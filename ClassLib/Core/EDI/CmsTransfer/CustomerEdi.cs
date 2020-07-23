using System;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer{


[System.Runtime.Serialization.DataContract]
public
class CustomerEdi : BusinessObject {

private string bVCUST;
private decimal bVCOMP;
private string bVNAME;
private string bVADR1;
private string bVADR2;
private string bVADR3;
private string bVADR4;
private string bVADR5;
private string bVADR6;
private string bVADR7;
private string bVADR8;
private string bVADR9;
private string bVADR10;
private string bVPOST;
private string bVCITY;
private string bVPROV;
private string bVCTRY;
private string bVTELP;
private string bVBORD;
private string bVPRAR;
private string bVPSTE;
private string bVPRCD;
private string bVPSTL;
private string bVFSTE;
private string bVTXGR;
private string bVTXRT;
private string bVPACK;
private string bVNU10;
private string bVSALM;
private string bVTERR;
private string bVSNOT;
private string bVCURR;
private string bVSCOM;
private string bVTYPE;
private string bVCRLE;
private string bVGSTE;
private decimal bVCREL;
private string bVOEM;
private string bVLANG;
private decimal bVSHLT;
private string bVINPO;
private string bVTERM;
private string bVSHCL;
private string bV1B;
private decimal bVDISL;
private string bVARCD;
private string bVINT;
private decimal bVSDAY;
private string bVPORQ;
private string bVCLAS;
private string bVPSTC;
private DateTime bVLDAT;
private decimal bVLINA;
private DateTime bVPDAT;
private decimal bVLPAA;
private decimal bVYTDS;
private decimal bVLYTD;
private decimal bVOUTB;
private string bV15;
private string bVDUNN;
private string bVFAX;
private DateTime bVMDAT;
private string bVBILL;
private string bVGSTL;
private string bV3;
private decimal bVLARA;
private string bVCONT;
private string bVSUPP;
private string bVSFOR;
private decimal bVSFCP;
private string bVMFOR;
private decimal bVMFCP;
private string bVXFOR;
private decimal bVXFCP;
private string bVCARC;
private string bVSERC;
private string bVSUPA;
private string bVTRDP;
private string bVDUNS;
private string bVSFID;
private string bVUSEC;
private string bVSHPR;
private string bVASNY;
private string bVINVY;
private string bVFLG1;
private string bVFLG2;
private string bVFLG3;
private string bVFLG4;
private string bVFLG5;
private string bVFLG6;
private string bVSUMR;
private string bVPLNT;
private string bVDOCK;
private string bVLINE;
private string bVDROP;
private string bVTMOD;
private string bVTTYP;
private string bVEQPI;
private string bVROUT;
private string bVPOOL;
private string bVPOLL;
private string bVJITF;
private string bVAPLG;
private string bVAVER;
private string bVUVER;
private string bVFOBC;
private string bVEMAL;
private string bVWEB;
private string bVDDIR;
private string bVFL01;
private string bVADJC;
private string bVPPCL;
private DateTime bVCDAT;
private string bVIBRQ;
private string bVORSM;
private string bVFL04;
private string bVSTAT;
private string bVREAS;
private string bVFL05;
private string bVFL06;
private string bVFL07;
private string bVCSERD;
private string bVFL08;
private string bVFL09;
private string bVFL10;
private string bVFL11;
private string bVFL12;
private DateTime bVFL13;
private DateTime bVFL14;
private decimal bVFL15;
private decimal bVFL16;
private string bVFL17;
private string bVFL18;
private string bVFL19;
private string bVFL20;

internal
CustomerEdi(){
	this.bVCUST = "";
	this.bVCOMP = 0;
	this.bVNAME = "";
	this.bVADR1 = "";
	this.bVADR2 = "";
	this.bVADR3 = "";
	this.bVADR4 = "";
	this.bVADR5 = "";
	this.bVADR6 = "";
	this.bVADR7 = "";
	this.bVADR8 = "";
	this.bVADR9 = "";
	this.bVADR10 = "";
	this.bVPOST = "";
	this.bVCITY = "";
	this.bVPROV = "";
	this.bVCTRY = "";
	this.bVTELP = "";
	this.bVBORD = "";
	this.bVPRAR = "";
	this.bVPSTE = "";
	this.bVPRCD = "";
	this.bVPSTL = "";
	this.bVFSTE = "";
	this.bVTXGR = "";
	this.bVTXRT = "";
	this.bVPACK = "";
	this.bVNU10 = "";
	this.bVSALM = "";
	this.bVTERR = "";
	this.bVSNOT = "";
	this.bVCURR = "";
	this.bVSCOM = "";
	this.bVTYPE = "";
	this.bVCRLE = "";
	this.bVGSTE = "";
	this.bVCREL = 0;
	this.bVOEM = "";
	this.bVLANG = "";
	this.bVSHLT = 0;
	this.bVINPO = "";
	this.bVTERM = "";
	this.bVSHCL = "";
	this.bV1B = "";
	this.bVDISL = 0;
	this.bVARCD = "";
	this.bVINT = "";
	this.bVSDAY = 0;
	this.bVPORQ = "";
	this.bVCLAS = "";
	this.bVPSTC = "";
	this.bVLDAT = DateUtil.MinValue;
	this.bVLINA = 0;
	this.bVPDAT = DateUtil.MinValue;
	this.bVLPAA = 0;
	this.bVYTDS = 0;
	this.bVLYTD = 0;
	this.bVOUTB = 0;
	this.bV15 = "";
	this.bVDUNN = "";
	this.bVFAX = "";
	this.bVMDAT = DateUtil.MinValue;
	this.bVBILL = "";
	this.bVGSTL = "";
	this.bV3 = "";
	this.bVLARA = 0;
	this.bVCONT = "";
	this.bVSUPP = "";
	this.bVSFOR = "";
	this.bVSFCP = 0;
	this.bVMFOR = "";
	this.bVMFCP = 0;
	this.bVXFOR = "";
	this.bVXFCP = 0;
	this.bVCARC = "";
	this.bVSERC = "";
	this.bVSUPA = "";
	this.bVTRDP = "";
	this.bVDUNS = "";
	this.bVSFID = "";
	this.bVUSEC = "";
	this.bVSHPR = "";
	this.bVASNY = "";
	this.bVINVY = "";
	this.bVFLG1 = "";
	this.bVFLG2 = "";
	this.bVFLG3 = "";
	this.bVFLG4 = "";
	this.bVFLG5 = "";
	this.bVFLG6 = "";
	this.bVSUMR = "";
	this.bVPLNT = "";
	this.bVDOCK = "";
	this.bVLINE = "";
	this.bVDROP = "";
	this.bVTMOD = "";
	this.bVTTYP = "";
	this.bVEQPI = "";
	this.bVROUT = "";
	this.bVPOOL = "";
	this.bVPOLL = "";
	this.bVJITF = "";
	this.bVAPLG = "";
	this.bVAVER = "";
	this.bVUVER = "";
	this.bVFOBC = "";
	this.bVEMAL = "";
	this.bVWEB = "";
	this.bVDDIR = "";
	this.bVFL01 = "";
	this.bVADJC = "";
	this.bVPPCL = "";
	this.bVCDAT = DateUtil.MinValue;
	this.bVIBRQ = "";
	this.bVORSM = "";
	this.bVFL04 = "";
	this.bVSTAT = "";
	this.bVREAS = "";
	this.bVFL05 = "";
	this.bVFL06 = "";
	this.bVFL07 = "";
	this.bVCSERD = "";
	this.bVFL08 = "";
	this.bVFL09 = "";
	this.bVFL10 = "";
	this.bVFL11 = "";
	this.bVFL12 = "";
	this.bVFL13 = DateUtil.MinValue;
	this.bVFL14 = DateUtil.MinValue;
	this.bVFL15 = 0;
	this.bVFL16 = 0;
	this.bVFL17 = "";
	this.bVFL18 = "";
	this.bVFL19 = "";
	this.bVFL20 = "";
}

internal
CustomerEdi(
				string bVCUST,
				decimal bVCOMP,
				string bVNAME,
				string bVADR1,
				string bVADR2,
				string bVADR3,
				string bVADR4,
				string bVADR5,
				string bVADR6,
				string bVADR7,
				string bVADR8,
				string bVADR9,
				string bVADR10,
				string bVPOST,
				string bVCITY,
				string bVPROV,
				string bVCTRY,
				string bVTELP,
				string bVBORD,
				string bVPRAR,
				string bVPSTE,
				string bVPRCD,
				string bVPSTL,
				string bVFSTE,
				string bVTXGR,
				string bVTXRT,
				string bVPACK,
				string bVNU10,
				string bVSALM,
				string bVTERR,
				string bVSNOT,
				string bVCURR,
				string bVSCOM,
				string bVTYPE,
				string bVCRLE,
				string bVGSTE,
				decimal bVCREL,
				string bVOEM,
				string bVLANG,
				decimal bVSHLT,
				string bVINPO,
				string bVTERM,
				string bVSHCL,
				string bV1B,
				decimal bVDISL,
				string bVARCD,
				string bVINT,
				decimal bVSDAY,
				string bVPORQ,
				string bVCLAS,
				string bVPSTC,
				DateTime bVLDAT,
				decimal bVLINA,
				DateTime bVPDAT,
				decimal bVLPAA,
				decimal bVYTDS,
				decimal bVLYTD,
				decimal bVOUTB,
				string bV15,
				string bVDUNN,
				string bVFAX,
				DateTime bVMDAT,
				string bVBILL,
				string bVGSTL,
				string bV3,
				decimal bVLARA,
				string bVCONT,
				string bVSUPP,
				string bVSFOR,
				decimal bVSFCP,
				string bVMFOR,
				decimal bVMFCP,
				string bVXFOR,
				decimal bVXFCP,
				string bVCARC,
				string bVSERC,
				string bVSUPA,
				string bVTRDP,
				string bVDUNS,
				string bVSFID,
				string bVUSEC,
				string bVSHPR,
				string bVASNY,
				string bVINVY,
				string bVFLG1,
				string bVFLG2,
				string bVFLG3,
				string bVFLG4,
				string bVFLG5,
				string bVFLG6,
				string bVSUMR,
				string bVPLNT,
				string bVDOCK,
				string bVLINE,
				string bVDROP,
				string bVTMOD,
				string bVTTYP,
				string bVEQPI,
				string bVROUT,
				string bVPOOL,
				string bVPOLL,
				string bVJITF,
				string bVAPLG,
				string bVAVER,
				string bVUVER,
				string bVFOBC,
				string bVEMAL,
				string bVWEB,
				string bVDDIR,
				string bVFL01,
				string bVADJC,
				string bVPPCL,
				DateTime bVCDAT,
				string bVIBRQ,
				string bVORSM,
				string bVFL04,
				string bVSTAT,
				string bVREAS,
				string bVFL05,
				string bVFL06,
				string bVFL07,
				string bVCSERD,
				string bVFL08,
				string bVFL09,
				string bVFL10,
				string bVFL11,
				string bVFL12,
				DateTime bVFL13,
				DateTime bVFL14,
				decimal bVFL15,
				decimal bVFL16,
				string bVFL17,
				string bVFL18,
				string bVFL19,
				string bVFL20)
{
	this.bVCUST = bVCUST;
	this.bVCOMP = bVCOMP;
	this.bVNAME = bVNAME;
	this.bVADR1 = bVADR1;
	this.bVADR2 = bVADR2;
	this.bVADR3 = bVADR3;
	this.bVADR4 = bVADR4;
	this.bVADR5 = bVADR5;
	this.bVADR6 = bVADR6;
	this.bVADR7 = bVADR7;
	this.bVADR8 = bVADR8;
	this.bVADR9 = bVADR9;
	this.bVADR10 = bVADR10;
	this.bVPOST = bVPOST;
	this.bVCITY = bVCITY;
	this.bVPROV = bVPROV;
	this.bVCTRY = bVCTRY;
	this.bVTELP = bVTELP;
	this.bVBORD = bVBORD;
	this.bVPRAR = bVPRAR;
	this.bVPSTE = bVPSTE;
	this.bVPRCD = bVPRCD;
	this.bVPSTL = bVPSTL;
	this.bVFSTE = bVFSTE;
	this.bVTXGR = bVTXGR;
	this.bVTXRT = bVTXRT;
	this.bVPACK = bVPACK;
	this.bVNU10 = bVNU10;
	this.bVSALM = bVSALM;
	this.bVTERR = bVTERR;
	this.bVSNOT = bVSNOT;
	this.bVCURR = bVCURR;
	this.bVSCOM = bVSCOM;
	this.bVTYPE = bVTYPE;
	this.bVCRLE = bVCRLE;
	this.bVGSTE = bVGSTE;
	this.bVCREL = bVCREL;
	this.bVOEM = bVOEM;
	this.bVLANG = bVLANG;
	this.bVSHLT = bVSHLT;
	this.bVINPO = bVINPO;
	this.bVTERM = bVTERM;
	this.bVSHCL = bVSHCL;
	this.bV1B = bV1B;
	this.bVDISL = bVDISL;
	this.bVARCD = bVARCD;
	this.bVINT = bVINT;
	this.bVSDAY = bVSDAY;
	this.bVPORQ = bVPORQ;
	this.bVCLAS = bVCLAS;
	this.bVPSTC = bVPSTC;
	this.bVLDAT = bVLDAT;
	this.bVLINA = bVLINA;
	this.bVPDAT = bVPDAT;
	this.bVLPAA = bVLPAA;
	this.bVYTDS = bVYTDS;
	this.bVLYTD = bVLYTD;
	this.bVOUTB = bVOUTB;
	this.bV15 = bV15;
	this.bVDUNN = bVDUNN;
	this.bVFAX = bVFAX;
	this.bVMDAT = bVMDAT;
	this.bVBILL = bVBILL;
	this.bVGSTL = bVGSTL;
	this.bV3 = bV3;
	this.bVLARA = bVLARA;
	this.bVCONT = bVCONT;
	this.bVSUPP = bVSUPP;
	this.bVSFOR = bVSFOR;
	this.bVSFCP = bVSFCP;
	this.bVMFOR = bVMFOR;
	this.bVMFCP = bVMFCP;
	this.bVXFOR = bVXFOR;
	this.bVXFCP = bVXFCP;
	this.bVCARC = bVCARC;
	this.bVSERC = bVSERC;
	this.bVSUPA = bVSUPA;
	this.bVTRDP = bVTRDP;
	this.bVDUNS = bVDUNS;
	this.bVSFID = bVSFID;
	this.bVUSEC = bVUSEC;
	this.bVSHPR = bVSHPR;
	this.bVASNY = bVASNY;
	this.bVINVY = bVINVY;
	this.bVFLG1 = bVFLG1;
	this.bVFLG2 = bVFLG2;
	this.bVFLG3 = bVFLG3;
	this.bVFLG4 = bVFLG4;
	this.bVFLG5 = bVFLG5;
	this.bVFLG6 = bVFLG6;
	this.bVSUMR = bVSUMR;
	this.bVPLNT = bVPLNT;
	this.bVDOCK = bVDOCK;
	this.bVLINE = bVLINE;
	this.bVDROP = bVDROP;
	this.bVTMOD = bVTMOD;
	this.bVTTYP = bVTTYP;
	this.bVEQPI = bVEQPI;
	this.bVROUT = bVROUT;
	this.bVPOOL = bVPOOL;
	this.bVPOLL = bVPOLL;
	this.bVJITF = bVJITF;
	this.bVAPLG = bVAPLG;
	this.bVAVER = bVAVER;
	this.bVUVER = bVUVER;
	this.bVFOBC = bVFOBC;
	this.bVEMAL = bVEMAL;
	this.bVWEB = bVWEB;
	this.bVDDIR = bVDDIR;
	this.bVFL01 = bVFL01;
	this.bVADJC = bVADJC;
	this.bVPPCL = bVPPCL;
	this.bVCDAT = bVCDAT;
	this.bVIBRQ = bVIBRQ;
	this.bVORSM = bVORSM;
	this.bVFL04 = bVFL04;
	this.bVSTAT = bVSTAT;
	this.bVREAS = bVREAS;
	this.bVFL05 = bVFL05;
	this.bVFL06 = bVFL06;
	this.bVFL07 = bVFL07;
	this.bVCSERD = bVCSERD;
	this.bVFL08 = bVFL08;
	this.bVFL09 = bVFL09;
	this.bVFL10 = bVFL10;
	this.bVFL11 = bVFL11;
	this.bVFL12 = bVFL12;
	this.bVFL13 = bVFL13;
	this.bVFL14 = bVFL14;
	this.bVFL15 = bVFL15;
	this.bVFL16 = bVFL16;
	this.bVFL17 = bVFL17;
	this.bVFL18 = bVFL18;
	this.bVFL19 = bVFL19;
	this.bVFL20 = bVFL20;
}

public
void setBVCUST(string bVCUST){
	this.bVCUST = bVCUST;
}

public
void setBVCOMP(decimal bVCOMP){
	this.bVCOMP = bVCOMP;
}

public
void setBVNAME(string bVNAME){
	this.bVNAME = bVNAME;
}

public
void setBVADR1(string bVADR1){
	this.bVADR1 = bVADR1;
}

public
void setBVADR2(string bVADR2){
	this.bVADR2 = bVADR2;
}

public
void setBVADR3(string bVADR3){
	this.bVADR3 = bVADR3;
}

public
void setBVADR4(string bVADR4){
	this.bVADR4 = bVADR4;
}

public
void setBVADR5(string bVADR5){
	this.bVADR5 = bVADR5;
}

public
void setBVADR6(string bVADR6){
	this.bVADR6 = bVADR6;
}

public
void setBVADR7(string bVADR7){
	this.bVADR7 = bVADR7;
}

public
void setBVADR8(string bVADR8){
	this.bVADR8 = bVADR8;
}

public
void setBVADR9(string bVADR9){
	this.bVADR9 = bVADR9;
}

public
void setBVADR10(string bVADR10){
	this.bVADR10 = bVADR10;
}

public
void setBVPOST(string bVPOST){
	this.bVPOST = bVPOST;
}

public
void setBVCITY(string bVCITY){
	this.bVCITY = bVCITY;
}

public
void setBVPROV(string bVPROV){
	this.bVPROV = bVPROV;
}

public
void setBVCTRY(string bVCTRY){
	this.bVCTRY = bVCTRY;
}

public
void setBVTELP(string bVTELP){
	this.bVTELP = bVTELP;
}

public
void setBVBORD(string bVBORD){
	this.bVBORD = bVBORD;
}

public
void setBVPRAR(string bVPRAR){
	this.bVPRAR = bVPRAR;
}

public
void setBVPSTE(string bVPSTE){
	this.bVPSTE = bVPSTE;
}

public
void setBVPRCD(string bVPRCD){
	this.bVPRCD = bVPRCD;
}

public
void setBVPSTL(string bVPSTL){
	this.bVPSTL = bVPSTL;
}

public
void setBVFSTE(string bVFSTE){
	this.bVFSTE = bVFSTE;
}

public
void setBVTXGR(string bVTXGR){
	this.bVTXGR = bVTXGR;
}

public
void setBVTXRT(string bVTXRT){
	this.bVTXRT = bVTXRT;
}

public
void setBVPACK(string bVPACK){
	this.bVPACK = bVPACK;
}

public
void setBVNU10(string bVNU10){
	this.bVNU10 = bVNU10;
}

public
void setBVSALM(string bVSALM){
	this.bVSALM = bVSALM;
}

public
void setBVTERR(string bVTERR){
	this.bVTERR = bVTERR;
}

public
void setBVSNOT(string bVSNOT){
	this.bVSNOT = bVSNOT;
}

public
void setBVCURR(string bVCURR){
	this.bVCURR = bVCURR;
}

public
void setBVSCOM(string bVSCOM){
	this.bVSCOM = bVSCOM;
}

public
void setBVTYPE(string bVTYPE){
	this.bVTYPE = bVTYPE;
}

public
void setBVCRLE(string bVCRLE){
	this.bVCRLE = bVCRLE;
}

public
void setBVGSTE(string bVGSTE){
	this.bVGSTE = bVGSTE;
}

public
void setBVCREL(decimal bVCREL){
	this.bVCREL = bVCREL;
}

public
void setBVOEM(string bVOEM){
	this.bVOEM = bVOEM;
}

public
void setBVLANG(string bVLANG){
	this.bVLANG = bVLANG;
}

public
void setBVSHLT(decimal bVSHLT){
	this.bVSHLT = bVSHLT;
}

public
void setBVINPO(string bVINPO){
	this.bVINPO = bVINPO;
}

public
void setBVTERM(string bVTERM){
	this.bVTERM = bVTERM;
}

public
void setBVSHCL(string bVSHCL){
	this.bVSHCL = bVSHCL;
}

public
void setBV1B(string bV1B){
	this.bV1B = bV1B;
}

public
void setBVDISL(decimal bVDISL){
	this.bVDISL = bVDISL;
}

public
void setBVARCD(string bVARCD){
	this.bVARCD = bVARCD;
}

public
void setBVINT(string bVINT){
	this.bVINT = bVINT;
}

public
void setBVSDAY(decimal bVSDAY){
	this.bVSDAY = bVSDAY;
}

public
void setBVPORQ(string bVPORQ){
	this.bVPORQ = bVPORQ;
}

public
void setBVCLAS(string bVCLAS){
	this.bVCLAS = bVCLAS;
}

public
void setBVPSTC(string bVPSTC){
	this.bVPSTC = bVPSTC;
}

public
void setBVLDAT(DateTime bVLDAT){
	this.bVLDAT = bVLDAT;
}

public
void setBVLINA(decimal bVLINA){
	this.bVLINA = bVLINA;
}

public
void setBVPDAT(DateTime bVPDAT){
	this.bVPDAT = bVPDAT;
}

public
void setBVLPAA(decimal bVLPAA){
	this.bVLPAA = bVLPAA;
}

public
void setBVYTDS(decimal bVYTDS){
	this.bVYTDS = bVYTDS;
}

public
void setBVLYTD(decimal bVLYTD){
	this.bVLYTD = bVLYTD;
}

public
void setBVOUTB(decimal bVOUTB){
	this.bVOUTB = bVOUTB;
}

public
void setBV15(string bV15){
	this.bV15 = bV15;
}

public
void setBVDUNN(string bVDUNN){
	this.bVDUNN = bVDUNN;
}

public
void setBVFAX(string bVFAX){
	this.bVFAX = bVFAX;
}

public
void setBVMDAT(DateTime bVMDAT){
	this.bVMDAT = bVMDAT;
}

public
void setBVBILL(string bVBILL){
	this.bVBILL = bVBILL;
}

public
void setBVGSTL(string bVGSTL){
	this.bVGSTL = bVGSTL;
}

public
void setBV3(string bV3){
	this.bV3 = bV3;
}

public
void setBVLARA(decimal bVLARA){
	this.bVLARA = bVLARA;
}

public
void setBVCONT(string bVCONT){
	this.bVCONT = bVCONT;
}

public
void setBVSUPP(string bVSUPP){
	this.bVSUPP = bVSUPP;
}

public
void setBVSFOR(string bVSFOR){
	this.bVSFOR = bVSFOR;
}

public
void setBVSFCP(decimal bVSFCP){
	this.bVSFCP = bVSFCP;
}

public
void setBVMFOR(string bVMFOR){
	this.bVMFOR = bVMFOR;
}

public
void setBVMFCP(decimal bVMFCP){
	this.bVMFCP = bVMFCP;
}

public
void setBVXFOR(string bVXFOR){
	this.bVXFOR = bVXFOR;
}

public
void setBVXFCP(decimal bVXFCP){
	this.bVXFCP = bVXFCP;
}

public
void setBVCARC(string bVCARC){
	this.bVCARC = bVCARC;
}

public
void setBVSERC(string bVSERC){
	this.bVSERC = bVSERC;
}

public
void setBVSUPA(string bVSUPA){
	this.bVSUPA = bVSUPA;
}

public
void setBVTRDP(string bVTRDP){
	this.bVTRDP = bVTRDP;
}

public
void setBVDUNS(string bVDUNS){
	this.bVDUNS = bVDUNS;
}

public
void setBVSFID(string bVSFID){
	this.bVSFID = bVSFID;
}

public
void setBVUSEC(string bVUSEC){
	this.bVUSEC = bVUSEC;
}

public
void setBVSHPR(string bVSHPR){
	this.bVSHPR = bVSHPR;
}

public
void setBVASNY(string bVASNY){
	this.bVASNY = bVASNY;
}

public
void setBVINVY(string bVINVY){
	this.bVINVY = bVINVY;
}

public
void setBVFLG1(string bVFLG1){
	this.bVFLG1 = bVFLG1;
}

public
void setBVFLG2(string bVFLG2){
	this.bVFLG2 = bVFLG2;
}

public
void setBVFLG3(string bVFLG3){
	this.bVFLG3 = bVFLG3;
}

public
void setBVFLG4(string bVFLG4){
	this.bVFLG4 = bVFLG4;
}

public
void setBVFLG5(string bVFLG5){
	this.bVFLG5 = bVFLG5;
}

public
void setBVFLG6(string bVFLG6){
	this.bVFLG6 = bVFLG6;
}

public
void setBVSUMR(string bVSUMR){
	this.bVSUMR = bVSUMR;
}

public
void setBVPLNT(string bVPLNT){
	this.bVPLNT = bVPLNT;
}

public
void setBVDOCK(string bVDOCK){
	this.bVDOCK = bVDOCK;
}

public
void setBVLINE(string bVLINE){
	this.bVLINE = bVLINE;
}

public
void setBVDROP(string bVDROP){
	this.bVDROP = bVDROP;
}

public
void setBVTMOD(string bVTMOD){
	this.bVTMOD = bVTMOD;
}

public
void setBVTTYP(string bVTTYP){
	this.bVTTYP = bVTTYP;
}

public
void setBVEQPI(string bVEQPI){
	this.bVEQPI = bVEQPI;
}

public
void setBVROUT(string bVROUT){
	this.bVROUT = bVROUT;
}

public
void setBVPOOL(string bVPOOL){
	this.bVPOOL = bVPOOL;
}

public
void setBVPOLL(string bVPOLL){
	this.bVPOLL = bVPOLL;
}

public
void setBVJITF(string bVJITF){
	this.bVJITF = bVJITF;
}

public
void setBVAPLG(string bVAPLG){
	this.bVAPLG = bVAPLG;
}

public
void setBVAVER(string bVAVER){
	this.bVAVER = bVAVER;
}

public
void setBVUVER(string bVUVER){
	this.bVUVER = bVUVER;
}

public
void setBVFOBC(string bVFOBC){
	this.bVFOBC = bVFOBC;
}

public
void setBVEMAL(string bVEMAL){
	this.bVEMAL = bVEMAL;
}

public
void setBVWEB(string bVWEB){
	this.bVWEB = bVWEB;
}

public
void setBVDDIR(string bVDDIR){
	this.bVDDIR = bVDDIR;
}

public
void setBVFL01(string bVFL01){
	this.bVFL01 = bVFL01;
}

public
void setBVADJC(string bVADJC){
	this.bVADJC = bVADJC;
}

public
void setBVPPCL(string bVPPCL){
	this.bVPPCL = bVPPCL;
}

public
void setBVCDAT(DateTime bVCDAT){
	this.bVCDAT = bVCDAT;
}

public
void setBVIBRQ(string bVIBRQ){
	this.bVIBRQ = bVIBRQ;
}

public
void setBVORSM(string bVORSM){
	this.bVORSM = bVORSM;
}

public
void setBVFL04(string bVFL04){
	this.bVFL04 = bVFL04;
}

public
void setBVSTAT(string bVSTAT){
	this.bVSTAT = bVSTAT;
}

public
void setBVREAS(string bVREAS){
	this.bVREAS = bVREAS;
}

public
void setBVFL05(string bVFL05){
	this.bVFL05 = bVFL05;
}

public
void setBVFL06(string bVFL06){
	this.bVFL06 = bVFL06;
}

public
void setBVFL07(string bVFL07){
	this.bVFL07 = bVFL07;
}

public
void setBVCSERD(string bVCSERD){
	this.bVCSERD = bVCSERD;
}

public
void setBVFL08(string bVFL08){
	this.bVFL08 = bVFL08;
}

public
void setBVFL09(string bVFL09){
	this.bVFL09 = bVFL09;
}

public
void setBVFL10(string bVFL10){
	this.bVFL10 = bVFL10;
}

public
void setBVFL11(string bVFL11){
	this.bVFL11 = bVFL11;
}

public
void setBVFL12(string bVFL12){
	this.bVFL12 = bVFL12;
}

public
void setBVFL13(DateTime bVFL13){
	this.bVFL13 = bVFL13;
}

public
void setBVFL14(DateTime bVFL14){
	this.bVFL14 = bVFL14;
}

public
void setBVFL15(decimal bVFL15){
	this.bVFL15 = bVFL15;
}

public
void setBVFL16(decimal bVFL16){
	this.bVFL16 = bVFL16;
}

public
void setBVFL17(string bVFL17){
	this.bVFL17 = bVFL17;
}

public
void setBVFL18(string bVFL18){
	this.bVFL18 = bVFL18;
}

public
void setBVFL19(string bVFL19){
	this.bVFL19 = bVFL19;
}

public
void setBVFL20(string bVFL20){
	this.bVFL20 = bVFL20;
}

public
string getBVCUST(){
	 return bVCUST;
}

public
decimal getBVCOMP(){
	 return bVCOMP;
}

public
string getBVNAME(){
	 return bVNAME;
}

public
string getBVADR1(){
	 return bVADR1;
}

public
string getBVADR2(){
	 return bVADR2;
}

public
string getBVADR3(){
	 return bVADR3;
}

public
string getBVADR4(){
	 return bVADR4;
}

public
string getBVADR5(){
	 return bVADR5;
}

public
string getBVADR6(){
	 return bVADR6;
}

public
string getBVADR7(){
	 return bVADR7;
}

public
string getBVADR8(){
	 return bVADR8;
}

public
string getBVADR9(){
	 return bVADR9;
}

public
string getBVADR10(){
	 return bVADR10;
}

public
string getBVPOST(){
	 return bVPOST;
}

public
string getBVCITY(){
	 return bVCITY;
}

public
string getBVPROV(){
	 return bVPROV;
}

public
string getBVCTRY(){
	 return bVCTRY;
}

public
string getBVTELP(){
	 return bVTELP;
}

public
string getBVBORD(){
	 return bVBORD;
}

public
string getBVPRAR(){
	 return bVPRAR;
}

public
string getBVPSTE(){
	 return bVPSTE;
}

public
string getBVPRCD(){
	 return bVPRCD;
}

public
string getBVPSTL(){
	 return bVPSTL;
}

public
string getBVFSTE(){
	 return bVFSTE;
}

public
string getBVTXGR(){
	 return bVTXGR;
}

public
string getBVTXRT(){
	 return bVTXRT;
}

public
string getBVPACK(){
	 return bVPACK;
}

public
string getBVNU10(){
	 return bVNU10;
}

public
string getBVSALM(){
	 return bVSALM;
}

public
string getBVTERR(){
	 return bVTERR;
}

public
string getBVSNOT(){
	 return bVSNOT;
}

public
string getBVCURR(){
	 return bVCURR;
}

public
string getBVSCOM(){
	 return bVSCOM;
}

public
string getBVTYPE(){
	 return bVTYPE;
}

public
string getBVCRLE(){
	 return bVCRLE;
}

public
string getBVGSTE(){
	 return bVGSTE;
}

public
decimal getBVCREL(){
	 return bVCREL;
}

public
string getBVOEM(){
	 return bVOEM;
}

public
string getBVLANG(){
	 return bVLANG;
}

public
decimal getBVSHLT(){
	 return bVSHLT;
}

public
string getBVINPO(){
	 return bVINPO;
}

public
string getBVTERM(){
	 return bVTERM;
}

public
string getBVSHCL(){
	 return bVSHCL;
}

public
string getBV1B(){
	 return bV1B;
}

public
decimal getBVDISL(){
	 return bVDISL;
}

public
string getBVARCD(){
	 return bVARCD;
}

public
string getBVINT(){
	 return bVINT;
}

public
decimal getBVSDAY(){
	 return bVSDAY;
}

public
string getBVPORQ(){
	 return bVPORQ;
}

public
string getBVCLAS(){
	 return bVCLAS;
}

public
string getBVPSTC(){
	 return bVPSTC;
}

public
DateTime getBVLDAT(){
	 return bVLDAT;
}

public
decimal getBVLINA(){
	 return bVLINA;
}

public
DateTime getBVPDAT(){
	 return bVPDAT;
}

public
decimal getBVLPAA(){
	 return bVLPAA;
}

public
decimal getBVYTDS(){
	 return bVYTDS;
}

public
decimal getBVLYTD(){
	 return bVLYTD;
}

public
decimal getBVOUTB(){
	 return bVOUTB;
}

public
string getBV15(){
	 return bV15;
}

public
string getBVDUNN(){
	 return bVDUNN;
}

public
string getBVFAX(){
	 return bVFAX;
}

public
DateTime getBVMDAT(){
	 return bVMDAT;
}

public
string getBVBILL(){
	 return bVBILL;
}

public
string getBVGSTL(){
	 return bVGSTL;
}

public
string getBV3(){
	 return bV3;
}

public
decimal getBVLARA(){
	 return bVLARA;
}

public
string getBVCONT(){
	 return bVCONT;
}

public
string getBVSUPP(){
	 return bVSUPP;
}

public
string getBVSFOR(){
	 return bVSFOR;
}

public
decimal getBVSFCP(){
	 return bVSFCP;
}

public
string getBVMFOR(){
	 return bVMFOR;
}

public
decimal getBVMFCP(){
	 return bVMFCP;
}

public
string getBVXFOR(){
	 return bVXFOR;
}

public
decimal getBVXFCP(){
	 return bVXFCP;
}

public
string getBVCARC(){
	 return bVCARC;
}

public
string getBVSERC(){
	 return bVSERC;
}

public
string getBVSUPA(){
	 return bVSUPA;
}

public
string getBVTRDP(){
	 return bVTRDP;
}

public
string getBVDUNS(){
	 return bVDUNS;
}

public
string getBVSFID(){
	 return bVSFID;
}

public
string getBVUSEC(){
	 return bVUSEC;
}

public
string getBVSHPR(){
	 return bVSHPR;
}

public
string getBVASNY(){
	 return bVASNY;
}

public
string getBVINVY(){
	 return bVINVY;
}

public
string getBVFLG1(){
	 return bVFLG1;
}

public
string getBVFLG2(){
	 return bVFLG2;
}

public
string getBVFLG3(){
	 return bVFLG3;
}

public
string getBVFLG4(){
	 return bVFLG4;
}

public
string getBVFLG5(){
	 return bVFLG5;
}

public
string getBVFLG6(){
	 return bVFLG6;
}

public
string getBVSUMR(){
	 return bVSUMR;
}

public
string getBVPLNT(){
	 return bVPLNT;
}

public
string getBVDOCK(){
	 return bVDOCK;
}

public
string getBVLINE(){
	 return bVLINE;
}

public
string getBVDROP(){
	 return bVDROP;
}

public
string getBVTMOD(){
	 return bVTMOD;
}

public
string getBVTTYP(){
	 return bVTTYP;
}

public
string getBVEQPI(){
	 return bVEQPI;
}

public
string getBVROUT(){
	 return bVROUT;
}

public
string getBVPOOL(){
	 return bVPOOL;
}

public
string getBVPOLL(){
	 return bVPOLL;
}

public
string getBVJITF(){
	 return bVJITF;
}

public
string getBVAPLG(){
	 return bVAPLG;
}

public
string getBVAVER(){
	 return bVAVER;
}

public
string getBVUVER(){
	 return bVUVER;
}

public
string getBVFOBC(){
	 return bVFOBC;
}

public
string getBVEMAL(){
	 return bVEMAL;
}

public
string getBVWEB(){
	 return bVWEB;
}

public
string getBVDDIR(){
	 return bVDDIR;
}

public
string getBVFL01(){
	 return bVFL01;
}

public
string getBVADJC(){
	 return bVADJC;
}

public
string getBVPPCL(){
	 return bVPPCL;
}

public
DateTime getBVCDAT(){
	 return bVCDAT;
}

public
string getBVIBRQ(){
	 return bVIBRQ;
}

public
string getBVORSM(){
	 return bVORSM;
}

public
string getBVFL04(){
	 return bVFL04;
}

public
string getBVSTAT(){
	 return bVSTAT;
}

public
string getBVREAS(){
	 return bVREAS;
}

public
string getBVFL05(){
	 return bVFL05;
}

public
string getBVFL06(){
	 return bVFL06;
}

public
string getBVFL07(){
	 return bVFL07;
}

public
string getBVCSERD(){
	 return bVCSERD;
}

public
string getBVFL08(){
	 return bVFL08;
}

public
string getBVFL09(){
	 return bVFL09;
}

public
string getBVFL10(){
	 return bVFL10;
}

public
string getBVFL11(){
	 return bVFL11;
}

public
string getBVFL12(){
	 return bVFL12;
}

public
DateTime getBVFL13(){
	 return bVFL13;
}

public
DateTime getBVFL14(){
	 return bVFL14;
}

public
decimal getBVFL15(){
	 return bVFL15;
}

public
decimal getBVFL16(){
	 return bVFL16;
}

public
string getBVFL17(){
	 return bVFL17;
}

public
string getBVFL18(){
	 return bVFL18;
}

public
string getBVFL19(){
	 return bVFL19;
}

public
string getBVFL20(){
	 return bVFL20;
}

public override
bool Equals(object obj){
	if (obj is CustomerEdi)
		return	this.bVCUST.Equals(((CustomerEdi)obj).getBVCUST());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

#region Properties

[System.Runtime.Serialization.DataMember]
public
string BVCUST
{
    get { return this.bVCUST; }
    set
    {
        if (this.bVCUST != value)
        {
            this.bVCUST = value;
            Notify("BVCUST");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVCOMP
{
    get { return this.bVCOMP; }
    set
    {
        if (this.bVCOMP != value)
        {
            this.bVCOMP = value;
            Notify("BVCOMP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVNAME
{
    get { return this.bVNAME; }
    set
    {
        if (this.bVNAME != value)
        {
            this.bVNAME = value;
            Notify("BVNAME");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR1
{
    get { return this.bVADR1; }
    set
    {
        if (this.bVADR1 != value)
        {
            this.bVADR1 = value;
            Notify("BVADR1");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR2
{
    get { return this.bVADR2; }
    set
    {
        if (this.bVADR2 != value)
        {
            this.bVADR2 = value;
            Notify("BVADR2");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR3
{
    get { return this.bVADR3; }
    set
    {
        if (this.bVADR3 != value)
        {
            this.bVADR3 = value;
            Notify("BVADR3");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR4
{
    get { return this.bVADR4; }
    set
    {
        if (this.bVADR4 != value)
        {
            this.bVADR4 = value;
            Notify("BVADR4");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR5
{
    get { return this.bVADR5; }
    set
    {
        if (this.bVADR5 != value)
        {
            this.bVADR5 = value;
            Notify("BVADR5");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR6
{
    get { return this.bVADR6; }
    set
    {
        if (this.bVADR6 != value)
        {
            this.bVADR6 = value;
            Notify("BVADR6");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR7
{
    get { return this.bVADR7; }
    set
    {
        if (this.bVADR7 != value)
        {
            this.bVADR7 = value;
            Notify("BVADR7");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR8
{
    get { return this.bVADR8; }
    set
    {
        if (this.bVADR8 != value)
        {
            this.bVADR8 = value;
            Notify("BVADR8");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR9
{
    get { return this.bVADR9; }
    set
    {
        if (this.bVADR9 != value)
        {
            this.bVADR9 = value;
            Notify("BVADR9");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADR10
{
    get { return this.bVADR10; }
    set
    {
        if (this.bVADR10 != value)
        {
            this.bVADR10 = value;
            Notify("BVADR10");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPOST
{
    get { return this.bVPOST; }
    set
    {
        if (this.bVPOST != value)
        {
            this.bVPOST = value;
            Notify("BVPOST");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCITY
{
    get { return this.bVCITY; }
    set
    {
        if (this.bVCITY != value)
        {
            this.bVCITY = value;
            Notify("BVCITY");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPROV
{
    get { return this.bVPROV; }
    set
    {
        if (this.bVPROV != value)
        {
            this.bVPROV = value;
            Notify("BVPROV");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCTRY
{
    get { return this.bVCTRY; }
    set
    {
        if (this.bVCTRY != value)
        {
            this.bVCTRY = value;
            Notify("BVCTRY");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTELP
{
    get { return this.bVTELP; }
    set
    {
        if (this.bVTELP != value)
        {
            this.bVTELP = value;
            Notify("BVTELP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVBORD
{
    get { return this.bVBORD; }
    set
    {
        if (this.bVBORD != value)
        {
            this.bVBORD = value;
            Notify("BVBORD");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPRAR
{
    get { return this.bVPRAR; }
    set
    {
        if (this.bVPRAR != value)
        {
            this.bVPRAR = value;
            Notify("BVPRAR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPSTE
{
    get { return this.bVPSTE; }
    set
    {
        if (this.bVPSTE != value)
        {
            this.bVPSTE = value;
            Notify("BVPSTE");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPRCD
{
    get { return this.bVPRCD; }
    set
    {
        if (this.bVPRCD != value)
        {
            this.bVPRCD = value;
            Notify("BVPRCD");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPSTL
{
    get { return this.bVPSTL; }
    set
    {
        if (this.bVPSTL != value)
        {
            this.bVPSTL = value;
            Notify("BVPSTL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFSTE
{
    get { return this.bVFSTE; }
    set
    {
        if (this.bVFSTE != value)
        {
            this.bVFSTE = value;
            Notify("BVFSTE");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTXGR
{
    get { return this.bVTXGR; }
    set
    {
        if (this.bVTXGR != value)
        {
            this.bVTXGR = value;
            Notify("BVTXGR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTXRT
{
    get { return this.bVTXRT; }
    set
    {
        if (this.bVTXRT != value)
        {
            this.bVTXRT = value;
            Notify("BVTXRT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPACK
{
    get { return this.bVPACK; }
    set
    {
        if (this.bVPACK != value)
        {
            this.bVPACK = value;
            Notify("BVPACK");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVNU10
{
    get { return this.bVNU10; }
    set
    {
        if (this.bVNU10 != value)
        {
            this.bVNU10 = value;
            Notify("BVNU10");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSALM
{
    get { return this.bVSALM; }
    set
    {
        if (this.bVSALM != value)
        {
            this.bVSALM = value;
            Notify("BVSALM");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTERR
{
    get { return this.bVTERR; }
    set
    {
        if (this.bVTERR != value)
        {
            this.bVTERR = value;
            Notify("BVTERR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSNOT
{
    get { return this.bVSNOT; }
    set
    {
        if (this.bVSNOT != value)
        {
            this.bVSNOT = value;
            Notify("BVSNOT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCURR
{
    get { return this.bVCURR; }
    set
    {
        if (this.bVCURR != value)
        {
            this.bVCURR = value;
            Notify("BVCURR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSCOM
{
    get { return this.bVSCOM; }
    set
    {
        if (this.bVSCOM != value)
        {
            this.bVSCOM = value;
            Notify("BVSCOM");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTYPE
{
    get { return this.bVTYPE; }
    set
    {
        if (this.bVTYPE != value)
        {
            this.bVTYPE = value;
            Notify("BVTYPE");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCRLE
{
    get { return this.bVCRLE; }
    set
    {
        if (this.bVCRLE != value)
        {
            this.bVCRLE = value;
            Notify("BVCRLE");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVGSTE
{
    get { return this.bVGSTE; }
    set
    {
        if (this.bVGSTE != value)
        {
            this.bVGSTE = value;
            Notify("BVGSTE");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVCREL
{
    get { return this.bVCREL; }
    set
    {
        if (this.bVCREL != value)
        {
            this.bVCREL = value;
            Notify("BVCREL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVOEM
{
    get { return this.bVOEM; }
    set
    {
        if (this.bVOEM != value)
        {
            this.bVOEM = value;
            Notify("BVOEM");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVLANG
{
    get { return this.bVLANG; }
    set
    {
        if (this.bVLANG != value)
        {
            this.bVLANG = value;
            Notify("BVLANG");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVSHLT
{
    get { return this.bVSHLT; }
    set
    {
        if (this.bVSHLT != value)
        {
            this.bVSHLT = value;
            Notify("BVSHLT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVINPO
{
    get { return this.bVINPO; }
    set
    {
        if (this.bVINPO != value)
        {
            this.bVINPO = value;
            Notify("BVINPO");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTERM
{
    get { return this.bVTERM; }
    set
    {
        if (this.bVTERM != value)
        {
            this.bVTERM = value;
            Notify("BVTERM");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSHCL
{
    get { return this.bVSHCL; }
    set
    {
        if (this.bVSHCL != value)
        {
            this.bVSHCL = value;
            Notify("BVSHCL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BV1B
{
    get { return this.bV1B; }
    set
    {
        if (this.bV1B != value)
        {
            this.bV1B = value;
            Notify("BV1B");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVDISL
{
    get { return this.bVDISL; }
    set
    {
        if (this.bVDISL != value)
        {
            this.bVDISL = value;
            Notify("BVDISL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVARCD
{
    get { return this.bVARCD; }
    set
    {
        if (this.bVARCD != value)
        {
            this.bVARCD = value;
            Notify("BVARCD");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVINT
{
    get { return this.bVINT; }
    set
    {
        if (this.bVINT != value)
        {
            this.bVINT = value;
            Notify("BVINT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVSDAY
{
    get { return this.bVSDAY; }
    set
    {
        if (this.bVSDAY != value)
        {
            this.bVSDAY = value;
            Notify("BVSDAY");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPORQ
{
    get { return this.bVPORQ; }
    set
    {
        if (this.bVPORQ != value)
        {
            this.bVPORQ = value;
            Notify("BVPORQ");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCLAS
{
    get { return this.bVCLAS; }
    set
    {
        if (this.bVCLAS != value)
        {
            this.bVCLAS = value;
            Notify("BVCLAS");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPSTC
{
    get { return this.bVPSTC; }
    set
    {
        if (this.bVPSTC != value)
        {
            this.bVPSTC = value;
            Notify("BVPSTC");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime BVLDAT
{
    get { return this.bVLDAT; }
    set
    {
        if (this.bVLDAT != value)
        {
            this.bVLDAT = value;
            Notify("BVLDAT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVLINA
{
    get { return this.bVLINA; }
    set
    {
        if (this.bVLINA != value)
        {
            this.bVLINA = value;
            Notify("BVLINA");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime BVPDAT
{
    get { return this.bVPDAT; }
    set
    {
        if (this.bVPDAT != value)
        {
            this.bVPDAT = value;
            Notify("BVPDAT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVLPAA
{
    get { return this.bVLPAA; }
    set
    {
        if (this.bVLPAA != value)
        {
            this.bVLPAA = value;
            Notify("BVLPAA");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVYTDS
{
    get { return this.bVYTDS; }
    set
    {
        if (this.bVYTDS != value)
        {
            this.bVYTDS = value;
            Notify("BVYTDS");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVLYTD
{
    get { return this.bVLYTD; }
    set
    {
        if (this.bVLYTD != value)
        {
            this.bVLYTD = value;
            Notify("BVLYTD");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVOUTB
{
    get { return this.bVOUTB; }
    set
    {
        if (this.bVOUTB != value)
        {
            this.bVOUTB = value;
            Notify("BVOUTB");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BV15
{
    get { return this.bV15; }
    set
    {
        if (this.bV15 != value)
        {
            this.bV15 = value;
            Notify("BV15");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVDUNN
{
    get { return this.bVDUNN; }
    set
    {
        if (this.bVDUNN != value)
        {
            this.bVDUNN = value;
            Notify("BVDUNN");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFAX
{
    get { return this.bVFAX; }
    set
    {
        if (this.bVFAX != value)
        {
            this.bVFAX = value;
            Notify("BVFAX");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime BVMDAT
{
    get { return this.bVMDAT; }
    set
    {
        if (this.bVMDAT != value)
        {
            this.bVMDAT = value;
            Notify("BVMDAT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVBILL
{
    get { return this.bVBILL; }
    set
    {
        if (this.bVBILL != value)
        {
            this.bVBILL = value;
            Notify("BVBILL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVGSTL
{
    get { return this.bVGSTL; }
    set
    {
        if (this.bVGSTL != value)
        {
            this.bVGSTL = value;
            Notify("BVGSTL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BV3
{
    get { return this.bV3; }
    set
    {
        if (this.bV3 != value)
        {
            this.bV3 = value;
            Notify("BV3");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVLARA
{
    get { return this.bVLARA; }
    set
    {
        if (this.bVLARA != value)
        {
            this.bVLARA = value;
            Notify("BVLARA");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCONT
{
    get { return this.bVCONT; }
    set
    {
        if (this.bVCONT != value)
        {
            this.bVCONT = value;
            Notify("BVCONT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSUPP
{
    get { return this.bVSUPP; }
    set
    {
        if (this.bVSUPP != value)
        {
            this.bVSUPP = value;
            Notify("BVSUPP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSFOR
{
    get { return this.bVSFOR; }
    set
    {
        if (this.bVSFOR != value)
        {
            this.bVSFOR = value;
            Notify("BVSFOR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVSFCP
{
    get { return this.bVSFCP; }
    set
    {
        if (this.bVSFCP != value)
        {
            this.bVSFCP = value;
            Notify("BVSFCP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVMFOR
{
    get { return this.bVMFOR; }
    set
    {
        if (this.bVMFOR != value)
        {
            this.bVMFOR = value;
            Notify("BVMFOR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVMFCP
{
    get { return this.bVMFCP; }
    set
    {
        if (this.bVMFCP != value)
        {
            this.bVMFCP = value;
            Notify("BVMFCP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVXFOR
{
    get { return this.bVXFOR; }
    set
    {
        if (this.bVXFOR != value)
        {
            this.bVXFOR = value;
            Notify("BVXFOR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVXFCP
{
    get { return this.bVXFCP; }
    set
    {
        if (this.bVXFCP != value)
        {
            this.bVXFCP = value;
            Notify("BVXFCP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCARC
{
    get { return this.bVCARC; }
    set
    {
        if (this.bVCARC != value)
        {
            this.bVCARC = value;
            Notify("BVCARC");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSERC
{
    get { return this.bVSERC; }
    set
    {
        if (this.bVSERC != value)
        {
            this.bVSERC = value;
            Notify("BVSERC");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSUPA
{
    get { return this.bVSUPA; }
    set
    {
        if (this.bVSUPA != value)
        {
            this.bVSUPA = value;
            Notify("BVSUPA");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTRDP
{
    get { return this.bVTRDP; }
    set
    {
        if (this.bVTRDP != value)
        {
            this.bVTRDP = value;
            Notify("BVTRDP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVDUNS
{
    get { return this.bVDUNS; }
    set
    {
        if (this.bVDUNS != value)
        {
            this.bVDUNS = value;
            Notify("BVDUNS");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSFID
{
    get { return this.bVSFID; }
    set
    {
        if (this.bVSFID != value)
        {
            this.bVSFID = value;
            Notify("BVSFID");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVUSEC
{
    get { return this.bVUSEC; }
    set
    {
        if (this.bVUSEC != value)
        {
            this.bVUSEC = value;
            Notify("BVUSEC");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSHPR
{
    get { return this.bVSHPR; }
    set
    {
        if (this.bVSHPR != value)
        {
            this.bVSHPR = value;
            Notify("BVSHPR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVASNY
{
    get { return this.bVASNY; }
    set
    {
        if (this.bVASNY != value)
        {
            this.bVASNY = value;
            Notify("BVASNY");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVINVY
{
    get { return this.bVINVY; }
    set
    {
        if (this.bVINVY != value)
        {
            this.bVINVY = value;
            Notify("BVINVY");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFLG1
{
    get { return this.bVFLG1; }
    set
    {
        if (this.bVFLG1 != value)
        {
            this.bVFLG1 = value;
            Notify("BVFLG1");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFLG2
{
    get { return this.bVFLG2; }
    set
    {
        if (this.bVFLG2 != value)
        {
            this.bVFLG2 = value;
            Notify("BVFLG2");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFLG3
{
    get { return this.bVFLG3; }
    set
    {
        if (this.bVFLG3 != value)
        {
            this.bVFLG3 = value;
            Notify("BVFLG3");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFLG4
{
    get { return this.bVFLG4; }
    set
    {
        if (this.bVFLG4 != value)
        {
            this.bVFLG4 = value;
            Notify("BVFLG4");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFLG5
{
    get { return this.bVFLG5; }
    set
    {
        if (this.bVFLG5 != value)
        {
            this.bVFLG5 = value;
            Notify("BVFLG5");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFLG6
{
    get { return this.bVFLG6; }
    set
    {
        if (this.bVFLG6 != value)
        {
            this.bVFLG6 = value;
            Notify("BVFLG6");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSUMR
{
    get { return this.bVSUMR; }
    set
    {
        if (this.bVSUMR != value)
        {
            this.bVSUMR = value;
            Notify("BVSUMR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPLNT
{
    get { return this.bVPLNT; }
    set
    {
        if (this.bVPLNT != value)
        {
            this.bVPLNT = value;
            Notify("BVPLNT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVDOCK
{
    get { return this.bVDOCK; }
    set
    {
        if (this.bVDOCK != value)
        {
            this.bVDOCK = value;
            Notify("BVDOCK");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVLINE
{
    get { return this.bVLINE; }
    set
    {
        if (this.bVLINE != value)
        {
            this.bVLINE = value;
            Notify("BVLINE");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVDROP
{
    get { return this.bVDROP; }
    set
    {
        if (this.bVDROP != value)
        {
            this.bVDROP = value;
            Notify("BVDROP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTMOD
{
    get { return this.bVTMOD; }
    set
    {
        if (this.bVTMOD != value)
        {
            this.bVTMOD = value;
            Notify("BVTMOD");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVTTYP
{
    get { return this.bVTTYP; }
    set
    {
        if (this.bVTTYP != value)
        {
            this.bVTTYP = value;
            Notify("BVTTYP");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVEQPI
{
    get { return this.bVEQPI; }
    set
    {
        if (this.bVEQPI != value)
        {
            this.bVEQPI = value;
            Notify("BVEQPI");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVROUT
{
    get { return this.bVROUT; }
    set
    {
        if (this.bVROUT != value)
        {
            this.bVROUT = value;
            Notify("BVROUT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPOOL
{
    get { return this.bVPOOL; }
    set
    {
        if (this.bVPOOL != value)
        {
            this.bVPOOL = value;
            Notify("BVPOOL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPOLL
{
    get { return this.bVPOLL; }
    set
    {
        if (this.bVPOLL != value)
        {
            this.bVPOLL = value;
            Notify("BVPOLL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVJITF
{
    get { return this.bVJITF; }
    set
    {
        if (this.bVJITF != value)
        {
            this.bVJITF = value;
            Notify("BVJITF");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVAPLG
{
    get { return this.bVAPLG; }
    set
    {
        if (this.bVAPLG != value)
        {
            this.bVAPLG = value;
            Notify("BVAPLG");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVAVER
{
    get { return this.bVAVER; }
    set
    {
        if (this.bVAVER != value)
        {
            this.bVAVER = value;
            Notify("BVAVER");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVUVER
{
    get { return this.bVUVER; }
    set
    {
        if (this.bVUVER != value)
        {
            this.bVUVER = value;
            Notify("BVUVER");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFOBC
{
    get { return this.bVFOBC; }
    set
    {
        if (this.bVFOBC != value)
        {
            this.bVFOBC = value;
            Notify("BVFOBC");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVEMAL
{
    get { return this.bVEMAL; }
    set
    {
        if (this.bVEMAL != value)
        {
            this.bVEMAL = value;
            Notify("BVEMAL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVWEB
{
    get { return this.bVWEB; }
    set
    {
        if (this.bVWEB != value)
        {
            this.bVWEB = value;
            Notify("BVWEB");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVDDIR
{
    get { return this.bVDDIR; }
    set
    {
        if (this.bVDDIR != value)
        {
            this.bVDDIR = value;
            Notify("BVDDIR");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL01
{
    get { return this.bVFL01; }
    set
    {
        if (this.bVFL01 != value)
        {
            this.bVFL01 = value;
            Notify("BVFL01");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVADJC
{
    get { return this.bVADJC; }
    set
    {
        if (this.bVADJC != value)
        {
            this.bVADJC = value;
            Notify("BVADJC");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVPPCL
{
    get { return this.bVPPCL; }
    set
    {
        if (this.bVPPCL != value)
        {
            this.bVPPCL = value;
            Notify("BVPPCL");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime BVCDAT
{
    get { return this.bVCDAT; }
    set
    {
        if (this.bVCDAT != value)
        {
            this.bVCDAT = value;
            Notify("BVCDAT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVIBRQ
{
    get { return this.bVIBRQ; }
    set
    {
        if (this.bVIBRQ != value)
        {
            this.bVIBRQ = value;
            Notify("BVIBRQ");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVORSM
{
    get { return this.bVORSM; }
    set
    {
        if (this.bVORSM != value)
        {
            this.bVORSM = value;
            Notify("BVORSM");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL04
{
    get { return this.bVFL04; }
    set
    {
        if (this.bVFL04 != value)
        {
            this.bVFL04 = value;
            Notify("BVFL04");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVSTAT
{
    get { return this.bVSTAT; }
    set
    {
        if (this.bVSTAT != value)
        {
            this.bVSTAT = value;
            Notify("BVSTAT");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVREAS
{
    get { return this.bVREAS; }
    set
    {
        if (this.bVREAS != value)
        {
            this.bVREAS = value;
            Notify("BVREAS");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL05
{
    get { return this.bVFL05; }
    set
    {
        if (this.bVFL05 != value)
        {
            this.bVFL05 = value;
            Notify("BVFL05");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL06
{
    get { return this.bVFL06; }
    set
    {
        if (this.bVFL06 != value)
        {
            this.bVFL06 = value;
            Notify("BVFL06");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL07
{
    get { return this.bVFL07; }
    set
    {
        if (this.bVFL07 != value)
        {
            this.bVFL07 = value;
            Notify("BVFL07");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVCSERD
{
    get { return this.bVCSERD; }
    set
    {
        if (this.bVCSERD != value)
        {
            this.bVCSERD = value;
            Notify("BVCSERD");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL08
{
    get { return this.bVFL08; }
    set
    {
        if (this.bVFL08 != value)
        {
            this.bVFL08 = value;
            Notify("BVFL08");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL09
{
    get { return this.bVFL09; }
    set
    {
        if (this.bVFL09 != value)
        {
            this.bVFL09 = value;
            Notify("BVFL09");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL10
{
    get { return this.bVFL10; }
    set
    {
        if (this.bVFL10 != value)
        {
            this.bVFL10 = value;
            Notify("BVFL10");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL11
{
    get { return this.bVFL11; }
    set
    {
        if (this.bVFL11 != value)
        {
            this.bVFL11 = value;
            Notify("BVFL11");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL12
{
    get { return this.bVFL12; }
    set
    {
        if (this.bVFL12 != value)
        {
            this.bVFL12 = value;
            Notify("BVFL12");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime BVFL13
{
    get { return this.bVFL13; }
    set
    {
        if (this.bVFL13 != value)
        {
            this.bVFL13 = value;
            Notify("BVFL13");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime BVFL14
{
    get { return this.bVFL14; }
    set
    {
        if (this.bVFL14 != value)
        {
            this.bVFL14 = value;
            Notify("BVFL14");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVFL15
{
    get { return this.bVFL15; }
    set
    {
        if (this.bVFL15 != value)
        {
            this.bVFL15 = value;
            Notify("BVFL15");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
decimal BVFL16
{
    get { return this.bVFL16; }
    set
    {
        if (this.bVFL16 != value)
        {
            this.bVFL16 = value;
            Notify("BVFL16");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL17
{
    get { return this.bVFL17; }
    set
    {
        if (this.bVFL17 != value)
        {
            this.bVFL17 = value;
            Notify("BVFL17");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL18
{
    get { return this.bVFL18; }
    set
    {
        if (this.bVFL18 != value)
        {
            this.bVFL18 = value;
            Notify("BVFL18");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL19
{
    get { return this.bVFL19; }
    set
    {
        if (this.bVFL19 != value)
        {
            this.bVFL19 = value;
            Notify("BVFL19");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string BVFL20
{
    get { return this.bVFL20; }
    set
    {
        if (this.bVFL20 != value)
        {
            this.bVFL20 = value;
            Notify("BVFL20");
        }
    }
}

#endregion Properties

} // class

} // package
