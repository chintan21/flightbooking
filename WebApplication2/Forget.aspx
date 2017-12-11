<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="WebApplication2.Forget" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <div class="well-sm">
<asp:Label ID="Label1" runat="server" Text="Enter username: " CssClass="label-default" Font-Size="X-Large" ForeColor="#FF3300"></asp:Label>
<br />
<asp:TextBox ID="TextBox1" runat="server" TextMode="Email" CssClass="form-control" Width="300px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Get OTP" CssClass="btn-group-xs" OnClick="Button1_click" />
                <asp:Button ID="Button2" runat="server" Text="Resend OTP" CssClass="btn-group-xs" OnClick="Button1_click" />

</div>
                </tr>

        <tr>
            <asp:Label ID="Label2" runat="server" Text="Enter OTP:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="300px" AutoPostBack="true" OnTextChanged="OTP_check"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Enter New Password:" Visible="false"></asp:Label>

            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="form-control" Width="300px" Visible="false"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="Re-Enter New Password:" Visible="false"></asp:Label>

           <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" CssClass="form-control" Width="300px" Visible="false"></asp:TextBox>

        <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="btn-group-xs" OnClick="Button3_click" Visible="false" />

        </tr>
    </table>

</asp:Content>
