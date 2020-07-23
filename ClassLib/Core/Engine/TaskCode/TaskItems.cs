using System;
using System.Threading;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Engine.TaskCode{
	
public 
class TaskItems : GenericTaskCode{

public
TaskItems(TaskNode taskNode, string parameters) : base(taskNode, parameters){
}

public override
void run(){
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

	try{
		this.sleep(coreFactory, taskNode.getTask(), parameters);

		Task task = taskNode.getTask();
		log(coreFactory, task, Task.TASK_RUNNING, "Copying Items");

		int copied = coreFactory.generateCMSItems("",true);
		
		task.setAdicionalData("copied : " + copied.ToString() + " records of items table");
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

//	TaskConfiguration taskConfiguration = coreFactory.readTaskConfiguration(taskNode.getTask().getTaskId());
//	if (taskConfiguration != null){
//		Engine.getInstance().insertTask(taskNode.getTask().getTaskId(), taskConfiguration.getTaskParameter());
//	}
	
	coreFactory = null;
}

} // class

} // namespace
