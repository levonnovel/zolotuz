using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Paint
	{
		//"Provider=SQLOLEDB;Data Source=SQL6001.site4now.net;Initial Catalog=DB_A48CD1_zu;User Id=DB_A48CD1_zu_admin;Password=YOUR_DB_PASSWORD;"
		//"Data Source=SQL6001.site4now.net;Initial Catalog=DB_A48CD1_zu;User Id=DB_A48CD1_zu_admin;Password=googlecomm123;"
		//Data Source=LEVON\LEOMAX; database=PastaAndMore ;Integrated Security=SSPI
		//static readonly string cs = @"Data Source=LEVPETROS-PC\SQLEXPRESS; database=ZolotoyUzor ;Integrated Security=SSPI";
		static readonly string cs = @"Data Source=SQL6001.site4now.net;Initial Catalog=DB_A48CD1_zu;User Id=DB_A48CD1_zu_admin;Password=googlecomm123;";
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Composition { get; set; }
		public string Application_Area { get; set; }
		public decimal Price { get; set; }
		public string Color { get; set; }
		public string Volume { get; set; }
		public string Country { get; set; }
		public string Product_Type { get; set; }
		public string Type { get; set; }
		public List<Image> Images{ get; set; }


		//public static List<Paint> GetAllPaints()
		//{
		//	List <Paint> ProductsList = new List<Paint>();
		//	using (SqlConnection conn = new SqlConnection(cs))
		//	{
		//		SqlCommand cmd = new SqlCommand("sp_get_all_paints", conn);

		//		@paint_id
		//		@type
		//		 @color
		//		 @volume
		//		 @min_amount
		//		 @max_amount

		//		cmd.CommandType = CommandType.StoredProcedure;
		//		cmd.Parameters.AddWithValue("@paint_id", SqlDbType.VarChar);


		//		conn.Open();
		//		SqlDataReader dr = cmd.ExecuteReader();

		//		while (dr.Read())
		//		{
		//			ProductsList.Add(
		//					new Paint()
		//					{
		//						Id = Convert.ToInt32(dr["Id"]),
		//						Name = dr["Name"].ToString(),
		//						Description = dr["Description"].ToString(),
		//						Composition = dr["Composition"].ToString(),
		//						Application_Area = dr["Application_Area"].ToString(),
		//						Price = Convert.ToDecimal(dr["Price"]),
		//						Color = dr["COLOR_NAME"].ToString(),
		//						Volume = dr["Volume_NAME"].ToString(),
		//						Country = dr["Country_NAME"].ToString(),
		//						Type = Convert.ToByte(dr["Type_NAME"]),
		//						Product_Type = Convert.ToByte(dr["Product_Type"]),
		//					}
		//				);
		//		}
		//		return ProductsList;
		//	}
		//}

		//public static Paint GetPaintByID( int id)
		//{
		//	using (SqlConnection conn = new SqlConnection(cs))
		//	{
		//		SqlCommand cmd = new SqlCommand("SELECT * FROM paints WHERE ID=@id", conn);

		//		conn.Open();
		//		cmd.Parameters.AddWithValue("@id", id);
		//		SqlDataReader dr = cmd.ExecuteReader();
		//		Paint el = new Paint();
		//		while (dr.Read())
		//		{

		//			el = new Paint()
		//			{
		//				Id = Convert.ToInt32(dr["Id"]),
		//				Name = dr["Name"].ToString(),
		//				Description = dr["Description"].ToString(),
		//				Composition = dr["Composition"].ToString(),
		//				Application_Area = dr["Application_Area"].ToString(),
		//				Price = Convert.ToDecimal(dr["Price"]),
		//				Color = dr["Color"].ToString(),
		//				Volume = dr["Volume"].ToString(),
		//				Country = dr["Country"].ToString(),
		//			};


		//		}
		//		return el;
		//	}
		//}


	}
}
