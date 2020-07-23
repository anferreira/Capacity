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
class CapShiftProfileDtlDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int ShiftTaskId;
private int NumPeople;
private int NewPeople;
private decimal Hours;

private string taskNameShow; //only used to show on screen
private string dirIndShow;

public
CapShiftProfileDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capshiftprofiledtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capshiftprofiledtl where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.ShiftTaskId = reader.GetInt32("ShiftTaskId");
	this.NumPeople = reader.GetInt32("NumPeople");
	this.NewPeople = reader.GetInt32("NewPeople");
	this.Hours = reader.GetDecimal("Hours");

    try{
        taskNameShow = "";
        taskNameShow = reader.GetString("TaskName");
    }catch{}

    try{
        dirIndShow = "";
        dirIndShow = reader.GetString("DirInd");
    }
    catch { }            
}

public override
void write(){ 
	string sql = "insert into capshiftprofiledtl(" + 
		"HdrId," +
		"Detail," +
		"ShiftTaskId," +
		"NumPeople," +
		"NewPeople," +
		"Hours" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(ShiftTaskId) + "," +
		"" + NumberUtil.toString(NumPeople) + "," +
		"" + NumberUtil.toString(NewPeople) + "," +
		"" + NumberUtil.toString(Hours) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update capshiftprofiledtl set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"ShiftTaskId = " + NumberUtil.toString(ShiftTaskId) + ", " +
		"NumPeople = " + NumberUtil.toString(NumPeople) + ", " +
		"NewPeople = " + NumberUtil.toString(NewPeople) + ", " +
		"Hours = " + NumberUtil.toString(Hours) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capshiftprofiledtl where " + getWhereCondition();
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
void setShiftTaskId(int ShiftTaskId){
	this.ShiftTaskId = ShiftTaskId;
}

public
void setNumPeople(int NumPeople){
	this.NumPeople = NumPeople;
}

public
void setNewPeople(int NewPeople){
	this.NewPeople = NewPeople;
}

public
void setHours(decimal Hours){
	this.Hours = Hours;
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
int getShiftTaskId(){
	return ShiftTaskId;
}

public
int getNumPeople(){
	return NumPeople;
}

public
int getNewPeople(){
	return NewPeople;
}

public
decimal getHours(){
	return Hours;
}

public
string getTaskNameShow(){
	return taskNameShow;
}

public
string getDirIndShow(){
	return dirIndShow;
}


} // class
} // package