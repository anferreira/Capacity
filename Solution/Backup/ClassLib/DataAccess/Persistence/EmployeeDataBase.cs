using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class EmployeeDataBase : GenericDataBaseElement{

private string empID;
private string firstName;
private string lastName;
private string loginName;
private string password;
private string statusCode;
private string deptCode;
private string postion;
private string companyExt;
private string homePhone;
private string cellPhone;
private string email;
private string comment;
private string styleSheet;
private int rowsPerPage;
private string	 sisSalesRep;
private DateTime dateUpdated;

public
EmployeeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.empID = reader.GetString("EmpID");
	this.firstName = reader.GetString("FirstName");
	this.lastName = reader.GetString("LastName");
	this.loginName = reader.GetString("LoginName");
	this.password = reader.GetString("Password");
	this.statusCode = reader.GetString("StatusCode");
	this.deptCode = reader.GetString("DeptCode");
	this.postion = reader.GetString("Postion");
	this.companyExt = reader.GetString("CompanyExt");
	this.homePhone = reader.GetString("HomePhone");
	this.cellPhone = reader.GetString("CellPhone");
	this.email = reader.GetString("Email");
	this.comment = reader.GetString("Comment");
	this.styleSheet = reader.GetString("StyleSheet");
	this.rowsPerPage = reader.GetInt16("rowsPerPage");
	this.sisSalesRep = reader.GetString("IsSalesRep");			
	this.dateUpdated = reader.GetDateTime("DateUpdated");
}

public override
void write(){
	try{
		string sql = "insert into Employee values ('" + 
			Converter.fixString(empID) + "', '" +
			Converter.fixString(firstName) + "', '" +
			Converter.fixString(lastName) + "', '" +
			Converter.fixString(loginName) + "', '" +
			Converter.fixString(password) + "', '" +
			Converter.fixString(statusCode) + "', '" +
			Converter.fixString(deptCode) + "', '" +
			Converter.fixString(postion) + "', '" +
			Converter.fixString(companyExt) + "', '" +
			Converter.fixString(homePhone) + "', '" +
			Converter.fixString(cellPhone) + "', '" +
			Converter.fixString(email) + "', '" +
			Converter.fixString(comment) + "', '" +
			Converter.fixString(styleSheet) + "', " +
			rowsPerPage.ToString() + ",'" +
			Converter.fixString(sisSalesRep) + "','" +
			DateUtil.getDateRepresentation(dateUpdated) + "')";

		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBase <write>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <write>: " + de.Message,de);
	}
}

public
void read(){
	try{
		string sql = "select * from employee where EmpID = '" + empID.ToString() + "'";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBase <read>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <read>: " + de.Message,de);
	}
}

public
bool exists(){
	try{
		string sql = "select * from employee where EmpID = '" + empID.ToString() + "'";

		bool returnValue = false;
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;
		reader.Close();
		
		return returnValue;
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBase <exists>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <exists>: " + de.Message,de);
	}
}

public
bool existsLogingPassw()
{
	try
	{
		string  sql = "select * from employee where";
				sql+= " LoginName='" + Converter.fixString(this.loginName) + "'" + " and ";
				sql+= " Password='"  + Converter.fixString(this.password)  + "'";				

		bool returnValue = false;
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
		{
			load(reader);
			returnValue = true;
		}
		reader.Close();
	
		return returnValue;
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <existsLogingPassw>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBase <existsLogingPassw>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsLogingPassw> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <existsLogingPassw>: " + de.Message,de);
	}
}

public override
void update(){
	try{
		string sql = "update employee set " + 
			"firstName = '" + Converter.fixString(firstName) + "', " +
			"lastName = '" + Converter.fixString(lastName) + "', " +
			"loginName = '" + Converter.fixString(loginName) + "', " +
			"password = '" + Converter.fixString(password) + "', " +
			"statusCode = '" + Converter.fixString(statusCode) + "', " +
			"deptCode = '" + Converter.fixString(deptCode) + "', " +
			"postion = '" + Converter.fixString(postion) + "', " +
			"companyExt = '" + Converter.fixString(companyExt) + "', " +
			"homePhone = '" + Converter.fixString(homePhone) + "', " +
			"cellPhone = '" + Converter.fixString(cellPhone) + "', " +
			"email = '" + Converter.fixString(email) + "', " +
			"comment = '" + Converter.fixString(comment) + "', " +
			"styleSheet = '" + Converter.fixString(styleSheet) + "', " +
			"rowsPerPage = " + rowsPerPage.ToString() + ", " +
			"isSalesRep = '" + Converter.fixString(sisSalesRep) + "', " +			
			"dateUpdated = '" + DateUtil.getDateRepresentation(dateUpdated) + 
		"' where empId = '"	+ Converter.fixString(empID) + "'";

		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBase <update>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <update>: " + de.Message,de);
	}
}

public override
void delete(){
	try{
		string sql = "insert into Employee where EmpID = '" + empID.ToString() + "'";
		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBase <delete>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBase <delete>: " + de.Message,de);
	}
}

public
string getEmpID(){
	return empID;
}

public
string getFirstName(){
	return firstName;
}

public
string getLastName(){
	return lastName;
}

public
string getLoginName(){
	return loginName;
}

public
string getPassword(){
	return password;
}

public
string getStatusCode(){
	return statusCode;
}

public
string getDeptCode(){
	return deptCode;
}

public
string getPostion(){
	return postion;
}

public
string getCompanyExt(){
	return companyExt;
}

public
string getHomePhone(){
	return homePhone;
}

public
string getCellPhone(){
	return cellPhone;
}

public
string getEmail(){
	return email;
}

public
string getComment(){
	return comment;
}

public
string getStyleSheet(){
	return styleSheet;
}

public
int getRowsPerPage(){
	return rowsPerPage;
}

public
string getIsSalesRep(){
	return sisSalesRep;
}

public
DateTime getDateUpdated(){
	return dateUpdated;
}


public
void setEmpID(string empID){
	this.empID = empID;
}

public
void setFirstName(string firstName){
	this.firstName = firstName;
}

public
void setLastName(string lastName){
	this.lastName = lastName;
}

public
void setLoginName(string loginName){
	this.loginName = loginName;
}

public
void setPassword(string password){
	this.password = password;
}

public
void setStatusCode(string statusCode){
	this.statusCode = statusCode;
}

public
void setDeptCode(string deptCode){
	this.deptCode = deptCode;
}

public
void setPostion(string postion){
	this.postion = postion;
}

public
void setCompanyExt(string companyExt){
	this.companyExt = companyExt;
}

public
void setHomePhone(string homePhone){
	this.homePhone = homePhone;
}

public
void setCellPhone(string cellPhone){
	this.cellPhone = cellPhone;
}

public
void setEmail(string email){
	this.email = email;
}

public
void setComment(string comment){
	this.comment = comment;
}

public
void setStyleSheet(string styleSheet){
	this.styleSheet = styleSheet;
}

public
void setRowsPerPage(int rowsPerPage){
	this.rowsPerPage = rowsPerPage;
}

public
void setIsSalesRep(string sisSalesRep){
	this.sisSalesRep = sisSalesRep;
}

public
void setDateUpdated(DateTime dateUpdated){
	this.dateUpdated = dateUpdated;
}


} // class

} // namespace