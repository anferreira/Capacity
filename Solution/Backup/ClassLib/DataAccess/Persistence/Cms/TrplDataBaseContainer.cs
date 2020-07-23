using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class TrplDataBaseContainer : GenericDataBaseContainer{

public 
TrplDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary+".";
		
		sql += "trpl";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			TrplDataBase trplDataBase = new TrplDataBase(dataBaseAccess);
			trplDataBase.load(reader);
			this.Add(trplDataBase);
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
		string sql = "delete from trpl";
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
void readBySYTRDP(string[] filterTPartner){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct SYTRDP,SYSTXL from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary+".";
		
		sql += "trpl";
		
		if (filterTPartner.Length > 0){
			sql += " where SYTRDP in (";

			for(int i = 0; i < filterTPartner.Length; i++){
				sql += "'" + filterTPartner[i] + "'";
				if (i < filterTPartner.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			TrplDataBase trplDataBase = new TrplDataBase(dataBaseAccess);
			trplDataBase.loadBySYTRDP(reader);
			this.Add(trplDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySYTRDP> : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

}//end class

}//end nanespace
