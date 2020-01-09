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
		public decimal? Type { get; set; }
		public decimal? SubType { get; set; }
		public decimal Discount { get; set; }

		public byte? Cat_manufacturer {get; set;}
		public byte? Cat_color_palette {get; set;}
		public byte? Cat_appearance {get; set;}
		public byte? Cat_washable {get; set;}
		public byte? Cat_smell {get; set;}
		public byte? Cat_color {get; set;}
		public byte? Cat_room_type {get; set;}
		public byte? Cat_appointment {get; set;}
		public byte? Cat_type {get; set;}
		public byte? Cat_stencil_theme {get; set;}
		public byte? Cat_place_of_use {get; set;}
		public byte? Cat_created_for {get; set;}
		public byte? Cat_finish_guarantee {get; set;}
		public byte? Cat_effect {get; set;}
		public byte? Cat_volume {get; set;}
		public byte? Cat_duration_of_protection {get; set;}
		public byte? Cat_surface_of_application {get; set;}
		public byte? Cat_type_of_use {get; set;}
		public byte? Cat_brush_type {get; set;}
		public byte? Cat_width {get; set;}
		public byte? Cat_fiber_material {get; set;}
		public byte? Cat_structure {get; set;}
		public byte? Cat_resistant {get; set;}
		public byte? Cat_gluing_strength {get; set;}
		public byte? Cat_capture_time {get; set;}
		public byte? Cat_gluing_material {get; set;}
		public byte? Cat_frost_resistance {get; set;}
		public byte? Cat_heat_resistance {get; set;}
		public byte? Cat_color_after_drying {get; set;}
		public byte? Cat_external_material {get; set;}
		public byte? Cat_application_type {get; set;}
		public byte? Cat_paint_type {get; set;}

		public byte Cat_consumption { get; set; }
		public byte Cat_application_temperature { get; set; }

		public IFormFile Img1 { get; set; }
		public IFormFile Img2 { get; set; }
		public IFormFile Img3 { get; set; }
		//public List<Image> Images { get; set; }


	}
}
