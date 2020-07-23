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
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

namespace HotListReports.Windows.Demand{
/// <summary>
/// Interaction logic for CapacityOptionsWindow.xaml
/// </summary>
public partial 
class CapacityOptionsWindow : Window{

private CapacityOptionsModel capacityOptionsModel;
private CapacityHdr capacityHdr;

public CapacityOptionsWindow(CapacityHdr capacityHdr){
    InitializeComponent();
    this.capacityOptionsModel = new CapacityOptionsModel(this);
    this.capacityHdr = capacityHdr;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    
}

private
string getSelectedPlant(){        
    string splant="";
    try {
        splant = plantComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)plantComboBox.SelectedItem).Content.ToString() : "";       
    } catch (Exception ex) {
        MessageBox.Show("getSelectedPlant Exception: " + ex.Message);        
    }
    return splant;
}

private 
void initialize(){        
    try {        
        this.DataContext = null;
        this.DataContext = capacityHdr;
        capacityOptionsModel.Cursor = this.Cursor;      

        this.startFilterRadDateTimePicker.IsEnabled = false;                
        capacityOptionsModel.loadHotListDifferentsPlants(plantComboBox);
                    
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void okButton_Click(object sender, RoutedEventArgs e){
    ok();
}

private 
bool dataOk(){
    bool bresult=true;

    if (string.IsNullOrEmpty(capacityHdr.Plant)){
        MessageBox.Show("Please, Select Plant.");
        bresult=false;
    }
    return bresult;
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}

private 
void ok(){    
    if (dataOk()) { 
        this.DialogResult = true;
        Close();
    }
}

private 
void cancel(){    
    this.DialogResult = false;
    Close();    
}

}
}
