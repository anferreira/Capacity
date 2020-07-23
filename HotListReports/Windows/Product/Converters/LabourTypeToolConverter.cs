using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

namespace HotListReports.Windows.Products{

public
class LabourTypeToolConverter : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    string sresult = String.Empty;

    if (value != null) {
          
        if (value is string){
            string svalue = (string)value; 

            switch(svalue){
                case RoutingLabTool.LABOUR_TYPE:    sresult = "Labour Task";break;
                case RoutingLabTool.TOOL_TYPE:      sresult = "Tool";break;                
            }
        }        
    }
    return sresult;
}

public
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    throw new NotImplementedException();
}

}
}
