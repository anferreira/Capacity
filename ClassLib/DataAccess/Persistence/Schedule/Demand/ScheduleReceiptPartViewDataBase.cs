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
class ScheduleReceiptPartViewDataBase : ScheduleReceiptPartDataBase {

private string Part;
private int Seq;


public
ScheduleReceiptPartViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public override
void load(NotNullDataReader reader){
	this.Part = reader.GetString("Part");
	this.Seq = reader.GetInt32("Seq");    
	base.load(reader);
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
string getPart(){
	return Part;
}

public
int getSeq(){
	return Seq;
}

} // class
} // package