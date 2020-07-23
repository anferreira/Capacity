using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class PlantDataBaseContainer : GenericDataBaseContainer{


public PlantDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plant ";
				
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PlantDataBase plantDataBase = new PlantDataBase(dataBaseAccess);
			plantDataBase.load(reader);
			this.Add(plantDataBase);
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

public 
void read(string db, int company){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plant " +
		             "where " + 
		                    "PL_Db = '" + Converter.fixString(db) + "' and " +
		                    "PL_Company = " + NumberUtil.toString(company);
				
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PlantDataBase plantDataBase = new PlantDataBase(dataBaseAccess);
			plantDataBase.load(reader);
			this.Add(plantDataBase);
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
public 
bool existPlant(string db, int company){
	NotNullDataReader reader = null;
	try{
	    bool returnValue = false;
		string sql = "select * from plant " +
		             "where " + 
		                    "PL_Db = '" + Converter.fixString(db) +"' and " +
		                    "PL_Company = " + NumberUtil.toString(company);
				
		reader = dataBaseAccess.executeQuery(sql);
		
		if (reader.Read())
			returnValue = true;
			
		return returnValue;
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existPlant> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existPlant> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existPlant> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByDesc(string desc,string sdb,int icompany){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plant" +
			" where PL_PltName like '%" + Converter.fixString(desc) + "%'"; 

			if (sdb.Length > 0)
				sql+= " and PL_Db= '" + Converter.fixString(sdb) + "'";

			if (icompany >= 0)
				sql+= " and PL_Company=" + NumberUtil.toString(icompany);
			sql+= " order by PL_PltName";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PlantDataBase plantDataBase = new PlantDataBase(dataBaseAccess);
			plantDataBase.load(reader);		
			this.Add(plantDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from plant";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}



}//end class
}//end namespace
