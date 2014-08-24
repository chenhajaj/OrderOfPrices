<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="NoNextProd.aspx.cs" Inherits="NoNextProd" %>

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
        &nbsp;</p>
    <p class="style2">
        <strong><span class="style3">You got your bonus for this product and will be directed to the new<br />
         </span><span class="style3" 
            style="line-height: 115%; font-family: &quot;Segoe UI&quot;,&quot;sans-serif&quot;; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; color: dimgray; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: HE">
        scenario </span><span class="style3">with the next 
        product after pressing the button</span></strong></p>
    <p class="style1">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Continue to the next step" />
    </p>
    </center>
    <script type="text/javascript">
        var val = '<%=Session["Procced"] %>';
        function onLoad() {
            if (val == 1)
                setTimeout(function () { window.location.assign('Experiment.aspx'); }, 2000);
        }
        $(document).ready(onLoad);
    </script>
</asp:Content>
