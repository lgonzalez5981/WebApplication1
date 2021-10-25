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
    public partial class frmAdmonProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ListarProducto();
            }
        }
        private void ListarProducto()
        {
            ProductoDB objProducto = new ProductoDB();
            DataTable dttProducto = objProducto.ListarProductos();
            rptProducto.DataSource = dttProducto;
            rptProducto.DataBind();

        }
        protected void bttNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            pnlNuevo.Visible = true;
        }
        private void Limpiar()
        {
            hIdProducto.Value = "0";
            txtCodigo.Text = "";
            txtPeso.Text = "";
            txtProducto.Text = "";
            chkDisponible.Checked = false;
        }
        protected void bttGuardar_Click(object sender, EventArgs e)
        {
            string IdProducto = hIdProducto.Value;
            string Producto = txtProducto.Text;
            string Peso = txtPeso.Text;
            string Codigo = txtCodigo.Text;
            bool Disponible = chkDisponible.Checked;

            ProductoDB objProducto = new ProductoDB();
            objProducto.GuardarProducto(IdProducto, Producto, Peso, Codigo, Disponible);
            ListarProducto();
            Limpiar();
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

        protected void rptProducto_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                HiddenField hhIdProductoGrid = e.Item.FindControl("hIdProducto") as HiddenField;
                hIdProducto.Value = hhIdProductoGrid.Value;
                Label lblProducto = e.Item.FindControl("lblProducto") as Label;
                txtProducto.Text = lblProducto.Text;
                Label lblPeso = e.Item.FindControl("lblPeso") as Label;
                txtPeso.Text = lblPeso.Text;
                Label lblCodigo = e.Item.FindControl("lblCodigo") as Label;
                txtCodigo.Text = lblCodigo.Text;
                CheckBox chkDiscponibleGrid = e.Item.FindControl("chkDiscponible") as CheckBox;
                chkDisponible.Checked = chkDiscponibleGrid.Checked;
                pnlNuevo.Visible = true;
            }
        }
    }
}