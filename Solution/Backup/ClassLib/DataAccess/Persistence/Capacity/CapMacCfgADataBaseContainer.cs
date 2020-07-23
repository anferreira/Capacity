using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacCfgADataBaseContainer : GenericDataBaseContainer{

private string CMCA_Plt;
private string CMCA_Dept;
private string CMCA_Mach;
private string CMCA_Cfg;

public
CapMacCfgADataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmaccfga";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);
			capMacCfgADataBase.load(reader);
			this.Add(capMacCfgADataBase);
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
		string sql = "select * from capmaccfga where " +
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Mach = '" + CMCA_Mach + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);
			capMacCfgADataBase.load(reader);
			this.Add(capMacCfgADataBase);
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
void readByPltDeptCfg(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmaccfga where " +
			"CMCA_Plt = '" + CMCA_Plt + "' and " +
			"CMCA_Dept = '" + CMCA_Dept + "' and " +
			"CMCA_Cfg = '" + CMCA_Cfg + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);
			capMacCfgADataBase.load(reader);
			this.Add(capMacCfgADataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptCfg> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptCfg> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptCfg> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from capmaccfga";
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
void setCMCA_Cfg(string CMCA_Cfg){
	this.CMCA_Cfg = CMCA_Cfg;
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
string getCMCA_Cfg(){
	return CMCA_Cfg;
}

} // class

} // namespace