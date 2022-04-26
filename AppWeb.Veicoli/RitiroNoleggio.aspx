<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RitiroNoleggio.aspx.cs" Inherits="AppWeb.Veicoli.RitiroNoleggio" %>

<%@ Register Src="~/Controls/RimuoviNoleggioControl.ascx" TagPrefix="ucR" TagName="Nolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <ucR:Nolo runat="server" ID="RemoveNoleggio"/>
</asp:Content>
