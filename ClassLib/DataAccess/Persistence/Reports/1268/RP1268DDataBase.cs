/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Reports{

    public
class RP1268DDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string Part;
private decimal RTPart;
private decimal Part10;
private decimal Part20;
private decimal Part30;
private decimal Part40;
private decimal Part50;
private decimal Part60;
private decimal Part70;
private decimal Part80;
private decimal Part90;
private decimal Part100;
private decimal Part110;
private decimal Part120;
private decimal Part130;
private decimal Part140;
private decimal Part150;
private decimal Part160;
private decimal QtyHold;
private decimal FinGood;
private decimal NetQoh;
private decimal CDPast;
private decimal CDWeek1;
private decimal CDWeek2;
private decimal CDWeek3;
private decimal CDWeek4;
private decimal CDWeek5;
private decimal CDWeek6;
private decimal CDWeek7;
private decimal CDWeek8;

private decimal CDWeek9;
private decimal CDWeek10;
private decimal CDWeek11;
private decimal CDWeek12;
private decimal CDWeek13;
private decimal CDWeek14;

private string AVMAJG;
private string AVMING;
private string ENGCHANGE;
private decimal QTYG12;

public
RP1268DDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix3() + "rp1268d where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix3() + "rp1268d where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Part = reader.GetString("Part");
	this.RTPart = reader.GetDecimal("RTPart");
	this.Part10 = reader.GetDecimal("Part10");
	this.Part20 = reader.GetDecimal("Part20");
	this.Part30 = reader.GetDecimal("Part30");
	this.Part40 = reader.GetDecimal("Part40");
	this.Part50 = reader.GetDecimal("Part50");
	this.Part60 = reader.GetDecimal("Part60");
	this.Part70 = reader.GetDecimal("Part70");
	this.Part80 = reader.GetDecimal("Part80");
	this.Part90 = reader.GetDecimal("Part90");
	this.Part100 = reader.GetDecimal("Part100");
	this.Part110 = reader.GetDecimal("Part110");
	this.Part120 = reader.GetDecimal("Part120");
	this.Part130 = reader.GetDecimal("Part130");
	this.Part140 = reader.GetDecimal("Part140");
	this.Part150 = reader.GetDecimal("Part150");
	this.Part160 = reader.GetDecimal("Part160");
	this.QtyHold = reader.GetDecimal("QtyHold");
	this.FinGood = reader.GetDecimal("FinGood");
	this.NetQoh = reader.GetDecimal("NetQoh");
	this.CDPast = reader.GetDecimal("CDPast");
	this.CDWeek1 = reader.GetDecimal("CDWeek1");
	this.CDWeek2 = reader.GetDecimal("CDWeek2");
	this.CDWeek3 = reader.GetDecimal("CDWeek3");
	this.CDWeek4 = reader.GetDecimal("CDWeek4");
	this.CDWeek5 = reader.GetDecimal("CDWeek5");
	this.CDWeek6 = reader.GetDecimal("CDWeek6");
	this.CDWeek7 = reader.GetDecimal("CDWeek7");
	this.CDWeek8 = reader.GetDecimal("CDWeek8");

    this.CDWeek9 = reader.GetDecimal("CDWeek9");
	this.CDWeek10 = reader.GetDecimal("CDWeek10");
	this.CDWeek11 = reader.GetDecimal("CDWeek11");
	this.CDWeek12 = reader.GetDecimal("CDWeek12");
	this.CDWeek13 = reader.GetDecimal("CDWeek13");
	this.CDWeek14 = reader.GetDecimal("CDWeek14");

    this.AVMAJG = reader.GetString("AVMAJG");
    this.AVMING = reader.GetString("AVMING");

    this.ENGCHANGE = reader.GetString("ENGCHANGE");    
    this.QTYG12 = reader.GetDecimal("QTYG12");
}

public override
void write(){
   
	string sql = "insert into " + getTablePrefix3() + "rp1268d(" + 
		"HdrId," +
		"Detail," +
		"Part," +
		"RTPart," +
		"Part10," +
		"Part20," +
		"Part30," +
		"Part40," +
		"Part50," +
		"Part60," +
		"Part70," +
		"Part80," +
		"Part90," +
		"Part100," +
		"Part110," +
		"Part120," +
		"Part130," +
		"Part140," +
		"Part150," +
		"Part160," +
		"QtyHold," +
		"FinGood," +
		"NetQoh," +
		"CDPast," +
		"CDWeek1," +
		"CDWeek2," +
		"CDWeek3," +
		"CDWeek4," +
		"CDWeek5," +
		"CDWeek6," +
		"CDWeek7," +
        "CDWeek8," +
        "CDWeek9," +
        "CDWeek10," +
        "CDWeek11," +
        "CDWeek12," +
        "CDWeek13," +
        "CDWeek14," +

        "AVMAJG," +
        "AVMING," +
        "ENGCHANGE," +        
        "QTYG12"+
            ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(RTPart,10,2) + "," +
		"" + NumberUtil.toString(Part10,10,2) + "," +
		"" + NumberUtil.toString(Part20,10,2) + "," +
		"" + NumberUtil.toString(Part30,10,2) + "," +
		"" + NumberUtil.toString(Part40,10,2) + "," +
		"" + NumberUtil.toString(Part50,10,2) + "," +
		"" + NumberUtil.toString(Part60,10,2) + "," +
		"" + NumberUtil.toString(Part70,10,2) + "," +
		"" + NumberUtil.toString(Part80,10,2) + "," +
		"" + NumberUtil.toString(Part90,10,2) + "," +
		"" + NumberUtil.toString(Part100,10,2) + "," +
		"" + NumberUtil.toString(Part110,10,2) + "," +
		"" + NumberUtil.toString(Part120,10,2) + "," +
		"" + NumberUtil.toString(Part130,10,2) + "," +
		"" + NumberUtil.toString(Part140,10,2) + "," +
		"" + NumberUtil.toString(Part150,10,2) + "," +
		"" + NumberUtil.toString(Part160,10,2) + "," +
		"" + NumberUtil.toString(QtyHold,10,2) + "," +
		"" + NumberUtil.toString(FinGood,10,2) + "," +
		"" + NumberUtil.toString(NetQoh,10,2) + "," +
		"" + NumberUtil.toString(CDPast,10,2) + "," +
		"" + NumberUtil.toString(CDWeek1,10,2) + "," +
		"" + NumberUtil.toString(CDWeek2,10,2) + "," +
		"" + NumberUtil.toString(CDWeek3,10,2) + "," +
		"" + NumberUtil.toString(CDWeek4,10,2) + "," +
		"" + NumberUtil.toString(CDWeek5,10,2) + "," +
		"" + NumberUtil.toString(CDWeek6,10,2) + "," +
		"" + NumberUtil.toString(CDWeek7,10,2) + "," +
		"" + NumberUtil.toString(CDWeek8,10,2) + "," +
		"" + NumberUtil.toString(CDWeek9,10,2) + "," +
		"" + NumberUtil.toString(CDWeek10,10,2) + "," +
		"" + NumberUtil.toString(CDWeek11,10,2) + "," +
		"" + NumberUtil.toString(CDWeek12,10,2) + "," +
		"" + NumberUtil.toString(CDWeek13,10,2) + "," +
		"" + NumberUtil.toString(CDWeek14,10,2) + "," +
        "'" + Converter.fixString(AVMAJG) + "'," +
        "'" + Converter.fixString(AVMING) + "'," +
        "'" + Converter.fixString(ENGCHANGE) + "'," +        
        "" + NumberUtil.toString(QTYG12,10,2) + ")";
 
    try{
        //System.Windows.Forms.MessageBox.Show("write rp1268d : " + sql);
        write(sql);
    }catch(Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)
            System.Windows.Forms.MessageBox.Show("write rp1268d error: " + ex.Message);
    }
}

public override
void update(){
	string sql = "update " + getTablePrefix3() + "rp1268d set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"RTPart = " + NumberUtil.toString(RTPart) + ", " +
		"Part10 = " + NumberUtil.toString(Part10) + ", " +
		"Part20 = " + NumberUtil.toString(Part20) + ", " +
		"Part30 = " + NumberUtil.toString(Part30) + ", " +
		"Part40 = " + NumberUtil.toString(Part40) + ", " +
		"Part50 = " + NumberUtil.toString(Part50) + ", " +
		"Part60 = " + NumberUtil.toString(Part60) + ", " +
		"Part70 = " + NumberUtil.toString(Part70) + ", " +
		"Part80 = " + NumberUtil.toString(Part80) + ", " +
		"Part90 = " + NumberUtil.toString(Part90) + ", " +
		"Part100 = " + NumberUtil.toString(Part100) + ", " +
		"Part110 = " + NumberUtil.toString(Part110) + ", " +
		"Part120 = " + NumberUtil.toString(Part120) + ", " +
		"Part130 = " + NumberUtil.toString(Part130) + ", " +
		"Part140 = " + NumberUtil.toString(Part140) + ", " +
		"Part150 = " + NumberUtil.toString(Part150) + ", " +
		"Part160 = " + NumberUtil.toString(Part160) + ", " +
		"QtyHold = " + NumberUtil.toString(QtyHold) + ", " +
		"FinGood = " + NumberUtil.toString(FinGood) + ", " +
		"NetQoh = " + NumberUtil.toString(NetQoh) + ", " +
		"CDPast = " + NumberUtil.toString(CDPast) + ", " +
		"CDWeek1 = " + NumberUtil.toString(CDWeek1) + ", " +
		"CDWeek2 = " + NumberUtil.toString(CDWeek2) + ", " +
		"CDWeek3 = " + NumberUtil.toString(CDWeek3) + ", " +
		"CDWeek4 = " + NumberUtil.toString(CDWeek4) + ", " +
		"CDWeek5 = " + NumberUtil.toString(CDWeek5) + ", " +
		"CDWeek6 = " + NumberUtil.toString(CDWeek6) + ", " +
		"CDWeek7 = " + NumberUtil.toString(CDWeek7) + ", " +
        "CDWeek8 = " + NumberUtil.toString(CDWeek8) + ", " +
        "CDWeek9 = " + NumberUtil.toString(CDWeek9) + ", " +
        "CDWeek10 = " + NumberUtil.toString(CDWeek10) + ", " +
        "CDWeek11 = " + NumberUtil.toString(CDWeek11) + ", " +
        "CDWeek12 = " + NumberUtil.toString(CDWeek12) + ", " +
        "CDWeek13 = " + NumberUtil.toString(CDWeek13) + ", " +
        "CDWeek14 = " + NumberUtil.toString(CDWeek14) + ", " +
        "AVMAJG = '" + Converter.fixString(AVMAJG) + "', " +
        "AVMING = '" + Converter.fixString(AVMING) + "', " +
        "ENGCHANGE = '" + Converter.fixString(ENGCHANGE) + "', " +        
        "QTYG12 = " + NumberUtil.toString(QTYG12) + " " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rp1268d where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + "";
	return sqlWhere;
}

public
void setHdrId(int HdrId){
	this.HdrId = HdrId;
}

public
void setDetail(int Detail){
	this.Detail = Detail;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setRTPart(decimal RTPart){
	this.RTPart = RTPart;
}

public
void setPart10(decimal Part10){
	this.Part10 = Part10;
}

public
void setPart20(decimal Part20){
	this.Part20 = Part20;
}

public
void setPart30(decimal Part30){
	this.Part30 = Part30;
}

public
void setPart40(decimal Part40){
	this.Part40 = Part40;
}

public
void setPart50(decimal Part50){
	this.Part50 = Part50;
}

public
void setPart60(decimal Part60){
	this.Part60 = Part60;
}

public
void setPart70(decimal Part70){
	this.Part70 = Part70;
}

public
void setPart80(decimal Part80){
	this.Part80 = Part80;
}

public
void setPart90(decimal Part90){
	this.Part90 = Part90;
}

public
void setPart100(decimal Part100){
	this.Part100 = Part100;
}

public
void setPart110(decimal Part110){
	this.Part110 = Part110;
}

public
void setPart120(decimal Part120){
	this.Part120 = Part120;
}

public
void setPart130(decimal Part130){
	this.Part130 = Part130;
}

public
void setPart140(decimal Part140){
	this.Part140 = Part140;
}

public
void setPart150(decimal Part150){
	this.Part150 = Part150;
}

public
void setPart160(decimal Part160){
	this.Part160 = Part160;
}

public
void setQtyHold(decimal QtyHold){
	this.QtyHold = QtyHold;
}

public
void setFinGood(decimal FinGood){
	this.FinGood = FinGood;
}

public
void setNetQoh(decimal NetQoh){
	this.NetQoh = NetQoh;
}

public
void setCDPast(decimal CDPast){
	this.CDPast = CDPast;
}

public
void setCDWeek1(decimal CDWeek1){
	this.CDWeek1 = CDWeek1;
}

public
void setCDWeek2(decimal CDWeek2){
	this.CDWeek2 = CDWeek2;
}

public
void setCDWeek3(decimal CDWeek3){
	this.CDWeek3 = CDWeek3;
}

public
void setCDWeek4(decimal CDWeek4){
	this.CDWeek4 = CDWeek4;
}

public
void setCDWeek5(decimal CDWeek5){
	this.CDWeek5 = CDWeek5;
}

public
void setCDWeek6(decimal CDWeek6){
	this.CDWeek6 = CDWeek6;
}

public
void setCDWeek7(decimal CDWeek7){
	this.CDWeek7 = CDWeek7;
}

public
void setCDWeek8(decimal CDWeek8){
	this.CDWeek8 = CDWeek8;
}

public
void setCDWeek9(decimal CDWeek9){
	this.CDWeek9 = CDWeek9;
}

public
void setCDWeek10(decimal CDWeek10){
	this.CDWeek10 = CDWeek10;
}

public
void setCDWeek11(decimal CDWeek11){
	this.CDWeek11 = CDWeek11;
}

public
void setCDWeek12(decimal CDWeek12){
	this.CDWeek12 = CDWeek12;
}

public
void setCDWeek13(decimal CDWeek13){
	this.CDWeek13 = CDWeek13;
}

public
void setCDWeek14(decimal CDWeek14){
	this.CDWeek14 = CDWeek14;
}

public
void setAVMAJG(string AVMAJG){
	this.AVMAJG = AVMAJG;
}

public
void setAVMING(string AVMING){
	this.AVMING = AVMING;
}

public
void setENGCHANGE(string ENGCHANGE){
	this.ENGCHANGE = ENGCHANGE;
}

public
void setQTYG12(decimal QTYG12){
    this.QTYG12 = QTYG12;
}
      
public
int getHdrId(){
	return HdrId;
}

public
int getDetail(){
	return Detail;
}

public
string getPart(){
	return Part;
}

public
decimal getRTPart(){
	return RTPart;
}

public
decimal getPart10(){
	return Part10;
}

public
decimal getPart20(){
	return Part20;
}

public
decimal getPart30(){
	return Part30;
}

public
decimal getPart40(){
	return Part40;
}

public
decimal getPart50(){
	return Part50;
}

public
decimal getPart60(){
	return Part60;
}

public
decimal getPart70(){
	return Part70;
}

public
decimal getPart80(){
	return Part80;
}

public
decimal getPart90(){
	return Part90;
}

public
decimal getPart100(){
	return Part100;
}

public
decimal getPart110(){
	return Part110;
}

public
decimal getPart120(){
	return Part120;
}

public
decimal getPart130(){
	return Part130;
}

public
decimal getPart140(){
	return Part140;
}

public
decimal getPart150(){
	return Part150;
}

public
decimal getPart160(){
	return Part160;
}

public
decimal getQtyHold(){
	return QtyHold;
}

public
decimal getFinGood(){
	return FinGood;
}

public
decimal getNetQoh(){
	return NetQoh;
}

public
decimal getCDPast(){
	return CDPast;
}

public
decimal getCDWeek1(){
	return CDWeek1;
}

public
decimal getCDWeek2(){
	return CDWeek2;
}

public
decimal getCDWeek3(){
	return CDWeek3;
}

public
decimal getCDWeek4(){
	return CDWeek4;
}

public
decimal getCDWeek5(){
	return CDWeek5;
}

public
decimal getCDWeek6(){
	return CDWeek6;
}

public
decimal getCDWeek7(){
	return CDWeek7;
}

public
decimal getCDWeek8(){
	return CDWeek8;
}

public
decimal getCDWeek9(){
	return CDWeek9;
}

public
decimal getCDWeek10(){
	return CDWeek10;
}

public
decimal getCDWeek11(){
	return CDWeek11;
}

public
decimal getCDWeek12(){
	return CDWeek12;
}

public
decimal getCDWeek13(){
	return CDWeek13;
}

public
decimal getCDWeek14(){
	return CDWeek14;
}

public
string getAVMAJG(){
    return AVMAJG;
}

public
string getAVMING(){
	return AVMING;
}

public
string getENGCHANGE(){
    return ENGCHANGE;
}

public
decimal getQTYG12(){
    return QTYG12;
}

} // class
} // package