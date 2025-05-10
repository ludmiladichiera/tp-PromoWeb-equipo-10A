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
                // Inicialización si es necesario, no hacemos nada aquí por ahora.
            }
        }

        // Este método se ejecuta cuando el valor del campo DNI cambia
        protected void textDni_TextChanged(object sender, EventArgs e)
        {
            string dni = textDni.Text;
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            // Verificamos si el cliente ya existe por el DNI
            cliente = clienteNegocio.ObtenerDniCliente(dni);

            if (cliente != null)
            {
                // Si el cliente ya existe, precargamos los datos
                textDni.Text = cliente.Documento.ToString();
                textNombre.Text = cliente.Nombre.ToString();
                textApellido.Text = cliente.Apellido.ToString();
                textEmail.Text = cliente.Email.ToString();
                textDireccion.Text = cliente.Direccion.ToString();
                textCiudad.Text = cliente.Ciudad.ToString();
                textCP.Text = cliente.CP.ToString();
            }
        }

        // Este método se ejecuta cuando se hace clic en el botón "Participar"
        protected void btnParticipar_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!validarCajasTexto())
                {
                    return;
                }

                string dni = textDni.Text;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = clienteNegocio.ObtenerDniCliente(dni);

                if (cliente == null) // Si el cliente no existe, creamos uno nuevo
                {
                    // Crear nuevo cliente con los datos ingresados
                    cliente = new Cliente
                    {
                        Documento = textDni.Text,
                        Nombre = textNombre.Text,
                        Apellido = textApellido.Text,
                        Email = textEmail.Text,
                        Direccion = textDireccion.Text,
                        Ciudad = textCiudad.Text,
                        CP = int.Parse(textCP.Text)
                    };

                    // Guardar el nuevo cliente en la base de datos
                    clienteNegocio.AltaCliente(cliente);
                }

                // Obtener el ID del cliente (nuevo o existente)
                int idCliente = cliente.Id;

                // Validamos que el cliente haya aceptado los términos y condiciones
                if (Session["idVoucher"] != null && Session["idArticulo"] != null)
                {
                    string codigoVoucher = Session["idVoucher"].ToString();
                    int idArticulo = int.Parse(Session["idArticulo"].ToString());
                    DateTime fechaCanje = DateTime.Now;

                    // Crear el voucher y asociarlo al cliente (nuevo o existente)
                    VoucherNegocio voucherNegocio = new VoucherNegocio();
                    voucherNegocio.guardarVoucher(codigoVoucher, idCliente, fechaCanje, idArticulo);
                }

                // Redirigir a la página de "Canje Exitoso"
                Response.Redirect("CanjeExitoso.aspx?nombre=" + Server.UrlEncode(cliente.Nombre), false);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
        }

        // Función para validar si un texto es un número
        bool esNumero(string texto)
        {
            long numero;
            return long.TryParse(texto, out numero);
        }

        // Validaciones de los campos del formulario
        public bool validarCajasTexto()
        {
            bool aux = true;

            // Validación del campo DNI
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
            else
            {
                lblErrorDni.Visible = false;
            }

            // Validación del campo Email
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

            // Validación de la Dirección
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

            // Validación de la Ciudad
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

            // Validación del Código Postal
            if (string.IsNullOrEmpty(textCP.Text))
            {
                lblErrorCp.Text = "El campo Código Postal no puede estar vacío.";
                lblErrorCp.Visible = true;
                aux = false;
            }
            else if (!esNumero(textCP.Text)) // Verifica que contenga solo números
            {
                lblErrorCp.Text = "El Código Postal debe contener solo números.";
                lblErrorCp.Visible = true;
                aux = false;
            }
            else
            {
                lblErrorCp.Visible = false;
            }

            // Validación del campo Apellido
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

            // Validación del campo Nombre
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

            // Validación de aceptación de términos y condiciones
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