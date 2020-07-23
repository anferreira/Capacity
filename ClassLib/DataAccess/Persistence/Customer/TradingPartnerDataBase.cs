/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Customer{

public
class TradingPartnerDataBase : GenericDataBaseElement {

private string TPartner;
private string ExportMode;

public
TradingPartnerDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from tradingpartner where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from tradingpartner where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.TPartner   = reader.GetString("TPartner");
	this.ExportMode = reader.GetString("ExportMode");    
}

public override
void write(){
	string sql = "insert into tradingpartner(" + 
		"TPartner," +
        "ExportMode" +
        
        ") values (" + 

		"'" + Converter.fixString(TPartner) + "'," +		
        "'" + Converter.fixString(ExportMode) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update tradingpartner set " +
		"TPartner = '" + Converter.fixString(TPartner) + "', " +		
        "ExportMode = '" + Converter.fixString(ExportMode) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from tradingpartner where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"TPartner = '" + Converter.fixString(TPartner) + "'";
	return sqlWhere;
}

public
void setTPartner(string TPartner){
	this.TPartner = TPartner;
}

public
void setExportMode(string ExportMode){
	this.ExportMode = ExportMode;
}

public
string getTPartner(){
	return TPartner;
}

public
string getExportMode(){
	return ExportMode;
}

} // class
} // package