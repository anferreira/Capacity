/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePSCtnDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OePSCtnDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/03/29 04:05:56  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class OePSCtnDataBase : GenericDataBaseElement {

private int PSC_ID;
private string PSC_Db;
private int PSC_PackSlip;
private int PSC_PSItemNum;
private int PSC_PSDetailNum;
private string PSC_LabelType;
private int PSC_Serial;
private string PSC_CtnType;
private string PSC_Ctn;
private string PSC_CtnName;
private int PSC_CtnSerial;
private decimal PSC_CtnWgt;
private string PSC_CtnWgtUom;
private decimal PSC_CtnVol;
private decimal PSC_TotalWgt;

public
OePSCtnDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oepsctn where " + getWhereCondition();

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
	string sql = "select * from oepsctn where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.PSC_ID = reader.GetInt32("PSC_ID");
	this.PSC_Db = reader.GetString("PSC_Db");
	this.PSC_PackSlip = reader.GetInt32("PSC_PackSlip");
	this.PSC_PSItemNum = reader.GetInt32("PSC_PSItemNum");
	this.PSC_PSDetailNum = reader.GetInt32("PSC_PSDetailNum");
	this.PSC_LabelType = reader.GetString("PSC_LabelType");
	this.PSC_Serial = reader.GetInt32("PSC_Serial");
	this.PSC_CtnType = reader.GetString("PSC_CtnType");
	this.PSC_Ctn = reader.GetString("PSC_Ctn");
	this.PSC_CtnName = reader.GetString("PSC_CtnName");
	this.PSC_CtnSerial = reader.GetInt32("PSC_CtnSerial");
	this.PSC_CtnWgt = reader.GetDecimal("PSC_CtnWgt");
	this.PSC_CtnWgtUom = reader.GetString("PSC_CtnWgtUom");
	this.PSC_CtnVol = reader.GetDecimal("PSC_CtnVol");
	this.PSC_TotalWgt = reader.GetDecimal("PSC_TotalWgt");
}

public override
void write(){
	string sql = "insert into oepsctn (" + 
		"PSC_Db," +
		"PSC_PackSlip," +
		"PSC_PSItemNum," +
		"PSC_PSDetailNum," +
		"PSC_LabelType," +
		"PSC_Serial," +
		"PSC_CtnType," +
		"PSC_Ctn," +
		"PSC_CtnName," +
		"PSC_CtnSerial," +
		"PSC_CtnWgt," +
		"PSC_CtnWgtUom," +
		"PSC_CtnVol," +
		"PSC_TotalWgt" +

		") values (" + 

		"'" + Converter.fixString(PSC_Db) + "'," +
		"" + NumberUtil.toString(PSC_PackSlip) + "," +
		"" + NumberUtil.toString(PSC_PSItemNum) + "," +
		"" + NumberUtil.toString(PSC_PSDetailNum) + "," +
		"'" + Converter.fixString(PSC_LabelType) + "'," +
		"" + NumberUtil.toString(PSC_Serial) + "," +
		"'" + Converter.fixString(PSC_CtnType) + "'," +
		"'" + Converter.fixString(PSC_Ctn) + "'," +
		"'" + Converter.fixString(PSC_CtnName) + "'," +
		"" + NumberUtil.toString(PSC_CtnSerial) + "," +
		"" + NumberUtil.toString(PSC_CtnWgt) + "," +
		"'" + Converter.fixString(PSC_CtnWgtUom) + "'," +
		"" + NumberUtil.toString(PSC_CtnVol) + "," +
		"" + NumberUtil.toString(PSC_TotalWgt) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update oepsctn set " +
		"PSC_Db = '" + Converter.fixString(PSC_Db) + "', " +
		"PSC_PackSlip = " + NumberUtil.toString(PSC_PackSlip) + ", " +
		"PSC_PSItemNum = " + NumberUtil.toString(PSC_PSItemNum) + ", " +
		"PSC_PSDetailNum = " + NumberUtil.toString(PSC_PSDetailNum) + ", " +
		"PSC_LabelType = '" + Converter.fixString(PSC_LabelType) + "', " +
		"PSC_Serial = " + NumberUtil.toString(PSC_Serial) + ", " +
		"PSC_CtnType = '" + Converter.fixString(PSC_CtnType) + "', " +
		"PSC_Ctn = '" + Converter.fixString(PSC_Ctn) + "', " +
		"PSC_CtnName = '" + Converter.fixString(PSC_CtnName) + "', " +
		"PSC_CtnSerial = " + NumberUtil.toString(PSC_CtnSerial) + ", " +
		"PSC_CtnWgt = " + NumberUtil.toString(PSC_CtnWgt) + ", " +
		"PSC_CtnWgtUom = '" + Converter.fixString(PSC_CtnWgtUom) + "', " +
		"PSC_CtnVol = " + NumberUtil.toString(PSC_CtnVol) + ", " +
		"PSC_TotalWgt = " + NumberUtil.toString(PSC_TotalWgt) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepsctn where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"PSC_ID = " + NumberUtil.toString(PSC_ID) + "";
	return sqlWhere;
}

public
void setPSC_ID(int PSC_ID){
	this.PSC_ID = PSC_ID;
}

public
void setPSC_Db(string PSC_Db){
	this.PSC_Db = PSC_Db;
}

public
void setPSC_PackSlip(int PSC_PackSlip){
	this.PSC_PackSlip = PSC_PackSlip;
}

public
void setPSC_PSItemNum(int PSC_PSItemNum){
	this.PSC_PSItemNum = PSC_PSItemNum;
}

public
void setPSC_PSDetailNum(int PSC_PSDetailNum){
	this.PSC_PSDetailNum = PSC_PSDetailNum;
}

public
void setPSC_LabelType(string PSC_LabelType){
	this.PSC_LabelType = PSC_LabelType;
}

public
void setPSC_Serial(int PSC_Serial){
	this.PSC_Serial = PSC_Serial;
}

public
void setPSC_CtnType(string PSC_CtnType){
	this.PSC_CtnType = PSC_CtnType;
}

public
void setPSC_Ctn(string PSC_Ctn){
	this.PSC_Ctn = PSC_Ctn;
}

public
void setPSC_CtnName(string PSC_CtnName){
	this.PSC_CtnName = PSC_CtnName;
}

public
void setPSC_CtnSerial(int PSC_CtnSerial){
	this.PSC_CtnSerial = PSC_CtnSerial;
}

public
void setPSC_CtnWgt(decimal PSC_CtnWgt){
	this.PSC_CtnWgt = PSC_CtnWgt;
}

public
void setPSC_CtnWgtUom(string PSC_CtnWgtUom){
	this.PSC_CtnWgtUom = PSC_CtnWgtUom;
}

public
void setPSC_CtnVol(decimal PSC_CtnVol){
	this.PSC_CtnVol = PSC_CtnVol;
}

public
void setPSC_TotalWgt(decimal PSC_TotalWgt){
	this.PSC_TotalWgt = PSC_TotalWgt;
}

public
int getPSC_ID(){
	return PSC_ID;
}

public
string getPSC_Db(){
	return PSC_Db;
}

public
int getPSC_PackSlip(){
	return PSC_PackSlip;
}

public
int getPSC_PSItemNum(){
	return PSC_PSItemNum;
}

public
int getPSC_PSDetailNum(){
	return PSC_PSDetailNum;
}

public
string getPSC_LabelType(){
	return PSC_LabelType;
}

public
int getPSC_Serial(){
	return PSC_Serial;
}

public
string getPSC_CtnType(){
	return PSC_CtnType;
}

public
string getPSC_Ctn(){
	return PSC_Ctn;
}

public
string getPSC_CtnName(){
	return PSC_CtnName;
}

public
int getPSC_CtnSerial(){
	return PSC_CtnSerial;
}

public
decimal getPSC_CtnWgt(){
	return PSC_CtnWgt;
}

public
string getPSC_CtnWgtUom(){
	return PSC_CtnWgtUom;
}

public
decimal getPSC_CtnVol(){
	return PSC_CtnVol;
}

public
decimal getPSC_TotalWgt(){
	return PSC_TotalWgt;
}

} // class

} // package