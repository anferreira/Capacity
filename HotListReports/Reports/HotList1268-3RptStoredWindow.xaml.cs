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
using Telerik.Reporting;
using NujitWms.ReportLibrary.Metelix.HotList;
using Telerik.Reporting.Processing;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.ErpException;
using NujitWms.ReportLibrary.Concord;


namespace HotListReports.Reports
{
/// <summary>
/// Interaction logic for HotList1268_3RptStoredWindow.xaml
/// </summary>
public partial 
class HotList1268_3RptStoredWindow : Window{
public HotList1268_3RptStoredWindow(){
    InitializeComponent();
    Loaded += MyWindow_Loaded;
}
    
private
void MyWindow_Loaded(object sender, RoutedEventArgs e){
    showReport3();
}

private
void showReport3(){
   try{
        Telerik.Reporting.Report h1268Report = new HotList1268_3StoredReport();
        this.hotList1268RptViewer.ReportSource = h1268Report;
                this.hotList1268RptViewer.RefreshReport();

    }catch(NujitException ne){     
        MessageBox.Show(ne.Message);
	}
}

private
void showReport(){
    try{

    Telerik.Reporting.Report h1268Report = new HotList1268_3StoredReport();
    var dataSource = h1268Report.DataSource as Telerik.Reporting.SqlDataSource;
    Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
    sqlDataSource.ProviderName = "System.Data.Odbc";
    sqlDataSource.ConnectionString = Configuration.CMSConnectionstring;

                MessageBox.Show(sqlDataSource.ConnectionString);
    string selectMain =

" select HOT_ProdID as PartNumber "+
" ,'MainM' AS MainMaterial " +
" ,'MTP' AS MTPart " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >0 and w.VDSEQ# < 10) ) as RTPart " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=10 and w.VDSEQ# < 20) ) as Part10 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=20 and w.VDSEQ# < 30) ) as Part20 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=30 and w.VDSEQ# < 40) ) as Part30 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=40 and w.VDSEQ# < 50) ) as Part40 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=50 and w.VDSEQ# < 60) ) as Part50 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=60 and w.VDSEQ# < 70) ) as Part60 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=70 and w.VDSEQ# < 80) ) as Part70 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=80 and w.VDSEQ# < 90) ) as Part80 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=90 and w.VDSEQ# < 100) ) as Part90 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=100 and w.VDSEQ# < 110) ) as Part100 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=110 and w.VDSEQ# < 120) ) as Part110 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=120 and w.VDSEQ# < 130) ) as Part120 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=130 and w.VDSEQ# < 140) ) as Part130 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=140 and w.VDSEQ# < 150) ) as Part140 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=150 and w.VDSEQ# < 160) ) as Part150 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=160) ) as Part160 " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri where HTPART = HOT_ProdID and HTSTS = 'H' ) as QtyHold " +
" ,(select sum(BXQTOH)  from cmsdat.stkb where BxPART = HOT_ProdID) as FG " +
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
" from cmsdat.stkmm limit 10 " +
" ) as query " +
" order by HOT_ProdID ";

    sqlDataSource.SelectCommand = selectMain;
    h1268Report.DataSource = sqlDataSource;    

    this.hotList1268RptViewer.ReportSource = h1268Report;
    this.hotList1268RptViewer.RefreshReport();

  
    }catch(NujitException ne){
       // FormException formException = new FormException(ne);
        //formException.Show();
        MessageBox.Show(ne.Message);
	}
}    

      
private
void showReportEdi870(){

    EDI870GoodReport edi870Report = new EDI870GoodReport();
    var dataSource = edi870Report.DataSource as Telerik.Reporting.SqlDataSource;
    Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
    sqlDataSource.ProviderName = "System.Data.Odbc";
    sqlDataSource.ConnectionString = Configuration.CMSConnectionstring;
    
    string selectMain = "select d.DTL,d.PART,d.PRODSERIAL,d.QTYPROD,d.SCRAP,d.DAMFAULT, d.DAMTYPE, d.ACTUALLBS,d.ACTUALKGS,d.THEORETLBS,d.THEORETKGS,d.MATCLASS,d.EDGETYPE,d.MATSTATUS,d.PROCCODE,d.DTLPOSTED from nujit.edi870hdr h  , nujit.edi870dtl d where CONTROLID='37007-999' and d.TNA=h.TNA and  d.TPA=h.TPA and d.TDA=h.TDA and d.TTA=h.TTA";
    

    sqlDataSource.SelectCommand = selectMain;   
    edi870Report.DataSource = sqlDataSource;    
    this.hotList1268RptViewer.ReportSource = edi870Report;   
}
}
}
