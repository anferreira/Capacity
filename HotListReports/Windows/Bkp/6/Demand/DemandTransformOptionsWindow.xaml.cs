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
/// Interaction logic for DemandTransformOptionsWindow.xaml
/// </summary>
public 
partial class DemandTransformOptionsWindow : Window{

private DemandTransformOptionsModel model;
private DemTransformOptions demTransformOptions;

public DemandTransformOptionsWindow(DemandH demandH){
    InitializeComponent();
    this.model = new DemandTransformOptionsModel(this);
    this.demTransformOptions = model.getCoreFactory().createDemTransformOptions();

    this.demTransformOptions.DemandH = demandH;
}

public
DemTransformOptions DemTransformOptions {
	get { return demTransformOptions; }
	set {
        this.demTransformOptions = value;		
	}
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
        this.DataContext = demTransformOptions.DemandH;
        this.bottomGroupBox.DataContext = demTransformOptions;

        model.loadTimeFilter(weeklyComboBox,false);model.setSelectedComboBoxItem(weeklyComboBox,Constants.TIME_CODE_WEEKLY);
        model.loadTimeFilter(monthlyComboBox,true);model.setSelectedComboBoxItem(monthlyComboBox, Constants.TIME_CODE_MONTHLY);                            
            
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
