using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmInfoDataBase : GenericDataBaseElement{

private string PFS_ProdID;
private string PFS_Db;
private string PFS_Des1;
private string PFS_Des2;
private string PFS_Des3;
private string PFS_VarFam;
private int PFS_SeqLast;
private string PFS_ActIDLast;
private string PFS_FamProd;
private string PFS_PartType;
private string PFS_InvStatus;
private string PFS_ABCCode;
private string PFS_MajorGroup;
private string PFS_MinorGroup;
private string PFS_GLExp;
private string PFS_GLDistr;
private string PFS_MajorSales;
private string PFS_MinorSales;
private DateTime PFS_LastRevision;
private string PFS_RetailProductType;
private decimal PFS_StdPackSize;
private string PFS_StdPackUnit;
private string PFS_ProdCode;

public 
ProdFmInfoDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfminfo where PFS_ProdID = '" + PFS_ProdID + "'";
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
bool readForBom(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from prodfminfo where PFS_ProdID = '" + PFS_ProdID + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			load(reader);
			returnValue = true;
		}

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from prodfminfo where PFS_ProdID = '" + PFS_ProdID + "'";
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

public 
void load(NotNullDataReader reader){
	this.PFS_ProdID = reader.GetString("PFS_ProdID");
	this.PFS_Db = reader.GetString("PFS_Db");
	this.PFS_Des1 = reader.GetString("PFS_Des1");
	this.PFS_Des2 = reader.GetString("PFS_Des2");
	this.PFS_Des3 = reader.GetString("PFS_Des3");
	this.PFS_VarFam = reader.GetString("PFS_VarFam");
	this.PFS_SeqLast = reader.GetInt32("PFS_SeqLast");
	this.PFS_ActIDLast = reader.GetString("PFS_ActIDLast");
	this.PFS_FamProd = reader.GetString("PFS_FamProd");
	this.PFS_PartType = reader.GetString("PFS_PartType");
	this.PFS_InvStatus = reader.GetString("PFS_InvStatus");
	this.PFS_ABCCode = reader.GetString("PFS_ABCCode");
	this.PFS_MajorGroup = reader.GetString("PFS_MajorGroup");
	this.PFS_MinorGroup = reader.GetString("PFS_MinorGroup");
	this.PFS_GLExp = reader.GetString("PFS_GLExp");
	this.PFS_GLDistr = reader.GetString("PFS_GLDistr");
	this.PFS_MajorSales = reader.GetString("PFS_MajorSales");
	this.PFS_MinorSales = reader.GetString("PFS_MinorSales");
	this.PFS_LastRevision = reader.GetDateTime("PFS_LastRevision");
	this.PFS_RetailProductType = reader.GetString("PFS_RetailProductType");
	this.PFS_StdPackSize = reader.GetDecimal("PFS_StdPackSize");
	this.PFS_StdPackUnit = reader.GetString("PFS_StdPackUnit");
	this.PFS_ProdCode = reader.GetString("PFS_ProdCode");
}

public override 
void write(){
	try{
		string sql = "insert into prodfminfo values('" + 
		    Converter.fixString(PFS_ProdID) + "', '" +
			Converter.fixString(PFS_Db) +"', '" +
			Converter.fixString(PFS_Des1) + "', '" +
			Converter.fixString(PFS_Des2) + "', '" +
			Converter.fixString(PFS_Des3) + "', '" +
			Converter.fixString(PFS_VarFam) + "', " +
			PFS_SeqLast.ToString() + ", '" +
			Converter.fixString(PFS_ActIDLast) + "', '" +
			Converter.fixString(PFS_FamProd) + "', '" +
			Converter.fixString(PFS_PartType) + "', '" +
			Converter.fixString(PFS_InvStatus) + "', '" +
			Converter.fixString(PFS_ABCCode) + "', '" +
			Converter.fixString(PFS_MajorGroup) + "', '" +
			Converter.fixString(PFS_MinorGroup) + "', '" +
			Converter.fixString(PFS_GLExp) + "', '" +
			Converter.fixString(PFS_GLDistr) + "', '" +
			Converter.fixString(PFS_MajorSales) + "', '" +
			Converter.fixString(PFS_MinorSales) + "', '" +
			DateUtil.getDateRepresentation(PFS_LastRevision) + "', '" +
			Converter.fixString(PFS_RetailProductType) + "', " +
			NumberUtil.toString(PFS_StdPackSize) + ", '" +
			Converter.fixString(PFS_StdPackUnit) + "', '" +
			Converter.fixString(PFS_ProdCode)+"')";
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
	try{
		string sql = "update prodfminfo set " +
		    "PFS_Db = '" + Converter.fixString(PFS_Db) +"', " +
			"PFS_Des1 = '" + Converter.fixString(PFS_Des1) + "', " +
			"PFS_Des2 = '" + Converter.fixString(PFS_Des2) + "', " +
			"PFS_Des3 = '" + Converter.fixString(PFS_Des3) + "', " +
			"PFS_VarFam = '" + Converter.fixString(PFS_VarFam) + "', " +
			"PFS_SeqLast = " + PFS_SeqLast + ", " +
			"PFS_ActIDLast = '" + Converter.fixString(PFS_ActIDLast) + "', " +
			"PFS_FamProd = '" + Converter.fixString(PFS_FamProd) + "', " +
			"PFS_PartType = '" + Converter.fixString(PFS_PartType) + "', " +
			"PFS_InvStatus = '" + Converter.fixString(PFS_InvStatus) + "', " +
			"PFS_ABCCode = '" + Converter.fixString(PFS_ABCCode) + "', " +
			"PFS_MajorGroup = '" + Converter.fixString(PFS_MajorGroup) + "', " +
			"PFS_MinorGroup = '" + Converter.fixString(PFS_MinorGroup) + "', " +
			"PFS_GLExp = '" + Converter.fixString(PFS_GLExp) + "', " +
			"PFS_GLDistr = '" + Converter.fixString(PFS_GLDistr) + "', " +
			"PFS_MajorSales = '" + Converter.fixString(PFS_MajorSales) + "', " +
			"PFS_MinorSales = '" + Converter.fixString(PFS_MinorSales) + "', " +
			"PFS_LastRevision = '" + DateUtil.getDateRepresentation(PFS_LastRevision) + "', " +
			"PFS_RetailProductType = '" + Converter.fixString(PFS_RetailProductType) + "', " +
			"PFS_StdPackSize = " + NumberUtil.toString(PFS_StdPackSize) + ", " +
			"PFS_StdPackUnit = '" + Converter.fixString(PFS_StdPackUnit) + "', " +
			"PFS_ProdCode = '" + Converter.fixString(PFS_ProdCode) +"' " +
		"where " +
			"PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";

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
void delete(){
	try{
		string sql = "delete from prodfminfo where " +
			"PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
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
void setPFS_ProdID(string PFS_ProdID){
	this.PFS_ProdID = PFS_ProdID;
}

public
void setPFS_Db(string PFS_Db){
	this.PFS_Db = PFS_Db;
}

public
void setPFS_Des1(string PFS_Des1){
	this.PFS_Des1 = PFS_Des1;
}

public
void setPFS_Des2(string PFS_Des2){
	this.PFS_Des2 = PFS_Des2;
}

public
void setPFS_Des3(string PFS_Des3){
	this.PFS_Des3 = PFS_Des3;
}

public
void setPFS_VarFam(string PFS_VarFam){
	this.PFS_VarFam = PFS_VarFam;
}

public
void setPFS_SeqLast(int PFS_SeqLast){
	this.PFS_SeqLast = PFS_SeqLast;
}

public
void setPFS_ActIDLast(string PFS_ActIDLast){
	this.PFS_ActIDLast = PFS_ActIDLast;
}

public
void setPFS_FamProd(string PFS_FamProd){
	this.PFS_FamProd = PFS_FamProd;
}

public
void setPFS_PartType(string PFS_PartType){
	this.PFS_PartType = PFS_PartType;
}

public
void setPFS_InvStatus(string PFS_InvStatus){
	this.PFS_InvStatus = PFS_InvStatus;
}

public
void setPFS_ABCCode(string PFS_ABCCode){
	this.PFS_ABCCode = PFS_ABCCode;
}

public
void setPFS_MajorGroup(string PFS_MajorGroup){
	this.PFS_MajorGroup = PFS_MajorGroup;
}

public
void setPFS_MinorGroup(string PFS_MinorGroup){
	this.PFS_MinorGroup = PFS_MinorGroup;
}

public
void setPFS_GLExp(string PFS_GLExp){
	this.PFS_GLExp = PFS_GLExp;
}

public
void setPFS_GLDistr(string PFS_GLDistr){
	this.PFS_GLDistr = PFS_GLDistr;
}

public
void setPFS_MajorSales(string PFS_MajorSales){
	this.PFS_MajorSales = PFS_MajorSales;
}

public
void setPFS_MinorSales(string PFS_MinorSales){
	this.PFS_MinorSales = PFS_MinorSales;
}

public
void setPFS_LastRevision(DateTime PFS_LastRevision){
	this.PFS_LastRevision = PFS_LastRevision;
}

public
void setPFS_RetailProductType(string PFS_RetailProductType){
	this.PFS_RetailProductType = PFS_RetailProductType;
}

public
void setPFS_StdPackSize(decimal PFS_StdPackSize){
	this.PFS_StdPackSize = PFS_StdPackSize;
}

public
void setPFS_StdPackUnit(string PFS_StdPackUnit){
	this.PFS_StdPackUnit = PFS_StdPackUnit;
}

public
void setPFS_ProdCode(string PFS_ProdCode){
	this.PFS_ProdCode = PFS_ProdCode;
}


public
string getPFS_ProdID(){
	return PFS_ProdID;
}

public
string getPFS_Db(){
	return PFS_Db;
}

public
string getPFS_Des1(){
	return PFS_Des1;
}

public
string getPFS_Des2(){
	return PFS_Des2;
}

public
string getPFS_Des3(){
	return PFS_Des3;
}

public
string getPFS_VarFam(){
	return PFS_VarFam;
}

public
int getPFS_SeqLast(){
	return PFS_SeqLast;
}

public
string getPFS_ActIDLast(){
	return PFS_ActIDLast;
}

public
string getPFS_FamProd(){
	return PFS_FamProd;
}

public
string getPFS_PartType(){
	return PFS_PartType;
}

public
string getPFS_InvStatus(){
	return PFS_InvStatus;
}

public
string getPFS_ABCCode(){
	return PFS_ABCCode;
}

public
string getPFS_MajorGroup(){
	return PFS_MajorGroup;
}

public
string getPFS_MinorGroup(){
	return PFS_MinorGroup;
}

public
string getPFS_GLExp(){
	return PFS_GLExp;
}

public
string getPFS_GLDistr(){
	return PFS_GLDistr;
}

public
string getPFS_MajorSales(){
	return PFS_MajorSales;
}

public
string getPFS_MinorSales(){
	return PFS_MinorSales;
}

public
DateTime getPFS_LastRevision(){
	return PFS_LastRevision;
}

public
string getPFS_RetailProductType(){
	return PFS_RetailProductType;
}

public
decimal getPFS_StdPackSize(){
	return PFS_StdPackSize;
}

public
string getPFS_StdPackUnit(){
	return PFS_StdPackUnit;
}

public
string getPFS_ProdCode(){
	return PFS_ProdCode;
}

} // class

} // namespace
