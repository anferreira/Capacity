using System;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class CapacityVersion : MarshalByRefObject{

private string plt;
private string version;
private string status;
private string sett;
private DateTime dtStart;
private DateTime dtEnd;
private DateTime dtCreat;
private string userCr;
private DateTime dtUpdate;
private string userUp;

public 
CapacityVersion(){
}

public 
CapacityVersion(string plt, string version, string status, string sett,
		DateTime dtStart, DateTime dtEnd, DateTime dtCreat, string userCr,
		DateTime dtUpdate, string userUp){
	
	this.plt = plt;
	this.version = version;
	this.status = status;
	this.sett = sett;
	this.dtStart = dtStart;
	this.dtEnd = dtEnd;
	this.dtCreat = dtCreat;
	this.userCr = userCr;
	this.dtUpdate = dtUpdate;
	this.userUp = userUp;
}

public
void setPlt(string plt){
	this.plt = plt;
}

public
void setVersion(string version){
	this.version = version;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setSett(string sett){
	this.sett = sett;
}

public
void setDtStart(DateTime dtStart){
	this.dtStart = dtStart;
}

public
void setDtEnd(DateTime dtEnd){
	this.dtEnd = dtEnd;
}

public
void setDtCreat(DateTime dtCreat){
	this.dtCreat = dtCreat;
}

public
void setUserCr(string userCr){
	this.userCr = userCr;
}

public
void setDtUpdate(DateTime dtUpdate){
	this.dtUpdate = dtUpdate;
}

public
void setUserUp(string userUp){
	this.userUp = userUp;
}



public
string getPlt(){
	return plt;
}

public
string getVersion(){
	return version;
}

public
string getStatus(){
	return status;
}

public
string getSett(){
	return sett;
}

public
DateTime getDtStart(){
	return dtStart;
}

public
DateTime getDtEnd(){
	return dtEnd;
}

public
DateTime getDtCreat(){
	return dtCreat;
}

public
string getUserCr(){
	return userCr;
}

public
DateTime getDtUpdate(){
	return dtUpdate;
}

public
string getUserUp(){
	return userUp;
}


} // class

} // namespace
