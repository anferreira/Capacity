using System;
using System.Collections;
using System.Threading;
using System.Data;
using System.Data.OleDb;

using System.Web;
using System.Web.Mail;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Engine.TaskCode{
	
public 
class TaskHotListReport : GenericTaskCode{

/*
private string smtpServer = "martinrea.com";
private string from = "dwalser@martinrea.com";
private string to = "ocarvalho@martinrea.com; dwalser@martinrea.com";
private string message = "";
private string attachPath = "";
private string password = "daryl";
*/
private string smtpServer = "adinet.com.uy";
private string from = "gmuller@adinet.com.uy";
private string to = "ocarvalho@martinrea.com; dwalser@martinrea.com";
private string message = "";
private string attachPath = "";
private string password = "3982390";

public
TaskHotListReport(TaskNode taskNode, string parameters) : base(taskNode, parameters){
}

public override
void run(){
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

	try{
		this.sleep(coreFactory, taskNode.getTask(), parameters);

		Task task = taskNode.getTask();
		log(coreFactory, task, Task.TASK_RUNNING, "HotList Totals");

 		DataSet dataSet = generateDataSet(coreFactory);
		string generated = "";
		string exploded = "";
		string title = "All Products HotList";

		this.attachPath = Nujit.NujitERP.ClassLib.Reports.GenerateHotListReport.generate(dataSet, generated, exploded, title);

		email();

		task.setAdicionalData("Process finished");
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

	coreFactory = null;
}


private 
DataSet generateDataSet(CoreFactory coreFactory){
	DataTable dataTable = new DataTable();
	dataTable.TableName = "hotListReport";

	dataTable.Columns.Add(new DataColumn("HOT_ProdID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_ActID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Uom", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Dept", typeof(string)));			
	dataTable.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MachCyc", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_QohCml", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_PastDue",typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day006", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day007", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day008", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day009", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day010", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day011", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day012", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day013", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day014", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day015", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day016", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day017", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day018", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day019", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day020", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day021", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day022", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day023", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day024", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day025", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day026", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day027", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day028", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day029", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day030", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day031", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day032", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day033", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day034", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day035", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day036", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day037", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day038", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day039", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day040", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day041", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day042", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day043", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day044", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day045", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day046", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day047", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day048", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day049", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day050", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day051", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day052", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day053", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day054", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day055", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day056", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day057", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day058", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day059", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day060", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MajorGroup", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MinorGroup", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Finalized", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MinorGroupDesc", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MainMaterial", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MainMaterialSeq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MainMaterialQoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("MajorAndMinor", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Hot_Id", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_MachDesc", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Level", typeof(string)));

	string[] filterDept = new string[0];
	string[] filterPart = new string[0];
	string[] filterMg = new string[0];

	string[][] vec = coreFactory.getHotListReport(0, filterDept, filterPart, filterMg, 
		true, "B", false, false, false, false, false, false, false);

	for(int x = 0; x < vec.Length; x++){
		DataRow dataRow = dataTable.NewRow();
		dataRow.ItemArray = vec[x];
		dataTable.Rows.Add(dataRow);
	}

	DataSet dataSet = new DataSet();
	dataSet.Tables.Add(dataTable);

	return dataSet;
}

private 
void email(){
	MailMessage mail = new MailMessage();
	mail.From = from;
	mail.To = to;
	mail.Subject = "Hot List " + Nujit.NujitERP.ClassLib.Common.Configuration.CompanyName;
	mail.Priority = MailPriority.Low;
	mail.BodyFormat = MailFormat.Text;
	mail.Body = message;

	MailAttachment myAttachment = new MailAttachment(attachPath, MailEncoding.Base64);
	mail.Attachments.Add(myAttachment);

	mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");	//basic authentication
	mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from); //set your username here
	mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);	//set your password here

	SmtpMail.SmtpServer = smtpServer;
	SmtpMail.Send(mail);
}




} // class

} // namespace
