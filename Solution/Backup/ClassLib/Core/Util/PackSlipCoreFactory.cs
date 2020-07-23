/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 23/03/2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/Util/PackSlipCoreFactory.cs,v $ 
*   $State: Exp $ 
*   $Log: PackSlipCoreFactory.cs,v $
*   Revision 1.6  2005-05-17 04:34:51  gmuller
*   ponga aqui un comentario
*
*   Revision 1.5  2005/04/06 20:32:24  fnicolet
*   *** empty log message ***
*
*   Revision 1.4  2005/04/05 20:25:25  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/03/29 04:06:50  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/03/23 20:09:23  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/23 20:00:19  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{

public
class PackSlipCoreFactory : OrderCoreFactory {

protected
PackSlipCoreFactory() : base(){
}


//----------------------------------- OePSHdr ---------------------------------------------------------------
public
bool existsPackSlip (string db, int company, string plant, int packSlipNum){

	try{
		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);

		oePSHdrDataBase.setP_Db(db);
		oePSHdrDataBase.setP_Company(company);
		oePSHdrDataBase.setP_Plant(plant);
		oePSHdrDataBase.setP_PackSlipNum(packSlipNum);

		return oePSHdrDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PackSlip readPackSlip (string db, int company, string plant, int packSlipNum){

	try{
		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);

		oePSHdrDataBase.setP_Db(db);
		oePSHdrDataBase.setP_Company(company);
		oePSHdrDataBase.setP_Plant(plant);
		oePSHdrDataBase.setP_PackSlipNum(packSlipNum);

		if (!oePSHdrDataBase.exists())
			return null;

		oePSHdrDataBase.read();

		PackSlip packSlip = this.objectDataBaseToObject(oePSHdrDataBase);

		return packSlip;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updatePackSlip(PackSlip packSlip){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OePSHdrDataBase oePSHdrDataBase = this.objectToObjectDataBase(packSlip);

		oePSHdrDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writePackSlip (PackSlip packSlip){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OePSHdrDataBase oePSHdrDataBase = this.objectToObjectDataBase(packSlip);

		oePSHdrDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deletePackSlip (string db, int company, string plant, int packSlipNum){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);

		oePSHdrDataBase.setP_Db(db);
		oePSHdrDataBase.setP_Company(company);
		oePSHdrDataBase.setP_Plant(plant);
		oePSHdrDataBase.setP_PackSlipNum(packSlipNum);

		oePSHdrDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
PackSlip objectDataBaseToObject (OePSHdrDataBase oePSHdrDataBase){

	PackSlip packSlip = new PackSlip();

	packSlip.setID(oePSHdrDataBase.getP_ID());
	packSlip.setDb(oePSHdrDataBase.getP_Db());
	packSlip.setCompany(oePSHdrDataBase.getP_Company());
	packSlip.setPlant(oePSHdrDataBase.getP_Plant());
	packSlip.setPackSlipNum(oePSHdrDataBase.getP_PackSlipNum());
	packSlip.setPackSlipType(oePSHdrDataBase.getP_PackSlipType());
	packSlip.setDateCrt(oePSHdrDataBase.getP_DateCrt());
	packSlip.setPrintInd(oePSHdrDataBase.getP_PrintInd());
	packSlip.setShipInd(oePSHdrDataBase.getP_ShipInd());
	packSlip.setBillToCust(oePSHdrDataBase.getP_BillToCust());
	packSlip.setShipToCust(oePSHdrDataBase.getP_ShipToCust());
	packSlip.setBillToName(oePSHdrDataBase.getP_BillToName());
	packSlip.setShipToName(oePSHdrDataBase.getP_ShipToName());
	packSlip.setBillToPost(oePSHdrDataBase.getP_BillToPost());
	packSlip.setAttention(oePSHdrDataBase.getP_Attention());
	packSlip.setShipDate(oePSHdrDataBase.getP_ShipDate());
	packSlip.setShipVia(oePSHdrDataBase.getP_ShipVia());
	packSlip.setOrderNum(oePSHdrDataBase.getP_OrderNum());
	packSlip.setStkLoc(oePSHdrDataBase.getP_StkLoc());
	packSlip.setShipTime(oePSHdrDataBase.getP_ShipTime());
	packSlip.setShipmentID(oePSHdrDataBase.getP_ShipmentID());
	packSlip.setTradingPartner(oePSHdrDataBase.getP_TradingPartner());
	packSlip.setMBOL(oePSHdrDataBase.getP_MBOL());
	packSlip.setPackSlip2(oePSHdrDataBase.getP_PackSlip2());
	packSlip.setProNumber(oePSHdrDataBase.getP_ProNumber());
	packSlip.setStatus(oePSHdrDataBase.getP_Status());
	packSlip.setBTAdd1(oePSHdrDataBase.getP_BTAdd1());
	packSlip.setBTAdd2(oePSHdrDataBase.getP_BTAdd2());
	packSlip.setBTAdd3(oePSHdrDataBase.getP_BTAdd3());
	packSlip.setBTAdd4(oePSHdrDataBase.getP_BTAdd4());
	packSlip.setBTProvState(oePSHdrDataBase.getP_BTProvState());
	packSlip.setBTCountry(oePSHdrDataBase.getP_BTCountry());
	packSlip.setBTPostZip(oePSHdrDataBase.getP_BTPostZip());
	packSlip.setBTContact(oePSHdrDataBase.getP_BTContact());
	packSlip.setSTAdd1(oePSHdrDataBase.getP_STAdd1());
	packSlip.setSTAdd2(oePSHdrDataBase.getP_STAdd2());
	packSlip.setSTAdd3(oePSHdrDataBase.getP_STAdd3());
	packSlip.setSTAdd4(oePSHdrDataBase.getP_STAdd4());
	packSlip.setSTProvState(oePSHdrDataBase.getP_STProvState());
	packSlip.setSTCountry(oePSHdrDataBase.getP_STCountry());
	packSlip.setSTPostZip(oePSHdrDataBase.getP_STPostZip());
	packSlip.setSTContact(oePSHdrDataBase.getP_STContact());
	packSlip.setSFAdd1(oePSHdrDataBase.getP_SFAdd1());
	packSlip.setSFAdd2(oePSHdrDataBase.getP_SFAdd2());
	packSlip.setSFAdd3(oePSHdrDataBase.getP_SFAdd3());
	packSlip.setSFAdd4(oePSHdrDataBase.getP_SFAdd4());
	packSlip.setSFProvState(oePSHdrDataBase.getP_SFProvState());
	packSlip.setSFCountry(oePSHdrDataBase.getP_SFCountry());
	packSlip.setSFPostZip(oePSHdrDataBase.getP_SFPostZip());
	packSlip.setSFContact(oePSHdrDataBase.getP_SFContact());

	return packSlip;
}

private
OePSHdrDataBase objectToObjectDataBase (PackSlip packSlip){

OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);

	oePSHdrDataBase.setP_ID(packSlip.getID());
	oePSHdrDataBase.setP_Db(packSlip.getDb());
	oePSHdrDataBase.setP_Company(packSlip.getCompany());
	oePSHdrDataBase.setP_Plant(packSlip.getPlant());
	oePSHdrDataBase.setP_PackSlipNum(packSlip.getPackSlipNum());
	oePSHdrDataBase.setP_PackSlipType(packSlip.getPackSlipType());
	oePSHdrDataBase.setP_DateCrt(packSlip.getDateCrt());
	oePSHdrDataBase.setP_PrintInd(packSlip.getPrintInd());
	oePSHdrDataBase.setP_ShipInd(packSlip.getShipInd());
	oePSHdrDataBase.setP_BillToCust(packSlip.getBillToCust());
	oePSHdrDataBase.setP_ShipToCust(packSlip.getShipToCust());
	oePSHdrDataBase.setP_BillToName(packSlip.getBillToName());
	oePSHdrDataBase.setP_ShipToName(packSlip.getShipToName());
	oePSHdrDataBase.setP_BillToPost(packSlip.getBillToPost());
	oePSHdrDataBase.setP_Attention(packSlip.getAttention());
	oePSHdrDataBase.setP_ShipDate(packSlip.getShipDate());
	oePSHdrDataBase.setP_ShipVia(packSlip.getShipVia());
	oePSHdrDataBase.setP_OrderNum(packSlip.getOrderNum());
	oePSHdrDataBase.setP_StkLoc(packSlip.getStkLoc());
	oePSHdrDataBase.setP_ShipTime(packSlip.getShipTime());
	oePSHdrDataBase.setP_ShipmentID(packSlip.getShipmentID());
	oePSHdrDataBase.setP_TradingPartner(packSlip.getTradingPartner());
	oePSHdrDataBase.setP_MBOL(packSlip.getMBOL());
	oePSHdrDataBase.setP_PackSlip2(packSlip.getPackSlip2());
	oePSHdrDataBase.setP_ProNumber(packSlip.getProNumber());
	oePSHdrDataBase.setP_Status(packSlip.getStatus());
	oePSHdrDataBase.setP_BTAdd1(packSlip.getBTAdd1());
	oePSHdrDataBase.setP_BTAdd2(packSlip.getBTAdd2());
	oePSHdrDataBase.setP_BTAdd3(packSlip.getBTAdd3());
	oePSHdrDataBase.setP_BTAdd4(packSlip.getBTAdd4());
	oePSHdrDataBase.setP_BTProvState(packSlip.getBTProvState());
	oePSHdrDataBase.setP_BTCountry(packSlip.getBTCountry());
	oePSHdrDataBase.setP_BTPostZip(packSlip.getBTPostZip());
	oePSHdrDataBase.setP_BTContact(packSlip.getBTContact());
	oePSHdrDataBase.setP_STAdd1(packSlip.getSTAdd1());
	oePSHdrDataBase.setP_STAdd2(packSlip.getSTAdd2());
	oePSHdrDataBase.setP_STAdd3(packSlip.getSTAdd3());
	oePSHdrDataBase.setP_STAdd4(packSlip.getSTAdd4());
	oePSHdrDataBase.setP_STProvState(packSlip.getSTProvState());
	oePSHdrDataBase.setP_STCountry(packSlip.getSTCountry());
	oePSHdrDataBase.setP_STPostZip(packSlip.getSTPostZip());
	oePSHdrDataBase.setP_STContact(packSlip.getSTContact());
	oePSHdrDataBase.setP_SFAdd1(packSlip.getSFAdd1());
	oePSHdrDataBase.setP_SFAdd2(packSlip.getSFAdd2());
	oePSHdrDataBase.setP_SFAdd3(packSlip.getSFAdd3());
	oePSHdrDataBase.setP_SFAdd4(packSlip.getSFAdd4());
	oePSHdrDataBase.setP_SFProvState(packSlip.getSFProvState());
	oePSHdrDataBase.setP_SFCountry(packSlip.getSFCountry());
	oePSHdrDataBase.setP_SFPostZip(packSlip.getSFPostZip());
	oePSHdrDataBase.setP_SFContact(packSlip.getSFContact());

	return oePSHdrDataBase;
}

public
PackSlip createPackSlip(){
	return new PackSlip();
}

//------------------------------------------------------------------------------------------------------
} // class

} // package