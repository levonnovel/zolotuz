using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zolotuz.Models;

namespace zolotuz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController
	{
		[HttpPost("IsAdmin")]
		public JsonResult IsAdmin(Admin admin)
		{
			var isadmin = DataProvider.IsAdmin(admin.Login, admin.Password);

			return new JsonResult(isadmin) { };
		}
	}
}
