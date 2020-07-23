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
class CapacityPartDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int HotListID;
private string Part;
private string IsFamily;
private int Seq;
private decimal Qty;
private DateTime StartDate;
private DateTime EndDate;
private string Plant;
private string Dept;
private decimal QtyPlanned;

public
CapacityPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}


public
bool read(){
	string sql = "select * from capacitypart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capacitypart where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.HotListID = reader.GetInt32("HotListID");
	this.Part = reader.GetString("Part");
	this.IsFamily = reader.GetString("IsFamily");
	this.Seq = reader.GetInt32("Seq");
	this.Qty = reader.GetDecimal("Qty");
	this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");

    this.Plant = reader.GetString("Plant");
    this.Dept = reader.GetString("Dept");
    this.QtyPlanned = reader.GetDecimal("QtyPlanned");            
}

public override
void write(){ 
	string sql = "insert into capacitypart(" + 
		"HdrId," +
		"Detail," +
		"HotListID," +
		"Part," +
		"IsFamily," +
		"Seq," +
		"Qty," +
        "QtyPlanned," +        
        "StartDate," +
		"EndDate," +
        "Plant," +
        "Dept" +
          
        ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(HotListID) + "," +
		"'" + Converter.fixString(Part) + "'," +
		"'" + Converter.fixString(IsFamily) + "'," +
		"" + NumberUtil.toString(Seq) + "," +
		"" + NumberUtil.toString(Qty) + "," +
        "" + NumberUtil.toString(QtyPlanned) + "," +
        "'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate)  + "'," +
        "'" + Converter.fixString(Plant) + "'," +
		"'" + Converter.fixString(Dept) + "')";

        //System.Windows.Forms.MessageBox.Show(sql);
        write(sql);	    
}

public override
void update(){
	string sql = "update capacitypart set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"HotListID = " + NumberUtil.toString(HotListID) + ", " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"IsFamily = '" + Converter.fixString(IsFamily) + "', " +
		"Seq = " + NumberUtil.toString(Seq) + ", " +
		"Qty = " + NumberUtil.toString(Qty) + ", " +
        "QtyPlanned = " + NumberUtil.toString(QtyPlanned) + ", " +
        "StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capacitypart where " + getWhereCondition();
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
void setHotListID(int HotListID){
	this.HotListID = HotListID;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setIsFamily(string IsFamily){
	this.IsFamily = IsFamily;
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
void setStartDate(DateTime StartDate){
	this.StartDate = StartDate;
}

public
void setEndDate(DateTime EndDate){
	this.EndDate = EndDate;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setDept(string Dept){
	this.Dept = Dept;
}

public
void setQtyPlanned(decimal QtyPlanned){
	this.QtyPlanned = QtyPlanned;
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
int getHotListID(){
	return HotListID;
}

public
string getPart(){
	return Part;
}

public
string getIsFamily(){
	return IsFamily;
}

public
int getSeq(){
	return Seq;
}

public
decimal getQty(){
	return Qty;
}

public
DateTime getStartDate(){
	return StartDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

public
string getPlant(){
    return Plant;
}

public
string getDept(){
	return Dept;
}

public
decimal getQtyPlanned(){
	return QtyPlanned;
}

} // class
} // package