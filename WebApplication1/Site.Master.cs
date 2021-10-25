﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRASMEBA.DATOS;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objPersona"] != null)
            {
                PersonaModel objPersona = (PersonaModel)Session["objPersona"];
                if (objPersona.IdTipoUsuario == 1)
                {
                    pnlAdministracion.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}