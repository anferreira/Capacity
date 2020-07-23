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
class InventoryObjectivePartDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string Part;
private int Seq;
private string Master;
private string ObectivesAutomaticCalc;

public
InventoryObjectivePartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from inventoryobjectivepart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from inventoryobjectivepart where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Part = reader.GetString("Part");
	this.Seq = reader.GetInt32("Seq");
	this.Master = reader.GetString("Master");
    this.ObectivesAutomaticCalc = reader.GetString("ObectivesAutomaticCalc");
}

public override 
void write(){
	string sql = "insert into inventoryobjectivepart(" + 
		"HdrId," +
		"Detail," +
		"Part," +
		"Seq," +
		"Master," +
        "ObectivesAutomaticCalc" +
        
		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(Seq) + "," +
		"'" + Converter.fixString(Master) + "'," +
        "'" + Converter.fixString(ObectivesAutomaticCalc) + "')";
            
    write(sql);	
}

public override
void update(){
	string sql = "update inventoryobjectivepart set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"Seq = " + NumberUtil.toString(Seq) + ", " +
		"Master = '" + Converter.fixString(Master) + "', " +
        "ObectivesAutomaticCalc = '" + Converter.fixString(ObectivesAutomaticCalc) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from inventoryobjectivepart where " + getWhereCondition();
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
void setPart(string Part){
	this.Part = Part;
}

public
void setSeq(int Seq){
	this.Seq = Seq;
}

public
void setMaster(string Master){
	this.Master = Master;
}

public
void setObectivesAutomaticCalc(string ObectivesAutomaticCalc){
	this.ObectivesAutomaticCalc = ObectivesAutomaticCalc;
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
string getPart(){
	return Part;
}

public
int getSeq(){
	return Seq;
}

public
string getMaster(){
	return Master;
}

public
string getObectivesAutomaticCalc(){
	return ObectivesAutomaticCalc;
}

} // class
} // package