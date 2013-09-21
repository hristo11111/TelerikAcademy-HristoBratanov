<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="_04.StudentsRegistration.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Students registration form</h1>

        First name:
        <asp:TextBox ID="TbFirstName" runat="server" />
        <br />
        Last name:
        <asp:TextBox ID="TbLastName" runat="server" />
        <br />
        Faculty number:
        <asp:TextBox ID="TbFacultyNumber" runat="server" />
        <br />
        University:
        <asp:DropDownList ID="DropDownListUniversity" runat="server" AutoPostBack="true">
            <asp:ListItem Value="1">Sofia University</asp:ListItem>
            <asp:ListItem Value="2">Plovdiv University</asp:ListItem>
            <asp:ListItem Value="3">Technical University</asp:ListItem>
        </asp:DropDownList>
        <br />
        Specialty:
        <asp:DropDownList ID="DropDownListSpecialty" runat="server" AutoPostBack="true">
            <asp:ListItem Value="1">Specialty1</asp:ListItem>
            <asp:ListItem Value="2">Specialty2</asp:ListItem>
            <asp:ListItem Value="3">Specialty3</asp:ListItem>
        </asp:DropDownList>
        <br />
        Courses:
        <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple" AutoPostBack="True"
            Height="56px">
            <asp:ListItem Value="0">-Select-</asp:ListItem>
            <asp:ListItem Value="1">Maths</asp:ListItem>
            <asp:ListItem Value="2">Literature</asp:ListItem>
            <asp:ListItem Value="3">Informatics</asp:ListItem>
            <asp:ListItem Value="4">Psyhology</asp:ListItem>
        </asp:ListBox>
    </form>
</body>
</html>
