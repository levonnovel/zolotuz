using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace zolotuz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MailController : Controller
    {

        public bool Index()
        {
			SmtpClient smtpClient = new SmtpClient("mail.zolotoyuzor.ru", 8889);

			smtpClient.Credentials = new System.Net.NetworkCredential("Artur2019", "Aa199814");
			smtpClient.UseDefaultCredentials = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.EnableSsl = true;
			MailMessage mail = new MailMessage();

			//Setting From , To and CC
			mail.From = new MailAddress("levonpetrosyan9@gmail.com", "MyWeb Site");
			mail.To.Add(new MailAddress("leomax2016@mail.ru"));
			//mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

			smtpClient.Send(mail);
			return true;
        }
    }
}