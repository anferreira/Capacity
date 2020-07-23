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
using Nujit.NujitERP.ClassLib.Core.Cms.PackSlips;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace HotListReports.Windows.Location{
/// <summary>
/// Interaction logic for DepartmentWindow.xaml
/// </summary>
public partial class DepartmentWindow : Window{

private DepartmentModel model;
private int itabIndex;
private Departament departament;

public DepartmentWindow(){
    InitializeComponent();

    this.model = new DepartmentModel(this);
    this.itabIndex = 0;
    this.departament=null;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {                                                                  
        model.getCoreFactory().getLocalDemandDCompareAllViewReportByFilters("01",DemandD.SOURCE_830,"","","","",
         DateTime.Now,DateTime.Now.AddDays(-14), DateTime.Now.AddDays(14),0);    

        model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);
        model.loadCombo(searchByComboBox,"Dept","Description");
        model.loadPlantCombo(plantComboBox,true);

        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadShiftTaskComboBox(dftLabTaskIdComboBox,true);   
                
        model.screenFullArea();        

        search();
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{        
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
                        
            if (indexSel == 0)
                search();            
            else
                loadDetail();            
        }        
         
    } catch (Exception ex) {
        MessageBox.Show("mainTabControlSelectionChanged error:" + ex.Message);
    }    
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){        
    mainTabControl.SelectedItem = dtlTabItem;
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(){    
    try{                
        int         irows   = model.getRecords(recordsTextBox);
        string      sdept   = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : ""; 
        string      sdes1   = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : "";
        string      splant  = model.getSelectedComboBoxItemString(plantComboBox);
        
        if (!string.IsNullOrEmpty(sdept))        
            sdept = sdept + "%";  
         if (!string.IsNullOrEmpty(sdes1))        
            sdes1 = sdes1 + "%";                  
               
        DepartamentContainer departamentContainer = model.getCoreFactory().readDepartamentsByFilters("",splant,sdept,sdes1,irows);
        model.setDataContextListView(hdrListView, departamentContainer);
        model.setSelected(hdrListView,this.departament);
        
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }                       
}  

private
void loadDetail(){
    try { 
        departament = (Departament)model.getSelected(hdrListView);
        if (departament!= null){
            dtlTabItem.DataContext = null;
            dtlTabItem.DataContext = departament;
        }else
            mainTabControl.SelectedItem = hdrTabItem;

    }catch (Exception ex){
        MessageBox.Show("loadDetail Exception: " + ex.Message);
    } 
}

private 
void okDtlButton_Click(object sender, RoutedEventArgs e){
    if (model.save(departament))
       mainTabControl.SelectedItem = hdrTabItem;
}

private 
void cancelDtlButton_Click(object sender, RoutedEventArgs e){
    if (model.cancel())                    
        mainTabControl.SelectedItem = hdrTabItem;        
}            

private 
void autoPlanButton_Click(object sender, RoutedEventArgs e){
    autoPlan();
}

private 
void autoPlan(){
    model.autoPlan(hdrListView);
}


}
}
