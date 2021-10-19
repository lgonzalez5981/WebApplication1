<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRegistro.aspx.cs" Inherits="WebApplication1.frmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Bootstrap CSS -->


    <title>TrasmebaCarga</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css?_cacheOverride=1622164133047" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous" />
    <link rel="stylesheet" href="styles/style.css" />
        <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
        <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
        media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <header>
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                    <%--<img src="assets/Logo TMB Transparente.png" alt="" />--%>
                    <button class="navbar-toggler collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                </div>
            </nav>
        </header>
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
                    <div class="form-group">
                        <label for="exampleInputEmail1">Licencia</label>
                        <asp:FileUpload runat="server" ID="fupLicencia" />
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

                    <div class="form-group">
                        <label for="exampleInputEmail1">Usuario</label>
                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUsuario"
                            ErrorMessage="Diligencie el usuario"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Contraseña</label>
                        <asp:TextBox runat="server" ID="txtContrasena" CssClass="form-control" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtContrasena"
                            ErrorMessage="Diligencie la contraseña"><label style="color:red"><b>*</b></label></asp:RequiredFieldValidator>
                    </div>

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
                    <div class="form-group">
                        <label for="exampleInputEmail1">Matricula</label>
                        <asp:FileUpload runat="server" ID="fupMatricula" />
                    </div>
                    <div class="row">
                        <div class="d-flex flex-row-reverse bd-highlight">
                            <asp:Button Text="Enviar" runat="server" CssClass="btn botonRojo" OnClick="Unnamed_Click" ID="bttGuardar" />

                        </div>
                    </div>
                    <div class="row">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
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
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
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
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/jquery@2.2.4/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.4/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-match-height@0.7.2/dist/jquery.matchHeight.min.js"></script>
    </form>
</body>
</html>
