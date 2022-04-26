<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AppWeb.Veicoli.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class:"container">
       <div class:"row">
    <div id="testo" class="col-md-8">
        <h1>Società  Noleggio  </h1>
        <br>
        <p>Gestionale per :  </p>
        <br>
        <p>- Parco auto </p>
        <br>
        <p>- Noleggi </p>
        <br>
        <p>- Clienti </p>
    </div>
          
    <div id="divButton" class="col-md-4">
        <p> <asp:Button runat="server" Text="Inserisci Veicolo" Class="button button1" OnClick="Inserisci_Click" Visible="true" /></p>
      <p>   <asp:Button runat="server" ID="ricerca" Text="Ricerca Veicolo" class="button button2" OnClick="ricerca_Click" /></p>
       <p>  <asp:Button runat="server" ID="disponibili" Text=" Veicoli Disponibili" class="button button3" OnClick="disponibili_Click" /></p>
       <p>  <asp:Button runat="server" ID="noleggiati" Text="Veicoli Noleggiati" class="button button4" OnClick="noleggiati_Click" /></p>
    </div>
   </div>
</div>
    <style>
        #testo {
            margin-right: auto;
            margin-left: auto;
            margin-top: 100px;
            font-family: Stencil;
            font-size: 25px;
            font-stretch: extra-expanded;
            color: ghostwhite;
            -webkit-text-stroke-width: 0.9px;
            -webkit-text-stroke-color: black;
            text-align: left;
        }

        #divButton {
           margin-top: 100px;
        }

        .button1 {
            transition-duration: 0.4s;
            background-color: lightgray;
            border: 2px solid black;
            color: black;
            text-align: center;
            font-size: 24px;
            font-family: Stencil;
            padding: 32px 16px;
            border-radius: 50%;
            margin: 4px 2px;
            width:350px;
        }

            .button1:hover {
                border-radius: 50%;
                background-color: black;
                border: 2px solid lightgray;
                color: lightgray;
                text-align: center;
            }

        .button2 {
            transition-duration: 0.4s;
            background-color: lightgray;
            border: 2px solid black;
            color: black;
            text-align: center;
            font-size: 24px;
            font-family: Stencil;
            padding: 32px 16px;
            border-radius: 50%;
            margin: 4px 2px;
             width:350px;
        }

            .button2:hover {
                border-radius: 50%;
                background-color: black;
                border: 2px solid lightgray;
                color: lightgray;
                text-align: center;
            }

        .button3 {
            transition-duration: 0.4s;
            background-color: lightgray;
            border: 2px solid black;
            color: black;
            text-align: center;
            font-size: 24px;
            font-family: Stencil;
            padding: 32px 16px;
            border-radius: 50%;
            margin: 4px 2px;
             width:350px;
        }

            .button3:hover {
                border-radius: 50%;
                background-color: black;
                border: 2px solid lightgray;
                color: lightgray;
                text-align: center;
            }

        .button4 {
            transition-duration: 0.4s;
            background-color: lightgray;
            border: 2px solid black;
            color: black;
            text-align: center;
            font-size: 24px;
            font-family: Stencil;
            padding: 32px 16px;
            border-radius: 50%;
            margin: 4px 2px;
             width:350px;
        }

            .button4:hover {
                border-radius: 50%;
                background-color: black;
                border: 2px solid lightgray;
                color: lightgray;
                text-align: center;
            }

        body {
            background-image: url(image/auto.jpg);
            background-size: cover;
            background-repeat: no-repeat;
        }

        hr {
            visibility: hidden
        }

        footer {
            font-size: large;
            font-weight: bold;
            color: aliceblue;
        }
    </style>

</asp:Content>
