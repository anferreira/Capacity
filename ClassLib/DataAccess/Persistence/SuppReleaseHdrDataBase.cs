using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class SuppReleaseHdrDataBase : GenericDataBaseElement{

private int ID;
private string SRH_Database;
private string SRH_Plant;
private string SRH_SupplierNum;
private string SRH_ProdID;
private int SRH_Seq;
private string SRH_ReleaseNum;
private string SRH_TransRef;
private string SRH_Status;
private DateTime SRH_DateCrt;
private string SRH_UserCrt;
private DateTime SRH_DateSent;
private string SRH_UserSent;

public
SuppReleaseHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.SRH_Database = reader.GetString("SRH_Database");
	this.SRH_Plant = reader.GetString("SRH_Plant");
	this.SRH_SupplierNum = reader.GetString("SRH_SupplierNum");
	this.SRH_ProdID = reader.GetString("SRH_ProdID");
	this.SRH_Seq = reader.GetInt32("SRH_Seq");
	this.SRH_ReleaseNum = reader.GetString("SRH_ReleaseNum");
	this.SRH_TransRef = reader.GetString("SRH_TransRef");
	this.SRH_Status = reader.GetString("SRH_Status");
	this.SRH_DateCrt = reader.GetDateTime("SRH_DateCrt");
	this.SRH_UserCrt = reader.GetString("SRH_UserCrt");
	this.SRH_DateSent = reader.GetDateTime("SRH_DateSent");
	this.SRH_UserSent = reader.GetString("SRH_UserSent");
}

public override
void write(){
	try{
		string sql = "insert into suppreleasehdr values('" + 
			Converter.fixString(SRH_Database) + "', '" +
			Converter.fixString(SRH_Plant) + "', '" +
			Converter.fixString(SRH_SupplierNum) + "', '" +
			Converter.fixString(SRH_ProdID) + "', " +
			SRH_Seq.ToString() + ", '" +
			Converter.fixString(SRH_ReleaseNum) + "', '" +
			Converter.fixString(SRH_TransRef) + "', '" +
			Converter.fixString(SRH_Status) + "', '" +
			DateUtil.getDateRepresentation(SRH_DateCrt) + "', '" +
			Converter.fixString(SRH_UserCrt) + "', '" +
			DateUtil.getDateRepresentation(SRH_DateSent) + "', '" +
			Converter.fixString(SRH_UserSent) + "')";
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
		string sql = "delete from suppreleasehdr where ID = " + ID.ToString();

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
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from suppreleasehdr where " + 
			"SRH_Database = '" + Converter.fixString(SRH_Database) +
			"' and SRH_Plant = '" + Converter.fixString(SRH_Plant) +
			"' and SRH_SupplierNum = '" + Converter.fixString(SRH_SupplierNum) + 
			"' and SRH_ProdID = '" + Converter.fixString(SRH_ProdID) + 
			"' and SRH_Seq = " + SRH_Seq.ToString() + 
			" and SRH_ReleaseNum = '" + Converter.fixString(SRH_ReleaseNum) + 
			"' and SRH_Status = '" + Converter.fixString(SRH_Status) + "'";

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
void setID(int ID){
	this.ID = ID;
}

public
void setSRH_Database(string SRH_Database){
	this.SRH_Database = SRH_Database;
}

public
void setSRH_Plant(string SRH_Plant){
	this.SRH_Plant = SRH_Plant;
}

public
void setSRH_SupplierNum(string SRH_SupplierNum){
	this.SRH_SupplierNum = SRH_SupplierNum;
}

public
void setSRH_ProdID(string SRH_ProdID){
	this.SRH_ProdID = SRH_ProdID;
}

public
void setSRH_Seq(int SRH_Seq){
	this.SRH_Seq = SRH_Seq;
}

public
void setSRH_ReleaseNum(string SRH_ReleaseNum){
	this.SRH_ReleaseNum = SRH_ReleaseNum;
}

public
void setSRH_TransRef(string SRH_TransRef){
	this.SRH_TransRef = SRH_TransRef;
}

public
void setSRH_Status(string SRH_Status){
	this.SRH_Status = SRH_Status;
}

public
void setSRH_DateCrt(DateTime SRH_DateCrt){
	this.SRH_DateCrt = SRH_DateCrt;
}

public
void setSRH_UserCrt(string SRH_UserCrt){
	this.SRH_UserCrt = SRH_UserCrt;
}

public
void setSRH_DateSent(DateTime SRH_DateSent){
	this.SRH_DateSent = SRH_DateSent;
}

public
void setSRH_UserSent(string SRH_UserSent){
	this.SRH_UserSent = SRH_UserSent;
}


public
int getID(){
	return ID;
}

public
string getSRH_Database(){
	return SRH_Database;
}

public
string getSRH_Plant(){
	return SRH_Plant;
}

public
string getSRH_SupplierNum(){
	return SRH_SupplierNum;
}

public
string getSRH_ProdID(){
	return SRH_ProdID;
}

public
int getSRH_Seq(){
	return SRH_Seq;
}

public
string getSRH_ReleaseNum(){
	return SRH_ReleaseNum;
}

public
string getSRH_TransRef(){
	return SRH_TransRef;
}

public
string getSRH_Status(){
	return SRH_Status;
}

public
DateTime getSRH_DateCrt(){
	return SRH_DateCrt;
}

public
string getSRH_UserCrt(){
	return SRH_UserCrt;
}

public
DateTime getSRH_DateSent(){
	return SRH_DateSent;
}

public
string getSRH_UserSent(){
	return SRH_UserSent;
}

} // class

} // namespace