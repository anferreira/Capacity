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
class BomCoreFactory : BaseCoreFactory{

private ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainerForBom;
private ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainerForBom;
private Hashtable hashCapCfgProdPrefForBom;

protected
BomCoreFactory() : base(){
}

public
BomContainer createBomContainer(){
    return new BomContainer();
}

public
BomObjectivesView createBomObjectivesView(Bom bom){
	return new BomObjectivesView(bom);
}

public 
string[][] getProdBOMChild(string prodId, int seqId) {
	try{
		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(prodId);
		if (prodFmInfoDataBase.exists())
			prodFmInfoDataBase.read();
		else
			throw new NujitException("The product : " + prodId.Trim() + " was not found in ProdFmInfo table, but is present in BomSum table");
		
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		bomSumDataBaseContainer.readForMaterials(prodId, seqId);

		string[][] returnArray = new string[bomSumDataBaseContainer.Count][];
		int i = 0;

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;

			string[] lineArray = new string[2];
			lineArray[0] = bomSumDataBase.getBMS_MatID();
			lineArray[1] = bomSumDataBase.getBMS_MatSeq().ToString();

			returnArray[i++] = lineArray;
		}
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getParentMaterials(string matId, int seqId){
	try{
		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(matId);
		if (prodFmInfoDataBase.exists())
			prodFmInfoDataBase.read();
		else
			throw new NujitException("The product : " + matId.Trim() + " was not found in ProdFmInfo table, but is present in BomSum table");
		
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		bomSumDataBaseContainer.readParentMaterials(matId, seqId);

		string[][] returnArray = new string[bomSumDataBaseContainer.Count][];
		int i = 0;

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;

			string[] lineArray = new string[4];
			lineArray[0] = bomSumDataBase.getBMS_ProdID().Trim();

			Product prod = UtilCoreFactory.createCoreFactory().readProduct(bomSumDataBase.getBMS_ProdID().Trim());
			lineArray[1] = prod.getDes1();
			lineArray[2] = bomSumDataBase.getBMS_Seq().ToString();
			lineArray[3] = bomSumDataBase.getBMS_QtyPerInv().ToString();
			returnArray[i++] = lineArray;
		}
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
int QtyInSubmaterialsOf(string matSrch, int matSrchSeq, string matId, int matSeq){
	return QtyInSubmaterialsOf(matSrch, matSrchSeq, matId, matSeq, 0);
}

private 
int QtyInSubmaterialsOf(string matSrch, int matSrchSeq, string matId, int matSeq, int qty){
	try{
		if (qty>99)
			return 999;

		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(matId);
		if (prodFmInfoDataBase.exists())
			prodFmInfoDataBase.read();
		else
			throw new NujitException("The product : " + matId.Trim() + " was not found in ProdFmInfo table, but is present in BomSum table");
		
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		bomSumDataBaseContainer.readForMaterials(matId, matSeq);

		string[][] returnArray = new string[bomSumDataBaseContainer.Count][];

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;
			
			if ((matSrch == bomSumDataBase.getBMS_MatID().Trim()) && ((matSrchSeq == bomSumDataBase.getBMS_MatSeq()) || (matSrchSeq == 0) ) )
				qty++;
			qty = QtyInSubmaterialsOf(matSrch, matSrchSeq, bomSumDataBase.getBMS_MatID().Trim(), bomSumDataBase.getBMS_MatSeq(), qty);
		}
		return qty;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getSubMaterials(string matId, int seqId){
	try{
		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(matId);
		if (prodFmInfoDataBase.exists())
			prodFmInfoDataBase.read();
		else
			throw new NujitException("The product : " + matId.Trim() + " was not found in ProdFmInfo table, but is present in BomSum table");
		
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		bomSumDataBaseContainer.readForMaterials(matId, seqId);

		string[][] returnArray = new string[bomSumDataBaseContainer.Count][];
		int i = 0;

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;

			string[] lineArray = new string[4];
			lineArray[0] = bomSumDataBase.getBMS_MatID().Trim();
			lineArray[1] = bomSumDataBase.getBMS_MatSeq().ToString();
			returnArray[i++] = lineArray;
		}
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
        /*
public 
string[][] getSubMaterialsMainLevel(string matId, int seqId){
	try{		
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		bomSumDataBaseContainer.readForMaterials(matId, seqId);

		string[][]      returnArray = new string[bomSumDataBaseContainer.Count][];
		int             i = 0;
        string          schildPart="";
        int             ichildSeq=0;
        string          sdesc="";
        string          stype="";
        decimal         dinventory=0;

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;
			
            string[] lineArray = new string[7];

            schildPart  = bomSumDataBase.getBMS_MatID();
            ichildSeq   = bomSumDataBase.getBMS_MatSeq();
            sdesc="";
            stype="";
            dinventory = 0;

            ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
            prodFmInfoDataBase.setPFS_ProdID(schildPart);
            if (prodFmInfoDataBase.read()){
                sdesc = prodFmInfoDataBase.getPFS_Des1();
				stype = prodFmInfoDataBase.getPFS_PartType();
            }
                        
            InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
            dinventory= invPltLocDataBaseContainer.getSumQtyByPartSeq(schildPart,ichildSeq);
            
			lineArray[0] = bomSumDataBase.getBMS_MatID().Trim();
			lineArray[1] = bomSumDataBase.getBMS_MatSeq().ToString();
            lineArray[2] = decimal.Round(bomSumDataBase.getBMS_MatQty(),2).ToString();
            lineArray[3] = sdesc;
            lineArray[4] = stype;
            lineArray[5] = decimal.Round(dinventory,2).ToString(); 
            lineArray[6] = ""; 
			returnArray[i++] = lineArray;
		}
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}*/

public 
BomSumContainer getSubMaterialsMainLevel(string spart, int iseq,string splant){
	try{		
        BomSumContainer         bomSumContainer = new BomSumContainer();
        BomSum                  bomSum          = null;
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		bomSumDataBaseContainer.readForMaterials(spart,iseq);
		
        string          sdesc="";
        string          stype="";
        decimal         dqoh=0;

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;
            bomSum = objectDataBaseToObject(bomSumDataBase);
			
            sdesc="";
            stype="";
            dqoh = 0;

            ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
            prodFmInfoDataBase.setPFS_ProdID(bomSum.MatID);
            if (prodFmInfoDataBase.read()){
                sdesc = prodFmInfoDataBase.getPFS_Des1();
				stype = prodFmInfoDataBase.getPFS_PartType();
            }
                        
            InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
            dqoh= invPltLocDataBaseContainer.getSumQtyByPartSeq(bomSum.MatID,bomSum.MatSeq,splant);
            
			bomSum.MatDescShow  = sdesc;
            bomSum.MatTypeShow  = stype;
            bomSum.MatQohShow   = dqoh;

            bomSumContainer.Add(bomSum);
		}
		return bomSumContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
BomSumContainer getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(string spart, int iseq,string splant,string sreportingPoint,int iminorSeqRows){
	try{		
        BomSumContainer         bomSumContainer = getSubMaterialsMainLevel(spart,iseq,splant);        
        BomSum                  bomSum          = null;
        string                  sdesc="";
        string                  stype="";
        decimal                 dqoh=0;
        int                     iminorSeqProcessed=0;
        
        ProdFmActHDataBaseContainer prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);
	    prodFmActHDataBaseContainer.readByFilters(spart, -1,splant,sreportingPoint); //read all seqs for part

        if (prodFmActHDataBaseContainer.Count > 0) { 
            ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
            prodFmInfoDataBase.setPFS_ProdID(spart);
            if (prodFmInfoDataBase.read()){
                sdesc = prodFmInfoDataBase.getPFS_Des1();
			    stype = prodFmInfoDataBase.getPFS_PartType();
            }
        }

        foreach(ProdFmActHDataBase prodFmActHDataBase in prodFmActHDataBaseContainer){
            if (prodFmActHDataBase.getPAH_Seq() < iseq && (iminorSeqRows == 0 || iminorSeqProcessed < iminorSeqRows)){

                iminorSeqProcessed++;
                bomSum= new BomSum();
                bomSum.ProdID   = spart;
                bomSum.Seq      = iseq;

                bomSum.MatID    = spart;
                bomSum.MatSeq   = prodFmActHDataBase.getPAH_Seq();
                bomSum.MatQty   = 1;

                InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
                dqoh= invPltLocDataBaseContainer.getSumQtyByPartSeq(bomSum.MatID,bomSum.MatSeq,splant);

                bomSum.MatDescShow  = sdesc;
                bomSum.MatTypeShow  = stype;
                bomSum.MatQohShow   = dqoh;

                bomSumContainer.Add(bomSum);
            }
        }

        return bomSumContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
BomSum createBomSum(){
    return new BomSum();
}

public
BomSumContainer createBomSumContainer(){
    return new BomSumContainer();
}


/// <summary>
/// Return if exists a BomSum record
/// </summary>
/// <param name="prodID"></param>
/// <param name="seq"></param>
/// <param name="matID"></param>
/// <param name="matSeq"></param>
/// <returns></returns>
        public 
bool existsBomSum(string prodID, int seq, string matID, int matSeq){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(prodID);
		bomSumDataBase.setBMS_Seq(seq);
		bomSumDataBase.setBMS_MatID(matID);
		bomSumDataBase.setBMS_MatSeq(matSeq);
		return bomSumDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Return if exists a BomSum record
/// </summary>
/// <param name="bomSumObj"></param>
/// <returns></returns>
public 
bool existsBomSumObj(BomSum bomSumObj) {
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(bomSumObj.getBMS_ProdID());
		bomSumDataBase.setBMS_Seq(bomSumObj.getBMS_Seq());
		bomSumDataBase.setBMS_MatID(bomSumObj.getBMS_MatID());
		bomSumDataBase.setBMS_MatSeq(bomSumObj.getBMS_MatSeq());
		return bomSumDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Read and return a BomSum object
/// </summary>
/// <param name="prodID"></param>
/// <param name="seq"></param>
/// <param name="matID"></param>
/// <param name="matSeq"></param>
/// <returns></returns>
public 
BomSum readBomSum(string prodID, int seq, string matID, int matSeq){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(prodID);
		bomSumDataBase.setBMS_Seq(seq);
		bomSumDataBase.setBMS_MatID(matID);
		bomSumDataBase.setBMS_MatSeq(matSeq);
		
		if (!bomSumDataBase.exists())
			return null;

		bomSumDataBase.read();
		BomSum bomSum = new BomSum(bomSumDataBase.getBMS_ProdID(), bomSumDataBase.getBMS_ActID(), bomSumDataBase.getBMS_Seq(), bomSumDataBase.getBMS_SubID(), bomSumDataBase.getBMS_SubOrdNum(), bomSumDataBase.getBMS_MethodRank(), bomSumDataBase.getBMS_MatOrdNum(), bomSumDataBase.getBMS_MatID(), bomSumDataBase.getBMS_MatSeq(), bomSumDataBase.getBMS_TLID(), bomSumDataBase.getBMS_MatQty(), bomSumDataBase.getBMS_Uom(), bomSumDataBase.getBMS_PrQty(), bomSumDataBase.getBMS_PrQtyUom(), bomSumDataBase.getBMS_QtyPerInv(), bomSumDataBase.getBMS_QtyPerUom(), bomSumDataBase.getBMS_UsePer(), bomSumDataBase.getBMS_MatPer(), bomSumDataBase.getBMS_ScrapPer(), bomSumDataBase.getBMS_ScrapAmt(), bomSumDataBase.getBMS_ScrapUnt(), bomSumDataBase.getBMS_EcnCurr(), bomSumDataBase.getBMS_EcnFut(), bomSumDataBase.getBMS_EcnFutDat(), bomSumDataBase.getBMS_BomSumYN());
		
		return bomSum;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Write to the database a BomSum object
/// </summary>
/// <param name="bomSum"></param>
public 
void writeBomSum(BomSum bomSum){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(bomSum.getBMS_ProdID());
		bomSumDataBase.setBMS_Seq(bomSum.getBMS_Seq());
		bomSumDataBase.setBMS_ActID(bomSum.getBMS_ActID());
		bomSumDataBase.setBMS_SubID(bomSum.getBMS_SubID());
		bomSumDataBase.setBMS_SubOrdNum(bomSum.getBMS_SubOrdNum());
		bomSumDataBase.setBMS_MethodRank(bomSum.getBMS_MethodRank());
		bomSumDataBase.setBMS_MatOrdNum(bomSum.getBMS_MatOrdNum());
		bomSumDataBase.setBMS_MatID(bomSum.getBMS_MatID());
		bomSumDataBase.setBMS_MatSeq(bomSum.getBMS_MatSeq());
		bomSumDataBase.setBMS_TLID(bomSum.getBMS_TLID());
		bomSumDataBase.setBMS_MatQty(bomSum.getBMS_MatQty());
		bomSumDataBase.setBMS_Uom(bomSum.getBMS_Uom());
		bomSumDataBase.setBMS_PrQty(bomSum.getBMS_PrQty());
		bomSumDataBase.setBMS_PrQtyUom(bomSum.getBMS_PrQtyUom());
		bomSumDataBase.setBMS_QtyPerInv(bomSum.getBMS_QtyPerInv());
		bomSumDataBase.setBMS_QtyPerUom(bomSum.getBMS_QtyPerUom());
		bomSumDataBase.setBMS_UsePer(bomSum.getBMS_UsePer());
		bomSumDataBase.setBMS_MatPer(bomSum.getBMS_MatPer());
		bomSumDataBase.setBMS_ScrapPer(bomSum.getBMS_ScrapPer());
		bomSumDataBase.setBMS_ScrapAmt(bomSum.getBMS_ScrapAmt());
		bomSumDataBase.setBMS_ScrapUnt(bomSum.getBMS_ScrapUnt());
		bomSumDataBase.setBMS_EcnCurr(bomSum.getBMS_EcnCurr());
		bomSumDataBase.setBMS_EcnFut(bomSum.getBMS_EcnFut());
		bomSumDataBase.setBMS_EcnFutDat(bomSum.getBMS_EcnFutDat());
		bomSumDataBase.setBMS_BomSumYN(bomSum.getBMS_BomSumYN());
		bomSumDataBase.write();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Update a BomSum object
/// </summary>
/// <param name="bomSum"></param>
public 
void updateBomSum(BomSum bomSum){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(bomSum.getBMS_ProdID());
		bomSumDataBase.setBMS_Seq(bomSum.getBMS_Seq());
		bomSumDataBase.setBMS_ActID(bomSum.getBMS_ActID());
		bomSumDataBase.setBMS_SubID(bomSum.getBMS_SubID());
		bomSumDataBase.setBMS_SubOrdNum(bomSum.getBMS_SubOrdNum());
		bomSumDataBase.setBMS_MethodRank(bomSum.getBMS_MethodRank());
		bomSumDataBase.setBMS_MatOrdNum(bomSum.getBMS_MatOrdNum());
		bomSumDataBase.setBMS_MatID(bomSum.getBMS_MatID());
		bomSumDataBase.setBMS_MatSeq(bomSum.getBMS_MatSeq());
		bomSumDataBase.setBMS_TLID(bomSum.getBMS_TLID());
		bomSumDataBase.setBMS_MatQty(bomSum.getBMS_MatQty());
		bomSumDataBase.setBMS_Uom(bomSum.getBMS_Uom());
		bomSumDataBase.setBMS_PrQty(bomSum.getBMS_PrQty());
		bomSumDataBase.setBMS_PrQtyUom(bomSum.getBMS_PrQtyUom());
		bomSumDataBase.setBMS_QtyPerInv(bomSum.getBMS_QtyPerInv());
		bomSumDataBase.setBMS_QtyPerUom(bomSum.getBMS_QtyPerUom());
		bomSumDataBase.setBMS_UsePer(bomSum.getBMS_UsePer());
		bomSumDataBase.setBMS_MatPer(bomSum.getBMS_MatPer());
		bomSumDataBase.setBMS_ScrapPer(bomSum.getBMS_ScrapPer());
		bomSumDataBase.setBMS_ScrapAmt(bomSum.getBMS_ScrapAmt());
		bomSumDataBase.setBMS_ScrapUnt(bomSum.getBMS_ScrapUnt());
		bomSumDataBase.setBMS_EcnCurr(bomSum.getBMS_EcnCurr());
		bomSumDataBase.setBMS_EcnFut(bomSum.getBMS_EcnFut());
		bomSumDataBase.setBMS_EcnFutDat(bomSum.getBMS_EcnFutDat());
		bomSumDataBase.setBMS_BomSumYN(bomSum.getBMS_BomSumYN());
		bomSumDataBase.update();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Delete a BomSum object
/// </summary>
/// <param name="bomSum"></param>
public 
void deleteBomSum(BomSum bomSum){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(bomSum.getBMS_ProdID());
		bomSumDataBase.setBMS_Seq(bomSum.getBMS_Seq());
		bomSumDataBase.setBMS_MatID(bomSum.getBMS_MatID());
		bomSumDataBase.setBMS_MatSeq(bomSum.getBMS_MatSeq());
		bomSumDataBase.delete();
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Adds the tree of materials attached to the product
/// </summary>
/// <param name="prodId"></param>
/// <param name="prodSeq"></param>
/// <returns></returns>
public 
BomSumTempContainer readBomSumTreeProdSeq(string prodId, int prodSeq){
	try{
		BomSumTempContainer bomSumTempContainer = new BomSumTempContainer();

		bomSumTempContainer = readBomSumTree(bomSumTempContainer, prodId, prodSeq);
		return bomSumTempContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Adds the subtree of materials attached to the product or material
/// </summary>
/// <param name="bomSumTempContainer"></param>
/// <param name="prodId"></param>
/// <param name="prodSeq"></param>
/// <returns></returns>
public 
BomSumTempContainer readBomSumTree(BomSumTempContainer bomSumTempContainer, string prodId, int prodSeq){
    try{
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);

		bomSumDataBaseContainer.readForMaterials(prodId, prodSeq);

		for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;

			string subProdId = bomSumDataBase.getBMS_ProdID();
			int subProdSeq = bomSumDataBase.getBMS_Seq();
			string subMatId = bomSumDataBase.getBMS_MatID();
			int subMatSeq = bomSumDataBase.getBMS_MatSeq();

			if (!bomSumTempContainer.existsBomSum(subProdId, subProdSeq, subMatId, subMatSeq)){
				BomSum bomSumObj = readBomSum(subProdId, subProdSeq, subMatId, subMatSeq);
				if (bomSumObj!=null) {
					bomSumTempContainer.addBomSum(bomSumObj);			
					bomSumTempContainer = readBomSumTree(bomSumTempContainer, subMatId, subMatSeq);
				} else // gdd 
					throw new NujitException("Error in readBomSumTree: readBomSum('" + subProdId + "'," + subProdSeq + ",'" + subMatId + "'," + subMatSeq + ")==null");
			}
		}
		return bomSumTempContainer;

	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

public 
void updateBomSumTempContainer(BomSumTempContainer bomSumTempContainer){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		for(IEnumerator en = bomSumTempContainer.GetEnumerator(); en.MoveNext(); ){
			DictionaryEntry de = (DictionaryEntry)en.Current;
			BomSum bomSumObj = (BomSum) de.Value;

			if (bomSumObj.isDeleted()){
				deleteBomSum(bomSumObj);
			}else{
				if (existsBomSumObj(bomSumObj)){
					updateBomSum(bomSumObj);
				}else{
					writeBomSum(bomSumObj);
				}
			}
		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
	    throw new NujitException(exception.Message, exception);
    }
}

private
BomSum objectDataBaseToObject(BomSumDataBase bomSumDataBase){
	BomSum bomSum = new BomSum();

	bomSum.ProdID=bomSumDataBase.getBMS_ProdID();
	bomSum.ActID=bomSumDataBase.getBMS_ActID();
	bomSum.Seq=bomSumDataBase.getBMS_Seq();
	bomSum.SubID=bomSumDataBase.getBMS_SubID();
	bomSum.SubOrdNum=bomSumDataBase.getBMS_SubOrdNum();
	bomSum.MethodRank=bomSumDataBase.getBMS_MethodRank();
	bomSum.MatOrdNum=bomSumDataBase.getBMS_MatOrdNum();
	bomSum.MatID=bomSumDataBase.getBMS_MatID();
	bomSum.MatSeq=bomSumDataBase.getBMS_MatSeq();
	bomSum.TLID=bomSumDataBase.getBMS_TLID();
	bomSum.MatQty=bomSumDataBase.getBMS_MatQty();
	bomSum.Uom=bomSumDataBase.getBMS_Uom();
	bomSum.PrQty=bomSumDataBase.getBMS_PrQty();
	bomSum.PrQtyUom=bomSumDataBase.getBMS_PrQtyUom();
	bomSum.QtyPerInv=bomSumDataBase.getBMS_QtyPerInv();
	bomSum.QtyPerUom=bomSumDataBase.getBMS_QtyPerUom();
	bomSum.UsePer=bomSumDataBase.getBMS_UsePer();
	bomSum.MatPer=bomSumDataBase.getBMS_MatPer();
	bomSum.ScrapPer=bomSumDataBase.getBMS_ScrapPer();
	bomSum.ScrapAmt=bomSumDataBase.getBMS_ScrapAmt();
	bomSum.ScrapUnt=bomSumDataBase.getBMS_ScrapUnt();
	bomSum.EcnCurr=bomSumDataBase.getBMS_EcnCurr();
	bomSum.EcnFut=bomSumDataBase.getBMS_EcnFut();
	bomSum.EcnFutDat=bomSumDataBase.getBMS_EcnFutDat();
	bomSum.BomSumYN=bomSumDataBase.getBMS_BomSumYN();

	return bomSum;
}

private
BomSumDataBase objectToObjectDataBase(BomSum bomSum){
	BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
	bomSumDataBase.setBMS_ProdID(bomSum.ProdID);
	bomSumDataBase.setBMS_ActID(bomSum.ActID);
	bomSumDataBase.setBMS_Seq(bomSum.Seq);
	bomSumDataBase.setBMS_SubID(bomSum.SubID);
	bomSumDataBase.setBMS_SubOrdNum(bomSum.SubOrdNum);
	bomSumDataBase.setBMS_MethodRank(bomSum.MethodRank);
	bomSumDataBase.setBMS_MatOrdNum(bomSum.MatOrdNum);
	bomSumDataBase.setBMS_MatID(bomSum.MatID);
	bomSumDataBase.setBMS_MatSeq(bomSum.MatSeq);
	bomSumDataBase.setBMS_TLID(bomSum.TLID);
	bomSumDataBase.setBMS_MatQty(bomSum.MatQty);
	bomSumDataBase.setBMS_Uom(bomSum.Uom);
	bomSumDataBase.setBMS_PrQty(bomSum.PrQty);
	bomSumDataBase.setBMS_PrQtyUom(bomSum.PrQtyUom);
	bomSumDataBase.setBMS_QtyPerInv(bomSum.QtyPerInv);
	bomSumDataBase.setBMS_QtyPerUom(bomSum.QtyPerUom);
	bomSumDataBase.setBMS_UsePer(bomSum.UsePer);
	bomSumDataBase.setBMS_MatPer(bomSum.MatPer);
	bomSumDataBase.setBMS_ScrapPer(bomSum.ScrapPer);
	bomSumDataBase.setBMS_ScrapAmt(bomSum.ScrapAmt);
	bomSumDataBase.setBMS_ScrapUnt(bomSum.ScrapUnt);
	bomSumDataBase.setBMS_EcnCurr(bomSum.EcnCurr);
	bomSumDataBase.setBMS_EcnFut(bomSum.EcnFut);
	bomSumDataBase.setBMS_EcnFutDat(bomSum.EcnFutDat);
	bomSumDataBase.setBMS_BomSumYN(bomSum.BomSumYN);

	return bomSumDataBase;
}

public
BomSum cloneBomSum(BomSum bomSum){
	BomSum bomSumClone = new BomSum();

	bomSumClone.ProdID=bomSum.ProdID;
	bomSumClone.ActID=bomSum.ActID;
	bomSumClone.Seq=bomSum.Seq;
	bomSumClone.SubID=bomSum.SubID;
	bomSumClone.SubOrdNum=bomSum.SubOrdNum;
	bomSumClone.MethodRank=bomSum.MethodRank;
	bomSumClone.MatOrdNum=bomSum.MatOrdNum;
	bomSumClone.MatID=bomSum.MatID;
	bomSumClone.MatSeq=bomSum.MatSeq;
	bomSumClone.TLID=bomSum.TLID;
	bomSumClone.MatQty=bomSum.MatQty;
	bomSumClone.Uom=bomSum.Uom;
	bomSumClone.PrQty=bomSum.PrQty;
	bomSumClone.PrQtyUom=bomSum.PrQtyUom;
	bomSumClone.QtyPerInv=bomSum.QtyPerInv;
	bomSumClone.QtyPerUom=bomSum.QtyPerUom;
	bomSumClone.UsePer=bomSum.UsePer;
	bomSumClone.MatPer=bomSum.MatPer;
	bomSumClone.ScrapPer=bomSum.ScrapPer;
	bomSumClone.ScrapAmt=bomSum.ScrapAmt;
	bomSumClone.ScrapUnt=bomSum.ScrapUnt;
	bomSumClone.EcnCurr=bomSum.EcnCurr;
	bomSumClone.EcnFut=bomSum.EcnFut;
	bomSumClone.EcnFutDat=bomSum.EcnFutDat;
	bomSumClone.BomSumYN=bomSum.BomSumYN;

	return bomSumClone;
}


//---------------------------------------------------------------------------

public
BomContainer makeBoms(string splant){
    try{
	    BomContainer bomContainer = new BomContainer();
	    BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
	    bomSumDataBaseContainer.read();

	    ProdFmInfoDataBaseContainer     prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        Hashtable                       hashBomSum= new Hashtable();

	    for(IEnumerator en = bomSumDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    BomSumDataBase bomSumDataBase = (BomSumDataBase) en.Current;
		    Bom bom = makeBom(bomSumDataBase.getBMS_ProdID(), bomSumDataBase.getBMS_Seq(),splant,
			    prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);
		    bomContainer.Add(bom);
	    }
	    return bomContainer;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	 
}

public 
void loadInfoForBom() {
	prodFmInfoDataBaseContainerForBom = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	prodFmActSubDataBaseContainerForBom = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	CapCfgProdPrefDataBaseContainer capCfgProdPrefDataBaseContainer = new CapCfgProdPrefDataBaseContainer(dataBaseAccess);
	capCfgProdPrefDataBaseContainer.read();
	hashCapCfgProdPrefForBom = new Hashtable();
	IEnumerator enu = capCfgProdPrefDataBaseContainer.GetEnumerator();
	while (enu.MoveNext()) {
		CapCfgProdPrefDataBase capCfgProdPrefDataBase = (CapCfgProdPrefDataBase)enu.Current;
		ArrayList list = (ArrayList)hashCapCfgProdPrefForBom[getPrefsKey(capCfgProdPrefDataBase)];
		if (list == null)
		{
			list = new ArrayList();
			hashCapCfgProdPrefForBom.Add (getPrefsKey(capCfgProdPrefDataBase), list);
		}
		list.Add (capCfgProdPrefDataBase);
	}
	prodFmActSubDataBaseContainerForBom.read();
	prodFmInfoDataBaseContainerForBom.read();
}

private
string getPrefsKey(CapCfgProdPrefDataBase capCfgProdPrefDataBase){
	return capCfgProdPrefDataBase.getPFCP_Plt() + "_" + capCfgProdPrefDataBase.getPFCP_Dept() +
		"_" + capCfgProdPrefDataBase.getPFCP_Cfg() + "_" + capCfgProdPrefDataBase.getPFCP_ProdID() +
		"_" + capCfgProdPrefDataBase.getPFCP_Seq().ToString();
}

public
void discardInfoForBom()
{
	prodFmInfoDataBaseContainerForBom = null;
	prodFmActSubDataBaseContainerForBom = null;
	hashCapCfgProdPrefForBom = null;
}

public 
Bom makeBomFromProdIDAndSeq (string prodId, int seqId,string splant){
	if (prodFmInfoDataBaseContainerForBom == null)
		loadInfoForBom();

    Hashtable hashBomSum = new Hashtable();
	return makeCompleteBom(prodId, seqId,splant,prodFmInfoDataBaseContainerForBom, 
		prodFmActSubDataBaseContainerForBom, hashCapCfgProdPrefForBom, hashBomSum);
}

private 
void setPreferences(Bom bom, Hashtable hashCapCfgProdPref, string plant, string departament,
				string cfg, string prodId, int seq){

	ArrayList list = (ArrayList)hashCapCfgProdPref[plant + "_" + departament + "_" + cfg + "_" + prodId + "_" + seq.ToString()];
	if (list != null){
        IEnumerator enu = list.GetEnumerator();
		while (enu.MoveNext()){
			CapCfgProdPrefDataBase capCfgProdPrefDataBase = (CapCfgProdPrefDataBase)enu.Current;
			bom.addPreference (capCfgProdPrefDataBase.getPFCP_Mach(), capCfgProdPrefDataBase.getPFCP_Pref());
		}
	}else{
		string mach = generateShcByMachine(plant, departament, prodId, seq);
		if ((mach != null) && (!mach.Equals(string.Empty))){
			try{
				if (!userHandleTransaction)
					dataBaseAccess.beginTransaction();

				CapCfgProdPrefDataBase capCfgProdPrefDataBase = new CapCfgProdPrefDataBase(dataBaseAccess);
				capCfgProdPrefDataBase.setPFCP_Plt(plant);
				capCfgProdPrefDataBase.setPFCP_Dept(departament);
				capCfgProdPrefDataBase.setPFCP_Cfg(cfg);
				capCfgProdPrefDataBase.setPFCP_ProdID(prodId);
				capCfgProdPrefDataBase.setPFCP_Seq(seq);
				capCfgProdPrefDataBase.setPFCP_Mach(mach);
				capCfgProdPrefDataBase.setPFCP_Pref(0);
				
				capCfgProdPrefDataBase.write();

				bom.addPreference (capCfgProdPrefDataBase.getPFCP_Mach(), capCfgProdPrefDataBase.getPFCP_Pref());

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
	}
}

private 
Bom makeCompleteBom(string prodId, int seqId,string splant, 
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
		Hashtable hashCapCfgProdPref,Hashtable hashBomSum){
	int level = 0;
	
	try{
	    ProdFmInfoDataBase prodFmInfoDataBase = 
		    prodFmInfoDataBaseContainer.getProdFmInfo(prodId);

	    if (prodFmInfoDataBase == null){
		    prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		    prodFmInfoDataBase.setPFS_ProdID(prodId);
		    if (!prodFmInfoDataBase.readForBom())
			    throw new NujitException("The product : " + prodId.Trim() + " was not found in ProdFmInfo table, but is present in BomSum table");

		    prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
	    }
    	
	    bool isPurchased = false;
	    if (prodFmInfoDataBase.getPFS_PartType().Equals("P"))
		    isPurchased = true;
    	
	    string cfg = "";
	    string departament = "";
		string plant = "";
		decimal rate = 1;

        ProdFmActSubDataBase prodFmActSubDataBase = null;                            
	    if (getProdFmActSubDataBase(out prodFmActSubDataBase,prodFmActSubDataBaseContainer, prodId, seqId, splant)){
		    departament = prodFmActSubDataBase.getPC_Dept();
			plant = prodFmActSubDataBase.getPC_Plt();
			cfg = prodFmActSubDataBase.getPC_Cfg();
			rate = prodFmActSubDataBase.getPC_RunStd();
		}

	    Bom bom = new Bom(new BomContainer(), 0, isPurchased, prodId, "", seqId, 1, departament, cfg, rate);
		if (!isPurchased && (hashCapCfgProdPref != null))
			this.setPreferences (bom, hashCapCfgProdPref, plant, departament, cfg, prodId, seqId);

	    return makeBomRecursive(bom, prodId, seqId,splant, level, departament, 
		    prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashCapCfgProdPref, hashBomSum);
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}		    
}


public
Bom makeBom(string prodId, int seqId, string splant,
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,Hashtable hashBomSum){

	return makeCompleteBom(prodId, seqId,splant,prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, null, hashBomSum);
}

public
BomSumDataBaseContainer getBomSum(string prodId,int seqId,Hashtable hashBomSum){
    BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);        
    string                  sbomKey     = prodId.ToUpper()+ Nujit.NujitERP.ClassLib.Common.Constants.DEFAULT_SEP + seqId.ToString();

    if (hashBomSum.Contains(sbomKey))
        bomSumDataBaseContainer = (BomSumDataBaseContainer)hashBomSum[sbomKey];
    else{
        bomSumDataBaseContainer.readForMaterials(prodId, seqId);       
        hashBomSum.Add(sbomKey,bomSumDataBaseContainer);                     	   
    }
    return bomSumDataBaseContainer;
}

private
Bom makeBomRecursive(Bom bom, string prodId, int seqId,string splant,int level, string dept,
	ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,
	ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
	Hashtable hashCapCfgProdPref, Hashtable hashBomSum){

	try{
		/*if (prodId.Equals("SUB10A-RH"))
		{
			string c = "";
		}*/
        BomSumDataBaseContainer bomSumDataBaseContainer = getBomSum(prodId,seqId,hashBomSum);            
	    level++;

        if (level > 2)
            level=level;

	    for(IEnumerator en2 = bomSumDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
		    BomSumDataBase bomSumDataBase = (BomSumDataBase) en2.Current;

		    // added for recognize manufactured/purchased products 
		    ProdFmInfoDataBase prodFmInfoDataBase = 
			    prodFmInfoDataBaseContainer.getProdFmInfo(bomSumDataBase.getBMS_MatID());

		    if (prodFmInfoDataBase == null){
			    prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
			    prodFmInfoDataBase.setPFS_ProdID(bomSumDataBase.getBMS_MatID());
			    if (!prodFmInfoDataBase.exists())
				    throw new NujitException("The product : " + bomSumDataBase.getBMS_MatID() + " was not found in ProdFmInfo table, but is present in BomSum table");

			    prodFmInfoDataBase.read();
			    prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
		    }
    		
		    bool isPurchased = false;
		    if (prodFmInfoDataBase.getPFS_PartType().Equals("P")){
			    isPurchased = true;

			    Bom newBom = new Bom(new BomContainer(), level, isPurchased, 
				    prodFmInfoDataBase.getPFS_ProdID(), "", bomSumDataBase.getBMS_MatSeq(), // seqId, AF 2020-03-31 use matseq not parent part seq
				    bomSumDataBase.getBMS_MatQty(), "", "", 0);

				bom.addToBomContainer(newBom);
		    }else{
			    ProdFmActSubDataBaseContainer components = prodFmActSubDataBaseContainer.getProdFmActSubContainer(bomSumDataBase.getBMS_MatID());
			    if (components.Count == 0){
				    components = new ProdFmActSubDataBaseContainer(dataBaseAccess);
				    components.readForBomOnlyByProd(bomSumDataBase.getBMS_MatID(),splant);

				    if (components.Count == 0){
						ProdFmActSubDataBase prodFmActSubDataBaseMat = (ProdFmActSubDataBase)prodFmActSubDataBaseContainer.getFirstObject(bomSumDataBase.getBMS_MatID());

						string cfgMat = "";
						string departament = "";
						string plant = "";
						decimal rate = 0;
						
						if (prodFmActSubDataBaseMat != null){
							cfgMat = prodFmActSubDataBaseMat.getPC_Cfg();
							departament = prodFmActSubDataBaseMat.getPC_Dept();
							plant = prodFmActSubDataBaseMat.getPC_Plt();
							rate = prodFmActSubDataBaseMat.getPC_RunStd();
						}

						Bom newBom = new Bom(new BomContainer(), level, isPurchased, 
						    bomSumDataBase.getBMS_MatID(), "", bomSumDataBase.getBMS_Seq(),
						    bomSumDataBase.getBMS_MatQty(), departament, cfgMat, rate);

						if (!isPurchased && (hashCapCfgProdPref != null))
							this.setPreferences (newBom, hashCapCfgProdPref, plant, departament, cfgMat, bomSumDataBase.getBMS_MatID(), bomSumDataBase.getBMS_Seq());
				
						bom.addToBomContainer(newBom);
				    }
			    }
    			
			    for(IEnumerator en = components.GetEnumerator(); en.MoveNext(); ){
				    ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) en.Current;

				    Bom newBom = new Bom(new BomContainer(), level, isPurchased, 
					    prodFmActSubDataBase.getPC_ProdID(), "", prodFmActSubDataBase.getPC_Seq(),
					    bomSumDataBase.getBMS_MatQty(), prodFmActSubDataBase.getPC_Dept(), 
						prodFmActSubDataBase.getPC_Cfg(), prodFmActSubDataBase.getPC_RunStd());

					if (!isPurchased && (hashCapCfgProdPref != null))
						this.setPreferences (newBom, hashCapCfgProdPref, prodFmActSubDataBase.getPC_Plt(), prodFmActSubDataBase.getPC_Dept(), prodFmActSubDataBase.getPC_Cfg(), prodFmActSubDataBase.getPC_ProdID(), prodFmActSubDataBase.getPC_Seq());

				    newBom = makeBomRecursive(newBom, prodFmActSubDataBase.getPC_ProdID(), 
					    prodFmActSubDataBase.getPC_Seq(),splant,level, prodFmActSubDataBase.getPC_Dept(),
					    prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer/*AF Demo components*/, hashCapCfgProdPref, hashBomSum);

				    bom.addToBomContainer(newBom);
			    }
		    }
	    }

	    return bom;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
void seeBom(Bom bom, string parent){
	try{
	    BomContainer bomContainer = bom.getBomContainer();
	    for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		    Bom bomAux = (Bom) en.Current;

		    seeBom(bomAux, bom.getProd());
	    }
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	    
}

public
string[][] getAllPurchasedMaterials(string prodId, int seqId,string splant){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = 
			new ProdFmInfoDataBaseContainer(dataBaseAccess);
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = 
			new ProdFmActSubDataBaseContainer(dataBaseAccess);

        Hashtable  hashBomSum= new Hashtable();
		Bom bom = makeBom(prodId, seqId,splant,prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);

		ArrayList lst = new ArrayList();
		lst = getAllPurchasedMaterialsFromBom(bom, lst);

		string[][] v = new string[lst.Count][];
		int index = 0;
		
		for(IEnumerator en = lst.GetEnumerator(); en.MoveNext(); ){
			string[] k = (String[]) en.Current;
			v[index] = k;
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
ArrayList getAllPurchasedMaterialsFromBom(Bom bom, ArrayList lst){
	try{
	    if (bom.isPurchased()){
		    string[] aux = new string[3];
		    aux[0] = bom.getProd();
		    aux[1] = bom.getSeq().ToString();
		    aux[2] = bom.getQty().ToString();
		    lst.Add(aux);
	    }
    	
	    BomContainer bomContainer = bom.getBomContainer();
	    for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		    Bom bomAux = (Bom) en.Current;

		    lst = getAllPurchasedMaterialsFromBom(bomAux, lst);
	    }
	    return lst;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	   
}

public
string[][] getErrorsBom(){
	try{
		BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
		return bomSumDataBaseContainer.getErrorsBom();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//---------------------------------------------------------------------------

public virtual
string generateShcByMachine(string plt, string dept,string part, int seq)
{return null;}

protected
bool getProdFmActSubDataBase(out ProdFmActSubDataBase prodFmActSubDataBase,string spart,int seq,string splant){
    bool                    bfound = false;     
    prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
	prodFmActSubDataBase.setPC_ProdID(spart);
	prodFmActSubDataBase.setPC_Seq(seq);
    prodFmActSubDataBase.setPC_Plt(splant);

	if (!string.IsNullOrEmpty(splant) )
        bfound = prodFmActSubDataBase.readByPartSeqPlant(); //first read by part/seq/plant
    if (!bfound)
        bfound = prodFmActSubDataBase.readByPartSeq();

    //we initialize just in case   
    if (!bfound) { 
        prodFmActSubDataBase.setPC_Plt("");
        prodFmActSubDataBase.setPC_Dept("");
        prodFmActSubDataBase.setPC_Cfg("");
        prodFmActSubDataBase.setPC_RunStd(1);
    }
    if (prodFmActSubDataBase.getPC_RunStd() == 0)
        prodFmActSubDataBase.setPC_RunStd(1);

    //if (!bfound)
        //System.Windows.Forms.MessageBox.Show("Can not find routing");
    return bfound;
} 

public
bool getProdFmActSubDataBase(out ProdFmActSubDataBase prodFmActSubDataBase, ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer, string spart,int seq,string splant){
    bool bfound = false;       
    prodFmActSubDataBase = null;                
    if (!string.IsNullOrEmpty(splant))
        prodFmActSubDataBase = prodFmActSubDataBaseContainer.getProdFmActSub(spart,seq,splant);

    if (prodFmActSubDataBase==null)
        prodFmActSubDataBase = prodFmActSubDataBaseContainer.getProdFmActSub(spart,seq);

    if (prodFmActSubDataBase!=null)
        bfound = true;     

	if (prodFmActSubDataBase == null) { 
        bfound = getProdFmActSubDataBase(out prodFmActSubDataBase,spart, seq,splant);
        if (bfound)
            prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase, prodFmActSubDataBase.getPC_ProdID());                
    }
    return bfound;
} 

public
Bom makeBom(string prodId, int seqId, string splant){

    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);

    prodFmActSubDataBaseContainer.read();

    Hashtable hashBomSum= new Hashtable();
    Bom bom = makeBom(prodId, seqId, splant,
			    prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);

	return bom;
}

public
Bom makeBom(ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer, string prodId, int seqId, string splant){

    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	
    Hashtable hashBomSum= new Hashtable();
    Bom bom = makeBom(prodId, seqId, splant,
			    prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);

	return bom;
}

} // class

} // namespace