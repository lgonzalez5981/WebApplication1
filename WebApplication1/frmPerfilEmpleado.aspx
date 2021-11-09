<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPerfilEmpleado.aspx.cs" Inherits="WebApplication1.frmPerfilEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="hIdEmpleado" />
    <asp:HiddenField runat="server" ID="hIdVehiculo" />
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-md-6">
            <asp:LinkButton Text="Descargar Licencia" runat="server" ID="bttDescargarLicencia" OnClick="Unnamed_Click" CausesValidation="false" />
        </div>
        <div class="col-md-6">
            <asp:LinkButton Text="Descargar Matricula" runat="server" ID="bttDescargarMatricula" OnClick="bttDescargarMatricula_Click" CausesValidation="false" />
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlUsuario">
        <div class="row">
            <div class="col-md-6">
                <div class="border rounded border-panel-padding">
                    <h6>Por favor diligenciar los campos solicitados</h6>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Nombres</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNombre"
                            ErrorMessage="Diligencie el nombre"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Apellidos</label>
                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApellido"
                            ErrorMessage="Diligencie el apellido"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Tipo Documento</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="drpTipoDocumento">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Identificación</label>
                        <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIdentificacion"
                            ErrorMessage="Diligencie la identificacion"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Tipo Sangre</label>
                        <asp:TextBox runat="server" ID="txtTipoSangre" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTipoSangre"
                            ErrorMessage="Diligencie el tipo de sangre"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Fecha Nacimiento</label>
                        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="cldNacimiento" runat="server"
                            PopupButtonID="txtFechaNacimiento" TargetControlID="txtFechaNacimiento" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTipoSangre"
                            ErrorMessage="Diligencie la fecha de nacimiento"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group" id="pnlLicencia" runat="server">
                        <label for="exampleInputEmail1">Licencia</label>
                        <asp:FileUpload runat="server" ID="fupLicencia" />

                        <asp:HiddenField runat="server" ID="hUrlLicencia" Value="" />
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Telefóno</label>
                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTelefono"
                            ErrorMessage="Diligencie el teléfono"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Departamento</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="drpDepartamento" OnSelectedIndexChanged="drpDepartamento_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Ciudad</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="drpCiudad">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Panel runat="server" ID="pnlContrasena">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Usuario</label>
                            <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUsuario"
                                ErrorMessage="Diligencie el usuario"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Contraseña</label>
                            <asp:TextBox runat="server" ID="txtContrasena" CssClass="form-control" TextMode="Password" />
                            <asp:HiddenField runat="server" ID="hContrasena" Value="" />
                        </div>
                    </asp:Panel>


                </div>
            </div>
            <div class="col-md-6">
                <div class="border rounded border-panel-padding">
                    <h6>Por favor diligenciar información de su vehiculo</h6>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Placa</label>
                        <asp:TextBox runat="server" ID="txtPlaca" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPlaca"
                            ErrorMessage="Diligencie la placa"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Modelo</label>
                        <asp:TextBox runat="server" ID="txtModelo" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtModelo"
                            ErrorMessage="Diligencie el modelo"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1"># Ruedas</label>
                        <asp:TextBox runat="server" ID="txtRuedas" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRuedas"
                            ErrorMessage="Diligencie las ruedas"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Capacidad (toneladas)</label>
                        <asp:TextBox runat="server" ID="txtCapacidad" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCapacidad"
                            ErrorMessage="Diligencie la capacidad"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group" id="pnlMatricula" runat="server">
                        <label for="exampleInputEmail1">Matricula</label>
                        <asp:FileUpload runat="server" ID="fupMatricula" />
                        <asp:HiddenField runat="server" ID="hUrlMatricula" Value="" />
                    </div>
                    <div class="row">
                        <div class="d-flex flex-row-reverse bd-highlight">
                            <asp:Button Text="Enviar" runat="server" CssClass="btn botonRojo" OnClick="bttGuardar_Click" ID="bttGuardar" />

                        </div>
                    </div>
                    <div class="row">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </div>
                </div>
            </div>

        </div>
    </asp:Panel>
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
