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
    public partial class frmLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objPersona"] != null)
            {
                PersonaModel objPersona = (PersonaModel)Session["objPersona"];
                hIdEmpleado.Value = objPersona.IdEmpleado;
                ListarPedido(objPersona.IdEmpleado);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        private void ListarPedido(string IdEmpleado)
        {
            PedidoDB objPedido = new PedidoDB();
            DataTable dttPedido = objPedido.ListarPedidoAsignadoEmpleado(IdEmpleado);
            rptPedido.DataSource = dttPedido;
            rptPedido.DataBind();
        }
        protected void rptPedido_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Productos")
            {
                HiddenField hIdPedidoGrid = e.Item.FindControl("hIdPedido") as HiddenField;
                PedidoDB objPedido = new PedidoDB();
                DataTable dttProductos = objPedido.ListarDetallePedido(hIdPedidoGrid.Value);
                rptProducto.DataSource = dttProductos;
                rptProducto.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalDetail", "$('#myModalDetail').show();", true);
                upModalDetail.Update();
            }
            if (e.CommandName == "Entregar")
            {
                HiddenField hIdPedidoGrid = e.Item.FindControl("hIdPedido") as HiddenField;
                PedidoDB objPedido = new PedidoDB();
                objPedido.EntregarPedidoCliente(hIdPedidoGrid.Value, hIdEmpleado.Value);
                ListarPedido(hIdEmpleado.Value);
                lblModalTitle.Text = "Correcto";
                lblModalBody.Text = "Gracias por realizar la entrega, en unos instantes nos comunicaremos con usted";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
                upModal.Update();
            }

        }

        protected void bttCerrarDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalDetail", "$('#myModalDetail').hide();", true);
        }

        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').hide();", true);
        }
    }
}