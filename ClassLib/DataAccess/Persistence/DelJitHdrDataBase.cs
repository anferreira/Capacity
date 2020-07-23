using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class DelJitHdrDataBase : GenericDataBaseElement{

private int DJH_Id;
private string DJH_Db;
private int DJH_Key;
private string DJH_Tpartner;
private string DJH_TpartnerLoc;
private string DJH_CustPartID;
private string DJH_DeljitReleaseNum;
private string DJH_SchedType;
private string DJH_ReleaseNum;
private DateTime DJH_HorizonStDate;
private DateTime DJH_HorizonStopDate;
private DateTime DJH_SchedDate;
private string DJH_DockCode;
private string DJH_CustPO;
private int DJH_LogNum;
private int DJH_EntryNum;
private int DJH_CustCumReq;
private int DJH_CustCumShip;
private int DJH_CustLastRecQty;
private DateTime DJH_CustLastDate;
private string DJH_CustLastShipID;
private int DJH_CustShipCum;
private int DJH_CustFabCum;
private int DJH_CustMatCum;
private int DJH_CumDisc;
private string DJH_CumInError;
private string DJH_DateType;
private string DJH_QtyType;
private string DJH_Status;


public DelJitHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
this.DJH_Id = reader.GetInt32("DJH_Id");
this.DJH_Db = reader.GetString("DJH_Db");
this.DJH_Key = reader.GetInt32("DJH_Key");
this.DJH_Tpartner = reader.GetString("DJH_Tpartner");
this.DJH_TpartnerLoc = reader.GetString("DJH_TpartnerLoc");
this.DJH_CustPartID = reader.GetString("DJH_CustPartID");
this.DJH_DeljitReleaseNum = reader.GetString("DJH_DeljitReleaseNum");
this.DJH_SchedType = reader.GetString("DJH_SchedType");
this.DJH_ReleaseNum = reader.GetString("DJH_ReleaseNum");
this.DJH_HorizonStDate = reader.GetDateTime("DJH_HorizonStDate");
this.DJH_HorizonStopDate = reader.GetDateTime("DJH_HorizonStopDate");
this.DJH_SchedDate = reader.GetDateTime("DJH_SchedDate");
this.DJH_DockCode = reader.GetString("DJH_DockCode");
this.DJH_CustPO = reader.GetString("DJH_CustPO");
this.DJH_LogNum = reader.GetInt32("DJH_LogNum");
this.DJH_EntryNum = reader.GetInt32("DJH_EntryNum");
this.DJH_CustCumReq = reader.GetInt32("DJH_CustCumReq");
this.DJH_CustCumShip = reader.GetInt32("DJH_CustCumShip");
this.DJH_CustLastRecQty = reader.GetInt32("DJH_CustLastRecQty");
this.DJH_CustLastDate = reader.GetDateTime("DJH_CustLastDate");
this.DJH_CustLastShipID = reader.GetString("DJH_CustLastShipID");
this.DJH_CustShipCum = reader.GetInt32("DJH_CustShipCum");
this.DJH_CustFabCum = reader.GetInt32("DJH_CustFabCum");
this.DJH_CustMatCum = reader.GetInt32("DJH_CustMatCum");
this.DJH_CumDisc = reader.GetInt32("DJH_CumDisc");
this.DJH_CumInError = reader.GetString("DJH_CumInError");
this.DJH_DateType = reader.GetString("DJH_DateType");
this.DJH_QtyType = reader.GetString("DJH_QtyType");
this.DJH_Status = reader.GetString("DJH_Status");

}

public override 
void write(){
	try{
		string sql = "insert into deljithdr (DJH_Db,DJH_Key,DJH_Tpartner,DJH_TpartnerLoc,DJH_CustPartID,"+
		                                    "DJH_DeljitReleaseNum,DJH_SchedType,DJH_ReleaseNum,DJH_HorizonStDate,"+
		                                    "DJH_HorizonStopDate,DJH_SchedDate,DJH_DockCode,DJH_CustPO,DJH_LogNum,"+
		                                    "DJH_EntryNum,DJH_CustCumReq,DJH_CustCumShip,DJH_CustLastRecQty,"+
		                                    "DJH_CustLastDate,DJH_CustLastShipID,DJH_CustShipCum,DJH_CustFabCum,"+
		                                    "DJH_CustMatCum,DJH_CumDisc,DJH_CumInError,DJH_DateType,DJH_QtyType,DJH_Status ) "+
		            "values('" + 
                        Converter.fixString(DJH_Db) +"', " +
                        NumberUtil.toString(DJH_Key) +", '" +
                        Converter.fixString(DJH_Tpartner) +"', '" +
                        Converter.fixString(DJH_TpartnerLoc) +"', '" +
                        Converter.fixString(DJH_CustPartID) +"', '" +
                        Converter.fixString(DJH_DeljitReleaseNum) +"', '" +
                        Converter.fixString(DJH_SchedType) +"', '" +
                        Converter.fixString(DJH_ReleaseNum) +"', '" +
                        DateUtil.getCompleteDateRepresentation(DJH_HorizonStDate) +"', '" +
                        DateUtil.getCompleteDateRepresentation(DJH_HorizonStopDate) +"', '" +
                        DateUtil.getCompleteDateRepresentation(DJH_SchedDate) +"', '" +
                        Converter.fixString(DJH_DockCode) +"', '" +
                        Converter.fixString(DJH_CustPO) +"', " +
                        NumberUtil.toString(DJH_LogNum) +", " +
                        NumberUtil.toString(DJH_EntryNum) +", " +
                        NumberUtil.toString(DJH_CustCumReq) +", " +
                        NumberUtil.toString(DJH_CustCumShip) +", " +
                        NumberUtil.toString(DJH_CustLastRecQty) +", '" +
                        DateUtil.getCompleteDateRepresentation(DJH_CustLastDate) +"', '" +
                        Converter.fixString(DJH_CustLastShipID) +"', " +
                        NumberUtil.toString(DJH_CustShipCum) +", " +
                        NumberUtil.toString(DJH_CustFabCum) +", " +
                        NumberUtil.toString(DJH_CustMatCum) +", " +
                        NumberUtil.toString(DJH_CumDisc) +", '" +
                        Converter.fixString(DJH_CumInError) +"', '" +
                        Converter.fixString(DJH_DateType) +"', '" +
                        Converter.fixString(DJH_QtyType) +"', '" +
                        Converter.fixString(DJH_Status) +"')";
		 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}

}

public override 
void update(){
    throw new PersistenceException("Method not implemented");
}

public override 
void delete(){
    throw new PersistenceException("Method not implemented");

}

public 
void read(){
    throw new PersistenceException("Method not implemented");
}

//Setters
public void setDJH_Id (int DJH_Id){
    this.DJH_Id = DJH_Id;
}

public void setDJH_Db (string DJH_Db){
    this.DJH_Db = DJH_Db;
}

public void setDJH_Key (int DJH_Key){
    this.DJH_Key = DJH_Key;
}

public void setDJH_Tpartner (string DJH_Tpartner){
    this.DJH_Tpartner = DJH_Tpartner;
}

public void setDJH_TpartnerLoc (string DJH_TpartnerLoc){
    this.DJH_TpartnerLoc = DJH_TpartnerLoc;
}

public void setDJH_CustPartID (string DJH_CustPartID){
    this.DJH_CustPartID = DJH_CustPartID;
}

public void setDJH_DeljitReleaseNum (string DJH_DeljitReleaseNum){
    this.DJH_DeljitReleaseNum = DJH_DeljitReleaseNum;
}

public void setDJH_SchedType (string DJH_SchedType){
    this.DJH_SchedType = DJH_SchedType;
}

public void setDJH_ReleaseNum (string DJH_ReleaseNum){
    this.DJH_ReleaseNum = DJH_ReleaseNum;
}

public void setDJH_HorizonStDate (DateTime DJH_HorizonStDate){
    this.DJH_HorizonStDate = DJH_HorizonStDate;
}

public void setDJH_HorizonStopDate (DateTime DJH_HorizonStopDate){
    this.DJH_HorizonStopDate = DJH_HorizonStopDate;
}

public void setDJH_SchedDate (DateTime DJH_SchedDate){
    this.DJH_SchedDate = DJH_SchedDate;
}

public void setDJH_DockCode (string DJH_DockCode){
    this.DJH_DockCode = DJH_DockCode;
}

public void setDJH_CustPO (string DJH_CustPO){
    this.DJH_CustPO = DJH_CustPO;
}

public void setDJH_LogNum (int DJH_LogNum){
    this.DJH_LogNum = DJH_LogNum;
}

public void setDJH_EntryNum (int DJH_EntryNum){
    this.DJH_EntryNum = DJH_EntryNum;
}

public void setDJH_CustCumReq (int DJH_CustCumReq){
    this.DJH_CustCumReq = DJH_CustCumReq;
}

public void setDJH_CustCumShip (int DJH_CustCumShip){
    this.DJH_CustCumShip = DJH_CustCumShip;
}

public void setDJH_CustLastRecQty (int DJH_CustLastRecQty){
    this.DJH_CustLastRecQty = DJH_CustLastRecQty;
}

public void setDJH_CustLastDate (DateTime DJH_CustLastDate){
    this.DJH_CustLastDate = DJH_CustLastDate;
}

public void setDJH_CustLastShipID (string DJH_CustLastShipID){
    this.DJH_CustLastShipID = DJH_CustLastShipID;
}

public void setDJH_CustShipCum (int DJH_CustShipCum){
    this.DJH_CustShipCum = DJH_CustShipCum;
}

public void setDJH_CustFabCum (int DJH_CustFabCum){
    this.DJH_CustFabCum = DJH_CustFabCum;
}

public void setDJH_CustMatCum (int DJH_CustMatCum){
    this.DJH_CustMatCum = DJH_CustMatCum;
}

public void setDJH_CumDisc (int DJH_CumDisc){
    this.DJH_CumDisc = DJH_CumDisc;
}

public void setDJH_CumInError (string DJH_CumInError){
    this.DJH_CumInError = DJH_CumInError;
}

public void setDJH_DateType (string DJH_DateType){
    this.DJH_DateType = DJH_DateType;
}

public void setDJH_QtyType (string DJH_QtyType){
    this.DJH_QtyType = DJH_QtyType;
}

public void setDJH_Status (string DJH_Status){
    this.DJH_Status = DJH_Status;
}

//Getters
public int getDJH_Id(){
    return DJH_Id;
}

public string getDJH_Db(){
    return DJH_Db;
}

public int getDJH_Key(){
    return DJH_Key;
}

public string getDJH_Tpartner(){
    return DJH_Tpartner;
}

public string getDJH_TpartnerLoc(){
    return DJH_TpartnerLoc;
}

public string getDJH_CustPartID(){
    return DJH_CustPartID;
}

public string getDJH_DeljitReleaseNum(){
    return DJH_DeljitReleaseNum;
}

public string getDJH_SchedType(){
    return DJH_SchedType;
}

public string getDJH_ReleaseNum(){
    return DJH_ReleaseNum;
}

public DateTime getDJH_HorizonStDate(){
    return DJH_HorizonStDate;
}

public DateTime getDJH_HorizonStopDate(){
    return DJH_HorizonStopDate;
}

public DateTime getDJH_SchedDate(){
    return DJH_SchedDate;
}

public string getDJH_DockCode(){
    return DJH_DockCode;
}

public string getDJH_CustPO(){
    return DJH_CustPO;
}

public int getDJH_LogNum(){
    return DJH_LogNum;
}

public int getDJH_EntryNum(){
    return DJH_EntryNum;
}

public int getDJH_CustCumReq(){
    return DJH_CustCumReq;
}

public int getDJH_CustCumShip(){
    return DJH_CustCumShip;
}

public int getDJH_CustLastRecQty(){
    return DJH_CustLastRecQty;
}

public DateTime getDJH_CustLastDate(){
    return DJH_CustLastDate;
}

public string getDJH_CustLastShipID(){
    return DJH_CustLastShipID;
}

public int getDJH_CustShipCum(){
    return DJH_CustShipCum;
}

public int getDJH_CustFabCum(){
    return DJH_CustFabCum;
}

public int getDJH_CustMatCum(){
    return DJH_CustMatCum;
}

public int getDJH_CumDisc(){
    return DJH_CumDisc;
}

public string getDJH_CumInError(){
    return DJH_CumInError;
}

public string getDJH_DateType(){
    return DJH_DateType;
}

public string getDJH_QtyType(){
    return DJH_QtyType;
}

public string getDJH_Status(){
    return DJH_Status;
}


}//end class
}//end namespace
