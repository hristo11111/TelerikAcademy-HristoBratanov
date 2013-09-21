<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_03.NorthwEmp_FormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false"
            onrowcommand="gridMembersList_RowCommand">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First name" />
                <asp:BoundField DataField="LastName" HeaderText="Last name" />
                <asp:TemplateField HeaderText="View More">
                    <ItemTemplate>
                        <asp:Button ID="btnViewmore"  
                            CommandArgument='<%#Eval("EmployeeID")%>' 
                            CommandName="More" runat="server" Text="View More" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:FormView ID="FormViewEmplDetails" AllowPaging="false" runat="server" >
            <ItemTemplate>
                <h3><%# Eval("FirstName") + " " + Eval("LastName") %></h3>
                <p><strong>Title: </strong><%#: Eval("Title") %></p>
                <p><strong>City</strong><%#: Eval("City") %></p>
                <p><strong>Region</strong><%#: Eval("Region") %></p>
            </ItemTemplate>
        </asp:FormView>
        <asp:Label ID="LabelMessages" runat="server" />
    </form>
</body>
</html>
