using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrOrdDataBase : GenericDataBaseElement{

private string SPO_SchVersion;
private string SPO_PrOrdMas;
private string SPO_PrOrd;
private string SPO_Plt;
private string SPO_Dept;
private string SPO_Mach;
private string SPO_ProdID;
private string SPO_ActID;
private int SPO_Seq;
private string SPO_Status;
private decimal SPO_Qty;
private decimal SPO_QtyComp;
private decimal SPO_QtyScrap;
private string SPO_Uom;
private decimal SPO_TmRun;
private string SPO_Shf;
private DateTime SPO_DtStart;
private DateTime SPO_DtEnd;
private string SPO_FamMulti;
private decimal SPO_HrLab;
private decimal SPO_HrPr;
private decimal SPO_Qty2;
private string SPO_Uom2;
private decimal SPO_QtyMin;
private decimal SPO_HrBehind;
private int SPO_QuePos;

public
SchPrOrdDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SPO_SchVersion = reader.GetString("SPO_SchVersion");
	this.SPO_PrOrdMas = reader.GetString("SPO_PrOrdMas");
	this.SPO_PrOrd = reader.GetString("SPO_PrOrd");
	this.SPO_Plt = reader.GetString("SPO_Plt");
	this.SPO_Dept = reader.GetString("SPO_Dept");
	this.SPO_Mach = reader.GetString("SPO_Mach");
	this.SPO_ProdID = reader.GetString("SPO_ProdID");
	this.SPO_ActID = reader.GetString("SPO_ActID");
	this.SPO_Seq = reader.GetInt32("SPO_Seq");
	this.SPO_Status = reader.GetString("SPO_Status");
	this.SPO_Qty = reader.GetDecimal("SPO_Qty");
	this.SPO_QtyComp = reader.GetDecimal("SPO_QtyComp");
	this.SPO_QtyScrap = reader.GetDecimal("SPO_QtyScrap");
	this.SPO_Uom = reader.GetString("SPO_Uom");
	this.SPO_TmRun = reader.GetDecimal("SPO_TmRun");
	this.SPO_Shf = reader.GetString("SPO_Shf");
	this.SPO_DtStart = reader.GetDateTime("SPO_DtStart");
	this.SPO_DtEnd = reader.GetDateTime("SPO_DtEnd");
	this.SPO_FamMulti = reader.GetString("SPO_FamMulti");
	this.SPO_HrLab = reader.GetDecimal("SPO_HrLab");
	this.SPO_HrPr = reader.GetDecimal("SPO_HrPr");
	this.SPO_Qty2 = reader.GetDecimal("SPO_Qty2");
	this.SPO_Uom2 = reader.GetString("SPO_Uom2");
	this.SPO_QtyMin = reader.GetDecimal("SPO_QtyMin");
	this.SPO_HrBehind = reader.GetDecimal("SPO_HrBehind");
	this.SPO_QuePos = reader.GetInt32("SPO_QuePos");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprord where " + 
			"SPO_SchVersion = '" + SPO_SchVersion + "' and " +
			"SPO_PrOrdMas = '" + SPO_PrOrdMas + "' and " +
			"SPO_PrOrd = '" + SPO_PrOrd + "'";
		
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
		string sql = "delete from schprord where " +
			"SPO_SchVersion = '" + SPO_SchVersion + "' and " +
			"SPO_PrOrdMas = '" + SPO_PrOrdMas + "' and " +
			"SPO_PrOrd = '" + SPO_PrOrd + "'";
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
		string sql = "update schprord set " +
			"SPO_Plt = '" + Converter.fixString(SPO_Plt) + "', " + 
			"SPO_Dept = '" + Converter.fixString(SPO_Dept) + "', " + 
			"SPO_Mach = '" + Converter.fixString(SPO_Mach) + "', " + 
			"SPO_ProdID = '" + Converter.fixString(SPO_ProdID) + "', " + 
			"SPO_ActID = '" + Converter.fixString(SPO_ActID) + "', " + 
			"SPO_Seq = " + SPO_Seq + ", " + 
			"SPO_Status = '" + Converter.fixString(SPO_Status) + "', " + 
			"SPO_Qty = " + NumberUtil.toString(SPO_Qty) + ", " + 
			"SPO_QtyComp = " + NumberUtil.toString(SPO_QtyComp) + ", " + 
			"SPO_QtyScrap = " + NumberUtil.toString(SPO_QtyScrap) + ", " + 
			"SPO_Uom = '" + Converter.fixString(SPO_Uom) + "', " + 
			"SPO_TmRun = " + NumberUtil.toString(SPO_TmRun) + ", " + 
			"SPO_Shf = '" + Converter.fixString(SPO_Shf) + "', " + 
			"SPO_DtStart = '" + DateUtil.getDateRepresentation(SPO_DtStart) + "', " + 
			"SPO_DtEnd = '" + DateUtil.getDateRepresentation(SPO_DtEnd) + "', " + 
			"SPO_FamMulti = '" + Converter.fixString(SPO_FamMulti) + "', " + 
			"SPO_HrLab = " + NumberUtil.toString(SPO_HrLab) + ", " + 
			"SPO_HrPr = " + NumberUtil.toString(SPO_HrPr) + ", " + 
			"SPO_Qty2 = " + NumberUtil.toString(SPO_Qty2) + ", " + 
			"SPO_Uom2 = '" + Converter.fixString(SPO_Uom2) + "', " + 
			"SPO_QtyMin = " + NumberUtil.toString(SPO_QtyMin) + ", " + 
			"SPO_HrBehind = " + NumberUtil.toString(SPO_HrBehind) + ", " + 
			"SPO_QuePos = " + SPO_QuePos + 
		" where " + 
			"SPO_SchVersion = '" + SPO_SchVersion + "' and " +
			"SPO_PrOrdMas = '" + SPO_PrOrdMas + "' and " +
			"SPO_PrOrd = '" + SPO_PrOrd + "'";
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
		string sql = "insert into schprord values('" + 
			SPO_SchVersion + "', '" +
			SPO_PrOrdMas + "', '" +
			SPO_PrOrd + "', '" +
			SPO_Plt + "', '" +
			SPO_Dept + "', '" +
			SPO_Mach + "', '" +
			SPO_ProdID + "', '" +
			SPO_ActID + "', " +
			NumberUtil.toString(SPO_Seq) + ", '" +
			SPO_Status + "', " +
			NumberUtil.toString(SPO_Qty) + ", " +
			NumberUtil.toString(SPO_QtyComp) + ", " +
			NumberUtil.toString(SPO_QtyScrap) + ", '" +
			SPO_Uom + "', " +
			NumberUtil.toString(SPO_TmRun) + ", '" +
			SPO_Shf + "', '" +
			DateUtil.getCompleteDateRepresentation(SPO_DtStart) +
			"', '" +
			DateUtil.getCompleteDateRepresentation(SPO_DtEnd) +
			"', '" +
			SPO_FamMulti + "', " +
			NumberUtil.toString(SPO_HrLab) + ", " +
			NumberUtil.toString(SPO_HrPr) + ", " +
			NumberUtil.toString(SPO_Qty2) + ", '" +
			SPO_Uom2 + "', " +
			NumberUtil.toString(SPO_QtyMin) + ", " +
			NumberUtil.toString(SPO_HrBehind) + ", " +
			SPO_QuePos.ToString() + ")";
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
void setSPO_SchVersion(string SPO_SchVersion){
	this.SPO_SchVersion = SPO_SchVersion;
}

public
void setSPO_PrOrdMas(string SPO_PrOrdMas){
	this.SPO_PrOrdMas = SPO_PrOrdMas;
}

public
void setSPO_PrOrd(string SPO_PrOrd){
	this.SPO_PrOrd = SPO_PrOrd;
}

public
void setSPO_Plt(string SPO_Plt){
	this.SPO_Plt = SPO_Plt;
}

public
void setSPO_Dept(string SPO_Dept){
	this.SPO_Dept = SPO_Dept;
}

public
void setSPO_Mach(string SPO_Mach){
	this.SPO_Mach = SPO_Mach;
}

public
void setSPO_ProdID(string SPO_ProdID){
	this.SPO_ProdID = SPO_ProdID;
}



public
void setSPO_ActID(string SPO_ActID){
	this.SPO_ActID = SPO_ActID;
}

public
void setSPO_Seq(int SPO_Seq){
	this.SPO_Seq = SPO_Seq;
}

public
void setSPO_Status(string SPO_Status){
	this.SPO_Status = SPO_Status;
}

public
void setSPO_Qty(decimal SPO_Qty){
	this.SPO_Qty = SPO_Qty;
}

public
void setSPO_QtyComp(decimal SPO_QtyComp){
	this.SPO_QtyComp = SPO_QtyComp;
}

public
void setSPO_QtyScrap(decimal SPO_QtyScrap){
	this.SPO_QtyScrap = SPO_QtyScrap;
}

public
void setSPO_Uom(string SPO_Uom){
	this.SPO_Uom = SPO_Uom;
}

public
void setSPO_TmRun(decimal SPO_TmRun){
	this.SPO_TmRun = SPO_TmRun;
}

public
void setSPO_Shf(string SPO_Shf){
	this.SPO_Shf = SPO_Shf;
}

public
void setSPO_DtStart(DateTime SPO_DtStart){
	this.SPO_DtStart = SPO_DtStart;
}

public
void setSPO_DtEnd(DateTime SPO_DtEnd){
	this.SPO_DtEnd = SPO_DtEnd;
}

public
void setSPO_FamMulti(string SPO_FamMulti){
	this.SPO_FamMulti = SPO_FamMulti;
}

public
void setSPO_HrLab(decimal SPO_HrLab){
	this.SPO_HrLab = SPO_HrLab;
}

public
void setSPO_HrPr(decimal SPO_HrPr){
	this.SPO_HrPr = SPO_HrPr;
}

public
void setSPO_Qty2(decimal SPO_Qty2){
	this.SPO_Qty2 = SPO_Qty2;
}

public
void setSPO_Uom2(string SPO_Uom2){
	this.SPO_Uom2 = SPO_Uom2;
}

public
void setSPO_QtyMin(decimal SPO_QtyMin){
	this.SPO_QtyMin = SPO_QtyMin;
}

public
void setSPO_HrBehind(decimal SPO_HrBehind){
	this.SPO_HrBehind = SPO_HrBehind;
}

public
void setSPO_QuePos(int SPO_QuePos){
	this.SPO_QuePos = SPO_QuePos;
}


public
string getSPO_SchVersion(){
	return SPO_SchVersion;
}

public
string getSPO_PrOrdMas(){
	return SPO_PrOrdMas;
}

public
string getSPO_PrOrd(){
	return SPO_PrOrd;
}

public
string getSPO_Plt(){
	return SPO_Plt;
}

public
string getSPO_Dept(){
	return SPO_Dept;
}

public
string getSPO_Mach(){
	return SPO_Mach;
}

public
string getSPO_ProdID(){
	return SPO_ProdID;
}



public
string getSPO_ActID(){
	return SPO_ActID;
}

public
int getSPO_Seq(){
	return SPO_Seq;
}

public
string getSPO_Status(){
	return SPO_Status;
}

public
decimal getSPO_Qty(){
	return SPO_Qty;
}

public
decimal getSPO_QtyComp(){
	return SPO_QtyComp;
}

public
decimal getSPO_QtyScrap(){
	return SPO_QtyScrap;
}

public
string getSPO_Uom(){
	return SPO_Uom;
}

public
decimal getSPO_TmRun(){
	return SPO_TmRun;
}

public
string getSPO_Shf(){
	return SPO_Shf;
}

public
DateTime getSPO_DtStart(){
	return SPO_DtStart;
}

public
DateTime getSPO_DtEnd(){
	return SPO_DtEnd;
}

public
string getSPO_FamMulti(){
	return SPO_FamMulti;
}

public
decimal getSPO_HrLab(){
	return SPO_HrLab;
}

public
decimal getSPO_HrPr(){
	return SPO_HrPr;
}

public
decimal getSPO_Qty2(){
	return SPO_Qty2;
}

public
string getSPO_Uom2(){
	return SPO_Uom2;
}

public
decimal getSPO_QtyMin(){
	return SPO_QtyMin;
}

public
decimal getSPO_HrBehind(){
	return SPO_HrBehind;
}

public
int getSPO_QuePos(){
	return SPO_QuePos;
}


} // class

} // namespace