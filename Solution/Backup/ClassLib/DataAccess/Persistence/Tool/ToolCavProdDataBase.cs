using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ToolCavProdDataBase : GenericDataBaseElement{

private string TLCP_TLID;
private decimal TLCP_CavID;
private string TLCP_ProdID;
private string TLCP_Status;
private int TLCP_Qty;

public
ToolCavProdDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.TLCP_TLID = reader.GetString("TLCP_TLID");
	this.TLCP_CavID = reader.GetDecimal("TLCP_CavID");
	this.TLCP_ProdID = reader.GetString("TLCP_ProdID");
	this.TLCP_Status = reader.GetString("TLCP_Status");
	this.TLCP_Qty = reader.GetInt32("TLCP_Qty");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from toolcavprod where " + 
				"TLCP_TLID = '" + TLCP_TLID + "' and " + 
				"TLCP_CavID = '" + TLCP_CavID + "' and " +
				"TLCP_ProdID = '" + TLCP_ProdID + "'";
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

public override
void write(){
	try{
		string sql = "insert into toolcavprod values('" + 
					"TLCP_TLID = '" + Converter.fixString(TLCP_TLID) + "', " +
					"TLCP_CavID = " + NumberUtil.toString(TLCP_CavID) + ", " +
					"TLCP_ProdID = '" + Converter.fixString(TLCP_ProdID) + "', " +
					"TLCP_Status = '" + Converter.fixString(TLCP_Status) + "', " +
					"TLCP_Qty = " + TLCP_Qty + ")";
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
		string sql = "update toolcavprod set " +
				"TLCP_Status = '" + Converter.fixString(TLCP_Status) + "', " +
				"TLCP_Qty = " + TLCP_Qty + 
		" where " + 
				"TLCP_TLID = '" + TLCP_TLID + "' and " + 
				"TLCP_CavID = '" + TLCP_CavID + "' and " +
				"TLCP_ProdID = '" + TLCP_ProdID + "'";
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
		string sql = "delete from toolcavprod where " +
				"TLCP_TLID = '" + TLCP_TLID + "' and " + 
				"TLCP_CavID = '" + TLCP_CavID + "' and " +
				"TLCP_ProdID = '" + TLCP_ProdID + "'";
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
void setTLCP_TLID(string TLCP_TLID){
	this.TLCP_TLID = TLCP_TLID;
}

public
void setTLCP_CavID(decimal TLCP_CavID){
	this.TLCP_CavID = TLCP_CavID;
}

public
void setTLCP_ProdID(string TLCP_ProdID){
	this.TLCP_ProdID = TLCP_ProdID;
}


public
void setTLCP_Status(string TLCP_Status){
	this.TLCP_Status = TLCP_Status;
}

public
void setTLCP_Qty(int TLCP_Qty){
	this.TLCP_Qty = TLCP_Qty;
}


public
string getTLCP_TLID(){
	return TLCP_TLID;
}

public
decimal getTLCP_CavID(){
	return TLCP_CavID;
}

public
string getTLCP_ProdID(){
	return TLCP_ProdID;
}


public
string getTLCP_Status(){
	return TLCP_Status;
}

public
int getTLCP_Qty(){
	return TLCP_Qty;
}


} // class

} // namespace