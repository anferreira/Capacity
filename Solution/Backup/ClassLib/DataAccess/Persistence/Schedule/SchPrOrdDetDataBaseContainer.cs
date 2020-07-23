using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchPrOrdDetDataBaseContainer : GenericDataBaseContainer{

private string SPOD_SchVersion;

public
SchPrOrdDetDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public 
void setSPOD_SchVersion(string SPOD_SchVersion){
	this.SPOD_SchVersion = SPOD_SchVersion;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprorddet where SPOD_SchVersion = '" + SPOD_SchVersion + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrOrdDetDataBase schPrOrdDetDataBase = new SchPrOrdDetDataBase(dataBaseAccess);
			schPrOrdDetDataBase.load(reader);
			this.Add(schPrOrdDetDataBase);
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
		string sql = "select * from schprorddet where " +
			"SPOD_SchVersion = '" + SPOD_SchVersion + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrOrdDetDataBase schPrOrdDetDataBase = new SchPrOrdDetDataBase(dataBaseAccess);
			schPrOrdDetDataBase.load(reader);
			this.Add(schPrOrdDetDataBase);
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
		string sql = "delete from schprorddet";
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