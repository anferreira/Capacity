/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmployeeShiftDataBaseContainer : GenericDataBaseContainer {

public
EmployeeShiftDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from employeeshift";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from employeeshift";
	if (searchText.Length > 0){
		sql += " where Plant like '" + Converter.fixString(searchText) + "%'";
		sql += " or EmpId like '" + Converter.fixString(searchText) + "%'";
		sql += " or Status like '" + Converter.fixString(searchText) + "%'";
		sql += " or MonWork like '" + Converter.fixString(searchText) + "%'";
		sql += " or TueWork like '" + Converter.fixString(searchText) + "%'";
		sql += " or WedWork like '" + Converter.fixString(searchText) + "%'";
		sql += " or ThuWork like '" + Converter.fixString(searchText) + "%'";
		sql += " or FriWork like '" + Converter.fixString(searchText) + "%'";
		sql += " or SatWork like '" + Converter.fixString(searchText) + "%'";
		sql += " or SunWork like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmployeeShiftDataBase employeeShiftDataBase = new EmployeeShiftDataBase(dataBaseAccess);
		employeeShiftDataBase.load(reader);
		this.Add(employeeShiftDataBase);
	}
}

public 
void readByFilters(string sid,int ishiftNum,DateTime startDate,int rows){	
	string sql = "select * from employeeShift";

    if (!string.IsNullOrEmpty(sid))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("EmpID", sid);
    if (ishiftNum > 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "ShiftNum=" + NumberUtil.toString(ishiftNum);

    if (startDate != DateUtil.MinValue)
        sql= DBFormatter.addWhereAndSentence(sql) + "StartDate='" + DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY) + "'";

    sql+= " order by StartDate desc,ShiftNum";

    if (rows > 0)
	   sql = DBFormatter.selectTopRows(sql,rows);
 
	read(sql);		
}


public 
void truncate(){
	string sql = "truncate table employeeshift";
	truncate(sql);
}

} // class
} // package