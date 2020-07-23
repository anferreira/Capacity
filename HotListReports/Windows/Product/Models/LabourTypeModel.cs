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
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;



namespace HotListReports.Windows.Products{

class LabourTypeModel : BaseModel2{

public LabourTypeModel(Window window) : base(window){    
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Code","Name","DirInd");        
}
        
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay,60, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Code", "Code", BindingMode.OneWay,80, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Name", "LabName", BindingMode.OneWay,150, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DirInd", "DirInd", BindingMode.OneWay,50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                  
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
bool remove(ListView listView){
    bool bresult=false;
    try {
         LabourType labourType = (LabourType)this.deleltedSelected(listView);

        if (labourType != null){            
            getCoreFactory().deleteLabourType(labourType.Id);
            bresult=true;
        }

    } catch (Exception ex) {
        MessageBox.Show("remove Exception: " + ex.Message);        
    }
    return bresult;
}

public
void save(LabourType labourType){
    try{      
        if (labourType.Id > 0)
            getCoreFactory().updateLabourType(labourType);
        else            
            getCoreFactory().writeLabourType(labourType);

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}


}
}
