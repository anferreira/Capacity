using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class HotListCoreFactory : GroupDiscCoreFactory{

protected
HotListCoreFactory() : base(){
}

public
void createHotList(string[] stkbFilter, string[] wipbFilter, string[][] badWipb){
    try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.read(); 

		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.read(); 

		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
	    prodFmActPlanDataBaseContainer.read(); 

	    blockHotList();
    	
	    // inventory

#if !DEBUG
		badWipb = generateCMSInventory(stkbFilter, wipbFilter, prodFmInfoDataBaseContainer);
#endif

//	    badWipb = new string[0][];
//      cmsTempToNujitInventory(stkbFilter, wipbFilter, prodFmInfoDataBaseContainer);

	    // hot list
	    generateHotlist(prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer,
			prodFmActPlanDataBaseContainer);

	    // hot list bom
	    generateHotListBom(prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer,
				prodFmActPlanDataBaseContainer);

	    unBlockHotList();

    //	System.Console.WriteLine("End : " + DateTime.Now);
   }catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

public
void generateHotlist(ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer, 
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		InvPltLocDataBaseContainer invPltLocDataBaseContainer = 
			new InvPltLocDataBaseContainer(dataBaseAccess);
		invPltLocDataBaseContainer.readForHotList();

		DemDetailDataBaseContainer allDemDetailDataBaseContainer = 
			new DemDetailDataBaseContainer(dataBaseAccess);
		allDemDetailDataBaseContainer.readActives(); 

		HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
		hotListHdrDataBase.setHLR_HotlistRunDate(DateTime.Now);
		hotListHdrDataBase.setHLR_HotlistExpDate(DateUtil.MinValue);
		hotListHdrDataBase.write();

		HotListDataBaseContainer hotListDataBaseContainer = 
			generateHotlist(invPltLocDataBaseContainer, allDemDetailDataBaseContainer, "Y",
				prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, 
				prodFmActPlanDataBaseContainer, "N");

		for(int i = 0; i < hotListDataBaseContainer.Count; i++){
			HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
			hotListDataBase.setHOT_Id(hotListHdrDataBase.getId());
		}
		
		hotListDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
HotListDataBaseContainer generateHotlist(InvPltLocDataBaseContainer invPltLocDataBaseContainer,
		DemDetailDataBaseContainer allDemDetailDataBaseContainer, string finalizedPart,
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer, 
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer,
		string hotListType){
	
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory(UtilCoreFactory.LOCAL);

	// record to write to database
	HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);

	DemDetailDataBaseContainer definitiveDemDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);

	Hashtable control = new Hashtable();
	// filter for prod, act, seq
	for(IEnumerator en1 = allDemDetailDataBaseContainer.GetEnumerator(); en1.MoveNext(); ){
		DemDetailDataBase demDetailDataBase1 = (DemDetailDataBase) en1.Current;

		/*if (demDetailDataBase1.getDEDT_ProdID().Equals("GM25897222")){
			string c = "";
		}*/

		ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(demDetailDataBase1.getDEDT_ProdID());
		if (!demDetailDataBase1.isGenerated()){ // lead times
			ProdFmActPlanDataBase prodFmActPlanDataBase = 
					prodFmActPlanDataBaseContainer.getProdFmActPlan(demDetailDataBase1.getDEDT_ProdID(), demDetailDataBase1.getDEDT_Seq());
			if (prodFmActPlanDataBase == null){
				prodFmActPlanDataBase = new ProdFmActPlanDataBase(this.dataBaseAccess);
				prodFmActPlanDataBase.setPAPL_ProdID(demDetailDataBase1.getDEDT_ProdID());
				prodFmActPlanDataBase.setPAPL_Seq(demDetailDataBase1.getDEDT_Seq());
				prodFmActPlanDataBase.read();
			}

			decimal PAPL_DayLTCum = prodFmActPlanDataBase.getPAPL_DayLTCum();

			if (PAPL_DayLTCum != 0){
				bool excludeSats = false;
				if (prodFmActPlanDataBase.getPAPL_ExcludeSats().Equals("Y"))
					excludeSats = true;
				bool excludeSuns = false;
				if (prodFmActPlanDataBase.getPAPL_ExcludeSuns().Equals("Y"))
					excludeSuns = true;
					
				DateTime newDemandDate = DateUtil.subtractDaysExcludeSatandSun(demDetailDataBase1.getDEDT_DtShip(), 
					double.Parse(PAPL_DayLTCum.ToString()), excludeSats, excludeSuns);
						//demDetailDataBase1.getDEDT_DtShip().AddDays((-1) * double.Parse(PAPL_DayLTCum.ToString()));
				demDetailDataBase1.setDEDT_DtShip(newDemandDate);
			}
		}
		
		string key1 = demDetailDataBase1.getDEDT_ProdID().Trim() + "-" +
			demDetailDataBase1.getDEDT_ActID() + "-" +
			demDetailDataBase1.getDEDT_Seq().ToString();

		if (!control.ContainsKey(key1)){
			definitiveDemDetailDataBaseContainer.Add(demDetailDataBase1);
			control.Add(key1, key1);
		}
	}

	// definitive loop
	for(IEnumerator en2 = definitiveDemDetailDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
		DemDetailDataBase demDetailDataBase2 = (DemDetailDataBase) en2.Current;

		HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
		hotListDataBase.setHOT_Uom("");
		hotListDataBase.setHOT_Qoh(0);
		hotListDataBase.setHOT_QohCml(0); // acumulative stock
		hotListDataBase.setHOT_Finalized(finalizedPart);
		hotListDataBase.setHOT_Type(hotListType);

		ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(demDetailDataBase2.getDEDT_ProdID());
		if (prodFmInfoDataBase != null){
			if ( (demDetailDataBase2.getDEDT_Seq() != prodFmInfoDataBase.getPFS_SeqLast()) || 
					((!prodFmInfoDataBase.getPFS_GLExp().Equals("FGD")) &&
						(!prodFmInfoDataBase.getPFS_GLExp().Equals("FG")) &&
						(!prodFmInfoDataBase.getPFS_GLExp().Equals("FG1")) 
				) ){
				
				hotListDataBase.setHOT_Finalized("N"); // mark as wip
			}else{
				hotListDataBase.setHOT_Finalized("Y"); // mark as finished
			}
		}else{
			hotListDataBase.setHOT_Finalized("N"); // mark as wip
		}

		bool present = false;
		int init = invPltLocDataBaseContainer.getFirstElementPosition(demDetailDataBase2.getDEDT_ProdID());

		for(; (init > -1) && (init < invPltLocDataBaseContainer.Count); init++){
			InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase)invPltLocDataBaseContainer[init];
			
			/*if (invPltLocDataBase.getIPL_ProdID().Equals("WIP-25897222")){
				string a = "";
			}

			if (invPltLocDataBase.getIPL_ProdID().Equals("SUB10A-RH")){
				string b = "";
			}*/

			if (invPltLocDataBase.getIPL_ProdID().Equals(demDetailDataBase2.getDEDT_ProdID())){
				hotListDataBase.setHOT_ProdID(demDetailDataBase2.getDEDT_ProdID());
				hotListDataBase.setHOT_ActID(demDetailDataBase2.getDEDT_ActID());
				hotListDataBase.setHOT_Seq(demDetailDataBase2.getDEDT_Seq());
				hotListDataBase.setHOT_Dept(demDetailDataBase2.getDepartamentCode());
				
				hotListDataBase.setHOT_Dept("");
				hotListDataBase.setHOT_Mach("");
				hotListDataBase.setHOT_MachCyc(0);

				if (invPltLocDataBase.getIPL_Seq() == demDetailDataBase2.getDEDT_Seq()){
					hotListDataBase.setHOT_Uom(invPltLocDataBase.getIPL_Uom());
					hotListDataBase.setHOT_Qoh(invPltLocDataBase.getIPL_Qoh());
 
					ProdFmActPlanDataBase prodFmActPlanDataBase = 
							prodFmActPlanDataBaseContainer.getProdFmActPlan(hotListDataBase.getHOT_ProdID(), hotListDataBase.getHOT_Seq());
					if (prodFmActPlanDataBase == null){
						prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
						prodFmActPlanDataBase.setPAPL_ProdID(hotListDataBase.getHOT_ProdID());
						prodFmActPlanDataBase.setPAPL_Seq(hotListDataBase.getHOT_Seq()); //????
						prodFmActPlanDataBase.read();
					}

					decimal minInvCum = prodFmActPlanDataBase.getMinInvCum();
					
					// minimum inventory
					if (minInvCum < invPltLocDataBase.getIPL_Qoh2())
						hotListDataBase.setHOT_QohCml(invPltLocDataBase.getIPL_Qoh2() - 
							minInvCum); // cumulative qoh
					else
						hotListDataBase.setHOT_QohCml(0); // cumulative qoh
				}
				
				present = true;
			}else
				break;
		}

		if (!present){
			hotListDataBase.setHOT_ProdID(demDetailDataBase2.getDEDT_ProdID());
			hotListDataBase.setHOT_ActID(demDetailDataBase2.getDEDT_ActID());
			hotListDataBase.setHOT_Seq(demDetailDataBase2.getDEDT_Seq());
			hotListDataBase.setHOT_Qoh(0);
			hotListDataBase.setHOT_Dept(demDetailDataBase2.getDepartamentCode());
			hotListDataBase.setHOT_QohCml(0); // acumulative stock
		}

		DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);
		demDetailDataBaseContainer = allDemDetailDataBaseContainer.getByProd(demDetailDataBase2.getDEDT_ProdID());

		decimal[] quantity = new decimal[90];
		for(int i = 0; i < quantity.Length; i++)
			quantity[i] = 0;
		decimal pastDue = 0;

		DateTime today = DateTime.Today;

		for(IEnumerator en = demDetailDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DemDetailDataBase demDetailDataBase = (DemDetailDataBase) en.Current;
			DateTime dtShip = demDetailDataBase.getDEDT_DtShip();

			if (dtShip.CompareTo(today) >= 0){ // dtship >= today, entrega futura
				TimeSpan timeSpan = dtShip.Subtract(today);
				int offset = timeSpan.Days;
				
				if ((offset > -1) && (offset < 90)){ // 0 - 89 
					if (hotListDataBase.getHOT_Seq() == demDetailDataBase.getDEDT_Seq())
						quantity[offset] += demDetailDataBase.getDEDT_QtyID();
				}
			}else{ // dtship <= today, entrega atrasada
				if (hotListDataBase.getHOT_Seq() == demDetailDataBase.getDEDT_Seq())
					pastDue += demDetailDataBase.getDEDT_QtyID();
			}
		}

		pastDue = (pastDue * -1) + hotListDataBase.getHOT_QohCml();
		if (pastDue > 0)
			hotListDataBase.setHOT_PastDue(0);
		else
			hotListDataBase.setHOT_PastDue(pastDue);

		for(int index = 0; index < 90; index++){
			decimal hota = 0;
			for(int x = 0; x <= index; x++){
				hota += quantity[x];
			}

			int day = index + 1;
			hota = hota * -1;

			decimal dayMount = pastDue + hota;
			if (dayMount > 0)
				dayMount = 0;

			switch(day){
			case 1:
				hotListDataBase.setHOT_Day001(dayMount);
				break;
			case 2:
				hotListDataBase.setHOT_Day002(dayMount);
				break;
			case 3:
				hotListDataBase.setHOT_Day003(dayMount);
				break;
			case 4:
				hotListDataBase.setHOT_Day004(dayMount);
				break;
			case 5:
				hotListDataBase.setHOT_Day005(dayMount);
				break;
			case 6:
				hotListDataBase.setHOT_Day006(dayMount);
				break;
			case 7:
				hotListDataBase.setHOT_Day007(dayMount);
				break;
			case 8:
				hotListDataBase.setHOT_Day008(dayMount);
				break;
			case 9:
				hotListDataBase.setHOT_Day009(dayMount);
				break;
			case 10:
				hotListDataBase.setHOT_Day010(dayMount);
				break;
			case 11:
				hotListDataBase.setHOT_Day011(dayMount);
				break;
			case 12:
				hotListDataBase.setHOT_Day012(dayMount);
				break;
			case 13:
				hotListDataBase.setHOT_Day013(dayMount);
				break;
			case 14:
				hotListDataBase.setHOT_Day014(dayMount);
				break;
			case 15:
				hotListDataBase.setHOT_Day015(dayMount);
				break;
			case 16:
				hotListDataBase.setHOT_Day016(dayMount);
				break;
			case 17:
				hotListDataBase.setHOT_Day017(dayMount);
				break;
			case 18:
				hotListDataBase.setHOT_Day018(dayMount);
				break;
			case 19:
				hotListDataBase.setHOT_Day019(dayMount);
				break;
			case 20:
				hotListDataBase.setHOT_Day020(dayMount);
				break;
			case 21:
				hotListDataBase.setHOT_Day021(dayMount);
				break;
			case 22:
				hotListDataBase.setHOT_Day022(dayMount);
				break;
			case 23:
				hotListDataBase.setHOT_Day023(dayMount);
				break;
			case 24:
				hotListDataBase.setHOT_Day024(dayMount);
				break;
			case 25:
				hotListDataBase.setHOT_Day025(dayMount);
				break;
			case 26:
				hotListDataBase.setHOT_Day026(dayMount);
				break;
			case 27:
				hotListDataBase.setHOT_Day027(dayMount);
				break;
			case 28:
				hotListDataBase.setHOT_Day028(dayMount);
				break;
			case 29:
				hotListDataBase.setHOT_Day029(dayMount);
				break;
			case 30:
				hotListDataBase.setHOT_Day030(dayMount);
				break;
			case 31:
				hotListDataBase.setHOT_Day031(dayMount);
				break;
			case 32:
				hotListDataBase.setHOT_Day032(dayMount);
				break;
			case 33:
				hotListDataBase.setHOT_Day033(dayMount);
				break;
			case 34:
				hotListDataBase.setHOT_Day034(dayMount);
				break;
			case 35:
				hotListDataBase.setHOT_Day035(dayMount);
				break;
			case 36:
				hotListDataBase.setHOT_Day036(dayMount);
				break;
			case 37:
				hotListDataBase.setHOT_Day037(dayMount);
				break;
			case 38:
				hotListDataBase.setHOT_Day038(dayMount);
				break;
			case 39:
				hotListDataBase.setHOT_Day039(dayMount);
				break;
			case 40:
				hotListDataBase.setHOT_Day040(dayMount);
				break;
			case 41:
				hotListDataBase.setHOT_Day041(dayMount);
				break;
			case 42:
				hotListDataBase.setHOT_Day042(dayMount);
				break;
			case 43:
				hotListDataBase.setHOT_Day043(dayMount);
				break;
			case 44:
				hotListDataBase.setHOT_Day044(dayMount);
				break;
			case 45:
				hotListDataBase.setHOT_Day045(dayMount);
				break;
			case 46:
				hotListDataBase.setHOT_Day046(dayMount);
				break;
			case 47:
				hotListDataBase.setHOT_Day047(dayMount);
				break;
			case 48:
				hotListDataBase.setHOT_Day048(dayMount);
				break;
			case 49:
				hotListDataBase.setHOT_Day049(dayMount);
				break;
			case 50:
				hotListDataBase.setHOT_Day050(dayMount);
				break;
			case 51:
				hotListDataBase.setHOT_Day051(dayMount);
				break;
			case 52:
				hotListDataBase.setHOT_Day052(dayMount);
				break;
			case 53:
				hotListDataBase.setHOT_Day053(dayMount);
				break;
			case 54:
				hotListDataBase.setHOT_Day054(dayMount);
				break;
			case 55:
				hotListDataBase.setHOT_Day055(dayMount);
				break;
			case 56:
				hotListDataBase.setHOT_Day056(dayMount);
				break;
			case 57:
				hotListDataBase.setHOT_Day057(dayMount);
				break;
			case 58:
				hotListDataBase.setHOT_Day058(dayMount);
				break;
			case 59:
				hotListDataBase.setHOT_Day059(dayMount);
				break;
			case 60:
				hotListDataBase.setHOT_Day060(dayMount);
				break;
			case 61:
				hotListDataBase.setHOT_Day061(dayMount);
				break;
			case 62:
				hotListDataBase.setHOT_Day062(dayMount);
				break;
			case 63:
				hotListDataBase.setHOT_Day063(dayMount);
				break;
			case 64:
				hotListDataBase.setHOT_Day064(dayMount);
				break;
			case 65:
				hotListDataBase.setHOT_Day065(dayMount);
				break;
			case 66:
				hotListDataBase.setHOT_Day066(dayMount);
				break;
			case 67:
				hotListDataBase.setHOT_Day067(dayMount);
				break;
			case 68:
				hotListDataBase.setHOT_Day068(dayMount);
				break;
			case 69:
				hotListDataBase.setHOT_Day069(dayMount);
				break;
			case 70:
				hotListDataBase.setHOT_Day070(dayMount);
				break;
			case 71:
				hotListDataBase.setHOT_Day071(dayMount);
				break;
			case 72:
				hotListDataBase.setHOT_Day072(dayMount);
				break;
			case 73:
				hotListDataBase.setHOT_Day073(dayMount);
				break;
			case 74:
				hotListDataBase.setHOT_Day074(dayMount);
				break;
			case 75:
				hotListDataBase.setHOT_Day075(dayMount);
				break;
			case 76:
				hotListDataBase.setHOT_Day076(dayMount);
				break;
			case 77:
				hotListDataBase.setHOT_Day077(dayMount);
				break;
			case 78:
				hotListDataBase.setHOT_Day078(dayMount);
				break;
			case 79:
				hotListDataBase.setHOT_Day079(dayMount);
				break;
			case 80:
				hotListDataBase.setHOT_Day080(dayMount);
				break;
			case 81:
				hotListDataBase.setHOT_Day081(dayMount);
				break;
			case 82:
				hotListDataBase.setHOT_Day082(dayMount);
				break;
			case 83:
				hotListDataBase.setHOT_Day083(dayMount);
				break;
			case 84:
				hotListDataBase.setHOT_Day084(dayMount);
				break;
			case 85:
				hotListDataBase.setHOT_Day085(dayMount);
				break;
			case 86:
				hotListDataBase.setHOT_Day086(dayMount);
				break;
			case 87:
				hotListDataBase.setHOT_Day087(dayMount);
				break;
			case 88:
				hotListDataBase.setHOT_Day088(dayMount);
				break;
			case 89:
				hotListDataBase.setHOT_Day089(dayMount);
				break;
			case 90:
				hotListDataBase.setHOT_Day090(dayMount);
				break;
			}
		}

		hotListDataBase.setHOT_MinorGroup(prodFmInfoDataBase.getPFS_MinorGroup());
		hotListDataBase.setHOT_MajorGroup(prodFmInfoDataBase.getPFS_MajorGroup());

		ProdFmActSubDataBase prodFmActSubDataBase = 
			prodFmActSubDataBaseContainer.getProdFmActSub(hotListDataBase.getHOT_ProdID().Trim(), 
					hotListDataBase.getHOT_Seq());
		
		if (prodFmActSubDataBase == null){
			prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
			prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
			prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
			if (prodFmActSubDataBase.exists()){
				prodFmActSubDataBase.read();
				hotListDataBase.setHOT_Mach(prodFmActSubDataBase.getPC_Cfg());
			}else{
				hotListDataBase.setHOT_Mach("");
			}
		}else{
			hotListDataBase.setHOT_Mach(prodFmActSubDataBase.getPC_Cfg());
		}
		
		ProdFmActPlanDataBase prodFmActPlanDataBaseMat = 
				prodFmActPlanDataBaseContainer.getProdFmActPlan(hotListDataBase.getHOT_ProdID(), hotListDataBase.getHOT_Seq());
		if (prodFmActPlanDataBaseMat == null){
			prodFmActPlanDataBaseMat = new ProdFmActPlanDataBase(this.dataBaseAccess);
			prodFmActPlanDataBaseMat.setPAPL_ProdID(hotListDataBase.getHOT_ProdID());
			prodFmActPlanDataBaseMat.setPAPL_Seq(hotListDataBase.getHOT_Seq());
		
			if (prodFmActPlanDataBaseMat.exists()){
				prodFmActPlanDataBaseMat.read();

				string mainMaterial = prodFmActPlanDataBaseMat.getPAPL_MainMaterial();
				int mainMaterialSeq = prodFmActPlanDataBaseMat.getPAPL_MainMatSeq();

				if (!mainMaterial.Equals("")){
					hotListDataBase.setHOT_MainMaterial(mainMaterial);
					hotListDataBase.setHOT_MainMaterialSeq(mainMaterialSeq);

					Inventory inventory = coreFactory.readInventory(mainMaterial);

//					hotListDataBase.setHOT_MainMaterialQoh(inventory.getTotalInventory(mainMaterialSeq));
					hotListDataBase.setHOT_MainMaterialQoh(inventory.getTotalInventory());
				}else{
					hotListDataBase.setHOT_MainMaterial("");
					hotListDataBase.setHOT_MainMaterialSeq(0);
					hotListDataBase.setHOT_MainMaterialQoh(0);
				}
			}else{
				hotListDataBase.setHOT_MainMaterial("");
				hotListDataBase.setHOT_MainMaterialSeq(0);
				hotListDataBase.setHOT_MainMaterialQoh(0);
			}
		}else{
			hotListDataBase.setHOT_MainMaterial(prodFmActPlanDataBaseMat.getPAPL_MainMaterial());
			hotListDataBase.setHOT_MainMaterialSeq(prodFmActPlanDataBaseMat.getPAPL_MainMatSeq());
			Inventory inventory = coreFactory.readInventory(prodFmActPlanDataBaseMat.getPAPL_MainMaterial());
//			hotListDataBase.setHOT_MainMaterialQoh(inventory.getTotalInventory(prodFmActPlanDataBaseMat.getPAPL_MainMatSeq()));
			hotListDataBase.setHOT_MainMaterialQoh(inventory.getTotalInventory());
		}

		if ((hotListDataBase.getHOT_Dept() == null) || (hotListDataBase.getHOT_Dept().Equals(""))){
			hotListDataBase.setHOT_Dept(prodFmActSubDataBase.getPC_Dept());
		}

		hotListDataBaseContainer.Add(hotListDataBase);
	}

	coreFactory = null;

	return hotListDataBaseContainer;
}

private
void generateHotListBom(ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,
			ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
			ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer){
	try{
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = 
			new InvPltLocDataBaseContainer(dataBaseAccess);
		invPltLocDataBaseContainer.readForHotList();

		DemDetailDataBaseContainer allDemDetailDataBaseContainer = 
			new DemDetailDataBaseContainer(dataBaseAccess);
		allDemDetailDataBaseContainer.readForBom(); // read all records into DemDetail for products with 
													// inventory and Bom def, ordered by product + ship date

		InventoryContainer inventoryContainer = new InventoryContainer();
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		//string plt = "DFT";
		string plt = Configuration.DftPlant;
		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);
		//		schMatReqDayDataBaseContainer.read();
		schMatReqDayDataBaseContainer.truncate();

		SchMatReqDayDataBaseContainer depuredSchMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);

		schMatReqDayDataBaseContainer = depuredSchMatReqDayDataBaseContainer;
		DemDetailDataBaseContainer demandToProccess = new DemDetailDataBaseContainer(dataBaseAccess);
		decimal remaining = 0;

		Bom bom = null;
		ArrayList bomContainer = new ArrayList();
		Hashtable inventoryTable = new Hashtable();

		CoreFactory coreFactory = UtilCoreFactory.createCoreFactory(UtilCoreFactory.LOCAL);
		for(IEnumerator en = allDemDetailDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DemDetailDataBase demDetailDataBase = (DemDetailDataBase)en.Current;

			/*if (demDetailDataBase.getDEDT_ProdID().Equals("GM25897222"))
			{
				string a = "";
			}*/

			decimal mult = 1;

			/*** GP BEGIN - El bomContainer se usa para hacer una sola vez el "makeBom" en la db. ***/

			bom = null;
			for(int iBom = 0; ((iBom < bomContainer.Count) && (bom == null)); iBom++){
				Bom bomSeek = (Bom)bomContainer[iBom];
				if (bomSeek.getProd().Equals(demDetailDataBase.getDEDT_ProdID()) &&
						bomSeek.getSeq() == demDetailDataBase.getDEDT_Seq()){
					bom = bomSeek;
				}
					
			}

			if (bom == null){
				bom = makeBom(demDetailDataBase.getDEDT_ProdID(), 
					demDetailDataBase.getDEDT_Seq(), prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer);
				bomContainer.Add(bom);
			}

			/*** GP END ***/

			string prod = demDetailDataBase.getDEDT_ProdID();
			int seq = demDetailDataBase.getDEDT_Seq();

			remaining = getHotListBomInventory(prod, seq, inventoryTable,
				invPltLocDataBaseContainer);

			decimal remainingToCall = 0;
			decimal demand = demDetailDataBase.getDEDT_QtyID();

			// mas inventario que demanda --> demanda del material = 0
			if (remaining > demand){ 
				remainingToCall = 0;
			}else{
				remainingToCall = demand - remaining;
				if (remainingToCall < 0)
					remainingToCall = 0;
			}

			remaining -= demand;
			if (remaining < 0)
				remaining = 0;

			updateHotListBomInventory(prod, seq, remaining, inventoryTable);

			if (remainingToCall > 0){
				demandToProccess = generateDemDetailBomRecursive(bom, mult, 
					demandToProccess, demDetailDataBase, plt, 
					bom.getDepartament(), schMatReqDayDataBaseContainer,
					demDetailDataBase.getDEDT_DtShip(), remainingToCall,
					prodFmActSubDataBaseContainer, inventoryContainer, coreFactory);
			}
		}

		coreFactory = null;

		SchDemDetailDataBaseContainer schDemDetailDataBaseContainer = new SchDemDetailDataBaseContainer(demandToProccess.getDataBaseAccess());
		for(int iDem = 0; iDem < demandToProccess.Count; iDem++){
			DemDetailDataBase demDetailTP = (DemDetailDataBase)demandToProccess[iDem];
			SchDemDetailDataBase schDemDetailDataBase = new SchDemDetailDataBase(demDetailTP);
			schDemDetailDataBaseContainer.Add(schDemDetailDataBase);
		}

		demandToProccess.Sort();

		HotListDataBaseContainer bomHotListDataBaseContainer = generateHotlist(invPltLocDataBaseContainer,
				demandToProccess, "N", prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer,
				prodFmActPlanDataBaseContainer, "B");
//AF
//		HotListHdrDataBaseContainer hotListHdrDataBaseContainer = new HotListHdrDataBaseContainer(dataBaseAccess);
//		hotListHdrDataBaseContainer.read();
//		HotListHdrDataBase hotListHdrDataBase = (HotListHdrDataBase)hotListHdrDataBaseContainer[hotListHdrDataBaseContainer.Count - 1];
		HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(this.dataBaseAccess);
		HotListDataBaseContainer normalHotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		normalHotListDataBaseContainer.readById(hotListHdrDataBase.readLastId());
		
		for(IEnumerator en1 = bomHotListDataBaseContainer.GetEnumerator(); en1.MoveNext(); ){
			HotListDataBase bomHotListDataBase = (HotListDataBase)en1.Current;

			bool isFound = false;
			for(IEnumerator en2 = normalHotListDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				HotListDataBase normalHotListDataBase = (HotListDataBase)en2.Current;
			
				if ((normalHotListDataBase.getHOT_ProdID().Equals(bomHotListDataBase.getHOT_ProdID())) &&
					(normalHotListDataBase.getHOT_Seq() == bomHotListDataBase.getHOT_Seq())){
				
					normalHotListDataBase.addData(bomHotListDataBase);
					isFound = true;
				}
			}

			if (!isFound){
				normalHotListDataBaseContainer.Add(bomHotListDataBase);
			}
		}

		schDemDetailDataBaseContainer.write();

		HotListHdrDataBaseContainer hotListHdrDataBaseContainer = new HotListHdrDataBaseContainer(dataBaseAccess);
		hotListHdrDataBaseContainer.read();
		hotListHdrDataBase = hotListHdrDataBaseContainer.getLast();

		hotListHdrDataBase.setHLR_HotlistExpDate(DateTime.Now);
		hotListHdrDataBase.update();

		HotListDataBaseContainer toTruncateHotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		toTruncateHotListDataBaseContainer.deleteById(hotListHdrDataBase.getId());

		for(int i = 0; i < normalHotListDataBaseContainer.Count; i++){
			HotListDataBase hotListDataBase = (HotListDataBase)normalHotListDataBaseContainer[i];
			hotListDataBase.setHOT_Id(hotListHdrDataBase.getId());
		}

		normalHotListDataBaseContainer.write();

		SchMatReqDayDataBaseContainer toDeleteSchMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);
		toDeleteSchMatReqDayDataBaseContainer.truncate();

		schMatReqDayDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getHotListAsString(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
		bool onlyDemand, string type){

	try{
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.read(id,filterDept, filterPart, filterMg, onlyDemand, type);

		string[][] returnArray = new string[hotListDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

			string[] lineArray = new string[106];
			lineArray[0] = hotListDataBase.getHOT_Dept();
			lineArray[1] = hotListDataBase.getHOT_MinorGroup();
			lineArray[2] = hotListDataBase.getHOT_MajorGroup();
			lineArray[3] = hotListDataBase.getHOT_Finalized();
			lineArray[4] = hotListDataBase.getHOT_ProdID();
			lineArray[5] = hotListDataBase.getHOT_Seq().ToString();
			lineArray[6] = hotListDataBase.getHOT_Uom();
			lineArray[7] = hotListDataBase.getHOT_Mach();
			lineArray[8] = hotListDataBase.getHOT_MachCyc().ToString();
			lineArray[9] = hotListDataBase.getHOT_Qoh().ToString();

			lineArray[10] = decimal.Floor(hotListDataBase.getHOT_QohCml()).ToString();
			lineArray[11] = hotListDataBase.getHOT_MainMaterial();
			lineArray[12] = hotListDataBase.getHOT_MainMaterialSeq().ToString();
			lineArray[13] = decimal.Floor(hotListDataBase.getHOT_MainMaterialQoh()).ToString();
			lineArray[14] = decimal.Floor(hotListDataBase.getHOT_PastDue()).ToString();
			lineArray[15] = decimal.Floor(hotListDataBase.getHOT_Day001()).ToString();
			lineArray[16] = decimal.Floor(hotListDataBase.getHOT_Day002()).ToString();
			lineArray[17] = decimal.Floor(hotListDataBase.getHOT_Day003()).ToString();
			lineArray[18] = decimal.Floor(hotListDataBase.getHOT_Day004()).ToString();
			lineArray[19] = decimal.Floor(hotListDataBase.getHOT_Day005()).ToString();

			lineArray[20] = decimal.Floor(hotListDataBase.getHOT_Day006()).ToString();
			lineArray[21] = decimal.Floor(hotListDataBase.getHOT_Day007()).ToString();
			lineArray[22] = decimal.Floor(hotListDataBase.getHOT_Day008()).ToString();
			lineArray[23] = decimal.Floor(hotListDataBase.getHOT_Day009()).ToString();
			lineArray[24] = decimal.Floor(hotListDataBase.getHOT_Day010()).ToString();
			lineArray[25] = decimal.Floor(hotListDataBase.getHOT_Day011()).ToString();
			lineArray[26] = decimal.Floor(hotListDataBase.getHOT_Day012()).ToString();
			lineArray[27] = decimal.Floor(hotListDataBase.getHOT_Day013()).ToString();
			lineArray[28] = decimal.Floor(hotListDataBase.getHOT_Day014()).ToString();
			lineArray[29] = decimal.Floor(hotListDataBase.getHOT_Day015()).ToString();

			lineArray[30] = decimal.Floor(hotListDataBase.getHOT_Day016()).ToString();
			lineArray[31] = decimal.Floor(hotListDataBase.getHOT_Day017()).ToString();
			lineArray[32] = decimal.Floor(hotListDataBase.getHOT_Day018()).ToString();
			lineArray[33] = decimal.Floor(hotListDataBase.getHOT_Day019()).ToString();
			lineArray[34] = decimal.Floor(hotListDataBase.getHOT_Day020()).ToString();
			lineArray[35] = decimal.Floor(hotListDataBase.getHOT_Day021()).ToString();
			lineArray[36] = decimal.Floor(hotListDataBase.getHOT_Day022()).ToString();
			lineArray[37] = decimal.Floor(hotListDataBase.getHOT_Day023()).ToString();
			lineArray[38] = decimal.Floor(hotListDataBase.getHOT_Day024()).ToString();
			lineArray[39] = decimal.Floor(hotListDataBase.getHOT_Day025()).ToString();

			lineArray[40] = decimal.Floor(hotListDataBase.getHOT_Day026()).ToString();
			lineArray[41] = decimal.Floor(hotListDataBase.getHOT_Day027()).ToString();
			lineArray[42] = decimal.Floor(hotListDataBase.getHOT_Day028()).ToString();
			lineArray[43] = decimal.Floor(hotListDataBase.getHOT_Day029()).ToString();
			lineArray[44] = decimal.Floor(hotListDataBase.getHOT_Day030()).ToString();
			lineArray[45] = decimal.Floor(hotListDataBase.getHOT_Day031()).ToString();
			lineArray[46] = decimal.Floor(hotListDataBase.getHOT_Day032()).ToString();
			lineArray[47] = decimal.Floor(hotListDataBase.getHOT_Day033()).ToString();
			lineArray[48] = decimal.Floor(hotListDataBase.getHOT_Day034()).ToString();
			lineArray[49] = decimal.Floor(hotListDataBase.getHOT_Day035()).ToString();

			lineArray[50] = decimal.Floor(hotListDataBase.getHOT_Day036()).ToString();
			lineArray[51] = decimal.Floor(hotListDataBase.getHOT_Day037()).ToString();
			lineArray[52] = decimal.Floor(hotListDataBase.getHOT_Day038()).ToString();
			lineArray[53] = decimal.Floor(hotListDataBase.getHOT_Day039()).ToString();
			lineArray[54] = decimal.Floor(hotListDataBase.getHOT_Day040()).ToString();
			lineArray[55] = decimal.Floor(hotListDataBase.getHOT_Day041()).ToString();
			lineArray[56] = decimal.Floor(hotListDataBase.getHOT_Day042()).ToString();
			lineArray[57] = decimal.Floor(hotListDataBase.getHOT_Day043()).ToString();
			lineArray[58] = decimal.Floor(hotListDataBase.getHOT_Day044()).ToString();
			lineArray[59] = decimal.Floor(hotListDataBase.getHOT_Day045()).ToString();
			
			lineArray[60] = decimal.Floor(hotListDataBase.getHOT_Day046()).ToString();
			lineArray[61] = decimal.Floor(hotListDataBase.getHOT_Day047()).ToString();
			lineArray[62] = decimal.Floor(hotListDataBase.getHOT_Day048()).ToString();
			lineArray[63] = decimal.Floor(hotListDataBase.getHOT_Day049()).ToString();
			lineArray[64] = decimal.Floor(hotListDataBase.getHOT_Day050()).ToString();
			lineArray[65] = decimal.Floor(hotListDataBase.getHOT_Day051()).ToString();
			lineArray[66] = decimal.Floor(hotListDataBase.getHOT_Day052()).ToString();
			lineArray[67] = decimal.Floor(hotListDataBase.getHOT_Day053()).ToString();
			lineArray[68] = decimal.Floor(hotListDataBase.getHOT_Day054()).ToString();
			lineArray[69] = decimal.Floor(hotListDataBase.getHOT_Day055()).ToString();

			lineArray[70] = decimal.Floor(hotListDataBase.getHOT_Day056()).ToString();
			lineArray[71] = decimal.Floor(hotListDataBase.getHOT_Day057()).ToString(); 
			lineArray[72] = decimal.Floor(hotListDataBase.getHOT_Day058()).ToString();
			lineArray[73] = decimal.Floor(hotListDataBase.getHOT_Day059()).ToString();
			lineArray[74] = decimal.Floor(hotListDataBase.getHOT_Day060()).ToString();
			lineArray[75] = decimal.Floor(hotListDataBase.getHOT_Day061()).ToString();
			lineArray[76] = decimal.Floor(hotListDataBase.getHOT_Day062()).ToString();
			lineArray[77] = decimal.Floor(hotListDataBase.getHOT_Day063()).ToString();
			lineArray[78] = decimal.Floor(hotListDataBase.getHOT_Day064()).ToString();
			lineArray[79] = decimal.Floor(hotListDataBase.getHOT_Day065()).ToString();

			lineArray[80] = decimal.Floor(hotListDataBase.getHOT_Day066()).ToString();
			lineArray[81] = decimal.Floor(hotListDataBase.getHOT_Day067()).ToString();
			lineArray[82] = decimal.Floor(hotListDataBase.getHOT_Day068()).ToString();
			lineArray[83] = decimal.Floor(hotListDataBase.getHOT_Day069()).ToString();
			lineArray[84] = decimal.Floor(hotListDataBase.getHOT_Day070()).ToString();
			lineArray[85] = decimal.Floor(hotListDataBase.getHOT_Day071()).ToString();
			lineArray[86] = decimal.Floor(hotListDataBase.getHOT_Day072()).ToString();
			lineArray[87] = decimal.Floor(hotListDataBase.getHOT_Day073()).ToString();
			lineArray[88] = decimal.Floor(hotListDataBase.getHOT_Day074()).ToString();
			lineArray[89] = decimal.Floor(hotListDataBase.getHOT_Day075()).ToString();

			lineArray[90] = decimal.Floor(hotListDataBase.getHOT_Day076()).ToString();
			lineArray[91] = decimal.Floor(hotListDataBase.getHOT_Day077()).ToString();
			lineArray[92] = decimal.Floor(hotListDataBase.getHOT_Day078()).ToString();
			lineArray[93] = decimal.Floor(hotListDataBase.getHOT_Day079()).ToString();
			lineArray[94] = decimal.Floor(hotListDataBase.getHOT_Day080()).ToString();
			lineArray[95] = decimal.Floor(hotListDataBase.getHOT_Day081()).ToString();
			lineArray[96] = decimal.Floor(hotListDataBase.getHOT_Day082()).ToString();
			lineArray[97] = decimal.Floor(hotListDataBase.getHOT_Day083()).ToString();
			lineArray[98] = decimal.Floor(hotListDataBase.getHOT_Day084()).ToString();
			lineArray[99] = decimal.Floor(hotListDataBase.getHOT_Day085()).ToString();

			lineArray[100] = decimal.Floor(hotListDataBase.getHOT_Day086()).ToString();
			lineArray[101] = decimal.Floor(hotListDataBase.getHOT_Day087()).ToString(); 
			lineArray[102] = decimal.Floor(hotListDataBase.getHOT_Day088()).ToString();
			lineArray[103] = decimal.Floor(hotListDataBase.getHOT_Day089()).ToString();
			lineArray[104] = decimal.Floor(hotListDataBase.getHOT_Day090()).ToString();
			//Version  of the hotlist.
			lineArray[105] = hotListDataBase.getHOT_Id().ToString();

			returnArray[i] = lineArray;
			i++;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getDemandAsString(string[] filterPart){
	try{
		DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);
		string[][] demand = demDetailDataBaseContainer.getDemandAsString(filterPart);

		CoreFactory coreFactory = UtilCoreFactory.createCoreFactory(UtilCoreFactory.LOCAL);

		string lastPart = "";
		decimal qoh = 0;
		for(int i = 0; i < demand.Length; i++){
			if (!demand[i][0].Equals(lastPart)){
				Inventory inventory = coreFactory.readInventory(demand[i][0]);
				qoh = inventory.getTotalInventory();
			}

			demand[i][3] = NumberUtil.toStringForReportMaterials(qoh);;
			lastPart = demand[i][0];
		}

		coreFactory = null;

		return demand;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(NujitException ne){
		throw new NujitException(ne.Message, ne);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getActiveDemandAsStringByDate(DateTime dateFrom, DateTime dateTo){
	try{
		DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);
	
		return demDetailDataBaseContainer.getDemandsAsStringByDate(dateFrom, dateTo, true);

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(NujitException ne){
		throw new NujitException(ne.Message, ne);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getDemandAsStringByDate(DateTime dateFrom, DateTime dateTo){
	try{
		DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);
	
		return demDetailDataBaseContainer.getDemandsAsStringByDate(dateFrom, dateTo, false);

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(NujitException ne){
		throw new NujitException(ne.Message, ne);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getHotListAsStringByDemand(bool onlyDemand){
	string[] filter = {};
	return getHotListAsString(0, filter, filter, filter, onlyDemand, "B");
}

// GP - Debería empezar por la última secuencia, calcular la diferencia entre la demanda y lo que hay 
// en el inventario (qoh) y eso pasarlo a sus componentes y secuencias anteriores. Ahora, empieza siempre
// por la primer secuencia y la diferencia se transfiere a los "hijos".

private
DemDetailDataBaseContainer generateDemDetailBomRecursive(Bom bom, decimal mult, 
		DemDetailDataBaseContainer demDetailDataBaseContainer, 
		DemDetailDataBase toCopy, string plt, string dept, 
		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer,
		DateTime fromDate, decimal remaining,
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
		InventoryContainer inventoryContainer, CoreFactory coreFactory){

	decimal remainingToCall = 0;
	decimal qohToCall = 0;

	// GP
	ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(toCopy.getDataBaseAccess());

	SchVersionDataBase schVersionDataBase = new SchVersionDataBase(toCopy.getDataBaseAccess());
	schVersionDataBase.setSCH_Plt(plt);
	schVersionDataBase.setSCH_Status("A");
	schVersionDataBase.readByPltActive();

	string schVersion = "";
	if (schVersionDataBase.getSCH_Version() != null)
		schVersion = schVersionDataBase.getSCH_Version();

	DemDetailDataBase demDetailDataBase = new DemDetailDataBase(toCopy);

	if (bom.getLevel() != 0){		
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(toCopy.getDataBaseAccess());
		prodFmActPlanDataBase.setPAPL_ProdID(bom.getProd());
		prodFmActPlanDataBase.setPAPL_Seq(bom.getSeq());

		prodFmActPlanDataBase.read();

		decimal PAPL_DayLT = prodFmActPlanDataBase.getPAPL_DayLT();
		decimal PAPL_HourLT = prodFmActPlanDataBase.getPAPL_HourLT();
		decimal PAPL_DayLTCum = prodFmActPlanDataBase.getPAPL_DayLTCum();
		decimal PAPL_HourLTCum = prodFmActPlanDataBase.getPAPL_HourLTCum();

		if (PAPL_DayLTCum != 0){
//			fromDate = fromDate.AddDays((-1) * double.Parse(PAPL_DayLTCum.ToString()));

			bool excludeSats = false;
			if (prodFmActPlanDataBase.getPAPL_ExcludeSats().Equals("Y"))
				excludeSats = true;
			bool excludeSuns = false;
			if (prodFmActPlanDataBase.getPAPL_ExcludeSuns().Equals("Y"))
				excludeSuns = true;
				
			fromDate = DateUtil.subtractDaysExcludeSatandSun(fromDate, 
				double.Parse(PAPL_DayLTCum.ToString()), excludeSats, excludeSuns);

		}

		if (!bom.isPurchased()){ // manufactured
			demDetailDataBase.setDEDT_DtShip(fromDate);

			demDetailDataBase.setDEDT_ProdID(bom.getProd());
			demDetailDataBase.setDEDT_ActID(bom.getAct());
			demDetailDataBase.setDEDT_Seq(bom.getSeq());

			demDetailDataBase.setDEDT_QtyID(remaining * mult);
			demDetailDataBase.setDepartamentCode(dept);
			demDetailDataBaseContainer.Add(demDetailDataBase);

			Inventory inventory = inventoryContainer.getInventory(bom.getProd());
			if (inventory == null){
				inventory = coreFactory.readInventory(bom.getProd());
				inventoryContainer.Add(inventory);
			}

			// GP - Si por algún motivo no se encuentra el registros, la última secuencia a usar es la 999.
			prodFmInfoDataBase.setPFS_ProdID(bom.getProd());
			prodFmInfoDataBase.setPFS_SeqLast(999);
			prodFmInfoDataBase.read();

			qohToCall = inventory.getTotalInventory(bom.getSeq());
			decimal tempRemaining = remaining;

			string[][] invPltLocContainer = inventory.getInvPltLocAsString();
			for(int index = 0; index < invPltLocContainer.Length; index++){
				decimal auxQoh = decimal.Parse(invPltLocContainer[index][6]);
				if (auxQoh > tempRemaining){
					auxQoh = auxQoh - tempRemaining;
					tempRemaining = 0;
				}else{
					tempRemaining -= auxQoh;
					auxQoh = 0;
				}

				// GP - Solo se tiene que actualizar el QOH que corresponde a la última secuencia.
				if (bom.getSeq() == prodFmInfoDataBase.getPFS_SeqLast())
					invPltLocContainer[index][6] = auxQoh.ToString();
			}

			inventory.setInvPltLocContainer(invPltLocContainer);

			if (remaining > qohToCall)
				qohToCall = 0;

			// GP - SIEMPRE se debe transferir al hijo el "remaining" del padre.
			remaining = tempRemaining;

		}else{ // purchased

			string prodId = toCopy.getDEDT_ProdID();
			int prodSeq = toCopy.getDEDT_Seq();
			string matProdId = bom.getProd();
			int matSeq = bom.getSeq();

			ProdFmActSubDataBase prodFmActSubDataBase = 
				prodFmActSubDataBaseContainer.getProdFmActSub(prodId, prodSeq);
			if (prodFmActSubDataBase == null){
				prodFmActSubDataBase = new ProdFmActSubDataBase(demDetailDataBase.getDataBaseAccess());
				prodFmActSubDataBase.setPC_ProdID(prodId);
				prodFmActSubDataBase.setPC_Seq(prodSeq);
				if (prodFmActSubDataBase.exists()){
					prodFmActSubDataBase.read();
					prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);
				}else{
					throw new NujitException("The part " + prodId + " Sec " + prodSeq.ToString() + " is not present in ProdFmActSub table");
				}
			}

			string matDept = prodFmActSubDataBase.getPC_Dept();
			
			SchMatReqDayDataBase schMatReqDayDataBase = 
				schMatReqDayDataBaseContainer.getAndAddRecord(schVersion, 
					plt, matDept, prodId, prodSeq, matProdId, matSeq, fromDate, "D");

			if (coreFactory.existsInventory(matProdId)){
				Inventory inventory = coreFactory.readInventory(matProdId);
				decimal qoh = inventory.getTotalInventory(0);

				schMatReqDayDataBase.setSMD_MatUom("");
				schMatReqDayDataBase.setSMD_InvQty(qoh);
				schMatReqDayDataBase.setSMD_POQty(0); //  po receipt
			}else{
				schMatReqDayDataBase.setSMD_MatUom("");
				schMatReqDayDataBase.setSMD_InvQty(0);
				schMatReqDayDataBase.setSMD_POQty(0); //  po receipt
			}

			schMatReqDayDataBase.setSMD_Factor(mult); // factor
			schMatReqDayDataBase.setSMD_DemMatReq(schMatReqDayDataBase.getSMD_DemMatReq() + remaining * mult); // dem mat qty from demand
		}
	}

	if (qohToCall > remaining)
		remainingToCall = 0;
	else
		remainingToCall = remaining - qohToCall;

	BomContainer bomContainer = bom.getBomContainer();
	for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		Bom bomAux = (Bom) en.Current;

		// GP: No debería pasar por este método si remainingToCall es igual a cero.

		demDetailDataBaseContainer = generateDemDetailBomRecursive(bomAux, 
			mult * bomAux.getQty(), demDetailDataBaseContainer, toCopy, plt,
			dept, schMatReqDayDataBaseContainer, fromDate, remainingToCall, 
			prodFmActSubDataBaseContainer, inventoryContainer, coreFactory);
	}

	return demDetailDataBaseContainer;
}

// GP: 06/12/2007 - ACA HAY QUE PASARLE LOS STOCK LOCATIONS QUE SE SELECCIONAN EN EL FILTRO Y TENERLOS EN
//					CUENTA CUANDO SE HACEN LAS CONSULTAS

public
string[][] getAllMatReqAsString(string[] depts, string[]parts ){
	SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer =
		new SchMatReqDayDataBaseContainer(dataBaseAccess);

	ArrayList array = schMatReqDayDataBaseContainer.readByPartDept(parts, depts);
	
	string[][] lines = new string[array.Count][];
	int x = 0;

	string lastMat = "";
	int lastSeq = 0;

	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory(UtilCoreFactory.LOCAL);
	Inventory inventory = null;
	decimal currentQty = 0;
	decimal currentDemand = 0;
	string initialInventory = "";

	for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		SchMatReqDayDataBase schMatReqDayDataBase = (SchMatReqDayDataBase)en.Current;

		string prod = schMatReqDayDataBase.getSMD_ProdID();
		string mat = schMatReqDayDataBase.getSMD_MatID();
		int seq = schMatReqDayDataBase.getSMD_MatSeq();
		
		if ((lastMat.Equals(mat)) && (seq == lastSeq)){
			currentQty -= schMatReqDayDataBase.getSMD_DemMatReq(); 
			currentDemand += (schMatReqDayDataBase.getSMD_DemMatReq() + schMatReqDayDataBase.getSMD_SchMatReq());
			initialInventory = "";
		}else{
			inventory = coreFactory.readInventory(mat);
			initialInventory = NumberUtil.toStringForReportMaterials(inventory.getTotalInventory());
			currentQty = inventory.getTotalInventory() - schMatReqDayDataBase.getSMD_DemMatReq();
			currentDemand = schMatReqDayDataBase.getSMD_DemMatReq() + schMatReqDayDataBase.getSMD_SchMatReq();
		}

		lastMat = mat;
		lastSeq = seq;

		string[] line = new string[19];
		line[0] = schMatReqDayDataBase.getSMD_SchVersion();
		line[1] = schMatReqDayDataBase.getSMD_Plt();
		line[2] = schMatReqDayDataBase.getSMD_Dept();
		line[3] = schMatReqDayDataBase.getSMD_ProdID();
		line[4] = schMatReqDayDataBase.getSMD_ProdSeq().ToString();
		line[5] = schMatReqDayDataBase.getSMD_MatID();
		line[6] = schMatReqDayDataBase.getSMD_MatSeq().ToString();
		line[7] = DateUtil.getDateRepresentation(schMatReqDayDataBase.getSMD_MatReqDate(), DateUtil.MMDDYYYY);
		line[8] = schMatReqDayDataBase.getSMD_MatUom();
		line[9] = schMatReqDayDataBase.getSMD_Usage();
		if (currentQty > 0) currentQty = currentQty * -1;
		line[10] = NumberUtil.toStringForReportMaterials(currentQty);
		line[11] = NumberUtil.toStringForReportMaterials(schMatReqDayDataBase.getSMD_POQty());
		decimal total = currentQty < 0 ? 0 - currentDemand : currentQty - currentDemand;
		if (total > 0) total = total * -1;
		line[12] = total.ToString("#,##0.00");
		line[13] = NumberUtil.toStringForReportMaterials(schMatReqDayDataBase.getSMD_SchMatReq());
		if (currentDemand > 0) currentDemand = currentDemand * -1;
		line[14] = NumberUtil.toStringForReportMaterials(currentDemand);
		line[15] = initialInventory;
		line[16] = schMatReqDayDataBase.getSMD_Factor().ToString("##0.##0");

		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer =
			new ProdFmInfoDataBaseContainer(dataBaseAccess);
		string description = prodFmInfoDataBaseContainer.readDescByProdId(schMatReqDayDataBase.getSMD_ProdID());

		line[17] = description;

		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer =
			new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		decimal leadTime = prodFmActPlanDataBaseContainer.readLeadTimeByProduct(schMatReqDayDataBase.getSMD_ProdID());

		line[18] = leadTime.ToString("#,##0.00");

		lines[x] = line;
		
		x++;
	}

	coreFactory = null;
	return lines;
}

public
void generateReleases(string startSupplier, string endSupplier,
		string startPart, string endPart){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SuppReleaseHdrDataBaseContainer suppReleaseHdrDataBaseContainer = new SuppReleaseHdrDataBaseContainer(dataBaseAccess);
		SuppReleaseDtlDataBaseContainer suppReleaseDtlDataBaseContainer = new SuppReleaseDtlDataBaseContainer(dataBaseAccess);

		suppReleaseHdrDataBaseContainer.truncate();
		suppReleaseDtlDataBaseContainer.truncate();

		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);
		schMatReqDayDataBaseContainer.readMaterials(startSupplier, endSupplier, startPart, endPart);

		for(IEnumerator en = schMatReqDayDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SchMatReqDayDataBase schMatReqDayDataBase = (SchMatReqDayDataBase)en.Current;
			
			string matId = schMatReqDayDataBase.getSMD_MatID();
			string refMatId = matId;
			int matSeq = schMatReqDayDataBase.getSMD_MatSeq();
			string plt = schMatReqDayDataBase.getSMD_Plt();
			DateTime date = schMatReqDayDataBase.getSMD_MatReqDate();
			decimal qty = schMatReqDayDataBase.getSMD_DemMatReq() + schMatReqDayDataBase.getSMD_SchMatReq();

			SuppProductCrossDataBase suppProductCrossDataBase = new SuppProductCrossDataBase(dataBaseAccess);
			suppProductCrossDataBase.setSP_SupplierNum("");
			suppProductCrossDataBase.setSP_ProdID(matId);
			suppProductCrossDataBase.setSP_Seq(matSeq);

			if (suppProductCrossDataBase.exists()){
				suppProductCrossDataBase.read();
				refMatId = suppProductCrossDataBase.getSP_SupplierPart();
			}

			SuppReleaseHdrDataBase suppReleaseHdrDataBase = suppReleaseHdrDataBaseContainer.getSuppReleaseHdrDataBase(matId, matSeq);
			if (suppReleaseHdrDataBase == null){
				suppReleaseHdrDataBase = new SuppReleaseHdrDataBase(dataBaseAccess);
				suppReleaseHdrDataBase.setSRH_Database("CMSDAT");
				suppReleaseHdrDataBase.setSRH_Plant(plt);
				//suppReleaseHdrDataBase.setSRH_SupplierNum();
				suppReleaseHdrDataBase.setSRH_ProdID(refMatId);
				suppReleaseHdrDataBase.setSRH_Seq(matSeq);
				//suppReleaseHdrDataBase.setSRH_ReleaseNum();
				//suppReleaseHdrDataBase.setSRH_TransRef();
				suppReleaseHdrDataBase.setSRH_Status("A");
				suppReleaseHdrDataBase.setSRH_DateCrt(date);
				suppReleaseHdrDataBase.setSRH_UserCrt("User");
				suppReleaseHdrDataBase.setSRH_DateSent(date);
				suppReleaseHdrDataBase.setSRH_UserSent("User");
				suppReleaseHdrDataBaseContainer.Add(suppReleaseHdrDataBase);
			}

			SuppReleaseDtlDataBase suppReleaseDtlDataBase = suppReleaseDtlDataBaseContainer.getSuppReleaseDtlDataBase(matId, matSeq, date);
			if (suppReleaseDtlDataBase == null){
				suppReleaseDtlDataBase = new SuppReleaseDtlDataBase(dataBaseAccess);
				suppReleaseDtlDataBase.setSP_Database("CMSDAT");
				suppReleaseDtlDataBase.setSP_ProdID(refMatId);
				suppReleaseDtlDataBase.setSP_Seq(matSeq);
				//suppReleaseDtlDataBase.setSP_TransRef();
				//suppReleaseDtlDataBase.setSP_PastDue();
				suppReleaseDtlDataBase.setSP_QtyNet(qty);
				suppReleaseDtlDataBase.setSP_QtyCum(qty);
				//suppReleaseDtlDataBase.setSP_Uom();
				suppReleaseDtlDataBase.setSP_Date(date);
				//suppReleaseDtlDataBase.setSP_AuthLevel();
				//suppReleaseDtlDataBase.setSP_ValidUntil();
				suppReleaseDtlDataBaseContainer.Add(suppReleaseDtlDataBase);
			}
		}

		for(IEnumerator en = suppReleaseHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SuppReleaseHdrDataBase suppReleaseHdrDataBase = (SuppReleaseHdrDataBase)en.Current;
			
			suppReleaseHdrDataBase.write();
			suppReleaseHdrDataBase.read();

			for(IEnumerator en2 = suppReleaseDtlDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				SuppReleaseDtlDataBase suppReleaseDtlDataBase = (SuppReleaseDtlDataBase)en2.Current;
				
				if ((suppReleaseDtlDataBase.getSP_ProdID().Equals(suppReleaseDtlDataBase.getSP_ProdID())) &&
						(suppReleaseDtlDataBase.getSP_Seq() == suppReleaseDtlDataBase.getSP_Seq())){

					suppReleaseDtlDataBase.setSP_ReleaseID(suppReleaseHdrDataBase.getID());
					suppReleaseDtlDataBase.write();
					
				}
			}
		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getReleasesAsString(string startSupplier, string endSupplier,
		string startPart, string endPart){
	try{
		SuppReleaseHdrDataBaseContainer suppReleaseHdrDataBaseContainer = new SuppReleaseHdrDataBaseContainer(dataBaseAccess);
		suppReleaseHdrDataBaseContainer.read();

		string[][] v = new string[suppReleaseHdrDataBaseContainer.Count][];
		int index = 0;

		for(IEnumerator en = suppReleaseHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SuppReleaseHdrDataBase suppReleaseHdrDataBase = (SuppReleaseHdrDataBase)en.Current;

			string[] line = new string[11];
			line[0] = suppReleaseHdrDataBase.getSRH_SupplierNum();
			line[1] = "";
			line[2] = suppReleaseHdrDataBase.getSRH_ProdID();
			line[3] = suppReleaseHdrDataBase.getSRH_Seq().ToString();
			line[4] = suppReleaseHdrDataBase.getSRH_ReleaseNum();
			line[5] = suppReleaseHdrDataBase.getSRH_DateCrt().ToShortDateString();
			line[6] = suppReleaseHdrDataBase.getSRH_DateSent().ToShortDateString();
			line[7] = ""; // upload erp
			line[8] = ""; // emailed
			line[9] = ""; // confirmed
			line[10] = ""; // schedule
			v[index] = line;
			index++;
		}
		return v;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getVendorReleaseInquiry(bool weeks){
	try{
		int days1 = 1;
		int days2 = 2;
		int days3 = 3;
		int days4 = 4;
		int days5 = 5;
		int days6 = 6;
		int days7 = 7;
		
		if (weeks){
			days1 = 7;
			days2 = 14;
			days3 = 21;
			days4 = 28;
			days5 = 35;
			days6 = 42;
			days7 = 49;
		}
		
		SuppReleaseDtlDataBaseContainer suppReleaseDtlDataBaseContainer = new SuppReleaseDtlDataBaseContainer(dataBaseAccess);
		suppReleaseDtlDataBaseContainer.read();

		VendorReleaseInquiryContainer vendorReleaseInquiryContainer = new VendorReleaseInquiryContainer();

		for(IEnumerator en = suppReleaseDtlDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SuppReleaseDtlDataBase suppReleaseDtlDataBase = (SuppReleaseDtlDataBase)en.Current;

			VendorReleaseInquiry vendorReleaseInquiry = 
				vendorReleaseInquiryContainer.getVendorReleaseInquiry(suppReleaseDtlDataBase.getSP_SupplierID(), suppReleaseDtlDataBase.getSP_ProdID(),
				suppReleaseDtlDataBase.getSP_Seq(), suppReleaseDtlDataBase.getSP_ReleaseNum());

			if (vendorReleaseInquiry == null){
				vendorReleaseInquiry = new VendorReleaseInquiry(suppReleaseDtlDataBase.getSP_SupplierID(), 
					suppReleaseDtlDataBase.getSP_ProdID(), suppReleaseDtlDataBase.getSP_Seq(), 
					"", suppReleaseDtlDataBase.getSP_ReleaseNum(), 0, 0, 0, 0, 0, 0, 0, 0);
				vendorReleaseInquiryContainer.Add(vendorReleaseInquiry);
			}

			if (suppReleaseDtlDataBase.getSP_Date().CompareTo(DateTime.Today) <= 0){
				vendorReleaseInquiry.setPastDue(vendorReleaseInquiry.getPastDue() + suppReleaseDtlDataBase.getSP_QtyCum());
			}else{
				TimeSpan timeSpan = suppReleaseDtlDataBase.getSP_Date().Subtract(DateTime.Today);
				int offset = timeSpan.Days;
				if (offset <= days1){
					vendorReleaseInquiry.setEnt1(vendorReleaseInquiry.getEnt1() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
				if (offset <= days2){
					vendorReleaseInquiry.setEnt2(vendorReleaseInquiry.getEnt2() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
				if (offset <= days3){
					vendorReleaseInquiry.setEnt3(vendorReleaseInquiry.getEnt3() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
				if (offset <= days4){
					vendorReleaseInquiry.setEnt4(vendorReleaseInquiry.getEnt4() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
				if (offset <= days5){
					vendorReleaseInquiry.setEnt5(vendorReleaseInquiry.getEnt5() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
				if (offset <= days6){
					vendorReleaseInquiry.setEnt6(vendorReleaseInquiry.getEnt6() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
				if (offset <= days7){
					vendorReleaseInquiry.setEnt7(vendorReleaseInquiry.getEnt7() + suppReleaseDtlDataBase.getSP_QtyCum());
					continue;
				}
			}
		}

		string[][] v = new string[vendorReleaseInquiryContainer.Count][];
		int index = 0;

		for(IEnumerator en = vendorReleaseInquiryContainer.GetEnumerator(); en.MoveNext(); ){
			VendorReleaseInquiry vendorReleaseInquiry = (VendorReleaseInquiry)en.Current;

			string[] line = new string[14];
			line[0] = vendorReleaseInquiry.getSupplier();
			line[1] = "";
			line[2] = vendorReleaseInquiry.getProduct();
			line[3] = vendorReleaseInquiry.getSeq().ToString();
			line[4] = vendorReleaseInquiry.getDescription();
			line[5] = vendorReleaseInquiry.getReleaseNum();
			line[6] = vendorReleaseInquiry.getPastDue().ToString();
			line[7] = vendorReleaseInquiry.getEnt1().ToString();
			line[8] = vendorReleaseInquiry.getEnt2().ToString();
			line[9] = vendorReleaseInquiry.getEnt3().ToString();
			line[10] = vendorReleaseInquiry.getEnt4().ToString();
			line[11] = vendorReleaseInquiry.getEnt5().ToString();
			line[12] = vendorReleaseInquiry.getEnt6().ToString();
			line[13] = vendorReleaseInquiry.getEnt7().ToString();
			
			v[index] = line;
			index++;
		}
		return v;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[] getAllPartFromHotListAsString(int id, bool inactive){
	try{
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readAllParts(id, inactive);
		
		string[] returnArray = new string[hotListDataBaseContainer.Count];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

			returnArray[i]= hotListDataBase.getHOT_ProdID();
			i++;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[] getAllMGFromHotListAsString(int id){
	try{
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readAllMG(id);
		
		string[] returnArray = new string[hotListDataBaseContainer.Count];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

			returnArray[i]= hotListDataBase.getHOT_MinorGroup();
			i++;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getHotListLogData(){
	try{
		HotListHdrDataBaseContainer hotListHdrDataBaseContainer = new HotListHdrDataBaseContainer(dataBaseAccess);
		hotListHdrDataBaseContainer.read();

		HotListHdrDataBase hotListHdrDataBase = hotListHdrDataBaseContainer.getLast();

		string[] v = new string[3];
		if (hotListHdrDataBase != null){
			v[0] = DateUtil.getCompleteDateRepresentation(hotListHdrDataBase.getHLR_HotlistRunDate(), DateUtil.MMDDYYYY);
			v[1] = DateUtil.getCompleteDateRepresentation(hotListHdrDataBase.getHLR_HotlistExpDate(), DateUtil.MMDDYYYY);
			v[2] = hotListHdrDataBase.getId().ToString();
		}else{
			v[0] = DateUtil.getCompleteDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY);
			v[1] = DateUtil.getCompleteDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY);
			v[2] = "0"; //hotListHdrDataBase.getId().ToString();
		}
		return v;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getHotListLogHist(){
	try{
		HotListHdrDataBaseContainer hotListHdrDataBaseContainer = new HotListHdrDataBaseContainer(dataBaseAccess);
		hotListHdrDataBaseContainer.read();

		string[][] v = new string[hotListHdrDataBaseContainer.Count][];
		for(int i = 0; i < hotListHdrDataBaseContainer.Count; i++){
			HotListHdrDataBase hotListHdrDataBase = (HotListHdrDataBase)hotListHdrDataBaseContainer[i];
			
			string[] line = new string[3];
			line[0] = hotListHdrDataBase.getId().ToString();
			line[1] = DateUtil.getCompleteDateRepresentation(hotListHdrDataBase.getHLR_HotlistRunDate(), DateUtil.MMDDYYYY);
			line[2] = DateUtil.getCompleteDateRepresentation(hotListHdrDataBase.getHLR_HotlistExpDate(), DateUtil.MMDDYYYY);
			v[i] = line;
		}
		return v;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getHotListReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
			bool onlyDemand, string type, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint,
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp){

	try{
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);

		if (byMinorGroup){
			hotListDataBaseContainer.readReportByMinGroup(id,filterDept, filterPart, filterMg, onlyDemand, type);
		}else{
			if (orderByResource){
				hotListDataBaseContainer.readReportByResource(id, filterDept, filterPart, filterMg, 
					onlyDemand, type);
			}else{
				if (orderByMajorMinorGrp){
					hotListDataBaseContainer.readReportByMajorMinorGroup(id, filterDept, filterPart, filterMg, onlyDemand, type);
				}else{
					hotListDataBaseContainer.readReport(id,filterDept, filterPart, filterMg, onlyDemand, type);
				}
			}
		}

		HotListDataBaseContainer depuredHotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		if (onlyReportingPoint){
			for(int i = 0; i < hotListDataBaseContainer.Count; i++){
				HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
				
				ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
				prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
				prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());

				if (prodFmActSubDataBase.existsWithSeq()){
					prodFmActSubDataBase.read();
				}else{
					prodFmActSubDataBase.setPC_RepPoint("N");
				}

				if (prodFmActSubDataBase.getPC_RepPoint().Equals("Y")){
					depuredHotListDataBaseContainer.Add(hotListDataBase);
				}
			}
		}else{
			if (hoursReport){
				for(int i = 0; i < hotListDataBaseContainer.Count; i++){
					HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
					
					ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
					prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
					prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
					prodFmActSubDataBase.read();

					decimal runStd = prodFmActSubDataBase.getPC_RunStd();
					if (runStd == 0)
						runStd = 1;
					hotListDataBase.setHOT_Qoh(hotListDataBase.getHOT_Qoh() / runStd);
					hotListDataBase.setHOT_QohCml(hotListDataBase.getHOT_QohCml() / runStd);
					hotListDataBase.setHOT_PastDue(hotListDataBase.getHOT_PastDue() / runStd);

					hotListDataBase.setHOT_Day001(hotListDataBase.getHOT_Day001() / runStd);
					hotListDataBase.setHOT_Day002(hotListDataBase.getHOT_Day002() / runStd);
					hotListDataBase.setHOT_Day003(hotListDataBase.getHOT_Day003() / runStd);
					hotListDataBase.setHOT_Day004(hotListDataBase.getHOT_Day004() / runStd);
					hotListDataBase.setHOT_Day005(hotListDataBase.getHOT_Day005() / runStd);
					hotListDataBase.setHOT_Day006(hotListDataBase.getHOT_Day006() / runStd);
					hotListDataBase.setHOT_Day007(hotListDataBase.getHOT_Day007() / runStd);
					hotListDataBase.setHOT_Day008(hotListDataBase.getHOT_Day008() / runStd);
					hotListDataBase.setHOT_Day009(hotListDataBase.getHOT_Day009() / runStd);
					hotListDataBase.setHOT_Day010(hotListDataBase.getHOT_Day010() / runStd);

					hotListDataBase.setHOT_Day011(hotListDataBase.getHOT_Day011() / runStd);
					hotListDataBase.setHOT_Day012(hotListDataBase.getHOT_Day012() / runStd);
					hotListDataBase.setHOT_Day013(hotListDataBase.getHOT_Day013() / runStd);
					hotListDataBase.setHOT_Day014(hotListDataBase.getHOT_Day014() / runStd);
					hotListDataBase.setHOT_Day015(hotListDataBase.getHOT_Day015() / runStd);
					hotListDataBase.setHOT_Day016(hotListDataBase.getHOT_Day016() / runStd);
					hotListDataBase.setHOT_Day017(hotListDataBase.getHOT_Day017() / runStd);
					hotListDataBase.setHOT_Day018(hotListDataBase.getHOT_Day018() / runStd);
					hotListDataBase.setHOT_Day019(hotListDataBase.getHOT_Day019() / runStd);
					hotListDataBase.setHOT_Day020(hotListDataBase.getHOT_Day020() / runStd);

					hotListDataBase.setHOT_Day021(hotListDataBase.getHOT_Day021() / runStd);
					hotListDataBase.setHOT_Day022(hotListDataBase.getHOT_Day022() / runStd);
					hotListDataBase.setHOT_Day023(hotListDataBase.getHOT_Day023() / runStd);
					hotListDataBase.setHOT_Day024(hotListDataBase.getHOT_Day024() / runStd);
					hotListDataBase.setHOT_Day025(hotListDataBase.getHOT_Day025() / runStd);
					hotListDataBase.setHOT_Day026(hotListDataBase.getHOT_Day026() / runStd);
					hotListDataBase.setHOT_Day027(hotListDataBase.getHOT_Day027() / runStd);
					hotListDataBase.setHOT_Day028(hotListDataBase.getHOT_Day028() / runStd);
					hotListDataBase.setHOT_Day029(hotListDataBase.getHOT_Day029() / runStd);
					hotListDataBase.setHOT_Day030(hotListDataBase.getHOT_Day030() / runStd);

					hotListDataBase.setHOT_Day031(hotListDataBase.getHOT_Day031() / runStd);
					hotListDataBase.setHOT_Day032(hotListDataBase.getHOT_Day032() / runStd);
					hotListDataBase.setHOT_Day033(hotListDataBase.getHOT_Day033() / runStd);
					hotListDataBase.setHOT_Day034(hotListDataBase.getHOT_Day034() / runStd);
					hotListDataBase.setHOT_Day035(hotListDataBase.getHOT_Day035() / runStd);
					hotListDataBase.setHOT_Day036(hotListDataBase.getHOT_Day036() / runStd);
					hotListDataBase.setHOT_Day037(hotListDataBase.getHOT_Day037() / runStd);
					hotListDataBase.setHOT_Day038(hotListDataBase.getHOT_Day038() / runStd);
					hotListDataBase.setHOT_Day039(hotListDataBase.getHOT_Day039() / runStd);
					hotListDataBase.setHOT_Day040(hotListDataBase.getHOT_Day040() / runStd);

					hotListDataBase.setHOT_Day041(hotListDataBase.getHOT_Day041() / runStd);
					hotListDataBase.setHOT_Day042(hotListDataBase.getHOT_Day042() / runStd);
					hotListDataBase.setHOT_Day043(hotListDataBase.getHOT_Day043() / runStd);
					hotListDataBase.setHOT_Day044(hotListDataBase.getHOT_Day044() / runStd);
					hotListDataBase.setHOT_Day045(hotListDataBase.getHOT_Day045() / runStd);
					hotListDataBase.setHOT_Day046(hotListDataBase.getHOT_Day046() / runStd);
					hotListDataBase.setHOT_Day047(hotListDataBase.getHOT_Day047() / runStd);
					hotListDataBase.setHOT_Day048(hotListDataBase.getHOT_Day048() / runStd);
					hotListDataBase.setHOT_Day049(hotListDataBase.getHOT_Day049() / runStd);
					hotListDataBase.setHOT_Day050(hotListDataBase.getHOT_Day050() / runStd);

					hotListDataBase.setHOT_Day051(hotListDataBase.getHOT_Day051() / runStd);
					hotListDataBase.setHOT_Day052(hotListDataBase.getHOT_Day052() / runStd);
					hotListDataBase.setHOT_Day053(hotListDataBase.getHOT_Day053() / runStd);
					hotListDataBase.setHOT_Day054(hotListDataBase.getHOT_Day054() / runStd);
					hotListDataBase.setHOT_Day055(hotListDataBase.getHOT_Day055() / runStd);
					hotListDataBase.setHOT_Day056(hotListDataBase.getHOT_Day056() / runStd);
					hotListDataBase.setHOT_Day057(hotListDataBase.getHOT_Day057() / runStd);
					hotListDataBase.setHOT_Day058(hotListDataBase.getHOT_Day058() / runStd);
					hotListDataBase.setHOT_Day059(hotListDataBase.getHOT_Day059() / runStd);
					hotListDataBase.setHOT_Day060(hotListDataBase.getHOT_Day060() / runStd);

					hotListDataBase.setHOT_Day061(hotListDataBase.getHOT_Day061() / runStd);
					hotListDataBase.setHOT_Day062(hotListDataBase.getHOT_Day062() / runStd);
					hotListDataBase.setHOT_Day063(hotListDataBase.getHOT_Day063() / runStd);
					hotListDataBase.setHOT_Day064(hotListDataBase.getHOT_Day064() / runStd);
					hotListDataBase.setHOT_Day065(hotListDataBase.getHOT_Day065() / runStd);
					hotListDataBase.setHOT_Day066(hotListDataBase.getHOT_Day066() / runStd);
					hotListDataBase.setHOT_Day067(hotListDataBase.getHOT_Day067() / runStd);
					hotListDataBase.setHOT_Day068(hotListDataBase.getHOT_Day068() / runStd);
					hotListDataBase.setHOT_Day069(hotListDataBase.getHOT_Day069() / runStd);
					hotListDataBase.setHOT_Day070(hotListDataBase.getHOT_Day070() / runStd);

					hotListDataBase.setHOT_Day071(hotListDataBase.getHOT_Day071() / runStd);
					hotListDataBase.setHOT_Day072(hotListDataBase.getHOT_Day072() / runStd);
					hotListDataBase.setHOT_Day073(hotListDataBase.getHOT_Day073() / runStd);
					hotListDataBase.setHOT_Day074(hotListDataBase.getHOT_Day074() / runStd);
					hotListDataBase.setHOT_Day075(hotListDataBase.getHOT_Day075() / runStd);
					hotListDataBase.setHOT_Day076(hotListDataBase.getHOT_Day076() / runStd);
					hotListDataBase.setHOT_Day077(hotListDataBase.getHOT_Day077() / runStd);
					hotListDataBase.setHOT_Day078(hotListDataBase.getHOT_Day078() / runStd);
					hotListDataBase.setHOT_Day079(hotListDataBase.getHOT_Day079() / runStd);
					hotListDataBase.setHOT_Day080(hotListDataBase.getHOT_Day080() / runStd);

					hotListDataBase.setHOT_Day081(hotListDataBase.getHOT_Day081() / runStd);
					hotListDataBase.setHOT_Day082(hotListDataBase.getHOT_Day082() / runStd);
					hotListDataBase.setHOT_Day083(hotListDataBase.getHOT_Day083() / runStd);
					hotListDataBase.setHOT_Day084(hotListDataBase.getHOT_Day084() / runStd);
					hotListDataBase.setHOT_Day085(hotListDataBase.getHOT_Day085() / runStd);
					hotListDataBase.setHOT_Day086(hotListDataBase.getHOT_Day086() / runStd);
					hotListDataBase.setHOT_Day087(hotListDataBase.getHOT_Day087() / runStd);
					hotListDataBase.setHOT_Day088(hotListDataBase.getHOT_Day088() / runStd);
					hotListDataBase.setHOT_Day089(hotListDataBase.getHOT_Day089() / runStd);
					hotListDataBase.setHOT_Day090(hotListDataBase.getHOT_Day090() / runStd);

					depuredHotListDataBaseContainer.Add(hotListDataBase);
				}
			}else{
				if (labourReport){
//Qty Required divided by piece/hr * (qty of Machines/# of Men) = total labour hours
					for(int i = 0; i < hotListDataBaseContainer.Count; i++){
						HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
						
						ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
						prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
						prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
						prodFmActSubDataBase.read();

						decimal runStd = prodFmActSubDataBase.getPC_RunStd();
						decimal menQty = prodFmActSubDataBase.getPC_QtyMen();
						decimal machQty = prodFmActSubDataBase.getPC_QtyMachines();

						if (runStd == 0)
							runStd = 1;
						if (menQty == 0)
							menQty = 1;
						if (machQty == 0){
							machQty = 1;
							menQty = 1;
						}

						hotListDataBase.setHOT_Qoh((hotListDataBase.getHOT_Qoh() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_QohCml((hotListDataBase.getHOT_QohCml() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_PastDue((hotListDataBase.getHOT_PastDue() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day001((hotListDataBase.getHOT_Day001() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day002((hotListDataBase.getHOT_Day002() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day003((hotListDataBase.getHOT_Day003() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day004((hotListDataBase.getHOT_Day004() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day005((hotListDataBase.getHOT_Day005() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day006((hotListDataBase.getHOT_Day006() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day007((hotListDataBase.getHOT_Day007() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day008((hotListDataBase.getHOT_Day008() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day009((hotListDataBase.getHOT_Day009() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day010((hotListDataBase.getHOT_Day010() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day011((hotListDataBase.getHOT_Day011() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day012((hotListDataBase.getHOT_Day012() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day013((hotListDataBase.getHOT_Day013() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day014((hotListDataBase.getHOT_Day014() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day015((hotListDataBase.getHOT_Day015() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day016((hotListDataBase.getHOT_Day016() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day017((hotListDataBase.getHOT_Day017() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day018((hotListDataBase.getHOT_Day018() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day019((hotListDataBase.getHOT_Day019() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day020((hotListDataBase.getHOT_Day020() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day021((hotListDataBase.getHOT_Day021() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day022((hotListDataBase.getHOT_Day022() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day023((hotListDataBase.getHOT_Day023() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day024((hotListDataBase.getHOT_Day024() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day025((hotListDataBase.getHOT_Day025() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day026((hotListDataBase.getHOT_Day026() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day027((hotListDataBase.getHOT_Day027() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day028((hotListDataBase.getHOT_Day028() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day029((hotListDataBase.getHOT_Day029() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day030((hotListDataBase.getHOT_Day030() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day031((hotListDataBase.getHOT_Day031() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day032((hotListDataBase.getHOT_Day032() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day033((hotListDataBase.getHOT_Day033() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day034((hotListDataBase.getHOT_Day034() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day035((hotListDataBase.getHOT_Day035() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day036((hotListDataBase.getHOT_Day036() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day037((hotListDataBase.getHOT_Day037() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day038((hotListDataBase.getHOT_Day038() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day039((hotListDataBase.getHOT_Day039() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day040((hotListDataBase.getHOT_Day040() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day041((hotListDataBase.getHOT_Day041() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day042((hotListDataBase.getHOT_Day042() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day043((hotListDataBase.getHOT_Day043() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day044((hotListDataBase.getHOT_Day044() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day045((hotListDataBase.getHOT_Day045() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day046((hotListDataBase.getHOT_Day046() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day047((hotListDataBase.getHOT_Day047() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day048((hotListDataBase.getHOT_Day048() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day049((hotListDataBase.getHOT_Day049() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day050((hotListDataBase.getHOT_Day050() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day051((hotListDataBase.getHOT_Day051() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day052((hotListDataBase.getHOT_Day052() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day053((hotListDataBase.getHOT_Day053() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day054((hotListDataBase.getHOT_Day054() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day055((hotListDataBase.getHOT_Day055() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day056((hotListDataBase.getHOT_Day056() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day057((hotListDataBase.getHOT_Day057() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day058((hotListDataBase.getHOT_Day058() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day059((hotListDataBase.getHOT_Day059() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day060((hotListDataBase.getHOT_Day060() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day061((hotListDataBase.getHOT_Day061() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day062((hotListDataBase.getHOT_Day062() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day063((hotListDataBase.getHOT_Day063() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day064((hotListDataBase.getHOT_Day064() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day065((hotListDataBase.getHOT_Day065() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day066((hotListDataBase.getHOT_Day066() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day067((hotListDataBase.getHOT_Day067() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day068((hotListDataBase.getHOT_Day068() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day069((hotListDataBase.getHOT_Day069() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day070((hotListDataBase.getHOT_Day070() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day071((hotListDataBase.getHOT_Day071() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day072((hotListDataBase.getHOT_Day072() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day073((hotListDataBase.getHOT_Day073() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day074((hotListDataBase.getHOT_Day074() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day075((hotListDataBase.getHOT_Day075() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day076((hotListDataBase.getHOT_Day076() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day077((hotListDataBase.getHOT_Day077() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day078((hotListDataBase.getHOT_Day078() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day079((hotListDataBase.getHOT_Day079() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day080((hotListDataBase.getHOT_Day080() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day081((hotListDataBase.getHOT_Day081() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day082((hotListDataBase.getHOT_Day082() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day083((hotListDataBase.getHOT_Day083() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day084((hotListDataBase.getHOT_Day084() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day085((hotListDataBase.getHOT_Day085() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day086((hotListDataBase.getHOT_Day086() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day087((hotListDataBase.getHOT_Day087() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day088((hotListDataBase.getHOT_Day088() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day089((hotListDataBase.getHOT_Day089() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day090((hotListDataBase.getHOT_Day090() / runStd) / (machQty / menQty));

						depuredHotListDataBaseContainer.Add(hotListDataBase);
					}
				}else{
					depuredHotListDataBaseContainer = hotListDataBaseContainer;
				}
			}
		}
		
		string[][] returnArray = new string[depuredHotListDataBaseContainer.Count][];

        if (accumOnFridays)
            specialAccum(returnArray, depuredHotListDataBaseContainer, hoursReport, labourReport);
        else
            communAccum(returnArray, depuredHotListDataBaseContainer, hoursReport, labourReport);
            
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


private 
ArrayList communAccum(string[][] returnArray, HotListDataBaseContainer hotListDataBaseContainer, 
			bool hoursReport, bool labourReport){
	int i = 0;
	dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
	MmgpDataBase mmgpDataBase = new MmgpDataBase(dataBaseAccess);

	ArrayList lst = new ArrayList();
	ArrayList returnArrayList = new ArrayList();

	for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

		string[] lineArray = new string[82];
		lineArray[0] = hotListDataBase.getHOT_ProdID();
		lineArray[1] = hotListDataBase.getHOT_ActID();
		lineArray[2] = hotListDataBase.getHOT_Seq().ToString();
		lineArray[3] = hotListDataBase.getHOT_Uom();
		lineArray[4] = hotListDataBase.getHOT_Dept();
		lineArray[5] = hotListDataBase.getHOT_Mach();
		lineArray[6] = hotListDataBase.getHOT_MachCyc().ToString();

		if (!hoursReport && !labourReport)
			lineArray[7] = (decimal.Floor(hotListDataBase.getHOT_Qoh())).ToString();
		else
			lineArray[7] = (decimal.Round(hotListDataBase.getHOT_Qoh(), 2)).ToString();
		
		if (!hoursReport && !labourReport)
			lineArray[8] = (decimal.Round(hotListDataBase.getHOT_QohCml(), 2)).ToString();
		else
			lineArray[8] = (decimal.Round(hotListDataBase.getHOT_QohCml(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[9] = (decimal.Floor(hotListDataBase.getHOT_PastDue())).ToString();
		else
			lineArray[9] = (decimal.Round(hotListDataBase.getHOT_PastDue(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
		else
			lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day001(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
		else
			lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day002(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
		else
			lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day003(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
		else
			lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day004(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
		else
			lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day005(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
		else
			lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day006(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
		else
			lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day007(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
		else
			lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day008(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
		else
			lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day009(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();
		else
			lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day010(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();
		else
			lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day011(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();
		else
			lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day012(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
		else
			lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day013(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
		else
			lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day014(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
		else
			lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day015(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[25] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();
		else
			lineArray[25] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[26] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
		else
			lineArray[26] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[27] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();
		else
			lineArray[27] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[28] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
		else
			lineArray[28] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[29] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
		else
			lineArray[29] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[30] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();
		else
			lineArray[30] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[31] = (decimal.Floor(hotListDataBase.getHOT_Day022())).ToString();
		else
			lineArray[31] = (decimal.Round(hotListDataBase.getHOT_Day022(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[32] = (decimal.Floor(hotListDataBase.getHOT_Day023())).ToString();
		else
			lineArray[32] = (decimal.Round(hotListDataBase.getHOT_Day023(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[33] = (decimal.Floor(hotListDataBase.getHOT_Day024())).ToString();
		else
			lineArray[33] = (decimal.Round(hotListDataBase.getHOT_Day024(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[34] = (decimal.Floor(hotListDataBase.getHOT_Day025())).ToString();
		else
			lineArray[34] = (decimal.Round(hotListDataBase.getHOT_Day025(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[35] = (decimal.Floor(hotListDataBase.getHOT_Day026())).ToString();
		else
			lineArray[35] = (decimal.Round(hotListDataBase.getHOT_Day026(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[36] = (decimal.Floor(hotListDataBase.getHOT_Day027())).ToString();
		else
			lineArray[36] = (decimal.Round(hotListDataBase.getHOT_Day027(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[37] = (decimal.Floor(hotListDataBase.getHOT_Day028())).ToString();
		else
			lineArray[37] = (decimal.Round(hotListDataBase.getHOT_Day028(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[38] = (decimal.Floor(hotListDataBase.getHOT_Day029())).ToString();
		else
			lineArray[38] = (decimal.Round(hotListDataBase.getHOT_Day029(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[39] = (decimal.Floor(hotListDataBase.getHOT_Day030())).ToString();
		else
			lineArray[39] = (decimal.Round(hotListDataBase.getHOT_Day030(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[40] = (decimal.Floor(hotListDataBase.getHOT_Day031())).ToString();
		else
			lineArray[40] = (decimal.Round(hotListDataBase.getHOT_Day031(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[41] = (decimal.Floor(hotListDataBase.getHOT_Day032())).ToString();
		else
			lineArray[41] = (decimal.Round(hotListDataBase.getHOT_Day032(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[42] = (decimal.Floor(hotListDataBase.getHOT_Day033())).ToString();
		else
			lineArray[42] = (decimal.Round(hotListDataBase.getHOT_Day033(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[43] = (decimal.Floor(hotListDataBase.getHOT_Day034())).ToString();
		else
			lineArray[43] = (decimal.Round(hotListDataBase.getHOT_Day034(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[44] = (decimal.Floor(hotListDataBase.getHOT_Day035())).ToString();
		else
			lineArray[44] = (decimal.Round(hotListDataBase.getHOT_Day035(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[45] = (decimal.Floor(hotListDataBase.getHOT_Day036())).ToString();
		else
			lineArray[45] = (decimal.Round(hotListDataBase.getHOT_Day036(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[46] = (decimal.Floor(hotListDataBase.getHOT_Day037())).ToString();
		else
			lineArray[46] = (decimal.Round(hotListDataBase.getHOT_Day037(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[47] = (decimal.Floor(hotListDataBase.getHOT_Day038())).ToString();
		else
			lineArray[47] = (decimal.Round(hotListDataBase.getHOT_Day038(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[48] = (decimal.Floor(hotListDataBase.getHOT_Day039())).ToString();
		else
			lineArray[48] = (decimal.Round(hotListDataBase.getHOT_Day039(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[49] = (decimal.Floor(hotListDataBase.getHOT_Day040())).ToString();
		else
			lineArray[49] = (decimal.Round(hotListDataBase.getHOT_Day040(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[50] = (decimal.Floor(hotListDataBase.getHOT_Day041())).ToString();
		else
			lineArray[50] = (decimal.Round(hotListDataBase.getHOT_Day041(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[51] = (decimal.Floor(hotListDataBase.getHOT_Day042())).ToString();
		else
			lineArray[51] = (decimal.Round(hotListDataBase.getHOT_Day042(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[52] = (decimal.Floor(hotListDataBase.getHOT_Day043())).ToString();
		else
			lineArray[52] = (decimal.Round(hotListDataBase.getHOT_Day043(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[53] = (decimal.Floor(hotListDataBase.getHOT_Day044())).ToString();
		else
			lineArray[53] = (decimal.Round(hotListDataBase.getHOT_Day044(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[54] = (decimal.Floor(hotListDataBase.getHOT_Day045())).ToString();
		else
			lineArray[54] = (decimal.Round(hotListDataBase.getHOT_Day045(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[55] = (decimal.Floor(hotListDataBase.getHOT_Day046())).ToString();
		else
			lineArray[55] = (decimal.Round(hotListDataBase.getHOT_Day046(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[56] = (decimal.Floor(hotListDataBase.getHOT_Day047())).ToString();
		else
			lineArray[56] = (decimal.Round(hotListDataBase.getHOT_Day047(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[57] = (decimal.Floor(hotListDataBase.getHOT_Day048())).ToString();
		else
			lineArray[57] = (decimal.Round(hotListDataBase.getHOT_Day048(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[58] = (decimal.Floor(hotListDataBase.getHOT_Day049())).ToString();
		else
			lineArray[58] = (decimal.Round(hotListDataBase.getHOT_Day049(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[59] = (decimal.Floor(hotListDataBase.getHOT_Day050())).ToString();
		else
			lineArray[59] = (decimal.Round(hotListDataBase.getHOT_Day050(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[60] = (decimal.Floor(hotListDataBase.getHOT_Day051())).ToString();
		else
			lineArray[60] = (decimal.Round(hotListDataBase.getHOT_Day051(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[61] = (decimal.Floor(hotListDataBase.getHOT_Day052())).ToString();
		else
			lineArray[61] = (decimal.Round(hotListDataBase.getHOT_Day052(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[62] = (decimal.Floor(hotListDataBase.getHOT_Day053())).ToString();
		else
			lineArray[62] = (decimal.Round(hotListDataBase.getHOT_Day053(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[63] = (decimal.Floor(hotListDataBase.getHOT_Day054())).ToString();
		else
			lineArray[63] = (decimal.Round(hotListDataBase.getHOT_Day054(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[64] = (decimal.Floor(hotListDataBase.getHOT_Day055())).ToString();
		else
			lineArray[64] = (decimal.Round(hotListDataBase.getHOT_Day055(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[65] = (decimal.Floor(hotListDataBase.getHOT_Day056())).ToString();
		else
			lineArray[65] = (decimal.Round(hotListDataBase.getHOT_Day056(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[66] = (decimal.Floor(hotListDataBase.getHOT_Day057())).ToString(); 
		else
			lineArray[66] = (decimal.Round(hotListDataBase.getHOT_Day057(), 2)).ToString(); 

		if (!hoursReport && !labourReport)
			lineArray[67] = (decimal.Floor(hotListDataBase.getHOT_Day058())).ToString();
		else
			lineArray[67] = (decimal.Round(hotListDataBase.getHOT_Day058(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[68] = (decimal.Floor(hotListDataBase.getHOT_Day059())).ToString();
		else
			lineArray[68] = (decimal.Round(hotListDataBase.getHOT_Day059(), 2)).ToString();

		if (!hoursReport && !labourReport)
			lineArray[69] = (decimal.Floor(hotListDataBase.getHOT_Day060())).ToString();
		else
			lineArray[69] = (decimal.Round(hotListDataBase.getHOT_Day060(), 2)).ToString();


		lineArray[70] = hotListDataBase.getHOT_MajorGroup();
		lineArray[71] = hotListDataBase.getHOT_MinorGroup();
		lineArray[72] = hotListDataBase.getHOT_Finalized();

		mmgpDataBase.setBRDES("");
		mmgpDataBase.setBRMGRP(hotListDataBase.getHOT_MinorGroup());
		mmgpDataBase.readByMinorGroup();

		lineArray[73] = mmgpDataBase.getBRDES();

		lineArray[74] = hotListDataBase.getHOT_MainMaterial();
		lineArray[75] = hotListDataBase.getHOT_MainMaterialSeq().ToString();
		lineArray[76] = (decimal.Floor(hotListDataBase.getHOT_MainMaterialQoh())).ToString();
		lineArray[77] = hotListDataBase.getHOT_MajorGroup() + "-" + hotListDataBase.getHOT_MinorGroup();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (hotListDataBase.getHOT_MainMaterial().Equals("")){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.setBMS_ProdID(hotListDataBase.getHOT_ProdID());
			bomSumDataBase.setBMS_Seq(hotListDataBase.getHOT_Seq());
			bomSumDataBase.setBMS_MatID(hotListDataBase.getHOT_MainMaterial());
			bomSumDataBase.setBMS_MatSeq(hotListDataBase.getHOT_Seq());
			if (bomSumDataBase.exists()){
				bomSumDataBase.read();

				lineArray[76] += " / " + (decimal.Floor(bomSumDataBase.getBMS_MatQty())).ToString();
			}
		}
		
		lineArray[78] = hotListDataBase.getHOT_Id().ToString();
	
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		pltDeptMachDataBase.setPDM_Dept(hotListDataBase.getHOT_Dept());
		pltDeptMachDataBase.setPDM_Mach(hotListDataBase.getHOT_Mach());
		if (pltDeptMachDataBase.existsByMach()){
			pltDeptMachDataBase.readByMach();
			lineArray[79] = pltDeptMachDataBase.getPDM_Des1();
		}
		lineArray[80] = hotListDataBase.getHOT_Level().ToString();

		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer =
			new ProdFmInfoDataBaseContainer(dataBaseAccess);
		string description = prodFmInfoDataBaseContainer.readDescByProdId(hotListDataBase.getHOT_ProdID());
		lineArray[81] = description.Length > 20 ? description.Substring(0, 20) : description;

		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		returnArray[i] = lineArray;
		returnArrayList.Add(lineArray);
		i++;
	}

	dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

	return returnArrayList;
}

private 
ArrayList specialAccum(string[][] returnArray, HotListDataBaseContainer hotListDataBaseContainer, 
			bool hoursReport, bool labourReport){
    int i = 0;
    int validCase = getValidOption();
    
	dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
	MmgpDataBase mmgpDataBase = new MmgpDataBase(dataBaseAccess);

	ArrayList lst = new ArrayList();
	ArrayList returnArrayList = new ArrayList();

	for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

		string[] lineArray = new string[82];
		lineArray[0] = hotListDataBase.getHOT_ProdID();
		lineArray[1] = hotListDataBase.getHOT_ActID();
		lineArray[2] = hotListDataBase.getHOT_Seq().ToString();
		lineArray[3] = hotListDataBase.getHOT_Uom();
		lineArray[4] = hotListDataBase.getHOT_Dept();
		lineArray[5] = hotListDataBase.getHOT_Mach();
		lineArray[6] = hotListDataBase.getHOT_MachCyc().ToString();

		if (!hoursReport && !labourReport)
			lineArray[7] = (decimal.Floor(hotListDataBase.getHOT_Qoh())).ToString();
		else
			lineArray[7] = decimal.Round(hotListDataBase.getHOT_Qoh(), 2).ToString();
			
		if (!hoursReport && !labourReport)
			lineArray[8] = (decimal.Floor(hotListDataBase.getHOT_QohCml())).ToString();
		else
			lineArray[8] = decimal.Round(hotListDataBase.getHOT_QohCml(), 2).ToString();
		
		if (!hoursReport && !labourReport)
			lineArray[9] = (decimal.Floor(hotListDataBase.getHOT_PastDue())).ToString();
		else
			lineArray[9] = decimal.Round(hotListDataBase.getHOT_PastDue(), 2).ToString();
		
		switch(validCase){
	    case 1: //Today = Monday
			if (!hoursReport && !labourReport)
				lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
			else
				lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day001(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day002(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day003(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day004(), 2)).ToString();
            //Friday we get the Sunday value
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day007(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
				lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
			else
				lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day008(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day009(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day010(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day011(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day014(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day015(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();		
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();		
		    break;
        case 2://Today = Tusday
			if (!hoursReport && !labourReport)
	            lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
			else
	            lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day001(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day002(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day003(), 2)).ToString();
            //Friday we get the Sunday value
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day006(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day007(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
			else
	            lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day008(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day009(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day010(), 2)).ToString();    
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day013(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day014(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day015(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();		
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();		

		    break;
        case 3: //Today = Wednesday
			if (!hoursReport && !labourReport)
	            lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
			else
	            lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day001(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day002(), 2)).ToString();
            //Friday we get the Sunday value
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day005(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day006(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day007(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
			else
	            lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day008(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day009(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day012(), 2)).ToString();    
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day013(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day014(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day015(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();    
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();		
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();		

		    break;
        case 4://Today = Thuesday
			if (!hoursReport && !labourReport)
	            lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
			else
	            lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day001(), 2)).ToString();
            //Friday we get the Sunday value
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day004(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day005(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day006(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day007(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
			else
	            lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day008(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day011(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day012(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day013(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day014(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day015(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();    
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();		
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();		
		    break;
        case 5: //Today = Friday
            //Friday we get the Sunday value
			if (!hoursReport && !labourReport)
	            lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
			else
	            lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day003(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day004(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day005(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day006(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day007(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();
			else
	            lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day010(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day011(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day012(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day013(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day014(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();	
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();	
		    break;
        case 6: //Today is Saturday
			if (!hoursReport && !labourReport)
	            lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
			else
	            lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day002(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day003(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day004(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day005(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day006(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
			else
	            lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day009(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day010(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day011(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day012(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day013(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();	
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();	
		    break;
        case 7: //Today is Sunday
			if (!hoursReport && !labourReport)
	            lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
			else
	            lineArray[10] = (decimal.Round(hotListDataBase.getHOT_Day001(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
			else
	            lineArray[11] = (decimal.Round(hotListDataBase.getHOT_Day002(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
			else
	            lineArray[12] = (decimal.Round(hotListDataBase.getHOT_Day003(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
			else
	            lineArray[13] = (decimal.Round(hotListDataBase.getHOT_Day004(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
			else
	            lineArray[14] = (decimal.Round(hotListDataBase.getHOT_Day005(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
			else
	            lineArray[15] = (decimal.Round(hotListDataBase.getHOT_Day008(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
			else
	            lineArray[16] = (decimal.Round(hotListDataBase.getHOT_Day009(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();    
			else
	            lineArray[17] = (decimal.Round(hotListDataBase.getHOT_Day010(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();
			else
	            lineArray[18] = (decimal.Round(hotListDataBase.getHOT_Day011(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();
			else
	            lineArray[19] = (decimal.Round(hotListDataBase.getHOT_Day012(), 2)).ToString();
            //Friday
			if (!hoursReport && !labourReport)
	            lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
			else
	            lineArray[20] = (decimal.Round(hotListDataBase.getHOT_Day015(), 2)).ToString();
            //Monday
			if (!hoursReport && !labourReport)
	            lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();    
			else
	            lineArray[21] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();    
			if (!hoursReport && !labourReport)
	            lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
			else
	            lineArray[22] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();
			else
	            lineArray[23] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();
			if (!hoursReport && !labourReport)
	            lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();	
			else
	            lineArray[24] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();	

		    break;
        }

		if (!hoursReport && !labourReport)
			lineArray[25] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();
		else
			lineArray[25] = (decimal.Round(hotListDataBase.getHOT_Day016(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[26] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
		else
			lineArray[26] = (decimal.Round(hotListDataBase.getHOT_Day017(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[27] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();
		else
			lineArray[27] = (decimal.Round(hotListDataBase.getHOT_Day018(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[28] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
		else
			lineArray[28] = (decimal.Round(hotListDataBase.getHOT_Day019(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[29] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
		else
			lineArray[29] = (decimal.Round(hotListDataBase.getHOT_Day020(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[30] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();
		else
			lineArray[30] = (decimal.Round(hotListDataBase.getHOT_Day021(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[31] = (decimal.Floor(hotListDataBase.getHOT_Day022())).ToString();
		else
			lineArray[31] = (decimal.Round(hotListDataBase.getHOT_Day022(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[32] = (decimal.Floor(hotListDataBase.getHOT_Day023())).ToString();
		else
			lineArray[32] = (decimal.Round(hotListDataBase.getHOT_Day023(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[33] = (decimal.Floor(hotListDataBase.getHOT_Day024())).ToString();
		else
			lineArray[33] = (decimal.Round(hotListDataBase.getHOT_Day024(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[34] = (decimal.Floor(hotListDataBase.getHOT_Day025())).ToString();
		else
			lineArray[34] = (decimal.Round(hotListDataBase.getHOT_Day025(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[35] = (decimal.Floor(hotListDataBase.getHOT_Day026())).ToString();
		else
			lineArray[35] = (decimal.Round(hotListDataBase.getHOT_Day026(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[36] = (decimal.Floor(hotListDataBase.getHOT_Day027())).ToString();
		else
			lineArray[36] = (decimal.Round(hotListDataBase.getHOT_Day027(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[37] = (decimal.Floor(hotListDataBase.getHOT_Day028())).ToString();
		else
			lineArray[37] = (decimal.Round(hotListDataBase.getHOT_Day028(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[38] = (decimal.Floor(hotListDataBase.getHOT_Day029())).ToString();
		else
			lineArray[38] = (decimal.Round(hotListDataBase.getHOT_Day029(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[39] = (decimal.Floor(hotListDataBase.getHOT_Day030())).ToString();
		else
			lineArray[39] = (decimal.Round(hotListDataBase.getHOT_Day030(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[40] = (decimal.Floor(hotListDataBase.getHOT_Day031())).ToString();
		else
			lineArray[40] = (decimal.Round(hotListDataBase.getHOT_Day031(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[41] = (decimal.Floor(hotListDataBase.getHOT_Day032())).ToString();
		else
			lineArray[41] = (decimal.Round(hotListDataBase.getHOT_Day032(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[42] = (decimal.Floor(hotListDataBase.getHOT_Day033())).ToString();
		else
			lineArray[42] = (decimal.Round(hotListDataBase.getHOT_Day033(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[43] = (decimal.Floor(hotListDataBase.getHOT_Day034())).ToString();
		else
			lineArray[43] = (decimal.Round(hotListDataBase.getHOT_Day034(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[44] = (decimal.Floor(hotListDataBase.getHOT_Day035())).ToString();
		else
			lineArray[44] = (decimal.Round(hotListDataBase.getHOT_Day035(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[45] = (decimal.Floor(hotListDataBase.getHOT_Day036())).ToString();
		else
			lineArray[45] = (decimal.Round(hotListDataBase.getHOT_Day036(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[46] = (decimal.Floor(hotListDataBase.getHOT_Day037())).ToString();
		else
			lineArray[46] = (decimal.Round(hotListDataBase.getHOT_Day037(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[47] = (decimal.Floor(hotListDataBase.getHOT_Day038())).ToString();
		else
			lineArray[47] = (decimal.Round(hotListDataBase.getHOT_Day038(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[48] = (decimal.Floor(hotListDataBase.getHOT_Day039())).ToString();
		else
			lineArray[48] = (decimal.Round(hotListDataBase.getHOT_Day039(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[49] = (decimal.Floor(hotListDataBase.getHOT_Day040())).ToString();
		else
			lineArray[49] = (decimal.Round(hotListDataBase.getHOT_Day040(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[50] = (decimal.Floor(hotListDataBase.getHOT_Day041())).ToString();
		else
			lineArray[50] = (decimal.Round(hotListDataBase.getHOT_Day041(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[51] = (decimal.Floor(hotListDataBase.getHOT_Day042())).ToString();
		else
			lineArray[51] = (decimal.Round(hotListDataBase.getHOT_Day042(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[52] = (decimal.Floor(hotListDataBase.getHOT_Day043())).ToString();
		else
			lineArray[52] = (decimal.Round(hotListDataBase.getHOT_Day043(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[53] = (decimal.Floor(hotListDataBase.getHOT_Day044())).ToString();
		else
			lineArray[53] = (decimal.Round(hotListDataBase.getHOT_Day044(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[54] = (decimal.Floor(hotListDataBase.getHOT_Day045())).ToString();
		else
			lineArray[54] = (decimal.Round(hotListDataBase.getHOT_Day045(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[55] = (decimal.Floor(hotListDataBase.getHOT_Day046())).ToString();
		else
			lineArray[55] = (decimal.Round(hotListDataBase.getHOT_Day046(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[56] = (decimal.Floor(hotListDataBase.getHOT_Day047())).ToString();
		else
			lineArray[56] = (decimal.Round(hotListDataBase.getHOT_Day047(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[57] = (decimal.Floor(hotListDataBase.getHOT_Day048())).ToString();
		else
			lineArray[57] = (decimal.Round(hotListDataBase.getHOT_Day048(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[58] = (decimal.Floor(hotListDataBase.getHOT_Day049())).ToString();
		else
			lineArray[58] = (decimal.Round(hotListDataBase.getHOT_Day049(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[59] = (decimal.Floor(hotListDataBase.getHOT_Day050())).ToString();
		else
			lineArray[59] = (decimal.Round(hotListDataBase.getHOT_Day050(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[60] = (decimal.Floor(hotListDataBase.getHOT_Day051())).ToString();
		else
			lineArray[60] = (decimal.Round(hotListDataBase.getHOT_Day051(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[61] = (decimal.Floor(hotListDataBase.getHOT_Day052())).ToString();
		else
			lineArray[61] = (decimal.Round(hotListDataBase.getHOT_Day052(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[62] = (decimal.Floor(hotListDataBase.getHOT_Day053())).ToString();
		else
			lineArray[62] = (decimal.Round(hotListDataBase.getHOT_Day053(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[63] = (decimal.Floor(hotListDataBase.getHOT_Day054())).ToString();
		else
			lineArray[63] = (decimal.Round(hotListDataBase.getHOT_Day054(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[64] = (decimal.Floor(hotListDataBase.getHOT_Day055())).ToString();
		else
			lineArray[64] = (decimal.Round(hotListDataBase.getHOT_Day055(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[65] = (decimal.Floor(hotListDataBase.getHOT_Day056())).ToString();
		else
			lineArray[65] = (decimal.Round(hotListDataBase.getHOT_Day056(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[66] = (decimal.Floor(hotListDataBase.getHOT_Day057())).ToString(); 
		else
			lineArray[66] = (decimal.Round(hotListDataBase.getHOT_Day057(), 2)).ToString(); 
		if (!hoursReport && !labourReport)
			lineArray[67] = (decimal.Floor(hotListDataBase.getHOT_Day058())).ToString();
		else
			lineArray[67] = (decimal.Round(hotListDataBase.getHOT_Day058(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[68] = (decimal.Floor(hotListDataBase.getHOT_Day059())).ToString();
		else
			lineArray[68] = (decimal.Round(hotListDataBase.getHOT_Day059(), 2)).ToString();
		if (!hoursReport && !labourReport)
			lineArray[69] = (decimal.Floor(hotListDataBase.getHOT_Day060())).ToString();
		else
			lineArray[69] = (decimal.Round(hotListDataBase.getHOT_Day060(), 2)).ToString();

		lineArray[70] = hotListDataBase.getHOT_MajorGroup();
		lineArray[71] = hotListDataBase.getHOT_MinorGroup();
		lineArray[72] = hotListDataBase.getHOT_Finalized();

		mmgpDataBase.setBRDES("");
		mmgpDataBase.setBRMGRP(hotListDataBase.getHOT_MinorGroup());
		mmgpDataBase.readByMinorGroup();

		lineArray[73] = mmgpDataBase.getBRDES();

		lineArray[74] = hotListDataBase.getHOT_MainMaterial();
		lineArray[75] = hotListDataBase.getHOT_MainMaterialSeq().ToString();
		lineArray[76] = (decimal.Floor(hotListDataBase.getHOT_MainMaterialQoh())).ToString();
		lineArray[77] = hotListDataBase.getHOT_MajorGroup() + "-" + hotListDataBase.getHOT_MinorGroup();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (hotListDataBase.getHOT_MainMaterial().Equals("")){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.setBMS_ProdID(hotListDataBase.getHOT_ProdID());
			bomSumDataBase.setBMS_Seq(hotListDataBase.getHOT_Seq());
			bomSumDataBase.setBMS_MatID(hotListDataBase.getHOT_MainMaterial());
			bomSumDataBase.setBMS_MatSeq(hotListDataBase.getHOT_Seq());
			if (bomSumDataBase.exists()){
				bomSumDataBase.read();

				lineArray[76] += " / " + (decimal.Floor(bomSumDataBase.getBMS_MatQty())).ToString();
			}
		}
		lineArray[78] = hotListDataBase.getHOT_Id().ToString();
		
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		pltDeptMachDataBase.setPDM_Dept(hotListDataBase.getHOT_Dept());
		pltDeptMachDataBase.setPDM_Mach(hotListDataBase.getHOT_Mach());
		if (pltDeptMachDataBase.existsByMach()){
			pltDeptMachDataBase.readByMach();
			lineArray[79] = pltDeptMachDataBase.getPDM_Des1();
		}

		lineArray[80] = hotListDataBase.getHOT_Level().ToString();

		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer =
			new ProdFmInfoDataBaseContainer(dataBaseAccess);
		string description = prodFmInfoDataBaseContainer.readDescByProdId(hotListDataBase.getHOT_ProdID());
		lineArray[81] = description.Length > 20 ? description.Substring(0, 20) : description;

		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		returnArray[i] = lineArray;
		returnArrayList.Add(lineArray);
		i++;
	}

	dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

	return returnArrayList;
}

public 
string[][] getHotListReportByPart(int id, string byPart){
	try{
	
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readReport(id,byPart);

		string[][] returnArray = new string[hotListDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;

			string[] lineArray = new string[74];
			lineArray[0] = hotListDataBase.getHOT_ProdID();
			lineArray[1] = hotListDataBase.getHOT_ActID();
			lineArray[2] = hotListDataBase.getHOT_Seq().ToString();
			lineArray[3] = hotListDataBase.getHOT_Uom();
			lineArray[4] = hotListDataBase.getHOT_Dept();
			lineArray[5] = hotListDataBase.getHOT_Mach();
			lineArray[6] = hotListDataBase.getHOT_MachCyc().ToString();
			lineArray[7] = hotListDataBase.getHOT_Qoh().ToString();
			lineArray[8] = hotListDataBase.getHOT_QohCml().ToString();
			lineArray[9] = hotListDataBase.getHOT_PastDue().ToString();
			lineArray[10] = (decimal.Floor(hotListDataBase.getHOT_Day001())).ToString();
			lineArray[11] = (decimal.Floor(hotListDataBase.getHOT_Day002())).ToString();
			lineArray[12] = (decimal.Floor(hotListDataBase.getHOT_Day003())).ToString();
			lineArray[13] = (decimal.Floor(hotListDataBase.getHOT_Day004())).ToString();
			lineArray[14] = (decimal.Floor(hotListDataBase.getHOT_Day005())).ToString();
			lineArray[15] = (decimal.Floor(hotListDataBase.getHOT_Day006())).ToString();
			lineArray[16] = (decimal.Floor(hotListDataBase.getHOT_Day007())).ToString();
			lineArray[17] = (decimal.Floor(hotListDataBase.getHOT_Day008())).ToString();
			lineArray[18] = (decimal.Floor(hotListDataBase.getHOT_Day009())).ToString();
			lineArray[19] = (decimal.Floor(hotListDataBase.getHOT_Day010())).ToString();
			lineArray[20] = (decimal.Floor(hotListDataBase.getHOT_Day011())).ToString();
			lineArray[21] = (decimal.Floor(hotListDataBase.getHOT_Day012())).ToString();
			lineArray[22] = (decimal.Floor(hotListDataBase.getHOT_Day013())).ToString();
			lineArray[23] = (decimal.Floor(hotListDataBase.getHOT_Day014())).ToString();
			lineArray[24] = (decimal.Floor(hotListDataBase.getHOT_Day015())).ToString();
			lineArray[25] = (decimal.Floor(hotListDataBase.getHOT_Day016())).ToString();
			lineArray[26] = (decimal.Floor(hotListDataBase.getHOT_Day017())).ToString();
			lineArray[27] = (decimal.Floor(hotListDataBase.getHOT_Day018())).ToString();
			lineArray[28] = (decimal.Floor(hotListDataBase.getHOT_Day019())).ToString();
			lineArray[29] = (decimal.Floor(hotListDataBase.getHOT_Day020())).ToString();
			lineArray[30] = (decimal.Floor(hotListDataBase.getHOT_Day021())).ToString();
			lineArray[31] = (decimal.Floor(hotListDataBase.getHOT_Day022())).ToString();
			lineArray[32] = (decimal.Floor(hotListDataBase.getHOT_Day023())).ToString();
			lineArray[33] = (decimal.Floor(hotListDataBase.getHOT_Day024())).ToString();
			lineArray[34] = (decimal.Floor(hotListDataBase.getHOT_Day025())).ToString();
			lineArray[35] = (decimal.Floor(hotListDataBase.getHOT_Day026())).ToString();
			lineArray[36] = (decimal.Floor(hotListDataBase.getHOT_Day027())).ToString();
			lineArray[37] = (decimal.Floor(hotListDataBase.getHOT_Day028())).ToString();
			lineArray[38] = (decimal.Floor(hotListDataBase.getHOT_Day029())).ToString();
			lineArray[39] = (decimal.Floor(hotListDataBase.getHOT_Day030())).ToString();
			lineArray[40] = (decimal.Floor(hotListDataBase.getHOT_Day031())).ToString();
			lineArray[41] = (decimal.Floor(hotListDataBase.getHOT_Day032())).ToString();
			lineArray[42] = (decimal.Floor(hotListDataBase.getHOT_Day033())).ToString();
			lineArray[43] = (decimal.Floor(hotListDataBase.getHOT_Day034())).ToString();
			lineArray[44] = (decimal.Floor(hotListDataBase.getHOT_Day035())).ToString();
			lineArray[45] = (decimal.Floor(hotListDataBase.getHOT_Day036())).ToString();
			lineArray[46] = (decimal.Floor(hotListDataBase.getHOT_Day037())).ToString();
			lineArray[47] = (decimal.Floor(hotListDataBase.getHOT_Day038())).ToString();
			lineArray[48] = (decimal.Floor(hotListDataBase.getHOT_Day039())).ToString();
			lineArray[49] = (decimal.Floor(hotListDataBase.getHOT_Day040())).ToString();
			lineArray[50] = (decimal.Floor(hotListDataBase.getHOT_Day041())).ToString();
			lineArray[51] = (decimal.Floor(hotListDataBase.getHOT_Day042())).ToString();
			lineArray[52] = (decimal.Floor(hotListDataBase.getHOT_Day043())).ToString();
			lineArray[53] = (decimal.Floor(hotListDataBase.getHOT_Day044())).ToString();
			lineArray[54] = (decimal.Floor(hotListDataBase.getHOT_Day045())).ToString();
			lineArray[55] = (decimal.Floor(hotListDataBase.getHOT_Day046())).ToString();
			lineArray[56] = (decimal.Floor(hotListDataBase.getHOT_Day047())).ToString();
			lineArray[57] = (decimal.Floor(hotListDataBase.getHOT_Day048())).ToString();
			lineArray[58] = (decimal.Floor(hotListDataBase.getHOT_Day049())).ToString();
			lineArray[59] = (decimal.Floor(hotListDataBase.getHOT_Day050())).ToString();
			lineArray[60] = (decimal.Floor(hotListDataBase.getHOT_Day051())).ToString();
			lineArray[61] = (decimal.Floor(hotListDataBase.getHOT_Day052())).ToString();
			lineArray[62] = (decimal.Floor(hotListDataBase.getHOT_Day053())).ToString();
			lineArray[63] = (decimal.Floor(hotListDataBase.getHOT_Day054())).ToString();
			lineArray[64] = (decimal.Floor(hotListDataBase.getHOT_Day055())).ToString();
			lineArray[65] = (decimal.Floor(hotListDataBase.getHOT_Day056())).ToString();
			lineArray[66] = (decimal.Floor(hotListDataBase.getHOT_Day057())).ToString(); 
			lineArray[67] = (decimal.Floor(hotListDataBase.getHOT_Day058())).ToString();
			lineArray[68] = (decimal.Floor(hotListDataBase.getHOT_Day059())).ToString();
			lineArray[69] = (decimal.Floor(hotListDataBase.getHOT_Day060())).ToString();
			lineArray[70] = hotListDataBase.getHOT_MajorGroup();
			lineArray[71] = hotListDataBase.getHOT_MinorGroup();
			lineArray[72] = hotListDataBase.getHOT_Finalized();
			lineArray[73] = hotListDataBase.getHOT_Id().ToString();
		
			returnArray[i] = lineArray;
			i++;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getMaterialDueDate(bool weeks, string[] depts, string[] parts, bool orderByVendor, string[] stkLocs){
	try{
		int days1 = 0;
		int days2 = 1;
		int days3 = 2;
		int days4 = 3;
		int days5 = 4;
		int days6 = 5;
		int days7 = 6;
		int days8 = 7;
		int days9 = 8;
		int days10 = 9;
		int days11 = 10;
		int days12 = 11;
		int days13 = 12;
		int days14 = 13;

		if (weeks){
			days1 = 6;
			days2 = 13;
			days3 = 20;
			days4 = 27;
			days5 = 34;
			days6 = 41;
			days7 = 47;
			days8 = 55;
			days9 = 62;
			days10 = 69;
			days11 = 76;
			days12 = 83;
			days13 = 90;
			days14 = 97;
		}
		
		MaterialDueDateContainer materialDueDateContainer = new MaterialDueDateContainer();
		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);

		string[][] partsDueDate = schMatReqDayDataBaseContainer.getPartsDueDate(parts, depts, orderByVendor);
		string[] logDates = getHotListLogData();
		DateTime runDate = DateUtil.parseCompleteDate(logDates[0], DateUtil.MMDDYYYY);
		runDate = DateUtil.parseDate(DateUtil.getDateRepresentation(runDate, DateUtil.MMDDYYYY), DateUtil.MMDDYYYY);
		
		for(int i = 0; i < partsDueDate.Length; i++){

			string supplierNum = partsDueDate[i][0];
			string prodID = partsDueDate[i][1];
			int prodSeq = int.Parse(partsDueDate[i][2]);
			string matID = partsDueDate[i][3];
			int matSeq = int.Parse(partsDueDate[i][4]);
			string des = partsDueDate[i][9];
			DateTime matReqDate = DateUtil.parseDate(partsDueDate[i][5], DateUtil.MMDDYYYY);
			decimal demMatReq = decimal.Parse(partsDueDate[i][6]);
			decimal schMatReq = decimal.Parse(partsDueDate[i][7]);
			decimal totalMatReq = demMatReq + schMatReq;

			MaterialDueDate materialDueDate = 
				materialDueDateContainer.getMaterialDueDate(matID, matSeq);

			if (materialDueDate == null){
				materialDueDate = new MaterialDueDate(supplierNum, matID, matSeq, des, 
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				materialDueDateContainer.Add(materialDueDate);
			}

			if (matReqDate.CompareTo(runDate) < 0){
				materialDueDate.setPastDue(totalMatReq);
			}else{
				TimeSpan timeSpan = matReqDate.Subtract(runDate);
				int offset = timeSpan.Days;

				if (offset <= days1){
					materialDueDate.setEnt1(materialDueDate.getEnt1() + totalMatReq);
					continue;
				}
				if (offset <= days2){
					materialDueDate.setEnt2(materialDueDate.getEnt2() + totalMatReq);
					continue;
				}
				if (offset <= days3){
					materialDueDate.setEnt3(materialDueDate.getEnt3() + totalMatReq);
					continue;
				}
				if (offset <= days4){
					materialDueDate.setEnt4(materialDueDate.getEnt4() + totalMatReq);
					continue;
				}
				if (offset <= days5){
					materialDueDate.setEnt5(materialDueDate.getEnt5() + totalMatReq);
					continue;
				}
				if (offset <= days6){
					materialDueDate.setEnt6(materialDueDate.getEnt6() + totalMatReq);
					continue;
				}
				if (offset <= days7){
					materialDueDate.setEnt7(materialDueDate.getEnt7() + totalMatReq);
					continue;
				}
				if (offset <= days8){
					materialDueDate.setEnt8(materialDueDate.getEnt8() + totalMatReq);
					continue;
				}
				if (offset <= days9){
					materialDueDate.setEnt9(materialDueDate.getEnt9() + totalMatReq);
					continue;
				}
				if (offset <= days10){
					materialDueDate.setEnt10(materialDueDate.getEnt10() + totalMatReq);
					continue;
				}
				if (offset <= days11){
					materialDueDate.setEnt11(materialDueDate.getEnt11() + totalMatReq);
					continue;
				}
				if (offset <= days12){
					materialDueDate.setEnt12(materialDueDate.getEnt12() + totalMatReq);
					continue;
				}
				if (offset <= days13){
					materialDueDate.setEnt13(materialDueDate.getEnt13() + totalMatReq);
					continue;
				}
				if (offset <= days14){
					materialDueDate.setEnt14(materialDueDate.getEnt14() + totalMatReq);
					continue;
				}
			}
		}

		string[][] v = new string[materialDueDateContainer.Count][];
		int index = 0;

		CoreFactory coreFactory = UtilCoreFactory.createCoreFactory(UtilCoreFactory.LOCAL);
		for(IEnumerator en = materialDueDateContainer.GetEnumerator(); en.MoveNext(); ){
			MaterialDueDate materialDueDate = (MaterialDueDate)en.Current;

			Inventory inventory = coreFactory.readInventory(materialDueDate.getProduct());
			
			decimal currentQoh = inventory.getTotalInventoryForMaterials(stkLocs);

			decimal pd = materialDueDate.getPastDue() - currentQoh;
			decimal d1 = pd + materialDueDate.getEnt1();
			decimal d2 = d1 + materialDueDate.getEnt2();
			decimal d3 = d2 + materialDueDate.getEnt3();
			decimal d4 = d3 + materialDueDate.getEnt4();
			decimal d5 = d4 + materialDueDate.getEnt5();
			decimal d6 = d5 + materialDueDate.getEnt6();
			decimal d7 = d6 + materialDueDate.getEnt7();
			decimal d8 = d7 + materialDueDate.getEnt8();
			decimal d9 = d8 + materialDueDate.getEnt9();
			decimal d10 = d9 + materialDueDate.getEnt10();
			decimal d11 = d10 + materialDueDate.getEnt11();
			decimal d12 = d11 + materialDueDate.getEnt12();
			decimal d13 = d12 + materialDueDate.getEnt13();
			decimal d14 = d13 + materialDueDate.getEnt14();

			if (pd <= 0)
				pd = 0;
			if (d1 <= 0)
				d1 = 0;
			if (d2 <= 0)
				d2 = 0;
			if (d3 <= 0)
				d3 = 0;
			if (d4 <= 0)
				d4 = 0;
			if (d5 <= 0)
				d5 = 0;
			if (d6 <= 0)
				d6 = 0;
			if (d7 <= 0)
				d7 = 0;
			if (d8 <= 0)
				d8 = 0;
			if (d9 <= 0)
				d9 = 0;
			if (d10 <= 0)
				d10 = 0;
			if (d11 <= 0)
				d11 = 0;
			if (d12 <= 0)
				d12 = 0;
			if (d13 <= 0)
				d13 = 0;
			if (d14 <= 0)
				d14 = 0;

			if ((pd == 0) && (d1 == 0) && (d2 == 0) && (d3 == 0) && (d4 == 0) && (d5 == 0) &&
						(d6 == 0) && (d7 == 0) && (d8 == 0) && (d9 == 0) && (d10 == 0) &&
						(d11 == 0) && (d12 == 0) && (d13 == 0) && (d14 == 0)){
				continue; // all records in zero
			}
			
			string[] line = new string[20];
			line[0] = materialDueDate.getSupplier();
			line[1] = decimal.Round(inventory.getTotalInventoryForMaterials(stkLocs), 0).ToString("###,###,###,##0");
			line[2] = materialDueDate.getProduct();
			line[3] = materialDueDate.getSeq().ToString();
			line[4] = materialDueDate.getDescription();
			line[5] = decimal.Round(pd * -1, 0).ToString("###,###,###,##0");
			line[6] = decimal.Round(d1 * -1, 0).ToString("###,###,###,##0");
			line[7] = decimal.Round(d2 * -1, 0).ToString("###,###,###,##0");
			line[8] = decimal.Round(d3 * -1, 0).ToString("###,###,###,##0");
			line[9] = decimal.Round(d4 * -1, 0).ToString("###,###,###,##0");
			line[10] = decimal.Round(d5 * -1, 0).ToString("###,###,###,##0");
			line[11] = decimal.Round(d6 * -1, 0).ToString("###,###,###,##0");
			line[12] = decimal.Round(d7 * -1, 0).ToString("###,###,###,##0");
			line[13] = decimal.Round(d8 * -1, 0).ToString("###,###,###,##0");
			line[14] = decimal.Round(d9 * -1, 0).ToString("###,###,###,##0");
			line[15] = decimal.Round(d10 * -1, 0).ToString("###,###,###,##0");
			line[16] = decimal.Round(d11 * -1, 0).ToString("###,###,###,##0");
			line[17] = decimal.Round(d12 * -1, 0).ToString("###,###,###,##0");
			line[18] = decimal.Round(d13 * -1, 0).ToString("###,###,###,##0");
			line[19] = decimal.Round(d14 * -1, 0).ToString("###,###,###,##0");

			v[index] = line;
			index++;
		}

		string[][] newVec = new string[index][];
		for(int x = 0; x < index; x++){
			newVec[x] = v[x];
		}

		coreFactory = null;
		return newVec;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
void blockHotList(){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		HotListBlockDataBase hotListBlockDataBase = new HotListBlockDataBase(this.dataBaseAccess);
		hotListBlockDataBase.setBlocked("Y");
		hotListBlockDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
bool isHotListBlocked(){
	try{
		HotListBlockDataBase hotListBlockDataBase = new HotListBlockDataBase(this.dataBaseAccess);
		hotListBlockDataBase.read();
		if (hotListBlockDataBase.getBlocked().Equals("Y"))
			return true;
		return false;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
void unBlockHotList(){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		HotListBlockDataBase hotListBlockDataBase = new HotListBlockDataBase(this.dataBaseAccess);
		hotListBlockDataBase.setBlocked("N");
		hotListBlockDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//CM 11/10/2005
public
HotListHourContainer getHotListHoursDays(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		string[] v = getHotListLogData();
		DateTime today = DateUtil.parseDate(v[0].Substring(0, 10), DateUtil.MMDDYYYY);

		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readOrderByConfiguration(id);

		HotListHourContainer hotListHourContainer = new HotListHourContainer();

		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase)en.Current;

			HotListHour hotListHour = hotListHourContainer.getHotListHour(hotListDataBase.getHOT_Mach());
			if (hotListHour == null){
				hotListHour = new HotListHour(hotListDataBase.getHOT_Mach(), HotListHour.FOR_DAYS);
				hotListHourContainer.Add(hotListHour);
			}
			
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
			prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
			prodFmActSubDataBase.setPC_RunStd(0); // if not exists => RunStd = 0
			prodFmActSubDataBase.read();
			decimal runStd = prodFmActSubDataBase.getPC_RunStd();

			if (runStd != 0){
				decimal pastDue = hotListDataBase.getHOT_PastDue();
				decimal day001 = hotListDataBase.getHOT_Day001() - hotListDataBase.getHOT_PastDue();
				decimal day002 = hotListDataBase.getHOT_Day002() - hotListDataBase.getHOT_Day001();
				decimal day003 = hotListDataBase.getHOT_Day003() - hotListDataBase.getHOT_Day002();
				decimal day004 = hotListDataBase.getHOT_Day004() - hotListDataBase.getHOT_Day003();
				decimal day005 = hotListDataBase.getHOT_Day005() - hotListDataBase.getHOT_Day004();
				decimal day006 = hotListDataBase.getHOT_Day006() - hotListDataBase.getHOT_Day005();
				decimal day007 = hotListDataBase.getHOT_Day007() - hotListDataBase.getHOT_Day006();
				decimal day008 = hotListDataBase.getHOT_Day008() - hotListDataBase.getHOT_Day007();
				decimal day009 = hotListDataBase.getHOT_Day009() - hotListDataBase.getHOT_Day008();
				decimal day010 = hotListDataBase.getHOT_Day010() - hotListDataBase.getHOT_Day009();
				decimal day011 = hotListDataBase.getHOT_Day011() - hotListDataBase.getHOT_Day010();
				decimal day012 = hotListDataBase.getHOT_Day012() - hotListDataBase.getHOT_Day011();
				decimal day013 = hotListDataBase.getHOT_Day013() - hotListDataBase.getHOT_Day012();
				decimal day014 = hotListDataBase.getHOT_Day014() - hotListDataBase.getHOT_Day013();
				decimal day015 = hotListDataBase.getHOT_Day015() - hotListDataBase.getHOT_Day014();

				decimal day016 = hotListDataBase.getHOT_Day016() - hotListDataBase.getHOT_Day015();
				decimal day017 = hotListDataBase.getHOT_Day017() - hotListDataBase.getHOT_Day016();
				decimal day018 = hotListDataBase.getHOT_Day018() - hotListDataBase.getHOT_Day017();
				decimal day019 = hotListDataBase.getHOT_Day019() - hotListDataBase.getHOT_Day018();
				decimal day020 = hotListDataBase.getHOT_Day020() - hotListDataBase.getHOT_Day019();
				decimal day021 = hotListDataBase.getHOT_Day021() - hotListDataBase.getHOT_Day020();
				decimal day022 = hotListDataBase.getHOT_Day022() - hotListDataBase.getHOT_Day021();
				decimal day023 = hotListDataBase.getHOT_Day023() - hotListDataBase.getHOT_Day022();
				decimal day024 = hotListDataBase.getHOT_Day024() - hotListDataBase.getHOT_Day023();
				decimal day025 = hotListDataBase.getHOT_Day025() - hotListDataBase.getHOT_Day024();
				decimal day026 = hotListDataBase.getHOT_Day026() - hotListDataBase.getHOT_Day025();
				decimal day027 = hotListDataBase.getHOT_Day027() - hotListDataBase.getHOT_Day026();
				decimal day028 = hotListDataBase.getHOT_Day028() - hotListDataBase.getHOT_Day027();
				decimal day029 = hotListDataBase.getHOT_Day029() - hotListDataBase.getHOT_Day028();
				decimal day030 = hotListDataBase.getHOT_Day030() - hotListDataBase.getHOT_Day029();

				decimal day031 = hotListDataBase.getHOT_Day031() - hotListDataBase.getHOT_Day030();
				decimal day032 = hotListDataBase.getHOT_Day032() - hotListDataBase.getHOT_Day031();
				decimal day033 = hotListDataBase.getHOT_Day033() - hotListDataBase.getHOT_Day032();
				decimal day034 = hotListDataBase.getHOT_Day034() - hotListDataBase.getHOT_Day033();
				decimal day035 = hotListDataBase.getHOT_Day035() - hotListDataBase.getHOT_Day034();
				decimal day036 = hotListDataBase.getHOT_Day036() - hotListDataBase.getHOT_Day035();
				decimal day037 = hotListDataBase.getHOT_Day037() - hotListDataBase.getHOT_Day036();
				decimal day038 = hotListDataBase.getHOT_Day038() - hotListDataBase.getHOT_Day037();
				decimal day039 = hotListDataBase.getHOT_Day039() - hotListDataBase.getHOT_Day038();
				decimal day040 = hotListDataBase.getHOT_Day040() - hotListDataBase.getHOT_Day039();
				decimal day041 = hotListDataBase.getHOT_Day041() - hotListDataBase.getHOT_Day040();
				decimal day042 = hotListDataBase.getHOT_Day042() - hotListDataBase.getHOT_Day041();
				decimal day043 = hotListDataBase.getHOT_Day043() - hotListDataBase.getHOT_Day042();
				decimal day044 = hotListDataBase.getHOT_Day044() - hotListDataBase.getHOT_Day043();
				decimal day045 = hotListDataBase.getHOT_Day045() - hotListDataBase.getHOT_Day044();
				
				decimal day046 = hotListDataBase.getHOT_Day046() - hotListDataBase.getHOT_Day045();
				decimal day047 = hotListDataBase.getHOT_Day047() - hotListDataBase.getHOT_Day046();
				decimal day048 = hotListDataBase.getHOT_Day048() - hotListDataBase.getHOT_Day047();
				decimal day049 = hotListDataBase.getHOT_Day049() - hotListDataBase.getHOT_Day048();
				decimal day050 = hotListDataBase.getHOT_Day050() - hotListDataBase.getHOT_Day049();
				decimal day051 = hotListDataBase.getHOT_Day051() - hotListDataBase.getHOT_Day050();
				decimal day052 = hotListDataBase.getHOT_Day052() - hotListDataBase.getHOT_Day051();
				decimal day053 = hotListDataBase.getHOT_Day053() - hotListDataBase.getHOT_Day052();
				decimal day054 = hotListDataBase.getHOT_Day054() - hotListDataBase.getHOT_Day053();
				decimal day055 = hotListDataBase.getHOT_Day055() - hotListDataBase.getHOT_Day054();
				decimal day056 = hotListDataBase.getHOT_Day056() - hotListDataBase.getHOT_Day055();
				decimal day057 = hotListDataBase.getHOT_Day057() - hotListDataBase.getHOT_Day056();
				decimal day058 = hotListDataBase.getHOT_Day058() - hotListDataBase.getHOT_Day057();
				decimal day059 = hotListDataBase.getHOT_Day059() - hotListDataBase.getHOT_Day058();
				decimal day060 = hotListDataBase.getHOT_Day060() - hotListDataBase.getHOT_Day059();
				
				hotListHour.addHourDemand(pastDue / runStd, 0);
				hotListHour.addHourDemand(day001 / runStd, 1);
				hotListHour.addHourDemand(day002 / runStd, 2);
				hotListHour.addHourDemand(day003 / runStd, 3);
				hotListHour.addHourDemand(day004 / runStd, 4);
				hotListHour.addHourDemand(day005 / runStd, 5);
				hotListHour.addHourDemand(day006 / runStd, 6);
				hotListHour.addHourDemand(day007 / runStd, 7);
				hotListHour.addHourDemand(day008 / runStd, 8);
				hotListHour.addHourDemand(day009 / runStd, 9);
				hotListHour.addHourDemand(day010 / runStd, 10);
				hotListHour.addHourDemand(day011 / runStd, 11);
				hotListHour.addHourDemand(day012 / runStd, 12);
				hotListHour.addHourDemand(day013 / runStd, 13);
				hotListHour.addHourDemand(day014 / runStd, 14);
				hotListHour.addHourDemand(day015 / runStd, 15);

				hotListHour.addHourDemand(day016 / runStd, 16);
				hotListHour.addHourDemand(day017 / runStd, 17);
				hotListHour.addHourDemand(day018 / runStd, 18);
				hotListHour.addHourDemand(day019 / runStd, 19);
				hotListHour.addHourDemand(day020 / runStd, 20);
				hotListHour.addHourDemand(day021 / runStd, 21);
				hotListHour.addHourDemand(day022 / runStd, 22);
				hotListHour.addHourDemand(day023 / runStd, 23);
				hotListHour.addHourDemand(day024 / runStd, 24);
				hotListHour.addHourDemand(day025 / runStd, 25);
				hotListHour.addHourDemand(day026 / runStd, 26);
				hotListHour.addHourDemand(day027 / runStd, 27);
				hotListHour.addHourDemand(day028 / runStd, 28);
				hotListHour.addHourDemand(day029 / runStd, 29);
				hotListHour.addHourDemand(day030 / runStd, 30);

				hotListHour.addHourDemand(day031 / runStd, 31);
				hotListHour.addHourDemand(day032 / runStd, 32);
				hotListHour.addHourDemand(day033 / runStd, 33);
				hotListHour.addHourDemand(day034 / runStd, 34);
				hotListHour.addHourDemand(day035 / runStd, 35);
				hotListHour.addHourDemand(day036 / runStd, 36);
				hotListHour.addHourDemand(day037 / runStd, 37);
				hotListHour.addHourDemand(day038 / runStd, 38);
				hotListHour.addHourDemand(day039 / runStd, 39);
				hotListHour.addHourDemand(day040 / runStd, 40);
				hotListHour.addHourDemand(day041 / runStd, 41);
				hotListHour.addHourDemand(day042 / runStd, 42);
				hotListHour.addHourDemand(day043 / runStd, 43);
				hotListHour.addHourDemand(day044 / runStd, 44);
				hotListHour.addHourDemand(day045 / runStd, 45);
				
				hotListHour.addHourDemand(day046 / runStd, 46);
				hotListHour.addHourDemand(day047 / runStd, 47);
				hotListHour.addHourDemand(day048 / runStd, 48);
				hotListHour.addHourDemand(day049 / runStd, 49);
				hotListHour.addHourDemand(day050 / runStd, 50);
				hotListHour.addHourDemand(day051 / runStd, 51);
				hotListHour.addHourDemand(day052 / runStd, 52);
				hotListHour.addHourDemand(day053 / runStd, 53);
				hotListHour.addHourDemand(day054 / runStd, 54);
				hotListHour.addHourDemand(day055 / runStd, 55);
				hotListHour.addHourDemand(day056 / runStd, 56);
				hotListHour.addHourDemand(day057 / runStd, 57);
				hotListHour.addHourDemand(day058 / runStd, 58);
				hotListHour.addHourDemand(day059 / runStd, 59);
				hotListHour.addHourDemand(day060 / runStd, 60);
			}
		}
		
		CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		capMacHrDataBaseContainer.read(today, "RUNTIME");

		for(IEnumerator en = capMacHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)en.Current;
			TimeSpan timeSpan = capMacHrDataBase.getCMH_Dt().Subtract(today);
			
			if (timeSpan.Days + 1 >= 0){
				HotListHour hotListHour = hotListHourContainer.getHotListHour(capMacHrDataBase.getCMH_Mach());
				
				decimal hours = capMacHrDataBase.getCMH_HrPr();
				hotListHour.addHourCapacity(hours, timeSpan.Days + 1);
			}
		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return hotListHourContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//CM 11/10/2005 Este metodo no se usa
public
HotListHourContainer getHotListHoursShifts(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		string[] v = getHotListLogData();
		DateTime today = DateUtil.parseDate(v[0].Substring(0, 10), DateUtil.MMDDYYYY);

		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readOrderByConfiguration(id);
		
		HotListHourContainer hotListHourContainer = new HotListHourContainer();

		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase)en.Current;

			HotListHour hotListHour = hotListHourContainer.getHotListHour(hotListDataBase.getHOT_Mach());
			if (hotListHour == null){
				hotListHour = new HotListHour(hotListDataBase.getHOT_Mach(), HotListHour.FOR_DAYS);
				hotListHourContainer.Add(hotListHour);
			}
			
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
			prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
			prodFmActSubDataBase.setPC_RunStd(0); // if not exists => RunStd = 0
			prodFmActSubDataBase.read();
			decimal runStd = prodFmActSubDataBase.getPC_RunStd();

			if (runStd != 0){
				decimal[] days = new decimal[61];
				days[0] = hotListDataBase.getHOT_PastDue();
				days[1] = hotListDataBase.getHOT_Day001() - hotListDataBase.getHOT_PastDue();
				days[2] = hotListDataBase.getHOT_Day002() - hotListDataBase.getHOT_Day001();
				days[3] = hotListDataBase.getHOT_Day003() - hotListDataBase.getHOT_Day002();
				days[4] = hotListDataBase.getHOT_Day004() - hotListDataBase.getHOT_Day003();
				days[5] = hotListDataBase.getHOT_Day005() - hotListDataBase.getHOT_Day004();
				days[6] = hotListDataBase.getHOT_Day006() - hotListDataBase.getHOT_Day005();
				days[7] = hotListDataBase.getHOT_Day007() - hotListDataBase.getHOT_Day006();
				days[8] = hotListDataBase.getHOT_Day008() - hotListDataBase.getHOT_Day007();
				days[9] = hotListDataBase.getHOT_Day009() - hotListDataBase.getHOT_Day008();
				days[10] = hotListDataBase.getHOT_Day010() - hotListDataBase.getHOT_Day009();
				days[11] = hotListDataBase.getHOT_Day011() - hotListDataBase.getHOT_Day010();
				days[12] = hotListDataBase.getHOT_Day012() - hotListDataBase.getHOT_Day011();
				days[13] = hotListDataBase.getHOT_Day013() - hotListDataBase.getHOT_Day012();
				days[14] = hotListDataBase.getHOT_Day014() - hotListDataBase.getHOT_Day013();
				days[15] = hotListDataBase.getHOT_Day015() - hotListDataBase.getHOT_Day014();

				days[16] = hotListDataBase.getHOT_Day016() - hotListDataBase.getHOT_Day015();
				days[17] = hotListDataBase.getHOT_Day017() - hotListDataBase.getHOT_Day016();
				days[18] = hotListDataBase.getHOT_Day018() - hotListDataBase.getHOT_Day017();
				days[19] = hotListDataBase.getHOT_Day019() - hotListDataBase.getHOT_Day018();
				days[20] = hotListDataBase.getHOT_Day020() - hotListDataBase.getHOT_Day019();
				days[21] = hotListDataBase.getHOT_Day021() - hotListDataBase.getHOT_Day020();
				days[22] = hotListDataBase.getHOT_Day022() - hotListDataBase.getHOT_Day021();
				days[23] = hotListDataBase.getHOT_Day023() - hotListDataBase.getHOT_Day022();
				days[24] = hotListDataBase.getHOT_Day024() - hotListDataBase.getHOT_Day023();
				days[25] = hotListDataBase.getHOT_Day025() - hotListDataBase.getHOT_Day024();
				days[26] = hotListDataBase.getHOT_Day026() - hotListDataBase.getHOT_Day025();
				days[27] = hotListDataBase.getHOT_Day027() - hotListDataBase.getHOT_Day026();
				days[28] = hotListDataBase.getHOT_Day028() - hotListDataBase.getHOT_Day027();
				days[29] = hotListDataBase.getHOT_Day029() - hotListDataBase.getHOT_Day028();
				days[30] = hotListDataBase.getHOT_Day030() - hotListDataBase.getHOT_Day029();

				days[31] = hotListDataBase.getHOT_Day031() - hotListDataBase.getHOT_Day030();
				days[32] = hotListDataBase.getHOT_Day032() - hotListDataBase.getHOT_Day031();
				days[33] = hotListDataBase.getHOT_Day033() - hotListDataBase.getHOT_Day032();
				days[34] = hotListDataBase.getHOT_Day034() - hotListDataBase.getHOT_Day033();
				days[35] = hotListDataBase.getHOT_Day035() - hotListDataBase.getHOT_Day034();
				days[36] = hotListDataBase.getHOT_Day036() - hotListDataBase.getHOT_Day035();
				days[37] = hotListDataBase.getHOT_Day037() - hotListDataBase.getHOT_Day036();
				days[38] = hotListDataBase.getHOT_Day038() - hotListDataBase.getHOT_Day037();
				days[39] = hotListDataBase.getHOT_Day039() - hotListDataBase.getHOT_Day038();
				days[40] = hotListDataBase.getHOT_Day040() - hotListDataBase.getHOT_Day039();
				days[41] = hotListDataBase.getHOT_Day041() - hotListDataBase.getHOT_Day040();
				days[42] = hotListDataBase.getHOT_Day042() - hotListDataBase.getHOT_Day041();
				days[43] = hotListDataBase.getHOT_Day043() - hotListDataBase.getHOT_Day042();
				days[44] = hotListDataBase.getHOT_Day044() - hotListDataBase.getHOT_Day043();
				days[45] = hotListDataBase.getHOT_Day045() - hotListDataBase.getHOT_Day044();
				
				days[46] = hotListDataBase.getHOT_Day046() - hotListDataBase.getHOT_Day045();
				days[47] = hotListDataBase.getHOT_Day047() - hotListDataBase.getHOT_Day046();
				days[48] = hotListDataBase.getHOT_Day048() - hotListDataBase.getHOT_Day047();
				days[49] = hotListDataBase.getHOT_Day049() - hotListDataBase.getHOT_Day048();
				days[50] = hotListDataBase.getHOT_Day050() - hotListDataBase.getHOT_Day049();
				days[51] = hotListDataBase.getHOT_Day051() - hotListDataBase.getHOT_Day050();
				days[52] = hotListDataBase.getHOT_Day052() - hotListDataBase.getHOT_Day051();
				days[53] = hotListDataBase.getHOT_Day053() - hotListDataBase.getHOT_Day052();
				days[54] = hotListDataBase.getHOT_Day054() - hotListDataBase.getHOT_Day053();
				days[55] = hotListDataBase.getHOT_Day055() - hotListDataBase.getHOT_Day054();
				days[56] = hotListDataBase.getHOT_Day056() - hotListDataBase.getHOT_Day055();
				days[57] = hotListDataBase.getHOT_Day057() - hotListDataBase.getHOT_Day056();
				days[58] = hotListDataBase.getHOT_Day058() - hotListDataBase.getHOT_Day057();
				days[59] = hotListDataBase.getHOT_Day059() - hotListDataBase.getHOT_Day058();
				days[60] = hotListDataBase.getHOT_Day060() - hotListDataBase.getHOT_Day059();

				for(int i = 0; i < days.Length; i++){
//					hotListHour.addHourDemand(days[i] / runStd, i);

					if (i != 0){
						DateTime toSeek = today.AddDays(i);
						CapMacShfDataBaseContainer capMacShfDataBaseContainer = new CapMacShfDataBaseContainer(dataBaseAccess);
						capMacShfDataBaseContainer.setCMS_Mach(hotListHour.getConfiguration());
						capMacShfDataBaseContainer.setCMS_Dt(toSeek);
						capMacShfDataBaseContainer.readByMachDt();

						if (capMacShfDataBaseContainer.Count > 0){ // thiere is shifts
							decimal demand = days[i];
							for(int x = 0; x < capMacShfDataBaseContainer.Count; x++){
								CapMacShfDataBase capMacShfDataBase = (CapMacShfDataBase)capMacShfDataBaseContainer[x];
								decimal prodHours = capMacShfDataBase.getCMS_HrPr();

								if (demand > prodHours){
									if (x != capMacShfDataBaseContainer.Count -1){ // no last shift
										hotListHour.addHourDemand(prodHours, toSeek, capMacShfDataBase.getCMS_Shf());
										demand -= prodHours;
									}else{
										hotListHour.addHourDemand(demand, toSeek, capMacShfDataBase.getCMS_Shf());
									}
								}else{
									hotListHour.addHourDemand(demand, toSeek, capMacShfDataBase.getCMS_Shf());
								}
								
								hotListHour.addHourCapacity(prodHours, toSeek, capMacShfDataBase.getCMS_Shf());
							}
						}else{ // there isn't shifts
							hotListHour.addHourDemand(days[i], toSeek, "");
						}
					}else{
						hotListHour.addHourDemand(days[0], DateTime.MinValue, ""); // past due
					}
				}
			}
		}
		
//		CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
//		capMacHrDataBaseContainer.read(today, "RUNTIME");
//
//		for(IEnumerator en = capMacHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
//			CapMacHrDataBase capMacHrDataBase = (CapMacHrDataBase)en.Current;
//			TimeSpan timeSpan = capMacHrDataBase.getCMH_Dt().Subtract(today);
//			
//			if (timeSpan.Days + 1 >= 0){
//				HotListHour hotListHour = hotListHourContainer.getHotListHour(capMacHrDataBase.getCMH_Mach());
//				
//				decimal hours = capMacHrDataBase.getCMH_HrPr();
//				hotListHour.addHourCapacity(hours, timeSpan.Days + 1);
//			}
//		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return hotListHourContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
decimal getHotListBomInventory(string prod, int sec, Hashtable inventoryList,
		InvPltLocDataBaseContainer invPltLocDataBaseContainer){
	decimal inventory = 0;
	decimal remaining = 0;
	string key = prod + "_" + sec.ToString();

	if (!inventoryList.ContainsKey(key)){
		int pos = invPltLocDataBaseContainer.getFirstElementPosition(prod);
		for(; (pos > -1) && (pos < invPltLocDataBaseContainer.Count); pos++){
			InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) invPltLocDataBaseContainer[pos];

			if ( (invPltLocDataBase.getIPL_ProdID().Equals(prod)) && 
						(invPltLocDataBase.getIPL_Seq() == sec) ){
				inventory += invPltLocDataBase.getIPL_Qoh2();
			}else{
				if (!invPltLocDataBase.getIPL_ProdID().Equals(prod)) 
					break;
			}
		}

			// minimum inventory
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(prod);
		prodFmActPlanDataBase.setPAPL_Seq(sec);
		decimal minInvCum = prodFmActPlanDataBase.getMinInvCum();
		if (minInvCum < inventory)
			remaining = inventory - minInvCum;
		else
			remaining = 0;

		inventoryList.Add(key, remaining);
	}else{
		remaining = (decimal) inventoryList[key];
	}
	
	return remaining;
}

private
void updateHotListBomInventory(string prod, int sec, decimal qoh, Hashtable inventoryList){
	string key = prod + "_" + sec.ToString();

	if (inventoryList.ContainsKey(key))
		inventoryList.Remove(key);
	
	inventoryList.Add(key, qoh);
}

private 
decimal getMultValue(Bom bom, string mat, decimal initMult){
	BomContainer bomContainer = bom.getBomContainer();
	for(int i = 0; i < bomContainer.Count; i++){
		Bom bomit = (Bom) bomContainer[i];

		if (bomit.getProd().Equals(mat)){
			return initMult * bomit.getQty();
		}
	}

	for(int i = 0; i < bomContainer.Count; i++){
		Bom bomit = (Bom) bomContainer[i];
		decimal newMult = getMultValue(bomit, mat, initMult * bomit.getQty());
		if (newMult != 0)
			return newMult;
	}
	return 0;
}

public 
MaterialBomContainer generateMaterialListRecursive(string prodId, int seq){
	try{
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		InventoryContainer inventoryContainer = new InventoryContainer();
		DemDetailDataBaseContainer demandToProccess = new DemDetailDataBaseContainer(dataBaseAccess);
		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);

		MaterialBom materialBom = new MaterialBom();
		materialBom.setProdId(prodId);
		materialBom.setSeq(seq);
		materialBom.setQty(1);
		materialBom.setQoh(0);
		materialBom.setDateShip(DateTime.Now);
		
		Bom bom = makeBom(prodId, seq, prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer);
		CoreFactory coreFactory = UtilCoreFactory.createCoreFactory(UtilCoreFactory.LOCAL);

		decimal mult = 1;
		decimal remainingToCall = 1;
		string plt = "";
		decimal possible = 0;

		MaterialBomContainer materialBomContainer = new MaterialBomContainer();
		materialBomContainer = generateDemDetailBomRecursive2(bom, mult, 
			materialBomContainer, materialBom, plt, bom.getDepartament(), 
			materialBom.getDateShip(), remainingToCall, prodFmActSubDataBaseContainer,
			inventoryContainer, coreFactory, ref possible);

		materialBomContainer.setPossible(possible);

		return materialBomContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
MaterialBomContainer generateDemDetailBomRecursive2(Bom bom, decimal mult, 
		MaterialBomContainer materialBomContainer, 
		MaterialBom toCopy, string plt, string dept, 
		DateTime fromDate, decimal remaining,
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
		InventoryContainer inventoryContainer, CoreFactory coreFactory,
		ref decimal possible){

	decimal remainingToCall = 0;
	decimal qohToCall = 0;

	SchVersionDataBase schVersionDataBase = new SchVersionDataBase(dataBaseAccess);
	schVersionDataBase.setSCH_Plt(plt);
	schVersionDataBase.setSCH_Status("A");
	schVersionDataBase.readByPltActive();

	string schVersion = "";
	if (schVersionDataBase.getSCH_Version() != null)
		schVersion = schVersionDataBase.getSCH_Version();

	MaterialBom materialBom = new MaterialBom(toCopy);
	
	if (bom.getLevel() != 0){
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(bom.getProd());
		prodFmActPlanDataBase.setPAPL_Seq(bom.getSeq());

		prodFmActPlanDataBase.read();

		decimal PAPL_DayLT = prodFmActPlanDataBase.getPAPL_DayLT();
		decimal PAPL_HourLT = prodFmActPlanDataBase.getPAPL_HourLT();
		decimal PAPL_DayLTCum = prodFmActPlanDataBase.getPAPL_DayLTCum();
		decimal PAPL_HourLTCum = prodFmActPlanDataBase.getPAPL_HourLTCum();

		if (PAPL_DayLTCum != 0){
//			fromDate = fromDate.AddDays((-1) * double.Parse(PAPL_DayLTCum.ToString()));
			bool excludeSats = false;
			if (prodFmActPlanDataBase.getPAPL_ExcludeSats().Equals("Y"))
				excludeSats = true;
			bool excludeSuns = false;
			if (prodFmActPlanDataBase.getPAPL_ExcludeSuns().Equals("Y"))
				excludeSuns = true;
				
			fromDate = DateUtil.subtractDaysExcludeSatandSun(fromDate, 
				double.Parse(PAPL_DayLTCum.ToString()), excludeSats, excludeSuns);
		}

		if (!bom.isPurchased()){ // manufactured
			materialBom.setDept(bom.getDepartament());
			materialBom.setProdId(bom.getProd());
			materialBom.setSeq(bom.getSeq());
			materialBom.setDateShip(fromDate);
			materialBom.setQty(remaining * mult);
			materialBom.setProdType("M");
			materialBomContainer.Add(materialBom);

			Inventory inventory = inventoryContainer.getInventory(bom.getProd());
			if (inventory == null){
				inventory = coreFactory.readInventory(bom.getProd());
				inventoryContainer.Add(inventory);
			}

			qohToCall = inventory.getTotalInventory(bom.getSeq());
			if (qohToCall < 0)
				qohToCall = 0;

			materialBom.setQoh(qohToCall);

			decimal tempRemaining = remaining;
			
			possible = qohToCall / remaining * mult;

			string[][] invPltLocContainer = inventory.getInvPltLocAsString();
			for(int index = 0; index < invPltLocContainer.Length; index++){
				decimal auxQoh = decimal.Parse(invPltLocContainer[index][6]);
				if (auxQoh > tempRemaining){
					auxQoh = auxQoh - tempRemaining;
				}else{
					auxQoh = 0;
				}
				invPltLocContainer[index][6] = auxQoh.ToString();
			}

			inventory.setInvPltLocContainer(invPltLocContainer);
		}else{ // purchased
			string prodId = toCopy.getProdId();
			int prodSeq = toCopy.getSeq();
			string matProdId = bom.getProd();
			int matSeq = bom.getSeq();

			ProdFmActSubDataBase prodFmActSubDataBase = 
				prodFmActSubDataBaseContainer.getProdFmActSub(prodId, prodSeq);
			if (prodFmActSubDataBase == null){
				prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
				prodFmActSubDataBase.setPC_ProdID(prodId);
				prodFmActSubDataBase.setPC_Seq(prodSeq);
				if (prodFmActSubDataBase.exists()){
					prodFmActSubDataBase.read();
					prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);
				}else{
					throw new NujitException("The part " + prodId + " Sec " + prodSeq.ToString() + " is not present in ProdFmActSub table");
				}
			}

			string matDept = prodFmActSubDataBase.getPC_Dept();

			MaterialBom materialBomMat = new MaterialBom(matDept, matProdId, matSeq, fromDate, 0, 0, "P");

			if (coreFactory.existsInventory(matProdId)){
				Inventory inventory = coreFactory.readInventory(matProdId);
				qohToCall = inventory.getTotalInventory(0);
				if (qohToCall < 0)
					qohToCall = 0;

				materialBomMat.setQoh(qohToCall);
			}else{
				materialBomMat.setQoh(0);
			}
			
			possible = qohToCall / (remaining * mult);

			materialBom.setProdType("P");
			materialBomMat.setQty(remaining * mult);
			materialBomContainer.Add(materialBomMat);
		}
	}

	remainingToCall = remaining;

	decimal newpossible = -1;
	BomContainer bomContainer = bom.getBomContainer();
	for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		Bom bomAux = (Bom) en.Current;

		decimal newpossibletemp = 0;
		materialBomContainer = generateDemDetailBomRecursive2(bomAux, mult * bomAux.getQty(), 
			materialBomContainer, toCopy, plt, dept, fromDate, remainingToCall, 
			prodFmActSubDataBaseContainer, inventoryContainer, coreFactory, ref newpossibletemp);

		if (newpossibletemp < newpossible){
			newpossible = newpossibletemp;
		}else{
			if (newpossible == -1){
				newpossible = newpossibletemp;
			}
		}
	}

	if (newpossible == -1)
		newpossible = 0;

	possible += newpossible;
	return materialBomContainer;
}

//----------------------------------------------------------------------------------------------------------
private 
int getValidOption(){
	string[] logVector = this.getHotListLogData();
	
	DateTime today = DateUtil.parseDate(logVector[0].Substring(0, 10), DateUtil.MMDDYYYY);

	switch(today.DayOfWeek.ToString()){
	case "Monday":
		return 1;
    case "Tuesday":
		return 2;
    case "Wednesday":
		return 3;
    case "Thursday":
		return 4;
    case "Friday":
		return 5;
    case "Saturday":
		return 6;
    case "Sunday":
		return 7;
    }
    return 0;
}

public
string[][] geHotListTotals(int id1, int id2){
	try{
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(this.dataBaseAccess);

		string[][] v1 = hotListDataBaseContainer.getHotListTotalAsString(id1);
		string[][] v2 = hotListDataBaseContainer.getHotListTotalAsString(id2);

		Hashtable table = new Hashtable();

		for(int i = 0; i < v1.Length; i++){
			string dept = v1[i][0];
			string mach = v1[i][1];
			string key = dept + "_" + mach;

			if (!table.ContainsKey(key))
				table.Add(key, key);
		}

		for(int i = 0; i < v2.Length; i++){
			string dept = v2[i][0];
			string mach = v2[i][1];
			string key = dept + "_" + mach;

			if (!table.ContainsKey(key))
				table.Add(key, key);
		}

		int keyindex = 0;
		string[] vecKeys = new string[table.Count];
		for(IEnumerator en = table.GetEnumerator(); en.MoveNext(); ){
			DictionaryEntry de = (DictionaryEntry)en.Current;
			string key = (string)de.Value;
			vecKeys[keyindex] = key;
			keyindex++;
		}

		for(int i1 = 0; i1 < vecKeys.Length; i1++){
			for(int i2 = i1; i2 < vecKeys.Length; i2++){
				if (vecKeys[i2].CompareTo(vecKeys[i1]) < 0){
					string aux = vecKeys[i2];
					vecKeys[i2] = vecKeys[i1];
					vecKeys[i1] = aux;
				}
			}
		}

		int index = 0;
		string[][] totals = new string[table.Count * 2][];
		for(int i1 = 0; i1 < vecKeys.Length; i1++){
			string key = vecKeys[i1];

			string[] line1 = new string[0];
			if (v1.Length > 0)
				line1 = new string[v1[0].Length];
			else
				line1 = new string[v2[0].Length];

			for(int lineI = 0; lineI < line1.Length; lineI++)
				line1[lineI] = "0";

			line1[0] = "";

			string dept = key.Split('_')[0];
			string mach = key.Split('_')[1];

			for(int x = 0; x < v1.Length; x++){
				if ( (v1[x][0].Equals(dept)) && (v1[x][1].Equals(mach)) ){
					for(int lineI = 0; lineI < line1.Length; lineI++)
						line1[lineI] = v1[x][lineI];
					break;
				}
			}

			line1[0] = dept;
			line1[1] = mach;
			totals[index] = line1;
			index++;
			
			string[] line2 = new string[v2[0].Length];
			for(int lineI = 0; lineI < line2.Length; lineI++)
				line2[lineI] = "0";

			line2[0] = "";

			for(int x = 0; x < v2.Length; x++){
				if ( (v2[x][0].Equals(dept)) && (v2[x][1].Equals(mach)) ){
					for(int lineI = 0; lineI < line2.Length; lineI++)
						line2[lineI] = v2[x][lineI];
					break;
				}
			}

			line2[0] = dept;
			line2[1] = mach;
			totals[index] = line2;
			index++;
		}

		return totals;
   }catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

//----------------------------------------------------------------------------------------------------------

public 
string[][] getHotListBomReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
			bool onlyDemand, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint,
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp,
			bool orderByPart){

	try{
		if (id == 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
			 HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
			 id = hotListHdrDataBase.readLastId();
		}
		
		string finishedParts = "Y";

		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);

		if (byMinorGroup){
			hotListDataBaseContainer.readReportByMinGroup(id,filterDept, filterPart, filterMg, onlyDemand, finishedParts);
		}else{
			if (orderByResource){
				hotListDataBaseContainer.readReportByResource(id, filterDept, filterPart, filterMg, 
					onlyDemand, finishedParts);
			}else{
				if (orderByMajorMinorGrp){
					hotListDataBaseContainer.readReportByMajorMinorGroup(id, filterDept, filterPart, filterMg, onlyDemand, finishedParts);
				}else{
					if (orderByPart){
						hotListDataBaseContainer.readReportByPart(id, filterDept, filterPart, filterMg, onlyDemand, finishedParts);
					}else{
						hotListDataBaseContainer.readReportForBomHL(id, filterDept, filterPart, filterMg, onlyDemand, finishedParts);
					}
				}
			}
		}

		HotListDataBaseContainer depuredHotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		if (onlyReportingPoint){
			for(int i = 0; i < hotListDataBaseContainer.Count; i++){
				HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
				
				ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
				prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
				prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());

				if (prodFmActSubDataBase.exists()){
					prodFmActSubDataBase.read();
				}else{
					prodFmActSubDataBase.setPC_RepPoint("N");
				}

				if (prodFmActSubDataBase.getPC_RepPoint().Equals("Y")){
					depuredHotListDataBaseContainer.Add(hotListDataBase);
				}
			}
		}else{
			if (hoursReport){
				for(int i = 0; i < hotListDataBaseContainer.Count; i++){
					HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
					
					ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
					prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
					prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
					prodFmActSubDataBase.read();

					decimal runStd = prodFmActSubDataBase.getPC_RunStd();
					if (runStd == 0)
						runStd = 1;
					hotListDataBase.setHOT_Qoh(hotListDataBase.getHOT_Qoh() / runStd);
					hotListDataBase.setHOT_QohCml(hotListDataBase.getHOT_QohCml() / runStd);
					hotListDataBase.setHOT_PastDue(hotListDataBase.getHOT_PastDue() / runStd);

					hotListDataBase.setHOT_Day001(hotListDataBase.getHOT_Day001() / runStd);
					hotListDataBase.setHOT_Day002(hotListDataBase.getHOT_Day002() / runStd);
					hotListDataBase.setHOT_Day003(hotListDataBase.getHOT_Day003() / runStd);
					hotListDataBase.setHOT_Day004(hotListDataBase.getHOT_Day004() / runStd);
					hotListDataBase.setHOT_Day005(hotListDataBase.getHOT_Day005() / runStd);
					hotListDataBase.setHOT_Day006(hotListDataBase.getHOT_Day006() / runStd);
					hotListDataBase.setHOT_Day007(hotListDataBase.getHOT_Day007() / runStd);
					hotListDataBase.setHOT_Day008(hotListDataBase.getHOT_Day008() / runStd);
					hotListDataBase.setHOT_Day009(hotListDataBase.getHOT_Day009() / runStd);
					hotListDataBase.setHOT_Day010(hotListDataBase.getHOT_Day010() / runStd);

					hotListDataBase.setHOT_Day011(hotListDataBase.getHOT_Day011() / runStd);
					hotListDataBase.setHOT_Day012(hotListDataBase.getHOT_Day012() / runStd);
					hotListDataBase.setHOT_Day013(hotListDataBase.getHOT_Day013() / runStd);
					hotListDataBase.setHOT_Day014(hotListDataBase.getHOT_Day014() / runStd);
					hotListDataBase.setHOT_Day015(hotListDataBase.getHOT_Day015() / runStd);
					hotListDataBase.setHOT_Day016(hotListDataBase.getHOT_Day016() / runStd);
					hotListDataBase.setHOT_Day017(hotListDataBase.getHOT_Day017() / runStd);
					hotListDataBase.setHOT_Day018(hotListDataBase.getHOT_Day018() / runStd);
					hotListDataBase.setHOT_Day019(hotListDataBase.getHOT_Day019() / runStd);
					hotListDataBase.setHOT_Day020(hotListDataBase.getHOT_Day020() / runStd);

					hotListDataBase.setHOT_Day021(hotListDataBase.getHOT_Day021() / runStd);
					hotListDataBase.setHOT_Day022(hotListDataBase.getHOT_Day022() / runStd);
					hotListDataBase.setHOT_Day023(hotListDataBase.getHOT_Day023() / runStd);
					hotListDataBase.setHOT_Day024(hotListDataBase.getHOT_Day024() / runStd);
					hotListDataBase.setHOT_Day025(hotListDataBase.getHOT_Day025() / runStd);
					hotListDataBase.setHOT_Day026(hotListDataBase.getHOT_Day026() / runStd);
					hotListDataBase.setHOT_Day027(hotListDataBase.getHOT_Day027() / runStd);
					hotListDataBase.setHOT_Day028(hotListDataBase.getHOT_Day028() / runStd);
					hotListDataBase.setHOT_Day029(hotListDataBase.getHOT_Day029() / runStd);
					hotListDataBase.setHOT_Day030(hotListDataBase.getHOT_Day030() / runStd);

					hotListDataBase.setHOT_Day031(hotListDataBase.getHOT_Day031() / runStd);
					hotListDataBase.setHOT_Day032(hotListDataBase.getHOT_Day032() / runStd);
					hotListDataBase.setHOT_Day033(hotListDataBase.getHOT_Day033() / runStd);
					hotListDataBase.setHOT_Day034(hotListDataBase.getHOT_Day034() / runStd);
					hotListDataBase.setHOT_Day035(hotListDataBase.getHOT_Day035() / runStd);
					hotListDataBase.setHOT_Day036(hotListDataBase.getHOT_Day036() / runStd);
					hotListDataBase.setHOT_Day037(hotListDataBase.getHOT_Day037() / runStd);
					hotListDataBase.setHOT_Day038(hotListDataBase.getHOT_Day038() / runStd);
					hotListDataBase.setHOT_Day039(hotListDataBase.getHOT_Day039() / runStd);
					hotListDataBase.setHOT_Day040(hotListDataBase.getHOT_Day040() / runStd);

					hotListDataBase.setHOT_Day041(hotListDataBase.getHOT_Day041() / runStd);
					hotListDataBase.setHOT_Day042(hotListDataBase.getHOT_Day042() / runStd);
					hotListDataBase.setHOT_Day043(hotListDataBase.getHOT_Day043() / runStd);
					hotListDataBase.setHOT_Day044(hotListDataBase.getHOT_Day044() / runStd);
					hotListDataBase.setHOT_Day045(hotListDataBase.getHOT_Day045() / runStd);
					hotListDataBase.setHOT_Day046(hotListDataBase.getHOT_Day046() / runStd);
					hotListDataBase.setHOT_Day047(hotListDataBase.getHOT_Day047() / runStd);
					hotListDataBase.setHOT_Day048(hotListDataBase.getHOT_Day048() / runStd);
					hotListDataBase.setHOT_Day049(hotListDataBase.getHOT_Day049() / runStd);
					hotListDataBase.setHOT_Day050(hotListDataBase.getHOT_Day050() / runStd);

					hotListDataBase.setHOT_Day051(hotListDataBase.getHOT_Day051() / runStd);
					hotListDataBase.setHOT_Day052(hotListDataBase.getHOT_Day052() / runStd);
					hotListDataBase.setHOT_Day053(hotListDataBase.getHOT_Day053() / runStd);
					hotListDataBase.setHOT_Day054(hotListDataBase.getHOT_Day054() / runStd);
					hotListDataBase.setHOT_Day055(hotListDataBase.getHOT_Day055() / runStd);
					hotListDataBase.setHOT_Day056(hotListDataBase.getHOT_Day056() / runStd);
					hotListDataBase.setHOT_Day057(hotListDataBase.getHOT_Day057() / runStd);
					hotListDataBase.setHOT_Day058(hotListDataBase.getHOT_Day058() / runStd);
					hotListDataBase.setHOT_Day059(hotListDataBase.getHOT_Day059() / runStd);
					hotListDataBase.setHOT_Day060(hotListDataBase.getHOT_Day060() / runStd);

					hotListDataBase.setHOT_Day061(hotListDataBase.getHOT_Day061() / runStd);
					hotListDataBase.setHOT_Day062(hotListDataBase.getHOT_Day062() / runStd);
					hotListDataBase.setHOT_Day063(hotListDataBase.getHOT_Day063() / runStd);
					hotListDataBase.setHOT_Day064(hotListDataBase.getHOT_Day064() / runStd);
					hotListDataBase.setHOT_Day065(hotListDataBase.getHOT_Day065() / runStd);
					hotListDataBase.setHOT_Day066(hotListDataBase.getHOT_Day066() / runStd);
					hotListDataBase.setHOT_Day067(hotListDataBase.getHOT_Day067() / runStd);
					hotListDataBase.setHOT_Day068(hotListDataBase.getHOT_Day068() / runStd);
					hotListDataBase.setHOT_Day069(hotListDataBase.getHOT_Day069() / runStd);
					hotListDataBase.setHOT_Day070(hotListDataBase.getHOT_Day070() / runStd);

					hotListDataBase.setHOT_Day071(hotListDataBase.getHOT_Day071() / runStd);
					hotListDataBase.setHOT_Day072(hotListDataBase.getHOT_Day072() / runStd);
					hotListDataBase.setHOT_Day073(hotListDataBase.getHOT_Day073() / runStd);
					hotListDataBase.setHOT_Day074(hotListDataBase.getHOT_Day074() / runStd);
					hotListDataBase.setHOT_Day075(hotListDataBase.getHOT_Day075() / runStd);
					hotListDataBase.setHOT_Day076(hotListDataBase.getHOT_Day076() / runStd);
					hotListDataBase.setHOT_Day077(hotListDataBase.getHOT_Day077() / runStd);
					hotListDataBase.setHOT_Day078(hotListDataBase.getHOT_Day078() / runStd);
					hotListDataBase.setHOT_Day079(hotListDataBase.getHOT_Day079() / runStd);
					hotListDataBase.setHOT_Day080(hotListDataBase.getHOT_Day080() / runStd);

					hotListDataBase.setHOT_Day081(hotListDataBase.getHOT_Day081() / runStd);
					hotListDataBase.setHOT_Day082(hotListDataBase.getHOT_Day082() / runStd);
					hotListDataBase.setHOT_Day083(hotListDataBase.getHOT_Day083() / runStd);
					hotListDataBase.setHOT_Day084(hotListDataBase.getHOT_Day084() / runStd);
					hotListDataBase.setHOT_Day085(hotListDataBase.getHOT_Day085() / runStd);
					hotListDataBase.setHOT_Day086(hotListDataBase.getHOT_Day086() / runStd);
					hotListDataBase.setHOT_Day087(hotListDataBase.getHOT_Day087() / runStd);
					hotListDataBase.setHOT_Day088(hotListDataBase.getHOT_Day088() / runStd);
					hotListDataBase.setHOT_Day089(hotListDataBase.getHOT_Day089() / runStd);
					hotListDataBase.setHOT_Day090(hotListDataBase.getHOT_Day090() / runStd);

					depuredHotListDataBaseContainer.Add(hotListDataBase);
				}
			}else{
				if (labourReport){
//Qty Required divided by piece/hr * (qty of Machines/# of Men) = total labour hours
					for(int i = 0; i < hotListDataBaseContainer.Count; i++){
						HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
						
						ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
						prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
						prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());
						prodFmActSubDataBase.read();

						decimal runStd = prodFmActSubDataBase.getPC_RunStd();
						decimal menQty = prodFmActSubDataBase.getPC_QtyMen();
						decimal machQty = prodFmActSubDataBase.getPC_QtyMachines();

						if (runStd == 0)
							runStd = 1;
						if (menQty == 0)
							menQty = 1;
						if (machQty == 0){
							machQty = 1;
							menQty = 1;
						}

						hotListDataBase.setHOT_Qoh((hotListDataBase.getHOT_Qoh() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_QohCml((hotListDataBase.getHOT_QohCml() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_PastDue((hotListDataBase.getHOT_PastDue() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day001((hotListDataBase.getHOT_Day001() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day002((hotListDataBase.getHOT_Day002() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day003((hotListDataBase.getHOT_Day003() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day004((hotListDataBase.getHOT_Day004() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day005((hotListDataBase.getHOT_Day005() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day006((hotListDataBase.getHOT_Day006() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day007((hotListDataBase.getHOT_Day007() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day008((hotListDataBase.getHOT_Day008() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day009((hotListDataBase.getHOT_Day009() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day010((hotListDataBase.getHOT_Day010() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day011((hotListDataBase.getHOT_Day011() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day012((hotListDataBase.getHOT_Day012() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day013((hotListDataBase.getHOT_Day013() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day014((hotListDataBase.getHOT_Day014() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day015((hotListDataBase.getHOT_Day015() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day016((hotListDataBase.getHOT_Day016() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day017((hotListDataBase.getHOT_Day017() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day018((hotListDataBase.getHOT_Day018() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day019((hotListDataBase.getHOT_Day019() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day020((hotListDataBase.getHOT_Day020() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day021((hotListDataBase.getHOT_Day021() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day022((hotListDataBase.getHOT_Day022() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day023((hotListDataBase.getHOT_Day023() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day024((hotListDataBase.getHOT_Day024() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day025((hotListDataBase.getHOT_Day025() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day026((hotListDataBase.getHOT_Day026() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day027((hotListDataBase.getHOT_Day027() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day028((hotListDataBase.getHOT_Day028() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day029((hotListDataBase.getHOT_Day029() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day030((hotListDataBase.getHOT_Day030() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day031((hotListDataBase.getHOT_Day031() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day032((hotListDataBase.getHOT_Day032() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day033((hotListDataBase.getHOT_Day033() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day034((hotListDataBase.getHOT_Day034() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day035((hotListDataBase.getHOT_Day035() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day036((hotListDataBase.getHOT_Day036() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day037((hotListDataBase.getHOT_Day037() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day038((hotListDataBase.getHOT_Day038() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day039((hotListDataBase.getHOT_Day039() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day040((hotListDataBase.getHOT_Day040() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day041((hotListDataBase.getHOT_Day041() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day042((hotListDataBase.getHOT_Day042() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day043((hotListDataBase.getHOT_Day043() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day044((hotListDataBase.getHOT_Day044() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day045((hotListDataBase.getHOT_Day045() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day046((hotListDataBase.getHOT_Day046() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day047((hotListDataBase.getHOT_Day047() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day048((hotListDataBase.getHOT_Day048() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day049((hotListDataBase.getHOT_Day049() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day050((hotListDataBase.getHOT_Day050() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day051((hotListDataBase.getHOT_Day051() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day052((hotListDataBase.getHOT_Day052() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day053((hotListDataBase.getHOT_Day053() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day054((hotListDataBase.getHOT_Day054() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day055((hotListDataBase.getHOT_Day055() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day056((hotListDataBase.getHOT_Day056() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day057((hotListDataBase.getHOT_Day057() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day058((hotListDataBase.getHOT_Day058() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day059((hotListDataBase.getHOT_Day059() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day060((hotListDataBase.getHOT_Day060() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day061((hotListDataBase.getHOT_Day061() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day062((hotListDataBase.getHOT_Day062() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day063((hotListDataBase.getHOT_Day063() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day064((hotListDataBase.getHOT_Day064() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day065((hotListDataBase.getHOT_Day065() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day066((hotListDataBase.getHOT_Day066() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day067((hotListDataBase.getHOT_Day067() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day068((hotListDataBase.getHOT_Day068() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day069((hotListDataBase.getHOT_Day069() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day070((hotListDataBase.getHOT_Day070() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day071((hotListDataBase.getHOT_Day071() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day072((hotListDataBase.getHOT_Day072() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day073((hotListDataBase.getHOT_Day073() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day074((hotListDataBase.getHOT_Day074() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day075((hotListDataBase.getHOT_Day075() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day076((hotListDataBase.getHOT_Day076() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day077((hotListDataBase.getHOT_Day077() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day078((hotListDataBase.getHOT_Day078() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day079((hotListDataBase.getHOT_Day079() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day080((hotListDataBase.getHOT_Day080() / runStd) / (machQty / menQty));

						hotListDataBase.setHOT_Day081((hotListDataBase.getHOT_Day081() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day082((hotListDataBase.getHOT_Day082() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day083((hotListDataBase.getHOT_Day083() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day084((hotListDataBase.getHOT_Day084() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day085((hotListDataBase.getHOT_Day085() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day086((hotListDataBase.getHOT_Day086() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day087((hotListDataBase.getHOT_Day087() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day088((hotListDataBase.getHOT_Day088() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day089((hotListDataBase.getHOT_Day089() / runStd) / (machQty / menQty));
						hotListDataBase.setHOT_Day090((hotListDataBase.getHOT_Day090() / runStd) / (machQty / menQty));

						depuredHotListDataBaseContainer.Add(hotListDataBase);
					}
				}else{
					depuredHotListDataBaseContainer = hotListDataBaseContainer;
				}
			}
		}

		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
		HotListDataBaseContainer depured2HotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);

		for(int z = 0; z < depuredHotListDataBaseContainer.Count; z++){
			HotListDataBase hotListDataBase = (HotListDataBase)depuredHotListDataBaseContainer[z];

			HotListDataBaseContainer allHotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
			allHotListDataBaseContainer.readByPart(id, hotListDataBase.getHOT_ProdID());

			HotListDataBaseContainer bomHotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);

			for(int y = 0; y < allHotListDataBaseContainer.Count; y++){
				HotListDataBase hlForBom = (HotListDataBase)allHotListDataBaseContainer[y];


				Bom bom = this.makeBom(hlForBom.getHOT_ProdID(), hlForBom.getHOT_Seq(), 
					prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer);
				bomHotListDataBaseContainer = makeHLBom(id, bom, bomHotListDataBaseContainer);
			}

			depured2HotListDataBaseContainer.AddRange(allHotListDataBaseContainer);
			depured2HotListDataBaseContainer.AddRange(bomHotListDataBaseContainer);
		}

		string[][] returnArray = new string[depured2HotListDataBaseContainer.Count][];

        if (accumOnFridays)
            specialAccum(returnArray, depured2HotListDataBaseContainer, hoursReport, labourReport);
        else
            communAccum(returnArray, depured2HotListDataBaseContainer, hoursReport, labourReport);
            
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//----------------------------------------------------------------------------------------------------------

HotListDataBaseContainer makeHLBom(int id, Bom bom, HotListDataBaseContainer bomHotListDataBaseContainer){
	BomContainer bomContainer = bom.getBomContainer();

	for(int i = bomContainer.Count - 1; i > -1; i--){
		Bom bom2 = (Bom)bomContainer[i];

		HotListDataBaseContainer forReadCont = new HotListDataBaseContainer(dataBaseAccess);
		forReadCont.readByPartSeq(id, bom2.getProd(), bom2.getSeq());

		for(int x = 0; x < forReadCont.Count; x++){
			HotListDataBase forReadRec = (HotListDataBase)forReadCont[x];
			forReadRec.setHOT_Level(bom2.getLevel() + 1);
			bomHotListDataBaseContainer.Add(forReadRec);
		}

		bomHotListDataBaseContainer = makeHLBom(id, bom2, bomHotListDataBaseContainer);
	}

	return bomHotListDataBaseContainer;
}

//----------------------------------------------------------------------------------------------------------

} // class

} // namespace