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
class PlannedReqDataBaseContainer : GenericDataBaseContainer {

public
PlannedReqDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from plannedreq";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from plannedreq";
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
		PlannedReqDataBase plannedReqDataBase = new PlannedReqDataBase(dataBaseAccess);
		plannedReqDataBase.load(reader);
		this.Add(plannedReqDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table plannedreq";
	truncate(sql);
}
        /*
        public
void readByHdr(int id,int detail,int subDetail,int subSubDetail){
	string sql = "select * from schedulematerialconsumpart where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail) +
                " and SubDetail=" + NumberUtil.toString(subDetail) +
                " and SubSubDetail=" + NumberUtil.toString(subSubDetail) +
                " order by SubSubSubDetail";
    read(sql);
}*/

public
void readByHdr(int id){
	string sql = "select * from plannedreq where HdrId=" + NumberUtil.toString(id) + " order by Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from plannedreq where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package