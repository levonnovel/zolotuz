using System.Collections.Generic;
using System.Data;
using System.Text;
using zolotuz.Models;
using System;
using System.Linq;

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
			if (list != null)
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
			//if (dr["Discount"] != DBNull.Value)
			//{
			//	P.Discount = Convert.ToInt32(dr["Discount"]);
			//}
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
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToByte(dr["Discount"]);
				P.DiscountedPrice = Math.Round((P.Price * (100 - P.Discount)) / 100);
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
			//if (dr["Discount"] != DBNull.Value)
			//{
			//	P.Discount = Convert.ToInt32(dr["Discount"]);
			//}
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToByte(dr["Discount"]);
				P.DiscountedPrice = Math.Round((P.Price * (100 - P.Discount)) / 100);
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
			//if (dr["Discount"] != DBNull.Value)
			//{
			//	P.Discount = Convert.ToInt32(dr["Discount"]);
			//}
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToByte(dr["Discount"]);
				P.DiscountedPrice = Math.Round((P.Price * (100 - P.Discount)) / 100);
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
			if (dr["Price"] != DBNull.Value)
			{
				P.Price = Convert.ToDecimal(dr["Price"]);
			}
			if (dr["Discount"] != DBNull.Value)
			{
				P.Discount = Convert.ToByte(dr["Discount"]);
				P.DiscountedPrice = Math.Round((P.Price * (100 - P.Discount)) / 100);
			}
			//if (dr["Product_Type"] != DBNull.Value)
			//{
			//	P.Product_Type = Convert.ToInt32(dr["Product_Type"]);
			//}
			//if (dr["PRODUCT_TYPE_NAME"] != DBNull.Value)
			//{
			//	P.Product_Type_Name = dr["PRODUCT_TYPE_NAME"].ToString();
			//}
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

		internal static Headers ConvertToHeader(this DataRow dr, List<Headers> H)
		{
			Headers headers = new Headers();
			byte productGroup;
			byte productType;
			byte productSubType;

			if (dr["product_group"] != DBNull.Value)
			{
				productGroup = Convert.ToByte(dr["product_group"]);

				if (!H.Exists(x => x.Id == productGroup))
				//if (H.ElementAtOrDefault(productGroup - 1) == null)//(!H.ContainsKey(productGroup))
				{
					H.Add(new Headers() { Id = productGroup });
				}

				Headers headers1 = H.Find(x => x.Id == productGroup);

				if (dr["group_name"] != DBNull.Value)
				{
					//H.Find(x => x.Id == productGroup).Name = dr["group_name"].ToString();
					headers1.Name = dr["group_name"].ToString();
				}
				if (dr["group_eng_name"] != DBNull.Value)
				{
					//H[productGroup - 1].EngName = dr["group_eng_name"].ToString();
					headers1.EngName = dr["group_eng_name"].ToString();
				}

				//H[productGroup - 1].Id = productGroup;

				if (dr["product_type"] != DBNull.Value)
				{
					productType = Convert.ToByte(dr["product_type"]);


					// if (H[productGroup - 1].Values.ElementAtOrDefault(productType - 1) == null)
					if (!headers1.Values.Exists(x => x.Id == productType))
					{
						//H[productGroup - 1].Values.Add(new Types());
						headers1.Values.Add(new Types() { Id = productType });
					}

					Types types1 = headers1.Values.Find(x => x.Id == productType);

					if (dr["product_subtype"] != DBNull.Value)
					{
						productSubType = Convert.ToByte(dr["product_subtype"]);

						if (!types1.Values.Exists(x => x.Id == productSubType))
						{
							types1.Values.Add(new SubTypes() { Id = productSubType });
						}

						SubTypes subTypes1 = types1.Values.Find(x => x.Id == productSubType);

						if (dr["subtype_name"] != DBNull.Value)
						{
							subTypes1.Name = dr["subtype_name"].ToString();
						}

						if (dr["subtype_eng_name"] != DBNull.Value)
						{
							subTypes1.EngName = dr["subtype_eng_name"].ToString();
						}

						//H[productGroup - 1].Values[productType - 1].Values[productSubType - 1].Id = productSubType;

					}

					if (dr["type_name"] != DBNull.Value)
					{
						types1.Name = dr["type_name"].ToString();
					}

					if (dr["type_eng_name"] != DBNull.Value)
					{
						types1.EngName = dr["type_eng_name"].ToString();
					}

					//H[productGroup - 1].Values[productType - 1].Id = productType;
				}
			}

			return headers;
		}

		internal static PageFiltersValues ConvertToPageFilterValues(this DataRow dr)
		{
			PageFiltersValues P = new PageFiltersValues();
			string values;

			if (dr["product_group"] != DBNull.Value)
			{
				P.product_group = Convert.ToByte(dr["product_group"]);
			}
			if (dr["product_type"] != DBNull.Value)
			{
				P.product_type = Convert.ToByte(dr["product_type"]);
			}
			if (dr["product_subtype"] != DBNull.Value)
			{
				P.product_subType = Convert.ToByte(dr["product_subtype"]);
			}

			if (dr["manufacturer"] != DBNull.Value)
			{
				values = dr["manufacturer"].ToString();
				P.cat_manufacturer = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["color_palette"] != DBNull.Value)
			{
				values = dr["color_palette"].ToString();
				P.cat_color_palette = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["appearance"] != DBNull.Value)
			{
				values = dr["appearance"].ToString();
				P.cat_appearance = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["washable"] != DBNull.Value)
			{
				values = dr["washable"].ToString();
				P.cat_washable = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["smell"] != DBNull.Value)
			{
				values = dr["smell"].ToString();
				P.cat_smell = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["color"] != DBNull.Value)
			{
				values = dr["color"].ToString();
				P.cat_color = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["room_type"] != DBNull.Value)
			{
				values = dr["room_type"].ToString();
				P.cat_room_type = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["appointment"] != DBNull.Value)
			{
				values = dr["appointment"].ToString();
				P.cat_appointment = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["type"] != DBNull.Value)
			{
				values = dr["type"].ToString();
				P.cat_type = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["stencil_theme"] != DBNull.Value)
			{
				values = dr["stencil_theme"].ToString();
				P.cat_stencil_theme = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["place_of_use"] != DBNull.Value)
			{
				values = dr["place_of_use"].ToString();
				P.cat_place_of_use = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["created_for"] != DBNull.Value)
			{
				values = dr["created_for"].ToString();
				P.cat_created_for = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["finish_guarantee"] != DBNull.Value)
			{
				values = dr["finish_guarantee"].ToString();
				P.cat_finish_guarantee = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["effect"] != DBNull.Value)
			{
				values = dr["effect"].ToString();
				P.cat_effect = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["volume"] != DBNull.Value)
			{
				values = dr["volume"].ToString();
				P.cat_volume = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["duration_of_protection"] != DBNull.Value)
			{
				values = dr["duration_of_protection"].ToString();
				P.cat_duration_of_protection = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["surface_of_application"] != DBNull.Value)
			{
				values = dr["surface_of_application"].ToString();
				P.cat_surface_of_application = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["type_of_use"] != DBNull.Value)
			{
				values = dr["type_of_use"].ToString();
				P.cat_type_of_use = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["brush_type"] != DBNull.Value)
			{
				values = dr["brush_type"].ToString();
				P.cat_brush_type = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["width"] != DBNull.Value)
			{
				values = dr["width"].ToString();
				P.cat_width = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["fiber_material"] != DBNull.Value)
			{
				values = dr["fiber_material"].ToString();
				P.cat_fiber_material = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["structure"] != DBNull.Value)
			{
				values = dr["structure"].ToString();
				P.cat_structure = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["resistant"] != DBNull.Value)
			{
				values = dr["resistant"].ToString();
				P.cat_resistant = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["gluing_strength"] != DBNull.Value)
			{
				values = dr["gluing_strength"].ToString();
				P.cat_gluing_strength = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["capture_time"] != DBNull.Value)
			{
				values = dr["capture_time"].ToString();
				P.cat_capture_time = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["gluing_material"] != DBNull.Value)
			{
				values = dr["gluing_material"].ToString();
				P.cat_gluing_material = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["frost_resistance"] != DBNull.Value)
			{
				values = dr["frost_resistance"].ToString();
				P.cat_frost_resistance = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["heat_resistance"] != DBNull.Value)
			{
				values = dr["heat_resistance"].ToString();
				P.cat_heat_resistance = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["color_after_drying"] != DBNull.Value)
			{
				values = dr["color_after_drying"].ToString();
				P.cat_color_after_drying = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["external_material"] != DBNull.Value)
			{
				values = dr["external_material"].ToString();
				P.cat_external_material = values.Split(',').Select(byte.Parse).ToList(); ;
			}
			if (dr["application_type"] != DBNull.Value)
			{
				values = dr["application_type"].ToString();
				P.cat_application_type = values.Split(',').Select(byte.Parse).ToList(); ;
			}

			return P;
		}

		internal static PageFilters ConvertToPageFilter(this DataRow dr)
		{
			PageFilters P = new PageFilters();

			if (dr["product_group"] != DBNull.Value)
			{
				P.product_group = Convert.ToByte(dr["product_group"]);
			}
			if (dr["product_type"] != DBNull.Value)
			{
				P.product_type = Convert.ToByte(dr["product_type"]);
			}
			if (dr["product_subtype"] != DBNull.Value)
			{
				P.product_subType = Convert.ToByte(dr["product_subtype"]);
			}
			if (dr["cat_manufacturer"] != DBNull.Value)
			{
				P.cat_manufacturer = Convert.ToByte(dr["cat_manufacturer"]);
			}
			if (dr["cat_color_palette"] != DBNull.Value)
			{
				P.cat_color_palette = Convert.ToByte(dr["cat_color_palette"]);
			}
			if (dr["cat_appearance"] != DBNull.Value)
			{
				P.cat_appearance = Convert.ToByte(dr["cat_appearance"]);
			}
			if (dr["cat_washable"] != DBNull.Value)
			{
				P.cat_washable = Convert.ToByte(dr["cat_washable"]);
			}
			if (dr["cat_smell"] != DBNull.Value)
			{
				P.cat_smell = Convert.ToByte(dr["cat_smell"]);
			}
			if (dr["cat_color"] != DBNull.Value)
			{
				P.cat_color = Convert.ToByte(dr["cat_color"]);
			}
			if (dr["cat_room_type"] != DBNull.Value)
			{
				P.cat_room_type = Convert.ToByte(dr["cat_room_type"]);
			}
			if (dr["cat_appointment"] != DBNull.Value)
			{
				P.cat_appointment = Convert.ToByte(dr["cat_appointment"]);
			}
			if (dr["cat_type"] != DBNull.Value)
			{
				P.cat_type = Convert.ToByte(dr["cat_type"]);
			}
			if (dr["cat_stencil_theme"] != DBNull.Value)
			{
				P.cat_stencil_theme = Convert.ToByte(dr["cat_stencil_theme"]);
			}
			if (dr["cat_place_of_use"] != DBNull.Value)
			{
				P.cat_place_of_use = Convert.ToByte(dr["cat_place_of_use"]);
			}
			if (dr["cat_created_for"] != DBNull.Value)
			{
				P.cat_created_for = Convert.ToByte(dr["cat_created_for"]);
			}
			if (dr["cat_finish_guarantee"] != DBNull.Value)
			{
				P.cat_finish_guarantee = Convert.ToByte(dr["cat_finish_guarantee"]);
			}
			if (dr["cat_effect"] != DBNull.Value)
			{
				P.cat_effect = Convert.ToByte(dr["cat_effect"]);
			}
			if (dr["cat_volume"] != DBNull.Value)
			{
				P.cat_volume = Convert.ToByte(dr["cat_volume"]);
			}
			if (dr["cat_duration_of_protection"] != DBNull.Value)
			{
				P.cat_duration_of_protection = Convert.ToByte(dr["cat_duration_of_protection"]);
			}
			if (dr["cat_surface_of_application"] != DBNull.Value)
			{
				P.cat_surface_of_application = Convert.ToByte(dr["cat_surface_of_application"]);
			}
			if (dr["cat_type_of_use"] != DBNull.Value)
			{
				P.cat_type_of_use = Convert.ToByte(dr["cat_type_of_use"]);
			}
			if (dr["cat_brush_type"] != DBNull.Value)
			{
				P.cat_brush_type = Convert.ToByte(dr["cat_brush_type"]);
			}
			if (dr["cat_width"] != DBNull.Value)
			{
				P.cat_width = Convert.ToByte(dr["cat_width"]);
			}
			if (dr["cat_fiber_material"] != DBNull.Value)
			{
				P.cat_fiber_material = Convert.ToByte(dr["cat_fiber_material"]);
			}
			if (dr["cat_structure"] != DBNull.Value)
			{
				P.cat_structure = Convert.ToByte(dr["cat_structure"]);
			}
			if (dr["cat_resistant"] != DBNull.Value)
			{
				P.cat_resistant = Convert.ToByte(dr["cat_resistant"]);
			}
			if (dr["cat_gluing_strength"] != DBNull.Value)
			{
				P.cat_gluing_strength = Convert.ToByte(dr["cat_gluing_strength"]);
			}
			if (dr["cat_capture_time"] != DBNull.Value)
			{
				P.cat_capture_time = Convert.ToByte(dr["cat_capture_time"]);
			}
			if (dr["cat_gluing_material"] != DBNull.Value)
			{
				P.cat_gluing_material = Convert.ToByte(dr["cat_gluing_material"]);
			}
			if (dr["cat_frost_resistance"] != DBNull.Value)
			{
				P.cat_frost_resistance = Convert.ToByte(dr["cat_frost_resistance"]);
			}
			if (dr["cat_heat_resistance"] != DBNull.Value)
			{
				P.cat_heat_resistance = Convert.ToByte(dr["cat_heat_resistance"]);
			}
			if (dr["cat_color_after_drying"] != DBNull.Value)
			{
				P.cat_color_after_drying = Convert.ToByte(dr["cat_color_after_drying"]);
			}
			if (dr["cat_external_material"] != DBNull.Value)
			{
				P.cat_external_material = Convert.ToByte(dr["cat_external_material"]);
			}
			if (dr["cat_application_type"] != DBNull.Value)
			{
				P.cat_application_type = Convert.ToByte(dr["cat_application_type"]);
			}

			return P;
		}

		internal static Product ConvertToProduct(this DataRow dr, Product P)
		{
			//Product P = new Product();
			var refs = DataProvider.GetRefNames();
            List<Image> images = new List<Image>();
           
            //if (dr["product_group_name"] != DBNull.Value)
            //{
            //    P.product_group = Convert.ToByte(dr["product_group_name"]);
            //}
            //if (dr["product_type_name"] != DBNull.Value)
            //{
            //    P.product_type = Convert.ToByte(dr["product_type_name"]);
            //}
            //if (dr["product_subtype_name"] != DBNull.Value)
            //{
            //    P.product_subType = Convert.ToByte(dr["product_subtype_name"]);
            //}
            if (dr["Id"] != DBNull.Value)
			{
				P.Id = Convert.ToInt32(dr["Id"]);
			}
            if (dr["product_group"] != DBNull.Value)
            {
                P.Group = Convert.ToInt32(dr["product_group"]);
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
				P.Discount = Convert.ToByte(dr["Discount"]);
				P.DiscountedPrice = Math.Round((P.Price * (100 - P.Discount)) / 100);
			}

			if (dr["manufacturer_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_manufacturer").Value, Value = dr["manufacturer_name"].ToString() });
			}
			if (dr["color_palette_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_color_palette").Value, Value = dr["color_palette_name"].ToString() });
			}
			if (dr["appearance_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_appearance").Value, Value = dr["appearance_name"].ToString() });
			}
			if (dr["washable_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_washable").Value, Value = dr["washable_name"].ToString() });
			}
			if (dr["smell_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_smell").Value, Value = dr["smell_name"].ToString() });
			}
			if (dr["color_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_color").Value, Value = dr["color_name"].ToString() });
			}
			if (dr["room_type_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_room_type").Value, Value = dr["room_type_name"].ToString() });
			}
			if (dr["appointment_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_appointment").Value, Value = dr["appointment_name"].ToString() });
			}
			if (dr["type_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_type").Value, Value = dr["type_name"].ToString() });
			}
			if (dr["stencil_theme_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_stencil_theme").Value, Value = dr["stencil_theme_name"].ToString() });
			}
			if (dr["place_of_use_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_place_of_use").Value, Value = dr["place_of_use_name"].ToString() });
			}
			if (dr["created_for_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_created_for").Value, Value = dr["created_for_name"].ToString() });
			}
			if (dr["finish_guarantee_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_finish_guarantee").Value, Value = dr["finish_guarantee_name"].ToString() });
			}
			if (dr["effect_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_effect").Value, Value = dr["effect_name"].ToString() });
			}
			if (dr["volume_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_volume").Value, Value = dr["volume_name"].ToString() });
			}
			if (dr["duration_of_protection_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_duration_of_protection").Value, Value = dr["duration_of_protection_name"].ToString() });
			}
			if (dr["surface_of_application_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_surface_of_application").Value, Value = dr["surface_of_application_name"].ToString() });
			}
			if (dr["type_of_use_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_type_of_use").Value, Value = dr["type_of_use_name"].ToString() });
			}
			if (dr["brush_type_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_brush_type").Value, Value = dr["brush_type_name"].ToString() });
			}
			if (dr["width_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_width").Value, Value = dr["width_name"].ToString() });
			}
			if (dr["fiber_material_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_fiber_material").Value, Value = dr["fiber_material_name"].ToString() });
			}
			if (dr["structure_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_structure").Value, Value = dr["structure_name"].ToString() });
			}
			if (dr["resistant_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_resistant").Value, Value = dr["resistant_name"].ToString() });
			}
			if (dr["gluing_strength_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_gluing_strength").Value, Value = dr["gluing_strength_name"].ToString() });
			}
			if (dr["capture_time_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_capture_time").Value, Value = dr["capture_time_name"].ToString() });
			}
			if (dr["gluing_material_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_gluing_material").Value, Value = dr["gluing_material_name"].ToString() });
			}
			if (dr["frost_resistance_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_frost_resistance").Value, Value = dr["frost_resistance_name"].ToString() });
			}
			if (dr["heat_resistance_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_heat_resistance").Value, Value = dr["heat_resistance_name"].ToString() });
			}
			if (dr["color_after_drying_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_color_after_drying").Value, Value = dr["color_after_drying_name"].ToString() });
			}
			if (dr["external_material_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_external_material").Value, Value = dr["external_material_name"].ToString() });
			}
			if (dr["application_type_name"] != DBNull.Value)
			{
				P.produtInfos.Add(new ProductInfo() { Label = refs.First(x => x.Key == "cat_application_type").Value, Value = dr["application_type_name"].ToString() });
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

        internal static Dictionary<string, byte> ConvertToProductCategory(this DataRow dr)
        {
            Dictionary<string, byte> Dict = new Dictionary<string, byte>();

            if (dr["cat_manufacturer"] != DBNull.Value)
            {
                Dict.Add("cat_manufacturer", Convert.ToByte(dr["cat_manufacturer"]));
            }
            if (dr["cat_color_palette"] != DBNull.Value)
            {
                Dict.Add("cat_color_palette", Convert.ToByte(dr["cat_color_palette"]));
            }
            if (dr["cat_appearance"] != DBNull.Value)
            {
                Dict.Add("cat_appearance", Convert.ToByte(dr["cat_appearance"]));
            }
            if (dr["cat_washable"] != DBNull.Value)
            {
                Dict.Add("cat_washable", Convert.ToByte(dr["cat_washable"]));
            }
            if (dr["cat_smell"] != DBNull.Value)
            {
                Dict.Add("cat_smell", Convert.ToByte(dr["cat_smell"]));
            }
            if (dr["cat_color"] != DBNull.Value)
            {
                Dict.Add("cat_color", Convert.ToByte(dr["cat_color"]));
            }
            if (dr["cat_room_type"] != DBNull.Value)
            {
                Dict.Add("cat_room_type", Convert.ToByte(dr["cat_room_type"]));
            }
            if (dr["cat_appointment"] != DBNull.Value)
            {
                Dict.Add("cat_appointment", Convert.ToByte(dr["cat_appointment"]));
            }
            if (dr["cat_type"] != DBNull.Value)
            {
                Dict.Add("cat_type", Convert.ToByte(dr["cat_type"]));
            }
            if (dr["cat_stencil_theme"] != DBNull.Value)
            {
                Dict.Add("cat_stencil_theme", Convert.ToByte(dr["cat_stencil_theme"]));
            }
            if (dr["cat_place_of_use"] != DBNull.Value)
            {
                Dict.Add("cat_place_of_use", Convert.ToByte(dr["cat_place_of_use"]));
            }
            if (dr["cat_created_for"] != DBNull.Value)
            {
                Dict.Add("cat_created_for", Convert.ToByte(dr["cat_created_for"]));
            }
            if (dr["cat_finish_guarantee"] != DBNull.Value)
            {
                Dict.Add("cat_finish_guarantee", Convert.ToByte(dr["cat_finish_guarantee"]));
            }
            if (dr["cat_effect"] != DBNull.Value)
            {
                Dict.Add("cat_effect", Convert.ToByte(dr["cat_effect"]));
            }
            if (dr["cat_volume"] != DBNull.Value)
            {
                Dict.Add("cat_volume", Convert.ToByte(dr["cat_volume"]));
            }
            if (dr["cat_duration_of_protection"] != DBNull.Value)
            {
                Dict.Add("cat_duration_of_protection", Convert.ToByte(dr["cat_duration_of_protection"]));
            }
            if (dr["cat_surface_of_application"] != DBNull.Value)
            {
                Dict.Add("cat_surface_of_application", Convert.ToByte(dr["cat_surface_of_application"]));
            }
            if (dr["cat_type_of_use"] != DBNull.Value)
            {
                Dict.Add("cat_type_of_use", Convert.ToByte(dr["cat_type_of_use"]));
            }
            if (dr["cat_brush_type"] != DBNull.Value)
            {
                Dict.Add("cat_brush_type", Convert.ToByte(dr["cat_brush_type"]));
            }
            if (dr["cat_width"] != DBNull.Value)
            {
                Dict.Add("cat_width", Convert.ToByte(dr["cat_width"]));
            }
            if (dr["cat_fiber_material"] != DBNull.Value)
            {
                Dict.Add("cat_fiber_material", Convert.ToByte(dr["cat_fiber_material"]));
            }
            if (dr["cat_structure"] != DBNull.Value)
            {
                Dict.Add("cat_structure", Convert.ToByte(dr["cat_structure"]));
            }
            if (dr["cat_resistant"] != DBNull.Value)
            {
                Dict.Add("cat_resistant", Convert.ToByte(dr["cat_resistant"]));
            }
            if (dr["cat_gluing_strength"] != DBNull.Value)
            {
                Dict.Add("cat_gluing_strength", Convert.ToByte(dr["cat_gluing_strength"]));
            }
            if (dr["cat_capture_time"] != DBNull.Value)
            {
                Dict.Add("cat_capture_time", Convert.ToByte(dr["cat_capture_time"]));
            }
            if (dr["cat_gluing_material"] != DBNull.Value)
            {
                Dict.Add("cat_gluing_material", Convert.ToByte(dr["cat_gluing_material"]));
            }
            if (dr["cat_frost_resistance"] != DBNull.Value)
            {
                Dict.Add("cat_frost_resistance", Convert.ToByte(dr["cat_frost_resistance"]));
            }
            if (dr["cat_heat_resistance"] != DBNull.Value)
            {
                Dict.Add("cat_heat_resistance", Convert.ToByte(dr["cat_heat_resistance"]));
            }
            if (dr["cat_color_after_drying"] != DBNull.Value)
            {
                Dict.Add("cat_color_after_drying", Convert.ToByte(dr["cat_color_after_drying"]));
            }
            if (dr["cat_external_material"] != DBNull.Value)
            {
                Dict.Add("cat_external_material", Convert.ToByte(dr["cat_external_material"]));
            }
            if (dr["cat_application_type"] != DBNull.Value)
            {
                Dict.Add("cat_application_type", Convert.ToByte(dr["cat_application_type"]));
            }

            return Dict;
        }
    }
}
