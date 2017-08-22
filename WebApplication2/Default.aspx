<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                <div class="panel-heading">
                    <h3>Book a Flight</h3>
                </div>
                <div class="panel-body">
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home">One Way</a></li>
                        <li><a data-toggle="tab" href="#menu1">Round Trip</a></li>

                    </ul>

                    <div class="tab-content">
                        <div id="home" class="tab-pane fade in active">


                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group" style="color: white">
                                        <h3>One Way Trip</h3>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <h4>From</h4>
                                            </div>
                                            <div class="col-xs-6">
                                                <h4>to</h4>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox1" class="form-control" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <h4>Depart</h4>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <input class="form-control" id="datepicker" name="Text" type="text" value="mm/dd/yyyy" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'mm/dd/yyyy';}" required="">
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <h4>Adult:(12+ yrs)</h4>
                                            </div>
                                            <div class="col-sm-4">
                                                <h4>Child:(2-11 yrs)</h4>
                                            </div>
                                            <div class="col-sm-4">
                                                <h4>Class</h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <select class="form-control" id="sel1" onchange="run()" >
                                                        <option>1</option>
                                                        <option>2</option>
                                                        <option>3</option>
                                                        <option>4</option>
                                                        <option>5</option>
                                                        <option>6</option>
                                                        <option>7</option>
                                                        <option>8</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <select class="form-control" id="sel2">
                                                        <option>0</option>
                                                        <option>1</option>
                                                        <option>2</option>
                                                        <option>3</option>
                                                        <option>4</option>
                                                        <option>5</option>
                                                        <option>6</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">

                                                    <select class="form-control" id="sel3">
                                                        <option>Economy</option>
                                                        <option>Business</option>
                                                       
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color:white">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="TextBox3" class="form-control" runat="server">Promotional Code</asp:TextBox>
                                            </div> 
                                            <div class="col-sm-6">
                                                <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Search Flights" OnClick="Button1_Click" />
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
                                        <h3>Round Way Trip</h3>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <h4>From</h4>
                                            </div>
                                            <div class="col-xs-6">
                                                <h4>to</h4>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <h4>Depart</h4>
                                            </div>
                                            <div class="col-sm-6">
                                                <h4>Return</h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <input class="form-control" id="datepicker1" name="Text" type="text" value="mm/dd/yyyy" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'mm/dd/yyyy';}" required="">
                                            </div>
                                            <div class="col-xs-6">
                                                <input class="form-control" id="datepicker2" name="Text" type="text" value="mm/dd/yyyy" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'mm/dd/yyyy';}" required="">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <h4>Adult:(12+ yrs)</h4>
                                            </div>
                                            <div class="col-sm-4">
                                                <h4>Child:(2-11 yrs)</h4>
                                            </div>
                                            <div class="col-sm-4">
                                                <h4>Class</h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <select class="form-control" id="sel4">
                                                        <option>1</option>
                                                        <option>2</option>
                                                        <option>3</option>
                                                        <option>4</option>
                                                        <option>5</option>
                                                        <option>6</option>
                                                        <option>7</option>
                                                        <option>8</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <select class="form-control" id="sel5">
                                                        <option>0</option>
                                                        <option>1</option>
                                                        <option>2</option>
                                                        <option>3</option>
                                                        <option>4</option>
                                                        <option>5</option>
                                                        <option>6</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">

                                                    <select class="form-control" id="sel6">
                                                        <option>Economy</option>
                                                       
                                                        <option>Business</option>
                                                      
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color:white">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="TextBox6" class="form-control" runat="server">Promotional Code</asp:TextBox>
                                            </div> 
                                            <div class="col-sm-6">
                                                <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Search Flights" OnClick="Button2_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    

                                  
                                </div>
                            </div>
                        </div>

                        <script src="js/jquery-ui.js"></script>
                        <link href="css/jquery-ui.css" rel="stylesheet" />
                        <script>
                            $(function () {
                                $("#datepicker,#datepicker1,#datepicker2,#datepicker3").datepicker();
                            });
                        </script>



                    </div>
                </div>
            </div>
        </div>
    </div>

   
</asp:Content>
