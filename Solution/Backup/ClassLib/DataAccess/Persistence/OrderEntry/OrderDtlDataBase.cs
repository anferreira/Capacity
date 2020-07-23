using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class OrderDtlDataBase : GenericDataBaseElement{
		
private	int OH_ID;
private	int OD_ID;
private	string OD_Db;
private	int OD_ItemNum;	
private	string OD_Company;
private	string OD_Plant;
private	int OD_OrderNum;
private	string OD_ErpOrderNum;
private	int	   OD_ErpOrderItemNum;
private	string OD_OrgID;
private	string OD_OrgItemNum;
private	string OD_ProdID;
private	string	OD_ProdDescription;
private	int	OD_Seq;
private	string OD_InternalRef;
private	string OD_CustPart;
private	string OD_CustPO;
private	double OD_QtyOrdSum;
private	double OD_QtyShippedSum;
private	string OD_QtyOrdUom;
private	double OD_UnitPrice;
private	string OD_UnitPriceUom;
private	double OD_ItemNetTotal;
private	DateTime OD_DateAdded;
private	double OD_TotalDiscounts;
private	double OD_TotalPromo;
private	double OD_TotalRoyalty;
private	double OD_TotalFreight;
private	double OD_TotalTax;
private	double OD_TotalStTax;
private	double OD_TotalFedTax;	
private	double OD_QtyPackSize;
private	double OD_Cost;
private string OD_Condition;
private string OD_Project;
	
public OrderDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
bool readIfProductSold(string sprodId){
	bool bresult=false;

	try{	
		string sql ="select * from orderdtl where "	+ 					
					"OD_ProdID = '"	+ Converter.fixString(sprodId) + "'" +
					" order by OD_DateAdded Desc";
							
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		bresult = reader.Read();
		if (bresult)
			load(reader);

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <read>: " + de.Message,de);
	}
	return bresult;
}

public 
void read(){
	try{	
		string sql ="select * from orderdtl where "	+ 					
					"OH_ID = "		+ OH_ID	+ " and " +
					"OD_ItemNum = "	+ OD_ItemNum;
			
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <read>: " + de.Message,de);
	}
}

public int getMaxOrderLine()
{
	int iresultado=-1;
	try
	{		
		string sql = "select max(OD_ItemNum) from orderdtl where " +					
					" OH_ID = "	+ OH_ID;

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
		throw new PersistenceException("Error in class OrderDtlDataBase <getMaxOrderLine>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <getMaxOrderLine>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getMaxOrderLine> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <getMaxOrderLine>: " + de.Message,de);
	}
	return iresultado;
}


public 
int getMaxOrderLineNumber()
{
	try
	{
		int		ireturnValue = -1;
		string	sql =	"select max(OD_ItemNum) from orderdtl where " +									
						" OH_ID = "	+ OH_ID;
						

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
		{
			#if POCKET_PC
 				ireturnValue = (int) reader.GetInt64(0);// cast to int, because OD_ItemNum is int, but to read from the database we must use GetInt64
			#else
				ireturnValue = reader.GetInt32(0);
			#endif			
		}

		reader.Close();

		return ireturnValue;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <getMaxOrderLineNumber>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <getMaxOrderLineNumber>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getMaxOrderLineNumber> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <getMaxOrderLineNumber>: " + de.Message,de);
	}
}


public 
bool exists(){
	try{
		bool returnValue = false;
		string sql ="select * from orderdtl where "	+								
					" OH_ID="		+ OH_ID		+ " and "	+			
					" OD_ItemNum="	+ OD_ItemNum;		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <exists>: " + de.Message,de);
	}
}

public 
void load(NotNullDataReader reader){

	this.OH_ID			= reader.GetInt32("OH_ID");
	this.OD_ID			= reader.GetInt32("OD_ID");
	this.OD_Db			= reader.GetString("OD_Db");
	this.OD_Company		= reader.GetString("OD_Company");
	this.OD_Plant		= reader.GetString("OD_Plant");
	this.OD_OrderNum	= reader.GetInt32("OD_OrderNum");
	this.OD_ItemNum		= reader.GetInt32("OD_ItemNum");
	this.OD_ProdID		= reader.GetString("OD_ProdID");
	this.OD_ProdDescription = reader.GetString("OD_ProdDescription");
	this.OD_Seq			=  reader.GetInt32("OD_Seq");
	this.OD_InternalRef = reader.GetString("OD_InternalRef");
	this.OD_CustPart    = reader.GetString("OD_CustPart");
	this.OD_CustPO		= reader.GetString("OD_CustPO");
	this.OD_QtyOrdSum		= decimal.ToDouble(reader.GetDecimal("OD_QtyOrdSum"));
	this.OD_QtyShippedSum	= decimal.ToDouble(reader.GetDecimal("OD_QtyShippedSum"));
	this.OD_QtyOrdUom		= reader.GetString("OD_QtyOrdUom");
	this.OD_UnitPrice		= decimal.ToDouble(reader.GetDecimal("OD_UnitPrice"));
	this.OD_UnitPriceUom	= reader.GetString("OD_UnitPriceUom");
	this.OD_ItemNetTotal	= decimal.ToDouble(reader.GetDecimal("OD_ItemNetTotal"));
	this.OD_DateAdded		= reader.GetDateTime("OD_DateAdded");
	this.OD_TotalDiscounts	= decimal.ToDouble(reader.GetDecimal("OD_TotalDiscounts"));
	this.OD_TotalPromo		= decimal.ToDouble(reader.GetDecimal("OD_TotalPromo"));
	this.OD_TotalRoyalty	= decimal.ToDouble(reader.GetDecimal("OD_TotalRoyalty"));
	this.OD_TotalFreight	= decimal.ToDouble(reader.GetDecimal("OD_TotalFreight"));
	this.OD_TotalTax		= decimal.ToDouble(reader.GetDecimal("OD_TotalTax"));
	this.OD_TotalStTax		= decimal.ToDouble(reader.GetDecimal("OD_TotalStTax"));
	this.OD_TotalFedTax		= decimal.ToDouble(reader.GetDecimal("OD_TotalFedTax"));
	this.OD_ErpOrderNum		= reader.GetString("OD_ErpOrderNum");
	this.OD_ErpOrderItemNum = reader.GetInt32("OD_ErpOrderItemNum");
	this.OD_QtyPackSize		= decimal.ToDouble(reader.GetDecimal("OD_QtyPackSize"));
	this.OD_Cost			= decimal.ToDouble(reader.GetDecimal("OD_Cost"));
	this.OD_Condition       = reader.GetString("OD_Condition");
	this.OD_Project         = reader.GetString("OD_Project");
}

public override 
void write(){
	try{		
		//OD_ItemNum sequence
		string sql = "insert into orderdtl(" + 		
		"OH_ID," +	
		"OD_Db," +
		"OD_Company," +
		"OD_Plant," +
		"OD_OrderNum," +
		"OD_ItemNum," +		
		"OD_OrgID," +
		"OD_OrgItemNum," + 			
		"OD_ProdID," +
		"OD_ProdDescription," +
		"OD_Seq," +
		"OD_InternalRef," +
		"OD_CustPart," +
		"OD_CustPO," +
		"OD_QtyOrdSum," +
		"OD_QtyShippedSum," +
		"OD_QtyOrdUom," +
		"OD_UnitPrice," +
		"OD_UnitPriceUom," +
		"OD_ItemNetTotal," +
		"OD_DateAdded," +
		"OD_TotalDiscounts," +
		"OD_TotalPromo," +
		"OD_TotalRoyalty," +
		"OD_TotalFreight," +
		"OD_TotalTax," +
		"OD_TotalStTax," +
		"OD_TotalFedTax,"+
		"OD_ErpOrderNum,"+
		"OD_ErpOrderItemNum,"+
		"OD_QtyPackSize," +
		"OD_Cost," +
		"OD_Condition," +
		"OD_Project)" +
		" values ("+
				OH_ID.ToString()						+ "," +	
 		"'"	+	Converter.fixString(OD_Db)				+ "'," +	
 		"'"	+	Converter.fixString(OD_Company)			+ "'," + 
 		"'"	+	Converter.fixString(OD_Plant)  			+ "'," +	
		OD_OrderNum.ToString()							+ "," +
		OD_ItemNum.ToString()							+ "," +	
		"'"	+	Converter.fixString(OD_OrgID)			+ "'," +	
		"'" +	Converter.fixString(OD_OrgItemNum)		+ "'," +			
		"'"	+	Converter.fixString(OD_ProdID)			+ "'," +	
		"'" +	Converter.fixString(OD_ProdDescription)	+ "'," +
		OD_Seq.ToString()								+ "," +	
		"'"	+	Converter.fixString(OD_InternalRef)		+ "'," +	
		"'"	+	Converter.fixString(OD_CustPart)		+ "'," +	
		"'"	+	Converter.fixString(OD_CustPO)			+ "'," +	
		NumberUtil.toString(OD_QtyOrdSum)				+ "," +			
		NumberUtil.toString(OD_QtyShippedSum)			+ "," +	
		"'"	+	Converter.fixString(OD_QtyOrdUom)		+ "'," +		
		NumberUtil.toString(OD_UnitPrice)				+ "," +	 
		"'"	+	Converter.fixString(OD_UnitPriceUom)	+ "'," + 
		NumberUtil.toString(OD_ItemNetTotal)			+ "," +	  
		"'" + DateUtil.getCompleteDateRepresentation(OD_DateAdded) + "'," + 
		NumberUtil.toString(OD_TotalDiscounts)			+ "," +	   
		NumberUtil.toString(OD_TotalPromo)				+ "," +	   
		NumberUtil.toString(OD_TotalRoyalty)			+ "," +	   
		NumberUtil.toString(OD_TotalFreight)			+ "," +	   
		NumberUtil.toString(OD_TotalTax)				+ "," +	   
		NumberUtil.toString(OD_TotalStTax)				+ "," +	   
		NumberUtil.toString(OD_TotalFedTax)				+ "," +
		"'"	+	Converter.fixString(OD_ErpOrderNum)		+ "'," +	
		OD_ErpOrderItemNum.ToString()					+ "," +	   
		NumberUtil.toString(OD_QtyPackSize)				+ "," +	   
		NumberUtil.toString(OD_Cost)					+ "," +
		"'" + Converter.fixString(OD_Condition)         + "'," +
		"'" + Converter.fixString(OD_Project)           + "')";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <write>: " + de.Message,de);
	}
}

public override 
void update(){
	try{
		//OD_ItemNum sequence
		string sql = "update OrderDtl set " +
		
		"OD_Db ='"				+ OD_Db.ToString()	+ "'," +	
		"OD_Company ='"			+ Converter.fixString(OD_Company)			+ "'," + 
		"OD_Plant='"			+ Converter.fixString(OD_Plant)  			+ "'," +	
		"OD_OrderNum="			+ OD_OrderNum.ToString()					+ "," +
		"OD_ItemNum="			+ OD_ItemNum.ToString()						+ "," +			
		"OD_OrgID='"			+ Converter.fixString(OD_OrgID)				+ "'," +	
		"OD_OrgItemNum='"		+ Converter.fixString(OD_OrgItemNum)		+ "'," +			
		"OD_ProdID='"			+ Converter.fixString(OD_ProdID)			+ "'," +	
		"OD_ProdDescription='"	+ Converter.fixString(OD_ProdDescription)	+ "'," +
		"OD_Seq="				+ OD_Seq.ToString()							+ "," +	
		"OD_InternalRef='"		+ Converter.fixString(OD_InternalRef)		+ "'," +	
		"OD_CustPart='"			+ Converter.fixString(OD_CustPart)			+ "'," +	
		"OD_CustPO='"			+ Converter.fixString(OD_CustPO)			+ "'," +	
		"OD_QtyOrdSum="			+ NumberUtil.toString(OD_QtyOrdSum)			+ "," +	
		"OD_QtyShippedSum="		+ NumberUtil.toString(OD_QtyShippedSum)		+ "," +	
		"OD_QtyOrdUom='"		+ Converter.fixString(OD_QtyOrdUom)			+ "'," +		
		"OD_UnitPrice="			+ NumberUtil.toString(OD_UnitPrice)			+ "," +	 
		"OD_UnitPriceUom='"		+ Converter.fixString(OD_UnitPriceUom)		+ "'," + 
		"OD_ItemNetTotal="		+ NumberUtil.toString(OD_ItemNetTotal)		+ "," +	  
		"OD_DateAdded='"		+ DateUtil.getCompleteDateRepresentation(OD_DateAdded) + "'," + 
		"OD_TotalDiscounts="	+ NumberUtil.toString(OD_TotalDiscounts)	+ "," +	   
		"OD_TotalPromo="		+ NumberUtil.toString(OD_TotalPromo)		+ "," +	   
		"OD_TotalRoyalty="		+ NumberUtil.toString(OD_TotalRoyalty)		+ "," +	   
		"OD_TotalFreight="		+ NumberUtil.toString(OD_TotalFreight)		+ "," +	   
		"OD_TotalTax="			+ NumberUtil.toString(OD_TotalTax)			+ "," +	   
		"OD_TotalStTax="		+ NumberUtil.toString(OD_TotalStTax)		+ "," +	   
		"OD_TotalFedTax="		+ NumberUtil.toString(OD_TotalFedTax)		+ "," +
		"OD_ErpOrderNum='"		+ Converter.fixString(OD_ErpOrderNum)		+ "'," +		
		"OD_ErpOrderItemNum="	+ OD_ErpOrderItemNum.ToString()				+ "," +	
		"OD_QtyPackSize="		+ NumberUtil.toString(OD_QtyPackSize)		+ "," +	   
		"OD_Cost="				+ NumberUtil.toString(OD_Cost)				+ 		
	" where " +
		"OH_ID = "			+ OH_ID	+ " and " +
		"OD_ItemNum = "		+ OD_ItemNum;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <update>: " + de.Message,de);
	}
}

public override 
void delete(){
	try{
		string sql ="delete from orderdtl where "	+					
					"OH_ID = "		+ OH_ID	+ " and " +
					"OD_ItemNum = "	+ OD_ItemNum;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <delete>: " + de.Message,de);
	}
}
public void deleteAllFromHeader()
{
	try
	{
		string sql ="delete from orderdtl where " +										
					"OH_ID = "	+ OH_ID;			

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <deleteAllFromHeader>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBase <deleteAllFromHeader>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteAllFromHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBase <deleteAllFromHeader>: " + de.Message,de);
	}
}

public void setOH_ID (int OH_ID){
	this.OH_ID =OH_ID;
}
public void setOD_ID (int OD_ID){
	this.OD_ID = OD_ID;
}
public void setOD_Db (	string OD_Db){
	this.OD_Db = OD_Db;
}
public void setOD_Company (string OD_Company){
	this.OD_Company = OD_Company;
}
public void setOD_Plant (string OD_Plant){
	this.OD_Plant = OD_Plant;
}
public void setOD_OrderNum (int OD_OrderNum){
	this.OD_OrderNum = OD_OrderNum;
}
	public void setOD_ItemNum (int OD_ItemNum){
this.OD_ItemNum = OD_ItemNum;
}

public void setOD_OrgID(string OD_OrgID){
	this.OD_OrgID = OD_OrgID;
}

public void setOD_OrgItemNum(string OD_OrgItemNum){
	this.OD_OrgItemNum = OD_OrgItemNum;
}	

public void setOD_ProdID (string OD_ProdID){
this.OD_ProdID = OD_ProdID;
}
public void setOD_ProdDescription (string OD_ProdDescription){
this.OD_ProdDescription = OD_ProdDescription;
}

public void setOD_Seq (int	OD_Seq){
this.OD_Seq = OD_Seq;
}
public void setOD_InternalRef (string OD_InternalRef){
this.OD_InternalRef = OD_InternalRef;
}
public void setOD_CustPart (string OD_CustPart){
this.OD_CustPart = OD_CustPart;
}
public void setOD_CustPO (string OD_CustPO){
this.OD_CustPO = OD_CustPO;
}
public void setOD_QtyOrdSum (double OD_QtyOrdSum){
this.OD_QtyOrdSum = OD_QtyOrdSum;
}
public void setOD_QtyShippedSum (double OD_QtyShippedSum){
this.OD_QtyShippedSum = OD_QtyShippedSum;
}
public void setOD_QtyOrdUom (string OD_QtyOrdUom){
this.OD_QtyOrdUom = OD_QtyOrdUom;
}
public void setOD_UnitPrice (double OD_UnitPrice){
this.OD_UnitPrice = OD_UnitPrice;
}
public void setOD_UnitPriceUom (string OD_UnitPriceUom){
this.OD_UnitPriceUom = OD_UnitPriceUom;
}
public void setOD_ItemNetTotal (double OD_ItemNetTotal){
this.OD_ItemNetTotal = OD_ItemNetTotal;
}
public void setOD_DateAdded (DateTime OD_DateAdded){
this.OD_DateAdded = OD_DateAdded;
}
public void setOD_TotalDiscounts (double OD_TotalDiscounts){
this.OD_TotalDiscounts = OD_TotalDiscounts;
}
public void setOD_TotalPromo (double OD_TotalPromo){
this.OD_TotalPromo = OD_TotalPromo;
}
public void setOD_TotalRoyalty (double OD_TotalRoyalty){
this.OD_TotalRoyalty = OD_TotalRoyalty;
}
public void setOD_TotalFreight (double OD_TotalFreight){
this.OD_TotalFreight = OD_TotalFreight;
}
public void setOD_TotalTax (double OD_TotalTax){
this.OD_TotalTax = OD_TotalTax;
}
public void setOD_TotalStTax (double OD_TotalStTax){
this.OD_TotalStTax = OD_TotalStTax;
}
public void setOD_TotalFedTax (double OD_TotalFedTax){
	this.OD_TotalFedTax = OD_TotalFedTax;
}

public void setOD_ErpOrderNum(string OD_ErpOrderNum){
	this.OD_ErpOrderNum = OD_ErpOrderNum;
}	
public void setOD_ErpOrderItemNum(int OD_ErpOrderItemNum){
	this.OD_ErpOrderItemNum = OD_ErpOrderItemNum;
}	

public void setOD_QtyPackSize(double OD_QtyPackSize){
	this.OD_QtyPackSize = OD_QtyPackSize;
}
public void setOD_Cost(double OD_Cost){
	this.OD_Cost = OD_Cost;
}

public void setOD_Condition(string OD_Condition){
	this.OD_Condition = OD_Condition;
}

public void setOD_Project(string OD_Project){
	this.OD_Project = OD_Project;
}

public int getOH_ID(){
	return OH_ID;
}
public int getOD_ID(){
	return OD_ID;
}
public string getOD_Db(){
	return OD_Db;
}
public string getOD_Company(){
	return OD_Company;
}
public string getOD_Plant(){
	return OD_Plant;
}
public int getOD_OrderNum(){
	return OD_OrderNum;
}
public int getOD_ItemNum(){
	return OD_ItemNum;
}

public string getOD_OrgID(){
	return OD_OrgID;
}

public string getOD_OrgItemNum(){
	return OD_OrgItemNum;
}	

public string getOD_ProdID(){
	return OD_ProdID;
}
public string getOD_ProdDescription (){
	return this.OD_ProdDescription;
}

public
int	getOD_Seq(){
	return OD_Seq;
}
public string getOD_InternalRef(){
	return OD_InternalRef;
}
public string getOD_CustPart(){
	return OD_CustPart;
}
public string getOD_CustPO(){
	return OD_CustPO;
}
public double getOD_QtyOrdSum(){
	return OD_QtyOrdSum;
}
public double getOD_QtyShippedSum(){
	return OD_QtyShippedSum;
}
public string getOD_QtyOrdUom(){
	return OD_QtyOrdUom;
}
public double getOD_UnitPrice(){
	return OD_UnitPrice;
}
public string getOD_UnitPriceUom(){
	return OD_UnitPriceUom;
}
public double getOD_ItemNetTotal(){
	return OD_ItemNetTotal;
}
public DateTime getOD_DateAdded(){
	return OD_DateAdded;
}
public double getOD_TotalDiscounts(){
	return OD_TotalDiscounts;
}
public double getOD_TotalPromo(){
	return OD_TotalPromo;
}
public double getOD_TotalRoyalty(){
	return OD_TotalRoyalty;
}
public double getOD_TotalFreight(){
	return OD_TotalFreight;
}
public double getOD_TotalTax(){
	return OD_TotalTax;
}
public double getOD_TotalStTax(){
	return OD_TotalStTax;
}
public double getOD_TotalFedTax(){
	return OD_TotalFedTax;
}

public string getOD_ErpOrderNum(){
	return OD_ErpOrderNum;
}
public int getOD_ErpOrderItemNum(){
	return OD_ErpOrderItemNum;
}

public double getOD_QtyPackSize(){
	return OD_QtyPackSize;
}
public string getOD_Condition(){
	return OD_Condition;
}

public string getOD_Project(){
	return OD_Project;
}

public double getOD_Cost(){
	return OD_Cost;
}


public
	string getKeyHash()
{
	string sret= this.OH_ID + "," + this.OD_ItemNum;
	return sret;
}
} // class
//
} // namespace
