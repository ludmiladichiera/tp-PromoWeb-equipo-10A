<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TpPromoWeb_equipo_10A.Articulos" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Lista de Artículos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: contain;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                                <img class="card-img-top" src='<%# ObtenerUrlImagen(Container.DataItem) %>' alt="Imagen Artículo">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><strong>Marca:</strong> <%# Eval("Marca") %></p>
                                    <p class="card-text"><strong>Categoría:</strong> <%# Eval("Categoria") %></p>
                                    <p class="card-text"><strong>Descripción:</strong> <%# Eval("Descripcion") %></p>
                                    <asp:HyperLink ID="hlVerImagenes" runat="server" NavigateUrl='<%# "VerImagenes.aspx?id=" + Eval("Id") %>' class="btn btn-primary">Ver Imágenes</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div style="padding-left:120px" class="mt-4">
                <label for="ddlArticulo">Seleccionar premio:</label>
                <asp:DropDownList ID="ddlArticulos" runat="server" CssClass="form-control w-25"></asp:DropDownList>

                <asp:Button style="margin-block-end:30px" ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary mt-3" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>