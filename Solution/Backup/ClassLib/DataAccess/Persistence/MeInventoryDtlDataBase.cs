using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class MeInventoryDtlDataBase : GenericDataBaseElement{

private int MID_Id;
private string MID_ProdID;
private int MID_Seq;
private decimal MID_LabourUnitCost;
private decimal MID_MaterialUnitCost;
private decimal MID_OutsideUnitCost;
private decimal MID_TotalUnitCost;
private decimal MID_QohCounted;
private string MID_Uom;
private string MID_StockLoc;
private string MID_Plant;
private string MID_PartCategory;
private string MID_MajorGroup;
private string MID_MinorGroup;
private decimal MID_WarehouseChg;
private string MID_Currency;
private decimal MID_FreightChg;
private decimal MID_DutyChg;
private decimal MID_BrokerageChg;
private decimal MID_CurrencyChgRec;
private int MID_Order;
private string MID_PONumber;
private int MID_POItemNum;
private int MID_POItemRelease;
private DateTime MID_DateReceived ;
private int MID_LotNumber;
private string MID_WorkOrder;
private string MID_OrderNumber;
private int MID_OrderItem;
private int MID_ItemRel;
private string MID_PartType;





public MeInventoryDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

    this.MID_Id = reader.GetInt32("MID_Id");
    this.MID_ProdID = reader.GetString("MID_ProdID");
    this.MID_Seq = reader.GetInt32("MID_Seq");
    this.MID_LabourUnitCost = reader.GetDecimal("MID_LabourUnitCost");
    this.MID_MaterialUnitCost = reader.GetDecimal("MID_MaterialUnitCost");
    this.MID_OutsideUnitCost = reader.GetDecimal("MID_OutsideUnitCost");
    this.MID_TotalUnitCost = reader.GetDecimal("MID_TotalUnitCost");
    this.MID_QohCounted = reader.GetDecimal("MID_QohCounted");
    this.MID_Uom = reader.GetString("MID_Uom");
    this.MID_StockLoc = reader.GetString("MID_StockLoc");
    this.MID_Plant = reader.GetString("MID_Plant");
    this.MID_PartCategory = reader.GetString("MID_PartCategory");
    this.MID_MajorGroup = reader.GetString("MID_MajorGroup");
    this.MID_MinorGroup = reader.GetString("MID_MinorGroup");
    this.MID_WarehouseChg = reader.GetDecimal("MID_WarehouseChg");
    this.MID_Currency = reader.GetString("MID_Currency");
    this.MID_FreightChg = reader.GetDecimal("MID_FreightChg");
    this.MID_DutyChg = reader.GetDecimal("MID_DutyChg");
    this.MID_BrokerageChg = reader.GetDecimal("MID_BrokerageChg");
    this.MID_CurrencyChgRec = reader.GetDecimal("MID_CurrencyChgRec");
    this.MID_Order = reader.GetInt32("MID_Order");
    this.MID_PONumber = reader.GetString("MID_PONumber");
    this.MID_POItemNum = reader.GetInt32("MID_POItemNum");
    this.MID_POItemRelease = reader.GetInt32("MID_POItemRelease");
    this.MID_DateReceived  = reader.GetDateTime("MID_DateReceived ");
    this.MID_LotNumber = reader.GetInt32("MID_LotNumber");
    this.MID_WorkOrder = reader.GetString("MID_WorkOrder");
    this.MID_OrderNumber = reader.GetString("MID_OrderNumber");
    this.MID_OrderItem = reader.GetInt32("MID_OrderItem");
    this.MID_ItemRel = reader.GetInt32("MID_ItemRel");
    this.MID_PartType = reader.GetString("MID_PartType");

}

public override
void write(){

	try{
		string sql = "insert into dlyinventorydtl (" + 
		                        "MID_ProdID,MID_Seq,MID_LabourUnitCost,MID_MaterialUnitCost,MID_OutsideUnitCost," +
                                "MID_TotalUnitCost,MID_QohCounted,MID_Uom,MID_StockLoc,MID_Plant,MID_PartCategory," +
                                "MID_MajorGroup,MID_MinorGroup,MID_WarehouseChg,MID_Currency,MID_FreightChg,MID_DutyChg," +
                                "MID_BrokerageChg,MID_CurrencyChgRec,MID_Order,MID_PONumber,MID_POItemNum,MID_POItemRelease," +
                                "MID_DateReceived ,MID_LotNumber,MID_WorkOrder,MID_OrderNumber,MID_OrderItem,MID_ItemRel," +
                                "MID_PartType)" +
                       "values('" + 
                                Converter.fixString(MID_ProdID) +"', " +
                                NumberUtil.toString(MID_Seq) +", " +
                                NumberUtil.toString(MID_LabourUnitCost) +", " +
                                NumberUtil.toString(MID_MaterialUnitCost) +", " +
                                NumberUtil.toString(MID_OutsideUnitCost) +", " +
                                NumberUtil.toString(MID_TotalUnitCost) +", " +
                                NumberUtil.toString(MID_QohCounted) +", '" +
                                Converter.fixString(MID_Uom) +"', '" +
                                Converter.fixString(MID_StockLoc) +"', '" +
                                Converter.fixString(MID_Plant) +"', '" +
                                Converter.fixString(MID_PartCategory) +"', '" +
                                Converter.fixString(MID_MajorGroup) +"', '" +
                                Converter.fixString(MID_MinorGroup) +"', " +
                                NumberUtil.toString(MID_WarehouseChg) +", '" +
                                Converter.fixString(MID_Currency) +"', " +
                                NumberUtil.toString(MID_FreightChg) +", " +
                                NumberUtil.toString(MID_DutyChg) +", " +
                                NumberUtil.toString(MID_BrokerageChg) +", " +
                                NumberUtil.toString(MID_CurrencyChgRec) +", " +
                                NumberUtil.toString(MID_Order) +", '" +
                                Converter.fixString(MID_PONumber) +"', " +
                                NumberUtil.toString(MID_POItemNum) +", " +
                                NumberUtil.toString(MID_POItemRelease) +", '" +
                                DateUtil.getCompleteDateRepresentation(MID_DateReceived ) +"', " +
                                NumberUtil.toString(MID_LotNumber) +", '" +
                                Converter.fixString(MID_WorkOrder) +"', '" +
                                Converter.fixString(MID_OrderNumber) +"', " +
                                NumberUtil.toString(MID_OrderItem) +", " +
                                NumberUtil.toString(MID_ItemRel) +", '" +
                                Converter.fixString(MID_PartType) +"')";
                      
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

//Setters

public void setMID_Id (int MID_Id){
    this.MID_Id = MID_Id;
}

public void setMID_ProdID (string MID_ProdID){
    this.MID_ProdID = MID_ProdID;
}

public void setMID_Seq (int MID_Seq){
    this.MID_Seq = MID_Seq;
}

public void setMID_LabourUnitCost (decimal MID_LabourUnitCost){
    this.MID_LabourUnitCost = MID_LabourUnitCost;
}

public void setMID_MaterialUnitCost (decimal MID_MaterialUnitCost){
    this.MID_MaterialUnitCost = MID_MaterialUnitCost;
}

public void setMID_OutsideUnitCost (decimal MID_OutsideUnitCost){
    this.MID_OutsideUnitCost = MID_OutsideUnitCost;
}

public void setMID_TotalUnitCost (decimal MID_TotalUnitCost){
    this.MID_TotalUnitCost = MID_TotalUnitCost;
}

public void setMID_QohCounted (decimal MID_QohCounted){
    this.MID_QohCounted = MID_QohCounted;
}

public void setMID_Uom (string MID_Uom){
    this.MID_Uom = MID_Uom;
}

public void setMID_StockLoc (string MID_StockLoc){
    this.MID_StockLoc = MID_StockLoc;
}

public void setMID_Plant (string MID_Plant){
    this.MID_Plant = MID_Plant;
}

public void setMID_PartCategory (string MID_PartCategory){
    this.MID_PartCategory = MID_PartCategory;
}

public void setMID_MajorGroup (string MID_MajorGroup){
    this.MID_MajorGroup = MID_MajorGroup;
}

public void setMID_MinorGroup (string MID_MinorGroup){
    this.MID_MinorGroup = MID_MinorGroup;
}

public void setMID_WarehouseChg (decimal MID_WarehouseChg){
    this.MID_WarehouseChg = MID_WarehouseChg;
}

public void setMID_Currency (string MID_Currency){
    this.MID_Currency = MID_Currency;
}

public void setMID_FreightChg (decimal MID_FreightChg){
    this.MID_FreightChg = MID_FreightChg;
}

public void setMID_DutyChg (decimal MID_DutyChg){
    this.MID_DutyChg = MID_DutyChg;
}

public void setMID_BrokerageChg (decimal MID_BrokerageChg){
    this.MID_BrokerageChg = MID_BrokerageChg;
}

public void setMID_CurrencyChgRec (decimal MID_CurrencyChgRec){
    this.MID_CurrencyChgRec = MID_CurrencyChgRec;
}

public void setMID_Order (int MID_Order){
    this.MID_Order = MID_Order;
}

public void setMID_PONumber (string MID_PONumber){
    this.MID_PONumber = MID_PONumber;
}

public void setMID_POItemNum (int MID_POItemNum){
    this.MID_POItemNum = MID_POItemNum;
}

public void setMID_POItemRelease (int MID_POItemRelease){
    this.MID_POItemRelease = MID_POItemRelease;
}

public void setMID_DateReceived  (DateTime MID_DateReceived ){
    this.MID_DateReceived  = MID_DateReceived ;
}

public void setMID_LotNumber (int MID_LotNumber){
    this.MID_LotNumber = MID_LotNumber;
}

public void setMID_WorkOrder (string MID_WorkOrder){
    this.MID_WorkOrder = MID_WorkOrder;
}

public void setMID_OrderNumber (string MID_OrderNumber){
    this.MID_OrderNumber = MID_OrderNumber;
}

public void setMID_OrderItem (int MID_OrderItem){
    this.MID_OrderItem = MID_OrderItem;
}

public void setMID_ItemRel (int MID_ItemRel){
    this.MID_ItemRel = MID_ItemRel;
}

public void setMID_PartType (string MID_PartType){
    this.MID_PartType = MID_PartType;
}


//Getters

public int getMID_Id(){
    return MID_Id;
}

public string getMID_ProdID(){
    return MID_ProdID;
}

public int getMID_Seq(){
    return MID_Seq;
}

public decimal getMID_LabourUnitCost(){
    return MID_LabourUnitCost;
}

public decimal getMID_MaterialUnitCost(){
    return MID_MaterialUnitCost;
}

public decimal getMID_OutsideUnitCost(){
    return MID_OutsideUnitCost;
}

public decimal getMID_TotalUnitCost(){
    return MID_TotalUnitCost;
}

public decimal getMID_QohCounted(){
    return MID_QohCounted;
}

public string getMID_Uom(){
    return MID_Uom;
}

public string getMID_StockLoc(){
    return MID_StockLoc;
}

public string getMID_Plant(){
    return MID_Plant;
}

public string getMID_PartCategory(){
    return MID_PartCategory;
}

public string getMID_MajorGroup(){
    return MID_MajorGroup;
}

public string getMID_MinorGroup(){
    return MID_MinorGroup;
}

public decimal getMID_WarehouseChg(){
    return MID_WarehouseChg;
}

public string getMID_Currency(){
    return MID_Currency;
}

public decimal getMID_FreightChg(){
    return MID_FreightChg;
}

public decimal getMID_DutyChg(){
    return MID_DutyChg;
}

public decimal getMID_BrokerageChg(){
    return MID_BrokerageChg;
}

public decimal getMID_CurrencyChgRec(){
    return MID_CurrencyChgRec;
}

public int getMID_Order(){
    return MID_Order;
}

public string getMID_PONumber(){
    return MID_PONumber;
}

public int getMID_POItemNum(){
    return MID_POItemNum;
}

public int getMID_POItemRelease(){
    return MID_POItemRelease;
}

public DateTime getMID_DateReceived (){
    return MID_DateReceived ;
}

public int getMID_LotNumber(){
    return MID_LotNumber;
}

public string getMID_WorkOrder(){
    return MID_WorkOrder;
}

public string getMID_OrderNumber(){
    return MID_OrderNumber;
}

public int getMID_OrderItem(){
    return MID_OrderItem;
}

public int getMID_ItemRel(){
    return MID_ItemRel;
}

public string getMID_PartType(){
    return MID_PartType;
}



}//end class
}//end namespace
