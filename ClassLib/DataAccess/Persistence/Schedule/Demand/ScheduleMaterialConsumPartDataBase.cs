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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleMaterialConsumPartDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private int SubSubDetail;
private string MatPart;
private int MatSeq;
private decimal QtyReq;
private decimal QtyReported;
private decimal QtyConsum;
private string MatType;

public
ScheduleMaterialConsumPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from schedulematerialconsumpart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from schedulematerialconsumpart where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");
	this.SubSubDetail = reader.GetInt32("SubSubDetail");	
	this.MatPart = reader.GetString("MatPart");
	this.MatSeq = reader.GetInt32("MatSeq");
	this.QtyReq = reader.GetDecimal("QtyReq");
	this.QtyReported = reader.GetDecimal("QtyReported");
	this.QtyConsum = reader.GetDecimal("QtyConsum");
	this.MatType = reader.GetString("MatType");
}

public override
void write(){ 
	string sql = "insert into schedulematerialconsumpart(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +
		"SubSubDetail," +		
		"MatPart," +
		"MatSeq," +
		"QtyReq," +
		"QtyReported," +
		"QtyConsum," +
		"MatType" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +
		"" + NumberUtil.toString(SubSubDetail) + "," +		
		"'" + Converter.fixString(MatPart) + "'," +
		"" + NumberUtil.toString(MatSeq) + "," +
		"" + NumberUtil.toString(QtyReq) + "," +
		"" + NumberUtil.toString(QtyReported) + "," +
		"" + NumberUtil.toString(QtyConsum) + "," +
		"'" + Converter.fixString(MatType) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update schedulematerialconsumpart set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
		"SubSubDetail = " + NumberUtil.toString(SubSubDetail) + ", " +		
		"MatPart = '" + Converter.fixString(MatPart) + "', " +
		"MatSeq = " + NumberUtil.toString(MatSeq) + ", " +
		"QtyReq = " + NumberUtil.toString(QtyReq) + ", " +
		"QtyReported = " + NumberUtil.toString(QtyReported) + ", " +
		"QtyConsum = " + NumberUtil.toString(QtyConsum) + ", " +
		"MatType = '" + Converter.fixString(MatType) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from schedulematerialconsumpart where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + " and " +
		"SubSubDetail = " + NumberUtil.toString(SubSubDetail);
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
void setSubDetail(int SubDetail){
	this.SubDetail = SubDetail;
}

public
void setSubSubDetail(int SubSubDetail){
	this.SubSubDetail = SubSubDetail;
}

public
void setMatPart(string MatPart){
	this.MatPart = MatPart;
}

public
void setMatSeq(int MatSeq){
	this.MatSeq = MatSeq;
}

public
void setQtyReq(decimal QtyReq){
	this.QtyReq = QtyReq;
}

public
void setQtyReported(decimal QtyReported){
	this.QtyReported = QtyReported;
}

public
void setQtyConsum(decimal QtyConsum){
	this.QtyConsum = QtyConsum;
}

public
void setMatType(string MatType){
	this.MatType = MatType;
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
int getSubDetail(){
	return SubDetail;
}

public
int getSubSubDetail(){
	return SubSubDetail;
}

public
string getMatPart(){
	return MatPart;
}

public
int getMatSeq(){
	return MatSeq;
}

public
decimal getQtyReq(){
	return QtyReq;
}

public
decimal getQtyReported(){
	return QtyReported;
}

public
decimal getQtyConsum(){
	return QtyConsum;
}

public
string getMatType(){
	return MatType;
}

} // class
} // package