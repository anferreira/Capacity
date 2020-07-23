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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityViewPartDataBase : CapacityViewDataBase {


private string Part;
private int Seq;
private decimal Qty;

public
CapacityViewPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public override
void load(NotNullDataReader reader){
	this.Part = reader.GetString("Part");
	this.Seq = reader.GetInt32("Seq");
    this.Qty = reader.GetDecimal("Qty");
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
void setQty(decimal Qty){
	this.Qty = Qty;
}

public
string getPart(){
	return Part;
}

public
int getSeq(){
	return Seq;
}

public
decimal getQty(){
	return Qty;
}

} // class
} // package