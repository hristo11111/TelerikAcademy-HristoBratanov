<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Books.aspx.cs" Inherits="ExamWebFormsASP.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Books</h1>
    <asp:GridView ID="GridViewEditBooks" runat="server"
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        ItemType="ExamWebFormsASP.Models.Book"
        DataKeyNames="BookId" PageSize="5" SelectMethod="GridViewEditBooks_GetData">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
            <asp:HyperLinkField DataTextField="Url" DataNavigateUrlFields="Url" DataNavigateUrlFormatString="{0}" Text="Url" />
            <asp:BoundField DataField="Category.CategoryName" HeaderText="Category" SortExpression="Category" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="ButtonEdit"
                        CommandArgument="<%# Item.BookId %>"
                        Text="Edit" OnClick="ShowEditMenu" />
                    <asp:LinkButton runat="server" ID="ButtonDelete"
                        CommandArgument="<%# Item.BookId %>"
                        Text="Delete" OnClick="DeleteBook" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <%--<asp:LinkButton ID="ButtonCreate" runat="server" Text="Create New" OnClick="ShowCreateBookForm" />--%>

    <%--<div id="Panel-Create-Book">
        <asp:ListView runat="server" ID="ListViewCreateBook"
            ItemType="ExamWebFormsASP.Models.Book"
            DataKeyNames="BookId">
            <LayoutTemplate>
                <h2>Create New Book</h2>
                <ul>
                    <li>Title:
                        <asp:TextBox runat="server" placeholder="Enter book title ..."
                            ID="TextBoxEditTitleInsert" /></li>
                    <li>Author(s):
                        <asp:TextBox runat="server" placeholder="Enter book author / authors ..."
                            ID="TextBoxEditAuthorsInsert" /></li>
                    <li>ISBN:
                        <asp:TextBox runat="server" placeholder="Enter book ISBN ..."
                            ID="TextBoxIsbnInsert" /></li>
                    <li>Web site:
                        <asp:TextBox runat="server" placeholder="Enter book web site ..."
                            ID="TextBoxWebSiteInsert" /></li>
                    <li>Description:
                        <asp:TextBox runat="server" placeholder="Enter book description ..."
                            ID="TextBoxtDescriptionInsert" /></li>
                    <li>Category:
                        <asp:DropDownList ID="DropDownCategoryInsert" runat="server"
                            DataValueField="CategoryId"
                            DataTextField="CategoryName"
                            SelectMethod="LoadDropDown"
                            SelectedValue="<%# Item.CategoryId %>" /></li>
                </ul>
                <br />
                <asp:LinkButton ID="ButtonCreate" runat="server" Text="Create"
                     OnClick="CreateBook" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBook" />
            </LayoutTemplate>
            <ItemTemplate>
                <h2>Create New Book</h2>
                <ul>
                    <li>Title:
                        <asp:TextBox runat="server" placeholder="Enter book title ..."
                            ID="TextBoxEditTitleInsert" Text='<%# BindItem.Title %>' /></li>
                    <li>Author(s):
                        <asp:TextBox runat="server" placeholder="Enter book author / authors ..."
                            ID="TextBoxEditAuthorsInsert" Text='<%# BindItem.Author %>' /></li>
                    <li>ISBN:
                        <asp:TextBox runat="server" placeholder="Enter book ISBN ..."
                            ID="TextBoxIsbnInsert" Text='<%# BindItem.ISBN %>' /></li>
                    <li>Web site:
                        <asp:TextBox runat="server" placeholder="Enter book web site ..."
                            ID="TextBoxWebSiteInsert" Text='<%# BindItem.Url %>' /></li>
                    <li>Description:
                        <asp:TextBox runat="server" placeholder="Enter book description ..."
                            ID="TextBoxtDescriptionInsert" Text='<%# BindItem.Description %>' /></li>
                    <li>Category:
                        <asp:DropDownList ID="DropDownCategoryInsert" runat="server"
                            DataValueField="CategoryId"
                            DataTextField="CategoryName"
                            SelectMethod="LoadDropDown"/></li>
                </ul>
                <br />
                <asp:LinkButton ID="ButtonCreate" runat="server" Text="Create"
                    CommandArgument="<%# Item.CategoryId %>" OnClick="CreateBook" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBook" />
            </ItemTemplate>
            <InsertItemTemplate>
                <h2>Create New Book</h2>
                <ul>
                    <li>Title:
                        <asp:TextBox runat="server" placeholder="Enter book title ..."
                            ID="TextBoxEditTitleInsert" Text='<%# BindItem.Title %>' /></li>
                    <li>Author(s):
                        <asp:TextBox runat="server" placeholder="Enter book author / authors ..."
                            ID="TextBoxEditAuthorsInsert" Text='<%# BindItem.Author %>' /></li>
                    <li>ISBN:
                        <asp:TextBox runat="server" placeholder="Enter book ISBN ..."
                            ID="TextBoxIsbnInsert" Text='<%# BindItem.ISBN %>' /></li>
                    <li>Web site:
                        <asp:TextBox runat="server" placeholder="Enter book web site ..."
                            ID="TextBoxWebSiteInsert" Text='<%# BindItem.Url %>' /></li>
                    <li>Description:
                        <asp:TextBox runat="server" placeholder="Enter book description ..."
                            ID="TextBoxtDescriptionInsert" Text='<%# BindItem.Description %>' /></li>
                    <li>Category:
                        <asp:DropDownList ID="DropDownCategoryInsert" runat="server"
                            DataValueField="CategoryId"
                            DataTextField="CategoryName"
                            SelectMethod="LoadDropDown"
                            SelectedValue="<%# Item.CategoryId %>" /></li>
                </ul>
                <br />
                <asp:LinkButton ID="ButtonCreate" runat="server" Text="Create"
                    CommandArgument="<%# Item.CategoryId %>" OnClick="CreateBook" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBook" />
            </InsertItemTemplate>
        </asp:ListView>
    </div>--%>

    <div id="Panel-Edit-Books">
        <asp:ListView runat="server" ID="ListViewEditBook"
            ItemType="ExamWebFormsASP.Models.Book"
            DataKeyNames="BookId">
            <ItemTemplate>
                <h2>Edit Book</h2>
                <ul>
                    <li>Title:
                        <asp:TextBox runat="server" ID="TextBoxEditTitle" Text='<%# BindItem.Title %>' /></li>
                    <li>Author(s):
                        <asp:TextBox runat="server" ID="TextBoxEditAuthors" Text='<%# BindItem.Author %>' /></li>
                    <li>ISBN:
                        <asp:TextBox runat="server" ID="TextBoxIsbn" Text='<%# BindItem.ISBN %>' /></li>
                    <li>Web site:
                        <asp:TextBox runat="server" ID="TextBoxWebSite" Text='<%# BindItem.Url %>' /></li>
                    <li>Description:
                        <asp:TextBox runat="server" ID="TextBoxtDescription" Text='<%# BindItem.Description %>' /></li>
                    <li>Category:
                        <asp:DropDownList ID="DropDownCategory" runat="server"
                            DataValueField="CategoryId"
                            DataTextField="CategoryName"
                            SelectMethod="LoadDropDown"
                            SelectedValue="<%# Item.CategoryId %>" /></li>
                </ul>
                <br />
                <asp:LinkButton ID="ButtonUpdate" runat="server" Text="Save"
                    CommandArgument="<%# Item.BookId %>" OnClick="EditBook" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBook" />
            </ItemTemplate>
            <EditItemTemplate>
                <h2>Edit Book</h2>
                <ul>
                    <li>Title:
                        <asp:TextBox runat="server" ID="TextBoxEditTitle" Text='<%# BindItem.Title %>' /></li>
                    <li>Author(s):
                        <asp:TextBox runat="server" ID="TextBoxEditAuthors" Text='<%# BindItem.Author %>' /></li>
                    <li>ISBN:
                        <asp:TextBox runat="server" ID="TextBoxIsbn" Text='<%# BindItem.ISBN %>' /></li>
                    <li>Web site:
                        <asp:TextBox runat="server" ID="TextBoxWebSite" Text='<%# BindItem.Url %>' /></li>
                    <li>Description:
                        <asp:TextBox runat="server" ID="TextBoxtDescription" Text='<%# BindItem.Description %>' /></li>
                    <li>Category:
                        <asp:DropDownList ID="DropDownCategory" runat="server"
                            DataValueField="CategoryId"
                            DataTextField="CategoryName"
                            SelectMethod="LoadDropDown"
                            SelectedValue="<%# Item.CategoryId %>" /></li>
                </ul>
                <br />
                <asp:LinkButton ID="ButtonUpdate" runat="server" Text="Save"
                    CommandArgument="<%# Item.CategoryId %>" OnClick="EditBook" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBook" />
            </EditItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <br />
    <a href="Default.aspx">Back to books</a>

</asp:Content>
