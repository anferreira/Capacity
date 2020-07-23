using System;
using System.Collections;
using MySql.Data.MySqlClient;
using Npgsql;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{

/// <summary>
/// Class GenericDataBaseContainer : represents a table or a set of records of a table
/// </summary>
public
class GenericDataBaseContainer : ArrayList{

protected DataBaseAccess dataBaseAccess;
private Hashtable hash = new Hashtable();


/// <summary>
/// Constructor
/// </summary>
/// <returns></returns>
public
GenericDataBaseContainer(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

/// <summary>
/// Returns if the collection in indexed
/// </summary>
/// <returns></returns>
public
bool isIndexed(){
	if ((this.Count > 0) && (hash.Count == 0))
		return false;
	return true;
}

/// <summary>
/// Adds a new object to the set
/// </summary>
/// <returns></returns>
public 
int Add(GenericDataBaseElement element, string key){
	int pos = 0;
	if (this.Count != 0)
		pos = this.Count;
	
	if (!hash.ContainsKey(key.Trim()))
		hash.Add(key.Trim(), pos.ToString());
	
	return this.Add(element);
}

/// <summary>
/// Returns ths first position object seeked
/// </summary>
/// <returns></returns>
public
int getFirstElementPosition(string key){
	if (hash.Count == 0)
		return -1;
	
	if (hash.ContainsKey(key.Trim()))
		return int.Parse((string)hash[key.Trim()]);
	return -1;
}

/// <summary>
/// Returns ths first object seeked
/// </summary>
/// <returns></returns>
public
object getFirstObject(string key){
	int pos = getFirstElementPosition(key);
	if (pos != -1)
		return (object)this[pos];
	return null;
}

/// <summary>
/// Returns ths DataBaseAccess object
/// </summary>
/// <returns></returns>
public
DataBaseAccess getDataBaseAccess(){
	return dataBaseAccess;
}

public
void getDataBaseAccess(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

/// <summary>
/// Write method, write all records presents
/// </summary>
public
void write(){
	IEnumerator ie = GetEnumerator();
	while(ie.MoveNext()){
		GenericDataBaseElement element = (GenericDataBaseElement)ie.Current;
		element.write();
	}
}

/// <summary>
/// Update method, update all records presents
/// </summary>
public
void update(){
	IEnumerator ie = GetEnumerator();
	while(ie.MoveNext()){
		GenericDataBaseElement element = (GenericDataBaseElement)ie.Current;
		element.update();
	}
}

/// <summary>
/// Delete method, delete all records presents
/// </summary>
public
void delete(){
	IEnumerator ie = GetEnumerator();
	while(ie.MoveNext()){
		GenericDataBaseElement element = (GenericDataBaseElement)ie.Current;
		element.delete();
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
        
public virtual
void load(NotNullDataReader reader){

}

protected
void read(string sql){
	NotNullDataReader reader = null;
	try{
		reader = dataBaseAccess.executeQuery(sql);
		load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read>  : " + de.Message, de);
	}
    #if !POCKET_PC	
	catch(MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read>  : "  + mySqlExc.Message, mySqlExc);
	}catch(NpgsqlException npgsqlException){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<read>  : "  + npgsqlException.Message, npgsqlException);
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
}

protected 
void truncate(string sql){
    try{
        dataBaseAccess.executeUpdate(sql);
    }catch (System.Data.SqlClient.SqlException se){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
    }catch (System.Data.DataException de){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
    }
#if !POCKET_PC
    catch (MySqlException mySqlExc){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<truncate>  : " + mySqlExc.Message, mySqlExc);
    }catch (NpgsqlException npgsqlException){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<truncate>  : " + npgsqlException.Message, npgsqlException);
    }
#else
    catch(System.Data.SqlServerCe.SqlCeException sece){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + sece.Message, sece);
	}
#endif
    catch (System.Exception ex){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<truncate> : " + ex.Message, ex);
    }
}    

protected
void delete(string sql){
    try
    {
        dataBaseAccess.executeUpdate(sql);
    }
    catch (System.Data.SqlClient.SqlException se)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
    }
    catch (System.Data.DataException de)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
    }
#if !POCKET_PC
    catch (MySqlException mySqlExc)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<delete>  : " + mySqlExc.Message, mySqlExc);
    }
    catch (NpgsqlException npgsqlException)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<delete>  : " + npgsqlException.Message, npgsqlException);
    }
#else
    catch(System.Data.SqlServerCe.SqlCeException sece){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + sece.Message, sece);
	}
#endif
    catch (System.Exception ex)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<delete> : " + ex.Message, ex);
    }
}
 
protected
void update(string sql){
    try
    {
        dataBaseAccess.executeUpdate(sql);
    }
    catch (System.Data.SqlClient.SqlException se)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
    }
    catch (System.Data.DataException de)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
    }
#if !POCKET_PC
    catch (MySqlException mySqlExc)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<update>  : " + mySqlExc.Message, mySqlExc);
    }
    catch (NpgsqlException npgsqlException)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<update>  : " + npgsqlException.Message, npgsqlException);
    }
#else
    catch(System.Data.SqlServerCe.SqlCeException sece){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + sece.Message, sece);
	}
#endif
    catch (System.Exception ex)
    {
        throw new PersistenceException("Error in class " + this.GetType().Name + "<update> : " + ex.Message, ex);
    }
}

} // class

} // namespace
