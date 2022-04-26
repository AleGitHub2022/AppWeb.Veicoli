<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplicaNoleggio.aspx.cs" Inherits="AppWeb.Veicoli.ApplicaNoleggio" %>

<%@ Register Src="~/Controls/IsNoleggiatoControl.ascx" TagPrefix="ucS" TagName="Nolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <ucS:Nolo runat="server" ID="IsNoleggiatoControl"/>
</asp:Content>
