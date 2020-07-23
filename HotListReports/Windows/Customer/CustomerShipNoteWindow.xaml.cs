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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace HotListReports.Windows.Customers{

/// <summary>
/// Interaction logic for CustomerShipNoteWindow.xaml
/// </summary>
public partial class CustomerShipNoteWindow : Window{

private CustomerShipNoteModel   model;
private ShipExportSum           shipExportSum;


public CustomerShipNoteWindow(ShipExportSum shipExportSum){
    InitializeComponent();

    model = new CustomerShipNoteModel(this);
    this.shipExportSum = shipExportSum;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {        

        this.DataContext = shipExportSum;                        
        model.loadYesNoComboBox(ppapComboBox,false);
        model.loadYesNoComboBox(fixManualComboBox, false);                

        this.noteTextBox.Focus();

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    } finally{         
    }
}


private 
void okButton_Click(object sender, RoutedEventArgs e){
   ok();
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
   cancel();
}

private 
void ok(){
    try{       
        if (dataOK() && System.Windows.Forms.MessageBox.Show("Do You Want To Save Changes ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){                    
            model.save(shipExportSum);
        }        
    } catch (Exception ex) {
        MessageBox.Show("ok Exception: " + ex.Message);        
    }finally{
     
    }
}

private 
void cancel(){
    if (model.closeAsk())   
        model.close();
}

private
bool dataOK(){
    bool    bresult=true;

    model.validQtyBiggerZero(ref bresult,qtyOrderTextBox,   (string)qtyOrderLabel.Content,      shipExportSum.QtyOrder);
    model.validQtyBiggerZero(ref bresult,qtyShippedTextBox, (string)qtyShippedLabel.Content,    shipExportSum.QtyShipped);
    model.validQtyBiggerZero(ref bresult,qtyOrdCumTextBox,  (string)qtyOrdCumLabel.Content,     shipExportSum.QtyOrderedFromCum);
            
    model.validQtyBiggerZero(ref bresult,leadTimeTextBox,   (string)leadTimeLabel.Content,      shipExportSum.LeadTime);

    model.validDate(ref bresult,createDateDatePicker,       (string)createDateLabel.Content,    shipExportSum.CreateDate);
    model.validDate(ref bresult,dateRequestDatePicker,      (string)dateRequestLabel.Content,   shipExportSum.DateRequest);
    model.validDate(ref bresult,shipDateDatePicker,         (string)shipDateLabel.Content,      shipExportSum.ShipDate);
    model.validDate(ref bresult, changeDateDatePicker,      (string)changeDateLabel.Content,    shipExportSum.ChangeDate);

    if (shipExportSum.ShipDate < shipExportSum.CreateDate){
        bresult=false;
        MessageBox.Show("Please, Select Ship Date Bigger Than Created Date.");
        shipDateDatePicker.Focus();
    }

    if (shipExportSum.QtyPpm > shipExportSum.QtyOrder){
        bresult=false;
        MessageBox.Show("Please, Reenter QtyPPM Is Bigger Than QtyOrder.");
        qtyPpmTextBox.Focus();
    }

    if (shipExportSum.QtyShippedOnTime > shipExportSum.QtyOrder){
        bresult=false;
        MessageBox.Show("Please, Reenter QtyShippedOnTime Is Bigger Than QtyOrder.");
        qtyShippedOnTimeTextBox.Focus();
    }

    if (shipExportSum.QtyShippedLate > shipExportSum.QtyOrder){
        bresult=false;
        MessageBox.Show("Please, Reenter QtyShippedLate Is Bigger Than QtyOrder.");
        qtyShippedLateTextBox.Focus();
    }

    if ( (shipExportSum.QtyShippedOnTime + shipExportSum.QtyShippedLate) > shipExportSum.QtyOrder){
        bresult=false;
        MessageBox.Show("Please, Reenter QtyShippedOnTime Plus QtyShippedLate Is Bigger Than QtyOrder.");
        qtyShippedOnTimeTextBox.Focus();
    }    
  
    return bresult;
}


}
}
