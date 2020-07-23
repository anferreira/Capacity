using System;

using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class Shift : MarshalByRefObject{

public const string SHIFT_TYPE_STANDARD		= "1";
public const string SHIFT_TYPE_OVER_TIME	= "2";
public const string SHIFT_TYPE_MIXED		= "3";

public const string SHIFT_STATUS_ACTIVE		= "A";
public const string SHIFT_STATUS_INACTIVE	= "I";

private string db;
private int company;
private string plt;
private string dept;
private string shf;
private string des;
private string shfType;
private string shfStatus;
private string regTime;
private DateTime strPeriod;
private DateTime endPeriod;
private int empNumTl;
private int machNum;
private decimal machDirCost;
private decimal labDirCost;
private decimal labIndCost;
private decimal labTempCost;
private int empNumD;
private int empNumI;
private int empNumT;

private ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer;
private ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer;

public 
Shift(){
}

internal
Shift(ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer,
	ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer){

	this.shiftDayDetailDataBaseContainer = shiftDayDetailDataBaseContainer;
	this.shiftDayDetailTransDataBaseContainer = shiftDayDetailTransDataBaseContainer;
}

public 
Shift(string db, int company, string plt, string dept, string shf, string des, string shfType, 
		string shfStatus, string regTime, DateTime strPeriod, DateTime endPeriod,
		int empNumTl, int machNum, decimal machDirCost, decimal labDirCost, 
		decimal labIndCost, decimal labTempCost, int empNumD, int empNumI, int empNumT, 
		ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer,
		ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer){

	this.db = db;
	this.company = company;
	this.plt = plt;
	this.dept = dept;
	this.shf = shf;
	this.des = des;
	this.shfType = shfType;
	this.shfStatus = shfStatus;
	this.regTime = regTime;
	this.strPeriod = strPeriod;
	this.endPeriod = endPeriod;
	this.empNumTl = empNumTl;
	this.machNum = machNum;
	this.machDirCost = machDirCost;
	this.labDirCost = labDirCost;
	this.labIndCost = labIndCost;
	this.labTempCost = labTempCost;
	this.empNumD = empNumD;
	this.empNumI = empNumI;
	this.empNumT = empNumT;

	this.shiftDayDetailDataBaseContainer = shiftDayDetailDataBaseContainer;
	this.shiftDayDetailTransDataBaseContainer = shiftDayDetailTransDataBaseContainer;
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
void setPlt(string plt){
	this.plt = plt;
}

public
void setDept(string dept){
	this.dept = dept;
}

public
void setShf(string shf){
	this.shf = shf;
}

public
void setDes(string des){
	this.des = des;
}

public
void setShfType(string shfType){
	this.shfType = shfType;
}

public
void setShfStatus(string shfStatus){
	this.shfStatus = shfStatus;
}

public
void setRegTime(string regTime){
	this.regTime = regTime;
}

public
void setStrPeriod(DateTime strPeriod){
	this.strPeriod = strPeriod;
}

public
void setEndPeriod(DateTime endPeriod){
	this.endPeriod = endPeriod;
}

public
void setEmpNumTl(int empNumTl){
	this.empNumTl = empNumTl;
}

public
void setMachNum(int machNum){
	this.machNum = machNum;
}

public
void setMachDirCost(decimal machDirCost){
	this.machDirCost = machDirCost;
}

public
void setLabDirCost(decimal labDirCost){
	this.labDirCost = labDirCost;
}

public
void setLabIndCost(decimal labIndCost){
	this.labIndCost = labIndCost;
}

public
void setLabTempCost(decimal labTempCost){
	this.labTempCost = labTempCost;
}

public
void setEmpNumD(int empNumD){
	this.empNumD = empNumD;
}

public
void setEmpNumI(int empNumI){
	this.empNumI = empNumI;
}

public
void setEmpNumT(int empNumT){
	this.empNumT = empNumT;
}


public
string getDb(){
	return db;
}

public 
string getPlt(){
	return plt;
}

public 
int getCompany(){
	return company;
}

public
string getDept(){
	return dept;
}

public
string getShf(){
	return shf;
}

public
string getDes(){
	return des;
}

public
string getShfType(){
	return shfType;
}

public
string getShfStatus(){
	return shfStatus;
}

public
string getRegTime(){
	return regTime;
}

public
DateTime getStrPeriod(){
	return strPeriod;
}

public	
DateTime getEndPeriod(){
	return endPeriod;
}

public
int getEmpNumTl(){
	return empNumTl;
}

public
int getMachNum(){
	return machNum;
}

public
decimal getMachDirCost(){
	return machDirCost;
}

public
decimal getLabDirCost(){
	return labDirCost;
}

public
decimal getLabIndCost(){
	return labIndCost;
}

public
decimal getLabTempCost(){
	return labTempCost;
}

public
int getEmpNumD(){
	return empNumD;
}

public
int getEmpNumI(){
	return empNumI;
}

public
int getEmpNumT(){
	return empNumT;
}

public
void setShiftDayDetailDataBaseContainer(ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer){
	this.shiftDayDetailDataBaseContainer = shiftDayDetailDataBaseContainer;
}

public
void setShiftDayDetailTransDataBaseContainer(ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer){
	this.shiftDayDetailTransDataBaseContainer = shiftDayDetailTransDataBaseContainer;
}

public
ShiftDayDetailDataBaseContainer getShiftDayDetailDataBaseContainer(){
	return shiftDayDetailDataBaseContainer;
}

public
ShiftDayDetailTransDataBaseContainer getShiftDayDetailTransDataBaseContainer(){
	return shiftDayDetailTransDataBaseContainer;
}

public
string[][] getDaysDetail(int dayAct, string timeCode){
	ArrayList array = new ArrayList();
	
	for(IEnumerator en = shiftDayDetailDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase) en.Current;
		if ((shiftDayDetailDataBase.getSDS_ShfActDay() == dayAct) &&
				(shiftDayDetailDataBase.getSDS_TmType().Equals(timeCode)))
			array.Add(shiftDayDetailDataBase);
	}

	string[][] vec = new string[array.Count][];
	int index = 0;
	for(IEnumerator en2 = array.GetEnumerator(); en2.MoveNext(); ){
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase) en2.Current;

		string[] reg = new string[11];
		reg[0]  = shiftDayDetailDataBase.getSDS_Db();
		reg[1]  = shiftDayDetailDataBase.getSDS_Company().ToString();
		reg[2]  = shiftDayDetailDataBase.getSDS_Plt();
		reg[3]  = shiftDayDetailDataBase.getSDS_Dept();
		reg[4]  = shiftDayDetailDataBase.getSDS_Shf();
		reg[5]  = shiftDayDetailDataBase.getSDS_TmType();
		reg[6]  = shiftDayDetailDataBase.getSDS_ShfActDay().ToString();
		reg[7]  = shiftDayDetailDataBase.getSDS_TmStr();
		reg[8]  = shiftDayDetailDataBase.getSDS_TmEnd();
		reg[9]  = shiftDayDetailDataBase.getSDS_Hours().ToString();
		reg[10] = shiftDayDetailDataBase.getSDS_DetailType();
		
		vec[index] = reg;
		index++;
	}
	return vec;
}

public
string[][] getDaysDetail(int dayAct){
	ArrayList array = new ArrayList();
	
	for(IEnumerator en = shiftDayDetailDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase) en.Current;
		if (shiftDayDetailDataBase.getSDS_ShfActDay() == dayAct)
			array.Add(shiftDayDetailDataBase);
	}

	string[][] vec = new string[array.Count][];
	int index = 0;
	for(IEnumerator en2 = array.GetEnumerator(); en2.MoveNext(); ){
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase) en2.Current;

		string[] reg = new string[11];
		reg[0]  = shiftDayDetailDataBase.getSDS_Db();
		reg[1]  = shiftDayDetailDataBase.getSDS_Company().ToString();
		reg[2]  = shiftDayDetailDataBase.getSDS_Plt();
		reg[3]  = shiftDayDetailDataBase.getSDS_Dept();
		reg[4]  = shiftDayDetailDataBase.getSDS_Shf();
		reg[5]  = shiftDayDetailDataBase.getSDS_TmType();
		reg[6]  = shiftDayDetailDataBase.getSDS_ShfActDay().ToString();
		reg[7]  = shiftDayDetailDataBase.getSDS_TmStr();
		reg[8]  = shiftDayDetailDataBase.getSDS_TmEnd();
		reg[9]  = shiftDayDetailDataBase.getSDS_Hours().ToString();
		reg[10] = shiftDayDetailDataBase.getSDS_DetailType();
		
		vec[index] = reg;
		index++;
	}
	return vec;
}

public
string[][] getDetails(){
	ArrayList array = new ArrayList();
	
	for(IEnumerator en = shiftDayDetailDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase) en.Current;
		array.Add(shiftDayDetailDataBase);
	}

	string[][] vec = new string[array.Count][];
	int index = 0;
	for(IEnumerator en2 = array.GetEnumerator(); en2.MoveNext(); ){
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase) en2.Current;

		string[] reg = new string[11];
		reg[0]  = shiftDayDetailDataBase.getSDS_Db();
		reg[1]  = shiftDayDetailDataBase.getSDS_Company().ToString();
		reg[2]  = shiftDayDetailDataBase.getSDS_Plt();
		reg[3]  = shiftDayDetailDataBase.getSDS_Dept();
		reg[4]  = shiftDayDetailDataBase.getSDS_Shf();
		reg[5]  = shiftDayDetailDataBase.getSDS_TmType();
		reg[6]  = shiftDayDetailDataBase.getSDS_ShfActDay().ToString();
		reg[7]  = shiftDayDetailDataBase.getSDS_TmStr();
		reg[8]  = shiftDayDetailDataBase.getSDS_TmEnd();
		reg[9]  = shiftDayDetailDataBase.getSDS_Hours().ToString();
		reg[10] = shiftDayDetailDataBase.getSDS_DetailType();
		
		vec[index] = reg;
		index++;
	}
	return vec;
}

public
string[] getDayDetailByTimeSpan(int dayAct, string timeStart, string timeEnd){
	ArrayList array = new ArrayList();
	
	IEnumerator enu = shiftDayDetailDataBaseContainer.GetEnumerator();
	ShiftDayDetailDataBase shiftDayDetailDataBase = null;
	while (enu.MoveNext() && (shiftDayDetailDataBase == null)){
		ShiftDayDetailDataBase current = (ShiftDayDetailDataBase) enu.Current;
		if ((current.getSDS_ShfActDay() == dayAct) && current.getSDS_TmStr().Equals(timeStart) && current.getSDS_TmEnd().Equals(timeEnd))
			shiftDayDetailDataBase = current;
	}

	if (shiftDayDetailDataBase != null)
	{
		string[] reg = new string[11];
		reg[0]  = shiftDayDetailDataBase.getSDS_Db();
		reg[1]  = shiftDayDetailDataBase.getSDS_Company().ToString();
		reg[2]  = shiftDayDetailDataBase.getSDS_Plt();
		reg[3]  = shiftDayDetailDataBase.getSDS_Dept();
		reg[4]  = shiftDayDetailDataBase.getSDS_Shf();
		reg[5]  = shiftDayDetailDataBase.getSDS_TmType();
		reg[6]  = shiftDayDetailDataBase.getSDS_ShfActDay().ToString();
		reg[7]  = shiftDayDetailDataBase.getSDS_TmStr();
		reg[8]  = shiftDayDetailDataBase.getSDS_TmEnd();
		reg[9]  = shiftDayDetailDataBase.getSDS_Hours().ToString();
		reg[10] = shiftDayDetailDataBase.getSDS_DetailType();
			
		return reg;
	}
	else
		return null;
}

public
void removeDayDetailByTimeSpan(int dayAct, string timeStart, string timeEnd){
	ArrayList array = new ArrayList();
	
	IEnumerator enu = shiftDayDetailDataBaseContainer.GetEnumerator();
	bool removed = false;
	int i = 0;	
	while ((i < shiftDayDetailDataBaseContainer.Count) && (!removed)){
		ShiftDayDetailDataBase current = (ShiftDayDetailDataBase)shiftDayDetailDataBaseContainer[i];
		if ((current.getSDS_ShfActDay() == dayAct) && current.getSDS_TmStr().Equals(timeStart) && current.getSDS_TmEnd().Equals(timeEnd))
		{
			shiftDayDetailDataBaseContainer.RemoveAt (i);
			removed = true;
		}
		i++;
	}
}

public 
void addDayDetail(int shfActDay, string tmType, string tmStr, string tmEnd, decimal hours, string detailType){
	ShiftDayDetailDataBase shiftDayDetailDataBase = new ShiftDayDetailDataBase(shiftDayDetailDataBaseContainer.getDataBaseAccess());
	shiftDayDetailDataBase.setSDS_Db(db);
	shiftDayDetailDataBase.setSDS_Company(company);
	shiftDayDetailDataBase.setSDS_Plt(plt);
	shiftDayDetailDataBase.setSDS_Dept(dept);
	shiftDayDetailDataBase.setSDS_Shf(shf);
	shiftDayDetailDataBase.setSDS_ShfActDay(shfActDay);
	shiftDayDetailDataBase.setSDS_TmType(tmType);
	shiftDayDetailDataBase.setSDS_TmStr(tmStr);
	shiftDayDetailDataBase.setSDS_TmEnd(tmEnd);
	shiftDayDetailDataBase.setSDS_Hours(hours);
	shiftDayDetailDataBase.setSDS_DetailType(detailType);
	shiftDayDetailDataBaseContainer.Add(shiftDayDetailDataBase);
}

public 
void addDayDetailTrans(DateTime shfAcTrnDte, string tmType, string tmStr, string tmEnd,
		decimal hours, DateTime shfStrTrnDte){
	
	ShiftDayDetailTransDataBase shiftDayDetailTransDataBase = new ShiftDayDetailTransDataBase(shiftDayDetailTransDataBaseContainer.getDataBaseAccess());
	shiftDayDetailTransDataBase.setSDDT_Db(db);
	shiftDayDetailTransDataBase.setSDDT_Company(company);
	shiftDayDetailTransDataBase.setSDDT_Plt(plt);
	shiftDayDetailTransDataBase.setSDDT_Dept(dept);
	shiftDayDetailTransDataBase.setSDDT_Shf(shf);
	shiftDayDetailTransDataBase.setSDDT_ShfAcTrnDte(shfAcTrnDte);
	shiftDayDetailTransDataBase.setSDDT_TmType(tmType);
	shiftDayDetailTransDataBase.setSDDT_TmStr(tmStr);
	shiftDayDetailTransDataBase.setSDDT_TmEnd(tmEnd);
	shiftDayDetailTransDataBase.setSDDT_Hours(hours);
	shiftDayDetailTransDataBase.setSDDT_ShfStrTrnDte(shfStrTrnDte);
	shiftDayDetailTransDataBaseContainer.Add(shiftDayDetailTransDataBase);
}

public void updateCrossReference()
{
	IEnumerator enu = shiftDayDetailDataBaseContainer.GetEnumerator();
	while (enu.MoveNext())
	{
		ShiftDayDetailDataBase shiftDayDetailDataBase = (ShiftDayDetailDataBase)enu.Current;
		shiftDayDetailDataBase.setSDS_Db (db);
		shiftDayDetailDataBase.setSDS_Company(company);
		shiftDayDetailDataBase.setSDS_Plt(plt);
		shiftDayDetailDataBase.setSDS_Dept(dept);
		shiftDayDetailDataBase.setSDS_Shf(shf);
	}
	enu = shiftDayDetailTransDataBaseContainer.GetEnumerator();
	while (enu.MoveNext())
	{
		ShiftDayDetailTransDataBase shiftDayDetailTransDataBase = (ShiftDayDetailTransDataBase)enu.Current;
		shiftDayDetailTransDataBase.setSDDT_Db (db);
		shiftDayDetailTransDataBase.setSDDT_Company(company);
		shiftDayDetailTransDataBase.setSDDT_Plt(plt);
		shiftDayDetailTransDataBase.setSDDT_Dept(dept);
		shiftDayDetailTransDataBase.setSDDT_Shf(shf);
	}
}



} // class

} // namespace