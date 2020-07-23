using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace  Nujit.NujitERP.ClassLib.DataAccess.Persistence.ExcelReports{


public
class ExcelReportsSetupDataBase : GenericDataBaseElement{

private string EXC_ReportName;
private string EXC_Path;
private string EXC_FileName;
private string EXC_SqlSentence;
private string EXC_Type;
private string EXC_PivotTablePath;

public
ExcelReportsSetupDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from excelreportssetup where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	string sql = "select * from excelreportssetup where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.EXC_ReportName = reader.GetString("EXC_ReportName");
	this.EXC_Path = reader.GetString("EXC_Path");
	this.EXC_FileName = reader.GetString("EXC_FileName");
	this.EXC_SqlSentence = reader.GetString("EXC_SqlSentence");
	this.EXC_Type = reader.GetString("EXC_Type");
	this.EXC_PivotTablePath = reader.GetString("EXC_PivotTablePath");
}

public override
void write(){
	string sql = "insert into excelreportssetup(" + 
		"EXC_ReportName," +
		"EXC_Path," +
		"EXC_FileName," +
		"EXC_SqlSentence," +
		"EXC_Type," +
		"EXC_PivotTablePath" +
		") values (" + 

		"'" + Converter.fixString(EXC_ReportName) + "'," +
		"'" + Converter.fixString(EXC_Path) + "'," +
		"'" + Converter.fixString(EXC_FileName) + "'," +
		"'" + Converter.fixString(EXC_SqlSentence) + "'," +
		"'" + Converter.fixString(EXC_Type) +			"'," +
		"'" + Converter.fixString(EXC_PivotTablePath) +	"')";
	write(sql);
}

public override
void update(){
	string sql = "update excelreportssetup set " +
		"EXC_ReportName = '" + Converter.fixString(EXC_ReportName) + "', " +
		"EXC_Path = '" + Converter.fixString(EXC_Path) + "', " +
		"EXC_FileName = '" + Converter.fixString(EXC_FileName) + "', " +
		"EXC_SqlSentence = '" + Converter.fixString(EXC_SqlSentence) + "', " +
		"EXC_Type = '" + Converter.fixString(EXC_Type) + "', " +
		"EXC_PivotTablePath = '" + Converter.fixString(EXC_PivotTablePath) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from excelreportssetup where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"EXC_ReportName = '" + Converter.fixString(EXC_ReportName) + "'";
	return sqlWhere;
}

public
void setEXC_ReportName(string EXC_ReportName){
	this.EXC_ReportName = EXC_ReportName;
}

public
void setEXC_Path(string EXC_Path){
	this.EXC_Path = EXC_Path;
}

public
void setEXC_FileName(string EXC_FileName){
	this.EXC_FileName = EXC_FileName;
}

public
void setEXC_SqlSentence(string EXC_SqlSentence){
	this.EXC_SqlSentence = EXC_SqlSentence;
}

public
void setEXC_Type(string EXC_Type){
	this.EXC_Type = EXC_Type;
}

public
void setEXC_PivotTablePath(string EXC_PivotTablePath){
	this.EXC_PivotTablePath = EXC_PivotTablePath;
}

public
string getEXC_ReportName(){
	return EXC_ReportName;
}

public
string getEXC_Path(){
	return EXC_Path;
}

public
string getEXC_FileName(){
	return EXC_FileName;
}

public
string getEXC_SqlSentence(){
	return EXC_SqlSentence;
}

public
string getEXC_Type(){
	return EXC_Type;
}

public
string getEXC_PivotTablePath(){
	return EXC_PivotTablePath;
}

} // class

} // package