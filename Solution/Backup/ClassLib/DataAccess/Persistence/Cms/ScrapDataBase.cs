using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class ScrapDataBase : GenericDataBaseElement{
private decimal BOTRAN;
private string BOREAS;
private DateTime BODATE;
private string BOSHFT;
private string BODEPT;
private string BORESC;
private string BOPART;
private string BOWORK;
private decimal BOSEQN;
private string BOLOT;
private decimal BOQTYS;
private string BOUNIT;
private string BOEDEP;
private string BOEMPL;
private decimal BOTICK;
private string BOA7;
private string BOSGRP;
private string BOMAJG;
private decimal BOFSYY;
private decimal BOFSPP;
private decimal BOBTCH;
private decimal BOBID;
public 
ScrapDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public
void load(NotNullDataReader reader){
	this.BOTRAN = reader.GetDecimal("BOTRAN");
	this.BOREAS = reader.GetString("BOREAS");
	this.BODATE = reader.GetDateTime("BODATE");
	this.BOSHFT = reader.GetString("BOSHFT");
	this.BODEPT = reader.GetString("BODEPT");
	this.BORESC = reader.GetString("BORESC");
	this.BOPART = reader.GetString("BOPART");
	this.BOWORK = reader.GetString("BOWORK");
	this.BOSEQN = reader.GetDecimal("BOSEQN");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.BOLOT = reader.GetString("BOLOT#");
	else
		this.BOLOT = reader.GetString("BOLOT");
	this.BOQTYS = reader.GetDecimal("BOQTYS");
	this.BOUNIT = reader.GetString("BOUNIT");
	this.BOEDEP = reader.GetString("BOEDEP");
	this.BOEMPL = reader.GetString("BOEMPL");
	this.BOTICK = reader.GetDecimal("BOTICK");
	this.BOA7 = reader.GetString("BOA7");
	this.BOSGRP = reader.GetString("BOSGRP");
	this.BOMAJG = reader.GetString("BOMAJG");
	this.BOFSYY = reader.GetDecimal("BOFSYY");
	this.BOFSPP = reader.GetDecimal("BOFSPP");
	this.BOBTCH = reader.GetDecimal("BOBTCH");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.BOBID = reader.GetDecimal("BOBID#");
	else
		this.BOBID = reader.GetDecimal("BOBID");
}
public override
void write(){
	try{
		string sql = "insert into scrap values(" +
                NumberUtil.toString(BOTRAN) + ", '" +
	            Converter.fixString(BOREAS) + "', '" +
				DateUtil.getDateRepresentation(BODATE) + "', '" +
                Converter.fixString(BOSHFT) + "', '" +
                Converter.fixString(BODEPT) + "', '" +
                Converter.fixString(BORESC) + "', '" +
                Converter.fixString(BOPART) + "', '" +
                Converter.fixString(BOWORK) + "', " +
                NumberUtil.toString(BOSEQN) + ", '" +
                Converter.fixString(BOLOT) + "', " +
                NumberUtil.toString(BOQTYS) + ", '" +
                Converter.fixString(BOUNIT) + "', '" +
                Converter.fixString(BOEDEP) + "', '" +
                Converter.fixString(BOEMPL) + "', " +
                NumberUtil.toString(BOTICK) + ", '" +
                Converter.fixString(BOA7) + "', '" +
                Converter.fixString(BOSGRP) + "', '" +
                Converter.fixString(BOMAJG) + "', " +
                NumberUtil.toString(BOFSYY) + ", " +
                NumberUtil.toString(BOFSPP) + ", " +
                NumberUtil.toString(BOBTCH) + ", " +
                NumberUtil.toString(BOBID) + ")";
	        dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}
public override
void update(){
	throw new PersistenceException("Method not implemented");
}
public override
void delete(){
	throw new PersistenceException("Method not implemented");
}
public
void setBOTRAN(decimal BOTRAN){
	this.BOTRAN = BOTRAN;
}
public
void setBOREAS(string BOREAS){
	this.BOREAS = BOREAS;
}
public
void setBODATE(DateTime BODATE){
	this.BODATE = BODATE;
}
public
void setBOSHFT(string BOSHFT){
	this.BOSHFT = BOSHFT;
}
public
void setBODEPT(string BODEPT){
	this.BODEPT = BODEPT;
}
public
void setBORESC(string BORESC){
	this.BORESC = BORESC;
}
public
void setBOPART(string BOPART){
	this.BOPART = BOPART;
}
public
void setBOWORK(string BOWORK){
	this.BOWORK = BOWORK;
}
public
void setBOSEQN(decimal BOSEQN){
	this.BOSEQN = BOSEQN;
}
public
void setBOLOT(string BOLOT){
	this.BOLOT = BOLOT;
}
public
void setBOQTYS(decimal BOQTYS){
	this.BOQTYS = BOQTYS;
}
public
void setBOUNIT(string BOUNIT){
	this.BOUNIT = BOUNIT;
}
public
void setBOEDEP(string BOEDEP){
	this.BOEDEP = BOEDEP;
}
public
void setBOEMPL(string BOEMPL){
	this.BOEMPL = BOEMPL;
}
public
void setBOTICK(decimal BOTICK){
	this.BOTICK = BOTICK;
}
public
void setBOA7(string BOA7){
	this.BOA7 = BOA7;
}
public
void setBOSGRP(string BOSGRP){
	this.BOSGRP = BOSGRP;
}
public
void setBOMAJG(string BOMAJG){
	this.BOMAJG = BOMAJG;
}
public
void setBOFSYY(decimal BOFSYY){
	this.BOFSYY = BOFSYY;
}
public
void setBOFSPP(decimal BOFSPP){
	this.BOFSPP = BOFSPP;
}
public
void setBOBTCH(decimal BOBTCH){
	this.BOBTCH = BOBTCH;
}
public
void setBOBID(decimal BOBID){
	this.BOBID = BOBID;
}
public
decimal getBOTRAN(){
	return BOTRAN;
}
public
string getBOREAS(){
	return BOREAS;
}
public
DateTime getBODATE(){
	return BODATE;
}
public
string getBOSHFT(){
	return BOSHFT;
}
public
string getBODEPT(){
	return BODEPT;
}
public
string getBORESC(){
	return BORESC;
}
public
string getBOPART(){
	return BOPART;
}
public
string getBOWORK(){
	return BOWORK;
}
public
decimal getBOSEQN(){
	return BOSEQN;
}
public
string getBOLOT(){
	return BOLOT;
}
public
decimal getBOQTYS(){
	return BOQTYS;
}
public
string getBOUNIT(){
	return BOUNIT;
}
public
string getBOEDEP(){
	return BOEDEP;
}
public
string getBOEMPL(){
	return BOEMPL;
}
public
decimal getBOTICK(){
	return BOTICK;
}
public
string getBOA7(){
	return BOA7;
}
public
string getBOSGRP(){
	return BOSGRP;
}
public
string getBOMAJG(){
	return BOMAJG;
}
public
decimal getBOFSYY(){
	return BOFSYY;
}
public
decimal getBOFSPP(){
	return BOFSPP;
}
public
decimal getBOBTCH(){
	return BOBTCH;
}
public
decimal getBOBID(){
	return BOBID;
}
}//end class
}//end namespace
