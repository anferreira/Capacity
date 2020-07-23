using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMatReqShfDataBase : GenericDataBaseElement{

private string SMR_SchVersion;
private int SMR_MachOrdNum;
private string SMR_Plt;
private string SMR_Dept;
private string SMR_Mach;
private string SMH_Shf;
private DateTime SMH_Dt;
private DateTime SMH_DtShf;
private string SMH_MatID;
private int SMH_Seq;
private string SMH_ActID;
private decimal SMH_QtyPerInv;
private decimal SMH_QtyReq;
private string SMH_Uom;
private decimal SMH_InvStartPos;
private decimal SMH_InvEndPos;

public
SchMatReqShfDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMR_SchVersion = reader.GetString("SMR_SchVersion");
	this.SMR_MachOrdNum = reader.GetInt32("SMR_MachOrdNum");
	this.SMR_Plt = reader.GetString("SMR_Plt");
	this.SMR_Dept = reader.GetString("SMR_Dept");
	this.SMR_Mach = reader.GetString("SMR_Mach");
	this.SMH_Shf = reader.GetString("SMH_Shf");
	this.SMH_Dt = reader.GetDateTime("SMH_Dt");
	this.SMH_DtShf = reader.GetDateTime("SMH_DtShf");
	this.SMH_MatID = reader.GetString("SMH_MatID");
	this.SMH_Seq = reader.GetInt32("SMH_Seq");
	this.SMH_ActID = reader.GetString("SMH_ActID");
	this.SMH_QtyPerInv = reader.GetDecimal("SMH_QtyPerInv");
	this.SMH_QtyReq = reader.GetDecimal("SMH_QtyReq");
	this.SMH_Uom = reader.GetString("SMH_Uom");
	this.SMH_InvStartPos = reader.GetDecimal("SMH_InvStartPos");
	this.SMH_InvEndPos = reader.GetDecimal("SMH_InvEndPos");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqshf where " + 
			"SMR_SchVersion = '" + SMR_SchVersion + "'";
		
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
		string sql = "insert into schmatreqshf values('" + 
			Converter.fixString(SMR_SchVersion) + "', " +
			SMR_MachOrdNum + ", '" +
			Converter.fixString(SMR_Plt) + "', '" +
			Converter.fixString(SMR_Dept) + "', '" +
			Converter.fixString(SMR_Mach) + "', '" +
			Converter.fixString(SMH_Shf) + "', '" +
			DateUtil.getDateRepresentation(SMH_Dt) + "', '" +
			DateUtil.getDateRepresentation(SMH_DtShf) + "', '" +
			Converter.fixString(SMH_MatID) + "', " +
			SMH_Seq + ", '" +
			Converter.fixString(SMH_ActID) + "', " +
			NumberUtil.toString(SMH_QtyPerInv) + ", " +
			NumberUtil.toString(SMH_QtyReq) + ", '" +
			Converter.fixString(SMH_Uom) + "', " +
			NumberUtil.toString(SMH_InvStartPos) + ", " +
			NumberUtil.toString(SMH_InvEndPos) + ")";

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
		string sql = "delete from schmatreqshf where " +
			"SMR_SchVersion = '" + SMR_SchVersion + "'";
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
		string sql = "update schmatreqshf set " +
			"SMR_MachOrdNum = " + SMR_MachOrdNum + ", " + 
			"SMR_Plt = '" + Converter.fixString(SMR_Plt) + "', " + 
			"SMR_Dept = '" + Converter.fixString(SMR_Dept) + "', " + 
			"SMR_Mach = '" + Converter.fixString(SMR_Mach) + "', " + 
			"SMH_Shf = '" + Converter.fixString(SMH_Shf) + "', " + 
			"SMH_Dt = '" + DateUtil.getDateRepresentation(SMH_Dt) + "', " + 
			"SMH_DtShf = '" + DateUtil.getDateRepresentation(SMH_DtShf) + "', " + 
			"SMH_MatID = '" + Converter.fixString(SMH_MatID) + "', " + 
			"SMH_Seq = " + SMH_Seq + ", " + 
			"SMH_ActID = '" + Converter.fixString(SMH_ActID) + "', " + 
			"SMH_QtyPerInv = " + NumberUtil.toString(SMH_QtyPerInv) + ", " + 
			"SMH_QtyReq = " + NumberUtil.toString(SMH_QtyReq) + ", " + 
			"SMH_Uom = '" + Converter.fixString(SMH_Uom) + "', " + 
			"SMH_InvStartPos = " + NumberUtil.toString(SMH_InvStartPos) + ", " + 
			"SMH_InvEndPos = " + NumberUtil.toString(SMH_InvEndPos) + 
		" where " + 
			"SMR_SchVersion = '" + SMR_SchVersion + "'";
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
void setSMR_SchVersion(string SMR_SchVersion){
	this.SMR_SchVersion = SMR_SchVersion;
}

public
void setSMR_MachOrdNum(int SMR_MachOrdNum){
	this.SMR_MachOrdNum = SMR_MachOrdNum;
}

public
void setSMR_Plt(string SMR_Plt){
	this.SMR_Plt = SMR_Plt;
}

public
void setSMR_Dept(string SMR_Dept){
	this.SMR_Dept = SMR_Dept;
}

public
void setSMR_Mach(string SMR_Mach){
	this.SMR_Mach = SMR_Mach;
}

public
void setSMH_Shf(string SMH_Shf){
	this.SMH_Shf = SMH_Shf;
}

public
void setSMH_Dt(DateTime SMH_Dt){
	this.SMH_Dt = SMH_Dt;
}

public
void setSMH_DtShf(DateTime SMH_DtShf){
	this.SMH_DtShf = SMH_DtShf;
}

public
void setSMH_MatID(string SMH_MatID){
	this.SMH_MatID = SMH_MatID;
}

public
void setSMH_Seq(int SMH_Seq){
	this.SMH_Seq = SMH_Seq;
}

public
void setSMH_ActID(string SMH_ActID){
	this.SMH_ActID = SMH_ActID;
}

public
void setSMH_QtyPerInv(decimal SMH_QtyPerInv){
	this.SMH_QtyPerInv = SMH_QtyPerInv;
}

public
void setSMH_QtyReq(decimal SMH_QtyReq){
	this.SMH_QtyReq = SMH_QtyReq;
}

public
void setSMH_Uom(string SMH_Uom){
	this.SMH_Uom = SMH_Uom;
}

public
void setSMH_InvStartPos(decimal SMH_InvStartPos){
	this.SMH_InvStartPos = SMH_InvStartPos;
}

public
void setSMH_InvEndPos(decimal SMH_InvEndPos){
	this.SMH_InvEndPos = SMH_InvEndPos;
}


public
string getSMR_SchVersion(){
	return SMR_SchVersion;
}

public
int getSMR_MachOrdNum(){
	return SMR_MachOrdNum;
}

public
string getSMR_Plt(){
	return SMR_Plt;
}

public
string getSMR_Dept(){
	return SMR_Dept;
}

public
string getSMR_Mach(){
	return SMR_Mach;
}

public
string getSMH_Shf(){
	return SMH_Shf;
}

public
DateTime getSMH_Dt(){
	return SMH_Dt;
}

public
DateTime getSMH_DtShf(){
	return SMH_DtShf;
}

public
string getSMH_MatID(){
	return SMH_MatID;
}

public
int getSMH_Seq(){
	return SMH_Seq;
}

public
string getSMH_ActID(){
	return SMH_ActID;
}

public
decimal getSMH_QtyPerInv(){
	return SMH_QtyPerInv;
}

public
decimal getSMH_QtyReq(){
	return SMH_QtyReq;
}

public
string getSMH_Uom(){
	return SMH_Uom;
}

public
decimal getSMH_InvStartPos(){
	return SMH_InvStartPos;
}

public
decimal getSMH_InvEndPos(){
	return SMH_InvEndPos;
}

} // class

} // namespace