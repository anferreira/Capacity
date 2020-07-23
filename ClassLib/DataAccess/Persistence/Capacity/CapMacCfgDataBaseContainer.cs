using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacCfgDataBaseContainer : GenericDataBaseContainer{
	
private string plt;
private string dept;
private string mach;

public
CapMacCfgDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void truncate(){
	try{
		string sql = "delete from capmaccfg";
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
void readByPltDept(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmaccfg " +
		             "where  CMC_Plt = '" + plt + "' and " +
			                "CMC_Dept = '" + dept + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
			capMacCfgDataBase.load(reader);
			this.Add(capMacCfgDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setPlt(string plt){
	this.plt = plt;
}
public
void setDept(string dept){
	this.dept = dept;
}

public
void setMach(string mach){
	this.mach = mach;
}

public
string getPlt(){
	return plt;
}
public
string getDept(){
	return dept;
}

public
string getMach(){
	return mach;
}

public
void read(){
	NotNullDataReader reader = null;
	try
	{
		string sql = "select * from CapMacCfg";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
		{
			CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
			capMacCfgDataBase.load(reader);
			this.Add(capMacCfgDataBase);
		}
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}
	catch(System.Data.DataException de)
	{
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
		string sql = "select A.* from CapMacCfg A, CapMacCfgA B where " +
			"CMC_Plt = '" + plt + "' and " +
			"A.CMC_Cfg = B.CMCA_Cfg and B.CMCA_Plt = '" + plt + "' and " +
			"B.CMCA_Dept = '" + dept + "' and B.CMCA_Mach = '" + mach + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
			capMacCfgDataBase.load(reader);
			this.Add(capMacCfgDataBase);
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


} // class

}