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
    public class ProductoDB
    {
        public void GuardarProducto(string IdProducto, string Producto, string Peso, string Codigo, bool Disponible)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_PRODUCTO", IdProducto)
                                                                ,new SqlParameter("@PRODUCTO", Producto)
                                                                ,new SqlParameter("@PESO", Peso)
                                                                ,new SqlParameter("@CODIGO", Codigo)
                                                                ,new SqlParameter("@DISPONIBLE", Disponible)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Guardar_Producto", sqlParameters1);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable ListarProductos()
        {
            DataTable dataTable;

            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Listar_Producto", null);
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
        public DataTable ListarProductosDetallePedido()
        {
            DataTable dataTable;

            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Listar_Producto_Detalle", null);
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
