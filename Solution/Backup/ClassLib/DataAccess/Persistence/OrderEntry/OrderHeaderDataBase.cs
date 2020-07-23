using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif



namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class OrderHdrDataBase : GenericDataBaseElement{

private int   OH_ID;
private string OH_Db;
private string OH_Company;
private string OH_Plant;
private int		OH_OrderNum;
private string OH_OrgID;
private DateTime	OH_OrderDate;
private string OH_OrderStatus;
private string OH_DistributionLoc;
private string OH_OrderType;
private string OH_BillToNum;
private string OH_BillToName;
private string OH_BillToAdd1;
private string OH_BillToAdd2;
private string OH_BillToAdd3;
private string OH_BillToAdd4;
private string OH_BillToAdd5;
private string OH_BillToAdd6;
private string OH_BillToZipCode;
private string OH_Attention;
private string OH_Terms;
private string OH_ShipVia;
private string OH_PO;
private int 	OH_Quote;
private string OH_Currency;
private string OH_SalesPerson;
private double OH_ComPercent;
private double OH_ComRate;
private DateTime	OH_DateRequest;
private DateTime	OH_DatePromise;
private DateTime	OH_DateShip;
private DateTime	OH_DateConfirm;
private DateTime	OH_DateCancel;
private DateTime	OH_ProdDate;
private string OH_Territory;
private string OH_HoldStatus;
private string OH_ShipComplete;
private double OH_OrderTotal;
private double OH_OrderNet;
private double OH_Tax1Total;
private double OH_Tax2Total;
private double OH_Tax3Total;
private double OH_DiscountTot;
private double OH_CommissTot;
private double OH_RoyaltyTot;
private string OH_Synchronized;
private string OH_OrgOrderType;
private string OH_RetailProductType;
private string OH_SentToCMS;
private string OH_SentUser;
private DateTime OH_SentDateTime;
private string OH_ErpOrderNum;
	
public void updateOrderNotSend()
{	
	try
	{
		string sql = "update orderhdr set OH_Synchronized='N',OH_OrderStatus = 'F'";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <updateOrderNotSend>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <updateOrderNotSend>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getMaxOrderHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <updateOrderNotSend>: " + de.Message,de);
	}
	
}

public int getMaxOrderHeader()
{
	int iresultado=-1;
	try
	{
		string sql = "select max(OH_ID) from orderhdr ";
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
		{
			#if POCKET_PC
 				iresultado = (int) reader.GetInt64(0);// cast to int, because OD_ItemNum is int, but to read from the database we must use GetInt64
			#else
				iresultado = reader.GetInt32(0);
			#endif
		}
		else
 			iresultado=0;//no hay order headers

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <getMaxOrderHeader>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <getMaxOrderHeader>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getMaxOrderHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <getMaxOrderHeader>: " + de.Message,de);
	}
	return iresultado;
}


public OrderHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess)
{
}

public 
void read(){
	try{
		string sql =	"select * from orderhdr where " + 	   
						" OH_ID = "	+ OH_ID.ToString(); 
		   
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
 			load(reader);

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <read>: " + de.Message,de);
	}
}

public 
bool exists(){
	try{
		bool returnValue = false;
		string sql ="select * from orderhdr where OH_ID= " + OH_ID.ToString();
			NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
 			returnValue = true;

		reader.Close();

		return returnValue;

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <exists>: " + de.Message,de);
	}
}

public 
void load(NotNullDataReader reader){

	OH_ID				= reader.GetInt32("OH_ID"); 
	OH_Db				= reader.GetString("OH_Db");
	OH_Company 			= reader.GetString("OH_Company");
	OH_Plant 			= reader.GetString("OH_Plant");
	OH_OrderNum 		= reader.GetInt32("OH_OrderNum");
	OH_OrgID 			= reader.GetString("OH_OrgID");
	OH_OrderDate		= reader.GetDateTime("OH_OrderDate");
	OH_OrderStatus		= reader.GetString("OH_OrderStatus");
	OH_DistributionLoc	= reader.GetString("OH_DistributionLoc");
	OH_OrderType		= reader.GetString("OH_OrderType");
	OH_BillToNum		= reader.GetString("OH_BillToNum");
	OH_BillToName		= reader.GetString("OH_BillToName");
	OH_BillToAdd1		= reader.GetString("OH_BillToAdd1");
	OH_BillToAdd2		= reader.GetString("OH_BillToAdd2");
	OH_BillToAdd3		= reader.GetString("OH_BillToAdd3");
	OH_BillToAdd4		= reader.GetString("OH_BillToAdd4");
	OH_BillToAdd5		= reader.GetString("OH_BillToAdd5");
	OH_BillToAdd6		= reader.GetString("OH_BillToAdd6");
	OH_BillToZipCode	= reader.GetString("OH_BillToZipCode");
	OH_Attention		= reader.GetString("OH_Attention");
	OH_Terms 			= reader.GetString("OH_Terms");
	OH_ShipVia 			= reader.GetString("OH_ShipVia");
	OH_PO				= reader.GetString("OH_PO");
	OH_Quote 			= reader.GetInt32("OH_Quote");
	OH_Currency 		= reader.GetString("OH_Currency");
	OH_SalesPerson		= reader.GetString("OH_SalesPerson");
	OH_ComPercent		= decimal.ToDouble(reader.GetDecimal("OH_ComPercent"));
	OH_ComRate 			= decimal.ToDouble(reader.GetDecimal("OH_ComRate"));
	OH_DateRequest		= reader.GetDateTime("OH_DateRequest");
	OH_DatePromise		= reader.GetDateTime("OH_DatePromise");
	OH_DateShip 		= reader.GetDateTime("OH_DateShip");
	OH_DateConfirm		= reader.GetDateTime("OH_DateConfirm");
	OH_DateCancel		= reader.GetDateTime("OH_DateCancel");
	OH_ProdDate 		= reader.GetDateTime("OH_ProdDate");
	OH_Territory		= reader.GetString("OH_Territory");
	OH_HoldStatus		= reader.GetString("OH_HoldStatus");
	OH_ShipComplete		= reader.GetString("OH_ShipComplete");
	OH_OrderTotal		= decimal.ToDouble(reader.GetDecimal("OH_OrderTotal"));
	OH_OrderNet 		= decimal.ToDouble(reader.GetDecimal("OH_OrderNet"));
	OH_Tax1Total		= decimal.ToDouble(reader.GetDecimal("OH_Tax1Total"));
	OH_Tax2Total		= decimal.ToDouble(reader.GetDecimal("OH_Tax2Total"));
	OH_Tax3Total		= decimal.ToDouble(reader.GetDecimal("OH_Tax3Total"));
	OH_DiscountTot		= decimal.ToDouble(reader.GetDecimal("OH_DiscountTot"));
	OH_CommissTot		= decimal.ToDouble(reader.GetDecimal("OH_CommissTot"));
	OH_RoyaltyTot		= decimal.ToDouble(reader.GetDecimal("OH_RoyaltyTot"));
	OH_Synchronized		= reader.GetString("OH_Synchronized");
	OH_OrgOrderType		= reader.GetString("OH_OrgOrderType");
	OH_RetailProductType= reader.GetString("OH_RetailProductType");
	OH_SentToCMS		= reader.GetString("OH_SentToCMS");
	OH_SentUser			= reader.GetString("OH_SentUser");
	OH_SentDateTime		= reader.GetDateTime("OH_SentDateTime");	
	OH_ErpOrderNum		= reader.GetString("OH_ErpOrderNum");	
}

public override 
void write(){
	try{  
 string sql = "insert into orderhdr("+   	
  	"OH_Db," +
  	"OH_Company," +
  	"OH_Plant," +
  	"OH_OrderNum," +
  	"OH_OrgID," +  	
  	"OH_OrderDate," +
  	"OH_OrderStatus," +
  	"OH_DistributionLoc," +
  	"OH_OrderType," +
  	"OH_BillToNum," +
  	"OH_BillToName," +
  	"OH_BillToAdd1," +
  	"OH_BillTOAdd2," +
  	"OH_BillToAdd3," +
  	"OH_BillToAdd4," +
  	"OH_BillToAdd5," +
  	"OH_BillToAdd6," +
  	"OH_BillToZipCode," +
  	"OH_Attention," +
  	"OH_Terms," +
  	"OH_ShipVia," +
  	"OH_PO," +
  	"OH_Quote," +
  	"OH_Currency," +
  	"OH_SalesPerson," +
  	"OH_ComPercent," +
  	"OH_ComRate," +	
  	"OH_DateRequest," +
  	"OH_DatePromise," +
  	"OH_DateShip," +
  	"OH_DateConfirm," +
  	"OH_DateCancel," +
  	"OH_ProdDate," +
  	"OH_Territory," +
  	"OH_HoldStatus," +
  	"OH_ShipComplete," +
  	"OH_OrderTotal," +
  	"OH_OrderNet," +
  	"OH_Tax1Total," +
  	"OH_Tax2Total," +
  	"OH_Tax3Total," +
  	"OH_DiscountTot," +
  	"OH_CommissTot," +
  	"OH_RoyaltyTot," +
  	"OH_Synchronized," +
	"OH_OrgOrderType," +
	"OH_RetailProductType," +	
	"OH_SentToCMS," + 
	"OH_SentUser," + 
	"OH_SentDateTime," +
	"OH_ErpOrderNum) values (" +
	 	
 	"'"	+	Converter.fixString(OH_Db)			+ "'," +	
 	"'"	+	Converter.fixString(OH_Company)		+ "'," + 
 	"'"	+	Converter.fixString(OH_Plant)  		+ "'," +	
	 OH_OrderNum.ToString()   					+ "," +
 	"'"	+	Converter.fixString(OH_OrgID)		+ "'," +	  	
 	"'" + DateUtil.getCompleteDateRepresentation(OH_OrderDate) + "'," +
 	"'" + Converter.fixString(OH_OrderStatus) 	+ "'," +		
 	"'" + Converter.fixString(OH_DistributionLoc) + "'," +	
 	"'" + Converter.fixString(OH_OrderType)		+ "'," +   	
 	"'" + Converter.fixString(OH_BillToNum)		+ "'," +	
 	"'" + Converter.fixString(OH_BillToName) 	+ "'," +	
 	"'" + Converter.fixString(OH_BillToAdd1) 	+ "'," +	
 	"'" + Converter.fixString(OH_BillToAdd2) 	+ "'," +	
 	"'" + Converter.fixString(OH_BillToAdd3) 	+ "'," +	
 	"'" + Converter.fixString(OH_BillToAdd4) 	+ "'," +	
 	"'" + Converter.fixString(OH_BillToAdd5) 	+ "'," +	
 	"'" + Converter.fixString(OH_BillToAdd6) 	+ "'," +	
    "'" + Converter.fixString(OH_BillToZipCode) + "'," +		 
 	"'" + Converter.fixString(OH_Attention)		+ "'," +	
 	"'" + Converter.fixString(OH_Terms)  		+ "'," +	
 	"'" + Converter.fixString(OH_ShipVia)		+ "'," +	
 	"'" + Converter.fixString(OH_PO)  			+ "'," +	
  		OH_Quote.ToString()   					+ "," + 
 	"'" + Converter.fixString(OH_Currency) 		+ "'," +
 	"'" + Converter.fixString( OH_SalesPerson) 	+ "'," +
  	  NumberUtil.toString(OH_ComPercent)		+ "," + 
  	  NumberUtil.toString(OH_ComRate)			+ "," +   	
 	"'" + DateUtil.getCompleteDateRepresentation(OH_DateRequest) + "'," +
 	"'" + DateUtil.getCompleteDateRepresentation(OH_DatePromise) + "'," +
 	"'" + DateUtil.getCompleteDateRepresentation(OH_DateShip) + "'," +
 	"'" + DateUtil.getCompleteDateRepresentation(OH_DateConfirm) + "'," +
 	"'" + DateUtil.getCompleteDateRepresentation(OH_DateCancel) + "'," +
 	"'" + DateUtil.getCompleteDateRepresentation(OH_ProdDate) + "'," +
 	"'" + Converter.fixString(OH_Territory)			+ "'," +
 	"'" + Converter.fixString(OH_HoldStatus) 		+ "'," +
 	"'" + Converter.fixString(OH_ShipComplete) 		+ "'," +
	NumberUtil.toString(OH_OrderTotal) 				+ "," + 
	NumberUtil.toString(OH_OrderNet)  				+ "," + 
	NumberUtil.toString(OH_Tax1Total)  				+ "," + 
	NumberUtil.toString(OH_Tax2Total)  				+ "," + 
	NumberUtil.toString(OH_Tax3Total)  				+ "," + 
	NumberUtil.toString(OH_DiscountTot)				+ "," + 
	NumberUtil.toString(OH_CommissTot) 				+ "," + 
	NumberUtil.toString(OH_RoyaltyTot) 				+ "," + 
	"'" + Converter.fixString(OH_Synchronized)		+ "'," + 	
	"'" + Converter.fixString(OH_OrgOrderType)		+ "'," + 
	"'" + Converter.fixString(OH_RetailProductType)	+ "'," + 
	"'" + Converter.fixString(OH_SentToCMS)			+ "'," +
	"'" + Converter.fixString(OH_SentUser)			+ "'," +
	"'" + DateUtil.getCompleteDateRepresentation(OH_SentDateTime) + "'," + 
	"'" + Converter.fixString(OH_ErpOrderNum)		+ "')";
  	 	
	dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <write>: " + de.Message,de);
	}
}

public override 
void update(){
	try{
 
	string sql = "update orderhdr set " + 
 
	"OH_Db='"			+ Converter.fixString(OH_Db)			+ "'," +	
	"OH_Company='" 	+ Converter.fixString(OH_Company)		+ "'," + 
	"OH_Plant='" 		+ Converter.fixString(OH_Plant)  		+ "'," +	
	"OH_OrderNum=" 	+ OH_OrderNum.ToString()				+ "," +
	"OH_OrgID='"		+ Converter.fixString(OH_OrgID)			+ "'," +	 
	"OH_OrderDate='"	+ DateUtil.getCompleteDateRepresentation (OH_OrderDate) + "'," +
	"OH_OrderStatus='" + Converter.fixString(OH_OrderStatus) 	+ "'," +	
	"OH_DistributionLoc='"	+ Converter.fixString(OH_DistributionLoc) + "'," +	
	"OH_OrderType='"	+ Converter.fixString(OH_OrderType)		+ "'," + 
	"OH_BillToNum='"	+ Converter.fixString(OH_BillToNum)		+ "'," +	
	"OH_BillToName='"	+ Converter.fixString(OH_BillToName) 	+ "'," +	
	"OH_BillToAdd1='"	+ Converter.fixString(OH_BillToAdd1) 	+ "'," +	
	"OH_BillTOAdd2='"	+ Converter.fixString(OH_BillToAdd2) 	+ "'," +	
	"OH_BillToAdd3='"	+ Converter.fixString(OH_BillToAdd3) 	+ "'," +	
	"OH_BillToAdd4='"	+ Converter.fixString(OH_BillToAdd4) 	+ "'," +	
	"OH_BillToAdd5='"	+ Converter.fixString(OH_BillToAdd5) 	+ "'," +	
	"OH_BillToAdd6='"	+ Converter.fixString(OH_BillToAdd6) 	+ "'," +	
	"OH_BillToZipCode='"+ Converter.fixString(OH_BillToZipCode)+ "'," +	
	"OH_Attention='"	+ Converter.fixString(OH_Attention)		+ "'," +	
	"OH_Terms='" 		+ Converter.fixString(OH_Terms)  		+ "'," +	
	"OH_ShipVia='"		+ Converter.fixString(OH_ShipVia)		+ "'," +	
	"OH_PO='"			+ Converter.fixString(OH_PO)  			+ "'," +	
	"OH_Quote="		+ OH_Quote.ToString()   				+ "," + 
	"OH_Currency='" 	+ Converter.fixString(OH_Currency)		+ "'," +
	"OH_SalesPerson='" + Converter.fixString( OH_SalesPerson) 	+ "'," +
	"OH_ComPercent="	+ NumberUtil.toString(OH_ComPercent) 	+ "," + 
	"OH_ComRate=" 		+ NumberUtil.toString(OH_ComRate)		+ "," + 
	"OH_DateRequest='" + DateUtil.getCompleteDateRepresentation(OH_DateRequest) + "'," +
	"OH_DatePromise='" + DateUtil.getCompleteDateRepresentation(OH_DatePromise) + "'," +
	"OH_DateShip='" 	+ DateUtil.getCompleteDateRepresentation(OH_DateShip) + "'," +
	"OH_DateConfirm='" + DateUtil.getCompleteDateRepresentation(OH_DateConfirm) + "'," +
	"OH_DateCancel='"	+ DateUtil.getCompleteDateRepresentation(OH_DateCancel) + "'," +
	"OH_ProdDate='" 	+ DateUtil.getCompleteDateRepresentation(OH_ProdDate) + "'," +
	"OH_Territory='"	+ Converter.fixString(OH_Territory)		+ "'," +
	"OH_HoldStatus='"	+ Converter.fixString(OH_HoldStatus) 	+ "'," +
	"OH_ShipComplete='"+ Converter.fixString(OH_ShipComplete)	+ "'," +
	"OH_OrderTotal="	+ NumberUtil.toString(OH_OrderTotal)	+ "," + 
	"OH_OrderNet=" 	+ NumberUtil.toString(OH_OrderNet)		+ "," + 
	"OH_Tax1Total=" 	+ NumberUtil.toString(OH_Tax1Total)		+ "," + 
	"OH_Tax2Total=" 	+ NumberUtil.toString(OH_Tax2Total)		+ "," + 
	"OH_Tax3Total=" 	+ NumberUtil.toString(OH_Tax3Total)		+ "," + 
	"OH_DiscountTot="	+ NumberUtil.toString(OH_DiscountTot)	+ "," + 
	"OH_CommissTot="	+ NumberUtil.toString(OH_CommissTot)	+ "," + 
	"OH_RoyaltyTot="	+ NumberUtil.toString(OH_RoyaltyTot)	+ "," + 
	"OH_Synchronized='"	+ Converter.fixString(OH_Synchronized)	+ "',"+ 	
	"OH_OrgOrderType='"	+ Converter.fixString(OH_OrgOrderType)	+ "',"+
	"OH_RetailProductType='" + Converter.fixString(OH_RetailProductType)+ "'," +
	"OH_SentToCMS='"	+ Converter.fixString(OH_SentToCMS)		+ "'," + 
	"OH_SentUser='"	+ Converter.fixString(OH_SentUser)		+ "'," + 
	"OH_SentDateTime='"+ DateUtil.getCompleteDateRepresentation(OH_SentDateTime) + "'," +
	"OH_ErpOrderNum='"	+ Converter.fixString(OH_ErpOrderNum)		+ "'"  +
	 
	" where " +
	" OH_ID= "	+ OH_ID.ToString();

 	
	dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <update>: " + de.Message,de);
	}

}

public override 
void delete(){
	try{
		string sql =	"delete from orderhdr where OH_ID= "+ OH_ID.ToString();
		 
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBase <delete>: " + de.Message,de);
	}
}

public int	getOH_ID()
{
	return OH_ID;
}
public string getOH_Db()
{
	return OH_Db;
}
public string getOH_Company()
{
	return OH_Company;
}

public string getOH_Plant()
{
	return OH_Plant;
}

public int getOH_OrderNum()
{
	return OH_OrderNum;
}

public string	getOH_OrgID()
{
	return OH_OrgID;
}
public DateTime getOH_OrderDate(){
	return OH_OrderDate;
}

public string	getOH_OrderStatus(){
	return OH_OrderStatus;
}

public string	getOH_DistributionLoc(){
	return OH_DistributionLoc;
}
public string	getOH_OrderType(){
	return OH_OrderType;
}

public string	getOH_BillToNum(){
	return OH_BillToNum;
}

public string	getOH_BillToName(){
	return OH_BillToName;
}

public string	getOH_BillToAdd1(){
	return OH_BillToAdd1;
}

public string	getOH_BillToAdd2(){
	return OH_BillToAdd2;
}

public string	getOH_BillToAdd3(){
	return OH_BillToAdd3;
}
public string	getOH_BillToAdd4()
{
	return OH_BillToAdd3;
}
public string	getOH_BillToAdd5()
{
	return OH_BillToAdd3;
}
public string	getOH_BillToAdd6()
{
	return OH_BillToAdd3;
}

public string	getOH_BillToZipCode(){
	return OH_BillToZipCode;
}

public string	getOH_Attention(){
	return OH_Attention;
}
public string	getOH_Terms(){
	return OH_Terms;
}
public string	getOH_ShipVia(){
	return OH_ShipVia;
}
public string	getOH_PO(){
	return OH_PO;
}
public int	getOH_Quote(){
	return OH_Quote;
}
public string getOH_Currency(){
	return OH_Currency;
}
public string	getOH_SalesPerson(){
	return OH_SalesPerson;
}
public double	getOH_ComPercent(){
	return OH_ComPercent;
}
public double	getOH_ComRate(){
	return OH_ComRate;
}
public DateTime getOH_DateRequest(){
	return OH_DateRequest;
}
public DateTime getOH_DatePromise(){
	return OH_DatePromise;
}
public DateTime getOH_DateShip(){
	return OH_DateShip;
}
public DateTime getOH_DateConfirm(){
	return OH_DateConfirm;
}
public DateTime getOH_DateCancel(){
	return OH_DateCancel;
}
public DateTime getOH_ProdDate(){
	return OH_ProdDate;
}
public string	getOH_Territory(){
	return OH_Territory;
}
public string getOH_HoldStatus(){
	return OH_HoldStatus;
}
public string getOH_ShipComplete(){
	return OH_ShipComplete;
}
public double getOH_OrderTotal(){
	return OH_OrderTotal;
}
public double getOH_OrderNet(){
	return OH_OrderNet;
}
public double getOH_Tax1Total(){
	return OH_Tax1Total;
}
public double getOH_Tax2Total(){
	return OH_Tax2Total;
}
public double getOH_Tax3Total(){
	return OH_Tax3Total;
}
public double getOH_DiscountTot(){
	return OH_DiscountTot;
}
public double getOH_CommissTot(){
	return OH_CommissTot;
}
public double getOH_RoyaltyTot(){
	return OH_RoyaltyTot;
}
public string getOH_Synchronized(){
	return OH_Synchronized;
}

public string getOH_OrgOrderType(){
	return OH_OrgOrderType;	
}

public string getOH_RetailProductType(){
	return OH_RetailProductType;	
}



public string getOH_SentToCMS(){
	return OH_SentToCMS;	
}	
public string getOH_SentUser(){
	return OH_SentUser;	
}	
public DateTime getOH_SentDateTime(){
	return OH_SentDateTime;	
}	

public string getOH_ErpOrderNum(){
	return OH_ErpOrderNum;	
}

public
void setOH_ID(int OH_ID){
	this.OH_ID = OH_ID;
}

public
void setOH_Db(string OH_Db){
	this.OH_Db = OH_Db;
}

public void setOH_Company(string OH_Company){	
	this.OH_Company = OH_Company;
}


public
void setOH_Plant(string	OH_Plant){
	this.OH_Plant = OH_Plant;
}

public void setOH_OrderNum(int OH_OrderNum){
	this.OH_OrderNum = OH_OrderNum;
}

public
void setOH_OrgID(string	OH_OrgID){
	this.OH_OrgID = OH_OrgID;
}

public
void setOH_OrderDate(DateTime	OH_OrderDate){
	this.OH_OrderDate = OH_OrderDate;
}

public
void setOH_OrderStatus(string OH_OrderStatus){
this.OH_OrderStatus  = OH_OrderStatus;
}

public
void setOH_DistributionLoc(string OH_DistributionLoc){
this.OH_DistributionLoc = OH_DistributionLoc;
}

public
void setOH_OrderType(string OH_OrderType){
this.OH_OrderType = OH_OrderType;
}

public
void setOH_BillToNum(string OH_BillToNum){
this.OH_BillToNum = OH_BillToNum;
}

public
void setOH_BillToName(string OH_BillToName){
this.OH_BillToName = OH_BillToName;
}

public
void setOH_BillToAdd1(string OH_BillToAdd1){
this.OH_BillToAdd1 = OH_BillToAdd1;
}

public
void setOH_BillToAdd2(string OH_BillTOAdd2){
this.OH_BillToAdd2 = OH_BillTOAdd2;
}

public
void setOH_BillToAdd3(string OH_BillToAdd3){
this.OH_BillToAdd3 = OH_BillToAdd3;
}

public
void setOH_BillToAdd4(string OH_BillToAdd4){
this.OH_BillToAdd4 = OH_BillToAdd4;
}

public
void setOH_BillToAdd5(string OH_BillToAdd5){
this.OH_BillToAdd5 = OH_BillToAdd5;
}

public
void setOH_BillToAdd6(string OH_BillToAdd6){
this.OH_BillToAdd6 = OH_BillToAdd6;
}

public
void setOH_BillToZipCode( string OH_BillToZipCode){
this.OH_BillToZipCode = OH_BillToZipCode;
}


public
void setOH_Attention(string OH_Attention){
this.OH_Attention = OH_Attention;
}

public
void setOH_Terms(string OH_Terms){
this.OH_Terms = OH_Terms;
}

public
void setOH_ShipVia(string OH_ShipVia){
this.OH_ShipVia = OH_ShipVia;
}

public
void setOH_PO(string OH_PO){
this.OH_PO = OH_PO;
}

public
void setOH_Quote(int OH_Quote){
this.OH_Quote = OH_Quote;
}

public
void setOH_Currency(string OH_Currency){
this.OH_Currency = OH_Currency;
}

public
void setOH_SalesPerson(string OH_SalesPerson){
this.OH_SalesPerson = OH_SalesPerson;
}

public
void setOH_ComPercent(double OH_ComPercent){
this.OH_ComPercent = OH_ComPercent;
}

public
void setOH_ComRate(double OH_ComRate){
this.OH_ComRate = OH_ComRate;
}

public
void setOH_DateRequest(DateTime OH_DateRequest){
this.OH_DateRequest = OH_DateRequest;
}

public
void setOH_DatePromise(DateTime OH_DatePromise){
this.OH_DatePromise = OH_DatePromise;
}

public
void setOH_DateShip(DateTime OH_DateShip){
this.OH_DateShip = OH_DateShip;
}	

public
void setOH_DateConfirm(DateTime OH_DateConfirm){
this.OH_DateConfirm = OH_DateConfirm;
}	

public
void setOH_DateCancel(DateTime OH_DateCancel){
this.OH_DateCancel = OH_DateCancel;
}	

public
void setOH_ProdDate(DateTime OH_ProdDate){
this.OH_ProdDate = OH_ProdDate;
}	


public
void setOH_Territory(string OH_Territory){
this.OH_Territory = OH_Territory;
}

public
void setOH_HoldStatus(string OH_HoldStatus){
this.OH_HoldStatus = OH_HoldStatus;
}

public
void setOH_ShipComplete(string OH_ShipComplete){
this.OH_ShipComplete = OH_ShipComplete;
}

public
void setOH_OrderTotal(double OH_OrderTotal){
this.OH_OrderTotal = OH_OrderTotal;
}

public
void setOH_OrderNet(double OH_OrderNet){
this.OH_OrderNet = OH_OrderNet;
}

public
void setOH_Tax1Total(double OH_Tax1Total){
this.OH_Tax1Total = OH_Tax1Total;
}

public
void setOH_Tax2Total(double OH_Tax2Total){
this.OH_Tax2Total = OH_Tax2Total;
}

public
void setOH_Tax3Total(double OH_Tax3Total){
this.OH_Tax3Total = OH_Tax3Total;
}

public
void setOH_DiscountTot(double OH_DiscountTot){
this.OH_DiscountTot = OH_DiscountTot;
}

public
void setOH_CommissTot(double OH_CommissTot){
this.OH_CommissTot = OH_CommissTot;
}

public
void setOH_RoyaltyTot(double OH_RoyaltyTot){
this.OH_RoyaltyTot = OH_RoyaltyTot;
}

public
void setOH_Synchronized(string OH_Synchronized){
this.OH_Synchronized = OH_Synchronized;
}

public void setOH_OrgOrderType(string OH_OrgOrderType){
	this.OH_OrgOrderType = OH_OrgOrderType;
}

public void setOH_RetailProductType(string OH_RetailProductType){
	this.OH_RetailProductType = OH_RetailProductType;	
}


public void setOH_SentToCMS(string OH_SentToCMS){
	this.OH_SentToCMS = OH_SentToCMS;	
}
public void setOH_SentUser(string OH_SentUser){
	this.OH_SentUser = OH_SentUser;	
}

public void setOH_SentDateTime(DateTime OH_SentDateTime){
	this.OH_SentDateTime = OH_SentDateTime;	
}

public void setOH_ErpOrderNum(string OH_ErpOrderNum){
	this.OH_ErpOrderNum = OH_ErpOrderNum;
}

public
	string getKeyHash()
{
	string sret= this.OH_ID.ToString();
	return sret;
}
	
} // class

} // namespace
