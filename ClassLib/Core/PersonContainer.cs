/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class PersonContainer : ObservableCollection<Person> { 
#else
class PersonContainer : Collection<Person> { 
#endif

internal
PersonContainer() : base(){
}

public
Person getByKey(string id){
	Person person = null;
	int i = 0;
	while ((i < this.Count) && (person == null)){
		if (id.ToUpper().Equals(this[i].Id.ToUpper()))
			person = this[i];
		i++;
	}
	return person;
}
        

} // class
} // package