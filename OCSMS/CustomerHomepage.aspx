<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="CustomerHomepage.aspx.cs" Inherits="OCSMS.CustomerHomepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    OCSMS - Customer Homepage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    Search: 
    <asp:TextBox ID="TbSearch" runat="server" 
    ontextchanged="TbSearch_TextChanged" AutoPostBack="True"></asp:TextBox>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="1"
        RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <img width="200" src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' />
            <br />
            Name:
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Manufacture:<asp:Label ID="ManufacturerLabel" runat="server" Text='<%# Eval("Manufacturer") %>' />
            <br />
            Color:
            <asp:Label ID="ColorLabel" runat="server" Text='<%# Eval("Color") %>' />
            <br />
            Price:
            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
            <br />
            Quantity:
            <asp:TextBox ID="TbQty" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            Description:
            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
            <br />
            <asp:Button ID="BtnAC" runat="server" CommandName="addtocart" Text="Add To Cart"
                CommandArgument='<%#Eval("ProductID")%>' CssClass="BtnCart" />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Connection %>"
        
        SelectCommand="SELECT * FROM [TblProduct] WHERE ([Name] LIKE '%' + @Name + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="TbSearch" DefaultValue="%" Name="Name" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
