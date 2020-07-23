using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using System.Threading;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class CmsCoreFactory : CapacityCoreFactory{

protected
CmsCoreFactory() : base(){
}

//---------------------------------------------------------------------------

public
string[][] generateCMSInventory(string[] stkbFilter, string[] wipbFilter, 
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer){
	try{
#if !DEBUG
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		StkbDataBaseContainer stkbDataBaseContainer = new StkbDataBaseContainer(dataBaseAccess);
		if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "STKB"))
			stkbDataBaseContainer.read(stkbFilter);
		else
			throw new NujitException("Table STKB is locked !!!");

		WipbDataBaseContainer wipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "WIPB"))
			wipbDataBaseContainer.read(wipbFilter);
		else
			throw new NujitException("Table WIPB is locked !!!");

		SschDataBaseContainer sschDataBaseContainer = new SschDataBaseContainer(dataBaseAccess);
		if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "SSCH"))
			sschDataBaseContainer.read();
		else
			throw new NujitException("Table SSCH is locked !!!");

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		stkbDataBaseContainer.truncate();
		wipbDataBaseContainer.truncate();
		sschDataBaseContainer.truncate();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// writes records to database
		stkbDataBaseContainer.write();
		wipbDataBaseContainer.write();
		sschDataBaseContainer.write();
#else
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		StkbDataBaseContainer stkbDataBaseContainer = new StkbDataBaseContainer(dataBaseAccess);
		stkbDataBaseContainer.read(stkbFilter);

		WipbDataBaseContainer wipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		wipbDataBaseContainer.read(wipbFilter);

		SschDataBaseContainer sschDataBaseContainer = new SschDataBaseContainer(dataBaseAccess);
		sschDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
#endif
		WipbDataBaseContainer badWipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		WipbDataBaseContainer goodWipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = wipbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			WipbDataBase wipbDataBase = (WipbDataBase) en.Current;

			/*if (wipbDataBase.getVDPART().Equals("WIP-25897222"))
			{
				string a = "";
			}*/


			ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(wipbDataBase.getVDPART());
			if (prodFmInfoDataBase == null)
				continue;
				
			if (wipbDataBase.getVDSEQ() != prodFmInfoDataBase.getPFS_SeqLast()){
				goodWipbDataBaseContainer.Add(wipbDataBase);
				continue;
			}else{
				if (wipbDataBase.getVDQTOH() != 0){
					badWipbDataBaseContainer.Add(wipbDataBase);
					continue;
				}
			}
		}		
#if !DEBUG
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
#endif
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = goodWipbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			WipbDataBase wipbDataBase = (WipbDataBase) en.Current;

			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.setIPL_ProdID(wipbDataBase.getVDPART());
			invPltLocDataBase.setIPL_Seq(decimal.ToInt32(wipbDataBase.getVDSEQ()));
			invPltLocDataBase.setIPL_Qoh(wipbDataBase.getVDQTOH());
			invPltLocDataBase.setIPL_Uom(Constants.DEFAULT_UOM);
			invPltLocDataBase.setIPL_StkLoc(wipbDataBase.getVDSTOK());
		
			invPltLocDataBaseContainer.Add(invPltLocDataBase);
		}
	
		for(IEnumerator en = stkbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			StkbDataBase stkbDataBase = (StkbDataBase) en.Current;

			ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(stkbDataBase.getBXPART());
			if (prodFmInfoDataBase == null)
				continue;

			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.setIPL_ProdID(stkbDataBase.getBXPART());
			invPltLocDataBase.setIPL_Seq(prodFmInfoDataBase.getPFS_SeqLast());
			invPltLocDataBase.setIPL_Qoh(stkbDataBase.getBXQTOH());
			invPltLocDataBase.setIPL_Uom(Constants.DEFAULT_UOM);
			invPltLocDataBase.setIPL_StkLoc(stkbDataBase.getBXSTOK());
		
			invPltLocDataBaseContainer.Add(invPltLocDataBase);
		}

		SchDemDetailDataBaseContainer schDemDetailDataBaseContainer = new SchDemDetailDataBaseContainer(dataBaseAccess);
		DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = sschDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SschDataBase sschDataBase = (SschDataBase) en.Current;

			DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);

			demDetailDataBase.setDEDT_OrdID(sschDataBase.getJYORDR());
			demDetailDataBase.setDEDT_ItemID(sschDataBase.getJYITEM());
			demDetailDataBase.setDEDT_RLID(sschDataBase.getJYRELN());
			demDetailDataBase.setDEDT_BusLoc(sschDataBase.getJYSCUS());
			demDetailDataBase.setDEDT_ProdID(sschDataBase.getJYPART());
			demDetailDataBase.setDEDT_QtyID(sschDataBase.getJYSQTY());
			demDetailDataBase.setDEDT_CumID(sschDataBase.getJYCUMQ());
            
            //Date: 05/12/2005 
            //Change by: Claudia Melo
            //Requested by: Mauricio and Chuck.
            //JYDATE includes Lead-Time - JYODAT did't include
            demDetailDataBase.setDEDT_DtShip(sschDataBase.getJYDATE());
			//demDetailDataBase.setDEDT_DtShip(sschDataBase.getJYODAT()); 

			demDetailDataBase.setDEDT_InvLoc(sschDataBase.getJYSTKL());
			demDetailDataBase.setDEDT_ShipTm(sschDataBase.getJYTIME());

			// skip past due --> done for Icon Sept 21 th
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			DateTime shipDate = new DateTime(demDetailDataBase.getDEDT_DtShip().Year, demDetailDataBase.getDEDT_DtShip().Month, demDetailDataBase.getDEDT_DtShip().Day);

			if (Configuration.IgnorePastDue){
				if (shipDate.CompareTo(today) < 0){
					continue;
				}
			}

			demDetailDataBaseContainer.Add(demDetailDataBase);
			schDemDetailDataBaseContainer.Add(new SchDemDetailDataBase(demDetailDataBase));
		}

#if !DEBUG
		invPltLocDataBaseContainer.truncate();
		demDetailDataBaseContainer.truncate();
		schDemDetailDataBaseContainer.truncate();

		invPltLocDataBaseContainer.write();
		demDetailDataBaseContainer.write();
		schDemDetailDataBaseContainer.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
#endif
		int i = 0;
		string[][] badWipb = new string[badWipbDataBaseContainer.Count][];
		for(IEnumerator en = badWipbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			WipbDataBase badWipbDataBase = (WipbDataBase) en.Current;
			ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(badWipbDataBase.getVDPART());
			
			string[] line = new string[4];
			line[0] = badWipbDataBase.getVDPART();
			line[1] = badWipbDataBase.getVDSEQ().ToString();
			line[2] = prodFmInfoDataBase.getPFS_Des1();
			line[3] = badWipbDataBase.getVDQTOH().ToString();
			badWipb[i] = line;
			i++;
		}

		return badWipb;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempInventory(string[] stkbFilter, string[] wipbFilter,
			StkbDataBaseContainer stkbDataBaseContainer,
			WipbDataBaseContainer wipbDataBaseContainer,
			SschDataBaseContainer sschDataBaseContainer,
			ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		stkbDataBaseContainer.read(stkbFilter);
		wipbDataBaseContainer.read(wipbFilter);
		sschDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		stkbDataBaseContainer.truncate();
		wipbDataBaseContainer.truncate();
		sschDataBaseContainer.truncate();

		// writes records to database
		stkbDataBaseContainer.write();
		wipbDataBaseContainer.write();
		sschDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return stkbDataBaseContainer.Count + wipbDataBaseContainer.Count + sschDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempInventory(string[] stkbFilter, string[] wipbFilter,
			ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer){
	try{
		StkbDataBaseContainer stkbDataBaseContainer = new StkbDataBaseContainer(dataBaseAccess);
		WipbDataBaseContainer wipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		SschDataBaseContainer sschDataBaseContainer = new SschDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempInventory(stkbFilter, wipbFilter, stkbDataBaseContainer, 
			wipbDataBaseContainer, sschDataBaseContainer, prodFmInfoDataBaseContainer);

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		return stkbDataBaseContainer.Count + wipbDataBaseContainer.Count + sschDataBaseContainer.Count;
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

protected
int cmsTempToNujitInventory(string[] stkbFilter, string[] wipbFilter, ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer){
	try{
		StkbDataBaseContainer stkbDataBaseContainer = new StkbDataBaseContainer(dataBaseAccess);
		WipbDataBaseContainer wipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		SschDataBaseContainer sschDataBaseContainer = new SschDataBaseContainer(dataBaseAccess);
		
		return cmsTempToNujitInventory(stkbFilter, wipbFilter, stkbDataBaseContainer, 
			wipbDataBaseContainer, sschDataBaseContainer, prodFmInfoDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitInventory(string[] stkbFilter, string[] wipbFilter,
			StkbDataBaseContainer stkbDataBaseContainer,
			WipbDataBaseContainer wipbDataBaseContainer,
			SschDataBaseContainer sschDataBaseContainer,
			ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer){

	try{
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (stkbDataBaseContainer.Count == 0)
			stkbDataBaseContainer.read(stkbFilter);

		if (wipbDataBaseContainer.Count == 0)
			wipbDataBaseContainer.read(wipbFilter);

		if (sschDataBaseContainer.Count == 0)
			sschDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		Hashtable control = new Hashtable();
		WipbDataBaseContainer goodWipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = wipbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			WipbDataBase wipbDataBase = (WipbDataBase) en.Current;
			ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(wipbDataBase.getVDPART());
				
			if ((prodFmInfoDataBase == null) || (wipbDataBase.getVDSEQ() != prodFmInfoDataBase.getPFS_SeqLast())){
				goodWipbDataBaseContainer.Add(wipbDataBase);
				continue;
			}

			bool insert = true;

			for(IEnumerator en2 = stkbDataBaseContainer.GetEnumerator(); insert && en2.MoveNext(); ){
				StkbDataBase stkbDataBase = (StkbDataBase) en2.Current;
				
				if (prodFmInfoDataBase != null){
					if ((stkbDataBase.getBXPART().Trim().Equals(wipbDataBase.getVDPART().Trim()))){
						decimal inv = stkbDataBase.getBXQTOH();
						inv += wipbDataBase.getVDQTOH();
						stkbDataBase.setBXQTOH(inv);
						insert = false;
					}
				}
			}
			
			if (insert && !control.ContainsKey(wipbDataBase.GetHashCode())){
				goodWipbDataBaseContainer.Add(wipbDataBase);
				control.Add(wipbDataBase.GetHashCode(), wipbDataBase.GetHashCode());
			}
		}		

		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = goodWipbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			WipbDataBase wipbDataBase = (WipbDataBase) en.Current;

			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.setIPL_ProdID(wipbDataBase.getVDPART());
			invPltLocDataBase.setIPL_Seq(decimal.ToInt32(wipbDataBase.getVDSEQ()));
			invPltLocDataBase.setIPL_Qoh(wipbDataBase.getVDQTOH());
			invPltLocDataBase.setIPL_Uom(Constants.DEFAULT_UOM);
			invPltLocDataBase.setIPL_StkLoc(wipbDataBase.getVDSTOK());
		
			invPltLocDataBaseContainer.Add(invPltLocDataBase);
		}
	
		for(IEnumerator en = stkbDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			StkbDataBase stkbDataBase = (StkbDataBase) en.Current;

			ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(stkbDataBase.getBXPART());
			if (prodFmInfoDataBase == null)
				continue;
			
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.setIPL_ProdID(stkbDataBase.getBXPART());
			invPltLocDataBase.setIPL_Seq(prodFmInfoDataBase.getPFS_SeqLast());
			invPltLocDataBase.setIPL_Qoh(stkbDataBase.getBXQTOH());
			invPltLocDataBase.setIPL_Uom(Constants.DEFAULT_UOM);
			invPltLocDataBase.setIPL_StkLoc(stkbDataBase.getBXSTOK());
		
			invPltLocDataBaseContainer.Add(invPltLocDataBase);
		}

		DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = sschDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SschDataBase sschDataBase = (SschDataBase) en.Current;

			DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);

			demDetailDataBase.setDEDT_OrdID(sschDataBase.getJYORDR());
			demDetailDataBase.setDEDT_ItemID(sschDataBase.getJYITEM());
			demDetailDataBase.setDEDT_RLID(sschDataBase.getJYRELN());
			demDetailDataBase.setDEDT_BusLoc(sschDataBase.getJYSCUS());
			demDetailDataBase.setDEDT_ProdID(sschDataBase.getJYPART());
			demDetailDataBase.setDEDT_QtyID(sschDataBase.getJYSQTY());
			demDetailDataBase.setDEDT_CumID(sschDataBase.getJYCUMQ());
			
            //Date: 05/12/2005 
            //Change by: Claudia Melo
            //Requested by: Mauricio and Chuck.
            //JYDATE includes Lead-Time - JYODAT did't include. 
            demDetailDataBase.setDEDT_DtShip(sschDataBase.getJYDATE());
			//demDetailDataBase.setDEDT_DtShip(sschDataBase.getJYODAT()); 
			demDetailDataBase.setDEDT_DtShip(sschDataBase.getJYODAT());
			demDetailDataBase.setDEDT_InvLoc(sschDataBase.getJYSTKL());
			demDetailDataBase.setDEDT_ShipTm(sschDataBase.getJYTIME());

			// skip past due --> done for Icon Sept 21 th
			DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			DateTime shipDate = new DateTime(demDetailDataBase.getDEDT_DtShip().Year, demDetailDataBase.getDEDT_DtShip().Month, demDetailDataBase.getDEDT_DtShip().Day);

			if (Configuration.IgnorePastDue){
				if (shipDate.CompareTo(today) < 0){
					continue;
				}
			}

			demDetailDataBaseContainer.Add(demDetailDataBase);
		}
		
		invPltLocDataBaseContainer.truncate();
		demDetailDataBaseContainer.truncate();

		invPltLocDataBaseContainer.write();
		demDetailDataBaseContainer.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return invPltLocDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//---------------------------------------------------------------------------

public
int cms400ToCmsTempItems(){
	try{
		StkMMDataBaseContainer stkMMDataBaseContainer = new StkMMDataBaseContainer(dataBaseAccess);
		StkMPDataBaseContainer stkMPDataBaseContainer = new StkMPDataBaseContainer(dataBaseAccess);
		MetHdrDataBaseContainer metHdrDataBaseContainer = new MetHdrDataBaseContainer(dataBaseAccess);
		MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
		PopTvnDataBaseContainer popTvnDataBaseContainer = new PopTvnDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempItems(stkMMDataBaseContainer, stkMPDataBaseContainer, 
			metHdrDataBaseContainer, metHdmDataBaseContainer, popTvnDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempItems(StkMMDataBaseContainer stkMMDataBaseContainer,
		StkMPDataBaseContainer stkMPDataBaseContainer, 
		MetHdrDataBaseContainer metHdrDataBaseContainer,
		MetHdmDataBaseContainer metHdmDataBaseContainer,
		PopTvnDataBaseContainer popTvnDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		stkMMDataBaseContainer.read();
		stkMPDataBaseContainer.read();
		metHdrDataBaseContainer.read();
		metHdmDataBaseContainer.read();
		popTvnDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		stkMMDataBaseContainer.truncate();
		stkMPDataBaseContainer.truncate();
		metHdrDataBaseContainer.truncate();
		metHdmDataBaseContainer.truncate();
		popTvnDataBaseContainer.truncate();
			
		stkMMDataBaseContainer.write();
		stkMPDataBaseContainer.write();
		metHdrDataBaseContainer.write();
		metHdmDataBaseContainer.write();
		popTvnDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return stkMMDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitItems(){
	try{
		StkMMDataBaseContainer stkMMDataBaseContainer = new StkMMDataBaseContainer(dataBaseAccess);
		StkMPDataBaseContainer stkMPDataBaseContainer = new StkMPDataBaseContainer(dataBaseAccess);
		MetHdrDataBaseContainer metHdrDataBaseContainer = new MetHdrDataBaseContainer(dataBaseAccess);
		MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
		PopTvnDataBaseContainer popTvnDataBaseContainer = new PopTvnDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitItems(stkMMDataBaseContainer, stkMPDataBaseContainer,
			metHdrDataBaseContainer, metHdmDataBaseContainer, popTvnDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitItems(StkMMDataBaseContainer stkMMDataBaseContainer,
		StkMPDataBaseContainer stkMPDataBaseContainer, 
		MetHdrDataBaseContainer metHdrDataBaseContainer,
		MetHdmDataBaseContainer metHdmDataBaseContainer,
		PopTvnDataBaseContainer popTvnDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (stkMMDataBaseContainer.Count == 0)
			stkMMDataBaseContainer.read();
		
		if (stkMPDataBaseContainer.Count == 0)
			stkMPDataBaseContainer.read();

		if (metHdrDataBaseContainer.Count == 0)
			metHdrDataBaseContainer.read();

		if (metHdmDataBaseContainer.Count == 0)
			metHdmDataBaseContainer.read();
		
		if (popTvnDataBaseContainer.Count == 0)
			popTvnDataBaseContainer.read();

		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		ProdFmActHDataBaseContainer prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainerFromAs400 = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		SuppProductCrossDataBaseContainer suppProductCrossDataBaseContainer = new SuppProductCrossDataBaseContainer(dataBaseAccess);

		for(IEnumerator en = stkMPDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			StkMPDataBase stkMPDataBase = (StkMPDataBase) en.Current;

			// ProdFmInfo
			ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
			prodFmInfoDataBase.setPFS_ProdID(stkMPDataBase.getAWPART());
			prodFmInfoDataBase.setPFS_Des1(stkMPDataBase.getAWDES1());
			prodFmInfoDataBase.setPFS_Des2(stkMPDataBase.getAWDES2());
			prodFmInfoDataBase.setPFS_Des3(stkMPDataBase.getAWDES3());
			prodFmInfoDataBase.setPFS_SeqLast(0);
			prodFmInfoDataBase.setPFS_FamProd("P");
			prodFmInfoDataBase.setPFS_VarFam("");
			prodFmInfoDataBase.setPFS_ActIDLast("");
			prodFmInfoDataBase.setPFS_PartType("P");
			prodFmInfoDataBase.setPFS_InvStatus(stkMPDataBase.getAWSTAT());
			prodFmInfoDataBase.setPFS_ABCCode(stkMPDataBase.getAWABCC());
			prodFmInfoDataBase.setPFS_MajorGroup(stkMPDataBase.getAWMAJG());
			prodFmInfoDataBase.setPFS_MinorGroup(stkMPDataBase.getAWMING());
			prodFmInfoDataBase.setPFS_GLExp(stkMPDataBase.getAWGLED());
			prodFmInfoDataBase.setPFS_GLDistr(stkMPDataBase.getAWGLDC());
			prodFmInfoDataBase.setPFS_MajorSales(stkMPDataBase.getAWMAJS());
			prodFmInfoDataBase.setPFS_MinorSales(stkMPDataBase.getAWMINS());
			prodFmInfoDataBase.setPFS_LastRevision(stkMPDataBase.getAWLDAT());
			prodFmInfoDataBase.setPFS_RetailProductType(stkMPDataBase.getAWBK04());
			prodFmInfoDataBase.setPFS_StdPackSize(stkMPDataBase.getAWPACK());
			prodFmInfoDataBase.setPFS_StdPackUnit(stkMPDataBase.getAWPACU());

			prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());

			// SuppProductCross
			string jrpt = stkMPDataBase.getAWPART(); // part number
			int jrseq = 0; // sequence
//			int jrvpts = 0; // Vendor Part Sequence
			string jrvnd = stkMPDataBase.getAWVEND(); // vendor number
			string suppPart = stkMPDataBase.getAWVPT();
			int priority = 1;

			PopTvnDataBaseContainer searchItems = popTvnDataBaseContainer.getPopTvnDataBaseContainer(jrpt);
			if (searchItems.Count != 0){
				for(IEnumerator ie = searchItems.GetEnumerator(); ie.MoveNext(); ){
					PopTvnDataBase popTvnDataBase = (PopTvnDataBase) ie.Current;
					
					SuppProductCrossDataBase suppProductCrossDataBase = new SuppProductCrossDataBase(dataBaseAccess);
					suppProductCrossDataBase.setSP_SupplierNum(popTvnDataBase.getJRVND());
					suppProductCrossDataBase.setSP_ProdID(popTvnDataBase.getJRPT());
					suppProductCrossDataBase.setSP_Seq(decimal.ToInt32(popTvnDataBase.getJRSEQ()));
					suppProductCrossDataBase.setSP_SupplierPart(popTvnDataBase.getJRVPT());

					priority = decimal.ToInt32(popTvnDataBase.getJRPRYS());
					suppProductCrossDataBase.setSP_Priority(priority);
					
					suppProductCrossDataBaseContainer.Add(suppProductCrossDataBase);
				}
			}else{
				SuppProductCrossDataBase suppProductCrossDataBase = new SuppProductCrossDataBase(dataBaseAccess);
				suppProductCrossDataBase.setSP_SupplierNum(jrvnd);
				suppProductCrossDataBase.setSP_ProdID(jrpt);
				suppProductCrossDataBase.setSP_Seq(jrseq);
				suppProductCrossDataBase.setSP_SupplierPart(suppPart);
				suppProductCrossDataBase.setSP_Priority(priority);
				suppProductCrossDataBaseContainer.Add(suppProductCrossDataBase);
			}
		}

		for(IEnumerator en = stkMMDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			StkMMDataBase stkMMDataBase = (StkMMDataBase) en.Current;
			ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
			prodFmInfoDataBase.setPFS_ProdID(stkMMDataBase.getAVPART().Trim());
			prodFmInfoDataBase.setPFS_Des1(stkMMDataBase.getAVDES1().Trim());
			prodFmInfoDataBase.setPFS_Des2(stkMMDataBase.getAVDES2().Trim());
			prodFmInfoDataBase.setPFS_Des3(stkMMDataBase.getAVDES3().Trim());

			decimal greater = 0;
			for(IEnumerator en2 = metHdrDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				MetHdrDataBase metHdrDataBase = (MetHdrDataBase) en2.Current;
				if (metHdrDataBase.getAOPART().Trim().Equals(stkMMDataBase.getAVPART().Trim()) &&
						(metHdrDataBase.getAOSEQ() > greater)){
					greater = metHdrDataBase.getAOSEQ();
				}
			}
			
			prodFmInfoDataBase.setPFS_SeqLast(Decimal.ToInt32(greater));
			prodFmInfoDataBase.setPFS_FamProd("P");
			prodFmInfoDataBase.setPFS_VarFam("");
			prodFmInfoDataBase.setPFS_ActIDLast("");

			prodFmInfoDataBase.setPFS_PartType("M");
			prodFmInfoDataBase.setPFS_InvStatus(stkMMDataBase.getAVSTAT());
			prodFmInfoDataBase.setPFS_ABCCode(stkMMDataBase.getAVABCC());
			prodFmInfoDataBase.setPFS_MajorGroup(stkMMDataBase.getAVMAJG());
			prodFmInfoDataBase.setPFS_MinorGroup(stkMMDataBase.getAVMING());
			prodFmInfoDataBase.setPFS_GLExp(stkMMDataBase.getAVGLED());
			prodFmInfoDataBase.setPFS_GLDistr(stkMMDataBase.getAVGLCD());
			prodFmInfoDataBase.setPFS_MajorSales(stkMMDataBase.getAVMAJS());
			prodFmInfoDataBase.setPFS_MinorSales(stkMMDataBase.getAVMINS());
			prodFmInfoDataBase.setPFS_LastRevision(stkMMDataBase.getAVLDAT());
			prodFmInfoDataBase.setPFS_RetailProductType(stkMMDataBase.getAVBK04());
			prodFmInfoDataBase.setPFS_StdPackSize(stkMMDataBase.getAVPACK());
			prodFmInfoDataBase.setPFS_StdPackUnit(stkMMDataBase.getAVPACU());

			prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
		}

		for(IEnumerator en = metHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			MetHdrDataBase metHdrDataBase = (MetHdrDataBase) en.Current;
			
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.setPAH_ProdID(metHdrDataBase.getAOPART());
			prodFmActHDataBase.setPAH_Seq(decimal.ToInt32(metHdrDataBase.getAOSEQ()));
			prodFmActHDataBaseContainer.Add(prodFmActHDataBase, prodFmActHDataBase.getPAH_ProdID().Trim());

			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.setPC_ProdID(metHdrDataBase.getAOPART());
			prodFmActSubDataBase.setPC_Seq(decimal.ToInt32(metHdrDataBase.getAOSEQ()));
			prodFmActSubDataBase.setPC_Cfg(metHdrDataBase.getAORESC());
			prodFmActSubDataBase.setPC_RunStd(metHdrDataBase.getAORUNS());
			prodFmActSubDataBase.setPC_CycleTm(metHdrDataBase.getAOCTME());
			prodFmActSubDataBase.setPC_CavityNum(metHdrDataBase.getAOMULT());
			prodFmActSubDataBase.setPC_CavAvail(metHdrDataBase.getAOMULT());
			prodFmActSubDataBase.setPC_Dept(metHdrDataBase.getAODEPT());
			prodFmActSubDataBase.setPC_RepPoint(metHdrDataBase.getAOREPP());
			prodFmActSubDataBase.setPC_QtyMen(decimal.ToInt32(metHdrDataBase.getAO_MEN()));
			prodFmActSubDataBase.setPC_QtyMachines(decimal.ToInt32(metHdrDataBase.getAO_MCH()));

			PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			pltDeptDataBase.setDE_Dept(metHdrDataBase.getAODEPT());
			pltDeptDataBase.readByDept();

			prodFmActSubDataBase.setPC_Plt(pltDeptDataBase.getDE_Plt());
			prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);
		}

		for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase) en.Current;
			ProdFmActHDataBaseContainer secuences = 
				prodFmActHDataBaseContainer.getByProd(prodFmInfoDataBase.getPFS_ProdID().Trim());

			//int planDays = int.Parse(Configuration.PlanDays);
			//int cumDays = 0;

			for(int count = secuences.Count - 1; count > -1; count--){
				ProdFmActHDataBase prodFmActHDataBase = (ProdFmActHDataBase) secuences[count];

                ProdFmActPlanDataBase prodFmActPlanDataBaseAux = new ProdFmActPlanDataBase(dataBaseAccess);
                prodFmActPlanDataBaseAux.setPAPL_ProdID(prodFmActHDataBase.getPAH_ProdID());
                prodFmActPlanDataBaseAux.setPAPL_Seq(prodFmActHDataBase.getPAH_Seq());

				ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
				prodFmActPlanDataBase.setPAPL_ProdID(prodFmActHDataBase.getPAH_ProdID());
				prodFmActPlanDataBase.setPAPL_Seq(prodFmActHDataBase.getPAH_Seq());

				/*if (count == secuences.Count - 1)
                    prodFmActPlanDataBase.setPAPL_DayLT(0);
				else
					prodFmActPlanDataBase.setPAPL_DayLT(planDays);

				prodFmActPlanDataBase.setPAPL_DayLTCum(cumDays);*/

                decimal dayLt = 0;
                decimal dayLtCum = 0;
                decimal hourLt = 0;
                decimal hourLtCum = 0;

                try{
                    if (prodFmActPlanDataBaseAux.exists()){
                        prodFmActPlanDataBaseAux.read();
                        dayLt = prodFmActPlanDataBaseAux.getPAPL_DayLT();
                        dayLtCum = prodFmActPlanDataBaseAux.getPAPL_DayLTCum();
                        hourLt = prodFmActPlanDataBaseAux.getPAPL_HourLT();
                        hourLtCum = prodFmActPlanDataBaseAux.getPAPL_HourLTCum();
                    }
                }
                catch { }

                prodFmActPlanDataBase.setPAPL_DayLT(dayLt);
                prodFmActPlanDataBase.setPAPL_DayLTCum(dayLtCum);
                prodFmActPlanDataBase.setPAPL_HourLT(hourLt);
                prodFmActPlanDataBase.setPAPL_HourLTCum(hourLtCum);

				string key = prodFmActPlanDataBase.getKey();
				//.getPAPL_ProdID() + "_" + prodFmActPlanDataBase.getPAPL_Seq().ToString();
				prodFmActPlanDataBaseContainerFromAs400.Add(prodFmActPlanDataBase, key);

				StkMMDataBase stkMMDataBase = (StkMMDataBase)stkMMDataBaseContainer.getFirstObject(prodFmActHDataBase.getPAH_ProdID());
				if (stkMMDataBase != null)
					prodFmActPlanDataBase.setPAPL_Colour(stkMMDataBase.getAVFUT5());

				prodFmActPlanDataBase.setPAPL_ExcludeSats("N");
				prodFmActPlanDataBase.setPAPL_ExcludeSuns("N");

				//cumDays += planDays;
			}

			/*int lastPos = prodFmActPlanDataBaseContainerFromAs400.Count - 1;
			if (secuences.Count == 1){
				ProdFmActPlanDataBase prodFmActPlanDataBase = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromAs400[lastPos];

				ProdFmInfoDataBase toVerify = (ProdFmInfoDataBase)prodFmInfoDataBaseContainer.getFirstObject(prodFmActPlanDataBase.getPAPL_ProdID());

				if (toVerify.getPFS_GLExp().Equals("FGD") || toVerify.getPFS_GLExp().Equals("FG")
						 || toVerify.getPFS_GLExp().Equals("FG1")){ //finished
					prodFmActPlanDataBase.setPAPL_DayLT(0);
					prodFmActPlanDataBase.setPAPL_DayLTCum(0);
				}else{ // WIP
					prodFmActPlanDataBase.setPAPL_DayLT(3);
					prodFmActPlanDataBase.setPAPL_DayLTCum(3);
				}
			}else{
				if (secuences.Count == 2){
					ProdFmActPlanDataBase minorSec = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromAs400[lastPos];
					minorSec.setPAPL_DayLT(int.Parse(Configuration.MaxPlanDays));
					minorSec.setPAPL_DayLTCum(int.Parse(Configuration.MaxPlanDays));
					
					ProdFmActPlanDataBase maySec = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromAs400[lastPos - 1];
                    maySec.setPAPL_DayLT(0);
                    maySec.setPAPL_DayLTCum(0);
				}
			}*/
		}

		for(IEnumerator en = metHdmDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			MetHdmDataBase metHdmDataBase = (MetHdmDataBase) en.Current;

			if (metHdmDataBase.getAQQTYM() > 0){
				BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
				bomSumDataBase.setBMS_ProdID(metHdmDataBase.getAQPART());
				bomSumDataBase.setBMS_Seq(decimal.ToInt32(metHdmDataBase.getAQSEQ()));
				bomSumDataBase.setBMS_MatOrdNum(decimal.ToInt32(metHdmDataBase.getAQLIN()));
				bomSumDataBase.setBMS_MatID(metHdmDataBase.getAQMTLP());
				
				// cambio para alfield 30/08/2004
				bomSumDataBase.setBMS_MatSeq(bomSumDataBase.getBMS_Seq());
				
				bomSumDataBase.setBMS_PrQty(metHdmDataBase.getAQQPPC());
				bomSumDataBase.setBMS_Uom(metHdmDataBase.getAQUNIT());
				bomSumDataBase.setBMS_QtyPerInv(metHdmDataBase.getAQQTYM());
				// cambiado para alfield 3/8/2004
				//bomSumDataBase.setBMS_MatQty(metHdmDataBase.getAQQTYM() / metHdmDataBase.getAQQPPC());
				bomSumDataBase.setBMS_MatQty(metHdmDataBase.getAQQPPC() / metHdmDataBase.getAQQTYM());
				bomSumDataBaseContainer.Add(bomSumDataBase);
			}
		}

		prodFmInfoDataBaseContainer.truncate();
		prodFmActHDataBaseContainer.truncate();
		prodFmActSubDataBaseContainer.truncate();
		bomSumDataBaseContainer.truncate();
		suppProductCrossDataBaseContainer.truncate();

		prodFmInfoDataBaseContainer.write();
		prodFmActHDataBaseContainer.write();
		prodFmActSubDataBaseContainer.write();
		bomSumDataBaseContainer.write();
		suppProductCrossDataBaseContainer.write();

//		prodFmActPlanDataBaseContainerFromAs400.truncate();
//		prodFmActPlanDataBaseContainerFromAs400.write();

// step 1 : delete old records
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainerFromNujit = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		prodFmActPlanDataBaseContainerFromNujit.read();

		for(int index = 0; index < prodFmActPlanDataBaseContainerFromNujit.Count; index++){
			ProdFmActPlanDataBase fromNujit = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromNujit[index];

			if (prodFmActPlanDataBaseContainerFromAs400.getFirstElementPosition(fromNujit.getKey()) == -1){ // not exists in As400
				fromNujit.delete();
			}
		}

// step 2 : add new records
		for(int index = 0; index < prodFmActPlanDataBaseContainerFromAs400.Count; index++){
			ProdFmActPlanDataBase fromAs400 = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromAs400[index];

			if (prodFmActPlanDataBaseContainerFromNujit.getFirstElementPosition(fromAs400.getKey()) == -1){ // not exists in Nujit
				fromAs400.write();
			}
		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return prodFmInfoDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int generateCMSItems(){
	try{
		StkMMDataBaseContainer stkMMDataBaseContainer = new StkMMDataBaseContainer(dataBaseAccess);
		StkMPDataBaseContainer stkMPDataBaseContainer = new StkMPDataBaseContainer(dataBaseAccess);
		MetHdrDataBaseContainer metHdrDataBaseContainer = new MetHdrDataBaseContainer(dataBaseAccess);
		MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
		PopTvnDataBaseContainer popTvnDataBaseContainer = new PopTvnDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempItems(stkMMDataBaseContainer, stkMPDataBaseContainer, 
			metHdrDataBaseContainer, metHdmDataBaseContainer, popTvnDataBaseContainer);

		return cmsTempToNujitItems(stkMMDataBaseContainer, stkMPDataBaseContainer, 
			metHdrDataBaseContainer, metHdmDataBaseContainer, popTvnDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
}

//---------------------------------------------------------------------------

//Depts and Plnt
// The function returns an array where the first element is the total records that
//we insert in the table PltDept, the second element is the total records discard, and the rest of
//the array have the pairs (Plant,Dept) that where discard.
//Save the in CMSTemp the Tables PLNT and DEPTS

public 
string[] generateCMSDeptsRecords(){
	try{
		DeptsDataBaseContainer deptsDataBaseContainer = new DeptsDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempDepts(deptsDataBaseContainer);
		
		string[] notInserted = cmsTempToNujitDepts(deptsDataBaseContainer);

		if (notInserted.Length == 0){
			notInserted = new string[1];
			notInserted[0] = deptsDataBaseContainer.Count.ToString();
		}
		return notInserted;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
}

public 
int cms400ToCmsTempDepts(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		DeptsDataBaseContainer deptsDataBaseContainer = new DeptsDataBaseContainer(dataBaseAccess);
		deptsDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		deptsDataBaseContainer.truncate();
		deptsDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return deptsDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempDepts(DeptsDataBaseContainer deptsDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		deptsDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		deptsDataBaseContainer.truncate();
		deptsDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return deptsDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[] cmsTempToNujitDepts(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		DeptsDataBaseContainer deptsDataBaseContainer = new DeptsDataBaseContainer(dataBaseAccess);
		string[] unCopyDepts = cmsTempToNujitDepts(deptsDataBaseContainer);		

		string[] returnString = new string[unCopyDepts.Length + 2];
		returnString[0] = NumberUtil.toString(deptsDataBaseContainer.Count - unCopyDepts.Length);
		returnString[1]= NumberUtil.toString(unCopyDepts.Length);
		if (unCopyDepts.Length > 0){
			for(int i = 2; i < returnString.Length; i++){
				returnString[i] = unCopyDepts[i-2];
			}
		}

		if (returnString.Length == 0){
			returnString = new string[1];
			returnString[0] = deptsDataBaseContainer.Count.ToString();
		}
		return returnString;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
string[] cmsTempToNujitDepts(DeptsDataBaseContainer deptsDataBaseContainer){
	int countDiscard = 0;

	dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

	if (deptsDataBaseContainer.Count == 0)
		deptsDataBaseContainer.read();

	string[] aux = new string[deptsDataBaseContainer.Count];
	
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
		
		for(IEnumerator en = deptsDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DeptsDataBase deptsDataBase = (DeptsDataBase)en.Current;
			if ((deptsDataBase.getAAPLNT() != null) && (!deptsDataBase.getAAPLNT().Trim().Equals(""))){
				PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
				pltDeptDataBase.setDE_Plt(deptsDataBase.getAAPLNT());
				pltDeptDataBase.setDE_Dept(deptsDataBase.getAADEPT());
				pltDeptDataBase.setDE_DeptShort("");
				pltDeptDataBase.setDE_Des1(deptsDataBase.getAADNME());
				pltDeptDataBase.setDE_UtilPer(0);
				
				if (pltDeptDataBase.getDE_Dept().Trim().Equals("45"))
					pltDeptDataBase.setDE_DeptShort("A");
				else
					pltDeptDataBase.setDE_DeptShort("B");

				pltDeptDataBaseContainer.Add(pltDeptDataBase);
			}else{
				aux[countDiscard] = deptsDataBase.getAADEPT();
				countDiscard++;
			}
		}
		pltDeptDataBaseContainer.truncate();
		pltDeptDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		string[] recordsDiscard = new string[countDiscard];
		
		for (int i = 0; i < countDiscard; i++)
			recordsDiscard[i] = aux[i];

		if (recordsDiscard.Length == 0){
			recordsDiscard = new string[1];
			recordsDiscard[0] = deptsDataBaseContainer.Count.ToString();
		}
		
		return recordsDiscard;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSPlt(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		PlntDataBaseContainer plntDataBaseContainer = new PlntDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempPlnt(plntDataBaseContainer);
		cmsTempToNujitPlt(plntDataBaseContainer);
		
		return plntDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempPlnt(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		PlntDataBaseContainer plntDataBaseContainer = new PlntDataBaseContainer(dataBaseAccess);
		plntDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		plntDataBaseContainer.truncate();
		plntDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return plntDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempPlnt(PlntDataBaseContainer plntDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		plntDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		plntDataBaseContainer.truncate();
		plntDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return plntDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cmsTempToNujitPlt(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		PlntDataBaseContainer plntDataBaseContainer = new PlntDataBaseContainer(dataBaseAccess);
		cmsTempToNujitPlt(plntDataBaseContainer);
		
		return plntDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitPlt(PlntDataBaseContainer plntDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (plntDataBaseContainer.Count==0)
			plntDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PltDataBaseContainer  pltDataBaseContainer = new PltDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = plntDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PlntDataBase plntDataBase = (PlntDataBase)en.Current;
			
			//Records to save in Nujit
			PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
			pltDataBase.setP_Plt(plntDataBase.getYAPLNT());
			pltDataBase.setP_PltName(plntDataBase.getYAPNME());
			pltDataBase.setP_PltShort("");
			pltDataBase.setP_Ads1("");
			pltDataBase.setP_Ads2("");
			pltDataBase.setP_Ads3("");
			pltDataBase.setP_Ads4("");
			pltDataBase.setP_DateUpdated(DateTime.Now);
			pltDataBaseContainer.Add(pltDataBase);
		}
	
		pltDataBaseContainer.truncate();
		pltDataBaseContainer.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return pltDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//-Machines---------------------------------------------------------------------------

public
int generateCMSMachineRecords(){
	try{
		ResreDataBaseContainer resreDataBaseContainer = new ResreDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempMachines(resreDataBaseContainer);
		cmsTempToNujitMachines(resreDataBaseContainer);
																		 
		return resreDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempMachines(){
	try{
		ResreDataBaseContainer resreDataBaseContainer = new ResreDataBaseContainer(dataBaseAccess);
		resreDataBaseContainer.read();
		
		return cms400ToCmsTempMachines(resreDataBaseContainer);

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempMachines(ResreDataBaseContainer resreDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		if (resreDataBaseContainer.Count == 0)
			resreDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		resreDataBaseContainer.truncate();
		resreDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		return resreDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitMachines(){
	try{
		ResreDataBaseContainer resreDataBaseContainer = new ResreDataBaseContainer(dataBaseAccess);
		cmsTempToNujitMachines(resreDataBaseContainer);

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		return resreDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitMachines(ResreDataBaseContainer resreDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		if (resreDataBaseContainer.Count == 0)
			resreDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

	
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		CapMacCfgDataBaseContainer capMacCfgDataBaseContainer = new CapMacCfgDataBaseContainer(dataBaseAccess);
		CapMacCfgADataBaseContainer capMacCfgADataBaseContainer = new CapMacCfgADataBaseContainer(dataBaseAccess);

		// capacity tables
		CapMacDayDataBaseContainer capMacDayDataBaseContainer = new CapMacDayDataBaseContainer(dataBaseAccess);
		CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		CapMacShfDataBaseContainer capMacShfDataBaseContainer = new CapMacShfDataBaseContainer(dataBaseAccess);
		CapMacWkDataBaseContainer capMacWkDataBaseContainer = new CapMacWkDataBaseContainer(dataBaseAccess);

		// scheduler tables
		SchPrFmHrDtDataBaseContainer schPrFmHrDtDataBaseContainer = new SchPrFmHrDtDataBaseContainer(dataBaseAccess);
		SchPrFmHrDataBaseContainer schPrFmHrDataBaseContainer = new SchPrFmHrDataBaseContainer(dataBaseAccess);
		SchMachHrDataBaseContainer schMachHrDataBaseContainer = new SchMachHrDataBaseContainer(dataBaseAccess);
		SchPrOrdDetDataBaseContainer schPrOrdDetDataBaseContainer = new SchPrOrdDetDataBaseContainer(dataBaseAccess);
		SchPrOrdDataBaseContainer schPrOrdDataBaseContainer = new SchPrOrdDataBaseContainer(dataBaseAccess);
		SchPrMasDataBaseContainer schPrMasDataBaseContainer = new SchPrMasDataBaseContainer(dataBaseAccess);
		ProdPackDtlDataBaseContainer prodPackDtlDataBaseContainer = new ProdPackDtlDataBaseContainer(dataBaseAccess);
		SchVersionDataBaseContainer schVersionDataBaseContainer = new SchVersionDataBaseContainer(dataBaseAccess);

		for(IEnumerator en = resreDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ResreDataBase resreDataBase = (ResreDataBase)en.Current;
			
			PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			pltDeptDataBase.setDE_Dept(resreDataBase.getABDEPT());
			if (pltDeptDataBase.existsByDept()){
				pltDeptDataBase.readByDept();
				
				PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
				pltDeptMachDataBase.setPDM_Plt(pltDeptDataBase.getDE_Plt());
				pltDeptMachDataBase.setPDM_Dept(resreDataBase.getABDEPT());
				pltDeptMachDataBase.setPDM_Mach(resreDataBase.getABRESC());
				pltDeptMachDataBase.setPDM_Des1(resreDataBase.getABDES());
				pltDeptMachDataBase.setPDM_UtilPer(resreDataBase.getABUTLP());
				pltDeptMachDataBase.setPDM_InvDrFr(resreDataBase.getABWPDR());
				pltDeptMachDataBase.setPDM_InvRecTo(resreDataBase.getABWPRV());
				pltDeptMachDataBaseContainer.Add(pltDeptMachDataBase);
			
				CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
				capMacCfgDataBase.setCMC_Plt(pltDeptMachDataBase.getPDM_Plt());
				capMacCfgDataBase.setCMC_Dept(pltDeptMachDataBase.getPDM_Dept());
				capMacCfgDataBase.setCMC_Cfg(pltDeptMachDataBase.getPDM_Mach());
				capMacCfgDataBase.setCMC_Des1(pltDeptMachDataBase.getPDM_Des1());
				capMacCfgDataBaseContainer.Add(capMacCfgDataBase);
			
				CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);
				capMacCfgADataBase.setCMCA_Cfg(pltDeptMachDataBase.getPDM_Mach());
				capMacCfgADataBase.setCMCA_Mach(pltDeptMachDataBase.getPDM_Mach());
				capMacCfgADataBase.setCMCA_Plt(pltDeptMachDataBase.getPDM_Plt());
				capMacCfgADataBase.setCMCA_Dept(pltDeptMachDataBase.getPDM_Dept());
				capMacCfgADataBase.setCMCA_MachTyp("A");
				capMacCfgADataBaseContainer.Add(capMacCfgADataBase);
			} 
		} 

		// remove all records from capacity tables
		capMacDayDataBaseContainer.truncate();
		capMacHrDataBaseContainer.truncate();
		capMacShfDataBaseContainer.truncate();
		capMacWkDataBaseContainer.truncate();

		// remove all records from scheduler tables
		schPrFmHrDtDataBaseContainer.truncate();
		schPrFmHrDataBaseContainer.truncate();
		schMachHrDataBaseContainer.truncate();
		schPrOrdDetDataBaseContainer.truncate();
		schPrOrdDataBaseContainer.truncate();
		schPrMasDataBaseContainer.truncate();
		prodPackDtlDataBaseContainer.truncate();
		schVersionDataBaseContainer.truncate();

		// remove all records from mach/config tables
		capMacCfgADataBaseContainer.truncate();
		capMacCfgDataBaseContainer.truncate();
		pltDeptMachDataBaseContainer.truncate();
		
		// write data
		pltDeptMachDataBaseContainer.write();
		capMacCfgDataBaseContainer.write();
		capMacCfgADataBaseContainer.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		return pltDeptMachDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//------------------------------------------------------------------------------------

public 
int generateCMSStkr(){
	try{
		StkrDataBaseContainer stkrDataBaseContainer = new StkrDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempStkr(stkrDataBaseContainer);
		cmsTempToNujitStkrInt(stkrDataBaseContainer);
		
		return stkrDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempStkr(){
	try{
		StkrDataBaseContainer stkrDataBaseContainer = new StkrDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempStkr(stkrDataBaseContainer);
		
		return stkrDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempStkr(StkrDataBaseContainer stkrDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		stkrDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		stkrDataBaseContainer.truncate();
		stkrDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		return stkrDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitStkr(){
	try{
		StkrDataBaseContainer stkrDataBaseContainer = new StkrDataBaseContainer(dataBaseAccess);
		cmsTempToNujitStkrInt(stkrDataBaseContainer);

		return stkrDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitStkrInt(StkrDataBaseContainer stkrDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (stkrDataBaseContainer.Count == 0)
			stkrDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		PltInvLocDataBaseContainer pltInvLocDataBaseContainer = new PltInvLocDataBaseContainer(dataBaseAccess);

		for (IEnumerator en = stkrDataBaseContainer.GetEnumerator();en.MoveNext();){
			StkrDataBase stkrDataBase = (StkrDataBase)en.Current;

			PltInvLocDataBase pltInvLocDataBase = new PltInvLocDataBase(dataBaseAccess);
			pltInvLocDataBase.setPL_Plt(stkrDataBase.getAXPLNT().Trim());
			pltInvLocDataBase.setPL_Loc(stkrDataBase.getAXSTKL().Trim());
			pltInvLocDataBase.setPL_LocName(stkrDataBase.getAXLOCN().Trim());
			pltInvLocDataBase.setPL_Des1(stkrDataBase.getAXADR1().Trim());
			pltInvLocDataBase.setPL_Des2(stkrDataBase.getAXADR2().Trim());
			pltInvLocDataBase.setPL_Des3(stkrDataBase.getAXADR1().Trim() + stkrDataBase.getAXPOST().Trim() );
			pltInvLocDataBase.setPL_Phone(stkrDataBase.getAXTEL().ToString());
			pltInvLocDataBase.setPL_Fax("");
			pltInvLocDataBase.setPL_Contact("");
			if ((stkrDataBase.getAXHLD().Trim().Equals("N")) || (stkrDataBase.getAXHLD().Trim().Equals("n")) )
				pltInvLocDataBase.setPL_InvAvail("Y");
			else
				pltInvLocDataBase.setPL_InvAvail("N");

			pltInvLocDataBase.setPL_LastPhysical(stkrDataBase.getAXLDAT());
			pltInvLocDataBase.setPL_HotListUse("Y");
			
			if (stkrDataBase.getAXSTKL().Trim().Equals("800") || stkrDataBase.getAXSTKL().Trim().Equals("810") ||
					stkrDataBase.getAXSTKL().Trim().Equals("Q25")){
				pltInvLocDataBase.setPL_HotListUse("N");
			}
			
			
			pltInvLocDataBaseContainer.Add(pltInvLocDataBase);
		}
		
		pltInvLocDataBaseContainer.truncate();
		pltInvLocDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return pltInvLocDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//------------------------------------------------------------------------------------

public
void generateSchPrOrdMat(){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		SchPrOrdMatDataBaseContainer schPrOrdMatDataBaseContainer = new SchPrOrdMatDataBaseContainer(dataBaseAccess);
		schPrOrdMatDataBaseContainer.truncate();
		
		schPrOrdMatDataBaseContainer.readAllMaterialsForOrders();
		schPrOrdMatDataBaseContainer.write();
		
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
void generateMaterialRecords(){
/*
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		SchMatReqHrDataBaseContainer schMatReqHrDataBaseContainer = new SchMatReqHrDataBaseContainer(dataBaseAccess);
		schMatReqHrDataBaseContainer.readAllMaterialsForOrders();
		
		SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = schMatReqHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DictionaryEntry schMatReqHrDataBaseEntry = (DictionaryEntry) en.Current;
			SchMatReqHrDataBase schMatReqHrDataBase = (SchMatReqHrDataBase) schMatReqHrDataBaseEntry.Value;

			bool modifiedHr = false;
			for (IEnumerator en2 = schMatReqDayDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				DictionaryEntry schMatReqDayDataBaseEntry = (DictionaryEntry) en2.Current;
				SchMatReqDayDataBase schMatReqDayDataBase = (SchMatReqDayDataBase) schMatReqDayDataBaseEntry.Value;

				string dateDay = DateUtil.getDateRepresentation(schMatReqDayDataBase.getSMD_Dt(), DateUtil.MMDDYYYY);
				string dateHr = DateUtil.getDateRepresentation(schMatReqHrDataBase.getSMH_Dt(), DateUtil.MMDDYYYY);

				if (schMatReqHrDataBase.getSMH_ProdID().Equals(schMatReqDayDataBase.getSMD_ProdID()) &&
					schMatReqHrDataBase.getSMH_ActID().Equals(schMatReqDayDataBase.getSMD_ActID()) &&
					schMatReqHrDataBase.getSMH_Seq().Equals(schMatReqDayDataBase.getSMD_Seq()) &&
					schMatReqHrDataBase.getSMH_MatID().Equals(schMatReqDayDataBase.getSMD_MatID()) &&
					dateDay.Equals(dateHr)){

					schMatReqDayDataBase.setSMD_MatQty(schMatReqDayDataBase.getSMD_MatQty() + schMatReqHrDataBase.getSMH_QtyReq());
					modifiedHr = true;
				}
			}
			
			if (!modifiedHr){
				SchMatReqDayDataBase schMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);

				schMatReqDayDataBase.setSMD_SchVersion(schMatReqHrDataBase.getSMH_SchVersion());
				schMatReqDayDataBase.setSMD_Plt(schMatReqHrDataBase.getSMH_Plt());
				schMatReqDayDataBase.setSMD_Dept(schMatReqHrDataBase.getSMH_Dept());
				schMatReqDayDataBase.setSMD_Mach(schMatReqHrDataBase.getSMH_Mach());
				schMatReqDayDataBase.setSMD_Dt(schMatReqHrDataBase.getSMH_Dt());
				schMatReqDayDataBase.setSMD_ProdID(schMatReqHrDataBase.getSMH_ProdID());
				schMatReqDayDataBase.setSMD_Seq(schMatReqHrDataBase.getSMH_Seq());
				schMatReqDayDataBase.setSMD_ActID(schMatReqHrDataBase.getSMH_ActID());
				schMatReqDayDataBase.setSMD_MatID(schMatReqHrDataBase.getSMH_MatID());
				schMatReqDayDataBase.setSMD_MatSeq(schMatReqHrDataBase.getSMH_Seq());
				schMatReqDayDataBase.setSMD_MatQty(schMatReqHrDataBase.getSMH_QtyReq());
				schMatReqDayDataBase.setSMD_MatUom(schMatReqHrDataBase.getSMH_Uom());
				
				schMatReqDayDataBaseContainer.Add(schMatReqDayDataBase.GetHashCode(), schMatReqDayDataBase);
			}
		}
		
		SchMatReqShfDataBaseContainer schMatReqShfDataBaseContainer = new SchMatReqShfDataBaseContainer(dataBaseAccess);
		for(IEnumerator en = schMatReqHrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DictionaryEntry schMatReqHrDataBaseEntry = (DictionaryEntry) en.Current;
			SchMatReqHrDataBase schMatReqHrDataBase = (SchMatReqHrDataBase) schMatReqHrDataBaseEntry.Value;

			bool modifiedShf = false;
			for (IEnumerator en2 = schMatReqShfDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				DictionaryEntry schMatReqShfDataBaseEntry = (DictionaryEntry) en2.Current;
				SchMatReqShfDataBase schMatReqShfDataBase = (SchMatReqShfDataBase) schMatReqShfDataBaseEntry.Value;

				string dateDay = DateUtil.getDateRepresentation(schMatReqShfDataBase.getSMH_Dt(), DateUtil.MMDDYYYY);
				string dateHr = DateUtil.getDateRepresentation(schMatReqHrDataBase.getSMH_Dt(), DateUtil.MMDDYYYY);

				if (schMatReqHrDataBase.getSMH_ActID().Equals(schMatReqShfDataBase.getSMH_ActID()) &&
					schMatReqHrDataBase.getSMH_Seq().Equals(schMatReqShfDataBase.getSMH_Seq()) &&
					schMatReqHrDataBase.getSMH_MatID().Equals(schMatReqShfDataBase.getSMH_MatID()) &&
					dateDay.Equals(dateHr) &&
					schMatReqHrDataBase.getSMH_Shf().Equals(schMatReqShfDataBase.getSMH_Shf())){

					schMatReqShfDataBase.setSMH_QtyReq(schMatReqShfDataBase.getSMH_QtyReq() + schMatReqHrDataBase.getSMH_QtyReq());
					modifiedShf = true;
				}
			}
			
			if (!modifiedShf){
				SchMatReqShfDataBase schMatReqShfDataBase = new SchMatReqShfDataBase(dataBaseAccess);

				schMatReqShfDataBase.setSMR_SchVersion(schMatReqHrDataBase.getSMH_SchVersion());
				schMatReqShfDataBase.setSMR_MachOrdNum(schMatReqHrDataBase.getSMH_MachOrdNum());
				schMatReqShfDataBase.setSMR_Plt(schMatReqHrDataBase.getSMH_Plt());
				schMatReqShfDataBase.setSMR_Dept(schMatReqHrDataBase.getSMH_Dept());
				schMatReqShfDataBase.setSMR_Mach(schMatReqHrDataBase.getSMH_Mach());
				schMatReqShfDataBase.setSMH_Shf(schMatReqHrDataBase.getSMH_Shf());
				schMatReqShfDataBase.setSMH_Dt(schMatReqHrDataBase.getSMH_Dt());
				schMatReqShfDataBase.setSMH_DtShf(schMatReqHrDataBase.getSMH_DtShf());
				schMatReqShfDataBase.setSMH_MatID(schMatReqHrDataBase.getSMH_MatID());
				schMatReqShfDataBase.setSMH_Seq(schMatReqHrDataBase.getSMH_Seq());
				schMatReqShfDataBase.setSMH_ActID(schMatReqHrDataBase.getSMH_ActID());
				schMatReqShfDataBase.setSMH_QtyPerInv(schMatReqHrDataBase.getSMH_QtyPerInv());
				schMatReqShfDataBase.setSMH_QtyReq(schMatReqHrDataBase.getSMH_QtyReq());
				schMatReqShfDataBase.setSMH_Uom(schMatReqHrDataBase.getSMH_Uom());
				schMatReqShfDataBase.setSMH_InvStartPos(schMatReqHrDataBase.getSMH_InvStartPos());
				schMatReqShfDataBase.setSMH_InvEndPos(schMatReqHrDataBase.getSMH_InvEndPos());

				schMatReqShfDataBaseContainer.Add(schMatReqShfDataBase.GetHashCode(), schMatReqShfDataBase);
			}
		}
		
		schMatReqHrDataBaseContainer.truncate();
		schMatReqHrDataBaseContainer.write();
		
		schMatReqDayDataBaseContainer.truncate();
		schMatReqDayDataBaseContainer.write();

		schMatReqShfDataBaseContainer.truncate();
		schMatReqShfDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	} */
}

public
void restoreInvalidsSeqs(){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		invPltLocDataBaseContainer.setIPL_Seq(0);
		invPltLocDataBaseContainer.readAllBySeq();
		
		ProdFmActHDataBaseContainer prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);
		prodFmActHDataBaseContainer.readAllProdMaxSeq();

		for(IEnumerator en = invPltLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) en.Current;

			for (IEnumerator en2 = prodFmActHDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				ProdFmActHDataBase prodFmActHDataBase = (ProdFmActHDataBase) en2.Current;
				if (invPltLocDataBase.getIPL_ProdID().Equals(prodFmActHDataBase.getPAH_ProdID())){
					invPltLocDataBase.setIPL_Seq(prodFmActHDataBase.getPAH_Seq());
					break;
				}
			}
		}

		invPltLocDataBaseContainer.update();
		
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

//------------------------------------------------------------------------------------

public 
int CMSFamilyCopy(){
	try{
		PdfmDataBaseContainer pdfmDataBaseContainer = new PdfmDataBaseContainer(dataBaseAccess);
		PdfcDataBaseContainer pdfcDataBaseContainer = new PdfcDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempFamily(pdfmDataBaseContainer, pdfcDataBaseContainer);
		return cmsTempToNujitFamily(pdfmDataBaseContainer, pdfcDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempFamily(){
	try{
		PdfmDataBaseContainer pdfmDataBaseContainer = new PdfmDataBaseContainer(dataBaseAccess);
		PdfcDataBaseContainer pdfcDataBaseContainer = new PdfcDataBaseContainer(dataBaseAccess);

		return cms400ToCmsTempFamily(pdfmDataBaseContainer, pdfcDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempFamily(PdfmDataBaseContainer pdfmDataBaseContainer, 
		PdfcDataBaseContainer pdfcDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		pdfmDataBaseContainer.read();
		pdfcDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		pdfcDataBaseContainer.truncate();
		pdfmDataBaseContainer.truncate();
		
		pdfcDataBaseContainer.write();
		pdfmDataBaseContainer.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return pdfmDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitFamily(){
	try{
		PdfmDataBaseContainer pdfmDataBaseContainer = new PdfmDataBaseContainer(dataBaseAccess);
		PdfcDataBaseContainer pdfcDataBaseContainer = new PdfcDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitFamily(pdfmDataBaseContainer, pdfcDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitFamily(PdfmDataBaseContainer pdfmDataBaseContainer, 
		PdfcDataBaseContainer pdfcDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		if (pdfmDataBaseContainer.Count == 0)
			pdfmDataBaseContainer.read();
		
		if (pdfcDataBaseContainer.Count == 0)
			pdfcDataBaseContainer.read();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		prodFmActPlanDataBaseContainer.truncateFamilies();
		
		ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
		prodFmActPlanDtDataBaseContainer.truncate();

		int recordsCopied = 0;
		for(IEnumerator en = pdfmDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PdfmDataBase pdfmDataBase = (PdfmDataBase) en.Current;

			ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
			prodFmInfoDataBase.setPFS_ProdID(pdfmDataBase.getPSFMPT());
			
			if (!prodFmInfoDataBase.exists()){
				prodFmInfoDataBase.setPFS_Des1(pdfmDataBase.getPSDES1());
				prodFmInfoDataBase.setPFS_Des2(pdfmDataBase.getPSDES2());
				prodFmInfoDataBase.setPFS_Des3(pdfmDataBase.getPSDES3());
				prodFmInfoDataBase.setPFS_FamProd("F");
				prodFmInfoDataBase.write();
			}else{  
				prodFmInfoDataBase.read();
				prodFmInfoDataBase.setPFS_FamProd("F");
				prodFmInfoDataBase.update();
			}

			ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
			prodFmActPlanDataBase.setPAPL_ProdID(pdfmDataBase.getPSFMPT());
			prodFmActPlanDataBase.setPAPL_ActID("");
			// Get the last Sequence number
			ProdFmInfoDataBase seq_prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
			seq_prodFmInfoDataBase.setPFS_ProdID(pdfmDataBase.getPSFMPT());
			seq_prodFmInfoDataBase.read();
			// Get the last Sequence number
			prodFmActPlanDataBase.setPAPL_Seq(seq_prodFmInfoDataBase.getPFS_SeqLast());
			prodFmActPlanDataBase.setPAPL_InvUom(pdfmDataBase.getPSUNIT());

			prodFmActPlanDataBaseContainer.Add(prodFmActPlanDataBase);
			recordsCopied++;
		}

		for(IEnumerator en = pdfcDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PdfcDataBase pdfcDataBase = (PdfcDataBase) en.Current;

			ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = new ProdFmActPlanDtDataBase(dataBaseAccess);
			prodFmActPlanDtDataBase.setPFPD_ProdID(pdfcDataBase.getPXPART());
			prodFmActPlanDtDataBase.setPFPD_FamCfg(pdfcDataBase.getPXFMPT());
			prodFmActPlanDtDataBase.setPFPD_Qty(pdfcDataBase.getPXCQTY());
			prodFmActPlanDtDataBase.setPFPD_InvUOM(pdfcDataBase.getPXUNIT());
			prodFmActPlanDtDataBase.setPFPD_ShutYN(pdfcDataBase.getPXBLCK());
			prodFmActPlanDtDataBaseContainer.Add(prodFmActPlanDtDataBase);
		}

		prodFmActPlanDataBaseContainer.write();
		prodFmActPlanDtDataBaseContainer.write();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return recordsCopied;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//------------------------------------------------------------------------------------

public 
void generateCMSCust(){
	try{
		CustDataBaseContainer custDataBaseContainer = new CustDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempCust(custDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempCust(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		CustDataBaseContainer custDataBaseContainer = new CustDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempCust(custDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempCust(CustDataBaseContainer custDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		custDataBaseContainer.read();
	
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		custDataBaseContainer.truncate();
		custDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return custDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//------------------------------------------------------------------------------------

public 
int generateCMSVend(){
	try{
		VendDataBaseContainer vendDataBaseContainer = new VendDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempVend(vendDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempVend(){
	try{
		VendDataBaseContainer vendDataBaseContainer = new VendDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempVend(vendDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempVend(VendDataBaseContainer vendDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		vendDataBaseContainer.read();
	
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		vendDataBaseContainer.truncate();
		vendDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return vendDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//---------------------------------------------------------------------------
public 
int cmsTempToNujitCustVend(){
	try{
		CustDataBaseContainer custDataBaseContainer = new CustDataBaseContainer(dataBaseAccess);
		VendDataBaseContainer vendDataBaseContainer = new VendDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitCustVend(custDataBaseContainer,vendDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitCustVend(CustDataBaseContainer custDataBaseContainer, VendDataBaseContainer vendDataBaseContainer){
	try{	
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (custDataBaseContainer.Count == 0)
			custDataBaseContainer.read();
		
		if (vendDataBaseContainer.Count == 0)
			vendDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		CustVendDataBaseContainer custVendDataBaseContainer = new CustVendDataBaseContainer(dataBaseAccess);

		//Copy records from Cust to CustVend
		for (IEnumerator en = custDataBaseContainer.GetEnumerator();en.MoveNext();){
			CustDataBase custDataBase = (CustDataBase)en.Current;

			CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
			custVendDataBase.setCV_ID(custDataBase.getBVCUST());
			custVendDataBase.setCV_RecType("C");

			if (custDataBase.getBVTYPE().Equals("E"))
				custVendDataBase.setCV_CustomerType("B");
			else
				custVendDataBase.setCV_CustomerType(custDataBase.getBVTYPE());

			custVendDataBase.setCV_Status(custDataBase.getBVSTAT());
			custVendDataBase.setCV_Name(custDataBase.getBVNAME());
			custVendDataBase.setCV_Address1(custDataBase.getBVADR1());
			custVendDataBase.setCV_Address2(custDataBase.getBVADR2());
			custVendDataBase.setCV_Address3(custDataBase.getBVADR3());
			custVendDataBase.setCV_Address4(custDataBase.getBVADR4());
			custVendDataBase.setCV_Address5(custDataBase.getBVADR5());
			custVendDataBase.setCV_Address6(custDataBase.getBVADR6());
			custVendDataBase.setCV_Address7(custDataBase.getBVADR7());
			custVendDataBase.setCV_Address8(custDataBase.getBVADR8());
			custVendDataBase.setCV_Phone(custDataBase.getBVTELP());
			custVendDataBase.setCV_Fax(custDataBase.getBVFAX());
			custVendDataBase.setCV_WebPage(custDataBase.getBVWEB());
			custVendDataBase.setCV_Country("");
			custVendDataBase.setCV_State_Prov(custDataBase.getBVPRCD());
			custVendDataBase.setCV_Currency(custDataBase.getBVCURR());
			custVendDataBase.setCV_Territory(custDataBase.getBVTERR());
			custVendDataBase.setCV_Class(custDataBase.getBVCLAS());
			custVendDataBase.setCV_DateCreated(DateTime.Today);
			custVendDataBase.setCV_DateUpdated(DateTime.Today);
			custVendDataBaseContainer.Add(custVendDataBase);
		}

		//Copy records from Vend to CustVend
		for (IEnumerator en = vendDataBaseContainer.GetEnumerator();en.MoveNext();){
			VendDataBase vendDataBase = (VendDataBase)en.Current;

			CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
			custVendDataBase.setCV_Plt(Configuration.DftPlant);
			custVendDataBase.setCV_ID(vendDataBase.getBTVEND());
			custVendDataBase.setCV_RecType("V");
			custVendDataBase.setCV_CustomerType("");
			custVendDataBase.setCV_Status(vendDataBase.getBTSTAT());
			custVendDataBase.setCV_Name(vendDataBase.getBTNAME());
			custVendDataBase.setCV_Address1(vendDataBase.getBTADR1());
			custVendDataBase.setCV_Address2(vendDataBase.getBTADR2());
			custVendDataBase.setCV_Address3(vendDataBase.getBTADR3());
			custVendDataBase.setCV_Address4(vendDataBase.getBTADR4());
			custVendDataBase.setCV_Address5(vendDataBase.getBTADR5());
			custVendDataBase.setCV_Address6(vendDataBase.getBTADR6());
			custVendDataBase.setCV_Address7(vendDataBase.getBTADR7());
			custVendDataBase.setCV_Address8(vendDataBase.getBTADR8());
			custVendDataBase.setCV_Phone(vendDataBase.getBTTEL());
			custVendDataBase.setCV_Fax(vendDataBase.getBTFAX());
			custVendDataBase.setCV_WebPage(vendDataBase.getBTWPAG());
			custVendDataBase.setCV_Country(vendDataBase.getBTCNTC());
			custVendDataBase.setCV_State_Prov(vendDataBase.getBTPRCD());
			custVendDataBase.setCV_Currency(vendDataBase.getBTCURR());
			custVendDataBase.setCV_Territory("");
			custVendDataBase.setCV_Class(vendDataBase.getBTCLAS());
			custVendDataBase.setCV_DateCreated(DateTime.Today);
			custVendDataBase.setCV_DateUpdated(DateTime.Today);
			
			custVendDataBaseContainer.Add(custVendDataBase);
		}
	
		custVendDataBaseContainer.truncate();
		custVendDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		return custVendDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//--------------------------------------------------------------------------------
//The table CustVend save files from Cust and Vend tables from CMSTemp

public 
int generateCustVend(){
	try{
		//Save records from AS400 to CmsTemp and then copy to Nujit
		VendDataBaseContainer vendDataBaseContainer = new VendDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempVend(vendDataBaseContainer);

		CustDataBaseContainer custDataBaseContainer = new CustDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempCust(custDataBaseContainer);

		//Copy to Nujit
		return cmsTempToNujitCustVend(custDataBaseContainer, vendDataBaseContainer);	
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSJitToDelJit(){
	try{
		JithDataBaseContainer jithDataBaseContainer = new JithDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempJith(jithDataBaseContainer);
		JitdDataBaseContainer jitdDataBaseContainer = new JitdDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempJitd(jitdDataBaseContainer);
		
		return cmsTempToNujitDelJit(jithDataBaseContainer,jitdDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
public 
int cms400ToCmsTempJith(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		JithDataBaseContainer jithDataBaseContainer = new JithDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempJith(jithDataBaseContainer);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempJith(JithDataBaseContainer jithDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		jithDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		JithDataBaseContainer newJithDataBaseContainer = new JithDataBaseContainer(dataBaseAccess);
        
			
        for( IEnumerator en = jithDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			JithDataBase oldJithDataBase = (JithDataBase) en.Current;
		
			JithDataBase newJithDataBase = new  JithDataBase(dataBaseAccess);
			
			newJithDataBase=oldJithDataBase;
			newJithDataBase.setDB(Configuration.CMSLibrary);
		
			newJithDataBaseContainer.Add(newJithDataBase);
		}

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		jithDataBaseContainer.truncate();
		newJithDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
			
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		return newJithDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}


public 
void generateCMSJitd(){
	try{
		JitdDataBaseContainer jitdDataBaseContainer = new JitdDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempJitd(jitdDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempJitd(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		JitdDataBaseContainer jitdDataBaseContainer = new JitdDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempJitd(jitdDataBaseContainer);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempJitd(JitdDataBaseContainer jitdDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		jitdDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		JitdDataBaseContainer newJitdDataBaseContainer = new JitdDataBaseContainer(dataBaseAccess);	
		
		for( IEnumerator en = jitdDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			JitdDataBase oldJitdDataBase = (JitdDataBase) en.Current;
		
			JitdDataBase newJitdDataBase = new  JitdDataBase(dataBaseAccess);
			
			newJitdDataBase=oldJitdDataBase;
			newJitdDataBase.setDB(Configuration.CMSLibrary);
		
			newJitdDataBaseContainer.Add(newJitdDataBase);
		}
		
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
			
		jitdDataBaseContainer.truncate();
		newJitdDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		return newJitdDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateRRLToDelFor(){
	try{
		RrlhDataBaseContainer rrlhDataBaseContainer = new RrlhDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRrlh(rrlhDataBaseContainer);
		RrldDataBaseContainer rrldDataBaseContainer= new RrldDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRrld(rrldDataBaseContainer);
		
		return cmsTempToNujitDelFor(rrlhDataBaseContainer,rrldDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
void generateCMSRrlh(){
	try{
		RrlhDataBaseContainer rrlhDataBaseContainer = new RrlhDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempRrlh(rrlhDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempRrlh(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		RrlhDataBaseContainer rrlhDataBaseContainer = new RrlhDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempRrlh(rrlhDataBaseContainer);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempRrlh(RrlhDataBaseContainer rrlhDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		rrlhDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		RrlhDataBaseContainer newRrlhDataBaseContainer= new RrlhDataBaseContainer(dataBaseAccess);

        for( IEnumerator en = rrlhDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			RrlhDataBase oldRrlhDataBase = (RrlhDataBase) en.Current;
		
			RrlhDataBase newRrlhDataBase = new RrlhDataBase(dataBaseAccess);
			
			newRrlhDataBase=oldRrlhDataBase;
			newRrlhDataBase.setDB(Configuration.CMSLibrary);
		
			newRrlhDataBaseContainer.Add(newRrlhDataBase);
		}

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		rrlhDataBaseContainer.truncate();
		newRrlhDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		return newRrlhDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void generateCMSRrld(){
	try{
		RrldDataBaseContainer rrldDataBaseContainer = new RrldDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempRrld(rrldDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempRrld(){
	try{
		RrldDataBaseContainer rrldDataBaseContainer = new RrldDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempRrld(rrldDataBaseContainer);
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempRrld(RrldDataBaseContainer rrldDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		rrldDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
        RrldDataBaseContainer newRrldDataBaseContainer= new RrldDataBaseContainer(dataBaseAccess);
        
        for( IEnumerator en = rrldDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			RrldDataBase oldRrldDataBase = (RrldDataBase) en.Current;
		
			RrldDataBase newRrldDataBase = new RrldDataBase(dataBaseAccess);
			
			newRrldDataBase=oldRrldDataBase;
			newRrldDataBase.setDB(Configuration.CMSLibrary);
		
			newRrldDataBaseContainer.Add(newRrldDataBase);
		}

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		rrldDataBaseContainer.truncate();
		newRrldDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		return newRrldDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//Move the records from the tables Jitd and Jith from CMstemp to Nujit.
public 
int cmsTempToNujitDelJit(){
	try{
		JithDataBaseContainer jithDataBaseContainer = new JithDataBaseContainer(dataBaseAccess);
		JitdDataBaseContainer jitdDataBaseContainer = new JitdDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitDelJit(jithDataBaseContainer,jitdDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitDelJit(JithDataBaseContainer jithDataBaseContainer, JitdDataBaseContainer jitdDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (jithDataBaseContainer.Count == 0)
			jithDataBaseContainer.read();
		
		if (jitdDataBaseContainer.Count == 0)
			jitdDataBaseContainer.read();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
			
		DelJitHdrDataBaseContainer delJitHdrDataBaseContainer= new DelJitHdrDataBaseContainer(dataBaseAccess);
		DelJitDtlDataBaseContainer delJitDtlDataBaseContainer= new DelJitDtlDataBaseContainer(dataBaseAccess);

	    for (IEnumerator en = jithDataBaseContainer.GetEnumerator();en.MoveNext();){
		    JithDataBase jithDataBase = (JithDataBase)en.Current;

            DelJitHdrDataBase delJitHdrDataBase = new DelJitHdrDataBase(dataBaseAccess);
            
            delJitHdrDataBase.setDJH_Db(Configuration.CMSLibrary);
            delJitHdrDataBase.setDJH_Key((int)jithDataBase.getSPKEYN());
            delJitHdrDataBase.setDJH_Tpartner(jithDataBase.getSPTRPT());
            delJitHdrDataBase.setDJH_TpartnerLoc(jithDataBase.getSPSTXL());
            delJitHdrDataBase.setDJH_CustPartID(jithDataBase.getSPCPT());
            delJitHdrDataBase.setDJH_DeljitReleaseNum(jithDataBase.getSPREF());
            delJitHdrDataBase.setDJH_SchedType(jithDataBase.getSPSETP());
            delJitHdrDataBase.setDJH_ReleaseNum(jithDataBase.getSPREL());
            delJitHdrDataBase.setDJH_HorizonStDate(jithDataBase.getSPSDAT());
            delJitHdrDataBase.setDJH_HorizonStopDate(jithDataBase.getSPEDAT());
            delJitHdrDataBase.setDJH_SchedDate(jithDataBase.getSPRDAT());
            delJitHdrDataBase.setDJH_DockCode(jithDataBase.getSPDOK());
            delJitHdrDataBase.setDJH_CustPO(jithDataBase.getSPCPO());
            delJitHdrDataBase.setDJH_LogNum((int)jithDataBase.getSPLOG());
            delJitHdrDataBase.setDJH_EntryNum((int)jithDataBase.getSPLIN());
            delJitHdrDataBase.setDJH_CustCumReq((int)jithDataBase.getSPOEMC());
            delJitHdrDataBase.setDJH_CustCumShip((int)jithDataBase.getSPOEMS());
            delJitHdrDataBase.setDJH_CustLastRecQty((int)jithDataBase.getSPLRCQ());
            delJitHdrDataBase.setDJH_CustLastDate(jithDataBase.getSPLDAT());
            delJitHdrDataBase.setDJH_CustLastShipID(jithDataBase.getSPLSHI());
            delJitHdrDataBase.setDJH_CustShipCum((int)jithDataBase.getSPYTDC());
            delJitHdrDataBase.setDJH_CustFabCum((int)jithDataBase.getSPFABC());
            delJitHdrDataBase.setDJH_CustMatCum((int)jithDataBase.getSPMTLC());
            delJitHdrDataBase.setDJH_CumDisc((int)jithDataBase.getSPCUMD());
            delJitHdrDataBase.setDJH_CumInError(jithDataBase.getSPCUME());
            delJitHdrDataBase.setDJH_DateType(jithDataBase.getSPDTYP());
            delJitHdrDataBase.setDJH_QtyType(jithDataBase.getSPQTYP());
            delJitHdrDataBase.setDJH_Status(jithDataBase.getSPCRCM());
            
            delJitHdrDataBaseContainer.Add(delJitHdrDataBase);
        }	
        
        for (IEnumerator en = jitdDataBaseContainer.GetEnumerator();en.MoveNext();){
		    JitdDataBase jitdDataBase = (JitdDataBase)en.Current;

            DelJitDtlDataBase delJitDtlDataBase = new DelJitDtlDataBase(dataBaseAccess);
            
            delJitDtlDataBase.setDJD_Db(Configuration.CMSLibrary);
            delJitDtlDataBase.setDJD_Key((int)jitdDataBase.getPYKEYN());
            delJitDtlDataBase.setDJD_Reference(jitdDataBase.getPYREF());
            delJitDtlDataBase.setDJD_ShipDate(jitdDataBase.getPYDATE());
            delJitDtlDataBase.setDJD_ShipTime(jitdDataBase.getPYHM());
            delJitDtlDataBase.setDJD_EndDate(jitdDataBase.getPYEDAT());
            delJitDtlDataBase.setDJD_Qty((int)jitdDataBase.getPYQTY());
            delJitDtlDataBase.setDJD_CumQty((int)jitdDataBase.getPYQCUM());
            delJitDtlDataBase.setDJD_QtyAdj((int)jitdDataBase.getPYNQTY());
            delJitDtlDataBase.setDJD_Source(jitdDataBase.getPYSRC());
            delJitDtlDataBase.setDJD_LogNum((int)jitdDataBase.getPYLOG());
            delJitDtlDataBase.setDJD_EntNum((int)jitdDataBase.getPYENT());
            delJitDtlDataBase.setDJD_BOLNum((int)jitdDataBase.getPYBOL());
            delJitDtlDataBase.setDJD_BOLLine((int)jitdDataBase.getPYBLIN());
            delJitDtlDataBase.setDJD_RAN(jitdDataBase.getPYRAN());
            delJitDtlDataBase.setDJD_Ref1(jitdDataBase.getPYREF1());
            delJitDtlDataBase.setDJD_Ref2(jitdDataBase.getPYREF2());
            delJitDtlDataBase.setDJD_Stat(jitdDataBase.getPYSTAT());
            delJitDtlDataBase.setDJD_RecordID((int)jitdDataBase.getPYKEY());
            delJitDtlDataBase.setDJD_KanBanPre(jitdDataBase.getPYKBPR());
            delJitDtlDataBase.setDJD_KanBanStart(jitdDataBase.getPYKBST());
            delJitDtlDataBase.setDJD_KanBanEnd(jitdDataBase.getPYKBEN());
            delJitDtlDataBase.setDJD_ShipPattern(jitdDataBase.getPYSHPP());
            delJitDtlDataBase.setDJD_ShipPatternTime(jitdDataBase.getPYSHPT());
           
            
            delJitDtlDataBaseContainer.Add(delJitDtlDataBase);
        }	
        //Write the DelJitHdr table
        delJitHdrDataBaseContainer.truncate();
        delJitHdrDataBaseContainer.write();
        
        //Write the DelJitDtl table
        delJitDtlDataBaseContainer.truncate();
        delJitDtlDataBaseContainer.write();
      	if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return delJitDtlDataBaseContainer.Count + delJitHdrDataBaseContainer.Count; 
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}	
}



//Move the records from the tables RRLH and RRLD from CMstemp to Nujit.
public 
int cmsTempToNujitDelFor(){
	try{
		RrlhDataBaseContainer rrlhDataBaseContainer = new RrlhDataBaseContainer(dataBaseAccess);
		RrldDataBaseContainer rrldDataBaseContainer = new RrldDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitDelFor(rrlhDataBaseContainer,rrldDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitDelFor(RrlhDataBaseContainer rrlhDataBaseContainer, RrldDataBaseContainer rrldDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (rrlhDataBaseContainer.Count == 0)
			rrlhDataBaseContainer.read();
		
		if (rrldDataBaseContainer.Count == 0)
			rrldDataBaseContainer.read();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
			
		DelForHdrDataBaseContainer delForHdrDataBaseContainer= new DelForHdrDataBaseContainer(dataBaseAccess);
		DelForDtlDataBaseContainer delForDtlDataBaseContainer= new DelForDtlDataBaseContainer(dataBaseAccess);

	    for (IEnumerator en = rrlhDataBaseContainer.GetEnumerator();en.MoveNext();){
		    RrlhDataBase rrlhDataBase = (RrlhDataBase)en.Current;

            DelForHdrDataBase delForHdrDataBase = new DelForHdrDataBase(dataBaseAccess);
            
            delForHdrDataBase.setDH_Db(Configuration.CMSLibrary);
            delForHdrDataBase.setDH_Key((int)rrlhDataBase.getOZKEYN());
            delForHdrDataBase.setDH_Tpartner(rrlhDataBase.getOZTRPT());
            delForHdrDataBase.setDH_TpartnerLoc(rrlhDataBase.getOZSTXL());
            delForHdrDataBase.setDH_CustPartID(rrlhDataBase.getOZCPT());
            delForHdrDataBase.setDH_DelforReleaseNum(rrlhDataBase.getOZREL());
            delForHdrDataBase.setDH_ReleaseNum(rrlhDataBase.getOZMTL());
            delForHdrDataBase.setDH_HorizonStartDate(rrlhDataBase.getOZSDAT());
            delForHdrDataBase.setDH_HorizonStopDate(rrlhDataBase.getOZEDAT());
            delForHdrDataBase.setDH_IssueDate(rrlhDataBase.getOZIDAT());
            delForHdrDataBase.setDH_SchType(rrlhDataBase.getOZSETP());
            delForHdrDataBase.setDH_CustPO(rrlhDataBase.getOZCPO());
            delForHdrDataBase.setDH_Plant(rrlhDataBase.getOZPLNT());
            delForHdrDataBase.setDH_DockCode(rrlhDataBase.getOZDOK());
            delForHdrDataBase.setDH_LineFeed(rrlhDataBase.getOZLINE());
            delForHdrDataBase.setDH_DropCode(rrlhDataBase.getOZDROP());
            delForHdrDataBase.setDH_Source(rrlhDataBase.getOZSRCE());
            delForHdrDataBase.setDH_LogNum((int)rrlhDataBase.getOZLOG());
            delForHdrDataBase.setDH_LogLin((int)rrlhDataBase.getOZLIN());
            delForHdrDataBase.setDH_CumQty((int)rrlhDataBase.getOZYTDC());
            delForHdrDataBase.setDH_CustCumRequired((int)rrlhDataBase.getOZOEMC());
            delForHdrDataBase.setDH_CustCumShipped((int)rrlhDataBase.getOZOEMS());
            delForHdrDataBase.setDH_FabCumQty((int)rrlhDataBase.getOZFABC());
            delForHdrDataBase.setDH_MatCumQty((int)rrlhDataBase.getOZMTLC());
            delForHdrDataBase.setDH_LastRecQty((int)rrlhDataBase.getOZRCVQ());
            delForHdrDataBase.setDH_LastRecDate(rrlhDataBase.getOZLDAT());
            delForHdrDataBase.setDH_LastRecShipment(rrlhDataBase.getOZLSHI());
            delForHdrDataBase.setDH_CumDisc((int)rrlhDataBase.getOZCUMD());
            delForHdrDataBase.setDH_CumError(rrlhDataBase.getOZCUME());
            delForHdrDataBase.setDH_DateType(rrlhDataBase.getOZDTYP());
            delForHdrDataBase.setDH_QtyType(rrlhDataBase.getOZQTYP());
            delForHdrDataBase.setDH_ReleaseType(rrlhDataBase.getOZRELT());
            delForHdrDataBase.setDH_PartStatus(rrlhDataBase.getOZPSTS());
            delForHdrDataBase.setDH_ReleaseStatus(rrlhDataBase.getOZCRCM());

            delForHdrDataBaseContainer.Add(delForHdrDataBase);
        }	
        
        for (IEnumerator en = rrldDataBaseContainer.GetEnumerator();en.MoveNext();){
		    RrldDataBase rrldDataBase = (RrldDataBase)en.Current;

            DelForDtlDataBase delForDtlDataBase = new DelForDtlDataBase(dataBaseAccess);
            
            delForDtlDataBase.setDD_Db(Configuration.CMSLibrary);
            delForDtlDataBase.setDD_Key((int)rrldDataBase.getPLKEYN());
            delForDtlDataBase.setDD_DelforReleaseNum(rrldDataBase.getPLREL());
            delForDtlDataBase.setDD_DelforDate(rrldDataBase.getPLRDAT());
            delForDtlDataBase.setDD_DelforTime(DateUtil.parseDate(rrldDataBase.getPLHHMM().ToString(),DateUtil.HOUR_ITEM));
            delForDtlDataBase.setDD_DelforDate(rrldDataBase.getPLTDAT());
            delForDtlDataBase.setDD_DelforQtyCum((int)rrldDataBase.getPLQCUM());
            delForDtlDataBase.setDD_Qty((int)rrldDataBase.getPLQNET());
            
            delForDtlDataBase.setDD_QtyAdj((int)rrldDataBase.getPLADJN());
            delForDtlDataBase.setDD_AuthLev(rrldDataBase.getPLAUTC());
            delForDtlDataBase.setDD_Timing(rrldDataBase.getPLTIMC());
            delForDtlDataBase.setDD_AuthType(rrldDataBase.getPLATYP());
            delForDtlDataBase.setDD_RanNumber(rrldDataBase.getPLRAN());
    
            delForDtlDataBaseContainer.Add(delForDtlDataBase);
        }	
        //Write the DelJitHdr table
        delForHdrDataBaseContainer.truncate();
        delForHdrDataBaseContainer.write();
        
        //Write the DelJitDtl table
        delForDtlDataBaseContainer.truncate();
        delForDtlDataBaseContainer.write();
       	if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return delForDtlDataBaseContainer.Count + delForHdrDataBaseContainer.Count; 
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}	
}

public 
int generateCMSPrhist(){
	try{
		PrhistDataBaseContainer prhistDataBaseContainer = new PrhistDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempPrhist(prhistDataBaseContainer);
//		return cmsTempToNujitMeHistMach(prhistDataBaseContainer);
		
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempPrhist(){
	try{
		PrhistDataBaseContainer prhistDataBaseContainer = new PrhistDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempPrhist(prhistDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private 
int cms400ToCmsTempPrhist(PrhistDataBaseContainer prhistDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		prhistDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
        
        for(IEnumerator en = prhistDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PrhistDataBase prhistDataBase = (PrhistDataBase) en.Current;
			prhistDataBase.setDB(Configuration.CMSLibrary_2nd);
		}
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		prhistDataBaseContainer.truncate();
		prhistDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
			
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
        
		return prhistDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}


public 
int generateCMSTrlp(){
	try{
		TrlpDataBaseContainer trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempTrlp(trlpDataBaseContainer);
		return cmsTempToNujitTPPartCrossRef(trlpDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
public 
int cms400ToCmsTempTrlp(){
	try{
		TrlpDataBaseContainer trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempTrlp(trlpDataBaseContainer);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private 
int cms400ToCmsTempTrlp(TrlpDataBaseContainer trlpDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		trlpDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
        TrlpDataBaseContainer newTrlpDataBaseContainer= new TrlpDataBaseContainer(dataBaseAccess);
        for( IEnumerator en = trlpDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			TrlpDataBase oldTrlpDataBase = (TrlpDataBase) en.Current;
		
			TrlpDataBase newTrlpDataBase = new TrlpDataBase(dataBaseAccess);
			
			newTrlpDataBase=oldTrlpDataBase;
			newTrlpDataBase.setDB(Configuration.CMSLibrary);
		
			newTrlpDataBaseContainer.Add(newTrlpDataBase);
		}
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		trlpDataBaseContainer.truncate();
		newTrlpDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		return newTrlpDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSTrpl(){
	try{
		TrplDataBaseContainer trplDataBaseContainer = new TrplDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempTrpl(trplDataBaseContainer);
		//Falta pasaje a Nujit
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
public 
int cms400ToCmsTempTrpl(){
	try{
		TrplDataBaseContainer trplDataBaseContainer = new TrplDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempTrpl(trplDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private 
int cms400ToCmsTempTrpl(TrplDataBaseContainer trplDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		trplDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
        TrplDataBaseContainer newTrplDataBaseContainer= new TrplDataBaseContainer(dataBaseAccess);
        
        for( IEnumerator en = trplDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			TrplDataBase oldTrplDataBase = (TrplDataBase) en.Current;
		
			TrplDataBase newTrplDataBase = new TrplDataBase(dataBaseAccess);
			
			newTrplDataBase=oldTrplDataBase;
			newTrplDataBase.setDB(Configuration.CMSLibrary);
		
			newTrplDataBaseContainer.Add(newTrplDataBase);
		}
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		trplDataBaseContainer.truncate();
		newTrplDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
    
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		return newTrplDataBaseContainer.Count;
		
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSTrpt(){
	try{
		TrptDataBaseContainer trptDataBaseContainer = new TrptDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempTrpt(trptDataBaseContainer);
		//Falta pasaje a Nujit
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempTrpt(){
	try{
		TrptDataBaseContainer trptDataBaseContainer = new TrptDataBaseContainer(dataBaseAccess);
		return cms400ToCmsTempTrpt(trptDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private 
int cms400ToCmsTempTrpt(TrptDataBaseContainer trptDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
		trptDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
        TrptDataBaseContainer newTrptDataBaseContainer= new TrptDataBaseContainer(dataBaseAccess);
        
        for( IEnumerator en = trptDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			TrptDataBase oldTrptDataBase = (TrptDataBase) en.Current;
		
			TrptDataBase newTrptDataBase = new TrptDataBase(dataBaseAccess);
			
			newTrptDataBase=oldTrptDataBase;
			newTrptDataBase.setDB(Configuration.CMSLibrary);
		
			newTrptDataBaseContainer.Add(newTrptDataBase);
		}
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		trptDataBaseContainer.truncate();
		newTrptDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
        
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		return newTrptDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCmsCustPart(){
	try{
		CsptDataBaseContainer csptDataBaseContainer = new CsptDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempCspt(csptDataBaseContainer);
		return cmsTempToNujitCustPart(csptDataBaseContainer);
		
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//CUST
public
int cms400ToCmsTempCspt(){
	try{
	    CsptDataBaseContainer csptDataBaseContainer = new CsptDataBaseContainer(dataBaseAccess);
	    return cms400ToCmsTempCspt(csptDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempCspt(CsptDataBaseContainer csptDataBaseContainer){
	try{
    	// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
	
		csptDataBaseContainer.read();
		
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
	    CsptDataBaseContainer newCsptDataBaseContainer = new CsptDataBaseContainer(dataBaseAccess);
    
   		//Iterator over the records recover to fill the DataBase
		for( IEnumerator en = csptDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			CsptDataBase oldCsptDataBase = (CsptDataBase) en.Current;
		
			CsptDataBase newCsptDataBase = new CsptDataBase(dataBaseAccess);
			
			newCsptDataBase=oldCsptDataBase;
			newCsptDataBase.setDB(Configuration.CMSLibrary);
		
			newCsptDataBaseContainer.Add(newCsptDataBase);
	
		}
	
	    if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

	    // clean database
	    csptDataBaseContainer.truncate();
	    newCsptDataBaseContainer.write();
    	
	    if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();
	    // restore connction to sql server
	    dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    	
	    return newCsptDataBaseContainer.Count;
	
}catch(PersistenceException persistenceException){
	dataBaseAccess.rollbackTransaction();
	throw new NujitException(persistenceException.Message, persistenceException);
}catch(System.Exception exception){
	dataBaseAccess.rollbackTransaction();
	throw new NujitException(exception.Message, exception);
}
}

public int cmsTempToNujitCustPart(){
	
	try{
		CsptDataBaseContainer csptDataBaseContainer = new CsptDataBaseContainer(dataBaseAccess);
		return cmsTempToNujitCustPart(csptDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

private
int cmsTempToNujitCustPart(CsptDataBaseContainer csptDataBaseContainer){
	try{	

		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (csptDataBaseContainer.Count == 0)
		    csptDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		CustPartDataBaseContainer custPartDataBaseContainer = new CustPartDataBaseContainer(dataBaseAccess);
		//Copy records from Cust to CustPart
		for (IEnumerator en = csptDataBaseContainer.GetEnumerator();en.MoveNext();){
			CsptDataBase csptDataBase = (CsptDataBase)en.Current;

            CustPartDataBase custPartDataBase= new CustPartDataBase(dataBaseAccess);
            
            custPartDataBase.setCP_Db(csptDataBase.getDB());
            custPartDataBase.setCP_ProdID(csptDataBase.getRRPART());
            
            CustVendDataBase custVendDataBase= new CustVendDataBase(dataBaseAccess);
            //custVendDataBase.setCV_Db(csptDataBase.getDB()); No estamos usando DB's
            custVendDataBase.setCV_ID(csptDataBase.getRRCUST());
            custVendDataBase.setCV_RecType("C");
            custVendDataBase.readByIdRecType();
            switch (custVendDataBase.getCV_CustomerType()){
				case "S": custPartDataBase.setCP_ShipToCust(csptDataBase.getRRCUST());
				          custPartDataBase.setCP_BillToCust("");  
				          break;
				case "E": custPartDataBase.setCP_BillToCust(csptDataBase.getRRCUST());
				          custPartDataBase.setCP_ShipToCust("");
				          break;
				case "B": custPartDataBase.setCP_BillToCust(csptDataBase.getRRCUST());
				          custPartDataBase.setCP_ShipToCust("");
				          break;
			}    
            custPartDataBase.setCP_CustPart(csptDataBase.getRRCPT());
            custPartDataBase.setCP_CustPartRev(csptDataBase.getRRREV());
            custPartDataBase.setCP_CustPartRevDate(csptDataBase.getRRRDAT());
            custPartDataBase.setCP_CustPartDes1(csptDataBase.getRRDES1()); 		 
            custPartDataBase.setCP_CustPartDes2(csptDataBase.getRRDES2());	
            custPartDataBase.setCP_CustPartDes3(csptDataBase.getRRDES3());
 	        custPartDataBase.setCP_Consignment(csptDataBase.getRRCONS());
	        custPartDataBase.setCP_StdPackQty(csptDataBase.getRRSDPQ());
	        custPartDataBase.setCP_StdPackCont(csptDataBase.getRRCNTR ());		 
 	        custPartDataBase.setCP_StdPackUnit(csptDataBase.getRRSDPU());	 
            custPartDataBase.setCP_StdPackSkidCode(csptDataBase.getRRPLCC()); 	 
			
			if(!custPartDataBase.exists())
				custPartDataBaseContainer.Add(custPartDataBase);
		}
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		custPartDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		return custPartDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cmsTempToNujitTPPartCrossRef(){
try{
	    TrlpDataBaseContainer trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);
	    return cmsTempToNujitTPPartCrossRef(trlpDataBaseContainer);
	    
}catch(System.Exception exception){
	throw new NujitException(exception.Message, exception);
}
}

private 
int cmsTempToNujitTPPartCrossRef(TrlpDataBaseContainer trlpDataBaseContainer){

	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (trlpDataBaseContainer.Count == 0)
			trlpDataBaseContainer.read();
		
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
			
		TPPartCrossRefDataBaseContainer tPPartCrossRefDataBaseContainer= new TPPartCrossRefDataBaseContainer(dataBaseAccess);
		
	    for (IEnumerator en = trlpDataBaseContainer.GetEnumerator();en.MoveNext();){
		    TrlpDataBase trlpDataBase = (TrlpDataBase)en.Current;

            TPPartCrossRefDataBase tPPartCrossRefDataBase = new TPPartCrossRefDataBase(dataBaseAccess);
               
            tPPartCrossRefDataBase.setTPP_Key((int)trlpDataBase.getSMCKEY());   
            tPPartCrossRefDataBase.setTPP_Db(trlpDataBase.getDB());   
            tPPartCrossRefDataBase.setTPP_Tpartner(trlpDataBase.getSMTRPT());   
            tPPartCrossRefDataBase.setTPP_TpartnerLoc(trlpDataBase.getSMSTXL());   
            tPPartCrossRefDataBase.setTPP_DockKey(trlpDataBase.getSMDOCK());   
            tPPartCrossRefDataBase.setTPP_CustPartID(trlpDataBase.getSMCPT());   
            tPPartCrossRefDataBase.setTPP_ModelYrKey(trlpDataBase.getSMYEAR());   
            tPPartCrossRefDataBase.setTPP_BillToCust(trlpDataBase.getSMCUST());   
            tPPartCrossRefDataBase.setTPP_ShipToCust(trlpDataBase.getSMLOCN());   
            tPPartCrossRefDataBase.setTPP_ProdID(trlpDataBase.getSMPART());   
            tPPartCrossRefDataBase.setTPP_OrderNum((int)trlpDataBase.getSMORD());   
            tPPartCrossRefDataBase.setTPP_OrderNumItem((int)trlpDataBase.getSMITM());   
            tPPartCrossRefDataBase.setTPP_PO(trlpDataBase.getSMCPO());   
            tPPartCrossRefDataBase.setTPP_PODate(trlpDataBase.getSMPDAT());   
            tPPartCrossRefDataBase.setTPP_DockCode(trlpDataBase.getSMDOK());   
            tPPartCrossRefDataBase.setTPP_Revision(trlpDataBase.getSMREV());   
            tPPartCrossRefDataBase.setTPP_RevDate(trlpDataBase.getSMVDAT());   
            tPPartCrossRefDataBase.setTPP_Expeditor(trlpDataBase.getSMEXPR());   
            tPPartCrossRefDataBase.setTPP_ExpeditorPhone(trlpDataBase.getSMEXPP());   
            tPPartCrossRefDataBase.setTPP_Plant(trlpDataBase.getSMPLNT());   
            tPPartCrossRefDataBase.setTPP_Line(trlpDataBase.getSMLINE());   
            tPPartCrossRefDataBase.setTPP_Drop(trlpDataBase.getSMDROP());   
            tPPartCrossRefDataBase.setTPP_DelforReleaseNum(trlpDataBase.getSMCREL());   
            tPPartCrossRefDataBase.setTPP_CurrentDelforDate(trlpDataBase.getSMRDAT());   
            tPPartCrossRefDataBase.setTPP_LastRecDate(trlpDataBase.getSMLDAT());   
            tPPartCrossRefDataBase.setTPP_LastRecQty((int)trlpDataBase.getSMLQTY());   
            tPPartCrossRefDataBase.setTPP_LastRecCum((int)trlpDataBase.getSMLCUM());   
            tPPartCrossRefDataBase.setTPP_CurrentCum((int)trlpDataBase.getSMCCUM());   
            tPPartCrossRefDataBase.setTPP_PriorCum((int)trlpDataBase.getSMPCUM());   
            tPPartCrossRefDataBase.setTPP_FabAuthor((int)trlpDataBase.getSMFABC());   
            tPPartCrossRefDataBase.setTPP_FabCumDelfor(trlpDataBase.getSMFCRL());   
            tPPartCrossRefDataBase.setTPP_FabCumDelforDate(trlpDataBase.getSMFCDT());   
            tPPartCrossRefDataBase.setTPP_MatAuthCum((int)trlpDataBase.getSMMTLC());   
            tPPartCrossRefDataBase.setTPP_MatAuthDelfor(trlpDataBase.getSMMCRL());   
            tPPartCrossRefDataBase.setTPP_MatAuthDate(trlpDataBase.getSMMCDT());   
            tPPartCrossRefDataBase.setTPP_CurrentDeljit(trlpDataBase.getSMSREF());   
            tPPartCrossRefDataBase.setTPP_CurrDeljitDate(trlpDataBase.getSMSDAT());   
            tPPartCrossRefDataBase.setTPP_Linked(trlpDataBase.getSMAUTG());   
            
            tPPartCrossRefDataBaseContainer.Add(tPPartCrossRefDataBase );
        }	
        
       if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        //Write the DelJitHdr table
        tPPartCrossRefDataBaseContainer.truncate();
        tPPartCrossRefDataBaseContainer.write();
        
        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
			
        return tPPartCrossRefDataBaseContainer.Count ; 
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}	
}

public 
int generateCmsPrHistLbHist(){
	try{
		LbHistDataBaseContainer lbHistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);
		PrhistDataBaseContainer prhistDataBaseContainer = new PrhistDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempPrhist(prhistDataBaseContainer);
		return cms400ToCmsTempLbHist(lbHistDataBaseContainer);
		
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public 
int cmsTempToNujitMeHistMach(){
	try{
		PrhistDataBaseContainer prhistDataBaseContainer = new PrhistDataBaseContainer(dataBaseAccess);
		return cmsTempToNujitMeHistMach(prhistDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

private 
int cmsTempToNujitMeHistMach(PrhistDataBaseContainer prhistDataBaseContainer){
	try{	
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (prhistDataBaseContainer.Count == 0)
		    prhistDataBaseContainer.read();

        ArrayList dates = prhistDataBaseContainer.readDwdate();
        
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		MeHistHdrDataBaseContainer meHistHdrDataBaseContainer = new MeHistHdrDataBaseContainer(dataBaseAccess);
		MeHistMachDtlDataBaseContainer meHistMachDtlDataBaseContainer = new MeHistMachDtlDataBaseContainer(dataBaseAccess);
		
		//Copy records from PRHIST to MeHistHdr and MeHistMachDtl
		for (IEnumerator en = prhistDataBaseContainer.GetEnumerator();en.MoveNext();){
			PrhistDataBase prhistDataBase = (PrhistDataBase)en.Current;

            MeHistMachDtlDataBase meHistMachDtlDataBase= new MeHistMachDtlDataBase(dataBaseAccess);
            
            meHistMachDtlDataBase.setMHMD_Db(prhistDataBase.getDB());
            meHistMachDtlDataBase.setMHMD_Plt(Configuration.DftPlant);
            meHistMachDtlDataBase.setMHMD_Dept(prhistDataBase.getDWDEPT());
            meHistMachDtlDataBase.setMHMD_Machine(prhistDataBase.getDWRESR());
            meHistMachDtlDataBase.setMHMD_Part(prhistDataBase.getDWPART());
            meHistMachDtlDataBase.setMHMD_Seq((int)prhistDataBase.getDWSEQN());
            meHistMachDtlDataBase.setMHMD_QtyRun(prhistDataBase.getDWQTYC()+prhistDataBase.getDWQTYS());
            meHistMachDtlDataBase.setMHMD_GoodQty(prhistDataBase.getDWQTYC());
            
            if (prhistDataBase.getDWMODE().Equals("D"))
                meHistMachDtlDataBase.setMHMD_DowntimeHrs(prhistDataBase.getDWTIME());
            if (prhistDataBase.getDWMODE().Equals("S"))
                meHistMachDtlDataBase.setMHMD_SetupHrs(prhistDataBase.getDWTIME());
            if (prhistDataBase.getDWMODE().Equals("R"))
                meHistMachDtlDataBase.setMHMD_RuntimeHrs(prhistDataBase.getDWTIME());
             
             meHistMachDtlDataBaseContainer.Add(meHistMachDtlDataBase);
		}
		
		//Process the dates from PrHist and we create the correct information in the container MeHistHdr.
		processDates(dates, meHistHdrDataBaseContainer); 
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		meHistHdrDataBaseContainer.write();
		meHistMachDtlDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
			
		return meHistMachDtlDataBaseContainer.Count;

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}



public 
int generateCmsLbHist(){
	try{
		LbHistDataBaseContainer lbhistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempLbHist(lbhistDataBaseContainer);
		return cmsTempToNujitMeHistLab(lbhistDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//LbHist
public
int cms400ToCmsTempLbHist(){
	try{
	    LbHistDataBaseContainer lbHistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);
	    return cms400ToCmsTempLbHist(lbHistDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


private
int cms400ToCmsTempLbHist(LbHistDataBaseContainer lbHistDataBaseContainer){
	try{
    	// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
	
		lbHistDataBaseContainer.read();
		
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
	    LbHistDataBaseContainer newLbHistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);
    
   		//Iterator over the records recover to fill the DataBase
		for( IEnumerator en = lbHistDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			LbHistDataBase oldLbHistDataBase = (LbHistDataBase) en.Current;
		
			LbHistDataBase newLbHistDataBase = new LbHistDataBase(dataBaseAccess);
			
			newLbHistDataBase=oldLbHistDataBase;
			newLbHistDataBase.setDb(Configuration.CMSLibrary);
		
			newLbHistDataBaseContainer.Add(newLbHistDataBase);
	
		}
	
	    if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

	    // clean database
	    lbHistDataBaseContainer.truncate();
	    newLbHistDataBaseContainer.write();
    	
	    if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();
	    // restore connction to sql server
	    dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    	
	    return newLbHistDataBaseContainer.Count;
	
}catch(PersistenceException persistenceException){
	dataBaseAccess.rollbackTransaction();
	throw new NujitException(persistenceException.Message, persistenceException);
}catch(System.Exception exception){
	dataBaseAccess.rollbackTransaction();
	throw new NujitException(exception.Message, exception);
}
}

public int cmsTempToNujitMeHistLab(){
	
	try{
		LbHistDataBaseContainer lbHistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);
		return cmsTempToNujitMeHistLab(lbHistDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

private
int cmsTempToNujitMeHistLab(LbHistDataBaseContainer lbHistDataBaseContainer){
	try{	

		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		
		if (lbHistDataBaseContainer.Count == 0)
		    lbHistDataBaseContainer.read();
        
        ArrayList dates = lbHistDataBaseContainer.readDvdate();
        
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		
		MeHistHdrDataBaseContainer meHistHdrDataBaseContainer = new MeHistHdrDataBaseContainer(dataBaseAccess);
		MeHistLabDtlDataBaseContainer meHistLabDtlDataBaseContainer = new MeHistLabDtlDataBaseContainer(dataBaseAccess);
		//Copy records from LBHIST to MeHistHdr and MeHistDtl
		for (IEnumerator en = lbHistDataBaseContainer.GetEnumerator();en.MoveNext();){
			LbHistDataBase lbHistDataBase = (LbHistDataBase)en.Current;

            MeHistLabDtlDataBase meHistLabDtlDataBase= new MeHistLabDtlDataBase(dataBaseAccess);
            
            meHistLabDtlDataBase.setMHLD_Db(lbHistDataBase.getDb());
            meHistLabDtlDataBase.setMHLD_Employee(lbHistDataBase.getDVEMPL());
            meHistLabDtlDataBase.setMHLD_Part(lbHistDataBase.getDVPART());
            meHistLabDtlDataBase.setMHLD_Seq((int)lbHistDataBase.getDVSEQN());
            meHistLabDtlDataBase.setMHLD_QtyRun(lbHistDataBase.getDVQTYC()+ lbHistDataBase.getDVQTYS());
            meHistLabDtlDataBase.setMHLD_GoodQty(lbHistDataBase.getDVQTYC()); 
            meHistLabDtlDataBase.setMHLD_ScrapLastMonth(lbHistDataBase.getDVQTYS());
            
            decimal eff= 0;
            if (lbHistDataBase.getDVMODE().Equals("D"))
                meHistLabDtlDataBase.setMHLD_DowntimeHrs(lbHistDataBase.getDVTIME());
            if (lbHistDataBase.getDVMODE().Equals("R"))
                meHistLabDtlDataBase.setMHLD_LabHrs(lbHistDataBase.getDVTIME());
            if (lbHistDataBase.getDVMODE().Equals("I"))
                meHistLabDtlDataBase.setMHLD_IndirectLabHrs(lbHistDataBase.getDVTIME());
                
            //Effic. = (good + scrap)/hours of run time
            //       = (DWQTYS + DVQTYC)/ hours of run time
            if (meHistLabDtlDataBase.getMHLD_IndirectLabHrs() != 0 )
                eff= (lbHistDataBase.getDVQTYC() +lbHistDataBase.getDVQTYS())/lbHistDataBase.getDVTIME();
        
            meHistLabDtlDataBase.setMHLD_EffPercent(eff);

            //DVQTYS/(DWQTYS + DVQTYC)
            if ((lbHistDataBase.getDVQTYS() + lbHistDataBase.getDVQTYC())!=0)
                eff = lbHistDataBase.getDVQTYS() /(lbHistDataBase.getDVQTYS() + lbHistDataBase.getDVQTYC());
            else
                eff = 0;
            meHistLabDtlDataBase.setMHLD_ScraptPercent(eff);
            
            meHistLabDtlDataBaseContainer.Add(meHistLabDtlDataBase);
		}
		
		//Process the dates and we fill the records in the Container
		processDates(dates, meHistHdrDataBaseContainer);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		meHistHdrDataBaseContainer.write();
		meHistLabDtlDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
			
		return meHistLabDtlDataBaseContainer.Count;

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private 
void processDates(ArrayList arrayDates, MeHistHdrDataBaseContainer meHistHdrDataBaseContainer){
	for(IEnumerator en = arrayDates.GetEnumerator(); en.MoveNext(); ){
		string[] lineArray = (string[])en.Current;
		int day =1;
		DateTime date = DateUtil.parseDate(lineArray[0].ToString(),DateUtil.MMDDYYYY);
		DateTime startDate = new DateTime(date.Year,date.Month,day);
		int month = startDate.Month;
		int year = startDate.Year;
		if (month ==12){
			month =1;
			year ++;
		}else
			month ++;
		DateTime endDate = new DateTime(year,month,day).AddDays(-1);    
	    
		MeHistHdrDataBase meHistHdrDataBase= new MeHistHdrDataBase(dataBaseAccess);
		meHistHdrDataBase.setSHH_Plt(Configuration.DftPlant);
		meHistHdrDataBase.setSHH_EndDate(endDate);
		meHistHdrDataBase.setSHH_StartDate(startDate);
		meHistHdrDataBase.setSHH_Date(date);
		if (! meHistHdrDataBase.exists())
			if (!meHistHdrDataBaseContainer.Contains(meHistHdrDataBase))
				meHistHdrDataBaseContainer.Add(meHistHdrDataBase);      
	}
}

//---------------------------------------------------------------------------

public
int cms400ToCmsTempPssc(){
	try{
		PsscDataBaseContainer psscDataBaseContainer = new PsscDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempPssc(psscDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempPssc(PsscDataBaseContainer psscDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		psscDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		psscDataBaseContainer.truncate();
		psscDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return psscDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitPssc(){
	try{
		PsscDataBaseContainer psscDataBaseContainer = new PsscDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitPssc(psscDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitPssc(PsscDataBaseContainer psscDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (psscDataBaseContainer.Count == 0)
			psscDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		psscDataBaseContainer.truncate();
		psscDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return psscDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToNujitPssc(){
	try{
		PsscDataBaseContainer psscDataBaseContainer = new PsscDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempPssc(psscDataBaseContainer);
		return cmsTempToNujitPssc(psscDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
}

//---------------------------------------------------------------------------

public
int cms400ToCmsTempScrap(){
	try{
		ScrapDataBaseContainer scrapDataBaseContainer = new ScrapDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempScrap(scrapDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempScrap(ScrapDataBaseContainer scrapDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		scrapDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		scrapDataBaseContainer.truncate();
		scrapDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return scrapDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitScrap(){
	try{
		ScrapDataBaseContainer scrapDataBaseContainer = new ScrapDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitScrap(scrapDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitScrap(ScrapDataBaseContainer scrapDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (scrapDataBaseContainer.Count == 0)
			scrapDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

// There isn't scrap table in nujit database
//		if (!userHandleTransaction)
//			dataBaseAccess.beginTransaction();
//
//		scrapDataBaseContainer.truncate();
//		scrapDataBaseContainer.write();
//
//		if (!userHandleTransaction)
//			dataBaseAccess.commitTransaction();

		return scrapDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToNujitScrap(){
	try{
		ScrapDataBaseContainer scrapDataBaseContainer = new ScrapDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempScrap(scrapDataBaseContainer);
		return cmsTempToNujitScrap(scrapDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
}

//---------------------------------------------------------------------------

public
int cms400ToCmsTempSprsn(){
	try{
		SprsnDataBaseContainer sprsnDataBaseContainer = new SprsnDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempSprsn(sprsnDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempSprsn(SprsnDataBaseContainer sprsnDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		sprsnDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		sprsnDataBaseContainer.truncate();
		sprsnDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return sprsnDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitSprsn(){
	try{
		SprsnDataBaseContainer sprsnDataBaseContainer = new SprsnDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitSprsn(sprsnDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitSprsn(SprsnDataBaseContainer sprsnDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (sprsnDataBaseContainer.Count == 0)
			sprsnDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		sprsnDataBaseContainer.truncate();
		sprsnDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return sprsnDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToNujitSprsn(){
	try{
		SprsnDataBaseContainer sprsnDataBaseContainer = new SprsnDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempSprsn(sprsnDataBaseContainer);
		return cmsTempToNujitSprsn(sprsnDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
}

//---------------------------------------------------------------------------

public 
int generateCMSIcstm(){
	try{
		IcstmDataBaseContainer icstmDataBaseContainer = new IcstmDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempIcstm(icstmDataBaseContainer);
		cmsTempToNujitIcstm(icstmDataBaseContainer);
		
		return icstmDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public
int cms400ToCmsTempIcstm(){
	try{
		IcstmDataBaseContainer icstmDataBaseContainer = new IcstmDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempIcstm(icstmDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempIcstm(IcstmDataBaseContainer icstmDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		icstmDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		icstmDataBaseContainer.truncate();
		icstmDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return icstmDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitIcstm(){
	try{
		IcstmDataBaseContainer icstmDataBaseContainer = new IcstmDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitIcstm(icstmDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitIcstm(IcstmDataBaseContainer icstmDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (icstmDataBaseContainer.Count == 0)
			icstmDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActCostDataBaseContainer prodFmActCostDataBaseContainer = new ProdFmActCostDataBaseContainer(dataBaseAccess);
		
		for(int i = 0; i < icstmDataBaseContainer.Count; i++){
			IcstmDataBase icstmDataBase = (IcstmDataBase) icstmDataBaseContainer[i];

			ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
			
			prodFmActCostDataBase.setPAC_ProdID(icstmDataBase.getCGPART());
			prodFmActCostDataBase.setPAC_ActID("");
			prodFmActCostDataBase.setPAC_Seq(0);
			prodFmActCostDataBase.setPAC_PartType("M");
			prodFmActCostDataBase.setPAC_Cost(icstmDataBase.getCGSTCS());
			
			prodFmActCostDataBaseContainer.Add(prodFmActCostDataBase);
		}

		prodFmActCostDataBaseContainer.truncateManufactured();
		prodFmActCostDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return icstmDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}
//------------------------------------------------------------------------------

public 
int generateCMSIcstp(){
	try{
		IcstpDataBaseContainer icstpDataBaseContainer = new IcstpDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempIcstp(icstpDataBaseContainer);
		cmsTempToNujitIcstp(icstpDataBaseContainer);
		
		return icstpDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempIcstp(){
	try{
		IcstpDataBaseContainer icstpDataBaseContainer = new IcstpDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempIcstp(icstpDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempIcstp(IcstpDataBaseContainer icstpDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		icstpDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		icstpDataBaseContainer.truncate();
		icstpDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return icstpDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}


public
int cmsTempToNujitIcstp(){
	try{
		IcstpDataBaseContainer icstpDataBaseContainer = new IcstpDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitIcstp(icstpDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitIcstp(IcstpDataBaseContainer icstpDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (icstpDataBaseContainer.Count == 0)
			icstpDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActCostDataBaseContainer prodFmActCostDataBaseContainer = new ProdFmActCostDataBaseContainer(dataBaseAccess);
		
		for(int i = 0; i < icstpDataBaseContainer.Count; i++){
			IcstpDataBase icstpDataBase = (IcstpDataBase) icstpDataBaseContainer[i];

			ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
			
			prodFmActCostDataBase.setPAC_ProdID(icstpDataBase.getCHPART());
			prodFmActCostDataBase.setPAC_ActID("");
			prodFmActCostDataBase.setPAC_Seq(0);
			prodFmActCostDataBase.setPAC_PartType("M");
			prodFmActCostDataBase.setPAC_Cost(icstpDataBase.getCHSTCS());
			
			prodFmActCostDataBaseContainer.Add(prodFmActCostDataBase);
		}

		prodFmActCostDataBaseContainer.truncateManufactured();
		prodFmActCostDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return icstpDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

//---------------------------------------------------------------------------
public 
int generateCMSMmgp(){
	try{
		MmgpDataBaseContainer mmgpDataBaseContainer = new MmgpDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempMmgp(mmgpDataBaseContainer);
		cmsTempToNujitMmgp(mmgpDataBaseContainer);
		
		return mmgpDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempMmgp(){
	try{
		MmgpDataBaseContainer mmgpDataBaseContainer = new MmgpDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempMmgp(mmgpDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempMmgp(MmgpDataBaseContainer mmgpDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		mmgpDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		mmgpDataBaseContainer.truncate();
		mmgpDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return mmgpDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitMmgp(){
	try{
		MmgpDataBaseContainer mmgpDataBaseContainer = new MmgpDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitMmgp(mmgpDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitMmgp(MmgpDataBaseContainer mmgpDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (mmgpDataBaseContainer.Count == 0)
			mmgpDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();


		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return mmgpDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}
//------------------------------------------------------------------------------

public 
int generateCMSStkt(){
	try{
	
		StktDataBaseContainer stktDataBaseContainer= new StktDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempStkt(stktDataBaseContainer);
		
		return stktDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempStkt(){
	StktDataBaseContainer stktDataBaseContainer= new StktDataBaseContainer(dataBaseAccess);
	cms400ToCmsTempStkt(stktDataBaseContainer);
	return stktDataBaseContainer.Count;
	
}
private
int cms400ToCmsTempStkt(StktDataBaseContainer stktDataBaseContainer){
	try{
	
	    //First we check if we have to transfer all the records or only the last one that we dont't
	    //transfer yet.
	    dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
	    StktDataBaseContainer auxStktDataBaseContainer= new  StktDataBaseContainer(dataBaseAccess);
	    int maxTransaction = auxStktDataBaseContainer.readMaxByTran();
	    
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
     
		stktDataBaseContainer.read(maxTransaction);

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// we don't clean the table, if there are transactions there we keep it.
		stktDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return stktDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSRprd(){
	try{
		RprdDataBaseContainer rprdDataBaseContainer= new RprdDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRprd(rprdDataBaseContainer);
		
		return rprdDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempRprd(){
	RprdDataBaseContainer rprdDataBaseContainer= new RprdDataBaseContainer(dataBaseAccess);
	cms400ToCmsTempRprd(rprdDataBaseContainer);
	return rprdDataBaseContainer.Count;
}

private
int cms400ToCmsTempRprd(RprdDataBaseContainer rprdDataBaseContainer){
	try{    
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
     
		rprdDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// we don't clean the table, if there are transactions there we keep it.
		rprdDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return rprdDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSRprr(){
	try{
		RprrDataBaseContainer rprrDataBaseContainer= new RprrDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRprr(rprrDataBaseContainer);
		
		return rprrDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempRprr(){
	RprrDataBaseContainer rprrDataBaseContainer= new RprrDataBaseContainer(dataBaseAccess);
	cms400ToCmsTempRprr(rprrDataBaseContainer);
	return rprrDataBaseContainer.Count;
}

private
int cms400ToCmsTempRprr(RprrDataBaseContainer rprrDataBaseContainer){
	try{    
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
     
		rprrDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// we don't clean the table, if there are transactions there we keep it.
		rprrDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return rprrDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSRprs(){
	try{
		RprsDataBaseContainer rprsDataBaseContainer= new RprsDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRprs(rprsDataBaseContainer);
		
		return rprsDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempRprs(){
	RprsDataBaseContainer rprsDataBaseContainer= new RprsDataBaseContainer(dataBaseAccess);
	cms400ToCmsTempRprs(rprsDataBaseContainer);
	return rprsDataBaseContainer.Count;
}

private
int cms400ToCmsTempRprs(RprsDataBaseContainer rprsDataBaseContainer){
	try{    
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
     
		rprsDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// we don't clean the table, if there are transactions there we keep it.
		rprsDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return rprsDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSRprh(){
	try{
		RPRHDataBaseContainer rprhDataBaseContainer= new RPRHDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRprh(rprhDataBaseContainer);
		
		return rprhDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempRprh(){
	RPRHDataBaseContainer rprhDataBaseContainer= new RPRHDataBaseContainer(dataBaseAccess);
	cms400ToCmsTempRprh(rprhDataBaseContainer);
	return rprhDataBaseContainer.Count;
}

private
int cms400ToCmsTempRprh(RPRHDataBaseContainer rprhDataBaseContainer){
	try{    
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
     
		rprhDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// we don't clean the table, if there are transactions there we keep it.
		rprhDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return rprhDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSRprp(){
	try{
		RPRPDataBaseContainer rprpDataBaseContainer= new RPRPDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempRprp(rprpDataBaseContainer);
		
		return rprpDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempRprp(){
	RPRPDataBaseContainer rprpDataBaseContainer= new RPRPDataBaseContainer(dataBaseAccess);
	cms400ToCmsTempRprp(rprpDataBaseContainer);
	return rprpDataBaseContainer.Count;
}

private
int cms400ToCmsTempRprp(RPRPDataBaseContainer rprpDataBaseContainer){
	try{    
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
     
		rprpDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// we don't clean the table, if there are transactions there we keep it.
		rprpDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return rprpDataBaseContainer.Count;
	}catch(System.Threading.ThreadAbortException){
	    return 0;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/*** MTHL - Method File - Tooling ***/

public
int cms400ToCmsTempMthl(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		MTHLDataBaseContainer mthlDataBaseContainer = new MTHLDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempMthl(mthlDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempMthl(MTHLDataBaseContainer mthlDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		mthlDataBaseContainer.read();
	
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		mthlDataBaseContainer.truncate();
		mthlDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return mthlDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cmsTempToNujitMthl(){
	try{
		MTHLDataBaseContainer mthlDataBaseContainer = new MTHLDataBaseContainer(dataBaseAccess);
		return cmsTempToNujitMthl(mthlDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitMthl(MTHLDataBaseContainer mthlDataBaseContainer){
	try{	
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (mthlDataBaseContainer.Count == 0)
			mthlDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// Copy records from cmstemp.MTHL to nujit.PdPartTool
		PdToolPartDataBaseContainer pdToolDataBaseContainer = new PdToolPartDataBaseContainer(dataBaseAccess);
		IEnumerator en = mthlDataBaseContainer.GetEnumerator();
		while(en.MoveNext()){
			MTHLDataBase mthlDataBase = (MTHLDataBase)en.Current;
			PdToolPartDataBase pdToolPartDataBase = new PdToolPartDataBase(dataBaseAccess);
			pdToolPartDataBase.setPTP_Db(Configuration.CMSLibrary);	
			pdToolPartDataBase.setPTP_Company(Configuration.DftCompany.ToString());
			pdToolPartDataBase.setPTP_Plant(Configuration.DftPlant);
			pdToolPartDataBase.setPTP_Family("");
			pdToolPartDataBase.setPTP_Part(mthlDataBase.getMHPART());
			pdToolPartDataBase.setPTP_Seq((int)mthlDataBase.getMHSEQ());
			pdToolPartDataBase.setPTP_LineNum((int)mthlDataBase.getMHLIN());
			pdToolPartDataBase.setPTP_EntryNum((int)mthlDataBase.getMHENT());
			pdToolPartDataBase.setPTP_ToolNum(mthlDataBase.getMHTOOL());
			pdToolPartDataBase.setPTP_ReqSetup(mthlDataBase.getMHRSET());
			pdToolPartDataBase.setPTP_ReqRun(mthlDataBase.getMHRRUN());
			pdToolPartDataBase.setPTP_Qty(mthlDataBase.getMHQTYP());
			pdToolPartDataBase.setPTP_Uom(mthlDataBase.getMHUNIT());
			
			pdToolDataBaseContainer.Add(pdToolPartDataBase);
		}
		
		pdToolDataBaseContainer.truncate();
		pdToolDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		return mthlDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSMthl(){
	try{
		//Save records from AS400 to CmsTemp and then copy to Nujit
		MTHLDataBaseContainer mthlDataBaseContainer = new MTHLDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempMthl(mthlDataBaseContainer);

		//Copy to Nujit
		return cmsTempToNujitMthl(mthlDataBaseContainer);	
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/*********************************************************************/

/*** TMST - Tool Master File ***/

public
int cms400ToCmsTempTmst(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TMSTDataBaseContainer tmstDataBaseContainer = new TMSTDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempTmst(tmstDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempTmst(TMSTDataBaseContainer tmstDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		tmstDataBaseContainer.read();
	
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		tmstDataBaseContainer.truncate();
		tmstDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return tmstDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cmsTempToNujitTmst(){
	try{
		TMSTDataBaseContainer tmstDataBaseContainer = new TMSTDataBaseContainer(dataBaseAccess);
		return cmsTempToNujitTmst(tmstDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitTmst(TMSTDataBaseContainer tmstDataBaseContainer){
	try{	
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (tmstDataBaseContainer.Count == 0)
			tmstDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		// Copy records from cmstemp.TMST to nujit.PdTool
		PdToolDataBaseContainer pdToolDataBaseContainer = new PdToolDataBaseContainer(dataBaseAccess);
		IEnumerator en = tmstDataBaseContainer.GetEnumerator();
		while(en.MoveNext()){
			TMSTDataBase tmstDataBase = (TMSTDataBase)en.Current;
			PdToolDataBase pdToolDataBase = new PdToolDataBase(dataBaseAccess);
			pdToolDataBase.setTOO_Db(Configuration.CMSLibrary);	
			pdToolDataBase.setTOO_Company(Configuration.DftCompany.ToString());
			pdToolDataBase.setTOO_Plant(Configuration.DftPlant);
			pdToolDataBase.setTOO_ToolNumber(tmstDataBase.getLXTOOL());
			pdToolDataBase.setTOO_Desc1(tmstDataBase.getLXDES1());
			pdToolDataBase.setTOO_Desc2(tmstDataBase.getLXDES2());
			pdToolDataBase.setTOO_Desc3(tmstDataBase.getLXDES3());
			pdToolDataBase.setTOO_MaintenanceClass(tmstDataBase.getLXCLSS());
			pdToolDataBase.setTOO_AssetID(tmstDataBase.getLXAST());
			pdToolDataBase.setTOO_ToolStatus(tmstDataBase.getLXSTAT());
			pdToolDataBase.setTOO_ScheduleStatus(tmstDataBase.getLXAST());
			pdToolDataBase.setTOO_ProductionUom(tmstDataBase.getLXUNIT());
			pdToolDataBase.setTOO_CurrentWorkOrder(tmstDataBase.getLXCORD());
			
			pdToolDataBaseContainer.Add(pdToolDataBase);
		}
		
		pdToolDataBaseContainer.truncate();
		pdToolDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		return tmstDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
int generateCMSTmst(){
	try{
		//Save records from AS400 to CmsTemp and then copy to Nujit
		TMSTDataBaseContainer tmstDataBaseContainer = new TMSTDataBaseContainer(dataBaseAccess);
		cms400ToCmsTempTmst(tmstDataBaseContainer);

		//Copy to Nujit
		return cmsTempToNujitTmst(tmstDataBaseContainer);	
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/*********************************************************************/

} // class
} // namespace