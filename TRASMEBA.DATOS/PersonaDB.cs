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
    public class PersonaDB
    {
        
        public DataTable ListarTipoDocumento()
        {
            DataTable dataTable;

            //SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter(SP_CONSULTA_PENDIENTES_ESTUDIANTE.ID_ESTUDIANTE, strIdEstudiante)
            //                                                    ,new SqlParameter(SP_CONSULTA_PENDIENTES_ESTUDIANTE.ID_GRADO, strIdGrado)
            //                                                    ,new SqlParameter(SP_CONSULTA_PENDIENTES_ESTUDIANTE.ID_PERIODO, strIdPeriodo)
            //};
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Listar_Tipo_Documento", null);
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
        public DataTable ListarDepartamento()
        {
            DataTable dataTable;

            //SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter(SP_CONSULTA_PENDIENTES_ESTUDIANTE.ID_ESTUDIANTE, strIdEstudiante)
            //                                                    ,new SqlParameter(SP_CONSULTA_PENDIENTES_ESTUDIANTE.ID_GRADO, strIdGrado)
            //                                                    ,new SqlParameter(SP_CONSULTA_PENDIENTES_ESTUDIANTE.ID_PERIODO, strIdPeriodo)
            //};
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Listar_Departamento", null);
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
        public DataTable ListarCiudad(string IdDepartamento)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_DEPARTAMENTO", IdDepartamento)
                                                              
            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Listar_Ciudad", sqlParameters1);
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
        public void GuardarUsuario(string IdEmpleado, string Nombre, string Apellido, string Usuario, string Contrasena, DateTime FechaNacimiento, string TipoSangre, string Ciudad, string Departamento, string Telefono, string Licencia)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_EMPLEADO", IdEmpleado)
                                                                ,new SqlParameter("@NOMBRE", Nombre)
                                                                ,new SqlParameter("@APELLIDO", Apellido)
                                                                ,new SqlParameter("@USUARIO", Usuario)
                                                                ,new SqlParameter("@CONTRASENA", Contrasena)
                                                                ,new SqlParameter("@FECHA_NACIMIENTO", FechaNacimiento)
                                                                ,new SqlParameter("@TIPO_SANGRE", TipoSangre)
                                                                ,new SqlParameter("@CIUDAD", Ciudad)
                                                                ,new SqlParameter("@DEPARTAMENTO", Departamento)
                                                                ,new SqlParameter("@TELEFONO", Telefono)
                                                                ,new SqlParameter("@LICENCIA", Licencia)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Guardar_Usuario", sqlParameters1);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void GuardarVehiculo(string IdVehiculo, string Placa, string Modelo, string Ruedas, string IdEmpleado, string Capacidad, string Matricula)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@ID_VECHICULO", IdVehiculo)
                                                                ,new SqlParameter("@PLACA", Placa)
                                                                ,new SqlParameter("@MODELO", Modelo)
                                                                ,new SqlParameter("@RUEDAS", Ruedas)
                                                                ,new SqlParameter("@ID_EMPLEADO", IdEmpleado)
                                                                ,new SqlParameter("@CAPACIDAD", Capacidad)
                                                                ,new SqlParameter("@MATRICULA", Matricula)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Guardar_Vehiculo", sqlParameters1);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet ValidarUsuario(string Usuario, string Contrasena)
        {
            DataTable dataTable;

            SqlParameter[] sqlParameters1 = new SqlParameter[] { new SqlParameter("@USUARIO", Usuario)
                                                                ,new SqlParameter("@CONTRASENA", Contrasena)

            };
            Datos datos = new Datos();


            try
            {
                DataSet dataSet = datos.EjecutarSP("P_Login_Usuario", sqlParameters1);
                
                return dataSet;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
