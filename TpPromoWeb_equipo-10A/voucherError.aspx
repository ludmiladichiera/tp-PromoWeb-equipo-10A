<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="voucherError.aspx.cs" Inherits="TpPromoWeb_equipo_10A.voucherError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center py-5">
        <img src="https://media.tenor.com/W-ECGp040xQAAAAM/the-bee-movie-bee-movie.gif" alt="" class="img-fluid mb-4" style="max-width: 200px;" />
        
        <h1 class="display-4 fw-bold">OOPS! ERROR EN EL VOUCHER.</h1>
        
        <p class="lead text-muted my-3">
            El voucher ya fue usado o no existe 😥.
        </p>

        <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al inicio" CssClass="btn btn-primary mt-3" OnClick="btnVolverInicio_click" />
    </div>
</asp:Content>
