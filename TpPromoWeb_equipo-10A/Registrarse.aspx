<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpPromoWeb_equipo_10A.Registrarse" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container mt-4">
                <h3 class="mb-4">Registrarse</h3>

                <!-- Línea 1: DNI -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="textDni" class="form-label">DNI</label>
                        <asp:TextBox ID="textDni" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="textDni_TextChanged" />
                        <asp:Label ID="lblErrorDni" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                </div>
                <!-- Línea 2: Nombre, Apellido, Email -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="textNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="textNombre" CssClass="form-control" runat="server" />
                        <asp:Label ID="lblErrorNombre" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                    <div class="col-md-4">
                        <label for="textApellido" class="form-label">Apellido</label>
                        <asp:TextBox ID="textApellido" CssClass="form-control" runat="server" />
                        <asp:Label ID="lblErrorApellido" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                    <div class="col-md-4">
                        <label for="textEmail" class="form-label">Email</label>
                        <asp:TextBox ID="textEmail" CssClass="form-control" runat="server" TextMode="Email" />
                        <asp:Label ID="lblErrorEmail" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                </div>

                <!-- Línea 3: Dirección, Ciudad, CP -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="textDireccion" class="form-label">Dirección</label>
                        <asp:TextBox ID="textDireccion" CssClass="form-control" runat="server" />
                        <asp:Label ID="lblErrorDireccion" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                    <div class="col-md-4">
                        <label for="textCiudad" class="form-label">Ciudad</label>
                        <asp:TextBox ID="textCiudad" CssClass="form-control" runat="server" />
                        <asp:Label ID="lblErrorCiudad" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                    <div class="col-md-4">
                        <label for="textCP" class="form-label">Código Postal</label>
                        <asp:TextBox ID="textCP" CssClass="form-control" runat="server" TextMode="Number" />
                        <asp:Label ID="lblErrorCp" runat="server" CssClass="text-danger small" Visible="false" />
                    </div>
                </div>

                <!-- Checkbox -->
                <div class="row mb-3">
                    <div class="col-md-12">
                        <asp:CheckBox ID="chkbAcepto" runat="server" Text="Acepto términos y condiciones" CssClass="form-check-input me-2" />
                        <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger small d-block mt-1" Visible="false" />
                    </div>
                </div>

                <!-- Botón -->
                <div class="row mb-3">
                    <div class="col-md-12 text-end">
                        <asp:Label ID="lblMensajeExito" runat="server" ForeColor="Green" Visible="False" Text="Cliente registrado con éxito!" />
                        <asp:Label ID="lblError" runat="server" ForeColor="Green" Visible="False" Text="" />
                        <asp:Button ID="btnParticipar" CssClass="btn btn-primary" runat="server" Text="Aceptar" OnClick="btnParticipar_OnClick" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>