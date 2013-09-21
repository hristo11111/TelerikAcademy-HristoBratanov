<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="World.aspx.cs" Inherits="World.World" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource 
            ID="EntityDataSource1" 
            runat="server" 
            ConnectionString="name=WorldDbEntities" 
            DefaultContainerName="WorldDbEntities" 
            EnableFlattening="False" 
            EntitySetName="Continents">
        </asp:EntityDataSource>
    
        <asp:ListBox 
            ID="ListBoxContintents" 
            runat="server" 
            AutoPostBack="True" 
            DataSourceID="EntityDataSource1" 
            DataTextField="ContinentName" 
            DataValueField="ContintentId" OnSelectedIndexChanged="ListBoxContintents_SelectedIndexChanged">
        </asp:ListBox>
        <br />
        <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities" EnableFlattening="False" EntitySetName="Countries" Include="Continent" EntityTypeFilter="" Select="" Where="it.Continent_ContintentId = @ContID">
            <WhereParameters>
                <asp:ControlParameter ControlID="ListBoxContintents" Name="ContID" PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CountryId" DataSourceID="EntityDataSourceCountries" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CountryName" HeaderText="CountryName" SortExpression="CountryName" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Continent.ContinentName" HeaderText="Continent" SortExpression="Continent" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities" EnableFlattening="False" EntitySetName="Towns" EntityTypeFilter="" Include="Country" Select="" Where="it.Country_CountryId = @TownID">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" Name="TownID" PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="TownId" DataSourceID="EntityDataSource2">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="TownNameTextBox" runat="server" Text='<%#: Bind("TownName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%#: Bind("Country.CountryName") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="TownNameTextBox" runat="server" Text='<%#: Bind("TownName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%#: Bind("Country.CountryName") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="TownNameLabel" runat="server" Text='<%# Eval("TownName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.CountryName") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">TownName</th>
                                    <th runat="server">Country</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="TownNameLabel" runat="server" Text='<%# Eval("TownName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.CountryName") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <br />
        <asp:EntityDataSource ID="EntityDataSourceContintentsEditable" runat="server" ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Continents" Include="">
        </asp:EntityDataSource>
        <br />
        <asp:ListView ID="ListViewContinentsEditable" 
            runat="server" DataKeyNames="ContintentId" 
            DataSourceID="EntityDataSourceContintentsEditable" 
            InsertItemPosition="LastItem">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="ContinentNameTextBox" runat="server" Text='<%#: Bind("ContinentName") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="ContinentNameTextBox" runat="server" Text='<%#: Bind("ContinentName") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="ContinentNameLabel" runat="server" Text='<%# Eval("ContinentName") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">ContinentName</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="ContinentNameLabel" runat="server" Text='<%# Eval("ContinentName") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <br />
        <asp:EntityDataSource ID="EntityDataSourceCountriesEditable" runat="server" ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Countries" Include="Continent">
        </asp:EntityDataSource>
        <br />
        <asp:ListView ID="ListView2" runat="server" DataKeyNames="CountryId" DataSourceID="EntityDataSourceCountriesEditable" InsertItemPosition="LastItem">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryNameTextBox" runat="server" Text='<%#: Bind("CountryName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LanguageTextBox" runat="server" Text='<%#: Bind("Language") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListContinent" runat="server" 
                            DataSourceID="EntityDataSourceContintentsEditable"
                            DataValueField="ContintentId"
                            DataTextField="ContinentName"
                            SelectedValue="<%# BindItem.Continent_ContintentId %>" />
                    </td>
                    <td>
                        <asp:FileUpload id="FileUploadControl" runat="server" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryNameTextBox" runat="server" Text='<%#: Bind("CountryName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LanguageTextBox" runat="server" Text='<%#: Bind("Language") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListContinent" runat="server" 
                            DataSourceID="EntityDataSourceContintentsEditable"
                            DataValueField="ContintentId"
                            DataTextField="ContinentName"
                            SelectedValue="<%# BindItem.Continent_ContintentId %>" />
                    </td>
                    <td>
                        <asp:FileUpload id="FileUploadControl" runat="server" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="CountryNameLabel" runat="server" Text='<%# Eval("CountryName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LanguageLabel" runat="server" Text='<%# Eval("Language") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContinentLabel" runat="server" Text='<%# Eval("Continent.ContinentName") %>' />
                    </td>
                    <td>
                        <asp:FileUpload id="FileUploadControl" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">CountryName</th>
                                    <th runat="server">Language</th>
                                    <th runat="server">Continent</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="CountryNameLabel" runat="server" Text='<%# Eval("CountryName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LanguageLabel" runat="server" Text='<%# Eval("Language") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContinentLabel" runat="server" Text='<%# Eval("Continent") %>' />
                    </td>
                    <td>
                        <asp:FileUpload id="FileUploadControl" runat="server" />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <br />
        <asp:EntityDataSource ID="EntityDataSourceTownsEditabe" runat="server" ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Towns" Include="Country">
        </asp:EntityDataSource>
        <br />
        <asp:ListView ID="ListView3" runat="server" DataKeyNames="TownId" DataSourceID="EntityDataSourceTownsEditabe" InsertItemPosition="LastItem">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="TownNameTextBox" runat="server" Text='<%#: Bind("TownName") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" runat="server" 
                            DataSourceID="EntityDataSourceCountriesEditable"
                            DataValueField="CountryId"
                            DataTextField="CountryName"
                            SelectedValue="<%# BindItem.Country_CountryId %>" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="TownNameTextBox" runat="server" Text='<%#: Bind("TownName") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" runat="server" 
                            DataSourceID="EntityDataSourceCountriesEditable"
                            DataValueField="CountryId"
                            DataTextField="CountryName"
                            SelectedValue="<%# BindItem.Country_CountryId %>" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="TownNameLabel" runat="server" Text='<%# Eval("TownName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.CountryName") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">TownName</th>
                                    <th runat="server">Country</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="TownNameLabel" runat="server" Text='<%# Eval("TownName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
