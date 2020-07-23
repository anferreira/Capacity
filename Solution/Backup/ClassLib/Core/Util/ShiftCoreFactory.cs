using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class ShiftCoreFactory : ScheduleCoreFactory{

protected
ShiftCoreFactory() : base(){
}

/// <summary>
/// Return if exists a Shift
/// </summary>
/// <param name="SH_Shf"></param>
/// <param name="SH_Plt"></param>
/// <param name="SH_Dept"></param>
/// <returns></returns>
public
bool existsShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf){

    try{
	    ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
    	
		shiftHdrDataBase.setSH_Db(SH_Db);
		shiftHdrDataBase.setSH_Company(SH_Company);
		shiftHdrDataBase.setSH_Plt(SH_Plt);
		shiftHdrDataBase.setSH_Dept(SH_Dept);
		shiftHdrDataBase.setSH_Shf(SH_Shf);

	    return shiftHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

public
bool existsShift(string SH_Plt, string SH_Dept, string SH_Shf){

    try{
	    ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
    	
		shiftHdrDataBase.setSH_Db(Configuration.DftDataBase);
		shiftHdrDataBase.setSH_Company(Configuration.DftCompany);
		shiftHdrDataBase.setSH_Plt(SH_Plt);
		shiftHdrDataBase.setSH_Dept(SH_Dept);
		shiftHdrDataBase.setSH_Shf(SH_Shf);

	    return shiftHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/// <summary>
/// Read and return a Shift object
/// </summary>
/// <param name="SH_Shf"></param>
/// <param name="SH_ShfGrp"></param>
/// <param name="SH_Plt"></param>
/// <param name="SH_Dept"></param>
/// <param name="SH_ShfType"></param>
/// <param name="SH_ShfStatus"></param>
/// <returns></returns>
public
Shift readShift(string SH_Db, int SH_Company, string SH_Plt, string SH_Dept, string SH_Shf){
    try{
		ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
		
		shiftHdrDataBase.setSH_Db(SH_Db);
		shiftHdrDataBase.setSH_Company(SH_Company);
		shiftHdrDataBase.setSH_Plt(SH_Plt);
		shiftHdrDataBase.setSH_Dept(SH_Dept);
		shiftHdrDataBase.setSH_Shf(SH_Shf);
		shiftHdrDataBase.read();

		ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer = new ShiftDayDetailDataBaseContainer(dataBaseAccess);
		shiftDayDetailDataBaseContainer.setDb(SH_Db);
		shiftDayDetailDataBaseContainer.setCompany(SH_Company);
		shiftDayDetailDataBaseContainer.setPlt(SH_Plt);
		shiftDayDetailDataBaseContainer.setDept(SH_Dept);
		shiftDayDetailDataBaseContainer.setShf(SH_Shf);
		shiftDayDetailDataBaseContainer.readByPltDeptShf();

		ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		shiftDayDetailTransDataBaseContainer.setSDDT_Db(SH_Db);
		shiftDayDetailTransDataBaseContainer.setSDDT_Company(SH_Company);
		shiftDayDetailTransDataBaseContainer.setSDDT_Plt(SH_Plt);
		shiftDayDetailTransDataBaseContainer.setSDDT_Dept(SH_Dept);
		shiftDayDetailTransDataBaseContainer.setSDDT_Shf(SH_Shf);
		shiftDayDetailTransDataBaseContainer.readByPltDeptShf();

		Shift shift = new Shift();
		shift.setDb(shiftHdrDataBase.getSH_Db());
		shift.setCompany(shiftHdrDataBase.getSH_Company());
		shift.setPlt(shiftHdrDataBase.getSH_Plt());
		shift.setDept(shiftHdrDataBase.getSH_Dept());
		shift.setShf(shiftHdrDataBase.getSH_Shf());
		shift.setDes(shiftHdrDataBase.getSH_Des());
		shift.setShfType(shiftHdrDataBase.getSH_ShfType());
		shift.setShfStatus(shiftHdrDataBase.getSH_ShfStatus());
		shift.setRegTime(shiftHdrDataBase.getSH_RegTime());
		shift.setStrPeriod(shiftHdrDataBase.getSH_StrPeriod());
		shift.setEndPeriod(shiftHdrDataBase.getSH_EndPeriod());
		shift.setEmpNumTl(shiftHdrDataBase.getSH_EmpNumTl());
		shift.setMachNum(shiftHdrDataBase.getSH_MachNum());
		shift.setMachDirCost(shiftHdrDataBase.getSH_MachDirCost());
		shift.setLabDirCost(shiftHdrDataBase.getSH_LabDirCost());
		shift.setLabIndCost(shiftHdrDataBase.getSH_LabIndCost());
		shift.setLabTempCost(shiftHdrDataBase.getSH_LabTempCost());
		shift.setEmpNumD(shiftHdrDataBase.getSH_EmpNumD());
		shift.setEmpNumI(shiftHdrDataBase.getSH_EmpNumI());
		shift.setEmpNumT(shiftHdrDataBase.getSH_EmpNumT());

		shift.setShiftDayDetailDataBaseContainer(shiftDayDetailDataBaseContainer);
		shift.setShiftDayDetailTransDataBaseContainer(shiftDayDetailTransDataBaseContainer);

		return shift;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

public
Shift readShift(string SH_Plt, string SH_Dept, string SH_Shf){
    try{
		ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
		
		shiftHdrDataBase.setSH_Db(Configuration.DftDataBase);
		shiftHdrDataBase.setSH_Company(Configuration.DftCompany);
		shiftHdrDataBase.setSH_Plt(SH_Plt);
		shiftHdrDataBase.setSH_Dept(SH_Dept);
		shiftHdrDataBase.setSH_Shf(SH_Shf);
		shiftHdrDataBase.read();

		ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer = new ShiftDayDetailDataBaseContainer(dataBaseAccess);
		shiftDayDetailDataBaseContainer.setDb(Configuration.DftDataBase);
		shiftDayDetailDataBaseContainer.setCompany(Configuration.DftCompany);
		shiftDayDetailDataBaseContainer.setPlt(SH_Plt);
		shiftDayDetailDataBaseContainer.setDept(SH_Dept);
		shiftDayDetailDataBaseContainer.setShf(SH_Shf);
		shiftDayDetailDataBaseContainer.readByPltDeptShf();
		
		ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		shiftDayDetailTransDataBaseContainer.setSDDT_Db(Configuration.DftDataBase);
		shiftDayDetailTransDataBaseContainer.setSDDT_Company(Configuration.DftCompany);
		shiftDayDetailTransDataBaseContainer.setSDDT_Plt(SH_Plt);
		shiftDayDetailTransDataBaseContainer.setSDDT_Dept(SH_Dept);
		shiftDayDetailTransDataBaseContainer.setSDDT_Shf(SH_Shf);
		shiftDayDetailTransDataBaseContainer.readByPltDeptShf();

		Shift shift = new Shift();
		shift.setDb(shiftHdrDataBase.getSH_Db());
		shift.setCompany(shiftHdrDataBase.getSH_Company());
		shift.setPlt(shiftHdrDataBase.getSH_Plt());
		shift.setDept(shiftHdrDataBase.getSH_Dept());
		shift.setShf(shiftHdrDataBase.getSH_Shf());
		shift.setDes(shiftHdrDataBase.getSH_Des());
		shift.setShfType(shiftHdrDataBase.getSH_ShfType());
		shift.setShfStatus(shiftHdrDataBase.getSH_ShfStatus());
		shift.setRegTime(shiftHdrDataBase.getSH_RegTime());
		shift.setStrPeriod(shiftHdrDataBase.getSH_StrPeriod());
		shift.setEndPeriod(shiftHdrDataBase.getSH_EndPeriod());
		shift.setEmpNumTl(shiftHdrDataBase.getSH_EmpNumTl());
		shift.setMachNum(shiftHdrDataBase.getSH_MachNum());
		shift.setMachDirCost(shiftHdrDataBase.getSH_MachDirCost());
		shift.setLabDirCost(shiftHdrDataBase.getSH_LabDirCost());
		shift.setLabIndCost(shiftHdrDataBase.getSH_LabIndCost());
		shift.setLabTempCost(shiftHdrDataBase.getSH_LabTempCost());
		shift.setEmpNumD(shiftHdrDataBase.getSH_EmpNumD());
		shift.setEmpNumI(shiftHdrDataBase.getSH_EmpNumI());
		shift.setEmpNumT(shiftHdrDataBase.getSH_EmpNumT());

		shift.setShiftDayDetailDataBaseContainer(shiftDayDetailDataBaseContainer);
		shift.setShiftDayDetailTransDataBaseContainer(shiftDayDetailTransDataBaseContainer);

		return shift;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

private
Shift readShift(ShiftHdrDataBase shiftHdrDataBase){
    try{
		ShiftDayDetailDataBaseContainer shiftDayDetailDataBaseContainer = new ShiftDayDetailDataBaseContainer(dataBaseAccess);
		shiftDayDetailDataBaseContainer.setDb(shiftHdrDataBase.getSH_Db());
		shiftDayDetailDataBaseContainer.setCompany(shiftHdrDataBase.getSH_Company());
		shiftDayDetailDataBaseContainer.setPlt(shiftHdrDataBase.getSH_Plt());
		shiftDayDetailDataBaseContainer.setDept(shiftHdrDataBase.getSH_Dept());
		shiftDayDetailDataBaseContainer.setShf(shiftHdrDataBase.getSH_Shf());
		shiftDayDetailDataBaseContainer.readByPltDeptShf();
		
		ShiftDayDetailTransDataBaseContainer shiftDayDetailTransDataBaseContainer = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		shiftDayDetailTransDataBaseContainer.setSDDT_Db(shiftHdrDataBase.getSH_Db());
		shiftDayDetailTransDataBaseContainer.setSDDT_Company(shiftHdrDataBase.getSH_Company());
		shiftDayDetailTransDataBaseContainer.setSDDT_Plt(shiftHdrDataBase.getSH_Plt());
		shiftDayDetailTransDataBaseContainer.setSDDT_Dept(shiftHdrDataBase.getSH_Dept());
		shiftDayDetailTransDataBaseContainer.setSDDT_Shf(shiftHdrDataBase.getSH_Shf());
		shiftDayDetailTransDataBaseContainer.readByPltDeptShf();

		Shift shift = new Shift();
		shift.setDb(shiftHdrDataBase.getSH_Db());
		shift.setCompany(shiftHdrDataBase.getSH_Company());
		shift.setPlt(shiftHdrDataBase.getSH_Plt());
		shift.setDept(shiftHdrDataBase.getSH_Dept());
		shift.setShf(shiftHdrDataBase.getSH_Shf());
		shift.setDes(shiftHdrDataBase.getSH_Des());
		shift.setShfType(shiftHdrDataBase.getSH_ShfType());
		shift.setShfStatus(shiftHdrDataBase.getSH_ShfStatus());
		shift.setRegTime(shiftHdrDataBase.getSH_RegTime());
		shift.setStrPeriod(shiftHdrDataBase.getSH_StrPeriod());
		shift.setEndPeriod(shiftHdrDataBase.getSH_EndPeriod());
		shift.setEmpNumTl(shiftHdrDataBase.getSH_EmpNumTl());
		shift.setMachNum(shiftHdrDataBase.getSH_MachNum());
		shift.setMachDirCost(shiftHdrDataBase.getSH_MachDirCost());
		shift.setLabDirCost(shiftHdrDataBase.getSH_LabDirCost());
		shift.setLabIndCost(shiftHdrDataBase.getSH_LabIndCost());
		shift.setLabTempCost(shiftHdrDataBase.getSH_LabTempCost());
		shift.setEmpNumD(shiftHdrDataBase.getSH_EmpNumD());
		shift.setEmpNumI(shiftHdrDataBase.getSH_EmpNumI());
		shift.setEmpNumT(shiftHdrDataBase.getSH_EmpNumT());

		shift.setShiftDayDetailDataBaseContainer(shiftDayDetailDataBaseContainer);
		shift.setShiftDayDetailTransDataBaseContainer(shiftDayDetailTransDataBaseContainer);

		return shift;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/// <summary>
/// Read all shifts in a plant/departament
/// </summary>
/// <returns></returns>
public
ShiftContainer readShiftsByPltDept(string db, int company, string plt, string dept){
    try{
	    ShiftContainer shiftContainer = new ShiftContainer();

	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
		shiftHdrDataBaseContainer.setSH_Db(db);
		shiftHdrDataBaseContainer.setSH_Company(company);
		shiftHdrDataBaseContainer.setSH_Plt(plt);
		shiftHdrDataBaseContainer.setSH_Dept(dept);
	    shiftHdrDataBaseContainer.readByPltDept();
    	
	    for(IEnumerator en = shiftHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)en.Current;
    		
		    Shift shift = readShift(shiftHdrDataBase);
		    shiftContainer.Add(shift);
	    }
	    return shiftContainer;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/// <summary>
/// Read all shifts in a plant/departament
/// </summary>
/// <returns></returns>
public
ShiftContainer readShiftsByPltDept(string plt, string dept){
    try{
	    ShiftContainer shiftContainer = new ShiftContainer();

	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
		shiftHdrDataBaseContainer.setSH_Db(Configuration.DftDataBase);
		shiftHdrDataBaseContainer.setSH_Company(Configuration.DftCompany);
		shiftHdrDataBaseContainer.setSH_Plt(plt);
		shiftHdrDataBaseContainer.setSH_Dept(dept);
	    shiftHdrDataBaseContainer.readByPltDept();
    	
	    for(IEnumerator en = shiftHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)en.Current;
    		
		    Shift shift = readShift(shiftHdrDataBase);
		    shiftContainer.Add(shift);
	    }
	    return shiftContainer;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

public
ShiftContainer readShiftsByPlt(string plt){
    try{
	    ShiftContainer shiftContainer = new ShiftContainer();

	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
		shiftHdrDataBaseContainer.setSH_Db(Configuration.DftDataBase);
		shiftHdrDataBaseContainer.setSH_Company(Configuration.DftCompany);
		shiftHdrDataBaseContainer.setSH_Plt(plt);
	    shiftHdrDataBaseContainer.readByPlt();
    	
	    for(IEnumerator en = shiftHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)en.Current;
    		
		    Shift shift = readShift(shiftHdrDataBase);
		    shiftContainer.Add(shift);
	    }
	    return shiftContainer;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/// <summary>
/// Read all shifts in all plants/departaments
/// </summary>
/// <returns></returns>
public
ShiftContainer readShifts(){
    try{
	    ShiftContainer shiftContainer = new ShiftContainer();

	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
	    shiftHdrDataBaseContainer.read();
    	
	    for(IEnumerator en = shiftHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)en.Current;
    		
		    Shift shift = readShift(shiftHdrDataBase);
		    shiftContainer.Add(shift);
	    }
	    return shiftContainer;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/// <summary>
/// Write a Shift object to disk
/// </summary>
/// <param name="shift"></param>
public
void writeShift(Shift shift){
	try{
		if (!userHandleTransaction)
			this.dataBaseAccess.beginTransaction();

		ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
		shiftHdrDataBase.setSH_Db(shift.getDb());
		shiftHdrDataBase.setSH_Company(shift.getCompany());
		shiftHdrDataBase.setSH_Plt(shift.getPlt());
		shiftHdrDataBase.setSH_Dept(shift.getDept());
		shiftHdrDataBase.setSH_Shf(shift.getShf());
		shiftHdrDataBase.setSH_Des(shift.getDes());
		shiftHdrDataBase.setSH_ShfType(shift.getShfType());
		shiftHdrDataBase.setSH_ShfStatus(shift.getShfStatus());
		shiftHdrDataBase.setSH_RegTime(shift.getRegTime());
		shiftHdrDataBase.setSH_StrPeriod(shift.getStrPeriod());
		shiftHdrDataBase.setSH_EndPeriod(shift.getEndPeriod());
		shiftHdrDataBase.setSH_EmpNumTl(shift.getEmpNumTl());
		shiftHdrDataBase.setSH_MachNum(shift.getMachNum());
		shiftHdrDataBase.setSH_MachDirCost(shift.getMachDirCost());
		shiftHdrDataBase.setSH_LabDirCost(shift.getLabDirCost());
		shiftHdrDataBase.setSH_LabIndCost(shift.getLabIndCost());
		shiftHdrDataBase.setSH_LabTempCost(shift.getLabTempCost());
		shiftHdrDataBase.setSH_EmpNumD(shift.getEmpNumD());
		shiftHdrDataBase.setSH_EmpNumI(shift.getEmpNumI());
		shiftHdrDataBase.setSH_EmpNumT(shift.getEmpNumT());
		shiftHdrDataBase.write();

		shift.updateCrossReference();

		ShiftDayDetailDataBaseContainer writeShiftDayDetailDataBaseContainer = shift.getShiftDayDetailDataBaseContainer();
		ShiftDayDetailTransDataBaseContainer writeShiftDayDetailTransDataBaseContainer = shift.getShiftDayDetailTransDataBaseContainer();

		writeShiftDayDetailDataBaseContainer.write();
		writeShiftDayDetailTransDataBaseContainer.write();

		if (!this.userHandleTransaction)
			this.dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException)
	{
		this.dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		this.dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Update a Shift object
/// </summary>
/// <param name="shift"></param>
public
void updateShift(Shift shift){
	try{
		if (!userHandleTransaction)
			this.dataBaseAccess.beginTransaction();

		ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
		shiftHdrDataBase.setSH_Db(shift.getDb());
		shiftHdrDataBase.setSH_Company(shift.getCompany());
		shiftHdrDataBase.setSH_Plt(shift.getPlt());
		shiftHdrDataBase.setSH_Dept(shift.getDept());
		shiftHdrDataBase.setSH_Shf(shift.getShf());
		shiftHdrDataBase.setSH_Des(shift.getDes());
		shiftHdrDataBase.setSH_ShfType(shift.getShfType());
		shiftHdrDataBase.setSH_ShfStatus(shift.getShfStatus());
		shiftHdrDataBase.setSH_RegTime(shift.getRegTime());
		shiftHdrDataBase.setSH_StrPeriod(shift.getStrPeriod());
		shiftHdrDataBase.setSH_EndPeriod(shift.getEndPeriod());
		shiftHdrDataBase.setSH_EmpNumTl(shift.getEmpNumTl());
		shiftHdrDataBase.setSH_MachNum(shift.getMachNum());
		shiftHdrDataBase.setSH_MachDirCost(shift.getMachDirCost());
		shiftHdrDataBase.setSH_LabDirCost(shift.getLabDirCost());
		shiftHdrDataBase.setSH_LabIndCost(shift.getLabIndCost());
		shiftHdrDataBase.setSH_LabTempCost(shift.getLabTempCost());
		shiftHdrDataBase.setSH_EmpNumD(shift.getEmpNumD());
		shiftHdrDataBase.setSH_EmpNumI(shift.getEmpNumI());
		shiftHdrDataBase.setSH_EmpNumT(shift.getEmpNumT());
		shiftHdrDataBase.update();
		
		ShiftDayDetailDataBaseContainer delShiftDayDetailDataBaseContainer = new ShiftDayDetailDataBaseContainer(dataBaseAccess);
		delShiftDayDetailDataBaseContainer.setDb(shiftHdrDataBase.getSH_Db());
		delShiftDayDetailDataBaseContainer.setCompany(shiftHdrDataBase.getSH_Company());
		delShiftDayDetailDataBaseContainer.setPlt(shiftHdrDataBase.getSH_Plt());
		delShiftDayDetailDataBaseContainer.setDept(shiftHdrDataBase.getSH_Dept());
		delShiftDayDetailDataBaseContainer.setShf(shiftHdrDataBase.getSH_Shf());
		delShiftDayDetailDataBaseContainer.readByPltDeptShf();
		
		ShiftDayDetailTransDataBaseContainer delShiftDayDetailTransDataBaseContainer = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		delShiftDayDetailTransDataBaseContainer.setSDDT_Db(shiftHdrDataBase.getSH_Db());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Company(shiftHdrDataBase.getSH_Company());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Plt(shiftHdrDataBase.getSH_Plt());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Dept(shiftHdrDataBase.getSH_Dept());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Shf(shiftHdrDataBase.getSH_Shf());
		delShiftDayDetailTransDataBaseContainer.readByPltDeptShf();

		delShiftDayDetailTransDataBaseContainer.delete();
		delShiftDayDetailDataBaseContainer.delete();

		ShiftDayDetailDataBaseContainer writeShiftDayDetailDataBaseContainer = shift.getShiftDayDetailDataBaseContainer();
		ShiftDayDetailTransDataBaseContainer writeShiftDayDetailTransDataBaseContainer = shift.getShiftDayDetailTransDataBaseContainer();

		writeShiftDayDetailDataBaseContainer.write();
		writeShiftDayDetailTransDataBaseContainer.write();

		if (!this.userHandleTransaction)
			this.dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException)
	{
		this.dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		this.dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Delete a Shift object 
/// </summary>
/// <param name="SH_Shf"></param>
/// <param name="SH_ShfGrp"></param>
/// <param name="SH_Plt"></param>
/// <param name="SH_Dept"></param>
/// <param name="SH_ShfType"></param>
/// <param name="SH_ShfStatus"></param>
public
void deleteShift(string SH_Db, int SH_Company, string SH_Plt,
		string SH_Dept, string SH_Shf){

	try
	{
		if (!userHandleTransaction)
			this.dataBaseAccess.beginTransaction();

		ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
		shiftHdrDataBase.setSH_Db(SH_Db);
		shiftHdrDataBase.setSH_Company(SH_Company);
		shiftHdrDataBase.setSH_Plt(SH_Plt);
		shiftHdrDataBase.setSH_Dept(SH_Dept);
		shiftHdrDataBase.setSH_Shf(SH_Shf);

		ShiftDayDetailDataBaseContainer delShiftDayDetailDataBaseContainer = new ShiftDayDetailDataBaseContainer(dataBaseAccess);
		delShiftDayDetailDataBaseContainer.setDb(shiftHdrDataBase.getSH_Db());
		delShiftDayDetailDataBaseContainer.setCompany(shiftHdrDataBase.getSH_Company());
		delShiftDayDetailDataBaseContainer.setPlt(shiftHdrDataBase.getSH_Plt());
		delShiftDayDetailDataBaseContainer.setDept(shiftHdrDataBase.getSH_Dept());
		delShiftDayDetailDataBaseContainer.setShf(shiftHdrDataBase.getSH_Shf());
		delShiftDayDetailDataBaseContainer.readByPltDeptShf();
		
		ShiftDayDetailTransDataBaseContainer delShiftDayDetailTransDataBaseContainer = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		delShiftDayDetailTransDataBaseContainer.setSDDT_Db(shiftHdrDataBase.getSH_Db());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Company(shiftHdrDataBase.getSH_Company());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Plt(shiftHdrDataBase.getSH_Plt());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Dept(shiftHdrDataBase.getSH_Dept());
		delShiftDayDetailTransDataBaseContainer.setSDDT_Shf(shiftHdrDataBase.getSH_Shf());
		delShiftDayDetailTransDataBaseContainer.readByPltDeptShf();

		delShiftDayDetailTransDataBaseContainer.delete();
		delShiftDayDetailDataBaseContainer.delete();

		shiftHdrDataBase.delete();

		if (!this.userHandleTransaction)
			this.dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		this.dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		this.dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void deleteShift(string SH_Plt, string SH_Dept, string SH_Shf, 
		string SH_ShfGrp, string SH_ShfType, string SH_ShfStatus){

	throw new NujitException("Not Implemented!");
}

/// <summary>
/// Return all the Shift codes
/// </summary>
/// <returns></returns>
public
string[] getShiftCodesByPltDept(string db, int company, string plt, string dept){

    try{
	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
		shiftHdrDataBaseContainer.setSH_Db(db);
		shiftHdrDataBaseContainer.setSH_Company(company);
		shiftHdrDataBaseContainer.setSH_Plt(plt);
		shiftHdrDataBaseContainer.setSH_Dept(dept);
	    shiftHdrDataBaseContainer.readByPltDept();

	    string[] vec = new String[shiftHdrDataBaseContainer.Count];
	    int index = 0;
    	
	    IEnumerator iEnum = shiftHdrDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)iEnum.Current;
		    vec[index] = shiftHdrDataBase.getSH_Shf();
		    index++;
	    }
	    return vec;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/// <summary>
/// Return all the Shift codes
/// </summary>
/// <returns></returns>
public
string[] getShiftCodesByPltDept(string plt, string dept){

    try{
	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
		shiftHdrDataBaseContainer.setSH_Db(Configuration.DftDataBase);
		shiftHdrDataBaseContainer.setSH_Company(Configuration.DftCompany);
		shiftHdrDataBaseContainer.setSH_Plt(plt);
		shiftHdrDataBaseContainer.setSH_Dept(dept);
	    shiftHdrDataBaseContainer.readByPltDept();

	    string[] vec = new String[shiftHdrDataBaseContainer.Count];
	    int index = 0;
    	
	    IEnumerator iEnum = shiftHdrDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)iEnum.Current;
		    vec[index] = shiftHdrDataBase.getSH_Shf();
		    index++;
	    }
	    return vec;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

public 
bool existsShiftDayDetailTrans(string db, int company, string plt, string dept, string shift, DateTime startDate,DateTime endDate,int type){
	bool exit = false;

	try{
		ShiftDayDetailTransDataBaseContainer shiftDayDetailTrans = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		shiftDayDetailTrans.setSDDT_Db(db);
		shiftDayDetailTrans.setSDDT_Company(company);
		shiftDayDetailTrans.setSDDT_Plt(plt);
		shiftDayDetailTrans.setSDDT_Dept(dept);
		shiftDayDetailTrans.setSDDT_Shf(shift);
		if (type.Equals(1))
			shiftDayDetailTrans.readByPltDeptShf();
		else{
			shiftDayDetailTrans.readByPltDeptShfEndStartTime(startDate,endDate); 
		}
		if (shiftDayDetailTrans.Count > 0)
			exit = true;
		else 
			exit = false;
		return exit;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
bool existsShiftDayDetailTrans(string plt, string dept, string shift, DateTime startDate,DateTime endDate,int type){
	bool exit = false;

	try{
		ShiftDayDetailTransDataBaseContainer shiftDayDetailTrans = new ShiftDayDetailTransDataBaseContainer(dataBaseAccess);
		shiftDayDetailTrans.setSDDT_Db(Configuration.DftDataBase);
		shiftDayDetailTrans.setSDDT_Company(Configuration.DftCompany);
		shiftDayDetailTrans.setSDDT_Plt(plt);
		shiftDayDetailTrans.setSDDT_Dept(dept);
		shiftDayDetailTrans.setSDDT_Shf(shift);
		if (type.Equals(1))
			shiftDayDetailTrans.readByPltDeptShf();
		else{
			shiftDayDetailTrans.readByPltDeptShfEndStartTime(startDate,endDate); 
		}
		if (shiftDayDetailTrans.Count > 0)
			exit = true;
		else 
			exit = false;
		return exit;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getShiftHdrByDesc(string desc, string db, int company, string plt, string dept){

	try{

		ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
		shiftHdrDataBaseContainer.readByDesc(desc, db, company, plt, dept);

		string[][] items = new string[shiftHdrDataBaseContainer.Count][];

		int i = 0;
		for(IEnumerator en = shiftHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase) en.Current;

			string[] item = new String[6];
			item[0] = shiftHdrDataBase.getSH_Db();
			item[1] = shiftHdrDataBase.getSH_Company().ToString();
			item[2] = shiftHdrDataBase.getSH_Plt();
			item[3] = shiftHdrDataBase.getSH_Dept();
			item[4] = shiftHdrDataBase.getSH_Shf();
			item[5] = shiftHdrDataBase.getSH_Des();

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
Shift createShift(){
	return new Shift(new ShiftDayDetailDataBaseContainer(this.dataBaseAccess), 
		new ShiftDayDetailTransDataBaseContainer(this.dataBaseAccess));
}

} // class

} // namespace