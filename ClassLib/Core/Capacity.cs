using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]	
public 
class Capacity : MarshalByRefObject{

private string version;
private string plt;
private string dept;
private string mach;
private CapMacHrDataBaseContainer capMacHrDataBaseContainer;

public 
Capacity(CapMacHrDataBaseContainer capMacHrDataBaseContainer){
	this.version = "";
	this.plt = "";
	this.dept = "";
	this.mach = "";
	this.capMacHrDataBaseContainer = capMacHrDataBaseContainer;
}

public 
Capacity(string version, string plt, string dept, string mach, CapMacHrDataBaseContainer capMacHrDataBaseContainer){
    this.version = version;
	this.plt = plt;
    this.dept = dept;
    this.mach = mach;
	this.capMacHrDataBaseContainer = capMacHrDataBaseContainer;
}

public 
void setVersion(string version){
    this.version = version;
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
void setMach(string mach){
    this.mach = mach;
}

public 
void setCapMacHrDataBaseContainer(CapMacHrDataBaseContainer capMacHrDataBaseContainer){
    this.capMacHrDataBaseContainer = capMacHrDataBaseContainer;
}


public 
string getPlt(){
    return plt;
}

public 
string getDept(){
    return dept;
}

public 
string getMach(){
    return mach;
}

public 
string getVersion(){
    return version;
}

public 
CapMacHrDataBaseContainer getCapMacHrDataBaseContainer(){
    return capMacHrDataBaseContainer;
}

public string[][] getAllHoursAsString(){
	string[][] capacity = new string[capMacHrDataBaseContainer.Count][];

	int j=0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		string[] line = new string[16];
		line[0] = NumberUtil.toString(capMacHrDataBase.getCMH_Wk());
		line[1] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_Dt(), DateUtil.MMDDYYYY);
		line[2] = capMacHrDataBase.getCMH_Shf();
		line[3] = capMacHrDataBase.getCMH_TmType();
		line[4] = NumberUtil.toString(capMacHrDataBase.getCMH_TmBlkOrd());
		line[5] = capMacHrDataBase.getCMH_TmStart();
		line[6] = capMacHrDataBase.getCMH_TmEnd();
		line[7] = NumberUtil.toString(capMacHrDataBase.getCMH_Hr());
		line[8] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPr());
		line[9] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_DtShf(), DateUtil.MMDDYYYY);
		line[10] = capMacHrDataBase.getCMH_TmTypePre();
		line[11] = capMacHrDataBase.getCMH_ShfCode();
		line[12] = NumberUtil.toString(capMacHrDataBase.getCMH_UtilPer());
		line[13] = NumberUtil.toString(capMacHrDataBase.getCMH_HrClm());
		line[14] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPrClm());
		line[15] = capMacHrDataBase.getCMH_CapType();
		capacity[j] = line;
		j++;
	}
	return capacity;
}

public 
string[][] getCapacityHoursAsString(string shf){
	int dim = 0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;

		dim++;
	}

	string[][] capacity = new string[dim][];

	int j=0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;

		string[] line = new string[16];
		line[0] = NumberUtil.toString(capMacHrDataBase.getCMH_Wk());
		line[1] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_Dt(), DateUtil.MMDDYYYY);
		line[2] = capMacHrDataBase.getCMH_Shf();
		line[3] = capMacHrDataBase.getCMH_TmType();
		line[4] = NumberUtil.toString(capMacHrDataBase.getCMH_TmBlkOrd());
		line[5] = capMacHrDataBase.getCMH_TmStart();
		line[6] = capMacHrDataBase.getCMH_TmEnd();
		line[7] = NumberUtil.toString(capMacHrDataBase.getCMH_Hr());
		line[8] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPr());
		line[9] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_DtShf(), DateUtil.MMDDYYYY);
		line[10] = capMacHrDataBase.getCMH_TmTypePre();
		line[11] = capMacHrDataBase.getCMH_ShfCode();
		line[12] = NumberUtil.toString(capMacHrDataBase.getCMH_UtilPer());
		line[13] = NumberUtil.toString(capMacHrDataBase.getCMH_HrClm());
		line[14] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPrClm());
		line[15] = capMacHrDataBase.getCMH_CapType();
		capacity[j] = line;
		j++;
	}
	return capacity;
}

public 
string[][] getCapacityHoursOfWeekAsString(string shf, int weekNumber, int year){
	int dim = 0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Wk().Equals(weekNumber))
			continue;

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;

		if (!capMacHrDataBase.getCMH_Dt().Year.Equals(year))
			continue;
		
		dim++;
	}

	string[][] capacity = new string[dim][];

	int j = 0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Wk().Equals(weekNumber))
			continue;

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;

		if (!capMacHrDataBase.getCMH_Dt().Year.Equals(year))
			continue;

		string[] line = new string[16];
		line[0] = NumberUtil.toString(capMacHrDataBase.getCMH_Wk());
		line[1] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_Dt(), DateUtil.MMDDYYYY);
		line[2] = capMacHrDataBase.getCMH_Shf();
		line[3] = capMacHrDataBase.getCMH_TmType();
		line[4] = NumberUtil.toString(capMacHrDataBase.getCMH_TmBlkOrd());
		line[5] = capMacHrDataBase.getCMH_TmStart();
		line[6] = capMacHrDataBase.getCMH_TmEnd();
		line[7] = NumberUtil.toString(capMacHrDataBase.getCMH_Hr());
		line[8] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPr());
		line[9] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_DtShf(), DateUtil.MMDDYYYY);
		line[10] = capMacHrDataBase.getCMH_TmTypePre();
		line[11] = capMacHrDataBase.getCMH_ShfCode();
		line[12] = NumberUtil.toString(capMacHrDataBase.getCMH_UtilPer());
		line[13] = NumberUtil.toString(capMacHrDataBase.getCMH_HrClm());
		line[14] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPrClm());
		line[15] = capMacHrDataBase.getCMH_CapType();
		capacity[j] = line;
		j++;
	}
	return capacity;
}

public 
string[][] getCapacityHoursOfDayAsString(string shf, DateTime date){
	int dim = 0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Dt().Equals(date))
			continue;

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;
	
		dim++;
	}

	string[][] capacity = new string[dim][];

	int j = 0;
    for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Dt().Equals(date))
			continue;

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;

		string[] line = new string[16];
		line[0] = NumberUtil.toString(capMacHrDataBase.getCMH_Wk());
		line[1] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_Dt(), DateUtil.MMDDYYYY);
		line[2] = capMacHrDataBase.getCMH_Shf();
		line[3] = capMacHrDataBase.getCMH_TmType();
		line[4] = NumberUtil.toString(capMacHrDataBase.getCMH_TmBlkOrd());
		line[5] = capMacHrDataBase.getCMH_TmStart();
		line[6] = capMacHrDataBase.getCMH_TmEnd();
		line[7] = NumberUtil.toString(capMacHrDataBase.getCMH_Hr());
		line[8] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPr());
		line[9] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_DtShf(), DateUtil.MMDDYYYY);
		line[10] = capMacHrDataBase.getCMH_TmTypePre();
		line[11] = capMacHrDataBase.getCMH_ShfCode();
		line[12] = NumberUtil.toString(capMacHrDataBase.getCMH_UtilPer());
		line[13] = NumberUtil.toString(capMacHrDataBase.getCMH_HrClm());
		line[14] = NumberUtil.toString(capMacHrDataBase.getCMH_HrPrClm());
		line[15] = capMacHrDataBase.getCMH_CapType();
		capacity[j] = line;
		j++;
	}
	return capacity;
}

public 
string[] getOneCapacityHourAsString(string shf, DateTime date, string timeStart){
	int pos = -1;
    for(int i = 0; (i < capMacHrDataBaseContainer.Count) && (pos == -1); i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];

		if (!capMacHrDataBase.getCMH_Dt().Equals(date))
			continue;

		if (!capMacHrDataBase.getCMH_TmStart().Equals(timeStart))
			continue;

		if (!capMacHrDataBase.getCMH_Shf().Equals(shf))
			continue;
	
		pos = i;
	}

	CapMacHrDataBase cMHDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[pos];

	string[] line = new string[16];
	line[0] = NumberUtil.toString(cMHDataBase.getCMH_Wk());
	line[1] = DateUtil.getDateRepresentation(cMHDataBase.getCMH_Dt(), DateUtil.MMDDYYYY);
	line[2] = cMHDataBase.getCMH_Shf();
	line[3] = cMHDataBase.getCMH_TmType();
	line[4] = NumberUtil.toString(cMHDataBase.getCMH_TmBlkOrd());
	line[5] = cMHDataBase.getCMH_TmStart();
	line[6] = cMHDataBase.getCMH_TmEnd();
	line[7] = NumberUtil.toString(cMHDataBase.getCMH_Hr());
	line[8] = NumberUtil.toString(cMHDataBase.getCMH_HrPr());
	line[9] = DateUtil.getDateRepresentation(cMHDataBase.getCMH_DtShf(), DateUtil.MMDDYYYY);
	line[10] = cMHDataBase.getCMH_TmTypePre();
	line[11] = cMHDataBase.getCMH_ShfCode();
	line[12] = NumberUtil.toString(cMHDataBase.getCMH_UtilPer());
	line[13] = NumberUtil.toString(cMHDataBase.getCMH_HrClm());
	line[14] = NumberUtil.toString(cMHDataBase.getCMH_HrPrClm());
	line[15] = cMHDataBase.getCMH_CapType();

	return line;
}

public 
void addCapacityHour(int wk, DateTime dt, string shf, string tmType, int tmBlkOrd, string tmStart, 
		string tmEnd, decimal hr, decimal hrPr, DateTime dtShf, string tmTypePre, string shfCode, 
		decimal utilPer, decimal hrClm, decimal hrPrClm, string capType){
	
	CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(capMacHrDataBaseContainer.getDataBaseAccess());
	
	capMacHrDataBase.setCMH_SchVersion(this.version);
	capMacHrDataBase.setCMH_Plt(this.plt);
	capMacHrDataBase.setCMH_Dept(this.dept);
	capMacHrDataBase.setCMH_Mach(this.mach);
	capMacHrDataBase.setCMH_Wk(wk);
	capMacHrDataBase.setCMH_Dt(dt);
	capMacHrDataBase.setCMH_Shf(shf);
	capMacHrDataBase.setCMH_TmType(tmType);
	capMacHrDataBase.setCMH_TmBlkOrd(tmBlkOrd);
	capMacHrDataBase.setCMH_TmStart(tmStart);
	capMacHrDataBase.setCMH_TmEnd(tmEnd);
	capMacHrDataBase.setCMH_Hr(hr);
	capMacHrDataBase.setCMH_HrPr(hrPr);
	capMacHrDataBase.setCMH_DtShf(dtShf);
	capMacHrDataBase.setCMH_TmTypePre(tmTypePre);
	capMacHrDataBase.setCMH_ShfCode(shfCode);
	capMacHrDataBase.setCMH_UtilPer(utilPer);
	capMacHrDataBase.setCMH_HrClm(hrClm);
	capMacHrDataBase.setCMH_HrPrClm(hrPrClm);
	capMacHrDataBase.setCMH_CapType(capType);
	
	capMacHrDataBaseContainer.Add(capMacHrDataBase);
}

public 
void removeCapacityHour(string shf, DateTime dt, string tmType, string tmStart, string tmEnd){
	for(int i = 0; i < capMacHrDataBaseContainer.Count; i++){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)capMacHrDataBaseContainer[i];
		
		if ((capMacHrDataBase.getCMH_Shf().Equals(shf)) &&
				(capMacHrDataBase.getCMH_Dt().CompareTo(dt) == 0) &&
				(capMacHrDataBase.getCMH_TmType().Equals(tmType)) &&
				(capMacHrDataBase.getCMH_TmStart().Equals(tmStart)) &&
				(capMacHrDataBase.getCMH_TmEnd().Equals(tmEnd)))
		
			capMacHrDataBaseContainer.RemoveAt(i);
	}
}

public
void deleteAllHours(){
	capMacHrDataBaseContainer.Clear();
}

public void sort(){
	this.capMacHrDataBaseContainer.Sort();
}

}//end class

}//end namespace
