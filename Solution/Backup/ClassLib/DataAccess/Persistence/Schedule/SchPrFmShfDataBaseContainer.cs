using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchPrFmShfDataBaseContainer : GenericDataBaseContainer{

public
SchPrFmShfDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprfmshf";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrFmShfDataBase schPrFmShfDataBase = new SchPrFmShfDataBase(dataBaseAccess);
			schPrFmShfDataBase.load(reader);
			this.Add(schPrFmShfDataBase);
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
void truncate(){
	try{
		string sql = "delete from schprfmshf";
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