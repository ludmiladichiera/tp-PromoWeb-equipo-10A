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
    public partial class PromoVoucher : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsiguiente_Click(object sender, EventArgs e)

        {
            Voucher a = new Voucher();
            a.Codigo = txtvoucher.Text; //obtengo el dato del textbox


            string codigoVoucher = txtvoucher.Text;

            // Acá simulas traer el voucher desde la base de datos por código
            // En un caso real, tendrías un método tipo: Voucher ObtenerPorCodigo(string codigo)
            AccesoDatos accesoDatos = new AccesoDatos();

            // Verificar si el código de voucher existe
            bool existeVoucher = accesoDatos.ExisteCodigoVoucher(codigoVoucher);

            if (existeVoucher)
            {
                Session["idVoucher"] = codigoVoucher;
                // Si el voucher existe, redirigir a la página de selección de premio
                Response.Redirect("SeleccionarPremio.aspx?desde=promo", false);
            }
            else
            {
                // Si el voucher no existe, mostrar un mensaje de error
                lblError.Text = "El código del voucher no es válido o ya ha sido utilizado.";
                lblError.Visible = true;
            }



            //try
            //{
            //    // Simulamos datos que podrían venir del usuario logueado o contexto
            //    int idCliente = 1;
            //    DateTime fechaCanje = DateTime.Now;
            //    int idArticulo = 123;

            //    negocio.ModificarVoucher(voucher, idCliente, fechaCanje, idArticulo);

            //    // Mostrás algún mensaje de éxito
            //    Response.Write("<script>alert('✅ Voucher aplicado correctamente.');</script>");
            //}
            //catch (Exception ex)
            //{
            //    Response.Write($"<script>alert('❌ Error: {ex.Message}');</script>");
            //}
        }
    }
}