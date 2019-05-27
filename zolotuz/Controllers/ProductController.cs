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
			List<Paint> el = new List<Paint>();
			if (type == "kraski")
			{
				el = DataProvider.GetPaint(id);
			}

			return new JsonResult(el.FirstOrDefault()) { };
		}

		[HttpPost("GetPaints")]
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
		public string CreateOrder(Order order)
		{
			bool isAdded = false; isAdded =  DataProvider.AddOrder(order);

			return isAdded;
		}
	}
}
