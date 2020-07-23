using System;

namespace Nujit.NujitERP.ClassLib.Core{


[Serializable]
public 
class Company : MarshalByRefObject{

private string		sdb;
private int			icompany;
private string		sname;
private string		sdescription;
private int			icurrOrderNum;
private int			icurrInvoiceNum;
private int			icurrBillLadNum;
private int			icurrQuoteNum;
private int			icurrCreditNoteNum;

public 
Company(){
	this.sdb="";
	this.icompany=0;
	this.sname="";
	this.sdescription="";
	this.icurrOrderNum=0;
	this.icurrInvoiceNum=0;
	this.icurrBillLadNum=0;
	this.icurrQuoteNum=0;
	this.icurrCreditNoteNum=0;
}

public 
Company(string sdb, int icompany, 
	string sname, string sdescription,
	int icurrOrderNum, int icurrInvoiceNum,
	int icurrBillLadNum, int icurrQuoteNum,
	int icurrCreditNoteNum){

	this.sdb = sdb;
	this.icompany = icompany;
	this.sname = sname;
	this.sdescription = sdescription;
	this.icurrOrderNum = icurrOrderNum;	
	this.icurrInvoiceNum = icurrInvoiceNum;
	this.icurrBillLadNum = icurrBillLadNum;
	this.icurrQuoteNum = icurrQuoteNum;
	this.icurrCreditNoteNum = icurrCreditNoteNum;	
}

public
void setDb(string sdb){
	this.sdb = sdb;
}

public
void setCompany(int icompany){
	this.icompany = icompany;
}


public
void setCurrOrderNum(int icurrOrderNum){
	this.icurrOrderNum = icurrOrderNum;
}

public
void setName(string sname){
	this.sname = sname;
}

public
void setDescription(string sdescription){
	this.sdescription = sdescription;
}

public
void setCurrInvoiceNum(int icurrInvoiceNum){
	this.icurrInvoiceNum = icurrInvoiceNum;
}

public
void setCurrBillLadNum(int icurrBillLadNum){
	this.icurrBillLadNum = icurrBillLadNum;
}

public
void setCurrQuoteNum(int icurrQuoteNum){
	this.icurrQuoteNum = icurrQuoteNum;
}

public
void setCurrCreditNoteNum(int icurrCreditNoteNum){
	this.icurrCreditNoteNum = icurrCreditNoteNum;
}

public
string getDb(){
	return sdb;
}

public
int getCompany(){
	return icompany;
}

public
int getCurrOrderNum(){
	return icurrOrderNum;
}

public
string getName(){
	return sname;
}

public
string getDescription(){
	return sdescription;
}

public
int getCurrInvoiceNum(){
	return icurrInvoiceNum;
}

public
int getCurrBillLadNum(){
	return icurrBillLadNum;
}

public
int getCurrQuoteNum(){
	return icurrQuoteNum;
}

public
int getCurrCreditNoteNum(){
	return icurrCreditNoteNum;
}

}//end Class

}//end 
