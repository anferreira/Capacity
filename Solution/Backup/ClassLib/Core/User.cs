using System;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class User : MarshalByRefObject{

private int userID;
private string loginName;
private string password;
private string firstName;
private string lastName;
private string type;
private string email;

UserSignin	userSignin = null;

public 
User(){

	userSignin = null;
}

public
void setUserID(int userID){
	this.userID = userID;
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
void setFirstName(string firstName){
	this.firstName = firstName;
}

public
void setLastName(string lastName){
	this.lastName = lastName;
}

public
void setType(string type){
	this.type = type;
}

public
void setEmail(string email){
	this.email = email;
}

public void setUserSignin(UserSignin userSignin)
{
	this.userSignin = userSignin;
}

public
int getUserID(){
	return userID;
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
string getFirstName(){
	return firstName;
}

public
string getLastName(){
	return lastName;
}

public
string getType(){
	return type;
}

public
string getEmail(){
	return email;
}

public UserSignin getUserSignin()
{
	return this.userSignin;
}

public void fillRedundances()
{
	if (this.userSignin!= null)
		this.userSignin.setUserId(this.getUserID());
}
} // class

} // namespace
