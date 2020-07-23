using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Nujit.NujitERP.ClassLib.Common;

namespace HotListReports.Windows.Util{

[ValueConversion(/*sourceType*/ typeof(string), /*targetType*/ typeof(bool))]

public
class ConstantYesNoToBoolConverterNew : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    
    //if (targetType != typeof(bool)){
    //    return null;
    //}

    if (value == null)
        #if NEW_SP
        return false;
        #else
        return null;
        #endif        

    string constant = value.ToString();
    if (constant.Equals(Constants.STRING_YES))
        return true;
    else
        return false;
}

public
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    //if (value != typeof(bool)){
    //    return null;
    //}
    if ((bool)value)
        return Constants.STRING_YES;
    else
        return Constants.STRING_NO;
}

}
}
