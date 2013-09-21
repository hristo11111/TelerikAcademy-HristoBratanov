<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Sumator</h1>
        First number:
        <asp:TextBox ID="firstNumber" runat="server"></asp:TextBox>
        Second number:
        <asp:TextBox ID="secondNumber" runat="server"></asp:TextBox>
        <asp:Button ID="btnSum" onclick="SumNumbers" Text="Sum" runat="server" />
        <asp:TextBox ID="result" runat="server"></asp:TextBox>
    </form>
</body>
</html>
