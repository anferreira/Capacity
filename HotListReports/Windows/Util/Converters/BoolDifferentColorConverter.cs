using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace HotListReports.Windows.Util{

public
class BoolDifferentColorConverter : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    string scolor = "Black";
             
    if (value != null && value is bool){
        bool bvalue = (bool)value;
        if (bvalue)
            scolor = "Red";
    }
    return scolor;
}

public
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    throw new NotImplementedException();
}

}
}
