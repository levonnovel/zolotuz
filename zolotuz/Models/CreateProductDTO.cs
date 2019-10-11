using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class CreateProductDTO
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Group { get; set; }
		public decimal Type { get; set; }
		public decimal SubType { get; set; }
        public decimal Discount { get; set; }



        public byte? manufacturer;
        public byte? color_palette;
        public byte? appearance;
        public byte? washable;
        public byte? smell;
        public byte? color;
        public byte? room_type;
        public byte? appointment;
        public byte? type;
        public byte? stencil_theme;
        public byte? place_of_use;
        public byte? created_for;
        public byte? finish_guarantee;
        public byte? effect;
        public byte? volume;
        public byte? duration_of_protection;
        public byte? surface_of_application;
        public byte? type_of_use;
        public byte? brush_type;
        public byte? width;
        public byte? fiber_material;
        public byte? structure;
        public byte? resistant;
        public byte? gluing_strength;
        public byte? capture_time;
        public byte? gluing_material;
        public byte? frost_resistance;
        public byte? heat_resistance;
        public byte? color_after_drying;
        public byte? external_material;
        public byte? application_type;


        public IFormFile Img1 { get; set; }
		public IFormFile Img2 { get; set; }
		public IFormFile Img3 { get; set; }
        //public List<Image> Images { get; set; }


	}
}
