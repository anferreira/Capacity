using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class SchPrOrdMatDataBase : GenericDataBaseElement{

private string SMP_OrdPr;
private string SMP_MatID;
private string SMP_ActID;
private int SMP_Seq;
private int SMP_LineID;
private decimal SMP_QtyToReq;
private string SMP_QTRUom;
private decimal SMP_QtyReq;
private string SMP_Uom;
private decimal SMP_QtyCons;
private string SMP_QtyCUom;
private decimal SMP_QtyPer;
private string SMP_UomPer;
private string SMP_PartType;
private decimal SMP_ScrapPer;
private decimal SMP_SpareQty;
private string SMP_SpareUom;
private string SMP_BackFlush;
private string SMP_ByProduct;
private string SMP_PltLoc;
private string SMP_BinLoc;

public 
SchPrOrdMatDataBase (DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.SMP_OrdPr = reader.GetString("SMP_OrdPr");
	this.SMP_MatID = reader.GetString("SMP_MatID");
	this.SMP_ActID = reader.GetString("SMP_ActID");
	this.SMP_Seq = reader.GetInt32("SMP_Seq");
	this.SMP_LineID = reader.GetInt32("SMP_LineID");
	this.SMP_QtyToReq = reader.GetDecimal("SMP_QtyToReq");
	this.SMP_QTRUom = reader.GetString("SMP_QTRUom");
	this.SMP_QtyReq = reader.GetDecimal("SMP_QtyReq");
	this.SMP_Uom = reader.GetString("SMP_Uom");
	this.SMP_QtyCons = reader.GetDecimal("SMP_QtyCons");
	this.SMP_QtyCUom = reader.GetString("SMP_QtyCUom");
	this.SMP_QtyPer = reader.GetDecimal("SMP_QtyPer");
	this.SMP_UomPer = reader.GetString("SMP_UomPer");
	this.SMP_PartType = reader.GetString("SMP_PartType");
	this.SMP_ScrapPer = reader.GetDecimal("SMP_ScrapPer");
	this.SMP_SpareQty = reader.GetDecimal("SMP_SpareQty");
	this.SMP_SpareUom = reader.GetString("SMP_SpareUom");
	this.SMP_BackFlush = reader.GetString("SMP_BackFlush");
	this.SMP_ByProduct = reader.GetString("SMP_ByProduct");
	this.SMP_PltLoc = reader.GetString("SMP_PltLoc");
	this.SMP_BinLoc = reader.GetString("SMP_BinLoc");
}//end load

public 
void load2(NotNullDataReader reader){
	this.SMP_OrdPr = reader.GetString(0);
	this.SMP_MatID = reader.GetString(1);
	this.SMP_ActID = reader.GetString(2);
	this.SMP_Seq = reader.GetInt32(3);
	this.SMP_LineID = 0;
	this.SMP_QtyToReq = reader.GetDecimal(4);
	this.SMP_QTRUom = reader.GetString(5);
	this.SMP_QtyReq = reader.GetDecimal(6);
	this.SMP_Uom = reader.GetString(7);
	this.SMP_QtyCons = 0;
	this.SMP_QtyCUom = reader.GetString(8);
	this.SMP_QtyPer = reader.GetDecimal(9);
	this.SMP_UomPer = reader.GetString(10);
	this.SMP_PartType = "";
	this.SMP_ScrapPer = reader.GetDecimal(11);
	this.SMP_SpareQty = 0;
	this.SMP_SpareUom = "";
	this.SMP_BackFlush = "";
	this.SMP_ByProduct = "";
	this.SMP_PltLoc = "";
	this.SMP_BinLoc = "";
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprordmat where " +
			"SMP_OrdPr = '" + SMP_OrdPr  + " ' and " +
			"SMP_MatID = '" + SMP_MatID + " ' and " +
			"SMP_ActID = '" + SMP_ActID + " ' and " +
			"SMP_Seq = '" + SMP_Seq + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	} catch (System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	} catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}//end read

public override	
void delete(){
	try{
		string sql ="delete from schprordmat where " +
			"SMP_OrdPr = '" + SMP_OrdPr  + " ' and " +
			"SMP_MatID = '" + SMP_MatID + " ' and " +
			"SMP_ActID = '" + SMP_ActID + " ' and " +
			"SMP_Seq = '" + SMP_Seq + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}//end delete

public override	
void update(){
	try{
		string sql = "update schprordmat set " +
			"SMP_LineID   = " + SMP_LineID   + ", " + 
			"SMP_QtyToReq = " + NumberUtil.toString(SMP_QtyToReq) + ", " + 
			"SMP_QTRUom   = '" + Converter.fixString(SMP_QTRUom)   + "', " + 
			"SMP_QtyReq   = " + NumberUtil.toString(SMP_QtyReq)+ ", " + 
			"SMP_Uom      = '" + Converter.fixString(SMP_Uom)      + "', " +
			"SMP_QtyCons  = " + NumberUtil.toString(SMP_QtyCons)  + ", " + 
			"SMP_QtyCUom  = '" + Converter.fixString(SMP_QtyCUom)  + "', " + 
			"SMP_Qty_Per  = " + NumberUtil.toString(SMP_QtyPer) + ", " +
			"SMP_UomPer   = '" + Converter.fixString(SMP_UomPer)   + "', " + 
			"SMP_PartType = '" + Converter.fixString(SMP_PartType) + "', " + 
			"SMP_ScrapPer = " + NumberUtil.toString(SMP_ScrapPer) + ", " + 
			"SMP_SpareQty = " + NumberUtil.toString(SMP_SpareQty) + ", " + 
			"SMP_SpareUom = '" + Converter.fixString(SMP_SpareUom) + "', " + 
			"SMP_BackFlush = '" + Converter.fixString(SMP_BackFlush) + "', " + 
			"SMP_ByProduct = '" + Converter.fixString(SMP_ByProduct) + "', " + 
			"SMP_PltLoc    = '" + Converter.fixString(SMP_PltLoc)    + "', " + 
			"SMP_BinLoc    = '" + Converter.fixString(SMP_BinLoc) + "' " + 
			"where " +
			"SMP_OrdPr = '" + SMP_OrdPr  + " ' and " +
			"SMP_MatID = '" + SMP_MatID + " ' and " +
			"SMP_ActID = '" + SMP_ActID + " ' and " +
			"SMP_Seq = '" + SMP_Seq + "'"; 
			dataBaseAccess.executeUpdate(sql);
	}catch (System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}//end update

public override	
void write(){
	try{
		string sql = "insert into schprordmat values ('"+
			Converter.fixString(SMP_OrdPr) + "', '" + 
			Converter.fixString(SMP_MatID) + "', '" + 
			Converter.fixString(SMP_ActID) + "', " + 
			SMP_Seq + ", " + 
			SMP_LineID + ", " + 
			NumberUtil.toString(SMP_QtyToReq) + ", '" + 
			Converter.fixString(SMP_QTRUom) + "', " + 
			NumberUtil.toString(SMP_QtyReq)+ ", '" + 
			Converter.fixString(SMP_Uom) + "', " + 
			NumberUtil.toString(SMP_QtyCons) + ", '" + 
			Converter.fixString(SMP_QtyCUom)  + "', " + 
			NumberUtil.toString(SMP_QtyPer) + ", '" +
			Converter.fixString(SMP_UomPer) + "', '" + 
			Converter.fixString(SMP_PartType) + "', " + 
			NumberUtil.toString(SMP_ScrapPer) + ", " + 
			NumberUtil.toString(SMP_SpareQty) + ", '" + 
			Converter.fixString(SMP_SpareUom) + "', '" + 
			Converter.fixString(SMP_BackFlush) + "', '" + 
			Converter.fixString(SMP_ByProduct) + "', '" + 
			Converter.fixString(SMP_PltLoc) + "', '" + 
			Converter.fixString(SMP_BinLoc) + "')"; 

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}//end write

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
}//end exists


public 
void setSMP_OrdPr(string  SMP_OrdPr){
	this.SMP_OrdPr=SMP_OrdPr;
}

public 
string  getSMP_OrdPr(){
	return SMP_OrdPr;
}

public 
void setSMP_MatID(string  SMP_MatID){
	this.SMP_MatID =SMP_MatID;
}
		
public 
string getSMP_MatID(){
	return SMP_MatID;
}

public 
void setSMP_ActID(string  SMP_ActID){
	this.SMP_ActID = SMP_ActID;
}

public 
string getSMP_ActID(){
	return SMP_ActID;
}

public 
void setSMP_Seq(int SMP_Seq){
	this.SMP_Seq =SMP_Seq;
}

public 
int getSMP_Seq(){
	return SMP_Seq;
}

public 
void setSMP_LineID(int SMP_LineID){
	this.SMP_LineID = SMP_LineID;
}
	
public 
int getSMP_LineID(){
	return SMP_LineID;
}

public 
void setSMP_QtyToReq(decimal SMP_QtyToReq){
	this.SMP_QtyToReq = SMP_QtyToReq;
}

public 
decimal getSMP_QtyToReq(){
	return SMP_QtyToReq;
}

public 
void setSMP_QTRUom(string SMP_QTRUom){
	this.SMP_QTRUom=SMP_QTRUom;
}

public 
string  getSMP_QTRUom(){
	return SMP_QTRUom;
}

public 
void setSMP_QtyReq(decimal SMP_QtyReq){
	this.SMP_QtyReq =SMP_QtyReq;
}

public 
decimal getSMP_QtyReq(){
	return SMP_QtyReq;
}

public 
void setSMP_Uom(string SMP_Uom){
	this.SMP_Uom=SMP_Uom;
}

public 
string getSMP_Uom(){
	return SMP_Uom;
}

public 
void setSMP_QtyCons(decimal SMP_QtyCons){
	this.SMP_QtyCons=SMP_QtyCons;
}

public 
decimal getSMP_QtyCons(){
	return SMP_QtyCons;
}

public 
void setSMP_QtyCUom(string SMP_QtyCUom){
	this.SMP_QtyCUom=SMP_QtyCUom;
}

public 
string getSMP_QtyCUom(){
	return SMP_QtyCUom;
}

public 
void setSMP_QtyPer(decimal SMP_QtyPer){
	this.SMP_QtyPer=SMP_QtyPer;
}

public 
decimal getSMP_QtyPer(){
	return SMP_QtyPer;
}

public 
void setSMP_UomPer(string SMP_UomPer){
	this.SMP_UomPer=SMP_UomPer;
}

public 
string  getSMP_UomPer(){
	return SMP_UomPer;
}

public 
void setSMP_PartType(string SMP_PartType){
	this.SMP_PartType=SMP_PartType;
}

public 
string getSMP_PartType(){
	return SMP_PartType;
}

public 
void setSMP_ScrapPer(decimal SMP_ScrapPer){
	this.SMP_ScrapPer=SMP_ScrapPer;
}

public 
decimal getSMP_ScrapPer(){
	return SMP_ScrapPer;
}

public 
void setSMP_SpareQty(decimal SMP_SpareQty){
	this.SMP_SpareQty=SMP_SpareQty;
}

public 
decimal getSMP_SpareQty(){
	return SMP_SpareQty;
}

public 
void setSMP_SpareUom(string SMP_SpareUom){
	this.SMP_SpareUom=SMP_SpareUom;
}

public 
string getSMP_SpareUom(){
	return SMP_SpareUom;
}

public 
void setSMP_BackFlush(string SMP_BackFlush){
	this.SMP_BackFlush=SMP_BackFlush;
}

public 
string getSMP_BackFlush(){
	return SMP_BackFlush;
}

public 
void setSMP_ByProduct(string SMP_ByProduct){
	this.SMP_ByProduct=SMP_ByProduct;
}

public 
string getSMP_ByProduct(){
	return SMP_ByProduct;
}

public 
void setSMP_PltLoc(string SMP_PltLoc){
	this.SMP_PltLoc=SMP_PltLoc;
}

public 
string getSMP_PltLoc(){
	return SMP_PltLoc;
}

public 
void setSMP_BinLoc(string SMP_BinLoc){
	this.SMP_BinLoc=SMP_BinLoc;
}

public 
string getSMP_BinLoc(){
	return SMP_BinLoc;
}

}//end class
}//end namespace
