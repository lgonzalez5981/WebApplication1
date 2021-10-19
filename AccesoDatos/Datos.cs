using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Datos
    {
        public DataSet EjecutarSP(string strNombreProcedimiento, SqlParameter[] sqlParameter)
        {
            DataSet result;
            string connetionString;
            connetionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connetionString);
            using (SqlCommand command = connection.CreateCommand())
            {
                dataSet = SqlHelper.ExecuteDataset(connetionString, CommandType.StoredProcedure, strNombreProcedimiento, sqlParameter);
                result = dataSet;
            }
            return result;
        }
    }
}
