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
		//static readonly string cs = @"Data Source=LEVONPET-PC\SQLEXPRESS; database=DB_A49556_zu ;Integrated Security=SSPI";
		//static readonly string cs = @"Data Source=LEVON\LEOMAX; database=ZolotoyUzor ;Integrated Security=SSPI";
		static readonly string cs = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A49556_zolotoyuzor;User Id=DB_A49556_zolotoyuzor_admin;Password=Aa199814;";
		

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
		
		public static List<ProductDTO> GetKovki(KovkaFilter filter)
		{


			DataTable dt = new DataTable();

			List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_kovki", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@kovka_id", filter.ID);
				cmd.Parameters.AddWithValue("@min_amount", filter.MinPrice);
				cmd.Parameters.AddWithValue("@max_amount", filter.MaxPrice);
				cmd.Parameters.AddWithValue("@type", filter.Kovka_type.ConvertToSqlArr());

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

		public static List<Kovka> GetKovki(int id)
		{


			DataTable dt = new DataTable();

			List<Kovka> ProductsList = new List<Kovka>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_kovka", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", id);

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToKovka());
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
				SqlCommand cmd = new SqlCommand("sp_get_discounted_products", conn);
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
				SqlCommand cmd = new SqlCommand("sp_get_most_viewd_products", conn);
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
				cmd.Parameters.AddWithValue("@ref", name);


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

		public static bool AddPaint(PaintDTO order, out int id)
		{
			int cnt = 0;
			if (order.Img1 != null)
				cnt++;
			if (order.Img2 != null)
				cnt++;
			if (order.Img3 != null)
				cnt++;
			//DataTable dt = new DataTable();

			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_insert_kraska", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@desc", order.Description);
				cmd.Parameters.AddWithValue("@appl_area", order.Application_Area);
				cmd.Parameters.AddWithValue("@price", order.Price);
				cmd.Parameters.AddWithValue("@color", order.Color);
				cmd.Parameters.AddWithValue("@volume", order.Volume);
				cmd.Parameters.AddWithValue("@country", order.Country);
				cmd.Parameters.AddWithValue("@man", order.Manufacturer);
				cmd.Parameters.AddWithValue("@type", order.Type);
				cmd.Parameters.AddWithValue("@discount", order.Discount);
				cmd.Parameters.AddWithValue("@imgscount", cnt);


				SqlParameter outParameter = new SqlParameter("@id", SqlDbType.Int);
				outParameter.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(outParameter);

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
				id = Convert.ToInt32(outParameter.Value);

				return true;
			}
		}

		public static bool AddStroymat(StroymatDTO order, out int id)
		{
			int cnt = 0;
			if (order.Img1 != null)
				cnt++;
			if (order.Img2 != null)
				cnt++;
			if (order.Img3 != null)
				cnt++;
			//DataTable dt = new DataTable();

			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_insert_stroymateryal", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@desc", order.Description);
				cmd.Parameters.AddWithValue("@price", order.Price);
				cmd.Parameters.AddWithValue("@country", order.Country);
				cmd.Parameters.AddWithValue("@man", order.Manufacturer);
				cmd.Parameters.AddWithValue("@type", order.Type);
				cmd.Parameters.AddWithValue("@discount", order.Discount);
				cmd.Parameters.AddWithValue("@imgscount", cnt);




				SqlParameter outParameter = new SqlParameter("@id", SqlDbType.Int);
				outParameter.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(outParameter);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);


				//cmd.Parameters["@items"].Value = order.Items;
				//cmd.Parameters.AddWithValue("@items", order.Items);


				conn.Open();
				//dt.Load(cmd.ExecuteReader());
				cmd.ExecuteNonQuery();
				id = Convert.ToInt32(outParameter.Value);

				//foreach (DataRow dr in dt.Rows)
				//{
				//	ProductsList.Add(dr.ConvertToProductDTO());
				//}

				return true;
			}
		}

		public static bool AddKovka(KovkaDTO order, out int id)
		{
			int cnt = 0;
			if (order.Img1 != null)
				cnt++;
			if (order.Img2 != null)
				cnt++;
			if (order.Img3 != null)
				cnt++;
			//DataTable dt = new DataTable();

			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_insert_kovka", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@desc", order.Description);
				cmd.Parameters.AddWithValue("@price", order.Price);
				cmd.Parameters.AddWithValue("@type", order.Type);
				cmd.Parameters.AddWithValue("@discount", order.Discount);
				cmd.Parameters.AddWithValue("@imgscount", cnt);

				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				//cmd.Parameters.Add("@items", SqlDbType.Structured);
				SqlParameter outParameter = new SqlParameter("@id", SqlDbType.Int);
				outParameter.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(outParameter);

				//cmd.Parameters["@items"].Value = order.Items;
				//cmd.Parameters.AddWithValue("@items", order.Items);


				conn.Open();
				//dt.Load(cmd.ExecuteReader());
				cmd.ExecuteNonQuery();
				id = Convert.ToInt32(outParameter.Value);
				//foreach (DataRow dr in dt.Rows)
				//{
				//	ProductsList.Add(dr.ConvertToProductDTO());
				//}

				return true;
			}
		}

		public static bool EditPaint(PaintDTO order)
		{
			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_update_kraska", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", order.Id);
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@desc", order.Description);
				cmd.Parameters.AddWithValue("@appl_area", order.Application_Area);
				cmd.Parameters.AddWithValue("@price", order.Price);
				cmd.Parameters.AddWithValue("@color", order.Color);
				cmd.Parameters.AddWithValue("@volume", order.Volume);
				cmd.Parameters.AddWithValue("@country", order.Country);
				cmd.Parameters.AddWithValue("@man", order.Manufacturer);
				cmd.Parameters.AddWithValue("@type", order.Type);
				cmd.Parameters.AddWithValue("@discount", order.Discount);



			

				conn.Open();
				//dt.Load(cmd.ExecuteReader());
				cmd.ExecuteNonQuery();
				

				return true;
			}
		}

		public static bool EditStroymat(StroymatDTO order)
		{
			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_update_kraska", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", order.Id);
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@desc", order.Description);
				cmd.Parameters.AddWithValue("@price", order.Price);
				cmd.Parameters.AddWithValue("@country", order.Country);
				cmd.Parameters.AddWithValue("@man", order.Manufacturer);
				cmd.Parameters.AddWithValue("@type", order.Type);
				cmd.Parameters.AddWithValue("@discount", order.Discount);



				conn.Open();
				//dt.Load(cmd.ExecuteReader());
				cmd.ExecuteNonQuery();


				return true;
			}
		}

		public static bool EditKovka(KovkaDTO order)
		{
			//List<ProductDTO> ProductsList = new List<ProductDTO>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_update_kraska", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", order.Id);
				cmd.Parameters.AddWithValue("@name", order.Name);
				cmd.Parameters.AddWithValue("@desc", order.Description);
				cmd.Parameters.AddWithValue("@price", order.Price);
				cmd.Parameters.AddWithValue("@type", order.Type);
				cmd.Parameters.AddWithValue("@discount", order.Discount);



				conn.Open();
				//dt.Load(cmd.ExecuteReader());
				cmd.ExecuteNonQuery();


				return true;
			}
		}

        public static List<Headers> GetHeaders()
        {
            DataTable dt = new DataTable();
            List<Headers> Headers = new List<Headers>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("[sp_get_headers]", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow dr in dt.Rows)
                {

                   dr.ConvertToHeader(Headers);
                }

                return Headers;
            }
        }

        public static List<PageFiltersValues> GetPageFiltersValues()
        {


            DataTable dt = new DataTable();

            List<PageFiltersValues> Filters = new List<PageFiltersValues>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("[sp_get_products_filter_values]", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow dr in dt.Rows)
                {
                    Filters.Add(dr.ConvertToPageFilterValues());
                }

                return Filters;
            }
        }

        public static List<PageFilters> GetPageFilters()
        {


            DataTable dt = new DataTable();

            List<PageFilters> Filters = new List<PageFilters>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("[get_page_filters]", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow dr in dt.Rows)
                {
                    Filters.Add(dr.ConvertToPageFilter());
                }

                return Filters;
            }
        }

        public static List<ProductDTO> GetProducts(ProductFilter filter)
        {

			if(filter.Product_group == 0)
			{
				filter.Product_type = 0;
			}

			if (filter.Product_type == 0)
			{
				filter.Product_subtype = 0;
			}

			DataTable dt = new DataTable();

            List<ProductDTO> ProductsList = new List<ProductDTO>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_get_products", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@product_group", filter.Product_group);
                cmd.Parameters.AddWithValue("@product_type", filter.Product_type);
                cmd.Parameters.AddWithValue("@product_subtype", filter.Product_subtype);
				cmd.Parameters.AddWithValue("@manufacturer", filter.cat_manufacturer.ConvertToSqlArr());
				cmd.Parameters.AddWithValue("@color_palette", filter.cat_color_palette.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@appearance", filter.cat_appearance.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@washable", filter.cat_washable.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@smell", filter.cat_smell.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@color", filter.cat_color.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@appointment", filter.cat_appointment.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@type", filter.cat_type.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@application_type", filter.cat_application_type.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@paint_type", filter.cat_paint_type.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@room_type", filter.cat_room_type.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@brush_type", filter.cat_brush_type.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@type_of_use", filter.cat_type_of_use.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@stencil_theme", filter.cat_stencil_theme.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@place_of_use", filter.cat_place_of_use.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@created_for", filter.cat_created_for.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@finish_guarantee", filter.cat_finish_guarantee.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@effect", filter.cat_effect.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@volume", filter.cat_volume.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@duration_of_protection", filter.cat_duration_of_protection.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@surface_of_application", filter.cat_surface_of_application.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@width", filter.cat_width.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@fiber_material", filter.cat_fiber_material.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@structure", filter.cat_structure.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@resistant", filter.cat_resistant.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@gluing_strength", filter.cat_gluing_strength.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@capture_time", filter.cat_capture_time.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@frost_resistance", filter.cat_frost_resistance.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@heat_resistance", filter.cat_heat_resistance.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@color_after_drying", filter.cat_color_after_drying.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@gluing_material", filter.cat_gluing_material.ConvertToSqlArr());
                cmd.Parameters.AddWithValue("@external_material", filter.cat_external_material.ConvertToSqlArr());

                cmd.Parameters.AddWithValue("@min_amount", filter.MinPrice);
                cmd.Parameters.AddWithValue("@max_amount", filter.MaxPrice);

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

		public static List<Product> GetProduct(int id)
		{


			DataTable dt = new DataTable();

			List<Product> ProductsList = new List<Product>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("sp_get_product", conn);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", id);

				conn.Open();
				dt.Load(cmd.ExecuteReader());

				foreach (DataRow dr in dt.Rows)
				{
					ProductsList.Add(dr.ConvertToProduct());
				}

				return ProductsList;
			}
		}

	}
}
