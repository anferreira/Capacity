/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/MTHLDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class MTHLDataBase : GenericDataBaseElement{

private string MHPART;
private decimal MHSEQ;
private decimal MHLIN;
private decimal MHENT;
private string MHTOOL;
private string MHRSET;
private string MHRRUN;
private decimal MHQTYP;
private string MHUNIT;
private string MHCTBY;
private DateTime MHCDAT;
private string MHUPBY;
private DateTime MHUDAT;

public
MTHLDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from mthl where " + getWhereCondition();
		
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
	string sql = "select * from mthl where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.MHPART = reader.GetString("MHPART");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.MHSEQ = reader.GetDecimal("MHSEQ#");
		this.MHLIN = reader.GetDecimal("MHLIN#");
		this.MHENT = reader.GetDecimal("MHENT#");
	}
	else{
		this.MHSEQ = reader.GetDecimal("MHSEQ");
		this.MHLIN = reader.GetDecimal("MHLIN");
		this.MHENT = reader.GetDecimal("MHENT");
	}
	this.MHTOOL = reader.GetString("MHTOOL");
	this.MHRSET = reader.GetString("MHRSET");
	this.MHRRUN = reader.GetString("MHRRUN");
	this.MHQTYP = reader.GetDecimal("MHQTYP");
	this.MHUNIT = reader.GetString("MHUNIT");
	this.MHCTBY = reader.GetString("MHCTBY");
	this.MHCDAT = reader.GetDateTime("MHCDAT");
	this.MHUPBY = reader.GetString("MHUPBY");
	this.MHUDAT = reader.GetDateTime("MHUDAT");
}

public override
void write(){
	string sql = "insert into mthl(" + 
		"MHPART," +
		"MHSEQ," +
		"MHLIN," +
		"MHENT," +
		"MHTOOL," +
		"MHRSET," +
		"MHRRUN," +
		"MHQTYP," +
		"MHUNIT," +
		"MHCTBY," +
		"MHCDAT," +
		"MHUPBY," +
		"MHUDAT" +

		") values (" + 

		"'" + Converter.fixString(MHPART) + "'," +
		"" + NumberUtil.toString(MHSEQ) + "," +
		"" + NumberUtil.toString(MHLIN) + "," +
		"" + NumberUtil.toString(MHENT) + "," +
		"'" + Converter.fixString(MHTOOL) + "'," +
		"'" + Converter.fixString(MHRSET) + "'," +
		"'" + Converter.fixString(MHRRUN) + "'," +
		"" + NumberUtil.toString(MHQTYP) + "," +
		"'" + Converter.fixString(MHUNIT) + "'," +
		"'" + Converter.fixString(MHCTBY) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(MHCDAT) + "'," +
		"'" + Converter.fixString(MHUPBY) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(MHUDAT) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update mthl set " +
		"MHPART = '" + Converter.fixString(MHPART) + "', " +
		"MHSEQ = " + NumberUtil.toString(MHSEQ) + ", " +
		"MHLIN = " + NumberUtil.toString(MHLIN) + ", " +
		"MHENT = " + NumberUtil.toString(MHENT) + ", " +
		"MHTOOL = '" + Converter.fixString(MHTOOL) + "', " +
		"MHRSET = '" + Converter.fixString(MHRSET) + "', " +
		"MHRRUN = '" + Converter.fixString(MHRRUN) + "', " +
		"MHQTYP = " + NumberUtil.toString(MHQTYP) + ", " +
		"MHUNIT = '" + Converter.fixString(MHUNIT) + "', " +
		"MHCTBY = '" + Converter.fixString(MHCTBY) + "', " +
		"MHCDAT = '" + DateUtil.getCompleteDateRepresentation(MHCDAT) + "', " +
		"MHUPBY = '" + Converter.fixString(MHUPBY) + "', " +
		"MHUDAT = '" + DateUtil.getCompleteDateRepresentation(MHUDAT) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from mthl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"MHPART = '" + Converter.fixString(MHPART) + "' and " +
		"MHSEQ = " + NumberUtil.toString(MHSEQ) + " and " +
		"MHLIN = " + NumberUtil.toString(MHLIN) + " and " +
		"MHENT = " + NumberUtil.toString(MHENT) + "";
	return sqlWhere;
}

public
void setMHPART(string MHPART){
	this.MHPART = MHPART;
}

public
void setMHSEQ(decimal MHSEQ){
	this.MHSEQ = MHSEQ;
}

public
void setMHLIN(decimal MHLIN){
	this.MHLIN = MHLIN;
}

public
void setMHENT(decimal MHENT){
	this.MHENT = MHENT;
}

public
void setMHTOOL(string MHTOOL){
	this.MHTOOL = MHTOOL;
}

public
void setMHRSET(string MHRSET){
	this.MHRSET = MHRSET;
}

public
void setMHRRUN(string MHRRUN){
	this.MHRRUN = MHRRUN;
}

public
void setMHQTYP(decimal MHQTYP){
	this.MHQTYP = MHQTYP;
}

public
void setMHUNIT(string MHUNIT){
	this.MHUNIT = MHUNIT;
}

public
void setMHCTBY(string MHCTBY){
	this.MHCTBY = MHCTBY;
}

public
void setMHCDAT(DateTime MHCDAT){
	this.MHCDAT = MHCDAT;
}

public
void setMHUPBY(string MHUPBY){
	this.MHUPBY = MHUPBY;
}

public
void setMHUDAT(DateTime MHUDAT){
	this.MHUDAT = MHUDAT;
}

public
string getMHPART(){
	return MHPART;
}

public
decimal getMHSEQ(){
	return MHSEQ;
}

public
decimal getMHLIN(){
	return MHLIN;
}

public
decimal getMHENT(){
	return MHENT;
}

public
string getMHTOOL(){
	return MHTOOL;
}

public
string getMHRSET(){
	return MHRSET;
}

public
string getMHRRUN(){
	return MHRRUN;
}

public
decimal getMHQTYP(){
	return MHQTYP;
}

public
string getMHUNIT(){
	return MHUNIT;
}

public
string getMHCTBY(){
	return MHCTBY;
}

public
DateTime getMHCDAT(){
	return MHCDAT;
}

public
string getMHUPBY(){
	return MHUPBY;
}

public
DateTime getMHUDAT(){
	return MHUDAT;
}

} // class

} // package