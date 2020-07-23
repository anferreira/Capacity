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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityPartDtlDataBaseContainer : GenericDataBaseContainer {

public
CapacityPartDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capacitypartdtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capacitypartdtl";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapacityPartDtlDataBase capacityPartDtlDataBase = new CapacityPartDtlDataBase(dataBaseAccess);
		capacityPartDtlDataBase.load(reader);
		this.Add(capacityPartDtlDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capacitypartdtl";
	truncate(sql);
}

public
void readByHdr(int id,int detail){
	string sql ="select * from capacitypartdtl where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail);
    read(sql);
}

public
void readByHdrAll(int id){
	string sql ="select * from capacitypartdtl where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql ="delete from capacitypartdtl where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package