using System;
using System.Data;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{
	
public 
class NotNullDataReader{


private IDataReader dataReader;

public 
NotNullDataReader(IDataReader dataReader){
	this.dataReader = dataReader;
}

public 
void Close(){
	this.dataReader.Close();
	this.dataReader = null;
}

public 
bool Read(){
	try{
		return this.dataReader.Read();
	}catch(System.NullReferenceException){
		return false;
	}
}

private
int GetOrdinal(string fieldName){
	try{
		return dataReader.GetOrdinal(fieldName.Trim());
	}catch(System.IndexOutOfRangeException e){
		throw new System.Data.DataException(e.Message);
	}
}

public
string GetFieldName(int ordinal){
	try{
		return dataReader.GetName(ordinal);
	}catch(System.IndexOutOfRangeException e){
		throw new System.Data.DataException(e.Message);
	}
}

public
int ColumnCount(){
	try{
		return dataReader.FieldCount;
	}catch(System.IndexOutOfRangeException e){
		throw new System.Data.DataException(e.Message);
	}
}

public
string GetFieldDataType(int ordinal){
	try{
		DataTable schema = dataReader.GetSchemaTable();
		return schema.Rows[ordinal]["DataType"].ToString();
	}catch(System.IndexOutOfRangeException e){
		throw new System.Data.DataException(e.Message);
	}
}

//GetString
public
string GetString(string fieldName){
	return GetString(this.GetOrdinal(fieldName));	
}

public
string GetString(int i){
	if (dataReader.IsDBNull(i)){
		return "";
	}
	return dataReader.GetString(i).Trim();
}

public 
double GetDouble(int i){
	if (dataReader.IsDBNull(i)){
		return 0.0;
	}

	if (dataReader.GetType().Name.Equals("OdbcDataReader")){
		string aux = (string)dataReader.GetValue(i);
		return double.Parse(aux);
	}else{
		return dataReader.GetDouble(i);
	}
}


public
double GetDouble(string fieldName){
	return GetDouble(this.GetOrdinal(fieldName));
}

public 
decimal GetDecimal(int i){
	if (dataReader.IsDBNull(i)){
		return 0;
	}

	if (dataReader.GetType().Name.Equals("OdbcDataReader")){
		object aux =  dataReader.GetValue(i);

		char[] arr = aux.ToString().ToCharArray();
		string buffer = "";

		foreach(char c in arr)
        	if ((Char.IsDigit(c)) || (c == '.'))  
        		buffer += c.ToString();
    	
		return decimal.Parse(buffer.ToString());
	}else{
		return dataReader.GetDecimal(i);
	}
}


public
decimal GetDecimal(string fieldName){
	return GetDecimal(this.GetOrdinal(fieldName));
}


public 
Int16 GetInt16(int i){
	if (dataReader.IsDBNull(i)){
		return 0;
	}
	return dataReader.GetInt16(i);
}

public
Int16 GetInt16(string fieldName){
	return GetInt16(this.GetOrdinal(fieldName));
}

public 
Int32 GetInt32(int i){
	if (dataReader.IsDBNull(i)){
		return 0;
	}
	return dataReader.GetInt32(i);
}


public
Int32 GetInt32(string fieldName){
	return GetInt32(this.GetOrdinal(fieldName));
}


public 
Int64 GetInt64(int i){
	if (dataReader.IsDBNull(i)){
		return 0;
	}
	return dataReader.GetInt64(i);
}

public
Int64 GetInt64(string fieldName){
	return GetInt64(this.GetOrdinal(fieldName));
}

public
bool GetBit(string fieldName)
{
	return GetBit(GetOrdinal(fieldName));
}

public
bool GetBit(int i)
{	
	if (dataReader != null)
	{
		return dataReader.GetBoolean(i);
	}
	return false;	
}

public 
DateTime GetDateTime(int i){
	if (dataReader.IsDBNull(i)){
		return new DateTime(1901, 1, 1);
	}else{
		if (dataReader.GetType().Name.Equals("OleDbDataReader")){
			return DateUtil.parseDate(dataReader.GetString(i), DateUtil.YYYYMMDD_AS);
		}else{
			return dataReader.GetDateTime(i);
		}
	}
}

public
DateTime GetDateTime(string fieldName){
	return GetDateTime(this.GetOrdinal(fieldName));
}

public
object GetValue(string fieldName){
	return GetValue(this.GetOrdinal(fieldName));
}

public
object GetValue(int i){
	if (dataReader.IsDBNull(i)){
		return "";
	}
	return dataReader.GetValue(i);
}


}//end class

}//end namesapace
