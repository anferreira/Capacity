using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderDtlRelDataBase : GenericDataBaseElement{

private int OH_ID;
private int	ODR_ID;
private string	ODR_Db;
private int		ODR_ItemNum;
private int		ODR_ItemNumRel;
private string	ODR_Company;
private string	ODR_Plant;
private int		ODR_OrderNum;
private string ODR_OrgID;
private string ODR_OrgItemNum;
private string ODR_OrgItemNumRel;
private string ODR_ShipToNum;
private string ODR_ShipToName;
private string ODR_ShipToAdd1;
private string ODR_ShipToAdd2;
private string ODR_ShipToAdd3;
private string ODR_ShipToAdd4;
private string ODR_ShipToAdd5;
private string ODR_ShipToAdd6;
private string ODR_ShipToZipCode;
private string ODR_PhoneNum;
private string ODR_Attention;
private string ODR_CustPO;
private double ODR_QtyOrd;
private string ODR_QtyOrdUom;
private double ODR_QtyOrdInv;
private string ODR_QtyOrdInvUom;
private double ODR_QtyShipped;
private double ODR_QtyShippedInv;
private double ODR_QtyBO;
private double ODR_QtyBOInv;
private DateTime OD_DatePromise;
private DateTime OD_DateRequest;
private DateTime OD_DateShipping;
private DateTime OD_DateCancel;
private DateTime OD_DateChanged;
private DateTime OD_DateNotBefore;
private DateTime OD_DateAdded;
private int	ODR_OrderDtlID;
private string ODR_ProdDescription;
private string ODR_Condition;
private string ODR_Project;

	
public OrderDtlRelDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	try{	
		string sql ="select * from orderdtlrel where " +
					"OH_ID="		+ OH_ID		+ " and " + 
					"ODR_ItemNum="  + ODR_ItemNum;
																
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <read>: " + de.Message,de);
	}
}

public int getMaxItemFromDetailRel()
{
	int iresultado=-1;
	try
	{				
		string sql ="select max(ODR_ItemNumRel) from orderdtlrel " +
					"OH_ID="		+ OH_ID + " and " + 
					"ODR_ItemNum="  + ODR_ItemNum;
					
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
	}
	catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <getMaxItemFromDetailRel>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <getMaxItemFromDetailRel>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getMaxItemFromDetailRel> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <getMaxItemFromDetailRel>: " + de.Message,de);
	}
	return iresultado;
}

public 
bool exists(){
	try{
		bool returnValue = false;
		string sql ="select * from orderdtlrel where "	+			
					"OH_ID="			+ OH_ID	+ " and " + 
					"ODR_ItemNum="		+ ODR_ItemNum	+ " and " +	
					"ODR_ItemNumRel="	+ ODR_ItemNumRel;

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <exists>: " + de.Message,de);
	}
}
public 
void load(NotNullDataReader reader){

	this.OH_ID				= reader.GetInt32("OH_ID");
	this.ODR_ID				= reader.GetInt32("ODR_ID");
	this.ODR_Db				= reader.GetString("ODR_Db");
	this.ODR_Company		= reader.GetString("ODR_Company");
	this.ODR_Plant			= reader.GetString("ODR_Plant");
	this.ODR_OrderNum		= reader.GetInt32("ODR_OrderNum");
	this.ODR_ItemNum		= reader.GetInt32("ODR_ItemNum");
	this.ODR_ItemNumRel		= reader.GetInt32("ODR_ItemNumRel");
	this.ODR_OrgID			= reader.GetString("ODR_OrgID");
	this.ODR_OrgItemNum		= reader.GetString("ODR_OrgItemNum");
	this.ODR_OrgItemNumRel	= reader.GetString("ODR_OrgItemNumRel");
	this.ODR_ShipToNum		= reader.GetString("ODR_ShipToNum");
	this.ODR_ShipToName		= reader.GetString("ODR_ShipToName");
	this.ODR_ShipToAdd1		= reader.GetString("ODR_ShipToAdd1");
	this.ODR_ShipToAdd2		= reader.GetString("ODR_ShipToAdd2");
	this.ODR_ShipToAdd3		= reader.GetString("ODR_ShipToAdd3");
	this.ODR_ShipToAdd4		= reader.GetString("ODR_ShipToAdd4");
	this.ODR_ShipToAdd5		= reader.GetString("ODR_ShipToAdd5");
	this.ODR_ShipToAdd6		= reader.GetString("ODR_ShipToAdd6");
	this.ODR_ShipToZipCode		= reader.GetString("ODR_ShipToZipCode");
	this.ODR_PhoneNum		= reader.GetString("ODR_PhoneNum");
	this.ODR_Attention		= reader.GetString("ODR_Attention");
	this.ODR_CustPO			= reader.GetString("ODR_CustPO");
	this.ODR_QtyOrd			= decimal.ToDouble(reader.GetDecimal("ODR_QtyOrd"));
	this.ODR_QtyOrdUom		= reader.GetString("ODR_QtyOrdUom");
	this.ODR_QtyOrdInv		= decimal.ToDouble(reader.GetDecimal("ODR_QtyOrdInv"));
	this.ODR_QtyOrdInvUom	= reader.GetString("ODR_QtyOrdInvUom");
	this.ODR_QtyShipped		= decimal.ToDouble(reader.GetDecimal("ODR_QtyShipped"));
	this.ODR_QtyShippedInv	= decimal.ToDouble(reader.GetDecimal("ODR_QtyShippedInv"));
	this.ODR_QtyBO			= decimal.ToDouble(reader.GetDecimal("ODR_QtyBO"));
	this.ODR_QtyBOInv		= decimal.ToDouble(reader.GetDecimal("ODR_QtyBOInv"));
	this.OD_DatePromise		= reader.GetDateTime("OD_DatePromise");
	this.OD_DateRequest		= reader.GetDateTime("OD_DateRequest");
	this.OD_DateShipping	= reader.GetDateTime("OD_DateShipping");
	this.OD_DateCancel		= reader.GetDateTime("OD_DateCancel");
	this.OD_DateChanged		= reader.GetDateTime("OD_DateChanged");
	this.OD_DateNotBefore	= reader.GetDateTime("OD_DateNotBefore");
	this.OD_DateAdded		= reader.GetDateTime("OD_DateAdded");
	this.ODR_OrderDtlID	= reader.GetInt32("ODR_OrderDtlID");
	this.ODR_ProdDescription= reader.GetString("ODR_ProdDescription");
	this.ODR_Condition = reader.GetString("ODR_Condition");
	this.ODR_Project = reader.GetString("ODR_Project");
}

public override 
void write(){
	try{		
		//OD_ItemNum sequence
		string sql = "insert into orderdtlrel(" + 		
		"OH_ID,"+
		"ODR_Db," +
		"ODR_Company," +
		"ODR_Plant," +
		"ODR_OrderNum," +
		"ODR_ItemNum," +
		"ODR_ItemNumRel," +
		"ODR_OrgID," +
		"ODR_OrgItemNum," +
		"ODR_OrgItemNumRel," +
		"ODR_ShipToNum," +
		"ODR_ShipToName," +
		"ODR_ShipToAdd1," +
		"ODR_ShipToAdd2," +
		"ODR_ShipToAdd3," +
		"ODR_ShipToAdd4," +
		"ODR_ShipToAdd5," +
		"ODR_ShipToAdd6," +
		"ODR_ShipToZipCode," +
		"ODR_PhoneNum," +
		"ODR_Attention," +
		"ODR_CustPO," +
		"ODR_QtyOrd," +
		"ODR_QtyOrdUom," +
		"ODR_QtyOrdInv," +
		"ODR_QtyOrdInvUom," +
		"ODR_QtyShipped," +
		"ODR_QtyShippedInv," +
		"ODR_QtyBO," +
		"ODR_QtyBOInv," +
		"OD_DatePromise," +
		"OD_DateRequest," +
		"OD_DateShipping," +
		"OD_DateCancel," +
		"OD_DateChanged," +
		"OD_DateNotBefore," +
		"OD_DateAdded," +
		"ODR_OrderDtlID," +
		"ODR_ProdDescription," +
		"ODR_Condition, " +
		"ODR_Project)" +
			
		" values ("+		
		OH_ID.ToString() + "," +
		"'" + Converter.fixString(ODR_Db) + "'," + 
		"'" + Converter.fixString(ODR_Company) + "'," + 
		"'" + Converter.fixString(ODR_Plant) + "'," + 
		ODR_OrderNum.ToString() + "," + 
		ODR_ItemNum.ToString() + "," + 
		ODR_ItemNumRel.ToString() + "," + 
		"'" + Converter.fixString(ODR_OrgID)+ "'," + 
		"'" + Converter.fixString(ODR_OrgItemNum)+ "'," + 
		"'" + Converter.fixString(ODR_OrgItemNumRel)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToNum)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToName)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToAdd1)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToAdd2)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToAdd3)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToAdd4)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToAdd5)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToAdd6)+ "'," + 
		"'" + Converter.fixString(ODR_ShipToZipCode)+ "'," + 
		"'" + Converter.fixString(ODR_PhoneNum)+ "'," + 
		"'" + Converter.fixString(ODR_Attention)+ "'," + 
		"'" + Converter.fixString(ODR_CustPO)+ "'," + 
		NumberUtil.toString(ODR_QtyOrd) + "," + 
		"'" + Converter.fixString(ODR_QtyOrdUom)+ "'," + 
		NumberUtil.toString(ODR_QtyOrdInv) + "," +
		"'" + Converter.fixString(ODR_QtyOrdInvUom) + "'," + 
		NumberUtil.toString(ODR_QtyShipped)+ "," + 
		NumberUtil.toString(ODR_QtyShippedInv)+ "," + 
		NumberUtil.toString(ODR_QtyBO)+ "," + 
		NumberUtil.toString(ODR_QtyBOInv)+ "," + 		
		"'" + DateUtil.getCompleteDateRepresentation(OD_DatePromise) + "'," + 
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateRequest) + "'," + 
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateShipping) + "'," + 
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateCancel) + "'," + 
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateChanged) + "'," + 
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateNotBefore) + "'," + 
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateAdded)+ "'," + 
		ODR_OrderDtlID.ToString() + "," +
		"'" + Converter.fixString(ODR_ProdDescription) + "', " +
		"'" + Converter.fixString(ODR_Condition) +"' , " +
		"'" + Converter.fixString(ODR_Project) +"')"; 		

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <write>: " + de.Message,de);
	}
}

public override 
void update(){
	try{
		
		string sql = "update orderdtlrel set " +		
		"ODR_Db='"				+ Converter.fixString(ODR_Db)			+ "'," + 
		"ODR_Company='"			+ Converter.fixString(ODR_Company)		+ "'," + 
		"ODR_OrderNum="			+ ODR_OrderNum.ToString()				+ ","  +	
		"ODR_Plant='"			+ Converter.fixString(ODR_Plant)		+ "'," + 		
		"ODR_OrgID='"			+ Converter.fixString(ODR_OrgID)		+ "'," + 
		"ODR_OrgItemNum='"		+ Converter.fixString(ODR_OrgItemNum)	+ "'," + 
		"ODR_OrgItemNumRel='"	+ Converter.fixString(ODR_OrgItemNumRel)+ "'," + 
		"ODR_ShipToNum='"		+ Converter.fixString(ODR_ShipToNum)		+ "'," + 
		"ODR_ShipToName='"		+ Converter.fixString(ODR_ShipToName)	+ "'," + 
		"ODR_ShipToAdd1='"		+ Converter.fixString(ODR_ShipToAdd1)	+ "'," + 
		"ODR_ShipToAdd2='"		+ Converter.fixString(ODR_ShipToAdd2)	+ "'," + 
		"ODR_ShipToAdd3='"		+ Converter.fixString(ODR_ShipToAdd3)	+ "'," + 
		"ODR_ShipToAdd4='"		+ Converter.fixString(ODR_ShipToAdd4)	+ "'," + 
		"ODR_ShipToAdd5='"		+ Converter.fixString(ODR_ShipToAdd5)	+ "'," + 
		"ODR_ShipToAdd6='"		+ Converter.fixString(ODR_ShipToAdd6)	+ "'," + 
		"ODR_ShipToZipCode='"		+ Converter.fixString(ODR_ShipToZipCode)	+ "'," + 
		"ODR_PhoneNum='"		+ Converter.fixString(ODR_PhoneNum)		+ "'," + 
		"ODR_Attention='"		+ Converter.fixString(ODR_Attention)	+ "'," + 
		"ODR_CustPO='"			+ Converter.fixString(ODR_CustPO)		+ "'," + 
		"ODR_QtyOrd="			+ NumberUtil.toString(ODR_QtyOrd)		+ "," + 
		"ODR_QtyOrdUom='"		+ Converter.fixString(ODR_QtyOrdUom)	+ "'," + 
		"ODR_QtyOrdInv="		+ NumberUtil.toString(ODR_QtyOrdInv)	+ "," +
		"ODR_QtyOrdInvUom='"	+ Converter.fixString(ODR_QtyOrdInvUom) + "'," + 
		"ODR_QtyShipped="		+ NumberUtil.toString(ODR_QtyShipped)	+ "," + 
		"ODR_QtyShippedInv="	+ NumberUtil.toString(ODR_QtyShippedInv)+ "," + 
		"ODR_QtyBO="			+ NumberUtil.toString(ODR_QtyBO)		+ "," + 
		"ODR_QtyBOInv="			+ NumberUtil.toString(ODR_QtyBOInv)		+ "," + 		
		"OD_DatePromise='"		+ DateUtil.getCompleteDateRepresentation(OD_DatePromise) + "'," + 
		"OD_DateRequest='"		+ DateUtil.getCompleteDateRepresentation(OD_DateRequest) + "'," + 
		"OD_DateShipping='"		+ DateUtil.getCompleteDateRepresentation(OD_DateShipping) + "'," + 
		"OD_DateCancel='"		+ DateUtil.getCompleteDateRepresentation(OD_DateCancel) + "'," + 
		"OD_DateChanged='"		+ DateUtil.getCompleteDateRepresentation(OD_DateChanged) + "'," + 
		"OD_DateNotBefore='"	+ DateUtil.getCompleteDateRepresentation(OD_DateNotBefore) + "'," + 
		"OD_DateAdded='"		+ DateUtil.getCompleteDateRepresentation(OD_DateAdded)+ "'," + 
		"ODR_OrderDtlID="		+ ODR_OrderDtlID.ToString()				+ "," +
		"ODR_ProdDescription='" + Converter.fixString(ODR_ProdDescription)+  "', " +				
		"ODR_Condition  = '" + Converter.fixString(ODR_Condition) +"', " +
		"ODR_Project = '" + Converter.fixString(ODR_Project) +"' " + 
	" where " +		
		"OH_ID="				+ OH_ID			+ " and " +
		"ODR_ItemNum ="			+ ODR_ItemNum	+ " and " +
		"ODR_ItemNumRel="		+ ODR_ItemNumRel;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <update>: " + de.Message,de);
	}
}


public 
void deleteFromDetail(){
	try{
		string sql ="delete from orderdtlrel where " +					
					"OH_ID= "			+ OH_ID	+ " and " +
					"ODR_ItemNum = "	+ ODR_ItemNum;
					
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <deleteFromDetail>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <deleteFromDetail>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteFromDetail> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <deleteFromDetail>: " + de.Message,de);
	}
}

public override 
void delete(){
	try{
		string sql ="delete from orderdtlrel where " +					
					"OH_ID= "			+ OH_ID	+ " and " +
					"ODR_ItemNum = "	+ ODR_ItemNum	+ " and " +
					"ODR_ItemNumRel="	+ ODR_ItemNumRel;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <delete>: " + de.Message,de);
	}
}

public 
void updateAllFromHeader(){
	try{
		//OD_ItemNum sequence
		string sql = "update orderdtlrel set " +		
		"ODR_Company='"			+ Converter.fixString(ODR_Company)		+ "'," + 
		"ODR_Plant='"			+ Converter.fixString(ODR_Plant)		+ "'," + 		
		"ODR_ShipToNum='"		+ Converter.fixString(ODR_ShipToNum)		+ "'," + 
		"ODR_ShipToName='"		+ Converter.fixString(ODR_ShipToName)	+ "'," + 
		"ODR_ShipToAdd1='"		+ Converter.fixString(ODR_ShipToAdd1)	+ "'," + 
		"ODR_ShipToAdd2='"		+ Converter.fixString(ODR_ShipToAdd2)	+ "'," + 
		"ODR_ShipToAdd3='"		+ Converter.fixString(ODR_ShipToAdd3)	+ "'," + 
		"ODR_ShipToAdd4='"		+ Converter.fixString(ODR_ShipToAdd4)	+ "'," + 
		"ODR_ShipToAdd5='"		+ Converter.fixString(ODR_ShipToAdd5)	+ "'," + 
		"ODR_ShipToAdd6='"		+ Converter.fixString(ODR_ShipToAdd6)	+ "'," + 
		"ODR_ShipToZipCode='"		+ Converter.fixString(ODR_ShipToZipCode)	+ "'," + 
		"ODR_PhoneNum='"		+ Converter.fixString(ODR_PhoneNum)		+ "'," + 
		"ODR_Attention='"		+ Converter.fixString(ODR_Attention)	+ "'," + 
		"ODR_CustPO='"			+ Converter.fixString(ODR_CustPO)		+ "'," + 
		"ODR_OrderNum="			+ ODR_OrderNum.ToString()				+ 
	" where " +		
		"OH_ID="				+ OH_ID;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <updateAllFromHeader>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <updateAllFromHeader>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <updateAllFromHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <updateAllFromHeader>: " + de.Message,de);
	}
}

public  
void deleteAllFromHeader(){
	try{
		string sql ="delete from orderdtlrel where " +					
					"OH_ID= "	+ OH_ID;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <deleteAllFromHeader>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <deleteAllFromHeader>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteAllFromHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <deleteAllFromHeader>: " + de.Message,de);
	}
}

public void setOH_ID(int OH_ID)
{
	this.OH_ID = OH_ID;
}
public void setODR_ID(int	ODR_ID)
{
	this.ODR_ID = ODR_ID;
}
public void setODR_Db(string ODR_Db)
{
	this.ODR_Db = ODR_Db;
}
public void setODR_Company(string ODR_Company)
{
	this.ODR_Company = ODR_Company;
}

public void setODR_Plant(string ODR_Plant)
{
	this.ODR_Plant = ODR_Plant;
}

public void setODR_OrderNum(int ODR_OrderNum)
{
	this.ODR_OrderNum = ODR_OrderNum;
}
public void setODR_ItemNum(int ODR_ItemNum)
{
	this.ODR_ItemNum = ODR_ItemNum;
}
public void setODR_ItemNumRel(int ODR_ItemNumRel)
{
	this.ODR_ItemNumRel = ODR_ItemNumRel;
}
public void setODR_OrgID(string ODR_OrgID)
{
	this.ODR_OrgID = ODR_OrgID;
}
public void setODR_OrgItemNum(string ODR_OrgItemNum)
{
	this.ODR_OrgItemNum = ODR_OrgItemNum;
}
public void setODR_OrgItemNumRel(string ODR_OrgItemNumRel)
{
	this.ODR_OrgItemNumRel = ODR_OrgItemNumRel;
}	

public void setODR_ShipToNum(string ODR_ShipToNum)
{
	this.ODR_ShipToNum = ODR_ShipToNum;
}

public void setODR_ShipToName(string ODR_ShipToName)
{
	this.ODR_ShipToName = ODR_ShipToName;
}

public void setODR_ShipToAdd1(string ODR_ShipToAdd1)
{
	this.ODR_ShipToAdd1 = ODR_ShipToAdd1;
}

public void setODR_ShipToAdd2(string ODR_ShipToAdd2)
{
	this.ODR_ShipToAdd2 = ODR_ShipToAdd2;
}
public void setODR_ShipToAdd3(string ODR_ShipToAdd3)
{
	this.ODR_ShipToAdd3 = ODR_ShipToAdd3;
}

public void setODR_ShipToAdd4(string ODR_ShipToAdd4)
{
	this.ODR_ShipToAdd4 = ODR_ShipToAdd4;
}
public void setODR_ShipToAdd5(string ODR_ShipToAdd5)
{
	this.ODR_ShipToAdd5 = ODR_ShipToAdd5;
}
public void setODR_ShipToAdd6(string ODR_ShipToAdd6)
{
	this.ODR_ShipToAdd6 = ODR_ShipToAdd6;
}
public void setODR_ShipToZipCode(string ODR_ShipToZipCode)
{
	this.ODR_ShipToZipCode = ODR_ShipToZipCode;
}
public void setODR_PhoneNum(string ODR_PhoneNum)
{
	this.ODR_PhoneNum = ODR_PhoneNum;
}
public void setODR_Attention(string ODR_Attention)
{
	this.ODR_Attention = ODR_Attention;
}

public void setODR_CustPO(string ODR_CustPO)
{
	this.ODR_CustPO = ODR_CustPO;
}

public void setODR_QtyOrd(double ODR_QtyOrd)
{
	this.ODR_QtyOrd = ODR_QtyOrd;
}

public void setODR_QtyOrdUom(string ODR_QtyOrdUom)
{
	this.ODR_QtyOrdUom = ODR_QtyOrdUom;
}

public void setODR_QtyOrdInv(double ODR_QtyOrdInv)
{
	this.ODR_QtyOrdInv = ODR_QtyOrdInv;
}

public void setODR_QtyOrdInvUom(string ODR_QtyOrdInvUom)
{
	this.ODR_QtyOrdInvUom = ODR_QtyOrdInvUom;
}

public void setODR_QtyShipped(double ODR_QtyShipped)
{
	this.ODR_QtyShipped = ODR_QtyShipped;
}
public void setODR_QtyShippedInv(double ODR_QtyShippedInv)
{
	this.ODR_QtyShippedInv = ODR_QtyShippedInv;
}
public void setODR_QtyBO(double ODR_QtyBO)
{
	this.ODR_QtyBO = ODR_QtyBO;
}	
public void setODR_QtyBOInv(double ODR_QtyBOInv)
{
	this.ODR_QtyBOInv = ODR_QtyBOInv;
}
public void setOD_DatePromise(DateTime OD_DatePromise)
{
	this.OD_DatePromise = OD_DatePromise;
}
	
public void setOD_DateRequest(DateTime OD_DateRequest)
{
	this.OD_DateRequest = OD_DateRequest;
}
	 
public void setOD_DateShipping(DateTime OD_DateShipping)
{
	this.OD_DateShipping = OD_DateShipping;
}

public void setOD_DateCancel(DateTime OD_DateCancel)
{
	this.OD_DateCancel = OD_DateCancel;
}
public void setOD_DateChanged(DateTime OD_DateChanged)
{
	this.OD_DateChanged = OD_DateChanged;
}
public void setOD_DateNotBefore(DateTime OD_DateNotBefore)
{
	this.OD_DateNotBefore = OD_DateNotBefore;
}
public void setOD_DateAdded(DateTime OD_DateAdded)
{
	this.OD_DateAdded = OD_DateAdded;
}
public void setODR_OrderDtlID(int ODR_OrderDtlID)
{
	this.ODR_OrderDtlID = ODR_OrderDtlID;
}
public void setODR_ProdDescription(string ODR_ProdDescription)
{
	this.ODR_ProdDescription = ODR_ProdDescription;
}	

public 
void setODR_Condition(string ODR_Condition){
	this.ODR_Condition = ODR_Condition;
}		

public 
void setODR_Project(string ODR_Project){
	this.ODR_Project = ODR_Project;
}		

public int getOH_ID()
{
	return OH_ID;
}

public int getODR_ID()
{
	return ODR_ID;
}
public string getODR_Db()
{
	return ODR_Db;
}
public string getODR_Company()
{
	return ODR_Company;
}

public string getODR_Plant()
{
	return ODR_Plant;
}

public int getODR_OrderNum()
{
	return ODR_OrderNum;
}

public int getODR_ItemNum()
{
	return ODR_ItemNum;
}
public int getODR_ItemNumRel()
{
	return ODR_ItemNumRel;
}
public string getODR_OrgID()
{
	return ODR_OrgID;
}
public string getODR_OrgItemNum()
{
	return ODR_OrgItemNum;
}
public string getODR_OrgItemNumRel()
{
	return ODR_OrgItemNumRel;
}	

public string getODR_ShipToNum()
{
	return ODR_ShipToNum;
}

public string getODR_ShipToName()
{
	return ODR_ShipToName;
}

public string getODR_ShipToAdd1()
{
	return ODR_ShipToAdd1;
}

public string getODR_ShipToAdd2()
{
	return ODR_ShipToAdd2;
}
public string getODR_ShipToAdd3()
{
	return ODR_ShipToAdd3;
}

public string getODR_ShipToAdd4()
{
	return ODR_ShipToAdd4;
}
public string getODR_ShipToAdd5()
{
	return ODR_ShipToAdd5;
}
public string getODR_ShipToAdd6()
{
	return ODR_ShipToAdd6;
}
public string getODR_ShipToZipCode()
{
	return ODR_ShipToZipCode;
}
public string getODR_PhoneNum()
{
	return ODR_PhoneNum;
}
public string getODR_Attention()
{
	return ODR_Attention;
}

public string getODR_CustPO()
{
	return ODR_CustPO;
}

public double getODR_QtyOrd()
{
	return ODR_QtyOrd;
}

public string getODR_QtyOrdUom()
{
	return ODR_QtyOrdUom;
}

public double getODR_QtyOrdInv()
{
	return ODR_QtyOrdInv;
}

public string getODR_QtyOrdInvUom()
{
	return ODR_QtyOrdInvUom;
}

public double getODR_QtyShipped()
{
	return ODR_QtyShipped;
}
public double getODR_QtyShippedInv()
{
	return ODR_QtyShippedInv;
}
public double getODR_QtyBO()
{
	return ODR_QtyBO;
}	
public double getODR_QtyBOInv()
{
	return ODR_QtyBOInv;
}
public DateTime getOD_DatePromise()
{
	return OD_DatePromise;
}
	
public DateTime getOD_DateRequest()
{
	return OD_DateRequest;
}
	 
public DateTime getOD_DateShipping()
{
	return OD_DateShipping;
}

public DateTime getOD_DateCancel()
{
	return OD_DateCancel;
}
public DateTime getOD_DateChanged()
{
	return OD_DateChanged;
}
public DateTime getOD_DateNotBefore()
{
	return OD_DateNotBefore;
}
public DateTime getOD_DateAdded()
{
	return OD_DateAdded;
}
public int getODR_OrderDtlID()
{
	return ODR_OrderDtlID;
}
public string getODR_ProdDescription()
{
	return ODR_ProdDescription;
}	

public string getODR_Condition(){
	return ODR_Condition;
}	

public string getODR_Project(){
	return ODR_Project;
}	

public
	string getKeyHash()
{
	string sret= this.OH_ID + "," + this.ODR_OrgItemNum + "," + this.ODR_OrgItemNumRel;
	return sret;	
}


} // class
//
} // namespace
