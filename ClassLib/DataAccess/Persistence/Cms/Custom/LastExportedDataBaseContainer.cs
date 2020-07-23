/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class LastExportedDataBaseContainer : GenericDataBaseContainer {

public
LastExportedDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from lastexported";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from lastexported";
	if (searchText.Length > 0){
		sql += " where Code like '" + Converter.fixString(searchText) + "%'";
		sql += " or LastId like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		LastExportedDataBase lastExportedDataBase = new LastExportedDataBase(dataBaseAccess);
		lastExportedDataBase.load(reader);
		this.Add(lastExportedDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table lastexported";
	truncate(sql);
}

} // class
} // package