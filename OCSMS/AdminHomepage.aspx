<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHomepage.aspx.cs" Inherits="OCSMS.AdminHomepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
OCSMS - Admin Homepage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
   <asp:GridView ID="GvProduct" runat="server" OnRowDataBound="GvProduct_RowDataBound"
        BackColor="#D9EAFB" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px"
        CellPadding="500">
        <Columns>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" Width="150px" />
                </ItemTemplate>
            </asp:TemplateField>
       
            
       
        </Columns>
        <RowStyle Width="50px" />
    </asp:GridView>
</asp:Content>
