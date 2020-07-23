using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines{


public 
class PltDeptMachViewDataBase : PltDeptMachDataBase{

private DateTime DateLastPlanned;
private int Priority;

public
PltDeptMachViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    base.load(reader);
    this.DateLastPlanned = reader.GetDateTime("DateLastPlanned");
    this.Priority = reader.GetInt32("Priority");	
}

public
void setDateLastPlanned(DateTime DateLastPlanned){
	this.DateLastPlanned = DateLastPlanned;
}

public
void setPriority(int Priority){
	this.Priority = Priority;
}

public
DateTime getDateLastPlanned(){
	return DateLastPlanned;
}

public
int getPriority(){
	return Priority;
}

} // class

} // namespace
