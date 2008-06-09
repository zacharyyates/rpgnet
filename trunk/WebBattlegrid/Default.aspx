<%@ Page Language="C#" 
	MasterPageFile="~/Include/Site.Master" 
	AutoEventWireup="true" 
	CodeBehind="Default.aspx.cs" 
	Inherits="WebBattlegrid.Default" 
	Title="Web Battlegrid" %>
<%@ Register TagPrefix="WebBattlegrid" TagName="Grid" Src="~/Controls/DMView.ascx" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="server">
	<link href="/Include/BattleGrid.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="cntMain" ContentPlaceHolderID="cphMain" runat="server">
	<WebBattlegrid:Grid runat="server" ID="bgMain" />
</asp:Content>