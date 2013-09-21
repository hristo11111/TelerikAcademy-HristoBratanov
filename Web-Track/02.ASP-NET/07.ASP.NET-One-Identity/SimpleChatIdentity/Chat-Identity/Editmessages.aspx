<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Editmessages.aspx.cs" Inherits="WebFormsTemplate.Edit_messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Edit-table-container">
        <asp:GridView runat="server" ID="GridViewEditMessages"
            ItemType="WebFormsTemplate.Message" DataKeyNames="MessageId"
            SelectMethod="GetMessages"
            UpdateMethod="ListViewMessages_UpdateItem"
            AutoGenerateEditButton="true"  
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Message1" HeaderText="Message"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
