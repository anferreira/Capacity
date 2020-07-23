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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityPartDtlDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private int CPHdrID;
private int CPDtlID;
private string Part;
private int Seq;
private decimal Qty;

public
CapacityPartDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capacitypartdtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capacitypartdtl where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");
	this.CPHdrID = reader.GetInt32("CPHdrID");
	this.CPDtlID = reader.GetInt32("CPDtlID");
	this.Part = reader.GetString("Part");
    this.Seq = reader.GetInt32("Seq");
	this.Qty = reader.GetDecimal("Qty");
}

public override
void write(){ 
	string sql = "insert into capacitypartdtl(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +
		"CPHdrID," +
		"CPDtlID," +
		"Part," +
        "Seq," +
        "Qty" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +
		"" + NumberUtil.toString(CPHdrID) + "," +
		"" + NumberUtil.toString(CPDtlID) + "," +
		"'" + Converter.fixString(Part) + "'," +
        "" + NumberUtil.toString(Seq) + ","+
        "" + NumberUtil.toString(Qty) + ")";
	//System.Windows.Forms.MessageBox.Show(sql);
	write(sql);	 
}


public override
void update(){
	string sql = "update capacitypartdtl set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
		"CPHdrID = " + NumberUtil.toString(CPHdrID) + ", " +
		"CPDtlID = " + NumberUtil.toString(CPDtlID) + ", " +
		"Part = '" + Converter.fixString(Part) + "', " +
        "Seq = " + NumberUtil.toString(Seq) + "," +
        "Qty = " + NumberUtil.toString(Qty) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capacitypartdtl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + "";
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
void setCPHdrID(int CPHdrID){
	this.CPHdrID = CPHdrID;
}

public
void setCPDtlID(int CPDtlID){
	this.CPDtlID = CPDtlID;
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
int getCPHdrID(){
	return CPHdrID;
}

public
int getCPDtlID(){
	return CPDtlID;
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