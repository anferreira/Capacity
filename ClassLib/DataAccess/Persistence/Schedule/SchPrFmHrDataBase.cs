using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrFmHrDataBase : GenericDataBaseElement{

private string SPH_SchVersion;
private decimal SPH_SchOrdNum;
private decimal SPH_MachOrdNum;
private string SPH_PrOrdMas;
private string SPH_PrOrd;
private string SPH_ProdID;
private string SPH_ActID;
private int SPH_Seq;
private int SPH_MethodRank;
private string SPH_TmType;
private decimal SPH_DlyOrdID;
private decimal SPH_Hr;
private decimal SPH_HrPr;
private decimal SPH_Qty;
private decimal SPH_QtyUtil;
private decimal SPH_CountSt;
private decimal SPH_CountEnd;
private string SPH_Loc;
private decimal SPH_Cycle;
private decimal SPH_RunStd;
private decimal SPH_UtilPer;
private decimal SPH_Effic;
private string SPH_EfficUom;
private decimal SPH_EfficPer;
private decimal SPH_ContQty;
private decimal SPH_RackQty;
private string SPH_Status;

// special attributes
private string SMH_Mach;
private string SMH_DRS;

public
SchPrFmHrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
bool existsByFamily(string familyCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.* from schprfmhr as A, prodfminfo as B " +
			"where A.SPH_ProdID = B.PFS_ProdID and B.PFS_FamProd = 'F' and B.PFS_ProdID = '" + familyCode + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			return true;
		else
			return false;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByFamily> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByFamily> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByFamily> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool existsByProduct(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.* from schprfmhr as A, prodfminfo as B " +
			"where A.SPH_ProdID = B.PFS_ProdID and B.FamProd = 'P' and B.PFS_ProdID = '" + productCode + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			return true;
		else
			return false;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByFamily(string familyCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.* from schprfmhr as A, prodfminfo as B " +
			"where A.SPH_ProdID = B.PFS_ProdID and B.PFS_FamProd = 'F' and B.PFS_ProdID = '" + familyCode + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByProduct(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.* from schprfmhr as A, prodfminfo as B " +
			"where A.SPH_ProdID = B.PFS_ProdID and B.FamProd = 'P' and B.PFS_ProdID = '" + productCode + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void load(NotNullDataReader reader){
	this.SPH_SchVersion = reader.GetString("SPH_SchVersion");
	this.SPH_SchOrdNum = reader.GetDecimal("SPH_SchOrdNum");
	this.SPH_MachOrdNum = reader.GetInt32("SPH_MachOrdNum");
	this.SPH_PrOrdMas = reader.GetString("SPH_PrOrdMas");
	this.SPH_PrOrd = reader.GetString("SPH_PrOrd");
	this.SPH_ProdID = reader.GetString("SPH_ProdID");
	this.SPH_ActID = reader.GetString("SPH_ActID");
	this.SPH_Seq = reader.GetInt32("SPH_Seq");
	this.SPH_MethodRank = reader.GetInt32("SPH_MethodRank");
	this.SPH_TmType = reader.GetString("SPH_TmType");
	this.SPH_DlyOrdID = reader.GetDecimal("SPH_DlyOrdID");
	this.SPH_Hr = reader.GetDecimal("SPH_Hr");
	this.SPH_HrPr = reader.GetDecimal("SPH_HrPr");
	this.SPH_Qty = reader.GetDecimal("SPH_Qty");
	this.SPH_QtyUtil = reader.GetDecimal("SPH_QtyUtil");
	this.SPH_CountSt = reader.GetDecimal("SPH_CountSt");
	this.SPH_CountEnd = reader.GetDecimal("SPH_CountEnd");
	this.SPH_Loc = reader.GetString("SPH_Loc");
	this.SPH_Cycle = reader.GetDecimal("SPH_Cycle");
	this.SPH_RunStd = reader.GetDecimal("SPH_RunStd");
	this.SPH_UtilPer = reader.GetDecimal("SPH_UtilPer");
	this.SPH_Effic = reader.GetDecimal("SPH_Effic");
	this.SPH_EfficUom = reader.GetString("SPH_EfficUom");
	this.SPH_EfficPer = reader.GetDecimal("SPH_EfficPer");
	this.SPH_ContQty = reader.GetDecimal("SPH_ContQty");
	this.SPH_RackQty = reader.GetDecimal("SPH_RackQty");
	this.SPH_Status = reader.GetString("SPH_Status");
}

public
void load2(NotNullDataReader reader){
	load(reader);
	this.SMH_Mach = reader.GetString(27);
	this.SMH_DRS = reader.GetString(28);
}


public override
void write(){
	try{
		string sql = "insert into schprfmhr values('" + 
			Converter.fixString(SPH_SchVersion) + "', " +
			NumberUtil.toString(SPH_SchOrdNum) + ", " +
			NumberUtil.toString(SPH_MachOrdNum) + ", '" +
			Converter.fixString(SPH_PrOrdMas) + "', '" +
			Converter.fixString(SPH_PrOrd) + "', '" +
			Converter.fixString(SPH_ProdID) + "', '" +
			Converter.fixString(SPH_ActID) + "', " +
			NumberUtil.toString(SPH_Seq) + ", " +
			NumberUtil.toString(SPH_MethodRank) + ", '" +
			Converter.fixString(SPH_TmType) + "', " +
			NumberUtil.toString(SPH_DlyOrdID) + ", " +
			NumberUtil.toString(SPH_Hr) + ", " +
			NumberUtil.toString(SPH_HrPr) + ", " +
			NumberUtil.toString(SPH_Qty) + ", " +
			NumberUtil.toString(SPH_QtyUtil) + ", " +
			NumberUtil.toString(SPH_CountSt) + ", " +
			NumberUtil.toString(SPH_CountEnd) + ", '" +
			Converter.fixString(SPH_Loc) + "', " +
			NumberUtil.toString(SPH_Cycle) + ", " +
			NumberUtil.toString(SPH_RunStd) + ", " +
			NumberUtil.toString(SPH_UtilPer) + ", " +
			NumberUtil.toString(SPH_Effic) + ", '" +
			Converter.fixString(SPH_EfficUom) + "', " +
			NumberUtil.toString(SPH_EfficPer) + ", " +
			NumberUtil.toString(SPH_ContQty) + ", " +
			NumberUtil.toString(SPH_RackQty) + ", '" +
			Converter.fixString(SPH_Status) + "')";
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
		string sql = "update schprfmhr set " +
			"SPH_PrOrdMas = '" + Converter.fixString(SPH_PrOrdMas) + "', " +
			"SPH_PrOrd = '" + Converter.fixString(SPH_PrOrd) + "', " +
			"SPH_ProdID = '" + Converter.fixString(SPH_ProdID) + "', " +
			"SPH_ActID = '" + Converter.fixString(SPH_ActID) + "', " +
			"SPH_Seq = " +  NumberUtil.toString(SPH_Seq) +  
			"SPH_MethodRank = " + NumberUtil.toString(SPH_MethodRank) +
			"SPH_TmType = '" + Converter.fixString(SPH_TmType) + "', " +
			"SPH_DlyOrdID = " + NumberUtil.toString(SPH_DlyOrdID) +
			"SPH_Hr = " + NumberUtil.toString(SPH_Hr) +
			"SPH_HrPr = " + NumberUtil.toString(SPH_HrPr) +
			"SPH_Qty = " + NumberUtil.toString(SPH_Qty) +
			"SPH_QtyUtil = " + NumberUtil.toString(SPH_QtyUtil) +
			"SPH_CountSt = " + NumberUtil.toString(SPH_CountSt) +
			"SPH_CountEnd = " + NumberUtil.toString(SPH_CountEnd) + 
			"SPH_Loc = '" + Converter.fixString(SPH_Loc) + "', " +
			"SPH_Cycle = " + NumberUtil.toString(SPH_Cycle) +
			"SPH_RunStd = " + NumberUtil.toString(SPH_RunStd) +
			"SPH_UtilPer = " + NumberUtil.toString(SPH_UtilPer) +
			"SPH_Effic = " + NumberUtil.toString(SPH_Effic) +
			"SPH_EfficUom = '" + Converter.fixString(SPH_EfficUom) + "', " +
			"SPH_EfficPer = " + NumberUtil.toString(SPH_EfficPer) +
			"SPH_ContQty = " + NumberUtil.toString(SPH_ContQty) +
			"SPH_RackQty = " + NumberUtil.toString(SPH_RackQty) +
			"SPH_Status = '" + Converter.fixString(SPH_Status) + 
		"where " +
		 "SPH_SchVersion = " + SPH_SchVersion +
		 "SPH_SchOrdNum = " + SPH_SchOrdNum + 
		 "SPH_MachOrdNum = " + SPH_MachOrdNum;
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
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
		string sql = "delete from schprfmhr where " +
			"SPH_SchVersion = '" + SPH_SchVersion + "' and " +
			"SPH_SchOrdNum = " + SPH_SchOrdNum + " and " +
			"SPH_MachOrdNum = " + SPH_MachOrdNum;

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
string getSPH_SchVersion(){
	return SPH_SchVersion;
}

public
decimal getSPH_SchOrdNum(){
	return SPH_SchOrdNum;
}

public
decimal getSPH_MachOrdNum(){
	return SPH_MachOrdNum;
}

public
string getSPH_PrOrdMas(){
	return SPH_PrOrdMas;
}

public
string getSPH_PrOrd(){
	return SPH_PrOrd;
}

public
string getSPH_ProdID(){
	return SPH_ProdID;
}

public
string getSPH_ActID(){
	return SPH_ActID;
}

public
int getSPH_Seq(){
	return SPH_Seq;
}

public
int getSPH_MethodRank(){
	return SPH_MethodRank;
}

public
string getSPH_TmType(){
	return SPH_TmType;
}

public
decimal getSPH_DlyOrdID(){
	return SPH_DlyOrdID;
}

public
decimal getSPH_Hr(){
	return SPH_Hr;
}

public
decimal getSPH_HrPr(){
	return SPH_HrPr;
}

public
decimal getSPH_Qty(){
	return SPH_Qty;
}

public
decimal getSPH_QtyUtil(){
	return SPH_QtyUtil;
}

public
decimal getSPH_CountSt(){
	return SPH_CountSt;
}

public
decimal getSPH_CountEnd(){
	return SPH_CountEnd;
}

public
string getSPH_Loc(){
	return SPH_Loc;
}

public
decimal getSPH_Cycle(){
	return SPH_Cycle;
}

public
decimal getSPH_RunStd(){
	return SPH_RunStd;
}

public
decimal getSPH_UtilPer(){
	return SPH_UtilPer;
}

public
decimal getSPH_Effic(){
	return SPH_Effic;
}

public
string getSPH_EfficUom(){
	return SPH_EfficUom;
}

public
decimal getSPH_EfficPer(){
	return SPH_EfficPer;
}

public
decimal getSPH_ContQty(){
	return SPH_ContQty;
}

public
decimal getSPH_RackQty(){
	return SPH_RackQty;
}

public
string getSMH_Mach(){
	return SMH_Mach;
}

public 
string getSMH_DRS(){
	return SMH_DRS;
}




public
void setSPH_SchVersion(string SPH_SchVersion){
	this.SPH_SchVersion = SPH_SchVersion;
}
public
void setSPH_SchOrdNum(decimal SPH_SchOrdNum){
	this.SPH_SchOrdNum = SPH_SchOrdNum;
}
public
void setSPH_MachOrdNum(decimal SPH_MachOrdNum){
	this.SPH_MachOrdNum = SPH_MachOrdNum;
}
public
void setSPH_PrOrdMas(string SPH_PrOrdMas){
	this.SPH_PrOrdMas = SPH_PrOrdMas;
}
public
void setSPH_PrOrd(string SPH_PrOrd){
	this.SPH_PrOrd = SPH_PrOrd;
}
public
void setSPH_ProdID(string SPH_ProdID){
	this.SPH_ProdID = SPH_ProdID;
}
public
void setSPH_ActID(string SPH_ActID){
	this.SPH_ActID = SPH_ActID;
}
public
void setSPH_Seq(int SPH_Seq){
	this.SPH_Seq = SPH_Seq;
}
public
void setSPH_MethodRank(int SPH_MethodRank){
	this.SPH_MethodRank = SPH_MethodRank;
}
public
void setSPH_TmType(string SPH_TmType){
	this.SPH_TmType = SPH_TmType;
}
public
void setSPH_DlyOrdID(decimal SPH_DlyOrdID){
	this.SPH_DlyOrdID = SPH_DlyOrdID;
}
public
void setSPH_Hr(decimal SPH_Hr){
	this.SPH_Hr = SPH_Hr;
}
public
void setSPH_HrPr(decimal SPH_HrPr){
	this.SPH_HrPr = SPH_HrPr;
}
public
void setSPH_Qty(decimal SPH_Qty){
	this.SPH_Qty = SPH_Qty;
}
public
void setSPH_QtyUtil(decimal SPH_QtyUtil){
	this.SPH_QtyUtil = SPH_QtyUtil;
}
public
void setSPH_CountSt(decimal SPH_CountSt){
	this.SPH_CountSt = SPH_CountSt;
}
public
void setSPH_CountEnd(decimal SPH_CountEnd){
	this.SPH_CountEnd = SPH_CountEnd;
}
public
void setSPH_Loc(string SPH_Loc){
	this.SPH_Loc = SPH_Loc;
}
public
void setSPH_Cycle(decimal SPH_Cycle){
	this.SPH_Cycle = SPH_Cycle;
}
public
void setSPH_RunStd(decimal SPH_RunStd){
	this.SPH_RunStd = SPH_RunStd;
}
public
void setSPH_UtilPer(decimal SPH_UtilPer){
	this.SPH_UtilPer = SPH_UtilPer;
}
public
void setSPH_Effic(decimal SPH_Effic){
	this.SPH_Effic = SPH_Effic;
}
public
void setSPH_EfficUom(string SPH_EfficUom){
	this.SPH_EfficUom = SPH_EfficUom;
}
public
void setSPH_EfficPer(decimal SPH_EfficPer){
	this.SPH_EfficPer = SPH_EfficPer;
}
public
void setSPH_ContQty(decimal SPH_ContQty){
	this.SPH_ContQty = SPH_ContQty;
}
public
void setSPH_RackQty(decimal SPH_RackQty){
	this.SPH_RackQty = SPH_RackQty;
}
public
void setSPH_Status(string SPH_Status){
	this.SPH_Status = SPH_Status;
}


}

}