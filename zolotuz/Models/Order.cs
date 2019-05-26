using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Order
	{
		public string Name { get; set; }

		public string EMail { get; set; }

		public string Number { get; set; }

		public List<PurchasedItem> Items = new List<PurchasedItem>();
	}
}
