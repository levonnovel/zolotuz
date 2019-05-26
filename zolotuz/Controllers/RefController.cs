using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zolotuz.Models;

namespace zolotuz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RefController : Controller
    {
		public Dictionary<string, string> GetRefNames()
        {
			Dictionary<string, string> refs = DataProvider.GetRefNames();

			return refs;
        }

		[HttpGet("GetAll")]
		public JsonResult GetAll()
		{
			Dictionary<string, string> refs = GetRefNames();
			Dictionary<string, Dictionary<int, string>> rr = new Dictionary<string, Dictionary<int, string>>();

			foreach(var el in refs)
			{
				var refer = DataProvider.GetRefs(el.Key, el.Value);
				rr.Add(refer.Keys.First(), refer.Values.First());
			}

			return new JsonResult(rr) { };
		}
	}
}