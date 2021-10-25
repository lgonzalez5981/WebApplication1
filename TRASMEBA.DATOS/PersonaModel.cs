using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRASMEBA.DATOS
{
    public class PersonaModel
    {   
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoSangre { get; set; }
        public int IdCiudad { get; set; }
        public int IdDepartamento { get; set; }
        public string TelefonoContacto { get; set; }
        public string LicenciaConducion { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
