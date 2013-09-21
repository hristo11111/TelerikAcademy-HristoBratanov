<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.ListStringInSession.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <label>Enter something</label>
        <asp:TextBox ID="TextBox_Input" runat="server" />
        <asp:Button ID="Button_Save" runat="server" Text="Save" OnClick="Button_Save_Click" />
    </form>
</body>
</html>
