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
class DemandDtlModel : BaseModel2{
public DemandDtlModel(Window window) : base(window){    
}

public
void loadSourceCombo(ComboBox sourceComboBox){
    sourceComboBox.Items.Add(DemandD.SOURCE_830);
    sourceComboBox.Items.Add(DemandD.SOURCE_862);
    sourceComboBox.Items.Add(DemandD.SOURCE_ORDER);
}

public
void loadTimeCodeCombo(ComboBox timeCodeComboBox){
    timeCodeComboBox.Items.Add("D");
    timeCodeComboBox.Items.Add("M");
    timeCodeComboBox.Items.Add("W");   
    timeCodeComboBox.Items.Add("");
}


}
}
