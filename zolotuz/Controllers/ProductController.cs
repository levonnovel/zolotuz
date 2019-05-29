	using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using zolotuz.Models;
using zolotuz.Models.Filters;

namespace zolotuz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{

		// GET: Product
		[HttpGet]
		public string Index()
		{
			return "s";
			//var els = DataProvider.GetPaints();

			//return new JsonResult(els) { };
		}
		[HttpGet("{type}/{id}")]
		public JsonResult Item(string type, int id)
		{
			
			if (type == "kraski")
			{
				var el1 = DataProvider.GetPaint(id);

				return new JsonResult(el1.FirstOrDefault()) { };

			}
			else if (type == "stroymateryali")
			{
				var el2 = DataProvider.GetStroymateryali(id);

				return new JsonResult(el2.FirstOrDefault()) { };
			}


			return null;
		}

		[HttpPost("filter/stroymateryali")]
		public JsonResult GetStroymats(StroymatFilter filter)
		{
			var els = DataProvider.GetStroymats(filter);

			return new JsonResult(els) { };
		}

		[HttpPost("filter/kraski")]
		public JsonResult GetPaints(PaintFilter filter)
		{
			var els = DataProvider.GetPaints(filter);

			return new JsonResult(els) { };
		}

		[HttpGet("GetRandomItems")]
		public JsonResult GetRandomItems()
		{
			var list = DataProvider.GetRandomItems();

			return new JsonResult(list) { };
		}

		[HttpGet("GetDiscountedItems")]
		public JsonResult GetDiscountedItems()
		{
			var list = DataProvider.GetDiscountedItems();

			return new JsonResult(list) { };
		}

		[HttpGet("GetPopularItems")]
		public JsonResult GetPopularItems()
		{
			var list = DataProvider.GetPopularItems();

			return new JsonResult(list) { };
		}

		[HttpGet("GetCurrentProductTypeItems/{table}/{type}")]
		public JsonResult GetCurrentProductTypeItems(string table, string type)
		{
			var list = DataProvider.GetCurrentTypeItems(table, type);

			return new JsonResult(list) { };
		}

		[HttpGet("GetCurrentTypeItems/{table}")]
		public JsonResult GetCurrentTypeItems(string table)
		{
			var list = DataProvider.GetCurrentTypeItems(table);

			return new JsonResult(list) { };
		}

		[HttpPost("CreateOrder")]
		public bool CreateOrder(Order order)
		{
			bool isAdded = false;

			isAdded =  DataProvider.AddOrder(order);

			return isAdded;
		}

		[HttpGet("GetOrders")]
		public JsonResult GetOrders()
		{
			var orders = DataProvider.GetOrders();

			return new JsonResult(orders) { };
		}

		[HttpGet("img/{table}/{id}/{nmb}")]
		public ActionResult Img(string table, string id, string nmb)
		{
			Image img = new Image();
			//string name = Directory.GetFiles("imgs")[0];

			string path = Directory.GetCurrentDirectory() + string.Format(@"\imgs\{0}_{1}_{2}.jpg", table, id, nmb);
			byte[] bytes = System.IO.File.ReadAllBytes(path);

			return File(bytes, "image/jpeg");
		}

	}
}
