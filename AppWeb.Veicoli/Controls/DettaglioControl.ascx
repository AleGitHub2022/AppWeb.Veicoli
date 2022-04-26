<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DettaglioControl.ascx.cs" Inherits="AppWeb.Veicoli.Controls.DettaglioControl" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>
<%@ Register Src="~/Controls/IsNoleggiatoControl.ascx" TagPrefix="ucS" TagName="Nolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



      <uc1:Info runat="server" ID="InfoControl" />

     <div class="panel panel-default">
        <div class="panel-heading">
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
                <asp:TextBox runat="server" ID="txtData" CssClass ="form-control"  ReadOnly="true">
                </asp:TextBox>
            </div>
             <asp:ImageButton ID="ImageButtonCalendar" runat="server" 
			ImageUrl="~/image/index.jpg" 
			OnClick="ImageButtonCalendar_Click"  Height="30" Width="50" ImageAlign="Left"  />
             <asp:calendar ID= "Calendar" runat = "server" OnSelectionChanged  ="Calendar_SelectionChanged" Visible="false" WeekendDayStyle-BackColor="#FF1717" TodayDayStyle-BackColor="#999999" SelectorStyle-BackColor="#333333" BorderStyle="Solid" BorderColor="#333333" DayStyle-BorderStyle="Ridge" DayStyle-BorderColor="#333333" TitleStyle-BackColor="#FF3E3E" OtherMonthDayStyle-Wrap="True" OtherMonthDayStyle-HorizontalAlign="Left" OtherMonthDayStyle-BackColor="#0033CC">
                 
            </asp:calendar>
            <br>
            <br>

            <div class="form-group">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass ="form-control">
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
            <div class="form-group"style="float:left;margin-left:50px;margin-top:25px"; >
                 <asp:Button runat="server" ID="BtnNoleggio" Text="Gestione Noleggio" CssClass="btn btn-default" OnClick="BtnNoleggio_Click" visible="true"/>
          </div>
              <div class="form-group"style="clear:left;" >
                  </div>
                <div class="form-group"style="float:left;">  
                 <asp:Button runat="server" ID="Indietro" Text="Precedente" CssClass="btn btn-default" OnClick="Indietro_Click" visible="true"/>
             <asp:Button runat="server" ID="Avanti" Text="Successivo" CssClass="btn btn-default" OnClick="Avanti_Click" visible="true"/>
                 </div>
                    <div class="form-group"style="float:left;margin-left:50px";>  
                 <asp:Button runat="server" ID="Modifica" Text="Salva Modifiche" CssClass="btn btn-default" OnClick="Modifica_Click" visible="true"/>
             <asp:Button runat="server" ID="Elimina" Text="Elimina Veicolo" CssClass="btn btn-default" OnClick="Elimina_Click" visible="true"/>
                 </div>
            </div>
        </div>

       
</asp:Content>
