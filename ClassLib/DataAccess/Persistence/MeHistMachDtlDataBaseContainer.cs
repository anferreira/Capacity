using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class MeHistMachDtlDataBaseContainer : GenericDataBaseContainer{

public 
MeHistMachDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from mehistmachdtl ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			MeHistMachDtlDataBase meHistMachDtlDataBase = new MeHistMachDtlDataBase(dataBaseAccess);
			meHistMachDtlDataBase.load(reader);
			this.Add(meHistMachDtlDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class  "+ this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
string[][] generateShcByMachine(string plt, string dept,string part, int seq){
	NotNullDataReader reader = null;
	try{
		string sql = "select MHMD_Machine, " +
		                    "MHMD_Plt, " +
		                    "MHMD_Dept, "+
		                    "MHMD_Seq, "+
		                    "sum(MHMD_RuntimeHrs) " +
		             "from mehistmachdtl " +
		                  "where MHMD_Plt = '" + plt +"' and " +
		                        "MHMD_Dept = '" + dept +"' and " +
		                        "MHMD_Part ='" + part +"' and " + 
		                        "MHMD_Seq = " + seq  + " " + 
                           "group by MHMD_Machine, MHMD_Plt, MHMD_Dept, MHMD_Seq " +
                           "having sum(MHMD_RuntimeHrs) > 0 " + 
                           "order by MHMD_Machine, MHMD_Plt, MHMD_Dept, MHMD_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[5];
			getLine(reader,line);
			array.Add((object)line);
		}

        int index = 0;
        string[][] returnArray = new string[array.Count][];
	    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		    string[] lineArray = (string[])en.Current;
		    returnArray[index] = lineArray;
		    index++;
	    }
	    return returnArray;
	    
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class  "+ this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

private 
void getLine(NotNullDataReader reader,string[] line){
    line[0]= reader.GetString("MHMD_Machine"); 
    line[1]= reader.GetString("MHMD_Plt");
    line[2]= reader.GetString("MHMD_Dept");
    line[3]= reader.GetString("MHMD_Seq");
    line[4]= reader.GetDecimal(4).ToString();
}

}//end class
}//end namespace
