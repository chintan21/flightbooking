<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contact_us.aspx.cs" Inherits="WebApplication2.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>so finally u reached out to me</p>
  <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                
                 <div class="panel-body">
                      <div class="tab-content">
                          <p>
                              <h3 style="color:white">If you have any questions regarding our products or services, please contact us by calling or e-mailing us. We will get back to you as soon as possible.</h3>
                          </p>
                          
                          <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <h4>Name</h4>
                                            </div>
                                            <div class="col-xs-6">
                                                <h4>Contact No</h4>
                                            </div>
                                        </div>
                                    </div>
                           <div class="form-group" style="color: black">
                                        <div class="row">
                                            <div class="col-xs-6">
                                                <div class="col-xs-8">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                                </div>
                                        <div class="col-xs-6">
                                            <div class="col-xs-8">    
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            </div>
                                        </div>
                                    </div>

                           <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <h4>Email ID</h4>
                                            </div>
                                            <div class="col-sm-6">
                                                <h4>Country</h4>
                                       </div>
                                        </div>
                                    </div>

                          <div class="form-group" style="color: white">
                                        <div class="row">
                                            <div class="col-xs-6">

      
                                                </div>
                                            </div>
                              </div>
                          </div>
                          

</asp:Content>
