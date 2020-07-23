/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/UserSignin.cs,v $ 
*   $State: Exp $ 
*   $Log: UserSignin.cs,v $
*   Revision 1.2  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/12 19:35:25  aferreira
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class UserSignin : MarshalByRefObject
{

private int userId;
private string defDatabase;
private int defCompany;
private string defPlant;
private string defLabelPrinter;
private string defPrinter;
private int timeSignedIn;
private string securityProfile;

public
UserSignin(){
	this.userId = 0;
	this.defDatabase = "";
	this.defCompany = 0;
	this.defPlant = "";
	this.defLabelPrinter = "";
	this.defPrinter = "";
	this.timeSignedIn = 0;
	this.securityProfile = "";
}

public
UserSignin(
				int userId,
				string defDatabase,
				int defCompany,
				string defPlant,
				string defLabelPrinter,
				string defPrinter,
				int timeSignedIn,
				string securityProfile)
{
	this.userId = userId;
	this.defDatabase = defDatabase;
	this.defCompany = defCompany;
	this.defPlant = defPlant;
	this.defLabelPrinter = defLabelPrinter;
	this.defPrinter = defPrinter;
	this.timeSignedIn = timeSignedIn;
	this.securityProfile = securityProfile;
}

public
void setUserId(int userId){
	this.userId = userId;
}

public
void setDefDatabase(string defDatabase){
	this.defDatabase = defDatabase;
}

public
void setDefCompany(int defCompany){
	this.defCompany = defCompany;
}

public
void setDefPlant(string defPlant){
	this.defPlant = defPlant;
}

public
void setDefLabelPrinter(string defLabelPrinter){
	this.defLabelPrinter = defLabelPrinter;
}

public
void setDefPrinter(string defPrinter){
	this.defPrinter = defPrinter;
}

public
void setTimeSignedIn(int timeSignedIn){
	this.timeSignedIn = timeSignedIn;
}

public
void setSecurityProfile(string securityProfile){
	this.securityProfile = securityProfile;
}

public
int getUserId(){
	 return userId;
}

public
string getDefDatabase(){
	 return defDatabase;
}

public
int getDefCompany(){
	 return defCompany;
}

public
string getDefPlant(){
	 return defPlant;
}

public
string getDefLabelPrinter(){
	 return defLabelPrinter;
}

public
string getDefPrinter(){
	 return defPrinter;
}

public
int getTimeSignedIn(){
	 return timeSignedIn;
}

public
string getSecurityProfile(){
	 return securityProfile;
}

} // class

} // package