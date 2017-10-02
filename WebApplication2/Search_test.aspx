<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search_test.aspx.cs" Inherits="WebApplication2.Search_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
  </style>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="well">
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Label1" runat="server" Text="One Way"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="Pune to Kolkata"></asp:Label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="Label3" runat="server" Text="Departure"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="Label5" runat="server" Text="Adult Child Class"></asp:Label>
                                    <asp:Button ID="Button1" runat="server" Text=" + Modify Search" />
                                </div>
                            </div>

                        </div>


                        <div class="container-fluid">
                            <div class="row content">
                                <div class="col-sm-3 sidenav">
                                    <h2>Logo</h2>
                                    <ul class="nav nav-pills nav-stacked">
                                        <li><a>
                                            <asp:Label ID="Label12" runat="server" Text="Departure Time From Pune"></asp:Label></a></li>
                                        <li><a>
                                            <asp:Label ID="Label13" runat="server" Text="Airlines"></asp:Label>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                                                <asp:CheckBox ID="CheckBox5" runat="server" />
                                            </div>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                                                <asp:CheckBox ID="CheckBox6" runat="server" />
                                            </div>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                                <asp:CheckBox ID="CheckBox7" runat="server" />
                                            </div>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                                                <asp:CheckBox ID="CheckBox8" runat="server" />
                                            </div>
                                        </a></li>
                                    </ul>
                                    <br>
                                </div>
                                <br />
                                <div class="col-sm-9">

                                    <div class="row">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="fid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="fid" HeaderText="fid" ReadOnly="True" SortExpression="fid" />
                                                <asp:BoundField DataField="air_id" HeaderText="air_id" SortExpression="air_id" />
                                                <asp:BoundField DataField="src_airp" HeaderText="src_airp" SortExpression="src_airp" />
                                                <asp:BoundField DataField="dest_airp" HeaderText="dest_airp" SortExpression="dest_airp" />
                                                <asp:BoundField DataField="dept_time" HeaderText="dept_time" SortExpression="dept_time" />
                                                <asp:BoundField DataField="arr_time" HeaderText="arr_time" SortExpression="arr_time" />
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT * FROM [flights]"></asp:SqlDataSource>
                                    </div>


                                  <div class="row">
                                      <div class="table-responsive">
                                <table class="table">

                                    <caption>Children Below 5 Years</caption>

                                    <thead style="text-align: center">
                                        <tr>
                                            <th>S no.</th>
                                            <th>Name</th>
                                            <th>Age</th>
                                            <th>Gender</th>

                                        </tr>
                                    </thead>


                                    <tbody>
                                        <tr id="Tr5" runat="server">
                                            <td>5</td>
                                            <td>2</td>
                                            <td>3</td>
                                            <td>4</td>
                                        </tr>
                                       <tr id="Tr1" runat="server">
                                            <td>1</td>
                                            <td>2</td>
                                            <td>3</td>
                                            <td>4</td>
                                        </tr>
                                           
                                           <tr id="Tr4" runat="server">
                                            <td>4</td>
                                            <td>2</td>
                                            <td>3</td>
                                            <td>4</td>
                                        </tr>
                                    
                                    
                                    </tbody>

                                </table>
                            </div>
                        </div>

                                      <div class="row">
                                          <asp:Table ID="Table1" runat="server" Height="73px" Width="254px" CssClass="table">
                                              
                                              <asp:TableRow runat="server" ID="TableRow1">
                                                  <asp:TableCell>1</asp:TableCell>
                                                  <asp:TableCell>Azure</asp:TableCell>
                                              </asp:TableRow>
                                              <asp:TableRow runat="server" ID="TableRow2">
                                                  <asp:TableCell>2</asp:TableCell>
                                                  <asp:TableCell>Azure</asp:TableCell>
                                              </asp:TableRow>
                                          <asp:TableRow runat="server" ID="TableRow3" >
                                                  <asp:TableCell>3</asp:TableCell>
                                                  <asp:TableCell>Azure</asp:TableCell>
                                              </asp:TableRow>
                                          </asp:Table>
                                      </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
