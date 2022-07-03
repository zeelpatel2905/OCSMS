<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="OCSMS.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divform">
        <div>
            Email ID<br />
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TbUsername"
                ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            Password<br />
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblMsg" runat="server" ForeColor="#CC0000" Text="Label"></asp:Label>
            <br />
            <asp:LinkButton ID="LbForgotPassword" runat="server" OnClick="LbForgotPassword_Click"
                CssClass="LbCss">Forgot Password</asp:LinkButton>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" CssClass="BtnCss" Text="Login" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" CssClass="BtnCss" Text="Reset" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br /><br /><br /><br /><br /><br /><br /><br /><br />
        </div>
    </div>
</asp:Content>
