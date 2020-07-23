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
using Telerik.Windows.Controls;
using FarsiLibrary.FX.Win.Controls;


namespace HotListReports.Windows.Inventories{


class InventoryObjectivesModel : BaseModel2{

private InventoryObjectiveHdr inventoryObjectiveHdr;
//private DateColumnListView dateColumnListView = null;
private DateRadColumnListView           dateRadColumnListView = null;
private SelectionChangedEventHandler    handler =null;
private bool                            benableDateTimeEvent=false;
private Hashtable                       hashProducts;
private Hashtable                       hashInventory;

private ListView partsListView,partsDtlListView,bomListView;

public InventoryObjectivesModel(Window window, ListView partsListView, ListView partsDtlListView, ListView bomListView) : base(window){    
    
    this.inventoryObjectiveHdr = null;
    this.partsListView = partsListView;
    this.partsDtlListView = partsDtlListView;
    this.bomListView = bomListView;
    this.hashProducts = new Hashtable();
    this.hashInventory = new Hashtable();
}

public
InventoryObjectiveHdr InventoryObjectiveHdr {
	get { return inventoryObjectiveHdr; }
	set { if (this.inventoryObjectiveHdr != value){
			this.inventoryObjectiveHdr = value;			
		}
	}
}

public
void loadColumnsOnHeaderGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;        
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Date Created", "DateCreated", BindingMode.OneWay,90, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay, 50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                              
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnPartGrid(ListView listView){
    try {
       GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Dtl", "Detail", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,150,listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qoh", "QohShow", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Mst", "Master", BindingMode.OneWay,30,listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DayOHand", "DaysOnHandShow", BindingMode.OneWay,50,listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                             
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"0.0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("AutoCalc", "ObectivesAutomaticCalc", BindingMode.OneWay,50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPartList Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnPartsDtlGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;       
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Sub#", "SubDtl", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                /*
        dateColumnListView = new DateColumnListView("Date", "DateObjective", BindingMode.TwoWay,90, listView);
        dateColumnListView.getColumn().HeaderContainerStyle = cell;
        dateColumnListView.setEvent(FXDatePicker.LostFocusEvent, new RoutedEventHandler(dateObjectiveLostFocusEvent));
        handler = new SelectionChangedEventHandler(dateObjectiveSelectionEvent);
        dateColumnListView.setEvent(FXDatePicker.SelectionChangedEvent,handler);
        dateColumnListView.setEvent(FXDatePicker.GotFocusEvent, new RoutedEventHandler(dateObjectiveGotFocus));        
        gridView.Columns.Add(dateColumnListView.process());
        */
   
        dateRadColumnListView = new DateRadColumnListView("Date", "DateObjective", BindingMode.TwoWay,100, listView);
        dateRadColumnListView.getColumn().HeaderContainerStyle = cell;
        dateRadColumnListView.setEvent(RadDateTimePicker.LostFocusEvent, new RoutedEventHandler(dateObjectiveLostFocusEvent));
        handler = new SelectionChangedEventHandler(dateObjectiveSelectionEvent);
        dateRadColumnListView.setEvent(RadDateTimePicker.SelectionChangedEvent,handler);
        dateRadColumnListView.setEvent(RadDateTimePicker.GotFocusEvent, new RoutedEventHandler(dateObjectiveGotFocus));        
        dateRadColumnListView.setProperty(RadDateTimePicker.InputModeProperty,Telerik.Windows.Controls.InputMode.DatePicker);
        dateRadColumnListView.setProperty(RadDateTimePicker.BackgroundProperty,new SolidColorBrush(UIColors.COLOR_SELECT));
        gridView.Columns.Add(dateRadColumnListView.process());
               
        textColumnListView = new TextColumnListView("TargDayOHand", "DaysOnHand",BindingMode.TwoWay,80, listView);   
        textColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textColumnListView.getColumn().HeaderContainerStyle = cell;                 
        textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                             
        textColumnListView.setConverter(new DecimalToStringConverterNew(),"0.0");
        textColumnListView.setEvent(TextBox.LostFocusEvent, new RoutedEventHandler(daysOnHandTextBoxLostFocus));
        gridView.Columns.Add(textColumnListView.process()); 

        textColumnListView = new TextColumnListView("WeeklyReq", "Qty", BindingMode.TwoWay,80, listView);
        textColumnListView.getColumn().HeaderContainerStyle = cell;        
        textColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textColumnListView.setConverter(new DecimalToStringConverterNew(),"int");    
        textColumnListView.setEvent(TextBox.LostFocusEvent, new RoutedEventHandler(requiredTextBoxLostFocus));
        gridView.Columns.Add(textColumnListView.process()); 

                /*
        textColumnListView = new TextColumnListView("Reported", "QtyReported", BindingMode.TwoWay, 80, listView);
        textColumnListView.getColumn().HeaderContainerStyle = cell;        
        textColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textColumnListView.setEvent(TextBox.LostFocusEvent, new RoutedEventHandler(reportedTextBoxLostFocus));
        gridView.Columns.Add(textColumnListView.process()); */
        
        textBlockColumnListView = new TextBlockColumnListView("DailyReq", "DailyRequiredShow", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("WeekConsum", "QtyHotListShow", BindingMode.OneWay,65, listView);        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "int");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DailyConsum", "QtyDailyHotListShow", BindingMode.OneWay,60, listView);        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "");
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPartsDtlGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnBomGrid(ListView listView){
    try {
        GridView                gridView = new GridView();// loadBaseColumnsOnHotList(listView);
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        string                  sday = "";
    
        textBlockColumnListView = new TextBlockColumnListView("Lev", "Level", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Date", "DateObjective", BindingMode.OneWay,70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(),"Date");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "Prod", BindingMode.OneWay,150,listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qoh", "Qoh", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        gridView.Columns.Add(textBlockColumnListView.process());
     
        textBlockColumnListView = new TextBlockColumnListView("QtyPer", "Qty", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("QtyBase", "QtyBase", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("WeeklyReq", "QtyTotal", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("WkNetReq", "QtyHotList", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotListDateOnTopGrid Exception: " + ex.Message);        
    }
}
        
private 
void daysOnHandTextBoxLostFocus(object sender, RoutedEventArgs e){
    decimalLostFocus((TextBox)sender,1);
}                
private 
void requiredTextBoxLostFocus(object sender, RoutedEventArgs e){
    decimalLostFocus((TextBox)sender,2);
}

private 
void reportedTextBoxLostFocus(object sender, RoutedEventArgs e){
    decimalLostFocus((TextBox)sender,3);
} 

private
void decimalLostFocus(TextBox textBox,int index){
    try { 
        InventoryObjectivePartDtl   inventoryObjectivePartDtl = textBox != null ? (InventoryObjectivePartDtl)textBox.DataContext : null;
        decimal                     dvalueOriginal =0;
            
        switch(index){
            case 1:  dvalueOriginal = inventoryObjectivePartDtl.DaysOnHand;break;               
            case 2:  dvalueOriginal = inventoryObjectivePartDtl.Qty;break;               
            case 3:  dvalueOriginal = inventoryObjectivePartDtl.QtyReported;break;               
        }                                
        
        if (textBox!= null && inventoryObjectivePartDtl!= null){
            if (NumberUtil.isDecimalNumber(textBox.Text)){
                decimal daux = decimal.Parse(textBox.Text);
                if (true){

                    switch(index){
                        case 1: inventoryObjectivePartDtl.DaysOnHand = daux;recalculateInventoryObjectivesDtl(inventoryObjectivePartDtl);break;               
                        case 2: inventoryObjectivePartDtl.Qty = daux; break;               
                        case 3:
                            if (daux > inventoryObjectivePartDtl.Qty)   inventoryObjectivePartDtl.QtyReported = inventoryObjectivePartDtl.Qty;
                            else                                        inventoryObjectivePartDtl.QtyReported = daux;
                            break;               
                    }                                    
                    save();
                }
            }else
                textBox.Text = Convert.ToInt64(dvalueOriginal).ToString();            
        }
    }catch (Exception ex){
        MessageBox.Show("decimalLostFocus Exception: " + ex.Message);
    }
}

private 
void dateObjectiveLostFocusEvent(object sender, RoutedEventArgs e){
    benableDateTimeEvent = false;
}

private 
void dateObjectiveGotFocus(object sender, RoutedEventArgs e){
    benableDateTimeEvent = true;
}

private 
void dateObjectiveSelectionEvent(object sender, SelectionChangedEventArgs e){
    if (benableDateTimeEvent) { 
        RadDateTimePicker           radDateTimePicker = (RadDateTimePicker)sender;
        InventoryObjectivePartDtl   inventoryObjectivePartDtl = radDateTimePicker!= null ? (InventoryObjectivePartDtl)radDateTimePicker.DataContext : null;
        if (radDateTimePicker != null && inventoryObjectivePartDtl!= null) { 
            inventoryObjectivePartDtl.DateObjective = DateUtil.getNextFridayFromDate(inventoryObjectivePartDtl.DateObjective);
            recalculateInventoryObjectivesDtl(inventoryObjectivePartDtl);
            save();
        }
    }
} 

/*
private 
void dateObjectiveSelectionEvent(object sender, SelectionChangedEventArgs e){
    if (benableDateTimeEvent) { 
        FXDatePicker dateTimePicker = (FXDatePicker)sender;
        InventoryObjectivePartDtl inventoryObjectivePartDtl = dateTimePicker != null ? (InventoryObjectivePartDtl)dateTimePicker.DataContext : null;
        if (dateTimePicker != null && inventoryObjectivePartDtl!= null)
            save();
    }
}  
*/

public 
bool del(ListView listView){
    bool bresult = false;
    try { 
        inventoryObjectiveHdr = (InventoryObjectiveHdr)deleltedSelected(listView);
        if (inventoryObjectiveHdr!= null)   {             
            getCoreFactory().deleteInventoryObjectiveHdr(inventoryObjectiveHdr.Id);
            bresult = true;
        }
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }
    return bresult;
}

public 
void save(){    
    try{        
        if (getCoreFactory()!= null) { 
            if (inventoryObjectiveHdr.Id > 0)
                getCoreFactory().updateInventoryObjectiveHdr(inventoryObjectiveHdr);
            else
                getCoreFactory().writeInventoryObjectiveHdr(inventoryObjectiveHdr);
        }
                                                   
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }                       
}

public
InventoryObjectiveHdr createInventoryObjectives(){
    inventoryObjectiveHdr = getCoreFactory().createInventoryObjectiveHdr();    
    return inventoryObjectiveHdr;
}

public
InventoryObjectivePart loadModifyPart(bool baddingDtl,ListView listView,InventoryObjectivePart inventoryObjectivePart){
    InventoryObjectivePart inventoryObjectivePartOriginal = inventoryObjectivePart;            
    try{
        if (baddingDtl)
            inventoryObjectiveHdr.InventoryObjectivePartContainer.Add(inventoryObjectivePart);
        else{
            inventoryObjectivePartOriginal = inventoryObjectiveHdr.InventoryObjectivePartContainer.getByKey(inventoryObjectivePart.HdrId, inventoryObjectivePart.Detail);
            if (inventoryObjectivePartOriginal != null)
                inventoryObjectivePartOriginal.copy(inventoryObjectivePart);
        }  
           
        save();
        setDataContextListView(listView,loadPartQoh(inventoryObjectiveHdr.InventoryObjectivePartContainer, inventoryObjectiveHdr.Plant));
        setSelected(listView, inventoryObjectivePartOriginal);

    }catch (Exception ex){
        MessageBox.Show("loadModifyPart Exception: " + ex.Message);
    }         
    return inventoryObjectivePartOriginal;                            
}

public
bool removePart(ListView listView){    
    bool    bresult = false;
    try{ 
        InventoryObjectivePart  inventoryObjectivePart = (InventoryObjectivePart)deleltedSelected(listView);
        if (inventoryObjectivePart!= null){
            inventoryObjectiveHdr.InventoryObjectivePartContainer.Remove(inventoryObjectivePart);
            save();        
            bresult = true;
        }

    }catch (Exception ex){
        MessageBox.Show("removePart Exception: " + ex.Message);
    } 
    return bresult;     
}

public
InventoryObjectivePart modifyPart(ListView listView,ComboBox combo){    
    InventoryObjectivePart inventoryObjectivePart       = (InventoryObjectivePart)getSelected(listView);    
    InventoryObjectivePart inventoryObjectivePartClone  = getCoreFactory().createInventoryObjectivePart();

    if (inventoryObjectivePart != null){
        inventoryObjectivePartClone.copy(inventoryObjectivePart);        
        loadPartSequences(combo,inventoryObjectivePart.Part);
    }
    return inventoryObjectivePartClone;
}

public
void loadPartSequences(ComboBox comboBox, InventoryObjectivePart inventoryObjectivePart){
    try {
        if (inventoryObjectivePart!= null){

            loadPartSequences(comboBox,inventoryObjectivePart.Part);

            if (comboBox.Items.Count > 0){
                comboBox.SelectedIndex = comboBox.Items.Count-1;
                string sseq = (string)getSelectedComboBoxItem(comboBox);
                if (NumberUtil.isIntegerNumber(sseq))
                    inventoryObjectivePart.Seq = int.Parse(sseq);
            }

        }
              
    } catch (Exception ex) {
        MessageBox.Show("loadPartSequences Exception: " + ex.Message);        
    }
}

public 
void loadPartsDtl(ListView listView,ListView dtlsListView) {
    try { 
        /*
        if (dateRadColumnListView!=null && handler != null) { 
            try { 
                dateRadColumnListView.removeEvent(RadDateTimePicker.SelectionChangedEvent, handler);
            }catch { }
            handler = null;                                    
        }*/
        
       // benableDateTimeEvent = false;
        InventoryObjectivePart              inventoryObjectivePart = (InventoryObjectivePart)getSelected(listView);
        InventoryObjectivePart              inventoryObjectivePartClone = getCoreFactory().createInventoryObjectivePart();
        InventoryObjectivePartDtlContainer  inventoryObjectivePartDtlContainer = getCoreFactory().createInventoryObjectivePartDtlContainer();

        if (inventoryObjectivePart!= null)
            inventoryObjectivePartClone = getCoreFactory().cloneInventoryObjectivePart(inventoryObjectivePart);

        setDataContextListView(dtlsListView, inventoryObjectivePart != null ? loadPartDtlQtyHotList(inventoryObjectivePart) : null);

    } catch (Exception ex) {
       // MessageBox.Show("loadPartsDtl Exception: " + ex.Message);        
    }finally{
        //benableDateTimeEvent=true;
        /*
        if (dateRadColumnListView != null && handler==null) { 
            handler = new SelectionChangedEventHandler(dateObjectiveLostFocusEvent);            
            try { 
                dateRadColumnListView.setEvent(RadDateTimePicker.SelectionChangedEvent,handler);
            }catch { }
        }*/
    }
}

public
InventoryObjectivePartContainer loadPartQoh(InventoryObjectivePartContainer inventoryObjectivePartContainer,string splant){
        
    InventoryObjectivePart inventoryObjectivePart = null;
    for (int i=0; i < inventoryObjectivePartContainer.Count;i++){
        inventoryObjectivePart = inventoryObjectivePartContainer[i];

        Inventory inventory = getInventoryHash(inventoryObjectivePart.Part,splant);//inventory        
        inventoryObjectivePart.QohShow = inventory!= null ? inventory.getTotalInventory(inventoryObjectivePart.Seq) : 0;                             

        Product product = getProductHash(inventoryObjectivePart.Part);
        if (product!= null)
            inventoryObjectivePart.DaysOnHandShow = product.DaysOnHand;
    }    
        
    return inventoryObjectivePartContainer;
}

private
InventoryObjectivePartDtlContainer loadPartDtlQtyHotList(InventoryObjectivePart inventoryObjectivePart) {
    InventoryObjectivePartDtlContainer inventoryObjectivePartDtlContainer = null;

    if (inventoryObjectivePart != null) { 
        inventoryObjectivePartDtlContainer = inventoryObjectivePart.InventoryObjectivePartDtlContainer;

        InventoryObjectivePartDtl inventoryObjectivePartDtl= null;
        for (int i=0; i < inventoryObjectivePartDtlContainer.Count;i++){
            inventoryObjectivePartDtl = inventoryObjectivePartDtlContainer[i];

            inventoryObjectivePartDtl.PartShow = inventoryObjectivePart.Part;
            inventoryObjectivePartDtl.SeqShow = inventoryObjectivePart.Seq;
            inventoryObjectivePartDtl.QtyHotListShow = getHotListQtyForWeek(inventoryObjectivePartDtl.PartShow, inventoryObjectivePartDtl.SeqShow, inventoryObjectivePartDtl.DateObjective);       
        }    
    }
    return inventoryObjectivePartDtlContainer;
}

public
InventoryObjectivePartDtl createDtl(ListView listView){    
    InventoryObjectivePartDtl   inventoryObjectivePartDtl = getCoreFactory().createInventoryObjectivePartDtl();
    Product                     product = null;         

    try{                        
        InventoryObjectivePart inventoryObjectivePart = (InventoryObjectivePart)getSelected(listView);
        if (inventoryObjectivePart!= null){ 
        
            InventoryObjectivePartDtl   inventoryObjectivePartDtlLast = inventoryObjectivePart.InventoryObjectivePartDtlContainer.Count > 0 ? inventoryObjectivePart.InventoryObjectivePartDtlContainer[inventoryObjectivePart.InventoryObjectivePartDtlContainer.Count-1] : null;
        
            inventoryObjectivePartDtl.PartShow  = inventoryObjectivePart.Part;
            inventoryObjectivePartDtl.SeqShow   = inventoryObjectivePart.Seq;
            if (inventoryObjectivePartDtlLast!= null) {
                inventoryObjectivePartDtl.DateObjective = inventoryObjectivePartDtlLast.DateObjective.AddDays(7);
                if (inventoryObjectivePartDtl.DateObjective < DateTime.Now) //if date if old , we try with next friday
                    inventoryObjectivePartDtl.DateObjective = DateUtil.getNextFridayFromDate(DateTime.Now);

                inventoryObjectivePartDtl.Qty           = inventoryObjectivePartDtlLast.Qty;
                inventoryObjectivePartDtl.DaysOnHand    = inventoryObjectivePartDtlLast.DaysOnHand;
            }else
                inventoryObjectivePartDtl.DateObjective = DateUtil.getNextFridayFromDate(DateTime.Now);

            product  = getCoreFactory().readProduct(inventoryObjectivePart.Part); //read part to get DaysOnHand
            if (product!= null)
                inventoryObjectivePartDtl.DaysOnHand= product.DaysOnHand;

            recalculateInventoryObjectivesDtl(inventoryObjectivePartDtl);
        }

    }catch (Exception ex){
        MessageBox.Show("createDtl Exception: " + ex.Message);
    } 

    return inventoryObjectivePartDtl;
}

public
bool removeDtl(ListView listView, ListView dtlsListView){    
    bool    bresult = false;
    try{ 
        InventoryObjectivePart      inventoryObjectivePart = (InventoryObjectivePart)getSelected(listView);
        InventoryObjectivePartDtl   inventoryObjectivePartDtl = (InventoryObjectivePartDtl)deleltedSelected(dtlsListView);
        if (inventoryObjectivePart!= null && inventoryObjectivePartDtl != null){
            inventoryObjectivePart.InventoryObjectivePartDtlContainer.Remove(inventoryObjectivePartDtl);
            save();        
            
            loadPartsDtl(listView,dtlsListView);
            bresult = true;
        }

    }catch (Exception ex){
        MessageBox.Show("removePart Exception: " + ex.Message);
    } 
    return bresult;     
}

public
InventoryObjectivePartDtl loadModifyPartDtl(bool baddingDtl,ListView listView,ListView dtlsListView,InventoryObjectivePartDtl inventoryObjectivePartDtl){
    InventoryObjectivePartDtl inventoryObjectivePartDtlOriginal = null;            
    try{
        InventoryObjectivePart      inventoryObjectivePart = (InventoryObjectivePart)getSelected(listView);

        if (inventoryObjectivePart!= null) { 
            if (baddingDtl) { 
                inventoryObjectivePartDtlOriginal = inventoryObjectivePartDtl;  
                inventoryObjectivePart.InventoryObjectivePartDtlContainer.Add(inventoryObjectivePartDtl);
            }else{
                inventoryObjectivePartDtlOriginal = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getBySubDtl(inventoryObjectivePartDtl.SubDtl);
                if (inventoryObjectivePartDtlOriginal != null)
                    inventoryObjectivePartDtlOriginal.copy(inventoryObjectivePartDtl);
            }

            if (baddingDtl)
                inventoryObjectivePart.InventoryObjectivePartDtlContainer.sortByDate();
            save();                    
            loadPartsDtl(listView,dtlsListView);    
            setSelected(dtlsListView,inventoryObjectivePartDtlOriginal);  
        }

    }catch (Exception ex){
        MessageBox.Show("loadModifyPartDtl Exception: " + ex.Message);
    }         
    return inventoryObjectivePartDtlOriginal;                            
}
        

public 
void searchPart(ListView listView){
    try { 
        
    }catch (Exception ex){
        MessageBox.Show("searchPart Exception: " + ex.Message);
    }
}

public
void searchPartDtl(ListView listView, InventoryObjectivePart inventoryObjectivePart,DateTime dateObjective){
    try{         
        if (inventoryObjectivePart!= null && dateObjective!= null) {                         
            InventoryObjectivePartDtl inventoryObjectivePartDtl = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getByDate(dateObjective);
            if (inventoryObjectivePartDtl!= null){ 
                setSelected(listView, inventoryObjectivePartDtl);                
            }                        
        }    

    }catch (Exception ex){
        MessageBox.Show("searchPartDtl Exception: " + ex.Message);
    }                       
} 

public
HotListContainer generateListBom(bool bqtyCumulative,string sreportedPoint){    
    HotListContainer    hotListSumContainer = getCoreFactory().createHotListContainer();
    try{ 
        InventoryObjectivePart      inventoryObjectivePart = (InventoryObjectivePart) getSelected(partsListView);
        InventoryObjectivePartDtl   inventoryObjectivePartDtl = (InventoryObjectivePartDtl) getSelected(partsDtlListView);
        BomContainer                sumBomContainer = getCoreFactory().createBomContainer();
        BomContainer                currBomContainer= getCoreFactory().createBomContainer();
        Bom                         bom = null;
        BomObjectivesView           bomViewChild=null;
        DateTime                    dateRequired = inventoryObjectivePartDtl!= null ? inventoryObjectivePartDtl.DateObjective : DateUtil.getNextFridayFromDate(DateTime.Now);

        if (inventoryObjectivePart != null){
            bom = getCoreFactory().makeBom(inventoryObjectivePart.Part,inventoryObjectivePart.Seq,inventoryObjectiveHdr.Plant);

            if (bom!= null){
                BomObjectivesView bomView = getCoreFactory().createBomObjectivesView(bom);
                bomView.QtyBase = inventoryObjectivePartDtl!= null ? inventoryObjectivePartDtl.Qty : 0;
                bomView.reconvert(); //convert to BomObjectivesView objects and qty recalculated

                int     imaxLevel = 0;
                bom.getMaxLevel(bom,ref imaxLevel);
      
                for (int i=1; i <= imaxLevel; i++){
                    currBomContainer.Clear();
                    bom.getFromLevel(bom,i,currBomContainer);
                    
                    for (int j=0; j < currBomContainer.Count; j++){
                        bomViewChild = (BomObjectivesView) currBomContainer[j];
                        bomViewChild.DateObjective = dateRequired; //date

                        Inventory inventory = getCoreFactory().readInventory(bomViewChild.Prod,inventoryObjectiveHdr.Plant); //inventory
                        bomViewChild.Qoh = inventory!= null ? inventory.getTotalInventory(bomViewChild.Seq) : 0;

                        bomViewChild.QtyHotList = getHotListQtyForWeek(bomViewChild.Prod, bomViewChild.Seq,dateRequired); //qty hotlist
                        sumBomContainer.Add(bomViewChild);
                    }
                }
            }
        }

        setDataContextListView(bomListView,sumBomContainer);
                      
    }catch (Exception ex){
        MessageBox.Show("generateHotListBom Exception: " + ex.Message);
    } 
    return hotListSumContainer;
}

public
void partDtlDateObjectiveDatePickerLostFocus(DatePicker datePicker){
  try{
        InventoryObjectivePartDtl inventoryObjectivePartDtl = null;
        if (datePicker != null)
            inventoryObjectivePartDtl  = (InventoryObjectivePartDtl)datePicker.DataContext;

        recalculateInventoryObjectivesDtl(inventoryObjectivePartDtl);
        
    }catch (Exception ex){
        MessageBox.Show("partDtlDateObjectiveDatePickerLostFocus Exception: " + ex.Message);
    } 
}

public
void recalculateInventoryObjectivesDtl(InventoryObjectivePartDtl inventoryObjectivePartDtl){
  try{        
        InventoryObjectivePart inventoryObjectivePart = (InventoryObjectivePart) getSelected(partsListView);
        
        if (inventoryObjectivePart!=null && inventoryObjectivePart.ObectivesAutomaticCalc.Equals(Constants.STRING_YES) && 
            inventoryObjectivePartDtl != null) { 
            inventoryObjectivePartDtl.DateObjective = DateUtil.getNextFridayFromDate(inventoryObjectivePartDtl.DateObjective);

            decimal             dweeklyQty = getHotListQtyForWeek(inventoryObjectivePartDtl.PartShow, inventoryObjectivePartDtl.SeqShow, inventoryObjectivePartDtl.DateObjective);    
            //weeklyqty /5 days X days on hand
            inventoryObjectivePartDtl.Qty = (dweeklyQty / Constants.PRODUCTION_DAYS_PERWEEK) * inventoryObjectivePartDtl.DaysOnHand;            
        }

    }catch (Exception ex){
        MessageBox.Show("recalculateInventoryObjectivesDtl Exception: " + ex.Message);
    } 
}

private
decimal getHotListQtyForWeek(string spart,int iseq,DateTime dateRequired){
    HotListHdr          hotListHdr = getCoreFactory().readLastHotList(this.inventoryObjectiveHdr.Plant);
    HotListContainer    hotListContainer =null;
    HotList             hotList = null;
    decimal             dweeklyQty = 0;
    decimal             dweeklyMonQty =0;
    decimal             dweeklySunQty =0;
    DateTime            weeklyMonday = DateTime.Now;        
    DateTime            weeklySunday = DateTime.Now;      
    
    if (hotListHdr!= null) { 
        hotListContainer = getCoreFactory().readHotListByFilters(hotListHdr!= null ? hotListHdr.Id:0,"","","","",0,spart,iseq,"","",false,true,0);
        if (hotListContainer.Count > 0){ 
            hotList = hotListContainer[0];

            DateUtil.getPriorMondayNextSundayFromDate(dateRequired,out weeklyMonday, out weeklySunday);

            dweeklyMonQty = hotList != null ? hotList.getQtyByDate(hotListHdr.HotlistRunDate,weeklyMonday) : 0;
            dweeklySunQty = hotList != null ? hotList.getQtyByDate(hotListHdr.HotlistRunDate,weeklySunday) : 0;

            dweeklyQty = Math.Abs(dweeklySunQty) - Math.Abs(dweeklyMonQty);
        }
    }
    return dweeklyQty;
}

public 
void automaticObjectivesCalc(ComboBox plantFilterComboBox){
    try {
        string      splant  = getSelectedComboBoxItemString(plantFilterComboBox);     
        if (string.IsNullOrEmpty(splant))                    
            splant = Configuration.DftPlant;
        getCoreFactory().recalcAutomaticObjectives(splant);
        MessageBox.Show("Inventory Objectives Recalculated, Done.");

    }catch (Exception ex){
        MessageBox.Show("automaticObjectivesCalc Exception: " + ex.Message);
    }  
}  

private
Product getProductHash(string spart){
    Product     product = null;
    try{ 
        string      skey    =  !string.IsNullOrEmpty(spart) ?  spart.ToUpper() : "";

        product = (Product)getFromHashTable(hashProducts,skey);
        if (product == null){
            product = getCoreFactory().readProduct(spart);
            if (product!= null)
                hashProducts.Add(skey,product);
    
        }

    }catch (Exception ex){
        MessageBox.Show("getProductHash Exception: " + ex.Message);
    } 
    return product;
}

private
Inventory getInventoryHash(string spart,string splant){
    Inventory inventory = null;
    try{ 
        string      skey    =  !string.IsNullOrEmpty(spart) ?  spart.ToUpper() : "";

        inventory =(Inventory)getFromHashTable(hashInventory, skey);//inventory
        if (inventory == null) {
            inventory =  getCoreFactory().readInventory(spart,splant);
            if (inventory!= null)
                hashInventory.Add(inventory,skey);
        }  

    }catch (Exception ex){
        MessageBox.Show("getInventoryHash Exception: " + ex.Message);
    } 
    return inventory;
}
  

}
}
