using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ArRemLinkHdrDataBase : GenericDataBaseElement{

private int ID;
private string RLS_RemDb;
private int RLS_LogNum;
private int RLS_EntryNum;
private string RLS_Applied;
private DateTime RLS_DateApplied;
private string RLS_User;

public 
ArRemLinkHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.RLS_RemDb = reader.GetString("RLS_RemDb");
	this.RLS_LogNum = reader.GetInt32("RLS_LogNum");
	this.RLS_EntryNum = reader.GetInt32("RLS_EntryNum");
	this.RLS_Applied = reader.GetString("RLS_Applied");
	this.RLS_DateApplied = reader.GetDateTime("RLS_DateApplied");
	this.RLS_User = reader.GetString("RLS_User");
}

public override
void write(){
	try{
		string sql = "insert into arremlinkhdr " +
    		            "(RLS_RemDb,RLS_LogNum,RLS_EntryNum," +
    		            " RLS_Applied,RLS_DateApplied,RLS_User)" +
		    " values('" +
					Converter.fixString(RLS_RemDb) +"', " +
					NumberUtil.toString(RLS_LogNum) +", " +
					NumberUtil.toString(RLS_EntryNum) +", '" +
					Converter.fixString(RLS_Applied)+"', '" +
					DateUtil.getCompleteDateRepresentation(RLS_DateApplied)+"', '" +
					Converter.fixString(RLS_User)+"')";
				dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update arremlinkhdr set " +
					"RLS_RemDb = '" + Converter.fixString(RLS_RemDb) +"', " +
					"RLS_LogNum = " + NumberUtil.toString(RLS_LogNum) +", " +
					"RLS_EntryNum = " + NumberUtil.toString(RLS_EntryNum) +", " +
					"RLS_Applied = '" + Converter.fixString(RLS_Applied) + "', " +
					"RLS_DateApplied = '" +DateUtil.getCompleteDateRepresentation(RLS_DateApplied)+"', '" +
					"RLS_User = '" + Converter.fixString(RLS_User) + "' " +									
			"where " + 
				"ID = " + NumberUtil.toString(ID);
				
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}

}


public override
void delete(){
	try{
		string sql = "delete from arremlinkhdr where " +
				"ID = " + NumberUtil.toString(ID);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arremlinkhdr where " + 
				"ID = " + NumberUtil.toString(ID);
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from arremlinkhdr " + 
			"where " +
			"RLS_RemDb = '" + Converter.fixString(RLS_RemDb) +"' and " +
			"RLS_LogNum= " + NumberUtil.toString(RLS_LogNum) +" and " +
			"RLS_EntryNum= " + NumberUtil.toString(RLS_EntryNum);

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


//Setters
public 
void setID(int ID){
   this.ID = ID;
}

public 
void setRLS_RemDb(string RLS_RemDb){
   this.RLS_RemDb = RLS_RemDb;
}

public 
void setRLS_LogNum(int RLS_LogNum){
   this.RLS_LogNum = RLS_LogNum;
}

public 
void setRLS_EntryNum(int RLS_EntryNum){
   this.RLS_EntryNum = RLS_EntryNum;
}

public 
void setRLS_Applied(string RLS_Applied){
   this.RLS_Applied = RLS_Applied;
}

public 
void setRLS_DateApplied(DateTime RLS_DateApplied){
   this.RLS_DateApplied = RLS_DateApplied;
}

public 
void setRLS_User(string RLS_User){
   this.RLS_User = RLS_User;
}


//Getters
public
int getID(){
   return ID;
}

public
string getRLS_RemDb(){
   return RLS_RemDb;
}

public
int getRLS_LogNum(){
   return RLS_LogNum;
}

public
int getRLS_EntryNum(){
   return RLS_EntryNum;
}


public
string getRLS_Applied(){
   return RLS_Applied;
}

public
DateTime getRLS_DateApplied(){
   return RLS_DateApplied;
}

public
string getRLS_User(){
   return RLS_User;
}

}//end class

}//end namesapce
