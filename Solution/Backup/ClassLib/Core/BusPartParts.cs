/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/BusPartParts.cs,v $ 
*   $State: Exp $ 
*   $Log: BusPartParts.cs,v $
*   Revision 1.8  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.7  2005/03/18 00:14:29  cmelo
*   *** empty log message ***
*
*   Revision 1.6  2005/03/17 02:52:36  cmelo
*   *** empty log message ***
*
*   Revision 1.5  2005/03/16 20:09:56  cmelo
*   *** empty log message ***
*
*   Revision 1.4  2005/03/15 21:26:35  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/03/15 01:10:26  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class BusPartParts : MarshalByRefObject
{

private int iD;
private string db;
private string part;
private int sequence;
private string busPartnerBT;
private string busPartPart;
private string busPartnerST;
private string revision;
private string dropShipCust;
private string consignment;
private decimal boxPackQty;
private decimal casePackQty;
private decimal skidPackQty;
private string packUom;
private string boxCont;
private string caseCont;
private string skidCont;
private string uPCCase;
private string uPCBox;
private string uPCSkid;
private string manufacturer;
private string alias;
private string uPC;
private DateTime startDate;
private DateTime endDate;
private string sC1;
private string sC2;
private string sC3;
private string sC4;
private string sC5;
private string sC6;
private string salesperson;
private string commPlan;
private decimal commPercent;
private decimal commRate;
private string packProfile;
private int warrantyDays;
private int expiryDate;
private string unitLFmt;
private int unitLFmtQty;
private string boxLFmt;
private int boxLFmtQty;
private string caseLFmt;
private int caseLFmtQty;
private string skidLFmt;
private int skidLFmtQty;
private string make;
private string model;
private string brand;
private string color;
private string size;
private string style;

public
BusPartParts(){
	this.iD = 0;
	this.db = "";
	this.part = "";
	this.sequence = 0;
	this.busPartnerBT = "";
	this.busPartPart = "";
	this.busPartnerST = "";
	this.revision = "";
	this.dropShipCust = "";
	this.consignment = "";
	this.boxPackQty = 0;
	this.casePackQty = 0;
	this.skidPackQty = 0;
	this.packUom = "";
	this.boxCont = "";
	this.caseCont = "";
	this.skidCont = "";
	this.uPCCase = "";
	this.uPCBox = "";
	this.uPCSkid = "";
	this.manufacturer = "";
	this.alias = "";
	this.uPC = "";
	this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
	this.sC1 = "";
	this.sC2 = "";
	this.sC3 = "";
	this.sC4 = "";
	this.sC5 = "";
	this.sC6 = "";
	this.salesperson = "";
	this.commPlan = "";
	this.commPercent = 0;
	this.commRate = 0;
	this.packProfile = "";
	this.warrantyDays = 0;
	this.expiryDate = 0;
	this.unitLFmt = "";
	this.unitLFmtQty = 0;
	this.boxLFmt = "";
	this.boxLFmtQty = 0;
	this.caseLFmt = "";
	this.caseLFmtQty = 0;
	this.skidLFmt = "";
	this.skidLFmtQty = 0;
	this.make = "";
	this.model = "";
	this.brand = "";
	this.color = "";
	this.size = "";
	this.style = "";
}

public
BusPartParts(
				int iD,
				string db,
				string part,
				int sequence,
				string busPartnerBT,
				string busPartPart,
				string revision,
				string busPartnerST,
				string dropShipCust,
				string consignment,
				decimal boxPackQty,
				decimal casePackQty,
				decimal skidPackQty,
				string packUom,
				string boxCont,
				string caseCont,
				string skidCont,
				string uPCCase,
				string uPCBox,
				string uPCSkid,
				string manuID,
				string alias,
				string uPC,
				DateTime startDate,
				DateTime endDate,
				string sC1,
				string sC2,
				string sC3,
				string sC4,
				string sC5,
				string sC6,
				string salesperson,
				string commPlan,
				decimal commPercent,
				decimal commRate,
				string packProfile,
				int warrantyDays,
				int expiryDate,
				string unitLFmt,
				int unitLFmtQty,
				string boxLFmt,
				int boxLFmtQty,
				string caseLFmt,
				int caseLFmtQty,
				string skidLFmt,
				int skidLFmtQty,
				string make,
				string model,
				string brand,
				string color,
				string size,
				string style)
{
	this.iD = iD;
	this.db = db;
	this.part = part;
	this.sequence = sequence;
	this.busPartnerBT = busPartnerBT;
	this.busPartPart = busPartPart;
	this.busPartnerST = busPartnerST;
	this.revision = revision;
	this.dropShipCust = dropShipCust;
	this.consignment = consignment;
	this.boxPackQty = boxPackQty;
	this.casePackQty = casePackQty;
	this.skidPackQty = skidPackQty;
	this.packUom = packUom;
	this.boxCont = boxCont;
	this.caseCont = caseCont;
	this.skidCont = skidCont;
	this.uPCCase = uPCCase;
	this.uPCBox = uPCBox;
	this.uPCSkid = uPCSkid;
	this.manufacturer= manufacturer;
	this.alias = alias;
	this.uPC = uPC;
	this.startDate = startDate;
	this.endDate = endDate;
	this.sC1 = sC1;
	this.sC2 = sC2;
	this.sC3 = sC3;
	this.sC4 = sC4;
	this.sC5 = sC5;
	this.sC6 = sC6;
	this.salesperson = salesperson;
	this.commPlan = commPlan;
	this.commPercent = commPercent;
	this.commRate = commRate;
	this.packProfile = packProfile;
	this.warrantyDays = warrantyDays;
	this.expiryDate = expiryDate;
	this.unitLFmt = unitLFmt;
	this.unitLFmtQty = unitLFmtQty;
	this.boxLFmt = boxLFmt;
	this.boxLFmtQty = boxLFmtQty;
	this.caseLFmt = caseLFmt;
	this.caseLFmtQty = caseLFmtQty;
	this.skidLFmt = skidLFmt;
	this.skidLFmtQty = skidLFmtQty;
	this.make = make;
	this.model = model;
	this.brand = brand;
	this.color = color;
	this.size = size;
	this.style = style;
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
void setPart(string part){
	this.part = part;
}

public
void setSequence(int sequence){
	this.sequence = sequence;
}

public
void setBusPartnerBT(string busPartnerBT){
	this.busPartnerBT = busPartnerBT;
}

public
void setBusPartPart(string busPartPart){
	this.busPartPart = busPartPart;
}

public
void setBusPartnerST(string busPartnerST){
	this.busPartnerST = busPartnerST;
}

public
void setRevision(string revision){
	this.revision = revision;
}

public
void setDropShipCust(string dropShipCust){
	this.dropShipCust = dropShipCust;
}

public
void setConsignment(string consignment){
	this.consignment = consignment;
}

public
void setBoxPackQty(decimal boxPackQty){
	this.boxPackQty = boxPackQty;
}

public
void setCasePackQty(decimal casePackQty){
	this.casePackQty = casePackQty;
}

public
void setSkidPackQty(decimal skidPackQty){
	this.skidPackQty = skidPackQty;
}

public
void setPackUom(string packUom){
	this.packUom = packUom;
}

public
void setBoxCont(string boxCont){
	this.boxCont = boxCont;
}

public
void setCaseCont(string caseCont){
	this.caseCont = caseCont;
}

public
void setSkidCont(string skidCont){
	this.skidCont = skidCont;
}

public
void setUPCCase(string uPCCase){
	this.uPCCase = uPCCase;
}

public
void setUPCBox(string uPCBox){
	this.uPCBox = uPCBox;
}

public
void setUPCSkid(string uPCSkid){
	this.uPCSkid = uPCSkid;
}

public
void setManufacturer(string manufacturer){
	this.manufacturer = manufacturer;
}

public
void setAlias(string alias){
	this.alias = alias;
}

public
void setUPC(string uPC){
	this.uPC = uPC;
}

public
void setStartDate(DateTime startDate){
	this.startDate = startDate;
}

public
void setEndDate(DateTime endDate){
	this.endDate = endDate;
}

public
void setSC1(string sC1){
	this.sC1 = sC1;
}

public
void setSC2(string sC2){
	this.sC2 = sC2;
}

public
void setSC3(string sC3){
	this.sC3 = sC3;
}

public
void setSC4(string sC4){
	this.sC4 = sC4;
}

public
void setSC5(string sC5){
	this.sC5 = sC5;
}

public
void setSC6(string sC6){
	this.sC6 = sC6;
}

public
void setSalesperson(string salesperson){
	this.salesperson = salesperson;
}

public
void setCommPlan(string commPlan){
	this.commPlan = commPlan;
}

public
void setCommPercent(decimal commPercent){
	this.commPercent = commPercent;
}

public
void setCommRate(decimal commRate){
	this.commRate = commRate;
}

public
void setPackProfile(string packProfile){
	this.packProfile = packProfile;
}

public
void setWarrantyDays(int warrantyDays){
	this.warrantyDays = warrantyDays;
}

public
void setExpiryDate(int expiryDate){
	this.expiryDate = expiryDate;
}

public
void setUnitLFmt(string unitLFmt){
	this.unitLFmt = unitLFmt;
}

public
void setUnitLFmtQty(int unitLFmtQty){
	this.unitLFmtQty = unitLFmtQty;
}

public
void setBoxLFmt(string boxLFmt){
	this.boxLFmt = boxLFmt;
}

public
void setBoxLFmtQty(int boxLFmtQty){
	this.boxLFmtQty = boxLFmtQty;
}

public
void setCaseLFmt(string caseLFmt){
	this.caseLFmt = caseLFmt;
}

public
void setCaseLFmtQty(int caseLFmtQty){
	this.caseLFmtQty = caseLFmtQty;
}

public
void setSkidLFmt(string skidLFmt){
	this.skidLFmt = skidLFmt;
}

public
void setSkidLFmtQty(int skidLFmtQty){
	this.skidLFmtQty = skidLFmtQty;
}

public
void setMake(string make){
	this.make = make;
}

public
void setModel(string model){
	this.model = model;
}

public
void setBrand(string brand){
	this.brand = brand;
}

public
void setColor(string color){
	this.color = color;
}

public
void setSize(string size){
	this.size = size;
}

public
void setStyle(string style){
	this.style = style;
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
string getPart(){
	 return part;
}

public
int getSequence(){
	 return sequence;
}

public
string getBusPartnerBT(){
	 return busPartnerBT;
}

public
string getBusPartPart(){
	return busPartPart;
}

public
string getBusPartnerST(){
	 return busPartnerST;
}

public
string getRevision(){
	return revision;
}

public
string getDropShipCust(){
	 return dropShipCust;
}

public
string getConsignment(){
	 return consignment;
}

public
decimal getBoxPackQty(){
	 return boxPackQty;
}

public
decimal getCasePackQty(){
	 return casePackQty;
}

public
decimal getSkidPackQty(){
	 return skidPackQty;
}

public
string getPackUom(){
	 return packUom;
}

public
string getBoxCont(){
	 return boxCont;
}

public
string getCaseCont(){
	 return caseCont;
}

public
string getSkidCont(){
	 return skidCont;
}

public
string getUPCCase(){
	 return uPCCase;
}

public
string getUPCBox(){
	 return uPCBox;
}

public
string getUPCSkid(){
	 return uPCSkid;
}

public
string getManufacturer(){
	 return manufacturer;
}

public
string getAlias(){
	 return alias;
}

public
string getUPC(){
	 return uPC;
}

public
DateTime getStartDate(){
	 return startDate;
}

public
DateTime getEndDate(){
	 return endDate;
}

public
string getSC1(){
	 return sC1;
}

public
string getSC2(){
	 return sC2;
}

public
string getSC3(){
	 return sC3;
}

public
string getSC4(){
	 return sC4;
}

public
string getSC5(){
	 return sC5;
}

public
string getSC6(){
	 return sC6;
}

public
string getSalesperson(){
	 return salesperson;
}

public
string getCommPlan(){
	 return commPlan;
}

public
decimal getCommPercent(){
	 return commPercent;
}

public
decimal getCommRate(){
	 return commRate;
}

public
string getPackProfile(){
	 return packProfile;
}

public
int getWarrantyDays(){
	 return warrantyDays;
}

public
int getExpiryDate(){
	 return expiryDate;
}

public
string getUnitLFmt(){
	 return unitLFmt;
}

public
int getUnitLFmtQty(){
	 return unitLFmtQty;
}

public
string getBoxLFmt(){
	 return boxLFmt;
}

public
int getBoxLFmtQty(){
	 return boxLFmtQty;
}

public
string getCaseLFmt(){
	 return caseLFmt;
}

public
int getCaseLFmtQty(){
	 return caseLFmtQty;
}

public
string getSkidLFmt(){
	 return skidLFmt;
}

public
int getSkidLFmtQty(){
	 return skidLFmtQty;
}

public
string getMake(){
	 return make;
}

public
string getModel(){
	 return model;
}

public
string getBrand(){
	 return brand;
}

public
string getColor(){
	 return color;
}

public
string getSize(){
	 return size;
}

public
string getStyle(){
	 return style;
}

} // class

} // package