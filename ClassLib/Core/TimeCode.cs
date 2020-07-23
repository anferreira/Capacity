using System;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.Core{

public 
class TimeCode{

private string tmType;
private string dirIndLbr;
private string deptLoc;
private string deptAsg;
private string drs;
private string schYN;
private string useProdID;
private string des;
private string color;
private decimal hrPrPorc;


public 
TimeCode(string tmType, string dirIndLbr, string deptLoc, string deptAsg, string drs, 
		 string schYN, string useProdID, string des, string color, decimal hrPrPorc){
	this.tmType = tmType;
	this.dirIndLbr = dirIndLbr;
	this.deptLoc = deptLoc;
	this.deptAsg = deptAsg;
	this.drs = drs;
	this.schYN = schYN;
	this.useProdID = useProdID;
	this.des = des;
	this.color = color;
	this.hrPrPorc = hrPrPorc;
}

public
TimeCode(){
	this.tmType = "";
	this.dirIndLbr = "";
	this.deptLoc = "";
	this.deptAsg = "";
	this.drs = "";
	this.schYN = "";
	this.useProdID = "";
	this.des = "";
	this.color = "";
	this.hrPrPorc = 0M;
}

public
void setTmType (string tmType){
	this.tmType = tmType;
}

public
void setDirIndLbr (string dirIndLbr){
	this.dirIndLbr = dirIndLbr;
}

public
void setDeptLoc (string deptLoc){
	this.deptLoc = deptLoc;
}

public
void setDeptAsg (string deptAsg){
	this.deptAsg = deptAsg;
}

public
void setDrs (string drs){
	this.drs = drs;
}

public
void setSchYN (string schYN){
	this.schYN = schYN;
}

public
void setUseProdID (string useProdID){
	this.useProdID = useProdID;
}

public
void setDes (string des){
	this.des = des;
}

public
void setColor (string color){
	this.color = color;
}

public
void setHrPrPorc (decimal hrPrPorc){
	this.hrPrPorc = hrPrPorc;
}

public
string getTmType(){
	return tmType;
}

public
string getDirIndLbr(){
	return dirIndLbr;
}

public
string getDeptLoc(){
	return deptLoc;
}

public
string getDeptAsg(){
	return deptAsg;
}

public
string getDrs(){
	return drs;
}

public
string getSchYN(){
	return schYN;
}

public
string getUseProdID(){
	return useProdID;
}

public
string getDes(){
	return des;
}

public
string getColor(){
	return color;
}

public
decimal getHrPrPorc(){
	return hrPrPorc;
}

} // class

} // namespace
