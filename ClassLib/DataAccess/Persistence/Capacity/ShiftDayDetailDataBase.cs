using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ShiftDayDetailDataBase : GenericDataBaseElement{

private string SDS_Db;
private int SDS_Company;
private string SDS_Plt;
private string SDS_Dept;
private string SDS_Shf;
private int SDS_ShfActDay;
private string SDS_TmType;
private string SDS_TmStr;
private string SDS_TmEnd;
private decimal SDS_Hours;
private string SDS_DetailType;

public
ShiftDayDetailDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){

	this.SDS_Db = reader.GetString("SDS_Db");
	this.SDS_Company = reader.GetInt32("SDS_Company");
	this.SDS_Plt = reader.GetString("SDS_Plt");
	this.SDS_Dept = reader.GetString("SDS_Dept");
	this.SDS_Shf = reader.GetString("SDS_Shf");
	this.SDS_ShfActDay = reader.GetInt16("SDS_ShfActDay");
	this.SDS_TmType = reader.GetString("SDS_TmType");
	this.SDS_TmStr = reader.GetString("SDS_TmStr");
	this.SDS_TmEnd = reader.GetString("SDS_TmEnd");
	this.SDS_Hours = reader.GetDecimal("SDS_Hours");
	this.SDS_DetailType = reader.GetString("SDS_DetailType");
}

public override
void write(){
	string sql = "insert into shiftdaydetail (" +
		"SDS_Db, " +
		"SDS_Company, " +
		"SDS_Plt, " +
		"SDS_Dept, " +
		"SDS_Shf, " +
		"SDS_ShfActDay, " +
		"SDS_TmType, " +
		"SDS_TmStr, " +
		"SDS_TmEnd, " +
		"SDS_Hours," +
		"SDS_DetailType" +

		") values ('" +

		Converter.fixString(SDS_Db) + "'," +
		NumberUtil.toString(SDS_Company) + ",'" +
		Converter.fixString(SDS_Plt) + "','" +
		Converter.fixString(SDS_Dept) + "','" +
		Converter.fixString(SDS_Shf) + "'," +
		NumberUtil.toString(SDS_ShfActDay) + ",'" +
		Converter.fixString(SDS_TmType) + "','" +
		Converter.fixString(SDS_TmStr) + "','" +
		Converter.fixString(SDS_TmEnd) + "'," +
		NumberUtil.toString(SDS_Hours) + ",'" +
		Converter.fixString(SDS_DetailType) + "')";

	base.write (sql);
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){

	string sql = "delete from shiftdaydetail where " +
		"SDS_Db = '" + Converter.fixString(SDS_Db) + "' and " +
		"SDS_Company = " + NumberUtil.toString(SDS_Company) + " and " +
		"SDS_Plt = '" + Converter.fixString(SDS_Plt) + "' and " +
		"SDS_Dept = '" + Converter.fixString(SDS_Dept) + "' and " +
		"SDS_Shf = '" + Converter.fixString(SDS_Shf) + "' and " +
		"SDS_ShfActDay = " + NumberUtil.toString(SDS_ShfActDay) + " and " +
		"SDS_TmType = '" + Converter.fixString(SDS_TmType) + "' and " +
		"SDS_TmStr = '" + Converter.fixString(SDS_TmStr) + "' and " +
		"SDS_TmEnd = '" + Converter.fixString(SDS_TmEnd) + "'";

	base.delete (sql);
}

public
void setSDS_Db(string SDS_Db){
	this.SDS_Db = SDS_Db;
}

public
void setSDS_Company(int SDS_Company){
	this.SDS_Company = SDS_Company;
}

public
void setSDS_Plt(string SDS_Plt){
	this.SDS_Plt = SDS_Plt;
}

public
void setSDS_Dept(string SDS_Dept){
	this.SDS_Dept = SDS_Dept;
}

public
void setSDS_Shf(string SDS_Shf){
	this.SDS_Shf = SDS_Shf;
}

public
void setSDS_ShfActDay(int SDS_ShfActDay){
	this.SDS_ShfActDay = SDS_ShfActDay;
}

public
void setSDS_TmType(string SDS_TmType){
	this.SDS_TmType = SDS_TmType;
}

public
void setSDS_TmStr(string SDS_TmStr){
	this.SDS_TmStr = SDS_TmStr;
}

public
void setSDS_TmEnd(string SDS_TmEnd){
	this.SDS_TmEnd = SDS_TmEnd;
}

public
void setSDS_Hours(decimal SDS_Hours){
	this.SDS_Hours = SDS_Hours;
}

public
void setSDS_DetailType(string SDS_DetailType){
	this.SDS_DetailType = SDS_DetailType;
}

public
string getSDS_Db(){
	return SDS_Db;
}

public
int getSDS_Company(){
	return SDS_Company;
}

public
string getSDS_Plt(){
	return SDS_Plt;
}

public
string getSDS_Dept(){
	return SDS_Dept;
}

public
string getSDS_Shf(){
	return SDS_Shf;
}

public
int getSDS_ShfActDay(){
	return SDS_ShfActDay;
}

public
string getSDS_TmType(){
	return SDS_TmType;
}

public
string getSDS_TmStr(){
	return SDS_TmStr;
}

public
string getSDS_TmEnd(){
	return SDS_TmEnd;
}

public
decimal getSDS_Hours(){
	return SDS_Hours;
}

public
string getSDS_DetailType(){
	return SDS_DetailType;
}

} // class

} // namespace