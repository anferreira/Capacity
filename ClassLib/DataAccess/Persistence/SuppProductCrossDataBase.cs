using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SuppProductCrossDataBase : GenericDataBaseElement{

private int ID;
private string SP_Database;
private string SP_SupplierNum;
private string SP_SupplierName;
private string SP_ProdID;
private int SP_Seq;
private string SP_SupplierPart;
private string SP_ReleaseProfile;
private string SP_Desc1;
private string SP_Desc2;
private string SP_Desc3;
private string SP_ECNumber;
private string SP_SuppECNumber;
private decimal SP_StdPack;
private string SP_StdPackUom;
private decimal SP_SkidPack;
private string SP_SkidPackUom;
private string SP_Consigned;
private decimal SP_UnitPrice;
private string SP_UnitPriceUom;
private int SP_AuthDaysShip;
private int SP_AuthDaysProd;
private int SP_AuthDaysMat;
private int SP_AuthDaysFore;
private string SP_MonCrt;
private string SP_TuesCrt;
private string SP_WedCrt;
private string SP_ThurCrt;
private string SP_FriCrt;
private string SP_SatCrt;
private string SP_SunCrt;
private string SP_ReleaseNum;
private int SP_Priority;

public
SuppProductCrossDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.SP_Database = reader.GetString("SP_Database");
	this.SP_SupplierNum = reader.GetString("SP_SupplierNum");
	this.SP_SupplierName = reader.GetString("SP_SupplierName");
	this.SP_ProdID = reader.GetString("SP_ProdID");
	this.SP_Seq = reader.GetInt32("SP_Seq");
	this.SP_SupplierPart = reader.GetString("SP_SupplierPart");
	this.SP_ReleaseProfile = reader.GetString("SP_ReleaseProfile");
	this.SP_Desc1 = reader.GetString("SP_Desc1");
	this.SP_Desc2 = reader.GetString("SP_Desc2");
	this.SP_Desc3 = reader.GetString("SP_Desc3");
	this.SP_ECNumber = reader.GetString("SP_ECNumber");
	this.SP_SuppECNumber = reader.GetString("SP_SuppECNumber");
	this.SP_StdPack = reader.GetDecimal("SP_StdPack");
	this.SP_StdPackUom = reader.GetString("SP_StdPackUom");
	this.SP_SkidPack = reader.GetDecimal("SP_SkidPack");
	this.SP_SkidPackUom = reader.GetString("SP_SkidPackUom");
	this.SP_Consigned = reader.GetString("SP_Consigned");
	this.SP_UnitPrice = reader.GetDecimal("SP_UnitPrice");
	this.SP_UnitPriceUom = reader.GetString("SP_UnitPriceUom");
	this.SP_AuthDaysShip = reader.GetInt32("SP_AuthDaysShip");
	this.SP_AuthDaysProd = reader.GetInt32("SP_AuthDaysProd");
	this.SP_AuthDaysMat = reader.GetInt32("SP_AuthDaysMat");
	this.SP_AuthDaysFore = reader.GetInt32("SP_AuthDaysFore");
	this.SP_MonCrt = reader.GetString("SP_MonCrt");
	this.SP_TuesCrt = reader.GetString("SP_TuesCrt");
	this.SP_WedCrt = reader.GetString("SP_WedCrt");
	this.SP_ThurCrt = reader.GetString("SP_ThurCrt");
	this.SP_FriCrt = reader.GetString("SP_FriCrt");
	this.SP_SatCrt = reader.GetString("SP_SatCrt");
	this.SP_SunCrt = reader.GetString("SP_SunCrt");
	this.SP_ReleaseNum = reader.GetString("SP_ReleaseNum");
	this.SP_Priority = reader.GetInt32("SP_Priority");
}

public override
void write(){
	try{
		string sql = "insert into suppproductcross(" +
			"SP_Database, SP_SupplierNum, SP_SupplierName, SP_ProdID, " +
			"SP_Seq, SP_SupplierPart, SP_ReleaseProfile, SP_Desc1, SP_Desc2, " +
			"SP_Desc3, SP_ECNumber, SP_SuppECNumber, SP_StdPack, SP_StdPackUom, " +
			"SP_SkidPack, SP_SkidPackUom, SP_Consigned, SP_UnitPrice, SP_UnitPriceUom, " +
			"SP_AuthDaysShip, SP_AuthDaysProd, SP_AuthDaysMat, SP_AuthDaysFore, SP_MonCrt, " +
			"SP_TuesCrt, SP_WedCrt, SP_ThurCrt, SP_FriCrt, SP_SatCrt, SP_SunCrt, SP_ReleaseNum, SP_Priority)" +
		" values ('" + 
			Converter.fixString(SP_Database) + "', '" +
			Converter.fixString(SP_SupplierNum) + "', '" +
			Converter.fixString(SP_SupplierName) + "', '" +
			Converter.fixString(SP_ProdID) + "', " +
			SP_Seq.ToString() + ", '" +
			Converter.fixString(SP_SupplierPart) + "', '" +
			Converter.fixString(SP_ReleaseProfile) + "', '" +
			Converter.fixString(SP_Desc1) + "', '" +
			Converter.fixString(SP_Desc2) + "', '" +
			Converter.fixString(SP_Desc3) + "', '" +
			Converter.fixString(SP_ECNumber) + "', '" +
			Converter.fixString(SP_SuppECNumber) + "', " +
			NumberUtil.toString(SP_StdPack) + ", '" +
			Converter.fixString(SP_StdPackUom) + "', " +
			NumberUtil.toString(SP_SkidPack) + ", '" +
			Converter.fixString(SP_SkidPackUom) + "', '" +
			Converter.fixString(SP_Consigned) + "', " +
			NumberUtil.toString(SP_UnitPrice) + ", '" +
			Converter.fixString(SP_UnitPriceUom) + "', " +
			SP_AuthDaysShip.ToString() + ", " +
			SP_AuthDaysProd.ToString() + ", " +
			SP_AuthDaysMat.ToString() + ", " +
			SP_AuthDaysFore.ToString() + ", '" +
			Converter.fixString(SP_MonCrt) + "', '" +
			Converter.fixString(SP_TuesCrt) + "', '" +
			Converter.fixString(SP_WedCrt) + "', '" +
			Converter.fixString(SP_ThurCrt) + "', '" +
			Converter.fixString(SP_FriCrt) + "', '" +
			Converter.fixString(SP_SatCrt) + "', '" +
			Converter.fixString(SP_SunCrt) + "', '" +
			Converter.fixString(SP_ReleaseNum) + "', " +
			SP_Priority.ToString() + ")";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from suppproductcross where " + 
			"SP_SupplierNum = '" + Converter.fixString(SP_SupplierNum) + 
			"' and SP_ProdID = '" + Converter.fixString(SP_ProdID) + 
			"' and SP_Seq = " + SP_Seq.ToString();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from suppproductcross where " + 
			"SP_SupplierNum = '" + Converter.fixString(SP_SupplierNum) + 
			"' and SP_ProdID = '" + Converter.fixString(SP_ProdID) + 
			"' and SP_Seq = " + SP_Seq.ToString();

		bool returnValue = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;
		
		return returnValue;
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

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	try{
		string sql = "insert into suppproductcross where ID = " + ID.ToString();
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void setID(int ID){
	this.ID = ID;
}

public
void setSP_Database(string SP_Database){
	this.SP_Database = SP_Database;
}

public
void setSP_SupplierNum(string SP_SupplierNum){
	this.SP_SupplierNum = SP_SupplierNum;
}

public
void setSP_SupplierName(string SP_SupplierName){
	this.SP_SupplierName = SP_SupplierName;
}

public
void setSP_ProdID(string SP_ProdID){
	this.SP_ProdID = SP_ProdID;
}

public
void setSP_Seq(int SP_Seq){
	this.SP_Seq = SP_Seq;
}

public
void setSP_SupplierPart(string SP_SupplierPart){
	this.SP_SupplierPart = SP_SupplierPart;
}

public
void setSP_ReleaseProfile(string SP_ReleaseProfile){
	this.SP_ReleaseProfile = SP_ReleaseProfile;
}

public
void setSP_Desc1(string SP_Desc1){
	this.SP_Desc1 = SP_Desc1;
}

public
void setSP_Desc2(string SP_Desc2){
	this.SP_Desc2 = SP_Desc2;
}

public
void setSP_Desc3(string SP_Desc3){
	this.SP_Desc3 = SP_Desc3;
}

public
void setSP_ECNumber(string SP_ECNumber){
	this.SP_ECNumber = SP_ECNumber;
}

public
void setSP_SuppECNumber(string SP_SuppECNumber){
	this.SP_SuppECNumber = SP_SuppECNumber;
}

public
void setSP_StdPack(decimal SP_StdPack){
	this.SP_StdPack = SP_StdPack;
}

public
void setSP_StdPackUom(string SP_StdPackUom){
	this.SP_StdPackUom = SP_StdPackUom;
}

public
void setSP_SkidPack(decimal SP_SkidPack){
	this.SP_SkidPack = SP_SkidPack;
}

public
void setSP_SkidPackUom(string SP_SkidPackUom){
	this.SP_SkidPackUom = SP_SkidPackUom;
}

public
void setSP_Consigned(string SP_Consigned){
	this.SP_Consigned = SP_Consigned;
}

public
void setSP_UnitPrice(decimal SP_UnitPrice){
	this.SP_UnitPrice = SP_UnitPrice;
}

public
void setSP_UnitPriceUom(string SP_UnitPriceUom){
	this.SP_UnitPriceUom = SP_UnitPriceUom;
}

public
void setSP_AuthDaysShip(int SP_AuthDaysShip){
	this.SP_AuthDaysShip = SP_AuthDaysShip;
}

public
void setSP_AuthDaysProd(int SP_AuthDaysProd){
	this.SP_AuthDaysProd = SP_AuthDaysProd;
}

public
void setSP_AuthDaysMat(int SP_AuthDaysMat){
	this.SP_AuthDaysMat = SP_AuthDaysMat;
}

public
void setSP_AuthDaysFore(int SP_AuthDaysFore){
	this.SP_AuthDaysFore = SP_AuthDaysFore;
}

public
void setSP_MonCrt(string SP_MonCrt){
	this.SP_MonCrt = SP_MonCrt;
}

public
void setSP_TuesCrt(string SP_TuesCrt){
	this.SP_TuesCrt = SP_TuesCrt;
}

public
void setSP_WedCrt(string SP_WedCrt){
	this.SP_WedCrt = SP_WedCrt;
}

public
void setSP_ThurCrt(string SP_ThurCrt){
	this.SP_ThurCrt = SP_ThurCrt;
}

public
void setSP_FriCrt(string SP_FriCrt){
	this.SP_FriCrt = SP_FriCrt;
}

public
void setSP_SatCrt(string SP_SatCrt){
	this.SP_SatCrt = SP_SatCrt;
}

public
void setSP_SunCrt(string SP_SunCrt){
	this.SP_SunCrt = SP_SunCrt;
}

public
void setSP_Priority(int SP_Priority){
	this.SP_Priority = SP_Priority;
}


public
int getID(){
	return ID;
}

public
string getSP_Database(){
	return SP_Database;
}

public
string getSP_SupplierNum(){
	return SP_SupplierNum;
}

public
string getSP_SupplierName(){
	return SP_SupplierName;
}

public
string getSP_ProdID(){
	return SP_ProdID;
}

public
int getSP_Seq(){
	return SP_Seq;
}

public
string getSP_SupplierPart(){
	return SP_SupplierPart;
}

public
string getSP_ReleaseProfile(){
	return SP_ReleaseProfile;
}

public
string getSP_Desc1(){
	return SP_Desc1;
}

public
string getSP_Desc2(){
	return SP_Desc2;
}

public
string getSP_Desc3(){
	return SP_Desc3;
}

public
string getSP_ECNumber(){
	return SP_ECNumber;
}

public
string getSP_SuppECNumber(){
	return SP_SuppECNumber;
}

public
decimal getSP_StdPack(){
	return SP_StdPack;
}

public
string getSP_StdPackUom(){
	return SP_StdPackUom;
}

public
decimal getSP_SkidPack(){
	return SP_SkidPack;
}

public
string getSP_SkidPackUom(){
	return SP_SkidPackUom;
}

public
string getSP_Consigned(){
	return SP_Consigned;
}

public
decimal getSP_UnitPrice(){
	return SP_UnitPrice;
}

public
string getSP_UnitPriceUom(){
	return SP_UnitPriceUom;
}

public
int getSP_AuthDaysShip(){
	return SP_AuthDaysShip;
}

public
int getSP_AuthDaysProd(){
	return SP_AuthDaysProd;
}

public
int getSP_AuthDaysMat(){
	return SP_AuthDaysMat;
}

public
int getSP_AuthDaysFore(){
	return SP_AuthDaysFore;
}

public
string getSP_MonCrt(){
	return SP_MonCrt;
}

public
string getSP_TuesCrt(){
	return SP_TuesCrt;
}

public
string getSP_WedCrt(){
	return SP_WedCrt;
}

public
string getSP_ThurCrt(){
	return SP_ThurCrt;
}

public
string getSP_FriCrt(){
	return SP_FriCrt;
}

public
string getSP_SatCrt(){
	return SP_SatCrt;
}

public
string getSP_SunCrt(){
	return SP_SunCrt;
}

public
int getSP_Priority(){
	return SP_Priority;
}

} // class

} // namespace