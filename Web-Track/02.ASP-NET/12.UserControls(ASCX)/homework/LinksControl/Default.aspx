<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinksControl.Default" %>
<%@ Register src="ListControl.ascx" tagname="ListControl"
  tagprefix="userControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <userControls:ListControl ID="lbl" runat="server" LoadData="LoadDataMenu()" 
            fontColor="red" fontName="Tahoma" />
    </form>
</body>
</html>
