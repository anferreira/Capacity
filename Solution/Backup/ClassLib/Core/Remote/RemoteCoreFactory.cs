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
int cms400ToCmsTempItems(){
	return coreFactory.cms400ToCmsTempItems();
}

public
int cmsTempToNujitItems(){
	return coreFactory.cmsTempToNujitItems();
}

public
int generateCMSItems(){
	return coreFactory.generateCMSItems();
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

#endregion

#region BOM

// Methods are implemented here
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
BomContainer makeBoms(){
	return coreFactory.makeBoms();
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
makeBomFromProdIDAndSeq (string prodId, int seqId){
	return coreFactory.makeBomFromProdIDAndSeq (prodId, seqId);
}

public
void seeBom(Bom bom, string parent){
	coreFactory.seeBom(bom, parent);
}

public
string[][] getAllPurchasedMaterials(string prodId, int seqId){
	return coreFactory.getAllPurchasedMaterials(prodId, seqId);
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
void createHotList(string[] stkbFilter, string[] wipbFilter, string[][] badWipb){
	coreFactory.createHotList(stkbFilter, wipbFilter, badWipb);
}

public 
string[][] getHotListAsString(int id,string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	return coreFactory.getHotListAsString(id,filterDept, filterPart, filterMg, onlyDemand, type);
}

public 
string[][] getDemandAsString(string[] filterPart){
	return coreFactory.getDemandAsString(filterPart);
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
string[][] getAllMatReqAsString(string[] depts, string[]parts ){
	return coreFactory.getAllMatReqAsString(depts, parts);
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
string[][] getMaterialDueDate(bool weeks, string[] depts, string[] parts, bool orderByVendor, string[] stkLocs){
	return coreFactory.getMaterialDueDate(weeks, depts, parts, orderByVendor, stkLocs);
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
bool existsInventory(string prodId){
	return coreFactory.existsInventory(prodId);
}

public 
Inventory readInventory(string prodId){
	return coreFactory.readInventory(prodId);
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
Machine readMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach){
	return coreFactory.readMachine(PDM_Plt, PDM_Dept, PDM_Mach);
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
decimal[] getSeqQOHs(string part){
	return coreFactory.getSeqQOHs(part);
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
string[][] getComponentsFromFamily(string familyCode){
	return coreFactory.getComponentsFromFamily(familyCode);
}

public
string[][] getAllMaterialsForProduct(string prodId, int seqId){
	return coreFactory.getAllMaterialsForProduct(prodId, seqId);
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
DepartamentContainer readDepartaments(){
	return coreFactory.readDepartaments();
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
string[][] getDiscountsByDesc(string sdesc,int itop){
	return coreFactory.getDiscountsByDesc (sdesc, itop);
}

public
ArrayList getDiscountsInGroupDescByDesc(string sgroupId,string sdesc,int itop,string sorderBy){
	return coreFactory.getDiscountsInGroupDescByDesc (sgroupId, sdesc, itop, sorderBy);
}

public
bool existsDiscount(string sdiscount){
	return coreFactory.existsDiscount (sdiscount);
}

public
Discount readDiscount(string sdiscount){
	return coreFactory.readDiscount (sdiscount);
}

public
void updateDiscount(Discount discount){
	coreFactory.updateDiscount (discount);
}

public
void writeDiscount(Discount discount){
	coreFactory.writeDiscount (discount);
}

public
void deleteDiscount(string sdiscount){
	coreFactory.deleteDiscount (sdiscount);
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
Employee readEmployee(string id){
	return coreFactory.readEmployee (id);
}

public
string[][] getEmployeeByDesc(string desc, int iTop){
	return coreFactory.getEmployeeByDesc(desc, iTop);
}

public
string[][] getGroupDiscByCode (string sgroupCode){
	return coreFactory.getGroupDiscByCode (sgroupCode);
}

public
GroupDisc readGroupDisc(string sgroupCode, int idisNum){
	return coreFactory.readGroupDisc (sgroupCode, idisNum);
}

public
bool existsGroupDisc(string sgroupCode, int idisNum){
	return coreFactory.existsGroupDisc (sgroupCode, idisNum);
}

public
void writeGroupDisc(GroupDisc groupDisc){
	coreFactory.writeGroupDisc (groupDisc);
}

public
void updateGroupDisc(GroupDisc groupDisc){
	coreFactory.updateGroupDisc(groupDisc);
}

public
void deleteGroupDisc(GroupDisc groupDisc){
	coreFactory.deleteGroupDisc (groupDisc);
}

public
Note[] readNotes(string stype, int ikey1,int ikey2,int ikey3){
	return coreFactory.readNotes (stype, ikey1, ikey2, ikey3);
}

public
Note readNote(string stype, int ikey1,int ikey2,int ikey3,int ilineNum){
	return coreFactory.readNote (stype, ikey1, ikey2, ikey3, ilineNum);
}

public
bool existsNote(string stype, int ikey1,int ikey2,int ikey3,int ilineNum){
	return coreFactory.existsNote (stype, ikey1, ikey2, ikey3, ilineNum);
}

public
void writeNote(Note note){
	coreFactory.writeNote (note);
}

public
void updateNote(Note note){
	coreFactory.updateNote (note);
}

public
void deleteNote(Note note){
	coreFactory.deleteNote (note);
}

public
void deleteNoteAllFromTypeKey(Note note){
	coreFactory.deleteNoteAllFromTypeKey (note);
}

public
int getMaxItemFromDetailCharge(int iorder, int itemNum){
	return coreFactory.getMaxItemFromDetailCharge (iorder, itemNum);
}

public
bool existsOrderDtlCharge(OrderDtlCharge orderDtlCharge){
	return coreFactory.existsOrderDtlCharge (orderDtlCharge);
}

public
OrderDtlCharge readOrderDetailCharge(OrderDtlCharge orderDtlChargeCons){
	return coreFactory.readOrderDetailCharge (orderDtlChargeCons);
}

public
OrderDtlCharge createOrderDtlCharge(){
	return coreFactory.createOrderDtlCharge();
}

public
OrderDtl readIfProductSold(string sprodId){
	return coreFactory.readIfProductSold (sprodId);
}

public
int getMaxOrderLine(int iorder){
	return coreFactory.getMaxOrderLine (iorder);
}

public
string[][] getOrderLinesById(int iorder){
	return coreFactory.getOrderLinesById (iorder);
}

public
Order getOrderLinesById(Order order){
	return coreFactory.getOrderLinesById (order);
}

public
OrderDtl readLineByProductId(int iorder,string sprodID){
return coreFactory.readLineByProductId (iorder, sprodID);
}

public
bool existsOrderLine(int iorder,int item){
	return coreFactory.existsOrderLine (iorder, item);
}

public
OrderDtl readOrderLine(int iorder,int item){
	return coreFactory.readOrderLine (iorder, item);
}

public
OrderDtl createOrderDtl(){
	return coreFactory.createOrderDtl();
}

public
int getMaxItemFromDetail(OrderDtlRel orderDtlRel){
	return coreFactory.getMaxItemFromDetail (orderDtlRel);
}

public
string[][] getOrderDetailRelById(OrderDtlRel orderDtlRel){
	return coreFactory.getOrderDetailRelById (orderDtlRel);
}

public
bool existsOrderDetailRel(OrderDtlRel orderDtlRel){
	return coreFactory.existsOrderDetailRel (orderDtlRel);
}

public
OrderDtlRel readOrderDetailRel(OrderDtlRel orderDtlRelCons){
	return coreFactory.readOrderDetailRel (orderDtlRelCons);
}

public
OrderDtl getOrderDetailRelById(OrderDtl orderDtl){
	return coreFactory.getOrderDetailRelById (orderDtl);
}

public
OrderDtlRel createOrderDtlRel(){
	return coreFactory.createOrderDtlRel();
}

public
void updateOrderNotSend(){
	coreFactory.updateOrderNotSend();
}

public
int getMaxOrderHeader(){
	return coreFactory.getMaxOrderHeader ();
}

public
Order getOrderHeader(int iorder){
	return coreFactory.getOrderHeader (iorder);
}

public
ArrayList readOrdersHeadersArrayList(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected){
	return coreFactory.readOrdersHeadersArrayList (sclient, semployee, dateSince, dateUntil, stypeOfOrderSelected);
}

public
Order[] readOrdersHeaders(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected, string sorderStatus, string sorderType, int iorderNum, bool onlyPendingOrders){
	return coreFactory.readOrdersHeaders (sclient, semployee, dateSince, dateUntil, stypeOfOrderSelected, sorderStatus, sorderType, iorderNum, onlyPendingOrders);
}

public
string[][] readOrdersHeaders(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected){
	return coreFactory.readOrdersHeaders (sclient, semployee, dateSince, dateUntil, stypeOfOrderSelected);
}

public
string[][] readOrdersHeadersNotSend(){
	return coreFactory.readOrdersHeadersNotSend();
}

public
bool existsOrderHeader(int iorder){
	return coreFactory.existsOrderHeader (iorder);
}

public
Order readOrderHeader(int iorder){
	return coreFactory.readOrderHeader (iorder);
}

public
Order readOrderHeaderAllData(int iorder){
	return coreFactory.readOrderHeaderAllData (iorder);
}

public
void writeOrderHeader(Order order){
	coreFactory.writeOrderHeader (order);
}

public
void writeCompleteOrder (Order order){
	coreFactory.writeCompleteOrder (order);
}

public
void writeOrderHeaderAndLines(Order order){
	coreFactory.writeOrderHeaderAndLines (order);
}

public
void updateOrderHeader(Order order){
	coreFactory.updateOrderHeader (order);
}

public
void updateCompleteOrder(Order order){
	coreFactory.updateCompleteOrder (order);
}

public
void deleteOrderHeader(Order order){
	coreFactory.deleteOrderHeader (order);
}

public
bool sendOrderToCMS(Order order, string user){
	return coreFactory.sendOrderToCMS (order, user);
}

public
Order createOrder(){
	return coreFactory.createOrder();
}

public
string[][] readProductPriceByCustomer(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive, decimal quantity){
	return coreFactory.readProductPriceByCustomer (sproduct, scustomer, scustomersClass, sdateTime, sactive, quantity);
}

public
string[][] readProductPrice(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive,decimal quantity){
	return coreFactory.readProductPrice (sproduct, scustomer, scustomersClass, sdateTime, sactive, quantity);
}

public
bool existsProdPrice(string product,string customer,string type,DateTime EffecFrmDatem,DateTime EffecToDate,decimal volume){
	return coreFactory.existsProdPrice (product, customer, type, EffecFrmDatem, EffecToDate, volume);
}

public
void writeProdPrice(ProdPrice prodPrice){
	coreFactory.writeProdPrice (prodPrice);
}

public
void updateProdPrice(ProdPrice prodPrice){
	coreFactory.updateProdPrice (prodPrice);
}

public
void deleteProdPrice(ProdPrice prodPrice){
	coreFactory.deleteProdPrice (prodPrice);
}

public
void deleteProdPriceOldies(DateTime dateTime){
	coreFactory.deleteProdPriceOldies (dateTime);
}

public
ProductActCost readProductActCost(string sproduct, int iseq){
	return coreFactory.readProductActCost (sproduct, iseq);
}

public
bool existsProdFmActCost(string sproduct, int iseq){
	return coreFactory.existsProdFmActCost (sproduct, iseq);
}

public
void writeProdFmActCost(ProductActCost productActCost){
	coreFactory.writeProdFmActCost (productActCost);
}

public
void updateProdFmActCost(ProductActCost productActCost){
	coreFactory.updateProdFmActCost (productActCost);
}

public
void deleteProdFmActCost(ProductActCost productActCost){
	coreFactory.deleteProdFmActCost (productActCost);
}
#endregion OE

public
string[][] getAllDownCodes(){
	return coreFactory.getAllDownCodes();
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

//#region StorageType
//public 
//StorageType createStorageType(){
//	return coreFactory.createStorageType();
//}
// 
//public 
//bool existsStorageType(string sdb,string stype){
//	return coreFactory.existsStorageType(sdb,stype);
//}
//
//public
//StorageType readStorageType(string sdb,string stype)
//{
//	return coreFactory.readStorageType(sdb,stype);
//}
//
//public 
//void updateStorageType(StorageType storageType){
//
//	coreFactory.updateStorageType(storageType);
//}
//   
//public 
//void writeStorageType(StorageType storageType){
//
//	coreFactory.writeStorageType(storageType);
//}
//
//public 
//void deleteStorageType(StorageType storageType){
//
//	coreFactory.deleteStorageType(storageType);
//}
//
//public
//string[][] getStorageTypeByDesc(string desc,string sdb){
//	return coreFactory.getStorageTypeByDesc(desc,sdb);
//}
//#endregion storaageType
//
//#region aisle
//public 
//Aisle createAisle(){
//	return coreFactory.createAisle();
//}
//
//public 
//bool existsAisle(string db, string aisle){
//	return coreFactory.existsAisle(db,aisle);
//}
//
//public 
//Aisle readAisle(string db, string aisle){
//	return coreFactory.readAisle(db,aisle);
//}
//
//public 
//void writeAisle(Aisle aisle){
//	coreFactory.writeAisle(aisle);
//}
//
//public 
//void updateAisle(Aisle aisle){
//	coreFactory.updateAisle(aisle);
//}
//
//public 
//void deleteAisle(Aisle aisle){
//	coreFactory.deleteAisle(aisle);
//}
//
//public
//string[][] getAisleByDesc(string desc,string sdb){
//	return coreFactory.getAisleByDesc(desc,sdb);
//}
//#endregion aisle

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

//#region bin
//public
//string[][] getBinsFromSLocAsString(string db,int company, string plant, string stkLoc){
//    return coreFactory.getBinsFromSLocAsString(db,company, plant, stkLoc);
//}
//
//public
//bool existsBin(string sdb,int icompany,string splant,string stkLoc,string sbin){
//	return coreFactory.existsBin(sdb,icompany,splant,stkLoc,sbin);
//}
//
//public
//bool existsBinByStkLoc(string sdb,int icompany,string splant,string stkLoc){
//	return coreFactory.existsBinByStkLoc(sdb,icompany,splant,stkLoc);
//}
//
//public
//Bin readBin(string sdb,int icompany,string splant,string stkLoc,string sbin){
//	return coreFactory.readBin(sdb,icompany,splant,stkLoc,sbin);
//}
//
//public 
//void updateBin(Bin bin){
//	coreFactory.updateBin(bin);
//}
//
//public 
//void writeBin(Bin bin){
//	coreFactory.writeBin(bin);
//}
//
//public 
//void deleteBin(Bin bin){
//	coreFactory.deleteBin(bin);
//}
//
//public
//Bin createBin(){
//	return coreFactory.createBin();
//}
//
//public
//string[][] getQohBinAsString(string db,int company,string plant, string stkLoc,string bin){
//    return coreFactory.getQohBinAsString(db,company,plant, stkLoc,bin);
//}
//
//
//public
//string[][] getSlotsFromBinAsString(string db,int company, string plant, string stkLoc, string bin){
//    return coreFactory.getSlotsFromBinAsString(db,company,plant,stkLoc,bin);
//}
//
//public
//bool existSlotByBin(string db,int company, string plant, string stkLoc, string bin){
//    return coreFactory.existSlotByBin(db,company,plant,stkLoc,bin);
//}
//
//public
//string[][] getBinByDesc(string desc,string sdb,int icompany,string splant,string stkLocation){
//	return coreFactory.getBinByDesc(desc,sdb,icompany,splant,stkLocation);
//}
//
//
//#endregion bin
//
//#region Slot
//public
//bool existsSlot(string db, int company, string plant, string stkLoc,string bin, string slot){
//    return coreFactory.existsSlot(db, company, plant, stkLoc,bin, slot);
//}
//
//public Slot createSlot(){
//    return coreFactory.createSlot();
//}
//
//public Slot readSlot(string db, int company, string plant, string stkLoc,string bin, string slot){
//    return coreFactory.readSlot(db, company, plant, stkLoc,bin, slot);
//}
//
//public void writeSlot(Slot slot){
//    coreFactory.writeSlot(slot);
//}
//
//public void updateSlot(Slot slot){
//    coreFactory.updateSlot(slot);
//}
//
//public void deleteSlot(Slot slot){
//    coreFactory.deleteSlot(slot);
//}
//
//public
//string[][] getSlotByDesc(	string desc,string sdb,int icompany,string splant,
//							string stkLocation,string sbin){
//	return coreFactory.getSlotByDesc(desc,sdb,icompany,splant,stkLocation,sbin);
//}
//#endregion Slot
//
//#region level
//public
//bool existsLevel(string db, int level){
//    return coreFactory.existsLevel(db, level);
//}
//
//public
//Level createLevel(){
//    return coreFactory.createLevel();
//}
//
//public
//Level readLevel(string db, int level){
//    return coreFactory.readLevel(db, level);
//}
//
//public
//void writeLevel(Level level){
//    coreFactory.writeLevel(level);
//}
//
//public
//void updateLevel(Level level){
//    coreFactory.updateLevel(level);
//}
//
//public
//void deleteLevel(Level level){
//    coreFactory.deleteLevel(level);
//}
//
//public
//string[][] getLevelByDesc(string desc,string sdb){
//	return coreFactory.getLevelByDesc(desc,sdb);
//}
//
//public
//bool existsBay(string db, string bay){
//	return coreFactory.existsBay(db, bay);
//}
//#endregion level
//
//#region bay
//public
//Bay createBay(){
//	return coreFactory.createBay();
//}
//
//public 
//Bay readBay(string db, string bay){
//    return coreFactory.readBay(db,bay);
//}
//
//public 
//void writeBay(Bay bay){
//    coreFactory.writeBay(bay);
//}
//
//public 
//void updateBay(Bay bay){
//    coreFactory.updateBay(bay);
//}
//
//public 
//void deleteBay(Bay bay){
//    coreFactory.deleteBay(bay);
//}
//
//public 
//string[][] getBayByDesc(string desc,string sdb){
//    return coreFactory.getBayByDesc(desc,sdb);
//}
//#endregion bay
//
//#region StockLocation
//public
//bool existsStkLoc(string db, int company, string plant, string stkLoc){
//    return coreFactory.existsStkLoc(db, company, plant, stkLoc);
//}
//
//public
//bool existsStkLocByPlant(string db, int company, string plant){
//    return coreFactory.existsStkLocByPlant(db, company, plant);
//}
//
//public
//StockLocation createStockLocation(){
//    return coreFactory.createStockLocation();
//}
//
//public
//StockLocation readStockLocation(string db, int company, string plant, string stkLoc){
//    return coreFactory.readStockLocation(db, company, plant, stkLoc);
//}
//
//public
//void writeStockLocation(StockLocation stockLocation){
//    coreFactory.writeStockLocation(stockLocation);
//}
//
//public
//void updateStockLocation(StockLocation stockLocation){
//    coreFactory.updateStockLocation(stockLocation);
//}
//
//public
//void deleteStockLocation(StockLocation stockLocation){
//    coreFactory.deleteStockLocation(stockLocation);
//}
//
//public
//string[][] getStockLocationsFromPlantAsString(string db, int companyCode, string plantCode){
//    return coreFactory.getStockLocationsFromPlantAsString(db,companyCode, plantCode);
//}
//
//public
//string[][] getStkLocByDesc(string desc,string sdb,int icompany,string splant){
//	return coreFactory.getStkLocByDesc(desc,sdb,icompany, splant);
//}
//
//public 
//string[][] getStkLocByPlant(string sdb,int icompany,string splant){
//    return coreFactory.getStkLocByPlant(sdb,icompany,splant);
//}
//
//public
//bool existStkLocByPlant(string sdb,int icompany,string splant){
//    return coreFactory.existsStkLocByPlant(sdb,icompany,splant);
//}
//#endregion StockLocation
//
//#region QOH
//	#region QohBin
//	public 
//	bool existsQohBin(string sdb, int icompany, string splant, string stockLoc, string sbin){
//		return coreFactory.existsQohBin (sdb, icompany, splant, stockLoc, sbin);
//	}
//
//	public 
//	QohBin readQohBin(string sdb, int icompany, string splant, string stockLoc, string sbin){
//		return coreFactory.readQohBin (sdb, icompany, splant, stockLoc, sbin);
//	}
//
//	public 
//	void updateQohBin(QohBin qohBin){
//		coreFactory.updateQohBin (qohBin);
//	}
//
//	public 
//	void writeQohBin(QohBin qohBin){
//		coreFactory.writeQohBin (qohBin);
//	}
//
//	public 
//	void deleteQohBin(QohBin qohBin){
//		coreFactory.deleteQohBin(qohBin);
//	}
//
//	public 
//	QohBin createQohBin(){
//		return coreFactory.createQohBin ();
//	}
//
//
//	#endregion QohBin
//	#region qohSlot
//
//	public bool existQohSlot(string db, int company, string plant, string stkLoc, string bin,string slot){
//		return coreFactory.existQohSlot( db,  company,  plant,  stkLoc,  bin, slot);
//	}
//
//	public
//	QohSlot readQohSlot(string sdb, int icompany, string splant, string stockLoc, 
//						string sbin,string slot,string spart, int isequence){
//		return coreFactory.readQohSlot( sdb,  icompany,  splant,  stockLoc,  sbin, slot,spart,isequence);
//	}
//
//	public
//	QohSlot readQohExistSlot(	string sdb, int icompany, string splant, string stockLoc, 
//								string sbin,string slot){
//		return coreFactory.readQohExistSlot( sdb,  icompany,  splant,  stockLoc,  sbin, slot);
//	}
//	#endregion qohSlot
//
//	#region qohStockLoc
//	public
//	bool existsQohStockLoc(string sdb, int icompany, string splant, string stockLoc){
//		return coreFactory.existsQohStockLoc(sdb,icompany,splant,stockLoc);
//		
//	}
//	public
//	QohStockLoc readQohStockLoc(string sdb, int icompany, string splant, string stockLoc){
//		return coreFactory.readQohStockLoc(sdb,icompany,splant,stockLoc);
//	}
//	public 
//	void updateQohStockLoc(QohStockLoc qohStockLoc){
//		coreFactory.updateQohStockLoc(qohStockLoc);
//	}
//	public 
//	void writeQohStockLoc(QohStockLoc qohStockLoc){
//		coreFactory.writeQohStockLoc(qohStockLoc);
//	}
//
//	public 
//	void deleteQohStockLoc(QohStockLoc qohStockLoc){
//		coreFactory.deleteQohStockLoc(qohStockLoc);
//	}
//
//	public
//	QohStockLoc createQohStockLoc(){
//		return coreFactory.createQohStockLoc();
//	}
//
//
//	public string[][] getQohStkLocAsString(string db,int company, string plant,string stkLoc){
//		return coreFactory.getQohStkLocAsString(db,company, plant,stkLoc);
//	}
//
//	#endregion qohStockLoc
//	#region QohSlot
//	public 
//	string[][] getQohSlotAsString(string db,int company,string plant, string stkLoc,string bin,string slot){
//		return coreFactory.getQohSlotAsString(db,company,plant, stkLoc,bin,slot);
//
//	}
//
//	public
//	decimal getQohFromSlot(string db, int company, string plant, string stkLoc, string bin, string slot, string part, int sequence){
//		return coreFactory.getQohFromSlot(db, company, plant, stkLoc, bin, slot, part, sequence);
//	}
//
//	#endregion QohSlot
//#endregion QOH
//
//#region TransReason
//public
//bool existsTransReason(string db, string transReason){
//	return coreFactory.existsTransReason(db,transReason);
//}
//
//public
//TransReason createTransReason(){
//	return coreFactory.createTransReason();
//}
//
//public
//TransReason readTransReason(string db, string transReason){
//	return coreFactory.readTransReason(db,transReason);
//}
//
//public
//void writeTransReason(TransReason transReason){
//	coreFactory.writeTransReason(transReason);
//}
//
//public
//void updateTransReason(TransReason transReason){
//	coreFactory.updateTransReason(transReason);
//}
//
//public
//void deleteTransReason(TransReason transReason){
//	coreFactory.deleteTransReason(transReason);
//}
//
//public
//string[][] getTransReasonByDesc(string desc){
//	return coreFactory.getTransReasonByDesc(desc);
//}
//
//#endregion TransReason

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

//#region Source
//public
//bool existsSource (string source){
//	return coreFactory.existsSource (source);
//}
//
//public
//Source readSource (string source){
//	return coreFactory.readSource (source);
//}
//
//public
//void updateSource(Source source){
//	coreFactory.updateSource (source);
//}
//
//public
//void writeSource(Source source){
//	coreFactory.writeSource (source);
//}
//
//public
//void deleteSource(Source source){
//	coreFactory.deleteSource(source);
//}
//
//public
//string[][] getSourceByDesc(string desc){
//	return coreFactory.getSourceByDesc (desc);
//}
//
//public
//Source createSource(){
//	return coreFactory.createSource();
//}
//#endregion Source
//
//#region TransType
//public
//bool existsTransType (string stransType){
//	return coreFactory.existsTransType (stransType);
//}
//
//public
//TransType readTransType (string stransType){
//	return coreFactory.readTransType (stransType);
//}
//
//public
//void updateTransType(TransType transType){
//	coreFactory.updateTransType (transType);
//}
//
//public
//void writeTransType(TransType transType){
//	coreFactory.writeTransType (transType);
//}
//
//public
//void deleteTransType(TransType transType){
//	coreFactory.deleteTransType(transType);
//}
//
//public
//string[][] getTransTypeByDesc(string desc){
//	return coreFactory.getTransTypeByDesc (desc);
//}
//
//public
//TransType createTransType(){
//	return coreFactory.createTransType();
//}
//#endregion TransType
//
//#region Unit
//public
//bool existsUnit(string sdb,string suom){
//	return coreFactory.existsUnit(sdb,suom);
//}
//
//public
//Unit readUnit(string sdb,string suom){
//	return coreFactory.readUnit(sdb,suom);
//}
//
//public 
//void updateUnit(Unit unit){
//	coreFactory.updateUnit(unit);
//}
//   
//public 
//void writeUnit(Unit unit){
//	coreFactory.writeUnit(unit);
//}
//
//public 
//void deleteUnit(Unit unit){
//	coreFactory.deleteUnit(unit);
//}
//	
//public
//string[][] getUnitByDesc(string desc, string db){
//	return coreFactory.getUnitByDesc(desc, db);
//}
//
//public
//Unit createUnit(){
//	return coreFactory.createUnit();
//}
//#endregion Unit
//
//// UnitConPart
//public 
//bool existsUnitConPart(int id){
//	return coreFactory.existsUnitConPart (id);
//}
//
//#region UnitConPart
//public 
//UnitConPart readUnitConPart (int id){
//	return coreFactory.readUnitConPart (id);
//}
//
//public 
//void updateUnitConPart(UnitConPart unitConPart){
//	coreFactory.updateUnitConPart (unitConPart);
//}
//
//public
//void writeUnitConPart(UnitConPart unitConPart){
//	coreFactory.writeUnitConPart (unitConPart);
//}
//
//public 
//void deleteUnitConPart(UnitConPart unitConPart){
//	coreFactory.deleteUnitConPart(unitConPart);
//}
//
//public
//string[][] getUnitConPartByDesc(string desc){
//	return coreFactory.getUnitConPartByDesc(desc);
//}
//
//public
//UnitConPart createUnitConPart(){
//	return coreFactory.createUnitConPart();
//}
//#endregion UnitConPart
//
//#region Profile
//
//public 
//bool existsTransProfile(string db, string profileType){
//	return coreFactory.existsTransProfile (db, profileType);
//}
//
//public
//TransProfile createTransProfile(){
//	return coreFactory.createTransProfile();
//}
//
//public
//TransProfile readTransProfile(string db, string profileType){
//	return coreFactory.readTransProfile(db, profileType);
//}
//
//public
//void writeTransProfile(TransProfile transProfile){
//	coreFactory.writeTransProfile(transProfile);
//}
//
//public
//void updateTransProfile(TransProfile transProfile){
//	coreFactory.updateTransProfile(transProfile);
//}
//
//public
//void deleteTransProfile(TransProfile transProfile){
//	coreFactory.deleteTransProfile(transProfile);
//}
//
//public
//string[][] getTransProfileByDesc(string desc, string db){
//	return coreFactory.getTransProfileByDesc(desc, db);
//}
//
//#endregion Profile
//
//#region Container
//
//public
//string[][] getContainersByDescAsString(string desc){
//	return coreFactory.getContainersByDescAsString(desc);
//}
//
//public
//Container createContainer(){
//	return coreFactory.createContainer();
//}
//
//public
//bool existsContainer(string container){
//	return coreFactory.existsContainer(container);
//}
//
//public
//Container readContainer(string containerCode){
//	return coreFactory.readContainer(containerCode);
//}
//
//public 
//void updateContainer(Container container){
//	coreFactory.updateContainer(container);
//}
//
//public 
//void writeContainer(Container container){
//	coreFactory.writeContainer(container);
//}
//
//public 
//void deleteContainer(Container container){
//	coreFactory.deleteContainer(container);
//}
//	
//#endregion Container
//
//#region qohStockLocDtl
//
//public bool existsQohStockLocDtl(string db, int company, string plant, string stockLoc,
//								string part, int sequence){
//    
//    return coreFactory.existsQohStockLocDtl(db, company, plant, stockLoc,part,sequence);
//}
//
//public QohStockLocDtl readQohStockLocDtl(string db, int company, string plant, string stockLoc,
//										 string part, int sequence){
//    return coreFactory.readQohStockLocDtl(db, company, plant, stockLoc,part,sequence);
//}
//
//public void updateQohStockLocDtl(QohStockLocDtl qohStockLocDtl){
//    
//     coreFactory.updateQohStockLocDtl(qohStockLocDtl);
//}
//
//public void writeQohStockLocDtl(QohStockLocDtl qohStockLocDtl){
//
//     coreFactory.writeQohStockLocDtl(qohStockLocDtl);
//}
// 
//public void deleteQohStockLocDtl(QohStockLocDtl qohStockLocDtl){
//    
//     coreFactory.deleteQohStockLocDtl(qohStockLocDtl);
//}
//
//public QohStockLocDtl createQohStockLocDtl(){
//
//    return coreFactory.createQohStockLocDtl();
//}
//
//#endregion qohStockLocDtl
//
//#region UnitCon
//public
//bool existsUnitCon(string sdb,string suom1,string suom2){
//	 return coreFactory.existsUnitCon(sdb,suom1,suom2);
//}
//
//public
//UnitCon readUnitCon(string sdb,string suom1,string suom2){
//    return coreFactory.readUnitCon(sdb,suom1,suom2);
//}
//
//public 
//void updateUnitCon(UnitCon unitCon ){
//   coreFactory.updateUnitCon(unitCon);
//}
//   
//public 
//void writeUnitCon(UnitCon unitCon ){
//   coreFactory.writeUnitCon(unitCon);
//}
//
//public 
//void deleteUnitCon(UnitCon unitCon ){
//	coreFactory.deleteUnitCon(unitCon);
//}
//	
//public
//string[][] getUnitConByDesc(string desc){
//	return coreFactory.getUnitConByDesc(desc);	
//}
//
//public
//UnitCon createUnitCon(){
//	return coreFactory.createUnitCon();
//}
//#endregion UnitCon
//
//#region InventType
//public
//bool existsInventType(string stype){
//	return coreFactory.existsInventType(stype);
//}
//
//public
//InventType readInventType(string stype){
//	return coreFactory.readInventType(stype);
//}
//
//public 
//void updateInventType(InventType inventType){
//	coreFactory.updateInventType(inventType);
//}
//
//public 
//void writeInventType(InventType inventType){
//	coreFactory.writeInventType(inventType);
//}
//
//public 
//void deleteInventType(InventType inventType){
//	coreFactory.deleteInventType(inventType);
//}
//
//public
//string[][] getInventTypeByDesc(string desc){
//	return coreFactory.getInventTypeByDesc(desc);
//}
//
//public
//InventType createInventType(){
//	return coreFactory.createInventType();
//}
//#endregion InventType
//
//#region DemandPrf
//
//public bool existsDemandPrf(string db,string demandPrf){
//
//    return coreFactory.existsDemandPrf(db,demandPrf);
//}
//
//public DemandPrf createDemandPrf(){
//    
//    return coreFactory.createDemandPrf();
//}
//
//public DemandPrf readDemandPrf(string db,string demandPrf){
//    
//    return coreFactory.readDemandPrf(db,demandPrf);
//}
//
//public void writeDemandPrf(DemandPrf demandPrf){
//    
//    coreFactory.writeDemandPrf(demandPrf);
//}
//
//public void updateDemandPrf(DemandPrf demandPrf){
//
//    coreFactory.updateDemandPrf(demandPrf);
//}
//
//public void deleteDemandPrf(DemandPrf demandPrf){
//
//    coreFactory.deleteDemandPrf(demandPrf);
//}
//
//public string[][] getDemandPrfByDesc(string searchText){
//    
//    return coreFactory.getDemandPrfByDesc(searchText);
//}
//
//#endregion DemandPrf
//
//#region ItemType
//public
//bool existsItemType(string stype){
//	return coreFactory.existsItemType(stype);
//}
//
//public
//ItemType readItemType(string stype){
//	return coreFactory.readItemType(stype);
//}
//
//public 
//void updateItemType(ItemType itemType){
//	coreFactory.updateItemType(itemType);
//}
//
//public 
//void writeItemType(ItemType itemType){
//	coreFactory.writeItemType(itemType);
//}
//
//public 
//void deleteItemType(ItemType itemType){
//	coreFactory.deleteItemType(itemType);
//}
//	
//public
//string[][] getItemTypeByDesc(string desc){
//	
//	return coreFactory.getItemTypeByDesc(desc);
//}
//
//public
//ItemType createItemType(){
//	return new ItemType();
//}
//#endregion ItemType
//
//#region ScanType
//public
//bool existsScanType(string stype){
//	return coreFactory.existsScanType(stype);
//}
//
//public
//ScanType readScanType(string stype){
//	return coreFactory.readScanType(stype);
//}
//
//public 
//void updateScanType(ScanType scanType){
//	coreFactory.updateScanType(scanType);
//}
//
//public 
//void writeScanType(ScanType scanType){
//	coreFactory.writeScanType(scanType);
//}
//
//public 
//void deleteScanType(ScanType scanType){
//	coreFactory.deleteScanType(scanType);
//}
//	
//public
//string[][] getScanTypeByDesc(string desc){
//	
//	return coreFactory.getScanTypeByDesc(desc);
//}
//
//public
//ScanType createScanType(){
//	return new ScanType();
//}
//#endregion ScanType
//
//#region ItemInfo
//
//public	
//bool existsItemInfo (string db, string part){
//	return coreFactory.existsItemInfo (db, part);
//}
//
//public 
//ItemInfo readItemInfo (string db, string part){
//	return coreFactory.readItemInfo (db, part);
//}
//
//public
//ItemInfo readItemInfoWithSequences (string db, string part){
//	return coreFactory.readItemInfoWithSequences(db, part);
//}
//
//public 
//void updateItemInfo(ItemInfo itemInfo){
//	coreFactory.updateItemInfo (itemInfo);
//}
//
//public 
//void writeItemInfo(ItemInfo itemInfo){
//	coreFactory.writeItemInfo (itemInfo);
//}
//
//public 
//bool deleteItemInfo(ItemInfo itemInfo){
//	return coreFactory.deleteItemInfo(itemInfo);
//}
//
//public
//void deleteItemInfoCascade (ItemInfo itemInfo){
//	coreFactory.deleteItemInfoCascade (itemInfo);
//}
//
//public
//string[][] getItemInfoByDesc(string desc, string db){
//	return coreFactory.getItemInfoByDesc(desc, db);
//}
//
//public 
//bool itemInfoHasSeqs (ItemInfo itemInfo){
//	return coreFactory.itemInfoHasSeqs(itemInfo);
//}
//
//public
//bool itemInfoHasPlts (ItemInfo itemInfo){
//	return coreFactory.itemInfoHasPlts (itemInfo);
//}
//
//public 
//ItemInfo createItemInfo(){
//	return coreFactory.createItemInfo();
//}
//
//public
//string[][] getItemInfoByPart(string desc, string db){
//    return coreFactory.getItemInfoByPart(desc,db);
//}
//
//public
//ItemInfo getItemInfoByUPC(string upc, string db){	
//    return coreFactory.getItemInfoByUPC(upc,db);
//}
//
//
//public	
//bool existsItemInfoPlt (string db, string part, string plant)
//{
//	return coreFactory.existsItemInfoPlt (db, part,plant);
//}
//
//public 
//ItemInfoPlt readItemInfoPlt (string db, string part,string plant)
//{
//	return coreFactory.readItemInfoPlt (db, part,plant);
//}
//
//public
//ItemInfoPlt readItemInfoPltWithSequences (string db, string part, string plant){
//	return coreFactory.readItemInfoPltWithSequences (db, part, plant);
//}
//
//public 
//void updateItemInfoPlt(ItemInfoPlt itemInfoPlt){
//	coreFactory.updateItemInfoPlt (itemInfoPlt);
//}
//
//public 
//void writeItemInfoPlt(ItemInfoPlt itemInfoPlt)
//{
//	coreFactory.writeItemInfoPlt (itemInfoPlt);
//}
//
//public 
//void deleteItemInfoPlt(ItemInfoPlt itemInfoPlt)
//{
//	coreFactory.deleteItemInfoPlt(itemInfoPlt);
//}
//
//public
//bool itemInfoPltHasSeqs (ItemInfoPlt itemInfoPlt){
//	return coreFactory.itemInfoPltHasSeqs (itemInfoPlt);
//}
//
//public
//ItemInfoPlt getItemInfoPltFromItemInfo (ItemInfo itemInfo){
//	return coreFactory.getItemInfoPltFromItemInfo (itemInfo);
//}
//
//public 
//ItemInfoPlt createItemInfoPlt()
//{
//	return coreFactory.createItemInfoPlt();
//}
//
//public
//string[][] readItemInfoSeqFromItem (string db, string part)
//{
//	return coreFactory.readItemInfoSeqFromItem (db, part);
//}
//
//public 
//bool itemInfoSeqHasPlts (string db, string part, int seq){
//	return coreFactory.itemInfoSeqHasPlts (db, part, seq);
//}
//
//public
//ItemInfoSeq createItemInfoSeq(){
//	return coreFactory.createItemInfoSeq();
//}
//
//public
//string[][] readItemInfoSeqPltFromItemPlt (string db, string part, string plt)
//{
//	return coreFactory.readItemInfoSeqPltFromItemPlt (db, part, plt);
//}
//
//public
//ItemInfoSeqPlt getItemInfoSeqPltFromItemInfoSeq (ItemInfoSeq itemInfoSeq){
//	return coreFactory.getItemInfoSeqPltFromItemInfoSeq (itemInfoSeq);
//}
//
//public
//ItemInfoSeqPlt createItemInfoSeqPlt(){
//	return coreFactory.createItemInfoSeqPlt();
//}
//
//public 
//bool itemInfoHasBusPartParts (ItemInfo itemInfo){
//    return coreFactory.itemInfoHasBusPartParts(itemInfo);
//}
//#endregion ItemInfo
//
//#region ProdType
//public
//bool existsProdType(string sdb,string stype){
//	return coreFactory.existsProdType(sdb,stype);
//}
//
//public
//ProdType readProdType(string sdb,string stype){
//	return coreFactory.readProdType(sdb,stype);
//}
//
//public 
//void updateProdType(ProdType prodType){
//	coreFactory.updateProdType(prodType);
//}
//
//public 
//void writeProdType(ProdType prodType){
//	coreFactory.writeProdType(prodType);
//}
//
//public 
//void deleteProdType(ProdType prodType){
//	coreFactory.deleteProdType(prodType);
//}
//	
//public
//string[][] getProdTypeByDesc(string desc, string db){
//	
//	return coreFactory.getProdTypeByDesc(desc, db);
//}
//
//public
//ProdType createProdType(){
//	return new ProdType();
//}
//#endregion ProdType
//
//#region ProcurePref
//public	
//bool existsProcurePref (string procurePrefId)
//{
//	return coreFactory.existsProcurePref (procurePrefId);
//}
//
//public 
//ProcurePref readProcurePref (string procurePrefId)
//{
//	return coreFactory.readProcurePref (procurePrefId);
//}
//
//public 
//void updateProcurePref(ProcurePref procurePref)
//{
//	coreFactory.updateProcurePref (procurePref);
//}
//
//public 
//void writeProcurePref(ProcurePref procurePref)
//{
//	coreFactory.writeProcurePref (procurePref);
//}
//
//public 
//void deleteProcurePref(ProcurePref procurePref)
//{
//	coreFactory.deleteProcurePref(procurePref);
//}
//
//public 
//ProcurePref createProcurePref()
//{
//	return coreFactory.createProcurePref();
//}
//
//public
//string[][] getProcurePrefByDesc(string desc){
//	return coreFactory.getProcurePrefByDesc(desc);
//}
//
//public
//ProcurePref[] readAllProcurePref(){
//	return coreFactory.readAllProcurePref();
//}
//
//#endregion ProcurePref
//
//#region SalesCode
//
//public SalesCode createSalesCode(){
//    return coreFactory.createSalesCode();
//}
//
//public SalesCode readSalesCode(int id){
//    return coreFactory.readSalesCode(id);
//}
//
//public
//SalesCode readSalesCodeByCodes (string sales1, string sales2, string sales3, string sales4, string sales5, string sales6){
//	return coreFactory.readSalesCodeByCodes (sales1, sales2, sales3, sales4, sales5, sales6);
//}
//
//public void updateSaleCode(SalesCode salesCode){
//    coreFactory.updateSaleCode(salesCode);
//}
// 
//public void writeSalesCode(SalesCode salesCode){
//    coreFactory.writeSalesCode(salesCode);
//}
//
//public void deleteSalesCode(SalesCode salesCode){
//    coreFactory.deleteSalesCode(salesCode);
//}
//
//public string[][] getSalesCodeBySearch(string searchText, string db){
//    return coreFactory.getSalesCodeBySearch(searchText, db);
//}
//
//public bool existsSalesCode(SalesCode salesCode){
//
//    return coreFactory.existsSalesCode(salesCode);
//}
//
//#endregion SalesCode
//
//#region Defaults
//
//public
//Defaults createDefaults(){
//    return coreFactory.createDefaults();
//}
//
//public
//bool existsDefaults(string db, int company){
//    return coreFactory.existsDefaults(db, company);
//}
//
//public
//Defaults readDefaults(string db, int company){
//    return coreFactory.readDefaults(db, company);
//}
//
//public 
//void updateDefaults(Defaults defaults){
//    coreFactory.updateDefaults(defaults);
//}
//
//public 
//void writeDefaults(Defaults defaults){
//    coreFactory.writeDefaults(defaults);
//}
//
//public 
//void deleteDefaults(Defaults defaults){
//    coreFactory.deleteDefaults(defaults);
//}
//
//public
//string[][] getDefaultsByDesc(string desc){
//	return coreFactory.getDefaultsByDesc(desc);
//}
//#endregion Defaults
//
//#region InactiveReason
//
//public
//InactiveReason createInactiveReason(){
//    return coreFactory.createInactiveReason();
//}
//
//public
//bool existsInactiveReason(string db, string inactiveReason){
//    return coreFactory.existsInactiveReason(db, inactiveReason);
//}
//
//public
//InactiveReason readInactiveReason(string db, string inactiveReason){
//    return coreFactory.readInactiveReason(db, inactiveReason);
//}
//
//public
//void writeInactiveReason(InactiveReason inactiveReason){
//    coreFactory.writeInactiveReason(inactiveReason);
//}
//
//public
//void updateInactiveReason(InactiveReason inactiveReason){
//    coreFactory.updateInactiveReason(inactiveReason);
//}
//
//public
//void deleteInactiveReason(InactiveReason inactiveReason){
//    coreFactory.deleteInactiveReason(inactiveReason);
//}
//
//public
//string[][] getInactiveReasonByDesc(string desc, string db){
//    return coreFactory.getInactiveReasonByDesc(desc, db);
//}
//
//#endregion InactiveReason
//
//#region Transaction
//public
//Transaction createTransaction(){
//    return coreFactory.createTransaction();
//}
//
//public 
//void writeTransaction(Transaction transaction){
//    coreFactory.writeTransaction(transaction);
//}
//
//#endregion Transaction
//
//#region Mfg
//public
//bool existsMfg(string sdb,string smfg){
//	return coreFactory.existsMfg(sdb,smfg);	
//}
//
//public
//Mfg readMfg(string sdb,string smfg){
//    return coreFactory.readMfg(sdb,smfg);		
//}
//
//public 
//void updateMfg(Mfg mfg){
//   coreFactory.updateMfg(mfg);	
//}
//   
//public 
//void writeMfg(Mfg mfg){
//   coreFactory.writeMfg(mfg);	
//}
//
//public 
//void deleteMfg(Mfg mfg){
//   coreFactory.deleteMfg(mfg);	
//}
//	
//public
//string[][] getMfgByDesc(string desc,string sdb){
//	return coreFactory.getMfgByDesc(desc,sdb);		
//}
//
//public
//Mfg createMfg(){
//	return coreFactory.createMfg();
//}
//#endregion Mfg
//
//#region mfgModel
//
//public
//bool existsMfgModel(string db,string mfg,string mfgModel){
//    return coreFactory.existsMfgModel(db,mfg,mfgModel);
//}
//
//public
//MfgModel readMfgModel(string db,string mfg, string mfgModel){
//    return coreFactory.readMfgModel(db,mfg,mfgModel); 
//}
//
//public 
//void updateMfgModel(MfgModel mfgModel){
//     coreFactory.updateMfgModel(mfgModel);  
//}
//   
//public 
//void writeMfgModel(MfgModel mfgModel){
//     coreFactory.writeMfgModel(mfgModel); 
//}
//
//public 
//void deleteMfgModel(MfgModel mfgModel){
//     coreFactory.deleteMfgModel(mfgModel);
//}
//
//public MfgModel createMfgModel(){
//    return coreFactory.createMfgModel();
//}
//
//public string[][] getMfgModelByDesc(string searchText,string sdb){
//    return coreFactory.getMfgModelByDesc(searchText,sdb);
//}
//	
//public bool existsMfgModelByMfg(string db, string mfg){
//    return coreFactory.existsMfgModelByMfg(db,mfg);
//}
//
//public
//string[][] getMfgModelByCode(string mfg,string sdb){
//
//    return coreFactory.getMfgModelByCode(mfg,sdb);
//}
//#endregion mfgModel
//
//#region LabFormat
//	#region LabFile
//	
//	public
//	LabFile createLabFile(){
//		return coreFactory.createLabFile();
//	}
//
//	#endregion
//
//	#region LabVariables
//	
//	public
//	LabVariables createLabVariables(){
//		return coreFactory.createLabVariables();
//	}	
//	#endregion
//
//public
//bool existsLabFormat(string sdb,string slabel){
//	return coreFactory.existsLabFormat(sdb,slabel);
//}
//
//public
//LabFormat readLabFormat(string sdb,string slabel){
//   	return coreFactory.readLabFormat(sdb,slabel);
//}
//
//public 
//void updateLabFormat(LabFormat labFormat){
//   coreFactory.updateLabFormat(labFormat);
//}
//   
//public 
//void writeLabFormat(LabFormat labFormat){
//   coreFactory.writeLabFormat(labFormat);
//}
//
//public 
//void deleteLabFormat(LabFormat labFormat){
//   coreFactory.deleteLabFormat(labFormat);
//}
//	
//public
//string[][] getLabFormatByDesc(string desc,string sdb){
//	return 	coreFactory.getLabFormatByDesc( desc,sdb);
//}
//
//public
//LabFormat createLabFormat(){
//	return coreFactory.createLabFormat();
//}
//#endregion LabFormat
//
//#region Colors
//
//public
//bool existsColors(string code){
//    return coreFactory.existsColors(code);
//}
//
//public
//Colors readColors(string code){
//    return coreFactory.readColors(code);
//}
//
//public 
//void updateColors(Colors colors){
//    coreFactory.updateColors(colors);
//}
//
//public 
//void writeColors(Colors colors){
//    coreFactory.writeColors(colors);
//}
//
//public 
//void deleteColors(Colors colors){
//    coreFactory.deleteColors(colors);
//}
//
//
//public
//Colors createColors(){
//    return coreFactory.createColors();
//}
//
//public
//string[][] getColorsByDesc(string desc){
//    return coreFactory.getColorsByDesc(desc);
//}
//#endregion Colors
//
//#region IvLotMaster
//
//public
//bool existsLotMaster (string dB, string part, int sequence, string fromLot){
//	return coreFactory.existsLotMaster (dB, part, sequence, fromLot);
//}
//
//public
//LotMaster readLotMaster (string dB, string part, int sequence, string fromLot){
//	return coreFactory.readLotMaster (dB, part, sequence, fromLot);
//}
//
//public
//void updateLotMaster(LotMaster lotMaster){
//	coreFactory.updateLotMaster(lotMaster);
//}
//
//public
//void writeLotMaster (LotMaster lotMaster){
//	coreFactory.writeLotMaster (lotMaster);
//}
//
//public
//void deleteLotMaster (string dB, string part, int sequence, string fromLot){
//	coreFactory.deleteLotMaster (dB, part, sequence, fromLot);
//}
//
//public
//LotMaster createLotMaster(){
//	return coreFactory.createLotMaster();
//}
//#endregion

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

//#region BusPartParts
//
//public
//bool existsBusPartParts (string db, string prodID, int seq, string busPartnerBT,string busPartParts,
//                         string busPartnerST,string revision){
//	return coreFactory.existsBusPartParts (db, prodID, seq, busPartnerBT,busPartParts,busPartnerST,revision);
//}
//
//public
//BusPartParts readBusPartParts (string db, string prodID, int seq, string busPartnerBT,string busPartParts,
//                               string busPartnerST,string revision){
//	return coreFactory.readBusPartParts (db, prodID, seq, busPartnerBT,busPartParts,busPartnerST,revision);
//}
//
//public
//void updateBusPartParts(BusPartParts busPartParts){
//	coreFactory.updateBusPartParts(busPartParts);
//}
//
//public
//void writeBusPartParts (BusPartParts busPartParts){
//	coreFactory.writeBusPartParts (busPartParts);
//}
//
//public
//void deleteBusPartParts (string db, string prodID, int seq, string busPartnerBT,string busPartParts,
//                         string busPartnerST,string revision){
//	coreFactory.deleteBusPartParts (db, prodID, seq, busPartnerBT,busPartParts,busPartnerST,revision);
//}
//
//public 
//string[][] getBusPartPatsByDesc(string searchText, string db){
//
//    return coreFactory.getBusPartPatsByDesc(searchText, db);
//}
//
//public 
//string[][] getBusPartPartsByPart(string db,string part){
//    return coreFactory.getBusPartPartsByPart(db,part);
//}
//
//public
//BusPartParts readBusPartPartsById (int id){
//    return coreFactory.readBusPartPartsById(id);
//}
//
//public 
//BusPartParts getBusPartPatsByUPC(string upc, string db){
//	return coreFactory.getBusPartPatsByUPC(upc,db);
//}
//
//public BusPartParts[] readBusPartPartsByFilters(string db, string part, int seq, string busPartnerBT,
//												string busPartPart,string busPartnerST,string revision)
//{
//	return coreFactory.readBusPartPartsByFilters(	db,  part,  seq,  busPartnerBT,
//													busPartPart,busPartnerST,revision);
//}

//#endregion

#region GLCurrency

public
bool existsGLCurrency (string db, string currency){
	return coreFactory.existsGLCurrency (db, currency);
}

public
GLCurrency readGLCurrency (string db, string currency){
	return coreFactory.readGLCurrency (db, currency);
}

public
void updateGLCurrency(GLCurrency gLCurrency){
	coreFactory.updateGLCurrency(gLCurrency);
}

public
void writeGLCurrency (GLCurrency gLCurrency){
	coreFactory.writeGLCurrency (gLCurrency);
}

public
void deleteGLCurrency (string db, string currency){
	coreFactory.deleteGLCurrency (db, currency);
}

public 
string[][] getCurrencyByDesc(string text, string db){
    return coreFactory.getCurrencyByDesc(text,db);
}

public
bool existsGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase){
	return coreFactory.existsGLCurrencyDlyExc (db, company, startingDate, endingDate, currencyBase);
}

public
GLCurrencyDlyExc readGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase){
	return coreFactory.readGLCurrencyDlyExc (db, company, startingDate, endingDate, currencyBase);
}

public
void updateGLCurrencyDlyExc(GLCurrencyDlyExc gLCurrencyDlyExc){
	coreFactory.updateGLCurrencyDlyExc(gLCurrencyDlyExc);
}

public
void writeGLCurrencyDlyExc (GLCurrencyDlyExc gLCurrencyDlyExc){
	coreFactory.writeGLCurrencyDlyExc (gLCurrencyDlyExc);
}

public
void deleteGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase){
	coreFactory.deleteGLCurrencyDlyExc (db, company, startingDate, endingDate, currencyBase);
}

public 
string[][] getCurrencyDlyExcByDesc(string text, string db){
    return coreFactory.getCurrencyDlyExcByDesc(text,db);
}

#endregion

//#region IvSerial
//
//public
//bool existsSerial (string dB, int serialNum){
//	return coreFactory.existsSerial (dB, serialNum);
//}
//
//public
//Serial readSerial (string dB, int serialNum){
//	return coreFactory.readSerial (dB, serialNum);
//}
//
//public
//void updateSerial(Serial ivSerial){
//	coreFactory.updateSerial(ivSerial);
//}
//
//public
//void writeSerial (Serial ivSerial){
//	coreFactory.writeSerial (ivSerial);
//}
//
//public
//void deleteSerial (string dB, int serialNum){
//	coreFactory.deleteSerial (dB, serialNum);
//}
//
//public
//Serial createSerial(){
//	return coreFactory.createSerial();
//}
//
//public
//Serial readSerialByCustomSerial (string dB, string serialNum){
//	return coreFactory.readSerialByCustomSerial (dB, serialNum);
//}
//
//#endregion
//
//#region TransSerial
//
//public
//bool existsTransSerial (string dB, int serialTransNum){
//	return coreFactory.existsTransSerial (dB, serialTransNum);
//}
//
//public
//TransSerial readTransSerial (string dB, int serialTransNum){
//	return coreFactory.readTransSerial (dB, serialTransNum);
//}
//
//public
//void updateTransSerial(TransSerial transSerial){
//	coreFactory.updateTransSerial(transSerial);
//}
//
//public
//void writeTransSerial (TransSerial transSerial){
//	coreFactory.writeTransSerial (transSerial);
//}
//
//public
//void deleteTransSerial (string dB, int serialTransNum){
//	coreFactory.deleteTransSerial (dB, serialTransNum);
//}
//
//public
//TransSerial createTransSerial()
//{
//	return coreFactory.createTransSerial();
//}
//
//#endregion

#region Invoice

public
bool existsInvoice(string db,int company,string plant,int invoiceNum){
    return coreFactory.existsInvoice(db,company,plant,invoiceNum);
}


public
Invoice readInvoice (string db, int company, string plant, int invoiceNum){
	
	return coreFactory.readInvoice(db, company, plant, invoiceNum);
}

public
void updateInvoice(Invoice invoice){
	coreFactory.updateInvoice(invoice);
}

public
void writeInvoice (Invoice invoice){
	coreFactory.writeInvoice(invoice);
}

public
void deleteInvoice(string db, int company, string plant, int invoiceNum){
	coreFactory.deleteInvoice(db, company, plant, invoiceNum);
}

public
string[][] getInvoiceByNum(){
    return coreFactory.getInvoiceByNum();
}

#endregion Invoice

#region PackSlip

public
bool existsPackSlip(string db, int company, string plant, int packSlipNum){
	return coreFactory.existsPackSlip(db, company, plant, packSlipNum);
}

public
PackSlip readPackSlip(string db, int company, string plant, int packSlipNum){
	return coreFactory.readPackSlip (db, company, plant, packSlipNum);
}

public
void updatePackSlip(PackSlip PackSlip){
	coreFactory.updatePackSlip(PackSlip);
}

public
void writePackSlip(PackSlip PackSlip){
	coreFactory.writePackSlip (PackSlip);
}

public
void deletePackSlip (string db, int company, string plant, int packSlipNum){
	coreFactory.deletePackSlip (db, company, plant, packSlipNum);
}

#endregion


public
MaterialBomContainer generateMaterialListRecursive(string prodId, int seq){
	return coreFactory.generateMaterialListRecursive(prodId, seq);
}

//#region SuppSerial
//
//public
//bool existsSuppSerial (string dB, string supplier, string suppSerial){
//	return coreFactory.existsSuppSerial (dB, supplier, suppSerial);
//}
//
//public
//SuppSerial readSuppSerial (string dB, string supplier, string suppSerial){
//	return coreFactory.readSuppSerial (dB, supplier, suppSerial);
//}
//
//public
//void updateSuppSerial(SuppSerial suppSerial){
//	coreFactory.updateSuppSerial(suppSerial);
//}
//
//public
//void writeSuppSerial (SuppSerial suppSerial){
//	coreFactory.writeSuppSerial (suppSerial);
//}
//
//public
//void deleteSuppSerial (string dB, string supplier, string suppSerial){
//	coreFactory.deleteSuppSerial (dB, supplier, suppSerial);
//}
//
//public
//SuppSerial createSuppSerial(){
//	return coreFactory.createSuppSerial();
//}
//#endregion

#region Contact

public
Contact createContact(){
	 return coreFactory.createContact();
}

public
bool existsContact(int id){
	 return coreFactory.existsContact(id);
}

public
Contact readContact(int id){
	 return coreFactory.readContact(id);
}

public 
void updateContact(Contact contact){
	 coreFactory.updateContact(contact);
}

public 
void writeContact(Contact contact){
	 coreFactory.writeContact(contact);
}

public 
void deleteContact(Contact contact){
	 coreFactory.deleteContact(contact);
}

public 
string[][] getContactsByDesc(string searchText){
	 return coreFactory.getContactsByDesc(searchText);
}

public 
bool canDeleteContact(Contact contact){
	 return coreFactory.canDeleteContact(contact);
}

#endregion Contact

//#region Upc
//
//public
//bool existsUpc (string db, string part, int sequence, string container, string uPC){
//	return coreFactory.existsUpc (db, part, sequence, container, uPC);
//}
//
//public
//Upc readUpc (string db, string part, int sequence, string container, string uPC){
//	return coreFactory.readUpc (db, part, sequence, container, uPC);
//}
//
//public
//void updateUpc(Upc ivUPC){
//	coreFactory.updateUpc(ivUPC);
//}
//
//public
//void writeUpc (Upc ivUPC){
//	coreFactory.writeUpc (ivUPC);
//}
//
//public
//void deleteUpc (string db, string part, int sequence, string container, string uPC){
//	coreFactory.deleteUpc (db, part, sequence, container, uPC);
//}
//
//public
//string[][] getUpcByDesc(string desc,string sdb,string spart,int isequence,string scontainer,string supc,
//						string sbusPartnerBT,string sbusPartnerST,string sbusPartPart,string srevision){
//	return coreFactory.getUpcByDesc(desc, sdb, spart, isequence, scontainer,supc,
//									sbusPartnerBT, sbusPartnerST, sbusPartPart, srevision);
//}
//
//public Upc[] readUpcByUpc(string sdb,string supc)
//{
//	return coreFactory.readUpcByUpc( sdb,supc);
//}
//#endregion
//
//#region LabCompDef
//
//public
//bool existsLabCompDef (string db){
//	return coreFactory.existsLabCompDef (db);
//}
//
//public
//LabCompDef readLabCompDef (string db){
//	return coreFactory.readLabCompDef (db);
//}
//
//public
//void updateLabCompDef(LabCompDef labCompDef){
//	coreFactory.updateLabCompDef(labCompDef);
//}
//
//public
//void writeLabCompDef (LabCompDef labCompDef){
//	coreFactory.writeLabCompDef (labCompDef);
//}
//
//public
//void deleteLabCompDef (string db){
//	coreFactory.deleteLabCompDef (db);
//}
//
//public
//LabCompDef createLabCompDef(){
//	return coreFactory.createLabCompDef();
//}
//
//public
//string[][] readByLabCompDefDesc(string desc){
//	return coreFactory.readByLabCompDefDesc(desc);
//}
//
//#endregion
//
//#region SerialMSMX
//
//public
//bool existsSerialMSMX (string dB, int company, string plant, int msMxContainerSerial, int lowerLevelSerial){
//	return coreFactory.existsSerialMSMX (dB, company, plant, msMxContainerSerial, lowerLevelSerial);
//}
//
//public
//SerialMSMX readSerialMSMX (string dB, int company, string plant, int msMxContainerSerial, int lowerLevelSerial){
//	return coreFactory.readSerialMSMX (dB, company, plant, msMxContainerSerial, lowerLevelSerial);
//}
//
//public
//void updateSerialMSMX(SerialMSMX serialMSMX){
//	coreFactory.updateSerialMSMX(serialMSMX);
//}
//
//public
//void writeSerialMSMX (SerialMSMX serialMSMX){
//	coreFactory.writeSerialMSMX (serialMSMX);
//}
//
//public
//void deleteSerialMSMX (string dB, int company, string plant, int msMxContainerSerial, int lowerLevelSerial){
//	coreFactory.deleteSerialMSMX (dB, company, plant, msMxContainerSerial, lowerLevelSerial);
//}
//
//public
//SerialMSMX createSerialMSMX(){
//	return coreFactory.createSerialMSMX();
//}
//#endregion

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

#endregion SchLogCoreFactory


} // class
} // namespace

