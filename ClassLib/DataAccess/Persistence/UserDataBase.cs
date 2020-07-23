using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class UserDataBase : GenericDataBaseElement{

private int UserID;
private string LoginName;
private string Password;
private string FirstName;
private string LastName;
private string Type;
private string Email;
private string EmpId;

public 
UserDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from users" + 
		" where UserID = " + UserID.ToString();
    read(sql);		
}

public 
void readBylogin(){
    string sql = "select * from users where LoginName = '" + LoginName + "'";
    read(sql);		
}

public 
bool exists(){
	string sql = "select * from users where UserID = " + UserID.ToString();
    return exists(sql);				
}

public 
bool existsByLoginName(){
    string sql = "select * from users where LoginName = '" + LoginName + "'";
    return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.UserID = reader.GetInt32("UserID");
	this.LoginName = reader.GetString("LoginName");
	this.Password = reader.GetString("Password");

    try{ //AF commented some users fields
	    this.FirstName = reader.GetString("FirstName");
	    this.LastName = reader.GetString("LastName");
    }catch{}

	this.Type = reader.GetString("Type");

    try{
	    this.Email = reader.GetString("Email");
    }catch { }

    this.EmpId = reader.GetString("EmpId");
}

public override 
void write(){	
	string sql = "insert into users(LoginName, Password, FirstName, LastName, Type, Email,EmpId" +
	") values('" + 
		Converter.fixString(LoginName) + "', '" +
		Converter.fixString(Password) + "', '" +
		Converter.fixString(FirstName) + "', '" +
		Converter.fixString(LastName) + "', '" +
		Converter.fixString(Type) + "', '" +
		Converter.fixString(Email) + "', '" +                
		Converter.fixString(EmpId) + "')";     
    
    write(sql);
    this.UserID = dataBaseAccess.getLastId();                       			
}

public override 
void update(){	
    string sql = "update users set " +
	    "LoginName = '" + Converter.fixString(LoginName) + "', " +
	    "Password = '" + Converter.fixString(Password) + "', " +
	    "FirstName = '" + Converter.fixString(FirstName) + "', " +
	    "LastName = '" + Converter.fixString(LastName) + "', " +
	    "Type = '" + Converter.fixString(Type) + "', " +
	    "Email = '" + Converter.fixString(Email) + "', " +
        "EmpId = '" + Converter.fixString(EmpId) + "' " +
	    " where UserID = " + UserID.ToString();

    update(sql);		
}

public override 
void delete(){	
	string sql = "delete from userswhere UserID = " + UserID.ToString();
	delete(sql);	
}

public
void setUserID(int UserID){
	this.UserID = UserID;
}

public
void setLoginName(string LoginName){
	this.LoginName = LoginName;
}

public
void setPassword(string Password){
	this.Password = Password;
}

public
void setFirstName(string FirstName){
	this.FirstName = FirstName;
}

public
void setLastName(string LastName){
	this.LastName = LastName;
}

public
void setType(string Type){
	this.Type = Type;
}

public
void setEmail(string Email){
	this.Email = Email;
}

public
void setEmpId(string EmpId){
	this.EmpId = EmpId;
}

public
int getUserID(){
	return UserID;
}

public
string getLoginName(){
	return LoginName;
}

public
string getPassword(){
	return Password;
}

public
string getFirstName(){
	return FirstName;
}

public
string getLastName(){
	return LastName;
}

public
string getType(){
	return Type;
}

public
string getEmail(){
	return Email;
}

public
string getEmpId(){
	return EmpId;
}


} // class

} // namespace
