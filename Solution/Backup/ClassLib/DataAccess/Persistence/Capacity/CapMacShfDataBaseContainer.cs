using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using MySql.Data;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacShfDataBaseContainer : GenericDataBaseContainer{

private string CMS_Plt;
private string CMS_Dept;
private string CMS_Mach;

private DateTime CMS_Dt;

public
CapMacShfDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacshf";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacShfDataBase capMacShfDataBase = new CapMacShfDataBase(dataBaseAccess);
			capMacShfDataBase.load(reader);
			this.Add(capMacShfDataBase);
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
void readByPltDeptMach(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacshf where " +
			"CMS_Plt = '" + CMS_Plt + "' and " +
			"CMS_Dept = '" + CMS_Dept + "' and " +
			"CMS_Mach = '" + CMS_Mach + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacShfDataBase capMacShfDataBase = new CapMacShfDataBase(dataBaseAccess);
			capMacShfDataBase.load(reader);
			this.Add(capMacShfDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMach> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMach> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMach> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByMachDt(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacshf where " +
			"CMS_Mach = '" + CMS_Mach + "' and " +
			"CMS_Dt = '" + CMS_Dt + "'" + 
			" order by CMS_Mach, CMS_Dt, CMS_Shf, CMS_DtShf";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacShfDataBase capMacShfDataBase = new CapMacShfDataBase(dataBaseAccess);
			capMacShfDataBase.load(reader);
			this.Add(capMacShfDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMach> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMach> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMach> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from capmacshf";
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
void setCMS_Plt(string CMS_Plt){
	this.CMS_Plt = CMS_Plt;
}

public
void setCMS_Dept(string CMS_Dept){
	this.CMS_Dept = CMS_Dept;
}

public
void setCMS_Mach(string CMS_Mach){
	this.CMS_Mach = CMS_Mach;
}

public
void setCMS_Dt(DateTime CMS_Dt){
	this.CMS_Dt = CMS_Dt;
}

public
string getCMS_Plt(){
	return CMS_Plt;
}

public
string getCMS_Dept(){
	return CMS_Dept;
}

public
string getCMS_Mach(){
	return CMS_Mach;
}

public
DateTime getCMS_Dt(){
	return CMS_Dt;
}


} // class

}