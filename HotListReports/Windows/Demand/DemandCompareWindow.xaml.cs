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
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core.Cms;


namespace HotListReports.Windows.Demand{
/// <summary>
/// Interaction logic for DemandCompareWindow.xaml
/// </summary>
public partial class DemandCompareWindow : Window{

private DemandCompareModel  model;
private bool                bloadScreen;
private int                 itabIndex;

public 
DemandCompareWindow(){
    InitializeComponent();

    this.model      = new DemandCompareModel(this, compareListView, reportCompareListView, localCompareListView, localCompareAllDiffListView);
    this.bloadScreen= true;
    this.itabIndex  = 0;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void initialize(){
    try {
        displayFromDatePicker.SelectedDateChanged-=displayFromDatePicker_SelectedDateChanged;
        sourceComboBox.SelectionChanged-= sourceComboBox_SelectionChanged;

        displayFromDatePicker.Background = new SolidColorBrush(UIColors.COLOR_SELECT);

        DateTime fromDate   = DateTime.Now.AddDays(-7);
        DateTime toDate     = DateTime.Now.AddMonths(1);
        DateTime monday     = DateUtil.getPriorMondayCurrWeek();   

        this.displayFromDatePicker.SelectedDate = DateTime.Now;
        this.fromDatePicker.SelectedDate= fromDate;
        this.toDatePicker.SelectedDate  = toDate;

        model.addButtonsListViewFunctions(this.compareListView,         firstButton, prevButton, nextButton, lastButton);
        model.addButtonsListViewFunctions(this.reportCompareListView,   firstRButton,prevRButton,nextRButton,lastRButton);
        model.addButtonsListViewFunctions(this.localCompareListView,    firstLRButton,prevLRButton,nextLRButton,lastLRButton);
        model.addButtonsListViewFunctions(this.localCompareDateListView, firstLDRButton, prevLDRButton, nextLDRButton, lastLDRButton);
        model.addButtonsListViewFunctions(this.localCompareAllDiffListView,    firstLRAButton,prevLRAButton,nextLRAButton,lastLRAButton);
        
        model.Cursor = this.Cursor;
        model.loadDemandSourceCombo(sourceComboBox,false,false);
        model.loadPlantCombo(plantComboBox,false);model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);
                               
        model.screenFullArea();
                
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{
        displayFromDatePicker.SelectedDateChanged+=displayFromDatePicker_SelectedDateChanged;
        sourceComboBox.SelectionChanged+= sourceComboBox_SelectionChanged;
    }
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    mainTabControlSelectionChanged();
}
       
private 
void mainTabControlSelectionChanged(){
    try {
        int indexSel    = mainTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;

            showHideTrnasferScrollButtons(indexSel);
            model.loadTradingPartners(tPartnerComboBox,true,getPlantSel(),getSourceSel());                       

            if (indexSel == 0){
            
            }else if (indexSel == 1){            
            }else if (indexSel == 4){
                if (localCompareAllDiffListView.Items.Count <=0)
                    search();
            }
        }
         
    } catch (Exception ex) {
       MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);     
    }
}

private
void showHideTrnasferScrollButtons(int itabIndex){
    firstButton.Visibility      = prevButton.Visibility    = nextButton.Visibility    = lastButton.Visibility    = itabIndex == 0 ? Visibility.Visible : Visibility.Hidden;
    firstRButton.Visibility     = prevRButton.Visibility   = nextRButton.Visibility   = lastRButton.Visibility   = itabIndex == 1 ? Visibility.Visible : Visibility.Hidden;    
    firstLRButton.Visibility    = prevLRButton.Visibility  = nextLRButton.Visibility  = lastLRButton.Visibility  = itabIndex == 2 ? Visibility.Visible : Visibility.Hidden;
    firstLDRButton.Visibility   = prevLDRButton.Visibility = nextLDRButton.Visibility = lastLDRButton.Visibility = itabIndex == 3 ? Visibility.Visible : Visibility.Hidden;
    firstLRAButton.Visibility   = prevLRAButton.Visibility = nextLRAButton.Visibility = lastLRAButton.Visibility = itabIndex == 4 ? Visibility.Visible : Visibility.Hidden;    
}  

private 
void searchButton_Click(object sender, RoutedEventArgs e){    
    search();
}

private 
void search(){
    try{
        model.cursorWait();
        DemandDCompareViewContainer         demandDCompareViewContainer     =  model.getCoreFactory().createDemandDCompareViewContainer();
        DemandDCompareLeftViewContainer     demandDCompareLeftViewContainer = null;
        string      splant          = getPlantSel();
        string      stPartner       = getTPartnerSel();
        string      shipLoc         = getShipLocSel();
        string      spart           = partTextBox.Text;
        string      source          = getSourceSel();
        DateTime    displayFromDate = model.getSelectedDateTime(this.displayFromDatePicker);
        DateTime    fromDate        = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate          = model.getSelectedDateTime(toDatePicker);
        DateTime    runDate         = displayFromDate == DateUtil.MinValue || DateUtil.sameDate(displayFromDate, DateTime.Now) ? DateUtil.getPriorMondayFromDate(DateTime.Now) : displayFromDate;        
        ListView    listView        = model.getListView(itabIndex);
        bool        bcolumnsWQty    = (bool)columnsWithInfoCheckBox.IsChecked;
        bool        bcumulative     = (bool)cumulativeCheckBox.IsChecked; 
        bool        bqtyDifferences = (bool)qtyDifferencesCheckBox.IsChecked; 
        bool        ballParts       = (bool)localCompareAllDiffAllPartsCheckBox.IsChecked; 
        bool        bshowOnlyDiffer = (bool)localCompareAllDiffShowDifferencesCheckBox.IsChecked; 

        this.sourceSelTextBox.Text  = source;
        this.tPartnerTextBox.Text   = stPartner;
        this.shipLocSelTextBox.Text = shipLoc;
        this.partSelTextBox.Text    = spart;

        model.loadColumnsOnHeaderGrid(listView,runDate,runDate.AddDays(Constants.MAX_HOTLIST_DAYS));                                      

        if (dataOK(true)) {         
            model.setRunDate(itabIndex,runDate);
            
            if (itabIndex == 0) {                 
                demandDCompareViewContainer = model.getCoreFactory().getDemandDCompareViewReportByFilters(
                                        splant, source, stPartner, shipLoc, spart, runDate, fromDate,toDate,bcumulative,0);                               
            }else if (itabIndex == 1){                
                demandDCompareViewContainer = model.getCoreFactory().getAS400DemandDCompareViewReportByFilters(
                                        splant, source, stPartner, shipLoc, spart, runDate, fromDate,toDate, bcumulative,0);                         
                        /*
                DemandDCompareViewContainer demandDCompareViewContainer2 = model.getCoreFactory().getAS400DemandDCompareViewReportBoldByFilters(
                                        splant, source, stPartner, shipLoc, spart, runDate, fromDate,toDate, bcumulative,0); */                                          
             }else if (itabIndex == 2 || itabIndex == 3) {                
                demandDCompareViewContainer = model.getCoreFactory().getLocalDemandDCompareViewReportByFilters(
                                    splant, source, stPartner, shipLoc, spart, runDate, fromDate, toDate, bcumulative, bqtyDifferences, 0);                
                //if (!bcumulative)
                    //demandDCompareViewContainer.calculateNetsQty(runDate);
                if (itabIndex == 3) { 
                    demandDCompareLeftViewContainer = demandDCompareViewContainer.convertToDatesLeftSide(runDate);
                    if (bcolumnsWQty)
                        demandDCompareLeftViewContainer.removeWithoutQty();                                            
                }                
            }else if (itabIndex == 4){
                demandDCompareViewContainer = model.getCoreFactory().getLocalDemandDCompareAllViewReportByFilters3(
                    splant,source, stPartner, ballParts ? "" : shipLoc, ballParts ? "" : spart, "", runDate, fromDate, toDate, bshowOnlyDiffer, bqtyDifferences, bcumulative, bcolumnsWQty, 0);
                    
                model.rewriteDemandCompareViewColumns(localCompareAllDiffListView,(DemandDCompareReportViewContainer)demandDCompareViewContainer,runDate, bcolumnsWQty);
                if (bcumulative)   
                    ((DemandDCompareReportViewContainer)demandDCompareViewContainer).showFullCumulativeQty();
            }
        }        

        if (bcolumnsWQty){
            if (itabIndex != 3 && itabIndex != 4) { 
                model.loadColumnsOnHeaderGrid(listView ,runDate, runDate.AddDays(Constants.MAX_HOTLIST_DAYS),runDate,demandDCompareViewContainer);                        
                demandDCompareViewContainer.adjustZeroValues(runDate);
            }
        }

        if (bqtyDifferences && (itabIndex >=0 && itabIndex <=1) )
            model.getCoreFactory().processDemandDCompareViewNetQtyDifferences(bcumulative,runDate, demandDCompareViewContainer);

        if (itabIndex == 3){
            model.loadColumnsOnHeaderLeftDatesGrid(localCompareDateListView,demandDCompareLeftViewContainer);
            model.setDataContextListView(localCompareDateListView,          demandDCompareLeftViewContainer);
        }else
            model.setDataContextListView(listView, demandDCompareViewContainer);               
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        model.cursorNormal();
    }                                       
}

private
bool dataOK(bool bshowMessError){
    bool bresult=true;
    try{                      
        string      splant          = getPlantSel();
        string      source          = getSourceSel();
        string      stPartner       = getTPartnerSel();
        string      shipLoc         = getShipLocSel();
        string      spart           = partTextBox.Text;
        DateTime    displayFromDate = model.getSelectedDateTime(this.displayFromDatePicker);
        DateTime    fromDate        = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate          = model.getSelectedDateTime(toDatePicker);
        string      smessError      = "";

        if (displayFromDate == DateUtil.MinValue) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Display From Date";
            bresult=false;
        }
        
        if (string.IsNullOrEmpty(splant)) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Plant";
            bresult=false;
        }

        if (itabIndex != 4) { 
            if (string.IsNullOrEmpty(source)) {            
                smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Source";
                bresult=false;
            }

            if (string.IsNullOrEmpty(stPartner)) {            
                smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Trading Partner";                               
                bresult=false;
            }

            if (string.IsNullOrEmpty(shipLoc)) {            
                smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "ShipTo Location";
                bresult=false;
            }

            if (string.IsNullOrEmpty(partTextBox.Text)) {
                smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Part";
                bresult=false;
            }
        }
        
        if (fromDate == DateUtil.MinValue) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "From Date";
            bresult=false;
        }else if (toDate == DateUtil.MinValue) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "To Date";
            bresult=false;
        }else if ( toDate < fromDate) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "To Release Date Bigger Than From";
            bresult=false;
        }

        if (!string.IsNullOrEmpty(smessError) && bshowMessError)
            MessageBox.Show("Please Select : \n" + smessError);
            
    }catch (Exception ex){
        MessageBox.Show("dataOK Exception: " + ex.Message);
    }finally{
     
    }    
    return bresult;
}
        
private
string getPlantSel(){                      
    string      splant  = model.getSelectedComboBoxItemString(plantComboBox);
    return splant;
}

private
string getTPartnerSel(){                      
    string      stp     = model.getSelectedComboBoxItemString(tPartnerComboBox); ;
    return stp;
}

private
string getShipLocSel(){                      
    string      shipLoc = model.getSelectedComboBoxItemString(shipLocComboBox);
    return shipLoc;
}

private
string getSourceSel(){                      
    string      source = model.getSelectedComboBoxItemString(sourceComboBox);
    return source;
}


private
string getPartSel(){                      
    string      spart = model.getSelectedComboBoxItemString(partComboBox);
    return spart;
}

private 
void partSearchButton_Click(object sender, RoutedEventArgs e){    
    partSearch();
}

private 
void partSearch(){    
    if (model.searchPart(partTextBox) != null && dataOK(false))
        search();        
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadTradingPartners(tPartnerComboBox,itabIndex>=1,getPlantSel(),getSourceSel());
}

private 
void sourceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    model.loadTradingPartners(tPartnerComboBox,itabIndex>= 1,getPlantSel(),getSourceSel());
}

private 
void tPartnerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadShipLocs(shipLocComboBox,itabIndex>= 1,getPlantSel(),getSourceSel(),getTPartnerSel());
}

private 
void shipLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadParts(partComboBox,itabIndex>= 1,getPlantSel(),getSourceSel(),getTPartnerSel(),getShipLocSel());
}

private 
void partComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    partComboBoxSelectionChanged();
}

private 
void partComboBoxSelectionChanged() {
    try { 
        partTextBox.Text = getPartSel();
        ifOKSearch();
    }catch (Exception ex){
        MessageBox.Show("partComboBoxSelectionChanged Exception: " + ex.Message);
    }finally{
        bloadScreen=false;
    }
}

private
void ifOKSearch(){
    if (dataOK(false) && itabIndex != 4){
        search();
    }
}

private 
void displayFromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e){
    displayFromDatePickerSelectedDateChanged();
}

private 
void displayFromDatePickerSelectedDateChanged(){
    ifOKSearch();
}

private 
void nextPartButton_Click(object sender, RoutedEventArgs e){    
    nextPart();
}

private 
void nextPart(){
   try { 
        int  index = partComboBox.SelectedIndex;

        if (partComboBox.Items.Count > 0){
            if (index >=0 && (index+1) < partComboBox.Items.Count)
                partComboBox.SelectedIndex = index + 1;
            else
                partComboBox.SelectedIndex = 0;
        }        
    }catch (Exception ex){
        MessageBox.Show("nextPart Exception: " + ex.Message);
    }finally{        
    }         
}

private 
void columnsWithInfoCheckBox_Click(object sender, RoutedEventArgs e){
    columnsWithInfoCheckBoxClick();
}

private 
void columnsWithInfoCheckBoxClick(){
    try { 
        ListView    listView        =  model.getListView(itabIndex);
        bool        bcolumnsWQty    = (bool)columnsWithInfoCheckBox.IsChecked;
        DateTime    runDate         = model.getRunDate(itabIndex);
        DemandDCompareViewContainer demandDCompareViewContainer = model.getCoreFactory().createDemandDCompareViewContainer();

        if (itabIndex == 4)
            search();
        else {
            if (listView.DataContext != null){
                demandDCompareViewContainer = (DemandDCompareViewContainer)listView.DataContext;
                if (bcolumnsWQty)
                    model.loadColumnsOnHeaderGrid(listView, runDate, runDate.AddDays(Constants.MAX_HOTLIST_DAYS), runDate, demandDCompareViewContainer);
                else
                    model.loadColumnsOnHeaderGrid(listView, runDate, runDate.AddDays(Constants.MAX_HOTLIST_DAYS));                                                            
            }   
            model.setDataContextListView(listView, demandDCompareViewContainer);     
        }

    }catch (Exception ex){
        MessageBox.Show("columnsWithInfoCheckBoxClick Exception: " + ex.Message);
    }finally{        
    } 
}

private 
void cumulativeCheckBox_Click(object sender, RoutedEventArgs e){
    search();    
}

private 
void qtyDifferencesCheckBox_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void exportButton_Click(object sender, RoutedEventArgs e){    
    export();
}

private 
void export(){     
    try { 
        ListView    listView        = model.getListView(itabIndex); 
        DateTime    runDate         = model.getRunDate(itabIndex);
        string      stitle          = mainTabControl.SelectedItem != null ? (string)((TabItem)mainTabControl.SelectedItem).Header : "";
        bool        bcolumnsWQty    = (bool)columnsWithInfoCheckBox.IsChecked;
        DemandDCompareViewContainer demandDCompareViewContainer = model.getCoreFactory().createDemandDCompareViewContainer();

        if (listView.DataContext != null && listView.DataContext is DemandDCompareViewContainer){
            model.exportExcel(listView,stitle, itabIndex,bcolumnsWQty);          
        }           
    }catch (Exception ex){
        MessageBox.Show("export Exception: " + ex.Message);
    }finally{        
    } 
} 

}
}
