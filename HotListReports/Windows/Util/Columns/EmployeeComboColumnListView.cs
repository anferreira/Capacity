using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using NujitWPFUtilities;
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitWms.WinForms.Util.Controllers;

namespace Nujit.NujitWms.WinForms.Util.Grids {

public
class EmployeeComboColumnListView : ComboColumnListView{

public
EmployeeComboColumnListView(string title, string bindName, BindingMode bindingMode, int with, ListView listView)
    : base(title,bindName,bindingMode,with,listView) {
    
}

public
void loadValues(CoreFactory coreFactory,ComboDisplayFormat displayFormat, string sid="",string firstName="",string lastName="",string status= Nujit.NujitERP.ClassLib.Common.Constants.STATUS_ACTIVE,int iassignShift=0,string sdept="",int rows=0){
    try { 
        EmployeeContainer employeeContainer = coreFactory.readEmployeeByFilters(sid, firstName, lastName, status, iassignShift, sdept,-1,false,false,rows);
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        string sline = "";
        foreach(Employee employee in employeeContainer) {                                                                    
                switch (displayFormat){				
                    case (ComboDisplayFormat.Code):
                        sline= employee.Id;break;                              	
					case (ComboDisplayFormat.CodeDescription):
                        sline= StringUtil.AddSpaces(employee.Id, 10, false) + "-" + employee.FullName;break;                        
					case (ComboDisplayFormat.Description):
						sline= employee.FullName;break;
				}

                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sline,employee.Id));
        }
        this.setProperty(ComboBox.ItemsSourceProperty, list);

    }catch (Exception ex){
        MessageBox.Show("EmployeeComboColumnListView loadValues Exception: " + ex.Message);
    }
}

}
}
