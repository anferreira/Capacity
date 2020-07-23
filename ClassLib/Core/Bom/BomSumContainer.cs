/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class BomSumContainer : ObservableCollection<BomSum> { 
#else
class BomSumContainer : Collection<BomSum> { 
#endif

internal
BomSumContainer() : base(){
}


} // class
} // package