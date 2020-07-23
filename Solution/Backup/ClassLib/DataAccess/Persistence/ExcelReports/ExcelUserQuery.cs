using System;
using System.Collections;
using System.Text;
using  Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace  Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel{

public class ExcelUserQuery{

private string excelTable;
private ArrayList columns;
private ArrayList data;

public ExcelUserQuery(string excelTable){
	this.excelTable=excelTable;
	columns=new ArrayList();
	data=new ArrayList();
}

public
void addColumn(string columnName, string columnType){
	columns.Add(new ExcelColumn(columnName,columnType));
}

public
void addRow(string[] row){
	data.Add(row);
}

public
string getCreateSql(){
	StringBuilder create = new StringBuilder();
	create.Append("CREATE TABLE ["+excelTable+"](");
	if(columns.Count>0){
		for(int i=0; i<columns.Count; i++){
			ExcelColumn excelColumn = (ExcelColumn)columns[i];
			string column = excelColumn.getName();
			create.Append("["+column+"] "+excelColumn.getExcelType());
			if(i<columns.Count-1){
				create.Append(", ");
			}
		}
	}
	else
		create.Append("[NoDataFound] TEXT");
	create.Append(")");
	return create.ToString();
}

public
string getDropSheetSql(){
	return "DROP TABLE ["+excelTable+"$]";
}

public
string getDropTableSql(){
	return "DROP TABLE ["+excelTable+"]";
}

public
ArrayList getInsertSqls(){
 	ArrayList inserts = new ArrayList();
	foreach(string[] row in data){
		StringBuilder insert = new StringBuilder();
		insert.Append("insert into ["+excelTable+"] values");
		insert.Append("(");
		for(int i=0; i<columns.Count; i++){
			insert.Append(getSqlValue(row[i],i));
			if(i<columns.Count-1){
				insert.Append(", ");
			}
		}
		insert.Append(")");
		inserts.Add(insert.ToString());
	}
	return inserts;
}

private
string getSqlValue(string value, int i){
	switch(((ExcelColumn)this.columns[i]).getExcelType()){
		case "TEXT":
			return "'"+Converter.fixString(value)+"'";
		case "NUMBER":
			double doubleValue=0;
			try{
				doubleValue = double.Parse(value);
			}
			catch(Exception){
				doubleValue = 0;
			}
			return NumberUtil.toString(doubleValue);
		case "DATETIME":
			if(value.Equals(string.Empty))
				value=DateTime.MinValue.ToString();
			return "'"+Converter.fixString(value)+"'";
		default:
			return "'"+Converter.fixString(value)+"'";
	}
}

private
class ExcelColumn{
private string name;
private string type;
public
ExcelColumn(string name, string type){
	this.name=name;
	switch(type){
		case "System.String":
			this.type="TEXT";
			break;
		case "System.Int16":
			this.type="NUMBER";
			break;
		case "System.Int32":
			this.type="NUMBER";
			break;
		case "System.Int64":
			this.type="NUMBER";
			break;
		case "System.Bit":
			this.type="LOGICAL";
			break;
		case "System.DateTime":
			this.type="DATETIME";
			break;
		case "System.TimeSpan":
			this.type="DATETIME";
			break;
		case "System.Double":
			this.type="NUMBER";
			break;
		case "System.Decimal":
			this.type="NUMBER";
			break;
		default:
			this.type="TEXT";
			break;
	}
}
public
string getName(){
	return name;
}

public
string getExcelType(){
	return type;
}
}
}
}
