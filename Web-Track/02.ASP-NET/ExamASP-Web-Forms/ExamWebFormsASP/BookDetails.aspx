<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BookDetails.aspx.cs" Inherits="ExamWebFormsASP.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:ListView ID="ListViewBookDetails" runat="server" DataKeyNames="BookId"
        SelectMethod="ListViewBookDetails_GetData"
        ItemType="ExamWebFormsASP.Models.Book">
        <LayoutTemplate>
            <table>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <td>
                <p>
                    <asp:Label ID="LabelTitle" runat="server" Text="<%# Item.Title %>" /></p>
                <p>
                    <asp:Label ID="LabelAutor" runat="server" Text="<%# Item.Author %>" /></p>
                <p>
                    <asp:Label ID="LabelISBN" runat="server" Text="<%# Item.ISBN %>" /></p>
                <p>
                    <asp:Label ID="LabelUrl" runat="server" Text="<%# Item.Url %>" /></p>
                <p>
                    <asp:Label ID="LabelDescription" runat="server" Text="<%# Item.Description %>" /></p>
            </td>
        </ItemTemplate>
    </asp:ListView>
    <a href="Default.aspx">Back to books</a>
</asp:Content>
