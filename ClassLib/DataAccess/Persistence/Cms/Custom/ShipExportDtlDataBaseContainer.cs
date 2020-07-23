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
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class ShipExportDtlDataBaseContainer : GenericDataBaseContainer {

public
ShipExportDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from shipexportdtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from shipexportdtl";
	if (searchText.Length > 0){
		sql += " where Site like '" + Converter.fixString(searchText) + "%'";
		sql += " or Release like '" + Converter.fixString(searchText) + "%'";
		sql += " or TimeStamp like '" + Converter.fixString(searchText) + "%'";
		sql += " or Action like '" + Converter.fixString(searchText) + "%'";
		sql += " or Ran like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ShipExportDtlDataBase shipExportDtlDataBase = new ShipExportDtlDataBase(dataBaseAccess);
		shipExportDtlDataBase.load(reader);
		this.Add(shipExportDtlDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table shipexportdtl";
	truncate(sql);
}

public
void readByHdr(string site,decimal bol,decimal bolItem){
	string sql = "select * from shipexportdtl " +
		" Site = '" + Converter.fixString(site) + "' and " +
		" Bol = " + NumberUtil.toString(bol) + " and " +
		" BolItem = " + NumberUtil.toString(bolItem) + "" +
        " order by Site,Bol,BolItem,Detail";
    read(sql);
}

public
void deleteByHdr(string site,decimal bol,decimal bolItem){
	string sql = "delete from shipexportdtl where " +
		" Site = '" + Converter.fixString(site) + "' and " +
		" Bol = " + NumberUtil.toString(bol) + " and " +
		" BolItem = " + NumberUtil.toString(bolItem);
    delete(sql);
}

private
string getSqlOcrrtExcludedUsers(string sfield){
    string sql = "";

    if (!string.IsNullOrEmpty(Configuration.DdataTransOcrrtExcludeUserIds))
        sql+= " " + sfield + " not in (" + Configuration.sqlListString(Configuration.DdataTransOcrrtExcludeUserIds) + ")";            
    
    return sql;
}

private
string getSqlOcriExcludedUsers(string sfield){
    string sql = "";

    if (!string.IsNullOrEmpty(Configuration.DdataTransOcritExcludeUserIds))
        sql+= " " + sfield + " not in (" + Configuration.sqlListString(Configuration.DdataTransOcritExcludeUserIds) + ")";            
    
    return sql;
}

public
void getSqlOCRRTByFilters(string sqlFilters){           
    string sql ="select " + getSelectRenamesFields() + " from " + getTablePrefix() + "OCRRT " + sqlFilters+
                " order by DC5ORD#,DC5ITM#,DC5RLNO,DC5TMSP";
    read(sql);
}

public
void getSqlOCRITByFilters(string sqlFilters){           
    string sqlSel = "'' Site,0 Bol,0 BolItem,0 Detail," +
                        "DC4TMSP TimeStamp,DC4ACTN Action,DC4ORD# as OrderNum,DC4ITM# Item,DC4RDAT RelDate,'' Release"+
                        " ,DC4QTOI RelQtyInvUnit,DC4QTSI QtyShippedInv,DC4QTBI QtyBackInv,DC4QDAT DateRequest,DC4SDAT ShipDate"+
                        " ,DC4RAN# Ran,DC4USR User ";
    string sexcludeUsers    = getSqlOcriExcludedUsers("DC4USR");

    string sql ="select " + sqlSel + " from " + getTablePrefix() + "OCRIT " + sqlFilters;
    if (!string.IsNullOrEmpty(sexcludeUsers))
        sql= DBFormatter.addWhereAndSentence(sql) + sexcludeUsers; //excluded users
    sql += " order by DC4ORD#,DC4ITM#,DC4TMSP";
    read(sql);
}

public
ArrayList getDifferentsReleasesOCRRTOnRangeDate(decimal order, decimal item, string srelease, int idays){    
    NotNullDataReader   reader  = null;
    ArrayList           array   = new ArrayList();
    try{
        string sqlOrder = getTablePrefix()  + "OCRRT where DC5ORD#=" + NumberUtil.toString(order) +  " and DC5ITM#=" + NumberUtil.toString(item);
        string sql      = "select distinct(DC5RLNO)  from " + sqlOrder +
                        " and (DC5SDAT >= ((select  max(DC5SDAT) from " + sqlOrder + " and DC5RLNO='" + Converter.fixString(srelease) + "') - 7 days) " +
                        " and  DC5SDAT <= (select  max(DC5SDAT)  from " + sqlOrder + " and DC5RLNO='" + Converter.fixString(srelease) + "') )";

		reader = dataBaseAccess.executeQuery(sql);
	    while (reader.Read()) { 
            array.Add(reader.GetString(0));            
	    }
	    return array;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDifferentsReleasesOCRRTOnRangeDate> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDifferentsReleasesOCRRTOnRangeDate> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getDifferentsReleasesOCRRTOnRangeDate>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getDifferentsReleasesOCRRTOnRangeDate> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

private
string getSelectRenamesFields(){
    string sqlSel = "'' Site,0 Bol,0 BolItem,0 Detail," +
                        "DC5TMSP TimeStamp,DC5ACTN Action,DC5ORD# as OrderNum,DC5ITM# Item,DC5RDAT RelDate,DC5RLNO Release"+
                        " ,DC5QTOI RelQtyInvUnit,DC5QTSI QtyShippedInv,DC5QTBI QtyBackInv,DC5QDAT DateRequest,DC5SDAT ShipDate"+
                        " ,DC5RAN# Ran ,DC5USR User ";

    return sqlSel;
}

public
void getSqlOCRITPairedByFilters(decimal order,decimal item,string sreleasae,int irows){       
    string sdate            = "CAST(DC5TMSP AS Date)";   
    string sqlOrder         = " DC5ORD#=" + NumberUtil.toString(order) + " and  DC5ITM#=" + NumberUtil.toString(item) + " ";
    string sqlRel           = " and DC5RLNO='" + Converter.fixString(sreleasae) + "' ";
    string sqlFromWherOrder = " from  " + getTablePrefix() + "OCRRT where  " + sqlOrder;               
    string sexcludeUsers    = getSqlOcrrtExcludedUsers("DC5USR");

    string sql      = "select " + getSelectRenamesFields() + sqlFromWherOrder + 
                        (string.IsNullOrEmpty(sexcludeUsers) ? "" : " and " + sexcludeUsers) + //excluded users
            //" and DC5SDAT <= (select max(DC5SDAT)  " + sqlFromWherOrder + sqlRel + " and DC5QTSI > 0) " +

            " and(DC5SDAT >= ((select max(DC5SDAT) " + sqlFromWherOrder + sqlRel + " and DC5QTSI > 0) - 35 days) " +
            " and DC5SDAT <= (select max(DC5SDAT)  " + sqlFromWherOrder + sqlRel + " and DC5QTSI > 0) ) " +
            " order by DC5TMSP desc";

    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);
    
    read(sql);
}

public
void getlOCRRTDifferentQtyForOrderItemRel(decimal order,decimal item,string srelease){
    string  sqlOrder        = " DC5ORD#=" + NumberUtil.toString(order) + " and DC5ITM#=" + NumberUtil.toString(item) + " and DC5RLNO = '" + Converter.fixString(srelease) + "' ";
    string  sqlFromWhere    = " from " + getTablePrefix() + "OCRRT where " + sqlOrder;
    string  sqlOrderBy      = "  order by DC5TMSP desc";
    string  sqlShipRecord   = " ( select DC5QTOI " + sqlFromWhere + sqlOrderBy;
    string  sqlShipRecord2  = " ( select DC5TMSP " + sqlFromWhere + sqlOrderBy;
    string  sql             = " select " + getSelectRenamesFields() + sqlFromWhere;
    string  sexcludeUsers   = getSqlOcrrtExcludedUsers("DC5USR");

    sql+=  (string.IsNullOrEmpty(sexcludeUsers) ? "" : " and " + sexcludeUsers);  //excluded users
    sql+= " and DC5QTOI <> " + DBFormatter.selectTopRows(sqlShipRecord,1)  + ")";
    sql+= " and DC5TMSP <= " + DBFormatter.selectTopRows(sqlShipRecord2,1) + ")";

    sql+= sqlOrderBy;
    sql= DBFormatter.selectTopRows(sql,1);
    read(sql);
}

public
void getlOCRRTShippedRecord(decimal order,decimal item,string srelease){
    string  sqlOrder        = " DC5ORD#=" + NumberUtil.toString(order) + " and DC5ITM#=" + NumberUtil.toString(item) + " and DC5RLNO = '" + Converter.fixString(srelease) + "' ";
    string  sqlFromWhere    = " from " + getTablePrefix() + "OCRRT where " + sqlOrder;
    string  sqlOrderBy      = "  order by DC5TMSP desc";
    string  sql             = "select " + getSelectRenamesFields()  + sqlFromWhere + " and DC5QTSI > 0 " + sqlOrderBy;

    sql = DBFormatter.selectTopRows(sql,1);
    read(sql);
}


} // class
} // package