<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_01.RegisterUsers.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummaryRegisterForm" runat="server" />
        <br />
        <asp:Label ID="LabelUserName" 
                    runat="server" 
                    AssociatedControlID="TextBoxUserName" 
                    Text="Username:" />
        <asp:TextBox ID="TextBoxUserName" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorUserName" 
            runat="server" ControlToValidate="TextBoxUserName" 
            ErrorMessage="Username required!" Display="None"/>
        <br />
        <asp:Label ID="LabelPassword" 
                    runat="server" 
                    AssociatedControlID="TextBoxPassword" 
                    Text="Password:" />
        <asp:TextBox ID="TextBoxPassword" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorPassword" 
            runat="server" ControlToValidate="TextBoxPassword" 
            ErrorMessage="Password required!" Display="None"/>
        <br />
        <asp:Label ID="LabelRePassword" 
                    runat="server" 
                    AssociatedControlID="TextBoxRePassword" 
                    Text="Repeat Password:" />
        <asp:TextBox ID="TextBoxRePassword" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorRePassword" 
            runat="server" ControlToValidate="TextBoxRePassword" 
            ErrorMessage="Repeat password is required!" Display="None"/>
        <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
            ControlToCompare="TextBoxPassword"
            ControlToValidate="TextBoxRePassword" Display="None"
            ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False" 
            ></asp:CompareValidator>
        <br />
        <asp:Label ID="LabelFirstName" 
                    runat="server" 
                    AssociatedControlID="TextBoxFirstName" 
                    Text="First name:" />
        <asp:TextBox ID="TextBoxFirstName" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorFirstName" 
            runat="server" ControlToValidate="TextBoxFirstName" 
            ErrorMessage="First name is required!" Display="None"/>
        <br />
        <asp:Label ID="LabelLastName" 
                    runat="server" 
                    AssociatedControlID="TextBoxLastName" 
                    Text="Last name:" />
        <asp:TextBox ID="TextBoxLastName" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorLastName" 
            runat="server" ControlToValidate="TextBoxLastName" 
            ErrorMessage="Last name is required!" Display="None"/>
        <br />
        <asp:Label ID="LabelAge" 
                    runat="server" 
                    AssociatedControlID="TextBoxAge" 
                    Text="Age:" />
        <asp:TextBox ID="TextBoxAge" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorAge" 
            runat="server" ControlToValidate="TextBoxAge" 
            ErrorMessage="Age is required!" Display="None"/>
        <asp:RangeValidator ID="RangeValidatorAge" 
            runat="server" ControlToValidate="TextBoxAge" 
            Display="None" ErrorMessage="Age is not in range!" 
            MaximumValue="81" MinimumValue="18" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:Label ID="LabelEmail" 
                    runat="server" 
                    AssociatedControlID="TextBoxEmail" 
                    Text="Email:" />
        <asp:TextBox ID="TextBoxEmail" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorEmail" 
            runat="server" ControlToValidate="TextBoxEmail" 
            ErrorMessage="Email is required!" Display="None"/>
        <asp:RegularExpressionValidator
            id="RegularExpressionValidatorEmail"
            runat="server" ForeColor="Red" Display="None"
            ErrorMessage="Email address is incorrect!"
            ControlToValidate="TextBoxEmail" EnableClientScript="False"
            ValidationExpression=
            "[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
        </asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="LabelAddress" 
                    runat="server" 
                    AssociatedControlID="TextBoxAddress" 
                    Text="Local address:" />
        <asp:TextBox ID="TextBoxAddress" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorAddress" 
            runat="server" ControlToValidate="TextBoxAddress" 
            ErrorMessage="Local address is required!" Display="None"/>
        <br />
        <asp:Label ID="LabelPhone" 
                    runat="server" 
                    AssociatedControlID="TextBoxPhone" 
                    Text="Phone:" />
        <asp:TextBox ID="TextBoxPhone" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorPhone" 
            runat="server" ControlToValidate="TextBoxPhone" 
            ErrorMessage="Phone is required!" Display="None"/>
        <asp:RegularExpressionValidator
            id="RegularExpressionValidatorPhone"
            runat="server" ForeColor="Red" Display="None"
            ErrorMessage="Phone is incorrect!"
            ControlToValidate="TextBoxPhone" EnableClientScript="False"
            ValidationExpression=
            "\d+">
        </asp:RegularExpressionValidator>
        <br />
        <asp:CheckBox ID="CheckBoxAccept" runat="server" AutoPostBack="True" Text="I accept" />
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Enabled="False" />
    </form>
</body>
</html>
