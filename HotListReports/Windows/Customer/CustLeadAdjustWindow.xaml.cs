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
using Nujit.NujitERP.ClassLib.Core.Customer;

namespace HotListReports.Windows.Customers{
/// <summary>
/// Interaction logic for CustLeadWindow.xaml
/// </summary>
public partial 
class CustLeadAdjustWindow : Window{

private CustLeadAdjustModel model; 
private ShipExport          shipExport;

public CustLeadAdjustWindow(string sbillTo="",string smajSales="",string sminSales=""){
    InitializeComponent();

    this.model              = new CustLeadAdjustModel(this);
    this.shipExport         = model.getCoreFactory().createShipExport();
    this.shipExport.BillTo  = sbillTo;
    this.shipExport.MajSales= smajSales;
    this.shipExport.MinSales= sminSales;
}


private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {
        DateTime        toDate = new DateTime(DateTime.Now.Year, 3, 1);
        shipExport.ShipDate     = new DateTime(DateTime.Now.Year,1,1);
        if (toDate > DateTime.Now)
            toDate = DateTime.Now;
        shipExport.DateRequest  = toDate;
        this.leadTimeRadioButton.IsChecked = true;
        shipExport.BackFlag = "2"; //Lead Time 2 by default
        leadTimeRadio2Button.IsChecked = true;

        //load lead by default
        CustLeadContainer custLeadContainer = model.getCoreFactory().readCustLeadByCustomerFilters(shipExport.BillTo,shipExport.MajSales);
        shipExport.LeadTime = 28;
        if (custLeadContainer.Count > 0)
            shipExport.LeadTime = custLeadContainer[0].LeadTime;

        this.DataContext = shipExport;                

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    } finally{         
    }
}

private
bool dataOK(){
    bool    bresult=true;

    if (string.IsNullOrEmpty(shipExport.BillTo)){
        bresult=false;
        MessageBox.Show("Please, Select BillTo.");
        billToTextBox.Focus();

    }else{
        PersonContainer personContainer = model.getCoreFactory().readPersonsByFilters("",shipExport.BillTo,Person.TYPE_CUSTOMER,Person.CUSTOMER_TYPE_BILLTO, "", "", "", "", "",1);            
        if (personContainer.Count < 1){
            bresult=false;
            MessageBox.Show("Sorry, Can Not Find BillTo : " + shipExport.BillTo + ", Please Reenter.");
            billToTextBox.Focus();
        }
    }

    if (bresult){
        if (fromDatePicker == null){
            bresult=false;
            MessageBox.Show("Sorry, Select From Date.");
            fromDatePicker.Focus();
        }

        if (toDatePicker == null){
            bresult=false;
            MessageBox.Show("Sorry, Select To Date.");
            toDatePicker.Focus();
        }

        if (bresult){
            if (fromDatePicker.SelectedDate > toDatePicker.SelectedDate){
                bresult=false;
                MessageBox.Show("Sorry, From Date Must Be Bigger Than To Date.");
                fromDatePicker.Focus();
            }
        }

        if (shipExport.LeadTime <=0){
            bresult=false;
            MessageBox.Show("Sorry, Seleect Lead Time.");
            leadTTextBox.Focus();
        }

        if (string.IsNullOrEmpty(shipExport.BackFlag)){
            bresult=false;
            MessageBox.Show("Sorry, Seleect Lead To Adjust.");        
        }
    }

    return bresult;
}

private 
void billToSearchButton_Click(object sender, RoutedEventArgs e){
    billToSearch();
}

private 
void billToSearch(){
    Person  person = model.searchCustomer(Person.CUSTOMER_TYPE_BILLTO);
    if (person!= null) { 
        shipExport.Site     = person.getPlt();
        shipExport.BillTo   = person.Id;
    }
}

private 
void okButton_Click(object sender, RoutedEventArgs e){
    ok();
}

private 
void ok(){
    try{
        if (dataOK()) { 
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Proceed For \n\n Major Sales : " + shipExport.MajSales + " Minor Sales : " + shipExport.MinSales + "\n\n" +
                "From :" + DateUtil.getDateRepresentation(shipExport.ShipDate,DateUtil.MMDDYYYY) + " " + "To :" + DateUtil.getDateRepresentation(shipExport.DateRequest, DateUtil.MMDDYYYY) +
                " ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){        
                model.cursorWait();

                ShipExportContainer shipExportContainer  =  model.getCoreFactory().adjustShipExporAndSumLeadTime(shipExport);
                model.cursorNormal();

                MessageBox.Show("Total Records Processed : " + shipExportContainer.Count);                               
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("ok Exception: " + ex.Message);        
    }finally{
        model.cursorNormal();
    }
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
   cancel();
}

private 
void cancel(){
    if (model.closeAsk())   
        model.close();
}

private
void radio_Checked(object sender, RoutedEventArgs e){
    model.radioChecked(shipExport,sender);
}

}
}
