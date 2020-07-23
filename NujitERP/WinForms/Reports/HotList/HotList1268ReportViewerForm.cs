using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting;
using NujitWms.ReportLibrary.Metelix.HotList;
//using Telerik.Reporting.Processing;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.ErpException;


namespace Nujit.NujitERP.WinForms.Reports.HotList{

public partial class HotList1268ReportViewerForm : Form{
public HotList1268ReportViewerForm(){
    InitializeComponent();
}

private void HotList1268ReportViewerForm_Load(object sender, EventArgs e){
    //this.reportViewer1.RefreshReport();            
    showReport2();
}

private
void showReport2(){
   try{
        Telerik.Reporting.Report h1268Report = new HotList1268_2Report();        
        this.reportViewer1.ReportSource = h1268Report;

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
    sqlDataSource.ProviderName = "System.Data.Odbc";
    sqlDataSource.ConnectionString = Configuration.SqlDBConnectionString;

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

        sqlDataSource.SelectCommand = selectMain;
        glReport.DataSource = sqlDataSource;

        this.reportViewer1.ReportSource = glReport;

    }catch(NujitException ne){
        FormException formException = new FormException(ne);
        formException.Show();
	}
}

}
}
