using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class HotListHourContainer : ArrayList{

public 
HotListHourContainer() : base(){
}

public 
HotListHour getHotListHour(string configuration){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		HotListHour hotListHour = (HotListHour)en.Current;

		if (hotListHour.getConfiguration().Equals(configuration))
			return hotListHour;
	}
	return null;
}

public
void optimize(){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		HotListHour hotListHour = (HotListHour)en.Current;
		hotListHour.optimizeDays();
	}
}

} // class

} // namespace
