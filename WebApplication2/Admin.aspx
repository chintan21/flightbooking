<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication2.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                <div class="panel-heading">
                    <h3>Add to DataTable</h3>
                </div>
                <div class="panel-body">
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home">Add Flight</a></li>
                        <li><a data-toggle="tab" href="#menu1">Add AirLines</a></li>
                        <li><a data-toggle="tab" href="#menu2">Add Airport</a></li>

                    </ul>
                </div>
                <div class="tab-content">
                     <div id="home" class="tab-pane fade in active">
                          <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group" style="color: white">
                                        <h3>Add Flights</h3>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <h4>Flight ID</h4><br />
                                                <h4>Air Line ID</h4><br />
                                                <h4>Source</h4><br />
                                                <h4>Destination</h4><br />
                                                <h4>Departure Time</h4><br />
                                                <h4>Arrival Time</h4>
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>    
                                                <br />
                                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="air_name" DataValueField="air_name"></asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [air_name] FROM [airlines] ORDER BY [air_name]"></asp:SqlDataSource>
                                                <br />
                                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name"></asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [name] FROM [airport] ORDER BY [name]"></asp:SqlDataSource>
                                                <br />
                                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name"></asp:DropDownList>
                                                <br />
                                                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                                                <br />
                                                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
                                            
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6 col-xs-offset-6">
                                                <asp:Button ID="Button1" runat="server"  Text="Enter to the DATABASE" CssClass="btn btn-primary btn-lg" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>

               
                                </div>
                           </div>
                    </div>
                
                    <div id="menu1" class="tab-pane fade">
                         <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group" style="color: white">
                                        <h3>Add Airlines</h3>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <h4>Enter AIR ID</h4><br />
                                                <h4>Enter AIR NAME</h4>
                                                
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>    
                                                <br />

                                                <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>    
                                                <br />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6 col-xs-offset-6">
                                                <asp:Button ID="Button2" runat="server"  Text="Enter to the DATABASE" CssClass="btn btn-primary btn-lg" />
                                            </div>
                                        </div>
                                    </div>

               
                                </div>
                           </div>
                    </div>
                    <div id="menu2" class="tab-pane fade">
                
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group" style="color: white">
                                        <h3>Add AirPort</h3>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <h4>Enter AIRPORT ID</h4><br />
                                                <h4>Enter AIRPORT NAME</h4>
                                                
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox>    
                                                <br />

                                                <asp:TextBox ID="TextBox7" class="form-control" runat="server"></asp:TextBox>    
                                                <br />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6 col-xs-offset-6">
                                                <asp:Button ID="Button3" runat="server"  Text="Enter to the DATABASE" CssClass="btn btn-primary btn-lg" />
                                            </div>
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
