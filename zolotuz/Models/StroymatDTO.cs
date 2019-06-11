﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class StroymatDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int? Country { get; set; }
		public int? Manufacturer { get; set; }
		public int? Type { get; set; }
		public int? Discount { get; set; }
		public IFormFile Img1 { get; set; }
		public IFormFile Img2 { get; set; }
		public IFormFile Img3 { get; set; }
		//public List<Image> Images { get; set; }
	}
}
