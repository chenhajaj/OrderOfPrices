<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CSAsite.aspx.cs" Inherits="CSAsite" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2 {
            text-align: center;
            font-family: Helvetica, sans-serif;
            font-size: medium;
        }

        .style3 {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p style="text-align: center" class="style2">
        <strong>You are about to see an example of the comparisson shopping website.<br />
            The main part is the list of prices found. To the right of the list you will see 
        the most current minimum price among those. You do not have o remember the price 
        or the seller&#39;s name, this information is just for your convenience.</strong>
    </p>
    <p style="text-align: center" class="style2">
        &nbsp;
    </p>
    <p style="text-align: center" class="style2">
        <button id="Button2" type="button">I understand</button>
    </p>
    <p style="text-align: center" class="style2">
        &nbsp;
    </p>
    <div style="text-align: center">
        <span style="color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: medium; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 20.479999542236328px; orphans: auto; text-align: center;  white-space: normal; widows: auto;  display: inline !important; float: none; background-color: rgb(255, 255, 255);">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </span>
    </div>
    <p class="style3">
        &nbsp;
    </p>
    <script type="text/jscript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript">

        function redirectToExample() {
            window.location.replace("Example.aspx");
        }
        function OnButtonClick() {
            $("#Button2").attr('disabled', 'disabled');
            setTimeout(redirectToExample, 3000);
            setInterval(OnTimer, 1000);
            OnTimer();
        }
        function OnTimer() {
            timeToRedirect--;
            var msg = "We will start the Hit with the short example, get ready to be redirected in " + timeToRedirect + " seconds";
            $("#MainContent_Label1").text(msg);
        }


        function onLoad() {
            $("#Button2").click(OnButtonClick);
        }
        var timeToRedirect = 4;
        $(document).ready(onLoad);
    </script>
</asp:Content>
