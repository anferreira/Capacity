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
class MainMatDataBase : GenericDataBaseElement {

private string PART;
private int DTL;
private string MAINPART;

public
MainMatDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix3() + "mainmat where " + getWhereCondition();    
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix3() + "mainmat where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){        
	this.PART = reader.GetString("PART");
	this.DTL = Convert.ToInt32(reader.GetDecimal("DTL"));
	this.MAINPART = reader.GetString("MAINPART");            
}

public override
void write(){
	string sql = "insert into " + getTablePrefix3() + "mainmat(" + 
		"PART," +
		"DTL," +
		"MAINPART" +

		") values (" + 

		"'" + Converter.fixString(PART) + "'," +
		"" + NumberUtil.toString(DTL) + "," +
		"'" + Converter.fixString(MAINPART) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update " + getTablePrefix3() + "mainmat set " +
		"PART = '" + Converter.fixString(PART) + "', " +
		"DTL = " + NumberUtil.toString(DTL) + ", " +
		"MAINPART = '" + Converter.fixString(MAINPART) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from mainmat where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"PART = '" + Converter.fixString(PART) + "' and " +
		"DTL = " + NumberUtil.toString(DTL) + "";
	return sqlWhere;
}

public
void setPART(string PART){
	this.PART = PART;
}

public
void setDTL(int DTL){
	this.DTL = DTL;
}

public
void setMAINPART(string MAINPART){
	this.MAINPART = MAINPART;
}

public
string getPART(){
	return PART;
}

public
int getDTL(){
	return DTL;
}

public
string getMAINPART(){
	return MAINPART;
}

} // class
} // package