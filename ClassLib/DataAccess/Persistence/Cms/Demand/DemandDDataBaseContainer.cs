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
using System.Collections;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class DemandDDataBaseContainer : GenericDataBaseContainer {

public
DemandDDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    string sql = "select * from " + getTablePrefix2() + "demandd";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
    string sql = "select * from  " + getTablePrefix2() + "demandd";
	if (searchText.Length > 0){
		sql += " where Source like '" + Converter.fixString(searchText) + "%'";
		sql += " or TPartner like '" + Converter.fixString(searchText) + "%'";
		sql += " or RelNum like '" + Converter.fixString(searchText) + "%'";
		sql += " or BillTo like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipTo like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipLoc like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipLTUn like '" + Converter.fixString(searchText) + "%'";
		sql += " or Part like '" + Converter.fixString(searchText) + "%'";
		sql += " or CustPart like '" + Converter.fixString(searchText) + "%'";
		sql += " or CurShDoc like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemandDDataBase demandDDataBase = new DemandDDataBase(dataBaseAccess);

        try{
		    demandDDataBase.load(reader);
         }catch(System.Exception exception){
            System.Windows.Forms.MessageBox.Show("DemandDDataBase:load" + this.Count + "\n\n" + "Error:" + exception.Message);
		    throw new PersistenceException(exception.Message, exception);
	    }   

		this.Add(demandDDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table demandd";
	truncate(sql);
}

public
void read830862ByDates(string splant,DateTime startDate,DateTime endDate,string source="",decimal logFrom=0,decimal logTo=0,ArrayList arrayTPartner=null){
    string splantSql    = string.IsNullOrEmpty(splant) ? "" : (" and SMPLANT ='" + splant + "'");
    string sschPlantSql = string.IsNullOrEmpty(splant) ? "" : (" and JYPLNT ='" + splant + "'"); 
    string  sql         = "";
    int     icounter    = 0;

    sql ="select 0 as HdrId,0 as Detail ,'N' as Discard,query.* from ( " ;

    if (string.IsNullOrEmpty(source) || source.Equals(DemandD.SOURCE_830)) {
        icounter++;
        sql += 
            " select '830PLAN' as Source, " +
                " tr.SMTRPT as TPartner, tr.SMRDAT  as  RelDate,    tr.SMCREL as RelNum  " +
               " ,tr.SMCUST as BillTo, tr.SMLOCN  as ShipTo,tr.SMSTXL as ShipLoc, bcust.BVSLT as ShipLTim,bcust.BVSLTU as ShipLTUn " +
               " ,tr.SMPART as Part,    tr.SMCPT# as CustPart " +
              " ,tr.SMCCUM  as CurrCum,             tr.SMFABC  as FaAutCum,tr.SMMTLC  as MaAutCum " +
              " ,tr.SMSREF  as CurShDoc " +
              " ,rd.PLRDAT as SDate, rh.OZEDAT as EndDate " +
              " ,rd.PLQCUM as QtyCum,rd.PLQNET as AdjNQty " +
              " ,rd.PLTIMC as TimeCode,rd.PLADJN as NetQty" +
              " ,rh.OZKEYN as TrlpKeyId " +
              " ,rh.OZLOG# as LogNum " +
              
            " from " + getTablePrefix() + "TRLP as tr , " + getTablePrefix() + "RRLH  as rh, " + 
                       getTablePrefix() + "RRLD as rd , " + getTablePrefix() + "cust  as bcust " +
            " where  " +
            " tr.SMCKEY=rh.OZKEYN   and tr.SMCREL=rh.OZREL#    and " +
            " rh.OZKEYN=rd.PLKEYN   and rh.OZREL#=rd.PLREL# " +
            " and (rd.PLRDAT >= '" + DateUtil.getDateRepresentation(startDate) + "' " +
            " and rd.PLRDAT <= '" + DateUtil.getDateRepresentation(endDate) + "') " +
            " and bcust.BVCUST=tr.SMLOCN " +
            splantSql;

            if (logFrom > 0 || logTo > 0){
                sql+= " and (";
                if (logFrom > 0)
                    sql+= " OZLOG# >=" + logFrom;
                if (logTo > 0)
                    sql+= " and OZLOG# <=" + logTo;                    
                sql+= ")";
            }
    }

    if (string.IsNullOrEmpty(source) || source.Equals(DemandD.SOURCE_862)){
        if (icounter > 0)
            sql+= " union all ";
        icounter++;
        sql+= 
        " select '862SHIP' as Source, " +
            " tr.SMTRPT as TPartner, tr.SMRDAT  as  RelDate,    tr.SMCREL as RelNum " +
           " ,tr.SMCUST as BillTo, tr.SMLOCN  as ShipTo,tr.SMSTXL as ShipLoc, bcust.BVSLT as ShipLTim,bcust.BVSLTU as ShipLTUn " +
          " ,tr.SMPART as Part,    tr.SMCPT# as CustPart " +
          " ,tr.SMCCUM  as CurrCum,             tr.SMFABC  as FaAutCum,tr.SMMTLC  as MaAutCum " +
          " ,tr.SMSREF  as CurShDoc " +
          " ,jd.PYDATE as SDate,                      jd.PYEDAT as EndDate " +
          " ,jd.PYQCUM as QtyCum ,           jd.PYQTY as AdjNQty " +
          " ,'D' as TimeCode , jd.PYNQTY as NetQty" +
          " ,jh.SPKEYN as TrlpKeyId " +
          " ,jh.SPLOG# as LogNum " +

        " from " +  getTablePrefix() + "TRLP tr , " +   getTablePrefix() + "JITH jh , " + 
                    getTablePrefix() + "JITD as jd ," + getTablePrefix() + "cust  as bcust " +
        " where  " +

        " tr.SMCKEY=jh.SPKEYN"+
        " and tr.SMSREF=jh.SPREF#"+
        " and jh.SPKEYN=jd.PYKEYN" +
        " and jh.SPREF#=jd.PYREF#" +    
        //" tr.SMCKEY=jh.SPKEYN   and tr.SMCREL=jh.SPREL#   " +
        " and (jd.PYDATE >= '" + DateUtil.getDateRepresentation(startDate) + "' " +
        " and jd.PYDATE <= '" + DateUtil.getDateRepresentation(endDate) + "') " +   
        //" and jh.SPKEYN=jd.PYKEYN and jh.SPREF#=jd.PYREF# " +    
        " and bcust.BVCUST=tr.SMLOCN " +
        splantSql;

        if (logFrom > 0 || logTo > 0){
            sql+= " and (";
            if (logFrom > 0)
                sql+= " SPLOG# >=" + logFrom;
            if (logTo > 0)
                sql+= " SPLOG# <=" + logTo;         
            sql+= ")";                       
        }
    }

    if (string.IsNullOrEmpty(source) || source.Equals(DemandD.SOURCE_ORDER)){
        if (icounter > 0)
            sql+= " union all ";

        sql+=" select  'ORDER' as Source, " +
            " scust.BVTRDP as TPartner, s.JYDATE as RelDate,  '' as RelNum , " +
            " DCBCUS as BillTo, DCSCUS as ShipTo ,scust.BVDUNS as ShipLoc, scust.BVSLT as ShipLTim,scust.BVSLTU as ShipLTUn , " +
            " s.JYPART as Part, smm.AVCPT# as CustPart " +
            " , s.JYCUMQ as CurrCum, 0 as FaAutCum, 0 as MaAutCum " +
            " ,'' as CurShDoc " +
            " ,s.JYDATE as SDate, s.JYDATE as EndDate " +
            " ,0 as QtyCum, 0 as AdjNQty " +
            " ,'D' as TimeCode,JYSQTY as NetQty " +
            " ,0 as TrlpKeyId " +
            " ,0 as LogNum " +
            " from " + getTablePrefix() + "ssch as s left outer join "  + getTablePrefix() + "stkmm as smm on AVPART=s.JYPART , " 
                     + getTablePrefix() + "cust as bcust ,"             + getTablePrefix() + "cust as scust ,  " 
                     + getTablePrefix() + "ocrh as oh " +               
        " where " +
            " not exists(select * from " + getTablePrefix() + "trlp where SMORD#=s.JYORDR and SMITM#=s.JYITEM "+ splantSql +  ") " +
            " and s.JYORDR = oh.DCORD# " +
            " and bcust.BVCUST = oh.DCBCUS " +
            " and scust.BVCUST = oh.DCSCUS " +
            " and (s.JYDATE >= '" + DateUtil.getDateRepresentation(startDate) + "' " +
            " and s.JYDATE <= '" + DateUtil.getDateRepresentation(endDate) + "') " +
            sschPlantSql;
    }

    sql+=" ) as query ";

    if (arrayTPartner!= null && arrayTPartner.Count > 0)
        sql+= " where " + DBFormatter.getSqlInFieldLists("TPartner",arrayTPartner,true);
            
    sql+= " order by ShipTo,Part,SDate,Source desc";  // TPartner,RelNum,RelDate,Part ";

   // System.Windows.Forms.MessageBox.Show(sql);
	read(sql);    
}

public
void readByHdr(int id){
    string sql ="select * from  " + getTablePrefix2() + "demandd where HdrId=" + NumberUtil.toString(id)+
                " order by HdrId,Detail";
    
	read(sql);
}

public
void deleteByHdr(int id){
    string sql ="delete from  " + getTablePrefix2() + "demandd where HdrId=" + NumberUtil.toString(id);
    
	delete(sql);
}

public
ArrayList readDistinctTradingPartners(string splant,string source){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  =   "select TPartner,Max(RelDate) RelDate from demandd , demandh where HdrId=Id " +
                        " and Plant = '" + Converter.fixString(splant) + "'  and TPartner <> '' ";
        if (!string.IsNullOrEmpty(source))
            sql= DBFormatter.addWhereAndSentence(sql) + " Source='" + Converter.fixString(source) + "'";
        sql+=" group by TPartner order by TPartner";
        string[]item=new string[2];

		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read()){            		
            item=new string[2];
            item[0]= reader.GetString("TPartner");
            item[1]= DateUtil.getDateRepresentation(reader.GetDateTime("RelDate"),DateUtil.MMDDYYYY);

            arrayList.Add(item);
	    }        
	    
	    return arrayList;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctTradingPartners> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctTradingPartners> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctTradingPartners>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctTradingPartners> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readDistinctShipLoc(string splant, string source,string stpartner){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  = "select distinct(ShipLoc) from demandd , demandh where HdrId=Id " +
                      " and Plant = '" + Converter.fixString(splant) + "' and ShipLoc <> '' ";
        if (!string.IsNullOrEmpty(source))
            sql+= " and Source = '" + Converter.fixString(source) + "'";
        if (!string.IsNullOrEmpty(stpartner))
            sql+= " and TPartner = '" + Converter.fixString(stpartner) + "'";
        
        sql+= " order by ShipLoc";

		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read())            		        
            arrayList.Add(reader.GetString("ShipLoc"));	            
	    
	    return arrayList;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctShipLoc> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctShipLoc> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctShipLoc>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctShipLoc> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readDistinctParts(string splant,string source,string stpartner,string shipLoc){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  = "select distinct(Part) from demandd , demandh where HdrId=Id " +
                      " and Plant = '" + Converter.fixString(splant) + "' and ShipLoc <> '' ";
        if (!string.IsNullOrEmpty(source))
            sql+= " and Source = '" + Converter.fixString(source) + "'";
        if (!string.IsNullOrEmpty(stpartner))
            sql+= " and TPartner = '" + Converter.fixString(stpartner) + "'";
        if (!string.IsNullOrEmpty(shipLoc))
            sql+= " and ShipLoc = '" + Converter.fixString(shipLoc) + "'";
       
        sql+= " order by Part";

		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read())            		        
            arrayList.Add(reader.GetString("Part"));	            
	    
	    return arrayList;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctParts> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctParts> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctParts>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctParts> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
void read830ByDates(string splant,DateTime startDate,DateTime endDate,string source="",decimal logFrom=0,decimal logTo=0,ArrayList arrayTPartner=null){
    string splantSql    = string.IsNullOrEmpty(splant) ? "" : (" and SMPLANT ='" + splant + "'");
    string sschPlantSql = string.IsNullOrEmpty(splant) ? "" : (" and JYPLNT ='" + splant + "'"); 
    string  sql         = "";
    int     icounter    = 0;

    sql ="select 0 as HdrId,0 as Detail ,'N' as Discard,query.* from ( " ;

    if (string.IsNullOrEmpty(source) || source.Equals(DemandD.SOURCE_830)) {
        icounter++;

        if (!string.IsNullOrEmpty(splant)) { 
            splantSql = "select st.OYLOG# from " + getTablePrefix() + "Stxh st where st.OYLOG#=rh.OZLOG# and st.OYTRPR=rh.OZTRPT and OYPLNT='" + Converter.fixString(splant) + "'";    
            splantSql = " and exists (" + DBFormatter.selectTopRows(splantSql, 1) + ")";
        }

        sql +=
                    /*
                     * private string DB;
private decimal	OZKEYN;
private string OZTRPT;
private string OZSTXL;
private string OZCPT;
private string OZREL;
private string OZMTL;
private DateTime OZSDAT;
private DateTime OZEDAT;
private DateTime OZIDAT;
private string OZSETP;
private string OZINTC;
private string OZCPO;
private string OZPLNT;
private string OZDOK;
private string OZLINE;
private string OZDROP;
private string OZSRCE;
private decimal	OZLOG;*/

            " select '830PLAN' as Source, " +
                " rh.OZTRPT as TPartner, rh.OZSDAT  as  RelDate,    rh.OZREL# as RelNum  " +
               " ,'' as BillTo, '' as ShipTo,rh.OZSTXL as ShipLoc, 0 as ShipLTim,'' as ShipLTUn " +
               " ,'' as Part,    rh.OZCPT# as CustPart " +
              " ,0  as CurrCum,  0  as FaAutCum,0  as MaAutCum " +
              " ,''  as CurShDoc " +
              " ,rd.PLRDAT as SDate, rh.OZEDAT as EndDate " +
              " ,rd.PLQCUM as QtyCum,rd.PLQNET as AdjNQty " +
              " ,rd.PLTIMC as TimeCode,rd.PLADJN as NetQty" +
              " ,rh.OZKEYN as TrlpKeyId " +
              " ,rh.OZLOG# as LogNum " +
              
            " from " + getTablePrefix() + "RRLH  as rh, " + 
                       getTablePrefix() + "RRLD as rd , " + getTablePrefix() + "cust  as bcust " +
            " where  " +            
            " rh.OZKEYN=rd.PLKEYN   and rh.OZREL#=rd.PLREL# " +
            " and (rd.PLRDAT >= '" + DateUtil.getDateRepresentation(startDate) + "' " +
            " and rd.PLRDAT <= '" + DateUtil.getDateRepresentation(endDate) + "') " +
            splantSql;

            if (logFrom > 0 || logTo > 0){
                sql+= " and (";
                if (logFrom > 0)
                    sql+= " OZLOG# >=" + logFrom;
                if (logTo > 0)
                    sql+= " and OZLOG# <=" + logTo;                    
                sql+= ")";
            }
    }

    if (string.IsNullOrEmpty(source) || source.Equals(DemandD.SOURCE_862)){
        if (icounter > 0)
            sql+= " union all ";
        icounter++;
        sql+= 
        " select '862SHIP' as Source, " +
            " tr.SMTRPT as TPartner, tr.SMRDAT  as  RelDate,    tr.SMCREL as RelNum " +
           " ,tr.SMCUST as BillTo, tr.SMLOCN  as ShipTo,tr.SMSTXL as ShipLoc, bcust.BVSLT as ShipLTim,bcust.BVSLTU as ShipLTUn " +
          " ,tr.SMPART as Part,    tr.SMCPT# as CustPart " +
          " ,tr.SMCCUM  as CurrCum,             tr.SMFABC  as FaAutCum,tr.SMMTLC  as MaAutCum " +
          " ,tr.SMSREF  as CurShDoc " +
          " ,jd.PYDATE as SDate,                      jd.PYEDAT as EndDate " +
          " ,jd.PYQCUM as QtyCum ,           jd.PYQTY as AdjNQty " +
          " ,'D' as TimeCode , jd.PYNQTY as NetQty" +
          " ,jh.SPKEYN as TrlpKeyId " +
          " ,jh.SPLOG# as LogNum " +

        " from " +  getTablePrefix() + "TRLP tr , " +   getTablePrefix() + "JITH jh , " + 
                    getTablePrefix() + "JITD as jd ," + getTablePrefix() + "cust  as bcust " +
        " where  " +

        " tr.SMCKEY=jh.SPKEYN"+
        " and tr.SMSREF=jh.SPREF#"+
        " and jh.SPKEYN=jd.PYKEYN" +
        " and jh.SPREF#=jd.PYREF#" +    
        //" tr.SMCKEY=jh.SPKEYN   and tr.SMCREL=jh.SPREL#   " +
        " and (jd.PYDATE >= '" + DateUtil.getDateRepresentation(startDate) + "' " +
        " and jd.PYDATE <= '" + DateUtil.getDateRepresentation(endDate) + "') " +   
        //" and jh.SPKEYN=jd.PYKEYN and jh.SPREF#=jd.PYREF# " +    
        " and bcust.BVCUST=tr.SMLOCN " +
        splantSql;

        if (logFrom > 0 || logTo > 0){
            sql+= " and (";
            if (logFrom > 0)
                sql+= " SPLOG# >=" + logFrom;
            if (logTo > 0)
                sql+= " SPLOG# <=" + logTo;         
            sql+= ")";                       
        }
    } 

    sql+=" ) as query ";

    if (arrayTPartner!= null && arrayTPartner.Count > 0)
        sql+= " where " + DBFormatter.getSqlInFieldLists("TPartner",arrayTPartner,true);
            
    sql+= " order by ShipTo,Part,SDate,Source desc";  // TPartner,RelNum,RelDate,Part ";

   // System.Windows.Forms.MessageBox.Show(sql);
	read(sql);    
}

} // class
} // package