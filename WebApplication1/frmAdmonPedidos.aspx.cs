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
    public partial class frmAdmonPedidos : System.Web.UI.Page
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
            DataTable dttPedido = objPedido.ListarPedidos();
            rptPedido.DataSource = dttPedido;
            rptPedido.DataBind();
        }

        protected void bttGuardar_Click(object sender, EventArgs e)
        {
            string IdPedido = hIdPedido.Value;
            DateTime FechaPedido = Convert.ToDateTime(txtFechaPedido.Text);
            string Origen = txtOrigen.Text;
            string Destino = txtDestino.Text;
            string Descripcion = txtDescripcion.Text;
            string Peso = txtPeso.Text;

            PedidoDB objPedido = new PedidoDB();
            objPedido.GuardarPedido(IdPedido, FechaPedido, Origen, Destino, Descripcion, Peso);

            Limpiar();
            ListarPedidos();
            pnlSolicitud.Visible = false;
            lblModalTitle.Text = "Correcto";
            lblModalBody.Text = "Pedido registrado correctamente";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
            upModal.Update();
        }
        private void Limpiar()
        {
            hIdPedido.Value = "0";
            txtDescripcion.Text = "";
            txtDestino.Text = "";
            txtFechaPedido.Text = "";
            txtOrigen.Text = "";
            txtPeso.Text = "";
        }
        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            pnlSolicitud.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').hide();", true);
        }

        protected void bttNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            pnlSolicitud.Visible = true;
        }

        protected void rptPedido_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                HiddenField hIdPedidoGrid = e.Item.FindControl("hIdPedido") as HiddenField;
                hIdPedido.Value = hIdPedidoGrid.Value;
                Label lblFechaPedido = e.Item.FindControl("lblFechaPedido") as Label;
                txtFechaPedido.Text = lblFechaPedido.Text;
                Label lblDescripcion = e.Item.FindControl("lblDescripcion") as Label;
                txtDescripcion.Text = lblDescripcion.Text;
                Label lblOrigen = e.Item.FindControl("lblOrigen") as Label;
                txtOrigen.Text = lblOrigen.Text;
                Label lblDestino = e.Item.FindControl("lblDestino") as Label;
                txtDestino.Text = lblDestino.Text;
                Label lblPeso = e.Item.FindControl("lblPeso") as Label;
                txtPeso.Text = lblPeso.Text;

                pnlSolicitud.Visible = true;
            }
            if(e.CommandName== "Productos")
            {
                HiddenField hIdPedidoGrid = e.Item.FindControl("hIdPedido") as HiddenField;
                string strIdPedido = hIdPedidoGrid.Value;
                Response.Redirect("frmAdmonDetallePedido.aspx?IdPedido="+strIdPedido);
            }
        }
    }
}