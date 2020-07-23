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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemandDDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string Source;
private string TPartner;
private DateTime RelDate;
private string RelNum;
private string BillTo;
private string ShipTo;
private string ShipLoc;
private decimal ShipLTim;
private string ShipLTUn;
private string Part;
private string CustPart;
private decimal CurrCum;
private decimal FaAutCum;
private decimal MaAutCum;
private string CurShDoc;
private DateTime SDate;
private DateTime EndDate;
private decimal QtyCum;
private decimal AdjNQty;
private decimal NetQty;
private string TimeCode;
private decimal TrlpKeyId;
private string Discard;
private decimal LogNum;

public
DemandDDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
    string sql = "select * from " + getTablePrefix2() + "demandd where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
    string sql = "select * from " + getTablePrefix2() + "demandd where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Source = reader.GetString("Source");
	this.TPartner = reader.GetString("TPartner");
	this.RelDate = reader.GetDateTime("RelDate");
	this.RelNum = reader.GetString("RelNum");
	this.BillTo = reader.GetString("BillTo");
	this.ShipTo = reader.GetString("ShipTo");
	this.ShipLoc = reader.GetString("ShipLoc");
	this.ShipLTim = reader.GetDecimal("ShipLTim");
	this.ShipLTUn = reader.GetString("ShipLTUn");
	this.Part = reader.GetString("Part");
	this.CustPart = reader.GetString("CustPart");
	this.CurrCum = reader.GetDecimal("CurrCum");
	this.FaAutCum = reader.GetDecimal("FaAutCum");
	this.MaAutCum = reader.GetDecimal("MaAutCum");
	this.CurShDoc = reader.GetString("CurShDoc");
	this.SDate = reader.GetDateTime("SDate");
	this.EndDate = reader.GetDateTime("EndDate");
	this.QtyCum = reader.GetDecimal("QtyCum");
	this.AdjNQty = reader.GetDecimal("AdjNQty");
    this.NetQty = reader.GetDecimal("NetQty");
    this.TimeCode = reader.GetString("TimeCode");
    this.TrlpKeyId = reader.GetDecimal("TrlpKeyId");
    this.Discard = reader.GetString("Discard");
    try { this.LogNum = reader.GetDecimal("LogNum"); } catch { LogNum =0; };
}

public override
void write(){    
    string sql = "insert into " + getTablePrefix2() + "demandd(" +
        "HdrId," +
		"Detail," +
		"Source," +
		"TPartner," +
		"RelDate," +
		"RelNum," +

		"BillTo," +
		"ShipTo," +
		"ShipLoc," +

		"ShipLTim," +
		"ShipLTUn," +
		"Part," +
		"CustPart," +

		"CurrCum," +
		"FaAutCum," +
		"MaAutCum," +

		"CurShDoc," +
		"SDate," +
		"EndDate," +

		"QtyCum," +
		"AdjNQty," +
        "NetQty," +
        "TimeCode," +
        "TrlpKeyId,"+
        "Discard" +
        

        ") values (" +

        "" + Convert.ToInt64(HdrId).ToString() + "," +
		"" + Convert.ToInt32(Detail).ToString() + "," +
		"'" + Converter.fixString(Source) + "'," +
		"'" + Converter.fixString(TPartner) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(RelDate) + "'," +
		"'" + Converter.fixString(RelNum) + "'," +

		"'" + Converter.fixString(BillTo) + "'," +
		"'" + Converter.fixString(ShipTo) + "'," +
		"'" + Converter.fixString(ShipLoc) + "'," +

		"" + NumberUtil.toString(ShipLTim) + "," +
		"'" + Converter.fixString(ShipLTUn) + "'," +
		"'" + Converter.fixString(Part) + "'," +
		"'" + Converter.fixString(CustPart) + "'," +

        "" + Convert.ToInt64(CurrCum).ToString() + "," +
        "" + Convert.ToInt64(FaAutCum).ToString() + "," +
        "" + Convert.ToInt64(MaAutCum).ToString() + "," +

		"'" + Converter.fixString(CurShDoc) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(SDate) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(EndDate) + "'," +

        "" + Convert.ToInt64(QtyCum).ToString() + "," +
        "" + Convert.ToInt64(AdjNQty).ToString() + "," +
        "" + Convert.ToInt64(NetQty).ToString() + "," +        
        "'" + Converter.fixString(TimeCode) + "'," +
        "" + Convert.ToInt64(TrlpKeyId).ToString() + "," +
        "'" + Converter.fixString(Discard) + "')";
            
    try{        
        write(sql);
    }catch(Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)
            System.Windows.Forms.MessageBox.Show("write demandd error: " + ex.Message);
    }	
}

public override
void update(){
    string sql = "update  " + getTablePrefix2() + "demandd set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Source = '" + Converter.fixString(Source) + "', " +
		"TPartner = '" + Converter.fixString(TPartner) + "', " +
        "RelDate = '" + DateUtil.getDateRepresentation(RelDate) + "', " +
		"RelNum = '" + Converter.fixString(RelNum) + "', " +
		"BillTo = '" + Converter.fixString(BillTo) + "', " +
		"ShipTo = '" + Converter.fixString(ShipTo) + "', " +
		"ShipLoc = '" + Converter.fixString(ShipLoc) + "', " +
		"ShipLTim = " + NumberUtil.toString(ShipLTim) + ", " +
		"ShipLTUn = '" + Converter.fixString(ShipLTUn) + "', " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"CustPart = '" + Converter.fixString(CustPart) + "', " +
		"CurrCum = " + NumberUtil.toString(CurrCum) + ", " +
		"FaAutCum = " + NumberUtil.toString(FaAutCum) + ", " +
		"MaAutCum = " + NumberUtil.toString(MaAutCum) + ", " +
		"CurShDoc = '" + Converter.fixString(CurShDoc) + "', " +
        "SDate = '" + DateUtil.getDateRepresentation(SDate) + "', " +
        "EndDate = '" + DateUtil.getDateRepresentation(EndDate) + "', " +
		"QtyCum = " + NumberUtil.toString(QtyCum) + ", " +
        "AdjNQty = " + NumberUtil.toString(AdjNQty) + ", " +
        "NetQty = " + NumberUtil.toString(NetQty) + ", " +        
        "TimeCode = '" + Converter.fixString(TimeCode) + "', " +
        "TrlpKeyId= " + NumberUtil.toString(CurrCum) + ", " +
        "Discard = '" + Converter.fixString(Discard) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
    string sql = "delete from " + getTablePrefix2() + "demandd where " + getWhereCondition();
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
void setSource(string Source){
	this.Source = Source;
}

public
void setTPartner(string TPartner){
	this.TPartner = TPartner;
}

public
void setRelDate(DateTime RelDate){
	this.RelDate = RelDate;
}

public
void setRelNum(string RelNum){
	this.RelNum = RelNum;
}

public
void setBillTo(string BillTo){
	this.BillTo = BillTo;
}

public
void setShipTo(string ShipTo){
	this.ShipTo = ShipTo;
}

public
void setShipLoc(string ShipLoc){
	this.ShipLoc = ShipLoc;
}

public
void setShipLTim(decimal ShipLTim){
	this.ShipLTim = ShipLTim;
}

public
void setShipLTUn(string ShipLTUn){
	this.ShipLTUn = ShipLTUn;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setCustPart(string CustPart){
	this.CustPart = CustPart;
}

public
void setCurrCum(decimal CurrCum){
	this.CurrCum = CurrCum;
}

public
void setFaAutCum(decimal FaAutCum){
	this.FaAutCum = FaAutCum;
}

public
void setMaAutCum(decimal MaAutCum){
	this.MaAutCum = MaAutCum;
}

public
void setCurShDoc(string CurShDoc){
	this.CurShDoc = CurShDoc;
}

public
void setSDate(DateTime SDate){
	this.SDate = SDate;
}

public
void setEndDate(DateTime EndDate){
	this.EndDate = EndDate;
}

public
void setQtyCum(decimal QtyCum){
	this.QtyCum = QtyCum;
}

public
void setAdjNQty(decimal AdjNQty){
	this.AdjNQty = AdjNQty;
}
    
public
void setNetQty(decimal NetQty){
    this.NetQty = NetQty;
}
   
public
void setTimeCode(string TimeCode){
    this.TimeCode = TimeCode;
}

public
void setTrlpKeyId(decimal TrlpKeyId){
    this.TrlpKeyId = TrlpKeyId;
}

public
void setDiscard(string Discard){
    this.Discard = Discard;
}

public
void setLogNum(decimal LogNum){
    this.LogNum = LogNum;
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
string getSource(){
	return Source;
}

public
string getTPartner(){
	return TPartner;
}

public
DateTime getRelDate(){
	return RelDate;
}

public
string getRelNum(){
	return RelNum;
}

public
string getBillTo(){
	return BillTo;
}

public
string getShipTo(){
	return ShipTo;
}

public
string getShipLoc(){
	return ShipLoc;
}

public
decimal getShipLTim(){
	return ShipLTim;
}

public
string getShipLTUn(){
	return ShipLTUn;
}

public
string getPart(){
	return Part;
}

public
string getCustPart(){
	return CustPart;
}

public
decimal getCurrCum(){
	return CurrCum;
}

public
decimal getFaAutCum(){
	return FaAutCum;
}

public
decimal getMaAutCum(){
	return MaAutCum;
}

public
string getCurShDoc(){
	return CurShDoc;
}

public
DateTime getSDate(){
	return SDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

public
decimal getQtyCum(){
	return QtyCum;
}

public
decimal getAdjNQty(){
	return AdjNQty;
}

public
decimal getNetQty(){
    return NetQty;
}

public
string getTimeCode(){
    return TimeCode;
}

public
decimal getTrlpKeyId(){
    return TrlpKeyId;
}

public
string getDiscard(){
    return Discard;
}

public
decimal getLogNum(){
    return LogNum;
}
    

} // class
} // package