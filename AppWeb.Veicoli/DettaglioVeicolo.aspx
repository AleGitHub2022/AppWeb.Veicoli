<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioVeicolo.aspx.cs" Inherits="AppWeb.Veicoli.DettaglioVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>
<%@ Register Src="~/Controls/IsNoleggiatoControl.ascx" TagPrefix="ucS" TagName="Nolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



      <uc1:Info runat="server" ID="InfoControl" />

     <div class="panel panel-default" id="default">
        <div class="panel-heading" id="head">
            <h3 class="panel-title">Dettaglio Veicolo</h3>
        </div>
        <div class="panel-body">

            
              <div class="form-group"style="float:left">
                <label for="txtMarca">Marca</label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass ="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
            <br>
            
            <div class="form-group"  style="float:left; margin-left: 9px;margin-top:10px" >
                <asp:DropDownList ID="DropDownMarca" runat="server"  OnTextChanged="DropDownMarca_TextChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>

             <div class="form-group"style="clear:left">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass ="form-control">
                </asp:TextBox>
            </div>
            
            <div class="form-group"style="float:left">
                <label for="txtAlimentazione">Alimentazione</label>
                <asp:TextBox runat="server" ID="txtAlimentazione" CssClass ="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
            <br>
            
            <div class="form-group" style="float:left; margin-left: 9px;margin-top:10px" >
                <asp:DropDownList ID="DropDownAlimentazione" runat="server"  OnTextChanged="DropDownAlimentazione_TextChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
             <div class="form-group"style="clear:left">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass ="form-control">
                </asp:TextBox>
            </div>
             <div class="form-group">
                <label for="txtData">Data Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtData" CssClass ="form-control"  ReadOnly="false">
                </asp:TextBox>
            </div>
             <asp:ImageButton ID="ImageButtonCalendar" runat="server" 
			ImageUrl="~/image/index.jpg" 
			OnClick="ImageButtonCalendar_Click"  Height="30" Width="50" ImageAlign="Left"  />
             <asp:calendar  ID="Calendar" runat="server" OnSelectionChanged="Calendar_SelectionChanged" Visible="false" WeekendDayStyle-BackColor="#FF5959" TodayDayStyle-BackColor="#9393FF" TitleStyle-BackColor="#A2A2A2" SelectedDayStyle-BackColor="Gray" OtherMonthDayStyle-BackColor="#82FF82">
                 
            </asp:calendar>
            <br>
            <br>

            <div class="form-group" id="note">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" TextMode="MultiLine"  ID="txtNote"  CssClass ="form-control" style="height:fit-content,50px;background-color: white;  border-color: black; font-family: 'Arial Rounded MT';  font-weight: bold;  font-size: small; font-stretch: extra-expanded;color: black;  
            text-overflow:ellipsis;" > 
          
                </asp:TextBox>
            </div>
         

             <div class="form-group"style="float:left">
                <label for="txtNoleggio">Stato Noleggio</label>
                <asp:TextBox runat="server" ID="txtNoleggio" CssClass ="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
             <div class="form-group"style="float:left; margin-left: 15px">
                <label for="txtNominativo">Nominativo Cliente</label>
                <asp:TextBox runat="server" ID="txtNominativo" CssClass ="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
            <br>
            <div class="form-group"style="float:left;margin-left:30px"; >
                 <asp:Button runat="server" ID="BtnNoleggio" Text="Gestione Noleggio" Class="button button" OnClick="BtnNoleggio_Click" visible="true"/>
          </div>
              <div class="form-group"style="clear:left;" >
                  </div>
                <div class="form-group"style="float:left;">  
                 <asp:Button runat="server" ID="Indietro" Text="Precedente" Class="button button1" OnClick="Indietro_Click" visible="true"/>
             <asp:Button runat="server" ID="Avanti" Text="Successivo" Class="button button2" OnClick="Avanti_Click" visible="true"/>
                 </div>
                    <div class="form-group"style="float:left;margin-left:50px";>  
                 <asp:Button runat="server" ID="Modifica" Text="Salva Modifiche" Class="button button3" OnClick="Modifica_Click" visible="true"/>
             <asp:Button runat="server" ID="Elimina" Text="Elimina Veicolo" Class="button button4" OnClick="Elimina_Click" visible="true"/>
                 </div>
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
            text-overflow: ellipsis;
            height: fit-content;
            width: fit-content;
        }

            input[type=text]:focus {
                background-color: lightgray;
                color: black;
                border: 3px solid black;
                font-family: 'Arial Rounded MT';
                font-weight: bold;
                font-size: small;
                font-stretch: extra-expanded;
                height: fit-content;
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
            background-color: darkgray;
            border: none;
            color: black;
            text-align: center;
            font-size: small;
            font-weight: normal;
            padding: 10px;
            width: 150px;
            transition: all 0.5s;
            cursor: pointer;
            margin: 10px;
            font-stretch: condensed;
        }

            .button:hover {
                background-color: lightslategray
            }

            .button:active {
                background-color: lightslategray;
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


        .button2 {
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

            .button2:hover {
                background-color: lightslategray
            }

            .button2:active {
                background-color: lightslategray;
                box-shadow: 0 5px #666;
                transform: translateY(4px);
            }

        .button3 {
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

            .button3:hover {
                background-color: darkgreen
            }

            .button3:active {
                background-color: darkgreen;
                box-shadow: 0 5px #666;
                transform: translateY(4px);
            }

        .button4 {
            font-family: Stencil;
            border-radius: 4px;
            background-color: darkred;
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

            .button4:hover {
                background-color: indianred
            }

            .button4:active {
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
</asp:Content>
