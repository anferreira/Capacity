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
using System.IO;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip;
using Nujit.NujitERP.ClassLib.Core.Cms.PackSlips;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class CmsCoreFactory : CapacityDemandCoreFactory{

protected
CmsCoreFactory() : base(){
}

//---------------------------------------------------------------------------
public
string[][] generateCMSInventory2(){
    try{
        string[] stkbFilter = new string[0];
        string[] wipbFilter= new string[0];

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
        prodFmInfoDataBaseContainer.read();

        return generateCMSInventory( stkbFilter, wipbFilter,prodFmInfoDataBaseContainer,false);

    }catch(PersistenceException persistenceException){	
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] generateCMSInventory(string[] stkbFilter, string[] wipbFilter, 
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,bool bloadSsch){
	try{
#if !DEBUGAF
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);        
        
        int irows=Configuration.DataTransferMaxRecords;

		StkbDataBaseContainer stkbDataBaseContainer = new StkbDataBaseContainer(dataBaseAccess);
		if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "STKB")){
            if (irows > 0)  loadStkbBySteps(stkbDataBaseContainer, irows);
            else			stkbDataBaseContainer.read(stkbFilter);
		}else
			throw new NujitException("Table STKB is locked !!!");

		WipbDataBaseContainer wipbDataBaseContainer = new WipbDataBaseContainer(dataBaseAccess);
		if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "WIPB")){
            if (irows > 0)  loadWipbBySteps(wipbDataBaseContainer,irows);
			else            wipbDataBaseContainer.read(wipbFilter);
		}else
			throw new NujitException("Table WIPB is locked !!!");

		SschDataBaseContainer sschDataBaseContainer = new SschDataBaseContainer(dataBaseAccess);
        if (bloadSsch){
		    if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "SSCH")){
                if (irows > 0)  loadSschBySteps(sschDataBaseContainer, irows);
                else            sschDataBaseContainer.read();                                   
		    }else
			    throw new NujitException("Table SSCH is locked !!!");
        }
        /*
        SeriDataBaseContainer seriDataBaseContainer = new SeriDataBaseContainer(dataBaseAccess);
        if (!dataBaseAccess.isBlocked(Configuration.CMSLibrary, "SERI"))
            seriDataBaseContainer.read();
		else
			throw new NujitException("Table SERI is locked !!!");       
*/
		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

if (bloadSsch){
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database        
		stkbDataBaseContainer.truncate();
		wipbDataBaseContainer.truncate();
        if (bloadSsch)
		    sschDataBaseContainer.truncate();
       // seriDataBaseContainer.truncate();        

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
        //seriDataBaseContainer.write();        
}

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
#if !DEBUGAF
        if (bloadSsch){
		    if (!userHandleTransaction)
			    dataBaseAccess.commitTransaction();
        }
		
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
            invPltLocDataBase.setIPL_Plant(wipbDataBase.getVDPLNT());
            invPltLocDataBase.setIPL_FinishedGoods(Constants.STRING_NO);
		
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
            invPltLocDataBase.setIPL_Plant(stkbDataBase.getBXPLNT());
            invPltLocDataBase.setIPL_FinishedGoods(Constants.STRING_YES);

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

#if !DEBUGAF        
		invPltLocDataBaseContainer.truncate();
        if (bloadSsch){
		    demDetailDataBaseContainer.truncate();
		    schDemDetailDataBaseContainer.truncate();
        }
        //seriDataBaseContainer.truncate();
        
		//invPltLocDataBaseContainer.write(); //AF changed , related to duplicate issue
        foreach(InvPltLocDataBase invPltLocDataBase in invPltLocDataBaseContainer){
            if (invPltLocDataBase.exists()){
                //read so we can summarize qoh
                InvPltLocDataBase invPltLocDataBaseOld = new InvPltLocDataBase(dataBaseAccess);
                invPltLocDataBaseOld.setIPL_ProdID(invPltLocDataBase.getIPL_ProdID());
                invPltLocDataBaseOld.setIPL_Seq(invPltLocDataBase.getIPL_Seq());
                invPltLocDataBaseOld.setIPL_StkLoc(invPltLocDataBase.getIPL_StkLoc());
                invPltLocDataBaseOld.setIPL_Plant(invPltLocDataBase.getIPL_Plant());
                invPltLocDataBaseOld.read();

                invPltLocDataBase.setIPL_Qoh(invPltLocDataBase.getIPL_Qoh() + invPltLocDataBaseOld.getIPL_Qoh());
                invPltLocDataBase.update();
            }else
                invPltLocDataBase.write();
        }
		demDetailDataBaseContainer.write();
		schDemDetailDataBaseContainer.write();        
        //seriDataBaseContainer.write();   //write seri same as on cmstemp database    
               		
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
            invPltLocDataBase.setIPL_FinishedGoods(Constants.STRING_NO);

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
            invPltLocDataBase.setIPL_FinishedGoods(Constants.STRING_YES);
		
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
int cms400ToCmsTempItems(string splant){
	try{
		StkMMDataBaseContainer stkMMDataBaseContainer = new StkMMDataBaseContainer(dataBaseAccess);
		StkMPDataBaseContainer stkMPDataBaseContainer = new StkMPDataBaseContainer(dataBaseAccess);
		MetHdrDataBaseContainer metHdrDataBaseContainer = new MetHdrDataBaseContainer(dataBaseAccess);
		MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
        MetHdaDataBaseContainer metHdaDataBaseContainer = new MetHdaDataBaseContainer(dataBaseAccess);
		PopTvnDataBaseContainer popTvnDataBaseContainer = new PopTvnDataBaseContainer(dataBaseAccess);
        StkaDataBaseContainer   stkaDataBaseContainer = new StkaDataBaseContainer(dataBaseAccess);
     
        return cms400ToCmsTempItems(splant,stkMMDataBaseContainer, stkMPDataBaseContainer,
                                    metHdrDataBaseContainer, metHdmDataBaseContainer, metHdaDataBaseContainer, 
                                    popTvnDataBaseContainer, stkaDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int loadCms400Items(string splant,
                    StkMMDataBaseContainer stkMMDataBaseContainer,
		            StkMPDataBaseContainer stkMPDataBaseContainer, 
		            MetHdrDataBaseContainer metHdrDataBaseContainer,
		            MetHdmDataBaseContainer metHdmDataBaseContainer,
                    MetHdaDataBaseContainer metHdaDataBaseContainer,
                    PopTvnDataBaseContainer popTvnDataBaseContainer,
                    StkaDataBaseContainer stkaDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        int         irows=Configuration.DataTransferMaxRecords;         //System.Windows.Forms.MessageBox.Show("DataTransferMaxRecords:" + irows);
       
        if (irows > 0){                    
            loadStkMMBySteps(stkMMDataBaseContainer,"",irows);          //System.Windows.Forms.MessageBox.Show("stkMM:" +stkMMDataBaseContainer.Count);
            loadStkMPBySteps(stkMPDataBaseContainer,"",irows);          //System.Windows.Forms.MessageBox.Show("stkMP:" + stkMPDataBaseContainer.Count);
            loadMetHdrBySteps(metHdrDataBaseContainer,splant,irows);    //System.Windows.Forms.MessageBox.Show("metHdr:"+ metHdrDataBaseContainer.Count);        
            loadMetHdmBySteps(metHdmDataBaseContainer,splant,irows);    //System.Windows.Forms.MessageBox.Show("metHdm:"+ metHdmDataBaseContainer.Count);
            loadMetHdaBySteps(metHdaDataBaseContainer,splant,irows);    //System.Windows.Forms.MessageBox.Show("metHda:"+ metHdaDataBaseContainer.Count);                    
            loadPopTvnBySteps(popTvnDataBaseContainer,irows);           //System.Windows.Forms.MessageBox.Show("popTvn:"+ popTvnDataBaseContainer.Count);
            loadStkaBySteps(stkaDataBaseContainer,splant,Constants.STATUS_ACTIVE,irows);    //System.Windows.Forms.MessageBox.Show("stka:"  + stkaDataBaseContainer.Count);
        }else{              
            stkMMDataBaseContainer.readByFilters("",splant,0);      dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);//AF 2019/09/20 connect each time because of timeout issue
            stkMPDataBaseContainer.read();                          dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
            metHdrDataBaseContainer.readByFilters("",splant,0);     dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
            metHdmDataBaseContainer.readByFilters("",splant,0);     dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
            metHdaDataBaseContainer.readByFilters("",splant,0);     dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
            popTvnDataBaseContainer.read();                         dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);        
            stkaDataBaseContainer.readByFilters("",splant,"Y",0);   dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);        
        }
        return stkMMDataBaseContainer.Count+ stkMPDataBaseContainer.Count;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempItems(string splant,
                        StkMMDataBaseContainer stkMMDataBaseContainer,
		                StkMPDataBaseContainer stkMPDataBaseContainer, 
		                MetHdrDataBaseContainer metHdrDataBaseContainer,
		                MetHdmDataBaseContainer metHdmDataBaseContainer,
                        MetHdaDataBaseContainer metHdaDataBaseContainer,
		                PopTvnDataBaseContainer popTvnDataBaseContainer,
                        StkaDataBaseContainer stkaDataBaseContainer){
	try{
		         
        loadCms400Items(splant,stkMMDataBaseContainer,stkMPDataBaseContainer,
                        metHdrDataBaseContainer,metHdmDataBaseContainer,metHdaDataBaseContainer,
		                popTvnDataBaseContainer,stkaDataBaseContainer);

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
		// clean database
		stkMMDataBaseContainer.truncate();
		stkMPDataBaseContainer.truncate();
		metHdrDataBaseContainer.truncate();
		metHdmDataBaseContainer.truncate();
        metHdaDataBaseContainer.truncate();
		popTvnDataBaseContainer.truncate();
        stkaDataBaseContainer.truncate();
        		        
		stkMMDataBaseContainer.write();
		stkMPDataBaseContainer.write();
		metHdrDataBaseContainer.write();
		metHdmDataBaseContainer.write();
        metHdaDataBaseContainer.write();
		popTvnDataBaseContainer.write();
        stkaDataBaseContainer.write();
        
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
int cmsTempToNujitItems(string splant){
	try{
		StkMMDataBaseContainer stkMMDataBaseContainer = new StkMMDataBaseContainer(dataBaseAccess);
		StkMPDataBaseContainer stkMPDataBaseContainer = new StkMPDataBaseContainer(dataBaseAccess);
		MetHdrDataBaseContainer metHdrDataBaseContainer = new MetHdrDataBaseContainer(dataBaseAccess);
		MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
        MetHdaDataBaseContainer metHdaDataBaseContainer = new MetHdaDataBaseContainer(dataBaseAccess);
        PopTvnDataBaseContainer popTvnDataBaseContainer = new PopTvnDataBaseContainer(dataBaseAccess);
        StkaDataBaseContainer stkaDataBaseContainer = new StkaDataBaseContainer(dataBaseAccess);
        
        return cmsTempToNujitItems(splant,
                                   stkMMDataBaseContainer, stkMPDataBaseContainer,
			                       metHdrDataBaseContainer, metHdmDataBaseContainer, metHdaDataBaseContainer,
                                   popTvnDataBaseContainer, 
                                   stkaDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitItems(
        string splant,
        StkMMDataBaseContainer stkMMDataBaseContainer,
		StkMPDataBaseContainer stkMPDataBaseContainer, 
		MetHdrDataBaseContainer metHdrDataBaseContainer,
		MetHdmDataBaseContainer metHdmDataBaseContainer,
        MetHdaDataBaseContainer metHdaDataBaseContainer,
        PopTvnDataBaseContainer popTvnDataBaseContainer,
        StkaDataBaseContainer   stkaDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (stkMMDataBaseContainer.Count == 0)
			stkMMDataBaseContainer.read();
		
		if (stkMPDataBaseContainer.Count == 0)
			stkMPDataBaseContainer.read();

		if (metHdrDataBaseContainer.Count == 0)
			metHdrDataBaseContainer.readByFilters("",splant,0);

		if (metHdmDataBaseContainer.Count == 0)
			metHdmDataBaseContainer.readByFilters("",splant,0);

        if (metHdaDataBaseContainer.Count == 0)
			metHdaDataBaseContainer.readByFilters("",splant,0);
                
        if (popTvnDataBaseContainer.Count == 0)
			popTvnDataBaseContainer.read();

        if (stkaDataBaseContainer.Count == 0)
            stkaDataBaseContainer.readByFilters("",splant,Constants.STATUS_ACTIVE, 0);
                       
        // restore connction to sql server
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBaseContainer         prodFmInfoDataBaseContainer             = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		ProdFmActHDataBaseContainer         prodFmActHDataBaseContainer             = new ProdFmActHDataBaseContainer(dataBaseAccess);
		ProdFmActSubDataBaseContainer       prodFmActSubDataBaseContainer           = new ProdFmActSubDataBaseContainer(dataBaseAccess);        
		BomSumDataBaseContainer             bomSumDataBaseContainer                 = new BomSumDataBaseContainer(dataBaseAccess);
		ProdFmActPlanDataBaseContainer      prodFmActPlanDataBaseContainerFromAs400 = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		SuppProductCrossDataBaseContainer   suppProductCrossDataBaseContainer       = new SuppProductCrossDataBaseContainer(dataBaseAccess);
        string                              splantAux="";
        Hashtable                           hashtProdfmactByPart = new Hashtable();
        Hashtable                           hashtBomSumByPart = new Hashtable();

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
            prodFmInfoDataBase.setPFS_DaysOnHand((decimal)1.2);
            prodFmInfoDataBase.setPFS_ObectivesAutomaticCalc(Constants.STRING_YES);
            prodFmInfoDataBase.setPFS_DemandLowQtySplit(1);

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
            bool    bfoundPartOnMetHdr=false;
			for(IEnumerator en2 = metHdrDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
				MetHdrDataBase metHdrDataBase = (MetHdrDataBase) en2.Current;
				if (metHdrDataBase.getAOPART().Trim().Equals(stkMMDataBase.getAVPART().Trim())){                         
                    bfoundPartOnMetHdr = true;
				    if (metHdrDataBase.getAOSEQ() > greater)
					    greater = metHdrDataBase.getAOSEQ();
				}
			}

            if (!string.IsNullOrEmpty(splant) && !bfoundPartOnMetHdr){ //AF 2019-09-26 if transfer for specific plant
                //if not found part, there is not MetHdr for that part, so we check for prior part already configurated
                ProdFmInfoDataBase prodFmInfoDataBaseAux = new ProdFmInfoDataBase(dataBaseAccess);
                prodFmInfoDataBaseAux.setPFS_ProdID(prodFmInfoDataBase.getPFS_ProdID());
                if (prodFmInfoDataBaseAux.read())
                    greater = prodFmInfoDataBaseAux.getPFS_SeqLast();
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
            prodFmInfoDataBase.setPFS_DaysOnHand((decimal)1.2);
            prodFmInfoDataBase.setPFS_ObectivesAutomaticCalc(Constants.STRING_YES);

			prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
		}

		for(IEnumerator en = metHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			MetHdrDataBase metHdrDataBase = (MetHdrDataBase) en.Current;
			
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.setPAH_ProdID(metHdrDataBase.getAOPART());
			prodFmActHDataBase.setPAH_Seq(decimal.ToInt32(metHdrDataBase.getAOSEQ()));
			prodFmActHDataBaseContainer.Add(prodFmActHDataBase, prodFmActHDataBase.getPAH_ProdID().Trim());

            if (!hashtProdfmactByPart.Contains(prodFmActHDataBase.getPAH_ProdID()))
                hashtProdfmactByPart.Add(prodFmActHDataBase.getPAH_ProdID(), prodFmActHDataBase.getPAH_ProdID());

			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.setPC_ProdID(metHdrDataBase.getAOPART());
			prodFmActSubDataBase.setPC_Seq(decimal.ToInt32(metHdrDataBase.getAOSEQ()));
            prodFmActSubDataBase.setPC_ActID("");
			prodFmActSubDataBase.setPC_Cfg(metHdrDataBase.getAORESC());
			prodFmActSubDataBase.setPC_RunStd(metHdrDataBase.getAORUNS());
			prodFmActSubDataBase.setPC_CycleTm(metHdrDataBase.getAOCTME());
			prodFmActSubDataBase.setPC_CavityNum(metHdrDataBase.getAOMULT());
			prodFmActSubDataBase.setPC_CavAvail(metHdrDataBase.getAOMULT());
			prodFmActSubDataBase.setPC_Dept(metHdrDataBase.getAODEPT());
			prodFmActSubDataBase.setPC_RepPoint(metHdrDataBase.getAOREPP());
			prodFmActSubDataBase.setPC_QtyMen(decimal.ToInt32(metHdrDataBase.getAO_MEN()));
			prodFmActSubDataBase.setPC_QtyMachines(decimal.ToInt32(metHdrDataBase.getAO_MCH()));
            prodFmActSubDataBase.setPC_RoutingType(Routing.ROUTING_TYPE_MAIN);
            prodFmActSubDataBase.setPC_ScrapPercent(1);
            prodFmActSubDataBase.setPC_Efficiency(1);                    

        splantAux = metHdrDataBase.getAOPLNT(); //AF 2019-09-26 plant already exists on metHdr , is part from key too
            if (string.IsNullOrEmpty(splantAux)){
			    PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			    pltDeptDataBase.setDE_Dept(metHdrDataBase.getAODEPT());
			    pltDeptDataBase.readByDept();
                splantAux=pltDeptDataBase.getDE_Plt();
            }
			prodFmActSubDataBase.setPC_Plt(splantAux);
			prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);            
		}

        //AF 2019-07-01 alternative machine, methda
        for(IEnumerator en = metHdaDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			MetHdaDataBase metHdaDataBase = (MetHdaDataBase) en.Current;
						
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.setPC_ProdID(metHdaDataBase.getARPART());
			prodFmActSubDataBase.setPC_Seq(decimal.ToInt32(metHdaDataBase.getARSEQ()));
            prodFmActSubDataBase.setPC_ActID("");
			prodFmActSubDataBase.setPC_Cfg(metHdaDataBase.getARRESC());
			prodFmActSubDataBase.setPC_RunStd(metHdaDataBase.getARRUNS());
			prodFmActSubDataBase.setPC_CycleTm(metHdaDataBase.getARCTME());
			prodFmActSubDataBase.setPC_CavityNum(metHdaDataBase.getARMULT());
			prodFmActSubDataBase.setPC_CavAvail(metHdaDataBase.getARMULT());
			prodFmActSubDataBase.setPC_Dept(metHdaDataBase.getARDEPT());
			prodFmActSubDataBase.setPC_RepPoint(metHdaDataBase.getARREPP());
			prodFmActSubDataBase.setPC_QtyMen(decimal.ToInt32(metHdaDataBase.getARMEN()));
			prodFmActSubDataBase.setPC_QtyMachines(decimal.ToInt32(metHdaDataBase.getARMCH()));
            prodFmActSubDataBase.setPC_RoutingType(Routing.ROUTING_TYPE_ALTERNATIVE);
            prodFmActSubDataBase.setPC_ScrapPercent(1);
            prodFmActSubDataBase.setPC_Efficiency(1);      
            
            splantAux = metHdaDataBase.getARPLNT(); //AF 2019-09-26 plant already exists on metHda , is part from key too
            if (string.IsNullOrEmpty(splantAux)){
                PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			    pltDeptDataBase.setDE_Dept(metHdaDataBase.getARDEPT());
			    pltDeptDataBase.readByDept();
                splant = pltDeptDataBase.getDE_Plt();
            }
			prodFmActSubDataBase.setPC_Plt(splantAux);
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

            if (!hashtBomSumByPart.Contains(metHdmDataBase.getAQPART()))
                hashtBomSumByPart.Add(metHdmDataBase.getAQPART(),metHdmDataBase.getAQPART());

			if (metHdmDataBase.getAQQTYM() > 0){
				BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
				bomSumDataBase.setBMS_ProdID(metHdmDataBase.getAQPART());
				bomSumDataBase.setBMS_Seq(decimal.ToInt32(metHdmDataBase.getAQSEQ()));
				bomSumDataBase.setBMS_MatOrdNum(decimal.ToInt32(metHdmDataBase.getAQLIN()));
				bomSumDataBase.setBMS_MatID(metHdmDataBase.getAQMTLP());
				
				//for now seq= 0 for material
				bomSumDataBase.setBMS_MatSeq(0);//change for alfield was wrong using same seq as parent seq 30/08/2004bomSumDataBase.getBMS_Seq()
				
				bomSumDataBase.setBMS_PrQty(metHdmDataBase.getAQQPPC());
				bomSumDataBase.setBMS_Uom(metHdmDataBase.getAQUNIT());
				bomSumDataBase.setBMS_QtyPerInv(metHdmDataBase.getAQQTYM());
				// cambiado para alfield 3/8/2004
				//bomSumDataBase.setBMS_MatQty(metHdmDataBase.getAQQTYM() / metHdmDataBase.getAQQPPC());
				bomSumDataBase.setBMS_MatQty(metHdmDataBase.getAQQPPC() / metHdmDataBase.getAQQTYM());
				bomSumDataBaseContainer.Add(bomSumDataBase);
			}
		}

        //AF 2018/10/19 add Finished/Main MAterial from stka    
        Hashtable hashStka = new Hashtable();
        for(int index = 0; index < stkaDataBaseContainer.Count;index++){
            StkaDataBase stkaDataBase = (StkaDataBase)stkaDataBaseContainer[index];
            if (!hashStka.ContainsKey(stkaDataBase.getV6PART().ToUpper().Trim()))
                hashStka.Add(stkaDataBase.getV6PART(),stkaDataBase);            
        }          
        //System.Windows.Forms.MessageBox.Show("Total Hash:" + hashStka.Count + "Total Part:" + prodFmInfoDataBaseContainer.Count);          
        for(int index = 0; index < prodFmInfoDataBaseContainer.Count;index++){        
            ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)prodFmInfoDataBaseContainer[index];
            string spartFind = prodFmInfoDataBase.getPFS_ProdID().ToUpper().Trim();
            if (hashStka.ContainsKey(spartFind)){
                StkaDataBase stkaDataBase = (StkaDataBase)hashStka[spartFind];                                
                prodFmInfoDataBase.setPFS_Finished(stkaDataBase.getV6SELP());
                prodFmInfoDataBase.setPFS_MainMaterial(stkaDataBase.getV6CMTL());
                prodFmInfoDataBase.setPFS_StdPackSize(stkaDataBase.getV6PACK());
			    prodFmInfoDataBase.setPFS_StdPackUnit(stkaDataBase.getV6PACU());

                prodFmInfoDataBase.setPFS_Plant(stkaDataBase.getV6PLNT());
                prodFmInfoDataBase.setPFS_OptimRunPurchSize(stkaDataBase.getV6OPTR());
                prodFmInfoDataBase.setPFS_ProdMultiplier(stkaDataBase.getV6MULTP());
                prodFmInfoDataBase.setPFS_MinRunPurchQty(stkaDataBase.getV6MINR());
                prodFmInfoDataBase.setPFS_MatlPrepLdTime(Convert.ToInt32(stkaDataBase.getV6PRPT()));
                prodFmInfoDataBase.setPFS_PallPackSize(stkaDataBase.getV6MPCK());
                prodFmInfoDataBase.setPFS_PalletPackUnit(stkaDataBase.getV6MPKU());
                prodFmInfoDataBase.setPFS_MinQty(stkaDataBase.getV6MINQ());
                prodFmInfoDataBase.setPFS_MaxQty(stkaDataBase.getV6MAXQ());
                prodFmInfoDataBase.setPFS_VirtKanDemProf(stkaDataBase.getV6FUT25());
                prodFmInfoDataBase.setPFS_VirtKanManDem(stkaDataBase.getV6FUT35());
                //prodFmInfoDataBase.setPFS_Level(stkaDataBase.getV6LVL()); not for now, we have utility to Recalc Level
        /*
                        System.Windows.Forms.MessageBox.Show("Part:" + prodFmInfoDataBase.getPFS_ProdID() + "\n"+
                                                            "Finished:" + prodFmInfoDataBase.getPFS_Finished() + "\n"+
                                                            "MainMaterial:" + prodFmInfoDataBase.getPFS_MainMaterial() );*/
            }
        }
		
		suppProductCrossDataBaseContainer.truncate();      
        //can not delete    prodFmActSub because of Autonumeric, we could louse routing configurated
        //bomSumDataBaseContainer.truncate();   not delete AF 2019-09-26 could delete info from other plant, so we update/write

        if (string.IsNullOrEmpty(splant)){ 
            prodFmActHDataBaseContainer.truncate();	                     
            prodFmActPlanDataBaseContainerFromAs400.truncate();
		    bomSumDataBaseContainer.truncate();
        }else
            deleteProdFmActBomSumOldInfo(hashtProdfmactByPart,hashtBomSumByPart,splant);
                
        handleMaintenancePart(prodFmInfoDataBaseContainer);
        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        handleMaintenanceProdFmActH(prodFmActHDataBaseContainer);
        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        handleMaintenanceRoutings(prodFmActSubDataBaseContainer,splant);
        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        handleMaintenanceBomSum(bomSumDataBaseContainer);
        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        suppProductCrossDataBaseContainer.write();
        handleProdFmActPlan(prodFmActPlanDataBaseContainerFromAs400, splant);        

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

private
void deleteProdFmActBomSumOldInfo(Hashtable hashtProdfmactByPart, Hashtable hashtBomSumByPart,string splant){        
    ProdFmActHDataBaseContainer     prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);
    ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
    ProdFmActPlanDataBaseContainer  prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
    BomSumDataBaseContainer         bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);

    
    prodFmActHDataBaseContainer.deleteByPartList(hashtProdfmactByPart);
    prodFmActPlanDataBaseContainer.deleteByPartList(hashtProdfmactByPart);                    
    //prodFmActSubDataBaseContainer.deleteByPartList(spart,splant);  can not delete because we loose autonumeric
    bomSumDataBaseContainer.deleteByPartList(hashtBomSumByPart);       
}

private
void handleMaintenancePart(ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer){
    foreach (ProdFmInfoDataBase prodFmInfoDataBase in prodFmInfoDataBaseContainer){
        if (prodFmInfoDataBase.exists())
            prodFmInfoDataBase.updateShort();
        else
            prodFmInfoDataBase.write();
    }
}

private
void handleMaintenanceBomSum(BomSumDataBaseContainer bomSumDataBaseContainer){
    foreach (BomSumDataBase bomSumDataBase in bomSumDataBaseContainer){                
        if (bomSumDataBase.exists())
            bomSumDataBase.update();
        else
            bomSumDataBase.write();
    }
}

private
void handleMaintenanceProdFmActH(ProdFmActHDataBaseContainer prodFmActHDataBaseContainer){
    foreach (ProdFmActHDataBase prodFmActHDataBase in prodFmActHDataBaseContainer){		    
        if (!prodFmActHDataBase.exists())
            prodFmActHDataBase.write();
    }
}

private
void handleMaintenanceRoutings(ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,string splant){
    //we can not delete records which already exists , because we loose routings
    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainerOld = new ProdFmActSubDataBaseContainer(dataBaseAccess);
    prodFmActSubDataBaseContainerOld.readByFilters("",splant,"",-1,"","",false,0);//we read current routings
    foreach (ProdFmActSubDataBase prodFmActSubDataBase in prodFmActSubDataBaseContainer){            
        if (prodFmActSubDataBase.exists())
            prodFmActSubDataBase.updateShort();
        else
            prodFmActSubDataBase.write();
        prodFmActSubDataBaseContainerOld.Remove(prodFmActSubDataBase); //remove because exists, Equals functions was overrided
    }		                 
    foreach (ProdFmActSubDataBase prodFmActSubDataBase in prodFmActSubDataBaseContainerOld){//remove records not used any more        
        ProdFmactSubLabToolDataBaseContainer prodFmactSubLabToolDataBaseContainer = new ProdFmactSubLabToolDataBaseContainer(dataBaseAccess);
        prodFmactSubLabToolDataBaseContainer.deleteByHdr(prodFmActSubDataBase.getPC_Id());   	
        prodFmActSubDataBase.deleteById();
    }

    //update WeeklyCapacity if value not filled yet
    PltDeptMachDefDataBase pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
    pltDeptMachDefDataBase.updateWeeklyCapacity();

    createDefaultsRoutingLabourInt();
    prodFmActSubDataBaseContainer.updateOptRunQty();
}

private
void handleProdFmActPlan(ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainerFromAs400,string splant){

    foreach(ProdFmActPlanDataBase prodFmActPlanDataBase in prodFmActPlanDataBaseContainerFromAs400){
        if (prodFmActPlanDataBase.exists())
            prodFmActPlanDataBase.update();
        else
            prodFmActPlanDataBase.write();
                
    }        
/*
// step 1 : delete old records
	ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainerFromNujit = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
	prodFmActPlanDataBaseContainerFromNujit.read();
    if (string.IsNullOrEmpty(splant)) { //AF 2019-09-26 can not delete all records if for specific plant
		for(int index = 0; index < prodFmActPlanDataBaseContainerFromNujit.Count; index++){
			ProdFmActPlanDataBase fromNujit = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromNujit[index];

			if (prodFmActPlanDataBaseContainerFromAs400.getFirstElementPosition(fromNujit.getKey()) == -1){ // not exists in As400
				fromNujit.delete();
			}
		}
    }

// step 2 : add new records
	for(int index = 0; index < prodFmActPlanDataBaseContainerFromAs400.Count; index++){
		ProdFmActPlanDataBase fromAs400 = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainerFromAs400[index];

		if (prodFmActPlanDataBaseContainerFromNujit.getFirstElementPosition(fromAs400.getKey()) == -1){ // not exists in Nujit
            if (!fromAs400.exists()) //AF 201//09/18 added exists because getting duplicate error
                fromAs400.write();
            else
                fromAs400.update();
		}
	}
*/
}

public
int generateCMSItems(string splant,bool bstoreTemp){
	try{
		StkMMDataBaseContainer stkMMDataBaseContainer = new StkMMDataBaseContainer(dataBaseAccess);
		StkMPDataBaseContainer stkMPDataBaseContainer = new StkMPDataBaseContainer(dataBaseAccess);
		MetHdrDataBaseContainer metHdrDataBaseContainer = new MetHdrDataBaseContainer(dataBaseAccess);
		MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
        MetHdaDataBaseContainer metHdaDataBaseContainer = new MetHdaDataBaseContainer(dataBaseAccess);
		PopTvnDataBaseContainer popTvnDataBaseContainer = new PopTvnDataBaseContainer(dataBaseAccess);
        StkaDataBaseContainer stkaDataBaseContainer = new StkaDataBaseContainer(dataBaseAccess);
        
        if (bstoreTemp)
            cms400ToCmsTempItems(   splant,stkMMDataBaseContainer, stkMPDataBaseContainer,
                                    metHdrDataBaseContainer, metHdmDataBaseContainer, metHdaDataBaseContainer,
                                    popTvnDataBaseContainer, 
                                    stkaDataBaseContainer);
        else
            loadCms400Items(splant,
                            stkMMDataBaseContainer,stkMPDataBaseContainer,
                            metHdrDataBaseContainer,metHdmDataBaseContainer, metHdaDataBaseContainer,
                            popTvnDataBaseContainer, stkaDataBaseContainer);

        //System.Windows.Forms.MessageBox.Show("Stored on temp");

		return cmsTempToNujitItems( splant,stkMMDataBaseContainer, stkMPDataBaseContainer, 
			                        metHdrDataBaseContainer, metHdmDataBaseContainer, metHdaDataBaseContainer,
                                    popTvnDataBaseContainer,
                                    stkaDataBaseContainer);
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

		//pltDeptDataBaseContainer.truncate(); can not truncate any more, because we could loose DftLabTaskId
        Hashtable   hashDepts = loadDeptsHash();
        loadRoutingLabToolHash();
        string      skey = "";
        foreach (PltDeptDataBase pltDeptDataBase in pltDeptDataBaseContainer){//AF 2017-11-09 foreach/exists added because of duplicate record issue found
            skey = getDeptsHashKey(pltDeptDataBase);
            if (hashDepts.Contains(skey)){
                PltDeptDataBase pltDeptDataBaseAux = (PltDeptDataBase)hashDepts[skey];
                pltDeptDataBase.setDE_DftLabTaskId(pltDeptDataBaseAux.getDE_DftLabTaskId());
                pltDeptDataBase.setDE_NonScheduledDT(pltDeptDataBaseAux.getDE_NonScheduledDT());
                pltDeptDataBase.update();

                hashDepts.Remove(skey);
            }else
                pltDeptDataBase.write();            
        }

        //delete old plants not used
        foreach(DictionaryEntry dictionaryEntry in hashDepts){
            ((PltDeptDataBase)dictionaryEntry.Value).delete();
        }        

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
        foreach(PltDataBase pltDataBase in pltDataBaseContainer){
            if (!pltDataBase.exists())//AF 2017-11-09 foreach/exists added because of duplicate record issue found
                pltDataBase.write();
            else
                pltDataBase.update();
        }
		
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
                pltDeptMachDataBase.setPDM_DirectHoursToShifts((decimal)7.25); //7.25 by default
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
		//pltDeptMachDataBaseContainer.truncate(); //AF 2019-05-15  can not delete because we loose autonumeric ID		        
		// write data
        handleMaintenanceMachine(pltDeptMachDataBaseContainer);        
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

private
void handleMaintenanceMachine(PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer){    
    PltDeptMachDefDataBase  pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
    PltDeptMachDataBase     pltDeptMachDataBaseOld = new PltDeptMachDataBase(dataBaseAccess);

    foreach (PltDeptMachDataBase pltDeptMachDataBase in pltDeptMachDataBaseContainer){ //AF 2019-05-15 because we added autonumeric
        
        pltDeptMachDataBaseOld.setPDM_Plt(pltDeptMachDataBase.getPDM_Plt());
        pltDeptMachDataBaseOld.setPDM_Dept(pltDeptMachDataBase.getPDM_Dept());
        pltDeptMachDataBaseOld.setPDM_Mach(pltDeptMachDataBase.getPDM_Mach());

        if (pltDeptMachDataBaseOld.read()) { //check if machine already exists
            pltDeptMachDataBase.setPDM_ID(pltDeptMachDataBaseOld.getPDM_ID()); //load old autonumeric id
            pltDeptMachDataBase.update();
        }else
            pltDeptMachDataBase.write();
        
        pltDeptMachDefDataBase.setMachId(pltDeptMachDataBase.getPDM_ID());
        if (!pltDeptMachDefDataBase.read()){            
            pltDeptMachDefDataBase = createDefaultPltDeptMachDef(pltDeptMachDataBase.getPDM_ID());
            pltDeptMachDefDataBase.write();
        }
    }    
    pltDeptMachDefDataBase.updateWeeklyCapacity();//update WeeklyCapacity if value not filled yet
}

private
PltDeptMachDefDataBase createDefaultPltDeptMachDef(int id){
    PltDeptMachDefDataBase pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);

    pltDeptMachDefDataBase.setMachId(id);
    pltDeptMachDefDataBase.setPlanRunHrs(1);
    pltDeptMachDefDataBase.setHrsPerShift((decimal)7.25); 
    pltDeptMachDefDataBase.setPlanDownHrs(3);
    pltDeptMachDefDataBase.setPlanChanOvHrs(4);
    pltDeptMachDefDataBase.setStdShiftPerWeek(5*3);
    pltDeptMachDefDataBase.setUnitChanOverTime(6);
    pltDeptMachDefDataBase.setDirectHoursToShifts((decimal)7.25);
    pltDeptMachDefDataBase.setOee(3);
    pltDeptMachDefDataBase.setPerfOa(4);
    pltDeptMachDefDataBase.setScrapRate(2);
    pltDeptMachDefDataBase.setNetPressRate(1);
    pltDeptMachDefDataBase.setWeeklyCapacity(0);

    return pltDeptMachDefDataBase;
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
        foreach(PltInvLocDataBase pltInvLocDataBase in pltInvLocDataBaseContainer){
            if (!pltInvLocDataBase.exists())
		        pltInvLocDataBase.write();
            else
                pltInvLocDataBase.update();
        }
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
            custVendDataBase.setCV_TPartner(custDataBase.getBVTRDP());
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
            delForHdrDataBase.setDH_CumQty(rrlhDataBase.getOZYTDC());
            delForHdrDataBase.setDH_CustCumRequired(rrlhDataBase.getOZOEMC());
            delForHdrDataBase.setDH_CustCumShipped(rrlhDataBase.getOZOEMS());
            delForHdrDataBase.setDH_FabCumQty(rrlhDataBase.getOZFABC());            
            delForHdrDataBase.setDH_MatCumQty(rrlhDataBase.getOZMTLC());            
            delForHdrDataBase.setDH_LastRecQty(rrlhDataBase.getOZRCVQ());
            delForHdrDataBase.setDH_LastRecDate(rrlhDataBase.getOZLDAT());
            delForHdrDataBase.setDH_LastRecShipment(rrlhDataBase.getOZLSHI());
            delForHdrDataBase.setDH_CumDisc(rrlhDataBase.getOZCUMD());
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
            delForDtlDataBase.setDD_DelforQtyCum(rrldDataBase.getPLQCUM());
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
	
        if (Configuration.DataTransferMaxRecords > 0)
            loadCsptBySteps(csptDataBaseContainer,Configuration.DataTransferMaxRecords);
        else
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

System.Windows.Forms.MessageBox.Show("On cmsTempToNujitCustPart:" + csptDataBaseContainer.Count);

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
            
            //if (!custPartDataBase.exists())
            custPartDataBaseContainer.Add(custPartDataBase);
		}
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        foreach (CustPartDataBase custPartDataBase in custPartDataBaseContainer) { 
            if (custPartDataBase.exists())
                custPartDataBase.updateShort();
            else
		        custPartDataBaseContainer.write();
        }

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
        foreach (ProdFmActCostDataBase prodFmActCostDataBase in prodFmActCostDataBaseContainer){//AF 2017-11-09 foreach/exists added because of duplicate record issue found
            if (!prodFmActCostDataBase.exists())
		        prodFmActCostDataBase.write();
            else
                prodFmActCostDataBase.update();
        }

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
        foreach (ProdFmActCostDataBase prodFmActCostDataBase in prodFmActCostDataBaseContainer){//AF 2017-11-09 foreach/exists added because of duplicate record issue found
            if (!prodFmActCostDataBase.exists())
                prodFmActCostDataBase.write();
            else
                prodFmActCostDataBase.update();
        }

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
        foreach (RprdDataBase rprdDataBase in rprdDataBaseContainer){
            if (!rprdDataBase.exists())
		        rprdDataBase.write();
            else
                rprdDataBase.update();
        }

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
        foreach (RprrDataBase rprrDataBase in rprrDataBaseContainer){
            if (!rprrDataBase.exists())
                rprrDataBase.write();
            else
                rprrDataBase.update();
        }

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
        foreach (RprsDataBase rprsDataBase in rprsDataBaseContainer){
            if (!rprsDataBase.exists())
                rprsDataBase.write();
            else
                rprsDataBase.update();
        }

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
        foreach (RPRHDataBase rprhDataBase in rprhDataBaseContainer){
            if (!rprhDataBase.exists())
                rprhDataBase.write();
            else
                rprhDataBase.update();
        }

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
        foreach (RPRPDataBase rprpDataBase in rprpDataBaseContainer){
            if (!rprpDataBase.exists())
		        rprpDataBase.write();
            else
                rprpDataBase.update();
        }

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
		
		//pdToolDataBaseContainer.truncate(); AF 2019-05-16 not delete because we loose autonumeric ID
        foreach (PdToolDataBase pdToolDataBase in pdToolDataBaseContainer){
            if (pdToolDataBase.exists())
                pdToolDataBase.update();
            else
                pdToolDataBase.write();
        }

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
				
        //AF 2019-05-16 update and write so we do not loose Toold ID
        foreach (PdToolDataBase pdToolDataBase in pdToolDataBaseContainer){
            if (pdToolDataBase.exists())
                pdToolDataBase.update();
            else
                pdToolDataBase.write();
        }

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

/*-------------------------------------------Seri --------------------------------------------*/
public 
int generateCMSSeri(){
	try{
		SeriDataBaseContainer seriDataBaseContainer = new SeriDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempSeri(seriDataBaseContainer);
		cmsTempToNujitSeri(seriDataBaseContainer);
		
		return seriDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempSeri(){
	try{
		SeriDataBaseContainer seriDataBaseContainer = new SeriDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempSeri(seriDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempSeri(SeriDataBaseContainer seriDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        seriDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		seriDataBaseContainer.truncate();		
        foreach(SeriDataBase seriDataBase in seriDataBaseContainer){
		    if (!seriDataBase.exists())
                seriDataBase.write();
        }

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return seriDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitSeri(){
	try{
		SeriDataBaseContainer seriDataBaseContainer = new SeriDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitSeri(seriDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//Icstp
private
int cmsTempToNujitSeri(SeriDataBaseContainer seriDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (seriDataBaseContainer.Count == 0)
			seriDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        seriDataBaseContainer.truncate();      
        foreach(SeriDataBase seriDataBase in seriDataBaseContainer){
		    if (!seriDataBase.exists())
                seriDataBase.write();
        }                

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return seriDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/*-------------------------------------------MainMat --------------------------------------------*/
public 
int generateCMSMainMat(){
	try{
		MainMatDataBaseContainer mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);
		
		cms400ToCmsTempMainMat(mainMatDataBaseContainer);
		cmsTempToNujitMainMat(mainMatDataBaseContainer);
		
		return mainMatDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempMainMat(){
	try{
		MainMatDataBaseContainer mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);
		
		return cms400ToCmsTempMainMat(mainMatDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cms400ToCmsTempMainMat(MainMatDataBaseContainer mainMatDataBaseContainer){
	try{
		// change connection to AS 400
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        mainMatDataBaseContainer.read();

		// change connection to Sql Server
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// clean database
		mainMatDataBaseContainer.truncate();
		mainMatDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		// restore connection to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return mainMatDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitMainMat(){
	try{
		MainMatDataBaseContainer mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);

		return cmsTempToNujitMainMat(mainMatDataBaseContainer);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//Icstp
private
int cmsTempToNujitMainMat(MainMatDataBaseContainer mainMatDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (mainMatDataBaseContainer.Count == 0)
			mainMatDataBaseContainer.read();
		
		// restore connction to sql server
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        mainMatDataBaseContainer.truncate();
        mainMatDataBaseContainer.write();                

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		return mainMatDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
MainMat createMainMat(){
	return new MainMat();
}

public
MainMatContainer createMainMatContainer(){
	return new MainMatContainer();
}

public
bool existsMainMat(string pART, int dTL){
	try{
		MainMatDataBase mainMatDataBase = new MainMatDataBase(dataBaseAccess);

		mainMatDataBase.setPART(pART);
		mainMatDataBase.setDTL(dTL);

		return mainMatDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
MainMat readMainMat(string pART){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        MainMat                     mainMat = null;
        MainMatDataBaseContainer    mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);
        mainMatDataBaseContainer.readByHeader(pART);

        if (mainMatDataBaseContainer.Count > 0)
            mainMat = new MainMat();
        
        foreach(MainMatDataBase mainMatDataBase in mainMatDataBaseContainer){
            MainMat mainMatchild = this.objectDataBaseToObject(mainMatDataBase);
            
            mainMat.PART = mainMatchild.PART;
            mainMat.MainMatContainer.Add(mainMatchild);
        }

		return mainMat;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
MainMatContainer readMainMatByFilters(string pART,string smainPart,bool bonlyHeaders,int rows){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

        MainMatContainer mainMatContainer = new MainMatContainer();

        MainMatDataBaseContainer mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);
        mainMatDataBaseContainer.readByFilters(pART,smainPart,rows);
	
        for (int i=0; i < mainMatDataBaseContainer.Count;i++){
            MainMat mainMat = this.objectDataBaseToObject((MainMatDataBase)mainMatDataBaseContainer[i]);
            mainMatContainer.Add(mainMat);
        }

		return mainMatContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void updateMainMat(MainMat mainMat){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        deleteMainMatChilds(mainMat.PART);
        writeMainMatChilds(mainMat);
        
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void writeMainMat(MainMat mainMat){	
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

		writeMainMatChilds(mainMat);

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void writeMainMatChilds(MainMat mainMat){
    mainMat.fillRedundances();

    for (int i = 0; i < mainMat.MainMatContainer.Count; i++){
        MainMat         mainMatChild = mainMat.MainMatContainer[i];
        MainMatDataBase mainMatDataBase = objectToObjectDataBase(mainMatChild);

        try{
            mainMatDataBase.write();
        }catch (Exception ex){
            if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		        throw new NujitException(ex.Message, ex);
        }                
    }
}

public 
void deleteMainMatChilds(string spart){
    MainMatDataBaseContainer mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);
   
    try{
         mainMatDataBaseContainer.deleteByHeader(spart);
    }catch (Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		    throw new NujitException(ex.Message, ex);
    }  
}

public
void deleteMainMat(string pART, int dTL){
	 try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

		MainMatDataBase mainMatDataBase = new MainMatDataBase(dataBaseAccess);
        mainMatDataBase.setPART(pART);
        mainMatDataBase.setDTL(dTL);
        mainMatDataBase.delete();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
MainMat objectDataBaseToObject(MainMatDataBase mainMatDataBase){
	MainMat mainMat = new MainMat();

	mainMat.PART=mainMatDataBase.getPART();
	mainMat.DTL=mainMatDataBase.getDTL();
	mainMat.MAINPART=mainMatDataBase.getMAINPART();

	return mainMat;
}

private
MainMatDataBase objectToObjectDataBase(MainMat mainMat){
	MainMatDataBase mainMatDataBase = new MainMatDataBase(dataBaseAccess);
	mainMatDataBase.setPART(mainMat.PART);
	mainMatDataBase.setDTL(mainMat.DTL);
	mainMatDataBase.setMAINPART(mainMat.MAINPART);

	return mainMatDataBase;
}

public
MainMat cloneMainMat(MainMat mainMat){
	MainMat mainMatClone = new MainMat();

	mainMatClone.PART=mainMat.PART;
	mainMatClone.DTL=mainMat.DTL;
	mainMatClone.MAINPART=mainMat.MAINPART;

	return mainMatClone;
}
/*********************************************************************/

public
string[][] getReport1268OnCVSFormat(){
    string[][] items = null;

    try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);      

        MainMatDataBaseContainer mainMatDataBaseContainer = new MainMatDataBaseContainer(dataBaseAccess);
        items = mainMatDataBaseContainer.getReport1268();

        return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}

    return items;
}

private
MetHdaDataBase mtom(MetHdrDataBase metHdrDataBase){
    MetHdaDataBase m = new MetHdaDataBase(dataBaseAccess);
    
    m.setARPART(metHdrDataBase.getAOPART());
    m.setARSEQ(decimal.ToInt32(metHdrDataBase.getAOSEQ()));

    m.setARRESC(metHdrDataBase.getAORESC());
    m.setARRUNS(metHdrDataBase.getAORUNS());

    m.setARCTME(metHdrDataBase.getAOCTME());
    m.setARMULT(metHdrDataBase.getAOMULT());
    m.setARMULT(metHdrDataBase.getAOMULT());
    m.setARDEPT(metHdrDataBase.getAODEPT());
    m.setARREPP(metHdrDataBase.getAOREPP());
    m.setARMEN(decimal.ToInt32(metHdrDataBase.getAO_MEN()));
    m.setARMCH(decimal.ToInt32(metHdrDataBase.getAO_MCH()));

    PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
    pltDeptDataBase.setDE_Dept(m.getARDEPT());
    pltDeptDataBase.readByDept();

    return m;
}

private
void loadStkMMBySteps(StkMMDataBaseContainer stkMMDataBaseContainer,string splant,int irows){
    string  savpart="";    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free

        StkMMDataBaseContainer stkMMDataBaseContainerAux = new StkMMDataBaseContainer(dataBaseAccess);            
        stkMMDataBaseContainerAux.readByFilters(savpart,splant,irows);
       
        if (stkMMDataBaseContainerAux.Count > 0){
            savpart= ((StkMMDataBase)stkMMDataBaseContainerAux[stkMMDataBaseContainerAux.Count-1]).getAVPART();     
            stkMMDataBaseContainer.AddRange(stkMMDataBaseContainerAux);
       }
       if (stkMMDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private
void loadStkMPBySteps(StkMPDataBaseContainer stkMPDataBaseContainer,string splant,int irows){
    string  sawpart="";    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free

        StkMPDataBaseContainer stkMPDataBaseContainerAux = new StkMPDataBaseContainer(dataBaseAccess);            
        stkMPDataBaseContainerAux.readByFilters(sawpart,splant,irows);
       
        if (stkMPDataBaseContainerAux.Count > 0){
            sawpart= ((StkMPDataBase)stkMPDataBaseContainerAux[stkMPDataBaseContainerAux.Count-1]).getAWPART();     
            stkMPDataBaseContainer.AddRange(stkMPDataBaseContainerAux);
       }
       if (stkMPDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private      
void loadStkaBySteps(StkaDataBaseContainer stkaDataBaseContainer,string splant,string status, int irows){
    string  skey="";    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        StkaDataBaseContainer stkaDataBaseContainerAux = new StkaDataBaseContainer(dataBaseAccess);            
        stkaDataBaseContainerAux.readByFilters(skey,splant,status,irows);
       
        if (stkaDataBaseContainerAux.Count > 0){
            StkaDataBase stkaDataBase = (StkaDataBase)stkaDataBaseContainerAux[stkaDataBaseContainerAux.Count - 1];
            skey = stkaDataBase.getV6PLNT()+ stkaDataBase.getV6PART();     
            stkaDataBaseContainer.AddRange(stkaDataBaseContainerAux);
       }
       if (stkaDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private      
void loadStkbBySteps(StkbDataBaseContainer stkbDataBaseContainer, int irows){
    string  skey="";    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        StkbDataBaseContainer stkbDataBaseContainerAux = new StkbDataBaseContainer(dataBaseAccess);            
        stkbDataBaseContainerAux.readByFilters(skey, irows);
       
        if (stkbDataBaseContainerAux.Count > 0){
            StkbDataBase stkbDataBase = (StkbDataBase)stkbDataBaseContainerAux[stkbDataBaseContainerAux.Count - 1];            
            skey =  stkbDataBase.getBXPART()+ Constants.DEFAULT_SEP + stkbDataBase.getBXLOT() + Constants.DEFAULT_SEP +//BXPART,BXLOT,BXSTOK,BXUNIT
                    stkbDataBase.getBXSTOK()+ Constants.DEFAULT_SEP + stkbDataBase.getBXUNIT();
            stkbDataBaseContainer.AddRange(stkbDataBaseContainerAux);
       }
       if (stkbDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private      
void loadWipbBySteps(WipbDataBaseContainer wipbDataBaseContainer, int irows){
    string  skey="";    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        WipbDataBaseContainer wipbDataBaseContainerAux = new WipbDataBaseContainer(dataBaseAccess);            
        wipbDataBaseContainerAux.readByFilters(skey, irows);
       
        if (wipbDataBaseContainerAux.Count > 0){
            WipbDataBase wipbDataBase = (WipbDataBase)wipbDataBaseContainerAux[wipbDataBaseContainerAux.Count - 1];            
            string sVDSEQ = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(wipbDataBase.getVDSEQ()).ToString(),'0',10,false);		 
            skey =  wipbDataBase.getVDPART()+ Constants.DEFAULT_SEP + sVDSEQ                    + Constants.DEFAULT_SEP +//VDPART,VDSEQ#,VDLOT,VDSTOK
                    wipbDataBase.getVDLOT() + Constants.DEFAULT_SEP + wipbDataBase.getVDSTOK();
            wipbDataBaseContainer.AddRange(wipbDataBaseContainerAux);
       }
       if (wipbDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}
       
private
void loadMetHdrBySteps(MetHdrDataBaseContainer metHdrDataBaseContainer,string splant,int irows){
    string  skey="";
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        MetHdrDataBaseContainer metHdrDataBaseContainerAux = new MetHdrDataBaseContainer(dataBaseAccess);            
        metHdrDataBaseContainerAux.readByFilters(skey, splant,irows);
       
        if (metHdrDataBaseContainerAux.Count > 0){            
            MetHdrDataBase metHdrDataBase = (MetHdrDataBase)metHdrDataBaseContainerAux[metHdrDataBaseContainerAux.Count - 1];
            string sAOSEQ = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(metHdrDataBase.getAOSEQ()).ToString(),'0',10,false);
            string sAOLIN = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(metHdrDataBase.getAOLIN()).ToString(),'0',10,false);

            skey = metHdrDataBase.getAOTYPE()+ Constants.DEFAULT_SEP + metHdrDataBase.getAOPLNT()   + Constants.DEFAULT_SEP +  
                   metHdrDataBase.getAOPART()+ Constants.DEFAULT_SEP + sAOSEQ                       + Constants.DEFAULT_SEP +
                   sAOLIN;     
            metHdrDataBaseContainer.AddRange(metHdrDataBaseContainerAux);
        }
        if (metHdrDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private
void loadMetHdmBySteps(MetHdmDataBaseContainer metHdmDataBaseContainer,string splant,int irows){
    string  skey="";
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        MetHdmDataBaseContainer metHdmDataBaseContainerAux = new MetHdmDataBaseContainer(dataBaseAccess);            
        metHdmDataBaseContainerAux.readByFilters(skey,splant,irows);
       
        if (metHdmDataBaseContainerAux.Count > 0){            
            MetHdmDataBase metHdmDataBase = (MetHdmDataBase)metHdmDataBaseContainerAux[metHdmDataBaseContainerAux.Count - 1];
            string sAQSEQ = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(metHdmDataBase.getAQSEQ()).ToString(),'0',10,false);		 
            string sAQLIN = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(metHdmDataBase.getAQLIN()).ToString(),'0',10,false);		 

            skey = metHdmDataBase.getAQTYPE() + Constants.DEFAULT_SEP + metHdmDataBase.getAQPLNT()  + Constants.DEFAULT_SEP + 
                   metHdmDataBase.getAQPART() + Constants.DEFAULT_SEP + sAQSEQ                      + Constants.DEFAULT_SEP + 
                  sAQLIN;     
            metHdmDataBaseContainer.AddRange(metHdmDataBaseContainerAux);
        }
        if (metHdmDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private
void loadMetHdaBySteps(MetHdaDataBaseContainer metHdaDataBaseContainer,string splant,int irows){
    string  skey="";
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        MetHdaDataBaseContainer metHdaDataBaseContainerAux = new MetHdaDataBaseContainer(dataBaseAccess);            
        metHdaDataBaseContainerAux.readByFilters(skey,splant,irows);
       
        if (metHdaDataBaseContainerAux.Count > 0){            
            MetHdaDataBase metHdaDataBase = (MetHdaDataBase)metHdaDataBaseContainerAux[metHdaDataBaseContainerAux.Count - 1];
            string sARSEQ = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(metHdaDataBase.getARSEQ()).ToString(),'0',10,false);		 
            string sARLIN = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(metHdaDataBase.getARLIN()).ToString(),'0',10,false);		 

            skey = metHdaDataBase.getARTYPE()+ Constants.DEFAULT_SEP+ metHdaDataBase.getARPLNT()+ Constants.DEFAULT_SEP + 
                   metHdaDataBase.getARPART()+ Constants.DEFAULT_SEP+ sARSEQ                    + Constants.DEFAULT_SEP + 
                   sARLIN;     
            metHdaDataBaseContainer.AddRange(metHdaDataBaseContainerAux);
        }
        if (metHdaDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private
void loadPopTvnBySteps(PopTvnDataBaseContainer popTvnDataBaseContainer, int irows){
    string  skey="";
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        PopTvnDataBaseContainer popTvnDataBaseContainerAux = new PopTvnDataBaseContainer(dataBaseAccess);            
        popTvnDataBaseContainerAux.readByFilters(skey, irows);
       
        if (popTvnDataBaseContainerAux.Count > 0){            
            PopTvnDataBase popTvnDataBase = (PopTvnDataBase)popTvnDataBaseContainerAux[popTvnDataBaseContainerAux.Count - 1];
            //JRPT# , JRSEQ# , JRVPTS , JRVND# 
            string sJRSEQ = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(popTvnDataBase.getJRSEQ()).ToString(),'0',10,false);		 
            string sJRVPTS= Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(popTvnDataBase.getJRVPTS()).ToString(),'0',10,false);		 
            skey = popTvnDataBase.getJRPT() + Constants.DEFAULT_SEP + sJRSEQ + Constants.DEFAULT_SEP +
                   sJRVPTS                  + Constants.DEFAULT_SEP + popTvnDataBase.getJRVND();     
            popTvnDataBaseContainer.AddRange(popTvnDataBaseContainerAux);
        }
        if (popTvnDataBaseContainerAux.Count < irows)    
            bprocess =false;        
    }
}

private
void loadSschBySteps(SschDataBaseContainer sschDataBaseContainer, int irows){
    string  skey="";
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        SschDataBaseContainer sschDataBaseContainerAux = new SschDataBaseContainer(dataBaseAccess);            
        sschDataBaseContainerAux.readByFilters(skey, irows);
       
        if (sschDataBaseContainerAux.Count > 0){            
            SschDataBase sschDataBase = (SschDataBase)sschDataBaseContainerAux[sschDataBaseContainerAux.Count - 1];            
            //JYCODE,JYDATE,JYTIME,JYENTR
            string sJYTIME = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(sschDataBase.getJYTIME()).ToString(),'0',10,false);		 
            string sJYENTR = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(sschDataBase.getJYENTR()).ToString(),'0',10,false);		 
            skey = sschDataBase.getJYCODE() + Constants.DEFAULT_SEP + DateUtil.getDateRepresentation(sschDataBase.getJYDATE(),DateUtil.YYYYMMDD).Replace("/","-")  + Constants.DEFAULT_SEP +
                   sJYTIME                  + Constants.DEFAULT_SEP + sJYENTR;     
            sschDataBaseContainer.AddRange(sschDataBaseContainerAux);
        }
        if (sschDataBaseContainerAux.Count < irows)    
            bprocess =false;        
    }
}    
        
private      
void loadCsptBySteps(CsptDataBaseContainer csptDataBaseContainer, int irows){
    string  skey="";    
    bool    bprocess=true;    
            
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                
        CsptDataBaseContainer csptDataBaseContainerAux = new CsptDataBaseContainer(dataBaseAccess);                    
        csptDataBaseContainerAux.readByFilters(skey,irows);
       
        if (csptDataBaseContainerAux.Count > 0){
            CsptDataBase csptDataBase = (CsptDataBase)csptDataBaseContainerAux[csptDataBaseContainerAux.Count - 1];                        
            skey = csptDataBase.getRRPART() + csptDataBase.getRRCUST();//RRPART,RRCUST   
            csptDataBaseContainer.AddRange(csptDataBaseContainerAux);            
       }
       if (csptDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
    
}            

/*************************************** Employee **********************************************************************/
public 
int generateCMSEmployee(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
		TazmDataBaseContainer tazmDataBaseContainer = new TazmDataBaseContainer(dataBaseAccess);

		cms400ToCmsTempEmployee(tazmDataBaseContainer);
        cmsTempToNujitEmployee(tazmDataBaseContainer);
		
		return tazmDataBaseContainer.Count;
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
int cms400ToCmsTempEmployee(){
	try{
		TazmDataBaseContainer tazmDataBaseContainer = new TazmDataBaseContainer(dataBaseAccess);     
        return cms400ToCmsTempEmployee(tazmDataBaseContainer);

	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int cms400ToCmsTempEmployee(TazmDataBaseContainer tazmDataBaseContainer){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);		        
        tazmDataBaseContainer.read();
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		tazmDataBaseContainer.truncate();
		tazmDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		return tazmDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
int cmsTempToNujitEmployee(){
	try{
		TazmDataBaseContainer tazmDataBaseContainer = new TazmDataBaseContainer(dataBaseAccess);     
        return cmsTempToNujitEmployee(tazmDataBaseContainer);

	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
int cmsTempToNujitEmployee(TazmDataBaseContainer tazmDataBaseContainer){
	try{        

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        LbHistDataBaseContainer lbHistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);        
        Hashtable               hashDepts = new Hashtable();
        Hashtable               hashDates = new Hashtable();
        lbHistDataBaseContainer.getEmployeeLastDeptDate(out hashDepts,out hashDates);//get last depts and date worked by employee
   
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);
		if (tazmDataBaseContainer.Count == 0)
			tazmDataBaseContainer.read();

		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        string      sdept = "";
        DateTime    dateLastLab = DateUtil.MinValue;
        	
		for(IEnumerator en = tazmDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			TazmDataBase tazmDataBase = (TazmDataBase)en.Current;

            EmployeeDataBase employeeDataBase       = new EmployeeDataBase(dataBaseAccess); 
            EmployeeDataBase employeeDataBaseOld    = new EmployeeDataBase(dataBaseAccess);                                                   
            employeeDataBase.setEmpID(tazmDataBase.getZMEMPL());
            employeeDataBase.setFirstName(tazmDataBase.getZMFNME());
            employeeDataBase.setLastName(tazmDataBase.getZMLNME());
            employeeDataBase.setLoginName("");
            employeeDataBase.setPassword("");
            employeeDataBase.setStatusCode(tazmDataBase.getZMSTAT());
            
            employeeDataBase.setDeptCode("");
            employeeDataBase.setPostion(tazmDataBase.getZMETYP());
            employeeDataBase.setCompanyExt("");
            employeeDataBase.setHomePhone(tazmDataBase.getZMHPHO());
            employeeDataBase.setCellPhone("");
            employeeDataBase.setEmail("");
            employeeDataBase.setComment("");
            employeeDataBase.setStyleSheet("");
            employeeDataBase.setRowsPerPage(50);
            //employeeDataBase.setSisSalesRep("");
            employeeDataBase.setDateUpdated(DateTime.Now);     
            employeeDataBase.setDftDept(tazmDataBase.getZMBDEP());            
            employeeDataBase.setTagNumber(tazmDataBase.getZMTAG());
                                                            
            sdept = "";                //last dept
            if (hashDepts.Contains(employeeDataBase.getEmpID()))
                sdept = (string)hashDepts[employeeDataBase.getEmpID()];

            dateLastLab = DateUtil.MinValue;   //last date
            if (hashDates.Contains(employeeDataBase.getEmpID()))
                dateLastLab = (DateTime)hashDates[employeeDataBase.getEmpID()];      
            
            employeeDataBase.setDftDept(sdept);     
            employeeDataBase.setLastLabourDate(dateLastLab); 
            loadDftLabour(employeeDataBase);                                                   

            employeeDataBaseOld.setEmpID(employeeDataBase.getEmpID());
            if (employeeDataBaseOld.read()){  //check if employee already exists                
                employeeDataBaseOld.setFirstName(employeeDataBase.getFirstName());
                employeeDataBaseOld.setLastName(employeeDataBase.getLastName());
                employeeDataBaseOld.setHomePhone(employeeDataBase.getHomePhone());
                employeeDataBaseOld.setDftDept(employeeDataBase.getDftDept());
                employeeDataBaseOld.setLastLabourDate(employeeDataBase.getLastLabourDate());

                if (employeeDataBaseOld.getDftLabourTypeId() < 1)
                    employeeDataBaseOld.setDftLabourTypeId(employeeDataBase.getDftLabourTypeId());

                employeeDataBaseOld.update();                
            }else
                employeeDataBase.write();
        }

        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		return tazmDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
void loadDftLabour(EmployeeDataBase employeeDataBase){
    PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);

    if (employeeDataBase.getDftLabourTypeId() < 1 && !string.IsNullOrEmpty(employeeDataBase.getDftDept())){
        pltDeptDataBase.setDE_Plt(Configuration.DftPlant);
        pltDeptDataBase.setDE_Dept(employeeDataBase.getDftDept());
        
        if (pltDeptDataBase.read()){
            employeeDataBase.setDftLabourTypeId(pltDeptDataBase.getDE_DftLabTaskId());
        }
    }    
}

public
int cmsCmsNujitEmployeeAssignShift(){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);	

        LbHistDataBaseContainer lbHistDataBaseContainer = new LbHistDataBaseContainer(dataBaseAccess);
        Hashtable               hashEmployeeShift =  lbHistDataBaseContainer.getEmployeeUsualShift(DateTime.Now.AddDays(-30),DateTime.Now.AddDays(-60));
        Hashtable               hashDepts = new Hashtable();
        Hashtable               hashDates = new Hashtable();

        lbHistDataBaseContainer.getEmployeeLastDeptDate(out hashDepts,out hashDates);//get last depts and date worked by employee
        		
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        EmployeeDataBaseContainer employeeDataBaseContainer = new EmployeeDataBaseContainer(dataBaseAccess);
        employeeDataBaseContainer.read();    

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        int         ishift=0;
        string      sdept = "";
        DateTime    dateLastLab = DateUtil.MinValue;
	
		for(IEnumerator en = employeeDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			EmployeeDataBase employeeDataBase = (EmployeeDataBase)en.Current;            
            
            ishift = -1;    //check what shift, if shift<=0 employee will be inactive
            if (hashEmployeeShift.Contains(employeeDataBase.getEmpID()))
                ishift = (int)hashEmployeeShift[employeeDataBase.getEmpID()];

            if (ishift <=0) employeeDataBase.setStatusCode(Constants.STATUS_INACTIVE);
            else            employeeDataBase.setStatusCode(Constants.STATUS_ACTIVE);

            if (ishift < 0)
                ishift =0;

            sdept = "";                //last dept
            if (hashDepts.Contains(employeeDataBase.getEmpID()))
                sdept = (string)hashDepts[employeeDataBase.getEmpID()];

            dateLastLab = DateUtil.MinValue;   //last date
            if (hashDates.Contains(employeeDataBase.getEmpID()))
                dateLastLab = (DateTime)hashDates[employeeDataBase.getEmpID()];
         
            employeeDataBase.setAssignShift(ishift);            
            employeeDataBase.setDftDept(sdept);
            employeeDataBase.setLastLabourDate(dateLastLab);
            loadDftLabour(employeeDataBase); 
            employeeDataBase.update();                            
        }

        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
		
		return employeeDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}




/*    

*/

public
string getDeptsHashKey(PltDeptDataBase pltDeptDataBase){
    return pltDeptDataBase.getDE_Plt().ToUpper() + Constants.DEFAULT_SEP + pltDeptDataBase.getDE_Dept().ToUpper();
}

public
Hashtable loadDeptsHash(){
    Hashtable   hashtable = new Hashtable();
    string      skey="";

    PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
    pltDeptDataBaseContainer.read();

    foreach(PltDeptDataBase pltDeptDataBase in pltDeptDataBaseContainer){
        skey= getDeptsHashKey(pltDeptDataBase);
        hashtable.Add(skey,pltDeptDataBase);
    }

    return hashtable;
}

public
Hashtable loadLabTaskHash(){
    Hashtable                       hashtable = new Hashtable();    
    CapShiftTaskDataBaseContainer   capShiftTaskDataBaseContainer = new CapShiftTaskDataBaseContainer(dataBaseAccess);
    capShiftTaskDataBaseContainer.read();

    foreach(CapShiftTaskDataBase capShiftTaskDataBase in capShiftTaskDataBaseContainer){      
        hashtable.Add(capShiftTaskDataBase.getId(),capShiftTaskDataBase);
    }

    return hashtable;
}

public
Hashtable loadRoutingLabToolHash(){
    Hashtable                               hashtable = new Hashtable();
    int                                     ikey=0;
    ProdFmactSubLabToolDataBaseContainer    labToolDataBaseContainer = null;

    ProdFmactSubLabToolDataBaseContainer prodFmactSubLabToolDataBaseContainer = new ProdFmactSubLabToolDataBaseContainer(dataBaseAccess);
    prodFmactSubLabToolDataBaseContainer.read();

    foreach(ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase in prodFmactSubLabToolDataBaseContainer){
        ikey= prodFmactSubLabToolDataBase.getHdrId();

        if (hashtable.Contains(ikey)){
            labToolDataBaseContainer = (ProdFmactSubLabToolDataBaseContainer)hashtable[ikey];
            labToolDataBaseContainer.Add(prodFmactSubLabToolDataBase);
        }else{       
            labToolDataBaseContainer = new ProdFmactSubLabToolDataBaseContainer(dataBaseAccess);
            labToolDataBaseContainer.Add(prodFmactSubLabToolDataBase);
            hashtable.Add(ikey,labToolDataBaseContainer);
        }        
    }
    return hashtable;
}

public
bool createDefRoutingLabour(ProdFmActSubDataBase prodFmActSubDataBase,Hashtable hashDepts,Hashtable routingLabToolHash,Hashtable labTaskHash){
    bool                        bresult=false;    
    string                      skey="";
    PltDeptDataBase             pltDeptDataBase = null;
    CapShiftTaskDataBase        capShiftTaskDataBase = null;
    ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase= null;
    int                         iroutingId = prodFmActSubDataBase.getPC_Id();
    string                      splant = prodFmActSubDataBase.getPC_Plt();
    string                      sdept = prodFmActSubDataBase.getPC_Dept();
    decimal                     dtotEmployees=0;

    if (!routingLabToolHash.Contains(iroutingId)){ //check if routing already have labour/tools associated

        skey = splant.ToUpper() + Constants.DEFAULT_SEP + sdept.ToUpper();   //get department , check if default labour configurated   
        if (hashDepts.Contains(skey)){      
            pltDeptDataBase = (PltDeptDataBase)hashDepts[skey];

            if (pltDeptDataBase.getDE_DftLabTaskId() > 0 && labTaskHash.Contains(pltDeptDataBase.getDE_DftLabTaskId())){

                capShiftTaskDataBase = (CapShiftTaskDataBase)labTaskHash[pltDeptDataBase.getDE_DftLabTaskId()];

                prodFmactSubLabToolDataBase = new ProdFmactSubLabToolDataBase(dataBaseAccess);
                prodFmactSubLabToolDataBase.setHdrId(iroutingId);
                prodFmactSubLabToolDataBase.setDetail(1);
                prodFmactSubLabToolDataBase.setType(Constants.TYPE_LABOUR);
                prodFmactSubLabToolDataBase.setReqId(capShiftTaskDataBase.getId());                
                dtotEmployees = (decimal) (prodFmActSubDataBase.getPC_QtyMachines() != 0 ? (decimal)prodFmActSubDataBase.getPC_QtyMen() / (decimal)prodFmActSubDataBase.getPC_QtyMachines() : (decimal)prodFmActSubDataBase.getPC_QtyMen());
                prodFmactSubLabToolDataBase.setTotEmployees(dtotEmployees);
                prodFmactSubLabToolDataBase.write();

                bresult=true; 
            }
        }
    }    
    return bresult;
}

private
int createDefaultsRoutingLabourInt(){    
    int icountRecords=0;
    Hashtable hashDepts         =  loadDeptsHash();
    Hashtable hashLaboursTask   =  loadLabTaskHash();
    Hashtable routingLabToolHash=  loadRoutingLabToolHash();

    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
    prodFmActSubDataBaseContainer.read();

    foreach(ProdFmActSubDataBase prodFmActSubDataBase in prodFmActSubDataBaseContainer){
        if (createDefRoutingLabour(prodFmActSubDataBase,hashDepts,routingLabToolHash,hashLaboursTask))
            icountRecords++;                            
    }
    return icountRecords;
}

public
int createDefaultsRoutingLabour(){    
    int icountRecords=0;
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        icountRecords = createDefaultsRoutingLabourInt();

        if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}    
    return icountRecords;
}

/********************************************* Bol ******************************************************************/

public
Bol readBolInternal(decimal fEBOL){
	
		BolhDataBase bolhDataBase = new BolhDataBase(dataBaseAccess);
		bolhDataBase.setFEBOL(fEBOL);

		if (!bolhDataBase.read())
			return null;

		Bol bol = this.objectDataBaseToObject(bolhDataBase);

        BoldContainer boldContainer = new BoldContainer();
        BolhDataBaseContainer bolhDataBaseContainer = new BolhDataBaseContainer(dataBaseAccess);
        BoldDataBaseContainer boldDataBaseContainer = new BoldDataBaseContainer(dataBaseAccess);

        bolhDataBaseContainer.Add(bolhDataBase);
        boldDataBaseContainer.readByHeaders(bolhDataBaseContainer);

        foreach (BoldDataBase boldDataBase in boldDataBaseContainer)
            boldContainer.Add(objectDataBaseToObject(boldDataBase));

        bol.setBoldContainer(boldContainer);

		return bol;	
}

private
void writeBolChilds(Bol bol){
    foreach(Bold bold in bol.getBoldContainer()){
        BoldDataBase boldDataBase = objectToObjectDataBase(bold);
        boldDataBase.write();
    }
}

private
void deleteBolChilds(decimal id){
    BoldDataBaseContainer boldDataBaseContainer = new BoldDataBaseContainer(dataBaseAccess);
    boldDataBaseContainer.deleteByHdr(id);
}

internal 
void writeBolInternal(Bol bol){
		
	BolhDataBase bolhDataBase = this.objectToObjectDataBase(bol);
	bolhDataBase.write();
        
    writeBolChilds(bol);
}

public 
void writeBol(Bol bol){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		writeBolInternal(bol);

       if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}finally{
        //dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

internal 
void updateBolInternal(Bol bol){			
	BolhDataBase bolhDataBase = this.objectToObjectDataBase(bol);
	bolhDataBase.update();

    deleteBolChilds(bol.FEBOL);
    writeBolChilds(bol);      
}

public 
void updateBol(Bol bol){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        updateBolInternal(bol);
        
       if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}finally{
        //dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
BolContainer readBolByFilters(string sferteg ,decimal dorder,bool borderByBol,int rows){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        BolContainer bolContainer = new BolContainer();

        BolhDataBaseContainer bolhDataBaseContainer = new BolhDataBaseContainer(dataBaseAccess);
        bolhDataBaseContainer.readByFilters(sferteg,dorder, borderByBol,100);

        for (int i=0; i < bolhDataBaseContainer.Count;i++){
            Bol bol = this.objectDataBaseToObject((BolhDataBase)bolhDataBaseContainer[i]);

            bol = readBolInternal(bol.FEBOL);
            if (bol!=null)
                bolContainer.Add(bol);
        }

        dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

        for (int i=0; i < bolContainer.Count;i++){
            Bol bol = bolContainer[i];

            BolhDataBase bolhDataBase = new BolhDataBase(dataBaseAccess);
            bolhDataBase.setFEBOL(bol.FEBOL);
            if (bolhDataBase.exists())
                updateBol(bol);
            else
                writeBol(bol);            
        }


        return bolContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        //dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
Bol objectDataBaseToObject(BolhDataBase bolhDataBase){
	Bol bolh = new Bol();

	bolh.FEBOL=bolhDataBase.getFEBOL();
	bolh.FEBTYP=bolhDataBase.getFEBTYP();
	bolh.FECDAT=bolhDataBase.getFECDAT();
	bolh.FEPIND=bolhDataBase.getFEPIND();
	bolh.FESIND=bolhDataBase.getFESIND();
	bolh.FEBCS=bolhDataBase.getFEBCS();
	bolh.FESCS=bolhDataBase.getFESCS();
	bolh.FESVND=bolhDataBase.getFESVND();
	bolh.FERVND=bolhDataBase.getFERVND();
	bolh.FEBNME=bolhDataBase.getFEBNME();
	bolh.FEBPTC=bolhDataBase.getFEBPTC();
	bolh.FEATTN=bolhDataBase.getFEATTN();
	bolh.FESNME=bolhDataBase.getFESNME();
	bolh.FESAD1=bolhDataBase.getFESAD1();
	bolh.FESAD2=bolhDataBase.getFESAD2();
	bolh.FESAD3=bolhDataBase.getFESAD3();
	bolh.FESAD4=bolhDataBase.getFESAD4();
	bolh.FESAD5=bolhDataBase.getFESAD5();
	bolh.FESAD6=bolhDataBase.getFESAD6();
	bolh.FESAD7=bolhDataBase.getFESAD7();
	bolh.FESAD8=bolhDataBase.getFESAD8();
	bolh.FESAD9=bolhDataBase.getFESAD9();
	bolh.FESAD10=bolhDataBase.getFESAD10();
	bolh.FESPTC=bolhDataBase.getFESPTC();
	bolh.FESCTY=bolhDataBase.getFESCTY();
	bolh.FESPOV=bolhDataBase.getFESPOV();
	//bolh.FESCRY=bolhDataBase.getFESCRY();
	bolh.FESDAT=bolhDataBase.getFESDAT();
	bolh.FESVIA=bolhDataBase.getFESVIA();
	bolh.FETKID=bolhDataBase.getFETKID();
	bolh.FENCTN=bolhDataBase.getFENCTN();
	bolh.FENETW=bolhDataBase.getFENETW();
	bolh.FEGROW=bolhDataBase.getFEGROW();
	bolh.FETARW=bolhDataBase.getFETARW();
	bolh.FEWTUN=bolhDataBase.getFEWTUN();
	bolh.FEDOCD=bolhDataBase.getFEDOCD();
	bolh.FEFTCD=bolhDataBase.getFEFTCD();
	bolh.FEORD=bolhDataBase.getFEORD();
	bolh.FESTKL=bolhDataBase.getFESTKL();
	bolh.FEFTAM=bolhDataBase.getFEFTAM();
	bolh.FEFOB=bolhDataBase.getFEFOB();
	bolh.FECARC=bolhDataBase.getFECARC();
	bolh.FESERC=bolhDataBase.getFESERC();
	bolh.FESTME=bolhDataBase.getFESTME();
	bolh.FEJITF=bolhDataBase.getFEJITF();
	bolh.FESID=bolhDataBase.getFESID();
	bolh.FETRPT=bolhDataBase.getFETRPT();
	bolh.FEBID=bolhDataBase.getFEBID();
	bolh.FESFID=bolhDataBase.getFESFID();
	bolh.FEPLNT=bolhDataBase.getFEPLNT();
	bolh.FEITMC=bolhDataBase.getFEITMC();
	bolh.FESUPP=bolhDataBase.getFESUPP();
	bolh.FEULTD=bolhDataBase.getFEULTD();
	bolh.FEEDAT=bolhDataBase.getFEEDAT();
	bolh.FEETIM=bolhDataBase.getFEETIM();
	bolh.FEADAT=bolhDataBase.getFEADAT();
	bolh.FEATIM=bolhDataBase.getFEATIM();
	bolh.FETRNM=bolhDataBase.getFETRNM();
	bolh.FERTEG=bolhDataBase.getFERTEG();
	bolh.FEPLPT=bolhDataBase.getFEPLPT();
	bolh.FEPLOC=bolhDataBase.getFEPLOC();
	bolh.FEEQPD=bolhDataBase.getFEEQPD();
	bolh.FEEQPI=bolhDataBase.getFEEQPI();
	bolh.FEEQID=bolhDataBase.getFEEQID();
	bolh.FEMBOL=bolhDataBase.getFEMBOL();
	bolh.FEPSLP=bolhDataBase.getFEPSLP();
	bolh.FEFRTB=bolhDataBase.getFEFRTB();
	bolh.FEAIRB=bolhDataBase.getFEAIRB();
	bolh.FETSPR=bolhDataBase.getFETSPR();
	bolh.FEETRR=bolhDataBase.getFEETRR();
	bolh.FEEXTR=bolhDataBase.getFEEXTR();
	bolh.FEAETC=bolhDataBase.getFEAETC();
	bolh.FEMTHP=bolhDataBase.getFEMTHP();
	bolh.FETRNT=bolhDataBase.getFETRNT();
	bolh.FETRLQ=bolhDataBase.getFETRLQ();
	bolh.FECCT=bolhDataBase.getFECCT();
	bolh.FECCDE=bolhDataBase.getFECCDE();
	bolh.FESASN=bolhDataBase.getFESASN();
	bolh.FESNTF=bolhDataBase.getFESNTF();
	bolh.FESTS=bolhDataBase.getFESTS();
	bolh.FEXMOD=bolhDataBase.getFEXMOD();
	bolh.FEATYP=bolhDataBase.getFEATYP();
	bolh.FEFLD1=bolhDataBase.getFEFLD1();
	bolh.FEFLD2=bolhDataBase.getFEFLD2();
	bolh.FEFLD3=bolhDataBase.getFEFLD3();
	bolh.FEFLD4=bolhDataBase.getFEFLD4();
	bolh.FEFLD5=bolhDataBase.getFEFLD5();
	bolh.FEFLD6=bolhDataBase.getFEFLD6();
	bolh.FEMANW=bolhDataBase.getFEMANW();
	bolh.FES204=bolhDataBase.getFES204();
	bolh.FEBTRP=bolhDataBase.getFEBTRP();
	bolh.FEBSTS=bolhDataBase.getFEBSTS();
	bolh.FEBACK=bolhDataBase.getFEBACK();
	bolh.FEBSET=bolhDataBase.getFEBSET();
	bolh.FEBMOD=bolhDataBase.getFEBMOD();
	bolh.FESKDQ=bolhDataBase.getFESKDQ();
	bolh.FESKDT=bolhDataBase.getFESKDT();
	bolh.FELOSQ=bolhDataBase.getFELOSQ();
	bolh.FELOST=bolhDataBase.getFELOST();
	bolh.FECRCM=bolhDataBase.getFECRCM();
	bolh.FEUSE=bolhDataBase.getFEUSE();
	bolh.FESLCS=bolhDataBase.getFESLCS();
	bolh.FECRTY=bolhDataBase.getFECRTY();
	bolh.FECRDT=bolhDataBase.getFECRDT();
	bolh.FECRD=bolhDataBase.getFECRD();
	bolh.FEEXPR=bolhDataBase.getFEEXPR();
	bolh.FEHODR=bolhDataBase.getFEHODR();
	bolh.FECRNM=bolhDataBase.getFECRNM();
	bolh.FESHBF=bolhDataBase.getFESHBF();
	bolh.FECLEN=bolhDataBase.getFECLEN();
    /*
	bolh.FEPLTC=bolhDataBase.getFEPLTC();
	bolh.FEFUT1=bolhDataBase.getFEFUT1();
	bolh.FEFUT2=bolhDataBase.getFEFUT2();
	bolh.FEFUT3=bolhDataBase.getFEFUT3();
	bolh.FEFUT4=bolhDataBase.getFEFUT4();
	bolh.FEFUT5=bolhDataBase.getFEFUT5();
	bolh.FEFUT6=bolhDataBase.getFEFUT6();
	bolh.FEFUT7=bolhDataBase.getFEFUT7();
	bolh.FEFUT8=bolhDataBase.getFEFUT8();
	bolh.FEFUT9=bolhDataBase.getFEFUT9();
	bolh.FEFUTA=bolhDataBase.getFEFUTA();
	bolh.FEFUTB=bolhDataBase.getFEFUTB();
	bolh.FEFUTC=bolhDataBase.getFEFUTC();
	bolh.FEFUTD=bolhDataBase.getFEFUTD();
	bolh.FEFUTE=bolhDataBase.getFEFUTE();
	bolh.FEFUTF=bolhDataBase.getFEFUTF();
	bolh.FEFUTG=bolhDataBase.getFEFUTG();
	bolh.FELDTY=bolhDataBase.getFELDTY();
	bolh.FETKST=bolhDataBase.getFETKST();*/
	bolh.FERTS=bolhDataBase.getFERTS();/*
	bolh.FEFUTH=bolhDataBase.getFEFUTH();
	bolh.FEFUTI=bolhDataBase.getFEFUTI();
	bolh.FEFUTJ=bolhDataBase.getFEFUTJ();*/
	bolh.FEFUTK=bolhDataBase.getFEFUTK();
    /*
	bolh.FEFUTL=bolhDataBase.getFEFUTL();
	bolh.FEFUTM=bolhDataBase.getFEFUTM();
	bolh.FEFUTN=bolhDataBase.getFEFUTN();
	bolh.FEFUTO=bolhDataBase.getFEFUTO();*/
	bolh.FEFUTP=bolhDataBase.getFEFUTP();/*
	bolh.FEFUTQ=bolhDataBase.getFEFUTQ();
	bolh.FEFUTR=bolhDataBase.getFEFUTR();
	bolh.FEFUTS=bolhDataBase.getFEFUTS();
	bolh.FEFUTT=bolhDataBase.getFEFUTT();
	bolh.FEFUTU=bolhDataBase.getFEFUTU();
	bolh.FEFUTV=bolhDataBase.getFEFUTV();
	bolh.FEFUTW=bolhDataBase.getFEFUTW();
	bolh.FEFUTX=bolhDataBase.getFEFUTX();
    bolh.FEFUTY=bolhDataBase.getFEFUTY();
	bolh.FEFUTZ=bolhDataBase.getFEFUTZ();
	bolh.FESCNC=bolhDataBase.getFESCNC();
	bolh.FEDDAT=bolhDataBase.getFEDDAT();
	bolh.FEDCMT=bolhDataBase.getFEDCMT();
	bolh.FEMBL=bolhDataBase.getFEMBL();
	bolh.FEATMZ=bolhDataBase.getFEATMZ();
	bolh.FEETMZ=bolhDataBase.getFEETMZ();
	bolh.FESTMZ=bolhDataBase.getFESTMZ();
	bolh.FECTMZ=bolhDataBase.getFECTMZ();
	bolh.FEPSTS=bolhDataBase.getFEPSTS();
	bolh.FETENT=bolhDataBase.getFETENT();
	bolh.FEPQN=bolhDataBase.getFEPQN();*/
	bolh.FETAMT=bolhDataBase.getFETAMT(); /*
	bolh.FEIBN=bolhDataBase.getFEIBN();
	bolh.FESTTP=bolhDataBase.getFESTTP();
	bolh.FESTCN=bolhDataBase.getFESTCN();
	bolh.FEEXPDT=bolhDataBase.getFEEXPDT();
	bolh.FEDLTB=bolhDataBase.getFEDLTB();
    */ 

    bolh.FEPDAT = bolhDataBase.getFEPDAT();
    bolh.FEPTIM = bolhDataBase.getFEPTIM();

    return bolh;
}

private
BolhDataBase objectToObjectDataBase(Bol bolh){
	BolhDataBase bolhDataBase = new BolhDataBase(dataBaseAccess);
	bolhDataBase.setFEBOL(bolh.FEBOL);
	bolhDataBase.setFEBTYP(bolh.FEBTYP);
	bolhDataBase.setFECDAT(bolh.FECDAT);
	bolhDataBase.setFEPIND(bolh.FEPIND);
	bolhDataBase.setFESIND(bolh.FESIND);
	bolhDataBase.setFEBCS(bolh.FEBCS);
	bolhDataBase.setFESCS(bolh.FESCS);
	bolhDataBase.setFESVND(bolh.FESVND);
	bolhDataBase.setFERVND(bolh.FERVND);
	bolhDataBase.setFEBNME(bolh.FEBNME);
	bolhDataBase.setFEBPTC(bolh.FEBPTC);
	bolhDataBase.setFEATTN(bolh.FEATTN);
	bolhDataBase.setFESNME(bolh.FESNME);
	bolhDataBase.setFESAD1(bolh.FESAD1);
	bolhDataBase.setFESAD2(bolh.FESAD2);
	bolhDataBase.setFESAD3(bolh.FESAD3);
	bolhDataBase.setFESAD4(bolh.FESAD4);
	bolhDataBase.setFESAD5(bolh.FESAD5);
	bolhDataBase.setFESAD6(bolh.FESAD6);
	bolhDataBase.setFESAD7(bolh.FESAD7);
	bolhDataBase.setFESAD8(bolh.FESAD8);
	bolhDataBase.setFESAD9(bolh.FESAD9);
	bolhDataBase.setFESAD10(bolh.FESAD10);
	bolhDataBase.setFESPTC(bolh.FESPTC);
	bolhDataBase.setFESCTY(bolh.FESCTY);
	bolhDataBase.setFESPOV(bolh.FESPOV);
	//bolhDataBase.setFESCRY(bolh.FESCRY);
	bolhDataBase.setFESDAT(bolh.FESDAT);
	bolhDataBase.setFESVIA(bolh.FESVIA);
	bolhDataBase.setFETKID(bolh.FETKID);
	bolhDataBase.setFENCTN(bolh.FENCTN);
	bolhDataBase.setFENETW(bolh.FENETW);
	bolhDataBase.setFEGROW(bolh.FEGROW);
	bolhDataBase.setFETARW(bolh.FETARW);
	bolhDataBase.setFEWTUN(bolh.FEWTUN);
	bolhDataBase.setFEDOCD(bolh.FEDOCD);
	bolhDataBase.setFEFTCD(bolh.FEFTCD);
	bolhDataBase.setFEORD(bolh.FEORD);
	bolhDataBase.setFESTKL(bolh.FESTKL);
	bolhDataBase.setFEFTAM(bolh.FEFTAM);
	bolhDataBase.setFEFOB(bolh.FEFOB);
	bolhDataBase.setFECARC(bolh.FECARC);
	bolhDataBase.setFESERC(bolh.FESERC);
	bolhDataBase.setFESTME(bolh.FESTME);
	bolhDataBase.setFEJITF(bolh.FEJITF);
	bolhDataBase.setFESID(bolh.FESID);
	bolhDataBase.setFETRPT(bolh.FETRPT);
	bolhDataBase.setFEBID(bolh.FEBID);
	bolhDataBase.setFESFID(bolh.FESFID);
	bolhDataBase.setFEPLNT(bolh.FEPLNT);
	bolhDataBase.setFEITMC(bolh.FEITMC);
	bolhDataBase.setFESUPP(bolh.FESUPP);
	bolhDataBase.setFEULTD(bolh.FEULTD);
	bolhDataBase.setFEEDAT(bolh.FEEDAT);
	bolhDataBase.setFEETIM(bolh.FEETIM);
	bolhDataBase.setFEADAT(bolh.FEADAT);
	bolhDataBase.setFEATIM(bolh.FEATIM);
	bolhDataBase.setFETRNM(bolh.FETRNM);
	bolhDataBase.setFERTEG(bolh.FERTEG);
	bolhDataBase.setFEPLPT(bolh.FEPLPT);
	bolhDataBase.setFEPLOC(bolh.FEPLOC);
	bolhDataBase.setFEEQPD(bolh.FEEQPD);
	bolhDataBase.setFEEQPI(bolh.FEEQPI);
	bolhDataBase.setFEEQID(bolh.FEEQID);
	bolhDataBase.setFEMBOL(bolh.FEMBOL);
	bolhDataBase.setFEPSLP(bolh.FEPSLP);
	bolhDataBase.setFEFRTB(bolh.FEFRTB);
	bolhDataBase.setFEAIRB(bolh.FEAIRB);
	bolhDataBase.setFETSPR(bolh.FETSPR);
	bolhDataBase.setFEETRR(bolh.FEETRR);
	bolhDataBase.setFEEXTR(bolh.FEEXTR);
	bolhDataBase.setFEAETC(bolh.FEAETC);
	bolhDataBase.setFEMTHP(bolh.FEMTHP);
	bolhDataBase.setFETRNT(bolh.FETRNT);
	bolhDataBase.setFETRLQ(bolh.FETRLQ);
	bolhDataBase.setFECCT(bolh.FECCT);
	bolhDataBase.setFECCDE(bolh.FECCDE);
	bolhDataBase.setFESASN(bolh.FESASN);
	bolhDataBase.setFESNTF(bolh.FESNTF);
	bolhDataBase.setFESTS(bolh.FESTS);
	bolhDataBase.setFEXMOD(bolh.FEXMOD);
	bolhDataBase.setFEATYP(bolh.FEATYP);
	bolhDataBase.setFEFLD1(bolh.FEFLD1);
	bolhDataBase.setFEFLD2(bolh.FEFLD2);
	bolhDataBase.setFEFLD3(bolh.FEFLD3);
	bolhDataBase.setFEFLD4(bolh.FEFLD4);
	bolhDataBase.setFEFLD5(bolh.FEFLD5);
	bolhDataBase.setFEFLD6(bolh.FEFLD6);
	bolhDataBase.setFEMANW(bolh.FEMANW);
	bolhDataBase.setFES204(bolh.FES204);
	bolhDataBase.setFEBTRP(bolh.FEBTRP);
	bolhDataBase.setFEBSTS(bolh.FEBSTS);
	bolhDataBase.setFEBACK(bolh.FEBACK);
	bolhDataBase.setFEBSET(bolh.FEBSET);
	bolhDataBase.setFEBMOD(bolh.FEBMOD);
	bolhDataBase.setFESKDQ(bolh.FESKDQ);
	bolhDataBase.setFESKDT(bolh.FESKDT);
	bolhDataBase.setFELOSQ(bolh.FELOSQ);
	bolhDataBase.setFELOST(bolh.FELOST);
	bolhDataBase.setFECRCM(bolh.FECRCM);
	bolhDataBase.setFEUSE(bolh.FEUSE);
	bolhDataBase.setFESLCS(bolh.FESLCS);
	bolhDataBase.setFECRTY(bolh.FECRTY);
	bolhDataBase.setFECRDT(bolh.FECRDT);
	bolhDataBase.setFECRD(bolh.FECRD);
	bolhDataBase.setFEEXPR(bolh.FEEXPR);
	bolhDataBase.setFEHODR(bolh.FEHODR);
	bolhDataBase.setFECRNM(bolh.FECRNM);
	bolhDataBase.setFESHBF(bolh.FESHBF);
	bolhDataBase.setFECLEN(bolh.FECLEN);
    /*
	bolhDataBase.setFEPLTC(bolh.FEPLTC);
	bolhDataBase.setFEFUT1(bolh.FEFUT1);
	bolhDataBase.setFEFUT2(bolh.FEFUT2);
	bolhDataBase.setFEFUT3(bolh.FEFUT3);
	bolhDataBase.setFEFUT4(bolh.FEFUT4);
	bolhDataBase.setFEFUT5(bolh.FEFUT5);
	bolhDataBase.setFEFUT6(bolh.FEFUT6);
	bolhDataBase.setFEFUT7(bolh.FEFUT7);
	bolhDataBase.setFEFUT8(bolh.FEFUT8);
	bolhDataBase.setFEFUT9(bolh.FEFUT9);
	bolhDataBase.setFEFUTA(bolh.FEFUTA);
	bolhDataBase.setFEFUTB(bolh.FEFUTB);
	bolhDataBase.setFEFUTC(bolh.FEFUTC);
	bolhDataBase.setFEFUTD(bolh.FEFUTD);
	bolhDataBase.setFEFUTE(bolh.FEFUTE);
	bolhDataBase.setFEFUTF(bolh.FEFUTF);
	bolhDataBase.setFEFUTG(bolh.FEFUTG);
	bolhDataBase.setFELDTY(bolh.FELDTY);
	bolhDataBase.setFETKST(bolh.FETKST);*/
	bolhDataBase.setFERTS(bolh.FERTS);/*
	bolhDataBase.setFEFUTH(bolh.FEFUTH);
	bolhDataBase.setFEFUTI(bolh.FEFUTI);
	bolhDataBase.setFEFUTJ(bolh.FEFUTJ);*/
	bolhDataBase.setFEFUTK(bolh.FEFUTK);
    /*
	bolhDataBase.setFEFUTL(bolh.FEFUTL);
	bolhDataBase.setFEFUTM(bolh.FEFUTM);
	bolhDataBase.setFEFUTN(bolh.FEFUTN);
	bolhDataBase.setFEFUTO(bolh.FEFUTO);*/
	bolhDataBase.setFEFUTP(bolh.FEFUTP);/*
	bolhDataBase.setFEFUTQ(bolh.FEFUTQ);
	bolhDataBase.setFEFUTR(bolh.FEFUTR);
	bolhDataBase.setFEFUTS(bolh.FEFUTS);
	bolhDataBase.setFEFUTT(bolh.FEFUTT);
	bolhDataBase.setFEFUTU(bolh.FEFUTU);
	bolhDataBase.setFEFUTV(bolh.FEFUTV);
	bolhDataBase.setFEFUTW(bolh.FEFUTW);
	bolhDataBase.setFEFUTX(bolh.FEFUTX);
	bolhDataBase.setFEFUTY(bolh.FEFUTY);
	bolhDataBase.setFEFUTZ(bolh.FEFUTZ);
	bolhDataBase.setFESCNC(bolh.FESCNC);
	bolhDataBase.setFEDDAT(bolh.FEDDAT);
	bolhDataBase.setFEDCMT(bolh.FEDCMT);
	bolhDataBase.setFEMBL(bolh.FEMBL);
	bolhDataBase.setFEATMZ(bolh.FEATMZ);
	bolhDataBase.setFEETMZ(bolh.FEETMZ);
	bolhDataBase.setFESTMZ(bolh.FESTMZ);
	bolhDataBase.setFECTMZ(bolh.FECTMZ);
	bolhDataBase.setFEPSTS(bolh.FEPSTS);
	bolhDataBase.setFETENT(bolh.FETENT);
	bolhDataBase.setFEPQN(bolh.FEPQN);*/
	bolhDataBase.setFETAMT(bolh.FETAMT); /*
	bolhDataBase.setFEIBN(bolh.FEIBN);
	bolhDataBase.setFESTTP(bolh.FESTTP);
	bolhDataBase.setFESTCN(bolh.FESTCN);
	bolhDataBase.setFEEXPDT(bolh.FEEXPDT);
	bolhDataBase.setFEDLTB(bolh.FEDLTB);
    */
    bolhDataBase.setFEPDAT(bolh.FEPDAT);
    bolhDataBase.setFEPTIM(bolh.FEPTIM);

	return bolhDataBase;
}

public
Bol cloneBol(Bol bolh){
	Bol bolhClone = new Bol();

	bolhClone.FEBOL=bolh.FEBOL;
	bolhClone.FEBTYP=bolh.FEBTYP;
	bolhClone.FECDAT=bolh.FECDAT;
	bolhClone.FEPIND=bolh.FEPIND;
	bolhClone.FESIND=bolh.FESIND;
	bolhClone.FEBCS=bolh.FEBCS;
	bolhClone.FESCS=bolh.FESCS;
	bolhClone.FESVND=bolh.FESVND;
	bolhClone.FERVND=bolh.FERVND;
	bolhClone.FEBNME=bolh.FEBNME;
	bolhClone.FEBPTC=bolh.FEBPTC;
	bolhClone.FEATTN=bolh.FEATTN;
	bolhClone.FESNME=bolh.FESNME;
	bolhClone.FESAD1=bolh.FESAD1;
	bolhClone.FESAD2=bolh.FESAD2;
	bolhClone.FESAD3=bolh.FESAD3;
	bolhClone.FESAD4=bolh.FESAD4;
	bolhClone.FESAD5=bolh.FESAD5;
	bolhClone.FESAD6=bolh.FESAD6;
	bolhClone.FESAD7=bolh.FESAD7;
	bolhClone.FESAD8=bolh.FESAD8;
	bolhClone.FESAD9=bolh.FESAD9;
	bolhClone.FESAD10=bolh.FESAD10;
	bolhClone.FESPTC=bolh.FESPTC;
    
	bolhClone.FESCTY=bolh.FESCTY;
	bolhClone.FESPOV=bolh.FESPOV;
	//bolhClone.FESCRY=bolh.FESCRY;
	bolhClone.FESDAT=bolh.FESDAT;
	bolhClone.FESVIA=bolh.FESVIA;
	bolhClone.FETKID=bolh.FETKID;
	bolhClone.FENCTN=bolh.FENCTN;
	bolhClone.FENETW=bolh.FENETW;
	bolhClone.FEGROW=bolh.FEGROW;
	bolhClone.FETARW=bolh.FETARW;
	bolhClone.FEWTUN=bolh.FEWTUN;
	bolhClone.FEDOCD=bolh.FEDOCD;
	bolhClone.FEFTCD=bolh.FEFTCD;
	bolhClone.FEORD=bolh.FEORD;
	bolhClone.FESTKL=bolh.FESTKL;
	bolhClone.FEFTAM=bolh.FEFTAM;
	bolhClone.FEFOB=bolh.FEFOB;
	bolhClone.FECARC=bolh.FECARC;
	bolhClone.FESERC=bolh.FESERC;
	bolhClone.FESTME=bolh.FESTME;
	bolhClone.FEJITF=bolh.FEJITF;
	bolhClone.FESID=bolh.FESID;
	bolhClone.FETRPT=bolh.FETRPT;
	bolhClone.FEBID=bolh.FEBID;
	bolhClone.FESFID=bolh.FESFID;
	bolhClone.FEPLNT=bolh.FEPLNT;
	bolhClone.FEITMC=bolh.FEITMC;
	bolhClone.FESUPP=bolh.FESUPP;
	bolhClone.FEULTD=bolh.FEULTD;
	bolhClone.FEEDAT=bolh.FEEDAT;
	bolhClone.FEETIM=bolh.FEETIM;
	bolhClone.FEADAT=bolh.FEADAT;
	bolhClone.FEATIM=bolh.FEATIM;
	bolhClone.FETRNM=bolh.FETRNM;
	bolhClone.FERTEG=bolh.FERTEG;
	bolhClone.FEPLPT=bolh.FEPLPT;
	bolhClone.FEPLOC=bolh.FEPLOC;
	bolhClone.FEEQPD=bolh.FEEQPD;
	bolhClone.FEEQPI=bolh.FEEQPI;
	bolhClone.FEEQID=bolh.FEEQID;
	bolhClone.FEMBOL=bolh.FEMBOL;
	bolhClone.FEPSLP=bolh.FEPSLP;
	bolhClone.FEFRTB=bolh.FEFRTB;
	bolhClone.FEAIRB=bolh.FEAIRB;
	bolhClone.FETSPR=bolh.FETSPR;
	bolhClone.FEETRR=bolh.FEETRR;
	bolhClone.FEEXTR=bolh.FEEXTR;
	bolhClone.FEAETC=bolh.FEAETC;
	bolhClone.FEMTHP=bolh.FEMTHP;
	bolhClone.FETRNT=bolh.FETRNT;
	bolhClone.FETRLQ=bolh.FETRLQ;
	bolhClone.FECCT=bolh.FECCT;
	bolhClone.FECCDE=bolh.FECCDE;
	bolhClone.FESASN=bolh.FESASN;
	bolhClone.FESNTF=bolh.FESNTF;
	bolhClone.FESTS=bolh.FESTS;
	bolhClone.FEXMOD=bolh.FEXMOD;
	bolhClone.FEATYP=bolh.FEATYP;
	bolhClone.FEFLD1=bolh.FEFLD1;
	bolhClone.FEFLD2=bolh.FEFLD2;
	bolhClone.FEFLD3=bolh.FEFLD3;
	bolhClone.FEFLD4=bolh.FEFLD4;
	bolhClone.FEFLD5=bolh.FEFLD5;
	bolhClone.FEFLD6=bolh.FEFLD6;
	bolhClone.FEMANW=bolh.FEMANW;
	bolhClone.FES204=bolh.FES204;
	bolhClone.FEBTRP=bolh.FEBTRP;
	bolhClone.FEBSTS=bolh.FEBSTS;
	bolhClone.FEBACK=bolh.FEBACK;
	bolhClone.FEBSET=bolh.FEBSET;
	bolhClone.FEBMOD=bolh.FEBMOD;
	bolhClone.FESKDQ=bolh.FESKDQ;
	bolhClone.FESKDT=bolh.FESKDT;
	bolhClone.FELOSQ=bolh.FELOSQ;
	bolhClone.FELOST=bolh.FELOST;
	bolhClone.FECRCM=bolh.FECRCM;
	bolhClone.FEUSE=bolh.FEUSE;
	bolhClone.FESLCS=bolh.FESLCS;
	bolhClone.FECRTY=bolh.FECRTY;
	bolhClone.FECRDT=bolh.FECRDT;
	bolhClone.FECRD=bolh.FECRD;
	bolhClone.FEEXPR=bolh.FEEXPR;
	bolhClone.FEHODR=bolh.FEHODR;
	bolhClone.FECRNM=bolh.FECRNM;
	bolhClone.FESHBF=bolh.FESHBF;
	bolhClone.FECLEN=bolh.FECLEN;
	bolhClone.FEPLTC=bolh.FEPLTC;
	bolhClone.FEFUT1=bolh.FEFUT1;
	bolhClone.FEFUT2=bolh.FEFUT2;
	bolhClone.FEFUT3=bolh.FEFUT3;
	bolhClone.FEFUT4=bolh.FEFUT4;
	bolhClone.FEFUT5=bolh.FEFUT5;
	bolhClone.FEFUT6=bolh.FEFUT6;
	bolhClone.FEFUT7=bolh.FEFUT7;
	bolhClone.FEFUT8=bolh.FEFUT8;
	bolhClone.FEFUT9=bolh.FEFUT9;
	bolhClone.FEFUTA=bolh.FEFUTA;
	bolhClone.FEFUTB=bolh.FEFUTB;
	bolhClone.FEFUTC=bolh.FEFUTC;
	bolhClone.FEFUTD=bolh.FEFUTD;
	bolhClone.FEFUTE=bolh.FEFUTE;
	bolhClone.FEFUTF=bolh.FEFUTF;
	bolhClone.FEFUTG=bolh.FEFUTG;
    /*
	bolhClone.FELDTY=bolh.FELDTY;
	bolhClone.FETKST=bolh.FETKST;*/
	bolhClone.FERTS=bolh.FERTS;/*
	bolhClone.FEFUTH=bolh.FEFUTH;
	bolhClone.FEFUTI=bolh.FEFUTI;
	bolhClone.FEFUTJ=bolh.FEFUTJ;*/
	bolhClone.FEFUTK=bolh.FEFUTK;
    /*
	bolhClone.FEFUTL=bolh.FEFUTL;
	bolhClone.FEFUTM=bolh.FEFUTM;
	bolhClone.FEFUTN=bolh.FEFUTN;
	bolhClone.FEFUTO=bolh.FEFUTO;*/
	bolhClone.FEFUTP=bolh.FEFUTP;/*
	bolhClone.FEFUTQ=bolh.FEFUTQ;
	bolhClone.FEFUTR=bolh.FEFUTR;
	bolhClone.FEFUTS=bolh.FEFUTS;
	bolhClone.FEFUTT=bolh.FEFUTT;
	bolhClone.FEFUTU=bolh.FEFUTU;
	bolhClone.FEFUTV=bolh.FEFUTV;
	bolhClone.FEFUTW=bolh.FEFUTW;
	bolhClone.FEFUTX=bolh.FEFUTX;
	bolhClone.FEFUTY=bolh.FEFUTY;
	bolhClone.FEFUTZ=bolh.FEFUTZ;
	bolhClone.FESCNC=bolh.FESCNC;
	bolhClone.FEDDAT=bolh.FEDDAT;
	bolhClone.FEDCMT=bolh.FEDCMT;
	bolhClone.FEMBL=bolh.FEMBL;
	bolhClone.FEATMZ=bolh.FEATMZ;
	bolhClone.FEETMZ=bolh.FEETMZ;
	bolhClone.FESTMZ=bolh.FESTMZ;
	bolhClone.FECTMZ=bolh.FECTMZ;
	bolhClone.FEPSTS=bolh.FEPSTS;
	bolhClone.FETENT=bolh.FETENT;
	bolhClone.FEPQN=bolh.FEPQN;*/
	bolhClone.FETAMT=bolh.FETAMT; /*
	bolhClone.FEIBN=bolh.FEIBN;
	bolhClone.FESTTP=bolh.FESTTP;
	bolhClone.FESTCN=bolh.FESTCN;
	bolhClone.FEEXPDT=bolh.FEEXPDT;
	bolhClone.FEDLTB=bolh.FEDLTB;*/

    bolhClone.FEPDAT=bolh.FEPDAT;
    bolhClone.FEPTIM=bolh.FEPTIM;

	return bolhClone;
}

/********************************************************** Bold ********************************************************************/
public
Bold createBold(){
	return new Bold();
}

public
BoldContainer createBoldContainer(){
	return new BoldContainer();
}

private
Bold objectDataBaseToObject(BoldDataBase boldDataBase){
	Bold bold = new Bold();

	bold.FGBOL=boldDataBase.getFGBOL();
	bold.FGENT=boldDataBase.getFGENT();
	bold.FGORD=boldDataBase.getFGORD();
	bold.FGITEM=boldDataBase.getFGITEM();
	bold.FGPO=boldDataBase.getFGPO();
	bold.FGPREL=boldDataBase.getFGPREL();
	bold.FGPITM=boldDataBase.getFGPITM();
	bold.FGQSHP=boldDataBase.getFGQSHP();
	bold.FGQSHO=boldDataBase.getFGQSHO();
	bold.FGCTNC=boldDataBase.getFGCTNC();
	bold.FGCTNN=boldDataBase.getFGCTNN();
	//bold.FGPLTN=boldDataBase.getFGPLTN();
	bold.FGNTWC=boldDataBase.getFGNTWC();
	bold.FGGRSC=boldDataBase.getFGGRSC();
	bold.FGTARC=boldDataBase.getFGTARC();
	bold.FGVOLC=boldDataBase.getFGVOLC();
	bold.FGQTYC=boldDataBase.getFGQTYC();
	bold.FGWGTP=boldDataBase.getFGWGTP();
	bold.FGVOLP=boldDataBase.getFGVOLP();
	bold.FGLSTS=boldDataBase.getFGLSTS();
	bold.FGPART=boldDataBase.getFGPART();
	bold.FGRLNO=boldDataBase.getFGRLNO();
	bold.FGINV=boldDataBase.getFGINV();
	bold.FGLIN=boldDataBase.getFGLIN();
	bold.FGORUN=boldDataBase.getFGORUN();
	bold.FGFTAM=boldDataBase.getFGFTAM();
	bold.FGSTKL=boldDataBase.getFGSTKL();
	bold.FGRAN=boldDataBase.getFGRAN();
	bold.FGCPT=boldDataBase.getFGCPT();
	bold.FGCNID=boldDataBase.getFGCNID();
	bold.FGECHG=boldDataBase.getFGECHG();
	bold.FGCCUM=boldDataBase.getFGCCUM();
	bold.FGPCUM=boldDataBase.getFGPCUM();
	bold.FGCPO=boldDataBase.getFGCPO();
	bold.FGCMPR=boldDataBase.getFGCMPR();
	bold.FGDOCK=boldDataBase.getFGDOCK();
	bold.FGISTS=boldDataBase.getFGISTS();
	bold.FGSREF=boldDataBase.getFGSREF();
	bold.FGCRCM=boldDataBase.getFGCRCM();
	bold.FGUSR1=boldDataBase.getFGUSR1();
	bold.FGUSR2=boldDataBase.getFGUSR2();
	bold.FGUSR3=boldDataBase.getFGUSR3();
	bold.FGREQ=boldDataBase.getFGREQ();
	bold.FGDREQ=boldDataBase.getFGDREQ();
	//bold.FGJITD=boldDataBase.getFGJITD();
	bold.FGUSR4=boldDataBase.getFGUSR4();
	bold.FGUSR5=boldDataBase.getFGUSR5();
	bold.FGFUT1=boldDataBase.getFGFUT1();
	bold.FGFUT2=boldDataBase.getFGFUT2();
	bold.FGFUT3=boldDataBase.getFGFUT3();
	bold.FGFUT4=boldDataBase.getFGFUT4();
	bold.FGFUT5=boldDataBase.getFGFUT5();
    /*
	bold.FGFUTA=boldDataBase.getFGFUTA();
	bold.FGFUTB=boldDataBase.getFGFUTB();
	bold.FGFUTC=boldDataBase.getFGFUTC();
	bold.FGFUTD=boldDataBase.getFGFUTD();
	bold.FGFUTE=boldDataBase.getFGFUTE();
	bold.FGFUTF=boldDataBase.getFGFUTF();
	bold.FGFUTG=boldDataBase.getFGFUTG();
	bold.FGFUTH=boldDataBase.getFGFUTH();
	bold.FGFUTI=boldDataBase.getFGFUTI();
	bold.FGFUTJ=boldDataBase.getFGFUTJ();
	bold.FGFUTK=boldDataBase.getFGFUTK();
	bold.FGFUTL=boldDataBase.getFGFUTL();
	bold.FGFUTM=boldDataBase.getFGFUTM();
	bold.FGFUTN=boldDataBase.getFGFUTN();
	bold.FGFUTO=boldDataBase.getFGFUTO();
	bold.FGFUTP=boldDataBase.getFGFUTP();
	bold.FGFUTQ=boldDataBase.getFGFUTQ();
	bold.FGFUTR=boldDataBase.getFGFUTR();
	bold.FGFUTS=boldDataBase.getFGFUTS();
	bold.FGFUTT=boldDataBase.getFGFUTT();
	bold.FGPLNT=boldDataBase.getFGPLNT();
	bold.FGBUNT=boldDataBase.getFGBUNT();
	bold.FGRPBR=boldDataBase.getFGRPBR();*/
	bold.FGNWFP=boldDataBase.getFGNWFP();/*
	bold.FGCREL=boldDataBase.getFGCREL();*/
	bold.FGPSLP=boldDataBase.getFGPSLP();
    /*
	bold.FGRMID=boldDataBase.getFGRMID();
	bold.FGCREV=boldDataBase.getFGCREV();
	bold.FGREFF=boldDataBase.getFGREFF();*/

	return bold;
}

private
BoldDataBase objectToObjectDataBase(Bold bold){
	BoldDataBase boldDataBase = new BoldDataBase(dataBaseAccess);
	boldDataBase.setFGBOL(bold.FGBOL);
	boldDataBase.setFGENT(bold.FGENT);
	boldDataBase.setFGORD(bold.FGORD);
	boldDataBase.setFGITEM(bold.FGITEM);
	boldDataBase.setFGPO(bold.FGPO);
	boldDataBase.setFGPREL(bold.FGPREL);
	boldDataBase.setFGPITM(bold.FGPITM);
	boldDataBase.setFGQSHP(bold.FGQSHP);
	boldDataBase.setFGQSHO(bold.FGQSHO);
	boldDataBase.setFGCTNC(bold.FGCTNC);
	boldDataBase.setFGCTNN(bold.FGCTNN);
	//boldDataBase.setFGPLTN(bold.FGPLTN);
	boldDataBase.setFGNTWC(bold.FGNTWC);
	boldDataBase.setFGGRSC(bold.FGGRSC);
	boldDataBase.setFGTARC(bold.FGTARC);
	boldDataBase.setFGVOLC(bold.FGVOLC);
	boldDataBase.setFGQTYC(bold.FGQTYC);
	boldDataBase.setFGWGTP(bold.FGWGTP);
	boldDataBase.setFGVOLP(bold.FGVOLP);
	boldDataBase.setFGLSTS(bold.FGLSTS);
	boldDataBase.setFGPART(bold.FGPART);
	boldDataBase.setFGRLNO(bold.FGRLNO);
	boldDataBase.setFGINV(bold.FGINV);
	boldDataBase.setFGLIN(bold.FGLIN);
	boldDataBase.setFGORUN(bold.FGORUN);
	boldDataBase.setFGFTAM(bold.FGFTAM);
	boldDataBase.setFGSTKL(bold.FGSTKL);
	boldDataBase.setFGRAN(bold.FGRAN);
	boldDataBase.setFGCPT(bold.FGCPT);
	boldDataBase.setFGCNID(bold.FGCNID);
	boldDataBase.setFGECHG(bold.FGECHG);
	boldDataBase.setFGCCUM(bold.FGCCUM);
	boldDataBase.setFGPCUM(bold.FGPCUM);
	boldDataBase.setFGCPO(bold.FGCPO);
	boldDataBase.setFGCMPR(bold.FGCMPR);
	boldDataBase.setFGDOCK(bold.FGDOCK);
	boldDataBase.setFGISTS(bold.FGISTS);
	boldDataBase.setFGSREF(bold.FGSREF);
	boldDataBase.setFGCRCM(bold.FGCRCM);
	boldDataBase.setFGUSR1(bold.FGUSR1);
	boldDataBase.setFGUSR2(bold.FGUSR2);
	boldDataBase.setFGUSR3(bold.FGUSR3);
	boldDataBase.setFGREQ(bold.FGREQ);
	boldDataBase.setFGDREQ(bold.FGDREQ);
	//boldDataBase.setFGJITD(bold.FGJITD);
	boldDataBase.setFGUSR4(bold.FGUSR4);
	boldDataBase.setFGUSR5(bold.FGUSR5);
	boldDataBase.setFGFUT1(bold.FGFUT1);
	boldDataBase.setFGFUT2(bold.FGFUT2);
	boldDataBase.setFGFUT3(bold.FGFUT3);
	boldDataBase.setFGFUT4(bold.FGFUT4);
	boldDataBase.setFGFUT5(bold.FGFUT5);
    /*
	boldDataBase.setFGFUTA(bold.FGFUTA);
	boldDataBase.setFGFUTB(bold.FGFUTB);
	boldDataBase.setFGFUTC(bold.FGFUTC);
	boldDataBase.setFGFUTD(bold.FGFUTD);
	boldDataBase.setFGFUTE(bold.FGFUTE);
	boldDataBase.setFGFUTF(bold.FGFUTF);
	boldDataBase.setFGFUTG(bold.FGFUTG);
	boldDataBase.setFGFUTH(bold.FGFUTH);
	boldDataBase.setFGFUTI(bold.FGFUTI);
	boldDataBase.setFGFUTJ(bold.FGFUTJ);
	boldDataBase.setFGFUTK(bold.FGFUTK);
	boldDataBase.setFGFUTL(bold.FGFUTL);
	boldDataBase.setFGFUTM(bold.FGFUTM);
	boldDataBase.setFGFUTN(bold.FGFUTN);
	boldDataBase.setFGFUTO(bold.FGFUTO);
	boldDataBase.setFGFUTP(bold.FGFUTP);
	boldDataBase.setFGFUTQ(bold.FGFUTQ);
	boldDataBase.setFGFUTR(bold.FGFUTR);
	boldDataBase.setFGFUTS(bold.FGFUTS);
	boldDataBase.setFGFUTT(bold.FGFUTT);
	boldDataBase.setFGPLNT(bold.FGPLNT);
	boldDataBase.setFGBUNT(bold.FGBUNT);
	boldDataBase.setFGRPBR(bold.FGRPBR);*/
	boldDataBase.setFGNWFP(bold.FGNWFP);/*
	boldDataBase.setFGCREL(bold.FGCREL);*/
	boldDataBase.setFGPSLP(bold.FGPSLP);
	/*boldDataBase.setFGRMID(bold.FGRMID);
	boldDataBase.setFGCREV(bold.FGCREV);
	boldDataBase.setFGREFF(bold.FGREFF);*/

	return boldDataBase;
}

public
Bold cloneBold(Bold bold){
	Bold boldClone = new Bold();

	boldClone.FGBOL=bold.FGBOL;
	boldClone.FGENT=bold.FGENT;
	boldClone.FGORD=bold.FGORD;
	boldClone.FGITEM=bold.FGITEM;
	boldClone.FGPO=bold.FGPO;
	boldClone.FGPREL=bold.FGPREL;
	boldClone.FGPITM=bold.FGPITM;
	boldClone.FGQSHP=bold.FGQSHP;
	boldClone.FGQSHO=bold.FGQSHO;
	boldClone.FGCTNC=bold.FGCTNC;
	boldClone.FGCTNN=bold.FGCTNN;
	boldClone.FGPLTN=bold.FGPLTN;
	boldClone.FGNTWC=bold.FGNTWC;
	boldClone.FGGRSC=bold.FGGRSC;
	boldClone.FGTARC=bold.FGTARC;
	boldClone.FGVOLC=bold.FGVOLC;
	boldClone.FGQTYC=bold.FGQTYC;
	boldClone.FGWGTP=bold.FGWGTP;
	boldClone.FGVOLP=bold.FGVOLP;
	boldClone.FGLSTS=bold.FGLSTS;
	boldClone.FGPART=bold.FGPART;
	boldClone.FGRLNO=bold.FGRLNO;
	boldClone.FGINV=bold.FGINV;
	boldClone.FGLIN=bold.FGLIN;
	boldClone.FGORUN=bold.FGORUN;
	boldClone.FGFTAM=bold.FGFTAM;
	boldClone.FGSTKL=bold.FGSTKL;
	boldClone.FGRAN=bold.FGRAN;
	boldClone.FGCPT=bold.FGCPT;
	boldClone.FGCNID=bold.FGCNID;
	boldClone.FGECHG=bold.FGECHG;
	boldClone.FGCCUM=bold.FGCCUM;
	boldClone.FGPCUM=bold.FGPCUM;
	boldClone.FGCPO=bold.FGCPO;
	boldClone.FGCMPR=bold.FGCMPR;
	boldClone.FGDOCK=bold.FGDOCK;
	boldClone.FGISTS=bold.FGISTS;
	boldClone.FGSREF=bold.FGSREF;
	boldClone.FGCRCM=bold.FGCRCM;
	boldClone.FGUSR1=bold.FGUSR1;
	boldClone.FGUSR2=bold.FGUSR2;
	boldClone.FGUSR3=bold.FGUSR3;
	boldClone.FGREQ=bold.FGREQ;
	boldClone.FGDREQ=bold.FGDREQ;
	boldClone.FGJITD=bold.FGJITD;
	boldClone.FGUSR4=bold.FGUSR4;
	boldClone.FGUSR5=bold.FGUSR5;
	boldClone.FGFUT1=bold.FGFUT1;
	boldClone.FGFUT2=bold.FGFUT2;
	boldClone.FGFUT3=bold.FGFUT3;
	boldClone.FGFUT4=bold.FGFUT4;
	boldClone.FGFUT5=bold.FGFUT5;
	boldClone.FGFUTA=bold.FGFUTA;
	boldClone.FGFUTB=bold.FGFUTB;
	boldClone.FGFUTC=bold.FGFUTC;
	boldClone.FGFUTD=bold.FGFUTD;
	boldClone.FGFUTE=bold.FGFUTE;
	boldClone.FGFUTF=bold.FGFUTF;
	boldClone.FGFUTG=bold.FGFUTG;
	boldClone.FGFUTH=bold.FGFUTH;
	boldClone.FGFUTI=bold.FGFUTI;
	boldClone.FGFUTJ=bold.FGFUTJ;
	boldClone.FGFUTK=bold.FGFUTK;
	boldClone.FGFUTL=bold.FGFUTL;
	boldClone.FGFUTM=bold.FGFUTM;
	boldClone.FGFUTN=bold.FGFUTN;
	boldClone.FGFUTO=bold.FGFUTO;
	boldClone.FGFUTP=bold.FGFUTP;
	boldClone.FGFUTQ=bold.FGFUTQ;
	boldClone.FGFUTR=bold.FGFUTR;
	boldClone.FGFUTS=bold.FGFUTS;
	boldClone.FGFUTT=bold.FGFUTT;
    /*
	boldClone.FGPLNT=bold.FGPLNT;
	boldClone.FGBUNT=bold.FGBUNT;
	boldClone.FGRPBR=bold.FGRPBR;*/
	boldClone.FGNWFP=bold.FGNWFP;/*
	boldClone.FGCREL=bold.FGCREL;*/
	boldClone.FGPSLP=bold.FGPSLP;
    /*
	boldClone.FGRMID=bold.FGRMID;
	boldClone.FGCREV=bold.FGCREV;
	boldClone.FGREFF=bold.FGREFF;*/

	return boldClone;
}

public 
int cms400ToCmsTempBols(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
        int         irows=Configuration.DataTransferMaxRecords; 
        
		BolhDataBaseContainer bolhDataBaseContainer = new BolhDataBaseContainer(dataBaseAccess);
        BoldDataBaseContainer boldDataBaseContainer = new BoldDataBaseContainer(dataBaseAccess);

        if (irows > 0) {
             loadBolhBySteps(bolhDataBaseContainer,"","",irows);                
             loadBoldBySteps(boldDataBaseContainer,"",irows);                    
        }else{ 
		    bolhDataBaseContainer.read();        
		    boldDataBaseContainer.read();
        }
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		bolhDataBaseContainer.truncate();
		bolhDataBaseContainer.write();

        boldDataBaseContainer.truncate();
        boldDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();		

		return bolhDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private      
void loadBolhBySteps(BolhDataBaseContainer bolhDataBaseContainer,string splant,string status,int irows){
    decimal dkey=0;    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                

        BolhDataBaseContainer bolhDataBaseContainerAux = new BolhDataBaseContainer(dataBaseAccess);            
        bolhDataBaseContainerAux.readByFiltersTransfer(dkey, splant,status,DateUtil.MinValue,DateUtil.MinValue,irows);
       
        if (bolhDataBaseContainerAux.Count > 0){
            BolhDataBase bolhDataBase = (BolhDataBase)bolhDataBaseContainerAux[bolhDataBaseContainerAux.Count - 1];
            dkey  = bolhDataBase.getFEBOL();
            bolhDataBaseContainer.AddRange(bolhDataBaseContainerAux);
       }
       if (bolhDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

private      
void loadBoldBySteps(BoldDataBaseContainer boldDataBaseContainer, string splant,int irows){
    string  skey="";    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                

        BoldDataBaseContainer boldDataBaseContainerAux = new BoldDataBaseContainer(dataBaseAccess);            
        boldDataBaseContainerAux.readByFiltersTransfer(skey, splant,irows);
       
        if (boldDataBaseContainerAux.Count > 0){
            BoldDataBase boldDataBase = (BoldDataBase)boldDataBaseContainerAux[boldDataBaseContainerAux.Count - 1];            
            boldDataBaseContainer.AddRange(boldDataBaseContainerAux);
            
            string sfgbol= Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt64(boldDataBase.getFGBOL()).ToString(),'0',10,false);		 
            string sfgent= Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar(Convert.ToInt32(boldDataBase.getFGENT()).ToString(),'0',5,false);		 
            skey = sfgbol + Constants.DEFAULT_SEP + sfgent;            
       }
       if (boldDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}

public 
int cms400ToCmsTempRaca(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		
        int         irows=Configuration.DataTransferMaxRecords; 
        
		RacaDataBaseContainer racaDataBaseContainer = new RacaDataBaseContainer(dataBaseAccess);
        
        if (irows > 0)
             loadRacaBySteps(racaDataBaseContainer,irows);                
        else 
		    racaDataBaseContainer.read();        		    
		
		dataBaseAccess.switchConnection(DataBaseAccess.CMSTEMP_DATABASE);

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		racaDataBaseContainer.truncate();
		racaDataBaseContainer.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();		

		return racaDataBaseContainer.Count;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private      
void loadRacaBySteps(RacaDataBaseContainer racaDataBaseContainer,int irows){
    decimal dkey=0;    
    bool    bprocess=true;    
        
    for (int i=0; bprocess; i++) {       
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);      //connect each time to free                

        RacaDataBaseContainer racaDataBaseContainerAux = new RacaDataBaseContainer(dataBaseAccess);            
        racaDataBaseContainerAux.readByFiltersTransfer(dkey,irows);
       
        if (racaDataBaseContainerAux.Count > 0){
            RacaDataBase racaDataBase = (RacaDataBase)racaDataBaseContainerAux[racaDataBaseContainerAux.Count - 1];
            dkey  = racaDataBase.getQFENT();
            racaDataBaseContainer.AddRange(racaDataBaseContainerAux);
       }
       if (racaDataBaseContainerAux.Count < irows)    
            bprocess =false;
    }
}


/************************************************* Seri **********************************************************/
public
Seri createSeri(){
	return new Seri();
}

public
SeriContainer createSeriContainer(){
	return new SeriContainer();
}

public
bool existsSeri(decimal hTSERN){
	int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		SeriDataBase seriDataBase = new SeriDataBase(dataBaseAccess);

		seriDataBase.setHTSERN(hTSERN);

		return seriDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
Seri readSeri(decimal hTSERN){
	int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		SeriDataBase seriDataBase = new SeriDataBase(dataBaseAccess);
		seriDataBase.setHTSERN(hTSERN);

		if (!seriDataBase.read())
			return null;

		Seri seri = this.objectDataBaseToObject(seriDataBase);

		return seri;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void updateSeri(Seri seri){
	int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		SeriDataBase seriDataBase = this.objectToObjectDataBase(seri);
		seriDataBase.update();		

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void updateSeriSuppSerial(Seri seri){
	int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		SeriDataBase seriDataBase = this.objectToObjectDataBase(seri);
        seriDataBase.updateSuppSerial(seri.HTSUPS);		

	}catch(PersistenceException persistenceException){
        if (persistenceException.Message.ToLower().IndexOf("arithmetic") < 0)
		    throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
        if (exception.Message.ToLower().IndexOf("arithmetic") < 0)
		    throw new NujitException(exception.Message,exception);
	}finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void writeSeri(Seri seri){
	int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		SeriDataBase seriDataBase = this.objectToObjectDataBase(seri);
		seriDataBase.write();
		
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
void deleteSeri(decimal hTSERN){
	int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		SeriDataBase seriDataBase = new SeriDataBase(dataBaseAccess);

		seriDataBase.setHTSERN(hTSERN);
		seriDataBase.delete();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
Seri objectDataBaseToObject(SeriDataBase seriDataBase){
	Seri seri = new Seri();

	seri.HTSERN=seriDataBase.getHTSERN();
	seri.HTPART=seriDataBase.getHTPART();
	seri.HTLOTN=seriDataBase.getHTLOTN();
	seri.HTSEQ=seriDataBase.getHTSEQ();
	seri.HTJOBN=seriDataBase.getHTJOBN();
	seri.HTQTY=seriDataBase.getHTQTY();
	seri.HTQTYC=seriDataBase.getHTQTYC();
	seri.HTUNIT=seriDataBase.getHTUNIT();
	seri.HTCTNR=seriDataBase.getHTCTNR();
	seri.HTLBLT=seriDataBase.getHTLBLT();
	seri.HTSRC=seriDataBase.getHTSRC();
	seri.HTMSTN=seriDataBase.getHTMSTN();
	seri.HTMSTS=seriDataBase.getHTMSTS();
	seri.HTSTKL=seriDataBase.getHTSTKL();
	seri.HTBINL=seriDataBase.getHTBINL();
	seri.HTSTS=seriDataBase.getHTSTS();
	seri.HTADAT=seriDataBase.getHTADAT();
	seri.HTGWGT=seriDataBase.getHTGWGT();
	seri.HTWUNT=seriDataBase.getHTWUNT();
	seri.HTTWGT=seriDataBase.getHTTWGT();
	seri.HTFUT1=seriDataBase.getHTFUT1();
	seri.HTFUT2=seriDataBase.getHTFUT2();
	seri.HTFUT3=seriDataBase.getHTFUT3();
	seri.HTFUT4=seriDataBase.getHTFUT4();
	seri.HTFUT5=seriDataBase.getHTFUT5();
	seri.HTFUT6=seriDataBase.getHTFUT6();
	seri.HTCORG=seriDataBase.getHTCORG();
	seri.HTPSRN=seriDataBase.getHTPSRN();
	seri.HTRCLF=seriDataBase.getHTRCLF();
	seri.HTPLNT=seriDataBase.getHTPLNT();
	seri.HTHDRF=seriDataBase.getHTHDRF();
	seri.HTHDRS=seriDataBase.getHTHDRS();
	seri.HTSTRN=seriDataBase.getHTSTRN();
	seri.HTSUPS=seriDataBase.getHTSUPS();
	seri.HTFUT7=seriDataBase.getHTFUT7();
	seri.HTFUT8=seriDataBase.getHTFUT8();
	seri.HTFUT9=seriDataBase.getHTFUT9();
	seri.HTFU10=seriDataBase.getHTFU10();
	seri.HTFU11=seriDataBase.getHTFU11();
	seri.HTFU12=seriDataBase.getHTFU12();
	seri.HTFU13=seriDataBase.getHTFU13();
	seri.HTFU14=seriDataBase.getHTFU14();
	seri.HTFU15=seriDataBase.getHTFU15();
	seri.HTFU16=seriDataBase.getHTFU16();

	return seri;
}

private
SeriDataBase objectToObjectDataBase(Seri seri){
	SeriDataBase seriDataBase = new SeriDataBase(dataBaseAccess);
	seriDataBase.setHTSERN(seri.HTSERN);
	seriDataBase.setHTPART(seri.HTPART);
	seriDataBase.setHTLOTN(seri.HTLOTN);
	seriDataBase.setHTSEQ(seri.HTSEQ);
	seriDataBase.setHTJOBN(seri.HTJOBN);
	seriDataBase.setHTQTY(seri.HTQTY);
	seriDataBase.setHTQTYC(seri.HTQTYC);
	seriDataBase.setHTUNIT(seri.HTUNIT);
	seriDataBase.setHTCTNR(seri.HTCTNR);
	seriDataBase.setHTLBLT(seri.HTLBLT);
	seriDataBase.setHTSRC(seri.HTSRC);
	seriDataBase.setHTMSTN(seri.HTMSTN);
	seriDataBase.setHTMSTS(seri.HTMSTS);
	seriDataBase.setHTSTKL(seri.HTSTKL);
	seriDataBase.setHTBINL(seri.HTBINL);
	seriDataBase.setHTSTS(seri.HTSTS);
	seriDataBase.setHTADAT(seri.HTADAT);
	seriDataBase.setHTGWGT(seri.HTGWGT);
	seriDataBase.setHTWUNT(seri.HTWUNT);
	seriDataBase.setHTTWGT(seri.HTTWGT);
	seriDataBase.setHTFUT1(seri.HTFUT1);
	seriDataBase.setHTFUT2(seri.HTFUT2);
	seriDataBase.setHTFUT3(seri.HTFUT3);
	seriDataBase.setHTFUT4(seri.HTFUT4);
	seriDataBase.setHTFUT5(seri.HTFUT5);
	seriDataBase.setHTFUT6(seri.HTFUT6);
	seriDataBase.setHTCORG(seri.HTCORG);
	seriDataBase.setHTPSRN(seri.HTPSRN);
	seriDataBase.setHTRCLF(seri.HTRCLF);
	seriDataBase.setHTPLNT(seri.HTPLNT);
	seriDataBase.setHTHDRF(seri.HTHDRF);
	seriDataBase.setHTHDRS(seri.HTHDRS);
	seriDataBase.setHTSTRN(seri.HTSTRN);
	seriDataBase.setHTSUPS(seri.HTSUPS);
	seriDataBase.setHTFUT7(seri.HTFUT7);
	seriDataBase.setHTFUT8(seri.HTFUT8);
	seriDataBase.setHTFUT9(seri.HTFUT9);
	seriDataBase.setHTFU10(seri.HTFU10);
	seriDataBase.setHTFU11(seri.HTFU11);
	seriDataBase.setHTFU12(seri.HTFU12);
	seriDataBase.setHTFU13(seri.HTFU13);
	seriDataBase.setHTFU14(seri.HTFU14);
	seriDataBase.setHTFU15(seri.HTFU15);
	seriDataBase.setHTFU16(seri.HTFU16);

	return seriDataBase;
}

public
Seri cloneSeri(Seri seri){
	Seri seriClone = new Seri();

	seriClone.HTSERN=seri.HTSERN;
	seriClone.HTPART=seri.HTPART;
	seriClone.HTLOTN=seri.HTLOTN;
	seriClone.HTSEQ=seri.HTSEQ;
	seriClone.HTJOBN=seri.HTJOBN;
	seriClone.HTQTY=seri.HTQTY;
	seriClone.HTQTYC=seri.HTQTYC;
	seriClone.HTUNIT=seri.HTUNIT;
	seriClone.HTCTNR=seri.HTCTNR;
	seriClone.HTLBLT=seri.HTLBLT;
	seriClone.HTSRC=seri.HTSRC;
	seriClone.HTMSTN=seri.HTMSTN;
	seriClone.HTMSTS=seri.HTMSTS;
	seriClone.HTSTKL=seri.HTSTKL;
	seriClone.HTBINL=seri.HTBINL;
	seriClone.HTSTS=seri.HTSTS;
	seriClone.HTADAT=seri.HTADAT;
	seriClone.HTGWGT=seri.HTGWGT;
	seriClone.HTWUNT=seri.HTWUNT;
	seriClone.HTTWGT=seri.HTTWGT;
	seriClone.HTFUT1=seri.HTFUT1;
	seriClone.HTFUT2=seri.HTFUT2;
	seriClone.HTFUT3=seri.HTFUT3;
	seriClone.HTFUT4=seri.HTFUT4;
	seriClone.HTFUT5=seri.HTFUT5;
	seriClone.HTFUT6=seri.HTFUT6;
	seriClone.HTCORG=seri.HTCORG;
	seriClone.HTPSRN=seri.HTPSRN;
	seriClone.HTRCLF=seri.HTRCLF;
	seriClone.HTPLNT=seri.HTPLNT;
	seriClone.HTHDRF=seri.HTHDRF;
	seriClone.HTHDRS=seri.HTHDRS;
	seriClone.HTSTRN=seri.HTSTRN;
	seriClone.HTSUPS=seri.HTSUPS;
	seriClone.HTFUT7=seri.HTFUT7;
	seriClone.HTFUT8=seri.HTFUT8;
	seriClone.HTFUT9=seri.HTFUT9;
	seriClone.HTFU10=seri.HTFU10;
	seriClone.HTFU11=seri.HTFU11;
	seriClone.HTFU12=seri.HTFU12;
	seriClone.HTFU13=seri.HTFU13;
	seriClone.HTFU14=seri.HTFU14;
	seriClone.HTFU15=seri.HTFU15;
	seriClone.HTFU16=seri.HTFU16;

	return seriClone;
}

public
SeriContainer lookForCmsSeris(string spart, DateTime dateTime, string statusList,string slot,string suppSerial){
    int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
    try {
        SeriContainer   seriContainer = new SeriContainer();        
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);        

        seriContainer = lookForCmsSerisInt(spart,"",dateTime, statusList,slot,suppSerial);

        return seriContainer;

    } catch (PersistenceException persistenceException) {
        throw new NujitException(persistenceException.Message, persistenceException);
    } catch (System.Exception exception) {
        throw new NujitException(exception.Message, exception);
    } finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

internal
SeriContainer lookForCmsSerisInt(string spart,string spartStart,DateTime dateTime, string statusList,string slot,string suppSerial){
    SeriContainer   seriContainer = new SeriContainer();
     
    SeriDataBaseContainer seriDataBaseContainer = new SeriDataBaseContainer(dataBaseAccess);
    seriDataBaseContainer.lookForCmsSeris(spart,spartStart,dateTime,statusList,slot,suppSerial);

    foreach (SeriDataBase seriDataBase in seriDataBaseContainer)
        seriContainer.Add(objectDataBaseToObject(seriDataBase));

    return seriContainer;
}
    
public
SeriContainer readSeriCMSByFilters(string spart, string serialNum, string slot, string suppSerial,string smasterSerial, string splant, string stockLoc, DateTime startActivDate, DateTime endActivDate, string statusList, bool bechEDI870, string stradingPartner, int rows){

    int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
    try{
        SeriContainer   seriContainer = new SeriContainer();        
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);        

        SeriDataBaseContainer seriDataBaseContainer = new SeriDataBaseContainer(dataBaseAccess);
        seriDataBaseContainer.readByFilters(spart,serialNum,slot,suppSerial,smasterSerial,splant,stockLoc,startActivDate,endActivDate,statusList,bechEDI870,stradingPartner,rows); 

        foreach(SeriDataBase seriDataBase in seriDataBaseContainer)
            seriContainer.Add(objectDataBaseToObject(seriDataBase)); 
        
        return seriContainer;

    } catch (PersistenceException persistenceException) {
        throw new NujitException(persistenceException.Message, persistenceException);
    } catch (System.Exception exception) {
        throw new NujitException(exception.Message, exception);
    } finally {        
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

/****************************************************** Stxh *****************************************************************/
public
Stxh createStxh(){
	return new Stxh();
}

public
StxhContainer createStxhContainer(){
	return new StxhContainer();
}


public
StxhContainer readStxhByFilters(decimal oYLOG,string oYTRPR,string oYDOCN,DateTime fromDate,DateTime toDate,int irows){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        StxhContainer  stxhContainer = new StxhContainer();

		StxhDataBaseContainer stxhDataBaseContainer = new StxhDataBaseContainer(dataBaseAccess);
        stxhDataBaseContainer.readByFilters(oYLOG,0,oYTRPR, oYDOCN, fromDate, toDate,"","","","","","",irows);

        foreach (StxhDataBase stxhDataBase in stxhDataBaseContainer)
            stxhContainer.Add(objectDataBaseToObject(stxhDataBase));
		
		return stxhContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally {                
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
ArrayList getStxhDifferentsTPartnerByFiltersDate(DateTime fromDate,DateTime toDate){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        ArrayList               array = new ArrayList();        
		StxhDataBaseContainer   stxhDataBaseContainer = new StxhDataBaseContainer(dataBaseAccess);
        array=stxhDataBaseContainer.getDifferentsTParnterByDate(fromDate,toDate);
        
		return array;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally {                
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
Stxh objectDataBaseToObject(StxhDataBase stxhDataBase){
	Stxh stxh = new Stxh();

	stxh.OYLOG=stxhDataBase.getOYLOG();
	stxh.OYENT=stxhDataBase.getOYENT();
	stxh.OYTRCD=stxhDataBase.getOYTRCD();
	stxh.OYTRPR=stxhDataBase.getOYTRPR();
	stxh.OYDOCN=stxhDataBase.getOYDOCN();
	stxh.OYEXCD=stxhDataBase.getOYEXCD();
	stxh.OYDCCL=stxhDataBase.getOYDCCL();
	stxh.OYMAPT=stxhDataBase.getOYMAPT();
	stxh.OYCDAT=stxhDataBase.getOYCDAT();
	stxh.OYCHRM=stxhDataBase.getOYCHRM();
	stxh.OYSTAT=stxhDataBase.getOYSTAT();
	stxh.OYTDAT=stxhDataBase.getOYTDAT();
	stxh.OYTHRM=stxhDataBase.getOYTHRM();
	stxh.OYNOTE=stxhDataBase.getOYNOTE();
	stxh.OYSUPL=stxhDataBase.getOYSUPL();
	stxh.OYDOCC=stxhDataBase.getOYDOCC();
	stxh.OYITYP=stxhDataBase.getOYITYP();
	stxh.OYFUT1=stxhDataBase.getOYFUT1();
	stxh.OYFUT2=stxhDataBase.getOYFUT2();
	stxh.OYFUT3=stxhDataBase.getOYFUT3();
	stxh.OYFUT4=stxhDataBase.getOYFUT4();
	stxh.OYFUT5=stxhDataBase.getOYFUT5();
	stxh.OYFUT6=stxhDataBase.getOYFUT6();
	stxh.OYFUT7=stxhDataBase.getOYFUT7();
	stxh.OYFUT8=stxhDataBase.getOYFUT8();
	stxh.OYFUT9=stxhDataBase.getOYFUT9();
	stxh.OYPLNT=stxhDataBase.getOYPLNT();
	stxh.OYMLBX=stxhDataBase.getOYMLBX();

	return stxh;
}

private
StxhDataBase objectToObjectDataBase(Stxh stxh){
	StxhDataBase stxhDataBase = new StxhDataBase(dataBaseAccess);
	stxhDataBase.setOYLOG(stxh.OYLOG);
	stxhDataBase.setOYENT(stxh.OYENT);
	stxhDataBase.setOYTRCD(stxh.OYTRCD);
	stxhDataBase.setOYTRPR(stxh.OYTRPR);
	stxhDataBase.setOYDOCN(stxh.OYDOCN);
	stxhDataBase.setOYEXCD(stxh.OYEXCD);
	stxhDataBase.setOYDCCL(stxh.OYDCCL);
	stxhDataBase.setOYMAPT(stxh.OYMAPT);
	stxhDataBase.setOYCDAT(stxh.OYCDAT);
	stxhDataBase.setOYCHRM(stxh.OYCHRM);
	stxhDataBase.setOYSTAT(stxh.OYSTAT);
	stxhDataBase.setOYTDAT(stxh.OYTDAT);
	stxhDataBase.setOYTHRM(stxh.OYTHRM);
	stxhDataBase.setOYNOTE(stxh.OYNOTE);
	stxhDataBase.setOYSUPL(stxh.OYSUPL);
	stxhDataBase.setOYDOCC(stxh.OYDOCC);
	stxhDataBase.setOYITYP(stxh.OYITYP);
	stxhDataBase.setOYFUT1(stxh.OYFUT1);
	stxhDataBase.setOYFUT2(stxh.OYFUT2);
	stxhDataBase.setOYFUT3(stxh.OYFUT3);
	stxhDataBase.setOYFUT4(stxh.OYFUT4);
	stxhDataBase.setOYFUT5(stxh.OYFUT5);
	stxhDataBase.setOYFUT6(stxh.OYFUT6);
	stxhDataBase.setOYFUT7(stxh.OYFUT7);
	stxhDataBase.setOYFUT8(stxh.OYFUT8);
	stxhDataBase.setOYFUT9(stxh.OYFUT9);
	stxhDataBase.setOYPLNT(stxh.OYPLNT);
	stxhDataBase.setOYMLBX(stxh.OYMLBX);

	return stxhDataBase;
}

public
Stxh cloneStxh(Stxh stxh){
	Stxh stxhClone = new Stxh();

	stxhClone.OYLOG=stxh.OYLOG;
	stxhClone.OYENT=stxh.OYENT;
	stxhClone.OYTRCD=stxh.OYTRCD;
	stxhClone.OYTRPR=stxh.OYTRPR;
	stxhClone.OYDOCN=stxh.OYDOCN;
	stxhClone.OYEXCD=stxh.OYEXCD;
	stxhClone.OYDCCL=stxh.OYDCCL;
	stxhClone.OYMAPT=stxh.OYMAPT;
	stxhClone.OYCDAT=stxh.OYCDAT;
	stxhClone.OYCHRM=stxh.OYCHRM;
	stxhClone.OYSTAT=stxh.OYSTAT;
	stxhClone.OYTDAT=stxh.OYTDAT;
	stxhClone.OYTHRM=stxh.OYTHRM;
	stxhClone.OYNOTE=stxh.OYNOTE;
	stxhClone.OYSUPL=stxh.OYSUPL;
	stxhClone.OYDOCC=stxh.OYDOCC;
	stxhClone.OYITYP=stxh.OYITYP;
	stxhClone.OYFUT1=stxh.OYFUT1;
	stxhClone.OYFUT2=stxh.OYFUT2;
	stxhClone.OYFUT3=stxh.OYFUT3;
	stxhClone.OYFUT4=stxh.OYFUT4;
	stxhClone.OYFUT5=stxh.OYFUT5;
	stxhClone.OYFUT6=stxh.OYFUT6;
	stxhClone.OYFUT7=stxh.OYFUT7;
	stxhClone.OYFUT8=stxh.OYFUT8;
	stxhClone.OYFUT9=stxh.OYFUT9;
	stxhClone.OYPLNT=stxh.OYPLNT;
	stxhClone.OYMLBX=stxh.OYMLBX;

	return stxhClone;
}

/**************************************************** *******************************************************************/
public
Rrldm createRrldm(){
	return new Rrldm();
}

public
RrldmContainer createRrldmContainer(){
	return new RrldmContainer();
}

protected
Rrldm objectDataBaseToObject(RrldmDataBase rrldmDataBase){
	Rrldm rrldm = new Rrldm();

	rrldm.BJ0KEYN=rrldmDataBase.getBJ0KEYN();
	rrldm.BJ0REL=rrldmDataBase.getBJ0REL();
	rrldm.BJ0RDAT=rrldmDataBase.getBJ0RDAT();
	rrldm.BJ0HHMM=rrldmDataBase.getBJ0HHMM();
	rrldm.BJ0TDAT=rrldmDataBase.getBJ0TDAT();
	rrldm.BJ0QCUM=rrldmDataBase.getBJ0QCUM();
	rrldm.BJ0QNET=rrldmDataBase.getBJ0QNET();
	rrldm.BJ0ADJN=rrldmDataBase.getBJ0ADJN();
	rrldm.BJ0AUTC=rrldmDataBase.getBJ0AUTC();
	rrldm.BJ0TIMC=rrldmDataBase.getBJ0TIMC();
	rrldm.BJ0ATYP=rrldmDataBase.getBJ0ATYP();
	rrldm.BJ0RAN=rrldmDataBase.getBJ0RAN();
	rrldm.BJ0USR1=rrldmDataBase.getBJ0USR1();
	rrldm.BJ0USR2=rrldmDataBase.getBJ0USR2();
	rrldm.BJ0USR3=rrldmDataBase.getBJ0USR3();
	rrldm.BJ0USR4=rrldmDataBase.getBJ0USR4();
	rrldm.BJ0FUT1=rrldmDataBase.getBJ0FUT1();
	rrldm.BJ0FUT2=rrldmDataBase.getBJ0FUT2();
	rrldm.BJ0FUT3=rrldmDataBase.getBJ0FUT3();
	rrldm.BJ0FUT4=rrldmDataBase.getBJ0FUT4();
	rrldm.BJ0FUT5=rrldmDataBase.getBJ0FUT5();
	rrldm.BJ0FUT6=rrldmDataBase.getBJ0FUT6();
	rrldm.BJ0FLG1=rrldmDataBase.getBJ0FLG1();
	rrldm.BJ0FLG2=rrldmDataBase.getBJ0FLG2();
	rrldm.BJ0FLG3=rrldmDataBase.getBJ0FLG3();
	rrldm.BJ0FLG4=rrldmDataBase.getBJ0FLG4();
	rrldm.BJ0FLG5=rrldmDataBase.getBJ0FLG5();
	rrldm.BJ0FUT7=rrldmDataBase.getBJ0FUT7();
	rrldm.BJ0FUT8=rrldmDataBase.getBJ0FUT8();
	rrldm.BJ0FUT9=rrldmDataBase.getBJ0FUT9();
	rrldm.BJ0FUTA=rrldmDataBase.getBJ0FUTA();
	rrldm.BJ0FUTB=rrldmDataBase.getBJ0FUTB();
	rrldm.BJ0FUTC=rrldmDataBase.getBJ0FUTC();
	rrldm.BJ0FUTD=rrldmDataBase.getBJ0FUTD();
	rrldm.BJ0FUTE=rrldmDataBase.getBJ0FUTE();
	rrldm.BJ0FUTF=rrldmDataBase.getBJ0FUTF();
	rrldm.BJ0FUTG=rrldmDataBase.getBJ0FUTG();
	rrldm.BJ0FUTH=rrldmDataBase.getBJ0FUTH();
	rrldm.BJ0FUTI=rrldmDataBase.getBJ0FUTI();
	rrldm.BJ0FUTJ=rrldmDataBase.getBJ0FUTJ();
	rrldm.BJ0FUTK=rrldmDataBase.getBJ0FUTK();
	rrldm.BJ0USR5=rrldmDataBase.getBJ0USR5();
	rrldm.BJ0USRF=rrldmDataBase.getBJ0USRF();
	rrldm.BJ0USRG=rrldmDataBase.getBJ0USRG();
	rrldm.BJ0USRH=rrldmDataBase.getBJ0USRH();
	rrldm.BJ0USRI=rrldmDataBase.getBJ0USRI();
	rrldm.BJ0USRJ=rrldmDataBase.getBJ0USRJ();
	rrldm.BJ0USRK=rrldmDataBase.getBJ0USRK();
	rrldm.BJ0USRL=rrldmDataBase.getBJ0USRL();
	rrldm.BJ0USRM=rrldmDataBase.getBJ0USRM();
	rrldm.BJ0USRN=rrldmDataBase.getBJ0USRN();
	rrldm.BJ0TMZN=rrldmDataBase.getBJ0TMZN();
	rrldm.BJ0CHDT=rrldmDataBase.getBJ0CHDT();
	rrldm.BJ0CHTM=rrldmDataBase.getBJ0CHTM();
	rrldm.BJ0DTTM=rrldmDataBase.getBJ0DTTM();
	rrldm.BJ0USID=rrldmDataBase.getBJ0USID();
	rrldm.BJ0ITYP=rrldmDataBase.getBJ0ITYP();
	rrldm.BJ0OPCD=rrldmDataBase.getBJ0OPCD();

	return rrldm;
}

protected
RrldmDataBase objectToObjectDataBase(Rrldm rrldm){
	RrldmDataBase rrldmDataBase = new RrldmDataBase(dataBaseAccess);
	rrldmDataBase.setBJ0KEYN(rrldm.BJ0KEYN);
	rrldmDataBase.setBJ0REL(rrldm.BJ0REL);
	rrldmDataBase.setBJ0RDAT(rrldm.BJ0RDAT);
	rrldmDataBase.setBJ0HHMM(rrldm.BJ0HHMM);
	rrldmDataBase.setBJ0TDAT(rrldm.BJ0TDAT);
	rrldmDataBase.setBJ0QCUM(rrldm.BJ0QCUM);
	rrldmDataBase.setBJ0QNET(rrldm.BJ0QNET);
	rrldmDataBase.setBJ0ADJN(rrldm.BJ0ADJN);
	rrldmDataBase.setBJ0AUTC(rrldm.BJ0AUTC);
	rrldmDataBase.setBJ0TIMC(rrldm.BJ0TIMC);
	rrldmDataBase.setBJ0ATYP(rrldm.BJ0ATYP);
	rrldmDataBase.setBJ0RAN(rrldm.BJ0RAN);
	rrldmDataBase.setBJ0USR1(rrldm.BJ0USR1);
	rrldmDataBase.setBJ0USR2(rrldm.BJ0USR2);
	rrldmDataBase.setBJ0USR3(rrldm.BJ0USR3);
	rrldmDataBase.setBJ0USR4(rrldm.BJ0USR4);
	rrldmDataBase.setBJ0FUT1(rrldm.BJ0FUT1);
	rrldmDataBase.setBJ0FUT2(rrldm.BJ0FUT2);
	rrldmDataBase.setBJ0FUT3(rrldm.BJ0FUT3);
	rrldmDataBase.setBJ0FUT4(rrldm.BJ0FUT4);
	rrldmDataBase.setBJ0FUT5(rrldm.BJ0FUT5);
	rrldmDataBase.setBJ0FUT6(rrldm.BJ0FUT6);
	rrldmDataBase.setBJ0FLG1(rrldm.BJ0FLG1);
	rrldmDataBase.setBJ0FLG2(rrldm.BJ0FLG2);
	rrldmDataBase.setBJ0FLG3(rrldm.BJ0FLG3);
	rrldmDataBase.setBJ0FLG4(rrldm.BJ0FLG4);
	rrldmDataBase.setBJ0FLG5(rrldm.BJ0FLG5);
	rrldmDataBase.setBJ0FUT7(rrldm.BJ0FUT7);
	rrldmDataBase.setBJ0FUT8(rrldm.BJ0FUT8);
	rrldmDataBase.setBJ0FUT9(rrldm.BJ0FUT9);
	rrldmDataBase.setBJ0FUTA(rrldm.BJ0FUTA);
	rrldmDataBase.setBJ0FUTB(rrldm.BJ0FUTB);
	rrldmDataBase.setBJ0FUTC(rrldm.BJ0FUTC);
	rrldmDataBase.setBJ0FUTD(rrldm.BJ0FUTD);
	rrldmDataBase.setBJ0FUTE(rrldm.BJ0FUTE);
	rrldmDataBase.setBJ0FUTF(rrldm.BJ0FUTF);
	rrldmDataBase.setBJ0FUTG(rrldm.BJ0FUTG);
	rrldmDataBase.setBJ0FUTH(rrldm.BJ0FUTH);
	rrldmDataBase.setBJ0FUTI(rrldm.BJ0FUTI);
	rrldmDataBase.setBJ0FUTJ(rrldm.BJ0FUTJ);
	rrldmDataBase.setBJ0FUTK(rrldm.BJ0FUTK);
	rrldmDataBase.setBJ0USR5(rrldm.BJ0USR5);
	rrldmDataBase.setBJ0USRF(rrldm.BJ0USRF);
	rrldmDataBase.setBJ0USRG(rrldm.BJ0USRG);
	rrldmDataBase.setBJ0USRH(rrldm.BJ0USRH);
	rrldmDataBase.setBJ0USRI(rrldm.BJ0USRI);
	rrldmDataBase.setBJ0USRJ(rrldm.BJ0USRJ);
	rrldmDataBase.setBJ0USRK(rrldm.BJ0USRK);
	rrldmDataBase.setBJ0USRL(rrldm.BJ0USRL);
	rrldmDataBase.setBJ0USRM(rrldm.BJ0USRM);
	rrldmDataBase.setBJ0USRN(rrldm.BJ0USRN);
	rrldmDataBase.setBJ0TMZN(rrldm.BJ0TMZN);
	rrldmDataBase.setBJ0CHDT(rrldm.BJ0CHDT);
	rrldmDataBase.setBJ0CHTM(rrldm.BJ0CHTM);
	rrldmDataBase.setBJ0DTTM(rrldm.BJ0DTTM);
	rrldmDataBase.setBJ0USID(rrldm.BJ0USID);
	rrldmDataBase.setBJ0ITYP(rrldm.BJ0ITYP);
	rrldmDataBase.setBJ0OPCD(rrldm.BJ0OPCD);

	return rrldmDataBase;
}

public
Rrldm cloneRrldm(Rrldm rrldm){
	Rrldm rrldmClone = new Rrldm();

	rrldmClone.BJ0KEYN=rrldm.BJ0KEYN;
	rrldmClone.BJ0REL=rrldm.BJ0REL;
	rrldmClone.BJ0RDAT=rrldm.BJ0RDAT;
	rrldmClone.BJ0HHMM=rrldm.BJ0HHMM;
	rrldmClone.BJ0TDAT=rrldm.BJ0TDAT;
	rrldmClone.BJ0QCUM=rrldm.BJ0QCUM;
	rrldmClone.BJ0QNET=rrldm.BJ0QNET;
	rrldmClone.BJ0ADJN=rrldm.BJ0ADJN;
	rrldmClone.BJ0AUTC=rrldm.BJ0AUTC;
	rrldmClone.BJ0TIMC=rrldm.BJ0TIMC;
	rrldmClone.BJ0ATYP=rrldm.BJ0ATYP;
	rrldmClone.BJ0RAN=rrldm.BJ0RAN;
	rrldmClone.BJ0USR1=rrldm.BJ0USR1;
	rrldmClone.BJ0USR2=rrldm.BJ0USR2;
	rrldmClone.BJ0USR3=rrldm.BJ0USR3;
	rrldmClone.BJ0USR4=rrldm.BJ0USR4;
	rrldmClone.BJ0FUT1=rrldm.BJ0FUT1;
	rrldmClone.BJ0FUT2=rrldm.BJ0FUT2;
	rrldmClone.BJ0FUT3=rrldm.BJ0FUT3;
	rrldmClone.BJ0FUT4=rrldm.BJ0FUT4;
	rrldmClone.BJ0FUT5=rrldm.BJ0FUT5;
	rrldmClone.BJ0FUT6=rrldm.BJ0FUT6;
	rrldmClone.BJ0FLG1=rrldm.BJ0FLG1;
	rrldmClone.BJ0FLG2=rrldm.BJ0FLG2;
	rrldmClone.BJ0FLG3=rrldm.BJ0FLG3;
	rrldmClone.BJ0FLG4=rrldm.BJ0FLG4;
	rrldmClone.BJ0FLG5=rrldm.BJ0FLG5;
	rrldmClone.BJ0FUT7=rrldm.BJ0FUT7;
	rrldmClone.BJ0FUT8=rrldm.BJ0FUT8;
	rrldmClone.BJ0FUT9=rrldm.BJ0FUT9;
	rrldmClone.BJ0FUTA=rrldm.BJ0FUTA;
	rrldmClone.BJ0FUTB=rrldm.BJ0FUTB;
	rrldmClone.BJ0FUTC=rrldm.BJ0FUTC;
	rrldmClone.BJ0FUTD=rrldm.BJ0FUTD;
	rrldmClone.BJ0FUTE=rrldm.BJ0FUTE;
	rrldmClone.BJ0FUTF=rrldm.BJ0FUTF;
	rrldmClone.BJ0FUTG=rrldm.BJ0FUTG;
	rrldmClone.BJ0FUTH=rrldm.BJ0FUTH;
	rrldmClone.BJ0FUTI=rrldm.BJ0FUTI;
	rrldmClone.BJ0FUTJ=rrldm.BJ0FUTJ;
	rrldmClone.BJ0FUTK=rrldm.BJ0FUTK;
	rrldmClone.BJ0USR5=rrldm.BJ0USR5;
	rrldmClone.BJ0USRF=rrldm.BJ0USRF;
	rrldmClone.BJ0USRG=rrldm.BJ0USRG;
	rrldmClone.BJ0USRH=rrldm.BJ0USRH;
	rrldmClone.BJ0USRI=rrldm.BJ0USRI;
	rrldmClone.BJ0USRJ=rrldm.BJ0USRJ;
	rrldmClone.BJ0USRK=rrldm.BJ0USRK;
	rrldmClone.BJ0USRL=rrldm.BJ0USRL;
	rrldmClone.BJ0USRM=rrldm.BJ0USRM;
	rrldmClone.BJ0USRN=rrldm.BJ0USRN;
	rrldmClone.BJ0TMZN=rrldm.BJ0TMZN;
	rrldmClone.BJ0CHDT=rrldm.BJ0CHDT;
	rrldmClone.BJ0CHTM=rrldm.BJ0CHTM;
	rrldmClone.BJ0DTTM=rrldm.BJ0DTTM;
	rrldmClone.BJ0USID=rrldm.BJ0USID;
	rrldmClone.BJ0ITYP=rrldm.BJ0ITYP;
	rrldmClone.BJ0OPCD=rrldm.BJ0OPCD;

	return rrldmClone;
}

/***************************************************** Jitdm ************************************************************************/
public
Jitdm createJitdm(){
	return new Jitdm();
}

public
JitdmContainer createJitdmContainer(){
	return new JitdmContainer();
}

public
Jitdm objectDataBaseToObject(JitdmDataBase jitdmDataBase){
	Jitdm jitdm = new Jitdm();

	jitdm.BJ1KEYN=jitdmDataBase.getBJ1KEYN();
	jitdm.BJ1REF=jitdmDataBase.getBJ1REF();
	jitdm.BJ1DATE=jitdmDataBase.getBJ1DATE();
	jitdm.BJ1HM=jitdmDataBase.getBJ1HM();
	jitdm.BJ1EDAT=jitdmDataBase.getBJ1EDAT();
	jitdm.BJ1QTY=jitdmDataBase.getBJ1QTY();
	jitdm.BJ1QCUM=jitdmDataBase.getBJ1QCUM();
	jitdm.BJ1NQTY=jitdmDataBase.getBJ1NQTY();
	jitdm.BJ1SRC=jitdmDataBase.getBJ1SRC();
	jitdm.BJ1LOG=jitdmDataBase.getBJ1LOG();
	jitdm.BJ1ENT=jitdmDataBase.getBJ1ENT();
	jitdm.BJ1BOL=jitdmDataBase.getBJ1BOL();
	jitdm.BJ1BLIN=jitdmDataBase.getBJ1BLIN();
	jitdm.BJ1RAN=jitdmDataBase.getBJ1RAN();
	jitdm.BJ1REF1=jitdmDataBase.getBJ1REF1();
	jitdm.BJ1REF2=jitdmDataBase.getBJ1REF2();
	jitdm.BJ1STAT=jitdmDataBase.getBJ1STAT();
	jitdm.BJ1KEY=jitdmDataBase.getBJ1KEY();
	jitdm.BJ1KBPR=jitdmDataBase.getBJ1KBPR();
	jitdm.BJ1KBST=jitdmDataBase.getBJ1KBST();
	jitdm.BJ1KBEN=jitdmDataBase.getBJ1KBEN();
	jitdm.BJ1SHPP=jitdmDataBase.getBJ1SHPP();
	jitdm.BJ1SHPT=jitdmDataBase.getBJ1SHPT();
	jitdm.BJ1TYPE=jitdmDataBase.getBJ1TYPE();
	jitdm.BJ1TIMT=jitdmDataBase.getBJ1TIMT();
	jitdm.BJ1TIMC=jitdmDataBase.getBJ1TIMC();
	jitdm.BJ1RTEG=jitdmDataBase.getBJ1RTEG();
	jitdm.BJ1SVCC=jitdmDataBase.getBJ1SVCC();
	jitdm.BJ1MODE=jitdmDataBase.getBJ1MODE();
	jitdm.BJ1USR1=jitdmDataBase.getBJ1USR1();
	jitdm.BJ1USR2=jitdmDataBase.getBJ1USR2();
	jitdm.BJ1USR3=jitdmDataBase.getBJ1USR3();
	jitdm.BJ1USR4=jitdmDataBase.getBJ1USR4();
	jitdm.BJ1FUT1=jitdmDataBase.getBJ1FUT1();
	jitdm.BJ1FUT2=jitdmDataBase.getBJ1FUT2();
	jitdm.BJ1FUT3=jitdmDataBase.getBJ1FUT3();
	jitdm.BJ1FUT4=jitdmDataBase.getBJ1FUT4();
	jitdm.BJ1FUT5=jitdmDataBase.getBJ1FUT5();
	jitdm.BJ1FUT6=jitdmDataBase.getBJ1FUT6();
	jitdm.BJ1FUT7=jitdmDataBase.getBJ1FUT7();
	jitdm.BJ1FUT8=jitdmDataBase.getBJ1FUT8();
	jitdm.BJ1FUTA=jitdmDataBase.getBJ1FUTA();
	jitdm.BJ1FUTB=jitdmDataBase.getBJ1FUTB();
	jitdm.BJ1FUTC=jitdmDataBase.getBJ1FUTC();
	jitdm.BJ1FUTD=jitdmDataBase.getBJ1FUTD();
	jitdm.BJ1FUTE=jitdmDataBase.getBJ1FUTE();
	jitdm.BJ1FUTF=jitdmDataBase.getBJ1FUTF();
	jitdm.BJ1FUTG=jitdmDataBase.getBJ1FUTG();
	jitdm.BJ1FUTH=jitdmDataBase.getBJ1FUTH();
	jitdm.BJ1FUTI=jitdmDataBase.getBJ1FUTI();
	jitdm.BJ1FUTJ=jitdmDataBase.getBJ1FUTJ();
	jitdm.BJ1FUTK=jitdmDataBase.getBJ1FUTK();
	jitdm.BJ1FUTL=jitdmDataBase.getBJ1FUTL();
	jitdm.BJ1FUTM=jitdmDataBase.getBJ1FUTM();
	jitdm.BJ1FUTN=jitdmDataBase.getBJ1FUTN();
	jitdm.BJ1FUTO=jitdmDataBase.getBJ1FUTO();
	jitdm.BJ1FUTP=jitdmDataBase.getBJ1FUTP();
	jitdm.BJ1FUTQ=jitdmDataBase.getBJ1FUTQ();
	jitdm.BJ1FUTR=jitdmDataBase.getBJ1FUTR();
	jitdm.BJ1FUTS=jitdmDataBase.getBJ1FUTS();
	jitdm.BJ1FUTT=jitdmDataBase.getBJ1FUTT();
	jitdm.BJ1FUTU=jitdmDataBase.getBJ1FUTU();
	jitdm.BJ1FLG1=jitdmDataBase.getBJ1FLG1();
	jitdm.BJ1FLG2=jitdmDataBase.getBJ1FLG2();
	jitdm.BJ1FLG3=jitdmDataBase.getBJ1FLG3();
	jitdm.BJ1FLG4=jitdmDataBase.getBJ1FLG4();
	jitdm.BJ1JITS=jitdmDataBase.getBJ1JITS();
	jitdm.BJ1TMZN=jitdmDataBase.getBJ1TMZN();
	jitdm.BJ1CHDT=jitdmDataBase.getBJ1CHDT();
	jitdm.BJ1CHTM=jitdmDataBase.getBJ1CHTM();
	jitdm.BJ1DTTM=jitdmDataBase.getBJ1DTTM();
	jitdm.BJ1USID=jitdmDataBase.getBJ1USID();
	jitdm.BJ1ITYP=jitdmDataBase.getBJ1ITYP();
	jitdm.BJ1OPCD=jitdmDataBase.getBJ1OPCD();

	return jitdm;
}

public
JitdmDataBase objectToObjectDataBase(Jitdm jitdm){
	JitdmDataBase jitdmDataBase = new JitdmDataBase(dataBaseAccess);
	jitdmDataBase.setBJ1KEYN(jitdm.BJ1KEYN);
	jitdmDataBase.setBJ1REF(jitdm.BJ1REF);
	jitdmDataBase.setBJ1DATE(jitdm.BJ1DATE);
	jitdmDataBase.setBJ1HM(jitdm.BJ1HM);
	jitdmDataBase.setBJ1EDAT(jitdm.BJ1EDAT);
	jitdmDataBase.setBJ1QTY(jitdm.BJ1QTY);
	jitdmDataBase.setBJ1QCUM(jitdm.BJ1QCUM);
	jitdmDataBase.setBJ1NQTY(jitdm.BJ1NQTY);
	jitdmDataBase.setBJ1SRC(jitdm.BJ1SRC);
	jitdmDataBase.setBJ1LOG(jitdm.BJ1LOG);
	jitdmDataBase.setBJ1ENT(jitdm.BJ1ENT);
	jitdmDataBase.setBJ1BOL(jitdm.BJ1BOL);
	jitdmDataBase.setBJ1BLIN(jitdm.BJ1BLIN);
	jitdmDataBase.setBJ1RAN(jitdm.BJ1RAN);
	jitdmDataBase.setBJ1REF1(jitdm.BJ1REF1);
	jitdmDataBase.setBJ1REF2(jitdm.BJ1REF2);
	jitdmDataBase.setBJ1STAT(jitdm.BJ1STAT);
	jitdmDataBase.setBJ1KEY(jitdm.BJ1KEY);
	jitdmDataBase.setBJ1KBPR(jitdm.BJ1KBPR);
	jitdmDataBase.setBJ1KBST(jitdm.BJ1KBST);
	jitdmDataBase.setBJ1KBEN(jitdm.BJ1KBEN);
	jitdmDataBase.setBJ1SHPP(jitdm.BJ1SHPP);
	jitdmDataBase.setBJ1SHPT(jitdm.BJ1SHPT);
	jitdmDataBase.setBJ1TYPE(jitdm.BJ1TYPE);
	jitdmDataBase.setBJ1TIMT(jitdm.BJ1TIMT);
	jitdmDataBase.setBJ1TIMC(jitdm.BJ1TIMC);
	jitdmDataBase.setBJ1RTEG(jitdm.BJ1RTEG);
	jitdmDataBase.setBJ1SVCC(jitdm.BJ1SVCC);
	jitdmDataBase.setBJ1MODE(jitdm.BJ1MODE);
	jitdmDataBase.setBJ1USR1(jitdm.BJ1USR1);
	jitdmDataBase.setBJ1USR2(jitdm.BJ1USR2);
	jitdmDataBase.setBJ1USR3(jitdm.BJ1USR3);
	jitdmDataBase.setBJ1USR4(jitdm.BJ1USR4);
	jitdmDataBase.setBJ1FUT1(jitdm.BJ1FUT1);
	jitdmDataBase.setBJ1FUT2(jitdm.BJ1FUT2);
	jitdmDataBase.setBJ1FUT3(jitdm.BJ1FUT3);
	jitdmDataBase.setBJ1FUT4(jitdm.BJ1FUT4);
	jitdmDataBase.setBJ1FUT5(jitdm.BJ1FUT5);
	jitdmDataBase.setBJ1FUT6(jitdm.BJ1FUT6);
	jitdmDataBase.setBJ1FUT7(jitdm.BJ1FUT7);
	jitdmDataBase.setBJ1FUT8(jitdm.BJ1FUT8);
	jitdmDataBase.setBJ1FUTA(jitdm.BJ1FUTA);
	jitdmDataBase.setBJ1FUTB(jitdm.BJ1FUTB);
	jitdmDataBase.setBJ1FUTC(jitdm.BJ1FUTC);
	jitdmDataBase.setBJ1FUTD(jitdm.BJ1FUTD);
	jitdmDataBase.setBJ1FUTE(jitdm.BJ1FUTE);
	jitdmDataBase.setBJ1FUTF(jitdm.BJ1FUTF);
	jitdmDataBase.setBJ1FUTG(jitdm.BJ1FUTG);
	jitdmDataBase.setBJ1FUTH(jitdm.BJ1FUTH);
	jitdmDataBase.setBJ1FUTI(jitdm.BJ1FUTI);
	jitdmDataBase.setBJ1FUTJ(jitdm.BJ1FUTJ);
	jitdmDataBase.setBJ1FUTK(jitdm.BJ1FUTK);
	jitdmDataBase.setBJ1FUTL(jitdm.BJ1FUTL);
	jitdmDataBase.setBJ1FUTM(jitdm.BJ1FUTM);
	jitdmDataBase.setBJ1FUTN(jitdm.BJ1FUTN);
	jitdmDataBase.setBJ1FUTO(jitdm.BJ1FUTO);
	jitdmDataBase.setBJ1FUTP(jitdm.BJ1FUTP);
	jitdmDataBase.setBJ1FUTQ(jitdm.BJ1FUTQ);
	jitdmDataBase.setBJ1FUTR(jitdm.BJ1FUTR);
	jitdmDataBase.setBJ1FUTS(jitdm.BJ1FUTS);
	jitdmDataBase.setBJ1FUTT(jitdm.BJ1FUTT);
	jitdmDataBase.setBJ1FUTU(jitdm.BJ1FUTU);
	jitdmDataBase.setBJ1FLG1(jitdm.BJ1FLG1);
	jitdmDataBase.setBJ1FLG2(jitdm.BJ1FLG2);
	jitdmDataBase.setBJ1FLG3(jitdm.BJ1FLG3);
	jitdmDataBase.setBJ1FLG4(jitdm.BJ1FLG4);
	jitdmDataBase.setBJ1JITS(jitdm.BJ1JITS);
	jitdmDataBase.setBJ1TMZN(jitdm.BJ1TMZN);
	jitdmDataBase.setBJ1CHDT(jitdm.BJ1CHDT);
	jitdmDataBase.setBJ1CHTM(jitdm.BJ1CHTM);
	jitdmDataBase.setBJ1DTTM(jitdm.BJ1DTTM);
	jitdmDataBase.setBJ1USID(jitdm.BJ1USID);
	jitdmDataBase.setBJ1ITYP(jitdm.BJ1ITYP);
	jitdmDataBase.setBJ1OPCD(jitdm.BJ1OPCD);

	return jitdmDataBase;
}

public
Jitdm cloneJitdm(Jitdm jitdm){
	Jitdm jitdmClone = new Jitdm();

	jitdmClone.BJ1KEYN=jitdm.BJ1KEYN;
	jitdmClone.BJ1REF=jitdm.BJ1REF;
	jitdmClone.BJ1DATE=jitdm.BJ1DATE;
	jitdmClone.BJ1HM=jitdm.BJ1HM;
	jitdmClone.BJ1EDAT=jitdm.BJ1EDAT;
	jitdmClone.BJ1QTY=jitdm.BJ1QTY;
	jitdmClone.BJ1QCUM=jitdm.BJ1QCUM;
	jitdmClone.BJ1NQTY=jitdm.BJ1NQTY;
	jitdmClone.BJ1SRC=jitdm.BJ1SRC;
	jitdmClone.BJ1LOG=jitdm.BJ1LOG;
	jitdmClone.BJ1ENT=jitdm.BJ1ENT;
	jitdmClone.BJ1BOL=jitdm.BJ1BOL;
	jitdmClone.BJ1BLIN=jitdm.BJ1BLIN;
	jitdmClone.BJ1RAN=jitdm.BJ1RAN;
	jitdmClone.BJ1REF1=jitdm.BJ1REF1;
	jitdmClone.BJ1REF2=jitdm.BJ1REF2;
	jitdmClone.BJ1STAT=jitdm.BJ1STAT;
	jitdmClone.BJ1KEY=jitdm.BJ1KEY;
	jitdmClone.BJ1KBPR=jitdm.BJ1KBPR;
	jitdmClone.BJ1KBST=jitdm.BJ1KBST;
	jitdmClone.BJ1KBEN=jitdm.BJ1KBEN;
	jitdmClone.BJ1SHPP=jitdm.BJ1SHPP;
	jitdmClone.BJ1SHPT=jitdm.BJ1SHPT;
	jitdmClone.BJ1TYPE=jitdm.BJ1TYPE;
	jitdmClone.BJ1TIMT=jitdm.BJ1TIMT;
	jitdmClone.BJ1TIMC=jitdm.BJ1TIMC;
	jitdmClone.BJ1RTEG=jitdm.BJ1RTEG;
	jitdmClone.BJ1SVCC=jitdm.BJ1SVCC;
	jitdmClone.BJ1MODE=jitdm.BJ1MODE;
	jitdmClone.BJ1USR1=jitdm.BJ1USR1;
	jitdmClone.BJ1USR2=jitdm.BJ1USR2;
	jitdmClone.BJ1USR3=jitdm.BJ1USR3;
	jitdmClone.BJ1USR4=jitdm.BJ1USR4;
	jitdmClone.BJ1FUT1=jitdm.BJ1FUT1;
	jitdmClone.BJ1FUT2=jitdm.BJ1FUT2;
	jitdmClone.BJ1FUT3=jitdm.BJ1FUT3;
	jitdmClone.BJ1FUT4=jitdm.BJ1FUT4;
	jitdmClone.BJ1FUT5=jitdm.BJ1FUT5;
	jitdmClone.BJ1FUT6=jitdm.BJ1FUT6;
	jitdmClone.BJ1FUT7=jitdm.BJ1FUT7;
	jitdmClone.BJ1FUT8=jitdm.BJ1FUT8;
	jitdmClone.BJ1FUTA=jitdm.BJ1FUTA;
	jitdmClone.BJ1FUTB=jitdm.BJ1FUTB;
	jitdmClone.BJ1FUTC=jitdm.BJ1FUTC;
	jitdmClone.BJ1FUTD=jitdm.BJ1FUTD;
	jitdmClone.BJ1FUTE=jitdm.BJ1FUTE;
	jitdmClone.BJ1FUTF=jitdm.BJ1FUTF;
	jitdmClone.BJ1FUTG=jitdm.BJ1FUTG;
	jitdmClone.BJ1FUTH=jitdm.BJ1FUTH;
	jitdmClone.BJ1FUTI=jitdm.BJ1FUTI;
	jitdmClone.BJ1FUTJ=jitdm.BJ1FUTJ;
	jitdmClone.BJ1FUTK=jitdm.BJ1FUTK;
	jitdmClone.BJ1FUTL=jitdm.BJ1FUTL;
	jitdmClone.BJ1FUTM=jitdm.BJ1FUTM;
	jitdmClone.BJ1FUTN=jitdm.BJ1FUTN;
	jitdmClone.BJ1FUTO=jitdm.BJ1FUTO;
	jitdmClone.BJ1FUTP=jitdm.BJ1FUTP;
	jitdmClone.BJ1FUTQ=jitdm.BJ1FUTQ;
	jitdmClone.BJ1FUTR=jitdm.BJ1FUTR;
	jitdmClone.BJ1FUTS=jitdm.BJ1FUTS;
	jitdmClone.BJ1FUTT=jitdm.BJ1FUTT;
	jitdmClone.BJ1FUTU=jitdm.BJ1FUTU;
	jitdmClone.BJ1FLG1=jitdm.BJ1FLG1;
	jitdmClone.BJ1FLG2=jitdm.BJ1FLG2;
	jitdmClone.BJ1FLG3=jitdm.BJ1FLG3;
	jitdmClone.BJ1FLG4=jitdm.BJ1FLG4;
	jitdmClone.BJ1JITS=jitdm.BJ1JITS;
	jitdmClone.BJ1TMZN=jitdm.BJ1TMZN;
	jitdmClone.BJ1CHDT=jitdm.BJ1CHDT;
	jitdmClone.BJ1CHTM=jitdm.BJ1CHTM;
	jitdmClone.BJ1DTTM=jitdm.BJ1DTTM;
	jitdmClone.BJ1USID=jitdm.BJ1USID;
	jitdmClone.BJ1ITYP=jitdm.BJ1ITYP;
	jitdmClone.BJ1OPCD=jitdm.BJ1OPCD;

	return jitdmClone;
}


/********************************************* trlp ***********************************************************************/
public
ArrayList readTrlpTradingPartners(string splant,string source){
    try { 
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        TrlpDataBaseContainer   trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);    
        ArrayList               array = trlpDataBaseContainer.readDistinctTradingPartners(splant,source);
    
        return array;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
ArrayList readTrlpShipLocs(string stpartner){
    try { 
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        TrlpDataBaseContainer   trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);
        ArrayList               array = trlpDataBaseContainer.readDistinctShipLoc(stpartner);
    
        return array;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
ArrayList readTrlpPartsByFilters(string stpartner,string shipLoc){
    try { 
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        TrlpDataBaseContainer   trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);
        ArrayList               array = trlpDataBaseContainer.readDistinctParts(stpartner,shipLoc);
    
        return array;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}


} // class
} // namespace