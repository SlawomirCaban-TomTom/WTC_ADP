<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="time.aspx.cs" Inherits="TomTom_Info_Page.WTC.time" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>
   {

        // Your application has indicated there's an error
        window.setTimeout(function () {

            // Move to a new location or you can do something else
            window.location.href = "https://wtcadp.azurewebsites.net/wtc/wtc_main.aspx";

        }, 1500);

    }
</script>
<div style="width:100%;height:100%;position:absolute;z-index:0;overflow:hidden;">
    <img border=0 src="../img/wtc.jpg" width="100%"></div>
    <div style="z-index:1;position:absolute;">
 <asp:Label runat="server" Text="Work Time Controller - WTC 5.0" Font-Bold="True" ForeColor="#996633"></asp:Label>
 <br />
Time is ticking!
</div>
</asp:Content>
