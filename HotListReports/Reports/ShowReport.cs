using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotListReports.Reports{

public
class ShowReport{

public
ShowReport(){
    Nujit.NujitERP.ClassLib.Common.Configuration.OnApplicationStart(); 
}
    
public 
void hotList1268() {
    try{
        HotList1268RptWindow hotList1268RptWindow = new HotList1268RptWindow();
        hotList1268RptWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("Exception hotList1268 Report: " + ex.Message);
    }
}

public 
void hotList1268_3() {
    try{
        HotList1268_3RptWindow hotList1268_3RptWindow = new HotList1268_3RptWindow();
        hotList1268_3RptWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("Exception hotList1268 Report: " + ex.Message);
    }
}
    
public 
void hotList1268Stored() {
    try{
        HotList1268_3RptStoredWindow hotList1268_3RptStoredWindow = new HotList1268_3RptStoredWindow();
        hotList1268_3RptStoredWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("Exception hotList1268 Report: " + ex.Message);
    }
}

    
public 
void hotList1268Try() {
    try{
        Try1268RptWindow try1268RptWindow = new Try1268RptWindow();
                try1268RptWindow.ShowDialog();
    }catch (Exception ex){
        MessageBox.Show("Exception hotList1268 Report: " + ex.Message);
    }
}


}
}
