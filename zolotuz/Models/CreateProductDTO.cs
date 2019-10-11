using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class CreateProductDTO
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Group { get; set; }
		public decimal Type { get; set; }
		public decimal SubType { get; set; }
		public decimal Discount { get; set; }

		public byte? cat_manufacturer;
		public byte? cat_color_palette;
		public byte? cat_appearance;
		public byte? cat_washable;
		public byte? cat_smell;
		public byte? cat_color;
		public byte? cat_room_type;
		public byte? cat_appointment;
		public byte? cat_type;
		public byte? cat_stencil_theme;
		public byte? cat_place_of_use;
		public byte? cat_created_for;
		public byte? cat_finish_guarantee;
		public byte? cat_effect;
		public byte? cat_volume;
		public byte? cat_duration_of_protection;
		public byte? cat_surface_of_application;
		public byte? cat_type_of_use;
		public byte? cat_brush_type;
		public byte? cat_width;
		public byte? cat_fiber_material;
		public byte? cat_structure;
		public byte? cat_resistant;
		public byte? cat_gluing_strength;
		public byte? cat_capture_time;
		public byte? cat_gluing_material;
		public byte? cat_frost_resistance;
		public byte? cat_heat_resistance;
		public byte? cat_color_after_drying;
		public byte? cat_external_material;
		public byte? cat_application_type;
		public byte? cat_paint_type;
		

		public IFormFile Img1 { get; set; }
		public IFormFile Img2 { get; set; }
		public IFormFile Img3 { get; set; }
		//public List<Image> Images { get; set; }


	}
}
