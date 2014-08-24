<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Experiment is starting.aspx.cs" Inherits="Experiment_is_starting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <p style="text-align: center">
        Great, the HIT with the first product will start in 3 seconds
    </p>
    <script type="text/javascript">
        setTimeout(function () { window.location.assign('Experiment.aspx'); }, 3000);
    </script>
</asp:Content>
