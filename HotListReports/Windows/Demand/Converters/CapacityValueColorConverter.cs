using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Util;

namespace HotListReports.Windows.Demand{

public
class CapacityValueColorConverter : IValueConverter{

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

        string                  splant = "";
        string                  sdept = "";
        string                  sreqType= "";
        string                  smachine= "";
        string                  slabour= "";
        string                  stool= "";
        string                  stitle= "";
        decimal                 dhours= 0;
        DateTime                sDate= DateTime.Now;
        decimal                 directHoursToShifts= 1;
        CapacityView.SHOW_TYPE  showType = CapacityView.SHOW_TYPE.TYPE_NORMAL;

        if (items.Length >=1 && items.Length <=2){
            dhours  = NumberUtil.isDecimalNumber(items[0]) ? System.Convert.ToDecimal(items[0]):0;
            showType= items.Length>=2?(CapacityView.SHOW_TYPE)System.Convert.ToInt16(items[1]) : CapacityView.SHOW_TYPE.TYPE_NORMAL;
        } else if (items.Length > 5){
           //System.Windows.Forms.MessageBox.Show("items.Length:" + items.Length);

            splant   = items.Length >= 1 ? items[0]:"";
            sdept    = items.Length >= 2 ? items[1]:"";
            sreqType = items.Length >= 3 ? items[2]:"";

            smachine = items.Length >= 4 ? items[3]:"";
            slabour  = items.Length >= 5 ? items[4]:"";
            stool    = items.Length >= 6 ? items[5]:"";

            stitle   = items.Length >= 7 ? items[6]:"";
            dhours   = items.Length >= 8 ? System.Convert.ToDecimal(items[7]):0;
            sDate   = items.Length >= 9 ? DateUtil.parseDate(items[8],DateUtil.MMDDYYYY) : DateTime.Now;
            directHoursToShifts = items.Length>=10 ? System.Convert.ToDecimal(items[9]):0;
            showType            = items.Length>=11?(CapacityView.SHOW_TYPE)System.Convert.ToInt16(items[10]) : CapacityView.SHOW_TYPE.TYPE_NORMAL;

            if (showType == CapacityView.SHOW_TYPE.TYPE_TOTAL)            
                System.Windows.Forms.MessageBox.Show("Machine:" + smachine + "\nhours:" + dhours);                      
       }

       if (paramValue.Equals("C")){ //type color
            result = colorBlack;

            switch(showType){               
                case CapacityView.SHOW_TYPE.PERCENTAGE:
                case CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE:
                    if (dhours >=80 && dhours< 100)
                        result = colorYellow;   
                    else if (dhours >= 100)
                        result = colorRed;   
                    break;                
            }
       }else{ //type value
            //result = dhours.ToString("0.00");
            result = dhours.ToString("N");

            if (showType == CapacityView.SHOW_TYPE.PERCENTAGE || 
                showType == CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE)
                result+= "%";

                        /*
            decimal divide = directHoursToShifts != 0 ? directHoursToShifts : 1;
            result = (showType == CapacityView.SHOW_TYPE.TYPE_MACHSHIFTHOURS && sreqType.Equals(CapacityReq.REQUIREMENT_MACHINE)) ? 
                     (dhours / divide).ToString("0.00") : dhours.ToString("0.00");            
            
            //if (showType == CapacityView.SHOW_TYPE.TYPE_NORMAL)            
               //System.Windows.Forms.MessageBox.Show("Machine:" + smachine + "\nhours:" + dhours);   
               */
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
