/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePSHdrDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OePSHdrDataBase.cs,v $
*   Revision 1.4  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/03/29 04:05:56  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/23 20:02:47  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class OePSHdrDataBase : GenericDataBaseElement {

private int P_ID;
private string P_Db;
private int P_Company;
private string P_Plant;
private int P_PackSlipNum;
private string P_PackSlipType;
private DateTime P_DateCrt;
private string P_PrintInd;
private string P_ShipInd;
private string P_BillToCust;
private string P_ShipToCust;
private string P_BillToName;
private string P_ShipToName;
private string P_BillToPost;
private string P_Attention;
private DateTime P_ShipDate;
private string P_ShipVia;
private int P_OrderNum;
private string P_StkLoc;
private DateTime P_ShipTime;
private string P_ShipmentID;
private string P_TradingPartner;
private int P_MBOL;
private string P_PackSlip2;
private string P_ProNumber;
private string P_Status;
private string P_BTAdd1;
private string P_BTAdd2;
private string P_BTAdd3;
private string P_BTAdd4;
private string P_BTProvState;
private string P_BTCountry;
private string P_BTPostZip;
private string P_BTContact;
private string P_STAdd1;
private string P_STAdd2;
private string P_STAdd3;
private string P_STAdd4;
private string P_STProvState;
private string P_STCountry;
private string P_STPostZip;
private string P_STContact;
private string P_SFAdd1;
private string P_SFAdd2;
private string P_SFAdd3;
private string P_SFAdd4;
private string P_SFProvState;
private string P_SFCountry;
private string P_SFPostZip;
private string P_SFContact;

public
OePSHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oepshdr where " + getWhereCondition();

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
	string sql = "select * from oepshdr where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.P_ID = reader.GetInt32("P_ID");
	this.P_Db = reader.GetString("P_Db");
	this.P_Company = reader.GetInt32("P_Company");
	this.P_Plant = reader.GetString("P_Plant");
	this.P_PackSlipNum = reader.GetInt32("P_PackSlipNum");
	this.P_PackSlipType = reader.GetString("P_PackSlipType");
	this.P_DateCrt = reader.GetDateTime("P_DateCrt");
	this.P_PrintInd = reader.GetString("P_PrintInd");
	this.P_ShipInd = reader.GetString("P_ShipInd");
	this.P_BillToCust = reader.GetString("P_BillToCust");
	this.P_ShipToCust = reader.GetString("P_ShipToCust");
	this.P_BillToName = reader.GetString("P_BillToName");
	this.P_ShipToName = reader.GetString("P_ShipToName");
	this.P_BillToPost = reader.GetString("P_BillToPost");
	this.P_Attention = reader.GetString("P_Attention");
	this.P_ShipDate = reader.GetDateTime("P_ShipDate");
	this.P_ShipVia = reader.GetString("P_ShipVia");
	this.P_OrderNum = reader.GetInt32("P_OrderNum");
	this.P_StkLoc = reader.GetString("P_StkLoc");
	this.P_ShipTime = reader.GetDateTime("P_ShipTime");
	this.P_ShipmentID = reader.GetString("P_ShipmentID");
	this.P_TradingPartner = reader.GetString("P_TradingPartner");
	this.P_MBOL = reader.GetInt32("P_MBOL");
	this.P_PackSlip2 = reader.GetString("P_PackSlip2");
	this.P_ProNumber = reader.GetString("P_ProNumber");
	this.P_Status = reader.GetString("P_Status");
	this.P_BTAdd1 = reader.GetString("P_BTAdd1");
	this.P_BTAdd2 = reader.GetString("P_BTAdd2");
	this.P_BTAdd3 = reader.GetString("P_BTAdd3");
	this.P_BTAdd4 = reader.GetString("P_BTAdd4");
	this.P_BTProvState = reader.GetString("P_BTProvState");
	this.P_BTCountry = reader.GetString("P_BTCountry");
	this.P_BTPostZip = reader.GetString("P_BTPostZip");
	this.P_BTContact = reader.GetString("P_BTContact");
	this.P_STAdd1 = reader.GetString("P_STAdd1");
	this.P_STAdd2 = reader.GetString("P_STAdd2");
	this.P_STAdd3 = reader.GetString("P_STAdd3");
	this.P_STAdd4 = reader.GetString("P_STAdd4");
	this.P_STProvState = reader.GetString("P_STProvState");
	this.P_STCountry = reader.GetString("P_STCountry");
	this.P_STPostZip = reader.GetString("P_STPostZip");
	this.P_STContact = reader.GetString("P_STContact");
	this.P_SFAdd1 = reader.GetString("P_SFAdd1");
	this.P_SFAdd2 = reader.GetString("P_SFAdd2");
	this.P_SFAdd3 = reader.GetString("P_SFAdd3");
	this.P_SFAdd4 = reader.GetString("P_SFAdd4");
	this.P_SFProvState = reader.GetString("P_SFProvState");
	this.P_SFCountry = reader.GetString("P_SFCountry");
	this.P_SFPostZip = reader.GetString("P_SFPostZip");
	this.P_SFContact = reader.GetString("P_SFContact");
}

public override
void write(){
	string sql = "insert into oepshdr (" + 
		"P_Db," +
		"P_Company," +
		"P_Plant," +
		"P_PackSlipNum," +
		"P_PackSlipType," +
		"P_DateCrt," +
		"P_PrintInd," +
		"P_ShipInd," +
		"P_BillToCust," +
		"P_ShipToCust," +
		"P_BillToName," +
		"P_ShipToName," +
		"P_BillToPost," +
		"P_Attention," +
		"P_ShipDate," +
		"P_ShipVia," +
		"P_OrderNum," +
		"P_StkLoc," +
		"P_ShipTime," +
		"P_ShipmentID," +
		"P_TradingPartner," +
		"P_MBOL," +
		"P_PackSlip2," +
		"P_ProNumber," +
		"P_Status," +
		"P_BTAdd1," +
		"P_BTAdd2," +
		"P_BTAdd3," +
		"P_BTAdd4," +
		"P_BTProvState," +
		"P_BTCountry," +
		"P_BTPostZip," +
		"P_BTContact," +
		"P_STAdd1," +
		"P_STAdd2," +
		"P_STAdd3," +
		"P_STAdd4," +
		"P_STProvState," +
		"P_STCountry," +
		"P_STPostZip," +
		"P_STContact," +
		"P_SFAdd1," +
		"P_SFAdd2," +
		"P_SFAdd3," +
		"P_SFAdd4," +
		"P_SFProvState," +
		"P_SFCountry," +
		"P_SFPostZip," +
		"P_SFContact" +

		") values (" + 

		"'" + Converter.fixString(P_Db) + "'," +
		"" + NumberUtil.toString(P_Company) + "," +
		"'" + Converter.fixString(P_Plant) + "'," +
		"" + NumberUtil.toString(P_PackSlipNum) + "," +
		"'" + Converter.fixString(P_PackSlipType) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(P_DateCrt) + "'," +
		"'" + Converter.fixString(P_PrintInd) + "'," +
		"'" + Converter.fixString(P_ShipInd) + "'," +
		"'" + Converter.fixString(P_BillToCust) + "'," +
		"'" + Converter.fixString(P_ShipToCust) + "'," +
		"'" + Converter.fixString(P_BillToName) + "'," +
		"'" + Converter.fixString(P_ShipToName) + "'," +
		"'" + Converter.fixString(P_BillToPost) + "'," +
		"'" + Converter.fixString(P_Attention) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(P_ShipDate) + "'," +
		"'" + Converter.fixString(P_ShipVia) + "'," +
		"" + NumberUtil.toString(P_OrderNum) + "," +
		"'" + Converter.fixString(P_StkLoc) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(P_ShipTime) + "'," +
		"'" + Converter.fixString(P_ShipmentID) + "'," +
		"'" + Converter.fixString(P_TradingPartner) + "'," +
		"" + NumberUtil.toString(P_MBOL) + "," +
		"'" + Converter.fixString(P_PackSlip2) + "'," +
		"'" + Converter.fixString(P_ProNumber) + "'," +
		"'" + Converter.fixString(P_Status) + "'," +
		"'" + Converter.fixString(P_BTAdd1) + "'," +
		"'" + Converter.fixString(P_BTAdd2) + "'," +
		"'" + Converter.fixString(P_BTAdd3) + "'," +
		"'" + Converter.fixString(P_BTAdd4) + "'," +
		"'" + Converter.fixString(P_BTProvState) + "'," +
		"'" + Converter.fixString(P_BTCountry) + "'," +
		"'" + Converter.fixString(P_BTPostZip) + "'," +
		"'" + Converter.fixString(P_BTContact) + "'," +
		"'" + Converter.fixString(P_STAdd1) + "'," +
		"'" + Converter.fixString(P_STAdd2) + "'," +
		"'" + Converter.fixString(P_STAdd3) + "'," +
		"'" + Converter.fixString(P_STAdd4) + "'," +
		"'" + Converter.fixString(P_STProvState) + "'," +
		"'" + Converter.fixString(P_STCountry) + "'," +
		"'" + Converter.fixString(P_STPostZip) + "'," +
		"'" + Converter.fixString(P_STContact) + "'," +
		"'" + Converter.fixString(P_SFAdd1) + "'," +
		"'" + Converter.fixString(P_SFAdd2) + "'," +
		"'" + Converter.fixString(P_SFAdd3) + "'," +
		"'" + Converter.fixString(P_SFAdd4) + "'," +
		"'" + Converter.fixString(P_SFProvState) + "'," +
		"'" + Converter.fixString(P_SFCountry) + "'," +
		"'" + Converter.fixString(P_SFPostZip) + "'," +
		"'" + Converter.fixString(P_SFContact) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update oepshdr set " +
		"P_Db = '" + Converter.fixString(P_Db) + "', " +
		"P_Company = " + NumberUtil.toString(P_Company) + ", " +
		"P_Plant = '" + Converter.fixString(P_Plant) + "', " +
		"P_PackSlipNum = " + NumberUtil.toString(P_PackSlipNum) + ", " +
		"P_PackSlipType = '" + Converter.fixString(P_PackSlipType) + "', " +
		"P_DateCrt = '" + DateUtil.getCompleteDateRepresentation(P_DateCrt) + "', " +
		"P_PrintInd = '" + Converter.fixString(P_PrintInd) + "', " +
		"P_ShipInd = '" + Converter.fixString(P_ShipInd) + "', " +
		"P_BillToCust = '" + Converter.fixString(P_BillToCust) + "', " +
		"P_ShipToCust = '" + Converter.fixString(P_ShipToCust) + "', " +
		"P_BillToName = '" + Converter.fixString(P_BillToName) + "', " +
		"P_ShipToName = '" + Converter.fixString(P_ShipToName) + "', " +
		"P_BillToPost = '" + Converter.fixString(P_BillToPost) + "', " +
		"P_Attention = '" + Converter.fixString(P_Attention) + "', " +
		"P_ShipDate = '" + DateUtil.getCompleteDateRepresentation(P_ShipDate) + "', " +
		"P_ShipVia = '" + Converter.fixString(P_ShipVia) + "', " +
		"P_OrderNum = " + NumberUtil.toString(P_OrderNum) + ", " +
		"P_StkLoc = '" + Converter.fixString(P_StkLoc) + "', " +
		"P_ShipTime = '" + DateUtil.getCompleteDateRepresentation(P_ShipTime) + "', " +
		"P_ShipmentID = '" + Converter.fixString(P_ShipmentID) + "', " +
		"P_TradingPartner = '" + Converter.fixString(P_TradingPartner) + "', " +
		"P_MBOL = " + NumberUtil.toString(P_MBOL) + ", " +
		"P_PackSlip2 = '" + Converter.fixString(P_PackSlip2) + "', " +
		"P_ProNumber = '" + Converter.fixString(P_ProNumber) + "', " +
		"P_Status = '" + Converter.fixString(P_Status) + "', " +
		"P_BTAdd1 = '" + Converter.fixString(P_BTAdd1) + "', " +
		"P_BTAdd2 = '" + Converter.fixString(P_BTAdd2) + "', " +
		"P_BTAdd3 = '" + Converter.fixString(P_BTAdd3) + "', " +
		"P_BTAdd4 = '" + Converter.fixString(P_BTAdd4) + "', " +
		"P_BTProvState = '" + Converter.fixString(P_BTProvState) + "', " +
		"P_BTCountry = '" + Converter.fixString(P_BTCountry) + "', " +
		"P_BTPostZip = '" + Converter.fixString(P_BTPostZip) + "', " +
		"P_BTContact = '" + Converter.fixString(P_BTContact) + "', " +
		"P_STAdd1 = '" + Converter.fixString(P_STAdd1) + "', " +
		"P_STAdd2 = '" + Converter.fixString(P_STAdd2) + "', " +
		"P_STAdd3 = '" + Converter.fixString(P_STAdd3) + "', " +
		"P_STAdd4 = '" + Converter.fixString(P_STAdd4) + "', " +
		"P_STProvState = '" + Converter.fixString(P_STProvState) + "', " +
		"P_STCountry = '" + Converter.fixString(P_STCountry) + "', " +
		"P_STPostZip = '" + Converter.fixString(P_STPostZip) + "', " +
		"P_STContact = '" + Converter.fixString(P_STContact) + "', " +
		"P_SFAdd1 = '" + Converter.fixString(P_SFAdd1) + "', " +
		"P_SFAdd2 = '" + Converter.fixString(P_SFAdd2) + "', " +
		"P_SFAdd3 = '" + Converter.fixString(P_SFAdd3) + "', " +
		"P_SFAdd4 = '" + Converter.fixString(P_SFAdd4) + "', " +
		"P_SFProvState = '" + Converter.fixString(P_SFProvState) + "', " +
		"P_SFCountry = '" + Converter.fixString(P_SFCountry) + "', " +
		"P_SFPostZip = '" + Converter.fixString(P_SFPostZip) + "', " +
		"P_SFContact = '" + Converter.fixString(P_SFContact) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepshdr where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"P_Db = '" + Converter.fixString(P_Db) + "' and " +
		"P_Company = " + NumberUtil.toString(P_Company) + " and " +
		"P_Plant = '" + Converter.fixString(P_Plant) + "' and " +
		"P_PackSlipNum = " + NumberUtil.toString(P_PackSlipNum) + "";
	return sqlWhere;
}

public
void setP_ID(int P_ID){
	this.P_ID = P_ID;
}

public
void setP_Db(string P_Db){
	this.P_Db = P_Db;
}

public
void setP_Company(int P_Company){
	this.P_Company = P_Company;
}

public
void setP_Plant(string P_Plant){
	this.P_Plant = P_Plant;
}

public
void setP_PackSlipNum(int P_PackSlipNum){
	this.P_PackSlipNum = P_PackSlipNum;
}

public
void setP_PackSlipType(string P_PackSlipType){
	this.P_PackSlipType = P_PackSlipType;
}

public
void setP_DateCrt(DateTime P_DateCrt){
	this.P_DateCrt = P_DateCrt;
}

public
void setP_PrintInd(string P_PrintInd){
	this.P_PrintInd = P_PrintInd;
}

public
void setP_ShipInd(string P_ShipInd){
	this.P_ShipInd = P_ShipInd;
}

public
void setP_BillToCust(string P_BillToCust){
	this.P_BillToCust = P_BillToCust;
}

public
void setP_ShipToCust(string P_ShipToCust){
	this.P_ShipToCust = P_ShipToCust;
}

public
void setP_BillToName(string P_BillToName){
	this.P_BillToName = P_BillToName;
}

public
void setP_ShipToName(string P_ShipToName){
	this.P_ShipToName = P_ShipToName;
}

public
void setP_BillToPost(string P_BillToPost){
	this.P_BillToPost = P_BillToPost;
}

public
void setP_Attention(string P_Attention){
	this.P_Attention = P_Attention;
}

public
void setP_ShipDate(DateTime P_ShipDate){
	this.P_ShipDate = P_ShipDate;
}

public
void setP_ShipVia(string P_ShipVia){
	this.P_ShipVia = P_ShipVia;
}

public
void setP_OrderNum(int P_OrderNum){
	this.P_OrderNum = P_OrderNum;
}

public
void setP_StkLoc(string P_StkLoc){
	this.P_StkLoc = P_StkLoc;
}

public
void setP_ShipTime(DateTime P_ShipTime){
	this.P_ShipTime = P_ShipTime;
}

public
void setP_ShipmentID(string P_ShipmentID){
	this.P_ShipmentID = P_ShipmentID;
}

public
void setP_TradingPartner(string P_TradingPartner){
	this.P_TradingPartner = P_TradingPartner;
}

public
void setP_MBOL(int P_MBOL){
	this.P_MBOL = P_MBOL;
}

public
void setP_PackSlip2(string P_PackSlip2){
	this.P_PackSlip2 = P_PackSlip2;
}

public
void setP_ProNumber(string P_ProNumber){
	this.P_ProNumber = P_ProNumber;
}

public
void setP_Status(string P_Status){
	this.P_Status = P_Status;
}

public
void setP_BTAdd1(string P_BTAdd1){
	this.P_BTAdd1 = P_BTAdd1;
}

public
void setP_BTAdd2(string P_BTAdd2){
	this.P_BTAdd2 = P_BTAdd2;
}

public
void setP_BTAdd3(string P_BTAdd3){
	this.P_BTAdd3 = P_BTAdd3;
}

public
void setP_BTAdd4(string P_BTAdd4){
	this.P_BTAdd4 = P_BTAdd4;
}

public
void setP_BTProvState(string P_BTProvState){
	this.P_BTProvState = P_BTProvState;
}

public
void setP_BTCountry(string P_BTCountry){
	this.P_BTCountry = P_BTCountry;
}

public
void setP_BTPostZip(string P_BTPostZip){
	this.P_BTPostZip = P_BTPostZip;
}

public
void setP_BTContact(string P_BTContact){
	this.P_BTContact = P_BTContact;
}

public
void setP_STAdd1(string P_STAdd1){
	this.P_STAdd1 = P_STAdd1;
}

public
void setP_STAdd2(string P_STAdd2){
	this.P_STAdd2 = P_STAdd2;
}

public
void setP_STAdd3(string P_STAdd3){
	this.P_STAdd3 = P_STAdd3;
}

public
void setP_STAdd4(string P_STAdd4){
	this.P_STAdd4 = P_STAdd4;
}

public
void setP_STProvState(string P_STProvState){
	this.P_STProvState = P_STProvState;
}

public
void setP_STCountry(string P_STCountry){
	this.P_STCountry = P_STCountry;
}

public
void setP_STPostZip(string P_STPostZip){
	this.P_STPostZip = P_STPostZip;
}

public
void setP_STContact(string P_STContact){
	this.P_STContact = P_STContact;
}

public
void setP_SFAdd1(string P_SFAdd1){
	this.P_SFAdd1 = P_SFAdd1;
}

public
void setP_SFAdd2(string P_SFAdd2){
	this.P_SFAdd2 = P_SFAdd2;
}

public
void setP_SFAdd3(string P_SFAdd3){
	this.P_SFAdd3 = P_SFAdd3;
}

public
void setP_SFAdd4(string P_SFAdd4){
	this.P_SFAdd4 = P_SFAdd4;
}

public
void setP_SFProvState(string P_SFProvState){
	this.P_SFProvState = P_SFProvState;
}

public
void setP_SFCountry(string P_SFCountry){
	this.P_SFCountry = P_SFCountry;
}

public
void setP_SFPostZip(string P_SFPostZip){
	this.P_SFPostZip = P_SFPostZip;
}

public
void setP_SFContact(string P_SFContact){
	this.P_SFContact = P_SFContact;
}

public
int getP_ID(){
	return P_ID;
}

public
string getP_Db(){
	return P_Db;
}

public
int getP_Company(){
	return P_Company;
}

public
string getP_Plant(){
	return P_Plant;
}

public
int getP_PackSlipNum(){
	return P_PackSlipNum;
}

public
string getP_PackSlipType(){
	return P_PackSlipType;
}

public
DateTime getP_DateCrt(){
	return P_DateCrt;
}

public
string getP_PrintInd(){
	return P_PrintInd;
}

public
string getP_ShipInd(){
	return P_ShipInd;
}

public
string getP_BillToCust(){
	return P_BillToCust;
}

public
string getP_ShipToCust(){
	return P_ShipToCust;
}

public
string getP_BillToName(){
	return P_BillToName;
}

public
string getP_ShipToName(){
	return P_ShipToName;
}

public
string getP_BillToPost(){
	return P_BillToPost;
}

public
string getP_Attention(){
	return P_Attention;
}

public
DateTime getP_ShipDate(){
	return P_ShipDate;
}

public
string getP_ShipVia(){
	return P_ShipVia;
}

public
int getP_OrderNum(){
	return P_OrderNum;
}

public
string getP_StkLoc(){
	return P_StkLoc;
}

public
DateTime getP_ShipTime(){
	return P_ShipTime;
}

public
string getP_ShipmentID(){
	return P_ShipmentID;
}

public
string getP_TradingPartner(){
	return P_TradingPartner;
}

public
int getP_MBOL(){
	return P_MBOL;
}

public
string getP_PackSlip2(){
	return P_PackSlip2;
}

public
string getP_ProNumber(){
	return P_ProNumber;
}

public
string getP_Status(){
	return P_Status;
}

public
string getP_BTAdd1(){
	return P_BTAdd1;
}

public
string getP_BTAdd2(){
	return P_BTAdd2;
}

public
string getP_BTAdd3(){
	return P_BTAdd3;
}

public
string getP_BTAdd4(){
	return P_BTAdd4;
}

public
string getP_BTProvState(){
	return P_BTProvState;
}

public
string getP_BTCountry(){
	return P_BTCountry;
}

public
string getP_BTPostZip(){
	return P_BTPostZip;
}

public
string getP_BTContact(){
	return P_BTContact;
}

public
string getP_STAdd1(){
	return P_STAdd1;
}

public
string getP_STAdd2(){
	return P_STAdd2;
}

public
string getP_STAdd3(){
	return P_STAdd3;
}

public
string getP_STAdd4(){
	return P_STAdd4;
}

public
string getP_STProvState(){
	return P_STProvState;
}

public
string getP_STCountry(){
	return P_STCountry;
}

public
string getP_STPostZip(){
	return P_STPostZip;
}

public
string getP_STContact(){
	return P_STContact;
}

public
string getP_SFAdd1(){
	return P_SFAdd1;
}

public
string getP_SFAdd2(){
	return P_SFAdd2;
}

public
string getP_SFAdd3(){
	return P_SFAdd3;
}

public
string getP_SFAdd4(){
	return P_SFAdd4;
}

public
string getP_SFProvState(){
	return P_SFProvState;
}

public
string getP_SFCountry(){
	return P_SFCountry;
}

public
string getP_SFPostZip(){
	return P_SFPostZip;
}

public
string getP_SFContact(){
	return P_SFContact;
}

} // class

} // package