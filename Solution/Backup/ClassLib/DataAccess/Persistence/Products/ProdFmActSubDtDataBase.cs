using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActSubDtDataBase : GenericDataBaseElement{

private string PCD_FamID;
private string PCD_ProdID;
private string PCD_ActID;
private int PCD_Seq;
private string PCD_SubID;
private int PCD_SubIDRank;
private int PCD_SubOrdNum;
private int PCD_MethodRank;
private int PCD_SortOrd;
private decimal PCD_CompQty;
private decimal PCD_CavAvail;
private decimal PCD_CavUnavail;
private decimal PCD_CompEffPer;
private string PCD_EcnCur;

public
ProdFmActSubDtDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.PCD_FamID = reader.GetString("PCD_FamID");
	this.PCD_ProdID = reader.GetString("PCD_ProdID");
	this.PCD_ActID = reader.GetString("PCD_ActID");
	this.PCD_Seq = reader.GetInt32("PCD_Seq");
	this.PCD_SubID = reader.GetString("PCD_SubID");
	this.PCD_SubIDRank = reader.GetInt32("PCD_SubIDRank");
	this.PCD_SubOrdNum = reader.GetInt32("PCD_SubOrdNum");
	this.PCD_MethodRank = reader.GetInt32("PCD_MethodRank");
	this.PCD_SortOrd = reader.GetInt32("PCD_SortOrd");
	this.PCD_CompQty = reader.GetDecimal("PCD_CompQty");
	this.PCD_CavAvail = reader.GetDecimal("PCD_CavAvail");
	this.PCD_CavUnavail = reader.GetDecimal("PCD_CavUnavail");
	this.PCD_CompEffPer = reader.GetDecimal("PCD_CompEffPer");
	this.PCD_EcnCur = reader.GetString("PCD_EcnCur");
}

public override 
void write(){
	try{
		string sql = "insert into prodfmactsubdt values('" + 
			Converter.fixString(PCD_FamID) + "', '" +
			Converter.fixString(PCD_ProdID) + "', '" +
			Converter.fixString(PCD_ActID) + "', " +
			PCD_Seq + ", '" +
            Converter.fixString(PCD_SubID) + "', " +
			PCD_SubIDRank + ", " +
			PCD_SubOrdNum + ", " +
			PCD_MethodRank + ", " +
			PCD_SortOrd + ", " +
			NumberUtil.toString(PCD_CompQty) + ", " +
			NumberUtil.toString(PCD_CavAvail) + ", " +
			NumberUtil.toString(PCD_CavUnavail) + ", " +
			NumberUtil.toString(PCD_CompEffPer) + ", '" +
			Converter.fixString(PCD_EcnCur) + "')";
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
		string sql = "update from prodfmactsubdt set " +
			"PCD_ActID = '" + Converter.fixString(PCD_ActID) + "', " +
			"PCD_SubID = '" + Converter.fixString(PCD_SubID) + "', " +
			"PCD_SubIDRank = " + PCD_SubIDRank + ", " +
			"PCD_SubOrdNum = " + PCD_SubOrdNum + ", " +
			"PCD_MethodRank = " + PCD_MethodRank + ", " +
			"PCD_SortOrd = " + PCD_SortOrd + ", " +
			"PCD_CompQty = '" + NumberUtil.toString(PCD_CompQty) + "', " +
			"PCD_CavAvail = '" + NumberUtil.toString(PCD_CavAvail) + "', " +
			"PCD_CavUnavail = '" + NumberUtil.toString(PCD_CavUnavail) + "', " +
			"PCD_CompEffPer = '" + NumberUtil.toString(PCD_CompEffPer) + "', " +
			"PCD_EcnCur = '" + Converter.fixString(PCD_EcnCur) + "' " +
			"where PCD_FamID  = '" + Converter.fixString(PCD_FamID) + "' and " +
			"PCD_ProdID = '" + Converter.fixString(PCD_ProdID) + "' and " +
			"PCD_Seq = " + PCD_Seq;
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
		string sql = "delete from prodfmactsubdt where " + 
				"PCD_FamID  = '" + Converter.fixString(PCD_FamID) + "' and " +
			    "PCD_ProdID = '" + Converter.fixString(PCD_ProdID) + "' and " +
				"PCD_Seq = " + PCD_Seq;
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
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsubdt where " + 
				"PCD_FamID  = '" + PCD_FamID + "' and " +
			    "PCD_ProdID = '" + PCD_ProdID + "' and " +
				"PCD_Seq = " + PCD_Seq;
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
void setPCD_FamID(string PCD_FamID){
	this.PCD_FamID = PCD_FamID;
}

public
void setPCD_ProdID(string PCD_ProdID){
	this.PCD_ProdID = PCD_ProdID;
}

public
void setPCD_ActID(string PCD_ActID){
	this.PCD_ActID = PCD_ActID;
}

public
void setPCD_Seq(int PCD_Seq){
	this.PCD_Seq = PCD_Seq;
}

public
void setPCD_SubID(string PCD_SubID){
	this.PCD_SubID = PCD_SubID;
}

public
void setPCD_SubIDRank(int PCD_SubIDRank){
	this.PCD_SubIDRank = PCD_SubIDRank;
}

public
void setPCD_SubOrdNum(int PCD_SubOrdNum){
	this.PCD_SubOrdNum = PCD_SubOrdNum;
}

public
void setPCD_MethodRank(int PCD_MethodRank){
	this.PCD_MethodRank = PCD_MethodRank;
}

public
void setPCD_SortOrd(int PCD_SortOrd){
	this.PCD_SortOrd = PCD_SortOrd;
}

public
void setPCD_CompQty(decimal PCD_CompQty){
	this.PCD_CompQty = PCD_CompQty;
}

public
void setPCD_CavAvail(decimal PCD_CavAvail){
	this.PCD_CavAvail = PCD_CavAvail;
}

public
void setPCD_CavUnavail(decimal PCD_CavUnavail){
	this.PCD_CavUnavail = PCD_CavUnavail;
}

public
void setPCD_CompEffPer(decimal PCD_CompEffPer){
	this.PCD_CompEffPer = PCD_CompEffPer;
}

public
void setPCD_EcnCur(string PCD_EcnCur){
	this.PCD_EcnCur = PCD_EcnCur;
}


public
string getPCD_FamID(){
	return PCD_FamID;
}

public
string getPCD_ProdID(){
	return PCD_ProdID;
}

public
string getPCD_ActID(){
	return PCD_ActID;
}

public
int getPCD_Seq(){
	return PCD_Seq;
}

public
string getPCD_SubID(){
	return PCD_SubID;
}

public
int getPCD_SubIDRank(){
	return PCD_SubIDRank;
}

public
int getPCD_SubOrdNum(){
	return PCD_SubOrdNum;
}

public
int getPCD_MethodRank(){
	return PCD_MethodRank;
}

public
int getPCD_SortOrd(){
	return PCD_SortOrd;
}

public
decimal getPCD_CompQty(){
	return PCD_CompQty;
}

public
decimal getPCD_CavAvail(){
	return PCD_CavAvail;
}

public
decimal getPCD_CavUnavail(){
	return PCD_CavUnavail;
}

public
decimal getPCD_CompEffPer(){
	return PCD_CompEffPer;
}

public
string getPCD_EcnCur(){
	return PCD_EcnCur;
}

} // class

} // namespace