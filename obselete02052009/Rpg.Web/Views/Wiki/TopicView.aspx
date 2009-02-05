<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="TopicView.aspx.cs" Inherits="Rpg.Web.Views.Wiki.TopicView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1><%= ViewData.Model.Name %></h1>
	<div><%= ViewData.Model.Content %></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
