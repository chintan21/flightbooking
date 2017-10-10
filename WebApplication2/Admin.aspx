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
                        <li><a data-toggle="tab" href="#menu1">Feedbacks</a></li>
                      


                    </ul>


                </div>
                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <div class="row">
                            <div class="col-md-10 col-md-offset-1" style="color: white">
                                <div class="form-group" style="color: white">
                                    <h3>Add Flights</h3>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4>Flight ID
                                            </h4>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-10">
                                            <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Flight id"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4>Air Line</h4>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="air_name" DataValueField="air_name"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [air_name] FROM [airlines] ORDER BY [air_name]"></asp:SqlDataSource>
                                            
                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-6">
                                        <h4>Source</h4>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-6">
                                        <h4>Destination</h4>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [name] FROM [airport] ORDER BY [name]"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-6">
                                        <h4>Departure Time</h4>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-10">
                                            <asp:TextBox ID="TextBox9" class="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox9"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-6">
                                        <h4>Arrival Time</h4>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-10">
                                            <asp:TextBox ID="TextBox10" class="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox10"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-3">
                                        <h4>Class</h4>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                            <asp:ListItem>Business</asp:ListItem>
                                            <asp:ListItem>Economy</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Total seat"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="TextBox2" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>

                                    </div>
                                    <div class="col-md-3">

                                        <asp:TextBox ID="TextBox3" class="form-control" runat="server" placeholder="Price"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="TextBox3" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>

                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-3">
                                        <h4>Class</h4>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                                            <asp:ListItem>Economy</asp:ListItem>
                                            <asp:ListItem>Business</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="TextBox8" class="form-control" runat="server" placeholder="Total seat"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox8"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="TextBox8" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>
                                        

                                    </div>
                                    <div class="col-md-3">

                                        <asp:TextBox ID="TextBox11" class="form-control" runat="server" placeholder="Price"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox11"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="TextBox11" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>

                                    </div>
                                </div>
                                <div class="row" style="color: white">
                                    <div class="col-md-3">
                                        <h4>Luggage</h4>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="TextBox14" class="form-control" runat="server" placeholder="Default "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox14"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox14" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="TextBox12" class="form-control" runat="server" placeholder="Extra "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox12"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox12" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>
                                    </div>
                                    <div class="col-md-3">

                                        <asp:TextBox ID="TextBox13" class="form-control" runat="server" placeholder="Price"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                         ErrorMessage="Required"  ForeColor="Red" Display="Dynamic" ControlToValidate="TextBox13"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox13" Type="Integer" Operator="DataTypeCheck"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Must be a number"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="form-group" style="color: white">
                                    <div class="row">
                                        <div class="col-xs-6 col-xs-offset-6">
                                            <asp:Button ID="Button1" runat="server" Text="Enter to the DATABASE" CssClass="btn btn-primary btn-lg" OnClick="Button1_Click" />
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
                                    <h3>Feedbacks</h3>
                                </div>
                                <div class="form-group" style="color: white">
                                    <div class="row">

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
