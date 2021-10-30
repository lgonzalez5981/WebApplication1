<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdmonPedidos.aspx.cs" Inherits="WebApplication1.frmAdmonPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="hIdPedido" Value="0" />
    <asp:ScriptManager runat="server" />
    <div class="container">
        <asp:Button Text="Nueva Solicitud" runat="server" CssClass="btn botonRojo" OnClick="bttNuevo_Click" ID="bttNuevo" />
    </div>
    <div class="container border rounded border-panel-padding" runat="server" id="pnlSolicitud" visible="false">
        <div class="row">
            <div class="col-md-3">
                <label class="sr-only">Fecha Pedido:</label>
                <asp:TextBox runat="server" ID="txtFechaPedido" CssClass="form-control" />
                <ajaxToolkit:CalendarExtender ID="cldNacimiento" runat="server"
                    PopupButtonID="txtFechaNacimiento" TargetControlID="txtFechaPedido" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-md-3">
                <label class="sr-only">Origen:</label>
                <asp:TextBox runat="server" ID="txtOrigen" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="sr-only">Destino:</label>
                <asp:TextBox runat="server" ID="txtDestino" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="sr-only">Peso:</label>
                <asp:TextBox runat="server" ID="txtPeso" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <label class="sr-only">Descripcion:</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" />
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
                                    <th>Aspirantes</th>
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
                                                <asp:LinkButton runat="server" ID="bttAspirantes" CommandName="Aspirantes" ToolTip="ver Aspirantes"><%#Eval("Aspirantes")%> </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="bttEditar" CommandName="Editar" ToolTip="Seleccione el pedido a editar">
                                                        <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-pencil-square" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456l-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                                        </svg>
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="bttProductos" CommandName="Productos" ToolTip="Seleccione para administrar los Productos">Productos</asp:LinkButton>
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
    <div class="modal" id="myModalAspirantes" role="dialog" aria-labelledby="myModalLabelAspirantes" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModalAspirantes" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content" style="width:120%">
                        <div class="modal-header">
                            <h4 class="modal-title">Aspirantes</h4>
                        </div>
                        <div class="modal-body">
                            <div class="table-stats order-table ov-h">
                                <table class="table ">
                                    <thead>
                                        <tr>
                                            <th>Identificación</th>
                                            <th>Empleado</th>
                                            <th>Departamento</th>
                                            <th>Ciudad</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptAspirante" OnItemCommand="rptAspirante_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField runat="server" ID="hIdAsociado" Value='<%#Eval("IdAsociado")%>'></asp:HiddenField>
                                                        <asp:Label runat="server" ID="lblIdEmpleado" Text='<%#Eval("IdEmpleado")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblEmpleado" Text='<%#Eval("Empleado")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblDepartamento" Text='<%#Eval("Departamento")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCiudad" Text='<%#Eval("Ciudad")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="bttVerEmpleado" CommandName="VerEmpleado" ToolTip="Seleccione para ver el empleado">Ver</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="bttAsignar" CommandName="Asignar" ToolTip="Seleccione el conductor para asignar el pedido">Asignar</asp:LinkButton>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="bttAsignar_ConfirmButtonExtender"
                                                            runat="server"
                                                            ConfirmText="¿Está seguro de asignar el pedido?"
                                                            TargetControlID="bttAsignar"></ajaxToolkit:ConfirmButtonExtender>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="bttCerrarAspirantes" CssClass="btn botonRojo" Text="Cerrar" OnClick="bttCerrarAspirantes_Click" CausesValidation="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
        <div class="modal" id="myModalPedido" role="dialog" aria-labelledby="myModalPedidoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModalPedido" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblTituloConfirmacion" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBodyConfirmacion" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="bttCerrarPedido" CssClass="btn botonRojo" Text="Cerrar" OnClick="bttCerrarPedido_Click" CausesValidation="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
