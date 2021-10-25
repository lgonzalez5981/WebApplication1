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
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bttLogin_Click(object sender, EventArgs e)
        {
            string strUsuario = txtUsuario.Text;
            string strContrasena = txtContrasena.Text;
            PersonaDB objPersona = new PersonaDB();
            DataSet dsUsuario = objPersona.ValidarUsuario(strUsuario, strContrasena);
            if (dsUsuario.Tables.Count > 0)
            {
                PersonaModel objPersonaModel = new PersonaModel();
                objPersonaModel.IdEmpleado = dsUsuario.Tables[0].Rows[0]["IdEmpleado"].ToString();
                objPersonaModel.Nombre = dsUsuario.Tables[0].Rows[0]["Nombre"].ToString();
                objPersonaModel.Apellido = dsUsuario.Tables[0].Rows[0]["Apellido"].ToString();
                objPersonaModel.Usuario = dsUsuario.Tables[0].Rows[0]["Usuario"].ToString();
                objPersonaModel.Contrasena = dsUsuario.Tables[0].Rows[0]["Contrasena"].ToString();
                objPersonaModel.FechaNacimiento = Convert.ToDateTime(dsUsuario.Tables[0].Rows[0]["FechaNacimiento"].ToString());
                objPersonaModel.TipoSangre = dsUsuario.Tables[0].Rows[0]["TipoSangre"].ToString();
                objPersonaModel.IdCiudad = Convert.ToInt32(dsUsuario.Tables[0].Rows[0]["IdCiudad"].ToString());
                objPersonaModel.IdDepartamento = Convert.ToInt32(dsUsuario.Tables[0].Rows[0]["IdDepartamento"].ToString());
                objPersonaModel.TelefonoContacto = dsUsuario.Tables[0].Rows[0]["TelefonoContacto"].ToString();
                objPersonaModel.LicenciaConducion = dsUsuario.Tables[0].Rows[0]["LicenciaConducion"].ToString();
                objPersonaModel.IdTipoUsuario = Convert.ToInt32(dsUsuario.Tables[0].Rows[0]["IdTipoUsuario"].ToString());
                Session.Add("objPersona", objPersonaModel);

                VehiculoModel objVehiculo = new VehiculoModel();
                objVehiculo.IdVechiculo = dsUsuario.Tables[1].Rows[0]["IdVechiculo"].ToString();
                objVehiculo.Placa = dsUsuario.Tables[1].Rows[0]["Placa"].ToString();
                objVehiculo.Modelo = dsUsuario.Tables[1].Rows[0]["Modelo"].ToString();
                objVehiculo.Ruedas = dsUsuario.Tables[1].Rows[0]["Ruedas"].ToString();
                objVehiculo.Capacidad = dsUsuario.Tables[1].Rows[0]["Capacidad"].ToString();
                objVehiculo.Matricula = dsUsuario.Tables[1].Rows[0]["Matricula"].ToString();
                Session.Add("objVehiculo", objVehiculo);
                Response.Redirect("frmLanding.aspx");
            }
            else
            {
                lblModalTitle.Text = "Credenciales Incorrectas";
                lblModalBody.Text = "Por favor verifique que el usuario y contraseña sean correctos";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
                upModal.Update();
            }
        }

        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Credenciales Incorrectas";
            lblModalBody.Text = "Por favor verifique que el usuario y contraseña sean correctos";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').hide();", true);
            upModal.Update();
        }
    }
}