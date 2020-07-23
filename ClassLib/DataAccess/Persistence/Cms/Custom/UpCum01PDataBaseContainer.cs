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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class UpCum01PDataBaseContainer : GenericDataBaseContainer {

public
UpCum01PDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix3()  +"upcum01p";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from " + getTablePrefix3()  +"upcum01p";
	if (searchText.Length > 0){
		sql += " where FEBCS# like '" + Converter.fixString(searchText) + "%'";
		sql += " or FESCS# like '" + Converter.fixString(searchText) + "%'";
		sql += " or FGCREL like '" + Converter.fixString(searchText) + "%'";
		sql += " or FEPLTC like '" + Converter.fixString(searchText) + "%'";
		sql += " or FGRAN# like '" + Converter.fixString(searchText) + "%'";
		sql += " or PYRAN like '" + Converter.fixString(searchText) + "%'";
		sql += " or USERAN like '" + Converter.fixString(searchText) + "%'";
		sql += " or SPTRPT like '" + Converter.fixString(searchText) + "%'";
		sql += " or TPLOC like '" + Converter.fixString(searchText) + "%'";
		sql += " or OZTRPT like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		UpCum01PDataBase upCum01PDataBase = new UpCum01PDataBase(dataBaseAccess);
		upCum01PDataBase.load(reader);
		this.Add(upCum01PDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table upcum01p";
	truncate(sql);
}

} // class
} // package