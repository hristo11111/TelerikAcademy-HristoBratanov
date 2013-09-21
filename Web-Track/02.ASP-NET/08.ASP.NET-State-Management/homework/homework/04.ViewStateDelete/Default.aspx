<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_04.ViewStateDelete.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" />
    </form>

    <script>
        var hiddenInputs = document.getElementsByTagName('input');
        for (var i = 0; i < hiddenInputs.length; i++) {
            if (hiddenInputs[i].type == 'hidden') {
                hiddenInputs[i].type = '';
            }
        }
    </script>
</body>
</html>
