using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Machines;
using HotListReports.Windows.Products;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Demand{

class DemandCompareModel : BaseModel2{


public DemandCompareModel(Window window) : base(window){    
    
}

public
void loadTradingPartners(ComboBox comboBox,string splant){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList           arrayList   = getCoreFactory().readDemandDTradingPartners(splant);
        string              saux        = "";        
        string[]            items       = null;        
        int                 imaxLen     = 0;

        for (int i=0; i < arrayList.Count; i++){ //get max trading partner len
            items = (string[])arrayList[i];
            imaxLen = items[0].Length > imaxLen ? items[0].Length : imaxLen;
        }

        for (int i=0; i < arrayList.Count; i++){ 
            items = (string[])arrayList[i];
            saux = StringUtil.AddSpaces(items[0],imaxLen, true) + "-" + items[1];
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,items[0]));
        }
        setDataContextCombo(comboBox,list);        

    } catch (Exception ex) {
        MessageBox.Show("loadTradingPartners Exception: " + ex.Message);        
    }
}


public
void loadShipLocs(ComboBox comboBox,string splant,string stpartner){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList           arrayList   = getCoreFactory().readDemandDShipLocs(splant,stpartner);
        string              saux        = "";
        
        for (int i=0; i < arrayList.Count; i++){ 
            saux = (string)arrayList[i];            
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,saux));
        }

        setDataContextCombo(comboBox,list);     

    } catch (Exception ex) {
        MessageBox.Show("loadShipLocs Exception: " + ex.Message);        
    }
}

public
void loadParts(ComboBox comboBox,string splant,string stpartner,string shipLoc){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList           arrayList   = getCoreFactory().readDemandDPartsByFilters(splant,stpartner,shipLoc);
        string              saux        = "";
        
        for (int i=0; i < arrayList.Count; i++){ 
            saux = (string)arrayList[i];            
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,saux));
        }

        setDataContextCombo(comboBox,list);     

    } catch (Exception ex) {
        MessageBox.Show("loadParts Exception: " + ex.Message);        
    }
}
                
public
void loadColumnsOnHeaderGrid(ListView listView,DateTime fromDate,DateTime toDate){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("RelNum", "RelNum", BindingMode.OneWay,110, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelDate", "RelDate", BindingMode.OneWay,70, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());
                
        int         itotDay = Convert.ToInt32((toDate - fromDate).TotalDays);
        DateTime    date    = fromDate;
        string      sday    = "";

        for (int i=0; i < itotDay && i < Constants.MAX_HOTLIST_DAYS;i++){
            DateTime dateTimeAux = fromDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);
            
            sday = "Day0"   + (i+1).ToString("00");
           
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());  
            
        }

        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
Product searchPart(TextBox partTextBox){ 
    Product product = null;
    try{       
        product = searchPart();
        if (product!= null)
            partTextBox.Text = product.ProdID;
                           
    }catch (Exception ex){
        MessageBox.Show("searchPart Exception: " + ex.Message);
    } 
    return product;
}

}
}
