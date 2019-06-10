using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class PaintDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Application_Area { get; set; }
		public decimal Price { get; set; }
		public int Color { get; set; }
		public int Volume { get; set; }
		public int Country { get; set; }
		public int Manufacturer { get; set; }
		public int Type { get; set; }
		public int Discount { get; set; }

		public List<Image> Images { get; set; }

	}
}
