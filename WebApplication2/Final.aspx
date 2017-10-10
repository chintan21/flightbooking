<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="WebApplication2.Final" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="printableArea">

    <asp:Label ID="Label1" runat="server" Text="Your ticket has booked..!"></asp:Label>
        <asp:Image ID="Image1" runat="server" />
       
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    <script type="text/javascript">
	function printDiv(divName) {
     var printContents = document.getElementById(divName).innerHTML;
     var originalContents = document.body.innerHTML;
     document.body.innerHTML = printContents;
     window.print();
     document.body.innerHTML = originalContents;
}
</script>
    <input id="Button1" type="button" value="button" onclick="printDiv('printableArea')" value="print a div!"/>
</asp:Content>
