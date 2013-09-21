<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04.Repeater_Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <thead>
                <tr>
                    <th>First name</th>
                    <th>Last name</th>
                    <th>Title</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterEmloyees" runat="server" 
                    ItemType="_04.Repeater_Employees.EmployeeModel">
                        <ItemTemplate>
                            <tr>
                                <td><%#: Item.FirstName %></td>
                                <td><%#: Item.LastName %></td>
                                <td><%#: Item.Title %></td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </form>
</body>
</html>
