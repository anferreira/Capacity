using System;
using System.Threading;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Engine.TaskCode{
	
public abstract
class GenericTaskCode{

protected string parameters;
protected TaskNode taskNode;
protected string startDate;
protected string startTime;

public
GenericTaskCode(TaskNode taskNode, string parameters){
	this.taskNode = taskNode;
	this.parameters = parameters;
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
void sleep(int millis){
	DateTime now = DateTime.Now.AddMilliseconds(millis);

	this.startDate = DateUtil.getDateRepresentation(now, DateUtil.MMDDYYYY);
	this.startTime = DateUtil.getTimeRepresentation(now);

	Thread.Sleep(millis);

	System.Console.WriteLine("Inicio : " + DateUtil.getCompleteDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY));
}

public
void sleep(Task task, DateTime dateBegin){
	DateTime now = DateTime.Now;

	if (now.CompareTo(dateBegin) >= 0){
		dateBegin = dateBegin.AddDays(1);
	}

	TimeSpan timeSpan = dateBegin.Subtract(now);

	this.startDate = DateUtil.getDateRepresentation(dateBegin, DateUtil.MMDDYYYY);
	this.startTime = DateUtil.getTimeRepresentation(dateBegin);

	double totalDbl = timeSpan.TotalMilliseconds;
	if (totalDbl < 0)
		totalDbl = totalDbl * -1;

	string totalStr = totalDbl.ToString();
	decimal aux = decimal.Parse(totalStr);
	int millis = decimal.ToInt32(aux);

	Thread.Sleep(millis);
}

public 
void sleep(CoreFactory coreFactory, Task task, string parameter){
	DateTime dateBegin = DateTime.MinValue;
	DateTime now = DateTime.MinValue;
	TimeSpan timeSpan = TimeSpan.MinValue;
//	TimeSpan test = TimeSpan.MinValue;
	
//	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
	TaskConfiguration taskConfiguration = coreFactory.readTaskConfiguration(task.getTaskId());
//	coreFactory = null;

	TaskConfiguration.TaskType type = taskConfiguration.getTaskType();
//	int millis = 0;

	switch(type){
	case TaskConfiguration.TaskType.TASK_LOOP:
//		millis = int.Parse(parameter) * 60 * 1000;
		dateBegin = now.AddMinutes(int.Parse(parameter));
		timeSpan = dateBegin.Subtract(now);

		break;
	case TaskConfiguration.TaskType.TASK_DAILY:
		dateBegin = DateUtil.parseTime(parameter);
		now = DateTime.Now;
		if (now.CompareTo(dateBegin) >= 0)
			dateBegin = dateBegin.AddDays(1);

		timeSpan = dateBegin.Subtract(now);

//		totalDbl = timeSpan.TotalMilliseconds;
//
//		if (totalDbl < 0)
//			totalDbl = totalDbl * -1;
//
//		string totalStr = totalDbl.ToString();
//		decimal aux = decimal.Parse(totalStr);
//		millis = decimal.ToInt32(aux);

		break;
	case TaskConfiguration.TaskType.TASK_MONTHLY:
		int dayM = int.Parse(parameter.Substring(0, 2));
		int hour = DateUtil.getItemFromTime(parameter.Substring(3, 5), DateUtil.HOUR_ITEM);
		int min = DateUtil.getItemFromTime(parameter.Substring(3, 5), DateUtil.MIN_ITEM);

		dateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayM, hour, min, 0, 0); 
		now = DateTime.Now;
		if (now.CompareTo(dateBegin) >= 0)
			dateBegin = dateBegin.AddMonths(1);

		timeSpan = dateBegin.Subtract(now);

//		totalDbl = timeSpan.TotalMilliseconds;
//		if (totalDbl < 0)
//			totalDbl = totalDbl * -1;
//
//		millis = decimal.ToInt32(decimal.Parse(totalDbl.ToString()));

		break;
	case TaskConfiguration.TaskType.TASK_ANNUAL:
		int month = int.Parse(parameter.Substring(0, 2));
		int day = int.Parse(parameter.Substring(3, 2));

		int annualHour = DateUtil.getItemFromTime(parameter.Substring(6, 5), DateUtil.HOUR_ITEM);
		int annualMin = DateUtil.getItemFromTime(parameter.Substring(6, 5), DateUtil.MIN_ITEM);

		dateBegin = new DateTime(DateTime.Now.Year, month, day, annualHour, annualMin, 0, 0); 
		now = DateTime.Now;
		if (now.CompareTo(dateBegin) >= 0)
			dateBegin = dateBegin.AddYears(1);

		timeSpan = dateBegin.Subtract(now);

//		totalDbl = timeSpan.TotalMilliseconds;
//		if (totalDbl < 0)
//			totalDbl = totalDbl * -1;
//
//		millis = decimal.ToInt32(decimal.Parse(totalDbl.ToString()));

		break;
	case TaskConfiguration.TaskType.TASK_ONCE:
		dateBegin = DateUtil.parseCompleteDate(parameter, DateUtil.MMDDYYYY);
		now = DateTime.Now;
		timeSpan = dateBegin.Subtract(now);

//		totalDbl = timeSpan.TotalMilliseconds;
//		if (totalDbl < 0)
//			totalDbl = totalDbl * -1;
//
//		millis = decimal.ToInt32(decimal.Parse(totalDbl.ToString()));

		break;
	}

	this.startDate = DateUtil.getDateRepresentation(DateTime.Now.Add(timeSpan), DateUtil.MMDDYYYY);
	this.startTime = DateUtil.getTimeRepresentation(DateTime.Now.Add(timeSpan));

//	Thread.Sleep(millis);

	
	double totalMillis = timeSpan.TotalMilliseconds;
	double maxSlice = int.MaxValue;
	int slice = 0;

	while(totalMillis > 0){
		if (totalMillis > maxSlice){
			slice = int.MaxValue;
			totalMillis -= maxSlice;
		}else{
			slice = decimal.ToInt32(decimal.Parse(totalMillis.ToString()));
			totalMillis = 0;
		}
		Thread.Sleep(slice);
	}
}

protected
void log(CoreFactory coreFactory, Task task, string status, string adicionalData){
	task.setStatus(status);
	task.setEndDate(DateUtil.getDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY));
	task.setEndTime(DateUtil.getTimeRepresentation(DateTime.Now));
	if (!adicionalData.Equals(""))
		task.setAdicionalData(adicionalData);
	coreFactory.updateTask(task);
}




public abstract void run();


} // class

} // namespace
