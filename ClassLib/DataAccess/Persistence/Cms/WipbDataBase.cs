using System;
using MySql.Data;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public 
class WipbDataBase : GenericDataBaseElement{

private string VDPART;
private decimal VDSEQ;
private string VDLOT;
private string VDSTOK;
private string VDJOB;
private decimal VDQTOH;
private decimal VDQTAL;
private DateTime VDDATE;
private string VDPLNT;

public
WipbDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.VDPART = reader.GetString(0);
	this.VDSEQ = reader.GetDecimal(1);
	this.VDLOT = reader.GetString(2);
	this.VDSTOK = reader.GetString(3);
	this.VDJOB = reader.GetString(4);
	this.VDQTOH = reader.GetDecimal(5);
	this.VDQTAL = reader.GetDecimal(6);
	this.VDDATE = reader.GetDateTime(7);
    this.VDPLNT = reader.GetString("VDPLNT");
}

public override
void write(){
	string sql = "insert into wipb values('" +
		Converter.fixString(VDPART) + "', " +
		VDSEQ + ", '" +
		Converter.fixString(VDLOT) + "', '" +
		Converter.fixString(VDSTOK) + "', '" +
		Converter.fixString(VDJOB) + "', " +
		VDQTOH + ", " +
		VDQTAL + ", '" +
		DateUtil.getCompleteDateRepresentation(VDDATE) + "', '" +
        VDPLNT + "')";
            
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
void setVDPART(string VDPART){
	this.VDPART = VDPART;
}

public
void setVDSEQ(decimal VDSEQ){
	this.VDSEQ = VDSEQ;
}

public
void setVDLOT(string VDLOT){
	this.VDLOT = VDLOT;
}

public
void setVDSTOK(string VDSTOK){
	this.VDSTOK = VDSTOK;
}

public
void setVDJOB(string VDJOB){
	this.VDJOB = VDJOB;
}

public
void setVDQTOH(decimal VDQTOH){
	this.VDQTOH = VDQTOH;
}

public
void setVDQTAL(decimal VDQTAL){
	this.VDQTAL = VDQTAL;
}

public
void setVDDATE(DateTime VDDATE){
	this.VDDATE = VDDATE;
}

public
void setVDPLNT(string VDPLNT){
	this.VDPLNT = VDPLNT;
}

public
string getVDPART(){
	return VDPART;
}

public
decimal getVDSEQ(){
	return VDSEQ;
}

public
string getVDLOT(){
	return VDLOT;
}

public
string getVDSTOK(){
	return VDSTOK;
}

public
string getVDJOB(){
	return VDJOB;
}

public
decimal getVDQTOH(){
	return VDQTOH;
}

public
decimal getVDQTAL(){
	return VDQTAL;
}

public
DateTime getVDDATE(){
	return VDDATE;
}

public
string getVDPLNT(){
	return VDPLNT;
}



}

}