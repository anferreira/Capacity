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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;



namespace HotListReports.Windows.Demand{

class CapacityOptionsModel : BaseModel2{

public CapacityOptionsModel(Window window) : base(window){    
}

public
void loadHotListDifferentsPlants(ComboBox comboBox){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        HotListHdrContainer hotListHdrContainer = getCoreFactory().readLastHotListHdrDifferentsPlants();

        foreach (HotListHdr hotListHdr in hotListHdrContainer)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(hotListHdr.Plant,10,false) + "-" + DateUtil.getDateRepresentation(hotListHdr.HotlistRunDate,DateUtil.MMDDYYYY),
                                                                  hotListHdr.Plant));
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadHotListDifferentsPlants Exception: " + ex.Message);        
    }
}


}
}
