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

		[HttpPost("filter/kovki")]
		public JsonResult GetKovka(KovkaFilter filter)
		{
			var els = DataProvider.GetKovki(filter);

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
            try
            {
                MailController.Send(order.Name, order.Email, order.Items);
                if (DataProvider.AddOrder(order))
                {
                    isAdded = true;
                }
            }
            catch(Exception)
            {
                isAdded = false;
            }

           // isAdded = DataProvider.AddOrder(order);

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

			string path = Directory.GetCurrentDirectory() + string.Format(@"\imgs\{0}\{1}\{2}.jpg", table, id, nmb);
			byte[] bytes = System.IO.File.ReadAllBytes(path);

			return File(bytes, "image/jpeg");
		}


		[HttpPost("DeleteProduct")]
		public JsonResult DeleteProduct(DeleteProductDTO dt)
		{
			var orders = DataProvider.DeleteProduct(dt.Table, Convert.ToInt32(dt.Id));

			string path = @"imgs\" + dt.Table + @"\" + dt.Id;

			Directory.Delete(path, true);

			return new JsonResult(true) { };
		}


		[HttpGet("asd")]
		public string asd()
		{

			return "asd";
		}

		[HttpPost("CreateProduct/kraski")]
		public bool CreateKraska([FromForm] PaintDTO paint)
		{
			bool isAdded = false;

			isAdded = DataProvider.AddPaint(paint, out var id);


			string path = @"imgs\kraski\" + id;

			Directory.CreateDirectory(path);
			if (paint.Img1?.Length > 0)
			{
				var filePath = path + @"\1.jpg";
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					paint.Img1.CopyTo(fileStream);
				}
			}
			if (paint.Img2?.Length > 0)
			{
				var filePath = path + @"\2.jpg";
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					paint.Img2.CopyTo(fileStream);
				}
			}
			if (paint.Img3?.Length > 0)
			{
				var filePath = path + @"\3.jpg";
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					paint.Img3.CopyTo(fileStream);
				}
			}

			return isAdded;
		}

		[HttpPost("EditProduct/kraski")]
		public bool EditKraska(PaintDTO paint)
		{
			bool isAdded = false;

			isAdded = DataProvider.EditPaint(paint);

			return isAdded;
		}

		[HttpPost("CreateProduct/stroymateryali")]
		public string CreateStroymat([FromForm] StroymatDTO str)
		{

		
			bool isAdded = false;

			
			isAdded = DataProvider.AddStroymat(str, out var id);
			try
			{
				string path = @"imgs\stroymateryali\" + id;

				Directory.CreateDirectory(path);
				if (str.Img1?.Length > 0)
				{
					var filePath = path + @"\1.jpg";
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						str.Img1.CopyTo(fileStream);
					}
				}
				if (str.Img2?.Length > 0)
				{
					var filePath = path + @"\2.jpg";
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						str.Img2.CopyTo(fileStream);
					}
				}
				if (str.Img3?.Length > 0)
				{
					var filePath = path + @"\3.jpg";
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						str.Img3.CopyTo(fileStream);
					}
				}
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
			
			return id.ToString();
		}

		[HttpPost("EditProduct/stroymateryali")]
		public bool EditStroymat(StroymatDTO str)
		{
			bool isAdded = false;

			isAdded = DataProvider.EditStroymat(str);

			return isAdded;
		}

		[HttpPost("CreateProduct/kovki")]
		public bool CreateКovka([FromForm] KovkaDTO str)
		{
			bool isAdded = false;

			isAdded = DataProvider.AddKovka(str, out var id);
			string path = @"imgs\kovka\" + id;
			
			Directory.CreateDirectory(path);
			if (str.Img1?.Length > 0)
			{
				var filePath = path + @"\1.jpg";
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					str.Img1.CopyTo(fileStream);
				}
			}
			if (str.Img2?.Length > 0)
			{
				var filePath = path + @"\2.jpg";
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					str.Img2.CopyTo(fileStream);
				}
			}
			if (str.Img3?.Length > 0)
			{
				var filePath = path + @"\3.jpg";
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					str.Img3.CopyTo(fileStream);
				}
			}
			return isAdded;
		}

		[HttpPost("EditProduct/kovki")]
		public bool EditKovka(KovkaDTO str)
		{
			bool isAdded = false;

			isAdded = DataProvider.EditKovka(str);

			return isAdded;
		}

        [HttpGet("GetHeaders")]
        public JsonResult GetHeaders()
        {
            var headers = DataProvider.GetHeaders();

            return new JsonResult(headers) { };
        }

        [HttpGet("GetPageFiltersValues")]
        public JsonResult GetPageFiltersValues()
        {
            var pageFilters = DataProvider.GetPageFiltersValues();

            return new JsonResult(pageFilters) { };
        }

        [HttpGet("GetPageFilters")]
        public JsonResult GetPageFilters()
        {
            var pageFilters = DataProvider.GetPageFilters();

            return new JsonResult(pageFilters) { };
        }

        [HttpPost("GetProducts")]
        public JsonResult GetProducts(ProductFilter filter)
        {
            var pageFilters = DataProvider.GetProducts(filter);

            return new JsonResult(pageFilters) { };
        }

		[HttpGet("GetProduct/{id}")]
		public JsonResult GetProduct(int id)
		{
			var pageFilters = DataProvider.GetProduct(id);

			return new JsonResult(pageFilters) { };
		}

	}
}
