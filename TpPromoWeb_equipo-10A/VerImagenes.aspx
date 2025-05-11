<%@ Page Title="Ver Imágenes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerImagenes.aspx.cs" Inherits="TpPromoWeb_equipo_10A.VerImagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3 class="mb-4">Imágenes del artículo</h3>
        <div class="row">
            <asp:Repeater ID="rptImagenes" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-3">
                        <div class="card">
                            <img src='<%# Eval("ImagenUrl") %>' class="card-img-top imagen-preview" alt="Imagen artículo" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row">
            <div class="col-md-12 text-end">
                <asp:Button ID="btnVolver" CssClass="btn btn-primary" runat="server" Text="Volver" OnClick="btnVolver_OnClick" />
            </div>
        </div>
    </div>

    <style>
        .imagen-preview {
            max-width: 100%;
            height: auto;
            object-fit: contain;
        }
    </style>
</asp:Content>