using System;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class EmployeeDataBaseContainer : GenericDataBaseContainer{


public
EmployeeDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
		employeeDataBase.load(reader);
		this.Add(employeeDataBase);
	}
}

#if OE_SYNC
public
void readToSynchronize(LastRevision lastRevision, int iquantity)
{
	try
	{
		string sql = "select * " +
			" from employee where " + 			
			" (DateUpdated >='"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'" +
			" and EmpId > '"	+ lastRevision.getFieldId() + "')" + 
			" or " +
			" (DateUpdated > '"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "')" +
			" order by DateUpdated,EmpId";

		sql = DBFormatter.selectTopRows (sql, Configuration.SqlRepositoryType, iquantity);
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
		{
			EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
			employeeDataBase.load(reader);			
			this.Add(employeeDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readToSynchronize>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readToSynchronize>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readToSynchronize> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readToSynchronize>: " + de.Message,de);
	}
}
#endif

public
void read(){	
    string sql = "select * from employee";
    read(sql);
}

public
void truncate(){	
	string sql = "delete from employee";
	truncate(sql);	
}

public
void readByDesc(string desc,int iTop){
	string sql = "select ";

	if (iTop > 0)
		sql+=" top "  + iTop.ToString();

	sql+=" * from employee ";
	sql+=" where firstName like '%"	+ Converter.fixString(desc) + "%'";
	sql+=" or lastName like '%"		+ Converter.fixString(desc) + "%'";
	sql+=" Order by firstName,lastName";		
    read(sql);
}

public 
void readByFilters(string sid,string firstName,string lastName,string status,int iassignShift,string sdept,int idftLabourTypeId,bool bhasDefLababour,int rows){	
	string sql = "select * from employee";

    if (!string.IsNullOrEmpty(sid))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("EmpID", sid);
    if (!string.IsNullOrEmpty(firstName))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FirstName", firstName);
    if (!string.IsNullOrEmpty(lastName))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("LastName", lastName);

    if (!string.IsNullOrEmpty(status))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("StatusCode",status);
    if (!string.IsNullOrEmpty(sdept))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DftDept", sdept);

    if (iassignShift >= 1)
        sql= DBFormatter.addWhereAndSentence(sql) + "AssignShift =" + NumberUtil.toString(iassignShift);
    if (idftLabourTypeId >= 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "DftLabourTypeId =" + NumberUtil.toString(idftLabourTypeId);
            
    if (bhasDefLababour)
        sql= DBFormatter.addWhereAndSentence(sql) + "DftLabourTypeId > 0";
         
	sql+= " order by FirstName,LastName";
    if (rows > 0)
	   sql = DBFormatter.selectTopRows(sql,rows);
 
	read(sql);		
}

public
void readByIds(ArrayList arrayIds){
	string sql = "select * from employee";

	if (arrayIds.Count > 0) { 
        string saux     ="";
        string sempId   ="";        
        for (int i=0; i < arrayIds.Count;i++){
            sempId = (string)arrayIds[i];
            saux+=  (i == 0 ? "":",") + "'" + Converter.fixString(sempId) + "'";
        }
        sql= DBFormatter.addWhereAndSentence(sql) + " empID in ( " + saux + ") ";
    }
    
	sql+= " Order by empID";		
    read(sql);
}


} // class

} // namespace