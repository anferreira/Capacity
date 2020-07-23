using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListDataBaseContainer : GenericDataBaseContainer{

public
HotListDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
		hotListDataBase.load(reader);
		this.Add(hotListDataBase);
	}
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
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
void readById(int id){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist where HOT_Id = " + NumberUtil.toString(id);

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
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
void readByPartSeq(int id, string prod, int seq){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist where HOT_Id = " + NumberUtil.toString(id) + 
			" and HOT_ProdId = '" + Converter.fixString(prod) + "' " + 
			" and HOT_Seq = " + NumberUtil.toString(seq) + 
			" order by HOT_ProdId, HOT_Seq desc";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
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
void readByPart(int id, string prod){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist where HOT_Id = " + NumberUtil.toString(id) + 
			" and HOT_ProdId = '" + Converter.fixString(prod) + "' order by HOT_Seq desc";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
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
void readOrderByConfiguration(int id){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist ";
		
		sql += " where Hot_Id = " + NumberUtil.toString(id);
		 
		sql += " order by HOT_Mach";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readOrderByConfiguration> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readOrderByConfiguration> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readOrderByConfiguration> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readPO(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist where " + 
			"(HOT_ProdID IN (SELECT HOT_ProdID FROM hotlist GROUP BY HOT_ProdID HAVING (COUNT(*) = 5))) " +
			"ORDER BY HOT_ProdID, HOT_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPO> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPO> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPO> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void read(int id,string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	NotNullDataReader reader = null;
	try{
		string sql = "select * ";        
        sql +=  ",(select COALESCE(SUM(i.IPL_Qoh),0) " +  //mysql FORMAT(COALESCE(SUM(i.IPL_Qoh),0),0)
                " from invpltloc i , prodfminfo p2 " +
                " where p2.PFS_ProdID=p.PFS_MainMaterial " +
                " and IPL_ProdID=p2.PFS_ProdID and IPL_Seq=p2.PFS_SeqLast) as QohMainMaterial";
        sql += ",(select p2.PFS_SeqLast " +
                " from prodfminfo p2 " +
                " where p2.PFS_ProdID=p.PFS_MainMaterial ) as SeqMainMaterial";
        sql += " from hotlist ";
        sql += " left outer join prodfminfo as p on p.PFS_ProdID = HOT_ProdID ";
        
        bool existsFilter = false;		
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsFilter = true;
		
		if (filterDept.Length > 0){
			if (existsFilter)
				sql += " and ";
			else
				sql += " where ";
			
			sql += " HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
			existsFilter = true;
		}
		if (filterPart.Length > 0){
			if (existsFilter) {
				sql  += " and ";
			}else 
				sql += " where ";
			sql +="HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
			
			existsFilter = true;
		}

		if (filterMg.Length > 0){
			if (existsFilter) {
				sql  += " and ";
			}else 
				sql += " where ";
			sql +="HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
			
			existsFilter = true;
		}

		if (onlyDemand){
			if (existsFilter)
				sql += " and ";
			else
				sql += " where ";
			sql +="((HOT_PastDue +";
			sql+="  HOT_Day001 +";
			sql+="  HOT_Day002 +";
			sql+="  HOT_Day003 +";
			sql+="  HOT_Day004 +";
			sql+="  HOT_Day005 +";
			sql+="  HOT_Day006 +";
			sql+="  HOT_Day007 +";
			sql+="  HOT_Day008 +";
			sql+="  HOT_Day009 +";
			sql+="  HOT_Day010 +";
			sql+="  HOT_Day011 +";
			sql+="  HOT_Day012 +";
			sql+="  HOT_Day013 +";
			sql +=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql +=" and (HOT_Finalized = '" + type.Trim() + "')";

		sql += " Order by " +
				"HOT_Dept,HOT_MinorGroup,HOT_Day001,HOT_Day002,HOT_Day003,HOT_Day004,HOT_Day005,HOT_Day006,"+
				"HOT_Day007,HOT_Day008,HOT_Day009,HOT_Day010,HOT_Day011,HOT_Day012,HOT_Day013,HOT_Day014,"+
				"HOT_Day015,HOT_Day016,HOT_Day017,HOT_Day018,HOT_Day019,HOT_Day020,HOT_Day021,HOT_Day022,"+
				"HOT_Day023,HOT_Day024,HOT_Day025,HOT_Day026,HOT_Day027,HOT_Day028,HOT_Day029,HOT_Day030,"+
				"HOT_Day031,HOT_Day032,HOT_Day033,HOT_Day034,HOT_Day035,HOT_Day036,HOT_Day037,HOT_Day038,"+
				"HOT_Day039,HOT_Day040,HOT_Day041,HOT_Day042,HOT_Day043,HOT_Day044,HOT_Day045,HOT_Day046,"+
				"HOT_Day047,HOT_Day048,HOT_Day049,HOT_Day050,HOT_Day051,HOT_Day052,HOT_Day053,HOT_Day054,"+
				"HOT_Day055,HOT_Day056,HOT_Day057,HOT_Day058,HOT_Day059,HOT_Day060," +
				"HOT_Day061,HOT_Day062,HOT_Day063,HOT_Day064,HOT_Day065,HOT_Day066,HOT_Day067,HOT_Day068,"+
				"HOT_Day069,HOT_Day070,HOT_Day071,HOT_Day072,HOT_Day073,HOT_Day074,HOT_Day075,HOT_Day076,"+
				"HOT_Day077,HOT_Day078,HOT_Day079,HOT_Day080,HOT_Day081,HOT_Day082,HOT_Day083,HOT_Day084,"+
				"HOT_Day085,HOT_Day086,HOT_Day087,HOT_Day088,HOT_Day089,HOT_Day090," +
				"HOT_ProdID desc, HOT_Seq desc";
					
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.loadGridHotList(reader);

            //AF 2018/10/22 load info related to main material
            hotListDataBase.setHOT_MainMaterial(reader.GetString("PFS_MainMaterial"));
            hotListDataBase.setHOT_MainMaterialSeq(reader.GetInt32("SeqMainMaterial"));
            hotListDataBase.setHOT_MainMaterialQoh(reader.GetDecimal("QohMainMaterial"));                    

            this.Add(hotListDataBase);
			
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readAllDepts(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(HOT_Dept) from hotlist Order by HOT_Dept";
					 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.setHOT_Dept(reader.GetString(0));
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllDepts> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllDepts> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllDepts> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
void readAllParts(int id, bool inactive){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(hotlist.HOT_ProdID) from hotlist";
		
		if (!inactive)
			sql += ", prodfminfo";

		sql += " where hotlist.HOT_Id = " + NumberUtil.toString(id);

		if (!inactive)
			sql += " and hotlist.HOT_ProdID = prodfminfo.PFS_ProdID and prodfminfo.PFS_InvStatus = 'A'";
			
		sql += " order by hotlist.HOT_ProdID";
					 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.setHOT_ProdID(reader.GetString(0));
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllParts> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllParts> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllParts> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readAllMG(int id){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(HOT_MinorGroup) from hotlist ";
		sql += " where HOT_Id = " + NumberUtil.toString(id);
		sql += " order by HOT_MinorGroup ";
					 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.setHOT_MinorGroup(reader.GetString(0));
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllParts> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllParts> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllParts> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public 
void truncate(){	
    string sql = "delete from hotlist";
    truncate(sql);		
}

public 
void deleteById(int id){
	string sql = "delete from hotlist where HOT_Id = " + NumberUtil.toString(id);
    delete(sql);        		
}

public 
void readReport(int id, string[] filterDept, string[] filterPart, string[] filterMg, string smachine, bool onlyDemand, string type){
	NotNullDataReader reader = null;
	try{
		string sql = "Select * from hotlist, prodfminfo, pltdept ";
		
		bool existsWhere = false;
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;

		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
			
		sql +=	"DE_Dept = HOT_Dept and " +
				"rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) "; 
	
		if (filterDept.Length > 0){
			sql += " and HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
	
		if (filterPart.Length > 0){
			sql +=" and HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (filterMg.Length > 0){
			sql +=" and HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

        if (!string.IsNullOrEmpty(smachine))
            sql = DBFormatter.addWhereAndSentence(sql) + " HOT_Mach like '" + Converter.fixString(smachine) + "'";
 

		if (onlyDemand){
			sql +=" and ((HOT_PastDue +";
			sql+=" HOT_Day001 +";
			sql+=" HOT_Day002 +";
			sql+=" HOT_Day003 +";
			sql+=" HOT_Day004 +";
			sql+=" HOT_Day005 +";
			sql+=" HOT_Day006 +";
			sql+=" HOT_Day007 +";
			sql+=" HOT_Day008 +";
			sql+=" HOT_Day009 +";
			sql+=" HOT_Day010 +";
			sql+=" HOT_Day011 +";
			sql+=" HOT_Day012 +";
			sql+=" HOT_Day013 +";
			sql+=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql += " and (HOT_Finalized = '" + type + "')";

		sql = sql + " Order by " +
						"DE_DeptShort, " + 
						"HOT_Dept, " +
//						"HOT_MinorGroup, " +
						"HOT_Day001, " +
						"HOT_Day002, " +
						"HOT_Day003, " +
						"HOT_Day004, " +
						"HOT_Day005, " +
						"HOT_Day006, " +
						"HOT_Day007, " +
						"HOT_Day008, " +
						"HOT_Day009, " +
						"HOT_Day010, " +
						"HOT_Day011, " +
						"HOT_Day012, " +
						"HOT_Day013, " +
						"HOT_Day014, " +
						"HOT_ProdID, " +
						"HOT_Seq";


		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readReportForBomHL(int id, string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	NotNullDataReader reader = null;
	try{
		string sql = "Select * from hotlist, prodfminfo, pltdept ";
		
		bool existsWhere = false;
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;

		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
			
		sql +=	"DE_Dept = HOT_Dept and " +
				"rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) "; 
	
		if (filterDept.Length > 0){
			sql += " and HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
	
		if (filterPart.Length > 0){
			sql +=" and HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (filterMg.Length > 0){
			sql +=" and HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (onlyDemand){
			sql +=" and ((HOT_PastDue +";
			sql+=" HOT_Day001 +";
			sql+=" HOT_Day002 +";
			sql+=" HOT_Day003 +";
			sql+=" HOT_Day004 +";
			sql+=" HOT_Day005 +";
			sql+=" HOT_Day006 +";
			sql+=" HOT_Day007 +";
			sql+=" HOT_Day008 +";
			sql+=" HOT_Day009 +";
			sql+=" HOT_Day010 +";
			sql+=" HOT_Day011 +";
			sql+=" HOT_Day012 +";
			sql+=" HOT_Day013 +";
			sql+=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql += " and (HOT_Finalized = '" + type + "')";

		sql = sql + " Order by " +
						"HOT_Day001, " +
						"HOT_Day002, " +
						"HOT_Day003, " +
						"HOT_Day004, " +
						"HOT_Day005, " +
						"HOT_Day006, " +
						"HOT_Day007, " +
						"HOT_Day008, " +
						"HOT_Day009, " +
						"HOT_Day010, " +
						"HOT_Day011, " +
						"HOT_Day012, " +
						"HOT_Day013, " +
						"HOT_Day014, " +
						"HOT_ProdID, " +
						"HOT_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readReportByResource(int id, string[] filterDept, string[] filterPart, string[] filterMg, 
		bool onlyDemand, string type){

	NotNullDataReader reader = null;
	try{
		string sql = "Select * from hotlist, prodfminfo, pltdept ";
		
		bool existsWhere = false;
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;
	
		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
		
		sql +=  "DE_Dept = HOT_Dept and " +
				"rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) ";

		if (filterDept.Length > 0){
			sql += " and HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
	
		if (filterPart.Length > 0){
			sql +=" and HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (filterMg.Length > 0){
			sql +=" and HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (onlyDemand){
			sql +=" and ((HOT_PastDue +";
			sql+=" HOT_Day001 +";
			sql+=" HOT_Day002 +";
			sql+=" HOT_Day003 +";
			sql+=" HOT_Day004 +";
			sql+=" HOT_Day005 +";
			sql+=" HOT_Day006 +";
			sql+=" HOT_Day007 +";
			sql+=" HOT_Day008 +";
			sql+=" HOT_Day009 +";
			sql+=" HOT_Day010 +";
			sql+=" HOT_Day011 +";
			sql+=" HOT_Day012 +";
			sql+=" HOT_Day013 +";
			sql+=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql += " and (HOT_Finalized = '" + type + "')";

		sql = sql + " Order by " +
						"HOT_Mach, " +
						"HOT_Day001, " +
						"HOT_Day002, " +
						"HOT_Day003, " +
						"HOT_Day004, " +
						"HOT_Day005, " +
						"HOT_Day006, " +
						"HOT_Day007, " +
						"HOT_Day008, " +
						"HOT_Day009, " +
						"HOT_Day010, " +
						"HOT_Day011, " +
						"HOT_Day012, " +
						"HOT_Day013, " +
						"HOT_Day014, " +
						"HOT_ProdID, " +
						"HOT_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readReportByMajorMinorGroup(int id, string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	NotNullDataReader reader = null;
	try{
		string sql = "Select * from hotlist, prodfminfo, pltdept ";
		
		bool existsWhere = false;
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;
	
		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
			
		sql +=	"DE_Dept = HOT_Dept and " +
				"rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) "; 
	
		if (filterDept.Length > 0){
			sql += " and HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
	
		if (filterPart.Length > 0){
			sql +=" and HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (filterMg.Length > 0){
			sql +=" and HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (onlyDemand){
			sql +=" and ((HOT_PastDue +";
			sql+=" HOT_Day001 +";
			sql+=" HOT_Day002 +";
			sql+=" HOT_Day003 +";
			sql+=" HOT_Day004 +";
			sql+=" HOT_Day005 +";
			sql+=" HOT_Day006 +";
			sql+=" HOT_Day007 +";
			sql+=" HOT_Day008 +";
			sql+=" HOT_Day009 +";
			sql+=" HOT_Day010 +";
			sql+=" HOT_Day011 +";
			sql+=" HOT_Day012 +";
			sql+=" HOT_Day013 +";
			sql+=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql += " and (HOT_Finalized = '" + type + "')";

		sql = sql + " Order by " +
						"HOT_MajorGroup, " + 
						"HOT_MinorGroup, " +
						"HOT_Day001, " +
						"HOT_Day002, " +
						"HOT_Day003, " +
						"HOT_Day004, " +
						"HOT_Day005, " +
						"HOT_Day006, " +
						"HOT_Day007, " +
						"HOT_Day008, " +
						"HOT_Day009, " +
						"HOT_Day010, " +
						"HOT_Day011, " +
						"HOT_Day012, " +
						"HOT_Day013, " +
						"HOT_Day014, " +
						"HOT_ProdID, " +
						"HOT_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readReportByPart(int id, string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	NotNullDataReader reader = null;
	try{
		string sql = "Select * from hotlist, prodfminfo, pltdept ";
		
		bool existsWhere = false;
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;
	
		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
			
		sql +=	"DE_Dept = HOT_Dept and " +
				"rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) "; 
	
		if (filterDept.Length > 0){
			sql += " and HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
	
		if (filterPart.Length > 0){
			sql +=" and HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (filterMg.Length > 0){
			sql +=" and HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (onlyDemand){
			sql +=" and ((HOT_PastDue +";
			sql+=" HOT_Day001 +";
			sql+=" HOT_Day002 +";
			sql+=" HOT_Day003 +";
			sql+=" HOT_Day004 +";
			sql+=" HOT_Day005 +";
			sql+=" HOT_Day006 +";
			sql+=" HOT_Day007 +";
			sql+=" HOT_Day008 +";
			sql+=" HOT_Day009 +";
			sql+=" HOT_Day010 +";
			sql+=" HOT_Day011 +";
			sql+=" HOT_Day012 +";
			sql+=" HOT_Day013 +";
			sql+=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql += " and (HOT_Finalized = '" + type + "')";

		sql = sql + " Order by " +
						"HOT_ProdID, " +
						"HOT_Seq desc";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readReportByMinGroup(int id,string[] filterDept, string[] filterPart, string[] filterMg, bool onlyDemand, string type){
	NotNullDataReader reader = null;
	try{
		string sql = "Select * from hotlist, prodfminfo, pltdept ";
		
		bool existsWhere = false;
		
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;
	
		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
		
		sql +=  "DE_Dept = HOT_Dept and " +
				"rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) "; 
	
		if (filterDept.Length > 0){
			sql += " and HOT_Dept in (";

			for(int i = 0; i < filterDept.Length; i++){
				sql += "'" + filterDept[i] + "'";
				if (i < filterDept.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
	
		if (filterPart.Length > 0){
			sql +=" and HOT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (filterMg.Length > 0){
			sql +=" and HOT_MinorGroup in (";
			for(int i = 0; i < filterMg.Length; i++){
				//sql += "'" + filterMg[i].Replace(" ","") + "'";
				sql += "'" + filterMg[i] + "'";
				if (i < filterMg.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		if (onlyDemand){
			sql +=" and ((HOT_PastDue +";
			sql+=" HOT_Day001 +";
			sql+=" HOT_Day002 +";
			sql+=" HOT_Day003 +";
			sql+=" HOT_Day004 +";
			sql+=" HOT_Day005 +";
			sql+=" HOT_Day006 +";
			sql+=" HOT_Day007 +";
			sql+=" HOT_Day008 +";
			sql+=" HOT_Day009 +";
			sql+=" HOT_Day010 +";
			sql+=" HOT_Day011 +";
			sql+=" HOT_Day012 +";
			sql+=" HOT_Day013 +";
			sql+=" HOT_Day014) <> 0)";
		}

		if (!type.Equals("B"))
			sql += " and (HOT_Finalized = '" + type + "')";

		sql = sql + " Order by " +
						"HOT_MinorGroup, " +
						"HOT_Day001, " +
						"HOT_Day002, " +
						"HOT_Day003, " +
						"HOT_Day004, " +
						"HOT_Day005, " +
						"HOT_Day006, " +
						"HOT_Day007, " +
						"HOT_Day008, " +
						"HOT_Day009, " +
						"HOT_Day010, " +
						"HOT_Day011, " +
						"HOT_Day012, " +
						"HOT_Day013, " +
						"HOT_Day014, " +
						"HOT_ProdID, " +
						"HOT_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(filterDept, filterPart, onlyDemand, type)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readReport(int id, string byPart){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hotlist, prodfminfo ";
		
		bool existsWhere = false;
		
		sql += "where HOT_Id = " + NumberUtil.toString(id); 
		existsWhere = true;

		if (existsWhere)
			sql += " and ";
		else
			sql += " where ";
			
		sql += "rtrim(hotlist.HOT_ProdID) = rtrim(prodfminfo.PFS_ProdID) "; 
		
		if (!byPart.Equals(""))
					sql = sql + " AND HOTLIST.HOT_ProdID = '"+Converter.fixString(byPart)+"'";
		sql = sql + "Order by " +
								"HOT_Dept, " +
							"HOT_MinorGroup, " +
							"HOT_Day001, " +
							"HOT_Day002, " +
							"HOT_Day003, " +
							"HOT_Day004, " +
							"HOT_Day005, " +
							"HOT_Day006, " +
							"HOT_Day007, " +
							"HOT_Day008, " +
							"HOT_Day009, " +
							"HOT_Day010, " +
							"HOT_Day011, " +
							"HOT_Day012, " +
							"HOT_Day013, " +
							"HOT_Day014, " +
							"HOT_ProdID, " +
							"HOT_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
			hotListDataBase.load(reader);
			this.Add(hotListDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(byPart)> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(byPart)> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readReport(byPart)> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
string[] getAllCfgFromHotListAsString(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(HOT_Mach) from hotlist"; 
		ArrayList array = new ArrayList();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string HOT_Mach = reader.GetString(0);
			this.Add(HOT_Mach);
		}
		string[] vec = new string[array.Count];
		for(int i = 0; i < array.Count; i ++)
			vec[i] = (string)array[i];
		return vec;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAllCfgFromHotListAsString> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAllCfgFromHotListAsString> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAllCfgFromHotListAsString> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
string[][] getHotListTotalAsString(int id){
	NotNullDataReader reader = null;
	try{
		string sql = "select HOT_Dept, HOT_Mach, " +
			"sum(HOT_Qoh), sum(HOT_QohCml), sum(HOT_PastDue), sum(HOT_Day001), " +
			"sum(HOT_Day002), sum(HOT_Day003), sum(HOT_Day004), sum(HOT_Day005), " +
			"sum(HOT_Day006), sum(HOT_Day007), sum(HOT_Day008), sum(HOT_Day009), " +
			"sum(HOT_Day010), sum(HOT_Day011), sum(HOT_Day012), sum(HOT_Day013), " +
			"sum(HOT_Day014), sum(HOT_Day015), sum(HOT_Day016), sum(HOT_Day017), " +
			"sum(HOT_Day018), sum(HOT_Day019), sum(HOT_Day020), sum(HOT_Day020), " +
			"sum(HOT_Day021), sum(HOT_Day022), sum(HOT_Day023), sum(HOT_Day024), " +
			"sum(HOT_Day025), sum(HOT_Day026), sum(HOT_Day027), sum(HOT_Day028), " +
			"sum(HOT_Day029), sum(HOT_Day030), sum(HOT_Day031), sum(HOT_Day032), " +
			"sum(HOT_Day033), sum(HOT_Day034), sum(HOT_Day035), sum(HOT_Day036), " +
			"sum(HOT_Day037), sum(HOT_Day038), sum(HOT_Day039), sum(HOT_Day040), " +
			"sum(HOT_Day041), sum(HOT_Day042), sum(HOT_Day043), sum(HOT_Day044), " +
			"sum(HOT_Day045), sum(HOT_Day046), sum(HOT_Day047), sum(HOT_Day048), " +
			"sum(HOT_Day049), sum(HOT_Day050), sum(HOT_Day051), sum(HOT_Day052), " +
			"sum(HOT_Day053), sum(HOT_Day054), sum(HOT_Day055), sum(HOT_Day056), " +
			"sum(HOT_Day057), sum(HOT_Day058), sum(HOT_Day059), sum(HOT_Day060), " +
			"sum(HOT_Day061), sum(HOT_Day062), sum(HOT_Day063), sum(HOT_Day064), " +
			"sum(HOT_Day065), sum(HOT_Day066), sum(HOT_Day067), sum(HOT_Day068), " +
			"sum(HOT_Day069), sum(HOT_Day070), sum(HOT_Day071), sum(HOT_Day072), " +
			"sum(HOT_Day073), sum(HOT_Day074), sum(HOT_Day075), sum(HOT_Day076), " +
			"sum(HOT_Day077), sum(HOT_Day078), sum(HOT_Day079), sum(HOT_Day080), " +
			"sum(HOT_Day081), sum(HOT_Day082), sum(HOT_Day083), sum(HOT_Day084), " +
			"sum(HOT_Day085), sum(HOT_Day086), sum(HOT_Day087), sum(HOT_Day088), " +
			"sum(HOT_Day089), sum(HOT_Day090) " +
		"from hotlist " +
		"where HOT_Id = " + NumberUtil.toString(id) +
		" group by HOT_Dept, HOT_Mach" + 
		" order by HOT_Dept, HOT_Mach";

		ArrayList array = new ArrayList();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string HOT_Dept = reader.GetString(0);
			string HOT_Mach = reader.GetString(1);
			decimal HOT_Qoh = reader.GetDecimal(2);
			decimal HOT_QohCml = reader.GetDecimal(3);
			decimal HOT_PastDue = NumberUtil.absolute(reader.GetDecimal(4));
			decimal HOT_Day001 = NumberUtil.absolute(reader.GetDecimal(5));
			decimal HOT_Day002 = NumberUtil.absolute(reader.GetDecimal(6));
			decimal HOT_Day003 = NumberUtil.absolute(reader.GetDecimal(7));
			decimal HOT_Day004 = NumberUtil.absolute(reader.GetDecimal(8));
			decimal HOT_Day005 = NumberUtil.absolute(reader.GetDecimal(9));
			decimal HOT_Day006 = NumberUtil.absolute(reader.GetDecimal(10));
			decimal HOT_Day007 = NumberUtil.absolute(reader.GetDecimal(11));
			decimal HOT_Day008 = NumberUtil.absolute(reader.GetDecimal(12));
			decimal HOT_Day009 = NumberUtil.absolute(reader.GetDecimal(13));
			decimal HOT_Day010 = NumberUtil.absolute(reader.GetDecimal(14));
			decimal HOT_Day011 = NumberUtil.absolute(reader.GetDecimal(15));
			decimal HOT_Day012 = NumberUtil.absolute(reader.GetDecimal(16));
			decimal HOT_Day013 = NumberUtil.absolute(reader.GetDecimal(17));
			decimal HOT_Day014 = NumberUtil.absolute(reader.GetDecimal(18));
			decimal HOT_Day015 = NumberUtil.absolute(reader.GetDecimal(19));
			decimal HOT_Day016 = NumberUtil.absolute(reader.GetDecimal(20));
			decimal HOT_Day017 = NumberUtil.absolute(reader.GetDecimal(21));
			decimal HOT_Day018 = NumberUtil.absolute(reader.GetDecimal(22));
			decimal HOT_Day019 = NumberUtil.absolute(reader.GetDecimal(23));
			decimal HOT_Day020 = NumberUtil.absolute(reader.GetDecimal(24));
			decimal HOT_Day021 = NumberUtil.absolute(reader.GetDecimal(25));
			decimal HOT_Day022 = NumberUtil.absolute(reader.GetDecimal(26));
			decimal HOT_Day023 = NumberUtil.absolute(reader.GetDecimal(27));
			decimal HOT_Day024 = NumberUtil.absolute(reader.GetDecimal(28));
			decimal HOT_Day025 = NumberUtil.absolute(reader.GetDecimal(29));
			decimal HOT_Day026 = NumberUtil.absolute(reader.GetDecimal(30));
			decimal HOT_Day027 = NumberUtil.absolute(reader.GetDecimal(31));
			decimal HOT_Day028 = NumberUtil.absolute(reader.GetDecimal(32));
			decimal HOT_Day029 = NumberUtil.absolute(reader.GetDecimal(33));
			decimal HOT_Day030 = NumberUtil.absolute(reader.GetDecimal(34));
			decimal HOT_Day031 = NumberUtil.absolute(reader.GetDecimal(35));
			decimal HOT_Day032 = NumberUtil.absolute(reader.GetDecimal(36));
			decimal HOT_Day033 = NumberUtil.absolute(reader.GetDecimal(37));
			decimal HOT_Day034 = NumberUtil.absolute(reader.GetDecimal(38));
			decimal HOT_Day035 = NumberUtil.absolute(reader.GetDecimal(39));
			decimal HOT_Day036 = NumberUtil.absolute(reader.GetDecimal(40));
			decimal HOT_Day037 = NumberUtil.absolute(reader.GetDecimal(41));
			decimal HOT_Day038 = NumberUtil.absolute(reader.GetDecimal(42));
			decimal HOT_Day039 = NumberUtil.absolute(reader.GetDecimal(43));
			decimal HOT_Day040 = NumberUtil.absolute(reader.GetDecimal(44));
			decimal HOT_Day041 = NumberUtil.absolute(reader.GetDecimal(45));
			decimal HOT_Day042 = NumberUtil.absolute(reader.GetDecimal(46));
			decimal HOT_Day043 = NumberUtil.absolute(reader.GetDecimal(47));
			decimal HOT_Day044 = NumberUtil.absolute(reader.GetDecimal(48));
			decimal HOT_Day045 = NumberUtil.absolute(reader.GetDecimal(49));
			decimal HOT_Day046 = NumberUtil.absolute(reader.GetDecimal(50));
			decimal HOT_Day047 = NumberUtil.absolute(reader.GetDecimal(51));
			decimal HOT_Day048 = NumberUtil.absolute(reader.GetDecimal(52));
			decimal HOT_Day049 = NumberUtil.absolute(reader.GetDecimal(53));
			decimal HOT_Day050 = NumberUtil.absolute(reader.GetDecimal(54));
			decimal HOT_Day051 = NumberUtil.absolute(reader.GetDecimal(55));
			decimal HOT_Day052 = NumberUtil.absolute(reader.GetDecimal(56));
			decimal HOT_Day053 = NumberUtil.absolute(reader.GetDecimal(57));
			decimal HOT_Day054 = NumberUtil.absolute(reader.GetDecimal(58));
			decimal HOT_Day055 = NumberUtil.absolute(reader.GetDecimal(59));
			decimal HOT_Day056 = NumberUtil.absolute(reader.GetDecimal(60));
			decimal HOT_Day057 = NumberUtil.absolute(reader.GetDecimal(61));
			decimal HOT_Day058 = NumberUtil.absolute(reader.GetDecimal(62));
			decimal HOT_Day059 = NumberUtil.absolute(reader.GetDecimal(63));
			decimal HOT_Day060 = NumberUtil.absolute(reader.GetDecimal(64));
			decimal HOT_Day061 = NumberUtil.absolute(reader.GetDecimal(65));
			decimal HOT_Day062 = NumberUtil.absolute(reader.GetDecimal(66));
			decimal HOT_Day063 = NumberUtil.absolute(reader.GetDecimal(67));
			decimal HOT_Day064 = NumberUtil.absolute(reader.GetDecimal(68));
			decimal HOT_Day065 = NumberUtil.absolute(reader.GetDecimal(69));
			decimal HOT_Day066 = NumberUtil.absolute(reader.GetDecimal(70));
			decimal HOT_Day067 = NumberUtil.absolute(reader.GetDecimal(71));
			decimal HOT_Day068 = NumberUtil.absolute(reader.GetDecimal(72));
			decimal HOT_Day069 = NumberUtil.absolute(reader.GetDecimal(73));
			decimal HOT_Day070 = NumberUtil.absolute(reader.GetDecimal(74));
			decimal HOT_Day071 = NumberUtil.absolute(reader.GetDecimal(75));
			decimal HOT_Day072 = NumberUtil.absolute(reader.GetDecimal(76));
			decimal HOT_Day073 = NumberUtil.absolute(reader.GetDecimal(77));
			decimal HOT_Day074 = NumberUtil.absolute(reader.GetDecimal(78));
			decimal HOT_Day075 = NumberUtil.absolute(reader.GetDecimal(79));
			decimal HOT_Day076 = NumberUtil.absolute(reader.GetDecimal(80));
			decimal HOT_Day077 = NumberUtil.absolute(reader.GetDecimal(81));
			decimal HOT_Day078 = NumberUtil.absolute(reader.GetDecimal(82));
			decimal HOT_Day079 = NumberUtil.absolute(reader.GetDecimal(83));
			decimal HOT_Day080 = NumberUtil.absolute(reader.GetDecimal(84));
			decimal HOT_Day081 = NumberUtil.absolute(reader.GetDecimal(85));
			decimal HOT_Day082 = NumberUtil.absolute(reader.GetDecimal(86));
			decimal HOT_Day083 = NumberUtil.absolute(reader.GetDecimal(87));
			decimal HOT_Day084 = NumberUtil.absolute(reader.GetDecimal(88));
			decimal HOT_Day085 = NumberUtil.absolute(reader.GetDecimal(89));
			decimal HOT_Day086 = NumberUtil.absolute(reader.GetDecimal(90));
			decimal HOT_Day087 = NumberUtil.absolute(reader.GetDecimal(91));
			decimal HOT_Day088 = NumberUtil.absolute(reader.GetDecimal(92));
			decimal HOT_Day089 = NumberUtil.absolute(reader.GetDecimal(93));
			decimal HOT_Day090 = NumberUtil.absolute(reader.GetDecimal(94));

			HOT_Day090 -= HOT_Day089;
			HOT_Day089 -= HOT_Day088;
			HOT_Day088 -= HOT_Day087;
			HOT_Day087 -= HOT_Day086;
			HOT_Day086 -= HOT_Day085;
			HOT_Day085 -= HOT_Day084;
			HOT_Day084 -= HOT_Day083;
			HOT_Day083 -= HOT_Day082;
			HOT_Day082 -= HOT_Day081;
			HOT_Day081 -= HOT_Day080;
			HOT_Day080 -= HOT_Day079;
			HOT_Day079 -= HOT_Day078;
			HOT_Day078 -= HOT_Day077;
			HOT_Day077 -= HOT_Day076;
			HOT_Day076 -= HOT_Day075;
			HOT_Day075 -= HOT_Day074;
			HOT_Day074 -= HOT_Day073;
			HOT_Day073 -= HOT_Day072;
			HOT_Day072 -= HOT_Day071;
			HOT_Day071 -= HOT_Day070;
			HOT_Day070 -= HOT_Day069;
			HOT_Day069 -= HOT_Day068;
			HOT_Day068 -= HOT_Day067;
			HOT_Day067 -= HOT_Day066;
			HOT_Day066 -= HOT_Day065;
			HOT_Day065 -= HOT_Day064;
			HOT_Day064 -= HOT_Day063;
			HOT_Day063 -= HOT_Day062;
			HOT_Day062 -= HOT_Day061;
			HOT_Day061 -= HOT_Day060;
			HOT_Day060 -= HOT_Day059;
			HOT_Day059 -= HOT_Day058;
			HOT_Day058 -= HOT_Day057;
			HOT_Day057 -= HOT_Day056;
			HOT_Day056 -= HOT_Day055;
			HOT_Day055 -= HOT_Day054;
			HOT_Day054 -= HOT_Day053;
			HOT_Day053 -= HOT_Day052;
			HOT_Day052 -= HOT_Day051;
			HOT_Day051 -= HOT_Day050;
			HOT_Day050 -= HOT_Day049;
			HOT_Day049 -= HOT_Day048;
			HOT_Day048 -= HOT_Day047;
			HOT_Day047 -= HOT_Day046;
			HOT_Day046 -= HOT_Day045;
			HOT_Day045 -= HOT_Day044;
			HOT_Day044 -= HOT_Day043;
			HOT_Day043 -= HOT_Day042;
			HOT_Day042 -= HOT_Day041;
			HOT_Day041 -= HOT_Day040;
			HOT_Day040 -= HOT_Day039;
			HOT_Day039 -= HOT_Day038;
			HOT_Day038 -= HOT_Day037;
			HOT_Day037 -= HOT_Day036;
			HOT_Day036 -= HOT_Day035;
			HOT_Day035 -= HOT_Day034;
			HOT_Day034 -= HOT_Day033;
			HOT_Day033 -= HOT_Day032;
			HOT_Day032 -= HOT_Day031;
			HOT_Day031 -= HOT_Day030;
			HOT_Day030 -= HOT_Day029;
			HOT_Day029 -= HOT_Day028;
			HOT_Day028 -= HOT_Day027;
			HOT_Day027 -= HOT_Day026;
			HOT_Day026 -= HOT_Day025;
			HOT_Day025 -= HOT_Day024;
			HOT_Day024 -= HOT_Day023;
			HOT_Day023 -= HOT_Day022;
			HOT_Day022 -= HOT_Day021;
			HOT_Day021 -= HOT_Day020;
			HOT_Day020 -= HOT_Day019;
			HOT_Day019 -= HOT_Day018;
			HOT_Day018 -= HOT_Day017;
			HOT_Day017 -= HOT_Day016;
			HOT_Day016 -= HOT_Day015;
			HOT_Day015 -= HOT_Day014;
			HOT_Day014 -= HOT_Day013;
			HOT_Day013 -= HOT_Day012;
			HOT_Day012 -= HOT_Day011;
			HOT_Day011 -= HOT_Day010;
			HOT_Day010 -= HOT_Day009;
			HOT_Day009 -= HOT_Day008;
			HOT_Day008 -= HOT_Day007;
			HOT_Day007 -= HOT_Day006;
			HOT_Day006 -= HOT_Day005;
			HOT_Day005 -= HOT_Day004;
			HOT_Day004 -= HOT_Day003;
			HOT_Day003 -= HOT_Day002;
			HOT_Day002 -= HOT_Day001;
			HOT_Day001 -= HOT_PastDue;
			
			string[] line = new string[95];
			line[0] = HOT_Dept;
			line[1] = HOT_Mach;
			line[2] = NumberUtil.toString(HOT_Qoh);
			line[3] = NumberUtil.toString(HOT_QohCml);
			line[4] = NumberUtil.toString(HOT_PastDue);
			line[5] = NumberUtil.toString(HOT_Day001);
			line[6] = NumberUtil.toString(HOT_Day002);
			line[7] = NumberUtil.toString(HOT_Day003);
			line[8] = NumberUtil.toString(HOT_Day004);
			line[9] = NumberUtil.toString(HOT_Day005);
			line[10] = NumberUtil.toString(HOT_Day006);
			line[11] = NumberUtil.toString(HOT_Day007);
			line[12] = NumberUtil.toString(HOT_Day008);
			line[13] = NumberUtil.toString(HOT_Day009);
			line[14] = NumberUtil.toString(HOT_Day010);
			line[15] = NumberUtil.toString(HOT_Day011);
			line[16] = NumberUtil.toString(HOT_Day012);
			line[17] = NumberUtil.toString(HOT_Day013);
			line[18] = NumberUtil.toString(HOT_Day014);
			line[19] = NumberUtil.toString(HOT_Day015);
			line[20] = NumberUtil.toString(HOT_Day016);
			line[21] = NumberUtil.toString(HOT_Day017);
			line[22] = NumberUtil.toString(HOT_Day018);
			line[23] = NumberUtil.toString(HOT_Day019);
			line[24] = NumberUtil.toString(HOT_Day020);
			line[25] = NumberUtil.toString(HOT_Day021);
			line[26] = NumberUtil.toString(HOT_Day022);
			line[27] = NumberUtil.toString(HOT_Day023);
			line[28] = NumberUtil.toString(HOT_Day024);
			line[29] = NumberUtil.toString(HOT_Day025);
			line[30] = NumberUtil.toString(HOT_Day026);
			line[31] = NumberUtil.toString(HOT_Day027);
			line[32] = NumberUtil.toString(HOT_Day028);
			line[33] = NumberUtil.toString(HOT_Day029);
			line[34] = NumberUtil.toString(HOT_Day030);
			line[35] = NumberUtil.toString(HOT_Day031);
			line[36] = NumberUtil.toString(HOT_Day032);
			line[37] = NumberUtil.toString(HOT_Day033);
			line[38] = NumberUtil.toString(HOT_Day034);
			line[39] = NumberUtil.toString(HOT_Day035);
			line[40] = NumberUtil.toString(HOT_Day036);
			line[41] = NumberUtil.toString(HOT_Day037);
			line[42] = NumberUtil.toString(HOT_Day038);
			line[43] = NumberUtil.toString(HOT_Day039);
			line[44] = NumberUtil.toString(HOT_Day040);
			line[45] = NumberUtil.toString(HOT_Day041);
			line[46] = NumberUtil.toString(HOT_Day042);
			line[47] = NumberUtil.toString(HOT_Day043);
			line[48] = NumberUtil.toString(HOT_Day044);
			line[49] = NumberUtil.toString(HOT_Day045);
			line[50] = NumberUtil.toString(HOT_Day046);
			line[51] = NumberUtil.toString(HOT_Day047);
			line[52] = NumberUtil.toString(HOT_Day048);
			line[53] = NumberUtil.toString(HOT_Day049);
			line[54] = NumberUtil.toString(HOT_Day050);
			line[55] = NumberUtil.toString(HOT_Day051);
			line[56] = NumberUtil.toString(HOT_Day052);
			line[57] = NumberUtil.toString(HOT_Day053);
			line[58] = NumberUtil.toString(HOT_Day054);
			line[59] = NumberUtil.toString(HOT_Day055);
			line[60] = NumberUtil.toString(HOT_Day056);
			line[61] = NumberUtil.toString(HOT_Day057);
			line[62] = NumberUtil.toString(HOT_Day058);
			line[63] = NumberUtil.toString(HOT_Day059);
			line[64] = NumberUtil.toString(HOT_Day060);
			line[65] = NumberUtil.toString(HOT_Day061);
			line[66] = NumberUtil.toString(HOT_Day062);
			line[67] = NumberUtil.toString(HOT_Day063);
			line[68] = NumberUtil.toString(HOT_Day064);
			line[69] = NumberUtil.toString(HOT_Day065);
			line[70] = NumberUtil.toString(HOT_Day066);
			line[71] = NumberUtil.toString(HOT_Day067);
			line[72] = NumberUtil.toString(HOT_Day068);
			line[73] = NumberUtil.toString(HOT_Day069);
			line[74] = NumberUtil.toString(HOT_Day070);
			line[75] = NumberUtil.toString(HOT_Day071);
			line[76] = NumberUtil.toString(HOT_Day072);
			line[77] = NumberUtil.toString(HOT_Day073);
			line[78] = NumberUtil.toString(HOT_Day074);
			line[79] = NumberUtil.toString(HOT_Day075);
			line[80] = NumberUtil.toString(HOT_Day076);
			line[81] = NumberUtil.toString(HOT_Day077);
			line[82] = NumberUtil.toString(HOT_Day078);
			line[83] = NumberUtil.toString(HOT_Day079);
			line[84] = NumberUtil.toString(HOT_Day080);
			line[85] = NumberUtil.toString(HOT_Day081);
			line[86] = NumberUtil.toString(HOT_Day082);
			line[87] = NumberUtil.toString(HOT_Day083);
			line[88] = NumberUtil.toString(HOT_Day084);
			line[89] = NumberUtil.toString(HOT_Day085);
			line[90] = NumberUtil.toString(HOT_Day086);
			line[91] = NumberUtil.toString(HOT_Day087);
			line[92] = NumberUtil.toString(HOT_Day088);
			line[93] = NumberUtil.toString(HOT_Day089);
			line[94] = NumberUtil.toString(HOT_Day090);

			array.Add(line);
		}

		string[][] mat = new string[array.Count][];
		for(int i = 0; i < array.Count; i ++){
			string[] line = (string[])array[i];
			mat[i] = line;
		}

		return mat;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAllCfgFromHotListAsString> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAllCfgFromHotListAsString> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAllCfgFromHotListAsString> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

protected
string readBaseByFilters(int id,string splant, string sdept, string smachine, int imachineId, string spart,int iseq,string smajorGroup,string sglExp,string sreportedPoint,string sprodFamily,string sfieldDay=""){
    string sql      = " ";
    
    if (id > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " HOT_Id = " + NumberUtil.toString(id);

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("HOT_Plt",splant);
    if (!string.IsNullOrEmpty(sdept))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("HOT_Dept",sdept);
    if (!string.IsNullOrEmpty(smachine))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("HOT_Mach",smachine);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("HOT_ProdID",spart);
    if (iseq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " HOT_Seq = " + NumberUtil.toString(iseq);

    if (imachineId > 0){                            
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            " select m.PDM_ID from pltdeptmach m " +
            " where  m.PDM_ID = " + imachineId +
            " and (m.PDM_Plt = HOT_Plt or HOT_Plt='') and m.PDM_Dept = HOT_Dept and m.PDM_Mach=HOT_Mach " +
            " )";
    }

    if (!string.IsNullOrEmpty(smajorGroup))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("HOT_MajorGroup",smajorGroup);

    if (!string.IsNullOrEmpty(sglExp)){
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            "select PFS_GLExp from prodfminfo where  PFS_ProdID = HOT_ProdID and " + DBFormatter.equalLikeSql("PFS_GLExp",sglExp) + ")";
    }

    if (!string.IsNullOrEmpty(sreportedPoint)){
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            " select p.PC_ProdID from prodfmactsub p where " +
            " p.PC_ProdID = HOT_ProdID and p.PC_Plt = HOT_Plt and p.PC_Dept = HOT_Dept and p.PC_Seq = HOT_Seq " +
            " and p.PC_Cfg = HOT_Mach and p.PC_RepPoint = '" + sreportedPoint + "'" +
            " )";
    }

    if (!string.IsNullOrEmpty(sprodFamily)) {
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            " select p.PFS_ProdID from prodfminfo p where " +
            " HOT_ProdID = PFS_ProdID and p.PFS_FamProd = '" + sprodFamily + "'" +
            " )";                
    }

    if (!string.IsNullOrEmpty(sfieldDay)) 
        sql = DBFormatter.addWhereAndSentence(sql) + sfieldDay +  " <> 0";                
                      
    sql = DBFormatter.addWhereAndSentence(sql);
    sql+= " (HOt_dept <> '' and HOt_dept is not null) ";

    return sql;
}

public
void readByFilters(int id,string splant, string sdept, string smachine, int imachineId, string spart,int iseq,string smajorGroup,string sglExp,string srepPoint,string sprodFamily,string sfieldDay,bool borderByDemand, int rows){
    string sql = "select * from hotlist";

    sql+= readBaseByFilters(id,splant,sdept,smachine,imachineId,spart,iseq,smajorGroup,sglExp,srepPoint,sprodFamily,sfieldDay);
    
    sql += " order by ";
    if (borderByDemand)
        sql+= orderByDemand();
    else
        sql+= "HOT_Dept,HOT_Mach,HOT_ProdID,HOT_Seq";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

protected
string orderByDemand(){
    string sql = " " + 
		"HOT_Dept,HOT_MinorGroup,HOT_Day001,HOT_Day002,HOT_Day003,HOT_Day004,HOT_Day005,HOT_Day006,"+
		"HOT_Day007,HOT_Day008,HOT_Day009,HOT_Day010,HOT_Day011,HOT_Day012,HOT_Day013,HOT_Day014,"+
		"HOT_Day015,HOT_Day016,HOT_Day017,HOT_Day018,HOT_Day019,HOT_Day020,HOT_Day021,HOT_Day022,"+
		"HOT_Day023,HOT_Day024,HOT_Day025,HOT_Day026,HOT_Day027,HOT_Day028,HOT_Day029,HOT_Day030,"+
		"HOT_Day031,HOT_Day032,HOT_Day033,HOT_Day034,HOT_Day035,HOT_Day036,HOT_Day037,HOT_Day038,"+
		"HOT_Day039,HOT_Day040,HOT_Day041,HOT_Day042,HOT_Day043,HOT_Day044,HOT_Day045,HOT_Day046,"+
		"HOT_Day047,HOT_Day048,HOT_Day049,HOT_Day050,HOT_Day051,HOT_Day052,HOT_Day053,HOT_Day054,"+
		"HOT_Day055,HOT_Day056,HOT_Day057,HOT_Day058,HOT_Day059,HOT_Day060," +
		"HOT_Day061,HOT_Day062,HOT_Day063,HOT_Day064,HOT_Day065,HOT_Day066,HOT_Day067,HOT_Day068,"+
		"HOT_Day069,HOT_Day070,HOT_Day071,HOT_Day072,HOT_Day073,HOT_Day074,HOT_Day075,HOT_Day076,"+
		"HOT_Day077,HOT_Day078,HOT_Day079,HOT_Day080,HOT_Day081,HOT_Day082,HOT_Day083,HOT_Day084,"+
		"HOT_Day085,HOT_Day086,HOT_Day087,HOT_Day088,HOT_Day089,HOT_Day090," +
		"HOT_ProdID desc, HOT_Seq desc";
    return sql;
}

public
void readByFiltersWeekly(int id,string splant, string sdept, string smachine, int imachineId, string spart,int iseq,string smajorGroup,string sglExp,string sreportedPoint,string sfieldDay,bool borderByDemand,ArrayList sfieldList,int rows){
  	NotNullDataReader reader = null;
	try{
        string sql = "select HOT_IdAut,HOT_Id,HOT_ProdID,HOT_ActID,HOT_Seq,HOT_Uom,HOT_Dept,HOT_Mach,HOT_MachCyc,HOT_Qoh,HOT_QohCml,HOT_MinorGroup,HOT_MajorGroup,HOT_Finalized,HOT_Type,HOT_MainMaterial,HOT_MainMaterialSeq,HOT_MainMaterialQoh,HOT_Plt";
        string sqlQty = ",HOT_PastDue";

        for (int i=0; i < sfieldList.Count;i++)
            sqlQty+= "," + (string)sfieldList[i];
        sql+= sqlQty + " from hotlist";

        sql+= readBaseByFilters(id,splant,sdept,smachine,imachineId,spart,iseq,smajorGroup,sglExp,sreportedPoint,"",sfieldDay);
        
        sql += " order by ";
        if (borderByDemand)
            sql+= orderByDemand();
        else
            sql+= "HOT_Dept,HOT_Mach,HOT_ProdID,HOT_Seq";

	    if (rows > 0)
		    sql = DBFormatter.selectTopRows(sql,rows);
	    

	    reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
            HotListDataBase hotListDataBase = new HotListDataBase(dataBaseAccess);
            hotListDataBase.setHOT_IdAut(reader.GetInt32("HOT_IdAut"));
            hotListDataBase.setHOT_Id(reader.GetInt32("HOT_Id"));
	        hotListDataBase.setHOT_ProdID(reader.GetString("HOT_ProdID"));
	        hotListDataBase.setHOT_ActID(reader.GetString("HOT_ActID"));
	        hotListDataBase.setHOT_Seq(reader.GetInt32("HOT_Seq"));
	        hotListDataBase.setHOT_Uom(reader.GetString("HOT_Uom"));
	        hotListDataBase.setHOT_Dept(reader.GetString("HOT_Dept"));
	        hotListDataBase.setHOT_Mach(reader.GetString("HOT_Mach"));
	        hotListDataBase.setHOT_MachCyc(reader.GetDecimal("HOT_MachCyc"));
	        hotListDataBase.setHOT_Qoh(reader.GetDecimal("HOT_Qoh"));
	        hotListDataBase.setHOT_QohCml(reader.GetDecimal("HOT_QohCml"));
	        hotListDataBase.setHOT_PastDue(reader.GetDecimal("HOT_PastDue"));
	    

	        hotListDataBase.setHOT_MajorGroup(reader.GetString("HOT_MajorGroup"));
	        hotListDataBase.setHOT_MinorGroup(reader.GetString("HOT_MinorGroup"));
	        hotListDataBase.setHOT_Finalized(reader.GetString("HOT_Finalized"));
	        hotListDataBase.setHOT_Type(reader.GetString("HOT_Type"));

	        hotListDataBase.setHOT_MainMaterial(reader.GetString("HOT_MainMaterial"));
	        hotListDataBase.setHOT_MainMaterialSeq(reader.GetInt32("HOT_MainMaterialSeq"));
	        hotListDataBase.setHOT_MainMaterialQoh(reader.GetDecimal("HOT_MainMaterialQoh"));
            hotListDataBase.setHOT_Plt(reader.GetString("HOT_Plt"));
            
            decimal dpriorQty=0;
            for (int i=0; i < sfieldList.Count; i++) { 
                string sfieldName =  (string)sfieldList[i];
                switch (sfieldName){
                    case "HOT_Day001" : hotListDataBase.setHOT_Day001(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day002" : hotListDataBase.setHOT_Day002(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day003" : hotListDataBase.setHOT_Day003(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day004" : hotListDataBase.setHOT_Day004(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day005" : hotListDataBase.setHOT_Day005(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day006" : hotListDataBase.setHOT_Day006(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day007" : hotListDataBase.setHOT_Day007(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day008" : hotListDataBase.setHOT_Day008(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day009" : hotListDataBase.setHOT_Day009(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day010" : hotListDataBase.setHOT_Day010(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day011" : hotListDataBase.setHOT_Day011(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day012" : hotListDataBase.setHOT_Day012(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day013" : hotListDataBase.setHOT_Day013(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day014" : hotListDataBase.setHOT_Day014(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day015" : hotListDataBase.setHOT_Day015(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day016" : hotListDataBase.setHOT_Day016(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day017" : hotListDataBase.setHOT_Day017(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day018" : hotListDataBase.setHOT_Day018(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day019" : hotListDataBase.setHOT_Day019(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day020" : hotListDataBase.setHOT_Day020(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day021" : hotListDataBase.setHOT_Day021(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day022" : hotListDataBase.setHOT_Day022(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day023" : hotListDataBase.setHOT_Day023(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day024" : hotListDataBase.setHOT_Day024(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day025" : hotListDataBase.setHOT_Day025(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day026" : hotListDataBase.setHOT_Day026(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day027" : hotListDataBase.setHOT_Day027(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day028" : hotListDataBase.setHOT_Day028(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day029" : hotListDataBase.setHOT_Day029(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day030" : hotListDataBase.setHOT_Day030(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day031" : hotListDataBase.setHOT_Day031(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day032" : hotListDataBase.setHOT_Day032(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day033" : hotListDataBase.setHOT_Day033(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day034" : hotListDataBase.setHOT_Day034(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day035" : hotListDataBase.setHOT_Day035(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day036" : hotListDataBase.setHOT_Day036(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day037" : hotListDataBase.setHOT_Day037(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day038" : hotListDataBase.setHOT_Day038(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day039" : hotListDataBase.setHOT_Day039(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day040" : hotListDataBase.setHOT_Day040(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day041" : hotListDataBase.setHOT_Day041(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day042" : hotListDataBase.setHOT_Day042(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day043" : hotListDataBase.setHOT_Day043(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day044" : hotListDataBase.setHOT_Day044(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day045" : hotListDataBase.setHOT_Day045(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day046" : hotListDataBase.setHOT_Day046(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day047" : hotListDataBase.setHOT_Day047(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day048" : hotListDataBase.setHOT_Day048(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day049" : hotListDataBase.setHOT_Day049(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day050" : hotListDataBase.setHOT_Day050(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day051" : hotListDataBase.setHOT_Day051(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day052" : hotListDataBase.setHOT_Day052(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day053" : hotListDataBase.setHOT_Day053(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day054" : hotListDataBase.setHOT_Day054(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day055" : hotListDataBase.setHOT_Day055(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day056" : hotListDataBase.setHOT_Day056(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day057" : hotListDataBase.setHOT_Day057(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day058" : hotListDataBase.setHOT_Day058(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day059" : hotListDataBase.setHOT_Day059(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day060" : hotListDataBase.setHOT_Day060(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day061" : hotListDataBase.setHOT_Day061(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day062" : hotListDataBase.setHOT_Day062(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day063" : hotListDataBase.setHOT_Day063(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day064" : hotListDataBase.setHOT_Day064(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day065" : hotListDataBase.setHOT_Day065(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day066" : hotListDataBase.setHOT_Day066(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day067" : hotListDataBase.setHOT_Day067(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day068" : hotListDataBase.setHOT_Day068(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day069" : hotListDataBase.setHOT_Day069(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day070" : hotListDataBase.setHOT_Day070(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day071" : hotListDataBase.setHOT_Day071(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day072" : hotListDataBase.setHOT_Day072(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day073" : hotListDataBase.setHOT_Day073(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day074" : hotListDataBase.setHOT_Day074(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day075" : hotListDataBase.setHOT_Day075(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day076" : hotListDataBase.setHOT_Day076(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day077" : hotListDataBase.setHOT_Day077(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day078" : hotListDataBase.setHOT_Day078(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day079" : hotListDataBase.setHOT_Day079(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day080" : hotListDataBase.setHOT_Day080(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day081" : hotListDataBase.setHOT_Day081(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day082" : hotListDataBase.setHOT_Day082(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day083" : hotListDataBase.setHOT_Day083(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day084" : hotListDataBase.setHOT_Day084(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day085" : hotListDataBase.setHOT_Day085(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day086" : hotListDataBase.setHOT_Day086(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day087" : hotListDataBase.setHOT_Day087(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day088" : hotListDataBase.setHOT_Day088(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day089" : hotListDataBase.setHOT_Day089(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day090" : hotListDataBase.setHOT_Day090(reader.GetDecimal(sfieldName));break;                                        
                }                               
            }


		    this.Add(hotListDataBase);
		}

		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersWeekly> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersWeekly> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersWeekly> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void deleteByIdAllQtyZero(int id){
	string sql ="delete from hotlist where HOT_Id = " + NumberUtil.toString(id) +
            " and HOT_Day001 = 0 and HOT_Day002 = 0 and HOT_Day003 = 0 and HOT_Day004 = 0 and HOT_Day005 = 0 and HOT_Day006 = 0 and HOT_Day007 = 0 and HOT_Day008 = 0 and HOT_Day009 = 0 and HOT_Day010 = 0 " +
            " and HOT_Day011 = 0 and HOT_Day012 = 0 and HOT_Day013 = 0 and HOT_Day014 = 0 and HOT_Day015 = 0 and HOT_Day016 = 0 and HOT_Day017 = 0 and HOT_Day018 = 0 and HOT_Day019 = 0 and HOT_Day020 = 0 " +
            " and HOT_Day021 = 0 and HOT_Day022 = 0 and HOT_Day023 = 0 and HOT_Day024 = 0 and HOT_Day025 = 0 and HOT_Day026 = 0 and HOT_Day027 = 0 and HOT_Day028 = 0 and HOT_Day029 = 0 and HOT_Day030 = 0 " +
            " and HOT_Day031 = 0 and HOT_Day032 = 0 and HOT_Day033 = 0 and HOT_Day034 = 0 and HOT_Day035 = 0 and HOT_Day036 = 0 and HOT_Day037 = 0 and HOT_Day038 = 0 and HOT_Day039 = 0 and HOT_Day040 = 0 " +
            " and HOT_Day041 = 0 and HOT_Day042 = 0 and HOT_Day043 = 0 and HOT_Day044 = 0 and HOT_Day045 = 0 and HOT_Day046 = 0 and HOT_Day047 = 0 and HOT_Day048 = 0 and HOT_Day049 = 0 and HOT_Day050 = 0 " +
            " and HOT_Day051 = 0 and HOT_Day052 = 0 and HOT_Day053 = 0 and HOT_Day054 = 0 and HOT_Day055 = 0 and HOT_Day056 = 0 and HOT_Day057 = 0 and HOT_Day058 = 0 and HOT_Day059 = 0 and HOT_Day060 = 0 " +
            " and HOT_Day061 = 0 and HOT_Day062 = 0 and HOT_Day063 = 0 and HOT_Day064 = 0 and HOT_Day065 = 0 and HOT_Day066 = 0 and HOT_Day067 = 0 and HOT_Day068 = 0 and HOT_Day069 = 0 and HOT_Day070 = 0 " +
            " and HOT_Day071 = 0 and HOT_Day072 = 0 and HOT_Day073 = 0 and HOT_Day074 = 0 and HOT_Day075 = 0 and HOT_Day076 = 0 and HOT_Day077 = 0 and HOT_Day078 = 0 and HOT_Day079 = 0 and HOT_Day080 = 0 " +
            " and HOT_Day081 = 0 and HOT_Day082 = 0 and HOT_Day083 = 0 and HOT_Day084 = 0 and HOT_Day085 = 0 and HOT_Day086 = 0 and HOT_Day087 = 0 and HOT_Day088 = 0 and HOT_Day089 = 0 and HOT_Day090 = 0 ";
    delete(sql);        		
}

} // class

} // namespace