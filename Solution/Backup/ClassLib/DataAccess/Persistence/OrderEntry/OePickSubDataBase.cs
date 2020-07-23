/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $  Claudia Melo
*   $Date: 2006-12-21 19:56:25 $  6/4/2005
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePickSubDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OePickSubDataBase.cs,v $
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
class OePickSubDataBase : GenericDataBaseElement {

private int IPS_ID;
private string IPS_Db;
private int IPS_Serial;
private string IPS_SerialType;
private string IPS_PickedBy;

public
OePickSubDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oepicksub where " + getWhereCondition();

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
	string sql = "select * from oepicksub where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.IPS_ID = reader.GetInt32("IPS_ID");
	this.IPS_Db = reader.GetString("IPS_Db");
	this.IPS_Serial = reader.GetInt32("IPS_Serial");
	this.IPS_SerialType = reader.GetString("IPS_SerialType");
	this.IPS_PickedBy = reader.GetString("IPS_PickedBy");
}

public override
void write(){
	string sql = "insert into oepicksub (" + 
		"IPS_Db," +
		"IPS_Serial," +
		"IPS_SerialType," +
		"IPS_PickedBy" +

		") values (" + 

		"'" + Converter.fixString(IPS_Db) + "'," +
		"" + NumberUtil.toString(IPS_Serial) + "," +
		"'" + Converter.fixString(IPS_SerialType) + "'," +
		"'" + Converter.fixString(IPS_PickedBy) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update oepicksub set " +
		"IPS_Db = '" + Converter.fixString(IPS_Db) + "', " +
		"IPS_Serial = " + NumberUtil.toString(IPS_Serial) + ", " +
		"IPS_SerialType = '" + Converter.fixString(IPS_SerialType) + "', " +
		"IPS_PickedBy = '" + Converter.fixString(IPS_PickedBy) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepicksub where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"IPS_ID = " + NumberUtil.toString(IPS_ID) + "";
	return sqlWhere;
}

public
void setIPS_ID(int IPS_ID){
	this.IPS_ID = IPS_ID;
}

public
void setIPS_Db(string IPS_Db){
	this.IPS_Db = IPS_Db;
}

public
void setIPS_Serial(int IPS_Serial){
	this.IPS_Serial = IPS_Serial;
}

public
void setIPS_SerialType(string IPS_SerialType){
	this.IPS_SerialType = IPS_SerialType;
}

public
void setIPS_PickedBy(string IPS_PickedBy){
	this.IPS_PickedBy = IPS_PickedBy;
}

public
int getIPS_ID(){
	return IPS_ID;
}

public
string getIPS_Db(){
	return IPS_Db;
}

public
int getIPS_Serial(){
	return IPS_Serial;
}

public
string getIPS_SerialType(){
	return IPS_SerialType;
}

public
string getIPS_PickedBy(){
	return IPS_PickedBy;
}

} // class

} // package