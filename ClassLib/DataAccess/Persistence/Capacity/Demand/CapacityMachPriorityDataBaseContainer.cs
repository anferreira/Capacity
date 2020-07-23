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
class CapacityMachPriorityDataBaseContainer : GenericDataBaseContainer {

public
CapacityMachPriorityDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capacitymachpriority";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capacitymachpriority";
	if (searchText.Length > 0){
		sql += " where Planned like '" + Converter.fixString(searchText) + "%'";
		sql += " or Labour like '" + Converter.fixString(searchText) + "%'";
		sql += " or Part like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapacityMachPriorityDataBase capacityMachPriorityDataBase = new CapacityMachPriorityDataBase(dataBaseAccess);
		capacityMachPriorityDataBase.load(reader);
		this.Add(capacityMachPriorityDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table capacitymachpriority";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql =    "select * from capacitymachpriority where HdrId=" + NumberUtil.toString(id) +
                    " order by Priority";
	read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from capacitymachpriority where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

} // class
} // package