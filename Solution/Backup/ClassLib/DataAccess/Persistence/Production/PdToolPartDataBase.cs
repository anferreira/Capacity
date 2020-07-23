using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class PdToolPartDataBase : GenericDataBaseElement{

private string PTP_Db;
private string PTP_Company;
private string PTP_Plant;
private string PTP_Family;
private string PTP_Part;
private int PTP_Seq;
private int PTP_LineNum;
private int PTP_EntryNum;
private string PTP_ToolNum;
private string PTP_ReqSetup;
private string PTP_ReqRun;
private decimal PTP_Qty;
private string PTP_Uom;

public
PdToolPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pdtoolpart where " + getWhereCondition();
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
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pdtoolpart where " + getWhereCondition();

		bool founded = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			founded = true;
		return founded;
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException){
		return false;
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void load(NotNullDataReader reader){
	this.PTP_Db = reader.GetString("PTP_Db");
	this.PTP_Company = reader.GetString("PTP_Company");
	this.PTP_Plant = reader.GetString("PTP_Plant");
	this.PTP_Family = reader.GetString("PTP_Family");
	this.PTP_Part = reader.GetString("PTP_Part");
	this.PTP_Seq = reader.GetInt32("PTP_Seq");
	this.PTP_LineNum = reader.GetInt32("PTP_LineNum");
	this.PTP_EntryNum = reader.GetInt32("PTP_EntryNum");
	this.PTP_ToolNum = reader.GetString("PTP_ToolNum");
	this.PTP_ReqSetup = reader.GetString("PTP_ReqSetup");
	this.PTP_ReqRun = reader.GetString("PTP_ReqRun");
	this.PTP_Qty = reader.GetDecimal("PTP_Qty");
	this.PTP_Uom = reader.GetString("PTP_Uom");
}

public override
void write(){
	try{
		string sql = "insert into pdtoolpart(" + 
			"PTP_Db," +
			"PTP_Company," +
			"PTP_Plant," +
			"PTP_Family," +
			"PTP_Part," +
			"PTP_Seq," +
			"PTP_LineNum," +
			"PTP_EntryNum," +
			"PTP_ToolNum," +
			"PTP_ReqSetup," +
			"PTP_ReqRun," +
			"PTP_Qty," +
			"PTP_Uom" +

			") values (" + 

			"'" + Converter.fixString(PTP_Db) + "'," +
			"'" + Converter.fixString(PTP_Company) + "'," +
			"'" + Converter.fixString(PTP_Plant) + "'," +
			"'" + Converter.fixString(PTP_Family) + "'," +
			"'" + Converter.fixString(PTP_Part) + "'," +
			"" + NumberUtil.toString(PTP_Seq) + "," +
			"" + NumberUtil.toString(PTP_LineNum) + "," +
			"" + NumberUtil.toString(PTP_EntryNum) + "," +
			"'" + Converter.fixString(PTP_ToolNum) + "'," +
			"'" + Converter.fixString(PTP_ReqSetup) + "'," +
			"'" + Converter.fixString(PTP_ReqRun) + "'," +
			"" + NumberUtil.toString(PTP_Qty) + "," +
			"'" + Converter.fixString(PTP_Uom) + "')";

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
		string sql = "update pdtoolpart set " +
			"PTP_Db = '" + Converter.fixString(PTP_Db) + "', " +
			"PTP_Company = '" + Converter.fixString(PTP_Company) + "', " +
			"PTP_Plant = '" + Converter.fixString(PTP_Plant) + "', " +
			"PTP_Family = '" + Converter.fixString(PTP_Family) + "', " +
			"PTP_Part = '" + Converter.fixString(PTP_Part) + "', " +
			"PTP_Seq = " + NumberUtil.toString(PTP_Seq) + ", " +
			"PTP_LineNum = " + NumberUtil.toString(PTP_LineNum) + ", " +
			"PTP_EntryNum = " + NumberUtil.toString(PTP_EntryNum) + ", " +
			"PTP_ToolNum = '" + Converter.fixString(PTP_ToolNum) + "', " +
			"PTP_ReqSetup = '" + Converter.fixString(PTP_ReqSetup) + "', " +
			"PTP_ReqRun = '" + Converter.fixString(PTP_ReqRun) + "', " +
			"PTP_Qty = " + NumberUtil.toString(PTP_Qty) + ", " +
			"PTP_Uom = '" + Converter.fixString(PTP_Uom) + "' " +

			"where " + getWhereCondition();
			
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
		string sql = "delete from pdtoolpart where " + getWhereCondition();
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
string getWhereCondition(){
	string sqlWhere =
		"PTP_Db = '" + Converter.fixString(PTP_Db) + "' and " +
		"PTP_Company = '" + Converter.fixString(PTP_Company) + "' and " +
		"PTP_Plant = '" + Converter.fixString(PTP_Plant) + "' and " +
		"PTP_Family = '" + Converter.fixString(PTP_Family) + "' and " +
		"PTP_Part = '" + Converter.fixString(PTP_Part) + "' and " +
		"PTP_Seq = " + NumberUtil.toString(PTP_Seq) + " and " +
		"PTP_LineNum = " + NumberUtil.toString(PTP_LineNum) + " and " +
		"PTP_EntryNum = " + NumberUtil.toString(PTP_EntryNum) + "";
	return sqlWhere;
}

public
void setPTP_Db(string PTP_Db){
	this.PTP_Db = PTP_Db;
}

public
void setPTP_Company(string PTP_Company){
	this.PTP_Company = PTP_Company;
}

public
void setPTP_Plant(string PTP_Plant){
	this.PTP_Plant = PTP_Plant;
}

public
void setPTP_Family(string PTP_Family){
	this.PTP_Family = PTP_Family;
}

public
void setPTP_Part(string PTP_Part){
	this.PTP_Part = PTP_Part;
}

public
void setPTP_Seq(int PTP_Seq){
	this.PTP_Seq = PTP_Seq;
}

public
void setPTP_LineNum(int PTP_LineNum){
	this.PTP_LineNum = PTP_LineNum;
}

public
void setPTP_EntryNum(int PTP_EntryNum){
	this.PTP_EntryNum = PTP_EntryNum;
}

public
void setPTP_ToolNum(string PTP_ToolNum){
	this.PTP_ToolNum = PTP_ToolNum;
}

public
void setPTP_ReqSetup(string PTP_ReqSetup){
	this.PTP_ReqSetup = PTP_ReqSetup;
}

public
void setPTP_ReqRun(string PTP_ReqRun){
	this.PTP_ReqRun = PTP_ReqRun;
}

public
void setPTP_Qty(decimal PTP_Qty){
	this.PTP_Qty = PTP_Qty;
}

public
void setPTP_Uom(string PTP_Uom){
	this.PTP_Uom = PTP_Uom;
}

public
string getPTP_Db(){
	return PTP_Db;
}

public
string getPTP_Company(){
	return PTP_Company;
}

public
string getPTP_Plant(){
	return PTP_Plant;
}

public
string getPTP_Family(){
	return PTP_Family;
}

public
string getPTP_Part(){
	return PTP_Part;
}

public
int getPTP_Seq(){
	return PTP_Seq;
}

public
int getPTP_LineNum(){
	return PTP_LineNum;
}

public
int getPTP_EntryNum(){
	return PTP_EntryNum;
}

public
string getPTP_ToolNum(){
	return PTP_ToolNum;
}

public
string getPTP_ReqSetup(){
	return PTP_ReqSetup;
}

public
string getPTP_ReqRun(){
	return PTP_ReqRun;
}

public
decimal getPTP_Qty(){
	return PTP_Qty;
}

public
string getPTP_Uom(){
	return PTP_Uom;
}

} // class

} // package