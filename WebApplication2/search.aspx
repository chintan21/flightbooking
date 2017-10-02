<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebApplication2.WebForm5" %>

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
                                <div class="col-sm-2">
                                    <asp:Label ID="Label1" runat="server" Text="One Way"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label3" runat="server" Text="Departure"></asp:Label>
                                    <h3><asp:Label ID="Label4" runat="server" Text=""></asp:Label></h3>
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
                                <div class="col-sm-2">
                                    <asp:Button ID="Button1" runat="server" Text=" + Modify Search" OnClick="Button1_Click" />
                                </div>
                            </div>

                        </div>


                        <div class="container-fluid">
                            <div class="row content">
                                <div class="col-sm-3 sidenav">
                                    <img src="Images/udaan_logo.png" height="50px";width="80px" />
                                    <ul class="nav nav-pills nav-stacked">
                                        <!--<li><a>
                                            <asp:Label ID="Label12" runat="server" Text="Departure Time From Pune"></asp:Label></a></li>-->
                                        <li><a>
                                            <h4><asp:Label ID="Label13" runat="server" Text="Airlines"></asp:Label></h4>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-xs-9">
                                                        <img src="Images/airindia.png" height="30px" width="30px" />
                                                <asp:Label ID="Label14" runat="server" Text="   AirIndia"></asp:Label>
                                                        </div>
                                                    <div class="col-xs-1">
                                                        <asp:CheckBox ID="CheckBox5" runat="server" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" />
                                                    </div>
                                                </div>
                                            </div>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-xs-9">
                                                        <img src="Images/indigo.png" height="30px" width="30px" />
                                                <asp:Label ID="Label6" runat="server" Text="   Indigo"></asp:Label>
                                                        </div>
                                                    <div class="col-xs-1">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" />
                                                    </div>
                                                </div>
                                            </div>
                                        </a></li>
                                        
                                        <li><a>
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-xs-9">
                                                        <img src="Images/jetairways.png" height="30px" width="30px"/>
                                                        <asp:Label ID="Label15" runat="server" Text="   JetAirways"></asp:Label>
                                                    </div>
                                                    <div class="col-xs-1">
                                                        <asp:CheckBox ID="CheckBox6" runat="server" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" />
                                                    </div>
                                                </div>
                                                
                                                
                                            </div>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-xs-9">
                                                        <img src="Images/spicejet.jpg" height="30px" width="30px" />
                                                <asp:Label ID="Label16" runat="server" Text="  SpiceJet  "></asp:Label>
                                                    </div>
                                                    <div class="col-xs-1">
                                                
                                                <asp:CheckBox ID="CheckBox7" runat="server" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged"/>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                        </a></li>
                                        <li><a>
                                            <div class="well">
                                                <div class="row">
                                                    <div class="col-xs-9">
                                                        <img src="Images/goair.png" height="30px" width="30px" />
                                                <asp:Label ID="Label17" runat="server" Text="  GoAir"></asp:Label>
                                                
                                                    </div>
                                                    <div class="col-xs-1">
                                                        <asp:CheckBox ID="CheckBox8" runat="server" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" />
                                                    </div>
                                                </div>
                                                
                                            </div>
                                        </a></li>
                                    </ul>
                                    <br>
                                </div>
                                <br />
                                <div class="col-sm-9">

                                    <div class="row">


    <br />
    <h2><asp:Label ID="Label55" runat="server"  Text="Direct Flights:" CssClass="label label-default"></asp:Label></h2>
    <br />

    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="754px" CssClass="table table-striped table-bordered table-condensed" OnRowCommand="GridView1_SelectedIndexChanged" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
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
        &nbsp;
    </p>
    <p>

        <h2><asp:Label ID="Label66" runat="server" Text="Flights with 1 stop:" CssClass="label label-default"></asp:Label></h2>

    </p>
    <p>
        &nbsp;
    </p>
    <p>

        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="752px" CssClass="table table-striped table-bordered table-condensed" OnRowCommand="GridView2_SelectedIndexChanged">

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
        &nbsp;
    </p>

    <p>
        &nbsp;
    </p>

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
