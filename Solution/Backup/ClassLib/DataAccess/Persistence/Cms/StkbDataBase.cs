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
}

public override
void write(){
	try{
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
			NumberUtil.toString(BXQTSO) + ")";

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

} // class

} // namespace