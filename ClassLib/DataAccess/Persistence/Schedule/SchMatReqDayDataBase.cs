using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMatReqDayDataBase : GenericDataBaseElement{
	
private string SMD_SchVersion;
private string SMD_Plt;
private string SMD_Dept;
private string SMD_ProdID;
private int SMD_ProdSeq;
private string SMD_MatID;
private int SMD_MatSeq;
private DateTime SMD_MatReqDate;
private string SMD_MatUom;
private string SMD_Usage;
private decimal SMD_InvQty;
private decimal SMD_POQty;
private decimal SMD_DemMatReq;
private decimal SMD_SchMatReq;
private decimal SMD_Factor;

public
SchMatReqDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMD_SchVersion = reader.GetString("SMD_SchVersion");
	this.SMD_Plt = reader.GetString("SMD_Plt");
	this.SMD_Dept = reader.GetString("SMD_Dept");
	this.SMD_ProdID = reader.GetString("SMD_ProdID");
	this.SMD_ProdSeq = reader.GetInt32("SMD_ProdSeq");
	this.SMD_MatID = reader.GetString("SMD_MatID");
	this.SMD_MatSeq = reader.GetInt32("SMD_MatSeq");
	this.SMD_MatReqDate = reader.GetDateTime("SMD_MatReqDate");
	this.SMD_MatUom = reader.GetString("SMD_MatUom");
	this.SMD_Usage = reader.GetString("SMD_Usage");
	this.SMD_InvQty = reader.GetDecimal("SMD_InvQty");
	this.SMD_POQty = reader.GetDecimal("SMD_POQty");
	this.SMD_DemMatReq = reader.GetDecimal("SMD_DemMatReq");
	this.SMD_SchMatReq = reader.GetDecimal("SMD_SchMatReq");
	this.SMD_Factor =  reader.GetDecimal("SMD_Factor");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqday where " + 
			"SMD_SchVersion = '" + SMD_SchVersion + "' and " +
			"SMD_Plt = '" + SMD_Plt + "' and " +
			"SMD_Dept = '" + SMD_Dept + "' and " +
			"SMD_ProdID = '" + SMD_ProdID + "' and " +
			"SMD_ProdSeq = " + SMD_ProdSeq.ToString() + " and " +
			"SMD_MatID = '" + SMD_MatID + "' and " +
			"SMD_MatSeq = " + SMD_MatSeq.ToString() + " and " +
			"SMD_MatReqDate = '" + DateUtil.getDateRepresentation(SMD_MatReqDate) + "'";

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

public override
void write(){
	try{
		string sql = "insert into schmatreqday values('" + 
			SMD_SchVersion + "', '" +
			SMD_Plt + "', '" +
			SMD_Dept + "', '" +
			SMD_ProdID + "', " +
			SMD_ProdSeq.ToString() + ", '" +
			SMD_MatID + "', " +
			SMD_MatSeq.ToString() + ", '" +
			DateUtil.getDateRepresentation(SMD_MatReqDate) + "', '" +
			SMD_MatUom + "', '" +
			SMD_Usage + "', " +
			NumberUtil.toString(SMD_InvQty) + ", " +
			NumberUtil.toString(SMD_POQty) + ", " +
			NumberUtil.toString(SMD_DemMatReq) + ", " +
			NumberUtil.toString(SMD_SchMatReq) + ", " +
			NumberUtil.toString(SMD_Factor) + ")";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from schmatreqday where " +
			"SMD_SchVersion = '" + SMD_SchVersion + "' and " +
			"SMD_Plt = '" + SMD_Plt + "' and " +
			"SMD_Dept = '" + SMD_Dept + "' and " +
			"SMD_ProdID = '" + SMD_ProdID + "' and " +
			"SMD_ProdSeq = " + SMD_ProdSeq.ToString() + " and " +
			"SMD_MatID = '" + SMD_MatID + "' and " +
			"SMD_MatSeq = " + SMD_MatSeq.ToString() + " and " +
			"SMD_MatReqDate = '" + DateUtil.getDateRepresentation(SMD_MatReqDate) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update schmatreqday set " +
			"SMD_MatUom = '" + SMD_MatUom + "', " +
			"SMD_Usage = '" + SMD_Usage + "', " +
			"SMD_InvQty = " + NumberUtil.toString(SMD_InvQty) + ", " +
			"SMD_POQty = " + NumberUtil.toString(SMD_POQty) + ", " +
			"SMD_DemMatReq = " + NumberUtil.toString(SMD_DemMatReq) + ", " +
			"SMD_SchMatReq = " + NumberUtil.toString(SMD_SchMatReq) + ", " +
			"SMD_Factor = " + NumberUtil.toString(SMD_Factor) + 
		" where " + 
			"SMD_SchVersion = '" + SMD_SchVersion + "' and " +
			"SMD_Plt = '" + SMD_Plt + "' and " +
			"SMD_Dept = '" + SMD_Dept + "' and " +
			"SMD_ProdID = '" + SMD_ProdID + "' and " +
			"SMD_ProdSeq = " + SMD_ProdSeq.ToString() + " and " +
			"SMD_MatID = '" + SMD_MatID + "' and " +
			"SMD_MatSeq = " + SMD_MatSeq.ToString() + " and " +
			"SMD_MatReqDate = '" + DateUtil.getDateRepresentation(SMD_MatReqDate) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqday where " + 
			"SMD_SchVersion = '" + SMD_SchVersion + "' and " +
			"SMD_Plt = '" + SMD_Plt + "' and " +
			"SMD_Dept = '" + SMD_Dept + "' and " +
			"SMD_ProdID = '" + SMD_ProdID + "' and " +
			"SMD_ProdSeq = " + SMD_ProdSeq.ToString() + " and " +
			"SMD_MatID = '" + SMD_MatID + "' and " +
			"SMD_MatSeq = " + SMD_MatSeq.ToString() + " and " +
			"SMD_MatReqDate = '" + DateUtil.getDateRepresentation(SMD_MatReqDate) + "'";

		bool returnValue = false;

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;
		
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setSMD_SchVersion(string SMD_SchVersion){
	this.SMD_SchVersion = SMD_SchVersion;
}

public
void setSMD_Plt(string SMD_Plt){
	this.SMD_Plt = SMD_Plt;
}

public
void setSMD_Dept(string SMD_Dept){
	this.SMD_Dept = SMD_Dept;
}

public
void setSMD_ProdID(string SMD_ProdID){
	this.SMD_ProdID = SMD_ProdID;
}

public
void setSMD_ProdSeq(int SMD_ProdSeq){
	this.SMD_ProdSeq = SMD_ProdSeq;
}

public
void setSMD_MatID(string SMD_MatID){
	this.SMD_MatID = SMD_MatID;
}

public
void setSMD_MatSeq(int SMD_MatSeq){
	this.SMD_MatSeq = SMD_MatSeq;
}

public
void setSMD_MatReqDate(DateTime SMD_MatReqDate){
	this.SMD_MatReqDate = SMD_MatReqDate;
}

public
void setSMD_MatUom(string SMD_MatUom){
	this.SMD_MatUom = SMD_MatUom;
}

public
void setSMD_Usage(string SMD_Usage){
	this.SMD_Usage = SMD_Usage;
}

public
void setSMD_InvQty(decimal SMD_InvQty){
	this.SMD_InvQty = SMD_InvQty;
}

public
void setSMD_POQty(decimal SMD_POQty){
	this.SMD_POQty = SMD_POQty;
}

public
void setSMD_DemMatReq(decimal SMD_DemMatReq){
	this.SMD_DemMatReq = SMD_DemMatReq;
}

public
void setSMD_SchMatReq(decimal SMD_SchMatReq){
	this.SMD_SchMatReq = SMD_SchMatReq;
}

public
void setSMD_Factor(decimal SMD_Factor){
	this.SMD_Factor = SMD_Factor;
}


public
string getSMD_SchVersion(){
	return SMD_SchVersion;
}

public
string getSMD_Plt(){
	return SMD_Plt;
}

public
string getSMD_Dept(){
	return SMD_Dept;
}

public
string getSMD_ProdID(){
	return SMD_ProdID;
}

public
int getSMD_ProdSeq(){
	return SMD_ProdSeq;
}

public
string getSMD_MatID(){
	return SMD_MatID;
}

public
int getSMD_MatSeq(){
	return SMD_MatSeq;
}

public
DateTime getSMD_MatReqDate(){
	return SMD_MatReqDate;
}

public
string getSMD_MatUom(){
	return SMD_MatUom;
}

public
string getSMD_Usage(){
	return SMD_Usage;
}

public
decimal getSMD_InvQty(){
	return SMD_InvQty;
}

public
decimal getSMD_POQty(){
	return SMD_POQty;
}

public
decimal getSMD_DemMatReq(){
	return SMD_DemMatReq;
}

public
decimal getSMD_SchMatReq(){
	return SMD_SchMatReq;
}

public
decimal getSMD_Factor(){
	return SMD_Factor;
}

} // class

} // namespace