using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB
{
	public class DBFormatter
	{
		public DBFormatter()
		{
		}

        public static 
        string selectTopRows(string sqlSelect,int rowCount) {
	        return selectTopRows(sqlSelect, ConnectionManager.getCURRENT_DATABASE(),rowCount);
        }

    public static 
    string selectTopRows(string sqlSelect, string sqlRepositoryType, int rowCount) {
	    string  formatSql = "";
	    int     i=0;
	
	    switch (sqlRepositoryType){
	        case DataBaseAccess.SQLSERVER:
	        case DataBaseAccess.ACCESS:
		        i = 0;
		        bool done = false;
		        while (!done && i < (sqlSelect.Length-6)) {
			        if (sqlSelect.Substring(i,6).ToUpper().Equals("SELECT")) {
				        done = true;
				        formatSql = sqlSelect.Substring(0,i+6);
				        formatSql += " top " + rowCount.ToString();
				        formatSql += sqlSelect.Substring(i+6);
			        }
			        i++;
		        }
		        break;
	        case DataBaseAccess.MYSQL:
            case DataBaseAccess.POSTGRESQL:
		        i = sqlSelect.Length-1;
		        while (sqlSelect.Substring(i,1).Equals(" "))
			        i--;
		        if (sqlSelect.Substring(i,1).Equals(";"))
			        i--;
		        formatSql = sqlSelect.Substring (0,i+1);
		        formatSql += " limit " + rowCount.ToString();
		        formatSql += sqlSelect.Substring (i+1);
		        break;
            case DataBaseAccess.ODBC:
            case DataBaseAccess.OLEDB:        
                formatSql = sqlSelect + " fetch first " + rowCount + " rows only";            
                break;
            default: // DataBaseAccess.SQLSERVERCE or something else:
                formatSql = sqlSelect;
                break;
	    }
	    return formatSql;
    }
        /*
        public static
        string selectTopRows(string sqlSelect, int rowCount){
            return selectTopRows(sqlSelect, ConnectionManager.getCURRENT_DATABASE(), rowCount);
        }
        public static string selectTopRows (string sqlSelect, string sqlRepositoryType, int rowCount)
		{
			string formatSql = "";
			if (sqlRepositoryType.Equals("SQLServer"))
			{
				int i = 0;
				bool done = false;
				while (!done && i < (sqlSelect.Length-6))
				{
					if (sqlSelect.Substring(i,6).ToUpper().Equals("SELECT"))
					{
						done = true;
						formatSql = sqlSelect.Substring(0,i+6);
						formatSql += " top " + rowCount.ToString();
						formatSql += sqlSelect.Substring(i+6);
					}
					i++;
				}
			}
			if (sqlRepositoryType.Equals("MySQL"))
			{
				int i = sqlSelect.Length-1;
				while (sqlSelect.Substring(i,1).Equals(" "))
					i--;
				if (sqlSelect.Substring(i,1).Equals(";"))
					i--;
				formatSql = sqlSelect.Substring (0,i+1);
				formatSql += " limit " + rowCount.ToString();
				formatSql += sqlSelect.Substring (i+1);
			}
			return formatSql;
		}
        */
        public static
        string addWhereAndSentence(string sql) {
            if (sql!=null){
                string saux = sql.ToLower();
                if (saux.LastIndexOf(" where ") < 0)
                    sql+=" where ";
                else
                    sql+= " and ";
            }
            return sql;     
        }

        public static
        string equalLikeSql(string sfield, string svalue){
            string sql = " ";
            string svalueAux = svalue;

            if (ConnectionManager.CURRENT_CONNECTION_TYPE == DataBaseAccess.CMS_DATABASE){
                sql += "LOWER(" + sfield + ")";
                svalueAux = string.IsNullOrEmpty(svalue) ? "" : svalue.ToLower();
            }
            else
                sql += sfield;

            sql += " ";
            sql += svalueAux.IndexOf("%") >= 0 ? " like " : " = ";
            sql += "'" + Converter.fixString(svalueAux) + "'";

            return sql;
        }

        public static
        string convertDate(string field, string param){
            string sql = "";

            switch (ConnectionManager.getCURRENT_DATABASE()){
                case DataBaseAccess.SQLSERVER:
                case DataBaseAccess.SQLSERVERCE:
                    sql += "convert(varchar," + field + "," + param + ")";
                    break;
                case DataBaseAccess.MYSQL:
                    sql += "date_format(" + field + "," + param + ")";
                    break;
                case DataBaseAccess.POSTGRESQL:
                case DataBaseAccess.ORACLE:
                    sql += "to_date(to_char(" + field + "," + param + ")" + "," + param + ")";
                    break;
                case DataBaseAccess.ODBC:
                case DataBaseAccess.OLEDB:
                    sql += " to_char(" + field + "," + param+ ")";                        
                    break;
            }
            return sql;
        }

        public static
        string compareDate(string field){
            string sql = field;

            switch (ConnectionManager.getCURRENT_DATABASE()){
                case DataBaseAccess.SQLSERVER:
                case DataBaseAccess.SQLSERVERCE:                    
                    sql = "Convert(date," + field + ")";
                    break;
                case DataBaseAccess.MYSQL:
                    sql = "date(" + field + ")";
                    break;
                case DataBaseAccess.POSTGRESQL:
                case DataBaseAccess.ORACLE:                    
                    break;
            }
            return sql;
        }

        public static
        string getNowFunction(){
            string sresult = "";

            switch (ConnectionManager.getCURRENT_DATABASE())
            {
                case DataBaseAccess.MYSQL:
                case DataBaseAccess.POSTGRESQL:
                    sresult = "now()";
                    break;
                case DataBaseAccess.SQLSERVER:
                case DataBaseAccess.SQLSERVERCE:
                    sresult = "GETDATE()";
                    break;
                case DataBaseAccess.ORACLE:
                    sresult = "SYSDATE";
                    break;
                default:
                    break;
            }

            return sresult;
        }

        public static
        string getSystemDate(){
            string sql = "select ";

            switch (ConnectionManager.getCURRENT_DATABASE()){
                case DataBaseAccess.MYSQL:
                    sql += "date_format(" + getNowFunction() + ",'%m/%d/%Y %h:%m:%s')";
                    break;
                case DataBaseAccess.SQLSERVER:
                case DataBaseAccess.SQLSERVERCE:
                    sql += "convert(varchar," + getNowFunction() + ",101) + ' ' + convert(varchar," + getNowFunction() + ",108)";
                    break;
                case DataBaseAccess.POSTGRESQL:
                    sql = "to_char(" + getNowFunction() + ",'mm/dd/yyyy hh:mm:ss')";
                    break;
                default:
                    break;
            }
            return sql;
        }

        public static
        string concat(string sql,string sfield){
            string saux = "Concat( " + sql + "," + sfield + ")";
            return saux;
        }            

        public static
        string lpad(string sfield,int len,char c){
            string sql = "";

            switch (ConnectionManager.getCURRENT_DATABASE()){                               
                case DataBaseAccess.SQLSERVER:
                case DataBaseAccess.SQLSERVERCE:
                    string saux = Nujit.NujitERP.ClassLib.Common.StringUtil.AddChar("", c, len, false);
                    sql += "RIGHT('" + saux + "' + " + sfield + ", " + len +")";
                    break;
                case DataBaseAccess.POSTGRESQL:
                    sql = "";
                    break;
                case DataBaseAccess.MYSQL:
                case DataBaseAccess.ODBC:
                case DataBaseAccess.OLEDB:
                    sql = "LPAD(" + sfield + "," + len + ", '" + c + "')";
                    break;
                default:
                    break;
            }
            return sql;
        } 

        public static
        string getSqlRangeDates(string sfield,DateTime fromDate,DateTime toDate,bool bcompleteDate=false){
            return getSqlRangeDates(sfield, sfield, fromDate,toDate,bcompleteDate);
        }

        public static
        string getSqlRangeDates(string sfield1,string sfield2, DateTime fromDate,DateTime toDate,bool bcompleteDate=false){
            string sql = "";
            bool   bisAS400 = ConnectionManager.getCURRENT_DATABASE().Equals(DataBaseAccess.ODBC) || ConnectionManager.getCURRENT_DATABASE().Equals(DataBaseAccess.OLEDB);

            //we only check Start date
            if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue ){              
                sql+= "( ";

                DateTime fromDateAux= fromDate;
                DateTime toDateAux  = toDate;

                if (!bcompleteDate){
                    fromDateAux = fromDate!= DateUtil.MinValue ? new DateTime(fromDate.Year, fromDate.Month, fromDate.Day,0,0,0): fromDate;
                    toDateAux   = toDate  != DateUtil.MinValue ? new DateTime(toDate.Year, toDate.Month, toDate.Day,23,59,59)   : toDate;
                }

                if (fromDate != DateUtil.MinValue) { 
                    sql += sfield1 + " >= '" + (bisAS400 ? DateUtil.getDateRepresentation(fromDateAux, DateUtil.MMDDYYYY) : DateUtil.getCompleteDateRepresentation(fromDateAux,DateUtil.MMDDYYYY)) + "'";
                }
                 //sql += sfield + " >= '" + ( bcompleteDate ? DateUtil.getCompleteDateRepresentation(fromDate,DateUtil.MMDDYYYY) : DateUtil.getDateRepresentation(fromDate, DateUtil.MMDDYYYY) )  + "'";            
        
                if (toDate != DateUtil.MinValue){
                    sql+= fromDate != DateUtil.MinValue? " and " : "";
                    //sql+= sfield + " <= '" + (bcompleteDate ? DateUtil.getCompleteDateRepresentation(toDate, DateUtil.MMDDYYYY) : DateUtil.getDateRepresentation(toDate, DateUtil.MMDDYYYY)) + "'";
                    sql += sfield2 + " <= '" + (bisAS400 ? DateUtil.getDateRepresentation(toDateAux, DateUtil.MMDDYYYY) : DateUtil.getCompleteDateRepresentation(toDateAux, DateUtil.MMDDYYYY)) + "'";
                }

                sql += ")";
            }
            return sql;
        }


        public static
        string getSqlInFieldLists(string sfield1,ArrayList arrayList,bool bstring){
            string sql = "";

            if (arrayList != null && arrayList.Count > 0){

                sql+= " " + sfield1 + " in (";
                for (int i = 0; i < arrayList.Count; i++){
                    sql += i == 0 ? "" : ",";

                    if (bstring)    sql += "'" + Converter.fixString((string)arrayList[i])  + "'";
                    else            sql += Convert.ToInt64(arrayList[i]).ToString();
                }

                sql+=") ";
            }
            return sql;
        }

    }
}
