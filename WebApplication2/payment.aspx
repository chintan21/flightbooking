<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="WebApplication2.payment" %>

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
        <div class="col-md-8">
            <div class="well">
                <h2>PAYMENT OPTIONS</h2>
                <div class="row">
                    <ul class="nav nav-tabs">
                        <li><a data-toggle="tab" href="#home">Credit Card</a></li>
                        <li><a data-toggle="tab" href="#menu1">Debit Card</a></li>
                        <li><a data-toggle="tab" href="#menu2">Net Banking</a></li>
                    </ul>
                </div>
                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <div class="row">
                                    <h3>Credit Card Info</h3>
                                </div>
                                <div class="row">
                                    <h4>
                                        <asp:Label ID="Label1" runat="server" Text="Name On Card"></asp:Label>
                                    </h4>
                                </div>
                                <div class="row">
                                    <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>

                                </div>
                                <div class="row">
                                    <h4>
                                        <asp:Label ID="Label2" runat="server" Text="Card Number"></asp:Label>
                                    </h4>
                                </div>
                                <div class="row">
                                    <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="row">
                                    <div class="col-md-4">
                                        <h4>
                                            <asp:Label ID="Label3" runat="server" Text="Expiration"></asp:Label></h4>
                                    </div>

                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4">
                                        <h4>
                                            <asp:Label ID="Label5" runat="server" Text="cvv no"></asp:Label></h4>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>


                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2022</asp:ListItem>
                                            <asp:ListItem>2023</asp:ListItem>
                                            <asp:ListItem>2024</asp:ListItem>
                                            <asp:ListItem>2025</asp:ListItem>
                                            <asp:ListItem>2026</asp:ListItem>
                                            <asp:ListItem>2027</asp:ListItem>
                                            <asp:ListItem>2028</asp:ListItem>
                                            <asp:ListItem>2029</asp:ListItem>
                                            <asp:ListItem>2030</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>
                                            <asp:ListItem>2032</asp:ListItem>
                                            <asp:ListItem>2033</asp:ListItem>
                                            <asp:ListItem>2034</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="  By checking this box, I agree to the Terms &amp; Conditions &amp; Privacy Policy." />
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-success btn-lg" Text="Make Payment" OnClick="Button1_Click" />

                                </div>

                            </div>
                        </div>
                    </div>


                    <div id="menu1" class="tab-pane fade">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <div class="row">
                                    <h3>Debit Card Info</h3>
                                </div>
                                <div class="row">
                                    <h4>
                                        <asp:Label ID="Label4" runat="server" Text="Name On Card"></asp:Label>
                                    </h4>
                                </div>
                                <div class="row">
                                    <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>

                                </div>
                                <div class="row">
                                    <h4>
                                        <asp:Label ID="Label6" runat="server" Text="Card Number"></asp:Label>
                                    </h4>
                                </div>
                                <div class="row">
                                    <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="row">
                                    <div class="col-md-4">
                                        <h4>
                                            <asp:Label ID="Label7" runat="server" Text="Expiration"></asp:Label></h4>
                                    </div>

                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4">
                                        <h4>
                                            <asp:Label ID="Label8" runat="server" Text="cvv no"></asp:Label></h4>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>


                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2022</asp:ListItem>
                                            <asp:ListItem>2023</asp:ListItem>
                                            <asp:ListItem>2024</asp:ListItem>
                                            <asp:ListItem>2025</asp:ListItem>
                                            <asp:ListItem>2026</asp:ListItem>
                                            <asp:ListItem>2027</asp:ListItem>
                                            <asp:ListItem>2028</asp:ListItem>
                                            <asp:ListItem>2029</asp:ListItem>
                                            <asp:ListItem>2030</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>
                                            <asp:ListItem>2032</asp:ListItem>
                                            <asp:ListItem>2033</asp:ListItem>
                                            <asp:ListItem>2034</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>
                                            <asp:ListItem>2031</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="  By checking this box, I agree to the Terms &amp; Conditions &amp; Privacy Policy." />
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Button ID="Button2" runat="server" class="btn btn-success btn-lg" Text="Make Payment" OnClick="Button1_Click" />

                                </div>

                            </div>
                        </div>
                    </div>

                    <div id="menu2" class="tab-pane fade">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">

                                <div class="row">

                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                        <asp:ListItem>Axis Bank</asp:ListItem>
                                        <asp:ListItem>HDFC Bank</asp:ListItem>
                                        <asp:ListItem>State Bank of India</asp:ListItem>
                                        <asp:ListItem>ICICI Bank</asp:ListItem>
                                        <asp:ListItem>City Bank</asp:ListItem>
                                    </asp:RadioButtonList>


                                </div>


                                <br />
                                <div class="row">
                                    <asp:Button ID="Button3" runat="server" class="btn btn-success btn-lg" Text="Make Payment" OnClick="Button1_Click" />

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="well">
                <h2>BOOKING SUMMARY </h2>
            </div>
        </div>
</asp:Content>
