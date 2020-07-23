using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PrhistSumViewDataBase : GenericDataBaseElement{

private decimal DWSEQN;
private string DWPART;
private decimal DWQTYC;
private decimal DWQTYS;

public 
PrhistSumViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){	
}

public 
void load(NotNullDataReader reader){
	this.DWSEQN = reader.GetDecimal("DWSEQN");
    this.DWPART = reader.GetString("DWPART");
    this.DWQTYC = reader.GetDecimal("DWQTYC");
    this.DWQTYS = reader.GetDecimal("DWQTYS");    
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
void setDWSEQN (decimal DWSEQN){
    this.DWSEQN = DWSEQN;
}

public 
void setDWPART (string DWPART){
    this.DWPART = DWPART;
}

public 
void setDWQTYC (decimal DWQTYC){
    this.DWQTYC = DWQTYC;
}

public 
void setDWQTYS (decimal DWQTYS){
    this.DWQTYS = DWQTYS;
}

public 
decimal getDWSEQN(){
    return DWSEQN;
}

public 
string getDWPART(){
    return DWPART;
}

public 
decimal getDWQTYC(){
    return DWQTYC;
}

public 
decimal getDWQTYS(){
    return DWQTYS;
}


}//end class

}//end namespace
