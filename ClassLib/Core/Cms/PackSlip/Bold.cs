using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{

[System.Runtime.Serialization.DataContract]
public
class Bold : BusinessObject {

private decimal fGBOL;
private decimal fGENT;
private decimal fGORD;
private decimal fGITEM;
private decimal fGPO;
private decimal fGPREL;
private decimal fGPITM;
private decimal fGQSHP;
private decimal fGQSHO;
private string fGCTNC;
private decimal fGCTNN;
private decimal fGPLTN;
private decimal fGNTWC;
private decimal fGGRSC;
private decimal fGTARC;
private decimal fGVOLC;
private decimal fGQTYC;
private decimal fGWGTP;
private decimal fGVOLP;
private string fGLSTS;
private string fGPART;
private string fGRLNO;
private decimal fGINV;
private decimal fGLIN;
private string fGORUN;
private decimal fGFTAM;
private string fGSTKL;
private string fGRAN;
private string fGCPT;
private string fGCNID;
private string fGECHG;
private decimal fGCCUM;
private decimal fGPCUM;
private string fGCPO;
private string fGCMPR;
private string fGDOCK;
private string fGISTS;
private string fGSREF;
private string fGCRCM;
private string fGUSR1;
private string fGUSR2;
private string fGUSR3;
private decimal fGREQ;
private decimal fGDREQ;
private decimal fGJITD;
private string fGUSR4;
private string fGUSR5;
private string fGFUT1;
private string fGFUT2;
private string fGFUT3;
private string fGFUT4;
private string fGFUT5;
private decimal fGFUTA;
private decimal fGFUTB;
private decimal fGFUTC;
private decimal fGFUTD;
private string fGFUTE;
private string fGFUTF;
private string fGFUTG;
private string fGFUTH;
private string fGFUTI;
private string fGFUTJ;
private string fGFUTK;
private string fGFUTL;
private string fGFUTM;
private string fGFUTN;
private string fGFUTO;
private string fGFUTP;
private string fGFUTQ;
private string fGFUTR;
private string fGFUTS;
private string fGFUTT;

private string fGPSLP;
private decimal fGNWFP;

private BollContainer bollContainer;

private string ediProcessed=Constants.STRING_NO;//only used to resolve the situation when a part belongs to more than 1 detail, so we flag if detail processed or not

internal
Bold(){
	this.fGBOL = 0;
	this.fGENT = 0;
	this.fGORD = 0;
	this.fGITEM = 0;
	this.fGPO = 0;
	this.fGPREL = 0;
	this.fGPITM = 0;
	this.fGQSHP = 0;
	this.fGQSHO = 0;
	this.fGCTNC = "";
	this.fGCTNN = 0;
	this.fGPLTN = 0;
	this.fGNTWC = 0;
	this.fGGRSC = 0;
	this.fGTARC = 0;
	this.fGVOLC = 0;
	this.fGQTYC = 0;
	this.fGWGTP = 0;
	this.fGVOLP = 0;
	this.fGLSTS = "";
	this.fGPART = "";
	this.fGRLNO = "";
	this.fGINV = 0;
	this.fGLIN = 0;
	this.fGORUN = "";
	this.fGFTAM = 0;
	this.fGSTKL = "";
	this.fGRAN = "";
	this.fGCPT = "";
	this.fGCNID = "";
	this.fGECHG = "";
	this.fGCCUM = 0;
	this.fGPCUM = 0;
	this.fGCPO = "";
	this.fGCMPR = "";
	this.fGDOCK = "";
	this.fGISTS = "";
	this.fGSREF = "";
	this.fGCRCM = "";
	this.fGUSR1 = "";
	this.fGUSR2 = "";
	this.fGUSR3 = "";
	this.fGREQ = 0;
	this.fGDREQ = 0;
	this.fGJITD = 0;
	this.fGUSR4 = "";
	this.fGUSR5 = "";
	this.fGFUT1 = "";
	this.fGFUT2 = "";
	this.fGFUT3 = "";
	this.fGFUT4 = "";
	this.fGFUT5 = "";
	this.fGFUTA = 0;
	this.fGFUTB = 0;
	this.fGFUTC = 0;
	this.fGFUTD = 0;
	this.fGFUTE = "";
	this.fGFUTF = "";
	this.fGFUTG = "";
	this.fGFUTH = "";
	this.fGFUTI = "";
	this.fGFUTJ = "";
	this.fGFUTK = "";
	this.fGFUTL = "";
	this.fGFUTM = "";
	this.fGFUTN = "";
	this.fGFUTO = "";
	this.fGFUTP = "";
	this.fGFUTQ = "";
	this.fGFUTR = "";
	this.fGFUTS = "";
	this.fGFUTT = "";
    this.fGPSLP = "";
    this.fGNWFP = 0;
	this.bollContainer = new BollContainer();
}

internal
Bold(
				decimal fGBOL,
				decimal fGENT,
				decimal fGORD,
				decimal fGITEM,
				decimal fGPO,
				decimal fGPREL,
				decimal fGPITM,
				decimal fGQSHP,
				decimal fGQSHO,
				string fGCTNC,
				decimal fGCTNN,
				decimal fGPLTN,
				decimal fGNTWC,
				decimal fGGRSC,
				decimal fGTARC,
				decimal fGVOLC,
				decimal fGQTYC,
				decimal fGWGTP,
				decimal fGVOLP,
				string fGLSTS,
				string fGPART,
				string fGRLNO,
				decimal fGINV,
				decimal fGLIN,
				string fGORUN,
				decimal fGFTAM,
				string fGSTKL,
				string fGRAN,
				string fGCPT,
				string fGCNID,
				string fGECHG,
				decimal fGCCUM,
				decimal fGPCUM,
				string fGCPO,
				string fGCMPR,
				string fGDOCK,
				string fGISTS,
				string fGSREF,
				string fGCRCM,
				string fGUSR1,
				string fGUSR2,
				string fGUSR3,
				decimal fGREQ,
				decimal fGDREQ,
				decimal fGJITD,
				string fGUSR4,
				string fGUSR5,
				string fGFUT1,
				string fGFUT2,
				string fGFUT3,
				string fGFUT4,
				string fGFUT5,
				decimal fGFUTA,
				decimal fGFUTB,
				decimal fGFUTC,
				decimal fGFUTD,
				string fGFUTE,
				string fGFUTF,
				string fGFUTG,
				string fGFUTH,
				string fGFUTI,
				string fGFUTJ,
				string fGFUTK,
				string fGFUTL,
				string fGFUTM,
				string fGFUTN,
				string fGFUTO,
				string fGFUTP,
				string fGFUTQ,
				string fGFUTR,
				string fGFUTS,
				string fGFUTT,
                string fGPSLP,
                decimal fGNWFP,
				BollContainer bollContainer)
{
	this.fGBOL = fGBOL;
	this.fGENT = fGENT;
	this.fGORD = fGORD;
	this.fGITEM = fGITEM;
	this.fGPO = fGPO;
	this.fGPREL = fGPREL;
	this.fGPITM = fGPITM;
	this.fGQSHP = fGQSHP;
	this.fGQSHO = fGQSHO;
	this.fGCTNC = fGCTNC;
	this.fGCTNN = fGCTNN;
	this.fGPLTN = fGPLTN;
	this.fGNTWC = fGNTWC;
	this.fGGRSC = fGGRSC;
	this.fGTARC = fGTARC;
	this.fGVOLC = fGVOLC;
	this.fGQTYC = fGQTYC;
	this.fGWGTP = fGWGTP;
	this.fGVOLP = fGVOLP;
	this.fGLSTS = fGLSTS;
	this.fGPART = fGPART;
	this.fGRLNO = fGRLNO;
	this.fGINV = fGINV;
	this.fGLIN = fGLIN;
	this.fGORUN = fGORUN;
	this.fGFTAM = fGFTAM;
	this.fGSTKL = fGSTKL;
	this.fGRAN = fGRAN;
	this.fGCPT = fGCPT;
	this.fGCNID = fGCNID;
	this.fGECHG = fGECHG;
	this.fGCCUM = fGCCUM;
	this.fGPCUM = fGPCUM;
	this.fGCPO = fGCPO;
	this.fGCMPR = fGCMPR;
	this.fGDOCK = fGDOCK;
	this.fGISTS = fGISTS;
	this.fGSREF = fGSREF;
	this.fGCRCM = fGCRCM;
	this.fGUSR1 = fGUSR1;
	this.fGUSR2 = fGUSR2;
	this.fGUSR3 = fGUSR3;
	this.fGREQ = fGREQ;
	this.fGDREQ = fGDREQ;
	this.fGJITD = fGJITD;
	this.fGUSR4 = fGUSR4;
	this.fGUSR5 = fGUSR5;
	this.fGFUT1 = fGFUT1;
	this.fGFUT2 = fGFUT2;
	this.fGFUT3 = fGFUT3;
	this.fGFUT4 = fGFUT4;
	this.fGFUT5 = fGFUT5;
	this.fGFUTA = fGFUTA;
	this.fGFUTB = fGFUTB;
	this.fGFUTC = fGFUTC;
	this.fGFUTD = fGFUTD;
	this.fGFUTE = fGFUTE;
	this.fGFUTF = fGFUTF;
	this.fGFUTG = fGFUTG;
	this.fGFUTH = fGFUTH;
	this.fGFUTI = fGFUTI;
	this.fGFUTJ = fGFUTJ;
	this.fGFUTK = fGFUTK;
	this.fGFUTL = fGFUTL;
	this.fGFUTM = fGFUTM;
	this.fGFUTN = fGFUTN;
	this.fGFUTO = fGFUTO;
	this.fGFUTP = fGFUTP;
	this.fGFUTQ = fGFUTQ;
	this.fGFUTR = fGFUTR;
	this.fGFUTS = fGFUTS;
	this.fGFUTT = fGFUTT;
    this.fGPSLP = fGPSLP;
    this.fGNWFP = fGNWFP;
	this.bollContainer = bollContainer;
}

public
void setFGBOL(decimal fGBOL){
	this.fGBOL = fGBOL;
}

public
void setFGENT(decimal fGENT){
	this.fGENT = fGENT;
}

public
void setFGORD(decimal fGORD){
	this.fGORD = fGORD;
}

public
void setFGITEM(decimal fGITEM){
	this.fGITEM = fGITEM;
}

public
void setFGPO(decimal fGPO){
	this.fGPO = fGPO;
}

public
void setFGPREL(decimal fGPREL){
	this.fGPREL = fGPREL;
}

public
void setFGPITM(decimal fGPITM){
	this.fGPITM = fGPITM;
}

public
void setFGQSHP(decimal fGQSHP){
	this.fGQSHP = fGQSHP;
}

public
void setFGQSHO(decimal fGQSHO){
	this.fGQSHO = fGQSHO;
}

public
void setFGCTNC(string fGCTNC){
	this.fGCTNC = fGCTNC;
}

public
void setFGCTNN(decimal fGCTNN){
	this.fGCTNN = fGCTNN;
}

public
void setFGPLTN(decimal fGPLTN){
	this.fGPLTN = fGPLTN;
}

public
void setFGNTWC(decimal fGNTWC){
	this.fGNTWC = fGNTWC;
}

public
void setFGGRSC(decimal fGGRSC){
	this.fGGRSC = fGGRSC;
}

public
void setFGTARC(decimal fGTARC){
	this.fGTARC = fGTARC;
}

public
void setFGVOLC(decimal fGVOLC){
	this.fGVOLC = fGVOLC;
}

public
void setFGQTYC(decimal fGQTYC){
	this.fGQTYC = fGQTYC;
}

public
void setFGWGTP(decimal fGWGTP){
	this.fGWGTP = fGWGTP;
}

public
void setFGVOLP(decimal fGVOLP){
	this.fGVOLP = fGVOLP;
}

public
void setFGLSTS(string fGLSTS){
	this.fGLSTS = fGLSTS;
}

public
void setFGPART(string fGPART){
	this.fGPART = fGPART;
}

public
void setFGRLNO(string fGRLNO){
	this.fGRLNO = fGRLNO;
}

public
void setFGINV(decimal fGINV){
	this.fGINV = fGINV;
}

public
void setFGLIN(decimal fGLIN){
	this.fGLIN = fGLIN;
}

public
void setFGORUN(string fGORUN){
	this.fGORUN = fGORUN;
}

public
void setFGFTAM(decimal fGFTAM){
	this.fGFTAM = fGFTAM;
}

public
void setFGSTKL(string fGSTKL){
	this.fGSTKL = fGSTKL;
}

public
void setFGRAN(string fGRAN){
	this.fGRAN = fGRAN;
}

public
void setFGCPT(string fGCPT){
	this.fGCPT = fGCPT;
}

public
void setFGCNID(string fGCNID){
	this.fGCNID = fGCNID;
}

public
void setFGECHG(string fGECHG){
	this.fGECHG = fGECHG;
}

public
void setFGCCUM(decimal fGCCUM){
	this.fGCCUM = fGCCUM;
}

public
void setFGPCUM(decimal fGPCUM){
	this.fGPCUM = fGPCUM;
}

public
void setFGCPO(string fGCPO){
	this.fGCPO = fGCPO;
}

public
void setFGCMPR(string fGCMPR){
	this.fGCMPR = fGCMPR;
}

public
void setFGDOCK(string fGDOCK){
	this.fGDOCK = fGDOCK;
}

public
void setFGISTS(string fGISTS){
	this.fGISTS = fGISTS;
}

public
void setFGSREF(string fGSREF){
	this.fGSREF = fGSREF;
}

public
void setFGCRCM(string fGCRCM){
	this.fGCRCM = fGCRCM;
}

public
void setFGUSR1(string fGUSR1){
	this.fGUSR1 = fGUSR1;
}

public
void setFGUSR2(string fGUSR2){
	this.fGUSR2 = fGUSR2;
}

public
void setFGUSR3(string fGUSR3){
	this.fGUSR3 = fGUSR3;
}

public
void setFGREQ(decimal fGREQ){
	this.fGREQ = fGREQ;
}

public
void setFGDREQ(decimal fGDREQ){
	this.fGDREQ = fGDREQ;
}

public
void setFGJITD(decimal fGJITD){
	this.fGJITD = fGJITD;
}

public
void setFGUSR4(string fGUSR4){
	this.fGUSR4 = fGUSR4;
}

public
void setFGUSR5(string fGUSR5){
	this.fGUSR5 = fGUSR5;
}

public
void setFGFUT1(string fGFUT1){
	this.fGFUT1 = fGFUT1;
}

public
void setFGFUT2(string fGFUT2){
	this.fGFUT2 = fGFUT2;
}

public
void setFGFUT3(string fGFUT3){
	this.fGFUT3 = fGFUT3;
}

public
void setFGFUT4(string fGFUT4){
	this.fGFUT4 = fGFUT4;
}

public
void setFGFUT5(string fGFUT5){
	this.fGFUT5 = fGFUT5;
}

public
void setFGFUTA(decimal fGFUTA){
	this.fGFUTA = fGFUTA;
}

public
void setFGFUTB(decimal fGFUTB){
	this.fGFUTB = fGFUTB;
}

public
void setFGFUTC(decimal fGFUTC){
	this.fGFUTC = fGFUTC;
}

public
void setFGFUTD(decimal fGFUTD){
	this.fGFUTD = fGFUTD;
}

public
void setFGFUTE(string fGFUTE){
	this.fGFUTE = fGFUTE;
}

public
void setFGFUTF(string fGFUTF){
	this.fGFUTF = fGFUTF;
}

public
void setFGFUTG(string fGFUTG){
	this.fGFUTG = fGFUTG;
}

public
void setFGFUTH(string fGFUTH){
	this.fGFUTH = fGFUTH;
}

public
void setFGFUTI(string fGFUTI){
	this.fGFUTI = fGFUTI;
}

public
void setFGFUTJ(string fGFUTJ){
	this.fGFUTJ = fGFUTJ;
}

public
void setFGFUTK(string fGFUTK){
	this.fGFUTK = fGFUTK;
}

public
void setFGFUTL(string fGFUTL){
	this.fGFUTL = fGFUTL;
}

public
void setFGFUTM(string fGFUTM){
	this.fGFUTM = fGFUTM;
}

public
void setFGFUTN(string fGFUTN){
	this.fGFUTN = fGFUTN;
}

public
void setFGFUTO(string fGFUTO){
	this.fGFUTO = fGFUTO;
}

public
void setFGFUTP(string fGFUTP){
	this.fGFUTP = fGFUTP;
}

public
void setFGFUTQ(string fGFUTQ){
	this.fGFUTQ = fGFUTQ;
}

public
void setFGFUTR(string fGFUTR){
	this.fGFUTR = fGFUTR;
}

public
void setFGFUTS(string fGFUTS){
	this.fGFUTS = fGFUTS;
}

public
void setFGFUTT(string fGFUTT){
	this.fGFUTT = fGFUTT;
}

public
void setBollContainer(BollContainer bollContainer){
	this.bollContainer = bollContainer;
}

public
decimal getFGBOL(){
	 return fGBOL;
}

public
decimal getFGENT(){
	 return fGENT;
}

public
decimal getFGORD(){
	 return fGORD;
}

public
decimal getFGITEM(){
	 return fGITEM;
}

public
decimal getFGPO(){
	 return fGPO;
}

public
decimal getFGPREL(){
	 return fGPREL;
}

public
decimal getFGPITM(){
	 return fGPITM;
}

public
decimal getFGQSHP(){
	 return fGQSHP;
}

public
decimal getFGQSHO(){
	 return fGQSHO;
}

public
string getFGCTNC(){
	 return fGCTNC;
}

public
decimal getFGCTNN(){
	 return fGCTNN;
}

public
decimal getFGPLTN(){
	 return fGPLTN;
}

public
decimal getFGNTWC(){
	 return fGNTWC;
}

public
decimal getFGGRSC(){
	 return fGGRSC;
}

public
decimal getFGTARC(){
	 return fGTARC;
}

public
decimal getFGVOLC(){
	 return fGVOLC;
}

public
decimal getFGQTYC(){
	 return fGQTYC;
}

public
decimal getFGWGTP(){
	 return fGWGTP;
}

public
decimal getFGVOLP(){
	 return fGVOLP;
}

public
string getFGLSTS(){
	 return fGLSTS;
}

public
string getFGPART(){
	 return fGPART;
}

public
string getFGRLNO(){
	 return fGRLNO;
}

public
decimal getFGINV(){
	 return fGINV;
}

public
decimal getFGLIN(){
	 return fGLIN;
}

public
string getFGORUN(){
	 return fGORUN;
}

public
decimal getFGFTAM(){
	 return fGFTAM;
}

public
string getFGSTKL(){
	 return fGSTKL;
}

public
string getFGRAN(){
	 return fGRAN;
}

public
string getFGCPT(){
	 return fGCPT;
}

public
string getFGCNID(){
	 return fGCNID;
}

public
string getFGECHG(){
	 return fGECHG;
}

public
decimal getFGCCUM(){
	 return fGCCUM;
}

public
decimal getFGPCUM(){
	 return fGPCUM;
}

public
string getFGCPO(){
	 return fGCPO;
}

public
string getFGCMPR(){
	 return fGCMPR;
}

public
string getFGDOCK(){
	 return fGDOCK;
}

public
string getFGISTS(){
	 return fGISTS;
}

public
string getFGSREF(){
	 return fGSREF;
}

public
string getFGCRCM(){
	 return fGCRCM;
}

public
string getFGUSR1(){
	 return fGUSR1;
}

public
string getFGUSR2(){
	 return fGUSR2;
}

public
string getFGUSR3(){
	 return fGUSR3;
}

public
decimal getFGREQ(){
	 return fGREQ;
}

public
decimal getFGDREQ(){
	 return fGDREQ;
}

public
decimal getFGJITD(){
	 return fGJITD;
}

public
string getFGUSR4(){
	 return fGUSR4;
}

public
string getFGUSR5(){
	 return fGUSR5;
}

public
string getFGFUT1(){
	 return fGFUT1;
}

public
string getFGFUT2(){
	 return fGFUT2;
}

public
string getFGFUT3(){
	 return fGFUT3;
}

public
string getFGFUT4(){
	 return fGFUT4;
}

public
string getFGFUT5(){
	 return fGFUT5;
}

public
decimal getFGFUTA(){
	 return fGFUTA;
}

public
decimal getFGFUTB(){
	 return fGFUTB;
}

public
decimal getFGFUTC(){
	 return fGFUTC;
}

public
decimal getFGFUTD(){
	 return fGFUTD;
}

public
string getFGFUTE(){
	 return fGFUTE;
}

public
string getFGFUTF(){
	 return fGFUTF;
}

public
string getFGFUTG(){
	 return fGFUTG;
}

public
string getFGFUTH(){
	 return fGFUTH;
}

public
string getFGFUTI(){
	 return fGFUTI;
}

public
string getFGFUTJ(){
	 return fGFUTJ;
}

public
string getFGFUTK(){
	 return fGFUTK;
}

public
string getFGFUTL(){
	 return fGFUTL;
}

public
string getFGFUTM(){
	 return fGFUTM;
}

public
string getFGFUTN(){
	 return fGFUTN;
}

public
string getFGFUTO(){
	 return fGFUTO;
}

public
string getFGFUTP(){
	 return fGFUTP;
}

public
string getFGFUTQ(){
	 return fGFUTQ;
}

public
string getFGFUTR(){
	 return fGFUTR;
}

public
string getFGFUTS(){
	 return fGFUTS;
}

public
string getFGFUTT(){
	 return fGFUTT;
}

public
BollContainer getBollContainer(){
	return bollContainer;
}

public override
bool Equals(object obj){
	if (obj is Bold)
		return	this.fGBOL.Equals(((Bold)obj).getFGBOL()) &&
				this.fGENT.Equals(((Bold)obj).getFGENT());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void addBoll(Boll boll){
	this.bollContainer.Add(boll);
}

public
void fillRedundances(){
	for (int i = 0; i < bollContainer.getSize(); i++ ){
		Boll boll = bollContainer.getAt(i);
		boll.setQUBOL(this.getFGBOL());
		boll.setQUENT(this.getFGENT());
		boll.setQUSEQ(i + 1);
	}
}

public
void setEdiProcessed(string ediProcessed){
    this.ediProcessed = ediProcessed;
}

public
string getEdiProcessed(){
    return ediProcessed;
}

[System.Runtime.Serialization.DataMember]
public
decimal FGBOL {
	get { return fGBOL;}
	set { if (this.fGBOL != value){
			this.fGBOL = value;
			Notify("FGBOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGENT {
	get { return fGENT;}
	set { if (this.fGENT != value){
			this.fGENT = value;
			Notify("FGENT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGORD {
	get { return fGORD;}
	set { if (this.fGORD != value){
			this.fGORD = value;
			Notify("FGORD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGITEM {
	get { return fGITEM;}
	set { if (this.fGITEM != value){
			this.fGITEM = value;
			Notify("FGITEM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPO {
	get { return fGPO;}
	set { if (this.fGPO != value){
			this.fGPO = value;
			Notify("FGPO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPREL {
	get { return fGPREL;}
	set { if (this.fGPREL != value){
			this.fGPREL = value;
			Notify("FGPREL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPITM {
	get { return fGPITM;}
	set { if (this.fGPITM != value){
			this.fGPITM = value;
			Notify("FGPITM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGQSHP {
	get { return fGQSHP;}
	set { if (this.fGQSHP != value){
			this.fGQSHP = value;
			Notify("FGQSHP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGQSHO {
	get { return fGQSHO;}
	set { if (this.fGQSHO != value){
			this.fGQSHO = value;
			Notify("FGQSHO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCTNC {
	get { return fGCTNC;}
	set { if (this.fGCTNC != value){
			this.fGCTNC = value;
			Notify("FGCTNC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGCTNN {
	get { return fGCTNN;}
	set { if (this.fGCTNN != value){
			this.fGCTNN = value;
			Notify("FGCTNN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPLTN {
	get { return fGPLTN;}
	set { if (this.fGPLTN != value){
			this.fGPLTN = value;
			Notify("FGPLTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGNTWC {
	get { return fGNTWC;}
	set { if (this.fGNTWC != value){
			this.fGNTWC = value;
			Notify("FGNTWC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGGRSC {
	get { return fGGRSC;}
	set { if (this.fGGRSC != value){
			this.fGGRSC = value;
			Notify("FGGRSC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGTARC {
	get { return fGTARC;}
	set { if (this.fGTARC != value){
			this.fGTARC = value;
			Notify("FGTARC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGVOLC {
	get { return fGVOLC;}
	set { if (this.fGVOLC != value){
			this.fGVOLC = value;
			Notify("FGVOLC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGQTYC {
	get { return fGQTYC;}
	set { if (this.fGQTYC != value){
			this.fGQTYC = value;
			Notify("FGQTYC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGWGTP {
	get { return fGWGTP;}
	set { if (this.fGWGTP != value){
			this.fGWGTP = value;
			Notify("FGWGTP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGVOLP {
	get { return fGVOLP;}
	set { if (this.fGVOLP != value){
			this.fGVOLP = value;
			Notify("FGVOLP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGLSTS {
	get { return fGLSTS;}
	set { if (this.fGLSTS != value){
			this.fGLSTS = value;
			Notify("FGLSTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGPART {
	get { return fGPART;}
	set { if (this.fGPART != value){
			this.fGPART = value;
			Notify("FGPART");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGRLNO {
	get { return fGRLNO;}
	set { if (this.fGRLNO != value){
			this.fGRLNO = value;
			Notify("FGRLNO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGINV {
	get { return fGINV;}
	set { if (this.fGINV != value){
			this.fGINV = value;
			Notify("FGINV");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGLIN {
	get { return fGLIN;}
	set { if (this.fGLIN != value){
			this.fGLIN = value;
			Notify("FGLIN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGORUN {
	get { return fGORUN;}
	set { if (this.fGORUN != value){
			this.fGORUN = value;
			Notify("FGORUN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGFTAM {
	get { return fGFTAM;}
	set { if (this.fGFTAM != value){
			this.fGFTAM = value;
			Notify("FGFTAM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGSTKL {
	get { return fGSTKL;}
	set { if (this.fGSTKL != value){
			this.fGSTKL = value;
			Notify("FGSTKL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGRAN {
	get { return fGRAN;}
	set { if (this.fGRAN != value){
			this.fGRAN = value;
			Notify("FGRAN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCPT {
	get { return fGCPT;}
	set { if (this.fGCPT != value){
			this.fGCPT = value;
			Notify("FGCPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCNID {
	get { return fGCNID;}
	set { if (this.fGCNID != value){
			this.fGCNID = value;
			Notify("FGCNID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGECHG {
	get { return fGECHG;}
	set { if (this.fGECHG != value){
			this.fGECHG = value;
			Notify("FGECHG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGCCUM {
	get { return fGCCUM;}
	set { if (this.fGCCUM != value){
			this.fGCCUM = value;
			Notify("FGCCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPCUM {
	get { return fGPCUM;}
	set { if (this.fGPCUM != value){
			this.fGPCUM = value;
			Notify("FGPCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCPO {
	get { return fGCPO;}
	set { if (this.fGCPO != value){
			this.fGCPO = value;
			Notify("FGCPO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCMPR {
	get { return fGCMPR;}
	set { if (this.fGCMPR != value){
			this.fGCMPR = value;
			Notify("FGCMPR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGDOCK {
	get { return fGDOCK;}
	set { if (this.fGDOCK != value){
			this.fGDOCK = value;
			Notify("FGDOCK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGISTS {
	get { return fGISTS;}
	set { if (this.fGISTS != value){
			this.fGISTS = value;
			Notify("FGISTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGSREF {
	get { return fGSREF;}
	set { if (this.fGSREF != value){
			this.fGSREF = value;
			Notify("FGSREF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCRCM {
	get { return fGCRCM;}
	set { if (this.fGCRCM != value){
			this.fGCRCM = value;
			Notify("FGCRCM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGUSR1 {
	get { return fGUSR1;}
	set { if (this.fGUSR1 != value){
			this.fGUSR1 = value;
			Notify("FGUSR1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGUSR2 {
	get { return fGUSR2;}
	set { if (this.fGUSR2 != value){
			this.fGUSR2 = value;
			Notify("FGUSR2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGUSR3 {
	get { return fGUSR3;}
	set { if (this.fGUSR3 != value){
			this.fGUSR3 = value;
			Notify("FGUSR3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGREQ {
	get { return fGREQ;}
	set { if (this.fGREQ != value){
			this.fGREQ = value;
			Notify("FGREQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGDREQ {
	get { return fGDREQ;}
	set { if (this.fGDREQ != value){
			this.fGDREQ = value;
			Notify("FGDREQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGJITD {
	get { return fGJITD;}
	set { if (this.fGJITD != value){
			this.fGJITD = value;
			Notify("FGJITD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGUSR4 {
	get { return fGUSR4;}
	set { if (this.fGUSR4 != value){
			this.fGUSR4 = value;
			Notify("FGUSR4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGUSR5 {
	get { return fGUSR5;}
	set { if (this.fGUSR5 != value){
			this.fGUSR5 = value;
			Notify("FGUSR5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUT1 {
	get { return fGFUT1;}
	set { if (this.fGFUT1 != value){
			this.fGFUT1 = value;
			Notify("FGFUT1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUT2 {
	get { return fGFUT2;}
	set { if (this.fGFUT2 != value){
			this.fGFUT2 = value;
			Notify("FGFUT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUT3 {
	get { return fGFUT3;}
	set { if (this.fGFUT3 != value){
			this.fGFUT3 = value;
			Notify("FGFUT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUT4 {
	get { return fGFUT4;}
	set { if (this.fGFUT4 != value){
			this.fGFUT4 = value;
			Notify("FGFUT4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUT5 {
	get { return fGFUT5;}
	set { if (this.fGFUT5 != value){
			this.fGFUT5 = value;
			Notify("FGFUT5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGFUTA {
	get { return fGFUTA;}
	set { if (this.fGFUTA != value){
			this.fGFUTA = value;
			Notify("FGFUTA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGFUTB {
	get { return fGFUTB;}
	set { if (this.fGFUTB != value){
			this.fGFUTB = value;
			Notify("FGFUTB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGFUTC {
	get { return fGFUTC;}
	set { if (this.fGFUTC != value){
			this.fGFUTC = value;
			Notify("FGFUTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGFUTD {
	get { return fGFUTD;}
	set { if (this.fGFUTD != value){
			this.fGFUTD = value;
			Notify("FGFUTD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTE {
	get { return fGFUTE;}
	set { if (this.fGFUTE != value){
			this.fGFUTE = value;
			Notify("FGFUTE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTF {
	get { return fGFUTF;}
	set { if (this.fGFUTF != value){
			this.fGFUTF = value;
			Notify("FGFUTF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTG {
	get { return fGFUTG;}
	set { if (this.fGFUTG != value){
			this.fGFUTG = value;
			Notify("FGFUTG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTH {
	get { return fGFUTH;}
	set { if (this.fGFUTH != value){
			this.fGFUTH = value;
			Notify("FGFUTH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTI {
	get { return fGFUTI;}
	set { if (this.fGFUTI != value){
			this.fGFUTI = value;
			Notify("FGFUTI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTJ {
	get { return fGFUTJ;}
	set { if (this.fGFUTJ != value){
			this.fGFUTJ = value;
			Notify("FGFUTJ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTK {
	get { return fGFUTK;}
	set { if (this.fGFUTK != value){
			this.fGFUTK = value;
			Notify("FGFUTK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTL {
	get { return fGFUTL;}
	set { if (this.fGFUTL != value){
			this.fGFUTL = value;
			Notify("FGFUTL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTM {
	get { return fGFUTM;}
	set { if (this.fGFUTM != value){
			this.fGFUTM = value;
			Notify("FGFUTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTN {
	get { return fGFUTN;}
	set { if (this.fGFUTN != value){
			this.fGFUTN = value;
			Notify("FGFUTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTO {
	get { return fGFUTO;}
	set { if (this.fGFUTO != value){
			this.fGFUTO = value;
			Notify("FGFUTO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTP {
	get { return fGFUTP;}
	set { if (this.fGFUTP != value){
			this.fGFUTP = value;
			Notify("FGFUTP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTQ {
	get { return fGFUTQ;}
	set { if (this.fGFUTQ != value){
			this.fGFUTQ = value;
			Notify("FGFUTQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTR {
	get { return fGFUTR;}
	set { if (this.fGFUTR != value){
			this.fGFUTR = value;
			Notify("FGFUTR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTS {
	get { return fGFUTS;}
	set { if (this.fGFUTS != value){
			this.fGFUTS = value;
			Notify("FGFUTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGFUTT {
	get { return fGFUTT;}
	set { if (this.fGFUTT != value){
			this.fGFUTT = value;
			Notify("FGFUTT");
		}
	}
}

/*
[System.Runtime.Serialization.DataMember]
public
string FGPLNT {
	get { return fGPLNT;}
	set { if (this.fGPLNT != value){
			this.fGPLNT = value;
			Notify("FGPLNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGBUNT {
	get { return fGBUNT;}
	set { if (this.fGBUNT != value){
			this.fGBUNT = value;
			Notify("FGBUNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGRPBR {
	get { return fGRPBR;}
	set { if (this.fGRPBR != value){
			this.fGRPBR = value;
			Notify("FGRPBR");
		}
	}
}
    */
[System.Runtime.Serialization.DataMember]
public
decimal FGNWFP {
	get { return fGNWFP;}
	set { if (this.fGNWFP != value){
			this.fGNWFP = value;
			Notify("FGNWFP");
		}
	}
}
    /*
[System.Runtime.Serialization.DataMember]
public
string FGCREL {
	get { return fGCREL;}
	set { if (this.fGCREL != value){
			this.fGCREL = value;
			Notify("FGCREL");
		}
	}
}*/

[System.Runtime.Serialization.DataMember]
public
string FGPSLP {
	get { return fGPSLP;}
	set { if (this.fGPSLP != value){
			this.fGPSLP = value;
			Notify("FGPSLP");
		}
	}
}
/*
[System.Runtime.Serialization.DataMember]
public
string FGRMID {
	get { return fGRMID;}
	set { if (this.fGRMID != value){
			this.fGRMID = value;
			Notify("FGRMID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCREV {
	get { return fGCREV;}
	set { if (this.fGCREV != value){
			this.fGCREV = value;
			Notify("FGCREV");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGREFF {
	get { return fGREFF;}
	set { if (this.fGREFF != value){
			this.fGREFF = value;
			Notify("FGREFF");
		}
	}
}
    */

} // class

} // package