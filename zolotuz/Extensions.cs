using System.Collections.Generic;
using System.Data;
using System.Text;

namespace zolotuz
{
	public static class Extensions
	{
		internal static DataTable ConvertToDataTable(this List<byte> list)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add();
			list.ForEach(m => dt.Rows.Add(m));
			return dt;
		}

		internal static string ConvertToSqlArr(this List<byte> list)
		{
			if(list != null)
			{
				StringBuilder st = new StringBuilder();
				//st.Append(@"'");
				foreach (byte el in list)
				{
					st.Append(el);
					st.Append(",");
				}
				st.Remove(st.Length - 1, 1);
				//st.Append(@"'");
				return st.ToString();
			}
			return "";

		}
	}
}
