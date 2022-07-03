<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OCSMS.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    OCSMS - Homepage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <center>
                    <img id="offer" src="Images/laptop-cpu.jpg" alt="p1" /><br />
                    <br />
                </center>
            </div>
            <div class="item">
                <center>
                    <img id="offer" src="Images/dellpc.jpg" alt="p2" /></center>
            </div>
            <div class="item">
                <center>
                    <img id="offer" src="Images/ram.jpg" alt="p3" /></center>
            </div>
        </div>
        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left">
        </span><span class="sr-only">Previous</span> </a><a class="right carousel-control"
            href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
            </span><span class="sr-only">Next</span> </a>
    </div>
    <asp:Image ID="Image2" runat="server" Height="300px" 
        ImageUrl="~/Images/ram1.jpg" Width="300px" />
    <asp:Image ID="Image3" runat="server" Height="300px" 
        ImageUrl="~/Images/key3.jpg" Width="300px" />
    <asp:Image ID="Image4" runat="server" Height="300px" 
        ImageUrl="~/Images/dekstop2.jpg" Width="300px" />
    <asp:Image ID="Image5" runat="server" Height="300px" ImageUrl="~/Images/ram4.jpg" 
        Width="300px" />
    <asp:Image ID="Image6" runat="server" Height="300px" 
        ImageUrl="~/Images/key2.jpg" Width="300px" />
    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Connection %>" 
        SelectCommand="SELECT * FROM [TblProduct]"></asp:SqlDataSource>
</asp:Content>
