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