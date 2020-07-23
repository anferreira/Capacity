using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Nujit.NujitERP.ClassLib.Util;

namespace HotListReports.Windows.Util{


[ValueConversion(/*sourceType*/ typeof(DateTime), /*targetType*/ typeof(string))]

public 
class DateTimeToStringConverterNew : IValueConverter{

public 
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    string result = String.Empty;

    if (parameter != null){
        if (value != null){
            DateTime    dateTime = (DateTime)value;       
            if (!dateTime.Equals(DateUtil.MinValue) && !dateTime.Equals(DateTime.MinValue)){
                string paramValue = parameter.ToString();
                switch (paramValue){
                    case "Date":
                        result = DateUtil.getDateRepresentation(dateTime, DateUtil.MMDDYYYY);
                        break;
                    case "Date2":
                        if (dateTime != DateUtil.MinValue) { 
                            result = DateUtil.getDateRepresentation(dateTime, DateUtil.MMDDYYYY);
                            if (!string.IsNullOrEmpty(result) && result.Length >=8)
                                result = result.Substring(0,6)  + result.Substring(result.Length-2);
                        }
                        break;
                    case "Time":
                        result = DateUtil.getTimeRepresentation(dateTime);
                        break;
                    case "DateTime":
                        result = DateUtil.getCompleteDateRepresentation(dateTime, DateUtil.MMDDYYYY);
                        break;
                    case "DateMinValue":
                        if (dateTime != DateUtil.MinValue)
                            result = DateUtil.getDateRepresentation(dateTime,DateUtil.MMDDYYYY);                    
                        break;
                    case "DateTimeMinValue":
                        if (dateTime != DateUtil.MinValue)
                            result = DateUtil.getCompleteDateRepresentation(dateTime,DateUtil.MMDDYYYY);
                        break;
                }
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
