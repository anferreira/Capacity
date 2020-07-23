/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 03/10/2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/GeneralLedger/GLCurrencyDlyExc.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrencyDlyExc.cs,v $
*   Revision 1.2  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/03/11 03:15:33  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class GLCurrencyDlyExc : MarshalByRefObject{

private string db;
private int company;
private DateTime startingDate;
private DateTime endingDate;
private string currencyBase;
private decimal exchangeRate;
private string currencyCode;
private DateTime dateCreated;
private string userCreated;
private DateTime dateUpdated;
private string userUpdated;

public
GLCurrencyDlyExc(){
	this.db = "";
	this.company = 0;
	this.startingDate = DateUtil.MinValue;
	this.endingDate = DateUtil.MinValue;
	this.currencyBase = "";
	this.exchangeRate = 0;
	this.currencyCode = "";
	this.dateCreated = DateUtil.MinValue;
	this.userCreated = "";
	this.dateUpdated = DateUtil.MinValue;
	this.userUpdated = "";
}

public
GLCurrencyDlyExc(
				string db,
				int company,
				DateTime startingDate,
				DateTime endingDate,
				string currencyBase,
				decimal exchangeRate,
				string currencyCode,
				DateTime dateCreated,
				string userCreated,
				DateTime dateUpdated,
				string userUpdated)
{
	this.db = db;
	this.company = company;
	this.startingDate = startingDate;
	this.endingDate = endingDate;
	this.currencyBase = currencyBase;
	this.exchangeRate = exchangeRate;
	this.currencyCode = currencyCode;
	this.dateCreated = dateCreated;
	this.userCreated = userCreated;
	this.dateUpdated = dateUpdated;
	this.userUpdated = userUpdated;
}

public
void setDb(string db){
	this.db = db;
}

public
void setCompany(int company){
	this.company = company;
}

public
void setStartingDate(DateTime startingDate){
	this.startingDate = startingDate;
}

public
void setEndingDate(DateTime endingDate){
	this.endingDate = endingDate;
}

public
void setCurrencyBase(string currencyBase){
	this.currencyBase = currencyBase;
}

public
void setExchangeRate(decimal exchangeRate){
	this.exchangeRate = exchangeRate;
}

public
void setCurrencyCode(string currencyCode){
	this.currencyCode = currencyCode;
}

public
void setDateCreated(DateTime dateCreated){
	this.dateCreated = dateCreated;
}

public
void setUserCreated(string userCreated){
	this.userCreated = userCreated;
}

public
void setDateUpdated(DateTime dateUpdated){
	this.dateUpdated = dateUpdated;
}

public
void setUserUpdated(string userUpdated){
	this.userUpdated = userUpdated;
}

public
string getDb(){
	 return db;
}

public
int getCompany(){
	 return company;
}

public
DateTime getStartingDate(){
	 return startingDate;
}

public
DateTime getEndingDate(){
	 return endingDate;
}

public
string getCurrencyBase(){
	 return currencyBase;
}

public
decimal getExchangeRate(){
	 return exchangeRate;
}

public
string getCurrencyCode(){
	 return currencyCode;
}

public
DateTime getDateCreated(){
	 return dateCreated;
}

public
string getUserCreated(){
	 return userCreated;
}

public
DateTime getDateUpdated(){
	 return dateUpdated;
}

public
string getUserUpdated(){
	 return userUpdated;
}

} // class

} // package