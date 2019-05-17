using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zolotuz.Models;
using zolotuz.Models.Filters;

namespace zolotuz.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : Controller
	{

		[HttpGet("s")]
		public string Sss()
		{

			return "SSS";
		}

		// GET: Product
		[HttpGet]
		public JsonResult Index()
		{
			var els = Paint.GetAllPaints();

			return new JsonResult(els) { };
		}
		[HttpGet("Item/{id}")]
		public JsonResult Item(int id)
		{
			var el = Paint.GellPaintByID(id);

			return new JsonResult(el) { };
		}

		[HttpGet("GetPaints/{id}")]
		public JsonResult GetPaints(PaintFilter filter)
		{
			return new JsonResult(new string[] { "dsa"}) { };
		}
	}
}
