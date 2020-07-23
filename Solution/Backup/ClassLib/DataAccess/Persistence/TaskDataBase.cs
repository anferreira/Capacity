using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class TaskDataBase : GenericDataBaseElement{

private long id;
private int taskId;
private int priority;
private string startDate;
private string startTime;
private string endDate;
private string endTime;
private string status;
private string parameters;
private string adicionalData;

public
TaskDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.id = reader.GetInt64("id");
	this.taskId = reader.GetInt32("taskId");
	this.priority = reader.GetInt32("priority");
	this.startDate = reader.GetString("startDate");
	this.startTime = reader.GetString("startTime");
	this.endDate = reader.GetString("endDate");
	this.endTime = reader.GetString("endTime");
	this.status = reader.GetString("status");
	this.parameters = reader.GetString("parameters");
	this.adicionalData = reader.GetString("adicionalData");
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from task where id = " + id.ToString();

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
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from task where id = " + id.ToString();

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

public override
void write(){
	try{
		string sql = "insert into task values(" + 
			id.ToString() + ", " +
			taskId.ToString() + ", " +
			priority.ToString() + ", '" +
			Converter.fixString(startDate) + "', '" +
			Converter.fixString(startTime) + "', '" +
			Converter.fixString(endDate) + "', '" +
			Converter.fixString(endTime) + "', '" +
			Converter.fixString(status) + "', '" +
			Converter.fixString(parameters) + "', '" +
			Converter.fixString(adicionalData) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update task set " +
			"taskId = " + taskId.ToString() + ", " +
			"priority = " + priority.ToString() + ", " +
			"startDate = '" + Converter.fixString(startDate) + "', " +
			"startTime = '" + Converter.fixString(startTime) + "', " +
			"endDate = '" + Converter.fixString(endDate) + "', " +
			"endTime = '" + Converter.fixString(endTime) + "', " +
			"status = '" + Converter.fixString(status) + "', " +
			"parameters = '" + Converter.fixString(parameters) + "', " +
			"adicionalData = '" + Converter.fixString(adicionalData) + 
		"' where id = " + id.ToString();

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
	try{
		string sql = "delete from task where id = " + id.ToString();

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}


public
void setId(long id){
	this.id = id;
}

public
void setTaskId(int taskId){
	this.taskId = taskId;
}

public
void setPriority(int priority){
	this.priority = priority;
}

public
void setStartDate(string startDate){
	this.startDate = startDate;
}

public
void setStartTime(string startTime){
	this.startTime = startTime;
}

public
void setEndDate(string endDate){
	this.endDate = endDate;
}

public
void setEndTime(string endTime){
	this.endTime = endTime;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setParameters(string parameters){
	this.parameters = parameters;
}

public
void setAdicionalData(string adicionalData){
	this.adicionalData = adicionalData;
}


public
long getId(){
	return id;
}

public
int getTaskId(){
	return taskId;
}

public
int getPriority(){
	return priority;
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
string getEndDate(){
	return endDate;
}

public
string getEndTime(){
	return endTime;
}

public
string getStatus(){
	return status;
}

public
string getParameters(){
	return parameters;
}

public
string getAdicionalData(){
	return adicionalData;
}

} // class

} // namespace