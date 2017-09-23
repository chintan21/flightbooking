<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Baggage.aspx.cs" Inherits="WebApplication2.Baggage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary" style="background-color: rgba(3, 3, 3, 0.57)">
                
                 <div class="panel-body">
                      <div class="tab-content">
                           
                              <h3 style="color:white"> HAND BAGGAGE (CARRY-ON BAGGAGE )</h3>

                               <div class="row">
                                   <div class="col-lg-12">
                                       <h4 style="color:white">
                                   The dimensions of Hand Baggage that would be applicable for carriage on Air India flights is as given below for both Domestic and International sectors on all AI / Alliance Air flights.
                                   Height 55 cms (22 inches) + Length 35 cms (14 inches) + Width 25 cms (10 inches) for Boeing & Airbus -Total of Dimensions 115 cms
                                   Height 55 cms (22 inches) + Length 35 cms (14 inches) + Width 20 cms (08 inches) for ATR -Total 11O cms
                                   The maximum permitted weight for Hand Baggage is 8 Kgs per passenger.
                               </h4>
                                     </div>
                                 </div>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cabin-baggage.png" />

                               <h4 style="color:white"><p>
                                   Children are entitled to the same cabin baggage allowance as adults.
                                   When an infant (not entitled to a seat or free baggage allowance) accompanies an adult, a carrycot, or a fully collapsible push chair/stroller is allowed. This may be carried in the cabin if space is available, or else as checked baggage.
                                   An odd sized cabin baggage not conforming to the specified dimension will not be allowed in the cabin. Such baggage will be removed and will be loaded in the hold, as per rules.
                                   </p>
                               </h4>
                          
                          </div>
                 </div>
            </div>
            </div>
        </div>
</asp:Content>
