using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class MetHdrDataBaseContainer : GenericDataBaseContainer{

public
MetHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		MetHdrDataBase metHdrDataBase = new MetHdrDataBase(dataBaseAccess);
		metHdrDataBase.load(reader);
		this.Add(metHdrDataBase);
	}
}

public
void read(){	
	string sql = "select * from ";
		
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		sql += Configuration.CMSLibrary + ".";

		sql += "methdr order by AOPART, AOSEQ#";
	}else{
		sql += "methdr order by AOPART, AOSEQ";
	}

	read(sql);		
}

public
void truncate(){	
	string sql = "delete from methdr";
    truncate(sql);	
}

public
void readByFilters(string skeytGreaterThan,string splant,int rows){
    //PRIMARY KEY(AOTYPE, AOPLNT, AOPART, AOSEQ# , AOLIN# )         
    string sql      = "select * from "+ getTablePrefix()  + "methdr";    
    string scastSeq = "CAST(" + getFieldDigit("AOSEQ") + " AS varchar(10))"; //3 len
    string scastLin = "CAST(" + getFieldDigit("AOLIN") + " AS varchar(10))"; //2 len
    scastSeq = DBFormatter.lpad(scastSeq,10,'0');
    scastLin = DBFormatter.lpad(scastLin,10,'0');
    string skey     = "AOTYPE,AOPLNT,AOPART," + scastSeq + "," + scastLin; //AOSEQ#,AOLIN#

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("AOPLNT",splant);

    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);
        string sfields = "Rtrim(AOTYPE)";                       sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields,"Rtrim(AOPLNT)");  sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields,"Rtrim(AOPART)");  sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastSeq);        sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastLin);        
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