<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_03.CookiesTransfer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:label runat="server" AssociatedControlID="TextBox_UserName" Text="Username" />
        <asp:TextBox ID="TextBox_UserName" runat="server" />
        <asp:Button ID="Button_Login" runat="server" Text="Login" OnClick="Button_Login_Click" />
        <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                    ControlToValidate="TextBox_UserName"
                    Display="Static"
                    ErrorMessage="*"
                    runat="server"/> 
        <asp:Label ID="Label_Errors" runat="server" />
    </form>
</body>
</html>
