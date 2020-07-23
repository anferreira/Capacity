/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $  Claudia Melo
*   $Date: 2006-12-21 19:56:25 $  6/4/2005
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OeWaveDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OeWaveDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/12 19:34:22  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/04/07 20:37:29  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class OeWaveDataBase : GenericDataBaseElement {

private int IW_Id;
private string IW_Db;
private string IW_Wave;
private int IW_WaveNum;
private DateTime IW_DtTmCreated;
private string IW_UserCreated;
private int IW_TotalPicks;
private string IW_PickMethod;

public
OeWaveDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oewave where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	string sql = "select * from oewave where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.IW_Id = reader.GetInt32("IW_Id");
	this.IW_Db = reader.GetString("IW_Db");
	this.IW_Wave = reader.GetString("IW_Wave");
	this.IW_WaveNum = reader.GetInt32("IW_WaveNum");
	this.IW_DtTmCreated = reader.GetDateTime("IW_DtTmCreated");
	this.IW_UserCreated = reader.GetString("IW_UserCreated");
	this.IW_TotalPicks = reader.GetInt32("IW_TotalPicks");
	this.IW_PickMethod = reader.GetString("IW_PickMethod");
}

public override
void write(){
	string sql = "insert into oewave (" + 
		"IW_Db," +
		"IW_Wave," +
		"IW_WaveNum," +
		"IW_DtTmCreated," +
		"IW_UserCreated," +
		"IW_TotalPicks," +
		"IW_PickMethod" +

		") values (" + 

		"'" + Converter.fixString(IW_Db) + "'," +
		"'" + Converter.fixString(IW_Wave) + "'," +
		"" + NumberUtil.toString(IW_WaveNum) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(IW_DtTmCreated) + "'," +
		"'" + Converter.fixString(IW_UserCreated) + "'," +
		"" + NumberUtil.toString(IW_TotalPicks) + "," +
		"'" + Converter.fixString(IW_PickMethod) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update oewave set " +
		"IW_Db = '" + Converter.fixString(IW_Db) + "', " +
		"IW_Wave = '" + Converter.fixString(IW_Wave) + "', " +
		"IW_WaveNum = " + NumberUtil.toString(IW_WaveNum) + ", " +
		"IW_DtTmCreated = '" + DateUtil.getCompleteDateRepresentation(IW_DtTmCreated) + "', " +
		"IW_UserCreated = '" + Converter.fixString(IW_UserCreated) + "', " +
		"IW_TotalPicks = " + NumberUtil.toString(IW_TotalPicks) + ", " +
		"IW_PickMethod = '" + Converter.fixString(IW_PickMethod) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oewave where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"IW_Id = " + NumberUtil.toString(IW_Id) + "";
	return sqlWhere;
}

public
void setIW_Id(int IW_Id){
	this.IW_Id = IW_Id;
}

public
void setIW_Db(string IW_Db){
	this.IW_Db = IW_Db;
}

public
void setIW_Wave(string IW_Wave){
	this.IW_Wave = IW_Wave;
}

public
void setIW_WaveNum(int IW_WaveNum){
	this.IW_WaveNum = IW_WaveNum;
}

public
void setIW_DtTmCreated(DateTime IW_DtTmCreated){
	this.IW_DtTmCreated = IW_DtTmCreated;
}

public
void setIW_UserCreated(string IW_UserCreated){
	this.IW_UserCreated = IW_UserCreated;
}

public
void setIW_TotalPicks(int IW_TotalPicks){
	this.IW_TotalPicks = IW_TotalPicks;
}

public
void setIW_PickMethod(string IW_PickMethod){
	this.IW_PickMethod = IW_PickMethod;
}

public
int getIW_Id(){
	return IW_Id;
}

public
string getIW_Db(){
	return IW_Db;
}

public
string getIW_Wave(){
	return IW_Wave;
}

public
int getIW_WaveNum(){
	return IW_WaveNum;
}

public
DateTime getIW_DtTmCreated(){
	return IW_DtTmCreated;
}

public
string getIW_UserCreated(){
	return IW_UserCreated;
}

public
int getIW_TotalPicks(){
	return IW_TotalPicks;
}

public
string getIW_PickMethod(){
	return IW_PickMethod;
}

} // class
} // package