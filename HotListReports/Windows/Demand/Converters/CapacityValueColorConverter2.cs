using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitWms.WinForms.Util.Converters{

[ValueConversion(/*sourceType*/ typeof(decimal), /*targetType*/ typeof(string))]

public 
class CapacityValueColorConverter2 : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    string result = String.Empty;

    string colorBlack = Color.Black.ToString();
    string colorBlue = Color.Blue.ToString();
    string colorGreen = Color.Green.ToString();
    string colorYellow = Color.Yellow.ToString();
    string colorRed = Color.Red.ToString();
    string colorViolet = Color.Violet.ToString();

#if !POCKET_PC
    colorRed = Color.Red.Name;
    colorBlack = Color.Black.Name;
    colorBlue = Color.Blue.Name;
    colorGreen = Color.Green.Name;
    colorYellow = Color.YellowGreen.Name;
    colorRed = Color.Red.Name;
#endif

string paramValue = "V"; //V=Value C=Color
if (parameter is string)
    paramValue = string.IsNullOrEmpty((string)parameter) ? "": (string)parameter;

result = paramValue.Equals("V") ? "0.00" : colorBlack;
//new
if (value != null) {    
   string svalue = "";

   if (value is string)
       svalue = !string.IsNullOrEmpty((string)value) ? (string)value : "";
  
   if (!string.IsNullOrEmpty(svalue)){
        string[] items = svalue.Trim().Split(Nujit.NujitERP.ClassLib.Common.Constants.DEFAULT_SEP);

        string                  snumValue = "";
        string                  stypeShow = "";
        decimal                 dvalue =0;
        CapacityView.SHOW_TYPE  showType = CapacityView.SHOW_TYPE.TYPE_NORMAL;

       if (items.Length >=1){
            dvalue  = NumberUtil.isDecimalNumber(items[0]) ? System.Convert.ToDecimal(items[0]):0;
            showType= items.Length>=2?(CapacityView.SHOW_TYPE)System.Convert.ToInt16(items[1]) : CapacityView.SHOW_TYPE.TYPE_NORMAL;
       }

       if (paramValue.Equals("C")){ //type color
            result = colorBlack;

            switch(showType){               
                case CapacityView.SHOW_TYPE.PERCENTAGE:
                case CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE:
                    if (dvalue >= 80 && dvalue < 100)
                        result = colorYellow;   
                    else if (dvalue >= 100)
                        result = colorRed;   
                    break;                
            }
       }else{ //type value            
            result = dvalue.ToString("N");
            if (showType == CapacityView.SHOW_TYPE.DEMAND)
                result = decimal.Floor(dvalue).ToString();

            if (showType == CapacityView.SHOW_TYPE.PERCENTAGE || 
                showType == CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE)
                result+= "%";             
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
