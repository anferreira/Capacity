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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmpShiftScheduleHdrSumViewDataBase : GenericDataBaseElement {

private DateTime Date;
private int ShiftNum;
private int EmployeeCount;

public
EmpShiftScheduleHdrSumViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void load(NotNullDataReader reader){
	this.Date = reader.GetDateTime("Date");
	this.ShiftNum = reader.GetInt32("ShiftNum");
    this.EmployeeCount = reader.GetInt32("EmployeeCount");
}

public override
void write(){
    throw new PersistenceException("write Function not enabled");    
}

public override
void update(){
    throw new PersistenceException("update Function not enabled");    
}

public override
void delete(){
   throw new PersistenceException("delete Function not enabled");    
}

public
void setDate(DateTime Date){
	this.Date = Date;
}

public
void setShiftNum(int ShiftNum){
	this.ShiftNum = ShiftNum;
}

public
void setEmployeeCount(int EmployeeCount){
	this.EmployeeCount = EmployeeCount;
}

public
DateTime getDate(){
	return Date;
}

public
int getShiftNum(){
	return ShiftNum;
}

public
int getEmployeeCount(){
    return EmployeeCount;
}

} // class
} // package