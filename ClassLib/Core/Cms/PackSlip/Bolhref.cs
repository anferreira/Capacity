using System;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer;


namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{

[System.Runtime.Serialization.DataContract]
public
class Bolhref {

private decimal x1BOLH;
private string x1CMPFLG;
private DateTime x1UPDDATE;

internal
Bolhref(){
	this.x1BOLH = 0;
	this.x1CMPFLG = "";
	this.x1UPDDATE = DateUtil.MinValue;
}

internal
Bolhref(
				decimal x1BOLH,
				string x1CMPFLG,
				DateTime x1UPDDATE)
{
	this.x1BOLH = x1BOLH;
	this.x1CMPFLG = x1CMPFLG;
	this.x1UPDDATE = x1UPDDATE;
}

public
void setX1BOLH(decimal x1BOLH){
	this.x1BOLH = x1BOLH;
}

public
void setX1CMPFLG(string x1CMPFLG){
	this.x1CMPFLG = x1CMPFLG;
}

public
void setX1UPDDATE(DateTime x1UPDDATE){
	this.x1UPDDATE = x1UPDDATE;
}

public
decimal getX1BOLH(){
	 return x1BOLH;
}

public
string getX1CMPFLG(){
	 return x1CMPFLG;
}

public
DateTime getX1UPDDATE(){
	 return x1UPDDATE;
}

public override
bool Equals(object obj){
	if (obj is Bolhref)
		return	this.x1BOLH.Equals(((Bolhref)obj).getX1BOLH());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // package