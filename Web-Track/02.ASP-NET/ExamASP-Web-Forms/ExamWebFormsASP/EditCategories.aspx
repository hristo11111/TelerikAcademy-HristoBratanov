<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="ExamWebFormsASP.EditCategories" %>

<asp:Content ID="ContentEditCategories" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>
    <asp:GridView ID="GridViewEditCategories" runat="server"
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        ItemType="ExamWebFormsASP.Models.Category"
        DataKeyNames="CategoryId" PageSize="5" SelectMethod="GridViewEditCategories_GetData">
        <Columns>
            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="ButtonEdit"
                        CommandArgument="<%# Item.CategoryId %>"
                        Text="Edit" OnClick="ShowEditMenu" />
                    <asp:LinkButton runat="server" ID="ButtonDelete"
                        CommandArgument="<%# Item.CategoryId %>"
                        Text="Delete" OnClick="DeleteCategory" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:LinkButton ID="ButtonCreateCategory" Text="Create New" runat="server" OnClick="ButtonCreateCategory_Click" />

    <div id="Panel-Edit">
        <asp:ListView runat="server" ID="ListViewEditCategory"
            ItemType="ExamWebFormsASP.Models.Category"
            DataKeyNames="CategoryId">
            <ItemTemplate>
                <h2>Edit Category</h2>
                Category: <asp:TextBox runat="server" ID="TextBoxEditCategory" Text='<%# BindItem.CategoryName %>' />
                <br />
                <asp:LinkButton ID="ButtonUpdate" runat="server" Text="Save"
                    CommandArgument="<%# Item.CategoryId %>" OnClick="EditCategory" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelCategory" />
            </ItemTemplate>
            <EditItemTemplate>
                <h2>Edit Category</h2>
                Category: <asp:TextBox runat="server" ID="TextBoxEditCategory" Text='<%# BindItem.CategoryName %>' />
                <br />
                <asp:LinkButton ID="ButtonUpdate" runat="server" Text="Save"
                    CommandArgument="<%# Item.CategoryId %>" OnClick="EditCategory" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelCategory" />
            </EditItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <br />
    <a href="Default.aspx">Back to books</a>
    <%--<asp:FormView runat="server" ID="FormViewEditCategory" 
        DataKeyNames="CategoryId"
        DefaultMode="Edit"
        OnModeChanged="FormViewEditCategory_ModeChanged"
        OnItemUpdated="FormViewEditCategory_ItemUpdated"
        ItemType="ExamWebFormsASP.Models.Category">
        <ItemTemplate>
            <h2>Edit Category</h2>
            <asp:TextBox runat="server" ID="TextBoxEditCategory" Text='<%# BindItem.CategoryName %>' />
            <br />
            <asp:LinkButton runat="server" ID="ButtonSave"
                        CommandArgument = "<%# Item.CategoryId %>"
                        Text = "Save" CommandName="Update" />
            <asp:LinkButton runat="server" ID="ButtonCancel"
                        Text = "Cancel" OnClick = "CancelCategory" />
        </ItemTemplate>
        <EditItemTemplate>
            <h2>Edit Category</h2>
            <asp:TextBox runat="server" ID="TextBoxEditCategory" Text='<%# BindItem.CategoryName %>' />
            <br />
            <asp:LinkButton runat="server" ID="ButtonSave"
                        CommandArgument = "<%# Item.CategoryId %>"
                        Text = "Save" CommandName="Update" />
            <asp:LinkButton runat="server" ID="ButtonCancel"
                        Text = "Cancel" OnClick = "CancelCategory" />
        </EditItemTemplate>
    </asp:FormView>--%>
</asp:Content>
