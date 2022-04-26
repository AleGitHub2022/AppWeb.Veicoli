<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciVeicolo.aspx.cs" Inherits="AppWeb.Veicoli.InserisciVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="InfoControl" />

    <div class="panel panel-default" id="default">
        <div class="panel-heading" id="head">
            <h3 class="panel-title">Inserisci Veicolo</h3>
        </div>
        <div class="panel-body">

            <div class="form-group">
                <label>Marca</label>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="DropDownMarca" runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control">
                </asp:TextBox>
            </div>

            <div class="form-group">
                <label>Alimentazione</label>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="DropDownAlimentazione" runat="server">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="txtData">Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtData" CssClass="form-control" Height="25" ReadOnly="false" Width="170" ></asp:TextBox>

                <asp:ImageButton ID="ImageButtonCalendar" runat="server"
                    ImageUrl="~/image/index.jpg"
                    OnClick="ImageButtonCalendar_Click" Height="30" Width="50" ImageAlign="Left" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="ImageButtonClear" runat="server"
                ImageUrl="~/image/delete.png"
                OnClick="ImageButtonClear_Click" Height="19" Width="19" ImageAlign="NotSet" />
            </div>
            <asp:Calendar ID="Calendar" runat="server" OnSelectionChanged="Calendar_SelectionChanged" Visible="false" WeekendDayStyle-BackColor="#FF5959" TodayDayStyle-BackColor="#9393FF" TitleStyle-BackColor="#A2A2A2" SelectedDayStyle-BackColor="Gray" OtherMonthDayStyle-BackColor="#82FF82"></asp:Calendar>

            <div class="form-group">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control">
                </asp:TextBox>
            </div>



            <asp:Button runat="server" Text="Inserisci" Class="button" Style="vertical-align: middle" OnClick="btnInserisci_Click" />


        </div>
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
            background-color: forestgreen;
            border: none;
            color: black;
            text-align: center;
            font-size: medium;
            font-weight:normal;
            padding: 10px;
            width: 100px;
            transition: all 0.5s;
            cursor: pointer;
            margin: 5px;
        }

            .button:hover {
                background-color:darkgreen
            }

            .button:active {
                background-color: darkgreen;
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
</asp:Content>
