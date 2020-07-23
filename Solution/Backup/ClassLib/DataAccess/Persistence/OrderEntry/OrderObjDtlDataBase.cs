using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderObjDtlDataBase : GenericDataBaseElement{

private int OBJD_ID;
private string OBJD_Order;
private string OBJD_OrderItem;
private string OBJD_OrderItemRel;
private string OBJD_ObjLineNum;
private string OBJD_Description;
private decimal OBJD_DefDaysReq;
private decimal OBJD_DefHoursReq;
private string OBJD_DefEventToTrigger;

public 
OrderObjDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from orderobjdtl where OBJD_ID = " + NumberUtil.toString(OBJD_ID);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
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
		string sql = "select * from objectdtl where OBJD_ID = " + NumberUtil.toString(OBJD_ID);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void load(NotNullDataReader reader){
	this.OBJD_ID = reader.GetInt32("OBJD_ID");
	this.OBJD_Order = reader.GetString("OBJD_Order");
	this.OBJD_OrderItem = reader.GetString("OBJD_OrderItem");
	this.OBJD_OrderItemRel = reader.GetString("OBJD_OrderItemRel");
	this.OBJD_ObjLineNum = reader.GetString("OBJD_ObjLineNum");
	this.OBJD_Description = reader.GetString("OBJD_Description");
	this.OBJD_DefDaysReq = reader.GetDecimal("OBJD_DefDaysReq");
	this.OBJD_DefHoursReq = reader.GetDecimal("OBJD_DefHoursReq");
	this.OBJD_DefEventToTrigger = reader.GetString("OBJD_DefEventToTrigger");
}

public override 
void write(){
	try{
		string sql = "insert into objecthdr(" + 
			"OBJD_Order, " + 
			"OBJD_OrderItem, " + 
			"OBJD_OrderItemRel, " + 
			"OBJD_ObjLineNum, " + 
			"OBJD_Description, " + 
			"OBJD_DefDaysReq, " + 
			"OBJD_DefHoursReq, " + 
			"OBJD_DefEventToTrigger " + 
		")values('" + 
			Converter.fixString(OBJD_Order) + "', '" + 
			Converter.fixString(OBJD_OrderItem) + "', '" + 
			Converter.fixString(OBJD_OrderItemRel) + "', '" + 
			Converter.fixString(OBJD_ObjLineNum) + "', '" + 
			Converter.fixString(OBJD_Description) + "', " + 
			NumberUtil.toString(OBJD_DefDaysReq) + ", " + 
			NumberUtil.toString(OBJD_DefHoursReq) + ", '" + 
			Converter.fixString(OBJD_DefEventToTrigger) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
}

public override 
void update(){
	try{
		string sql = "update objectdtl set " +
			"OBJD_Order = '" + Converter.fixString(OBJD_Order) + "', '" + 
			"OBJD_OrderItem = '" + Converter.fixString(OBJD_OrderItem) + "', '" + 
			"OBJD_OrderItemRel = '" + Converter.fixString(OBJD_OrderItemRel) + "', '" + 
			"OBJD_ObjLineNum = '" + Converter.fixString(OBJD_ObjLineNum) + "', '" + 
			"OBJD_Description = '" + Converter.fixString(OBJD_Description) + "', " + 
			"OBJD_DefDaysReq = " + NumberUtil.toString(OBJD_DefDaysReq) + ", " + 
			"OBJD_DefHoursReq = " + NumberUtil.toString(OBJD_DefHoursReq) + ", '" + 
			"OBJD_DefEventToTrigger = '" + Converter.fixString(OBJD_DefEventToTrigger) + "') " +
		"where " +
			"OBJD_ID = '" + NumberUtil.toString(OBJD_ID) + "'";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
}

public override 
void delete(){
	try{
		string sql = "delete from objectdtl where OBJD_ID = " + NumberUtil.toString(OBJD_ID);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}

public
void setOBJD_ID(int OBJD_ID){
	this.OBJD_ID = OBJD_ID;
}

public
void setOBJD_Order(string OBJD_Order){
	this.OBJD_Order = OBJD_Order;
}

public
void setOBJD_OrderItem(string OBJD_OrderItem){
	this.OBJD_OrderItem = OBJD_OrderItem;
}

public
void setOBJD_OrderItemRel(string OBJD_OrderItemRel){
	this.OBJD_OrderItemRel = OBJD_OrderItemRel;
}

public
void setOBJD_ObjLineNum(string OBJD_ObjLineNum){
	this.OBJD_ObjLineNum = OBJD_ObjLineNum;
}

public
void setOBJD_Description(string OBJD_Description){
	this.OBJD_Description = OBJD_Description;
}

public
void setOBJD_DefDaysReq(decimal OBJD_DefDaysReq){
	this.OBJD_DefDaysReq = OBJD_DefDaysReq;
}

public
void setOBJD_DefHoursReq(decimal OBJD_DefHoursReq){
	this.OBJD_DefHoursReq = OBJD_DefHoursReq;
}

public
void setOBJD_DefEventToTrigger(string OBJD_DefEventToTrigger){
	this.OBJD_DefEventToTrigger = OBJD_DefEventToTrigger;
}


public
int getOBJD_ID(){
	return OBJD_ID;
}

public
string getOBJD_Order(){
	return OBJD_Order;
}

public
string getOBJD_OrderItem(){
	return OBJD_OrderItem;
}

public
string getOBJD_OrderItemRel(){
	return OBJD_OrderItemRel;
}

public
string getOBJD_ObjLineNum(){
	return OBJD_ObjLineNum;
}

public
string getOBJD_Description(){
	return OBJD_Description;
}

public
decimal getOBJD_DefDaysReq(){
	return OBJD_DefDaysReq;
}

public
decimal getOBJD_DefHoursReq(){
	return OBJD_DefHoursReq;
}

public
string getOBJD_DefEventToTrigger(){
	return OBJD_DefEventToTrigger;
}

} // class

} // namespace
