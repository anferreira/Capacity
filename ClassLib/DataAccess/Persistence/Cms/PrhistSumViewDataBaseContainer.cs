using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Core.Cms;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PrhistSumViewSumViewDataBaseContainer: GenericDataBaseContainer{

public 
PrhistSumViewSumViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PrhistSumViewDataBase prhistSumViewDataBase = new PrhistSumViewDataBase(dataBaseAccess);
		prhistSumViewDataBase.load(reader);
		this.Add(prhistSumViewDataBase);
    }
}

public
void readByFilters(string spart,int iseq,string sdept,DateTime fromDate,DateTime toDate,PrHistSumViewContainer prHistSumViewContainer,int irows){
	string sql = "select DWPART,DWSEQN,Sum(DWQTYC) as DWQTYC,Sum(DWQTYS) as DWQTYS from " + getTablePrefix2() + "prhist";
                        
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DWPART",spart);
    if (iseq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " DWSEQN = " + NumberUtil.toString(iseq);

    if (!string.IsNullOrEmpty(sdept))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DWDEPT",sdept);

    if (fromDate!= DateUtil.MinValue || fromDate != DateUtil.MinValue)
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("DWDATE", fromDate,toDate);

    if (prHistSumViewContainer!=null && prHistSumViewContainer.Count > 0){
        sql = DBFormatter.addWhereAndSentence(sql) + "(";
        for (int i=0; i < prHistSumViewContainer.Count; i++){            
            PrHistSumView prHistSumView = prHistSumViewContainer[i];
            sql+= i > 0 ? " or " : ""; 
            sql += " (" + DBFormatter.equalLikeSql("DWPART",prHistSumView.DWPART) + 
                   " and DWSEQN = " + NumberUtil.toString(prHistSumView.DWSEQN)  + ") ";
        }
        sql+= ")";
    }

    sql+= " group by DWPART,DWSEQN";
    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
    read(sql);
}

}//end class

}//end nanespace
