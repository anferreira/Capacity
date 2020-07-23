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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using HotListReports.Windows.Util;

namespace HotListReports.Windows.Customers{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
public partial class 
CustomerWindow : Window{

private CustomerModel   model;
private int             itabIndex;
private int             itransferTabIndex;
private bool            bmodeSelect;
private string          scustTypeFilter;

public CustomerWindow(bool bmodeSelect=false,string scustTypeFilter=""){
    InitializeComponent();

    model = new CustomerModel(this,hdrListView,customerPartsListView,transferListView,transferDtlListView, transferReleseListView,leadListView, shipExportSumListView);
    itabIndex=0;
    itransferTabIndex = 0;
    this.bmodeSelect = bmodeSelect;
    this.scustTypeFilter = scustTypeFilter;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}
      
private 
void initialize(){        
    try {                         
        //model.addFunnelTitle();
        this.exportAutoButton.Visibility = Visibility.Hidden;
        model.addButtonsListViewFunctions(this.hdrListView,     firstButton, prevButton, nextButton, lastButton);
        model.addButtonsListViewFunctions(this.leadListView,    firstLButton,prevLButton,nextLButton,lastLButton);
        model.addButtonsListViewFunctions(this.transferListView,firstTButton,prevTButton,nextTButton,lastTButton);
        model.addButtonsListViewFunctions(this.transferDtlListView,firstTDtlButton, prevTDtlButton, nextTDtlButton, lastTDtlButton);
        model.addButtonsListViewFunctions(this.transferReleseListView,firstTRelButton, prevTRelButton, nextTRelButton, lastTRelButton);                
        model.addButtonsListViewFunctions(this.customerPartsListView, firstCPButton, prevCPButton, nextCPButton, lastCPButton);
        model.addButtonsListViewFunctions(this.shipExportSumListView, firstSumButton, prevSumButton, nextSumButton, lastSumButton);
                
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        this.recordsCustomTransferTextBox.Text = Configuration.SearchDefaultMaxRecords; 
        model.Cursor = this.Cursor;

        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadCombo(this.searchByComboBox,"Id","Name","Address 1","Phone");        
        model.loadStatusComboBox(this.stsComboBox,true); model.setSelectedComboBoxItem(stsComboBox,Constants.STATUS_ACTIVE);
        model.loadBillToShipToComboBox(this.custTypeComboBox,true); model.setSelectedComboBoxItem(custTypeComboBox,scustTypeFilter); 
        model.loadYesNoComboBox(ppapComboBox,true);

        model.loadColumnsOnTransferGrid(transferListView);
        model.loadColumnsOnShipExportDtlGrid(transferDtlListView);
        model.loadColumnsOnShipExportRelGrid(transferReleseListView);
        model.loadColumnsOnShipExportSumGrid(shipExportSumListView,false);
        model.loadPlantCombo(plantCTComboBox,true);model.setSelectedComboBoxItem(plantCTComboBox,Configuration.DftPlant);
        model.loadCombo(this.searchByCTComboBox, "Bol#","Order#","Cust.PO","PO","Bill To","Ship To");//,"TPartner");  
        loadCustomersCombo();
        model.loadOrderDocTypeComboBox(docTypeComboBox,true);
        fromDatePicker.SelectedDate = DateTime.Now.AddMonths(-2);
        toDatePicker.SelectedDate   = DateTime.Now.AddMonths(1);

        model.loadColumnsOnCustomerPartsGrid(customerPartsListView);

        model.loadColumnsOnLeadsGrid(leadListView);


        ContextMenuListViewFunctions contextMenuListView = model.addContextMenuListViewFunctions(transferListView);
        model.addContextMenuItem(Constants.OPTIONS_ADJUST_LEATETIME);
        contextMenuListView.contextMenuListViewEventHandler += new ContextMenuListViewEventHandler(contextMenuListViewEventHandlerEvent);

        contextMenuListView = model.addContextMenuListViewFunctions(shipExportSumListView,false,false,false,true);
        model.addContextMenuItem(Constants.OPTIONS_ADJUST_LEATETIME);
        contextMenuListView.contextMenuListViewEventHandler += new ContextMenuListViewEventHandler(contextMenuListViewShipExportSumEventHandlerEvent);
        
        model.screenFullArea();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    } finally{         
    }
}

private
void contextMenuListViewEventHandlerEvent(object sender, string optionSelected){
    
    switch (optionSelected){        
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_CANCEL:
            model.close();                                
            break;
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_REFRESH:
            searchCustomTransfer();
            break;        
        case Constants.OPTION_EDIT:    
            model.editSumUpCum01P();                            
            break;        
        case Constants.OPTIONS_ADJUST_LEATETIME:        
            model.adjustLeadTime(itransferTabIndex==3);
            break;                
    }
}

private
void contextMenuListViewShipExportSumEventHandlerEvent(object sender, string optionSelected){
    
    switch (optionSelected){        
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_CANCEL:
            model.close();                                
            break;
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_REFRESH:
            searchShipExportSum();
            break;        
        case  Constants.OPTION_EDIT:
            model.editSum();
            break;
        case Constants.OPTIONS_ADJUST_LEATETIME:        
            model.adjustLeadTime(itransferTabIndex==3);
            break;                
    }
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    mainTabControlSelectionChanged();
}

public
Person getSelPerson(){
    Person person = (Person)model.getSelected(hdrListView); 
    return person;
}

private 
void mainTabControlSelectionChanged(){
    try {
        int indexSel    = mainTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;
                        
            if (indexSel == 0){            
                search();
            }else if (indexSel == 1 || indexSel == 2){                            
                                        
                Person person = (Person)model.getSelected(hdrListView);                                             
                if (person != null)
                   if (indexSel == 1)
                        loadLeadsTime(person);
                else
                    mainTabControl.SelectedItem = this.hdrTabItem;                
            
            }else if (indexSel == 3){      
                model.loadCustomerParts(customerPartsTabItem);
            }else if (indexSel == 4){      
                searchCustomTransfer();
            } 
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }

}

private 
void transferTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    transferTabControlSelectionChanged();
}

private 
void transferTabControlSelectionChanged(){
    try {
        int indexSel    = transferTabControl.SelectedIndex;
        int ipriorIndex = itransferTabIndex;
                
        if (indexSel != itransferTabIndex){
            this.itransferTabIndex = indexSel;
            showHideTrnasferScrollButtons(itransferTabIndex);
                        
            if (indexSel == 0) {             
                this.itransferTabIndex = indexSel; //do nothing for now
            }else if (indexSel == 1 || indexSel == 2){     
                UpCum01PView upCum01PView = (UpCum01PView)model.getSelected(transferListView);
                if (upCum01PView!= null) { 
                    transferReleseTabItem.DataContext = null;
                    transferReleseTabItem.DataContext = upCum01PView;

                    string sflagShipExportMode= ShipExport.EXPORT_ORDER;
                    if (upCum01PView.DCOTYP.Equals("B"))
                        sflagShipExportMode= model.getShipExportMode(upCum01PView);

                    if (sflagShipExportMode.Equals(ShipExport.EXPORT_830) && sflagShipExportMode.Equals(ShipExport.EXPORT_862) && sflagShipExportMode.Equals(ShipExport.EXPORT_862_RAN))
                        model.loadShipExportRel();
                    else { 
                        if (indexSel == 1)  model.loadShipExportDtl();
                        if (indexSel == 2)  model.loadShipExportRel();
                    }
                    
                }else
                    transferTabControl.SelectedItem = transferViewTabItem;
            }else if (indexSel == 3)
                searchShipExportSum();
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

private
void showHideTrnasferScrollButtons(int itransferTabIndex){
    firstTButton.Visibility     = prevTButton.Visibility    = nextTButton.Visibility    = lastTButton.Visibility    = itransferTabIndex == 0 ? Visibility.Visible : Visibility.Hidden;
    firstTDtlButton.Visibility  = prevTDtlButton.Visibility = nextTDtlButton.Visibility = lastTDtlButton.Visibility = itransferTabIndex == 1 ? Visibility.Visible : Visibility.Hidden;    
    firstTRelButton.Visibility  = prevTRelButton.Visibility = nextTRelButton.Visibility = lastTRelButton.Visibility = itransferTabIndex == 2 ? Visibility.Visible : Visibility.Hidden;    
    firstSumButton.Visibility   = prevSumButton.Visibility  = nextSumButton.Visibility  = lastSumButton.Visibility  = itransferTabIndex == 3 ? Visibility.Visible : Visibility.Hidden;    
}   

private
void loadLeadsTime(Person person){
    leadTabItem.DataContext=null;
    leadTabItem.DataContext=person;
    model.loadLeads(person);            
}

private
void leadListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    model.modifyLead();
}

private
void loadCustomersCombo(){
    model.loadCustomerComboBox(billToCTComboBox,true,Person.CUSTOMER_TYPE_BILLTO);
    model.loadCustomerComboBox(shipToCTComboBox,true,Person.CUSTOMER_TYPE_SHIPTO);
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){            
    if (bmodeSelect) { 
        this.DialogResult = true;
        Close();
    }
}

private 
void search(){
    try{ 
        model.cursorWait();
        int         irows           = model.getRecords(recordsTextBox);
        string      sid             = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,0);
        string      sname           = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,1);
        string      status          = (string)model.getSelectedComboBoxItem(stsComboBox);
        string      splant          = "";
        string      stype           = Person.TYPE_CUSTOMER;
        string      scustType       = (string)model.getSelectedComboBoxItem(custTypeComboBox);      
        string      saddress1       = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,2);
        string      sphone          = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,3);
        string      sbillToCust     = "";        
        
        PersonContainer personContainer = model.getCoreFactory().readPersonsByFilters(splant,sid,stype,scustType,status,sname,saddress1,sbillToCust, sphone,irows);        
        model.setDataContextListViewSelected(hdrListView,personContainer);
       
        searchForTextBox.Focus();

    } catch (Exception ex) {
        MessageBox.Show("search Exception: " + ex.Message);        
    }finally{
        model.cursorNormal();
    }
                   
}

private 
void okDefaultsButton_Click(object sender, RoutedEventArgs e){   
}

private 
void cancelDefaultsButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void searchCustomTransferButton_Click(object sender, RoutedEventArgs e){
   searchCustomTransferGeneric();
}

private 
void searchCustomTransferGeneric(){
    if (itransferTabIndex == 3)
        searchShipExportSum();    
    else
        searchCustomTransfer();
}

private 
bool searchCustomTransfer(){
    try{ 
        model.cursorWait();
        model.freeMemory();

        transferTabControl.SelectedItem = transferViewTabItem;        

        int         irows       = model.getRecords(recordsCustomTransferTextBox);
        string      splant      = (string)model.getSelectedComboBoxItem(plantCTComboBox);
        string      stpartner   = "";//model.getSearchFromComboBoxString(searchByCTComboBox,searchForCTTextBox,1);        
        string      sbol        = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,0);
        string      sorder      = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,1);
        string      scustPO     = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,2);
        string      spo         = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,3);
        string      sbillTo     = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,4);
        string      shipTo      = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,5);
        DateTime    fromDate    = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate      = model.getSelectedDateTime(toDatePicker);
        string      sdocType    = (string)model.getSelectedComboBoxItem(docTypeComboBox); 
        string      srelease    = releaseTextBox.Text;
        bool        blateOrders = (bool)lateOrdersCheckBox.IsChecked;
        string      sppap       = model.getSelectedComboBoxItemString(ppapComboBox);

        if (irows == 0 && System.Windows.Forms.MessageBox.Show("Do You Want To Search For All Records Which Match Filters ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            return false;
    
        if (string.IsNullOrEmpty(sbillTo))
            sbillTo = (string)model.getSelectedComboBoxItem(billToCTComboBox);
        if (string.IsNullOrEmpty(shipTo))
            shipTo = (string)model.getSelectedComboBoxItem(shipToCTComboBox);
        if (!string.IsNullOrEmpty(srelease))
            srelease+= "%";        

        foundRecordsCustomTransferTextBox.Text ="0";

        UpCum01PViewContainer upCum01PViewContainer = model.getCoreFactory().readUpCum01PCustomByFilters(splant,stpartner,sbillTo,shipTo,sbol,sorder,spo,scustPO,Constants.STRING_YES, sdocType, srelease,0,blateOrders,sppap,fromDate, toDate, irows);        
        //model.loadLeadsForCustomTransfer(upCum01PViewContainer);
        model.getCoreFactory().loadShipExportToUpCum01PList(upCum01PViewContainer);
        model.setDataContextListView(transferListView, upCum01PViewContainer);      
                
        foundRecordsCustomTransferTextBox.Text = upCum01PViewContainer.Count.ToString();

    } catch (Exception ex) {
        MessageBox.Show("searchCustomTransfer Exception: " + ex.Message);        
    }finally{
        model.cursorNormal();
    }           
    return true;                    
}

private 
void searchShipExportSum(){
    try{ 
        model.cursorWait();               

        int         irows       = model.getRecords(recordsCustomTransferTextBox);
        string      splant      = (string)model.getSelectedComboBoxItem(plantCTComboBox);
        string      stpartner   = "";//model.getSearchFromComboBoxString(searchByCTComboBox,searchForCTTextBox,1);    
        string      sbol        = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,0);                            
        string      sorder      = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,1);
        string      scustPO     = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,2);
        string      spo         = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,3);
        string      sbillTo     = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,4);
        string      shipTo      = model.getSearchFromComboBoxString(searchByCTComboBox, searchForCTTextBox,5);
        DateTime    fromDate    = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate      = model.getSelectedDateTime(toDatePicker);
        string      sdocType    = (string)model.getSelectedComboBoxItem(docTypeComboBox); 
        string      srelease    = releaseTextBox.Text;
        bool        blateOrders = (bool)lateOrdersCheckBox.IsChecked;
        string      sppap       = model.getSelectedComboBoxItemString(ppapComboBox);
        bool        bcompareDiff= (bool)compareCheckBox.IsChecked;
        bool        bqtyOrder   = (bool)qtyOrderCDCheckBox.IsChecked;
        bool        bqtyShip    = (bool)qtyShipCDheckBox.IsChecked;
        bool        bdateReq    = (bool)dateReqCDCheckBox.IsChecked;
        bool        bdateShip   = (bool)shipDateCDcheckBox.IsChecked;
        bool        bqtyPpm     = (bool)qtyPpmCDcheckBox.IsChecked;    
        bool        bleadTime   = (bool)leadTimeCDcheckBox.IsChecked;
        bool        bppap       = (bool)ppapCDcheckBox.IsChecked;                        
        ShipExportSumContainer shipExportSumContainer   = model.getCoreFactory().createShipExportSumContainer();

        if (string.IsNullOrEmpty(sbillTo))
            sbillTo = (string)model.getSelectedComboBoxItem(billToCTComboBox);
        if (string.IsNullOrEmpty(shipTo))
            shipTo = (string)model.getSelectedComboBoxItem(shipToCTComboBox);
        if (!string.IsNullOrEmpty(srelease))
            srelease+= "%";                

        foundRecordsCustomTransferTextBox.Text ="0";
        model.loadColumnsOnShipExportSumGrid(shipExportSumListView, bcompareDiff);

        if (bcompareDiff)
            shipExportSumContainer = model.getCoreFactory().readShipExportSumCompareByFilters(splant,sbillTo,shipTo, sbol,sorder, scustPO,sdocType, srelease,0,blateOrders,sppap,fromDate, toDate,
                                                            bqtyOrder,bqtyShip,bdateReq,bdateShip,bqtyPpm,bleadTime,bppap,irows);
        else
            shipExportSumContainer = model.getCoreFactory().readShipExportSumByFilters(splant,sbillTo, shipTo, sbol,sorder, scustPO,sdocType, srelease,0,blateOrders,sppap,fromDate, toDate, irows);

        model.setDataContextListView(shipExportSumListView, shipExportSumContainer);                              

        foundRecordsCustomTransferTextBox.Text = shipExportSumContainer.Count.ToString();

    } catch (Exception ex) {
        MessageBox.Show("searchShipExportSum Exception: " + ex.Message);        
    }finally{
        model.cursorNormal();
    }                   
}

private
void transferListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    transferTabControl.SelectedItem = transferDtlTabItem;
}

private
void transferListViewMouseDoubleClick(){
    try{ 
        UpCum01PView upCum01PView = (UpCum01PView)model.getSelected(transferListView);

        if (upCum01PView!= null) { 
            CustomViewWindow window = new CustomViewWindow(upCum01PView);
            window.ShowDialog();
        }

    } catch (Exception ex) {
        MessageBox.Show("transferListViewMouseDoubleClick Exception: " + ex.Message);        
    }finally{
        
    }  
}

private 
void lateOrdersCheckBox_Click(object sender, RoutedEventArgs e){
    searchCustomTransferGeneric(); 
}

private 
void exportAllButton_Click(object sender, RoutedEventArgs e){   
    if (itransferTabIndex == 3)
        model.reprocessSumAll();
    else
        model.exportAll();
}

private 
void exportSelButton_Click(object sender, RoutedEventArgs e){   
    if (itransferTabIndex == 3)
        model.reprocessSumSel();
    else        
        model.exportSel();
}

private 
void addLeadButton_Click(object sender, RoutedEventArgs e){   
   model.addLead();
}

private 
void delLeadButton_Click(object sender, RoutedEventArgs e){   
   model.delLead();
}   

private 
void includeSelButton_Click(object sender, RoutedEventArgs e){   
    model.transferIncludeSel(Constants.STRING_YES);  
}

private 
void excludeSelButton_Click(object sender, RoutedEventArgs e){   
   model.transferIncludeSel(Constants.STRING_NO);  
}

private 
void billToCTComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   billToCTComboBoxSelectionChanged();
}
       
private 
void billToCTComboBoxSelectionChanged() {
    try {     
        if (billToCTComboBox.SelectedIndex > 0) { //only when not All selected
            if  (searchByCTComboBox.SelectedIndex == 4)
                searchForCTTextBox.Text = "";

            searchCustomTransferGeneric();
        }
    } catch (Exception ex) {
        MessageBox.Show("billToCTComboBoxSelectionChanged Exception: " + ex.Message);        
    }
}

private 
void shipToCTComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    shipToCTComboBoxSelectionChanged();
}


private 
void shipToCTComboBoxSelectionChanged() {
    try {     
        if (shipToCTComboBox.SelectedIndex > 0) { //only when not All selected
            if  (searchByCTComboBox.SelectedIndex == 4)
                searchForCTTextBox.Text = "";

            searchCustomTransferGeneric();            
        }
    } catch (Exception ex) {
        MessageBox.Show("shipToCTComboBoxSelectionChanged Exception: " + ex.Message);        
    }
}
            
private 
void genericLeadButton_Click(object sender, RoutedEventArgs e){   
    genericLeadButtonClick();
}

private 
void genericLeadButtonClick(){   
    if (model.loadGenericCustomerLeads())
        mainTabControl.SelectedItem = leadTabItem;    
}

private 
void exportAutoButton_Click(object sender, RoutedEventArgs e){
    //exportAuto();

    //model.getCoreFactory().loadCustPOToShipExport();
    //model.getCoreFactory().readStxhByFilters(0,"","",DateTime.Now.AddDays(-30),DateTime.Today,100);

    //model.getCoreFactory().getStxhDifferentsTPartnerByFiltersDate(DateTime.Now.AddDays(-30), DateTime.Today);

    //EdiTransTPContainer ediTransTPContainer = model.getCoreFactory().createEdiTransTPartnerAutomatic();

        
    try{   
        model.getCoreFactory().loadGenericPriorCum();                    
    
                /*
        UpCum01PViewContainer upCum01PViewContainer = (UpCum01PViewContainer)transferListView.DataContext;
        if (upCum01PViewContainer!= null) { 
            if (System.Windows.Forms.MessageBox.Show(" Update New Fields, Records: " + upCum01PViewContainer.Count  + " ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){        
        
                model.cursorWait();                            
                //model.getCoreFactory().adjustNewShipExportFields(upCum01PViewContainer);

                ShipExportSumContainer shipExportSumContainer = model.getCoreFactory().createShipExportSumNewFields(upCum01PViewContainer);
                model.cursorNormal();

                MessageBox.Show("Records Updated: " + shipExportSumContainer.Count);
            }
        }*/

    } catch (Exception ex) {
        MessageBox.Show("exportAutoButton_Click Exception: " + ex.Message);        
    }finally{        
        model.cursorNormal();
    }
}

private 
void exportAuto(){
    try { 
        string      splant      = (string)model.getSelectedComboBoxItem(plantCTComboBox);
        DateTime    fromDate    = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate      = model.getSelectedDateTime(toDatePicker);

        model.cursorWait();
        ShipExportContainer shipExportContainer =model.getCoreFactory().processShipExportAutomatically("");

        model.cursorNormal();
        MessageBox.Show("Exported :" + shipExportContainer.Count);

    } catch (Exception ex) {
        MessageBox.Show("exportAuto Exception: " + ex.Message);        
    }finally{
        model.cursorNormal();
    }
}

private 
void adjustLeadTimeButton_Click(object sender, RoutedEventArgs e){
    model.adjustLeadTime(itransferTabIndex==3);
}

private 
void adjustLeadTime2Button_Click(object sender, RoutedEventArgs e){
    model.adjustLeadTime2((Person)leadTabItem.DataContext);
}

private
void shipExportSumListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    model.editSum();
}

private 
void compareCheckBox_Click(object sender, RoutedEventArgs e){
    searchShipExportSum(); 
}


}
}
