using System;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB
{
	public class DBFormatter
	{
		public DBFormatter()
		{
		}

		public static string selectTopRows (string sqlSelect, string sqlRepositoryType, int rowCount)
		{
			string formatSql = "";
			if (sqlRepositoryType.Equals("SQLServer"))
			{
				int i = 0;
				bool done = false;
				while (!done && i < (sqlSelect.Length-6))
				{
					if (sqlSelect.Substring(i,6).ToUpper().Equals("SELECT"))
					{
						done = true;
						formatSql = sqlSelect.Substring(0,i+6);
						formatSql += " top " + rowCount.ToString();
						formatSql += sqlSelect.Substring(i+6);
					}
					i++;
				}
			}
			if (sqlRepositoryType.Equals("MySQL"))
			{
				int i = sqlSelect.Length-1;
				while (sqlSelect.Substring(i,1).Equals(" "))
					i--;
				if (sqlSelect.Substring(i,1).Equals(";"))
					i--;
				formatSql = sqlSelect.Substring (0,i+1);
				formatSql += " limit " + rowCount.ToString();
				formatSql += sqlSelect.Substring (i+1);
			}
			return formatSql;
		}
	}
}
