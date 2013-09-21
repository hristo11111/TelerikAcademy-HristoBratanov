<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqldatasource.aspx.cs" Inherits="MyDemo_SQLDataSource.sqldatasource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<asp:SqlDataSource 
            ID="SqlDataSourceCategories" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:northwindConnectionString %>" 
            SelectCommand="SELECT * FROM [Categories]">
    </asp:SqlDataSource>

    <asp:SqlDataSource 
        ID="SqlDataSourceProducts" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:northwindConnectionString2 %>" 
        SelectCommand="SELECT [ProductName], [UnitPrice], [CategoryID] FROM [Products]">
        </asp:SqlDataSource>--%>

    <form id="form1" runat="server">
        <%--<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="CategoryID" DataSourceID="SqlDataSourceCategories" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CategoryName" 
                    HeaderText="CategoryName" SortExpression="CategoryName" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
        <h2>
            <asp:Literal ID="Literal1" runat="server" Mode="Encode" Text="All Categories"></asp:Literal>
        </h2>
        <asp:Repeater ID="Repeater1" runat="server" 
            DataSourceID="SqlDataSourceProducts">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><%# Eval("ProductName") %>
                    <%# Eval("UnitPrice") %></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>--%>

        <%--<asp:EntityDataSource ID="EntityDataSourceCustomers" 
            runat="server" ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" EnableFlattening="False" 
            EntitySetName="Customers">
        </asp:EntityDataSource>
        <br />
        <asp:ListBox ID="ListBox1" runat="server" 
            DataSourceID="EntityDataSourceCustomers" 
            DataTextField="CompanyName" 
            DataValueField="CustomerID" 
            OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" 
            Rows="10" AutoPostBack="True"></asp:ListBox>


        <asp:FormView ID="FormView1" runat="server" DataKeyNames="CustomerID" DataSourceID="EntityDataSourceCustomers">
            <EditItemTemplate>
                CustomerID:
                <asp:Label ID="CustomerIDLabel1" runat="server" Text='<%# Eval("CustomerID") %>' />
                <br />
                CompanyName:
                <asp:TextBox ID="CompanyNameTextBox" runat="server" Text='<%# Bind("CompanyName") %>' />
                <br />
                ContactName:
                <asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' />
                <br />
                ContactTitle:
                <asp:TextBox ID="ContactTitleTextBox" runat="server" Text='<%# Bind("ContactTitle") %>' />
                <br />
                Address:
                <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                <br />
                City:
                <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                <br />
                Region:
                <asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
                <br />
                PostalCode:
                <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
                <br />
                Country:
                <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                <br />
                Phone:
                <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                <br />
                Fax:
                <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                CustomerID:
                <asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />
                <br />
                CompanyName:
                <asp:TextBox ID="CompanyNameTextBox" runat="server" Text='<%# Bind("CompanyName") %>' />
                <br />
                ContactName:
                <asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' />
                <br />
                ContactTitle:
                <asp:TextBox ID="ContactTitleTextBox" runat="server" Text='<%# Bind("ContactTitle") %>' />
                <br />
                Address:
                <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                <br />
                City:
                <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                <br />
                Region:
                <asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
                <br />
                PostalCode:
                <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
                <br />
                Country:
                <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                <br />
                Phone:
                <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                <br />
                Fax:
                <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                CustomerID:
                <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                <br />
                CompanyName:
                <asp:Label ID="CompanyNameLabel" runat="server" Text='<%# Bind("CompanyName") %>' />
                <br />
                ContactName:
                <asp:Label ID="ContactNameLabel" runat="server" Text='<%# Bind("ContactName") %>' />
                <br />
                ContactTitle:
                <asp:Label ID="ContactTitleLabel" runat="server" Text='<%# Bind("ContactTitle") %>' />
                <br />
                Address:
                <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
                <br />
                City:
                <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>' />
                <br />
                Region:
                <asp:Label ID="RegionLabel" runat="server" Text='<%# Bind("Region") %>' />
                <br />
                PostalCode:
                <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Bind("PostalCode") %>' />
                <br />
                Country:
                <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>' />
                <br />
                Phone:
                <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
                <br />
                Fax:
                <asp:Label ID="FaxLabel" runat="server" Text='<%# Bind("Fax") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>


        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=NorthwindEntities" DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Orders" EntityTypeFilter="" Select="" Where="it.CustomerID=@CustID">
            <WhereParameters>
                <asp:ControlParameter ControlID="ListBox1" Name="CustID" PropertyName="SelectedValue" Type="String" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateSelectButton="True" DataKeyNames="OrderID" DataSourceID="EntityDataSource1">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
                <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
                <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia" />
                <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
                <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
                <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
                <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
                <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
                <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
                <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:EntityDataSource ID="EntityDataSource2" 
            runat="server" 
            ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" 
            EnableFlattening="False" EntitySetName="Order_Details" 
            EntityTypeFilter="" 
            Include="Product" Select="" 
            Where="it.OrderID=@OrderID">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" 
                    Name="OrderID" PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>
        <br />
        <asp:DataList ID="DataList1" runat="server" 
            DataSourceID="EntityDataSource2" 
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <div>Product: <%#: Eval("Product.ProductName") %></div>
                <div>Price: <%#: Eval("UnitPrice", "{0:c}") %></div>
                <div>Quantity: <%#: Eval("Quantity") %></div>
                <div>Discount: <%#: Eval("Discount") %></div>
            </ItemTemplate>
        </asp:DataList>--%>

        

        <asp:EntityDataSource 
            ID="EntityDataSource1" 
            runat="server" 
            ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" 
            EnableDelete="True" 
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Customers">
        </asp:EntityDataSource>

        <asp:ListView ID="ListView1" runat="server" DataSourceID="EntityDataSource1" 
            ItemType="MyDemo_SQLDataSource.Customer">
            
            <LayoutTemplate>
                <span runat="server" id="itemPlaceholder" />
                <div class="paging">
                    <asp:Button ID="ButtonInsert" Text="Insert" runat="server" OnClick="ButtonInsert_Click" />
                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowNextPageButton="False" 
                                ShowPreviousPageButton="False" ShowLastPageButton="True" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <p>No data!</p>
            </EmptyDataTemplate>
            <ItemTemplate>
                <div class="item">
                    Customer ID: <%#: Item.CustomerID %> <br />
                    Company Name: <%#: Item.CompanyName %> <br />
                    Contact Name: <%#: Item.ContactName %> <br />
                    Contact Title: <%#: Item.ContactTitle %> <br />
                    Address: <%#: Item.Address %> <br />
                    City: <%#: Item.City %> <br />
                    Region: <%#: Item.Region %> <br />
                    Postal Code: <%#: Item.PostalCode %> <br />
                    Country: <%#: Item.Country %> <br />
                    Phone: <%#: Item.Phone %> <br />
                    Fax: <%#: Item.Fax %> <br />
                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                </div>
            </ItemTemplate>

            <EditItemTemplate>
                <div class="editItem">
                    Customer ID: <%#: Item.CustomerID %>
                    <br />
                    Company Name:
                    <asp:TextBox ID="TextBoxCompanyName" runat="server" 
                        Text='<%# Bind("CompanyName") %>' />
                    <br />
                    Contact Name:
                    <asp:TextBox ID="TextBoxContactName" runat="server" Text='<%# BindItem.ContactName %>' />
                    <br />
                    Contact Title:
                    <asp:TextBox ID="TextBoxContactTitle" runat="server" Text='<%# BindItem.ContactTitle %>' />
                    <br />
                    Address:
                    <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# BindItem.Address %>' />
                    <br />
                    City:
                    <asp:TextBox ID="TextBoxCity" runat="server" Text='<%# BindItem.City %>' />
                    <br />
                    Region:
                    <asp:TextBox ID="TextBoxRegion" runat="server" Text='<%# BindItem.Region %>' />
                    <br />
                    Postal Code:
                    <asp:TextBox ID="TextBoxPostalCode" runat="server" Text='<%# BindItem.PostalCode %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="TextBoxCountry" runat="server" Text='<%# BindItem.Country %>' />
                    <br />
                    Phone:
                    <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%# Bind("Phone") %>' />
                    <br />
                    Fax:
                    <asp:TextBox ID="TextBoxFax" runat="server" Text='<%# Bind("Fax") %>' />
                    <br />
                    <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                </div>
            </EditItemTemplate>

            <InsertItemTemplate>
                <div class="insertItem">
                    Customer ID: 
                    <asp:TextBox ID="TextBoxCustomerID" runat="server" 
                        Text='<%# Bind("CustomerID") %>' MaxLength="5"/>
                    <asp:RequiredFieldValidator
                         ID="RequiredFieldValidatorCustomerID" runat="server"
                         ErrorMessage="Required field!" ControlToValidate="TextBoxCustomerID">
                    </asp:RequiredFieldValidator>
                    <br />
                    Company Name:
                    <asp:TextBox ID="TextBoxCompanyName" runat="server" Text='<%# Bind("CompanyName") %>' />
                    <br />
                    Contact Name:
                    <asp:TextBox ID="TextBoxContactName" runat="server" Text='<%# Bind("ContactName") %>' />
                    <br />
                    Contact Title:
                    <asp:TextBox ID="TextBoxContactTitle" runat="server" Text='<%# Bind("ContactTitle") %>' />
                    <br />
                    Address:
                    <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# Bind("Address") %>' />
                    <br />
                    City:
                    <asp:TextBox ID="TextBoxCity" runat="server" Text='<%# Bind("City") %>' />
                    <br />
                    Region:
                    <asp:TextBox ID="TextBoxRegion" runat="server" Text='<%# Bind("Region") %>' />
                    <br />
                    Postal Code:
                    <asp:TextBox ID="TextBoxPostalCode" runat="server" Text='<%# Bind("PostalCode") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="TextBoxCountry" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                    Phone:
                    <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%# Bind("Phone") %>' />
                    <br />
                    Fax:
                    <asp:TextBox ID="TextBoxFax" runat="server" Text='<%# Bind("Fax") %>' />
                    <br />
                    <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" />
                </div>
            </InsertItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
