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
class ProdFmactSubLabToolDataBase : GenericDataBaseElement {

private int Id;
private int HdrId;
private int Detail;
private string Type;
private int ReqId;
private decimal TotEmployees;

public
ProdFmactSubLabToolDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from prodfmactsublabtool where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from prodfmactsublabtool where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Type = reader.GetString("Type");
	this.ReqId = reader.GetInt32("ReqId");
	this.TotEmployees = reader.GetDecimal("TotEmployees");
}

public override
void write(){ 

	string sql = "insert into prodfmactsublabtool(" + 
		"HdrId," +
		"Detail," +
		"Type," +
		"ReqId," +
		"TotEmployees" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Type) + "'," +
		"" + NumberUtil.toString(ReqId) + "," +
		"" + NumberUtil.toString(TotEmployees) + ")";
	write(sql);
    this.setId(dataBaseAccess.getLastId());	  	
}

public override
void update(){
	string sql = "update prodfmactsublabtool set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Type = '" + Converter.fixString(Type) + "', " +
		"ReqId = " + NumberUtil.toString(ReqId) + ", " +
		"TotEmployees = " + NumberUtil.toString(TotEmployees) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from prodfmactsublabtool where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + "";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setHdrId(int HdrId){
	this.HdrId = HdrId;
}

public
void setDetail(int Detail){
	this.Detail = Detail;
}

public
void setType(string Type){
	this.Type = Type;
}

public
void setReqId(int ReqId){
	this.ReqId = ReqId;
}

public
void setTotEmployees(decimal TotEmployees){
	this.TotEmployees = TotEmployees;
}

public
int getId(){
	return Id;
}

public
int getHdrId(){
	return HdrId;
}

public
int getDetail(){
	return Detail;
}

public
string getType(){
	return Type;
}

public
int getReqId(){
	return ReqId;
}

public
decimal getTotEmployees(){
	return TotEmployees;
}

} // class
} // package