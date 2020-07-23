using System;
using DataDynamics.ActiveReports;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Reports{


public 
class GenerateReportFormat{


public static 
string generateReport(ActiveReport rpt, DataSet dataSet, string dataMember, int type){
    setReport(rpt, dataSet, dataMember);
    rpt.Run();
    return openReportFormat(rpt, type, true);
}

public static 
string generateReport(ActiveReport rpt, DataSet dataSet, string dataMember, int type, bool open){
    setReport(rpt, dataSet, dataMember);
    rpt.Run();
	return openReportFormat(rpt, type, open);
}

private static 
void setReport(ActiveReport rpt, DataSet dataSet,string dataMember){
    rpt.SetLicense("Mauricio Della-Quercia,Nujit Inc.,DD-ARN-10-E000241, CXATZQQXKZ3J5Q2542Q9");
    rpt.DataSource = dataSet;
    rpt.DataMember = dataMember;
}

private static 
string openReportFormat(ActiveReport rpt, int type, bool open){
    string filename = Configuration.ReportPath + "\\" + rpt.DataMember +
			DateUtil.formatCompleteDate(System.DateTime.Now, DateUtil.MMDDYYYY);

	if (type == Constants.PDF_FORMAT){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".pdf")))
			filename += ".pdf";
        DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport= new DataDynamics.ActiveReports.Export.Pdf.PdfExport();

		pdfExport.Export(rpt.Document, filename);
		pdfExport.Dispose();
	}

	if (type ==Constants.HTML_FORMAT){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".html")))
			filename += ".html";

        DataDynamics.ActiveReports.Export.Html.HtmlExport htmlExport= new DataDynamics.ActiveReports.Export.Html.HtmlExport();
		htmlExport.Export(rpt.Document, filename);
		htmlExport.Dispose();
	}

	if (type == Constants.XLS_FORMAT){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".xls")))
			filename += ".xls";

        DataDynamics.ActiveReports.Export.Xls.XlsExport xlsExport = new DataDynamics.ActiveReports.Export.Xls.XlsExport();

		xlsExport.Export(rpt.Document, filename);
		xlsExport.Dispose();
	}

	if (type == Constants.RTF_FORMAT){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".rtf")))
			filename += ".rtf";
        DataDynamics.ActiveReports.Export.Rtf.RtfExport rtfExport= new DataDynamics.ActiveReports.Export.Rtf.RtfExport();	

		rtfExport.Export(rpt.Document, filename);
		rtfExport.Dispose();
	}
	
	if (open){
		ShellLib.ShellExecute shellExec  = new ShellLib.ShellExecute();
		shellExec.Path = @filename;
		shellExec.Execute();	
	}

	return filename;
}

}

}
