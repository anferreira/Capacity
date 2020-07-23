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
class CapShiftProfileDataBase : GenericDataBaseElement {

private int Id;
private int ShiftNum;
private string Status;
private DateTime StartDate;
private DateTime EndDate;
private string Plant;
private string ShiftStart;
private string ShiftEnd;
private string MonWork;
private string TueWork;
private string WedWork;
private string ThuWork;
private string FriWork;
private string SatWork;
private string SunWork;
private string ShiftDefault;
private string ShiftType;
private string ShiftNumId;

public
CapShiftProfileDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capshiftprofile where " + getWhereCondition();
	return read(sql);
}

public
bool readLastByFilter(string splant){
    string sql = "select * from capshiftprofile h where h.Id in (select max(h2.Id) from capshiftprofile h2 ";
    
    if (!string.IsNullOrEmpty(splant))                     
        sql+= " where Plant='" + splant +"'";
    sql+=")";

	return read(sql);	
}

public
bool exists(){
	string sql = "select * from capshiftprofile where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.ShiftNum = reader.GetInt32("ShiftNum");
	this.Status = reader.GetString("Status");
	this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
    this.Plant = reader.GetString("Plant");
    this.ShiftStart = reader.GetString("ShiftStart");
    this.ShiftEnd = reader.GetString("ShiftEnd");
    this.MonWork= reader.GetString("MonWork");
    this.TueWork= reader.GetString("TueWork");
    this.WedWork= reader.GetString("WedWork");
    this.ThuWork= reader.GetString("ThuWork");
    this.FriWork= reader.GetString("FriWork");
    this.SatWork= reader.GetString("SatWork");
    this.SunWork= reader.GetString("SunWork");
    this.ShiftDefault = reader.GetString("ShiftDefault");
    this.ShiftType = reader.GetString("ShiftType");
    this.ShiftNumId= reader.GetString("ShiftNumId");
}

public override
void write(){ 
	string sql = "insert into capshiftprofile(" + 		
		"ShiftNum," +
		"Status," +
		"StartDate," +
        "EndDate," +
        "Plant," +
        "ShiftStart," +
        "ShiftEnd," +
        "MonWork," +
        "TueWork," +
        "WedWork," +
        "ThuWork," +
        "FriWork," +
        "SatWork," +
        "SunWork," +
        "ShiftDefault," +
        "ShiftType," +
        "ShiftNumId" +
        
        ") values (" + 		
		"" + NumberUtil.toString(ShiftNum) + "," +
		"'" + Converter.fixString(Status) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate) + "'," +
        "'" + Converter.fixString(Plant) + "'," +
        "'" + Converter.fixString(ShiftStart) + "'," +
        "'" + Converter.fixString(ShiftEnd) + "'," +

        "'" + Converter.fixString(MonWork) + "'," +
        "'" + Converter.fixString(TueWork) + "'," +
        "'" + Converter.fixString(WedWork) + "'," +
        "'" + Converter.fixString(ThuWork) + "'," +
        "'" + Converter.fixString(FriWork) + "'," +
        "'" + Converter.fixString(SatWork) + "'," +        
        "'" + Converter.fixString(SunWork) + "'," +
        "'" + Converter.fixString(ShiftDefault) + "'," +
        "'" + Converter.fixString(ShiftType) + "'," +
        "'" + Converter.fixString(ShiftNumId) +  "')";            
    write(sql);	
    this.setId(dataBaseAccess.getLastId());	 
}

public override
void update(){
	string sql = "update capshiftprofile set " +		
		"ShiftNum = " + NumberUtil.toString(ShiftNum) + ", " +
		"Status = '" + Converter.fixString(Status) + "', " +
		"StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
        "Plant = '" + Converter.fixString(Plant) + "', " +
        "ShiftStart = '" + Converter.fixString(ShiftStart)  + "', " +
        "ShiftEnd = '" + Converter.fixString(ShiftEnd)+ "', " +

        "MonWork = '" + Converter.fixString(MonWork) + "', " +
        "TueWork = '" + Converter.fixString(TueWork) + "', " +
        "WedWork = '" + Converter.fixString(WedWork) + "', " +
        "ThuWork = '" + Converter.fixString(ThuWork) + "', " +
        "FriWork = '" + Converter.fixString(FriWork) + "', " +
        "SatWork = '" + Converter.fixString(SatWork) + "', " +
        "SunWork = '" + Converter.fixString(SunWork) + "', " +
        "ShiftDefault = '" + Converter.fixString(ShiftDefault) + "', " +
        "ShiftType = '" + Converter.fixString(ShiftType) + "', " +
        "ShiftNumId = '" + Converter.fixString(ShiftNumId) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}


public override
void delete(){
	string sql = "delete from capshiftprofile where " + getWhereCondition();
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
void setShiftNum(int ShiftNum){
	this.ShiftNum = ShiftNum;
}

public
void setStatus(string Status){
	this.Status = Status;
}

public
void setStartDate(DateTime StartDate){
	this.StartDate = StartDate;
}

public
void setEndDate(DateTime EndDate){
	this.EndDate = EndDate;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setShiftStart(string ShiftStart){
	this.ShiftStart = ShiftStart;
}

public
void setShiftEnd(string ShiftEnd){
	this.ShiftEnd = ShiftEnd;
}

public
void setMonWork(string MonWork){
	this.MonWork = MonWork;
}

public
void setTueWork(string TueWork){
	this.TueWork = TueWork;
}

public
void setWedWork(string WedWork){
	this.WedWork = WedWork;
}

public
void setThuWork(string ThuWork){
	this.ThuWork = ThuWork;
}

public
void setFriWork(string FriWork){
	this.FriWork = FriWork;
}

public
void setSatWork(string SatWork){
	this.SatWork = SatWork;
}

public
void setSunWork(string SunWork){
	this.SunWork = SunWork;
}

public
void setShiftDefault(string ShiftDefault){
	this.ShiftDefault = ShiftDefault;
}
   
public
void setShiftType(string ShiftType){
	this.ShiftType = ShiftType;
}

public
void setShiftNumId(string ShiftNumId){
	this.ShiftNumId = ShiftNumId;
}

public
int getId(){
	return Id;
}

public
int getShiftNum(){
	return ShiftNum;
}

public
string getStatus(){
	return Status;
}

public
DateTime getStartDate(){
	return StartDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

public
string getPlant(){
	return Plant;
}

public
string getShiftStart(){
	return ShiftStart;
}

public
string getShiftEnd(){
	return ShiftEnd;
}

public
string getMonWork(){
	return MonWork;
}

public
string getTueWork(){
	return TueWork;
}

public
string getWedWork(){
	return WedWork;
}

public
string getThuWork(){
    return ThuWork;
}

public
string getFriWork(){
    return FriWork;
}

public
string getSatWork(){
	return SatWork;
}

public
string getSunWork(){
	return SunWork;
}

public
string getShiftDefault(){
	return ShiftDefault;
}

public
string getShiftType(){
	return ShiftType;
}

public
string getShiftNumId(){
	return ShiftNumId;
}


} // class
} // package