using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListInvAnalysisViewDataBase : HotListDataBase{

private string PFS_Des1;
private decimal PFS_VirtKanManDem;
private string  PFS_PartType;
private decimal PFS_Level;
private decimal MatQty;
private decimal PC_OptRunQty;
        
public
HotListInvAnalysisViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
HotListInvAnalysisViewDataBase(HotListInvAnalysisViewDataBase hotListInvAnalysisViewDataBase) : base(hotListInvAnalysisViewDataBase.dataBaseAccess){
	
}

public 
void load(NotNullDataReader reader){
    base.load(reader);
    this.PFS_Des1 = reader.GetString("PFS_Des1");
    this.PFS_VirtKanManDem = reader.GetDecimal("PFS_VirtKanManDem"); 	
    this.PFS_PartType = reader.GetString("PFS_PartType");
    this.PFS_Level = reader.GetInt32("PC_ProdLev"); //we get level from routing PFS_Level
    this.MatQty = reader.GetDecimal("MatQty"); 	
    this.PC_OptRunQty =reader.GetDecimal("PC_OptRunQty"); 	
}

public override
void update(){
	throw new PersistenceException("Error in class HotListDataBase <update>: Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Error in class HotListDataBase <delete>: Method not implemented");
}

public
void setPFS_Des1(string PFS_Des1){
	this.PFS_Des1 = PFS_Des1;
}

public
void setPFS_VirtKanManDem(decimal PFS_VirtKanManDem){
	this.PFS_VirtKanManDem = PFS_VirtKanManDem;
}

public
void setPFS_PartType(string PFS_PartType){
	this.PFS_PartType = PFS_PartType;
}
        
public
void setPFS_Level(decimal PFS_Level){
	this.PFS_Level = PFS_Level;
}

public
void setMatQty(decimal MatQty){
	this.MatQty = MatQty;
}

public
void setPC_OptRunQty(decimal PC_OptRunQty){
    this.PC_OptRunQty = PC_OptRunQty;
}

public
string getPFS_Des1(){
	return PFS_Des1;
}

public
decimal getPFS_VirtKanManDem(){
	return PFS_VirtKanManDem;
}

public
string getPFS_PartType(){
	return PFS_PartType;
}

public
decimal getPFS_Level(){
	return PFS_Level;
}

public
decimal getMatQty(){
    return MatQty;
}

public
decimal getPC_OptRunQty(){
    return PC_OptRunQty;
}


} // class

} // namespace