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
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace HotListReports.Windows.Demand{

    
/// <summary>
/// Interaction logic for CapShiftTaskWindow.xaml
/// </summary>
public partial 
class CapShiftTaskWindow : Window{

private CapShiftTaskModel model;
private int itabIndex;
private CapShiftTask capShiftTask;
private ButtonsListViewFunctions buttonsListViewFunctions;
private bool badding;
private bool bmodeSelect;


public 
CapShiftTaskWindow(bool bmodeSelect){
    InitializeComponent();
    this.bmodeSelect = bmodeSelect;

    this.itabIndex = 0;
    this.capShiftTask = null;  
    this.badding=false;
    this.model = new CapShiftTaskModel(this);  
}

public
CapShiftTask getCapShiftTask(){
    return (CapShiftTask)model.getSelected(this.hdrListView);
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}
    
private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
}

private 
void initialize(){        
    try {          
        buttonsListViewFunctions = new ButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);

        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords; 
        model.loadSearchByCombo(searchByComboBox);
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadDirIndCombo(this.dirIndComboBox,true);
        model.loadDirIndCombo(this.dirIndDtlComboBox,false);   
        model.loadYesNoComboBox(manufactComboBox,false);
        model.loadYesNoComboBox(empTempCanPerformComboBox, false);

        model.screenFullArea();                   
        search();           

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
void ok(){  
    this.DialogResult = true;
    Close();
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    if (bmodeSelect)
        ok();
    else{
        badding=false;
        mainTabControl.SelectedItem = this.dtlTabItem;
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

private 
void mainTabControlSelectionChanged(){
    try {
        int indexSel    = mainTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;
                       
            if (indexSel == 0){                
                search();
            }else if (indexSel == 1){
                                
                if (ipriorIndex == 0){
                    if (!badding)
                        capShiftTask = (CapShiftTask)model.getSelected(hdrListView);                                             
                    if (capShiftTask != null)
                        loadCapacityH();
                    else
                        mainTabControl.SelectedItem = this.viewTabItem;
                }

            }           
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }

}

private
void  loadCapacityH(){
    this.dtlTabItem.DataContext = null; //clear info
    this.dtlTabItem.DataContext = capShiftTask;
    this.taskNameTextBox.Focus();
    this.badding=false;
}

private 
void search(){    
    try{
        int         irows       = model.getRecords(recordsTextBox);
        string      sid         = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";
        string      staskName   = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : "";
        string      sdirInd     = model.getSelectedComboBoxItemString(dirIndComboBox);

        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";
        if (!string.IsNullOrEmpty(staskName))        
            staskName = staskName + "%";

        CapShiftTaskContainer capShiftTaskContainer = model.getCoreFactory().readCapShiftTaskByFilters(sid,staskName,sdirInd, irows);
        model.setDataContextListView(hdrListView,capShiftTaskContainer);        
        model.setSelected(hdrListView,capShiftTask);

        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        capShiftTask=null;
    }                                                       
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
    try{
        this.badding=true;
        this.model.add(out capShiftTask);         
        mainTabControl.SelectedItem = dtlTabItem;
        this.taskNameTextBox.Focus();
                                           
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}
        
private 
void del(){            
    if (this.model.del(hdrListView))                    
        search();
}          

private 
void okButton_Click(object sender, RoutedEventArgs e){
    save();
}

private 
void save(){        
    if (model.save(capShiftTask, taskNameTextBox, dirIndDtlComboBox))           
        mainTabControl.SelectedItem = viewTabItem;                                                                             
}          

private
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}

private 
void cancel(){    
    try{
        mainTabControl.SelectedItem = viewTabItem;            
    }catch (Exception ex){
        MessageBox.Show("cancel Exception: " + ex.Message);
    }                       
} 


       
}
}
