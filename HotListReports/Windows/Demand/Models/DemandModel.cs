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
using Nujit.NujitERP.ClassLib.Core.Planned;



namespace HotListReports.Windows.Demand{

class  DemandModel : BaseModel2 { 

private ListView    dtlListView;                
private ListView    dtlDaysListView;
private ListView    dtlDaysAuhorizListView;
private ListView    dtlPlanVsProductionListView;

private DemandH     demandH;
private DemandDViewContainer demandDViewContainer;

private Hashtable   hashPlannedParts;
private DateTime    plannedDateTimeStamp;

private Hashtable   hashPrHistSum;
private DateTime    prHistDateTimeChecked;

private Hashtable   hashPackSlipByDate;
private PackSlip    packSlipMaxId;

private Object      objSelected1;
private Object      objSelected2;
private Object      objSelected3;
private Object      objSelected4;

public DemandModel(Window window, ListView dtlListView, ListView dtlDaysListView, ListView dtlDaysAuhorizListView, ListView dtlPlanVsProductionListView) : base(window){    

    this.dtlListView = dtlListView;
    this.dtlDaysListView = dtlDaysListView;
    this.dtlDaysAuhorizListView = dtlDaysAuhorizListView;
    this.dtlPlanVsProductionListView = dtlPlanVsProductionListView;

    this.demandH = null;
    this.demandDViewContainer = getCoreFactory().createDemandDViewContainer();    

    hashPlannedParts = new Hashtable();
    plannedDateTimeStamp = DateUtil.MinValue;

    hashPrHistSum  = new Hashtable();
    prHistDateTimeChecked = DateUtil.MinValue;

    hashPackSlipByDate = new Hashtable();
    packSlipMaxId=null; 

    objSelected1= objSelected2= objSelected3= objSelected4=null;
}

public
DemandH DemandH {
	get { return demandH; }
	set { if (this.demandH != value){
			this.demandH = value;	
		}
	}
}

public
DemandDViewContainer DemandDViewContainer {
	get { return demandDViewContainer; }
	set {
		this.demandDViewContainer = value;			
	}
}

public
Object ObjSelected1 {
	get { return objSelected1; }
	set { if (this.objSelected1 != value){
			this.objSelected1 = value;	
		}
	}
}

public
Object ObjSelected2 {
	get { return objSelected2; }
	set { if (this.objSelected2 != value){
			this.objSelected2 = value;	
		}
	}
}

public
Object ObjSelected3 {
	get { return objSelected3; }
	set { if (this.objSelected3 != value){
			this.objSelected3 = value;	
		}
	}
}

public
Object ObjSelected4 {
	get { return objSelected4; }
	set { if (this.objSelected4 != value){
			this.objSelected4 = value;	
		}
	}
}

public
void loadSearchByCombo(ComboBox searchByComboBox,bool buseTrlpKey){
    loadCombo(searchByComboBox,"Id");     
    if (buseTrlpKey)
        loadCombo(searchByComboBox,"TrlpKey");       
}
          
public
void loadStatusCombo(ComboBox stsComboBox) {
    try{
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Nujit.NujitERP.ClassLib.Common.Constants.STATUS_ACTIVE, Nujit.NujitERP.ClassLib.Common.Constants.STATUS_ACTIVE));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Nujit.NujitERP.ClassLib.Common.Constants.STATUS_TRANSFORM, Nujit.NujitERP.ClassLib.Common.Constants.STATUS_TRANSFORM));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Nujit.NujitERP.ClassLib.Common.Constants.STATUS_HOTLIST_CREATED, Nujit.NujitERP.ClassLib.Common.Constants.STATUS_HOTLIST_CREATED));
                       
        setDataContextCombo(stsComboBox,list);
        
    } catch (Exception ex) {       
         MessageBox.Show("loadStatusCombo Exception: " + ex.Message);     
    }
}

public
void loadTimeCodeCombo(ComboBox comboBox) {
    try{
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.TIME_CODE_DAILY,   Constants.TIME_CODE_DAILY));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.TIME_CODE_WEEKLY,  Constants.TIME_CODE_WEEKLY));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.TIME_CODE_MONTHLY, Constants.TIME_CODE_MONTHLY));                       
        setDataContextCombo(comboBox,list);        

    } catch (Exception ex) {       
         MessageBox.Show("loadTimeCodeCombo Exception: " + ex.Message);     
    }
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

        textBlockColumnListView = new TextBlockColumnListView("Date Created", "DateTime", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay, 50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("StaDate", "StaDate", BindingMode.OneWay,65, hdrListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay,65, hdrListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,85, hdrListView);        
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
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,30, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        checkColumnListView = new CheckColumnListView("Discard", "Discard", BindingMode.TwoWay,35, dtlListView);        
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagDiscardClickEvent));
        checkColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(checkColumnListView.process());
                       
        textBlockColumnListView = new TextBlockColumnListView("Source", "Source", BindingMode.OneWay,50, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TPartner", "TPartner", BindingMode.OneWay, 70, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        //resource
        textBlockColumnListView = new TextBlockColumnListView("RelDate", "RelDate", BindingMode.OneWay,65, dtlListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RelNum", "RelNum", BindingMode.OneWay, 70, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,110, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        textBlockColumnListView = new TextBlockColumnListView("Cust Part", "CustPart", BindingMode.OneWay, 100, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TimeC", "TimeCode", BindingMode.OneWay,30, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CurrCum", "CurrCum", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());


        textBlockColumnListView = new TextBlockColumnListView("QtyCum", "QtyCum", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("NetQty", "NetQty", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Ship Date", "SDate", BindingMode.OneWay, 65, dtlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("FaACum", "FaAutCum", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MaACum", "MaAutCum", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Bill To", "BillTo", BindingMode.OneWay, 70, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Ship To", "ShipTo", BindingMode.OneWay, 70, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipLoc", "ShipLoc", BindingMode.OneWay, 70, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipLTim", "ShipLTim", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipLTUn", "ShipLTUn", BindingMode.OneWay,50, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CurShDoc", "CurShDoc", BindingMode.OneWay, 70, dtlListView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("AdjNQty", "AdjNQty", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("TrlpKeyId", "TrlpKeyId", BindingMode.OneWay, 50, dtlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        dtlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailsGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnTransformGrid(ListView transformListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;

        textBlockColumnListView = new TextBlockColumnListView("HdrId", "HdrId", BindingMode.OneWay, 40, transformListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Detail", "Detail", BindingMode.OneWay, 40, transformListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DemandDate", "DemDate", BindingMode.OneWay,65, transformListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay, 60, transformListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        transformListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailsGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnDetailsDatesGridView(ListView listView,bool baddAutorization){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        string                  sday = "";
        DateTime                priorMonday = DateTime.Now;
        DateTime                nextSunday = DateTime.Now;

        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);
                                                 
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Cust Part", "CustPart", BindingMode.OneWay, 100, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Source", "Source", BindingMode.OneWay,50, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Ship To", "ShipTo", BindingMode.OneWay, 70, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShipLoc", "ShipLoc", BindingMode.OneWay, 70, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        if (baddAutorization){
            textBlockColumnListView = new TextBlockColumnListView("FaAutCum", "FaAutCum", BindingMode.OneWay,70, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");     
            gridView.Columns.Add(textBlockColumnListView.process());

            textBlockColumnListView = new TextBlockColumnListView("MaAutCum", "MaAutCum", BindingMode.OneWay,70, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");     
            gridView.Columns.Add(textBlockColumnListView.process());
        }
              
        textBlockColumnListView = new TextBlockColumnListView("Qoh", "Qoh", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PastDue", "PastDue", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        for (int i=0; i < Constants.MAX_HOTLIST_DAYS;i++){
            DateTime dateTimeAux = priorMonday.AddDays(i);
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
        MessageBox.Show("loadColumnsOnDetailsGridView2 Exception: " + ex.Message);        
    }
}

private 
void flagDiscardClickEvent(object sender, RoutedEventArgs e){   
    flagDiscardClickEvent(sender);
}

private 
void flagDiscardClickEvent(object sender){   
    try{        
        if (sender!= null) { 
            CheckBox        checkBox = (CheckBox)sender;
            DemandD         demandD = (DemandD)checkBox.DataContext;    
                       
            if (demandH!= null && demandD != null && getCoreFactory()!= null) {                 
                DemandDViewContainer.Clear();//clear because need to reload all info again
                getCoreFactory().updateDemandHSpecicDtl(demandH,demandD);                                
            } 
        }

    } catch (Exception ex) {
        MessageBox.Show("flagClickEvent Exception: " + ex.Message);        
    }
}

public 
bool demandDump(){
    bool    bresult = false;
    Cursor  cursorBkp = this.cursor;
    try {                
        DemandH     demandH = getDemandOptions();      
        string      smess   = "";                        
        if (demandH!= null){ 
            if (System.Windows.MessageBox.Show( "Do You Wish To Run Demand Dump ,\n" + 
                                                " From Date = " + DateUtil.getDateRepresentation(demandH.StaDate, DateUtil.MMDDYYYY)  +
                                                " To Date = "   + DateUtil.getDateRepresentation(demandH.EndDate, DateUtil.MMDDYYYY) +
                                                "\n For Plant " + demandH.Plant + "?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){

                ProcessStart();
                this.cursor = System.Windows.Input.Cursors.Wait;                                

                DemandH demandHAux = coreFactory.processDemand830862ByDate(demandH.Plant,demandH.StaDate,demandH.EndDate,false,true); //false to to not import items stuff, but true to import inventory

                smess = ProcessEndAndTex(demandHAux.DemandDContainer.Count);       
                this.cursor = cursorBkp;                     

                MessageBox.Show("Total Demand Id " + (int)demandHAux.Id +  ":\n\n" +
                                "\tDemand Dump     :" + smess);
                bresult = true;
            }
        }

    }catch (Exception ex){
       MessageBox.Show("demandDump Exception: " + ex.Message);  
    }finally {
        this.cursor = cursorBkp;    
    }
    return bresult; 
}

private
DemandH getDemandOptions(){
    try {
        DemandH     demandH     = getCoreFactory().createDemandH();
        DateTime    weekAgo     =  DateTime.Now.AddDays(-7);
        DateTime    fromDate    = new DateTime(weekAgo.Year, weekAgo.Month, weekAgo.Day,0,0,0);
        DateTime    threeMonths = DateTime.Now.AddDays(90);
        DateTime    toDate      = new DateTime(threeMonths.Year, threeMonths.Month, threeMonths.Day,23,59,59);
        
        demandH.StaDate = fromDate;
        demandH.EndDate = toDate;        
        demandH.Plant = Configuration.DftPlant;

        DemandOptionsWindow demandOptionsWindow = new DemandOptionsWindow(demandH);
        if ((bool)demandOptionsWindow.ShowDialog()) 
            return demandH;

    }catch (Exception ex){
       MessageBox.Show("getDemandOptions: " + ex.Message);  
    }
    return null;
}

public 
bool transform(ListView hdrListView){
    bool bresult = false;    
    try {                
        DemandH demandHAux = (DemandH)getSelected(hdrListView);     
        if (demandHAux != null){
                    
            DemandH demandH = coreFactory.readDemandH(demandHAux.Id);
            if (demandH != null){

                DemandTransformOptionsWindow demandTransformOptionsWindow = new DemandTransformOptionsWindow(demandH);
                if ((bool)demandTransformOptionsWindow.ShowDialog()) { 

                    cursorWait();
                    DemTransformH   demTransformH  = coreFactory.processDemandTransform(demandTransformOptionsWindow.DemTransformOptions);
                    int             icounterDiscarded = demandH.countProcessTransform(false);                    
                                       
                    cursorNormal();
                    MessageBox.Show("Total Demand:\n\n" +
                                    "\tDemand Dump     :" + demandH.DemandDContainer.Count +  "\n" +
                                    "\tDemand Transform:" + demTransformH.DemTransformDContainer.Count + "\n" +
                                    (icounterDiscarded> 0 ? "\tDemand Discarded By Merge:" + icounterDiscarded : ""));                    
                    bresult = true;
                }

            }else
                MessageBox.Show("Sorry, Can Not Find DemandH With Id : " + (int)demandHAux.Id);            

        }else
            MessageBox.Show("Please, Select Demand Item First.");
         
    } catch (Exception ex) {
        MessageBox.Show("transform Exception: " + ex.Message);        
    }finally {
        cursorNormal();
    }
    return bresult; 
}

public 
bool merge830862(ListView hdrListView){
    bool    bresult = false;
    Cursor  cursorBkp = this.cursor;
    try{        
        this.cursor = System.Windows.Input.Cursors.Wait;
        DemandH demandH = (DemandH)getSelected(hdrListView);

        if (demandH!= null){
            demandH = coreFactory.readDemandH(demandH.Id);

            if (demandH!= null){
                DemandH demandHAux = coreFactory.processDemandMerge830862(demandH);
                if (demandHAux != null) { 
                    DemTransformOptions demTransformOptions = coreFactory.createDemTransformOptions();
                    demTransformOptions.DemandH = demandHAux;
                    coreFactory.processDemandTransform(demTransformOptions);
                }

                this.cursor = cursorBkp;  
                MessageBox.Show("Process Done.");
                bresult = true;
            }
        }

    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }finally {
        this.cursor = cursorBkp;   
    }
    return bresult;
}

public 
bool dumpInventory(){
    bool    bresult = false;
    Cursor  cursorBkp = this.cursor;
    try{        
        this.cursor = System.Windows.Input.Cursors.Wait;

        string[][] b = coreFactory.generateCMSInventory2();
                
        this.cursor = cursorBkp;  
        MessageBox.Show("Process Done.");             
        bresult = true;

    } catch (Exception ex) {        
        MessageBox.Show("dumpInventory Exception: " + ex.Message);  
    }finally {
        this.cursor = cursorBkp;    
    }
    return bresult;
}

public 
bool createHotList(ListView hdrListView){
    bool    bresult = false;
    Cursor  cursorBkp = this.cursor;
    try {                        
        DemandH     demandH = (DemandH)getSelected(hdrListView);
        string      smess   = "";        
                      
        if (demandH!= null){
            if (System.Windows.MessageBox.Show("Do You Wish To Create Hot-List From Demand Id = " + demandH.Id + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                this.cursor = System.Windows.Input.Cursors.Wait;
                this.ProcessStart();

                demandH = coreFactory.readDemandH(demandH.Id);
                if (demandH!= null){
                    if (demandH.Status.Equals(Constants.STATUS_HOTLIST_CREATED))
                        MessageBox.Show("Hot-List Already Created For That Demand.");
                    else { 
                        getCoreFactory().createHotListDemand(demandH,true);
                        getCoreFactory().compareNewHotListVsPriorHotListFillPlannedQtyChange(demandH.Plant);                                                                  
                                
                        smess = ProcessEndAndTex(demandH.DemandDContainer.Count);
                        this.cursor = cursorBkp; 
                        MessageBox.Show("Process Done. " + "\n" + smess);
                        bresult = true; 
                    }
                }
            }
        }else
            MessageBox.Show("Please, Select Item First.");

    } catch (Exception ex) {
       MessageBox.Show("createHotList Exception: " + ex.Message); 
    }finally {
        this.cursor = cursorBkp; 
    }
    return bresult;
}

public 
bool dumpTransCreateHotList(){
    bool    bresult = false;
    Cursor  cursorBkp = this.cursor;
    try {
        DemandH demandH = getDemandOptions();
        if (demandH!=null){
            this.cursor = System.Windows.Input.Cursors.Wait;

            getCoreFactory().createHotListDemand(demandH,true);//DemandH.ID=0 because not dump yet
            getCoreFactory().compareNewHotListVsPriorHotListFillPlannedQtyChange(demandH.Plant);  
        
            this.cursor = cursorBkp;
            MessageBox.Show("Process Done.");                  
            bresult = true; 
        }

    }catch (Exception ex){
       MessageBox.Show("dumpTransCreateHotList Exception: " + ex.Message);  
    }finally {
        this.cursor = cursorBkp;    
    }
    return bresult;
}

public 
void editDtl(DemandH demandH, DemandD demandD){
    try{     
        if (demandH!= null && demandD != null){
            DemandDtlWindow demandDtlWindow = new DemandDtlWindow(demandH, demandD);
            demandDtlWindow.ShowDialog();
        }

    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

public 
void saveDemand(DemandH demandH,bool bshowMsk=true){
    try{                
        if (demandH!= null){
            coreFactory.updateDemandH(demandH);
            if (bshowMsk)
                MessageBox.Show("Demand Saved OK.");            
        }

    } catch (Exception ex) {        
        MessageBox.Show("saveDemand Exception: " + ex.Message);  
    }
}

public
void loadTPartner(ComboBox comboBox,DemandH demandH){
    try{         
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        Hashtable     hashtable = new Hashtable();
                                
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        for (int i=0;i < demandH.DemandDContainer.Count;i++){
            DemandD demandD  = demandH.DemandDContainer[i];
        
            if (!string.IsNullOrEmpty(demandD.TPartner) && !hashtable.Contains(demandD.TPartner)){
                hashtable.Add(demandD.TPartner, demandD.TPartner);
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(demandD.TPartner, demandD.TPartner));
            }
        }

        setDataContextComboSelected(comboBox,list);                  
        
    } catch (Exception ex) {
        MessageBox.Show("loadBillTo Exception: " + ex.Message);        
    }
}

public
void loadBillTo(ComboBox comboBox,DemandH demandH){
    try{         
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        Hashtable     hashtable = new Hashtable();
                                
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        for (int i=0;i < demandH.DemandDContainer.Count;i++){
            DemandD demandD  = demandH.DemandDContainer[i];
        
            if (!string.IsNullOrEmpty(demandD.BillTo) && !hashtable.Contains(demandD.BillTo)){
                hashtable.Add(demandD.BillTo,demandD.BillTo);
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(demandD.BillTo, demandD.BillTo));
            }
        }

        setDataContextComboSelected(comboBox,list);                  
        
    } catch (Exception ex) {
        MessageBox.Show("loadBillTo Exception: " + ex.Message);        
    }
}

public
void loadShipTo(ComboBox comboBox,DemandH demandH){
    try{         
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        Hashtable     hashtable = new Hashtable();
        
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        for (int i=0;i < demandH.DemandDContainer.Count;i++){
            DemandD demandD  = demandH.DemandDContainer[i];
        
            if (!string.IsNullOrEmpty(demandD.ShipTo) && !hashtable.Contains(demandD.ShipTo)){
                hashtable.Add(demandD.ShipTo,demandD.ShipTo);
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(demandD.ShipTo, demandD.ShipTo));
            }
        }
               
        setDataContextComboSelected(comboBox,list);                                      

    } catch (Exception ex) {
        MessageBox.Show("loadShipTo Exception: " + ex.Message);        
    }
}

public
DemandD getDtlSelectedForTransform(DemandH demandH,int itabDtlIndex,string stimeCodeFilterSelected,string sdiscardFilterSelected){
    DemandD         demandD = null;  
    try{               
        DemandDView                 demandDView = null;
        PlanProductionReportView    planProductionReportView = null;
        
        if (demandH!= null) { 
            switch(itabDtlIndex){
                case 0: demandD = (DemandD)getSelected(dtlListView);                        break;
                case 1: demandDView = (DemandDView)getSelected(dtlDaysListView);            break;
                case 2: demandDView = (DemandDView)getSelected(dtlDaysAuhorizListView);     break;
                case 3: planProductionReportView = (PlanProductionReportView)getSelected(dtlPlanVsProductionListView);break;
            }
             
            if (demandDView!= null){ //search for some detail record with billto/shipto/part
                DemandDContainer demandDContainer = demandH.DemandDContainer.getByFilters(demandDView.Source,stimeCodeFilterSelected, sdiscardFilterSelected,"",demandDView.BillTo, demandDView.ShipTo, demandDView.Part,0,Constants.STRING_YES, true);
                if (demandDContainer.Count > 0)
                    demandD = demandDContainer[0];
            }

            if (planProductionReportView != null){ //search for some detail record with billto/shipto/part
                DemandDContainer demandDContainer = demandH.DemandDContainer.getByFilters("",stimeCodeFilterSelected,sdiscardFilterSelected,"",planProductionReportView.BillTo, planProductionReportView.ShipTo, planProductionReportView.Part,0,Constants.STRING_YES,true);
                if (demandDContainer.Count > 0)
                    demandD = demandDContainer[0];
            }
        }    

    } catch (Exception ex) {
       MessageBox.Show("getDtlSelectedForTransform Exception: " + ex.Message); 
    }
    return demandD;
}

public
void rewritePlannedVsProductionListViewColumns(ListView listView){
    try {         
        createListViewColumns(listView, Constants.MAX_HOTLIST_DAYS + 2);
        GridView                view = (GridView)listView.View;
    
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
        FrameworkElementFactory frameworkElementFactoryTextBox=null;
        ListViewCol             listViewCol = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.FontSizeProperty, dfonSize));
        Setter          textAlignSetter = new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
        cell.Setters.Add(textAlignSetter);
            
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);

        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        
            listViewCol = new ListViewCol();
            sbindPanel = "";
            if (i > 1) { 
                iday = (i-2);

                fontWeight = FontWeights.Bold;
                dcornerRadius = 0;
                sweek       = "Week";
                sbindPanel  = "Day" + (iday+1).ToString("000");                        

                listViewCol.addTextBlock("Planned",     Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);//Honeydew
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                listViewCol.addTextBlock("Production", Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                listViewCol.addTextBlock("Daily862",     Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                listViewCol.addTextBlock("Weekly830",   Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                listViewCol.addTextBlock("Shipment",    Constants.WIDTH_HOTLIST_CELL,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.WhiteSmoke);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");                                    
            }
            
            column.HeaderContainerStyle = cell;        
            column.Width = dwith+10;
                
            switch (i){
                case 0:                                    
                    column.Header = space + "Part  / CustPart / ShipTo" + "\n" + space + "MaAutCum / FaAutCum";                
                    column.Width = 200;
                    listViewCol.addTextBlock("Part",    180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("CustPart",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("ShipTo",  180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);  
                    listViewCol.addTextBlock("MaAutCum",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);                                                          
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                    listViewCol.addTextBlock("FaAutCum", 180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);                                                          
                    listViewCol.setConverter( new DecimalToStringConverterNew(), "int");
                    break;
                case 1:
                    column.Header = space + "Description";
                    sbindPanel = "CellTitles";                
                    column.Width = 90;
                    listViewCol.addTextBlock("Title1",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title3",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title4",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title5",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    break;

                default:
                    DateTime    dateTimeAux = priorMonday.AddDays(iday);
                    string      sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
                    string      sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux).Replace("Week0",CapacityView.TITLE_WEEK0);            
                    string      sday = "Day0"   + (iday+1).ToString("00");

                    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);
                    column.Header = space + sweekTitle + "\n" + space + sdate;
                    break;                            
            }                  
            column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);                                             
        }    

    } catch (Exception ex) {
        MessageBox.Show("rewritePlannedVsProductionListViewColumns Exception: " + ex.Message);        
    }
}

public
void loadPlanVsProduction(DemandH demandH,DemandDViewContainer demandDViewContainerIn,bool includeProduction){        
    DemandDViewContainer        demandDViewContainer = getCoreFactory().createDemandDViewContainer();
    DemandDViewContainer        demandDViewContainer830=null;
    DemandDViewContainer        demandDViewContainer862=null;
    DateTime                    priorMonday     = DateTime.Now;
    DateTime                    priorMondayAux  = DateTime.Now;
    DateTime                    nextSunday      = DateTime.Now;
    DateTime                    currDate        = DateTime.Now;    
    DateTime                    datePastDue     = DateTime.Now; 
    PlannedHdr                  plannedHdr = getCoreFactory().createPlannedHdr(); //used just to get planned qty, but based on hashPlannedParts
    PlanProductionReportView    planProductionReportView = null;
    CellPlanProduction          cellPlanProduction = null;
    ArrayList                   list = new ArrayList();        
    string                      skey="";
    PackSlipContainer           packSlipContainer = null;
    PackSlipDtlContainer        packSlipDtlContainer = null;    
    PackSlip                    packSlipMaxIdNew = null;
    Hashtable                   hashDemandUsed = new Hashtable();

    priorMonday = DateTime.Now;
    DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
    
    //read planned parts quickly mode                                
    getCoreFactory().readPlannedPartsHash(demandH.Plant, ref plannedDateTimeStamp,ref hashPlannedParts);
    
    if (includeProduction)//production history
        getProductionPrHistSum(ref hashPrHistSum,ref prHistDateTimeChecked,"",-1, demandH.Plant,priorMonday, priorMonday.AddDays(Constants.MAX_HOTLIST_DAYS));
    
    //shipments, first we read last Packslip Id created , just to verify if any change
    packSlipContainer = getCoreFactory().readPackSlipByFilters("", DateUtil.MinValue, DateUtil.MinValue,true,1);
    if (packSlipContainer.Count > 0) { 
        packSlipMaxIdNew = packSlipContainer[0];
    }
    if (packSlipMaxId == null  || (packSlipMaxIdNew!= null && packSlipMaxIdNew.Id != packSlipMaxId.Id)) { 
        packSlipMaxId = packSlipMaxIdNew;
        packSlipContainer = getCoreFactory().readPackSlipByFilters("", priorMonday, priorMonday.AddDays(Constants.MAX_HOTLIST_DAYS),false,0);
        hashPackSlipByDate = packSlipContainer.getHashByPostDate();
    }
    
    foreach (DemandDView demandDView in demandDViewContainerIn)
        demandDViewContainer.Add(demandDView);

    if (plannedHdr!= null && demandDViewContainer.Count > 0){
                                
        for (int i=0; i < demandDViewContainer.Count; i++){            
            DemandDView demandDView = (DemandDView)demandDViewContainer[i];       
                                                                                
            priorMonday = DateTime.Now;                                    
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);

            DemandDView demandDView862 = null;
            DemandDView demandDView830 = null;
            //get if 830 weekly
            if (demandDView.Source.Equals(DemandD.SOURCE_830) && demandDView.TimeCode.Equals(Constants.TIME_CODE_WEEKLY)) 
                demandDView830 = demandDView;                
            else { 
                //check if record on forward position                                    
                demandDViewContainer830 = demandDViewContainer.getByFilters(DemandD.SOURCE_830,Constants.TIME_CODE_WEEKLY, demandDView.BillTo,demandDView.ShipTo,demandDView.Part);
                if (demandDViewContainer830.Count > 0) {                 
                    demandDView830 = demandDViewContainer830[0];
                    demandDViewContainer.Remove(demandDView830);                
                }
            }

            //get if 862 daily
            if (demandDView.Source.Equals(DemandD.SOURCE_862) && demandDView.TimeCode.Equals(Constants.TIME_CODE_DAILY))
                demandDView862 = demandDView;            
            else { 
                demandDViewContainer862 = demandDViewContainer.getByFilters(DemandD.SOURCE_862,Constants.TIME_CODE_DAILY, demandDView.BillTo,demandDView.ShipTo,demandDView.Part);
                if (demandDViewContainer862.Count > 0) { 
                    demandDView862 = demandDViewContainer862[0];
                    demandDViewContainer.Remove(demandDView862);                
                }
            }

            planProductionReportView = new PlanProductionReportView();
            planProductionReportView.Part       = demandDView.Part;            
            planProductionReportView.Seq        = demandDView.Seq;
            planProductionReportView.CustPart   = demandDView.CustPart;
            planProductionReportView.BillTo     = demandDView.BillTo;
            planProductionReportView.ShipTo     = demandDView.ShipTo;
            planProductionReportView.MaAutCum   = demandDView.MaAutCum;
            planProductionReportView.FaAutCum   = demandDView.FaAutCum;
            list.Add(planProductionReportView);

            for (int j= 0; j < Constants.MAX_HOTLIST_DAYS; j++){ //loop for every day 

                currDate = priorMonday.AddDays(j);
                cellPlanProduction = planProductionReportView.getCellByIndex(j);
                
                if (DateUtil.sameDate(currDate,nextSunday)) { // check if sunday , so we get planned, which is for week
                    cellPlanProduction.Planned= plannedHdr.getPlannedQtyByPartSeqRangeDateBasedHash(hashPlannedParts, planProductionReportView.Part, planProductionReportView.Seq, priorMondayAux, nextSunday);                     
                }
                DateUtil.getPriorMondayNextSundayFromDate(currDate, out priorMondayAux, out nextSunday);
                                            
                if (demandDView862 != null) //862
                    cellPlanProduction.Daily862 = demandDView862.getQtyByDate(priorMonday,currDate);
                if (demandDView830 != null) //830
                    cellPlanProduction.Weekly830= demandDView830.getQtyByDate(priorMonday,currDate);

                //production
                cellPlanProduction.Production = getProductionPrHistSumFromHash(hashPrHistSum, planProductionReportView.Part, planProductionReportView.Seq, currDate);                

                //shipments
                skey = DateUtil.getDateRepresentation(currDate,DateUtil.MMDDYYYY);
                if (hashPackSlipByDate.Contains(skey)) { 
                    packSlipDtlContainer = (PackSlipDtlContainer)hashPackSlipByDate[skey];
                    cellPlanProduction.Shipment = packSlipDtlContainer.getSumByShipQty(planProductionReportView.Part);
                }
            }
        }                 
    }
    setDataContextListView(dtlPlanVsProductionListView,list);
}

public
bool getProductionPrHistSum(ref Hashtable hashPrHistSum,ref DateTime prHistDateTimeChecked,string spart,int iseq,string sdept,DateTime fromDate,DateTime toDate){
    bool bresult=true;
    try { 
        if (prHistDateTimeChecked == DateUtil.MinValue || DateTime.Now > prHistDateTimeChecked.AddMinutes(Constants.MAX_MINS_CHECK_PR_HIST)) { //check if at least passed 10 mins for last check just to not waste time
            sdept = string.IsNullOrEmpty(sdept) ? "" : sdept+"%";
            hashPrHistSum = getCoreFactory().readPrHistByFiltersHashByPartSeq(spart,iseq,sdept,fromDate,toDate,0);
            prHistDateTimeChecked = DateTime.Now;
        }
    }catch {
        bresult = false;
        MessageBox.Show("Connection Issue When Trying To Get Production History Information.");
    }
    return bresult;
}

public
decimal getProductionPrHistSumFromHash(Hashtable hashPrHistSum, string spart,int iseq,DateTime date){
    decimal dty=0;
    try { 
        string  skey= spart.ToUpper() + Constants.DEFAULT_SEP + iseq.ToString();
        
        if (hashPrHistSum.Contains(skey)){
            PrHistContainer prHistContainer = (PrHistContainer)hashPrHistSum[skey];
            dty = prHistContainer.getSumQtyByDate(date);
        }

    } catch (Exception ex) {
        MessageBox.Show("getProductionPrHistSumFromHash Exception: " + ex.Message);      
    }
    return dty;
}

public
bool exportByDates(ListView listView){
    bool bresult = false;
    try { 
        ExportListView exp = new ExportListView(listView);

        string                  stotal = exp.getHeaderValues();
        string                  sline  ="";
        char                    sep =';';
        DemandDViewContainer    demandDViewContainer = listView.DataContext!= null ? (DemandDViewContainer)listView.DataContext : getCoreFactory().createDemandDViewContainer();
        DemandDView             demandDView=null;
        string                  sfileName = "";
        string                  sfileNameAux = "DemandDates-" + DateUtil.getDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD).Replace('/','-') + ".csv";
        
        for (int i=0; i < demandDViewContainer.Count;i++){
            //Part;Cust Part;Source;Ship To;ShipLoc;Qoh;PastDue;CurrWk02/24;CurrWk02/25;CurrWk02/26;CurrWk02/27;CurrWk02/28;CurrWk02/29;CurrWk03/01;Week103/02;Week103/03;Week103/04;Week103/05;Week103/06;Week103/07;Week103/08;Week203/09;Week203/10;Week203/11;Week203/12;Week203/13;Week203/14;Week203/15;Week303/16;Week303/17;Week303/18;Week303/19;Week303/20;Week303/21;Week303/22;Week403/23;Week403/24;Week403/25;Week403/26;Week403/27;Week403/28;Week403/29;Week503/30;Week503/31;Week504/01;Week504/02;Week504/03;Week504/04;Week504/05;Week604/06;Week604/07;Week604/08;Week604/09;Week604/10;Week604/11;Week604/12;Week704/13;Week704/14;Week704/15;Week704/16;Week704/17;Week704/18;Week704/19;Week804/20;Week804/21;Week804/22;Week804/23;Week804/24;Week804/25;Week804/26;Week904/27;Week904/28;Week904/29;Week904/30;Week905/01;Week905/02;Week905/03;Week1005/04;Week1005/05;Week1005/06;Week1005/07;Week1005/08;Week1005/09;Week1005/10;Week1105/11;Week1105/12;Week1105/13;Week1105/14;Week1105/15;Week1105/16;Week1105/17;Week1205/18;Week1205/19;Week1205/20;Week1205/21;Week1205/22;Week1205/23;\n"
            demandDView= demandDViewContainer[i];
            sline = demandDView.Part        + sep;
            sline+= demandDView.CustPart    + sep;
            sline+= demandDView.Source      + sep;
            sline+= demandDView.ShipTo      + sep;         
            sline+= demandDView.ShipLoc     + sep;         
            sline+= Convert.ToInt32(demandDView.Qoh).ToString()         + sep;
            sline+= Convert.ToInt32(demandDView.PastDue).ToString()     + sep;
            sline+= Convert.ToInt32(demandDView.Day001).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day002).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day003).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day004).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day005).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day006).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day007).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day008).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day009).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day010).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day011).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day012).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day013).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day014).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day015).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day016).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day017).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day018).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day019).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day020).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day021).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day022).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day023).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day024).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day025).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day026).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day027).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day028).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day029).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day030).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day031).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day032).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day033).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day034).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day035).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day036).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day037).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day038).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day039).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day040).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day041).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day042).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day043).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day044).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day045).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day046).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day047).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day048).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day049).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day050).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day051).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day052).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day053).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day054).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day055).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day056).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day057).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day058).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day059).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day060).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day061).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day062).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day063).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day064).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day065).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day066).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day067).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day068).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day069).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day070).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day071).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day072).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day073).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day074).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day075).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day076).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day077).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day078).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day079).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day080).ToString()      + sep;

            sline+= Convert.ToInt32(demandDView.Day081).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day082).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day083).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day084).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day085).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day086).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day087).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day088).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day089).ToString()      + sep;
            sline+= Convert.ToInt32(demandDView.Day090).ToString()      + sep;
            
            stotal+= sline + "\n";
        }   

        sfileName = ExportModel.generateFileName(sfileNameAux, "Exports", false);
        ExportModel.writeFile(sfileName,stotal,true);
                            
    } catch (Exception ex) {
        MessageBox.Show("exportByDates Exception: " + ex.Message);      
    }
    return bresult;
}
       

}
}
