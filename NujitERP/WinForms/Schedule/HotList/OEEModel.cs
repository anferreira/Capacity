using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core;
using System.Data;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitWms.WinForms.Custom.Markdom.Concord;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Shapes;

namespace Nujit.NujitERP.WinForms.Schedule.HotList{

class OEEtModel{

public
void oee(){
    try {
        BatchReportWindow batchReportWindow = new BatchReportWindow();
        batchReportWindow.Show();
        
    }catch (Exception ex){
       using(FormException formException = new FormException(ex))
		    formException.ShowDialog();   
    }
}

}
}
