<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCalculator.aspx.cs" Inherits="_05.WebCalculator.WebCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Table ID="TableCalculator" runat="server">
        <asp:TableRow ID="RowCalculateField">
            <asp:TableCell ID="CellCalculateField" ColumnSpan="4">
                <asp:TextBox ID="TbCalculateField" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="RowSecond">
            <asp:TableCell ID="CellRowSecond" ColumnSpan="4">
                <asp:Button Text="1" runat="server" ID="Button1" OnClick="AddForCalculation"/>
                <asp:Button Text="2" runat="server" ID="Button2" OnClick="AddForCalculation"/>
                <asp:Button Text="3" runat="server" ID="Button3" OnClick="AddForCalculation"/>
                <asp:Button Text="+" runat="server" ID="ButtonPlus" OnClick="AddForCalculation"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="RowThird">
            <asp:TableCell ID="CellRowThird" ColumnSpan="4">
                <asp:Button Text="4" runat="server" ID="Button4" OnClick="AddForCalculation"/>
                <asp:Button Text="5" runat="server" ID="Button5" OnClick="AddForCalculation"/>
                <asp:Button Text="6" runat="server" ID="Button6" OnClick="AddForCalculation"/>
                <asp:Button Text="-" runat="server" ID="ButtonMinus" OnClick="AddForCalculation"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="RowForth">
            <asp:TableCell ID="CellRowForth" ColumnSpan="4">
                <asp:Button Text="7" runat="server" ID="Button7" OnClick="AddForCalculation"/>
                <asp:Button Text="8" runat="server" ID="Button8" OnClick="AddForCalculation"/>
                <asp:Button Text="9" runat="server" ID="Button9" OnClick="AddForCalculation"/>
                <asp:Button Text="x" runat="server" ID="ButtonMultiply" OnClick="AddForCalculation"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="RowFifth">
            <asp:TableCell ID="CellRowFifth" ColumnSpan="4">
                <asp:Button Text="Clear" runat="server" ID="ButtonClear" OnClick="Clear"/>
                <asp:Button Text="0" runat="server" ID="Button0" OnClick="Button0Click"/>
                <asp:Button Text="/" runat="server" ID="ButtonDivision" OnClick="AddForCalculation"/>
                <asp:Button Text="&#x221a;" runat="server" ID="ButtonSqrt" OnClick="CalculateSQRT"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="RowSixth">
            <asp:TableCell ID="CellResult" ColumnSpan="4">
                <asp:Button Text="=" runat="server" ID="ButtonResult" OnClick="CalculateTotals"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    </form>
</body>
</html>
