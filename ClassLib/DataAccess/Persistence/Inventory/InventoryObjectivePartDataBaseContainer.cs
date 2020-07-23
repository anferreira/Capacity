/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class InventoryObjectivePartDataBaseContainer : GenericDataBaseContainer {

public
InventoryObjectivePartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from inventoryobjectivepart";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from inventoryobjectivepart";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
		sql += " or Master like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		InventoryObjectivePartDataBase inventoryObjectivePartDataBase = new InventoryObjectivePartDataBase(dataBaseAccess);
		inventoryObjectivePartDataBase.load(reader);
		this.Add(inventoryObjectivePartDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table inventoryobjectivepart";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql = "select * from inventoryobjectivepart where HdrId=" + NumberUtil.toString(id) + " order by HdrId,Detail";	
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from inventoryobjectivepart where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

} // class
} // package