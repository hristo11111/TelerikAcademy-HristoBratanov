<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarsCatalog.aspx.cs" Inherits="CarsCatalog.CarsCatalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownProducer" runat="server" AutoPostBack="true" 
            DataTextField="ProducerName" DataValueField="ProducerId"
            OnSelectedIndexChanged="DropDownProducer_IndexChanged">
        </asp:DropDownList>

        <br />
        <br />
        <br />

        <asp:DropDownList ID="DropDownModel" runat="server" AutoPostBack="true"
            DataTextField="CarName">
        </asp:DropDownList>

        <br />
        <br />
        <br />

        <asp:CheckBoxList ID="CheckBoxList_Extra" runat="server" AutoPostBack="true"
            DataTextField="Type">
        </asp:CheckBoxList>

        <br />
        <br />
        <br />

        <asp:RadioButtonList ID="RadioButtonList_Engine" runat="server" AutoPostBack="true">
        </asp:RadioButtonList>

        <br />
        <br />
        <br />

        <asp:Button ID="ButtonSumbit" Text="Submit" runat="server" OnClick="SubmitForm" />
        <br />
        <asp:Literal ID="LiteralResult" runat="server" />
    </form>
</body>
</html>
