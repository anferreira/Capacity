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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned { 

public
class PlannedReqDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string Type;
private int ReqID;

public
PlannedReqDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from plannedreq where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from plannedreq where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Type = reader.GetString("Type");
	this.ReqID = reader.GetInt32("ReqID");
}

public override
void write(){
	string sql = "insert into plannedreq(" + 
		"HdrId," +
		"Detail," +
		"Type," +
		"ReqID" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Type) + "'," +
		"" + NumberUtil.toString(ReqID) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update plannedreq set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Type = '" + Converter.fixString(Type) + "', " +
		"ReqID = " + NumberUtil.toString(ReqID) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from plannedreq where " + getWhereCondition();
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
void setReqID(int ReqID){
	this.ReqID = ReqID;
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
int getReqID(){
	return ReqID;
}

} // class
} // package