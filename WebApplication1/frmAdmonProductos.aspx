<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdmonProductos.aspx.cs" Inherits="WebApplication1.frmAdmonProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="hIdProducto" Value="0" />
    <asp:ScriptManager runat="server" />
    <div class="container">
        <asp:Button Text="Nuevo" runat="server" CssClass="btn botonRojo" OnClick="bttNuevo_Click" ID="bttNuevo" />
    </div>
    <div class="container border rounded border-panel-padding" runat="server" id="pnlNuevo" visible="false">
        <div class="row">
            <div class="col-md-3">
                <label class="sr-only">Producto:</label>
                <asp:TextBox runat="server" ID="txtProducto" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="sr-only">Peso:</label>
                <asp:TextBox runat="server" ID="txtPeso" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="sr-only">Código:</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="sr-only">Disponible:</label>
                <asp:CheckBox runat="server" ID="chkDisponible" />
            </div>
        </div>
        <div class="row">
            <div class="d-flex flex-row-reverse bd-highlight">
                <asp:Button Text="Guardar" runat="server" CssClass="btn botonRojo" OnClick="bttGuardar_Click" ID="bttGuardar" />
            </div>

        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-header"><strong>Productos</strong></div>
                <div class="card-body">
                    <div class="table-stats order-table ov-h">
                        <table class="table ">
                            <thead>
                                <tr>
                                    <th>Producto</th>
                                    <th>Fecha Creación</th>
                                    <th>Peso</th>
                                    <th>Codigo</th>
                                    <th>Disponible</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptProducto" OnItemCommand="rptProducto_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:HiddenField runat="server" ID="hIdProducto" Value='<%#Eval("IdProducto")%>' />
                                                <asp:Label runat="server" ID="lblProducto" Text='<%#Eval("Producto")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="lblFechaCreacion" Text='<%#Eval("FechaCreacion")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPeso" Text='<%#Eval("Peso")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCodigo" Text='<%#Eval("Codigo")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkDiscponible" Checked='<%#Eval("Disponible")%>' Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="bttEditar" CommandName="Editar" ToolTip="Seleccione el pedido a editar">
                                                        <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-pencil-square" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456l-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                                        </svg>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="bttCerrar" CssClass="btn botonRojo" Text="Cerrar" OnClick="bttCerrar_Click" CausesValidation="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
