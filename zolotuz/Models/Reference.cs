using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Reference
	{
		public string Name { get; set; }
		public Dictionary<int, string> Values { get; set; } = new Dictionary<int, string>();
	}
}
