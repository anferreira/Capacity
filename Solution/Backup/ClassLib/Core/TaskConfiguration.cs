using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class TaskConfiguration{

public 
enum TaskType : int{
	TASK_LOOP = 0,
	TASK_DAILY = 1,
	TASK_MONTHLY = 2,
	TASK_ANNUAL = 3,
	TASK_ONCE = 4
}

private int taskId;
private string taskParameter;
private string automaticRestart; // when the system is loading
private TaskType taskType;
private string creationDate;
private string creationTime;

public
TaskConfiguration(){
	this.taskId = 0;
	this.taskParameter = "";
	this.automaticRestart = "";
	this.taskType = TaskType.TASK_DAILY;
	this.creationDate = "2500/01/01";
	this.creationTime = "00:00:00";
}

public
TaskConfiguration(int taskId, string taskParameter, string automaticRestart, TaskType taskType, string creationDate, string creationTime){
	this.taskId = taskId;
	this.taskParameter = taskParameter;
	this.automaticRestart = automaticRestart;
	this.taskType = taskType;
	this.creationDate = creationDate;
	this.creationTime = creationTime;
}


public
void setTaskId(int taskId){
	this.taskId = taskId;
}

public
void setTaskParameter(string taskParameter){
	this.taskParameter = taskParameter;
}

public
void setAutomaticRestart(string automaticRestart){
	this.automaticRestart = automaticRestart;
}

public
void setTaskType(TaskType taskType){
	this.taskType = taskType;
}

public
void setCreationDate (string creationDate){
	this.creationDate = creationDate;
}

public
void setCreationTime (string creationTime){
	this.creationTime = creationTime;
}

public
int getTaskId(){
	return taskId;
}

public
string getTaskParameter(){
	return taskParameter;
}

public
string getAutomaticRestart(){
	return automaticRestart;
}

public
TaskType getTaskType(){
	return taskType;
}

public
string getCreationDate(){
	return creationDate;
}

public
string getCreationTime(){
	return creationTime;
}

public static 
string getTaskTypeDescription(TaskType type){
	switch(type){
	case TaskType.TASK_LOOP:
		return "Loop";
	case TaskType.TASK_DAILY:
		return "Daily";
	case TaskType.TASK_MONTHLY:
		return "Monthly";
	case TaskType.TASK_ANNUAL:
		return "Annual";
	case TaskType.TASK_ONCE:
		return "Once";
	}
	return "ERROR";
}

public static 
string[][] getTastTypes(){
	string[][] v = new string[5][];
	string[] line = null;


	line = new string[2];
	v[0] = line;
	v[0][0] = TaskType.TASK_LOOP.ToString();
	v[0][1] = TaskConfiguration.getTaskTypeDescription(TaskType.TASK_LOOP);

	line = new string[2];
	v[1] = line;
	v[1][0] = TaskType.TASK_DAILY.ToString();
	v[1][1] = TaskConfiguration.getTaskTypeDescription(TaskType.TASK_DAILY);

	line = new string[2];
	v[2] = line;
	v[2][0] = TaskType.TASK_MONTHLY.ToString();
	v[2][1] = TaskConfiguration.getTaskTypeDescription(TaskType.TASK_MONTHLY);

	line = new string[2];
	v[3] = line;
	v[3][0] = TaskType.TASK_ANNUAL.ToString();
	v[3][1] = TaskConfiguration.getTaskTypeDescription(TaskType.TASK_ANNUAL);

	line = new string[2];
	v[4] = line;
	v[4][0] = TaskType.TASK_ONCE.ToString();
	v[4][1] = TaskConfiguration.getTaskTypeDescription(TaskType.TASK_ONCE);

	return v;
}

} // class

} // namespace
