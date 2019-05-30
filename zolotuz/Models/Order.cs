using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Order
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public DateTime? Date { get; set; }

		public List<PurchasedItem> Items = new List<PurchasedItem>();
	}
}
