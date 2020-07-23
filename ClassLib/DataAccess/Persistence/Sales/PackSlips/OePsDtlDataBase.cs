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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips{

public
class OePsDtlDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int ExternalDetail;
private string Part;
private string CustPart;
private decimal ShipQty;
private decimal FGCurCum;
private decimal FGPrevCum;

public
OePsDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from oepsdtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from oepsdtl where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.ExternalDetail = reader.GetInt32("ExternalDetail");
	this.Part = reader.GetString("Part");
	this.CustPart = reader.GetString("CustPart");
	this.ShipQty = reader.GetDecimal("ShipQty");
	this.FGCurCum = reader.GetDecimal("FGCurCum");
	this.FGPrevCum = reader.GetDecimal("FGPrevCum");
}

public override
void write(){
	string sql = "insert into oepsdtl(" + 
		"HdrId," +
		"Detail," +
		"ExternalDetail," +
		"Part," +
		"CustPart," +
		"ShipQty," +
		"FGCurCum," +
		"FGPrevCum" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(ExternalDetail) + "," +
		"'" + Converter.fixString(Part) + "'," +
		"'" + Converter.fixString(CustPart) + "'," +
		"" + NumberUtil.toString(ShipQty) + "," +
		"" + NumberUtil.toString(FGCurCum) + "," +
		"" + NumberUtil.toString(FGPrevCum) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update oepsdtl set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"ExternalDetail = " + NumberUtil.toString(ExternalDetail) + ", " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"CustPart = '" + Converter.fixString(CustPart) + "', " +
		"ShipQty = " + NumberUtil.toString(ShipQty) + ", " +
		"FGCurCum = " + NumberUtil.toString(FGCurCum) + ", " +
		"FGPrevCum = " + NumberUtil.toString(FGPrevCum) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepsdtl where " + getWhereCondition();
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
void setExternalDetail(int ExternalDetail){
	this.ExternalDetail = ExternalDetail;
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
void setShipQty(decimal ShipQty){
	this.ShipQty = ShipQty;
}

public
void setFGCurCum(decimal FGCurCum){
	this.FGCurCum = FGCurCum;
}

public
void setFGPrevCum(decimal FGPrevCum){
	this.FGPrevCum = FGPrevCum;
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
int getExternalDetail(){
	return ExternalDetail;
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
decimal getShipQty(){
	return ShipQty;
}

public
decimal getFGCurCum(){
	return FGCurCum;
}

public
decimal getFGPrevCum(){
	return FGPrevCum;
}

} // class
} // package