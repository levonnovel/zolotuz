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

		public List<byte> Cat_manufacturer {get; set;}
		public List<byte> Cat_color_palette {get; set;}
		public List<byte> Cat_appearance {get; set;}
		public List<byte> Cat_washable {get; set;}
		public List<byte> Cat_smell {get; set;}
		public List<byte> Cat_color {get; set;}
		public List<byte> Cat_room_type {get; set;}
		public List<byte> Cat_appointment {get; set;}
		public List<byte> Cat_type {get; set;}
		public List<byte> Cat_stencil_theme {get; set;}
		public List<byte> Cat_place_of_use {get; set;}
		public List<byte> Cat_created_for {get; set;}
		public List<byte> Cat_finish_guarantee {get; set;}
		public List<byte> Cat_effect {get; set;}
		public List<byte> Cat_volume {get; set;}
		public List<byte> Cat_duration_of_protection {get; set;}
		public List<byte> Cat_surface_of_application {get; set;}
		public List<byte> Cat_type_of_use {get; set;}
		public List<byte> Cat_brush_type {get; set;}
		public List<byte> Cat_width {get; set;}
		public List<byte> Cat_fiber_material {get; set;}
		public List<byte> Cat_structure {get; set;}
		public List<byte> Cat_resistant {get; set;}
		public List<byte> Cat_gluing_strength {get; set;}
		public List<byte> Cat_capture_time {get; set;}
		public List<byte> Cat_gluing_material {get; set;}
		public List<byte> Cat_frost_resistance {get; set;}
		public List<byte> Cat_heat_resistance {get; set;}
		public List<byte> Cat_color_after_drying {get; set;}
		public List<byte> Cat_external_material {get; set;}
		public List<byte> Cat_application_type {get; set;}
		public List<byte> Cat_paint_type {get; set;}
		public List<byte> Cat_consumption { get; set; }
		public List<byte> Cat_application_temperature { get; set; }

		public decimal? Min_price { get; set; }
		public decimal? Max_price { get; set; }
		public int? Start { get; set; }
		public int? End { get; set; }
	}
}
