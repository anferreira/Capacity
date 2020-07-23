using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkrDataBaseContainer : GenericDataBaseContainer{

public
StkrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";

		sql += "stkr order by AXSTKL";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			StkrDataBase stkrDataBase = new StkrDataBase(dataBaseAccess);
			stkrDataBase.load(reader);
			this.Add(stkrDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from stkr";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

} // class

} // namespace