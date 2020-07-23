using System;
using System.Globalization;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;


namespace Nujit.NujitERP.ClassLib.Common
{

public
class Culture {

	static CultureLocal cultureLocal= new CultureLocal();

	public static void setCulture(CultureInfo cultureInfo2)  
	{
		cultureLocal.setCulture(cultureInfo2);
	}

	public static CultureInfo getCulture()
	{
		return cultureLocal.getCulture();
	}

	public static void setResource(string spathResource,Assembly assembly)
	{
		cultureLocal.setResource(spathResource,assembly);		
	}
	public static bool getText(Control control)
	{
		return cultureLocal.getText(control);		
	}

	public static string getText(string sname)
	{
		return cultureLocal.getText(sname);
	}

	public static bool setControlsCulture(Control control)
	{
		return cultureLocal.setControlsCulture(control);
	}
} // class
} // namespace
