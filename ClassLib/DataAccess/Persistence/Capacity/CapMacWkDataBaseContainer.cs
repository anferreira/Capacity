using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacWkDataBaseContainer : GenericDataBaseContainer{

private string CMW_Plt;
private string CMW_Dept;
private string CMW_Mach;

public
CapMacWkDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacwk";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacWkDataBase capMacWkDataBase = new CapMacWkDataBase(dataBaseAccess);
			capMacWkDataBase.load(reader);
			this.Add(capMacWkDataBase);
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
void readByPltdeptMach(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacwk where " +
			"CMW_Plt = '" + CMW_Plt + "' and " +
			"CMW_Dept = '" + CMW_Dept + "' and " +
			"CMW_Mach = '" + CMW_Mach + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacWkDataBase capMacWkDataBase = new CapMacWkDataBase(dataBaseAccess);
			capMacWkDataBase.load(reader);
			this.Add(capMacWkDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltdeptMach> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltdeptMach> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltdeptMach> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from capmacwk";
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
void setCMW_Plt(string CMW_Plt){
	this.CMW_Plt = CMW_Plt;
}

public
void setCMW_Dept(string CMW_Dept){
	this.CMW_Dept = CMW_Dept;
}

public
void setCMW_Mach(string CMW_Mach){
	this.CMW_Mach = CMW_Mach;
}


public
string getCMW_Plt(){
	return CMW_Plt;
}

public
string getCMW_Dept(){
	return CMW_Dept;
}

public
string getCMW_Mach(){
	return CMW_Mach;
}

} // class

}