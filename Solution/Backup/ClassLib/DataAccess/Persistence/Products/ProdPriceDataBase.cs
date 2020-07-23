using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ProdPriceDataBase : GenericDataBaseElement{

private int Prc_ID;
private string Prc_CustClassID;
private string Prc_Product;
private string Prc_PricingUnit;
private string Prc_Currency;
private decimal Prc_Price;
private string Prc_Active;
private DateTime Prc_EffecFrmDate;
private DateTime Prc_EffecToDate;
private DateTime Prc_LastChgDate;
private string	Prc_LastChgUser;
private	decimal	Prc_Volume;
private string	Prc_Discode; 
private string	Prc_Type;

public ProdPriceDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public 
void read(){
	try{
		string sql = "select * from prodprice where Prc_Product = '" + Prc_Product + "'";
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class this.GetType().Name <read>: " + se.Message, se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe)
	{
		throw new PersistenceException("Error in class this.GetType().Name <read>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class this.GetType().Name <read>: " + mySqlExc.Message, mySqlExc);
	}
#endif
	catch(System.Data.DataException de){
		throw new PersistenceException("Error in class this.GetType().Name <read>: " + de.Message, de);
	}
}

public 
bool exists(){
	try{
		bool returnValue = false;
		string	sql ="select * from prodprice where "; 
				sql+= getWhereCondition();
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class this.GetType().Name <exists>: " + se.Message, se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class this.GetType().Name <exists>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}
}


public 
void load(NotNullDataReader reader){
	this.Prc_ID = reader.GetInt32("Prc_ID");
	this.Prc_CustClassID = reader.GetString("Prc_CustClassID");
	this.Prc_Product = reader.GetString("Prc_Product");
	this.Prc_PricingUnit = reader.GetString("Prc_PricingUnit");
	this.Prc_Currency = reader.GetString("Prc_Currency");
	this.Prc_Price = reader.GetDecimal("Prc_Price");
	this.Prc_Active = reader.GetString("Prc_Active");
	this.Prc_EffecFrmDate = reader.GetDateTime("Prc_EffecFrmDate");
	this.Prc_EffecToDate = reader.GetDateTime("Prc_EffecToDate");
	this.Prc_LastChgDate = reader.GetDateTime("Prc_LastChgDate");
	this.Prc_LastChgUser = reader.GetString("Prc_LastChgUser");
	this.Prc_Volume		= reader.GetDecimal("Prc_Volume");
	this.Prc_Discode	= reader.GetString("Prc_Discode");
	this.Prc_Type		= reader.GetString("Prc_Type");
}

public override
void write(){
	try{
		string sql = "insert into prodprice(" +
					"Prc_CustClassID,"  +
					"Prc_Product," + 
					"Prc_PricingUnit," + 
					"Prc_Currency," + 
					"Prc_Price," + 
					"Prc_Active," + 
					"Prc_EffecFrmDate," + 
					"Prc_EffecToDate," + 
					"Prc_LastChgDate," + 
					"Prc_LastChgUser,"+
					"Prc_Volume,"+
					"Prc_Discode," +
					"Prc_Type) values ('"  +
			
			Converter.fixString(Prc_CustClassID)		+ "', '" + 
			Converter.fixString(Prc_Product)	+ "', '" + 
			Converter.fixString(Prc_PricingUnit)+ "', '" + 
			Converter.fixString(Prc_Currency)	+ "', " + 
			NumberUtil.toString(Prc_Price)		+ ", '" + 
			Converter.fixString(Prc_Active)		+ "', '" + 
			DateUtil.getDateRepresentation(Prc_EffecFrmDate) + "', '" + 
			DateUtil.getDateRepresentation(Prc_EffecToDate) + "', '" + 
			DateUtil.getDateRepresentation(Prc_LastChgDate) + "', '" + 
			Converter.fixString(Prc_LastChgUser)+ "',"	+
			NumberUtil.toString(Prc_Volume)		+ ",'"	+
			Converter.fixString(Prc_Discode)	+ "','"	+
			Converter.fixString(Prc_Type)		+ "')";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class this.GetType().Name <write>: " + se.Message, se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe)
	{
		throw new PersistenceException("Error in class this.GetType().Name <write>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc)
	{
		throw new PersistenceException("Error in class this.GetType().Name <write>: " + mySqlExc.Message, mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class this.GetType().Name <write>: " + de.Message, de);
	}
}


public override 
void update(){
	try{
		string sql = "update prodprice set " +			
			"Prc_PricingUnit = '" + Converter.fixString(Prc_PricingUnit) + "', " +
			"Prc_Currency = '" + Converter.fixString(Prc_Currency) + "', " +
			"Prc_Price = " + NumberUtil.toString(Prc_Price) + ", " + 
			"Prc_Active = '" + Converter.fixString(Prc_Active) + "', " +
//thsi values is not necessary , we put because colud change the condition
			"Prc_LastChgDate = '"	+	DateUtil.getDateRepresentation(Prc_LastChgDate) + "', " +
			"Prc_LastChgUser = '"	+	Converter.fixString(Prc_LastChgUser)	+ "', " +
			"Prc_Volume="			+	NumberUtil.toString(Prc_Volume)			+ "," +
			"Prc_Discode='"			+	Converter.fixString(Prc_Discode)		+ "'," +			
			"Prc_Type='"			+	Converter.fixString(Prc_Type)			+ "' " +
	  " where " +
			getWhereCondition();
			

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class this.GetType().Name <update>: " + se.Message, se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe)
	{
		throw new PersistenceException("Error in class this.GetType().Name <update>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class this.GetType().Name <update>: " + mySqlExc.Message, mySqlExc);
	}
#endif
	catch(System.Data.DataException de){
		throw new PersistenceException("Error in class this.GetType().Name <update>: " + de.Message, de);
	}
}

string getWhereCondition()
{
		string sql="";

		sql=" Prc_Product = '" + Prc_Product + "' and "; 	//product

		//customer
		if (Prc_CustClassID.Length > 0)
			sql+=" Prc_CustClassID = '" + Converter.fixString(Prc_CustClassID) + "'";
		else
			sql+=" (Prc_CustClassID is NULL or Prc_CustClassID = '')";

		//type		
		sql+= " and Prc_Type='" + Converter.fixString(Prc_Type) + "'";

		//volume
		sql+= " and Prc_Volume=" + NumberUtil.toString(Prc_Volume);

		//date
		sql+=" and Prc_EffecToDate = '"	+ DateUtil.getCompleteDateRepresentation(Prc_EffecToDate)	+ "'"; //between date
		sql+=" and Prc_EffecFrmDate= '"	+ DateUtil.getCompleteDateRepresentation(Prc_EffecFrmDate)	+ "'";		


		return sql;
}

public override 
void delete(){
	try{
		string sql = "delete from prodprice " + 
			"where " +	getWhereCondition();

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + se.Message, se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe)
	{
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc)
	{
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + mySqlExc.Message, mySqlExc);
	}
#endif
	catch(System.Data.DataException de){
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + de.Message, de);
	}
}

public  
void deleteProdPriceOldies(DateTime dateTime){
	try{
		string sql ="delete from prodprice " + 
					"where Prc_EffecFrmDate < '" + DateUtil.getCompleteDateRepresentation(dateTime) + "'";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + se.Message, se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe)
	{
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc)
	{
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + mySqlExc.Message, mySqlExc);
	}
#endif
	catch(System.Data.DataException de){
		throw new PersistenceException("Error in class this.GetType().Name <delete>: " + de.Message, de);
	}
}


public
void setPrc_ID(int Prc_ID){
	this.Prc_ID = Prc_ID;
}

public
void setPrc_CustClassID(string Prc_CustClassID){
	this.Prc_CustClassID = Prc_CustClassID;
}

public
void setPrc_Product(string Prc_Product){
	this.Prc_Product = Prc_Product;
}

public
void setPrc_PricingUnit(string Prc_PricingUnit){
	this.Prc_PricingUnit = Prc_PricingUnit;
}

public
void setPrc_Currency(string Prc_Currency){
	this.Prc_Currency = Prc_Currency;
}

public
void setPrc_Price(decimal Prc_Price){
	this.Prc_Price = Prc_Price;
}

public
void setPrc_Active(string Prc_Active){
	this.Prc_Active = Prc_Active;
}

public
void setPrc_EffecFrmDate(DateTime Prc_EffecFrmDate){
	this.Prc_EffecFrmDate = Prc_EffecFrmDate;
}

public
void setPrc_EffecToDate(DateTime Prc_EffecToDate){
	this.Prc_EffecToDate = Prc_EffecToDate;
}

public
void setPrc_LastChgDate(DateTime Prc_LastChgDate){
	this.Prc_LastChgDate = Prc_LastChgDate;
}

public
void setPrc_LastChgUser(string Prc_LastChgUser){
	this.Prc_LastChgUser = Prc_LastChgUser;
}

public
void setPrc_Volume(decimal Prc_Volume){
	this.Prc_Volume = Prc_Volume;
}

public
void setPrc_Discode(string Prc_Discode){
	this.Prc_Discode = Prc_Discode;
}

public
void setPrc_Type(string Prc_Type){
	this.Prc_Type = Prc_Type;
}

public
int getPrc_ID(){
	return Prc_ID;
}

public
string getPrc_CustClassID(){
	return Prc_CustClassID;
}

public
string getPrc_Product(){
	return Prc_Product;
}

public
string getPrc_PricingUnit(){
	return Prc_PricingUnit;
}

public
string getPrc_Currency(){
	return Prc_Currency;
}

public
decimal getPrc_Price(){
	return Prc_Price;
}

public
string getPrc_Active(){
	return Prc_Active;
}

public
DateTime getPrc_EffecFrmDate(){
	return Prc_EffecFrmDate;
}

public
DateTime getPrc_EffecToDate(){
	return Prc_EffecToDate;
}

public
DateTime getPrc_LastChgDate(){
	return Prc_LastChgDate;
}

public
string getPrc_LastChgUser(){
	return Prc_LastChgUser;
}

public
decimal getPrc_Volume(){
	return Prc_Volume;
}

public
string getPrc_Discode(){
	return Prc_Discode;
}

public
string getPrc_Type()
{
	return Prc_Type;
}

} // class

} // namespace
