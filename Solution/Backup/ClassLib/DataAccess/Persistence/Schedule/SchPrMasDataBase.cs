using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrMasDataBase : GenericDataBaseElement{

private string SMO_SchVersion;
private string SMO_PrOrdMas;
private string SMO_ProdID;
private string SMO_ActID;
private int SMO_Seq;
private string SMO_Status;
private decimal SMO_Qty;
private string SMO_QtyComp;
private decimal SMO_QtyMin;
private decimal SMO_QtyOver;
private decimal SMO_QtyUnd;
private string SMO_Uom;
private DateTime SMO_DtReq;
private DateTime SMO_DtStart;
private DateTime SMO_DtEnd;
private decimal SMO_HrPr;
private decimal SMO_HrPrUtil;
private decimal SMO_HrLabD;
private string SMO_MultiOrd;
private string SMO_MultiSeq;
private decimal SMO_Qty2;
private string SMO_Uom2;
private decimal SMO_HrBehind;

public
SchPrMasDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMO_SchVersion = reader.GetString("SMO_SchVersion");
	this.SMO_PrOrdMas = reader.GetString("SMO_PrOrdMas");
	this.SMO_ProdID = reader.GetString("SMO_ProdID");
	this.SMO_ActID = reader.GetString("SMO_ActID");
	this.SMO_Seq = reader.GetInt32("SMO_Seq");
	this.SMO_Status = reader.GetString("SMO_Status");
	this.SMO_Qty = reader.GetDecimal("SMO_Qty");
	this.SMO_QtyComp = reader.GetString("SMO_QtyComp");
	this.SMO_QtyMin = reader.GetDecimal("SMO_QtyMin");
	this.SMO_QtyOver = reader.GetDecimal("SMO_QtyOver");
	this.SMO_QtyUnd = reader.GetDecimal("SMO_QtyUnd");
	this.SMO_Uom = reader.GetString("SMO_Uom");
	this.SMO_DtReq = reader.GetDateTime("SMO_DtReq");
	this.SMO_DtStart = reader.GetDateTime("SMO_DtStart");
	this.SMO_DtEnd = reader.GetDateTime("SMO_DtEnd");
	this.SMO_HrPr = reader.GetDecimal("SMO_HrPr");
	this.SMO_HrPrUtil = reader.GetDecimal("SMO_HrPrUtil");
	this.SMO_HrLabD = reader.GetDecimal("SMO_HrLabD");
	this.SMO_MultiOrd = reader.GetString("SMO_MultiOrd");
	this.SMO_MultiSeq = reader.GetString("SMO_MultiSeq");
	this.SMO_Qty2 = reader.GetDecimal("SMO_Qty2");
	this.SMO_Uom2 = reader.GetString("SMO_Uom2");
	this.SMO_HrBehind = reader.GetDecimal("SMO_HrBehind");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprmas where " + 
			"SMO_SchVersion = '" + SMO_SchVersion + "' and " +
			"SMO_PrOrdMas = '" + SMO_PrOrdMas + "'";

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
void delete(){
	try{
		string sql = "delete from schprmas where " +
			"SMO_SchVersion = '" + SMO_SchVersion + "' and " +
			"SMO_PrOrdMas = '" + SMO_PrOrdMas + "'";
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
void update(){
	try{
		string sql = "update schprmas set " +
			"SMO_ProdID = '" + Converter.fixString(SMO_ProdID) + "', " + 
			"SMO_ActID = '" + Converter.fixString(SMO_ActID) + "', " + 
			"SMO_Seq = " + SMO_Seq + ", " + 
			"SMO_Status = '" + Converter.fixString(SMO_Status) + "', " + 
			"SMO_Qty = " + NumberUtil.toString(SMO_Qty) + ", " + 
			"SMO_QtyComp = '" + Converter.fixString(SMO_QtyComp) + "', " + 
			"SMO_QtyMin = " + NumberUtil.toString(SMO_QtyMin) + ", " + 
			"SMO_QtyOver = " + NumberUtil.toString(SMO_QtyOver) + ", " + 
			"SMO_QtyUnd = " + NumberUtil.toString(SMO_QtyUnd) + ", " + 
			"SMO_Uom = '" + Converter.fixString(SMO_Uom) + "', " + 
			"SMO_DtReq = '" + DateUtil.getDateRepresentation(SMO_DtReq) + "', " + 
			"SMO_DtStart = '" + DateUtil.getDateRepresentation(SMO_DtStart) + "', " + 
			"SMO_DtEnd = '" + DateUtil.getDateRepresentation(SMO_DtEnd) + "', " + 
			"SMO_HrPr = " + NumberUtil.toString(SMO_HrPr) + ", " + 
			"SMO_HrPrUtil = " + NumberUtil.toString(SMO_HrPrUtil) + ", " + 
			"SMO_HrLabD = " + NumberUtil.toString(SMO_HrLabD) + ", " + 
			"SMO_MultiOrd = '" + Converter.fixString(SMO_MultiOrd) + "', " + 
			"SMO_MultiSeq = '" + Converter.fixString(SMO_MultiSeq) + "', " + 
			"SMO_Qty2 = " + NumberUtil.toString(SMO_Qty2) + ", " + 
			"SMO_Uom2 = '" + Converter.fixString(SMO_Uom2) + "', " + 
			"SMO_HrBehind = " + NumberUtil.toString(SMO_HrBehind) +
		" where " + 
			"SMO_SchVersion = '" + SMO_SchVersion + "' and " +
			"SMO_PrOrdMas = '" + SMO_PrOrdMas + "'";

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
void write(){
	try{	
		string sql = "insert into schprmas values('" + 
			Converter.fixString(SMO_SchVersion) + "', '" +
			Converter.fixString(SMO_PrOrdMas) + "', '" +
			Converter.fixString(SMO_ProdID) + "', '" +
			Converter.fixString(SMO_ActID) + "', " +
			SMO_Seq + ", '" +
			Converter.fixString(SMO_Status) + "', " +
			NumberUtil.toString(SMO_Qty) + ", '" +
			Converter.fixString(SMO_QtyComp) + "', " +
			NumberUtil.toString(SMO_QtyMin) + ", " +
			NumberUtil.toString(SMO_QtyOver) + ", " +
			NumberUtil.toString(SMO_QtyUnd) + ", '" +
			Converter.fixString(SMO_Uom) + "', '" +
			DateUtil.getCompleteDateRepresentation(SMO_DtReq) + "', '" + 
			DateUtil.getCompleteDateRepresentation(SMO_DtStart) + "', '" +
			DateUtil.getCompleteDateRepresentation(SMO_DtEnd) + "', " +
			NumberUtil.toString(SMO_HrPr) + ", " +
			NumberUtil.toString(SMO_HrPrUtil) + ", " +
			NumberUtil.toString(SMO_HrLabD) + ", '" +
			Converter.fixString(SMO_MultiOrd) + "', '" +
			Converter.fixString(SMO_MultiSeq) + "', " +
			NumberUtil.toString(SMO_Qty2) + ", '" +
			Converter.fixString(SMO_Uom2) + "', " +
			NumberUtil.toString(SMO_HrBehind) + ")";
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
bool exists(){
	try{
		read();
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException ){
		return false;
	}
	return true;
}

public
void setSMO_SchVersion(string SMO_SchVersion){
	this.SMO_SchVersion = SMO_SchVersion;
}

public
void setSMO_PrOrdMas(string SMO_PrOrdMas){
	this.SMO_PrOrdMas = SMO_PrOrdMas;
}

public
void setSMO_ProdID(string SMO_ProdID){
	this.SMO_ProdID = SMO_ProdID;
}

public
void setSMO_ActID(string SMO_ActID){
	this.SMO_ActID = SMO_ActID;
}

public
void setSMO_Seq(int SMO_Seq){
	this.SMO_Seq = SMO_Seq;
}

public
void setSMO_Status(string SMO_Status){
	this.SMO_Status = SMO_Status;
}

public
void setSMO_Qty(decimal SMO_Qty){
	this.SMO_Qty = SMO_Qty;
}

public
void setSMO_QtyComp(string SMO_QtyComp){
	this.SMO_QtyComp = SMO_QtyComp;
}

public
void setSMO_QtyMin(decimal SMO_QtyMin){
	this.SMO_QtyMin = SMO_QtyMin;
}

public
void setSMO_QtyOver(decimal SMO_QtyOver){
	this.SMO_QtyOver = SMO_QtyOver;
}

public
void setSMO_QtyUnd(decimal SMO_QtyUnd){
	this.SMO_QtyUnd = SMO_QtyUnd;
}

public
void setSMO_Uom(string SMO_Uom){
	this.SMO_Uom = SMO_Uom;
}

public
void setSMO_DtReq(DateTime SMO_DtReq){
	this.SMO_DtReq = SMO_DtReq;
}

public
void setSMO_DtStart(DateTime SMO_DtStart){
	this.SMO_DtStart = SMO_DtStart;
}

public
void setSMO_DtEnd(DateTime SMO_DtEnd){
	this.SMO_DtEnd = SMO_DtEnd;
}

public
void setSMO_HrPr(decimal SMO_HrPr){
	this.SMO_HrPr = SMO_HrPr;
}

public
void setSMO_HrPrUtil(decimal SMO_HrPrUtil){
	this.SMO_HrPrUtil = SMO_HrPrUtil;
}

public
void setSMO_HrLabD(decimal SMO_HrLabD){
	this.SMO_HrLabD = SMO_HrLabD;
}

public
void setSMO_MultiOrd(string SMO_MultiOrd){
	this.SMO_MultiOrd = SMO_MultiOrd;
}

public
void setSMO_MultiSeq(string SMO_MultiSeq){
	this.SMO_MultiSeq = SMO_MultiSeq;
}

public
void setSMO_Qty2(decimal SMO_Qty2){
	this.SMO_Qty2 = SMO_Qty2;
}

public
void setSMO_Uom2(string SMO_Uom2){
	this.SMO_Uom2 = SMO_Uom2;
}

public
void setSMO_HrBehind(decimal SMO_HrBehind){
	this.SMO_HrBehind = SMO_HrBehind;
}


public
string getSMO_SchVersion(){
	return SMO_SchVersion;
}

public
string getSMO_PrOrdMas(){
	return SMO_PrOrdMas;
}

public
string getSMO_ProdID(){
	return SMO_ProdID;
}

public
string getSMO_ActID(){
	return SMO_ActID;
}

public
int getSMO_Seq(){
	return SMO_Seq;
}

public
string getSMO_Status(){
	return SMO_Status;
}

public
decimal getSMO_Qty(){
	return SMO_Qty;
}

public
string getSMO_QtyComp(){
	return SMO_QtyComp;
}

public
decimal getSMO_QtyMin(){
	return SMO_QtyMin;
}

public
decimal getSMO_QtyOver(){
	return SMO_QtyOver;
}

public
decimal getSMO_QtyUnd(){
	return SMO_QtyUnd;
}

public
string getSMO_Uom(){
	return SMO_Uom;
}

public
DateTime getSMO_DtReq(){
	return SMO_DtReq;
}

public
DateTime getSMO_DtStart(){
	return SMO_DtStart;
}

public
DateTime getSMO_DtEnd(){
	return SMO_DtEnd;
}

public
decimal getSMO_HrPr(){
	return SMO_HrPr;
}

public
decimal getSMO_HrPrUtil(){
	return SMO_HrPrUtil;
}

public
decimal getSMO_HrLabD(){
	return SMO_HrLabD;
}

public
string getSMO_MultiOrd(){
	return SMO_MultiOrd;
}

public
string getSMO_MultiSeq(){
	return SMO_MultiSeq;
}

public
decimal getSMO_Qty2(){
	return SMO_Qty2;
}

public
string getSMO_Uom2(){
	return SMO_Uom2;
}

public
decimal getSMO_HrBehind(){
	return SMO_HrBehind;
}

} // class

} // namespace