using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkMPDataBaseContainer : GenericDataBaseContainer{

public
StkMPDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		StkMPDataBase stkMPDataBase = new StkMPDataBase(dataBaseAccess);
		stkMPDataBase.load(reader);
		this.Add(stkMPDataBase);
	}
}

public
void read(){	
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "stkmp";

    read(sql);		
}

public
void truncate(){	
	string sql = "delete from stkmp";
    truncate(sql);	
}

public
void readByFilters(string savpartGreaterThan,string splant,int rows){
    string sql = "select * from "+ getTablePrefix()  + "stkmp";
            
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("AWDPLT",splant);

    if (!string.IsNullOrEmpty(savpartGreaterThan))
        sql = DBFormatter.addWhereAndSentence(sql) + " AWPART > '" + savpartGreaterThan + "'";

    sql+= " order by AWPART";
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class

} // namespace