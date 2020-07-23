using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class ProgramDataBase : GenericDataBaseElement{

private string CP_Program;
private string CP_ProgDesc1;
private string CP_ProgDesc2;

public 
ProgramDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.CP_Program = reader.GetString("CP_Program");
	this.CP_ProgDesc1 = reader.GetString("CP_ProgDesc1");
	this.CP_ProgDesc2 = reader.GetString("CP_ProgDesc2");
}

public override
void write(){
	try{
		string sql = "insert into program values('" +
					Converter.fixString(CP_Program) + "' " + 
					Converter.fixString(CP_ProgDesc1) + "' " + 
					Converter.fixString(CP_ProgDesc2) + "')"; 
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update program set " +
					"CP_ProgDesc1 = '" + Converter.fixString(CP_ProgDesc1) + "', " +
					"CP_ProgDesc2 = '" + Converter.fixString(CP_ProgDesc2) + "' " +
					"where " + 
						"CP_Program ='" + Converter.fixString(CP_Program)+ "'";
				
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from program  " +
				"where " + 
						"CP_Program ='" + Converter.fixString(CP_Program)+ "'";
				
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from program  " + 
					"where " + 
						"CP_Program ='" + Converter.fixString(CP_Program)+ "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public 
void setCP_Program(string CP_Program){
   this.CP_Program = CP_Program;
}

public 
void setCP_ProgDesc1(string CP_ProgDesc1){
   this.CP_ProgDesc1 = CP_ProgDesc1;
}

public 
void setCP_ProgDesc2(string CP_ProgDesc2){
   this.CP_ProgDesc2 = CP_ProgDesc2;
}


//Getters
public
string getCP_Program(){
   return CP_Program;
}

public
string getCP_ProgDesc1(){
   return CP_ProgDesc1;
}

public
string getCP_ProgDesc2(){
   return CP_ProgDesc2;
}

}//end class

}//end namespace
