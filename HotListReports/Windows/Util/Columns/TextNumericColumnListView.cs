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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

namespace Nujit.NujitWms.WinForms.Util.Grids {

public
class TextNumericColumnListView : TextColumnListView{

public
TextNumericColumnListView(string title, string bindName, BindingMode bindingMode,int with,iListView listView)
    : base(title,bindName,bindingMode,with,listView) {
    
}

public
void loadValues(CoreFactory coreFactory, string sid="", string staskName="", string sdirInd="", int rows = 0){
    try {
        CapShiftTaskContainer capShiftTaskContainer = coreFactory.readCapShiftTaskByFilters(sid, staskName, sdirInd,rows);
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>  list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();

        foreach(CapShiftTask capShiftTask in capShiftTaskContainer)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(capShiftTask.TaskName, capShiftTask.Id));        
             
        this.setProperty(ComboBox.ItemsSourceProperty, list);

    }catch (Exception ex){
        MessageBox.Show("ShiftTaskComboColumnListView loadValues Exception: " + ex.Message);
    }
}

}
}
