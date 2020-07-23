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
class RP1268SDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDtl;
private string MainMat;
private decimal Qty;
private decimal wK1RECQTY;
private decimal wK2RECQTY;
private decimal wK3RECQTY;
private decimal wK4RECQTY;
private DateTime WK1RECDAT;
private DateTime WK2RECDAT;

public
RP1268SDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix3() + "rp1268s where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix3() + "rp1268s where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDtl = reader.GetInt32("SubDtl");
	this.MainMat = reader.GetString("MainMat");
	this.Qty = reader.GetDecimal("Qty");
    this.wK1RECQTY = reader.GetDecimal("wK1RECQTY");
    this.wK2RECQTY = reader.GetDecimal("wK2RECQTY");
    this.wK3RECQTY = reader.GetDecimal("wK3RECQTY");
    this.wK4RECQTY = reader.GetDecimal("wK4RECQTY");

    this.WK1RECDAT = reader.GetDateTime("WK1RECDAT");
    this.WK2RECDAT = reader.GetDateTime("WK2RECDAT");
}

public override
void write(){
	string sql = "insert into " + getTablePrefix3() + "rp1268s(" +
        "HdrId," +
        "Detail," +
		"SubDtl," +
		"MainMat," +
		"Qty," +
        "wK1RECQTY," +
        "wK2RECQTY," +
        "wK3RECQTY," +
        "wK4RECQTY," +
        "WK1RECDAT," +
        "WK2RECDAT" + 
               
        ") values (" + 

		"" + NumberUtil.toString(HdrId)  + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDtl) + "," +
		"'"+ Converter.fixString(MainMat)+ "'," +
		"" + NumberUtil.toString(Qty,10,2) + "," +

        "" + NumberUtil.toString(wK1RECQTY,10,2) + "," +
        "" + NumberUtil.toString(wK2RECQTY,10,2) + "," +
        "" + NumberUtil.toString(wK3RECQTY,10,2) + "," +
        "" + NumberUtil.toString(wK4RECQTY,10,2) + "," +

        "'" + DateUtil.getDateRepresentation(WK1RECDAT) + "'," +
        "'" + DateUtil.getDateRepresentation(WK2RECDAT) + "')";
        
        //write(sql);	
            
    try{
        //System.Windows.Forms.MessageBox.Show("write rp1268s : " + sql);
        write(sql);
    }catch(Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)
            System.Windows.Forms.MessageBox.Show("write rp1268s error: " + ex.Message);
    }                    
}

public override
void update(){
	string sql = "update " + getTablePrefix3() + "rp1268s set " +
        "HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDtl = " + NumberUtil.toString(SubDtl) + ", " +
		"MainMat = '" + Converter.fixString(MainMat) + "', " +
		"Qty = " + NumberUtil.toString(Qty) + " " +

        "wK1RECQTY = " + NumberUtil.toString(wK1RECQTY) + ", " +
        "wK2RECQTY = " + NumberUtil.toString(wK2RECQTY) + ", " +
        "wK3RECQTY = " + NumberUtil.toString(wK3RECQTY) + ", " +
        "wK4RECQTY = " + NumberUtil.toString(wK4RECQTY) + " " +
        "WK1RECDAT = '" + DateUtil.getDateRepresentation(WK1RECDAT) + "'," +
        "WK2RECDAT = '" + DateUtil.getDateRepresentation(WK2RECDAT) + "' " +        

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rp1268s where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
        "HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDtl = " + NumberUtil.toString(SubDtl) + "";
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
void setSubDtl(int SubDtl){
	this.SubDtl = SubDtl;
}

public
void setMainMat(string MainMat){
	this.MainMat = MainMat;
}

public
void setQty(decimal Qty){
	this.Qty = Qty;
}

public
void setWK1RECQTY(decimal wK1RECQTY){
	this.wK1RECQTY = wK1RECQTY;
}

public
void setWK2RECQTY(decimal wK2RECQTY){
	this.wK2RECQTY = wK2RECQTY;
}

public
void setWK3RECQTY(decimal wK3RECQTY){
	this.wK3RECQTY = wK3RECQTY;
}

public
void setWK4RECQTY(decimal wK4RECQTY){
    this.wK4RECQTY = wK4RECQTY;
}

public
void setWK1RECDAT(DateTime WK1RECDAT){
    this.WK1RECDAT = WK1RECDAT;
}

public
void setWK2RECDAT(DateTime WK2RECDAT){
    this.WK2RECDAT = WK2RECDAT;
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
int getSubDtl(){
	return SubDtl;
}

public
string getMainMat(){
	return MainMat;
}

public
decimal getQty(){
	return Qty;
}

public
decimal getWK1RECQTY(){
    return wK1RECQTY;
}

public
decimal getWK2RECQTY(){
    return wK2RECQTY;
}

public
decimal getWK3RECQTY(){
    return wK3RECQTY;
}

public
decimal getWK4RECQTY(){
    return wK4RECQTY;
}

public
DateTime getWK1RECDAT(){
    return WK1RECDAT;
}

public
DateTime getWK2RECDAT(){
    return WK2RECDAT;
}

} // class
} // package