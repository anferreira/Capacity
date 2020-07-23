using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class OrgChartDataBase : GenericDataBaseElement{

private string O_OrgChart;
private DateTime O_Dt;
private string O_CreateBy;
private DateTime O_DtCr;
private string O_UpdateBy;
private DateTime O_DtUp;

public
OrgChartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.O_OrgChart = reader.GetString("O_OrgChart");
	this.O_Dt = reader.GetDateTime("O_Dt");
	this.O_CreateBy = reader.GetString("O_CreateBy");
	this.O_DtCr = reader.GetDateTime("O_DtCr");
	this.O_UpdateBy = reader.GetString("O_UpdateBy");
	this.O_DtUp = reader.GetDateTime("O_DtUp");
}

public override
void write(){
	throw new PersistenceException("Method not implemented");
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setO_OrgChart(string O_OrgChart){
	this.O_OrgChart = O_OrgChart;
}

public
void setO_Dt(DateTime O_Dt){
	this.O_Dt = O_Dt;
}

public
void setO_CreateBy(string O_CreateBy){
	this.O_CreateBy = O_CreateBy;
}

public
void setO_DtCr(DateTime O_DtCr){
	this.O_DtCr = O_DtCr;
}

public
void setO_UpdateBy(string O_UpdateBy){
	this.O_UpdateBy = O_UpdateBy;
}

public
void setO_DtUp(DateTime O_DtUp){
	this.O_DtUp = O_DtUp;
}

public
string getO_OrgChart(){
	return O_OrgChart;
}

public
DateTime getO_Dt(){
	return O_Dt;
}

public
string getO_CreateBy(){
	return O_CreateBy;
}

public
DateTime getO_DtCr(){
	return O_DtCr;
}

public
string getO_UpdateBy(){
	return O_UpdateBy;
}

public
DateTime getO_DtUp(){
	return O_DtUp;
}


} // class

} // namespace