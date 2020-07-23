using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class ArCollTransNumDataBaseContainer : GenericDataBaseContainer	{

public ArCollTransNumDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public void read(){
    NotNullDataReader  reader = null;
	try{
		string sql = "select * from arcolltransnum ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArCollTransNumDataBase arCollTransNumDataBase = new ArCollTransNumDataBase(dataBaseAccess);
			arCollTransNumDataBase.load(reader);
			this.Add(arCollTransNumDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

	
}
}

