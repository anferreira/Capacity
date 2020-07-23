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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotListReports.Reports;
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;
using HotListReports.Windows;
using HotListReports.Windows.Demand;
using HotListReports.Windows.Products;
using HotListReports.Windows.Transfer;
using HotListReports.Windows.Machines;
using HotListReports.Windows.HotLists;
using HotListReports.Windows.Boms;
using HotListReports.Windows.Labour;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Inventories;
using HotListReports.Windows.ShiftProfile;
using HotListReports.Windows.Location;
using HotListReports.Windows.Employees;
using HotListReports.Windows.EmployeeSchedule;
using HotListReports.Windows.Customers;


namespace HotListReports{
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial 
class MainWindow : Window{

public MainWindow(){
    InitializeComponent();

    this.Closing+= Window_Closing;

    mainMenu.Visibility = Visibility.Hidden;
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    Environment.Exit(0);
}

private 
void hotList1268MenuITem_Click(object sender, System.Windows.RoutedEventArgs e) {
    hotList1268Stored();
}

private 
void hotList1268() {
    try{
        /*
        HotList1268RptWindow hotList1268RptWindow = new HotList1268RptWindow();
        hotList1268RptWindow.ShowDialog();
        */

        
        ShowReport showReport = new ShowReport();
        //showReport.hotList1268_3();
        showReport.hotList1268Try();

        /*
        CoreFactory core= UtilCoreFactory.createCoreFactory();
        ArrayList alist=null;
        core.runStoreReport1268(out alist);
        */

    }catch (Exception ex){
        MessageBox.Show("Exception initialize: " + ex.Message);
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
void mainMaterialMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    mainMaterial();
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
void demandMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     demand();
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
void compareDemandMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     compareDemand();
}                    

private
void compareDemand(){
    try{
        DemandCompareWindow window = new DemandCompareWindow();
        window.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("compareDemand Exception: " + ex.Message);
    }
} 

private
void capacityMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     capacity();
}   

private
void capacity(){
    try{
        CapacityHdrWindow capacityHdrWindow = new CapacityHdrWindow();
        capacityHdrWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("Capacity Window Exception: " + ex.Message);
    }
}

private
void capacityShiftTaskMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     capacityShiftTask();
}   

private
void capacityShiftTask(){
    try{
        CapShiftTaskWindow capShiftTaskWindow = new CapShiftTaskWindow(false);
        capShiftTaskWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("Capacity Window Exception: " + ex.Message);
    }
}

private
void capacityShiftProfileMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     capacityShiftProfile();
}   

private
void capacityShiftProfile(){
    try{
        CapShiftProfileWindow capShiftProfileWindow = new CapShiftProfileWindow();
        capShiftProfileWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("Capacity Window Exception: " + ex.Message);
    }
}

private
void scheduleMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     schedule();
}   

private
void schedule(){
    try{
        ScheduleHdWindow scheduleHdrWindow = new ScheduleHdWindow();
        scheduleHdrWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("schedule Window Exception: " + ex.Message);
    }
}

private
void productMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     product();
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
void dataTransferMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     dataTransfer();
}   

private
void dataTransfer(){
    try{
        DataTransferWindow dataTransferWindow = new DataTransferWindow();
        dataTransferWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("dataTransfer Window Exception: " + ex.Message);
    }
}

private
void routingMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     routing();
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
void labourTypeMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     labourType();
}  

private
void labourType(){
    try{
        //LabourTypeWindow labourTypeWindow = new LabourTypeWindow();
        //labourTypeWindow.ShowDialog();

    }catch (Exception ex){
        MessageBox.Show("labourType Window Exception: " + ex.Message);
    }
}

private
void toolMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     tool();
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
void machineMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
     machine();
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
void hotListMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    hotList();
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
void bomMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    bom();
}  

private
void bom(){
    try{
        //BomWindow bomWindow = new BomWindow("CB-AMX30-4", 20,"");
        BomWindow bomWindow = new BomWindow("CC1809XL", 20,"");               
        bomWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("bom Window Exception: " + ex.Message);
    }
}


private
void machineViewsMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    machineViews();
}  

private
void machineViews(){
    try{
        MachineViewsWindow window = new MachineViewsWindow(null);
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("machineViews Window Exception: " + ex.Message);
    }
}


private
void labourMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    labourViews();
}  

private
void labourViews(){
    try{
        LabourViewsWindow window = new LabourViewsWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("labourViews Window Exception: " + ex.Message);
    }
}

private
void inventoryObjMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    inventoryObj();
}  

private
void inventoryObj(){
    try{
        InventoryObjectivesWindow window = new InventoryObjectivesWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("inventoryObj Window Exception: " + ex.Message);
    }
}

private
void capProfileHolidayMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    profileHoliday();
}  

private
void profileHoliday(){
    try{
        CapProfileHolidayWindow window = new CapProfileHolidayWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("profileHoliday Window Exception: " + ex.Message);
    }
}

private
void deptsMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    depts();
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
void employeeMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    employee();
}  

private
void employee(){
    try{
        EmployeeWindow window = new EmployeeWindow();
        //HotListReports.Windows.Labour.LTestWindow window = new HotListReports.Windows.Labour.LTestWindow();
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("employee Window Exception: " + ex.Message);
    }
}

private
void employeeScheduleMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    employeeSheduleRpt();
} 

private
void employeeSheduleRpt(){
    try{
        EmployeeSheduleRptWindow window = new EmployeeSheduleRptWindow();       
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("employeeSheduleRpt Window Exception: " + ex.Message);
    }
}

private
void machScheduleMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    machEmployeeSheduleRpt();
} 

private
void machEmployeeSheduleRpt(){
    try{
        MachineScheduleRptWindow window = new MachineScheduleRptWindow();       
        window.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("machEmployeeSheduleRpt Window Exception: " + ex.Message);
    }
}

private
void customerMenuITem_Click(object sender, System.Windows.RoutedEventArgs e){
    customer();
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





}
}
