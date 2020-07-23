using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class SuppReleaseDtlDataBase : GenericDataBaseElement{

private int ID;
private string SP_Database;
private string SP_SupplierID;
private string SP_ProdID;
private int SP_Seq;
private string SP_ReleaseNum;
private string SP_TransRef;
private string SP_PastDue;
private decimal SP_QtyNet;
private decimal SP_QtyCum;
private string SP_Uom;
private DateTime SP_Date;
private string SP_AuthLevel;
private DateTime SP_ValidUntil;

private int SP_ReleaseID;

public
SuppReleaseDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.SP_Database = reader.GetString("SP_Database");
	this.SP_SupplierID = reader.GetString("SP_SupplierID");
	this.SP_ProdID = reader.GetString("SP_ProdID");
	this.SP_Seq = reader.GetInt32("SP_Seq");
	this.SP_ReleaseNum = reader.GetString("SP_ReleaseNum");
	this.SP_TransRef = reader.GetString("SP_TransRef");
	this.SP_PastDue = reader.GetString("SP_PastDue");
	this.SP_QtyNet = reader.GetDecimal("SP_QtyNet");
	this.SP_QtyCum = reader.GetDecimal("SP_QtyCum");
	this.SP_Uom = reader.GetString("SP_Uom");
	this.SP_Date = reader.GetDateTime("SP_Date");
	this.SP_AuthLevel = reader.GetString("SP_AuthLevel");
	this.SP_ValidUntil = reader.GetDateTime("SP_ValidUntil");
}

public override
void write(){
	try{
		string sql = "insert into suppreleasedtl values('" + 
			Converter.fixString(SP_Database) + "', '" +
			Converter.fixString(SP_SupplierID) + "', '" +
			Converter.fixString(SP_ProdID) + "', " +
			SP_Seq.ToString() + ", '" +
			Converter.fixString(SP_ReleaseNum) + "', '" +
			Converter.fixString(SP_TransRef) + "', '" +
			Converter.fixString(SP_PastDue) + "', " +
			NumberUtil.toString(SP_QtyNet) + ", " +
			NumberUtil.toString(SP_QtyCum) + ", '" +
			Converter.fixString(SP_Uom) + "', '" +
			DateUtil.getDateRepresentation(SP_Date) + "', '" +
			Converter.fixString(SP_AuthLevel) + "', '" +
			DateUtil.getDateRepresentation(SP_ValidUntil) + "')";

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
	try{
		string sql = "delete from suppreleasedtl where ID = " + ID.ToString();

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
void setSP_SupplierID(string SP_SupplierID){
	this.SP_SupplierID = SP_SupplierID;
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
void setSP_ReleaseNum(string SP_ReleaseNum){
	this.SP_ReleaseNum = SP_ReleaseNum;
}

public
void setSP_TransRef(string SP_TransRef){
	this.SP_TransRef = SP_TransRef;
}

public
void setSP_PastDue(string SP_PastDue){
	this.SP_PastDue = SP_PastDue;
}

public
void setSP_QtyNet(decimal SP_QtyNet){
	this.SP_QtyNet = SP_QtyNet;
}

public
void setSP_QtyCum(decimal SP_QtyCum){
	this.SP_QtyCum = SP_QtyCum;
}

public
void setSP_Uom(string SP_Uom){
	this.SP_Uom = SP_Uom;
}

public
void setSP_Date(DateTime SP_Date){
	this.SP_Date = SP_Date;
}

public
void setSP_AuthLevel(string SP_AuthLevel){
	this.SP_AuthLevel = SP_AuthLevel;
}

public
void setSP_ValidUntil(DateTime SP_ValidUntil){
	this.SP_ValidUntil = SP_ValidUntil;
}

public
void setSP_ReleaseID(int SP_ReleaseID){
	this.SP_ReleaseID = SP_ReleaseID;
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
string getSP_SupplierID(){
	return SP_SupplierID;
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
string getSP_ReleaseNum(){
	return SP_ReleaseNum;
}

public
string getSP_TransRef(){
	return SP_TransRef;
}

public
string getSP_PastDue(){
	return SP_PastDue;
}

public
decimal getSP_QtyNet(){
	return SP_QtyNet;
}

public
decimal getSP_QtyCum(){
	return SP_QtyCum;
}

public
string getSP_Uom(){
	return SP_Uom;
}

public
DateTime getSP_Date(){
	return SP_Date;
}

public
string getSP_AuthLevel(){
	return SP_AuthLevel;
}

public
DateTime getSP_ValidUntil(){
	return SP_ValidUntil;
}

public
int getSP_ReleaseID(){
	return SP_ReleaseID;
}

} // class

} // namespace