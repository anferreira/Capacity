using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class RewScrapDataBase : GenericDataBaseElement{

private string REW_Code;
private string REW_Des1;
private string REW_Des2;
private string REW_ScrRew;

public
RewScrapDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.REW_Code = reader.GetString("REW_Code");
	this.REW_Des1 = reader.GetString("REW_Des1");
	this.REW_Des2 = reader.GetString("REW_Des2");
	this.REW_ScrRew = reader.GetString("REW_ScrRew");
}

public override
void write(){
	throw new PersistenceException("Method not implemented");
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setREW_Code(string REW_Code){
	this.REW_Code = REW_Code;
}

public
void setREW_Des1(string REW_Des1){
	this.REW_Des1 = REW_Des1;
}

public
void setREW_Des2(string REW_Des2){
	this.REW_Des2 = REW_Des2;
}

public
void setREW_ScrRew(string REW_ScrRew){
	this.REW_ScrRew = REW_ScrRew;
}


public
string getREW_Code(){
	return REW_Code;
}

public
string getREW_Des1(){
	return REW_Des1;
}

public
string getREW_Des2(){
	return REW_Des2;
}

public
string getREW_ScrRew(){
	return REW_ScrRew;
}

} // class

} // namespace