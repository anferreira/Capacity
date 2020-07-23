using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using System.Windows.Media;
using HotListReports.Windows.Util;

namespace HotListReports.Windows.EmployeeSchedule{

public
class PriorityColorConverter : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){    
//1 - 5     = Red background, white font
//6 - 10    = Orange Background, white font
//11- 15    = Yellow, white font
//else      = Blue

    SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Blue);            
    
    if (value != null && value is int){
        int ivalue = (int)value;
                    
        if (ivalue >= 1 && ivalue <=5)
            solidColorBrush = new SolidColorBrush(Colors.Red);
        else if (ivalue >= 6 && ivalue <=10)
            solidColorBrush = new SolidColorBrush(Colors.Orange);
        else if (ivalue >= 11 && ivalue <=15)
            solidColorBrush = new SolidColorBrush(UIColors.COLOR_SELECT);
    }        
    
    return solidColorBrush;    
}

public
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    throw new NotImplementedException();
}

}
}
