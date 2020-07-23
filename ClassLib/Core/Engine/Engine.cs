using System;
using System.Threading;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine.TaskCode;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Engine{

public 
class Engine{

private TaskNodeContainer taskNodeContainer = new TaskNodeContainer();
private static CoreFactory coreFactory = null;
private static Engine instance = null;


private
Engine(CoreFactory coreFactory){
	Engine.coreFactory = coreFactory;
	
	if (isServerInstance())
		restartTasks();
}

public static 
Engine getInstance(){
	if (Engine.instance == null)
		throw new NujitException("The Engine was not created properly - getInstance()");
	return instance;
}

public static 
Engine getInstance(CoreFactory coreFactory){
	if (Engine.instance == null){
		Engine.instance = new Engine(coreFactory);
	}
	return instance;
}

~Engine(){
	stop();
}

private 
void restartTasks(){
	string[][] allTasks = coreFactory.getAllTaskConfiguration();
	
	for(int i = 0; i < allTasks.Length; i++){
		if (allTasks[i][2].Equals("Y")){
			insertTask(int.Parse(allTasks[i][0]), allTasks[i][1]);
			Thread.Sleep(1);
		}
	}
}

public
void stop(){
	if (!isServerInstance())
		return;

	for(int i = 0; i < taskNodeContainer.Count; i++){
		TaskNode taskNode = (TaskNode)taskNodeContainer[i];
		taskNode.abort();
	}
}

public
void insertTask(int taskCode, string parameters){
	if (!isServerInstance())
		return;

	lock(this){
		Task task = new Task(DateTime.Now.Ticks, taskCode, 0, "", "", "", "", Task.TASK_PENDING, parameters, "");

		System.Console.WriteLine("Inicia Tarea " + DateUtil.getDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY) + 
			" " + DateUtil.getTimeRepresentation(DateTime.Now));

		task.setStartDate(DateUtil.getDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY));
		task.setStartTime(DateUtil.getTimeRepresentation(DateTime.Now));
		coreFactory.writeTask(task);
		
		taskNodeContainer.Add(new TaskNode(task));
	}
}

public
void finishTask(TaskNode taskNode, string status){
	if (!isServerInstance())
		return;

	Task task = taskNode.getTask();
	
	System.Console.WriteLine("Finaliza Tarea " + DateUtil.getDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY) + 
		" " + DateUtil.getTimeRepresentation(DateTime.Now));

	lock(this){
		taskNodeContainer.Remove(taskNode);
		task.setEndDate(DateUtil.getDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY));
		task.setEndTime(DateUtil.getTimeRepresentation(DateTime.Now));
		task.setStatus(status);
		coreFactory.updateTask(task);
	}

	if (!taskNode.isStopped()){
		TaskConfiguration taskConfiguration = coreFactory.readTaskConfiguration(task.getTaskId());
		if (taskConfiguration != null){
			if (taskConfiguration.getTaskType() != TaskConfiguration.TaskType.TASK_ONCE){
				Engine.getInstance().insertTask(task.getTaskId(), taskConfiguration.getTaskParameter());
			}
		}
	}
}

public
string[][] getRunningTaskInformation(){
	string[][] tasks = new string[taskNodeContainer.Count][];
	int index = 0;
	
	for(IEnumerator en = taskNodeContainer.GetEnumerator(); en.MoveNext(); ){
		TaskNode taskNode = (TaskNode)en.Current;

		string[] line = new string[4];
		line[0] = taskNode.getTask().getTaskId().ToString();
		line[1] = taskNode.getTask().getId().ToString();
		line[2] = taskNode.getTask().getStatus();
		line[3] = taskNode.getStartTime();
		tasks[index] = line;
		index++;
	}
	return tasks;
}

public
string[][] getRunningTaskInformation(int taskId){
	int len = 0;
	for(int i = 0; i < taskNodeContainer.Count; i++){
		TaskNode taskNode = (TaskNode) taskNodeContainer[i];
		if (taskNode.getTask().getTaskId() == taskId)
			len++;
	}

	string[][] tasks = new string[len][];
	int index = 0;
	
	for(int i = 0; i < taskNodeContainer.Count; i++){
		TaskNode taskNode = (TaskNode) taskNodeContainer[i];

		if (taskNode.getTask().getTaskId() == taskId){
			string[] line = new string[4];
			line[0] = taskNode.getTask().getTaskId().ToString();
			line[1] = taskNode.getTask().getId().ToString();
			line[2] = taskNode.getTask().getStatus();
			line[3] = taskNode.getStartTime();
			tasks[index] = line;
			index++;
		}
	}
	return tasks;
}

public
string getNextRunTaskInformation(int taskId){
	if (isServerInstance()){
		for(int i = taskNodeContainer.Count - 1; i > -1; i--){
			TaskNode taskNode = (TaskNode) taskNodeContainer[i];

			if ((taskNode.getTask().getTaskId() == taskId) && 
					((taskNode.getTask().getStatus().Equals(Task.TASK_PENDING)) || 
					(taskNode.getTask().getStatus().Equals(Task.TASK_RUNNING))) )
				return taskNode.getStartDate() + " " + taskNode.getStartTime();
		}
	}

	return "";
}

public
void stopAllPendingTasks(int taskId){
	if (isServerInstance()){
		for(int i = 0; i < taskNodeContainer.Count; i++){
			TaskNode taskNode = (TaskNode)taskNodeContainer[i];
			if ((taskNode.getTask().getTaskId() == taskId) && (taskNode.getTask().getStatus().Equals(Task.TASK_PENDING)))
				taskNode.abort();
		}
	}
}

private
bool isServerInstance(){
	if (Configuration.IpAddress.Equals(Configuration.ServerIp)) // This instance is the server
		return true;
	return false;
}

} // class

} // namespace
