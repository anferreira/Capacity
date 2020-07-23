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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleMaterialConsumPartDataBaseContainer : GenericDataBaseContainer {

public
ScheduleMaterialConsumPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from schedulematerialconsumpart";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from schedulematerialconsumpart";
	if (searchText.Length > 0){
		sql += " where MatPart like '" + Converter.fixString(searchText) + "%'";
		sql += " or MatType like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleMaterialConsumPartDataBase scheduleMaterialConsumPartDataBase = new ScheduleMaterialConsumPartDataBase(dataBaseAccess);
		scheduleMaterialConsumPartDataBase.load(reader);
		this.Add(scheduleMaterialConsumPartDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table schedulematerialconsumpart";
	truncate(sql);
}

public
void readByHdrAll(int id){
	string sql ="select * from schedulematerialconsumpart where HdrId=" + NumberUtil.toString(id) +
                " order by  HdrId,Detail,SubDetail,SubSubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from schedulematerialconsumpart where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package