using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacCfgADataBase : GenericDataBaseElement{
	
private string CMCA_Cfg;
private string CMCA_Plt;
private string CMCA_Dept;
private string CMCA_Mach;
private string CMCA_MachTyp;
private string CMCA_DirTyp;

public
CapMacCfgADataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CMCA_Cfg = reader.GetString("CMCA_Cfg");
	this.CMCA_Plt = reader.GetString("CMCA_Plt");
	this.CMCA_Dept = reader.GetString("CMCA_Dept");
	this.CMCA_Mach = reader.GetString("CMCA_Mach");
	this.CMCA_MachTyp = reader.GetString("CMCA_MachTyp");
	this.CMCA_DirTyp = reader.GetString("CMCA_DirTyp");
}

public
void readByPltDeptMach(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmaccfga where " + 
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Mach = '" + CMCA_Mach + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
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
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmaccfga where " + 
			"CMCA_Cfg = '" + CMCA_Cfg + "' and " +
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Mach = '" + CMCA_Mach + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
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

public override
void write(){
	try{
		string sql = "insert into capmaccfga values('" + 
			Converter.fixString(CMCA_Cfg) + "', '" + 
			Converter.fixString(CMCA_Plt) + "', '" + 
			Converter.fixString(CMCA_Dept) + "', '" + 
			Converter.fixString(CMCA_Mach) + "', '" + 
			Converter.fixString(CMCA_MachTyp) + "', '" + 
			Converter.fixString(CMCA_DirTyp) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from capmaccfga where " +
			"CMCA_Cfg = '" + CMCA_Cfg + "' and " +
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Mach = '" + CMCA_Mach + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void deleteFromAllCfgs(){
	try{
		string sql = "delete from capmaccfga where " +
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Mach = '" + CMCA_Mach + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update capmaccfga set " +
			"CMCA_MachTyp = '" + Converter.fixString(CMCA_MachTyp) + "', " +
			"CMCA_DirTyp = '" + Converter.fixString(CMCA_DirTyp) + "'" +
		" where " + 
			"CMCA_Cfg = '" + CMCA_Cfg + "' and " +
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Mach = '" + CMCA_Mach + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql ="select * from capmaccfga where CMCA_Plt = '" + CMCA_Plt + "'" +
			"and CMCA_Dept = '"	+ CMCA_Dept	+ "'" +
			"and CMCA_Cfg = '"	+ CMCA_Cfg	+ "'" +
			"and CMCA_Mach = '"	+ CMCA_Mach	+ "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool existsByPltDeptMach(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql ="select * from capmacAcfg where " + 
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '"	+ CMCA_Dept	+ "' and " +
			"CMCA_Mach = '"	+ CMCA_Mach	+ "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool hasMachines (){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql ="select * from capmaccfga where CMCA_Plt = '" + CMCA_Plt + "'" +
			"and CMCA_Dept = '"	+ CMCA_Dept	+ "'" +
			"and CMCA_Cfg = '"	+ CMCA_Cfg	+ "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasMachine> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasMachine> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasMachine> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setCMCA_Cfg(string CMCA_Cfg){
	this.CMCA_Cfg = CMCA_Cfg;
}

public
void setCMCA_Plt(string CMCA_Plt){
	this.CMCA_Plt = CMCA_Plt;
}

public
void setCMCA_Dept(string CMCA_Dept){
	this.CMCA_Dept = CMCA_Dept;
}

public
void setCMCA_Mach(string CMCA_Mach){
	this.CMCA_Mach = CMCA_Mach;
}

public
void setCMCA_MachTyp(string CMCA_MachTyp){
	this.CMCA_MachTyp = CMCA_MachTyp;
}

public
void setCMCA_DirTyp(string CMCA_DirTyp){
	this.CMCA_DirTyp = CMCA_DirTyp;
}


public
string getCMCA_Cfg(){
	return CMCA_Cfg;
}

public
string getCMCA_Plt(){
	return CMCA_Plt;
}

public
string getCMCA_Dept(){
	return CMCA_Dept;
}

public
string getCMCA_Mach(){
	return CMCA_Mach;
}

public
string getCMCA_MachTyp(){
	return CMCA_MachTyp;
}

public
string getCMCA_DirTyp(){
	return CMCA_DirTyp;
}

}

}