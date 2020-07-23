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
class InventoryObjectivePartDtlDataBaseContainer : GenericDataBaseContainer {

public
InventoryObjectivePartDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from inventoryobjectivepartdtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from inventoryobjectivepartdtl";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		InventoryObjectivePartDtlDataBase inventoryObjectivePartDtlDataBase = new InventoryObjectivePartDtlDataBase(dataBaseAccess);
		inventoryObjectivePartDtlDataBase.load(reader);
		this.Add(inventoryObjectivePartDtlDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table inventoryobjectivepartdtl";
	truncate(sql);
}

public
void readByHdr(int id,int detail){
	string sql = "select * from inventoryobjectivepartdtl where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail) + " order by HdrId,Detail";
    read(sql);
}

public
void readByHdrAll(int id){
	string sql ="select * from inventoryobjectivepartdtl where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDtl";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from inventoryobjectivepartdtl where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

public
void deleteByHdr(int id,int detail){
	string sql = "delete from inventoryobjectivepartdtl where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail);
    delete(sql);
}

} // class
} // package