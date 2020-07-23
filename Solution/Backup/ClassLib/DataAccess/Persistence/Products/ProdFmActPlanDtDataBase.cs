using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActPlanDtDataBase : GenericDataBaseElement{

private string PFPD_FamCfg;
private int PFPD_FamSeq;
private string PFPD_ProdID;
private int PFPD_Seq;
private decimal PFPD_Qty;
private string PFPD_InvUOM;
private decimal PFPD_QtyAvail;
private string PFPD_ShutYN;
private decimal PFPD_MinQty;
private decimal PFPD_MaxQty;

public
ProdFmActPlanDtDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PFPD_FamCfg = reader.GetString("PFPD_FamCfg");
	this.PFPD_FamSeq = reader.GetInt32("PFPD_FamSeq");
	this.PFPD_ProdID = reader.GetString("PFPD_ProdID");
	this.PFPD_Seq = reader.GetInt32("PFPD_Seq");
	this.PFPD_Qty = reader.GetDecimal("PFPD_Qty");
	this.PFPD_InvUOM = reader.GetString("PFPD_InvUOM");
	this.PFPD_QtyAvail = reader.GetDecimal("PFPD_QtyAvail");
	this.PFPD_ShutYN = reader.GetString("PFPD_ShutYN");
	this.PFPD_MinQty = reader.GetDecimal("PFPD_MinQty");
	this.PFPD_MaxQty = reader.GetDecimal("PFPD_MaxQty");
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactplandt where " + 
				"PFPD_FamCfg  = '" + PFPD_FamCfg + "'";
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

public 
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactplandt where " + 
			"PFPD_FamCfg  = '" + PFPD_FamCfg + "' and PFPD_FamSeq  = '" + PFPD_FamSeq + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()) 
			return true;
		else 
			return false;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void write(){
	try{
		string sql = "insert into prodfmactplandt values('" + 
			Converter.fixString(PFPD_FamCfg) + "', " +
			PFPD_FamSeq.ToString() + ", '" +
			Converter.fixString(PFPD_ProdID) + "', " +
			PFPD_Seq.ToString() + ", " +
			NumberUtil.toString(PFPD_Qty) + ", '" +
			Converter.fixString(PFPD_InvUOM) + "', " +
			NumberUtil.toString(PFPD_QtyAvail) + ", '" +
			Converter.fixString(PFPD_ShutYN) + "', " +
			NumberUtil.toString(PFPD_MinQty) + ", " +
			NumberUtil.toString(PFPD_MaxQty) + ")";
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
		string sql = "update prodfmactplandt set " +
			"PFPD_FamCfg = '" + Converter.fixString(PFPD_FamCfg) + "', " +
			"PFPD_FamSeq = " + PFPD_FamSeq.ToString() + ", '" +
			"PFPD_ProdID = '" + Converter.fixString(PFPD_ProdID) + "', '" +
			"PFPD_Seq = " + PFPD_Seq.ToString() + ", " +
			"PFPD_Qty = " + NumberUtil.toString(PFPD_Qty) + ", '" +
			"PFPD_InvUOM = " + Converter.fixString(PFPD_InvUOM) + "', " +
			"PFPD_QtyAvail = " + NumberUtil.toString(PFPD_QtyAvail) + ", '" +
			"PFPD_ShutYN = '" + Converter.fixString(PFPD_ShutYN) + "', " +
			"PFPD_MinQty = " + NumberUtil.toString(PFPD_MinQty) + ", " +
			"PFPD_MaxQty = " + NumberUtil.toString(PFPD_MaxQty) + 
			" where " +
				"PFPD_FamCfg  = '" + Converter.fixString(PFPD_FamCfg) + "'";
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
		string sql = "delete from prodfmactplandt where " +
			"PFPD_FamCfg  = '" + Converter.fixString(PFPD_FamCfg) + "'";
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
void setPFPD_FamCfg(string PFPD_FamCfg){
	this.PFPD_FamCfg = PFPD_FamCfg;
}

public
void setPFPD_FamSeq(int PFPD_FamSeq){
	this.PFPD_FamSeq = PFPD_FamSeq;
}

public
void setPFPD_ProdID(string PFPD_ProdID){
	this.PFPD_ProdID = PFPD_ProdID;
}

public
void setPFPD_Seq(int PFPD_Seq){
	this.PFPD_Seq = PFPD_Seq;
}

public
void setPFPD_Qty(decimal PFPD_Qty){
	this.PFPD_Qty = PFPD_Qty;
}

public
	void setPFPD_InvUOM(string PFPD_InvUOM)
{
	this.PFPD_InvUOM = PFPD_InvUOM;
}

public
void setPFPD_QtyAvail(decimal PFPD_QtyAvail){
	this.PFPD_QtyAvail = PFPD_QtyAvail;
}

public
void setPFPD_ShutYN(string PFPD_ShutYN){
	this.PFPD_ShutYN = PFPD_ShutYN;
}

public
void setPFPD_MinQty(decimal PFPD_MinQty){
	this.PFPD_MinQty = PFPD_MinQty;
}

public
void setPFPD_MaxQty(decimal PFPD_MaxQty){
	this.PFPD_MaxQty = PFPD_MaxQty;
}


public
string getPFPD_FamCfg(){
	return PFPD_FamCfg;
}

public
int getPFPD_FamSeq(){
	return PFPD_FamSeq;
}

public
string getPFPD_ProdID(){
	return PFPD_ProdID;
}

public
int getPFPD_Seq(){
	return PFPD_Seq;
}

public
decimal getPFPD_Qty(){
	return PFPD_Qty;
}

public string getPFPD_InvUOM()
{
	return PFPD_InvUOM;
}

public
decimal getPFPD_QtyAvail(){
	return PFPD_QtyAvail;
}

public
string getPFPD_ShutYN(){
	return PFPD_ShutYN;
}

public
decimal getPFPD_MinQty(){
	return PFPD_MinQty;
}

public
decimal getPFPD_MaxQty(){
	return PFPD_MaxQty;
}


} // class

} // namespace
