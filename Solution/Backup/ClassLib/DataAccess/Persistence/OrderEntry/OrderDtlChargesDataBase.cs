using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderDtlChargesDataBase : GenericDataBaseElement{
		
	int OH_ID;
	int ODC_ID;
	string ODC_Db;
	int ODC_OrderNum;
	int ODC_ItemNum;
	int ODC_ItemChgNum;
	string ODC_ChargeCode;
	string ODC_ChargeDesc;	
	string ODC_ChargeType;
	string ODC_ChargeTypeSub;
	string ODC_BaseNet;
	string	ODC_FixedUnit;
	string	ODC_SaleCOS;
	double ODC_Amount;
	double ODC_MaxAmount;
	string ODC_BeforeTax;
	string ODC_BeforeFreight;
	string ODC_BeforeDiscount;
	double ODC_Percent;
	double ODC_Extension;
	string ODC_ApplytoCust;
	string ODC_ApplytoSupplier;
	long  ODC_GLAccountNum;
	string ODC_OnSalePaidInv;
	string ODC_Paid;
	string ODC_Received;
	
	
public OrderDtlChargesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	try{	
		string sql ="select * from orderdtlcharges where "	+ 					
					"OH_ID="			+ OH_ID	+ " and " +					
					"ODC_ItemNum="		+ ODC_ItemNum	+ " and " +
					"ODC_ItemChgNum="	+ ODC_ItemChgNum;
			
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <read>: " + de.Message,de);
	}
}
public int getMaxItemFromDetailCharges()
{
	int iresultado=-1;
	try
	{				
		string sql ="select max(ODC_ItemChgNum) from orderdtlcharges where " +					
					"OH_ID="		+ OH_ID	+ " and " +					
					"ODC_ItemNum="	+ ODC_ItemNum;
					
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
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <getMaxItemFromDetailCharges>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <getMaxItemFromDetailCharges>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getMaxItemFromDetailCharges> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <getMaxItemFromDetailCharges>: " + de.Message,de);
	}
	return iresultado;
}


public 
bool exists(){
	try{
		bool returnValue = false;
		string sql ="select * from orderdtlcharges where "	+								
					"OH_ID="			+ OH_ID	+ " and " +					
					"ODC_ItemNum="		+ ODC_ItemNum	+ " and " +
					"ODC_ItemChgNum="	+ ODC_ItemChgNum;

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <exists>: " + de.Message,de);
	}
}

public 
void load(NotNullDataReader reader){

	this.OH_ID				= reader.GetInt32("OH_ID");
	this.ODC_ID				= reader.GetInt32("ODC_ID");
	this.ODC_Db				= reader.GetString("ODC_Db");
	this.ODC_OrderNum		= reader.GetInt32("ODC_OrderNum");
	this.ODC_ItemNum		= reader.GetInt32("ODC_ItemNum");
	this.ODC_ItemChgNum		= reader.GetInt32("ODC_ItemChgNum");
	this.ODC_ChargeCode		= reader.GetString("ODC_ChargeCode");
	this.ODC_ChargeDesc		= reader.GetString("ODC_ChargeDesc");
	this.ODC_BaseNet		= reader.GetString("ODC_BaseNet");
	this.ODC_FixedUnit		= reader.GetString("ODC_FixedUnit");
	this.ODC_SaleCOS		= reader.GetString("ODC_SaleCOS");
	this.ODC_Amount			= decimal.ToDouble(reader.GetDecimal("ODC_Amount"));
	this.ODC_MaxAmount		= decimal.ToDouble(reader.GetDecimal("ODC_MaxAmount"));
	this.ODC_BeforeTax		= reader.GetString("ODC_BeforeTax");

	this.ODC_BeforeFreight	= reader.GetString("ODC_BeforeFreight");
	this.ODC_BeforeDiscount	= reader.GetString("ODC_BeforeDiscount");
	this.ODC_Percent		= decimal.ToDouble(reader.GetDecimal("ODC_Percent"));
	this.ODC_Extension		= decimal.ToDouble(reader.GetDecimal("ODC_Extension"));	
	this.ODC_ApplytoCust	= reader.GetString("ODC_ApplytoCust");
	this.ODC_ApplytoSupplier= reader.GetString("ODC_ApplytoSupplier");
	this.ODC_GLAccountNum	= decimal.ToInt64(reader.GetDecimal("ODC_GLAccountNum"));
	this.ODC_OnSalePaidInv	= reader.GetString("ODC_OnSalePaidInv");
	this.ODC_Paid			= reader.GetString("ODC_Paid");
	this.ODC_Received		= reader.GetString("ODC_Received");	
}

public override 
void write(){
	try{		
		//ODC_ChargeDesc sequence
		string sql = "insert into orderdtlcharges(" + 			
		"OH_ID," +
		"ODC_Db," +
		"ODC_OrderNum," +
		"ODC_ItemNum," +
		"ODC_ItemChgNum," +
		"ODC_ChargeCode," +
		"ODC_ChargeDesc," +		
		"ODC_ChargeType," +
		"ODC_ChargeTypeSub," + 			
		"ODC_BaseNet," +		
		"ODC_FixedUnit," +		
		"ODC_SaleCOS," + 
		"ODC_Amount," +
		"ODC_MaxAmount," +
		"ODC_BeforeTax," +
		"ODC_BeforeFreight," +
		"ODC_BeforeDiscount," +
		"ODC_Percent," +
		"ODC_Extension," +		
		"ODC_ApplytoCust," +
		"ODC_ApplytoSupplier," +
		"ODC_GLAccountNum," +
		"ODC_OnSalePaidInv," +
		"ODC_Paid," +
		"ODC_Received)" +
		
		" values ("+				
		OH_ID.ToString()								+ "," +
		"'" +   Converter.fixString(ODC_Db)				+ "'," +
 				ODC_OrderNum.ToString()					+ "," +	
 				ODC_ItemNum.ToString()					+ "," + 
 				ODC_ItemChgNum.ToString() 				+ "," +	
		"'" +   Converter.fixString(ODC_ChargeCode)		+ "'," +
		"'" +   Converter.fixString(ODC_ChargeDesc)		+ "'," +			
		"'"	+	Converter.fixString(ODC_ChargeType)		+ "'," +	
		"'" +	Converter.fixString(ODC_ChargeTypeSub)	+ "'," +			
		"'"	+	Converter.fixString(ODC_BaseNet)		+ "'," +
		"'" +	Converter.fixString(ODC_FixedUnit)		+ "'," +		
		"'" +	Converter.fixString(ODC_SaleCOS)		+ "'," +		
				NumberUtil.toString(ODC_Amount)			+ "," +			
				NumberUtil.toString(ODC_MaxAmount)		+ "," +			
		"'"	+	Converter.fixString(ODC_BeforeTax)		+ "'," +	
		"'"	+	Converter.fixString(ODC_BeforeFreight)	+ "'," +	
		"'"	+	Converter.fixString(ODC_BeforeDiscount)	+ "'," +			
				NumberUtil.toString(ODC_Percent)		+ "," +	   
				NumberUtil.toString(ODC_Extension)		+ "," +	   
		"'"	+	Converter.fixString(ODC_ApplytoCust)	+ "'," +			
		"'"	+	Converter.fixString(ODC_ApplytoSupplier)+ "'," +							
				ODC_GLAccountNum.ToString()				+ "," +	   
		"'"	+	Converter.fixString(ODC_OnSalePaidInv)	+ "'," +			
		"'"	+	Converter.fixString(ODC_Paid)			+ "'," +	
		"'"	+	Converter.fixString(ODC_Received)		+ "')";				
		
		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <write>: " + de.Message,de);
	}
}

public override 
void update(){
	try{
		//ODC_ChargeDesc sequence
		string sql = "update orderdtlcharges set " +
		"ODC_Db='"				+ Converter.fixString(ODC_Db)				+ "'," +		
		"ODC_OrderNum="			+ ODC_OrderNum.ToString()					+ "," +
		"ODC_ChargeCode='"		+ Converter.fixString(ODC_ChargeCode)		+ "'," +
		"ODC_ChargeDesc='"		+ ODC_ChargeDesc.ToString()					+ "'," +			
		"ODC_ChargeType='"		+ Converter.fixString(ODC_ChargeType)		+ "'," +	
		"ODC_ChargeTypeSub='"	+ Converter.fixString(ODC_ChargeTypeSub)	+ "'," +			
		"ODC_BaseNet='"			+ Converter.fixString(ODC_BaseNet)			+ "'," +	
		"ODC_FixedUnit='"		+ Converter.fixString(ODC_FixedUnit)		+ "'," +
		"ODC_SaleCOS='"			+ Converter.fixString(ODC_SaleCOS)			+ "'," +	
		"ODC_Amount="			+ NumberUtil.toString(ODC_Amount)			+ "," +	
		"ODC_MaxAmount="		+ NumberUtil.toString(ODC_MaxAmount)		+ "," +			
		"ODC_BeforeTax='"		+ Converter.fixString(ODC_BeforeTax)		+ "'," +	
		"ODC_BeforeFreight='"	+ Converter.fixString(ODC_BeforeFreight)	+ "'," +	
		"ODC_BeforeDiscount='"	+ Converter.fixString(ODC_BeforeDiscount)	+ "'," +			
		"ODC_Percent="			+ NumberUtil.toString(ODC_Percent)			+ "," +	
		"ODC_Extension="		+ NumberUtil.toString(ODC_Extension)		+ "," +	
		"ODC_ApplytoCust='"		+ Converter.fixString(ODC_ApplytoCust)		+ "'," +			
		"ODC_ApplytoSupplier='"	+ Converter.fixString(ODC_ApplytoSupplier)	+ "'," +					
		"ODC_GLAccountNum="		+ ODC_GLAccountNum.ToString()				+ "," +	   		
		"ODC_OnSalePaidInv='"	+ Converter.fixString(ODC_OnSalePaidInv)	+ "'," +			
		"ODC_Paid='"			+ Converter.fixString(ODC_Paid)				+ "'," +	
		"ODC_Received='"		+ Converter.fixString(ODC_Received)			+ "'" +	
		
	" where " +
		"OH_ID="			+ OH_ID	+ " and " +					
		"ODC_ItemNum="		+ ODC_ItemNum	+ " and " +
		"ODC_ItemChgNum="	+ ODC_ItemChgNum;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <update>: " + de.Message,de);
	}
}

public override 
void delete(){
	try{
		string sql ="delete from orderdtlcharges where "	+					
					"OH_ID="			+ OH_ID	+		" and " +					
					"ODC_ItemNum="		+ ODC_ItemNum	+ " and " +
					"ODC_ItemChgNum="	+ ODC_ItemChgNum;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <delete>: " + de.Message,de);
	}
}
public void deleteAllFromHeader()
{
	try
	{
		string sql ="delete from orderdtlcharges where " +										
					"OH_ID="	+ OH_ID;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <deleteAllFromHeader>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <deleteAllFromHeader>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteAllFromHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <deleteAllFromHeader>: " + de.Message,de);
	}
}

public 
void deleteFromDetail(){
	try{
		string sql ="delete from orderdtlcharges where " +										
					"OH_ID="		+ OH_ID + " and " +
					"ODC_ItemNum="	+ ODC_ItemNum;
					
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <deleteFromDetail>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <deleteFromDetail>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteFromDetail> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBase <deleteFromDetail>: " + de.Message,de);
	}
}


public void setOH_ID (int OH_ID){
	this.OH_ID =OH_ID;
}
public void setODC_ID (int ODC_ID){
	this.ODC_ID =ODC_ID;
}
public void setODC_Db (string ODC_Db){
	this.ODC_Db = ODC_Db;
}
public void setODC_OrderNum (	int ODC_OrderNum){
	this.ODC_OrderNum = ODC_OrderNum;
}
public void setODC_ItemNum (int ODC_ItemNum){
	this.ODC_ItemNum = ODC_ItemNum;
}
public void setODC_ItemChgNum (int ODC_ItemChgNum){
	this.ODC_ItemChgNum = ODC_ItemChgNum;
}
public void setODC_ChargeCode (string ODC_ChargeCode){
	this.ODC_ChargeCode = ODC_ChargeCode;
}
	public void setODC_ChargeDesc (string ODC_ChargeDesc){
this.ODC_ChargeDesc = ODC_ChargeDesc;
}

public void setODC_ChargeType(string ODC_ChargeType){
	this.ODC_ChargeType = ODC_ChargeType;
}

public void setODC_ChargeTypeSub(string ODC_ChargeTypeSub){
	this.ODC_ChargeTypeSub = ODC_ChargeTypeSub;
}	

public void setODC_BaseNet (string ODC_BaseNet){
this.ODC_BaseNet = ODC_BaseNet;
}
public void setODC_FixedUnit (string ODC_FixedUnit){
this.ODC_FixedUnit = ODC_FixedUnit;
}

public void setODC_SaleCOS (string	ODC_SaleCOS){
this.ODC_SaleCOS = ODC_SaleCOS;
}
public void setODC_Amount (double ODC_Amount){
this.ODC_Amount = ODC_Amount;
}
public void setODC_MaxAmount (double ODC_MaxAmount){
this.ODC_MaxAmount = ODC_MaxAmount;
}
public void setODC_BeforeTax (string ODC_BeforeTax){
this.ODC_BeforeTax = ODC_BeforeTax;
}
public void setODC_BeforeFreight (string ODC_BeforeFreight){
this.ODC_BeforeFreight = ODC_BeforeFreight;
}
public void setODC_BeforeDiscount (string ODC_BeforeDiscount){
this.ODC_BeforeDiscount = ODC_BeforeDiscount;
}
public void setODC_Percent (double ODC_Percent){
this.ODC_Percent = ODC_Percent;
}
public void setODC_Extension (double ODC_Extension){
this.ODC_Extension = ODC_Extension;
}

public void setODC_ApplytoCust (string ODC_ApplytoCust){
this.ODC_ApplytoCust = ODC_ApplytoCust;
}
public void setODC_ApplytoSupplier (string ODC_ApplytoSupplier){
this.ODC_ApplytoSupplier = ODC_ApplytoSupplier;
}
public void setODC_GLAccountNum (long ODC_GLAccountNum){
this.ODC_GLAccountNum = ODC_GLAccountNum;
}
public void setODC_OnSalePaidInv (string ODC_OnSalePaidInv){
this.ODC_OnSalePaidInv = ODC_OnSalePaidInv;
}
public void setODC_Paid (string ODC_Paid){
this.ODC_Paid = ODC_Paid;
}
public void setODC_Received (string ODC_Received){
this.ODC_Received = ODC_Received;
}
	
public int getODC_ID(){
	return ODC_ID;
}
public string getODC_Db(){
	return ODC_Db;
}
public int getODC_OrderNum(){
	return ODC_OrderNum;
}
public int getODC_ItemNum(){
	return ODC_ItemNum;
}
public int getODC_ItemChgNum(){
	return ODC_ItemChgNum;
}
public string getODC_ChargeCode(){
	return ODC_ChargeCode;
}
public string getODC_ChargeDesc(){
	return ODC_ChargeDesc;
}

public string getODC_ChargeType(){
	return ODC_ChargeType;
}

public string getODC_ChargeTypeSub(){
	return ODC_ChargeTypeSub;
}	

public string getODC_BaseNet(){
	return ODC_BaseNet;
}
public string getODC_FixedUnit (){
	return this.ODC_FixedUnit;
}

public
string	getODC_SaleCOS(){
	return ODC_SaleCOS;
}
public double getODC_Amount(){
	return ODC_Amount;
}
public double getODC_MaxAmount(){
	return ODC_MaxAmount;
}
public string getODC_BeforeTax(){
	return ODC_BeforeTax;
}
public string getODC_BeforeFreight(){
	return ODC_BeforeFreight;
}
public string getODC_BeforeDiscount(){
	return ODC_BeforeDiscount;
}
public double getODC_Percent(){
	return ODC_Percent;
}
public double getODC_Extension(){
	return ODC_Extension;
}

public string getODC_ApplytoCust(){
	return ODC_ApplytoCust;
}
public string getODC_ApplytoSupplier(){
	return ODC_ApplytoSupplier;
}
public long getODC_GLAccountNum(){
	return ODC_GLAccountNum;
}
public string getODC_OnSalePaidInv(){
	return ODC_OnSalePaidInv;
}
public string getODC_Paid(){
	return ODC_Paid;
}
public string getODC_Received(){
	return ODC_Received;
}
public int getOH_ID (){
	return OH_ID;
}

} // class
//
} // namespace
