using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class TimeTypeDataBase : GenericDataBaseElement{

private string TT_TmType;
private string TT_DirInd;
private string TT_DeptLoc;
private string TT_DeptAsg;
private string TT_DRS;
private string TT_SchYN;
private string TT_UseProdID;
private string TT_Des;
private string TT_Color;
private decimal TT_HrPrPorc;

public
TimeTypeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.TT_TmType = reader.GetString("TT_TmType");
	this.TT_DirInd = reader.GetString("TT_DirIndLbr");
	this.TT_DeptLoc = reader.GetString("TT_DeptLoc");
	this.TT_DeptAsg = reader.GetString("TT_DeptAsg");
	this.TT_DRS = reader.GetString("TT_DRS");
	this.TT_SchYN = reader.GetString("TT_SchYN");
	this.TT_UseProdID = reader.GetString("TT_UseProdID");
	this.TT_Des = reader.GetString("TT_Des");
	this.TT_Color = reader.GetString("TT_Color");
	this.TT_HrPrPorc = reader.GetDecimal("TT_HrPrPorc");
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
void setTT_TmType(string TT_TmType){
	this.TT_TmType = TT_TmType;
}

public
void setTT_DirInd(string TT_DirInd){
	this.TT_DirInd = TT_DirInd;
}

public
void setTT_DeptLoc(string TT_DeptLoc){
	this.TT_DeptLoc = TT_DeptLoc;
}

public
void setTT_DeptAsg(string TT_DeptAsg){
	this.TT_DeptAsg = TT_DeptAsg;
}

public
void setTT_DRS(string TT_DRS){
	this.TT_DRS = TT_DRS;
}

public
void setTT_SchYN(string TT_SchYN){
	this.TT_SchYN = TT_SchYN;
}

public
void setTT_UseProdID(string TT_UseProdID){
	this.TT_UseProdID = TT_UseProdID;
}

public
void setTT_Des(string TT_Des){
	this.TT_Des = TT_Des;
}

public
void setTT_Color(string TT_Color){
	this.TT_Color = TT_Color;
}

public
void setTT_HrPrPorc(decimal TT_HrPrPorc){
	this.TT_HrPrPorc = TT_HrPrPorc;
}

public
string getTT_TmType(){
	return TT_TmType;
}

public
string getTT_DirInd(){
	return TT_DirInd;
}

public
string getTT_DeptLoc(){
	return TT_DeptLoc;
}

public
string getTT_DeptAsg(){
	return TT_DeptAsg;
}

public
string getTT_DRS(){
	return TT_DRS;
}

public
string getTT_SchYN(){
	return TT_SchYN;
}

public
string getTT_UseProdID(){
	return TT_UseProdID;
}

public
string getTT_Des(){
	return TT_Des;
}

public
string getTT_Color(){
	return TT_Color;
}

public
decimal getTT_HrPrPorc(){
	return TT_HrPrPorc;
}

} // class

} // namespace