<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Specialoffer.aspx.cs" Inherits="WebApplication2.Specialoffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">

                <div class="panel-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
                            </asp:Timer>
                            <asp:Image ID="Image1" runat="server" Height="200px" Width="780px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h3 style="color: white">Concessionary Fare</h3>
                    <div class="row">
                        <div class="col-lg-12">
                            <h4 style="color: white">The following discounts are offered only on the Domestic sectors of Air lines.</h4>
                            <h3 style="color: white">Discounts offered on humanitarian grounds</h3>
                            <h4 style="color:white">
                                <ul>
                                     <li>Blind People Concession</li>
                                     <li>Cancer Patients Concession</li>
                                     <li>Locomotor Disability Concession</li>
                               </h4>

                            <h3 style="color: white">Other Concessions</h3>
                            <h4 style="color:white">
                                <ul>
                                    <li>LTC Concession</li>
                                    <li>Senior Citizen Concession</li>
                                    <li>Student Concession</li>
                                </ul>

                                </h4>
                        </div>
                        
            </div>
        </div>
    </div>
        </div>
    </div>

</asp:Content>
