using System;
using System.Threading;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine.TaskCode;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Core.Engine{

public 
class TaskNode{

private Task task;
private Thread thread = null;
private GenericTaskCode genericTaskCode = null;
private bool stopped = false;

public 
TaskNode(Task task){
	this.task = task;

	switch(task.getTaskId()){
	case Task.TASK_GENERATE_HOTLIST:
		genericTaskCode = new TaskHotList(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "HotList generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_PRHIST:
		genericTaskCode = new TaskPrHist(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "PrHist generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_SCRAP:
		genericTaskCode = new TaskScrap(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Scrap generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_SPRSN:
		genericTaskCode = new TaskSprsn(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Sprsn generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_LBHIST:
		genericTaskCode = new TaskLbhist(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Lbhist generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_FAMILYPARTS:
		genericTaskCode = new TaskFamilyParts(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Family Parts generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_ITEMS:
		genericTaskCode = new TaskItems(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Items generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_PSSC:
		genericTaskCode = new TaskPssc(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Pssc generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_DEPTS:
		genericTaskCode = new TaskDepts(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Depts generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_MACHINES:
		genericTaskCode = new TaskMachines(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Machines generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_STKR:
		genericTaskCode = new TaskStkr(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Stkr generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_SUPPLIERS:
		genericTaskCode = new TaskSuppliers(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Suppliers generate";
		thread.Start();
		break;

	case Task.TASK_GENERATE_SCHIPPING_SCHEDULE:
		genericTaskCode = new TaskSchippingSchedule(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Schipping Schedule generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_MAT_RELEASE:
		genericTaskCode = new TaskMatRelease(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Material Release generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_EDI_CROSS_REF:
		genericTaskCode = new TaskEdiCrossRef(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Edi Cross Ref generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_ICSTM:
		genericTaskCode = new TaskIcstm(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Icstm generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_ICSTP:
		genericTaskCode = new TaskIcstp(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Icstp generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_TOTALS_HL:
		genericTaskCode = new TaskHotListTotals(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "Hl totals generate";
		thread.Start();
		break;
	case Task.TASK_GENERATE_HOTLIST_REPORT:
		genericTaskCode = new TaskHotListReport(this, task.getParameters());
		thread = new Thread(new ThreadStart(genericTaskCode.run));
		thread.Name = "HL Report generate";
		thread.Start();
		break;
	default:
		throw new NujitException("Invalid task code !!!!!!!!!!!");
	}
}

public
void abort(){
	if (thread != null){
		if (thread.IsAlive){
			thread.Abort();
		}
	}
	stopped = true;
}

public
Task getTask(){
	return task;
}

public
string getStartDate(){
	return genericTaskCode.getStartDate();
}

public
string getStartTime(){
	return genericTaskCode.getStartTime();
}

public
bool isStopped(){
	return stopped;
}

} // class

} // namespace
