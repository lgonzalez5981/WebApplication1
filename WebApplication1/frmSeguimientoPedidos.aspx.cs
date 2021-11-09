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
    public partial class frmSeguimientoPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarPedidoEntregadoEmpleado();
            }
        }
        private void ListarPedidoEntregadoEmpleado()
        {
            PedidoDB objPedido = new PedidoDB();
            DataTable dttPedido = objPedido.ListarPedidoEntregadoCliente();
            rptPedido.DataSource = dttPedido;
            rptPedido.DataBind();
        }
    }
}