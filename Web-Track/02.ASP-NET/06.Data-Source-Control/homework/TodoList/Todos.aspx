<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="TodoList.Todos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:GridView ID="GridViewCategories" runat="server"
            SelectMethod="GridViewCategories_GetData"
            UpdateMethod="GridViewCategories_UpdateItem"
            DeleteMethod="GridViewCategories_DeleteItem"
            ItemType="TodoList.Category"
            

            DataKeyNames="CategoryId"
            AutoGenerateEditButton="true" 
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>
            </Columns> 
        </asp:GridView>
        <br />
        <asp:FormView ID="FormViewInsertCategory" runat="server" DefaultMode="Insert" 
            ItemType="TodoList.Category"
            InsertMethod="InsertCategory">
            <InsertItemTemplate>
                New Category:
                <asp:TextBox ID="TextBoxInsertCategory" runat="server" Text='<%#: BindItem.CategoryName %>'/>
                <asp:Button ID="Button_Save" runat="server" CommandName="Insert" Text="Save" /> 
            </InsertItemTemplate>
        </asp:FormView>
        <br />
        <br />
        <asp:GridView ID="GridViewTodos" runat="server"
            SelectMethod="GridViewTodos_GetData"
            UpdateMethod="GridViewTodos_UpdateItem"
            DeleteMethod="GridViewTodos_DeleteItem"
            ItemType="TodoList.TodoItem"
            AllowPaging="true" AllowSorting="true"
            DataKeyNames="TodoId"
            AutoGenerateEditButton="true" 
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                <asp:BoundField DataField="DateLastChanged" HeaderText="Date Last Changed" SortExpression="DateLastChanged" />
                <asp:BoundField DataField="Category.CategoryName" HeaderText="Category" SortExpression="Category" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>
            </Columns>
        </asp:GridView>
        <br />
        <asp:FormView ID="FormViewTodos" runat="server" DefaultMode="Insert" 
            ItemType="TodoList.TodoItem"
            InsertMethod="InsertTodoItem">
            <InsertItemTemplate>
                <table>
                    <tr>
                        <td></td>
                        <td>Title</td>
                        <td>Text</td>
                        <td>Date Last Changed</td>
                        <td>Category</td>
                    </tr>
                    <tr>
                        <td>New TodoItem:</td>
                        <td>
                            <asp:TextBox ID="TextBoxTodoItem_Title" runat="server" Text='<%#: BindItem.Title %>'/>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTodoItem_Text" runat="server" Text='<%#: BindItem.Text %>'/>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTodoItem_Date" runat="server" Text='<%#: BindItem.DateLastChanged %>'/>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTodoItem_Category" runat="server" Text='<%#: BindItem.Category.CategoryName %>'/>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button_Save" runat="server" CommandName="Insert" Text="Save" /> 
            </InsertItemTemplate>
        </asp:FormView>
            
    </form>
</body>
</html>
