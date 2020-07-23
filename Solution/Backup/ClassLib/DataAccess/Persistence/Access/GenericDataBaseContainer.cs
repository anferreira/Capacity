using System;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{

/// <summary>
/// Class GenericDataBaseContainer : represents a table or a set of records of a table
/// </summary>
public
class GenericDataBaseContainer : ArrayList{

protected DataBaseAccess dataBaseAccess;
private Hashtable hash = new Hashtable();


/// <summary>
/// Constructor
/// </summary>
/// <returns></returns>
public
GenericDataBaseContainer(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

/// <summary>
/// Returns if the collection in indexed
/// </summary>
/// <returns></returns>
public
bool isIndexed(){
	if ((this.Count > 0) && (hash.Count == 0))
		return false;
	return true;
}

/// <summary>
/// Adds a new object to the set
/// </summary>
/// <returns></returns>
public 
int Add(GenericDataBaseElement element, string key){
	int pos = 0;
	if (this.Count != 0)
		pos = this.Count;
	
	if (!hash.ContainsKey(key.Trim()))
		hash.Add(key.Trim(), pos.ToString());
	
	return this.Add(element);
}

/// <summary>
/// Returns ths first position object seeked
/// </summary>
/// <returns></returns>
public
int getFirstElementPosition(string key){
	if (hash.Count == 0)
		return -1;
	
	if (hash.ContainsKey(key.Trim()))
		return int.Parse((string)hash[key.Trim()]);
	return -1;
}

/// <summary>
/// Returns ths first object seeked
/// </summary>
/// <returns></returns>
public
object getFirstObject(string key){
	int pos = getFirstElementPosition(key);
	if (pos != -1)
		return (object)this[pos];
	return null;
}

/// <summary>
/// Returns ths DataBaseAccess object
/// </summary>
/// <returns></returns>
public
DataBaseAccess getDataBaseAccess(){
	return dataBaseAccess;
}

public
void getDataBaseAccess(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

/// <summary>
/// Write method, write all records presents
/// </summary>
public
void write(){
	IEnumerator ie = GetEnumerator();
	while(ie.MoveNext()){
		GenericDataBaseElement element = (GenericDataBaseElement)ie.Current;
		element.write();
	}
}

/// <summary>
/// Update method, update all records presents
/// </summary>
public
void update(){
	IEnumerator ie = GetEnumerator();
	while(ie.MoveNext()){
		GenericDataBaseElement element = (GenericDataBaseElement)ie.Current;
		element.update();
	}
}

/// <summary>
/// Delete method, delete all records presents
/// </summary>
public
void delete(){
	IEnumerator ie = GetEnumerator();
	while(ie.MoveNext()){
		GenericDataBaseElement element = (GenericDataBaseElement)ie.Current;
		element.delete();
	}
}

} // class

} // namespace
