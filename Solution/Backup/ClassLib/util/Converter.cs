using System;

namespace Nujit.NujitERP.ClassLib.Util{

/// <summary>
/// Utility class for convert data, changes simple ' for '', it uses before the insert or an update.
/// </summary>
public 
class Converter{

public static
string fixString(string stringToTransform){
	if (stringToTransform == null)
		return "";
	stringToTransform = stringToTransform.Replace("'", "''");
	return stringToTransform;
}

} // class

} // namespace
