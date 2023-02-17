<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="mcr_import.aspx.cs" Inherits="TomTom_Info_Page.cpp.mcr_import" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Timer ID="Timer1" runat="server" OnTick="Page_Load" Interval="60000"></asp:Timer>
  <br /><asp:Label ID="Label4" runat="server" Text="MDS Refresher imported runs" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr />
    <br />
    
release: <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList> &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh" />
&nbsp; (autorefresh every minute)<br />
&nbsp;<asp:GridView runat="server" ID="gv" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle Font-Size="Smaller" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" Font-Size="Smaller" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <sortedascendingcellstyle backcolor="#FBFBF2" />
        <sortedascendingheaderstyle backcolor="#848384" />
        <sorteddescendingcellstyle backcolor="#EAEAD3" />
        <sorteddescendingheaderstyle backcolor="#575357" />
</asp:GridView>
    <asp:Label runat="server" Text="Label" ID="lbl_err"></asp:Label>
</asp:Content>
