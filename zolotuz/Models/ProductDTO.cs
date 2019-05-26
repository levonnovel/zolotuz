﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class ProductDTO
	{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Description { get; set; }
			public decimal Price { get; set; }
			public byte Discount { get; set; }

			public int Product_Type { get; set; }
			public string Product_Type_Name { get; set; }

			public Image Image { get; set; }

		
	}
}