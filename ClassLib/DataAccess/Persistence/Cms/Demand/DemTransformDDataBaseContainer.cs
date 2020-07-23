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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemTransformDDataBaseContainer : GenericDataBaseContainer {

public
DemTransformDDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from demtransformd";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from demtransformd";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemTransformDDataBase demTransformDDataBase = new DemTransformDDataBase(dataBaseAccess);
		demTransformDDataBase.load(reader);
		this.Add(demTransformDDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table demtransformd";
	truncate(sql);
}

public
void readByHeader(int hdr){
	string sql ="select * from demtransformd where HdrId =" + NumberUtil.toString(hdr) +
                " order by HdrId,Detail";            
    read(sql);
}

public
void deleteByHeader(int hdr){
	string sql ="delete from demtransformd where HdrId =" + NumberUtil.toString(hdr);            
    delete(sql);
}

} // class
} // package