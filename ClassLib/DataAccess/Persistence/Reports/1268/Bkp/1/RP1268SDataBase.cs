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

public
RP1268SDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from rp1268s where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from rp1268s where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDtl = reader.GetInt32("SubDtl");
	this.MainMat = reader.GetString("MainMat");
	this.Qty = reader.GetDecimal("Qty");
}

public override
void write(){
	string sql = "insert into rp1268s(" + 
		"HdrId," +
		"Detail," +
		"SubDtl," +
		"MainMat," +
		"Qty" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDtl) + "," +
		"'" + Converter.fixString(MainMat) + "'," +
		"" + NumberUtil.toString(Qty) + ")";
    System.Windows.Forms.MessageBox.Show(sql);
	write(sql);	
}

public override
void update(){
	string sql = "update rp1268s set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDtl = " + NumberUtil.toString(SubDtl) + ", " +
		"MainMat = '" + Converter.fixString(MainMat) + "', " +
		"Qty = " + NumberUtil.toString(Qty) + " " +

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

} // class
} // package