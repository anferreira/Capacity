using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrOrdDetDataBase : GenericDataBaseElement{

private string SPOD_SchVersion;
private string SPOD_PrOrdMas;
private string SPOD_PrOrd;
private int SPOD_LineID;
private string SPOD_ProdID;
private string SPOD_ActID;
private int SPOD_Seq;
private decimal SPOD_Qty;
private decimal SPOD_QtyComp;
private decimal SPOD_QtyScrap;

public
SchPrOrdDetDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SPOD_SchVersion = reader.GetString("SPOD_SchVersion");
	this.SPOD_PrOrdMas = reader.GetString("SPOD_PrOrdMas");
	this.SPOD_PrOrd = reader.GetString("SPOD_PrOrd");
	this.SPOD_LineID = reader.GetInt32("SPOD_LineID");
	this.SPOD_ProdID = reader.GetString("SPOD_ProdID");
	this.SPOD_ActID = reader.GetString("SPOD_ActID");
	this.SPOD_Seq = reader.GetInt32("SPOD_Seq");
	this.SPOD_Qty = reader.GetDecimal("SPOD_Qty");
	this.SPOD_QtyComp = reader.GetDecimal("SPOD_QtyComp");
	this.SPOD_QtyScrap = reader.GetDecimal("SPOD_QtyScrap");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprorddet where " + 
			"SPOD_SchVersion = '" + SPOD_SchVersion + "' and " +
			"SPOD_PrOrdMas = '" + SPOD_PrOrdMas + "' and " +
			"SPOD_PrOrd = '" + SPOD_PrOrd + "' and " +
			"SPOD_LineID = " + SPOD_LineID;
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
		string sql = "delete from schprorddet where " +
			"SPOD_SchVersion = '" + SPOD_SchVersion + "' and " +
			"SPOD_PrOrdMas = '" + SPOD_PrOrdMas + "' and " +
			"SPOD_PrOrd = '" + SPOD_PrOrd + "' and " +
			"SPOD_LineID = " + SPOD_LineID;
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
		string sql = "update schprorddet set " +
			"SPOD_ProdID = '" + Converter.fixString(SPOD_ProdID) + "', " +
			"SPOD_ActID = '" + Converter.fixString(SPOD_ActID) + "', " +
			"SPOD_Seq = " + SPOD_Seq + ", " +
			"SPOD_Qty = " + SPOD_Qty + ", " +
			"SPOD_QtyComp = " + SPOD_QtyComp + ", " +
			"SPOD_QtyScrap = " + SPOD_QtyScrap +
		" where " + 
			"SPOD_SchVersion = '" + SPOD_SchVersion + "' and " +
			"SPOD_PrOrdMas = '" + SPOD_PrOrdMas + "' and " +
			"SPOD_PrOrd = '" + SPOD_PrOrd + "' and " +
			"SPOD_LineID = " + SPOD_LineID;
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
		string sql = "insert into schprorddet values('" + 
			Converter.fixString(SPOD_SchVersion) + "', '" +
			Converter.fixString(SPOD_PrOrdMas) + "', '" +
			Converter.fixString(SPOD_PrOrd) + "', " +
			SPOD_LineID + ", '" +
			Converter.fixString(SPOD_ProdID) + "', '" +
			Converter.fixString(SPOD_ActID) + "', " +
			NumberUtil.toString(SPOD_Seq) + ", " +
			NumberUtil.toString(SPOD_Qty) + ", " +
			NumberUtil.toString(SPOD_QtyComp) + ", " +
			NumberUtil.toString(SPOD_QtyScrap) + ")";

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
	}catch(MySql.Data.MySqlClient.MySqlException ){
		return false;
	}
	return true;
}

public
void setSPOD_SchVersion(string SPOD_SchVersion){
	this.SPOD_SchVersion = SPOD_SchVersion;
}

public
void setSPOD_PrOrdMas(string SPOD_PrOrdMas){
	this.SPOD_PrOrdMas = SPOD_PrOrdMas;
}

public
void setSPOD_PrOrd(string SPOD_PrOrd){
	this.SPOD_PrOrd = SPOD_PrOrd;
}

public
void setSPODD_LineID(int SPODD_LineID){
	this.SPOD_LineID = SPODD_LineID;
}


public
void setSPOD_ProdID(string SPOD_ProdID){
	this.SPOD_ProdID = SPOD_ProdID;
}

public
void setSPOD_ActID(string SPOD_ActID){
	this.SPOD_ActID = SPOD_ActID;
}

public
void setSPOD_Seq(int SPOD_Seq){
	this.SPOD_Seq = SPOD_Seq;
}

public
void setSPOD_Qty(decimal SPOD_Qty){
	this.SPOD_Qty = SPOD_Qty;
}

public
void setSPOD_QtyComp(decimal SPOD_QtyComp){
	this.SPOD_QtyComp = SPOD_QtyComp;
}

public
void setSPOD_QtyScrap(decimal SPOD_QtyScrap){
	this.SPOD_QtyScrap = SPOD_QtyScrap;
}


public
string getSPOD_SchVersion(){
	return SPOD_SchVersion;
}

public
string getSPOD_PrOrdMas(){
	return SPOD_PrOrdMas;
}

public
string getSPOD_PrOrd(){
	return SPOD_PrOrd;
}

public
int getSPODD_LineID(){
	return SPOD_LineID;
}


public
string getSPOD_ProdID(){
	return SPOD_ProdID;
}

public
string getSPOD_ActID(){
	return SPOD_ActID;
}

public
int getSPOD_Seq(){
	return SPOD_Seq;
}

public
decimal getSPOD_Qty(){
	return SPOD_Qty;
}

public
decimal getSPOD_QtyComp(){
	return SPOD_QtyComp;
}

public
decimal getSPOD_QtyScrap(){
	return SPOD_QtyScrap;
}

} // class

} // namespace