using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using Nujit.NujitWms.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace HotListReports.Windows.Customers{

public
class QtyShipOrderColorConverter : IValueConverter{

public
object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
     string scolor = "Black";
    
    if (value != null) { 
        if (value is UpCum01PView){
            UpCum01PView upCum01PView = (UpCum01PView)value;
            if (System.Convert.ToInt64(upCum01PView.FGQSHP) != System.Convert.ToInt64(upCum01PView.QtyOrder))        
              scolor = "Red";
        }

        if (value is ShipExportSum){
            ShipExportSum shipExportSum = (ShipExportSum)value;
            if (System.Convert.ToInt64(shipExportSum.QtyShipped) != System.Convert.ToInt64(shipExportSum.QtyOrder))        
              scolor = "Red";
        }
    }
    return scolor;
}

public
object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo){
    throw new NotImplementedException();
}

}
}
