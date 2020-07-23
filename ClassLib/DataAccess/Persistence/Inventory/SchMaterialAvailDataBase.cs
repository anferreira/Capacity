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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class SchMaterialAvailDataBase : GenericDataBaseElement {

private int Id;
private string Plant;
private DateTime DateCreated;
private int ParentSrcHotId;
private int ParentSrcHotDtlId;
private string ParentPart;
private int ParentSeq;
private decimal ParentQtyAdjust;
private decimal MaxQty;
private string MaxUOM;
private string ChildSource;
private string ChildPart;
private int ChildSeq;
private decimal ChildQty;
private decimal ChildCumulativeQOH;
private decimal ChildAvailQty;
private DateTime DateTime;
private int CounterParentSrcHotId;

public
SchMaterialAvailDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from schmaterialavail where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from schmaterialavail where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
    this.Plant = reader.GetString("Plant");
    this.DateCreated = reader.GetDateTime("DateCreated");
	this.ParentSrcHotId = reader.GetInt32("ParentSrcHotId");
    this.ParentSrcHotDtlId= reader.GetInt32("ParentSrcHotDtlId");
    this.ParentPart = reader.GetString("ParentPart");
	this.ParentSeq = reader.GetInt32("ParentSeq");
    this.ParentQtyAdjust = reader.GetDecimal("ParentQtyAdjust");
	this.MaxQty = reader.GetDecimal("MaxQty");
	this.MaxUOM = reader.GetString("MaxUOM");
	this.ChildSource = reader.GetString("ChildSource");
	this.ChildPart = reader.GetString("ChildPart");
	this.ChildSeq = reader.GetInt32("ChildSeq");
	this.ChildQty = reader.GetDecimal("ChildQty");
	this.ChildCumulativeQOH = reader.GetDecimal("ChildCumulativeQOH");
	this.ChildAvailQty = reader.GetDecimal("ChildAvailQty");
	this.DateTime = reader.GetDateTime("DateTime");
	this.CounterParentSrcHotId = reader.GetInt32("CounterParentSrcHotId");
}

public override
void write(){
	string sql = "insert into schmaterialavail(" +
        "Plant," +
        "DateCreated," +
		"ParentSrcHotId," +
        "ParentSrcHotDtlId," +        
        "ParentPart," +
		"ParentSeq," +
        "ParentQtyAdjust," +        
        "MaxQty," +
		"MaxUOM," +
		"ChildSource," +
		"ChildPart," +
		"ChildSeq," +
		"ChildQty," +
		"ChildCumulativeQOH," +
		"ChildAvailQty," +
		"DateTime," +
		"CounterParentSrcHotId" +

		") values (" +        
        "'" + Converter.fixString(Plant) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(DateCreated) + "'," +
		"" + NumberUtil.toString(ParentSrcHotId) + "," +
        "" + NumberUtil.toString(ParentSrcHotDtlId) + "," +        
        "'" + Converter.fixString(ParentPart) + "'," +
		"" + NumberUtil.toString(ParentSeq) + "," +
        "" + NumberUtil.toString(ParentQtyAdjust) + "," +        
        "" + NumberUtil.toString(MaxQty) + "," +
		"'" + Converter.fixString(MaxUOM) + "'," +
		"'" + Converter.fixString(ChildSource) + "'," +
		"'" + Converter.fixString(ChildPart) + "'," +
		"" + NumberUtil.toString(ChildSeq) + "," +
		"" + NumberUtil.toString(ChildQty) + "," +
		"" + NumberUtil.toString(ChildCumulativeQOH) + "," +
		"" + NumberUtil.toString(ChildAvailQty) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(DateTime) + "'," +
		"" + NumberUtil.toString(CounterParentSrcHotId) + ")";
	write(sql);
	this.setId(dataBaseAccess.getLastId());	
}

public override
void update(){
	string sql = "update schmaterialavail set " +
        "Plant = '" + Converter.fixString(Plant) + "', " +
        "DateCreated = '" + DateUtil.getCompleteDateRepresentation(DateCreated) + "', " +
		"ParentSrcHotId = " + NumberUtil.toString(ParentSrcHotId) + ", " +
        "ParentSrcHotDtlId = " + NumberUtil.toString(ParentSrcHotDtlId) + ", " +        
        "ParentPart = '" + Converter.fixString(ParentPart) + "', " +
		"ParentSeq = " + NumberUtil.toString(ParentSeq) + ", " +
        "ParentQtyAdjust = " + NumberUtil.toString(ParentQtyAdjust) + ", " +        
        "MaxQty = " + NumberUtil.toString(MaxQty) + ", " +
		"MaxUOM = '" + Converter.fixString(MaxUOM) + "', " +
		"ChildSource = '" + Converter.fixString(ChildSource) + "', " +
		"ChildPart = '" + Converter.fixString(ChildPart) + "', " +
		"ChildSeq = " + NumberUtil.toString(ChildSeq) + ", " +
		"ChildQty = " + NumberUtil.toString(ChildQty) + ", " +
		"ChildCumulativeQOH = " + NumberUtil.toString(ChildCumulativeQOH) + ", " +
		"ChildAvailQty = " + NumberUtil.toString(ChildAvailQty) + ", " +
		"DateTime = '" + DateUtil.getCompleteDateRepresentation(DateTime) + "', " +
		"CounterParentSrcHotId = " + NumberUtil.toString(CounterParentSrcHotId) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from schmaterialavail where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Id = " + NumberUtil.toString(Id) + "";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setDateCreated(DateTime DateCreated){
	this.DateCreated = DateCreated;
}

public
void setParentSrcHotId(int ParentSrcHotId){
	this.ParentSrcHotId = ParentSrcHotId;
}

public
void setParentSrcHotDtlId(int ParentSrcHotDtlId){
	this.ParentSrcHotDtlId = ParentSrcHotDtlId;
}

public
void setParentPart(string ParentPart){
	this.ParentPart = ParentPart;
}

public
void setParentSeq(int ParentSeq){
	this.ParentSeq = ParentSeq;
}

public
void setParentQtyAdjust(decimal ParentQtyAdjust){
	this.ParentQtyAdjust = ParentQtyAdjust;
}

public
void setMaxQty(decimal MaxQty){
	this.MaxQty = MaxQty;
}

public
void setMaxUOM(string MaxUOM){
	this.MaxUOM = MaxUOM;
}

public
void setChildSource(string ChildSource){
	this.ChildSource = ChildSource;
}

public
void setChildPart(string ChildPart){
	this.ChildPart = ChildPart;
}

public
void setChildSeq(int ChildSeq){
	this.ChildSeq = ChildSeq;
}

public
void setChildQty(decimal ChildQty){
	this.ChildQty = ChildQty;
}

public
void setChildCumulativeQOH(decimal ChildCumulativeQOH){
	this.ChildCumulativeQOH = ChildCumulativeQOH;
}

public
void setChildAvailQty(decimal ChildAvailQty){
	this.ChildAvailQty = ChildAvailQty;
}

public
void setDateTime(DateTime DateTime){
	this.DateTime = DateTime;
}

public
void setCounterParentSrcHotId(int CounterParentSrcHotId){
	this.CounterParentSrcHotId = CounterParentSrcHotId;
}

public
int getId(){
	return Id;
}

public
string getPlant(){
	return Plant;
}

public
DateTime getDateCreated(){
	return DateCreated;
}

public
int getParentSrcHotId(){
	return ParentSrcHotId;
}

public
int getParentSrcHotDtlId(){
	return ParentSrcHotDtlId;
}
       
public
string getParentPart(){
	return ParentPart;
}

public
int getParentSeq(){
	return ParentSeq;
}

public
decimal getParentQtyAdjust(){
	return ParentQtyAdjust;
}

public
decimal getMaxQty(){
	return MaxQty;
}

public
string getMaxUOM(){
	return MaxUOM;
}

public
string getChildSource(){
	return ChildSource;
}

public
string getChildPart(){
	return ChildPart;
}

public
int getChildSeq(){
	return ChildSeq;
}

public
decimal getChildQty(){
	return ChildQty;
}

public
decimal getChildCumulativeQOH(){
	return ChildCumulativeQOH;
}

public
decimal getChildAvailQty(){
	return ChildAvailQty;
}

public
DateTime getDateTime(){
	return DateTime;
}

public
int getCounterParentSrcHotId(){
	return CounterParentSrcHotId;
}

} // class
} // package