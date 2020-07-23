using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using Telerik.Windows.Controls;
using Nujit.NujitWms.WinForms.Util.Controllers;
using Nujit.NujitERP.ClassLib.Core.Customer;

namespace HotListReports.Windows.Customers{

class CustLeadModel : BaseModel2{

public CustLeadModel(Window window) : base(window){    

}

public 
bool save(CustLead custLead){   
    bool bresult=false;
    try {                        
        if (custLead.Id > 0)        
            getCoreFactory().updateCustLead(custLead);
        else
            getCoreFactory().writeCustLead(custLead);
        
         bresult=true;

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    } finally{         

    }
    return bresult;
}
                

}
}
