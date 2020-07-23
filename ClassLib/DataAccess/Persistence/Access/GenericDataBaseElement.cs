using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using Npgsql;

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

/*Original
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
*/

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
	}finally{
        //System.Windows.Forms.MessageBox.Show("finally end write:" + sql);
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

public
string getTablePrefix() {
    string table = "";
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        table = Nujit.NujitERP.ClassLib.Common.Configuration.CMSLibrary + ".";
    return table;
}

public
string getTablePrefix2(){
    string table = "";
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)        
        table = Nujit.NujitERP.ClassLib.Common.Configuration.CMSLibrary_2nd + ".";
    return table;
}

public
string getTablePrefix3(){
    string table = "";
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)        
        table = Nujit.NujitERP.ClassLib.Common.Configuration.CMSLibrary_3rd + ".";
    return table;
}

public
string getFieldDigit(string sfield,char c) {
    string sfieldAux = sfield;
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        sfieldAux+= c;
    return sfieldAux;
}

public
string getFieldDigit(string sfield) {
    return getFieldDigit(sfield,'#');    
}

public
string getFieldReplaceDigit(string sfield){
    string sfieldAux = sfield;
    if (dataBaseAccess.getConnectionType() != DataBaseAccess.CMS_DATABASE)
        sfieldAux = sfieldAux.Replace("#","");
    return sfieldAux; 
}
        
public virtual
void load(NotNullDataReader reader){    
}

protected
bool read(string sql){
	NotNullDataReader reader = null;
	bool bresult = false;

	try{
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			load(reader);
			bresult = true;
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}
	#if !POCKET_PC	
	catch(MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read>  : "  + mySqlExc.Message, mySqlExc);
	}catch(NpgsqlException pgsqlException){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read>  : "  + pgsqlException.Message, pgsqlException);
	}
	#else
    catch(System.Data.SqlServerCe.SqlCeException sece){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + sece.Message, sece);
	}
	#endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read> : " + ex.Message, ex);
	}finally{
		if (reader != null)
			reader.Close();
	}
	return bresult;
}

public virtual 
string getWhereCondition() {    
    return "";
}

protected
DateTime readDateTimeStamp(string table,string fieldName) {
    NotNullDataReader reader = null;
    try {
        string sql = "select " + fieldName + " from " + table + " where " + getWhereCondition();
        reader = dataBaseAccess.executeQuery(sql);
        if (reader.Read())
            return reader.GetDateTime(fieldName);
        return Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB.DateUtil.MinValue;
    } catch (System.Data.SqlClient.SqlException se) {
        throw new PersistenceException("Error in class " + this.GetType().Name + " <readDateTimeStamp> : " + se.Message, se);
    } catch (System.Data.DataException de) {
        throw new PersistenceException("Error in class " + this.GetType().Name + " <readDateTimeStamp> : " + de.Message, de);
    }
#if !POCKET_PC
 catch (MySqlException mySqlExc) {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<readDateTimeStamp>  : " + mySqlExc.Message, mySqlExc);
    }
#endif
 catch (System.Exception ex) {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<readDateTimeStamp> : " + ex.Message, ex);
    } finally {
        if (reader != null)
            reader.Close();
    }
}

} // class

} // namespace
