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
class EmpShiftScheduleHdrSumViewContainer : ObservableCollection<EmpShiftScheduleHdrSumView> { 
#else
class EmpShiftScheduleHdrSumViewContainer : Collection<EmpShiftScheduleHdrSumView> { 
#endif

internal
EmpShiftScheduleHdrSumViewContainer() : base(){
}


} // class
} // package