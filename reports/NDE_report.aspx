<%@ Page Title="Competence Center NDE report" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="NDE_report.aspx.cs" Inherits="TomTom_Info_Page.reports.NDE_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <asp:Label runat="server" Text="NDE report" Font-Bold="True"></asp:Label>
    <br />
    <hr />
    <br /><br />
<asp:GridView runat="server" ID="gv_results" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="White" />
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <sortedascendingcellstyle backcolor="#FBFBF2" />
    <sortedascendingheaderstyle backcolor="#848384" />
    <sorteddescendingcellstyle backcolor="#EAEAD3" />
    <sorteddescendingheaderstyle backcolor="#575357" />
    </asp:GridView>
    <br />
    <br />
     <asp:Label ID="lbl_err" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
</asp:Content>
