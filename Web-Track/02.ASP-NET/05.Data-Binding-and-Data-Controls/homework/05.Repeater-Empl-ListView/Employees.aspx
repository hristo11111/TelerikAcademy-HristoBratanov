<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_05.Repeater_Empl_ListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListView ID="ListViewEmployees" runat="server" 
            ItemType="_05.Repeater_Empl_ListView.Employee">
            <LayoutTemplate>
                <h1>Employees</h1>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <ul>
                    <li><strong>First name: </strong><%#: Item.FirstName %></li>
                    <li><strong>Last name: </strong><%#: Item.LastName %></li>
                    <li><strong>Hire date: </strong><%#: Item.HireDate %></li>
                    <li><strong>Home phone: </strong><%#: Item.HomePhone %></li>
                    <li><strong>City: </strong><%#: Item.City %></li>
                </ul>
            </ItemTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPagerEmployees" runat="server"
            PagedControlID="ListViewEmployees" PageSize="3"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </form>
</body>
</html>
