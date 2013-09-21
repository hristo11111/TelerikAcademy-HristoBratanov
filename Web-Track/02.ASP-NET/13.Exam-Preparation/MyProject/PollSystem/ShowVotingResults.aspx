<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ShowVotingResults.aspx.cs" Inherits="PollSystem.ShowVotingResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Voting Results</h1>
    <h2>Questions: 
        <asp:Literal ID="LiteralQuestion" 
            runat="server"
            Mode="Encode">
        </asp:Literal>
    </h2>
    <ul>
        <asp:Repeater ID="RepeaterAnsweers" runat="server" ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %> --> <%# Item.Votes %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
