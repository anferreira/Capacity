using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class TaskConfigurationDataBase : GenericDataBaseElement{

private int taskId;
private string taskRestart;
private string taskParameters;
private int taskType;
private string creationDate;
private string creationTime;

public
TaskConfigurationDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.taskId = reader.GetInt32("taskId");
	this.taskRestart = reader.GetString("taskRestart");
	this.taskParameters = reader.GetString("taskParameters");
	this.taskType = reader.GetInt32("taskType");
	this.creationDate = reader.GetString ("creationDate");
	this.creationTime = reader.GetString ("creationTime");
}

public override
void write(){
	try{
		string sql = "insert into taskconfiguration " +
		    "values(" + 
                NumberUtil.toString(taskId) + ", '" +
                Converter.fixString(taskRestart) + "', '" +
                Converter.fixString(taskParameters) + "', " + 
				NumberUtil.toString(taskType) + ",'" +
				Converter.fixString(creationDate) + "','" +
				Converter.fixString(creationTime) + "')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + mySqlExc.Message, mySqlExc);
	}
}

public override 
void update(){
	try{
		string sql = "update taskconfiguration set " +
			"taskRestart = '" + Converter.fixString(taskRestart) + "', " +
			"taskParameters = '" + Converter.fixString(taskParameters) + "', " +
			"taskType = " + NumberUtil.toString(taskType) + ", " +
			"creationDate = '" + Converter.fixString(creationDate) + "', " +
			"creationTime = '" + Converter.fixString(creationTime) + "' " +
			" where " +
			"taskId = " + NumberUtil.toString(taskId);

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public 
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from taskconfiguration where taskId = " + NumberUtil.toString(taskId);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from taskconfiguration where taskId = " + NumberUtil.toString(taskId);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setTaskId(int taskId){
	this.taskId = taskId;
}

public
void setTaskRestart(string taskRestart){
	this.taskRestart = taskRestart;
}

public
void setTaskParameters(string taskParameters){
	this.taskParameters = taskParameters;
}

public
void setTaskType(int taskType){
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
string getTaskRestart(){
	return taskRestart;
}

public
string getTaskParameters(){
	return taskParameters;
}

public
int getTaskType(){
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


} // clas(){

} // namespac(){
