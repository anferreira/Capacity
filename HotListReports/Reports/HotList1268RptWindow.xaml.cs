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


namespace HotListReports.Reports
{
/// <summary>
/// Interaction logic for HotList1268RptWindow.xaml
/// </summary>
public partial 
class HotList1268RptWindow : Window{
public HotList1268RptWindow(){
    InitializeComponent();
    Loaded += MyWindow_Loaded;
}
    
private
void MyWindow_Loaded(object sender, RoutedEventArgs e){
    showReport2();
}

private
void showReport2(){
   try{
        Telerik.Reporting.Report h1268Report = new HotList1268_2Report();
        this.hotList1268RptViewer.ReportSource = h1268Report;
                this.hotList1268RptViewer.RefreshReport();

    }catch(NujitException ne){     
        MessageBox.Show(ne.Message);
	}
}
    private
void showReport(){
    try{
    Telerik.Reporting.Report glReport = new HotList1268Report();
                         
    var                                 dataSource = glReport.DataSource as Telerik.Reporting.SqlDataSource;
    Telerik.Reporting.SqlDataSource     sqlDataSource = new Telerik.Reporting.SqlDataSource();
    
    sqlDataSource.ConnectionString = "DSN=DTSMysql;UID=root;PWD=funnel;";// Configuration.SqlDBConnectionString;
    sqlDataSource.ConnectionString = "DSN=DS_MySql;uid=root;pwd=funnel;";
               
    sqlDataSource.ProviderName = "System.Data.Odbc";
    sqlDataSource.ProviderName = "MySql.Data.MySqlClient";

                sqlDataSource.ConnectionString =Configuration.SqlDBConnectionString;
    //sqlDataSource.ConnectionString = "Driver={MySQL ODBC 5.3 ANSI Driver};System=127.0.0.1;Database=funnel;Uid=root;Pwd=funnel;";
    MessageBox.Show(sqlDataSource.ProviderName + "\n\n" + sqlDataSource.ConnectionString);

    
            //sqlDataSource.ConnectionString = "Driver={MySQL ODBC 5.3 ANSI Driver};System=127.0.0.1;Uid=root;Pwd=funnel;Database=funnel;";

            //    sqlDataSource.ProviderName = "MySql.Data";
            //  sqlDataSource.ConnectionString = "Server=127.0.0.1;Port=3306;Database=funnel;UserId=root;Password=funnel;";    

/*sqlServer
    sqlDataSource.ProviderName = "System.Data.SqlClient";
    sqlDataSource.ConnectionString = "Server=localhost;uid=sa;pwd=nujit;database=MRP-NewArch;";
*/
 

                string selectMain = "select HOT_ProdID as PartNumber" +
                       ",(select b.BMS_MatID from bomsum as b where BMS_ProdID = HOT_ProdID limit 1) as MainMaterial" +
       ",(select COALESCE(sum(i.IPL_Qoh), 0)  from invpltloc i , prodfminfo p" +
               "where IPL_ProdID = (select b.BMS_MatID from bomsum as b" +
               "where BMS_ProdID = HOT_ProdID limit 1)" +
               "and PFS_ProdID = IPL_ProdID" +
               "and IPL_Seq = PFS_SeqLast) as QohMainMaterial" +
       ",(select COALESCE(SUM(IPL_Qoh), 0)" +
       "from prodfmactsub as s , invpltloc i" +
       "where PC_ProdID = HOT_ProdID and PC_RepPoint = 'Y'" +
       "and IPL_ProdID = PC_ProdID and IPL_Seq = PC_Seq and" +
         "(PC_Seq > 0 and PC_Seq < 10) ) as QohSeq0" +


       ",(select COALESCE(SUM(IPL_Qoh), 0)" +
       "from prodfmactsub as s , invpltloc i" +
       "where PC_ProdID = HOT_ProdID and PC_RepPoint = 'Y'" +
       "and IPL_ProdID = PC_ProdID and IPL_Seq = PC_Seq and" +
       "(PC_Seq >= 10 and PC_Seq < 20) ) as QohSeq10" +

       ",(select COALESCE(SUM(IPL_Qoh), 0)" +
       "from prodfmactsub as s , invpltloc i" +
       "where PC_ProdID = HOT_ProdID and PC_RepPoint = 'Y'" +
       "and IPL_ProdID = PC_ProdID and IPL_Seq = PC_Seq and" +
       "(PC_Seq >= 20 and PC_Seq < 30) ) as QohSeq20" +

       ",(select COALESCE(SUM(IPL_Qoh), 0)" +
       "from prodfmactsub as s , invpltloc i" +
       "where PC_ProdID = HOT_ProdID and PC_RepPoint = 'Y'" +
       "and IPL_ProdID = PC_ProdID and IPL_Seq = PC_Seq and" +
       "(PC_Seq >= 30 and PC_Seq < 40) ) as QohSeq30" +

       ",(select COALESCE(SUM(IPL_Qoh), 0)" +
       "from prodfmactsub as s , invpltloc i" +
       "where PC_ProdID = HOT_ProdID and PC_RepPoint = 'Y'" +
       "and IPL_ProdID = PC_ProdID and IPL_Seq = PC_Seq and" +
       "(PC_Seq >= 40 and PC_Seq < 50) ) as QohSeq40" +

       ",(select COALESCE(SUM(IPL_Qoh), 0)" +
       "from prodfmactsub as s , invpltloc i" +
       "where PC_ProdID = HOT_ProdID and PC_RepPoint = 'Y'" +
       "and IPL_ProdID = PC_ProdID and IPL_Seq = PC_Seq and" +
       "PC_Seq >= 50  ) as QohSeq50" +

       ",(select COALESCE(SUM(i.IPL_Qoh), 0) from invpltloc i" +
       "where IPL_ProdID = HOT_ProdID and IPL_Seq = (select PFS_SeqLast from prodfminfo where PFS_ProdID = HOT_ProdID)) as QohFG" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) <= 0" +
       ") as PastWeek" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 1" +
       ") as Week1" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 2" +
       ") as Week2" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 3" +
       ") as Week3" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 4" +
       ") as Week4" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 5" +
       ") as Week5" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 6" +
       ") as Week6" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 7" +
       ") as Week7" +
       ",(" +
       "select COALESCE(sum(DEDT_QtyID), 0)" +
       "from demdetail as d" +
       "where DEDT_ProdID = HOT_ProdID" +
       "and(WEEKOFYEAR(d.DEDT_DtShip) - WEEKOFYEAR(CURDATE()) + 1) = 8" +
       ") as Week8" +
       "from(select distinct(HOT_ProdID) from hotlist" +
       "where Hot_Id = (select max(id) from hotlisthdr)" +
       ") as query  where HOT_ProdID like 'FAU%'" +
       "order by HOT_ProdID";

        selectMain = "select 'Part' as PartNumber" +
                     ",'MainMat' as MainMaterial"+                     
                     ",2 as QohMainMaterial" +
                    ",0 as QohSeq0"+
                    ",10 as QohSeq10" +
                    ",20 as QohSeq20" +
                    ",30 as QohSeq30" +
                    ",40 as QohSeq40" +
                    ",50 as QohSeq50" +
                    ",@QohValue as QohFG" +
                    ",10 as PastWeek" +
                    ",1 as Week1" +
                    ",2 as Week2" +
                    ",3 as Week3" +
                    ",4 as Week4" +
                    ",3 as Week5" +
                    ",6 as Week6" +
                    ",7 as Week7" +
                    ",8 as Week8" ;
                /*
        selectMain = "select 'Part' as PartNumber" +
                            ",'MainMat' as MainMaterial" +
                            ",25 as QohMainMaterial" +
                            ",0 as QohSeq0" +
                            ",10 as QohSeq10" +
                            ",20 as QohSeq20" +
                            ",30 as QohSeq30" +
                            ",40 as QohSeq40" +
                            ",50 as QohSeq50" +
                            ",70 as QohFG" +
                            ",10 as PastWeek" +
                            ",1 as Week1" +
                            ",2 as Week2" +
                            ",3 as Week3" +
                            ",4 as Week4" +
                            ",35 as Week5" +
                            ",6 as Week6" +
                            ",7 as Week7" +
                            ",8 as Week8";*/
                /*
string[] itemsSqlParams = selectMain.Split('?');

for (int i = 1; i < itemsSqlParams.Length; i++)
sqlDataSource.Parameters.Add("QohValue" + i.ToString(), System.Data.DbType.Double, 25);
*/
        sqlDataSource.Parameters.Add("@QohValue", System.Data.DbType.Double,25);

        //glReport.ReportParameters["titleReportParam"].Value = "Param Title";
                

        sqlDataSource.SelectCommand = selectMain;
        glReport.DataSource = sqlDataSource;

      this.hotList1268RptViewer.ReportSource = glReport;

    }catch(NujitException ne){
       // FormException formException = new FormException(ne);
        //formException.Show();
        MessageBox.Show(ne.Message);
	}
}    
}
}
