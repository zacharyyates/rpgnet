<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Dnd4Classic.aspx.cs" Inherits="Rpg.Web.Views.Character.Dnd4Classic" %>
<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
	<link href="Content/Character.css" rel="Stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<div style="width:100%;">
		<!-- Name / Level -->
		<div class="section">
			<table cellspacing="0" border="0" style="width: 100%;">
				<tr>
					<td style="font-size: 2em;">
						<%= Character.GivenName %>
					</td>
					<td style="font-size: 3.25em; text-align: right;" rowspan="2">
						<%= Character.CharacterClass %>
					</td>
					<td style="font-size: 3.25em; text-align: right;" rowspan="2">
						<%= Character.CharacterLevel %>
					</td>
				</tr>
				<tr>
					<td style="font-size: 1.25em;">
						<%= Character.Surname %>
					</td>
					<td></td>
				</tr>
			</table>
			<span><%= Character.Experience %></span>
		</div>
		<!-- Misc -->
		<div class="section">
			<span><%= Character.Race %></span>
			<span><%= Character.SizeCategory %></span>
			<span><%= Character.Age %></span>
			<span><%= Character.Gender %></span>
			<span><%= Character.Height %></span>
			<span><%= Character.Weight %></span>
			<span><%= Character.Alignment %></span>
		</div>
	</div>
	<div>
		<div class="column" style="width:32%;">
			<!-- Initiative -->
			<div class="section">
				<h1>Initiative</h1>
				<table class="stats">
					<tr>
						<th class="value">Score</th>
						<th></th>
						<th class="value">Dex</th>
						<th class="value">1/2 Level</th>
						<th class="value">Misc</th>
					</tr>
					<tr>
						<td class="value" style="font-size: 1.5em;"><%= Character.GetEffectedScoreFor("Init") %></td>
						<td>Initiative</td>
						<td class="value"><%= Character.GetEffectedScoreFor("DexMod") %></td>
						<td class="value"><%= Character.CharacterLevel / 2 %></td>
						<td class="value"><%= Character.GetEffectModifierTotalFor("Init") %></td>
					</tr>
				</table>
			</div>
			<!-- Abilities -->
			<div class="section">
				<h1>Ability Scores</h1>
				<table cellspacing="0" class="stats abilities" style="width: 100%;">
					<tr>
						<th>Score</th>
						<th>Ability</th>
						<th>Abil Mod</th>
						<th>Mod + 1/2 Lvl</th>
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
					</tr>
				<% } %>
				</table>
			</div>
			<!-- HP -->
			<div class="section">
				<h1>Hit Points</h1>
				<table class="stats">
					<tr>
						<th class="value" style="font-size: 1em; font-weight: bold;">Max HP</th>
						<th class="value">Bloodied</th>
						<th class="value">Surge Value</th>
						<th class="value">Surges/Day</th>
					</tr>
					<tr>
						<td class="value" style="font-size: 1.5em;"><%= Character.GetEffectedScoreFor("HP") %></td>
						<td class="value"><%= Character.GetEffectedScoreFor("BV") %></td>
						<td class="value"><%= Character.GetEffectedScoreFor("SV") %></td>
						<td class="value"><%= Character.GetEffectedScoreFor("HS") %></td>
					</tr>
				</table>
			</div>
			<!-- Skills -->
			<div class="section">
				<h1>Skills</h1>
				<table class="stats">
					<tr>
						<th class="value">Bonus</th>
						<th class="text">Skill Name</th>
						<th></th>
						<th class="value">Mod+1/2Lvl</th>
						<th class="value">Trnd (+5)</th>
						<th class="value">Armor Penalty</th>
						<th class="value">Misc</th>
					</tr>
				<%	int counter = 1;
					foreach (var skill in Character.SkillNames) { %>
					<tr class="<%= (counter % 2 == 0) ? "even" : "odd" %>">
						<td class="value"><%= Character.GetEffectedScoreFor(skill) %></td>
						<td class="text"><%= skill %></td>
						<td></td>
						<td class="value"></td>
						<td class="value"></td>
						<td class="value"></td>
						<td class="value"></td>
					</tr>
				<% counter++; } %>
				</table>
			</div>
		</div>
		<div class="column" style="width:32%;">
			<!-- Defenses -->
			<div class="section">
				<h1>Defenses</h1>
				<table class="stats abilities">
					<tr>
						<th class="value">Score</th>
						<th></th>
						<th class="value">10 + 1/2 Lvl</th>
						<th class="value">Armor</th>
						<th class="value">Abil Mod</th>
						<th class="value">Class</th>
						<th class="value">Feat</th>
						<th class="value">Enh</th>
						<th class="value">Misc</th>
					</tr>
				<% foreach (var defense in Character.Defenses) { %>
					<tr>
						<td class="value" style="font-size: 1.5em;"><%= Character.GetEffectedScoreFor(defense.Key) %></td>
						<td class="text"><%= defense.Key %></td>
						<td class="value"><%= Character.CharacterLevel / 2 + 10 %></td>
						<td class="value"></td>
						<td class="value"></td>
						<td class="value"></td>
						<td class="value"></td>
						<td class="value"></td>
						<td class="value"></td>
					</tr>
				<% } %>
				</table>
			</div>
		</div>
	</div>
</asp:Content>

<asp:Content ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>