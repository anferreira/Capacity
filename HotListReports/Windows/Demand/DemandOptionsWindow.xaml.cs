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
using Nujit.NujitERP.ClassLib.Common;

namespace HotListReports.Windows.Demand{
/// <summary>
/// Interaction logic for DemandOptionsWindow.xaml
/// </summary>
public 
partial class DemandOptionsWindow : Window{

private DemandOptionsModel model;
private DemandH demandH;

public DemandOptionsWindow(DemandH demandH){
    InitializeComponent();
    this.model = new DemandOptionsModel(this);
    this.demandH = demandH;
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
        this.DataContext = demandH;
        model.Cursor = this.Cursor;      

        this.startFilterRadDateTimePicker.IsEnabled = true;
        this.stopFilterRadDateTimePicker.IsEnabled = false;        
        model.loadPlantCombo(plantComboBox,false);

        demandH.Plant = Configuration.DftPlant;
        if (string.IsNullOrEmpty(demandH.Plant)){
            string[] plants = model.getCoreFactory().getPlantCodes();//show default plant
            if (plants.Length > 0)
                demandH.Plant = plants[0];       
        }                     
            
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

    if (string.IsNullOrEmpty(demandH.Plant)){
        MessageBox.Show("Please, Select Plant.");
        bresult=false;
    }

    if (demandH.StaDate >= DateTime.Today){
        MessageBox.Show("Please, Reenter Start Date Might Be Slower Than Today.");
        startFilterRadDateTimePicker.Focus();
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
