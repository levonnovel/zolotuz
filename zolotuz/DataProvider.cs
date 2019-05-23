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
		//static readonly string cs = @"Data Source=LEVPETROS-PC\SQLEXPRESS; database=ZolotoyUzor ;Integrated Security=SSPI";
		static readonly string cs = @"Data Source=LEVON\LEOMAX; database=ZolotoyUzor ;Integrated Security=SSPI";
		//static readonly string cs = @"Data Source=SQL6001.site4now.net;Initial Catalog=DB_A48CD1_zu;User Id=DB_A48CD1_zu_admin;Password=googlecomm123;";

		public static List<Paint> GetPaints(PaintFilter filter)
		{


			DataTable dt = new DataTable();

			List<Paint> ProductsList = new List<Paint>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_paints", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@paint_id", filter.ID);
				cmd.Parameters.AddWithValue("@min_amount", filter.MinPrice);
				cmd.Parameters.AddWithValue("@max_amount", filter.MaxPrice);
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
					ProductsList.Add(dr.ConvertToPaint());
				}

				return ProductsList;
			}
		}

		public static List<ProductDTO> GetRandomItems()
		{

			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_random_items", conn);
				cmd.CommandType = CommandType.StoredProcedure;


				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToProductDTO());
				}

				return ProductsList;
			}
		}

		public static List<ProductDTO> GetDiscountedItems()
		{

			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_discounted_items", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToProductDTO());
				}

				return ProductsList;
			}

		}

		public static List<ProductDTO> GetCurrentTypeItems(string table, string type = null)
		{

			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_items", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@tbl", table);
				if(type != null)
				{
					cmd.Parameters.AddWithValue("@type", type);

				}

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToProductDTO());
				}

				return ProductsList;
			}

		}
		
	}
}
