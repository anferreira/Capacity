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
class CapShiftProfileSubDtlDataBaseContainer : GenericDataBaseContainer {

public
CapShiftProfileSubDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capshiftprofilesubdtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capshiftprofilesubdtl";
	if (searchText.Length > 0){
		sql += " where Type like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapShiftProfileSubDtlDataBase capShiftProfileSubDtlDataBase = new CapShiftProfileSubDtlDataBase(dataBaseAccess);
		capShiftProfileSubDtlDataBase.load(reader);
		this.Add(capShiftProfileSubDtlDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table capshiftprofilesubdtl";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql = "select * from capshiftprofilesubdtl " +                
                " where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from capshiftprofilesubdtl where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package