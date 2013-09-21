<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="_01.RandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <input type="text" id="tbFrom" runat="server"/>
        <input type="text" id="tbTo" runat="server"/>
        <button OnServerClick="GenerateRandNumber" id="btnGenerate" runat="server">Generate</button>
        <br />
        <label id="labelResult" runat="server"></label>
    </form>
</body>
</html>
