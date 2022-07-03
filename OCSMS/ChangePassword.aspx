<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OCSMS.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
OCSMS - Change Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divform">
        <div>
            Email ID<br />
            <asp:TextBox ID="TbEmailID" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TbEmailID"
                ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            Old Password<br />
            <asp:TextBox ID="TbOPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <br />
            New Password<br />
            <asp:TextBox ID="TbNpassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TbNpassword"
                ErrorMessage="Password Must Be Alphanumeric" ValidationExpression="[A-Za-z]+[0-9]+"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="LblMsg" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="BtnCss" />
            <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" CssClass="BtnCss" /><br />
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
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
