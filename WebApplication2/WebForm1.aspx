<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server" Height="73px" Width="254px" CssClass="table">

        <asp:TableRow runat="server" ID="TableRow1">
            <asp:TableCell>1</asp:TableCell>
            <asp:TableCell>Azure</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" ID="TableRow2">
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>Azure</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" ID="TableRow3">
            <asp:TableCell>3</asp:TableCell>
            <asp:TableCell>Azure</asp:TableCell>
        </asp:TableRow>
    </asp:Table>


    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


</asp:Content>
