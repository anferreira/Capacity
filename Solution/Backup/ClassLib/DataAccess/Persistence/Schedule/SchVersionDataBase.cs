using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchVersionDataBase : GenericDataBaseElement{

private string SCH_Plt;
private string SCH_Version;
private string SCH_Status;
private string SCH_SysSett;
private DateTime SCH_DtStart;
private DateTime SCH_DtEnd;
private DateTime SCH_DtCreat;
private string SCH_UserCr;
private DateTime SCH_DtUpdate;
private string SCH_UserUp;

public
SchVersionDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SCH_Plt = reader.GetString("SCH_Plt");
	this.SCH_Version = reader.GetString("SCH_Version");
	this.SCH_Status = reader.GetString("SCH_Status");
	this.SCH_SysSett = reader.GetString("SCH_SysSett");
	this.SCH_DtStart = reader.GetDateTime("SCH_DtStart");
	this.SCH_DtEnd = reader.GetDateTime("SCH_DtEnd");
	this.SCH_DtCreat = reader.GetDateTime("SCH_DtCreat");
	this.SCH_UserCr = reader.GetString("SCH_UserCr");
	this.SCH_DtUpdate = reader.GetDateTime("SCH_DtUpdate");
	this.SCH_UserUp = reader.GetString("SCH_UserUp");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schversion where " + 
			"SCH_Version = '" + Converter.fixString(SCH_Version) + "'";
		
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
void readByPltActive(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schversion where " + 
			"SCH_Plt = '" + Converter.fixString(SCH_Plt) + "' and " +
			"SCH_Status = '" + Converter.fixString(SCH_Status) + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptActive> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptActive> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptActive> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

public override
void delete(){
	try{
		string sql = "delete from schversion where " +
			"SCH_Version = '" + Converter.fixString(SCH_Version) + "'";
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
		string sql = "update schversion set " +
			"SCH_Status = '" + Converter.fixString(SCH_Status )+ "', " +
			"SCH_SysSett = '" + Converter.fixString(SCH_SysSett) + "', " +
			"SCH_DtStart = '" + DateUtil.getDateRepresentation(SCH_DtStart) + "', " +
			"SCH_DtEnd = '" + DateUtil.getDateRepresentation(SCH_DtEnd) + "', " +
			"SCH_DtCreat = '" + DateUtil.getDateRepresentation(SCH_DtCreat) + "', " +
			"SCH_UserCr = '" + Converter.fixString(SCH_UserCr) + "', " +
			"SCH_DtUpdate = '" + DateUtil.getDateRepresentation(SCH_DtUpdate) + "', " +
			"SCH_UserUp = '" + Converter.fixString(SCH_UserUp) + "'" +
		" where " + 
			"SCH_Version = '" + Converter.fixString(SCH_Version) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void write(){
	try{
		string sql = "insert into schversion values('" + 
			Converter.fixString(SCH_Plt) + "', '" +
			Converter.fixString(SCH_Version) + "', '" +
			Converter.fixString(SCH_Status) + "', '" +
			Converter.fixString(SCH_SysSett) + "', '" +
			DateUtil.getDateRepresentation(SCH_DtStart) + "', '" +
			DateUtil.getDateRepresentation(SCH_DtEnd) + "', '" +
			DateUtil.getDateRepresentation(SCH_DtCreat) + "', '" +
			Converter.fixString(SCH_UserCr) + "', '" +
			DateUtil.getDateRepresentation(SCH_DtUpdate) + "', '" +
			Converter.fixString(SCH_UserUp) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schversion where " + 
			"SCH_Version = '" + Converter.fixString(SCH_Version) + "'";
		
		bool returnValue = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException ){
		return false;
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setSCH_Plt(string SCH_Plt){
	this.SCH_Plt = SCH_Plt;
}

public
void setSCH_Version(string SCH_Version){
	this.SCH_Version = SCH_Version;
}

public
void setSCH_Status(string SCH_Status){
	this.SCH_Status = SCH_Status;
}

public
void setSCH_SysSett(string SCH_SysSett){
	this.SCH_SysSett = SCH_SysSett;
}

public
void setSCH_DtStart(DateTime SCH_DtStart){
	this.SCH_DtStart = SCH_DtStart;
}

public
void setSCH_DtEnd(DateTime SCH_DtEnd){
	this.SCH_DtEnd = SCH_DtEnd;
}

public
void setSCH_DtCreat(DateTime SCH_DtCreat){
	this.SCH_DtCreat = SCH_DtCreat;
}

public
void setSCH_UserCr(string SCH_UserCr){
	this.SCH_UserCr = SCH_UserCr;
}

public
void setSCH_DtUpdate(DateTime SCH_DtUpdate){
	this.SCH_DtUpdate = SCH_DtUpdate;
}

public
void setSCH_UserUp(string SCH_UserUp){
	this.SCH_UserUp = SCH_UserUp;
}


public
string getSCH_Plt(){
	return SCH_Plt;
}

public
string getSCH_Version(){
	return SCH_Version;
}

public
string getSCH_Status(){
	return SCH_Status;
}

public
string getSCH_SysSett(){
	return SCH_SysSett;
}

public
DateTime getSCH_DtStart(){
	return SCH_DtStart;
}

public
DateTime getSCH_DtEnd(){
	return SCH_DtEnd;
}

public
DateTime getSCH_DtCreat(){
	return SCH_DtCreat;
}

public
string getSCH_UserCr(){
	return SCH_UserCr;
}

public
DateTime getSCH_DtUpdate(){
	return SCH_DtUpdate;
}

public
string getSCH_UserUp(){
	return SCH_UserUp;
}

} // class

} // namespace