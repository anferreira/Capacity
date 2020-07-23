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
class DemTransformDDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int DemandHdr;
private int DemandDetail;
private DateTime DemDate;
private decimal Qty;

public
DemTransformDDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from demtransformd where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from demtransformd where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.DemandHdr = reader.GetInt32("DemandHdr");
	this.DemandDetail = reader.GetInt32("DemandDetail");
	this.DemDate = reader.GetDateTime("DemDate");
	this.Qty = reader.GetDecimal("Qty");
}

public override
void write(){   
	string sql = "insert into demtransformd(" + 
		"HdrId," +
		"Detail," +
		"DemandHdr," +
		"DemandDetail," +
		"DemDate," +
		"Qty" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(DemandHdr) + "," +
		"" + NumberUtil.toString(DemandDetail) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(DemDate) + "'," +
		"" + NumberUtil.toString(Qty) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update demtransformd set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"DemandHdr = " + NumberUtil.toString(DemandHdr) + ", " +
		"DemandDetail = " + NumberUtil.toString(DemandDetail) + ", " +
		"DemDate = '" + DateUtil.getCompleteDateRepresentation(DemDate) + "', " +
		"Qty = " + NumberUtil.toString(Qty) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from demtransformd where " + getWhereCondition();
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
void setDemandHdr(int DemandHdr){
	this.DemandHdr = DemandHdr;
}

public
void setDemandDetail(int DemandDetail){
	this.DemandDetail = DemandDetail;
}

public
void setDemDate(DateTime DemDate){
	this.DemDate = DemDate;
}

public
void setQty(decimal Qty){
	this.Qty = Qty;
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
int getDemandHdr(){
	return DemandHdr;
}

public
int getDemandDetail(){
	return DemandDetail;
}

public
DateTime getDemDate(){
	return DemDate;
}

public
decimal getQty(){
	return Qty;
}

} // class
} // package