<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditDeleteMessages.aspx.cs" Inherits="WebFormsTemplate.EditDeleteMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewAdmin" runat="server" 
        SelectMethod="ListViewAdmin_GetData" 
        DataKeyNames="MessageId" 
        ItemPlaceholderID="itemPlaceHolder" 
        ItemType="WebFormsTemplate.Message" 
        UpdateMethod="ListViewAdmin_UpdateItem"
        DeleteMethod="ListViewAdmin_DeleteItem">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Message</th>
                    <th></th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#: Item.Message1%>
                </td>
                <td>
                    <asp:LinkButton ID="Edit" runat="server" 
                        ClientIDMode="Static" CommandName="Edit" 
                        CommandArgument="<%#: Item.MessageId %>" Text="Edit" />
                    <asp:LinkButton ID="Delete" runat="server" 
                        ClientIDMode="Static" CommandName="Delete" 
                        CommandArgument="<%#: Item.MessageId %>" Text="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="Description" runat="server" Text="<%#: BindItem.Message1%>" />
                </td>
                <td>
                    <asp:LinkButton ID="Update" runat="server" ClientIDMode="Static"
                        CommandName="Update" CommandArgument="<%#: Item.MessageId %>"
                        Text="Update" />
                    <asp:LinkButton ID="Cancel" runat="server" ClientIDMode="Static"
                        CommandName="Cancel" CommandArgument="<%#: Item.MessageId %>"
                        Text="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
