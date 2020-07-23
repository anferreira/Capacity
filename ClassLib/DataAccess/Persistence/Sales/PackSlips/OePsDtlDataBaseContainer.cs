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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips{


public
class OePsDtlDataBaseContainer : GenericDataBaseContainer {

public
OePsDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from oepsdtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from oepsdtl";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
		sql += " or CustPart like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		OePsDtlDataBase oePsDtlDataBase = new OePsDtlDataBase(dataBaseAccess);
		oePsDtlDataBase.load(reader);
		this.Add(oePsDtlDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table oepsdtl";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql = "select * from oepsdtl where HdrId=" + NumberUtil.toString(id) +                
                " order by Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from oepsdtl where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

} // class
} // package