<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TpPromoWeb_equipo_10A.Articulos" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: contain;
        }
    </style>

    <div class="container mt-5">
        <h2>Lista de Artículos</h2>
        <div class="row">
            <asp:Repeater ID="repArticulos" runat="server">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img class="card-img-top" src='<%# ObtenerUrlImagen(Container.DataItem) %>' alt="Imagen Artículo" />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><strong>Marca:</strong> <%# Eval("Marca") %></p>
                                <p class="card-text"><strong>Categoría:</strong> <%# Eval("Categoria") %></p>
                                <p class="card-text"><strong>Descripción:</strong> <%# Eval("Descripcion") %></p>
                                <asp:HyperLink ID="hlVerImagenes" runat="server" NavigateUrl='<%# "VerImagenes.aspx?id=" + Eval("Id") %>' CssClass="btn btn-primary">Ver Imágenes</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <div class="mt-4 pl-5">
            <label for="ddlArticulo">Seleccionar premio:</label>
            <asp:DropDownList ID="ddlArticulos" runat="server" CssClass="form-control w-25"></asp:DropDownList>

            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary mt-3 mb-5" OnClick="btnAceptar_Click" />
        </div>
    </div>
</asp:Content>