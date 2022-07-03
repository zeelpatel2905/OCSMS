<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddProduct.aspx.cs" Inherits="OCSMS.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    OCSMS - Add Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divform">
        <br />
        Product Name*<br />
        <asp:TextBox ID="TbPName" runat="server" AutoPostBack="True" 
            ontextchanged="TbPName_TextChanged"></asp:TextBox><br />
        <br />
        Type*<br />
        <asp:DropDownList ID="DdPType" runat="server">
            <asp:ListItem Selected="True">Select Type</asp:ListItem>
            <asp:ListItem>Laptop</asp:ListItem>
            <asp:ListItem>Mouse</asp:ListItem>
            <asp:ListItem>Keyboard</asp:ListItem>
            <asp:ListItem>Accessories</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Manufacturer*<br />
        <asp:TextBox ID="TbManuF" runat="server"></asp:TextBox>
        <br />
        <br />
        Image*<br />
        <asp:FileUpload ID="FuImage" runat="server" />
        <br />
        <br />
        Color*<br />
        <asp:TextBox ID="TbColor" runat="server"></asp:TextBox>
        <br />
        <br />
        Price*<br />
        <asp:TextBox ID="TbPrice" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        Quantity*<br />
        <asp:TextBox ID="TbQty" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        Description*<br />
        <asp:TextBox ID="TbDesc" runat="server" Height="60px" TextMode="MultiLine" Width="200px"></asp:TextBox>
        <br />
        <br />
        Status&nbsp;
        <asp:RadioButton ID="RbtActive" runat="server" Text="Active" 
            GroupName="Status" />
        <asp:RadioButton ID="RbtDeactive" runat="server" Text="Deactive" 
            GroupName="Status" />
        <br />
        <asp:HiddenField ID="Hf_PID" runat="server" />
        <br />
        <asp:Label ID="LblMsg" runat="server" Text="Label" CssClass="LbCss"></asp:Label>
        <br />
        <asp:Button ID="BtnSubmit" runat="server" CssClass="BtnCss" Text="Insert" 
            OnClick="BtnSubmit_Click" />
        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update"
            CssClass="BtnCss" Enabled="False" />
        <asp:Button ID="BtnReset" runat="server" CssClass="BtnCss" Text="Reset" 
            onclick="BtnReset_Click" />
        <br />
    </div>
    <asp:DropDownList ID="DdType" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DdType_SelectedIndexChanged">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>Laptop</asp:ListItem>
        <asp:ListItem>Mouse</asp:ListItem>
        <asp:ListItem>Keyboard</asp:ListItem>
        <asp:ListItem>Accessories</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="LblTP" runat="server" Text="Label"></asp:Label>

    <asp:GridView ID="GvProduct" runat="server" OnRowDataBound="GvProduct_RowDataBound"
        BackColor="#D9EAFB" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px"
        CellPadding="500" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" Width="150px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        CommandArgument='<%# Eval("ProductID") %>'
                        onclick="LinkButton2_Click">Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" 
                        CommandArgument='<%# Eval("ProductID") %>' onclick="LinkButton3_Click">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="ProductType" HeaderText="Product Type" />
            <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" />
            <asp:BoundField DataField="Color" HeaderText="Color" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
        </Columns>
        <RowStyle Width="50px" />
    </asp:GridView>
&nbsp;&nbsp;&nbsp; 
</asp:Content>
