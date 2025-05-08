using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class VoucherNegocio
    {
        //Solo modificar siempre y cuando tenga todo null como dice Leandro
        //Seria corroborar si el codigo tiene null... Si tiene null es porque no se utilizó.
        //Y ahi modificar la tabla voucher

        /*
        public void ModificarVoucher(Voucher voucher, int idCliente, DateTime fechaCanje, int idArticulo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (voucher.IdCliente != null || voucher.FechaCanje != null || voucher.IdArticulo != null)
                    throw new InvalidOperationException("El voucher ya fue utilizado y no puede ser modificado.");

                // Si pasa el if, actualizop los datos:
                voucher.IdCliente = idCliente;
                voucher.FechaCanje = fechaCanje;
                voucher.IdArticulo = idArticulo;

                // Acá iría tu código para actualizar en la base de datos, por ejemplo:
                
                    datos.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @Codigo");
                    datos.setearParametro("@IdCliente", voucher.IdCliente);
                    datos.setearParametro("@FechaCanje", voucher.FechaCanje);
                    datos.setearParametro("@IdArticulo", voucher.IdArticulo);
                    datos.setearParametro("@Codigo", voucher.Codigo);

                    datos.ejecutarAccion();
                
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
        */
        
            public List<Articulo> Listar()
            {
                List<Articulo> lista = new List<Articulo>();
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta(@"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, 
                                     A.IdCategoria, C.Descripcion AS Categoria, A.Precio, 
                                     MIN(I.ImagenUrl) AS ImagenesUrl
                                     FROM ARTICULOS A
                                     JOIN MARCAS M ON A.IdMarca = M.Id
                                     LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                                     LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo
                                     GROUP BY A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion, A.IdCategoria, C.Descripcion, A.Precio");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Articulo aux = new Articulo();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Codigo = datos.Lector["Codigo"].ToString();
                        aux.Nombre = datos.Lector["Nombre"].ToString();
                        aux.Descripcion = datos.Lector["Descripcion"].ToString();
                        aux.Marca = new Marca((int)datos.Lector["IdMarca"], datos.Lector["Marca"].ToString());
                        aux.Categoria = new Categoria((int)datos.Lector["IdCategoria"], datos.Lector["Categoria"].ToString());

                        if (aux.Imagenes == null)
                            aux.Imagenes = new List<Imagen>();

                        if (!(datos.Lector["ImagenesUrl"] is DBNull))
                        {
                            aux.Imagenes.Add(new Imagen(datos.Lector["ImagenesUrl"].ToString()));
                        }
                        else
                        {
                            aux.Imagenes.Add(new Imagen("https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk="));
                        }

                        aux.Precio = (decimal)datos.Lector["Precio"];
                        lista.Add(aux);
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }

            public void guardarVoucher(string codigoVoucher, int idCliente, DateTime fechaCanje, int idArticulo)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo " +
                                         "WHERE CodigoVoucher = @CodigoVoucher;");
                    datos.setearParametro("@IdCliente", idCliente);
                    datos.setearParametro("@FechaCanje", fechaCanje);
                    datos.setearParametro("@IdArticulo", idArticulo);
                    datos.setearParametro("@CodigoVoucher", codigoVoucher);

                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }

            public bool ExisteCodigoVoucher(string codigo)
            {
                AccesoDatos datos = new AccesoDatos();
                bool existe = false;

                try
                {
                    datos.setearConsulta("SELECT CodigoVoucher FROM Vouchers WHERE CodigoVoucher = @codigoV AND IdCliente IS NULL AND FechaCanje IS NULL AND IdArticulo IS NULL");
                    datos.setearParametro("@codigoV", codigo);

                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                        existe = true;
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
        }
    }


