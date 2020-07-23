using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMachDayDataBase : GenericDataBaseElement{
	
private string SMD_SchVersion;
private string SMD_Plt;
private string SMD_Dept;
private string SMD_Mach;
private string SMD_TmType;
private DateTime SMD_Dt;
private string SMD_ProdID;
private string SMD_ActID;
private int SMD_Seq;
private decimal SMD_Hr;
private decimal SMD_HrPr;
private decimal SMD_Cycles;
private decimal SMD_HrCum;

public
SchMachDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMD_SchVersion = reader.GetString("SMD_SchVersion");
	this.SMD_Plt = reader.GetString("SMD_Plt");
	this.SMD_Dept = reader.GetString("SMD_Dept");
	this.SMD_Mach = reader.GetString("SMD_Mach");
	this.SMD_TmType = reader.GetString("SMD_TmType");
	this.SMD_Dt = reader.GetDateTime("SMD_Dt");
	this.SMD_ProdID = reader.GetString("SMD_ProdID");
	this.SMD_ActID = reader.GetString("SMD_ActID");
	this.SMD_Seq = reader.GetInt32("SMD_Seq");
	this.SMD_Hr = reader.GetDecimal("SMD_Hr");
	this.SMD_HrPr = reader.GetDecimal("SMD_HrPr");
	this.SMD_Cycles = reader.GetDecimal("SMD_Cycles");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmachday where " + 
					"SMD_SchVersion = '" + SMD_SchVersion + "' and " +
					"SMD_Plt = '" + SMD_Plt + "' and " +
					"SMD_Dept = '" + SMD_Dept + "' and " +
					"SMD_Mach = '" + SMD_Mach + "' and " +
					"SMD_TmType ='" + SMD_TmType + "' and " +
					"SMD_Dt = '" + DateUtil.getDateRepresentation(SMD_Dt) + "'";
		
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
		string sql = "insert into schmachday values('" + 
				Converter.fixString(SMD_SchVersion) +"', '" +
				Converter.fixString(SMD_Plt) +"', '" +
				Converter.fixString(SMD_Dept) +"', '" +
				Converter.fixString(SMD_Mach) +"', '" +
				Converter.fixString(SMD_TmType) +"', '" +
				DateUtil.getDateRepresentation(SMD_Dt) + "', '" +
				Converter.fixString(SMD_ProdID)  + "', '" +
				Converter.fixString(SMD_ActID)  + "', " +
				SMD_Seq + ", " +
				NumberUtil.toString(SMD_Hr) + ", " +
				NumberUtil.toString(SMD_HrPr) + ", " +
				NumberUtil.toString(SMD_Cycles) + ", " +
				NumberUtil.toString(SMD_HrCum) + ")";
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
void update(){
		try{
		string sql = "update schmachday set " +
				"SMD_ProdID = '" + Converter.fixString(SMD_ProdID) + "', " +
				"SMD_ActID = '" + Converter.fixString(SMD_ActID) + "', " +
				"SMD_Seq = " + SMD_Seq + ", " +
				"SMD_Hr = " + NumberUtil.toString(SMD_Hr) + ", " +
				"SMD_HrPr = " + NumberUtil.toString(SMD_HrPr) + ", " +
				"SMD_Cycles = " + NumberUtil.toString(SMD_Cycles) + ", " +
				"SMD_HrCum = " + NumberUtil.toString(SMD_HrCum) + 
			" where " + 
				"SMD_SchVersion = '" + SMD_SchVersion + "' and" +
				"SMD_Plt = '" + SMD_Plt + "' and" +
				"SMD_Dept = '" + SMD_Dept + "' and" + 
				"SMD_Mach = '" + SMD_Mach + "' and" +
				"SMD_TmType = '" + SMD_TmType + "' and" +
				"SMD_Dt = '" + DateUtil.getDateRepresentation(SMD_Dt) + "'";
		dataBaseAccess.executeUpdate(sql);
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
		string sql = "delete from schmachday where " +
			"SMD_SchVersion = '" + SMD_SchVersion + "' and" +
				"SMD_Plt = '" + SMD_Plt + "' and" +
				"SMD_Dept = '" + SMD_Dept + "' and" + 
				"SMD_Mach = '" + SMD_Mach + "' and" +
				"SMD_TmType = '" + SMD_TmType + "' and" +
				"SMD_Dt = '" + DateUtil.getDateRepresentation(SMD_Dt) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
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
void setSMD_Mach(string SMD_Mach){
	this.SMD_Mach = SMD_Mach;
}

public
void setSMD_TmType(string SMD_TmType){
	this.SMD_TmType = SMD_TmType;
}

public
void setSMD_Dt(DateTime SMD_Dt){
	this.SMD_Dt = SMD_Dt;
}


public
void setSMD_ProdID(string SMD_ProdID){
	this.SMD_ProdID = SMD_ProdID;
}

public
void setSMD_ActID(string SMD_ActID){
	this.SMD_ActID = SMD_ActID;
}

public
void setSMD_Seq(int SMD_Seq){
	this.SMD_Seq = SMD_Seq;
}

public
void setSMD_Hr(decimal SMD_Hr){
	this.SMD_Hr = SMD_Hr;
}

public
void setSMD_HrPr(decimal SMD_HrPr){
	this.SMD_HrPr = SMD_HrPr;
}

public
void setSMD_Cycles(decimal SMD_Cycles){
	this.SMD_Cycles = SMD_Cycles;
}

public 
void setSMD_HrCum(decimal SMD_HrCum){
	this.SMD_HrCum = SMD_HrCum;
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
string getSMD_Mach(){
	return SMD_Mach;
}

public
string getSMD_TmType(){
	return SMD_TmType;
}

public
DateTime getSMD_Dt(){
	return SMD_Dt;
}


public
string getSMD_ProdID(){
	return SMD_ProdID;
}

public
string getSMD_ActID(){
	return SMD_ActID;
}

public
int getSMD_Seq(){
	return SMD_Seq;
}

public
decimal getSMD_Hr(){
	return SMD_Hr;
}

public
decimal getSMD_HrPr(){
	return SMD_HrPr;
}

public
decimal getSMD_Cycles(){
	return SMD_Cycles;
}

public 
decimal getsMD_HrCum(){
	return SMD_HrCum;
}

}

}