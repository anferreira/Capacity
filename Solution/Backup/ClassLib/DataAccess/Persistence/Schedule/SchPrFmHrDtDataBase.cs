using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrFmHrDtDataBase : GenericDataBaseElement{

private string SPHD_SchVersion;
private decimal SPHD_MachOrdNum;
private decimal SPHD_SchOrdNum;
private decimal SPHD_SubOrdNum;
private string SPHD_ProdID;
private string SPHD_ActID;
private int SPHD_Seq;
private decimal SPHD_DlyOrdID;
private decimal SPHD_CavAvail;
private decimal SPHD_QtySch;
private DateTime SPHD_Dt;
private string SPHD_PrOrdMas;
private string SPHD_PrOrd;

public
SchPrFmHrDtDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SPHD_SchVersion = reader.GetString("SPHD_SchVersion");
	this.SPHD_MachOrdNum = reader.GetInt32("SPHD_MachOrdNum");
	this.SPHD_SchOrdNum = reader.GetDecimal("SPHD_SchOrdNum");
	this.SPHD_SubOrdNum = reader.GetDecimal("SPHD_SubOrdNum");
	this.SPHD_ProdID = reader.GetString("SPHD_ProdID");
	this.SPHD_ActID = reader.GetString("SPHD_ActID");
	this.SPHD_Seq = reader.GetInt32("SPHD_Seq");
	this.SPHD_DlyOrdID = reader.GetDecimal("SPHD_DlyOrdID");
	this.SPHD_CavAvail = reader.GetDecimal("SPHD_CavAvail");
	this.SPHD_QtySch = reader.GetDecimal("SPHD_QtySch");
	this.SPHD_Dt = reader.GetDateTime("SPHD_Dt");
	this.SPHD_PrOrdMas = reader.GetString("SPHD_PrOrdMas");
	this.SPHD_PrOrd = reader.GetString("SPHD_PrOrd");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprfmhrdt where " + 
			"SPHD_SchVersion	= '" + SPHD_SchVersion + "' and " +
			"SPHD_MachOrdNum = " + SPHD_MachOrdNum + " and " +
			"SPHD_SchOrdNum = " + SPHD_SchOrdNum + " and " +
			"SPHD_SubOrdNum = " + SPHD_SubOrdNum;
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
void delete(){
	try{
		string sql = "delete from schprfmhrdt where " +
			"SPHD_SchVersion	= '" + SPHD_SchVersion + "' and " +
			"SPHD_MachOrdNum = " + SPHD_MachOrdNum + " and " +
			"SPHD_SchOrdNum = " + SPHD_SchOrdNum + " and " +
			"SPHD_SubOrdNum = " + SPHD_SubOrdNum;

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
		string sql = "update schprfmhrdt set " +
			"SPHD_ProdID = '" + Converter.fixString(SPHD_ProdID) + "', " +
			"SPHD_ActID = '" + Converter.fixString(SPHD_ActID) + "', " +
			"SPHD_Seq = " + SPHD_Seq + ", " +
			"SPHD_DlyOrdID = " + NumberUtil.toString(SPHD_DlyOrdID) + ", " +
			"SPHD_CavAvail = " + NumberUtil.toString(SPHD_CavAvail) + ", " +
			"SPHD_QtySch = " + NumberUtil.toString(SPHD_QtySch) + ", " +
			"SPHD_Dt = '" + DateUtil.getDateRepresentation(SPHD_Dt) + "', " +
			"SPHD_PrOrdMas = '" + Converter.fixString(SPHD_PrOrdMas) + "', " +
			"SPHD_PrOrd = '" + Converter.fixString(SPHD_PrOrd) + "' " +
		"where " + 
			"SPHD_SchVersion	= '" + SPHD_SchVersion + "' and " +
			"SPHD_MachOrdNum = " + SPHD_MachOrdNum + " and " +
			"SPHD_SchOrdNum = " + SPHD_SchOrdNum + " and " +
			"SPHD_SubOrdNum = " + SPHD_SubOrdNum;
		
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
void write(){
	try{
		string sql = "insert into schprfmhrdt values('" + 
			Converter.fixString(SPHD_SchVersion) + "', " +
			NumberUtil.toString(SPHD_MachOrdNum) + ", " +
			NumberUtil.toString(SPHD_SchOrdNum) + ", " +
			NumberUtil.toString(SPHD_SubOrdNum) + ", '" +
			Converter.fixString(SPHD_ProdID) + "', '" +
			Converter.fixString(SPHD_ActID) + "', " +
			SPHD_Seq + ", " +
			NumberUtil.toString(SPHD_DlyOrdID) + ", " +
			NumberUtil.toString(SPHD_CavAvail) + ", " +
			NumberUtil.toString(SPHD_QtySch) + ", '" +
			DateUtil.getDateRepresentation(SPHD_Dt) + "', '" +
			Converter.fixString(SPHD_PrOrdMas) + "', '" +
			Converter.fixString(SPHD_PrOrd) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	try{
		read();
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException){
		return false;
	}
	return true;
}

public
void setSPHD_SchVersion(string SPHD_SchVersion){
	this.SPHD_SchVersion = SPHD_SchVersion;
}

public
void setSPHD_MachOrdNum(decimal SPHD_MachOrdNum){
	this.SPHD_MachOrdNum = SPHD_MachOrdNum;
}

public
void setSPHD_SchOrdNum(decimal SPHD_SchOrdNum){
	this.SPHD_SchOrdNum = SPHD_SchOrdNum;
}

public
void setSPHD_SubOrdNum(decimal SPHD_SubOrdNum){
	this.SPHD_SubOrdNum = SPHD_SubOrdNum;
}



public
void setSPHD_ProdID(string SPHD_ProdID){
	this.SPHD_ProdID = SPHD_ProdID;
}

public
void setSPHD_ActID(string SPHD_ActID){
	this.SPHD_ActID = SPHD_ActID;
}

public
void setSPHD_Seq(int SPHD_Seq){
	this.SPHD_Seq = SPHD_Seq;
}

public
void setSPHD_DlyOrdID(decimal SPHD_DlyOrdID){
	this.SPHD_DlyOrdID = SPHD_DlyOrdID;
}

public
void setSPHD_CavAvail(decimal SPHD_CavAvail){
	this.SPHD_CavAvail = SPHD_CavAvail;
}

public
void setSPHD_QtySch(decimal SPHD_QtySch){
	this.SPHD_QtySch = SPHD_QtySch;
}

public
void setSPHD_Dt(DateTime SPHD_Dt){
	this.SPHD_Dt = SPHD_Dt;
}

public
void setSPHD_PrOrdMas(string SPHD_PrOrdMas){
	this.SPHD_PrOrdMas = SPHD_PrOrdMas;
}

public
void setSPHD_PrOrd(string SPHD_PrOrd){
	this.SPHD_PrOrd = SPHD_PrOrd;
}


public
string getSPHD_SchVersion(){
	return SPHD_SchVersion;
}

public
decimal getSPHD_MachOrdNum(){
	return SPHD_MachOrdNum;
}

public
decimal getSPHD_SchOrdNum(){
	return SPHD_SchOrdNum;
}

public
decimal getSPHD_SubOrdNum(){
	return SPHD_SubOrdNum;
}



public
string getSPHD_ProdID(){
	return SPHD_ProdID;
}

public
string getSPHD_ActID(){
	return SPHD_ActID;
}

public
int getSPHD_Seq(){
	return SPHD_Seq;
}

public
decimal getSPHD_DlyOrdID(){
	return SPHD_DlyOrdID;
}

public
decimal getSPHD_CavAvail(){
	return SPHD_CavAvail;
}

public
decimal getSPHD_QtySch(){
	return SPHD_QtySch;
}

public
DateTime getSPHD_Dt(){
	return SPHD_Dt;
}

public
string getSPHD_PrOrdMas(){
	return SPHD_PrOrdMas;
}

public
string getSPHD_PrOrd(){
	return SPHD_PrOrd;
}

} // class

} // namespace