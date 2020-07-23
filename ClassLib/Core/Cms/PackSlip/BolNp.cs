using System;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer;


namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{


[System.Runtime.Serialization.DataContract]
public
class BolNp {

private string gGKEY;
private decimal gGPAG;
private decimal gGLIN;
private string gGTEXT;
private string gGFUT1;
private string gGFUT2;
private string gGFUT3;
private string gGFUT4;
private string gGFUT5;

internal
BolNp(){
	this.gGKEY = "";
	this.gGPAG = 0;
	this.gGLIN = 0;
	this.gGTEXT = "";
	this.gGFUT1 = "";
	this.gGFUT2 = "";
	this.gGFUT3 = "";
	this.gGFUT4 = "";
	this.gGFUT5 = "";
}

internal
BolNp(
				string gGKEY,
				decimal gGPAG,
				decimal gGLIN,
				string gGTEXT,
				string gGFUT1,
				string gGFUT2,
				string gGFUT3,
				string gGFUT4,
				string gGFUT5)
{
	this.gGKEY = gGKEY;
	this.gGPAG = gGPAG;
	this.gGLIN = gGLIN;
	this.gGTEXT = gGTEXT;
	this.gGFUT1 = gGFUT1;
	this.gGFUT2 = gGFUT2;
	this.gGFUT3 = gGFUT3;
	this.gGFUT4 = gGFUT4;
	this.gGFUT5 = gGFUT5;
}

public
void setGGKEY(string gGKEY){
	this.gGKEY = gGKEY;
}

public
void setGGPAG(decimal gGPAG){
	this.gGPAG = gGPAG;
}

public
void setGGLIN(decimal gGLIN){
	this.gGLIN = gGLIN;
}

public
void setGGTEXT(string gGTEXT){
	this.gGTEXT = gGTEXT;
}

public
void setGGFUT1(string gGFUT1){
	this.gGFUT1 = gGFUT1;
}

public
void setGGFUT2(string gGFUT2){
	this.gGFUT2 = gGFUT2;
}

public
void setGGFUT3(string gGFUT3){
	this.gGFUT3 = gGFUT3;
}

public
void setGGFUT4(string gGFUT4){
	this.gGFUT4 = gGFUT4;
}

public
void setGGFUT5(string gGFUT5){
	this.gGFUT5 = gGFUT5;
}

public
string getGGKEY(){
	 return gGKEY;
}

public
decimal getGGPAG(){
	 return gGPAG;
}

public
decimal getGGLIN(){
	 return gGLIN;
}

public
string getGGTEXT(){
	 return gGTEXT;
}

public
string getGGFUT1(){
	 return gGFUT1;
}

public
string getGGFUT2(){
	 return gGFUT2;
}

public
string getGGFUT3(){
	 return gGFUT3;
}

public
string getGGFUT4(){
	 return gGFUT4;
}

public
string getGGFUT5(){
	 return gGFUT5;
}

public override
bool Equals(object obj){
	if (obj is BolNp)
		return	this.gGKEY.Equals(((BolNp)obj).getGGKEY()) &&
				this.gGPAG.Equals(((BolNp)obj).getGGPAG()) &&
				this.gGLIN.Equals(((BolNp)obj).getGGLIN());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // package