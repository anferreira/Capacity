using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class ProdPackDtlDataBase : GenericDataBaseElement{

private string PCK_SchVersion;
private string PCK_Plt;
private string PCK_Dept;
private string PCK_ProdID;
private string PCK_ShipToNum;
private string PCK_CustProdID;
private decimal PCK_Order;
private decimal PCK_OrderItem;
private decimal PCK_Qty;
private decimal PCK_CtrQty;

public 
ProdPackDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.PCK_SchVersion = reader.GetString("PCK_SchVersion");
	this.PCK_Plt = reader.GetString("PCK_Plt");
	this.PCK_Dept = reader.GetString("PCK_Dept");
	this.PCK_ProdID = reader.GetString("PCK_ProdID");
	this.PCK_ShipToNum = reader.GetString("PCK_ShipToNum");
	this.PCK_CustProdID = reader.GetString("PCK_CustProdID");
	this.PCK_Order = reader.GetDecimal("PCK_Order");
	this.PCK_OrderItem = reader.GetDecimal("PCK_OrderItem");
	this.PCK_Qty = reader.GetDecimal("PCK_Qty");
	this.PCK_CtrQty = reader.GetDecimal("PCK_CtrQty");
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodpackdtl where " + 
					"PCK_SchVersion = '" + PCK_SchVersion + "' and " +
					"PCK_Plt        = '" + PCK_Plt  + "' and " +
					"PCK_Dept       = '" + PCK_Dept + "' and " +
					"PCK_ProdID     = '" + PCK_ProdID + "' and " +
					"PCK_ShipToNum  = '" + PCK_ShipToNum + "' and " +
					"PCK_CustProdID  = '" + PCK_CustProdID + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override	
void update(){
	try{
		string sql = "update prodpackdtl set " +
					"PCK_Order = " + NumberUtil.toString(PCK_Order) +", " +
					"PCK_OrderItem = " + NumberUtil.toString(PCK_OrderItem)  +", " +
                    "PCK_Qty = " + NumberUtil.toString(PCK_Qty) +", " +
					"PCK_CtrQty = " +	NumberUtil.toString(PCK_CtrQty) +
					" where " + 
					"PCK_SchVersion = '" + PCK_SchVersion +"' and " +
					"PCK_Plt = '" + PCK_Plt + "' and " +
                    "PCK_Dept = '" + PCK_Dept + "' and " +
                    "PCK_ProdID = '" + PCK_ProdID + "' and " +
                    "PCK_ShipToNum = '" + PCK_ShipToNum  + "' and " +
                    "PCK_CustProdID = '" + PCK_CustProdID + "'";
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
		string sql = "delete from prodpackdtl where " +
					"PCK_SchVersion = '" + PCK_SchVersion +"' and " +
					"PCK_Plt = '" + PCK_Plt + "' and " +
					"PCK_Dept = '" + PCK_Dept + "' and " +
					"PCK_ProdID = '" + PCK_ProdID + "'";
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
void write(){
	try{
		string sql = "insert into prodpackdtl values('" + 
				Converter.fixString(PCK_SchVersion) + "', '" +
				Converter.fixString(PCK_Plt) + "', '" +
				Converter.fixString(PCK_Dept) + "', '" +
				Converter.fixString(PCK_ProdID) + "', '" +
                Converter.fixString(PCK_ShipToNum) + "', '" +
                Converter.fixString(PCK_CustProdID) + "', " +
                NumberUtil.toString(PCK_Order) + ", " +
                NumberUtil.toString(PCK_OrderItem) + ", " +
                NumberUtil.toString(PCK_Qty) + ", " +
                NumberUtil.toString(PCK_CtrQty) +")";
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
string getPCK_SchVersion(){
		return PCK_SchVersion;
}

public 
string getPCK_Plt(){
	return PCK_Plt;
}

public 
string getPCK_Dept(){
	return PCK_Dept;
}

public 
string getPCK_ProdID(){
	return PCK_ProdID;
}
		
public 
string getPCK_ShipToNum(){
	return PCK_ShipToNum;
}
		
public 
string getPCK_CustProdID(){
	return PCK_CustProdID;
}

public 
decimal getPCK_Order(){
	return PCK_Order;
}

public 
decimal getPCK_OrderItem(){
	return PCK_OrderItem;
}

public 
decimal getPCK_Qty(){
	return PCK_Qty;
}

public 
decimal getPCK_CtrQty(){
	return PCK_CtrQty;
}


public 
void setPCK_SchVersion(string PCK_SchVersion){
	this.PCK_SchVersion = PCK_SchVersion;
}

public 
void setPCK_Plt(string PCK_Plt){
	this.PCK_Plt = PCK_Plt;
}

public 
void setPCK_Dept(string PCK_Dept){
	this.PCK_Dept =PCK_Dept;
}

public 
void setPCK_ProdID(string PCK_ProdID){
	this.PCK_ProdID = PCK_ProdID;
}

public 
void setPCK_ShipToNum(string PCK_ShipToNum){
	this.PCK_ShipToNum = PCK_ShipToNum;
}

public 
void setPCK_CustProdID(string PCK_CustProdID){
	this.PCK_CustProdID = PCK_CustProdID;
}

public 
void setPCK_Order(decimal PCK_Order){
	this.PCK_Order = PCK_Order;
}

public 
void setPCK_OrderItem(decimal PCK_OrderItem){
	this.PCK_OrderItem = PCK_OrderItem;
}

public 
void setPCK_Qty(decimal PCK_Qty){
	this.PCK_Qty = PCK_Qty;
}

public 
void setPCK_CtrQty(decimal PCK_CtrQty){
	this.PCK_CtrQty = PCK_CtrQty;
}

} // class

} // namespace
	
