<%@ Page Title="Active ADP members" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="adp_activity.aspx.cs" Inherits="TomTom_Info_Page.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br /><asp:Label ID="Label4" runat="server" Text="Active ADP members" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr /><br />
  

      <asp:DataGrid ID="gv_results" runat="server"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
      <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
      <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
      <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
      <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
       
    </asp:DataGrid>
    <br />
     <asp:Label runat="server" ID="lbl_err" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
</asp:Content>
