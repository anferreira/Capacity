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
class CapacityReqDataBaseContainer : GenericDataBaseContainer {

public
CapacityReqDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capacityreq";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capacityreq";
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
		CapacityReqDataBase capacityReqDataBase = new CapacityReqDataBase(dataBaseAccess);
		capacityReqDataBase.load(reader);
		this.Add(capacityReqDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capacityreq";
	truncate(sql);
}

public
void readByHdr(int id,int detail){
	string sql ="select * from capacityreq where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail);
    read(sql);
}

public
void readByHdrAll(int id){
	string sql ="select * from capacityreq where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}
        
public
void deleteByHdr(int id){
	string sql ="delete from capacityreq where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package