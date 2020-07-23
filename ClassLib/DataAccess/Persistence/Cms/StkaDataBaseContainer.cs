/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class StkaDataBaseContainer : GenericDataBaseContainer {

public
StkaDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
        StkaDataBase stkaDataBase = new StkaDataBase(dataBaseAccess);
        stkaDataBase.load(reader);
        this.Add(stkaDataBase);
    }
}

public
void read(){	
	string sql = "select * from " + getTablePrefix() + "stka";

	read(sql);		
}

public
void truncate(){	
    string sql = "delete from stka";
    truncate(sql);	
}

public
void readByFilters(string skeytGreaterThan,string splant,string status,int rows){
    string sql = "select * from "+ getTablePrefix()  + "stka";
    string skey= "V6PLNT,V6PART";
            
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("V6PLNT",splant);

    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + "V6STAT='" + status +"'";

    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);
        string sfields = "Rtrim(V6PLNT)";
        sfields = DBFormatter.concat(sfields, "Rtrim(V6PART)");
        sql+= sfields + " > '" + skeytGreaterThan + "'";
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class
} // package