<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpPromoWeb_equipo_10A.Registrarse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Si usted no esta registrado, complete estos campos</h3>
        <p>Una vez finalizado el proceso de registro, podra seguir con la promo</p>
    </main>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false" />

    <div class="container">
       
        <div class="row mb-3">
            <div class="col-md-12">
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Visible="false" />
            </div>
        </div>

        
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtDocumento" class="form-label">DNI</label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" />
            </div>
        </div>

        
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>
        </div>

       
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
        </div>

        
        <div class="row mb-3">
            <div class="col-md-12">
                <asp:CheckBox ID="chkTerminos" runat="server" Text="Acepto términos y condiciones" />
            </div>
        </div>

       
        <div class="row mb-3">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>
        </div>

    </div>
</asp:Content>