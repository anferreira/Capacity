/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class LastExportedDataBase : GenericDataBaseElement {

private string Code;
private DateTime LastProces;
private string LastId;

public
LastExportedDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from lastexported where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from lastexported where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Code = reader.GetString("Code");
	this.LastProces = reader.GetDateTime("LastProces");
	this.LastId = reader.GetString("LastId");
}

public override
void write(){
	string sql = "insert into lastexported(" + 
		"Code," +
		"LastProces," +
		"LastId" +

		") values (" + 

		"'" + Converter.fixString(Code) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LastProces) + "'," +
		"'" + Converter.fixString(LastId) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update lastexported set " +
		"Code = '" + Converter.fixString(Code) + "', " +
		"LastProces = '" + DateUtil.getCompleteDateRepresentation(LastProces) + "', " +
		"LastId = '" + Converter.fixString(LastId) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from lastexported where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Code = '" + Converter.fixString(Code) + "'";
	return sqlWhere;
}

public
void setCode(string Code){
	this.Code = Code;
}

public
void setLastProces(DateTime LastProces){
	this.LastProces = LastProces;
}

public
void setLastId(string LastId){
	this.LastId = LastId;
}

public
string getCode(){
	return Code;
}

public
DateTime getLastProces(){
	return LastProces;
}

public
string getLastId(){
	return LastId;
}

} // class
} // package