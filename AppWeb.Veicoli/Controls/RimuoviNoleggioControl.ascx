<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RimuoviNoleggioControl.ascx.cs" Inherits="AppWeb.Veicoli.Controls.RimuoviNoleggioControl" %>
<div class="panel panel-default" id="default">
    <div class="panel-heading" id="head">
        <h3 class="panel-title">Consegna veicolo</h3>
    </div>
    <div class="panel-body">
        <label for="Veicolo">Informazioni Veicolo</label>
    </div>
    <div class="form-group">
        <label for="Marca">Marca</label>
        <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group">
        <label for="Modello">Modello</label>
        <asp:TextBox runat="server" ID="txtModello" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group">
        <label for="Targa">Targa</label>
        <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div>
        <label for="Cliente">Anagrafica Cliente</label>
    </div>
    <br>
    <div class="form-group" style="float: left">
        <label for="Nome">Nome</label>
        <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>

    <div class="form-group" style="float: left; margin-left: 50px">
        <label for="Cognome">Cognome</label>
        <asp:TextBox runat="server" ID="txtCognome" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group" style="clear: left;">
    </div>
    <div class="form-group" style="float: left">
        <label for="txtDataNascita">Data Di Nascita</label>
        <asp:TextBox runat="server" ID="txtDataNascita" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group" style="clear: left;">
    </div>
    <div class="form-group" style="float: left">
        <label for="txtComune">Comune Di Residenza</label>
        <asp:TextBox runat="server" ID="txtComune" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group" style="float: left; margin-left: 50px">
        <label for="txtProvincia">Provincia</label>
        <asp:TextBox runat="server" ID="txtProvincia" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group" style="float: left; margin-left: 50px">
        <label for="Residenza">Residenza via/piazza</label>
        <asp:TextBox runat="server" ID="txtResidenza" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>
    <div class="form-group" style="clear: left;">
    </div>


    <div class="form-group">
        <label for="txtTelefono">Numero di telefono</label>
        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" ReadOnly="true">
        </asp:TextBox>
    </div>

    <asp:Button runat="server" ID="btnTermina" Text="Termina Noleggio" Class="button button" OnClick="btnTermina_Click" />

</div>
<style>
        h3 {
            font-family: Stencil;
            font-size: xx-large;
            font-stretch: expanded;
            color: black;
            text-align: center;
        }

        #head {
            background-color: lightgray;
        }

        #default {
            width: fit-content;
            padding:10px;
            background-color: white;
            color: black;
        }

        body {
            background-image: url(image/volante.jpg);
            background-size: cover;
            background-repeat: no-repeat;
        }

        input[type=text] {
            background-color: white;
            border-color: black;
            font-family: 'Arial Rounded MT';
            font-weight: bold;
            font-size: small;
            font-stretch: extra-expanded;
            color: black;
        }

            input[type=text]:focus {
                background-color: lightgray;
                color: black;
                border: 3px solid black;
                font-family: 'Arial Rounded MT';
                font-weight: bold;
                font-size: small;
                font-stretch: extra-expanded;
            }

        select {
            background-color: white;
            border-color: black;
            font-family: 'Arial Rounded MT';
            font-weight: bold;
            font-size: small;
            font-stretch: extra-expanded;
            color: black;
        }

            select:focus {
                user-select: text;
                background-color: lightgray;
                color: black;
                border: 3px solid black;
                font-family: 'Arial Rounded MT';
                font-weight: bold;
                font-size: small;
                font-stretch: extra-expanded;
            }

        .button {
            font-family: Stencil;
            border-radius: 4px;
            background-color: darkred;
            border: none;
            color: black;
            text-align: center;
            font-size: small;
            font-weight:normal;
            padding: 10px;
            width: 150px;
            transition: all 0.5s;
            cursor: pointer;
            margin: 10px;
        }

            .button:hover {
                background-color:indianred
            }

            .button:active {
                background-color: indianred;
                box-shadow: 0 5px #666;
                transform: translateY(4px);
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