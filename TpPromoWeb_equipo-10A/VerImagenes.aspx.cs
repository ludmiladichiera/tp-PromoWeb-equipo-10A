
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
    public partial class VerImagenes : System.Web.UI.Page
    {
        public int idArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    idArticulo = int.Parse(Request.QueryString["id"]);
                    Session["IdArticulo"] = idArticulo;
                    cargarImagenes();
                }
                else
                {
                    Response.Redirect("Articulos.aspx");
                }
            }
        }
        protected void btnVolver_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Articulos.aspx");
        }
        private void cargarImagenes()
        {
            int id = (int)Session["IdArticulo"];
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> lista = imagenNegocio.listar(id);
            rptImagenes.DataSource = lista;
            rptImagenes.DataBind();
        }


    }
}

