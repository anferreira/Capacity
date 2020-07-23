using System;
using System.Globalization;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;


namespace Nujit.NujitERP.ClassLib.Common
{

public
class CultureLocal{

	protected CultureInfo cultureInfo= null;
	protected ResourceManager rm= null;	

	public 
	CultureLocal(CultureInfo cultureInfo2)
	{
		cultureInfo = cultureInfo2;
		rm= null;
	}

	public 
	CultureLocal()
	{
		cultureInfo = null;
		rm= null;
	}
	public void setCulture(CultureInfo cultureInfo2)
	{
		cultureInfo = cultureInfo2;
	}


	public CultureInfo getCulture()
	{
		return cultureInfo;
	}

	public void setResource(string spathResource,Assembly assembly)
	{
		
		if (rm != null)
			rm = null;

		rm = new ResourceManager(spathResource,assembly);
	}
	public bool getText(Control control)
	{
		bool	bresult=false;
		string	stext="";
		if (rm != null)			
		{
			stext	=rm.GetString(control.Name,cultureInfo);
			if (stext!= null)
			{
				control.Text =stext;
				bresult=true;
			}
		}
		return bresult;
	}

	public  string getText(string sname)
	{
		string	stext="";

		if (rm != null)			
		{
			stext = rm.GetString(sname,cultureInfo);
			if (stext== null)
				stext="";
		}
		return stext;
	}

	public bool setControlsCulture(Control control)
	{
		bool	bresult=false;
		
		if (rm != null)			
		{
			if (control != null)
			{
				this.getText(control);	

				foreach(Control objControl in control.Controls){
					bresult = setControlsCulture(objControl);
				}					

			}
		}
		return bresult;
	}
} // class
} // namespace
