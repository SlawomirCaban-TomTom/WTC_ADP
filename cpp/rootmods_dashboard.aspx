<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="rootmods_dashboard.aspx.cs" Inherits="TomTom_Info_Page.cpp.rootmods_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><asp:Label ID="Label4" runat="server" Text="Mods" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr /><br />
    <strong>Data generated based on data from darts.projectproductionmetricdaily
This table is updated 3x per week, if more often will be needed, let us know.</strong><br /><br />
   
    <br /><br /> <asp:Label runat="server" Text="Label" id="Label"></asp:Label>
   <asp:GridView runat="server" ID="dgDashboard" OnSorting="GridView_Sorting" AllowSorting="True" AutoGenerateColumns="True" EnableModelValidation="True" BackColor="White" BorderColor="#353481" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Large"  >
       <AlternatingRowStyle BackColor="#F7F7F7" />
     
       <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="Larger" />
       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
       <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
       <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    
  
    
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
</asp:Content>
