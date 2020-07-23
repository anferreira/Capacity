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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned { 

public
class PlannedLabourDataBaseContainer : GenericDataBaseContainer {

public
PlannedLabourDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from plannedlabour";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from plannedlabour";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PlannedLabourDataBase plannedLabourDataBase = new PlannedLabourDataBase(dataBaseAccess);
		plannedLabourDataBase.load(reader);
		this.Add(plannedLabourDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table plannedlabour";
	truncate(sql);
}

public
void readByHdr(int id,int detail){
	string sql = "select * from plannedlabour where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail) +
                " order by SubDetail";
    read(sql);
}

public
void readByHdrAll(int id){
	string sql = "select * from plannedlabour where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from plannedlabour where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

public
void deleteByReqHdr(int ihdr,int idtl){
	string sql = "delete from plannedlabour where HdrId=" + NumberUtil.toString(ihdr) +
                                          " and Detail="+ NumberUtil.toString(idtl);
    delete(sql);
}

} // class
} // package