using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class InvPltLocDataBase : GenericDataBaseElement{

private string IPL_ProdID;
private int IPL_Seq;
private string IPL_StkLoc;
private string IPL_ActID;
private string IPL_LotID;
private string IPL_MasPrOrd;
private string IPL_PrOrd;
private decimal IPL_Qoh;
private decimal IPL_QohAvail;
private string IPL_Uom;
private decimal IPL_Qoh2;
private decimal IPL_QohAvail2;
private string IPL_Uom2;
private string IPL_Prod2;
private string IPL_FinishedGoods;
private string IPL_Plant;

//Variable fomr talbe ProdFmInfo, is used in InventoryReport
private string PFS_Des1;

public
InvPltLocDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	this.IPL_ProdID = reader.GetString("IPL_ProdID");
	this.IPL_Seq = reader.GetInt32("IPL_Seq");
    this.IPL_Plant =  reader.GetString("IPL_Plant");
    this.IPL_StkLoc = reader.GetString("IPL_StkLoc");
	this.IPL_ActID = reader.GetString("IPL_ActID");
	this.IPL_LotID = reader.GetString("IPL_LotID");
	this.IPL_MasPrOrd = reader.GetString("IPL_MasPrOrd");
	this.IPL_PrOrd = reader.GetString("IPL_PrOrd");
	this.IPL_Qoh = reader.GetDecimal("IPL_Qoh");
	this.IPL_QohAvail = reader.GetDecimal("IPL_QohAvail");
	this.IPL_Uom = reader.GetString("IPL_Uom");
	this.IPL_Qoh2 = reader.GetDecimal("IPL_Qoh2");
	this.IPL_QohAvail2 = reader.GetDecimal("IPL_QohAvail2");
	this.IPL_Uom2 = reader.GetString("IPL_Uom2");
	this.IPL_Prod2 = reader.GetString("IPL_Prod2");
    this.IPL_FinishedGoods = reader.GetString("IPL_FinishedGoods");

    this.PFS_Des1 = "";
    if (reader.HasColumn("PFS_Des1"))
        this.PFS_Des1 = reader.GetString("PFS_Des1");
}

public
void loadForReport(NotNullDataReader reader){
	this.IPL_ProdID = reader.GetString(0);
	this.IPL_Seq = reader.GetInt32(1);
	this.IPL_StkLoc = reader.GetString(2);
	this.IPL_ActID = reader.GetString(3);
	this.IPL_LotID = reader.GetString(4);
	this.IPL_MasPrOrd = reader.GetString(5);
	this.IPL_PrOrd = reader.GetString(6);
	this.IPL_Qoh = reader.GetDecimal(7);
	this.IPL_QohAvail = reader.GetDecimal(8);
	this.IPL_Uom = reader.GetString(9);
	this.IPL_Qoh2 = reader.GetDecimal(10);
	this.IPL_QohAvail2 = reader.GetDecimal(11);
	this.IPL_Uom2 = reader.GetString(12);
	this.IPL_Prod2 = reader.GetString(13);
	this.PFS_Des1 = reader.GetString(14);
    this.IPL_FinishedGoods = reader.GetString(15);
}

public
void loadForHotList(NotNullDataReader reader){
	this.IPL_ProdID = reader.GetString(0);
	this.IPL_ActID = reader.GetString(1);
	this.IPL_Seq = reader.GetInt32(2);
	this.IPL_Qoh = reader.GetDecimal(3);
	this.IPL_Qoh2 = reader.GetDecimal(4);
	this.IPL_Uom = Constants.DEFAULT_UOM;
}

public
void read(){
	string sql = "select * from invpltloc where " + 
		"IPL_ProdID = '" + Converter.fixString(IPL_ProdID) + "' and " +
		"IPL_Seq = " + IPL_Seq.ToString() + " and " +
        "IPL_Plant = '" + Converter.fixString(IPL_Plant) + "' and " +
        "IPL_StkLoc = '" + Converter.fixString(IPL_StkLoc) + "'";
    read(sql);
}

public
void readByProduct(){
	string sql = "select * from invpltloc where " + 
		"IPL_ProdID = '" + Converter.fixString(IPL_ProdID) + "'";
    read(sql);		
}

public 
decimal readProdQoh(){
	NotNullDataReader reader = null;
	try{
		decimal Qoh = 0;

		string sql = "select IPL_ProdID, IPL_Seq, sum(IPL_Qoh) AS Qoh from invpltloc where (IPL_ProdID = '" + Converter.fixString(IPL_ProdID) + "') and (IPL_Seq = " + IPL_Seq + " and IPL_Plant = '" + Converter.fixString(IPL_Plant) + "') group by IPL_ProdID, IPL_Seq";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			Qoh = reader.GetDecimal(2);
		return Qoh;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProdQoh> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProdQoh> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProdQoh> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void write(){	
	string sql = "insert into invpltloc values('" +
		Converter.fixString(IPL_ProdID) + "', " +
		IPL_Seq.ToString() + ", '" +
		Converter.fixString(IPL_StkLoc) + "', '" +
		Converter.fixString(IPL_ActID) + "', '" +
		Converter.fixString(IPL_LotID) + "', '" +
		Converter.fixString(IPL_MasPrOrd) + "', '" +
		Converter.fixString(IPL_PrOrd) + "', " +
		NumberUtil.toString(IPL_Qoh) + ", " +
		NumberUtil.toString(IPL_QohAvail) + ", '" +
		Converter.fixString(IPL_Uom) + "', " +
		NumberUtil.toString(IPL_Qoh2) + ", " +
		NumberUtil.toString(IPL_QohAvail2) + ", '" +
		Converter.fixString(IPL_Uom2) + "', '" +
		Converter.fixString(IPL_Prod2) + "', '" +
        Converter.fixString(IPL_FinishedGoods) + "', '" +                
        Converter.fixString(IPL_Plant) + "')";
    write(sql);                     
}

public override
void update(){	
	string sql = "update invpltloc set " +
		"IPL_LotID = '" + Converter.fixString(IPL_LotID) + "', " +
		"IPL_MasPrOrd = '" + Converter.fixString(IPL_MasPrOrd) + "', " +
		"IPL_PrOrd = '" + Converter.fixString(IPL_PrOrd) + "', " +
		"IPL_StkLoc = '" + Converter.fixString(IPL_StkLoc) + "', " +
		"IPL_Qoh = " + IPL_Qoh + ", " +
		"IPL_QohAvail = " + IPL_QohAvail + ", " +
		"IPL_Uom = '" + Converter.fixString(IPL_Uom) + "', " +
		"IPL_Qoh2 = " + IPL_Qoh2 + ", " +
		"IPL_QohAvail2 = " + IPL_QohAvail2 + ", " +
		"IPL_Uom2 = '" + Converter.fixString(IPL_Uom2) + "', " +
		"IPL_Prod2 = '" + Converter.fixString(IPL_Prod2) + "', " +
        "IPL_FinishedGoods = '" + IPL_FinishedGoods + "', " +            
        "IPL_Seq = " + IPL_Seq +
	" where " + getWhereCondition();
    update(sql);
}

public
string getWhereCondition(){
    string sql =" IPL_ProdID = '" + Converter.fixString(IPL_ProdID) + "' and " +
			    "IPL_Seq = " + IPL_Seq.ToString() + " and " +
                "IPL_Plant = '" + Converter.fixString(IPL_Plant) + "' and " +            
                "IPL_StkLoc = '" + Converter.fixString(IPL_StkLoc) + "' ";
    return sql;
}

public override
void delete(){	
	string sql = "delete from  invpltloc " +
		" where " + getWhereCondition();			
    delete(sql);	
}

public 
bool exists(){		
    string sql = "select * from invpltloc where " + getWhereCondition();			
    return exists(sql);		
}

public 
bool existsProdIDPlant(){		
	string sql = "select * from invpltloc where " + 
		        "IPL_ProdID = '" + Converter.fixString(IPL_ProdID) + "' and IPL_Plant = '" + Converter.fixString(IPL_Plant) + "'";
    return exists(sql);		
}

public
void setIPL_ProdID(string IPL_ProdID){
	this.IPL_ProdID = IPL_ProdID;
}

public
void setIPL_ActID(string IPL_ActID){
	this.IPL_ActID = IPL_ActID;
}

public
void setIPL_Seq(int IPL_Seq){
	this.IPL_Seq = IPL_Seq;
}

public
void setIPL_LotID(string IPL_LotID){
	this.IPL_LotID = IPL_LotID;
}

public
void setIPL_MasPrOrd(string IPL_MasPrOrd){
	this.IPL_MasPrOrd = IPL_MasPrOrd;
}

public
void setIPL_PrOrd(string IPL_PrOrd){
	this.IPL_PrOrd = IPL_PrOrd;
}
        
public
void setIPL_Plant(string IPL_Plant){
	this.IPL_Plant = IPL_Plant;
}

public
void setIPL_StkLoc(string IPL_StkLoc){
	this.IPL_StkLoc = IPL_StkLoc;
}

public
void setIPL_Qoh(decimal IPL_Qoh){
	this.IPL_Qoh = IPL_Qoh;
}

public
void setIPL_QohAvail(decimal IPL_QohAvail){
	this.IPL_QohAvail = IPL_QohAvail;
}

public
void setIPL_Uom(string IPL_Uom){
	this.IPL_Uom = IPL_Uom;
}

public
void setIPL_Qoh2(decimal IPL_Qoh2){
	this.IPL_Qoh2 = IPL_Qoh2;
}

public
void setIPL_QohAvail2(decimal IPL_QohAvail2){
	this.IPL_QohAvail2 = IPL_QohAvail2;
}

public
void setIPL_Uom2(string IPL_Uom2){
	this.IPL_Uom2 = IPL_Uom2;
}

public
void setIPL_Prod2(string IPL_Prod2){
	this.IPL_Prod2 = IPL_Prod2;
}

public
void setIPL_FinishedGoods(string IPL_FinishedGoods){
	this.IPL_FinishedGoods = IPL_FinishedGoods;
}
        
public
string getIPL_ProdID(){
	return IPL_ProdID;
}

public
string getIPL_ActID(){
	return IPL_ActID;
}

public
int getIPL_Seq(){
	return IPL_Seq;
}

public
string getIPL_LotID(){
	return IPL_LotID;
}

public
string getIPL_MasPrOrd(){
	return IPL_MasPrOrd;
}

public
string getIPL_PrOrd(){
	return IPL_PrOrd;
}

public
string getIPL_Plant(){
	return IPL_Plant;
}

public
string getIPL_StkLoc(){
	return IPL_StkLoc;
}

public
decimal getIPL_Qoh(){
	return IPL_Qoh;
}

public
decimal getIPL_QohAvail(){
	return IPL_QohAvail;
}

public
string getIPL_Uom(){
	return IPL_Uom;
}

public
decimal getIPL_Qoh2(){
	return IPL_Qoh2;
}

public
decimal getIPL_QohAvail2(){
	return IPL_QohAvail2;
}

public
string getIPL_Uom2(){
	return IPL_Uom2;
}

public
string getIPL_Prod2(){
	return IPL_Prod2;
}
public
string getIPL_FinishedGoods(){
	return IPL_FinishedGoods;
}
      
public
string getPFS_Des1(){
	return PFS_Des1;
}

} // clas(){
} // namespac(){
