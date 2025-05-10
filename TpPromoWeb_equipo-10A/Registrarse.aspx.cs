using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TpPromoWeb_equipo_10A
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void textDni_TextChanged(object sender, EventArgs e)
        {
            string dni = textDni.Text;
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            cliente = clienteNegocio.ObtenerDniCliente(dni);

            if (cliente != null)
            {
                textDni.Text = cliente.Documento.ToString();
                textNombre.Text = cliente.Nombre.ToString();
                textApellido.Text = cliente.Apellido.ToString();
                textEmail.Text = cliente.Email.ToString();
                textDireccion.Text = cliente.Direccion.ToString();
                textCiudad.Text = cliente.Ciudad.ToString();
                textCP.Text = cliente.CP.ToString();
            }
        }

        protected void btnParticipar_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!validarCajasTexto())
                {
                    return;
                }

                Cliente cliente = new Cliente
                {
                    Documento = textDni.Text,
                    Nombre = textNombre.Text,
                    Apellido = textApellido.Text,
                    Email = textEmail.Text,
                    Direccion = textDireccion.Text,
                    Ciudad = textCiudad.Text,
                    CP = int.Parse(textCP.Text)
                };

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                clienteNegocio.AltaCliente(cliente);

                string desde = Request.QueryString["desde"];
                if (desde != "promo")
                {
                    Cliente clienteId = clienteNegocio.ObtenerDniCliente(cliente.Documento);
                    int idCliente = clienteId.Id;

                    if (Session["idVoucher"] != null && Session["idArticulo"] != null)
                    {
                        string codigoVoucher = Session["idVoucher"].ToString();
                        int idArticulo = int.Parse(Session["idArticulo"].ToString());
                        int yyyy = DateTime.Now.Year;
                        int mm = DateTime.Now.Month;
                        int dd = DateTime.Now.Day;
                        DateTime fechaCanje = new DateTime(yyyy, mm, dd);

                        VoucherNegocio voucherNegocio = new VoucherNegocio();
                        voucherNegocio.guardarVoucher(codigoVoucher, idCliente, fechaCanje, idArticulo);
                    }
                }

                Response.Redirect("CanjeExitoso.aspx?nombre=" + Server.UrlEncode(cliente.Nombre), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///validaciones de cajas de texto 
        bool esNumero(string texto)
        {
            long numero;
            return long.TryParse(texto, out numero);
        }
        public bool validarCajasTexto()
        {

            bool aux = true;

            // VALIDA DNI:

            if (string.IsNullOrEmpty(textDni.Text))
            {

                lblErrorDni.Text = "El campo DNI no puede estar vacío.\n";
                lblErrorDni.Visible = true;
                aux = false;
            }
            else if (!esNumero(textDni.Text))
            {
                lblErrorDni.Text = "DNI debe contener solo números.\n";
                lblErrorDni.Visible = true;
                aux = false;
            }
            else { lblErrorDni.Visible = false; }

            // VALIDA VALIDA CORREO: 

            if (string.IsNullOrWhiteSpace(textEmail.Text))
            {
                lblErrorEmail.Text = "Debe colocar un Email. \n";
                lblErrorEmail.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorEmail.Visible = false;
            }

            // VALIDA DIRECCIÓN;

            if (string.IsNullOrEmpty(textDireccion.Text))
            {
                lblErrorDireccion.Text = "Debe colocar una dirección. \n";
                lblErrorDireccion.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorDireccion.Visible = false;
            }

            // VALIDA CIUDAD;

            if (string.IsNullOrEmpty(textCiudad.Text))
            {
                lblErrorCiudad.Text = "Debe colocar nombre de la ciudad. \n";
                lblErrorCiudad.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorCiudad.Visible = false;
            }

            // VALIDA CP;

            if (string.IsNullOrEmpty(textCP.Text))
            {
                lblErrorCp.Text = "El campo Código Postal no puede estar vacío.";
                lblErrorCp.Visible = true;
                aux = false;
            }
            else if (!esNumero(textCP.Text))  // Verifica que contenga solo números
            {
                lblErrorCp.Text = "El Código Postal debe contener solo números.";
                lblErrorCp.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorCp.Visible = false;
            }

            // VALIDA APELLIDO;

            if (string.IsNullOrEmpty(textApellido.Text))
            {
                lblErrorApellido.Text = "Debe colocar un apellido.  \n";
                lblErrorApellido.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorApellido.Visible = false;
            }

            // VALIDA NOMBRE; 

            if (string.IsNullOrEmpty(textNombre.Text))
            {
                lblErrorNombre.Text = "Debe colocar un nombre.  \n";
                lblErrorNombre.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorNombre.Visible = false;
            }

            // VALIDA CHECKBOX; 

            if (!chkbAcepto.Checked)
            {
                lblMensajeError.Text = "Debe aceptar los términos y condiciones.";
                lblMensajeError.Visible = true;
                aux = false;
            }
            else
            {
                lblMensajeError.Visible = false;
            }

            return aux;

        }
    }
}