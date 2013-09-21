<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Bulgaria.aspx.cs" Inherits="BusinessCompany.Bulgaria" %>

<asp:Content ID="ContentBulgaria" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Offices in Bulgaria</h2>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>
