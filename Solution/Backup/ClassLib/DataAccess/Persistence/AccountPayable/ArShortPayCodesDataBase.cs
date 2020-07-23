using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArShortPayCodesDataBase: GenericDataBaseElement{

private int	ID;
private string ASPShortPayCode;
private string ASPSPCDes;

public 
ArShortPayCodesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.ASPShortPayCode = reader.GetString("ASPShortPayCode");
	this.ASPSPCDes = reader.GetString("ASPSPCDes");
}


public override
void write(){

    try{
		string sql = "insert into arshortpaycodes (ASPShortPayCode,ASPSPCDes)" +
		                "values(" +
						    NumberUtil.toString(ID)+", '" +
						    Converter.fixString(ASPShortPayCode)+"', '" +
						    Converter.fixString(ASPSPCDes)+"')";
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
		string sql = "update arshortpaycodes set " +
				"where " + 
				"ID = " + ID;
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
		string sql = "delete arshortpaycodes  " +
			 "where " + 
				"ID = " + ID;
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
		string sql = "select * from arshortpaycodes  " +
			 "where " + 
				"ID = " + ID;
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

//Setters
public 
void setID(int ID){
   this.ID = ID;
}

public 
void setASPShortPayCode(string ASPShortPayCode){
   this.ASPShortPayCode = ASPShortPayCode;
}

public 
void setASPSPCDes(string ASPSPCDes){
   this.ASPSPCDes = ASPSPCDes;
}


//Getters
public
int	getID(){
   return ID;
}

public
string getASPShortPayCode(){
   return ASPShortPayCode;
}

public
string getASPSPCDes(){
   return ASPSPCDes;
}

}//end class

}//end namespace

