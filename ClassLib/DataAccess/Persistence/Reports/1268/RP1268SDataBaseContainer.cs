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
using Nujit.NujitERP.ClassLib.ErpException;
using MySql.Data.MySqlClient;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Reports{

public
class RP1268SDataBaseContainer : GenericDataBaseContainer {

public
RP1268SDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from rp1268s";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from rp1268s";
	if (searchText.Length > 0){
		sql += " where MainMat like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public
void load(NotNullDataReader reader){
	while(reader.Read()){
		RP1268SDataBase rP1268SDataBase = new RP1268SDataBase(dataBaseAccess);
		rP1268SDataBase.load(reader);
		this.Add(rP1268SDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table rp1268s";
	truncate(sql);
}

public
void deleteExceptId(int id){
	string sql ="delete from " + getTablePrefix3() + "rp1268s " +
                " where HdrId <> " + NumberUtil.toString(id);
	delete(sql);
}

} // class
} // package