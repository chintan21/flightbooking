<%@ Page Title="Booking_list" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Mybooking.aspx.cs" Inherits="WebApplication2.Mybooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to cancel ticket?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <asp:Label ID="Label1" runat="server" Text="Booking Details:" CssClass="label-success" Font-Bold="True" Font-Size="18pt"></asp:Label>
     <asp:Button ID="Button15" runat="server" CssClass="btn-default focus"  Text="Cancel Ticket" Width="177px" OnClick="OnConfirm"  OnClientClick="Confirm()" />
    <br />
     <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="1299px" CssClass="table table-striped table-bordered table-condensed" EnableSortingAndPagingCallbacks="True" PageSize="2" OnRowCommand="GridView1_SelectedIndexChanged">
        <Columns>
<asp:ButtonField Text="Select" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>

</asp:Content>
