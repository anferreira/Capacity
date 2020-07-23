using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class Machine{

private string plt;
private string dept;
private string mach;
private string des1;
private string des2;
private string des3;
private string des4;
private string pltLoc;
private string inOut;
private string machTyp;
private string schType;
private decimal utilPer;
private string invDrFr;
private string invRecTo;
private decimal cableLn;
private string lnUom;
private decimal speed;
private decimal maxRacks;
private decimal defSpaceRack;
private string defSpaceUom;
private decimal maxWgt;
private string maxWgtUom;

private CapMacCfgDataBaseContainer capMacCfgDataBaseContainer;
private CapMacCfgADataBaseContainer capMacCfgADataBaseContainer;

private CapMacShfDataBaseContainer capMacShfDataBaseContainer;
private CapMacHrDataBaseContainer capMacHrDataBaseContainer;
private CapMacDayDataBaseContainer capMacDayDataBaseContainer;
private CapMacWkDataBaseContainer capMacWkDataBaseContainer;

private CapCfgShfDataBaseContainer capCfgShfDataBaseContainer;
private CapCfgDayDataBaseContainer capCfgDayDataBaseContainer;
private CapCfgWkDataBaseContainer capCfgWkDataBaseContainer;

public
Machine(){
}

public
Machine(CapMacCfgDataBaseContainer capMacCfgDataBaseContainer,
		CapMacCfgADataBaseContainer capMacCfgADataBaseContainer,
		CapMacShfDataBaseContainer capMacShfDataBaseContainer,
		CapMacHrDataBaseContainer capMacHrDataBaseContainer,
		CapMacDayDataBaseContainer capMacDayDataBaseContainer,
		CapMacWkDataBaseContainer capMacWkDataBaseContainer,
	
		CapCfgShfDataBaseContainer capCfgShfDataBaseContainer,
		CapCfgDayDataBaseContainer capCfgDayDataBaseContainer,
		CapCfgWkDataBaseContainer capCfgWkDataBaseContainer){
	
	this.plt = "";
	this.dept = "";
	this.mach = "";
	this.des1 = "";
	this.des2 = "";
	this.des3 = "";
	this.des4 = "";
	this.pltLoc = "";
	this.inOut = "";
	this.machTyp = "";
	this.schType = "";
	this.utilPer = 0;
	this.invDrFr = "";
	this.invRecTo = "";
	this.cableLn = 0;
	this.lnUom = "";
	this.speed = 0;
	this.maxRacks = 0;
	this.defSpaceRack = 0;
	this.defSpaceUom = "";
	this.maxWgt = 0;
	this.maxWgtUom = "";

	this.capMacCfgDataBaseContainer = capMacCfgDataBaseContainer;
	this.capMacCfgADataBaseContainer = capMacCfgADataBaseContainer;

	this.capMacShfDataBaseContainer = capMacShfDataBaseContainer;
	this.capMacHrDataBaseContainer = capMacHrDataBaseContainer;
	this.capMacDayDataBaseContainer = capMacDayDataBaseContainer;
	this.capMacWkDataBaseContainer = capMacWkDataBaseContainer;

	this.capCfgShfDataBaseContainer = capCfgShfDataBaseContainer;
	this.capCfgDayDataBaseContainer = capCfgDayDataBaseContainer;
	this.capCfgWkDataBaseContainer = capCfgWkDataBaseContainer;
}

public
Machine(string plt, string dept, string mach, string des1,
		string des2, string des3, string des4, string pltLoc,
		string inOut, string machTyp, string schType, 
		decimal utilPer, string invDrFr,
		string invRecTo, decimal cableLn, string lnUom,
		decimal speed, decimal maxRacks, decimal defSpaceRack,
		string defSpaceUom, decimal maxWgt, string maxWgtUom){

	this.plt = plt;
	this.dept = dept;
	this.mach = mach;
	this.des1 = des1;
	this.des2 = des2;
	this.des3 = des3;
	this.des4 = des4;
	this.pltLoc = pltLoc;
	this.inOut = inOut;
	this.machTyp = machTyp;
	this.schType = schType;
	this.utilPer = utilPer;
	this.invDrFr = invDrFr;
	this.invRecTo = invRecTo;
	this.cableLn = cableLn;
	this.lnUom = lnUom;
	this.speed = speed;
	this.maxRacks = maxRacks;
	this.defSpaceRack = defSpaceRack;
	this.defSpaceUom = defSpaceUom;
	this.maxWgt = maxWgt;
	this.maxWgtUom = maxWgtUom;
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
void setDes1(string des1){
	this.des1 = des1;
}

public
void setDes2(string des2){
	this.des2 = des2;
}

public
void setDes3(string des3){
	this.des3 = des3;
}

public
void setDes4(string des4){
	this.des4 = des4;
}

public
void setPltLoc(string pltLoc){
	this.pltLoc = pltLoc;
}

public
void setInOut(string inOut){
	this.inOut = inOut;
}

public
void setMachTyp(string machTyp){
	this.machTyp = machTyp;
}

public
void setSchType(string schType){
	this.schType = schType;
}

public
void setUtilPer(decimal utilPer){
	this.utilPer = utilPer;
}

public
void setInvDrFr(string invDrFr){
	this.invDrFr = invDrFr;
}

public
void setInvRecTo(string invRecTo){
	this.invRecTo = invRecTo;
}

public
void setCableLn(decimal cableLn){
	this.cableLn = cableLn;
}

public
void setLnUom(string lnUom){
	this.lnUom = lnUom;
}

public
void setSpeed(decimal speed){
	this.speed = speed;
}

public
void setMaxRacks(decimal maxRacks){
	this.maxRacks = maxRacks;
}

public
void setDefSpaceRack(decimal defSpaceRack){
	this.defSpaceRack = defSpaceRack;
}

public
void setDefSpaceUom(string defSpaceUom){
	this.defSpaceUom = defSpaceUom;
}

public
void setMaxWgt(decimal maxWgt){
	this.maxWgt = maxWgt;
}

public
void setMaxWgtUom(string maxWgtUom){
	this.maxWgtUom = maxWgtUom;
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
string getDes1(){
	return des1;
}

public
string getDes2(){
	return des2;
}

public
string getDes3(){
	return des3;
}

public
string getDes4(){
	return des4;
}

public
string getPltLoc(){
	return pltLoc;
}

public
string getInOut(){
	return inOut;
}

public
string getMachTyp(){
	return machTyp;
}

public
string getSchType(){
	return schType;
}

public
decimal getUtilPer(){
	return utilPer;
}

public
string getInvDrFr(){
	return invDrFr;
}

public
string getInvRecTo(){
	return invRecTo;
}

public
decimal getCableLn(){
	return cableLn;
}

public
string getLnUom(){
	return lnUom;
}

public
decimal getSpeed(){
	return speed;
}

public
decimal getMaxRacks(){
	return maxRacks;
}

public
decimal getDefSpaceRack(){
	return defSpaceRack;
}

public
string getDefSpaceUom(){
	return defSpaceUom;
}

public
decimal getMaxWgt(){
	return maxWgt;
}

public
string getMaxWgtUom(){
	return maxWgtUom;
}

public
string[][] getCapMacShfAsArray(){
	string[][] vec = new string[capMacShfDataBaseContainer.Count][];
	int index = 0;
	
	for(IEnumerator en = capMacShfDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		CapMacShfDataBase capMacShfDataBase = (CapMacShfDataBase) en.Current;

		string[] aux = new String[15];
		aux[0] = capMacShfDataBase.getCMS_SchVersion();
		aux[1] = capMacShfDataBase.getCMS_TmType();
		aux[2] = capMacShfDataBase.getCMS_Wk().ToString();
		aux[3] = DateUtil.getDateRepresentation(capMacShfDataBase.getCMS_Dt(), DateUtil.DDMMYYYY);
		aux[4] = capMacShfDataBase.getCMS_Shf();
		aux[5] = capMacShfDataBase.getCMS_Hr().ToString();
		aux[6] = capMacShfDataBase.getCMS_HrPr().ToString();
		aux[7] = capMacShfDataBase.getCMS_UtilPer().ToString();
		aux[8] = DateUtil.getDateRepresentation(capMacShfDataBase.getCMS_DtShf(), DateUtil.DDMMYYYY);
		aux[9] = capMacShfDataBase.getCMS_MachCyc().ToString();
		aux[10] = capMacShfDataBase.getCMS_Racks().ToString();
		aux[11] = capMacShfDataBase.getCMS_HrClm().ToString();
		aux[12] = capMacShfDataBase.getCMS_HrPrClm().ToString();
		aux[13] = capMacShfDataBase.getCMS_CapType();
		aux[14] = capMacShfDataBase.getCMS_TmBlkOrd().ToString();

		vec[index] = aux;
		index++;
	}
	return vec;
}

public
string[][] getCapMacHrByShfAsArray(string shf){
	CapMacHrDataBaseContainer auxiliarContainer = new CapMacHrDataBaseContainer(capMacHrDataBaseContainer.getDataBaseAccess());
	
	for(IEnumerator en1 = capMacHrDataBaseContainer.GetEnumerator(); en1.MoveNext(); ){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase) en1.Current;
		if (capMacHrDataBase.getCMH_Shf().Equals(shf))
			auxiliarContainer.Add(capMacHrDataBase);
	}
	
	string[][] vec = new string[auxiliarContainer.Count][];
	int index = 0;
	
	for(IEnumerator en2 = auxiliarContainer.GetEnumerator(); en2.MoveNext(); ){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase) en2.Current;

		string[] aux = new String[16];
		aux[0] = capMacHrDataBase.getCMH_SchVersion();
		aux[1] = capMacHrDataBase.getCMH_Wk().ToString();
		aux[2] = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_Dt(), DateUtil.DDMMYYYY);
		aux[3] = capMacHrDataBase.getCMH_TmBlkOrd().ToString();
		aux[4] = capMacHrDataBase.getCMH_TmType();
		aux[5] = capMacHrDataBase.getCMH_TmStart();
		aux[6] = capMacHrDataBase.getCMH_TmEnd();
		aux[7] = capMacHrDataBase.getCMH_Hr().ToString();
		aux[8] = capMacHrDataBase.getCMH_HrPr().ToString();
		aux[9] = capMacHrDataBase.getCMH_DtShf().ToString();
		aux[10] = capMacHrDataBase.getCMH_TmTypePre();
		aux[11] = capMacHrDataBase.getCMH_ShfCode();
		aux[12] = capMacHrDataBase.getCMH_UtilPer().ToString();
		aux[13] = capMacHrDataBase.getCMH_HrClm().ToString();
		aux[14] = capMacHrDataBase.getCMH_HrPrClm().ToString();
		aux[15] = capMacHrDataBase.getCMH_CapType();

		vec[index] = aux;
		index++;
	}
	return vec;
}

public
void removeAllCapMacShf(){
	IEnumerator iEnum = capMacShfDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapMacShfDataBase capMacShfDataBase = (CapMacShfDataBase)iEnum.Current;

		IEnumerator iEnum2 = capCfgShfDataBaseContainer.GetEnumerator();
		while(iEnum2.MoveNext()){
			CapCfgShfDataBase capCfgShfDataBase = (CapCfgShfDataBase)iEnum2.Current;
			
			if (capCfgShfDataBase.getCCH_Shf().Equals(capMacShfDataBase.getCMS_Shf())){
				decimal newHr = capCfgShfDataBase.getCCH_Hr() - capMacShfDataBase.getCMS_Hr();
				decimal newHrPr = capCfgShfDataBase.getCCH_HrPr() - capMacShfDataBase.getCMS_HrPr();
				
				if ((newHr > -1) && (newHrPr > -1)){
					capCfgShfDataBase.setCCH_Hr(newHr);
					capCfgShfDataBase.setCCH_HrPr(newHrPr);
				}
			}
		}
	}


	capMacShfDataBaseContainer.Clear();
	removeAllCapMacDay();
}

public
void removeCapMacShf(string tmType, int wk, DateTime dt, string shf){
	Object obj = null;
	
	IEnumerator iEnum = capMacShfDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapMacShfDataBase capMacShfDataBase = (CapMacShfDataBase)iEnum.Current;
		obj = capMacShfDataBase;

		if ( (capMacShfDataBase.getCMS_TmType().Equals(tmType)) &&
				(capMacShfDataBase.getCMS_Wk()== wk) &&
				(capMacShfDataBase.getCMS_Dt().Equals(dt)) &&
				(capMacShfDataBase.getCMS_Shf().Equals(shf)) ){

			IEnumerator iEnum2 = capCfgShfDataBaseContainer.GetEnumerator();
			while(iEnum2.MoveNext()){
				CapCfgShfDataBase capCfgShfDataBase = (CapCfgShfDataBase)iEnum2.Current;

				if ( (capCfgShfDataBase.getCCH_Shf().Equals(capMacShfDataBase.getCMS_Shf())) ){
					
					decimal newHr = capCfgShfDataBase.getCCH_Hr() - capMacShfDataBase.getCMS_Hr();
					decimal newHrPr = capCfgShfDataBase.getCCH_HrPr() - capMacShfDataBase.getCMS_HrPr();
					
					if ((newHr > -1) && (newHrPr > -1)){
						capCfgShfDataBase.setCCH_Hr(newHr);
						capCfgShfDataBase.setCCH_HrPr(newHrPr);
					}
				}
			}
		}

	}
	
	if (obj != null)
		capMacShfDataBaseContainer.Remove(obj);
}

public
void removeAllCapMacHr(){
	IEnumerator iEnum = capMacHrDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)iEnum.Current;

		IEnumerator iEnum2 = capMacCfgDataBaseContainer.GetEnumerator();
		while(iEnum2.MoveNext()){
			CapMacCfgDataBase capMacCfgDataBase = (CapMacCfgDataBase)iEnum2.Current;
			
			decimal newHr = capMacCfgDataBase.getCMC_TotalHrs() - capMacHrDataBase.getCMH_Hr();
			decimal newHrPr = capMacCfgDataBase.getCMC_TotalHrsPr() - capMacHrDataBase.getCMH_HrPr();
			
			if ((newHr > -1) && (newHrPr > -1)){
				capMacCfgDataBase.setCMC_TotalHrs(newHr);
				capMacCfgDataBase.setCMC_TotalHrsPr(newHrPr);
			}
		}
	}

	capMacHrDataBaseContainer.Clear();
}

public
void removeAllCapMacDay(){
	IEnumerator iEnum = capMacDayDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapMacDayDataBase capMacDayDataBase = (CapMacDayDataBase)iEnum.Current;

		IEnumerator iEnum2 = capCfgDayDataBaseContainer.GetEnumerator();
		while(iEnum2.MoveNext()){
			CapCfgDayDataBase capCfgDayDataBase = (CapCfgDayDataBase)iEnum2.Current;
			
			if ((capCfgDayDataBase.getCCD_Wk() == capMacDayDataBase.getCMD_Wk()) &&
					(capCfgDayDataBase.getCCD_Dt().Equals(capMacDayDataBase.getCMD_Dt()))){

				decimal newHr = capCfgDayDataBase.getCCD_Hr() - capMacDayDataBase.getCMD_Hr();
				decimal newHrPr = capCfgDayDataBase.getCCD_HrPr() - capMacDayDataBase.getCMD_HrPr();
				
				if ((newHr > -1) && (newHrPr > -1)){
					capCfgDayDataBase.setCCD_Hr(newHr);
					capCfgDayDataBase.setCCD_HrPr(newHrPr);
				}
			}
		}
	}

	capMacDayDataBaseContainer.Clear();
}

public
void removeAllCapMacHrByShf(string tmType, int wk, DateTime dt, string shf){
	CapMacHrDataBaseContainer auxiliarContainer = new CapMacHrDataBaseContainer(capMacHrDataBaseContainer.getDataBaseAccess());
	
	IEnumerator en = capMacHrDataBaseContainer.GetEnumerator();

	while(en.MoveNext()){
		CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase) en.Current;
		
		string date1 = DateUtil.getDateRepresentation(dt, DateUtil.DDMMYYYY);
		string date2 = DateUtil.getDateRepresentation(capMacHrDataBase.getCMH_Dt(), DateUtil.DDMMYYYY);

		if ( (!capMacHrDataBase.getCMH_Shf().Equals(shf))){
			auxiliarContainer.Add(capMacHrDataBase);
		}else{
			IEnumerator iEnum = capMacCfgDataBaseContainer.GetEnumerator();
			while(iEnum.MoveNext()){
				CapMacCfgDataBase capMacCfgDataBase = (CapMacCfgDataBase)iEnum.Current;
				
				decimal newHr = capMacCfgDataBase.getCMC_TotalHrs() - capMacHrDataBase.getCMH_Hr();
				decimal newHrPr = capMacCfgDataBase.getCMC_TotalHrsPr() - capMacHrDataBase.getCMH_HrPr();
				
				if ((newHr > -1) && (newHrPr > -1)){
					capMacCfgDataBase.setCMC_TotalHrs(newHr);
					capMacCfgDataBase.setCMC_TotalHrsPr(newHrPr);
				}
			}
		}
	}
	this.capMacHrDataBaseContainer = auxiliarContainer;
}

public
bool existsCapMacShf(string CMS_SchVersion, string CMS_TmType, int CMS_Wk, DateTime CMS_Dt,
		string CMS_Shf){

	IEnumerator iEnum = capMacShfDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapMacShfDataBase capMacShfDataBase = (CapMacShfDataBase)iEnum.Current;

		if ((capMacShfDataBase.getCMS_SchVersion().Equals(CMS_SchVersion)) &&
				(capMacShfDataBase.getCMS_TmType().Equals(CMS_TmType)) &&
				(capMacShfDataBase.getCMS_Wk() == CMS_Wk) &&
				(capMacShfDataBase.getCMS_Dt().Equals(CMS_Dt)) &&
				(capMacShfDataBase.getCMS_Shf().Equals(CMS_Shf))){

			return true;
		}
	}
	return false;
}

public
void addCapMacShf(string CMS_SchVersion, string CMS_Plt, string CMS_Dept,
		string CMS_Mach, string CMS_TmType, int CMS_Wk, DateTime CMS_Dt,
		string CMS_Shf, decimal CMS_Hr, decimal CMS_HrPr, decimal CMS_UtilPer,
		DateTime CMS_DtShf, decimal CMS_SchPr, decimal CMS_MachCyc,
		decimal CMS_Racks, decimal CMS_HrClm, decimal CMS_HrPrClm,
		string CMS_CapType, int CMS_TmBlkOrd){

	CapMacShfDataBase capMacShfDataBase = new CapMacShfDataBase(capMacShfDataBaseContainer.getDataBaseAccess());
	capMacShfDataBase.setCMS_SchVersion(CMS_SchVersion);
	capMacShfDataBase.setCMS_Plt(CMS_Plt);
	capMacShfDataBase.setCMS_Dept(CMS_Dept);
	capMacShfDataBase.setCMS_Mach(CMS_Mach);
	capMacShfDataBase.setCMS_TmType(CMS_TmType);
	capMacShfDataBase.setCMS_Wk(CMS_Wk);
	capMacShfDataBase.setCMS_Dt(CMS_Dt);
	capMacShfDataBase.setCMS_Shf(CMS_Shf);
	capMacShfDataBase.setCMS_Hr(CMS_Hr);
	capMacShfDataBase.setCMS_HrPr(CMS_HrPr);
	capMacShfDataBase.setCMS_UtilPer(CMS_UtilPer);
	capMacShfDataBase.setCMS_DtShf(CMS_DtShf);
	capMacShfDataBase.setCMS_SchPr(CMS_SchPr);
	capMacShfDataBase.setCMS_MachCyc(CMS_MachCyc);
	capMacShfDataBase.setCMS_Racks(CMS_Racks);
	capMacShfDataBase.setCMS_HrClm(CMS_HrClm);
	capMacShfDataBase.setCMS_HrPrClm(CMS_HrPrClm);
	capMacShfDataBase.setCMS_CapType(CMS_CapType);
	capMacShfDataBase.setCMS_TmBlkOrd(CMS_TmBlkOrd);
	
	capMacShfDataBaseContainer.Add(capMacShfDataBase);

	bool encontre = false;
	IEnumerator iEnum = capCfgShfDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapCfgShfDataBase capCfgShfDataBase = (CapCfgShfDataBase)iEnum.Current;
		
		if (capMacShfDataBase.getCMS_Shf().Equals(capCfgShfDataBase.getCCH_Shf())){
			decimal newHr = capCfgShfDataBase.getCCH_Hr() + capMacShfDataBase.getCMS_Hr();
			decimal newHrPr = capCfgShfDataBase.getCCH_HrPr() + capMacShfDataBase.getCMS_HrPr();
			capCfgShfDataBase.setCCH_Hr(newHr);
			capCfgShfDataBase.setCCH_HrPr(newHrPr);
			encontre = true;
		}
	}

	if (!encontre){ //distinct configuration
		IEnumerator iEnum2 = capMacCfgADataBaseContainer.GetEnumerator();
		while(iEnum2.MoveNext()){
			CapMacCfgADataBase capMacCfgADataBase = (CapMacCfgADataBase)iEnum2.Current;
			
			CapCfgShfDataBase capCfgShfDataBase = new CapCfgShfDataBase(capCfgShfDataBaseContainer.getDataBaseAccess());
			capCfgShfDataBase.setCCH_SchVersion(capMacShfDataBase.getCMS_SchVersion());
			capCfgShfDataBase.setCCH_Plt(capMacShfDataBase.getCMS_Plt());
			capCfgShfDataBase.setCCH_Dept(capMacShfDataBase.getCMS_Dept());
			capCfgShfDataBase.setCCH_Cfg(capMacCfgADataBase.getCMCA_Cfg());
			capCfgShfDataBase.setCCH_Wk(capMacShfDataBase.getCMS_Wk());
			capCfgShfDataBase.setCCH_WkAcc(capMacShfDataBase.getCMS_Wk());
			capCfgShfDataBase.setCCH_Dt(capMacShfDataBase.getCMS_Dt());
			capCfgShfDataBase.setCCH_TmType(capMacShfDataBase.getCMS_TmType());
			capCfgShfDataBase.setCCH_Shf(capMacShfDataBase.getCMS_Shf());
			capCfgShfDataBase.setCCH_Hr(capMacShfDataBase.getCMS_Hr());
			capCfgShfDataBase.setCCH_HrPr(capMacShfDataBase.getCMS_HrPr());
			capCfgShfDataBaseContainer.Add(capCfgShfDataBase);
		}
	}

	CapMacDayDataBase capMacDayDataBase = new CapMacDayDataBase(capMacDayDataBaseContainer.getDataBaseAccess());

	capMacDayDataBase.setCMD_SchVersion(capMacShfDataBase.getCMS_SchVersion());
	capMacDayDataBase.setCMD_Plt(capMacShfDataBase.getCMS_Plt());
	capMacDayDataBase.setCMD_Dept(capMacShfDataBase.getCMS_Dept());
	capMacDayDataBase.setCMD_Mach(capMacShfDataBase.getCMS_Mach());
	capMacDayDataBase.setCMD_TmType(capMacShfDataBase.getCMS_TmType());
	capMacDayDataBase.setCMD_Wk(capMacShfDataBase.getCMS_Wk());
	capMacDayDataBase.setCMD_Dt(capMacShfDataBase.getCMS_Dt());
	capMacDayDataBase.setCMD_Hr(capMacShfDataBase.getCMS_Hr());
	capMacDayDataBase.setCMD_HrPr(capMacShfDataBase.getCMS_HrPr());
	capMacDayDataBase.setCMD_UtilPer(capMacShfDataBase.getCMS_UtilPer());
	capMacDayDataBase.setCMD_MachCyc(capMacShfDataBase.getCMS_MachCyc());
	capMacDayDataBase.setCMD_SchPr(capMacShfDataBase.getCMS_SchPr());
	capMacDayDataBase.setCMD_Racks(capMacShfDataBase.getCMS_Racks());
	capMacDayDataBase.setCMD_TmBlkOrd(capMacShfDataBase.getCMS_TmBlkOrd());
	capMacDayDataBase.setCMD_HrCum(capMacShfDataBase.getCMS_HrClm());
	capMacDayDataBase.setCMD_HrPrCum(capMacShfDataBase.getCMS_HrPrClm());
	capMacDayDataBase.setCMD_CapType(capMacShfDataBase.getCMS_CapType());
	capMacDayDataBaseContainer.Add(capMacDayDataBase);

	bool dayFounded = false;
	IEnumerator iEnum3 = capCfgDayDataBaseContainer.GetEnumerator();
	while(iEnum3.MoveNext()){
		CapCfgDayDataBase capCfgDayDataBase = (CapCfgDayDataBase)iEnum3.Current;
		
		if ((capCfgDayDataBase.getCCD_Wk() == capMacDayDataBase.getCMD_Wk()) &&
				(capCfgDayDataBase.getCCD_Dt().Equals(capMacDayDataBase.getCMD_Dt()))){
			decimal newHr = capCfgDayDataBase.getCCD_Hr() + capMacDayDataBase.getCMD_Hr();
			decimal newHrPr = capCfgDayDataBase.getCCD_HrPr() + capMacDayDataBase.getCMD_HrPr();
			
			capCfgDayDataBase.setCCD_Hr(newHr);
			capCfgDayDataBase.setCCD_HrPr(newHrPr);
			dayFounded = true;
		}
	}

	if (!dayFounded){
		IEnumerator iEnum4 = capMacCfgADataBaseContainer.GetEnumerator();
		while(iEnum4.MoveNext()){
			CapMacCfgADataBase capMacCfgADataBase = (CapMacCfgADataBase)iEnum4.Current;
	
			CapCfgDayDataBase capCfgDayDataBase = new CapCfgDayDataBase(capMacCfgADataBase.getDataBaseAccess());
			capCfgDayDataBase.setCCD_SchVersion(capMacDayDataBase.getCMD_SchVersion());
			capCfgDayDataBase.setCCD_Plt(capMacDayDataBase.getCMD_Plt());
			capCfgDayDataBase.setCCD_Dept(capMacDayDataBase.getCMD_Dept());
			capCfgDayDataBase.setCCD_Cfg(capMacCfgADataBase.getCMCA_Cfg());
			capCfgDayDataBase.setCCD_Wk(capMacDayDataBase.getCMD_Wk());
			capCfgDayDataBase.setCCD_WkAcc(capMacDayDataBase.getCMD_Wk());
			capCfgDayDataBase.setCCD_Dt(capMacDayDataBase.getCMD_Dt());
			capCfgDayDataBase.setCCD_TmType(capMacDayDataBase.getCMD_TmType());
			capCfgDayDataBase.setCCD_Hr(capMacDayDataBase.getCMD_Hr());
			capCfgDayDataBase.setCCD_HrPr(capMacDayDataBase.getCMD_HrPr());
			capCfgDayDataBaseContainer.Add(capCfgDayDataBase);
		}
	}
}

public
void addCapMacHr(string CMH_SchVersion, string CMH_Plt, string CMH_Dept,
		string CMH_Mach, int CMH_Wk, DateTime CMH_Dt, string CMH_Shf,
		int CMH_TmBlkOrd, string CMH_TmType, string CMH_TmStart,
		string CMH_TmEnd, decimal CMH_Hr, decimal CMH_HrPr,
		DateTime CMH_DtShf, string CMH_TmTypePre, string CMH_ShfCode,
		decimal CMH_UtilPer, decimal CMH_HrClm, decimal CMH_HrPrClm,
		string CMH_CapType){
	
	CapMacHrDataBase capMacHrDataBase = new CapMacHrDataBase(capMacShfDataBaseContainer.getDataBaseAccess());

	capMacHrDataBase.setCMH_SchVersion(CMH_SchVersion);
	capMacHrDataBase.setCMH_Plt(CMH_Plt);
	capMacHrDataBase.setCMH_Dept(CMH_Dept);
	capMacHrDataBase.setCMH_Mach(CMH_Mach);
	capMacHrDataBase.setCMH_Wk(CMH_Wk);
	capMacHrDataBase.setCMH_Dt(CMH_Dt);
	capMacHrDataBase.setCMH_Shf(CMH_Shf);
	capMacHrDataBase.setCMH_TmBlkOrd(CMH_TmBlkOrd);
	capMacHrDataBase.setCMH_TmType(CMH_TmType);
	capMacHrDataBase.setCMH_TmStart(CMH_TmStart);
	capMacHrDataBase.setCMH_TmEnd(CMH_TmEnd);
	capMacHrDataBase.setCMH_Hr(CMH_Hr);
	capMacHrDataBase.setCMH_HrPr(CMH_HrPr);
	capMacHrDataBase.setCMH_DtShf(CMH_DtShf);
	capMacHrDataBase.setCMH_TmTypePre(CMH_TmTypePre);
	capMacHrDataBase.setCMH_ShfCode(CMH_ShfCode);
	capMacHrDataBase.setCMH_UtilPer(CMH_UtilPer);
	capMacHrDataBase.setCMH_HrClm(CMH_HrClm);
	capMacHrDataBase.setCMH_HrPrClm(CMH_HrPrClm);
	capMacHrDataBase.setCMH_CapType(CMH_CapType);
	
	capMacHrDataBaseContainer.Add(capMacHrDataBase);

	IEnumerator iEnum = capMacCfgDataBaseContainer.GetEnumerator();
	while(iEnum.MoveNext()){
		CapMacCfgDataBase capMacCfgDataBase = (CapMacCfgDataBase)iEnum.Current;
		decimal newHr = capMacCfgDataBase.getCMC_TotalHrs() + capMacHrDataBase.getCMH_Hr();
		decimal newHrPr = capMacCfgDataBase.getCMC_TotalHrsPr() + capMacHrDataBase.getCMH_HrPr();

		capMacCfgDataBase.setCMC_TotalHrs(newHr);
		capMacCfgDataBase.setCMC_TotalHrsPr(newHrPr);
	}
}

public
CapMacShfDataBaseContainer getCapMacShfDataBaseContainer(){
	return capMacShfDataBaseContainer;
}

public
void setCapMacCfgDataBaseContainer(CapMacCfgDataBaseContainer capMacCfgDataBaseContainer){
	this.capMacCfgDataBaseContainer = capMacCfgDataBaseContainer;
}

public
void setCapMacCfgADataBaseContainer(CapMacCfgADataBaseContainer capMacCfgADataBaseContainer){
	this.capMacCfgADataBaseContainer = capMacCfgADataBaseContainer;
}

public
void setCapMacHrDataBaseContainer(CapMacHrDataBaseContainer capMacHrDataBaseContainer ){
	this.capMacHrDataBaseContainer = capMacHrDataBaseContainer;
}

public
void setCapMacDayDataBaseContainer(CapMacDayDataBaseContainer capMacDayDataBaseContainer){
	this.capMacDayDataBaseContainer = capMacDayDataBaseContainer;
}

public
void setCapMacWkDataBaseContainer(CapMacWkDataBaseContainer capMacWkDataBaseContainer){
	this.capMacWkDataBaseContainer = capMacWkDataBaseContainer;
}

public
void setCapCfgShfDataBaseContainer(CapCfgShfDataBaseContainer capCfgShfDataBaseContainer){
	this.capCfgShfDataBaseContainer = capCfgShfDataBaseContainer;
}

public
void setCapCfgDayDataBaseContainer(CapCfgDayDataBaseContainer capCfgDayDataBaseContainer){
	this.capCfgDayDataBaseContainer = capCfgDayDataBaseContainer;
}

public
void setCapCfgWkDataBaseContainer(CapCfgWkDataBaseContainer capCfgWkDataBaseContainer){
	this.capCfgWkDataBaseContainer = capCfgWkDataBaseContainer;
}

public
CapMacCfgDataBaseContainer getCapMacCfgDataBaseContainer(){
	return capMacCfgDataBaseContainer;
}

public
CapMacCfgADataBaseContainer getCapMacCfgADataBaseContainer(){
	return capMacCfgADataBaseContainer;
}

public
CapMacHrDataBaseContainer getCapMacHrDataBaseContainer(){
	return capMacHrDataBaseContainer;
}

public
CapMacDayDataBaseContainer getCapMacDayDataBaseContainer(){
	return capMacDayDataBaseContainer;
}

public
CapMacWkDataBaseContainer getCapMacWkDataBaseContainer(){
	return capMacWkDataBaseContainer;
}

public
CapCfgShfDataBaseContainer getCapCfgShfDataBaseContainer(){
	return capCfgShfDataBaseContainer;
}

public
CapCfgDayDataBaseContainer getCapCfgDayDataBaseContainer(){
	return capCfgDayDataBaseContainer;
}

public
CapCfgWkDataBaseContainer getCapCfgWkDataBaseContainer(){
	return capCfgWkDataBaseContainer;
}

public override
string ToString ()
{
	return this.mach + " - " + this.des1;
}

} // class

} // namespace
