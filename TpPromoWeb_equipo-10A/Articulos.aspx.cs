using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Dominio;
using Negocio;

namespace TpPromoWeb_equipo_10A
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected List<Articulo> listaArticulos;
        public string voucher { get; set; }
        string Dni;
        int IdArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            voucher = Session["CodigoVoucher"] != null ? Session["CodigoVoucher"].ToString() : "";
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listar();
                Session["listaArticulos"] = listaArticulos;
                repArticulos.DataSource = listaArticulos;
                repArticulos.DataBind();


 
                ddlArticulos.DataSource = listaArticulos;
                ddlArticulos.DataTextField = "Nombre";
                ddlArticulos.DataValueField = "Id";
                ddlArticulos.DataBind();


            }
        }

        protected string ObtenerUrlImagen(object dataItem)
        {
            var articulo = (Articulo)dataItem;
            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                return articulo.Imagenes[0].ImagenUrl;
            else
                return "https://via.placeholder.com/200x150?text=Sin+Imagen";
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            IdArticulo = int.Parse(ddlArticulos.SelectedValue);
            Dni = txtDni.Text;
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                lblError.Text = "DNI no valido";
                lblError.Visible = true;
                return;
            }
            try
            {
                Session.Add("Dni", Dni);
                Session.Add("IdArticulo", IdArticulo);
                Response.Redirect("Registrarse.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
                lblError.Visible = true;

            }

        }


    }
}