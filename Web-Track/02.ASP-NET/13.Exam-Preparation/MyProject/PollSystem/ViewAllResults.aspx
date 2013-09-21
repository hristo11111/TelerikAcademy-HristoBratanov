<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ViewAllResults.aspx.cs" 
    Inherits="PollSystem.ViewAllResults" %>
<asp:Content ID="ContentViewAllResults" 
    ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView AutoGenerateColumns="false" ID="GridView" 
        runat="server">
        <Columns>
            <asp:BoundField DataField="QuestionText" HeaderText="Question" />
            <asp:HyperLinkField DataNavigateUrlFields="QuestionId" 
                DataNavigateUrlFormatString="ShowVotingResults?questionId={0}"
                Text="Edit" />

        </Columns>
    </asp:GridView>
</asp:Content>
