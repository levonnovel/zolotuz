using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class ProductFilter
	{
		public byte Product_group { get; set; }

		public byte Product_type { get; set; }

		public byte Product_subtype { get; set; }

		public List<byte> cat_manufacturer;

		public List<byte> cat_color_palette;

		public List<byte> cat_appearance;

		public List<byte> cat_washable;

		public List<byte> cat_smell;

		public List<byte> cat_color;

		public List<byte> cat_room_type;

		public List<byte> cat_appointment;

		public List<byte> cat_type;

		public List<byte> cat_stencil_theme;

		public List<byte> cat_place_of_use;

		public List<byte> cat_created_for;

		public List<byte> cat_finish_guarantee;

		public List<byte> cat_effect;

		public List<byte> cat_volume;

		public List<byte> cat_duration_of_protection;

		public List<byte> cat_surface_of_application;

		public List<byte> cat_type_of_use;

		public List<byte> cat_brush_type;

		public List<byte> cat_width;

		public List<byte> cat_fiber_material;

		public List<byte> cat_structure;

		public List<byte> cat_resistant;

		public List<byte> cat_gluing_strength;

		public List<byte> cat_capture_time;

		public List<byte> cat_gluing_material;

		public List<byte> cat_frost_resistance;

		public List<byte> cat_heat_resistance;

		public List<byte> cat_color_after_drying;

		public List<byte> cat_external_material;

		public List<byte> cat_application_type;

		public List<byte> cat_paint_type;

		public decimal? MinPrice { get; set; }

		public decimal? MaxPrice { get; set; }

		public int? Start { get; set; }

		public int? End { get; set; }
	}
}
