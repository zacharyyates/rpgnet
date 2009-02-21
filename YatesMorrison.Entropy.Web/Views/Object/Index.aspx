<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="YatesMorrison.Entropy.Web.Views.Object.Index" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <%	var mgr = MvcApplication.GetScaffoldingManager(ViewData.Model.GetType());
		var view = mgr.GetEntityView();
		var renderer = new YatesMorrison.Web.Mvc.MvcRenderingManager(view, Html);
		renderer.Render();
    	%>
</asp:Content>