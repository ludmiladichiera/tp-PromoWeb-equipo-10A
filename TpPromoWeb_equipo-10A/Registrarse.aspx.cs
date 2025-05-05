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
    public partial class Registrarse : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string email = txtEmail.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            int cp;

            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(ciudad) ||
                !int.TryParse(txtCP.Text.Trim(), out cp))
            {
                lblError.Text = "Por favor, complete todos los campos correctamente.";
                lblError.Visible = true;
                return;
            }

            if (!IsValidEmail(email))
            {
                lblError.Text = "Por favor, ingrese un correo electrónico válido.";
                lblError.Visible = true;
                return;
            }

         
            Cliente cliente = new Cliente
            {
                Documento = documento,
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Direccion = direccion,
                Ciudad = ciudad,
                CP = cp
            };

            
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                bool registrado = negocio.RegistrarClienteSiNoExiste(cliente);

                if (!registrado)
                {
                    lblError.Text = "El cliente ya está registrado.";
                    lblError.Visible = true;
                }
                else
                {

                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "¡Registro exitoso!";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
    namespace TpPromoWeb_equipo_10A
    {
        public partial class About : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }
        }
    }
}