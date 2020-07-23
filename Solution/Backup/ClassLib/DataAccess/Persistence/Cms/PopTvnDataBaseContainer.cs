using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PopTvnDataBaseContainer : GenericDataBaseContainer{

public
PopTvnDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "poptvn";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PopTvnDataBase popTvnDataBase = new PopTvnDataBase(dataBaseAccess);
			popTvnDataBase.load(reader);
			this.Add(popTvnDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from poptvn";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

public
PopTvnDataBaseContainer getPopTvnDataBaseContainer(string JRPT){
	PopTvnDataBaseContainer result = new PopTvnDataBaseContainer(dataBaseAccess);

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		PopTvnDataBase popTvnDataBase = (PopTvnDataBase)en.Current;

		if (JRPT.Equals(popTvnDataBase.getJRPT()))
			result.Add(popTvnDataBase);
	}
	return result;
}

} // class

} // namespace