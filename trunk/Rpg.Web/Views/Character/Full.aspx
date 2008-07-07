<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Full.aspx.cs" Inherits="Rpg.Web.Views.Character.Full" %>

<%@ Import Namespace="YatesMorrison.Rpg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<table cellspacing="0" border="0" style="width: 100%;">
		<tr>
			<td style="font-size: 2em;">
				<%= Character.GivenName %>
			</td>
			<td style="font-size: 3.25em; text-align: right;" rowspan="2">
				<%= Character.CharacterClass %>
			</td>
			<td style="font-size: 3.25em; text-align: right;" rowspan="2">
				<img src="/Content/Images/GreenCircle<%= Character.CharacterLevel %>.png" alt="<%= Character.CharacterLevel %>" />
			</td>
		</tr>
		<tr>
			<td style="font-size: 1.25em;">
				<%= Character.Surname %>
			</td>
		</tr>
	</table>
	<table cellspacing="0" class="abilities" style="width: 33%;">
		<tr style="font-size: .75em;">
			<td>Score</td>
			<td>Ability</td>
			<td>Abil Mod</td>
			<td colspan="2">Mod + 1/2 Lvl</td>
		</tr>
	<% foreach (var ability in Character.AbilityScoreNames) { %>
		<tr>
			<td class="value">
				<%= Character.GetSimpleScoreFor(ability.Key)%>
			</td>
			<td class="text">
				<div style="font-size: 1em; font-weight: bold;"><%= ability.Key %></div>
				<div style="font-size: .55em;"><%= ability.Value %></div>
			</td>
			<td class="value">
				<%= Character.GetSimpleScoreFor(ability.Key + "Mod")%>
			</td>
			<td class="value">
				<%= Character.GetSimpleScoreFor(ability.Key + "Mod+1/2Lvl") %>
			</td>
			<td></td>
		</tr>
	<% } %>
	</table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>