using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
public 
class RemittanceDtlDataBase : GenericDataBaseElement{

private int ID;
private string RD_Db;
private int RD_LogNum;
private int RD_EntryNum;
private int RD_LineNum;
private int RD_DetailNum;
private string RD_CustPartID;
private string RD_ProdID;
private string RD_Kanban;
private string RD_KitNumber;
private string RD_KitKanBan;
private decimal RD_NetAmt;
private string RD_Ref1;
private string RD_Ref2;
private string RD_Ref3;
private DateTime RD_LiabilityDate;
private string RD_KanProc;
private decimal RD_GrossAmt;
private decimal RD_DiscTaken;
private string RD_PONum;
private int RD_ItemNum;
private decimal RD_QtyReceived;
private string RD_Uom;
private decimal RD_UnitPrice;
private string RD_RePriced;
private decimal RD_GSTAmt;
private decimal RD_PSTAmt;
private decimal RD_OtherAmt;
private string RD_OtherAmtQ1;
private decimal RD_OtherAmt1;
private string RD_OtherAmtQ2;
private decimal RD_OtherAmt2;
private decimal RD_RemitAmt;
private decimal RD_PayAmt;
private decimal RD_AdjAmt;
private string RD_Processed;
private string RD_Linked;
private string RD_SentToERP;
private DateTime RD_DateSendToERP;
private string RD_ERPDebitNote;
private string RD_DebitNote;


//Varialbes used in the ArRemLink Process
private decimal ID_UnitPrice;
private decimal ID_LineExt;
private decimal ID_QtyShipped;
private int ID_InvLineNum;


public 
RemittanceDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.RD_Db = reader.GetString("RD_Db");
	this.RD_LogNum = reader.GetInt32("RD_LogNum");
	this.RD_EntryNum = reader.GetInt32("RD_EntryNum");
	this.RD_LineNum = reader.GetInt32("RD_LineNum");
	this.RD_DetailNum = reader.GetInt32("RD_DetailNum");
	this.RD_CustPartID = reader.GetString("RD_CustPartID");
	this.RD_ProdID = reader.GetString("RD_ProdID");
	this.RD_Kanban = reader.GetString("RD_Kanban");
	this.RD_KitNumber = reader.GetString("RD_KitNumber");
	this.RD_KitKanBan = reader.GetString("RD_KitKanBan");
	this.RD_NetAmt = reader.GetDecimal("RD_NetAmt");
	this.RD_Ref1 = reader.GetString("RD_Ref1");
	this.RD_Ref2 = reader.GetString("RD_Ref2");
	this.RD_Ref3 = reader.GetString("RD_Ref3");
	this.RD_LiabilityDate = reader.GetDateTime("RD_LiabilityDate");
	this.RD_KanProc = reader.GetString("RD_KanProc");
	this.RD_GrossAmt = reader.GetDecimal("RD_GrossAmt");
	this.RD_DiscTaken = reader.GetDecimal("RD_DiscTaken");
	this.RD_PONum = reader.GetString("RD_PONum");
	this.RD_ItemNum = reader.GetInt32("RD_ItemNum");
	this.RD_QtyReceived = reader.GetDecimal("RD_QtyReceived");
	this.RD_Uom = reader.GetString("RD_Uom");
	this.RD_UnitPrice = reader.GetDecimal("RD_UnitPrice");
	this.RD_RePriced = reader.GetString("RD_RePriced");
	this.RD_GSTAmt = reader.GetDecimal("RD_GSTAmt");
	this.RD_PSTAmt = reader.GetDecimal("RD_PSTAmt");
	this.RD_OtherAmt = reader.GetDecimal("RD_OtherAmt");
	this.RD_OtherAmtQ1 = reader.GetString("RD_OtherAmtQ1");
	this.RD_OtherAmt1 = reader.GetDecimal("RD_OtherAmt1");
	this.RD_OtherAmtQ2 = reader.GetString("RD_OtherAmtQ2");
	this.RD_OtherAmt2 = reader.GetDecimal("RD_OtherAmt2");
	this.RD_RemitAmt = reader.GetDecimal("RD_RemitAmt");
	this.RD_PayAmt = reader.GetDecimal("RD_PayAmt");
	this.RD_AdjAmt = reader.GetDecimal("RD_AdjAmt");
	this.RD_Processed = reader.GetString("RD_Processed");
	this.RD_Linked = reader.GetString("RD_Linked");
	this.RD_SentToERP = reader.GetString("RD_SentToERP");
	this.RD_DateSendToERP= reader.GetDateTime("RD_DateSendToERP");
	this.RD_ERPDebitNote = reader.GetString("RD_ERPDebitNote");
	this.RD_DebitNote = reader.GetString("RD_DebitNote");

}

public
void loadArRemLink(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.RD_Db = reader.GetString("RD_Db");
	this.RD_LogNum = reader.GetInt32("RD_LogNum");
	this.RD_EntryNum = reader.GetInt32("RD_EntryNum");
	this.RD_LineNum = reader.GetInt32("RD_LineNum");
	this.RD_DetailNum = reader.GetInt32("RD_DetailNum");
	this.RD_CustPartID = reader.GetString("RD_CustPartID");
	this.RD_ProdID = reader.GetString("RD_ProdID");
	this.RD_Kanban = reader.GetString("RD_Kanban");
	this.RD_KitNumber = reader.GetString("RD_KitNumber");
	this.RD_KitKanBan = reader.GetString("RD_KitKanBan");
	this.RD_NetAmt = reader.GetDecimal("RD_NetAmt");
	this.RD_Ref1 = reader.GetString("RD_Ref1");
	this.RD_Ref2 = reader.GetString("RD_Ref2");
	this.RD_Ref3 = reader.GetString("RD_Ref3");
	this.RD_LiabilityDate = reader.GetDateTime("RD_LiabilityDate");
	this.RD_KanProc = reader.GetString("RD_KanProc");
	this.RD_GrossAmt = reader.GetDecimal("RD_GrossAmt");
	this.RD_DiscTaken = reader.GetDecimal("RD_DiscTaken");
	this.RD_PONum = reader.GetString("RD_PONum");
	this.RD_ItemNum = reader.GetInt32("RD_ItemNum");
	this.RD_QtyReceived = reader.GetDecimal("RD_QtyReceived");
	this.RD_Uom = reader.GetString("RD_Uom");
	this.RD_UnitPrice = reader.GetDecimal("RD_UnitPrice");
	this.RD_RePriced = reader.GetString("RD_RePriced");
	this.RD_GSTAmt = reader.GetDecimal("RD_GSTAmt");
	this.RD_PSTAmt = reader.GetDecimal("RD_PSTAmt");
	this.RD_OtherAmt = reader.GetDecimal("RD_OtherAmt");
	this.RD_OtherAmtQ1 = reader.GetString("RD_OtherAmtQ1");
	this.RD_OtherAmt1 = reader.GetDecimal("RD_OtherAmt1");
	this.RD_OtherAmtQ2 = reader.GetString("RD_OtherAmtQ2");
	this.RD_OtherAmt2 = reader.GetDecimal("RD_OtherAmt2");
	this.RD_RemitAmt = reader.GetDecimal("RD_RemitAmt");
	this.RD_PayAmt = reader.GetDecimal("RD_PayAmt");
	this.RD_AdjAmt = reader.GetDecimal("RD_AdjAmt");
	this.RD_Processed = reader.GetString("RD_Processed");
	this.RD_Linked = reader.GetString("RD_Linked");
	this.RD_SentToERP = reader.GetString("RD_SentToERP");
	this.RD_DateSendToERP= reader.GetDateTime("RD_DateSendToERP");
	this.RD_ERPDebitNote = reader.GetString("RD_ERPDebitNote");
	this.RD_DebitNote = reader.GetString("RD_DebitNote");
    this.ID_UnitPrice = reader.GetDecimal("ID_UnitPrice");
    this.ID_LineExt = reader.GetDecimal("ID_LineExt");
    this.ID_QtyShipped = reader.GetDecimal("ID_QtyShipped");
    this.ID_InvLineNum = reader.GetInt32("ID_InvLineNum");

}
public override
void write(){
	try{
		string sql = "insert into remittancedtl " +
		                "(RD_Db,RD_LogNum,RD_EntryNum,RD_LineNum,RD_DetailNum,RD_CustPartID," +
		                " RD_ProdID,RD_Kanban,RD_KitNumber,RD_KitKanBan,RD_NetAmt,RD_Ref1," +
		                " RD_Ref2,RD_Ref3,RD_LiabilityDate,RD_KanProc,RD_GrossAmt,RD_DiscTaken," +
		                " RD_PONum,RD_ItemNum,RD_QtyReceived,RD_Uom,RD_UnitPrice,RD_RePriced," +
		                " RD_GSTAmt,RD_PSTAmt,RD_OtherAmt,RD_OtherAmtQ1,RD_OtherAmt1,RD_OtherAmtQ2," +
		                " RD_OtherAmt2,RD_RemitAmt,RD_PayAmt,RD_AdjAmt,RD_Processed,RD_Linked," +
		                " RD_SentToERP,RD_DateSendToERP,RD_ERPDebitNote,RD_DebitNote)"+
		            "values('" +
					            Converter.fixString(RD_Db) + "', " +
					            NumberUtil.toString(RD_LogNum) + ", " +
					            NumberUtil.toString(RD_EntryNum) + ", " +
					            NumberUtil.toString(RD_LineNum) + ", " +
					            NumberUtil.toString(RD_DetailNum) + ", '" +
					            Converter.fixString(RD_CustPartID) + "', '" +
					            Converter.fixString(RD_ProdID) + "', '" +
					            Converter.fixString(RD_Kanban) + "', '" +
					            Converter.fixString(RD_KitNumber) + "', '" +
					            Converter.fixString(RD_KitKanBan) + "', " +
					            NumberUtil.toString(RD_NetAmt) + ", '" +
					            Converter.fixString(RD_Ref1) + "', '" +
					            Converter.fixString(RD_Ref2) + "', '" +
					            Converter.fixString(RD_Ref3) + "', '" +
					            DateUtil.getCompleteDateRepresentation(RD_LiabilityDate)+ "', '" +
					            Converter.fixString(RD_KanProc) + "', " +
					            NumberUtil.toString(RD_GrossAmt) + ", " +
					            NumberUtil.toString(RD_DiscTaken) + ", '" +
					            Converter.fixString(RD_PONum) + "', " +
					            NumberUtil.toString(RD_ItemNum) + ", " +
					            NumberUtil.toString(RD_QtyReceived) + ", '" +
					            Converter.fixString(RD_Uom) + "', " +
					            NumberUtil.toString(RD_UnitPrice) + ", '" +
					            Converter.fixString(RD_RePriced) + "', " +
					            NumberUtil.toString(RD_GSTAmt) + ", " +
					            NumberUtil.toString(RD_PSTAmt) + ", " +
					            NumberUtil.toString(RD_OtherAmt) + ", '" +
					            Converter.fixString(RD_OtherAmtQ1) + "', " +
					            NumberUtil.toString(RD_OtherAmt1) + ", '" +
					            Converter.fixString(RD_OtherAmtQ2) + "', " +
					            NumberUtil.toString(RD_OtherAmt2) + ", " +
					            NumberUtil.toString(RD_RemitAmt) + ", " +
					            NumberUtil.toString(RD_PayAmt) + ", '" +
					            NumberUtil.toString(RD_AdjAmt) + "', '" +
					            Converter.fixString(RD_Processed) + "', '" +
					            Converter.fixString(RD_Linked) + "', '" +
					            Converter.fixString(RD_SentToERP) + "', '" +
					            DateUtil.getCompleteDateRepresentation(RD_DateSendToERP) + "', '" +
					            Converter.fixString(RD_ERPDebitNote) + "', '" +
					            Converter.fixString(RD_DebitNote) + "')";

			dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update  remittancedtl  set " +
						"RD_Db = '" + Converter.fixString(RD_Db) + "', " +
						"RD_LogNum = " + NumberUtil.toString(RD_LogNum) + ", " +
						"RD_EntryNum = " + NumberUtil.toString(RD_EntryNum) + ", " +
						"RD_LineNum = " + NumberUtil.toString(RD_LineNum) + ", " +
						"RD_DetailNum = " + NumberUtil.toString(RD_DetailNum) + ", " +
						"RD_CustPartID = '" + Converter.fixString(RD_CustPartID) + "', " +
						"RD_ProdID = '" + Converter.fixString(RD_ProdID) + "', " +
						"RD_Kanban = '" + Converter.fixString(RD_Kanban) + "', " +
						"RD_KitNumber = '" + Converter.fixString(RD_KitNumber) + "', " +
						"RD_KitKanBan = '"+ Converter.fixString(RD_KitKanBan) + "', " +
						"RD_NetAmt = " + NumberUtil.toString(RD_NetAmt) + ", " +
						"RD_Ref1 = '" + Converter.fixString(RD_Ref1) + "', " +
						"RD_Ref2 = '" + Converter.fixString(RD_Ref2) + "', " +
						"RD_Ref3 = '" + Converter.fixString(RD_Ref3) + "', " +
						"RD_LiabilityDate = '" + DateUtil.getCompleteDateRepresentation(RD_LiabilityDate)+ "', " +
						"RD_KanProc = '" + Converter.fixString(RD_KanProc) + "', " +
						"RD_GrossAmt = " + NumberUtil.toString(RD_GrossAmt) + ", " +
						"RD_DiscTaken = " + NumberUtil.toString(RD_DiscTaken) + ", " +
						"RD_PONum = '" + Converter.fixString(RD_PONum) + "', " +
						"RD_ItemNum = " + NumberUtil.toString(RD_ItemNum) + ", " +
						"RD_QtyReceived = " + NumberUtil.toString(RD_QtyReceived) + ", " +
						"RD_Uom = '" + Converter.fixString(RD_Uom) + "', " +
						"RD_UnitPrice = " + NumberUtil.toString(RD_UnitPrice) + ", " +
						"RD_RePriced = '" + Converter.fixString(RD_RePriced) + "', " +
						"RD_GSTAmt = " + NumberUtil.toString(RD_GSTAmt) + ", " +
						"RD_PSTAmt = " + NumberUtil.toString(RD_PSTAmt) + ", " +
						"RD_OtherAmt = " + NumberUtil.toString(RD_OtherAmt) + ", " +
						"RD_OtherAmtQ1 ='" + Converter.fixString(RD_OtherAmtQ1) + "', " +
						"RD_OtherAmt1 = " + NumberUtil.toString(RD_OtherAmt1) + ", " +
						"RD_OtherAmtQ2 = '" + Converter.fixString(RD_OtherAmtQ2) + "', " +
						"RD_OtherAmt2 = " + NumberUtil.toString(RD_OtherAmt2) + ", " +
						"RD_RemitAmt = " + NumberUtil.toString(RD_RemitAmt) + ", " +
						"RD_PayAmt = " +  NumberUtil.toString(RD_PayAmt) + ", " +
						"RD_AdjAmt = '" + NumberUtil.toString(RD_AdjAmt) + "', " + 
						"RD_Processed = '" + Converter.fixString(RD_Processed) + "', " + 
						"RD_Linked = '" + Converter.fixString(RD_Linked) + "', " + 
						"RD_SentToERP = '" + Converter.fixString(RD_SentToERP) + "', " + 
						"RD_DateSendToERP = '" + DateUtil.getCompleteDateRepresentation(RD_DateSendToERP) + "', " + 
						"RD_ERPDebitNote = '" + Converter.fixString(RD_ERPDebitNote) +"', " +
						"RD_DebitNote ='" + Converter.fixString(RD_DebitNote)+ "' " +
					"where ID = " + NumberUtil.toString(ID) ;

		dataBaseAccess.executeQuery(sql);
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
		string sql = "delete from remittancedtl " +
					"where ID = " + NumberUtil.toString(ID) ;
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : "+ de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittancedtl " +
					"where ID = " + NumberUtil.toString(ID) ;

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

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from remittancedtl " + 
			"where " +
			"RD_Db = '" + Converter.fixString(RD_Db) +"' and " +
			"RD_LogNum = " + NumberUtil.toString(RD_LogNum) +" and " +
			"RD_EntryNum = " + NumberUtil.toString(RD_EntryNum)+ " and " +
			"RD_LineNum = " + NumberUtil.toString(RD_LineNum) + " and " +
			"RD_DetailNum = " + NumberUtil.toString(RD_DetailNum);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public 
void setRD_Db(string RD_Db){
   this.RD_Db = RD_Db;
}

public 
void setRD_LogNum(int RD_LogNum){
   this.RD_LogNum = RD_LogNum;
}

public 
void setRD_EntryNum(int RD_EntryNum){
   this.RD_EntryNum = RD_EntryNum;
}

public 
void setRD_LineNum(int RD_LineNum){
   this.RD_LineNum = RD_LineNum;
}

public 
void setRD_DetailNum(int RD_DetailNum){
   this.RD_DetailNum = RD_DetailNum;
}

public 
void setRD_CustPartID(string RD_CustPartID){
   this.RD_CustPartID = RD_CustPartID;
}

public 
void setRD_ProdID(string RD_ProdID){
   this.RD_ProdID = RD_ProdID;
}

public 
void setRD_Kanban(string RD_Kanban){
   this.RD_Kanban = RD_Kanban;
}

public 
void setRD_KitNumber(string RD_KitNumber){
   this.RD_KitNumber = RD_KitNumber;
}

public 
void setRD_KitKanBan(string RD_KitKanBan){
   this.RD_KitKanBan = RD_KitKanBan;
}

public 
void setRD_NetAmt(decimal RD_NetAmt){
   this.RD_NetAmt = RD_NetAmt;
}

public 
void setRD_Ref1(string RD_Ref1){
   this.RD_Ref1 = RD_Ref1;
}

public 
void setRD_Ref2(string RD_Ref2){
   this.RD_Ref2 = RD_Ref2;
}

public 
void setRD_Ref3(string RD_Ref3){
   this.RD_Ref3 = RD_Ref3;
}

public 
void setRD_LiabilityDate(DateTime RD_LiabilityDate){
   this.RD_LiabilityDate = RD_LiabilityDate;
}

public 
void setRD_KanProc(string RD_KanProc){
   this.RD_KanProc = RD_KanProc;
}

public 
void setRD_GrossAmt(decimal RD_GrossAmt){
   this.RD_GrossAmt = RD_GrossAmt;
}

public 
void setRD_DiscTaken(decimal RD_DiscTaken){
   this.RD_DiscTaken = RD_DiscTaken;
}

public 
void setRD_PONum(string RD_PONum){
   this.RD_PONum = RD_PONum;
}

public 
void setRD_ItemNum(int RD_ItemNum){
   this.RD_ItemNum = RD_ItemNum;
}

public 
void setRD_QtyReceived(decimal RD_QtyReceived){
   this.RD_QtyReceived = RD_QtyReceived;
}

public 
void setRD_Uom(string RD_Uom){
   this.RD_Uom = RD_Uom;
}

public 
void setRD_UnitPrice(decimal RD_UnitPrice){
   this.RD_UnitPrice = RD_UnitPrice;
}

public 
void setRD_RePriced(string RD_RePriced){
   this.RD_RePriced = RD_RePriced;
}

public 
void setRD_GSTAmt(decimal RD_GSTAmt){
   this.RD_GSTAmt = RD_GSTAmt;
}

public 
void setRD_PSTAmt(decimal RD_PSTAmt){
   this.RD_PSTAmt = RD_PSTAmt;
}

public 
void setRD_OtherAmt(decimal RD_OtherAmt){
   this.RD_OtherAmt = RD_OtherAmt;
}

public 
void setRD_OtherAmtQ1(string RD_OtherAmtQ1){
   this.RD_OtherAmtQ1 = RD_OtherAmtQ1;
}

public 
void setRD_OtherAmt1(decimal RD_OtherAmt1){
   this.RD_OtherAmt1 = RD_OtherAmt1;
}

public 
void setRD_OtherAmtQ2(string RD_OtherAmtQ2){
   this.RD_OtherAmtQ2 = RD_OtherAmtQ2;
}

public 
void setRD_OtherAmt2(decimal RD_OtherAmt2){
   this.RD_OtherAmt2 = RD_OtherAmt2;
}

public 
void setRD_RemitAmt(decimal RD_RemitAmt){
   this.RD_RemitAmt = RD_RemitAmt;
}

public 
void setRD_PayAmt(decimal RD_PayAmt){
   this.RD_PayAmt = RD_PayAmt;
}

public 
void setRD_AdjAmt(decimal RD_AdjAmt){
   this.RD_AdjAmt = RD_AdjAmt;
}

public 
void setRD_Processed(string RD_Processed){
   this.RD_Processed = RD_Processed;
}

public 
void setRD_Linked(string RD_Linked){
   this.RD_Linked = RD_Linked;
}

public 
void setRD_SentToERP(string RD_SentToERP){
   this.RD_SentToERP = RD_SentToERP;
}

public 
void setRD_DateSendToERP(DateTime RD_DateSendToERP){
   this.RD_DateSendToERP = RD_DateSendToERP;
}

public 
void setRD_ERPDebitNote(string RD_ERPDebitNote){
   this.RD_ERPDebitNote = RD_ERPDebitNote;
}

public 
void setRD_DebitNote(string RD_DebitNote){
   this.RD_DebitNote = RD_DebitNote;
}

public 
void setID_UnitPrice (decimal ID_UnitPrice){
    this.ID_UnitPrice = ID_UnitPrice;
}

public 
void setID_LineExt (decimal ID_LineExt){
    this.ID_LineExt = ID_LineExt;
}

public 
void setQtyShipped (decimal ID_QtyShipped){
    this.ID_QtyShipped = ID_QtyShipped;
}

public
void setID_InvLineNum(int ID_InvLineNum){
	this.ID_InvLineNum = ID_InvLineNum;
}

//Getters

public
string getRD_Db(){
   return RD_Db;
}

public
int getRD_LogNum(){
   return RD_LogNum;
}

public
int getRD_EntryNum(){
   return RD_EntryNum;
}

public
int getRD_LineNum(){
   return RD_LineNum;
}

public
int getRD_DetailNum(){
   return RD_DetailNum;
}

public
string getRD_CustPartID(){
   return RD_CustPartID;
}

public
string getRD_ProdID(){
   return RD_ProdID;
}

public
string getRD_Kanban(){
   return RD_Kanban;
}

public
string getRD_KitNumber(){
   return RD_KitNumber;
}

public
string getRD_KitKanBan(){
   return RD_KitKanBan;
}

public
decimal getRD_NetAmt(){
   return RD_NetAmt;
}

public
string getRD_Ref1(){
   return RD_Ref1;
}

public
string getRD_Ref2(){
   return RD_Ref2;
}

public
string getRD_Ref3(){
   return RD_Ref3;
}

public
DateTime getRD_LiabilityDate(){
   return RD_LiabilityDate;
}

public
string getRD_KanProc(){
   return RD_KanProc;
}

public
decimal getRD_GrossAmt(){
   return RD_GrossAmt;
}

public
decimal getRD_DiscTaken(){
   return RD_DiscTaken;
}

public
string getRD_PONum(){
   return RD_PONum;
}

public
int getRD_ItemNum(){
   return RD_ItemNum;
}

public
decimal getRD_QtyReceived(){
   return RD_QtyReceived;
}

public
string getRD_Uom(){
   return RD_Uom;
}

public
decimal getRD_UnitPrice(){
   return RD_UnitPrice;
}

public
string getRD_RePriced(){
   return RD_RePriced;
}

public
decimal getRD_GSTAmt(){
   return RD_GSTAmt;
}

public
decimal getRD_PSTAmt(){
   return RD_PSTAmt;
}

public
decimal getRD_OtherAmt(){
   return RD_OtherAmt;
}

public
string getRD_OtherAmtQ1(){
   return RD_OtherAmtQ1;
}

public
decimal getRD_OtherAmt1(){
   return RD_OtherAmt1;
}

public
string getRD_OtherAmtQ2(){
   return RD_OtherAmtQ2;
}

public
decimal getRD_OtherAmt2(){
   return RD_OtherAmt2;
}

public
decimal getRD_RemitAmt(){
   return RD_RemitAmt;
}

public
decimal getRD_PayAmt(){
   return RD_PayAmt;
}

public
decimal getRD_AdjAmt(){
   return RD_AdjAmt;
}

public
string getRD_Processed(){
   return RD_Processed;
}

public
string getRD_Linked(){
   return RD_Linked;
}

public
string getRD_SentToERP(){
   return RD_SentToERP;
}

public
DateTime getRD_DateSendToERP(){
   return RD_DateSendToERP;
}

public
string getRD_ERPDebitNote(){
   return RD_ERPDebitNote;
}

public
string getRD_DebitNote(){
   return RD_DebitNote;
}


//Auxiliary 
public decimal getID_UnitPrice(){
    return ID_UnitPrice;
}

public decimal getID_LineExt(){
    return ID_LineExt;
}

public decimal getID_QtyShipped(){
    return ID_QtyShipped;
}

public
int getID_InvLineNum(){
	return ID_InvLineNum;
}

}//end class

}//end namespace
