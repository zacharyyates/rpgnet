<%@ Page Title="Entropy - Character" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="YatesMorrison.Entropy.Web.Views.Character.Index" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	
	<style type="text/css">
		th
		{
			text-align:left;
		}
		
		.Score
		{
			font-family: Gothic821 Cn BT, Tahoma;
			font-size:1.5em;
			text-align:center;
		}
		.Total
		{ 
			font-weight:bold;
			font-size:2em;
			color:#5c87b2;
		}
		.BigHeader
		{
			font-size:1.5em;
		}
		.SmallHeader
		{
			font-size:1.5em;
			width:50px;
			text-align:center;
		}
		.Attribute
		{
			font-size:1.5em;
			width:250px;
		}
	</style>
	
	<div style="width:100%;">
		<div class="BigHeader">Name</div>
		<div></div>
	</div>
	<div style="width:100%;">
		<div class="BigHeader">Player</div>
		<div></div>
	</div>
	<div style="width:50%; float:left;">
		<div id="Attributes">
			<table>
				<tr>
					<th class="BigHeader">Primary</th>
					<th class="SmallHeader">Base</th>
					<th class="SmallHeader">Mod</th>
					<th class="SmallHeader">Total</th>
				</tr>
				
				<% foreach (var primary in ViewData.Model.Primary) { %>
				
				<tr>
					<td class="Attribute"><%= primary.Name %></td>
					<td class="Score"><%= primary.Normal %></td>
					<td class="Score"><%= primary.ModifierTotal %></td>
					<td class="Score Total"><%= primary.Total %></td>
				</tr>
				
				<% } %>
			</table>
		</div>
		<div id="Derived">
			<table>
				<tr>
					<th class="BigHeader">Derived</th>
					<th class="SmallHeader">Base</th>
					<th class="SmallHeader">Mod</th>
					<th class="SmallHeader">Total</th>
				</tr>
				
				<% foreach (var derived in ViewData.Model.Derived) { %>
				
				<tr>
					<td class="Attribute"><%= derived.Name %></td>
					<td class="Score"><%= derived.Normal %></td>
					<td class="Score"><%= derived.ModifierTotal %></td>
					<td class="Score Total"><%= derived.Total %></td>
				</tr>
				
				<% } %>
			</table>
		</div>
	</div>
	<div style="width:50%; float:left;">
		<div id="Skills">
			<table>
				<tr>
					<th class="BigHeader">Skills</th>
					<th class="SmallHeader">KP</th>
					<th class="SmallHeader">Base</th>
					<th class="SmallHeader">SP</th>
					<th class="SmallHeader">Total</th>
				</tr>
				
				<% foreach (var ka in ViewData.Model.KnowledgeAreas) { %>
				
				<tr>
					<td class="Attribute" style="font-weight:bold;"><%= ka.Name %></td>
					<td class="Score"><%= ka.Total %></td>
					<td class="Score"></td>
					<td class="Score"></td>
					<td class="Score Total"><%= ka.Total %></td>
				</tr>
				
					<% foreach (var skill in ka.Derived) { %>
					
					<tr style="background-color:#efefef;">
						<td class="Attribute"><%= skill.Name %></td>
						<td class="Score"><%= skill.Attribute.Total %></td>
						<td class="Score"><%= skill.Base %></td>
						<td class="Score"><%= skill.AdvanceTotal %></td>
						<td class="Score Total"><%= skill.Total %></td>
					</tr>
					
					<% } %>
				
				<% } %>
			</table>
		</div>
	</div>
</asp:Content>