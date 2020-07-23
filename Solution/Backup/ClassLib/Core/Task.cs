using System;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class Task : MarshalByRefObject{

private long id;
private int taskId;
private int priority;
private string startDate;
private string startTime;
private string endDate;
private string endTime;
private string status;
private string parameters;
private string adicionalData;

// tasks status 
public const string TASK_PENDING = "P";
public const string TASK_FINISHED = "F";
public const string TASK_RUNNING = "R";
public const string TASK_CANCELED = "C";
public const string TASK_SUSPENDED = "S";
public const string TASK_ABORTED = "A";

// tasks types
public const int TASK_GENERATE_HOTLIST = 10;
public const int TASK_GENERATE_PRHIST = 20;
public const int TASK_GENERATE_SCRAP = 30;
public const int TASK_GENERATE_SPRSN = 40;
public const int TASK_GENERATE_LBHIST = 50;
public const int TASK_GENERATE_FAMILYPARTS = 60;
public const int TASK_GENERATE_ITEMS = 70;
public const int TASK_GENERATE_PSSC = 80;
public const int TASK_GENERATE_DEPTS = 90;
public const int TASK_GENERATE_MACHINES = 100;
public const int TASK_GENERATE_STKR = 110;
public const int TASK_GENERATE_SUPPLIERS = 120;
public const int TASK_GENERATE_SCHIPPING_SCHEDULE = 130;
public const int TASK_GENERATE_MAT_RELEASE = 140;
public const int TASK_GENERATE_EDI_CROSS_REF = 150;
public const int TASK_GENERATE_ICSTM = 160;
public const int TASK_GENERATE_ICSTP = 170;
public const int TASK_GENERATE_MMGP = 180;
public const int TASK_GENERATE_TOTALS_HL = 190;
public const int TASK_GENERATE_HOTLIST_REPORT = 200;
public const int TASK_GENERATE_TMST = 210;
public const int TASK_GENERATE_MTHL = 220;

public 
Task(){
	this.id = 0;
	this.taskId = 0;
	this.priority = 0;
	this.startDate = "";
	this.startTime = "";
	this.endDate = "";
	this.endTime = "";
	this.status = "";
	this.parameters = "";
	this.adicionalData = "";
}

public 
Task(long id, int taskId, int priority, string startDate, string startTime, string endDate, 
			string endTime, string status, string parameters, string adicionalData){
	this.id = id;
	this.taskId = taskId;
	this.priority = priority;
	this.startDate = startDate;
	this.startTime = startTime;
	this.endDate = endDate;
	this.endTime = endTime;
	this.status = status;
	this.parameters = parameters;
	this.adicionalData = adicionalData;
}

public
void setId(long id){
	this.id = id;
}

public
void setTaskId(int taskId){
	this.taskId = taskId;
}

public
void setPriority(int priority){
	this.priority = priority;
}

public
void setStartDate(string startDate){
	this.startDate = startDate;
}

public
void setStartTime(string startTime){
	this.startTime = startTime;
}

public
void setEndDate(string endDate){
	this.endDate = endDate;
}

public
void setEndTime(string endTime){
	this.endTime = endTime;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setParameters(string parameters){
	this.parameters = parameters;
}

public
void setAdicionalData(string adicionalData){
	this.adicionalData = adicionalData;
}


public
long getId(){
	return id;
}

public
int getTaskId(){
	return taskId;
}

public
int getPriority(){
	return priority;
}

public
string getStartDate(){
	return startDate;
}

public
string getStartTime(){
	return startTime;
}

public
string getEndDate(){
	return endDate;
}

public
string getEndTime(){
	return endTime;
}

public
string getStatus(){
	return status;
}

public
string getParameters(){
	return parameters;
}

public
string getAdicionalData(){
	return adicionalData;
}

} // class

} // namespace
