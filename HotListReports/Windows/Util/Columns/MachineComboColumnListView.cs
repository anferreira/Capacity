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
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace Nujit.NujitWms.WinForms.Util.Grids {

public
class MachineComboColumnListView : ComboColumnListView{

public
MachineComboColumnListView(string title, string bindName, BindingMode bindingMode, int with, ListView listView)
    : base(title,bindName,bindingMode,with,listView) {
    
}

public
void loadValues(CoreFactory coreFactory,string smachine="", string sdes1="",string plant="",string sdept="",bool bonlyHeader=true,int rows=0){
    try {
        MachineContainer machineContainer = coreFactory.readMachinesByFilters(smachine,sdes1,plant, sdept,"", bonlyHeader,rows);
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();

        int imaxCodeLen = machineContainer.getMaxMachCodeLen();

        foreach (Machine machine in machineContainer)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(machine.Mach,imaxCodeLen,false) + "-" + machine.Des1, machine.Id));

        this.setProperty(ComboBox.ItemsSourceProperty, list);

    }catch (Exception ex){
        MessageBox.Show("MachineComboColumnListView loadValues Exception: " + ex.Message);
    }
}

}
}
