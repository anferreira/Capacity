/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class RacaDataBase : GenericDataBaseElement {

private decimal QFENT;
private decimal QFCKEY;
private DateTime QFSDAT;
private decimal QFSTIM;
private decimal QFPCUM;
private decimal QFNCUM;
private decimal QFADJQ;
private string QFREAS;

public
RacaDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix() + "raca where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix() + "raca where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.QFENT = reader.GetDecimal(getFieldDigit("QFENT"));
	this.QFCKEY = reader.GetDecimal("QFCKEY");
	this.QFSDAT = reader.GetDateTime("QFSDAT");
	this.QFSTIM = reader.GetDecimal("QFSTIM");
	this.QFPCUM = reader.GetDecimal("QFPCUM");
	this.QFNCUM = reader.GetDecimal("QFNCUM");
	this.QFADJQ = reader.GetDecimal("QFADJQ");
	this.QFREAS = reader.GetString("QFREAS");
}

public override
void write(){
	string sql = "insert into " + getTablePrefix() + "raca(" +
        getFieldDigit("QFENT")+ "," +
		"QFCKEY," +
		"QFSDAT," +
		"QFSTIM," +
		"QFPCUM," +
		"QFNCUM," +
		"QFADJQ," +
		"QFREAS" +

		") values (" + 

		"" + NumberUtil.toString(QFENT) + "," +
		"" + NumberUtil.toString(QFCKEY) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(QFSDAT) + "'," +
		"" + NumberUtil.toString(QFSTIM) + "," +
		"" + NumberUtil.toString(QFPCUM) + "," +
		"" + NumberUtil.toString(QFNCUM) + "," +
		"" + NumberUtil.toString(QFADJQ) + "," +
		"'" + Converter.fixString(QFREAS) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update " + getTablePrefix() + "raca set " +
        getFieldDigit("QFENT") + "= " + NumberUtil.toString(QFENT) + ", " +
		"QFCKEY = " + NumberUtil.toString(QFCKEY) + ", " +
		"QFSDAT = '" + DateUtil.getCompleteDateRepresentation(QFSDAT) + "', " +
		"QFSTIM = " + NumberUtil.toString(QFSTIM) + ", " +
		"QFPCUM = " + NumberUtil.toString(QFPCUM) + ", " +
		"QFNCUM = " + NumberUtil.toString(QFNCUM) + ", " +
		"QFADJQ = " + NumberUtil.toString(QFADJQ) + ", " +
		"QFREAS = '" + Converter.fixString(QFREAS) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from raca where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"QFENT = " + NumberUtil.toString(QFENT) + "";
	return sqlWhere;
}

public
void setQFENT(decimal QFENT){
	this.QFENT = QFENT;
}

public
void setQFCKEY(decimal QFCKEY){
	this.QFCKEY = QFCKEY;
}

public
void setQFSDAT(DateTime QFSDAT){
	this.QFSDAT = QFSDAT;
}

public
void setQFSTIM(decimal QFSTIM){
	this.QFSTIM = QFSTIM;
}

public
void setQFPCUM(decimal QFPCUM){
	this.QFPCUM = QFPCUM;
}

public
void setQFNCUM(decimal QFNCUM){
	this.QFNCUM = QFNCUM;
}

public
void setQFADJQ(decimal QFADJQ){
	this.QFADJQ = QFADJQ;
}

public
void setQFREAS(string QFREAS){
	this.QFREAS = QFREAS;
}

public
decimal getQFENT(){
	return QFENT;
}

public
decimal getQFCKEY(){
	return QFCKEY;
}

public
DateTime getQFSDAT(){
	return QFSDAT;
}

public
decimal getQFSTIM(){
	return QFSTIM;
}

public
decimal getQFPCUM(){
	return QFPCUM;
}

public
decimal getQFNCUM(){
	return QFNCUM;
}

public
decimal getQFADJQ(){
	return QFADJQ;
}

public
string getQFREAS(){
	return QFREAS;
}

} // class
} // package