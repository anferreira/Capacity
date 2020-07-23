using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacHrDataBaseContainer : GenericDataBaseContainer{

private string CMH_Plt;
private string CMH_Dept;
private string CMH_Mach;
private string CMH_Shf;
private string CMH_SchVersion;
private DateTime CMH_Dt;

public
CapMacHrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmachr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(dataBaseAccess);
			capMacHrDataBase.load(reader);
			this.Add(capMacHrDataBase);
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
void read(DateTime date, string tmType){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmachr " +
			" where CMH_TmType = '" + tmType + "' and CMH_Dt >= '" + 
				DateUtil.getDateRepresentation(date) +
			"' order by CMH_Plt, CMH_Dept, CMH_Mach";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(dataBaseAccess);
			capMacHrDataBase.load(reader);
			this.Add(capMacHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read(date, tmType)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read(date, tmType)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read(date, tmType)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPltDeptMach(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmachr where " +
			"CMH_Plt = '" + CMH_Plt + "' and " + 
			"CMH_Dept = '" + CMH_Dept + "' and " + 
			"CMH_Mach = '" + CMH_Mach + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(dataBaseAccess);
			capMacHrDataBase.load(reader);
			this.Add(capMacHrDataBase);
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
void readByPltDeptMachVersion(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmachr where " +
			"CMH_Plt = '" + Converter.fixString(CMH_Plt) + "' and " + 
			"CMH_Dept = '" + Converter.fixString(CMH_Dept) + "' and " + 
			"CMH_Mach = '" + Converter.fixString(CMH_Mach) + "' and " +
			"CMH_SchVersion = '" + Converter.fixString(CMH_SchVersion) + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(dataBaseAccess);
			capMacHrDataBase.load(reader);
			this.Add(capMacHrDataBase);
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
void readByPltDeptMachShf(DateTime dateStr,DateTime dateEnd){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmachr where " +
			"CMH_Plt = '" + CMH_Plt + "' and " + 
			"CMH_Dept = '" + CMH_Dept + "' and " + 
			"CMH_Mach = '" + CMH_Mach + "' and " +
			"CMH_Shf = '" + CMH_Shf +"' and " +
			"CMH_DT BETWEEN  '" + DateUtil.getDateRepresentation(dateStr) +"' and " +
						    "'" + DateUtil.getDateRepresentation(dateEnd) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(dataBaseAccess);
			capMacHrDataBase.load(reader);
			this.Add(capMacHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMachShf> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMachShf> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptMachShf> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from capmachr";
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
void setCMH_Plt(string CMH_Plt){
	this.CMH_Plt = CMH_Plt;
}

public 
void setCMH_Dept(string CMH_Dept){
	this.CMH_Dept = CMH_Dept;
}

public 
void setCMH_Mach(string CMH_Mach){
	this.CMH_Mach = CMH_Mach;
}

public 
void setCMH_Shf(string CMH_Shf){
	this.CMH_Shf = CMH_Shf;
}

public
void setCMH_SchVersion(string CMH_SchVersion){
	this.CMH_SchVersion = CMH_SchVersion;
}

public 
void setCMH_Dt(DateTime CMH_Dt){
   this.CMH_Dt = CMH_Dt;
}


public
string getCMH_Plt(){
	return CMH_Plt;
}

public
string getCMH_Dept(){
	return CMH_Dept;
}

public
string getCMH_Mach(){
	return CMH_Mach;
}

public
string getCMH_Shf(){
	return CMH_Shf;
}

public
string getCMH_SchVersion(){
	return CMH_SchVersion;
}

public
DateTime getCMH_Dt(){
   return CMH_Dt;
}



} // class

}