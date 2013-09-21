<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.Northwind_Employees.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />

        <asp:EntityDataSource ID="EntityDataSourceEmployees"
            runat="server" ConnectionString="name=NorthwindEntities"
            DefaultContainerName="NorthwindEntities" EnableFlattening="False"
            EntitySetName="Employees" AutoGenerateOrderByClause="True">
        </asp:EntityDataSource>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="EmployeeID"
            DataSourceID="EntityDataSourceEmployees" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:EntityDataSource ID="EntityDataSourceOrders" runat="server"
            ConnectionString="name=NorthwindEntities" DefaultContainerName="NorthwindEntities"
            EnableFlattening="False" EntitySetName="Orders"
            Where="it.EmployeeID = @EmployeeID"
            AutoGenerateOrderByClause="True">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" Name="EmployeeID" PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:UpdateProgress ID="UpdateProgress" runat="server" DynamicLayout="true">
            <ProgressTemplate>
                Updating ...
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
        <asp:UpdatePanel ID="UpdatePanelOrders" UpdateMode="Conditional" runat="server">
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="EntityDataSourceOrders">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" ReadOnly="True" SortExpression="OrderDate" />
                        <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" ReadOnly="True" SortExpression="ShippedDate" />
                        <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" ReadOnly="True" SortExpression="ShipVia" />
                        <asp:BoundField DataField="Freight" HeaderText="Freight" ReadOnly="True" SortExpression="Freight" />
                        <asp:BoundField DataField="ShipName" HeaderText="ShipName" ReadOnly="True" SortExpression="ShipName" />
                        <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" ReadOnly="True" SortExpression="ShipCity" />
                        <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" ReadOnly="True" SortExpression="ShipCountry" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
