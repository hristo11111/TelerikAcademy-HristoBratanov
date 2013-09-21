<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="CreateCategory.aspx.cs" Inherits="ExamWebFormsASP.CreateCategory" %>

<asp:Content ID="ContentCreateCategory" ContentPlaceHolderID="MainContent" runat="server">
    
                <h2>Create New Category</h2>
                Category: <asp:TextBox runat="server" ID="TextBoxEditCategory" placeholder="Enter category name ..." />
                <br />
                <asp:LinkButton ID="ButtonUpdate" runat="server" Text="Create" OnClick="CreateNewCategory" />
                <asp:LinkButton runat="server" Text="Cancel" OnClick="CancelCategory" />
</asp:Content>
