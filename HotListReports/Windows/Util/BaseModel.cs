using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nujit.NujitERP.ClassLib.Core;
using System.Windows.Controls;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using Nujit.NujitERP.ClassLib.Util;
using System.Windows.Input;

namespace HotListReports.Windows.Util{
class BaseModel{

protected CoreFactory coreFactory;
protected Cursor cursor;

public BaseModel(CoreFactory coreFactory){
    this.coreFactory = coreFactory;
    this.cursor  = null;
}

public
void setCursor(Cursor cursor){    
    this.cursor  = cursor;
}

public
Object getSelected(ListView listView){
    Object obj = null;
    if (listView.SelectedItems.Count > 0)
        obj = listView.SelectedItems[listView.SelectedItems.Count - 1];
    return obj;
}

public
ArrayList getSelecteds(ListView listView){
    ArrayList    arrayList = new ArrayList();
                                
    foreach(Object obj in listView.SelectedItems)
        arrayList.Add(obj);    
    return arrayList;
}

public
void loadStatusComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Active", "A"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Inactive", "I"));                
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadStatusComboBox Exception: " + ex.Message);        
    }
}

public
void loadShiftNumComboBox(ComboBox comboBox,int imaxShift,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)                    
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));

        for (int i=1; i <= imaxShift;i++)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(i.ToString(), i.ToString()));
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadShiftNumComboBox Exception: " + ex.Message);        
    }
}

public
int getRecords(TextBox recordsTextBox){
    int irows = NumberUtil.isIntegerNumber(recordsTextBox.Text) ? Convert.ToInt32(recordsTextBox.Text) : 50;
    recordsTextBox.Text = irows.ToString();
    return irows;
}

public
Object deleltedSelected(ListView listView){    
    try{            
        Object  obj = getSelected(listView);

        if (obj != null){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete Item Selected ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
               return obj;
            }
        }else
            MessageBox.Show("Please, Select Item First.");        
            
    }catch (Exception ex){
        MessageBox.Show("deleltedSelected Exception: " + ex.Message);
    }   
    return null;                                
}          

public
ArrayList deleltedSelecteds(ListView listView){    
    ArrayList arrayList = new ArrayList();
    try{            
        arrayList = getSelecteds(listView);

        if (arrayList.Count > 0){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete Item/s Selected ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
               return arrayList;
            }
        }else
            MessageBox.Show("Please, Select Item/s First.");        
        
        arrayList.Clear();    

    }catch (Exception ex){
        MessageBox.Show("deleltedSelecteds Exception: " + ex.Message);
    }   
    return arrayList;                                
} 


}
}
