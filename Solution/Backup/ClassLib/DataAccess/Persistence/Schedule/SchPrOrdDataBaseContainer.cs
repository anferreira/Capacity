using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchPrOrdDataBaseContainer : GenericDataBaseContainer{

private string SPO_Plt;
private string SPO_Dept;
private string SPO_SchVersion;

public
SchPrOrdDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprord";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrOrdDataBase schPrOrdDataBase = new SchPrOrdDataBase(dataBaseAccess);
			schPrOrdDataBase.load(reader);
			this.Add(schPrOrdDataBase);
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
void readByVersion(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprord where " +
			"SPO_SchVersion = '" + SPO_SchVersion + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrOrdDataBase schPrOrdDataBase = new SchPrOrdDataBase(dataBaseAccess);
			schPrOrdDataBase.load(reader);
			this.Add(schPrOrdDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

public
void truncate(){
	try{
		string sql = "delete from schprord";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void setSPO_Plt(string SPO_Plt){
	this.SPO_Plt = SPO_Plt;
}

public
void setSPO_Dept(string SPO_Dept){
	this.SPO_Dept = SPO_Dept;
}

public
void setSPO_SchVersion(string SPO_SchVersion){
	this.SPO_SchVersion = SPO_SchVersion;
}

public
string getSPO_Plt(){
	return SPO_Plt;
}

public
string getSPO_Dept(){
	return SPO_Dept;
}

public
string getSPO_SchVersion(){
	return SPO_SchVersion;
}

} // class

} // namespace