using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRASMEBA.DATOS;


namespace WebApplication1
{
    public partial class frmPerfilEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarDepartamento();
                ListarTipoDocumento();
                if (Request.QueryString["IdEmpleado"] != null)
                {
                    string IdEmpleado = Request.QueryString["IdEmpleado"].ToString();
                    hIdEmpleado.Value = IdEmpleado;
                    ListarPerfil();
                    pnlContrasena.Visible = false;
                    bttGuardar.Visible = false;
                    pnlLicencia.Visible = false;
                    pnlMatricula.Visible = false;
                    pnlUsuario.Enabled = false;
                    
                    
                }
                else
                {
                    PersonaModel objPersona = (PersonaModel)Session["objPersona"];
                    hIdEmpleado.Value = objPersona.IdEmpleado;
                    ListarPerfil();
                    pnlUsuario.Enabled = true;
                }
            }
        }
        private void ListarDepartamento()
        {
            PersonaDB objPersona = new PersonaDB();
            DataTable dttDepartamento = objPersona.ListarDepartamento();
            drpDepartamento.DataSource = dttDepartamento;
            drpDepartamento.DataTextField = "Departamento";
            drpDepartamento.DataValueField = "IdDepartamento";
            drpDepartamento.DataBind();
            drpDepartamento.Items.Insert(0, new ListItem("Departamento", "0"));
        }
        private void ListarTipoDocumento()
        {
            PersonaDB objPersona = new PersonaDB();
            DataTable dttTipoDocumenot = objPersona.ListarTipoDocumento();
            drpTipoDocumento.DataSource = dttTipoDocumenot;
            drpTipoDocumento.DataTextField = "TipoDocumento";
            drpTipoDocumento.DataValueField = "IdTipo";
            drpTipoDocumento.DataBind();
            drpTipoDocumento.Items.Insert(0, new ListItem("Tipo Documento", "0"));
        }
        private void ListarPerfil()
        {
            PersonaDB objPersona = new PersonaDB();
            DataSet dsPersona = objPersona.ListarInformacionEmpleado(hIdEmpleado.Value);
            if (dsPersona != null)
            {
                DataTable dttEmpleado = dsPersona.Tables[0];
                string IdEmpleado = dttEmpleado.Rows[0]["IdEmpleado"].ToString();
                txtIdentificacion.Text = IdEmpleado;
                string Nombre = dttEmpleado.Rows[0]["Nombre"].ToString();
                txtNombre.Text = Nombre;
                string Apellido = dttEmpleado.Rows[0]["Apellido"].ToString();
                txtApellido.Text = Apellido;
                string FechaNacimiento = dttEmpleado.Rows[0]["FechaNacimiento"].ToString();
                txtFechaNacimiento.Text = FechaNacimiento;
                string TipoSangre = dttEmpleado.Rows[0]["TipoSangre"].ToString();
                txtTipoSangre.Text = TipoSangre;
                string TelefonoContacto = dttEmpleado.Rows[0]["TelefonoContacto"].ToString();
                txtTelefono.Text = TelefonoContacto;
                string IdDepartamento = dttEmpleado.Rows[0]["IdDepartamento"].ToString();
                drpDepartamento.SelectedValue = IdDepartamento;
                drpDepartamento_SelectedIndexChanged(null, null);
                string IdCiudad = dttEmpleado.Rows[0]["IdCiudad"].ToString();
                drpCiudad.SelectedValue = IdCiudad;
                string LicenciaConducion = dttEmpleado.Rows[0]["LicenciaConducion"].ToString();
                hUrlLicencia.Value = LicenciaConducion;
                string IdTipoDocumento = dttEmpleado.Rows[0]["IdTipoDocumento"].ToString();
                drpTipoDocumento.SelectedValue = IdTipoDocumento;
                string Usuario = dttEmpleado.Rows[0]["Usuario"].ToString();
                txtUsuario.Text = Usuario;
                string Contrasena = dttEmpleado.Rows[0]["Contrasena"].ToString();
                hContrasena.Value = Contrasena;


                DataTable dttVehiculo = dsPersona.Tables[1];
                string IdVehiculo = dttVehiculo.Rows[0]["IdVechiculo"].ToString();
                hIdVehiculo.Value = IdVehiculo;
                string Placa = dttVehiculo.Rows[0]["Placa"].ToString();
                txtPlaca.Text = Placa;
                string Modelo = dttVehiculo.Rows[0]["Modelo"].ToString();
                txtModelo.Text = Modelo;
                string Ruedas = dttVehiculo.Rows[0]["Ruedas"].ToString();
                txtRuedas.Text = Ruedas;
                string Capacidad = dttVehiculo.Rows[0]["Capacidad"].ToString();
                txtCapacidad.Text = Capacidad;
                string Matricula = dttVehiculo.Rows[0]["Matricula"].ToString();
                hUrlMatricula.Value = Matricula;

            }
        }
        protected void drpDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdDepartamento = drpDepartamento.SelectedValue;
            PersonaDB objPersona = new PersonaDB();
            DataTable dttCiudad = objPersona.ListarCiudad(IdDepartamento);
            drpCiudad.DataSource = dttCiudad;
            drpCiudad.DataTextField = "Ciudad";
            drpCiudad.DataValueField = "IdCiudad";
            drpCiudad.DataBind();
            drpCiudad.Items.Insert(0, new ListItem("Ciudad", "0"));
        }

        protected void bttGuardar_Click(object sender, EventArgs e)
        {
            string Identificacion = txtIdentificacion.Text;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Usuario = txtUsuario.Text;
            string Contrasena = hContrasena.Value;
            if (txtContrasena.Text != "")
            {
                Contrasena = txtContrasena.Text;
            }
            DateTime FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            string TipoSangre = txtTipoSangre.Text;
            string Ciudad = drpCiudad.SelectedValue;
            string Departamento = drpDepartamento.SelectedValue;
            string Telefono = txtTelefono.Text;
            string UrlLicencia = hUrlLicencia.Value;
            string IdTipoDocumento = drpTipoDocumento.SelectedValue;
            if (fupLicencia.HasFile)
            {
                string strRutaDestinoPregunta = Server.MapPath("LicenciaConduccion");
                string strRuta = strRutaDestinoPregunta + "\\" + fupLicencia.FileName;
                fupLicencia.SaveAs(strRuta);
                UrlLicencia = "LicenciaConduccion/" + fupLicencia.FileName;
            }
            PersonaDB objPersona = new PersonaDB();
            objPersona.GuardarUsuario(Identificacion, Nombre, Apellido, Usuario, Contrasena, FechaNacimiento, TipoSangre, Ciudad, Departamento, Telefono, UrlLicencia, IdTipoDocumento);

            string IdVehiculo = "0";
            string Placa = txtPlaca.Text;
            string Modelo = txtModelo.Text;
            string Ruedas = txtRuedas.Text;
            string Capacidad = txtCapacidad.Text;
            string UrlMatricula = hUrlMatricula.Value;
            if (fupMatricula.HasFile)
            {
                string strRutaDestinoPregunta = Server.MapPath("Matriculas");
                string strRuta = strRutaDestinoPregunta + "\\" + fupMatricula.FileName;
                fupMatricula.SaveAs(strRuta);
                UrlMatricula = "Matriculas/" + fupMatricula.FileName;
            }
            objPersona.GuardarVehiculo(IdVehiculo, Placa, Modelo, Ruedas, Identificacion, Capacidad, UrlMatricula);

            lblModalTitle.Text = "Correcto";
            lblModalBody.Text = "Información guardada correctamente";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
            upModal.Update();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string filePath = hUrlLicencia.Value;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();

        }

        protected void bttDescargarMatricula_Click(object sender, EventArgs e)
        {
            string filePath = hUrlMatricula.Value;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').hide();", true);
            upModal.Update();
        }
    }
}