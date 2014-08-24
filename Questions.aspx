<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Questions.aspx.cs" Inherits="Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <p class="style1">
        <br />
        <asp:Image ID="Screenshot" runat="server" ImageAlign="AbsMiddle" Height="489px"
            ImageUrl="~/Images/screenshot.jpg" />
    </p>
    <p class="style1">
        Please answer the following questions acoording to the above screenshot taken from the previous example
    </p>
    <p class="style1">
        What is the minimal price that was found?
    </p>
    <div style="text-align: center">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <p class="style1">
        How are the results sorted?
    </p>

    <div style="text-align: center">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="918px">
            <asp:ListItem>By price</asp:ListItem>
            <asp:ListItem>By seller's name</asp:ListItem>
        </asp:RadioButtonList>
    </div>

    <div style="text-align: center">
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click"
            Text="Submit answers" />
    </div>
</asp:Content>
