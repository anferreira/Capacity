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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Util;

namespace HotListReports.Windows.ShiftProfile{
    /// <summary>
    /// Interaction logic for CapProfileHolidayWindow.xaml
    /// </summary>
public partial 
class CapProfileHolidayWindow : Window{

private CapProfileHolidayModel model;
private int itabIndex;
private CapProfileHoliday capProfileHoliday;
private bool badd;

public 
CapProfileHolidayWindow(){
    InitializeComponent();

    this.model = new CapProfileHolidayModel(this);
    this.itabIndex = 0;
    this.capProfileHoliday = null;
    this.badd = false;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
   initialize();
}

private 
void initialize(){        
    try {                    
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;

        model.addButtonsListViewFunctions(hdrListView,firstButton,prevButton,nextButton,lastButton);
        
        model.loadCombo(searchByComboBox,"Id");       
        model.loadPlantCombo(plantFilterComboBox,true); model.setSelectedComboBoxItem(plantFilterComboBox,  Configuration.DftPlant);
        model.loadPlantCombo(plantComboBox,false);      model.setSelectedComboBoxItem(plantComboBox,        Configuration.DftPlant);

        model.loadHolidayType(typeFilterComboBox,true);
        model.loadHolidayType(holTypeComboBox,false);
        
        model.loadColumnsOnHeaderGrid(hdrListView);                
        
        model.screenFullArea();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void search(){    
    try{
        int         irows   = model.getRecords(recordsTextBox);
        string      sid     = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";        
        string      splant  = model.getSelectedComboBoxItemString(plantFilterComboBox);
        string      stype   = model.getSelectedComboBoxItemString(typeFilterComboBox);
        DateTime    fromDate= model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate  = model.getSelectedDateTime(toDatePicker);          
        
        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";        
         
        CapProfileHolidayContainer capProfileHolidayContainer = model.getCoreFactory().readCapProfileHolidayByFilters(sid, splant,stype,fromDate,toDate,irows);

        model.setDataContextListView(hdrListView,capProfileHolidayContainer);        
        model.setSelected(hdrListView,capProfileHoliday);
        this.searchForTextBox.Focus();
                    
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    } finally{
        capProfileHoliday=null;      
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
                        
            if (indexSel == 0){
                this.badd = false;                                            
                search();
            }else if (indexSel == 1){                                                     

                if (!badd)                                                
                    capProfileHoliday = (CapProfileHoliday)model.getSelected(hdrListView);                                             

                if (capProfileHoliday != null)
                    loadCapProfileHoliday(capProfileHoliday);
                else
                    mainTabControl.SelectedItem = this.hdrTabItem;                
            }       
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }

}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    badd=false;
    mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void addButton_Click(object sender, RoutedEventArgs e){
    add();
}

private 
void delButton_Click(object sender, RoutedEventArgs e){
    del();
}

private 
void add(){
    try { 
        badd=true;
        model.add(out capProfileHoliday);        
        mainTabControl.SelectedItem = dtlTabItem;
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }
}

private 
void del(){
    try { 
        if (model.del(hdrListView))
            search();
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }
}

private
void loadCapProfileHoliday(CapProfileHoliday capProfileHoliday){
    this.dtlTabItem.DataContext = null;
    this.dtlTabItem.DataContext = capProfileHoliday;
    model.CapProfileHoliday = capProfileHoliday;
}

private 
void okButton_Click(object sender, RoutedEventArgs e){
    save();
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    if (model.cancel())
        mainTabControl.SelectedItem =hdrTabItem;
}

private 
void startDateTimeDateTimePicker_LostFocus(object sender, RoutedEventArgs e){    
    model.adjustEndDate();    
}
        
private
bool dataOk(){    
    bool    bresult=true;
    
    if (capProfileHoliday == null)
        return false;        

    if (string.IsNullOrEmpty(capProfileHoliday.Plant)) { 
        MessageBox.Show("Plese, Select Plant.");
        plantComboBox.Focus();
        bresult=false;
    }

    if (capProfileHoliday.StartDate > capProfileHoliday.EndDate) { 
        MessageBox.Show("End Date Might Be Bigger Than Start Date.");
        endDateTimeDateTimePicker.Focus();
        bresult=false;
    }


    if (bresult){ 
        CapProfileHolidayContainer  capProfileHolidayContainer = model.getCoreFactory().readCapProfileHolidayByFilters("",capProfileHoliday.Plant,"",capProfileHoliday.StartDate,capProfileHoliday.EndDate,1);
        CapProfileHoliday           capProfileHolidayFound = null;
        
        if (capProfileHolidayContainer.Count > 0){
            capProfileHolidayFound = capProfileHolidayContainer[0];

            if (badd)                                                       bresult=false;
            else if (capProfileHolidayFound.Id != capProfileHoliday.Id)     bresult=false;
                
            if (!bresult){
                MessageBox.Show("Sorry, Already Exists Record On That Range Dates.\n" + 
                                " Id : " + capProfileHolidayFound.Id.ToString() +  " Dates :" + DateUtil.getCompleteDateRepresentation(capProfileHolidayFound.StartDate,DateUtil.MMDDYYYY) + "-" + DateUtil.getCompleteDateRepresentation(capProfileHolidayFound.EndDate,DateUtil.MMDDYYYY));
            }
        }
    }     

    return bresult;
}
    
private
void save(){
    try{ 
        if (dataOk()) {             
            model.save();            
            badd=false;            
            mainTabControl.SelectedItem = hdrTabItem;
        }    

    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }                       
} 

private 
void autoWeekButton_Click(object sender, RoutedEventArgs e){
    autoWeek();
}

private 
void autoWeek(){
    try { 
        string      splant  = model.getSelectedComboBoxItemString(plantFilterComboBox);
        if (model.autoWeekCurrentYear(splant))
            search();    
    }catch (Exception ex){
        MessageBox.Show("autoWeek Exception: " + ex.Message);
    }
}



}
}
