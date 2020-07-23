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

namespace HotListReports.Windows{
    /// <summary>
    /// Interaction logic for BolWindow.xaml
    /// </summary>
public partial 
class BolWindow : Window{

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private BolmContainer bolmContainer;

public 
BolWindow(){
    InitializeComponent();
    bolmContainer=null;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
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
void initialize(){
    loadSearchByCombo();
    search();
}

private
void loadSearchByCombo(){
    searchByComboBox.Items.Add("BOL#");
    searchByComboBox.Items.Add("Ship Via");
    searchByComboBox.Items.Add("Truck ID");
    searchByComboBox.Items.Add("Route");
    
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
     try {
     
        TabItem         selectedTab = (TabItem)mainTabControl.SelectedItem;        
                /*
        if (selectedTab.Equals(serialsTabItem) || selectedTab.Equals(serialTotalsTabItem)){
            setEnable(Visibility.Visible);         

            if (priorSelectedTab!=null && (priorSelectedTab.Equals(resTabItem) || priorSelectedTab.Equals(partTabItem)))
                search();

        }else
            setEnable(Visibility.Collapsed);

        
        this.toLabel.Visibility =
        this.toDateTimePicker.Visibility = 

        this.adjustTimesButton.Visibility =
        this.filterGroupBox.Visibility = 
        this.exportNoResourcesOnBatchButton.Visibility = selectedTab.Equals(this.shiftSummaryTabItem) || selectedTab.Equals(shiftDtlTabItem) ? Visibility.Hidden : Visibility.Visible;

        priorSelectedTab = selectedTab;


        showSearchControls();
        */
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}
    
private 
void search(){
    try{
        string  sbol        = searchByComboBox.SelectedIndex == 0 && NumberUtil.isDecimalNumber(searchForTextBox.Text) ? searchForTextBox.Text : "0";
        string  shipVia     = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : "";
        string  struckID    = searchByComboBox.SelectedIndex == 2 ? searchForTextBox.Text : "";
        string  sroute      = searchByComboBox.SelectedIndex == 3 ? searchForTextBox.Text : "";                
        decimal dbol        = Convert.ToDecimal(sbol);
               
        bolmContainer = coreFactory.readBolmByFilters(dbol,DateUtil.MinValue, DateUtil.MinValue,"",shipVia, struckID,sroute, 50);

        this.bolMListView.DataContext= bolmContainer;                
        this.bolMListView.ItemsSource= bolmContainer;   
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("MainMaterial Data OK Exception: " + ex.Message);
    }                       
}

}
}
