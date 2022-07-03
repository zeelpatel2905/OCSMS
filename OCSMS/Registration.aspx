<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OCSMS.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
OCSMS - Registration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divform">
        <div>
            First Name
            <asp:TextBox ID="TbFirstName" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Last Name
            <asp:TextBox ID="TbLastName" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Gender&nbsp;
            <asp:RadioButton ID="RbtMale" GroupName="Gender" runat="server" Text="Male" />
            &nbsp;
            <asp:RadioButton ID="RbtFemale" GroupName="Gender" runat="server" Text="Female" />
            <br />
            <br />
            <br />
            Email ID
            <asp:TextBox ID="TbEmailID" runat="server" TextMode="Email"></asp:TextBox>
            &nbsp; <asp:Button ID="BtnSendOTP" runat="server" Text="Send OTP" OnClick="BtnSendOTP_Click"
                CssClass="BtnCss" />
            &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TbEmailID"
                ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            &nbsp;<br />
            <br />
            OTP
            <asp:TextBox ID="TbOTP" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TbOTP"
                ErrorMessage="OTP Must Be Of 6 Digit" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            Contact No
            <asp:TextBox ID="TbContactNo" runat="server" TextMode="Phone"></asp:TextBox>
            &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TbContactNo"
                ErrorMessage="Contact No Must Be Of 10 Digit" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
            <br />
            &nbsp;<br />
            <br />
            Password&nbsp;
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TbPassword"
                ErrorMessage="Password Must Be Alphanumeric" ValidationExpression="[A-Za-z]+[0-9]+"></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            User Type
            <asp:DropDownList ID="DdUser" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LblMsg" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click"
                CssClass="BtnCss" />
            <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" CssClass="BtnCss" />
        </div>
    </div>
</asp:Content>