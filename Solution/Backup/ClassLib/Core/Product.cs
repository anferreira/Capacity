using System;


namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class Product : MarshalByRefObject{

private string prodID;
private string db;
private string des1;
private string des2;
private string des3;
private string varFam;
private int seqLast;
private string actIDLast;
private string famProd;
private string partType;
private string invStatus;
private string aBCCode;
private string majorGroup;
private string minorGroup;
private string gLExp;
private string gLDistr;
private string majorSales;
private string minorSales;
private DateTime lastRevision;
private string retailProductType;
private decimal stdPackSize;
private string stdPackUnit;
private string prodCode;

public 
Product(){
}

public 
Product(string prodID,string db, string des1, string des2,
		string des3, string varFam, int seqLast,
		string actIDLast, string famProd, string partType,
		string invStatus, string aBCCode, string majorGroup,
		string minorGroup, string gLExp, string gLDistr,
		string majorSales, string minorSales, DateTime lastRevision,
		string retailProductType, decimal stdPackSize, string stdPackUnit, string prodCode){
	
	this.prodID = prodID;
	this.db = db;
	this.des1 = des1;
	this.des2 = des2;
	this.des3 = des3;
	this.varFam = varFam; 
	this.seqLast = seqLast;
	this.actIDLast = actIDLast;
	this.famProd = famProd;
	this.partType = partType;
	this.invStatus = invStatus;
	this.aBCCode = aBCCode;
	this.majorGroup = majorGroup;
	this.minorGroup = minorGroup;
	this.gLExp = gLExp;
	this.gLDistr = gLDistr;
	this.majorSales = majorSales;
	this.minorSales = minorSales;
	this.lastRevision = lastRevision;
	this.retailProductType = retailProductType;
	this.stdPackSize = stdPackSize;
	this.stdPackUnit = stdPackUnit;
	this.prodCode = prodCode;
}

public
void setProdID(string prodID){
	this.prodID = prodID;
}

public
void setDb(string Db){
	this.db = db;
}

public
void setDes1(string des1){
	this.des1 = des1;
}

public
void setDes2(string des2){
	this.des2 = des2;
}

public
void setDes3(string des3){
	this.des3 = des3;
}

public
void setVarFam(string varFam){
	this.varFam = varFam;
}

public
void setSeqLast(int seqLast){
	this.seqLast = seqLast;
}

public
void setActIDLast(string actIDLast){
	this.actIDLast = actIDLast;
}

public
void setFamProd(string famProd){
	this.famProd = famProd;
}

public
void setPartType(string partType){
	this.partType = partType;
}

public
void setInvStatus(string invStatus){
	this.invStatus = invStatus;
}

public
void setABCCode(string aBCCode){
	this.aBCCode = aBCCode;
}

public
void setMajorGroup(string majorGroup){
	this.majorGroup = majorGroup;
}

public
void setMinorGroup(string minorGroup){
	this.minorGroup = minorGroup;
}

public
void setGLExp(string gLExp){
	this.gLExp = gLExp;
}

public
void setGLDistr(string gLDistr){
	this.gLDistr = gLDistr;
}

public
void setMajorSales(string majorSales){
	this.majorSales = majorSales;
}

public
void setMinorSales(string minorSales){
	this.minorSales = minorSales;
}

public
void setLastRevision(DateTime lastRevision){
	this.lastRevision = lastRevision;
}

public
void setRetailProductType(string retailProductType){
	this.retailProductType = retailProductType;
}

public
void setStdPackSize(decimal stdPackSize){
	this.stdPackSize = stdPackSize;
}

public
void setStdPackUnit(string stdPackUnit){
	this.stdPackUnit = stdPackUnit;
}

public
void setProdCode(string prodCode){
	this.prodCode = prodCode;
}

public
string getProdID(){
	return prodID;
}

public
string getDb(){
	return db;
}

public
string getDes1(){
	return des1;
}

public
string getDes2(){
	return des2;
}

public
string getDes3(){
	return des3;
}

public
string getVarFam(){
	return varFam;
}

public
int getSeqLast(){
	return seqLast;
}

public
string getActIDLast(){
	return actIDLast;
}

public
string getFamProd(){
	return famProd;
}

public
string getPartType(){
	return partType;
}

public
string getInvStatus(){
	return invStatus;
}

public
string getABCCode(){
	return aBCCode;
}

public
string getMajorGroup(){
	return majorGroup;
}

public
string getMinorGroup(){
	return minorGroup;
}

public
string getGLExp(){
	return gLExp;
}

public
string getGLDistr(){
	return gLDistr;
}

public
string getMajorSales(){
	return majorSales;
}

public
string getMinorSales(){
	return minorSales;
}

public
DateTime getLastRevision(){
	return lastRevision;
}

public
string getRetailProductType(){
	return retailProductType;
}

public
decimal getStdPackSize(){
	return stdPackSize;
}

public
string getStdPackUnit(){
	return stdPackUnit;
}

public
string getProdCode(){
	return prodCode;
}

} // class

} // namespace
