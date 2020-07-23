/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePSLotSerialDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OePSLotSerialDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/03/29 04:05:57  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class OePSLotSerialDataBase : GenericDataBaseElement {

private int PSS_ID;
private string PSS_Db;
private int PSS_PackSlip;
private int PSS_PSItemNum;
private int PSS_PSDetailNum;
private string PSS_LabelType;
private int PSS_Serial;
private string PSS_Lot;
private decimal PSS_Qty;
private string PSS_Ctn;
private string PSS_CtnType;
private string PSS_CtnName;

public
OePSLotSerialDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oepslotserial where " + getWhereCondition();

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
	string sql = "select * from oepslotserial where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.PSS_ID = reader.GetInt32("PSS_ID");
	this.PSS_Db = reader.GetString("PSS_Db");
	this.PSS_PackSlip = reader.GetInt32("PSS_PackSlip");
	this.PSS_PSItemNum = reader.GetInt32("PSS_PSItemNum");
	this.PSS_PSDetailNum = reader.GetInt32("PSS_PSDetailNum");
	this.PSS_LabelType = reader.GetString("PSS_LabelType");
	this.PSS_Serial = reader.GetInt32("PSS_Serial");
	this.PSS_Lot = reader.GetString("PSS_Lot");
	this.PSS_Qty = reader.GetDecimal("PSS_Qty");
	this.PSS_Ctn = reader.GetString("PSS_Ctn");
	this.PSS_CtnType = reader.GetString("PSS_CtnType");
	this.PSS_CtnName = reader.GetString("PSS_CtnName");
}

public override
void write(){
	string sql = "insert into oepslotserial (" + 
		"PSS_Db," +
		"PSS_PackSlip," +
		"PSS_PSItemNum," +
		"PSS_PSDetailNum," +
		"PSS_LabelType," +
		"PSS_Serial," +
		"PSS_Lot," +
		"PSS_Qty," +
		"PSS_Ctn," +
		"PSS_CtnType," +
		"PSS_CtnName" +

		") values (" + 

		"'" + Converter.fixString(PSS_Db) + "'," +
		"" + NumberUtil.toString(PSS_PackSlip) + "," +
		"" + NumberUtil.toString(PSS_PSItemNum) + "," +
		"" + NumberUtil.toString(PSS_PSDetailNum) + "," +
		"'" + Converter.fixString(PSS_LabelType) + "'," +
		"" + NumberUtil.toString(PSS_Serial) + "," +
		"'" + Converter.fixString(PSS_Lot) + "'," +
		"" + NumberUtil.toString(PSS_Qty) + "," +
		"'" + Converter.fixString(PSS_Ctn) + "'," +
		"'" + Converter.fixString(PSS_CtnType) + "'," +
		"'" + Converter.fixString(PSS_CtnName) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update oepslotserial set " +
		"PSS_Db = '" + Converter.fixString(PSS_Db) + "', " +
		"PSS_PackSlip = " + NumberUtil.toString(PSS_PackSlip) + ", " +
		"PSS_PSItemNum = " + NumberUtil.toString(PSS_PSItemNum) + ", " +
		"PSS_PSDetailNum = " + NumberUtil.toString(PSS_PSDetailNum) + ", " +
		"PSS_LabelType = '" + Converter.fixString(PSS_LabelType) + "', " +
		"PSS_Serial = " + NumberUtil.toString(PSS_Serial) + ", " +
		"PSS_Lot = '" + Converter.fixString(PSS_Lot) + "', " +
		"PSS_Qty = " + NumberUtil.toString(PSS_Qty) + ", " +
		"PSS_Ctn = '" + Converter.fixString(PSS_Ctn) + "', " +
		"PSS_CtnType = '" + Converter.fixString(PSS_CtnType) + "', " +
		"PSS_CtnName = '" + Converter.fixString(PSS_CtnName) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepslotserial where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"PSS_ID = " + NumberUtil.toString(PSS_ID) + "";
	return sqlWhere;
}

public
void setPSS_ID(int PSS_ID){
	this.PSS_ID = PSS_ID;
}

public
void setPSS_Db(string PSS_Db){
	this.PSS_Db = PSS_Db;
}

public
void setPSS_PackSlip(int PSS_PackSlip){
	this.PSS_PackSlip = PSS_PackSlip;
}

public
void setPSS_PSItemNum(int PSS_PSItemNum){
	this.PSS_PSItemNum = PSS_PSItemNum;
}

public
void setPSS_PSDetailNum(int PSS_PSDetailNum){
	this.PSS_PSDetailNum = PSS_PSDetailNum;
}

public
void setPSS_LabelType(string PSS_LabelType){
	this.PSS_LabelType = PSS_LabelType;
}

public
void setPSS_Serial(int PSS_Serial){
	this.PSS_Serial = PSS_Serial;
}

public
void setPSS_Lot(string PSS_Lot){
	this.PSS_Lot = PSS_Lot;
}

public
void setPSS_Qty(decimal PSS_Qty){
	this.PSS_Qty = PSS_Qty;
}

public
void setPSS_Ctn(string PSS_Ctn){
	this.PSS_Ctn = PSS_Ctn;
}

public
void setPSS_CtnType(string PSS_CtnType){
	this.PSS_CtnType = PSS_CtnType;
}

public
void setPSS_CtnName(string PSS_CtnName){
	this.PSS_CtnName = PSS_CtnName;
}

public
int getPSS_ID(){
	return PSS_ID;
}

public
string getPSS_Db(){
	return PSS_Db;
}

public
int getPSS_PackSlip(){
	return PSS_PackSlip;
}

public
int getPSS_PSItemNum(){
	return PSS_PSItemNum;
}

public
int getPSS_PSDetailNum(){
	return PSS_PSDetailNum;
}

public
string getPSS_LabelType(){
	return PSS_LabelType;
}

public
int getPSS_Serial(){
	return PSS_Serial;
}

public
string getPSS_Lot(){
	return PSS_Lot;
}

public
decimal getPSS_Qty(){
	return PSS_Qty;
}

public
string getPSS_Ctn(){
	return PSS_Ctn;
}

public
string getPSS_CtnType(){
	return PSS_CtnType;
}

public
string getPSS_CtnName(){
	return PSS_CtnName;
}

} // class

} // package