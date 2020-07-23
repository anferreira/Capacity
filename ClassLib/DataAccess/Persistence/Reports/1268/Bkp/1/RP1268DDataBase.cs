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
		"CDWeek8" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(RTPart) + "," +
		"" + NumberUtil.toString(Part10) + "," +
		"" + NumberUtil.toString(Part20) + "," +
		"" + NumberUtil.toString(Part30) + "," +
		"" + NumberUtil.toString(Part40) + "," +
		"" + NumberUtil.toString(Part50) + "," +
		"" + NumberUtil.toString(Part60) + "," +
		"" + NumberUtil.toString(Part70) + "," +
		"" + NumberUtil.toString(Part80) + "," +
		"" + NumberUtil.toString(Part90) + "," +
		"" + NumberUtil.toString(Part100) + "," +
		"" + NumberUtil.toString(Part110) + "," +
		"" + NumberUtil.toString(Part120) + "," +
		"" + NumberUtil.toString(Part130) + "," +
		"" + NumberUtil.toString(Part140) + "," +
		"" + NumberUtil.toString(Part150) + "," +
		"" + NumberUtil.toString(Part160) + "," +
		"" + NumberUtil.toString(QtyHold) + "," +
		"" + NumberUtil.toString(FinGood) + "," +
		"" + NumberUtil.toString(NetQoh) + "," +
		"" + NumberUtil.toString(CDPast) + "," +
		"" + NumberUtil.toString(CDWeek1) + "," +
		"" + NumberUtil.toString(CDWeek2) + "," +
		"" + NumberUtil.toString(CDWeek3) + "," +
		"" + NumberUtil.toString(CDWeek4) + "," +
		"" + NumberUtil.toString(CDWeek5) + "," +
		"" + NumberUtil.toString(CDWeek6) + "," +
		"" + NumberUtil.toString(CDWeek7) + "," +
		"" + NumberUtil.toString(CDWeek8) + ")";
    System.Windows.Forms.MessageBox.Show(sql);
	write(sql);	
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
		"CDWeek8 = " + NumberUtil.toString(CDWeek8) + " " +

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

} // class
} // package