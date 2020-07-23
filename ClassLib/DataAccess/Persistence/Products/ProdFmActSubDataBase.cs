using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActSubDataBase : GenericDataBaseElement{

public const string ORDER_BY_PRODSEQ_ROUTTYPE = " order by PC_ProdID, PC_Seq, PC_RoutingType desc ";

private int PC_Id;
private string PC_ProdID;
private string PC_Plt;
private string PC_Dept;
private string PC_ActID;
private int PC_Seq;
private string PC_SubID;
private int PC_SubIDRank;
private int PC_SubOrdNum;
private int PC_MethodRank;
private string PC_Cfg;
private string PC_VarFam;
private decimal PC_CycleTm;
private string PC_CycleUom;
private decimal PC_RunStd;
private decimal PC_CavityNum;
private decimal PC_CavUnavail;
private decimal PC_CavAvail;
private decimal PC_CycleHr;
private string PC_BatchProc;
private decimal PC_BatchTm;
private decimal PC_BatchQty;
private string PC_BatchUom;
private string PC_RepPoint;
private string PC_ECNCurr;
private decimal PC_YieldPer;
private decimal PC_ReworkPer;
private string PC_SchSort1;
private string PC_SchSort2;
private int PC_ProdLev;
private string PC_SubIDDes;
private string PC_ActType;
private string PC_OneTm;
private decimal PC_Tm;
private string PC_UseMach;
private decimal PC_MachCyc;
private string PC_IndDept;
private string PC_LabOnly;
private string PC_FamOnly;
private int PC_QtyMen;
private int PC_QtyMachines;
private string PC_RoutingType;
private decimal PC_ScrapPercent;
private decimal PC_Efficiency;
private decimal PC_OptRunQty;

public
ProdFmActSubDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public
bool exists(){
	string sql = "select * from prodfmactsub where " + getWhereCondition();
	return exists(sql);
}

public
bool existsByPartSeq(){
	string sql = "select * from prodfmactsub where PC_ProdID = '" + PC_ProdID + "' and PC_Seq = " + PC_Seq;
	return exists(sql);
}

public
bool readById(){
	string sql = "select * from prodfmactsub where PC_Id = " + NumberUtil.toString(PC_Id);
	return read(sql);
}

public
string getWhereCondition(){
	string sqlWhere =   "PC_ProdID = '" + PC_ProdID + "' and " +
                        "PC_Plt = '" + PC_Plt + "' and " +
                        "PC_Dept = '" + PC_Dept + "' and " +
                        "PC_ActID = '" + PC_ActID + "' and " +
                        "PC_Seq = " + PC_Seq + " and " +          
                        "PC_Cfg = '" + PC_Cfg + "'";
	return sqlWhere;
}

public override
void load(NotNullDataReader reader){
    this.PC_Id  = reader.GetInt32("PC_Id");
    this.PC_ProdID = reader.GetString("PC_ProdID");
	this.PC_Plt = reader.GetString("PC_Plt");
	this.PC_Dept = reader.GetString("PC_Dept");
	this.PC_ActID = reader.GetString("PC_ActID");
	this.PC_Seq = reader.GetInt32("PC_Seq");
	this.PC_SubID = reader.GetString("PC_SubID");
	this.PC_SubIDRank = reader.GetInt32("PC_SubIDRank");
	this.PC_SubOrdNum = reader.GetInt32("PC_SubOrdNum");
	this.PC_MethodRank = reader.GetInt32("PC_MethodRank");
	this.PC_Cfg = reader.GetString("PC_Cfg");
	this.PC_VarFam = reader.GetString("PC_VarFam");
	this.PC_CycleTm = reader.GetDecimal("PC_CycleTm");
	this.PC_CycleUom = reader.GetString("PC_CycleUom");
	this.PC_RunStd = reader.GetDecimal("PC_RunStd");
	this.PC_CavityNum = reader.GetDecimal("PC_CavityNum");
	this.PC_CavUnavail = reader.GetDecimal("PC_CavUnavail");
	this.PC_CavAvail = reader.GetDecimal("PC_CavAvail");
	this.PC_CycleHr = reader.GetDecimal("PC_CycleHr");
	this.PC_BatchProc = reader.GetString("PC_BatchProc");
	this.PC_BatchTm = reader.GetDecimal("PC_BatchTm");
	this.PC_BatchQty = reader.GetDecimal("PC_BatchQty");
	this.PC_BatchUom = reader.GetString("PC_BatchUom");
	this.PC_RepPoint = reader.GetString("PC_RepPoint");
	this.PC_ECNCurr = reader.GetString("PC_ECNCurr");
	this.PC_YieldPer = reader.GetDecimal("PC_YieldPer");
	this.PC_ReworkPer = reader.GetDecimal("PC_ReworkPer");
	this.PC_SchSort1 = reader.GetString("PC_SchSort1");
	this.PC_SchSort2 = reader.GetString("PC_SchSort2");
	this.PC_ProdLev = reader.GetInt32("PC_ProdLev");
	this.PC_SubIDDes = reader.GetString("PC_SubIDDes");
	this.PC_ActType = reader.GetString("PC_ActType");
	this.PC_OneTm = reader.GetString("PC_OneTm");
	this.PC_Tm = reader.GetDecimal("PC_Tm");
	this.PC_UseMach = reader.GetString("PC_UseMach");
	this.PC_MachCyc = reader.GetDecimal("PC_MachCyc");
	this.PC_IndDept = reader.GetString("PC_IndDept");
	this.PC_LabOnly = reader.GetString("PC_LabOnly");
	this.PC_FamOnly = reader.GetString("PC_FamOnly");
	this.PC_QtyMen = reader.GetInt32("PC_QtyMen");
	this.PC_QtyMachines = reader.GetInt32("PC_QtyMachines");
    this.PC_RoutingType = reader.GetString("PC_RoutingType");
    this.PC_ScrapPercent = reader.GetDecimal("PC_ScrapPercent");
    this.PC_Efficiency = reader.GetDecimal("PC_Efficiency");
    this.PC_OptRunQty = reader.GetDecimal("PC_OptRunQty");
}

public override
void write(){
	
    string sql = "insert into prodfmactsub values('" + 
	Converter.fixString(PC_ProdID) + "', '" +
	Converter.fixString(PC_Plt) + "', '" +
	Converter.fixString(PC_Dept) + "', '" +
	Converter.fixString(PC_ActID) + "', " +
	PC_Seq + ", '" +
	Converter.fixString(PC_SubID) + "', " +
	PC_SubIDRank + ", " +
	PC_SubOrdNum + ", " +
	PC_MethodRank + ", '" +
	Converter.fixString(PC_Cfg) + "', '" +
	Converter.fixString(PC_VarFam) + "', " +
	NumberUtil.toString(PC_CycleTm) + ", '"+
	Converter.fixString(PC_CycleUom) + "', " +
	NumberUtil.toString(PC_RunStd) + ", "+
	NumberUtil.toString(PC_CavityNum) + ", "+
	NumberUtil.toString(PC_CavUnavail) + ", "+
	NumberUtil.toString(PC_CavAvail) + ", "+
	NumberUtil.toString(PC_CycleHr) + ", '"+
	Converter.fixString(PC_BatchProc) + "', " +
	NumberUtil.toString(PC_BatchTm) + ", "+
	NumberUtil.toString(PC_BatchQty) + ", '"+
	Converter.fixString(PC_BatchUom) + "', '" +
	Converter.fixString(PC_RepPoint) + "', '" +
	Converter.fixString(PC_ECNCurr) + "', " +
	NumberUtil.toString(PC_YieldPer) + ", "+
	NumberUtil.toString(PC_ReworkPer) + ", '"+
	Converter.fixString(PC_SchSort1) + "', '" +
	Converter.fixString(PC_SchSort2) + "'," +	
    NumberUtil.toString(PC_ProdLev) + ", '" +
    Converter.fixString(PC_SubIDDes) + "', '" +
	Converter.fixString(PC_ActType) + "', '" +
	Converter.fixString(PC_OneTm) + "', " +
	NumberUtil.toString(PC_Tm) + ", '"+
	Converter.fixString(PC_UseMach) + "', " +
	NumberUtil.toString(PC_MachCyc) + ", '"+
	Converter.fixString(PC_IndDept) + "', '" +
	Converter.fixString(PC_LabOnly) + "', '" +
	Converter.fixString(PC_FamOnly) + "', " +
	NumberUtil.toString(PC_QtyMen) + ", " +
	NumberUtil.toString(PC_QtyMachines) + ", " +
    "'"  +  Converter.fixString(PC_RoutingType) + "', " +
    NumberUtil.toString(PC_ScrapPercent) + ", " +
    NumberUtil.toString(PC_Efficiency) + ", " +
    NumberUtil.toString(PC_OptRunQty) +   ")";
            
    write(sql);				
    this.setPC_Id(dataBaseAccess.getLastId());	    	
}

public
bool read(){
	string sql = "select * from prodfmactsub where " + getWhereCondition();			
	return read(sql);
}

public
bool readByPartSeq(){
	string sql = "select * from prodfmactsub where " + 
			"PC_ProdID = '" + PC_ProdID + "' and " +
			"PC_Seq = " + PC_Seq + ORDER_BY_PRODSEQ_ROUTTYPE;

    return read(sql);
}

public
bool readByPartSeqPlant(){
	string sql = "select * from prodfmactsub where " +
                "PC_ProdID = '" + PC_ProdID + "' and " +
                "PC_Plt = '" + PC_Plt + "' and " +
                "PC_Seq = " + PC_Seq + ORDER_BY_PRODSEQ_ROUTTYPE;
    return read(sql);
}

/*
public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where " + 
			"PC_ProdID = '" + PC_ProdID + "' and " +
			"PC_Seq = " + PC_Seq;
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
}*/

public 
bool readForBom(){
	string sql = "select * from prodfmactsub where " + 
		"PC_ProdID = '" + PC_ProdID + "' and " +
		"PC_Seq = " + PC_Seq + ORDER_BY_PRODSEQ_ROUTTYPE;
	return read(sql);
}

public 
bool readForBomOnlyByProd(){			
	string sql = "select * from prodfmactsub where " + 
		"PC_ProdID = '" + PC_ProdID + "'" + ORDER_BY_PRODSEQ_ROUTTYPE;
	return read(sql);		
}

public 
bool existsPart(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from prodfmactsub where PC_ProdID = '" + PC_ProdID + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
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

public 
bool existsPartSeq(){
	string sql = "select * from prodfmactsub where PC_ProdID = '" + PC_ProdID + "' and " +
		"PC_Seq = " + NumberUtil.toString(PC_Seq);

    return exists(sql);		
}

public override
void update(){  
  update(true);
}

public  
void updateShort(){  
  update(false);
}

private  
void update(bool bfull){
	string sql = "update prodfmactsub set " + 
		"PC_SubID = '" + Converter.fixString(PC_SubID) + "', " +
		"PC_SubIDRank = " + PC_SubIDRank +" ," +
		"PC_SubOrdNum = " + PC_SubOrdNum  +" ," +
		"PC_MethodRank = " +PC_MethodRank +" ," +
		"PC_Cfg = '" + Converter.fixString(PC_Cfg) + "', " +
		"PC_VarFam  = '" + Converter.fixString(PC_VarFam) + "', " +
		"PC_CycleTm = " + NumberUtil.toString(PC_CycleTm) + ", " +
		"PC_CycleUom = ' " + Converter.fixString(PC_CycleUom) + "', " +
		"PC_RunStd = " + NumberUtil.toString(PC_RunStd) + ", " +
		"PC_CavityNum = " + NumberUtil.toString(PC_CavityNum) +  ", " +
		"PC_CavUnavail = " + NumberUtil.toString(PC_CavUnavail) + ", " +
		"PC_CavAvail = " + NumberUtil.toString(PC_CavAvail) + ", " +
		"PC_CycleHr = " + NumberUtil.toString(PC_CycleHr) +  ", " +
		"PC_BatchProc = '" + Converter.fixString(PC_BatchProc) + "', " + 
		"PC_BatchTm = " + NumberUtil.toString(PC_BatchTm) + ", " + 
		"PC_BatchQty = " + NumberUtil.toString(PC_BatchQty) + ", " + 
		"PC_BatchUom = '" + Converter.fixString(PC_BatchUom) + "', " + 
		"PC_RepPoint = '" + Converter.fixString(PC_RepPoint) + "', " +
		"PC_ECNCurr = '" + Converter.fixString(PC_ECNCurr) + "', " +
		"PC_YieldPer = " + NumberUtil.toString(PC_YieldPer) + ", " +
		"PC_ReworkPer = " + NumberUtil.toString(PC_ReworkPer) +  ", " +
		"PC_SchSort1 = '"+ Converter.fixString(PC_SchSort1) + "', " +
		"PC_SchSort2 = '" + Converter.fixString(PC_SchSort2) + "', " +		
		"PC_SubIDDes = '" + Converter.fixString(PC_SubIDDes) + "', " +
		"PC_ActType = '" + Converter.fixString(PC_ActType) + "', " +
		"PC_OneTm = '"+ Converter.fixString(PC_OneTm) + "', " +
		"PC_Tm = " + NumberUtil.toString(PC_Tm) + ", " + 
		"PC_UseMach = '" + Converter.fixString(PC_UseMach) + "', " + 
		"PC_MachCyc = " +NumberUtil.toString(PC_MachCyc) + ", " +
		"PC_IndDept = '" + Converter.fixString(PC_IndDept) + "', " +
		"PC_LabOnly = '" + Converter.fixString(PC_LabOnly) + "', " +
		"PC_FamOnly ='" + Converter.fixString(PC_FamOnly) + "', " +
		"PC_QtyMen = " + NumberUtil.toString(PC_QtyMen) + ", " +
		"PC_QtyMachines = " + NumberUtil.toString(PC_QtyMachines)   + ", " +
        "PC_RoutingType ='" + Converter.fixString(PC_RoutingType)   + "', " +
        "PC_ScrapPercent = " + NumberUtil.toString(PC_ScrapPercent) + ", " +
        "PC_Efficiency = " + NumberUtil.toString(PC_Efficiency) + ", " +
        "PC_OptRunQty = " + NumberUtil.toString(PC_OptRunQty);

    if (bfull)            
        sql+=", PC_ProdLev = " + NumberUtil.toString(PC_ProdLev);

    sql+=" where " +getWhereCondition();
	update(sql);					
}

public override
void delete(){
	try{
		string sql = "delete from prodfmactsub where " +
					"PC_ProdID = '" + PC_ProdID + "' and " +
					"PC_ActID = '" + PC_ActID + "' and " +
					"PC_Seq = " + PC_Seq;
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
void deleteById(){
	string sql = "delete from prodfmactsub where PC_Id = " + NumberUtil.toString(PC_Id);
	base.delete(sql);
}

public
void setPC_Id(int PC_Id){
	this.PC_Id = PC_Id;
}

public
void setPC_ProdID(string PC_ProdID){
	this.PC_ProdID = PC_ProdID;
}

public
void setPC_Plt(string PC_Plt){
	this.PC_Plt = PC_Plt;
}

public
void setPC_Dept(string PC_Dept){
	this.PC_Dept = PC_Dept;
}

public
void setPC_ActID(string PC_ActID){
	this.PC_ActID = PC_ActID;
}

public
void setPC_Seq(int PC_Seq){
	this.PC_Seq = PC_Seq;
}

public
void setPC_SubID(string PC_SubID){
	this.PC_SubID = PC_SubID;
}

public
void setPC_SubIDRank(int PC_SubIDRank){
	this.PC_SubIDRank = PC_SubIDRank;
}

public
void setPC_SubOrdNum(int PC_SubOrdNum){
	this.PC_SubOrdNum = PC_SubOrdNum;
}

public
void setPC_MethodRank(int PC_MethodRank){
	this.PC_MethodRank = PC_MethodRank;
}

public
void setPC_Cfg(string PC_Cfg){
	this.PC_Cfg = PC_Cfg;
}

public
void setPC_VarFam(string PC_VarFam){
	this.PC_VarFam = PC_VarFam;
}

public
void setPC_CycleTm(decimal PC_CycleTm){
	this.PC_CycleTm = PC_CycleTm;
}

public
void setPC_CycleUom(string PC_CycleUom){
	this.PC_CycleUom = PC_CycleUom;
}

public
void setPC_RunStd(decimal PC_RunStd){
	this.PC_RunStd = PC_RunStd;
}

public
void setPC_CavityNum(decimal PC_CavityNum){
	this.PC_CavityNum = PC_CavityNum;
}

public
void setPC_CavUnavail(decimal PC_CavUnavail){
	this.PC_CavUnavail = PC_CavUnavail;
}

public
void setPC_CavAvail(decimal PC_CavAvail){
	this.PC_CavAvail = PC_CavAvail;
}

public
void setPC_CycleHr(decimal PC_CycleHr){
	this.PC_CycleHr = PC_CycleHr;
}

public
void setPC_BatchProc(string PC_BatchProc){
	this.PC_BatchProc = PC_BatchProc;
}

public
void setPC_BatchTm(decimal PC_BatchTm){
	this.PC_BatchTm = PC_BatchTm;
}

public
void setPC_BatchQty(decimal PC_BatchQty){
	this.PC_BatchQty = PC_BatchQty;
}

public
void setPC_BatchUom(string PC_BatchUom){
	this.PC_BatchUom = PC_BatchUom;
}

public
void setPC_RepPoint(string PC_RepPoint){
	this.PC_RepPoint = PC_RepPoint;
}

public
void setPC_ECNCurr(string PC_ECNCurr){
	this.PC_ECNCurr = PC_ECNCurr;
}

public
void setPC_YieldPer(decimal PC_YieldPer){
	this.PC_YieldPer = PC_YieldPer;
}

public
void setPC_ReworkPer(decimal PC_ReworkPer){
	this.PC_ReworkPer = PC_ReworkPer;
}

public
void setPC_SchSort1(string PC_SchSort1){
	this.PC_SchSort1 = PC_SchSort1;
}

public
void setPC_SchSort2(string PC_SchSort2){
	this.PC_SchSort2 = PC_SchSort2;
}

public
void setPC_ProdLev(int PC_ProdLev){
	this.PC_ProdLev = PC_ProdLev;
}

public
void setPC_SubIDDes(string PC_SubIDDes){
	this.PC_SubIDDes = PC_SubIDDes;
}

public
void setPC_ActType(string PC_ActType){
	this.PC_ActType = PC_ActType;
}

public
void setPC_OneTm(string PC_OneTm){
	this.PC_OneTm = PC_OneTm;
}

public
void setPC_Tm(decimal PC_Tm){
	this.PC_Tm = PC_Tm;
}

public
void setPC_UseMach(string PC_UseMach){
	this.PC_UseMach = PC_UseMach;
}

public
void setPC_MachCyc(decimal PC_MachCyc){
	this.PC_MachCyc = PC_MachCyc;
}

public
void setPC_IndDept(string PC_IndDept){
	this.PC_IndDept = PC_IndDept;
}

public
void setPC_LabOnly(string PC_LabOnly){
	this.PC_LabOnly = PC_LabOnly;
}

public
void setPC_FamOnly(string PC_FamOnly){
	this.PC_FamOnly = PC_FamOnly;
}

public
void setPC_QtyMen(int PC_QtyMen){
	this.PC_QtyMen = PC_QtyMen;
}

public
void setPC_QtyMachines(int PC_QtyMachines){
	this.PC_QtyMachines = PC_QtyMachines;
}

public
void setPC_RoutingType(string PC_RoutingType){
	this.PC_RoutingType = PC_RoutingType;
}

public
void setPC_ScrapPercent(decimal PC_ScrapPercent){
	this.PC_ScrapPercent = PC_ScrapPercent;
}

public
void setPC_Efficiency(decimal PC_Efficiency){
	this.PC_Efficiency = PC_Efficiency;
}

public
void setPC_OptRunQty(decimal PC_OptRunQty){
	this.PC_OptRunQty = PC_OptRunQty;
}
               
public
int getPC_Id(){
	return PC_Id;
}

public
string getPC_ProdID(){
	return PC_ProdID;
}

public
string getPC_Plt(){
	return PC_Plt;
}

public
string getPC_Dept(){
	return PC_Dept;
}

public
string getPC_ActID(){
	return PC_ActID;
}

public
int getPC_Seq(){
	return PC_Seq;
}

public
string getPC_SubID(){
	return PC_SubID;
}

public
int getPC_SubIDRank(){
	return PC_SubIDRank;
}

public
int getPC_SubOrdNum(){
	return PC_SubOrdNum;
}

public
int getPC_MethodRank(){
	return PC_MethodRank;
}

public
string getPC_Cfg(){
	return PC_Cfg;
}

public
string getPC_VarFam(){
	return PC_VarFam;
}

public
decimal getPC_CycleTm(){
	return PC_CycleTm;
}

public
string getPC_CycleUom(){
	return PC_CycleUom;
}

public
decimal getPC_RunStd(){
	return PC_RunStd;
}

public
decimal getPC_CavityNum(){
	return PC_CavityNum;
}

public
decimal getPC_CavUnavail(){
	return PC_CavUnavail;
}

public
decimal getPC_CavAvail(){
	return PC_CavAvail;
}

public
decimal getPC_CycleHr(){
	return PC_CycleHr;
}

public
string getPC_BatchProc(){
	return PC_BatchProc;
}

public
decimal getPC_BatchTm(){
	return PC_BatchTm;
}

public
decimal getPC_BatchQty(){
	return PC_BatchQty;
}

public
string getPC_BatchUom(){
	return PC_BatchUom;
}

public
string getPC_RepPoint(){
	return PC_RepPoint;
}

public
string getPC_ECNCurr(){
	return PC_ECNCurr;
}

public
decimal getPC_YieldPer(){
	return PC_YieldPer;
}

public
decimal getPC_ReworkPer(){
	return PC_ReworkPer;
}

public
string getPC_SchSort1(){
	return PC_SchSort1;
}

public
string getPC_SchSort2(){
	return PC_SchSort2;
}

public
int getPC_ProdLev(){
	return PC_ProdLev;
}

public
string getPC_SubIDDes(){
	return PC_SubIDDes;
}

public
string getPC_ActType(){
	return PC_ActType;
}

public
string getPC_OneTm(){
	return PC_OneTm;
}

public
decimal getPC_Tm(){
	return PC_Tm;
}

public
string getPC_UseMach(){
	return PC_UseMach;
}

public
decimal getPC_MachCyc(){
	return PC_MachCyc;
}

public
string getPC_IndDept(){
	return PC_IndDept;
}

public
string getPC_LabOnly(){
	return PC_LabOnly;
}

public
string getPC_FamOnly(){
	return PC_FamOnly;
}

public
int getPC_QtyMen(){
	return PC_QtyMen;
}

public
int getPC_QtyMachines(){
	return PC_QtyMachines;
}

public
string getPC_RoutingType(){
    return PC_RoutingType;
}

public
decimal getPC_ScrapPercent(){
	return PC_ScrapPercent;
}

public
decimal getPC_Efficiency(){
    return PC_Efficiency;
}

public
decimal getPC_OptRunQty(){
    return PC_OptRunQty;
}
	
public 
string[] getCfgFromProd(string plt, string prod){
	NotNullDataReader reader = null;
	try{
		string sql = "select PC_Dept, PC_CFG from ProdFmActSub where " + 
			"PC_ProdID = '" + prod + "' and " +
			"PC_Plt = '" + plt + "'" + ORDER_BY_PRODSEQ_ROUTTYPE;
		
		string[] ret = new string[2];
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			ret[0] = reader.GetString(0);
			ret[1] = reader.GetString(1);
		}
		return ret;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getCfgFromProd> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getCfgFromProd> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getCfgFromProd> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
decimal getRunStdFromProd(string plt, string prod){
	NotNullDataReader reader = null;
	try{
		string sql = "select PC_RunStd from ProdFmActSub where " + 
			"PC_ProdID = '" + prod + "' and " +
			"PC_Plt = '" + plt + "'" + ORDER_BY_PRODSEQ_ROUTTYPE;
		
		decimal ret = 0;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = reader.GetDecimal(0);
		return ret;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getRunStdFromProd> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getRunStdFromProd> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getRunStdFromProd> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
bool Equals(object obj){
	if (obj is ProdFmActSubDataBase){
        ProdFmActSubDataBase aux = (ProdFmActSubDataBase)obj;
        return	this.PC_ProdID.ToUpper().Equals(aux.getPC_ProdID().ToUpper()) &&
				this.PC_Plt.ToUpper().Equals(aux.getPC_Plt().ToUpper()) &&
                this.PC_Dept.ToUpper().Equals(aux.getPC_Dept().ToUpper()) &&
                this.PC_ActID.ToUpper().Equals(aux.getPC_ActID().ToUpper()) &&
                this.PC_Seq == aux.getPC_Seq() &&
                this.PC_Cfg.ToUpper().Equals(aux.getPC_Cfg().ToUpper());
	}else
		return false;
}

public  
void updateAllLevels(string splant,int ilevel){
  string sql =  "update ProdFmActSub set PC_ProdLev = " + NumberUtil.toString(ilevel);
    if (!string.IsNullOrEmpty(splant))
        sql+= " where PC_Plt = '" + splant + "'";
  update(sql);
}

public  
void updateLevelPartSeq(){  //just to it faster , just update level
    string sql ="update ProdFmActSub set PC_ProdLev = " + NumberUtil.toString(PC_ProdLev) + " " +
                " where PC_Plt = '" + PC_Plt + "' and PC_ProdID = '" + Converter.fixString(PC_ProdID) + "'";
    if (PC_Seq >= 0)        
        sql+=" and PC_Seq = " +NumberUtil.toString(PC_Seq);
  update(sql);
}

} // class

} // namespace