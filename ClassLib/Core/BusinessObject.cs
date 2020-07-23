using System;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
//using Nujit.NujitWms.ClassLib.Util;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract]
#endif

public abstract
class BusinessObject : /*IXmlSerializable,*/INotifyPropertyChanged, IDataErrorInfo
{

public 
BusinessObject(){
    Dirty = false;
}

public Boolean Dirty { get; set; }

#region INotifyPropertyChanged Members

public event PropertyChangedEventHandler PropertyChanged;

protected void Notify(string propName){
    this.Dirty = true;
    if (this.PropertyChanged != null){
        PropertyChanged(this,new PropertyChangedEventArgs(propName));
    }
}

#endregion INotifyPropertyChanged Members


/*#region IXmlSerializable Members

public 
XmlSchema GetSchema(){
	return null;
}

public 
void ReadXml(XmlReader reader){
	CustomXmlSerializer xmlReader = new CustomXmlSerializer();
	xmlReader.ReadXml(reader, this);
}

public 
void WriteXml(XmlWriter writer){
	CustomXmlSerializer xmlWriter = new CustomXmlSerializer();
	xmlWriter.WriteXml(this, writer);	
}

#endregion*/

#region IDataErrorInfo

public virtual
string Error {
	get { return null;}
}

public virtual
string this[string columnName] {
    get { return null; }
}

#endregion

} // class
} // namespace
