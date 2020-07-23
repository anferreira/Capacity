using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class OEClassGroupDataBaseContainer : GenericDataBaseContainer	{

public OEClassGroupDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeclassgroup ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEClassGroupDataBase oeClassGroupDataBase = new OEClassGroupDataBase(dataBaseAccess);
			oeClassGroupDataBase.load(reader);
			this.Add(oeClassGroupDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class  " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class  " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public void truncate(){
	try{
		string sql = "delete from oeclassgroup";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}


public string[] getClassGroup(){
  
    NotNullDataReader reader = null;
	try{
		string sql = "select distinct(CG_ClassGroup) as classGroup " +
		             "from oeclassgroup ";
		              
		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0] = reader.GetString("classGroup");
			array.Add((object)line);
		}
		int index = 0;
		string[] vec = new string[array.Count];
	    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		    string[] lineArray = (string[])en.Current;
		    vec[index] = lineArray[0];
		    index++;
    	}
	    return vec;	
	    
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

}//end class
}//end namespace
