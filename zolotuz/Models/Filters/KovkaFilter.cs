using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models.Filters
{
	public class KovkaFilter
	{
			public int ID { get; set; }

			public List<byte> Kovka_type { get; set; }

			public decimal? MinPrice { get; set; }

			public decimal? MaxPrice { get; set; }

			public int? Start { get; set; }

			public int? End { get; set; }
	}
}
