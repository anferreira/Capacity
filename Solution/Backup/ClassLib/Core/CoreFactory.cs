using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Core.ExcelReports;


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
string[][] getProdBOMChild(string prodId, int seqId);

string[][] getParentMaterials(string matId, int seqId);

int QtyInSubmaterialsOf(string matSrch, int matSrchSeq, string matId, int matSeq);

string[][] getSubMaterials(string matId, int seqId);

bool existsBomSum(string prodID, int seq, string matID, int matSeq);

bool existsBomSumObj(BomSum bomSumObj) ;

BomSum readBomSum(string prodID, int seq, string matID, int matSeq);

void writeBomSum(BomSum bomSum);

void updateBomSum(BomSum bomSum);

void deleteBomSum(BomSum bomSum);

BomSumTempContainer readBomSumTreeProdSeq(string prodId, int prodSeq);

BomSumTempContainer readBomSumTree(BomSumTempContainer bomSumTempContainer, string prodId, int prodSeq);

void updateBomSumTempContainer(BomSumTempContainer bomSumTempContainer);

BomContainer makeBoms();

void loadInfoForBom();

void discardInfoForBom();

Bom makeBomFromProdIDAndSeq (string prodId, int seqId);

void seeBom(Bom bom, string parent);

string[][] getAllPurchasedMaterials(string prodId, int seqId);

ArrayList getAllPurchasedMaterialsFromBom(Bom bom, ArrayList lst);

string[][] getErrorsBom();

int cms400ToCmsTempItems();

int cmsTempToNujitItems();

int generateCMSItems();

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

string[] getDepartamentCodes();

string[] getDepartamentCodesByPlt(string plt);

string[] getAllDeptFromHotListAsString();

string getDepartamentDescription(string dept);

string getPlantCodeByDept(string departamentCode);

string[][] getDepartmentByDesc(string desc, string db, int company, string plt);

void createHotList(string[] stkbFilter, string[] wipbFilter, string[][] badWipb);

string[][] getHotListAsString(int id,string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type);

string[][] getDemandAsString(string[] filterPart);

string[][] getActiveDemandAsStringByDate(DateTime dateFrom, DateTime dateTo);

string[][] getDemandAsStringByDate(DateTime dateFrom, DateTime dateTo);

string[][] getHotListAsStringByDemand(bool onlyDemand);

string[][] getAllMatReqAsString(string[] depts, string[]parts );

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

string[][] getMaterialDueDate(bool weeks, string[] depts, string[] parts, bool orderByVendor, string[] stkLocs);

void blockHotList();

bool isHotListBlocked();

void unBlockHotList();

HotListHourContainer getHotListHoursDays(int id);

string[][] geHotListTotals(int id1, int id2);

string[][] getHotListBomReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
			bool onlyDemand, bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint,
			bool hoursReport, bool orderByResource, bool labourReport, bool orderByMajorMinorGrp,
			bool orderByPart);

void updateInventory(Inventory inventory);

bool existsInventory(string prodId);

Inventory readInventory(string prodId);

decimal getQtyOnHandForProduct(string prodId);

string[][] getAllPltInvLocAsString();

string[][] getInventoryReport(string prodId);

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

Machine readMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach);

void writeMachine(Machine machine);

void deleteMachine (Machine machine);

void updateMachine(Machine machine);

bool existPltDeptMachShf(string plt,string dept, string mach,string shift,DateTime start,DateTime end);

string[] getAllCfgFromHotListAsString();

bool existsPerson(string plt, string id);

Person createPerson();

Person readPerson(string plt, string id);

Person[] readPersonsById(string id);

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

decimal[] getSeqQOHs(string part);

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

string[][] getComponentsFromFamily(string familyCode);

string[][] getAllMaterialsForProduct(string prodId, int seqId);

string[] getMainMaterial(string prodId, string seq);

string[][] getProductsForReportAsString(string infMayGroup,string infMinGroup,string supMayGroup,string supMinGroup, string[] prodsID);

bool existsProductPlan(string	prodID,	int	seq);

ProductPlan createProductPlan();

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

DepartamentContainer readDepartaments();

DepartamentContainer readDepartamentsByPlt(string plt);

ArrayList generateDeptsPrHist(string smode, DateTime dateBefore, DateTime dateAfter, string splant, 
	string sshift, string sdept, string sresource, string spart, int seq);

bool existsByDept(string dept);

bool hasMachineForDept(Departament departament);

bool hasConfigurationForDept(Departament departament);

decimal getMinInventory(string prodId, int seq);

#region OE
string[][] getDiscountsByDesc(string sdesc,int itop);

ArrayList getDiscountsInGroupDescByDesc(string sgroupId,string sdesc,int itop,string sorderBy);

bool existsDiscount(string sdiscount);

Discount readDiscount(string sdiscount);

void updateDiscount(Discount discount);

void writeDiscount(Discount discount);

void deleteDiscount(string sdiscount);

void updateEmployee(Employee employee);

void writeEmployee(Employee employee);

bool existsEmployee(string id);

bool existsEmployee(string slogin,string spass,out string sempId);

Employee readEmployee(string id);

string[][] getEmployeeByDesc(string desc, int iTop);

string[][] getGroupDiscByCode (string sgroupCode);

GroupDisc readGroupDisc(string sgroupCode, int idisNum);

bool existsGroupDisc(string sgroupCode, int idisNum);

void writeGroupDisc(GroupDisc groupDisc);

void updateGroupDisc(GroupDisc groupDisc);

void deleteGroupDisc(GroupDisc groupDisc);

Note[] readNotes(string stype, int ikey1,int ikey2,int ikey3);

Note readNote(string stype, int ikey1,int ikey2,int ikey3,int ilineNum);

bool existsNote(string stype, int ikey1,int ikey2,int ikey3,int ilineNum);

void writeNote(Note note);

void updateNote(Note note);

void deleteNote(Note note);

void deleteNoteAllFromTypeKey(Note note);

int getMaxItemFromDetailCharge(int iorder, int itemNum);

bool existsOrderDtlCharge(OrderDtlCharge orderDtlCharge);

OrderDtlCharge readOrderDetailCharge(OrderDtlCharge orderDtlChargeCons);

OrderDtlCharge createOrderDtlCharge();

OrderDtl readIfProductSold(string sprodId);

int getMaxOrderLine(int iorder);

string[][] getOrderLinesById(int iorder);

Order getOrderLinesById(Order order);

OrderDtl readLineByProductId(int iorder,string sprodID);

bool existsOrderLine(int iorder,int item);

OrderDtl readOrderLine(int iorder,int item);

OrderDtl createOrderDtl();

int getMaxItemFromDetail(OrderDtlRel orderDtlRel);

string[][] getOrderDetailRelById(OrderDtlRel orderDtlRel);

bool existsOrderDetailRel(OrderDtlRel orderDtlRel);

OrderDtlRel readOrderDetailRel(OrderDtlRel orderDtlRelCons);

OrderDtl getOrderDetailRelById(OrderDtl orderDtl);

OrderDtlRel createOrderDtlRel();

void updateOrderNotSend();

int getMaxOrderHeader();

Order getOrderHeader(int iorder);

ArrayList readOrdersHeadersArrayList(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected);

Order[] readOrdersHeaders(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected, string sorderStatus, string sorderType, int iorderNum, bool onlyPendingOrders);

string[][] readOrdersHeaders(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected);

string[][] readOrdersHeadersNotSend();

bool existsOrderHeader(int iorder);

Order readOrderHeader(int iorder);

Order readOrderHeaderAllData(int iorder);

void writeOrderHeader(Order order);

void writeCompleteOrder (Order order);

void writeOrderHeaderAndLines(Order order);

void updateOrderHeader(Order order);

void updateCompleteOrder(Order order);

void deleteOrderHeader(Order order);

bool sendOrderToCMS(Order order, string user);

Order createOrder();

string[][] readProductPriceByCustomer(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive, decimal quantity);

string[][] readProductPrice(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive,decimal quantity);

bool existsProdPrice(string product,string customer,string type,DateTime EffecFrmDatem,DateTime EffecToDate,decimal volume);

void writeProdPrice(ProdPrice prodPrice);

void updateProdPrice(ProdPrice prodPrice);

void deleteProdPrice(ProdPrice prodPrice);

void deleteProdPriceOldies(DateTime dateTime);

ProductActCost readProductActCost(string sproduct, int iseq);

bool existsProdFmActCost(string sproduct, int iseq);

void writeProdFmActCost(ProductActCost productActCost);

void updateProdFmActCost(ProductActCost productActCost);

void deleteProdFmActCost(ProductActCost productActCost);
#endregion

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

//#region ItemType
//
//bool existsItemType(string stype);
//
//ItemType readItemType(string stype);
//
//void updateItemType(ItemType itemType);
//
//void writeItemType(ItemType itemType);
//
//void deleteItemType(ItemType itemType);
//
//string[][] getItemTypeByDesc(string desc);
//
//ItemType createItemType();
//
//#endregion ItemType
//
//#region ScanType
//bool existsScanType(string stype);
//
//ScanType readScanType(string stype);
//
//void updateScanType(ScanType scanType);
//
//void writeScanType(ScanType scanType);
//
//void deleteScanType(ScanType scanType);
//
//string[][] getScanTypeByDesc(string desc);
//
//ScanType createScanType();
//#endregion ScanType
//
//#region ItemInfo
//
//bool existsItemInfo (string db, string part);
//
//ItemInfo readItemInfo (string db, string part);
//
//ItemInfo readItemInfoWithSequences (string db, string part);
//
//void updateItemInfo(ItemInfo itemInfo);
//
//void writeItemInfo(ItemInfo itemInfo);
//
//bool deleteItemInfo(ItemInfo itemInfo);
//
//void deleteItemInfoCascade(ItemInfo itemInfo);
//
//string[][] getItemInfoByDesc(string desc, string db);
//
//bool itemInfoHasSeqs (ItemInfo itemInfo);
//
//bool itemInfoHasPlts (ItemInfo itemInfo);
//
//ItemInfo createItemInfo();
//
//string[][] getItemInfoByPart(string desc, string db);
//
//ItemInfo getItemInfoByUPC(string upc, string db);
//
//bool existsItemInfoPlt (string db, string part,string plant);
//
//ItemInfoPlt readItemInfoPlt (string db, string part,string plant);
//
//ItemInfoPlt readItemInfoPltWithSequences (string db, string part, string plant);
//
//void updateItemInfoPlt(ItemInfoPlt itemInfoPlt);
//
//void writeItemInfoPlt(ItemInfoPlt itemInfoPlt);
//
//void deleteItemInfoPlt(ItemInfoPlt itemInfoPlt);
//
//bool itemInfoPltHasSeqs (ItemInfoPlt itemInfoPlt);
//
//ItemInfoPlt getItemInfoPltFromItemInfo (ItemInfo itemInfo);
//
//ItemInfoPlt createItemInfoPlt();
//
//string[][] readItemInfoSeqFromItem (string db, string part);
//
//bool itemInfoSeqHasPlts (string db, string part, int seq);
//
//ItemInfoSeq createItemInfoSeq();
//
//string[][] readItemInfoSeqPltFromItemPlt (string db, string part, string plt);
//
//ItemInfoSeqPlt getItemInfoSeqPltFromItemInfoSeq (ItemInfoSeq itemInfoSeq);
//
//ItemInfoSeqPlt createItemInfoSeqPlt();
//
//bool itemInfoHasBusPartParts (ItemInfo itemInfo);
//
//#endregion
//
//#region ProdType
//bool existsProdType(string sdb,string stype);
//
//ProdType readProdType(string sdb,string stype);
//
//void updateProdType(ProdType prodType);
//
//void writeProdType(ProdType prodType);
//
//void deleteProdType(ProdType prodType);
//
//string[][] getProdTypeByDesc(string desc, string db);
//
//ProdType createProdType();
//#endregion ProdType
//
//#region ProcurePref
//bool existsProcurePref (string procurePrefId);
//
//ProcurePref readProcurePref (string procurePrefId);
//
//void updateProcurePref(ProcurePref procurePref);
//
//void writeProcurePref(ProcurePref procurePref);
//
//void deleteProcurePref(ProcurePref procurePref);
//
//ProcurePref createProcurePref();
//
//string[][] getProcurePrefByDesc(string desc);
//
//ProcurePref[] readAllProcurePref();
//
//#endregion ProcurePref
//
//#region SalesCode
//
//SalesCode createSalesCode();
//
//SalesCode readSalesCode(int id);
//
//SalesCode readSalesCodeByCodes (string sales1, string sales2, string sales3, string sales4, string sales5, string sales6);
//
//void updateSaleCode(SalesCode salesCode);
// 
//void writeSalesCode(SalesCode salesCode);
//
//void deleteSalesCode(SalesCode salesCode);
//
//string[][] getSalesCodeBySearch(string searchText, string db);
//
//bool existsSalesCode(SalesCode salesCode);
//
//
//#endregion SalesCode
//
//#region Defaults
//
//Defaults createDefaults();
//
//bool existsDefaults(string db, int company);
//
//Defaults readDefaults(string db, int company);
//
//void updateDefaults(Defaults defaults);
//
//void writeDefaults(Defaults defaults);
//
//void deleteDefaults(Defaults defaults);
//
//string[][] getDefaultsByDesc(string desc);
//#endregion Defaults
//
//#region InactiveReason
//
//InactiveReason createInactiveReason();
//
//
//bool existsInactiveReason(string db, string inactiveReason);
//
//
//InactiveReason readInactiveReason(string db, string inactiveReason);
//
//
//void writeInactiveReason(InactiveReason inactiveReason);
//
//
//void updateInactiveReason(InactiveReason inactiveReason);
//
//
//void deleteInactiveReason(InactiveReason inactiveReason);
//
//
//string[][] getInactiveReasonByDesc(string desc, string db);
//
//#endregion InactiveReason
//
//#region Transaction
//Transaction createTransaction();
//
//void writeTransaction(Transaction transaction);
//
//#endregion Transaction
//
//#region Mfg
//
//bool existsMfg(string sdb,string smfg);
//
//Mfg readMfg(string sdb,string smfg);
//
//void updateMfg(Mfg mfg);
//
//void writeMfg(Mfg mfg);
//
//void deleteMfg(Mfg mfg);
//
//string[][] getMfgByDesc(string desc,string sdb);
//
//Mfg createMfg();
//
//#endregion Mfg
//
//#region MfgModel
//
//bool existsMfgModel(string db,string mfg,string mfgModel);
//	
//MfgModel readMfgModel(string db,string mfg, string mfgModel);
//   
//void updateMfgModel(MfgModel mfgModel);
//   
//void writeMfgModel(MfgModel mfgModel);
//  
//void deleteMfgModel(MfgModel mfgModel);
//  
//MfgModel createMfgModel();
//
//string[][] getMfgModelByDesc(string searchText,string sdb);
//
//bool existsMfgModelByMfg(string db, string mfg);
//
//string [][] getMfgModelByCode(string mfg,string sdb);
//	
//#endregion MfgModel
//
//#region LabFormat
//	#region IvLabVariables
//
//	LabVariables createLabVariables();
//
//	//string[][] getLabVariablesByDesc(string desc,string sdb);
//
//	#endregion
//
//	#region IvLabFile
//	
//	LabFile createLabFile();
//
//	#endregion
//
//bool existsLabFormat(string sdb,string slabel);
//
//LabFormat readLabFormat(string sdb,string slabel);
//
//void updateLabFormat(LabFormat labFormat);
//
//void writeLabFormat(LabFormat labFormat);
//
//void deleteLabFormat(LabFormat labFormat);
//
//string[][] getLabFormatByDesc(string desc,string sdb);
//
//LabFormat createLabFormat();
//#endregion LabFormat
//
//#region colors
//bool existsColors(string code);
//
//Colors readColors(string code);
//
//void updateColors(Colors colors);
//
//void writeColors(Colors colors);
//
//void deleteColors(Colors colors);
//
//Colors createColors();
//
//string[][] getColorsByDesc(string desc);
//
//#endregion colors

#region Capacity

Capacity createCapacity();

bool existsCapacity(string version, string plt, string dept, string mach);

Capacity readCapacity(string version, string plt, string dept, string mach);

void writeCapacity(Capacity capacity);

void updateCapacity(Capacity capacity);

void deleteCapacity(Capacity capacity);

string[] getShiftCodesByPltDeptEnd(string plt, string dept, DateTime endDate);

#endregion Capacity

//#region IvLotMaster
//
//bool existsLotMaster (string dB, string part, int sequence, string fromLot);
//
//LotMaster readLotMaster (string dB, string part, int sequence, string fromLot);
//
//void updateLotMaster(LotMaster lotMaster);
//
//void writeLotMaster (LotMaster lotMaster);
//
//void deleteLotMaster (string dB, string part, int sequence, string fromLot);
//
//LotMaster createLotMaster();
//#endregion
//
//#region BusPartParts
//
//bool existsBusPartParts (string db, string prodID, int seq, string busPartnerBT,string busPartParts,
//                         string busPartnerST,string revision);
//
//BusPartParts readBusPartParts (string db, string prodID, int seq, string busPartnerBT,string busPartParts,
//                               string busPartnerST,string revision);
//
//void updateBusPartParts(BusPartParts busPartParts);
//
//void writeBusPartParts (BusPartParts busPartParts);
//
//void deleteBusPartParts (string db, string prodID, int seq, string busPartnerBT,string busPartParts,
//                         string busPartnerST,string revision);
//
//string[][] getBusPartPatsByDesc(string searchText, string db);
//
//string[][] getBusPartPartsByPart(string db,string part);
//
//BusPartParts readBusPartPartsById (int id);
//
//BusPartParts getBusPartPatsByUPC(string upc, string db);
//
//BusPartParts[] readBusPartPartsByFilters(string db, string part, int seq, string busPartnerBT,
//										string busPartPart,string busPartnerST,string revision);
//
//#endregion

#region GLCurrency

bool existsGLCurrency (string db, string currency);

GLCurrency readGLCurrency (string db, string currency);

void updateGLCurrency(GLCurrency gLCurrency);

void writeGLCurrency (GLCurrency gLCurrency);

void deleteGLCurrency (string db, string currency);

string[][] getCurrencyByDesc(string text, string db);


#endregion

#region GLCurrencyDlyExc

bool existsGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase);

GLCurrencyDlyExc readGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase);

void updateGLCurrencyDlyExc(GLCurrencyDlyExc gLCurrencyDlyExc);

void writeGLCurrencyDlyExc (GLCurrencyDlyExc gLCurrencyDlyExc);

void deleteGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase);

string[][] getCurrencyDlyExcByDesc(string text, string db);

#endregion

//#region IvSerial
//
//bool existsSerial (string dB, int serialNum);
//
//Serial readSerial (string dB, int serialNum);
//
//void updateSerial(Serial ivSerial);
//
//void writeSerial (Serial ivSerial);
//
//void deleteSerial (string dB, int serialNum);
//
//Serial createSerial();
//
//Serial readSerialByCustomSerial (string dB, string serialNum);
//
//#endregion
//
//#region TransSerial
//
//bool existsTransSerial (string dB, int serialTransNum);
//
//TransSerial readTransSerial (string dB, int serialTransNum);
//
//void updateTransSerial(TransSerial transSerial);
//
//void writeTransSerial (TransSerial transSerial);
//
//void deleteTransSerial (string dB, int serialTransNum);
//
//TransSerial createTransSerial();
//#endregion

#region Invoice

bool existsInvoice(string db,int company,string plant,int invoiceNum);

Invoice readInvoice (string db, int company, string plant, int invoiceNum);

void updateInvoice(Invoice invoice);

void writeInvoice (Invoice invoice);

void deleteInvoice (string db, int company, string plant, int invoiceNum);

string[][] getInvoiceByNum();

#endregion Invoice

#region PackSlip

bool existsPackSlip(string db, int company, string plant, int packSlipNum);

PackSlip readPackSlip(string db, int company, string plant, int packSlipNum);

void updatePackSlip(PackSlip packSlip);

void writePackSlip (PackSlip packSlip);

void deletePackSlip (string db, int company, string plant, int packSlipNum);

#endregion

MaterialBomContainer generateMaterialListRecursive(string prodId, int seq);

//#region SuppSerial
//
//bool existsSuppSerial (string dB, string supplier, string suppSerial);
//
//SuppSerial readSuppSerial (string dB, string supplier, string suppSerial);
//
//void updateSuppSerial(SuppSerial suppSerial);
//
//void writeSuppSerial (SuppSerial suppSerial);
//
//void deleteSuppSerial (string dB, string supplier, string suppSerial);
//
//SuppSerial createSuppSerial();
//
//#endregion

#region Contact

Contact createContact();

bool existsContact(int id);

Contact readContact(int id);

void updateContact(Contact contact);

void writeContact(Contact contact);

void deleteContact(Contact contact);

string[][] getContactsByDesc(string searchText);

bool canDeleteContact(Contact contact);

#endregion Contact

//#region Upc
//
//bool existsUpc (string db, string part, int sequence, string container, string uPC);
//
//Upc readUpc (string db, string part, int sequence, string container, string uPC);
//
//void updateUpc(Upc ivUPC);
//
//void writeUpc (Upc ivUPC);
//
//void deleteUpc (string db, string part, int sequence, string container, string uPC);
//
//string[][] getUpcByDesc(string desc,string sdb,string spart,int isequence,string scontainer,string supc,
//						string sbusPartnerBT,string sbusPartnerST,string sbusPartPart,string srevision);
//
//Upc[] readUpcByUpc(string sdb,string supc);
//
//#endregion
//
//#region LabCompDef
//
//bool existsLabCompDef (string db);
//
//string[][] readByLabCompDefDesc(string desc);
//
//LabCompDef readLabCompDef (string db);
//
//void updateLabCompDef(LabCompDef labCompDef);
//
//void writeLabCompDef (LabCompDef labCompDef);
//
//void deleteLabCompDef (string db);
//
//LabCompDef createLabCompDef();
//
//#endregion
//
//#region SerialMSMX
//
//bool existsSerialMSMX (string dB, int company, string plant, int msMxContainerSerial, int lowerLevelSerial);
//
//SerialMSMX readSerialMSMX (string dB, int company, string plant, int msMxContainerSerial, int lowerLevelSerial);
//
//void updateSerialMSMX(SerialMSMX serialMSMX);
//
//void writeSerialMSMX (SerialMSMX serialMSMX);
//
//void deleteSerialMSMX (string dB, int company, string plant, int msMxContainerSerial, int lowerLevelSerial);
//
//SerialMSMX createSerialMSMX();
//
//#endregion

#region stkt
int generateCMSStkt();

int cms400ToCmsTempStkt();

string[][] getShortageReportAsString(string[] vecMajorFilter,string[] vecMinorFilter,DateTime dateFrom);

#endregion

string[] getMajorGroupASString(string major);

string[] getMinorGroupASString();

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

#endregion SchLog

} // class
} // namespace

