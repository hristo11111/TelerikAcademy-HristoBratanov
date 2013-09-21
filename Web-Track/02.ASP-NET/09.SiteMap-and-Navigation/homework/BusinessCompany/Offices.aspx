<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Offices.aspx.cs" 
    Inherits="BusinessCompany.Offices" %>

<asp:Content ID="ContentOffices" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>You can find us in the following countries:</h1>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>
