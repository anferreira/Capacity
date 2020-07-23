using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class TimeResDataBaseContainer : GenericDataBaseContainer{

public
TimeResDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from timeres";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			TimeResDataBase timeResDataBase = new TimeResDataBase(dataBaseAccess);
			timeResDataBase.load(reader);
			this.Add(timeResDataBase);
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

} // class

} // namespace