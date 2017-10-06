<%@ Page Title="search flight" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                <div class="panel-heading">
                    <h3>Book a Flight</h3>
                </div>

                <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group" style="color: white">
                                        <h4>
                                        
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1" CssClass="radio radiobuttonlist col-sm-9"  Width="500px">
                                          
                                              <asp:ListItem Selected="True" Text="One Way"></asp:ListItem>
                                              <asp:ListItem Text="         Round Trip"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        </h4>
                                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                                    
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

                                    <div class="form-group" style="color: black">
                                        <div class="row">
                                            <div class="col-xs-6">

                                                <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" CssClass="form-control"></asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [name] FROM [airport] ORDER BY [name]"></asp:SqlDataSource>

                                            </div>
                                            <div class="col-xs-6">
                                                <asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" CssClass="form-control"></asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [name] FROM [airport] ORDER BY [name]"></asp:SqlDataSource>
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
                                                
                                                                <table>
                                                                    <tr>
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th></th>
                                                                    </tr>
                                                                    <tr>
                                                                    <td colspan="8">
                                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calaend.jpg" Height="30px" Width="30px" OnClick="ImageButton1_Click" />
                                                                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged">
                                                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                                        <OtherMonthDayStyle ForeColor="#999999" />
                                                                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                                        <TodayDayStyle BackColor="#CCCCCC" />
                                                                    </asp:Calendar>
                                                                    </td>
                                                                       </tr></table>
                                                                    
                                                </div>
                                            <div class="col-xs-6">
                                                    <table><tr><td colspan="4">
                                                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                               </td>
                                                        <td>
                                                                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/calaend.jpg" Height="30px" Width="30px" OnClick="ImageButton4_Click" />
                                                                    <asp:Calendar ID="Calendar4" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar4_SelectionChanged">
                                                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                                        <OtherMonthDayStyle ForeColor="#999999" />
                                                                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                                        <TodayDayStyle BackColor="#CCCCCC" />
                                                                    </asp:Calendar>
                                                
                                                        </td>
                                                           </tr></table>
                                                                    
                                                
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

                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>


                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                        <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>


                                                    </asp:DropDownList>


                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                                        <asp:ListItem>Economy</asp:ListItem>
                                                        <asp:ListItem>Business</asp:ListItem>

                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="TextBox3" class="form-control" runat="server">Promotional Code</asp:TextBox>
                                            </div>
                                            <div class="col-sm-6">

                                                <asp:Button ID="OnewaySearch" class="btn btn-primary" runat="server" Text="Search Flights" OnClick="OnewaySearch_Click" />



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
