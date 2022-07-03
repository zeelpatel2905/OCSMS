<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddtoCart.aspx.cs" Inherits="OCSMS.AddtoCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="200px" Width="200px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer"></asp:BoundField>
            <asp:BoundField DataField="Color" HeaderText="Color" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("CartID") %>'
                        OnClick="LinkButton2_Click">Remove</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="LblTotal" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="LblNo" runat="server" Font-Size="X-Large" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="BtnCart" Text="Checkout" />
    <br />
    <br />
    <asp:Button ID="BtnCS" runat="server" CssClass="BtnCss" OnClick="BtnCS_Click" Text="Continue to shopping" />
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
</asp:Content>
