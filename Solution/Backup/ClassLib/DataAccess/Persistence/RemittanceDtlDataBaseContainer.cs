using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class RemittanceDtlDataBaseContainer : GenericDataBaseContainer{


//Variables for selecction records.
private string RD_Db;
private decimal RD_LogNum;
private decimal RD_EntryNum;
private decimal RD_LineNum;

private string RD_CustPartID;

public 
RemittanceDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittancedtl";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceDtlDataBase remittanceDtlDataBase = new RemittanceDtlDataBase(dataBaseAccess);
			remittanceDtlDataBase.load(reader);
			this.Add(remittanceDtlDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 	
void readByLogEntryNum(int invoiceNum){
    NotNullDataReader reader = null;
	try	{
		string sql ="select " +
                    "A.ID," +
                    "A.RD_Db," +
                    "A.RD_LogNum," +
                    "A.RD_EntryNum," +
                    "A.RD_LineNum," +
                    "A.RD_DetailNum," +
                    "A.RD_CustPartID," +
                    "A.RD_ProdID," +
                    "A.RD_Kanban," +
                    "A.RD_KitNumber," +
                    "A.RD_KitKanBan," +
                    "A.RD_NetAmt," +
                    "A.RD_Ref1," +
                    "A.RD_Ref2," +
                    "A.RD_Ref3," +
                    "A.RD_LiabilityDate," +
                    "A.RD_KanProc," +
                    "A.RD_GrossAmt," +
                    "A.RD_DiscTaken," +
                    "A.RD_PONum," +
                    "A.RD_ItemNum," +
                    "A.RD_QtyReceived," +
                    "A.RD_Uom," +
                    "A.RD_UnitPrice," +
                    "A.RD_RePriced," +
                    "A.RD_GSTAmt," +
                    "A.RD_PSTAmt," +
                    "A.RD_OtherAmt," +
                    "A.RD_OtherAmtQ1," +
                    "A.RD_OtherAmt1," +
                    "A.RD_OtherAmtQ2," +
                    "A.RD_OtherAmt2," +
                    "A.RD_RemitAmt," +
                    "A.RD_PayAmt," +
                    "A.RD_AdjAmt," +
                    "A.RD_Processed," +
                    "A.RD_Linked," +
                    "A.RD_SentToERP," +
                    "A.RD_DateSendToERP," +
                    "A.RD_ERPDebitNote," +
                    "A.RD_DebitNote," +
                    "B.ID_UnitPrice,"+
                    "B.ID_LineExt," +
                    "B.ID_QtyShipped, " +
                    "B.ID_InvLineNum " +
				 " from remittancedtl as A, invoicedtl as B " + 
					"where A.RD_Db = '" +Converter.fixString(RD_Db) + "' and " +
						  "A.RD_LogNum = " + NumberUtil.toString(RD_LogNum) + " and " +
						  "A.RD_EntryNum = " + NumberUtil.toString(RD_EntryNum)+ " and " +
						  "A.RD_LineNum = " + NumberUtil.toString(RD_LineNum) +" and " +
						  "A.RD_Db = B.ID_Db and " +
						  "A.RD_CustPartID = B.ID_CustPart and " +
						  "B.ID_InvoiceNum = " + invoiceNum.ToString() ; 

		reader = dataBaseAccess.executeQuery(sql);
		
		while(reader.Read()){
			RemittanceDtlDataBase remittanceDtlDataBase = new RemittanceDtlDataBase(dataBaseAccess);
			remittanceDtlDataBase.loadArRemLink(reader);
			this.Add(remittanceDtlDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByLogEntryNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByLogEntryNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByLogEntryNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByDbWithDtl(string invoiceDb,string company, string plant,int invoiceNum){
	NotNullDataReader reader = null;
	try	{
		string sql ="select A.* from remittancedtl as A, invoicedtl as B " + 
					"where A.RD_Db = '" +Converter.fixString(RD_Db) + "' and " +
						  "A.RD_LogNum = " + NumberUtil.toString(RD_LogNum) + " and " +
						  "A.RD_EntryNum = " + NumberUtil.toString(RD_EntryNum)+ " and " +
						  "A.RD_CustPartID =  B.ID_CustPart and " +
						  "B.ID_Db = '" + Converter.fixString(invoiceDb) +"' and "+ 
						  "ID_Company ='" + Converter.fixString(company) + "' and " +
				          "ID_Plant = '" + Converter.fixString(plant) + "' and " +
				          "ID_InvoiceNum = " +invoiceNum.ToString();
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceDtlDataBase remittanceDtlDataBase = new RemittanceDtlDataBase(dataBaseAccess);
			remittanceDtlDataBase.load(reader);
			this.Add(remittanceDtlDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbWithDtl>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbWithDtl>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbWithDtl> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from remittancedtl";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

//Setters
public 
void setRD_Db(string RD_Db){
	this.RD_Db = RD_Db;
}

public 
void setRD_LogNum(decimal RD_LogNum){
	this.RD_LogNum = RD_LogNum;
}

public 
void setRD_EntryNum(decimal RD_EntryNum){
	this.RD_EntryNum = RD_EntryNum;
}

public 
void setRD_LineNum(decimal RD_LineNum){
	this.RD_LineNum = RD_LineNum;
}

public 
void setRD_CustPartID (string RD_CustPartID){
    this.RD_CustPartID = RD_CustPartID;
}


//Getters
public 
string getRD_Db(){
	return RD_Db;
}

public 
decimal getRD_LogNum(){
	return RD_LogNum;
}

public 
decimal getRD_EntryNum(){
	return RD_EntryNum;
}

public 
decimal getRD_LineNum(){
	return RD_LineNum;
}

public 
string getRD_CustPartID(){
    return RD_CustPartID;
}

}//end class

}//end namespace
