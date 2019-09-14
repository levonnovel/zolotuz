using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Stroymat
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal DiscountedPrice { get; set; }
		public int Country { get; set; }
		public string CountryName { get; set; }
		public byte Manufacturer { get; set; }
		public int Discount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int Product_Type { get; set; }
		public string Product_Type_Name { get; set; }

		public int Type { get; set; }
		public string Type_Name { get; set; }

		public Image Image { get; set; }

		public List<Image> Images { get; set; }

	}
}
