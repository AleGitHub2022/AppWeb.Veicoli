<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaVeicoliNoleggiati.aspx.cs" Inherits="AppWeb.Veicoli.ListaVeicoliNoleggiati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-heading" id="head">
        <h3 class="panel-title">Veicoli Noleggiati</h3>
    </div>

    <asp:GridView runat="server" ID="gvVeicoli" CssClass="table table" BorderStyle="None" AutoGenerateColumns="False" AutoGenerateSelectButton="false">
        <Columns>



            
            <asp:BoundField DataField="Marca" HeaderText=" Marca">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText=" Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Targa" HeaderText="Targa">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:BoundField DataField="Alimentazione" HeaderText=" Alimentazione">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Immatricolazione" HeaderText="Immatricolazione" DataFormatString="{0:d}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="Nominativo" HeaderText="Nominativo Cliente">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <style>
        h3 {
            
            font-family: Stencil;
            font-size: xx-large;
            font-stretch: expanded;
            color: black;
            text-align: center;
        }

        #head {
            margin-top:200px;
            background-color: lightgray;
        }

        body {
            background-image: url(image/volante.jpg);
            background-size: cover;
            background-repeat: no-repeat;
        }

        .table {
            background-color: lightgray;
            font-family: Stencil;
            border-style: solid;
            font-size: small;
            font-weight: normal;
            text-align: center;
        }
        .table th,td
        {
            text-align:center !important;
        }
        hr {
            visibility: hidden;
        }

        footer {
            color: aliceblue;
            font-size: large;
            font-weight: bold;
        }
    </style>
</asp:Content>
