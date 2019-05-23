using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models.Filters
{
	public class PaintFilter
	{
		public int ID { get; set; }

		public List<byte> Colors { get; set; }

		public List<byte> Volumes { get; set; }

		public List<byte> Countries { get; set; }

		public List<byte> Types { get; set; }

		public decimal? MinPrice { get; set; }

		public decimal? MaxPrice { get; set; }
	}
}
