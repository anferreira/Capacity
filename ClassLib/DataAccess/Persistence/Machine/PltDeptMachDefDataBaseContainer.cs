/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines{

public
class PltDeptMachDefDataBaseContainer : GenericDataBaseContainer {

public
PltDeptMachDefDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	string sql = "select * from pltdeptmachdef";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from pltdeptmachdef";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PltDeptMachDefDataBase pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
		pltDeptMachDefDataBase.load(reader);
		this.Add(pltDeptMachDefDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table pltdeptmachdef";
	truncate(sql);
}

public
void readByMachIdIds(ArrayList arrayMachIds){
	string sql = "select * from pltdeptmachdef";

    if (arrayMachIds.Count > 0) {         
        sql+= " where MachId in (";
        string sids = "";
        for (int i=0; i < arrayMachIds.Count;i++){
            sids+= string.IsNullOrEmpty(sids) ? "":","; 
            sids+= ((int)arrayMachIds[i]).ToString(); 
        }
        sql+= sids + ")";
        read(sql);
    }
}

} // class
} // package