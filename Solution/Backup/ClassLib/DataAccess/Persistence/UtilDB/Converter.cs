using System;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB{

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
	if (Configuration.SqlRepositoryType.Equals("MySQL"))
		stringToTransform = stringToTransform.Replace("\\", "\\\\");
	return stringToTransform;
}

} // class

} // namespace
