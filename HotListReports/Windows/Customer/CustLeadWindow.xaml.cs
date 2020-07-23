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
class CustLeadWindow : Window{

private CustLeadModel model;
private Person   person;
private CustLead custLead;

public CustLeadWindow(Person person,CustLead custLead){
    InitializeComponent();

    this.model    = new CustLeadModel(this);
    this.person   = person;
    this.custLead = custLead;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {                        
        this.custTopCanvas.DataContext = person;
        this.DataContext = custLead;      

        if (custLead.Id > 0) { 
            leadTTextBox.Focus();
            this.majTextBox.IsReadOnly= this.minTextBox.IsReadOnly= true;//because we can not change the Keys
            this.majTextBox.IsEnabled = this.minTextBox.IsEnabled = false;
            this.leadTTextBox.Focus();
            this.leadTTextBox.SelectAll();
        }else
            majTextBox.Focus();

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    } finally{         
    }
}

private 
void okDefaultsButton_Click(object sender, RoutedEventArgs e){   
    save();
}

private 
bool dataOk(){   
    bool bresult=true;
    try{      
        string      smessError      = "";
                
        if (string.IsNullOrEmpty(custLead.MajSalesCode)) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Major Sales";
            majTextBox.Focus();
            bresult=false;
        }

        /*For now comment MinGroup could be empty
        if (string.IsNullOrEmpty(custLead.MinGroup)) {            
            smessError+= (!string.IsNullOrEmpty(smessError) ? ",":"")  + "Minor Sales";
            minTextBox.Focus();
            bresult=false;
        }*/

        if (bresult &&  custLead.Id <=0){ //if adding
            CustLead custLeadAux = model.getCoreFactory().readCustLead(custLead.CustId, custLead.MajSalesCode, custLead.MinSalesCode);
            if (custLeadAux != null){
                MessageBox.Show("Please, Reenter Record Already Exists.");
                majTextBox.Focus();
                bresult=false;
            }
        }

        if (!string.IsNullOrEmpty(smessError))
            MessageBox.Show("Please Enter : \n" + smessError);


      
    } catch (Exception ex) {
        MessageBox.Show("dataOk Exception: " + ex.Message);        
    }
    return bresult;        
}

private 
void save(){   
    try{                        
        if (dataOk()) { 
            if (model.save(custLead))
                Close();
        }                        
    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    } finally{         

    }
}

private 
void cancelDefaultsButton_Click(object sender, RoutedEventArgs e){   
    if (model.cancel())
        Close();
}  

}
}
