using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class RemittanceHdrDataBaseContainer	: GenericDataBaseContainer{

private string RH_Db;

public 
RemittanceHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittancehdr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.load(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
} 

public 
void readLogNumber(string db){
    NotNullDataReader reader = null;
	try{
		string sql = "select distinct RH_LogNum from remittancehdr " + 
					 "where RH_Db = '" + db + "'" +
					 "order by RH_LogNum";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.loadLogNumber(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readLogNumber>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readLogNumber>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readLogNumber> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readEntryNumber(string db){
    NotNullDataReader reader = null;
	try{
		string sql = "select distinct RH_EntNum from remittancehdr " + 
					 "where RH_Db = '" + db + "'" + 
					 "order by RH_EntNum ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.loadEntryNumber(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readEntryNumber>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readEntryNumber>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readEntryNumber> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readTraceNumber(string db){
    NotNullDataReader reader = null;
	try{
		string sql = "select distinct RH_TraceNum from remittancehdr " + 
					 "where RH_Db = '" + db + "'" + 
					 "order by RH_TraceNum ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.loadTraceNum(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTraceNumber>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTraceNumber>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTraceNumber> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readTraceNumber(string db,string tPartner){
    NotNullDataReader reader = null;
	try{
		string sql = "select distinct RH_TraceNum from remittancehdr " + 
					 "where RH_Db = '" + db + "' and " +
					       "RH_TPartner ='" +tPartner +"' " + 
					 "order by RH_TraceNum ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.loadTraceNum(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTraceNumber>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTraceNumber>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTraceNumber> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readTPartner(string db){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct RH_TPartner from remittancehdr " + 
					 "where RH_Db = '" + db + "' " + 
					 "order by RH_TPartner ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.loadTPartner(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTPartner>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTPartner>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readTPartner> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByTraceLogNum(int maxLogNum,int minLogNum,string traceNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittancehdr " +
					"where " +
						"RH_Db = '" + Converter.fixString(RH_Db) + "' and " +
						"RH_TraceNum ='" +Converter.fixString(traceNum) + "' and " +
						"RH_LogNum between " + minLogNum  +" and " + maxLogNum; 
				
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.load(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTraceLogNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTraceLogNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTraceLogNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByTraceNum(string traceNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from remittancehdr " +
					"where " +
						"RH_Db = '" + Converter.fixString(RH_Db) + "' and " +
						"RH_TraceNum ='" +Converter.fixString(traceNum) + "'"; 
				
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.load(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTraceNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTraceNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTraceLogNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public 
void readCountTraceNum(string db, string traceNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select RH_TraceNum from remittancehdr " +
					"where " +
						"RH_Db = '" + db + "' and " +
						"RH_TraceNum ='" + traceNum +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			RemittanceHdrDataBase remittanceHdrDataBase = new RemittanceHdrDataBase(dataBaseAccess);
			remittanceHdrDataBase.loadTraceNum(reader);
			this.Add(remittanceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readCountTraceNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readCountTraceNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readCountTraceNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from remittancehdr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

//Shipment level deduction report
public 
string[][] getShipmentDeductionReport(string db,string tPartner,string traceNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select  RH_RemitAmt,RH_PayID,RH_PayingName,RH_TraceNum,RH_Currency,RH_TPartner," +
                             "RS_BOLReceived,RS_RemitAmt,RS_Ref1,RS_Ref3,RS_Ref4,RS_CheckNum,RS_AdjAmt," +
                             "RS_InvSent, RS_GrossAmt, RS_PayAmt "+
                     "from remittancehdr,remittanceship " +
					 "where RH_Db = '" + db + "' and " +					 
					       "RH_Db = RS_Db and " +
					       "RH_TPartner = '" +tPartner + "' and " + 
					       "RH_TraceNum = '" +traceNum + "' and " +
					       "RH_LogNum = RS_LogNum and " +
					       "RH_EntNum = RS_EntryNum and " +
					       "(RS_RemitAmt < 0 or RS_AdjAmt <0) " +
					 "order by RH_TPartner,RH_TraceNum,RS_BOLReceived";	

		ArrayList array = new ArrayList();
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string[] line = new string[16];
			line[0]= reader.GetDecimal("RH_RemitAmt").ToString();
			line[1]= reader.GetString("RH_PayID");
			line[2]= reader.GetString("RH_PayingName");
			line[3]= reader.GetString("RH_TraceNum");
			line[4]= reader.GetString("RH_Currency");
			line[5]= reader.GetString("RH_TPartner");
			line[6]= reader.GetString("RS_BOLReceived");
			line[7]= reader.GetDecimal("RS_RemitAmt").ToString();
			line[8]= reader.GetString("RS_Ref1");
			line[9]= reader.GetDecimal("RS_GrossAmt").ToString(); 
			line[10]= reader.GetString("RS_Ref3");
			line[11]= reader.GetString("RS_Ref4");
			line[12]= reader.GetString("RS_CheckNum");
			line[13]= reader.GetDecimal("RS_AdjAmt").ToString();
			line[14]= reader.GetString("RS_InvSent");
            line[15]= reader.GetDecimal("RS_PayAmt").ToString();
 
			array.Add((object)line);	
		}
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		
		return returnArray;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <ShipmentDeductionReport>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <ShipmentDeductionReport>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <ShipmentDeductionReport> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
//Detail level deduction report
public 
string[][] getDetailDeductionReport(string db,string tPartner,string traceNum){
    NotNullDataReader reader = null;
	try{
		string sql = "select  RH_LogNum,RH_EntNum,RH_RemitAmt,RH_PayID,RH_PayingName,RH_TraceNum,RH_Currency,RH_TPartner," +
                             "RD_CustPartID, RD_ProdID, RD_Ref1, RD_Ref2, RD_QtyReceived, RD_UnitPrice," +
                             "RD_RemitAmt,RD_AdjAmt,RD_Uom,RD_Ref3," +
                             "RS_BOLActual,RS_InvActual,RS_CustAcc, " +
                             "RS_BOLReceived,RS_RemitAmt,RS_Ref1,RS_Ref3,RS_Ref4,RS_CheckNum,RS_AdjAmt," +
                             "RS_InvSent, RS_GrossAmt, RS_PayAmt " +
                     "from remittancehdr,remittancedtl,remittanceship " +
					 "where RH_Db = '" + db + "' and " +					 
					       "RH_Db = RD_Db and " +
					       "RH_TPartner = '" +tPartner.Trim() + "' and " + 
					       "RH_TraceNum = '" +traceNum.Trim() + "' and " +
					       "RH_LogNum = RD_LogNum and " +
					       "RH_EntNum = RD_EntryNum and " +
					       "(RD_RemitAmt < 0 or RD_AdjAmt <0) and " +
					       "RS_Db = RD_Db and " +
					       "RS_LogNum = RD_LogNum and " +
					       "RS_EntryNum = RD_EntryNum and " + 
					       "RS_LineNum = RD_LineNum and " +
					       "(RS_RemitAmt < 0 or RS_AdjAmt <0) " +
					 "order by RS_BolReceived,RS_InvSent";	

		ArrayList array = new ArrayList();
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string[] line = new string[31];
			line[0]= reader.GetDecimal("RH_RemitAmt").ToString();
			line[1]= reader.GetString("RH_PayID");
			line[2]= reader.GetString("RH_PayingName");
			line[3]= reader.GetString("RH_TraceNum");
			line[4]= reader.GetString("RH_Currency");
			line[5]= reader.GetString("RH_TPartner");
			line[6]= reader.GetString("RD_CustPartID");
			line[7]= reader.GetString("RD_ProdID");
			line[8]= reader.GetString("RD_Ref1");
			line[9]= reader.GetString("RD_Ref2");
			line[10]= reader.GetDecimal("RD_QtyReceived").ToString();
			line[11]= reader.GetDecimal("RD_UnitPrice").ToString();
			line[12]= reader.GetDecimal("RD_RemitAmt").ToString();
			line[13]= reader.GetDecimal("RD_AdjAmt").ToString();
			line[14]= reader.GetString("RD_Uom");
			line[15]= reader.GetString("RD_Ref3");
			line[16]= reader.GetString("RS_BOLReceived");
			line[17]= reader.GetDecimal("RS_BOLActual").ToString();
			line[18]= reader.GetDecimal("RS_InvActual").ToString();
			line[19]= reader.GetString("RS_InvSent");
			line[20]= reader.GetString("RS_CustAcc");
			line[21]= reader.GetInt32("RH_LogNum").ToString();
			line[22]= reader.GetInt32("RH_EntNum").ToString();
			line[23]= reader.GetDecimal("RS_RemitAmt").ToString();
			line[24]= reader.GetString("RS_Ref1");
			line[25]= reader.GetDecimal("RS_GrossAmt").ToString(); 
			line[26]= reader.GetString("RS_Ref3");
			line[27]= reader.GetString("RS_Ref4");
			line[28]= reader.GetString("RS_CheckNum");
			line[29]= reader.GetDecimal("RS_AdjAmt").ToString();
			line[30]= reader.GetDecimal("RS_PayAmt").ToString();
 
			array.Add((object)line);	
		}
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		
		return returnArray;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDetailDeductionReport>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDetailDeductionReport>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDetailDeductionReport> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
//Setters
public 
void setRH_Db(string RH_Db){
   this.RH_Db = RH_Db;
}


//Getters
public
string getRH_Db(){
   return RH_Db;
}

}//end class

}//end namespace
