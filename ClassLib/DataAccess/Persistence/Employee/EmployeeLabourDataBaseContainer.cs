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
class EmployeeLabourDataBaseContainer : GenericDataBaseContainer {

public
EmployeeLabourDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from employeelabour";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from employeelabour";
	if (searchText.Length > 0){
		sql += " where EmpId like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmployeeLabourDataBase employeeLabourDataBase = new EmployeeLabourDataBase(dataBaseAccess);
		employeeLabourDataBase.load(reader);
		this.Add(employeeLabourDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table employeelabour";
	truncate(sql);
}

public 
void readByEmpId(string sempId){
	string sql = "select * from employeelabour where EmpId = '" + Convert.ToString(sempId) + "'" ;
	read(sql);
}

public 
void readByEmpIdLabType(string sempId,int ilabourTypeId){
	string sql = "select * from employeelabour where EmpId = '" + Convert.ToString(sempId) + "'" +
                 " and LabourTypeId= " + NumberUtil.toString(ilabourTypeId);
	read(sql);
}

public 
void deleteByEmpId(string sempId){
	string sql = "delete from employeelabour where EmpId = '" + Convert.ToString(sempId) + "'" ;
	delete(sql);
}


} // class
} // package