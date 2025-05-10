using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpPromoWeb_equipo_10A
{
    
public partial class CanjeExitoso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string nombreCliente = Request.QueryString["nombre"];
            if (!string.IsNullOrEmpty(nombreCliente))
            {
                MensajeExito.Text = "¡Gracias por participar, " + nombreCliente + "! el registro ha sido exitoso";
            }
        }
    }
}
}