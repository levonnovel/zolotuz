using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zolotuz.Models;

namespace zolotuz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MailController : Controller
	{

		public static void Send(string name, string email, List<PurchasedItem> items)
		{
			//SmtpClient smtpClient = new SmtpClient("mail.zolotoyuzor.ru", 8889);
			//
			//smtpClient.Credentials = new System.Net.NetworkCredential("Artur2019", "Aa199814");
			//smtpClient.UseDefaultCredentials = true;
			//smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			//smtpClient.EnableSsl = true;
			//MailMessage mail = new MailMessage();
			//
			////Setting From , To and CC
			//mail.From = new MailAddress("levonpetrosyan9@gmail.com", "MyWeb Site");
			//mail.To.Add(new MailAddress("leomax2016@mail.ru"));
			////mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
			//
			//smtpClient.Send(mail);
			//return true;


			MailMessage mail = new MailMessage();

			//set the addresses 
			mail.From = new MailAddress("Artur@zolotoyuzor.ru"); //IMPORTANT: This must be same as your smtp authentication addres

			mail.To.Add("leomax2016@mail.ru");
			mail.To.Add("dadamyan2012@mail.ru");
			mail.To.Add(email);
			mail.IsBodyHtml = true;
			StringBuilder str = new StringBuilder();

			str.Append(@"    
    <h2 style=""font - size: 18px"">Здравствуйте " + name + @"!</h2>

    <p> Спасибо за ваш заказ у компании
      <a href = ""https://www.zolotoyuzor.ru"" target = ""_blank"" >
        «Интернет - магазин ""Золотой узор""».
      </a >
    </p >

    <p > Вы заказали:</p >

    <center >
        <table width = ""100 %"" border = ""0"" cellpadding = ""10"" cellspacing = ""0"" >

            <thead bgColor = ""#ffc700"" >
                <tr  bgColor=""#ffc700"">
                    <td > Название </td >
                    <td > Количество </td >
                    <td > Цена за единицу </td >
                </tr >
            </thead >

            <tbody >
                            ");
            int i = 0;
			foreach (var it in items)
			{
                i++;
                if(i % 2 == 0)
                {
                    str.Append(@"<tr bgColor=""#eee""> ");

                }
                else
                {
                    str.Append(@"<tr> ");
                }
                str.Append(@"<td>");
				str.Append(it.Name);
				str.Append("</td>");

				str.Append(@"<td>");
				str.Append(it.Count);
				str.Append("</td>");

				str.Append(@"<td>");
				str.Append(it.Price);
				str.Append("</td>");
				str.Append("</tr>");
			}

            str.Append(@"
            </tbody>
        </table>
    </center>
");
			mail.Subject = "Спасибо за ваш заказ у <<Интернет-магазин \"Золотой Узор\">>!";
			mail.Body = str.ToString();
			//send the message 
			SmtpClient smtp = new SmtpClient("mail.zolotoyuzor.ru");
			//IMPORANT:  Your smtp login email MUST be same as your FROM address. 
			NetworkCredential Credentials = new NetworkCredential("Artur@zolotoyuzor.ru", "Aa199814-");
			smtp.Credentials = Credentials;
			smtp.Send(mail);


			// MailMessage mail = new MailMessage();

			//set the addresses 
			//mail.From = new MailAddress("seller@zolotoyuzor.ru"); //IMPORTANT: This must be same as your smtp authentication addres
			//mail.To.Add("leomax2016@mail.ru");
			//mail.To.Add("dadamyan2012@mail.ru");
			//mail.To.Add(email);
			//
			////set the content dasdasdasdas
			//mail.Subject = "Pokupka";
			//mail.Body = "Dear " + name + " ваш заказ оформлен";
			////send the message 
			//SmtpClient smtp = new SmtpClient("smtp.hostinger.ru");
			////IMPORANT:  Your smtp login email MUST be same as your FROM address. 
			//NetworkCredential Credentials = new NetworkCredential("seller@zolotoyuzor.ru", "Aa199814-");
			//smtp.Credentials = Credentials;
			//smtp.Send(mail);
		}
	}
}