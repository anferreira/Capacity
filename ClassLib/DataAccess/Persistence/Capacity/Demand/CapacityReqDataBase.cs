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
class CapacityReqDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private string Type;
private int ReqID;
private decimal Time;
private decimal Hours;
private int TotEmployees;
private decimal EmployeeHours;

public
CapacityReqDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capacityreq where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capacityreq where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");
	this.Type = reader.GetString("Type");
	this.ReqID = reader.GetInt32("ReqID");
	this.Time = reader.GetDecimal("Time");
	this.Hours = reader.GetDecimal("Hours");

    this.TotEmployees = reader.GetInt32("TotEmployees");
    this.EmployeeHours=reader.GetDecimal("EmployeeHours");
}

public override
void write(){ 
	string sql = "insert into capacityreq(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +
		"Type," +
		"ReqID," +
		"Time," +
		"Hours," +
        "TotEmployees," +
        "EmployeeHours" +
            
            ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +
		"'" + Converter.fixString(Type) + "'," +
		"" + NumberUtil.toString(ReqID) + "," +
		"" + NumberUtil.toString(Time) + "," +
		"" + NumberUtil.toString(Hours) + "," +

        "" + NumberUtil.toString(TotEmployees) + "," +
		"" + NumberUtil.toString(EmployeeHours) + ")";
	//System.Windows.Forms.MessageBox.Show(sql);
	write(sql);	 
}

public override
void update(){
	string sql = "update capacityreq set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
		"Type = '" + Converter.fixString(Type) + "', " +
		"ReqID = " + NumberUtil.toString(ReqID) + ", " +
		"Time = " + NumberUtil.toString(Time) + ", " +
		"Hours = " + NumberUtil.toString(Hours) + ", " +
        "TotEmployees = " + NumberUtil.toString(TotEmployees) + ", " +
        "EmployeeHours = " + NumberUtil.toString(EmployeeHours) + " " +            

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capacityreq where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + "";
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
void setSubDetail(int SubDetail){
	this.SubDetail = SubDetail;
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
void setTime(decimal Time){
	this.Time = Time;
}

public
void setHours(decimal Hours){
	this.Hours = Hours;
}

public
void setTotEmployees(int TotEmployees){
	this.TotEmployees = TotEmployees;
}

public
void setEmployeeHours(decimal EmployeeHours){
	this.EmployeeHours = EmployeeHours;
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
int getSubDetail(){
	return SubDetail;
}

public
string getType(){
	return Type;
}

public
int getReqID(){
	return ReqID;
}

public
decimal getTime(){
	return Time;
}

public
decimal getHours(){
	return Hours;
}

public
int getTotEmployees(){
    return TotEmployees;
}

public
decimal getEmployeeHours(){
    return EmployeeHours;
}

} // class
} // package