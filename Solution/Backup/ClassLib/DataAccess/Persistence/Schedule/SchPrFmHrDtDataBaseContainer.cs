using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchPrFmHrDtDataBaseContainer : GenericDataBaseContainer{

private string SPHD_SchVersion;
	
public
SchPrFmHrDtDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void setSPHD_SchVersion(string SPHD_SchVersion) {
	this.SPHD_SchVersion = SPHD_SchVersion;
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprfmhrdt";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrFmHrDtDataBase schPrFmHrDtDataBase = new SchPrFmHrDtDataBase(dataBaseAccess);
			schPrFmHrDtDataBase.load(reader);
			this.Add(schPrFmHrDtDataBase);
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

public 
void readBySchVersion(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprfmhrdt where " +
			"SPHD_SchVersion = '" + SPHD_SchVersion + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrFmHrDtDataBase schPrFmHrDtDataBase = new SchPrFmHrDtDataBase(dataBaseAccess);
			schPrFmHrDtDataBase.load(reader);
			this.Add(schPrFmHrDtDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySchVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySchVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySchVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

public
void truncate(){
	try{
		string sql = "delete from schprfmhrdt";
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