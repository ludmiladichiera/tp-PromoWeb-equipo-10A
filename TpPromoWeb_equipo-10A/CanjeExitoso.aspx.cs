using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TpPromoWeb_equipo_10A
{

    public partial class CanjeExitoso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombreCliente = Request.QueryString["nombre"];
                string mailCliente = Request.QueryString["mail"];

                if (!string.IsNullOrEmpty(nombreCliente))
                {
                    MensajeExito.Text = "¡Gracias por participar, " + nombreCliente + "! El registro ha sido exitoso";
                    lblMailEnviado.Text = "";
                    lblErrorMail.Text = "";
                    try //intento enviar mail
                    {
                        EmailService emailService = new EmailService();
                        emailService.armarCorreo(mailCliente, nombreCliente);
                        
                        emailService.enviarEmail();
                        lblMailEnviado.Text = "Correo enviado a: " + mailCliente + " [mailtrap.io]";
                        
                    }
                    catch (Exception ex)
                    {
                         lblErrorMail.Text = "Error al enviar el correo: \n\n " + ex.Message;
                       // throw ex;

                    }
                }
            }
        }
    }
}