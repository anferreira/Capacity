using System;


namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class Plt : MarshalByRefObject{

private string sdb;
private int		icompany;
private string splant;
private string spltName;
private string spltShort;
private DateTime dateUpdated;
private string  saddress;
private string sdftForSalesForecast;
private string stimezone;
private string sdftReceivetoStkRoom;
private string sintransit;
private string soutsideServiceStkRoom;
private string shipFromStkLoc;
private string sprodFulFillmentGrp;
private string sdistFulFillmentGrp;
private string swhsStorageGrp;
private string soutsideStorageGrp;


public 
Plt(){
}

public 
Plt(string sdb,int icompany, string splant, string spltName,
		string spltShort, DateTime dateUpdated, string saddress,
		string sdftForSalesForecast, string stimezone, string sdftReceivetoStkRoom,
		string sintransit, string soutsideServiceStkRoom, string shipFromStkLoc,
		string sprodFulFillmentGrp, string sdistFulFillmentGrp,
		string swhsStorageGrp, string soutsideStorageGrp){
	
	this.sdb = sdb;
	this.icompany = icompany;
	this.splant = splant;
	this.spltName = spltName;
	this.spltShort = spltShort;
	this.dateUpdated = dateUpdated; 
	this.saddress = saddress;
	this.sdftForSalesForecast = sdftForSalesForecast;
	this.stimezone = stimezone;
	this.sdftReceivetoStkRoom = sdftReceivetoStkRoom;
	this.sintransit = sintransit;
	this.soutsideServiceStkRoom = soutsideServiceStkRoom;
	this.shipFromStkLoc = shipFromStkLoc;
	this.sprodFulFillmentGrp = sprodFulFillmentGrp;
	this.swhsStorageGrp = swhsStorageGrp;
	this.soutsideStorageGrp = soutsideStorageGrp;
	this.sdistFulFillmentGrp = sdistFulFillmentGrp;	
}

public
void setDb(string sdb){
	this.sdb = sdb;
}

public
void setCompany(int icompany){
	this.icompany = icompany;
}

public
void setPlant(string splant){
	this.splant = splant;
}

public
void setPltName(string spltName){
	this.spltName = spltName;
}

public
void setPltShort(string spltShort){
	this.spltShort = spltShort;
}

public
void setDateUpdated(DateTime dateUpdated){
	this.dateUpdated = dateUpdated;
}

public
void setAddress(string saddress){
	this.saddress = saddress;
}

public
void setDftForSalesForecast(string sdftForSalesForecast){
	this.sdftForSalesForecast = sdftForSalesForecast;
}

public
void setTimezone(string stimezone){
	this.stimezone = stimezone;
}

public
void setDftReceivetoStkRoom(string sdftReceivetoStkRoom){
	this.sdftReceivetoStkRoom = sdftReceivetoStkRoom;
}

public
void setIntransit(string sintransit){
	this.sintransit = sintransit;
}

public
void setOutsideServiceStkRoom(string soutsideServiceStkRoom){
	this.soutsideServiceStkRoom = soutsideServiceStkRoom;
}

public
void setShipFromStkLoc(string shipFromStkLoc){
	this.shipFromStkLoc = shipFromStkLoc;
}

public
void setProdFulFillmentGrp(string sprodFulFillmentGrp){
	this.sprodFulFillmentGrp = sprodFulFillmentGrp;
}

public
void setWhsStorageGrp(string swhsStorageGrp){
	this.swhsStorageGrp = swhsStorageGrp;
}

public
void setOutsideStorageGrp(string soutsideStorageGrp){
	this.soutsideStorageGrp = soutsideStorageGrp;
}

public
void setDistFulFillmentGrp(string sdistFulFillmentGrp){
	this.sdistFulFillmentGrp = sdistFulFillmentGrp;
}

public
string getDb(){
	return sdb;
}

public
int getCompany(){
	return icompany;
}

public
string getPlant(){
	return splant;
}

public
string getPltName(){
	return spltName;
}

public
string getPltShort(){
	return spltShort;
}

public
DateTime getDateUpdated(){
	return dateUpdated;
}

public
string getAddress(){
	return saddress;
}

public
string getDftForSalesForecast(){
	return sdftForSalesForecast;
}

public
string getTimezone(){
	return stimezone;
}

public
string getDftReceivetoStkRoom(){
	return sdftReceivetoStkRoom;
}

public
string getIntransit(){
	return sintransit;
}

public
string getOutsideServiceStkRoom(){
	return soutsideServiceStkRoom;
}

public
string getShipFromStkLoc(){
	return shipFromStkLoc;
}

public
string getProdFulFillmentGrp(){
	return sprodFulFillmentGrp;
}

public
string getWhsStorageGrp(){
	return swhsStorageGrp;
}

public
string getOutsideStorageGrp(){
	return soutsideStorageGrp;
}

public
string getDistFulFillmentGrp(){
	return sdistFulFillmentGrp;
}

} // class

} // namespace
