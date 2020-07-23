using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class MetHdrDataBaseContainer : GenericDataBaseContainer{

public
MetHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
			sql += Configuration.CMSLibrary + ".";

			sql += "methdr order by AOPART, AOSEQ#";
		}else{
			sql += "methdr order by AOPART, AOSEQ";
		}

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			MetHdrDataBase metHdrDataBase = new MetHdrDataBase(dataBaseAccess);
			metHdrDataBase.load(reader);
			this.Add(metHdrDataBase);
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
		string sql = "delete from methdr";
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