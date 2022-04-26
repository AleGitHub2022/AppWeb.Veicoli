<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AppWeb.Veicoli.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass ="form-control">
                </asp:TextBox>
            </div>          
   <img src="image/index.jpg"/>
    
    <style>
        body
        {
           background-color:darkred;
           background-image:url('images/bg.jpg');
        }
    </style>
        
</asp:content>

