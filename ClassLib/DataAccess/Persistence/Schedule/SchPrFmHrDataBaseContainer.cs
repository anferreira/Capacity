using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrFmHrDataBaseContainer : GenericDataBaseContainer{

private string PDM_Dept;
private string PDM_Plt;
private string PDM_Mach;
private string SPH_SchVersion;
	
public
SchPrFmHrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void setPDM_Dept(string PDM_Dept){
    this.PDM_Dept = PDM_Dept;
}

public
void setPDM_Plt(string PDM_Plt){
    this.PDM_Plt = PDM_Plt;
}

public
void setPDM_Mach(string PDM_Mach){
    this.PDM_Mach = PDM_Mach;
}

public
void setSPH_SchVersion(string SPH_SchVersion){
	this.SPH_SchVersion = SPH_SchVersion;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.*, B.SMH_Mach, B.SMH_DRS from schprfmhr as A, schmachhr as B where B.SMH_Dept = '" +
			PDM_Dept + "' and B.SMH_Plt ='" + PDM_Plt + "' and B.SMH_Mach = '" + PDM_Mach + "'" +
			" and (B.SMH_DRS = 'R' or B.SMH_DRS = 'S') and A.SPH_MachOrdNum = B.SMH_MachOrdNum and " +
			"SPH_SchVersion = '" + SPH_SchVersion + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrFmHrDataBase schPrFmHrDataBase = new SchPrFmHrDataBase(dataBaseAccess);
			schPrFmHrDataBase.load2(reader);
			this.Add(schPrFmHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
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
void readProvisorio(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schprfmhr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrFmHrDataBase schPrFmHrDataBase = new SchPrFmHrDataBase(dataBaseAccess);
			schPrFmHrDataBase.load(reader);
			this.Add(schPrFmHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProvisorio> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProvisorio> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProvisorio> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByVersion(){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.*, B.SMH_Mach, B.SMH_DRS from schprfmhr as A, schmachhr as B " + 
			"where  A.SPH_SchVersion ='" + 	SPH_SchVersion + "' and B.SMH_SchVersion = '" + SPH_SchVersion + 
			"' and (B.SMH_DRS = 'R' or B.SMH_DRS = 'S') and A.SPH_MachOrdNum = B.SMH_MachOrdNum";


		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrFmHrDataBase schPrFmHrDataBase = new SchPrFmHrDataBase(dataBaseAccess);
			schPrFmHrDataBase.load2(reader);
			this.Add(schPrFmHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public string[][] readForReport(string plantCode,string deptCode){
	NotNullDataReader reader = null;
	try{
		string sql = "Select SPH_ProdID, "  + 
							"SPH_Seq, "  + 
							"SPH_HrPr, "  + 
							"SPH_UtilPer, "  + 
							"SPH_MachOrdNum,  "  +
							"PDM_Mach, " +
							"SMH_TmStart, " +
							"SMH_HrPr " + 
				"from schprfmhr, pltdeptmach, schmachhr where " +
				"PDM_Plt = '" + plantCode +"' and " +
				"PDM_Dept = '" + deptCode +"' and " + 
				"PDM_PLT = SMH_PLT  and " +
				"PDM_Dept= SMH_Dept and " + 
				"PDM_Mach = SMH_Mach and " +
				"SMH_SchVersion = SPH_SchVersion and " +
				"SMH_MachOrdNum = SPH_MachOrdNum " +
				"order by PDM_Mach";

		reader = dataBaseAccess.executeQuery(sql);
		
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] lineArray = new string[11];
			lineArray[0] = reader.GetString("SPH_ProdID");
			lineArray[1] = reader.GetInt32("SPH_Seq").ToString();
			lineArray[2] = reader.GetDecimal("SPH_HrPr").ToString();
			lineArray[3] = reader.GetDecimal("SPH_UtilPer").ToString();
			lineArray[4] = reader.GetInt32("SPH_MachOrdNum").ToString();
			lineArray[5] = reader.GetString("PDM_Mach");
			lineArray[6] =DateUtil.getCompleteDateRepresentation(reader.GetDateTime("SMH_TmStart"),DateUtil.MMDDYYYY);
			lineArray[7] = reader.GetDecimal("SMH_HrPr").ToString();
			array.Add((object)lineArray);
		}
	    string[][] returnArray = new string[array.Count][];
        int index = 0;
	    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		    string[] lineArray = (string[])en.Current;
		    returnArray[index] = lineArray;
		    index++;
	    }
		return returnArray;	
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
	
}


public
void truncate(){
	try{
		string sql = "delete from schprfmhr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

public string[][] getScheduleForReport(string plantCode,string deptCode){
	NotNullDataReader reader = null;
	try{
		string sql = "Select SPH_ProdID, "  + 
							"SPH_Seq, "  + 
							"SPH_HrPr, "  + 
							"SPH_UtilPer, "  + 
							"SPH_MachOrdNum,  "  +
							"PDM_Mach, " +
							"SMH_TmStart, " +
							"SMH_HrPr " + 
				"from schprfmhr, pltdeptmach, schmachhr where " +
				"PDM_Plt = '" + plantCode +"' and " +
				"PDM_Dept = '" + deptCode +"' and " + 
				"PDM_PLT = SMH_PLT  and " +
				"PDM_Dept= SMH_Dept and " + 
				"PDM_Mach = SMH_Mach and " +
				"SMH_SchVersion = SPH_SchVersion and " +
				"SMH_MachOrdNum = SPH_MachOrdNum " +
				"order by PDM_Mach";
				
		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] lineArray = new string[8];
			lineArray[0] = reader.GetString(0);
			lineArray[1] = reader.GetInt32(1).ToString();
			lineArray[2] = reader.GetDecimal(2).ToString();
			lineArray[3] = reader.GetDecimal(3).ToString();
			lineArray[4] = reader.GetInt32(4).ToString();
			lineArray[5] = reader.GetString(5);
			lineArray[6] =DateUtil.getCompleteDateRepresentation(reader.GetDateTime(6));
			lineArray[7] = reader.GetDecimal(7).ToString();
			array.Add((object)lineArray);
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
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getScheduleForReport> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getScheduleForReport> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getScheduleForReport> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

} // class

} // namespace