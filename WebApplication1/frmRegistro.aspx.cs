using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRASMEBA.DATOS;

namespace WebApplication1
{
    public partial class frmRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarTipoDocumento();
                ListarDepartamento();
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
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string Identificacion = txtIdentificacion.Text;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Usuario = txtUsuario.Text;
            string Contrasena = txtContrasena.Text;
            DateTime FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            string TipoSangre = txtTipoSangre.Text;
            string Ciudad = drpCiudad.SelectedValue;
            string Departamento = drpDepartamento.SelectedValue;
            string Telefono = txtTelefono.Text;
            string UrlLicencia = "";
            if (fupLicencia.HasFile)
            {
                string strRutaDestinoPregunta = Server.MapPath("LicenciaConduccion");
                string strRuta = strRutaDestinoPregunta + "\\" + fupLicencia.FileName;
                fupLicencia.SaveAs(strRuta);
                UrlLicencia = "LicenciaConduccion/" + fupLicencia.FileName;
            }
            PersonaDB objPersona = new PersonaDB();
            objPersona.GuardarUsuario(Identificacion, Nombre, Apellido, Usuario, Contrasena, FechaNacimiento, TipoSangre, Ciudad, Departamento,Telefono,UrlLicencia);

            string IdVehiculo = "0";
            string Placa = txtPlaca.Text;
            string Modelo = txtModelo.Text;
            string Ruedas = txtRuedas.Text;
            string Capacidad = txtCapacidad.Text;
            string UrlMatricula = "";
            if (fupMatricula.HasFile)
            {
                string strRutaDestinoPregunta = Server.MapPath("Matriculas");
                string strRuta = strRutaDestinoPregunta + "\\" + fupMatricula.FileName;
                fupMatricula.SaveAs(strRuta);
                UrlMatricula = "Matriculas/" + fupMatricula.FileName;
            }
            objPersona.GuardarVehiculo(IdVehiculo, Placa, Modelo, Ruedas, Identificacion, Capacidad, UrlMatricula);

            lblModalTitle.Text = "Correcto";
            lblModalBody.Text = "Usuario registrado correctamente";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
            upModal.Update();
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

        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}