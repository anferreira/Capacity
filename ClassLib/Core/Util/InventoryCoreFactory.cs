using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class InventoryCoreFactory : HotListCoreFactory{

protected
InventoryCoreFactory() : base(){
}

/// <summary>
/// Insert an row in the InvPltLoc table
/// </summary>
public 
void updateInventory(Inventory inventory){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		InvPltLocDataBaseContainer oldInvPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		oldInvPltLocDataBaseContainer.setIPLProdID(inventory.getProdID());
		oldInvPltLocDataBaseContainer.readByProdId(inventory.Plant);	
		
		//Delete the old container
		oldInvPltLocDataBaseContainer.delete();
	
		//Inser the new information
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		string[][] invPltLocContainer = inventory.getInvPltLocAsString();
		for(int i = 0; i < invPltLocContainer.Length; i++){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.setIPL_ProdID(invPltLocContainer[i][0]);
			invPltLocDataBase.setIPL_Seq(int.Parse(invPltLocContainer[i][1]));
			invPltLocDataBase.setIPL_LotID(invPltLocContainer[i][2]);
			invPltLocDataBase.setIPL_MasPrOrd(invPltLocContainer[i][3]);
			invPltLocDataBase.setIPL_PrOrd(invPltLocContainer[i][4]);
			invPltLocDataBase.setIPL_StkLoc(invPltLocContainer[i][5]);
			invPltLocDataBase.setIPL_Qoh(decimal.Parse(invPltLocContainer[i][6]));
			invPltLocDataBase.setIPL_QohAvail(decimal.Parse(invPltLocContainer[i][7]));
			invPltLocDataBase.setIPL_Uom(invPltLocContainer[i][8]);
			invPltLocDataBase.setIPL_Qoh2(decimal.Parse(invPltLocContainer[i][9]));
			invPltLocDataBase.setIPL_QohAvail2(decimal.Parse(invPltLocContainer[i][10]));
			invPltLocDataBase.setIPL_Uom2(invPltLocContainer[i][11]);
			invPltLocDataBase.setIPL_Prod2(invPltLocContainer[i][12]);	
			invPltLocDataBaseContainer.Add(invPltLocDataBase);
		}

		invPltLocDataBaseContainer.write();		

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}


/// <summary>
/// Return true if exists any inventory in the  InvPltLoc table
/// <param name="prodID"></param>
/// </summary>
public 
bool existsInventory(string prodId,string splant){
    try{
	    InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
	    invPltLocDataBase.setIPL_ProdID(prodId);
        invPltLocDataBase.setIPL_Plant(splant);
	    return invPltLocDataBase.existsProdIDPlant();
	}catch(PersistenceException persistenceException){
       throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}
		
}

/// <summary>
/// Return an Invnetory object searching for the prodID
/// <param name="prodID"></param>
/// </summary>
public 
Inventory readInventory(string prodId,string splant){
	try{
	    InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
	    invPltLocDataBaseContainer.setIPLProdID(prodId);
	    invPltLocDataBaseContainer.readByProdId(splant);

	    string[][] vec = new string[invPltLocDataBaseContainer.Count][];
	    int index = 0;
	    for(IEnumerator en = invPltLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) en.Current;
		    string[] aux = new String[13];
		    aux[0] = invPltLocDataBase.getIPL_ProdID();
		    aux[1] = invPltLocDataBase.getIPL_Seq().ToString();
		    aux[2] = invPltLocDataBase.getIPL_LotID();
		    aux[3] = invPltLocDataBase.getIPL_MasPrOrd();
		    aux[4] = invPltLocDataBase.getIPL_PrOrd();
		    aux[5] = invPltLocDataBase.getIPL_StkLoc();
		    aux[6] = invPltLocDataBase.getIPL_Qoh().ToString("#,###,###,##0.00000");
		    aux[7] = invPltLocDataBase.getIPL_QohAvail().ToString("#,###,###,##0.00000");
		    aux[8] = invPltLocDataBase.getIPL_Uom();
		    aux[9] = invPltLocDataBase.getIPL_Qoh2().ToString("#,###,###,##0.00000");
		    aux[10] = invPltLocDataBase.getIPL_QohAvail2().ToString("#,###,###,##0.00000");
		    aux[11] = invPltLocDataBase.getIPL_Uom2();
		    aux[12] = invPltLocDataBase.getIPL_Prod2();			
		    vec[index] = aux;
		    index++;
	    }

	    Inventory inventory = new Inventory(prodId,splant,vec);

	    return inventory;
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}
}

public
decimal getQtyOnHandForProduct(string prodId){

    try{
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(prodId);
	    prodFmInfoDataBase.read();
    	
	    decimal inv = 0;
	    InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
	    invPltLocDataBase.setIPL_ProdID(prodId);
	    invPltLocDataBase.setIPL_Seq(prodFmInfoDataBase.getPFS_SeqLast());
    	
	    if (invPltLocDataBase.exists()){
		    invPltLocDataBase.read();
		    inv = invPltLocDataBase.getIPL_Qoh();
	    }
    	
	    return inv;
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}


public 
string[][] getAllPltInvLocAsString(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		PltInvLocDataBaseContainer  pltInvLocDataBaseContainer = new PltInvLocDataBaseContainer(dataBaseAccess);
		pltInvLocDataBaseContainer.read();

		string[][] returnArray = new string[pltInvLocDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = pltInvLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PltInvLocDataBase pltInvLocDataBase = (PltInvLocDataBase)en.Current;

			string[] lineArray = new string[3];
			lineArray[0] = pltInvLocDataBase.getPL_Loc();
			lineArray[1] = pltInvLocDataBase.getPL_LocName();
			lineArray[2] = pltInvLocDataBase.getPL_HotListUse();

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
string[][] getInventoryReport(string prodId){
	try{
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		invPltLocDataBaseContainer.setIPLProdID(prodId);
		invPltLocDataBaseContainer.readForReport();

		string[][] returnArray = new string[invPltLocDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = invPltLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) en.Current;

			string[] lineArray = new string[15];
			lineArray[0] = invPltLocDataBase.getIPL_ProdID();
			lineArray[1] = invPltLocDataBase.getIPL_Seq().ToString();
			lineArray[2] = invPltLocDataBase.getIPL_StkLoc();
			lineArray[3] = invPltLocDataBase.getIPL_ActID();
			lineArray[4] = invPltLocDataBase.getIPL_LotID();
			lineArray[5] = invPltLocDataBase.getIPL_MasPrOrd();
			lineArray[6] = invPltLocDataBase.getIPL_PrOrd();
			lineArray[7] = invPltLocDataBase.getIPL_Qoh().ToString();
			lineArray[8] = invPltLocDataBase.getIPL_QohAvail().ToString();
			lineArray[9] = invPltLocDataBase.getIPL_Uom();
			lineArray[10] = invPltLocDataBase.getIPL_Qoh2().ToString();
			lineArray[11] = invPltLocDataBase.getIPL_QohAvail2().ToString();
			lineArray[12] = invPltLocDataBase.getIPL_Uom2();
			lineArray[13] = invPltLocDataBase.getIPL_Prod2();
			lineArray[14] = invPltLocDataBase.getPFS_Des1();
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
decimal getMinInventory(string prodId, int seq){
	try{
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(prodId);
		prodFmActPlanDataBase.setPAPL_Seq(seq);
		if (prodFmActPlanDataBase.exists()){
			prodFmActPlanDataBase.read();
			return prodFmActPlanDataBase.getPAPL_MinInv();
		}
		return 0;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
decimal getMinInventoryCum(string prodId, int seq){
	try{
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(prodId);
		prodFmActPlanDataBase.setPAPL_Seq(seq);
		
		return prodFmActPlanDataBase.getMinInvCum();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public 
string[][] getInventoryForSchedule(string splantOriginal,string spart,int seq, string stockLoc, string smachine,int imachineId,string sglExp,string srepPoint,string sprodFamily,DateTime startDate,DateTime endDate,bool baddReceipParts,bool bgetCumulativeQty,int irows){
	try{      
        Hashtable                   hashReceiptPart = new Hashtable(); //load hash to be processed faster
        InvPltLocDataBase           invPltLocDataBasePrior = null;
		InvPltLocDataBaseContainer  invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
        invPltLocDataBaseContainer.readByFilters(spart,seq,splantOriginal,stockLoc,smachine, imachineId, sglExp,srepPoint,sprodFamily, irows);

        ScheduleReceiptPartContainer scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();        
        if (baddReceipParts){
            scheduleReceiptPartContainer = getReceiptPartContainerByFilters(0,splantOriginal,spart, seq,smachine,imachineId,startDate,endDate);
            loadHashReceiptPart(scheduleReceiptPartContainer, hashReceiptPart,calculateUntilPastDue());
        }
		
		string[][]  returnArray = new string[0][];
        bool        bsummarizePart=false;
		int         i = 0;
		
        ArrayList arrayList = new ArrayList();
		for(IEnumerator en = invPltLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) en.Current;

            bsummarizePart=false;
            string[] lineArray = new string[101]; 
            
            if (invPltLocDataBasePrior!= null && 
                invPltLocDataBasePrior.getIPL_ProdID().ToUpper().Equals(invPltLocDataBase.getIPL_ProdID().ToUpper()) &&
                invPltLocDataBasePrior.getIPL_Seq() == invPltLocDataBase.getIPL_Seq()){

                lineArray = (string[]) arrayList[arrayList.Count-1];
                invPltLocDataBase.setIPL_Qoh(invPltLocDataBase.getIPL_Qoh() + invPltLocDataBasePrior.getIPL_Qoh());
                lineArray[Constants.INDEX_INVENTORY_START_QOH] = decimal.Floor(invPltLocDataBase.getIPL_Qoh()).ToString();//set Qoh
                bsummarizePart=true;
            }else
                lineArray = generateArrayInventory(invPltLocDataBase.getIPL_ProdID(), invPltLocDataBase.getIPL_Seq(),invPltLocDataBase.getIPL_StkLoc(), invPltLocDataBase.getPFS_Des1(), invPltLocDataBase.getIPL_Qoh());
                        
            if (!bsummarizePart){                
                addReceiptParts(startDate, lineArray, Constants.INDEX_INVENTORY_START_QOH,hashReceiptPart, false);
                arrayList.Add(lineArray);			
            }
            invPltLocDataBasePrior = invPltLocDataBase;
		}

        //addReceiptPartsWithNoInventoryRecords(splantOriginal,startDate, arrayList,hashReceiptPart);//add Receipt parts with no inventory records        
        cleanInventoryRecordsWihoutInfo(arrayList); //records with all columns on zero will be removed

        arrayList.Sort(new InventoryPartSeqComparer()); //sort by part/seq , then copy to return array
        returnArray = new string[arrayList.Count][];
        for (i=0; i < arrayList.Count;i++)
            returnArray[i]= checkIfNeedSummarizeLines(bgetCumulativeQty,(string[])arrayList[i]);
        
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
DateTime calculateUntilPastDue(){
    DateTime priorMon = DateTime.Now;
    DateTime nextSun = DateTime.Now;
    DateTime pastDue = DateTime.Now;

    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMon,out nextSun);    
    pastDue = priorMon.AddDays(-1);
    pastDue = new DateTime(pastDue.Year, pastDue.Month, pastDue.Day,23,59,59);
    return pastDue;
}

private
string[] checkIfNeedSummarizeLines(bool bgetCumulativeQty,string[] line){         
    if (bgetCumulativeQty) { 
        decimal dqtySum = 0;
        for (int i= Constants.INDEX_INVENTORY_START_QOH; i < line.Length; i++){
            dqtySum+= Convert.ToDecimal(line[i]);            
            line[i] = decimal.Floor(dqtySum).ToString();
        } 
    }
    return line; 
}

private
string[] generateArrayInventory(string spart,int seq,string stockLoc,string sdesc,decimal dqoh){    
    string[]    lineArray = new string[101];     
        
    for (int j=0; j < lineArray.Length;j++)
        lineArray[j] = decimal.Floor(0).ToString(); //initialize all
       
    lineArray[0] = spart;
	lineArray[1] = seq.ToString();
	lineArray[2] = stockLoc;
	lineArray[3] = sdesc;
    lineArray[Constants.INDEX_INVENTORY_START_QOH] = decimal.Floor(dqoh).ToString();//set Qoh

    return lineArray;
}

private
void cleanInventoryRecordsWihoutInfo(ArrayList arrayList){    
     //only show records with something on colums, qoh or receipt part
    bool bhasValue=true;
    for (int i=0; i < arrayList.Count;i++){
        string[] line = (string[])arrayList[i];

        bhasValue=false;                        
        for (int j= Constants.INDEX_INVENTORY_START_QOH; j < line.Length && !bhasValue; j++){
            decimal daux =  Convert.ToDecimal(line[j]);
            if (daux != 0)
                bhasValue = true;
        }

        if (!bhasValue){
            arrayList.RemoveAt(i);
            i--;
        }
    }
}

private
string getPartDesc(string spart,ProdFmInfoDataBase prodFmInfoDataBase){
    string sdesc = "";

    if (!string.IsNullOrEmpty(prodFmInfoDataBase.getPFS_ProdID()) && 
        prodFmInfoDataBase.getPFS_ProdID().ToUpper().Equals(spart.ToUpper())) //check if already read
        sdesc = prodFmInfoDataBase.getPFS_Des1();
    else{        
        prodFmInfoDataBase.setPFS_ProdID(spart);
        prodFmInfoDataBase.setPFS_Des1("");
        if (prodFmInfoDataBase.read())
            sdesc = prodFmInfoDataBase.getPFS_Des1();
    }

    return sdesc;
}

private 
void addReceiptPartsWithNoInventoryRecords(string splant,DateTime startDate,ArrayList arrayList,Hashtable hashReceiptPart){
    InvPltLocDataBaseContainer  invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
    IDictionaryEnumerator       denum = hashReceiptPart.GetEnumerator();        
    DictionaryEntry             dentry;      
    ProdFmInfoDataBase          prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);                         
    
    while (denum.MoveNext()) { 
        dentry = (DictionaryEntry) denum.Current;
        ScheduleReceiptPart scheduleReceiptPart = (ScheduleReceiptPart)dentry.Value;
        string              skey=(string)dentry.Key;
        decimal             dqoh= invPltLocDataBaseContainer.getSumQtyByPartSeq(scheduleReceiptPart.Part, scheduleReceiptPart.Seq,splant);        
        string[]            lineArray = generateArrayInventory(scheduleReceiptPart.Part, scheduleReceiptPart.Seq,"",getPartDesc(scheduleReceiptPart.Part,prodFmInfoDataBase),dqoh);
                
        addReceiptParts(startDate,lineArray, Constants.INDEX_INVENTORY_START_QOH,hashReceiptPart, false);
        arrayList.Add(lineArray);

        hashReceiptPart.Remove(skey); //just in case not found, force remove item
        denum = hashReceiptPart.GetEnumerator();  //to start iterator again,because minor records count on hashReceiptPart
    }
}

#region InventoryComparer
private
class InventoryPartSeqComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is string[]) && (y is string[])){
            string[] v1 = (string[])x;
            string[] v2 = (string[])y;

            string saux1 = v1[0] + Constants.DEFAULT_SEP + StringUtil.AddChar(v1[1],'0',5,false);
            string saux2 = v2[0] + Constants.DEFAULT_SEP + StringUtil.AddChar(v2[1],'0',5,false);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion ScheduleDateComparer

private
void addReceiptParts(DateTime runDate,string[] line,int indexStartQoh,Hashtable hashReceiptPart,bool bgetCumulativeQty){
    string                  spart = line[0];
    int                     seq = Convert.ToInt32(line[1]);
    DateTime                currentDate = DateUtil.MinValue;
    ScheduleReceiptPart     scheduleReceiptPart= null;
    decimal                 dqty = 0;
    decimal                 dnewQty = 0;       
    string                  skey="";
                                                           
    for (int i= (indexStartQoh+1); i < line.Length;i++){ //-2 because last 2 values, related to HotID/Plant
        currentDate = runDate.AddDays(i- (indexStartQoh + 1));
        
        scheduleReceiptPart = null;        
        skey= getHashKey(spart, seq, currentDate); //code to search faster
        if (hashReceiptPart.Contains(skey)){
            scheduleReceiptPart = (ScheduleReceiptPart)hashReceiptPart[skey];
            hashReceiptPart.Remove(skey); //remove , so we understand record was used
        }                    

        if (scheduleReceiptPart!= null){
            dqty = Convert.ToDecimal(line[i]);
            dnewQty = (scheduleReceiptPart.RecQty - scheduleReceiptPart.RepQty);
            dqty += dnewQty; //qty is negative so rest 
            line[i] = decimal.Floor(dqty).ToString();            
        } 
    } 

} 

/****************************************************** InventoryObjectives **************************************************/
public
InventoryObjectiveHdr createInventoryObjectiveHdr(){
	return new InventoryObjectiveHdr();
}

public
InventoryObjectiveHdrContainer createInventoryObjectiveHdrContainer(){
	return new InventoryObjectiveHdrContainer();
}

public
bool existsInventoryObjectiveHdr(int id){
	try{
		InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);

		inventoryObjectiveHdrDataBase.setId(id);

		return inventoryObjectiveHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
InventoryObjectiveHdr readInventoryObjectiveHdr(int id){
	try{
		InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);
		inventoryObjectiveHdrDataBase.setId(id);

		if (!inventoryObjectiveHdrDataBase.read())
			return null;

		InventoryObjectiveHdr inventoryObjectiveHdr = this.objectDataBaseToObject(inventoryObjectiveHdrDataBase);
        readInventoryObjectiveChilds2(inventoryObjectiveHdr);

		return inventoryObjectiveHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
void readInventoryObjectiveChilds(InventoryObjectiveHdr inventoryObjectiveHdr){
            	
	InventoryObjectivePartDataBaseContainer inventoryObjectivePartDataBaseContainer = new InventoryObjectivePartDataBaseContainer(dataBaseAccess);
	inventoryObjectivePartDataBaseContainer.readByHdr(inventoryObjectiveHdr.Id);
		
    foreach(InventoryObjectivePartDataBase inventoryObjectivePartDataBase in inventoryObjectivePartDataBaseContainer){ 
        InventoryObjectivePart inventoryObjectivePart = objectDataBaseToObject(inventoryObjectivePartDataBase);

        InventoryObjectivePartDtlDataBaseContainer inventoryObjectivePartDtlDataBaseContainer = new InventoryObjectivePartDtlDataBaseContainer(dataBaseAccess);
	    inventoryObjectivePartDtlDataBaseContainer.readByHdr(inventoryObjectivePart.HdrId, inventoryObjectivePart.Detail);

        foreach(InventoryObjectivePartDtlDataBase inventoryObjectivePartDtlDataBase in inventoryObjectivePartDtlDataBaseContainer){ 
            InventoryObjectivePartDtl inventoryObjectivePartDtl = objectDataBaseToObject(inventoryObjectivePartDtlDataBase);
            inventoryObjectivePart.InventoryObjectivePartDtlContainer.Add(inventoryObjectivePartDtl);
        }

        inventoryObjectiveHdr.InventoryObjectivePartContainer.Add(inventoryObjectivePart);
    }
}

private
void readInventoryObjectiveChilds2(InventoryObjectiveHdr inventoryObjectiveHdr){
    Hashtable               hashParts = new Hashtable();            	
    InventoryObjectivePart  inventoryObjectivePart = null;

    //parts    
	InventoryObjectivePartDataBaseContainer inventoryObjectivePartDataBaseContainer = new InventoryObjectivePartDataBaseContainer(dataBaseAccess);
	inventoryObjectivePartDataBaseContainer.readByHdr(inventoryObjectiveHdr.Id);
		
    foreach(InventoryObjectivePartDataBase inventoryObjectivePartDataBase in inventoryObjectivePartDataBaseContainer){ 
        inventoryObjectivePart = objectDataBaseToObject(inventoryObjectivePartDataBase);        
        inventoryObjectiveHdr.InventoryObjectivePartContainer.Add(inventoryObjectivePart);
        hashParts.Add(inventoryObjectivePart.Detail,inventoryObjectivePart);
    }

    //details
    InventoryObjectivePartDtlDataBaseContainer inventoryObjectivePartDtlDataBaseContainer = new InventoryObjectivePartDtlDataBaseContainer(dataBaseAccess);
	inventoryObjectivePartDtlDataBaseContainer.readByHdrAll(inventoryObjectiveHdr.Id);
    foreach(InventoryObjectivePartDtlDataBase inventoryObjectivePartDtlDataBase in inventoryObjectivePartDtlDataBaseContainer){ 
        InventoryObjectivePartDtl inventoryObjectivePartDtl = objectDataBaseToObject(inventoryObjectivePartDtlDataBase);

        if (hashParts.Contains(inventoryObjectivePartDtl.Detail)) {
            inventoryObjectivePart = (InventoryObjectivePart)hashParts[inventoryObjectivePartDtl.Detail];
            inventoryObjectivePart.InventoryObjectivePartDtlContainer.Add(inventoryObjectivePartDtl);
        }
    }

}

private
void deleteInventoryObjectiveChilds(int id){
    InventoryObjectivePartDtlDataBaseContainer inventoryObjectivePartDtlDataBaseContainer = new InventoryObjectivePartDtlDataBaseContainer(dataBaseAccess);
	inventoryObjectivePartDtlDataBaseContainer.deleteByHdr(id);
            	
	InventoryObjectivePartDataBaseContainer inventoryObjectivePartDataBaseContainer = new InventoryObjectivePartDataBaseContainer(dataBaseAccess);
	inventoryObjectivePartDataBaseContainer.deleteByHdr(id);	
}

private
void writeInventoryObjectiveChilds(InventoryObjectiveHdr inventoryObjectiveHdr){
            	
	inventoryObjectiveHdr.fillRedundances();
		
    for (int i=0; i < inventoryObjectiveHdr.InventoryObjectivePartContainer.Count;i++){ 
        InventoryObjectivePart inventoryObjectivePart = (InventoryObjectivePart)inventoryObjectiveHdr.InventoryObjectivePartContainer[i];
        InventoryObjectivePartDataBase inventoryObjectivePartDataBase = objectToObjectDataBase(inventoryObjectivePart);
        inventoryObjectivePartDataBase.write();
        
        writeInventoryObjectivePartChilds(inventoryObjectivePart);                
    }
}

public
void writeInventoryObjectivePartChilds(InventoryObjectivePart inventoryObjectivePart){
    inventoryObjectivePart.fillRedundances();
    for (int j=0; j < inventoryObjectivePart.InventoryObjectivePartDtlContainer.Count;j++){ 
        InventoryObjectivePartDtlDataBase inventoryObjectivePartDtlDataBase = objectToObjectDataBase(inventoryObjectivePart.InventoryObjectivePartDtlContainer[j]);
        inventoryObjectivePartDtlDataBase.write();
    } 
}

private 
void updateInventoryObjectiveOnly(InventoryObjectiveHdr inventoryObjectiveHdr){
    InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = this.objectToObjectDataBase(inventoryObjectiveHdr);
    checkDateTimeStamp(inventoryObjectiveHdr, inventoryObjectiveHdrDataBase);
	inventoryObjectiveHdrDataBase.update();
    inventoryObjectiveHdr.DateTimeStamp = inventoryObjectiveHdrDataBase.readDateTimeStamp();
}

public 
void updateInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		updateInventoryObjectiveOnly(inventoryObjectiveHdr);

        deleteInventoryObjectiveChilds(inventoryObjectiveHdr.Id);
        writeInventoryObjectiveChilds(inventoryObjectiveHdr);

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
	}
}

public 
void writeInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = this.objectToObjectDataBase(inventoryObjectiveHdr);
		inventoryObjectiveHdrDataBase.write();
        inventoryObjectiveHdr.Id=inventoryObjectiveHdrDataBase.getId();
        inventoryObjectiveHdr.DateTimeStamp = inventoryObjectiveHdrDataBase.readDateTimeStamp();
		
        writeInventoryObjectiveChilds(inventoryObjectiveHdr);

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
	}
}

public
void deleteInventoryObjectiveHdr(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        deleteInventoryObjectiveChilds(id);

		InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);

		inventoryObjectiveHdrDataBase.setId(id);
		inventoryObjectiveHdrDataBase.delete();

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
	}
}

public
InventoryObjectiveHdrContainer readInventoryObjectiveHdrByFilters(string sid,string splant, string status,DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows){
	try{
        InventoryObjectiveHdrContainer inventoryObjectiveHdrContainer = new InventoryObjectiveHdrContainer();

        InventoryObjectiveHdrDataBaseContainer inventoryObjectiveHdrDataBaseContainer = new InventoryObjectiveHdrDataBaseContainer(dataBaseAccess);
		inventoryObjectiveHdrDataBaseContainer.readByFilters(sid,splant,status,fromDate, toDate,rows);	
        
        foreach(InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase in inventoryObjectiveHdrDataBaseContainer){
            InventoryObjectiveHdr inventoryObjectiveHdr = objectDataBaseToObject(inventoryObjectiveHdrDataBase);
            
            if (!bonlyHeader)
                readInventoryObjectiveChilds2(inventoryObjectiveHdr);            
            inventoryObjectiveHdrContainer.Add(inventoryObjectiveHdr);
        }

		return inventoryObjectiveHdrContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
InventoryObjectiveHdr readInventoryObjectiveHdrLast(string splant){
    try{
        InventoryObjectiveHdr           inventoryObjectiveHdr = null;        
		InventoryObjectiveHdrDataBase   inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);
        int                             id=0;

        if (inventoryObjectiveHdrDataBase.readLastByFilter(splant)){
            inventoryObjectiveHdr = readInventoryObjectiveHdr(inventoryObjectiveHdrDataBase.getId());
        }
                      
		return inventoryObjectiveHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
InventoryObjectiveHdr readInventoryObjectiveHdrLastDateCheck(InventoryObjectiveHdr inventoryObjectiveHdr, string splant){
    InventoryObjectiveHdr inventoryObjectiveHdrNew = null;
	try{
        inventoryObjectiveHdrNew = inventoryObjectiveHdr;
        bool                            breadNew = false;
        InventoryObjectiveHdrDataBase   inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);		
        if (!inventoryObjectiveHdrDataBase.readLastByFilter(splant))
			return null;

        if (inventoryObjectiveHdr == null)
            breadNew = true;            
        else if (inventoryObjectiveHdr.DateTimeStamp != inventoryObjectiveHdrDataBase.getDateTimeStamp() || inventoryObjectiveHdr.Id != inventoryObjectiveHdrDataBase.getId())
            breadNew = true;    

        if (breadNew)
            inventoryObjectiveHdrNew = readInventoryObjectiveHdr(inventoryObjectiveHdrDataBase.getId());

		return inventoryObjectiveHdrNew;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
InventoryObjectiveHdr objectDataBaseToObject(InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase){
	InventoryObjectiveHdr inventoryObjectiveHdr = new InventoryObjectiveHdr();

	inventoryObjectiveHdr.Id=inventoryObjectiveHdrDataBase.getId();
	inventoryObjectiveHdr.DateCreated=inventoryObjectiveHdrDataBase.getDateCreated();
	inventoryObjectiveHdr.Status=inventoryObjectiveHdrDataBase.getStatus();
	inventoryObjectiveHdr.Plant=inventoryObjectiveHdrDataBase.getPlant();
    inventoryObjectiveHdr.DateTimeStamp = inventoryObjectiveHdrDataBase.getDateTimeStamp();

	return inventoryObjectiveHdr;
}

private
InventoryObjectiveHdrDataBase objectToObjectDataBase(InventoryObjectiveHdr inventoryObjectiveHdr){
	InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);
	inventoryObjectiveHdrDataBase.setId(inventoryObjectiveHdr.Id);
	inventoryObjectiveHdrDataBase.setDateCreated(inventoryObjectiveHdr.DateCreated);
	inventoryObjectiveHdrDataBase.setStatus(inventoryObjectiveHdr.Status);
	inventoryObjectiveHdrDataBase.setPlant(inventoryObjectiveHdr.Plant);
    inventoryObjectiveHdrDataBase.setDateTimeStamp(inventoryObjectiveHdr.DateTimeStamp);

	return inventoryObjectiveHdrDataBase;
}

public
InventoryObjectiveHdr cloneInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr){
	InventoryObjectiveHdr inventoryObjectiveHdrClone = new InventoryObjectiveHdr();

	inventoryObjectiveHdrClone.Id=inventoryObjectiveHdr.Id;
	inventoryObjectiveHdrClone.DateCreated=inventoryObjectiveHdr.DateCreated;
	inventoryObjectiveHdrClone.Status=inventoryObjectiveHdr.Status;
	inventoryObjectiveHdrClone.Plant=inventoryObjectiveHdr.Plant;
    inventoryObjectiveHdrClone.DateTimeStamp = inventoryObjectiveHdr.DateTimeStamp;

	return inventoryObjectiveHdrClone;
}

public
InventoryObjectivePart createInventoryObjectivePart(){
	return new InventoryObjectivePart();
}

public
InventoryObjectivePartContainer createInventoryObjectivePartContainer(){
	return new InventoryObjectivePartContainer();
}

private
InventoryObjectivePart objectDataBaseToObject(InventoryObjectivePartDataBase inventoryObjectivePartDataBase){
	InventoryObjectivePart inventoryObjectivePart = new InventoryObjectivePart();

	inventoryObjectivePart.HdrId=inventoryObjectivePartDataBase.getHdrId();
	inventoryObjectivePart.Detail=inventoryObjectivePartDataBase.getDetail();
	inventoryObjectivePart.Part=inventoryObjectivePartDataBase.getPart();
	inventoryObjectivePart.Seq=inventoryObjectivePartDataBase.getSeq();
	inventoryObjectivePart.Master=inventoryObjectivePartDataBase.getMaster();
    inventoryObjectivePart.ObectivesAutomaticCalc=inventoryObjectivePartDataBase.getObectivesAutomaticCalc();
            
    return inventoryObjectivePart;
}

private
InventoryObjectivePartDataBase objectToObjectDataBase(InventoryObjectivePart inventoryObjectivePart){
	InventoryObjectivePartDataBase inventoryObjectivePartDataBase = new InventoryObjectivePartDataBase(dataBaseAccess);
	inventoryObjectivePartDataBase.setHdrId(inventoryObjectivePart.HdrId);
	inventoryObjectivePartDataBase.setDetail(inventoryObjectivePart.Detail);
	inventoryObjectivePartDataBase.setPart(inventoryObjectivePart.Part);
	inventoryObjectivePartDataBase.setSeq(inventoryObjectivePart.Seq);
	inventoryObjectivePartDataBase.setMaster(inventoryObjectivePart.Master);
    inventoryObjectivePartDataBase.setObectivesAutomaticCalc(inventoryObjectivePart.ObectivesAutomaticCalc);

	return inventoryObjectivePartDataBase;
}

public
InventoryObjectivePart cloneInventoryObjectivePart(InventoryObjectivePart inventoryObjectivePart){
	InventoryObjectivePart inventoryObjectivePartClone = new InventoryObjectivePart();
    inventoryObjectivePartClone.copy(inventoryObjectivePart);
	
	return inventoryObjectivePartClone;
}

/******************************************* InventoryObjectivePartDtl ***********************************************************/        
public
InventoryObjectivePartDtl createInventoryObjectivePartDtl(){
	return new InventoryObjectivePartDtl();
}

public
InventoryObjectivePartDtlContainer createInventoryObjectivePartDtlContainer(){
	return new InventoryObjectivePartDtlContainer();
}

public
InventoryObjectiveReportView createInventoryObjectiveReportView(){
	return new InventoryObjectiveReportView();
}

private
InventoryObjectivePartDtl objectDataBaseToObject(InventoryObjectivePartDtlDataBase inventoryObjectivePartDtlDataBase){
	InventoryObjectivePartDtl inventoryObjectivePartDtl = new InventoryObjectivePartDtl();

	inventoryObjectivePartDtl.HdrId=inventoryObjectivePartDtlDataBase.getHdrId();
	inventoryObjectivePartDtl.Detail=inventoryObjectivePartDtlDataBase.getDetail();
	inventoryObjectivePartDtl.SubDtl=inventoryObjectivePartDtlDataBase.getSubDtl();
	inventoryObjectivePartDtl.DateObjective=inventoryObjectivePartDtlDataBase.getDateObjective();
	inventoryObjectivePartDtl.DaysOnHand=inventoryObjectivePartDtlDataBase.getDaysOnHand();
	inventoryObjectivePartDtl.Qty=inventoryObjectivePartDtlDataBase.getQty();
	inventoryObjectivePartDtl.QtyReported=inventoryObjectivePartDtlDataBase.getQtyReported();

	return inventoryObjectivePartDtl;
}

private
InventoryObjectivePartDtlDataBase objectToObjectDataBase(InventoryObjectivePartDtl inventoryObjectivePartDtl){
	InventoryObjectivePartDtlDataBase inventoryObjectivePartDtlDataBase = new InventoryObjectivePartDtlDataBase(dataBaseAccess);
	inventoryObjectivePartDtlDataBase.setHdrId(inventoryObjectivePartDtl.HdrId);
	inventoryObjectivePartDtlDataBase.setDetail(inventoryObjectivePartDtl.Detail);
	inventoryObjectivePartDtlDataBase.setSubDtl(inventoryObjectivePartDtl.SubDtl);
	inventoryObjectivePartDtlDataBase.setDateObjective(inventoryObjectivePartDtl.DateObjective);
	inventoryObjectivePartDtlDataBase.setDaysOnHand(inventoryObjectivePartDtl.DaysOnHand);
	inventoryObjectivePartDtlDataBase.setQty(inventoryObjectivePartDtl.Qty);
	inventoryObjectivePartDtlDataBase.setQtyReported(inventoryObjectivePartDtl.QtyReported);

	return inventoryObjectivePartDtlDataBase;
}

public
InventoryObjectivePartDtl cloneInventoryObjectivePartDtl(InventoryObjectivePartDtl inventoryObjectivePartDtl){
	InventoryObjectivePartDtl inventoryObjectivePartDtlClone = new InventoryObjectivePartDtl();
    inventoryObjectivePartDtlClone.copy(inventoryObjectivePartDtl);
	
	return inventoryObjectivePartDtlClone;
}

public
InventoryObjectiveHdr recalcAutomaticObjectives(string splant){ 
    InventoryObjectiveHdr                   inventoryObjectiveHdr  = null;
    try{
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        if (string.IsNullOrEmpty(splant)){
            PltDataBaseContainer pltDataBaseContainer = new PltDataBaseContainer(dataBaseAccess);
	        pltDataBaseContainer.read();

            foreach(PltDataBase pltDataBase in pltDataBaseContainer)
                inventoryObjectiveHdr = recalcAutomaticObjectivesPlant(pltDataBase.getP_Plt());
        }else
            inventoryObjectiveHdr = recalcAutomaticObjectivesPlant(splant);

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
	}
    return inventoryObjectiveHdr;
}

public
InventoryObjectiveHdr recalcAutomaticObjectivesPlant(string splant){ 
    InventoryObjectiveHdr               inventoryObjectiveHdr  = null;    
    HotListHdr                          hotListHdr = readLastHotList(splant);
    inventoryObjectiveHdr  = readInventoryObjectiveHdrLast(splant);
    HotListContainer                    hotListContainer = null;
    HotList                             hotList = null;
    decimal                             dweeklyQty = 0;    
    decimal                             dweeklyMonQty =0;
    decimal                             dweeklySunQty =0;
    DateTime                            weeklyMonday = DateTime.Now;        
    DateTime                            weeklySunday = DateTime.Now;    
    InventoryObjectivePartDtlDataBase   inventoryObjectivePartDtlDataBase = new InventoryObjectivePartDtlDataBase(dataBaseAccess);
    
    if (hotListHdr!= null && inventoryObjectiveHdr!= null){
        
        hotListContainer = readHotListByFilters(hotListHdr.Id,"","","","",0,"",-1,"","",false,true,0);

        for (int i=0; i < inventoryObjectiveHdr.InventoryObjectivePartContainer.Count;i++) {
            InventoryObjectivePart inventoryObjectivePart = inventoryObjectiveHdr.InventoryObjectivePartContainer[i];

            if (inventoryObjectivePart.ObectivesAutomaticCalc.Equals(Constants.STRING_YES)){

                hotList = hotListContainer.getByPartSeq(inventoryObjectivePart.Part,inventoryObjectivePart.Seq);

                for (int j=0; hotList!=null && j < inventoryObjectivePart.InventoryObjectivePartDtlContainer.Count;j++) {
                    InventoryObjectivePartDtl inventoryObjectivePartDtl= inventoryObjectivePart.InventoryObjectivePartDtlContainer[j];
                    
                    DateUtil.getPriorMondayNextSundayFromDate(inventoryObjectivePartDtl.DateObjective, out weeklyMonday, out weeklySunday);

                    dweeklyMonQty = hotList != null ? hotList.getQtyByDate(hotListHdr.HotlistRunDate,weeklyMonday) : 0;
                    dweeklySunQty = hotList != null ? hotList.getQtyByDate(hotListHdr.HotlistRunDate,weeklySunday) : 0;
                    dweeklyQty = Math.Abs(dweeklySunQty) - Math.Abs(dweeklyMonQty);
                         
                    //weeklyqty /5 days X days on hand
                    inventoryObjectivePartDtl.Qty = (dweeklyQty / Constants.PRODUCTION_DAYS_PERWEEK) * inventoryObjectivePartDtl.DaysOnHand;

                    inventoryObjectivePartDtlDataBase = objectToObjectDataBase(inventoryObjectivePartDtl);
                    inventoryObjectivePartDtlDataBase.update();
                }
            }
        }
    }
    return inventoryObjectiveHdr;
}

public
InventoryObjectivePart generateNewInventoryObjectivePartBasedPlanned(InventoryObjectiveHdr inventoryObjectiveHdr, string splant,int imachineId,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart){
    InventoryObjectivePart  inventoryObjectivePart = null;    
    bool                    bwritePart = false;
    try{           
        /* we do not read InventoryObjective because take so much time, so we add record at the end                      
       
        */        
        if (inventoryObjectiveHdr == null)
            inventoryObjectiveHdr = createNewInventoryObjectiveHdr(splant);

        if (inventoryObjectiveHdr != null){           
            inventoryObjectivePart = inventoryObjectiveHdr.InventoryObjectivePartContainer.getByPartSeq(machineReportPartView.Part,machineReportPartView.Seq);

            if (inventoryObjectivePart == null){
                inventoryObjectivePart = createNewInventoryObjectivePart(machineReportPartView.Part, machineReportPartView.Seq);
                inventoryObjectiveHdr.InventoryObjectivePartContainer.Add(inventoryObjectivePart);                
                inventoryObjectiveHdr.fillRedundances(); //set Detail to new Part added
                bwritePart = true;
            }
            InventoryObjectivePartDtl inventoryObjectivePartDtl = inventoryObjectivePart.InventoryObjectivePartDtlContainer.getByRangeDate(cellMachinePart.StartDate,cellMachinePart.EndDate);                    

            if (inventoryObjectivePartDtl == null){
                inventoryObjectivePartDtl = new InventoryObjectivePartDtl();

                inventoryObjectivePartDtl.DateObjective = DateUtil.getNextFridayFromDate(cellMachinePart.StartDate);
                inventoryObjectivePart.InventoryObjectivePartDtlContainer.Add(inventoryObjectivePartDtl);
                inventoryObjectivePart.InventoryObjectivePartDtlContainer.sortByDate();

                ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
                prodFmInfoDataBase.setPFS_ProdID(inventoryObjectivePart.Part);
                if (prodFmInfoDataBase.read())
                    inventoryObjectivePartDtl.DaysOnHand = prodFmInfoDataBase.getPFS_DaysOnHand();
            }
            inventoryObjectivePartDtl.Qty = cellMachinePart.InvObjectives;
                        
            if (inventoryObjectiveHdr.Id > 0) {
                updateInventoryObjectivePart(inventoryObjectiveHdr,inventoryObjectivePart,bwritePart);                
            }else
                writeInventoryObjectiveHdr(inventoryObjectiveHdr);                                            
        }

        
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
    return inventoryObjectivePart;
}

public
InventoryObjectiveHdr createNewInventoryObjectiveHdr(string splant){
    InventoryObjectiveHdr inventoryObjectiveHdr = new InventoryObjectiveHdr();
    inventoryObjectiveHdr.Plant = splant;
    return inventoryObjectiveHdr;
}

public
InventoryObjectivePart createNewInventoryObjectivePart(string spart,int iseq){
    InventoryObjectivePart inventoryObjectivePart = new InventoryObjectivePart();
    inventoryObjectivePart.Part = spart;
    inventoryObjectivePart.Seq = iseq;

    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
    prodFmInfoDataBase.setPFS_ProdID(spart);
    if (prodFmInfoDataBase.read())
        inventoryObjectivePart.ObectivesAutomaticCalc = prodFmInfoDataBase.getPFS_ObectivesAutomaticCalc();

    return inventoryObjectivePart;
}

private
bool checkDateTimeStamp(InventoryObjectiveHdr inventoryObjectiveHdr, InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase) {
    bool bchanged=false;
    if (inventoryObjectiveHdr.DateTimeStamp != inventoryObjectiveHdrDataBase.readDateTimeStamp())
        throw new Exception("Inventory Objective " + Constants.DATETIME_STAMP_TABLE_MESSAGE);

    return bchanged;
}

public 
bool updateInventoryObjectivePart(InventoryObjectiveHdr inventoryObjectiveHdr,InventoryObjectivePart inventoryObjectivePart,bool bwritePart){
    try{
        bool bresult=false;

		if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

        updateInventoryObjectiveOnly(inventoryObjectiveHdr);        
               
        if (inventoryObjectivePart!= null) {                                     
            if (bwritePart){                
                InventoryObjectivePartDataBase inventoryObjectivePartDataBase = objectToObjectDataBase(inventoryObjectivePart);
                inventoryObjectivePartDataBase.write();
            }
            InventoryObjectivePartDtlDataBaseContainer inventoryObjectivePartDtlDataBaseContainer = new InventoryObjectivePartDtlDataBaseContainer(dataBaseAccess);
            inventoryObjectivePartDtlDataBaseContainer.deleteByHdr(inventoryObjectivePart.HdrId,inventoryObjectivePart.Detail);            
            writeInventoryObjectivePartChilds(inventoryObjectivePart);            
        }

	    if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        bresult=true;
        return bresult;

	}catch(PersistenceException persistenceException){		
        dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/********************************************** SchMaterialAvail  *******************************************************************/
public
SchMaterialAvail createSchMaterialAvail(){
	return new SchMaterialAvail();
}

public
SchMaterialAvailContainer createSchMaterialAvailContainer(){
	return new SchMaterialAvailContainer();
}

public
SchProductAvail createSchProductAvail(Product product){
	return new SchProductAvail(product);
}


public
bool existsSchMaterialAvail(int id){
	try{
		SchMaterialAvailDataBase schMaterialAvailDataBase = new SchMaterialAvailDataBase(dataBaseAccess);

		schMaterialAvailDataBase.setId(id);

		return schMaterialAvailDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
SchMaterialAvail readSchMaterialAvail(int id){
	try{
		SchMaterialAvailDataBase schMaterialAvailDataBase = new SchMaterialAvailDataBase(dataBaseAccess);
		schMaterialAvailDataBase.setId(id);

		if (!schMaterialAvailDataBase.read())
			return null;

		SchMaterialAvail schMaterialAvail = this.objectDataBaseToObject(schMaterialAvailDataBase);

		return schMaterialAvail;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateSchMaterialAvail(SchMaterialAvail schMaterialAvail){
	 try{
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchMaterialAvailDataBase schMaterialAvailDataBase = this.objectToObjectDataBase(schMaterialAvail);
		schMaterialAvailDataBase.update();

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
	}
}

public 
void writeSchMaterialAvail(SchMaterialAvail schMaterialAvail){
	 try{
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchMaterialAvailDataBase schMaterialAvailDataBase = this.objectToObjectDataBase(schMaterialAvail);
		schMaterialAvailDataBase.write();

		schMaterialAvail.Id=schMaterialAvailDataBase.getId();

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
	}
}

public
void deleteSchMaterialAvail(int id){
	 try{
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchMaterialAvailDataBase schMaterialAvailDataBase = new SchMaterialAvailDataBase(dataBaseAccess);

		schMaterialAvailDataBase.setId(id);
		schMaterialAvailDataBase.delete();

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
	}
}

private
SchMaterialAvail objectDataBaseToObject(SchMaterialAvailDataBase schMaterialAvailDataBase){
	SchMaterialAvail schMaterialAvail = new SchMaterialAvail();

	schMaterialAvail.Id=schMaterialAvailDataBase.getId();
    schMaterialAvail.Plant = schMaterialAvailDataBase.getPlant();
	schMaterialAvail.DateCreated=schMaterialAvailDataBase.getDateCreated();
	schMaterialAvail.ParentSrcHotId=schMaterialAvailDataBase.getParentSrcHotId();
    schMaterialAvail.ParentSrcHotDtlId=schMaterialAvailDataBase.getParentSrcHotDtlId();
	schMaterialAvail.ParentPart=schMaterialAvailDataBase.getParentPart();
	schMaterialAvail.ParentSeq=schMaterialAvailDataBase.getParentSeq();
    schMaterialAvail.ParentQtyAdjust = schMaterialAvailDataBase.getParentQtyAdjust();
	schMaterialAvail.MaxQty=schMaterialAvailDataBase.getMaxQty();
	schMaterialAvail.MaxUOM=schMaterialAvailDataBase.getMaxUOM();
	schMaterialAvail.ChildSource=schMaterialAvailDataBase.getChildSource();
	schMaterialAvail.ChildPart=schMaterialAvailDataBase.getChildPart();
	schMaterialAvail.ChildSeq=schMaterialAvailDataBase.getChildSeq();
	schMaterialAvail.ChildQty=schMaterialAvailDataBase.getChildQty();
	schMaterialAvail.ChildCumulativeQOH=schMaterialAvailDataBase.getChildCumulativeQOH();
	schMaterialAvail.ChildAvailQty=schMaterialAvailDataBase.getChildAvailQty();
	schMaterialAvail.DateTime=schMaterialAvailDataBase.getDateTime();
	schMaterialAvail.CounterParentSrcHotId=schMaterialAvailDataBase.getCounterParentSrcHotId();

	return schMaterialAvail;
}

private
SchMaterialAvailDataBase objectToObjectDataBase(SchMaterialAvail schMaterialAvail){
	SchMaterialAvailDataBase schMaterialAvailDataBase = new SchMaterialAvailDataBase(dataBaseAccess);
	schMaterialAvailDataBase.setId(schMaterialAvail.Id);
    schMaterialAvailDataBase.setPlant(schMaterialAvail.Plant);
	schMaterialAvailDataBase.setDateCreated(schMaterialAvail.DateCreated);
	schMaterialAvailDataBase.setParentSrcHotId(schMaterialAvail.ParentSrcHotId);
    schMaterialAvailDataBase.setParentSrcHotDtlId(schMaterialAvail.ParentSrcHotDtlId);
	schMaterialAvailDataBase.setParentPart(schMaterialAvail.ParentPart);
    schMaterialAvailDataBase.setParentQtyAdjust(schMaterialAvail.ParentQtyAdjust);
	schMaterialAvailDataBase.setParentSeq(schMaterialAvail.ParentSeq);
	schMaterialAvailDataBase.setMaxQty(schMaterialAvail.MaxQty);
	schMaterialAvailDataBase.setMaxUOM(schMaterialAvail.MaxUOM);
	schMaterialAvailDataBase.setChildSource(schMaterialAvail.ChildSource);
	schMaterialAvailDataBase.setChildPart(schMaterialAvail.ChildPart);
	schMaterialAvailDataBase.setChildSeq(schMaterialAvail.ChildSeq);
	schMaterialAvailDataBase.setChildQty(schMaterialAvail.ChildQty);
	schMaterialAvailDataBase.setChildCumulativeQOH(schMaterialAvail.ChildCumulativeQOH);
	schMaterialAvailDataBase.setChildAvailQty(schMaterialAvail.ChildAvailQty);
	schMaterialAvailDataBase.setDateTime(schMaterialAvail.DateTime);
	schMaterialAvailDataBase.setCounterParentSrcHotId(schMaterialAvail.CounterParentSrcHotId);

	return schMaterialAvailDataBase;
}

public
SchMaterialAvail cloneSchMaterialAvail(SchMaterialAvail schMaterialAvail){
	SchMaterialAvail schMaterialAvailClone = new SchMaterialAvail();

	schMaterialAvailClone.Id=schMaterialAvail.Id;
    schMaterialAvailClone.Plant = schMaterialAvail.Plant;
    schMaterialAvailClone.DateCreated=schMaterialAvail.DateCreated;
	schMaterialAvailClone.ParentSrcHotId=schMaterialAvail.ParentSrcHotId;
    schMaterialAvailClone.ParentSrcHotDtlId=schMaterialAvail.ParentSrcHotDtlId;
	schMaterialAvailClone.ParentPart=schMaterialAvail.ParentPart;
	schMaterialAvailClone.ParentSeq=schMaterialAvail.ParentSeq;
    schMaterialAvailClone.ParentQtyAdjust = schMaterialAvail.ParentQtyAdjust;
    schMaterialAvailClone.MaxQty=schMaterialAvail.MaxQty;
	schMaterialAvailClone.MaxUOM=schMaterialAvail.MaxUOM;
	schMaterialAvailClone.ChildSource=schMaterialAvail.ChildSource;
	schMaterialAvailClone.ChildPart=schMaterialAvail.ChildPart;
	schMaterialAvailClone.ChildSeq=schMaterialAvail.ChildSeq;
	schMaterialAvailClone.ChildQty=schMaterialAvail.ChildQty;
	schMaterialAvailClone.ChildCumulativeQOH=schMaterialAvail.ChildCumulativeQOH;
	schMaterialAvailClone.ChildAvailQty=schMaterialAvail.ChildAvailQty;
	schMaterialAvailClone.DateTime=schMaterialAvail.DateTime;
	schMaterialAvailClone.CounterParentSrcHotId=schMaterialAvail.CounterParentSrcHotId;

	return schMaterialAvailClone;
}

public
SchMaterialAvailContainer readSchMaterialAvailByFilters(string splant,int parentSrcHotId, int parentSrcHotDtlId, int notParentSrcHotDtlId, string sparentPart, int partentSeq, string schildPart, int childSeq,DateTime dateTime,bool blastSeq,int rows){
	try{
        SchMaterialAvailContainer   schMaterialAvailContainer = new SchMaterialAvailContainer();
        SchMaterialAvail            schMaterialAvail=null;

        SchMaterialAvailDataBaseContainer schMaterialAvailDataBaseContainer = new SchMaterialAvailDataBaseContainer(dataBaseAccess);
		schMaterialAvailDataBaseContainer.readByFilters(splant, parentSrcHotId, parentSrcHotDtlId, notParentSrcHotDtlId, sparentPart, partentSeq,schildPart,childSeq,dateTime, blastSeq, rows);	
        
        foreach(SchMaterialAvailDataBase schMaterialAvailDataBase in schMaterialAvailDataBaseContainer){
            schMaterialAvail = objectDataBaseToObject(schMaterialAvailDataBase);
            schMaterialAvailContainer.Add(schMaterialAvail);
        }

		return schMaterialAvailContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

} // class

} // namespace