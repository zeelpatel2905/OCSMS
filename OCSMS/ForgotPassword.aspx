<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs" Inherits="OCSMS.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
<div id="divform">
        <div>
            Email ID<br />
            <asp:TextBox ID="TbEmailID" runat="server" TextMode="Email"></asp:TextBox>
            <asp:Button ID="BtnSendOTP" runat="server" Text="Send OTP" OnClick="BtnSendOTP_Click"
                CssClass="BtnCss" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TbEmailID"
                ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            OTP<br />
            <asp:TextBox ID="TbOTP" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TbOTP"
                ErrorMessage="OTP Must Be Of 6 Digit" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
            <br />
            <br />
            New Passsword<br />
            <asp:TextBox ID="TbNPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TbNPassword"
                ErrorMessage="Password Must Be Alphanumeric" ValidationExpression="[A-Za-z]+[0-9]+"></asp:RegularExpressionValidator>
            <br />
            <br />
            User Type<br />
            <asp:DropDownList ID="DdUType" runat="server">
                <asp:ListItem>Select Type</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LblMsg" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click"
                CssClass="BtnCss" />
            <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" CssClass="BtnCss" />
            <br />
        </div>
    </div>
</asp:Content>
