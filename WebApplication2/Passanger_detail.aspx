<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Passanger_detail.aspx.cs" Inherits="WebApplication2.Passanger_detail" %>

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
                    <div class="col-xs-offset-1 col-md-10">
                        <div class="well">
                            <div class="row">
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label1" runat="server" Text="One Way"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label3" runat="server" Text="Flight ID"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label4" runat="server" Text=""></asp:Label></h3>
                                </div>
                               
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label9" runat="server" Text="Departure Time"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label10" runat="server" Text=""></asp:Label></h3>
                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label11" runat="server" Text="Arrival Time"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label12" runat="server" Text=""></asp:Label></h3>
                                </div>
                                     <div class="col-sm-2">
                                    <asp:Label ID="Label13" runat="server" Text="Price"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label14" runat="server" Text=""></asp:Label></h3>
                                </div>
                                     <div class="col-sm-2">
                                    <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label16" runat="server" Text=""></asp:Label></h3>
                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label5" runat="server" Text="Adults"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label6" runat="server" Text=""></asp:Label></h3>
                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label7" runat="server" Text="Child"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label8" runat="server" Text=""></asp:Label></h3>
                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label17" runat="server" Text="Available seats"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label18" runat="server" Text=""></asp:Label></h3>
                                </div>
                                     <div class="col-sm-2">
                                    <asp:Label ID="Label19" runat="server" Text="Free Luggage(Total)"></asp:Label>
                                    
                                    <h3><asp:Label ID="Label20" runat="server" Text=""></asp:Label></h3>
                                </div>

                            </div>

                        </div>

                        <div class="well">
                            <div class="table-responsive">
                                <table class="table">

                                    <caption>Passenger Details</caption>

                                    <thead>
                                        <tr>
                                            <th>S no.</th>
                                            <th>Name</th>
                                            <th>Age</th>
                                            <th>Gender</th>
                                            <th>ID Card Type</th>
                                            <th>ID Card No.</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td>
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                                        <asp:ListItem>PAN Card</asp:ListItem>
                                                        <asp:ListItem>Draving license</asp:ListItem>
                                                        <asp:ListItem>Passport</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>
                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                                        <asp:ListItem>PAN Card</asp:ListItem>
                                                        <asp:ListItem>Draving license</asp:ListItem>
                                                        <asp:ListItem>Passport</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>3</td>
                                            <td>
                                                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                                        <asp:ListItem>PAN Card</asp:ListItem>
                                                        <asp:ListItem>Draving license</asp:ListItem>
                                                        <asp:ListItem>Passport</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>4</td>
                                            <td>
                                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList7" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList8" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                                        <asp:ListItem>PAN Card</asp:ListItem>
                                                        <asp:ListItem>Draving license</asp:ListItem>
                                                        <asp:ListItem>Passport</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>5</td>
                                            <td>
                                                <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList9" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList10" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                                        <asp:ListItem>PAN Card</asp:ListItem>
                                                        <asp:ListItem>Draving license</asp:ListItem>
                                                        <asp:ListItem>Passport</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>

                                        
                                        <tr>
                                            <td>6</td>
                                            <td>
                                                <asp:TextBox ID="TextBox16" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox17" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList11" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList12" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem>Aadhar Card</asp:ListItem>
                                                        <asp:ListItem>PAN Card</asp:ListItem>
                                                        <asp:ListItem>Draving license</asp:ListItem>
                                                        <asp:ListItem>Passport</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TextBox18" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>

                                    </tbody>

                                </table>
                            </div>
                        </div>

                        
                        <div class="well">
                            <div class="table-responsive">
                                <table class="table">

                                    <caption>Children Below 5 Years</caption>

                                    <thead  style="text-align:center">
                                        <tr >
                                            <th>S no.</th>
                                            <th>Name</th>
                                            <th>Age</th>
                                            <th>Gender</th>
                                            
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td>
                                                <asp:TextBox ID="TextBox19" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox20" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList13" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                           <tr>
                                            <td>2</td>
                                            <td>
                                                <asp:TextBox ID="TextBox21" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox22" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList14" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       

                                    </tbody>

                                </table>
                            </div>
                        </div>

                        
                        <div class="well">
                            <div class="row">
                                <h4>Contact Detials</h4>
                            </div>
                             <div class="row">

                                <div class="col-sm-6">
                                    <div class="col-xs-8">
                                    <asp:TextBox ID="TextBox23" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                </div>
                                <div class="col-sm-6">
                                    <p>Your Mobile number will be used only for sending flight related communication.</p>
                                </div>
                                
                            </div>

                        </div>
                        <asp:Button ID="Button2" runat="server" Text="Make Payment" CssClass="btn btn-danger btn-lg" OnClick="Button2_Click" />
                       
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
