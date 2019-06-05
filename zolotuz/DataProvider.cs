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
		//static readonly string cs = @"Data Source=LEVON\LEOMAX; database=ZolotoyUzor ;Integrated Security=SSPI";
		//static readonly string cs = @"Data Source=SQL6003.site4now.net;Initial Catalog=DB_A49556_zu;User Id=DB_A49556_zu_admin;Password=googlecomm123;";
		

		public static List<ProductDTO> GetPaints(PaintFilter filter)
		{


			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_paints", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@paint_id", filter.ID);
				cmd.Parameters.AddWithValue("@min_amount", filter.MinPrice);
				cmd.Parameters.AddWithValue("@max_amount", filter.MaxPrice);
				cmd.Parameters.AddWithValue("@type", filter.Paint_type.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@volume", filter.Volumes.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@color", filter.Colors.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@country", filter.Countries.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@manufact", filter.Manufacturers.ConvertToSqlArr());

				cmd.Parameters.AddWithValue("@start", filter.Start);
				cmd.Parameters.AddWithValue("@end", filter.End);





				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToProductDTO());
				}

				return ProductsList;
			}
		}


		public static List<ProductDTO> GetStroymats(StroymatFilter filter)
		{


			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_stroymats", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@stroymat_id", filter.ID);
				cmd.Parameters.AddWithValue("@min_amount", filter.MinPrice);
				cmd.Parameters.AddWithValue("@max_amount", filter.MaxPrice);
				cmd.Parameters.AddWithValue("@type", filter.Stroymat_type.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@country", filter.Countries.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@manufact", filter.Manufacturers.ConvertToSqlArr());

				cmd.Parameters.AddWithValue("@start", filter.Start);
				cmd.Parameters.AddWithValue("@end", filter.End);





				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToProductDTO());
				}

				return ProductsList;
			}
		}

		public static List<Paint> GetPaint(int id)
		{


			DataTable dt = new DataTable();

			List<Paint> ProductsList = new List<Paint>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_paint", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", id);

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToPaint());
				}

				return ProductsList;
			}
		}

		public static List<Stroymat> GetStroymateryali(int id)
		{


			DataTable dt = new DataTable();

			List<Stroymat> ProductsList = new List<Stroymat>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_stroymat", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", id);

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToStroymat());
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

		public static List<ProductDTO> GetPopularItems()
		{

			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_most_viewd_items", conn);
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
				if (type != null)
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

		public static Dictionary<string, string> GetRefNames()
		{


			DataTable dt = new DataTable();

			Dictionary<string, string> Refs = new Dictionary<string, string>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("select * from spr_list", conn);

				cmd.CommandType = CommandType.Text;

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					Refs.Add(dr["Name"].ToString(), dr["View"].ToString());
				}

				return Refs;
			}
		}

		public static Dictionary<string, Dictionary<int, string>> GetRefs(string name, string reference)
		{


			DataTable dt = new DataTable();

			Dictionary<string, Dictionary<int, string>> Refs = new Dictionary<string, Dictionary<int, string>>();
			//List<Reference> Refs = new List<Reference>();

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_refs", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ref", reference);


				conn.Open();
				dt.Load(cmd.ExecuteReader());

				Reference R = new Reference() { Name = name };
				foreach (DataRow dr in dt.Rows)
				{
					R.Values.Add(Convert.ToInt32(dr["Id"]), dr["Name"].ToString());
				}

				Refs.Add(R.Name, R.Values);
				return Refs;
			}
		}

		public static bool AddOrder(Order order)
		{

			//DataTable dt = new DataTable();

			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_insert_order", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@email", order.Email);
				cmd.Parameters.AddWithValue("@phone", order.Phone);
				cmd.Parameters.AddWithValue("@addr", order.Address);

				DataTable dt = new DataTable();
				dt.Columns.Add("Name", typeof(string));
				dt.Columns.Add("Description", typeof(string));
				dt.Columns.Add("Price", typeof(decimal));
				dt.Columns.Add("Count", typeof(int));

				foreach(var el in order.Items)
				{
					dt.Rows.Add(el.Name, el.Description, el.Price, el.Count);
				}
				cmd.Parameters.AddWithValue("@ordersList", dt);

				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);


				//cmd.Parameters["@items"].Value = order.Items;
				//cmd.Parameters.AddWithValue("@items", order.Items);


				conn.Open();
				//dt.Load(cmd.ExecuteReader());
				cmd.ExecuteNonQuery();
				//foreach (DataRow dr in dt.Rows)
				//{
				//	ProductsList.Add(dr.ConvertToProductDTO());
				//}

				return true;
			}
		}

		public static List<Order> GetOrders()
		{


			List<Order> OrdersList = new List<Order>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_orders", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				conn.Open();
				//dt.Load(cmd.ExecuteReader());


				SqlDataAdapter adapter = new SqlDataAdapter(cmd);

				DataSet ds = new DataSet();
				adapter.Fill(ds);

				DataTable dt1 = new DataTable();
				dt1 = ds.Tables[0];

				DataTable dt2 = new DataTable();
				dt2 = ds.Tables[1];

				foreach (DataRow dr in dt1.Rows)
				{
					Order order = new Order();
					order = dr.ConvertToOrder();

					foreach (DataRow dr2 in dt2.Rows)
					{
						if (dr["id"].ToString() == dr2["order_id"].ToString())
						{
							order.Items.Add(dr2.ConvertToPurchaisedItem());
						}
					}
					OrdersList.Add(order);
				}

				return OrdersList;
			}

		}

		public static bool IsAdmin(string login, string password)
		{
			DataTable dt = new DataTable();
			//DataTable dt = new DataTable();

			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand(@"select * from admins where login = '" + login + @"' and password = '" + password + @"'", conn);

				conn.Open();
				dt.Load(cmd.ExecuteReader());
				//foreach (DataRow dr in dt.Rows)
				//{
				//	ProductsList.Add(dr.ConvertToProductDTO());
				//}

				return dt.Rows.Count > 0;
			}
		}
		public static bool DeleteProduct(string table, int id)
		{
			DataTable dt = new DataTable();
			//DataTable dt = new DataTable();

			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_delete_product", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@table", table);

				conn.Open();
				cmd.ExecuteNonQuery();
				//foreach (DataRow dr in dt.Rows)
				//{
				//	ProductsList.Add(dr.ConvertToProductDTO());
				//}

				return true;
			}
		}
		
	}
}
