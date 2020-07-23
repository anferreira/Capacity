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
class TaskHotListTotals : GenericTaskCode{

private string smtpServer = "adinet.com.uy";
private string from = "gmuller@adinet.com.uy";
private string to = "gustavom@nujit.com";
private string message = "";
private string attachPath = "";
private string password = "3982390";


public
TaskHotListTotals(TaskNode taskNode, string parameters) : base(taskNode, parameters){
}

public override
void run(){
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

	try{
		this.sleep(coreFactory, taskNode.getTask(), parameters);

		Task task = taskNode.getTask();
		log(coreFactory, task, Task.TASK_RUNNING, "HotList Totals");

		ArrayList fields = new ArrayList();
    	int id1 = 12;
		int id2 = 13;
		//---------------------------------------
		string[][] vec = coreFactory.getHotListLogHist();
		if (vec.Length >= 2){
			id1 = int.Parse(vec[vec.Length-1][0]);
			id2 = int.Parse(vec[vec.Length-2][0]);		
		}
		//---------------------------------------
 		DataSet dataSet = generateDataSet(coreFactory, id1, id2, fields);

		this.attachPath = Nujit.NujitERP.ClassLib.Reports.GenerateTotalsHotList.generate(dataSet, id1, id2, fields);

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
DataSet generateDataSet(CoreFactory coreFactory, int id1, int id2, ArrayList fields){
	DataTable dataTable = new DataTable();
	dataTable.TableName = "hotListTotals";

	dataTable.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_QohCml", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(string)));
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

	string[][] vec = coreFactory.geHotListTotals(id1, id2);

	for(int x = 0; x < vec.Length; x++){
		DataRow dataRow = dataTable.NewRow();
		dataRow[0]  = vec[x][0];
		dataRow[1]  = vec[x][1];
		dataRow[2]  = vec[x][2];
		dataRow[3]  = vec[x][3];
		dataRow[4]  = vec[x][4];
		dataRow[5]  = vec[x][5];
		dataRow[6]  = vec[x][6];
		dataRow[7]  = vec[x][7];
		dataRow[8]  = vec[x][8];
		dataRow[9]  = vec[x][9];
		dataRow[10]  = vec[x][10];
		dataRow[11]  = vec[x][11];
		dataRow[12]  = vec[x][12];
		dataRow[13]  = vec[x][13];
		dataRow[14]  = vec[x][14];
		dataRow[15]  = vec[x][15];
		dataRow[16]  = vec[x][16];
		dataRow[17]  = vec[x][17];
		dataRow[18]  = vec[x][18];
		dataRow[19]  = vec[x][19];
		dataRow[20]  = vec[x][20];
		dataRow[21]  = vec[x][21];
		dataRow[22]  = vec[x][22];
		dataRow[23]  = vec[x][23];

		string[] vecField = new string[24];
		vecField[0] = vec[x][0];
		vecField[1] = vec[x][1];
		vecField[2] = vec[x][2];
		vecField[3] = vec[x][3];
		vecField[4] = vec[x][4];
		vecField[5] = vec[x][5];
		vecField[6] = vec[x][6];
		vecField[7] = vec[x][7];
		vecField[8] = vec[x][8];
		vecField[9] = vec[x][9];
		vecField[10] = vec[x][10];
		vecField[11] = vec[x][11];
		vecField[12] = vec[x][12];
		vecField[13] = vec[x][13];
		vecField[14] = vec[x][14];
		vecField[15] = vec[x][15];
		vecField[16] = vec[x][16];
		vecField[17] = vec[x][17];
		vecField[18] = vec[x][18];
		vecField[19] = vec[x][19];
		vecField[20] = vec[x][20];
		vecField[21] = vec[x][21];
		vecField[22] = vec[x][22];
		vecField[23] = vec[x][23];

		fields.Add(vecField);

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
	mail.Subject = "Hot List Totals " + Nujit.NujitERP.ClassLib.Common.Configuration.CompanyName;
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
