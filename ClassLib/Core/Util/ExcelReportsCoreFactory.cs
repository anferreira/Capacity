using System;
using System.Collections;
using System.IO;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.ExcelReports;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Remote;
using Nujit.NujitERP.ClassLib.Core.ExcelReports;
using Nujit.NujitERP.ClassLib.ErpException;


namespace Nujit.NujitERP.ClassLib.Core.Util{

public
class ExcelReportsCoreFactory : EmployeeCoreFactory{

public
ExcelReportsCoreFactory() : base(){
}

public
void generateExcelReport(ExcelReportSetup excelReportSetup){
	ReportsExcelAdapter adapter = null;
	string file = string.Empty;
	string excelTable = string.Empty;
	try {
		if (excelReportSetup.getSqlSentence().Length<6 || !excelReportSetup.getSqlSentence().Substring(0,6).ToLower().Equals("select"))
			throw new NujitException("Can run only SELECT statements");
		if(!Directory.Exists(excelReportSetup.getPath()))
			throw new NujitException("Invalid Path");
	
		adapter = new ReportsExcelAdapter(dataBaseAccess);

		excelTable = excelReportSetup.getFileName();
		if(excelReportSetup.getFileName().IndexOf(".")>-1)
			excelTable = excelTable.Substring(0,excelTable.IndexOf("."));
		
		file = excelReportSetup.getPath();
		if(!file.Substring(file.Length-1,1).Equals("\\"))
			file+="\\";
		FileInfo fi = new FileInfo(file);
		file=fi.FullName+excelReportSetup.getFileName();
		if(!file.Substring(file.Length-4,4).Equals(".xls"))
			file+=".xls";
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
	bool pivotTableExist = false;
	try{
		
		if (File.Exists(excelReportSetup.getPivotTablePath())) {
			if (File.Exists(file))
				File.Delete(file);
			pivotTableExist = true;
			File.Copy(excelReportSetup.getPivotTablePath(),file,true);
			
		}
		if (File.Exists(file)){
			FileStream s = File.OpenWrite(file);
			s.Close();
		}
	}catch(Exception ex){
		throw new ExcelFileException(ex.Message,ex);
	}

	try{
		string pathTemplate = excelReportSetup.getPivotTablePath();
		string nametemplate = string.Empty;
		if (!pathTemplate.Equals(string.Empty)){
			int i = pathTemplate.LastIndexOf("\\");
			nametemplate = pathTemplate.Substring(i+1,pathTemplate.Length-(i+1));
			i = nametemplate.LastIndexOf(".");
			nametemplate = nametemplate.Substring(0,i);
		}
		if (nametemplate.Equals(string.Empty)) nametemplate = excelTable;

		adapter.generateExcelReport(file,nametemplate,excelReportSetup.getSqlSentence(),pivotTableExist);
	}catch(ExcelPersistenceException ex){
		throw ex;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ExcelReportSetup createExcelReportSetup(){
	return new ExcelReportSetup();
}

public
bool existsExcelReportSetup(string reportName){
	try{
		ExcelReportsSetupDataBase excelReportsSetupDataBase = new ExcelReportsSetupDataBase(dataBaseAccess);

		excelReportsSetupDataBase.setEXC_ReportName(reportName);

		return excelReportsSetupDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ExcelReportSetup readExcelReportSetup(string reportName){
	try{
		ExcelReportsSetupDataBase excelReportsSetupDataBase = new ExcelReportsSetupDataBase(dataBaseAccess);
		excelReportsSetupDataBase.setEXC_ReportName(reportName);

		if (!excelReportsSetupDataBase.exists())
			return null;

		excelReportsSetupDataBase.read();

		ExcelReportSetup excelReportSetup = this.objectDataBaseToObject(excelReportsSetupDataBase);

		return excelReportSetup;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getExcelReportSetupsByDescType(string searchText,string type, int rows){
	try{
		ExcelReportsSetupDataBaseContainer excelReportsSetupDataBaseContainer = new ExcelReportsSetupDataBaseContainer(dataBaseAccess);
		excelReportsSetupDataBaseContainer.readByDescType(searchText,type, rows);
		string[][] items = new string[excelReportsSetupDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = excelReportsSetupDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ExcelReportsSetupDataBase excelReportsSetupDataBase = (ExcelReportsSetupDataBase) en.Current;
			ExcelReportSetup excelReportSetup = objectDataBaseToObject(excelReportsSetupDataBase);
			string[] item = new String[5];
			item[0] = excelReportsSetupDataBase.getEXC_ReportName();
			item[1] = excelReportsSetupDataBase.getEXC_Path();
			item[2] = excelReportsSetupDataBase.getEXC_FileName();
			item[3] = excelReportSetup.getSqlSentenceUnformatted();
			item[4] = excelReportsSetupDataBase.getEXC_PivotTablePath();
			items[i] = item;
			i++;
		}
		return items;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateExcelReportSetup(ExcelReportSetup excelReportSetup){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ExcelReportsSetupDataBase excelReportsSetupDataBase = this.objectToObjectDataBase(excelReportSetup);
		excelReportsSetupDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeExcelReportSetup(ExcelReportSetup excelReportSetup){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ExcelReportsSetupDataBase excelReportsSetupDataBase = this.objectToObjectDataBase(excelReportSetup);
		excelReportsSetupDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteExcelReportSetup(string reportName){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ExcelReportsSetupDataBase excelReportsSetupDataBase = new ExcelReportsSetupDataBase(dataBaseAccess);

		excelReportsSetupDataBase.setEXC_ReportName(reportName);
		excelReportsSetupDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
ExcelReportSetup objectDataBaseToObject(ExcelReportsSetupDataBase excelReportsSetupDataBase){
	ExcelReportSetup excelReportSetup = new ExcelReportSetup();

	excelReportSetup.setReportName(excelReportsSetupDataBase.getEXC_ReportName());
	excelReportSetup.setPath(excelReportsSetupDataBase.getEXC_Path());
	excelReportSetup.setFileName(excelReportsSetupDataBase.getEXC_FileName());
	excelReportSetup.setSqlSentence(excelReportsSetupDataBase.getEXC_SqlSentence());
	excelReportSetup.setType(excelReportsSetupDataBase.getEXC_Type());
	excelReportSetup.setPivotTablePath(excelReportsSetupDataBase.getEXC_PivotTablePath());
	return excelReportSetup;
}

private
ExcelReportsSetupDataBase objectToObjectDataBase(ExcelReportSetup excelReportSetup){
	ExcelReportsSetupDataBase excelReportsSetupDataBase = new ExcelReportsSetupDataBase(dataBaseAccess);
	excelReportsSetupDataBase.setEXC_ReportName(excelReportSetup.getReportName());
	excelReportsSetupDataBase.setEXC_Path(excelReportSetup.getPath());
	excelReportsSetupDataBase.setEXC_FileName(excelReportSetup.getFileName());
	excelReportsSetupDataBase.setEXC_SqlSentence(excelReportSetup.getSqlSentence());
	excelReportsSetupDataBase.setEXC_Type(excelReportSetup.getType());
	excelReportsSetupDataBase.setEXC_PivotTablePath(excelReportSetup.getPivotTablePath());
	return excelReportsSetupDataBase;
}

public
ExcelReportSetup cloneExcelReportSetup(ExcelReportSetup excelReportSetup){
	ExcelReportSetup excelReportSetupClone = new ExcelReportSetup();

	excelReportSetupClone.setReportName(excelReportSetup.getReportName());
	excelReportSetupClone.setPath(excelReportSetup.getPath());
	excelReportSetupClone.setFileName(excelReportSetup.getFileName());
	excelReportSetupClone.setSqlSentence(excelReportSetup.getSqlSentence());
	excelReportSetupClone.setType(excelReportSetup.getType());
	excelReportSetupClone.setPivotTablePath(excelReportSetup.getPivotTablePath());
	return excelReportSetupClone;
}

} // class

} // package