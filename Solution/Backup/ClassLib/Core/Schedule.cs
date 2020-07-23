using System;
using System.Data;
using System.Collections;

using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.Core{

// Class Scheduling 
// This a core class namespace
// Contains all functionallity for make a plannig girid
//

[Serializable]
public 
class Schedule : MarshalByRefObject{

private string plant;
private string schVersion;

private PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer;
private SchMachHrDataBaseContainer schMachHrDataBaseContainer;
private SchPrMasDataBaseContainer schPrMasDataBaseContainer;
private SchPrFmHrDataBaseContainer schPrFmHrDataBaseContainer;
private SchPrFmHrDtDataBaseContainer schPrFmHrDtDataBaseContainer;	//Family components
private SchPrOrdDataBaseContainer schPrOrdDataBaseContainer;
private SchPrOrdDetDataBaseContainer schPrOrdDetDataBaseContainer;	//Family components
private SchVersionDataBase schVersionDataBase;
private ProdPackDtlDataBaseContainer prodPackDtlDataBaseContainer;
private SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer;

public
Schedule(string plant, string schVersion,
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer,
		SchMachHrDataBaseContainer schMachHrDataBaseContainer, 
		SchPrMasDataBaseContainer schPrMasDataBaseContainer, 
		SchPrFmHrDataBaseContainer schPrFmHrDataBaseContainer,
		SchPrFmHrDtDataBaseContainer schPrFmHrDtDataBaseContainer,
		SchPrOrdDataBaseContainer schPrOrdDataBaseContainer,
		SchPrOrdDetDataBaseContainer schPrOrdDetDataBaseContainer,
		SchVersionDataBase schVersionDataBase,
		ProdPackDtlDataBaseContainer prodPackDtlDataBaseContainer,
		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer){

	this.plant = plant;
	this.pltDeptMachDataBaseContainer = pltDeptMachDataBaseContainer;
	this.schMachHrDataBaseContainer = schMachHrDataBaseContainer;
	this.schPrMasDataBaseContainer = schPrMasDataBaseContainer;
	this.schPrFmHrDataBaseContainer = schPrFmHrDataBaseContainer;
	this.schPrFmHrDtDataBaseContainer = schPrFmHrDtDataBaseContainer;
	this.schPrOrdDataBaseContainer = schPrOrdDataBaseContainer;
	this.schPrOrdDetDataBaseContainer = schPrOrdDetDataBaseContainer;
	this.schVersion = schVersion;
	this.prodPackDtlDataBaseContainer = prodPackDtlDataBaseContainer;
	this.schVersionDataBase = schVersionDataBase;
	this.schMatReqDayDataBaseContainer = schMatReqDayDataBaseContainer;
}

public
void setPlant(string plant){
	this.plant = plant;
}

public 
void setSchVersion(string schVersion){
	this.schVersion = schVersion;
}

public 
string getSchVersion(){
	return schVersion;
}

public
string getPlant(){
	return plant;
}

public
string getVersion(){
	return schVersionDataBase.getSCH_Version();
}

public
string getStatus(){
	return schVersionDataBase.getSCH_Version();
}

public
DateTime getDtStartVersion(){
	return schVersionDataBase.getSCH_DtStart();
}

public
DateTime getDtEndVersion(){
	return schVersionDataBase.getSCH_DtEnd();
}

public
SortedList getMachines(){
	SortedList lst = new SortedList(pltDeptMachDataBaseContainer.Count);
	int i=0;

	for(IEnumerator en = pltDeptMachDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		PltDeptMachDataBase pltDeptMachDataBase = (PltDeptMachDataBase)en.Current;
		lst.Add(pltDeptMachDataBase.getPDM_Mach(), pltDeptMachDataBase.getPDM_Mach());
		i++;
	}
	return lst;
}

public
SortedList getUsedMachines(){
	SortedList lst = new SortedList(pltDeptMachDataBaseContainer.Count);

	for(IEnumerator en = schMachHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		SchMachHrDataBase schMachHrDataBase  = (SchMachHrDataBase) en.Current;
		string key = schMachHrDataBase.getSMH_Dept() + "_" + schMachHrDataBase.getSMH_Mach();
		if (!lst.ContainsKey(key))
		{
			string[] machine = {schMachHrDataBase.getSMH_Mach(), schMachHrDataBase.getSMH_Dept()};
			lst.Add(key, machine);
		}
	}

	return lst;
}

public 
string[] getSMOInfo(string prodId, string SPH_Version, string SPH_PrOrd, int SPH_Seq){
	for(IEnumerator en = schPrMasDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		SchPrMasDataBase schPrMasDataBase  = (SchPrMasDataBase) en.Current;

		if (!schPrMasDataBase.getSMO_ProdID().Equals(prodId))
			continue;

		if (!schPrMasDataBase.getSMO_SchVersion().Equals(SPH_Version))
			continue;

		if (!schPrMasDataBase.getSMO_PrOrdMas().Equals(SPH_PrOrd))
			continue;

		if (schPrMasDataBase.getSMO_Seq() != SPH_Seq)
			continue;

		string[] ret = new string[2];
		ret[0] = schPrMasDataBase.getSMO_Qty().ToString();
		ret[1] = schPrMasDataBase.getSMO_QtyMin().ToString();
		return ret;
	}
	return new string[0];
}

public 
string[] getNodeInfo(decimal SPH_PrOrd, string mach, DateTime fromDate, DateTime toDate){
	for(IEnumerator en = schMachHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		SchMachHrDataBase schMachHrDataBase  = (SchMachHrDataBase) en.Current;

		if (schMachHrDataBase.getSMH_MachOrdNum() != SPH_PrOrd)
			continue;
		
		if (!schMachHrDataBase.getSMH_Mach().Equals(mach))
			continue;

		DateTime date1 = schMachHrDataBase.getSMH_TmStart();
		DateTime date2 = schMachHrDataBase.getSMH_TmStart().AddHours((double)schMachHrDataBase.getSMH_HrPr());

		string[] ret = new string[5];
		ret[2] = NumberUtil.toString(schMachHrDataBase.getSMH_OrdID());
		ret[3] = NumberUtil.toString(schMachHrDataBase.getSMH_ItemID());
		ret[4] = schMachHrDataBase.getSMH_RLID();

		if ((fromDate.Ticks != 0) && (toDate.Ticks != 0))
		{
			if ((fromDate.CompareTo(date1) <= 0) && (toDate.CompareTo(date2) >= 0)){
				ret[0] = DateUtil.getCompleteDateRepresentation(date1,DateUtil.MMDDYYYY);
				ret[1] = DateUtil.getCompleteDateRepresentation(date2,DateUtil.MMDDYYYY);
				return ret;
			}
		}else{
			ret[0] = DateUtil.getCompleteDateRepresentation(date1,DateUtil.MMDDYYYY);
			ret[1] = DateUtil.getCompleteDateRepresentation(date2,DateUtil.MMDDYYYY);
			return ret;
		}
	}
	return null;
}

public
string[][] getSchPrFmHrForMachine(string machineCode, string deptCode){
	ArrayList lst = new ArrayList();
	for(IEnumerator en = schPrFmHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		SchPrFmHrDataBase schPrFmHrDataBase = (SchPrFmHrDataBase) en.Current;

		if (schPrFmHrDataBase.getSMH_Mach().Equals(machineCode))
			lst.Add(schPrFmHrDataBase);
	}

	string[][] returnArray = new string[lst.Count][];
	int i = 0;

	for(IEnumerator en = lst.GetEnumerator(); en.MoveNext(); ){
		SchPrFmHrDataBase schPrFmHrDataBase = (SchPrFmHrDataBase) en.Current;

		string[] lineArray = new string[12];

		lineArray[0] = schPrFmHrDataBase.getSPH_ProdID();
		lineArray[1] = schPrFmHrDataBase.getSPH_Seq().ToString();
		lineArray[2] = schPrFmHrDataBase.getSPH_HrPr().ToString(); // suma
		lineArray[3] = schPrFmHrDataBase.getSPH_UtilPer().ToString();
		lineArray[4] = schPrFmHrDataBase.getSMH_DRS();
		lineArray[5] = schPrFmHrDataBase.getSPH_UtilPer().ToString();
		lineArray[6] = schPrFmHrDataBase.getSPH_SchVersion();
		lineArray[7] = schPrFmHrDataBase.getSPH_PrOrdMas();
		lineArray[8] = schPrFmHrDataBase.getSPH_MachOrdNum().ToString();
		lineArray[9] = schPrFmHrDataBase.getSPH_RunStd().ToString();
		lineArray[10] = schPrFmHrDataBase.getSPH_HrPr().ToString();
		lineArray[11] = schPrFmHrDataBase.getSPH_UtilPer().ToString();
		returnArray[i] = lineArray;
		
		i++;
	}
	return returnArray;
}

public
string[][] getSchPrMasStr(){
	string[][] returnArray = new string[schPrMasDataBaseContainer.Count][];
	int i = 0;

	ArrayList lst = new ArrayList();
	for(IEnumerator en = schPrMasDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		SchPrMasDataBase schPrMasDataBase = (SchPrMasDataBase) en.Current;

		string[] lineArray = new string[32];
		lineArray[0] = schPrMasDataBase.getSMO_SchVersion();
		lineArray[1] = schPrMasDataBase.getSMO_PrOrdMas();
		lineArray[2] = schPrMasDataBase.getSMO_ProdID();
		lineArray[3] = schPrMasDataBase.getSMO_ActID();
		lineArray[4] = schPrMasDataBase.getSMO_Seq().ToString();
		lineArray[5] = schPrMasDataBase.getSMO_Status();
		lineArray[6] = schPrMasDataBase.getSMO_Qty().ToString();
		lineArray[7] = schPrMasDataBase.getSMO_QtyComp().ToString();
		lineArray[8] = schPrMasDataBase.getSMO_QtyMin().ToString();
		lineArray[9] = schPrMasDataBase.getSMO_QtyOver().ToString();
		lineArray[10] = schPrMasDataBase.getSMO_QtyUnd().ToString();
		lineArray[11] = schPrMasDataBase.getSMO_Uom().ToString();
		lineArray[12] = DateUtil.getCompleteDateRepresentation(schPrMasDataBase.getSMO_DtReq(), DateUtil.MMDDYYYY);
		lineArray[13] = DateUtil.getCompleteDateRepresentation(schPrMasDataBase.getSMO_DtStart(), DateUtil.MMDDYYYY);
		lineArray[14] = DateUtil.getCompleteDateRepresentation(schPrMasDataBase.getSMO_DtEnd(), DateUtil.MMDDYYYY);
		lineArray[15] = schPrMasDataBase.getSMO_HrPr().ToString();
		lineArray[16] = schPrMasDataBase.getSMO_HrPrUtil().ToString();
		lineArray[17] = schPrMasDataBase.getSMO_HrLabD().ToString();
		lineArray[18] = schPrMasDataBase.getSMO_MultiOrd();
		lineArray[19] = schPrMasDataBase.getSMO_MultiSeq();
		lineArray[20] = schPrMasDataBase.getSMO_Qty2().ToString();
		lineArray[21] = schPrMasDataBase.getSMO_Uom2();
		lineArray[22] = schPrMasDataBase.getSMO_HrBehind().ToString();

		// seek mach 
		string mach = "";
		string timeType = "";
		string utilPer = "";
		string shift = "";
		decimal ordID = 0;
		decimal itemID = 0;
		string rlID = "";
		string dept = "";

		for(IEnumerator en2 = schMachHrDataBaseContainer.GetEnumerator(); en2.MoveNext(); )
		{
			SchMachHrDataBase schMachHrDataBase = (SchMachHrDataBase) en2.Current;

			decimal ord1 = schMachHrDataBase.getSMH_MachOrdNum();
			decimal ord2 = decimal.Parse(schPrMasDataBase.getSMO_PrOrdMas());
			if (ord1 == ord2)
			{
				mach = schMachHrDataBase.getSMH_Mach();
				timeType = schMachHrDataBase.getSHM_TmType();
				utilPer = NumberUtil.toString(schMachHrDataBase.getSMH_UtilPer());
				shift = schMachHrDataBase.getSMH_Shf();
				ordID = schMachHrDataBase.getSMH_OrdID();
				itemID = schMachHrDataBase.getSMH_ItemID();
				rlID = schMachHrDataBase.getSMH_RLID();
				dept = schMachHrDataBase.getSMH_Dept();
			}
		}		

		// seek pos queue
		int queuePos = 0;
		for(IEnumerator en2 = schPrOrdDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
			SchPrOrdDataBase schPrOrdDataBase = (SchPrOrdDataBase) en2.Current;

			decimal ord1 = decimal.Parse(schPrOrdDataBase.getSPO_PrOrdMas());
			decimal ord2 = decimal.Parse(schPrMasDataBase.getSMO_PrOrdMas());
			if (ord1 == ord2)
				queuePos = schPrOrdDataBase.getSPO_QuePos();
		}

		lineArray[23] = mach;
		lineArray[24] = queuePos.ToString();
		lineArray[25] = shift;
		lineArray[26] = utilPer;
		lineArray[27] = timeType;
		lineArray[28] = ordID.ToString();
		lineArray[29] = itemID.ToString();
		lineArray[30] = rlID;
		lineArray[31] = dept;
		
		returnArray[i] = lineArray;
		i++;
	}
	return returnArray;
}

public
PltDeptMachDataBaseContainer getPltDeptMachDataBaseContainer(){
	return pltDeptMachDataBaseContainer;
}

public 
SchPrFmHrDtDataBaseContainer getSchPrFmHrDtDataBaseContainer(){
	return schPrFmHrDtDataBaseContainer;
}

public 
SchPrOrdDetDataBaseContainer getSchPrOrdDetDataBaseContainer(){
	return schPrOrdDetDataBaseContainer;
}

public
SchMachHrDataBaseContainer getSchMachHrDataBaseContainer(){
	return schMachHrDataBaseContainer;
}

public
SchPrMasDataBaseContainer getSchPrMasDataBaseContainer(){
	return schPrMasDataBaseContainer;
}

public
SchPrFmHrDataBaseContainer getSchPrFmHrDataBaseContainer(){
	return schPrFmHrDataBaseContainer;
}

public
SchPrOrdDataBaseContainer getSchPrOrdDataBaseContainer(){
	return schPrOrdDataBaseContainer;
}

public 
ProdPackDtlDataBaseContainer getProdPackDtlDataBaseContainer(){
	return prodPackDtlDataBaseContainer;
}

public
SchVersionDataBase getSchVersionDataBase(){
	return schVersionDataBase;
}

public
SchMatReqDayDataBaseContainer getSchMatReqDayDataBaseContainer(){
	return schMatReqDayDataBaseContainer;
}

public
void addAllItems(string plt, string[][] vec){
	DataBaseAccess dataBaseAccess = schPrMasDataBaseContainer.getDataBaseAccess();

	schMachHrDataBaseContainer.Clear();
	schPrFmHrDataBaseContainer.Clear();
	schPrFmHrDtDataBaseContainer.Clear();
	schPrOrdDataBaseContainer.Clear();
	schPrOrdDetDataBaseContainer.Clear();
	schPrMasDataBaseContainer.Clear();
	schMatReqDayDataBaseContainer.Clear();

	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

	for(int i = 0; i < vec.Length; i++){
		string cfg = vec[i][0];
		string prod = vec[i][1];
		bool isFamPart = UtilCoreFactory.createCoreFactory().isFamilyPart(prod);
		decimal seq = decimal.Parse(vec[i][2]);
		decimal qty = decimal.Parse(vec[i][3]);
		int pos = int.Parse(vec[i][4]);
		decimal hrPr = decimal.Parse(vec[i][5]);
		DateTime start = DateUtil.parseCompleteDate(vec[i][6], DateUtil.MMDDYYYY);
		DateTime end = DateUtil.parseCompleteDate(vec[i][7], DateUtil.MMDDYYYY);
		string shift = vec[i][8];
		decimal utilPer = decimal.Parse(vec[i][9]);
		string timeType = vec[i][10];
		decimal ordID = decimal.Parse(vec[i][11]);
		decimal itemID = decimal.Parse(vec[i][12]);
		string rlID = vec[i][13];
		string dept = vec[i][14];

		SchMachHrDataBase schMachHrDataBase = new SchMachHrDataBase(dataBaseAccess);
		schMachHrDataBase.setSMH_SchVersion(schVersionDataBase.getSCH_Version());
		schMachHrDataBase.setSMH_MachOrdNum(i);
		schMachHrDataBase.setSMH_Plt(plt);
		schMachHrDataBase.setSMH_Dept(dept);
		schMachHrDataBase.setSMH_Mach(cfg);
		schMachHrDataBase.setSMH_Shf(shift);
		schMachHrDataBase.setSMH_ShfGrp("");
		schMachHrDataBase.setSMH_DtShf(DateTime.Today);
		schMachHrDataBase.setSMH_Dt(DateTime.Today);
		schMachHrDataBase.setSMH_TmStart(start);
		schMachHrDataBase.setSMH_TmEnd(end);
		schMachHrDataBase.setSMH_Qty(qty);
		schMachHrDataBase.setSMH_Cycles(0);
		schMachHrDataBase.setSMH_HrPr(hrPr);
		schMachHrDataBase.setSMH_HrPrUtil((hrPr * utilPer) / 100);
		schMachHrDataBase.setSMH_UtilPer(utilPer);
		schMachHrDataBase.setSHM_TmType(timeType);
		schMachHrDataBase.setSMH_CountSt(0);
		schMachHrDataBase.setSMH_CountEnd(0);
		schMachHrDataBase.setSMH_MasPrOrd("1");
		schMachHrDataBase.setSMH_PrOrd("1");
		schMachHrDataBase.setSMH_Status("A");
		schMachHrDataBase.setSMH_DRS("S");
		schMachHrDataBase.setSMH_HoursBeh(0);
		schMachHrDataBase.setSMH_OrdID(ordID);
		schMachHrDataBase.setSMH_ItemID(itemID);
		schMachHrDataBase.setSMH_RLID(rlID);
		schMachHrDataBase.setSMH_SchVersion(schVersion);
		schMachHrDataBaseContainer.Add(schMachHrDataBase);
	
		SchPrFmHrDataBase schPrFmHrDataBase = new SchPrFmHrDataBase(dataBaseAccess);
		schPrFmHrDataBase.setSPH_SchVersion(schVersion);
		schPrFmHrDataBase.setSPH_SchOrdNum(decimal.Parse(i.ToString()));
		schPrFmHrDataBase.setSPH_MachOrdNum(decimal.Parse(i.ToString()));
		schPrFmHrDataBase.setSPH_PrOrdMas(i.ToString());
		schPrFmHrDataBase.setSPH_PrOrd("1");
		schPrFmHrDataBase.setSPH_ProdID(prod);
		schPrFmHrDataBase.setSPH_ActID("");
		schPrFmHrDataBase.setSPH_Seq(int.Parse(seq.ToString()));
		schPrFmHrDataBase.setSPH_MethodRank(0);
		schPrFmHrDataBase.setSPH_TmType(timeType);
		schPrFmHrDataBase.setSPH_DlyOrdID(0);
		schPrFmHrDataBase.setSPH_Hr(0);
		schPrFmHrDataBase.setSPH_HrPr(hrPr);
		schPrFmHrDataBase.setSPH_Qty(qty);
		schPrFmHrDataBase.setSPH_QtyUtil(0);
		schPrFmHrDataBase.setSPH_CountSt(0);
		schPrFmHrDataBase.setSPH_CountEnd(0);
		schPrFmHrDataBase.setSPH_Loc("");
		schPrFmHrDataBase.setSPH_Cycle(0);
		schPrFmHrDataBase.setSPH_RunStd(0);
		schPrFmHrDataBase.setSPH_UtilPer(utilPer);
		schPrFmHrDataBase.setSPH_Effic(0);
		schPrFmHrDataBase.setSPH_EfficUom("");
		schPrFmHrDataBase.setSPH_EfficPer(0);
		schPrFmHrDataBase.setSPH_ContQty(0);
		schPrFmHrDataBase.setSPH_RackQty(0);
		schPrFmHrDataBase.setSPH_Status("A");
		schPrFmHrDataBaseContainer.Add(schPrFmHrDataBase);

		SchPrOrdDataBase schPrOrdDataBase = new SchPrOrdDataBase(dataBaseAccess);
		schPrOrdDataBase.setSPO_SchVersion(schVersion);
		schPrOrdDataBase.setSPO_PrOrdMas(i.ToString());
		schPrOrdDataBase.setSPO_PrOrd(i.ToString());
		schPrOrdDataBase.setSPO_Plt(plt);
		schPrOrdDataBase.setSPO_Dept(dept);
		schPrOrdDataBase.setSPO_Mach(cfg);
		schPrOrdDataBase.setSPO_ProdID(prod);
		schPrOrdDataBase.setSPO_ActID("");
		schPrOrdDataBase.setSPO_Seq(int.Parse(seq.ToString()));
		schPrOrdDataBase.setSPO_Status("A");
		schPrOrdDataBase.setSPO_Qty(qty);
		schPrOrdDataBase.setSPO_QtyComp(0);
		schPrOrdDataBase.setSPO_QtyScrap(0);
		schPrOrdDataBase.setSPO_Uom("");
		schPrOrdDataBase.setSPO_TmRun(0);
		schPrOrdDataBase.setSPO_Shf(shift);
		schPrOrdDataBase.setSPO_DtStart(start);
		schPrOrdDataBase.setSPO_DtEnd(end);
		schPrOrdDataBase.setSPO_FamMulti("");
		schPrOrdDataBase.setSPO_HrLab(0);
		schPrOrdDataBase.setSPO_HrPr(hrPr);
		schPrOrdDataBase.setSPO_Qty2(0);
		schPrOrdDataBase.setSPO_Uom2("1");
		schPrOrdDataBase.setSPO_QtyMin(0);
		schPrOrdDataBase.setSPO_HrBehind(0);
		schPrOrdDataBase.setSPO_QuePos(pos);
		schPrOrdDataBaseContainer.Add(schPrOrdDataBase);

		if (isFamPart) {
			ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
            
			prodFmActPlanDataBase.setPAPL_ProdID(prod);
			if (prodFmActPlanDataBase.exists()) {
				prodFmActPlanDataBase.read();
                ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
				prodFmActPlanDtDataBaseContainer.readByFamilyPart(prod);
				int subOrdNum = 0;
				for(IEnumerator en = prodFmActPlanDtDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
					ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = (ProdFmActPlanDtDataBase) en.Current;

					SchPrOrdDetDataBase schPrOrdDetDataBase = new SchPrOrdDetDataBase(dataBaseAccess);
					schPrOrdDetDataBase.setSPOD_ProdID(prodFmActPlanDtDataBase.getPFPD_ProdID());
					schPrOrdDetDataBase.setSPOD_Seq(prodFmActPlanDataBase.getPAPL_Seq());
					schPrOrdDetDataBase.setSPOD_ActID(prodFmActPlanDataBase.getPAPL_ActID());
					schPrOrdDetDataBase.setSPOD_Qty(prodFmActPlanDtDataBase.getPFPD_Qty()*qty);
                    schPrOrdDetDataBase.setSPOD_QtyComp(0);
					schPrOrdDetDataBase.setSPOD_QtyScrap(0);
					schPrOrdDetDataBase.setSPOD_SchVersion(schVersion);
					schPrOrdDetDataBase.setSPOD_PrOrdMas(i.ToString());
					schPrOrdDetDataBase.setSPOD_PrOrd(i.ToString());
					schPrOrdDetDataBase.setSPODD_LineID(subOrdNum);
					schPrOrdDetDataBaseContainer.Add(schPrOrdDetDataBase);

					SchPrFmHrDtDataBase schPrFmHrDtDataBase = new SchPrFmHrDtDataBase(dataBaseAccess);
					schPrFmHrDtDataBase.setSPHD_ProdID(prodFmActPlanDtDataBase.getPFPD_ProdID());
					schPrFmHrDtDataBase.setSPHD_Seq(prodFmActPlanDataBase.getPAPL_Seq());
					schPrFmHrDtDataBase.setSPHD_ActID(prodFmActPlanDataBase.getPAPL_ActID());
					schPrFmHrDtDataBase.setSPHD_QtySch(prodFmActPlanDtDataBase.getPFPD_Qty()*qty);
                    schPrFmHrDtDataBase.setSPHD_DlyOrdID(0);
					schPrFmHrDtDataBase.setSPHD_CavAvail(0);
					schPrFmHrDtDataBase.setSPHD_SchVersion(schVersion);
					schPrFmHrDtDataBase.setSPHD_PrOrdMas(i.ToString());
					schPrFmHrDtDataBase.setSPHD_PrOrd(i.ToString());
					schPrFmHrDtDataBase.setSPHD_Dt(start);
					schPrFmHrDtDataBase.setSPHD_SubOrdNum(subOrdNum++);
					schPrFmHrDtDataBase.setSPHD_SchOrdNum(decimal.Parse(i.ToString()));
					schPrFmHrDtDataBase.setSPHD_MachOrdNum(decimal.Parse(i.ToString()));
					schPrFmHrDtDataBaseContainer.Add(schPrFmHrDtDataBase);
				}				
			}
		}

		SchPrMasDataBase schPrMasDataBase = new SchPrMasDataBase(dataBaseAccess);
		schPrMasDataBase.setSMO_SchVersion(schVersion);
		schPrMasDataBase.setSMO_PrOrdMas(i.ToString());
		schPrMasDataBase.setSMO_ProdID(prod);
		schPrMasDataBase.setSMO_ActID("");
		schPrMasDataBase.setSMO_Seq(int.Parse(seq.ToString()));
		schPrMasDataBase.setSMO_Status("A");
		schPrMasDataBase.setSMO_Qty(qty);
		schPrMasDataBase.setSMO_QtyComp("");
		schPrMasDataBase.setSMO_QtyMin(0);
		schPrMasDataBase.setSMO_QtyOver(0);
		schPrMasDataBase.setSMO_QtyUnd(0);
		schPrMasDataBase.setSMO_Uom("");
		schPrMasDataBase.setSMO_DtReq(DateTime.Today);
		schPrMasDataBase.setSMO_DtStart(start);
		schPrMasDataBase.setSMO_DtEnd(end);
		schPrMasDataBase.setSMO_HrPr(hrPr);
		schPrMasDataBase.setSMO_HrPrUtil((hrPr * utilPer) / 100);
		schPrMasDataBase.setSMO_HrLabD(0);
		schPrMasDataBase.setSMO_MultiOrd("");
		schPrMasDataBase.setSMO_MultiSeq("");
		schPrMasDataBase.setSMO_Qty2(0);
		schPrMasDataBase.setSMO_Uom2("");
		schPrMasDataBase.setSMO_HrBehind(0);
		schPrMasDataBaseContainer.Add(schPrMasDataBase);

		string[][] materials = coreFactory.getAllPurchasedMaterials(prod, int.Parse(seq.ToString()));
		for(int z = 0; z < materials.Length; z++){
			SchMatReqDayDataBase schMatReqDayDataBase = 
				schMatReqDayDataBaseContainer.getRecord(schVersionDataBase.getSCH_Version(), 
					plant, dept, prod, int.Parse(seq.ToString()), materials[z][0], 
					int.Parse(materials[z][1]), start);

			if (schMatReqDayDataBase == null){
				Inventory inventory = coreFactory.readInventory(materials[z][0]);
				schMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);
				schMatReqDayDataBase.setSMD_SchVersion(schVersion);
				schMatReqDayDataBase.setSMD_Plt(plant);
				schMatReqDayDataBase.setSMD_Dept(dept);
				schMatReqDayDataBase.setSMD_ProdID(prod);
				schMatReqDayDataBase.setSMD_ProdSeq(int.Parse(seq.ToString()));
				schMatReqDayDataBase.setSMD_MatID(materials[z][0]);
				schMatReqDayDataBase.setSMD_MatSeq(int.Parse(materials[z][1]));
				schMatReqDayDataBase.setSMD_MatReqDate(start);
				schMatReqDayDataBase.setSMD_MatUom("");
				schMatReqDayDataBase.setSMD_Usage("S");
				schMatReqDayDataBase.setSMD_InvQty(inventory.getTotalInventory(int.Parse(materials[z][1])));
				schMatReqDayDataBase.setSMD_POQty(0);
				schMatReqDayDataBase.setSMD_DemMatReq(0);
				schMatReqDayDataBase.setSMD_SchMatReq(qty * decimal.Parse(materials[z][2]));
				schMatReqDayDataBase.setSMD_Factor(decimal.Parse(materials[z][2]));
				schMatReqDayDataBaseContainer.Add(schMatReqDayDataBase);
			}else{
				decimal req = schMatReqDayDataBase.getSMD_SchMatReq() + (qty * decimal.Parse(materials[z][2]));
				schMatReqDayDataBase.setSMD_SchMatReq(req);
				schMatReqDayDataBase.setSMD_Factor(decimal.Parse(materials[z][2]));
			}
		}
	}
}

public 
string[][] getProdPackDtlInfo(string prodId){
	ArrayList lst = new ArrayList();
	for(IEnumerator en = prodPackDtlDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		ProdPackDtlDataBase prodPackDtlDataBase = (ProdPackDtlDataBase) en.Current;

		if (prodPackDtlDataBase.getPCK_ProdID().Equals(prodId))
			lst.Add(prodPackDtlDataBase);
	}

	string[][] returnArray = new string[lst.Count][];
	int i = 0;

	for (IEnumerator en = lst.GetEnumerator(); en.MoveNext(); ){
      	ProdPackDtlDataBase prodPackDtlDataBase = (ProdPackDtlDataBase) en.Current;

		string[] lineArray = new string[10];
		lineArray[0] = prodPackDtlDataBase.getPCK_ShipToNum();
		lineArray[1] = prodPackDtlDataBase.getPCK_CustProdID();
		lineArray[2] = prodPackDtlDataBase.getPCK_Order().ToString();
		lineArray[3] = prodPackDtlDataBase.getPCK_OrderItem().ToString();
		lineArray[4] = prodPackDtlDataBase.getPCK_Qty().ToString();
		lineArray[5] = prodPackDtlDataBase.getPCK_CtrQty().ToString();
					
		returnArray[i] = lineArray;
		i++;
	}
	return returnArray;
}


public
void addProdPackDtlItems(string prodId, string[][] vec){
	deleteProdPackDtlInfo(prodId);
	
	DataBaseAccess dataBaseAccess = prodPackDtlDataBaseContainer.getDataBaseAccess();
	
	for(int i = 0; i < vec.Length; i++){
		string shipToNum = vec[i][0];
		string custProdId = vec[i][1];
		decimal order = decimal.Parse(vec[i][2]);
		decimal orderItem  = decimal.Parse(vec[i][3]);
        decimal qty = decimal.Parse(vec[i][4]);
        decimal ctrQty = decimal.Parse(vec[i][5]);
		
		ProdPackDtlDataBase prodPackDtlDataBase = new ProdPackDtlDataBase(dataBaseAccess);
		prodPackDtlDataBase.setPCK_SchVersion(schVersion);
		prodPackDtlDataBase.setPCK_Plt(plant);
        prodPackDtlDataBase.setPCK_Dept("");
        prodPackDtlDataBase.setPCK_ProdID(prodId);
		prodPackDtlDataBase.setPCK_ShipToNum(shipToNum);
        prodPackDtlDataBase.setPCK_CustProdID(custProdId);
        prodPackDtlDataBase.setPCK_Order(order);
        prodPackDtlDataBase.setPCK_OrderItem(orderItem);
        prodPackDtlDataBase.setPCK_Qty(qty);
        prodPackDtlDataBase.setPCK_CtrQty(ctrQty);

		prodPackDtlDataBaseContainer.Add(prodPackDtlDataBase);

	}
}

private
void deleteProdPackDtlInfo(string prodId){
	ProdPackDtlDataBaseContainer aux = new ProdPackDtlDataBaseContainer(prodPackDtlDataBaseContainer.getDataBaseAccess());

	for (IEnumerator en = prodPackDtlDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		ProdPackDtlDataBase prodPackDtlDataBase = (ProdPackDtlDataBase) en.Current;

		if (!prodPackDtlDataBase.getPCK_ProdID().Trim().Equals(prodId.Trim()))
			aux.Add(prodPackDtlDataBase);
	}

	this.prodPackDtlDataBaseContainer.Clear();
	this.prodPackDtlDataBaseContainer = aux;
}

} // Scheduling class

} // namespace