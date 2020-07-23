using System;

namespace Nujit.NujitERP.ClassLib.Core{


[Serializable]
public 
class Departament : MarshalByRefObject{

private string db;
private int company;
private string plt;
private string dept;
private string des1;
private decimal utilPer;
private string deptShort;

public 
Departament(){
}

public
Departament(string db, int company, string plt, string dept, string des1, decimal utilPer, string deptShort){
	this.db = db;
	this.company = company;
	this.plt = plt;
	this.dept = dept;
	this.des1 = des1;
	this.utilPer = utilPer;
	this.deptShort = deptShort;
}

public
	void setDb(string db)
{
	this.db = db;
}

public
	void setCompany(int company)
{
	this.company = company;
}

public
	void setPlt(string plt)
{
	this.plt = plt;
}

public
void setDept(string dept){
	this.dept = dept;
}

public
void setDes1(string des1){
	this.des1 = des1;
}

public
void setUtilPer(decimal utilPer){
	this.utilPer = utilPer;
}

public
void setDeptShort(string deptShort){
	this.deptShort = deptShort;
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
string getPlt(){
	return plt;
}

public
string getDept(){
	return dept;
}

public
string getDes1(){
	return des1;
}

public
decimal getUtilPer(){
	return utilPer;
}

public
string getDeptShort(){
	return deptShort;
}

} // class

} // namespace
