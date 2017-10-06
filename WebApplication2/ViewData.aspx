<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewData.aspx.cs" Inherits="WebApplication2.ViewData" %>

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
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                <div class="panel-heading">
                    <h3>Add to DataTable</h3>
                </div>
                <div class="panel-body">
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home">View Flight Table</a></li>
                        <li><a data-toggle="tab" href="#menu1">View Airport Table</a></li>

                    </ul>
                </div>
                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <div class="row">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="form-group" style="color: white">
                                    <h3>Total Available flights</h3>
                                  <div class="well">
                                         <asp:GridView ID="GridView1" runat="server"  BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="754px" CssClass="table table-striped table-bordered table-condensed"
                        AllowPaging="True" AutoGenerateColumns="False"  DataKeyNames="fid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" DeleteCommand="DELETE FROM [flights] WHERE [fid] = @original_fid AND [air_id] = @original_air_id AND [src_airp] = @original_src_airp AND [dest_airp] = @original_dest_airp AND [dept_time] = @original_dept_time AND [arr_time] = @original_arr_time" InsertCommand="INSERT INTO [flights] ([fid], [air_id], [src_airp], [dest_airp], [dept_time], [arr_time]) VALUES (@fid, @air_id, @src_airp, @dest_airp, @dept_time, @arr_time)" SelectCommand="SELECT * FROM [flights] ORDER BY [src_airp], [dest_airp]" UpdateCommand="UPDATE [flights] SET [air_id] = @air_id, [src_airp] = @src_airp, [dest_airp] = @dest_airp, [dept_time] = @dept_time, [arr_time] = @arr_time WHERE [fid] = @original_fid AND [air_id] = @original_air_id AND [src_airp] = @original_src_airp AND [dest_airp] = @original_dest_airp AND [dept_time] = @original_dept_time AND [arr_time] = @original_arr_time" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="original_fid" Type="String" />
                            <asp:Parameter Name="original_air_id" Type="String" />
                            <asp:Parameter Name="original_src_airp" Type="String" />
                            <asp:Parameter Name="original_dest_airp" Type="String" />
                            <asp:Parameter DbType="Time" Name="original_dept_time" />
                            <asp:Parameter DbType="Time" Name="original_arr_time" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="fid" Type="String" />
                            <asp:Parameter Name="air_id" Type="String" />
                            <asp:Parameter Name="src_airp" Type="String" />
                            <asp:Parameter Name="dest_airp" Type="String" />
                            <asp:Parameter DbType="Time" Name="dept_time" />
                            <asp:Parameter DbType="Time" Name="arr_time" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="air_id" Type="String" />
                            <asp:Parameter Name="src_airp" Type="String" />
                            <asp:Parameter Name="dest_airp" Type="String" />
                            <asp:Parameter DbType="Time" Name="dept_time" />
                            <asp:Parameter DbType="Time" Name="arr_time" />
                            <asp:Parameter Name="original_fid" Type="String" />
                            <asp:Parameter Name="original_air_id" Type="String" />
                            <asp:Parameter Name="original_src_airp" Type="String" />
                            <asp:Parameter Name="original_dest_airp" Type="String" />
                            <asp:Parameter DbType="Time" Name="original_dept_time" />
                            <asp:Parameter DbType="Time" Name="original_arr_time" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                                  </div>   
                                
                                </div>
                            </div>
                        </div>
                    </div>

                 
                    <div id="menu1" class="tab-pane fade">

                        <div class="row">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="form-group" style="color: white">
                                    <h3>Add AirPort</h3>
                               
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource2">
                                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                                        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                                        <RowStyle BackColor="#EFF3FB"></RowStyle>

                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                                        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                                        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                                        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                                    </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2"></asp:SqlDataSource>
                                </div>
                               

                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
