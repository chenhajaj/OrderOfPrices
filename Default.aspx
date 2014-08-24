<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2 {
            text-align:center;
            font-family: Helvetica, sans-serif;
            font-size: medium;
        }

        .style3 {
            text-align: center;
            font-size: large;
        }

        .style4 {
            text-align: center;
            font-size: 1.2em;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="style3">Online shopping experience</h2>
    <p style="text-align: center" class="style2">
        In this HIT you are asked to use a random comparison shopping website.<br />
        Your goal is to minimize the expense in purchasing five different products. 
        <br />
        For each product, the website will find some potential sellers among the many that are out 
        there over the web, returning their prices. 
    </p>
    <p class="style4">
        <strong>Good Luck&nbsp;&nbsp;&nbsp;&nbsp; :)</strong>
    </p>
    <div style="text-align: center">
        <asp:Image ID="Image1" runat="server"
            ImageUrl="~/Images/online_shopping-222.jpg" Height="197px" Width="417px"
            Style="text-align: center" />
    </div>
    <div style="text-align: center">
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="font-size: medium;" Text="go for it" Font-Bold="True" />
    </div>

</asp:Content>
