<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="_03.HtmlEscaping.HtmlEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tbInput" runat="server" />
        <asp:Button ID="btnShowInput" Text="Show" OnClick="ShowInput" runat="server" />
        <asp:Literal ID="literalEscapedInput" runat="server" mode="Encode" />
        <br />
        Textbox:
        <asp:TextBox ID="tbResult" runat="server" />
        <br />
        Label:
        <asp:Label ID="labelResult" runat="server" />
    </form>
</body>
</html>
