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
class CapShiftProfileMachPlanDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private DateTime Date;
private int MachId;
private string FullShift;
private string ShiftType;

public
CapShiftProfileMachPlanDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capshiftprofilemachplan where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capshiftprofilemachplan where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Date = reader.GetDateTime("Date");
	this.MachId = reader.GetInt32("MachId");
	this.FullShift = reader.GetString("FullShift");
    this.ShiftType = reader.GetString("ShiftType");            
}

public override
void write(){
	string sql = "insert into capshiftprofilemachplan(" + 
		"HdrId," +
		"Detail," +
		"Date," +
		"MachId," +
		"FullShift," +
        "ShiftType" +

        ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(Date) + "'," +
		"" + NumberUtil.toString(MachId) + "," +
		"'" + Converter.fixString(FullShift) + "'," +
        "'" + Converter.fixString(ShiftType) + "')";

	write(sql);	
}

public override
void update(){
	string sql = "update capshiftprofilemachplan set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Date = '" + DateUtil.getCompleteDateRepresentation(Date) + "', " +
		"MachId = " + NumberUtil.toString(MachId) + ", " +
		"FullShift = '" + Converter.fixString(FullShift) + "', " +
        "ShiftType = '" + Converter.fixString(ShiftType) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capshiftprofilemachplan where " + getWhereCondition();
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
void setDate(DateTime Date){
	this.Date = Date;
}

public
void setMachId(int MachId){
	this.MachId = MachId;
}

public
void setFullShift(string FullShift){
	this.FullShift = FullShift;
}

public
void setShiftType(string ShiftType){
	this.ShiftType = ShiftType;
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
DateTime getDate(){
	return Date;
}

public
int getMachId(){
	return MachId;
}

public
string getFullShift(){
	return FullShift;
}

public
string getShiftType(){
	return ShiftType;
}

} // class
} // package