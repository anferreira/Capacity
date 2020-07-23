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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleTaskDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private DateTime StartDate;
private DateTime EndDate;
private int StartShift;
private int TaskId;
private decimal Hours;
private int TotEmployees;
private decimal EmployeeHours;
private int Priority;
private int Queue;
private int MachId;

public
ScheduleTaskDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from scheduletask where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from scheduletask where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");    
	this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
	this.StartShift = reader.GetInt32("StartShift");
    this.TaskId = reader.GetInt32("TaskId");
    this.Hours = reader.GetDecimal("Hours");
	this.TotEmployees = reader.GetInt32("TotEmployees");
	this.EmployeeHours = reader.GetDecimal("EmployeeHours");

    this.Priority = reader.GetInt32("Priority");
    this.Queue = reader.GetInt32("Queue"); 
    this.MachId =reader.GetInt32("MachId");
}

public override
void write(){ 
	string sql = "insert into scheduletask(" + 
		"HdrId," +
		"Detail," +        
        "StartDate," +
		"EndDate," +
		"StartShift," +
        "TaskId," +
        "Hours," +
		"TotEmployees," +
        "EmployeeHours," +
        "Priority," +
        "Queue," +
        "MachId" +

        ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +        
        "'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate) + "'," +
		"" + NumberUtil.toString(StartShift) + "," +
        "" + NumberUtil.toString(TaskId) + "," +
        "" + NumberUtil.toString(Hours) + "," +
		"" + NumberUtil.toString(TotEmployees) + "," +
		"" + NumberUtil.toString(EmployeeHours) + "," +
        "" + NumberUtil.toString(Priority) + "," +
		"" + NumberUtil.toString(Queue) + "," +
        "" + NumberUtil.toString(MachId) + ")"; 
            
    write(sql);	
}

public override
void update(){
	string sql = "update scheduletask set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +        
        "StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
		"StartShift = " + NumberUtil.toString(StartShift) + "," +
        "TaskId = " + NumberUtil.toString(TaskId) + "," +
        "Hours = " + NumberUtil.toString(Hours) + ", " +
        "TotEmployees = " + NumberUtil.toString(TotEmployees) + ", " +
        "EmployeeHours = " + NumberUtil.toString(EmployeeHours) + ", " +
        "Priority = " + NumberUtil.toString(Priority) + ", " +
        "Queue = " + NumberUtil.toString(Queue) + " " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from scheduletask where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail);
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
void setStartDate(DateTime StartDate){
	this.StartDate = StartDate;
}

public
void setEndDate(DateTime EndDate){
	this.EndDate = EndDate;
}

public
void setStartShift(int StartShift){
	this.StartShift = StartShift;
}

public
void setTaskId(int TaskId){
	this.TaskId = TaskId;
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
void setPriority(int Priority){
	this.Priority = Priority;
}

public
void setQueue(int Queue){
	this.Queue = Queue;
}

public
void setMachId(int MachId){
	this.MachId = MachId;
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
DateTime getStartDate(){
	return StartDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

public
int getStartShift(){
	return StartShift;
}

public
int getTaskId(){
    return TaskId;
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

public
int getPriority(){
	return Priority;
}

public
int getQueue(){
	return Queue;
}

public
int getMachId(){
    return MachId;
}

} // class
} // package