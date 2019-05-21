using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using zolotuz.Models;
using zolotuz.Models.Filters;

namespace zolotuz
{
	public static class DataProvider
	{
		static readonly string cs = @"Data Source=LEVPETROS-PC\SQLEXPRESS; database=ZolotoyUzor ;Integrated Security=SSPI";

		public static List<Paint> GetPaints(PaintFilter filter)
		{


			DataTable dt = new DataTable();

			List<Paint> ProductsList = new List<Paint>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_paints", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@paint_id", filter.ID);

				if (filter.MinPrice == 0)
				{
					cmd.Parameters.AddWithValue("@min_amount", DBNull.Value);

				}
				else
				{
					cmd.Parameters.AddWithValue("@min_amount", filter.MinPrice);
				}
				if (filter.MaxPrice == 0)
				{
					cmd.Parameters.AddWithValue("@max_amount", DBNull.Value);

				}
				else
				{
					cmd.Parameters.AddWithValue("@max_amount", filter.MaxPrice);
				}

				cmd.Parameters.AddWithValue("@type", filter.Types.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@volume", filter.Volumes.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@color", filter.Colors.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@country", filter.Countries.ConvertToSqlArr());


				SqlParameter outParameter = new SqlParameter("@cnt", SqlDbType.Int);
				outParameter.Direction = ParameterDirection.Output;

				cmd.Parameters.Add(outParameter);

				conn.Open();
				dt.Load(cmd.ExecuteReader());
				foreach (DataRow dr in dt.Rows)
				{

					Paint P = new Paint();
					if (dr["Id"] != DBNull.Value)
					{
						P.Id = Convert.ToInt32(dr["Id"]);
					}
					if (dr["Name"] != DBNull.Value)
					{
						P.Name = dr["Name"].ToString();
					}
					if (dr["Description"] != DBNull.Value)
					{
						P.Description = dr["Description"].ToString();
					}
					if (dr["Composition"] != DBNull.Value)
					{
						P.Composition = dr["Composition"].ToString();
					}
					if (dr["Application_Area"] != DBNull.Value)
					{
						P.Application_Area = dr["Application_Area"].ToString();
					}
					if (dr["Price"] != DBNull.Value)
					{
						P.Price = Convert.ToDecimal(dr["Price"]);
					}
					if (dr["Color"] != DBNull.Value)
					{
						P.Color = dr["COLOR_NAME"].ToString();
					}
					if (dr["Volume"] != DBNull.Value)
					{
						P.Volume = dr["Volume_NAME"].ToString();
					}
					if (dr["Country"] != DBNull.Value)
					{
						P.Country = dr["Country_NAME"].ToString();
					}
					if (dr["Type"] != DBNull.Value)
					{
						P.Type = dr["Type_NAME"].ToString();
					}
					if (dr["Product_Type"] != DBNull.Value)
					{
						P.Product_Type = dr["Product_Type"].ToString();
					}

					ProductsList.Add(P);
				}

				return ProductsList;
			}
		}


	}
}
