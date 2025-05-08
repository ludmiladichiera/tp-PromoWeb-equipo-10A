<%@ Page Title="PromoVoucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromoVoucher.aspx.cs" Inherits="TpPromoWeb_equipo_10A.PromoVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>

      
    <div class="container">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <h2>Canjea tu Voucher</h2>

                <!-- Etiqueta para la caja de texto -->
                <asp:Label ID="lblCodigoVoucher" runat="server" Text="Ingresa tu código de voucher:" CssClass="form-label"></asp:Label>
                
                <!-- Caja de texto para ingresar código  pruebasss-->
                <asp:TextBox ID="txtCodigoVoucher" runat="server" CssClass="form-control" Placeholder="xxxxxx"></asp:TextBox>
                
                <!-- Botón para enviar el código -->
                <asp:Button ID="btnCanjear" runat="server" Text="Siguiente" CssClass="btn btn-secondary mt-3" OnClick="btnCanjear_Click" />

                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>


            </div>
        </div>
    </div>


    </main>

</asp:Content>