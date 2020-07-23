using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActHDataBase : GenericDataBaseElement{

private string PAH_ProdID;
private string PAH_ActID;
private int PAH_Seq;
private int PAH_MethodRank;
private string PAH_IndID;
private string PAH_ConfigID;
private string PAH_ECNLev;

public
ProdFmActHDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	this.PAH_ProdID = reader.GetString("PAH_ProdID");
	this.PAH_ActID = reader.GetString("PAH_ActID");
	this.PAH_Seq = reader.GetInt32("PAH_Seq");
	this.PAH_MethodRank = reader.GetInt32("PAH_MethodRank");
	this.PAH_IndID = reader.GetString("PAH_IndID");
	this.PAH_ConfigID = reader.GetString("PAH_ConfigID");
	this.PAH_ECNLev = reader.GetString("PAH_ECNLev");
}

public
void specialLoad(NotNullDataReader reader){
	this.PAH_ProdID = reader.GetString(0);
	this.PAH_Seq = reader.GetInt32(1);
}


public
string getWhereCondition(){
	string sqlWhere =
			"PAH_ProdID  = '" + Converter.fixString(PAH_ProdID) + "' and " +
			"PAH_ActID = '" + Converter.fixString(PAH_ActID) + "' and " +
		    "PAH_Seq = " + PAH_Seq;
	return sqlWhere;
}

public
bool exists(){
    string sql = "select * from prodfmacth where " +  getWhereCondition();
	return exists(sql);
}

public 
bool read(){
    string sql = "select * from prodfmacth where " +  getWhereCondition();
	return read(sql);			
}

public override
void write(){
	string sql = "insert into prodfmacth values('" + 
		Converter.fixString(PAH_ProdID) + "', '" +
		Converter.fixString(PAH_ActID) + "', " +
		PAH_Seq + ", " +
		PAH_MethodRank + ", '" +
		Converter.fixString(PAH_IndID) + "', '" +
		Converter.fixString(PAH_ConfigID) + "', '" +
		Converter.fixString(PAH_ECNLev) + "')";
    write(sql);	
}

public override
void update(){	
	string sql = "update prodfmacth set " +
		"PAH_MethodRank = " + NumberUtil.toString(PAH_MethodRank) + ", " +
		"PAH_IndID = '" + Converter.fixString(PAH_IndID) + "', " +
		"PAH_ConfigID = '" + Converter.fixString(PAH_ConfigID) + "', " + 
		"PAH_ECNLev = '" + Converter.fixString(PAH_ECNLev) + "', " + 
		"where " + getWhereCondition(); 		
    update(sql);	
}

public override
void delete(){
	string sql = "delete from prodfmacth where " + getWhereCondition();
    delete(sql);
}


public
void setPAH_ProdID(string PAH_ProdID){
	this.PAH_ProdID = PAH_ProdID;
}

public
void setPAH_ActID(string PAH_ActID){
	this.PAH_ActID = PAH_ActID;
}

public
void setPAH_Seq(int PAH_Seq){
	this.PAH_Seq = PAH_Seq;
}

public
void setPAH_MethodRank(int PAH_MethodRank){
	this.PAH_MethodRank = PAH_MethodRank;
}

public
void setPAH_IndID(string PAH_IndID){
	this.PAH_IndID = PAH_IndID;
}

public
void setPAH_ConfigID(string PAH_ConfigID){
	this.PAH_ConfigID = PAH_ConfigID;
}

public
void setPAH_ECNLev(string PAH_ECNLev){
	this.PAH_ECNLev = PAH_ECNLev;
}


public
string getPAH_ProdID(){
	return PAH_ProdID;
}

public
string getPAH_ActID(){
	return PAH_ActID;
}

public
int getPAH_Seq(){
	return PAH_Seq;
}

public
int getPAH_MethodRank(){
	return PAH_MethodRank;
}

public
string getPAH_IndID(){
	return PAH_IndID;
}

public
string getPAH_ConfigID(){
	return PAH_ConfigID;
}

public
string getPAH_ECNLev(){
	return PAH_ECNLev;
}

} // class

} // namespace