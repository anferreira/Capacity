/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/GeneralLedger/GLCurrency.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrency.cs,v $
*   Revision 1.3  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/03/11 20:28:06  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/11 03:28:12  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class GLCurrency : MarshalByRefObject
{

private string db;
private string currency;
private string description;

public
GLCurrency(){
	this.db = "";
	this.currency = "";
	this.description = "";
}

public
GLCurrency(
				string db,
				string currency,
				string description)
{
	this.db = db;
	this.currency = currency;
	this.description = description;
}

public
void setDb(string db){
	this.db = db;
}

public
void setCurrency(string currency){
	this.currency = currency;
}

public
void setDescription(string description){
	this.description = description;
}

public
string getDb(){
	 return db;
}

public
string getCurrency(){
	 return currency;
}

public
string getDescription(){
	 return description;
}

} // class

} // package