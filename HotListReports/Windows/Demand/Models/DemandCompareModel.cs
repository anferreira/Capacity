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

DateTime    runDateCompare;
DateTime    runDateReport;
DateTime    runDateLocalReport;
DateTime    runDateLocalDateReport;

ListView    compareListView;
ListView    reportCompareListView;
ListView    localCompareListView;
ListView    localCompareAllDiffListView;

public DemandCompareModel(Window window, ListView compareListView, ListView reportCompareListView, ListView localCompareListView,ListView localCompareAllDiffListView) : base(window){    

    this.compareListView            = compareListView;
    this.reportCompareListView      = reportCompareListView;
    this.localCompareListView       = localCompareListView;
    this.localCompareAllDiffListView= localCompareAllDiffListView;

    runDateCompare          = DateUtil.MinValue;
    runDateReport           = DateUtil.MinValue;
    runDateLocalReport      = DateUtil.MinValue;
    runDateLocalDateReport  = DateUtil.MinValue;
}

public
DateTime RunDateCompare {
	get { return runDateCompare; }
	set { if (this.runDateCompare != value){
			this.runDateCompare = value;			
		}
	}
}

public
DateTime RunDateReport {
	get { return runDateReport; }
	set { if (this.runDateReport != value){
			this.runDateReport = value;			
		}
	}
}

public
DateTime RunDateLocalReport {
	get { return runDateLocalReport; }
	set { if (this.runDateLocalReport != value){
			this.runDateLocalReport = value;			
		}
	}
}

public
DateTime RunDateLocalDateReport {
	get { return runDateLocalDateReport; }
	set { if (this.runDateLocalDateReport != value){
			this.runDateLocalDateReport = value;			
		}
	}
}

public
DateTime getRunDate(int itabIndex){
    DateTime    runDate = DateUtil.MinValue;

    if (itabIndex == 0)
        runDate = RunDateCompare;
    else if (itabIndex == 1)
        runDate = RunDateReport;
    else if (itabIndex == 2)
        runDate = RunDateLocalReport;
    else if (itabIndex == 3)
        runDate = RunDateLocalDateReport;
    return runDate;
}

public
void setRunDate(int itabIndex,DateTime runDate){    
    if (itabIndex == 0)
        RunDateCompare = runDate;
    else if (itabIndex == 1)
        RunDateReport = runDate;
    else if (itabIndex == 2)
        RunDateLocalReport = runDate;
    else if (itabIndex == 3)
        RunDateLocalDateReport = runDate;
}

public
ListView getListView(int itabIndex){
    ListView    listView = compareListView;

    if (itabIndex == 0)
        listView = compareListView;
    else if (itabIndex == 1)
        listView = reportCompareListView;
    else if (itabIndex == 2)
        listView = localCompareListView;
    else if (itabIndex == 4)
        listView = localCompareAllDiffListView;
                
    return listView;
}

public
void loadTradingPartners(ComboBox comboBox,bool bAS400Mode,string splant,string source){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList           arrayList   = new ArrayList();
        string              saux        = "";        
        string[]            items       = null;        
        int                 imaxLen     = 0;
               
        arrayList   = bAS400Mode ?  getCoreFactory().readTrlpTradingPartners(splant,source) :
                                    getCoreFactory().readDemandDTradingPartners(splant,source);

        for (int i=0; i < arrayList.Count; i++){ //get max trading partner len
            items = (string[])arrayList[i];
            imaxLen = items[0].Length > imaxLen ? items[0].Length : imaxLen;
        }
        
        for (int i=0; i < arrayList.Count; i++){ 
            items = (string[])arrayList[i];
            saux = StringUtil.AddSpaces(items[0],imaxLen, true) + "-" + items[1];
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,items[0]));
        }
        setDataContextComboSelected(comboBox,list);        

    } catch (Exception ex) {
        MessageBox.Show("loadTradingPartners Exception: " + ex.Message);        
    }
}

public
void loadShipLocs(ComboBox comboBox,bool bAS400Mode,string splant,string source,string stpartner){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList           arrayList   = bAS400Mode ?  getCoreFactory().readTrlpShipLocs(stpartner) :
                                                        getCoreFactory().readDemandDShipLocs(splant,source,stpartner);
        string              saux        = "";
        
        for (int i=0; i < arrayList.Count; i++){ 
            saux = (string)arrayList[i];            
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,saux));
        }

        setDataContextComboSelected(comboBox,list);     

    } catch (Exception ex) {
        MessageBox.Show("loadShipLocs Exception: " + ex.Message);        
    }
}

public
void loadParts(ComboBox comboBox,bool bAS400Mode,string splant,string source,string stpartner,string shipLoc){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList           arrayList   = bAS400Mode ?  getCoreFactory().readTrlpPartsByFilters(stpartner, shipLoc) :
                                                        getCoreFactory().readDemandDPartsByFilters(splant,source,stpartner,shipLoc);
        string              saux        = "";
        
        for (int i=0; i < arrayList.Count; i++){ 
            saux = (string)arrayList[i];            
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux,saux));
        }

        setDataContextComboSelected(comboBox,list);     

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
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelDate", "RelDate", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        //if (DateUtil.minorHour(fromDate) >= DateUtil.getPriorMondayCurrWeek()){                        
            textBlockColumnListView = new TextBlockColumnListView("Past Due","PastDue",BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
            textBlockColumnListView.process();        
            textBlockColumnListView.setBinding("PastDue", BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new ValueDifferentZeroColorConverter(), "");
            textBlockColumnListView.process();        
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());   
        //}
                
        int         itotDay = Convert.ToInt32((toDate - fromDate).TotalDays);
        DateTime    date    = fromDate;
        string      sday    = "";

        for (int i=0; i < itotDay && i < Constants.MAX_HOTLIST_DAYS;i++){
            DateTime dateTimeAux = fromDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDateInfinite(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);
            
            sday = "Day0"   + (i+1).ToString("00");
           
                    /*
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());  
            */

            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
            textBlockColumnListView.process();        
            textBlockColumnListView.setBinding(sday, BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new ValueDifferentZeroColorConverter(), "");
            textBlockColumnListView.process();        
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
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

public
void removeColumns(ListView listView,DemandDCompareViewContainer demandDCompareViewContainer){
    GridView    view = (GridView)listView.View;

    if (view != null){        
        view = (GridView)listView.View;

        for (int i=0; i < view.Columns.Count; i++) { 
            GridViewColumn column = view.Columns[i];            
        }
    }
              
} 

public
void loadColumnsOnHeaderGrid(ListView listView,DateTime fromDate,DateTime toDate,DateTime runDate,DemandDCompareViewContainer demandDCompareViewContainer){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("RelNum", "RelNum", BindingMode.OneWay,110, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelDate", "RelDate", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        //if (DateUtil.minorHour(fromDate) >= DateUtil.getPriorMondayCurrWeek()){                        
            textBlockColumnListView = new TextBlockColumnListView("Past Due","PastDue",BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
            textBlockColumnListView.process();        
            textBlockColumnListView.setBinding("PastDue", BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new ValueDifferentZeroColorConverter(), "");
            textBlockColumnListView.process();        
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());   
        //}
                
        int         itotDay = Convert.ToInt32((toDate - fromDate).TotalDays);
        DateTime    date    = fromDate;
        string      sday    = "";

        for (int i=0; i < itotDay && i < Constants.MAX_HOTLIST_DAYS;i++){
            DateTime dateTimeAux = fromDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDateInfinite(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);
            
            sday = "Day0"   + (i+1).ToString("00");
           
                    /*
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());  
            */
            if (demandDCompareViewContainer.getFirstByDate(runDate,dateTimeAux) != null){ 
                textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
                textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
                textBlockColumnListView.process();        
                textBlockColumnListView.setBinding(sday, BindingMode.OneWay, TextBlock.ForegroundProperty);
                textBlockColumnListView.setConverter(new ValueDifferentZeroColorConverter(), "");
                textBlockColumnListView.process();        
                textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
                textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
                textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
                gridView.Columns.Add(textBlockColumnListView.process());   
            }
            
        }

        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHeaderLeftDatesGrid(ListView listView,DemandDCompareLeftViewContainer demandDCompareLeftViewContainer){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty,HorizontalAlignment.Center));

        textBlockColumnListView = new TextBlockColumnListView("Date", "RelDate", BindingMode.OneWay,80, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date2");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;             
        gridView.Columns.Add(textBlockColumnListView.process());

        if (demandDCompareLeftViewContainer.Count > 0){
            DemandDCompareLeftView      demandDCompareLeftView = demandDCompareLeftViewContainer[0];
            DemandRelease               demandRelease1 =  demandDCompareLeftView.DemandRelease1;
            DemandRelease               demandRelease2 =  demandDCompareLeftView.DemandRelease2;
            
            if (demandRelease1 != null)
                createReleaseDateColumn(listView,gridView,cell,demandRelease1);
            if (demandRelease2 != null) 
                createReleaseDateColumn(listView,gridView,cell,demandRelease2);                
        }
        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderLeftDatesGrid Exception: " + ex.Message);        
    }
}

private
TextBlockColumnListView createReleaseDateColumn(ListView listView, GridView gridView,Style cell,DemandRelease demandRelease1){
    TextBlockColumnListView textBlockColumnListView =null;

    if (demandRelease1 != null) { 
        //textBlockColumnListView = new TextBlockColumnListView("Release :"  + demandRelease1.Release + "\n" + "Rel Date :" + DateUtil.getDateRepresentation(demandRelease1.DateTime,DateUtil.MMDDYYYY), "DemandRelease1Qty", BindingMode.OneWay,120, listView);        

        textBlockColumnListView = new TextBlockColumnListView(demandRelease1.Release, "DemandRelease1Qty", BindingMode.OneWay,120, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.process();        
        textBlockColumnListView.setBinding("DemandRelease1Qty", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new ValueDifferentZeroColorConverter(), "");
        textBlockColumnListView.process();   
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;             

        gridView.Columns.Add(textBlockColumnListView.process());
    }
    return textBlockColumnListView;
}

public
bool exportExcel(ListView listView,string stitle,int itabIndex,bool bcolumnsWQty){
    bool bresult = false;
    try { 
        ExportListView exp = new ExportListView(listView);

        string                              stotal = exp.getHeaderValues();        
        DemandDCompareViewContainer         demandDCompareViewContainer         = listView.DataContext!= null && listView.DataContext is DemandDCompareViewContainer    ? (DemandDCompareViewContainer)listView.DataContext : getCoreFactory().createDemandDCompareViewContainer();
        DemandDCompareLeftViewContainer     demandDCompareLeftViewContainer     = listView.DataContext!= null && listView.DataContext is DemandDCompareLeftViewContainer? (DemandDCompareLeftViewContainer)listView.DataContext : getCoreFactory().createDemandDCompareLeftViewContainer();
        DemandDCompareReportViewContainer   demandDCompareReportViewContainer   = listView.DataContext!= null && listView.DataContext is DemandDCompareReportViewContainer ? (DemandDCompareReportViewContainer)listView.DataContext : getCoreFactory().createDemandDCompareReportViewContainer();
                
        string                              sfileName = "";
        string                              sfileNameAux = "DemandCompare "+ stitle  + " -" + DateUtil.getCompleteDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD).Replace('/','-').Replace(':','-') + ".csv";
                       
        if (demandDCompareViewContainer.Count > 0 && itabIndex!= 4) {             
            stotal+= demandDCompareViewContainer.exportToExcel(itabIndex);
            bresult = true;
        }

        if (demandDCompareViewContainer.Count > 0 && itabIndex!= 4){             
            stotal+= demandDCompareViewContainer.exportToExcel(itabIndex);
            bresult = true;
        }

        if (demandDCompareReportViewContainer.Count > 0){             
            stotal= demandDCompareReportViewContainer.exportToExcel(DateUtil.MinValue, bcolumnsWQty);
            bresult = true;
        }


        if (bresult) { 
            sfileName = ExportModel.generateFileName(sfileNameAux, "Exports", false);
            ExportModel.writeFile(sfileName,stotal,true);
        }else
            MessageBox.Show("There Is Not Information To Export.");
                            
    } catch (Exception ex) {
        MessageBox.Show("exportExcel Exception: " + ex.Message);      
    }
    return bresult;
}

public
void loadColumnsOnHeaderAllDiffGrid(ListView listView,DateTime fromDate,DateTime toDate,DateTime runDate,DemandDCompareViewContainer demandDCompareViewContainer){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("RelNum", "RelNum", BindingMode.OneWay,110, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelDate", "RelDate", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(),"Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TPartner", "TPartner", BindingMode.OneWay,80, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipLoc", "ShipLoc", BindingMode.OneWay,80, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,120, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        //if (DateUtil.minorHour(fromDate) >= DateUtil.getPriorMondayCurrWeek()){                        
            textBlockColumnListView = new TextBlockColumnListView("Past Due","PastDue",BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
            textBlockColumnListView.process();        
            textBlockColumnListView.setBinding("SPastDue", BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new ValueHotStringColorConverter(), "");
            textBlockColumnListView.process();        
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());   
        //}
                
        int         itotDay = Convert.ToInt32((toDate - fromDate).TotalDays);
        DateTime    date    = fromDate;
        string      sday    = "";
        string      ssday   = "";

        for (int i=0; i < itotDay && i < Constants.MAX_HOTLIST_DAYS;i++){
            DateTime dateTimeAux = fromDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDateInfinite(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);
            
            sday = "Day0"   + (i+1).ToString("00");
            ssday= "S"+sday;
           
                    /*
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());  
            */
            if (demandDCompareViewContainer.getFirstByDate(runDate,dateTimeAux) != null){ 
                textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
                textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
                textBlockColumnListView.process();        
                textBlockColumnListView.setBinding(ssday, BindingMode.OneWay, TextBlock.ForegroundProperty);
                textBlockColumnListView.setConverter(new ValueHotStringColorConverter(), "");
                textBlockColumnListView.process();        
                textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
                textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
                textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
                gridView.Columns.Add(textBlockColumnListView.process());   
            }
            
        }

        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderAllDiffGrid Exception: " + ex.Message);        
    }
}

public
void rewriteDemandCompareViewColumns(ListView listView, DemandDCompareReportViewContainer demandDCompareReportViewContainer, DateTime runDate,bool bcolumnsWQty){
    try {         
        createListViewColumns(listView,Constants.MAX_HOTLIST_DAYS + 1);
        GridView                view = (GridView)listView.View;
    
        FrameworkElementFactory frameworkElementFactory=null;
        DateTime                dateTimeAux = DateUtil.MinValue;
        bool                    bloadColumn = true;
        ArrayList               arrayRemoveColums = new ArrayList();
        DateTime                priorMonday = DateTime.Now;
        DateTime                nextSunday  = DateTime.Now;                        
        int                     iday =0;
        string                  sweek ="";
        string                  space ="   ";
        double                  dcornerRadius = 6;
        double                  dwith =60;
        double                  dheight =20;
        double                  dfonSize =12;
        string                  sbindPanel = "";
        FontWeight              fontWeight = FontWeights.UltraBold;        
        ListViewCol             listViewCol = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.FontSizeProperty, dfonSize));
        Setter          textAlignSetter = new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
        cell.Setters.Add(textAlignSetter);
            
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);

        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
            bloadColumn = true;
        
            listViewCol = new ListViewCol();
            sbindPanel = "";
            if (i > 1) { 
                iday = (i-2);

                fontWeight = FontWeights.Bold;
                dcornerRadius = 0;
                sweek       = "Week";
                sbindPanel  = "Day" + (iday+1).ToString("000");

                frameworkElementFactory=listViewCol.addTextBlock("QtyNew",     Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);//Honeydew
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");  
                frameworkElementFactory.SetBinding(TextBlock.ForegroundProperty,new Binding("Color"));

                frameworkElementFactory = listViewCol.addTextBlock("QtyOld", Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                frameworkElementFactory.SetBinding(TextBlock.ForegroundProperty,new Binding("Color"));

                frameworkElementFactory = listViewCol.addTextBlock("QtyDiffResult",     Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");                
                frameworkElementFactory.SetBinding(TextBlock.ForegroundProperty,new Binding("Color"));                 
            }
            
            column.HeaderContainerStyle = cell;        
            column.Width = dwith+10;
                
            switch (i){
                case 0:                                    
                    column.Header = space + "TPartner/ShipLoc/Part";                
                    column.Width = 150;
                    listViewCol.addTextBlock("TPartner",150,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);                    
                    listViewCol.addTextBlock("ShipLoc", 150,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("Part",    150,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);                                                  
                    break;
                case 1:
                    column.Header = space + "Release";
                    sbindPanel = "CellTitles";                
                    column.Width = 140;
                    listViewCol.addTextBlock("Title1",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title3",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);                         
                    break;

                default:
                    dateTimeAux = runDate.AddDays(iday);
                    string      sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
                    string      sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);            
                    string      sday = "Day0"   + (iday+1).ToString("00");

                    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);
                    column.Header = space + sweekTitle + "\n" + space + sdate;
                    break;                            
            }                  

            if (bcolumnsWQty && i > 1 && demandDCompareReportViewContainer.getFirstWithQtyNonZero(runDate.AddDays(iday)) == null){
                bloadColumn=false;
                arrayRemoveColums.Add(column.Header);
            }            
            column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);                                                         
        }    

        //check if any colmuns might be removed       
        for (int i=0; i < view.Columns.Count && arrayRemoveColums.Count > 0; i++){
            GridViewColumn  column  = (GridViewColumn)view.Columns.ElementAt(i);
            string          saux    = (string)column.Header;
            for (int j=0; j < arrayRemoveColums.Count; j++){                                       
                if (saux.Equals((string)arrayRemoveColums[j])) { 
                    view.Columns.RemoveAt(i);
                    i--;
                    arrayRemoveColums.RemoveAt(j);
                    break;
                }
            }
        }        

    } catch (Exception ex) {
        MessageBox.Show("rewriteDemandCompareViewColumns Exception: " + ex.Message);        
    }
}


}
}
