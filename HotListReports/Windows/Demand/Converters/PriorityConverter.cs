using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;

namespace HotListReports.Windows.Demand{

public
class PriorityConverter : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    string sresult = String.Empty;

    if (value != null) {
          
        if (value is int){
            int ivalue = (int)value; 

            switch(ivalue){
                case 0: sresult = "Slow";break;
                case 1: sresult = "Normal";break;
                case 2: sresult = "High";break;
                case 3: sresult = "Urgent"; break;
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
