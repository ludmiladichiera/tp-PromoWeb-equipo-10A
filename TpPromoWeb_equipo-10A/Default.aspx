<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpPromoWeb_equipo_10A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 style="color:darkviolet; text-align:center; font-size:50px"  id="aspnetTitle">!!!Bienvenido a la Promo Ganá PRUEBA¡¡¡</h1>
            <p class="lead" style="text-align:center">Te guiaremos con simples pasos para que puedas participar</p>
            <hr />
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 style="color:cornflowerblue" id="gettingStartedTitle">Carga tu voucher</h2>
                <p>
                    Por haber realizado una compra en nuestro establecimiento se te otorgo un código
                    único para canjearlo por un premio especial.
                    Recorda que este código podes utilizarlo una sola vez, luego de utlizarlo ya deja
                    de ser válido.
                </p>
                <p>
                    <a class="btn btn-primary btn-md" runat="server" href="~/PromoVoucher.aspx">Carga tu voucher &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 style="color:cornflowerblue" id="librariesTitle">Seleciona tu premio</h2>
                <p>
                    Una vez cargado tu voucher podes selecionar un premio.
                    Tenes una variedad de articulos fantásticos para elegir.                    
                </p>
                <p>
                    <a class="btn btn-primary btn-md" runat="server" href="~/Articulos.aspx">Ver premios disponibles &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 style="color:cornflowerblue" id="hostingTitle">Registrate</h2>
                <p>
                    Una vez elegido tu fantástico premio se te pedira tus datos
                    para ver si estas registrado en nuestra página, de no estarlo
                    se te pediran datos para poder registrarte.
                </p>
                <p>
                    <a class="btn btn-primary btn-md" runat="server" href="~/Registrarse.aspx">Registrate &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
