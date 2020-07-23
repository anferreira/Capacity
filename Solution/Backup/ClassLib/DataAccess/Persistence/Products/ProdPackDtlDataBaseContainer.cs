using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class ProdPackDtlDataBaseContainer : GenericDataBaseContainer{

private string PCK_SchVersion;
private string PCK_Plt;
private string PCK_Dept;
		
public 
ProdPackDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
		
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodpackdtl";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdPackDtlDataBase prodPackDtlDataBase = new ProdPackDtlDataBase(dataBaseAccess);
			prodPackDtlDataBase.load(reader);
			this.Add(prodPackDtlDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
		
public 
void readBySchVersion(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodpackdtl where " +
				"PCK_SchVersion = '" + PCK_SchVersion + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdPackDtlDataBase prodPackDtlDataBase = new ProdPackDtlDataBase(dataBaseAccess);
			prodPackDtlDataBase.load(reader);
			this.Add(prodPackDtlDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySchVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySchVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readBySchVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
		
public
void truncate(){
	try{
		string sql = "delete from prodpackdtl";
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
string getPCK_SchVersion(){
	return PCK_SchVersion;
}

public 
void setPCK_SchVersion (string PCK_SchVersion){
	this.PCK_SchVersion = PCK_SchVersion;
}

public 
string getPCK_Plt (){
	return PCK_Plt;
}

public 
void setPCK_Plt (string PCK_Plt){
	this.PCK_Plt = PCK_Plt;
}

public 
string getPCK_Dept(){
	return PCK_Dept;
}

public 
void setPCK_Dept (string PCK_Dept){
	this.PCK_Dept = PCK_Dept;
}

} // class

} // namespace

