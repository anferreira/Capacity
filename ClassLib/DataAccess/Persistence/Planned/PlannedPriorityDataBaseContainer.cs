/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned { 

public
class PlannedPriorityDataBaseContainer : GenericDataBaseContainer {

public
PlannedPriorityDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from plannedpriority";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from plannedpriority";
	if (searchText.Length > 0){
		sql += " where Planned like '" + Converter.fixString(searchText) + "%'";
		sql += " or Labour like '" + Converter.fixString(searchText) + "%'";
		sql += " or Part like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PlannedPriorityDataBase plannedPriorityDataBase = new PlannedPriorityDataBase(dataBaseAccess);
		plannedPriorityDataBase.load(reader);
		this.Add(plannedPriorityDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table plannedpriority";
	truncate(sql);
}

} // class
} // package