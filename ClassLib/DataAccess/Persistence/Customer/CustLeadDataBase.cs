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
class CustLeadDataBase : GenericDataBaseElement {

private int Id;
private string CustId;
private string MajSalesCode;
private string MinSalesCode;
private int LeadTime;

public
CustLeadDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from custlead where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from custlead where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.CustId = reader.GetString("CustId");
	this.MajSalesCode = reader.GetString("MajSalesCode");
	this.MinSalesCode = reader.GetString("MinSalesCode");
	this.LeadTime = reader.GetInt32("LeadTime");
}

public override
void write(){
	string sql = "insert into custlead(" + 
		"CustId," +
		"MajSalesCode," +
		"MinSalesCode," +
		"LeadTime" +

		") values (" + 

		"'" + Converter.fixString(CustId) + "'," +
		"'" + Converter.fixString(MajSalesCode) + "'," +
		"'" + Converter.fixString(MinSalesCode) + "'," +
		"" + NumberUtil.toString(LeadTime) + ")";
	write(sql);
	this.setId(dataBaseAccess.getLastId());	
}

public override
void update(){
	string sql = "update custlead set " +
		"CustId = '" + Converter.fixString(CustId) + "', " +
		"MajSalesCode = '" + Converter.fixString(MajSalesCode) + "', " +
		"MinSalesCode = '" + Converter.fixString(MinSalesCode) + "', " +
		"LeadTime = " + NumberUtil.toString(LeadTime) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from custlead where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"CustId = '" + Converter.fixString(CustId) + "' and " +
		"MajSalesCode = '" + Converter.fixString(MajSalesCode) + "' and " +
		"MinSalesCode = '" + Converter.fixString(MinSalesCode) + "'";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setCustId(string CustId){
	this.CustId = CustId;
}

public
void setMajSalesCode(string MajSalesCode){
	this.MajSalesCode = MajSalesCode;
}

public
void setMinSalesCode(string MinSalesCode){
	this.MinSalesCode = MinSalesCode;
}

public
void setLeadTime(int LeadTime){
	this.LeadTime = LeadTime;
}

public
int getId(){
	return Id;
}

public
string getCustId(){
	return CustId;
}

public
string getMajSalesCode(){
	return MajSalesCode;
}

public
string getMinSalesCode(){
	return MinSalesCode;
}

public
int getLeadTime(){
	return LeadTime;
}

} // class
} // package