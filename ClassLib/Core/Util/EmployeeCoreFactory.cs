using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class EmployeeCoreFactory : DepartamentCoreFactory	{

public
EmployeeCoreFactory() : base(){
}

public
Employee createEmployee(){
	return new Employee();
}

public
EmployeeContainer createEmployeeContainer(){
	return new EmployeeContainer();
}

public 
void updateEmployee(Employee employee){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmployeeDataBase employeeDataBase = objectToObjectDataBase(employee);		
		employeeDataBase.update();

        if (employee.ChildsRead) { 
            deleteEmployeeLabour(employee.Id);
            writeEmployeeLabour(employee);            
        }
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exc.Message,exc);
	}
}

public 
void writeEmployee(Employee employee){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmployeeDataBase employeeDataBase = objectToObjectDataBase(employee);
		employeeDataBase.write();

        if (employee.ChildsRead)
            writeEmployeeLabour(employee);
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exc.Message,exc);
	}
}

public 
bool existsEmployee(string id){
	try{

		EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
		employeeDataBase.setEmpID(id);
		return employeeDataBase.exists();

	}catch (PersistenceException pe){		
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}
}

public 
bool existsEmployee(string slogin,string spass,out string sempId)
{
	try{
		EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
		bool	bresult=false;

		sempId="";

		employeeDataBase.setLoginName(slogin);
		employeeDataBase.setPassword(spass);

		bresult = employeeDataBase.existsLogingPassw();
		if (bresult)
			sempId = employeeDataBase.getEmpID();//get the employee id

		return bresult;

	}catch (PersistenceException pe){		
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}
}

public 
Employee readEmployee(string id,bool childsRead = false){	
try{
    Employee employee = null;
	EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
	employeeDataBase.setEmpID(id);

	if (employeeDataBase.read()) { 			    
        employee = objectDataBaseToObject(employeeDataBase);

        if (childsRead){
            employee.ChildsRead=childsRead;
            readEmployeeChilds(employee);
        }
    }
    return employee;

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

private
void readEmployeeChilds(Employee employee){    
    EmployeeLabourDataBaseContainer employeeLabourDataBaseContainer = new EmployeeLabourDataBaseContainer(dataBaseAccess);    
    employeeLabourDataBaseContainer.readByEmpId(employee.Id);        

    foreach (EmployeeLabourDataBase employeeLabourDataBase in employeeLabourDataBaseContainer)
        employee.EmployeeLabourContainer.Add(objectDataBaseToObject(employeeLabourDataBase));        
}

#if OE_SYNC
public
ArrayList readToSynchronizeEmployee(LastRevision lastRevision,int iquantity)
{
	ArrayList	arrayList = new ArrayList();
	EmployeeDataBaseContainer employeeDataBaseContainer = new EmployeeDataBaseContainer(dataBaseAccess);

	employeeDataBaseContainer.readToSynchronize(lastRevision,iquantity);
	
	IEnumerator iEnum = employeeDataBaseContainer.GetEnumerator();
	while (iEnum.MoveNext()){
		EmployeeDataBase employeeDataBase = (EmployeeDataBase)iEnum.Current;		
	
		Employee employee = new Employee();
	
		employee.setId(employeeDataBase.getEmpID());
		employee.setFirstName(employeeDataBase.getFirstName());
		employee.setLastName(employeeDataBase.getLastName());
		employee.setLogin(employeeDataBase.getLoginName());
		employee.setPassword(employeeDataBase.getPassword());
		employee.setStatus(employeeDataBase.getStatusCode());
		employee.setDeptCode(employeeDataBase.getDeptCode());
		employee.setPostion(employeeDataBase.getPostion());
		employee.setCompanyExt(employeeDataBase.getCompanyExt());
		employee.setHomePhone(employeeDataBase.getHomePhone());
		employee.setCellPhone(employeeDataBase.getCellPhone());
		employee.setEmail(employeeDataBase.getEmail());
		employee.setComment(employeeDataBase.getComment());
		employee.setStyleSheet(employeeDataBase.getStyleSheet());
		employee.setRowsPerPage(employeeDataBase.getRowsPerPage());
		employee.setIsSalesRep(employeeDataBase.getIsSalesRep());
		employee.setDateUpdated(employeeDataBase.getDateUpdated());

		arrayList.Add(employee);
	}

	return arrayList;
}
#endif

public
string[][] getEmployeeByDesc(string desc, int iTop)
{
	try
	{
		EmployeeDataBaseContainer employeeDataBaseContainer = new EmployeeDataBaseContainer(dataBaseAccess);
		employeeDataBaseContainer.readByDesc(desc,iTop);

		string[][] vec = new String[employeeDataBaseContainer.Count][];
		int index = 0;

		IEnumerator iEnum = employeeDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			EmployeeDataBase employeeDataBase = (EmployeeDataBase)iEnum.Current;		
				
			string[] v = new String[5];
			v[0] = employeeDataBase.getEmpID();
			v[1] = employeeDataBase.getFirstName();
			v[2] = employeeDataBase.getLastName();	
			v[3] = employeeDataBase.getHomePhone();	
			v[4] = employeeDataBase.getCellPhone();	

			vec[index] = v;		
			index++;
		}
		return vec;

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

public
EmployeeContainer readEmployeeByFilters(string sid,string firstName,string lastName,string status,int iassignShift,string sdept,int idftLabourTypeId,bool bhasDefLababour,bool bonlyHdr,int rows){
	try{
        EmployeeContainer           employeeContainer = new EmployeeContainer();
	    EmployeeDataBaseContainer   employeeDataBaseContainer = new EmployeeDataBaseContainer(dataBaseAccess);
	    employeeDataBaseContainer.readByFilters(sid,firstName, lastName, status, iassignShift, sdept, idftLabourTypeId, bhasDefLababour,rows);

        CapShiftTaskContainer       capShiftTaskContainer  = bonlyHdr ? new CapShiftTaskContainer() : readCapShiftTaskByFilters("","","",0); //no so much records so better to read alls
        CapShiftTask                capShiftTask = null;
	    
	    foreach(EmployeeDataBase employeeDataBase in  employeeDataBaseContainer){

            Employee employee= objectDataBaseToObject(employeeDataBase);
            if (!bonlyHdr && employee.DftLabourTypeId > 0){      //get labour/task name
                capShiftTask = capShiftTaskContainer.getByKey(employee.DftLabourTypeId);
                employee.DftLabourTypeNameShow = capShiftTask!= null ? capShiftTask.TaskName : "";

                //read user labour, to load approval dates
                EmployeeLabourDataBaseContainer employeeLabourDataBaseContainer = new EmployeeLabourDataBaseContainer(dataBaseAccess);
                employeeLabourDataBaseContainer.readByEmpIdLabType(employee.Id,employee.DftLabourTypeId);
                if (employeeLabourDataBaseContainer.Count > 0){
                    EmployeeLabourDataBase employeeLabourDataBase = (EmployeeLabourDataBase)employeeLabourDataBaseContainer[0];
                    employee.ApprovDateShow = employeeLabourDataBase.getApprovDate();
                    employee.ApprovUntilDateShow = employeeLabourDataBase.getApprovUntilDate();
                }
            }
            employeeContainer.Add(employee);
        }
    	
	    return employeeContainer;
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

private
Employee objectDataBaseToObject(EmployeeDataBase employeeDataBase){	
	return new Employee(employeeDataBase.getEmpID(), employeeDataBase.getFirstName(), 
			employeeDataBase.getLastName(), employeeDataBase.getLoginName(),
			employeeDataBase.getPassword(), employeeDataBase.getStatusCode(),
			employeeDataBase.getDeptCode(), employeeDataBase.getPostion(),
			employeeDataBase.getCompanyExt(), employeeDataBase.getHomePhone(),
			employeeDataBase.getCellPhone(), employeeDataBase.getEmail(),
			employeeDataBase.getComment(), employeeDataBase.getStyleSheet(),
			employeeDataBase.getRowsPerPage(), employeeDataBase.getIsSalesRep(),
			employeeDataBase.getDateUpdated(), employeeDataBase.getAssignShift(), 
            employeeDataBase.getAssignOTShift(),employeeDataBase.getDftDept(),
            employeeDataBase.getLastLabourDate(), employeeDataBase.getDftLabourTypeId(),
            employeeDataBase.getTagNumber(), employeeDataBase.getDftMachId());
	
}

private
EmployeeDataBase objectToObjectDataBase(Employee employee){
	EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
	employeeDataBase.setEmpID(employee.getId());
	employeeDataBase.setFirstName(employee.getFirstName());
	employeeDataBase.setLastName(employee.getLastName());
	employeeDataBase.setLoginName(employee.getLogin());
	employeeDataBase.setPassword(employee.getPassword());
	employeeDataBase.setStatusCode(employee.getStatus());
	employeeDataBase.setDeptCode(employee.getDeptCode());
	employeeDataBase.setPostion(employee.getPostion());
	employeeDataBase.setCompanyExt(employee.getCompanyExt());
	employeeDataBase.setHomePhone(employee.getHomePhone());
	employeeDataBase.setCellPhone(employee.getCellPhone());
	employeeDataBase.setEmail(employee.getEmail());
	employeeDataBase.setComment(employee.getComment());
	employeeDataBase.setStyleSheet(employee.getStyleSheet());
	employeeDataBase.setRowsPerPage(employee.getRowsPerPage());
	employeeDataBase.setIsSalesRep(employee.getIsSalesRep());
	employeeDataBase.setDateUpdated(employee.getDateUpdated());
    employeeDataBase.setAssignShift(employee.AssignShift);
    employeeDataBase.setAssignOTShift(employee.AssignOTShift);
    employeeDataBase.setDftDept(employee.DftDept);
    employeeDataBase.setLastLabourDate(employee.LastLabourDate);
    employeeDataBase.setDftLabourTypeId(employee.DftLabourTypeId);

    employeeDataBase.setTagNumber(employee.TagNumber);
    employeeDataBase.setDftMachId(employee.DftMachId);

    return employeeDataBase;
}


/************************************************** EmployeeShift *************************************************************/
public
EmployeeShift createEmployeeShift(){
	return new EmployeeShift();
}

public
EmployeeShiftContainer createEmployeeShiftContainer(){
	return new EmployeeShiftContainer();
}

public
bool existsEmployeeShift(int id){
	try{
		EmployeeShiftDataBase employeeShiftDataBase = new EmployeeShiftDataBase(dataBaseAccess);

		employeeShiftDataBase.setId(id);

		return employeeShiftDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
EmployeeShift readEmployeeShift(int id){
	try{
		EmployeeShiftDataBase employeeShiftDataBase = new EmployeeShiftDataBase(dataBaseAccess);
		employeeShiftDataBase.setId(id);

		if (!employeeShiftDataBase.read())
			return null;

		EmployeeShift employeeShift = this.objectDataBaseToObject(employeeShiftDataBase);

		return employeeShift;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getEmployeeShiftByDesc(string searchText, int rows){
	try{
		EmployeeShiftDataBaseContainer employeeShiftDataBaseContainer = new EmployeeShiftDataBaseContainer(dataBaseAccess);
		employeeShiftDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[employeeShiftDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = employeeShiftDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			EmployeeShiftDataBase employeeShiftDataBase = (EmployeeShiftDataBase) en.Current;
			string[] item = new String[14];
			item[0] = employeeShiftDataBase.getId().ToString();
			item[1] = employeeShiftDataBase.getPlant();
			item[2] = employeeShiftDataBase.getShiftNum().ToString();
			item[3] = employeeShiftDataBase.getStartDate().ToString();
			item[4] = employeeShiftDataBase.getEndDate().ToString();
			item[5] = employeeShiftDataBase.getEmpId();
			item[6] = employeeShiftDataBase.getStatus();
			item[7] = employeeShiftDataBase.getMonWork();
			item[8] = employeeShiftDataBase.getTueWork();
			item[9] = employeeShiftDataBase.getWedWork();
			item[10] = employeeShiftDataBase.getThuWork();
			item[11] = employeeShiftDataBase.getFriWork();
			item[12] = employeeShiftDataBase.getSatWork();
			item[13] = employeeShiftDataBase.getSunWork();
			items[i] = item;
			i++;
		}
		return items;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateEmployeeShift(EmployeeShift employeeShift){
	try{
	    if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

		EmployeeShiftDataBase employeeShiftDataBase = this.objectToObjectDataBase(employeeShift);
		employeeShiftDataBase.update();

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
void writeEmployeeShift(EmployeeShift employeeShift){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmployeeShiftDataBase employeeShiftDataBase = this.objectToObjectDataBase(employeeShift);
		employeeShiftDataBase.write();

		employeeShift.Id=employeeShiftDataBase.getId();

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
void deleteEmployeeShift(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmployeeShiftDataBase employeeShiftDataBase = new EmployeeShiftDataBase(dataBaseAccess);

		employeeShiftDataBase.setId(id);
		employeeShiftDataBase.delete();

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
EmployeeShiftContainer readEmployeeShiftByFilters(string sid, int ishiftNum, DateTime startDate,int rows){
	try{
        EmployeeShiftContainer          employeeShiftContainer = new EmployeeShiftContainer();
	    EmployeeShiftDataBaseContainer  employeeShiftDataBaseContainer = new EmployeeShiftDataBaseContainer(dataBaseAccess);
	    employeeShiftDataBaseContainer.readByFilters(sid, ishiftNum,startDate,rows);
	    
	    foreach(EmployeeShiftDataBase employeeShiftDataBase in  employeeShiftDataBaseContainer){
            employeeShiftContainer.Add(objectDataBaseToObject(employeeShiftDataBase));
        }
    	
	    return employeeShiftContainer;
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

private
EmployeeShift objectDataBaseToObject(EmployeeShiftDataBase employeeShiftDataBase){
	EmployeeShift employeeShift = new EmployeeShift();

	employeeShift.Id=employeeShiftDataBase.getId();
	employeeShift.Plant=employeeShiftDataBase.getPlant();
	employeeShift.ShiftNum=employeeShiftDataBase.getShiftNum();
	employeeShift.StartDate=employeeShiftDataBase.getStartDate();
	employeeShift.EndDate=employeeShiftDataBase.getEndDate();
	employeeShift.EmpId=employeeShiftDataBase.getEmpId();
	employeeShift.Status=employeeShiftDataBase.getStatus();
	employeeShift.MonWork=employeeShiftDataBase.getMonWork();
	employeeShift.TueWork=employeeShiftDataBase.getTueWork();
	employeeShift.WedWork=employeeShiftDataBase.getWedWork();
	employeeShift.ThuWork=employeeShiftDataBase.getThuWork();
	employeeShift.FriWork=employeeShiftDataBase.getFriWork();
	employeeShift.SatWork=employeeShiftDataBase.getSatWork();
	employeeShift.SunWork=employeeShiftDataBase.getSunWork();

	return employeeShift;
}

private
EmployeeShiftDataBase objectToObjectDataBase(EmployeeShift employeeShift){
	EmployeeShiftDataBase employeeShiftDataBase = new EmployeeShiftDataBase(dataBaseAccess);
	employeeShiftDataBase.setId(employeeShift.Id);
	employeeShiftDataBase.setPlant(employeeShift.Plant);
	employeeShiftDataBase.setShiftNum(employeeShift.ShiftNum);
	employeeShiftDataBase.setStartDate(employeeShift.StartDate);
	employeeShiftDataBase.setEndDate(employeeShift.EndDate);
	employeeShiftDataBase.setEmpId(employeeShift.EmpId);
	employeeShiftDataBase.setStatus(employeeShift.Status);
	employeeShiftDataBase.setMonWork(employeeShift.MonWork);
	employeeShiftDataBase.setTueWork(employeeShift.TueWork);
	employeeShiftDataBase.setWedWork(employeeShift.WedWork);
	employeeShiftDataBase.setThuWork(employeeShift.ThuWork);
	employeeShiftDataBase.setFriWork(employeeShift.FriWork);
	employeeShiftDataBase.setSatWork(employeeShift.SatWork);
	employeeShiftDataBase.setSunWork(employeeShift.SunWork);

	return employeeShiftDataBase;
}

public
EmployeeShift cloneEmployeeShift(EmployeeShift employeeShift){
	EmployeeShift employeeShiftClone = new EmployeeShift();

	employeeShiftClone.Id=employeeShift.Id;
	employeeShiftClone.Plant=employeeShift.Plant;
	employeeShiftClone.ShiftNum=employeeShift.ShiftNum;
	employeeShiftClone.StartDate=employeeShift.StartDate;
	employeeShiftClone.EndDate=employeeShift.EndDate;
	employeeShiftClone.EmpId=employeeShift.EmpId;
	employeeShiftClone.Status=employeeShift.Status;
	employeeShiftClone.MonWork=employeeShift.MonWork;
	employeeShiftClone.TueWork=employeeShift.TueWork;
	employeeShiftClone.WedWork=employeeShift.WedWork;
	employeeShiftClone.ThuWork=employeeShift.ThuWork;
	employeeShiftClone.FriWork=employeeShift.FriWork;
	employeeShiftClone.SatWork=employeeShift.SatWork;
	employeeShiftClone.SunWork=employeeShift.SunWork;

	return employeeShiftClone;
}

/************************************************** EmployeeLabour *************************************************************/
public
EmployeeLabour createEmployeeLabour(){
	return new EmployeeLabour();
}

public
EmployeeLabourContainer createEmployeeLabourContainer(){
	return new EmployeeLabourContainer();
}

public
EmployeeLabourView createEmployeeLabourView(){
	return new EmployeeLabourView();
}

public 
void updateEmployeeLabours(Employee employee){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmployeeDataBase employeeDataBase = objectToObjectDataBase(employee);		
		employeeDataBase.update();
        
        writeEmployeeLabour(employee);
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exc.Message,exc);
	}
}

private
void deleteEmployeeLabour(string sempId){
    EmployeeLabourDataBaseContainer employeeLabourDataBaseContainer = new EmployeeLabourDataBaseContainer(dataBaseAccess);    
    employeeLabourDataBaseContainer.deleteByEmpId(sempId);        
}

private
void writeEmployeeLabour(Employee employee){
    employee.fillRedundances();

    foreach (EmployeeLabour employeeLabour in employee.EmployeeLabourContainer){
        EmployeeLabourDataBase employeeLabourDataBase = objectToObjectDataBase(employeeLabour);
        employeeLabourDataBase.write();
        employeeLabour.Id= employeeLabourDataBase.getId();
    }
}

private
EmployeeLabour objectDataBaseToObject(EmployeeLabourDataBase employeeLabourDataBase){
	EmployeeLabour employeeLabour = new EmployeeLabour();

	employeeLabour.Id=employeeLabourDataBase.getId();
	employeeLabour.EmpId=employeeLabourDataBase.getEmpId();
	employeeLabour.LabourTypeId=employeeLabourDataBase.getLabourTypeId();

    employeeLabour.ApprovDate       = employeeLabourDataBase.getApprovDate();
    employeeLabour.ApprovUntilDate  = employeeLabourDataBase.getApprovUntilDate();
    employeeLabour.ApprovByEmpId    = employeeLabourDataBase.getApprovByEmpId();
    employeeLabour.ApprovLevel      = employeeLabourDataBase.getApprovLevel();

	return employeeLabour;
}

private
EmployeeLabourDataBase objectToObjectDataBase(EmployeeLabour employeeLabour){
	EmployeeLabourDataBase employeeLabourDataBase = new EmployeeLabourDataBase(dataBaseAccess);
	employeeLabourDataBase.setId(employeeLabour.Id);
	employeeLabourDataBase.setEmpId(employeeLabour.EmpId);
	employeeLabourDataBase.setLabourTypeId(employeeLabour.LabourTypeId);

    employeeLabourDataBase.setApprovDate(employeeLabour.ApprovDate);
    employeeLabourDataBase.setApprovUntilDate(employeeLabour.ApprovUntilDate);
    employeeLabourDataBase.setApprovByEmpId(employeeLabour.ApprovByEmpId);
    employeeLabourDataBase.setApprovLevel(employeeLabour.ApprovLevel);

	return employeeLabourDataBase;
}

public
EmployeeLabour cloneEmployeeLabour(EmployeeLabour employeeLabour){
	EmployeeLabour employeeLabourClone = new EmployeeLabour();

	employeeLabourClone.Id=employeeLabour.Id;
	employeeLabourClone.EmpId=employeeLabour.EmpId;
	employeeLabourClone.LabourTypeId=employeeLabour.LabourTypeId;

    employeeLabourClone.ApprovDate       = employeeLabour.ApprovDate;
    employeeLabourClone.ApprovUntilDate  = employeeLabour.ApprovUntilDate;
    employeeLabourClone.ApprovByEmpId    = employeeLabour.ApprovByEmpId;
    employeeLabourClone.ApprovLevel      = employeeLabour.ApprovLevel;

	return employeeLabourClone;
}

/************************************************** EmpShiftScheduleHdr *************************************************************/
public
EmpShiftScheduleHdr createEmpShiftScheduleHdr(){
	return new EmpShiftScheduleHdr();
}

public
EmpShiftScheduleHdrContainer createEmpShiftScheduleHdrContainer(){
	return new EmpShiftScheduleHdrContainer();
}

public
bool existsEmpShiftScheduleHdr(int id){
	try{
		EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = new EmpShiftScheduleHdrDataBase(dataBaseAccess);

		empShiftScheduleHdrDataBase.setId(id);

		return empShiftScheduleHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
void loadEmpShiftScheduleChilds(EmpShiftScheduleHdr empShiftScheduleHdr){        
    EmpShiftScheduleDtlDataBaseContainer empShiftScheduleDtlDataBaseContainer = new EmpShiftScheduleDtlDataBaseContainer(dataBaseAccess);
    empShiftScheduleDtlDataBaseContainer.readByHdr(empShiftScheduleHdr.Id);
        
    foreach(EmpShiftScheduleDtlDataBase empShiftScheduleDtlDataBase in empShiftScheduleDtlDataBaseContainer){
        empShiftScheduleHdr.EmpShiftScheduleDtlContainer.Add(objectDataBaseToObject(empShiftScheduleDtlDataBase));            
    }        

    //notes
    EmpShiftScheduleNotesDataBaseContainer empShiftScheduleNotesDataBaseContainer = new EmpShiftScheduleNotesDataBaseContainer(dataBaseAccess);
    empShiftScheduleNotesDataBaseContainer.readByHdr(empShiftScheduleHdr.Id);        
    foreach(EmpShiftScheduleNotesDataBase empShiftScheduleNotesDataBase in empShiftScheduleNotesDataBaseContainer){
        empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Add(objectDataBaseToObject(empShiftScheduleNotesDataBase));            
    }         
}

private
void writeEmpShiftScheduleChilds(EmpShiftScheduleHdr empShiftScheduleHdr){
    empShiftScheduleHdr.fillRedundances();
    
    foreach(EmpShiftScheduleDtl empShiftScheduleDtl in empShiftScheduleHdr.EmpShiftScheduleDtlContainer){        
        (objectToObjectDataBase(empShiftScheduleDtl)).write();
    }    

    foreach(EmpShiftScheduleNotes empShiftScheduleNotes in empShiftScheduleHdr.EmpShiftScheduleNotesContainer){        
        (objectToObjectDataBase(empShiftScheduleNotes)).write();
    } 
}

public 
void deleteEmpShiftScheduleChilds(int id){
    EmpShiftScheduleDtlDataBaseContainer empShiftScheduleDtlDataBaseContainer = new EmpShiftScheduleDtlDataBaseContainer(dataBaseAccess);
    empShiftScheduleDtlDataBaseContainer.deleteByHdr(id);    

    EmpShiftScheduleNotesDataBaseContainer empShiftScheduleNotesDataBaseContainer = new EmpShiftScheduleNotesDataBaseContainer(dataBaseAccess);
    empShiftScheduleNotesDataBaseContainer.deleteByHdr(id); 
}

public
EmpShiftScheduleHdr readEmpShiftScheduleHdr(int id){
	try{
		EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = new EmpShiftScheduleHdrDataBase(dataBaseAccess);
		empShiftScheduleHdrDataBase.setId(id);

		if (!empShiftScheduleHdrDataBase.read())
			return null;

		EmpShiftScheduleHdr empShiftScheduleHdr = this.objectDataBaseToObject(empShiftScheduleHdrDataBase);
        loadEmpShiftScheduleChilds(empShiftScheduleHdr);

		return empShiftScheduleHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = this.objectToObjectDataBase(empShiftScheduleHdr);
		empShiftScheduleHdrDataBase.update();

        deleteEmpShiftScheduleChilds(empShiftScheduleHdr.Id);
        writeEmpShiftScheduleChilds(empShiftScheduleHdr);

	    if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exc.Message,exc);
	}
}

public 
void writeEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = this.objectToObjectDataBase(empShiftScheduleHdr);
		empShiftScheduleHdrDataBase.write();

		empShiftScheduleHdr.Id=empShiftScheduleHdrDataBase.getId();        
        writeEmpShiftScheduleChilds(empShiftScheduleHdr);

		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exc.Message,exc);
	}
}

public
void deleteEmpShiftScheduleHdr(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = new EmpShiftScheduleHdrDataBase(dataBaseAccess);

        deleteEmpShiftScheduleChilds(id);
        
		empShiftScheduleHdrDataBase.setId(id);
		empShiftScheduleHdrDataBase.delete();

		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exc.Message,exc);
	}
}
        
public
EmpShiftScheduleHdrContainer readEmpShiftScheduleHdrByFilters(string sid,string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string snotes, string screatedByEmpId,bool bonlyHdr,int rows){
	try{
        EmpShiftScheduleHdrContainer            empShiftScheduleHdrContainer = new EmpShiftScheduleHdrContainer();
	    EmpShiftScheduleHdrDataBaseContainer    empShiftScheduleHdrDataBaseContainer = new EmpShiftScheduleHdrDataBaseContainer(dataBaseAccess);
	    empShiftScheduleHdrDataBaseContainer.readByFilters(sid, splant, fromDate, toDate, ishiftNum, sdept, snotes, screatedByEmpId, rows);
       
        foreach(EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase in  empShiftScheduleHdrDataBaseContainer){
            EmpShiftScheduleHdr empShiftScheduleHdr = objectDataBaseToObject(empShiftScheduleHdrDataBase);
            if (!bonlyHdr)
                loadEmpShiftScheduleChilds(empShiftScheduleHdr);        
            
            empShiftScheduleHdrContainer.Add(empShiftScheduleHdr);          
        }     

        loadEmployeeToEmpShiftScheduleHdrContainer(empShiftScheduleHdrContainer);

        return empShiftScheduleHdrContainer;
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

private
void loadEmployeeToEmpShiftScheduleHdrContainer(EmpShiftScheduleHdrContainer empShiftScheduleHdrContainer){
    Hashtable                               hashEmployeeIds= new Hashtable();
    ArrayList                               arrayEmployeeIds = new ArrayList();
    Employee                                employee = null;

    foreach(EmpShiftScheduleHdr empShiftScheduleHdr in  empShiftScheduleHdrContainer){
        if (!hashEmployeeIds.Contains(empShiftScheduleHdr.CreatedByEmpId)) { 
            employee = new Employee();
            employee.setId(empShiftScheduleHdr.CreatedByEmpId);
            hashEmployeeIds.Add(empShiftScheduleHdr.CreatedByEmpId, employee);
            arrayEmployeeIds.Add(empShiftScheduleHdr.CreatedByEmpId);
        }
    }

    //load employee names
    if (arrayEmployeeIds.Count > 0) { 
        EmployeeDataBaseContainer employeeDataBaseContainer = new EmployeeDataBaseContainer(dataBaseAccess);
        employeeDataBaseContainer.readByIds(arrayEmployeeIds);

        hashEmployeeIds.Clear();
        foreach(EmployeeDataBase employeeDataBase in employeeDataBaseContainer){
            if (!hashEmployeeIds.Contains(employeeDataBase.getEmpID())) { 
                hashEmployeeIds.Add(employeeDataBase.getEmpID(),objectDataBaseToObject(employeeDataBase));
            }
        }

        for (int i=0; i < empShiftScheduleHdrContainer.Count;i++){
            EmpShiftScheduleHdr empShiftScheduleHdr = (EmpShiftScheduleHdr)empShiftScheduleHdrContainer[i];
            if (hashEmployeeIds.Contains(empShiftScheduleHdr.CreatedByEmpId)) { 
                employee = (Employee)hashEmployeeIds[empShiftScheduleHdr.CreatedByEmpId];
                empShiftScheduleHdr.CreatedByEmpNameShow = !string.IsNullOrEmpty(employee.LastName) ? employee.LastName : employee.FirstName;
            }
        }
    }
}

private
EmpShiftScheduleHdr objectDataBaseToObject(EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase){
	EmpShiftScheduleHdr empShiftScheduleHdr = new EmpShiftScheduleHdr();

	empShiftScheduleHdr.Id=empShiftScheduleHdrDataBase.getId();
	empShiftScheduleHdr.Plant=empShiftScheduleHdrDataBase.getPlant();
	empShiftScheduleHdr.Date=empShiftScheduleHdrDataBase.getDate();
	empShiftScheduleHdr.ShiftNum=empShiftScheduleHdrDataBase.getShiftNum();
	empShiftScheduleHdr.Dept=empShiftScheduleHdrDataBase.getDept();
	empShiftScheduleHdr.Notes=empShiftScheduleHdrDataBase.getNotes();
	empShiftScheduleHdr.CreatedByEmpId=empShiftScheduleHdrDataBase.getCreatedByEmpId();

    empShiftScheduleHdr.PreShiftNote = empShiftScheduleHdrDataBase.getPreShiftNote();
    empShiftScheduleHdr.PostShiftNote = empShiftScheduleHdrDataBase.getPostShiftNote();

    return empShiftScheduleHdr;
}

private
EmpShiftScheduleHdrDataBase objectToObjectDataBase(EmpShiftScheduleHdr empShiftScheduleHdr){
	EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = new EmpShiftScheduleHdrDataBase(dataBaseAccess);
	empShiftScheduleHdrDataBase.setId(empShiftScheduleHdr.Id);
	empShiftScheduleHdrDataBase.setPlant(empShiftScheduleHdr.Plant);
	empShiftScheduleHdrDataBase.setDate(empShiftScheduleHdr.Date);
	empShiftScheduleHdrDataBase.setShiftNum(empShiftScheduleHdr.ShiftNum);
	empShiftScheduleHdrDataBase.setDept(empShiftScheduleHdr.Dept);
	empShiftScheduleHdrDataBase.setNotes(empShiftScheduleHdr.Notes);
	empShiftScheduleHdrDataBase.setCreatedByEmpId(empShiftScheduleHdr.CreatedByEmpId);

    empShiftScheduleHdrDataBase.setPreShiftNote(empShiftScheduleHdr.PreShiftNote);
    empShiftScheduleHdrDataBase.setPostShiftNote(empShiftScheduleHdr.PostShiftNote);

	return empShiftScheduleHdrDataBase;
}

public
EmpShiftScheduleHdr cloneEmpShiftScheduleHdr(EmpShiftScheduleHdr empShiftScheduleHdr){
	EmpShiftScheduleHdr empShiftScheduleHdrClone = new EmpShiftScheduleHdr();
    empShiftScheduleHdrClone.copy(empShiftScheduleHdr);
	
	return empShiftScheduleHdrClone;
}

public
EmpShiftScheduleDtl createEmpShiftScheduleDtl(){
	return new EmpShiftScheduleDtl();
}

public
EmpShiftScheduleDtlContainer createEmpShiftScheduleDtlContainer(){
	return new EmpShiftScheduleDtlContainer();
}

public
EmpShiftScheduleDtlView createEmpShiftScheduleDtlView(){
	return new EmpShiftScheduleDtlView();
}
 

private
EmpShiftScheduleDtl objectDataBaseToObject(EmpShiftScheduleDtlDataBase empShiftScheduleDtlDataBase){
	EmpShiftScheduleDtl empShiftScheduleDtl = new EmpShiftScheduleDtl();

	empShiftScheduleDtl.HdrId=empShiftScheduleDtlDataBase.getHdrId();
	empShiftScheduleDtl.Detail=empShiftScheduleDtlDataBase.getDetail();
	empShiftScheduleDtl.EmpId=empShiftScheduleDtlDataBase.getEmpId();
	empShiftScheduleDtl.MachId=empShiftScheduleDtlDataBase.getMachId();
	empShiftScheduleDtl.LabourTypeId=empShiftScheduleDtlDataBase.getLabourTypeId();
    empShiftScheduleDtl.LabMultiplier = empShiftScheduleDtlDataBase.getLabMultiplier();
    empShiftScheduleDtl.Absent = empShiftScheduleDtlDataBase.getAbsent();

	return empShiftScheduleDtl;
}

private
EmpShiftScheduleDtlDataBase objectToObjectDataBase(EmpShiftScheduleDtl empShiftScheduleDtl){
	EmpShiftScheduleDtlDataBase empShiftScheduleDtlDataBase = new EmpShiftScheduleDtlDataBase(dataBaseAccess);
	empShiftScheduleDtlDataBase.setHdrId(empShiftScheduleDtl.HdrId);
	empShiftScheduleDtlDataBase.setDetail(empShiftScheduleDtl.Detail);
	empShiftScheduleDtlDataBase.setEmpId(empShiftScheduleDtl.EmpId);
	empShiftScheduleDtlDataBase.setMachId(empShiftScheduleDtl.MachId);
	empShiftScheduleDtlDataBase.setLabourTypeId(empShiftScheduleDtl.LabourTypeId);
    empShiftScheduleDtlDataBase.setLabMultiplier(empShiftScheduleDtl.LabMultiplier);
    empShiftScheduleDtlDataBase.setAbsent(empShiftScheduleDtl.Absent);

	return empShiftScheduleDtlDataBase;
}

public
EmpShiftScheduleDtl cloneEmpShiftScheduleDtl(EmpShiftScheduleDtl empShiftScheduleDtl){
	EmpShiftScheduleDtl empShiftScheduleDtlClone = new EmpShiftScheduleDtl();
    empShiftScheduleDtlClone.copy(empShiftScheduleDtl);
	
	return empShiftScheduleDtlClone;
}

/****************************************************      EmpShiftScheduleNotes   *********************************************************/
public
EmpShiftScheduleNotes createEmpShiftScheduleNotes(){
	return new EmpShiftScheduleNotes();
}

public
EmpShiftScheduleNotesContainer createEmpShiftScheduleNotesContainer(){
	return new EmpShiftScheduleNotesContainer();
}

private
EmpShiftScheduleNotes objectDataBaseToObject(EmpShiftScheduleNotesDataBase empShiftScheduleNotesDataBase){
	EmpShiftScheduleNotes empShiftScheduleNotes = new EmpShiftScheduleNotes();

	empShiftScheduleNotes.HdrId=empShiftScheduleNotesDataBase.getHdrId();
	empShiftScheduleNotes.Detail=empShiftScheduleNotesDataBase.getDetail();
	empShiftScheduleNotes.Topic=empShiftScheduleNotesDataBase.getTopic();
	empShiftScheduleNotes.Notes=empShiftScheduleNotesDataBase.getNotes();

	return empShiftScheduleNotes;
}

private
EmpShiftScheduleNotesDataBase objectToObjectDataBase(EmpShiftScheduleNotes empShiftScheduleNotes){
	EmpShiftScheduleNotesDataBase empShiftScheduleNotesDataBase = new EmpShiftScheduleNotesDataBase(dataBaseAccess);
	empShiftScheduleNotesDataBase.setHdrId(empShiftScheduleNotes.HdrId);
	empShiftScheduleNotesDataBase.setDetail(empShiftScheduleNotes.Detail);
	empShiftScheduleNotesDataBase.setTopic(empShiftScheduleNotes.Topic);
	empShiftScheduleNotesDataBase.setNotes(empShiftScheduleNotes.Notes);

	return empShiftScheduleNotesDataBase;
}

public
EmpShiftScheduleNotes cloneEmpShiftScheduleNotes(EmpShiftScheduleNotes empShiftScheduleNotes){
	EmpShiftScheduleNotes empShiftScheduleNotesClone = new EmpShiftScheduleNotes();
    empShiftScheduleNotesClone.copy(empShiftScheduleNotes);
	
	return empShiftScheduleNotesClone;
}

public
void createDefaultsEmpShiftScheduleNotes(EmpShiftScheduleHdr empShiftScheduleHdr){
    try { 
        if (empShiftScheduleHdr!= null && empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Count < 1){
            string[][] items = EmpShiftScheduleHdr.getNotesTopics();

            for (int i = 0; i < items.Length; i++){
                EmpShiftScheduleNotes empShiftScheduleNotes = new EmpShiftScheduleNotes();
                empShiftScheduleNotes.Topic = items[i][1];
                empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Add(empShiftScheduleNotes);
            }
        }        
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

/*************************************************** *********************************************************************/
public
Hashtable readEmpShiftScheduleHdrSumViewByFilters(string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string screatedByEmpId,int rows){
	try{
        EmpShiftScheduleHdrSumViewContainer     empShiftScheduleHdrSumViewContainer = new EmpShiftScheduleHdrSumViewContainer();
        EmpShiftScheduleHdrSumView              empShiftScheduleHdrSumView=null;
        EmpShiftScheduleHdrSumView              empShiftScheduleHdrSumViewAux=null;

        Hashtable                               hashEmpByDateShif = new Hashtable();
        string                                  skey = "";
        DateTime                                monDate = DateTime.Now;
        DateTime                                sunDate = DateTime.Now;

        EmpShiftScheduleHdrSumViewDataBaseContainer empShiftScheduleHdrSumViewDataBaseContainer = new EmpShiftScheduleHdrSumViewDataBaseContainer(dataBaseAccess);
	    empShiftScheduleHdrSumViewDataBaseContainer.readByFilters(splant, fromDate, toDate, ishiftNum, sdept, screatedByEmpId, rows);

        foreach(EmpShiftScheduleHdrSumViewDataBase empShiftScheduleHdrSumViewDataBase in  empShiftScheduleHdrSumViewDataBaseContainer){

            empShiftScheduleHdrSumViewAux = objectDataBaseToObject(empShiftScheduleHdrSumViewDataBase);

            DateUtil.getPriorMondayNextSundayFromDate(empShiftScheduleHdrSumViewAux.Date,out monDate,out sunDate);
            skey = DateUtil.getDateRepresentation(monDate,DateUtil.MMDDYYYY) + Constants.DEFAULT_SEP + empShiftScheduleHdrSumViewAux.ShiftNum; 

            if (hashEmpByDateShif.Contains(skey)) { 
                empShiftScheduleHdrSumView = (EmpShiftScheduleHdrSumView)hashEmpByDateShif[skey];
                empShiftScheduleHdrSumView.EmployeeCount = empShiftScheduleHdrSumView.EmployeeCount + empShiftScheduleHdrSumViewAux.EmployeeCount;
            }else
                hashEmpByDateShif.Add(skey, empShiftScheduleHdrSumViewAux);
        }
    	
	    return hashEmpByDateShif;

	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

public
EmpShiftScheduleHdrSumView createEmpShiftScheduleHdrSumView(){
	return new EmpShiftScheduleHdrSumView();    
}

public
EmpShiftScheduleHdrSumViewContainer createEmpShiftScheduleHdrSumViewContainer(){
	return new EmpShiftScheduleHdrSumViewContainer();
}

private
EmpShiftScheduleHdrSumView objectDataBaseToObject(EmpShiftScheduleHdrSumViewDataBase empShiftScheduleHdrSumViewDataBase){
	EmpShiftScheduleHdrSumView empShiftScheduleHdrSumView = new EmpShiftScheduleHdrSumView();

	empShiftScheduleHdrSumView.Date         = empShiftScheduleHdrSumViewDataBase.getDate();
	empShiftScheduleHdrSumView.ShiftNum     = empShiftScheduleHdrSumViewDataBase.getShiftNum();
	empShiftScheduleHdrSumView.EmployeeCount= empShiftScheduleHdrSumViewDataBase.getEmployeeCount();
	
	return empShiftScheduleHdrSumView;
}

private
EmpShiftScheduleHdrSumViewDataBase objectToObjectDataBase(EmpShiftScheduleHdrSumView empShiftScheduleHdrSumView){
	EmpShiftScheduleHdrSumViewDataBase empShiftScheduleHdrSumViewDataBase = new EmpShiftScheduleHdrSumViewDataBase(dataBaseAccess);
    
	empShiftScheduleHdrSumViewDataBase.setDate(empShiftScheduleHdrSumView.Date);
	empShiftScheduleHdrSumViewDataBase.setShiftNum(empShiftScheduleHdrSumView.ShiftNum);
	empShiftScheduleHdrSumViewDataBase.setEmployeeCount(empShiftScheduleHdrSumView.EmployeeCount);
	
	return empShiftScheduleHdrSumViewDataBase;
}

public
EmpShiftScheduleHdrSumView cloneEmpShiftScheduleHdrSumView(EmpShiftScheduleHdrSumView empShiftScheduleHdrSumView){
	EmpShiftScheduleHdrSumView empShiftScheduleHdrSumViewClone = new EmpShiftScheduleHdrSumView();

	empShiftScheduleHdrSumViewClone.Date= empShiftScheduleHdrSumView.Date;
	empShiftScheduleHdrSumViewClone.ShiftNum= empShiftScheduleHdrSumView.ShiftNum;
	empShiftScheduleHdrSumViewClone.EmployeeCount= empShiftScheduleHdrSumView.EmployeeCount;
	
	return empShiftScheduleHdrSumViewClone;
}

/************************************************** EmpShiftScheduleReportView *****************************************************************/
public
EmpShiftScheduleReportView createEmpShiftScheduleReportView(){
	return new EmpShiftScheduleReportView();
}

public
EmpShiftScheduleReportViewContainer createEmpShiftScheduleReportViewContainer(){
	return new EmpShiftScheduleReportViewContainer();
}

public
EmpShiftScheduleReportTransformView createEmpShiftScheduleReportTransformView(){
	return new EmpShiftScheduleReportTransformView();
}

public
EmpShiftScheduleReportTransformViewContainer createEmpShiftScheduleReportTransformViewContainer(){
	return new EmpShiftScheduleReportTransformViewContainer();
}

private
EmpShiftScheduleReportView objectDataBaseToObject(EmpShiftScheduleReportViewDataBase empShiftScheduleReportViewDataBase){
	EmpShiftScheduleReportView empShiftScheduleReportView = new EmpShiftScheduleReportView();

	empShiftScheduleReportView.Id=empShiftScheduleReportViewDataBase.getId();
	empShiftScheduleReportView.Detail=empShiftScheduleReportViewDataBase.getDetail();
	empShiftScheduleReportView.Dept=empShiftScheduleReportViewDataBase.getDept();
	empShiftScheduleReportView.ShiftNum=empShiftScheduleReportViewDataBase.getShiftNum();
	empShiftScheduleReportView.EmpId=empShiftScheduleReportViewDataBase.getEmpId();
	empShiftScheduleReportView.FirstName=empShiftScheduleReportViewDataBase.getFirstName();
	empShiftScheduleReportView.LastName=empShiftScheduleReportViewDataBase.getLastName();
	empShiftScheduleReportView.MachId=empShiftScheduleReportViewDataBase.getMachId();
	empShiftScheduleReportView.Mach=empShiftScheduleReportViewDataBase.getMach();
    empShiftScheduleReportView.MachDesc = empShiftScheduleReportViewDataBase.getMachDesc();
    empShiftScheduleReportView.Priority  =empShiftScheduleReportViewDataBase.getPriority();

	return empShiftScheduleReportView;
}

private
EmpShiftScheduleReportViewDataBase objectToObjectDataBase(EmpShiftScheduleReportView empShiftScheduleReportView){
	EmpShiftScheduleReportViewDataBase empShiftScheduleReportViewDataBase = new EmpShiftScheduleReportViewDataBase(dataBaseAccess);
	empShiftScheduleReportViewDataBase.setId(empShiftScheduleReportView.Id);
	empShiftScheduleReportViewDataBase.setDetail(empShiftScheduleReportView.Detail);
	empShiftScheduleReportViewDataBase.setDept(empShiftScheduleReportView.Dept);
	empShiftScheduleReportViewDataBase.setShiftNum(empShiftScheduleReportView.ShiftNum);
	empShiftScheduleReportViewDataBase.setEmpId(empShiftScheduleReportView.EmpId);
	empShiftScheduleReportViewDataBase.setFirstName(empShiftScheduleReportView.FirstName);
	empShiftScheduleReportViewDataBase.setLastName(empShiftScheduleReportView.LastName);
	empShiftScheduleReportViewDataBase.setMachId(empShiftScheduleReportView.MachId);
	empShiftScheduleReportViewDataBase.setMach(empShiftScheduleReportView.Mach);
    empShiftScheduleReportViewDataBase.setMachDesc(empShiftScheduleReportView.MachDesc);
    empShiftScheduleReportViewDataBase.setPriority(empShiftScheduleReportView.Priority);

	return empShiftScheduleReportViewDataBase;
}

public
EmpShiftScheduleReportView cloneEmpShiftScheduleReportView(EmpShiftScheduleReportView empShiftScheduleReportView){
	EmpShiftScheduleReportView empShiftScheduleReportViewClone = new EmpShiftScheduleReportView();

	empShiftScheduleReportViewClone.Id=empShiftScheduleReportView.Id;
	empShiftScheduleReportViewClone.Detail=empShiftScheduleReportView.Detail;
	empShiftScheduleReportViewClone.Dept=empShiftScheduleReportView.Dept;
	empShiftScheduleReportViewClone.ShiftNum=empShiftScheduleReportView.ShiftNum;
	empShiftScheduleReportViewClone.EmpId=empShiftScheduleReportView.EmpId;
	empShiftScheduleReportViewClone.FirstName=empShiftScheduleReportView.FirstName;
	empShiftScheduleReportViewClone.LastName=empShiftScheduleReportView.LastName;
	empShiftScheduleReportViewClone.MachId=empShiftScheduleReportView.MachId;
	empShiftScheduleReportViewClone.Mach=empShiftScheduleReportView.Mach;
    empShiftScheduleReportViewClone.MachDesc=empShiftScheduleReportView.MachDesc;
    empShiftScheduleReportViewClone.Priority=empShiftScheduleReportView.Priority;

	return empShiftScheduleReportViewClone;
}

public
EmpShiftScheduleReportViewContainer readEmpShiftScheduleReportViewByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate,int ishiftNum,int rows){
	try{
        EmpShiftScheduleReportViewContainer         empShiftScheduleReportViewContainer = new EmpShiftScheduleReportViewContainer();       
        EmpShiftScheduleReportViewDataBaseContainer empShiftScheduleReportViewDataBaseContainer = new EmpShiftScheduleReportViewDataBaseContainer(dataBaseAccess);
        empShiftScheduleReportViewDataBaseContainer.readByFilters(splant, sdept, fromDate, toDate, ishiftNum, rows);

	    foreach(EmpShiftScheduleReportViewDataBase empShiftScheduleReportViewDataBase in  empShiftScheduleReportViewDataBaseContainer){
            EmpShiftScheduleReportView          empShiftScheduleReportView = objectDataBaseToObject(empShiftScheduleReportViewDataBase);
            empShiftScheduleReportViewContainer.Add(empShiftScheduleReportView);
        }
    	
	    return empShiftScheduleReportViewContainer;
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

public
EmpShiftScheduleReportViewContainer readMachEmpShiftScheduleReportViewByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate,int ishiftNum,string swithPriorityYesNo,int rows){
	try{
        EmpShiftScheduleReportViewContainer         empShiftScheduleReportViewContainer = new EmpShiftScheduleReportViewContainer();       
        EmpShiftScheduleReportViewDataBaseContainer empShiftScheduleReportViewDataBaseContainer = new EmpShiftScheduleReportViewDataBaseContainer(dataBaseAccess);
        empShiftScheduleReportViewDataBaseContainer.readMachineByFilters(splant, sdept, fromDate, toDate, ishiftNum, swithPriorityYesNo, rows);
        Hashtable                                   hashMachines = new Hashtable();
        EmpShiftScheduleReportView                  empShiftScheduleReportViewAux = null;       
        string                                      saux = "";
        
	    foreach(EmpShiftScheduleReportViewDataBase empShiftScheduleReportViewDataBase in  empShiftScheduleReportViewDataBaseContainer){
            EmpShiftScheduleReportView          empShiftScheduleReportView = objectDataBaseToObject(empShiftScheduleReportViewDataBase);

            if (hashMachines.Contains(empShiftScheduleReportView.MachId)){
                empShiftScheduleReportViewAux = (EmpShiftScheduleReportView)hashMachines[empShiftScheduleReportView.MachId];
                saux = empShiftScheduleReportView.EmpId + "-" + empShiftScheduleReportView.LastName;

                if (empShiftScheduleReportViewAux.EmpFullList.ToUpper().IndexOf(saux.ToUpper()) < 0)
                    empShiftScheduleReportViewAux.EmpFullList+= " , " + empShiftScheduleReportView.EmpId + "-" + empShiftScheduleReportView.LastName;
            }else{
                empShiftScheduleReportView.EmpFullList+= empShiftScheduleReportView.EmpId + "-" + empShiftScheduleReportView.LastName;
                if (string.IsNullOrEmpty(empShiftScheduleReportView.EmpId))
                    empShiftScheduleReportView.EmpFullList="";
        
                hashMachines.Add(empShiftScheduleReportView.MachId,empShiftScheduleReportView);
            }            
        }

        foreach (DictionaryEntry pair in hashMachines){
            empShiftScheduleReportViewContainer.Add((EmpShiftScheduleReportView)pair.Value);
            //Console.WriteLine("{0}={1}", pair.Key, pair.Value);
        }
    	
	    return empShiftScheduleReportViewContainer;
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}


} // class

} // namespace