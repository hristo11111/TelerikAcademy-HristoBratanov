<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NorthwindEmployees.aspx.cs" Inherits="_02.NorthwindEmployees.NorthwindEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First name" />
            <asp:BoundField DataField="LastName" HeaderText="Last name" />
            <asp:HyperLinkField 
                HeaderText="More info"
                Text="more"
                DataNavigateUrlFields="EmployeeID" 
                DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
