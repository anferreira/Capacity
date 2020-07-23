using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class RPRPDataBase : GenericDataBaseElement{

private decimal OEBTID;
private decimal OEENT;
private string OEDEPT;
private string OERESC;
private DateTime OERDAT;
private decimal OESHFT;
private string OESHGP;
private string OEPART;
private string OEJOB;
private string OELOT;
private decimal OESEQ;
private decimal OESER;
private decimal OESQTY;
private string OEUNIT;
private string OEREAS;
private string OEMODE;
private string OECDPT;
private string OECRSC;
private string OEEDPT;
private string OEEMPL;
private string OESRCE;
private string OEPOST;
private DateTime OECDAT;
private DateTime OECTIM;
private decimal OEPENT;

public
RPRPDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	throw new PersistenceException("Not implemented !");
}

public
bool exists(){
	string sql = "select * from rprp where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.OEBTID = reader.GetDecimal("OEBTID");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.OEENT = reader.GetDecimal("OEENT#");
	else
		this.OEENT = reader.GetDecimal("OEENT");
	this.OEDEPT = reader.GetString("OEDEPT");
	this.OERESC = reader.GetString("OERESC");
	this.OERDAT = reader.GetDateTime("OERDAT");
	this.OESHFT = reader.GetDecimal("OESHFT");
	this.OESHGP = reader.GetString("OESHGP");
	this.OEPART = reader.GetString("OEPART");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.OEJOB = reader.GetString("OEJOB#");
		this.OELOT = reader.GetString("OELOT#");
		this.OESEQ = reader.GetDecimal("OESEQ#");
		this.OESER = reader.GetDecimal("OESER#");
	}else{
		this.OEJOB = reader.GetString("OEJOB");
		this.OELOT = reader.GetString("OELOT");
		this.OESEQ = reader.GetDecimal("OESEQ");
		this.OESER = reader.GetDecimal("OESER");
	}
	this.OESQTY = reader.GetDecimal("OESQTY");
	this.OEUNIT = reader.GetString("OEUNIT");
	this.OEREAS = reader.GetString("OEREAS");
	this.OEMODE = reader.GetString("OEMODE");
	this.OECDPT = reader.GetString("OECDPT");
	this.OECRSC = reader.GetString("OECRSC");
	this.OEEDPT = reader.GetString("OEEDPT");
	this.OEEMPL = reader.GetString("OEEMPL");
	this.OESRCE = reader.GetString("OESRCE");
	this.OEPOST = reader.GetString("OEPOST");
	this.OECDAT = reader.GetDateTime("OECDAT");
	this.OECTIM = reader.GetDateTime("OECTIM");
	this.OEPENT = reader.GetDecimal("OEPENT");
}

public override
void write(){
	string sql = "insert into rprp(" + 
		"OEBTID," +
		"OEENT," +
		"OEDEPT," +
		"OERESC," +
		"OERDAT," +
		"OESHFT," +
		"OESHGP," +
		"OEPART," +
		"OEJOB," +
		"OELOT," +
		"OESEQ," +
		"OESER," +
		"OESQTY," +
		"OEUNIT," +
		"OEREAS," +
		"OEMODE," +
		"OECDPT," +
		"OECRSC," +
		"OEEDPT," +
		"OEEMPL," +
		"OESRCE," +
		"OEPOST," +
		"OECDAT," +
		"OECTIM," +
		"OEPENT" +

		") values (" + 

		"" + NumberUtil.toString(OEBTID) + "," +
		"" + NumberUtil.toString(OEENT) + "," +
		"'" + Converter.fixString(OEDEPT) + "'," +
		"'" + Converter.fixString(OERESC) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OERDAT) + "'," +
		"" + NumberUtil.toString(OESHFT) + "," +
		"'" + Converter.fixString(OESHGP) + "'," +
		"'" + Converter.fixString(OEPART) + "'," +
		"'" + Converter.fixString(OEJOB) + "'," +
		"'" + Converter.fixString(OELOT) + "'," +
		"" + NumberUtil.toString(OESEQ) + "," +
		"" + NumberUtil.toString(OESER) + "," +
		"" + NumberUtil.toString(OESQTY) + "," +
		"'" + Converter.fixString(OEUNIT) + "'," +
		"'" + Converter.fixString(OEREAS) + "'," +
		"'" + Converter.fixString(OEMODE) + "'," +
		"'" + Converter.fixString(OECDPT) + "'," +
		"'" + Converter.fixString(OECRSC) + "'," +
		"'" + Converter.fixString(OEEDPT) + "'," +
		"'" + Converter.fixString(OEEMPL) + "'," +
		"'" + Converter.fixString(OESRCE) + "'," +
		"'" + Converter.fixString(OEPOST) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OECDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OECTIM) + "'," +
		"" + NumberUtil.toString(OEPENT) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update rprp set " +
		"OEBTID = " + NumberUtil.toString(OEBTID) + ", " +
		"OEENT = " + NumberUtil.toString(OEENT) + ", " +
		"OEDEPT = '" + Converter.fixString(OEDEPT) + "', " +
		"OERESC = '" + Converter.fixString(OERESC) + "', " +
		"OERDAT = '" + DateUtil.getCompleteDateRepresentation(OERDAT) + "', " +
		"OESHFT = " + NumberUtil.toString(OESHFT) + ", " +
		"OESHGP = '" + Converter.fixString(OESHGP) + "', " +
		"OEPART = '" + Converter.fixString(OEPART) + "', " +
		"OEJOB = '" + Converter.fixString(OEJOB) + "', " +
		"OELOT = '" + Converter.fixString(OELOT) + "', " +
		"OESEQ = " + NumberUtil.toString(OESEQ) + ", " +
		"OESER = " + NumberUtil.toString(OESER) + ", " +
		"OESQTY = " + NumberUtil.toString(OESQTY) + ", " +
		"OEUNIT = '" + Converter.fixString(OEUNIT) + "', " +
		"OEREAS = '" + Converter.fixString(OEREAS) + "', " +
		"OEMODE = '" + Converter.fixString(OEMODE) + "', " +
		"OECDPT = '" + Converter.fixString(OECDPT) + "', " +
		"OECRSC = '" + Converter.fixString(OECRSC) + "', " +
		"OEEDPT = '" + Converter.fixString(OEEDPT) + "', " +
		"OEEMPL = '" + Converter.fixString(OEEMPL) + "', " +
		"OESRCE = '" + Converter.fixString(OESRCE) + "', " +
		"OEPOST = '" + Converter.fixString(OEPOST) + "', " +
		"OECDAT = '" + DateUtil.getCompleteDateRepresentation(OECDAT) + "', " +
		"OECTIM = '" + DateUtil.getCompleteDateRepresentation(OECTIM) + "', " +
		"OEPENT = " + NumberUtil.toString(OEPENT) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rprp where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"OEBTID = " + NumberUtil.toString(OEBTID) + " and " +
		"OEENT = " + NumberUtil.toString(OEENT) + "";
	return sqlWhere;
}

public
void setOEBTID(decimal OEBTID){
	this.OEBTID = OEBTID;
}

public
void setOEENT(decimal OEENT){
	this.OEENT = OEENT;
}

public
void setOEDEPT(string OEDEPT){
	this.OEDEPT = OEDEPT;
}

public
void setOERESC(string OERESC){
	this.OERESC = OERESC;
}

public
void setOERDAT(DateTime OERDAT){
	this.OERDAT = OERDAT;
}

public
void setOESHFT(decimal OESHFT){
	this.OESHFT = OESHFT;
}

public
void setOESHGP(string OESHGP){
	this.OESHGP = OESHGP;
}

public
void setOEPART(string OEPART){
	this.OEPART = OEPART;
}

public
void setOEJOB(string OEJOB){
	this.OEJOB = OEJOB;
}

public
void setOELOT(string OELOT){
	this.OELOT = OELOT;
}

public
void setOESEQ(decimal OESEQ){
	this.OESEQ = OESEQ;
}

public
void setOESER(decimal OESER){
	this.OESER = OESER;
}

public
void setOESQTY(decimal OESQTY){
	this.OESQTY = OESQTY;
}

public
void setOEUNIT(string OEUNIT){
	this.OEUNIT = OEUNIT;
}

public
void setOEREAS(string OEREAS){
	this.OEREAS = OEREAS;
}

public
void setOEMODE(string OEMODE){
	this.OEMODE = OEMODE;
}

public
void setOECDPT(string OECDPT){
	this.OECDPT = OECDPT;
}

public
void setOECRSC(string OECRSC){
	this.OECRSC = OECRSC;
}

public
void setOEEDPT(string OEEDPT){
	this.OEEDPT = OEEDPT;
}

public
void setOEEMPL(string OEEMPL){
	this.OEEMPL = OEEMPL;
}

public
void setOESRCE(string OESRCE){
	this.OESRCE = OESRCE;
}

public
void setOEPOST(string OEPOST){
	this.OEPOST = OEPOST;
}

public
void setOECDAT(DateTime OECDAT){
	this.OECDAT = OECDAT;
}

public
void setOECTIM(DateTime OECTIM){
	this.OECTIM = OECTIM;
}

public
void setOEPENT(decimal OEPENT){
	this.OEPENT = OEPENT;
}

public
decimal getOEBTID(){
	return OEBTID;
}

public
decimal getOEENT(){
	return OEENT;
}

public
string getOEDEPT(){
	return OEDEPT;
}

public
string getOERESC(){
	return OERESC;
}

public
DateTime getOERDAT(){
	return OERDAT;
}

public
decimal getOESHFT(){
	return OESHFT;
}

public
string getOESHGP(){
	return OESHGP;
}

public
string getOEPART(){
	return OEPART;
}

public
string getOEJOB(){
	return OEJOB;
}

public
string getOELOT(){
	return OELOT;
}

public
decimal getOESEQ(){
	return OESEQ;
}

public
decimal getOESER(){
	return OESER;
}

public
decimal getOESQTY(){
	return OESQTY;
}

public
string getOEUNIT(){
	return OEUNIT;
}

public
string getOEREAS(){
	return OEREAS;
}

public
string getOEMODE(){
	return OEMODE;
}

public
string getOECDPT(){
	return OECDPT;
}

public
string getOECRSC(){
	return OECRSC;
}

public
string getOEEDPT(){
	return OEEDPT;
}

public
string getOEEMPL(){
	return OEEMPL;
}

public
string getOESRCE(){
	return OESRCE;
}

public
string getOEPOST(){
	return OEPOST;
}

public
DateTime getOECDAT(){
	return OECDAT;
}

public
DateTime getOECTIM(){
	return OECTIM;
}

public
decimal getOEPENT(){
	return OEPENT;
}

} // class

} // package