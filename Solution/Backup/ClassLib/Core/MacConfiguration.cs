using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]	
public class MacConfiguration : MarshalByRefObject{

private string plt;
private string dept;
private string cfg;
private string des1;
private string Set;
private decimal totalHrs;
private decimal totalHrsPr;
private string exact;

//private ArrayList machinesArray;

public MacConfiguration(){
	this.plt = "";
	this.dept = "";
	this.cfg = "";
	this.des1 = "";
	this.Set = "";
	this.totalHrs = 0.0M;
	this.totalHrsPr = 0.0M;
	this.exact = "";
//	this.machinesArray = null;
}

//Setters
public void setPlt (string plt){
    this.plt = plt;
}

public void setDept (string dept){
    this.dept = dept;
}

public void setCfg (string cfg){
    this.cfg = cfg;
}

public void setDes1 (string des1){
    this.des1 = des1;
}

public void setSet (string Set){
    this.Set = Set;
}

public void setTotalHrs (decimal totalHrs){
    this.totalHrs = totalHrs;
}

public void setTotalHrsPr (decimal totalHrsPr){
    this.totalHrsPr = totalHrsPr;
}

public void setExact (string exact){
    this.exact = exact;
}


//Getters
public string getPlt(){
    return plt;
}

public string getDept(){
    return dept;
}

public string getCfg(){
    return cfg;
}

public string getDes1(){
    return des1;
}

public string getSet(){
    return Set;
}

public decimal getTotalHrs(){
    return totalHrs;
}

public decimal getTotalHrsPr(){
    return totalHrsPr;
}

public string getExact(){
    return exact;
}



}//end class
}//end namespace
