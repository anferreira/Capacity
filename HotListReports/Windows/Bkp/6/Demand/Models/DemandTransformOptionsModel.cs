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

class DemandTransformOptionsModel : BaseModel2{

public DemandTransformOptionsModel(Window window) : base(window){    
}

public
void loadTimeFilter(ComboBox combo,bool bloadMonthly){
    try{
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();
               
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.getTimeCodeDesc(Constants.TIME_CODE_DAILY), Constants.TIME_CODE_DAILY));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.getTimeCodeDesc(Constants.TIME_CODE_WEEKLY),Constants.TIME_CODE_WEEKLY));
        if (bloadMonthly)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.getTimeCodeDesc(Constants.TIME_CODE_MONTHLY),Constants.TIME_CODE_MONTHLY));

        setDataContextCombo(combo,list);

    } catch (Exception ex) {
       MessageBox.Show("loadTimeFilter Exception: " + ex.Message);       
    }
}



}
}
