using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmInfoDataBase : GenericDataBaseElement{

private int PFS_Id;
private string PFS_ProdID;
private string PFS_Db;
private string PFS_Des1;
private string PFS_Des2;
private string PFS_Des3;
private string PFS_VarFam;
private int PFS_SeqLast;
private string PFS_ActIDLast;
private string PFS_FamProd;
private string PFS_PartType;
private string PFS_InvStatus;
private string PFS_ABCCode;
private string PFS_MajorGroup;
private string PFS_MinorGroup;
private string PFS_GLExp;
private string PFS_GLDistr;
private string PFS_MajorSales;
private string PFS_MinorSales;
private DateTime PFS_LastRevision;
private string PFS_RetailProductType;
private decimal PFS_StdPackSize;
private string PFS_StdPackUnit;
private string PFS_ProdCode;
private string PFS_Finished;
private string PFS_MainMaterial;

private string PFS_Plant;
private decimal PFS_OptimRunPurchSize;
private decimal PFS_ProdMultiplier;
private decimal PFS_MinRunPurchQty;
private int PFS_MatlPrepLdTime;
private decimal PFS_PallPackSize;
private string PFS_PalletPackUnit;
private decimal PFS_MinQty;
private decimal PFS_MaxQty;
private string PFS_VirtKanDemProf;
private decimal PFS_VirtKanManDem;
private decimal PFS_DaysOnHand;
private string PFS_ObectivesAutomaticCalc;
private decimal PFS_DemandLowQtySplit;
private decimal PFS_Level;

public 
ProdFmInfoDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
bool read(){
    string sql = "select * from prodfminfo where PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
    return read(sql);
}

/*
public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfminfo where PFS_ProdID = '" + PFS_ProdID + "'";
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
}*/

public 
bool readForBom(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		string sql = "select * from prodfminfo where PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			load(reader);
			returnValue = true;
		}

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
bool exists(){
	string sql = "select * from prodfminfo where PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
    return exists(sql);		
}

public override
void load(NotNullDataReader reader){
    this.PFS_Id = reader.GetInt32("PFS_Id");
	this.PFS_ProdID = reader.GetString("PFS_ProdID");
	this.PFS_Db = reader.GetString("PFS_Db");
	this.PFS_Des1 = reader.GetString("PFS_Des1");
	this.PFS_Des2 = reader.GetString("PFS_Des2");
	this.PFS_Des3 = reader.GetString("PFS_Des3");
	this.PFS_VarFam = reader.GetString("PFS_VarFam");
	this.PFS_SeqLast = reader.GetInt32("PFS_SeqLast");
	this.PFS_ActIDLast = reader.GetString("PFS_ActIDLast");
	this.PFS_FamProd = reader.GetString("PFS_FamProd");
	this.PFS_PartType = reader.GetString("PFS_PartType");
	this.PFS_InvStatus = reader.GetString("PFS_InvStatus");
	this.PFS_ABCCode = reader.GetString("PFS_ABCCode");
	this.PFS_MajorGroup = reader.GetString("PFS_MajorGroup");
	this.PFS_MinorGroup = reader.GetString("PFS_MinorGroup");
	this.PFS_GLExp = reader.GetString("PFS_GLExp");
	this.PFS_GLDistr = reader.GetString("PFS_GLDistr");
	this.PFS_MajorSales = reader.GetString("PFS_MajorSales");
	this.PFS_MinorSales = reader.GetString("PFS_MinorSales");
	this.PFS_LastRevision = reader.GetDateTime("PFS_LastRevision");
	this.PFS_RetailProductType = reader.GetString("PFS_RetailProductType");
	this.PFS_StdPackSize = reader.GetDecimal("PFS_StdPackSize");
	this.PFS_StdPackUnit = reader.GetString("PFS_StdPackUnit");
	this.PFS_ProdCode = reader.GetString("PFS_ProdCode");

    //AF 2018/10/19
    this.PFS_Finished = reader.GetString("PFS_Finished");
    this.PFS_MainMaterial = reader.GetString("PFS_MainMaterial");            

    //AF 2019/10/25
    this.PFS_Plant = reader.GetString("PFS_Plant");
    this.PFS_OptimRunPurchSize = reader.GetDecimal("PFS_OptimRunPurchSize");
    this.PFS_ProdMultiplier  = reader.GetDecimal("PFS_ProdMultiplier");
    this.PFS_MinRunPurchQty = reader.GetDecimal("PFS_MinRunPurchQty");
    this.PFS_MatlPrepLdTime = reader.GetInt32("PFS_MatlPrepLdTime");        
    this.PFS_PallPackSize = reader.GetDecimal("PFS_PallPackSize");
    this.PFS_PalletPackUnit = reader.GetString("PFS_PalletPackUnit");
    this.PFS_MinQty = reader.GetDecimal("PFS_MinQty");
    this.PFS_MaxQty = reader.GetDecimal("PFS_MaxQty");
    this.PFS_VirtKanDemProf = reader.GetString("PFS_VirtKanDemProf");
    this.PFS_VirtKanManDem= reader.GetDecimal("PFS_VirtKanManDem");
    this.PFS_DaysOnHand = reader.GetDecimal("PFS_DaysOnHand");    
    this.PFS_ObectivesAutomaticCalc =  reader.GetString("PFS_ObectivesAutomaticCalc");
    this.PFS_DemandLowQtySplit = reader.GetDecimal("PFS_DemandLowQtySplit");    
    this.PFS_Level = reader.GetDecimal("PFS_Level");    
}

public override 
void write(){	
    string sql = "insert into prodfminfo (" +
    "PFS_ProdID,PFS_Db,PFS_Des1,PFS_Des2,PFS_Des3,PFS_VarFam,PFS_SeqLast,PFS_ActIDLast,PFS_FamProd,PFS_PartType,PFS_InvStatus,PFS_ABCCode,PFS_MajorGroup,"+
    "PFS_MinorGroup,PFS_GLExp,PFS_GLDistr,PFS_MajorSales,PFS_MinorSales,PFS_LastRevision,PFS_RetailProductType,PFS_StdPackSize,PFS_StdPackUnit,"+
    "PFS_ProdCode,PFS_Finished,PFS_MainMaterial,"+
    "PFS_Plant,PFS_OptimRunPurchSize,PFS_ProdMultiplier,PFS_MinRunPurchQty,PFS_MatlPrepLdTime,PFS_PallPackSize,"+
    "PFS_PalletPackUnit,PFS_MinQty,PFS_MaxQty,PFS_VirtKanDemProf,PFS_VirtKanManDem,PFS_DaysOnHand,"+
    "PFS_ObectivesAutomaticCalc,PFS_DemandLowQtySplit,PFS_Level" +
    ") values('" + 
	    Converter.fixString(PFS_ProdID) + "', '" +
	    Converter.fixString(PFS_Db) +"', '" +
	    Converter.fixString(PFS_Des1) + "', '" +
	    Converter.fixString(PFS_Des2) + "', '" +
	    Converter.fixString(PFS_Des3) + "', '" +
	    Converter.fixString(PFS_VarFam) + "', " +
	    PFS_SeqLast.ToString() + ", '" +
	    Converter.fixString(PFS_ActIDLast) + "', '" +
	    Converter.fixString(PFS_FamProd) + "', '" +
	    Converter.fixString(PFS_PartType) + "', '" +
	    Converter.fixString(PFS_InvStatus) + "', '" +
	    Converter.fixString(PFS_ABCCode) + "', '" +
	    Converter.fixString(PFS_MajorGroup) + "', '" +
	    Converter.fixString(PFS_MinorGroup) + "', '" +
	    Converter.fixString(PFS_GLExp) + "', '" +
	    Converter.fixString(PFS_GLDistr) + "', '" +
	    Converter.fixString(PFS_MajorSales) + "', '" +
	    Converter.fixString(PFS_MinorSales) + "', '" +
	    DateUtil.getDateRepresentation(PFS_LastRevision) + "', '" +
	    Converter.fixString(PFS_RetailProductType) + "', " +
	    NumberUtil.toString(PFS_StdPackSize) + ", '" +
	    Converter.fixString(PFS_StdPackUnit) + "', '" +
	    Converter.fixString(PFS_ProdCode) + "', '" +
        Converter.fixString(PFS_Finished) + "', '" +
        Converter.fixString(PFS_MainMaterial) + "'," +
        //AF 2019-10-25            
        "'" + Converter.fixString(PFS_Plant)        + "',"+
        NumberUtil.toString(PFS_OptimRunPurchSize)  + "," +
        NumberUtil.toString(PFS_ProdMultiplier)     + "," +
        NumberUtil.toString(PFS_MinRunPurchQty)     + "," +
        NumberUtil.toString(PFS_MatlPrepLdTime)     + "," +
        NumberUtil.toString(PFS_PallPackSize)       + "," +
        "'"+Converter.fixString(PFS_PalletPackUnit) + "',"+
        NumberUtil.toString(PFS_MinQty)             + "," +
        NumberUtil.toString(PFS_MaxQty)             + "," +
        "'"+Converter.fixString(PFS_VirtKanDemProf) + "',"+
        NumberUtil.toString(PFS_VirtKanManDem)      + "," +
        NumberUtil.toString(PFS_DaysOnHand)         + "," +
        "'"+Converter.fixString(PFS_ObectivesAutomaticCalc) + "'," +
        NumberUtil.toString(PFS_DemandLowQtySplit) + "," +
        NumberUtil.toString(PFS_Level) + ")";                                    
            //System.Windows.Forms.MessageBox.Show(sql);            
    write(sql);                
    this.PFS_Id = dataBaseAccess.getLastId();
}

public override 
void update(){
    string sql = updateSql(true);
    update(sql);
}

public  
string updateSql(bool bfull){
  string sql = "update prodfminfo set " +
	"PFS_Db = '" + Converter.fixString(PFS_Db) +"', " +
	"PFS_Des1 = '" + Converter.fixString(PFS_Des1) + "', " +
	"PFS_Des2 = '" + Converter.fixString(PFS_Des2) + "', " +
	"PFS_Des3 = '" + Converter.fixString(PFS_Des3) + "', " +
	"PFS_VarFam = '" + Converter.fixString(PFS_VarFam) + "', " +
	"PFS_SeqLast = " + PFS_SeqLast + ", " +
	"PFS_ActIDLast = '" + Converter.fixString(PFS_ActIDLast) + "', " +
	"PFS_FamProd = '" + Converter.fixString(PFS_FamProd) + "', " +
	"PFS_PartType = '" + Converter.fixString(PFS_PartType) + "', " +
	"PFS_InvStatus = '" + Converter.fixString(PFS_InvStatus) + "', " +
	"PFS_ABCCode = '" + Converter.fixString(PFS_ABCCode) + "', " +
	"PFS_MajorGroup = '" + Converter.fixString(PFS_MajorGroup) + "', " +
	"PFS_MinorGroup = '" + Converter.fixString(PFS_MinorGroup) + "', " +
	"PFS_GLExp = '" + Converter.fixString(PFS_GLExp) + "', " +
	"PFS_GLDistr = '" + Converter.fixString(PFS_GLDistr) + "', " +
	"PFS_MajorSales = '" + Converter.fixString(PFS_MajorSales) + "', " +
	"PFS_MinorSales = '" + Converter.fixString(PFS_MinorSales) + "', " +
	"PFS_LastRevision = '" + DateUtil.getDateRepresentation(PFS_LastRevision) + "', " +
	"PFS_RetailProductType = '" + Converter.fixString(PFS_RetailProductType) + "', " +
	"PFS_StdPackSize = " + NumberUtil.toString(PFS_StdPackSize) + ", " +
	"PFS_StdPackUnit = '" + Converter.fixString(PFS_StdPackUnit) + "', " +
	"PFS_ProdCode = '" + Converter.fixString(PFS_ProdCode) + "', " +

    "PFS_Finished = '" + Converter.fixString(PFS_Finished) + "', " +
    "PFS_MainMaterial = '" + Converter.fixString(PFS_MainMaterial) + "', " +

    "PFS_Plant = '"         + Converter.fixString(PFS_Plant) + "'," +
    "PFS_OptimRunPurchSize="+ NumberUtil.toString(PFS_OptimRunPurchSize) + "," +
    "PFS_ProdMultiplier="   + NumberUtil.toString(PFS_ProdMultiplier) + "," +
    "PFS_MinRunPurchQty="   + NumberUtil.toString(PFS_MinRunPurchQty) + "," +
    "PFS_MatlPrepLdTime="   + NumberUtil.toString(PFS_MatlPrepLdTime) + "," +
    "PFS_PallPackSize="     + NumberUtil.toString(PFS_PallPackSize) + "," +
    "PFS_PalletPackUnit = '"+ Converter.fixString(PFS_PalletPackUnit) + "'," +
    "PFS_MinQty="           + NumberUtil.toString(PFS_MinQty) + "," +
    "PFS_MaxQty="           + NumberUtil.toString(PFS_MaxQty) + "," +
    "PFS_VirtKanDemProf = '"+ Converter.fixString(PFS_VirtKanDemProf) + "'," +
    "PFS_VirtKanManDem="+ NumberUtil.toString(PFS_VirtKanManDem) + " ";
    
    if (bfull) {
        sql+=", " + "PFS_DaysOnHand=" + NumberUtil.toString(PFS_DaysOnHand) + "," +
                    "PFS_ObectivesAutomaticCalc = '" + Converter.fixString(PFS_ObectivesAutomaticCalc) + "', " +
                    "PFS_DemandLowQtySplit=" + NumberUtil.toString(PFS_DemandLowQtySplit) + "," +
                    "PFS_Level="     + NumberUtil.toString(PFS_Level) + " ";
    }
    sql+= " where PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
    return sql;
}

public  
void updateShort(){
  string sql = updateSql(false); //do not update fields used on funnel side
  update(sql);
}

public  
void updateLevel(){  //just to it faster , just update level
  string sql = "update prodfminfo set PFS_Level = " + NumberUtil.toString(PFS_Level) + " " + 
               " where PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
  update(sql);
}

public  
void updateAllLevels(int ilevel){
  string sql = "update prodfminfo set PFS_Level = " + NumberUtil.toString(ilevel);
  update(sql);
}

public override 
void delete(){
	string sql = "delete from prodfminfo where " +
			    "PFS_ProdID = '" + Converter.fixString(PFS_ProdID) + "'";
    delete(sql);		
}

public
void setPFS_Id(int PFS_Id){
	this.PFS_Id = PFS_Id;
}

public
void setPFS_ProdID(string PFS_ProdID){
	this.PFS_ProdID = PFS_ProdID;
}

public
void setPFS_Db(string PFS_Db){
	this.PFS_Db = PFS_Db;
}

public
void setPFS_Des1(string PFS_Des1){
	this.PFS_Des1 = PFS_Des1;
}

public
void setPFS_Des2(string PFS_Des2){
	this.PFS_Des2 = PFS_Des2;
}

public
void setPFS_Des3(string PFS_Des3){
	this.PFS_Des3 = PFS_Des3;
}

public
void setPFS_VarFam(string PFS_VarFam){
	this.PFS_VarFam = PFS_VarFam;
}

public
void setPFS_SeqLast(int PFS_SeqLast){
	this.PFS_SeqLast = PFS_SeqLast;
}

public
void setPFS_ActIDLast(string PFS_ActIDLast){
	this.PFS_ActIDLast = PFS_ActIDLast;
}

public
void setPFS_FamProd(string PFS_FamProd){
	this.PFS_FamProd = PFS_FamProd;
}

public
void setPFS_PartType(string PFS_PartType){
	this.PFS_PartType = PFS_PartType;
}

public
void setPFS_InvStatus(string PFS_InvStatus){
	this.PFS_InvStatus = PFS_InvStatus;
}

public
void setPFS_ABCCode(string PFS_ABCCode){
	this.PFS_ABCCode = PFS_ABCCode;
}

public
void setPFS_MajorGroup(string PFS_MajorGroup){
	this.PFS_MajorGroup = PFS_MajorGroup;
}

public
void setPFS_MinorGroup(string PFS_MinorGroup){
	this.PFS_MinorGroup = PFS_MinorGroup;
}

public
void setPFS_GLExp(string PFS_GLExp){
	this.PFS_GLExp = PFS_GLExp;
}

public
void setPFS_GLDistr(string PFS_GLDistr){
	this.PFS_GLDistr = PFS_GLDistr;
}

public
void setPFS_MajorSales(string PFS_MajorSales){
	this.PFS_MajorSales = PFS_MajorSales;
}

public
void setPFS_MinorSales(string PFS_MinorSales){
	this.PFS_MinorSales = PFS_MinorSales;
}

public
void setPFS_LastRevision(DateTime PFS_LastRevision){
	this.PFS_LastRevision = PFS_LastRevision;
}

public
void setPFS_RetailProductType(string PFS_RetailProductType){
	this.PFS_RetailProductType = PFS_RetailProductType;
}

public
void setPFS_StdPackSize(decimal PFS_StdPackSize){
	this.PFS_StdPackSize = PFS_StdPackSize;
}

public
void setPFS_StdPackUnit(string PFS_StdPackUnit){
	this.PFS_StdPackUnit = PFS_StdPackUnit;
}

public
void setPFS_ProdCode(string PFS_ProdCode){
	this.PFS_ProdCode = PFS_ProdCode;
}

public
void setPFS_Finished(string PFS_Finished){
	this.PFS_Finished = PFS_Finished;
}

public
void setPFS_MainMaterial(string PFS_MainMaterial){
	this.PFS_MainMaterial = PFS_MainMaterial;
}
        
public
void setPFS_Plant(string PFS_Plant){
	this.PFS_Plant = PFS_Plant;
}

public
void setPFS_OptimRunPurchSize(decimal PFS_OptimRunPurchSize){
	this.PFS_OptimRunPurchSize = PFS_OptimRunPurchSize;
}

public
void setPFS_ProdMultiplier(decimal PFS_ProdMultiplier){
	this.PFS_ProdMultiplier = PFS_ProdMultiplier;
}

public
void setPFS_MinRunPurchQty(decimal PFS_MinRunPurchQty){
	this.PFS_MinRunPurchQty = PFS_MinRunPurchQty;
}

public
void setPFS_MatlPrepLdTime(int PFS_MatlPrepLdTime){
	this.PFS_MatlPrepLdTime = PFS_MatlPrepLdTime;
}

public
void setPFS_PallPackSize(decimal PFS_PallPackSize){
	this.PFS_PallPackSize = PFS_PallPackSize;
}

public
void setPFS_PalletPackUnit(string PFS_PalletPackUnit){
	this.PFS_PalletPackUnit = PFS_PalletPackUnit;
}

public
void setPFS_MinQty(decimal PFS_MinQty){
	this.PFS_MinQty = PFS_MinQty;
}

public
void setPFS_MaxQty(decimal PFS_MaxQty){
	this.PFS_MaxQty = PFS_MaxQty;
}

public
void setPFS_VirtKanDemProf(string PFS_VirtKanDemProf){
	this.PFS_VirtKanDemProf = PFS_VirtKanDemProf;
}

public
void setPFS_VirtKanManDem(decimal PFS_VirtKanManDem){
	this.PFS_VirtKanManDem = PFS_VirtKanManDem;
}
        
public
void setPFS_DaysOnHand(decimal PFS_DaysOnHand){
	this.PFS_DaysOnHand = PFS_DaysOnHand;
}

public
void setPFS_ObectivesAutomaticCalc(string PFS_ObectivesAutomaticCalc){
	this.PFS_ObectivesAutomaticCalc = PFS_ObectivesAutomaticCalc;
}

public
void setPFS_DemandLowQtySplit(decimal PFS_DemandLowQtySplit){
	this.PFS_DemandLowQtySplit = PFS_DemandLowQtySplit;
}

public
void setPFS_Level(decimal PFS_Level){
	this.PFS_Level = PFS_Level;
}

public
int getPFS_Id(){
	return PFS_Id;
}

public
string getPFS_ProdID(){
	return PFS_ProdID;
}

public
string getPFS_Db(){
	return PFS_Db;
}

public
string getPFS_Des1(){
	return PFS_Des1;
}

public
string getPFS_Des2(){
	return PFS_Des2;
}

public
string getPFS_Des3(){
	return PFS_Des3;
}

public
string getPFS_VarFam(){
	return PFS_VarFam;
}

public
int getPFS_SeqLast(){
	return PFS_SeqLast;
}

public
string getPFS_ActIDLast(){
	return PFS_ActIDLast;
}

public
string getPFS_FamProd(){
	return PFS_FamProd;
}

public
string getPFS_PartType(){
	return PFS_PartType;
}

public
string getPFS_InvStatus(){
	return PFS_InvStatus;
}

public
string getPFS_ABCCode(){
	return PFS_ABCCode;
}

public
string getPFS_MajorGroup(){
	return PFS_MajorGroup;
}

public
string getPFS_MinorGroup(){
	return PFS_MinorGroup;
}

public
string getPFS_GLExp(){
	return PFS_GLExp;
}

public
string getPFS_GLDistr(){
	return PFS_GLDistr;
}

public
string getPFS_MajorSales(){
	return PFS_MajorSales;
}

public
string getPFS_MinorSales(){
	return PFS_MinorSales;
}

public
DateTime getPFS_LastRevision(){
	return PFS_LastRevision;
}

public
string getPFS_RetailProductType(){
	return PFS_RetailProductType;
}

public
decimal getPFS_StdPackSize(){
	return PFS_StdPackSize;
}

public
string getPFS_StdPackUnit(){
	return PFS_StdPackUnit;
}

public
string getPFS_ProdCode(){
	return PFS_ProdCode;
}

public
string getPFS_Finished(){
	return PFS_Finished;
}

public
string getPFS_MainMaterial(){
    return PFS_MainMaterial;
}   


public
string getPFS_Plant(){
	return PFS_Plant;
}

public
decimal getPFS_OptimRunPurchSize(){
	return PFS_OptimRunPurchSize;
}

public
decimal getPFS_ProdMultiplier(){
	return PFS_ProdMultiplier;
}

public
decimal getPFS_MinRunPurchQty(){
	return PFS_MinRunPurchQty;
}

public
int getPFS_MatlPrepLdTime(){
	return PFS_MatlPrepLdTime;
}

public
decimal getPFS_PallPackSize(){
	return PFS_PallPackSize;
}

public
string getPFS_PalletPackUnit(){
	return PFS_PalletPackUnit;
}

public
decimal getPFS_MinQty(){
	return PFS_MinQty;
}

public
decimal getPFS_MaxQty(){
	return PFS_MaxQty;
}

public
string getPFS_VirtKanDemProf(){
	return PFS_VirtKanDemProf;
}

public
decimal getPFS_VirtKanManDem(){
	return PFS_VirtKanManDem;
}

public
decimal getPFS_DaysOnHand(){
    return PFS_DaysOnHand;
}

public
string getPFS_ObectivesAutomaticCalc(){
    return PFS_ObectivesAutomaticCalc;
}

public
decimal getPFS_DemandLowQtySplit(){
	return PFS_DemandLowQtySplit;
}

public
decimal getPFS_Level(){
	return PFS_Level;
}


} // class

} // namespace
