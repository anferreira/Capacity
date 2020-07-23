using System;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class ProductPlan : MarshalByRefObject{

private string prodID;
private string actID;
private int seq;
private decimal stdPack;
private string packType;
private decimal skidQty;
private string skidType;
private decimal minInv;
private decimal maxInv;
private string invUom;
private decimal minCon;
private decimal maxCon;
private int dohMin;
private int dohMax;
private decimal packWip;
private string contWip;
private decimal tarRunQty;
private string colour;
private decimal dayLT;
private decimal hourLT;
private decimal dayLTCum;
private decimal hourLTCum;

private int processLoc;
private int numofMachines;
private int scheduleType;
private string scheduleOrder;
private string laborDep;
private string machineDep;
private string toolDep;
private string capacityRestrict;

private int qtyOption;
private int daysInAdvance;
private string partsonSpecShift;
private string longSetup;
private string shortSetup;
private string batchOperation;
private string batchSize;
private string nextOpQtyTransfer;
private string seqSched;
private string mainMaterial;
private int mainMatSeq;
private decimal mainMatQty;

private string mainToolType;
private int numofTools;
private string schGroup1;
private string schGroup2;
private string schGroup3;
private string schGroup4;
private string schGroup5;
private string schGroup6;

private string forecast;
private string foreTimeFence;

private string reportingPoint;
private string excludeAlloc;
private string transferToNext;

private string excludeSats;
private string excludeSuns;


public 
ProductPlan(){
	prodID = "";
	actID = "";
	seq = 0;
	stdPack = 0;
	packType = "";
	skidQty = 0;
	skidType = "";
	minInv = 0;
	maxInv = 0;
	invUom = "";
	minCon = 0;
	maxCon = 0;
	dohMin = 0;
	dohMax = 0;
	packWip = 0;
	contWip = "";
	tarRunQty = 0;
	colour = "";
	dayLT = 0;
	hourLT = 0;
	dayLTCum = 0;
	hourLTCum = 0;

	processLoc = 0;
	numofMachines = 0;
	scheduleType = 0;
	scheduleOrder = "";
	laborDep = "";
	machineDep = "";
	toolDep = "";
	qtyOption = 0;
	daysInAdvance = 0;
	partsonSpecShift = "";
	longSetup = "";
	shortSetup = "";
	batchOperation = "";
	batchSize = "";
	nextOpQtyTransfer = "";
	seqSched = "";
	mainMaterial = "";
	mainMatSeq = 0;
	mainMatQty = 0;
	mainToolType = "";
	numofTools = 0;
	schGroup1 = "";
	schGroup2 = "";
	schGroup3 = "";
	schGroup4 = "";
	schGroup5 = "";
	schGroup6 = "";
	forecast = "";
	foreTimeFence = "";

	reportingPoint = "";
	excludeAlloc = "";
	capacityRestrict = "";
	transferToNext = "";
	excludeSats = "N";
	excludeSuns = "N";
}

public
ProductPlan(string prodID, string actID, int seq, decimal stdPack, string packType,
			decimal skidQty, string	skidType, decimal minInv, decimal maxInv, string invUom,
			decimal minCon, decimal maxCon, int dohMin, int dohMax, decimal packWip,
			string	contWip, decimal tarRunQty, string colour, decimal dayLT, decimal hourLT,
			decimal dayLTCum, decimal hourLTCum, 
	
			int processLoc, int numofMachines, int scheduleType, string scheduleOrder, string laborDep, 
			string machineDep, string toolDep, int qtyOption, int daysInAdvance, string partsonSpecShift, 
			string longSetup, string shortSetup, string batchOperation, string batchSize, string nextOpQtyTransfer, 
			string seqSched, string mainMaterial, int mainMatSeq, decimal mainMatQty, string mainToolType, 
			int numofTools, string schGroup1, string schGroup2, string schGroup3, string schGroup4, 
			string schGroup5, string schGroup6, string forecast, string foreTimeFence,
			string reportingPoint, string excludeAlloc, string capacityRestrict,
			string transferToNext, string excludeSats, string excludeSuns
	){

	this.prodID = prodID;
	this.actID = actID;
	this.seq = seq;
	this.stdPack = stdPack;
	this.packType = packType;
	this.skidQty = skidQty;
	this.skidType = skidType;
	this.minInv = minInv;
	this.maxInv = maxInv;
	this.invUom = invUom;
	this.minCon = minCon;
	this.maxCon = maxCon;
	this.dohMin = dohMin;
	this.dohMax = dohMax;
	this.packWip = packWip;
	this.contWip = contWip;
	this.tarRunQty	= tarRunQty;
	this.colour	= colour;
	this.dayLT = dayLT;
	this.hourLT = hourLT;
	this.dayLTCum = dayLTCum;
	this.hourLTCum = hourLTCum;

	this.processLoc = processLoc;
	this.numofMachines = numofMachines;
	this.scheduleType = scheduleType;
	this.scheduleOrder = scheduleOrder;
	this.laborDep = laborDep;
	this.machineDep = machineDep;
	this.toolDep = toolDep;
	this.qtyOption = qtyOption;
	this.daysInAdvance = daysInAdvance;
	this.partsonSpecShift = partsonSpecShift;
	this.longSetup = longSetup;
	this.shortSetup = shortSetup;
	this.batchOperation = batchOperation;
	this.batchSize = batchSize;
	this.nextOpQtyTransfer = nextOpQtyTransfer;
	this.seqSched = seqSched;
	this.mainMaterial = mainMaterial;
	this.mainMatSeq = mainMatSeq;
	this.mainMatQty = mainMatQty;
	
	this.mainToolType = mainToolType;
	this.numofTools = numofTools;
	this.schGroup1 = schGroup1;
	this.schGroup2 = schGroup2;
	this.schGroup3 = schGroup3;
	this.schGroup4 = schGroup4;
	this.schGroup5 = schGroup5;
	this.schGroup6 = schGroup6;
	this.forecast = forecast;
	this.foreTimeFence = foreTimeFence;

	this.reportingPoint = reportingPoint;
	this.excludeAlloc = excludeAlloc;
	this.capacityRestrict = capacityRestrict;

	this.transferToNext = transferToNext;
	this.excludeSats = excludeSats;
	this.excludeSuns = excludeSuns;
}

public
void setProdID(string prodID){
	this.prodID = prodID;
}

public
void setActID(string actID){
	this.actID = actID;
}

public
void setSeq(int seq){
	this.seq = seq;
}

public
void setStdPack(decimal stdPack){
	this.stdPack = stdPack;
}

public
void setPackType(string packType){
	this.packType = packType;
}

public
void setSkidQty(decimal skidQty){
	this.skidQty = skidQty;
}

public
void setSkidType(string skidType){
	this.skidType = skidType;
}

public
void setMinInv(decimal minInv){
	this.minInv = minInv;
}

public
void setMaxInv(decimal maxInv){
	this.maxInv = maxInv;
}

public
void setInvUom(string invUom){
	this.invUom = invUom;
}

public
void setMinCon(decimal minCon){
	this.minCon = minCon;
}

public
void setMaxCon(decimal maxCon){
	this.maxCon = maxCon;
}

public
void setDohMin(int dohMin){
	this.dohMin = dohMin;
}

public
void setDohMax(int dohMax){
	this.dohMax = dohMax;
}

public
void setPackWip(decimal packWip){
	this.packWip = packWip;
}

public
void setContWip(string contWip){
	this.contWip = contWip;
}

public
void setTarRunQty(decimal tarRunQty){
	this.tarRunQty = tarRunQty;
}

public
void setColour(string colour){
	this.colour = colour;
}

public
void setDayLT(decimal dayLT){
	this.dayLT = dayLT;
}

public
void setHourLT(decimal hourLT){
	this.hourLT = hourLT;
}

public
void setDayLTCum(decimal dayLTCum){
	this.dayLTCum = dayLTCum;
}

public
void setHourLTCum(decimal hourLTCum){
	this.hourLTCum = hourLTCum;
}

public
void setProcessLoc(int processLoc){
	this.processLoc = processLoc;
}

public
void setNumofMachines(int numofMachines){
	this.numofMachines = numofMachines;
}

public
void setScheduleType(int scheduleType){
	this.scheduleType = scheduleType;
}

public
void setScheduleOrder(string scheduleOrder){
	this.scheduleOrder = scheduleOrder;
}

public
void setLaborDep(string laborDep){
	this.laborDep = laborDep;
}

public
void setMachineDep(string machineDep){
	this.machineDep = machineDep;
}

public
void setToolDep(string toolDep){
	this.toolDep = toolDep;
}

public
void setQtyOption(int qtyOption){
	this.qtyOption = qtyOption;
}

public
void setDaysInAdvance(int daysInAdvance){
	this.daysInAdvance = daysInAdvance;
}

public
void setPartsonSpecShift(string partsonSpecShift){
	this.partsonSpecShift = partsonSpecShift;
}

public
void setLongSetup(string longSetup){
	this.longSetup = longSetup;
}

public
void setShortSetup(string shortSetup){
	this.shortSetup = shortSetup;
}

public
void setBatchOperation(string batchOperation){
	this.batchOperation = batchOperation;
}

public
void setBatchSize(string batchSize){
	this.batchSize = batchSize;
}

public
void setNextOpQtyTransfer(string nextOpQtyTransfer){
	this.nextOpQtyTransfer = nextOpQtyTransfer;
}

public
void setSeqSched(string seqSched){
	this.seqSched = seqSched;
}

public
void setMainMaterial(string mainMaterial){
	this.mainMaterial = mainMaterial;
}

public
void setMainMatSeq(int mainMatSeq){
	this.mainMatSeq = mainMatSeq;
}

public
void setMainMatQty(decimal mainMatQty){
	this.mainMatQty = mainMatQty;
}

public
void setMainToolType(string mainToolType){
	this.mainToolType = mainToolType;
}

public
void setNumofTools(int numofTools){
	this.numofTools = numofTools;
}

public
void setSchGroup1(string schGroup1){
	this.schGroup1 = schGroup1;
}

public
void setSchGroup2(string schGroup2){
	this.schGroup2 = schGroup2;
}

public
void setSchGroup3(string schGroup3){
	this.schGroup3 = schGroup3;
}

public
void setSchGroup4(string schGroup4){
	this.schGroup4 = schGroup4;
}

public
void setSchGroup5(string schGroup5){
	this.schGroup5 = schGroup5;
}

public
void setSchGroup6(string schGroup6){
	this.schGroup6 = schGroup6;
}

public
void setForecast(string forecast){
	this.forecast = forecast;
}

public
void setForeTimeFence(string foreTimeFence){
	this.foreTimeFence = foreTimeFence;
}

public
void setExcludeAlloc(string excludeAlloc){
	this.excludeAlloc = excludeAlloc;
}

public
void setReportingPoint(string reportingPoint){
	this.reportingPoint = reportingPoint;
}

public
void setCapacityRestrict(string capacityRestrict){
	this.capacityRestrict = capacityRestrict;
}

public
void setTransferToNext(string transferToNext){
	this.transferToNext = transferToNext;
}

public
void setExcludeSats(string excludeSats){
	this.excludeSats = excludeSats;
}

public
void setExcludeSuns(string excludeSuns){
	this.excludeSuns = excludeSuns;
}

public
string getProdID(){
	return prodID;
}

public
string getActID(){
	return actID;
}

public
int getSeq(){
	return seq;
}

public
decimal getStdPack(){
	return stdPack;
}

public
string getPackType(){
	return packType;
}

public
decimal getSkidQty(){
	return skidQty;
}

public
string getSkidType(){
	return skidType;
}

public
decimal getMinInv(){
	return minInv;
}

public
decimal getMaxInv(){
	return maxInv;
}

public
string getInvUom(){
	return invUom;
}

public
decimal getMinCon(){
	return minCon;
}

public
decimal getMaxCon(){
	return maxCon;
}

public
int getDohMin(){
	return dohMin;
}

public
int getDohMax(){
	return dohMax;
}

public
decimal getPackWip(){
	return packWip;
}

public
string getContWip(){
	return contWip;
}

public
decimal getTarRunQty(){
	return tarRunQty;
}

public
string getColour(){
	return colour;
}

public
decimal getDayLT(){
	return dayLT;
}

public
decimal getHourLT(){
	return hourLT;
}

public
decimal getDayLTCum(){
	return dayLTCum;
}

public
decimal getHourLTCum(){
	return hourLTCum;
}

public
int getProcessLoc(){
	return processLoc;
}

public
int getNumofMachines(){
	return numofMachines;
}

public
int getScheduleType(){
	return scheduleType;
}

public
string getScheduleOrder(){
	return scheduleOrder;
}

public
string getLaborDep(){
	return laborDep;
}

public
string getMachineDep(){
	return machineDep;
}

public
string getToolDep(){
	return toolDep;
}

public
int getQtyOption(){
	return qtyOption;
}

public
int getDaysInAdvance(){
	return daysInAdvance;
}

public
string getPartsonSpecShift(){
	return partsonSpecShift;
}

public
string getLongSetup(){
	return longSetup;
}

public
string getShortSetup(){
	return shortSetup;
}

public
string getBatchOperation(){
	return batchOperation;
}

public
string getBatchSize(){
	return batchSize;
}

public
string getNextOpQtyTransfer(){
	return nextOpQtyTransfer;
}

public
string getSeqSched(){
	return seqSched;
}

public
string getMainMaterial(){
	return mainMaterial;
}

public
int getMainMatSeq(){
	return mainMatSeq;
}

public
decimal getMainMatQty(){
	return mainMatQty;
}

public
string getMainToolType(){
	return mainToolType;
}

public
int getNumofTools(){
	return numofTools;
}

public
string getSchGroup1(){
	return schGroup1;
}

public
string getSchGroup2(){
	return schGroup2;
}

public
string getSchGroup3(){
	return schGroup3;
}

public
string getSchGroup4(){
	return schGroup4;
}

public
string getSchGroup5(){
	return schGroup5;
}

public
string getSchGroup6(){
	return schGroup6;
}

public
string getForecast(){
	return forecast;
}

public
string getForeTimeFence(){
	return foreTimeFence;
}

public
string getExcludeAlloc(){
	return excludeAlloc;
}

public
string getReportingPoint(){
	return reportingPoint;
}

public
string getCapacityRestrict(){
	return capacityRestrict;
}

public
string getTransferToNext(){
	return transferToNext;
}

public
string getExcludeSats(){
	return this.excludeSats;
}

public
string getExcludeSuns(){
	return this.excludeSuns;
}

} // class

} // namespace
