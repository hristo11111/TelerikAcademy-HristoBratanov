﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs"
    Inherits="ChatIdentity.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--save scroll position--%>
    <%--<script type="text/javascript">
        window.onload = function () {
            var strCook = document.cookie;
            if (strCook.indexOf("!~") != 0) {
                var intS = strCook.indexOf("!~");
                var intE = strCook.indexOf("~!");
                var strPos = strCook.substring(intS + 2, intE);
                document.getElementById("messages-container").scrollTop = strPos;
            }
        }
        function SetDivPosition() {
            var intY = document.getElementById("messages-container").scrollTop;
            document.cookie = "yPos=!~" + intY + "~!";
        }
    </script>--%>

    <div id="messages-container" onscroll="SetDivPosition()">
        <asp:UpdatePanel runat='server' ID='UpdatePanelTime' UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:ListView ID="ListViewMessages" runat="server"
                    InsertItemPosition="None"
                    SelectMethod="ListViewMessages_GetData" ItemType="ChatIdentity.Message">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li id="list" runat="server"><%#: Item.Message1 %></li>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Timer ID="Timer1" runat="Server" Interval="500" />

    <div id="new-message-wrapper">
        <asp:Label runat="server" ID="LabelNewMessage" Text="Your message" />
        <asp:TextBox runat="server" ID="TextBox_NewMessage" />
        <asp:Button runat="server" ID="ButtonSend" Text="Send" OnClick="ButtonSend_Click" />
        <%--for testing only--%>
        <%= DateTime.Now.ToString("hh:mm:ss") %>
    </div>

    <script>
        debugger
        var some = $('#messages-container');
        $('#messages-container').scrollTop(10000);
    </script>
</asp:Content>
