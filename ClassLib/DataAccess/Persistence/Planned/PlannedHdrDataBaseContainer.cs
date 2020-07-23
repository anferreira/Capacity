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
class PlannedHdrDataBaseContainer : GenericDataBaseContainer {

public
PlannedHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from plannedhdr";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from plannedhdr";
	if (searchText.Length > 0){
		sql += " where Status like '" + Converter.fixString(searchText) + "%'";
		sql += " or Plant like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);
		plannedHdrDataBase.load(reader);
		this.Add(plannedHdrDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table plannedhdr";
	truncate(sql);
}

} // class
} // package