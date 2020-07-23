using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListHdrDataBaseContainer : GenericDataBaseContainer{

public
HotListHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    while(reader.Read()){
		HotListHdrDataBase hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
		hotListHdrDataBase.load(reader);
		this.Add(hotListHdrDataBase);
	}
}

public
void read(){
	string sql = "select * from hotlisthdr order by id";
    read(sql);		
}

public 
void truncate(){	
	string sql = "delete from hotlisthdr";
    truncate(sql);	
}

public
HotListHdrDataBase getLast(){
	if (Count == 0)
		return null;
	else
		return (HotListHdrDataBase)this[Count - 1];
}

public
void readLastHotListHdrDifferentsPlants(){
    string sql ="select h.* from hotlisthdr h, plt p " +
                " where h.HLR_Plant = p.P_Plt and h.id in (select max(h2.id)  from hotlisthdr h2  where h.HLR_Plant=h2.HLR_Plant) " +
                " order by h.HLR_HotlistRunDate desc";

    read(sql);
}

} // class

} // namespace