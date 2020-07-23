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
class EmpShiftScheduleReportViewDataBase : GenericDataBaseElement {

private int Id;
private int Detail;
private string Dept;
private int ShiftNum;
private string EmpId;
private string FirstName;
private string LastName;
private int MachId;
private string Mach;
private string MachDesc;               
private int Priority;

public
EmpShiftScheduleReportViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from empshiftschedulereportview where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from empshiftschedulereportview where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.Detail = reader.GetInt32("Detail");
	this.Dept = reader.GetString("Dept");
	this.ShiftNum = reader.GetInt32("ShiftNum");
	this.EmpId = reader.GetString("EmpId");
	this.FirstName = reader.GetString("FirstName");
	this.LastName = reader.GetString("LastName");
	this.MachId = reader.GetInt32("MachId");
	this.Mach = reader.GetString("Mach");
    this.MachDesc = reader.GetString("MachDesc");    
    this.Priority = reader.GetInt32("Priority");
}


public override
void write(){
    throw new PersistenceException("write Function not enabled");    
}

public override
void update(){
    throw new PersistenceException("update Function not enabled");    
}

public override
void delete(){
   throw new PersistenceException("delete Function not enabled");    
}

public
string getWhereCondition(){
	string sqlWhere =
		"Id = " + NumberUtil.toString(Id) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + "";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setDetail(int Detail){
	this.Detail = Detail;
}

public
void setDept(string Dept){
	this.Dept = Dept;
}

public
void setShiftNum(int ShiftNum){
	this.ShiftNum = ShiftNum;
}

public
void setEmpId(string EmpId){
	this.EmpId = EmpId;
}

public
void setFirstName(string FirstName){
	this.FirstName = FirstName;
}

public
void setLastName(string LastName){
	this.LastName = LastName;
}

public
void setMachId(int MachId){
	this.MachId = MachId;
}

public
void setMach(string Mach){
	this.Mach = Mach;
}

public
void setMachDesc(string MachDesc){
	this.MachDesc = MachDesc;
}

public
void setPriority(int Priority){
	this.Priority = Priority;
}

public
int getId(){
	return Id;
}

public
int getDetail(){
	return Detail;
}

public
string getDept(){
	return Dept;
}

public
int getShiftNum(){
	return ShiftNum;
}

public
string getEmpId(){
	return EmpId;
}

public
string getFirstName(){
	return FirstName;
}

public
string getLastName(){
	return LastName;
}

public
int getMachId(){
	return MachId;
}

public
string getMach(){
	return Mach;
}

public
int getPriority(){
	return Priority;
}

public
string getMachDesc(){
	return  MachDesc;
}

} // class
} // package