using System.Collections.Generic;
using System.Data;
using System.Text;
using zolotuz.Models;
using System;

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

		internal static Paint ConvertToPaint(this DataRow dr)
		{
			Paint P = new Paint();
			List<Image> images = new List<Image>();

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
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToInt32(dr["Discount"]);
			}
			if (dr["Manufacturer"] != DBNull.Value)
			{
				P.Manufacturer = Convert.ToByte(dr["Manufacturer"]);
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
				P.Color = Convert.ToInt32(dr["Color"].ToString());
			}
			if (dr["COLOR_NAME"] != DBNull.Value)
			{
				P.ColorName = dr["COLOR_NAME"].ToString();
			}
			if (dr["Volume"] != DBNull.Value)
			{
				P.Volume = Convert.ToInt32(dr["Volume"].ToString());
			}
			if (dr["Volume_NAME"] != DBNull.Value)
			{
				P.VolumeName = dr["Volume_NAME"].ToString();
			}
			if (dr["Country"] != DBNull.Value)
			{
				P.Country = Convert.ToInt32(dr["Country"]);
			}
			if (dr["Country_NAME"] != DBNull.Value)
			{
				P.CountryName = dr["Country_NAME"].ToString();
			}
			if (dr["Type"] != DBNull.Value)
			{
				P.Type = Convert.ToInt32(dr["Type"]);
			}
			if (dr["PAINT_TYPE_NAME"] != DBNull.Value)
			{
				P.Type_Name = dr["PAINT_TYPE_NAME"].ToString();
			}
			
			
			if (dr["Product_Type"] != DBNull.Value)
			{
				P.Product_Type = Convert.ToInt32(dr["Product_Type"]);
			}
			if (dr["PRODUCT_TYPE_NAME"] != DBNull.Value)
			{
				P.Product_Type_Name = dr["PRODUCT_TYPE_NAME"].ToString();
			}
			if (dr["IMAGE_1_NAME"] != DBNull.Value && dr["IMG_1"] != DBNull.Value)
			{
				P.Image = new Image() { Name = dr["IMAGE_1_NAME"].ToString(), Url = dr["IMG_1"].ToString() };
			}
			if (dr["IMAGE_2_NAME"] != DBNull.Value && dr["IMG_2"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_2_NAME"].ToString(), Url = dr["IMG_2"].ToString() });
			}
			if (dr["IMAGE_3_NAME"] != DBNull.Value && dr["IMG_3"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_3_NAME"].ToString(), Url = dr["IMG_3"].ToString() });
			}
			P.Images = images;
			return P;
		}

		internal static Stroymat ConvertToStroymat(this DataRow dr)
		{
			Stroymat P = new Stroymat();
			List<Image> images = new List<Image>();

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
			if (dr["Price"] != DBNull.Value)
			{
				P.Price = Convert.ToDecimal(dr["Price"]);
			}
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToInt32(dr["Discount"]);
			}
			if (dr["Country"] != DBNull.Value)
			{
				P.Country = Convert.ToInt32(dr["Country"]);
			}
			if (dr["Country_NAME"] != DBNull.Value)
			{
				P.CountryName = dr["Country_NAME"].ToString();
			}
			if (dr["Manufacturer"] != DBNull.Value)
			{
				P.Manufacturer = Convert.ToByte(dr["Manufacturer"]);
			}

			if (dr["Type"] != DBNull.Value)
			{
				P.Type = Convert.ToInt32(dr["Type"]);
			}
			if (dr["STROYMAT_TYPE_NAME"] != DBNull.Value)
			{
				P.Type_Name = dr["STROYMAT_TYPE_NAME"].ToString();
			}
			if (dr["Product_Type"] != DBNull.Value)
			{
				P.Product_Type = Convert.ToInt32(dr["Product_Type"]);
			}
			if (dr["PRODUCT_TYPE_NAME"] != DBNull.Value)
			{
				P.Product_Type_Name = dr["PRODUCT_TYPE_NAME"].ToString();
			}
			if (dr["IMAGE_1_NAME"] != DBNull.Value && dr["IMG_1"] != DBNull.Value)
			{
				P.Image = new Image() { Name = dr["IMAGE_1_NAME"].ToString(), Url = dr["IMG_1"].ToString() };
			}
			if (dr["IMAGE_2_NAME"] != DBNull.Value && dr["IMG_2"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_2_NAME"].ToString(), Url = dr["IMG_2"].ToString() });
			}
			if (dr["IMAGE_3_NAME"] != DBNull.Value && dr["IMG_3"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_3_NAME"].ToString(), Url = dr["IMG_3"].ToString() });

			}
			P.Images = images;
			return P;
		}

		internal static Kovka ConvertToKovka(this DataRow dr)
		{
			Kovka P = new Kovka();
			List<Image> images = new List<Image>();

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
			if (dr["Price"] != DBNull.Value)
			{
				P.Price = Convert.ToDecimal(dr["Price"]);
			}
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToInt32(dr["Discount"]);
			}
			if (dr["Type"] != DBNull.Value)
			{
				P.Type = Convert.ToInt32(dr["Type"]);
			}
			if (dr["KOVKA_TYPE_NAME"] != DBNull.Value)
			{
				P.Type_Name = dr["KOVKA_TYPE_NAME"].ToString();
			}
			if (dr["Product_Type"] != DBNull.Value)
			{
				P.Product_Type = Convert.ToInt32(dr["Product_Type"]);
			}
			if (dr["PRODUCT_TYPE_NAME"] != DBNull.Value)
			{
				P.Product_Type_Name = dr["PRODUCT_TYPE_NAME"].ToString();
			}
			if (dr["IMAGE_1_NAME"] != DBNull.Value && dr["IMG_1"] != DBNull.Value)
			{
				P.Image = new Image() { Name = dr["IMAGE_1_NAME"].ToString(), Url = dr["IMG_1"].ToString() };
			}
			if (dr["IMAGE_2_NAME"] != DBNull.Value && dr["IMG_2"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_2_NAME"].ToString(), Url = dr["IMG_2"].ToString() });
			}
			if (dr["IMAGE_3_NAME"] != DBNull.Value && dr["IMG_3"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_3_NAME"].ToString(), Url = dr["IMG_3"].ToString() });

			}
			P.Images = images;
			return P;
		}

		internal static ProductDTO ConvertToProductDTO(this DataRow dr)
		{
			ProductDTO P = new ProductDTO();

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
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToByte(dr["Discount"]);
			}
			if (dr["Price"] != DBNull.Value)
			{
				P.Price = Convert.ToDecimal(dr["Price"]);
			}
			if (dr["Product_Type"] != DBNull.Value)
			{
				P.Product_Type = Convert.ToInt32(dr["Product_Type"]);
			}
			if (dr["PRODUCT_TYPE_NAME"] != DBNull.Value)
			{
				P.Product_Type_Name = dr["PRODUCT_TYPE_NAME"].ToString();
			}
			if (dr["IMAGE_1_NAME"] != DBNull.Value && dr["IMG_1"] != DBNull.Value)
			{
				P.Image = new Image() { Name = dr["IMAGE_1_NAME"].ToString(), Url = dr["IMG_1"].ToString() };
			}
			
			return P;
		}

		internal static PurchasedItem ConvertToPurchaisedItem(this DataRow dr)
		{
			PurchasedItem P = new PurchasedItem();

		
			if (dr["Name"] != DBNull.Value)
			{
				P.Name = dr["Name"].ToString();
			}
			if (dr["Description"] != DBNull.Value)
			{
				P.Description = dr["Description"].ToString();
			}
			if (dr["Count"] != DBNull.Value)
			{
				P.Count = Convert.ToInt32(dr["Count"]);
			}
			if (dr["Price"] != DBNull.Value)
			{
				P.Price = Convert.ToDecimal(dr["Price"]);
			}
			
			return P;
		}

		internal static Order ConvertToOrder(this DataRow dr)
		{
			Order P = new Order();


			if (dr["Name"] != DBNull.Value)
			{
				P.Name = dr["Name"].ToString();
			}
			if (dr["email"] != DBNull.Value)
			{
				P.Email = dr["email"].ToString();
			}
			if (dr["phone"] != DBNull.Value)
			{
				P.Phone = dr["phone"].ToString();
			}
			if (dr["address"] != DBNull.Value)
			{
				P.Address = dr["address"].ToString();
			}
			if (dr["date"] != DBNull.Value)
			{
				P.Date = Convert.ToDateTime(dr["date"]);
			}
			
			return P;
		}
	}
}
