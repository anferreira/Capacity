using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


/// <summary>
/// Represents the Plant table
/// </summary>
public 
class PltDataBaseContainer : GenericDataBaseContainer{

/// <summary>
/// Constructor
/// </summary>
/// <param name="dataBaseAccess"></param>
public
PltDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

/// <summary>
/// Read method, reads all records from Plt table
/// </summary>
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plt";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
			pltDataBase.load(reader);
			this.Add(pltDataBase);
		}
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

/// <summary>
/// Read method, reads all records from Plt table by desc of Plt
/// </summary>
public
void readByDesc(string desc){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plt" +
			" where (P_Plt like '%" + Converter.fixString(desc) + "%') or " +
			"(P_PltName like '%" + Converter.fixString(desc) + "%') or " +
			"(P_Ads1 like '%" + Converter.fixString(desc) + "%') or " +
			"(P_Ads2 like '%" + Converter.fixString(desc) + "%') or " +
			"(P_Ads3 like '%" + Converter.fixString(desc) + "%') or " +
			"(P_Ads4 like '%" + Converter.fixString(desc) + "%') or " +
			"(P_PltShort like '%" + Converter.fixString(desc) + "%')"; 

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
			pltDataBase.load(reader);		
			this.Add(pltDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

/// <summary>
/// Truncates the Plt table
/// </summary>
public
void truncate(){
	try{
		string sql = "delete from plt";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

} // class

} // namespace
