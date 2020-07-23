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

class RoutingModel : BaseModel2{

public RoutingModel(Window window) : base(window){    
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    searchByComboBox.Items.Add("Part");    
    searchByComboBox.Items.Add("Machine");        
    
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}

public
void loadTypeComboBox(ComboBox typeComboBox){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
     
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Labour Task",  RoutingLabTool.LABOUR_TYPE ));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Tool",    RoutingLabTool.TOOL_TYPE));     
                       
        setDataContextCombo(typeComboBox, list);           
    } catch (Exception ex) {
        MessageBox.Show("loadTypeComboBox Exception: " + ex.Message);        
    }
}
    
public
void loadRoutingTypeComboBox(ComboBox comboBox){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Main",Routing.ROUTING_TYPE_MAIN));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Alterna",Routing.ROUTING_TYPE_ALTERNATIVE));
       
        setDataContextCombo(comboBox,list);        

    } catch (Exception ex) {
        MessageBox.Show("loadTypeComboBox Exception: " + ex.Message);        
    }
}
                       
public
void loadToolComboBox(ComboBox toolComboBox){
    try {
        string[][] items = coreFactory.readToolByFilters("","","","",0);                   
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        string                  saux = "";
    
        for (int i=0; i < items.Length;i++){
            string[] item = items[i];

            saux = item[4] + " - " + item[5]; 
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, item[0]));
        }
                       
        setDataContextCombo(toolComboBox, list);   
        
    } catch (Exception ex) {
        MessageBox.Show("loadToolComboBox Exception: " + ex.Message);        
    }
}
        
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay,60, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "ProdID", BindingMode.OneWay,150, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;             
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
     
        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plt", BindingMode.OneWay,60, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,60, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
 
        textBlockColumnListView = new TextBlockColumnListView("Machine", "Cfg", BindingMode.OneWay,80, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell; 
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RutTyp", "RoutingType", BindingMode.OneWay,30, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell; 
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RunStd", "RunStd", BindingMode.OneWay,40, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CycleTm", "CycleTm", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CavNum", "CavityNum", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CavAvail", "CavAvail", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OptRunQty", "OptRunQty", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Lev", "ProdLev", BindingMode.OneWay,15, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RepPoint", "RepPoint", BindingMode.OneWay,50, hdrListView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyMen", "QtyMen", BindingMode.OneWay,50, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyMachine", "QtyMachines", BindingMode.OneWay,50, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TotLabTypes", "TotLabourTypes", BindingMode.OneWay,60, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TotTools", "TotTools", BindingMode.OneWay,60, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                 
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public      
void loadColumnsOnDetailsGrid(ListView dtlListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#","Detail", BindingMode.OneWay,40, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Type","Type", BindingMode.OneWay,70, dtlListView);
        textBlockColumnListView.setConverter(new LabourTypeToolConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ReqId", "ReqId", BindingMode.OneWay,50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description", "NameShow", BindingMode.OneWay,120, dtlListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TotEmployee", "TotEmployees", BindingMode.OneWay,60, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "0.00");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
                                                
        dtlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailsGrid Exception: " + ex.Message);        
    }
}

public
void removeLabTool(Routing routing,ListView dtlListView){
    try {
        RoutingLabTool routingLabTool = (RoutingLabTool)this.deleltedSelected(dtlListView);

        if (routingLabTool!=null){
            routing.RoutingLabToolContainer.Remove(routingLabTool);
            save(routing);
        }

    } catch (Exception ex) {
        MessageBox.Show("removeLabTool Exception: " + ex.Message);        
    }
}

public
RoutingLabTool addModifyLabTool(Routing routing,RoutingLabTool routingLabToolNew,string sdesc,bool baddDtl){    
    RoutingLabTool routingLabTool = null;
    try {        
        if (routing!= null && routingLabToolNew != null){
            routingLabToolNew.NameShow = sdesc;            
            if (baddDtl){
                routingLabTool = routingLabToolNew;
                routing.RoutingLabToolContainer.Add(routingLabTool);         
            }else{
                routingLabTool = routing.RoutingLabToolContainer.getByKey(routingLabToolNew.HdrId, routingLabToolNew.Detail);//find original object
                if (routingLabTool!=null)
                    routingLabTool.copy(routingLabToolNew); //copy from cloned object                    
                else
                    MessageBox.Show("Sorry, Can Not Find LabourTool :" + routingLabToolNew.HdrId + "/" +  routingLabToolNew.Detail);
            }
                
        }
    } catch (Exception ex) {
        MessageBox.Show("addModifyLabTool Exception: " + ex.Message);        
    }
    return routingLabTool;
}

public
void save(Routing routing){
    try{
        routing.fillRedundances();
        getCoreFactory().updateRouting(routing);                    

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}

public
string getSelectedDesc(ComboBox typeComboBox,ComboBox labourComboBox, ComboBox toolComboBox){    
    string      sdesc = "";  
    string      sreqId="";   
    try{
        string      stype = (string)getSelectedComboBoxItem(typeComboBox);    
        if (stype!=null){
            switch(stype){
                case RoutingLabTool.LABOUR_TYPE:
                    sreqId = (string)getSelectedComboBoxItem(labourComboBox);    
                    if (!string.IsNullOrEmpty(sreqId)){
                        sdesc = getShiftTaskDesc(Convert.ToInt32(sreqId));                        
                    }  
                    break;
                 case RoutingLabTool.TOOL_TYPE:
                    sreqId = (string)getSelectedComboBoxItem(toolComboBox); 
                    if (!string.IsNullOrEmpty(sreqId)){
                        sdesc = getToolDesc(Convert.ToInt32(sreqId));                        
                    }                                 
                    break;
            }    
        }
    }catch (Exception ex){
        MessageBox.Show("getSelectedDesc Exception: " + ex.Message);
    }                                                    
    return sdesc;
}

public
string getShiftTaskDesc(int ireqId){    
    string      sdesc = "";      
    try{
        CapShiftTask capShiftTask = getCoreFactory().readCapShiftTask(ireqId);
        if (capShiftTask != null)
            sdesc = capShiftTask.TaskName;                    
    }catch (Exception ex){
        MessageBox.Show("getShiftTaskDesc Exception: " + ex.Message);
    }                                                    
    return sdesc;
}

public
string getToolDesc(int ireqId){    
    string      sdesc = "";      
    try{
        sdesc = getCoreFactory().getToolDescriptionById(ireqId);               
    }catch (Exception ex){
        MessageBox.Show("getToolDesc Exception: " + ex.Message);
    }                                                    
    return sdesc;
}

public
RoutingContainer copy(ListView hdrListView){
     RoutingContainer    routingContainer = getCoreFactory().createRoutingContainer();
    try{
        Routing             routing=null;
        Routing             routingAux=null;       
        IList               list = hdrListView.SelectedItems;
        
        if (list.Count > 0){
            RoutingWindow routingWindow = new RoutingWindow(true,"",null);
            if ((bool)routingWindow.ShowDialog()){
                routingAux = routingWindow.getSelected();  //selected routing to copy as base
                if (routingAux!= null)
                    routing = getCoreFactory().readRouting(routingAux.Id);
            }

            if (routing!=null){
                if (System.Windows.Forms.MessageBox.Show("Do You Want To Copy Labour/Tools From Routing Selected ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
                    for (int i=0; i < list.Count;i++){
                        routingAux = (Routing)list[i];
                        routingAux.RoutingLabToolContainer = routing.RoutingLabToolContainer;
                        getCoreFactory().updateRouting(routingAux);
                        routingContainer.Add(routingAux);
                    }
                    MessageBox.Show("Total Routings Changed :" + routingContainer.Count.ToString() + ".");                   
                }
            }
        }

    }catch (Exception ex){
        MessageBox.Show("copy Exception: " + ex.Message);
    }  
    return routingContainer;
    
}
public
bool createDefaults(){
    bool bresult=false;
    try{
        if (System.Windows.Forms.MessageBox.Show("Do You Want To Create Defaults Labour Routings For Routings Without Labours Associated ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
            int icountRoutings = getCoreFactory().createDefaultsRoutingLabour();
            MessageBox.Show("Total Routings/Labour Associated : " + icountRoutings.ToString() + ".");

            bresult=true;
        }

    } catch (Exception ex) {
        MessageBox.Show("createDefaults Exception: " + ex.Message);        
    }
    return bresult;
}


}
}
