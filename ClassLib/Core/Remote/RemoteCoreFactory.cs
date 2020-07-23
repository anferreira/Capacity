using System;
using System.Collections;

// Remoting libraries
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

// Nujit framework libraries
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Core.ExcelReports;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.Core.Remote;

// configuration and parameters
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Reports;

using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.Core.Cms.PackSlips;
using Nujit.NujitERP.ClassLib.Core.Customer;

namespace Nujit.NujitERP.ClassLib.Core.Remote{

/// <summary>
/// Class used for connect to a remote instance of a CoreFactory object
/// This class is used in the client-side
/// </summary>
public 
class RemoteCoreFactory : CoreFactory{

// protocol used, values are : tcp or http
private string protocol = "tcp";

// communication channel
private TcpChannel tcpChannel;

// remote instance
private CoreFactory coreFactory;

/// <summary>
/// Constructor : Here is linked the remote object
/// </summary>
public
RemoteCoreFactory(){
	if (ChannelServices.RegisteredChannels.Length != 0){
		foreach(IChannel oldChannel in ChannelServices.RegisteredChannels)
			ChannelServices.UnregisterChannel(oldChannel);
	}

	// build a new channel
	tcpChannel = new TcpChannel(0);

	// register the channel
	ChannelServices.RegisterChannel(tcpChannel);

    // make a new url    
	string url = protocol + "://" + Configuration.ServerIp + ":" + Configuration.ServerPort + "/" + 
			Configuration.ServiceName;

	// link the remote object
	coreFactory = (CoreFactory)Activator.GetObject(typeof(CoreFactory), url);
}

/// <summary>
/// Destructor : used for broke the link between server and client
/// </summary>
//~RemoteCoreFactory(){
//	tcpChannel.StopListening(null);
//	ChannelServices.UnregisterChannel(tcpChannel);
//}

public
void beginTransaction(){
	coreFactory.beginTransaction();
}

public
void commitTransaction(){
	coreFactory.commitTransaction();
}

public
void rollbackTransaction(){
	coreFactory.rollbackTransaction();
}

#region CMS

public
int cms400ToCmsTempItems(string splant){
	return coreFactory.cms400ToCmsTempItems(splant);
}

public
int cmsTempToNujitItems(string splant){
	return coreFactory.cmsTempToNujitItems(splant);
}

public
int generateCMSItems(string splant,bool bstoreTemp){
	return coreFactory.generateCMSItems(splant,bstoreTemp);
}

public 
string[] generateCMSDeptsRecords(){
	return coreFactory.generateCMSDeptsRecords();
}

public 
int cms400ToCmsTempDepts(){
	return coreFactory.cms400ToCmsTempDepts();
}

public 
string[] cmsTempToNujitDepts(){
	return coreFactory.cmsTempToNujitDepts();
}

public 
int cms400ToCmsTempPlnt(){
	return coreFactory.cms400ToCmsTempPlnt();
}

public 
int cmsTempToNujitPlt(){
	return coreFactory.cmsTempToNujitPlt();
}

public 
int generateCMSPlt(){
	return coreFactory.generateCMSPlt();
}

public
int generateCMSMachineRecords(){
	return coreFactory.generateCMSMachineRecords();
}

public
int cms400ToCmsTempMachines(){
	return coreFactory.cms400ToCmsTempMachines();
}

public
int cmsTempToNujitMachines(){
	return coreFactory.cmsTempToNujitMachines();
}

public 
int generateCMSStkr(){
	return coreFactory.generateCMSStkr();
}

public
int cms400ToCmsTempStkr(){
	return coreFactory.cms400ToCmsTempStkr();
}

public
int cmsTempToNujitStkr(){
	return coreFactory.cmsTempToNujitStkr();
}

public
void generateSchPrOrdMat(){
	coreFactory.generateSchPrOrdMat();
}

public
void generateMaterialRecords(){
	coreFactory.generateMaterialRecords();
}

public
void restoreInvalidsSeqs(){
	coreFactory.restoreInvalidsSeqs();
}

public 
int CMSFamilyCopy(){
	return coreFactory.CMSFamilyCopy();
}

public
int cms400ToCmsTempFamily(){
	return coreFactory.cms400ToCmsTempFamily();
}

public
int cmsTempToNujitFamily(){
	return coreFactory.cmsTempToNujitFamily();
}

public 
void generateCMSCust(){
	coreFactory.generateCMSCust();
}

public
int cms400ToCmsTempCust(){
	return coreFactory.cms400ToCmsTempCust();
}

public 
int generateCMSVend(){
	return coreFactory.generateCMSVend();
}

public
int cms400ToCmsTempVend(){
	return coreFactory.cms400ToCmsTempVend();
}

public 
int cmsTempToNujitCustVend(){
	return coreFactory.cmsTempToNujitCustVend();
}

public 
int generateCustVend(){
	return coreFactory.generateCustVend();
}

public 
int generateCMSJitToDelJit(){
	return coreFactory.generateCMSJitToDelJit();
}

public 
int cms400ToCmsTempJith(){
	return coreFactory.cms400ToCmsTempJith();
}

public 
void generateCMSJitd(){
	coreFactory.generateCMSJitd();
}

public 
int cms400ToCmsTempJitd(){
	return coreFactory.cms400ToCmsTempJitd();
}

public 
int generateRRLToDelFor(){
	return coreFactory.generateRRLToDelFor();
}

public 
void generateCMSRrlh(){
	coreFactory.generateCMSRrlh();
}

public 
int cms400ToCmsTempRrlh(){
	return coreFactory.cms400ToCmsTempRrlh();
}

public 
void generateCMSRrld(){
	coreFactory.generateCMSRrld();
}

public 
int cms400ToCmsTempRrld(){
	return coreFactory.cms400ToCmsTempRrld();
}

public 
int cmsTempToNujitDelJit(){
	return coreFactory.cmsTempToNujitDelJit();
}

public 
int cmsTempToNujitDelFor(){
	return coreFactory.cmsTempToNujitDelFor();
}

public 
int generateCMSPrhist(){
	return coreFactory.generateCMSPrhist();
}

public 
int cms400ToCmsTempPrhist(){
	return coreFactory.cms400ToCmsTempPrhist();
}


public 
int generateCMSTrlp(){
	return coreFactory.generateCMSTrlp();
}

public 
int cms400ToCmsTempTrlp(){
	return coreFactory.cms400ToCmsTempTrlp();
}

public 
int generateCMSTrpl(){
	return coreFactory.generateCMSTrpl();
}

public 
int cms400ToCmsTempTrpl(){
	return coreFactory.cms400ToCmsTempTrpl();
}

public 
int generateCMSTrpt(){
	return coreFactory.generateCMSTrpt();
}

public 
int cms400ToCmsTempTrpt(){
	return coreFactory.cms400ToCmsTempTrpt();
}


public 
int generateCmsCustPart(){
	return coreFactory.generateCmsCustPart();
}

public
int cms400ToCmsTempCspt(){
	return coreFactory.cms400ToCmsTempCspt();
}

public 
int cmsTempToNujitCustPart(){
	return coreFactory.cmsTempToNujitCustPart();
}

public 
int cmsTempToNujitTPPartCrossRef(){
	return coreFactory.cmsTempToNujitTPPartCrossRef();
}

public 
int cms400ToCmsTempBols(){
	return coreFactory.cms400ToCmsTempBols();
}

public 
int cms400ToCmsTempRaca(){
	return coreFactory.cms400ToCmsTempRaca();
}

public 
int generateCMSEmployee(){
	return coreFactory.generateCMSEmployee();
}

public
int cms400ToCmsTempEmployee(){
	return coreFactory.cms400ToCmsTempEmployee();
}

public
int cmsTempToNujitEmployee(){
	return coreFactory.cmsTempToNujitEmployee();
}

public
int cmsCmsNujitEmployeeAssignShift(){
	return coreFactory.cmsCmsNujitEmployeeAssignShift();
}

public
int cmsTempToNujitMmgp(){
	return coreFactory.cmsTempToNujitMmgp();
}
	
public
int cms400ToCmsTempMmgp(){
	return coreFactory.cms400ToCmsTempMmgp();
}

public
int generateCMSMmgp(){
	return coreFactory.generateCMSMmgp();
}

public 
int generateCmsPrHistLbHist(){
    return coreFactory.generateCmsPrHistLbHist();	
}


public 
int generateCmsLbHist(){
   return coreFactory.generateCmsLbHist();	
}

//LbHist
public
int cms400ToCmsTempLbHist(){
	return coreFactory.cms400ToCmsTempLbHist();		
}

public
int cmsTempToNujitMeHistMach(){
	return coreFactory.cmsTempToNujitMeHistMach();		
}

public
int cmsTempToNujitMeHistLab(){
	return coreFactory.cmsTempToNujitMeHistLab();		
}

public
int cms400ToCmsTempPssc(){
	return coreFactory.cms400ToCmsTempPssc();
}

public
int cmsTempToNujitPssc(){
	return coreFactory.cmsTempToNujitPssc();
}

public
int cms400ToNujitPssc(){
	return coreFactory.cms400ToNujitPssc();
}

public
int cms400ToCmsTempScrap(){
	return coreFactory.cms400ToCmsTempScrap();
}

public
int cmsTempToNujitScrap(){
	return coreFactory.cmsTempToNujitScrap();
}

public
int cms400ToNujitScrap(){
	return coreFactory.cms400ToNujitScrap();
}

public
int cms400ToCmsTempSprsn(){
	return coreFactory.cms400ToCmsTempSprsn();
}

public
int cmsTempToNujitSprsn(){
	return coreFactory.cmsTempToNujitSprsn();
}

public
int cms400ToNujitSprsn(){
	return coreFactory.cms400ToNujitSprsn();
}

public 
int generateCMSIcstm(){
    return coreFactory.generateCMSIcstm();
}

public
int cms400ToCmsTempIcstm(){
    return coreFactory.cms400ToCmsTempIcstm();
}


public 
int generateCMSIcstp(){
    return coreFactory.generateCMSIcstp();
}

public
int cmsTempToNujitIcstm(){
    return coreFactory.cmsTempToNujitIcstm();
}

public
int cms400ToCmsTempIcstp(){
    return coreFactory.cms400ToCmsTempIcstp();
}

public
int cmsTempToNujitIcstp(){
    return coreFactory.cmsTempToNujitIcstp();
}

public 
int generateCMSSeri(){
    return coreFactory.generateCMSSeri();
}

public 
int cms400ToCmsTempSeri(){
    return coreFactory.cms400ToCmsTempSeri();
}

public 
int cmsTempToNujitSeri(){
    return coreFactory.cmsTempToNujitSeri();
}


public 
int generateCMSMainMat(){
    return coreFactory.generateCMSMainMat();
}

public 
int cms400ToCmsTempMainMat(){
    return coreFactory.cms400ToCmsTempMainMat();
}

public 
int cmsTempToNujitMainMat(){
    return coreFactory.cmsTempToNujitMainMat();
}

public
MainMat createMainMat(){
    return coreFactory.createMainMat();
}

public
MainMatContainer createMainMatContainer(){
    return coreFactory.createMainMatContainer();
}

public
bool existsMainMat(string pART, int dTL){
    return coreFactory.existsMainMat(pART,dTL);
}

public
MainMat readMainMat(string pART){
    return coreFactory.readMainMat(pART);
}

public
MainMatContainer readMainMatByFilters(string pART,string smainPart,bool bonlyHeaders,int rows){
    return coreFactory.readMainMatByFilters(pART, smainPart, bonlyHeaders, rows);
}
	
public
void updateMainMat(MainMat mainMat){
    coreFactory.updateMainMat(mainMat);
}
    
public
void writeMainMat(MainMat mainMat){
    coreFactory.writeMainMat(mainMat);
}


public 
string[][] getReport1268OnCVSFormat(){
    return coreFactory.getReport1268OnCVSFormat();
}
    
public
BolContainer readBolByFilters(string sferteg ,decimal dorder,bool borderByBol,int rows){
    return coreFactory.readBolByFilters(sferteg, dorder, borderByBol, rows);
}

#endregion

#region BOM

// Methods are implemented here
public
BomContainer createBomContainer(){
	return coreFactory.createBomContainer();
}
 
public
BomObjectivesView createBomObjectivesView(Bom bom){
	return coreFactory.createBomObjectivesView(bom);
}

public 
string[][] getProdBOMChild(string prodId, int seqId){
	return coreFactory.getProdBOMChild(prodId, seqId); // here is invoked the remote method (server)
}

public 
string[][] getParentMaterials(string matId, int seqId){
	return coreFactory.getParentMaterials(matId, seqId);
}

public 
int QtyInSubmaterialsOf(string matSrch, int matSrchSeq, string matId, int matSeq){
	return coreFactory.QtyInSubmaterialsOf(matSrch, matSrchSeq, matId, matSeq);
}

public 
string[][] getSubMaterials(string matId, int seqId){
	return coreFactory.getSubMaterials(matId, seqId);
}

public 
BomSumContainer getSubMaterialsMainLevel(string matId, int seqId,string splant){
	return coreFactory.getSubMaterialsMainLevel(matId, seqId,splant);
}

public 
BomSumContainer getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(string matId, int seqId,string splant,string sreportingPoint,int iminorSeqRows){
	return coreFactory.getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(matId, seqId, splant, sreportingPoint,iminorSeqRows);
}

public
BomSum createBomSum(){
	return coreFactory.createBomSum();
}

public
BomSumContainer createBomSumContainer(){
	return coreFactory.createBomSumContainer();
}

public 
bool existsBomSum(string prodID, int seq, string matID, int matSeq){
	return coreFactory.existsBomSum(prodID, seq, matID, matSeq);
}

public 
bool existsBomSumObj(BomSum bomSumObj){
	return coreFactory.existsBomSumObj(bomSumObj);
}

public 
BomSum readBomSum(string prodID, int seq, string matID, int matSeq){
	return coreFactory.readBomSum(prodID, seq, matID, matSeq);
}

public 
void writeBomSum(BomSum bomSum){
	coreFactory.writeBomSum(bomSum);
}

public 
void updateBomSum(BomSum bomSum){
	coreFactory.updateBomSum(bomSum);
}

public 
void deleteBomSum(BomSum bomSum){
	coreFactory.deleteBomSum(bomSum);
}

public 
BomSumTempContainer readBomSumTreeProdSeq(string prodId, int prodSeq){
	return coreFactory.readBomSumTreeProdSeq(prodId, prodSeq);
}

public 
BomSumTempContainer readBomSumTree(BomSumTempContainer bomSumTempContainer, string prodId, int prodSeq){
	return coreFactory.readBomSumTree(bomSumTempContainer, prodId, prodSeq);
}

public 
void updateBomSumTempContainer(BomSumTempContainer bomSumTempContainer){
	coreFactory.updateBomSumTempContainer(bomSumTempContainer);
}

public
BomContainer makeBoms(string splant){
	return coreFactory.makeBoms(splant);
}

public
Bom makeBom(string prodId, int seqId, string splant){
	return coreFactory.makeBom(prodId, seqId, splant);
}

public
void loadInfoForBom(){
	coreFactory.loadInfoForBom();
}

public
void discardInfoForBom(){
	coreFactory.discardInfoForBom();
}

public Bom
makeBomFromProdIDAndSeq (string prodId, int seqId,string splant){
	return coreFactory.makeBomFromProdIDAndSeq (prodId, seqId,splant);
}

public
void seeBom(Bom bom, string parent){
	coreFactory.seeBom(bom, parent);
}

public
string[][] getAllPurchasedMaterials(string prodId, int seqId,string splant){
	return coreFactory.getAllPurchasedMaterials(prodId, seqId,splant);
}

public
ArrayList getAllPurchasedMaterialsFromBom(Bom bom, ArrayList lst){
	return coreFactory.getAllPurchasedMaterialsFromBom(bom, lst);
}

public
string[][] getErrorsBom(){
	return coreFactory.getErrorsBom();
}

#endregion 

#region DEPTS

public
string[] getDepartamentCodes(){
	return coreFactory.getDepartamentCodes();
}

public
string[] getDepartamentCodesByPlt(string plt){
	return coreFactory.getDepartamentCodesByPlt(plt);
}

public 
string[] getAllDeptFromHotListAsString(){
	return coreFactory.getAllDeptFromHotListAsString();
}

public
string getDepartamentDescription(string dept){
	return coreFactory.getDepartamentDescription(dept);
}

public
string getPlantCodeByDept(string departamentCode){
	return coreFactory.getPlantCodeByDept(departamentCode);
}

public
string[][] getDepartmentByDesc(string desc, string db, int company, string plt){
	return coreFactory.getDepartmentByDesc (desc, db, company, plt);
}

#endregion

#region HotList

public
void createHotList(string[] stkbFilter, string[] wipbFilter, string[][] badWipb,int demandHdrId,string splant){
	coreFactory.createHotList(stkbFilter, wipbFilter, badWipb, demandHdrId,splant);
}

public
void createHotListDemand(DemandH demandH,bool bcreateCapacity){
	coreFactory.createHotListDemand(demandH,bcreateCapacity);
}

public 
string[][] getHotListAsString(int id,string splantOriginal,string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	return coreFactory.getHotListAsString(id, splantOriginal,filterDept, filterPart, filterMg, onlyDemand, type);
}

public 
string[][] getDemandAsString(string[] filterPart,string splant){
	return coreFactory.getDemandAsString(filterPart,splant);
}

public
string[][] getHotListAsStringNew(int id,string splantHotList,string splant,string sdept,string machine, int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,string sprodFamily,int idaysWithQty,bool borderByDemand, bool bgetCumulativeQty,bool bqohAffects,bool baddReceipParts,bool baddMaterialConsumPart, int rows){
	return coreFactory.getHotListAsStringNew(id, splantHotList, splant, sdept, machine, imachineId, spart,iseq, sglExp, sreportedPoint, sprodFamily, idaysWithQty,borderByDemand, bgetCumulativeQty, bqohAffects, baddReceipParts, baddMaterialConsumPart, rows);
}

public
HotListContainer getHotListAsStringNew2(int id,string splantHotList,string splant,string sdept,string machine, int imachineId,string spart,int iseq, string smajorGroup,string sglExp,string sreportedPoint, string sprodFamily,bool borderByDemand, bool bgetCumulativeQty,bool baddReceipParts,bool baddMaterialConsumPart, int rows){
	return coreFactory.getHotListAsStringNew2(id, splantHotList, splant, sdept, machine, imachineId, spart,iseq, smajorGroup, sglExp, sreportedPoint,sprodFamily,borderByDemand, bgetCumulativeQty, baddReceipParts, baddMaterialConsumPart, rows);
}

public
HotListContainer getHotListInvAnalysis(int id,string splantHotList,string splant,string sdept,string machine, int imachineId,string spart,int iseq, string smajorGroup,string sglExp,string sreportedPoint,int idaysWithQty,bool borderByDemand, bool bgetCumulativeQty,bool bqohAffects,bool baddReceipParts,bool baddMaterialConsumPart, int rows){
	return coreFactory.getHotListInvAnalysis(id, splantHotList, splant, sdept, machine, imachineId, spart,iseq, smajorGroup, sglExp,sreportedPoint, idaysWithQty, borderByDemand, bgetCumulativeQty, bqohAffects, baddReceipParts, baddMaterialConsumPart, rows);
}
        
public 
string[][] getActiveDemandAsStringByDate(DateTime dateFrom, DateTime dateTo){
	return coreFactory.getActiveDemandAsStringByDate(dateFrom, dateTo);
}

public
string[][] getDemandAsStringByDate(DateTime dateFrom, DateTime dateTo){
	return coreFactory.getDemandAsStringByDate(dateFrom, dateTo);
}

public 
string[][] getHotListAsStringByDemand(bool onlyDemand){
	return coreFactory.getHotListAsStringByDemand(onlyDemand);
}

public
string[][] getAllMatReqAsString(string[] depts, string[]parts,string splant ){
	return coreFactory.getAllMatReqAsString(depts, parts,splant);
}

public
void generateReleases(string startSupplier, string endSupplier,
		string startPart, string endPart){
	coreFactory.generateReleases(startSupplier, endSupplier, startPart, endPart);
}

public
string[][] getReleasesAsString(string startSupplier, string endSupplier,
		string startPart, string endPart){
	return coreFactory.getReleasesAsString(startSupplier, endSupplier,
		startPart, endPart);
}

public
string[][] getVendorReleaseInquiry(bool weeks){
	return coreFactory.getVendorReleaseInquiry(weeks);
}

public 
string[] getAllPartFromHotListAsString(int id, bool inactive){
	return coreFactory.getAllPartFromHotListAsString(id, inactive);
}

public 
string[] getAllMGFromHotListAsString(int id){
	return coreFactory.getAllMGFromHotListAsString(id); 
}

public
string[] getHotListLogData(){
	return coreFactory.getHotListLogData();
}

public
string[][] getHotListLogHist(){
	return coreFactory.getHotListLogHist();
}

public 
string[][] getHotListReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, 
			string type, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint, 
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp){

	return coreFactory.getHotListReport(id,filterDept, filterPart, filterMg, onlyDemand, type, byMinorGroup,
			accumOnFridays, onlyReportingPoint, hoursReport, orderByResource, labourReport, orderByMajorMinorGrp);
}

public 
string[][] getHotListReportByPart(int id, string byPart){
	return coreFactory.getHotListReportByPart(id,byPart);
}

public
string[][] getMaterialDueDate(bool weeks, string[] depts, string[] parts, bool orderByVendor, string[] stkLocs,string splant){
	return coreFactory.getMaterialDueDate(weeks, depts, parts, orderByVendor, stkLocs,splant);
}

public
void blockHotList(){
	coreFactory.blockHotList();
}

public
bool isHotListBlocked(){
	return coreFactory.isHotListBlocked();
}

public
void unBlockHotList(){
	coreFactory.unBlockHotList();
}

public
HotListHdr createHotListHdr(){
	return coreFactory.createHotListHdr();
}

public
HotListHdrContainer createHotListHdrContainer(){
    return coreFactory.createHotListHdrContainer();
}

public
HotListHdr readHotListHdr(int id){
    return coreFactory.readHotListHdr(id);
}

public
HotList createHotList(){
    return coreFactory.createHotList();
}

public
HotListContainer createHotListContainer(){
    return coreFactory.createHotListContainer();
}

public
HotListDay createHotListDay(){
    return coreFactory.createHotListDay();
} 

public
HotListInvAnalysisView createHotListInvAnalysisView(){
    return coreFactory.createHotListInvAnalysisView();
}

public
HotListInvAnalysisView cloneHotListInvAnalysisView(HotListInvAnalysisView hotListInvAnalysisView){
    return coreFactory.cloneHotListInvAnalysisView(hotListInvAnalysisView);
}

public
HotListContainer readHotListByFilters(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sreportedPoint, string sprodFamily,bool borderByDemand,bool bgetCumulativeQty,int rows){
    return coreFactory.readHotListByFilters(id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq, sreportedPoint,sprodFamily, borderByDemand, bgetCumulativeQty,rows);
}

public
HotListContainer readHotListByFiltersWeekly(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq, string smajorGroup,string sglExp,string sreportedPoint,int idaysWithQoh,bool borderByDemand,bool bgetCumulativeQty,int rows){
    return coreFactory.readHotListByFiltersWeekly(id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq, smajorGroup, sglExp,sreportedPoint,idaysWithQoh,borderByDemand, bgetCumulativeQty,rows);
}

public
HotListContainer readHotListByFiltersWeekly2(ArrayList arrayFieldList,int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq, string smajorGroup,string sglExp,string sreportedPoint,int idaysWithQty, bool borderByDemand,bool bgetCumulativeQty,bool bqohAffects,int rows){
    return coreFactory.readHotListByFiltersWeekly2(arrayFieldList,id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq, smajorGroup, sglExp, sreportedPoint,idaysWithQty,borderByDemand,bgetCumulativeQty,bqohAffects,rows);
}


public
HotListHdrContainer readLastHotListHdrDifferentsPlants(){
    return coreFactory.readLastHotListHdrDifferentsPlants();
}

public
HotListHdr readLastHotList(string splant){
    return coreFactory.readLastHotList(splant);
}

public
HotListHdr readPriorLastHotList(string splant){
    return coreFactory.readPriorLastHotList(splant);
}

public
HotListHourContainer getHotListHoursDays(int id){
	return coreFactory.getHotListHoursDays(id);
}

public
string[][] geHotListTotals(int id1, int id2){
	return coreFactory.geHotListTotals(id1, id2);
}

public 
string[][] getHotListBomReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
			bool onlyDemand, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint,
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp,
			bool orderByPart){

	return coreFactory.getHotListBomReport(id, filterDept, filterPart, filterMg, onlyDemand, byMinorGroup, 
			accumOnFridays, onlyReportingPoint, hoursReport, orderByResource, labourReport, 
			orderByMajorMinorGrp, orderByPart);
}

#endregion

#region Inventory

public 
void updateInventory(Inventory inventory){
	coreFactory.updateInventory(inventory);
}

public 
bool existsInventory(string prodId,string splant){
	return coreFactory.existsInventory(prodId,splant);
}

public 
Inventory readInventory(string prodId,string splant){
	return coreFactory.readInventory(prodId, splant);
}

public
decimal getQtyOnHandForProduct(string prodId){
	return coreFactory.getQtyOnHandForProduct(prodId);
}

public 
string[][] getAllPltInvLocAsString(){
	return coreFactory.getAllPltInvLocAsString();
}

public 
string[][] getInventoryReport(string prodId){
	return coreFactory.getInventoryReport(prodId);
}

public 
string[][] getInventoryForSchedule(string splantOriginal,string spart, int seq, string stockLoc, string smachine,int imachineId,string sglExp,string srepPoint, string sprodFamily, DateTime startDate, DateTime endDate, bool baddReceipParts, bool bgetCumulativeQty, int irows){
	return coreFactory.getInventoryForSchedule(splantOriginal,spart, seq, stockLoc, smachine, imachineId, sglExp, srepPoint, sprodFamily, startDate, endDate, baddReceipParts, bgetCumulativeQty, irows);
}


#endregion

#region Machines

public
string[] getMachineCodes(){
	return coreFactory.getMachineCodes();
}

public
Machine[] getMachinesNotInAnyConfiguration(string plt, string dept){
	return coreFactory.getMachinesNotInAnyConfiguration (plt, dept);
}

public
Machine[] getMachinesNotInConfiguration(string plt, string dept, string cfg){
	return coreFactory.getMachinesNotInConfiguration (plt, dept, cfg);
}

public
Machine[] getMachinesFromConfiguration(string plt, string dept, string cfg){
	return coreFactory.getMachinesFromConfiguration (plt, dept, cfg);
}

public
bool existsMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach){
	return coreFactory.existsMachine(PDM_Plt, PDM_Dept, PDM_Mach);
}

public
Machine createMachine(){
	return coreFactory.createMachine();
}

public
MachineContainer createMachineContainer(){
	return coreFactory.createMachineContainer();
}

public
MachineDef createMachineDef(){
	return coreFactory.createMachineDef();
}

public
MachineDefContainer createMachineDefContainer(){
	return coreFactory.createMachineDefContainer();
}

public
Machine readMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach){
	return coreFactory.readMachine(PDM_Plt, PDM_Dept, PDM_Mach);
}

public
Machine readMachineById(int id){
	return coreFactory.readMachineById(id);
}

public
Machine readMachineForce(string splant, string sdept, string smachine){
	return coreFactory.readMachineForce(splant, sdept, smachine);
}

public
void writeMachine(Machine machine){
	coreFactory.writeMachine(machine);
}

public 
void deleteMachine(Machine machine){
	coreFactory.deleteMachine(machine);
}

public
void updateMachine(Machine machine){
	coreFactory.updateMachine(machine);
}

public 
bool existPltDeptMachShf(string plt,string dept, string mach,string shift,DateTime start,DateTime end){
	return coreFactory.existPltDeptMachShf(plt, dept,  mach, shift, start, end);
}

public
string[] getAllCfgFromHotListAsString(){
	return coreFactory.getAllCfgFromHotListAsString();
}

#endregion 

#region Seri


public
Seri createSeri(){
	return coreFactory.createSeri();
}

public
SeriContainer createSeriContainer(){
	return coreFactory.createSeriContainer();
}

public
SeriContainer readSeriCMSByFilters(string spart, string serialNum, string slot, string suppSerial,string smasterSerial, string splant, string stockLoc, DateTime startActivDate, DateTime endActivDate, string statusList, bool bechEDI870, string stradingPartner, int rows){
	return coreFactory.readSeriCMSByFilters(spart, serialNum, slot, suppSerial, smasterSerial, splant, stockLoc, startActivDate, endActivDate, statusList, bechEDI870, stradingPartner, rows);
}

#endregion Seri

#region Plant

public
Plant createPlant(){
	return coreFactory.createPlant();
}

public
bool existsPlant(string plt){
	return coreFactory.existsPlant(plt);
}

public
Plant readPlant(string plt){
	return coreFactory.readPlant(plt);
}

public
string[] getPlantCodes(){
	return coreFactory.getPlantCodes();
}

public
string[][] getPlantsByDesc(string desc){
	return coreFactory.getPlantsByDesc(desc);
}

#endregion 

#region Person

public
bool existsPerson(string plt, string id){
	return coreFactory.existsPerson(plt, id);
}

public
Person createPerson(){
	return coreFactory.createPerson();
}

public
Person readPerson(string plt, string id){
	return coreFactory.readPerson(plt, id);
}

public
Person[] readPersonsById(string id){
	return coreFactory.readPersonsById(id);
}

public
PersonContainer readPersonsByFilters(string splant,string sid,string stype,string scustType,string status,string sname,string saddress1,string sbillToCust,string sphone,int irows){
	return coreFactory.readPersonsByFilters(splant, sid, stype, scustType, status, sname, saddress1, sbillToCust, sphone,irows);
}

public
void updatePerson(Person person){
	coreFactory.updatePerson(person);
}

public
void writePerson(Person person){
	coreFactory.writePerson(person);
}

public
void deletePerson(string plt, string id){
	coreFactory.deletePerson(plt, id);
}

public
string[][] getPersonsByDesc(string desc){
	return coreFactory.getPersonsByDesc(desc);
}

public
string[][] getPersonsByDesc (string desc, string type, string plant, string billToCust){
	return coreFactory.getPersonsByDesc (desc, type, plant, billToCust);
}

#endregion 

#region Proccess

public
bool existsProccess(string code, bool family){
	return coreFactory.existsProccess(code, family);
}

public
Proccess readProccess(string code, bool family){
	return coreFactory.readProccess(code, family);
}

public
void writeProccess(Proccess proccess){
	coreFactory.writeProccess(proccess);
}

public
void updateProccess(Proccess proccess){
	coreFactory.updateProccess(proccess);
}

public
void deleteProccess(Proccess proccess){
	coreFactory.deleteProccess(proccess);
}

#endregion 

#region Products

public
string[] getProductCodes(){
	return coreFactory.getProductCodes();
}

public
string[] getManufacturedProductCodes(string plantCode){
	return coreFactory.getManufacturedProductCodes(plantCode);
}

public
string[][] getProductsByDescOrId(string desc, string retailProductType){
	return coreFactory.getProductsByDescOrId(desc, retailProductType);
}

public
string[][] getProductsByProdId(string prod){
	return coreFactory.getProductsByProdId(prod);
}

public
string[][] getProductsByFamilyId(string family){
	return coreFactory.getProductsByFamilyId(family);
}

public
decimal[] getSeqQOHs(string part,string splant){
	return coreFactory.getSeqQOHs(part,splant);
}

public
decimal getRunStdByPart(string part, string seq){
	return coreFactory.getRunStdByPart(part, seq);
}

public
string[][] getProductsByProdIdAndFamily(string prod, bool family){
	return coreFactory.getProductsByProdIdAndFamily(prod, family);
}

public
string[][] getFamilyPartsByDesc(string desc){
	return coreFactory.getFamilyPartsByDesc(desc);
}

public
string[][] getProductsByDesc(string desc){
	return coreFactory.getProductsByDesc(desc);
}

public
string[] getProductFamilyCodes(){
	return coreFactory.getProductFamilyCodes();
}

public 
bool isFamilyPart(string partNum){
	return coreFactory.isFamilyPart(partNum);
}

public
string[] getValidsSeqsForProduct(string productCode){
	return coreFactory.getValidsSeqsForProduct(productCode);
}

public
string[] getValidsSeqsByProdAndDept(string productCode, string department){
	return coreFactory.getValidsSeqsByProdAndDept(productCode, department);
}

public
bool existsProduct(string id){
	return coreFactory.existsProduct(id);
}

public 
Product createProduct(){
	return coreFactory.createProduct();
}

public
Product readProduct(string id){
	return coreFactory.readProduct(id);
}

public
void writeProduct(Product product){
	coreFactory.writeProduct(product);
}

public
void updateProduct(Product product){
	coreFactory.updateProduct(product);
}

public
void deleteProduct(Product product){
	coreFactory.deleteProduct(product);
}

public
void recalcAllPartsLevel(){
	coreFactory.recalcAllPartsLevel();
}

public
string[][] getComponentsFromFamily(string familyCode){
	return coreFactory.getComponentsFromFamily(familyCode);
}

public
string[][] getAllMaterialsForProduct(string prodId, int seqId,string splant){
	return coreFactory.getAllMaterialsForProduct(prodId, seqId,splant);
}

public 
string[] getMainMaterial(string prodId, string seq){
	return coreFactory.getMainMaterial(prodId, seq);
}

public 
string[][] getProductsForReportAsString(string infMayGroup,string infMinGroup,string supMayGroup,string supMinGroup, string[] prodsID){
	return coreFactory.getProductsForReportAsString(infMayGroup, infMinGroup, supMayGroup, supMinGroup, prodsID);
}
#endregion

#region Pplan

public
bool existsProductPlan(string prodID, int seq){
	return coreFactory.existsProductPlan(prodID, seq);
}

public
ProductPlan createProductPlan(){
	return coreFactory.createProductPlan();
}

public
ProductPlanContainer createProductPlanContainer(){
	return coreFactory.createProductPlanContainer();
}

public
ProductPlan readProductPlan(string	prodID, int seq){
	return coreFactory.readProductPlan(prodID, seq);
}

public
void updateProductPlan(ProductPlan productPlan){
	coreFactory.updateProductPlan(productPlan);
}

public
void writeProductPlan(ProductPlan productPlan){
	coreFactory.writeProductPlan(productPlan);
}

public
void deleteProductPlan(string	prodID, int	seq){
	coreFactory.deleteProductPlan(prodID, seq);
}

public
string[][] getProductPlanAsString(string prod){
	return coreFactory.getProductPlanAsString(prod);
}

public
string[][] getAllProductPlansAsString(){
	return coreFactory.getAllProductPlansAsString();
}

public
void clearLeadTimes(){
    coreFactory.clearLeadTimes();
}

#endregion

#region Schedule

public
Schedule readSchedule(string plt, string version){
	return coreFactory.readSchedule(plt, version);
}

public
void writeSchedule(Schedule schedule){
	coreFactory.writeSchedule(schedule);
}

public
void updateSchedule(Schedule schedule){
	coreFactory.updateSchedule(schedule);
}

public
void deleteSchedule(Schedule schedule){
	coreFactory.deleteSchedule(schedule);
}

public
string[][] getActiveCapacityVersions(string plt){
	return coreFactory.getActiveCapacityVersions(plt);
}

#endregion

public
string[] getCfgFromProd(string plt, string prod){
	return coreFactory.getCfgFromProd(plt, prod);
}

public
decimal getProductionHours(string plt, string prod, decimal qty){
	return coreFactory.getProductionHours(plt, prod, qty);
}

public
string[] getMachineCodesFromConfiguration(string plt, string dept, string cfg){
	return coreFactory.getMachineCodesFromConfiguration(plt, dept, cfg);
}

public
string[] getMachineCodesByPlt(string plt){
	return coreFactory.getMachineCodesByPlt(plt);
}

public
string[] getMachineByPartAndSeq(string plant, string dept, string part, int seq){
	return coreFactory.getMachineByPartAndSeq(plant, dept, part, seq);
}

public
string[] getMachineCodesByPltDept(string plt, string dept){
	return coreFactory.getMachineCodesByPltDept(plt, dept);
}

public
string[][] getMachinesByPltDept(string plt, string dept){
	return coreFactory.getMachinesByPltDept(plt, dept);
}

public
string[][] getMachinesByPltDeptAndDesc(string plt, string dept, string searchText){
	return coreFactory.getMachinesByPltDeptAndDesc(plt, dept, searchText);
}

public 
string[][] getScheduleForReport(string plantCode,string deptCode){
	return coreFactory.getScheduleForReport(plantCode, deptCode);
}

public 
SchQohAssignation createSchQohAssignation(){
	return coreFactory.createSchQohAssignation();
}

public 
void writeSchQohAssignation (SchQohAssignation schQohAssignation){
	coreFactory.writeSchQohAssignation (schQohAssignation);
}

public 
void updateSchQohAssignation (SchQohAssignation schQohAssignation){
	coreFactory.updateSchQohAssignation (schQohAssignation);
}

public 
SchQohAssignation readSchQohAssignation (string plant, string department, string version){
	return coreFactory.readSchQohAssignation (plant, department, version);
}

#region Shift

public
bool existsShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf){
	return coreFactory.existsShift(SH_Db, SH_Company, SH_Plt, SH_Dept, SH_Shf);
}

public
bool existsShift(string SH_Plt, string SH_Dept, string SH_Shf){
	return coreFactory.existsShift(SH_Plt, SH_Dept, SH_Shf);
}

public
Shift readShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf){
	return coreFactory.readShift(SH_Db, SH_Company, SH_Plt, SH_Dept, SH_Shf);
}

public
Shift readShift(string SH_Plt, string SH_Dept, string SH_Shf){
	return coreFactory.readShift(SH_Plt, SH_Dept, SH_Shf);
}

public
ShiftContainer readShiftsByPltDept(string db, int company, string plt, string dept){
	return coreFactory.readShiftsByPltDept(db, company, plt, dept);
}

public
ShiftContainer readShiftsByPltDept(string plt, string dept){
	return coreFactory.readShiftsByPltDept(plt, dept);
}

public
ShiftContainer readShiftsByPlt (string plt){
	return coreFactory.readShiftsByPlt (plt);
}

public
ShiftContainer readShifts(){
	return coreFactory.readShifts();
}

public
void writeShift(Shift shift){
	coreFactory.writeShift(shift);
}

public
void updateShift(Shift shift){
	coreFactory.updateShift(shift);
}

public
void deleteShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf){
	coreFactory.deleteShift(SH_Db, SH_Company, SH_Plt, SH_Dept, SH_Shf);
}

public
void deleteShift(string SH_Plt, string SH_Dept, string SH_Shf, string SH_ShfGrp, 
			string SH_ShfType, string SH_ShfStatus){
	coreFactory.deleteShift(SH_Plt, SH_Dept, SH_Shf, SH_ShfGrp, SH_ShfType, SH_ShfStatus);
}

public
string[] getShiftCodesByPltDept(string db, int company, string plt, string dept){
	return coreFactory.getShiftCodesByPltDept(db, company, plt, dept);
}

public
string[] getShiftCodesByPltDept(string plt, string dept){
	return coreFactory.getShiftCodesByPltDept(plt, dept);
}

public 
bool existsShiftDayDetailTrans(string db, int company, string plt, string dept, string shift, DateTime startDate,DateTime endDate,int type){
	return coreFactory.existsShiftDayDetailTrans(db, company, plt, dept, shift, startDate, endDate, type);
}

public 
bool existsShiftDayDetailTrans(string plt, string dept, string shift, DateTime startDate,DateTime endDate,int type){
	return coreFactory.existsShiftDayDetailTrans(plt, dept, shift, startDate, endDate, type);
}

public
string[][] getShiftHdrByDesc(string desc, string db, int company, string plt, string dept){
	return coreFactory.getShiftHdrByDesc (desc, db, company, plt, dept);
}

public
Shift createShift(){
	return coreFactory.createShift();
}

#endregion

#region Task

public
bool existsTask(int id){
	return coreFactory.existsTask(id);
}

public
Task readTask(int id){
	return coreFactory.readTask(id);
}

public
void updateTask(Task task){
	coreFactory.updateTask(task);
}

public
void writeTask(Task task){
	coreFactory.writeTask(task);
}

public
void deleteTask(int id){
	coreFactory.deleteTask(id);
}

public
void setAutimaticDelay(int delay){
	coreFactory.setAutimaticDelay(delay);
}

public
int getAutimaticDelay(){
	return coreFactory.getAutimaticDelay();
}

public
void setNoRunStart(string noRunStart){
	coreFactory.setNoRunStart(noRunStart);
}

public
string getNoRunStart(){
	return coreFactory.getNoRunStart();
}

public
void setNoRunEnd(string noRunEnd){
	coreFactory.setNoRunEnd(noRunEnd);
}

public
string getNoRunEnd(){
	return coreFactory.getNoRunEnd();
}

public
void insertTaskEngine(int taskCode, string parameters){
	coreFactory.insertTaskEngine(taskCode, parameters);
}

public
string getNextRunTaskInformation(int taskId){
	return coreFactory.getNextRunTaskInformation(taskId);
}

public
void stopAllPendingTasks(int taskId){
	coreFactory.stopAllPendingTasks(taskId);
}

public
string[][] getAllTaskConfiguration(){
	return coreFactory.getAllTaskConfiguration();
}

#endregion

public 
void setFilters(string[] stkbFilter, string[] wipbFilter){
	coreFactory.setFilters(stkbFilter, wipbFilter);
}

public 
string[] getStkbFilters(){ 
	return coreFactory.getStkbFilters();
}

public 
string[] getWipbFilters(){
	return coreFactory.getWipbFilters();
}

public 
void updateTaskConfiguration(TaskConfiguration taskConfiguration){
	coreFactory.updateTaskConfiguration(taskConfiguration);
}

public 
TaskConfiguration readTaskConfiguration(int taskCode){
	return coreFactory.readTaskConfiguration(taskCode);
}

public
string[][] getTimeCodes(){
	return coreFactory.getTimeCodes();
}

public
TimeCode[] getTimeCodeObjects(){
	return coreFactory.getTimeCodeObjects();
}

public
decimal getMachineTimeCodePorc (string plt, string dept, string machine, string timeCode){
	return coreFactory.getMachineTimeCodePorc (plt, dept, machine, timeCode);
}

public 
string[][] getPaintOrdersHotListAsString(int pONum){
	return coreFactory.getPaintOrdersHotListAsString(pONum);
}

public 
string[][] getPaintOrdersHotListSumAsString(){
	return coreFactory.getPaintOrdersHotListSumAsString();
}

#region Capacity Version

public 
CapacityVersion createCapacityVersion(){
	return coreFactory.createCapacityVersion();
}

public
CapacityVersion readCapacityVersion (string version){
	return coreFactory.readCapacityVersion (version);
}

public 
void writeCapacityVersion(CapacityVersion capacityVersion){
	coreFactory.writeCapacityVersion(capacityVersion);
}

public 
bool existsCapacityVersion(string version){
	return coreFactory.existsCapacityVersion(version);
}

#endregion

#region User

public
bool existsUser(int id){
	return coreFactory.existsUser(id);
}

public
bool existsUserByName(string loginName){
	return coreFactory.existsUserByName(loginName);
}

public
User createUser(){
	return coreFactory.createUser();
}

public
User readUser(int id){
	return coreFactory.readUser(id);
}

public
User readUserByName(string loginName){
	return coreFactory.readUserByName(loginName);
}

public
void writeUser(User user){
	coreFactory.writeUser(user);
}

public
void updateUser(User user){
	coreFactory.updateUser(user);
}

public
void deleteUser(User user){
	coreFactory.deleteUser(user);
}

public
UserContainer readUsers(){
	return coreFactory.readUsers();
}

public
UserSignin createUserSignin(){
	return coreFactory.createUserSignin();
}

#endregion

public 
PlantContainer readAllPlants(){
	return coreFactory.readAllPlants();
}

public 
void updatePlant(Plant plant){
	coreFactory.updatePlant(plant);
}

public 
void insertPlant(Plant plant){
	coreFactory.insertPlant(plant);
}

public void deletePlant(Plant plant){
	coreFactory.deletePlant(plant);
}

public 
bool hasDeptForPlant(string plant){
	return coreFactory.hasDeptForPlant(plant);

}

public 
bool existsDepartament(string plt, string dept){
	return coreFactory.existsDepartament(plt, dept);
}

public 
Departament createDepartament(){
	return coreFactory.createDepartament();
}

public 
Departament readDepartament(string plt, string dept){
	return coreFactory.readDepartament(plt, dept);
}

public 
void writeDepartament(Departament departament){
	coreFactory.writeDepartament(departament);
}

public 
void updateDepartament(Departament departament){
	coreFactory.updateDepartament(departament);
}

public 
void deleteDepartament(Departament departament){
	coreFactory.deleteDepartament(departament);
}

public 
DepartamentContainer readDepartamentsByFilters(string scompany,string splant,string sdept,string sdeptDesc,int rows){
	return coreFactory.readDepartamentsByFilters(scompany, splant, sdept, sdeptDesc, rows);
}

public 
DepartamentContainer readDepartamentsByPlt(string plt){
	return coreFactory.readDepartamentsByPlt(plt);
}


public
ArrayList generateDeptsPrHist(string smode, DateTime dateBefore, DateTime dateAfter, string splant,
							string sshift, string sdept, string sresource, string spart, int seq){

	return coreFactory.generateDeptsPrHist(smode, dateBefore, dateAfter, splant, sshift, sdept, sresource, spart, seq);
}

public
bool existsByDept(string sdept){
	return coreFactory.existsByDept(sdept);
}


public 
bool hasMachineForDept(Departament departament){
	return coreFactory.hasMachineForDept(departament);
}

public 
bool hasConfigurationForDept(Departament departament){
	return coreFactory.hasConfigurationForDept(departament);
}

public
decimal getMinInventory(string prodId, int seq){
	return coreFactory.getMinInventory(prodId, seq);
}

#region OE

public
Employee createEmployee(){
	return coreFactory.createEmployee();
}

public
EmployeeContainer createEmployeeContainer(){
	return coreFactory.createEmployeeContainer();
}

public
void updateEmployee(Employee employee){
	coreFactory.updateEmployee (employee);
}

public
void writeEmployee(Employee employee){
	coreFactory.writeEmployee (employee);
}

public
bool existsEmployee(string id){
	return coreFactory.existsEmployee (id);
}

public
bool existsEmployee(string slogin,string spass,out string sempId){
	return coreFactory.existsEmployee (slogin, spass, out sempId);
}

public
Employee readEmployee(string id,bool bfull = false){
	return coreFactory.readEmployee(id,bfull);
}

public
EmployeeLabour createEmployeeLabour(){
	return coreFactory.createEmployeeLabour();
}

public
EmployeeLabourContainer createEmployeeLabourContainer(){
	return coreFactory.createEmployeeLabourContainer();
}

public
EmployeeLabourView createEmployeeLabourView(){
	return coreFactory.createEmployeeLabourView();
}

public
EmployeeShift createEmployeeShift(){
	return coreFactory.createEmployeeShift();
}

public
EmployeeShiftContainer createEmployeeShiftContainer(){
	return coreFactory.createEmployeeShiftContainer();
}

public
bool existsEmployeeShift(int id){
	return coreFactory.existsEmployeeShift(id);
}

public
EmployeeShift readEmployeeShift(int id){
	return coreFactory.readEmployeeShift(id);
}

public
void updateEmployeeShift(EmployeeShift employeeShift){
	coreFactory.updateEmployeeShift (employeeShift);
}

public
void writeEmployeeShift(EmployeeShift employeeShift){
	coreFactory.writeEmployeeShift (employeeShift);
}

public
void deleteEmployeeShift(int id){
	coreFactory.deleteEmployeeShift(id);
}


public
EmployeeShiftContainer readEmployeeShiftByFilters(string sid, int ishiftNum, DateTime startDate,int rows){
	return coreFactory.readEmployeeShiftByFilters(sid, ishiftNum, startDate, rows);
}

public
string[][] getEmployeeByDesc(string desc, int iTop){
	return coreFactory.getEmployeeByDesc(desc, iTop);
}

public
EmployeeContainer readEmployeeByFilters(string sid,string firstName,string lastName,string status,int iassignShift,string sdept, int idftLabourTypeId, bool bhasDefLababour,bool bonlyHdr,int rows){
	return coreFactory.readEmployeeByFilters(sid,firstName, lastName,status,iassignShift, sdept,idftLabourTypeId,bhasDefLababour, bonlyHdr,rows);
}

#endregion OE


public
EmpShiftScheduleHdr createEmpShiftScheduleHdr(){
	return coreFactory.createEmpShiftScheduleHdr();
}

public
EmpShiftScheduleHdrContainer createEmpShiftScheduleHdrContainer(){
	return coreFactory.createEmpShiftScheduleHdrContainer();
}

public
EmpShiftScheduleDtl createEmpShiftScheduleDtl(){
	return coreFactory.createEmpShiftScheduleDtl();
}

public
EmpShiftScheduleDtlView createEmpShiftScheduleDtlView(){
	return coreFactory.createEmpShiftScheduleDtlView();
}
 
public
EmpShiftScheduleDtlContainer createEmpShiftScheduleDtlContainer(){
	return coreFactory.createEmpShiftScheduleDtlContainer();
}

public
EmpShiftScheduleNotes createEmpShiftScheduleNotes(){
	return coreFactory.createEmpShiftScheduleNotes();
}

public
EmpShiftScheduleNotesContainer createEmpShiftScheduleNotesContainer(){
	return coreFactory.createEmpShiftScheduleNotesContainer();
}

public
EmpShiftScheduleHdrSumView createEmpShiftScheduleHdrSumView(){
	return coreFactory.createEmpShiftScheduleHdrSumView();
}

public
EmpShiftScheduleHdrSumViewContainer createEmpShiftScheduleHdrSumViewContainer(){
	return coreFactory.createEmpShiftScheduleHdrSumViewContainer();
}

public
void createDefaultsEmpShiftScheduleNotes(EmpShiftScheduleHdr empShiftScheduleHdr){
	coreFactory.createDefaultsEmpShiftScheduleNotes(empShiftScheduleHdr);
}
 
public
bool existsEmpShiftScheduleHdr(int id){
	return coreFactory.existsEmpShiftScheduleHdr(id);
}

public
EmpShiftScheduleHdr readEmpShiftScheduleHdr(int id){
	return coreFactory.readEmpShiftScheduleHdr(id);
}

public
void updateEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr){
	coreFactory.updateEmpShiftScheduleHdr (empShiftScheduleHdr);
}

public
void writeEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr){
	coreFactory.writeEmpShiftScheduleHdr (empShiftScheduleHdr);
}

public
void deleteEmpShiftScheduleHdr(int id){
	coreFactory.deleteEmpShiftScheduleHdr(id);
}

public
EmpShiftScheduleHdr cloneEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr){
	return coreFactory.cloneEmpShiftScheduleHdr(empShiftScheduleHdr);
}

public
EmpShiftScheduleHdrContainer readEmpShiftScheduleHdrByFilters(string sid,string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string snotes, string screatedByEmpId,bool bonlyHdr,int rows){
	return coreFactory.readEmpShiftScheduleHdrByFilters(sid, splant, fromDate, toDate, ishiftNum, sdept, snotes, screatedByEmpId, bonlyHdr, rows);
}

public
Hashtable readEmpShiftScheduleHdrSumViewByFilters(string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string screatedByEmpId,int rows){
	return coreFactory.readEmpShiftScheduleHdrSumViewByFilters(splant, fromDate, toDate, ishiftNum, sdept, screatedByEmpId, rows);
}

public
EmpShiftScheduleReportView createEmpShiftScheduleReportView(){
	return coreFactory.createEmpShiftScheduleReportView();
}

public
EmpShiftScheduleReportViewContainer createEmpShiftScheduleReportViewContainer(){
	return coreFactory.createEmpShiftScheduleReportViewContainer();
}

public
EmpShiftScheduleReportTransformView createEmpShiftScheduleReportTransformView(){
	return coreFactory.createEmpShiftScheduleReportTransformView();
}

public
EmpShiftScheduleReportTransformViewContainer createEmpShiftScheduleReportTransformViewContainer(){
	return coreFactory.createEmpShiftScheduleReportTransformViewContainer();
}

public
EmpShiftScheduleReportViewContainer readEmpShiftScheduleReportViewByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate, int ishiftNum,int rows){
	return coreFactory.readEmpShiftScheduleReportViewByFilters(splant, sdept, fromDate, toDate,ishiftNum, rows);
}       

public
EmpShiftScheduleReportViewContainer readMachEmpShiftScheduleReportViewByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate, int ishiftNum,string swithPriorityYesNo,int rows){
	return coreFactory.readMachEmpShiftScheduleReportViewByFilters(splant, sdept, fromDate, toDate,ishiftNum, swithPriorityYesNo, rows);
}       

public
string[][] getAllDownCodes(){
	return coreFactory.getAllDownCodes();
}

public
Hashtable readPrHistByFiltersHashByPartSeq(string part,int seq, string sdept,DateTime fromDate,DateTime toDate,int irows){
    return coreFactory.readPrHistByFiltersHashByPartSeq(part,seq,sdept,fromDate,toDate,irows);
}

public
Hashtable readPrHistByFiltersHashSummarizedByPartSeq(string part,int seq,string sdept,DateTime fromDate,DateTime toDate, PrHistSumViewContainer prHistSumViewContainer, int irows){
    return coreFactory.readPrHistByFiltersHashSummarizedByPartSeq(part,seq,sdept,fromDate,toDate, prHistSumViewContainer,irows);
}

public
PrHistSumView createPrHistSumView(){
    return coreFactory.createPrHistSumView();
}

public
PrHistSumViewContainer createPrHistSumViewContainer(){
    return coreFactory.createPrHistSumViewContainer();
}
    
public 
string generateShcByMachine(string plt, string dept,string part, int seq){
    return coreFactory.generateShcByMachine(plt, dept,part, seq);
}

public 
MacConfiguration createConfiguration(){
	return coreFactory.createConfiguration ();
}

public 
MacConfiguration[] readAllConfigurations(string plt, string dept){
	return coreFactory.readAllConfigurations (plt, dept);
}

public 
bool existsConfiguration (string plt, string dept, string cfg){
	return coreFactory.existsConfiguration (plt, dept, cfg);
}

public 
MacConfiguration readConfiguration (string plt, string dept, string cfg){
	return coreFactory.readConfiguration (plt, dept, cfg);
}

public 
void writeConfiguration (MacConfiguration conf){
	coreFactory.writeConfiguration (conf);
}

public 
void updateConfiguration (MacConfiguration conf){
	coreFactory.updateConfiguration (conf);
}

public
void deleteConfiguration (MacConfiguration conf){
	coreFactory.deleteConfiguration (conf);
}

public
bool configurationHasMachines (MacConfiguration conf)
{
	return coreFactory.configurationHasMachines (conf);
}

public
void removeMachineFromConfiguration (Machine machine, MacConfiguration configuration){
	coreFactory.removeMachineFromConfiguration (machine, configuration);
}

public
void removeMachineFromAllConfigurations (Machine machine){
	coreFactory.removeMachineFromAllConfigurations (machine);
}

public
void addMachineToCfg (Machine machine, MacConfiguration configuration){
	coreFactory.addMachineToCfg (machine, configuration);
}

public
MachineContainer readMachinesByFilters(string smachine, string sdes1,string splant,string sdept, string scheduled,bool bonlyHeader,int rows){
	return coreFactory.readMachinesByFilters(smachine, sdes1, splant, sdept, scheduled, bonlyHeader, rows);
}

public
MachineContainer readMachinesViewByFilters(string smachine, string sdes1,string splant,string sdept, string scheduled,DateTime planDate, ArrayList arrayMachineIds,bool bonlyHeader,int rows){
	return coreFactory.readMachinesViewByFilters(smachine, sdes1, splant, sdept, scheduled, planDate,arrayMachineIds,bonlyHeader, rows);
}

#region Company
public
string[][] getCompaniesAsString(){
    return coreFactory.getCompaniesAsString();
}

public
bool existsCompany(string sdb,int icompany){	   
	 return coreFactory.existsCompany(sdb,icompany);
}

public
Company readCompany(string sdb,int icompany){
     return coreFactory.readCompany(sdb,icompany);
}

public 
void updateCompany(Company company){
    coreFactory.updateCompany(company);
}

public 
void writeCompany(Company company){
    coreFactory.writeCompany(company);
}

public 
void deleteCompany(Company company){
    coreFactory.deleteCompany(company);
}

public
string[][] getCompanyByDesc(string desc,string sdb){
	return coreFactory.getCompanyByDesc(desc,sdb);
}

public
Company createCompany(){
	 return coreFactory.createCompany();
}
#endregion Company

#region plant (new table)
public 
string[][] getPlantsFromCompanyAsString(string db, int companyCode){
    return coreFactory.getPlantsFromCompanyAsString(db,companyCode);
}

public 
bool existPlantByCompany(string db, int company){
    return coreFactory.existPlantByCompany(db,company);
}

public
Plt createPlt(){
	return coreFactory.createPlt();
}

public
bool existsPlt(string sdb,int icompany, string splt){
	return coreFactory.existsPlt( sdb, icompany, splt);
}

public
Plt readPlt(string sdb,int icompany, string splt){
    return coreFactory.readPlt( sdb, icompany, splt);
}

public
string[][] getPltByDesc(string desc,string sdb,int icompany){
	return coreFactory.getPltByDesc(desc,sdb,icompany);
}	

public 
void updatePlt(Plt plt){
	coreFactory.updatePlt(plt);
}


public 
void writePlt(Plt plt){
	coreFactory.writePlt(plt);
}

public 
void deletePlt(Plt plt){
	coreFactory.deletePlt(plt);
}

//public string[][] getQohPlantAsString(string db,int company, string plant){
//
//    return coreFactory.getQohPlantAsString(db,company, plant);
//}
#endregion plant (new table)

#region Capacity

public 
Capacity createCapacity(){
    return coreFactory.createCapacity();
}

public
bool existsCapacity(string version, string plt, string dept, string mach){
    return coreFactory.existsCapacity(version, plt, dept, mach);
}

public
Capacity readCapacity(string version, string plt, string dept, string mach){
    return coreFactory.readCapacity(version, plt, dept, mach);
}

public
void writeCapacity(Capacity capacity){
    coreFactory.writeCapacity(capacity);
}

public
void updateCapacity(Capacity capacity){
    coreFactory.updateCapacity(capacity);
}

public
void deleteCapacity(Capacity capacity){
    coreFactory.deleteCapacity(capacity);
}

public
string[] getShiftCodesByPltDeptEnd(string plt, string dept, DateTime endDate){
    return coreFactory.getShiftCodesByPltDeptEnd(plt, dept, endDate);
}

#endregion Capacity

public
MaterialBomContainer generateMaterialListRecursive(string prodId, int seq,string splant){
	return coreFactory.generateMaterialListRecursive(prodId, seq,splant);
}

#region Stkt
public int generateCMSStkt(){
    return coreFactory.generateCMSStkt();
}

public int cms400ToCmsTempStkt(){
    return coreFactory.cms400ToCmsTempStkt();
}

public 
string[][] getShortageReportAsString(string[] vecMajorFilter,string[] vecMinorFilter, DateTime dateFrom){
    return coreFactory.getShortageReportAsString(vecMajorFilter,vecMinorFilter,dateFrom);
}

#endregion

public 
string[] getMajorGroupASString(string major){
   return coreFactory.getMajorGroupASString(major);
}

public 
string[] getMinorGroupASString(){
    return coreFactory.getMinorGroupASString();
}

public
ArrayList readGLExps(){
    return coreFactory.readGLExps();
}

public
ProductContainer readProductByFilters(string sprodId,string sdes1,int imachineId,string smajGroup,string stype,int rows){
    return coreFactory.readProductByFilters(sprodId, sdes1, imachineId, smajGroup,stype, rows);
}

public
ProductContainer readProductViewByFilters(string splant,string sprodId,string sdes1,int imachineId,string smajGroup,string stype,string schMatAvailFlag,int rows){
    return coreFactory.readProductViewByFilters(splant,sprodId, sdes1, imachineId, smajGroup,stype, schMatAvailFlag,rows);
}

public
RoutingContainer getBuildByFilters(string splant,string sprodId, int seq, int imachineId, bool bincludeAtlernative,bool bonlyMachAlternative){
    return coreFactory.getBuildByFilters(splant,sprodId, seq, imachineId, bincludeAtlernative, bonlyMachAlternative);
}

#region Rprd
public int generateCMSRprd(){
    return coreFactory.generateCMSRprd();
}

public int cms400ToCmsTempRprd(){
    return coreFactory.cms400ToCmsTempRprd();
}
#endregion

#region Rprr
public int generateCMSRprr(){
    return coreFactory.generateCMSRprr();
}

public int cms400ToCmsTempRprr(){
    return coreFactory.cms400ToCmsTempRprr();
}
#endregion

#region Rprs
public int generateCMSRprs(){
    return coreFactory.generateCMSRprs();
}

public int cms400ToCmsTempRprs(){
    return coreFactory.cms400ToCmsTempRprs();
}
#endregion

#region Rprh
public int generateCMSRprh(){
    return coreFactory.generateCMSRprh();
}

public int cms400ToCmsTempRprh(){
    return coreFactory.cms400ToCmsTempRprh();
}
#endregion

#region Rprp
public int generateCMSRprp(){
    return coreFactory.generateCMSRprp();
}

public int cms400ToCmsTempRprp(){
    return coreFactory.cms400ToCmsTempRprp();
}
#endregion

#region ExcelReports

public
void generateExcelReport(ExcelReportSetup excelReportSetup){
	coreFactory.generateExcelReport(excelReportSetup);
}

public
ExcelReportSetup createExcelReportSetup(){
	return coreFactory.createExcelReportSetup();
}

public
bool existsExcelReportSetup(string reportName){
	return coreFactory.existsExcelReportSetup(reportName);
}

public
ExcelReportSetup readExcelReportSetup(string reportName){
	return coreFactory.readExcelReportSetup(reportName);
}

public
string[][] getExcelReportSetupsByDescType(string searchText,string type, int rows){
	return coreFactory.getExcelReportSetupsByDescType(searchText,type,rows);
}

public
void updateExcelReportSetup(ExcelReportSetup excelReportSetup){
	coreFactory.updateExcelReportSetup (excelReportSetup);
}

public
void writeExcelReportSetup(ExcelReportSetup excelReportSetup){
	coreFactory.writeExcelReportSetup (excelReportSetup);
}

public
void deleteExcelReportSetup(string reportName){
	coreFactory.deleteExcelReportSetup(reportName);
}

public
ExcelReportSetup cloneExcelReportSetup(ExcelReportSetup excelReportSetup){
	return coreFactory.cloneExcelReportSetup(excelReportSetup);
}

#endregion ExcelReports

/*** MTHL - Method File - Tooling ***/

public 
int cms400ToCmsTempMthl(){
	return coreFactory.cms400ToCmsTempMthl();
}

public 
int cmsTempToNujitMthl(){
	return coreFactory.cmsTempToNujitMthl();
}

public 
int generateCMSMthl(){
	return coreFactory.generateCMSMthl();
}

/*********************************************************************/

/*** TMST - Tool Master File ***/

public 
int cms400ToCmsTempTmst(){
	return coreFactory.cms400ToCmsTempTmst();
}

public 
int cmsTempToNujitTmst(){
	return coreFactory.cmsTempToNujitTmst();
}

public 
int generateCMSTmst(){
	return coreFactory.generateCMSTmst();
}

/*********************************************************************/

#region SchLog

public
SchLog createSchLog(){
	return coreFactory.createSchLog();
}

public
bool existsSchLog(string db, string jobcardID, string company, string plant){
	return coreFactory.existsSchLog(db, jobcardID, company, plant);
}

public
SchLog readSchLog(string db, string jobcardID, string company, string plant){
	return coreFactory.readSchLog(db, jobcardID, company, plant);
}

public
string[] readSchLogForReport(string db, string jobcardID, string company, string plant){
	return coreFactory.readSchLogForReport(db, jobcardID, company, plant);
}

public
string[][] getSchLogByDesc(string searchText, int rows){
	return coreFactory.getSchLogByDesc(searchText,rows);
}

public
void updateSchLog(SchLog schLog){
	coreFactory.updateSchLog (schLog);
}

public
void writeSchLog(SchLog schLog){
	coreFactory.writeSchLog (schLog);
}

public
void deleteSchLog(string db, string jobcardID, string company, string plant){
	coreFactory.deleteSchLog(db, jobcardID, company, plant);
}

public
SchLog cloneSchLog(SchLog schLog){
	return coreFactory.cloneSchLog(schLog);
}

public
string[][] getPdToolByDesc(string searchText, int rows){
	return coreFactory.getPdToolByDesc(searchText, rows);
}

public
string[][] getPdToolByPart(string part1, string part2, string part3, string part4){
	return coreFactory.getPdToolByPart(part1, part2, part3, part4);
}

public
string getToolDescription(string db, string company, string plant, string tool){
	return coreFactory.getToolDescription(db, company, plant, tool);
}

public
string getToolDescriptionById(int id){
	return coreFactory.getToolDescriptionById(id);
}

#endregion SchLogCoreFactory

#region Report
public
RP1268H createRP1268H(){
	return coreFactory.createRP1268H();
}

public
RP1268HContainer createRP1268HContainer(){
	return coreFactory.createRP1268HContainer();
}

public
RP1268D createRP1268D(){
	return coreFactory.createRP1268D();
}

public
RP1268DContainer createRP1268DContainer(){
	return coreFactory.createRP1268DContainer();
}

public
void writeRP1268H(RP1268H rP1268H){
	coreFactory.writeRP1268H(rP1268H);
}

public
ArrayList runReport1268(){
	return coreFactory.runReport1268();
}

public
RP1268H runStoreReport1268(out ArrayList alist){
	return coreFactory.runStoreReport1268(out alist);
}

public
ArrayList getStoredReport1268(int iheaderID,out DateTime dateProcessed){
	return coreFactory.getStoredReport1268(iheaderID, out dateProcessed);
}

public
ArrayList getDemandForPart(string spart){
	return coreFactory.getDemandForPart(spart);
}

public
Bolm createBolm(){
	return coreFactory.createBolm();
}

public
BolmContainer createBolmContainer(){
	return coreFactory.createBolmContainer();
}

public
BolmContainer readBolmByFilters(decimal dbolid, DateTime startDate, DateTime endDate, string status, string shipVia, string struckID, string sroute, int rows){
	return coreFactory.readBolmByFilters(dbolid, startDate, endDate, status, shipVia, struckID, sroute, rows);
}


    #endregion Report


#region Demand

public
DemandH createDemandH(){
    return coreFactory.createDemandH();
}

public
DemandHContainer createDemandHContainer(){
    return coreFactory.createDemandHContainer();
}

public
bool existsDemandH(int id){
    return coreFactory.existsDemandH(id);
}

public
DemandH readDemandH(int id){
    return coreFactory.readDemandH(id);
}

public
DemandH readDemandHLast(string splant){
    return coreFactory.readDemandHLast(splant);
}

public 
void updateDemandH(DemandH demandH){
    coreFactory.updateDemandH(demandH);
}

public
void updateDemandHSpecicDtl(DemandH demandH,DemandD demandD){
    coreFactory.updateDemandHSpecicDtl(demandH,demandD);
}

public 
void writeDemandH(DemandH demandH){
    coreFactory.writeDemandH(demandH);
}

public
void deleteDemandH(int id){
    coreFactory.deleteDemandH(id);
}

public
DemandH cloneDemandH(DemandH demandH){
    return coreFactory.cloneDemandH(demandH);
}

public
DemandD createDemandD(){
    return coreFactory.createDemandD();
}

public
DemandDContainer createDemandDContainer(){
    return coreFactory.createDemandDContainer();
}

public
DemandD cloneDemandD(DemandD demandD){
    return coreFactory.cloneDemandD(demandD);
}

public
DemandH processDemand830862ByDate(string splant,DateTime startDate, DateTime endDate,bool bimportItems,bool bimportInventory){    
    return coreFactory.processDemand830862ByDate(splant,startDate, endDate,bimportItems,bimportInventory);
}

public
DemandHContainer  readDemandHByFilters(string id, string splant,string status, decimal dtrlpKeyId,DateTime fromDate,DateTime toDate,int rows){    
    return coreFactory.readDemandHByFilters(id, splant, status, dtrlpKeyId, fromDate, toDate, rows);
}

public
DemandDViewContainer getDemandDViewReportByFilters(int id,string source,string stimecode,string stpartner,string sbillTo,string shipTo,string spart,bool baddAuthorizations,bool baddTimeCode,int irows){    
    return coreFactory.getDemandDViewReportByFilters(id, source, stimecode, stpartner, sbillTo, shipTo, spart, baddAuthorizations, baddTimeCode, irows);
}

public
DemandDCompareViewContainer getDemandDCompareViewReportByFilters(string splant,string source,string stPartner, string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){    
    return coreFactory.getDemandDCompareViewReportByFilters(splant, source, stPartner, shipLoc, spart,runDate,startRelDate, endRelDate, bcumulative, irows);
}

public
ArrayList readDemandDTradingPartners(string splant,string source){    
    return coreFactory.readDemandDTradingPartners(splant,source);
}

public
ArrayList readDemandDShipLocs(string splant,string source,string stpartner){    
    return coreFactory.readDemandDShipLocs(splant,source, stpartner);
}

public
ArrayList readDemandDPartsByFilters(string splant,string source,string stpartner,string shipLoc){    
    return coreFactory.readDemandDPartsByFilters(splant,source,stpartner, shipLoc);
}

public
DemandDView createDemandDView(){    
    return coreFactory.createDemandDView();
}

public
DemandDViewContainer createDemandDViewContainer(){    
    return coreFactory.createDemandDViewContainer();
}

public
DemandDCompareViewContainer createDemandDCompareViewContainer(){    
    return coreFactory.createDemandDCompareViewContainer();
}

public
DemandDCompareLeftViewContainer createDemandDCompareLeftViewContainer(){    
    return coreFactory.createDemandDCompareLeftViewContainer();
}

public
DemandDCompareReportViewContainer createDemandDCompareReportViewContainer(){    
    return  coreFactory.createDemandDCompareReportViewContainer();
}

#endregion Demand

#region DemandTransform

public
DemTransformH createDemTransformH(){
    return coreFactory.createDemTransformH();
}

public
DemTransformHContainer createDemTransformHContainer(){
    return coreFactory.createDemTransformHContainer();
}

public
DemTransformOptions createDemTransformOptions(){
    return coreFactory.createDemTransformOptions();
}

public
bool existsDemTransformH(int id){
    return coreFactory.existsDemTransformH(id);
}

public
DemTransformH readDemTransformH(int id){
    return coreFactory.readDemTransformH(id);
}

public
void updateDemTransformH(DemTransformH demTransformH){
    coreFactory.updateDemTransformH(demTransformH);
}

public
void writeDemTransformH(DemTransformH demTransformH){
    coreFactory.writeDemTransformH(demTransformH);
}

public
void deleteDemTransformH(int id){
    coreFactory.deleteDemTransformH(id);
}

public
DemTransformH cloneDemTransformH(DemTransformH demTransformH){
    return coreFactory.cloneDemTransformH(demTransformH);
}

public
DemTransformD createDemTransformD(){
    return coreFactory.createDemTransformD();
}

public
DemTransformDContainer createDemTransformDContainer(){
    return coreFactory.createDemTransformDContainer();
}

public
DemTransformH processDemandTransform(DemTransformOptions demTransformOptions){
    return coreFactory.processDemandTransform(demTransformOptions);
}

public
DemTransformH getDemTransformHdrByMaxID(int demandHdr){
    return coreFactory.getDemTransformHdrByMaxID(demandHdr);
}

public
DemandH processDemandMerge830862(DemandH demandH){
    return coreFactory.processDemandMerge830862(demandH);
}

public
void processDemandTransformH(DemandH demandH, DemTransformH demTransformH){
    coreFactory.processDemandTransformH(demandH, demTransformH);
}
#endregion DemandTransform

#region DemandWeek

public
DemandWeek createDemandWeek(){
    return coreFactory.createDemandWeek();
}

public
DemandWeekContainer createDemandWeekContainer(){
    return coreFactory.createDemandWeekContainer();
}

public
bool existsDemandWeek(int id){
    return coreFactory.existsDemandWeek(id);
}
 
public
DemandWeek readDemandWeek(int id){
    return coreFactory.readDemandWeek(id);
}

public
void updateDemandWeek(DemandWeek demandWeek){
    coreFactory.updateDemandWeek(demandWeek);
}

public
void writeDemandWeek(DemandWeek demandWeek){
    coreFactory.writeDemandWeek(demandWeek);
}

public
void deleteDemandWeek(int id){
    coreFactory.deleteDemandWeek(id);
}

public
DemandWeekContainer generateDemandWeek(DemandH demandH){
    return coreFactory.generateDemandWeek(demandH);
}

public
void processDemandDCompareViewNetQtyDifferences(bool bcumulative,DateTime runDate,DemandDCompareViewContainer demandDCompareViewContainer){
    coreFactory.processDemandDCompareViewNetQtyDifferences(bcumulative,runDate, demandDCompareViewContainer);
}

#endregion DemandWeek

public 
string[][] generateCMSInventory2(){
	return coreFactory.generateCMSInventory2();
}


#region CapacityDemand

public
CapacityHdr createCapacityHdr(){
	return coreFactory.createCapacityHdr();
}

public
CapacityHdrContainer createCapacityHdrContainer(){
	return coreFactory.createCapacityHdrContainer();
}

public
CapacityPart createCapacityPart(){
	return coreFactory.createCapacityPart();
}

public
CapacityPartContainer createCapacityPartContainer(){
	return coreFactory.createCapacityPartContainer();
}

public
CapacityPartDtl createCapacityPartDtl(){
	return coreFactory.createCapacityPartDtl();
}

public
CapacityPartDtlContainer createCapacityPartDtlContainer(){
	return coreFactory.createCapacityPartDtlContainer();
}

public
CapacityReq createCapacityReq(){
	return coreFactory.createCapacityReq();
}

public
CapacityReqContainer createCapacityReqContainer(){
	return coreFactory.createCapacityReqContainer();
}

public
CapacityView createCapacityView(){
	return coreFactory.createCapacityView();
}

public
CapacityViewContainer createCapacityViewContainer(){
	return coreFactory.createCapacityViewContainer();
}

public
CapacityViewHdr createCapacityViewHdr(){
	return coreFactory.createCapacityViewHdr();
}

public
CapacityViewHdrContainer createCapacityViewHdrContainer(){
	return coreFactory.createCapacityViewHdrContainer();
}

public
CapacityMachPriority createCapacityMachPriority(){
	return coreFactory.createCapacityMachPriority();
}

public
CapacityMachPriorityContainer createCapacityMachPriorityContainer(){
	return coreFactory.createCapacityMachPriorityContainer();
}

public
CapacityMachPriority cloneCapacityMachPriority(CapacityMachPriority capacityMachPriority){
	return coreFactory.cloneCapacityMachPriority(capacityMachPriority);
}

public
CapacityView cloneCapacityView(CapacityView capacityView){
	return coreFactory.cloneCapacityView(capacityView);
}

public
bool existsCapacityHdr(int id){
	return coreFactory.existsCapacityHdr(id);
}

public
CapacityHdr readCapacityHdr(int id){
	return coreFactory.readCapacityHdr(id);
}

public
void updateCapacityHdr(CapacityHdr capacityHdr){
	coreFactory.updateCapacityHdr(capacityHdr);
}

public
void updateCapacityHdrOnlyMachinePriority(CapacityHdr capacityHdr){
	coreFactory.updateCapacityHdrOnlyMachinePriority(capacityHdr);
}

public
CapacityMachPriority getCapacityMachPriority(int imachineId,string splant){
	return coreFactory.getCapacityMachPriority(imachineId,splant);
}

public
bool updateCapacityPart(CapacityPart capacityPart){
	return coreFactory.updateCapacityPart(capacityPart);
}

public
void writeCapacityHdr(CapacityHdr capacityHdr){
	coreFactory.writeCapacityHdr(capacityHdr);
}

public
void deleteCapacityHdr(int id){
	coreFactory.deleteCapacityHdr(id);
}

public
CapacityHdrContainer readCapacityHdrByFilters(string sid,string splant,string status, DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows){
    return coreFactory.readCapacityHdrByFilters(sid, splant, status, fromDate, toDate, bonlyHeader, rows);
}

public
CapacityHdr readCapacityHdrLast(string splant,bool bonlyHeadr){
    return coreFactory.readCapacityHdrLast(splant, bonlyHeadr);
}

public
CapacityHdr readCapacityHdrLastDateCheck(CapacityHdr capacityHdr, string splant){
    return coreFactory.readCapacityHdrLastDateCheck(capacityHdr, splant);
}

public
CapacityHdr processCapacityDemand(int ihotListId,string splantOriginal){
	return coreFactory.processCapacityDemand(ihotListId, splantOriginal);
}

public
CapacityViewContainer processCapacityReport(int icapacityHdrId, string splant,string sdept,string srequirment,string stype,string spart){
	return coreFactory.processCapacityReport(icapacityHdrId, splant, sdept, srequirment, stype,spart);
}

public
CapacityViewContainer processCapacityReportGroupByReqTypeDept(int icapacityHdrId,string splant,string sdept,string srequirment,int ireqId,string stype,string spart,DateTime dateWeek,CapacityView.SORT_TYPE sortType){
	return coreFactory.processCapacityReportGroupByReqTypeDept(icapacityHdrId, splant, sdept, srequirment,ireqId,stype, spart, dateWeek,sortType);
}

public
CapacityViewContainer readCapacityViewPartByFilters(int icapacityHdrId,string splant,string sdept,string srequirment,string stype, MachineContainer machineContainer, DateTime startDate,DateTime endDate){
	return coreFactory.readCapacityViewPartByFilters(icapacityHdrId, splant, sdept, srequirment, stype, machineContainer, startDate, endDate);
}

public
ScheduleHdr processScheduleByCapacityReportParts(int icapacityHdrId,string splant,string sdept,string srequirment,string stype, MachineContainer machineContainer, DateTime startDate,DateTime endDate,CapacityView.SORT_TYPE sortType){
	return coreFactory.processScheduleByCapacityReportParts(icapacityHdrId, splant, sdept, srequirment, stype, machineContainer, startDate,endDate,sortType);
}

public
CapacityPartContainer getCapacityPartContainerByFilters(int ihdrId,string spart,int iseq,string stype,int ireqId,int rows){
	return coreFactory.getCapacityPartContainerByFilters(ihdrId, spart, iseq, stype, ireqId, rows);
}

public
LabourPlanningReportShiftView createLabourPlanningReportShiftView(){
    return coreFactory.createLabourPlanningReportShiftView();
}

public
LabourPlanningReportShiftViewContainer createLabourPlanningReportShiftViewContainer(){
    return coreFactory.createLabourPlanningReportShiftViewContainer();
}

#endregion CapacityDemand

#region CapShiftTask

public
CapShiftProfile createCapShiftProfile(){
	return coreFactory.createCapShiftProfile();
}

public
CapShiftProfileContainer createCapShiftProfileContainer(){
	return coreFactory.createCapShiftProfileContainer();
}

public
CapShiftProfileView createCapShiftProfileView(){
	return coreFactory.createCapShiftProfileView();
}

public
bool existsCapShiftProfile(int id){
	return coreFactory.existsCapShiftProfile(id);
}

public
CapShiftProfile readCapShiftProfile(int id){
	return coreFactory.readCapShiftProfile(id);
}

public
CapShiftProfile readCapShiftProfileLast(string splant){
	return coreFactory.readCapShiftProfileLast(splant);
}

public
void updateCapShiftProfile(CapShiftProfile capShiftProfile){
	coreFactory.updateCapShiftProfile(capShiftProfile);
}

public
void writeCapShiftProfile(CapShiftProfile capShiftProfile){
	coreFactory.writeCapShiftProfile(capShiftProfile);
}


public
void deleteCapShiftProfile(int id){
	coreFactory.deleteCapShiftProfile(id);
}

public
CapShiftProfile cloneCapShiftProfile(CapShiftProfile capShiftProfile){
	return coreFactory.cloneCapShiftProfile(capShiftProfile);
}

public
CapShiftProfileView cloneCapShiftProfileView(CapShiftProfile capShiftProfile){
	return coreFactory.cloneCapShiftProfileView(capShiftProfile);
}

public
CapShiftProfileContainer readCapShiftProfileByFilters(string sid,string splant, int ishiftNum,string status,DateTime dstartDate,DateTime sendDate, int ishiftTaskId, string shiftDefault, bool bonlyHeader,int rows){
	return coreFactory.readCapShiftProfileByFilters(sid,splant,ishiftNum, status, dstartDate, sendDate, ishiftTaskId,shiftDefault,bonlyHeader, rows);
}

public
CapShiftProfileContainer readCapShiftProfileByExactlyDatesFilters(string splant,int ishiftNum,string status,DateTime dateTime,bool bonlyHeader,int rows){
	return coreFactory.readCapShiftProfileByExactlyDatesFilters(splant,ishiftNum, status,dateTime,bonlyHeader,rows);
}

public
CapShiftProfileContainer readCapShiftProfilesForWeek(string splant, string status, DateTime dateTime, bool bonlyHeader){
	return coreFactory.readCapShiftProfilesForWeek(splant,status,dateTime,bonlyHeader);
}

public
Hashtable readCapShiftProfilesForWeekHash(string splant,string status,DateTime fromDate,DateTime toDate, int imachineId,bool bonlyHeader){
	return coreFactory.readCapShiftProfilesForWeekHash(splant,status, fromDate,toDate, imachineId,bonlyHeader);
}

public
CapShiftProfileDtl createCapShiftProfileDtl(){
	return coreFactory.createCapShiftProfileDtl();
}

public
CapShiftProfileMachPlan createCapShiftProfileMachPlan(){
	return coreFactory.createCapShiftProfileMachPlan();
}

public
CapShiftProfileMachPlanEmployee createCapShiftProfileMachPlanEmployee(){
	return coreFactory.createCapShiftProfileMachPlanEmployee();
}

public
CapShiftProfileMachPlanEmployeeContainer createCapShiftProfileMachPlanEmployeeContainer(){
	return coreFactory.createCapShiftProfileMachPlanEmployeeContainer();
}
 
public
CapShiftProfileDtlView createCapShiftProfileDtlView(CapShiftProfileDtl capShiftProfileDtl){
	return coreFactory.createCapShiftProfileDtlView(capShiftProfileDtl);
}
 
public
CapShiftProfileDtlContainer createCapShiftProfileDtlContainer(){
	return coreFactory.createCapShiftProfileDtlContainer();
}

public
CapShiftProfileDtl cloneCapShiftProfileDtl(CapShiftProfileDtl capShiftProfileDtl){
	return coreFactory.cloneCapShiftProfileDtl(capShiftProfileDtl);
}

public
CapShiftTask createCapShiftTask(){
	return coreFactory.createCapShiftTask();
}

public
CapShiftTaskContainer createCapShiftTaskContainer(){
	return coreFactory.createCapShiftTaskContainer();
}

public
bool existsCapShiftTask(int id){
	return coreFactory.existsCapShiftTask(id);
}

public
CapShiftTask readCapShiftTask(int id){
	return coreFactory.readCapShiftTask(id);
}

public
void updateCapShiftTask(CapShiftTask capShiftTask){
	coreFactory.updateCapShiftTask (capShiftTask);
}

public
void writeCapShiftTask(CapShiftTask capShiftTask){
	coreFactory.writeCapShiftTask (capShiftTask);
}

public
void deleteCapShiftTask(int id){
	coreFactory.deleteCapShiftTask(id);
}

public
CapShiftTask cloneCapShiftTask(CapShiftTask capShiftTask){
	return coreFactory.cloneCapShiftTask(capShiftTask);
}

public
CapShiftTaskContainer readCapShiftTaskByFilters(string sid, string staskName,string sdirInd,int rows){
	return coreFactory.readCapShiftTaskByFilters(sid, staskName, sdirInd, rows);
}

public
CapProfileHoliday createCapProfileHoliday(){
	return coreFactory.createCapProfileHoliday();
}

public
CapProfileHolidayContainer createCapProfileHolidayContainer(){
	return coreFactory.createCapProfileHolidayContainer();
}

public
CapProfileHolidayContainer readCapProfileHolidayByFilters(string sid, string splant, string sholidayType, DateTime startDate, DateTime endDate, int rows){
    return coreFactory.readCapProfileHolidayByFilters(sid, splant, sholidayType,startDate, endDate, rows);
}

public
CapProfileHolidayContainer readIfHoliday(string splant,DateTime date,int rows){
    return coreFactory.readIfHoliday(splant,date,rows);
}

public
double getCapProfileHolidayDatesAffects(string splant,DateTime startDate,DateTime endDate){
	return coreFactory.getCapProfileHolidayDatesAffects(splant,startDate,endDate);
}

public
CapProfileHoliday readCapProfileHoliday(int id){
	return coreFactory.readCapProfileHoliday(id);
}

public
void updateCapProfileHoliday(CapProfileHoliday capProfileHoliday){
	coreFactory.updateCapProfileHoliday(capProfileHoliday);
}

public
void writeCapProfileHoliday(CapProfileHoliday capProfileHoliday){
	coreFactory.writeCapProfileHoliday(capProfileHoliday);
}

public
void deleteCapProfileHoliday(int id){
	coreFactory.deleteCapProfileHoliday(id);
}

#endregion CapShiftTask

#region ScheduleHdr
public
ScheduleHdr createScheduleHdr(){
	return coreFactory.createScheduleHdr();
}

public
ScheduleHdrContainer createScheduleHdrContainer(){
	return coreFactory.createScheduleHdrContainer();
}

public
ScheduleHdr cloneScheduleHdr(ScheduleHdr scheduleHdr){
	return coreFactory.cloneScheduleHdr(scheduleHdr);
}

public
bool existsScheduleHdr(int id){
	return coreFactory.existsScheduleHdr(id);
}

public
ScheduleHdr readScheduleHdr(int id){
	return coreFactory.readScheduleHdr(id);
}

public
ScheduleHdr readScheduleHdrLast(string splant){
	return coreFactory.readScheduleHdrLast(splant);
}

public
ScheduleHdr readScheduleHdrLastDateCheck(ScheduleHdr scheduleHdr,string splant){
	return coreFactory.readScheduleHdrLastDateCheck(scheduleHdr,splant);
}

public
void updateScheduleHdr(ScheduleHdr scheduleHdr){
	coreFactory.updateScheduleHdr(scheduleHdr);
}

public
void writeScheduleHdr(ScheduleHdr scheduleHdr){
	coreFactory.writeScheduleHdr(scheduleHdr);
}

public
void deleteScheduleHdr(int id){
	coreFactory.deleteScheduleHdr(id);
}

public
ScheduleHdrContainer readScheduleHdrByFilters(string sid,string splant, string status, int icapacityHdr, int ihotListId,DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows){
	return coreFactory.readScheduleHdrByFilters(sid,splant, status, icapacityHdr, ihotListId,fromDate, toDate, bonlyHeader, rows);
}

public
void loadScheduleHdrAdditionalInfo(ScheduleHdr scheduleHdr,Hashtable hashMachinesById){
	coreFactory.loadScheduleHdrAdditionalInfo(scheduleHdr, hashMachinesById);
}

public
SchedulePart createSchedulePart(){
	return coreFactory.createSchedulePart();
}

public
SchedulePartContainer createSchedulePartContainer(){
	return coreFactory.createSchedulePartContainer();
}

public
SchedulePart cloneSchedulePart(SchedulePart schedulePart){
	return coreFactory.cloneSchedulePart(schedulePart);
}

public
bool generateAutomaticReceiptPart(SchedulePart schedulePart){
	return coreFactory.generateAutomaticReceiptPart(schedulePart);
}

public
bool generateAutomaticMaterialConsumition(SchedulePart schedulePart,BomSumContainer bomSumContainer){
	return coreFactory.generateAutomaticMaterialConsumition(schedulePart, bomSumContainer);
}

public
void moveDatesFromSchedulePartTask(ScheduleHdr scheduleHdr, ScheduleReqViewContainer scheduleReqViewContainer,ScheduleReqView scheduleReqViewSelected){
	coreFactory.moveDatesFromSchedulePartTask(scheduleHdr, scheduleReqViewContainer, scheduleReqViewSelected);
}

public
SchedulePartDtl createSchedulePartDtl(){
	return coreFactory.createSchedulePartDtl();
}

public
SchedulePartDtlContainer createSchedulePartDtlContainer(){
	return coreFactory.createSchedulePartDtlContainer();
}

public
ScheduleReqView createScheduleReqView(){
	return coreFactory.createScheduleReqView();
}

public
ScheduleReqViewContainer createScheduleReqViewContainer(){
	return coreFactory.createScheduleReqViewContainer();
}

public
ScheduleTask createScheduleTask(){
	return coreFactory.createScheduleTask();
}

public
ScheduleTaskContainer createScheduleTaskContainer(){
	return coreFactory.createScheduleTaskContainer();
}

public
ScheduleTask cloneScheduleTask(ScheduleTask scheduleTask){
	return coreFactory.cloneScheduleTask(scheduleTask);
}

public
ScheduleDown createScheduleDown(){
	return coreFactory.createScheduleDown();
}

public
ScheduleDownContainer createScheduleDownContainer(){
	return coreFactory.createScheduleDownContainer();
}

public
ScheduleDown cloneScheduleDown(ScheduleDown scheduleDown){
	return coreFactory.cloneScheduleDown(scheduleDown);
}

public
decimal getRunStd(string splant,string spart,int seq,int machineId){
	return coreFactory.getRunStd(splant,spart, seq, machineId);
}

public
bool loadBuildMachineInfo(string splantOriginal,string spart,int seq,int imachineId,out string splant,out string sdept,out string smachine,out decimal drunStd, out decimal dcavities,out decimal optRunQty){
	return coreFactory.loadBuildMachineInfo(splantOriginal,spart, seq, imachineId, out splant, out sdept, out smachine, out drunStd, out dcavities, out optRunQty);
}

public
HotListView createHotListView(){
	return coreFactory.createHotListView();
}

public
HotListViewContainer createHotListViewContainer(){
	return coreFactory.createHotListViewContainer();
}

public
HotListViewHdr createHotListViewHdr(){
	return coreFactory.createHotListViewHdr();
}

public
HotListViewHdrContainer createHotListViewHdrContainer(){
	return coreFactory.createHotListViewHdrContainer();
}

public
HotListView cloneHotListView(HotListView hotListView){
	return coreFactory.cloneHotListView(hotListView);
}

public
HotListViewContainer processHotListSchedule(int ihotListId,string splantOriginal,string sdept, string smachine, string spart,int iseq,string sreportedPoint){
	return coreFactory.processHotListSchedule(ihotListId, splantOriginal,sdept, smachine, spart, iseq, sreportedPoint);
}

public
HotListViewContainer getHotListOrderedByDate(int ihotListId,string splantOriginal,string sdept,string smachine){
	return coreFactory.getHotListOrderedByDate(ihotListId,splantOriginal,sdept, smachine);
}

public
ScheduleHdr processScheduleByHotListView(int icapacityHdrId, HotListViewContainer hotListViewContainer, MachineContainer machineContainer, DateTime startDate, DateTime endDate, CapacityView.SORT_TYPE sortType){
	return coreFactory.processScheduleByHotListView(icapacityHdrId, hotListViewContainer, machineContainer, startDate, endDate, sortType);
}

public
ScheduleHdr getIfAlreadyScheduled(int ihotListId,int icapacityHdrId){
	return coreFactory.getIfAlreadyScheduled(ihotListId,icapacityHdrId);
}

public
SchedulePart scheduleAddSchedulePart(ref ScheduleHdr scheduleHdr,string splant,int imachId,string spart,int seq,decimal qty,DateTime dateTime,bool bfromHotList,bool badd,out string smessError){
	return coreFactory.scheduleAddSchedulePart(ref scheduleHdr, splant, imachId, spart, seq, qty, dateTime,bfromHotList,badd,out smessError);
}

public
ScheduleReceiptPart createScheduleReceiptPart(){
	return coreFactory.createScheduleReceiptPart();
}

public
ScheduleReceiptPartContainer createScheduleReceiptPartContainer(){
	return coreFactory.createScheduleReceiptPartContainer();
}

public
ScheduleReceiptPart cloneScheduleReceiptPart(ScheduleReceiptPart scheduleReceiptPart){
	return coreFactory.cloneScheduleReceiptPart(scheduleReceiptPart);
}

public
ScheduleReceiptPartContainer getReceiptPartContainerByFilters(int ischeduleId,string splantOriginal,string spart,int seq,string smachine, int imachineId,DateTime startDate,DateTime endDate){
    return coreFactory.getReceiptPartContainerByFilters(ischeduleId,splantOriginal,spart, seq,smachine,imachineId,startDate, endDate);
}

public
ScheduleMaterialConsumPartContainer getMaterialConsumPartContainerByFilters(int ischeduleId, string splantOriginal,string spart,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate){
    return coreFactory.getMaterialConsumPartContainerByFilters(ischeduleId, splantOriginal, spart,seq, smachine,imachineId, startDate, endDate);
}

public
string[][] getFutureInventoryByWeek(int id,string splantOriginal,string spartFilter,int iseqFilter,string smachine, int imachineId,string sglExp, DateTime startDate,DateTime endDate,int rows){
	return coreFactory.getFutureInventoryByWeek(id,splantOriginal, spartFilter, iseqFilter, smachine, imachineId, sglExp, startDate, endDate,rows);
}

public
MachineReportView createMachineReportView(){
    return coreFactory.createMachineReportView();
}

public
MachineReportPartView createMachineReportPartView(){
    return coreFactory.createMachineReportPartView();
}

public
MachineReportViewContainer createMachineReportViewContainer(){
    return coreFactory.createMachineReportViewContainer();
}

public
MachineReportPartView cloneMachineReportPartView(MachineReportPartView machineReportPartView){
    return coreFactory.cloneMachineReportPartView(machineReportPartView);
}

public
LabourPlanningReportView createLabourPlanningReportView(){
    return coreFactory.createLabourPlanningReportView();
}

public
LabourPlanningReportViewContainer createLabourPlanningReportViewContainer(){
    return coreFactory.createLabourPlanningReportViewContainer();
}

public
ReportWeeksView createReportWeeksView(){
    return coreFactory.createReportWeeksView();
}

public
ReportWeeksViewContainer createReportWeeksViewContainer(){
    return coreFactory.createReportWeeksViewContainer();
}
 
public
PartReportWeeksViewContainer createPartReportWeeksViewContainer(){
    return coreFactory.createPartReportWeeksViewContainer();
}

public
CellPlanningLabType createCellPlanningLabType(){
    return coreFactory.createCellPlanningLabType();
}

public
CapacityPart generateNewCapacityPartBasedPlanned(CapacityHdr capacityHdr,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart){
    return coreFactory.generateNewCapacityPartBasedPlanned(capacityHdr,machineReportPartView,cellMachinePart);
}

public
ScheduleMaterialConsumPart createScheduleMaterialConsumPart(){
	return coreFactory.createScheduleMaterialConsumPart();
}

public
ScheduleMaterialConsumPartContainer createScheduleMaterialConsumPartContainer(){
	return coreFactory.createScheduleMaterialConsumPartContainer();
}

public
ScheduleMaterialConsumPart cloneScheduleMaterialConsumPart(ScheduleMaterialConsumPart scheduleMaterialConsumPart){
	return coreFactory.cloneScheduleMaterialConsumPart(scheduleMaterialConsumPart);
}


#endregion ScheduleHdr


#region Routing

public
Routing createRouting(){
	return coreFactory.createRouting();
}

public
RoutingContainer createRoutingContainer(){
	return coreFactory.createRoutingContainer();
}
public
RoutingLabTool createRoutingLabTool(){
	return coreFactory.createRoutingLabTool();
}

public
RoutingLabToolContainer createRoutingLabToolContainer(){
	return coreFactory.createRoutingLabToolContainer();
}

public
bool existsRouting(string prodID, string plt, string dept, string actID, int seq, string cfg){
	return coreFactory.existsRouting(prodID, plt, dept, actID, seq, cfg);
}	

public
Routing readRouting(int id){
	return coreFactory.readRouting(id);
}

public
RoutingContainer readRoutingByFilters(string spart,string splant,string sdept,int seq,string smach,string sroutingType,bool blabToolInvolved,bool bonlyHdr,int rows){
	return coreFactory.readRoutingByFilters(spart, splant, sdept, seq, smach, sroutingType, blabToolInvolved, bonlyHdr, rows);
}

public
void updateRouting(Routing routing){
	coreFactory.updateRouting(routing);
}		

public
void writeRouting(Routing routing){
	coreFactory.writeRouting(routing);
}		

public
void deleteRouting(int id){
	coreFactory.deleteRouting(id);
}		

public
RoutingLabTool cloneRoutingLabTool(RoutingLabTool routingLabTool){
	return coreFactory.cloneRoutingLabTool(routingLabTool);
}		

/*
public
LabourType createLabourType(){
	return coreFactory.createLabourType();
}		

public
LabourTypeContainer createLabourTypeContainer(){
	return coreFactory.createLabourTypeContainer();
}
*/
public
LabourTypeRequired createLabourTypeRequired(){
	return coreFactory.createLabourTypeRequired();
}
 
public
LabourTypeRequiredContainer createLabourTypeRequiredContainer(){
	return coreFactory.createLabourTypeRequiredContainer();
}

/*
public
LabourType readLabourType(int id){
	return coreFactory.readLabourType(id);
}

public
void updateLabourType(LabourType labourType){
	coreFactory.updateLabourType(labourType);
}

public
void writeLabourType(LabourType labourType){
	coreFactory.writeLabourType(labourType);
}

public
void deleteLabourType(int id){
	coreFactory.deleteLabourType(id);
}

public
LabourTypeContainer readLabourTypeByFilters(string scode, string slabName, string sdirInd, int rows){
	return coreFactory.readLabourTypeByFilters(scode, slabName, sdirInd, rows);
}
*/
public
string[][] readToolByFilters(string scompany,string splant,string stoolNumber, string sdesc1,int rows){
	return coreFactory.readToolByFilters(scompany, splant, stoolNumber, sdesc1, rows);
}

public
string[][] getHotListLabourType(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows){
	return coreFactory.getHotListLabourType(id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq, sglExp, sreportedPoint, borderByDemand, bgetCumulativeQty, baddReceipParts, baddMaterialConsumPart, rows);
}

public
LabourTypeRequiredContainer getHotListLabourType2(Hashtable hashMachines,Hashtable hashRoutings, Hashtable hashTasks, ScheduleHdr scheduleHdr,int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,string sprodFamily,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows){
	return coreFactory.getHotListLabourType2(hashMachines, hashRoutings, hashTasks,scheduleHdr, id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq, sglExp, sreportedPoint, sprodFamily, borderByDemand, bgetCumulativeQty, baddReceipParts, baddMaterialConsumPart, rows);
}

public
LabourPlanningReportViewContainer getPlannedLabourType(LabourPlanningReportViewContainer labourPlanningReportViewContainer, PlannedHdr plannedHdrFilter ,Hashtable hashMachinesById,Hashtable hashRoutings, Hashtable hashTasks,string splant,string sdept,int imachineId,string spart,int iseq,string sreportedPoint,bool bgenericShiftNum,int rows){
	return coreFactory.getPlannedLabourType(labourPlanningReportViewContainer, plannedHdrFilter, hashMachinesById, hashRoutings, hashTasks, splant, sdept, imachineId, spart, iseq, sreportedPoint, bgenericShiftNum, rows);
}

public
decimal loadPlannedHdrHoursByMachineRangeDate(PlannedHdr plannedHdr, Hashtable hashPrHistSum, int imachineId,DateTime startDate,DateTime endDate,Hashtable hashRoutings){
    return coreFactory.loadPlannedHdrHoursByMachineRangeDate(plannedHdr, hashPrHistSum,imachineId, startDate, endDate, hashRoutings);
}

public
PlannedHdr machinePlannedFillAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine,MachineReportPartView machineReportPartView){
    return coreFactory.machinePlannedFillAutomatic(plannedHdrFilter,inventoryObjectiveHdrFilter,splant,machine,machineReportPartView);
}

public
PlannedHdr machinePlannedFillFullAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine, MachineReportViewContainer machineReportViewContainer,bool bcheckMaxBuilds){
    return coreFactory.machinePlannedFillFullAutomatic(plannedHdrFilter, inventoryObjectiveHdrFilter, splant, machine, machineReportViewContainer, bcheckMaxBuilds);
}

public
PlannedHdr machinePlannedClearAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine, MachineReportViewContainer machineReportViewContainer){
    return coreFactory.machinePlannedClearAutomatic(plannedHdrFilter, inventoryObjectiveHdrFilter, splant, machine, machineReportViewContainer);
}

public
MachineContainer loadMachinePlannedHdrShiftRemainings(PlannedHdr plannedHdr, CapacityHdr capacityHdr,string splant,Hashtable hashPrHistSum,Hashtable hashRoutings){
    return coreFactory.loadMachinePlannedHdrShiftRemainings(plannedHdr,capacityHdr,splant, hashPrHistSum,hashRoutings);
}

public
int createDefaultsRoutingLabour(){
    return coreFactory.createDefaultsRoutingLabour();
}

/*
public
LabourType cloneLabourType(LabourType labourType){
	return coreFactory.cloneLabourType(labourType);
}*/

#endregion Routing

#region PlannedHdr
public
PlannedHdr createPlannedHdr(){
	return coreFactory.createPlannedHdr();
}

public
PlannedHdrContainer createPlannedHdrContainer(){
	return coreFactory.createPlannedHdrContainer();
}

public
PlannedLabour createPlannedLabour(){
	return coreFactory.createPlannedLabour();
}

public
PlannedLabourContainer createPlannedLabourContainer(){
	return coreFactory.createPlannedLabourContainer();
}

public
bool existsPlannedHdr(int id){
	return coreFactory.existsPlannedHdr(id);
}

public
PlannedHdr readPlannedHdr(int id){
	return coreFactory.readPlannedHdr(id);
}

public
PlannedHdr readPlannedHdrLast(string splant){
	return coreFactory.readPlannedHdrLast(splant);
}

public
PlannedHdr readPlannedHdrLastDateCheck(PlannedHdr plannedHdr,string splant){
	return coreFactory.readPlannedHdrLastDateCheck(plannedHdr,splant);
}

public
void updatePlannedHdr(PlannedHdr plannedHdr){
	coreFactory.updatePlannedHdr (plannedHdr);
}

public
void updatePlannedHdrOnlyPlannedReq(PlannedHdr plannedHdr,PlannedReq plannedReq,bool bisNewReq){
	coreFactory.updatePlannedHdrOnlyPlannedReq(plannedHdr,plannedReq,bisNewReq);
}

public
void writePlannedHdr(PlannedHdr plannedHdr){
	coreFactory.writePlannedHdr (plannedHdr);
}

public
void deletePlannedHdr(int id){
	coreFactory.deletePlannedHdr(id);
}

public
PlannedHdr clonePlannedHdr(PlannedHdr plannedHdr){
	return coreFactory.clonePlannedHdr(plannedHdr);
}

public
bool updatePlannedPart(PlannedHdr plannedHdr,PlannedPart plannedPart){
	return coreFactory.updatePlannedPart(plannedHdr,plannedPart);
}

public
PlannedPart generateNewPlannedPartBasedPlanned(PlannedHdr plannedHdr,string splant,int imachineId, string spart, int iseq,decimal dqty, decimal dtyOvertime, DateTime startDate, bool bgenerateForChilds){
	return coreFactory.generateNewPlannedPartBasedPlanned(plannedHdr, splant, imachineId,spart,iseq,dqty, dtyOvertime,startDate, bgenerateForChilds);
}

public
PlannedLabour generateNewPlannedLabourBasedPlanned(PlannedHdr plannedHdr,string splant,int imachineId, int ishiftNum, CapacityView capacityView, CellPlanningLabType cellPlanningLabType){
	return coreFactory.generateNewPlannedLabourBasedPlanned(plannedHdr, splant, imachineId, ishiftNum, capacityView, cellPlanningLabType);
}

public
void getPlannedPartViewByFilters(string splant,string spart,int seq){
    coreFactory.getPlannedPartViewByFilters(splant,spart,seq);
}

public
bool readPlannedPartsHash(string splant,ref DateTime plannedDateTimeStamp,ref Hashtable hashPlannedParts){
    return coreFactory.readPlannedPartsHash(splant, ref plannedDateTimeStamp, ref hashPlannedParts);
}

public
bool compareNewHotListVsPriorHotListFillPlannedQtyChange(string splant){
    return coreFactory.compareNewHotListVsPriorHotListFillPlannedQtyChange(splant);
}

public
bool existsPlannedPartSfiftProfileMachine(int iprofShiftHdrId,int iprofShiftHdrDtl){
    return coreFactory.existsPlannedPartSfiftProfileMachine(iprofShiftHdrId,iprofShiftHdrDtl);
}

public
void plannedMoveQtyChangeToPlanned(PlannedHdr plannedHdr, string splant,int imachineId,DateTime fromDate){          
    coreFactory.plannedMoveQtyChangeToPlanned(plannedHdr,splant,imachineId,fromDate);
}

#endregion PlannedHdr


#region InventoryObjectives

public
InventoryObjectiveHdr createInventoryObjectiveHdr(){
	return coreFactory.createInventoryObjectiveHdr();
}

public
InventoryObjectiveHdrContainer createInventoryObjectiveHdrContainer(){
	return coreFactory.createInventoryObjectiveHdrContainer();
}

public
bool existsInventoryObjectiveHdr(int id){
	return coreFactory.existsInventoryObjectiveHdr(id);
}

public
InventoryObjectiveHdr readInventoryObjectiveHdr(int id){
	return coreFactory.readInventoryObjectiveHdr(id);
}

public
void updateInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr){
	coreFactory.updateInventoryObjectiveHdr(inventoryObjectiveHdr);
}

public
void writeInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr){
	coreFactory.writeInventoryObjectiveHdr(inventoryObjectiveHdr);
}

public
void deleteInventoryObjectiveHdr(int id){
	coreFactory.deleteInventoryObjectiveHdr(id);
}

public
InventoryObjectiveHdrContainer readInventoryObjectiveHdrByFilters(string sid,string splant, string status,DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows){
	return coreFactory.readInventoryObjectiveHdrByFilters(sid, splant, status, fromDate, toDate, bonlyHeader, rows);
}

public
InventoryObjectiveHdr readInventoryObjectiveHdrLast(string splant){
    return coreFactory.readInventoryObjectiveHdrLast(splant);
}

public
InventoryObjectiveHdr readInventoryObjectiveHdrLastDateCheck(InventoryObjectiveHdr inventoryObjectiveHdr, string splant){
    return coreFactory.readInventoryObjectiveHdrLastDateCheck(inventoryObjectiveHdr,splant);
}

public
InventoryObjectiveHdr recalcAutomaticObjectives(string splant){
    return coreFactory.recalcAutomaticObjectives(splant);
}

public
InventoryObjectivePart generateNewInventoryObjectivePartBasedPlanned(InventoryObjectiveHdr inventoryObjectiveHdr, string splant, int imachineId, MachineReportPartView machineReportPartView, CellMachinePart cellMachinePart){
    return coreFactory.generateNewInventoryObjectivePartBasedPlanned(inventoryObjectiveHdr, splant, imachineId,machineReportPartView, cellMachinePart);
}

public
InventoryObjectivePart createInventoryObjectivePart(){
	return coreFactory.createInventoryObjectivePart();
}

public
InventoryObjectivePartContainer createInventoryObjectivePartContainer(){
	return coreFactory.createInventoryObjectivePartContainer();
}

public
InventoryObjectivePartDtl createInventoryObjectivePartDtl(){
	return coreFactory.createInventoryObjectivePartDtl();
}

public
InventoryObjectivePartDtlContainer createInventoryObjectivePartDtlContainer(){
	return coreFactory.createInventoryObjectivePartDtlContainer();
}

public
InventoryObjectiveReportView createInventoryObjectiveReportView(){
	return coreFactory.createInventoryObjectiveReportView();
}

public
InventoryObjectivePart cloneInventoryObjectivePart(InventoryObjectivePart inventoryObjectivePart){
	return coreFactory.cloneInventoryObjectivePart(inventoryObjectivePart);
}
        
#endregion InventoryObjectives

#region SchMaterialAvail

public
SchMaterialAvail createSchMaterialAvail(){
	return coreFactory.createSchMaterialAvail();
}

public
SchMaterialAvailContainer createSchMaterialAvailContainer(){
	return coreFactory.createSchMaterialAvailContainer();
}

public
SchProductAvail createSchProductAvail(Product product){
	return coreFactory.createSchProductAvail(product);
}

public
SchMaterialAvailContainer processSchMaterialAvail(SchMaterialAvailContainer schMaterialAvailTotUsedContainer, BomSumContainer matBomSumContainer, HotListHdr hotListHdr,string spart,int seq,DateTime dateTime,decimal dqty){
    return coreFactory.processSchMaterialAvail(schMaterialAvailTotUsedContainer, matBomSumContainer, hotListHdr, spart,seq,dateTime,dqty);
}

public
SchMaterialAvail readSchMaterialAvail(int id){
    return coreFactory.readSchMaterialAvail(id);
}

public
void updateSchMaterialAvail(SchMaterialAvail schMaterialAvail){
    coreFactory.updateSchMaterialAvail(schMaterialAvail);
}

public
void writeSchMaterialAvail(SchMaterialAvail schMaterialAvail){
    coreFactory.writeSchMaterialAvail(schMaterialAvail);
}

public
SchMaterialAvailContainer readSchMaterialAvailByFilters(string splant, int parentSrcHotId, int parentSrcHotDtlId, int notParentSrcHotDtlId, string sparentPart, int partentSeq, string schildPart, int childSeq,DateTime dateTime,bool blastSeq,int rows){
    return coreFactory.readSchMaterialAvailByFilters(splant, parentSrcHotId, parentSrcHotDtlId, notParentSrcHotDtlId, sparentPart, partentSeq, schildPart, childSeq, dateTime, blastSeq, rows);
}

#endregion SchMaterialAvail

#region PackSlip

public
PackSlip createPackSlip(){
	return coreFactory.createPackSlip();
}

public
PackSlipContainer createPackSlipContainer(){
	return coreFactory.createPackSlipContainer();
}

public
bool existsPackSlip(int id){
	return coreFactory.existsPackSlip(id);
}

public
PackSlip readPackSlip(int id){
	return coreFactory.readPackSlip(id);
}

public
void updatePackSlip(PackSlip packSlip){
	coreFactory.updatePackSlip(packSlip);
}

public
void writePackSlip(PackSlip packSlip){
	coreFactory.writePackSlip(packSlip);
}

public
void deletePackSlip(int id){
	coreFactory.deletePackSlip(id);
}

public
PackSlipContainer transferPackSlipByFilters(string splant,DateTime fromDate,DateTime toDate,bool brunQuickProcess,int irows){
	return coreFactory.transferPackSlipByFilters(splant, fromDate, toDate, brunQuickProcess,irows);
}

public
PackSlipContainer readPackSlipByFilters(string splant,DateTime fromDate,DateTime toDate,bool bonlyHeader,int irows){
	return coreFactory.readPackSlipByFilters(splant, fromDate, toDate, bonlyHeader,irows);
}


#endregion PackSlip


#region ProductPlanDt

public
ProductPlanDt createProductPlanDt(){
	return coreFactory.createProductPlanDt();
}

public
ProductPlanDtContainer createProductPlanDtContainer(){
	return coreFactory.createProductPlanDtContainer();
}

public
ProductPlanDtContainer readProductPlanDtByFilters(string sfamCfg, int ifamSeq,string spart,int iseq,int rows){
	return coreFactory.readProductPlanDtByFilters(sfamCfg, ifamSeq, spart, iseq, rows);
}

#endregion ProductPlanDt



#region UpCum01P        
public
UpCum01P createUpCum01P(){
	return coreFactory.createUpCum01P();
}

public
UpCum01PContainer createUpCum01PContainer(){
	return coreFactory.createUpCum01PContainer();
}

public
UpCum01PViewContainer createUpCum01PViewContainer(){
	return coreFactory.createUpCum01PViewContainer();
}


public
bool existsUpCum01P(decimal fGBOL, decimal fGENT){
	return coreFactory.existsUpCum01P(fGBOL, fGENT);
}

public
UpCum01P readUpCum01P(decimal fGBOL, decimal fGENT){
	return coreFactory.readUpCum01P(fGBOL, fGENT);
}

public
void updateUpCum01P(UpCum01P upCum01P){
	coreFactory.updateUpCum01P (upCum01P);
}

public
void writeUpCum01P(UpCum01P upCum01P){
	coreFactory.writeUpCum01P (upCum01P);
}

public
void deleteUpCum01P(decimal fGBOL, decimal fGENT){
	coreFactory.deleteUpCum01P(fGBOL, fGENT);
}

public
UpCum01P cloneUpCum01P(UpCum01P upCum01P){
	return coreFactory.cloneUpCum01P(upCum01P);
}

public
UpCum01PContainer readUpCum01PByFilters(decimal fGBOL, decimal fGENT,string sbillTo,string shipTo){
	return coreFactory.readUpCum01PByFilters(fGBOL, fGENT, sbillTo, shipTo);
}

public
UpCum01PViewContainer readUpCum01PCustomByFilters(string splant,string stpartner,string sbillTo,string shipTo,string sbol, string sorder, string spo, string scustPO,string shipped,string sdocType,string srelease, decimal orderItem,bool blateOrders, string sppap,DateTime fromDate, DateTime toDate,int irows){
	return coreFactory.readUpCum01PCustomByFilters(splant,stpartner, sbillTo, shipTo, sbol, sorder,  spo, scustPO, shipped, sdocType, srelease, orderItem,blateOrders, sppap,fromDate, toDate, irows);
}

public
void adjustNewShipExportFields(UpCum01PViewContainer upCum01PViewContainer){
	coreFactory.adjustNewShipExportFields(upCum01PViewContainer);
}

#endregion UpCum01P   

#region CustPart

public
CustParts createCustParts(){
	return coreFactory.createCustParts();
}

public
CustPartsContainer createCustPartsContainer(){
	return coreFactory.createCustPartsContainer();
}

public
bool existsCustPart(string prodID, string billToCust, string shipToCust){
	return coreFactory.existsCustPart(prodID, billToCust, shipToCust);
}

public
CustParts readCustPart(string prodID, string billToCust, string shipToCust){
	return coreFactory.readCustPart(prodID, billToCust, shipToCust);
}

public
void updateCustPart(CustParts custPart){
	coreFactory.updateCustPart(custPart);
}

public
void writeCustPart(CustParts custPart){
	coreFactory.writeCustPart(custPart);
}

public
void deleteCustPart(string prodID, string billToCust, string shipToCust){
	coreFactory.deleteCustPart(prodID, billToCust, shipToCust);
}

public
CustParts cloneCustParts(CustParts custPart){
	return coreFactory.cloneCustParts(custPart);
}

public
CustPartsContainer readCustPartByFilters(string spart,string sbillTo,string shipTo,string scustPart,int irows){
	return coreFactory.readCustPartByFilters(spart, sbillTo, shipTo, scustPart, irows);
}


#endregion CustPart

#region ShipExport

public
ShipExport createShipExport(){
	return coreFactory.createShipExport();
}

public
ShipExportContainer createShipExportContainer(){
	return coreFactory.createShipExportContainer();
}


public
ShipExportDtl createShipExportDtl(){
	return coreFactory.createShipExportDtl();
}

public
ShipExportDtlContainer createShipExportDtlContainer(){
	return coreFactory.createShipExportDtlContainer();
}

public
bool existsShipExport(string site, decimal bol, decimal bolItem){
	return coreFactory.existsShipExport(site,  bol, bolItem);
}

public
ShipExport readShipExport(string site, decimal bol, decimal bolItem){
	return coreFactory.readShipExport(site,  bol, bolItem);
}

public
void updateShipExport(ShipExport shipExport){
	coreFactory.updateShipExport(shipExport);
}

public
void writeShipExport(ShipExport shipExport){
	coreFactory.writeShipExport(shipExport);
}

public
void deleteShipExport(string site, decimal bol, decimal bolItem){
	coreFactory.deleteShipExport(site,  bol, bolItem);
}

public
ShipExport cloneShipExport(ShipExport shipExport){
	return coreFactory.cloneShipExport(shipExport);
}

public
ShipExportContainer readShipExportByFilters(string sbillTo,string shipTo, string smajSales,DateTime fromShipDate,DateTime toShipDate,int rows){
	return coreFactory.readShipExportByFilters(sbillTo, shipTo, smajSales,fromShipDate, toShipDate, rows);
}

public
ShipExportContainer adjustShipExporAndSumLeadTime(ShipExport shipExport){
    return coreFactory.adjustShipExporAndSumLeadTime(shipExport);
}

public
ShipExportContainer bolsShipExport(UpCum01PViewContainer upCum01PViewContainer){
	return coreFactory.bolsShipExport(upCum01PViewContainer);
}

public
ShipExportContainer reprocessShipExportSum(ShipExportSumContainer shipExportSumContainerProcess){
	return coreFactory.reprocessShipExportSum(shipExportSumContainerProcess);
}

public
bool loadShipExportDtlsFromAS400(UpCum01PViewContainer upCum01PViewContainer){
	return coreFactory.loadShipExportDtlsFromAS400(upCum01PViewContainer);
}

public
void loadShipExportToUpCum01PList(UpCum01PViewContainer upCum01PViewContainer){
	coreFactory.loadShipExportToUpCum01PList(upCum01PViewContainer);
}

public
ShipExportContainer processShipExportAutomatically(string splant){
	return coreFactory.processShipExportAutomatically(splant);
}


public
int loadCustPOToShipExport(){
	return coreFactory.loadCustPOToShipExport();
}


public
ShipExportSum createShipExportSum(){
	return coreFactory.createShipExportSum();
}

public
ShipExportSumContainer createShipExportSumContainer(){
	return coreFactory.createShipExportSumContainer();
}

public
bool existsShipExportSum(decimal orderNum, decimal item, string release){
	return coreFactory.existsShipExportSum(orderNum, item, release);
}

public
ShipExportSum readShipExportSum(decimal orderNum, decimal item, string release){
	return coreFactory.readShipExportSum(orderNum, item, release);
}

public
void updateShipExportSum(ShipExportSum shipExportSum){
	coreFactory.updateShipExportSum (shipExportSum);
}

public
void updateShipExportSumForced(ShipExportSum shipExportSum){
	coreFactory.updateShipExportSumForced(shipExportSum);
}

public
void writeShipExportSum(ShipExportSum shipExportSum){
	coreFactory.writeShipExportSum (shipExportSum);
}

public
void updateShipExportSumNote(ShipExportSum shipExportSum){
	coreFactory.updateShipExportSumNote(shipExportSum);
}

public
void deleteShipExportSum(decimal orderNum, decimal item, string release){
	coreFactory.deleteShipExportSum(orderNum, item, release);
}

public
ShipExportSum cloneShipExportSum(ShipExportSum shipExportSum){
	return coreFactory.cloneShipExportSum(shipExportSum);
}

public
ShipExportSumContainer createShipExportSumNewFields(UpCum01PViewContainer upCum01PViewContainer){
	return coreFactory.createShipExportSumNewFields(upCum01PViewContainer);
}

public
void loadGenericPriorCum(){
	coreFactory.loadGenericPriorCum();
}

public
ShipExportSumContainer readShipExportSumByFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows){
	return coreFactory.readShipExportSumByFilters(splant,sbillTo, shipTo, sbol, sorder, scustPO, sdocType, srelease, orderItem, blateOrders, sppap, fromDate, toDate, irows);
}

public
ShipExportSumContainer readShipExportSumCompareByFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,
                                                        bool bqtyOrder, bool bqtyShip, bool bdateReq, bool bdateShip,bool bqtyPpm, bool bleadTime, bool bppap,int irows){
	return coreFactory.readShipExportSumCompareByFilters(splant,sbillTo, shipTo, sbol, sorder, scustPO, sdocType, srelease, orderItem, blateOrders, sppap, fromDate, toDate,
                                                    bqtyOrder, bqtyShip, bdateReq,  bdateShip, bqtyPpm, bleadTime, bppap,irows);
}

#endregion ShipExport

#region CustLead

public
CustLead createCustLead(){
	return coreFactory.createCustLead();
}

public
CustLeadContainer createCustLeadContainer(){
	return coreFactory.createCustLeadContainer();
}

public
bool existsCustLead(string custId, string majSalesCode, string minSalesCode){
	return coreFactory.existsCustLead(custId, majSalesCode, minSalesCode);
}

public
CustLead readCustLead(string custId, string majSalesCode, string minSalesCode){
	return coreFactory.readCustLead(custId, majSalesCode, minSalesCode);
}

public
void updateCustLead(CustLead custLead){
	coreFactory.updateCustLead(custLead);
}

public
void writeCustLead(CustLead custLead){
	coreFactory.writeCustLead(custLead);
}

public
void deleteCustLead(string custId, string majSalesCode, string minSalesCode){
	coreFactory.deleteCustLead(custId, majSalesCode, minSalesCode);
}

public
CustLead cloneCustLead(CustLead custLead){
	return coreFactory.cloneCustLead(custLead);
}

public
CustLeadContainer readCustLeadByFilters(string scustID,string sexactCustId,string smajSalesCode,string sminSalesCode,int irows){
	return coreFactory.readCustLeadByFilters(scustID,sexactCustId, smajSalesCode, sminSalesCode, irows);
}

public
CustLeadContainer readCustLeadByCustomerFilters(string scustID,string smajSalesCode){
	return coreFactory.readCustLeadByCustomerFilters(scustID,smajSalesCode);
}

#endregion CustLead


#region Stxh

public
Stxh createStxh(){
	return coreFactory.createStxh();
}
 
public
StxhContainer createStxhContainer(){
	return coreFactory.createStxhContainer();
}

public
StxhContainer readStxhByFilters(decimal oYLOG,string oYTRPR,string oYDOCN, DateTime fromDate, DateTime toDate, int irows){
	return coreFactory.readStxhByFilters(oYLOG, oYTRPR,oYDOCN, fromDate,toDate,irows);
}

public
ArrayList getStxhDifferentsTPartnerByFiltersDate(DateTime fromDate,DateTime toDate){
	return coreFactory.getStxhDifferentsTPartnerByFiltersDate(fromDate,toDate);
}


#endregion Stxh


#region LastExported

public
LastExported createLastExported(){
	return coreFactory.createLastExported();
}

public
LastExportedContainer createLastExportedContainer(){
	return coreFactory.createLastExportedContainer();
}

public
bool existsLastExported(string code){
	return coreFactory.existsLastExported(code);
}

public
LastExported readLastExported(string code){
	return coreFactory.readLastExported(code);
}

public
void updateLastExported(LastExported lastExported){
	coreFactory.updateLastExported(lastExported);
}

public
void writeLastExported(LastExported lastExported){
	coreFactory.writeLastExported(lastExported);
}

public
void deleteLastExported(string code){
	coreFactory.deleteLastExported(code);
}

#endregion LastExported


#region EdiTransTP

public
EdiTransTP createEdiTransTP(){
    return coreFactory.createEdiTransTP();
}
    
public
EdiTransTPContainer createEdiTransTPContainer(){
    return coreFactory.createEdiTransTPContainer();
}
 
public
EdiTransTPContainer createEdiTransTPartnerAutomatic(){
    return coreFactory.createEdiTransTPartnerAutomatic();
}

public
void justTestDemandDay(){
    coreFactory.justTestDemandDay();
}

#endregion EdiTransTP


#region ShipExportRelease

public
ShipExportRelease createShipExportRelease(){
    return coreFactory.createShipExportRelease();
}
 
public
ShipExportReleaseContainer createShipExportReleaseContainer(){
    return coreFactory.createShipExportReleaseContainer();
}

public
bool loadShipExportReleasesFromAS400(UpCum01PViewContainer upCum01PViewContainer){
    return coreFactory.loadShipExportReleasesFromAS400(upCum01PViewContainer);
}

#endregion ShipExportRelease

#region TradingPartner

public
TradingPartner createTradingPartner(){
    return coreFactory.createTradingPartner();
}

public
TradingPartnerContainer createTradingPartnerContainer(){
    return coreFactory.createTradingPartnerContainer();
}
 
public
bool existsTradingPartner(string tPartner){
    return coreFactory.existsTradingPartner(tPartner);
}

public
TradingPartner readTradingPartner(string tPartner){
    return coreFactory.createTradingPartner();
}

public
void updateTradingPartner(TradingPartner tradingPartner){
    coreFactory.createTradingPartner();
}

public
void writeTradingPartner(TradingPartner tradingPartner){
    coreFactory.createTradingPartner();
}

public
void deleteTradingPartner(string tPartner){
    coreFactory.createTradingPartner();
}

public
TradingPartner cloneTradingPartner(TradingPartner tradingPartner){
    return coreFactory.createTradingPartner();
}

public
TradingPartnerContainer readTradingPartnerByFilters(string stpartner,int irows){
    return coreFactory.readTradingPartnerByFilters(stpartner,irows);
}

#endregion TradingPartner


#region Trlp

public
ArrayList readTrlpTradingPartners(string splant,string source){
    return coreFactory.readTrlpTradingPartners(splant,source);
}

public
ArrayList readTrlpShipLocs(string stpartner){
    return coreFactory.readTrlpShipLocs(stpartner);
}

public
ArrayList readTrlpPartsByFilters(string stpartner,string shipLoc){
    return coreFactory.readTrlpPartsByFilters(stpartner,shipLoc);
}

public
DemandDCompareViewContainer getAS400DemandDCompareViewReportByFilters(string splant, string source, string stPartner, string shipLoc, string spart, DateTime runDate, DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){
    return coreFactory.getAS400DemandDCompareViewReportByFilters(splant, source, stPartner, shipLoc, spart, runDate, startRelDate, endRelDate, bcumulative, irows);
}

public
DemandDCompareViewContainer getLocalDemandDCompareViewReportByFilters(string splant, string source, string stPartner, string shipLoc, string spart, DateTime runDate, DateTime startRelDate, DateTime endRelDate,bool bcumulative,bool bqtyDifferences,int irows){
    return coreFactory.getLocalDemandDCompareViewReportByFilters(splant, source, stPartner, shipLoc, spart, runDate, startRelDate, endRelDate, bcumulative, bqtyDifferences, irows);
}

public
DemandDCompareViewContainer getAS400DemandDCompareViewReportBoldByFilters(string splant, string source, string stPartner, string shipLoc, string spart, DateTime runDate, DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){
    return coreFactory.getAS400DemandDCompareViewReportBoldByFilters(splant, source, stPartner, shipLoc, spart, runDate, startRelDate, endRelDate, bcumulative, irows);
}

public
DemandDCompareViewContainer getLocalDemandDCompareAllViewReportByFilters(string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum, DateTime runDate,DateTime fromDate,DateTime toDate,int irows){
    return coreFactory.getLocalDemandDCompareAllViewReportByFilters(splant,source,stPartner,shipLoc,spart,snewRelNum, runDate,fromDate, toDate,irows);
}

public
DemandDCompareViewContainer getLocalDemandDCompareAllViewReportByFilters2(string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum, DateTime runDate,DateTime fromDate,DateTime toDate, bool bshowDifferences,bool bqtyDifferences,bool bcumulative,bool bcolumnsWQty,int irows){
    return coreFactory.getLocalDemandDCompareAllViewReportByFilters2(splant,source,stPartner,shipLoc,spart,snewRelNum, runDate,fromDate, toDate, bshowDifferences, bqtyDifferences, bcumulative, bcolumnsWQty,irows);
}

public
DemandDCompareReportViewContainer getLocalDemandDCompareAllViewReportByFilters3(string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum, DateTime runDate,DateTime fromDate,DateTime toDate, bool bshowDifferences,bool bqtyDifferences,bool bcumulative,bool bcolumnsWQty,int irows){
    return coreFactory.getLocalDemandDCompareAllViewReportByFilters3(splant,source,stPartner,shipLoc,spart,snewRelNum, runDate,fromDate, toDate, bshowDifferences, bqtyDifferences, bcumulative, bcolumnsWQty,irows);
}

#endregion Trlp

} // class
} // namespace

