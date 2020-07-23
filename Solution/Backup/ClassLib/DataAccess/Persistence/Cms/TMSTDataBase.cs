/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/TMSTDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class TMSTDataBase : GenericDataBaseElement{

private string LXTOOL;
private string LXDES1;
private string LXDES2;
private string LXDES3;
private string LXCLSS;
private string LXAST;
private string LXSTKL;
private string LXBIN;
private string LXSTAT;
private decimal LXSETY;
private decimal LXSETL;
private decimal LXPARY;
private decimal LXPARL;
private string LXUNIT;
private decimal LXMCHY;
private decimal LXMCHL;
private decimal LXTIMY;
private decimal LXTIML;
private decimal LXCNTY;
private decimal LXCNTL;
private DateTime LXADAT;
private DateTime LXBDAT;
private DateTime LXDDAT;
private string LXFPRT;
private string LXFORD;
private DateTime LXEDAT;
private string LXLPRT;
private string LXLORD;
private DateTime LXFDAT;
private string LXCPRT;
private string LXCORD;
private string LXMTPT;
private decimal LXPMTL;
private string LXOWNT;
private string LXOWNR;
private string LXCTBY;
private DateTime LXCDAT;
private string LXUPBY;
private DateTime LXUDAT;

public
TMSTDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from tmst where " + getWhereCondition();
		
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
	string sql = "select * from tmst where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.LXTOOL = reader.GetString("LXTOOL");
	this.LXDES1 = reader.GetString("LXDES1");
	this.LXDES2 = reader.GetString("LXDES2");
	this.LXDES3 = reader.GetString("LXDES3");
	this.LXCLSS = reader.GetString("LXCLSS");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.LXAST = reader.GetString("LXAST#");
	else
		this.LXAST = reader.GetString("LXAST");
	this.LXSTKL = reader.GetString("LXSTKL");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.LXBIN = reader.GetString("LXBIN#");
	else
		this.LXBIN = reader.GetString("LXBIN");
	this.LXSTAT = reader.GetString("LXSTAT");
	this.LXSETY = reader.GetDecimal("LXSETY");
	this.LXSETL = reader.GetDecimal("LXSETL");
	this.LXPARY = reader.GetDecimal("LXPARY");
	this.LXPARL = reader.GetDecimal("LXPARL");
	this.LXUNIT = reader.GetString("LXUNIT");
	this.LXMCHY = reader.GetDecimal("LXMCHY");
	this.LXMCHL = reader.GetDecimal("LXMCHL");
	this.LXTIMY = reader.GetDecimal("LXTIMY");
	this.LXTIML = reader.GetDecimal("LXTIML");
	this.LXCNTY = reader.GetDecimal("LXCNTY");
	this.LXCNTL = reader.GetDecimal("LXCNTL");
	this.LXADAT = reader.GetDateTime("LXADAT");
	this.LXBDAT = reader.GetDateTime("LXBDAT");
	this.LXDDAT = reader.GetDateTime("LXDDAT");
	this.LXFPRT = reader.GetString("LXFPRT");
	this.LXFORD = reader.GetString("LXFORD");
	this.LXEDAT = reader.GetDateTime("LXEDAT");
	this.LXLPRT = reader.GetString("LXLPRT");
	this.LXLORD = reader.GetString("LXLORD");
	this.LXFDAT = reader.GetDateTime("LXFDAT");
	this.LXCPRT = reader.GetString("LXCPRT");
	this.LXCORD = reader.GetString("LXCORD");
	this.LXMTPT = reader.GetString("LXMTPT");
	this.LXPMTL = reader.GetDecimal("LXPMTL");
	this.LXOWNT = reader.GetString("LXOWNT");
	this.LXOWNR = reader.GetString("LXOWNR");
	this.LXCTBY = reader.GetString("LXCTBY");
	this.LXCDAT = reader.GetDateTime("LXCDAT");
	this.LXUPBY = reader.GetString("LXUPBY");
	this.LXUDAT = reader.GetDateTime("LXUDAT");
}

public override
void write(){
	string sql = "insert into tmst(" + 
		"LXTOOL," +
		"LXDES1," +
		"LXDES2," +
		"LXDES3," +
		"LXCLSS," +
		"LXAST," +
		"LXSTKL," +
		"LXBIN," +
		"LXSTAT," +
		"LXSETY," +
		"LXSETL," +
		"LXPARY," +
		"LXPARL," +
		"LXUNIT," +
		"LXMCHY," +
		"LXMCHL," +
		"LXTIMY," +
		"LXTIML," +
		"LXCNTY," +
		"LXCNTL," +
		"LXADAT," +
		"LXBDAT," +
		"LXDDAT," +
		"LXFPRT," +
		"LXFORD," +
		"LXEDAT," +
		"LXLPRT," +
		"LXLORD," +
		"LXFDAT," +
		"LXCPRT," +
		"LXCORD," +
		"LXMTPT," +
		"LXPMTL," +
		"LXOWNT," +
		"LXOWNR," +
		"LXCTBY," +
		"LXCDAT," +
		"LXUPBY," +
		"LXUDAT" +

		") values (" + 

		"'" + Converter.fixString(LXTOOL) + "'," +
		"'" + Converter.fixString(LXDES1) + "'," +
		"'" + Converter.fixString(LXDES2) + "'," +
		"'" + Converter.fixString(LXDES3) + "'," +
		"'" + Converter.fixString(LXCLSS) + "'," +
		"'" + Converter.fixString(LXAST) + "'," +
		"'" + Converter.fixString(LXSTKL) + "'," +
		"'" + Converter.fixString(LXBIN) + "'," +
		"'" + Converter.fixString(LXSTAT) + "'," +
		"" + NumberUtil.toString(LXSETY) + "," +
		"" + NumberUtil.toString(LXSETL) + "," +
		"" + NumberUtil.toString(LXPARY) + "," +
		"" + NumberUtil.toString(LXPARL) + "," +
		"'" + Converter.fixString(LXUNIT) + "'," +
		"" + NumberUtil.toString(LXMCHY) + "," +
		"" + NumberUtil.toString(LXMCHL) + "," +
		"" + NumberUtil.toString(LXTIMY) + "," +
		"" + NumberUtil.toString(LXTIML) + "," +
		"" + NumberUtil.toString(LXCNTY) + "," +
		"" + NumberUtil.toString(LXCNTL) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(LXADAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LXBDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LXDDAT) + "'," +
		"'" + Converter.fixString(LXFPRT) + "'," +
		"'" + Converter.fixString(LXFORD) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LXEDAT) + "'," +
		"'" + Converter.fixString(LXLPRT) + "'," +
		"'" + Converter.fixString(LXLORD) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LXFDAT) + "'," +
		"'" + Converter.fixString(LXCPRT) + "'," +
		"'" + Converter.fixString(LXCORD) + "'," +
		"'" + Converter.fixString(LXMTPT) + "'," +
		"" + NumberUtil.toString(LXPMTL) + "," +
		"'" + Converter.fixString(LXOWNT) + "'," +
		"'" + Converter.fixString(LXOWNR) + "'," +
		"'" + Converter.fixString(LXCTBY) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LXCDAT) + "'," +
		"'" + Converter.fixString(LXUPBY) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LXUDAT) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update tmst set " +
		"LXTOOL = '" + Converter.fixString(LXTOOL) + "', " +
		"LXDES1 = '" + Converter.fixString(LXDES1) + "', " +
		"LXDES2 = '" + Converter.fixString(LXDES2) + "', " +
		"LXDES3 = '" + Converter.fixString(LXDES3) + "', " +
		"LXCLSS = '" + Converter.fixString(LXCLSS) + "', " +
		"LXAST = '" + Converter.fixString(LXAST) + "', " +
		"LXSTKL = '" + Converter.fixString(LXSTKL) + "', " +
		"LXBIN = '" + Converter.fixString(LXBIN) + "', " +
		"LXSTAT = '" + Converter.fixString(LXSTAT) + "', " +
		"LXSETY = " + NumberUtil.toString(LXSETY) + ", " +
		"LXSETL = " + NumberUtil.toString(LXSETL) + ", " +
		"LXPARY = " + NumberUtil.toString(LXPARY) + ", " +
		"LXPARL = " + NumberUtil.toString(LXPARL) + ", " +
		"LXUNIT = '" + Converter.fixString(LXUNIT) + "', " +
		"LXMCHY = " + NumberUtil.toString(LXMCHY) + ", " +
		"LXMCHL = " + NumberUtil.toString(LXMCHL) + ", " +
		"LXTIMY = " + NumberUtil.toString(LXTIMY) + ", " +
		"LXTIML = " + NumberUtil.toString(LXTIML) + ", " +
		"LXCNTY = " + NumberUtil.toString(LXCNTY) + ", " +
		"LXCNTL = " + NumberUtil.toString(LXCNTL) + ", " +
		"LXADAT = '" + DateUtil.getCompleteDateRepresentation(LXADAT) + "', " +
		"LXBDAT = '" + DateUtil.getCompleteDateRepresentation(LXBDAT) + "', " +
		"LXDDAT = '" + DateUtil.getCompleteDateRepresentation(LXDDAT) + "', " +
		"LXFPRT = '" + Converter.fixString(LXFPRT) + "', " +
		"LXFORD = '" + Converter.fixString(LXFORD) + "', " +
		"LXEDAT = '" + DateUtil.getCompleteDateRepresentation(LXEDAT) + "', " +
		"LXLPRT = '" + Converter.fixString(LXLPRT) + "', " +
		"LXLORD = '" + Converter.fixString(LXLORD) + "', " +
		"LXFDAT = '" + DateUtil.getCompleteDateRepresentation(LXFDAT) + "', " +
		"LXCPRT = '" + Converter.fixString(LXCPRT) + "', " +
		"LXCORD = '" + Converter.fixString(LXCORD) + "', " +
		"LXMTPT = '" + Converter.fixString(LXMTPT) + "', " +
		"LXPMTL = " + NumberUtil.toString(LXPMTL) + ", " +
		"LXOWNT = '" + Converter.fixString(LXOWNT) + "', " +
		"LXOWNR = '" + Converter.fixString(LXOWNR) + "', " +
		"LXCTBY = '" + Converter.fixString(LXCTBY) + "', " +
		"LXCDAT = '" + DateUtil.getCompleteDateRepresentation(LXCDAT) + "', " +
		"LXUPBY = '" + Converter.fixString(LXUPBY) + "', " +
		"LXUDAT = '" + DateUtil.getCompleteDateRepresentation(LXUDAT) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from tmst where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"LXTOOL = '" + Converter.fixString(LXTOOL) + "'";
	return sqlWhere;
}

public
void setLXTOOL(string LXTOOL){
	this.LXTOOL = LXTOOL;
}

public
void setLXDES1(string LXDES1){
	this.LXDES1 = LXDES1;
}

public
void setLXDES2(string LXDES2){
	this.LXDES2 = LXDES2;
}

public
void setLXDES3(string LXDES3){
	this.LXDES3 = LXDES3;
}

public
void setLXCLSS(string LXCLSS){
	this.LXCLSS = LXCLSS;
}

public
void setLXAST(string LXAST){
	this.LXAST = LXAST;
}

public
void setLXSTKL(string LXSTKL){
	this.LXSTKL = LXSTKL;
}

public
void setLXBIN(string LXBIN){
	this.LXBIN = LXBIN;
}

public
void setLXSTAT(string LXSTAT){
	this.LXSTAT = LXSTAT;
}

public
void setLXSETY(decimal LXSETY){
	this.LXSETY = LXSETY;
}

public
void setLXSETL(decimal LXSETL){
	this.LXSETL = LXSETL;
}

public
void setLXPARY(decimal LXPARY){
	this.LXPARY = LXPARY;
}

public
void setLXPARL(decimal LXPARL){
	this.LXPARL = LXPARL;
}

public
void setLXUNIT(string LXUNIT){
	this.LXUNIT = LXUNIT;
}

public
void setLXMCHY(decimal LXMCHY){
	this.LXMCHY = LXMCHY;
}

public
void setLXMCHL(decimal LXMCHL){
	this.LXMCHL = LXMCHL;
}

public
void setLXTIMY(decimal LXTIMY){
	this.LXTIMY = LXTIMY;
}

public
void setLXTIML(decimal LXTIML){
	this.LXTIML = LXTIML;
}

public
void setLXCNTY(decimal LXCNTY){
	this.LXCNTY = LXCNTY;
}

public
void setLXCNTL(decimal LXCNTL){
	this.LXCNTL = LXCNTL;
}

public
void setLXADAT(DateTime LXADAT){
	this.LXADAT = LXADAT;
}

public
void setLXBDAT(DateTime LXBDAT){
	this.LXBDAT = LXBDAT;
}

public
void setLXDDAT(DateTime LXDDAT){
	this.LXDDAT = LXDDAT;
}

public
void setLXFPRT(string LXFPRT){
	this.LXFPRT = LXFPRT;
}

public
void setLXFORD(string LXFORD){
	this.LXFORD = LXFORD;
}

public
void setLXEDAT(DateTime LXEDAT){
	this.LXEDAT = LXEDAT;
}

public
void setLXLPRT(string LXLPRT){
	this.LXLPRT = LXLPRT;
}

public
void setLXLORD(string LXLORD){
	this.LXLORD = LXLORD;
}

public
void setLXFDAT(DateTime LXFDAT){
	this.LXFDAT = LXFDAT;
}

public
void setLXCPRT(string LXCPRT){
	this.LXCPRT = LXCPRT;
}

public
void setLXCORD(string LXCORD){
	this.LXCORD = LXCORD;
}

public
void setLXMTPT(string LXMTPT){
	this.LXMTPT = LXMTPT;
}

public
void setLXPMTL(decimal LXPMTL){
	this.LXPMTL = LXPMTL;
}

public
void setLXOWNT(string LXOWNT){
	this.LXOWNT = LXOWNT;
}

public
void setLXOWNR(string LXOWNR){
	this.LXOWNR = LXOWNR;
}

public
void setLXCTBY(string LXCTBY){
	this.LXCTBY = LXCTBY;
}

public
void setLXCDAT(DateTime LXCDAT){
	this.LXCDAT = LXCDAT;
}

public
void setLXUPBY(string LXUPBY){
	this.LXUPBY = LXUPBY;
}

public
void setLXUDAT(DateTime LXUDAT){
	this.LXUDAT = LXUDAT;
}

public
string getLXTOOL(){
	return LXTOOL;
}

public
string getLXDES1(){
	return LXDES1;
}

public
string getLXDES2(){
	return LXDES2;
}

public
string getLXDES3(){
	return LXDES3;
}

public
string getLXCLSS(){
	return LXCLSS;
}

public
string getLXAST(){
	return LXAST;
}

public
string getLXSTKL(){
	return LXSTKL;
}

public
string getLXBIN(){
	return LXBIN;
}

public
string getLXSTAT(){
	return LXSTAT;
}

public
decimal getLXSETY(){
	return LXSETY;
}

public
decimal getLXSETL(){
	return LXSETL;
}

public
decimal getLXPARY(){
	return LXPARY;
}

public
decimal getLXPARL(){
	return LXPARL;
}

public
string getLXUNIT(){
	return LXUNIT;
}

public
decimal getLXMCHY(){
	return LXMCHY;
}

public
decimal getLXMCHL(){
	return LXMCHL;
}

public
decimal getLXTIMY(){
	return LXTIMY;
}

public
decimal getLXTIML(){
	return LXTIML;
}

public
decimal getLXCNTY(){
	return LXCNTY;
}

public
decimal getLXCNTL(){
	return LXCNTL;
}

public
DateTime getLXADAT(){
	return LXADAT;
}

public
DateTime getLXBDAT(){
	return LXBDAT;
}

public
DateTime getLXDDAT(){
	return LXDDAT;
}

public
string getLXFPRT(){
	return LXFPRT;
}

public
string getLXFORD(){
	return LXFORD;
}

public
DateTime getLXEDAT(){
	return LXEDAT;
}

public
string getLXLPRT(){
	return LXLPRT;
}

public
string getLXLORD(){
	return LXLORD;
}

public
DateTime getLXFDAT(){
	return LXFDAT;
}

public
string getLXCPRT(){
	return LXCPRT;
}

public
string getLXCORD(){
	return LXCORD;
}

public
string getLXMTPT(){
	return LXMTPT;
}

public
decimal getLXPMTL(){
	return LXPMTL;
}

public
string getLXOWNT(){
	return LXOWNT;
}

public
string getLXOWNR(){
	return LXOWNR;
}

public
string getLXCTBY(){
	return LXCTBY;
}

public
DateTime getLXCDAT(){
	return LXCDAT;
}

public
string getLXUPBY(){
	return LXUPBY;
}

public
DateTime getLXUDAT(){
	return LXUDAT;
}

} // class

} // package