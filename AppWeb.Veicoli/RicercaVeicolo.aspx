<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaVeicolo.aspx.cs" Inherits="AppWebVeicoli.RicercaVeicolo" %>

<%@ Register Src="Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="InfoControl" />

    <div class="panel panel-default" id="default">
        <div class="panel-heading" id="head">
            <h3 class="panel-title">Ricerca Veicolo</h3>
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



            <div class="form-group" style="float: left; margin-left: 10px">

                <label for="txtData">Immatricolazione Da: </label>

                <asp:TextBox runat="server" ID="txtDataFrom" CssClass="form-control" Height="20" ReadOnly="false" Width="150px"></asp:TextBox>

                <asp:ImageButton ID="ImageButtonCalendar" runat="server" ImageUrl="~/image/index.jpg" OnClick="ImageButtonCalendar_Click" Height="30" Width="50" ImageAlign="Left" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButtonClear" runat="server" ImageUrl="~/image/delete.png" OnClick="ImageButtonClear_Click" Height="19" Width="19" ImageAlign="NotSet" />



                <asp:Calendar ID="CalendarFrom" runat="server" OnSelectionChanged="CalendarFrom_SelectionChanged" Visible="false" WeekendDayStyle-BackColor="#FF5959" TodayDayStyle-BackColor="#9393FF" TitleStyle-BackColor="#A2A2A2" SelectedDayStyle-BackColor="Gray" OtherMonthDayStyle-BackColor="#82FF82"></asp:Calendar>
            </div>


            <div class="form-group" style="float: left; margin-left: 70px">

                <label for="txtData">A : </label>
                <asp:TextBox runat="server" ID="txtDataTo" CssClass="form-control" Height="20" ReadOnly="false" Width="150px"></asp:TextBox>

                <asp:ImageButton ID="CalendarBtn" runat="server" ImageUrl="~/image/index.jpg" OnClick="CalendarBtn_Click" Height="30" Width="50" ImageAlign="Left" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="clearCalendar" runat="server" ImageUrl="~/image/delete.png" OnClick="clearCalendar_Click" Height="19" Width="19" ImageAlign="NotSet" />


                <asp:Calendar ID="CalendarTo" runat="server" OnSelectionChanged="CalendarTo_SelectionChanged1" Visible="false" WeekendDayStyle-BackColor="#FF5959" TodayDayStyle-BackColor="#9393FF" TitleStyle-BackColor="#A2A2A2" SelectedDayStyle-BackColor="Gray" OtherMonthDayStyle-BackColor="#82FF82"></asp:Calendar>
            </div>
        </div>
        <br>
        <div>

            <asp:RadioButton ID="IsNoleggiato" Text="&nbsp Noleggiato" Checked="false" GroupName="options" runat="server" />
            <asp:RadioButton ID="Disponibile" Text="&nbsp  Disponibile" Checked="false" GroupName="options" runat="server" />
        </div>
        <br>


        <br>
        <asp:Button runat="server" ID="btnRicerca" Text="Ricerca Veicolo" Class="button" OnClick="btnRicerca_Click" />
        <asp:Button runat="server" ID="Azzera" Text="Nuova Ricerca" Class="button button1" OnClick="Azzera_Click" />
    </div>
    <asp:GridView runat="server" ID="gvVeicolo" OnRowCommand="gvVeicolo_RowCommand"  HeaderStyle-CssClass="GridHeader header" CssClass="table table" BorderStyle="None" AutoGenerateColumns="False" AutoGenerateSelectButton="false" DataKeyNames="Id">
        <Columns>

            <asp:ButtonField ButtonType="Button" AccessibleHeaderText="Dettaglio" Text="Dettaglio" CommandName="Dettaglio" />

            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false">
                <HeaderStyle HorizontalAlign="Center" />
                
            </asp:BoundField>
            <asp:BoundField DataField="Marca" HeaderText=" Marca" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText=" Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField DataField="Immatricolazione" HeaderText="Immatricolazione" DataFormatString="{0:d}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Noleggiato" HeaderText=" Noleggiato">
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
            font-size: small;
            font-weight: normal;
            padding: 10px;
            width: 130px;
            transition: all 0.5s;
            cursor: pointer;
            margin: 10px;
        }

            .button:hover {
                background-color: darkgreen
            }

            .button:active {
                background-color: darkgreen;
                box-shadow: 0 5px #666;
                transform: translateY(4px);
            }

        .button1 {
            font-family: Stencil;
            border-radius: 4px;
            background-color: darkgray;
            border: none;
            color: black;
            text-align: center;
            font-size: small;
            font-weight: normal;
            padding: 10px;
            width: 130px;
            transition: all 0.5s;
            cursor: pointer;
            margin: 10px;
        }

            .button1:hover {
                background-color: lightslategray
            }

            .button1:active {
                background-color: lightslategray;
                box-shadow: 0 5px #666;
                transform: translateY(4px);
            }

       .table {
            background-color:lightgray;
             font-family: Stencil;
             border-style:solid;
             font-size: small;
            font-weight: normal;
            text-align:center;
            
        }
       .table,th,td
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
