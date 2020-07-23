using System;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public
class SchLog : MarshalByRefObject{

private int iD;
private string db;
private string jobcardID;
private string company;
private string plant;
private string department;
private string machine;
private string part;
private string description;
private string part2;
private string description2;
private string part3;
private string description3;
private string part4;
private string description4;
private string family;
private string familyDescription;
private decimal runQty;
private string uOM;
private decimal runStandard;
private decimal machineHrs;
private string mainTool;
private decimal qtyPerTool;
private string mainMaterial;
private decimal qtyPer;
private decimal materialReq;
private string status;
private DateTime dateReq;
private string operation;
private string nextOperation;

internal
SchLog(){
	this.iD = 0;
	this.db = "";
	this.jobcardID = "";
	this.company = "";
	this.plant = "";
	this.department = "";
	this.machine = "";
	this.part = "";
	this.description = "";
	this.part2 = "";
	this.description2 = "";
	this.part3 = "";
	this.description3 = "";
	this.part4 = "";
	this.description4 = "";
	this.family = "";
	this.familyDescription = "";
	this.runQty = 0;
	this.uOM = "";
	this.runStandard = 0;
	this.machineHrs = 0;
	this.mainTool = "";
	this.qtyPerTool = 0;
	this.mainMaterial = "";
	this.qtyPer = 0;
	this.materialReq = 0;
	this.status = "";
}

internal
SchLog(
				int iD,
				string db,
				string jobcardID,
				string company,
				string plant,
				string department,
				string machine,
				string part,
				string description,
				string part2,
				string description2,
				string part3,
				string description3,
				string part4,
				string description4,
				string family,
				string familyDescription,
				decimal runQty,
				string uOM,
				decimal runStandard,
				decimal machineHrs,
				string mainTool,
				decimal qtyPerTool,
				string mainMaterial,
				decimal qtyPer,
				decimal materialReq,
				string status)
{
	this.iD = iD;
	this.db = db;
	this.jobcardID = jobcardID;
	this.company = company;
	this.plant = plant;
	this.department = department;
	this.machine = machine;
	this.part = part;
	this.description = description;
	this.part2 = part2;
	this.description2 = description2;
	this.part3 = part3;
	this.description3 = description3;
	this.part4 = part4;
	this.description4 = description4;
	this.family = family;
	this.familyDescription = familyDescription;
	this.runQty = runQty;
	this.uOM = uOM;
	this.runStandard = runStandard;
	this.machineHrs = machineHrs;
	this.mainTool = mainTool;
	this.qtyPerTool = qtyPerTool;
	this.mainMaterial = mainMaterial;
	this.qtyPer = qtyPer;
	this.materialReq = materialReq;
	this.status = status;
}

internal
void setID(int iD){
	this.iD = iD;
}

public
void setDb(string db){
	this.db = db;
}

public
void setJobcardID(string jobcardID){
	this.jobcardID = jobcardID;
}

public
void setCompany(string company){
	this.company = company;
}

public
void setPlant(string plant){
	this.plant = plant;
}

public
void setDepartment(string department){
	this.department = department;
}

public
void setMachine(string machine){
	this.machine = machine;
}

public
void setPart(string part){
	this.part = part;
}

public
void setDescription(string description){
	this.description = description;
}

public
void setPart2(string part2){
	this.part2 = part2;
}

public
void setDescription2(string description2){
	this.description2 = description2;
}

public
void setPart3(string part3){
	this.part3 = part3;
}

public
void setDescription3(string description3){
	this.description3 = description3;
}

public
void setPart4(string part4){
	this.part4 = part4;
}

public
void setDescription4(string description4){
	this.description4 = description4;
}

public
void setFamily(string family){
	this.family = family;
}

public
void setFamilyDescription(string familyDescription){
	this.familyDescription = familyDescription;
}

public
void setRunQty(decimal runQty){
	this.runQty = runQty;
}

public
void setUOM(string uOM){
	this.uOM = uOM;
}

public
void setRunStandard(decimal runStandard){
	this.runStandard = runStandard;
}

public
void setMachineHrs(decimal machineHrs){
	this.machineHrs = machineHrs;
}

public
void setMainTool(string mainTool){
	this.mainTool = mainTool;
}

public
void setQtyPerTool(decimal qtyPerTool){
	this.qtyPerTool = qtyPerTool;
}

public
void setMainMaterial(string mainMaterial){
	this.mainMaterial = mainMaterial;
}

public
void setQtyPer(decimal qtyPer){
	this.qtyPer = qtyPer;
}

public
void setMaterialReq(decimal materialReq){
	this.materialReq = materialReq;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setDateReq(DateTime dateReq){
	this.dateReq = dateReq;
}

public
void setOperation(string operation){
	this.operation = operation;
}

public
void setNextOperation(string nextOperation){
	this.nextOperation = nextOperation;
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
string getJobcardID(){
	 return jobcardID;
}

public
string getCompany(){
	 return company;
}

public
string getPlant(){
	 return plant;
}

public
string getDepartment(){
	 return department;
}

public
string getMachine(){
	 return machine;
}

public
string getPart(){
	 return part;
}

public
string getDescription(){
	 return description;
}

public
string getPart2(){
	 return part2;
}

public
string getDescription2(){
	 return description2;
}

public
string getPart3(){
	 return part3;
}

public
string getDescription3(){
	 return description3;
}

public
string getPart4(){
	 return part4;
}

public
string getDescription4(){
	 return description4;
}

public
string getFamily(){
	 return family;
}

public
string getFamilyDescription(){
	 return familyDescription;
}

public
decimal getRunQty(){
	 return runQty;
}

public
string getUOM(){
	 return uOM;
}

public
decimal getRunStandard(){
	 return runStandard;
}

public
decimal getMachineHrs(){
	 return machineHrs;
}

public
string getMainTool(){
	 return mainTool;
}

public
decimal getQtyPerTool(){
	 return qtyPerTool;
}

public
string getMainMaterial(){
	 return mainMaterial;
}

public
decimal getQtyPer(){
	 return qtyPer;
}

public
decimal getMaterialReq(){
	 return materialReq;
}

public
string getStatus(){
	 return status;
}

public
DateTime getDateReq(){
	return dateReq;
}

public
string getOperation(){
	return operation;
}

public
string getNextOperation(){
	return nextOperation;
}

public override
bool Equals(object obj){
	if (obj is SchLog)
		return	this.db.Equals(((SchLog)obj).getDb()) &&
				this.jobcardID.Equals(((SchLog)obj).getJobcardID()) &&
				this.company.Equals(((SchLog)obj).getCompany()) &&
				this.plant.Equals(((SchLog)obj).getPlant());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // package