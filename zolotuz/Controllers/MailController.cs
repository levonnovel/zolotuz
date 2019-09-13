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
            str.Append("Здравствуйте " + name + "!<br />");

            str.Append(@"    
    <h2 style="" font-family: aial, sans-serif; font-size: 18px;"">Здравствуйте Armen Martirosyan!</h2>

    <p style="" font-family: aial, sans-serif; "">Спасибо за ваш заказ у компании
      <a href=""https://www.zolotoyuzor.ru"" target = ""_blank""  style="" font-family: aial, sans-serif; "">
        «Интернет - магазин Золотой узор ».
      </a>
    </p>

    <p style="" font-family: aial, sans-serif; ""> Вы заказали:</p>


    <div class=""container"" style="" font-family: aial, sans-serif; width: 100%; max-width: 900px; margin: 0 auto; width: 100%; border-collapse: collapse;"">
        <table style="" font-family: aial, sans-serif; "">
            <thead style="" background: linear-gradient(90deg, #ffc700, #ff862b); color: #fff;"">
                <tr>
                    <th stlye = ""text - align: justify; min - width: 150px; padding: 10px 15px; "">Название</th>
                    <th stlye = ""text - align: justify; min - width: 150px; padding: 10px 15px; "">Количество</th>
                    <th stlye = ""text - align: justify; min - width: 150px; padding: 10px 15px; "">Цена за единицу</th>
                </tr>
            </thead>
            <tbody>
               
			   ");

            int i = 0;
            foreach (var it in items)
            {
                if(i % 2 == 0)
                {
                    str.Append(@"<tr style=""background: #ddd;"">");
                }
                else
                {
                    str.Append("<tr>");
                }
                str.Append(@"<td stlye = ""text - align: justify; min - width: 150px; padding: 10px 15px; "">");
                str.Append(it.Name);
                str.Append("</td>");

                str.Append(@"<td stlye = ""text - align: justify; min - width: 150px; padding: 10px 15px; "">");
                str.Append(it.Count);
                str.Append("</td>");

                str.Append(@"<td stlye = ""text - align: justify; min - width: 150px; padding: 10px 15px; "">");
                str.Append(it.Price);
                str.Append("</td>");
                str.Append("</tr>");
            }
   //         str.Append(@"</tbody></table></div ><p> A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.A much longer piece of content for demo purposes.</p>>
   //     * {
   //         font-family: aial, sans-serif;
   //     }
        
   //     .container {
   //         width: 100%;
   //         max-width: 900px;
   //         margin: 0 auto;
   //     }

   //     h2 {
   //         font-size: 18px;
   //     }
        
   //     table {
   //         width: 100%;
   //         border-collapse: collapse;
   //     }
        
   //     thead {
   //         background: linear-gradient(90deg, #ffc700, #ff862b);
   //         color: #fff;
   //     }
        
   //     tr:nth-of-type(even) {
   //         background: #ddd;
   //     }
        
   //     th, td {
   //         text-align: justify;
   //         min-width: 150px;
   //         padding: 10px 15px;
   //     }

   //     @media screen and (max-width: 560px) {
   //         th, td {
   //             width: 100px;
   //             min-width: 100px;
   //             padding: 10px 5px;
   //         }
   //         td:not(:first-child) {
   //             text-align: center;
   //         }
   //     }

   //");
            //set the content dasdasdasdas
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