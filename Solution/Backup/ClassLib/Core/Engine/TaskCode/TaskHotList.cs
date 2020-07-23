using System;
using System.Threading;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Engine.TaskCode{
	
public 
class TaskHotList : GenericTaskCode{

public
TaskHotList(TaskNode taskNode, string parameters) : base(taskNode, parameters){
}

public override
void run(){
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

	try{
		this.startTime = DateUtil.getCompleteDateRepresentation(DateTime.Now.AddMinutes(
			int.Parse(parameters)), DateUtil.MMDDYYYY);
		Thread.Sleep(int.Parse(parameters) * 60 * 1000);

		string startTime = coreFactory.getNoRunStart();
		string endTime = coreFactory.getNoRunEnd();

		if ((startTime != null) && (endTime != null)){
			DateTime startDate = DateTime.Today;
				
			startDate = startDate.AddHours(int.Parse(startTime.Substring(0, 2)));
			startDate = startDate.AddMinutes(int.Parse(startTime.Substring(3, 2)));

			DateTime endDate = DateTime.Today;
			endDate = endDate.AddHours(int.Parse(endTime.Substring(0, 2)));
			endDate = endDate.AddMinutes(int.Parse(endTime.Substring(3, 2)));

			if (endDate.CompareTo(startDate) < 0)
				endDate.AddDays(1);
			
			DateTime now = DateTime.Now;

			if ((now.CompareTo(startDate) >= 0) && (now.CompareTo(endDate) <= 0)){
				TimeSpan timeSpan = endDate.Subtract(now);
				Thread.Sleep(timeSpan.Duration());
			}
		}

		Task task = taskNode.getTask();
		log(coreFactory, task, Task.TASK_RUNNING, "Hot List");

		string[][] badWipb = null;
		coreFactory.createHotList(coreFactory.getStkbFilters(), coreFactory.getWipbFilters(), badWipb);
		
		task.setAdicionalData("");

		TaskConfiguration taskConfiguration = coreFactory.readTaskConfiguration(this.taskNode.getTask().getTaskId());
		if (taskConfiguration != null){
			string newPars = coreFactory.getAutimaticDelay().ToString();
			taskConfiguration.setTaskParameter(newPars);
			coreFactory.updateTaskConfiguration(taskConfiguration);
		}

		Engine.getInstance().finishTask(taskNode, Task.TASK_FINISHED);
	}catch(System.Exception exception){
		System.Console.WriteLine("-----------------------------------------------------------------");
		System.Console.WriteLine("" + exception.Message);
		System.Console.WriteLine("-----------------------------------------------------------------");

		string message = exception.Message;
		if (message.Length > 240)
			message = exception.Message.Substring(0, 239);
		taskNode.getTask().setAdicionalData(message);
		
		Engine.getInstance().finishTask(taskNode, Task.TASK_ABORTED);
	}

//	if (coreFactory.getAutimaticDelay() != 0){
//		string newPars = coreFactory.getAutimaticDelay().ToString();
//		Engine.getInstance().insertTask(taskNode.getTask().getTaskId(), newPars);
//	}
	
	coreFactory = null;
}

} // class

} // namespace
