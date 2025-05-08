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
