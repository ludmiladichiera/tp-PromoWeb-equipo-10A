using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("fdd7ac65bff015", "0be0881a4f44dd");
            //server.Credentials = new NetworkCredential("grupo10.programacion3@gmail.com", "grupo10p3");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";

        }



        public void armarCorreo(string emailDestino, string asunto)
        {
            email = new MailMessage();
            email.From = new MailAddress("grupo10.programacion3@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<div style=\"max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); padding: 30px; text-align: center;\">\r\n    <h2 style=\"color: #4CAF50;\">🎉 ¡Voucher cargado exitosamente! 🎉</h2>\r\n    <p style=\"font-size: 16px;\">\r\n      Nos alegra informarte que tu voucher fue cargado con éxito.  \r\n      <br><br>\r\n      Si tenés alguna duda o consulta, no dudes en escribirnos.\r\n    </p>\r\n\r\n    <div style=\"margin: 30px 0;\">\r\n      <img src=\"https://viapais.com.ar/resizer/v2/MY4DMMJYGYZGIOBYGQZTMOJSME.jpg?quality=75&smart=true&auth=ca814c1442e434d166747ec139b658b70e1d8fa8faa59e64685b79e08e51f253&width=980&height=640\" alt=\"meme gracioso\" style=\"max-width: 100%; border-radius: 6px;\" />\r\n      <p style=\"font-size: 14px; color: #888;\">(Un meme para celebrarlo 😄)</p>\r\n    </div>\r\n\r\n    <p style=\"font-size: 16px; margin-top: 30px;\">\r\n      ¡Saludos del equipo10 de Prog 3! 👨‍💻👩‍💻\r\n    </p>\r\n  </div>";
            

        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}