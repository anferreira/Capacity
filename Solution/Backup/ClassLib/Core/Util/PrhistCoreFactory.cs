using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class PrhistCoreFactory : PlantCoreFactory{

public 
PrhistCoreFactory():base(){
}

public 
ArrayList generateDeptsPrHist(string smode, DateTime dateBefore, DateTime dateAfter, string splant,
					string sshift, string sdept, string sresource, string spart, int seq){

	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		ArrayList arrayList = new ArrayList();
		PrhistDataBaseContainer	prhistDataBaseContainer = new PrhistDataBaseContainer(dataBaseAccess);

		PrhistDataBaseContainer	origPrhistDataBaseContainer = new PrhistDataBaseContainer(dataBaseAccess);
		origPrhistDataBaseContainer.generateProductionHistory(smode, dateBefore, dateAfter, splant, 
						sshift, sdept, sresource, spart, seq);

		for(int index = 0; index < origPrhistDataBaseContainer.Count; index++){
			PrhistDataBase orgPrhistDataBase = (PrhistDataBase) origPrhistDataBaseContainer[index];
			string key = DateUtil.getDateRepresentation(orgPrhistDataBase.getDWDATE(), DateUtil.MMDDYYYY) + "_" +
				orgPrhistDataBase.getDWSHFT().ToString() + "_" + orgPrhistDataBase.getDWDEPT() + "_" + 
				orgPrhistDataBase.getDWRESR() + "_" + orgPrhistDataBase.getDWPART() + "_" + 
				orgPrhistDataBase.getDWSEQN() + "_" + orgPrhistDataBase.getDWWREF() + "_" + 
				orgPrhistDataBase.getDWSGRP();

			int position = prhistDataBaseContainer.getFirstElementPosition(key);
			if (position != -1){
				PrhistDataBase sumPrhistDataBase = (PrhistDataBase) prhistDataBaseContainer[position];
				sumPrhistDataBase.setDWQTYC(sumPrhistDataBase.getDWQTYC() + orgPrhistDataBase.getDWQTYC());
				sumPrhistDataBase.setDWQTYS(sumPrhistDataBase.getDWQTYS() + orgPrhistDataBase.getDWQTYS());
			}else{
				prhistDataBaseContainer.Add(orgPrhistDataBase, key);
			}
		}
		

		string[][] items = new string[prhistDataBaseContainer.Count][];
		string[][] downCodes = getAllDownCodes();

		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		int i = 0;
		for(IEnumerator en = prhistDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PrhistDataBase prhistDataBase = (PrhistDataBase) en.Current;

			if (smode.Equals("R")){
				PsscDataBase psscDataBase = new PsscDataBase(dataBaseAccess);
				psscDataBase.setUZPLNT(prhistDataBase.getAAPLNT());
				psscDataBase.setUZPART(prhistDataBase.getDWPART());
				psscDataBase.setUZSEQ(decimal.ToInt32(prhistDataBase.getDWSEQN()));
				psscDataBase.read();

				decimal cost = psscDataBase.getUZL1LB() + psscDataBase.getUZL1BD() + psscDataBase.getUZL1MT() + 
					psscDataBase.getUZL1OT() + psscDataBase.getUZL1BV() + psscDataBase.getUZL2BF();

				if (prhistDataBase.getDWQTYS() > 0){
					ScrapDataBaseContainer scrapDataBaseContainer = new ScrapDataBaseContainer(dataBaseAccess);
					scrapDataBaseContainer.setBODATE(prhistDataBase.getDWDATE());
					scrapDataBaseContainer.setBOSHFT(prhistDataBase.getDWSHFT().ToString());
					scrapDataBaseContainer.setBODEPT(prhistDataBase.getDWDEPT());
					scrapDataBaseContainer.setBORESC(prhistDataBase.getDWRESR());
					scrapDataBaseContainer.setBOPART(prhistDataBase.getDWPART());
					scrapDataBaseContainer.setBOSEQN(prhistDataBase.getDWSEQN());
					scrapDataBaseContainer.readForPrHist();


					if (scrapDataBaseContainer.Count == 0){
						ProductionHistory productionHistory = new ProductionHistory(prhistDataBase.getDB(), prhistDataBase.getDWDEPT(),
									prhistDataBase.getDWRESR(),	prhistDataBase.getDWDATE(),	decimal.ToDouble(prhistDataBase.getDWSHFT()),
									prhistDataBase.getDWMODE(), prhistDataBase.getDWWREF(),	decimal.ToDouble(prhistDataBase.getDWSEQN()),	
									decimal.ToDouble(prhistDataBase.getDWTIME()), prhistDataBase.getDWPART(),
									decimal.ToDouble(prhistDataBase.getDWQTYC()), decimal.ToDouble(prhistDataBase.getDWQTYS()),	
									decimal.ToDouble(prhistDataBase.getDWRATE()), prhistDataBase.getDWSGRP(),
									prhistDataBase.getDWMAJG(), decimal.ToDouble(prhistDataBase.getDWFSYY()),	
									decimal.ToDouble(prhistDataBase.getDWFSPP()), 
									decimal.ToDouble(prhistDataBase.getDWCPRC()), 0,
									prhistDataBase.getAAPLNT(), "Total", 
									"Total Scrap");

						productionHistory.setCost(cost);
						arrayList.Add(productionHistory);
					}

					for(int index = 0; index < scrapDataBaseContainer.Count; index++){
						ScrapDataBase scrapDataBase = (ScrapDataBase)scrapDataBaseContainer[index];

						SprsnDataBase sprsnDataBase = new SprsnDataBase(dataBaseAccess);
						sprsnDataBase.setETRESN(scrapDataBase.getBOREAS());
						sprsnDataBase.read();
//System.Console.WriteLine("Scrap.BOQTYS : " + scrapDataBase.getBOQTYS().ToString());

						ProductionHistory productionHistory = new ProductionHistory(prhistDataBase.getDB(), prhistDataBase.getDWDEPT(),
									prhistDataBase.getDWRESR(),	prhistDataBase.getDWDATE(),	decimal.ToDouble(prhistDataBase.getDWSHFT()),
									prhistDataBase.getDWMODE(), prhistDataBase.getDWWREF(),	decimal.ToDouble(prhistDataBase.getDWSEQN()),	
									decimal.ToDouble(prhistDataBase.getDWTIME()), prhistDataBase.getDWPART(),
									decimal.ToDouble(prhistDataBase.getDWQTYC()), decimal.ToDouble(scrapDataBase.getBOQTYS()),	
									decimal.ToDouble(prhistDataBase.getDWRATE()), prhistDataBase.getDWSGRP(),
									prhistDataBase.getDWMAJG(), decimal.ToDouble(prhistDataBase.getDWFSYY()),	
									decimal.ToDouble(prhistDataBase.getDWFSPP()), 
									decimal.ToDouble(prhistDataBase.getDWCPRC()), 0,
									prhistDataBase.getAAPLNT(), sprsnDataBase.getETRESN(), 
									sprsnDataBase.getETDESC());

						productionHistory.setCost(cost);
						productionHistory.setQtys(decimal.ToDouble(scrapDataBase.getBOQTYS()));

						if (index != 0){
							productionHistory.setQtyc(0);
						}

						arrayList.Add(productionHistory);
					}

				}else{
					ProductionHistory productionHistory = new ProductionHistory(prhistDataBase.getDB(), prhistDataBase.getDWDEPT(),
								prhistDataBase.getDWRESR(),	prhistDataBase.getDWDATE(),	decimal.ToDouble(prhistDataBase.getDWSHFT()),
								prhistDataBase.getDWMODE(), prhistDataBase.getDWWREF(),	decimal.ToDouble(prhistDataBase.getDWSEQN()),	
								decimal.ToDouble(prhistDataBase.getDWTIME()), prhistDataBase.getDWPART(),
								decimal.ToDouble(prhistDataBase.getDWQTYC()), decimal.ToDouble(prhistDataBase.getDWQTYS()),	
								decimal.ToDouble(prhistDataBase.getDWRATE()), prhistDataBase.getDWSGRP(),
								prhistDataBase.getDWMAJG(), decimal.ToDouble(prhistDataBase.getDWFSYY()),	
								decimal.ToDouble(prhistDataBase.getDWFSPP()), 
								decimal.ToDouble(prhistDataBase.getDWCPRC()), 0,
								prhistDataBase.getAAPLNT(), "", "");
					productionHistory.setCost(0);
					productionHistory.setQtys(0);
					arrayList.Add(productionHistory);
				}
			}

			if (smode.Equals("D")){
				ProductionHistory productionHistory = new ProductionHistory(prhistDataBase.getDB(), prhistDataBase.getDWDEPT(),
							prhistDataBase.getDWRESR(),	prhistDataBase.getDWDATE(),	decimal.ToDouble(prhistDataBase.getDWSHFT()),
							prhistDataBase.getDWMODE(), prhistDataBase.getDWWREF(),	decimal.ToDouble(prhistDataBase.getDWSEQN()),	
							decimal.ToDouble(prhistDataBase.getDWTIME()), prhistDataBase.getDWPART(),
							decimal.ToDouble(prhistDataBase.getDWQTYC()), decimal.ToDouble(prhistDataBase.getDWQTYS()),	
							decimal.ToDouble(prhistDataBase.getDWRATE()), prhistDataBase.getDWSGRP(),
							prhistDataBase.getDWMAJG(), decimal.ToDouble(prhistDataBase.getDWFSYY()),	
							decimal.ToDouble(prhistDataBase.getDWFSPP()), 
							decimal.ToDouble(prhistDataBase.getDWCPRC()), 0,
							prhistDataBase.getAAPLNT(), "", "");

				productionHistory.setSDesc(getDescDownCodeDesc(downCodes, prhistDataBase.getDWWREF()));
				productionHistory.setCost(0);
				arrayList.Add(productionHistory);
			}

			i++;

//			if (i == 10)
//				break;
		}

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return arrayList;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getAllDownCodes(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		IndlbrDataBaseContainer indlbrDataBaseContainer = new IndlbrDataBaseContainer(dataBaseAccess);
		indlbrDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		string[][] v = new string[indlbrDataBaseContainer.Count][];

		for(int i = 0; i < indlbrDataBaseContainer.Count; i++){
			IndlbrDataBase indlbrDataBase = (IndlbrDataBase)indlbrDataBaseContainer[i];
			
			string[] line = new string[2];
			line[0] = indlbrDataBase.getAFCODE();
			line[1] = indlbrDataBase.getAFDES1();
			v[i] = line;
		}
		return v;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
decimal getCostFromPart(string part){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		PsscDataBase psscDataBase = new PsscDataBase(dataBaseAccess);
		psscDataBase.setUZPART(part);
		psscDataBase.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		decimal cost = psscDataBase.getUZL1LB() + psscDataBase.getUZL1BD() + psscDataBase.getUZL1MT() + 
			psscDataBase.getUZL1OT() + psscDataBase.getUZL1BV() + psscDataBase.getUZL2BF();

		return cost;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
string getDescDownCodeDesc(string[][] downCodes, string afcode){
	for(int i = 0; i < downCodes.Length; i++){
		if (downCodes[i][0].Equals(afcode))
			return downCodes[i][1];
	}
	return "";
}

} // class

} // namespace
