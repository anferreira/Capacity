using System;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class Plant : MarshalByRefObject{

private string plt;
private string name;
private string ads1;
private string ads2;
private string ads3;
private string ads4;
private string pltShort;
private DateTime dateUpdated;

public 
Plant(){
}

public
Plant(string plt, string name, string ads1, string ads2,
		string ads3, string ads4, string pltShort, DateTime dateUpdated){
	
	this.plt = plt;
	this.name = name;
	this.ads1 = ads1;
	this.ads2 = ads2;
	this.ads3 = ads3;
	this.ads4 = ads4;
	this.pltShort = pltShort;
	this.dateUpdated = dateUpdated;
}

public
void setPlt(string plt){
	this.plt = plt;
}

public
void setName(string name){
	this.name = name;
}

public
void setAds1(string ads1){
	this.ads1 = ads1;
}

public
void setAds2(string ads2){
	this.ads2 = ads2;
}

public
void setAds3(string ads3){
	this.ads3 = ads3;
}

public
void setAds4(string ads4){
	this.ads4 = ads4;
}

public
void setPltShort(string pltShort){
	this.pltShort = pltShort;
}

public
void setDateUpdated(DateTime dateUpdated){
	this.dateUpdated = dateUpdated;
}

public
string getPlt(){
	return plt;
}

public
string getName(){
	return name;
}

public
string getAds1(){
	return ads1;
}

public
string getAds2(){
	return ads2;
}

public
string getAds3(){
	return ads3;
}

public
string getAds4(){
	return ads4;
}

public
string getPltShort(){
	return pltShort;
}

public
DateTime getDateUpdated(){
	return dateUpdated;
}

} // class

} // namespace
