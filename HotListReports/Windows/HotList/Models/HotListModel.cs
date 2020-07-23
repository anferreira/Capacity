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
using Nujit.NujitERP.ClassLib.Core.Planned;
using HotListReports.Windows.Inventories;
using HotListReports.Windows.Demand;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.HotLists{


class HotListModel : BaseModel2{

private Hashtable           hashPlannedParts;
private DateTime            plannedDateTimeStamp;
private HotListContainer    hotListContainerSelsSchedule;
private HotListHdr          hotListHdr;
private TextBox             textBoxLast;
private ScheduleHdr         scheduleHdr;

public HotListModel(Window window) : base(window){    

    hashPlannedParts    = new Hashtable();
    plannedDateTimeStamp= DateUtil.MinValue;
    hotListContainerSelsSchedule = getCoreFactory().createHotListContainer();
    hotListHdr          = null;    
    textBoxLast         = null;
    scheduleHdr         = null;
}

public
HotListHdr HotListHdr{
	get { return hotListHdr; }
	set { if (this.hotListHdr != value){
			this.hotListHdr = value;			
		}
	}
}

public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Machine","Part Desc");
}

public
int getPastDueIndex(DateTime runDate,string splant){
    int index = 0;    
    try {
        bool        bfound=false;        
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;
        DateTime    currentWeek=DateTime.Now;
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out priorMonday, out nextSunday);

        currentWeek = priorMonday; //all day minor than currentweek will be past due        
        for (int i = 0; i< 90 && !bfound; i++){
            DateTime dateTimeAux = runDate.AddDays(i);            
            if (dateTimeAux < currentWeek)
                index=(i+1);
            else
                bfound=true;
        }
    } catch (Exception ex) {
        MessageBox.Show("getPastDueIndex Exception: " + ex.Message);        
    }
    return index;
}

public
GridView loadBaseColumnsOnHotList(ListView listView,bool bfromBom){
    GridView                gridView = new GridView();
    TextBlockColumnListView textBlockColumnListView = null;
    Style                   cell = new Style(typeof(GridViewColumnHeader));
    cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                         
    textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,40, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);    
    gridView.Columns.Add(textBlockColumnListView.process());

    textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,40, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    gridView.Columns.Add(textBlockColumnListView.process());
        
    textBlockColumnListView = new TextBlockColumnListView("Part", "ProdID", BindingMode.OneWay,120, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
    textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));                            
    textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));                            
    gridView.Columns.Add(textBlockColumnListView.process());        
                
    textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    gridView.Columns.Add(textBlockColumnListView.process());        
                
    textBlockColumnListView = new TextBlockColumnListView("MajGrp", "MajorGroup", BindingMode.OneWay,40, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);    
    gridView.Columns.Add(textBlockColumnListView.process());                      

    textBlockColumnListView = new TextBlockColumnListView("AvgDay" + "\n" + "Pull", "VirtKanManDem", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");    
    gridView.Columns.Add(textBlockColumnListView.process());      

    textBlockColumnListView = new TextBlockColumnListView("DayOn" + "\n" + "Hand", "DaysOnHand", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");    
    gridView.Columns.Add(textBlockColumnListView.process());      

    if (bfromBom) { 
        textBlockColumnListView = new TextBlockColumnListView("Typ", "PartType", BindingMode.OneWay,15,listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);                
        gridView.Columns.Add(textBlockColumnListView.process());
    }

    textBlockColumnListView = new TextBlockColumnListView("L", "Level", BindingMode.OneWay,15,listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");    
    gridView.Columns.Add(textBlockColumnListView.process());     
                                                                                    
    textBlockColumnListView = new TextBlockColumnListView("Qoh", "Qoh", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
    gridView.Columns.Add(textBlockColumnListView.process());   

    textBlockColumnListView = new TextBlockColumnListView("Optimum" + "\n" + "RunQty", "OptRunQty", BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");    
    gridView.Columns.Add(textBlockColumnListView.process());
            
    textBlockColumnListView = new TextBlockColumnListView("MatQty", "MatQty", BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
    textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");    
    gridView.Columns.Add(textBlockColumnListView.process());                    
                                                                
    return gridView;
}

public
void loadColumnsOnHotList(ListView listView,int indexPastDue,string splant, int idays){
    try {
        GridView                gridView = loadBaseColumnsOnHotList(listView,false);
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        string                  sday = "";
                                                                                      
        if (indexPastDue == 0)  sday = "PastDue";
        else                    sday = "Day0"   + indexPastDue.ToString("00");


        textBlockColumnListView = new TextBlockColumnListView("PastDue",sday, BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        HotListHdr  hotListHdr = getCoreFactory().readLastHotList(splant);
        DateTime    runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
		
        int idaysAux= idays == 0 ? int.MaxValue : (idays*3);        
        if (idaysAux >0 && idaysAux < 14)        
            idaysAux= 14;

        for (int i= indexPastDue; i < 90 && idaysAux >=0; i++,idaysAux--){
            DateTime dateTimeAux = runDate.AddDays(i);
            string   sdate = DateUtil.getDateRepresentation(dateTimeAux, DateUtil.MMDDYYYY).Substring(0,5);
            string   sweekTitle = CapacityView.getTitleWeeekByDate(dateTimeAux);
            
            sday = "Day0"   + (i+1).ToString("00");
                  
                    /*
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle.Replace("Week0", CapacityView.TITLE_WEEK0) + "\n" + sdate, sday, BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);            
            textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
            textBlockColumnListView.setEvent(TextBlock.GotFocusEvent, new RoutedEventHandler(textBoxGotFocus)); //new MouseEventHandler(mouseEventFocus)); 
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());
            */
            
                    /*
            ButtonColumnListView buttonColumnListView = new ButtonColumnListView(sweekTitle.Replace("Week0", CapacityView.TITLE_WEEK0) + "\n" + sdate, sday, BindingMode.OneWay, Constants.WIDTH_HOTLIST_CELL, listView);
            //buttonColumnListView.setConverter(new DecimalToStringConverter(),"int");
            gridView.Columns.Add(buttonColumnListView.process());  
            */
                         
            TextNumericNewColumnListView textNumericNewColumnListView=
            new TextNumericNewColumnListView(sweekTitle.Replace("Week0", CapacityView.TITLE_WEEK0) + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
            textNumericNewColumnListView.setConverter(new DecimalToStringConverter(),"int");            
            textNumericNewColumnListView.setEvent(TextBox.GotFocusEvent, new RoutedEventHandler(textBoxGotFocus));    
            textNumericNewColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textNumericNewColumnListView.process());  
            
                    /*
            NumericColumnListView numericColumnListView = new NumericColumnListView
            (sweekTitle.Replace("Week0", CapacityView.TITLE_WEEK0) + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL,0,listView);
            numericColumnListView.setProperty(TextBox.IsReadOnlyProperty,true);
            numericColumnListView.setEvent(TextBox.GotFocusEvent, new RoutedEventHandler(textBoxGotFocus)); 
            gridView.Columns.Add(numericColumnListView.process()); */

            if (dateTimeAux.DayOfWeek == DayOfWeek.Sunday){
                textBlockColumnListView = new TextBlockColumnListView(sweekTitle.Replace("Week0",CapacityView.TITLE_WEEK0) + "\n" + "EndProy",sweekTitle, BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
                textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
                textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
                textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
                textBlockColumnListView.getColumn().HeaderContainerStyle = cell;   
                textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
                gridView.Columns.Add(textBlockColumnListView.process()); 
            }
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotListDateOnTopGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHotListWeeklyBom(ListView listView,int indexPastDue,string splant){
    try {
        GridView                gridView = loadBaseColumnsOnHotList(listView,true);
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        string                  sday = "";                  
                                                                                      
        if (indexPastDue == 0)  sday = "PastDue";
        else                    sday = "Day0"   + indexPastDue.ToString("00");

        textBlockColumnListView = new TextBlockColumnListView("PastDue",sday, BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        HotList     hotList = getCoreFactory().createHotList();
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;

        DateTime dPastDue = DateTime.Now;            
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out dPastDue, out nextSunday);        
        dPastDue = nextSunday.AddDays(-7);

        HotListHdr  hotListHdr = getCoreFactory().readLastHotList(splant);
        DateTime    runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
		
        for (int i= 0; i < CapacityView.TITLE_COUNTS; i++){

            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);                                          
            string   sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);            
            string   sweekTitle = CapacityView.getTitleWeeekByDate(priorMonday).Replace("Week0", CapacityView.TITLE_WEEK0);
            priorMonday = priorMonday.AddDays(7);
            
            sday = hotList.getFieldNameByDate(runDate, nextSunday);

            if (!string.IsNullOrEmpty(sday)) { 
                textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
                textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
                textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
                textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
                textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
                gridView.Columns.Add(textBlockColumnListView.process());  
            }
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotListDateOnTopGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHotListWeekly(ListView listView,int indexPastDue,string splant){
    try {
        GridView                gridView = loadBaseColumnsOnHotList(listView,false);
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        string                  sday = "";
                                                                                      
        if (indexPastDue == 0)  sday = "PastDue";
        else                    sday = "Day0"   + indexPastDue.ToString("00");

        textBlockColumnListView = new TextBlockColumnListView("PastDue",sday, BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        HotList     hotList = getCoreFactory().createHotList();
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;

        DateTime dPastDue = DateTime.Now;            
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out dPastDue, out nextSunday);        
        dPastDue = nextSunday.AddDays(-7);

        HotListHdr  hotListHdr = getCoreFactory().readLastHotList(splant);
        DateTime    runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate : DateTime.Now;
		
        for (int i= 0; i < CapacityView.TITLE_COUNTS; i++){

            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);                                          
            string   sdate      = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);            
            string   sweekTitle = CapacityView.getTitleWeeekByDate(priorMonday).Replace("Week0", CapacityView.TITLE_WEEK0); 
            priorMonday = priorMonday.AddDays(7);
            
            sday = hotList.getFieldNameByDate(runDate, nextSunday);

            if (!string.IsNullOrEmpty(sday)) { 
                textBlockColumnListView = new TextBlockColumnListView(sweekTitle + "\n" + sdate,sday,BindingMode.OneWay,Constants.WIDTH_HOTLIST_CELL,listView);
                textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
                textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
                textBlockColumnListView.setConverter(new DecimalToStringConverter(),"int");
                textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
                gridView.Columns.Add(textBlockColumnListView.process());  
            }
        }
   
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHotListDateOnTopGrid Exception: " + ex.Message);        
    }
}

      
public
void adjustHotListContainerBasedPastDue(HotListContainer hotListContainer,DateTime runDate,string splant){    
    int         indexPastDue = getPastDueIndex(runDate,splant);        
    decimal     dqty =0;
    decimal     dsumQty =0;
    DateTime    currentDate = runDate;
    HotList     hotList= null;

    for (int i=0; i < hotListContainer.Count;i++){
        hotList = hotListContainer[i];

        dsumQty = hotList.PastDue;
        for (int j=0; j < indexPastDue && j < 90; j++){        
            currentDate = runDate.AddDays(j);

            dqty = hotList.getQtyByDate(runDate,currentDate);
            dsumQty+= dqty;
            hotList.setQtyByDate(runDate,currentDate,dsumQty);

            if (j > 0)
                hotList.setQtyByDate(runDate,currentDate.AddDays(-1),0); //prior date set 0
        }   
    }
}
 
public
HotListContainer generateHotListBom(ListView listView, HotList hotList,bool bqtyCumulative,bool bqohAffects,string sreportedPoint){    
    HotListContainer    hotListSumContainer = getCoreFactory().createHotListContainer();
    try{ 
        if (hotList!= null){
            Bom                     bom = getCoreFactory().makeBom(hotList.ProdID, hotList.Seq,hotList.Plt);
            BomContainer            sumBomContainer = getCoreFactory().createBomContainer();
            BomContainer            currBomContainer= getCoreFactory().createBomContainer();
            Bom                     bomChild=null;
            HotListHdr              hotListHdr = getCoreFactory().readLastHotList(hotList.Plt);
            HotListContainer        hotListContainer = getCoreFactory().createHotListContainer();
            HotListInvAnalysisView  hotListInvAnalysisView= null;
            ArrayList               arrayFieldList = new ArrayList();

            if (bom!= null && hotListHdr!= null){ 
                int     imaxLevel = 0;
                bom.getMaxLevel(bom,ref imaxLevel);

                //get hot list info from master part
                hotListContainer = getCoreFactory().readHotListByFiltersWeekly2(arrayFieldList,hotListHdr.Id, hotList.Plt, hotList.Plt,"","",0, hotList.ProdID, hotList.Seq, "","",sreportedPoint,0,true, bqtyCumulative, bqohAffects, 1);
                if (hotListContainer.Count > 0)
                    hotListSumContainer.Add(hotListContainer[0]);
                    
                for (int i=1; i <= imaxLevel; i++){
                    currBomContainer.Clear();
                    bom.getFromLevel(bom,i,currBomContainer);
                    sumBomContainer.AddRange(currBomContainer);

                    for (int j=0; hotListHdr!= null && j < currBomContainer.Count; j++){
                        bomChild = (Bom) currBomContainer[j];

                        hotListContainer = getCoreFactory().readHotListByFiltersWeekly2(arrayFieldList,hotListHdr.Id, hotList.Plt, hotList.Plt, "","",0, bomChild.Prod, bomChild.Seq,"","", "",0,true, bqtyCumulative,bqohAffects,1);
                        hotListInvAnalysisView= null;
                        if (hotListContainer.Count > 0)
                            hotListInvAnalysisView= (HotListInvAnalysisView)hotListContainer[0];
                        else{
                            //can not find info on hotlist                                            
                            hotListInvAnalysisView = getCoreFactory().createHotListInvAnalysisView();
                            hotListInvAnalysisView.Plt = hotListHdr.Plant;
                            hotListInvAnalysisView.ProdID = bomChild.Prod;
                            hotListInvAnalysisView.Seq = bomChild.Seq;

                            Inventory inventory = getCoreFactory().readInventory(hotListInvAnalysisView.ProdID, hotListInvAnalysisView.Plt);
                            hotListInvAnalysisView.Qoh = inventory!= null ? inventory.getTotalInventory(hotListInvAnalysisView.Seq) : 0;

                            RoutingContainer routingContainer = getCoreFactory().getBuildByFilters(hotListInvAnalysisView.Plt, hotListInvAnalysisView.ProdID, hotListInvAnalysisView.Seq,0,true,false);
                            if  (routingContainer.Count > 0) {
                                Routing routing = routingContainer[0];
                                hotListInvAnalysisView.Dept = routing.Dept;
                                hotListInvAnalysisView.Mach = routing.Cfg;
                                hotListInvAnalysisView.MachCyc = routing.RunStd;
                            }

                            Product product = getCoreFactory().readProduct(hotListInvAnalysisView.ProdID);
                            if (product != null) { 
                                hotListInvAnalysisView.MajorGroup   =product.MajorGroup;                                
                                hotListInvAnalysisView.VirtKanManDem=product.VirtKanManDem;
                                hotListInvAnalysisView.PartType     =product.PartType;
                                hotListInvAnalysisView.DaysOnHand   =hotListInvAnalysisView.DaysOnHand;                                
                            }                            
                            hotListInvAnalysisView.MatQty =0;
                        }
                        hotListInvAnalysisView.Level=hotListInvAnalysisView.LevelShow = bomChild.Level;
                        hotListSumContainer.Add(hotListInvAnalysisView);
                    }
                }
            }
        }    

    }catch (Exception ex){
        MessageBox.Show("generateHotListBom Exception: " + ex.Message);
    } 
    return hotListSumContainer;
}

public
void adjustPastDueBasedIndexWhenNoCumulative(HotListContainer hotListContainer,DateTime runDate,int indexPastDue){
    DateTime    currentDate = runDate;
    decimal     dqtySummarizePastDue = 0;
    HotList     hotList = null;

    for (int i=0; i < hotListContainer.Count;i++){
        hotList = hotListContainer[i];
        dqtySummarizePastDue = hotList.getQtyByDate(runDate,runDate.AddDays(-1)); //get past due

        for (int j=0; j < indexPastDue && j < 90;j++){
            currentDate = runDate.AddDays(j);
            dqtySummarizePastDue+= hotList.getQtyByDate(runDate,currentDate);
            if ( (j+1) == indexPastDue)
                hotList.setQtyByDate(runDate, currentDate,dqtySummarizePastDue);
        }
 
    }                   
}

public
void addPlannedProcessEndOfWeek(HotListHdr hotListHdr,HotListContainer hotListContainer,string splant,bool bcumulativeQty,bool bshowDaily){    
    getCoreFactory().readPlannedPartsHash(splant,ref plannedDateTimeStamp,ref hashPlannedParts); //read planned parts quickly mode    
    DateTime                priorMonday = DateTime.Now;
    DateTime                nextSunday = DateTime.Now;
    decimal                 dplanned=0,dconsum=0,dtotal=0,dpastDue=0,dstarted=0,dpriorConsum=0;            
    DateTime                datePastDue = DateTime.Now; 
    PlannedHdr              plannedHdr = getCoreFactory().createPlannedHdr(); //used just to get planned qty, but based on hashPlannedParts

    if (plannedHdr!= null && hotListHdr != null){
        
        priorMonday = DateTime.Now;
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
        datePastDue = hotListHdr.HotlistRunDate > priorMonday ? hotListHdr.HotlistRunDate.AddDays(-1) : priorMonday.AddDays(-1);        
               
        for (int i=0; i < hotListContainer.Count; i++){            
            HotList hotList = (HotList)hotListContainer[i];                                                
            priorMonday = DateTime.Now;                        
            
            //consumed past due
            if (bcumulativeQty)
                dstarted = hotList.getQtyByDate(hotListHdr.HotlistRunDate,datePastDue);
            else
                dstarted = hotList.getQtyByRangeDate(hotListHdr.HotlistRunDate,hotListHdr.HotlistRunDate.AddDays(-1),datePastDue);//non cumulative, so get qty from day hotlist run-1 until datePastDue

            dpriorConsum =dstarted; 
            //planned pastdue
            dplanned = plannedHdr.getPlannedQtyByPartSeqRangeDateBasedHash(hashPlannedParts, hotList.ProdID, hotList.Seq,hotListHdr.HotlistRunDate,datePastDue);                     
            dstarted+= dplanned; //remember consum is negative so we summarize against planned
            
            for (int j= 0; j < CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
                DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
                
                if (bcumulativeQty)
                    dconsum = hotList.getQtyByDate(hotListHdr.HotlistRunDate,nextSunday); //cumulative so just get qty for date
                else
                    dconsum = hotList.getQtyByRangeDate(hotListHdr.HotlistRunDate,priorMonday,nextSunday);//non cumulative, so get qty from monday to sunday                 

                dplanned= plannedHdr.getPlannedQtyByPartSeqRangeDateBasedHash(hashPlannedParts, hotList.ProdID, hotList.Seq, priorMonday, nextSunday); 

                dtotal= (dstarted + dplanned) -  (Math.Abs(dconsum)- Math.Abs(dpriorConsum));
            
                dstarted = dtotal;                
                dpriorConsum = bcumulativeQty ? dconsum : 0;//if cumulative need to get prior consum, so we can understand the exact about on next week

                if (hotList is HotListInvAnalysisView)
                   ((HotListInvAnalysisView)hotList).setWeek(j, dtotal);             
                        
                if (!bshowDaily)
                    hotList.setQtyByDate(hotListHdr.HotlistRunDate,nextSunday,dtotal);
            }
        }        
    }
}

public
void fillEndOfWeekWithoutPlanned(HotListHdr hotListHdr,HotListContainer hotListContainer,bool bcumulativeQty){
    try { 
        DateTime                priorMonday = DateTime.Now;
        DateTime                nextSunday = DateTime.Now;
        decimal                 dconsum =0;
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);

        for (int i=0; i < hotListContainer.Count; i++){            
            HotList hotList = (HotList)hotListContainer[i];        
            if (hotList is HotListInvAnalysisView) { 
                   
                priorMonday = DateTime.Now;                        
                for (int j= 0; j < CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
                    DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);

                    if (bcumulativeQty)
                      dconsum = hotList.getQtyByDate(hotListHdr.HotlistRunDate,nextSunday); //cumulative so just get qty for date
                    else
                      dconsum = hotList.getQtyByRangeDate(hotListHdr.HotlistRunDate,priorMonday,nextSunday);//non cumulative, so get qty from monday to sunday                 

                    ((HotListInvAnalysisView)hotList).setWeek(j,dconsum);                                                           
                }
            }
        }

    }catch (Exception ex){
        MessageBox.Show("fillEndOfWeekWithoutPlanned Exception: " + ex.Message);       
    }
}

public
bool readPlannedPartsHash(string splant){
    bool bresult=true;
    try {
        getCoreFactory().readPlannedPartsHash(splant,ref plannedDateTimeStamp,ref hashPlannedParts);

    }catch (Exception ex){
        MessageBox.Show("readPlannedPartsHash Exception: " + ex.Message);
        bresult=false;
    } 
    return bresult;
}
       
public
void adjustHotListSelectTitle(HotListHdr hotListHdr){
    try {
        window.Title = Constants.FUNNEL_TITLE + " - HotList Created : " + (hotListHdr!= null ? DateUtil.getCompleteDateRepresentation(hotListHdr.HotlistRunDate,DateUtil.MMDDYYYY) : "N/A");            
    } catch (Exception ex) {
        MessageBox.Show("adjustHotListSelectTitle Exception: " + ex.Message);        
    } 
}
       
public
void createHotList(){
    try {        
        if (System.Windows.Forms.MessageBox.Show("Do You Want To Create Hot-List ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
            getCoreFactory().createHotListDemand(null,true);
        }
    } catch (Exception ex) {
        MessageBox.Show("createHotList Exception: " + ex.Message);        
    } 
}

public 
void processShMaterial(HotList hotListSelected,HotListContainer hotListContainer){
    try { 
        bool                bprocessAgain       =true;
        int                 index               =0;
        string              spart               = "";
        bool                bsamePart           =true;
        Hashtable           hashParts           = new Hashtable();
                      
        if (hotListSelected!= null) {       
            index   = hotListContainer.IndexOf(hotListSelected);
            
            do {
                spart   = hotListSelected.ProdID;
                addToHashTable(hashParts,spart,spart);
                processShMaterial(hotListSelected, out bprocessAgain);

                if (bprocessAgain){                    
                    bsamePart=true;                    
                    for (; index < hotListContainer.Count && bsamePart; index++){//move until next different part
                        hotListSelected = hotListContainer[index];
                        bsamePart = hashParts.Contains(hotListSelected.ProdID.ToUpper());                                    
                    }                    
                }

            } while (bprocessAgain && index < hotListContainer.Count);                        
            
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("processShMaterial Exception: " + ex.Message);
    } 
}

public
bool processShMaterial(HotList hotListSelected,out bool bprocessAgain){
    bool bresult=false;
    bprocessAgain=false;
    try { 
        
        if (hotListSelected!= null) { 
            hotListHdr = hotListHdr!= null ? hotListHdr : getCoreFactory().readLastHotList(Configuration.DftPlant);        

            HotList             hotListSelectedBkp  = hotListSelected;            
            HotListContainer    hotListContainer    = null;
            HotList             hotList             = null;
            Product             product             = getCoreFactory().readProduct(hotListSelected.ProdID);
            Machine             machine             = null;
            string              spart               ="";
            int                 iseq                =0;

            if (hotListHdr!= null && product!=null) { 

                spart   = hotListSelected.ProdID;
                iseq    = product.SeqLast;
                BomSumContainer matBomSumContainer = getCoreFactory().getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(spart,iseq,hotListHdr.Plant,Constants.STRING_YES,1);

                if (matBomSumContainer.Count > 0) { 
                    hotListContainer = getCoreFactory().readHotListByFilters(hotListHdr.Id,"","","","",0,spart,iseq,"","",false,false,0);

                    if (hotListContainer.Count > 0) { 
                        hotList = hotListContainer[0];
                        HotListDayContainer hotDayContainer = hotList.getQtyDatesNonZero(hotListHdr.HotlistRunDate);

                        if (hotDayContainer.Count > 0) { 
                            HotListDay hotListDay = hotDayContainer.getByDate(DateTime.Now);
                                    /*
                            if (hotListDay == null)
                                hotListDay = hotDayContainer.getBiggerThanDate(DateTime.Now);
                            */  

                            if (hotListDay == null) { 
                                hotListDay = getCoreFactory().createHotListDay();
                                hotListDay.DateTime = DateTime.Now;
                                hotListDay.Qty      =0;
                            }

                            machine  = getCoreFactory().readMachine(hotListHdr.Plant,hotList.Dept,hotList.Mach);

                            SchMaterialAvailWindow schMaterialAvailWindow = new SchMaterialAvailWindow(hotListHdr, hotList.IdAut,hotList.ProdID,hotList.Seq,hotListDay.DateTime, hotListDay.Qty, machine!= null ? machine.Id:0);
                            schMaterialAvailWindow.setMaterials(matBomSumContainer);
                            if ((bool)schMaterialAvailWindow.ShowDialog()) { 
                                bresult=true;                                
                                bprocessAgain = schMaterialAvailWindow.getNextPart();
                            }                            
                        }
                    }else
                        MessageBox.Show("Can Not Find HotList Record For Part :" + spart + " Seq :" + iseq);

                }else
                    MessageBox.Show("Sorry, Part :" + spart + " Seq :" + iseq + " Has Not Bom Associated.");
            }
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("processShMaterial Exception: " + ex.Message);
    } 
    return bresult;  
}

public
void exportToCsv(HotListContainer hotListContainer,ArrayList arrayFieldListWeekly,ComboBox deptComboBox){
    try {                
        string                  sdept     = getSelectedComboBoxItemString(deptComboBox);
        bool                    bsameDept =true;
        string                  sfileName = "";
        string                  sfileNameAux = "";        

        HotListInvAnalysisView hotListInvAnalysisView = null;
        char        sep         = Constants.DEFAULT_SEP;
        string      sline       = "";        
        string      stotal      = "";
        string      saux        = "";
        string      sfield      = "";
        int         j           =0;
        decimal     dqty        =0;
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday  = DateTime.Now;
        HotListHdr  hotListHdr  = hotListContainer.Count > 0 ? getCoreFactory().readHotListHdr(hotListContainer[0].Id) : null;
        DateTime    runDate     = hotListHdr!=null ? hotListHdr.HotlistRunDate : DateTime.Now;        
 
        if (hotListContainer.Count > 0 && arrayFieldListWeekly.Count > 0 && hotListHdr!= null){
                                
            sline  = "Dept" + sep + "Machine" + sep + "Part" + sep + "Seq" + sep + "MajGrp" + sep + "AvgDay" + sep + "DayOnHand" + sep + "RunStd" + sep + "Qoh"; 
            for (j = 0; j <= CapacityView.TITLE_COUNTS && j < arrayFieldListWeekly.Count; j++, priorMonday = priorMonday.AddDays(7)){
                DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
                saux = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);   
                sline+= sep + saux;
            }
            stotal = sline + "\n";
            
            for (int i=0; i < hotListContainer.Count ; i++){
                hotListInvAnalysisView = (HotListInvAnalysisView)hotListContainer[i];
                sline = hotListInvAnalysisView.Dept + sep + hotListInvAnalysisView.Mach + sep + hotListInvAnalysisView.ProdID + sep + hotListInvAnalysisView.Seq + sep + 
                        hotListInvAnalysisView.MajorGroup + sep + Convert.ToInt64(hotListInvAnalysisView.VirtKanManDem).ToString() + sep + Convert.ToInt64(hotListInvAnalysisView.DaysOnHand).ToString() + sep +
                        decimal.Round(hotListInvAnalysisView.MachCyc, 2).ToString() +  sep +  Convert.ToInt64(hotListInvAnalysisView.Qoh).ToString(); 

                if (!sdept.ToUpper().Equals(hotListInvAnalysisView.Dept.ToUpper()))
                    bsameDept=false;

                for (j = 0; j <= CapacityView.TITLE_COUNTS && j < arrayFieldListWeekly.Count; j++){                    
                    sfield  = (string)arrayFieldListWeekly[j];
                    saux    = sfield.ToUpper().Replace("HOT_", "").Replace("DAY","Day");

                    dqty = Math.Abs(hotListInvAnalysisView.getQtyByFieldName(saux));
                    dqty = hotListInvAnalysisView.MachCyc != 0 ? (dqty / hotListInvAnalysisView.MachCyc) : (dqty / 1);

                    sline+= sep + decimal.Round(dqty,1).ToString().Replace(",",".");                   
                }

                stotal+= sline + "\n";
            }

            stotal = stotal.Replace(",","");
            stotal = stotal.Replace(Constants.DEFAULT_SEP,',');

            //stotal = stotal.Replace(";","");
            //stotal = stotal.Replace(Constants.DEFAULT_SEP,';');
        }

        //generate file name
        sfileNameAux = "HotList Weekly-MachHours " + DateUtil.getCompleteDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD).Replace('/','-').Replace(':','-');        
        if (bsameDept)
            sfileNameAux+= " Dept " + sdept;        
        sfileNameAux+=".csv";        
        sfileName = ExportModel.generateFileName(sfileNameAux, "Exports", false);

        if (!string.IsNullOrEmpty(stotal))
            ExportModel.writeFile(sfileName,stotal,true); //write

    } catch (Exception ex) {
        MessageBox.Show("exportToCsv Exception: " + ex.Message);        
    } 
}

public 
void startCellSelect(){   
    for (int i=0; i < hotListContainerSelsSchedule.Count; i++) {
        HotListInvAnalysisViewSel hotListInvAnalysisViewSel = (HotListInvAnalysisViewSel)hotListContainerSelsSchedule[i];
        hotListInvAnalysisViewSel.setFree();
    }         
    hotListContainerSelsSchedule.Clear();                      
}

private 
void textBoxGotFocus(object sender, RoutedEventArgs e){            
    textBoxGotFocus((TextBox)sender);
}

private 
void mouseEventFocus(object sender, MouseEventArgs m){            
    
}


private 
void textBoxGotFocus(TextBox textBoxEvent){
    try { 
        bool bcontrolPressed = (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl));

        if (!bcontrolPressed)
            startCellSelect();

        HotListInvAnalysisView  hotListInvAnalysisView = (HotListInvAnalysisView)textBoxEvent.DataContext;
        
        if (hotListInvAnalysisView!= null && hotListHdr!= null){                         
            var                     binding = BindingOperations.GetBinding(textBoxEvent, TextBox.TextProperty); // get binding
            string                  sbind   = binding!= null ? binding.Path.Path : "";   
            string                  sday    = sbind.Length > 3 ? sbind.Substring(sbind.Length-3,3):"";
            int                     iday    = NumberUtil.isIntegerNumber(sday) ? Convert.ToInt32(sday) : int.MinValue;
            Machine                 machine = getCoreFactory().readMachine(hotListInvAnalysisView.Plt, hotListInvAnalysisView.Dept, hotListInvAnalysisView.Mach);         
    
            if (machine!= null && iday != int.MinValue) {                                       
                HotListInvAnalysisViewSel   hotListInvAnalysisViewSel = new HotListInvAnalysisViewSel();                
                hotListInvAnalysisViewSel.copy(hotListInvAnalysisView);
                hotListInvAnalysisViewSel.MachId    = machine.Id;
                hotListInvAnalysisViewSel.Qty       = System.Math.Abs(hotListInvAnalysisView.getQtyByFieldName(sbind));                                
                hotListInvAnalysisViewSel.DateTime  = hotListHdr.HotlistRunDate.AddDays(iday-1);                        
                hotListInvAnalysisViewSel.TextBox   = textBoxEvent;            
                hotListInvAnalysisViewSel.setSelected();
                
                hotListContainerSelsSchedule.Add(hotListInvAnalysisViewSel);
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("textBoxGotFocus Exception: " + ex.Message);        
    }
}  

public
bool addIfCurrCellFocused(){
    bool bresult=false;

    if (this.textBoxLast!= null && textBoxLast.IsFocused){ 
        textBoxGotFocus(textBoxLast);
        bresult=true;
    }        
    return bresult;        
} 

public 
bool schedule(){
    bool bresult=false;
    try { 
        if (hotListContainerSelsSchedule.Count > 0 && hotListHdr!= null) { 
            scheduleHdr                         = getCoreFactory().readScheduleHdrLast(hotListHdr.Plant);
            SchedulePart    schedulePart        = null;
            string          splant              = hotListHdr.Plant;            
            string          smessError          = "";
            int             icountAdded         =0;
            int             icountDiscarded     =0;

            if (scheduleHdr == null) { 
                scheduleHdr  = getCoreFactory().createScheduleHdr();
                scheduleHdr.Plant = hotListHdr.Plant;
            }
            
            for (int i=0; i < hotListContainerSelsSchedule.Count; i++) {
                HotListInvAnalysisViewSel hotListInvAnalysisViewSel = (HotListInvAnalysisViewSel)hotListContainerSelsSchedule[i];

                hotListInvAnalysisViewSel.DateTime = DateUtil.minorHour(hotListInvAnalysisViewSel.DateTime);
                hotListInvAnalysisViewSel.Qty      = Math.Abs(hotListInvAnalysisViewSel.Qty);

                if (hotListInvAnalysisViewSel.Qty > 0) { 
                    schedulePart = getCoreFactory(). scheduleAddSchedulePart(ref scheduleHdr,splant, hotListInvAnalysisViewSel.MachId,
                    hotListInvAnalysisViewSel.ProdID, hotListInvAnalysisViewSel.Seq,Math.Abs(hotListInvAnalysisViewSel.Qty), hotListInvAnalysisViewSel.DateTime,true,true,out smessError);

                    if (schedulePart!= null && string.IsNullOrEmpty(smessError)){
                        icountAdded++;
                        schedulePart.HdrId      = hotListInvAnalysisViewSel.Id;
                        schedulePart.HotListId  = hotListInvAnalysisViewSel.IdAut;
                    }else              
                        icountDiscarded++;
                }else              
                    icountDiscarded++;
            }

            bresult =true;
            if (icountAdded > 0 && scheduleHdr!= null){                            
                if (scheduleHdr.Id > 0)
                    getCoreFactory().updateScheduleHdr(scheduleHdr);
                else
                    getCoreFactory().writeScheduleHdr(scheduleHdr);                
            }
                    
            MessageBox.Show("Schedule Processed :\n\n" +  " Added     : " + icountAdded.ToString() +  "\n\n" + " Discarded : " + icountDiscarded.ToString());
        }else
            MessageBox.Show("Please, Select Item First.");

    } catch (Exception ex) {
        bresult=false;
        MessageBox.Show("schedule Exception: " + ex.Message);        
    }finally{
        if (bresult)
            startCellSelect();
    }

    return bresult;
}  

public 
bool scheduleW(){
    bool bresult=false;
    try { 
        if (this.hotListContainerSelsSchedule.Count > 0 && hotListHdr!= null) { 

            HotListScheduleWindow hotListScheduleWindow = new HotListScheduleWindow(hotListContainerSelsSchedule, hotListHdr);
            hotListScheduleWindow.ShowDialog();

            bresult=true;

        }else
            MessageBox.Show("Please, Select Item First.");

    } catch (Exception ex) {
        bresult=false;
        MessageBox.Show("scheduleW Exception: " + ex.Message);        
    }finally{
        if (bresult)
            startCellSelect();
    }

    return bresult;
}  


}
}
