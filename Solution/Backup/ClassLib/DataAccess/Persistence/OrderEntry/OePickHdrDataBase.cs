/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $  Claudia Melo
*   $Date: 2006-12-21 19:56:25 $  6/4/2005
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePickHdrDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OePickHdrDataBase.cs,v $
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
class OePickHdrDataBase : GenericDataBaseElement {

private int IPH_Id;
private string IPH_Db;
private string IPH_PickHdr;
private int IPH_Pick;
private int IPH_Order;
private int IPH_Item;
private string IPH_Release;
private int IPH_User;
private DateTime IPH_DtTmFinished;
private string IPH_HardAllocate;
private string IPH_WO;
private int IPH_WOSeq;
private string IPH_MaterialPart;
private int IPH_MaterialSeq;
private int IPH_MaterialLineNum;
private int IPH_WhTransferNum;



public
OePickHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oepickhdr where " + getWhereCondition();

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
	string sql = "select * from oepickhdr where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.IPH_Id = reader.GetInt32("IPH_Id");
	this.IPH_Db = reader.GetString("IPH_Db");
	this.IPH_PickHdr = reader.GetString("IPH_PickHdr");
	this.IPH_Pick = reader.GetInt32("IPH_Pick");
	this.IPH_Order = reader.GetInt32("IPH_Order");
	this.IPH_Item = reader.GetInt32("IPH_Item");
	this.IPH_Release = reader.GetString("IPH_Release");
	this.IPH_User = reader.GetInt32("IPH_User");
	this.IPH_DtTmFinished = reader.GetDateTime("IPH_DtTmFinished");
    this.IPH_HardAllocate = reader.GetString("IPH_HardAllocate");
    this.IPH_WO = reader.GetString("IPH_WO");
    this.IPH_WOSeq = reader.GetInt32("IPH_WOSeq");
    this.IPH_MaterialPart = reader.GetString("IPH_MaterialPart");
    this.IPH_MaterialSeq = reader.GetInt32("IPH_MaterialSeq");
    this.IPH_MaterialLineNum = reader.GetInt32("IPH_MaterialLineNum");
    this.IPH_WhTransferNum = reader.GetInt32("IPH_WhTransferNum");

}

public override
void write(){
	string sql = "insert into oepickhdr (" + 
		"IPH_Db," +
		"IPH_PickHdr," +
		"IPH_Pick," +
		"IPH_Order," +
		"IPH_Item," +
		"IPH_Release," +
		"IPH_User," +
		"IPH_DtTmFinished," +
        "IPH_HardAllocate," +
        "IPH_WO," +
        "IPH_WOSeq," +
        "IPH_MaterialPart," +
        "IPH_MaterialSeq," +
        "IPH_MaterialLineNum," +
        "IPH_WhTransferNum" +
		") values (" + 
		"" + NumberUtil.toString(IPH_Id) + "," +
		"'" + Converter.fixString(IPH_Db) + "'," +
		"'" + Converter.fixString(IPH_PickHdr) + "'," +
		"" + NumberUtil.toString(IPH_Pick) + "," +
		"" + NumberUtil.toString(IPH_Order) + "," +
		"" + NumberUtil.toString(IPH_Item) + "," +
		"'" + Converter.fixString(IPH_Release) + "'," +
		"" + NumberUtil.toString(IPH_User) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(IPH_DtTmFinished) + "', " +
        "'" + Converter.fixString(IPH_HardAllocate) +"', " +
        "'" + Converter.fixString(IPH_WO) +"', " +
        "" + NumberUtil.toString(IPH_WOSeq) +", " +
        "'" + Converter.fixString(IPH_MaterialPart) +"', " +
        "" + NumberUtil.toString(IPH_MaterialSeq) +", " +
        "" + NumberUtil.toString(IPH_MaterialLineNum) +", " +
        "" + NumberUtil.toString(IPH_WhTransferNum) +")";
	write(sql);
}

public override
void update(){
	string sql = "update oepickhdr set " +
		"IPH_Db = '" + Converter.fixString(IPH_Db) + "', " +
		"IPH_PickHdr = '" + Converter.fixString(IPH_PickHdr) + "', " +
		"IPH_Pick = " + NumberUtil.toString(IPH_Pick) + ", " +
		"IPH_Order = " + NumberUtil.toString(IPH_Order) + ", " +
		"IPH_Item = " + NumberUtil.toString(IPH_Item) + ", " +
		"IPH_Release = '" + Converter.fixString(IPH_Release) + "', " +
		"IPH_User = " + NumberUtil.toString(IPH_User) + ", " +
		"IPH_DtTmFinished = '" + DateUtil.getCompleteDateRepresentation(IPH_DtTmFinished) + "', " +
        "IPH_HardAllocate = '" + Converter.fixString(IPH_HardAllocate) +"', " +
        "IPH_WO = '" + Converter.fixString(IPH_WO) +"', " +
        "IPH_WOSeq = " + NumberUtil.toString(IPH_WOSeq) +", " +
        "IPH_MaterialPart = '" + Converter.fixString(IPH_MaterialPart) +"', " +
        "IPH_MaterialSeq = " + NumberUtil.toString(IPH_MaterialSeq) +", " +
        "IPH_MaterialLineNum = " + NumberUtil.toString(IPH_MaterialLineNum) +", " +
        "IPH_WhTransferNum = " + NumberUtil.toString(IPH_WhTransferNum) +" " +
		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepickhdr where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"IPH_Id = " + NumberUtil.toString(IPH_Id) + "";
	return sqlWhere;
}

public
void setIPH_Id(int IPH_Id){
	this.IPH_Id = IPH_Id;
}

public
void setIPH_Db(string IPH_Db){
	this.IPH_Db = IPH_Db;
}

public
void setIPH_PickHdr(string IPH_PickHdr){
	this.IPH_PickHdr = IPH_PickHdr;
}

public
void setIPH_Pick(int IPH_Pick){
	this.IPH_Pick = IPH_Pick;
}

public
void setIPH_Order(int IPH_Order){
	this.IPH_Order = IPH_Order;
}

public
void setIPH_Item(int IPH_Item){
	this.IPH_Item = IPH_Item;
}

public
void setIPH_Release(string IPH_Release){
	this.IPH_Release = IPH_Release;
}

public
void setIPH_User(int IPH_User){
	this.IPH_User = IPH_User;
}

public
void setIPH_DtTmFinished(DateTime IPH_DtTmFinished){
	this.IPH_DtTmFinished = IPH_DtTmFinished;
}

public void setIPH_HardAllocate (string IPH_HardAllocate){
    this.IPH_HardAllocate = IPH_HardAllocate;
}

public void setIPH_WO (string IPH_WO){
    this.IPH_WO = IPH_WO;
}

public void setIPH_WOSeq (int IPH_WOSeq){
    this.IPH_WOSeq = IPH_WOSeq;
}

public void setIPH_MaterialPart (string IPH_MaterialPart){
    this.IPH_MaterialPart = IPH_MaterialPart;
}

public void setIPH_MaterialSeq (int IPH_MaterialSeq){
    this.IPH_MaterialSeq = IPH_MaterialSeq;
}

public void setIPH_MaterialLineNum (int IPH_MaterialLineNum){
    this.IPH_MaterialLineNum = IPH_MaterialLineNum;
}

public void setIPH_WhTransferNum (int IPH_WhTransferNum){
    this.IPH_WhTransferNum = IPH_WhTransferNum;
}



public
int getIPH_Id(){
	return IPH_Id;
}

public
string getIPH_Db(){
	return IPH_Db;
}

public
string getIPH_PickHdr(){
	return IPH_PickHdr;
}

public
int getIPH_Pick(){
	return IPH_Pick;
}

public
int getIPH_Order(){
	return IPH_Order;
}

public
int getIPH_Item(){
	return IPH_Item;
}

public
string getIPH_Release(){
	return IPH_Release;
}

public
int getIPH_User(){
	return IPH_User;
}

public
DateTime getIPH_DtTmFinished(){
	return IPH_DtTmFinished;
}


public string getIPH_HardAllocate(){
    return IPH_HardAllocate;
}

public string getIPH_WO(){
    return IPH_WO;
}

public int getIPH_WOSeq(){
    return IPH_WOSeq;
}

public string getIPH_MaterialPart(){
    return IPH_MaterialPart;
}

public int getIPH_MaterialSeq(){
    return IPH_MaterialSeq;
}

public int getIPH_MaterialLineNum(){
    return IPH_MaterialLineNum;
}

public int getIPH_WhTransferNum(){
    return IPH_WhTransferNum;
}


} // class
} // package