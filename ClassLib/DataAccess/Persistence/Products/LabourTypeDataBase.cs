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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class LabourTypeDataBase : GenericDataBaseElement {

private int Id;
private string Code;
private string LabName;
private string DirInd;

public
LabourTypeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}


public
bool read(){
	string sql = "select * from labourtype where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from labourtype where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.Code = reader.GetString("Code");
	this.LabName = reader.GetString("LabName");
	this.DirInd = reader.GetString("DirInd");
}

public override
void write(){
	string sql = "insert into labourtype(" + 
		"Code," +
		"LabName," +
		"DirInd" +

		") values (" + 

		"'" + Converter.fixString(Code) + "'," +
		"'" + Converter.fixString(LabName) + "'," +
		"'" + Converter.fixString(DirInd) + "')";
	write(sql);
	this.setId(dataBaseAccess.getLastId());	  	
}

public override
void update(){
	string sql = "update labourtype set " +
		"Code = '" + Converter.fixString(Code) + "', " +
		"LabName = '" + Converter.fixString(LabName) + "', " +
		"DirInd = '" + Converter.fixString(DirInd) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from labourtype where " + getWhereCondition();
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
void setCode(string Code){
	this.Code = Code;
}

public
void setLabName(string LabName){
	this.LabName = LabName;
}

public
void setDirInd(string DirInd){
	this.DirInd = DirInd;
}

public
int getId(){
	return Id;
}

public
string getCode(){
	return Code;
}

public
string getLabName(){
	return LabName;
}

public
string getDirInd(){
	return DirInd;
}

} // class
} // package