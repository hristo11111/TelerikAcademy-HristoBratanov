<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="UK.aspx.cs" Inherits="BusinessCompany.UK" %>

<asp:Content ID="ContentUK" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Our offices in UK</h2>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>
