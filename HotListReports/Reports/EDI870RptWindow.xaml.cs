using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NujitWms.ReportLibrary.Concord;
using NujitWms.ReportLibrary.Metelix.HotList;
using Nujit.NujitERP.ClassLib.Common;


namespace HotListReports.Reports{
/// <summary>
/// Interaction logic for Try1268RptWindow.xaml
/// </summary>
public partial 
class Try1268RptWindow : Window{
    

public
Try1268RptWindow(){
    InitializeComponent();
    Loaded += MyWindow_Loaded;    
}
    
private 
void MyWindow_Loaded(object sender, RoutedEventArgs e){    
    showReport();
}
      
private
void showReport(){    
    Telerik.Reporting.Report edi870Report = new Try1268Report();            

    var                             dataSource = edi870Report.DataSource as Telerik.Reporting.SqlDataSource;
    
    Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
    sqlDataSource.ProviderName = "System.Data.Odbc";
    sqlDataSource.ConnectionString = Configuration.CMSConnectionstring;
    sqlDataSource.ConnectionString = "Dsn=DTSAs400;uid=CCRAWFORD;pwd=WORKING1";
    string selectMain =

" select HOT_ProdID as PartNumber "+
" ,'MainM' AS MainMaterial " +
" ,'MTP' AS MTPart " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >0 and w.VDSEQ# < 10) ) as RTPart " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=10 and w.VDSEQ# < 20) ) as Part10 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=20 and w.VDSEQ# < 30) ) as Part20 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=30 and w.VDSEQ# < 40) ) as Part30 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=40 and w.VDSEQ# < 50) ) as Part40 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=50 and w.VDSEQ# < 60) ) as Part50 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=60 and w.VDSEQ# < 70) ) as Part60 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=70 and w.VDSEQ# < 80) ) as Part70 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=80 and w.VDSEQ# < 90) ) as Part80 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=90 and w.VDSEQ# < 100) ) as Part90 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=100 and w.VDSEQ# < 110) ) as Part100 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=110 and w.VDSEQ# < 120) ) as Part110 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=120 and w.VDSEQ# < 130) ) as Part120 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=130 and w.VDSEQ# < 140) ) as Part130 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=140 and w.VDSEQ# < 150) ) as Part140 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=150 and w.VDSEQ# < 160) ) as Part150 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from PLCORP.wipb w , PLCORP.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=160) ) as Part160 " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from PLCORP.seri where HTPART = HOT_ProdID and HTSTS = 'H' ) as QtyHold " +
" ,(select sum(BXQTOH)  from PLCORP.stkb where BxPART = HOT_ProdID) as FG " +
" ,0 as PAST " +
" ,1 as WEEK1 " +
" ,2 as WEEK2 " +
" ,3 as WEEK3 " +
" ,4 as WEEK4 " +
" ,5 as WEEK5 " +
" ,6 as WEEK6 " +
" ,7 as WEEK7 " +
" ,8 as WEEK8 " +
" from(select distinct(AVPART) as HOT_ProdID " +
"     from PLCORP.stkmm " +
    " ) as query " +
" order by HOT_ProdID";
                
    //edi870Report.ReportParameters["tnaParam"].Value = edi870Hdr.TNA;
    sqlDataSource.SelectCommand = selectMain;   
    
    sqlDataSource.Parameters.Add("W1", System.Data.DbType.Int32,7);
    sqlDataSource.Parameters.Add("W2", System.Data.DbType.Int32,8);
        
    edi870Report.DataSource = sqlDataSource;
    this.edi870RptViewer.ReportSource = edi870Report;    
}

}
}
