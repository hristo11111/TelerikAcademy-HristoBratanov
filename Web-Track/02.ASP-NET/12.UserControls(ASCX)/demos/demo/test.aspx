﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="demo.test" %>
<%@ Register src="mycontrol.ascx" tagname="WelcomeLabel"
  tagprefix="userControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <userControls:WelcomeLabel ID="lbl" runat="server" LoadData="LoadDataMenu()" 
            fontColor="red" fontName="Tahoma" />
    </form>
</body>
</html>