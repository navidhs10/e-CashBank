<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 id="titulo" runat="server">e-Cash Bank</h1>
        <p class="lead">"ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript."
            <asp:Label ID="prueba" runat="server">Texto de prueba</asp:Label> <br />
        </p>
        <p class="lead">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar Datos de MySQL" />
        </p>
        <p><a href="#" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Posible imagen</h2>
            <p>
                "ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access".
            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Posible imagen</h2>
            <p>
                "NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects".
            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Posible imagen</h2>
            <p>
                "You can easily find a web hosting company that offers the right mix of features and price for your applications".
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
