using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public class CustPartDataBase : GenericDataBaseElement{

private int ID;
private string CP_Db;
private string CP_ProdID;
private string CP_ProdIDAlias;
private string CP_BillToCust;
private string CP_ShipToCust;
private string CP_DropShipCust;
private string CP_CustPart;
private string CP_CustPartRev;
private DateTime CP_CustPartRevDate;
private string CP_CustPartDes1;
private string CP_CustPartDes2;
private string CP_CustPartDes3;
private string CP_Consignment;
private decimal CP_StdPackQty;
private string CP_StdPackUnit;
private string CP_StdPackCont;
private string CP_StdPackSkidCode;
private decimal CP_StdPackSkidQty;
private string CP_StdPackSkidUom;
private int CP_LeadTime;
private int CP_WeeklyQtyCommit;

public CustPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public
bool read(){
	string sql = "select * from custpart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from custpart where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
    this.ID = reader.GetInt32("ID");
    this.CP_Db = reader.GetString("CP_Db");
    this.CP_ProdID = reader.GetString("CP_ProdID");
    this.CP_ProdIDAlias = reader.GetString("CP_ProdIDAlias");
    this.CP_BillToCust = reader.GetString("CP_BillToCust");
    this.CP_ShipToCust = reader.GetString("CP_ShipToCust");
    this.CP_DropShipCust = reader.GetString("CP_DropShipCust");
    this.CP_CustPart = reader.GetString("CP_CustPart");
    this.CP_CustPartRev = reader.GetString("CP_CustPartRev");
    this.CP_CustPartRevDate = reader.GetDateTime("CP_CustPartRevDate");
    this.CP_CustPartDes1 = reader.GetString("CP_CustPartDes1");
    this.CP_CustPartDes2 = reader.GetString("CP_CustPartDes2");
    this.CP_CustPartDes3 = reader.GetString("CP_CustPartDes3");
    this.CP_Consignment = reader.GetString("CP_Consignment");
    this.CP_StdPackQty = reader.GetDecimal("CP_StdPackQty");
    this.CP_StdPackUnit = reader.GetString("CP_StdPackUnit");
    this.CP_StdPackCont = reader.GetString("CP_StdPackCont");
    this.CP_StdPackSkidCode = reader.GetString("CP_StdPackSkidCode");
    this.CP_StdPackSkidQty = reader.GetDecimal("CP_StdPackSkidQty");
    this.CP_StdPackSkidUom = reader.GetString("CP_StdPackSkidUom");

    this.CP_LeadTime = reader.GetInt32("CP_LeadTime");
    this.CP_WeeklyQtyCommit = reader.GetInt32("CP_WeeklyQtyCommit");
}

public override
void write(){	
	string sql = "insert into custpart values('" +
        Converter.fixString(CP_Db) +"', '" +
        Converter.fixString(CP_ProdID) +"', '" +
        Converter.fixString(CP_ProdIDAlias) +"', '" +
        Converter.fixString(CP_BillToCust) +"', '" +
        Converter.fixString(CP_ShipToCust) +"', '" +
        Converter.fixString(CP_DropShipCust) +"', '" +
        Converter.fixString(CP_CustPart) +"', '" +
        Converter.fixString(CP_CustPartRev) +"', '" +
        DateUtil.getCompleteDateRepresentation(CP_CustPartRevDate) +"', '" +
        Converter.fixString(CP_CustPartDes1) +"', '" +
        Converter.fixString(CP_CustPartDes2) +"', '" +
        Converter.fixString(CP_CustPartDes3) +"', '" +
        Converter.fixString(CP_Consignment) +"', " +
        NumberUtil.toString(CP_StdPackQty) +", '" +
        Converter.fixString(CP_StdPackUnit) +"', '" +
        Converter.fixString(CP_StdPackCont) +"', '" +
        Converter.fixString(CP_StdPackSkidCode) +"', " +
        NumberUtil.toString(CP_StdPackSkidQty) +", '" +
        Converter.fixString(CP_StdPackSkidUom) +"'," +
        NumberUtil.toString(CP_LeadTime) + "," +
        NumberUtil.toString(CP_WeeklyQtyCommit) +")";
                
    write(sql);
    ID = dataBaseAccess.getLastId();
}

public override
void update(){  
  update(true);
}

public  
void updateShort(){  
  update(false);
}

private  
void update(bool bfull){
	string sql = "update custpart set " +
		"CP_Db = '" + Converter.fixString(CP_Db) + "', " +
		"CP_ProdID = '" + Converter.fixString(CP_ProdID) + "', " +
		"CP_ProdIDAlias = '" + Converter.fixString(CP_ProdIDAlias) + "', " +
		"CP_BillToCust = '" + Converter.fixString(CP_BillToCust) + "', " +
		"CP_ShipToCust = '" + Converter.fixString(CP_ShipToCust) + "', " +
		"CP_DropShipCust = '" + Converter.fixString(CP_DropShipCust) + "', " +
		"CP_CustPart = '" + Converter.fixString(CP_CustPart) + "', " +
		"CP_CustPartRev = '" + Converter.fixString(CP_CustPartRev) + "', " +
		"CP_CustPartRevDate = '" + DateUtil.getCompleteDateRepresentation(CP_CustPartRevDate) + "', " +
		"CP_CustPartDes1 = '" + Converter.fixString(CP_CustPartDes1) + "', " +
		"CP_CustPartDes2 = '" + Converter.fixString(CP_CustPartDes2) + "', " +
		"CP_CustPartDes3 = '" + Converter.fixString(CP_CustPartDes3) + "', " +
		"CP_Consignment = '" + Converter.fixString(CP_Consignment) + "', " +
		"CP_StdPackQty = " + NumberUtil.toString(CP_StdPackQty) + ", " +
		"CP_StdPackUnit = '" + Converter.fixString(CP_StdPackUnit) + "', " +
		"CP_StdPackCont = '" + Converter.fixString(CP_StdPackCont) + "', " +
		"CP_StdPackSkidCode = '" + Converter.fixString(CP_StdPackSkidCode) + "', " +
		"CP_StdPackSkidQty = " + NumberUtil.toString(CP_StdPackSkidQty) + ", " +
		"CP_StdPackSkidUom = '" + Converter.fixString(CP_StdPackSkidUom) + "' ";

    if (bfull)
		sql+=",CP_LeadTime = " + NumberUtil.toString(CP_LeadTime) + ", " +
		    " CP_WeeklyQtyCommit = " + NumberUtil.toString(CP_WeeklyQtyCommit) + " ";

    sql+= " where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from custpart where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"CP_ProdID = '" + Converter.fixString(CP_ProdID) + "' and " +
		"CP_BillToCust = '" + Converter.fixString(CP_BillToCust) + "' and " +
		"CP_ShipToCust = '" + Converter.fixString(CP_ShipToCust) + "'";
	return sqlWhere;
}

/*
public
bool exists(){	
	string sql = "select * from custpart " + 
		"where " + getWhereCondition();
            
        "CP_Db = '" + Converter.fixString(CP_Db) + "' and " +
        "CP_ProdID ='" +Converter.fixString(CP_ProdID) +"'";
    return exists(sql);						
}*/

//setters
public void setID (int ID){
    this.ID = ID;
}

public void setCP_Db (string CP_Db){
    this.CP_Db = CP_Db;
}

public void setCP_ProdID (string CP_ProdID){
    this.CP_ProdID = CP_ProdID;
}

public void setCP_ProdIDAlias (string CP_ProdIDAlias){
    this.CP_ProdIDAlias = CP_ProdIDAlias;
}

public void setCP_BillToCust (string CP_BillToCust){
    this.CP_BillToCust = CP_BillToCust;
}

public void setCP_ShipToCust (string CP_ShipToCust){
    this.CP_ShipToCust = CP_ShipToCust;
}

public void setCP_DropShipCust (string CP_DropShipCust){
    this.CP_DropShipCust = CP_DropShipCust;
}

public void setCP_CustPart (string CP_CustPart){
    this.CP_CustPart = CP_CustPart;
}

public void setCP_CustPartRev (string CP_CustPartRev){
    this.CP_CustPartRev = CP_CustPartRev;
}

public void setCP_CustPartRevDate (DateTime CP_CustPartRevDate){
    this.CP_CustPartRevDate = CP_CustPartRevDate;
}

public void setCP_CustPartDes1 (string CP_CustPartDes1){
    this.CP_CustPartDes1 = CP_CustPartDes1;
}

public void setCP_CustPartDes2 (string CP_CustPartDes2){
    this.CP_CustPartDes2 = CP_CustPartDes2;
}

public void setCP_CustPartDes3 (string CP_CustPartDes3){
    this.CP_CustPartDes3 = CP_CustPartDes3;
}

public void setCP_Consignment (string CP_Consignment){
    this.CP_Consignment = CP_Consignment;
}

public void setCP_StdPackQty (decimal CP_StdPackQty){
    this.CP_StdPackQty = CP_StdPackQty;
}

public void setCP_StdPackUnit (string CP_StdPackUnit){
    this.CP_StdPackUnit = CP_StdPackUnit;
}

public void setCP_StdPackCont (string CP_StdPackCont){
    this.CP_StdPackCont = CP_StdPackCont;
}

public void setCP_StdPackSkidCode (string CP_StdPackSkidCode){
    this.CP_StdPackSkidCode = CP_StdPackSkidCode;
}

public void setCP_StdPackSkidQty (decimal CP_StdPackSkidQty){
    this.CP_StdPackSkidQty = CP_StdPackSkidQty;
}

public void setCP_StdPackSkidUom (string CP_StdPackSkidUom){
    this.CP_StdPackSkidUom = CP_StdPackSkidUom;
}

public void setCP_LeadTime(int CP_LeadTime){
    this.CP_LeadTime = CP_LeadTime;
}

public void setCP_WeeklyQtyCommit(int CP_WeeklyQtyCommit){
    this.CP_WeeklyQtyCommit = CP_WeeklyQtyCommit;
}

//Getters
public int getID(){
    return ID;
}

public string getCP_Db(){
    return CP_Db;
}

public string getCP_ProdID(){
    return CP_ProdID;
}

public string getCP_ProdIDAlias(){
    return CP_ProdIDAlias;
}

public string getCP_BillToCust(){
    return CP_BillToCust;
}

public string getCP_ShipToCust(){
    return CP_ShipToCust;
}

public string getCP_DropShipCust(){
    return CP_DropShipCust;
}

public string getCP_CustPart(){
    return CP_CustPart;
}

public string getCP_CustPartRev(){
    return CP_CustPartRev;
}

public DateTime getCP_CustPartRevDate(){
    return CP_CustPartRevDate;
}

public string getCP_CustPartDes1(){
    return CP_CustPartDes1;
}

public string getCP_CustPartDes2(){
    return CP_CustPartDes2;
}

public string getCP_CustPartDes3(){
    return CP_CustPartDes3;
}

public string getCP_Consignment(){
    return CP_Consignment;
}

public decimal getCP_StdPackQty(){
    return CP_StdPackQty;
}

public string getCP_StdPackUnit(){
    return CP_StdPackUnit;
}

public string getCP_StdPackCont(){
    return CP_StdPackCont;
}

public string getCP_StdPackSkidCode(){
    return CP_StdPackSkidCode;
}

public decimal getCP_StdPackSkidQty(){
    return CP_StdPackSkidQty;
}

public string getCP_StdPackSkidUom(){
    return CP_StdPackSkidUom;
}

public int getCP_LeadTime(){
    return CP_LeadTime;
}

public int getCP_WeeklyQtyCommit(){
    return CP_WeeklyQtyCommit;
}

}//end class
}//end namespace
