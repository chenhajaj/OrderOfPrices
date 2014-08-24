<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EndExp.aspx.cs" Inherits="EndExp" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: large;
            font-weight: bold;
        }
        .auto-style1 {
            font-size: large;
            font-weight: bold;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <center>
     <p class="style1">
        <strong>Thank you for participating in the experiment :)</strong></p>
    <p class="auto-style1">
        you will recive $0.05 for participating in the HIT and $<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> &nbsp;as the bonus</p>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Collect your reward" />
    <br /></center>
</asp:Content>