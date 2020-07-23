using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{

/// <summary>
/// GenericDataBaseElement : represent an element of database, like a record
/// </summary>
public abstract
class GenericDataBaseElement : MarshalByRefObject{

// Access to database 
protected DataBaseAccess dataBaseAccess;

/// <summary>
/// Constructor
/// </summary>
/// <param name="dataBaseAccess"></param>
public
GenericDataBaseElement(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

/// <summary>
/// Returns the connection object
/// </summary>
/// <param name="dataBaseAccess"></param>
public
DataBaseAccess getDataBaseAccess(){
	return dataBaseAccess;
}

/// <summary>
/// Obtain the connection object
/// </summary>
/// <param name="dataBaseAccess"></param>
public
void setDataBaseAccess(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

/// <summary>
/// Write method
/// </summary>
public abstract
void write();

/// <summary>
/// Update method
/// </summary>
public abstract
void update();

/// <summary>
/// Delete method
/// </summary>
public abstract
void delete();

/// <summary>
/// Load method
/// </summary>
//public abstract
//void load();

protected
bool exists(string sql){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
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

//protected
//void read(string sql){
//	NotNullDataReader reader = null;
//	try{
//		reader = dataBaseAccess.executeQuery(sql);
//		if (reader.Read())
//			load(reader);
//	}catch(System.Data.SqlClient.SqlException se){
//		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
//	}catch(System.Data.DataException de){
//		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
//	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
//		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
//	}finally{
//		if (reader != null)
//			reader.Close();
//	}
//}

protected
void delete(string sql){
	try{
 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
    }	
}

protected
void write(string sql){
	try{
 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

protected 
void update(string sql){
	try{
 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

} // class

} // namespace
