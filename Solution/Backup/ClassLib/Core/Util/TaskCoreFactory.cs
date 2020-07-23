using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class TaskCoreFactory : ShiftCoreFactory{

private static int delay = 0;
private static string noRunStart = null;
private static string noRunEnd = null;

private static string[] stkbFilter = new string[0];
private static string[] wipbFilter = new string[0];

protected
TaskCoreFactory() : base(){
}

public
bool existsTask(int id){
	try{
		TaskDataBase taskDataBase = new TaskDataBase(dataBaseAccess);
		taskDataBase.setId(id);
		return taskDataBase.exists();
	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Task readTask(int id){
    try{
		TaskDataBase taskDataBase = new TaskDataBase(dataBaseAccess);
		taskDataBase.setId(id);
		taskDataBase.read();

		Task task = new Task(taskDataBase.getId(), taskDataBase.getTaskId(),
			taskDataBase.getPriority(), taskDataBase.getStartDate(),
			taskDataBase.getStartTime(), taskDataBase.getEndDate(),
			taskDataBase.getEndTime(), taskDataBase.getStatus(), 
			taskDataBase.getParameters(), taskDataBase.getAdicionalData());
		
		return task;
	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
void updateTask(Task task){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TaskDataBase taskDataBase = new TaskDataBase(dataBaseAccess);
		taskDataBase.setId(task.getId());
		taskDataBase.setTaskId(task.getTaskId());
		taskDataBase.setPriority(task.getPriority());
		taskDataBase.setStartDate(task.getStartDate());
		taskDataBase.setStartTime(task.getStartTime());
		taskDataBase.setEndDate(task.getEndDate());
		taskDataBase.setEndTime(task.getEndTime());
		taskDataBase.setStatus(task.getStatus());
		taskDataBase.setParameters(task.getParameters());
		taskDataBase.setAdicionalData(task.getAdicionalData());
		taskDataBase.update();

		TaskLogDataBase taskLogDataBase = new TaskLogDataBase(dataBaseAccess);
		taskLogDataBase.setId(task.getId());
		taskLogDataBase.setTaskId(task.getTaskId());
		taskLogDataBase.setPriority(task.getPriority());
		taskLogDataBase.setDate(task.getEndDate());
		taskLogDataBase.setTime(task.getEndTime());
		taskLogDataBase.setStatus(task.getStatus());
		taskLogDataBase.setParameters(task.getParameters());
		taskLogDataBase.setAdicionalData(task.getAdicionalData());
		taskLogDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException (exception.Message, exception);
	}
}

public
void writeTask(Task task){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TaskDataBase taskDataBase = new TaskDataBase(dataBaseAccess);
		taskDataBase.setId(task.getId());
		taskDataBase.setTaskId(task.getTaskId());
		taskDataBase.setPriority(task.getPriority());
		taskDataBase.setStartDate(task.getStartDate());
		taskDataBase.setStartTime(task.getStartTime());
		taskDataBase.setEndDate(task.getEndDate());
		taskDataBase.setEndTime(task.getEndTime());
		taskDataBase.setStatus(task.getStatus());
		taskDataBase.setParameters(task.getParameters());
		taskDataBase.setAdicionalData(task.getAdicionalData());
		taskDataBase.write();

		TaskLogDataBase taskLogDataBase = new TaskLogDataBase(dataBaseAccess);
		taskLogDataBase.setId(task.getId());
		taskLogDataBase.setTaskId(task.getTaskId());
		taskLogDataBase.setPriority(task.getPriority());
		taskLogDataBase.setDate(task.getStartDate());
		taskLogDataBase.setTime(task.getStartTime());
		taskLogDataBase.setStatus(task.getStatus());
		taskLogDataBase.setParameters(task.getParameters());
		taskLogDataBase.setAdicionalData(task.getAdicionalData());
		taskLogDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void deleteTask(int id){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TaskDataBase taskDataBase = new TaskDataBase(dataBaseAccess);
		taskDataBase.setId(id);
		taskDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void setAutimaticDelay(int delay){
	TaskCoreFactory.delay = delay;
}

public
int getAutimaticDelay(){
	return TaskCoreFactory.delay;
}

public
void setNoRunStart(string noRunStart){
	TaskCoreFactory.noRunStart = noRunStart;
}

public
string getNoRunStart(){
	return TaskCoreFactory.noRunStart;
}

public
void setNoRunEnd(string noRunEnd){
	TaskCoreFactory.noRunEnd = noRunEnd;
}

public
string getNoRunEnd(){
	return TaskCoreFactory.noRunEnd;
}

public 
void setFilters(string[] stkbFilter, string[] wipbFilter){
	TaskCoreFactory.stkbFilter = stkbFilter;
	TaskCoreFactory.wipbFilter = wipbFilter;
}

public 
string[] getStkbFilters(){ 
	return TaskCoreFactory.stkbFilter;
}

public 
string[] getWipbFilters(){ 
	return TaskCoreFactory.wipbFilter;
}

public
void insertTaskEngine(int taskCode, string parameters){
	ClassLib.Core.Engine.Engine.getInstance().insertTask(taskCode, parameters);
}

public
void updateTaskConfiguration(TaskConfiguration taskConfiguration){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TaskConfigurationDataBase taskConfigurationDataBase = new TaskConfigurationDataBase(dataBaseAccess);
		taskConfigurationDataBase.setTaskId(taskConfiguration.getTaskId());
		taskConfigurationDataBase.setTaskRestart(taskConfiguration.getAutomaticRestart());
		taskConfigurationDataBase.setTaskParameters(taskConfiguration.getTaskParameter());
		taskConfigurationDataBase.setTaskType((int)taskConfiguration.getTaskType());
		taskConfigurationDataBase.setCreationDate(DateUtil.getDateRepresentation(DateTime.Now,DateUtil.YYYYMMDD));
		taskConfigurationDataBase.setCreationTime(DateUtil.getTimeRepresentation(DateTime.Now));
		
		if (taskConfigurationDataBase.exists())
			taskConfigurationDataBase.update();
		else
			taskConfigurationDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
TaskConfiguration readTaskConfiguration(int taskCode){
    try{
		TaskConfigurationDataBase taskConfigurationDataBase = new TaskConfigurationDataBase(dataBaseAccess);
		taskConfigurationDataBase.setTaskId(taskCode);
		
		TaskConfiguration taskConfiguration = new TaskConfiguration();
		if (!taskConfigurationDataBase.exists()){
			taskConfiguration.setTaskId(taskCode);
			taskConfiguration.setTaskParameter("");
			taskConfiguration.setAutomaticRestart("N");
			taskConfiguration.setTaskType(0);
			taskConfiguration.setCreationDate("2500/01/01");
			taskConfiguration.setCreationTime("00:00:00");
		}
		else
		{
			taskConfigurationDataBase.read();

			taskConfiguration.setTaskId(taskConfigurationDataBase.getTaskId());
			taskConfiguration.setTaskParameter(taskConfigurationDataBase.getTaskParameters());
			taskConfiguration.setAutomaticRestart(taskConfigurationDataBase.getTaskRestart());
			taskConfiguration.setTaskType((TaskConfiguration.TaskType)taskConfigurationDataBase.getTaskType());
			taskConfiguration.setCreationDate(taskConfigurationDataBase.getCreationDate());
			taskConfiguration.setCreationTime(taskConfigurationDataBase.getCreationTime());
		}
		return taskConfiguration;

	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
string getNextRunTaskInformation(int taskId){
	return ClassLib.Core.Engine.Engine.getInstance().getNextRunTaskInformation(taskId);
}

public
void stopAllPendingTasks(int taskId){
	ClassLib.Core.Engine.Engine.getInstance().stopAllPendingTasks(taskId);
}

public
string[][] getAllTaskConfiguration(){
    try{
		TaskConfigurationDataBaseContainer taskConfigurationDataBaseContainer = new TaskConfigurationDataBaseContainer(dataBaseAccess);
		taskConfigurationDataBaseContainer.read();

		string[][] all = new string[taskConfigurationDataBaseContainer.Count][];
		for(int i = 0; i < taskConfigurationDataBaseContainer.Count; i++){
			TaskConfigurationDataBase taskConfigurationDataBase = (TaskConfigurationDataBase) taskConfigurationDataBaseContainer[i];
		
			string[] line = new string[4];
			line[0] = taskConfigurationDataBase.getTaskId().ToString();
			line[1] = taskConfigurationDataBase.getTaskParameters();
			line[2] = taskConfigurationDataBase.getTaskRestart();
			line[3] = taskConfigurationDataBase.getTaskType().ToString();
			
			all[i] = line;
		}

		return all;
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

} // class

} // namespace