using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRASMEBA.DATOS
{
    public class PedidoDB
    {
        public void GuardarPedido(string IdPedido, DateTime FechaPedido, string Origen, string Destino, string Descripcion, string Peso)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_PEDIDO", IdPedido)
                                                                ,new SqlParameter("@FECHA", FechaPedido)
                                                                ,new SqlParameter("@ORIGEN", Origen)
                                                                ,new SqlParameter("@DESTINO", Destino)
                                                                ,new SqlParameter("@DESCRIPCION", Descripcion)
                                                                ,new SqlParameter("@PESO", Peso)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Admon_Registrar_Pedido", sqlParameters1);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable ListarPedidos()
        {
            DataTable dataTable;

            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Admon_Listar_Pedidos", null);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataTable = dataSet.Tables[0];
                }
                else
                {
                    dataTable = null;
                }
                return dataTable;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void GuardarDetallePedido(string IdDetalle,string IdPedido, string IdProducto, string Cantidad)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_DETALLE", IdDetalle)
                                                                ,new SqlParameter("@ID_PEDIDO", IdPedido)
                                                                ,new SqlParameter("@ID_PRODUCTO", IdProducto)
                                                                ,new SqlParameter("@CANTIDAD", Cantidad)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Admon_Guardar_Detalle_Pedido", sqlParameters1);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable ListarDetallePedido(string IdPedido)
        {
            DataTable dataTable;
            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_PEDIDO", IdPedido)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Admon_Listar_Detalle_Pedido", sqlParameters1);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataTable = dataSet.Tables[0];
                }
                else
                {
                    dataTable = null;
                }
                return dataTable;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
