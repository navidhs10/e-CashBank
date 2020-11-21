<%@ Page Language="C#" Title="Perfil" MasterPageFile="~/Site.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" Async="true" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    
    <div class="row" runat="server" visible="false">
        <div class="col-md-4" >
            <img  style="width : 100%; height: 100%" src="Images/ll.png"/>
        </div>
        <div class="col-md-4" id="solicitudes" >
            <h3 style="background-color:#428bca; width:100%; border-radius:6px 6px 0px 0px; margin-top:0px; color:white">Solicitudes</h3>
            
        </div>
    </div>

    
    <div class="row" style=" padding-left:20%; padding-right:10%; margin-top:4%">
        <div id="btnDeposito" class="col-md-4" style="background-color:#428bca; padding: 0px; border-radius:6px 6px 0px 0px;">
                <asp:ImageButton ImageUrl="~/Images/Tarjeta1.png" runat="server" style="width:100%; height:78%; padding-top:10%; padding-left:1%; padding-right:15%; padding-bottom:5%;"  />
                <asp:button class="btn btn-primary btn-lg" style="border-radius:0px; margin-right:5%; width:100%;" runat="server" Text="Deposito" />
        </div>
         
        <div id="btnRetiro" class="col-md-4" style="margin-left:10%; background-color: #428bca; padding:0px; border-radius:6px 6px 0px 0px;">                
                <asp:ImageButton ImageUrl="~/Images/Tarjeta1.png" runat="server" style="width:100%; height:78%; padding-top:10%; padding-left:1%; padding-right:15%; padding-bottom:5%;"  />
                <asp:button class="btn btn-primary btn-lg" style="border-radius:0px; width:100%;" runat="server" Text="Retiro" />
        </div>
    </div>
    
    <div  class="jumbotron" runat="server" visible="true">        
        <div id="Old" style="background-color:black">
            <h2 id="tituloInfo" runat="server" >Deposito</h2>              
                   
                   <div style="background-color:green;">
                       <label id="enunciado" runat="server">Monto a depositar: </label>
                       <asp:TextBox runat="server" ID="T1" Visible="true" CssClass="form-control" />  
                       <asp:button class="btn btn-primary btn-lg" runat="server" Text="Depositar" />

                   </div> 
             <br />
        </div>
    </div>
    
    
</asp:Content>
