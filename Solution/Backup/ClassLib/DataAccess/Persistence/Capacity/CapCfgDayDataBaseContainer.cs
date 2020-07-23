using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapCfgDayDataBaseContainer : GenericDataBaseContainer{

private string plt;
private string dept;
private string mach;

public
CapCfgDayDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capcfgday";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapCfgDayDataBase capCfgDayDataBase = new CapCfgDayDataBase(dataBaseAccess);
			capCfgDayDataBase.load(reader);
			this.Add(capCfgDayDataBase);
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
		string sql = "select * from capcfgday A, capmaccfga B where " +
			"B.CMCA_Plt = '" + plt + "' and " +
			"B.CMCA_Dept = '" + dept + "' and " +
			"B.CMCA_Mach = '" + mach + "' and " +
			"B.CMCA_Cfg = A.CCD_Cfg";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapCfgDayDataBase capCfgDayDataBase = new CapCfgDayDataBase(dataBaseAccess);
			capCfgDayDataBase.load(reader);
			this.Add(capCfgDayDataBase);
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

} // class

}