<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLanding.aspx.cs" Inherits="WebApplication1.frmLanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:HiddenField runat="server" ID="hIdEmpleado" />
    <div class="container">
        <h2>Mis Pedidos Asignados</h2>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="card">
                                    <div class="card-header"><strong>Pedidos</strong></div>
                                    <div class="card-body">
                                        <div class="table-stats order-table ov-h">
                                            <table class="table ">
                                                <thead>
                                                    <tr>
                                                        <th>Fecha Pedido</th>
                                                        <th>Origen</th>
                                                        <th>Destino</th>
                                                        <th>Descripcion</th>
                                                        <th>Peso</th>
                                                        <th></th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater runat="server" ID="rptPedido" OnItemCommand="rptPedido_ItemCommand">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField runat="server" ID="hIdPedido" Value='<%#Eval("IdPedido")%>' />
                                                                    <asp:Label runat="server" ID="lblFechaPedido" Text='<%#Eval("FechaPedido")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblOrigen" Text='<%#Eval("Origen")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblDestino" Text='<%#Eval("Destino")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblDescripcion" Text='<%#Eval("Descripcion")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblPeso" Text='<%#Eval("Peso")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton runat="server" ID="bttProductos" CommandName="Productos" ToolTip="Seleccione para ver los Productos">Productos</asp:LinkButton>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton runat="server" ID="bttEntregar" CommandName="Entregar" ToolTip="Seleccione para Entregar">Entregar</asp:LinkButton>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="bttEntregar_ConfirmButtonExtender"
                                                                        runat="server"
                                                                        ConfirmText="¿Está seguro de entregar el pedido?"
                                                                        TargetControlID="bttEntregar"></ajaxToolkit:ConfirmButtonExtender>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="myModalDetail" role="dialog" aria-labelledby="myModalLabelDetail" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModalDetail" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Productos</h4>
                        </div>
                        <div class="modal-body">
                            <div class="table-stats order-table ov-h">
                                <table class="table ">
                                    <thead>
                                        <tr>
                                            <th>Producto</th>
                                            <th>Código</th>
                                            <th>Cantidad</th>
                                            <th>Peso</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptProducto">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblProducto" Text='<%#Eval("Producto")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCodigo" Text='<%#Eval("Codigo")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCantidad" Text='<%#Eval("Cantidad")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblPesoUnidad" Text='<%#Eval("PesoUnidad")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="bttCerrarDetail" CssClass="btn botonRojo" Text="Cerrar" OnClick="bttCerrarDetail_Click" CausesValidation="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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
