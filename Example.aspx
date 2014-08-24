<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Example.aspx.cs" Inherits="Example" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: 1.2em;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <strong><span class="style1">
    <br />
        <center>
            Example</span></strong><br />
    <asp:Table ID="Table1" runat="server" Height="600px" Width="100%" 
        BorderColor="Black" GridLines="Vertical">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="60%" Height="100%">
                <asp:Panel ID="sellerPricesTextBox" runat="server" Height="100%" HorizontalAlign="Center" Font-Size="11pt"
        ScrollBars="Auto" Width="570px">
    </asp:Panel></asp:TableCell>
            <asp:TableCell runat="server" Width="40%" Height="100%" HorizontalAlign="Center" Font-Size="11pt"> 
                The minimum price from the list:&nbsp;&nbsp;
                <asp:Label ID="minPriceLabel" 
    runat="server" Text=""></asp:Label><br /><br /><br />
The name of the store:
<asp:Label ID="minSellerLabel" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div align=center>
<asp:Button ID="Buy" runat="server" onclick="Buy_Click" 
    Text="Proceed to the next step" />
    </div>
    <br />
    <br />
    <br />
     <div align=center>
    <asp:Label ID="Message" runat="server" Text="You will be directed to our comparison shopping website to see the prices we found for the first product when pressing the above button. "  Visible="False" 
        style="text-align: left"></asp:Label>
        </div>
    <br />
    <br />
    </center>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script>
        var minPrice = 10000000;
        var sellerPrices = [];
        var timerIntervalHndlr;
        String.prototype.trim = function () { return this.replace('/^\s+|\s+$/g', ''); };
        function callback(args) {
            var sellerPrice = args.d;

            if(!sellerPrice)
                return;

            if(sellerPrice.IsLast)
            {
                clearInterval(timerIntervalHndlr);
                 $("#MainContent_Buy").show     ();
                return;
            }


            if (sellerPrice.Price < minPrice) {
                minPrice = sellerPrice.Price;
                //update min price
                $("#MainContent_minPriceLabel").html(sellerPrice.Price);
                $("#MainContent_minSellerLabel").html(sellerPrice.Seller);
            }

            var textBox = $("#MainContent_sellerPricesTextBox");

            //create simple span with id
            var spanId = 'price' + sellerPrices.length;

            var span = '<span id="' + spanId + '">' + sellerPrice.Seller + ' - ' + sellerPrice.Price + '</span>';

            //insert into array
            sellerPrices.splice(sellerPrice.Index, 0, span);            

            //add to textbox
            textBox.html(sellerPrices.join('</br>'));

            //color
            $('#' + spanId).css('color', 'red');

            //reset to textbox
            setTimeout(function () { textBox.html(sellerPrices.join('</br>')); }, 500);
        }
        function errorCallback(response) {
            
            var textBox = $("#MainContent_sellerPricesTextBox");
            var text = textBox.val() + "</br>" +response;
            textBox.val(text);
        }
        function OnTimer(){
            $.ajax({
                type: "POST",
                url: "Example.aspx/OnNewPrice",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: callback,
                failure: errorCallback,
            });
        }


        function onLoad() {
            timerIntervalHndlr = setInterval(OnTimer, 500);
             $("#MainContent_Buy").hide();
        }
        $(document).ready(onLoad);  
    </script>
</asp:Content>
