<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Experiment.aspx.cs" Inherits="Experiment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            font-size: 1.2em;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <center>
    <strong><span class="style1">
    <br />
        Product #</span><asp:Label ID="interationLabel" runat="server"
            Text="Label"></asp:Label>
    </strong>
    <br />
    <asp:Table ID="Table1" runat="server" Height="600px" Width="100%"
        BorderColor="Black" GridLines="Vertical">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server" Width="60%" Height="100%">
                <asp:Panel ID="sellerPricesTextBox" runat="server" Height="100%"
                    ScrollBars="Auto" Width="570px" HorizontalAlign="Center" Font-Size="11pt">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server" Width="40%" Height="100%" HorizontalAlign="Center" Font-Size="11pt">
                The minimum price from the list:&nbsp;&nbsp;<asp:Label ID="minPriceLabel"
                    runat="server" Text=""></asp:Label><br />
                <br />
                <br />
                The name of the store:
                <asp:Label ID="minSellerLabel" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div style="text-align: center">
        <asp:Button ID="Buy" runat="server" OnClick="Buy_Click"
            Text="Proceed" />
    </div>

    <br />
    <br />
    <br />

    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"
        Style="text-align: left"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"
        Style="text-align: left"></asp:Label>
    <br />

    <asp:Button ID="Again" runat="server" OnClick="OnAgainButton_Click" Text="yes, I would like to go through this again"
        Visible="False" />
    <asp:Button ID="Next" runat="server" OnClick="OnNextButton_Click" Text="no, I'm done with this product. Just give me my reward"
        Visible="False" />
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

            if (!sellerPrice)
                return;

            if (sellerPrice.IsLast) {
                clearInterval(timerIntervalHndlr);
                $("#MainContent_Buy").show();
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
            setTimeout(function () { textBox.html(sellerPrices.join('</br>')); }, 100);
        }
        function errorCallback(response) {

            var textBox = $("#MainContent_sellerPricesTextBox");
            var text = textBox.val() + "</br>" + response;
            textBox.val(text);
        }
        function OnTimer() {
            $.ajax({
                type: "POST",
                url: "Experiment.aspx/OnNewPrice",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: callback,
                failure: errorCallback,
            });
        }
        function onLoad() {
            timerIntervalHndlr = setInterval(OnTimer, 250);
            $("#MainContent_Buy").hide();
        }
        $(document).ready(onLoad);
    </script>
</asp:Content>
