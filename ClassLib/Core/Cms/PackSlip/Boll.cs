using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{

[System.Runtime.Serialization.DataContract]
public
class Boll : BusinessObject{

private decimal qUBOL;
private decimal qUENT;
private decimal qUSEQ;
private decimal qUQTSH;
private string qULOTN;
private string qULOTR;
private string qUSERT;
private decimal qUSERN;
private string qUCONC;
private string qUCONS;
private string qUCORG;
private string qUSPRT;
private string qUSUNT;
private string qUFUTA;
private string qUFUTB;
private string qUFUTC;
private string qUFUTD;
private decimal qUFUT1;
private decimal qUFUT2;

internal
Boll(){
	this.qUBOL = 0;
	this.qUENT = 0;
	this.qUSEQ = 0;
	this.qUQTSH = 0;
	this.qULOTN = "";
	this.qULOTR = "";
	this.qUSERT = "";
	this.qUSERN = 0;
	this.qUCONC = "";
	this.qUCONS = "";
	this.qUCORG = "";
	this.qUSPRT = "";
	this.qUSUNT = "";
	this.qUFUTA = "";
	this.qUFUTB = "";
	this.qUFUTC = "";
	this.qUFUTD = "";
	this.qUFUT1 = 0;
	this.qUFUT2 = 0;
}

internal
Boll(
				decimal qUBOL,
				decimal qUENT,
				decimal qUSEQ,
				decimal qUQTSH,
				string qULOTN,
				string qULOTR,
				string qUSERT,
				decimal qUSERN,
				string qUCONC,
				string qUCONS,
				string qUCORG,
				string qUSPRT,
				string qUSUNT,
				string qUFUTA,
				string qUFUTB,
				string qUFUTC,
				string qUFUTD,
				decimal qUFUT1,
				decimal qUFUT2)
{
	this.qUBOL = qUBOL;
	this.qUENT = qUENT;
	this.qUSEQ = qUSEQ;
	this.qUQTSH = qUQTSH;
	this.qULOTN = qULOTN;
	this.qULOTR = qULOTR;
	this.qUSERT = qUSERT;
	this.qUSERN = qUSERN;
	this.qUCONC = qUCONC;
	this.qUCONS = qUCONS;
	this.qUCORG = qUCORG;
	this.qUSPRT = qUSPRT;
	this.qUSUNT = qUSUNT;
	this.qUFUTA = qUFUTA;
	this.qUFUTB = qUFUTB;
	this.qUFUTC = qUFUTC;
	this.qUFUTD = qUFUTD;
	this.qUFUT1 = qUFUT1;
	this.qUFUT2 = qUFUT2;
}

public
void setQUBOL(decimal qUBOL){
	this.qUBOL = qUBOL;
}

public
void setQUENT(decimal qUENT){
	this.qUENT = qUENT;
}

public
void setQUSEQ(decimal qUSEQ){
	this.qUSEQ = qUSEQ;
}

public
void setQUQTSH(decimal qUQTSH){
	this.qUQTSH = qUQTSH;
}

public
void setQULOTN(string qULOTN){
	this.qULOTN = qULOTN;
}

public
void setQULOTR(string qULOTR){
	this.qULOTR = qULOTR;
}

public
void setQUSERT(string qUSERT){
	this.qUSERT = qUSERT;
}

public
void setQUSERN(decimal qUSERN){
	this.qUSERN = qUSERN;
}

public
void setQUCONC(string qUCONC){
	this.qUCONC = qUCONC;
}

public
void setQUCONS(string qUCONS){
	this.qUCONS = qUCONS;
}

public
void setQUCORG(string qUCORG){
	this.qUCORG = qUCORG;
}

public
void setQUSPRT(string qUSPRT){
	this.qUSPRT = qUSPRT;
}

public
void setQUSUNT(string qUSUNT){
	this.qUSUNT = qUSUNT;
}

public
void setQUFUTA(string qUFUTA){
	this.qUFUTA = qUFUTA;
}

public
void setQUFUTB(string qUFUTB){
	this.qUFUTB = qUFUTB;
}

public
void setQUFUTC(string qUFUTC){
	this.qUFUTC = qUFUTC;
}

public
void setQUFUTD(string qUFUTD){
	this.qUFUTD = qUFUTD;
}

public
void setQUFUT1(decimal qUFUT1){
	this.qUFUT1 = qUFUT1;
}

public
void setQUFUT2(decimal qUFUT2){
	this.qUFUT2 = qUFUT2;
}

public
decimal getQUBOL(){
	 return qUBOL;
}

public
decimal getQUENT(){
	 return qUENT;
}

public
decimal getQUSEQ(){
	 return qUSEQ;
}

public
decimal getQUQTSH(){
	 return qUQTSH;
}

public
string getQULOTN(){
	 return qULOTN;
}

public
string getQULOTR(){
	 return qULOTR;
}

public
string getQUSERT(){
	 return qUSERT;
}

public
decimal getQUSERN(){
	 return qUSERN;
}

public
string getQUCONC(){
	 return qUCONC;
}

public
string getQUCONS(){
	 return qUCONS;
}

public
string getQUCORG(){
	 return qUCORG;
}

public
string getQUSPRT(){
	 return qUSPRT;
}

public
string getQUSUNT(){
	 return qUSUNT;
}

public
string getQUFUTA(){
	 return qUFUTA;
}

public
string getQUFUTB(){
	 return qUFUTB;
}

public
string getQUFUTC(){
	 return qUFUTC;
}

public
string getQUFUTD(){
	 return qUFUTD;
}

public
decimal getQUFUT1(){
	 return qUFUT1;
}

public
decimal getQUFUT2(){
	 return qUFUT2;
}

public override
bool Equals(object obj){
	if (obj is Boll)
		return	this.qUBOL.Equals(((Boll)obj).getQUBOL()) &&
				this.qUENT.Equals(((Boll)obj).getQUENT()) &&
				this.qUSEQ.Equals(((Boll)obj).getQUSEQ());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // package