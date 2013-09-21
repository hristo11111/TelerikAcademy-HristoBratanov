<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="03.DumpEvents.aspx.cs" 
    Inherits="Web_forms_Intro._03_DumpEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button Text="OK" runat="server" ID="ButtonOK" OnClick="ButtonOK_Click" OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload"/>
    </div>
    </form>
</body>
</html>
