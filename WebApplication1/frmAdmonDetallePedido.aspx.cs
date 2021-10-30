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
    public partial class frmAdmonDetallePedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["IdPedido"] != null)
                {
                    string strIdPedido = Request.QueryString["IdPedido"].ToString();
                    hIdPedido.Value = strIdPedido;
                    ListarProductoDetallePeido();
                    ListarDetalle();
                }
            }
        }
        private void ListarDetalle()
        {
            string IdPedido = hIdPedido.Value;
            PedidoDB objPedido = new PedidoDB();
            DataTable dttDetalle = objPedido.ListarDetallePedido(IdPedido);
            rptDetalle.DataSource = dttDetalle;
            rptDetalle.DataBind();

        }
        private void ListarProductoDetallePeido()
        {
            ProductoDB objProducto = new ProductoDB();
            DataTable dttProducto = objProducto.ListarProductosDetallePedido();
            drpProducto.DataSource = dttProducto;
            drpProducto.DataTextField = "Producto";
            drpProducto.DataValueField = "IdProducto";
            drpProducto.DataBind();
            drpProducto.Items.Insert(0, new ListItem("Seleccione Producto", "0"));
        }
        protected void bttNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtCantidad.Text = "";
            hIdDetalle.Value = "0";
            pnlNuevo.Visible = true;
        }

        protected void rptDetalle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void bttGuardar_Click(object sender, EventArgs e)
        {
            string IdDetalle = hIdDetalle.Value;
            string IdPedido = hIdPedido.Value;
            string IdProducto = drpProducto.SelectedValue;
            string Cantidad = txtCantidad.Text;
            PedidoDB objOPedido = new PedidoDB();
            objOPedido.GuardarDetallePedido(IdDetalle, IdPedido, IdProducto, Cantidad);
            ListarDetalle();
            Limpiar();
            pnlNuevo.Visible = false;
            lblModalTitle.Text = "Correcto";
            lblModalBody.Text = "Producto registrado correctamente";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').show();", true);
            upModal.Update();
        }

        protected void bttCerrar_Click(object sender, EventArgs e)
        {
            pnlNuevo.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').hide();", true);
        }

        protected void bttRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAdmonPedidos.aspx");
        }
    }
}