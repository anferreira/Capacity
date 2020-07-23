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
class EmpShiftScheduleReportTransformViewContainer : ObservableCollection<EmpShiftScheduleReportTransformView> { 
#else
class EmpShiftScheduleReportTransformViewContainer : Collection<EmpShiftScheduleReportTransformView> { 
#endif

internal
EmpShiftScheduleReportTransformViewContainer() : base(){
}



} // class
} // package