using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TpPromoWeb_equipo_10A
{
    public partial class PromoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCanjear_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtCodigoVoucher.Text.Trim();

            //si el campo esta vacio:
            if (string.IsNullOrEmpty(codigoVoucher))
            {
                lblError.Text = "Por favor, ingresa un código de voucher.";
                lblError.Visible = true;
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            bool existeVoucher = voucherNegocio.ExisteCodigoVoucher(codigoVoucher);

            if (existeVoucher)
            {
                Session["idVoucher"] = codigoVoucher;
                Response.Redirect("Articulos.aspx?desde=promo", false);
            }
            else
            {
                Response.Redirect("voucherError.aspx", false);
            }
        }
    }
}