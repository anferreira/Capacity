/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapShiftTaskDataBase : GenericDataBaseElement {

private int Id;
private string TaskName;
private string DirInd;
private decimal RatePerHr;
private string ManufactProcess;
private string EmpTempCanPerform;
        
public
CapShiftTaskDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capshifttask where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capshifttask where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.TaskName = reader.GetString("TaskName");
	this.DirInd = reader.GetString("DirInd");
    this.RatePerHr = reader.GetDecimal("RatePerHr");
    this.ManufactProcess = reader.GetString("ManufactProcess");
    this.EmpTempCanPerform = reader.GetString("EmpTempCanPerform");
}

public override
void write(){ 
	string sql = "insert into capshifttask(" + 	
		"TaskName," +
		"DirInd," +
        "RatePerHr,"+
        "ManufactProcess," +
        "EmpTempCanPerform" +
        
        ") values (" + 
		
		"'" + Converter.fixString(TaskName) + "'," +
		"'" + Converter.fixString(DirInd) + "'," +   
        NumberUtil.toString(RatePerHr) + "," +
        "'" + Converter.fixString(ManufactProcess) + "'," +
        "'" + Converter.fixString(EmpTempCanPerform) + "')";
            
    write(sql);	
    this.setId(dataBaseAccess.getLastId());	        
}

public override
void update(){
	string sql = "update capshifttask set " +		
		"TaskName = '" + Converter.fixString(TaskName) + "', " +
		"DirInd = '" + Converter.fixString(DirInd) + "', " +
        "RatePerHr = " + NumberUtil.toString(RatePerHr) + ", " +
        "ManufactProcess = '" + Converter.fixString(ManufactProcess) + "', " +
        "EmpTempCanPerform = '" + Converter.fixString(EmpTempCanPerform) + "'  " +
        
        "where " + getWhereCondition();    
	update(sql);
}


public override
void delete(){
	string sql = "delete from capshifttask where " + getWhereCondition();    
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
void setTaskName(string TaskName){
	this.TaskName = TaskName;
}

public
void setDirInd(string DirInd){
	this.DirInd = DirInd;
}

public
void setRatePerHr(decimal RatePerHr){
	this.RatePerHr = RatePerHr;
}

public
void setManufactProcess(string ManufactProcess){
	this.ManufactProcess = ManufactProcess;
}

public
void setEmpTempCanPerform(string EmpTempCanPerform){
	this.EmpTempCanPerform = EmpTempCanPerform;
}

public
int getId(){
	return Id;
}

public
string getTaskName(){
	return TaskName;
}

public
string getDirInd(){
	return DirInd;
}

public
decimal getRatePerHr(){
	return RatePerHr;
}

public
string getManufactProcess(){
	return ManufactProcess;
}

public
string getEmpTempCanPerform(){
	return EmpTempCanPerform;
}

} // class
} // package