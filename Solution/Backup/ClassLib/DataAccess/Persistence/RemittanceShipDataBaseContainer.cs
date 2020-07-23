using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	

public 
class RemittanceShipDataBaseContainer : GenericDataBaseContainer{

private string RS_Db;
private decimal	RS_LogNum;
private decimal	RS_EntryNum;

public 
RemittanceShipDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittanceship";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceShipDataBase remittanceShipDataBase = new RemittanceShipDataBase(dataBaseAccess);
			remittanceShipDataBase.load(reader);
			this.Add(remittanceShipDataBase);
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
void readByEntryLogNum(int maxEntryNum,int minEntryNum,int maxLogNum,int minLogNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittanceship " +
					"where " +
						"RS_Db = '" + Converter.fixString(RS_Db) + "' and " +
						"RS_LogNum between " + minLogNum  +" and " + maxLogNum + " and " + 
						"RS_EntryNum between " + minEntryNum  +" and " + maxEntryNum;

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceShipDataBase remittanceShipDataBase = new RemittanceShipDataBase(dataBaseAccess);
			remittanceShipDataBase.load(reader);
			this.Add(remittanceShipDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByEntryLogNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByEntryLogNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readDbEntryLogNum(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittanceship " +
					"where " +
						"RS_Db = '" + Converter.fixString(RS_Db) + "' and " +
						"RS_LogNum =" + NumberUtil.toString(RS_LogNum) + " and " + 
						"RS_EntryNum =" + NumberUtil.toString(RS_EntryNum);

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceShipDataBase remittanceShipDataBase = new RemittanceShipDataBase(dataBaseAccess);
			remittanceShipDataBase.load(reader);
			this.Add(remittanceShipDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbEntryLogNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByEntryLogNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbEntryLogNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readDbLogTraceNum(string traceNum,int maxLogNum,int minLogNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select " +
                    "A.RS_Db, " +
                    "A.RS_LogNum, " +
                    "A.RS_EntryNum, " +
                    "A.RS_LineNum, " +
                    "A.RS_BOLReceived, " +
                    "A.RS_BOLActual, " +
                    "A.RS_InvActual, " +
                    "A.RS_InvSent, " +
                    "A.RS_POSent, " +
                    "A.RS_CustAcc, " +
                    "A.RS_CheckRef, " +
                    "A.RS_GrossAmt, " +
                    "A.RS_DiscAmt, " +
                    "A.RS_DiscPer, " +
                    "A.RS_GSTAmt, " +
                    "A.RS_NetAmtPaid, " +
                    "A.RS_RemitAmt, " +
                    "A.RS_PayAmt, " +
                    "A.RS_OtherAmtQu1, " +
                    "A.RS_OtherAmt1, " +
                    "A.RS_OtherAmtQu2, " +
                    "A.RS_OtherAmt2, " +
                    "A.RS_Ref1, " +
                    "A.RS_Ref2, " +
                    "A.RS_Ref3, " +
                    "A.RS_Ref4, " +
                    "A.RS_LiabilityDate, " +
                    "A.RS_IssueDate, " +
                    "A.RS_InvDate, " +
                    "A.RS_CheckNum, " +
                    "A.RS_BillToCust, " +
                    "A.RS_ShipToCust, " +
                    "A.RS_ShipType, " +
                    "A.RS_ProcessYN, " +
                    "A.RS_PstAmt, " +
                    "A.RS_AdjAmt, " +
                    "A.RS_Process, " +
                    "A.RS_Linked, " +
                    "A.RS_SentToERP, " +
                    "A.RS_DateSentToERP, " +
                    "A.RS_ERPDebitNote, " +
                    "A.RS_DebitNote, " +
                    "B.RH_PayID, " +
                    "B.RH_TPartner, " +
                    "B.RH_PayingPH " +
		        " from remittanceship as A, remittancehdr as B " +
					"where " +
						"A.RS_Db = '" + Converter.fixString(RS_Db) + "' and " +
						"A.RS_Db = B.RH_Db and " + 
						"B.RH_TraceNum = '" + traceNum +"' and " +
						"A.RS_LogNum = B.RH_LogNum and " +
						"A.RS_EntryNum = B.RH_EntNum and " + 
                		"B.RH_LogNum between " + minLogNum.ToString()  +" and " + maxLogNum.ToString(); 

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceShipDataBase remittanceShipDataBase = new RemittanceShipDataBase(dataBaseAccess);
			remittanceShipDataBase.loadWithHdr(reader);
			this.Add(remittanceShipDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbLogTraceNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbLogTraceNum>: " + de.Message,de);
    }catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbLogTraceNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readDbTraceNum(string traceNum){
    NotNullDataReader reader =null;
	try{
		string sql = "select " +
                    "A.RS_Db, " +
                    "A.RS_LogNum, " +
                    "A.RS_EntryNum, " +
                    "A.RS_LineNum, " +
                    "A.RS_BOLReceived, " +
                    "A.RS_BOLActual, " +
                    "A.RS_InvActual, " +
                    "A.RS_InvSent, " +
                    "A.RS_POSent, " +
                    "A.RS_CustAcc, " +
                    "A.RS_CheckRef, " +
                    "A.RS_GrossAmt, " +
                    "A.RS_DiscAmt, " +
                    "A.RS_DiscPer, " +
                    "A.RS_GSTAmt, " +
                    "A.RS_NetAmtPaid, " +
                    "A.RS_RemitAmt, " +
                    "A.RS_PayAmt, " +
                    "A.RS_OtherAmtQu1, " +
                    "A.RS_OtherAmt1, " +
                    "A.RS_OtherAmtQu2, " +
                    "A.RS_OtherAmt2, " +
                    "A.RS_Ref1, " +
                    "A.RS_Ref2, " +
                    "A.RS_Ref3, " +
                    "A.RS_Ref4, " +
                    "A.RS_LiabilityDate, " +
                    "A.RS_IssueDate, " +
                    "A.RS_InvDate, " +
                    "A.RS_CheckNum, " +
                    "A.RS_BillToCust, " +
                    "A.RS_ShipToCust, " +
                    "A.RS_ShipType, " +
                    "A.RS_ProcessYN, " +
                    "A.RS_PstAmt, " +
                    "A.RS_AdjAmt, " +
                    "A.RS_Process, " +
                    "A.RS_Linked, " +
                    "A.RS_SentToERP, " +
                    "A.RS_DateSentToERP, " +
                    "A.RS_ERPDebitNote, " +
                    "A.RS_DebitNote, " +
                    "B.RH_PayID, " +
                    "B.RH_TPartner, " +
                    "B.RH_PayingPH " +
		        " from remittanceship as A, remittancehdr as B " +
					"where " +
						"A.RS_Db = '" + Converter.fixString(RS_Db) + "' and " +
						"A.RS_Db = B.RH_Db and " + 
						"B.RH_TraceNum = '" + traceNum +"' and " +
						"A.RS_LogNum = B.RH_LogNum and " +
						"A.RS_EntryNum = B.RH_EntNum"; 

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceShipDataBase remittanceShipDataBase = new RemittanceShipDataBase(dataBaseAccess);
			remittanceShipDataBase.loadWithHdr(reader);
			this.Add(remittanceShipDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbTraceNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbTraceNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDbTraceNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from remittanceship";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

//Getters

public
string getRS_Db(){
   return RS_Db;
}

public
decimal	getRS_LogNum(){
   return RS_LogNum;
}

public
decimal	getRS_EntryNum(){
   return RS_EntryNum;
}



//Setters
public 
void setRS_Db(string RS_Db){
   this.RS_Db = RS_Db;
}

public 
void setRS_LogNum(decimal	RS_LogNum){
   this.RS_LogNum = RS_LogNum;
}

public 
void setRS_EntryNum(decimal	RS_EntryNum){
   this.RS_EntryNum = RS_EntryNum;
}

}//end class

}//end namespace
