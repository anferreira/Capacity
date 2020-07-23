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
/// Interaction logic for ToolWindow.xaml
/// </summary>
public partial 
class ToolWindow : Window{

private ToolModel model;

public ToolWindow(){
    InitializeComponent();
    model = new ToolModel(this);
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
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.screenFullArea();
        search();
        
    }catch (Exception ex){
        MessageBox.Show("initialize Exception: " + ex.Message);
    }
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    
}

private 
void dtlListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){

}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){

}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(){    
    try{
        int         irows   = model.getRecords(recordsTextBox);        
        string      scompany= searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : ""; 
        string      splant  = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : ""; 
        string      stool   = searchByComboBox.SelectedIndex == 2 ? searchForTextBox.Text : "";         
        string      sdesc   = searchByComboBox.SelectedIndex == 3 ? searchForTextBox.Text : "";         
            
        if (!string.IsNullOrEmpty(scompany))        
            scompany = scompany + "%";  
        if (!string.IsNullOrEmpty(splant))        
            splant = splant + "%";        
        if (!string.IsNullOrEmpty(stool))        
            stool = stool + "%";        
        if (!string.IsNullOrEmpty(sdesc))        
            sdesc = sdesc + "%";        
         
        string[][] items = model.getCoreFactory().readToolByFilters(scompany,splant,stool,sdesc,irows);        
        model.setDataContextListView(this.hdrListView,items);
        
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        
    }
}     
  
}
}
