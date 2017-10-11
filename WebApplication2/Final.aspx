<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="WebApplication2.Final" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <script type="text/javascript">
	function printDiv(divName) {
     var printContents = document.getElementById(divName).innerHTML;
     var originalContents = document.body.innerHTML;

     document.body.innerHTML = printContents;
     window.print();
     document.body.innerHTML = originalContents;
}
</script>
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
            .row.content {
                height: auto;
            }
        }

  
    </style>
    <div id="printableArea" class="col-md-12">
        <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
            <div class="panel-body">
                <div class="col-xs-offset-1 col-md-10">
                    <div class="well">
                        <div class="row">
                          <asp:Image ID="Image1" runat="server"></asp:Image>

                        </div>

                        <table class="table table-bordered">
                            <tbody>
                                <tr>
                                    <td>Booking ID:
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                                    <td>Class: <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                                    <td>Date: <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Source: <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                                    <td>Destination: <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                                    <td><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Departure Time: <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                                    <td>Arrival time: <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                                    <td>Flight ID:<asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Free luggage: <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                                    <td>Extra luggage:<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
                                    <td>Extra luggage fair: <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td>Grand Total: <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
<h3>Passanger Details:</h3>
                        <asp:GridView ID="GridView1" runat="server" Height="112px" Width="754px">
                        </asp:GridView>


                        <br />


  <asp:GridView ID="GridView2" runat="server" Height="112px" Width="757px">
       
    </asp:GridView>
                    </div>

                   
                </div>
            </div>
        </div>
    </div>
     <div class="well">
                        <div class="row">
                            <div class="col-md-10">
                        <h1>Thankyou for booking through Udaan..</h1>
                 <input id="Button1" type="button" value="print" class="btn btn-primary" onclick="printDiv('printableArea')" />  
                            </div>
                        <div class="col-md-2">


                        </div></div>
                    </div>
                               


    

    
</asp:Content>
