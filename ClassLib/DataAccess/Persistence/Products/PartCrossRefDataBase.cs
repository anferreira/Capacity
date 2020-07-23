using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public class PartCrossRefDataBase : GenericDataBaseElement{

private int ID;
private string BPP_Db;
private string BPP_ProdID;
private string BPP_ProdIDAlias;
private string BPP_BillToCust;
private string BPP_ShipToCust;
private string BPP_DropShipCust;
private string BPP_CustPart;
private string BPP_CustPartRev;
private DateTime BPP_CustPartRevDate;
private string BPP_CustPartDes1;
private string BPP_CustPartDes2;
private string BPP_CustPartDes3;
private string BPP_Consignment;
private decimal BPP_StdPackQty;
private string BPP_StdPackUnit;
private string BPP_StdPackCont;
private string BPP_StdPackSkidCode;
private decimal BPP_StdPackSkidQty;
private string BPP_StdPackSkidUom;
private string BPP_Manufacturer;
private string BPP_ManuID;
private string BPP_Alias;
private string BPP_UPC;
private DateTime BPP_StartDate;
private DateTime BPP_EndDate;
private string BPP_SC1;
private string BPP_SC21;
private string BPP_SC3;
private string BPP_SC4;
private string BPP_SC5;
private string BPP_SC6;
private string BPP_SalesPerson;
private decimal BPP_CommPercent;
private decimal BPP_CommRate;
private string PP_PackProfile;
private int BPP_WarrantyDays;
private DateTime BPP_ExpiryDate;
private string BPP_UnitLFmt;
private decimal BPP_UnitLFmtQty;
private string BPP_BoxLFmt;
private decimal BPP_BoxLFmtQty;
private string BPP_SkidFmt;
private decimal BPP_SkidLFmtQty;
private string BPP_Make;
private string BPP_Model;
private string BPP_Brand;
private string BPP_Color;
private string BPP_Size;
private string BPP_Style;

public PartCrossRefDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){
    this.ID = reader.GetInt32("ID");
    this.BPP_Db = reader.GetString("BPP_Db");
    this.BPP_ProdID = reader.GetString("BPP_ProdID");
    this.BPP_ProdIDAlias = reader.GetString("BPP_ProdIDAlias");
    this.BPP_BillToCust = reader.GetString("BPP_BillToCust");
    this.BPP_ShipToCust = reader.GetString("BPP_ShipToCust");
    this.BPP_DropShipCust = reader.GetString("BPP_DropShipCust");
    this.BPP_CustPart = reader.GetString("BPP_CustPart");
    this.BPP_CustPartRev = reader.GetString("BPP_CustPartRev");
    this.BPP_CustPartRevDate = reader.GetDateTime("BPP_CustPartRevDate");
    this.BPP_CustPartDes1 = reader.GetString("BPP_CustPartDes1");
    this.BPP_CustPartDes2 = reader.GetString("BPP_CustPartDes2");
    this.BPP_CustPartDes3 = reader.GetString("BPP_CustPartDes3");
    this.BPP_Consignment = reader.GetString("BPP_Consignment");
    this.BPP_StdPackQty = reader.GetDecimal("BPP_StdPackQty");
    this.BPP_StdPackUnit = reader.GetString("BPP_StdPackUnit");
    this.BPP_StdPackCont = reader.GetString("BPP_StdPackCont");
    this.BPP_StdPackSkidCode = reader.GetString("BPP_StdPackSkidCode");
    this.BPP_StdPackSkidQty = reader.GetDecimal("BPP_StdPackSkidQty");
    this.BPP_StdPackSkidUom = reader.GetString("BPP_StdPackSkidUom");
    this.BPP_Manufacturer = reader.GetString("BPP_Manufacturer");
    this.BPP_ManuID = reader.GetString("BPP_ManuID");
    this.BPP_Alias = reader.GetString("BPP_Alias");
    this.BPP_UPC = reader.GetString("BPP_UPC");
    this.BPP_StartDate = reader.GetDateTime("BPP_StartDate");
    this.BPP_EndDate = reader.GetDateTime("BPP_EndDate");
    this.BPP_SC1 = reader.GetString("BPP_SC1");
    this.BPP_SC21 = reader.GetString("BPP_SC21");
    this.BPP_SC3 = reader.GetString("BPP_SC3");
    this.BPP_SC4 = reader.GetString("BPP_SC4");
    this.BPP_SC5 = reader.GetString("BPP_SC5");
    this.BPP_SC6 = reader.GetString("BPP_SC6");
    this.BPP_SalesPerson = reader.GetString("BPP_SalesPerson");
    this.BPP_CommPercent = reader.GetDecimal("BPP_CommPercent");
    this.BPP_CommRate = reader.GetDecimal("BPP_CommRate");
    this.PP_PackProfile = reader.GetString("PP_PackProfile");
    this.BPP_WarrantyDays = reader.GetInt32("BPP_WarrantyDays");
    this.BPP_ExpiryDate = reader.GetDateTime("BPP_ExpiryDate");
    this.BPP_UnitLFmt = reader.GetString("BPP_UnitLFmt");
    this.BPP_UnitLFmtQty = reader.GetDecimal("BPP_UnitLFmtQty");
    this.BPP_BoxLFmt = reader.GetString("BPP_BoxLFmt");
    this.BPP_BoxLFmtQty = reader.GetDecimal("BPP_BoxLFmtQty");
    this.BPP_SkidFmt = reader.GetString("BPP_SkidFmt");
    this.BPP_SkidLFmtQty = reader.GetDecimal("BPP_SkidLFmtQty");
    this.BPP_Make = reader.GetString("BPP_Make");
    this.BPP_Model = reader.GetString("BPP_Model");
    this.BPP_Brand = reader.GetString("BPP_Brand");
    this.BPP_Color = reader.GetString("BPP_Color");
    this.BPP_Size = reader.GetString("BPP_Size");
    this.BPP_Style = reader.GetString("BPP_Style");
}

public override
void write(){
	try{
	    string sql = "insert into partcrossref values('" +
            Converter.fixString(BPP_Db) +"', '" +
            Converter.fixString(BPP_ProdID) +"', '" +
            Converter.fixString(BPP_ProdIDAlias) +"', '" +
            Converter.fixString(BPP_BillToCust) +"', '" +
            Converter.fixString(BPP_ShipToCust) +"', '" +
            Converter.fixString(BPP_DropShipCust) +"', '" +
            Converter.fixString(BPP_CustPart) +"', '" +
            Converter.fixString(BPP_CustPartRev) +"', '" +
            DateUtil.getCompleteDateRepresentation(BPP_CustPartRevDate) +"', '" +
            Converter.fixString(BPP_CustPartDes1) +"', '" +
            Converter.fixString(BPP_CustPartDes2) +"', '" +
            Converter.fixString(BPP_CustPartDes3) +"', '" +
            Converter.fixString(BPP_Consignment) +"', " +
            NumberUtil.toString(BPP_StdPackQty) +", '" +
            Converter.fixString(BPP_StdPackUnit) +"', '" +
            Converter.fixString(BPP_StdPackCont) +"', '" +
            Converter.fixString(BPP_StdPackSkidCode) +"', " +
            NumberUtil.toString(BPP_StdPackSkidQty) +", '" +
            Converter.fixString(BPP_StdPackSkidUom) +"', '" +
            Converter.fixString(BPP_Manufacturer) +"', '" +
            Converter.fixString(BPP_ManuID) +"', '" +
            Converter.fixString(BPP_Alias) +"', '" +
            Converter.fixString(BPP_UPC) +"', '" +
            DateUtil.getCompleteDateRepresentation(BPP_StartDate) +"', '" +
            DateUtil.getCompleteDateRepresentation(BPP_EndDate) +"', '" +
            Converter.fixString(BPP_SC1) +"', '" +
            Converter.fixString(BPP_SC21) +"', '" +
            Converter.fixString(BPP_SC3) +"', '" +
            Converter.fixString(BPP_SC4) +"', '" +
            Converter.fixString(BPP_SC5) +"', '" +
            Converter.fixString(BPP_SC6) +"', '" +
            Converter.fixString(BPP_SalesPerson) +"', " +
            NumberUtil.toString(BPP_CommPercent) +", " +
            NumberUtil.toString(BPP_CommRate) +", '" +
            Converter.fixString(PP_PackProfile) +"', " +
            NumberUtil.toString(BPP_WarrantyDays) +", '" +
            DateUtil.getCompleteDateRepresentation(BPP_ExpiryDate) +"', '" +
            Converter.fixString(BPP_UnitLFmt) +"', " +
            NumberUtil.toString(BPP_UnitLFmtQty) +", '" +
            Converter.fixString(BPP_BoxLFmt) +"', " +
            NumberUtil.toString(BPP_BoxLFmtQty) +", '" +
            Converter.fixString(BPP_SkidFmt) +"', " +
            NumberUtil.toString(BPP_SkidLFmtQty) +", '" +
            Converter.fixString(BPP_Make) +"', '" +
            Converter.fixString(BPP_Model) +"', '" +
            Converter.fixString(BPP_Brand) +"', '" +
            Converter.fixString(BPP_Color) +"', '" +
            Converter.fixString(BPP_Size) +"', '" +
            Converter.fixString(BPP_Style) +"')";
                       
        dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
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
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from partcrossref " + 
			"where " +
			"BPP_Db = '" + Converter.fixString(BPP_Db) + "' and " +
            "BPP_ProdID ='" +Converter.fixString(BPP_ProdID) +"'";
			
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
//setters
public void setID (int ID){
    this.ID = ID;
}

public void setBPP_Db (string BPP_Db){
    this.BPP_Db = BPP_Db;
}

public void setBPP_ProdID (string BPP_ProdID){
    this.BPP_ProdID = BPP_ProdID;
}

public void setBPP_ProdIDAlias (string BPP_ProdIDAlias){
    this.BPP_ProdIDAlias = BPP_ProdIDAlias;
}

public void setBPP_BillToCust (string BPP_BillToCust){
    this.BPP_BillToCust = BPP_BillToCust;
}

public void setBPP_ShipToCust (string BPP_ShipToCust){
    this.BPP_ShipToCust = BPP_ShipToCust;
}

public void setBPP_DropShipCust (string BPP_DropShipCust){
    this.BPP_DropShipCust = BPP_DropShipCust;
}

public void setBPP_CustPart (string BPP_CustPart){
    this.BPP_CustPart = BPP_CustPart;
}

public void setBPP_CustPartRev (string BPP_CustPartRev){
    this.BPP_CustPartRev = BPP_CustPartRev;
}

public void setBPP_CustPartRevDate (DateTime BPP_CustPartRevDate){
    this.BPP_CustPartRevDate = BPP_CustPartRevDate;
}

public void setBPP_CustPartDes1 (string BPP_CustPartDes1){
    this.BPP_CustPartDes1 = BPP_CustPartDes1;
}

public void setBPP_CustPartDes2 (string BPP_CustPartDes2){
    this.BPP_CustPartDes2 = BPP_CustPartDes2;
}

public void setBPP_CustPartDes3 (string BPP_CustPartDes3){
    this.BPP_CustPartDes3 = BPP_CustPartDes3;
}

public void setBPP_Consignment (string BPP_Consignment){
    this.BPP_Consignment = BPP_Consignment;
}

public void setBPP_StdPackQty (decimal BPP_StdPackQty){
    this.BPP_StdPackQty = BPP_StdPackQty;
}

public void setBPP_StdPackUnit (string BPP_StdPackUnit){
    this.BPP_StdPackUnit = BPP_StdPackUnit;
}

public void setBPP_StdPackCont (string BPP_StdPackCont){
    this.BPP_StdPackCont = BPP_StdPackCont;
}

public void setBPP_StdPackSkidCode (string BPP_StdPackSkidCode){
    this.BPP_StdPackSkidCode = BPP_StdPackSkidCode;
}

public void setBPP_StdPackSkidQty (decimal BPP_StdPackSkidQty){
    this.BPP_StdPackSkidQty = BPP_StdPackSkidQty;
}

public void setBPP_StdPackSkidUom (string BPP_StdPackSkidUom){
    this.BPP_StdPackSkidUom = BPP_StdPackSkidUom;
}

public void setBPP_Manufacturer (string BPP_Manufacturer){
    this.BPP_Manufacturer = BPP_Manufacturer;
}

public void setBPP_ManuID (string BPP_ManuID){
    this.BPP_ManuID = BPP_ManuID;
}

public void setBPP_Alias (string BPP_Alias){
    this.BPP_Alias = BPP_Alias;
}

public void setBPP_UPC (string BPP_UPC){
    this.BPP_UPC = BPP_UPC;
}

public void setBPP_StartDate (DateTime BPP_StartDate){
    this.BPP_StartDate = BPP_StartDate;
}

public void setBPP_EndDate (DateTime BPP_EndDate){
    this.BPP_EndDate = BPP_EndDate;
}

public void setBPP_SC1 (string BPP_SC1){
    this.BPP_SC1 = BPP_SC1;
}

public void setBPP_SC21 (string BPP_SC21){
    this.BPP_SC21 = BPP_SC21;
}

public void setBPP_SC3 (string BPP_SC3){
    this.BPP_SC3 = BPP_SC3;
}

public void setBPP_SC4 (string BPP_SC4){
    this.BPP_SC4 = BPP_SC4;
}

public void setBPP_SC5 (string BPP_SC5){
    this.BPP_SC5 = BPP_SC5;
}

public void setBPP_SC6 (string BPP_SC6){
    this.BPP_SC6 = BPP_SC6;
}

public void setBPP_SalesPerson (string BPP_SalesPerson){
    this.BPP_SalesPerson = BPP_SalesPerson;
}

public void setBPP_CommPercent (decimal BPP_CommPercent){
    this.BPP_CommPercent = BPP_CommPercent;
}

public void setBPP_CommRate (decimal BPP_CommRate){
    this.BPP_CommRate = BPP_CommRate;
}

public void setPP_PackProfile (string PP_PackProfile){
    this.PP_PackProfile = PP_PackProfile;
}

public void setBPP_WarrantyDays (int BPP_WarrantyDays){
    this.BPP_WarrantyDays = BPP_WarrantyDays;
}

public void setBPP_ExpiryDate (DateTime BPP_ExpiryDate){
    this.BPP_ExpiryDate = BPP_ExpiryDate;
}

public void setBPP_UnitLFmt (string BPP_UnitLFmt){
    this.BPP_UnitLFmt = BPP_UnitLFmt;
}

public void setBPP_UnitLFmtQty (decimal BPP_UnitLFmtQty){
    this.BPP_UnitLFmtQty = BPP_UnitLFmtQty;
}

public void setBPP_BoxLFmt (string BPP_BoxLFmt){
    this.BPP_BoxLFmt = BPP_BoxLFmt;
}

public void setBPP_BoxLFmtQty (decimal BPP_BoxLFmtQty){
    this.BPP_BoxLFmtQty = BPP_BoxLFmtQty;
}

public void setBPP_SkidFmt (string BPP_SkidFmt){
    this.BPP_SkidFmt = BPP_SkidFmt;
}

public void setBPP_SkidLFmtQty (decimal BPP_SkidLFmtQty){
    this.BPP_SkidLFmtQty = BPP_SkidLFmtQty;
}

public void setBPP_Make (string BPP_Make){
    this.BPP_Make = BPP_Make;
}

public void setBPP_Model (string BPP_Model){
    this.BPP_Model = BPP_Model;
}

public void setBPP_Brand (string BPP_Brand){
    this.BPP_Brand = BPP_Brand;
}

public void setBPP_Color (string BPP_Color){
    this.BPP_Color = BPP_Color;
}

public void setBPP_Size (string BPP_Size){
    this.BPP_Size = BPP_Size;
}

public void setBPP_Style (string BPP_Style){
    this.BPP_Style = BPP_Style;
}


//Getters
public int getID(){
    return ID;
}

public string getBPP_Db(){
    return BPP_Db;
}

public string getBPP_ProdID(){
    return BPP_ProdID;
}

public string getBPP_ProdIDAlias(){
    return BPP_ProdIDAlias;
}

public string getBPP_BillToCust(){
    return BPP_BillToCust;
}

public string getBPP_ShipToCust(){
    return BPP_ShipToCust;
}

public string getBPP_DropShipCust(){
    return BPP_DropShipCust;
}

public string getBPP_CustPart(){
    return BPP_CustPart;
}

public string getBPP_CustPartRev(){
    return BPP_CustPartRev;
}

public DateTime getBPP_CustPartRevDate(){
    return BPP_CustPartRevDate;
}

public string getBPP_CustPartDes1(){
    return BPP_CustPartDes1;
}

public string getBPP_CustPartDes2(){
    return BPP_CustPartDes2;
}

public string getBPP_CustPartDes3(){
    return BPP_CustPartDes3;
}

public string getBPP_Consignment(){
    return BPP_Consignment;
}

public decimal getBPP_StdPackQty(){
    return BPP_StdPackQty;
}

public string getBPP_StdPackUnit(){
    return BPP_StdPackUnit;
}

public string getBPP_StdPackCont(){
    return BPP_StdPackCont;
}

public string getBPP_StdPackSkidCode(){
    return BPP_StdPackSkidCode;
}

public decimal getBPP_StdPackSkidQty(){
    return BPP_StdPackSkidQty;
}

public string getBPP_StdPackSkidUom(){
    return BPP_StdPackSkidUom;
}

public string getBPP_Manufacturer(){
    return BPP_Manufacturer;
}

public string getBPP_ManuID(){
    return BPP_ManuID;
}

public string getBPP_Alias(){
    return BPP_Alias;
}

public string getBPP_UPC(){
    return BPP_UPC;
}

public DateTime getBPP_StartDate(){
    return BPP_StartDate;
}

public DateTime getBPP_EndDate(){
    return BPP_EndDate;
}

public string getBPP_SC1(){
    return BPP_SC1;
}

public string getBPP_SC21(){
    return BPP_SC21;
}

public string getBPP_SC3(){
    return BPP_SC3;
}

public string getBPP_SC4(){
    return BPP_SC4;
}

public string getBPP_SC5(){
    return BPP_SC5;
}

public string getBPP_SC6(){
    return BPP_SC6;
}

public string getBPP_SalesPerson(){
    return BPP_SalesPerson;
}

public decimal getBPP_CommPercent(){
    return BPP_CommPercent;
}

public decimal getBPP_CommRate(){
    return BPP_CommRate;
}

public string getPP_PackProfile(){
    return PP_PackProfile;
}

public int getBPP_WarrantyDays(){
    return BPP_WarrantyDays;
}

public DateTime getBPP_ExpiryDate(){
    return BPP_ExpiryDate;
}

public string getBPP_UnitLFmt(){
    return BPP_UnitLFmt;
}

public decimal getBPP_UnitLFmtQty(){
    return BPP_UnitLFmtQty;
}

public string getBPP_BoxLFmt(){
    return BPP_BoxLFmt;
}

public decimal getBPP_BoxLFmtQty(){
    return BPP_BoxLFmtQty;
}

public string getBPP_SkidFmt(){
    return BPP_SkidFmt;
}

public decimal getBPP_SkidLFmtQty(){
    return BPP_SkidLFmtQty;
}

public string getBPP_Make(){
    return BPP_Make;
}

public string getBPP_Model(){
    return BPP_Model;
}

public string getBPP_Brand(){
    return BPP_Brand;
}

public string getBPP_Color(){
    return BPP_Color;
}

public string getBPP_Size(){
    return BPP_Size;
}

public string getBPP_Style(){
    return BPP_Style;
}


}//end class
}//end namespace
