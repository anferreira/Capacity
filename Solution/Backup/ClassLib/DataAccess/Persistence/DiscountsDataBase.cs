using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class DiscountsDataBase : GenericDataBaseElement{
	
private int DF_ID;
private string DF_DiscCode;
private string DF_DiscDesc;
private double DF_DiscRate;
private string DF_DrCr;
private string DF_BaseNet;
private double DF_DiscAmount;
private string DF_FixedUnit;
private string DF_SalesCode;
private DateTime DF_DateUpdated;

public DiscountsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public 
void read(){
	try{
		string sql = "select * from discounts where DF_DiscCode = '" + DF_DiscCode + "'";
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <read>: " + de.Message,de);
	}
}

public 
bool exists(){
	try{
		bool returnValue = false;
		string	sql ="select * from discounts where "+ 
					" DF_DiscCode = '" + DF_DiscCode + "'";
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();

		return returnValue;
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <exists>: " + de.Message,de);
	}
}


public 
void load(NotNullDataReader reader){
	this.DF_ID			= reader.GetInt32("DF_ID");
	this.DF_DiscCode	= reader.GetString("DF_DiscCode");
	this.DF_DiscDesc	= reader.GetString("DF_DiscDesc");
	this.DF_DiscRate	= decimal.ToDouble(reader.GetDecimal("DF_DiscRate"));//in Windows reader.GetDouble, we found a exception						
	this.DF_DrCr		= reader.GetString("DF_DrCr");
	this.DF_BaseNet		= reader.GetString("DF_BaseNet");
	this.DF_DiscAmount	= decimal.ToDouble(reader.GetDecimal("DF_DiscAmount"));						
	this.DF_FixedUnit	= reader.GetString("DF_FixedUnit");
	this.DF_SalesCode	= reader.GetString("DF_SalesCode");
	this.DF_DateUpdated = reader.GetDateTime("DF_DateUpdated");
}

public override
void write(){
	try{
		string sql = "insert into discounts(" +
					"DF_DiscCode,"  +
					"DF_DiscDesc," + 
					"DF_DiscRate," + 
					"DF_DrCr," + 
					"DF_BaseNet," + 					
					"DF_DiscAmount," + 
					"DF_FixedUnit," + 
					"DF_SalesCode," + 
					"DF_DateUpdated) values ('"  +
			
			Converter.fixString(DF_DiscCode)	+ "','"+ 
			Converter.fixString(DF_DiscDesc)	+ "'," + 
			NumberUtil.toString(DF_DiscRate)	+ ",'" + 
			Converter.fixString(DF_DrCr)		+ "','"+ 
			Converter.fixString(DF_BaseNet)		+ "'," + 
			NumberUtil.toString(DF_DiscAmount)	+ ",'" + 
			Converter.fixString(DF_FixedUnit)	+ "','"+ 
			Converter.fixString(DF_SalesCode)	+ "','"+ 
			DateUtil.getCompleteDateRepresentation(DF_DateUpdated) + "')";
		dataBaseAccess.executeUpdate(sql);

	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <write>: " + de.Message,de);
	}
}


public override 
void update(){
	try{
		string sql = "update discounts set " +			
			
			"DF_DiscDesc='"		+ Converter.fixString(DF_DiscDesc)  + "'," +
			"DF_DiscRate = "	+ NumberUtil.toString(DF_DiscRate)	+ ","  +
			"DF_DrCr = '"		+ Converter.fixString(DF_DrCr)		+ "'," +
			"DF_BaseNet = '"	+ Converter.fixString(DF_BaseNet)	+ "'," + 			
			"DF_DiscAmount="	+ NumberUtil.toString(DF_DiscAmount)+ ","  + 
			"DF_FixedUnit='"	+ Converter.fixString(DF_FixedUnit)	+ "',"+
			"DF_SalesCode='"	+ Converter.fixString(DF_SalesCode)	+ "',"+
			"DF_DateUpdated='"	+ DateUtil.getCompleteDateRepresentation(DF_DateUpdated)+ "' " +
		" where " +
			" DF_DiscCode = '" + DF_DiscCode + "'";
			

		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <update>: " + de.Message,de);
	}
}

public override 
void delete(){
	try{
		string sql=	"delete from discounts "+ 
					"where DF_DiscCode = '"	+ DF_DiscCode + "'";

		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBase <delete>: " + de.Message,de);
	}
}



public
void setDF_ID(int DF_ID){
	this.DF_ID = DF_ID;
}

public
void setDF_DiscCode(string DF_DiscCode){
	this.DF_DiscCode = DF_DiscCode;
}

public
void setDF_DiscDesc(string DF_DiscDesc){
	this.DF_DiscDesc = DF_DiscDesc;
}

public
void setDF_DiscRate(double DF_DiscRate){
	this.DF_DiscRate = DF_DiscRate;
}

public
void setDF_DrCr(string DF_DrCr){
	this.DF_DrCr = DF_DrCr;
}

public
void setDF_BaseNet(string DF_BaseNet){
	this.DF_BaseNet = DF_BaseNet;
}

public
void setDF_DiscAmount(double DF_DiscAmount){
	this.DF_DiscAmount = DF_DiscAmount;
}

public
void setDF_FixedUnit(string DF_FixedUnit){
	this.DF_FixedUnit = DF_FixedUnit;
}

public
void setDF_SalesCode(string DF_SalesCode){
	this.DF_SalesCode = DF_SalesCode;
}

public
void setDF_DateUpdated(DateTime DF_DateUpdated){
	this.DF_DateUpdated = DF_DateUpdated;
}


public
int getDF_ID(){
	return DF_ID;
}

public
string getDF_DiscCode(){
	return DF_DiscCode;
}

public
string getDF_DiscDesc(){
	return DF_DiscDesc;
}

public
double getDF_DiscRate(){
	return DF_DiscRate;
}

public
string getDF_DrCr(){
	return DF_DrCr;
}

public
string getDF_BaseNet(){
	return DF_BaseNet;
}

public
double getDF_DiscAmount(){
	return DF_DiscAmount;
}

public
string getDF_FixedUnit(){
	return DF_FixedUnit;
}

public
string getDF_SalesCode(){
	return DF_SalesCode;
}

public
DateTime getDF_DateUpdated(){
	return DF_DateUpdated;
}

} // class

} // namespace
