using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActPlanDataBase : GenericDataBaseElement{

private string PAPL_ProdID;
private string PAPL_ActID;
private int PAPL_Seq;
private decimal PAPL_StdPack;
private string PAPL_PackType;
private decimal PAPL_SkidQty;
private string PAPL_SkidType;
private decimal PAPL_MinInv;
private decimal PAPL_MaxInv;
private string PAPL_InvUom;
private decimal PAPL_MinCon;
private decimal PAPL_MaxCon;
private int PAPL_DohMin;
private int PAPL_DohMax;
private decimal PAPL_PackWip;
private string PAPL_ContWip;
private decimal PAPL_TarRunQty;
private string PAPL_Colour;
private decimal PAPL_DayLT;
private decimal PAPL_HourLT;
private decimal PAPL_DayLTCum;
private decimal PAPL_HourLTCum;

private int PAPL_ProcessLoc;
private int PAPL_NumofMachines;
private int PAPL_ScheduleType;
private string PAPL_ScheduleOrder;
private string PAPL_LaborDep;
private string PAPL_MachineDep;
private string PAPL_ToolDep;
private string PAPL_CapacityRestrict;

private int PAPL_QtyOption;
private int PAPL_DaysInAdvance;
private string PAPL_PartsonSpecShift;
private string PAPL_LongSetup;
private string PAPL_ShortSetup;
private string PAPL_BatchOperation;
private string PAPL_BatchSize;
private string PAPL_NextOpQtyTransfer;
private string PAPL_ReportingPoint;

private string PAPL_SeqSched;
private string PAPL_MainMaterial;
private int PAPL_MainMatSeq;
private decimal PAPL_MainMatQty;

private string PAPL_MainToolType;
private int PAPL_NumofTools;
private string PAPL_SchGroup1;
private string PAPL_SchGroup2;
private string PAPL_SchGroup3;
private string PAPL_SchGroup4;
private string PAPL_SchGroup5;
private string PAPL_SchGroup6;

private string PAPL_Forecast;
private string PAPL_ForeTimeFence;
private string PAPL_ExcludeAlloc;
private string PAPL_TransferToNext;

private string PAPL_ExcludeSats = "N";
private string PAPL_ExcludeSuns = "N";

public
ProdFmActPlanDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PAPL_ProdID = reader.GetString("PAPL_ProdID").Trim();
	this.PAPL_ActID = reader.GetString("PAPL_ActID");
	this.PAPL_Seq = reader.GetInt32("PAPL_Seq");
	this.PAPL_StdPack = reader.GetDecimal("PAPL_StdPack");
	this.PAPL_PackType = reader.GetString("PAPL_PackType");
	this.PAPL_SkidQty = reader.GetDecimal("PAPL_SkidQty");
	this.PAPL_SkidType = reader.GetString("PAPL_SkidType");
	this.PAPL_MinInv = reader.GetDecimal("PAPL_MinInv");
	this.PAPL_MaxInv = reader.GetDecimal("PAPL_MaxInv");
	this.PAPL_InvUom = reader.GetString("PAPL_InvUom");
	this.PAPL_MinCon = reader.GetDecimal("PAPL_MinCon");
	this.PAPL_MaxCon = reader.GetDecimal("PAPL_MaxCon");
	this.PAPL_DohMin = reader.GetInt32("PAPL_DohMin");
	this.PAPL_DohMax = reader.GetInt32("PAPL_DohMax");
	this.PAPL_PackWip = reader.GetDecimal("PAPL_PackWip");
	this.PAPL_ContWip = reader.GetString("PAPL_ContWip");
	this.PAPL_TarRunQty = reader.GetDecimal("PAPL_TarRunQty");
	this.PAPL_Colour = reader.GetString("PAPL_Colour");
	this.PAPL_DayLT = reader.GetDecimal("PAPL_DayLT");
	this.PAPL_HourLT = reader.GetDecimal("PAPL_HourLT");
	this.PAPL_DayLTCum = reader.GetDecimal("PAPL_DayLTCum");
	this.PAPL_HourLTCum = reader.GetDecimal("PAPL_HourLTCum");

	this.PAPL_ProcessLoc = reader.GetInt32("PAPL_ProcessLoc");
	this.PAPL_NumofMachines = reader.GetInt32("PAPL_NumofMachines");
	this.PAPL_ScheduleType = reader.GetInt32("PAPL_ScheduleType");
	this.PAPL_ScheduleOrder = reader.GetString("PAPL_ScheduleOrder");
	this.PAPL_LaborDep = reader.GetString("PAPL_LaborDep");
	this.PAPL_MachineDep = reader.GetString("PAPL_MachineDep");
	this.PAPL_ToolDep = reader.GetString("PAPL_ToolDep");
	this.PAPL_CapacityRestrict = reader.GetString("PAPL_CapacityRestrict");

	this.PAPL_QtyOption = reader.GetInt32("PAPL_QtyOption");
	this.PAPL_DaysInAdvance = reader.GetInt32("PAPL_DaysInAdvance");
	this.PAPL_PartsonSpecShift = reader.GetString("PAPL_PartsonSpecShift");
	this.PAPL_LongSetup = reader.GetString("PAPL_LongSetup");
	this.PAPL_ShortSetup = reader.GetString("PAPL_ShortSetup");
	this.PAPL_BatchOperation = reader.GetString("PAPL_BatchOperation");
	this.PAPL_BatchSize = reader.GetString("PAPL_BatchSize");
	this.PAPL_NextOpQtyTransfer = reader.GetString("PAPL_NextOpQtyTransfer");
	this.PAPL_ReportingPoint = reader.GetString("PAPL_ReportingPoint");

	this.PAPL_SeqSched = reader.GetString("PAPL_SeqSched");
	this.PAPL_MainMaterial = reader.GetString("PAPL_MainMaterial");
	this.PAPL_MainMatSeq = reader.GetInt32("PAPL_MainMatSeq");
	this.PAPL_MainMatQty = reader.GetDecimal("PAPL_MainMatQty");

	this.PAPL_MainToolType = reader.GetString("PAPL_MainToolType");
	this.PAPL_NumofTools = reader.GetInt32("PAPL_NumofTools");
	this.PAPL_SchGroup1 = reader.GetString("PAPL_SchGroup1");
	this.PAPL_SchGroup2 = reader.GetString("PAPL_SchGroup2");
	this.PAPL_SchGroup3 = reader.GetString("PAPL_SchGroup3");
	this.PAPL_SchGroup4 = reader.GetString("PAPL_SchGroup4");
	this.PAPL_SchGroup5 = reader.GetString("PAPL_SchGroup5");
	this.PAPL_SchGroup6 = reader.GetString("PAPL_SchGroup6");

	this.PAPL_Forecast = reader.GetString("PAPL_Forecast");
	this.PAPL_ForeTimeFence = reader.GetString("PAPL_ForeTimeFence");
	this.PAPL_ExcludeAlloc = reader.GetString("PAPL_ExcludeAlloc");
	this.PAPL_TransferToNext = reader.GetString("PAPL_TransferToNext");

	this.PAPL_ExcludeSats = reader.GetString("PAPL_ExcludeSats");
	this.PAPL_ExcludeSuns = reader.GetString("PAPL_ExcludeSuns");
}


public 
decimal getMinInvCum(){
	try{
		string sql = "select sum(PAPL_MinInv) "+
			"from prodfmactplan " +
			"where PAPL_ProdID = '" + Converter.fixString(PAPL_ProdID) + "' and PAPL_Seq >= " + 
			NumberUtil.toString(PAPL_Seq);
		
		decimal minInv = 0;
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			minInv = reader.GetDecimal(0);
		reader.Close();
		
		return minInv;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class ProdFmActPlanDataBase <read>: " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class ProdFmActPlanDataBase <read>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + mySqlExc.Message, mySqlExc);
	}
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactplan where " + 
				"PAPL_ProdID  = '" + PAPL_ProdID + "' and " +
				"PAPL_Seq = " + PAPL_Seq;
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
		string sql = "select * from prodfmactplan where " + 
			"PAPL_ProdID  = '" + PAPL_ProdID + "' and " +
			"PAPL_Seq = " + PAPL_Seq;
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
		string sql = "insert into prodfmactplan values('" + 
			Converter.fixString(PAPL_ProdID) + "', '" +
			Converter.fixString(PAPL_ActID) + "', " +
			NumberUtil.toString(PAPL_Seq) + ", " +
			NumberUtil.toString(PAPL_StdPack) + ", '" +
			Converter.fixString(PAPL_PackType) + "', " +
			NumberUtil.toString(PAPL_SkidQty) + ", '" +
			Converter.fixString(PAPL_SkidType) + "', " +
			NumberUtil.toString(PAPL_MinInv) + ", " +
			NumberUtil.toString(PAPL_MaxInv) + ", '" +
			Converter.fixString(PAPL_InvUom) + "', " +
			NumberUtil.toString(PAPL_MinCon) + ", " +
			NumberUtil.toString(PAPL_MaxCon) + ", " +
			NumberUtil.toString(PAPL_DohMin) + ", " +
			NumberUtil.toString(PAPL_DohMax) + ", " +
			NumberUtil.toString(PAPL_PackWip) + ", '" +
			Converter.fixString(PAPL_ContWip) + "', " +
			NumberUtil.toString(PAPL_TarRunQty) + ", '" +
			Converter.fixString(PAPL_Colour) + "', " +
			NumberUtil.toString(PAPL_DayLT) + ", " +
			NumberUtil.toString(PAPL_HourLT) + ", " +
			NumberUtil.toString(PAPL_DayLTCum) + ", " +
			NumberUtil.toString(PAPL_HourLTCum) + ", " +
			NumberUtil.toString(PAPL_ProcessLoc) + ", " +
			NumberUtil.toString(PAPL_NumofMachines) + ", " +
			NumberUtil.toString(PAPL_ScheduleType) + ", '" +
			Converter.fixString(PAPL_ScheduleOrder) + "', '" +
			Converter.fixString(PAPL_LaborDep) + "', '" +
			Converter.fixString(PAPL_MachineDep) + "', '" +
			Converter.fixString(PAPL_ToolDep) + "', " +
			NumberUtil.toString(PAPL_QtyOption) + ", " +
			NumberUtil.toString(PAPL_DaysInAdvance) + ", '" +
			Converter.fixString(PAPL_PartsonSpecShift) + "', '" +
			Converter.fixString(PAPL_LongSetup) + "', '" +
			Converter.fixString(PAPL_ShortSetup) + "', '" +
			Converter.fixString(PAPL_BatchOperation) + "', '" +
			Converter.fixString(PAPL_BatchSize) + "', '" +
			Converter.fixString(PAPL_NextOpQtyTransfer) + "', '" +
			Converter.fixString(PAPL_SeqSched) + "', '" +
			Converter.fixString(PAPL_MainMaterial) + "', " +
			NumberUtil.toString(PAPL_MainMatSeq) + ", " +
			NumberUtil.toString(PAPL_MainMatQty) + ", '" +
			Converter.fixString(PAPL_MainToolType) + "', " +
			NumberUtil.toString(PAPL_NumofTools) + ", '" +
			Converter.fixString(PAPL_SchGroup1) + "', '" +
			Converter.fixString(PAPL_SchGroup2) + "', '" +
			Converter.fixString(PAPL_SchGroup3) + "', '" +
			Converter.fixString(PAPL_SchGroup4) + "', '" +
			Converter.fixString(PAPL_SchGroup5) + "', '" +
			Converter.fixString(PAPL_SchGroup6) + "', '" +
			Converter.fixString(PAPL_Forecast) + "', '" +
			Converter.fixString(PAPL_ForeTimeFence) + "', '" +
			Converter.fixString(PAPL_ReportingPoint) + "', '" +
			Converter.fixString(PAPL_ExcludeAlloc) + "', '" +
			Converter.fixString(PAPL_CapacityRestrict) + "', '" + 
			Converter.fixString(PAPL_TransferToNext) + "', '" + 
			Converter.fixString(PAPL_ExcludeSats) + "', '" + 
			Converter.fixString(PAPL_ExcludeSuns) + "')";

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
		string sql = "update prodfmactplan set " +
			"PAPL_StdPack = "	+ NumberUtil.toString(PAPL_StdPack)		+ ", " +
			"PAPL_PackType = '" + Converter.fixString(PAPL_PackType)	+ "', " +
			"PAPL_SkidQty = "	+ NumberUtil.toString(PAPL_SkidQty)		+ ", " +
			"PAPL_SkidType = '" + Converter.fixString(PAPL_SkidType)	+ "', " + 
			"PAPL_MinInv = "	+ NumberUtil.toString(PAPL_MinInv)		+ ", " + 
			"PAPL_MaxInv = "	+ NumberUtil.toString(PAPL_MaxInv)		+ ", " + 
			"PAPL_InvUom = '"	+ Converter.fixString(PAPL_InvUom)		+ "', " + 
			"PAPL_MinCon = "	+ NumberUtil.toString(PAPL_MinCon)		+ ", " + 
			"PAPL_MaxCon = "	+ NumberUtil.toString(PAPL_MaxCon)		+ ", " + 
			"PAPL_DohMin = "	+ PAPL_DohMin							+ ", " + 
			"PAPL_DohMax = "	+ PAPL_DohMax							+ ", " + 
			"PAPL_PackWip = "	+ NumberUtil.toString(PAPL_PackWip)		+ ", " +
			"PAPL_ContWip = '"	+ Converter.fixString(PAPL_ContWip)		+ "', " + 
			"PAPL_TarRunQty	= " + NumberUtil.toString(PAPL_TarRunQty)	+ ", " + 
			"PAPL_Colour = '"	+ Converter.fixString(PAPL_Colour)		+ "', " +
			"PAPL_DayLT = "		+ NumberUtil.toString(PAPL_DayLT)		+ ", " +
			"PAPL_HourLT = "	+ NumberUtil.toString(PAPL_HourLT)		+ ", " +
			"PAPL_DayLTCum = "	+ NumberUtil.toString(PAPL_DayLTCum)	+ ", " +
			"PAPL_HourLTCum = " + NumberUtil.toString(PAPL_HourLTCum)	+ ", " +

			"PAPL_MainMaterial = '" + Converter.fixString(PAPL_MainMaterial) + "', " +
			"PAPL_MainMatSeq = " + NumberUtil.toString(PAPL_MainMatSeq) + ", " +
			"PAPL_MainMatQty = " + NumberUtil.toString(PAPL_MainMatQty) + ", " +
			
			"PAPL_MainToolType = '" + Converter.fixString(PAPL_MainToolType) + "', " + 
			"PAPL_NumofTools = " + NumberUtil.toString(PAPL_NumofTools) + ", " + 
			"PAPL_SchGroup1 = '" + Converter.fixString(PAPL_SchGroup1) + "', " + 
			"PAPL_SchGroup2 = '" + Converter.fixString(PAPL_SchGroup2) + "', " + 
			"PAPL_SchGroup3 = '" + Converter.fixString(PAPL_SchGroup3) + "', " + 
			"PAPL_SchGroup4 = '" + Converter.fixString(PAPL_SchGroup4) + "', " + 
			"PAPL_SchGroup5 = '" + Converter.fixString(PAPL_SchGroup5) + "', " + 
			"PAPL_SchGroup6 = '" + Converter.fixString(PAPL_SchGroup6) + "', " + 

			"PAPL_Forecast = '" + Converter.fixString(PAPL_Forecast) + "', " + 
			"PAPL_ForeTimeFence = '" + Converter.fixString(PAPL_ForeTimeFence) + "', " + 

			"PAPL_ProcessLoc = " + NumberUtil.toString(PAPL_ProcessLoc) + ", " + 
			"PAPL_NumofMachines = " + NumberUtil.toString(PAPL_NumofMachines) + ", " + 
			"PAPL_ScheduleType = " + NumberUtil.toString(PAPL_ScheduleType) + ", " + 
			"PAPL_ScheduleOrder = '" + Converter.fixString(PAPL_ScheduleOrder) + "', " + 
			"PAPL_LaborDep = '" + Converter.fixString(PAPL_LaborDep) + "', " + 
			"PAPL_MachineDep = '" + Converter.fixString(PAPL_MachineDep) + "', " + 
			"PAPL_ToolDep = '" + Converter.fixString(PAPL_ToolDep) + "', " + 
			"PAPL_CapacityRestrict = '" + Converter.fixString(PAPL_CapacityRestrict) + "', " + 

			"PAPL_QtyOption = " + NumberUtil.toString(PAPL_QtyOption) + ", " + 
			"PAPL_DaysInAdvance = " + NumberUtil.toString(PAPL_DaysInAdvance) + ", " + 
			"PAPL_PartsonSpecShift = '" + Converter.fixString(PAPL_PartsonSpecShift) + "', " + 
			"PAPL_LongSetup = '" + Converter.fixString(PAPL_LongSetup) + "', " + 
			"PAPL_ShortSetup = '" + Converter.fixString(PAPL_ShortSetup) + "', " + 
			"PAPL_BatchOperation = '" + Converter.fixString(PAPL_BatchOperation) + "', " + 
			"PAPL_BatchSize = '" + Converter.fixString(PAPL_BatchSize) + "', " + 
			"PAPL_NextOpQtyTransfer = '" + Converter.fixString(PAPL_NextOpQtyTransfer) + "', " + 
			"PAPL_ReportingPoint = '" + Converter.fixString(PAPL_ReportingPoint) + "', " + 
			"PAPL_ExcludeAlloc = '" + Converter.fixString(PAPL_ExcludeAlloc) + "', " + 
			"PAPL_TransferToNext = '" + Converter.fixString(PAPL_TransferToNext) + "', " +
			"PAPL_ExcludeSats = '" + Converter.fixString(PAPL_ExcludeSats) + "', " + 
			"PAPL_ExcludeSuns = '" + Converter.fixString(PAPL_ExcludeSuns) + "'" +
		" where " +
			"PAPL_ProdID  = '" + PAPL_ProdID + "' and " +
			"PAPL_ActID = '" + PAPL_ActID + "' and " +
			"PAPL_Seq = " + PAPL_Seq;

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
		string sql = "delete from prodfmactplan where " +
			"PAPL_ProdID  = '" + PAPL_ProdID + "' and " +
			"PAPL_ActID = '" + PAPL_ActID + "' and " +
			"PAPL_Seq = " + PAPL_Seq;
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
void setPAPL_ProdID(string PAPL_ProdID){
	this.PAPL_ProdID = PAPL_ProdID;
}

public
void setPAPL_ActID(string PAPL_ActID){
	this.PAPL_ActID = PAPL_ActID;
}

public
void setPAPL_Seq(int PAPL_Seq){
	this.PAPL_Seq = PAPL_Seq;
}

public
void setPAPL_StdPack(decimal PAPL_StdPack){
	this.PAPL_StdPack = PAPL_StdPack;
}

public
void setPAPL_PackType(string PAPL_PackType){
	this.PAPL_PackType = PAPL_PackType;
}

public
void setPAPL_SkidQty(decimal PAPL_SkidQty){
	this.PAPL_SkidQty = PAPL_SkidQty;
}

public
void setPAPL_SkidType(string PAPL_SkidType){
	this.PAPL_SkidType = PAPL_SkidType;
}

public
void setPAPL_MinInv(decimal PAPL_MinInv){
	this.PAPL_MinInv = PAPL_MinInv;
}

public
void setPAPL_MaxInv(decimal PAPL_MaxInv){
	this.PAPL_MaxInv = PAPL_MaxInv;
}

public
void setPAPL_InvUom(string PAPL_InvUom){
	this.PAPL_InvUom = PAPL_InvUom;
}

public
void setPAPL_MinCon(decimal PAPL_MinCon){
	this.PAPL_MinCon = PAPL_MinCon;
}

public
void setPAPL_MaxCon(decimal PAPL_MaxCon){
	this.PAPL_MaxCon = PAPL_MaxCon;
}

public
void setPAPL_DohMin(int PAPL_DohMin){
	this.PAPL_DohMin = PAPL_DohMin;
}

public
void setPAPL_DohMax(int PAPL_DohMax){
	this.PAPL_DohMax = PAPL_DohMax;
}

public
void setPAPL_PackWip(decimal PAPL_PackWip){
	this.PAPL_PackWip = PAPL_PackWip;
}

public
void setPAPL_ContWip(string PAPL_ContWip){
	this.PAPL_ContWip = PAPL_ContWip;
}

public
void setPAPL_TarRunQty(decimal PAPL_TarRunQty){
	this.PAPL_TarRunQty = PAPL_TarRunQty;
}

public
void setPAPL_Colour(string PAPL_Colour){
	this.PAPL_Colour = PAPL_Colour;
}

public
void setPAPL_DayLT(decimal PAPL_DayLT){
	this.PAPL_DayLT = PAPL_DayLT;
}

public
void setPAPL_HourLT(decimal PAPL_HourLT){
	this.PAPL_HourLT = PAPL_HourLT;
}

public
void setPAPL_DayLTCum(decimal PAPL_DayLTCum){
	this.PAPL_DayLTCum = PAPL_DayLTCum;
}

public
void setPAPL_HourLTCum(decimal PAPL_HourLTCum){
	this.PAPL_HourLTCum = PAPL_HourLTCum;
}

public
void setPAPL_ProcessLoc(int PAPL_ProcessLoc){
	this.PAPL_ProcessLoc = PAPL_ProcessLoc;
}

public
void setPAPL_NumofMachines(int PAPL_NumofMachines){
	this.PAPL_NumofMachines = PAPL_NumofMachines;
}

public
void setPAPL_ScheduleType(int PAPL_ScheduleType){
	this.PAPL_ScheduleType = PAPL_ScheduleType;
}

public
void setPAPL_ScheduleOrder(string PAPL_ScheduleOrder){
	this.PAPL_ScheduleOrder = PAPL_ScheduleOrder;
}

public
void setPAPL_LaborDep(string PAPL_LaborDep){
	this.PAPL_LaborDep = PAPL_LaborDep;
}

public
void setPAPL_MachineDep(string PAPL_MachineDep){
	this.PAPL_MachineDep = PAPL_MachineDep;
}

public
void setPAPL_ToolDep(string PAPL_ToolDep){
	this.PAPL_ToolDep = PAPL_ToolDep;
}

public
void setPAPL_CapacityRestrict(string PAPL_CapacityRestrict){
	this.PAPL_CapacityRestrict = PAPL_CapacityRestrict;
}

public
void setPAPL_QtyOption(int PAPL_QtyOption){
	this.PAPL_QtyOption = PAPL_QtyOption;
}

public
void setPAPL_DaysInAdvance(int PAPL_DaysInAdvance){
	this.PAPL_DaysInAdvance = PAPL_DaysInAdvance;
}

public
void setPAPL_PartsonSpecShift(string PAPL_PartsonSpecShift){
	this.PAPL_PartsonSpecShift = PAPL_PartsonSpecShift;
}

public
void setPAPL_LongSetup(string PAPL_LongSetup){
	this.PAPL_LongSetup = PAPL_LongSetup;
}

public
void setPAPL_ShortSetup(string PAPL_ShortSetup){
	this.PAPL_ShortSetup = PAPL_ShortSetup;
}

public
void setPAPL_BatchOperation(string PAPL_BatchOperation){
	this.PAPL_BatchOperation = PAPL_BatchOperation;
}

public
void setPAPL_BatchSize(string PAPL_BatchSize){
	this.PAPL_BatchSize = PAPL_BatchSize;
}

public
void setPAPL_NextOpQtyTransfer(string PAPL_NextOpQtyTransfer){
	this.PAPL_NextOpQtyTransfer = PAPL_NextOpQtyTransfer;
}

public
void setPAPL_SeqSched(string PAPL_SeqSched){
	this.PAPL_SeqSched = PAPL_SeqSched;
}

public
void setPAPL_MainMaterial(string PAPL_MainMaterial){
	this.PAPL_MainMaterial = PAPL_MainMaterial;
}

public
void setPAPL_MainMatSeq(int PAPL_MainMatSeq){
	this.PAPL_MainMatSeq = PAPL_MainMatSeq;
}

public
void setPAPL_MainMatQty(decimal PAPL_MainMatQty){
	this.PAPL_MainMatQty = PAPL_MainMatQty;
}

public
void setPAPL_MainToolType(string PAPL_MainToolType){
	this.PAPL_MainToolType = PAPL_MainToolType;
}

public
void setPAPL_NumofTools(int PAPL_NumofTools){
	this.PAPL_NumofTools = PAPL_NumofTools;
}

public
void setPAPL_SchGroup1(string PAPL_SchGroup1){
	this.PAPL_SchGroup1 = PAPL_SchGroup1;
}

public
void setPAPL_SchGroup2(string PAPL_SchGroup2){
	this.PAPL_SchGroup2 = PAPL_SchGroup2;
}

public
void setPAPL_SchGroup3(string PAPL_SchGroup3){
	this.PAPL_SchGroup3 = PAPL_SchGroup3;
}

public
void setPAPL_SchGroup4(string PAPL_SchGroup4){
	this.PAPL_SchGroup4 = PAPL_SchGroup4;
}

public
void setPAPL_SchGroup5(string PAPL_SchGroup5){
	this.PAPL_SchGroup5 = PAPL_SchGroup5;
}

public
void setPAPL_SchGroup6(string PAPL_SchGroup6){
	this.PAPL_SchGroup6 = PAPL_SchGroup6;
}

public
void setPAPL_Forecast(string PAPL_Forecast){
	this.PAPL_Forecast = PAPL_Forecast;
}

public
void setPAPL_ForeTimeFence(string PAPL_ForeTimeFence){
	this.PAPL_ForeTimeFence = PAPL_ForeTimeFence;
}

public
void setPAPL_ExcludeAlloc(string PAPL_ExcludeAlloc){
	this.PAPL_ExcludeAlloc = PAPL_ExcludeAlloc;
}

public
void setPAPL_ReportingPoint(string PAPL_ReportingPoint){
	this.PAPL_ReportingPoint = PAPL_ReportingPoint;
}

public
void setPAPL_TransferToNext(string PAPL_TransferToNext){
	this.PAPL_TransferToNext = PAPL_TransferToNext;
}

public
void setPAPL_ExcludeSats(string PAPL_ExcludeSats){
	this.PAPL_ExcludeSats = PAPL_ExcludeSats;
}

public
void setPAPL_ExcludeSuns(string PAPL_ExcludeSuns){
	this.PAPL_ExcludeSuns = PAPL_ExcludeSuns;
}


public
string getPAPL_ProdID(){
	return PAPL_ProdID;
}

public
string getPAPL_ActID(){
	return PAPL_ActID;
}

public
int getPAPL_Seq(){
	return PAPL_Seq;
}

public
decimal getPAPL_StdPack(){
	return PAPL_StdPack;
}

public
string getPAPL_PackType(){
	return PAPL_PackType;
}

public
decimal getPAPL_SkidQty(){
	return PAPL_SkidQty;
}

public
string getPAPL_SkidType(){
	return PAPL_SkidType;
}

public
decimal getPAPL_MinInv(){
	return PAPL_MinInv;
}

public
decimal getPAPL_MaxInv(){
	return PAPL_MaxInv;
}

public
string getPAPL_InvUom(){
	return PAPL_InvUom;
}

public
decimal getPAPL_MinCon(){
	return PAPL_MinCon;
}

public
decimal getPAPL_MaxCon(){
	return PAPL_MaxCon;
}

public
int getPAPL_DohMin(){
	return PAPL_DohMin;
}

public
int getPAPL_DohMax(){
	return PAPL_DohMax;
}

public
decimal getPAPL_PackWip(){
	return PAPL_PackWip;
}

public
string getPAPL_ContWip(){
	return PAPL_ContWip;
}

public
decimal getPAPL_TarRunQty(){
	return PAPL_TarRunQty;
}

public
string getPAPL_Colour(){
	return PAPL_Colour;
}

public
decimal getPAPL_DayLT(){
	return PAPL_DayLT;
}

public
decimal getPAPL_HourLT(){
	return PAPL_HourLT;
}

public
decimal getPAPL_DayLTCum(){
	return PAPL_DayLTCum;
}

public
decimal getPAPL_HourLTCum(){
	return PAPL_HourLTCum;
}

public
int getPAPL_ProcessLoc(){
	return PAPL_ProcessLoc;
}

public
int getPAPL_NumofMachines(){
	return PAPL_NumofMachines;
}

public
int getPAPL_ScheduleType(){
	return PAPL_ScheduleType;
}

public
string getPAPL_ScheduleOrder(){
	return PAPL_ScheduleOrder;
}

public
string getPAPL_LaborDep(){
	return PAPL_LaborDep;
}

public
string getPAPL_MachineDep(){
	return PAPL_MachineDep;
}

public
string getPAPL_ToolDep(){
	return PAPL_ToolDep;
}

public
string getPAPL_CapacityRestrict(){
	return PAPL_CapacityRestrict;
}

public
int getPAPL_QtyOption(){
	return PAPL_QtyOption;
}

public
int getPAPL_DaysInAdvance(){
	return PAPL_DaysInAdvance;
}

public
string getPAPL_PartsonSpecShift(){
	return PAPL_PartsonSpecShift;
}

public
string getPAPL_LongSetup(){
	return PAPL_LongSetup;
}

public
string getPAPL_ShortSetup(){
	return PAPL_ShortSetup;
}

public
string getPAPL_BatchOperation(){
	return PAPL_BatchOperation;
}

public
string getPAPL_BatchSize(){
	return PAPL_BatchSize;
}

public
string getPAPL_NextOpQtyTransfer(){
	return PAPL_NextOpQtyTransfer;
}

public
string getPAPL_SeqSched(){
	return PAPL_SeqSched;
}

public
string getPAPL_MainMaterial(){
	return PAPL_MainMaterial;
}

public
int getPAPL_MainMatSeq(){
	return PAPL_MainMatSeq;
}

public
decimal getPAPL_MainMatQty(){
	return PAPL_MainMatQty;
}

public
string getPAPL_MainToolType(){
	return PAPL_MainToolType;
}

public
int getPAPL_NumofTools(){
	return PAPL_NumofTools;
}

public
string getPAPL_SchGroup1(){
	return PAPL_SchGroup1;
}

public
string getPAPL_SchGroup2(){
	return PAPL_SchGroup2;
}

public
string getPAPL_SchGroup3(){
	return PAPL_SchGroup3;
}

public
string getPAPL_SchGroup4(){
	return PAPL_SchGroup4;
}

public
string getPAPL_SchGroup5(){
	return PAPL_SchGroup5;
}

public
string getPAPL_SchGroup6(){
	return PAPL_SchGroup6;
}

public
string getPAPL_Forecast(){
	return PAPL_Forecast;
}

public
string getPAPL_ForeTimeFence(){
	return PAPL_ForeTimeFence;
}

public
string getKey(){
	return PAPL_ProdID + "_" + PAPL_Seq.ToString();
}

public
string getPAPL_ExcludeAlloc(){
	return PAPL_ExcludeAlloc;
}

public
string getPAPL_ReportingPoint(){
	return PAPL_ReportingPoint;
}

public
string getPAPL_TransferToNext(){
	return PAPL_TransferToNext;
}

public
string getPAPL_ExcludeSats(){
	return PAPL_ExcludeSats;
}

public
string getPAPL_ExcludeSuns(){
	return PAPL_ExcludeSuns;
}


} // class

} // namespace
