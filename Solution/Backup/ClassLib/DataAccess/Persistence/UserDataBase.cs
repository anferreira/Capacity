using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class UserDataBase : GenericDataBaseElement{

private int UserID;
private string LoginName;
private string Password;
private string FirstName;
private string LastName;
private string Type;
private string Email;

public 
UserDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from users" + 
			" where UserID = " + UserID.ToString();
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
void readBylogin(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from users where LoginName = '" + LoginName + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBylogin> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBylogin> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBylogin> : " + mySqlExc.Message, mySqlExc);
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
		string sql = "select * from users where UserID = " + UserID.ToString();
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
bool existsByLoginName(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from users where LoginName = '" + LoginName + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByLoginName> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByLoginName> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByLoginName> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public 
void load(NotNullDataReader reader){
	this.UserID = reader.GetInt32("UserID");
	this.LoginName = reader.GetString("LoginName");
	this.Password = reader.GetString("Password");
	this.FirstName = reader.GetString("FirstName");
	this.LastName = reader.GetString("LastName");
	this.Type = reader.GetString("Type");
	this.Email = reader.GetString("Email");
}

public override 
void write(){
	try{
		string sql = "insert into users(LoginName, Password, FirstName, LastName, Type, Email" +
		") values('" + 
			Converter.fixString(LoginName) + "', '" +
			Converter.fixString(Password) + "', '" +
			Converter.fixString(FirstName) + "', '" +
			Converter.fixString(LastName) + "', '" +
			Converter.fixString(Type) + "', '" +
			Converter.fixString(Email) + "')";

		dataBaseAccess.executeUpdate(sql);
		
		this.UserID = dataBaseAccess.getLastId();
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
		string sql = "update users set " +
			"LoginName = '" + Converter.fixString(LoginName) + "', " +
			"Password = '" + Converter.fixString(Password) + "', " +
			"FirstName = '" + Converter.fixString(FirstName) + "', " +
			"LastName = '" + Converter.fixString(LastName) + "', " +
			"Type = '" + Converter.fixString(Type) + "', " +
			"Email = '" + Converter.fixString(Email) + "' " +
			" where UserID = " + UserID.ToString();

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
		string sql = "delete from users" +
			" where UserID = " + UserID.ToString();
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
void setUserID(int UserID){
	this.UserID = UserID;
}

public
void setLoginName(string LoginName){
	this.LoginName = LoginName;
}

public
void setPassword(string Password){
	this.Password = Password;
}

public
void setFirstName(string FirstName){
	this.FirstName = FirstName;
}

public
void setLastName(string LastName){
	this.LastName = LastName;
}

public
void setType(string Type){
	this.Type = Type;
}

public
void setEmail(string Email){
	this.Email = Email;
}


public
int getUserID(){
	return UserID;
}

public
string getLoginName(){
	return LoginName;
}

public
string getPassword(){
	return Password;
}

public
string getFirstName(){
	return FirstName;
}

public
string getLastName(){
	return LastName;
}

public
string getType(){
	return Type;
}

public
string getEmail(){
	return Email;
}


} // class

} // namespace
