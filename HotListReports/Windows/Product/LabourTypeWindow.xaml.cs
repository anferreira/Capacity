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

namespace HotListReports.Windows.Products{
/// <summary>
/// Interaction logic for LabourTypeWindow.xaml
/// </summary>
public partial 
class LabourTypeWindow : Window{

private LabourTypeModel model;
private int itabIndex;
private bool baddDtl;

public LabourTypeWindow(){
    InitializeComponent();
    model = new LabourTypeModel(this);    
    this.itabIndex =0;    
    this.baddDtl = false;    
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
    try{                
        model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);
        model.loadSearchByCombo(searchByComboBox);
        model.loadDirIndCombo(dirIndDtlComboBox,false);
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.screenFullArea();
        search();
        
    }catch (Exception ex){
        MessageBox.Show("initialize Exception: " + ex.Message);
    }
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    baddDtl = false;
    mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void dtlListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){

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
                    if (!baddDtl){
                        labourType =  (LabourType)model.getSelected(hdrListView);                                                                     
                        if (labourType != null)
                            load(labourType);
                        else
                            mainTabControl.SelectedItem = this.hdrTabItem;
                    }  
                    setFocus();
                }                      
            }
        }
                 
    } catch (Exception ex) {        
        MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);  
    }

}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(){    
    try{
        baddDtl = false;

        int         irows   = model.getRecords(recordsTextBox);        
        string      scode   =searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : ""; 
        string      slabName=searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : ""; 
        string      sdirInd =searchByComboBox.SelectedIndex == 2 ? searchForTextBox.Text : "";         
            
        if (!string.IsNullOrEmpty(scode))        
            scode = scode + "%";  
        if (!string.IsNullOrEmpty(slabName))        
            slabName = slabName + "%";        
        if (!string.IsNullOrEmpty(sdirInd))        
            sdirInd = sdirInd + "%";        
         
        LabourTypeContainer labourTypeContainer = model.getCoreFactory().readLabourTypeByFilters(scode,slabName,sdirInd,irows);
        model.setDataContextListView(hdrListView,labourTypeContainer);                    
        hdrListView.Focus();
        
        if (labourType!= null)
            model.setSelected(hdrListView,labourType);

        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        labourType= null;
    }
}

private 
void addButton_Click(object sender, RoutedEventArgs e){
    add();
}

private 
void delButton_Click(object sender, RoutedEventArgs e){
    remove();
}

private 
void okDtlButton_Click(object sender, RoutedEventArgs e){
   save();
}

private 
void cancelDtlButton_Click(object sender, RoutedEventArgs e){
   mainTabControl.SelectedItem = this.hdrTabItem;
}

private 
void save(){
    try{
        if (dataOk()){                                                                
            model.save(labourType);    
            mainTabControl.SelectedItem = this.hdrTabItem;                        
        }
    }catch (Exception ex){
        MessageBox.Show("saveLabourType Exception: " + ex.Message);
    }
}

private 
bool dataOk(){    
    bool                bresult=true;
                
    if (labourType!= null){ 
                /*
        labourType.Code = this.codeTextBox.Text;
        labourType.LabName = this.labNameTextBox.Text;        
        labourType.DirInd =(string)model.getSelectedComboBoxItem(dirIndDtlComboBox);
        */
    
        if (string.IsNullOrEmpty(labourType.Code)){
            MessageBox.Show("Please Entry Code Value.");
            codeTextBox.Focus();
            bresult=false;   
        }

        if (bresult && baddDtl){ //if adding,check if code alredy added   
            LabourTypeContainer labourTypeContainer = model.getCoreFactory().readLabourTypeByFilters(labourType.Code,"","",1);
            if (labourTypeContainer.Count > 0){  
                MessageBox.Show("Sorry, Labour Type Which Code :" + labourType.Code + " Already Added, Please Reenter.");
                codeTextBox.Focus();
                bresult=false;   
            }
        }

    }else
        bresult=false;  

    return bresult;
}

private
void load(LabourType labourType){    
    dtlTabItem.DataContext = null;        
    dtlTabItem.DataContext = labourType;        
    
    codeTextBox.IsEnabled = baddDtl;    
    setFocus();
}

private 
void add(){
    labourType = model.getCoreFactory().createLabourType();
    baddDtl=true;    
    load(labourType);
    mainTabControl.SelectedItem = dtlTabItem;    
}

private
void setFocus(){
    if (baddDtl)   
        codeTextBox.Focus();
    else
        labNameTextBox.Focus();   
}

private 
void remove(){
     if (model.remove(this.hdrListView))
        search();                 
}

}
}
