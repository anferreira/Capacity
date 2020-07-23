using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class ShiftContainer : ArrayList{

public 
ShiftContainer() : base(){
}

public
Shift get(string shiftCode){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		Shift shift = (Shift) en.Current;
		if (shift.getShf().Equals(shiftCode))
			return shift;
	}
	return null;
}

} // class

} // namespace
