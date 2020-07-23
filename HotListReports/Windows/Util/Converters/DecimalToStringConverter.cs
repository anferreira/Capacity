using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace HotListReports.Windows.Util{

[ValueConversion(/*sourceType*/ typeof(decimal), /*targetType*/ typeof(string))]

public 
class DecimalToStringConverterNew : IValueConverter{

public 
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    if (targetType != typeof(string)){
        return null;
    }

    string result           = String.Empty;
    string sdefaultFormat   = "###,##0.00";

    if (value != null){
        decimal decNumber =0;

        try {
            decNumber =  System.Convert.ToDecimal(value);
        }catch{ }

        if ((parameter != null) && (!parameter.Equals(String.Empty))){
            string paramValue = parameter.ToString();

            switch(paramValue){
                case "0":
                    result = decNumber.ToString("###,##0");
                    break;
                case "Empty/0":
                    if (decNumber != 0 && decNumber != decimal.MinValue)
                        result = decNumber.ToString("###,##0");
                    break;
                case "int":
                    result = decNumber >= Int32.MinValue && decNumber <= Int32.MaxValue ? ((Int32)decimal.Floor(decNumber)).ToString() : decNumber.ToString("###,##0");
                    break;
                case "intNot0":
                    if (decNumber == 0)
                        result = "";
                    else
                        result = decNumber >= long.MinValue && decNumber <= long.MaxValue ? ((long)decimal.Floor(decNumber)).ToString() : decNumber.ToString("###,##0");
                    break;
                default:
                    try {result = decNumber.ToString(paramValue);} //supposed format send by user so we try it
                    catch{ result = decNumber.ToString(sdefaultFormat);}                               
                    break;                       
            }
                            
        }else
            result = decNumber.ToString(sdefaultFormat);

        if (decNumber == decimal.MinValue)
            result = "";
        if (decNumber == decimal.MaxValue)
            result = "";
    }

    return result;
}

public 
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    decimal decNumber =0;

    try {
        if (value!= null) { 
            string svalue = (string)value;
            if (string.IsNullOrEmpty(svalue))                        
                svalue="0";        

            char[] vec = svalue.ToCharArray();
            svalue ="";
	        for(int i = 0; i < vec.Length; i++){
		        if (Char.IsNumber(vec[i]) || (string.IsNullOrEmpty(svalue) && vec[i] == '-') ||
                    vec[i] == ',' || vec[i] == '.'   )
                    svalue+= vec[i];                    		        
	        }
            
            if (parameter is string && !string.IsNullOrEmpty((string)parameter)){
                    string paramValue = parameter.ToString();

                    switch(paramValue){                        
                        case "int":
                        case "intNot0":    
                            decNumber =  System.Convert.ToInt32(System.Convert.ToDecimal(svalue));
                            break;
                        default:
                            decNumber =  System.Convert.ToDecimal(value);
                            break;
                    }   
            }else
                decNumber =  System.Convert.ToDecimal(svalue);
        }
          
    }catch{ }

    return decNumber;  
}


}
}
