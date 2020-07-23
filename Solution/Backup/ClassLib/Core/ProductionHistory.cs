using System;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{

public 
class ProductionHistory : MarshalByRefObject{

	private string		sdb;
	private string		sdept;
	private string		sresr;
	private DateTime	date;
	private double		dshft;
	private string		smode;
	private string		sref;
	private double		dseqn;
	private double		dtime;
	private string		spart;
	private double		dqtyc;
	private double		dqtys;
	private double		drate;
	private string		sgrp;
	private string		smajg;
	private double		dfsyy;
	private double		dfspp;
	private double		dsprc;
	private decimal		cost;


	//used for the report
	private string		splant;
	private string		sdesc;

	private string		scrapCode;
	private string		scrapDescription;

public 
ProductionHistory(){
	this.sdb = "";
	this.sdept = "";
	this.sresr = "";
	this.date = DateTime.Now;
	this.dshft = 0;
	this.smode = "";
	this.sref = "";
	this.dseqn = 0;
	this.dtime = 0;
	this.spart = "";
	this.dqtyc = 0;
	this.dqtys = 0;
	this.drate = 0;
	this.sgrp = "";
	this.smajg = "";
	this.dfsyy = 0;
	this.dfspp = 0;
	this.dsprc = 0;	

	//used for the report
	this.splant="";
	this.sdesc = "";
	this.cost = 0;

	this.scrapCode = "";
	this.scrapDescription = "";

}

public 
ProductionHistory(string sdb, string sdept, string sresr, DateTime date,
		double dshft, string smode, string sref, double dseqn,
		double dtime, string spart, double dqtyc, double dqtys,
		double drate, string sgrp, string smajg,
		double dfsyy, double dfspp, double dsprc, decimal cost, 
		string splant, string scrapCode, string scrapDescription){

	this.sdb = sdb;
	this.sdept = sdept;
	this.sresr = sresr;
	this.date = date;
	this.dshft = dshft;
	this.smode = smode;
	this.sref = sref;
	this.dseqn = dseqn;
	this.dtime = dtime;
	this.spart = spart;
	this.dqtyc = dqtyc;
	this.dqtys = dqtys;
	this.drate = drate;
	this.sgrp = sgrp;
	this.smajg = smajg;
	this.dfsyy = dfsyy;
	this.dfspp = dfspp;
	this.dsprc = dsprc;
	this.cost = cost;

	this.splant = splant;
	
	this.scrapCode = scrapCode;
	this.scrapDescription = scrapDescription;
}

public
void setDb(string sdb){
	this.sdb = sdb;
}

public
void setDept(string sdept){
	this.sdept = sdept;
}

public
void setResr(string sresr){
	this.sresr = sresr;
}

public
void setDate(DateTime date){
	this.date = date;
}

public
void setShft(double dshft){
	this.dshft = dshft;
}

public
void setMode(string smode){
	this.smode = smode;
}

public
void setRef(string sref){
	this.sref = sref;
}

public
void setSeqn(double dseqn){
	this.dseqn = dseqn;
}

public
void setTime(double dtime){
	this.dtime = dtime;
}

public
void setPart(string spart){
	this.spart = spart;
}

public
void setQtyc(double dqtyc){
	this.dqtyc = dqtyc;
}

public
void setQtys(double dqtys){
	this.dqtys = dqtys;
}

public
void setRate(double drate){
	this.drate = drate;
}

public
void setGrp(string sgrp){
	this.sgrp = sgrp;
}

public
void setMajg(string smajg){
	this.smajg = smajg;
}

public
void setFsyy(double dfsyy){
	this.dfsyy = dfsyy;
}

public
void setFspp(double dfspp){
	this.dfspp = dfspp;
}

public
void setSprc(double dsprc){
	this.dsprc = dsprc;
}

public 
void setPlant(string splant){
	this.splant = splant;
}

public 
void setSDesc(string sdesc){
	this.sdesc = sdesc;
}

public 
void setCost(decimal cost){
	this.cost = cost;
}

public
void setScrapCode(string scrapCode){
	this.scrapCode = scrapCode;
}

public
void setScrapDescription(string scrapDescription){
	this.scrapDescription = scrapDescription;
}


public
string getDb(){
	return sdb;
}

public
string getDept(){
	return sdept;
}

public
string getResr(){
	return sresr;
}

public
DateTime getDate(){
	return date;
}

public
double getShft(){
	return dshft;
}

public
string getMode(){
	return smode;
}

public
string getRef(){
	return sref;
}

public
double getSeqn(){
	return dseqn;
}

public
double getTime(){
	return dtime;
}

public
string getPart(){
	return spart;
}

public
double getQtyc(){
	return dqtyc;
}

public
double getQtys(){
	return dqtys;
}

public
double getRate(){
	return drate;
}

public
string getGrp(){
	return sgrp;
}

public
string getMajg(){
	return smajg;
}

public
double getFsyy(){
	return dfsyy;
}

public
double getFspp(){
	return dfspp;
}

public
double getSprc(){
	return dsprc;
}

public 
string getPlant(){
	return splant;
}

public 
string getSDesc(){
	return sdesc;
}

public 
decimal getCost(){
	return cost;
}

public
string getScrapCode(){
	return scrapCode;
}

public
string getScrapDescription(){
	return scrapDescription;
}


}//end Class

}//end namespace
