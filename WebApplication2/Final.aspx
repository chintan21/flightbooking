<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="WebApplication2.Final" %>

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
            .row.content {
                height: auto;
            }
        }
    </style>
    <div class="col-md-12">
        <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
            <div class="panel-body">

                <div class="col-xs-offset-1 col-md-10">
                    <div class="well">
                        <div class="row">
                            <H1>you put your barcode here</H1>
                        </div>

                        <table class="table table-bordered">
                            <tbody>
                                <tr>
                                    <td>Booking ID:</td>
                                    <td>Class:</td>
                                    <td>Date:</td>
                                </tr>

                                <tr>
                                    <td>Source:</td>
                                    <td>Destination:</td>
                                    <td></td>
                                </tr>

                                <tr>
                                    <td>Departure Time:</td>
                                    <td>Arrival time:</td>
                                    <td></td>
                                </tr>

                                <tr>
                                    <td>Free luggage:</td>
                                    <td>Extra luggage:</td>
                                    <td>Extra luggage fair:</td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td>Grand Total:</td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>

                    </div>

                    <div class="well">
                        <div class="row">
                            <div class="col-md-10">
                        <h1>Thankyou for booking through Udaan..</h1></div>
                        <div class="col-md-2">
                        <asp:Button ID="Button1" runat="server" Text="Print Ticket" class="btn btn-primary"/>
                            </div></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="Label1" runat="server" Text="Your ticket has booked..!"></asp:Label>

    <h1>this is whrer</h1>
    thisis where
</asp:Content>
