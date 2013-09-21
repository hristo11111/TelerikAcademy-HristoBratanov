<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1,2.HelloName, Path.aspx.cs" Inherits="Web_forms_Intro.HelloName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tbInputName" runat="server"></asp:TextBox>
        <asp:Button ID="btnPrintName" OnClick="PrintName" Text="Print" runat="server" />
        <br />
        Your name is:
        <asp:Label ID="lblOutputName" runat="server"></asp:Label>
        <br />
        Tha path to current assembly location is:
        <asp:Label ID="lblPath" runat="server"></asp:Label>
    </form>
</body>
</html>
