using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip{
	
public class BolhDataBaseContainer : GenericDataBaseContainer{

public BolhDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public 
void read(){
	string table = getTablePrefix()+ "bolh";	
	string sql = "select * from " + table;

	read(sql);
}

public
void readUnposted(){
	string table = getTablePrefix()+ "bolh";		
	string sql = "select * from " + table + " where FECRCM <> '2' and FEBTYP = 'C'";

	read(sql);
}

public
void readByHeaders(ArrayList headers){
	if (headers.Count == 0)
		return;

	string fgbolField = "FEBOL";
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	{
		sql += getTablePrefix();
		fgbolField = "FEBOL#";
	}
	sql += "bolh";

	sql += " where "+fgbolField+" in (";

	for(int i=0; i<headers.Count; i++)
	{
		sql+=headers[i].ToString();
		if (i != headers.Count - 1)
			sql += ", ";
	}
	sql += ")";

	read(sql);
}

public
void read(int lastFEBOLtransfered){
	string febolField = "FEBOL";
	string table = "bolh";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	{
		table = getTablePrefix() + table;
		febolField="FEBOL#";
	}

	string sql = "select * from " + table + " where FEBTYP = 'C'"+
		" and "+ febolField + " > " + NumberUtil.toString(lastFEBOLtransfered) +
		" order by "+febolField;

	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += " fetch first 250 rows only";
	else
		sql = DBFormatter.selectTopRows (sql, 250);

	read(sql);
}

public
int getPackslipsToTransfer(){
	NotNullDataReader reader = null;
	try{
		string table = "bolh";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		{
			table = getTablePrefix() + table;
		}

		string sql = "select count(*) from " + table + " where FEBTYP = 'C'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			return reader.GetInt32(0);
		}
		return 0;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		BolhDataBase bolhDataBase = new BolhDataBase(dataBaseAccess);
		bolhDataBase.load(reader);
		this.Add(bolhDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table bolh";
	truncate(sql);
}

public
void readByFilters(string sferteg ,decimal dorder,bool borderByBol,int rows){
    string sql = "select * from " + getTablePrefix() + "bolh";

    if (!string.IsNullOrEmpty(sferteg))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FERTEG", sferteg);

    if (dorder > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "FEORD#=" + NumberUtil.toString(dorder);

    sql += " order by " + (borderByBol ? "FEBOL# desc" : "FESDAT,FESTME");
    
    if (rows > 0)
        sql = DBFormatter.selectTopRows(sql, rows);

    //System.Windows.Forms.MessageBox.Show("readByFilters:" + sql);
    read(sql);
}


public
void readByFilters2(string sferteg,string sbolid, DateTime startDate, DateTime endDate, string status, string shipInd, string shipVia, string struckID,string splant,decimal dorder, bool borderByBol, bool bshowAtLeastOneAttachBol,int rows){
    string sql ="select * from " + getTablePrefix() + "bolh " +
                " LEFT outer JOIN " + getTablePrefix() + "bolm on (FERTEG is not null and FERTEG <> '') and RAROUT=FERTEG ";
                
    if (bshowAtLeastOneAttachBol){
        sql = DBFormatter.addWhereAndSentence(sql) + " (FERTEG is not null and FERTEG <> '') and RAROUT=FERTEG";
        if (!string.IsNullOrEmpty(shipInd))
            sql = DBFormatter.addWhereAndSentence(sql) + "RASIND='" + Converter.fixString(shipInd) + "'";
    }

    if (!string.IsNullOrEmpty(sferteg))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FERTEG", sferteg);

    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += " ( ";

        if (startDate != DateUtil.MinValue)
            sql += " FESDAT >= '" + DateUtil.getDateRepresentation(startDate, DateUtil.MMDDYYYY) + "'";

        if (endDate != DateUtil.MinValue){
            if (startDate != DateUtil.MinValue)
                sql += " and ";
            sql += " FESDAT <= '" + DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY) + "'";
        }
        sql += " ) ";
    }

    if (!string.IsNullOrEmpty(sbolid))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("cast( FEBOL# as varchar(9))", sbolid);
        
    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + "FERTS='" + Converter.fixString(status) + "'";    
    
    if (!string.IsNullOrEmpty(shipVia))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FESVIA", shipVia);
    if (!string.IsNullOrEmpty(struckID))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FETKID", struckID);
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FEPLNT", splant);

    if (dorder > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "FEORD#=" + NumberUtil.toString(dorder);
       
    sql += " order by " + (borderByBol ? "FEBOL# desc" : "FESDAT,FESTME");

    if (rows > 0)
        sql = DBFormatter.selectTopRows(sql, rows);

    //System.Windows.Forms.MessageBox.Show("readByFilters2:" + sql);
    read(sql);
}


public
void readByFiltersTransfer(decimal dkeyGreaterThan,string splant,string status,DateTime fromPostDate,DateTime toPostDate, int rows){
    string sql = "select * from "+ getTablePrefix()  + "bolh";
    string skey= getFieldDigit("FEBOL");
            
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FEPLNT", splant);

    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + "FESTS='" + Converter.fixString(status) + "'";    

    if (dkeyGreaterThan > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " " + skey + " > " + NumberUtil.toString(dkeyGreaterThan);

     //we only check Start date
    if (fromPostDate != DateUtil.MinValue || toPostDate != DateUtil.MinValue ){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql+= "( ";

        if (fromPostDate != DateUtil.MinValue)
            sql+= "FEPDAT >= '" + DateUtil.getDateRepresentation(fromPostDate, DateUtil.MMDDYYYY)  + "'";            
        
        if (toPostDate != DateUtil.MinValue){
            sql+= fromPostDate != DateUtil.MinValue ? " and " : "";
            sql+= "FEPDAT <= '" + DateUtil.getDateRepresentation(toPostDate, DateUtil.MMDDYYYY)  + "'";
        }

        sql += ")";
    }

                   
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

public
ArrayList readByFiltersTransfer(string splant,string status,DateTime fromPostDate,DateTime toPostDate, int rows){
	NotNullDataReader reader = null;
	try{
        ArrayList arrayList = new ArrayList();
		string sql = "select " + getFieldDigit("FEBOL") + ","+ "FEPDAT, FEPTIM, FEPLNT, " + getFieldDigit("FEBCS") + "," + getFieldDigit("FESCS") + ",FESDAT,FESTME,FESTS, " +
                    getFieldDigit("FGBOL") + "," + getFieldDigit("FGENT") + ",FGPART ," + getFieldDigit("FGCPT") + ",FGQSHP,FGCCUM,FGPCUM" +
                    " from " + getTablePrefix() + "bolh ," + getTablePrefix() + "bold";

        sql= DBFormatter.addWhereAndSentence(sql) + getFieldDigit("FEBOL") + "=" + getFieldDigit("FGBOL");

        //we only check Start date
        if (fromPostDate != DateUtil.MinValue || toPostDate != DateUtil.MinValue ){
            sql = DBFormatter.addWhereAndSentence(sql);
            sql+= "( ";

            if (fromPostDate != DateUtil.MinValue)
                sql+= "FEPDAT >= '" + DateUtil.getDateRepresentation(fromPostDate, DateUtil.MMDDYYYY)  + "'";            
        
            if (toPostDate != DateUtil.MinValue){
                sql+= fromPostDate != DateUtil.MinValue ? " and " : "";
                sql+= "FEPDAT <= '" + DateUtil.getDateRepresentation(toPostDate, DateUtil.MMDDYYYY)  + "'";
            }

            sql += ")";
        }
        sql+= " order by " + getFieldDigit("FGBOL") +"," + getFieldDigit("FGENT");
		             
		reader = dataBaseAccess.executeQuery(sql);
        while(reader.Read()){
            string [] item = new string[50];  //first 20 char for header, last 30 from detail
            for (int i=0; i < 50;i++)
                item[i]="";
        
            item[0] = Convert.ToInt32(reader.GetDecimal(getFieldDigit("FGBOL"))).ToString();
            item[1] = reader.GetString("FEPLNT");
            item[2] = reader.GetString(getFieldDigit("FEBCS")); //bill
            item[3] = reader.GetString(getFieldDigit("FESCS"));//ship
            item[4] = DateUtil.getCompleteDateRepresentation(reader.GetDateTime("FESDAT"),DateUtil.MMDDYYYY); //shipping date
            item[5] = Convert.ToInt32(reader.GetDecimal("FESTME")).ToString();
            item[6] = DateUtil.getCompleteDateRepresentation(reader.GetDateTime("FEPDAT"),DateUtil.MMDDYYYY);//post date
            item[7] = Convert.ToInt32(reader.GetDecimal("FESTME")).ToString();
            item[8] = reader.GetString("FESTS");

            item[20]= Convert.ToInt32(reader.GetDecimal(getFieldDigit("FGENT"))).ToString();
            item[21]= reader.GetString("FGPART");
            item[22]= reader.GetString(getFieldDigit("FGCPT"));
            item[23]= reader.GetDecimal("FGQSHP").ToString();
            item[24]= reader.GetDecimal("FGCCUM").ToString();
            item[25]= reader.GetDecimal("FGPCUM").ToString();
                    
            arrayList.Add(item);		    
	    }
		
		return arrayList;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersTransfer> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersTransfer> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersTransfer> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

}//end class

}//end namespace
