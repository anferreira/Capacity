using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class RewProdIDDataBase : GenericDataBaseElement{

private string REWP_ReworkID;
private string REWP_ProdID;
private int REWP_Seq;
private string REWP_ActID;
private string REWP_Dept;
private string REWP_Mach;
private decimal REWP_LabHrs;
private decimal REWP_LabNum;
private string REWP_LabType;
private string REWP_RetProdID;
private int REWP_RetSeq;
private string REWP_RetActID;
private decimal REWP_RetPer;
private decimal REWP_ScrPer;

public
RewProdIDDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.REWP_ReworkID = reader.GetString("REWP_ReworkID");
	this.REWP_ProdID = reader.GetString("REWP_ProdID");
	this.REWP_Seq = reader.GetInt32("REWP_Seq");
	this.REWP_ActID = reader.GetString("REWP_ActID");
	this.REWP_Dept = reader.GetString("REWP_Dept");
	this.REWP_Mach = reader.GetString("REWP_Mach");
	this.REWP_LabHrs = reader.GetDecimal("REWP_LabHrs");
	this.REWP_LabNum = reader.GetDecimal("REWP_LabNum");
	this.REWP_LabType = reader.GetString("REWP_LabType");
	this.REWP_RetProdID = reader.GetString("REWP_RetProdID");
	this.REWP_RetSeq = reader.GetInt32("REWP_RetSeq");
	this.REWP_RetActID = reader.GetString("REWP_RetActID");
	this.REWP_RetPer = reader.GetDecimal("REWP_RetPer");
	this.REWP_ScrPer = reader.GetDecimal("REWP_ScrPer");
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
void setREWP_ReworkID(string REWP_ReworkID){
	this.REWP_ReworkID = REWP_ReworkID;
}

public
void setREWP_ProdID(string REWP_ProdID){
	this.REWP_ProdID = REWP_ProdID;
}

public
void setREWP_Seq(int REWP_Seq){
	this.REWP_Seq = REWP_Seq;
}

public
void setREWP_ActID(string REWP_ActID){
	this.REWP_ActID = REWP_ActID;
}

public
void setREWP_Dept(string REWP_Dept){
	this.REWP_Dept = REWP_Dept;
}

public
void setREWP_Mach(string REWP_Mach){
	this.REWP_Mach = REWP_Mach;
}

public
void setREWP_LabHrs(decimal REWP_LabHrs){
	this.REWP_LabHrs = REWP_LabHrs;
}

public
void setREWP_LabNum(decimal REWP_LabNum){
	this.REWP_LabNum = REWP_LabNum;
}

public
void setREWP_LabType(string REWP_LabType){
	this.REWP_LabType = REWP_LabType;
}

public
void setREWP_RetProdID(string REWP_RetProdID){
	this.REWP_RetProdID = REWP_RetProdID;
}

public
void setREWP_RetSeq(int REWP_RetSeq){
	this.REWP_RetSeq = REWP_RetSeq;
}

public
void setREWP_RetActID(string REWP_RetActID){
	this.REWP_RetActID = REWP_RetActID;
}

public
void setREWP_RetPer(decimal REWP_RetPer){
	this.REWP_RetPer = REWP_RetPer;
}

public
void setREWP_ScrPer(decimal REWP_ScrPer){
	this.REWP_ScrPer = REWP_ScrPer;
}


public
string getREWP_ReworkID(){
	return REWP_ReworkID;
}

public
string getREWP_ProdID(){
	return REWP_ProdID;
}

public
int getREWP_Seq(){
	return REWP_Seq;
}

public
string getREWP_ActID(){
	return REWP_ActID;
}

public
string getREWP_Dept(){
	return REWP_Dept;
}

public
string getREWP_Mach(){
	return REWP_Mach;
}

public
decimal getREWP_LabHrs(){
	return REWP_LabHrs;
}

public
decimal getREWP_LabNum(){
	return REWP_LabNum;
}

public
string getREWP_LabType(){
	return REWP_LabType;
}

public
string getREWP_RetProdID(){
	return REWP_RetProdID;
}

public
int getREWP_RetSeq(){
	return REWP_RetSeq;
}

public
string getREWP_RetActID(){
	return REWP_RetActID;
}

public
decimal getREWP_RetPer(){
	return REWP_RetPer;
}

public
decimal getREWP_ScrPer(){
	return REWP_ScrPer;
}


} // class

} // namespace