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
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Util;
using FarsiLibrary.FX.Win.Controls;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace HotListReports.Windows.Inventories{

/// <summary>
/// Interaction logic for SeriWindow.xaml
/// </summary>
public partial 
class SeriWindow : Window{

private SeriModel   model;
private string      spartFilter;
private int         iseqFilter;
private string      splantFilter;

public SeriWindow(string spartFilter, int iseqFilter,string splantFilter){
    InitializeComponent();

    this.model = new SeriModel(this);
    this.spartFilter= spartFilter;
    this.iseqFilter = iseqFilter;   
    this.splantFilter = splantFilter;                
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

public
Seri getSelected(){
    Seri seri = (Seri)model.getSelected(this.seriListView);
    return seri;
}

private 
void initialize(){
    try{        
        partTextBox.Text = spartFilter;
        model.loadColumnsOnHeaderGrid(this.seriListView);

        model.loadPlantCombo(plantFilterComboBox, false);model.setSelectedComboBoxItem(plantFilterComboBox,splantFilter);

        model.loadCombo(searchByComboBox,"Serial Num","Lot");
        model.loadStatus(statusFilterComboBox);

                /*
        model.loadPlantCombo(plantFilterComboBox,true); model.setSelectedComboBoxItem(plantFilterComboBox,Configuration.DftPlant);
        model.loadPlantCombo(plantComboBox,false);

        model.loadStatusComboBox(statusFilterComboBox,true);
        model.loadStatusComboBox(statusComboBox,false);
        setListViewScrollsButtons();
        */
        model.screenFullArea();
                
        search();
        
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
 
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void seriListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    doubleClick();
}

private 
void doubleClick(){
    this.DialogResult = true;
    Close();
}

private 
void search(){        
    try{          
        model.cursorWait();

        int         irows           = model.getRecords(recordsTextBox);        
        string      status          = (string)model.getSelectedComboBoxItem(statusFilterComboBox);                    
        string      splant          = model.getSelectedComboBoxItemString(plantFilterComboBox); 
        string      spart           = partTextBox.Text;
        DateTime    startActivDate  = model.getSelectedDateTime(fromDatePicker);
        DateTime    endActivDate    = model.getSelectedDateTime(toDatePicker);
        string      serialNum       = model.getSearchFromComboBoxString(searchByComboBox, searchForTextBox,0);
        string      slot            = model.getSearchFromComboBoxString(searchByComboBox, searchForTextBox,1);
        string      suppSerial      = "";
        string      smasterSerial   = "";
        string      stockLoc        = "";
        string      statusList      = "";
            
        if (!string.IsNullOrEmpty(serialNum))        
            serialNum = serialNum + "%";        
        if (!string.IsNullOrEmpty(slot))        
            slot = slot + "%";        
               
        SeriContainer seriContainer = model.getCoreFactory().readSeriCMSByFilters(spart, serialNum, slot, suppSerial, smasterSerial, splant, stockLoc, startActivDate, endActivDate, statusList,false,"",irows);   
        model.setDataContextListView(seriListView,seriContainer);
        this.searchForTextBox.Focus();

    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{        
        model.cursorNormal();
    }              
} 



}
}
