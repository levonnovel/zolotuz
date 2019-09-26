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

        internal static Headers ConvertToHeader(this DataRow dr, List<Headers> H)
        {
            Headers headers = new Headers();
            byte productGroup;
            byte productType;
            byte productSubType;

            if (dr["product_group"] != DBNull.Value)
            {
                productGroup = Convert.ToByte(dr["product_group"]);
                
                if(!H.Exists(x =>  x.Id == productGroup))
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
                        headers1.Values.Add(new Types() { Id = productType});
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
                P.manufacturer = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["color_palette"] != DBNull.Value)
            {
                values = dr["color_palette"].ToString();
                P.color_palette = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["appearance"] != DBNull.Value)
            {
                values = dr["appearance"].ToString();
                P.appearance = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["washable"] != DBNull.Value)
            {
                values = dr["washable"].ToString();
                P.washable = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["smell"] != DBNull.Value)
            {
                values = dr["smell"].ToString();
                P.smell = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["color"] != DBNull.Value)
            {
                values = dr["color"].ToString();
                P.color = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["room_type"] != DBNull.Value)
            {
                values = dr["room_type"].ToString();
                P.room_type = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["appointment"] != DBNull.Value)
            {
                values = dr["appointment"].ToString();
                P.appointment = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["type"] != DBNull.Value)
            {
                values = dr["type"].ToString();
                P.type = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["stencil_theme"] != DBNull.Value)
            {
                values = dr["stencil_theme"].ToString();
                P.stencil_theme = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["place_of_use"] != DBNull.Value)
            {
                values = dr["place_of_use"].ToString();
                P.place_of_use = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["created_for"] != DBNull.Value)
            {
                values = dr["created_for"].ToString();
                P.created_for = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["finish_guarantee"] != DBNull.Value)
            {
                values = dr["finish_guarantee"].ToString();
                P.finish_guarantee = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["effect"] != DBNull.Value)
            {
                values = dr["effect"].ToString();
                P.effect = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["volume"] != DBNull.Value)
            {
                values = dr["volume"].ToString();
                P.volume = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["duration_of_protection"] != DBNull.Value)
            {
                values = dr["duration_of_protection"].ToString();
                P.duration_of_protection = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["surface_of_application"] != DBNull.Value)
            {
                values = dr["surface_of_application"].ToString();
                P.surface_of_application = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["type_of_use"] != DBNull.Value)
            {
                values = dr["type_of_use"].ToString();
                P.type_of_use = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["brush_type"] != DBNull.Value)
            {
                values = dr["brush_type"].ToString();
                P.brush_type = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["width"] != DBNull.Value)
            {
                values = dr["width"].ToString();
                P.width = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["fiber_material"] != DBNull.Value)
            {
                values = dr["fiber_material"].ToString();
                P.fiber_material = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["structure"] != DBNull.Value)
            {
                values = dr["structure"].ToString();
                P.structure = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["resistant"] != DBNull.Value)
            {
                values = dr["resistant"].ToString();
                P.resistant = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["gluing_strength"] != DBNull.Value)
            {
                values = dr["gluing_strength"].ToString();
                P.gluing_strength = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["capture_time"] != DBNull.Value)
            {
                values = dr["capture_time"].ToString();
                P.capture_time = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["gluing_material"] != DBNull.Value)
            {
                values = dr["gluing_material"].ToString();
                P.gluing_material = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["frost_resistance"] != DBNull.Value)
            {
                values = dr["frost_resistance"].ToString();
                P.frost_resistance = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["heat_resistance"] != DBNull.Value)
            {
                values = dr["heat_resistance"].ToString();
                P.heat_resistance = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["color_after_drying"] != DBNull.Value)
            {
                values = dr["color_after_drying"].ToString();
                P.color_after_drying = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["external_material"] != DBNull.Value)
            {
                values = dr["external_material"].ToString();
                P.external_material = values.Split(',').Select(byte.Parse).ToList(); ;
            }
            if (dr["application_type"] != DBNull.Value)
            {
                values = dr["application_type"].ToString();
                P.application_type = values.Split(',').Select(byte.Parse).ToList(); ;
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
            if (dr["manufacturer"] != DBNull.Value)
            {
                P.manufacturer = Convert.ToByte(dr["manufacturer"]);
            }
            if (dr["color_palette"] != DBNull.Value)
            {
                P.color_palette = Convert.ToByte(dr["color_palette"]);
            }
            if (dr["appearance"] != DBNull.Value)
            {
                P.appearance = Convert.ToByte(dr["appearance"]);
            }
            if (dr["washable"] != DBNull.Value)
            {
                P.washable = Convert.ToByte(dr["washable"]);
            }
            if (dr["smell"] != DBNull.Value)
            {
                P.smell = Convert.ToByte(dr["smell"]);
            }
            if (dr["color"] != DBNull.Value)
            {
                P.color = Convert.ToByte(dr["color"]);
            }
            if (dr["room_type"] != DBNull.Value)
            {
                P.room_type = Convert.ToByte(dr["room_type"]);
            }
            if (dr["appointment"] != DBNull.Value)
            {
                P.appointment = Convert.ToByte(dr["appointment"]);
            }
            if (dr["type"] != DBNull.Value)
            {
                P.type = Convert.ToByte(dr["type"]);
            }
            if (dr["stencil_theme"] != DBNull.Value)
            {
                P.stencil_theme = Convert.ToByte(dr["stencil_theme"]);
            }
            if (dr["place_of_use"] != DBNull.Value)
            {
                P.place_of_use = Convert.ToByte(dr["place_of_use"]);
            }
            if (dr["created_for"] != DBNull.Value)
            {
                P.created_for = Convert.ToByte(dr["created_for"]);
            }
            if (dr["finish_guarantee"] != DBNull.Value)
            {
                P.finish_guarantee = Convert.ToByte(dr["finish_guarantee"]);
            }
            if (dr["effect"] != DBNull.Value)
            {
                P.effect = Convert.ToByte(dr["effect"]);
            }
            if (dr["volume"] != DBNull.Value)
            {
                P.volume = Convert.ToByte(dr["volume"]);
            }
            if (dr["duration_of_protection"] != DBNull.Value)
            {
                P.duration_of_protection = Convert.ToByte(dr["duration_of_protection"]);
            }
            if (dr["surface_of_application"] != DBNull.Value)
            {
                P.surface_of_application = Convert.ToByte(dr["surface_of_application"]);
            }
            if (dr["type_of_use"] != DBNull.Value)
            {
                P.type_of_use = Convert.ToByte(dr["type_of_use"]);
            }
            if (dr["brush_type"] != DBNull.Value)
            {
                P.brush_type = Convert.ToByte(dr["brush_type"]);
            }
            if (dr["width"] != DBNull.Value)
            {
                P.width = Convert.ToByte(dr["width"]);
            }
            if (dr["fiber_material"] != DBNull.Value)
            {
                P.fiber_material = Convert.ToByte(dr["fiber_material"]);
            }
            if (dr["structure"] != DBNull.Value)
            {
                P.structure = Convert.ToByte(dr["structure"]);
            }
            if (dr["resistant"] != DBNull.Value)
            {
                P.resistant = Convert.ToByte(dr["resistant"]);
            }
            if (dr["gluing_strength"] != DBNull.Value)
            {
                P.gluing_strength = Convert.ToByte(dr["gluing_strength"]);
            }
            if (dr["capture_time"] != DBNull.Value)
            {
                P.capture_time = Convert.ToByte(dr["capture_time"]);
            }
            if (dr["gluing_material"] != DBNull.Value)
            {
                P.gluing_material = Convert.ToByte(dr["gluing_material"]);
            }
            if (dr["frost_resistance"] != DBNull.Value)
            {
                P.frost_resistance = Convert.ToByte(dr["frost_resistance"]);
            }
            if (dr["heat_resistance"] != DBNull.Value)
            {
                P.heat_resistance = Convert.ToByte(dr["heat_resistance"]);
            }
            if (dr["color_after_drying"] != DBNull.Value)
            {
                P.color_after_drying = Convert.ToByte(dr["color_after_drying"]);
            }
            if (dr["external_material"] != DBNull.Value)
            {
                P.external_material = Convert.ToByte(dr["external_material"]);
            }
            if (dr["application_type"] != DBNull.Value)
            {
                P.application_type = Convert.ToByte(dr["application_type"]);
            }

            return P;
        }

        internal static Product ConvertToProduct(this DataRow dr)
        {
            Product P = new Product();
            string values;

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
            if (dr["id"] != DBNull.Value)
            {
                P.Id = Convert.ToInt32(dr["id"]);
            }
            if (dr["manufacturer_name"] != DBNull.Value)
            {
                P.manufacturer_name = dr["manufacturer_name"].ToString();
            }
            if (dr["color_palette_name"] != DBNull.Value)
            {
                P.color_palette_name = dr["color_palette_name"].ToString();
            }
            if (dr["appearance_name"] != DBNull.Value)
            {
                P.appearance_name = dr["appearance_name"].ToString();
            }
            if (dr["washable_name"] != DBNull.Value)
            {
                P.washable_name = dr["washable_name"].ToString();
            }
            if (dr["smell_name"] != DBNull.Value)
            {
                P.smell_name = dr["smell_name"].ToString();
            }
            if (dr["color_name"] != DBNull.Value)
            {
                P.color_name = dr["color_name"].ToString();
            }
            if (dr["room_type_name"] != DBNull.Value)
            {
                values = dr["room_type_name"].ToString();
                P.room_type_name = dr["room_type_name"].ToString();
            }
            if (dr["appointment_name"] != DBNull.Value)
            {
                P.appointment_name = dr["appointment_name"].ToString();
            }
            if (dr["type_name"] != DBNull.Value)
            {
                P.type_name = dr["type_name"].ToString();
            }
            if (dr["stencil_theme_name"] != DBNull.Value)
            {
                P.stencil_theme_name = dr["stencil_theme_name"].ToString();
            }
            if (dr["place_of_use_name"] != DBNull.Value)
            {
                P.place_of_use_name = dr["place_of_use_name"].ToString();
            }
            if (dr["created_for_name"] != DBNull.Value)
            {
                values = dr["created_for_name"].ToString();
                P.created_for_name = dr["created_for_name"].ToString();
            }
            if (dr["finish_guarantee_name"] != DBNull.Value)
            {
                P.finish_guarantee_name = dr["finish_guarantee_name"].ToString();
            }
            if (dr["effect_name"] != DBNull.Value)
            {
                P.effect_name = dr["effect_name"].ToString();
            }
            if (dr["volume_name"] != DBNull.Value)
            {
                P.volume_name = dr["volume_name"].ToString();
            }
            if (dr["duration_of_protection_name"] != DBNull.Value)
            {
                P.duration_of_protection_name = dr["duration_of_protection_name"].ToString();
            }
            if (dr["surface_of_application_name"] != DBNull.Value)
            {
                P.surface_of_application_name = dr["surface_of_application_name"].ToString();
            }
            if (dr["type_of_use_name"] != DBNull.Value)
            {
                P.type_of_use_name = dr["type_of_use_name"].ToString();
            }
            if (dr["brush_type_name"] != DBNull.Value)
            {
                P.brush_type_name = dr["brush_type_name"].ToString();
            }
            if (dr["width_name"] != DBNull.Value)
            {
                P.width_name = dr["width_name"].ToString();
            }
            if (dr["fiber_material_name"] != DBNull.Value)
            {
                P.fiber_material_name = dr["fiber_material_name"].ToString();
            }
            if (dr["structure_name"] != DBNull.Value)
            {
                P.structure_name = dr["structure_name"].ToString();
            }
            if (dr["resistant_name"] != DBNull.Value)
            {
                P.resistant_name = dr["resistant_name"].ToString();
            }
            if (dr["gluing_strength_name"] != DBNull.Value)
            {
                P.gluing_strength_name = dr["gluing_strength_name"].ToString();
            }
            if (dr["capture_time_name"] != DBNull.Value)
            {
                P.capture_time_name = dr["capture_time_name"].ToString();
            }
            if (dr["gluing_material_name"] != DBNull.Value)
            {
                P.gluing_material_name = dr["gluing_material_name"].ToString();
            }
            if (dr["frost_resistance_name"] != DBNull.Value)
            {
                P.frost_resistance_name = dr["frost_resistance_name"].ToString();
            }
            if (dr["heat_resistance_name"] != DBNull.Value)
            {
                P.heat_resistance_name = dr["heat_resistance_name"].ToString();
            }
            if (dr["color_after_drying_name"] != DBNull.Value)
            {
                P.color_after_drying_name = dr["color_after_drying_name"].ToString();
            }
            if (dr["external_material_name"] != DBNull.Value)
            {
                P.external_material_name = dr["external_material_name"].ToString();
            }
            if (dr["application_type_name"] != DBNull.Value)
            {
                P.application_type_name = dr["application_type_name"].ToString();
            }

            return P;
        }
    }
}
