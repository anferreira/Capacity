using System;
using System.Text;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core.ExcelReports{


[Serializable]
public
class ExcelReportSetup : MarshalByRefObject{

private string reportName;
private string path;
private string fileName;
private string sqlSentence;
private string type;
private string pivotTablePath;

internal
ExcelReportSetup(){
	this.reportName = "";
	this.path = "";
	this.fileName = "";
	this.sqlSentence = "";
	this.type = "";
	this.pivotTablePath = "";
}

internal
ExcelReportSetup(
				string reportName,
				string path,
				string fileName,
				string sqlSentence,
				string type,
				string pivotTable)
{
	this.reportName = reportName;
	this.path = path;
	this.fileName = fileName;
	this.sqlSentence = sqlSentence;
	this.type = type;
	this.pivotTablePath = pivotTable;
}

public
void setReportName(string reportName){
	this.reportName = reportName;
}

public
void setPath(string path){
	this.path = path;
}

public
void setFileName(string fileName){
	this.fileName = fileName;
}

public
void setSqlSentence(string sqlSentence){
	this.sqlSentence = sqlSentence;
}

public
void setType(string type){
	this.type = type;
}

public
void setPivotTablePath(string pivotTable){
	this.pivotTablePath = pivotTable;
}

public
string getReportName(){
	 return reportName;
}

public
string getPath(){
	 return path;
}

public
string getFileName(){
	 return fileName;
}

public
string getSqlSentence(){
	 return sqlSentence;
}

public
string getSqlSentenceUnformatted(){
    StringBuilder sb = new StringBuilder();
	for(int i=0; i<sqlSentence.Length; i++){
		if(!sqlSentence[i].Equals('\r')&&!sqlSentence[i].Equals('\n'))
			sb.Append(sqlSentence[i]);
		else if (sqlSentence[i].Equals('\r'))
			sb.Append(' ');
	}
	return sb.ToString();
}

public
string getType(){
	 return type;
}


public
string getPivotTablePath(){
	 return this.pivotTablePath;
}

public override
bool Equals(object obj){
	if (obj is ExcelReportSetup)
		return	this.reportName.Equals(((ExcelReportSetup)obj).getReportName());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // package