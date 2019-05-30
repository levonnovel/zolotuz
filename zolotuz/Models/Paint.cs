using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
	public class Paint
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Composition { get; set; }
		public string Application_Area { get; set; }
		public decimal Price { get; set; }
		public string Color { get; set; }
		public string Volume { get; set; }
		public string Country { get; set; }
		public int Product_Type { get; set; }
		public string Product_Type_Name { get; set; }
		
		public int Type { get; set; }
		public string Type_Name { get; set; }
		public Image Image { get; set; }

		public List<Image> Images{ get; set; }



	}
}
