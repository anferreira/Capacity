using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class TPPartCrossRefDataBase : GenericDataBaseElement{

private int TPP_ID;
private int TPP_Key;
private string TPP_Db;
private string TPP_Tpartner;
private string TPP_TpartnerLoc;
private string TPP_DockKey;
private string TPP_CustPartID;
private string TPP_ModelYrKey;
private string TPP_BillToCust;
private string TPP_ShipToCust;
private string TPP_ProdID;
private int TPP_OrderNum;
private int TPP_OrderNumItem;	
private string TPP_PO;
private DateTime TPP_PODate;
private string TPP_DockCode;
private string TPP_Revision;
private DateTime TPP_RevDate;
private string TPP_Expeditor;
private string TPP_ExpeditorPhone;
private string TPP_Plant;
private string TPP_Line;
private string TPP_Drop;		
private string TPP_DelforReleaseNum;
private DateTime TPP_CurrentDelforDate;
private DateTime TPP_LastRecDate;
private int TPP_LastRecQty;
private int TPP_LastRecCum;
private int TPP_CurrentCum;
private int TPP_PriorCum;
private int TPP_FabAuthor;
private string TPP_FabCumDelfor;
private DateTime TPP_FabCumDelforDate;
private int TPP_MatAuthCum;
private string TPP_MatAuthDelfor;
private DateTime TPP_MatAuthDate;
private string TPP_CurrentDeljit;
private DateTime TPP_CurrDeljitDate;
private string TPP_Linked;


public TPPartCrossRefDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
    this.TPP_ID = reader.GetInt32("TPP_ID");
    this.TPP_Key = reader.GetInt32("TPP_Key");
    this.TPP_Db = reader.GetString("TPP_Db");
    this.TPP_Tpartner = reader.GetString("TPP_Tpartner");
    this.TPP_TpartnerLoc = reader.GetString("TPP_TpartnerLoc");
    this.TPP_DockKey = reader.GetString("TPP_DockKey");
    this.TPP_CustPartID = reader.GetString("TPP_CustPartID");
    this.TPP_ModelYrKey = reader.GetString("TPP_ModelYrKey");
    this.TPP_BillToCust = reader.GetString("TPP_BillToCust");
    this.TPP_ShipToCust = reader.GetString("TPP_ShipToCust");
    this.TPP_ProdID = reader.GetString("TPP_ProdID");
    this.TPP_OrderNum = reader.GetInt32("TPP_OrderNum");
    this.TPP_OrderNumItem = reader.GetInt32("TPP_OrderNumItem");
    this.TPP_PO = reader.GetString("TPP_PO");
    this.TPP_PODate = reader.GetDateTime("TPP_PODate");
    this.TPP_DockCode = reader.GetString("TPP_DockCode");
    this.TPP_Revision = reader.GetString("TPP_Revision");
    this.TPP_RevDate = reader.GetDateTime("TPP_RevDate");
    this.TPP_Expeditor = reader.GetString("TPP_Expeditor");
    this.TPP_ExpeditorPhone = reader.GetString("TPP_ExpeditorPhone");
    this.TPP_Plant = reader.GetString("TPP_Plant");
    this.TPP_Line = reader.GetString("TPP_Line");
    this.TPP_Drop= reader.GetString("TPP_Drop");
    this.TPP_DelforReleaseNum = reader.GetString("TPP_DelforReleaseNum");
    this.TPP_CurrentDelforDate = reader.GetDateTime("TPP_CurrentDelforDate");
    this.TPP_LastRecDate = reader.GetDateTime("TPP_LastRecDate");
    this.TPP_LastRecQty = reader.GetInt32("TPP_LastRecQty");
    this.TPP_LastRecCum = reader.GetInt32("TPP_LastRecCum");
    this.TPP_CurrentCum = reader.GetInt32("TPP_CurrentCum");
    this.TPP_PriorCum = reader.GetInt32("TPP_PriorCum");
    this.TPP_FabAuthor = reader.GetInt32("TPP_FabAuthor");
    this.TPP_FabCumDelfor = reader.GetString("TPP_FabCumDelfor");
    this.TPP_FabCumDelforDate = reader.GetDateTime("TPP_FabCumDelforDate");
    this.TPP_MatAuthCum = reader.GetInt32("TPP_MatAuthCum");
    this.TPP_MatAuthDelfor = reader.GetString("TPP_MatAuthDelfor");
    this.TPP_MatAuthDate = reader.GetDateTime("TPP_MatAuthDate");
    this.TPP_CurrentDeljit = reader.GetString("TPP_CurrentDeljit");
    this.TPP_CurrDeljitDate = reader.GetDateTime("TPP_CurrDeljitDate");
    this.TPP_Linked = reader.GetString("TPP_Linked");

}

public override 
void write(){
	try{
		string sql = "insert into tppartcrossref (TPP_Key,TPP_Db,TPP_Tpartner,TPP_TpartnerLoc,TPP_DockKey," +
		                                        "TPP_CustPartID,TPP_ModelYrKey,TPP_BillToCust,TPP_ShipToCust," +
		                                        "TPP_ProdID,TPP_OrderNum,TPP_OrderNumItem,TPP_PO,TPP_PODate," +
		                                        "TPP_DockCode,TPP_Revision,TPP_RevDate,TPP_Expeditor," +
		                                        "TPP_ExpeditorPhone,TPP_Plant,TPP_Line,TPP_Drop,TPP_DelforReleaseNum," +
		                                        "TPP_CurrentDelforDate,TPP_LastRecDate,TPP_LastRecQty,TPP_LastRecCum," +
		                                        "TPP_CurrentCum,TPP_PriorCum,TPP_FabAuthor,TPP_FabCumDelfor," +
		                                        "TPP_FabCumDelforDate,TPP_MatAuthCum,TPP_MatAuthDelfor,TPP_MatAuthDate," +
		                                        "TPP_CurrentDeljit,TPP_CurrDeljitDate,TPP_Linked )" +
                        "values (" +
                        NumberUtil.toString(TPP_Key) +", '" +
                        Converter.fixString(TPP_Db) +"', '" +
                        Converter.fixString(TPP_Tpartner) +"', '" +
                        Converter.fixString(TPP_TpartnerLoc) +"', '" +
                        Converter.fixString(TPP_DockKey) +"', '" +
                        Converter.fixString(TPP_CustPartID) +"', '" +
                        Converter.fixString(TPP_ModelYrKey) +"', '" +
                        Converter.fixString(TPP_BillToCust) +"', '" +
                        Converter.fixString(TPP_ShipToCust) +"', '" +
                        Converter.fixString(TPP_ProdID) +"', " +
                        NumberUtil.toString(TPP_OrderNum) +", " +
                        NumberUtil.toString(TPP_OrderNumItem) +", '" +	
                        Converter.fixString(TPP_PO) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_PODate) +"', '" +
                        Converter.fixString(TPP_DockCode) +"', '" +
                        Converter.fixString(TPP_Revision) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_RevDate) +"', '" +
                        Converter.fixString(TPP_Expeditor) +"', '" +
                        Converter.fixString(TPP_ExpeditorPhone) +"', '" +
                        Converter.fixString(TPP_Plant) +"', '" +
                        Converter.fixString(TPP_Line) +"', '" +
                        Converter.fixString(TPP_Drop) +"', '" +		
                        Converter.fixString(TPP_DelforReleaseNum) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_CurrentDelforDate) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_LastRecDate) +"', " +
                        NumberUtil.toString(TPP_LastRecQty) +", " +
                        NumberUtil.toString(TPP_LastRecCum) +", " +
                        NumberUtil.toString(TPP_CurrentCum) +", " +
                        NumberUtil.toString(TPP_PriorCum) +", " +
                        NumberUtil.toString(TPP_FabAuthor) +", '" +
                        Converter.fixString(TPP_FabCumDelfor) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_FabCumDelforDate) +"', " +
                        NumberUtil.toString(TPP_MatAuthCum) +", '" +
                        Converter.fixString(TPP_MatAuthDelfor) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_MatAuthDate) +"', '" +
                        Converter.fixString(TPP_CurrentDeljit) +"', '" +
                        DateUtil.getCompleteDateRepresentation(TPP_CurrDeljitDate) +"', '" +
                        Converter.fixString(TPP_Linked) +"')";
		 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override 
void update(){
    throw new PersistenceException("Method not implemented");
}

public override 
void delete(){
    throw new PersistenceException("Method not implemented");

}

public 
void read(){
    throw new PersistenceException("Method not implemented");
}

//Setters
public void setTPP_ID (int TPP_ID){
    this.TPP_ID = TPP_ID;
}

public void setTPP_Key (int TPP_Key){
    this.TPP_Key = TPP_Key;
}

public void setTPP_Db (string TPP_Db){
    this.TPP_Db = TPP_Db;
}

public void setTPP_Tpartner (string TPP_Tpartner){
    this.TPP_Tpartner = TPP_Tpartner;
}

public void setTPP_TpartnerLoc (string TPP_TpartnerLoc){
    this.TPP_TpartnerLoc = TPP_TpartnerLoc;
}

public void setTPP_DockKey (string TPP_DockKey){
    this.TPP_DockKey = TPP_DockKey;
}

public void setTPP_CustPartID (string TPP_CustPartID){
    this.TPP_CustPartID = TPP_CustPartID;
}

public void setTPP_ModelYrKey (string TPP_ModelYrKey){
    this.TPP_ModelYrKey = TPP_ModelYrKey;
}

public void setTPP_BillToCust (string TPP_BillToCust){
    this.TPP_BillToCust = TPP_BillToCust;
}

public void setTPP_ShipToCust (string TPP_ShipToCust){
    this.TPP_ShipToCust = TPP_ShipToCust;
}

public void setTPP_ProdID (string TPP_ProdID){
    this.TPP_ProdID = TPP_ProdID;
}

public void setTPP_OrderNum (int TPP_OrderNum){
    this.TPP_OrderNum = TPP_OrderNum;
}

public void setTPP_OrderNumItem (int TPP_OrderNumItem){
    this.TPP_OrderNumItem = TPP_OrderNumItem;
}	

public void setTPP_PO (string TPP_PO){
    this.TPP_PO = TPP_PO;
}

public void setTPP_PODate (DateTime TPP_PODate){
    this.TPP_PODate = TPP_PODate;
}

public void setTPP_DockCode (string TPP_DockCode){
    this.TPP_DockCode = TPP_DockCode;
}

public void setTPP_Revision (string TPP_Revision){
    this.TPP_Revision = TPP_Revision;
}

public void setTPP_RevDate (DateTime TPP_RevDate){
    this.TPP_RevDate = TPP_RevDate;
}

public void setTPP_Expeditor (string TPP_Expeditor){
    this.TPP_Expeditor = TPP_Expeditor;
}

public void setTPP_ExpeditorPhone (string TPP_ExpeditorPhone){
    this.TPP_ExpeditorPhone = TPP_ExpeditorPhone;
}

public void setTPP_Plant (string TPP_Plant){
    this.TPP_Plant = TPP_Plant;
}

public void setTPP_Line (string TPP_Line){
    this.TPP_Line = TPP_Line;
}

public void setTPP_Drop	 (string TPP_Drop){
    this.TPP_Drop= TPP_Drop;
}		

public void setTPP_DelforReleaseNum (string TPP_DelforReleaseNum){
    this.TPP_DelforReleaseNum = TPP_DelforReleaseNum;
}

public void setTPP_CurrentDelforDate (DateTime TPP_CurrentDelforDate){
    this.TPP_CurrentDelforDate = TPP_CurrentDelforDate;
}

public void setTPP_LastRecDate (DateTime TPP_LastRecDate){
    this.TPP_LastRecDate = TPP_LastRecDate;
}

public void setTPP_LastRecQty (int TPP_LastRecQty){
    this.TPP_LastRecQty = TPP_LastRecQty;
}

public void setTPP_LastRecCum (int TPP_LastRecCum){
    this.TPP_LastRecCum = TPP_LastRecCum;
}

public void setTPP_CurrentCum (int TPP_CurrentCum){
    this.TPP_CurrentCum = TPP_CurrentCum;
}

public void setTPP_PriorCum (int TPP_PriorCum){
    this.TPP_PriorCum = TPP_PriorCum;
}

public void setTPP_FabAuthor (int TPP_FabAuthor){
    this.TPP_FabAuthor = TPP_FabAuthor;
}

public void setTPP_FabCumDelfor (string TPP_FabCumDelfor){
    this.TPP_FabCumDelfor = TPP_FabCumDelfor;
}

public void setTPP_FabCumDelforDate (DateTime TPP_FabCumDelforDate){
    this.TPP_FabCumDelforDate = TPP_FabCumDelforDate;
}

public void setTPP_MatAuthCum (int TPP_MatAuthCum){
    this.TPP_MatAuthCum = TPP_MatAuthCum;
}

public void setTPP_MatAuthDelfor (string TPP_MatAuthDelfor){
    this.TPP_MatAuthDelfor = TPP_MatAuthDelfor;
}

public void setTPP_MatAuthDate (DateTime TPP_MatAuthDate){
    this.TPP_MatAuthDate = TPP_MatAuthDate;
}

public void setTPP_CurrentDeljit (string TPP_CurrentDeljit){
    this.TPP_CurrentDeljit = TPP_CurrentDeljit;
}

public void setTPP_CurrDeljitDate (DateTime TPP_CurrDeljitDate){
    this.TPP_CurrDeljitDate = TPP_CurrDeljitDate;
}

public void setTPP_Linked (string TPP_Linked){
    this.TPP_Linked = TPP_Linked;
}



//Getters
public int getTPP_ID(){
    return TPP_ID;
}

public int getTPP_Key(){
    return TPP_Key;
}

public string getTPP_Db(){
    return TPP_Db;
}

public string getTPP_Tpartner(){
    return TPP_Tpartner;
}

public string getTPP_TpartnerLoc(){
    return TPP_TpartnerLoc;
}

public string getTPP_DockKey(){
    return TPP_DockKey;
}

public string getTPP_CustPartID(){
    return TPP_CustPartID;
}

public string getTPP_ModelYrKey(){
    return TPP_ModelYrKey;
}

public string getTPP_BillToCust(){
    return TPP_BillToCust;
}

public string getTPP_ShipToCust(){
    return TPP_ShipToCust;
}

public string getTPP_ProdID(){
    return TPP_ProdID;
}

public int getTPP_OrderNum(){
    return TPP_OrderNum;
}

public int getTPP_OrderNumItem(){
    return TPP_OrderNumItem;	
}

public string getTPP_PO(){
    return TPP_PO;
}

public DateTime getTPP_PODate(){
    return TPP_PODate;
}

public string getTPP_DockCode(){
    return TPP_DockCode;
}

public string getTPP_Revision(){
    return TPP_Revision;
}

public DateTime getTPP_RevDate(){
    return TPP_RevDate;
}

public string getTPP_Expeditor(){
    return TPP_Expeditor;
}

public string getTPP_ExpeditorPhone(){
    return TPP_ExpeditorPhone;
}

public string getTPP_Plant(){
    return TPP_Plant;
}

public string getTPP_Line(){
    return TPP_Line;
}

public string getTPP_Drop(){
    return TPP_Drop;		
}

public string getTPP_DelforReleaseNum(){
    return TPP_DelforReleaseNum;
}

public DateTime getTPP_CurrentDelforDate(){
    return TPP_CurrentDelforDate;
}

public DateTime getTPP_LastRecDate(){
    return TPP_LastRecDate;
}

public int getTPP_LastRecQty(){
    return TPP_LastRecQty;
}

public int getTPP_LastRecCum(){
    return TPP_LastRecCum;
}

public int getTPP_CurrentCum(){
    return TPP_CurrentCum;
}

public int getTPP_PriorCum(){
    return TPP_PriorCum;
}

public int getTPP_FabAuthor(){
    return TPP_FabAuthor;
}

public string getTPP_FabCumDelfor(){
    return TPP_FabCumDelfor;
}

public DateTime getTPP_FabCumDelforDate(){
    return TPP_FabCumDelforDate;
}

public int getTPP_MatAuthCum(){
    return TPP_MatAuthCum;
}

public string getTPP_MatAuthDelfor(){
    return TPP_MatAuthDelfor;
}

public DateTime getTPP_MatAuthDate(){
    return TPP_MatAuthDate;
}

public string getTPP_CurrentDeljit(){
    return TPP_CurrentDeljit;
}

public DateTime getTPP_CurrDeljitDate(){
    return TPP_CurrDeljitDate;
}

public string getTPP_Linked(){
    return TPP_Linked;
}


}//end class
}//endNamesapce
