using System;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;

namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{


[System.Runtime.Serialization.DataContract]
public
class Bol : BusinessObject {

private decimal fEBOL;
private string fEBTYP;
private DateTime fECDAT;
private string fEPIND;
private string fESIND;
private string fEBCS;
private string fESCS;
private string fESVND;
private string fERVND;
private string fEBNME;
private string fEBPTC;
private string fEATTN;
private string fESNME;
private string fESAD1;
private string fESAD2;
private string fESAD3;
private string fESAD4;
private string fESAD5;
private string fESAD6;
private string fESAD7;
private string fESAD8;
private string fESAD9;
private string fESAD10;
private string fESPTC;
private DateTime fESDAT;
private string fESVIA;
private string fETKID;
private decimal fENCTN;
private decimal fENETW;
private decimal fEGROW;
private decimal fETARW;
private string fEWTUN;
private string fEDOCD;
private string fEFTCD;
private decimal fEORD;
private string fESTKL;
private decimal fEFTAM;
private string fEFOB;
private string fECARC;
private string fESERC;
private decimal fESTME;
private string fEJITF;
private string fESID;
private string fETRPT;
private string fEBID;
private string fESFID;
private string fEPLNT;
private string fEITMC;
private string fESUPP;
private string fEULTD;
private DateTime fEEDAT;
private decimal fEETIM;
private DateTime fEADAT;
private decimal fEATIM;
private string fETRNM;
private string fERTEG;
private string fEPLPT;
private string fEPLOC;
private string fEEQPD;
private string fEEQPI;
private string fEEQID;
private decimal fEMBOL;
private string fEPSLP;
private string fEFRTB;
private string fEAIRB;
private string fETSPR;
private string fEETRR;
private string fEEXTR;
private string fEAETC;
private string fEMTHP;
private string fETRNT;
private string fETRLQ;
private string fECCT;
private string fECCDE;
private string fESASN;
private string fESNTF;
private string fESTS;
private string fEXMOD;
private string fEATYP;
private string fEFLD1;
private string fEFLD2;
private string fEFLD3;
private string fEFLD4;
private string fEFLD5;
private string fEFLD6;
private string fEMANW;
private string fES204;
private string fEBTRP;
private string fEBSTS;
private string fEBACK;
private string fEBSET;
private string fEBMOD;
private decimal fESKDQ;
private string fESKDT;
private decimal fELOSQ;
private string fELOST;
private string fECRCM;
private string fEUSE;
private string fESLCS;
private string fECRTY;
private string fECRDT;
private string fECRD;
private string fEEXPR;
private string fEHODR;
private decimal fECRNM;
private string fESHBF;
private string fECLEN;
private string fEPLTC;
private string fEFUT1;
private string fEFUT2;
private string fEFUT3;
private string fEFUT4;
private string fEFUT5;
private string fEFUT6;
private string fEFUT7;
private string fEFUT8;
private string fEFUT9;
private string fEFUTA;
private string fEFUTB;
private decimal fEFUTC;
private string fEFUTD;
private string fEFUTE;
private string fEFUTF;
private string fEFUTG;

private string fEFUTK;
private string fEFUTP;
private string fERTS;

private string fESCTY;
private string fESPOV;
private string fETAMT;    

private DateTime fEPDAT;
private decimal fEPTIM;

private BoldContainer boldContainer;
private CustomerEdi customerEdi;
private BolNpContainer bolNpContainer;
private Shcr shcr;
private Bolhref bolhref;
private Bolm bolm=null; //only used to show

internal
Bol(){
	this.fEBOL = 0;
	this.fEBTYP = "";
	this.fECDAT = DateUtil.MinValue;
	this.fEPIND = "";
	this.fESIND = "";
	this.fEBCS = "";
	this.fESCS = "";
	this.fESVND = "";
	this.fERVND = "";
	this.fEBNME = "";
	this.fEBPTC = "";
	this.fEATTN = "";
	this.fESNME = "";
	this.fESAD1 = "";
	this.fESAD2 = "";
	this.fESAD3 = "";
	this.fESAD4 = "";
	this.fESAD5 = "";
	this.fESAD6 = "";
	this.fESAD7 = "";
	this.fESAD8 = "";
	this.fESAD9 = "";
	this.fESAD10 = "";
	this.fESPTC = "";
	this.fESDAT = DateUtil.MinValue;
	this.fESVIA = "";
	this.fETKID = "";
	this.fENCTN = 0;
	this.fENETW = 0;
	this.fEGROW = 0;
	this.fETARW = 0;
	this.fEWTUN = "";
	this.fEDOCD = "";
	this.fEFTCD = "";
	this.fEORD = 0;
	this.fESTKL = "";
	this.fEFTAM = 0;
	this.fEFOB = "";
	this.fECARC = "";
	this.fESERC = "";
	this.fESTME = 0;
	this.fEJITF = "";
	this.fESID = "";
	this.fETRPT = "";
	this.fEBID = "";
	this.fESFID = "";
	this.fEPLNT = "";
	this.fEITMC = "";
	this.fESUPP = "";
	this.fEULTD = "";
	this.fEEDAT = DateUtil.MinValue;
	this.fEETIM = 0;
	this.fEADAT = DateUtil.MinValue;
	this.fEATIM = 0;
	this.fETRNM = "";
	this.fERTEG = "";
	this.fEPLPT = "";
	this.fEPLOC = "";
	this.fEEQPD = "";
	this.fEEQPI = "";
	this.fEEQID = "";
	this.fEMBOL = 0;
	this.fEPSLP = "";
	this.fEFRTB = "";
	this.fEAIRB = "";
	this.fETSPR = "";
	this.fEETRR = "";
	this.fEEXTR = "";
	this.fEAETC = "";
	this.fEMTHP = "";
	this.fETRNT = "";
	this.fETRLQ = "";
	this.fECCT = "";
	this.fECCDE = "";
	this.fESASN = "";
	this.fESNTF = "";
	this.fESTS = "";
	this.fEXMOD = "";
	this.fEATYP = "";
	this.fEFLD1 = "";
	this.fEFLD2 = "";
	this.fEFLD3 = "";
	this.fEFLD4 = "";
	this.fEFLD5 = "";
	this.fEFLD6 = "";
	this.fEMANW = "";
	this.fES204 = "";
	this.fEBTRP = "";
	this.fEBSTS = "";
	this.fEBACK = "";
	this.fEBSET = "";
	this.fEBMOD = "";
	this.fESKDQ = 0;
	this.fESKDT = "";
	this.fELOSQ = 0;
	this.fELOST = "";
	this.fECRCM = "";
	this.fEUSE = "";
	this.fESLCS = "";
	this.fECRTY = "";
	this.fECRDT = "";
	this.fECRD = "";
	this.fEEXPR = "";
	this.fEHODR = "";
	this.fECRNM = 0;
	this.fESHBF = "";
	this.fECLEN = "";
	this.fEPLTC = "";
	this.fEFUT1 = "";
	this.fEFUT2 = "";
	this.fEFUT3 = "";
	this.fEFUT4 = "";
	this.fEFUT5 = "";
	this.fEFUT6 = "";
	this.fEFUT7 = "";
	this.fEFUT8 = "";
	this.fEFUT9 = "";
	this.fEFUTA = "";
	this.fEFUTB = "";
	this.fEFUTC = 0;
	this.fEFUTD = "";
	this.fEFUTE = "";
	this.fEFUTF = "";
	this.fEFUTG = "";
    this.fEFUTK = "";
    this.fEFUTP = "";
    this.fERTS = "";

    this.fESCTY = "";
    this.fESPOV = "";
    this.fETAMT = "";

    this.fEPDAT = DateUtil.MinValue;
    this.fEPTIM = 0;

	this.boldContainer = new BoldContainer();
	this.customerEdi = new CustomerEdi();
	this.bolNpContainer = new BolNpContainer();

	this.shcr = new Shcr();
	this.bolhref = new Bolhref();
}

internal
Bol(
				decimal fEBOL,
				string fEBTYP,
				DateTime fECDAT,
				string fEPIND,
				string fESIND,
				string fEBCS,
				string fESCS,
				string fESVND,
				string fERVND,
				string fEBNME,
				string fEBPTC,
				string fEATTN,
				string fESNME,
				string fESAD1,
				string fESAD2,
				string fESAD3,
				string fESAD4,
				string fESAD5,
				string fESAD6,
				string fESAD7,
				string fESAD8,
				string fESAD9,
				string fESAD10,
				string fESPTC,
				DateTime fESDAT,
				string fESVIA,
				string fETKID,
				decimal fENCTN,
				decimal fENETW,
				decimal fEGROW,
				decimal fETARW,
				string fEWTUN,
				string fEDOCD,
				string fEFTCD,
				decimal fEORD,
				string fESTKL,
				decimal fEFTAM,
				string fEFOB,
				string fECARC,
				string fESERC,
				decimal fESTME,
				string fEJITF,
				string fESID,
				string fETRPT,
				string fEBID,
				string fESFID,
				string fEPLNT,
				string fEITMC,
				string fESUPP,
				string fEULTD,
				DateTime fEEDAT,
				decimal fEETIM,
				DateTime fEADAT,
				decimal fEATIM,
				string fETRNM,
				string fERTEG,
				string fEPLPT,
				string fEPLOC,
				string fEEQPD,
				string fEEQPI,
				string fEEQID,
				decimal fEMBOL,
				string fEPSLP,
				string fEFRTB,
				string fEAIRB,
				string fETSPR,
				string fEETRR,
				string fEEXTR,
				string fEAETC,
				string fEMTHP,
				string fETRNT,
				string fETRLQ,
				string fECCT,
				string fECCDE,
				string fESASN,
				string fESNTF,
				string fESTS,
				string fEXMOD,
				string fEATYP,
				string fEFLD1,
				string fEFLD2,
				string fEFLD3,
				string fEFLD4,
				string fEFLD5,
				string fEFLD6,
				string fEMANW,
				string fES204,
				string fEBTRP,
				string fEBSTS,
				string fEBACK,
				string fEBSET,
				string fEBMOD,
				decimal fESKDQ,
				string fESKDT,
				decimal fELOSQ,
				string fELOST,
				string fECRCM,
				string fEUSE,
				string fESLCS,
				string fECRTY,
				string fECRDT,
				string fECRD,
				string fEEXPR,
				string fEHODR,
				decimal fECRNM,
				string fESHBF,
				string fECLEN,
				string fEPLTC,
				string fEFUT1,
				string fEFUT2,
				string fEFUT3,
				string fEFUT4,
				string fEFUT5,
				string fEFUT6,
				string fEFUT7,
				string fEFUT8,
				string fEFUT9,
				string fEFUTA,
				string fEFUTB,
				decimal fEFUTC,
				string fEFUTD,
				string fEFUTE,
				string fEFUTF,
				string fEFUTG,
                string fEFUTK,     
                string fEFUTP,
                string fERTS,
                string fESCTY,
                string fESPOV,
                string fETAMT,
                DateTime fEPDAT,
                decimal fEPTIM,
				BoldContainer boldContainer,
				CustomerEdi customerEdi,
				BolNpContainer bolNpContainer,
				Shcr shcr,
				Bolhref bolhref)
{
	this.fEBOL = fEBOL;
	this.fEBTYP = fEBTYP;
	this.fECDAT = fECDAT;
	this.fEPIND = fEPIND;
	this.fESIND = fESIND;
	this.fEBCS = fEBCS;
	this.fESCS = fESCS;
	this.fESVND = fESVND;
	this.fERVND = fERVND;
	this.fEBNME = fEBNME;
	this.fEBPTC = fEBPTC;
	this.fEATTN = fEATTN;
	this.fESNME = fESNME;
	this.fESAD1 = fESAD1;
	this.fESAD2 = fESAD2;
	this.fESAD3 = fESAD3;
	this.fESAD4 = fESAD4;
	this.fESAD5 = fESAD5;
	this.fESAD6 = fESAD6;
	this.fESAD7 = fESAD7;
	this.fESAD8 = fESAD8;
	this.fESAD9 = fESAD9;
	this.fESAD10 = fESAD10;
	this.fESPTC = fESPTC;
	this.fESDAT = fESDAT;
	this.fESVIA = fESVIA;
	this.fETKID = fETKID;
	this.fENCTN = fENCTN;
	this.fENETW = fENETW;
	this.fEGROW = fEGROW;
	this.fETARW = fETARW;
	this.fEWTUN = fEWTUN;
	this.fEDOCD = fEDOCD;
	this.fEFTCD = fEFTCD;
	this.fEORD = fEORD;
	this.fESTKL = fESTKL;
	this.fEFTAM = fEFTAM;
	this.fEFOB = fEFOB;
	this.fECARC = fECARC;
	this.fESERC = fESERC;
	this.fESTME = fESTME;
	this.fEJITF = fEJITF;
	this.fESID = fESID;
	this.fETRPT = fETRPT;
	this.fEBID = fEBID;
	this.fESFID = fESFID;
	this.fEPLNT = fEPLNT;
	this.fEITMC = fEITMC;
	this.fESUPP = fESUPP;
	this.fEULTD = fEULTD;
	this.fEEDAT = fEEDAT;
	this.fEETIM = fEETIM;
	this.fEADAT = fEADAT;
	this.fEATIM = fEATIM;
	this.fETRNM = fETRNM;
	this.fERTEG = fERTEG;
	this.fEPLPT = fEPLPT;
	this.fEPLOC = fEPLOC;
	this.fEEQPD = fEEQPD;
	this.fEEQPI = fEEQPI;
	this.fEEQID = fEEQID;
	this.fEMBOL = fEMBOL;
	this.fEPSLP = fEPSLP;
	this.fEFRTB = fEFRTB;
	this.fEAIRB = fEAIRB;
	this.fETSPR = fETSPR;
	this.fEETRR = fEETRR;
	this.fEEXTR = fEEXTR;
	this.fEAETC = fEAETC;
	this.fEMTHP = fEMTHP;
	this.fETRNT = fETRNT;
	this.fETRLQ = fETRLQ;
	this.fECCT = fECCT;
	this.fECCDE = fECCDE;
	this.fESASN = fESASN;
	this.fESNTF = fESNTF;
	this.fESTS = fESTS;
	this.fEXMOD = fEXMOD;
	this.fEATYP = fEATYP;
	this.fEFLD1 = fEFLD1;
	this.fEFLD2 = fEFLD2;
	this.fEFLD3 = fEFLD3;
	this.fEFLD4 = fEFLD4;
	this.fEFLD5 = fEFLD5;
	this.fEFLD6 = fEFLD6;
	this.fEMANW = fEMANW;
	this.fES204 = fES204;
	this.fEBTRP = fEBTRP;
	this.fEBSTS = fEBSTS;
	this.fEBACK = fEBACK;
	this.fEBSET = fEBSET;
	this.fEBMOD = fEBMOD;
	this.fESKDQ = fESKDQ;
	this.fESKDT = fESKDT;
	this.fELOSQ = fELOSQ;
	this.fELOST = fELOST;
	this.fECRCM = fECRCM;
	this.fEUSE = fEUSE;
	this.fESLCS = fESLCS;
	this.fECRTY = fECRTY;
	this.fECRDT = fECRDT;
	this.fECRD = fECRD;
	this.fEEXPR = fEEXPR;
	this.fEHODR = fEHODR;
	this.fECRNM = fECRNM;
	this.fESHBF = fESHBF;
	this.fECLEN = fECLEN;
	this.fEPLTC = fEPLTC;
	this.fEFUT1 = fEFUT1;
	this.fEFUT2 = fEFUT2;
	this.fEFUT3 = fEFUT3;
	this.fEFUT4 = fEFUT4;
	this.fEFUT5 = fEFUT5;
	this.fEFUT6 = fEFUT6;
	this.fEFUT7 = fEFUT7;
	this.fEFUT8 = fEFUT8;
	this.fEFUT9 = fEFUT9;
	this.fEFUTA = fEFUTA;
	this.fEFUTB = fEFUTB;
	this.fEFUTC = fEFUTC;
	this.fEFUTD = fEFUTD;
	this.fEFUTE = fEFUTE;
	this.fEFUTF = fEFUTF;
	this.fEFUTG = fEFUTG;
    this.fEFUTK = fEFUTK;
    this.fEFUTP = fEFUTP;
    this.fERTS = fERTS;
    this.fEPDAT = fEPDAT;
    this.fEPTIM = fEPTIM;

    this.fESCTY = fESCTY;
    this.fESPOV = fESPOV;
    this.fETAMT = fETAMT;
	this.boldContainer = boldContainer;
	this.customerEdi = customerEdi;
	this.bolNpContainer = bolNpContainer;
	this.shcr = shcr;
	this.bolhref = bolhref;
}

public
void setFEBOL(decimal fEBOL){
	this.fEBOL = fEBOL;
}

public
void setFEBTYP(string fEBTYP){
	this.fEBTYP = fEBTYP;
}

public
void setFECDAT(DateTime fECDAT){
	this.fECDAT = fECDAT;
}

public
void setFEPIND(string fEPIND){
	this.fEPIND = fEPIND;
}

public
void setFESIND(string fESIND){
	this.fESIND = fESIND;
}

public
void setFEBCS(string fEBCS){
	this.fEBCS = fEBCS;
}

public
void setFESCS(string fESCS){
	this.fESCS = fESCS;
}

public
void setFESVND(string fESVND){
	this.fESVND = fESVND;
}

public
void setFERVND(string fERVND){
	this.fERVND = fERVND;
}

public
void setFEBNME(string fEBNME){
	this.fEBNME = fEBNME;
}

public
void setFEBPTC(string fEBPTC){
	this.fEBPTC = fEBPTC;
}

public
void setFEATTN(string fEATTN){
	this.fEATTN = fEATTN;
}

public
void setFESNME(string fESNME){
	this.fESNME = fESNME;
}

public
void setFESAD1(string fESAD1){
	this.fESAD1 = fESAD1;
}

public
void setFESAD2(string fESAD2){
	this.fESAD2 = fESAD2;
}

public
void setFESAD3(string fESAD3){
	this.fESAD3 = fESAD3;
}

public
void setFESAD4(string fESAD4){
	this.fESAD4 = fESAD4;
}

public
void setFESAD5(string fESAD5){
	this.fESAD5 = fESAD5;
}

public
void setFESAD6(string fESAD6){
	this.fESAD6 = fESAD6;
}

public
void setFESAD7(string fESAD7){
	this.fESAD7 = fESAD7;
}

public
void setFESAD8(string fESAD8){
	this.fESAD8 = fESAD8;
}

public
void setFESAD9(string fESAD9){
	this.fESAD9 = fESAD9;
}

public
void setFESAD10(string fESAD10){
	this.fESAD10 = fESAD10;
}

public
void setFESPTC(string fESPTC){
	this.fESPTC = fESPTC;
}

public
void setFESDAT(DateTime fESDAT){
	this.fESDAT = fESDAT;
}

public
void setFESVIA(string fESVIA){
	this.fESVIA = fESVIA;
}

public
void setFETKID(string fETKID){
	this.fETKID = fETKID;
}

public
void setFENCTN(decimal fENCTN){
	this.fENCTN = fENCTN;
}

public
void setFENETW(decimal fENETW){
	this.fENETW = fENETW;
}

public
void setFEGROW(decimal fEGROW){
	this.fEGROW = fEGROW;
}

public
void setFETARW(decimal fETARW){
	this.fETARW = fETARW;
}

public
void setFEWTUN(string fEWTUN){
	this.fEWTUN = fEWTUN;
}

public
void setFEDOCD(string fEDOCD){
	this.fEDOCD = fEDOCD;
}

public
void setFEFTCD(string fEFTCD){
	this.fEFTCD = fEFTCD;
}

public
void setFEORD(decimal fEORD){
	this.fEORD = fEORD;
}

public
void setFESTKL(string fESTKL){
	this.fESTKL = fESTKL;
}

public
void setFEFTAM(decimal fEFTAM){
	this.fEFTAM = fEFTAM;
}

public
void setFEFOB(string fEFOB){
	this.fEFOB = fEFOB;
}

public
void setFECARC(string fECARC){
	this.fECARC = fECARC;
}

public
void setFESERC(string fESERC){
	this.fESERC = fESERC;
}

public
void setFESTME(decimal fESTME){
	this.fESTME = fESTME;
}

public
void setFEJITF(string fEJITF){
	this.fEJITF = fEJITF;
}

public
void setFESID(string fESID){
	this.fESID = fESID;
}

public
void setFETRPT(string fETRPT){
	this.fETRPT = fETRPT;
}

public
void setFEBID(string fEBID){
	this.fEBID = fEBID;
}

public
void setFESFID(string fESFID){
	this.fESFID = fESFID;
}

public
void setFEPLNT(string fEPLNT){
	this.fEPLNT = fEPLNT;
}

public
void setFEITMC(string fEITMC){
	this.fEITMC = fEITMC;
}

public
void setFESUPP(string fESUPP){
	this.fESUPP = fESUPP;
}

public
void setFEULTD(string fEULTD){
	this.fEULTD = fEULTD;
}

public
void setFEEDAT(DateTime fEEDAT){
	this.fEEDAT = fEEDAT;
}

public
void setFEETIM(decimal fEETIM){
	this.fEETIM = fEETIM;
}

public
void setFEADAT(DateTime fEADAT){
	this.fEADAT = fEADAT;
}

public
void setFEATIM(decimal fEATIM){
	this.fEATIM = fEATIM;
}

public
void setFETRNM(string fETRNM){
	this.fETRNM = fETRNM;
}

public
void setFERTEG(string fERTEG){
	this.fERTEG = fERTEG;
}

public
void setFEPLPT(string fEPLPT){
	this.fEPLPT = fEPLPT;
}

public
void setFEPLOC(string fEPLOC){
	this.fEPLOC = fEPLOC;
}

public
void setFEEQPD(string fEEQPD){
	this.fEEQPD = fEEQPD;
}

public
void setFEEQPI(string fEEQPI){
	this.fEEQPI = fEEQPI;
}

public
void setFEEQID(string fEEQID){
	this.fEEQID = fEEQID;
}

public
void setFEMBOL(decimal fEMBOL){
	this.fEMBOL = fEMBOL;
}

public
void setFEPSLP(string fEPSLP){
	this.fEPSLP = fEPSLP;
}

public
void setFEFRTB(string fEFRTB){
	this.fEFRTB = fEFRTB;
}

public
void setFEAIRB(string fEAIRB){
	this.fEAIRB = fEAIRB;
}

public
void setFETSPR(string fETSPR){
	this.fETSPR = fETSPR;
}

public
void setFEETRR(string fEETRR){
	this.fEETRR = fEETRR;
}

public
void setFEEXTR(string fEEXTR){
	this.fEEXTR = fEEXTR;
}

public
void setFEAETC(string fEAETC){
	this.fEAETC = fEAETC;
}

public
void setFEMTHP(string fEMTHP){
	this.fEMTHP = fEMTHP;
}

public
void setFETRNT(string fETRNT){
	this.fETRNT = fETRNT;
}

public
void setFETRLQ(string fETRLQ){
	this.fETRLQ = fETRLQ;
}

public
void setFECCT(string fECCT){
	this.fECCT = fECCT;
}

public
void setFECCDE(string fECCDE){
	this.fECCDE = fECCDE;
}

public
void setFESASN(string fESASN){
	this.fESASN = fESASN;
}

public
void setFESNTF(string fESNTF){
	this.fESNTF = fESNTF;
}

public
void setFESTS(string fESTS){
	this.fESTS = fESTS;
}

public
void setFEXMOD(string fEXMOD){
	this.fEXMOD = fEXMOD;
}

public
void setFEATYP(string fEATYP){
	this.fEATYP = fEATYP;
}

public
void setFEFLD1(string fEFLD1){
	this.fEFLD1 = fEFLD1;
}

public
void setFEFLD2(string fEFLD2){
	this.fEFLD2 = fEFLD2;
}

public
void setFEFLD3(string fEFLD3){
	this.fEFLD3 = fEFLD3;
}

public
void setFEFLD4(string fEFLD4){
	this.fEFLD4 = fEFLD4;
}

public
void setFEFLD5(string fEFLD5){
	this.fEFLD5 = fEFLD5;
}

public
void setFEFLD6(string fEFLD6){
	this.fEFLD6 = fEFLD6;
}

public
void setFEMANW(string fEMANW){
	this.fEMANW = fEMANW;
}

public
void setFES204(string fES204){
	this.fES204 = fES204;
}

public
void setFEBTRP(string fEBTRP){
	this.fEBTRP = fEBTRP;
}

public
void setFEBSTS(string fEBSTS){
	this.fEBSTS = fEBSTS;
}

public
void setFEBACK(string fEBACK){
	this.fEBACK = fEBACK;
}

public
void setFEBSET(string fEBSET){
	this.fEBSET = fEBSET;
}

public
void setFEBMOD(string fEBMOD){
	this.fEBMOD = fEBMOD;
}

public
void setFESKDQ(decimal fESKDQ){
	this.fESKDQ = fESKDQ;
}

public
void setFESKDT(string fESKDT){
	this.fESKDT = fESKDT;
}

public
void setFELOSQ(decimal fELOSQ){
	this.fELOSQ = fELOSQ;
}

public
void setFELOST(string fELOST){
	this.fELOST = fELOST;
}

public
void setFECRCM(string fECRCM){
	this.fECRCM = fECRCM;
}

public
void setFEUSE(string fEUSE){
	this.fEUSE = fEUSE;
}

public
void setFESLCS(string fESLCS){
	this.fESLCS = fESLCS;
}

public
void setFECRTY(string fECRTY){
	this.fECRTY = fECRTY;
}

public
void setFECRDT(string fECRDT){
	this.fECRDT = fECRDT;
}

public
void setFECRD(string fECRD){
	this.fECRD = fECRD;
}

public
void setFEEXPR(string fEEXPR){
	this.fEEXPR = fEEXPR;
}

public
void setFEHODR(string fEHODR){
	this.fEHODR = fEHODR;
}

public
void setFECRNM(decimal fECRNM){
	this.fECRNM = fECRNM;
}

public
void setFESHBF(string fESHBF){
	this.fESHBF = fESHBF;
}

public
void setFECLEN(string fECLEN){
	this.fECLEN = fECLEN;
}

public
void setFEPLTC(string fEPLTC){
	this.fEPLTC = fEPLTC;
}

public
void setFEFUT1(string fEFUT1){
	this.fEFUT1 = fEFUT1;
}

public
void setFEFUT2(string fEFUT2){
	this.fEFUT2 = fEFUT2;
}

public
void setFEFUT3(string fEFUT3){
	this.fEFUT3 = fEFUT3;
}

public
void setFEFUT4(string fEFUT4){
	this.fEFUT4 = fEFUT4;
}

public
void setFEFUT5(string fEFUT5){
	this.fEFUT5 = fEFUT5;
}

public
void setFEFUT6(string fEFUT6){
	this.fEFUT6 = fEFUT6;
}

public
void setFEFUT7(string fEFUT7){
	this.fEFUT7 = fEFUT7;
}

public
void setFEFUT8(string fEFUT8){
	this.fEFUT8 = fEFUT8;
}

public
void setFEFUT9(string fEFUT9){
	this.fEFUT9 = fEFUT9;
}

public
void setFEFUTA(string fEFUTA){
	this.fEFUTA = fEFUTA;
}

public
void setFEFUTB(string fEFUTB){
	this.fEFUTB = fEFUTB;
}

public
void setFEFUTC(decimal fEFUTC){
	this.fEFUTC = fEFUTC;
}

public
void setFEFUTD(string fEFUTD){
	this.fEFUTD = fEFUTD;
}

public
void setFEFUTE(string fEFUTE){
	this.fEFUTE = fEFUTE;
}

public
void setFEFUTF(string fEFUTF){
	this.fEFUTF = fEFUTF;
}

public
void setFEFUTG(string fEFUTG){
	this.fEFUTG = fEFUTG;
}

public
void setFEFUTK(string fEFUTK){
    this.fEFUTK = fEFUTK;
}

public
void setfEFUTP(string fEFUTP){
    this.fEFUTP = fEFUTP;
}

public 
void setCustomerEdi(CustomerEdi customerEdi){
	this.customerEdi = customerEdi;
}


public 
void setBoldContainer(BoldContainer boldContainer){
	this.boldContainer = boldContainer;
}

public
void setShcr(Shcr shcr){
	this.shcr = shcr;
}
public
void setBolNPContainer(BolNpContainer bolNpContainer){
	this.bolNpContainer = bolNpContainer;
}
public
void setBolhref(Bolhref bolhref){
	this.bolhref = bolhref;
}

public
decimal getFEBOL(){
	 return fEBOL;
}

public
string getFEBTYP(){
	 return fEBTYP;
}

public
DateTime getFECDAT(){
	 return fECDAT;
}

public
string getFEPIND(){
	 return fEPIND;
}

public
string getFESIND(){
	 return fESIND;
}

public
string getFEBCS(){
	 return fEBCS;
}

public
string getFESCS(){
	 return fESCS;
}

public
string getFESVND(){
	 return fESVND;
}

public
string getFERVND(){
	 return fERVND;
}

public
string getFEBNME(){
	 return fEBNME;
}

public
string getFEBPTC(){
	 return fEBPTC;
}

public
string getFEATTN(){
	 return fEATTN;
}

public
string getFESNME(){
	 return fESNME;
}

public
string getFESAD1(){
	 return fESAD1;
}

public
string getFESAD2(){
	 return fESAD2;
}

public
string getFESAD3(){
	 return fESAD3;
}

public
string getFESAD4(){
	 return fESAD4;
}

public
string getFESAD5(){
	 return fESAD5;
}

public
string getFESAD6(){
	 return fESAD6;
}

public
string getFESAD7(){
	 return fESAD7;
}

public
string getFESAD8(){
	 return fESAD8;
}

public
string getFESAD9(){
	 return fESAD9;
}

public
string getFESAD10(){
	 return fESAD10;
}

public
string getFESPTC(){
	 return fESPTC;
}

public
DateTime getFESDAT(){
	 return fESDAT;
}

public
string getFESVIA(){
	 return fESVIA;
}

public
string getFETKID(){
	 return fETKID;
}

public
decimal getFENCTN(){
	 return fENCTN;
}

public
decimal getFENETW(){
	 return fENETW;
}

public
decimal getFEGROW(){
	 return fEGROW;
}

public
decimal getFETARW(){
	 return fETARW;
}

public
string getFEWTUN(){
	 return fEWTUN;
}

public
string getFEDOCD(){
	 return fEDOCD;
}

public
string getFEFTCD(){
	 return fEFTCD;
}

public
decimal getFEORD(){
	 return fEORD;
}

public
string getFESTKL(){
	 return fESTKL;
}

public
decimal getFEFTAM(){
	 return fEFTAM;
}

public
string getFEFOB(){
	 return fEFOB;
}

public
string getFECARC(){
	 return fECARC;
}

public
string getFESERC(){
	 return fESERC;
}

public
decimal getFESTME(){
	 return fESTME;
}

public
string getFEJITF(){
	 return fEJITF;
}

public
string getFESID(){
	 return fESID;
}

public
string getFETRPT(){
	 return fETRPT;
}

public
string getFEBID(){
	 return fEBID;
}

public
string getFESFID(){
	 return fESFID;
}

public
string getFEPLNT(){
	 return fEPLNT;
}

public
string getFEITMC(){
	 return fEITMC;
}

public
string getFESUPP(){
	 return fESUPP;
}

public
string getFEULTD(){
	 return fEULTD;
}

public
DateTime getFEEDAT(){
	 return fEEDAT;
}

public
decimal getFEETIM(){
	 return fEETIM;
}

public
DateTime getFEADAT(){
	 return fEADAT;
}

public
decimal getFEATIM(){
	 return fEATIM;
}

public
string getFETRNM(){
	 return fETRNM;
}

public
string getFERTEG(){
	 return fERTEG;
}

public
string getFEPLPT(){
	 return fEPLPT;
}

public
string getFEPLOC(){
	 return fEPLOC;
}

public
string getFEEQPD(){
	 return fEEQPD;
}

public
string getFEEQPI(){
	 return fEEQPI;
}

public
string getFEEQID(){
	 return fEEQID;
}

public
decimal getFEMBOL(){
	 return fEMBOL;
}

public
string getFEPSLP(){
	 return fEPSLP;
}

public
string getFEFRTB(){
	 return fEFRTB;
}

public
string getFEAIRB(){
	 return fEAIRB;
}

public
string getFETSPR(){
	 return fETSPR;
}

public
string getFEETRR(){
	 return fEETRR;
}

public
string getFEEXTR(){
	 return fEEXTR;
}

public
string getFEAETC(){
	 return fEAETC;
}

public
string getFEMTHP(){
	 return fEMTHP;
}

public
string getFETRNT(){
	 return fETRNT;
}

public
string getFETRLQ(){
	 return fETRLQ;
}

public
string getFECCT(){
	 return fECCT;
}

public
string getFECCDE(){
	 return fECCDE;
}

public
string getFESASN(){
	 return fESASN;
}

public
string getFESNTF(){
	 return fESNTF;
}

public
string getFESTS(){
	 return fESTS;
}

public
string getFEXMOD(){
	 return fEXMOD;
}

public
string getFEATYP(){
	 return fEATYP;
}

public
string getFEFLD1(){
	 return fEFLD1;
}

public
string getFEFLD2(){
	 return fEFLD2;
}

public
string getFEFLD3(){
	 return fEFLD3;
}

public
string getFEFLD4(){
	 return fEFLD4;
}

public
string getFEFLD5(){
	 return fEFLD5;
}

public
string getFEFLD6(){
	 return fEFLD6;
}

public
string getFEMANW(){
	 return fEMANW;
}

public
string getFES204(){
	 return fES204;
}

public
string getFEBTRP(){
	 return fEBTRP;
}

public
string getFEBSTS(){
	 return fEBSTS;
}

public
string getFEBACK(){
	 return fEBACK;
}

public
string getFEBSET(){
	 return fEBSET;
}

public
string getFEBMOD(){
	 return fEBMOD;
}

public
decimal getFESKDQ(){
	 return fESKDQ;
}

public
string getFESKDT(){
	 return fESKDT;
}

public
decimal getFELOSQ(){
	 return fELOSQ;
}

public
string getFELOST(){
	 return fELOST;
}

public
string getFECRCM(){
	 return fECRCM;
}

public
string getFEUSE(){
	 return fEUSE;
}

public
string getFESLCS(){
	 return fESLCS;
}

public
string getFECRTY(){
	 return fECRTY;
}

public
string getFECRDT(){
	 return fECRDT;
}

public
string getFECRD(){
	 return fECRD;
}

public
string getFEEXPR(){
	 return fEEXPR;
}

public
string getFEHODR(){
	 return fEHODR;
}

public
decimal getFECRNM(){
	 return fECRNM;
}

public
string getFESHBF(){
	 return fESHBF;
}

public
string getFECLEN(){
	 return fECLEN;
}

public
string getFEPLTC(){
	 return fEPLTC;
}

public
string getFEFUT1(){
	 return fEFUT1;
}

public
string getFEFUT2(){
	 return fEFUT2;
}

public
string getFEFUT3(){
	 return fEFUT3;
}

public
string getFEFUT4(){
	 return fEFUT4;
}

public
string getFEFUT5(){
	 return fEFUT5;
}

public
string getFEFUT6(){
	 return fEFUT6;
}

public
string getFEFUT7(){
	 return fEFUT7;
}

public
string getFEFUT8(){
	 return fEFUT8;
}

public
string getFEFUT9(){
	 return fEFUT9;
}

public
string getFEFUTA(){
	 return fEFUTA;
}

public
string getFEFUTB(){
	 return fEFUTB;
}

public
decimal getFEFUTC(){
	 return fEFUTC;
}

public
string getFEFUTD(){
	 return fEFUTD;
}

public
string getFEFUTE(){
	 return fEFUTE;
}

public
string getFEFUTF(){
	 return fEFUTF;
}

public
string getFEFUTG(){
	 return fEFUTG;
}

public
string getFEFUTK(){
    return fEFUTK;
}

public
string getfEFUTP(){
    return fEFUTP;
}

public
BoldContainer getBoldContainer() {
	return boldContainer;
}

public
BolNpContainer getBolNpContainer(){
	return bolNpContainer;
}

public
Shcr getShcr(){
	return shcr;
}

public 
Bolhref getBolhref(){
	return bolhref;
}

public override
bool Equals(object obj){
	if (obj is Bol)
		return	this.fEBOL.Equals(((Bol)obj).getFEBOL());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public 
void addBold(Bold bold){
	this.boldContainer.Add(bold);
}

public
void fillRedundances(){

	foreach(Bold bold in boldContainer){
		bold.setFGBOL(this.getFEBOL());
		bold.fillRedundances();		
	}	
}



public
CustomerEdi getCustomerEdi(){
	return customerEdi;
}

public
Bold getItemByPart(string part){
    bool found=false;
    Bold bold=null,boldAux=null;

    for(int i=0;i < boldContainer.getSize() && !found;i++){
        boldAux = boldContainer.getAt(i);
        if (boldAux.getFGPART().Equals(part) && boldAux.getEdiProcessed().Equals(Constants.STRING_NO)){
            bold = boldAux;
            found=true;
        }		
	}
    return bold;
}


[System.Runtime.Serialization.DataMember]
public
decimal FEBOL {
	get { return fEBOL;}
	set { if (this.fEBOL != value){
			this.fEBOL = value;
			Notify("FEBOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBTYP {
	get { return fEBTYP;}
	set { if (this.fEBTYP != value){
			this.fEBTYP = value;
			Notify("FEBTYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FECDAT {
	get { return fECDAT;}
	set { if (this.fECDAT != value){
			this.fECDAT = value;
			Notify("FECDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPIND {
	get { return fEPIND;}
	set { if (this.fEPIND != value){
			this.fEPIND = value;
			Notify("FEPIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESIND {
	get { return fESIND;}
	set { if (this.fESIND != value){
			this.fESIND = value;
			Notify("FESIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBCS {
	get { return fEBCS;}
	set { if (this.fEBCS != value){
			this.fEBCS = value;
			Notify("FEBCS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESCS {
	get { return fESCS;}
	set { if (this.fESCS != value){
			this.fESCS = value;
			Notify("FESCS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESVND {
	get { return fESVND;}
	set { if (this.fESVND != value){
			this.fESVND = value;
			Notify("FESVND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FERVND {
	get { return fERVND;}
	set { if (this.fERVND != value){
			this.fERVND = value;
			Notify("FERVND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBNME {
	get { return fEBNME;}
	set { if (this.fEBNME != value){
			this.fEBNME = value;
			Notify("FEBNME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBPTC {
	get { return fEBPTC;}
	set { if (this.fEBPTC != value){
			this.fEBPTC = value;
			Notify("FEBPTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEATTN {
	get { return fEATTN;}
	set { if (this.fEATTN != value){
			this.fEATTN = value;
			Notify("FEATTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESNME {
	get { return fESNME;}
	set { if (this.fESNME != value){
			this.fESNME = value;
			Notify("FESNME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD1 {
	get { return fESAD1;}
	set { if (this.fESAD1 != value){
			this.fESAD1 = value;
			Notify("FESAD1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD2 {
	get { return fESAD2;}
	set { if (this.fESAD2 != value){
			this.fESAD2 = value;
			Notify("FESAD2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD3 {
	get { return fESAD3;}
	set { if (this.fESAD3 != value){
			this.fESAD3 = value;
			Notify("FESAD3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD4 {
	get { return fESAD4;}
	set { if (this.fESAD4 != value){
			this.fESAD4 = value;
			Notify("FESAD4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD5 {
	get { return fESAD5;}
	set { if (this.fESAD5 != value){
			this.fESAD5 = value;
			Notify("FESAD5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD6 {
	get { return fESAD6;}
	set { if (this.fESAD6 != value){
			this.fESAD6 = value;
			Notify("FESAD6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD7 {
	get { return fESAD7;}
	set { if (this.fESAD7 != value){
			this.fESAD7 = value;
			Notify("FESAD7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD8 {
	get { return fESAD8;}
	set { if (this.fESAD8 != value){
			this.fESAD8 = value;
			Notify("FESAD8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD9 {
	get { return fESAD9;}
	set { if (this.fESAD9 != value){
			this.fESAD9 = value;
			Notify("FESAD9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESAD10 {
	get { return fESAD10;}
	set { if (this.fESAD10 != value){
			this.fESAD10 = value;
			Notify("FESAD10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESPTC {
	get { return fESPTC;}
	set { if (this.fESPTC != value){
			this.fESPTC = value;
			Notify("FESPTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESCTY {
	get { return fESCTY;}
	set { if (this.fESCTY != value){
			this.fESCTY = value;
			Notify("FESCTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESPOV {
	get { return fESPOV;}
	set { if (this.fESPOV != value){
			this.fESPOV = value;
			Notify("FESPOV");
		}
	}
}

 /* 
[System.Runtime.Serialization.DataMember]
public
string FESCRY {
	get { return fESCRY;}
	set { if (this.fESCRY != value){
			this.fESCRY = value;
			Notify("FESCRY");
		}
	}
}
*/
[System.Runtime.Serialization.DataMember]
public
DateTime FESDAT {
	get { return fESDAT;}
	set { if (this.fESDAT != value){
			this.fESDAT = value;
			Notify("FESDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESVIA {
	get { return fESVIA;}
	set { if (this.fESVIA != value){
			this.fESVIA = value;
			Notify("FESVIA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETKID {
	get { return fETKID;}
	set { if (this.fETKID != value){
			this.fETKID = value;
			Notify("FETKID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FENCTN {
	get { return fENCTN;}
	set { if (this.fENCTN != value){
			this.fENCTN = value;
			Notify("FENCTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FENETW {
	get { return fENETW;}
	set { if (this.fENETW != value){
			this.fENETW = value;
			Notify("FENETW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEGROW {
	get { return fEGROW;}
	set { if (this.fEGROW != value){
			this.fEGROW = value;
			Notify("FEGROW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FETARW {
	get { return fETARW;}
	set { if (this.fETARW != value){
			this.fETARW = value;
			Notify("FETARW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEWTUN {
	get { return fEWTUN;}
	set { if (this.fEWTUN != value){
			this.fEWTUN = value;
			Notify("FEWTUN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEDOCD {
	get { return fEDOCD;}
	set { if (this.fEDOCD != value){
			this.fEDOCD = value;
			Notify("FEDOCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFTCD {
	get { return fEFTCD;}
	set { if (this.fEFTCD != value){
			this.fEFTCD = value;
			Notify("FEFTCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEORD {
	get { return fEORD;}
	set { if (this.fEORD != value){
			this.fEORD = value;
			Notify("FEORD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESTKL {
	get { return fESTKL;}
	set { if (this.fESTKL != value){
			this.fESTKL = value;
			Notify("FESTKL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEFTAM {
	get { return fEFTAM;}
	set { if (this.fEFTAM != value){
			this.fEFTAM = value;
			Notify("FEFTAM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFOB {
	get { return fEFOB;}
	set { if (this.fEFOB != value){
			this.fEFOB = value;
			Notify("FEFOB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECARC {
	get { return fECARC;}
	set { if (this.fECARC != value){
			this.fECARC = value;
			Notify("FECARC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESERC {
	get { return fESERC;}
	set { if (this.fESERC != value){
			this.fESERC = value;
			Notify("FESERC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FESTME {
	get { return fESTME;}
	set { if (this.fESTME != value){
			this.fESTME = value;
			Notify("FESTME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEJITF {
	get { return fEJITF;}
	set { if (this.fEJITF != value){
			this.fEJITF = value;
			Notify("FEJITF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESID {
	get { return fESID;}
	set { if (this.fESID != value){
			this.fESID = value;
			Notify("FESID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETRPT {
	get { return fETRPT;}
	set { if (this.fETRPT != value){
			this.fETRPT = value;
			Notify("FETRPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBID {
	get { return fEBID;}
	set { if (this.fEBID != value){
			this.fEBID = value;
			Notify("FEBID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESFID {
	get { return fESFID;}
	set { if (this.fESFID != value){
			this.fESFID = value;
			Notify("FESFID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPLNT {
	get { return fEPLNT;}
	set { if (this.fEPLNT != value){
			this.fEPLNT = value;
			Notify("FEPLNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEITMC {
	get { return fEITMC;}
	set { if (this.fEITMC != value){
			this.fEITMC = value;
			Notify("FEITMC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESUPP {
	get { return fESUPP;}
	set { if (this.fESUPP != value){
			this.fESUPP = value;
			Notify("FESUPP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEULTD {
	get { return fEULTD;}
	set { if (this.fEULTD != value){
			this.fEULTD = value;
			Notify("FEULTD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FEEDAT {
	get { return fEEDAT;}
	set { if (this.fEEDAT != value){
			this.fEEDAT = value;
			Notify("FEEDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEETIM {
	get { return fEETIM;}
	set { if (this.fEETIM != value){
			this.fEETIM = value;
			Notify("FEETIM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FEADAT {
	get { return fEADAT;}
	set { if (this.fEADAT != value){
			this.fEADAT = value;
			Notify("FEADAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEATIM {
	get { return fEATIM;}
	set { if (this.fEATIM != value){
			this.fEATIM = value;
			Notify("FEATIM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETRNM {
	get { return fETRNM;}
	set { if (this.fETRNM != value){
			this.fETRNM = value;
			Notify("FETRNM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FERTEG {
	get { return fERTEG;}
	set { if (this.fERTEG != value){
			this.fERTEG = value;
			Notify("FERTEG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPLPT {
	get { return fEPLPT;}
	set { if (this.fEPLPT != value){
			this.fEPLPT = value;
			Notify("FEPLPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPLOC {
	get { return fEPLOC;}
	set { if (this.fEPLOC != value){
			this.fEPLOC = value;
			Notify("FEPLOC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEEQPD {
	get { return fEEQPD;}
	set { if (this.fEEQPD != value){
			this.fEEQPD = value;
			Notify("FEEQPD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEEQPI {
	get { return fEEQPI;}
	set { if (this.fEEQPI != value){
			this.fEEQPI = value;
			Notify("FEEQPI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEEQID {
	get { return fEEQID;}
	set { if (this.fEEQID != value){
			this.fEEQID = value;
			Notify("FEEQID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEMBOL {
	get { return fEMBOL;}
	set { if (this.fEMBOL != value){
			this.fEMBOL = value;
			Notify("FEMBOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPSLP {
	get { return fEPSLP;}
	set { if (this.fEPSLP != value){
			this.fEPSLP = value;
			Notify("FEPSLP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFRTB {
	get { return fEFRTB;}
	set { if (this.fEFRTB != value){
			this.fEFRTB = value;
			Notify("FEFRTB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEAIRB {
	get { return fEAIRB;}
	set { if (this.fEAIRB != value){
			this.fEAIRB = value;
			Notify("FEAIRB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETSPR {
	get { return fETSPR;}
	set { if (this.fETSPR != value){
			this.fETSPR = value;
			Notify("FETSPR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEETRR {
	get { return fEETRR;}
	set { if (this.fEETRR != value){
			this.fEETRR = value;
			Notify("FEETRR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEEXTR {
	get { return fEEXTR;}
	set { if (this.fEEXTR != value){
			this.fEEXTR = value;
			Notify("FEEXTR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEAETC {
	get { return fEAETC;}
	set { if (this.fEAETC != value){
			this.fEAETC = value;
			Notify("FEAETC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEMTHP {
	get { return fEMTHP;}
	set { if (this.fEMTHP != value){
			this.fEMTHP = value;
			Notify("FEMTHP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETRNT {
	get { return fETRNT;}
	set { if (this.fETRNT != value){
			this.fETRNT = value;
			Notify("FETRNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETRLQ {
	get { return fETRLQ;}
	set { if (this.fETRLQ != value){
			this.fETRLQ = value;
			Notify("FETRLQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECCT {
	get { return fECCT;}
	set { if (this.fECCT != value){
			this.fECCT = value;
			Notify("FECCT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECCDE {
	get { return fECCDE;}
	set { if (this.fECCDE != value){
			this.fECCDE = value;
			Notify("FECCDE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESASN {
	get { return fESASN;}
	set { if (this.fESASN != value){
			this.fESASN = value;
			Notify("FESASN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESNTF {
	get { return fESNTF;}
	set { if (this.fESNTF != value){
			this.fESNTF = value;
			Notify("FESNTF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESTS {
	get { return fESTS;}
	set { if (this.fESTS != value){
			this.fESTS = value;
			Notify("FESTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEXMOD {
	get { return fEXMOD;}
	set { if (this.fEXMOD != value){
			this.fEXMOD = value;
			Notify("FEXMOD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEATYP {
	get { return fEATYP;}
	set { if (this.fEATYP != value){
			this.fEATYP = value;
			Notify("FEATYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFLD1 {
	get { return fEFLD1;}
	set { if (this.fEFLD1 != value){
			this.fEFLD1 = value;
			Notify("FEFLD1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFLD2 {
	get { return fEFLD2;}
	set { if (this.fEFLD2 != value){
			this.fEFLD2 = value;
			Notify("FEFLD2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFLD3 {
	get { return fEFLD3;}
	set { if (this.fEFLD3 != value){
			this.fEFLD3 = value;
			Notify("FEFLD3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFLD4 {
	get { return fEFLD4;}
	set { if (this.fEFLD4 != value){
			this.fEFLD4 = value;
			Notify("FEFLD4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFLD5 {
	get { return fEFLD5;}
	set { if (this.fEFLD5 != value){
			this.fEFLD5 = value;
			Notify("FEFLD5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFLD6 {
	get { return fEFLD6;}
	set { if (this.fEFLD6 != value){
			this.fEFLD6 = value;
			Notify("FEFLD6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEMANW {
	get { return fEMANW;}
	set { if (this.fEMANW != value){
			this.fEMANW = value;
			Notify("FEMANW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FES204 {
	get { return fES204;}
	set { if (this.fES204 != value){
			this.fES204 = value;
			Notify("FES204");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBTRP {
	get { return fEBTRP;}
	set { if (this.fEBTRP != value){
			this.fEBTRP = value;
			Notify("FEBTRP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBSTS {
	get { return fEBSTS;}
	set { if (this.fEBSTS != value){
			this.fEBSTS = value;
			Notify("FEBSTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBACK {
	get { return fEBACK;}
	set { if (this.fEBACK != value){
			this.fEBACK = value;
			Notify("FEBACK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBSET {
	get { return fEBSET;}
	set { if (this.fEBSET != value){
			this.fEBSET = value;
			Notify("FEBSET");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBMOD {
	get { return fEBMOD;}
	set { if (this.fEBMOD != value){
			this.fEBMOD = value;
			Notify("FEBMOD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FESKDQ {
	get { return fESKDQ;}
	set { if (this.fESKDQ != value){
			this.fESKDQ = value;
			Notify("FESKDQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESKDT {
	get { return fESKDT;}
	set { if (this.fESKDT != value){
			this.fESKDT = value;
			Notify("FESKDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FELOSQ {
	get { return fELOSQ;}
	set { if (this.fELOSQ != value){
			this.fELOSQ = value;
			Notify("FELOSQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FELOST {
	get { return fELOST;}
	set { if (this.fELOST != value){
			this.fELOST = value;
			Notify("FELOST");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECRCM {
	get { return fECRCM;}
	set { if (this.fECRCM != value){
			this.fECRCM = value;
			Notify("FECRCM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEUSE {
	get { return fEUSE;}
	set { if (this.fEUSE != value){
			this.fEUSE = value;
			Notify("FEUSE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESLCS {
	get { return fESLCS;}
	set { if (this.fESLCS != value){
			this.fESLCS = value;
			Notify("FESLCS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECRTY {
	get { return fECRTY;}
	set { if (this.fECRTY != value){
			this.fECRTY = value;
			Notify("FECRTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECRDT {
	get { return fECRDT;}
	set { if (this.fECRDT != value){
			this.fECRDT = value;
			Notify("FECRDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECRD {
	get { return fECRD;}
	set { if (this.fECRD != value){
			this.fECRD = value;
			Notify("FECRD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEEXPR {
	get { return fEEXPR;}
	set { if (this.fEEXPR != value){
			this.fEEXPR = value;
			Notify("FEEXPR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEHODR {
	get { return fEHODR;}
	set { if (this.fEHODR != value){
			this.fEHODR = value;
			Notify("FEHODR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FECRNM {
	get { return fECRNM;}
	set { if (this.fECRNM != value){
			this.fECRNM = value;
			Notify("FECRNM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESHBF {
	get { return fESHBF;}
	set { if (this.fESHBF != value){
			this.fESHBF = value;
			Notify("FESHBF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECLEN {
	get { return fECLEN;}
	set { if (this.fECLEN != value){
			this.fECLEN = value;
			Notify("FECLEN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPLTC {
	get { return fEPLTC;}
	set { if (this.fEPLTC != value){
			this.fEPLTC = value;
			Notify("FEPLTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT1 {
	get { return fEFUT1;}
	set { if (this.fEFUT1 != value){
			this.fEFUT1 = value;
			Notify("FEFUT1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT2 {
	get { return fEFUT2;}
	set { if (this.fEFUT2 != value){
			this.fEFUT2 = value;
			Notify("FEFUT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT3 {
	get { return fEFUT3;}
	set { if (this.fEFUT3 != value){
			this.fEFUT3 = value;
			Notify("FEFUT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT4 {
	get { return fEFUT4;}
	set { if (this.fEFUT4 != value){
			this.fEFUT4 = value;
			Notify("FEFUT4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT5 {
	get { return fEFUT5;}
	set { if (this.fEFUT5 != value){
			this.fEFUT5 = value;
			Notify("FEFUT5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT6 {
	get { return fEFUT6;}
	set { if (this.fEFUT6 != value){
			this.fEFUT6 = value;
			Notify("FEFUT6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT7 {
	get { return fEFUT7;}
	set { if (this.fEFUT7 != value){
			this.fEFUT7 = value;
			Notify("FEFUT7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT8 {
	get { return fEFUT8;}
	set { if (this.fEFUT8 != value){
			this.fEFUT8 = value;
			Notify("FEFUT8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUT9 {
	get { return fEFUT9;}
	set { if (this.fEFUT9 != value){
			this.fEFUT9 = value;
			Notify("FEFUT9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTA {
	get { return fEFUTA;}
	set { if (this.fEFUTA != value){
			this.fEFUTA = value;
			Notify("FEFUTA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTB {
	get { return fEFUTB;}
	set { if (this.fEFUTB != value){
			this.fEFUTB = value;
			Notify("FEFUTB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEFUTC {
	get { return fEFUTC;}
	set { if (this.fEFUTC != value){
			this.fEFUTC = value;
			Notify("FEFUTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTD {
	get { return fEFUTD;}
	set { if (this.fEFUTD != value){
			this.fEFUTD = value;
			Notify("FEFUTD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTE {
	get { return fEFUTE;}
	set { if (this.fEFUTE != value){
			this.fEFUTE = value;
			Notify("FEFUTE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTF {
	get { return fEFUTF;}
	set { if (this.fEFUTF != value){
			this.fEFUTF = value;
			Notify("FEFUTF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTG {
	get { return fEFUTG;}
	set { if (this.fEFUTG != value){
			this.fEFUTG = value;
			Notify("FEFUTG");
		}
	}
}

/*
[System.Runtime.Serialization.DataMember]
public
string FELDTY {
	get { return fELDTY;}
	set { if (this.fELDTY != value){
			this.fELDTY = value;
			Notify("FELDTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETKST {
	get { return fETKST;}
	set { if (this.fETKST != value){
			this.fETKST = value;
			Notify("FETKST");
		}
	}
}
*/
[System.Runtime.Serialization.DataMember]
public
string FERTS {
	get { return fERTS;}
	set { if (this.fERTS != value){
			this.fERTS = value;
			Notify("FERTS");
		}
	}
}

/*
[System.Runtime.Serialization.DataMember]
public
string FEFUTH {
	get { return fEFUTH;}
	set { if (this.fEFUTH != value){
			this.fEFUTH = value;
			Notify("FEFUTH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTI {
	get { return fEFUTI;}
	set { if (this.fEFUTI != value){
			this.fEFUTI = value;
			Notify("FEFUTI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTJ {
	get { return fEFUTJ;}
	set { if (this.fEFUTJ != value){
			this.fEFUTJ = value;
			Notify("FEFUTJ");
		}
	}
}
    */
[System.Runtime.Serialization.DataMember]
public
string FEFUTK {
	get { return fEFUTK;}
	set { if (this.fEFUTK != value){
			this.fEFUTK = value;
			Notify("FEFUTK");
		}
	}
}

/*
[System.Runtime.Serialization.DataMember]
public
string FEFUTL {
	get { return fEFUTL;}
	set { if (this.fEFUTL != value){
			this.fEFUTL = value;
			Notify("FEFUTL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTM {
	get { return fEFUTM;}
	set { if (this.fEFUTM != value){
			this.fEFUTM = value;
			Notify("FEFUTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTN {
	get { return fEFUTN;}
	set { if (this.fEFUTN != value){
			this.fEFUTN = value;
			Notify("FEFUTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTO {
	get { return fEFUTO;}
	set { if (this.fEFUTO != value){
			this.fEFUTO = value;
			Notify("FEFUTO");
		}
	}
}
*/
[System.Runtime.Serialization.DataMember]
public
string FEFUTP {
	get { return fEFUTP;}
	set { if (this.fEFUTP != value){
			this.fEFUTP = value;
			Notify("FEFUTP");
		}
	}
}

/*
[System.Runtime.Serialization.DataMember]
public
string FEFUTQ {
	get { return fEFUTQ;}
	set { if (this.fEFUTQ != value){
			this.fEFUTQ = value;
			Notify("FEFUTQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTR {
	get { return fEFUTR;}
	set { if (this.fEFUTR != value){
			this.fEFUTR = value;
			Notify("FEFUTR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTS {
	get { return fEFUTS;}
	set { if (this.fEFUTS != value){
			this.fEFUTS = value;
			Notify("FEFUTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTT {
	get { return fEFUTT;}
	set { if (this.fEFUTT != value){
			this.fEFUTT = value;
			Notify("FEFUTT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTU {
	get { return fEFUTU;}
	set { if (this.fEFUTU != value){
			this.fEFUTU = value;
			Notify("FEFUTU");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTV {
	get { return fEFUTV;}
	set { if (this.fEFUTV != value){
			this.fEFUTV = value;
			Notify("FEFUTV");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTW {
	get { return fEFUTW;}
	set { if (this.fEFUTW != value){
			this.fEFUTW = value;
			Notify("FEFUTW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEFUTX {
	get { return fEFUTX;}
	set { if (this.fEFUTX != value){
			this.fEFUTX = value;
			Notify("FEFUTX");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEFUTY {
	get { return fEFUTY;}
	set { if (this.fEFUTY != value){
			this.fEFUTY = value;
			Notify("FEFUTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FEFUTZ {
	get { return fEFUTZ;}
	set { if (this.fEFUTZ != value){
			this.fEFUTZ = value;
			Notify("FEFUTZ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FESCNC {
	get { return fESCNC;}
	set { if (this.fESCNC != value){
			this.fESCNC = value;
			Notify("FESCNC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FEDDAT {
	get { return fEDDAT;}
	set { if (this.fEDDAT != value){
			this.fEDDAT = value;
			Notify("FEDDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEDCMT {
	get { return fEDCMT;}
	set { if (this.fEDCMT != value){
			this.fEDCMT = value;
			Notify("FEDCMT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEMBL {
	get { return fEMBL;}
	set { if (this.fEMBL != value){
			this.fEMBL = value;
			Notify("FEMBL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEATMZ {
	get { return fEATMZ;}
	set { if (this.fEATMZ != value){
			this.fEATMZ = value;
			Notify("FEATMZ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEETMZ {
	get { return fEETMZ;}
	set { if (this.fEETMZ != value){
			this.fEETMZ = value;
			Notify("FEETMZ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESTMZ {
	get { return fESTMZ;}
	set { if (this.fESTMZ != value){
			this.fESTMZ = value;
			Notify("FESTMZ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FECTMZ {
	get { return fECTMZ;}
	set { if (this.fECTMZ != value){
			this.fECTMZ = value;
			Notify("FECTMZ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPSTS {
	get { return fEPSTS;}
	set { if (this.fEPSTS != value){
			this.fEPSTS = value;
			Notify("FEPSTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FETENT {
	get { return fETENT;}
	set { if (this.fETENT != value){
			this.fETENT = value;
			Notify("FETENT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPQN {
	get { return fEPQN;}
	set { if (this.fEPQN != value){
			this.fEPQN = value;
			Notify("FEPQN");
		}
	}
}
    */
[System.Runtime.Serialization.DataMember]
public
string FETAMT {
	get { return fETAMT;}
	set { if (this.fETAMT != value){
			this.fETAMT = value;
			Notify("FETAMT");
		}
	}
}
    /*
[System.Runtime.Serialization.DataMember]
public
string FEIBN {
	get { return fEIBN;}
	set { if (this.fEIBN != value){
			this.fEIBN = value;
			Notify("FEIBN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESTTP {
	get { return fESTTP;}
	set { if (this.fESTTP != value){
			this.fESTTP = value;
			Notify("FESTTP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESTCN {
	get { return fESTCN;}
	set { if (this.fESTCN != value){
			this.fESTCN = value;
			Notify("FESTCN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEEXPDT {
	get { return fEEXPDT;}
	set { if (this.fEEXPDT != value){
			this.fEEXPDT = value;
			Notify("FEEXPDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEDLTB {
	get { return fEDLTB;}
	set { if (this.fEDLTB != value){
			this.fEDLTB = value;
			Notify("FEDLTB");
		}
	}
}
*/
public
Bolm Bolm{
    get { return bolm; }
	set { if (this.bolm != value){
            this.bolm = value;
            Notify("Bolm");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RAMBOL {	
    get {
        return bolm!=null ? bolm.RAMBOL : 0;
    }
	set { if (bolm!= null && bolm.RAMBOL != value){
            bolm.RAMBOL = value;
			Notify("RASIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASIND {
	get {
        return bolm!=null ? bolm.RASIND : "";
    }
	set { if (bolm!= null && bolm.RASIND != value){
            bolm.RASIND = value;
			Notify("RASIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASVIA {
	get {
        return bolm != null ? bolm.RASVIA : "";
    }
	set { if (bolm!= null && bolm.RASVIA != value){
            bolm.RASVIA = value;
            Notify("RASVIA");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string RATKID {
	get {
        return bolm != null ? bolm.RATKID : "";
    }
	set { if (bolm!= null && bolm.RATKID != value){
            bolm.RATKID = value;
            Notify("RATKID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RASDAT {
	get {
        return bolm != null ? bolm.RASDAT : DateUtil.MinValue;
    }
	set { if (bolm!= null && bolm.RASDAT != value){
            bolm.RASDAT = value;
            Notify("RASDAT");
		}
	}
}

public
DateTime FEPDAT {
	get { return fEPDAT; }
	set { if (this.fEPDAT != value){
			this.fEPDAT = value;
			Notify("FEPDAT");
		}
	}
}

public
decimal FEPTIM {
	get { return fEPTIM; }
	set { if (this.fEPTIM != value){
			this.fEPTIM = value;
			Notify("FEPTIM");
		}
	}
}
   
}//class
}//namespace
