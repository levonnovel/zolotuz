using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            int id = 0;
            bool isAdded = false;
            try
            {

                if (DataProvider.AddOrder(order, out id))
                {
                    MailController.Send(order.Name, order.Email, order.Items);
                    isAdded = true;
                }
            }
            catch (Exception ex)
            {
                DataProvider.DeleteOrder(id);
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

        [HttpGet("img/{group}/{id}/{nmb}")]
        public ActionResult Img(int group, int id, int nmb)
        {
            zolotuz.Models.Image img = new zolotuz.Models.Image();
            //string name = Directory.GetFiles("imgs")[0];

            string path = Directory.GetCurrentDirectory() + string.Format(@"\imgs\{0}\{1}\{2}.jpg", group, id, nmb);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "image/jpeg");
        }

        [HttpGet("DeleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {
            DataProvider.DeleteProduct(id);

            //string path = @"imgs\" + dt.Table + @"\" + dt.Id;
            //
            //Directory.Delete(path, true);

            return true;
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



                using (var ms = new MemoryStream())
                {
                    paint.Img1.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 10 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(200, 50);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\11.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }




                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    paint.Img1.CopyTo(fileStream);
                //}
            }
            if (paint.Img2?.Length > 0)
            {


                using (var ms = new MemoryStream())
                {
                    paint.Img1.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 50 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(10, 10);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\2.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }


                //var filePath = path + @"\2.jpg";
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    paint.Img2.CopyTo(fileStream);
                //}
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
            catch (Exception ex)
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
            decimal maxPrice;
            var pageFilters = DataProvider.GetProducts(filter, out maxPrice);
            object o = new { pageFilters, maxPrice };
            return new JsonResult(o) { };
        }

        [HttpGet("GetProduct/{id}")]
        public JsonResult GetProduct(int id)
        {
            var product = DataProvider.GetProduct(id);

            return new JsonResult(product) { };
        }

        [HttpGet("GetCurrentGroupItems/{group}")]
        public JsonResult GetCurrentProductTypeItems(int group)
        {
            var list = DataProvider.GetCurrentGroupItems(group);

            return new JsonResult(list) { };
        }


        [HttpGet("GetProductCategories/{id}")]
        public JsonResult GetProductCategories(int id)
        {
            var product = DataProvider.GetProductCategories(id);

            return new JsonResult(product) { };
        }

        [HttpPost("CreateProduct")]
        public bool CreateProduct([FromForm] CreateProductDTO str)
        {

            bool isAdded = false;

            isAdded = DataProvider.AddProduct(str, out var id);
            string path = @"imgs\" + str.Group + @"\" + id;
            Directory.CreateDirectory(path);
            if (str.Img1?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    str.Img1.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 75 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(400, 0);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .BackgroundColor(Color.White)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\1.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            if (str.Img2?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    str.Img2.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 75 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(400, 0);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .BackgroundColor(Color.White)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\2.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            if (str.Img3?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    str.Img3.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 75 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(400, 0);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .BackgroundColor(Color.White)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\3.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }

            return isAdded;
        }


        [HttpPost("EditProduct")]
        public bool EditProduct(CreateProductDTO product)
        {
            bool isAdded = false;

            isAdded = DataProvider.EditProduct(product);

            string path = @"imgs\" + product.Group + @"\" + product.Id;
            Directory.Delete(path, true);
            Directory.CreateDirectory(path);
            if (product.Img1?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    product.Img1.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 75 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(400, 0);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .BackgroundColor(Color.White)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\1.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            if (product.Img2?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    product.Img2.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 75 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(400, 0);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .BackgroundColor(Color.White)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\2.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            if (product.Img3?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    product.Img3.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    ISupportedImageFormat format = new JpegFormat { Quality = 75 };
                    using (MemoryStream inStream = new MemoryStream(fileBytes))
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            var maxSize = new Size(400, 0);
                            var r = new ResizeLayer(maxSize);
                            r.MaxSize = maxSize;
                            imageFactory.Load(inStream)
                                .BackgroundColor(Color.White)
                                .Resize(r)
                                 .Format(format)
                                .Save(outStream);
                        }

                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(outStream))
                        {
                            var filePath = path + @"\3.jpg";
                            image.Save(filePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }

            return isAdded;
        }


        [HttpPost("AddFilterValue")]
        public bool AddFilterValue(FilterDTO f)
        {
            bool isAdded = false;

            isAdded = DataProvider.AddFilterValue(f);

            return isAdded;
        }

        [HttpPost("DeleteFilterValue")]
        public bool DeleteFilterValue(FilterDTO f)
        {
            bool isAdded = false;

            isAdded = DataProvider.DeleteFilterValue(f);

            return isAdded;
        }

    }
}
