using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
	class EmployeeCoreFactory : DiscountCoreFactory	{

public
EmployeeCoreFactory() : base(){
}

public 
void updateEmployee(Employee employee){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

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
		employeeDataBase.update();
		
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
		employeeDataBase.write();
		
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
Employee readEmployee(string id){
	
try
{
	EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
	employeeDataBase.setEmpID(id);
	if (!employeeDataBase.exists())
		return null;
	employeeDataBase.read();

	return new Employee(employeeDataBase.getEmpID(), employeeDataBase.getFirstName(), 
			employeeDataBase.getLastName(), employeeDataBase.getLoginName(),
			employeeDataBase.getPassword(), employeeDataBase.getStatusCode(),
			employeeDataBase.getDeptCode(), employeeDataBase.getPostion(),
			employeeDataBase.getCompanyExt(), employeeDataBase.getHomePhone(),
			employeeDataBase.getCellPhone(), employeeDataBase.getEmail(),
			employeeDataBase.getComment(), employeeDataBase.getStyleSheet(),
			employeeDataBase.getRowsPerPage(), employeeDataBase.getIsSalesRep(),
			employeeDataBase.getDateUpdated());
	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
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


} // class

} // namespace