/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $  Claudia Melo
*   $Date: 2006-12-21 19:56:25 $  6/4/2005
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePickDtlDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OePickDtlDataBase.cs,v $
*   Revision 1.4  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/04/13 00:43:11  cmelo
*   *** empty log message ***
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
class OePickDtlDataBase : GenericDataBaseElement {

private int IPD_ID;
private string IPD_Db;
private int IPD_Company;
private string IPD_Plant;
private string IPD_StockLoc;
private string IPD_Bin;
private string IPD_Slot;
private string IPD_Part;
private int IPD_Sequence;
private string IPD_Lot;
private string IPD_WO;
private decimal IPD_Qty;
private DateTime IPD_TimePicked;
private string IPD_PickedBy;
private int IPD_PO;
private int IPD_POItem;
private string IPD_POItemRel;



public
OePickDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oepickdtl where " + getWhereCondition();

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
	string sql = "select * from oepickdtl where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.IPD_ID = reader.GetInt32("IPD_ID");
	this.IPD_Db = reader.GetString("IPD_Db");
	this.IPD_Company = reader.GetInt32("IPD_Company");
	this.IPD_Plant = reader.GetString("IPD_Plant");
	this.IPD_StockLoc = reader.GetString("IPD_StockLoc");
	this.IPD_Bin = reader.GetString("IPD_Bin");
	this.IPD_Slot = reader.GetString("IPD_Slot");
	this.IPD_Part = reader.GetString("IPD_Part");
	this.IPD_Sequence = reader.GetInt32("IPD_Sequence");
	this.IPD_Lot = reader.GetString("IPD_Lot");
	this.IPD_WO = reader.GetString("IPD_WO");
	this.IPD_Qty = reader.GetDecimal("IPD_Qty");
	this.IPD_TimePicked = reader.GetDateTime("IPD_TimePicked");
	this.IPD_PickedBy = reader.GetString("IPD_PickedBy");
    this.IPD_PO = reader.GetInt32("IPD_PO");
    this.IPD_POItem = reader.GetInt32("IPD_POItem");
    this.IPD_POItemRel = reader.GetString("IPD_POItemRel");
}

public override
void write(){
	string sql = "insert into oepickdtl (" + 
		"IPD_Db," +
		"IPD_Company," +
		"IPD_Plant," +
		"IPD_StockLoc," +
		"IPD_Bin," +
		"IPD_Slot," +
		"IPD_Part," +
		"IPD_Sequence," +
		"IPD_Lot," +
		"IPD_WO," +
		"IPD_Qty," +
		"IPD_TimePicked," +
		"IPD_PickedBy," +
        "IPD_PO," +
        "IPD_POItem," +
        "IPD_POItemRel" +		
		") values (" + 
		"'" + Converter.fixString(IPD_Db) + "'," +
		"" + NumberUtil.toString(IPD_Company) + "," +
		"'" + Converter.fixString(IPD_Plant) + "'," +
		"'" + Converter.fixString(IPD_StockLoc) + "'," +
		"'" + Converter.fixString(IPD_Bin) + "'," +
		"'" + Converter.fixString(IPD_Slot) + "'," +
		"'" + Converter.fixString(IPD_Part) + "'," +
		"" + NumberUtil.toString(IPD_Sequence) + "," +
		"'" + Converter.fixString(IPD_Lot) + "'," +
		"'" + Converter.fixString(IPD_WO) + "'," +
		"" + NumberUtil.toString(IPD_Qty) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(IPD_TimePicked) + "'," +
		"'" + Converter.fixString(IPD_PickedBy) + "', " +
        "" + NumberUtil.toString(IPD_PO) +", " +
        "" + NumberUtil.toString(IPD_POItem) +", " +
        "'" + Converter.fixString(IPD_POItemRel) +"')";
	write(sql);
}

public override
void update(){
	string sql = "update oepickdtl set " +
		"IPD_Db = '" + Converter.fixString(IPD_Db) + "', " +
		"IPD_Company = " + NumberUtil.toString(IPD_Company) + ", " +
		"IPD_Plant = '" + Converter.fixString(IPD_Plant) + "', " +
		"IPD_StockLoc = '" + Converter.fixString(IPD_StockLoc) + "', " +
		"IPD_Bin = '" + Converter.fixString(IPD_Bin) + "', " +
		"IPD_Slot = '" + Converter.fixString(IPD_Slot) + "', " +
		"IPD_Part = '" + Converter.fixString(IPD_Part) + "', " +
		"IPD_Sequence = " + NumberUtil.toString(IPD_Sequence) + ", " +
		"IPD_Lot = '" + Converter.fixString(IPD_Lot) + "', " +
		"IPD_WO = '" + Converter.fixString(IPD_WO) + "', " +
		"IPD_Qty = " + NumberUtil.toString(IPD_Qty) + ", " +
		"IPD_TimePicked = '" + DateUtil.getCompleteDateRepresentation(IPD_TimePicked) + "', " +
		"IPD_PickedBy = '" + Converter.fixString(IPD_PickedBy) + "', " +
        "IPD_PO = " + NumberUtil.toString(IPD_PO) +", " +
        "IPD_POItem = " + NumberUtil.toString(IPD_POItem) +", " +
        "IPD_POItemRel = '" + Converter.fixString(IPD_POItemRel) +"')"+ 
		
		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepickdtl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"IPD_ID = " + NumberUtil.toString(IPD_ID) + "";
	return sqlWhere;
}

public
void setIPD_ID(int IPD_ID){
	this.IPD_ID = IPD_ID;
}

public
void setIPD_Db(string IPD_Db){
	this.IPD_Db = IPD_Db;
}

public
void setIPD_Company(int IPD_Company){
	this.IPD_Company = IPD_Company;
}

public
void setIPD_Plant(string IPD_Plant){
	this.IPD_Plant = IPD_Plant;
}

public
void setIPD_StockLoc(string IPD_StockLoc){
	this.IPD_StockLoc = IPD_StockLoc;
}

public
void setIPD_Bin(string IPD_Bin){
	this.IPD_Bin = IPD_Bin;
}

public
void setIPD_Slot(string IPD_Slot){
	this.IPD_Slot = IPD_Slot;
}

public
void setIPD_Part(string IPD_Part){
	this.IPD_Part = IPD_Part;
}

public
void setIPD_Sequence(int IPD_Sequence){
	this.IPD_Sequence = IPD_Sequence;
}

public
void setIPD_Lot(string IPD_Lot){
	this.IPD_Lot = IPD_Lot;
}

public
void setIPD_WO(string IPD_WO){
	this.IPD_WO = IPD_WO;
}

public
void setIPD_Qty(decimal IPD_Qty){
	this.IPD_Qty = IPD_Qty;
}

public
void setIPD_TimePicked(DateTime IPD_TimePicked){
	this.IPD_TimePicked = IPD_TimePicked;
}

public
void setIPD_PickedBy(string IPD_PickedBy){
	this.IPD_PickedBy = IPD_PickedBy;
}

public void setIPD_PO (int IPD_PO){
    this.IPD_PO = IPD_PO;
}

public void setIPD_POItem (int IPD_POItem){
    this.IPD_POItem = IPD_POItem;
}

public void setIPD_POItemRel (string IPD_POItemRel){
    this.IPD_POItemRel = IPD_POItemRel;
}

 
public
int getIPD_ID(){
	return IPD_ID;
}

public
string getIPD_Db(){
	return IPD_Db;
}

public
int getIPD_Company(){
	return IPD_Company;
}

public
string getIPD_Plant(){
	return IPD_Plant;
}

public
string getIPD_StockLoc(){
	return IPD_StockLoc;
}

public
string getIPD_Bin(){
	return IPD_Bin;
}

public
string getIPD_Slot(){
	return IPD_Slot;
}

public
string getIPD_Part(){
	return IPD_Part;
}

public
int getIPD_Sequence(){
	return IPD_Sequence;
}

public
string getIPD_Lot(){
	return IPD_Lot;
}

public
string getIPD_WO(){
	return IPD_WO;
}

public
decimal getIPD_Qty(){
	return IPD_Qty;
}

public
DateTime getIPD_TimePicked(){
	return IPD_TimePicked;
}

public
string getIPD_PickedBy(){
	return IPD_PickedBy;
}

public int getIPD_PO(){
    return IPD_PO;
}

public int getIPD_POItem(){
    return IPD_POItem;
}

public string getIPD_POItemRel(){
    return IPD_POItemRel;
}


} // class

} // package