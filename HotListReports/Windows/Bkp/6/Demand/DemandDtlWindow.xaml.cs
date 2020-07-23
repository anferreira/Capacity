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

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using HotListReports.Windows.Demand;

namespace HotListReports.Windows.Demand{

/// <summary>
/// Interaction logic for DemandDtlWindow.xaml
/// </summary>
public partial 
class DemandDtlWindow : Window{

private DemandDtlModel demandDtlModel;
private DemandH demandH;
private DemandD demandD;

public 
DemandDtlWindow(DemandH demandH,DemandD demandD){
    InitializeComponent();

    this.demandH = demandH;
    this.demandD = demandD;
    this.demandDtlModel = new DemandDtlModel(this);
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
        demandDtlModel.loadSourceCombo(sourceComboBox);
        demandDtlModel.loadTimeCodeCombo(timeCodeComboBox);
        this.DataContext = demandD;   
        shipDatePicker.SelectedDate= demandD.SDate;
               
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}
        


private 
void okButton_Click(object sender, RoutedEventArgs e){
    ok();
}

private 
bool dataOK(){
    bool    bresult=true;
    demandD.SDate=(DateTime)shipDatePicker.SelectedDate;

    if (bresult)
        bresult = demandDtlModel.getValidNumericFromAlpha(this.netQtyTextBox, "Net Quantity");
    if (bresult)
        bresult = demandDtlModel.getValidNumericFromAlpha(this.qtyCumTextBox, "Qty. Cumulative");
            
    return bresult;
}

private 
void ok(){
    try{
        if (dataOK()){
            this.DialogResult = true;
            Close(); 
        }

    }catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

}
}
