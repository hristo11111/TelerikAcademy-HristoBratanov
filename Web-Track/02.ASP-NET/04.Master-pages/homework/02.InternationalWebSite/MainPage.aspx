<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_02.InternationalWebSite.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPageContent" runat="server">
    <aside>
        <ul>
            <%--english not implemented but it will be the same as Bulgarian implementation--%>
            <li><a href="/english/english.aspx">English</a></li>
            <li><a href="/Bulgarian/MoreAboutUsBg.aspx">Български</a></li>
        </ul>
    </aside>
</asp:Content>
