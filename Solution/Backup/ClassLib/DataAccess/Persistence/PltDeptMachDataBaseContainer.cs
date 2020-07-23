using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class PltDeptMachDataBaseContainer : GenericDataBaseContainer{

private string PDM_Dept;
private string PDM_Plt;

public
PltDeptMachDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void setPDM_Dept(string PDM_Dept){
	this.PDM_Dept = PDM_Dept;
}

public
void setPDM_Plt(string PDM_Plt){
	this.PDM_Plt = PDM_Plt;
}

public
void readByPltDept(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "'";
					
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void readByPltDeptAndDesc(string searchText){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "'";
		if (searchText.Length > 0)	
			sql += " and PDM_Mach like '%" + searchText + "%' or PDM_Des1 like '%" + searchText + "%'";
			
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void readByPlt(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt;
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPlt> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPlt> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPlt> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPltDeptNotInConfiguration(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "' and not exists (";
		sql += "select * from capmaccfga where CMCA_Plt = '" + PDM_Plt + "' and CMCA_Dept = '" +
			PDM_Dept + "' and CMCA_Mach = PDM_Mach)";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void readByPltDeptNotInConfiguration(string cfg){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "' and not exists (";
		sql += "select * from capmaccfga where CMCA_Plt = '" + PDM_Plt + "' and CMCA_Dept = '" +
			PDM_Dept + "' and CMCA_Cfg = '" + cfg + "' and CMCA_Mach = PDM_Mach)";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);		
			this.Add(pltDeptMachDataBase);
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
void truncate(){
	try{
		string sql = "delete from pltdeptmach";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

} // class

} // namespace
