using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nujit.NujitERP.ClassLib.Core;
using System.Windows.Controls;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using Nujit.NujitERP.ClassLib.Util;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Products;
using HotListReports.Windows.Machines;
using HotListReports.Windows.Demand;
using HotListReports.Windows.Employees;
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.Core.Cms;
using System.Windows.Media.Imaging;
using System.IO;
using HotListReports.Windows.Customers;


namespace HotListReports.Windows.Util{
class BaseModel2 : IDisposable{

protected   CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
protected   Cursor cursor;
private     ArrayList arrayListButtonsListView;
private     ArrayList arrayListContextMenuListViewFunctions;
protected   Window window;

private DateTime processStartDate;
private DateTime processEndDate;
private Stack<Cursor> stackCursor;

public BaseModel2(Window window){    
    this.window = window;
    this.window.Closing += Window_Closing;
    this.cursor  = window.Cursor;
    this.arrayListButtonsListView = new ArrayList();    
    this.arrayListContextMenuListViewFunctions = new ArrayList();

    processStartDate = processEndDate = DateTime.Now;
    stackCursor = new Stack<Cursor>();

    addFunnelTitle();
}

public BaseModel2(CoreFactory coreFactory,Window window){
    this.window = window;
    this.window.Closing += Window_Closing;
    this.coreFactory = coreFactory;
    this.cursor  = window.Cursor;     

    processStartDate = processEndDate = DateTime.Now;
    addFunnelTitle();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    this.Dispose();        
}
        
public 
void Dispose() {
    //MessageBox.Show("Dispose");
	if (coreFactory != null)
        coreFactory = null;	
}

~BaseModel2(){
    //MessageBox.Show("~BaseModel2");
   if (coreFactory!=null)
        coreFactory=null;
}

public
CoreFactory getCoreFactory(){
    return coreFactory;
}

public
void addFunnelTitle(){    
    if (window.Title.IndexOf(Constants.FUNNEL_TITLE) < 0)
        window.Title = Constants.FUNNEL_TITLE + " - " + window.Title;
}

public
Cursor Cursor {
	get { return cursor; }
	set { if (this.cursor != value){
			this.cursor = value;			
		}
	}
}

private
void overrideCursor(Cursor changeToCursor) {
    stackCursor.Push(changeToCursor);
    if (Mouse.OverrideCursor != changeToCursor)
        Mouse.OverrideCursor = changeToCursor;
}

public 
void disposeCursor() {
    stackCursor.Pop();
    Cursor cursor = stackCursor.Count > 0 ? stackCursor.Peek() : null;
    if (cursor != Mouse.OverrideCursor)
        Mouse.OverrideCursor = cursor;
}

public
void cursorWait(){    
    try {     
         Mouse.OverrideCursor = Cursors.Wait;
    } catch (Exception ex) {
        MessageBox.Show("cursorWait Exception: " + ex.Message);        
    }
}

public
void cursorNormal(){
    try {     
        Mouse.OverrideCursor = Cursors.Arrow;
    } catch (Exception ex) {
        MessageBox.Show("cursorNormal Exception: " + ex.Message);        
    }
}

public
void validQtyBiggerZero(ref bool bresult,TextBox textBox, string smess,decimal dvalue){    
    if (dvalue <= 0){
        bresult=false;
        MessageBox.Show("Please, Select " + smess + ".");
        textBox.Focus();
    }
}    

public
void validDate(ref bool bresult, DatePicker datePicker, string smess,DateTime date){    
    if (date < DateTime.Now.AddYears(-50)){
        bresult=false;
        MessageBox.Show("Please, Select " + smess + ".");
        datePicker.Focus();
    }
}    
      
public
Object getSelected(ListView listView){
    Object obj = null;
    if (listView.SelectedItems.Count > 0)
        obj = listView.SelectedItems[listView.SelectedItems.Count - 1];
    return obj;
}

public
string getSearchFromComboBoxString(ComboBox comboBox,TextBox txtBox,int index){
    string saux = comboBox.SelectedIndex == index ? txtBox.Text : "";
    if (!string.IsNullOrEmpty(saux))
       saux+= "%";                
    return saux;
}

public
int getSearchFromComboBoxInt(ComboBox comboBox,TextBox txtBox,int index){
    string  saux = comboBox.SelectedIndex == index ? txtBox.Text : "";
    int     iaux = 0;        
        
    if (NumberUtil.isIntegerNumber(saux))
        iaux = int.Parse(saux);
       
    return iaux;
}

public
Object getSelectedComboBoxItem(ComboBox comboBox){
    Object obj = null;
    if (comboBox.SelectedItem!= null)
        obj = ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)comboBox.SelectedItem).Content;
    return obj;
}

public
ArrayList getSelecteds(ListView listView){
    ArrayList    arrayList = new ArrayList();
                                
    foreach(Object obj in listView.SelectedItems)
        arrayList.Add(obj);    
    return arrayList;
}

public
string getSelectedComboBoxItemString(ComboBox comboBox){
    string sresult = comboBox.SelectedItem != null? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)comboBox.SelectedItem).Content.ToString() : "";
    return sresult;
}

public
int getSelectedComboBoxItemStringToInt(ComboBox comboBox){
    int    ivalue = 0;      
    try {
        string svalue = getSelectedComboBoxItemString(comboBox);         
        
        if (NumberUtil.isIntegerNumber(svalue))
            ivalue = Convert.ToInt32(svalue);

    } catch (Exception ex) {
        MessageBox.Show("getSelectedComboBoxItemStringToInt Exception: " + ex.Message);        
    }
    return ivalue;
}

public
DateTime getSelectedDateTime(DatePicker datePicker){
    return datePicker.SelectedDate != null ? (DateTime)datePicker.SelectedDate : DateUtil.MinValue;
}

public
void loadStatusComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Active", "A"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Inactive", "I"));     
                               
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadStatusComboBox Exception: " + ex.Message);        
    }
}

public
void loadBillToShipToComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Bill To",Person.CUSTOMER_TYPE_BILLTO));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Ship To",Person.CUSTOMER_TYPE_SHIPTO)); 
                  
        setDataContextCombo(comboBox,list);                                     

    } catch (Exception ex) {
        MessageBox.Show("loadBillToShipToComboBox Exception: " + ex.Message);        
    }
}


public
void loadCombo(ComboBox comboBox,string svalue1,string svalue2="",string svalue3="",string svalue4="",string svalue5="", string svalue6 = "")
        {
    comboBox.Items.Add(svalue1);

    if (!string.IsNullOrEmpty(svalue2)) 
        comboBox.Items.Add(svalue2);
    if (!string.IsNullOrEmpty(svalue3)) 
        comboBox.Items.Add(svalue3);
    if (!string.IsNullOrEmpty(svalue4)) 
        comboBox.Items.Add(svalue4);
    if (!string.IsNullOrEmpty(svalue5)) 
        comboBox.Items.Add(svalue5);
     if (!string.IsNullOrEmpty(svalue6)) 
        comboBox.Items.Add(svalue6);
               
    if (comboBox.Items.Count > 0)
        comboBox.SelectedIndex=0;
}

public
void loadTypePartComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Part","P"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Mat","M"));                
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadTypePartComboBox Exception: " + ex.Message);        
    }
}
        
public
void loadYesNoComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.STRING_YES,Constants.STRING_YES));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.STRING_NO,Constants.STRING_NO));      
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadYesNoComboBox Exception: " + ex.Message);        
    }
}

public
void loadFamilyPartComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("P","P"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("F","F"));
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadFamilyPartComboBox Exception: " + ex.Message);        
    }
}

public
void loadShiftNumComboBox(ComboBox comboBox,int imaxShift,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)                    
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        for (int i=1; i <= imaxShift;i++)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(i.ToString(), i.ToString()));
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadShiftNumComboBox Exception: " + ex.Message);        
    }
}

public
void loadDemandSourceCombo(ComboBox comboBox,bool bshowAll=true,bool bshowOrder=true) {
    try{
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        
        if (bshowAll)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(DemandD.SOURCE_830,  DemandD.SOURCE_830));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(DemandD.SOURCE_862,  DemandD.SOURCE_862));
        if (bshowOrder)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(DemandD.SOURCE_ORDER,DemandD.SOURCE_ORDER));   
                
        setDataContextCombo(comboBox, list);
        
    } catch (Exception ex) {       
         MessageBox.Show("loadSourceCombo Exception: " + ex.Message);     
    }
}

public
void loadCustomerComboBox(ComboBox comboBox,bool ball,string scustType){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        PersonContainer     personContainer = getCoreFactory().readPersonsByFilters("","",Person.TYPE_CUSTOMER, scustType,"","","","","",0);

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        foreach(Person person in personContainer) { 
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(person.Id,person.Id));
        }                  
        setDataContextCombo(comboBox,list);                                     

    } catch (Exception ex) {
        MessageBox.Show("loadCustomerComboBox Exception: " + ex.Message);        
    }
}

public
int getRecords(TextBox recordsTextBox){
    recordsTextBox.TextAlignment = TextAlignment.Right;
    int irows = NumberUtil.isIntegerNumber(recordsTextBox.Text) ? Convert.ToInt32(recordsTextBox.Text) : Configuration.SearchDefaultMaxRecordsInt;
    recordsTextBox.Text = irows.ToString();
    return irows;
}

public
Object deleltedSelected(ListView listView){    
    try{            
        Object  obj = getSelected(listView);

        if (obj != null){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete Item Selected ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
               return obj;
            }
        }else
            MessageBox.Show("Please, Select Item First.");        
            
    }catch (Exception ex){
        MessageBox.Show("deleltedSelected Exception: " + ex.Message);
    }   
    return null;                                
}          

public
ArrayList deleltedSelecteds(ListView listView){    
    ArrayList arrayList = new ArrayList();
    try{            
        arrayList = getSelecteds(listView);

        if (arrayList.Count > 0){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete "  + arrayList.Count.ToString() + " Item/s Selected ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
               return arrayList;
            }
        }else
            MessageBox.Show("Please, Select Item/s First.");        
        
        arrayList.Clear();    

    }catch (Exception ex){
        MessageBox.Show("deleltedSelecteds Exception: " + ex.Message);
    }   
    return arrayList;                                
} 

public
bool setSelectedComboBoxItem(ComboBox comboBox,Object obj){
    bool bresult=false;
    int index=0;
    
    if (obj!= null){
        for(int i=0; i < comboBox.Items.Count && !bresult; i++){
            Object objCurr = (Object)((Nujit.NujitWms.WinForms.Util.ComboBoxItem)comboBox.Items[i]).Content;        
            if (objCurr != null && objCurr.Equals(obj)) {                   
                comboBox.SelectedIndex=index;
                bresult=true;
            } 
            index++;                
        }  
    }
    return bresult;
}

public
bool setSelected(ListView listView,Object obj){
    bool bresult=false;
    int index=0;
    
    if (obj!= null){
        for(int i=0; i < listView.Items.Count && !bresult; i++){
            Object objCurr = (Object)listView.Items[i];        
            if (objCurr != null && objCurr.Equals(obj)) {                   
                listView.SelectedIndex=index;
                listView.ScrollIntoView(obj);
                bresult=true;
            } 
            index++;                
        }  
        if (bresult)
            listView.Focus();
    }
    return bresult;
}

public
bool getValidNumericFromAlpha(TextBox textBox,string stitle){
    bool bresult = true;
    
    if (string.IsNullOrEmpty(textBox.Text)){
        MessageBox.Show("Please, Entry " + stitle + " Value.");   
        textBox.Focus();
         bresult = false;
    }else if (!NumberUtil.isDecimalNumber(textBox.Text)){  
        MessageBox.Show("Please, Entry " + stitle + " Value, Not Valid Number.");   
        textBox.Focus();
        bresult = false;
    }  
    return bresult;
}

public
ButtonsListViewFunctions addButtonsListViewFunctions(ListView listView,Button firstButton,Button prevButton,
                                 Button nextButton,Button lastButton){

    ButtonsListViewFunctions buttonsListViewFunctions = new ButtonsListViewFunctions(listView,firstButton,prevButton,nextButton,lastButton);
    arrayListButtonsListView.Add(buttonsListViewFunctions);

    return buttonsListViewFunctions;
}

public
void removeButtonsListViewFunctions(){    
    arrayListButtonsListView.Clear();
}

public
ContextMenuListViewFunctions addContextMenuListViewFunctions(ListView listView){
    ContextMenuListViewFunctions contextMenuListView = new ContextMenuListViewFunctions(listView);    
    arrayListContextMenuListViewFunctions.Add(contextMenuListView);

    return contextMenuListView;
}

public
ContextMenuListViewFunctions addContextMenuListViewFunctions(ListView listView, bool showHistoryMenu, bool showColorLegendMenu, bool showSaveMenu, bool showEditMenu){
    ContextMenuListViewFunctions contextMenuListView = new ContextMenuListViewFunctions(listView, showHistoryMenu, showColorLegendMenu, showSaveMenu, showEditMenu);    
    arrayListContextMenuListViewFunctions.Add(contextMenuListView);

    return contextMenuListView;
}

public
ContextMenuListViewFunctions addContextMenuItem(string optionMenu){
    //get last context menu created    
    ContextMenuListViewFunctions contextMenuListView = arrayListContextMenuListViewFunctions.Count > 0 ? (ContextMenuListViewFunctions)arrayListContextMenuListViewFunctions[arrayListContextMenuListViewFunctions.Count-1] : null;
    if (contextMenuListView!= null)
        contextMenuListView.addMenuItem(optionMenu);
    return contextMenuListView;
}

public
void loadGrid(ListView listView, IEnumerable obsCollection) {
    try{
        listView.DataContext = obsCollection;
        listView.ItemsSource = obsCollection; 
        if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;

    }catch (Exception ex){
        MessageBox.Show("loadGrid Exception: " + ex.Message);
    } 
}

public
void removeTabItem(TabControl tabControl, TabItem tabItem){
    if (tabControl.Items.IndexOf(tabItem) >=0)
        tabControl.Items.Remove(tabItem); 
}

public
void addTabItem(TabControl tabControl, TabItem tabItem,Object obj){
    if (tabControl.Items.IndexOf(tabItem) < 0)
        tabControl.Items.Add(tabItem);        
    tabControl.SelectedItem = tabItem;
    tabItem.DataContext = null;
    tabItem.DataContext = obj;
}

public
void loadPlantCombo(ComboBox plantComboBox,bool baddAll){       
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        if (baddAll)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        string[] plants = coreFactory.getPlantCodes();
        for(int i = 0; i < plants.Length; i++)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(plants[i], plants[i]));		    
                       
       setDataContextCombo(plantComboBox,list);        
        
    } catch (Exception ex) {
        MessageBox.Show("loadPlantCombo Exception: " + ex.Message);        
    }
}

public
void loadDeptCombo(ComboBox comboBox,string splant, string sdept,bool ball=true){   
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
     
        DepartamentContainer departamentContainer = coreFactory.readDepartamentsByFilters("",splant,sdept,"",0);                
        for(int i = 0; i < departamentContainer.Count; i++){   
            string sdeptCode = ((Departament)departamentContainer[i]).getDept();
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sdeptCode,sdeptCode));		    		    
        }                  

        setDataContextCombo(comboBox,list);          

    } catch (Exception ex) {
        MessageBox.Show("loadDeptCombo Exception: " + ex.Message);        
    }     
}

public
void loadMachineCombo(ComboBox comboBox, string splant, string sdept,bool ball=false){   
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("None","0"));
     
        MachineContainer machineContainer = coreFactory.readMachinesByFilters("","",splant,sdept,"",false,0);                
        int imaxCodeLen = machineContainer.getMaxMachCodeLen();
        for(int i = 0; i < machineContainer.Count; i++){   
            Machine machine = machineContainer[i];            
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(machine.Mach, imaxCodeLen, false) + "-" + machine.Des1, machine.Id));		    		    
        }                  
        setDataContextCombo(comboBox, list);        

    } catch (Exception ex) {
        MessageBox.Show("loadMachineCombo Exception: " + ex.Message);        
    }     
}

public
EmployeeContainer loadEmployeeCombo(ComboBox comboBox,string sid="",string firstName="",string lastName="",string status=Constants.STATUS_ACTIVE,int iassignShift=0,string sdept="",int rows=0){
    EmployeeContainer employeeContainer = coreFactory.createEmployeeContainer();
    try { 
        employeeContainer = coreFactory.readEmployeeByFilters(sid, firstName, lastName, status, iassignShift, sdept,-1,false,true,rows);

        loadEmployeeCombo(comboBox,employeeContainer);        

    }catch (Exception ex){
        MessageBox.Show("loadEmployeeCombo Exception: " + ex.Message);
    }
    return employeeContainer;
}

public
void loadEmployeeCombo(ComboBox comboBox,EmployeeContainer employeeContainer){
    try {         
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces("", 10, false) + "-"  + "All",""));

        foreach(Employee employee in employeeContainer)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(employee.Id,10,false) + "-" + employee.FullName,employee.Id));

        setDataContextCombo(comboBox, list);        

    }catch (Exception ex){
        MessageBox.Show("loadEmployeeCombo Exception: " + ex.Message);
    }    
}


public
void loadDirIndCombo(ComboBox comboBox, bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Direct", "D"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Indirect", "I"));                
                       
        setDataContextCombo(comboBox, list);        

    } catch (Exception ex) {
        MessageBox.Show("loadDirIndCombo Exception: " + ex.Message);        
    }
}

public
void loadHolidayType(ComboBox combo,bool baddAll){       
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        if (baddAll)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        /*
        CapHolidayTypeContainer capHolidayTypeContainer = coreFactory.readCapHolidayTypeByFilters("","",0);
        for(int i = 0; i < capHolidayTypeContainer.Count;i++)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(capHolidayTypeContainer[i].Name,30,true) + " - " + capHolidayTypeContainer[i].SuggestDay, capHolidayTypeContainer[i].Id.ToString()));		    
          */             
       setDataContextCombo(combo, list);        
        
    } catch (Exception ex) {
        MessageBox.Show("loadHolidayType Exception: " + ex.Message);        
    }
}

public
void loadPartGLExps(ComboBox comboBox){
    try {         
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        ArrayList   array = getCoreFactory().readGLExps();

        foreach(string sglExp in array)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sglExp,sglExp));

        setDataContextCombo(comboBox, list);        

    }catch (Exception ex){
        MessageBox.Show("loadPartGLExps Exception: " + ex.Message);
    }    
}

public
bool cancel(){ 
    bool bresult=false;
    if (System.Windows.Forms.MessageBox.Show("Do You Want To Cancel Changes ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
        bresult=true;
    return bresult;
}

public
bool closeAsk(){ 
    bool bresult=false;
    if (System.Windows.Forms.MessageBox.Show("Do You Want To Close Screen ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
        bresult=true;
    return bresult;
}

public
void screenFullArea(){
    window.Top = 0;
    window.Left = 0;
    window.Width = SystemParameters.WorkArea.Width;
    window.Height = SystemParameters.WorkArea.Height;
}

public 
GroupStyle generateListViewGroupStyle(  string sbindGroupTitle,double dheight,Color color,Color colorBorder,
                                        double dfontSize,double dcornerRadius,double dborderThickness){

        #region  Control template Code(to show content)

        ControlTemplate template = new ControlTemplate(typeof(GroupItem));

        //Create border object
        FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));


        border.SetValue(Border.CornerRadiusProperty, new CornerRadius(dcornerRadius)); //3
        border.SetValue(Border.BorderThicknessProperty, new Thickness(dborderThickness)); //2
        border.SetValue(Border.BorderBrushProperty, new SolidColorBrush(colorBorder));
        border.SetValue(Border.PaddingProperty, new Thickness(2));

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
        textBlock.SetValue(TextBlock.TextProperty, new Binding() { Path = new PropertyPath(sbindGroupTitle) });
        textBlock.SetValue(TextBlock.BackgroundProperty, new SolidColorBrush(color));
        textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.UltraBold);        
        textBlock.SetValue(TextBlock.FontSizeProperty, dfontSize);
        textBlock.SetValue(TextBlock.HeightProperty, dheight);
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
CapShiftTask getDownTimeTask(){
    CapShiftTaskContainer   capShiftTaskContainer = getCoreFactory().readCapShiftTaskByFilters("", "%Down%Tim%", "", 1);
    CapShiftTask            capShiftTask= null;

    if (capShiftTaskContainer.Count > 0)
        capShiftTask= capShiftTaskContainer[0];                               
    
    return capShiftTask;
}

public
CapShiftTask getChangeOverTask(){
    CapShiftTaskContainer   capShiftTaskContainer = getCoreFactory().readCapShiftTaskByFilters("", "%Change%Over%", "", 1);
    CapShiftTask            capShiftTask= null;

    if (capShiftTaskContainer.Count > 0)
        capShiftTask= capShiftTaskContainer[0];                               
    
    return capShiftTask;
}

public
void createListViewColumns(ListView listView,int imaxColumns){
    GridView    view = (GridView)listView.View;

    if (view == null){
        view = new GridView();
        listView.View = view;
    }
    
    for (int i=0; view.Columns.Count < imaxColumns; i++) { 
        GridViewColumn column = new GridViewColumn();
        view.Columns.Add(column);
    }    
}

public
void ProcessStart(){
    this.processStartDate = DateTime.Now;
}

public
void ProcessEnd(){
    processEndDate = DateTime.Now;
}

public
string ProcessEndAndTex(int icountRecords){
    string stext ="";
    ProcessEnd();
    stext = "Tim:" + ((processEndDate - processStartDate).TotalSeconds).ToString("###,##0.00") + "s";

    if (icountRecords >=0)
        stext+= "/Rec:" + icountRecords;

    return stext;    
}

public
void loadDifferentsMajorGroup(ComboBox comboBox){
    try{ 
        string[] majorList = getCoreFactory().getMajorGroupASString("");
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        foreach (string smajGroup in majorList){
            if (!string.IsNullOrEmpty(smajGroup))
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(smajGroup,smajGroup));
        }                  
        setDataContextCombo(comboBox,list);        

    } catch (Exception ex) {
        MessageBox.Show("loadDifferentsMajorGroup Exception: " + ex.Message);        
    }
}

public
void setDataContextCombo(ComboBox comboBox, IEnumerable obj){
    comboBox.ItemsSource = obj;
    if (comboBox.Items.Count > 0)
        comboBox.SelectedIndex = 0;
}

public
void setDataContextComboSelected(ComboBox comboBox, IEnumerable obj){
    try { 
        Object objSelected = getSelectedComboBoxItem(comboBox);
        comboBox.ItemsSource = obj;
        if (comboBox.Items.Count > 0) { 
            if (objSelected!= null)
                setSelectedComboBoxItem(comboBox,objSelected);
            if (comboBox.SelectedIndex < 0)
                comboBox.SelectedIndex = 0;
        }
    } catch (Exception ex) {
        MessageBox.Show("setDataContextComboSelected Exception: " + ex.Message);        
    }
}

public
void setDataContextListView(ListView listView,IEnumerable obj){
    
    listView.DataContext= obj;                
    listView.ItemsSource= obj;   
    if (listView.Items.Count > 0)
        listView.SelectedIndex=0;
    listView.Focus(); //so scroll buttons enable    
}

public
void setDataContextListViewSelected(ListView listView,IEnumerable obj){
     try { 
        Object objSelected = getSelected(listView); //get if already exist item selected

        listView.DataContext= obj;                
        listView.ItemsSource= obj;   

        if (listView.Items.Count > 0) { 
            if (objSelected!= null)
                setSelected(listView,objSelected); //try to select item again
            if (listView.SelectedIndex < 0)
                listView.SelectedIndex = 0;
        }        
        listView.Focus(); //so scroll buttons enable    

    } catch (Exception ex) {
        MessageBox.Show("setDataContextListViewSelected Exception: " + ex.Message);        
    }
}

public 
void plantComboBoxSelectionChanged(ComboBox plantComboBox,ComboBox deptComboBox) {
    try{         
        string      splant  = getSelectedComboBoxItemString(plantComboBox);
        loadDeptCombo(deptComboBox,splant,"");
    }catch (Exception ex){
        MessageBox.Show("plantComboBoxSelectionChanged Exception: " + ex.Message);
    } 
}

public 
void deptComboBoxSelectionChanged(ComboBox plantComboBox,ComboBox deptComboBox,ComboBox machineComboBox) {
    try{         
        string      splant = getSelectedComboBoxItemString(plantComboBox);                    
        string      sdept  = getSelectedComboBoxItemString(deptComboBox);
        loadMachineCombo(machineComboBox,splant, sdept);
    }catch (Exception ex){
        MessageBox.Show("plantComboBoxSelectionChanged Exception: " + ex.Message);
    } 
}

public
Product searchPart(){ 
    Product product = null;
    try{       
        ProductWindow productWindow = new ProductWindow();
        if ((bool)productWindow.ShowDialog()){
            product = productWindow.getSelected();                                            
        }               
                           
    }catch (Exception ex){
        MessageBox.Show("searchPart Exception: " + ex.Message);
    } 
    return product;
}

public
Machine searchMachine(string splant){ 
    Machine machine = null;
    try{   
        MachineWindow machineWindow = new MachineWindow(true,splant);
        if ((bool)machineWindow.ShowDialog()){
            machine = machineWindow.getSelected();
        }      

    }catch (Exception ex){
        MessageBox.Show("searchMachine Exception: " + ex.Message);
    } 
    return machine;
}


public
Employee searchEmployee(int ishiftFilter=0){ 
    Employee employee = null;
    try{
        EmployeeWindow window = new EmployeeWindow(true,ishiftFilter);
        if ((bool)window.ShowDialog()){
            employee = window.getSelected();                                            
        }               
                           
    }catch (Exception ex){
        MessageBox.Show("searchPart Exception: " + ex.Message);
    } 
    return employee;
}

public
Person searchCustomer(string scustType=""){ 
    Person person = null;
    try{
        CustomerWindow window = new CustomerWindow(true,scustType);
        if ((bool)window.ShowDialog()){
            person = window.getSelPerson();                                            
        }               
                           
    }catch (Exception ex){
        MessageBox.Show("searchCustomer Exception: " + ex.Message);
    } 
    return person;
}
   
      
public
void navigateCapacity(string splant){     
    try{       
        CapacityHdrWindow capacityHdrWindow = new CapacityHdrWindow(splant);        
        capacityHdrWindow.ShowDialog();
                           
    }catch (Exception ex){
        MessageBox.Show("navigateCapacity Exception: " + ex.Message);
    }     
}

public
void navigateCapacityReport(string splant){     
    try{       
        CapacityHdr capacityHdr = getCoreFactory().readCapacityHdrLast(splant,true);

        if (capacityHdr!= null){
            CapacityReportWindow capacityReportWindow = new CapacityReportWindow(capacityHdr);        
            capacityReportWindow.ShowDialog();    
        }else
            MessageBox.Show("Sorry, Can Not Find Capacity Generated For Plant = " + splant + ".");

    }catch (Exception ex){
        MessageBox.Show("navigateCapacityReport Exception: " + ex.Message);
    }     
}

public
void navigateMachineViews(Machine machine){     
    try{       
        MachineViewsWindow wind = new MachineViewsWindow(machine);        
        wind.ShowDialog();
                           
    }catch (Exception ex){
        MessageBox.Show("navigateMachineViews Exception: " + ex.Message);
    }     
}

public
Machine navigateMachine(bool bmodeSelect, string splant, Machine machine = null){     
    try{
        MachineWindow wind = new MachineWindow(bmodeSelect,splant,machine);        
        wind.ShowDialog();

        return wind.getSelected();    
                           
    }catch (Exception ex){
        MessageBox.Show("navigateMachine Exception: " + ex.Message);
    }     
    return null;
}

public
void navigateCapacity(string splant,Machine machineFilter=null){     
    try{
        CapacityHdr capacityHdr = getCoreFactory().readCapacityHdrLast(splant,true);

        if (capacityHdr!= null){
            CapacityHdrWindow wind = new CapacityHdrWindow(splant,machineFilter);        
            wind.ShowDialog();
        }else
            MessageBox.Show("Sorry, Can Not Find Capacity Generated For Plant = " + splant + ".");
                                          
    }catch (Exception ex){
        MessageBox.Show("navigateCapacity Exception: " + ex.Message);
    }         
}

public
Product partSearch(TextBox partTextBox){        
    Product product = null;
    try{            
        ProductWindow productWindow = new ProductWindow();
        if ((bool)productWindow.ShowDialog()) {                 
            product = productWindow.getSelected();      
            if (product!= null)
                partTextBox.Text = product.ProdID;
        }
       
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }                       
    return product;
}

public
void loadPartSequences(ComboBox comboBox,string spart){
    try {
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();                
        comboBox.ItemsSource = list;  

        if (!string.IsNullOrEmpty(spart)){            
            string[] items = getCoreFactory().getValidsSeqsForProduct(spart);
                
            for (int i=0; i < items.Length;i++)
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(items[i], items[i]));
                        
            if (items.Length < 1){ //if not seq list , I will add at least last seq
                Product  product = getCoreFactory().readProduct(spart);                    
                if (product != null)
                    list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(product.SeqLast.ToString(), product.SeqLast.ToString()));
            }            
            comboBox.ItemsSource = list;         
        }
              
    } catch (Exception ex) {
        MessageBox.Show("loadPartSequences Exception: " + ex.Message);        
    }
}

public
bool validProduct(TextBox partTextBox){ 
    bool    bresult=false;
    try{ 
        Product product= null; 

        if (string.IsNullOrEmpty(partTextBox.Text)){ 
            MessageBox.Show("Please, Enter Part Value.");
            partTextBox.Focus();
        } else{ 
            product = coreFactory.readProduct(partTextBox.Text); 
            if (product==null){
                MessageBox.Show("Please, Enter Valid Part Value.");
                partTextBox.Focus();
            }else
                bresult=true;
        }

    }catch (Exception ex){
        MessageBox.Show("validProduct Exception: " + ex.Message);
    } 

    return bresult;
}

public
void close(){
    if (window != null){
        window.DialogResult = false;
        window.Close();
    }
}

public
Object getFromHashTable(Hashtable hash,string skey){            
    Object objRet = null;
    if (hash.Contains(skey.ToUpper()))
        objRet = hash[skey.ToUpper()];
    return objRet;
}

public
Object getFromHashTable(Hashtable hash,int ikey){            
    Object objRet = null;
    if (hash.Contains(ikey))
        objRet = hash[ikey];
    return objRet;
}

public
void addToHashTable(Hashtable hash, Object obj,string skey){                
    if (!hash.Contains(skey.ToUpper()))
        hash.Add(skey.ToUpper(),obj);                
}

public
Product readProductHash(Hashtable hash,string spart){
    Product product = null;
    try{
        product = (Product)getFromHashTable(hash,spart);                 
        if (product == null){
            product = getCoreFactory().readProduct(spart);
            if (product!=null)
               addToHashTable(hash,product,spart);
        }

    }catch (Exception ex){
        MessageBox.Show("readProductHash Exception: " + ex.Message);
    } 
    return product;
}

public
void loadAllTasks(Hashtable hash){
    CapShiftTaskContainer   capShiftTaskContainer = getCoreFactory().readCapShiftTaskByFilters("","","",0);      
    foreach(CapShiftTask capShiftTask in capShiftTaskContainer) {          
        if (!hash.Contains(capShiftTask.Id))
            hash.Add(capShiftTask.Id,capShiftTask);        
    }
}

public
void reloadAllTasks(Hashtable hash){
    hash.Clear();
    loadAllTasks(hash);
}

public
void loadShiftTaskComboBox(ComboBox shiftTaskComboBox,bool baddAllNone){
    try { 
        CapShiftTaskContainer   capShiftTaskContainer = coreFactory.readCapShiftTaskByFilters("", "", "", 0);
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        string                  saux = "";

        if (baddAllNone) { 
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All","-1"));        
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("None","0"));
        }
    
        foreach(CapShiftTask capShiftTask in capShiftTaskContainer){
            saux = capShiftTask.DirInd + " - " + capShiftTask.TaskName; 
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, capShiftTask.Id.ToString()));
        }
                       
        shiftTaskComboBox.ItemsSource = list;
        if (shiftTaskComboBox.Items.Count > 0)
            shiftTaskComboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadShiftTaskComboBox Exception: " + ex.Message);        
    }
}

public
void checkListViewScrollButtons(){
    try { 
        for (int i=0; i < arrayListButtonsListView.Count;i++){
            ButtonsListViewFunctions buttonsListViewFunctions = (ButtonsListViewFunctions)arrayListButtonsListView[i];
            buttonsListViewFunctions.checkListViewIndex();
        }
    } catch (Exception ex) {
        MessageBox.Show("checkListViewScrollButtons Exception: " + ex.Message);        
    }
}

public
bool getProductionPrHistSum(ref Hashtable hashPrHistSum,ref DateTime prHistDateTimeChecked,string spart,int iseq,string sdept,DateTime fromDate,DateTime toDate,PrHistSumViewContainer prHistSumViewContainer=null){
    bool bresult=true;
    try { 
        if (prHistDateTimeChecked == DateUtil.MinValue || DateTime.Now > prHistDateTimeChecked.AddMinutes(Constants.MAX_MINS_CHECK_PR_HIST)) { //check if at least passed 10 mins for last check just to not waste time
            sdept = string.IsNullOrEmpty(sdept) ? "" : sdept+"%";
            hashPrHistSum = getCoreFactory().readPrHistByFiltersHashSummarizedByPartSeq(spart,iseq,sdept,fromDate,toDate,prHistSumViewContainer,0);
            prHistDateTimeChecked = DateTime.Now;
        }
    }catch {
        bresult = false;
        MessageBox.Show("Connection Issue When Trying To Get Production History Information.");
    }
    return bresult;
}

public
decimal getProductionPrHistSumFromHash(Hashtable hashPrHistSum, string spart,int iseq){
    decimal dty=0;
    try { 
        string  skey= spart.ToUpper() + Constants.DEFAULT_SEP + iseq.ToString();
        
        if (hashPrHistSum.Contains(skey)){
            PrHistSumView prHistSumView = (PrHistSumView)hashPrHistSum[skey];
            dty = prHistSumView.DWQTYC;
        }

    } catch (Exception ex) {
        MessageBox.Show("getProductionPrHistSumFromHash Exception: " + ex.Message);      
    }
    return dty;
}

public
bool checkIfAnyHoliday(CapShiftProfile capShiftProfile,bool bincludeWeekend=true){
    //check if any holiday
    DateTime    currDate = capShiftProfile.StartDate;
    bool        bholidayNotWeekend=false;

    for (int i=0; i < 7; i++){
        currDate = capShiftProfile.StartDate.AddDays(i);
        
        if (!DateUtil.isWeekendDate(currDate) || (bincludeWeekend && DateUtil.isWeekendDate(currDate))){ 
            CapProfileHolidayContainer capProfileHolidayContainer  = getCoreFactory().readIfHoliday(capShiftProfile.Plant,currDate,1);
            if (capProfileHolidayContainer.Count > 0){ 
                capShiftProfile.setDayWork(currDate.DayOfWeek,Constants.STRING_NO);                            

                if (currDate.DayOfWeek!= DayOfWeek.Saturday && currDate.DayOfWeek != DayOfWeek.Sunday)
                    bholidayNotWeekend=true;
            }
        }
    }
    return bholidayNotWeekend;
}  

public
Machine getMachineById(Hashtable hashMachinesById, int id){
    Machine machine = null;
    try { 
        if (hashMachinesById.Contains(id))  
            machine = (Machine)hashMachinesById[id];

        if (machine == null) { 
            machine = getCoreFactory().readMachineById(id);
            if (machine!= null)
                hashMachinesById.Add(id,machine);
        }
                            
    } catch (Exception ex) {
        MessageBox.Show("getMachineById Exception: " + ex.Message);        
    }      
    return machine;    
}

public
void loadEmployeesMachCode(EmployeeContainer employeeContainer,Hashtable hashMachinesById){    
    try { 
        Machine     machine = null;
        Employee    employee=null;

        for (int i=0; i < employeeContainer.Count; i++){
            employee = employeeContainer[i];
            employee.MachShow = "";

            if (employee.DftMachId > 0) { 
                machine = getMachineById(hashMachinesById, employee.DftMachId);
                if (machine!= null)
                    employee.MachShow = machine.Mach;
            }        
        }
                            
    } catch (Exception ex) {
        MessageBox.Show("loadEmployeesMachCode Exception: " + ex.Message);        
    }          
}

public
Employee readEmployeeLogged() { 
    Employee employee = null;        
    try{
        if (App.UserLogged!= null && !string.IsNullOrEmpty(App.UserLogged.EmpId)) 
            employee = getCoreFactory().readEmployee(App.UserLogged.EmpId);

    } catch (Exception ex) {
        MessageBox.Show("readEmployeeLogged Exception: " + ex.Message);        
    } 
    return employee;
}

public 
bool snapShotPNG(ListView source, string destination, int zoom){
    bool bresult=false;
    try{
        double actualWidth = source.ActualWidth;
        source.Measure(new Size(source.ActualWidth, Double.PositiveInfinity));
        source.Arrange(new Rect(0, 0, actualWidth, source.DesiredSize.Height));
        double actualHeight = source.ActualHeight;

        double renderHeight = actualHeight * zoom;
        double renderWidth = actualWidth * zoom;

        RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
        VisualBrush sourceBrush = new VisualBrush(source);

        DrawingVisual drawingVisual = new DrawingVisual();
        DrawingContext drawingContext = drawingVisual.RenderOpen();

        using (drawingContext){
            drawingContext.PushTransform(new ScaleTransform(zoom, zoom));
            drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
        }
        renderTarget.Render(drawingVisual);

        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(renderTarget));
        using (FileStream stream = new FileStream(destination, FileMode.Create, FileAccess.Write)){
            encoder.Save(stream);
        }
    }catch (Exception e){
        MessageBox.Show(e.Message);
    }
    return bresult;
}

public
void freeMemory(){
    GC.Collect();
}

}
}
