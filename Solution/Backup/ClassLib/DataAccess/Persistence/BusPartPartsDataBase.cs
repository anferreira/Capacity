/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/BusPartPartsDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: BusPartPartsDataBase.cs,v $
*   Revision 1.12  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.11  2005/05/17 04:34:51  gmuller
*   ponga aqui un comentario
*
*   Revision 1.10  2005/04/02 17:31:23  aferreira
*   *** empty log message ***
*
*   Revision 1.9  2005/03/18 19:08:48  cmelo
*   *** empty log message ***
*
*   Revision 1.8  2005/03/18 03:21:19  cmelo
*   *** empty log message ***
*
*   Revision 1.7  2005/03/18 00:21:36  cmelo
*   *** empty log message ***
*
*   Revision 1.6  2005/03/17 02:52:42  cmelo
*   *** empty log message ***
*
*   Revision 1.5  2005/03/16 20:10:04  cmelo
*   *** empty log message ***
*
*   Revision 1.4  2005/03/15 21:26:30  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/03/15 01:10:18  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class BusPartPartsDataBase : GenericDataBaseElement {

private int BPP_ID;
private string BPP_Db;
private string BPP_Part;
private int BPP_Sequence;
private string BPP_BusPartnerBT;
private string BPP_BusPartPart;
private string BPP_BusPartnerST;
private string BPP_Revision;
private string BPP_DropShipCust;
private string BPP_Consignment;
private decimal BPP_BoxPackQty;
private decimal BPP_CasePackQty;
private decimal BPP_SkidPackQty;
private string BPP_PackUom;
private string BPP_BoxCont;
private string BPP_CaseCont;
private string BPP_SkidCont;
private string BPP_UPCBox;
private string BPP_UPCCase;
private string BPP_UPCSkid;
private string BPP_Manufacturer;
private string BPP_Alias;
private string BPP_UPC;
private DateTime BPP_StartDate;
private DateTime BPP_EndDate;
private string BPP_SC1;
private string BPP_SC2;
private string BPP_SC3;
private string BPP_SC4;
private string BPP_SC5;
private string BPP_SC6;
private string BPP_Salesperson;
private string BPP_CommPlan;
private decimal BPP_CommPercent;
private decimal BPP_CommRate;
private string BPP_PackProfile;
private int BPP_WarrantyDays;
private int BPP_ExpiryDate;
private string BPP_UnitLFmt;
private int BPP_UnitLFmtQty;
private string BPP_BoxLFmt;
private int BPP_BoxLFmtQty;
private string BPP_CaseLFmt;
private int BPP_CaseLFmtQty;
private string BPP_SkidLFmt;
private int BPP_SkidLFmtQty;
private string BPP_Make;
private string BPP_Model;
private string BPP_Brand;
private string BPP_Color;
private string BPP_Size;
private string BPP_Style;

public
BusPartPartsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from buspartparts where " + getWhereCondition();

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
void readById(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from buspartparts " + 
		             "where BPP_ID = " + NumberUtil.toString(BPP_ID) ;

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readById> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readById> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readById> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
bool exists(){
	string sql = "select * from buspartparts where " + getWhereCondition();
	return exists(sql);
}

//Check if exsit a record 
public
bool existsByPart(){
	string sql = "select * from buspartparts " +
	             "where BPP_Db = '" + Converter.fixString(BPP_Db) + "' and " +
		               "BPP_Part = '" + Converter.fixString(BPP_Part) + "'";
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.BPP_ID = reader.GetInt32("BPP_ID");
	this.BPP_Db = reader.GetString("BPP_Db");
	this.BPP_Part = reader.GetString("BPP_Part");
	this.BPP_Sequence = reader.GetInt32("BPP_Sequence");
	this.BPP_BusPartnerBT = reader.GetString("BPP_BusPartnerBT");
	this.BPP_BusPartPart = reader.GetString("BPP_BusPartPart");
	this.BPP_BusPartnerST = reader.GetString("BPP_BusPartnerST");
	this.BPP_Revision = reader.GetString("BPP_Revision");
	this.BPP_DropShipCust = reader.GetString("BPP_DropShipCust");
	this.BPP_Consignment = reader.GetString("BPP_Consignment");
	this.BPP_BoxPackQty = reader.GetDecimal("BPP_BoxPackQty");
	this.BPP_CasePackQty = reader.GetDecimal("BPP_CasePackQty");
	this.BPP_SkidPackQty = reader.GetDecimal("BPP_SkidPackQty");
	this.BPP_PackUom = reader.GetString("BPP_PackUom");
	this.BPP_CaseCont = reader.GetString("BPP_CaseCont");
	this.BPP_BoxCont = reader.GetString("BPP_BoxCont");
    this.BPP_SkidCont = reader.GetString("BPP_SkidCont");
	this.BPP_UPCCase = reader.GetString("BPP_UPCCase");
	this.BPP_UPCBox = reader.GetString("BPP_UPCBox");
	this.BPP_UPCSkid = reader.GetString("BPP_UPCSkid");
	this.BPP_Manufacturer = reader.GetString("BPP_Manufacturer");
	this.BPP_Alias = reader.GetString("BPP_Alias");
	this.BPP_UPC = reader.GetString("BPP_UPC");
	this.BPP_StartDate = reader.GetDateTime("BPP_StartDate");
	this.BPP_EndDate = reader.GetDateTime("BPP_EndDate");
	this.BPP_SC1 = reader.GetString("BPP_SC1");
	this.BPP_SC2 = reader.GetString("BPP_SC2");
	this.BPP_SC3 = reader.GetString("BPP_SC3");
	this.BPP_SC4 = reader.GetString("BPP_SC4");
	this.BPP_SC5 = reader.GetString("BPP_SC5");
	this.BPP_SC6 = reader.GetString("BPP_SC6");
	this.BPP_Salesperson = reader.GetString("BPP_Salesperson");
	this.BPP_CommPlan = reader.GetString("BPP_CommPlan");
	this.BPP_CommPercent = reader.GetDecimal("BPP_CommPercent");
	this.BPP_CommRate = reader.GetDecimal("BPP_CommRate");
	this.BPP_PackProfile = reader.GetString("BPP_PackProfile");
	this.BPP_WarrantyDays = reader.GetInt32("BPP_WarrantyDays");
	this.BPP_ExpiryDate = reader.GetInt32("BPP_ExpiryDate");
	this.BPP_UnitLFmt = reader.GetString("BPP_UnitLFmt");
	this.BPP_UnitLFmtQty = reader.GetInt32("BPP_UnitLFmtQty");
	this.BPP_BoxLFmt = reader.GetString("BPP_BoxLFmt");
	this.BPP_BoxLFmtQty = reader.GetInt32("BPP_BoxLFmtQty");
	this.BPP_CaseLFmt = reader.GetString("BPP_CaseLFmt");
	this.BPP_CaseLFmtQty = reader.GetInt32("BPP_CaseLFmtQty");
	this.BPP_SkidLFmt = reader.GetString("BPP_SkidLFmt");
	this.BPP_SkidLFmtQty = reader.GetInt32("BPP_SkidLFmtQty");
	this.BPP_Make = reader.GetString("BPP_Make");
	this.BPP_Model = reader.GetString("BPP_Model");
	this.BPP_Brand = reader.GetString("BPP_Brand");
	this.BPP_Color = reader.GetString("BPP_Color");
	this.BPP_Size = reader.GetString("BPP_Size");
	this.BPP_Style = reader.GetString("BPP_Style");
}

public override
void write(){
	string sql = "insert into buspartparts (" + 
		"BPP_Db," +
		"BPP_Part," +
		"BPP_Sequence," +
		"BPP_BusPartnerBT," +
		"BPP_BusPartPart," +
		"BPP_BusPartnerST," +
		"BPP_Revision," +
		"BPP_DropShipCust," +
		"BPP_Consignment," +
		"BPP_BoxPackQty," +
		"BPP_CasePackQty," +
		"BPP_SkidPackQty," +
		"BPP_PackUom," +
		"BPP_BoxCont," +
		"BPP_CaseCont," +
		"BPP_SkidCont," +
		"BPP_UPCBox," +
		"BPP_UPCCase," +
		"BPP_UPCSkid," +
		"BPP_Manufacturer," +
		"BPP_Alias," +
		"BPP_UPC," +
		"BPP_StartDate," +
		"BPP_EndDate," +
		"BPP_SC1," +
		"BPP_SC2," +
		"BPP_SC3," +
		"BPP_SC4," +
		"BPP_SC5," +
		"BPP_SC6," +
		"BPP_Salesperson," +
		"BPP_CommPlan," +
		"BPP_CommPercent," +
		"BPP_CommRate," +
		"BPP_PackProfile," +
		"BPP_WarrantyDays," +
		"BPP_ExpiryDate," +
		"BPP_UnitLFmt," +
		"BPP_UnitLFmtQty," +
		"BPP_BoxLFmt," +
		"BPP_BoxLFmtQty," +
		"BPP_CaseLFmt," +
		"BPP_CaseLFmtQty," +
		"BPP_SkidLFmt," +
		"BPP_SkidLFmtQty," +
		"BPP_Make," +
		"BPP_Model," +
		"BPP_Brand," +
		"BPP_Color," +
		"BPP_Size," +
		"BPP_Style" +

		") values (" + 

		"'" + Converter.fixString(BPP_Db) + "'," +
		"'" + Converter.fixString(BPP_Part) + "'," +
		"" + NumberUtil.toString(BPP_Sequence) + "," +
		"'" + Converter.fixString(BPP_BusPartnerBT) + "'," +
		"'" + Converter.fixString(BPP_BusPartPart) + "'," +
		"'" + Converter.fixString(BPP_BusPartnerST) + "'," +
		"'" + Converter.fixString(BPP_Revision) + "'," +
		"'" + Converter.fixString(BPP_DropShipCust) + "'," +
		"'" + Converter.fixString(BPP_Consignment) + "'," +
		"" + NumberUtil.toString(BPP_BoxPackQty) + "," +
		"" + NumberUtil.toString(BPP_CasePackQty) + "," +
		"" + NumberUtil.toString(BPP_SkidPackQty) + "," +
		"'" + Converter.fixString(BPP_PackUom) + "'," +
		"'" + Converter.fixString(BPP_BoxCont) + "'," +
		"'" + Converter.fixString(BPP_CaseCont) + "'," +
		"'" + Converter.fixString(BPP_SkidCont) + "'," +
		"'" + Converter.fixString(BPP_UPCBox) + "'," +
		"'" + Converter.fixString(BPP_UPCCase) + "'," +
		"'" + Converter.fixString(BPP_UPCSkid) + "'," +
		"'" + Converter.fixString(BPP_Manufacturer) + "'," +
		"'" + Converter.fixString(BPP_Alias) + "'," +
		"'" + Converter.fixString(BPP_UPC) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BPP_StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BPP_EndDate) + "'," +
		"'" + Converter.fixString(BPP_SC1) + "'," +
		"'" + Converter.fixString(BPP_SC2) + "'," +
		"'" + Converter.fixString(BPP_SC3) + "'," +
		"'" + Converter.fixString(BPP_SC4) + "'," +
		"'" + Converter.fixString(BPP_SC5) + "'," +
		"'" + Converter.fixString(BPP_SC6) + "'," +
		"'" + Converter.fixString(BPP_Salesperson) + "'," +
		"'" + Converter.fixString(BPP_CommPlan)+"', " +
		"" + NumberUtil.toString(BPP_CommPercent) + "," +
		"" + NumberUtil.toString(BPP_CommRate) + "," +
		"'" + Converter.fixString(BPP_PackProfile) + "'," +
		"" + NumberUtil.toString(BPP_WarrantyDays) + "," +
		"" + NumberUtil.toString(BPP_ExpiryDate) + "," +
		"'" + Converter.fixString(BPP_UnitLFmt) + "'," +
		"" + NumberUtil.toString(BPP_UnitLFmtQty) + "," +
		"'" + Converter.fixString(BPP_BoxLFmt) + "'," +
		"" + NumberUtil.toString(BPP_BoxLFmtQty) + "," +
		"'" + Converter.fixString(BPP_CaseLFmt) + "'," +
		"" + NumberUtil.toString(BPP_CaseLFmtQty) + "," +
		"'" + Converter.fixString(BPP_SkidLFmt) + "'," +
		"" + NumberUtil.toString(BPP_SkidLFmtQty) + "," +
		"'" + Converter.fixString(BPP_Make) + "'," +
		"'" + Converter.fixString(BPP_Model) + "'," +
		"'" + Converter.fixString(BPP_Brand) + "'," +
		"'" + Converter.fixString(BPP_Color) + "'," +
		"'" + Converter.fixString(BPP_Size) + "'," +
		"'" + Converter.fixString(BPP_Style) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update buspartparts set " +
		"BPP_Db = '" + Converter.fixString(BPP_Db) + "', " +
		"BPP_Part = '" + Converter.fixString(BPP_Part) + "', " +
		"BPP_Sequence = " + NumberUtil.toString(BPP_Sequence) + ", " +
		"BPP_BusPartnerBT = '" + Converter.fixString(BPP_BusPartnerBT) + "', " +
		"BPP_BusPartPart = '" + Converter.fixString(BPP_BusPartPart) + "', " +
		"BPP_BusPartnerST = '" + Converter.fixString(BPP_BusPartnerST) + "', " +
		"BPP_Revision = '" + Converter.fixString(BPP_Revision) + "', " +
		"BPP_DropShipCust = '" + Converter.fixString(BPP_DropShipCust) + "', " +
		"BPP_Consignment = '" + Converter.fixString(BPP_Consignment) + "', " +
		"BPP_BoxPackQty = " + NumberUtil.toString(BPP_BoxPackQty) + ", " +
		"BPP_CasePackQty = " + NumberUtil.toString(BPP_CasePackQty) + ", " +
		"BPP_SkidPackQty = " + NumberUtil.toString(BPP_SkidPackQty) + ", " +
		"BPP_PackUom = '" + Converter.fixString(BPP_PackUom) + "', " +
		"BPP_BoxCont = '" + Converter.fixString(BPP_BoxCont) + "', " +
		"BPP_CaseCont = '" + Converter.fixString(BPP_CaseCont) + "', " +
		"BPP_SkidCont = '" + Converter.fixString(BPP_SkidCont) + "', " +
		"BPP_UPCBox = '" + Converter.fixString(BPP_UPCBox) + "', " +
		"BPP_UPCCase = '" + Converter.fixString(BPP_UPCCase) + "', " +
		"BPP_UPCSkid = '" + Converter.fixString(BPP_UPCSkid) + "', " +
		"BPP_Manufacturer = '" + Converter.fixString(BPP_Manufacturer) + "', " +
		"BPP_Alias = '" + Converter.fixString(BPP_Alias) + "', " +
		"BPP_UPC = '" + Converter.fixString(BPP_UPC) + "', " +
		"BPP_StartDate = '" + DateUtil.getCompleteDateRepresentation(BPP_StartDate) + "', " +
		"BPP_EndDate = '" + DateUtil.getCompleteDateRepresentation(BPP_EndDate) + "', " +
		"BPP_SC1 = '" + Converter.fixString(BPP_SC1) + "', " +
		"BPP_SC2 = '" + Converter.fixString(BPP_SC2) + "', " +
		"BPP_SC3 = '" + Converter.fixString(BPP_SC3) + "', " +
		"BPP_SC4 = '" + Converter.fixString(BPP_SC4) + "', " +
		"BPP_SC5 = '" + Converter.fixString(BPP_SC5) + "', " +
		"BPP_SC6 = '" + Converter.fixString(BPP_SC6) + "', " +
		"BPP_Salesperson = '" + Converter.fixString(BPP_Salesperson) + "', " +
		"BPP_CommPlan = '" + Converter.fixString(BPP_CommPlan) +"', " +
		"BPP_CommPercent = " + NumberUtil.toString(BPP_CommPercent) + ", " +
		"BPP_CommRate = " + NumberUtil.toString(BPP_CommRate) + ", " +
		"BPP_PackProfile = '" + Converter.fixString(BPP_PackProfile) + "', " +
		"BPP_WarrantyDays = " + NumberUtil.toString(BPP_WarrantyDays) + ", " +
		"BPP_ExpiryDate = " + NumberUtil.toString(BPP_ExpiryDate) + ", " +
		"BPP_UnitLFmt = '" + Converter.fixString(BPP_UnitLFmt) + "', " +
		"BPP_UnitLFmtQty = " + NumberUtil.toString(BPP_UnitLFmtQty) + ", " +
		"BPP_BoxLFmt = '" + Converter.fixString(BPP_BoxLFmt) + "', " +
		"BPP_BoxLFmtQty = " + NumberUtil.toString(BPP_BoxLFmtQty) + ", " +
		"BPP_CaseLFmt = '" + Converter.fixString(BPP_CaseLFmt) + "', " +
		"BPP_CaseLFmtQty = " + NumberUtil.toString(BPP_CaseLFmtQty) + ", " +
		"BPP_SkidLFmt = '" + Converter.fixString(BPP_SkidLFmt) + "', " +
		"BPP_SkidLFmtQty = " + NumberUtil.toString(BPP_SkidLFmtQty) + ", " +
		"BPP_Make = '" + Converter.fixString(BPP_Make) + "', " +
		"BPP_Model = '" + Converter.fixString(BPP_Model) + "', " +
		"BPP_Brand = '" + Converter.fixString(BPP_Brand) + "', " +
		"BPP_Color = '" + Converter.fixString(BPP_Color) + "', " +
		"BPP_Size = '" + Converter.fixString(BPP_Size) + "', " +
		"BPP_Style = '" + Converter.fixString(BPP_Style) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from buspartparts where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"BPP_Db = '" + Converter.fixString(BPP_Db) + "' and " +
		"BPP_Part = '" + Converter.fixString(BPP_Part) + "' and " +
		"BPP_Sequence = " + NumberUtil.toString(BPP_Sequence) + " and " +
		"BPP_BusPartnerBT = '" + Converter.fixString(BPP_BusPartnerBT) + "' and " +
		"BPP_BusPartPart = '" + Converter.fixString(BPP_BusPartPart) + "' and " +
		"BPP_BusPartnerST = '" + Converter.fixString(BPP_BusPartnerST) + "' and " +
		"BPP_Revision = '" + Converter.fixString(BPP_Revision) +"'";
		
	return sqlWhere;
}

public
void setBPP_ID(int BPP_ID){
	this.BPP_ID = BPP_ID;
}

public
void setBPP_Db(string BPP_Db){
	this.BPP_Db = BPP_Db;
}

public
void setBPP_Part(string BPP_Part){
	this.BPP_Part = BPP_Part;
}

public
void setBPP_Sequence(int BPP_Sequence){
	this.BPP_Sequence = BPP_Sequence;
}

public
void setBPP_BusPartnerBT(string BPP_BusPartnerBT){
	this.BPP_BusPartnerBT = BPP_BusPartnerBT;
}

public
void setBPP_BusPartnerST(string BPP_BusPartnerST){
	this.BPP_BusPartnerST = BPP_BusPartnerST;
}

public
void setBPP_BusPartPart(string BPP_BusPartPart){
	this.BPP_BusPartPart = BPP_BusPartPart;
}

public
void setBPP_Revision(string BPP_Revision){
	this.BPP_Revision = BPP_Revision;
}

public
void setBPP_DropShipCust(string BPP_DropShipCust){
	this.BPP_DropShipCust = BPP_DropShipCust;
}

public
void setBPP_Consignment(string BPP_Consignment){
	this.BPP_Consignment = BPP_Consignment;
}

public
void setBPP_BoxPackQty(decimal BPP_BoxPackQty){
	this.BPP_BoxPackQty = BPP_BoxPackQty;
}

public
void setBPP_CasePackQty(decimal BPP_CasePackQty){
	this.BPP_CasePackQty = BPP_CasePackQty;
}

public
void setBPP_SkidPackQty(decimal BPP_SkidPackQty){
	this.BPP_SkidPackQty = BPP_SkidPackQty;
}

public
void setBPP_PackUom(string BPP_PackUom){
	this.BPP_PackUom = BPP_PackUom;
}

public
void setBPP_BoxCont(string BPP_BoxCont){
	this.BPP_BoxCont = BPP_BoxCont;
}

public
void setBPP_CaseCont(string BPP_CaseCont){
	this.BPP_CaseCont = BPP_CaseCont;
}

public
void setBPP_SkidCont(string BPP_SkidCont){
	this.BPP_SkidCont = BPP_SkidCont;
}

public
void setBPP_UPCCase(string BPP_UPCCase){
	this.BPP_UPCCase = BPP_UPCCase;
}

public
void setBPP_UPCBox(string BPP_UPCBox){
	this.BPP_UPCBox = BPP_UPCBox;
}

public
void setBPP_UPCSkid(string BPP_UPCSkid){
	this.BPP_UPCSkid = BPP_UPCSkid;
}

public
void setBPP_Manufacturer(string BPP_Manufacturer){
	this.BPP_Manufacturer = BPP_Manufacturer;
}

public
void setBPP_Alias(string BPP_Alias){
	this.BPP_Alias = BPP_Alias;
}

public
void setBPP_UPC(string BPP_UPC){
	this.BPP_UPC = BPP_UPC;
}

public
void setBPP_StartDate(DateTime BPP_StartDate){
	this.BPP_StartDate = BPP_StartDate;
}

public
void setBPP_EndDate(DateTime BPP_EndDate){
	this.BPP_EndDate = BPP_EndDate;
}

public
void setBPP_SC1(string BPP_SC1){
	this.BPP_SC1 = BPP_SC1;
}

public
void setBPP_SC2(string BPP_SC2){
	this.BPP_SC2 = BPP_SC2;
}

public
void setBPP_SC3(string BPP_SC3){
	this.BPP_SC3 = BPP_SC3;
}

public
void setBPP_SC4(string BPP_SC4){
	this.BPP_SC4 = BPP_SC4;
}

public
void setBPP_SC5(string BPP_SC5){
	this.BPP_SC5 = BPP_SC5;
}

public
void setBPP_SC6(string BPP_SC6){
	this.BPP_SC6 = BPP_SC6;
}

public
void setBPP_Salesperson(string BPP_Salesperson){
	this.BPP_Salesperson = BPP_Salesperson;
}

public
void setBPP_CommPlan(string BPP_CommPlan){
	this.BPP_CommPlan = BPP_CommPlan;
}
public
void setBPP_CommPercent(decimal BPP_CommPercent){
	this.BPP_CommPercent = BPP_CommPercent;
}

public
void setBPP_CommRate(decimal BPP_CommRate){
	this.BPP_CommRate = BPP_CommRate;
}

public
void setBPP_PackProfile(string BPP_PackProfile){
	this.BPP_PackProfile = BPP_PackProfile;
}

public
void setBPP_WarrantyDays(int BPP_WarrantyDays){
	this.BPP_WarrantyDays = BPP_WarrantyDays;
}

public
void setBPP_ExpiryDate(int BPP_ExpiryDate){
	this.BPP_ExpiryDate = BPP_ExpiryDate;
}

public
void setBPP_UnitLFmt(string BPP_UnitLFmt){
	this.BPP_UnitLFmt = BPP_UnitLFmt;
}

public
void setBPP_UnitLFmtQty(int BPP_UnitLFmtQty){
	this.BPP_UnitLFmtQty = BPP_UnitLFmtQty;
}

public
void setBPP_BoxLFmt(string BPP_BoxLFmt){
	this.BPP_BoxLFmt = BPP_BoxLFmt;
}

public
void setBPP_BoxLFmtQty(int BPP_BoxLFmtQty){
	this.BPP_BoxLFmtQty = BPP_BoxLFmtQty;
}

public
void setBPP_CaseLFmt(string BPP_CaseLFmt){
	this.BPP_CaseLFmt = BPP_CaseLFmt;
}

public
void setBPP_CaseLFmtQty(int BPP_CaseLFmtQty){
	this.BPP_CaseLFmtQty = BPP_CaseLFmtQty;
}

public
void setBPP_SkidLFmt(string BPP_SkidLFmt){
	this.BPP_SkidLFmt = BPP_SkidLFmt;
}

public
void setBPP_SkidLFmtQty(int BPP_SkidLFmtQty){
	this.BPP_SkidLFmtQty = BPP_SkidLFmtQty;
}

public
void setBPP_Make(string BPP_Make){
	this.BPP_Make = BPP_Make;
}

public
void setBPP_Model(string BPP_Model){
	this.BPP_Model = BPP_Model;
}

public
void setBPP_Brand(string BPP_Brand){
	this.BPP_Brand = BPP_Brand;
}

public
void setBPP_Color(string BPP_Color){
	this.BPP_Color = BPP_Color;
}

public
void setBPP_Size(string BPP_Size){
	this.BPP_Size = BPP_Size;
}

public
void setBPP_Style(string BPP_Style){
	this.BPP_Style = BPP_Style;
}

public
int getBPP_ID(){
	return BPP_ID;
}

public
string getBPP_Db(){
	return BPP_Db;
}

public
string getBPP_Part(){
	return BPP_Part;
}

public
int getBPP_Sequence(){
	return BPP_Sequence;
}

public
string getBPP_BusPartnerBT(){
	return BPP_BusPartnerBT;
}

public
string getBPP_BusPartnerST(){
	return BPP_BusPartnerST;
}

public
string getBPP_BusPartPart(){
	return BPP_BusPartPart;
}

public
string getBPP_Revision(){
	return BPP_Revision;
}

public
string getBPP_DropShipCust(){
	return BPP_DropShipCust;
}

public
string getBPP_Consignment(){
	return BPP_Consignment;
}

public
decimal getBPP_BoxPackQty(){
	return BPP_BoxPackQty;
}

public
decimal getBPP_CasePackQty(){
	return BPP_CasePackQty;
}

public
decimal getBPP_SkidPackQty(){
	return BPP_SkidPackQty;
}

public
string getBPP_PackUom(){
	return BPP_PackUom;
}

public
string getBPP_BoxCont(){
	return BPP_BoxCont;
}

public
string getBPP_CaseCont(){
	return BPP_CaseCont;
}

public
string getBPP_SkidCont(){
	return BPP_SkidCont;
}

public
string getBPP_UPCCase(){
	return BPP_UPCCase;
}

public
string getBPP_UPCBox(){
	return BPP_UPCBox;
}

public
string getBPP_UPCSkid(){
	return BPP_UPCSkid;
}

public
string getBPP_Manufacturer(){
	return BPP_Manufacturer;
}

public
string getBPP_Alias(){
	return BPP_Alias;
}

public
string getBPP_UPC(){
	return BPP_UPC;
}

public
DateTime getBPP_StartDate(){
	return BPP_StartDate;
}

public
DateTime getBPP_EndDate(){
	return BPP_EndDate;
}

public
string getBPP_SC1(){
	return BPP_SC1;
}

public
string getBPP_SC2(){
	return BPP_SC2;
}

public
string getBPP_SC3(){
	return BPP_SC3;
}

public
string getBPP_SC4(){
	return BPP_SC4;
}

public
string getBPP_SC5(){
	return BPP_SC5;
}

public
string getBPP_SC6(){
	return BPP_SC6;
}

public
string getBPP_Salesperson(){
	return BPP_Salesperson;
}

public
string getBPP_CommPlan(){
	return BPP_CommPlan;
}

public
decimal getBPP_CommPercent(){
	return BPP_CommPercent;
}

public
decimal getBPP_CommRate(){
	return BPP_CommRate;
}

public
string getBPP_PackProfile(){
	return BPP_PackProfile;
}

public
int getBPP_WarrantyDays(){
	return BPP_WarrantyDays;
}

public
int getBPP_ExpiryDate(){
	return BPP_ExpiryDate;
}

public
string getBPP_UnitLFmt(){
	return BPP_UnitLFmt;
}

public
int getBPP_UnitLFmtQty(){
	return BPP_UnitLFmtQty;
}

public
string getBPP_BoxLFmt(){
	return BPP_BoxLFmt;
}

public
int getBPP_BoxLFmtQty(){
	return BPP_BoxLFmtQty;
}

public
string getBPP_CaseLFmt(){
	return BPP_CaseLFmt;
}

public
int getBPP_CaseLFmtQty(){
	return BPP_CaseLFmtQty;
}

public
string getBPP_SkidLFmt(){
	return BPP_SkidLFmt;
}

public
int getBPP_SkidLFmtQty(){
	return BPP_SkidLFmtQty;
}

public
string getBPP_Make(){
	return BPP_Make;
}

public
string getBPP_Model(){
	return BPP_Model;
}

public
string getBPP_Brand(){
	return BPP_Brand;
}

public
string getBPP_Color(){
	return BPP_Color;
}

public
string getBPP_Size(){
	return BPP_Size;
}

public
string getBPP_Style(){
	return BPP_Style;
}

} // class

} // package