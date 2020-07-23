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
class SchedulePartDtlDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private string Part;
private int Seq;
private decimal Qty;

public
SchedulePartDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from schedulepartdtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from schedulepartdtl where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");    
	this.Part = reader.GetString("Part");
	this.Seq = reader.GetInt32("Seq");
	this.Qty = reader.GetDecimal("Qty");
}


public override
void write(){ 
	string sql = "insert into schedulepartdtl(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +        
        "Part," +
		"Seq," +
		"Qty" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +        
        "'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(Seq) + "," +
		"" + NumberUtil.toString(Qty) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update schedulepartdtl set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +        
        "Part = '" + Converter.fixString(Part) + "', " +
		"Seq = " + NumberUtil.toString(Seq) + ", " +
		"Qty = " + NumberUtil.toString(Qty) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from schedulepartdtl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDetail = " + NumberUtil.toString(SubDetail);            
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
void setPart(string Part){
	this.Part = Part;
}

public
void setSeq(int Seq){
	this.Seq = Seq;
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
int getSubDetail(){
	return SubDetail;
}

public
string getPart(){
	return Part;
}

public
int getSeq(){
	return Seq;
}

public
decimal getQty(){
	return Qty;
}

} // class
} // package