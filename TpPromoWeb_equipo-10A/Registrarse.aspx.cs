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
    public partial class Registrarse : Page
    {
        string dni;
        ClienteNegocio negocio = new ClienteNegocio();
        Cliente cliente = new Cliente();
        VoucherNegocio negociov = new VoucherNegocio();
        bool yaRegistrado;
        protected void Page_Load(object sender, EventArgs e)
        {
            dni = Session["Dni"] != null ? Session["Dni"].ToString() : "";
            if (dni != "")
            {


                txtDocumento.Text = dni;
                txtDocumento.Enabled = false;
                cliente = negocio.ObtenerDniCliente(dni);
                if (cliente != null)
                {
                    yaRegistrado = true;
                    txtNombre.Text = cliente.Nombre;
                    txtNombre.Enabled = false;
                    txtApellido.Text = cliente.Apellido;
                    txtApellido.Enabled = false;
                    txtEmail.Text = cliente.Email;
                    txtEmail.Enabled = false;
                    txtDireccion.Text = cliente.Direccion;
                    txtDireccion.Enabled = false;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCiudad.Enabled = false;
                    txtCP.Text = cliente.CP.ToString();
                    txtCP.Enabled = false;
                    lblError.Text = "El cliente ya está registrado.";
                    lblError.Visible = true;
                    btnGuardar.Visible = false;
                    btnContinuar.Visible = true;
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (yaRegistrado == false)
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


                try
                {
                    Cliente client = new Cliente
                    {
                        Documento = documento,
                        Nombre = nombre,
                        Apellido = apellido,
                        Email = email,
                        Direccion = direccion,
                        Ciudad = ciudad,
                        CP = cp
                    };
                    bool registrado = negocio.RegistrarClienteSiNoExiste(client);

                    if (registrado)

                    {

                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "¡Registro exitoso!";
                        lblError.Visible = true;
                        btnGuardar.Visible = false;
                        btnContinuar.Visible = true;
                        client = negocio.ObtenerDniCliente(client.Documento);
                        negociov.guardarVoucher(Session["idVoucher"].ToString(), client.Id, DateTime.Now, Convert.ToInt32(Session["IdArticulo"]));

                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Ocurrió un error: " + ex.Message;
                    lblError.Visible = true;
                }
            }
            else
            {
                negociov.guardarVoucher(Session["idVoucher"].ToString(), cliente.Id, DateTime.Now, Convert.ToInt32(Session["IdArticulo"]));
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

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }

}