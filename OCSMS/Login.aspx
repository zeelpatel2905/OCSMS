<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="OCSMS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
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
            Password<br />
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <br />
            <asp:Label ID="LblMsg" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label><br />
            <asp:LinkButton ID="LbForgotPassword" runat="server" OnClick="LbForgotPassword_Click"
                CssClass="LbCss">Forgot Password</asp:LinkButton><br />
            <br />
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" CssClass="BtnCss" />
            <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" CssClass="BtnCss" />
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
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        </div>
    </div>

</asp:Content>
