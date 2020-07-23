using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacDayDataBaseContainer : GenericDataBaseContainer{

private string CMD_Plt;
private string CMD_Dept;
private string CMD_Mach;

public
CapMacDayDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacday";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacDayDataBase capMacDayDataBase = new CapMacDayDataBase(dataBaseAccess);
			capMacDayDataBase.load(reader);
			this.Add(capMacDayDataBase);
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
		string sql = "select * from capmacday where " +
			"CMD_Plt = '" + CMD_Plt + "' and " +
			"CMD_Dept = '" + CMD_Dept + "' and " +
			"CMD_Mach = '" + CMD_Mach + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapMacDayDataBase capMacDayDataBase = new CapMacDayDataBase(dataBaseAccess);
			capMacDayDataBase.load(reader);
			this.Add(capMacDayDataBase);
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
		string sql = "delete from capmacday";
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
void setCMD_Plt(string CMD_Plt){
	this.CMD_Plt = CMD_Plt;
}

public
void setCMD_Dept(string CMD_Dept){
	this.CMD_Dept = CMD_Dept;
}

public
void setCMD_Mach(string CMD_Mach){
	this.CMD_Mach = CMD_Mach;
}


public
string getCMD_Plt(){
	return CMD_Plt;
}

public
string getCMD_Dept(){
	return CMD_Dept;
}

public
string getCMD_Mach(){
	return CMD_Mach;
}

} // class

}