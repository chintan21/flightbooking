<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebApplication2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
             
            <br />
            <asp:Label ID="Label5" runat="server" CssClass="btn-primary active focus" Font-Bold="True" Font-Size="21pt" ForeColor="White" Text="Direct Flights:"></asp:Label>
       
             
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="754px"  CssClass= "table table-striped table-bordered table-condensed" OnRowCommand="GridView1_SelectedIndexChanged" >
                <Columns>
                    <asp:ButtonField Text="Book Now" />
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
       
        <p>
            
            &nbsp;</p>
            <p>
            
                <asp:Label ID="Label6" runat="server" CssClass="btn-primary active focus" Font-Bold="True" Font-Size="21pt" ForeColor="White" Text="Flights with 1 stop:"></asp:Label>
            
        </p>
            <p>
            
                &nbsp;</p>
            <p>
            
            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="752px"  CssClass= "table table-striped table-bordered table-condensed" OnRowCommand="GridView2_SelectedIndexChanged">
              
                <Columns>
                    <asp:ButtonField Text="Book Now" />
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
            
        </p>
            <p>
                &nbsp;</p>
              
            <p>
                &nbsp;</p>
       
   

</asp:Content>
