using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=PROMOS_DB; integrated security=true");
            comando = new SqlCommand();
        }
        /*prueba para Voucher negocio
        public bool ExisteCodigoVoucher(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            bool existe = false;

            try
            {

                datos.setearConsulta("SELECT CodigoVoucher, FechaCanje FROM Vouchers WHERE CodigoVoucher = @codigoV AND FechaCanje IS NULL");
                datos.comando.Parameters.Clear();
                datos.comando.Parameters.AddWithValue("@codigoV", codigo);


                datos.ejecutarLectura();


                if (datos.Lector.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return existe;
        }
    
fin prueba vouycher negocio */
public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public int obtenerIdArt(string codigo)
        {
            int id = 0;
            try
            {
                setearConsulta("SELECT Id FROM ARTICULOS WHERE Codigo = @Codigo");
                setearParametro("@Codigo", codigo);
                ejecutarLectura();
                if (Lector.Read())
                {
                    id = (int)(Lector["Id"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
            return id;


        }
    }
}
