<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSeguimientoPedidos.aspx.cs" Inherits="WebApplication1.frmSeguimientoPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container">
        <h2>Pedidos Entregados</h2>
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
                                                        <th>Fecha Entrega</th>
                                                        <th>Identificación</th>
                                                        <th>Conductor</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater runat="server" ID="rptPedido">
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
                                                                    <asp:Label runat="server" ID="lblFechaEntrega" Text='<%#Eval("FechaEntregaCliente")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblIdEmpleado" Text='<%#Eval("IdEmpleado")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblNombre" Text='<%#Eval("Nombre")%>'></asp:Label>
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
</asp:Content>
