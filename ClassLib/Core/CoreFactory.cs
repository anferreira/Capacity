using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Core.ExcelReports;
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


namespace Nujit.NujitERP.ClassLib.Core{

/// <summary>
/// Interface used for hidden implementations details, like location, mode etc
/// Is implemented for LocalCoreFactory and RemoteCoreFactory, when one client create an instance 
/// of one of this classes, they don't know what is really using.
/// </summary>
public
interface CoreFactory{
	
void beginTransaction();

void commitTransaction();

void rollbackTransaction();

// methods are specified here
BomContainer createBomContainer();
BomObjectivesView createBomObjectivesView(Bom bom);
string[][] getProdBOMChild(string prodId, int seqId);

string[][] getParentMaterials(string matId, int seqId);

int QtyInSubmaterialsOf(string matSrch, int matSrchSeq, string matId, int matSeq);

string[][] getSubMaterials(string matId, int seqId);
BomSumContainer getSubMaterialsMainLevel(string matId, int seqId,string splant);
BomSumContainer getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(string spart, int iseq,string splant, string sreportingPoint,int iminorSeqRows);

BomSum createBomSum();
BomSumContainer createBomSumContainer();

bool existsBomSum(string prodID, int seq, string matID, int matSeq);

bool existsBomSumObj(BomSum bomSumObj) ;

BomSum readBomSum(string prodID, int seq, string matID, int matSeq);

void writeBomSum(BomSum bomSum);

void updateBomSum(BomSum bomSum);

void deleteBomSum(BomSum bomSum);

BomSumTempContainer readBomSumTreeProdSeq(string prodId, int prodSeq);

BomSumTempContainer readBomSumTree(BomSumTempContainer bomSumTempContainer, string prodId, int prodSeq);

void updateBomSumTempContainer(BomSumTempContainer bomSumTempContainer);

BomContainer makeBoms(string splant);

Bom makeBom(string prodId, int seqId, string splant);

void loadInfoForBom();

void discardInfoForBom();

Bom makeBomFromProdIDAndSeq (string prodId, int seqId,string splant);

void seeBom(Bom bom, string parent);

string[][] getAllPurchasedMaterials(string prodId, int seqId,string splant);

ArrayList getAllPurchasedMaterialsFromBom(Bom bom, ArrayList lst);

string[][] getErrorsBom();

int cms400ToCmsTempItems(string splant);

int cmsTempToNujitItems(string splant);

int generateCMSItems(string splant,bool bstoreTemp);

string[] generateCMSDeptsRecords();

int cms400ToCmsTempDepts();

string[] cmsTempToNujitDepts();

int cms400ToCmsTempPlnt();

int cmsTempToNujitPlt();

int generateCMSPlt();

int generateCMSMachineRecords();

int cms400ToCmsTempMachines();

int cmsTempToNujitMachines();

int generateCMSStkr();

int cms400ToCmsTempStkr();

int cmsTempToNujitStkr();

void generateSchPrOrdMat();

void generateMaterialRecords();

void restoreInvalidsSeqs();

int CMSFamilyCopy();

int cms400ToCmsTempFamily();

int cmsTempToNujitFamily();

void generateCMSCust();

int cms400ToCmsTempCust();

int generateCMSVend();

int cms400ToCmsTempVend();

int cmsTempToNujitCustVend();

int generateCustVend();

int generateCMSJitToDelJit();

int cms400ToCmsTempJith();

void generateCMSJitd();

int cms400ToCmsTempJitd();

int generateRRLToDelFor();

void generateCMSRrlh();

int cms400ToCmsTempRrlh();

void generateCMSRrld();

int cms400ToCmsTempRrld();

int cmsTempToNujitDelJit();

int cmsTempToNujitDelFor();

int generateCMSPrhist();

int cms400ToCmsTempPrhist();

int generateCMSTrlp();

int cms400ToCmsTempTrlp();

int generateCMSTrpl();

int cms400ToCmsTempTrpl();

int generateCMSTrpt();

int cms400ToCmsTempTrpt();

int generateCmsCustPart();

int cms400ToCmsTempCspt();

int cmsTempToNujitCustPart();

int cmsTempToNujitTPPartCrossRef();

int cms400ToCmsTempBols();

int cms400ToCmsTempRaca();

int generateCMSEmployee();

int cms400ToCmsTempEmployee();

int cmsTempToNujitEmployee();

int cmsCmsNujitEmployeeAssignShift();

string[] getDepartamentCodes();

string[] getDepartamentCodesByPlt(string plt);

string[] getAllDeptFromHotListAsString();

string getDepartamentDescription(string dept);

string getPlantCodeByDept(string departamentCode);

string[][] getDepartmentByDesc(string desc, string db, int company, string plt);

void createHotList(string[] stkbFilter, string[] wipbFilter, string[][] badWipb,int demandHdrId,string splant);
void createHotListDemand(DemandH demandH,bool bcreateCapacity);

string[][] getHotListAsString(int id,string splantHotList,string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type);

string[][] getDemandAsString(string[] filterPart,string splant);

string[][] getHotListAsStringNew(int id,string splantHotList,string splant,string sdept,string machine, int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,string sprodFamily,int idaysWithQty, bool borderByDemand,bool bgetCumulativeQty,bool bqohAffects,bool baddReceipParts,bool baddMaterialConsumPart,int rows);
HotListContainer getHotListAsStringNew2(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string smajorGroup,string sglExp,string sreportedPoint, string sprodFamily,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows);
HotListContainer getHotListInvAnalysis(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string smajorGroup,string sglExp,string sreportedPoint,int daysWithQty,bool borderByDemand,bool bgetCumulativeQty,bool bqohAffects, bool baddReceipParts,bool baddMaterialConsumPart,int rows);
        
string[][] getActiveDemandAsStringByDate(DateTime dateFrom, DateTime dateTo);

string[][] getDemandAsStringByDate(DateTime dateFrom, DateTime dateTo);

string[][] getHotListAsStringByDemand(bool onlyDemand);

string[][] getAllMatReqAsString(string[] depts, string[]parts ,string splant);

void generateReleases(string startSupplier, string endSupplier,
		string startPart, string endPart);

string[][] getReleasesAsString(string startSupplier, string endSupplier,
		string startPart, string endPart);

string[][] getVendorReleaseInquiry(bool weeks);

string[] getAllPartFromHotListAsString(int id, bool inactive);

string[] getAllMGFromHotListAsString(int id);

string[] getHotListLogData();

string[][] getHotListLogHist();

string[][] getHotListReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, 
			string type, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint,
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp);

string[][] getHotListReportByPart(int id, string byPart);

string[][] getMaterialDueDate(bool weeks, string[] depts, string[] parts, bool orderByVendor, string[] stkLocs,string splant);

void blockHotList();

bool isHotListBlocked();

void unBlockHotList();


HotListHdr createHotListHdr();
HotListHdrContainer createHotListHdrContainer();
HotListHdr readHotListHdr(int id);
HotListHdrContainer readLastHotListHdrDifferentsPlants();
HotListHdr readLastHotList(string splant);
HotListHdr readPriorLastHotList(string splant);

HotList createHotList();
HotListContainer createHotListContainer();
HotListDay createHotListDay();
HotListInvAnalysisView createHotListInvAnalysisView();
HotListInvAnalysisView cloneHotListInvAnalysisView(HotListInvAnalysisView hotListInvAnalysisView);

HotListContainer readHotListByFilters(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sreportedPoint,string sprodFamily,bool borderByDemand, bool bgetCumulativeQty,int rows);
HotListContainer readHotListByFiltersWeekly(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string smajorGroup,string sglExp,string sreportedPoint, int idaysWithQoh,bool borderByDemand,bool bgetCumulativeQty,int rows);
HotListContainer readHotListByFiltersWeekly2(ArrayList arrayFieldList,int id, string splantHotList, string splant, string sdept, string smachine, int imachineId, string spart, int iseq, string smajorGroup,string sglExp,string sreportedPoint,int idaysWithQty,bool borderByDemand, bool bgetCumulativeQty,bool bqohAffects, int rows); 

HotListHourContainer getHotListHoursDays(int id);

string[][] geHotListTotals(int id1, int id2);

string[][] getHotListBomReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
			bool onlyDemand, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint,
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp,
			bool orderByPart);

void updateInventory(Inventory inventory);

bool existsInventory(string prodId,string splant);

Inventory readInventory(string prodId,string splant);

decimal getQtyOnHandForProduct(string prodId);

string[][] getAllPltInvLocAsString();

string[][] getInventoryReport(string prodId);

string[][] getInventoryForSchedule(string splantOriginal,string spart, int seq, string stockLoc,string smachine,int imachineId,string sglExp,string srepPoint, string sprodFamily,DateTime startDate, DateTime endDate, bool baddReceipParts, bool bgetCumulativeQty, int irows);

string[] getMachineCodes();

string[] getMachineCodesFromConfiguration(string plt, string dept, string cfg);

string[] getMachineCodesByPlt(string plt);

string[] getMachineByPartAndSeq(string plant, string dept, string part, int seq);

string[] getMachineCodesByPltDept(string plt, string dept);

string[][] getMachinesByPltDept(string plt, string dept);

string[][] getMachinesByPltDeptAndDesc(string plt, string dept, string searchText);

Machine[] getMachinesNotInAnyConfiguration(string plt, string dept);

Machine[] getMachinesNotInConfiguration(string plt, string dept, string cfg);

Machine[] getMachinesFromConfiguration(string plt, string dept, string cfg);

bool existsMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach);

Machine createMachine();
MachineContainer createMachineContainer();

MachineDef createMachineDef();
MachineDefContainer createMachineDefContainer();


Machine readMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach);
Machine readMachineById(int id);
Machine readMachineForce(string splant, string sdept, string smachine);

void writeMachine(Machine machine);

void deleteMachine (Machine machine);

void updateMachine(Machine machine);

bool existPltDeptMachShf(string plt,string dept, string mach,string shift,DateTime start,DateTime end);

string[] getAllCfgFromHotListAsString();

bool existsPerson(string plt, string id);

Person createPerson();

Person readPerson(string plt, string id);

Person[] readPersonsById(string id);
PersonContainer readPersonsByFilters(string splant,string sid,string stype,string scustType,string status,string sname,string saddress1,string sbillToCust,string sphone,int irows);

Plant createPlant();

void updatePerson(Person person);

void writePerson(Person person);

void deletePerson(string plt, string id);

string[][] getPersonsByDesc(string desc);

string[][] getPersonsByDesc(string desc, string type, string plant, string billToCust);

bool existsPlant(string plt);

Plant readPlant(string plt);

string[] getPlantCodes();

string[][] getPlantsByDesc(string desc);

bool existsProccess(string code, bool family);

Proccess readProccess(string code, bool family);

void writeProccess(Proccess proccess);

void updateProccess(Proccess proccess);

void deleteProccess(Proccess proccess);

string[] getProductCodes();

string[] getManufacturedProductCodes(string plantCode);

string[][] getProductsByDescOrId(string desc, string retailProductType);

string[][] getProductsByProdId(string prod);

string[][] getProductsByFamilyId(string family);

decimal[] getSeqQOHs(string part,string splant);

decimal getRunStdByPart(string part, string seq);

string[][] getProductsByProdIdAndFamily(string prod, bool family);

string[][] getProductsByDesc(string desc);

string[][] getFamilyPartsByDesc(string desc);

string[] getProductFamilyCodes();

bool isFamilyPart(string partNum);

string[] getValidsSeqsForProduct(string productCode);

string[] getValidsSeqsByProdAndDept(string productCode, string department);

bool existsProduct(string id);

Product createProduct();

Product readProduct(string id);

void writeProduct(Product product);

void updateProduct(Product product);

void deleteProduct(Product product);

void recalcAllPartsLevel();

string[][] getComponentsFromFamily(string familyCode);

string[][] getAllMaterialsForProduct(string prodId, int seqId,string splant);

string[] getMainMaterial(string prodId, string seq);

string[][] getProductsForReportAsString(string infMayGroup,string infMinGroup,string supMayGroup,string supMinGroup, string[] prodsID);

bool existsProductPlan(string	prodID,	int	seq);

ProductPlan createProductPlan();
ProductPlanContainer createProductPlanContainer();

ProductPlan readProductPlan(string	prodID, int seq);

void updateProductPlan(ProductPlan productPlan);

void writeProductPlan(ProductPlan productPlan);

void deleteProductPlan(string	prodID, int	seq);

string[][] getProductPlanAsString(string prod);

string[][] getAllProductPlansAsString();

void clearLeadTimes();

Schedule readSchedule(string plt, string version);

CapacityVersion readCapacityVersion (string version);

void writeSchedule(Schedule schedule);

void updateSchedule(Schedule schedule);

void deleteSchedule(Schedule schedule);

string[][] getActiveCapacityVersions(string plt);

string[] getCfgFromProd(string plt, string prod);

decimal getProductionHours(string plt, string prod, decimal qty);

string[][] getScheduleForReport(string plantCode,string deptCode);

SchQohAssignation createSchQohAssignation();

void writeSchQohAssignation (SchQohAssignation schQohAssignation);

void updateSchQohAssignation (SchQohAssignation schQohAssignation);

SchQohAssignation readSchQohAssignation (string plant, string department, string version);

bool existsShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf);

bool existsShift(string SH_Plt, string SH_Dept, string SH_Shf);

Shift readShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf);

Shift readShift(string SH_Plt, string SH_Dept, string SH_Shf);

ShiftContainer readShiftsByPltDept(string db, int company, string plt, string dept);

ShiftContainer readShiftsByPltDept(string plt, string dept);

ShiftContainer readShiftsByPlt(string plt);

ShiftContainer readShifts();

void writeShift(Shift shift);

void updateShift(Shift shift);

void deleteShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf);

void deleteShift(string SH_Plt, string SH_Dept, string SH_Shf, string SH_ShfGrp, 
			string SH_ShfType, string SH_ShfStatus);

string[] getShiftCodesByPltDept(string db, int company, string plt, string dept);

string[] getShiftCodesByPltDept(string plt, string dept);

bool existsShiftDayDetailTrans(string db, int company, string plt, string dept, string shift, DateTime startDate,DateTime endDate,int type);

bool existsShiftDayDetailTrans(string plt, string dept, string shift, DateTime startDate,DateTime endDate,int type);

string[][] getShiftHdrByDesc(string desc, string db, int company, string plt, string dept);

Shift createShift();

bool existsTask(int id);

Task readTask(int id);

void updateTask(Task task);

void writeTask(Task task);

void deleteTask(int id);

void setAutimaticDelay(int delay);

int getAutimaticDelay();

void setNoRunStart(string noRunStart);

string getNoRunStart();

void setNoRunEnd(string noRunEnd);

string getNoRunEnd();

void insertTaskEngine(int taskCode, string parameters);

void updateTaskConfiguration(TaskConfiguration taskConfiguration);

TaskConfiguration readTaskConfiguration(int taskCode);

string getNextRunTaskInformation(int taskId);

void stopAllPendingTasks(int taskId);

string[][] getAllTaskConfiguration();

void setFilters(string[] stkbFilter, string[] wipbFilter);

string[] getStkbFilters(); 

string[] getWipbFilters(); 

string[][] getTimeCodes();

TimeCode[] getTimeCodeObjects();

decimal getMachineTimeCodePorc (string plt, string dept, string machine, string timeCode);

string[][] getPaintOrdersHotListAsString(int pONum);

string[][] getPaintOrdersHotListSumAsString();

CapacityVersion createCapacityVersion();

void writeCapacityVersion(CapacityVersion capacityVersion);

bool existsCapacityVersion(string version);

int generateCmsPrHistLbHist();

int cms400ToCmsTempLbHist();

int generateCmsLbHist();

int cmsTempToNujitMeHistMach();

int cmsTempToNujitMeHistLab();

bool existsUser(int id);

bool existsUserByName(string loginName);

User createUser();

User readUser(int id);

User readUserByName(string loginName);

void writeUser(User user);

void updateUser(User user);

void deleteUser(User user);

UserContainer readUsers();

UserSignin createUserSignin();

//Claudia
PlantContainer readAllPlants();

void updatePlant(Plant plant);

void insertPlant(Plant plant);

void deletePlant(Plant plant);

bool hasDeptForPlant(string plant);

bool existsDepartament(string plt, string dept);

Departament createDepartament();

Departament readDepartament(string plt, string dept);

void writeDepartament(Departament departament);

void updateDepartament(Departament departament);

void deleteDepartament(Departament departament);

DepartamentContainer readDepartamentsByFilters(string scompany, string splant, string sdept, string sdeptDesc, int rows);

DepartamentContainer readDepartamentsByPlt(string plt);

ArrayList generateDeptsPrHist(string smode, DateTime dateBefore, DateTime dateAfter, string splant, 
	string sshift, string sdept, string sresource, string spart, int seq);

bool existsByDept(string dept);

bool hasMachineForDept(Departament departament);

bool hasConfigurationForDept(Departament departament);

decimal getMinInventory(string prodId, int seq);

#region OE
     
Employee createEmployee();
EmployeeContainer createEmployeeContainer();

void updateEmployee(Employee employee);

void writeEmployee(Employee employee);

bool existsEmployee(string id);

bool existsEmployee(string slogin,string spass,out string sempId);

Employee readEmployee(string id,bool bfull=false);

string[][] getEmployeeByDesc(string desc, int iTop);

EmployeeContainer readEmployeeByFilters(string sid,string firstName,string lastName,string status,int iassignShift,string sdept,int idftLabourTypeId, bool bhasDefLababour,bool bonlyHdr,int rows);

EmployeeLabour createEmployeeLabour();
EmployeeLabourContainer createEmployeeLabourContainer();
EmployeeLabourView createEmployeeLabourView();

EmployeeShift createEmployeeShift();
EmployeeShiftContainer createEmployeeShiftContainer();
bool existsEmployeeShift(int id);
EmployeeShift readEmployeeShift(int id);
void updateEmployeeShift(EmployeeShift employeeShift);
void writeEmployeeShift(EmployeeShift employeeShift);
void deleteEmployeeShift(int id);
EmployeeShiftContainer readEmployeeShiftByFilters(string sid, int ishiftNum, DateTime startDate,int rows);

Hashtable readPrHistByFiltersHashByPartSeq(string part,int seq,string sdept,DateTime fromDate,DateTime toDate,int irows);

Hashtable readPrHistByFiltersHashSummarizedByPartSeq(string part,int seq,string sdept,DateTime fromDate,DateTime toDate, PrHistSumViewContainer prHistSumViewContainer, int irows);

PrHistSumView createPrHistSumView();
    
PrHistSumViewContainer createPrHistSumViewContainer();

#endregion

#region EmpShiftScheduleHdr

EmpShiftScheduleHdr createEmpShiftScheduleHdr();
EmpShiftScheduleHdrContainer createEmpShiftScheduleHdrContainer();
EmpShiftScheduleDtl createEmpShiftScheduleDtl();
EmpShiftScheduleDtlView createEmpShiftScheduleDtlView();
EmpShiftScheduleDtlContainer createEmpShiftScheduleDtlContainer();
EmpShiftScheduleNotes createEmpShiftScheduleNotes();	
EmpShiftScheduleNotesContainer createEmpShiftScheduleNotesContainer();
EmpShiftScheduleHdrSumView createEmpShiftScheduleHdrSumView();	
EmpShiftScheduleHdrSumViewContainer createEmpShiftScheduleHdrSumViewContainer();

void createDefaultsEmpShiftScheduleNotes(EmpShiftScheduleHdr empShiftScheduleHdr);
bool existsEmpShiftScheduleHdr(int id);
EmpShiftScheduleHdr readEmpShiftScheduleHdr(int id);
void updateEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr);
void writeEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr);
void deleteEmpShiftScheduleHdr(int id);
EmpShiftScheduleHdr cloneEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr);
EmpShiftScheduleHdrContainer readEmpShiftScheduleHdrByFilters(string sid,string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string snotes, string screatedByEmpId,bool bonlyHdr,int rows);
Hashtable readEmpShiftScheduleHdrSumViewByFilters(string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string screatedByEmpId,int rows);

EmpShiftScheduleReportView createEmpShiftScheduleReportView();
EmpShiftScheduleReportViewContainer createEmpShiftScheduleReportViewContainer();
EmpShiftScheduleReportTransformView createEmpShiftScheduleReportTransformView();
EmpShiftScheduleReportTransformViewContainer createEmpShiftScheduleReportTransformViewContainer();
EmpShiftScheduleReportViewContainer readEmpShiftScheduleReportViewByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate,int ishiftNum,int rows);       
EmpShiftScheduleReportViewContainer readMachEmpShiftScheduleReportViewByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate,int ishiftNum,string swithPriorityYesNo,int rows);       


#endregion EmpShiftScheduleHdr


string[][] getAllDownCodes();

int cms400ToCmsTempPssc();

int cmsTempToNujitPssc();

int cms400ToNujitPssc();

int cms400ToCmsTempScrap();

int cmsTempToNujitScrap();

int cms400ToNujitScrap();

int cms400ToCmsTempSprsn();

int cmsTempToNujitSprsn();

int cms400ToNujitSprsn();

int generateCMSIcstm();

int cms400ToCmsTempIcstm();

int generateCMSIcstp();

int cmsTempToNujitIcstm();

int cms400ToCmsTempIcstp();

int cmsTempToNujitIcstp();

int generateCMSSeri();
int cms400ToCmsTempSeri();

int cmsTempToNujitSeri();
int generateCMSMainMat();
int cms400ToCmsTempMainMat();

int cmsTempToNujitMainMat();
string[][] getReport1268OnCVSFormat();
BolContainer readBolByFilters(string sferteg ,decimal dorder,bool borderByBol,int rows);

MainMat createMainMat();

MainMatContainer createMainMatContainer();

bool existsMainMat(string pART, int dTL);

MainMat readMainMat(string pART);

MainMatContainer readMainMatByFilters(string pART,string smainPart,bool bonlyHeaders,int rows);
	
void updateMainMat(MainMat mainMat);
    
void writeMainMat(MainMat mainMat);

string generateShcByMachine(string plt, string dept,string part, int seq);

MacConfiguration createConfiguration();

MacConfiguration[] readAllConfigurations(string plt, string dept);

bool existsConfiguration (string plt, string dept, string cfg);

MacConfiguration readConfiguration (string plt, string dept, string cfg);

void writeConfiguration (MacConfiguration conf);

void updateConfiguration (MacConfiguration conf);

void deleteConfiguration (MacConfiguration conf);

bool configurationHasMachines (MacConfiguration conf);

void removeMachineFromConfiguration (Machine machine, MacConfiguration configuration);

void removeMachineFromAllConfigurations (Machine machine);

void addMachineToCfg (Machine machine, MacConfiguration configuration);

MachineContainer readMachinesByFilters(string smachine, string sdes1,string plant,string sdept,string scheduled,bool bonlyHeader,int rows);
MachineContainer readMachinesViewByFilters(string smachine, string sdes1,string plant,string sdept,string scheduled,DateTime planDate, ArrayList arrayMachineIds,bool bonlyHeader,int rows);

//#region storage type
//StorageType createStorageType();
//
//bool existsStorageType(string sdb,string stype);
//	
//StorageType readStorageType(string sdb,string stype);
//
//void updateStorageType(StorageType storageType);
//   
//void writeStorageType(StorageType storageType);
//
//void deleteStorageType(StorageType storageType);
//
//string[][] getStorageTypeByDesc(string desc,string sdb);
//
//#endregion storage type

#region Seri

Seri createSeri();
SeriContainer createSeriContainer();
SeriContainer readSeriCMSByFilters(string spart, string serialNum, string slot, string suppSerial,string smasterSerial, string splant, string stockLoc, DateTime startActivDate, DateTime endActivDate, string statusList, bool bechEDI870, string stradingPartner, int rows);

#endregion Seri


#region Company
string[][] getCompaniesAsString();

bool existsCompany(string sdb,int icompany);

Company readCompany(string sdb,int icompany);

void updateCompany(Company company);

void writeCompany(Company company);

void deleteCompany(Company company);

string[][] getCompanyByDesc(string desc,string sdb);

Company createCompany();
#endregion Company

//#region Bin
//string[][] getBinsFromSLocAsString(string db,int company, string plant, string stkLoc);
//
//bool existsBinByStkLoc(string sdb,int icompany,string splant,string stkLoc);
//
//bool existsBin(string sdb,int icompany,string splant,string stkLoc,string sbin);
//
//Bin readBin(string sdb,int icompany,string splant,string stkLoc,string sbin);
//
//void updateBin(Bin bin);
//
//void writeBin(Bin bin);
//
//void deleteBin(Bin bin);
//
//Bin createBin();
//
//string[][] getBinByDesc(string desc,string sdb,int icompany,string splant,string stkLocation);
//
//#endregion Bin
//
//#region Slot
//string[][] getSlotsFromBinAsString(string db,int company, string plant, string stkLoc, string bin);
//
//bool existSlotByBin(string db,int company, string plant, string stkLoc, string bin);
//
//bool existsSlot(string db, int company, string plant, string stkLoc,string bin, string slot);
//
//Slot createSlot();
//
//Slot readSlot(string db, int company, string plant, string stkLoc,string bin, string slot);
//
//void writeSlot(Slot slot);
//
//void updateSlot(Slot slot);
//
//void deleteSlot(Slot slot);
//
//string[][] getSlotByDesc(	string desc,string sdb,int icompany,string splant,string stkLocation,string sbin);
//
//#endregion slot
//
//#region Aisle
//Aisle createAisle();
//
//bool existsAisle(string db, string aisle);
//
//Aisle readAisle(string db, string aisle);
// 
//void writeAisle(Aisle aisle);
//
//void updateAisle(Aisle aisle);
//
//void deleteAisle(Aisle aisle);
//
//string[][] getAisleByDesc(string desc,string sdb);
//
//#endregion Aisle
//
//#region LevelCoreFactory
//bool existsLevel(string db, int level);
//
//Level createLevel();
//
//Level readLevel(string db, int level);
//
//void writeLevel(Level level);
//
//void updateLevel(Level level);
//
//void deleteLevel(Level level);
//
//string[][] getLevelByDesc(string desc,string sdb);
//
//#endregion LevelCoreFactory
//
//#region BayCoreFactory
//bool existsBay(string db, string bay);
//
//Bay createBay();
//
//Bay readBay(string db, string bay);
//
//void writeBay(Bay bay);
//
//void updateBay(Bay bay);
//
//void deleteBay(Bay bay);
//
//string[][] getBayByDesc(string desc,string sdb);
//
//#endregion BayCoreFactory
//
//#region StockLocation
//string[][] getStockLocationsFromPlantAsString(string db,int companyCode, string plantCode);
//
//bool existsStkLoc(string db, int company, string plant, string stkLoc);
//
//bool existsStkLocByPlant(string db, int company, string plant);
//
//StockLocation createStockLocation();
//
//StockLocation readStockLocation(string db, int company, string plant, string stkLoc);
//
//void writeStockLocation(StockLocation stockLocation);
//
//void updateStockLocation(StockLocation stockLocation);
//
//void deleteStockLocation(StockLocation stockLocation);
//
//string[][] getStkLocByDesc(string desc,string sdb,int icompany,string splant);
//
//string[][] getStkLocByPlant(string sdb,int icompany,string splant);
//
//bool existStkLocByPlant(string sdb,int icompany,string splant);
//
//#endregion StockLocation
//
//#region TransReason
//bool existsTransReason(string db, string transReason);
//
//TransReason createTransReason();
//
//TransReason readTransReason(string db, string transReason);
//
//void writeTransReason(TransReason transReason);
//
//void updateTransReason(TransReason transReason);
//
//void deleteTransReason(TransReason transReason);
//
//string[][] getTransReasonByDesc(string desc);
//#endregion TransReason

#region Plant
string[][] getPlantsFromCompanyAsString(string db,int companyCode);

bool existPlantByCompany(string db, int company);

Plt createPlt();

bool existsPlt(string sdb,int icompany, string splt);

Plt readPlt(string sdb,int icompany, string splt);

void updatePlt(Plt plt);

void writePlt(Plt plt);

void deletePlt(Plt plt);

string[][] getPltByDesc(string desc,string sdb,int icompany);

#endregion Plant

//#region QohBin
//bool existsQohBin(string db, int company, string plant, string stkLoc, string bin);
//
//QohBin readQohBin(string sdb, int icompany, string splant, string stockLoc, string sbin);
//
//void updateQohBin(QohBin qohBin);
//
//void writeQohBin(QohBin qohBin);
//
//void deleteQohBin(QohBin qohBin);
//
//QohBin createQohBin();
//
//string[][] getQohBinAsString(string db,int company,string plant, string stkLoc,string bin);
//
//#endregion QohBin
//
//#region Source
//bool existsSource (string source);
//
//Source readSource (string source);
//
//void updateSource(Source source);
//
//void writeSource(Source source);
//
//void deleteSource(Source source);
//
//string[][] getSourceByDesc(string desc);
//	
//Source createSource();
//#endregion Source
//
//#region TransType
//bool existsTransType (string stransType);
//
//TransType readTransType (string stransType);
//
//void updateTransType(TransType transType);
//
//void writeTransType(TransType transType);
//
//void deleteTransType(TransType transType);
//
//string[][] getTransTypeByDesc(string desc);
//	
//TransType createTransType();
//#endregion TransType
//
//#region QohStockLocation
//bool existsQohStockLoc(string sdb, int icompany, string splant, string stockLoc);
//
//QohStockLoc readQohStockLoc(string sdb, int icompany, string splant, string stockLoc);
//
//void updateQohStockLoc(QohStockLoc qohStockLoc);
//
//void writeQohStockLoc(QohStockLoc qohStockLoc);
//
//void deleteQohStockLoc(QohStockLoc qohStockLoc);
//
//QohStockLoc createQohStockLoc();
//
//string[][] getQohStkLocAsString(string db,int company, string plant,string stkLoc);
//
//#endregion QohStockLocation
//
//#region qohSlot
//
//bool existQohSlot(string db, int company, string plant, string stkLoc, string bin,string slot);
//
//string[][] getQohSlotAsString(string db,int company,string plant, string stkLoc,string bin,string slot);
//
//decimal getQohFromSlot(string db, int company, string plant, string stkLoc, string bin, string slot, string part, int sequence);
//
//QohSlot readQohSlot(string sdb, int icompany, string splant, string stockLoc,string sbin,string slot,
//					string spart, int isequence);
//
//QohSlot readQohExistSlot(	string sdb, int icompany, string splant, string stockLoc, string sbin,string slot);
//
//#endregion qohSlot
//
//#region Qoh Plant
//string[][] getQohPlantAsString(string db,int company, string plant);
//
//#endregion Qoh Plant
//
//#region unit
//bool existsUnit(string sdb,string suom);
//
//Unit readUnit(string sdb,string suom);
//
//void updateUnit(Unit unit);
//
//void writeUnit(Unit unit);
//
//void deleteUnit(Unit unit);
//
//string[][] getUnitByDesc(string desc, string db);
//
//Unit createUnit();
//#endregion unit
//
//#region UnitConPart
//bool existsUnitConPart (int id);
//
//UnitConPart readUnitConPart (int id);
//
//void updateUnitConPart(UnitConPart unitConPart);
//
//void writeUnitConPart(UnitConPart unitConPart);
//
//void deleteUnitConPart(UnitConPart unitConPart);
//
//string[][] getUnitConPartByDesc(string desc);
//
//UnitConPart createUnitConPart();
//
//#endregion UnitConPart
//
//#region Profile
//
//bool existsTransProfile(string db, string profileType);
//
//TransProfile createTransProfile();
//
//TransProfile readTransProfile(string db, string profileType);
//
//void writeTransProfile(TransProfile transProfile);
//
//void updateTransProfile(TransProfile transProfile);
//
//void deleteTransProfile(TransProfile transProfile);
//
//string[][] getTransProfileByDesc(string desc, string db);
//
//#endregion Profile
//
//#region Container
//
//string[][] getContainersByDescAsString(string desc);
//
//Container createContainer();
//
//bool existsContainer(string container);
//
//Container readContainer(string containerCode);
//
//void updateContainer(Container container);
//
//void writeContainer(Container container);
//
//void deleteContainer(Container container);
//
//#endregion Container
//
//#region qohStockLocDtl
//
//bool existsQohStockLocDtl(string sdb, int icompany, string splant, string stockLoc,string part, int sequence);
//
//QohStockLocDtl readQohStockLocDtl(string sdb, int icompany, string splant, string stockLoc,string part, int sequence);
//
// void updateQohStockLocDtl(QohStockLocDtl qohStockLocDtl);
//
//void writeQohStockLocDtl(QohStockLocDtl qohStockLocDtl);
// 
//void deleteQohStockLocDtl(QohStockLocDtl qohStockLocDtl);
//
//QohStockLocDtl createQohStockLocDtl();
//
//#endregion qohStockLocDtl
//
//#region UnitCon
//bool existsUnitCon(string sdb,string suom1,string suom2);
//
//UnitCon readUnitCon(string sdb,string suom1,string suom2);
//
//void updateUnitCon(UnitCon unitCon );
//
//void writeUnitCon(UnitCon unitCon );
//
//void deleteUnitCon(UnitCon unitCon );
//
//string[][] getUnitConByDesc(string desc);
//
//UnitCon createUnitCon();
//
//#endregion UnitCon
//
//#region InventType
//bool existsInventType(string stype);
//
//InventType readInventType(string stype);
//
//void updateInventType(InventType inventType);
//
//void writeInventType(InventType inventType);
//
//void deleteInventType(InventType inventType);
//
//string[][] getInventTypeByDesc(string desc);
//
//InventType createInventType();
//#endregion InventType
//
//#region DemandPrf
//bool existsDemandPrf(string db,string demandPrf);
//
//DemandPrf createDemandPrf();
//
//DemandPrf readDemandPrf(string db,string demandPrf);
//
//void writeDemandPrf(DemandPrf demandPrf);
//
//void updateDemandPrf(DemandPrf demandPrf);
//
//void deleteDemandPrf(DemandPrf demandPrf);
//
//string[][] getDemandPrfByDesc(string searchText);
//
//#endregion DemandPrf

int cmsTempToNujitMmgp();


int cms400ToCmsTempMmgp();


int generateCMSMmgp();

#region Capacity

Capacity createCapacity();

bool existsCapacity(string version, string plt, string dept, string mach);

Capacity readCapacity(string version, string plt, string dept, string mach);

void writeCapacity(Capacity capacity);

void updateCapacity(Capacity capacity);

void deleteCapacity(Capacity capacity);

string[] getShiftCodesByPltDeptEnd(string plt, string dept, DateTime endDate);

#endregion Capacity

MaterialBomContainer generateMaterialListRecursive(string prodId, int seq,string splant);

#region stkt
int generateCMSStkt();

int cms400ToCmsTempStkt();

string[][] getShortageReportAsString(string[] vecMajorFilter,string[] vecMinorFilter,DateTime dateFrom);

#endregion

string[] getMajorGroupASString(string major);

string[] getMinorGroupASString();
ArrayList readGLExps();

ProductContainer readProductByFilters(string sprodId,string sdes1,int imachineId,string majGroup,string stype,int rows);
ProductContainer readProductViewByFilters(string splant,string sprodId,string sdes1,int imachineId,string smajGroup,string stype,string schMatAvailFlag,int rows);

RoutingContainer getBuildByFilters(string splant,string sprodId, int seq, int imachineId,bool bincludeAlternative,bool bonlyMachAlternative);

#region Rprd
int generateCMSRprd();
int cms400ToCmsTempRprd();
#endregion

#region Rprr
int generateCMSRprr();
int cms400ToCmsTempRprr();
#endregion

#region Rprs
int generateCMSRprs();
int cms400ToCmsTempRprs();
#endregion

#region Rprh
int generateCMSRprh();
int cms400ToCmsTempRprh();
#endregion

#region Rprs
int generateCMSRprp();
int cms400ToCmsTempRprp();
#endregion

#region ExcelReports

void generateExcelReport(ExcelReportSetup excelReportSetup);

ExcelReportSetup createExcelReportSetup();

bool existsExcelReportSetup(string reportName);

ExcelReportSetup readExcelReportSetup(string reportName);

string[][] getExcelReportSetupsByDescType(string searchText,string type, int rows);

void updateExcelReportSetup(ExcelReportSetup excelReportSetup);

void writeExcelReportSetup(ExcelReportSetup excelReportSetup);

void deleteExcelReportSetup(string reportName);

ExcelReportSetup cloneExcelReportSetup(ExcelReportSetup excelReportSetup);

#endregion ExcelReports

/*** MTHL - Method File - Tooling ***/

int cms400ToCmsTempMthl();

int cmsTempToNujitMthl();

int generateCMSMthl();

/************************************/

/*** TMST - Tool Master File ***/

int cms400ToCmsTempTmst();

int cmsTempToNujitTmst();

int generateCMSTmst();

/************************************/

#region SchLog

SchLog createSchLog();

bool existsSchLog(string db, string jobcardID, string company, string plant);

SchLog readSchLog(string db, string jobcardID, string company, string plant);

string[] readSchLogForReport(string db, string jobcardID, string company, string plant);

string[][] getSchLogByDesc(string searchText, int rows);

void updateSchLog(SchLog schLog);

void writeSchLog(SchLog schLog);

void deleteSchLog(string db, string jobcardID, string company, string plant);

SchLog cloneSchLog(SchLog schLog);

string[][] getPdToolByDesc(string searchText, int rows);

string[][] getPdToolByPart(string part1, string part2, string part3, string part4);

string getToolDescription(string db, string company, string plant, string tool);

string getToolDescriptionById(int id);

#endregion SchLog


#region Report

RP1268H createRP1268H();

RP1268HContainer createRP1268HContainer();

RP1268D createRP1268D();

RP1268DContainer createRP1268DContainer();

void writeRP1268H(RP1268H rP1268H);

ArrayList runReport1268();
RP1268H runStoreReport1268(out ArrayList alist);

ArrayList getStoredReport1268(int iheaderID,out DateTime dateProcessed);

ArrayList getDemandForPart(string spart);
      
Bolm createBolm();
BolmContainer createBolmContainer();
BolmContainer readBolmByFilters(decimal dbolid, DateTime startDate, DateTime endDate, string status, string shipVia, string struckID, string sroute,int rows);

#endregion Report

#region Demand

DemandH createDemandH();

DemandHContainer createDemandHContainer();

bool existsDemandH(int id);

DemandH readDemandH(int id);
DemandH readDemandHLast(string splant);

void updateDemandH(DemandH demandH);
void updateDemandHSpecicDtl(DemandH demandH,DemandD demandD);

void writeDemandH(DemandH demandH);

void deleteDemandH(int id);

DemandH cloneDemandH(DemandH demandH);

DemandD createDemandD();

DemandDContainer createDemandDContainer();

DemandD cloneDemandD(DemandD demandD);

DemandH processDemand830862ByDate(string splant,DateTime startDate, DateTime endDate,bool bimportItems,bool bimportInventory);

DemandHContainer readDemandHByFilters(string id,string splant,string status, decimal dtrlpKeyId,DateTime fromDate,DateTime toDate,int rows);

DemandDViewContainer getDemandDViewReportByFilters(int id,string source,string stimecode,string stpartner,string sbillTo,string shipTo,string spart,bool baddAuthorizations,bool baddTimeCode,int irows);
DemandDCompareViewContainer getDemandDCompareViewReportByFilters(string splant,string source,string stPartner, string shipLoc, string spart,DateTime runDate, DateTime startRelDate, DateTime endRelDate,bool bcumulative, int irows);
ArrayList readDemandDTradingPartners(string splant,string source);
ArrayList readDemandDShipLocs(string splant, string source,string stpartner);
ArrayList readDemandDPartsByFilters(string splant,string source,string stpartner,string shipLoc);

DemandDView createDemandDView();
DemandDViewContainer createDemandDViewContainer();
DemandDCompareViewContainer createDemandDCompareViewContainer();
DemandDCompareLeftViewContainer createDemandDCompareLeftViewContainer();
DemandDCompareReportViewContainer createDemandDCompareReportViewContainer();

#endregion Demand


#region DemandTransform
DemTransformH createDemTransformH();
DemTransformHContainer createDemTransformHContainer();
DemTransformOptions createDemTransformOptions();

bool existsDemTransformH(int id);

DemTransformH readDemTransformH(int id);
void updateDemTransformH(DemTransformH demTransformH);
void writeDemTransformH(DemTransformH demTransformH);

void deleteDemTransformH(int id);
DemTransformH cloneDemTransformH(DemTransformH demTransformH);
DemTransformD createDemTransformD();
DemTransformDContainer createDemTransformDContainer();
DemTransformH processDemandTransform(DemTransformOptions demTransformOptions);
DemTransformH getDemTransformHdrByMaxID(int demandHdr);
DemandH processDemandMerge830862(DemandH demandH);
        
#endregion DemandTransform


#region DemandWeek

DemandWeek createDemandWeek();
DemandWeekContainer createDemandWeekContainer();

bool existsDemandWeek(int id);	
DemandWeek readDemandWeek(int id);
void updateDemandWeek(DemandWeek demandWeek);
void writeDemandWeek(DemandWeek demandWeek);
void deleteDemandWeek(int id);
DemandWeekContainer generateDemandWeek(DemandH demandH);
void processDemandDCompareViewNetQtyDifferences(bool bcumulative,DateTime runDate,DemandDCompareViewContainer demandDCompareViewContainer);

#endregion DemandWeek


string[][] generateCMSInventory2();

void processDemandTransformH(DemandH demandH, DemTransformH demTransformH);

#region CapacityDemand

CapacityHdr createCapacityHdr();

CapacityHdrContainer createCapacityHdrContainer();

CapacityPart createCapacityPart();

CapacityPartContainer createCapacityPartContainer();

CapacityPartDtl createCapacityPartDtl();

CapacityPartDtlContainer createCapacityPartDtlContainer();

CapacityMachPriority createCapacityMachPriority();
CapacityMachPriorityContainer createCapacityMachPriorityContainer();
CapacityMachPriority cloneCapacityMachPriority(CapacityMachPriority capacityMachPriority);


CapacityReq createCapacityReq();

CapacityReqContainer createCapacityReqContainer();

CapacityView createCapacityView();

CapacityViewContainer createCapacityViewContainer();

CapacityViewHdr createCapacityViewHdr();

CapacityViewHdrContainer createCapacityViewHdrContainer();

CapacityView cloneCapacityView(CapacityView capacityView);

bool existsCapacityHdr(int id);

CapacityHdr readCapacityHdr(int id);

void updateCapacityHdr(CapacityHdr capacityHdr);
bool updateCapacityPart(CapacityPart capacityPart);
void updateCapacityHdrOnlyMachinePriority(CapacityHdr capacityHdr);
CapacityMachPriority getCapacityMachPriority(int imachineId,string splant);

void writeCapacityHdr(CapacityHdr capacityHdr);

void deleteCapacityHdr(int id);

CapacityHdrContainer readCapacityHdrByFilters(string sid,string splant,string status,DateTime fromDate, DateTime toDate,bool bonlyHeader,int rows);
CapacityHdr readCapacityHdrLast(string splant,bool bonlyHeadr);
CapacityHdr readCapacityHdrLastDateCheck(CapacityHdr capacityHdr, string splant);

CapacityHdr processCapacityDemand(int ihotListId,string splantOriginal);

CapacityViewContainer processCapacityReport(int icapacityHdrId, string splant, string sdept, string srequirment, string stype,string spart);

CapacityViewContainer processCapacityReportGroupByReqTypeDept(int icapacityHdrId,string splant,string sdept,string srequirment,int ireqId,string stype,string spart,DateTime dateWeek,CapacityView.SORT_TYPE sortType);

CapacityViewContainer readCapacityViewPartByFilters(int icapacityHdrId,string splant,string sdept,string srequirment,string stype, MachineContainer machineContainer, DateTime startDate,DateTime endDate);
ScheduleHdr processScheduleByCapacityReportParts(int icapacityHdrId,string splant,string sdept,string srequirment,string stype, MachineContainer machineContainer, DateTime startDate,DateTime endDate,CapacityView.SORT_TYPE sortType);
CapacityPartContainer getCapacityPartContainerByFilters(int ihdrId,string spart,int iseq,string stype,int ireqId,int rows);

LabourPlanningReportShiftView createLabourPlanningReportShiftView();
LabourPlanningReportShiftViewContainer createLabourPlanningReportShiftViewContainer();

#endregion CapacityDemand

#region CapShiftTask

CapShiftProfile createCapShiftProfile();

CapShiftProfileView createCapShiftProfileView();
CapShiftProfileContainer createCapShiftProfileContainer();

bool existsCapShiftProfile(int id);

CapShiftProfile readCapShiftProfile(int id);
CapShiftProfile readCapShiftProfileLast(string splant);

void updateCapShiftProfile(CapShiftProfile capShiftProfile);

void writeCapShiftProfile(CapShiftProfile capShiftProfile);

void deleteCapShiftProfile(int id);

CapShiftProfileContainer readCapShiftProfileByFilters(string sid,string splant,int ishiftNum,string status,DateTime dstartDate,DateTime sendDate, int ishiftTaskId, string shiftDefault, bool bonlyHeader,int rows);
CapShiftProfileContainer readCapShiftProfileByExactlyDatesFilters(string splant,int ishiftNum,string status, DateTime dateTime, bool bonlyHeader, int rows);
CapShiftProfileContainer readCapShiftProfilesForWeek(string splant, string status, DateTime dateTime, bool bonlyHeader);
Hashtable readCapShiftProfilesForWeekHash(string splant,string status,DateTime fromDate,DateTime toDate, int imachineId,bool bonlyHeader);
CapShiftProfile cloneCapShiftProfile(CapShiftProfile capShiftProfile);
CapShiftProfileView cloneCapShiftProfileView(CapShiftProfile capShiftProfile);
CapShiftProfileDtl createCapShiftProfileDtl();
CapShiftProfileMachPlan createCapShiftProfileMachPlan();        
CapShiftProfileMachPlanEmployee createCapShiftProfileMachPlanEmployee();
CapShiftProfileMachPlanEmployeeContainer createCapShiftProfileMachPlanEmployeeContainer();

CapShiftProfileDtlView createCapShiftProfileDtlView(CapShiftProfileDtl capShiftProfileDtl);
CapShiftProfileDtlContainer createCapShiftProfileDtlContainer();
CapShiftProfileDtl cloneCapShiftProfileDtl(CapShiftProfileDtl capShiftProfileDtl);

CapShiftTask createCapShiftTask();

CapShiftTaskContainer createCapShiftTaskContainer();

bool existsCapShiftTask(int id);

CapShiftTask readCapShiftTask(int id);

void updateCapShiftTask(CapShiftTask capShiftTask);

void writeCapShiftTask(CapShiftTask capShiftTask);

void deleteCapShiftTask(int id);

CapShiftTask cloneCapShiftTask(CapShiftTask capShiftTask);
CapShiftTaskContainer readCapShiftTaskByFilters(string sid, string staskName,string sdirInd,int rows);

CapProfileHoliday createCapProfileHoliday();
CapProfileHolidayContainer createCapProfileHolidayContainer();
CapProfileHolidayContainer readCapProfileHolidayByFilters(string sid,string splant, string sholidayType,DateTime startDate, DateTime endDate,int rows);
CapProfileHolidayContainer readIfHoliday(string splant,DateTime date,int rows);
double getCapProfileHolidayDatesAffects(string splant,DateTime startDate,DateTime endDate);
CapProfileHoliday readCapProfileHoliday(int id);
void updateCapProfileHoliday(CapProfileHoliday capProfileHoliday);
void writeCapProfileHoliday(CapProfileHoliday capProfileHoliday);
void deleteCapProfileHoliday(int id);

#endregion CapShiftTask


#region ScheduleHdr
ScheduleHdr createScheduleHdr();
ScheduleHdrContainer createScheduleHdrContainer();
ScheduleHdr cloneScheduleHdr(ScheduleHdr scheduleHdr);

bool existsScheduleHdr(int id);

ScheduleHdr readScheduleHdr(int id);
ScheduleHdr readScheduleHdrLast(string splant);
ScheduleHdr readScheduleHdrLastDateCheck(ScheduleHdr scheduleHdr, string splant);

void updateScheduleHdr(ScheduleHdr scheduleHdr);

void writeScheduleHdr(ScheduleHdr scheduleHdr);

void deleteScheduleHdr(int id);
ScheduleHdrContainer readScheduleHdrByFilters(string sid,string splant, string status, int icapacityHdr, int ihotListId, DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows);

void loadScheduleHdrAdditionalInfo(ScheduleHdr scheduleHdr,Hashtable hashMachinesById);

SchedulePart createSchedulePart();
SchedulePartContainer createSchedulePartContainer();

SchedulePart cloneSchedulePart(SchedulePart schedulePart);
bool generateAutomaticReceiptPart(SchedulePart schedulePart);
bool generateAutomaticMaterialConsumition(SchedulePart schedulePart,BomSumContainer bomSumContainer);
void moveDatesFromSchedulePartTask(ScheduleHdr scheduleHdr, ScheduleReqViewContainer scheduleReqViewContainer,ScheduleReqView scheduleReqViewSelected);

SchedulePartDtl createSchedulePartDtl();
SchedulePartDtlContainer createSchedulePartDtlContainer();
ScheduleReqView createScheduleReqView();
ScheduleReqViewContainer createScheduleReqViewContainer();
ScheduleTask createScheduleTask();
ScheduleTaskContainer createScheduleTaskContainer();
ScheduleTask cloneScheduleTask(ScheduleTask scheduleTask);

ScheduleDown createScheduleDown();
ScheduleDownContainer createScheduleDownContainer();
ScheduleDown cloneScheduleDown(ScheduleDown scheduleDown);

ScheduleReceiptPart createScheduleReceiptPart();
ScheduleReceiptPartContainer createScheduleReceiptPartContainer();
ScheduleReceiptPart cloneScheduleReceiptPart(ScheduleReceiptPart scheduleReceiptPart);
ScheduleReceiptPartContainer getReceiptPartContainerByFilters(int ischeduleId,string splantOriginal,string part,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate);
ScheduleMaterialConsumPartContainer getMaterialConsumPartContainerByFilters(int ischeduleId, string splantOriginal,string spart,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate);
string[][] getFutureInventoryByWeek(int id,string splantOriginal,string spartFilter,int iseqFilter,string smachine, int imachineId,string sglExp,DateTime startDate,DateTime endDate,int rows);
MachineReportView createMachineReportView();
MachineReportPartView createMachineReportPartView();
ReportWeeksView createReportWeeksView();
ReportWeeksViewContainer createReportWeeksViewContainer();
PartReportWeeksViewContainer createPartReportWeeksViewContainer();
MachineReportViewContainer createMachineReportViewContainer();
MachineReportPartView cloneMachineReportPartView(MachineReportPartView machineReportPartView);
CapacityPart generateNewCapacityPartBasedPlanned(CapacityHdr capacityHdr,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart);

LabourPlanningReportView createLabourPlanningReportView();
LabourPlanningReportViewContainer createLabourPlanningReportViewContainer();
CellPlanningLabType createCellPlanningLabType();

ScheduleMaterialConsumPart createScheduleMaterialConsumPart();
ScheduleMaterialConsumPartContainer createScheduleMaterialConsumPartContainer();
ScheduleMaterialConsumPart cloneScheduleMaterialConsumPart(ScheduleMaterialConsumPart scheduleMaterialConsumPart);

bool loadBuildMachineInfo(string splantOriginal,string spart,int seq,int imachineId,out string splant,out string sdept,out string smachine,out decimal drunStd,out decimal dcavities,out decimal optRunQty);
decimal getRunStd(string splant,string part,int seq,int machineId);


HotListView createHotListView();
HotListViewContainer createHotListViewContainer();
HotListViewHdr createHotListViewHdr();
HotListViewHdrContainer createHotListViewHdrContainer();
HotListView cloneHotListView(HotListView hotListView);
HotListViewContainer getHotListOrderedByDate(int ihotListId,string splantOriginal,string sdept,string smachine);
HotListViewContainer processHotListSchedule(int ihotListId,string splantOriginal,string sdept, string smachine,string spart,int iseq,string sreportedPoint);
ScheduleHdr processScheduleByHotListView(int icapacityHdrId, HotListViewContainer hotListViewContainer, MachineContainer machineContainer, DateTime startDate, DateTime endDate, CapacityView.SORT_TYPE sortType);
ScheduleHdr getIfAlreadyScheduled(int ihotListId,int icapacityHdrId);


SchedulePart scheduleAddSchedulePart(ref ScheduleHdr scheduleHdr,string splant,int imachId,string spart,int seq,decimal qty,DateTime dateTime,bool fromHotList,bool badd,out string smessError);

#endregion ScheduleHdr

#region Routing

Routing createRouting();
RoutingContainer createRoutingContainer();
RoutingLabTool createRoutingLabTool();
RoutingLabToolContainer createRoutingLabToolContainer();

bool existsRouting(string prodID, string plt, string dept, string actID, int seq, string cfg);	
Routing readRouting(int id);	
RoutingContainer readRoutingByFilters(string spart,string splant,string sdept,int seq,string smach,string sroutingType,bool blabToolInvolved,bool bonlyHdr,int rows);
void updateRouting(Routing routing);		
void writeRouting(Routing routing);
void deleteRouting(int id);
RoutingLabTool cloneRoutingLabTool(RoutingLabTool routingLabTool);

//LabourType createLabourType();
//LabourTypeContainer createLabourTypeContainer();
LabourTypeRequired createLabourTypeRequired();
LabourTypeRequiredContainer createLabourTypeRequiredContainer();

/*
LabourType readLabourType(int id);
void updateLabourType(LabourType labourType);
void writeLabourType(LabourType labourType);
void deleteLabourType(int id);
LabourTypeContainer readLabourTypeByFilters(string scode,string slabName,string sdirInd,int rows);
*/
string[][] readToolByFilters(string scompany,string splant,string stoolNumber, string sdesc1,int rows);
string[][] getHotListLabourType(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows);
LabourTypeRequiredContainer getHotListLabourType2(Hashtable hashMachines,Hashtable hashRoutings,Hashtable hashTasks,ScheduleHdr scheduleHdr, int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,string sprodFamily,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows);
LabourPlanningReportViewContainer getPlannedLabourType(LabourPlanningReportViewContainer labourPlanningReportViewContainer, PlannedHdr plannedHdrFilter ,Hashtable hashMachinesById,Hashtable hashRoutings, Hashtable hashTasks,string splant,string sdept,int imachineId,string spart,int iseq,string sreportedPoint,bool bgenericShiftNum,int rows);
decimal loadPlannedHdrHoursByMachineRangeDate(PlannedHdr plannedHdr, Hashtable hashPrHistSum,int imachineId,DateTime startDate,DateTime endDate,Hashtable hashRoutings);
PlannedHdr machinePlannedFillAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine,MachineReportPartView machineReportPartView);
PlannedHdr machinePlannedFillFullAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine, MachineReportViewContainer machineReportViewContainer,bool bcheckMaxBuilds);
PlannedHdr machinePlannedClearAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine, MachineReportViewContainer machineReportViewContainer);
MachineContainer loadMachinePlannedHdrShiftRemainings(PlannedHdr plannedHdr, CapacityHdr capacityHdr,string splant,Hashtable hashPrHistSum,Hashtable hashRoutings);
int createDefaultsRoutingLabour();

//LabourType cloneLabourType(LabourType labourType);

#endregion Routing



#region PlannedHdr

PlannedHdr createPlannedHdr();
PlannedHdrContainer createPlannedHdrContainer();
PlannedLabour createPlannedLabour();
PlannedLabourContainer createPlannedLabourContainer();

bool existsPlannedHdr(int id);
PlannedHdr readPlannedHdr(int id);
PlannedHdr readPlannedHdrLast(string splant);
PlannedHdr readPlannedHdrLastDateCheck(PlannedHdr plannedHdr,string splant);
void updatePlannedHdr(PlannedHdr plannedHdr);
void updatePlannedHdrOnlyPlannedReq(PlannedHdr plannedHdr,PlannedReq plannedReq,bool bisNewReq);
void writePlannedHdr(PlannedHdr plannedHdr);
void deletePlannedHdr(int id);
PlannedHdr clonePlannedHdr(PlannedHdr plannedHdr);

bool updatePlannedPart(PlannedHdr plannedHdr,PlannedPart plannedPart);
PlannedPart generateNewPlannedPartBasedPlanned(PlannedHdr plannedHdr,string splant,int imachineId, string spart, int iseq,decimal dqty,decimal dtyOvertime,DateTime startDate,bool bgenerateForChilds);
PlannedLabour generateNewPlannedLabourBasedPlanned(PlannedHdr plannedHdr,string splant,int imachineId, int ishiftNum, CapacityView capacityView, CellPlanningLabType cellPlanningLabType);
void getPlannedPartViewByFilters(string splant,string spart,int seq);
bool readPlannedPartsHash(string splant,ref DateTime plannedDateTimeStamp,ref Hashtable hashPlannedParts);
bool compareNewHotListVsPriorHotListFillPlannedQtyChange(string splant);
bool existsPlannedPartSfiftProfileMachine(int iprofShiftHdrId,int iprofShiftHdrDtl);
void plannedMoveQtyChangeToPlanned(PlannedHdr plannedHdr, string splant,int imachineId,DateTime fromDate);

#endregion PlannedHdr


#region InventoryObjectives

InventoryObjectiveHdr createInventoryObjectiveHdr();
InventoryObjectiveHdrContainer createInventoryObjectiveHdrContainer();

bool existsInventoryObjectiveHdr(int id);
InventoryObjectiveHdr readInventoryObjectiveHdr(int id);
void updateInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr);
void writeInventoryObjectiveHdr(InventoryObjectiveHdr inventoryObjectiveHdr);
void deleteInventoryObjectiveHdr(int id);
InventoryObjectiveHdrContainer readInventoryObjectiveHdrByFilters(string sid,string splant, string status,DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows);
InventoryObjectiveHdr readInventoryObjectiveHdrLast(string splant);
InventoryObjectiveHdr readInventoryObjectiveHdrLastDateCheck(InventoryObjectiveHdr inventoryObjectiveHdr, string splant);
InventoryObjectiveHdr recalcAutomaticObjectives(string splant);
InventoryObjectivePart generateNewInventoryObjectivePartBasedPlanned(InventoryObjectiveHdr inventoryObjectiveHdr, string splant,int imachineId,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart);

InventoryObjectivePart createInventoryObjectivePart();
InventoryObjectivePartContainer createInventoryObjectivePartContainer();
InventoryObjectivePartDtl createInventoryObjectivePartDtl();
InventoryObjectivePartDtlContainer createInventoryObjectivePartDtlContainer();
InventoryObjectiveReportView createInventoryObjectiveReportView();
InventoryObjectivePart cloneInventoryObjectivePart(InventoryObjectivePart inventoryObjectivePart);

#endregion InventoryObjectives

#region SchMaterialAvail

SchMaterialAvail createSchMaterialAvail();
SchMaterialAvailContainer createSchMaterialAvailContainer();
SchProductAvail createSchProductAvail(Product product);
SchMaterialAvailContainer processSchMaterialAvail(SchMaterialAvailContainer schMaterialAvailTotUsedContainer,BomSumContainer matBomSumContainer, HotListHdr hotListHdr,string spart,int seq,DateTime dateTime,decimal dqty);

SchMaterialAvail readSchMaterialAvail(int id);
void updateSchMaterialAvail(SchMaterialAvail schMaterialAvail);
void writeSchMaterialAvail(SchMaterialAvail schMaterialAvail);
SchMaterialAvailContainer readSchMaterialAvailByFilters(string splant, int parentSrcHotId, int parentSrcHotDtlId, int notParentSrcHotDtlId, string sparentPart,int partentSeq,string schildPart,int childSeq,DateTime dateTime,bool blastSeq,int rows);

#endregion SchMaterialAvail

#region PackSlip

PackSlip createPackSlip();
PackSlipContainer createPackSlipContainer();

bool existsPackSlip(int id);
PackSlip readPackSlip(int id);
void updatePackSlip(PackSlip packSlip);
void writePackSlip(PackSlip packSlip);
void deletePackSlip(int id);
PackSlipContainer transferPackSlipByFilters(string splant,DateTime fromDate,DateTime toDate,bool brunQuickProcess,int irows);
PackSlipContainer readPackSlipByFilters(string splant,DateTime fromDate,DateTime toDate,bool bonlyHeader,int irows);


#endregion PackSlip

#region ProductPlanDt

ProductPlanDt createProductPlanDt();
ProductPlanDtContainer createProductPlanDtContainer();
ProductPlanDtContainer readProductPlanDtByFilters(string sfamCfg, int ifamSeq,string spart,int iseq,int rows);

#endregion ProductPlanDt


#region UpCum01P

UpCum01P createUpCum01P();

UpCum01PContainer createUpCum01PContainer();

UpCum01PViewContainer createUpCum01PViewContainer();
        
bool existsUpCum01P(decimal fGBOL, decimal fGENT);

UpCum01P readUpCum01P(decimal fGBOL, decimal fGENT);

void updateUpCum01P(UpCum01P upCum01P);

void writeUpCum01P(UpCum01P upCum01P);

void deleteUpCum01P(decimal fGBOL, decimal fGENT);

UpCum01P cloneUpCum01P(UpCum01P upCum01P);

UpCum01PContainer readUpCum01PByFilters(decimal fGBOL, decimal fGENT,string sbillTo,string shipTo);

UpCum01PViewContainer readUpCum01PCustomByFilters(string splant,string stpartner,string sbillTo,string shipTo,string sbol, string sorder, string spo, string scustPO,string shipped,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows);

void adjustNewShipExportFields(UpCum01PViewContainer upCum01PViewContainer);

#endregion UpCum01P

#region CustPart

CustParts createCustParts();

CustPartsContainer createCustPartsContainer();

bool existsCustPart(string prodID, string billToCust, string shipToCust);

CustParts readCustPart(string prodID, string billToCust, string shipToCust);

void updateCustPart(CustParts custPart);

void writeCustPart(CustParts custPart);

void deleteCustPart(string prodID, string billToCust, string shipToCust);

CustParts cloneCustParts(CustParts custPart);

CustPartsContainer readCustPartByFilters(string spart,string sbillTo,string shipTo,string scustPart,int irows);

#endregion CustPart


#region ShipExport

ShipExport createShipExport();

ShipExportContainer createShipExportContainer();

ShipExportDtl createShipExportDtl();

ShipExportDtlContainer createShipExportDtlContainer();

bool existsShipExport(string site, decimal bol, decimal bolItem);

ShipExport readShipExport(string site, decimal bol, decimal bolItem);

void updateShipExport(ShipExport shipExport);

void writeShipExport(ShipExport shipExport);

void deleteShipExport(string site, decimal bol, decimal bolItem);

ShipExport cloneShipExport(ShipExport shipExport);

ShipExportContainer readShipExportByFilters(string sbillTo,string shipTo,string smajSales,DateTime fromShipDate,DateTime toShipDate,int rows);

ShipExportContainer adjustShipExporAndSumLeadTime(ShipExport shipExport);

ShipExportContainer bolsShipExport(UpCum01PViewContainer upCum01PViewContainer);
ShipExportContainer reprocessShipExportSum(ShipExportSumContainer shipExportSumContainerProcess);

bool loadShipExportDtlsFromAS400(UpCum01PViewContainer upCum01PViewContainer);

void loadShipExportToUpCum01PList(UpCum01PViewContainer upCum01PViewContainer);

ShipExportContainer processShipExportAutomatically(string splant);

int loadCustPOToShipExport();

ShipExportSum createShipExportSum();
ShipExportSumContainer createShipExportSumContainer();
bool existsShipExportSum(decimal orderNum, decimal item, string release);
ShipExportSum readShipExportSum(decimal orderNum, decimal item, string release);
void updateShipExportSum(ShipExportSum shipExportSum);
void updateShipExportSumForced(ShipExportSum shipExportSum);
void writeShipExportSum(ShipExportSum shipExportSum);
void updateShipExportSumNote(ShipExportSum shipExportSum);
void deleteShipExportSum(decimal orderNum, decimal item, string release);
ShipExportSum cloneShipExportSum(ShipExportSum shipExportSum);
ShipExportSumContainer createShipExportSumNewFields(UpCum01PViewContainer upCum01PViewContainer);

void loadGenericPriorCum();

ShipExportSumContainer readShipExportSumByFilters(string splant,string sbillTo,string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows);

ShipExportSumContainer readShipExportSumCompareByFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,
                                                        bool bqtyOrder, bool bqtyShip, bool bdateReq, bool bdateShip,bool bqtyPpm, bool bleadTime, bool bppap,int irows);


#endregion ShipExport

#region CustLead

CustLead createCustLead();

CustLeadContainer createCustLeadContainer();

bool existsCustLead(string custId, string majSalesCode, string minGroup);

CustLead readCustLead(string custId, string majSalesCode, string minGroup);

void updateCustLead(CustLead custLead);

void writeCustLead(CustLead custLead);

void deleteCustLead(string custId, string majSalesCode, string minGroup);

CustLead cloneCustLead(CustLead custLead);

CustLeadContainer readCustLeadByFilters(string scustID,string sexactCustId,string smajSalesCode,string sminGroup,int irows);

CustLeadContainer readCustLeadByCustomerFilters(string scustID,string smajSalesCode);

#endregion CustLead


#region Stxh

Stxh createStxh();

StxhContainer createStxhContainer();

StxhContainer readStxhByFilters(decimal oYLOG,string oYTRPR,string oYDOCN, DateTime fromDate, DateTime toDate,int irows);

ArrayList getStxhDifferentsTPartnerByFiltersDate(DateTime fromDate,DateTime toDate);

#endregion Stxh


#region LastExported

LastExported createLastExported();

LastExportedContainer createLastExportedContainer();

bool existsLastExported(string code);

LastExported readLastExported(string code);

void updateLastExported(LastExported lastExported);

void writeLastExported(LastExported lastExported);

void deleteLastExported(string code);

#endregion LastExported


#region EdiTransTP
EdiTransTP createEdiTransTP();
    
EdiTransTPContainer createEdiTransTPContainer();

EdiTransTPContainer createEdiTransTPartnerAutomatic();
void justTestDemandDay();

#endregion EdiTransTP

#region ShipExportRelease

ShipExportRelease createShipExportRelease();

ShipExportReleaseContainer createShipExportReleaseContainer();

bool loadShipExportReleasesFromAS400(UpCum01PViewContainer upCum01PViewContainer);

#endregion ShipExportRelease

#region TradingPartner

TradingPartner createTradingPartner();

TradingPartnerContainer createTradingPartnerContainer();

bool existsTradingPartner(string tPartner);
TradingPartner readTradingPartner(string tPartner);
void updateTradingPartner(TradingPartner tradingPartner);
void writeTradingPartner(TradingPartner tradingPartner);
void deleteTradingPartner(string tPartner);
TradingPartner cloneTradingPartner(TradingPartner tradingPartner);
TradingPartnerContainer readTradingPartnerByFilters(string stpartner,int irows);

#endregion TradingPartner

#region Trlp

ArrayList readTrlpTradingPartners(string splant,string source);    
ArrayList readTrlpShipLocs(string stpartner);
ArrayList readTrlpPartsByFilters(string stpartner,string shipLoc);

DemandDCompareViewContainer getAS400DemandDCompareViewReportByFilters(string splant,string source,string stPartner,string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows);
DemandDCompareViewContainer getAS400DemandDCompareViewReportBoldByFilters(string splant,string source,string stPartner,string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate, bool bcumulative, int irows);
DemandDCompareViewContainer getLocalDemandDCompareViewReportByFilters(string splant, string source, string stPartner, string shipLoc, string spart, DateTime runDate, DateTime startRelDate, DateTime endRelDate, bool bcumulative,bool bqtyDifferences, int irows);
DemandDCompareViewContainer getLocalDemandDCompareAllViewReportByFilters(string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum, DateTime runDate,DateTime fromDate,DateTime toDate,int irows);
DemandDCompareViewContainer getLocalDemandDCompareAllViewReportByFilters2(string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum, DateTime runDate,DateTime fromDate,DateTime toDate, bool bshowDifferences,bool bqtyDifferences,bool bcumulative,bool bcolumnsWQty,int irows);
DemandDCompareReportViewContainer getLocalDemandDCompareAllViewReportByFilters3(string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum, DateTime runDate,DateTime fromDate,DateTime toDate, bool bshowDifferences,bool bqtyDifferences,bool bcumulative,bool bcolumnsWQty,int irows);

#endregion Trlp

} // class
} // namespace

