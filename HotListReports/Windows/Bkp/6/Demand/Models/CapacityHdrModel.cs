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
class CapacityHdrModel : BaseModel2{

private Hashtable hashMachinesById;

public CapacityHdrModel(Window window) : base(window){    
    this.hashMachinesById = new Hashtable();
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Id","Status");    
}
                
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Date Created", "DateCreated", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay, 50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay, 85, hdrListView);        
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
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,40, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Hot List", "HotListID", BindingMode.OneWay,40, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay, 150, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("IsFam", "IsFamily", BindingMode.OneWay,50, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,30, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        
        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay, 60, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("StartDate", "StartDate", BindingMode.OneWay, 65, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay, 65, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

                                                
        dtlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailsGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnPartDetailsGrid(ListView partDtlListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Sub#", "SubDetail", BindingMode.OneWay,40, partDtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CPHdr", "CPHdrID", BindingMode.OneWay,40, partDtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CPDtl", "CPDtlID", BindingMode.OneWay,40, partDtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay, 150, partDtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay, 60, partDtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

                                                
        partDtlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPartDetailsGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnRequirementGrid(ListView reqlListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Sub#", "SubDetail", BindingMode.OneWay,40, reqlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "Type", BindingMode.OneWay,40, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ReqID", "ReqID", BindingMode.OneWay,70, reqlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Code", "NameShow", BindingMode.OneWay,90, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Time", "Time", BindingMode.OneWay, 60, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Hours", "Hours", BindingMode.OneWay, 60, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());                 
                                                
        reqlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnRequirementGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnMachCapacityGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Priority", "Priority", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MachId", "MachineId", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "MachineShow", BindingMode.OneWay,85, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Planned", "Planned", BindingMode.OneWay, 50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Labour", "Labour", BindingMode.OneWay, 50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,150, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachCapacityGrid Exception: " + ex.Message);        
    }
}

public 
void showReport(ListView hdrListView){   
    try {        
        CapacityHdr capacityHdr = (CapacityHdr)getSelected(hdrListView);

        if (capacityHdr!= null){
            CapacityReportWindow capacityReportWindow = new CapacityReportWindow(capacityHdr);
            capacityReportWindow.ShowDialog();            
        }else
            MessageBox.Show("Pleas, Select Item First."); 

    } catch (Exception ex) {
       MessageBox.Show("showReport Exception: " + ex.Message); 
    }
}

private
CapacityHdr getCapacityOptions(){
    try {
        CapacityHdr capacityHdr = getCoreFactory().createCapacityHdr();
        capacityHdr.Plant = Configuration.DftPlant;
      
        CapacityOptionsWindow capacityOptionsWindow = new CapacityOptionsWindow(capacityHdr);
        if ((bool)capacityOptionsWindow.ShowDialog()) 
            return capacityHdr;

    }catch (Exception ex){
       MessageBox.Show("getCapacityOptions: " + ex.Message);  
    }
    return null;
}


public 
bool createCapacity(){
    bool    bresult = false;
    Cursor  cursorBkp = this.cursor;
    try {        
        
        CapacityHdr capacityHdr = getCapacityOptions();
        if (capacityHdr!= null) { 
            this.cursor = System.Windows.Input.Cursors.Wait;

            capacityHdr = coreFactory.processCapacityDemand(0,capacityHdr.Plant);
            this.cursor = cursorBkp;
            MessageBox.Show("Capacity Created OK.");
            bresult = true;
        }

    } catch (Exception ex) {
       MessageBox.Show("createCapacity Exception: " + ex.Message); 
    }finally {
        this.cursor = cursorBkp;
    }
    return bresult;
}

public 
bool delete(ListView listView){
    bool    bresult=false;
    try{
        CapacityHdr     capacityHdr = (CapacityHdr)deleltedSelected(listView);        

        if (capacityHdr != null){
            getCoreFactory().deleteCapacityHdr(capacityHdr.Id);
            bresult=true;
        }        
        
    }catch (Exception ex){
        MessageBox.Show("delete Exception: " + ex.Message);
    }   
    return bresult;
}

public
void searchMachineId(CapacityHdr capacityHdr,CapacityMachPriority capacityMachPriority){ 
    try{
        if (capacityHdr!= null && capacityMachPriority != null){             
            Machine machine = searchMachine(capacityHdr.Plant);
            if (machine != null){
                capacityMachPriority.MachineId  = machine.Id;
                capacityMachPriority.MachineShow= machine.Mach;
            }                           
        }                   

    }catch (Exception ex){
        MessageBox.Show("searchMachineId Exception: " + ex.Message);
    } 
}

public
void searchPartId(CapacityMachPriority capacityMachPriority){ 
    try{
        if (capacityMachPriority != null){             
            Product product = searchPart();                                
            if (product != null){
                capacityMachPriority.Part  = product.ProdID;                    
            }                           
        }                   

    }catch (Exception ex){
        MessageBox.Show("searchPartId Exception: " + ex.Message);
    } 
}

public 
bool delMachCapacity(ListView listView,CapacityHdr capacityHdr){
    bool    bresult=false;
    try{
        CapacityMachPriority    capacityMachPriority = (CapacityMachPriority)deleltedSelected(listView);        

        if (capacityHdr != null && capacityMachPriority!= null){

            capacityHdr.CapacityMachPriorityContainer.Remove(capacityMachPriority);
            getCoreFactory().updateCapacityHdrOnlyMachinePriority(capacityHdr);
            setDataContextListView(listView, capacityHdr.CapacityMachPriorityContainer);
            bresult=true;
        }        
        
    }catch (Exception ex){
        MessageBox.Show("delMachCapacity Exception: " + ex.Message);
    }   
    return bresult;
}

public
bool saveCapacityMachPriority(ListView machCapacityListView, CapacityHdr capacityHdr,CapacityMachPriority capacityMachPriority,bool badding){
    bool    bresult=false;
    try{
        if (badding)
            capacityHdr.CapacityMachPriorityContainer.Add(capacityMachPriority);
        else{ //edit copy info, remember we worked on cloned object
            CapacityMachPriority capacityMachPriorityModified = capacityHdr.CapacityMachPriorityContainer.getByKey(capacityMachPriority.HdrId, capacityMachPriority.Detail);
            if (capacityMachPriorityModified!=null)
                capacityMachPriorityModified.copy(capacityMachPriority);    
            capacityMachPriority= capacityMachPriorityModified;
        }

        getCoreFactory().updateCapacityHdrOnlyMachinePriority(capacityHdr);
        setDataContextListView(machCapacityListView,capacityHdr.CapacityMachPriorityContainer);        
        setSelected(machCapacityListView,capacityMachPriority);
        bresult=true;

    }catch (Exception ex){
        MessageBox.Show("saveCapacityMachPriority Exception: " + ex.Message);
    } 
    
    return bresult;
}

public
void loadReqDescription(CapacityReqContainer capacityReqContainer){
    try { 
        Machine machine=null;
    
        if (capacityReqContainer!= null) { 
            for (int i=0; i < capacityReqContainer.Count;i++) { 
                CapacityReq capacityReq = capacityReqContainer[i];

                if (capacityReq.Type.Equals(Constants.TYPE_MACHINE)){
                    machine=null;
                    if (hashMachinesById.Contains(capacityReq.ReqID))
                        machine = (Machine)hashMachinesById[capacityReq.ReqID];
                    else{
                        machine = getCoreFactory().readMachineById(capacityReq.ReqID);
                        if (machine!= null)
                            hashMachinesById.Add(capacityReq.ReqID,machine);
                    }

                    if (machine!= null)
                        capacityReq.NameShow= machine.Mach;
                }
            }
        }

    }catch (Exception ex){
        MessageBox.Show("loadReqDescription Exception: " + ex.Message);
    }
}


}
}
