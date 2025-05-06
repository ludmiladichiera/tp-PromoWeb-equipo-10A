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
    public partial class Articulos : System.Web.UI.Page
    {
        protected List<Articulo> listaArticulos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listar();
                Session["listaArticulos"] = listaArticulos;
                repArticulos.DataSource = listaArticulos;
                repArticulos.DataBind();
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
    }
}

