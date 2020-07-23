using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HotListReports.Reports;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core;
using HotListReports.Windows;
using Nujit.NujitWms.WinForms.Custom.Markdom.Concord;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using HotListReports.Windows.Demand;
using HotListReports.Windows.Products;
using HotListReports.Windows.Machines;
using HotListReports.Windows.Transfer;
using HotListReports.Windows.HotLists;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Labour;
using HotListReports.Windows.Inventories;
using HotListReports.Windows.ShiftProfile;
using HotListReports.Windows.Location;
using HotListReports.Windows.Employees;
using HotListReports.Windows.EmployeeSchedule;
using HotListReports.Windows.Customers;


namespace HotListReports{
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application{

public static User UserLogged;

private
void AppStart(object sender, StartupEventArgs e){
    System.Windows.Forms.Application.EnableVisualStyles();
    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
    Nujit.NujitERP.ClassLib.Common.Configuration.OnApplicationStart();

    //if (Nujit.NujitERP.ClassLib.Common.Configuration.UserLogged != null)
        //MessageBox.Show("Employee:" + Nujit.NujitERP.ClassLib.Common.Configuration.UserLogged.getUserID());
    if (e.Args.Length > 1)
        processArgs(e.Args);
}

private 
void Application_Exit(object sender,ExitEventArgs e) {    
    Environment.Exit(0);
}

private 
void processArgs(string[] args ){    
    string stype        = args.Length > 0 ? args[0]  :"";
    string sreportType  = args.Length > 1 ? args[1]  :"";
    string suser        = args.Length > 2 ? args[2]  :"3";
            
    loadUser(suser);
    //for (int i=0; i < args.Length;i++ )
        //MessageBox.Show(args[i]);

    if (!string.IsNullOrEmpty(stype)){
        switch(stype.ToUpper()){
            case "-R":
                switch(sreportType.ToUpper()){
                    case "1268":
                        hotList1268();
                        break;
                    case "1268-3":
                        hotList1268_3();
                        break;  
                    case "1268-ST":
                        hotList1268Stored();
                        break;                                                
                    default:
                        break;
                }
                break;                                 
            case  "-S":
                switch (sreportType){
                    case "1268":
                        storeReport1268();
                        break;             
                    case "LastEdiDocs":
                        lastEdiDocs();
                        break;      
                    case "ShipExport":
                        shipExport();
                        break;                                                                     
                    default:
                        break;
                }
                break;
            case  "-W":
                switch (sreportType){
                    case "MainMat":
                        mainMaterial();
                        break;             
                    case "OEE":                                       
                        oee();
                        break;      
                    case "Bol":                                       
                        bol();
                        break;    
                    case "Demand":                                                                     
                        demand();
                        break;    
                    case "DemandCompare":                                                                     
                        demandCompare();
                        break;    
                    case "Capacity":
                        capacity();
                        break;   
                    case "Schedule":
                        schedule();
                        break;         
                    case "ShiftProfile":
                        shiftProfile();
                        break;                                                               
                    case "ShiftTask":
                        shiftTask();
                        break;     
                    case "Product":
                        product();
                        break; 
                    case "Machine":
                        machine();
                        break;        
                    case "Transfer":
                        transfer();
                        break;                           
                                                                                    
                    case "Routing":
                        routing();
                        break; 
                    case "LabourType":
                        labourType();
                        break;        
                    case "Tool":
                        tool();
                        break;
                                
                    case "HotList":
                        hotList();
                        break;            

                    case "Labour":
                        labour();
                        break;             
                    case "InvObjectives":                     
                        invObjectives();
                        break;        
                    case "Holiday":
                        holiday();
                        break;
                    case "Depts":
                        depts();
                        break;
                    case "Employs":
                        employees();
                        break;
                    case "EmploysAssign":
                        employeeAssignRpt();
                        break;
                    case "MachsAssign":
                        machAssignRpt();
                        break;
                    case "Customer":
                        customer();
                        break;
                    default:
                        break;
                }
                break;

            case  "-P":
                switch (sreportType){
                    case "Demand":                       
                        process830862(args);
                        break;                                     
                    case "DemTransform":
                        demTransform();
                        break;   
                    case "ImportItemInv":
                        importItemInv();
                        break;                                                                                                                                                                                               
                    default:
                        break;
                }
                break;
            default:
                break;                    
        }
    }
    
    if (!string.IsNullOrEmpty(stype))
        Environment.Exit(0);
}

private
void loadUser(string suser){
    CoreFactory coreFactory = null;
    try {                 
        if (NumberUtil.isIntegerNumber(suser.Trim())) {            
            coreFactory = UtilCoreFactory.createCoreFactory();
            UserLogged = coreFactory.readUser(Convert.ToInt32(suser.Trim()));                        
        }

    }catch (Exception ex){
        MessageBox.Show("App loadUser : " + ex.Message);
    }finally{
        if (coreFactory != null)
            coreFactory = null;	    
    }
}

private 
void hotList1268() {
    try{
        ShowReport showReport = new ShowReport();
        showReport.hotList1268();
    }catch (Exception ex){
        MessageBox.Show("Exception Report 1268: " + ex.Message);
    }
}

private 
void hotList1268_3() {
    try{
        ShowReport showReport = new ShowReport();
        showReport.hotList1268_3();
    }catch (Exception ex){
        MessageBox.Show("Exception Report 1268: " + ex.Message);
    }
}

private 
void hotList1268Stored() {
    try{
        ShowReport showReport = new ShowReport();
        showReport.hotList1268Stored();
    }catch (Exception ex){
        MessageBox.Show("Exception Report 1268: " + ex.Message);
    }
}


private 
void storeReport1268() {
    try{
        ArrayList alist = null;
        
        CoreFactory core = UtilCoreFactory.createCoreFactory();
        core.runStoreReport1268(out alist);

    }catch (Exception ex){
        MessageBox.Show("Exception Report 1268: " + ex.Message);
    }
}

private
void mainMaterial(){
    try{
        MainMatWindow mainMatWindow = new MainMatWindow();
        mainMatWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("MainMaterial Window Exception: " + ex.Message);
    }
}

private
void bol(){
    try{
        BolWindow bolWindow = new BolWindow();
        bolWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("BOL Window Exception: " + ex.Message);
    }
}
       
public
void oee(){
    try {        
        Nujit.NujitWms.ClassLib.Common.Configuration.OnApplicationStart();        
        BatchReportWindow batchReportWindow = new BatchReportWindow();
        batchReportWindow.ShowDialog();
        
    }catch (Exception ex){
        MessageBox.Show("OEE Exception: " + ex.Message);  
    }
}    

private
void process830862(string[] args){        
    try{
        CoreFactory core    = UtilCoreFactory.createCoreFactory();
        string      sfromDate   = args.Length > 2 ? args[2] : "";
        string      stoDate     = args.Length > 3 ? args[3] : "";
        DateTime    fromDate= DateTime.Now.AddDays(-7);
        DateTime    toDate  = new DateTime(2099,12,31);
        string      splant="";

        if (!string.IsNullOrEmpty(sfromDate))
            fromDate = DateUtil.parseDate(sfromDate, DateUtil.MMDDYYYY);
        if (!string.IsNullOrEmpty(stoDate))
            toDate  = DateUtil.parseDate(stoDate, DateUtil.MMDDYYYY);

        MessageBox.Show("fromDate:" + DateUtil.getDateRepresentation(fromDate,DateUtil.MMDDYYYY) + "\n" +
                        "toDate:"   + DateUtil.getDateRepresentation(toDate, DateUtil.MMDDYYYY));

        core.processDemand830862ByDate(splant,fromDate, toDate,false,true);

        MessageBox.Show("End process830862");

    }catch (Exception ex){
       MessageBox.Show("Process 830/862 Exception: " + ex.Message);  
    }    
}

private
void demand(){
    try{
        DemandWindow demandWindow = new DemandWindow();
        demandWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("Demand Window Exception: " + ex.Message);
    }
}

private
void demandCompare(){
    try{
        DemandCompareWindow window = new DemandCompareWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("Demand Compare Window Exception: " + ex.Message);
    }
}

private
void capacity(){
    try{
        CapacityHdrWindow capacityHdrWindow = new CapacityHdrWindow();
        capacityHdrWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("capacity Window Exception: " + ex.Message);
    }
}

private
void schedule(){
    try{
        ScheduleHdWindow scheduleHdWindow = new ScheduleHdWindow();
        scheduleHdWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("schedule Window Exception: " + ex.Message);
    }
}

private
void shiftProfile(){
    try{
        CapShiftProfileWindow capShiftProfileWindow = new CapShiftProfileWindow();
        capShiftProfileWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("shiftProfile Window Exception: " + ex.Message);
    }
}

private
void shiftTask(){
    try{
        CapShiftTaskWindow capShiftTaskWindow = new CapShiftTaskWindow(false);
        capShiftTaskWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("shiftTask Window Exception: " + ex.Message);
    }
}

private
void product(){
    try{
        ProductWindow productWindow = new ProductWindow(false);
        productWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("product Window Exception: " + ex.Message);
    }
}

private
void machine(){
    try{
        MachineWindow machineWindow = new MachineWindow(false,"");
        machineWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("machine Window Exception: " + ex.Message);
    }
}
        
private
void transfer(){
    try{
        DataTransferWindow dataTransferWindow = new DataTransferWindow();
        dataTransferWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("transfer Window Exception: " + ex.Message);
    }
}         
             
private
void demTransform(){
    try{
        CoreFactory core    = UtilCoreFactory.createCoreFactory();

        DemandH demandH = core.readDemandH(22);

        MessageBox.Show("Demand Dump:" + demandH.DemandDContainer.Count);

        DemTransformOptions demTransformOptions = core.createDemTransformOptions();
        demTransformOptions.DemandH = demandH;
        DemTransformH demTransformH  = core.processDemandTransform(demTransformOptions);

        MessageBox.Show("Total Demand:\n\n" +
                        "Demand Dump:" + demandH.DemandDContainer.Count +  "\n" +
                        "Demand Transform:" + demTransformH.DemTransformDContainer.Count);

    }catch (Exception ex){
        MessageBox.Show("Demand Window Exception: " + ex.Message);
    }
}

private
void importItemInv(){
    try{
        CoreFactory         core            = UtilCoreFactory.createCoreFactory();
        PlantContainer      plantContainer  = core.readAllPlants();

        foreach(Plant plant in plantContainer)
            core.generateCMSItems(plant.getPlt(), false);
        core.generateCMSInventory2();

    }catch (Exception ex){
       MessageBox.Show("importItemInv Exception: " + ex.Message);
    }
}

private
void routing(){
    try{
        RoutingWindow routingWindow = new RoutingWindow(false,Configuration.DftPlant,null);
        routingWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("routing Window Exception: " + ex.Message);
    }
}   

private
void labourType(){
    try{
      //  LabourTypeWindow labourTypeWindow = new LabourTypeWindow();
//        labourTypeWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("labourType Window Exception: " + ex.Message);
    }
}   

private
void tool(){
    try{
        ToolWindow toolWindow = new ToolWindow();
        toolWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("tool Window Exception: " + ex.Message);
    }
} 

private
void hotList(){
    try{
        HotListWindow hotListWindow = new HotListWindow();
        hotListWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("hotList Window Exception: " + ex.Message);
    }
} 

private
void labour(){
    try{
        LabourViewsWindow window = new LabourViewsWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("labour Window Exception: " + ex.Message);
    }
} 

private
void invObjectives(){
    try{
        InventoryObjectivesWindow window = new InventoryObjectivesWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("invObjectives Window Exception: " + ex.Message);
    }
}

private
void holiday(){
    try{
        CapProfileHolidayWindow window = new CapProfileHolidayWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("holiday Window Exception: " + ex.Message);
    }
}

private
void depts(){
    try{
        DepartmentWindow window = new DepartmentWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("depts Window Exception: " + ex.Message);
    }
}

private
void employees(){
    try{
        EmployeeWindow window = new EmployeeWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("employees Window Exception: " + ex.Message);
    }
}

private
void employeeAssignRpt(){
    try{
        EmployeeSheduleRptWindow window = new EmployeeSheduleRptWindow();       
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("employeeAssignRpt Window Exception: " + ex.Message);
    }
}

private
void machAssignRpt(){
    try{
        MachineScheduleRptWindow window = new MachineScheduleRptWindow();       
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("machAssignRpt Window Exception: " + ex.Message);
    }
}

private
void customer(){
    try{
        CustomerWindow window = new CustomerWindow();       
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("customer Window Exception: " + ex.Message);
    }
}

private
void lastEdiDocs(){
    try{
        CoreFactory core = UtilCoreFactory.createCoreFactory();

        EdiTransTPContainer ediTransTPContainer = core.createEdiTransTPartnerAutomatic();
        //core.justTestDemandDay();

        //MessageBox.Show("lastEdiDocs:" + ediTransTPContainer.Count);

    }catch (Exception ex){
        MessageBox.Show("lastEdiDocs Exception: " + ex.Message);
    }
}

private
void shipExport(){
  try {                
        CoreFactory core = UtilCoreFactory.createCoreFactory();
        ShipExportContainer shipExportContainer = core.processShipExportAutomatically("");
                                
    } catch (Exception ex) {
        MessageBox.Show("shipExport Exception: " + ex.Message);        
    }finally{        
    }
}

}
}
