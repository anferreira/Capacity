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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleMaterialConsumPartViewDataBase : ScheduleMaterialConsumPartDataBase {

private DateTime StartDate;


public
ScheduleMaterialConsumPartViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public override
void load(NotNullDataReader reader){
	this.StartDate = reader.GetDateTime("StartDate");	
	base.load(reader);
}

public
void setStartDate(DateTime StartDate){
	this.StartDate = StartDate;
}

public
DateTime getStartDate(){
	return StartDate;
}

} // class
} // package