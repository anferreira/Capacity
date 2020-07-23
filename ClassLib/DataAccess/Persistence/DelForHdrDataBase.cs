using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class DelForHdrDataBase : GenericDataBaseElement{

private string DH_Db;
private int DH_ID;
private int DH_Key;
private string DH_Tpartner;
private string DH_TpartnerLoc;
private string DH_CustPartID;
private string DH_DelforReleaseNum;
private string DH_ReleaseNum;
private DateTime DH_HorizonStartDate;
private DateTime DH_HorizonStopDate;
private DateTime DH_IssueDate;
private string DH_SchType;
private string DH_CustPO;
private string DH_Plant;
private string DH_DockCode;
private string DH_LineFeed;
private string DH_DropCode;
private string DH_Source;
private int DH_LogNum;
private int DH_LogLin;
private decimal DH_CumQty;
private decimal DH_CustCumRequired;
private decimal DH_CustCumShipped;
private decimal DH_FabCumQty;
private decimal DH_MatCumQty;
private decimal DH_LastRecQty;
private DateTime DH_LastRecDate;
private string DH_LastRecShipment;
private decimal DH_CumDisc;
private string DH_CumError;
private string DH_DateType;
private string DH_QtyType;
private string DH_ReleaseType;
private string DH_PartStatus;
private string DH_ReleaseStatus;

	
public DelForHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
    this.DH_Db = reader.GetString("DH_Db");
    this.DH_ID = reader.GetInt32("DH_ID");
    this.DH_Key = reader.GetInt32("DH_Key");
    this.DH_Tpartner = reader.GetString("DH_Tpartner");
    this.DH_TpartnerLoc = reader.GetString("DH_TpartnerLoc");
    this.DH_CustPartID = reader.GetString("DH_CustPartID");
    this.DH_DelforReleaseNum = reader.GetString("DH_DelforReleaseNum");
    this.DH_ReleaseNum = reader.GetString("DH_ReleaseNum");
    this.DH_HorizonStartDate = reader.GetDateTime("DH_HorizonStartDate");
    this.DH_HorizonStopDate = reader.GetDateTime("DH_HorizonStopDate");
    this.DH_IssueDate = reader.GetDateTime("DH_IssueDate");
    this.DH_SchType = reader.GetString("DH_SchType");
    this.DH_CustPO = reader.GetString("DH_CustPO");
    this.DH_Plant = reader.GetString("DH_Plant");
    this.DH_DockCode = reader.GetString("DH_DockCode");
    this.DH_LineFeed = reader.GetString("DH_LineFeed");
    this.DH_DropCode = reader.GetString("DH_DropCode");
    this.DH_Source = reader.GetString("DH_Source");
    this.DH_LogNum = reader.GetInt32("DH_LogNum");
    this.DH_LogLin = reader.GetInt32("DH_LogLin");
    this.DH_CumQty = reader.GetDecimal("DH_CumQty");
    this.DH_CustCumRequired = reader.GetDecimal("DH_CustCumRequired");
    this.DH_CustCumShipped = reader.GetDecimal("DH_CustCumShipped");
    this.DH_FabCumQty = reader.GetDecimal("DH_FabCumQty");
    this.DH_MatCumQty = reader.GetDecimal("DH_MatCumQty");
    this.DH_LastRecQty = reader.GetDecimal("DH_LastRecQty");
    this.DH_LastRecDate = reader.GetDateTime("DH_LastRecDate");
    this.DH_LastRecShipment = reader.GetString("DH_LastRecShipment");
    this.DH_CumDisc = reader.GetDecimal("DH_CumDisc");
    this.DH_CumError = reader.GetString("DH_CumError");
    this.DH_DateType = reader.GetString("DH_DateType");
    this.DH_QtyType = reader.GetString("DH_QtyType");
    this.DH_ReleaseType = reader.GetString("DH_ReleaseType");
    this.DH_PartStatus = reader.GetString("DH_PartStatus");
    this.DH_ReleaseStatus = reader.GetString("DH_ReleaseStatus");
}

public
void read(){
  throw new PersistenceException("Method not implemented");
}

public override
void delete(){
  throw new PersistenceException("Method not implemented");
}


public override
void update(){
  throw new PersistenceException("Method not implemented");
}

public override
void write(){
try{
		string sql = "insert into delforhdr (DH_Db,DH_Key, DH_Tpartner, DH_TpartnerLoc, DH_CustPartID, " +
		                                    "DH_DelforReleaseNum, DH_ReleaseNum, DH_HorizonStartDate, "+
		                                    "DH_HorizonStopDate, DH_IssueDate, DH_SchType, DH_CustPO, DH_Plant, "+
		                                    "DH_DockCode, DH_LineFeed, DH_DropCode, DH_Source, DH_LogNum, "+
		                                    "DH_LogLin, DH_CumQty, DH_CustCumRequired, DH_CustCumShipped, "+
		                                    "DH_FabCumQty, DH_MatCumQty, DH_LastRecQty, DH_LastRecDate, "+
		                                    "DH_LastRecShipment, DH_CumDisc, DH_CumError, DH_DateType, DH_QtyType,"+
		                                    "DH_ReleaseType, DH_PartStatus, DH_ReleaseStatus) " +
		            "values('" + 
                            Converter.fixString(DH_Db) +"', " +
                            NumberUtil.toString(DH_Key) +", '" +
                            Converter.fixString(DH_Tpartner) +"', '" +
                            Converter.fixString(DH_TpartnerLoc) +"', '" +
                            Converter.fixString(DH_CustPartID) +"', '" +
                            Converter.fixString(DH_DelforReleaseNum) +"', '" +
                            Converter.fixString(DH_ReleaseNum) +"', '" +
                            DateUtil.getCompleteDateRepresentation(DH_HorizonStartDate) +"', '" +
                            DateUtil.getCompleteDateRepresentation(DH_HorizonStopDate) +"', '" +
                            DateUtil.getCompleteDateRepresentation(DH_IssueDate) +"', '" +
                            Converter.fixString(DH_SchType) +"', '" +
                            Converter.fixString(DH_CustPO) +"', '" +
                            Converter.fixString(DH_Plant) +"', '" +
                            Converter.fixString(DH_DockCode) +"', '" +
                            Converter.fixString(DH_LineFeed) +"', '" +
                            Converter.fixString(DH_DropCode) +"', '" +
                            Converter.fixString(DH_Source) +"', " +
                            NumberUtil.toString(DH_LogNum) +", " +
                            NumberUtil.toString(DH_LogLin) +", " +
                            NumberUtil.toString(DH_CumQty) +", " +
                            NumberUtil.toString(DH_CustCumRequired) +", " +
                            NumberUtil.toString(DH_CustCumShipped) +", " +
                            NumberUtil.toString(DH_FabCumQty) +", " +
                            NumberUtil.toString(DH_MatCumQty) +", " +
                            NumberUtil.toString(DH_LastRecQty) +", '" +
                            DateUtil.getCompleteDateRepresentation(DH_LastRecDate) +"', '" +
                            Converter.fixString(DH_LastRecShipment) +"', " +
                            NumberUtil.toString(DH_CumDisc) +", '" +
                            Converter.fixString(DH_CumError) +"', '" +
                            Converter.fixString(DH_DateType) +"', '" +
                            Converter.fixString(DH_QtyType) +"', '" +
                            Converter.fixString(DH_ReleaseType) +"', '" +
                            Converter.fixString(DH_PartStatus) +"', '" +
                            Converter.fixString(DH_ReleaseStatus)+"')";                    
		 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

//Setters
public void setDH_Db (string DH_Db){
    this.DH_Db = DH_Db;
}

public void setDH_ID (int DH_ID){
    this.DH_ID = DH_ID;
}

public void setDH_Key (int DH_Key){
    this.DH_Key = DH_Key;
}

public void setDH_Tpartner (string DH_Tpartner){
    this.DH_Tpartner = DH_Tpartner;
}

public void setDH_TpartnerLoc (string DH_TpartnerLoc){
    this.DH_TpartnerLoc = DH_TpartnerLoc;
}

public void setDH_CustPartID (string DH_CustPartID){
    this.DH_CustPartID = DH_CustPartID;
}

public void setDH_DelforReleaseNum (string DH_DelforReleaseNum){
    this.DH_DelforReleaseNum = DH_DelforReleaseNum;
}

public void setDH_ReleaseNum (string DH_ReleaseNum){
    this.DH_ReleaseNum = DH_ReleaseNum;
}

public void setDH_HorizonStartDate (DateTime DH_HorizonStartDate){
    this.DH_HorizonStartDate = DH_HorizonStartDate;
}

public void setDH_HorizonStopDate (DateTime DH_HorizonStopDate){
    this.DH_HorizonStopDate = DH_HorizonStopDate;
}

public void setDH_IssueDate (DateTime DH_IssueDate){
    this.DH_IssueDate = DH_IssueDate;
}

public void setDH_SchType (string DH_SchType){
    this.DH_SchType = DH_SchType;
}

public void setDH_CustPO (string DH_CustPO){
    this.DH_CustPO = DH_CustPO;
}

public void setDH_Plant (string DH_Plant){
    this.DH_Plant = DH_Plant;
}

public void setDH_DockCode (string DH_DockCode){
    this.DH_DockCode = DH_DockCode;
}

public void setDH_LineFeed (string DH_LineFeed){
    this.DH_LineFeed = DH_LineFeed;
}

public void setDH_DropCode (string DH_DropCode){
    this.DH_DropCode = DH_DropCode;
}

public void setDH_Source (string DH_Source){
    this.DH_Source = DH_Source;
}

public void setDH_LogNum (int DH_LogNum){
    this.DH_LogNum = DH_LogNum;
}

public void setDH_LogLin (int DH_LogLin){
    this.DH_LogLin = DH_LogLin;
}

public void setDH_CumQty (decimal DH_CumQty){
    this.DH_CumQty = DH_CumQty;
}

public void setDH_CustCumRequired (decimal DH_CustCumRequired){
    this.DH_CustCumRequired = DH_CustCumRequired;
}

public void setDH_CustCumShipped (decimal DH_CustCumShipped){
    this.DH_CustCumShipped = DH_CustCumShipped;
}

public void setDH_FabCumQty (decimal DH_FabCumQty){
    this.DH_FabCumQty = DH_FabCumQty;
}

public void setDH_MatCumQty (decimal DH_MatCumQty){
    this.DH_MatCumQty = DH_MatCumQty;
}

public void setDH_LastRecQty (decimal DH_LastRecQty){
    this.DH_LastRecQty = DH_LastRecQty;
}

public void setDH_LastRecDate (DateTime DH_LastRecDate){
    this.DH_LastRecDate = DH_LastRecDate;
}

public void setDH_LastRecShipment (string DH_LastRecShipment){
    this.DH_LastRecShipment = DH_LastRecShipment;
}

public void setDH_CumDisc (decimal DH_CumDisc){
    this.DH_CumDisc = DH_CumDisc;
}

public void setDH_CumError (string DH_CumError){
    this.DH_CumError = DH_CumError;
}

public void setDH_DateType (string DH_DateType){
    this.DH_DateType = DH_DateType;
}

public void setDH_QtyType (string DH_QtyType){
    this.DH_QtyType = DH_QtyType;
}

public void setDH_ReleaseType (string DH_ReleaseType){
    this.DH_ReleaseType = DH_ReleaseType;
}

public void setDH_PartStatus (string DH_PartStatus){
    this.DH_PartStatus = DH_PartStatus;
}

public void setDH_ReleaseStatus (string DH_ReleaseStatus){
    this.DH_ReleaseStatus = DH_ReleaseStatus;
}


//Getters
public string getDH_Db(){
    return DH_Db;
}

public int getDH_ID(){
    return DH_ID;
}

public int getDH_Key(){
    return DH_Key;
}

public string getDH_Tpartner(){
    return DH_Tpartner;
}

public string getDH_TpartnerLoc(){
    return DH_TpartnerLoc;
}

public string getDH_CustPartID(){
    return DH_CustPartID;
}

public string getDH_DelforReleaseNum(){
    return DH_DelforReleaseNum;
}

public string getDH_ReleaseNum(){
    return DH_ReleaseNum;
}

public DateTime getDH_HorizonStartDate(){
    return DH_HorizonStartDate;
}

public DateTime getDH_HorizonStopDate(){
    return DH_HorizonStopDate;
}

public DateTime getDH_IssueDate(){
    return DH_IssueDate;
}

public string getDH_SchType(){
    return DH_SchType;
}

public string getDH_CustPO(){
    return DH_CustPO;
}

public string getDH_Plant(){
    return DH_Plant;
}

public string getDH_DockCode(){
    return DH_DockCode;
}

public string getDH_LineFeed(){
    return DH_LineFeed;
}

public string getDH_DropCode(){
    return DH_DropCode;
}

public string getDH_Source(){
    return DH_Source;
}

public int getDH_LogNum(){
    return DH_LogNum;
}

public int getDH_LogLin(){
    return DH_LogLin;
}

public decimal getDH_CumQty(){
    return DH_CumQty;
}

public decimal getDH_CustCumRequired(){
    return DH_CustCumRequired;
}

public decimal getDH_CustCumShipped(){
    return DH_CustCumShipped;
}

public decimal getDH_FabCumQty(){
    return DH_FabCumQty;
}

public decimal getDH_MatCumQty(){
    return DH_MatCumQty;
}

public decimal getDH_LastRecQty(){
    return DH_LastRecQty;
}

public DateTime getDH_LastRecDate(){
    return DH_LastRecDate;
}

public string getDH_LastRecShipment(){
    return DH_LastRecShipment;
}

public decimal getDH_CumDisc(){
    return DH_CumDisc;
}

public string getDH_CumError(){
    return DH_CumError;
}

public string getDH_DateType(){
    return DH_DateType;
}

public string getDH_QtyType(){
    return DH_QtyType;
}

public string getDH_ReleaseType(){
    return DH_ReleaseType;
}

public string getDH_PartStatus(){
    return DH_PartStatus;
}

public string getDH_ReleaseStatus(){
    return DH_ReleaseStatus;
}



}//end class
}//end namespace
