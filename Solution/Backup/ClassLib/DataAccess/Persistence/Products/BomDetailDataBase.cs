using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class BomDetailDataBase : GenericDataBaseElement{

private string BMD_ProdID;
private string BMD_ActID;
private int BMD_Seq;
private string BMS_SubID;
private int BMS_SubOrdNum;
private int BMS_MethodRank;
private int BMS_MatOrdNum;
private string BMD_MatID;
private string BMD_TLID;
private int BMD_MatQty;
private string BMD_QtyUom;
private int BMD_QtyPer;
private string BMD_QtyPerUom;
private int BMD_Wgt;
private string BMD_WgtUom;
private string BMD_UsePer;
private int BMD_MatPer;
private int BMS_ScrapPer;
private int BMS_ScrapAmt;
private string BMS_ScrapUnt;

public
BomDetailDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.BMD_ProdID = reader.GetString("BMD_ProdID");
	this.BMD_ActID = reader.GetString("BMD_ActID");
	this.BMD_Seq = reader.GetInt16("BMD_Seq");
	this.BMS_SubID = reader.GetString("BMS_SubID");
	this.BMS_SubOrdNum = reader.GetInt16("BMS_SubOrdNum");
	this.BMS_MethodRank = reader.GetInt16("BMS_MethodRank");
	this.BMS_MatOrdNum = reader.GetInt16("BMS_MatOrdNum");
	this.BMD_MatID = reader.GetString("BMD_MatID");
	this.BMD_TLID = reader.GetString("BMD_TLID");
	this.BMD_MatQty = reader.GetInt16("BMD_MatQty");
	this.BMD_QtyUom = reader.GetString("BMD_QtyUom");
	this.BMD_QtyPer = reader.GetInt16("BMD_QtyPer");
	this.BMD_QtyPerUom = reader.GetString("BMD_QtyPerUom");
	this.BMD_Wgt = reader.GetInt16("BMD_Wgt");
	this.BMD_WgtUom = reader.GetString("BMD_WgtUom");
	this.BMD_UsePer = reader.GetString("BMD_UsePer");
	this.BMD_MatPer = reader.GetInt16("BMD_MatPer");
	this.BMS_ScrapPer = reader.GetInt16("BMS_ScrapPer");
	this.BMS_ScrapAmt = reader.GetInt16("BMS_ScrapAmt");
	this.BMS_ScrapUnt = reader.GetString("BMS_ScrapUnt");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from bomdetail where " + 
			"BMD_ProdID = '" + Converter.fixString(BMD_ProdID) + "' and " +
			"BMD_ActID = '" + Converter.fixString(BMD_ActID) + "' and " +
			"BMD_Seq = " + BMD_Seq + " and " +
			"BMS_SubID = '" + Converter.fixString(BMS_SubID) + "' and " +
			"BMS_SubOrdNum = " + BMS_SubOrdNum + " and " +
			"BMS_MethodRank = " + BMS_MethodRank + " and " +
			"BMS_MatOrdNum = " + BMS_MatOrdNum + " and " +
			"BMD_MatID = '" + Converter.fixString(BMD_MatID) + "' and " +
			"BMD_TLID = '" + Converter.fixString(BMD_TLID) + "'";
			
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

public override
void delete(){
	try{
		string sql = "delete from bomdetail where " +
			"BMD_ProdID = '" + Converter.fixString(BMD_ProdID) + "' and " +
			"BMD_ActID = '" + Converter.fixString(BMD_ActID) + "' and " +
			"BMD_Seq = " + BMD_Seq + " and " +
			"BMS_SubID = '" + Converter.fixString(BMS_SubID) + "' and " +
			"BMS_SubOrdNum = " + BMS_SubOrdNum + " and " +
			"BMS_MethodRank = " + BMS_MethodRank + " and " +
			"BMS_MatOrdNum = " + BMS_MatOrdNum + " and " +
			"BMD_MatID = '" + Converter.fixString(BMD_MatID) + "' and " +
			"BMD_TLID = '" + Converter.fixString(BMD_TLID) + "'";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update bomdetail set " +
			"BMD_MatQty = " + BMD_MatQty + ", " +
			"BMD_QtyUom = '" + Converter.fixString(BMD_QtyUom) + "', " +
			"BMD_QtyPer = " + BMD_QtyPer + ", " +
			"BMD_QtyPerUom = '" + Converter.fixString(BMD_QtyPerUom) + "', " +
			"BMD_Wgt = " + BMD_Wgt + ", " +
			"BMD_WgtUom = '" + Converter.fixString(BMD_WgtUom) + "', " +
			"BMD_UsePer = '" + Converter.fixString(BMD_UsePer) + "', " +
			"BMD_MatPer = " + BMD_MatPer + ", " +
			"BMS_ScrapPer = " + BMS_ScrapPer + ", " +
			"BMS_ScrapAmt = " + BMS_ScrapAmt + ", " +
			"BMS_ScrapUnt = '" + Converter.fixString(BMS_ScrapUnt) +  "' " +
		" where " + 
			"BMD_ProdID = '" + Converter.fixString(BMD_ProdID) + "' and " +
			"BMD_ActID = '" + Converter.fixString(BMD_ActID) + "' and " +
			"BMD_Seq = " + BMD_Seq + " and " +
			"BMS_SubID = '" + Converter.fixString(BMS_SubID) + "' and " +
			"BMS_SubOrdNum = " + BMS_SubOrdNum + " and " +
			"BMS_MethodRank = " + BMS_MethodRank + " and " +
			"BMS_MatOrdNum = " + BMS_MatOrdNum + " and " +
			"BMD_MatID = '" + Converter.fixString(BMD_MatID) + "' and " +
			"BMD_TLID = '" + Converter.fixString(BMD_TLID) + "'";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void write(){
	try{
		string sql = "insert into bomdetail values('" + 
			Converter.fixString(BMD_ProdID) + "', '" +
			Converter.fixString(BMD_ActID) + "', " +
			BMD_Seq + ", '" +
			Converter.fixString(BMS_SubID) + "', " +
			BMS_SubOrdNum + ", " +
			BMS_MethodRank + ", " +
			BMS_MatOrdNum + ", '" +
			Converter.fixString(BMD_MatID) + "', '" +
			Converter.fixString(BMD_TLID) + "', " +
			BMD_MatQty + ", '" +
			Converter.fixString(BMD_QtyUom) + "', " +
			BMD_QtyPer + ", '" +
			Converter.fixString(BMD_QtyPerUom) + "', " +
			BMD_Wgt + ", '" +
			Converter.fixString(BMD_WgtUom) + "', '" +
			Converter.fixString(BMD_UsePer) + "', " +
			BMD_MatPer + ", " +
			BMS_ScrapPer + ", " +
			BMS_ScrapAmt + ", '" +
			Converter.fixString(BMS_ScrapUnt) + "')";
			
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
void setBMD_ProdID(string BMD_ProdID){
	this.BMD_ProdID = BMD_ProdID;
}

public
void setBMD_ActID(string BMD_ActID){
	this.BMD_ActID = BMD_ActID;
}

public
void setBMD_Seq(int BMD_Seq){
	this.BMD_Seq = BMD_Seq;
}

public
void setBMS_SubID(string BMS_SubID){
	this.BMS_SubID = BMS_SubID;
}

public
void setBMS_SubOrdNum(int BMS_SubOrdNum){
	this.BMS_SubOrdNum = BMS_SubOrdNum;
}

public
void setBMS_MethodRank(int BMS_MethodRank){
	this.BMS_MethodRank = BMS_MethodRank;
}

public
void setBMS_MatOrdNum(int BMS_MatOrdNum){
	this.BMS_MatOrdNum = BMS_MatOrdNum;
}

public
void setBMD_MatID(string BMD_MatID){
	this.BMD_MatID = BMD_MatID;
}

public
void setBMD_TLID(string BMD_TLID){
	this.BMD_TLID = BMD_TLID;
}

public
void setBMD_MatQty(int BMD_MatQty){
	this.BMD_MatQty = BMD_MatQty;
}

public
void setBMD_QtyUom(string BMD_QtyUom){
	this.BMD_QtyUom = BMD_QtyUom;
}

public
void setBMD_QtyPer(int BMD_QtyPer){
	this.BMD_QtyPer = BMD_QtyPer;
}

public
void setBMD_QtyPerUom(string BMD_QtyPerUom){
	this.BMD_QtyPerUom = BMD_QtyPerUom;
}

public
void setBMD_Wgt(int BMD_Wgt){
	this.BMD_Wgt = BMD_Wgt;
}

public
void setBMD_WgtUom(string BMD_WgtUom){
	this.BMD_WgtUom = BMD_WgtUom;
}

public
void setBMD_UsePer(string BMD_UsePer){
	this.BMD_UsePer = BMD_UsePer;
}

public
void setBMD_MatPer(int BMD_MatPer){
	this.BMD_MatPer = BMD_MatPer;
}

public
void setBMS_ScrapPer(int BMS_ScrapPer){
	this.BMS_ScrapPer = BMS_ScrapPer;
}

public
void setBMS_ScrapAmt(int BMS_ScrapAmt){
	this.BMS_ScrapAmt = BMS_ScrapAmt;
}

public
void setBMS_ScrapUnt(string BMS_ScrapUnt){
	this.BMS_ScrapUnt = BMS_ScrapUnt;
}




public
string getBMD_ProdID(){
	return BMD_ProdID;
}

public
string getBMD_ActID(){
	return BMD_ActID;
}

public
int getBMD_Seq(){
	return BMD_Seq;
}

public
string getBMS_SubID(){
	return BMS_SubID;
}

public
int getBMS_SubOrdNum(){
	return BMS_SubOrdNum;
}

public
int getBMS_MethodRank(){
	return BMS_MethodRank;
}

public
int getBMS_MatOrdNum(){
	return BMS_MatOrdNum;
}

public
string getBMD_MatID(){
	return BMD_MatID;
}

public
string getBMD_TLID(){
	return BMD_TLID;
}

public
int getBMD_MatQty(){
	return BMD_MatQty;
}

public
string getBMD_QtyUom(){
	return BMD_QtyUom;
}

public
int getBMD_QtyPer(){
	return BMD_QtyPer;
}

public
string getBMD_QtyPerUom(){
	return BMD_QtyPerUom;
}

public
int getBMD_Wgt(){
	return BMD_Wgt;
}

public
string getBMD_WgtUom(){
	return BMD_WgtUom;
}

public
string getBMD_UsePer(){
	return BMD_UsePer;
}

public
int getBMD_MatPer(){
	return BMD_MatPer;
}

public
int getBMS_ScrapPer(){
	return BMS_ScrapPer;
}

public
int getBMS_ScrapAmt(){
	return BMS_ScrapAmt;
}

public
string getBMS_ScrapUnt(){
	return BMS_ScrapUnt;
}
	
} // class

} // namespace