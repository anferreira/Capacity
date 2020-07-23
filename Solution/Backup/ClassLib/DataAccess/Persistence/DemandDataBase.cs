using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class DemandDataBase : GenericDataBaseElement{

private decimal pr_id;

public
DemandDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.pr_id = reader.GetDecimal("pr_id");
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
void setPr_id(decimal pr_id){
	this.pr_id = pr_id;
}

public
decimal getPr_id(){
	return pr_id;
}

} // class

} // namespace