using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class DlyInventoryDtlDataBase : GenericDataBaseElement{

private int DID_Id;
private string DID_ProdID;
private int DID_Seq;
private decimal DID_LabourUnitCost;
private decimal DID_MaterialUnitCost;
private decimal DID_OutsideUnitCost;
private decimal DID_TotalUnitCost;
private decimal DID_QohCounted;
private string DID_Uom;
private string DID_StockLoc;
private string DID_Plant;
private string DID_PartCategory;
private string DID_MajorGroup;
private string DID_MinorGroup;
private decimal DID_WarehouseChg;
private string DID_Currency;
private decimal DID_FreightChg;
private decimal DID_DutyChg;
private decimal DID_BrokerageChg;
private decimal DID_CurrencyChgRec;
private int DID_Order;
private string DID_PONumber;
private int DID_POItemNum;
private int DID_POItemRelease;
private DateTime DID_DateReceived ;
private int DID_LotNumber;
private string DID_WorkOrder;
private string DID_OrderNumber;
private int DID_OrderItem;
private int DID_ItemRel;
private string DID_PartType;





public DlyInventoryDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

    this.DID_Id = reader.GetInt32("DID_Id");
    this.DID_ProdID = reader.GetString("DID_ProdID");
    this.DID_Seq = reader.GetInt32("DID_Seq");
    this.DID_LabourUnitCost = reader.GetDecimal("DID_LabourUnitCost");
    this.DID_MaterialUnitCost = reader.GetDecimal("DID_MaterialUnitCost");
    this.DID_OutsideUnitCost = reader.GetDecimal("DID_OutsideUnitCost");
    this.DID_TotalUnitCost = reader.GetDecimal("DID_TotalUnitCost");
    this.DID_QohCounted = reader.GetDecimal("DID_QohCounted");
    this.DID_Uom = reader.GetString("DID_Uom");
    this.DID_StockLoc = reader.GetString("DID_StockLoc");
    this.DID_Plant = reader.GetString("DID_Plant");
    this.DID_PartCategory = reader.GetString("DID_PartCategory");
    this.DID_MajorGroup = reader.GetString("DID_MajorGroup");
    this.DID_MinorGroup = reader.GetString("DID_MinorGroup");
    this.DID_WarehouseChg = reader.GetDecimal("DID_WarehouseChg");
    this.DID_Currency = reader.GetString("DID_Currency");
    this.DID_FreightChg = reader.GetDecimal("DID_FreightChg");
    this.DID_DutyChg = reader.GetDecimal("DID_DutyChg");
    this.DID_BrokerageChg = reader.GetDecimal("DID_BrokerageChg");
    this.DID_CurrencyChgRec = reader.GetDecimal("DID_CurrencyChgRec");
    this.DID_Order = reader.GetInt32("DID_Order");
    this.DID_PONumber = reader.GetString("DID_PONumber");
    this.DID_POItemNum = reader.GetInt32("DID_POItemNum");
    this.DID_POItemRelease = reader.GetInt32("DID_POItemRelease");
    this.DID_DateReceived  = reader.GetDateTime("DID_DateReceived ");
    this.DID_LotNumber = reader.GetInt32("DID_LotNumber");
    this.DID_WorkOrder = reader.GetString("DID_WorkOrder");
    this.DID_OrderNumber = reader.GetString("DID_OrderNumber");
    this.DID_OrderItem = reader.GetInt32("DID_OrderItem");
    this.DID_ItemRel = reader.GetInt32("DID_ItemRel");
    this.DID_PartType = reader.GetString("DID_PartType");

}

public override
void write(){

	try{
		string sql = "insert into dlyinventorydtl (" + 
		                        "DID_ProdID,DID_Seq,DID_LabourUnitCost,DID_MaterialUnitCost,DID_OutsideUnitCost," +
                                "DID_TotalUnitCost,DID_QohCounted,DID_Uom,DID_StockLoc,DID_Plant,DID_PartCategory," +
                                "DID_MajorGroup,DID_MinorGroup,DID_WarehouseChg,DID_Currency,DID_FreightChg,DID_DutyChg," +
                                "DID_BrokerageChg,DID_CurrencyChgRec,DID_Order,DID_PONumber,DID_POItemNum,DID_POItemRelease," +
                                "DID_DateReceived ,DID_LotNumber,DID_WorkOrder,DID_OrderNumber,DID_OrderItem,DID_ItemRel," +
                                "DID_PartType)" +
                       "values('" + 
                                Converter.fixString(DID_ProdID) +"', " +
                                NumberUtil.toString(DID_Seq) +", " +
                                NumberUtil.toString(DID_LabourUnitCost) +", " +
                                NumberUtil.toString(DID_MaterialUnitCost) +", " +
                                NumberUtil.toString(DID_OutsideUnitCost) +", " +
                                NumberUtil.toString(DID_TotalUnitCost) +", " +
                                NumberUtil.toString(DID_QohCounted) +", '" +
                                Converter.fixString(DID_Uom) +"', '" +
                                Converter.fixString(DID_StockLoc) +"', '" +
                                Converter.fixString(DID_Plant) +"', '" +
                                Converter.fixString(DID_PartCategory) +"', '" +
                                Converter.fixString(DID_MajorGroup) +"', '" +
                                Converter.fixString(DID_MinorGroup) +"', " +
                                NumberUtil.toString(DID_WarehouseChg) +", '" +
                                Converter.fixString(DID_Currency) +"', " +
                                NumberUtil.toString(DID_FreightChg) +", " +
                                NumberUtil.toString(DID_DutyChg) +", " +
                                NumberUtil.toString(DID_BrokerageChg) +", " +
                                NumberUtil.toString(DID_CurrencyChgRec) +", " +
                                NumberUtil.toString(DID_Order) +", '" +
                                Converter.fixString(DID_PONumber) +"', " +
                                NumberUtil.toString(DID_POItemNum) +", " +
                                NumberUtil.toString(DID_POItemRelease) +", '" +
                                DateUtil.getCompleteDateRepresentation(DID_DateReceived ) +"', " +
                                NumberUtil.toString(DID_LotNumber) +", '" +
                                Converter.fixString(DID_WorkOrder) +"', '" +
                                Converter.fixString(DID_OrderNumber) +"', " +
                                NumberUtil.toString(DID_OrderItem) +", " +
                                NumberUtil.toString(DID_ItemRel) +", '" +
                                Converter.fixString(DID_PartType) +"')";
                      
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

public void setDID_Id (int DID_Id){
    this.DID_Id = DID_Id;
}

public void setDID_ProdID (string DID_ProdID){
    this.DID_ProdID = DID_ProdID;
}

public void setDID_Seq (int DID_Seq){
    this.DID_Seq = DID_Seq;
}

public void setDID_LabourUnitCost (decimal DID_LabourUnitCost){
    this.DID_LabourUnitCost = DID_LabourUnitCost;
}

public void setDID_MaterialUnitCost (decimal DID_MaterialUnitCost){
    this.DID_MaterialUnitCost = DID_MaterialUnitCost;
}

public void setDID_OutsideUnitCost (decimal DID_OutsideUnitCost){
    this.DID_OutsideUnitCost = DID_OutsideUnitCost;
}

public void setDID_TotalUnitCost (decimal DID_TotalUnitCost){
    this.DID_TotalUnitCost = DID_TotalUnitCost;
}

public void setDID_QohCounted (decimal DID_QohCounted){
    this.DID_QohCounted = DID_QohCounted;
}

public void setDID_Uom (string DID_Uom){
    this.DID_Uom = DID_Uom;
}

public void setDID_StockLoc (string DID_StockLoc){
    this.DID_StockLoc = DID_StockLoc;
}

public void setDID_Plant (string DID_Plant){
    this.DID_Plant = DID_Plant;
}

public void setDID_PartCategory (string DID_PartCategory){
    this.DID_PartCategory = DID_PartCategory;
}

public void setDID_MajorGroup (string DID_MajorGroup){
    this.DID_MajorGroup = DID_MajorGroup;
}

public void setDID_MinorGroup (string DID_MinorGroup){
    this.DID_MinorGroup = DID_MinorGroup;
}

public void setDID_WarehouseChg (decimal DID_WarehouseChg){
    this.DID_WarehouseChg = DID_WarehouseChg;
}

public void setDID_Currency (string DID_Currency){
    this.DID_Currency = DID_Currency;
}

public void setDID_FreightChg (decimal DID_FreightChg){
    this.DID_FreightChg = DID_FreightChg;
}

public void setDID_DutyChg (decimal DID_DutyChg){
    this.DID_DutyChg = DID_DutyChg;
}

public void setDID_BrokerageChg (decimal DID_BrokerageChg){
    this.DID_BrokerageChg = DID_BrokerageChg;
}

public void setDID_CurrencyChgRec (decimal DID_CurrencyChgRec){
    this.DID_CurrencyChgRec = DID_CurrencyChgRec;
}

public void setDID_Order (int DID_Order){
    this.DID_Order = DID_Order;
}

public void setDID_PONumber (string DID_PONumber){
    this.DID_PONumber = DID_PONumber;
}

public void setDID_POItemNum (int DID_POItemNum){
    this.DID_POItemNum = DID_POItemNum;
}

public void setDID_POItemRelease (int DID_POItemRelease){
    this.DID_POItemRelease = DID_POItemRelease;
}

public void setDID_DateReceived  (DateTime DID_DateReceived ){
    this.DID_DateReceived  = DID_DateReceived ;
}

public void setDID_LotNumber (int DID_LotNumber){
    this.DID_LotNumber = DID_LotNumber;
}

public void setDID_WorkOrder (string DID_WorkOrder){
    this.DID_WorkOrder = DID_WorkOrder;
}

public void setDID_OrderNumber (string DID_OrderNumber){
    this.DID_OrderNumber = DID_OrderNumber;
}

public void setDID_OrderItem (int DID_OrderItem){
    this.DID_OrderItem = DID_OrderItem;
}

public void setDID_ItemRel (int DID_ItemRel){
    this.DID_ItemRel = DID_ItemRel;
}

public void setDID_PartType (string DID_PartType){
    this.DID_PartType = DID_PartType;
}


//Getters

public int getDID_Id(){
    return DID_Id;
}

public string getDID_ProdID(){
    return DID_ProdID;
}

public int getDID_Seq(){
    return DID_Seq;
}

public decimal getDID_LabourUnitCost(){
    return DID_LabourUnitCost;
}

public decimal getDID_MaterialUnitCost(){
    return DID_MaterialUnitCost;
}

public decimal getDID_OutsideUnitCost(){
    return DID_OutsideUnitCost;
}

public decimal getDID_TotalUnitCost(){
    return DID_TotalUnitCost;
}

public decimal getDID_QohCounted(){
    return DID_QohCounted;
}

public string getDID_Uom(){
    return DID_Uom;
}

public string getDID_StockLoc(){
    return DID_StockLoc;
}

public string getDID_Plant(){
    return DID_Plant;
}

public string getDID_PartCategory(){
    return DID_PartCategory;
}

public string getDID_MajorGroup(){
    return DID_MajorGroup;
}

public string getDID_MinorGroup(){
    return DID_MinorGroup;
}

public decimal getDID_WarehouseChg(){
    return DID_WarehouseChg;
}

public string getDID_Currency(){
    return DID_Currency;
}

public decimal getDID_FreightChg(){
    return DID_FreightChg;
}

public decimal getDID_DutyChg(){
    return DID_DutyChg;
}

public decimal getDID_BrokerageChg(){
    return DID_BrokerageChg;
}

public decimal getDID_CurrencyChgRec(){
    return DID_CurrencyChgRec;
}

public int getDID_Order(){
    return DID_Order;
}

public string getDID_PONumber(){
    return DID_PONumber;
}

public int getDID_POItemNum(){
    return DID_POItemNum;
}

public int getDID_POItemRelease(){
    return DID_POItemRelease;
}

public DateTime getDID_DateReceived (){
    return DID_DateReceived ;
}

public int getDID_LotNumber(){
    return DID_LotNumber;
}

public string getDID_WorkOrder(){
    return DID_WorkOrder;
}

public string getDID_OrderNumber(){
    return DID_OrderNumber;
}

public int getDID_OrderItem(){
    return DID_OrderItem;
}

public int getDID_ItemRel(){
    return DID_ItemRel;
}

public string getDID_PartType(){
    return DID_PartType;
}



}//end class
}//end namespace
