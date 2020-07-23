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
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmployeeLabourDataBase : GenericDataBaseElement {

private int Id;
private string EmpId;
private int LabourTypeId;

private DateTime ApprovDate;
private DateTime ApprovUntilDate;
private string  ApprovByEmpId;
private int     ApprovLevel;

public
EmployeeLabourDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from employeelabour where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from employeelabour where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.Id             = reader.GetInt32("Id");
	this.EmpId          = reader.GetString("EmpId");
	this.LabourTypeId   = reader.GetInt32("LabourTypeId");

    this.ApprovDate     = reader.GetDateTime("ApprovDate");
    this.ApprovUntilDate= reader.GetDateTime("ApprovUntilDate");
    this.ApprovByEmpId  = reader.GetString("EmpId");
    this.ApprovLevel    = reader.GetInt32("ApprovLevel");
}

public override
void write(){
	string sql = "insert into employeelabour(" + 
		"EmpId," +
		"LabourTypeId," +
        "ApprovDate," +
        "ApprovUntilDate," +
        "ApprovByEmpId," +
        "ApprovLevel" +
         
		") values (" + 

		"'" + Converter.fixString(EmpId) + "'," +
		"" + NumberUtil.toString(LabourTypeId) + ","+

        "'" + DateUtil.getCompleteDateRepresentation(ApprovDate,DateUtil.MMDDYYYY) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(ApprovUntilDate, DateUtil.MMDDYYYY) + "'," +
        "'" + Converter.fixString(ApprovByEmpId) + "'," +
        "" + NumberUtil.toString(ApprovLevel) + ")";

    write(sql);
	this.setId(dataBaseAccess.getLastId());
}

public override
void update(){
	string sql = "update employeelabour set " +
		"EmpId = '" + Converter.fixString(EmpId) + "', " +
		"LabourTypeId = " + NumberUtil.toString(LabourTypeId) + ", " +
        "ApprovDate='" + DateUtil.getCompleteDateRepresentation(ApprovDate,DateUtil.MMDDYYYY) + "'," +
        "ApprovUntilDate='" + DateUtil.getCompleteDateRepresentation(ApprovUntilDate, DateUtil.MMDDYYYY) + "'," +
        "ApprovByEmpId='" + Converter.fixString(ApprovByEmpId) + "'," +
        "ApprovLevel=" + NumberUtil.toString(ApprovLevel) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from employeelabour where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Id = " + NumberUtil.toString(Id) + "";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setEmpId(string EmpId){
	this.EmpId = EmpId;
}

public
void setLabourTypeId(int LabourTypeId){
	this.LabourTypeId = LabourTypeId;
}

public
void setApprovDate(DateTime ApprovDate){
	this.ApprovDate = ApprovDate;
}

public
void setApprovUntilDate(DateTime ApprovUntilDate){
	this.ApprovUntilDate = ApprovUntilDate;
}

public
void setApprovByEmpId(string ApprovByEmpId){
	this.ApprovByEmpId = ApprovByEmpId;
}

public
void setApprovLevel(int ApprovLevel){
	this.ApprovLevel = ApprovLevel;
}

public
int getId(){
	return Id;
}

public
string getEmpId(){
	return EmpId;
}

public
int getLabourTypeId(){
	return LabourTypeId;
}

public
DateTime getApprovDate(){
	return ApprovDate;
}

public
DateTime getApprovUntilDate(){
	return ApprovUntilDate;
}

public
string getApprovByEmpId(){
	return ApprovByEmpId;
}

public
int getApprovLevel(){
	return ApprovLevel;
}

} // class
} // package