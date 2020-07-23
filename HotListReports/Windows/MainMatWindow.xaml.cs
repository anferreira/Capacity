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

namespace HotListReports.Windows{
/// <summary>
/// Interaction logic for MainMatWindow.xaml
/// </summary>
public partial class MainMatWindow : Window{

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private MainMatContainer mainMatContainer;

public MainMatWindow(){
    InitializeComponent();
    mainMatContainer=null;
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    closing();
}

private 
void closing(){
    if (coreFactory!=null)
        coreFactory=null;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void initialize(){
    try {
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        loadSearchByCombo();
        search();

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
void loadSearchByCombo(){
    searchByComboBox.Items.Add("Part");
    searchByComboBox.Items.Add("Main Material");

    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}
        
private 
void search(){
    try{
        int    irows    = Nujit.NujitERP.ClassLib.Util.NumberUtil.isIntegerNumber(recordsTextBox.Text) ? Convert.ToInt32(recordsTextBox.Text) : 50;
        string spart    = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";
        string smainMat = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : "";

        mainMatContainer = coreFactory.readMainMatByFilters(spart, smainMat,false, irows);

        this.mainListView.DataContext= mainMatContainer;                
        this.mainListView.ItemsSource= mainMatContainer;     

        recordsTextBox.Text = irows.ToString();
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("MainMaterial search Exception: " + ex.Message);
    }                       
}

private 
void addButton_Click(object sender, RoutedEventArgs e){
    add();
}


private 
void delButton_Click(object sender, RoutedEventArgs e){
    deleteItem();
}
      
private 
void add(){
    try{
        MainMat mainMatAux = coreFactory.createMainMat();
        if (mainMatAux!=null){
            AddMainMaterialWindow addMainMaterialWindow = new AddMainMaterialWindow(mainMatAux,false);
            if (addMainMaterialWindow.ShowDialog() == true)
                search();
        }
    }catch (Exception ex){
        MessageBox.Show("MainMaterial add Exception: " + ex.Message);
    }
}

private 
void delete(){
    try{
        MainMat mainMatAux = coreFactory.createMainMat();
        if (mainMatAux!=null){
            AddMainMaterialWindow addMainMaterialWindow = new AddMainMaterialWindow(mainMatAux,false);
            if (addMainMaterialWindow.ShowDialog() == true)
                search();
        }
    }catch (Exception ex){
        MessageBox.Show("MainMaterial delete Exception: " + ex.Message);
    }
}
        
private void 
mainListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    addChild();
}

private 
void addChildButton_Click(object sender, RoutedEventArgs e){
    addChild();
}

private 
void editButton_Click(object sender, RoutedEventArgs e){
    editItem();
}

private 
void addChild(){
    try{
        MainMat mainMat = getSelected();
        if (mainMat != null){

            mainMat = coreFactory.readMainMat(mainMat.PART);
            if  (mainMat != null){                
                AddMainMaterialWindow addMainMaterialWindow = new AddMainMaterialWindow(mainMat,true);                
                if (addMainMaterialWindow.ShowDialog() == true)
                    search();
            }
        }else
            MessageBox.Show("Please, Select Item First.");
    }catch (Exception ex){
        MessageBox.Show("MainMaterial addChild Exception: " + ex.Message);
    }
}

private 
void deleteItem(){
    try{
        MainMat mainMatDelete = getSelected();
        if (mainMatDelete != null){
           
                MainMat mainMat = coreFactory.readMainMat(mainMatDelete.PART);
                if (mainMat!=null){
                    if (System.Windows.MessageBox.Show("Do You Wish To Delete Main Material " + mainMatDelete.PART + "/" + mainMatDelete.MAINPART +  " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                       
                        mainMatDelete = mainMat.MainMatContainer.getByMainMaterial(mainMatDelete.MAINPART);
                        if (mainMatDelete != null){
                            mainMat.MainMatContainer.Remove(mainMatDelete);
                            coreFactory.updateMainMat(mainMat);

                            MessageBox.Show("Main Material Deleted.");
                            search();
                        }
                    }
                }else
                    MessageBox.Show("Sorry, Can Not Find Main Material.");            
        }else
            MessageBox.Show("Please, Select Item First.");
    }catch (Exception ex){
        MessageBox.Show("MainMaterial deleteItem Exception: " + ex.Message);
    }
}

private 
void editItem(){
    try{
        MainMat mainMatChild = getSelected();
        if (mainMatChild != null){           
            MainMat mainMat = coreFactory.readMainMat(mainMatChild.PART);            
            
            if (mainMat != null){
                mainMatChild = mainMat.MainMatContainer.getByMainMaterial(mainMatChild.MAINPART);
                if (mainMatChild != null){
                    AddMainMaterialWindow addMainMaterialWindow = new AddMainMaterialWindow(mainMat, mainMatChild); 
                    if (addMainMaterialWindow.ShowDialog() == true)
                        search();                         
                }else
                    MessageBox.Show("Sorry, Can Not Find Main Material Child.");
            }else
                MessageBox.Show("Sorry,  Can Not Find Main Material.");

        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("MainMaterial deleteItem Exception: " + ex.Message);
    }
}


private
MainMat getSelected(){
    MainMat mainMat = null;
    if (mainListView.SelectedItems.Count > 0)
        mainMat = (MainMat)mainListView.SelectedItems[mainListView.SelectedItems.Count - 1];
    return mainMat;
}


private 
void firstButton_Click(object sender, RoutedEventArgs e){
    first();
}

private 
void prevButton_Click(object sender, RoutedEventArgs e){
    prev();
}

private 
void nextButton_Click(object sender, RoutedEventArgs e){
    next();
}

private 
void lastButton_Click(object sender, RoutedEventArgs e){
    last();
}


private 
void first(){
    if (mainListView.Items.Count > 0){
        mainListView.SelectedIndex = 0;
        mainListView.ScrollIntoView(mainListView.SelectedItem);        
    }
    mainListView.Focus();    
}

private 
void prev(){
    if (mainListView.Items.Count > 0){
        int selectedIndex = 0;
        if (mainListView.SelectedIndex > 0)
            selectedIndex = mainListView.SelectedIndex;
        int nextSelectedIndex = mainListView.Items.Count - 1;
        if (selectedIndex > 0){
            nextSelectedIndex = selectedIndex - 1;
        }
        mainListView.SelectedIndex = nextSelectedIndex;
        mainListView.ScrollIntoView(mainListView.SelectedItem);     
    }
    mainListView.Focus();
}

private 
void next(){
    if (mainListView.Items.Count > 0){
        int selectedIndex = 0;
        if (mainListView.SelectedIndex > 0)
            selectedIndex = mainListView.SelectedIndex;
        int nextSelectedIndex = 0;
        if (selectedIndex < mainListView.Items.Count - 1){
            nextSelectedIndex = selectedIndex + 1;
        }
        mainListView.SelectedIndex = nextSelectedIndex;
        mainListView.ScrollIntoView(mainListView.SelectedItem);     
    }
    mainListView.Focus();
}

private 
void last(){
    if (mainListView.Items.Count > 0){
        mainListView.SelectedIndex = mainListView.Items.Count - 1;
        mainListView.ScrollIntoView(mainListView.SelectedItem);        
    }
    mainListView.Focus();
}
        

}
}
