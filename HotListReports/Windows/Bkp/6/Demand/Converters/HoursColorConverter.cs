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
class HoursColorConverter : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    string result = String.Empty;

    string colorBlack = Color.Black.ToString();
    string colorBlue = Color.Blue.ToString();
    string colorGreen = Color.Green.ToString();
    string colorYellow = Color.Maroon.ToString();
    string colorRed = Color.Red.ToString();

#if !POCKET_PC
    colorRed = Color.Red.Name;
    colorBlack = Color.Black.Name;
    colorBlue = Color.Blue.Name;
    colorGreen = Color.Green.Name;
    colorYellow = Color.YellowGreen.Name;
    colorRed = Color.Red.Name;
#endif
     
    result = colorBlack;

    if (value != null) {

        string svalue = "";
        
        if (value is string){
            svalue = !string.IsNullOrEmpty((string)value) ? (string)value : "0";

            if (NumberUtil.isDecimalNumber(svalue)){
                decimal dvalue = System.Convert.ToDecimal(svalue);
                if (dvalue > (24*5))
                    result = colorRed;                 
            }
        }        
    }
    return result;
}

public
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    throw new NotImplementedException();
}

}
}
