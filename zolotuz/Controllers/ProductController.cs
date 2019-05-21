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
			Paint el = new Paint();
			if(type == "kraski")
			{
				el = DataProvider.GetPaintByID(id);
			}

			return new JsonResult(el) { };
		}

		[HttpGet("GetPaints")]
		public JsonResult GetPaints(PaintFilter filter)
		{
			var els = DataProvider.GetPaints(filter);

			return new JsonResult(els) { };
		}

	}
}
