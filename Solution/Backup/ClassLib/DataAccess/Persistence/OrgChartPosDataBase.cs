using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class OrgChartPosDataBase : GenericDataBaseElement{

private string OCP_OrgChart;
private string OCP_OCVersion;
private DateTime OCP_Dt;

public
OrgChartPosDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.OCP_OrgChart = reader.GetString("OCP_OrgChart");
	this.OCP_OCVersion = reader.GetString("OCP_OCVersion");
	this.OCP_Dt = reader.GetDateTime("OCP_Dt");
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
void setOCP_OrgChart(string OCP_OrgChart){
	this.OCP_OrgChart = OCP_OrgChart;
}

public
void setOCP_OCVersion(string OCP_OCVersion){
	this.OCP_OCVersion = OCP_OCVersion;
}

public
void setOCP_Dt(DateTime OCP_Dt){
	this.OCP_Dt = OCP_Dt;
}

public
string getOCP_OrgChart(){
	return OCP_OrgChart;
}

public
string getOCP_OCVersion(){
	return OCP_OCVersion;
}

public
DateTime getOCP_Dt(){
	return OCP_Dt;
}


} // class

} // namespace