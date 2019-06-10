using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class KovkaDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Type { get; set; }
		public int Discount { get; set; }

		public List<Image> Images { get; set; }
	}
}
