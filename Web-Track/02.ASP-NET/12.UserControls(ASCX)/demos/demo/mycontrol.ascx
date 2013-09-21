<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mycontrol.ascx.cs" Inherits="demo.mycontrol" %>



<asp:DataList ID="DataList" runat="server" OnItemDataBound="DataList_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink
                runat="server"
                ID="hyperlink1"
                Text='<%# Eval("Title") %>'
                NavigateUrl='<%# Eval("Url") %>'
                Target="_new" />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:DataList>