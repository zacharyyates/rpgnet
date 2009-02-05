<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="YatesMorrison.Entropy.Web.Views.Combat.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div>Zach: <%= ViewData.Model.Initiator.GetAspectByAbbreviation("CHP").Total %></div>
	<div>Karl: <%= ViewData.Model.Target.GetAspectByAbbreviation("CHP").Total %></div>
</asp:Content>
