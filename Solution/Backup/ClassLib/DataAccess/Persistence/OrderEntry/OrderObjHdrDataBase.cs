using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderObjHdrDataBase : GenericDataBaseElement{

private int OBJH_ID;
private string OBJH_Order;
private string OBJH_OrderItem;
private string OBJH_OrderItemRel;
private string OBJH_ObjName;
private string OBJH_ObjDescription;

public 
OrderObjHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from orderobjhdr where OBJH_ID = " + NumberUtil.toString(OBJH_ID);
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
		string sql = "select * from orderobjhdr where OBJH_ID = " + NumberUtil.toString(OBJH_ID);
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
	this.OBJH_ID = reader.GetInt32("OBJH_ID");
	this.OBJH_Order = reader.GetString("OBJH_Order");
	this.OBJH_OrderItem = reader.GetString("OBJH_OrderItem");
	this.OBJH_OrderItemRel = reader.GetString("OBJH_OrderItemRel");
	this.OBJH_ObjName = reader.GetString("OBJH_ObjName");
	this.OBJH_ObjDescription = reader.GetString("OBJH_ObjDescription");
}

public override 
void write(){
	try{
		string sql = "insert into orderobjhdr(" +
			"OBJH_Order, " + 
			"OBJH_OrderItem, " + 
			"OBJH_OrderItemRel, " + 
			"OBJH_ObjName, " + 
			"OBJH_ObjDescription" + 
		")values('" + 
			Converter.fixString(OBJH_Order) + "', '" +
			Converter.fixString(OBJH_OrderItem) + "', '" +
			Converter.fixString(OBJH_OrderItemRel) + "', '" +
			Converter.fixString(OBJH_ObjName) + "', '" +
			Converter.fixString(OBJH_ObjDescription) + "')";
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
		string sql = "update orderobjhdr set " +
			"OBJH_Order = '" + Converter.fixString(OBJH_Order) + "', '" +
			"OBJH_OrderItem = '" + Converter.fixString(OBJH_OrderItem) + "', '" +
			"OBJH_OrderItemRel = '" + Converter.fixString(OBJH_OrderItemRel) + "', '" +
			"OBJH_ObjName = '" + Converter.fixString(OBJH_ObjName) + "', '" +
			"OBJH_ObjDescription = '" + Converter.fixString(OBJH_ObjDescription) + "') " + 
		"where " +
			"OBJH_ID = " + NumberUtil.toString(OBJH_ID);

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
		string sql = "delete from orderobjhdr where OBJH_ID = " + NumberUtil.toString(OBJH_ID);
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
void setOBJH_ID(int OBJH_ID){
	this.OBJH_ID = OBJH_ID;
}

public
void setOBJH_Order(string OBJH_Order){
	this.OBJH_Order = OBJH_Order;
}

public
void setOBJH_OrderItem(string OBJH_OrderItem){
	this.OBJH_OrderItem = OBJH_OrderItem;
}

public
void setOBJH_OrderItemRel(string OBJH_OrderItemRel){
	this.OBJH_OrderItemRel = OBJH_OrderItemRel;
}

public
void setOBJH_ObjName(string OBJH_ObjName){
	this.OBJH_ObjName = OBJH_ObjName;
}

public
void setOBJH_ObjDescription(string OBJH_ObjDescription){
	this.OBJH_ObjDescription = OBJH_ObjDescription;
}


public
int getOBJH_ID(){
	return OBJH_ID;
}

public
string getOBJH_Order(){
	return OBJH_Order;
}

public
string getOBJH_OrderItem(){
	return OBJH_OrderItem;
}

public
string getOBJH_OrderItemRel(){
	return OBJH_OrderItemRel;
}

public
string getOBJH_ObjName(){
	return OBJH_ObjName;
}

public
string getOBJH_ObjDescription(){
	return OBJH_ObjDescription;
}

} // class

} // namespace
