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
    public partial class frmPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarPedidos();
            }
        }
        private void ListarPedidos()
        {
            PedidoDB objPedido = new PedidoDB();
            DataTable dttPedido = objPedido.ListarPedidoDisponible();
            rptPedido.DataSource = dttPedido;
            rptPedido.DataBind();

        }
        protected void rptPedido_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Inscribir")
            {
                HiddenField hIdPedidoGrid = e.Item.FindControl("hIdPedido") as HiddenField;
                PersonaModel objPersona = (PersonaModel)Session["objPersona"];
                string IdEmpleado = objPersona.IdEmpleado;
                PedidoDB objPedido = new PedidoDB();
                objPedido.InscribirEmpleadoPedido(hIdPedidoGrid.Value, IdEmpleado);
                lblModalTitle.Text = "Correcto";
                lblModalBody.Text = "Su inscripción esta siendo procesada, nos comunicaremos con usted proximamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
                upModal.Update();
                ListarPedidos();
            }
            if(e.CommandName== "Productos")
            {
                HiddenField hIdPedidoGrid = e.Item.FindControl("hIdPedido") as HiddenField;
                PedidoDB objPedido = new PedidoDB();
                DataTable dttProductos = objPedido.ListarDetallePedido(hIdPedidoGrid.Value);
                rptProducto.DataSource = dttProductos;
                rptProducto.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalDetail", "$('#myModalDetail').show();", true);
                upModalDetail.Update();
            }
        }
        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').hide();", true);
        }
        protected void rptPedido_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hIdPedido = (HiddenField)e.Item.FindControl("hIdPedido");
            if (hIdPedido != null)
            {
                PersonaModel objPersona = (PersonaModel)Session["objPersona"];
                string IdEmpleado = objPersona.IdEmpleado;
                PedidoDB objPedido = new PedidoDB();
                DataTable dttPedidoAsignado = objPedido.ValidarUsuarioPedido(IdEmpleado, hIdPedido.Value);
                if (dttPedidoAsignado != null)
                {
                    LinkButton bttInscribir = (LinkButton)e.Item.FindControl("bttInscribir");
                    bttInscribir.Visible = false;
                }
            }
        }

        protected void bttCerrarDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalDetail", "$('#myModalDetail').hide();", true);
        }
    }
}