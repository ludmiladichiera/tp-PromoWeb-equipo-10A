<%@ Page Title="PromoVoucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromoVoucher.aspx.cs" Inherits="TpPromoWeb_equipo_10A.PromoVoucher" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Ingrese el codigo de su voucher:</h3>
    </main>
    <div class="container">
    <div class="row mb-3">
        <div class="col-md-12">
            <label for="txtApellido" class="form-label">Voucher:</label>
            <asp:TextBox ID="txtvoucher" runat="server" CssClass="form-control" placeholder="xxxxxxxxxxxxxxxxx"/>
        </div>
    </div>
    <div class="row mb-3 mt-3">
        <div class="col-md-12">
            <asp:Button ID="btnsiguiente" runat="server" Text="siguiente" CssClass="btn btn-primary"  /> <!-- aca falta el evento onclick:  OnClick="btnsiguiente_Click"-->
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>


        </div>
    </div>
</div>
</asp:Content>
