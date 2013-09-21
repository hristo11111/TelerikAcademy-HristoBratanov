<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowserAndClientIP.aspx.cs" Inherits="_01.PrintBrowserAndClien.BrowserAndClientIP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonPrint" OnClick="ButtonPrint_OnClick" runat="server" Text="Print" />
        <br />
        <asp:Literal ID="LiteralResult" runat="server" />
    </form>
</body>
</html>
