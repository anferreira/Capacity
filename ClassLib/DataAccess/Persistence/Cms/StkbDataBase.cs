using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkbDataBase : GenericDataBaseElement{

private string BXPART;
private string BXLOT;
private string BXSTOK;
private decimal BXQTOH;
private decimal BXQTAL;
private decimal BXMNQT;
private decimal BXMXQT;
private decimal BXQTOD;
private DateTime BXPDAT;
private string BXCCGP;
private decimal BXQTSO;
private string BXUNIT; //new 2019-09-24
private string BXPLNT; //new 2020-04-01

public
StkbDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
    this.BXPART = reader.GetString("BXPART");
    this.BXLOT = reader.GetString("BXLOT");
    this.BXSTOK = reader.GetString("BXSTOK");
    this.BXQTOH = reader.GetDecimal("BXQTOH");
    this.BXQTAL = reader.GetDecimal("BXQTAL");
    this.BXMNQT = reader.GetDecimal("BXMNQT");
    this.BXMXQT = reader.GetDecimal("BXMXQT");
    this.BXQTOD = reader.GetDecimal("BXQTOD");
    this.BXPDAT = reader.GetDateTime("BXPDAT");
    this.BXCCGP = reader.GetString("BXCCGP");
    this.BXQTSO = reader.GetDecimal("BXQTSO");
    this.BXUNIT = reader.GetString("BXUNIT");
    this.BXPLNT = reader.GetString("BXPLNT");
}

public override
void write(){
    string sql = "insert into stkb values('" +
        Converter.fixString(BXPART) + "', '" +
        Converter.fixString(BXLOT) + "', '" +
        Converter.fixString(BXSTOK) + "', " +
        NumberUtil.toString(BXQTOH) + ", " +
        NumberUtil.toString(BXQTAL) + ", " +
        NumberUtil.toString(BXMNQT) + ", " +
        NumberUtil.toString(BXMXQT) + ", " +
        NumberUtil.toString(BXQTOD) + ", '" +
        DateUtil.getCompleteDateRepresentation(BXPDAT) + "', '" +
        Converter.fixString(BXCCGP) + "', " +
        NumberUtil.toString(BXQTSO) + ", '" +
        Converter.fixString(BXPLNT) + "')";
    write(sql);
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
void setBXPART(string BXPART){
	this.BXPART = BXPART;
}

public
void setBXLOT(string BXLOT){
	this.BXLOT = BXLOT;
}

public
void setBXSTOK(string BXSTOK){
	this.BXSTOK = BXSTOK;
}

public
void setBXQTOH(decimal BXQTOH){
	this.BXQTOH = BXQTOH;
}

public
void setBXQTAL(decimal BXQTAL){
	this.BXQTAL = BXQTAL;
}

public
void setBXMNQT(decimal BXMNQT){
	this.BXMNQT = BXMNQT;
}

public
void setBXMXQT(decimal BXMXQT){
	this.BXMXQT = BXMXQT;
}

public
void setBXQTOD(decimal BXQTOD){
	this.BXQTOD = BXQTOD;
}

public
void setBXPDAT(DateTime BXPDAT){
	this.BXPDAT = BXPDAT;
}

public
void setBXCCGP(string BXCCGP){
	this.BXCCGP = BXCCGP;
}

public
void setBXQTSO(decimal BXQTSO){
	this.BXQTSO = BXQTSO;
}

public
void setBXUNIT(string BXUNIT){
	this.BXUNIT = BXUNIT;
}

public
void setBXPLNT(string BXPLNT){
	this.BXPLNT = BXPLNT;
}        

public
string getBXPART(){
	return BXPART;
}

public
string getBXLOT(){
	return BXLOT;
}

public
string getBXSTOK(){
	return BXSTOK;
}

public
decimal getBXQTOH(){
	return BXQTOH;
}

public
decimal getBXQTAL(){
	return BXQTAL;
}

public
decimal getBXMNQT(){
	return BXMNQT;
}

public
decimal getBXMXQT(){
	return BXMXQT;
}

public
decimal getBXQTOD(){
	return BXQTOD;
}

public
DateTime getBXPDAT(){
	return BXPDAT;
}

public
string getBXCCGP(){
	return BXCCGP;
}

public
decimal getBXQTSO(){
	return BXQTSO;
}

public
string getBXUNIT(){
	return BXUNIT;
}

public
string getBXPLNT(){
    return BXPLNT;
}   

} // class

} // namespace