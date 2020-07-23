/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmployeeShiftDataBase : GenericDataBaseElement {

private int Id;
private string Plant;
private int ShiftNum;
private DateTime StartDate;
private DateTime EndDate;
private string EmpId;
private string Status;
private string MonWork;
private string TueWork;
private string WedWork;
private string ThuWork;
private string FriWork;
private string SatWork;
private string SunWork;

public
EmployeeShiftDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from employeeshift where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from employeeshift where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.Plant = reader.GetString("Plant");
	this.ShiftNum = reader.GetInt32("ShiftNum");
	this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
	this.EmpId = reader.GetString("EmpId");
	this.Status = reader.GetString("Status");
	this.MonWork = reader.GetString("MonWork");
	this.TueWork = reader.GetString("TueWork");
	this.WedWork = reader.GetString("WedWork");
	this.ThuWork = reader.GetString("ThuWork");
	this.FriWork = reader.GetString("FriWork");
	this.SatWork = reader.GetString("SatWork");
	this.SunWork = reader.GetString("SunWork");
}

public override
void write(){
	string sql = "insert into employeeshift(" + 
		"Plant," +
		"ShiftNum," +
		"StartDate," +
		"EndDate," +
		"EmpId," +
		"Status," +
		"MonWork," +
		"TueWork," +
		"WedWork," +
		"ThuWork," +
		"FriWork," +
		"SatWork," +
		"SunWork" +

		") values (" + 

		"'" + Converter.fixString(Plant) + "'," +
		"" + NumberUtil.toString(ShiftNum) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate) + "'," +
		"'" + Converter.fixString(EmpId) + "'," +
		"'" + Converter.fixString(Status) + "'," +
		"'" + Converter.fixString(MonWork) + "'," +
		"'" + Converter.fixString(TueWork) + "'," +
		"'" + Converter.fixString(WedWork) + "'," +
		"'" + Converter.fixString(ThuWork) + "'," +
		"'" + Converter.fixString(FriWork) + "'," +
		"'" + Converter.fixString(SatWork) + "'," +
		"'" + Converter.fixString(SunWork) + "')";
	write(sql);
	this.setId(dataBaseAccess.getLastId());
}

public override
void update(){
	string sql = "update employeeshift set " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
		"ShiftNum = " + NumberUtil.toString(ShiftNum) + ", " +
		"StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
		"EmpId = '" + Converter.fixString(EmpId) + "', " +
		"Status = '" + Converter.fixString(Status) + "', " +
		"MonWork = '" + Converter.fixString(MonWork) + "', " +
		"TueWork = '" + Converter.fixString(TueWork) + "', " +
		"WedWork = '" + Converter.fixString(WedWork) + "', " +
		"ThuWork = '" + Converter.fixString(ThuWork) + "', " +
		"FriWork = '" + Converter.fixString(FriWork) + "', " +
		"SatWork = '" + Converter.fixString(SatWork) + "', " +
		"SunWork = '" + Converter.fixString(SunWork) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from employeeshift where " + getWhereCondition();
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
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setShiftNum(int ShiftNum){
	this.ShiftNum = ShiftNum;
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
void setEmpId(string EmpId){
	this.EmpId = EmpId;
}

public
void setStatus(string Status){
	this.Status = Status;
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
int getId(){
	return Id;
}

public
string getPlant(){
	return Plant;
}

public
int getShiftNum(){
	return ShiftNum;
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
string getEmpId(){
	return EmpId;
}

public
string getStatus(){
	return Status;
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

} // class
} // package