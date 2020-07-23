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
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using System.Text.RegularExpressions;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Demand{
class  CapacityReportModel : HotListModel{

private CapacityViewHdrContainer capacityViewHdrContainer;
private HotListViewHdrContainer hotListViewHdrContainer;
private ListView labourTypePlanningListView;
private Hashtable hashMachines;
private Hashtable hashRoutings;
private Hashtable hashTasks;

public CapacityReportModel(Window window,CapacityHdr capacityHdr,ListView labourTypePlanningListView) : base(window){    
    this.capacityViewHdrContainer = coreFactory.createCapacityViewHdrContainer();
    this.hotListViewHdrContainer = coreFactory.createHotListViewHdrContainer();
    
    this.labourTypePlanningListView = labourTypePlanningListView;        

    this.capacityHdr = capacityHdr;
    this.hashMachines = new Hashtable();
    this.hashRoutings = new Hashtable();
    this.hashTasks = new Hashtable();
    realodWeeksRanges();
}
                
public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Requirment","Part");      
}

public
ArrayList getWeekList(){ 
    ArrayList   arrayList = new ArrayList();
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;
    DateTime    pastDue = DateTime.Now;        
                       
    priorMonday = DateTime.Now;
    for (int j = 0; j < CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);   
        arrayList.Add(priorMonday);
    }
    return arrayList;
}

public
void loadWeekCombo(ComboBox comboBox){       
    try {
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;
        DateTime    pastDue = DateTime.Now;        
        string      saux = "";
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);
        
        pastDue = priorMonday.AddMinutes(10);
        
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        saux = DateUtil.getDateRepresentation(DateUtil.MinValue,DateUtil.MMDDYYYY);        
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All", saux));        
        
        priorMonday = DateTime.Now;
        for (int j = 0; j < CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);   
            saux = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY);                     
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Week"+j,saux));                                       
        }
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadWeekCombo Exception: " + ex.Message);        
    }
}
        
public
void loadTypeCombo(ComboBox typeComboBox){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(CapacityReq.REQUIREMENT_LABOUR, CapacityReq.REQUIREMENT_LABOUR));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(CapacityReq.REQUIREMENT_MACHINE, CapacityReq.REQUIREMENT_MACHINE));                
                               
        typeComboBox.ItemsSource = list;
        if (typeComboBox.Items.Count > 1)
            typeComboBox.SelectedIndex = 1;        

    } catch (Exception ex) {
        MessageBox.Show("loadTypeCombo Exception: " + ex.Message);        
    }
}


public
void loadColumnsOnAvailableLabourListViewGrid(ListView availableLabourListView){
     try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));        
        
        textBlockColumnListView = new TextBlockColumnListView("Shift", "[0]", BindingMode.OneWay,240, availableLabourListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                                                     
        ArrayList   arrayWeekTitles   = CapacityView.getArrayWeeeksBy2Titles(false);
        
        for (int i=0; i < CapacityView.TITLE_COUNTS && i < arrayWeekTitles.Count; i++){
            textBlockColumnListView = new TextBlockColumnListView((string)arrayWeekTitles[i], "[" + (i+1).ToString() + "]", BindingMode.OneWay,50, availableLabourListView);            
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            gridView.Columns.Add(textBlockColumnListView.process());        
        }
                
        availableLabourListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnAvailableLabourListViewGrid Exception: " + ex.Message);        
    }    
}

public
void loadColumnsOnHotListGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("DateTime", "DateTime", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Part", "ProdID", BindingMode.OneWay,180, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;  
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");                              
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;  
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");                              
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Scheduled", "Scheduled", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;          
        gridView.Columns.Add(textBlockColumnListView.process());
                      
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotListGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHeaderGrid(ListView mainListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Department", "[0]", BindingMode.OneWay,80, mainListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "[1]", BindingMode.OneWay,20, mainListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Requirm.", "[2]", BindingMode.OneWay,50, mainListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        loadColumnsOnHeaderGeneric(mainListView,gridView,cell,false);
        mainListView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public 
void loadColumnsOnHeaderGeneric(ListView listView,GridView gridView,Style cell,bool badd){
     try {
        TextBlockColumnListView textBlockColumnListView = null;

        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, "[3]", BindingMode.OneWay,50, listView);            
        textBlockColumnListView.process();
        textBlockColumnListView.setBinding("[3]", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new HoursColorConverter(), "");
        textBlockColumnListView.process();
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(textBlockColumnListView.process());

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++){            
            textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_WEEKNUM + i.ToString(), "["+ (i+4) +"]", BindingMode.OneWay,50, listView);            
            textBlockColumnListView.process();

            textBlockColumnListView.setBinding("[" + (i + 4) + "]", BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new HoursColorConverter(), "");
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.process();
           
            if (badd){ 
                textBlockColumnListView.setBinding("[" + (i + 4) + "]", BindingMode.OneWay, TextBlock.TextProperty);
                textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "");                    
            }
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
            gridView.Columns.Add(textBlockColumnListView.process());
        }

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public 
void loadColumnsOnHeaderGeneric2(ListView listView,GridView gridView,Style cell){
     try {        
        TextBlockColumnListView textBlockColumnListView = null;

        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, "[3]", BindingMode.OneWay,50, listView);                                  
        textBlockColumnListView.setBinding("[3]", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "C");                    
        textBlockColumnListView.process();
        textBlockColumnListView.setBinding("[3]", BindingMode.OneWay, TextBlock.TextProperty);
        textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "V");                    
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.process();        

        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(textBlockColumnListView.process());

        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++,priorMonday = priorMonday.AddDays(7)){         
                                
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
            string sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);                

            string sbinding = "[" + (i + 4) + "]";                   
            textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_WEEKNUM + i.ToString() + "\n" + sdate, sbinding, BindingMode.OneWay,50, listView);                        

            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);
            textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "V");            
            textBlockColumnListView.process();

            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "C");                    
            textBlockColumnListView.process();
           
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            gridView.Columns.Add(textBlockColumnListView.process());
        }

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGeneric2 Exception: " + ex.Message);        
    }

}
public
void loadColumnsOnHeaderView2Grid(ListView view2ListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        
        textBlockColumnListView = new TextBlockColumnListView("Type", "[0]", BindingMode.OneWay,20, view2ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                                                     
        textBlockColumnListView = new TextBlockColumnListView("Department", "[1]", BindingMode.OneWay,80, view2ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Requirm.", "[2]", BindingMode.OneWay,50, view2ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        loadColumnsOnHeaderGeneric(view2ListView, gridView,cell,false);        
        view2ListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderView2Grid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHeaderView3Grid(ListView view3ListView,bool bloadType){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                
        textBlockColumnListView = new TextBlockColumnListView(bloadType ? "Type" :"", "[0]", BindingMode.OneWay, bloadType ? 20 : 0, view3ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                                                     
        textBlockColumnListView = new TextBlockColumnListView("Department", "[1]", BindingMode.OneWay, 80, view3ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Requirm.", "[2]", BindingMode.OneWay,50, view3ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        loadColumnsOnHeaderGeneric2(view3ListView, gridView,cell);        
        view3ListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderView2Grid Exception: " + ex.Message);        
    }
}

public
void loadAvailableLabours(ListView availableLabourListView,string splant){   
    try {
        CapShiftProfileContainer    capShiftProfileContainer = coreFactory.createCapShiftProfileContainer();        
        CapShiftProfileContainer    capShiftProfileSumContainer = coreFactory.createCapShiftProfileContainer();                
        CapShiftProfile             capShiftProfile=null;
        CapShiftProfileView         capShiftProfileView=null;
        CapShiftProfileView         capShiftProfileViewSummary=null;
        DateTime                    dateTime = DateTime.Now;            
        Hashtable                   hashtableByShift = new Hashtable();
        var                         rowList = new List<string>();
        int                         i=0;        
        DateTime                    priorMonday = dateTime;
        DateTime                    nextSunday = dateTime;
       
        availableLabourListView.Items.Clear(); 

        //get last active capacityprofile record for each shift, with Active status
        for (i=1; i <= Constants.MAX_SHIFTS; i++){
            capShiftProfileContainer = coreFactory.readCapShiftProfileByExactlyDatesFilters(splant,i, Constants.STATUS_ACTIVE, dateTime,false, CapacityView.TITLE_COUNTS);
            hashtableByShift.Add(i,capShiftProfileContainer);
        }  
    
        for (i=1; i <= Constants.MAX_SHIFTS; i++){ //loop on every shift
            capShiftProfileContainer = (CapShiftProfileContainer)hashtableByShift[i]; //always exists
            capShiftProfileSumContainer.Clear();

            priorMonday = dateTime;
            nextSunday = dateTime;

            rowList = new List<string>();
            rowList.Add(i.ToString());

            for (int j=0; j < CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){

                DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);                                        
                capShiftProfile = capShiftProfileContainer.getByShiftExactlyDates(i,priorMonday,nextSunday);             
                
                if (capShiftProfile!= null){         
                    capShiftProfileView = coreFactory.cloneCapShiftProfileView(capShiftProfile);                                       
                    rowList.Add(capShiftProfile.TotDirectPeople.ToString() + "/" + capShiftProfile.TotAvailableDirectHours.ToString());
                }else{
                    capShiftProfileView = coreFactory.createCapShiftProfileView();
                    rowList.Add("0/0");                    
                }
                capShiftProfileSumContainer.Add(capShiftProfileView);
            }
            availableLabourListView.Items.Add(rowList);    

            //show summarized
            rowList = new List<string>();
            rowList.Add("");//same shift
            capShiftProfileViewSummary=coreFactory.createCapShiftProfileView();
            for (int j=0; j < capShiftProfileSumContainer.Count;j++){
                capShiftProfileView = (CapShiftProfileView)capShiftProfileSumContainer[j];

                capShiftProfileViewSummary.TotDirectPeopleView+= capShiftProfileView.TotDirectPeople;
                capShiftProfileViewSummary.TotIndirectPeopleView+= capShiftProfileView.TotIndirectPeople;
                capShiftProfileViewSummary.TotAvailableDirectHoursView+= capShiftProfileView.TotAvailableDirectHours;                
                rowList.Add(capShiftProfileViewSummary.TotDirectPeopleView.ToString() + "/" + capShiftProfileViewSummary.TotAvailableDirectHoursView.ToString());    
            }   
            availableLabourListView.Items.Add(rowList);    
        }  

        //total for Shift1/2/3
        loadTotalsShifts(availableLabourListView,hashtableByShift,dateTime, CapacityView.TITLE_COUNTS);        

        if (availableLabourListView.Items.Count > 0)
            availableLabourListView.SelectedIndex=0;
      
    } catch (Exception ex) {
        MessageBox.Show("loadAvailableLabours Exception: " + ex.Message);        
    }     
}

private
void loadTotalsShifts(ListView listView,Hashtable hashtableByShift,DateTime dateTime,int irows){
    CapShiftProfileContainer        capShiftProfileSummaryContainer = coreFactory.createCapShiftProfileContainer();
    CapShiftProfileView             capShiftProfileViewSummary=null;
    CapShiftProfileView             capShiftProfileViewSummaryPrior=null;
    CapShiftProfile                 capShiftProfile=null;
    CapShiftProfileContainer        capShiftProfileContainer=null;    
    DateTime                        priorMonday = dateTime;
    DateTime                        nextSunday = dateTime;
    //total for Shift1/2/3
    var rowList = new List<string>();
    rowList.Add("Total");
        
    priorMonday = nextSunday =dateTime;
    for (int j=0; j <= irows;j++, priorMonday = priorMonday.AddDays(7)){
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);            
        capShiftProfileViewSummary = coreFactory.createCapShiftProfileView();

        for (int i=1; i <= Constants.MAX_SHIFTS; i++){ //loop on every shift
            capShiftProfileContainer = (CapShiftProfileContainer)hashtableByShift[i]; //always exists                               
            capShiftProfile = capShiftProfileContainer.getByShiftExactlyDates(i,priorMonday,nextSunday);  
            if (capShiftProfile!= null){
                capShiftProfileViewSummary.TotDirectPeopleView+= capShiftProfile.TotDirectPeople;
                capShiftProfileViewSummary.TotIndirectPeopleView+= capShiftProfile.TotIndirectPeople;
                capShiftProfileViewSummary.TotAvailableDirectHoursView+= capShiftProfile.TotAvailableDirectHours;
            }
        }  

        rowList.Add(capShiftProfileViewSummary.TotDirectPeopleView.ToString() + "/" + capShiftProfileViewSummary.TotAvailableDirectHoursView.ToString());
        capShiftProfileSummaryContainer.Add(capShiftProfileViewSummary);
    }
    listView.Items.Add(rowList);   

    //show totals summarized
    rowList = new List<string>();
    rowList.Add("SumTot");

    for (int j=0; j < capShiftProfileSummaryContainer.Count;j++){
        capShiftProfileViewSummary = (CapShiftProfileView)capShiftProfileSummaryContainer[j];
        
        if (capShiftProfileViewSummaryPrior != null){
            capShiftProfileViewSummary.TotDirectPeopleView+= capShiftProfileViewSummaryPrior.TotDirectPeopleView;
            capShiftProfileViewSummary.TotIndirectPeopleView+= capShiftProfileViewSummaryPrior.TotIndirectPeopleView;
            capShiftProfileViewSummary.TotAvailableDirectHoursView+= capShiftProfileViewSummaryPrior.TotAvailableDirectHoursView;
        }
          
        rowList.Add(capShiftProfileViewSummary.TotDirectPeopleView.ToString() + "/" + capShiftProfileViewSummary.TotAvailableDirectHoursView.ToString());
        capShiftProfileViewSummaryPrior= capShiftProfileViewSummary;
    }
    listView.Items.Add(rowList);   
}

public
void loadValuesOnGrid(ListView listView,CapacityViewContainer capacityViewContainer){

    int                     i=0;
    int                     j=0;
    string                  splantDept="";
    string                  sweeK="";
    string                  sresource="";
    string                  splantDeptForReport="";
    var                     rowList = new List<string>();
    CapacityViewContainer   capacityViewContainerByDeptPlant = coreFactory.createCapacityViewContainer();
    ArrayList               arrayColumns = new ArrayList();    
    ArrayList               arrayPlantDept = new ArrayList();
    ArrayList               arrayRes = new ArrayList();
    
    // plant/dept Type ReqName WeekColumns    
    Hashtable               hashPlantDept = new Hashtable();        //get differents plant/dept                                
    Hashtable               hashRes = new Hashtable();              //get differents resource/reqname per plant/dept

    listView.Items.Clear(); 
                             
    arrayColumns.Add(CapacityView.TITLE_PASTDUE);//generate columns fro    
    for (i=0; i < CapacityView.TITLE_COUNTS;i++)
        arrayColumns.Add(CapacityView.TITLE_WEEKNUM + i.ToString());

    foreach (CapacityView capacityView in capacityViewContainer) {    
        if (!hashPlantDept.ContainsKey(capacityView.PlantDept)){         
            hashPlantDept.Add(capacityView.PlantDept, capacityView.PlantDept);
            arrayPlantDept.Add(capacityView.PlantDept);            
        }
    }     
    
    for (i=0; i < arrayPlantDept.Count /*&& i < 3*/; i++){

        hashRes.Clear();
        arrayRes.Clear();
        splantDept= (string)arrayPlantDept[i];  //current plant/dept

        /*
        MessageBox.Show("Count Plant/Dept=" + arrayPlantDept.Count + "\n" +
                        "Current Plant/Dept=" + splantDept); */

        //get list of records related to plant/dept
        capacityViewContainerByDeptPlant = capacityViewContainer.getListByPlantDept(splantDept);
        capacityViewContainerByDeptPlant.sortByView1();

        //get differents resource by plant/dept
        for (j=0; j < capacityViewContainerByDeptPlant.Count;j++) {
            CapacityView capacityView = capacityViewContainerByDeptPlant[j];
                       
            if (!hashRes.ContainsKey(capacityView.ReqName)){                
                hashRes.Add(capacityView.ReqName, capacityView);
                arrayRes.Add(capacityView.ReqName);
            }
        }      
        /*
        MessageBox.Show("Count Plant/Dept=" + arrayPlantDept.Count + "\n" +
                        "Current Plant/Dept=" + splantDept + "\n" +
                        "Total Diff.Resources=" + capacityViewContainerByDeptPlant.Count); */
                        
        for (j=0; j < arrayRes.Count /*&& j < 3*/;j++) { //loop on list of differents resource/requirments per plant/dept
            sresource= (string)arrayRes[j]; //current resource/requirment

            rowList = new List<string>();
            if (!splantDeptForReport.ToUpper().Equals(splantDept.ToUpper())){
                rowList.Add(splantDept);
                splantDeptForReport= splantDept;
           } else
                rowList.Add("");

            CapacityView capacityViewAux = (CapacityView)hashRes[sresource]; 
            rowList.Add(capacityViewAux.ReqType);
            rowList.Add(capacityViewAux.ReqName);

            for (int k =0; k < arrayColumns.Count; k++){ 
                sweeK= (string)arrayColumns[k];  //current week/title

                CapacityView capacityView = capacityViewContainerByDeptPlant.getForMatrix(sresource,sweeK);
                if (capacityView !=null){
                    rowList.Add(capacityView.Hours.ToString("0.00"));                            
                }else{
                    rowList.Add("0.00");                                        
                }
            }
            listView.Items.Add(rowList);            
        }                                    
    }
}

public
void loadValuesOnView2(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType,CapacityViewContainer capacityViewContainer){

    int                     i=0;
    int                     j=0;
    string                  splantDept="";
    string                  sweeK="";
    string                  sresource="";
    string                  sreqTypeForReport="";
    string                  splantDeptForReport="";
    var                     rowList = new List<string>();
    CapacityViewContainer   capacityViewContainerByReqType = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerByDeptPlant = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerSummary = coreFactory.createCapacityViewContainer();    
    ArrayList               arrayColumns = new ArrayList();    
    ArrayList               arrayPlantDept = new ArrayList();
    ArrayList               arrayRes = new ArrayList();
    ArrayList               arrayReqType = capacityViewContainer.getDifferentsReqType();
    
    // plant/dept Type ReqName WeekColumns    
    Hashtable               hashPlantDept = new Hashtable();        //get differents plant/dept                                
    Hashtable               hashRes = new Hashtable();              //get differents resource/reqname per plant/dept

    listView.Items.Clear(); 
                             
    arrayColumns.Add(CapacityView.TITLE_PASTDUE);//generate columns for Weeks/Title
    addSummaryCapacityView(capacityViewContainerSummary, CapacityView.TITLE_PASTDUE);    //add to summarize container
    for (i=0; i < CapacityView.TITLE_COUNTS;i++){
        sweeK= CapacityView.TITLE_WEEKNUM + i.ToString();
        arrayColumns.Add(sweeK);

        addSummaryCapacityView(capacityViewContainerSummary, sweeK);    //add to summarize container
    }    
            
    for (int ireqType=0; ireqType < arrayReqType.Count; ireqType++){ //loop by reqtype
        string sreqType = (string)arrayReqType[ireqType];
        splantDeptForReport= "";

        //get list of plan/department per reqtype
        hashPlantDept.Clear();
        arrayPlantDept.Clear();

        capacityViewContainerByReqType = capacityViewContainer.getListByReqType(sreqType);
        arrayPlantDept = capacityViewContainerByReqType.getDifferentsPlantDept(); //get differents plant/depts
                    
        for (i=0; i < arrayPlantDept.Count; i++){

            hashRes.Clear();
            arrayRes.Clear();
            splantDept= (string)arrayPlantDept[i];  //current plant/dept

            /*
            MessageBox.Show("Count Plant/Dept=" + arrayPlantDept.Count + "\n" +
                            "Current Plant/Dept=" + splantDept); */

            //get list of records related to plant/dept
            capacityViewContainerByDeptPlant = capacityViewContainerByReqType.getListByPlantDept(splantDept);
            capacityViewContainerByDeptPlant.sortByView1();

            //get differents resource by plant/dept
            for (j=0; j < capacityViewContainerByDeptPlant.Count;j++) {
                CapacityView capacityView = capacityViewContainerByDeptPlant[j];
                       
                if (!hashRes.ContainsKey(capacityView.ReqName)){                
                    hashRes.Add(capacityView.ReqName, capacityView);
                    arrayRes.Add(capacityView.ReqName);
                }
            }      
            /*
            MessageBox.Show("Count Plant/Dept=" + arrayPlantDept.Count + "\n" +
                            "Current Plant/Dept=" + splantDept + "\n" +
                            "Total Diff.Resources=" + capacityViewContainerByDeptPlant.Count); */
                        
            for (j=0; j < arrayRes.Count /*&& j < 3*/;j++) { //loop on list of differents resource/requirments per plant/dept
                sresource= (string)arrayRes[j]; //current resource/requirment

                rowList = new List<string>();
                        
                if (!sreqTypeForReport.ToUpper().Equals(sreqType.ToUpper())){
                    rowList.Add(sreqType);
                    sreqTypeForReport= sreqType;
               } else
                    rowList.Add("");

                if (!splantDeptForReport.ToUpper().Equals(splantDept.ToUpper())){
                    rowList.Add(splantDept);
                    splantDeptForReport= splantDept;
               } else
                    rowList.Add("");

                CapacityView capacityViewAux = (CapacityView)hashRes[sresource];                 
                rowList.Add(capacityViewAux.ReqName);

                for (int k =0; k < arrayColumns.Count; k++){ 
                    sweeK= (string)arrayColumns[k];  //current week/title

                    CapacityView capacityView = capacityViewContainerByDeptPlant.getForMatrix(sresource,sweeK);
                    if (capacityView !=null){
                        rowList.Add(capacityView.Hours.ToString("0.00"));

                                /*
                        MessageBox.Show("Count Plant/Dept=" + arrayPlantDept.Count + "\n" +
                                        "Current Plant/Dept=" + splantDept + "\n" +
                                        "Resource=" + sresource + "\n" +
                                        "WeeK=" + sweeK + "\n" +
                                        "Found Hours=" + capacityView.Hours.ToString("0.00"));   */                                 
                    }else{
                        rowList.Add("0.00");
                                /*
                        MessageBox.Show("Count Plant/Dept=" + arrayPlantDept.Count + "\n" +
                                        "Current Plant/Dept=" + splantDept + "\n" +
                                        "Resource=" + sresource + "\n" +
                                        "WeeK=" + sweeK + "\n" +
                                        "Not Found Hours");*/
                    }
                }
                listView.Items.Add(rowList);            
            }                                    
        }
        loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSummary,sreqType);
    }

    /*
    //show summarized record by week and requirment type machine
    rowList = new List<string>();
    rowList.Add(CapacityReq.REQUIREMENT_MACHINE);
    rowList.Add("");
    rowList.Add("Total");
    for (i=0; i < capacityViewContainerSummary.Count;i++){
        capacityViewSum= capacityViewContainerSummary[i];  //current week/title
        rowList.Add(capacityViewSum.Hours.ToString("0.00"));        
    }
    listView.Items.Add(rowList); 
    */
}

public
void loadValuesOnViewByReqType(ListView listView,int icapacityHdr,CapacityViewContainer capacityViewContainer, decimal dcumPercent, CapacityView.SORT_TYPE sortType, CapacityView.GENERIC_SHOW_TYPE genericShowType) {

    int                     i = 0;
    int                     j = 0;
    string                  sweeK = "";
    string                  splantDeptResource = "";    
    
    CapacityViewContainer   capacityViewContainerByReqType = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerSum = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerForRequirment = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerAvailCapacity = loadAvailableCapacity();

    ArrayList               arrayColumns = new ArrayList();
    ArrayList               arrayRes = new ArrayList();
    ArrayList               arrayReqType = new ArrayList();
    CapacityView            capacityView=null;    
        
    Hashtable               hashRes = new Hashtable();              //get differents resource/reqname per plant/dept
            
    if (genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL)
        arrayReqType = capacityViewContainer.getDifferentsReqType(); //show differents requirments
    else
        arrayReqType.Add(CapacityReq.REQUIREMENT_MACHINE);          //show only Machine requirment

    this.capacityViewHdrContainer = coreFactory.createCapacityViewHdrContainer();

    loadColumnsOnHeaderView3Grid(listView,true);
    listView.Items.Clear(); 
                             
    arrayColumns.Add(CapacityView.TITLE_PASTDUE);//generate columns for Weeks/Title
    addSummaryCapacityView(capacityViewContainerSum, CapacityView.TITLE_PASTDUE);    
    for (i=0; i < CapacityView.TITLE_COUNTS;i++){
        sweeK= CapacityView.TITLE_WEEKNUM + i.ToString();
        arrayColumns.Add(sweeK);

        addSummaryCapacityView(capacityViewContainerSum,sweeK);    //add to summarize container
    }

    ScheduleHdr scheduleHdr = getCoreFactory().getIfAlreadyScheduled(0, icapacityHdr);
        
    for (int ireqType=0; ireqType < arrayReqType.Count; ireqType++){ //loop by reqtype
        string sreqType = (string)arrayReqType[ireqType];   
               
        capacityViewContainerByReqType = capacityViewContainer.getListByReqType(sreqType);
        if (sortType == CapacityView.SORT_TYPE.REQUIRMENT)
            capacityViewContainerByReqType.sortByRequirment();
        else
            capacityViewContainerByReqType.sortByView1();        

        //get differents plant/dept/resource 
        arrayRes = capacityViewContainerByReqType.getDifferentsPlantDeptResource(out hashRes);
                                            
        for (j=0; j < arrayRes.Count;j++) { //loop on list of differents resource/requirments
            splantDeptResource= (string)arrayRes[j]; //current plant/dept/resource/requirment
            
            CapacityView capacityViewAux = (CapacityView)hashRes[splantDeptResource];                                         
            
            capacityViewContainerForRequirment = coreFactory.createCapacityViewContainer();
            for (int k =0; k < arrayColumns.Count; k++){ 
                sweeK= (string)arrayColumns[k];  //current week/title

                capacityView = capacityViewContainerByReqType.getForMatrixByPlantDeptResoure(splantDeptResource, sweeK);
                if (capacityView !=null){ //found for shift   
                    capacityViewContainerForRequirment.Add(capacityView);                                                                                 
                }else{                    //not found for shift 
                    CapacityView capacityViewZero = coreFactory.cloneCapacityView(capacityViewAux);
                    capacityViewZero.Hours=0;
                    capacityViewZero.Title = sweeK;
                    capacityViewContainerForRequirment.Add(capacityViewZero);
                }
            }
            loadRequirmentInfo(capacityViewAux,capacityViewContainerForRequirment,capacityViewContainerAvailCapacity,scheduleHdr); //load requirment info            
        }                                                    
    }

    //show info processed on screen
    CapacityViewHdrContainer capacityViewHdrAuxContainer = this.capacityViewHdrContainer;
    if (dcumPercent > 0) 
        capacityViewHdrAuxContainer = applyCustomFilters(capacityViewContainer, dcumPercent);

    loadListViewWithContainer(listView,genericShowType,sortType, capacityViewHdrAuxContainer,capacityViewContainer,capacityViewContainerSum);    
}  

private
void addSummaryCapacityView(CapacityViewContainer capacityViewContainerSum, string stitle){
    CapacityView capacityView = coreFactory.createCapacityView();

    capacityView.ShowType = CapacityView.SHOW_TYPE.TYPE_TOTAL;
    capacityView.Title = stitle;    
    capacityView.Machine = "Total";    
    capacityViewContainerSum.Add(capacityView);    
}  

private
void loadTotalsPerReqType(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType, CapacityViewContainer capacityViewContainer,CapacityViewContainer capacityViewContainerSum,string sreqType){
    CapacityView capacityViewSum = null;
    CapacityView capacityViewSumPrior = null;

    //show summarized
    var rowList = new List<string>();    
    rowList.Add("");//reqTypef
    rowList.Add("");//plant/dept
    rowList.Add("Total");//total
    
    for (int j=0; j < capacityViewContainerSum.Count;j++){
        capacityViewSum= capacityViewContainerSum[j];
        CapacityView capacityView   = capacityViewContainer.getSummarizeByWeek(capacityViewSum.Title,sreqType);        
                
        capacityViewSum.ReqType = sreqType;
        capacityViewSum.ShowType = CapacityView.SHOW_TYPE.TYPE_TOTAL;
        if (capacityView!=null){
            capacityViewSum.Hours= capacityView.Hours; //overwrite totals
            capacityViewSum.SDate= capacityView.SDate;            
        }

        rowList.Add(true ? capacityViewSum.getHourShowType() : capacityViewSum.Hours.ToString("0.00"));        
    }   
    listView.Items.Add(rowList);  

    //now show summarized
    rowList = new List<string>();    
    rowList.Add("");//reqTypef
    rowList.Add("");//plant/dept
    rowList.Add("SumTot");//summarized total                 
    
    for (int j=0; j < capacityViewContainerSum.Count;j++){
        capacityViewSum= capacityViewContainerSum[j];
                               
        if (capacityViewSumPrior != null)
            capacityViewSum.Hours+= capacityViewSumPrior.Hours; //summarize totals            
                
        rowList.Add(true ? capacityViewSum.getHourShowType() : capacityViewSum.Hours.ToString("0.00"));        
        capacityViewSumPrior= capacityViewSum;
    }   
    listView.Items.Add(rowList);      
}  
        
public
CapacityViewHdrContainer applyCustomFilters(CapacityViewContainer capacityViewOriginalContainer,decimal dcumPercent){
    CapacityViewHdr             capacityViewHdr = null;
    CapacityView                capacityView= null;
    CapacityViewHdrContainer    capacityViewHdrMatchContainer = coreFactory.createCapacityViewHdrContainer();    
    bool                        brequirmentInvolved=false;

    int                         icountMachines = 0;
           
    //MessageBox.Show("Count Records:" + capacityViewHdrContainer.Count);
           
    for (int i=0; i < this.capacityViewHdrContainer.Count  /*&& icountMachines < 10*/ ; i++){
        capacityViewHdr = capacityViewHdrContainer[i];

        brequirmentInvolved=false;
        if (capacityViewHdr.ReqType.Equals(CapacityReq.REQUIREMENT_MACHINE)){

            icountMachines++;

            CapacityViewContainer capacityViewContainer = capacityViewHdr.getList(CapacityView.SHOW_TYPE.PERCENTAGE);
            for (int j=1; j < capacityViewContainer.Count && !brequirmentInvolved; j++){ //index= 0(PastDue) 1(Week0) 2(Week1)

                capacityView = capacityViewContainer[j];        
                if (capacityView.getCumulativePercentage() >=dcumPercent)
                   brequirmentInvolved=true;                                  
                /*
                MessageBox.Show("Req Name :" + capacityView.ReqName + "\n" +
                                "Week Num :" + (j - 1) + "\n" +
                                "Hours :" + capacityView.Hours.ToString("0.00") + "\n" +
                                "dmaxHoursCalcs :" + dmaxHoursCalcs.ToString("0.00") +
                                "brequirmentInvolved :" + (brequirmentInvolved ? "True" : "False"));*/
            }

            if (brequirmentInvolved)
                capacityViewHdrMatchContainer.Add(capacityViewHdr);
        }

        if (!brequirmentInvolved)
            capacityViewOriginalContainer.removeByRequirment(capacityViewHdr.Plant, capacityViewHdr.Dept, capacityViewHdr.ReqType, capacityViewHdr.ReqName);
    }  

    MessageBox.Show("Finally Count Records:" + capacityViewHdrMatchContainer.Count);

    return capacityViewHdrMatchContainer;
}  

private
void loadListViewWithContainer(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType,
                                CapacityView.SORT_TYPE sortType,CapacityViewHdrContainer capacityViewAuxHdrContainer,
                                CapacityViewContainer capacityViewContainer,CapacityViewContainer capacityViewContainerSum){
    CapacityViewHdr     capacityViewHdr = null;
    string              sreqTypeForReport = "";
    string              splantDeptForReport= "";
    bool                bshowTotals = (genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL);

    listView.Items.Clear(); 
           
    for (int i=0; i < capacityViewAuxHdrContainer.Count;i++){
        capacityViewHdr = capacityViewAuxHdrContainer[i];

        //if reqtype showed , changed we show summarize first
        if (bshowTotals && !string.IsNullOrEmpty(sreqTypeForReport) && !sreqTypeForReport.Equals(capacityViewHdr.ReqType))                    
            loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSum,sreqTypeForReport);

        loadRequirmentCell(listView, genericShowType, ref sreqTypeForReport, ref splantDeptForReport,sortType,capacityViewHdr);
    }  

    //load last summary
    if (bshowTotals && !string.IsNullOrEmpty(sreqTypeForReport))
        loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSum,sreqTypeForReport);
}  

private
void loadRequirmentCell(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType, ref string sreqTypeForReport,ref string splantDeptForReport,
                        CapacityView.SORT_TYPE sortType,CapacityViewHdr capacityViewHdr){
    int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.SCHEDULE_TIME; 
    int             istartShowIndex = genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL ? 0 : (int)CapacityView.SHOW_TYPE.PERCENTAGE;
    var             rowList = new List<string>();  
    CapacityView    capacityView = null;    
    bool            bprocess = true;        

    for (int i= 0; i <= icountInfoByReq && bprocess; i++){
        rowList = new List<string>();    

        if (i >= istartShowIndex){ //on list view only will be showed depending if All or Percentages            
            //req type
            if (sreqTypeForReport.Equals(capacityViewHdr.ReqType))
                rowList.Add("");
            else
                rowList.Add(capacityViewHdr.ReqType);
            sreqTypeForReport= capacityViewHdr.ReqType;

            //plant/dept
            if ( i > istartShowIndex || (splantDeptForReport.Equals(capacityViewHdr.PlantDept) && sortType == CapacityView.SORT_TYPE.DEPT_REQUIRMENT ) )
                rowList.Add("");
            else
                rowList.Add(capacityViewHdr.PlantDept);
            splantDeptForReport= capacityViewHdr.PlantDept;
        
            //reqname
            rowList.Add( i== istartShowIndex ? capacityViewHdr.ReqName : "");        

            listView.Items.Add(rowList);
        }

        CapacityViewContainer capacityViewContainer = capacityViewHdr.getList((CapacityView.SHOW_TYPE)i);

        for (int j=0; j < capacityViewContainer.Count;j++){ //loop on every shift
            capacityView= capacityViewContainer[j];
            rowList.Add(capacityView.getCellValue());
        } 
        
        bprocess = capacityViewHdr.ReqType.Equals(CapacityReq.REQUIREMENT_MACHINE);
    }
}


private
CapacityViewContainer loadAvailableCapacity(){
    CapacityViewContainer   capacityViewContainerAvailCapacity = coreFactory.createCapacityViewContainer();
    CapacityView            capacityView = coreFactory.createCapacityView();

    capacityView.Title = CapacityView.TITLE_PASTDUE;
    capacityViewContainerAvailCapacity.Add(capacityView);
              
    for (int i=0; i < CapacityView.TITLE_COUNTS;i++){
        string sweeK= CapacityView.TITLE_WEEKNUM + i.ToString();

        capacityView = coreFactory.createCapacityView();
        capacityView.Title = sweeK;         
        capacityView.AvailableCapacity = capacityView.getHoursForSimpleCalcs(i);
        capacityViewContainerAvailCapacity.Add(capacityView);

        /*
        MessageBox.Show("Week Num :" + sweeK + "\n" +
                        "Hours :" + capacityView.Hours.ToString("0.00"));*/
    }
    return capacityViewContainerAvailCapacity;
}


private
bool loadRequirmentInfo(CapacityView capacityViewSample,CapacityViewContainer capacityViewContainer,CapacityViewContainer capacityViewContainerAvailCapacity,ScheduleHdr scheduleHdr){
    //int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE;    
    int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.SCHEDULE_TIME;    
    CapacityView    capacityView = null;
    CapacityView    capacityViewAux = null;
    CapacityView    capacityViewCumulativeShift = null;
    CapacityView    capacityViewCumulativeMachineShiftHours = null;
    CapacityView    capacityViewAvailCapacity = null;
    CapacityView    capacityViewPastDue = null;
    CapacityView    capacityViewCumPercent=null;

    CapacityViewHdr capacityViewHdr= coreFactory.createCapacityViewHdr();
    bool            bprocess = true;
    ArrayList       arrayDateTimeWeek = CapacityView.getDateTimeWeekList();
    DateTime        startDate = DateTime.Now;
    DateTime        endDate = DateTime.Now;
            
    capacityViewHdr.copy(capacityViewSample); //copy main requirment fields and then add to list
    this.capacityViewHdrContainer.Add(capacityViewHdr);

    for (int i= 0; i <= icountInfoByReq && bprocess; i++){
          
        for (int j=0; j < capacityViewContainer.Count;j++){ //loop on every shift
            capacityView= capacityViewContainer[j];
            capacityViewAvailCapacity = capacityViewContainerAvailCapacity[j];

            if (j==0)
                capacityViewPastDue = capacityView;//load past due

            switch (i){
                case 0:
                    capacityView.ShowType = CapacityView.SHOW_TYPE.TYPE_NORMAL;      
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityView));
                    break;
                case 1:                    
                    capacityViewAux = coreFactory.cloneCapacityView(capacityView);
                    capacityViewAux.ShowType = CapacityView.SHOW_TYPE.TYPE_MACHSHIFTHOURS;                                            
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewAux));
                    /*
                    MessageBox.Show("Week :" + capacityViewAux.Title + "\n" +
                                    "ShowType :" + (int)capacityViewAux.ShowType + "\n" +
                                    "Hours :" + capacityViewAux.Hours.ToString("0.00") + "\n" +
                                    "DirectHoursToShifts :" + capacityViewAux.DirectHoursToShifts.ToString("0.00") + "\n" +
                                    "value:" + capacityViewAux.getCellValue());                     */
                    break;

                case 2:                    
                    if (capacityViewCumulativeShift == null){
                        capacityViewCumulativeShift=coreFactory.cloneCapacityView(capacityView);
                        capacityViewCumulativeShift.ShowType = CapacityView.SHOW_TYPE.CUMULATIVE_SHIFTS;
                    }else{
                        capacityViewCumulativeShift.Hours+= capacityView.Hours;                            
                    }                     
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewCumulativeShift));
                    break;

                case 3:                            
                    if (capacityViewCumulativeMachineShiftHours == null){
                        capacityViewCumulativeMachineShiftHours=coreFactory.cloneCapacityView(capacityView);
                        capacityViewCumulativeMachineShiftHours.ShowType = CapacityView.SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS;
                    }else{
                        capacityViewCumulativeMachineShiftHours.Hours+= capacityView.Hours;                            
                    }                     
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewCumulativeMachineShiftHours));
                    break;

                case 4:  //percentage
                    capacityViewAux = coreFactory.cloneCapacityView(capacityView);
                    if (j==1 && capacityViewPastDue!=null)  //Week0 = Week0 + PastDue
                        capacityViewAux.Hours+= capacityViewPastDue.Hours;

                    capacityViewAux.ShowType = CapacityView.SHOW_TYPE.PERCENTAGE;  
                    capacityViewAux.AvailableCapacity = capacityViewAvailCapacity.AvailableCapacity;    
                                                                
                    capacityViewHdr.addToList(capacityViewAux);
                    break;

                case 5://cumulative percentage                    
                    if (capacityViewCumPercent == null){
                        capacityViewCumPercent = coreFactory.cloneCapacityView(capacityView);
                        capacityViewCumPercent.ShowType = CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE;
                    }else{
                        capacityViewCumPercent.Hours+= capacityView.Hours;                            
                        capacityViewCumPercent.AvailableCapacity+= capacityViewAvailCapacity.AvailableCapacity;
                    }                                            
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewCumPercent));
                    break;

                case 6://schedule time
                    capacityViewAux = coreFactory.cloneCapacityView(capacityView);
                    capacityViewAux.ShowType = CapacityView.SHOW_TYPE.SCHEDULE_TIME;
                    capacityViewAux.Hours = 0;
                                    
                    if (arrayDateTimeWeek.Count > j && scheduleHdr!= null){
                        startDate = (DateTime) arrayDateTimeWeek[j];                                        
                        if (j ==0){  //past due
                            endDate = startDate;
                            startDate = DateUtil.MinValue;
                        }else
                            DateUtil.getPriorMondayNextSundayFromDate(startDate, out startDate, out endDate);   

                        capacityViewAux.Hours=0;
                        if (capacityViewAux.ReqType.Equals(Constants.TYPE_MACHINE))
                            capacityViewAux.Hours = scheduleHdr.getTotalHrsByMachineDateRange(capacityViewAux.ReqId, startDate,endDate);                                                     
                    }
                    capacityViewHdr.addToList(capacityViewAux);
                    break;
             }  
        } 
        
        bprocess = capacityViewSample.ReqType.Equals(CapacityReq.REQUIREMENT_MACHINE);
    }
    return true;
}

public
void createSchedule(int icapacityHdr,ListView listView,DateTime startDate,DateTime endDate){
    ArrayList           arraySelected = getSelecteds(listView);
    int                 i=0;
    var                 rowList =new List<string>();
    MachineContainer    machineContainer = getCoreFactory().createMachineContainer();
    Machine             machine = null;

            
    for (i=0;i < arraySelected.Count;i++){
        rowList = (List<string>)arraySelected[i]; 
        machine = getMachineBasedRowList(rowList);

        if (machine != null && machineContainer.getByKey(machine.Plt, machine.Dept, machine.Mach) == null)
            machineContainer.Add(machine);
    }
    
    if (machineContainer.Count > 0){              

        ScheduleHdr scheduleHdr = getCoreFactory().processScheduleByCapacityReportParts(icapacityHdr, "","","",CapacityReq.REQUIREMENT_MACHINE, machineContainer, startDate,endDate, CapacityView.SORT_TYPE.DEPT_REQUIRMENT);
        if (scheduleHdr!= null){
            MessageBox.Show("Schedule Properly Processed, Id :" + scheduleHdr.Id.ToString());           
        }
    }

}

public
bool createSchedule(int icapacityHdr,MachineContainer machineContainer,DateTime startDate,DateTime endDate){        
    bool                bresult=false;
    MachineContainer    machineContainerAux  = getCoreFactory().createMachineContainer();      

    foreach(MachineSel machineSel in machineContainer) {
        if (machineSel.IsChecked)
            machineContainerAux.Add(machineSel);
    }

    if (machineContainerAux.Count > 0){ 
        ScheduleHdr scheduleHdr = getCoreFactory().processScheduleByCapacityReportParts(icapacityHdr, "", "", "", CapacityReq.REQUIREMENT_MACHINE, 
                                                    machineContainerAux, startDate, endDate, CapacityView.SORT_TYPE.DEPT_REQUIRMENT);
        if (scheduleHdr!= null){
            bresult=true;
            MessageBox.Show("Schedule Properly Processed, Id :" + scheduleHdr.Id.ToString());           

            ScheduleHdWindow scheduleHdWindow = new ScheduleHdWindow(scheduleHdr,0,null);
            scheduleHdWindow.ShowDialog();
        }                
    }else                               
         MessageBox.Show("There Are Not Machine/s Selected.");
        
    return bresult;
}



public
bool createSchedule(int icapacityHdr,HotListViewContainer hotListViewContainer,MachineContainer machineContainer,DateTime startDate,DateTime endDate){        
    bool                bresult=false;
    MachineContainer    machineContainerAux  = getCoreFactory().createMachineContainer();      

    foreach(MachineSel machineSel in machineContainer) {
        if (machineSel.IsChecked)
            machineContainerAux.Add(machineSel);
    }

    if (machineContainerAux.Count > 0){ 
        ScheduleHdr scheduleHdr = getCoreFactory().processScheduleByHotListView(icapacityHdr, hotListViewContainer, 
                                                    machineContainerAux, startDate, endDate, CapacityView.SORT_TYPE.DEPT_REQUIRMENT);
        if (scheduleHdr!= null){
            bresult=true;
            MessageBox.Show("Schedule Properly Processed, Id :" + scheduleHdr.Id.ToString());           

            Machine         machineAux = machineContainerAux[machineContainerAux.Count-1];            
            ScheduleHdWindow scheduleHdWindow = new ScheduleHdWindow(scheduleHdr, machineAux.Id, null);
            scheduleHdWindow.ShowDialog();
        }                
    }else                               
         MessageBox.Show("There Are Not Machine/s Selected.");
        
    return bresult;
}
        
private
Machine getMachineBasedRowList(List<string> rowList){
    Machine     machine = null;
    string      stype       = rowList.Count > 0 ? rowList[0] : "";
    string      sdetpMachine= rowList.Count > 1 ? rowList[1] : "";
    string      smachine    = rowList.Count > 2 ? rowList[2] : "";
    string[]    items       = sdetpMachine.Split('\\'); 
    string      splant      = items.Length > 0 ? items[0] : "";
    string      sdept       = items.Length > 1 ? items[1] : "";

    if (!string.IsNullOrEmpty(splant) && !string.IsNullOrEmpty(sdept) && !string.IsNullOrEmpty(smachine))                    
        machine = getCoreFactory().readMachine(splant,sdept,smachine);

    return machine;
}

public
MachineContainer getMachineList(ListView listView){    
    MachineContainer    machineContainer = getCoreFactory().createMachineContainer();
    int                 i=0;
    var                 rowList =new List<string>();    
    Machine             machine = null;
    string              stype  = "";        
                
    for (i=0;i < listView.Items.Count;i++){
        rowList = (List<string>)listView.Items[i]; 
        stype  = rowList.Count > 0 ? rowList[0] : "";

        if (stype.Equals(CapacityReq.REQUIREMENT_MACHINE)){
            machine = getMachineBasedRowList(rowList);
            if (machine != null && machineContainer.getByKey(machine.Plt, machine.Dept, machine.Mach) == null)
                machineContainer.Add(machine);            
            
        }
    }

    return machineContainer;
}

public
MachineContainer getMachineList(CapacityViewContainer capacityViewContainer){    
    MachineContainer    machineContainer = getCoreFactory().createMachineContainer();
    Hashtable           hashRes = new Hashtable();
    ArrayList           arrayRes = capacityViewContainer.getDifferentsPlantDeptResource(out hashRes);    
    Machine             machine = null;    
                                           
    for (int j=0; j < arrayRes.Count;j++) { //loop on list of differents resource/requirments
        string splantDeptResource= (string)arrayRes[j]; //current plant/dept/resource/requirment
            
        CapacityView capacityView = (CapacityView)hashRes[splantDeptResource];                                         
        
        if (!string.IsNullOrEmpty(capacityView.Machine) && machineContainer.getByKey(capacityView.Plant, capacityView.Dept, capacityView.Machine) == null){
            machine = getCoreFactory().readMachine(capacityView.Plant, capacityView.Dept, capacityView.Machine);
            if (machine != null)
                machineContainer.Add(machine);   
        }  
    }                  
                    
    return machineContainer;
}
 
public
MachineContainer getMachineList(HotListViewContainer hotListViewContainer){            
    MachineContainer machineContainer = getCoreFactory().createMachineContainer();

    try{       
        ArrayList               arrayRes = new ArrayList();                   
        Hashtable               hashRes = new Hashtable();
        Machine                 machine=null;
            
        arrayRes = hotListViewContainer.getDifferentsPlantDeptResource(out hashRes);

        foreach (DictionaryEntry pair in hashRes){
            HotListView hotListView = (HotListView) pair.Value;

            if (!string.IsNullOrEmpty(hotListView.Mach)){
                machine = getCoreFactory().readMachine(hotListView.Plant, hotListView.Dept, hotListView.Mach);
                if (machine!=null)
                    machineContainer.Add(machine);
                else{
                    MachineContainer machineContainerAux = getCoreFactory().readMachinesByFilters(hotListView.Mach,"", hotListView.Plant, hotListView.Dept,"",true,1);        
                    if (machineContainerAux.Count > 0)
                        machineContainer.Add(machineContainerAux[0]);
                }                    
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("createMachineContainerBasedHotListView Exception: " + ex.Message);        
    }
    return machineContainer;
}

public 
void createScheduleHotList(ListView listView,string splant){            
    try{        
        HotListView     hotListView = (HotListView)getSelected(listView);
        ScheduleHdr     scheduleHdr = null;        
        SchedulePart    schedulePart= null;
        Machine         machine = null;

        if (hotListView!= null){

            if (hotListView.Scheduled.Equals(Constants.STRING_NO)){

                scheduleHdr = getCoreFactory().readScheduleHdrLast(splant);
                if (scheduleHdr==null){
                    scheduleHdr = getCoreFactory().createScheduleHdr();
                    scheduleHdr.Plant = splant;
                }

                machine = getCoreFactory().readMachineForce(hotListView.Plant, hotListView.Dept, hotListView.Mach);
                if (machine!= null){                                          
                    schedulePart = getCoreFactory().createSchedulePart();
                    schedulePart.Part= hotListView.ProdID;
                    schedulePart.Seq = hotListView.Seq;
                    schedulePart.RunStd = hotListView.MachCyc;
                    schedulePart.Qty = hotListView.Qty;
                    schedulePart.HotListScheduleDate = hotListView.DateTime; //set hot list schedule date
                    schedulePart.HotListId = hotListView.HotListIdAut;

                    schedulePart.MachId         = machine.Id;
                    schedulePart.MachShow       = machine.Mach;
                    schedulePart.MachDescShow   = machine.Des1;

                    DateTime startDateTime=DateTime.Now;
                    DateTime endDateTime = DateTime.Now;
                    if (scheduleHdr.getMaxDates(schedulePart.MachId,out startDateTime,out endDateTime))
                        schedulePart.StartDate = startDateTime;
                    else
                        schedulePart.StartDate = DateTime.Now;
                    schedulePart.EndDate = schedulePart.calculateEndDataMachineBuild();

                    ScheduleHdWindow scheduleHdWindow = new ScheduleHdWindow(scheduleHdr, schedulePart.MachId, schedulePart);
                    scheduleHdWindow.ShowDialog();

                }else
                    MessageBox.Show("Sorry, Can Not Read Machine: " + hotListView.Plant+"-" + hotListView.Dept + "-" + hotListView.Mach); 
           }else
                MessageBox.Show("Sorry, Item Selected Already Scheduled."); 
        }else
            MessageBox.Show("Please, Select Item First To Be Scheduled."); 

    } catch (Exception ex) {
       MessageBox.Show("createScheduleHotList Exception: " + ex.Message); 
    }
           
}

public
GroupStyle createMachineGroupStyle(string sbindName){

    #region  Control template Code(to show content)

    ControlTemplate template = new ControlTemplate(typeof(GroupItem));

    //Create border object
    FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));


    border.SetValue(Border.CornerRadiusProperty, new CornerRadius(1));
    border.SetValue(Border.BorderThicknessProperty, new Thickness(1));
    border.SetValue(Border.BorderBrushProperty, new SolidColorBrush(Colors.Silver));
    border.SetValue(Border.PaddingProperty, new Thickness(1));

    //create dockpanel to put inside border.
    FrameworkElementFactory dockPanel = new FrameworkElementFactory(typeof(DockPanel));
    dockPanel.SetValue(DockPanel.LastChildFillProperty, true);

    //stack panel to show group header
    FrameworkElementFactory stackPanel = new FrameworkElementFactory(typeof(StackPanel));
    stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
    stackPanel.SetValue(DockPanel.DockProperty, Dock.Top);

    //Create textBlock to show group header
    FrameworkElementFactory textBlock = new FrameworkElementFactory(typeof(TextBlock));

    textBlock.SetValue(TextBlock.PaddingProperty, new Thickness(2));
    textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
    textBlock.SetValue(TextBlock.TextProperty, new Binding() { Path = new PropertyPath(sbindName) });
    textBlock.SetValue(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
    stackPanel.AppendChild(textBlock);
    template.VisualTree = border;
    //define items presenter
    FrameworkElementFactory itemsPresenter = new FrameworkElementFactory(typeof(ItemsPresenter));
    itemsPresenter.SetValue(ItemsPresenter.MarginProperty, new Thickness(2));

    border.AppendChild(dockPanel);

    dockPanel.AppendChild(stackPanel);
    dockPanel.AppendChild(itemsPresenter);

    template.VisualTree = border;

    #endregion

    #region Set container style for Group

    Style style = new Style(typeof(GroupItem));

    Setter setter = new Setter();
    setter.Property = GroupItem.TemplateProperty;
    setter.Value = template;

    style.Setters.Add(setter);

    GroupStyle groupStyle = new GroupStyle();

    groupStyle.ContainerStyle = style;

    #endregion

    return groupStyle;
}
        
public
void loadColumnsOnMachineListView(ListView listView){
     try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;        
        TextColumnListView      textColumnListView = null;        
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));        
        
        textBlockColumnListView = new TextBlockColumnListView("", "Name", BindingMode.OneWay,300, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
               
                /*
        textColumnListView = new TextColumnListView(CapacityView.TITLE_PASTDUE, "WeekPastDue", BindingMode.TwoWay,50, listView);   
        textColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textColumnListView.getColumn().HeaderContainerStyle = cell;                 
        textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                             
        gridView.Columns.Add(textColumnListView.process());
        */
        
        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, "WeekPastDue", BindingMode.OneWay,50, listView);            
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);     
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");                   
        gridView.Columns.Add(textBlockColumnListView.process());
                                                                  
        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++,priorMonday = priorMonday.AddDays(7)){         
                                
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
            string sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);                

            string sbinding = "Week" + i.ToString();
                    
            textBlockColumnListView = new TextBlockColumnListView("Week" + i.ToString() + "\n" + sdate, "Week" + i.ToString(), BindingMode.OneWay,50, listView);            
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;            
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
            gridView.Columns.Add(textBlockColumnListView.process());
            

                    /*
            numericColumnListView = new NumericColumnListView("Week" + i.ToString() + "\n" + sdate, "Week" + i.ToString(), BindingMode.TwoWay, 85, 0, listView);
            numericColumnListView.setProperty(NujitWPFUtilities.NumericTextBoxWPF.IsEnabledProperty, true);
            numericColumnListView.setProperty(NujitWPFUtilities.NumericTextBoxWPF.MinimumProperty, (decimal)0);           
            gridView.Columns.Add(numericColumnListView.process());                                           
            */

    /*
            textColumnListView = new TextColumnListView("Week" + i.ToString() + "\n" + sdate, "Week" + i.ToString(), BindingMode.TwoWay,50, listView);   
            textColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textColumnListView.getColumn().HeaderContainerStyle = cell;                 
            textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                             
            gridView.Columns.Add(textColumnListView.process());
            */
        }
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachineListView Exception: " + ex.Message);        
    }    
}

public
void loadColumnsOnMachineListView2(ListView listView){
     try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;                
         string                 sbinding = "";
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));        
        
        textBlockColumnListView = new TextBlockColumnListView("Description", "Name", BindingMode.OneWay,300, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                      
        sbinding = "WSeekPastDue";
        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, sbinding, BindingMode.OneWay,50, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;            
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);
        textBlockColumnListView.setConverter(new CapacityValueColorConverter2(), "V");            
        textBlockColumnListView.process();

        textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new CapacityValueColorConverter2(), "C");                    
        textBlockColumnListView.process();
        gridView.Columns.Add(textBlockColumnListView.process());
                                                                  
        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++,priorMonday = priorMonday.AddDays(7)){         
                                
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
            string sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);                

            sbinding = "WSeek" + i.ToString();
                    
            textBlockColumnListView = new TextBlockColumnListView("Week" + i.ToString() + "\n" + sdate, sbinding, BindingMode.OneWay,50, listView);            
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;            
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);
            textBlockColumnListView.setConverter(new CapacityValueColorConverter2(), "V");            
            textBlockColumnListView.process();

            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new CapacityValueColorConverter2(), "C");                    
            textBlockColumnListView.process();


            gridView.Columns.Add(textBlockColumnListView.process());                           
        }
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachineListView Exception: " + ex.Message);        
    }    
}

public
void loadColumnsOnMachinePartsListView(ListView listView){
     try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;                
         string                 sbinding = "";
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));        
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");     
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qoh", "Qoh", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");     
        gridView.Columns.Add(textBlockColumnListView.process());
                      
        sbinding = "WeekPastDue";
        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, sbinding, BindingMode.OneWay,50, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;            
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");            
        textBlockColumnListView.process();                        
        gridView.Columns.Add(textBlockColumnListView.process());
                                                                  
        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++,priorMonday = priorMonday.AddDays(7)){         
                                
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
            string sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);                

            sbinding = "Week" + i.ToString();
                    
            textBlockColumnListView = new TextBlockColumnListView("Week" + i.ToString() + "\n" + sdate, sbinding, BindingMode.OneWay,50, listView);            
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;            
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");            
            textBlockColumnListView.process();            
            textBlockColumnListView.process();

            gridView.Columns.Add(textBlockColumnListView.process());                           
        }
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachineListView Exception: " + ex.Message);        
    }    
}

public
Machine getMachineByFilters(string srequirment,out RoutingContainer routingContainer, string splant,string sdept,string spart){   
    routingContainer=  getCoreFactory().createRoutingContainer();
    Machine machine = null;
    try{ 
        MachineContainer    machineContainer = getCoreFactory().readMachinesByFilters(srequirment,"",splant, sdept,"",false,1);    

        if (machineContainer.Count > 0)
            machine = machineContainer[0];        
            
        if (machine!= null){           
            if (!string.IsNullOrEmpty(spart))                     
                routingContainer= getCoreFactory().getBuildByFilters("",spart,-1,machine.Id,true,false);
            if (routingContainer.Count < 1)
                routingContainer= getCoreFactory().getBuildByFilters("","",-1,machine.Id,true,false);
        }

    } catch (Exception ex) {
        MessageBox.Show("getMachineByFilters Exception: " + ex.Message);        
    }  

    return machine;
}




/*////////////////////////////////////////////// LabourPlanning ///////////////////////////////////////////////////////////////*/
public
LabourPlanningReportViewContainer loadLabourTypePlanning(  ListView listView,TabItem tabItem,
                                                        CapacityHdr capacityHdr, string splant,string sdept,string srequirment,string spart, DateTime dateWeek){
    LabourPlanningReportViewContainer       labourPlanningReportViewContainer = getCoreFactory().createLabourPlanningReportViewContainer();
    try{                 
        HotListHdr                          hotListHdr = getCoreFactory().readLastHotList(capacityHdr.Plant);
        scheduleHdr = getCoreFactory().readScheduleHdrLastDateCheck(scheduleHdr,capacityHdr.Plant);
        LabourTypeRequiredContainer         labourTypeRequiredContainer = getCoreFactory().createLabourTypeRequiredContainer();
                                        
        realodWeeksRanges();        
        rewriteLabourTypePlanningListView(listView);

        if (hotListHdr!= null) { 
            loadLabourTypePlaningRequired(labourPlanningReportViewContainer, hotListHdr,splant, sdept, srequirment, spart, dateWeek);
            loadLabourTypePlaningNet(labourPlanningReportViewContainer);
        }

        /*
        if (hotListHdr!= null)
            labourTypeRequiredContainer= getCoreFactory().getHotListLabourType2(hotListHdr.Id, hotListHdr.Plant,splant,sdept,srequirment, 0,spart,-1,true,false,false,false,0);

        HotListContainer hotListContainer = getCoreFactory().getHotListAsStringNew2(0, capacityHdr.Plant,"","","",0,spart,-1,true,false,true,true,10);

        for (int i=0; i < 5;i++){
            LabourPlanningReportView labourPlanningReportView = getCoreFactory().createLabourPlanningReportView();

            labourPlanningReportView.ReqId = i;
            labourPlanningReportView.ReqType = "L";
            labourPlanningReportView.ReqName = "Lab Type " + i.ToString();
            
            createCellPlanningLabType(labourPlanningReportView.WeekCell0,i,1);
            createCellPlanningLabType(labourPlanningReportView.WeekCell1,i,2);
            createCellPlanningLabType(labourPlanningReportView.WeekCell2,i,3);
            createCellPlanningLabType(labourPlanningReportView.WeekCell3,i,4);
            createCellPlanningLabType(labourPlanningReportView.WeekCell4,i,5);
            createCellPlanningLabType(labourPlanningReportView.WeekCell5,i,6);
            createCellPlanningLabType(labourPlanningReportView.WeekCell6,i,7);
            createCellPlanningLabType(labourPlanningReportView.WeekCell7,i,8);
            createCellPlanningLabType(labourPlanningReportView.WeekCell8,i,9);
            createCellPlanningLabType(labourPlanningReportView.WeekCell9,i,10);
            createCellPlanningLabType(labourPlanningReportView.WeekCell10,i,11);
            createCellPlanningLabType(labourPlanningReportView.WeekCell11,i,12);
            createCellPlanningLabType(labourPlanningReportView.WeekCell12,i,13);
            createCellPlanningLabType(labourPlanningReportView.WeekCell13,i,14);

            labourPlanningReportViewContainer.Add(labourPlanningReportView);
        }
        */
        /*        
        if (machine != null) { 
            loadMachinePartsHotList(machineReportViewContainer,machine,capacityHdr,splant, sdept, srequirment, spart, dateWeek);
            loadMachinePartsCapacityPlanned(machineReportViewContainer,machine,capacityHdr,splant, sdept, srequirment, spart, dateWeek);
            loadMachinePartsNet(machineReportViewContainer);
        }
        */

        listView.DataContext = labourPlanningReportViewContainer;
        listView.ItemsSource = labourPlanningReportViewContainer;                  
        //tabItem.DataContext = machine;        
        
    } catch (Exception ex) {
        MessageBox.Show("loadLabourTypePlanning Exception: " + ex.Message);        
    }
    return labourPlanningReportViewContainer;
}

private
CellPlanningLabType createCellPlanningLabType(CellPlanningLabType cellPlanningLabType,int i,int j){    
    cellPlanningLabType.Overtime = (i * 3) + j + 9;
    cellPlanningLabType.Temp = (i * 2);
    cellPlanningLabType.Required = ((i + 3) * 2) * j;
    cellPlanningLabType.Planned = ((i + 7) * 2) * j + 10;
    cellPlanningLabType.Net = ( (i * 2) + 5) * 2 + j + 6;
    cellPlanningLabType.Index = i;

    return  cellPlanningLabType;
}

private
void rewriteLabourTypePlanningListView(ListView listView){
    try { 
        createListViewColumns(listView,16);
        GridView                view = (GridView)listView.View;        
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
                    
        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        
            listViewCol = new ListViewCol();
            sbindPanel = "";
            if (i > 1) { 
                fontWeight = FontWeights.Bold;
                dcornerRadius = 0;
                sweek = i > 2  ? "Week" + (i-2) : "PastDue";
                sbindPanel = i > 2 ? "WeekCell" + (i - 2) : "WeekCellPastDue";
                listViewCol.addTextBox("Required",  false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left,Colors.Black,Colors.Gray);            
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");

                createdEditableTextBoxOnListView(listView,listViewCol,"Planned", dwith,dheight,dfonSize,fontWeight);
                createdEditableTextBoxOnListView(listView,listViewCol,"Temp",    dwith,dheight,dfonSize,fontWeight);
                createdEditableTextBoxOnListView(listView,listViewCol,"Overtime",dwith,dheight,dfonSize,fontWeight);
                                            
                listViewCol.addTextBox("Net",       false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.Gray);                                    
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
            }
            
            column.HeaderContainerStyle = cell;        
            column.Width = dwith+10;
                
            switch (i){
                case 0:                    
                    column.Header = space + "Id" + "\n" + space +"Code" + "\n" + space + "Name";                
                    column.Width = 200;
                    listViewCol.addTextBlock("ReqId"  ,180,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,UIColors.COLOR_SELECT);                    
                    listViewCol.addTextBlock("Labour", 180,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,UIColors.COLOR_SELECT);                
                    listViewCol.addTextBlock("LabName",180,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,UIColors.COLOR_SELECT);                
                    for (int j=0;j < 2;j++)
                        listViewCol.addTextBlock(j.ToString(),180,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,UIColors.COLOR_SELECT);                                    
                    break;
                case 1:
                    column.Header = space + "Desc";
                    sbindPanel = "CellTitles";                
                    column.Width = 75;
                    listViewCol.addTextBlock("Title1",90,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",90,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title3",90,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title4",90,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title5",90,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);     
                    break;
                case 2:
                    column.Header = space + sweek;
                    break;
                case 3:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek0,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 4:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek1,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 5:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek2,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 6:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek3,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 7:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek4,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 8:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek5,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 9:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek6,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 10:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek7,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 11:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek8,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 12:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek9,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 13:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek10,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 14:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek11,DateUtil.MMDDYYYY).Substring(0,5);
                    break;          
                case 15:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek12,DateUtil.MMDDYYYY).Substring(0,5);
                    break;          
                case 16:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek13,DateUtil.MMDDYYYY).Substring(0,5);
                    break;          
            }                  
            column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);                                             
        }    

    } catch (Exception ex) {
        MessageBox.Show("rewriteLabourTypePlanningListView Exception: " + ex.Message);        
    }
}

private
FrameworkElementFactory createdEditableTextBoxOnListView(ListView listView,ListViewCol listViewCol,string sbind,double dwith,double dheight,double dfonSize,FontWeight fontWeight){
    FrameworkElementFactory frameworkElementFactoryTextBox = listViewCol.addTextBox(sbind,true,false,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
    frameworkElementFactoryTextBox.SetValue(TextBox.MaxLengthProperty, Int32.MaxValue.ToString().Length-1);
    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
    frameworkElementFactoryTextBox.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(plannedLabourTypeTextBox_LostFocus));
    frameworkElementFactoryTextBox.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(plannedLabourTypeTextBox_GotFocus));

    return frameworkElementFactoryTextBox;
}


private 
void plannedLabourTypeTextBox_LostFocus(object sender, RoutedEventArgs e){
    plannedLabourTypeTextBox((TextBox)sender);    
}

private 
void plannedLabourTypeTextBox_GotFocus(object sender, RoutedEventArgs e){
    plannedLabourTypeTextBoxGotFocus((TextBox)sender);    
}


private 
bool plannedLabourTypeTextBox(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellPlanningLabType cellPlanningLabType = (CellPlanningLabType)panel.DataContext;
            if (cellPlanningLabType != null) { 
                CapacityPartContainer       capacityPartContainer = cellPlanningLabType.CapacityPartContainer;
                CapacityPart                capacityPart=null;
                CapacityPart                capacityPartOld= null;
                LabourPlanningReportView    machineReportPartView = (LabourPlanningReportView)getSelected(this.labourTypePlanningListView);                            

                        /*
                if (capacityPartContainer.Count > 0){ //there capacity part record, already created
                    capacityPart = capacityPartContainer[0];
                    
                    if (capacityPart.QtyPlanned != cellMachinePart.Planned){//if qty changed we update it
                        capacityPart.QtyPlanned = cellMachinePart.Planned;
                        this.getCoreFactory().updateCapacityPart(capacityPart);
                        bresult=true;
                    }
                    
                    if (bresult) { 
                        //if there is object, we copy info recently changed
                        capacityPartOld= this.capacityHdr.CapacityPartContainer.getByKey(capacityPart.HdrId,capacityPart.Detail);
                        if (capacityPartOld!=null && capacityPartOld.Part.ToUpper().Equals(capacityPart.Part.ToUpper()) && capacityPartOld.Seq == capacityPart.Seq)
                            capacityPartOld.copy(capacityPart);
                    }            
                }else
                     createCapacityPart(machineReportPartView,cellMachinePart);
                */
            }
        }        

    } catch (Exception ex) {
        MessageBox.Show("plannedLabourTypeTextBox Exception: " + ex.Message);        
    }
    return bresult;
}

private 
bool plannedLabourTypeTextBoxGotFocus(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellPlanningLabType cellPlanningLabType = (CellPlanningLabType)panel.DataContext;
            
            if (cellPlanningLabType != null && cellPlanningLabType.Index < this.labourTypePlanningListView.Items.Count) { 
                this.labourTypePlanningListView.SelectedIndex = cellPlanningLabType.Index;
            }
        }        

    } catch (Exception ex) {
        MessageBox.Show("plannedTextBoxGotFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private
void loadLabourTypePlaningRequired(LabourPlanningReportViewContainer labourPlanningReportViewContainer, HotListHdr hotListHdr,string splant, string sdept, string srequirment, string spart, DateTime dateWeek){
    try{
        LabourTypeRequiredContainer labourTypeRequiredContainer  = getCoreFactory().createLabourTypeRequiredContainer();
        LabourTypeRequired          labourTypeRequired = null;
        LabourPlanningReportView    labourPlanningReportView = null;

        if (hotListHdr!= null) { 
            labourTypeRequiredContainer = getCoreFactory().getHotListLabourType2(hashMachines,hashRoutings,hashTasks,scheduleHdr,hotListHdr.Id, hotListHdr.Plant,splant,sdept,srequirment, 0,spart,-1,"","","",true,false,false,false,0);
        
            for (int i=0; i < labourTypeRequiredContainer.Count;i++)  {          
                labourTypeRequired = labourTypeRequiredContainer[i];                
            
                labourPlanningReportView = getCoreFactory().createLabourPlanningReportView();

                labourPlanningReportView.ReqId  = labourTypeRequired.Id;
                labourPlanningReportView.Labour = labourTypeRequired.Code;
                labourPlanningReportView.LabName= labourTypeRequired.LabName;

                labourPlanningReportView.WeekCellPastDue.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dPastDue,dPastDue);
                labourPlanningReportView.WeekCell0.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek0,dEweek0);
                labourPlanningReportView.WeekCell1.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek1,dEweek1);
                labourPlanningReportView.WeekCell2.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek2,dEweek2);

                labourPlanningReportView.WeekCell3.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek3,dEweek3);
                labourPlanningReportView.WeekCell4.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek4,dEweek4);
                labourPlanningReportView.WeekCell5.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek5,dEweek5);
                labourPlanningReportView.WeekCell6.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek6,dEweek6);
                labourPlanningReportView.WeekCell7.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek7,dEweek7);
                labourPlanningReportView.WeekCell8.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek8,dEweek8);
                labourPlanningReportView.WeekCell9.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek9,dEweek9);
                labourPlanningReportView.WeekCell10.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek10,dEweek10);
                labourPlanningReportView.WeekCell11.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek11,dEweek11);
                labourPlanningReportView.WeekCell12.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek12,dEweek12);
                labourPlanningReportView.WeekCell13.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek13,dEweek13);                
                
                labourPlanningReportViewContainer.Add(labourPlanningReportView);
            }
        }


    } catch (Exception ex) {
        MessageBox.Show("loadLabourTypePlaningRequired Exception: " + ex.Message);        
    }
}

private
void loadLabourTypePlaningNet(LabourPlanningReportViewContainer labourPlanningReportViewContainer){
    try{
        LabourPlanningReportView labourPlanningReportView = null;                            
        for (int i=0; i < labourPlanningReportViewContainer.Count;i++) {                
            labourPlanningReportView = (LabourPlanningReportView)labourPlanningReportViewContainer[i];
    
            //Required + Planned, because required is negative on hotlist , no matter Net is calculated on Net get
            labourPlanningReportView.WeekCellPastDue.Net+= labourPlanningReportView.WeekCellPastDue.Required + labourPlanningReportView.WeekCellPastDue.Planned;
            labourPlanningReportView.WeekCellPastDue.StartDate = labourPlanningReportView.WeekCellPastDue.EndDate = dPastDue;
            labourPlanningReportView.WeekCellPastDue.Index = i;

            labourPlanningReportView.WeekCell0.Net+=labourPlanningReportView.WeekCell0.Required + labourPlanningReportView.WeekCell0.Planned;
            labourPlanningReportView.WeekCell0.StartDate   = this.dSweek0;
            labourPlanningReportView.WeekCell0.EndDate     = this.dEweek0;
            labourPlanningReportView.WeekCell0.Index = i;

            labourPlanningReportView.WeekCell1.Net+=labourPlanningReportView.WeekCell1.Required + labourPlanningReportView.WeekCell1.Planned;
            labourPlanningReportView.WeekCell1.StartDate   = this.dSweek1;
            labourPlanningReportView.WeekCell1.EndDate     = this.dEweek1;
            labourPlanningReportView.WeekCell1.Index = i;

            labourPlanningReportView.WeekCell2.Net+=labourPlanningReportView.WeekCell2.Required + labourPlanningReportView.WeekCell2.Planned;
            labourPlanningReportView.WeekCell2.StartDate   = this.dSweek2;
            labourPlanningReportView.WeekCell2.EndDate     = this.dEweek2;
            labourPlanningReportView.WeekCell2.Index = i;

            labourPlanningReportView.WeekCell3.Net+=labourPlanningReportView.WeekCell3.Required + labourPlanningReportView.WeekCell3.Planned;
            labourPlanningReportView.WeekCell3.StartDate   = this.dSweek3;
            labourPlanningReportView.WeekCell3.EndDate     = this.dEweek3;
            labourPlanningReportView.WeekCell3.Index = i;

            labourPlanningReportView.WeekCell4.Net+=labourPlanningReportView.WeekCell4.Required + labourPlanningReportView.WeekCell4.Planned;
            labourPlanningReportView.WeekCell4.StartDate   = this.dSweek4;
            labourPlanningReportView.WeekCell4.EndDate     = this.dEweek4;
            labourPlanningReportView.WeekCell4.Index = i;

            labourPlanningReportView.WeekCell5.Net+=labourPlanningReportView.WeekCell5.Required + labourPlanningReportView.WeekCell5.Planned;
            labourPlanningReportView.WeekCell5.StartDate   = this.dSweek5;
            labourPlanningReportView.WeekCell5.EndDate     = this.dEweek5;
            labourPlanningReportView.WeekCell5.Index = i;

            labourPlanningReportView.WeekCell6.Net+=labourPlanningReportView.WeekCell6.Required + labourPlanningReportView.WeekCell6.Planned;
            labourPlanningReportView.WeekCell6.StartDate   = this.dSweek6;
            labourPlanningReportView.WeekCell6.EndDate     = this.dEweek6;
            labourPlanningReportView.WeekCell6.Index = i;

            labourPlanningReportView.WeekCell7.Net+=labourPlanningReportView.WeekCell7.Required + labourPlanningReportView.WeekCell7.Planned;
            labourPlanningReportView.WeekCell7.StartDate   = this.dSweek7;
            labourPlanningReportView.WeekCell7.EndDate     = this.dEweek7;
            labourPlanningReportView.WeekCell7.Index = i;

            labourPlanningReportView.WeekCell8.Net+=labourPlanningReportView.WeekCell8.Required + labourPlanningReportView.WeekCell8.Planned;
            labourPlanningReportView.WeekCell8.StartDate   = this.dSweek8;
            labourPlanningReportView.WeekCell8.EndDate     = this.dEweek8;
            labourPlanningReportView.WeekCell8.Index = i;

            labourPlanningReportView.WeekCell9.Net+=labourPlanningReportView.WeekCell9.Required + labourPlanningReportView.WeekCell9.Planned;
            labourPlanningReportView.WeekCell9.StartDate   = this.dSweek9;
            labourPlanningReportView.WeekCell9.EndDate     = this.dEweek9;
            labourPlanningReportView.WeekCell9.Index = i;

            labourPlanningReportView.WeekCell10.Net+=labourPlanningReportView.WeekCell10.Required + labourPlanningReportView.WeekCell10.Planned;
            labourPlanningReportView.WeekCell10.StartDate   = this.dSweek10;
            labourPlanningReportView.WeekCell10.EndDate     = this.dEweek10;
            labourPlanningReportView.WeekCell10.Index = i;

            labourPlanningReportView.WeekCell11.Net+=labourPlanningReportView.WeekCell11.Required + labourPlanningReportView.WeekCell11.Planned;
            labourPlanningReportView.WeekCell11.StartDate   = this.dSweek11;
            labourPlanningReportView.WeekCell11.EndDate     = this.dEweek11;
            labourPlanningReportView.WeekCell11.Index = i;

            labourPlanningReportView.WeekCell12.Net+=labourPlanningReportView.WeekCell12.Required + labourPlanningReportView.WeekCell12.Planned;
            labourPlanningReportView.WeekCell12.StartDate   = this.dSweek12;
            labourPlanningReportView.WeekCell12.EndDate     = this.dEweek12;
            labourPlanningReportView.WeekCell12.Index = i;

            labourPlanningReportView.WeekCell13.Net+=labourPlanningReportView.WeekCell13.Required + labourPlanningReportView.WeekCell13.Planned;                          
            labourPlanningReportView.WeekCell13.StartDate   = this.dSweek13;
            labourPlanningReportView.WeekCell13.EndDate     = this.dEweek13;
            labourPlanningReportView.WeekCell13.Index = i;
        }

    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsNet Exception: " + ex.Message);        
    }
}
}
}
