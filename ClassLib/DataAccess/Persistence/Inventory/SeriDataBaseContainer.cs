using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class SeriDataBaseContainer : GenericDataBaseContainer {

public
SeriDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    string sql = "select * from " + getTablePrefix() + "seri";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from seri";
	if (searchText.Length > 0){
		sql += " where HTPART like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTLOTN like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTJOBN like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTUNIT like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTCTNR like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTLBLT like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTSRC like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTMSTS like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTSTKL like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTBINL like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTSTS like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTWUNT like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFUT2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFUT3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFUT4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFUT5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFUT6 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTCORG like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTPSRN like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTRCLF like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTPLNT like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTHDRF like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTHDRS like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTSTRN like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTSUPS like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFU11 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFU12 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFU13 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFU14 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFU15 like '" + Converter.fixString(searchText) + "%'";
		sql += " or HTFU16 like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		SeriDataBase seriDataBase = new SeriDataBase(dataBaseAccess);
		seriDataBase.load(reader);
		this.Add(seriDataBase);
	}
}

public
void lookForCmsSeris(string spart,string spartStart,DateTime dateTime, string statusList,string slot,string suppSerial){
    string ediSeriScript = getTablePrefix() + "seri";

    string sql ="select * from " + ediSeriScript + " as ser ";

    if (!string.IsNullOrEmpty(spart)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "HTPART='" + spart + "'";
    }

    if (!string.IsNullOrEmpty(spartStart)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTPART", spartStart + "%");        
    }
    
    if (dateTime != DateUtil.MinValue)    {
        sql = DBFormatter.addWhereAndSentence(sql);
        sql +=  "(HTADAT >='" + DateUtil.getDateRepresentation(dateTime.AddDays(-15), DateUtil.YYYYMMDD).Replace('/', '-') + "'" +
                " and HTADAT <='" + DateUtil.getDateRepresentation(dateTime.AddDays(15), DateUtil.YYYYMMDD).Replace('/', '-') + "')";             
    }

    if (!string.IsNullOrEmpty(statusList)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "HTSTS in (" + statusList + ")";
    }

    if (!string.IsNullOrEmpty(slot)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "HTLOTN='" + slot + "'";
    }

    if (!string.IsNullOrEmpty(suppSerial)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "HTSUPS='" + suppSerial + "'";
    }

    if (!string.IsNullOrEmpty(spart) && !string.IsNullOrEmpty(statusList))
        sql+= " order by HTSERN desc,HTSUPS,HTLOTN";
    else
        sql+= " order by HTADAT desc";
    sql = DBFormatter.selectTopRows(sql,500);//just in case lot of records

    read(sql);
}

public
void readByFilters(string spart,string serialNum,string slot,string suppSerial,string smasterSerial, string splant, string stockLoc, DateTime startActivDate, DateTime endActivDate, string statusList,bool bcheckEDI870,string stradingPartner,int rows)
{
    string ediSeriScript = getTablePrefix() + "seri";
    string sqlSubQuery =     
    "select distinct(cref.COILPART) from " + getTablePrefix2()+ "edi870hdr as hdr," + getTablePrefix2()+ "edi870Dtl as dtl," + getTablePrefix2() + "Edi870Cref as cref "+    " where dtl.TNA = hdr.TNA and dtl.TPA = hdr.TPA and   dtl.TDA = hdr.TDA and dtl.TTA = hdr.TTA and "+    " hdr.HDRPOSTED <> 'Y' and   dtl.PART <> '' and cref.TPA=hdr.TPA and cref.BLANKPART=dtl.PART ";   
    string sql ="select * from " + ediSeriScript + " as ser ";
    
    if (!string.IsNullOrEmpty(spart)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTPART",spart);
    }

    if (!string.IsNullOrEmpty(serialNum)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("CAST(HTSERN AS CHAR(15))", serialNum);        
    }

    if (!string.IsNullOrEmpty(slot)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTLOTN", slot);
    }
    
    if (!string.IsNullOrEmpty(suppSerial)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTSUPS",suppSerial);
    }

    if (!string.IsNullOrEmpty(smasterSerial)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTMSTN", smasterSerial);
    }

    if (!string.IsNullOrEmpty(splant)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTPLNT",splant);
    } 

    if (!string.IsNullOrEmpty(stockLoc)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("HTSTKL", stockLoc);
    }

    if (startActivDate != DateUtil.MinValue){
        sql = DBFormatter.addWhereAndSentence(sql);

        if (endActivDate != DateUtil.MinValue)
            sql += "(";
        sql += "HTADAT >='" + DateUtil.getDateRepresentation(startActivDate, DateUtil.YYYYMMDD).Replace('/', '-') + "'";             
    }
    
    if (endActivDate != DateUtil.MinValue){
        sql = DBFormatter.addWhereAndSentence(sql);

        sql += "HTADAT <='" + DateUtil.getDateRepresentation(endActivDate, DateUtil.YYYYMMDD).Replace('/', '-') + "'";             
        if (startActivDate != DateUtil.MinValue)
            sql += ")";
    }

    if (!string.IsNullOrEmpty(statusList)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "HTSTS in (" + statusList + ")";
    }

    if (bcheckEDI870){
       if (!string.IsNullOrEmpty(stradingPartner)){
           sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery);
           sqlSubQuery += DBFormatter.equalLikeSql("hdr.TPA", stradingPartner);
        }

        sql = DBFormatter.addWhereAndSentence(sql);
        sql += " HTPART in (" + sqlSubQuery + ")";

    }

    sql+= " order by HTSERN desc";     
    
    if (rows > 0)
        sql = DBFormatter.selectTopRows(sql, rows);

    read(sql);
}

public
void truncate(){
	try{
		string sql = "delete from seri";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}
}

} // class
} // package