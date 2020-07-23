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

public static
string fixStringAscii127(string stringToTransform){
	if (stringToTransform == null)
		return "";
	stringToTransform = stringToTransform.Replace("'", "''");

    if (Configuration.SqlRepositoryType.Equals("MySQL"))
        stringToTransform = stringToTransform.Replace("\\", "\\\\");

    if (Configuration.SqlRepositoryType.Equals("MySQL")){ //on MySql version 10, there were some errors when ascii bigger than 127

        char[] chars = stringToTransform.ToCharArray();
        for (int i=0; i < chars.Length;i++){
            if ((int)chars[i] > 127){               
               //System.Windows.Forms.MessageBox.Show("ValueType=" + stringToTransform + "\n" + "Fix:" + chars[i] + " Int:" + (int)chars[i]);
               chars[i] = ' ';
            }
        }
        stringToTransform = "";
        for (int i = 0; i < chars.Length; i++)                
            stringToTransform+= chars[i];
    }        
    return stringToTransform;
}

} // class

} // namespace
