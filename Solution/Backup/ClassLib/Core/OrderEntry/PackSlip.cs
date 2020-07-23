/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/OrderEntry/PackSlip.cs,v $ 
*   $State: Exp $ 
*   $Log: PackSlip.cs,v $
*   Revision 1.3  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/04/06 22:20:20  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/04/05 20:25:06  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/03/29 04:06:22  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/23 20:01:04  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class PackSlip : MarshalByRefObject{

private int iD;
private string db;
private int company;
private string plant;
private int packSlipNum;
private string packSlipType;
private DateTime dateCrt;
private string printInd;
private string shipInd;
private string billToCust;
private string shipToCust;
private string billToName;
private string shipToName;
private string billToPost;
private string attention;
private DateTime shipDate;
private string shipVia;
private int orderNum;
private string stkLoc;
private DateTime shipTime;
private string shipmentID;
private string tradingPartner;
private int mBOL;
private string packSlip2;
private string proNumber;
private string status;
private string bTAdd1;
private string bTAdd2;
private string bTAdd3;
private string bTAdd4;
private string bTProvState;
private string bTCountry;
private string bTPostZip;
private string bTContact;
private string sTAdd1;
private string sTAdd2;
private string sTAdd3;
private string sTAdd4;
private string sTProvState;
private string sTCountry;
private string sTPostZip;
private string sTContact;
private string sFAdd1;
private string sFAdd2;
private string sFAdd3;
private string sFAdd4;
private string sFProvState;
private string sFCountry;
private string sFPostZip;
private string sFContact;


internal
PackSlip(){
	this.iD = 0;
	this.db = "";
	this.company = 0;
	this.plant = "";
	this.packSlipNum = 0;
	this.packSlipType = "";
	this.dateCrt = DateUtil.MinValue;
	this.printInd = "";
	this.shipInd = "";
	this.billToCust = "";
	this.shipToCust = "";
	this.billToName = "";
	this.shipToName = "";
	this.billToPost = "";
	this.attention = "";
	this.shipDate = DateUtil.MinValue;
	this.shipVia = "";
	this.orderNum = 0;
	this.stkLoc = "";
	this.shipTime = DateUtil.MinValue;
	this.shipmentID = "";
	this.tradingPartner = "";
	this.mBOL = 0;
	this.packSlip2 = "";
	this.proNumber = "";
	this.status = "";
	this.bTAdd1 = "";
	this.bTAdd2 = "";
	this.bTAdd3 = "";
	this.bTAdd4 = "";
	this.bTProvState = "";
	this.bTCountry = "";
	this.bTPostZip = "";
	this.bTContact = "";
	this.sTAdd1 = "";
	this.sTAdd2 = "";
	this.sTAdd3 = "";
	this.sTAdd4 = "";
	this.sTProvState = "";
	this.sTCountry = "";
	this.sTPostZip = "";
	this.sTContact = "";
	this.sFAdd1 = "";
	this.sFAdd2 = "";
	this.sFAdd3 = "";
	this.sFAdd4 = "";
	this.sFProvState = "";
	this.sFCountry = "";
	this.sFPostZip = "";
	this.sFContact = "";
}

internal
PackSlip(
				int iD,
				string db,
				int company,
				string plant,
				int packSlipNum,
				string packSlipType,
				DateTime dateCrt,
				string printInd,
				string shipInd,
				string billToCust,
				string shipToCust,
				string billToName,
				string shipToName,
				string billToPost,
				string attention,
				DateTime shipDate,
				string shipVia,
				int orderNum,
				string stkLoc,
				DateTime shipTime,
				string shipmentID,
				string tradingPartner,
				int mBOL,
				string packSlip2,
				string proNumber,
				string status,
				string bTAdd1,
				string bTAdd2,
				string bTAdd3,
				string bTAdd4,
				string bTProvState,
				string bTCountry,
				string bTPostZip,
				string bTContact,
				string sTAdd1,
				string sTAdd2,
				string sTAdd3,
				string sTAdd4,
				string sTProvState,
				string sTCountry,
				string sTPostZip,
				string sTContact,
				string sFAdd1,
				string sFAdd2,
				string sFAdd3,
				string sFAdd4,
				string sFProvState,
				string sFCountry,
				string sFPostZip,
				string sFContact)
{
	this.iD = iD;
	this.db = db;
	this.company = company;
	this.plant = plant;
	this.packSlipNum = packSlipNum;
	this.packSlipType = packSlipType;
	this.dateCrt = dateCrt;
	this.printInd = printInd;
	this.shipInd = shipInd;
	this.billToCust = billToCust;
	this.shipToCust = shipToCust;
	this.billToName = billToName;
	this.shipToName = shipToName;
	this.billToPost = billToPost;
	this.attention = attention;
	this.shipDate = shipDate;
	this.shipVia = shipVia;
	this.orderNum = orderNum;
	this.stkLoc = stkLoc;
	this.shipTime = shipTime;
	this.shipmentID = shipmentID;
	this.tradingPartner = tradingPartner;
	this.mBOL = mBOL;
	this.packSlip2 = packSlip2;
	this.proNumber = proNumber;
	this.status = status;
	this.bTAdd1 = bTAdd1;
	this.bTAdd2 = bTAdd2;
	this.bTAdd3 = bTAdd3;
	this.bTAdd4 = bTAdd4;
	this.bTProvState = bTProvState;
	this.bTCountry = bTCountry;
	this.bTPostZip = bTPostZip;
	this.bTContact = bTContact;
	this.sTAdd1 = sTAdd1;
	this.sTAdd2 = sTAdd2;
	this.sTAdd3 = sTAdd3;
	this.sTAdd4 = sTAdd4;
	this.sTProvState = sTProvState;
	this.sTCountry = sTCountry;
	this.sTPostZip = sTPostZip;
	this.sTContact = sTContact;
	this.sFAdd1 = sFAdd1;
	this.sFAdd2 = sFAdd2;
	this.sFAdd3 = sFAdd3;
	this.sFAdd4 = sFAdd4;
	this.sFProvState = sFProvState;
	this.sFCountry = sFCountry;
	this.sFPostZip = sFPostZip;
	this.sFContact = sFContact;
}

public
void setID(int iD){
	this.iD = iD;
}

public
void setDb(string db){
	this.db = db;
}

public
void setCompany(int company){
	this.company = company;
}

public
void setPlant(string plant){
	this.plant = plant;
}

public
void setPackSlipNum(int packSlipNum){
	this.packSlipNum = packSlipNum;
}

public
void setPackSlipType(string packSlipType){
	this.packSlipType = packSlipType;
}

public
void setDateCrt(DateTime dateCrt){
	this.dateCrt = dateCrt;
}

public
void setPrintInd(string printInd){
	this.printInd = printInd;
}

public
void setShipInd(string shipInd){
	this.shipInd = shipInd;
}

public
void setBillToCust(string billToCust){
	this.billToCust = billToCust;
}

public
void setShipToCust(string shipToCust){
	this.shipToCust = shipToCust;
}

public
void setBillToName(string billToName){
	this.billToName = billToName;
}

public
void setShipToName(string shipToName){
	this.shipToName = shipToName;
}

public
void setBillToPost(string billToPost){
	this.billToPost = billToPost;
}

public
void setAttention(string attention){
	this.attention = attention;
}

public
void setShipDate(DateTime shipDate){
	this.shipDate = shipDate;
}

public
void setShipVia(string shipVia){
	this.shipVia = shipVia;
}

public
void setOrderNum(int orderNum){
	this.orderNum = orderNum;
}

public
void setStkLoc(string stkLoc){
	this.stkLoc = stkLoc;
}

public
void setShipTime(DateTime shipTime){
	this.shipTime = shipTime;
}

public
void setShipmentID(string shipmentID){
	this.shipmentID = shipmentID;
}

public
void setTradingPartner(string tradingPartner){
	this.tradingPartner = tradingPartner;
}

public
void setMBOL(int mBOL){
	this.mBOL = mBOL;
}

public
void setPackSlip2(string packSlip2){
	this.packSlip2 = packSlip2;
}

public
void setProNumber(string proNumber){
	this.proNumber = proNumber;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setBTAdd1(string bTAdd1){
	this.bTAdd1 = bTAdd1;
}

public
void setBTAdd2(string bTAdd2){
	this.bTAdd2 = bTAdd2;
}

public
void setBTAdd3(string bTAdd3){
	this.bTAdd3 = bTAdd3;
}

public
void setBTAdd4(string bTAdd4){
	this.bTAdd4 = bTAdd4;
}

public
void setBTProvState(string bTProvState){
	this.bTProvState = bTProvState;
}

public
void setBTCountry(string bTCountry){
	this.bTCountry = bTCountry;
}

public
void setBTPostZip(string bTPostZip){
	this.bTPostZip = bTPostZip;
}

public
void setBTContact(string bTContact){
	this.bTContact = bTContact;
}

public
void setSTAdd1(string sTAdd1){
	this.sTAdd1 = sTAdd1;
}

public
void setSTAdd2(string sTAdd2){
	this.sTAdd2 = sTAdd2;
}

public
void setSTAdd3(string sTAdd3){
	this.sTAdd3 = sTAdd3;
}

public
void setSTAdd4(string sTAdd4){
	this.sTAdd4 = sTAdd4;
}

public
void setSTProvState(string sTProvState){
	this.sTProvState = sTProvState;
}

public
void setSTCountry(string sTCountry){
	this.sTCountry = sTCountry;
}

public
void setSTPostZip(string sTPostZip){
	this.sTPostZip = sTPostZip;
}

public
void setSTContact(string sTContact){
	this.sTContact = sTContact;
}

public
void setSFAdd1(string sFAdd1){
	this.sFAdd1 = sFAdd1;
}

public
void setSFAdd2(string sFAdd2){
	this.sFAdd2 = sFAdd2;
}

public
void setSFAdd3(string sFAdd3){
	this.sFAdd3 = sFAdd3;
}

public
void setSFAdd4(string sFAdd4){
	this.sFAdd4 = sFAdd4;
}

public
void setSFProvState(string sFProvState){
	this.sFProvState = sFProvState;
}

public
void setSFCountry(string sFCountry){
	this.sFCountry = sFCountry;
}

public
void setSFPostZip(string sFPostZip){
	this.sFPostZip = sFPostZip;
}

public
void setSFContact(string sFContact){
	this.sFContact = sFContact;
}

public
int getID(){
	 return iD;
}

public
string getDb(){
	 return db;
}

public
int getCompany(){
	 return company;
}

public
string getPlant(){
	 return plant;
}

public
int getPackSlipNum(){
	 return packSlipNum;
}

public
string getPackSlipType(){
	 return packSlipType;
}

public
DateTime getDateCrt(){
	 return dateCrt;
}

public
string getPrintInd(){
	 return printInd;
}

public
string getShipInd(){
	 return shipInd;
}

public
string getBillToCust(){
	 return billToCust;
}

public
string getShipToCust(){
	 return shipToCust;
}

public
string getBillToName(){
	 return billToName;
}

public
string getShipToName(){
	 return shipToName;
}

public
string getBillToPost(){
	 return billToPost;
}

public
string getAttention(){
	 return attention;
}

public
DateTime getShipDate(){
	 return shipDate;
}

public
string getShipVia(){
	 return shipVia;
}

public
int getOrderNum(){
	 return orderNum;
}

public
string getStkLoc(){
	 return stkLoc;
}

public
DateTime getShipTime(){
	 return shipTime;
}

public
string getShipmentID(){
	 return shipmentID;
}

public
string getTradingPartner(){
	 return tradingPartner;
}

public
int getMBOL(){
	 return mBOL;
}

public
string getPackSlip2(){
	 return packSlip2;
}

public
string getProNumber(){
	 return proNumber;
}

public
string getStatus(){
	 return status;
}

public
string getBTAdd1(){
	 return bTAdd1;
}

public
string getBTAdd2(){
	 return bTAdd2;
}

public
string getBTAdd3(){
	 return bTAdd3;
}

public
string getBTAdd4(){
	 return bTAdd4;
}

public
string getBTProvState(){
	 return bTProvState;
}

public
string getBTCountry(){
	 return bTCountry;
}

public
string getBTPostZip(){
	 return bTPostZip;
}

public
string getBTContact(){
	 return bTContact;
}

public
string getSTAdd1(){
	 return sTAdd1;
}

public
string getSTAdd2(){
	 return sTAdd2;
}

public
string getSTAdd3(){
	 return sTAdd3;
}

public
string getSTAdd4(){
	 return sTAdd4;
}

public
string getSTProvState(){
	 return sTProvState;
}

public
string getSTCountry(){
	 return sTCountry;
}

public
string getSTPostZip(){
	 return sTPostZip;
}

public
string getSTContact(){
	 return sTContact;
}

public
string getSFAdd1(){
	 return sFAdd1;
}

public
string getSFAdd2(){
	 return sFAdd2;
}

public
string getSFAdd3(){
	 return sFAdd3;
}

public
string getSFAdd4(){
	 return sFAdd4;
}

public
string getSFProvState(){
	 return sFProvState;
}

public
string getSFCountry(){
	 return sFCountry;
}

public
string getSFPostZip(){
	 return sFPostZip;
}

public
string getSFContact(){
	 return sFContact;
}

} // class

} // package