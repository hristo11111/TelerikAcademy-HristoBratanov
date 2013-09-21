<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberWebServerCls.aspx.cs" Inherits="_02.RandomNumbersWebServerControls.RandomNumberWebServerCls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tbFromNumber" runat="server" />
        <asp:TextBox ID="tbToNumber" runat="server" />
        <asp:Button ID="btnGenerate" OnClick="GenerateRandomNumbers" Text="Generate" runat="server" />
        <br />
        <asp:Label ID="labelResult" runat="server" />
    </form>
</body>
</html>
