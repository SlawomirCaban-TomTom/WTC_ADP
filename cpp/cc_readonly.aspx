<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="cc_readonly.aspx.cs" Inherits="TomTom_Info_Page.cpp.cc_readonly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br /><asp:Label ID="Label4" runat="server" Text="Committer Controller priorities Read Only" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><br />
  

    <hr />
<asp:Label runat="server" ID="lbl_status_new" Text=""></asp:Label>
  <asp:DataGrid ID="gv_results" runat="server" AutoGenerateColumns="true" O BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
      <AlternatingItemStyle BackColor="White" />
      <FooterStyle BackColor="#CCCC99" />
      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
      <ItemStyle BackColor="#F7F7DE" />
      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
      <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
    <br />
     <asp:Label runat="server" ID="lbl_err" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                    

</asp:Content>
