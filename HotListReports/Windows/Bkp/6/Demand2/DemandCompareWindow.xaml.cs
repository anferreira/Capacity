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

public 
DemandCompareWindow(){
    InitializeComponent();

    this.model = new DemandCompareModel(this);
    this.bloadScreen = true;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void initialize(){
    try {
        DateTime fromDate   = DateTime.Now.AddMonths(-3);
        DateTime toDate     = DateTime.Now.AddMonths(6);
        DateTime monday     = DateUtil.getPriorMondayCurrWeek();   

        this.fromDatePicker.SelectedDate= fromDate;
        this.toDatePicker.SelectedDate  = toDate;

        model.addButtonsListViewFunctions(this.compareListView, firstButton, prevButton, nextButton, lastButton);
        model.Cursor = this.Cursor;
        model.loadPlantCombo(plantComboBox,false);model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);
                       
        model.screenFullArea();
                
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){    
    search();
}

private 
void search(){
    try{
        DemandDCompareViewContainer demandDCompareViewContainer =  model.getCoreFactory().createDemandDCompareViewContainer();
        string      splant      = getPlantSel();
        string      stPartner   = getTPartnerSel();
        string      shipLoc     = getShipLocSel();
        string      spart       = partTextBox.Text;
        DateTime    fromDate    = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate      = model.getSelectedDateTime(toDatePicker);
        DateTime    runDate     = DateUtil.getPriorMondayCurrWeek();

        this.tPartnerTextBox.Text   = stPartner;
        this.shipLocSelTextBox.Text = shipLoc;
        this.partSelTextBox.Text    = spart;
        model.loadColumnsOnHeaderGrid(compareListView, runDate, runDate.AddDays(Constants.MAX_HOTLIST_DAYS));                

        if (dataOK(true)) {                        
            demandDCompareViewContainer = model.getCoreFactory().getDemandDCompareViewReportByFilters(
                                        splant, DemandD.SOURCE_830,stPartner, shipLoc, spart, runDate, fromDate,toDate,0);                               
        }
        model.setDataContextListView(compareListView, demandDCompareViewContainer);         

        dataGrid.DataContext = demandDCompareViewContainer;
        dataGrid.ItemsSource=demandDCompareViewContainer;
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
     
    }                                       
}

private
bool dataOK(bool bshowMessError){
    bool bresult=true;
    try{               
        string      splant      = getPlantSel();
        string      stPartner   = getTPartnerSel();
        string      shipLoc     = getShipLocSel();
        string      spart       = partTextBox.Text;
        DateTime    fromDate    = model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate      = model.getSelectedDateTime(toDatePicker);
        string      smessError  = "";
        
        if (string.IsNullOrEmpty(splant)) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Plant";
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
        
        if ( toDate < fromDate) {            
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
string getPartSel(){                      
    string      spart = model.getSelectedComboBoxItemString(partComboBox);
    return spart;
}

private 
void partSearchButton_Click(object sender, RoutedEventArgs e){    
    model.searchPart(partTextBox);
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadTradingPartners(tPartnerComboBox,getPlantSel());
}

private 
void tPartnerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadShipLocs(shipLocComboBox,getPlantSel(),getTPartnerSel());
}

private 
void shipLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadParts(partComboBox,getPlantSel(),getTPartnerSel(),getShipLocSel());
}

private 
void partComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    partComboBoxSelectionChanged();
}

private 
void partComboBoxSelectionChanged() {
    try { 
        partTextBox.Text = getPartSel();
        if (dataOK(false)){
            search();
        }
    }catch (Exception ex){
        MessageBox.Show("partComboBoxSelectionChanged Exception: " + ex.Message);
    }finally{
        bloadScreen=false;
    }
}


}
}
