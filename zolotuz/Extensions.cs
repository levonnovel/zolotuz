﻿using System.Collections.Generic;
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
			if (dr["PAINT_TYPE_NAME"] != DBNull.Value)
			{
				P.Type = dr["PAINT_TYPE_NAME"].ToString();
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
				images.Add(new Image() { Name = dr["IMAGE_1_NAME"].ToString(), Base64 = dr["IMG_1"].ToString() });
			}
			if (dr["IMAGE_2_NAME"] != DBNull.Value && dr["IMG_2"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_2_NAME"].ToString(), Base64 = dr["IMG_2"].ToString() });
			}
			if (dr["IMAGE_3_NAME"] != DBNull.Value && dr["IMG_3"] != DBNull.Value)
			{
				images.Add(new Image() { Name = dr["IMAGE_3_NAME"].ToString(), Base64 = dr["IMG_3"].ToString() });
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
				P.Image = new Image() { Name = dr["IMAGE_1_NAME"].ToString(), Base64 = dr["IMG_1"].ToString() };
			}
			
			return P;
		}
	}
}
