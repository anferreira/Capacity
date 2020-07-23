using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace  Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel{

public 
class ReportsExcelAdapter : ExcelAdapter{

public
ReportsExcelAdapter(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void generateExcelReport(string path, string excelTable, string sql, bool pivotTableExist){
	try{
		ExcelUserQuery excelUserQuery = executeDBQuery(sql, excelTable);
		
		bool create = false;
        if (!System.IO.File.Exists(path)){
			createFile(path);
			create=true;
		}
		
		if(!create){
			removeName(path, excelTable);
		}

		openConnection(path);

		if(!create){
			try{
				executeExcelNonQuery(excelUserQuery.getDropTableSql());
				executeExcelNonQuery(excelUserQuery.getDropSheetSql());
			}
			catch(Exception){
				//if the table doesn't exist the drop table fails but it's not a problem cause we are just trying to delete the table
			}
		}

		executeExcelNonQuery(excelUserQuery.getCreateSql());

		if(excelUserQuery.getInsertSqls().Count>0){
			ArrayList inserts = excelUserQuery.getInsertSqls();
			foreach(string insert in inserts){
				executeExcelNonQuery(insert);
			}
		}

		closeConnection();

		if(create)
			removeExtraSheets(path);

	//	if((excelUserQuery.getInsertSqls().Count>0) && (pivotTableExist)){
	//		updatePivotTable(path);
	//	}
		
	}catch(ExcelPersistenceException ex){
		throw ex;
	}catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<generateExcelReport> : " + ex.Message, ex);
	}
}

} // class

} // namespace
