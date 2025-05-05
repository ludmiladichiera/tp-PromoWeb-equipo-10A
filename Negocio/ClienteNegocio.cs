using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ClienteNegocio
    {

        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = datos.Lector["Documento"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Email = datos.Lector["Email"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        Ciudad = datos.Lector["Ciudad"].ToString(),
                        CP = (int)datos.Lector["CP"]
                    };

                    lista.Add(cliente);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Cliente ObtenerDniCliente(string dni)
        {
            Cliente cliente = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    cliente = new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = datos.Lector["Documento"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Email = datos.Lector["Email"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        Ciudad = datos.Lector["Ciudad"].ToString(),
                        CP = (int)datos.Lector["CP"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por DNI", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
            return cliente;
        }

        public void AltaCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                                     "VALUES(@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                datos.setearParametro("@Documento", cliente.Documento);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Direccion", cliente.Direccion);
                datos.setearParametro("@Ciudad", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        //esto nose 
        public bool RegistrarClienteSiNoExiste(Cliente cliente)
        {
            Cliente clienteExistente = ObtenerDniCliente(cliente.Documento);
            if (clienteExistente != null)
            {

                return false;
            }

            AltaCliente(cliente);
            return true;
        }
    }
}


    