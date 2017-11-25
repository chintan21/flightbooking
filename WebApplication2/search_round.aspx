<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search_round.aspx.cs" Inherits="WebApplication2.search_round" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

      y<style>
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {
        height: 100%;
        background-color: #f1f1f1;
   
            }
    
    /* Set gray background color and 100% height */
    .sidenav {
      background-color: #f1f1f1;
      height: 100%;
    }
        
    /* On small screens, set height to 'auto' for the grid */
    @media screen and (max-width: 767px) {
      .row.content {height: auto;} 
    }
  </style><div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="well">
                            <div class="row">
                                <div class="col-sm-2">
                                    <asp:Label ID="Label1" runat="server" Text="Round trip"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label3" runat="server" Text="Departure"></asp:Label>
                                    <h3><asp:Label ID="Label4" runat="server" Text=""></asp:Label></h3>
                                </div>

                                   <div class="col-sm-2">
                                    <asp:Label ID="Label6" runat="server" Text="Return"></asp:Label>
                                    <h3><asp:Label ID="Label12" runat="server" Text=""></asp:Label></h3>
                                </div>

                                <div class="col-sm-2">
                                    <asp:Label ID="Label5" runat="server" Text="Class"></asp:Label>
                                   <h3> <asp:Label ID="Label7" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label8" runat="server" Text="Adluts"></asp:Label>
                                   <h3> <asp:Label ID="Label9" runat="server" Text=""></asp:Label></h3>
                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label10" runat="server" Text="Child"></asp:Label>
                                   <h3> <asp:Label ID="Label11" runat="server" Text=""></asp:Label></h3>
                                </div>
                               
                           </div>

                             <div class="col-sm-9">

                                    <div class="row">
                                         

        

                        </div>
</div>
                            </div>
   

           
                       
</div>
    
       
                     
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="601px" CssClass="table table-striped table-bordered table-condensed" HorizontalAlign="Left" OnRowCommand="GridView1_SelectedIndexChanged">
       
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
   

   

                 <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="610px" CssClass="table table-striped table-bordered table-condensed" HorizontalAlign="Right" OnRowCommand="GridView2_SelectedIndexChanged" Enabled="false">
       
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
                </div>
           </div>
      </div>
      </div>
   
   
 
   
</asp:Content>
