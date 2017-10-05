<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PassangerDetail.aspx.cs" Inherits="WebApplication2.PassangerDetail" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>
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
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                                    <h4>
                                        <asp:Label ID="Label2" runat="server" Text="" Font-Bold="true"></asp:Label></h4>
                                        <h4><asp:Label ID="Label21" runat="server" Text="" Font-Bold="true"></asp:Label></h4>

                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label3" runat="server" Text="Flight ID"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label></h3>
                                     <h3>
                                       <asp:Label ID="Label22" runat="server" Text=""></asp:Label></h3>
                                </div>

                                <div class="col-sm-2">
                                    <asp:Label ID="Label9" runat="server" Text="Departure Time"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label></h3>
                                      <h3>
                                        <asp:Label ID="Label23" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label11" runat="server" Text="Arrival Time"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label12" runat="server" Text=""></asp:Label></h3>
                                     <h3>
                                        <asp:Label ID="Label24" runat="server" Text=""></asp:Label></h3>
                                </div>
                      
                                <div class="col-sm-2">
                                    <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label16" runat="server" Text=""></asp:Label></h3>
                                     <h3>
                                        <asp:Label ID="Label25" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label19" runat="server" Text="Free Luggage(Total)"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label20" runat="server" Text=""></asp:Label></h3>
                                     <h3>
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label></h3>
                                </div>

                            </div>

                       
                            <div class="row">
                               
                                <div class="col-sm-2">
                                    <asp:Label ID="Label39" runat="server" Text="Adults"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label40" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label41" runat="server" Text="Child"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label42" runat="server" Text=""></asp:Label></h3>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label43" runat="server" Text="Available seats"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label44" runat="server" Text=""></asp:Label></h3>
                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label6" runat="server" Text="Extra luggage"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label></h3>
                                </div>
                               
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label8" runat="server" Text="Price (per KG)"></asp:Label>

                                    <h3>
                                        <asp:Label ID="Label13" runat="server" Text=""></asp:Label></h3>
                                </div>

                                 <div class="col-sm-2">
                                    <asp:Label ID="Label14" runat="server" Text="Enter required luggage"></asp:Label>

                                     <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="true" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            </div>
                        </div>
</asp:Content>
