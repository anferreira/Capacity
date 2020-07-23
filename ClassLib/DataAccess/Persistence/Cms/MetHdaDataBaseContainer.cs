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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class MetHdaDataBaseContainer : GenericDataBaseContainer {

public
MetHdaDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	string sql = "select * from " + getTablePrefix() + "methda";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from methda";
	if (searchText.Length > 0){
		sql += " where ARTYPE like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARPLNT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARPART like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARDEPT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARRESC like '" + Converter.fixString(searchText) + "%'";
		sql += " or AROPNM like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARRTYP like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARREPP like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARUNIT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARPRC# like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARBK03 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARBK04 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT6 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT7 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT8 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUT9 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUTA like '" + Converter.fixString(searchText) + "%'";
		sql += " or ARFUTB like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		MetHdaDataBase metHdaDataBase = new MetHdaDataBase(dataBaseAccess);
		metHdaDataBase.load(reader);
		this.Add(metHdaDataBase);
	}
}


public
void truncate(){
	string sql = "truncate table methda";
	truncate(sql);
}

public
void readByFilters(string ARTYPE, string ARPART, decimal ARSEQ, string ARDEPT, string ARRESC, string ARREPP, string ABMACG){
    string sql = "select * from " + getTablePrefix() + "methda";  

    if (!string.IsNullOrEmpty(ARTYPE))
        sql = DBFormatter.addWhereAndSentence(sql) + " ARTYPE='" + Converter.fixString(ARTYPE) + "'";
    if (!string.IsNullOrEmpty(ARPART))
        sql = DBFormatter.addWhereAndSentence(sql) + " ARPART='" + Converter.fixString(ARPART) + "'";
    if (ARSEQ >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ARSEQ#=" + NumberUtil.toString(ARSEQ);

    if (!string.IsNullOrEmpty(ARDEPT))
        sql = DBFormatter.addWhereAndSentence(sql) + " ARDEPT='" + Converter.fixString(ARDEPT) + "'";
    if (!string.IsNullOrEmpty(ARRESC))
        sql = DBFormatter.addWhereAndSentence(sql) + " ARRESC='" + Converter.fixString(ARRESC) + "'";
    if (!string.IsNullOrEmpty(ARREPP))
        sql = DBFormatter.addWhereAndSentence(sql) + " ARREPP='" + Converter.fixString(ARREPP) + "'";

    if (!string.IsNullOrEmpty(ABMACG))
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (select ABMACG from " + getTablePrefix() + "resre " +
              " where ABDEPT=ARDEPT and ABRESC=ARRESC and ABMACG='" + Converter.fixString(ABMACG) + "')";

    sql += " order by ARPART,ARSEQ#";
    read(sql);
}

public
void readByFilters(string skeytGreaterThan,string splant,int rows){
    //PRIMARY KEY(  ARTYPE , ARPLNT , ARPART , ARSEQ# , ARLIN#  ) )       
    string sql      = "select * from "+ getTablePrefix()  + "methda";    
    string scastSeq = "CAST(" + getFieldDigit("ARSEQ") + " AS varchar(10))"; //3 len
    string scastLin = "CAST(" + getFieldDigit("ARLIN") + " AS varchar(10))"; //2 len        
    scastSeq = DBFormatter.lpad(scastSeq, 10,'0');
    scastLin = DBFormatter.lpad(scastLin, 10,'0');
    string skey     = "ARTYPE,ARPLNT,ARPART," + scastSeq + "," + scastLin;

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ARPLNT", splant);
           
    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);    
        string sfields = "Rtrim(ARTYPE)";                       sfields = DBFormatter.concat(sfields,"'" + Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields,"Rtrim(ARPLNT)");  sfields = DBFormatter.concat(sfields,"'" + Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields,"Rtrim(ARPART)");  sfields = DBFormatter.concat(sfields,"'" + Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastSeq);        sfields = DBFormatter.concat(sfields,"'" + Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastLin);        
        sql+= sfields + " > '" + skeytGreaterThan + "'";
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class
} // package