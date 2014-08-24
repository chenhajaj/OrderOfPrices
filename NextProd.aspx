<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="NextProd.aspx.cs" Inherits="NextProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            font-size: xx-large;
        }

        .style2 {
        }

        .style3 {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <center>
    <p>
        
        <span 
            style="color: rgb(34, 34, 34); font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none; " 
            class="style2"><strong> The random comparison shopping web-site is looking for a new 
        set&nbsp; of sellers.</strong></span>
    </p>
    <p class="style2">
        </span><strong><span class="style3">To save you time, the radom site will look for sellers in the background<br />
            and you will see the bonus you got at the end of the experiment.</span></strong>
    </p>
    <p class="style3">
        You will be redirected to the new scenario with the next product after pressing the button.
    </p>
    <p class="style1">
        <asp:Button ID="Button1" runat="server" CssClass="style2"
            OnClick="Button1_Click" Text="Continue to the next step" />
    </p>
    </center>
    <script type="text/javascript">
        var val = '<%=Session["Procced"] %>';
        if (val == -2)
            setTimeout(function () { window.location.assign('Experiment.aspx'); }, 2000);
    </script>
</asp:Content>
