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
private int dftLabTaskId;
private decimal nonScheduledDT;

private string taskNameShow;

public 
Departament(){
}

public
Departament(string db, int company, string plt, string dept, string des1, decimal utilPer, string deptShort,int dftLabTaskId,decimal nonScheduledDT){
	this.db = db;
	this.company = company;
	this.plt = plt;
	this.dept = dept;
	this.des1 = des1;
	this.utilPer = utilPer;
	this.deptShort = deptShort;
    this.dftLabTaskId = dftLabTaskId;
    this.nonScheduledDT = nonScheduledDT;
    this.taskNameShow = "";
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

public
string Db {
	get { return db; }
	set { if (this.db != value){
			this.db = value;			
		}
	}
}

public
int Company {
	get { return company; }
	set { if (this.company != value){
			this.company = value;			
		}
	}
}

public
string Plt {
	get { return plt; }
	set { if (this.plt != value){
			this.plt = value;			
		}
	}
}

public
string Dept {
	get { return dept; }
	set { if (this.dept != value){
			this.dept = value;			
		}
	}
}

public
string Des1 {
	get { return des1; }
	set { if (this.des1 != value){
			this.des1 = value;			
		}
	}
}

public
decimal UtilPer {
	get { return utilPer; }
	set { if (this.utilPer != value){
			this.utilPer = value;			
		}
	}
}

public
string DeptShort {
	get { return deptShort; }
	set { if (this.deptShort != value){
			this.deptShort = value;			
		}
	}
}

public
int DftLabTaskId {
	get { return dftLabTaskId; }
	set { if (this.dftLabTaskId != value){
			this.dftLabTaskId = value;			
		}
	}
}

public
decimal NonScheduledDT {
	get { return nonScheduledDT; }
	set { if (this.nonScheduledDT != value){
			this.nonScheduledDT = value;			
		}
	}
}

public
string TaskNameShow {
	get { return taskNameShow; }
	set { if (this.taskNameShow != value){
			this.taskNameShow = value;			
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Departament)
		return  this.Plt.Equals(((Departament)obj).Plt) &&
                this.Dept.Equals(((Departament)obj).Dept);
	else
		return false;
}


} // class
} // namespace
