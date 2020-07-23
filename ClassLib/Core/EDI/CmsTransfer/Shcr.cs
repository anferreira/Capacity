using System;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer{

[System.Runtime.Serialization.DataContract]
public
class Shcr {

private string rMCARC;
private string rMDES1;
private decimal rMADR;
private string rMCONT;
private string rMSCAC;
private string rMVEND;
private string rMTRPT;
private string rMBOLS;
private decimal rMFUT1;
private string rMFUT2;
private string rMFUT3;
private string rMFUT4;
private string rMFUT5;
private string rMFUT6;
private string rMFUT7;
private string rMFUT8;
private string rMFUT9;

internal
Shcr(){
	this.rMCARC = "";
	this.rMDES1 = "";
	this.rMADR = 0;
	this.rMCONT = "";
	this.rMSCAC = "";
	this.rMVEND = "";
	this.rMTRPT = "";
	this.rMBOLS = "";
	this.rMFUT1 = 0;
	this.rMFUT2 = "";
	this.rMFUT3 = "";
	this.rMFUT4 = "";
	this.rMFUT5 = "";
	this.rMFUT6 = "";
	this.rMFUT7 = "";
	this.rMFUT8 = "";
	this.rMFUT9 = "";
}

internal
Shcr(
				string rMCARC,
				string rMDES1,
				decimal rMADR,
				string rMCONT,
				string rMSCAC,
				string rMVEND,
				string rMTRPT,
				string rMBOLS,
				decimal rMFUT1,
				string rMFUT2,
				string rMFUT3,
				string rMFUT4,
				string rMFUT5,
				string rMFUT6,
				string rMFUT7,
				string rMFUT8,
				string rMFUT9)
{
	this.rMCARC = rMCARC;
	this.rMDES1 = rMDES1;
	this.rMADR = rMADR;
	this.rMCONT = rMCONT;
	this.rMSCAC = rMSCAC;
	this.rMVEND = rMVEND;
	this.rMTRPT = rMTRPT;
	this.rMBOLS = rMBOLS;
	this.rMFUT1 = rMFUT1;
	this.rMFUT2 = rMFUT2;
	this.rMFUT3 = rMFUT3;
	this.rMFUT4 = rMFUT4;
	this.rMFUT5 = rMFUT5;
	this.rMFUT6 = rMFUT6;
	this.rMFUT7 = rMFUT7;
	this.rMFUT8 = rMFUT8;
	this.rMFUT9 = rMFUT9;
}

public
void setRMCARC(string rMCARC){
	this.rMCARC = rMCARC;
}

public
void setRMDES1(string rMDES1){
	this.rMDES1 = rMDES1;
}

public
void setRMADR(decimal rMADR){
	this.rMADR = rMADR;
}

public
void setRMCONT(string rMCONT){
	this.rMCONT = rMCONT;
}

public
void setRMSCAC(string rMSCAC){
	this.rMSCAC = rMSCAC;
}

public
void setRMVEND(string rMVEND){
	this.rMVEND = rMVEND;
}

public
void setRMTRPT(string rMTRPT){
	this.rMTRPT = rMTRPT;
}

public
void setRMBOLS(string rMBOLS){
	this.rMBOLS = rMBOLS;
}

public
void setRMFUT1(decimal rMFUT1){
	this.rMFUT1 = rMFUT1;
}

public
void setRMFUT2(string rMFUT2){
	this.rMFUT2 = rMFUT2;
}

public
void setRMFUT3(string rMFUT3){
	this.rMFUT3 = rMFUT3;
}

public
void setRMFUT4(string rMFUT4){
	this.rMFUT4 = rMFUT4;
}

public
void setRMFUT5(string rMFUT5){
	this.rMFUT5 = rMFUT5;
}

public
void setRMFUT6(string rMFUT6){
	this.rMFUT6 = rMFUT6;
}

public
void setRMFUT7(string rMFUT7){
	this.rMFUT7 = rMFUT7;
}

public
void setRMFUT8(string rMFUT8){
	this.rMFUT8 = rMFUT8;
}

public
void setRMFUT9(string rMFUT9){
	this.rMFUT9 = rMFUT9;
}

public
string getRMCARC(){
	 return rMCARC;
}

public
string getRMDES1(){
	 return rMDES1;
}

public
decimal getRMADR(){
	 return rMADR;
}

public
string getRMCONT(){
	 return rMCONT;
}

public
string getRMSCAC(){
	 return rMSCAC;
}

public
string getRMVEND(){
	 return rMVEND;
}

public
string getRMTRPT(){
	 return rMTRPT;
}

public
string getRMBOLS(){
	 return rMBOLS;
}

public
decimal getRMFUT1(){
	 return rMFUT1;
}

public
string getRMFUT2(){
	 return rMFUT2;
}

public
string getRMFUT3(){
	 return rMFUT3;
}

public
string getRMFUT4(){
	 return rMFUT4;
}

public
string getRMFUT5(){
	 return rMFUT5;
}

public
string getRMFUT6(){
	 return rMFUT6;
}

public
string getRMFUT7(){
	 return rMFUT7;
}

public
string getRMFUT8(){
	 return rMFUT8;
}

public
string getRMFUT9(){
	 return rMFUT9;
}

public override
bool Equals(object obj){
	if (obj is Shcr)
		return	this.rMCARC.Equals(((Shcr)obj).getRMCARC());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // package