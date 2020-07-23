using System;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Common
{
	/// <summary>
	/// Summary description for StringUtil.
	/// </summary>
	public class StringUtil
	{
		public StringUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string center(string s, int ilen)
		{
			string	sresult,s1,s2;
			int		iquantSpaces=0;

			if (s.Length >= ilen)
				sresult = s.Substring(0,ilen);
			else
			{
				iquantSpaces = (ilen - s.Length) / 2;
				
				s1 = AddSpaces(s,iquantSpaces+s.Length,false);
				s2 = AddSpaces("",iquantSpaces,true);
							
				sresult = s1 + s2;		
			}
			return sresult;
		}

		public static string alingToRight(string s1,string s2,int ilen)
		{
			string	sresult,saux;
			int		iquantSpaces=0;
			int		iTotLen = s1.Length + s2.Length;

			if (iTotLen >= ilen)
			{
				saux = s1 + " " + s2;
				sresult = saux.Substring(0,ilen);
			}
			else
			{
				
				iquantSpaces = ilen - iTotLen;

				saux = AddSpaces(s1,s1.Length + iquantSpaces,true);

				sresult = saux + s2;				
			}
			return sresult;
		}

		public static string AddSpaces(string s,int len,bool bright)
		{
			string sresult;

			if (s.Length >= len)
				sresult = s.Substring(0,len);
			else
			{
				if (bright)
					sresult = s.PadRight(len,' ');			
				else
					sresult = s.PadLeft(len,' ');			
			}

			return sresult;
		}

		public static string AddChar(string s,char fillChar, int len,bool bright)
		{
			string sresult;

			if (s.Length >= len)
				sresult = s.Substring(0,len);
			else
			{
				if (bright)
					sresult = s.PadRight(len,fillChar);			
				else
					sresult = s.PadLeft(len,fillChar);			
			}

			return sresult;
		}

		public static bool checkLength(string s,int len,string snameField,bool bmustHaveValue,bool bshowMessage)
		{
			bool	bresult = false;
			string	smessage="";

			if (s.Length > len)
			{
				if (bshowMessage)
				{
					smessage="Please, reenter the field " + snameField;
					smessage+=",maximum length is " + len.ToString()+ "."; 
					MessageBox.Show(smessage);
				}
			}
			else
			{
				if (s.Length < 1 && bmustHaveValue)
				{
					if (bshowMessage)
					{
						smessage="Please, add value to field " + snameField + ".";					
						MessageBox.Show(smessage);
					}
				}
				else
					bresult = true;
			}

			return bresult;
		}

		public static void hasToBeDouble (TextBox textBox)
		{
			if (!textBox.Text.Equals(string.Empty) && !NumberUtil.isDoubleNumber(textBox.Text) && (!textBox.Text.Equals(".")) && (!textBox.Text.Equals(",")))
			{
				int pos = textBox.SelectionStart;
				if (pos == 0)
					textBox.Text = textBox.Text.Substring(1,textBox.Text.Length-1);
				else
				{
					string auxStr = textBox.Text;
					textBox.Text = auxStr.Substring (0,pos-1) + auxStr.Substring(pos,auxStr.Length-pos);
					textBox.SelectionStart = pos - 1;
					textBox.SelectionLength = 0;
				}
			}
			else
			{
				int pos = textBox.SelectionStart;
				int len = textBox.SelectionLength;
				for (int i=0; i<textBox.Text.Length; i++)
					if (textBox.Text[i].Equals(','))
						textBox.Text = textBox.Text.Substring(0,i) + "." + textBox.Text.Substring (i+1);
				if (pos >= 0)
					textBox.SelectionStart = pos;
				if (len >= 0)
					textBox.SelectionLength = len;
			}
		}

		public static void hasToBeInteger (TextBox textBox)
		{
			if (!textBox.Text.Equals(string.Empty) && !NumberUtil.isIntegerNumber(textBox.Text))
			{
				int pos = textBox.SelectionStart;
				if (pos == 0)
					textBox.Text = textBox.Text.Substring(1,textBox.Text.Length-1);
				else
				{
					string auxStr = textBox.Text;
					textBox.Text = auxStr.Substring (0,pos-1) + auxStr.Substring(pos,auxStr.Length-pos);
					textBox.SelectionStart = pos - 1;
					textBox.SelectionLength = 0;
				}
			}
			else
			{
				int pos = textBox.SelectionStart;
				int len = textBox.SelectionLength;
				for (int i=0; i<textBox.Text.Length; i++)
					if (textBox.Text[i].Equals(','))
						textBox.Text = textBox.Text.Substring(0,i) + "." + textBox.Text.Substring (i+1);
				textBox.SelectionStart = pos;
				textBox.SelectionLength = len;
			}
		}

		public static int getQuantFields(string sin,char csep)
		{
			int		iquantFields=0,i=0;

			for (i=0;i < sin.Length;i++)
			{
				if (sin[i] == csep)
					iquantFields++;
			}

			return iquantFields;
		}
		public static bool getField(string sin,out string sout,int ifield,char csep)
		{
			bool	bresult=false;
			int		i=0;
			int		iquantFields=0;

			sout="";
			if (getQuantFields(sin,csep) >= ifield)
			{	
				bresult=true;

				for (i=0;i < sin.Length && iquantFields < ifield;i++)
				{
					if (sin[i] == csep)
						iquantFields++;
				}
				for (;i < sin.Length && sin[i] != csep;i++)
					sout+= sin[i];				
			}
			
			return bresult;
		}
		
		public static bool cutString(string sin,out string sout,int ifield,int icountChars)
		{
			bool	bresult=true;
			int		ilen = sin.Length;
			int		isinceLen = (ifield*icountChars);
			int		ithereIs=0;
					
			sout="";
			if  (isinceLen >= ilen)
				bresult = false;
			else
			{
				ithereIs = ilen - (ifield*icountChars);
				if (ithereIs < icountChars)
					sout = sin.Substring(isinceLen,ithereIs);
				else
					sout = sin.Substring(isinceLen,icountChars);				
			}
			return bresult;
		}
	}
}
