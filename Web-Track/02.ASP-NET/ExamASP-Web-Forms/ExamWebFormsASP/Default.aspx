<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExamWebFormsASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="default-container">
        <asp:ListView ID="ListViewAllBooks" runat="server" DataKeyNames="CategoryId"
            SelectMethod="ListViewAllBooks_GetData"
            ItemType="ExamWebFormsASP.Models.Category" GroupItemCount="3">
            <LayoutTemplate>
                <table>
                    <tr id="groupPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <GroupTemplate>
                <tr>
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td align="left">
                    <h1>
                        <asp:Label ID="LabelCategoryName" runat="server" Text="<%# Item.CategoryName %>" /><br />
                    </h1>
                    <asp:Repeater ID="RepeaterBookTitles" runat="server" ItemType="ExamWebFormsASP.Models.Book" DataSource="<%# Item.Books %>">
                        <ItemTemplate>
                            <li>
                                <a runat="server" href='<%# string.Format("BookDetails?id={0}", Item.BookId) %>'><%# Item.Title %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
