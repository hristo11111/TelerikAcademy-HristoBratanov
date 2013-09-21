<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CreateBook.aspx.cs" Inherits="ExamWebFormsASP.CreateBook" %>

<asp:Content ID="ContentCreateBook" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create New Book</h2>
    <ul>
        <li>Title:
            <asp:TextBox runat="server" placeholder="Enter book title ..."
                ID="TextBoxEditTitleInsert" /></li>
        <li>Author(s):
            <asp:TextBox runat="server" placeholder="Enter book author / authors ..."
                ID="TextBoxEditAuthorsInsert" /></li>
        <li>ISBN:
            <asp:TextBox runat="server" placeholder="Enter book ISBN ..."
                ID="TextBoxIsbnInsert" /></li>
        <li>Web site:
            <asp:TextBox runat="server" placeholder="Enter book web site ..."
                ID="TextBoxWebSiteInsert" /></li>
        <li>Description:
            <asp:TextBox runat="server" placeholder="Enter book description ..."
                ID="TextBoxtDescriptionInsert" /></li>
        <li>Category:
            <asp:DropDownList ID="DropDownCategoryInsert" runat="server"
                DataValueField="CategoryId"
                DataTextField="CategoryName"
                SelectMethod="LoadDropDown"/></li>
    </ul>
    <br />
    <asp:LinkButton ID="ButtonCreate" runat="server" Text="Create"
        OnClick="CreateBook" />
    <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelBook" />
</asp:Content>
