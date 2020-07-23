using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class SschDataBaseContainer : GenericDataBaseContainer{

public
SschDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "ssch";

    read(sql);	
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		SschDataBase sschDataBase = new SschDataBase(dataBaseAccess);
		sschDataBase.load(reader);
		this.Add(sschDataBase);
	}
}

public
void truncate(){	
	string sql = "delete from ssch";
    truncate(sql);	
}

public
void readByEqualFilters(string spart){
    string sql = "select * from " + getTablePrefix() + "ssch";

    if (!string.IsNullOrEmpty(spart)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "JYPART='" + spart + "'";
    }

    sql+= " order by JYDATE";
    //System.Windows.Forms.MessageBox.Show(sql);
    read(sql);    
}
               
public
void readByFilters(string skeytGreaterThan,int rows){
    //PRIMARY KEY(JYCODE , JYDATE , JYTIME , JYENTR)         
    string sql      = "select * from "+ getTablePrefix()  + "ssch";
    string sdate    = DBFormatter.convertDate("JYDATE","'YYYY-MM-DD'");                        
    string scastTime= "CAST(JYTIME AS varchar(10))"; //4 len
    string scastEntr= "CAST(JYENTR AS varchar(10))"; //3 len
    scastTime = DBFormatter.lpad(scastTime, 10,'0');        
    scastEntr = DBFormatter.lpad(scastEntr, 10,'0');        
    string skey     = "JYCODE,"+ sdate +","+ scastTime + "," + scastEntr;            
            
    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);
        string sfields = "Rtrim(JYCODE)";                   sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, sdate);       sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastTime);   sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastEntr);   sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");        
        sql+= sfields + " > '" + skeytGreaterThan + "'";                       
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

} // class

} // namespace