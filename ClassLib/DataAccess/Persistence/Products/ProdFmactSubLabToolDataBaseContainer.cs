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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class ProdFmactSubLabToolDataBaseContainer : GenericDataBaseContainer {

public
ProdFmactSubLabToolDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from prodfmactsublabtool";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from prodfmactsublabtool";
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
		ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase = new ProdFmactSubLabToolDataBase(dataBaseAccess);
		prodFmactSubLabToolDataBase.load(reader);
		this.Add(prodFmactSubLabToolDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table prodfmactsublabtool";
	truncate(sql);
}

public
void deleteByHdr(int ihdrId){
	string sql = "delete from prodfmactsublabtool where HdrId=" + NumberUtil.toString(ihdrId);
	delete(sql);
}

public
void readByHdr(int ihdrId){
	string sql = "select * from prodfmactsublabtool where HdrId=" + NumberUtil.toString(ihdrId);
	read(sql);
}


} // class
} // package