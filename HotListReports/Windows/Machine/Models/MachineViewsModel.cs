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
using Nujit.NujitERP.ClassLib.Core.Planned;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Demand;
using Nujit.NujitERP.ClassLib.Core.Machines;
using HotListReports.Windows.Util.Message;



namespace HotListReports.Windows.Machines{

class MachineViewsModel : ReportTypeViewsModel {


private ListView        machineShiftListView;
private ListView        machinePartsListView;

private CellMachinePart cellMachinePartSelected=null;
private Hashtable       hashParts;

private Hashtable       hashPrHistSum;
private DateTime        prHistDateTimeChecked;

private bool            bincludePlanned;

public MachineViewsModel(Window window, ListView machineShiftListView,ListView machinePartsListView) : base(window){    
    init();

    this.machineShiftListView   = machineShiftListView;    
    this.machinePartsListView   = machinePartsListView;    
}

public MachineViewsModel(Window window) : base(window){               
    init();    
}

public
void init(){
    this.machineShiftListView   = null;    
    this.machinePartsListView   = null;   

    this.hashParts = new Hashtable();
    this.hashPrHistSum = new Hashtable();
    this.prHistDateTimeChecked = DateUtil.MinValue;

    this.bincludePlanned = true;
}

public
Hashtable HashPrHistSum {
	get { return hashPrHistSum; }
	set { if (this.hashPrHistSum != value){
			this.hashPrHistSum = value;			
		}
	}
}
       
public
void adjustMachineSelectTitle(Machine machine){
    try {
        string space = "  ";        
        string stitle = space + (machine != null ? machine.PlantDept + "/" + machine.Mach + space + machine.Des1 : "N/A");
        window.Title = "Machine Views :" + space + stitle;    

        CapacityMachPriority capacityMachPriority = machine!= null ? getCoreFactory().getCapacityMachPriority(machine.Id,machine.Plt) : null;
        string spriority = "Priority : " +  (capacityMachPriority!= null ? capacityMachPriority.Priority.ToString() : "N/A");
        window.Title+= space  + spriority;

        if (machine!= null && machine.MachineDef!= null) { 
            //window.Title+= space  + " Weekly Capacity : " + (machine.MachineDef.WeeklyCapacity != 0 ? decimal.Floor(machine.MachineDef.WeeklyCapacity).ToString() : "N/A");            
            window.Title+= space  + " ShiftP/Week : " +      machine.MachineDef.StdShiftPerWeek.ToString("#0.00");
            decimal    dhoursPerShift = machine.MachineDef.HrsPerShift !=0 ? machine.MachineDef.HrsPerShift : (decimal)7.25;
            window.Title+= space  + " HrsP/Shift : " + dhoursPerShift.ToString("#0.00");
        }

    } catch (Exception ex) {
        MessageBox.Show("adjustMachineSelectTitle Exception: " + ex.Message);        
    } 
}

public
CellMachinePart getCellMachinePartSelected(){
    return cellMachinePartSelected;
}

public
void loadColumnsOnMachineListView(ListView listView){
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
                    
            textBlockColumnListView = new TextBlockColumnListView( (i==0 ? CapacityView.TITLE_WEEK0 : ("Week" + i.ToString())) + "\n" + sdate, sbinding, BindingMode.OneWay,50, listView);            
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
MachineReportViewContainer loadMachine( ListView listView,TabItem machineTabItem,Machine machineFilter,RoutingContainer routingContainer,
                                        CapacityHdr capacityHdr, string splant,string sdept,string smachine,string smachDesc,string spart, DateTime dateWeek){
    MachineReportViewContainer              machineReportViewContainer = getCoreFactory().createMachineReportViewContainer();
    MachineReportViewContainer              machineReportViewPlannedContainer = getCoreFactory().createMachineReportViewContainer();
    try{ 
        MachineReportView                   machineReportViewDemand = null;
        MachineReportView                   machineReportView = null;
        MachineReportView                   machineReportViewTotRequired = null;
        machine = machineFilter;        
        scheduleHdr = getCoreFactory().readScheduleHdrLastDateCheck(scheduleHdr,capacityHdr.Plant);        
        string                              sbindGroupTitle = "Title"; 
        plannedHdr = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);
        
        realodWeeksRanges();           
        adjustMachineSelectTitle(machine);        
               
        if (machine!= null) { 
            machineReportViewDemand = loadMachineDemand(machineReportViewContainer,capacityHdr,machine,splant, sdept, smachine, spart,dateWeek);
            loadMachineMinMax(machineReportViewContainer,capacityHdr,machine, splant, sdept, smachine, spart,dateWeek);
            loadMachineScheduledVolume(machineReportViewContainer,capacityHdr,machine, machineReportViewDemand, splant, sdept, smachine, spart,dateWeek);

            //2
            loadMachineCycleTime(machineReportViewContainer, routingContainer);
            loadMachineAverageCavities(machineReportViewContainer, routingContainer);
            loadMachinePiecesPerHour(machineReportViewContainer, routingContainer);

            //3
            loadOee(machineReportViewContainer,capacityHdr,machine,splant, sdept, smachine, spart, dateWeek);
            loadOeePerfOA(machineReportViewContainer,capacityHdr,machine,splant, sdept, smachine, spart, dateWeek);
            loadOeeScrapRate(machineReportViewContainer,capacityHdr,machine,splant, sdept, smachine, spart, dateWeek);
            loadOeeNetPressRate(machineReportViewContainer,capacityHdr,machine,splant, sdept, smachine, spart, dateWeek);

            loadMachineCapacity(machineReportViewContainer,capacityHdr, machine,splant,sdept,smachine,spart, dateWeek);                    

            //5
            loadPlannedRunHours(machineReportViewContainer,machineReportViewPlannedContainer, capacityHdr,plannedHdr,machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);                        
            loadPlannedDownTimeHours( machineReportViewContainer, machineReportViewPlannedContainer,capacityHdr, machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);
            loadPlannedChangeOverHours( machineReportViewContainer, machineReportViewPlannedContainer,capacityHdr, machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);
            machineReportViewTotRequired = loadPlannedTotalHrsRequired(machineReportViewContainer,machineReportViewPlannedContainer);
            loadPlannedHrsPerShift(machineReportViewContainer, capacityHdr, machine, scheduleHdr, splant, sdept, smachine, spart, dateWeek);
            machineReportViewTotRequired = loadPlannedShiftsRequired(machineReportViewContainer, machineReportViewTotRequired);            
            loadPlannedStdShiftsPerWeek( machineReportViewContainer,capacityHdr,machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);

            loadPlannedOverTimeHours(machineReportViewContainer, machineReportViewTotRequired,machine);
            loadPlannedShiftsSummaryRequired(machineReportViewContainer, machineReportViewTotRequired);
            
        
            //6                
            loadScheduledRunHours( machineReportViewContainer,capacityHdr,machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);
            loadScheduledDownTimeHours( machineReportViewContainer,capacityHdr,machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);
            loadScheduledChangeOverHours( machineReportViewContainer,capacityHdr,machine,scheduleHdr, splant, sdept, smachine, spart, dateWeek);
                           
            //loadPiecesPerHour(machineReportViewContainer,capacityHdr, machine,splant,sdept,smachine,spart, dateWeek);
        }       
                          
        setDataContextListView(listView, machineReportViewContainer);       
        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
        PropertyGroupDescription groupDescription = new PropertyGroupDescription(sbindGroupTitle);
        view.GroupDescriptions.Add(groupDescription);   

        machineTabItem.DataContext = machine;
        
        
    } catch (Exception ex) {
        MessageBox.Show("loadMachine Exception: " + ex.Message);        
    }
    return machineReportViewContainer;
}


public
MachineReportViewContainer loadMachineCapacity(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr, Machine machine,
                                                string splant,string sdept,string smachine,string spart, DateTime dateWeek){    
    try{ 
        
        CapacityViewContainer               capacityViewContainer = getCoreFactory().createCapacityViewContainer();
        MachineReportView                   machineReportView= null;        
        MachineReportView                   machineReportViewCumulative= null;
        MachineReportView                   machineReportViewPercentaje= null;
        MachineReportView                   machineReportViewMACHSHIFTHOURS = null;                
        MachineReportView                   machineReportViewCUMULATIVE_MACHSHIFTHOURS = null;                
        CapacityView                        capacityView = null;
        int                                 i=0;
        
        if (machine!= null)
            capacityViewContainer = getCoreFactory().processCapacityReportGroupByReqTypeDept(capacityHdr.Id, "","", "",
                                machine.Id,CapacityReq.REQUIREMENT_MACHINE,spart,dateWeek,CapacityView.SORT_TYPE.DEPT_REQUIRMENT);        
                       
        for (i=0; i < capacityViewContainer.Count;i++){
            capacityView = capacityViewContainer[i];

            //TYPE_NORMAL=0,MACHSHIFTHOURS=1 CUMULATIVE_SHIFTS=2 CUMULATIVE_MACHSHIFTHOURS=3 PERCENTAGE=4 CUMULATIVE_PERCENTAGE= 5                                                                                             
            //loadCapacityMachineReportViewInfo(ref machineReportView,                capacityView, "Machine Hours",      "10", CapacityView.SHOW_TYPE.TYPE_NORMAL);            
            loadCapacityMachineReportViewInfo(ref machineReportViewPercentaje,      capacityView, "Machine Percentage", "10", CapacityView.SHOW_TYPE.PERCENTAGE);
            loadCapacityMachineReportViewInfo(ref machineReportViewMACHSHIFTHOURS,  capacityView, "Machine Shift Hours","10", CapacityView.SHOW_TYPE.TYPE_MACHSHIFTHOURS);                                                                                                         
        }        

        if (machineReportView != null){                                    
            //loadCapacityMachineReportViewInfo(ref machineReportViewCumulative,              null, "Machine Cumulative Hours", "10", CapacityView.SHOW_TYPE.CUMULATIVE_SHIFTS);
            loadCapacityMachineReportViewInfoSummarize(machineReportViewCumulative,machineReportView);            
        }

        if (machineReportViewMACHSHIFTHOURS != null){        
            loadCapacityMachineReportViewInfo(ref machineReportViewCUMULATIVE_MACHSHIFTHOURS,null,"Machine Cumulative Shift Hours", "10", CapacityView.SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS);
            loadCapacityMachineReportViewInfoSummarize(machineReportViewCUMULATIVE_MACHSHIFTHOURS, machineReportViewMACHSHIFTHOURS);
        }

        //load on properly order
        if (machineReportView != null)
            machineReportViewContainer.Add(machineReportView);                                   
        if (machineReportViewCumulative!= null)
            machineReportViewContainer.Add(machineReportViewCumulative);                                     
                
        if (machineReportViewMACHSHIFTHOURS != null)
            machineReportViewContainer.Add(machineReportViewMACHSHIFTHOURS);    
        if (machineReportViewCUMULATIVE_MACHSHIFTHOURS != null)
            machineReportViewContainer.Add(machineReportViewCUMULATIVE_MACHSHIFTHOURS);    
        if (machineReportViewPercentaje != null)
            machineReportViewContainer.Add(machineReportViewPercentaje);     
                
    } catch (Exception ex) {
        MessageBox.Show("loadMachineCapacity Exception: " + ex.Message);        
    }
    return machineReportViewContainer;
}

private
void loadCapacityMachineReportViewInfo(ref MachineReportView machineReportView,CapacityView capacityView, string sname,string starget,CapacityView.SHOW_TYPE showType){
    if (machineReportView == null){ //Normal
        machineReportView = getCoreFactory().createMachineReportView();                         
        machineReportView.Name = sname;
        machineReportView.Target = starget;                
    }

    machineReportView.HrsPerShift = getHrsPerShift();
    machineReportView.StdShiftPerWeek = getStdShiftPerWeek();
                
    if (capacityView!= null)
        machineReportView.copy(capacityView);
    machineReportView.Title = "Capacity";       
    machineReportView.ShowType = showType;

    if (capacityView != null)
        machineReportView.sumWeek();
}

private
void loadCapacityMachineReportViewInfoSummarize(MachineReportView machineReportViewSummarize,MachineReportView machineReportView){
    if (machineReportViewSummarize != null && machineReportView!= null){
        machineReportViewSummarize.WeekPastDue  = machineReportView.WeekPastDue;
        machineReportViewSummarize.Week0        = machineReportViewSummarize.WeekPastDue    + machineReportView.Week0;
        machineReportViewSummarize.Week1        = machineReportViewSummarize.Week0          + machineReportView.Week1;
        machineReportViewSummarize.Week2        = machineReportViewSummarize.Week1          + machineReportView.Week2;
        machineReportViewSummarize.Week3        = machineReportViewSummarize.Week2          + machineReportView.Week3;
        machineReportViewSummarize.Week4        = machineReportViewSummarize.Week3          + machineReportView.Week4;
        machineReportViewSummarize.Week5        = machineReportViewSummarize.Week4          + machineReportView.Week5;
        machineReportViewSummarize.Week6        = machineReportViewSummarize.Week5          + machineReportView.Week6;
        machineReportViewSummarize.Week7        = machineReportViewSummarize.Week6          + machineReportView.Week7;
        machineReportViewSummarize.Week8        = machineReportViewSummarize.Week7          + machineReportView.Week8;
        machineReportViewSummarize.Week9        = machineReportViewSummarize.Week8          + machineReportView.Week9;
        machineReportViewSummarize.Week10       = machineReportViewSummarize.Week9          + machineReportView.Week10;
        machineReportViewSummarize.Week11       = machineReportViewSummarize.Week10         + machineReportView.Week11;
        machineReportViewSummarize.Week12       = machineReportViewSummarize.Week11         + machineReportView.Week12;
        machineReportViewSummarize.Week13       = machineReportViewSummarize.Week12         + machineReportView.Week13;            
    }
}

private
MachineReportView loadMachineDemand( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
                                    string splant, string sdept, string smachine, string spart, DateTime dateWeek){

    MachineReportView   machineReportView = getCoreFactory().createMachineReportView();;
    try{ 
        HotListContainer    hotListContainer = null;
        HotList             hotList = null;
        int                 i=0;
        HotListHdr          hotListHdr = getCoreFactory().readLastHotList(capacityHdr.Plant);
        ArrayList           arrayDates = CapacityView.getDateTimeWeekList();        
        DateTime            runDate = DateTime.Now;
                         
        machineReportView = getCoreFactory().createMachineReportView();          
        machineReportView.Title = "Demand";
        machineReportView.ShowType = CapacityView.SHOW_TYPE.DEMAND;                          
        machineReportView.Name = "Demand/Requirments";
        machineReportView.Target = "1";
        machineReportViewContainer.Add(machineReportView);      

        if (hotListHdr!= null && machine!= null){

            runDate = hotListHdr.HotlistRunDate;
            hotListContainer = getCoreFactory().readHotListByFilters(hotListHdr.Id,hotListHdr.Plant,"","","", machine.Id,spart,-1,"","",true,false,0);
     
            for (i=0; i < hotListContainer.Count;i++)  {          
                hotList = hotListContainer[i];

                machineReportView.WeekPastDue += hotList.getQtyByRangeDate(runDate, hotList.calculatePastDueDate(runDate),dPastDue);
                machineReportView.Week0 += hotList.getQtyByRangeDate(runDate,dSweek0,dEweek0);
                machineReportView.Week1 += hotList.getQtyByRangeDate(runDate,dSweek1,dEweek1);
                machineReportView.Week2 += hotList.getQtyByRangeDate(runDate,dSweek2,dEweek2);
                machineReportView.Week3 += hotList.getQtyByRangeDate(runDate,dSweek3,dEweek3);
                machineReportView.Week4 += hotList.getQtyByRangeDate(runDate,dSweek4,dEweek4);
                machineReportView.Week5 += hotList.getQtyByRangeDate(runDate,dSweek5,dEweek5);
                machineReportView.Week6 += hotList.getQtyByRangeDate(runDate,dSweek6,dEweek6);
                machineReportView.Week7 += hotList.getQtyByRangeDate(runDate,dSweek7,dEweek7);
                machineReportView.Week8 += hotList.getQtyByRangeDate(runDate,dSweek8,dEweek8);
                machineReportView.Week9 += hotList.getQtyByRangeDate(runDate,dSweek9,dEweek9);
                machineReportView.Week10 += hotList.getQtyByRangeDate(runDate,dSweek10,dEweek10);
                machineReportView.Week11 += hotList.getQtyByRangeDate(runDate,dSweek11,dEweek11);
                machineReportView.Week12 += hotList.getQtyByRangeDate(runDate,dSweek12,dEweek12);
                machineReportView.Week13 += hotList.getQtyByRangeDate(runDate,dSweek13,dEweek13);                                
            }
        }                       

    }catch (Exception ex) {
        MessageBox.Show("loadMachineDemand Exception: " + ex.Message);        
    }    
    return machineReportView;
}

private
void loadMachineMinMax( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
                        string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.ShowType = CapacityView.SHOW_TYPE.DEMAND; 
        machineReportView.Title = "Demand";
        machineReportView.Name = "Min/Max Adjustments";
        machineReportView.Target = "1";
        machineReportViewContainer.Add(machineReportView);
        
    }catch (Exception ex) {
        MessageBox.Show("loadMachineMinMax Exception: " + ex.Message);        
    }    
}
        
private
void loadMachineScheduledVolume( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
                                MachineReportView machineReportViewDemand, string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();              
        if (machineReportViewDemand!= null)                    
            machineReportView.copy(machineReportViewDemand);
        machineReportView.Title = "Demand";
        machineReportView.Name = "Scheduled Volume";
        machineReportView.Target = "1";
        machineReportViewContainer.Add(machineReportView);
        
    }catch (Exception ex) {
        MessageBox.Show("loadMachineScheduledVolume Exception: " + ex.Message);        
    }    
}


private
void loadPiecesPerHour( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                        string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Cycle Info";
        machineReportView.Name = "Pieces/Hour";
        machineReportView.Target = "2";
        machineReportViewContainer.Add(machineReportView);
        
        if (scheduleHdr != null && machine!= null){
            foreach(SchedulePart schedulePart in scheduleHdr.SchedulePartContainer){
                if (schedulePart.MachId == machine.Id) { 
                    foreach(ScheduleReceiptPart scheduleReceiptPart in schedulePart.ScheduleReceiptPartContainer){
                        

                    }
                }
            }   
        }   
        
    }catch (Exception ex) {
        MessageBox.Show("loadPiecesPerHour Exception: " + ex.Message);        
    }    
}

private
void loadMachineCycleTime( MachineReportViewContainer machineReportViewContainer,RoutingContainer routingContainer){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Cycle Info";
        machineReportView.Name = "Cycle Time";
        machineReportView.Target = "2";
        machineReportViewContainer.Add(machineReportView);

        Routing     routing = routingContainer.Count > 0 ? routingContainer[0] : null;
        decimal     dvalue =0;

        if (routing != null){
            dvalue = routing.CycleTm;
            machineReportView.setSameValues(dvalue);
        }        
        
    }catch (Exception ex) {
        MessageBox.Show("loadMachineCycleTime Exception: " + ex.Message);        
    }    
}

private
void loadMachineAverageCavities( MachineReportViewContainer machineReportViewContainer,RoutingContainer routingContainer){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Cycle Info";
        machineReportView.Name = "Average Cavities";
        machineReportView.Target = "2";
        machineReportViewContainer.Add(machineReportView);
        
        Routing     routing = routingContainer.Count > 0 ? routingContainer[0] : null;
        decimal     dvalue =0;

        if (routing != null){
            dvalue = routing.CavityNum;
            machineReportView.setSameValues(dvalue);
        }        
        
    }catch (Exception ex) {
        MessageBox.Show("loadMachineAverageCavities Exception: " + ex.Message);        
    }    
}

private
void loadMachinePiecesPerHour( MachineReportViewContainer machineReportViewContainer,RoutingContainer routingContainer){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();     
        machineReportView.Title = "Cycle Info";                                 
        machineReportView.Name = "Pieces/Hour";
        machineReportView.Target = "2";
        machineReportViewContainer.Add(machineReportView);

        Routing     routing = routingContainer.Count > 0 ? routingContainer[0] : null;
        decimal     dvalue =0;

        if (routing != null){
            dvalue = routing.RunStd;
            machineReportView.setSameValues(dvalue);
        }        
        
    }catch (Exception ex) {
        MessageBox.Show("loadMachinePiecesPerHour Exception: " + ex.Message);        
    }    
}


/**************** Schedule/ Planning **********/
private
void loadScheduledRunHours( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                            string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Scheduling";
        machineReportView.Name = "Scheduled Run Hrs";
        machineReportView.Target = "6";
        machineReportViewContainer.Add(machineReportView);
        
        if (scheduleHdr!= null)
            processSummarizePartReceipts(machineReportView,scheduleHdr,machine.Id,spart);                       
        
    }catch (Exception ex) {
        MessageBox.Show("loadScheduledRunHours Exception: " + ex.Message);        
    }    
}

private
void loadScheduledDownTimeHours( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                                string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Scheduling";
        machineReportView.Name = "Scheduled DownTime Hrs";
        machineReportView.Target = "6";
        machineReportViewContainer.Add(machineReportView);
                                
        if (scheduleHdr != null)
            processSummarizeDown(machineReportView, scheduleHdr, machine.Id);                  
        
    }catch (Exception ex) {
        MessageBox.Show("loadScheduledDownTimeHours Exception: " + ex.Message);        
    }    
}

private
void loadScheduledChangeOverHours(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                                    string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Scheduling";
        machineReportView.Name = "Scheduled ChangeOver Hrs";
        machineReportView.Target = "6";
        machineReportViewContainer.Add(machineReportView);
        
        CapShiftTask    capShiftTaskChangeOver = getChangeOverTask();

        if (scheduleHdr != null && capShiftTaskChangeOver != null)
            processSummarizeTask(machineReportView, scheduleHdr, machine.Id,capShiftTaskChangeOver);
                             
    }catch (Exception ex) {
        MessageBox.Show("loadScheduledChangeOverHours Exception: " + ex.Message);        
    }    
}

private
void loadPlannedRunHours( MachineReportViewContainer machineReportViewContainer, MachineReportViewContainer machineReportViewPlannedContainer,
                        CapacityHdr capacityHdr,PlannedHdr plannedHdr, Machine machine,ScheduleHdr scheduleHdr,
                        string splant, string sdept, string smachine, string spart, DateTime dateWeek){    
    try{                           
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();   
        machineReportView.Title = "Planning";
        machineReportView.Name = "Planned Qty Run Hrs";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);
        machineReportViewPlannedContainer.Add(machineReportView);

        if (machine!=null) { 
            if (plannedHdr!= null){
                loadMachinePlanned(machineReportView, machine,plannedHdr,splant,sdept,smachine,spart,dateWeek);
            }else if (machine.MachineDef!= null)                        
                machineReportView.setSameValues(machine.MachineDef.PlanRunHrs);

        }        
        
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedRunHours Exception: " + ex.Message);        
    }     
}

private
void loadPlannedHrsPerShift(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                            string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Planning";
        machineReportView.Name = "Hrs Per Shift";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);

        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.HrsPerShift);
        
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedHrsPerShift Exception: " + ex.Message);        
    }    
}

private
void loadPlannedDownTimeHours(  MachineReportViewContainer machineReportViewContainer,MachineReportViewContainer machineReportViewPlannedContainer,
                                CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                                string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Planning";
        machineReportView.Name = "Planned DownTime Hrs";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);
        machineReportViewPlannedContainer.Add(machineReportView);

        if (machine!=null){
            decimal dtotalDownHours = (24 * 5) - machine.getTotalWeekHrs(); //24hs per 5 days a week
            machineReportView.setSameValues(dtotalDownHours);
        }
        
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedDownTimeHours Exception: " + ex.Message);        
    }    
}

private
void loadPlannedChangeOverHours( MachineReportViewContainer machineReportViewContainer, MachineReportViewContainer machineReportViewPlannedContainer,
                                CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                                string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Planning";
        machineReportView.Name = "Planned ChangeOver Hrs";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);
        machineReportViewPlannedContainer.Add(machineReportView);

        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(0 /*machine.MachineDef.PlanChanOvHrs*/);
                             
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedChangeOverHours Exception: " + ex.Message);        
    }    
}

private
void loadPlannedStdShiftsPerWeek( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                        string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Planning";
        machineReportView.Name = "Std Shifts Per Week";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);

        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.StdShiftPerWeek);
                             
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedStdShiftsPerWeek Exception: " + ex.Message);        
    }    
}

private
void loadPlannedUnitChangeOverTime( MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,ScheduleHdr scheduleHdr,
                        string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "Planning";
        machineReportView.Name = "Unit Change Over Time";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);
                           
        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.UnitChanOverTime);                  
    
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedUnitChangeOverTime Exception: " + ex.Message);        
    }    
}

private
MachineReportView loadPlannedTotalHrsRequired(MachineReportViewContainer machineReportViewContainer , MachineReportViewContainer machineReportViewPlannedContainer){
    MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
    try{ 
        
        machineReportView.Title = "Planning";
        machineReportView.Name = "Total Hrs Required";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);

        for (int i=0; i < machineReportViewPlannedContainer.Count; i++){
            MachineReportView currMachineReportView = machineReportViewPlannedContainer[i];

            machineReportView.WeekPastDue += currMachineReportView.WeekPastDue;
            machineReportView.Week0 += currMachineReportView.Week0;
            machineReportView.Week1 += currMachineReportView.Week1;
            machineReportView.Week2 += currMachineReportView.Week2;
            machineReportView.Week3 += currMachineReportView.Week3;
            machineReportView.Week4 += currMachineReportView.Week4;
            machineReportView.Week5 += currMachineReportView.Week5;
            machineReportView.Week6 += currMachineReportView.Week6;
            machineReportView.Week7 += currMachineReportView.Week7;
            machineReportView.Week8 += currMachineReportView.Week8;
            machineReportView.Week9 += currMachineReportView.Week9;
            machineReportView.Week10+= currMachineReportView.Week10;
            machineReportView.Week11+= currMachineReportView.Week11;
            machineReportView.Week12+= currMachineReportView.Week12;
            machineReportView.Week13+= currMachineReportView.Week13;

        }
                             
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedTotalHrsRequired Exception: " + ex.Message);        
    }    
    return machineReportView;
}

private
MachineReportView loadPlannedOverTimeHours(MachineReportViewContainer machineReportViewContainer,MachineReportView machineReportViewTotRequired,Machine machine){
    MachineReportView machineReportView = getCoreFactory().createMachineReportView();                      
    try{         
        machineReportView.Title = "Planning";
        machineReportView.Name = "Over Time";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);
                        
        decimal     dsSdShiftPerWeek = machine!= null ? machine.getStdShiftPerWeek() : (5*3);        
        decimal     dovertime =0;
        
        if (machine != null && machineReportViewTotRequired!= null){
            
            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.WeekPastDue;
            machineReportView.WeekPastDue = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week0;
            machineReportView.Week0 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week1;
            machineReportView.Week1 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week2;
            machineReportView.Week2 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week3;
            machineReportView.Week3 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week4;
            machineReportView.Week4 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week5;
            machineReportView.Week5 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week6;
            machineReportView.Week6 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week7;
            machineReportView.Week7 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week8;
            machineReportView.Week8 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week9;
            machineReportView.Week9 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week10;
            machineReportView.Week10 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week11;
            machineReportView.Week11 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week12;
            machineReportView.Week12 = dovertime < 0 ? Math.Abs(dovertime) : 0;

            dovertime = dsSdShiftPerWeek  - machineReportViewTotRequired.Week13;
            machineReportView.Week13 = dovertime < 0 ? Math.Abs(dovertime) : 0;                                                  
        }

    }catch (Exception ex) {
        MessageBox.Show("loadPlannedOverTimeHours Exception: " + ex.Message);        
    }    
    return machineReportView;
}

private
bool sumPlannedOvertimeHours(out decimal dshifts,PlannedLabour plannedLabour,Routing routing,DateTime startDate,DateTime endDate){
    dshifts=0;
    bool    breprocess = false;
    
    if (routing!= null && routing.RoutingLabToolContainer.Count > 0) {
        dshifts =1;
        decimal dtotEmployee = routing.RoutingLabToolContainer.getTotEmployees();	        
        // 1 runStd =       routingLabTool.TotEmployees              ? 
        //     x    _       Total
        decimal dhours = plannedLabour.TotEmployOver / (dtotEmployee != 0 ? dtotEmployee : 1);        
        dshifts = dhours / machine.getHrsPerShift();
    }
    
    return breprocess;
}


private
MachineReportView loadPlannedShiftsRequired(MachineReportViewContainer machineReportViewContainer ,MachineReportView machineReportViewHours){
    MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
    try{ 
        
        machineReportView.Title = "Planning";
        machineReportView.Name = "Total Shifts Required";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);

        if (machine!=null && machineReportViewHours!= null){            
            decimal dshift = machine.getHrsPerShift(); 

            machineReportView.WeekPastDue = machineReportViewHours.WeekPastDue / dshift;
            machineReportView.Week0 = machineReportViewHours.Week0/ dshift;
            machineReportView.Week1 = machineReportViewHours.Week1/ dshift;
            machineReportView.Week2 = machineReportViewHours.Week2/ dshift;
            machineReportView.Week3 = machineReportViewHours.Week3/ dshift;
            machineReportView.Week4 = machineReportViewHours.Week4/ dshift;
            machineReportView.Week5 = machineReportViewHours.Week5/ dshift;
            machineReportView.Week6 = machineReportViewHours.Week6/ dshift;
            machineReportView.Week7 = machineReportViewHours.Week7/ dshift;
            machineReportView.Week8 = machineReportViewHours.Week8/ dshift;
            machineReportView.Week9 = machineReportViewHours.Week9/ dshift;
            machineReportView.Week10= machineReportViewHours.Week10/ dshift;
            machineReportView.Week11= machineReportViewHours.Week11/ dshift;
            machineReportView.Week12= machineReportViewHours.Week12/ dshift;
            machineReportView.Week13= machineReportViewHours.Week13/ dshift;
        }
                             
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedChangeOverHours Exception: " + ex.Message);        
    }    
    return machineReportView;
}


private
MachineReportView loadPlannedShiftsSummaryRequired(MachineReportViewContainer machineReportViewContainer ,MachineReportView machineReportViewShifts){
    MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
    try{ 
        
        machineReportView.Title = "Planning";
        machineReportView.Name = "Net Shifts Summary";
        machineReportView.Target = "5";
        machineReportViewContainer.Add(machineReportView);

        if (machine!=null && machineReportViewShifts != null){                        

            machineReportView.WeekPastDue = machineReportViewShifts.WeekPastDue;        
            machineReportView.Week0 = machineReportView.WeekPastDue + machineReportViewShifts.Week0;
            machineReportView.Week1 = machineReportView.Week0       + machineReportViewShifts.Week1;
            machineReportView.Week2 = machineReportView.Week1       + machineReportViewShifts.Week2;
            machineReportView.Week3 = machineReportView.Week2       + machineReportViewShifts.Week3;
            machineReportView.Week4 = machineReportView.Week3       + machineReportViewShifts.Week4;
            machineReportView.Week5 = machineReportView.Week4       + machineReportViewShifts.Week5;
            machineReportView.Week6 = machineReportView.Week5       + machineReportViewShifts.Week6;
            machineReportView.Week7 = machineReportView.Week6       + machineReportViewShifts.Week7;
            machineReportView.Week8 = machineReportView.Week7       + machineReportViewShifts.Week8;
            machineReportView.Week9 = machineReportView.Week8       + machineReportViewShifts.Week9;
            machineReportView.Week10= machineReportView.Week9       + machineReportViewShifts.Week10;
            machineReportView.Week11= machineReportView.Week10      + machineReportViewShifts.Week11;
            machineReportView.Week12= machineReportView.Week11      + machineReportViewShifts.Week12;
            machineReportView.Week13= machineReportView.Week12      + machineReportViewShifts.Week13;
        }
                             
    }catch (Exception ex) {
        MessageBox.Show("loadPlannedChangeOverHours Exception: " + ex.Message);        
    }    
    return machineReportView;
}

private
void processSummarizeTask(MachineReportView machineReportView,ScheduleHdr scheduleHdr,int imachId,CapShiftTask capShiftTask){                
    decimal         dhours = 0;
    bool            breprocess = false;

    if (scheduleHdr != null && capShiftTask!= null){

        ScheduleHdr scheduleHdrClone = getCoreFactory().cloneScheduleHdr(scheduleHdr);        

        for (int i=0; i < scheduleHdrClone.ScheduleTaskContainer.Count;i++){
            breprocess = false;
            ScheduleTask scheduleTask = scheduleHdrClone.ScheduleTaskContainer[i];

            if (scheduleTask.MachId== imachId && capShiftTask.Id == scheduleTask.TaskId){

                dhours = Convert.ToDecimal((scheduleTask.EndDate - scheduleTask.StartDate).TotalHours);                    
                if (scheduleTask.StartDate <= dPastDue) { 
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dPastDue.AddMonths(-1),dPastDue);
                    machineReportView.WeekPastDue+= dhours;
                }else if (scheduleTask.StartDate>= dSweek0 && scheduleTask.StartDate <= dEweek0){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek0,dEweek0);
                    machineReportView.Week0+= dhours;
                }else if (scheduleTask.StartDate>= dSweek1 && scheduleTask.StartDate <= dEweek1){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek1,dEweek1);
                    machineReportView.Week1+= dhours;
                }else if (scheduleTask.StartDate>= dSweek2 && scheduleTask.StartDate <= dEweek2){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek2,dEweek2);
                    machineReportView.Week2+= dhours;
                }else if (scheduleTask.StartDate>= dSweek3 && scheduleTask.StartDate <= dEweek3){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek3,dEweek3);
                    machineReportView.Week3+= dhours;
                }else if (scheduleTask.StartDate>= dSweek4 && scheduleTask.StartDate <= dEweek4){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek4,dEweek4);
                    machineReportView.Week4+= dhours;
                }else if (scheduleTask.StartDate>= dSweek5 && scheduleTask.StartDate <= dEweek5){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek5,dEweek5);
                    machineReportView.Week5+= dhours;
                }else if (scheduleTask.StartDate>= dSweek6 && scheduleTask.StartDate <= dEweek6){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek6,dEweek6);
                    machineReportView.Week6+= dhours;
                }else if (scheduleTask.StartDate>= dSweek7 && scheduleTask.StartDate <= dEweek7){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek7,dEweek7);
                    machineReportView.Week7+= dhours;
                }else if (scheduleTask.StartDate>= dSweek8 && scheduleTask.StartDate <= dEweek8){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek8,dEweek8);
                    machineReportView.Week8+= dhours;
                }else if (scheduleTask.StartDate>= dSweek9 && scheduleTask.StartDate <= dEweek9){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek9,dEweek9);
                    machineReportView.Week9+= dhours;
                }else if (scheduleTask.StartDate>= dSweek10 && scheduleTask.StartDate <= dEweek10){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek10,dEweek10);
                    machineReportView.Week10+= dhours;
                }else if (scheduleTask.StartDate>= dSweek11 && scheduleTask.StartDate <= dEweek11){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek11,dEweek11);
                    machineReportView.Week11+= dhours;
                }else if (scheduleTask.StartDate>= dSweek12 && scheduleTask.StartDate <= dEweek12){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek12,dEweek12);
                    machineReportView.Week12+= dhours;
                }else if (scheduleTask.StartDate>= dSweek13 && scheduleTask.StartDate <= dEweek13){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleTask,dSweek13,dEweek13);
                    machineReportView.Week13+= dhours;                    
                }

                if (breprocess)
                    i--;
            }
        }   
    }   
 }   

private
void processSummarizeDown(MachineReportView machineReportView,ScheduleHdr scheduleHdr,int imachId){                
    decimal         dhours = 0;
    bool            breprocess = false;

    if (scheduleHdr != null){

        ScheduleHdr scheduleHdrClone = getCoreFactory().cloneScheduleHdr(scheduleHdr);        

        for (int i=0; i < scheduleHdrClone.ScheduleDownContainer.Count;i++){
            breprocess = false;
            ScheduleDown scheduleDown = scheduleHdrClone.ScheduleDownContainer[i];

            if (scheduleDown.MachId== imachId){

                dhours = Convert.ToDecimal((scheduleDown.EndDate - scheduleDown.StartDate).TotalHours);                    
                if (scheduleDown.StartDate <= dPastDue) { 
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dPastDue.AddMonths(-1),dPastDue);
                    machineReportView.WeekPastDue+= dhours;
                }else if (scheduleDown.StartDate>= dSweek0 && scheduleDown.StartDate <= dEweek0){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek0,dEweek0);
                    machineReportView.Week0+= dhours;
                }else if (scheduleDown.StartDate>= dSweek1 && scheduleDown.StartDate <= dEweek1){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek1,dEweek1);
                    machineReportView.Week1+= dhours;
                }else if (scheduleDown.StartDate>= dSweek2 && scheduleDown.StartDate <= dEweek2){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek2,dEweek2);
                    machineReportView.Week2+= dhours;
                }else if (scheduleDown.StartDate>= dSweek3 && scheduleDown.StartDate <= dEweek3){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek3,dEweek3);
                    machineReportView.Week3+= dhours;
                }else if (scheduleDown.StartDate>= dSweek4 && scheduleDown.StartDate <= dEweek4){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek4,dEweek4);
                    machineReportView.Week4+= dhours;
                }else if (scheduleDown.StartDate>= dSweek5 && scheduleDown.StartDate <= dEweek5){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek5,dEweek5);
                    machineReportView.Week5+= dhours;
                }else if (scheduleDown.StartDate>= dSweek6 && scheduleDown.StartDate <= dEweek6){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek6,dEweek6);
                    machineReportView.Week6+= dhours;
                }else if (scheduleDown.StartDate>= dSweek7 && scheduleDown.StartDate <= dEweek7){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek7,dEweek7);
                    machineReportView.Week7+= dhours;
                }else if (scheduleDown.StartDate>= dSweek8 && scheduleDown.StartDate <= dEweek8){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek8,dEweek8);
                    machineReportView.Week8+= dhours;
                }else if (scheduleDown.StartDate>= dSweek9 && scheduleDown.StartDate <= dEweek9){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek9,dEweek9);
                    machineReportView.Week9+= dhours;
                }else if (scheduleDown.StartDate>= dSweek10 && scheduleDown.StartDate <= dEweek10){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek10,dEweek10);
                    machineReportView.Week10+= dhours;
                }else if (scheduleDown.StartDate>= dSweek11 && scheduleDown.StartDate <= dEweek11){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek11,dEweek11);
                    machineReportView.Week11+= dhours;
                }else if (scheduleDown.StartDate>= dSweek12 && scheduleDown.StartDate <= dEweek12){
                    breprocess = sumTaskCheckIfReprocess(out dhours,scheduleDown,dSweek12,dEweek12);
                    machineReportView.Week12+= dhours;
                }else if (scheduleDown.StartDate>= dSweek13 && scheduleDown.StartDate <= dEweek13){
                    breprocess = sumTaskCheckIfReprocess(out dhours, scheduleDown, dSweek13,dEweek13);
                    machineReportView.Week13+= dhours;                    
                }

                if (breprocess)
                    i--;
            }
        }   
    }   
 }   


private
bool sumPartReceiptsCheckIfReprocess(out decimal dhours, SchedulePart schedulePart, DateTime startDate,DateTime endDate){
    dhours = Convert.ToDecimal((schedulePart.EndDate - schedulePart.StartDate).TotalHours);        
    bool    breprocess = false;
               
    if (schedulePart.EndDate > endDate.AddSeconds(1)) { 
        dhours = Convert.ToDecimal((endDate - schedulePart.StartDate).TotalHours);
        schedulePart.StartDate = endDate.AddSeconds(1); //adjust start date
        breprocess = true;
    }        
    return breprocess;
}

private
void loadOee(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
            string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "OEE";
        machineReportView.Name = "Oee";
        machineReportView.Target = "3";
        machineReportViewContainer.Add(machineReportView);
                           
        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.Oee);                  
    
    }catch (Exception ex) {
        MessageBox.Show("loadOee Exception: " + ex.Message);        
    }    
}

private
void loadOeePerfOA(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
            string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "OEE";
        machineReportView.Name = "Perf/OA";
        machineReportView.Target = "3";
        machineReportViewContainer.Add(machineReportView);
                           
        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.PerfOa);                  
    
    }catch (Exception ex) {
        MessageBox.Show("loadOeePerfOA Exception: " + ex.Message);        
    }    
}

private
void loadOeeScrapRate(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
            string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "OEE";
        machineReportView.Name = "Scrap Rate";
        machineReportView.Target = "3";
        machineReportViewContainer.Add(machineReportView);
                           
        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.ScrapRate);                  
    
    }catch (Exception ex) {
        MessageBox.Show("loadOeeScrapRate Exception: " + ex.Message);        
    }    
}

private
void loadOeeNetPressRate(MachineReportViewContainer machineReportViewContainer,CapacityHdr capacityHdr,Machine machine,
                        string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportView   machineReportView = getCoreFactory().createMachineReportView();                      
        machineReportView.Title = "OEE";
        machineReportView.Name = "Net Press Rate";
        machineReportView.Target = "3";
        machineReportViewContainer.Add(machineReportView);
                           
        if (machine!=null && machine.MachineDef!=null)
            machineReportView.setSameValues(machine.MachineDef.NetPressRate);                  
    
    }catch (Exception ex) {
        MessageBox.Show("loadOeeNetPressRate Exception: " + ex.Message);        
    }    
}

private
void processSummarizePartReceipts(MachineReportView machineReportView, ScheduleHdr scheduleHdr,int imachId,string spart){                
    decimal         dhours = 0;
    bool            breprocess = false;

    if (scheduleHdr != null){

        ScheduleHdr scheduleHdrClone = getCoreFactory().cloneScheduleHdr(scheduleHdr);
        
        for (int i=0; i < scheduleHdrClone.SchedulePartContainer.Count;i++){

            breprocess = false;
            SchedulePart schedulePart = scheduleHdrClone.SchedulePartContainer[i];

            if (schedulePart.MachId == imachId) {                 
                if (!string.IsNullOrEmpty(spart)){ //if part as filte, check if match
                    if (!StringUtil.ifMatch(schedulePart.Part.ToUpper(),spart.ToUpper()))                
                        continue;
                }
                                
                if (schedulePart.StartDate <= dPastDue) { 
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours, schedulePart, dPastDue.AddMonths(-1),dPastDue);
                    machineReportView.WeekPastDue+= dhours;
                }else if (schedulePart.StartDate>= dSweek0 && schedulePart.StartDate <= dEweek0){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek0,dEweek0);
                    machineReportView.Week0+= dhours;
                }else if (schedulePart.StartDate>= dSweek1 && schedulePart.StartDate <= dEweek1){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek1,dEweek1);
                    machineReportView.Week1+= dhours;
                }else if (schedulePart.StartDate>= dSweek2 && schedulePart.StartDate <= dEweek2){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek2,dEweek2);
                    machineReportView.Week2+= dhours;
                }else if (schedulePart.StartDate>= dSweek3 && schedulePart.StartDate <= dEweek3){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek3,dEweek3);
                    machineReportView.Week3+= dhours;
                }else if (schedulePart.StartDate>= dSweek4 && schedulePart.StartDate <= dEweek4){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek4,dEweek4);
                    machineReportView.Week4+= dhours;
                }else if (schedulePart.StartDate>= dSweek5 && schedulePart.StartDate <= dEweek5){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek5,dEweek5);
                    machineReportView.Week5+= dhours;
                }else if (schedulePart.StartDate>= dSweek6 && schedulePart.StartDate <= dEweek6){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek6,dEweek6);
                    machineReportView.Week6+= dhours;
                }else if (schedulePart.StartDate>= dSweek7 && schedulePart.StartDate <= dEweek7){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek7,dEweek7);
                    machineReportView.Week7+= dhours;
                }else if (schedulePart.StartDate>= dSweek8 && schedulePart.StartDate <= dEweek8){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek8,dEweek8);
                    machineReportView.Week8+= dhours;
                }else if (schedulePart.StartDate>= dSweek9 && schedulePart.StartDate <= dEweek9){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek9,dEweek9);
                    machineReportView.Week9+= dhours;
                }else if (schedulePart.StartDate>= dSweek10 && schedulePart.StartDate <= dEweek10){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek10,dEweek10);
                    machineReportView.Week10+= dhours;
                }else if (schedulePart.StartDate>= dSweek11 && schedulePart.StartDate <= dEweek11){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek11,dEweek11);
                    machineReportView.Week11+= dhours;
                }else if (schedulePart.StartDate>= dSweek12 && schedulePart.StartDate <= dEweek12){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek12,dEweek12);
                    machineReportView.Week12+= dhours;
                }else if (schedulePart.StartDate>= dSweek13 && schedulePart.StartDate <= dEweek13){
                    breprocess = sumPartReceiptsCheckIfReprocess(out dhours,schedulePart,dSweek13,dEweek13);
                    machineReportView.Week13+= dhours;                    
                }

                if (breprocess)
                    i--;            
            }
        }   
    }   
 }  

private
bool sumTaskCheckIfReprocess(out decimal dhours, ScheduleTask scheduleTask,DateTime startDate,DateTime endDate){
    dhours = Convert.ToDecimal((scheduleTask.EndDate - scheduleTask.StartDate).TotalHours);        
    bool    breprocess = false;
               
    if (scheduleTask.EndDate > endDate.AddSeconds(1)) { 
        dhours = Convert.ToDecimal((endDate - scheduleTask.StartDate).TotalHours);
        scheduleTask.StartDate = endDate.AddSeconds(1); //adjust start date
        breprocess = true;
    }        
    return breprocess;
}

private
bool sumTaskCheckIfReprocess(out decimal dhours, ScheduleDown scheduleDown, DateTime startDate,DateTime endDate){
    dhours = Convert.ToDecimal((scheduleDown.EndDate - scheduleDown.StartDate).TotalHours);        
    bool    breprocess = false;
               
    if (scheduleDown.EndDate > endDate.AddSeconds(1)) { 
        dhours = Convert.ToDecimal((endDate - scheduleDown.StartDate).TotalHours);
        scheduleDown.StartDate = endDate.AddSeconds(1); //adjust start date
        breprocess = true;
    }        
    return breprocess;
}

/****************************************** Machine/Parts *******************************************************************/
public
MachineReportViewContainer loadMachineParts( ListView listView,TabItem machinePartsTabItem,
                                            CapacityHdr capacityHdr, string splant,string sdept,string smachine,string smachDesc,
                                            string spart, DateTime dateWeek,bool bincludeProduction,bool bincludeZeroQty,bool bincludePlanned){
    
    this.bincludePlanned = bincludePlanned;
    MachineReportViewContainer              machineReportViewContainer = getCoreFactory().createMachineReportViewContainer();
    try{
        realodWeeksRanges();
        RoutingContainer                    routingContainer = getCoreFactory().createRoutingContainer();
                                            machine = getMachineByFilters(smachine,smachDesc,out routingContainer,splant,sdept,spart);
        //ScheduleHdr                         scheduleHdr = getCoreFactory().readScheduleHdrLast(capacityHdr.Plant);
        plannedHdr = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);
        inventoryObjectiveHdr = getCoreFactory().readInventoryObjectiveHdrLastDateCheck(inventoryObjectiveHdr,splant);
                                                       
        this.machinePartsListView = listView; //store listview, because will be used on textbox events        
        rewriteMachinePartListViewColumns(listView,bincludePlanned);                                
        adjustMachineSelectTitle(machine);

        if (machine != null) { 
            loadMachinePartsHotList(machineReportViewContainer,machine,capacityHdr,splant, sdept, smachine, spart, dateWeek, bincludeZeroQty);
            if (bincludePlanned) { 
                loadMachinePartsPlanned(machineReportViewContainer,machine,plannedHdr, splant, sdept, smachine, spart, dateWeek);
                loadMachinePartsPlannedOther(machineReportViewContainer,machine,plannedHdr, splant, sdept, smachine, spart, dateWeek);            
            }
            loadMachinePartsInventoryObjectives(machineReportViewContainer,machine,inventoryObjectiveHdr, splant, sdept, smachine, spart, dateWeek);
            loadMachinePartsNet(machineReportViewContainer,routingContainer);

            //production            
            if (bincludeProduction)
                this.getProductionPrHistSum(ref hashPrHistSum, ref prHistDateTimeChecked, "", -1,getPlant(),dSweek0, dEweek0, loadPartSeqRequired(machineReportViewContainer));//check production
            
            loadMachinePartsStartWkPlannedProdRemainWkPlanned(machineReportViewContainer,bincludePlanned);
        }
        
        setDataContextListView(listView,machineReportViewContainer);        
        machinePartsTabItem.DataContext = machine;        
        
    } catch (Exception ex) {
        MessageBox.Show("loadMachineParts2 Exception: " + ex.Message);        
    }
    return machineReportViewContainer;
}

private
void rewriteMachinePartListViewColumns(ListView listView, bool bincludePlanned){         
    try {         
        createListViewColumns(listView, 18);
        GridView                view = (GridView)listView.View;

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
            
        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        
            listViewCol = new ListViewCol();
            sbindPanel = "";
            if (i > 3) { 
                fontWeight = FontWeights.Bold;
                dcornerRadius = 0;
                sweek       = i > 4 ? "Week"     + (i-5) : "PastDue";
                sbindPanel  = i > 4 ? "WeekCell" + (i-5) : "WeekCellPastDue";
                dwith = Constants.WIDTH_HOTLIST_CELL + 10;
                                
                listViewCol.addTextBox("PriorWeekNet", false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_BACKGROUND,UIColors.COLOR_STACK_FONT);            
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");

                listViewCol.addTextBox("Required",  false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_BACKGROUND, UIColors.COLOR_STACK_FONT);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");

                if (!bincludePlanned){ 
                    listViewCol.addTextBox("InvObjectives", false , true, dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.LightGreen);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");   

                    listViewCol.addTextBox("Planned"   , false , true, dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.LightGreen);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");                       
                 
                }else {                     
                    frameworkElementFactoryTextBox = listViewCol.addTextBox("InvObjectives",   true ,false,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    frameworkElementFactoryTextBox.SetValue(TextBox.MaxLengthProperty, Int32.MaxValue.ToString().Length-1);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                    frameworkElementFactoryTextBox.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(invObjectivesTextBox_LostFocus));
                    frameworkElementFactoryTextBox.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(plannedTextBox_GotFocus));

                    frameworkElementFactoryTextBox = listViewCol.addTextBox("Planned",   true ,false,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    frameworkElementFactoryTextBox.SetValue(TextBox.MaxLengthProperty, Int32.MaxValue.ToString().Length-1);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                    frameworkElementFactoryTextBox.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(plannedTextBox_LostFocus));
                    frameworkElementFactoryTextBox.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(plannedTextBox_GotFocus));                
                }
                               
                listViewCol.addTextBox("PlannedQtyChange"   , false , true, dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.LightGreen);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");

                listViewCol.addTextBox("PlannedOther"   , false , true, dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.LightGreen);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");  

                listViewCol.addTextBox("NetShow",       false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.LightGreen);                                    
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");                
            }

            //if (i > 1)
                //cell.Setters.Remove(textAlignSetter); //only 2 first columns aligned left
            
            column.HeaderContainerStyle = cell;        
            column.Width = dwith+10;
                
            switch (i){
                case 0:                    
                    column.Header = space + "Part   / Seq    / Desc" + "\n" + space + "RunStd / PerWeek / Type";                
                    column.Width = 200;
                    listViewCol.addTextBlock("Part",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("Seq", 180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("Name",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);  
                    listViewCol.addTextBlock("RunStd",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);                                                          
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                    listViewCol.addTextBlock("QtyPerWeek", 180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);                                                          
                    listViewCol.setConverter( new DecimalToStringConverterNew(), "int");
                    listViewCol.addTextBlock("PartType",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("Target",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);
                    break;                     
                case 1:
                    column.Header = space + "Description";
                    sbindPanel = "CellTitles2";                
                    column.Width = 110;
                    listViewCol.addTextBlock("Title1",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title3",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title4",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title5",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title6",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title7",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);                         
                    break;                 
                case 2:                  
                    column.Header = space + "Start";                              
                    dwith = Constants.WIDTH_HOTLIST_CELL + 30;
                    column.Width = dwith;
                    listViewCol.addTextBox("Qoh",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    listViewCol.setConverter( new DecimalToStringConverter(),"int");
                    listViewCol.addTextBox("StartWeekPlanned",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                    listViewCol.addTextBox("Production",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                    listViewCol.addTextBox("RemaintWeekPlanned",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    listViewCol.setConverter( new DecimalToStringConverterNew(),"int");                                               

                    listViewCol.addTextBox("Title5",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
                    listViewCol.addTextBox("Title5",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);                    
                    listViewCol.addTextBox("Title5",       false,true ,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, Colors.Black,Colors.White);                                        
                    break;                                                                 
                case 3:
                    column.Header = space + "Description";
                    sbindPanel = "CellTitles";                
                    column.Width = 110;
                    listViewCol.addTextBlock("Title1",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT,Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title3",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title4",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title5",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title6",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title7",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);                         
                    break;                                        
                case 4:
                    column.Width = 0; //past due do not show
                    column.Header = space + sweek;
                    break;
                case 5:
                    sweek = CapacityView.TITLE_WEEK0;
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek0,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 6:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek1,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 7:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek2,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 8:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek3,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 9:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek4,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 10:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek5,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 11:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek6,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 12:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek7,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 13:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek8,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 14:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek9,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 15:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek10,DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 16:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek11,DateUtil.MMDDYYYY).Substring(0,5);
                    break;          
                case 17:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek12,DateUtil.MMDDYYYY).Substring(0,5);
                    break;          
                case 18:
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek13,DateUtil.MMDDYYYY).Substring(0,5);
                    break;          
            }                  
            column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);                                             
        }    

    } catch (Exception ex) {
        MessageBox.Show("rewriteMachinePartListViewColumns Exception: " + ex.Message);        
    }
}

private 
void plannedTextBox_LostFocus(object sender, RoutedEventArgs e){
    plannedTextBoxPlannedLosttFocus((TextBox)sender);    
}

private 
void plannedTextBox_GotFocus(object sender, RoutedEventArgs e){
    plannedTextBoxGotFocus((TextBox)sender);    
}

private 
void plannedOvertimeTextBox_LostFocus(object sender, RoutedEventArgs e){
    plannedOvertimeTextBoxLostFocus((TextBox)sender);    
}


private 
bool plannedTextBoxLosttFocusOld(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellMachinePart cellMachinePart = (CellMachinePart)panel.DataContext;
            if (cellMachinePart!= null) { 
                CapacityPartContainer   capacityPartContainer = cellMachinePart.CapacityPartContainer;
                CapacityPart            capacityPart=null;
                CapacityPart            capacityPartOld= null;
                MachineReportPartView   machineReportPartView = (MachineReportPartView)getSelected(machinePartsListView);                            

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
                     createCapacityPartOld(machineReportPartView,cellMachinePart);
            }
        }        

    } catch (Exception ex) {
        MessageBox.Show("plannedTextBoxLosttFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private 
bool plannedTextBoxPlannedLosttFocus(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellMachinePart         cellMachinePart         = (CellMachinePart)panel.DataContext;
            MachineReportPartView   machineReportPartView   = (MachineReportPartView)getSelected(machinePartsListView);

            if (cellMachinePart!= null && machineReportPartView!= null) { 
                PlannedPartContainer    plannedPartContainer= cellMachinePart.PlannedPartContainer;
                PlannedPart             plannedPart         = null;                
                bool                    bisCurrentWeek      = (cellMachinePart.XIndex == 0);

                if (plannedPartContainer.Count > 0){ //if planned already created
                    plannedPart = plannedPartContainer[0];
                    
                    if ((bisCurrentWeek && (machineReportPartView.Production+cellMachinePart.Planned+cellMachinePart.PlannedOvertime) != (plannedPart.QtyPlanned + plannedPart.QtyOvertime)) ||
                        !bisCurrentWeek && (plannedPart.QtyPlanned != cellMachinePart.Planned)){//if qty changed we update it

                        plannedPart.QtyPlanned  = cellMachinePart.Planned +  (bisCurrentWeek ? machineReportPartView.Production:0);
                        cellMachinePart.Planned = plannedPart.QtyPlanned;
                        plannedHdr.LastMachPlannedId = machine!= null ? machine.Id : 0;
                        this.getCoreFactory().updatePlannedPart(plannedHdr,plannedPart);
                        bresult=true;                        
                    }                    
                }else
                    bresult=createPlannedPart(machineReportPartView,cellMachinePart);

                if (bresult){
                    refreshPlannedChanges((MachineReportViewContainer)machinePartsListView.DataContext, machineReportPartView,cellMachinePart);    
                    loadCapacityByShifts(machineShiftListView,this.plannedHdr!=null? plannedHdr.Plant:"", 0,CapacityViewContainer,hashPrHistSum,true);
                }
                machineReportPartViewRecalcNet(machineReportPartView,cellMachinePart);
            }
        }        

    } catch (Exception ex) {
        if (ex.Message.IndexOf(Constants.DATETIME_STAMP_TABLE_MESSAGE) >=0)
            MessageBox.Show(ex.Message);        
        else
            MessageBox.Show("plannedTextBoxPlannedLosttFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private 
bool plannedOvertimeTextBoxLostFocus(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellMachinePart         cellMachinePart         = (CellMachinePart)panel.DataContext;
            MachineReportPartView   machineReportPartView   = (MachineReportPartView)getSelected(machinePartsListView);

            if (cellMachinePart!= null && machineReportPartView!= null) { 
                PlannedPartContainer    plannedPartContainer= cellMachinePart.PlannedPartContainer;
                PlannedPart             plannedPart         = null;                
                bool                    bisCurrentWeek      = (cellMachinePart.XIndex == 0);

                if (plannedPartContainer.Count > 0){ //if planned already created
                    plannedPart = plannedPartContainer[0];
                    
                    if ((bisCurrentWeek && (machineReportPartView.Production+cellMachinePart.Planned+cellMachinePart.PlannedOvertime) != (plannedPart.QtyPlanned + plannedPart.QtyOvertime)) ||
                        !bisCurrentWeek && (plannedPart.QtyOvertime != cellMachinePart.PlannedOvertime)){//if qty changed we update it

                        plannedPart.QtyOvertime  = cellMachinePart.PlannedOvertime +  (bisCurrentWeek ? machineReportPartView.Production:0);
                        cellMachinePart.PlannedOvertime = plannedPart.QtyOvertime;
                        plannedHdr.LastMachPlannedId = machine!= null ? machine.Id : 0;
                        this.getCoreFactory().updatePlannedPart(plannedHdr,plannedPart);
                        bresult=true;                        
                    }                    
                }else
                    bresult=createPlannedPart(machineReportPartView,cellMachinePart);

                if (bresult){
                    refreshPlannedChanges((MachineReportViewContainer)machinePartsListView.DataContext, machineReportPartView,cellMachinePart);    
                    loadCapacityByShifts(machineShiftListView,this.plannedHdr!=null? plannedHdr.Plant:"", 0,CapacityViewContainer,hashPrHistSum,true);
                }
                machineReportPartViewRecalcNet(machineReportPartView,cellMachinePart);
            }
        }        

    } catch (Exception ex) {
        if (ex.Message.IndexOf(Constants.DATETIME_STAMP_TABLE_MESSAGE) >=0)
            MessageBox.Show(ex.Message);        
        else
            MessageBox.Show("plannedTextBoxPlannedLosttFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private
void machineReportPartViewRecalcNet(MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart) {
    if (machineReportPartView!= null && cellMachinePart!= null) { 
        machineReportPartView.recalcNet();                
        if (cellMachinePart.XIndex == 0) //if current week, check if Planned need to be recalc
            loadMachinePartsStartWkPlannedProdRemainWkPlanned(machineReportPartView,bincludePlanned);
    }
}

private
void createCapacityPartOld(MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart){
    CapacityPart    capacityPart=null;
       
    if (machineReportPartView!= null && cellMachinePart!= null && this.capacityHdr!=null && cellMachinePart.Planned != 0 && cellMachinePart.CapacityPartContainer.Count == 0){
        capacityPart = getCoreFactory().generateNewCapacityPartBasedPlanned(capacityHdr,machineReportPartView,cellMachinePart);        
        if (capacityPart!=null)
            cellMachinePart.CapacityPartContainer.Add(capacityPart);
    }

}

private
bool createPlannedPart(MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart){
    bool            bresult=false;
    PlannedPart     plannedPart = null;
    string          splant = capacityHdr != null ? capacityHdr.Plant : "";


    if (machineReportPartView!= null && cellMachinePart!= null && this.machine != null && this.capacityHdr!=null && 
        (cellMachinePart.Planned != 0  || cellMachinePart.PlannedOvertime != 0) && cellMachinePart.PlannedPartContainer.Count == 0){

        plannedPart = getCoreFactory().generateNewPlannedPartBasedPlanned(plannedHdr,splant,machine.Id, machineReportPartView.Part, machineReportPartView.Seq,cellMachinePart.Planned, cellMachinePart.PlannedOvertime,cellMachinePart.StartDate,true);        
        if (plannedPart != null) { 
            bresult=true;

            cellMachinePart.PlannedPartContainer.Add(plannedPart);
            if (plannedHdr== null)
                plannedHdr = getCoreFactory().readPlannedHdrLast(splant);
        }
    }
    return bresult;
}

private 
bool plannedTextBoxGotFocus(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel                       panel = null;
        MachineReportPartView       machineReportPartView = (MachineReportPartView)getSelected(machinePartsListView);                            

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            cellMachinePartSelected = (CellMachinePart)panel.DataContext;

            if (cellMachinePartSelected != null && cellMachinePartSelected.Index < this.machinePartsListView.Items.Count) { 
                this.machinePartsListView.SelectedIndex = cellMachinePartSelected.Index;
            }

            if (machineReportPartView!= null)
                machineReportPartView.recalcNet();
        }        

    } catch (Exception ex) {
        MessageBox.Show("plannedTextBoxGotFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private 
void invObjectivesTextBox_LostFocus(object sender, RoutedEventArgs e){
    invObjectivesTextBoxLostFocus((TextBox)sender);        
}

private 
bool invObjectivesTextBoxLostFocus(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellMachinePart             cellMachinePart = (CellMachinePart)panel.DataContext;
            MachineReportPartView       machineReportPartView = (MachineReportPartView)getSelected(machinePartsListView);                            
            if (cellMachinePart!= null && machineReportPartView!= null) {                 
                InventoryObjectivePartDtlContainer  inventoryObjectivePartDtlContainer = machineReportPartView.InventoryObjectivePartDtlContainer;                                
                InventoryObjectivePart              inventoryObjectivePart= inventoryObjectiveHdr != null ? inventoryObjectiveHdr.InventoryObjectivePartContainer.getByPartSeq(machineReportPartView.Part, machineReportPartView.Seq) : null;
                InventoryObjectivePartDtl           inventoryObjectivePartDtl = null;
                bool                                bprocessChanges=false;

                if (inventoryObjectivePart!= null){
                    inventoryObjectivePartDtl = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getByRangeDate(cellMachinePart.StartDate, cellMachinePart.EndDate);

                    if (inventoryObjectivePartDtl == null && cellMachinePart.InvObjectives > 0)
                        bprocessChanges=true;
                    if (inventoryObjectivePartDtl != null && inventoryObjectivePartDtl.Qty != cellMachinePart.InvObjectives)
                        bprocessChanges=true;                        
                }else if (cellMachinePart.InvObjectives > 0)
                    bprocessChanges=true;

                if (bprocessChanges) { 
                    inventoryObjectivePart = getCoreFactory().generateNewInventoryObjectivePartBasedPlanned(inventoryObjectiveHdr, inventoryObjectiveHdr!= null ? inventoryObjectiveHdr.Plant : Configuration.DftPlant, machine!=null ? machine.Id :0,machineReportPartView,cellMachinePart);                    
                    if (inventoryObjectivePart!= null)
                        machineReportPartView.InventoryObjectivePartDtlContainer = inventoryObjectivePart.InventoryObjectivePartDtlContainer;
                }
                machineReportPartView.recalcNet();
            }
        }        

    } catch (Exception ex) {
        if (ex.Message.IndexOf(Constants.DATETIME_STAMP_TABLE_MESSAGE) >=0)
            MessageBox.Show(ex.Message);        
        else
            MessageBox.Show("invObjectivesTextBoxLostFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private
void loadMachinePartsHotList(MachineReportViewContainer machineReportViewContainer,Machine machine,CapacityHdr capacityHdr,string splant, string sdept, string smachine, string spart, DateTime dateWeek,bool bincludeZeroQty){
    try{ 
        HotListContainer        hotListContainer = getCoreFactory().createHotListContainer();
        HotListHdr              hotListHdr = getCoreFactory().readLastHotList(capacityHdr.Plant);
        MachineReportPartView   machineReportPartView = null;            
        HotList                 hotList = null;
        DateTime                runDate = DateTime.Now;            
        int                     i=0;
        Product                 product=null;
        Inventory               inventory=null;
        
        if (hotListHdr!= null && machine!= null){
            runDate = hotListHdr.HotlistRunDate;
            hotListContainer = getCoreFactory().readHotListByFilters(hotListHdr.Id, hotListHdr.Plant,splant,sdept, smachine, machine.Id,spart,-1,"","",true,false,0);          
                            
            for (i=0; i < hotListContainer.Count;i++)  {          
                hotList = hotListContainer[i];

                machineReportPartView = getCoreFactory().createMachineReportPartView();
                machineReportPartView.Name = hotList.ProdID;
                product = readProductHash(hashParts,hotList.ProdID);
                if (product != null) { 
                    machineReportPartView.Name   = product.Des1;
                    machineReportPartView.SeqLast= product.SeqLast; //last seq
                }

                machineReportPartView.Part = hotList.ProdID;
                machineReportPartView.Seq = hotList.Seq;
                machineReportPartView.Qoh = hotList.Qoh;

                inventory = getCoreFactory().readInventory(hotList.ProdID,hotListHdr.Plant);//read inventory updated
                machineReportPartView.Qoh = inventory.getTotalInventory(hotList.Seq);
                
                machineReportPartView.WeekCellPastDue.Required+= hotList.getQtyByRangeDate(runDate, hotList.calculatePastDueDate(runDate), dPastDue);
                machineReportPartView.WeekCell0.Required+= hotList.getQtyByRangeDate(runDate,dSweek0,dEweek0);
                machineReportPartView.WeekCell1.Required += hotList.getQtyByRangeDate(runDate,dSweek1,dEweek1);
                machineReportPartView.WeekCell2.Required += hotList.getQtyByRangeDate(runDate,dSweek2,dEweek2);
                machineReportPartView.WeekCell3.Required += hotList.getQtyByRangeDate(runDate,dSweek3,dEweek3);
                machineReportPartView.WeekCell4.Required += hotList.getQtyByRangeDate(runDate,dSweek4,dEweek4);
                machineReportPartView.WeekCell5.Required += hotList.getQtyByRangeDate(runDate,dSweek5,dEweek5);
                machineReportPartView.WeekCell6.Required += hotList.getQtyByRangeDate(runDate,dSweek6,dEweek6);
                machineReportPartView.WeekCell7.Required += hotList.getQtyByRangeDate(runDate,dSweek7,dEweek7);
                machineReportPartView.WeekCell8.Required += hotList.getQtyByRangeDate(runDate,dSweek8,dEweek8);
                machineReportPartView.WeekCell9.Required += hotList.getQtyByRangeDate(runDate,dSweek9,dEweek9);
                machineReportPartView.WeekCell10.Required += hotList.getQtyByRangeDate(runDate,dSweek10,dEweek10);
                machineReportPartView.WeekCell11.Required += hotList.getQtyByRangeDate(runDate,dSweek11,dEweek11);
                machineReportPartView.WeekCell12.Required += hotList.getQtyByRangeDate(runDate,dSweek12,dEweek12);
                machineReportPartView.WeekCell13.Required += hotList.getQtyByRangeDate(runDate,dSweek13,dEweek13);  
                        
                if (bincludeZeroQty || machineReportPartView.getTotRequired(false) != 0)
                    machineReportViewContainer.Add(machineReportPartView);
            }            
        }


    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsHotList Exception: " + ex.Message);        
    }
}


private
void loadMachinePartsCapacityPlanned(MachineReportViewContainer machineReportViewContainer,Machine machine,CapacityHdr capacityHdr,string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportPartView   machineReportPartView = null;                    
        CapacityPart            capacityPart=null;
        CapacityPartContainer   capacityPartContainer = getCoreFactory().createCapacityPartContainer();
        int                     i=0;
        bool                    breprocess=false;
        decimal                 dqty=0;
        Inventory               inventory = null;
        Product                 product = null;


        if (capacityHdr!= null && machine != null){            
            capacityPartContainer = getCoreFactory().getCapacityPartContainerByFilters(capacityHdr.Id,spart,-1,CapacityReq.REQUIREMENT_MACHINE, machine.Id,0);
                                                    
            for (i=0; i < capacityPartContainer.Count;i++)  {          
                capacityPart = capacityPartContainer[i];
                breprocess=false;

                machineReportPartView = machineReportViewContainer.getByPartSeq(capacityPart.Part,capacityPart.Seq);
                if (machineReportPartView == null){
                    machineReportPartView = getCoreFactory().createMachineReportPartView();
                    machineReportViewContainer.Add(machineReportPartView);

                    machineReportPartView.Part = capacityPart.Part;
                    machineReportPartView.Seq = capacityPart.Seq;

                    inventory = getCoreFactory().readInventory(capacityPart.Part,capacityHdr.Plant);
                    machineReportPartView.Qoh = inventory!= null ? inventory.getTotalInventory(capacityPart.Seq) : 0;

                    product = readProductHash(hashParts,capacityPart.Part);
                    if (product!=null)
                        machineReportPartView.Name = product.Des1;                                                            
                }

                if (capacityPart.StartDate <= dPastDue) { 
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCellPastDue,capacityPart, dPastDue.AddMonths(-1),dPastDue);                    
                }else if (capacityPart.StartDate>= dSweek0 && capacityPart.StartDate <= dEweek0){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell0,capacityPart, dSweek0,dEweek0);                    
                }else if (capacityPart.StartDate>= dSweek1 && capacityPart.StartDate <= dEweek1){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell1,capacityPart, dSweek1,dEweek1);
                }else if (capacityPart.StartDate>= dSweek2 && capacityPart.StartDate <= dEweek2){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell2, capacityPart,dSweek2,dEweek2);                    
                }else if (capacityPart.StartDate>= dSweek3 && capacityPart.StartDate <= dEweek3){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell3,capacityPart,dSweek3,dEweek3);                    
                }else if (capacityPart.StartDate>= dSweek4 && capacityPart.StartDate <= dEweek4){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty, machineReportPartView.WeekCell4,capacityPart, dSweek4,dEweek4);
                }else if (capacityPart.StartDate>= dSweek5 && capacityPart.StartDate <= dEweek5){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell5,capacityPart, dSweek5,dEweek5);
                }else if (capacityPart.StartDate>= dSweek6 && capacityPart.StartDate <= dEweek6){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell6,capacityPart, dSweek6,dEweek6);                    
                }else if (capacityPart.StartDate>= dSweek7 && capacityPart.StartDate <= dEweek7){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell7,capacityPart, dSweek7,dEweek7);                    
                }else if (capacityPart.StartDate>= dSweek8 && capacityPart.StartDate <= dEweek8){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell8,capacityPart,dSweek8,dEweek8);                    
                }else if (capacityPart.StartDate>= dSweek9 && capacityPart.StartDate <= dEweek9){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell9,capacityPart,dSweek9,dEweek9);                    
                }else if (capacityPart.StartDate>= dSweek10 && capacityPart.StartDate <= dEweek10){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell10,capacityPart, dSweek10,dEweek10);                    
                }else if (capacityPart.StartDate>= dSweek11 && capacityPart.StartDate <= dEweek11){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell11,capacityPart,dSweek11,dEweek11);                    
                }else if (capacityPart.StartDate>= dSweek12 && capacityPart.StartDate <= dEweek12){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell12,capacityPart, dSweek12,dEweek12);                    
                }else if (capacityPart.StartDate>= dSweek13 && capacityPart.StartDate <= dEweek13){
                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell13,capacityPart, dSweek13,dEweek13);                    
                }

                if (breprocess)
                    i--;
            }
        }


    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsCapacityPlanned Exception: " + ex.Message);        
    }
}

private
void loadMachinePartsPlanned(MachineReportViewContainer machineReportViewContainer,Machine machine,PlannedHdr plannedHdr,string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportPartView   machineReportPartView = null;                            
        CapacityPartContainer   capacityPartContainer = getCoreFactory().createCapacityPartContainer();
        int                     i=0;
        bool                    breprocess=false;
        decimal                 dqty=0;
        Inventory               inventory = null;
        Product                 product = null;
        PlannedReq              plannedReq = null;
        PlannedPartContainer    plannedPartContainer = null;
        PlannedPart             plannedPart = null;


        if (plannedHdr != null && machine != null){
            plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,machine.Id);

            if (plannedReq!= null){
                plannedPartContainer = plannedReq.PlannedPartContainer;                
                                                    
                for (i=0; i < plannedPartContainer.Count;i++)  {          
                    plannedPart = plannedPartContainer[i];
                    breprocess=false;

                    if (!string.IsNullOrEmpty(spart)){ //if part as filter, check if match
                        if (!StringUtil.ifMatch(plannedPart.Part.ToUpper(),spart.ToUpper()))                
                            continue;
                    }

                    machineReportPartView = machineReportViewContainer.getByPartSeq(plannedPart.Part, plannedPart.Seq);
                    if (machineReportPartView == null){
                        machineReportPartView = getCoreFactory().createMachineReportPartView();
                        machineReportViewContainer.Add(machineReportPartView);

                        machineReportPartView.Part = plannedPart.Part;
                        machineReportPartView.Seq = plannedPart.Seq;

                        inventory = getCoreFactory().readInventory(plannedPart.Part,plannedHdr.Plant);
                        machineReportPartView.Qoh = inventory!= null ? inventory.getTotalInventory(plannedPart.Seq) : 0;

                        product = readProductHash(hashParts,plannedPart.Part);
                        if (product != null) { 
                            machineReportPartView.Name    = product.Des1;                                                            
                            machineReportPartView.SeqLast = product.SeqLast;
                        }
                    }

                    if (plannedPart.StartDate <= dPastDue) { 
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCellPastDue,plannedPart, dPastDue.AddMonths(-1),dPastDue);                    
                    }else if (plannedPart.StartDate>= dSweek0 && plannedPart.StartDate <= dEweek0){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell0,plannedPart, dSweek0,dEweek0);                    
                    }else if (plannedPart.StartDate>= dSweek1 && plannedPart.StartDate <= dEweek1){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell1,plannedPart, dSweek1,dEweek1);
                    }else if (plannedPart.StartDate>= dSweek2 && plannedPart.StartDate <= dEweek2){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell2,plannedPart, dSweek2,dEweek2);                    
                    }else if (plannedPart.StartDate>= dSweek3 && plannedPart.StartDate <= dEweek3){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell3,plannedPart,dSweek3,dEweek3);                    
                    }else if (plannedPart.StartDate>= dSweek4 && plannedPart.StartDate <= dEweek4){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty, machineReportPartView.WeekCell4,plannedPart, dSweek4,dEweek4);
                    }else if (plannedPart.StartDate>= dSweek5 && plannedPart.StartDate <= dEweek5){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell5,plannedPart, dSweek5,dEweek5);
                    }else if (plannedPart.StartDate>= dSweek6 && plannedPart.StartDate <= dEweek6){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell6,plannedPart, dSweek6,dEweek6);                    
                    }else if (plannedPart.StartDate>= dSweek7 && plannedPart.StartDate <= dEweek7){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell7,plannedPart, dSweek7,dEweek7);                    
                    }else if (plannedPart.StartDate>= dSweek8 && plannedPart.StartDate <= dEweek8){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell8,plannedPart,dSweek8,dEweek8);                    
                    }else if (plannedPart.StartDate>= dSweek9 && plannedPart.StartDate <= dEweek9){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell9,plannedPart,dSweek9,dEweek9);                    
                    }else if (plannedPart.StartDate>= dSweek10 && plannedPart.StartDate <= dEweek10){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell10,plannedPart, dSweek10,dEweek10);                    
                    }else if (plannedPart.StartDate>= dSweek11 && plannedPart.StartDate <= dEweek11){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell11,plannedPart,dSweek11,dEweek11);                    
                    }else if (plannedPart.StartDate>= dSweek12 && plannedPart.StartDate <= dEweek12){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell12,plannedPart, dSweek12,dEweek12);                    
                    }else if (plannedPart.StartDate>= dSweek13 && plannedPart.StartDate <= dEweek13){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell13,plannedPart, dSweek13,dEweek13);                    
                    }

                    if (breprocess)
                        i--;
                }
            }
        }


    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsPlanned Exception: " + ex.Message);        
    }
}

private
void loadMachinePartsPlannedOther(MachineReportViewContainer machineReportViewContainer,Machine machine,PlannedHdr plannedHdr,string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportPartView   machineReportPartView = null;                            
        CapacityPartContainer   capacityPartContainer = getCoreFactory().createCapacityPartContainer();
        int                     i=0;
        bool                    breprocess=false;
        decimal                 dqty=0;        
        PlannedPartContainer    plannedPartContainer = null;
        PlannedPart             plannedPart = null;
        string                  skey = "";

        //get all planned qty for other machines
        if (plannedHdr != null && machine != null){
            Hashtable  hashPlanPartsSeq = plannedHdr.groupByPartSeq(machine.Id,Constants.TYPE_MACHINE);
                                                    
            for (int j=0; j < machineReportViewContainer.Count;j++)  {          
                machineReportPartView = (MachineReportPartView)machineReportViewContainer[j];

                skey = machineReportPartView.Part.ToUpper() + Constants.DEFAULT_SEP + machineReportPartView.Seq.ToString();
                if (hashPlanPartsSeq.Contains(skey)) {

                    plannedPartContainer = (PlannedPartContainer)hashPlanPartsSeq[skey];
                    for (i=0; i < plannedPartContainer.Count;i++)  {          
                        plannedPart = plannedPartContainer[i];
                        breprocess=false;
                        
                        if (plannedPart.StartDate <= dPastDue) { 
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCellPastDue,plannedPart, dPastDue.AddMonths(-1),dPastDue,false);                    
                        }else if (plannedPart.StartDate>= dSweek0 && plannedPart.StartDate <= dEweek0){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell0,plannedPart, dSweek0,dEweek0,false);                     
                        }else if (plannedPart.StartDate>= dSweek1 && plannedPart.StartDate <= dEweek1){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell1,plannedPart, dSweek1,dEweek1,false); 
                        }else if (plannedPart.StartDate>= dSweek2 && plannedPart.StartDate <= dEweek2){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell2,plannedPart, dSweek2,dEweek2,false);                     
                        }else if (plannedPart.StartDate>= dSweek3 && plannedPart.StartDate <= dEweek3){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell3,plannedPart,dSweek3,dEweek3,false);                     
                        }else if (plannedPart.StartDate>= dSweek4 && plannedPart.StartDate <= dEweek4){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty, machineReportPartView.WeekCell4,plannedPart, dSweek4,dEweek4,false); 
                        }else if (plannedPart.StartDate>= dSweek5 && plannedPart.StartDate <= dEweek5){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell5,plannedPart, dSweek5,dEweek5,false); 
                        }else if (plannedPart.StartDate>= dSweek6 && plannedPart.StartDate <= dEweek6){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell6,plannedPart, dSweek6,dEweek6,false);                     
                        }else if (plannedPart.StartDate>= dSweek7 && plannedPart.StartDate <= dEweek7){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell7,plannedPart, dSweek7,dEweek7,false);                     
                        }else if (plannedPart.StartDate>= dSweek8 && plannedPart.StartDate <= dEweek8){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell8,plannedPart,dSweek8,dEweek8,false);                     
                        }else if (plannedPart.StartDate>= dSweek9 && plannedPart.StartDate <= dEweek9){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell9,plannedPart,dSweek9,dEweek9,false);                     
                        }else if (plannedPart.StartDate>= dSweek10 && plannedPart.StartDate <= dEweek10){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell10,plannedPart, dSweek10,dEweek10,false);                     
                        }else if (plannedPart.StartDate>= dSweek11 && plannedPart.StartDate <= dEweek11){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell11,plannedPart,dSweek11,dEweek11,false);                     
                        }else if (plannedPart.StartDate>= dSweek12 && plannedPart.StartDate <= dEweek12){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell12,plannedPart, dSweek12,dEweek12,false);                     
                        }else if (plannedPart.StartDate>= dSweek13 && plannedPart.StartDate <= dEweek13){
                            breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell13,plannedPart, dSweek13,dEweek13,false);                     
                        }

                        if (breprocess)
                            i--;
                    }

                }
            }            
        }


    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsPlanned Exception: " + ex.Message);        
    }
}


private
void loadMachinePartsInventoryObjectives(MachineReportViewContainer machineReportViewContainer,Machine machine,InventoryObjectiveHdr inventoryObjectiveHdr, string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{ 
        MachineReportPartView   machineReportPartView = null;                            
        CapacityPartContainer   capacityPartContainer = getCoreFactory().createCapacityPartContainer();
        int                     i=0;              
        InventoryObjectivePart  inventoryObjectivePart= null;

        if (inventoryObjectiveHdr != null && machine != null){
                                
            for (i=0; i < machineReportViewContainer.Count;i++)  {          
                machineReportPartView = (MachineReportPartView)machineReportViewContainer[i];                
                if (!string.IsNullOrEmpty(spart)){ //if part as filter, check if match
                    if (!StringUtil.ifMatch(machineReportPartView.Part.ToUpper(),spart.ToUpper()))                
                        continue;
                }

                inventoryObjectivePart = inventoryObjectiveHdr.InventoryObjectivePartContainer.getByPartSeq(machineReportPartView.Part, machineReportPartView.Seq);
                if (inventoryObjectivePart!= null){                           

                    machineReportPartView.WeekCellPastDue.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dPastDue.AddMonths(-1), dPastDue);                    
                    machineReportPartView.WeekCell0.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek0, dEweek0);
                    machineReportPartView.WeekCell1.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek1, dEweek1);
                    machineReportPartView.WeekCell2.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek2, dEweek2);
                    machineReportPartView.WeekCell3.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek3, dEweek3);
                    machineReportPartView.WeekCell4.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek4, dEweek4);
                    machineReportPartView.WeekCell5.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek5, dEweek5);
                    machineReportPartView.WeekCell6.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek6, dEweek6);
                    machineReportPartView.WeekCell7.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek7, dEweek7);
                    machineReportPartView.WeekCell8.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek8, dEweek8);
                    machineReportPartView.WeekCell9.InvObjectives = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek9, dEweek9);
                    machineReportPartView.WeekCell10.InvObjectives= inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek10,dEweek10);
                    machineReportPartView.WeekCell11.InvObjectives= inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek11,dEweek11);
                    machineReportPartView.WeekCell12.InvObjectives= inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek12,dEweek12);
                    machineReportPartView.WeekCell13.InvObjectives= inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(dSweek13,dEweek13);                    

                    machineReportPartView.InventoryObjectivePartDtlContainer = inventoryObjectivePart.InventoryObjectivePartDtlContainer;
                }                                         
            }            
        }

    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsInventoryObjectives Exception: " + ex.Message);        
    }
}

private
bool sumCapacityPartCheckIfReprocess(out decimal dqty,CellMachinePart cellMachinePart,CapacityPart capacityPart, DateTime startDate,DateTime endDate){
    decimal dminutes = Convert.ToDecimal((capacityPart.EndDate - capacityPart.StartDate).TotalMinutes);        
    bool    breprocess = false;
    
    dqty = capacityPart.QtyPlanned;

    if (capacityPart.EndDate > endDate.AddSeconds(1)) { 
        capacityPart.StartDate = endDate.AddSeconds(1); //adjust start date
        decimal dnewMinutes = Convert.ToDecimal((capacityPart.EndDate - capacityPart.StartDate).TotalMinutes);
        decimal dnewQty = dnewMinutes * 100 / (dminutes != 0 ? dminutes : 1);
        
        capacityPart.QtyPlanned = dnewQty;        
        dqty-= dnewQty;
        breprocess = true;
    }

    cellMachinePart.Planned+= dqty;    
    cellMachinePart.CapacityPartContainer.Add(capacityPart);
    cellMachinePart.StartDate = startDate;
    cellMachinePart.EndDate = endDate;
    return breprocess;
}

private
bool sumCapacityPartCheckIfReprocess(out decimal dqty,CellMachinePart cellMachinePart,PlannedPart plannedPart, DateTime startDate,DateTime endDate,bool isPlanned=true){
    decimal dminutes = Convert.ToDecimal((plannedPart.EndDate - plannedPart.StartDate).TotalMinutes);        
    bool    breprocess = false;
    
    dqty = plannedPart.QtyPlanned;

    if (plannedPart.EndDate > endDate.AddSeconds(1)) { 
        plannedPart.StartDate = endDate.AddSeconds(1); //adjust start date
        decimal dnewMinutes = Convert.ToDecimal((plannedPart.EndDate - plannedPart.StartDate).TotalMinutes);
        decimal dnewQty = dnewMinutes * 100 / (dminutes != 0 ? dminutes : 1);
        
        plannedPart.QtyPlanned = dnewQty;        
        dqty-= dnewQty;
        breprocess = true;
    }

    if (isPlanned) { 
        cellMachinePart.Planned+= dqty;    
        cellMachinePart.PlannedPartContainer.Add(plannedPart);

        cellMachinePart.PlannedQtyChange = plannedPart.QtyChange;            
        cellMachinePart.PlannedOvertime = plannedPart.QtyOvertime;
    }else{
        cellMachinePart.PlannedOther+= dqty;    
        cellMachinePart.PlannedPartOtherContainer.Add(plannedPart);
    }
    cellMachinePart.StartDate = startDate;
    cellMachinePart.EndDate = endDate;
    return breprocess;
}

private
void loadMachinePartsNet(MachineReportViewContainer machineReportViewContainer,RoutingContainer routingContainer){
    try{
        MachineReportPartView   machineReportPartView = null;                            
        for (int i=0; i < machineReportViewContainer.Count;i++) {                
            machineReportPartView = (MachineReportPartView)machineReportViewContainer[i];
            machineReportPartView.recalcNet();

            Routing  routing = routingContainer.getByFirst(machineReportPartView.Part,machineReportPartView.Seq,machine!=null ? machine.Mach:"");
            if (routing!=null)
                machineReportPartView.RunStd = routing.RunStd;

            if (machine!= null){ 
                machineReportPartView.HrsPerShift       = machine.getHrsPerShift(); 
                machineReportPartView.StdShiftPerWeek   = machine.getStdShiftPerWeek(); 
            }

            machineReportPartView.WeekCellPastDue.StartDate = machineReportPartView.WeekCellPastDue.EndDate = dPastDue;
            machineReportPartView.WeekCellPastDue.Index = i;
    
            machineReportPartView.WeekCell0.StartDate   = this.dSweek0;
            machineReportPartView.WeekCell0.EndDate     = this.dEweek0;
            machineReportPartView.WeekCell0.Index = i;

            machineReportPartView.WeekCell1.StartDate   = this.dSweek1;
            machineReportPartView.WeekCell1.EndDate     = this.dEweek1;
            machineReportPartView.WeekCell1.Index = i;

            machineReportPartView.WeekCell2.StartDate   = this.dSweek2;
            machineReportPartView.WeekCell2.EndDate     = this.dEweek2;
            machineReportPartView.WeekCell2.Index = i;

            machineReportPartView.WeekCell3.StartDate   = this.dSweek3;
            machineReportPartView.WeekCell3.EndDate     = this.dEweek3;
            machineReportPartView.WeekCell3.Index = i;

            machineReportPartView.WeekCell4.StartDate   = this.dSweek4;
            machineReportPartView.WeekCell4.EndDate     = this.dEweek4;
            machineReportPartView.WeekCell4.Index = i;

            machineReportPartView.WeekCell5.StartDate   = this.dSweek5;
            machineReportPartView.WeekCell5.EndDate     = this.dEweek5;
            machineReportPartView.WeekCell5.Index = i;

            machineReportPartView.WeekCell6.StartDate   = this.dSweek6;
            machineReportPartView.WeekCell6.EndDate     = this.dEweek6;
            machineReportPartView.WeekCell6.Index = i;

            machineReportPartView.WeekCell7.StartDate   = this.dSweek7;
            machineReportPartView.WeekCell7.EndDate     = this.dEweek7;
            machineReportPartView.WeekCell7.Index = i;

            machineReportPartView.WeekCell8.StartDate   = this.dSweek8;
            machineReportPartView.WeekCell8.EndDate     = this.dEweek8;
            machineReportPartView.WeekCell8.Index = i;

            machineReportPartView.WeekCell9.StartDate   = this.dSweek9;
            machineReportPartView.WeekCell9.EndDate     = this.dEweek9;
            machineReportPartView.WeekCell9.Index = i;

            machineReportPartView.WeekCell10.StartDate   = this.dSweek10;
            machineReportPartView.WeekCell10.EndDate     = this.dEweek10;
            machineReportPartView.WeekCell10.Index = i;

            machineReportPartView.WeekCell11.StartDate   = this.dSweek11;
            machineReportPartView.WeekCell11.EndDate     = this.dEweek11;
            machineReportPartView.WeekCell11.Index = i;

            machineReportPartView.WeekCell12.StartDate   = this.dSweek12;
            machineReportPartView.WeekCell12.EndDate     = this.dEweek12;
            machineReportPartView.WeekCell12.Index = i;

            machineReportPartView.WeekCell13.StartDate   = this.dSweek13;
            machineReportPartView.WeekCell13.EndDate     = this.dEweek13;
            machineReportPartView.WeekCell13.Index = i;
        }

    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsNet Exception: " + ex.Message);        
    }
}


/****************************************** MAchine Shift/Planning *********************************************************/
public
void loadColumnsOnHeaderView3Grid(ListView view3ListView,bool bloadType){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("Department", "[1]", BindingMode.OneWay,160, view3ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Requirm.", "[2]", BindingMode.OneWay,150, view3ListView);
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
void loadColumnsOnHeaderGeneric2(ListView listView,GridView gridView,Style cell){
     try {        
        TextBlockColumnListView textBlockColumnListView = null;
        int                     iwith = 55;

        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, "[3]", BindingMode.OneWay, iwith, listView);                                  
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
            textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_WEEKNUM + i.ToString() + "\n" + sdate, sbinding, BindingMode.OneWay, iwith, listView);                        

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
     
private
void loadMachinePlanned(MachineReportView machineReportView, Machine machine,PlannedHdr plannedHdr,string splant, string sdept, string smachine, string spart, DateTime dateWeek){
    try{         
        CapacityPartContainer   capacityPartContainer = getCoreFactory().createCapacityPartContainer();
        int                     i=0;
        bool                    breprocess=false;
        decimal                 dhours = 0;        
        PlannedReq              plannedReq = null;
        PlannedPartContainer    plannedPartContainer = null;
        PlannedPart             plannedPart = null;
        RoutingContainer        routingContainer = null; 
        Routing                 routing = null; 
        
        if (plannedHdr != null && machine != null){
            plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,machine.Id);
            if (plannedReq!= null){
                plannedPartContainer = plannedReq.PlannedPartContainer;                

                //read all routings for machine
                routingContainer = getCoreFactory().getBuildByFilters(machine.Plt,"",-1,machine.Id,true,false);                
                                                    
                for (i=0; i < plannedPartContainer.Count;i++)  {          
                    plannedPart = plannedPartContainer[i];
                    breprocess=false;
                    
                    if (!string.IsNullOrEmpty(spart)){ //if part as filte, check if match
                        if (!StringUtil.ifMatch(plannedPart.Part.ToUpper(),spart.ToUpper()))                
                            continue;
                    }

                    routing = routingContainer.getByFirst(plannedPart.Part,plannedPart.Seq,machine.Mach);//get routing for part                    
                   
                    if (plannedPart.StartDate <= dPastDue) { 
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dPastDue.AddMonths(-1),dPastDue);
                        machineReportView.WeekPastDue+= dhours;
                    }else if (plannedPart.StartDate>= dSweek0 && plannedPart.StartDate <= dEweek0){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek0,dEweek0);
                        machineReportView.Week0+= dhours;
                    }else if (plannedPart.StartDate>= dSweek1 && plannedPart.StartDate <= dEweek1){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek1,dEweek1);
                        machineReportView.Week1+= dhours;
                    }else if (plannedPart.StartDate>= dSweek2 && plannedPart.StartDate <= dEweek2){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek2,dEweek2);
                        machineReportView.Week2+= dhours;
                    }else if (plannedPart.StartDate>= dSweek3 && plannedPart.StartDate <= dEweek3){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek3,dEweek3);
                        machineReportView.Week3+= dhours;
                    }else if (plannedPart.StartDate>= dSweek4 && plannedPart.StartDate <= dEweek4){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek4,dEweek4);
                        machineReportView.Week4+= dhours;
                    }else if (plannedPart.StartDate>= dSweek5 && plannedPart.StartDate <= dEweek5){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek5,dEweek5);
                        machineReportView.Week5+= dhours;
                    }else if (plannedPart.StartDate>= dSweek6 && plannedPart.StartDate <= dEweek6){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek6,dEweek6);
                        machineReportView.Week6+= dhours;
                    }else if (plannedPart.StartDate>= dSweek7 && plannedPart.StartDate <= dEweek7){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek7,dEweek7);
                        machineReportView.Week7+= dhours;
                    }else if (plannedPart.StartDate>= dSweek8 && plannedPart.StartDate <= dEweek8){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek8,dEweek8);
                        machineReportView.Week8+= dhours;
                    }else if (plannedPart.StartDate>= dSweek9 && plannedPart.StartDate <= dEweek9){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek9,dEweek9);
                        machineReportView.Week9+= dhours;
                    }else if (plannedPart.StartDate>= dSweek10 && plannedPart.StartDate <= dEweek10){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek10,dEweek10);
                        machineReportView.Week10+= dhours;
                    }else if (plannedPart.StartDate>= dSweek11 && plannedPart.StartDate <= dEweek11){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek11,dEweek11);
                        machineReportView.Week11+= dhours;
                    }else if (plannedPart.StartDate>= dSweek12 && plannedPart.StartDate <= dEweek12){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek12,dEweek12);
                        machineReportView.Week12+= dhours;
                    }else if (plannedPart.StartDate>= dSweek13 && plannedPart.StartDate <= dEweek13){
                        breprocess = sumPlannedCheckIfReprocess(out dhours,plannedPart,routing,dSweek13,dEweek13);
                        machineReportView.Week13+= dhours;                    
                    }

                    if (breprocess)
                        i--;                    
                }
            }
        }


    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsPlanned Exception: " + ex.Message);        
    }
}

private
bool sumPlannedCheckIfReprocess(out decimal dhours,PlannedPart plannedPart,Routing routing,DateTime startDate,DateTime endDate){
    bool    breprocess = false;
    dhours=0;

    if (routing!= null) { 
        dhours = plannedPart.QtyPlanned / (routing.RunStd!=0 ? routing.RunStd:1);                                             
    }
    return breprocess;
}

public
bool automaticPlanned(string splant){
    bool bresult = false;
    try{
        MachineReportViewContainer machineReportViewContainer =  (MachineReportViewContainer)machinePartsListView.DataContext;
        if (machineReportViewContainer!= null) { 
            plannedHdr = getCoreFactory().machinePlannedFillFullAutomatic(plannedHdr,inventoryObjectiveHdr,plannedHdr!=null?plannedHdr.Plant:splant, machine,machineReportViewContainer,false);                    
            bresult = true;
        }
    }catch (Exception ex){
        MessageBox.Show("automaticPlanned Exception: " + ex.Message);
    } 
    return bresult;
}

public
bool clearPlanned(string splant){
    bool bresult = false;
    try{
        MachineReportViewContainer machineReportViewContainer =  (MachineReportViewContainer)machinePartsListView.DataContext;
        if (machineReportViewContainer!= null) { 
            plannedHdr = getCoreFactory().machinePlannedClearAutomatic(plannedHdr,inventoryObjectiveHdr, plannedHdr!=null?plannedHdr.Plant:splant, machine,machineReportViewContainer);
            bresult = true;
        }
    }catch (Exception ex){
        MessageBox.Show("automaticPlanned Exception: " + ex.Message);
    } 
    return bresult;
}
 
public
bool createPlannedOtherPart(MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart,Machine machineOther){
    bool            bresult=false;
    PlannedPart     plannedPart = null;
    string          splant = capacityHdr != null ? capacityHdr.Plant : "";

    if (machineReportPartView!= null && cellMachinePart!= null && machineOther != null && this.capacityHdr!=null){
        plannedPart = getCoreFactory().generateNewPlannedPartBasedPlanned(plannedHdr,splant,machineOther.Id, machineReportPartView.Part, machineReportPartView.Seq, cellMachinePart.PlannedOther, cellMachinePart.PlannedOvertime, cellMachinePart.StartDate,true);        
        if (plannedPart != null) { 
            bresult=true;

            cellMachinePart.PlannedPartOtherContainer.Add(plannedPart);
            if (plannedHdr== null)
                plannedHdr = getCoreFactory().readPlannedHdrLast(splant);
        }
    }
    return bresult;
}

public
bool alternativeMachinePlanned(MachineReportPartView machineReportPartView, CellMachinePart cellSelected){
    bool bresult=false;
    try { 
        if (machineReportPartView!= null) { 
            string                  splant = getPlant();
            RoutingContainer        routingContainer = getCoreFactory().readRoutingByFilters(machineReportPartView.Part,splant,"", machineReportPartView.Seq, "", Routing.ROUTING_TYPE_ALTERNATIVE, false, false,0);
                        
            if (routingContainer.Count > 0){                                                                             
                MachineAlterPlanWindow window = new MachineAlterPlanWindow(plannedHdr,splant,machine, machineReportPartView, cellSelected, routingContainer);
                if ((bool)window.ShowDialog());
                    bresult = true;
            }else
                MessageBox.Show("Sorry, There Is Not Alternative Mahine For Part : " + machineReportPartView.Part +  " Seq :" + machineReportPartView.Seq.ToString() + ".");

        }

    } catch (Exception ex) {
        MessageBox.Show("alternativeMachinePlanned Exception: " + ex.Message);        
    }          

    return bresult;
}

private
void loadMAchineAlternativePlanned(MachineReportPartView machineReportPartView, RoutingContainer routingContainer){

    PlannedReq              plannedReq= null;
    PlannedPart             plannedPart = null;
    PlannedPartContainer    plannedPartContainer=null;
    bool                    breprocess = true;
    int                     i=0;
    decimal                 dqty=0;

     if (plannedHdr != null && machine != null){
        plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,machine.Id);

        if (plannedReq!= null){
            plannedPartContainer = plannedReq.PlannedPartContainer;                
                                                    
            for (i=0; i < plannedPartContainer.Count;i++)  {          
                plannedPart = plannedPartContainer[i];
                
                if (plannedPart.Part.ToUpper().Equals(machineReportPartView.Part.ToUpper())  && plannedPart.Seq == machineReportPartView.Seq) { 

                    if (plannedPart.StartDate <= dPastDue) { 
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCellPastDue,plannedPart, dPastDue.AddMonths(-1),dPastDue);                    
                    }else if (plannedPart.StartDate>= dSweek0 && plannedPart.StartDate <= dEweek0){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell0,plannedPart, dSweek0,dEweek0);                    
                    }else if (plannedPart.StartDate>= dSweek1 && plannedPart.StartDate <= dEweek1){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell1,plannedPart, dSweek1,dEweek1);
                    }else if (plannedPart.StartDate>= dSweek2 && plannedPart.StartDate <= dEweek2){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell2,plannedPart, dSweek2,dEweek2);                    
                    }else if (plannedPart.StartDate>= dSweek3 && plannedPart.StartDate <= dEweek3){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell3,plannedPart,dSweek3,dEweek3);                    
                    }else if (plannedPart.StartDate>= dSweek4 && plannedPart.StartDate <= dEweek4){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty, machineReportPartView.WeekCell4,plannedPart, dSweek4,dEweek4);
                    }else if (plannedPart.StartDate>= dSweek5 && plannedPart.StartDate <= dEweek5){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell5,plannedPart, dSweek5,dEweek5);
                    }else if (plannedPart.StartDate>= dSweek6 && plannedPart.StartDate <= dEweek6){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell6,plannedPart, dSweek6,dEweek6);                    
                    }else if (plannedPart.StartDate>= dSweek7 && plannedPart.StartDate <= dEweek7){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell7,plannedPart, dSweek7,dEweek7);                    
                    }else if (plannedPart.StartDate>= dSweek8 && plannedPart.StartDate <= dEweek8){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell8,plannedPart,dSweek8,dEweek8);                    
                    }else if (plannedPart.StartDate>= dSweek9 && plannedPart.StartDate <= dEweek9){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell9,plannedPart,dSweek9,dEweek9);                    
                    }else if (plannedPart.StartDate>= dSweek10 && plannedPart.StartDate <= dEweek10){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell10,plannedPart, dSweek10,dEweek10);                    
                    }else if (plannedPart.StartDate>= dSweek11 && plannedPart.StartDate <= dEweek11){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell11,plannedPart,dSweek11,dEweek11);                    
                    }else if (plannedPart.StartDate>= dSweek12 && plannedPart.StartDate <= dEweek12){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell12,plannedPart, dSweek12,dEweek12);                    
                    }else if (plannedPart.StartDate>= dSweek13 && plannedPart.StartDate <= dEweek13){
                        breprocess = sumCapacityPartCheckIfReprocess(out dqty,machineReportPartView.WeekCell13,plannedPart, dSweek13,dEweek13);                    
                    }

                    if (breprocess)
                        i--;
                }
            }
        }
    }
}

private
void loadMachinePartsStartWkPlannedProdRemainWkPlanned(MachineReportViewContainer machineReportViewContainer,bool bincludePlanned){
    try{ 
        MachineReportPartView   machineReportPartView = null;                                    
        int                     i=0;              
                                
        for (i=0; i < machineReportViewContainer.Count;i++)  {          
            machineReportPartView = (MachineReportPartView)machineReportViewContainer[i];
            loadMachinePartsStartWkPlannedProdRemainWkPlanned(machineReportPartView,bincludePlanned);                        
        }                   

    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsStartWkPlannedProdRemainWkPlanned Exception: " + ex.Message);        
    }
}

private
void loadMachinePartsStartWkPlannedProdRemainWkPlanned(MachineReportPartView machineReportPartView,bool bincludePlanned){
    machineReportPartView.Production = getProductionPrHistSumFromHash(hashPrHistSum, machineReportPartView.Part, machineReportPartView.Seq);

    machineReportPartView.WeekCell0.PriorWeekNet = machineReportPartView.Qoh; //we start with Qoh
    machineReportPartView.recalcNet();
    if (bincludePlanned) {       
        machineReportPartView.WeekCell0.Planned = machineReportPartView.WeekCell0.PlannedPartContainer.Count > 0 ? machineReportPartView.WeekCell0.PlannedPartContainer[0].QtyPlanned : 0;        
        machineReportPartView.StartWeekPlanned  = machineReportPartView.WeekCell0.Planned + machineReportPartView.WeekCell0.PlannedOvertime;
        machineReportPartView.RemaintWeekPlanned = machineReportPartView.StartWeekPlanned - machineReportPartView.Production;                
        
    }else{
        machineReportPartView.StartWeekPlanned = 
        machineReportPartView.RemaintWeekPlanned = 0;
    }
    machineReportPartView.WeekCell0.Planned = machineReportPartView.WeekCell0.Planned - machineReportPartView.Production;
}
      
private
PrHistSumViewContainer loadPartSeqRequired(MachineReportViewContainer machineReportViewContainer){
    PrHistSumViewContainer  prHistSumViewContainer = getCoreFactory().createPrHistSumViewContainer();
    try{         
        MachineReportPartView   machineReportPartView = null;                                    
        int                     i=0;              
                                
        for (i=0; i < machineReportViewContainer.Count;i++)  {          
            machineReportPartView = (MachineReportPartView)machineReportViewContainer[i];
            PrHistSumView  prHistSumView = getCoreFactory().createPrHistSumView();

            prHistSumView.DWPART = machineReportPartView.Part;
            prHistSumView.DWSEQN = machineReportPartView.Seq;

            prHistSumViewContainer.Add(prHistSumView);
        }                   

    } catch (Exception ex) {
        MessageBox.Show("loadPartSeqRequired Exception: " + ex.Message);        
    }
    return prHistSumViewContainer;
}                          
        
private
void refreshPlannedChanges(MachineReportViewContainer machineReportViewContainer,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart){
    try {         
        PlannedReq                  plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,machine.Id);
                
        for (int i=0; plannedReq!= null && i < machineReportViewContainer.Count;i++) { 
            MachineReportPartView   machineReportPartViewAux = (MachineReportPartView)machineReportViewContainer[i];
            CellMachinePart         cellMachinePartAux = null;
            PlannedPart             plannedPartAux = null;

            cellMachinePartAux = machineReportPartViewAux.getCellMachinePartByXIndex(cellMachinePart.XIndex);

            if (cellMachinePartAux!= null) {                  
                plannedPartAux = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(machineReportPartViewAux.Part, machineReportPartViewAux.Seq,cellMachinePartAux.StartDate);
                if (plannedPartAux!= null){
                    cellMachinePartAux.PlannedPartContainer.Clear();                                               
                    cellMachinePartAux.PlannedPartContainer.Add(plannedPartAux);
                    cellMachinePartAux.Planned = plannedPartAux.QtyPlanned;
                }                                                                                                        
                machineReportPartViewRecalcNet(machineReportPartViewAux,cellMachinePartAux);
            }                                   
        }

    } catch (Exception ex) {
        MessageBox.Show("refreshPlannedChanges Exception: " + ex.Message);        
    }
}                  
        
private
void refreshPlannedChanges(MachineReportViewContainer machineReportViewContainer){
    try {         
        PlannedReq                  plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,machine.Id);
                
        for (int i=0; plannedReq!= null && i < machineReportViewContainer.Count;i++) { 
            MachineReportPartView   machineReportPartViewAux = (MachineReportPartView)machineReportViewContainer[i];
            CellMachinePart         cellMachinePartAux = null;
            PlannedPart             plannedPartAux = null;

            for (int j=0; j < CapacityView.TITLE_COUNTS; j++) { 
                cellMachinePartAux = machineReportPartViewAux.getCellMachinePartByXIndex(j);

                if (cellMachinePartAux!= null) {                  
                    plannedPartAux = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(machineReportPartViewAux.Part, machineReportPartViewAux.Seq,cellMachinePartAux.StartDate);
                    if (plannedPartAux!= null){
                        cellMachinePartAux.PlannedPartContainer.Clear();                                               
                        cellMachinePartAux.PlannedPartContainer.Add(plannedPartAux);
                        cellMachinePartAux.Planned = plannedPartAux.QtyPlanned;

                        cellMachinePartAux.PlannedQtyChange = plannedPartAux.QtyChange;
                    }                                                                                                        
                    machineReportPartViewRecalcNet(machineReportPartViewAux,cellMachinePartAux);
                }                                   
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("refreshPlannedChanges Exception: " + ex.Message);        
    }
}               

public 
void moveQtyChange(){    
    try{                
        if (bincludePlanned && plannedHdr!= null &&
            System.Windows.Forms.MessageBox.Show("Do You Want To Move QtyMove To Quantity Planned ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){ 

            getCoreFactory().plannedMoveQtyChangeToPlanned(plannedHdr,getPlant(),machine!= null ? machine.Id:0,dSweek0);
            refreshPlannedChanges((MachineReportViewContainer)machinePartsListView.DataContext);
        }

    } catch (Exception ex) {
        MessageBox.Show("moveQtyChange Exception: " + ex.Message);        
    }
}


public 
void addOTShift(){    
    try{
        if (bincludePlanned && plannedHdr!= null) {
            MachineReportPartView       machineReportPartView = (MachineReportPartView)getSelected(machinePartsListView);                            
            string                      splant = getPlant();
            int                         imachineId = machine!= null ? machine.Id : 0;
            CapShiftProfileContainer    sumCapShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();
            PlannedPart                 plannedPart =  null;

            if (plannedHdr!= null && cellMachinePartSelected!= null && imachineId > 0){
                CapShiftProfileContainer    capShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();
                CapShiftProfile             capShiftProfile = null;                               
                CapShiftProfileMachPlan     capShiftProfileMachPlan = null;

                plannedPart = cellMachinePartSelected.PlannedPartContainer.Count > 0 ? cellMachinePartSelected.PlannedPartContainer[0] : null;

                if (plannedPart!= null) { 

                    //check if planned part already linked to ShiftProfileMachPlan record
                    if (plannedPart.ProfMachPlanHdrId > 0 && plannedPart.ProfMachPlanHdrDtl > 0){
                        capShiftProfile = getCoreFactory().readCapShiftProfile(plannedPart.ProfMachPlanHdrId);
                        if (capShiftProfile!= null)
                            capShiftProfileMachPlan = capShiftProfile.CapShiftProfileMachPlanContainer.getByKey(plannedPart.ProfMachPlanHdrId,plannedPart.ProfMachPlanHdrDtl);
                    }
                
                    if (capShiftProfileMachPlan == null ) {
                        //read capshiftprofiles for date
                        capShiftProfileContainer = getCoreFactory().readCapShiftProfilesForWeek(splant,Constants.STATUS_ACTIVE, cellMachinePartSelected.StartDate,false);
                        
                        if (capShiftProfileContainer.Count > 0){
                            capShiftProfile = capShiftProfileContainer[0];
                        }else{
                            //if there are not capshiftprofile, create based on Defaults profiles
                            sumCapShiftProfileContainer = loadSumCapShiftProfileDefaults(splant, "", Constants.STRING_YES, DateUtil.MinValue);
                            writeSumCapShiftProfileDefaults(sumCapShiftProfileContainer, cellMachinePartSelected.StartDate, cellMachinePartSelected.EndDate);

                            if (sumCapShiftProfileContainer.Count > 0)
                                capShiftProfile = sumCapShiftProfileContainer[0];
                        }

                        if (capShiftProfile!= null){
                                                
                            if (sumCapShiftProfileContainer.Count > 0)
                                capShiftProfileMachPlan = sumCapShiftProfileContainer.getByMachPlanByFirstMachine(imachineId);                    
                            else
                                capShiftProfileMachPlan = capShiftProfile.CapShiftProfileMachPlanContainer.getByFirstMachine(imachineId);                    
                        
                            if (capShiftProfileMachPlan == null){
                                capShiftProfileMachPlan = getCoreFactory().createCapShiftProfileMachPlan();
                                capShiftProfileMachPlan.MachId = imachineId;
                                capShiftProfileMachPlan.Date = cellMachinePartSelected.StartDate.AddDays(5); //saturday by default

                                capShiftProfile.CapShiftProfileMachPlanContainer.Add(capShiftProfileMachPlan);
                                save(capShiftProfile);                        
                            }

                            if (plannedPart!= null && capShiftProfileMachPlan!=null) { 
                                plannedPart.ProfMachPlanHdrId = capShiftProfileMachPlan.HdrId;
                                plannedPart.ProfMachPlanHdrDtl = capShiftProfileMachPlan.Detail;
                                getCoreFactory().updatePlannedPart(plannedHdr, plannedPart);
                            }
                        }
                    }
                    CapShiftProfileWindow capShiftProfileWindow = new CapShiftProfileWindow(plannedHdr,plannedPart);
                    capShiftProfileWindow.ShowDialog();

                    loadCapacityByShifts(machineShiftListView,splant,0,CapacityViewContainer,hashPrHistSum,true);
                }else{
                    MessageBox.Show("Sorry, Please Entry Quantity Planned Before Add Overtime Day.");
                }
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("addOTShift Exception: " + ex.Message);        
    }
}


public
CapShiftProfileContainer loadSumCapShiftProfileDefaults(string splant,string status,string shiftDefault,DateTime startDate){
    CapShiftProfile             capShiftProfile= null;
    CapShiftProfileContainer    sumCapShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();

    for (int i=1; i <= Constants.MAX_SHIFTS; i++) { 

        CapShiftProfileContainer capShiftProfileContainer = getCoreFactory().readCapShiftProfileByFilters("",splant,i,status,DateUtil.MinValue,DateUtil.MinValue,-1,shiftDefault, false,1);  
                             
        if (capShiftProfileContainer.Count > 0){            
            capShiftProfile = capShiftProfileContainer[0];
            capShiftProfile.fillRedundances();
            sumCapShiftProfileContainer.Add(capShiftProfile);                                                            
        }        
    }
    return sumCapShiftProfileContainer;
}

private
void writeSumCapShiftProfileDefaults(CapShiftProfileContainer sumCapShiftProfileContainer,DateTime startDate,DateTime endDate){
    CapShiftProfile capShiftProfile= null;
    
    for (int i=0; i < sumCapShiftProfileContainer.Count; i++) { 
        capShiftProfile = sumCapShiftProfileContainer[i];

        capShiftProfile.Id =0;                              //insert new one
        capShiftProfile.StartDate = startDate;
        capShiftProfile.EndDate = endDate;
        capShiftProfile.ShiftDefault = Constants.STRING_NO; //set no default
        checkIfAnyHoliday(capShiftProfile);                 //check holidays
        save(capShiftProfile);          
    } 
}

public
void save(CapShiftProfile capShiftProfile){
    try{
        if (capShiftProfile.Id > 0)
            getCoreFactory().updateCapShiftProfile(capShiftProfile);
        else
            getCoreFactory().writeCapShiftProfile(capShiftProfile);

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}

public
MachineContainer processAutoPlanForDept(string splant,string sdept){            
    MachineContainer    machineContainer = getCoreFactory().createMachineContainer();
    try{                
        machineContainer = getCoreFactory().readMachinesByFilters("","",splant,sdept,"",false,0);        
        MachineReportViewContainer   machineReportViewContainer = getCoreFactory().createMachineReportViewContainer();
                
        for (int i=0; i < machineContainer.Count; i++){
            machine = machineContainer[i];
            machineReportViewContainer = processAutoPlanForMachine(machine,splant,sdept);     
        }        
               
    } catch (Exception ex) {
        MessageBox.Show("processAutoPlanForDept Exception: " + ex.Message);        
    }
    return machineContainer;
}

public
MachineContainer processAutoPlanForMachines(ArrayList arrayMachines){            
    MachineContainer    machineContainer = getCoreFactory().createMachineContainer();
    try{                        
        MachineReportViewContainer   machineReportViewContainer = getCoreFactory().createMachineReportViewContainer();
                
        for (int i=0; i < arrayMachines.Count; i++){
            machine = (Machine)arrayMachines[i];
            machineReportViewContainer = processAutoPlanForMachine(machine,machine.Plt,machine.Dept);     

            machineContainer.Add(machine);
        }        
               
    } catch (Exception ex) {
        MessageBox.Show("processAutoPlanForMachines Exception: " + ex.Message);        
    }
    return machineContainer;
}

public
MachineReportViewContainer processAutoPlanForMachine(Machine machine,string splant,string sdept){            
    MachineReportViewContainer   machineReportViewContainer = getCoreFactory().createMachineReportViewContainer();
    try{
        cursorWait();
        
        this.machine = machine;
        bool                bincludeZeroQty     =false;
        bool                bincludeProduction  = false;
        string              smachine            ="";
        string              spart               ="";
        DateTime            dateWeek            =DateUtil.MinValue;        
        RoutingContainer    routingContainer    = getCoreFactory().createRoutingContainer();       

        capacityHdr             = getCoreFactory().readCapacityHdrLastDateCheck(capacityHdr,splant);
        plannedHdr              = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);
        inventoryObjectiveHdr   = getCoreFactory().readInventoryObjectiveHdrLastDateCheck(inventoryObjectiveHdr,splant); 

        realodWeeksRanges();
        
        routingContainer = getCoreFactory().getBuildByFilters("","",-1,machine.Id,true,false);//read all routins for machine
         
        loadMachinePartsHotList(machineReportViewContainer,machine,capacityHdr,splant, sdept, "", "",DateUtil.MinValue,bincludeZeroQty);
        if (bincludePlanned) { 
            loadMachinePartsPlanned(machineReportViewContainer,machine,plannedHdr, splant, sdept, smachine, spart, dateWeek);
            loadMachinePartsPlannedOther(machineReportViewContainer,machine,plannedHdr, splant, sdept, smachine, spart, dateWeek);            
        }
        loadMachinePartsInventoryObjectives(machineReportViewContainer,machine,inventoryObjectiveHdr, splant, sdept, smachine, spart, dateWeek);
        loadMachinePartsNet(machineReportViewContainer,routingContainer);

        //production            
        if (bincludeProduction)
            this.getProductionPrHistSum(ref hashPrHistSum, ref prHistDateTimeChecked, "", -1,getPlant(),dSweek0, dEweek0, loadPartSeqRequired(machineReportViewContainer));//check production
            
        loadMachinePartsStartWkPlannedProdRemainWkPlanned(machineReportViewContainer,bincludePlanned);

        plannedHdr = getCoreFactory().machinePlannedFillFullAutomatic(plannedHdr,inventoryObjectiveHdr,plannedHdr!=null?plannedHdr.Plant:splant, machine,machineReportViewContainer,false);                    
                              
    } catch (Exception ex) {
        MessageBox.Show("processAutoPlanForMachine Exception: " + ex.Message);        
    }finally{
        cursorNormal();
    }
    return machineReportViewContainer;
}


}
}
