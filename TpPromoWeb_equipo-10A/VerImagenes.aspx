<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerImagenes.aspx.cs" Inherits="TpPromoWeb_equipo_10A.VerImagenes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ver Imágenes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .imagen-preview {
            max-width: 100%;
            height: auto;
            object-fit: contain; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
    </div>
    </form>
</body>
</html>