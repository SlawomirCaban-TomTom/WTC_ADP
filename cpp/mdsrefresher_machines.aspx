<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="mdsrefresher_machines.aspx.cs" Inherits="TomTom_Info_Page.cpp.mdsrefresher_machines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><asp:Label ID="Label4" runat="server" Text="MDS contentrefresher machines status" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr />
    <asp:Button runat="server" Text="Refresh" ID="Button2" OnClick="refresh_Click"></asp:Button>
     &nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://infopage-lodz.ttg.global/cpp/mdsrefresher_dashboard_aws.aspx" Target="_blank">View dashboard  </asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://infopage-lodz.ttg.global/cpp/mdsrefresher_dashboard.aspx" Target="_blank">View dashboard (old)</asp:HyperLink>
     <asp:GridView runat="server" ID="dgDashboard" EnableModelValidation="True" CellPadding="4" Font-Size="Medium" ForeColor="#333333" GridLines="None"  >
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <EditRowStyle BackColor="#999999" />
         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <br />
    <hr />


    <asp:Button runat="server" Text="View basic" ID="refresh" OnClick="refresh_Click" Visible="False"></asp:Button>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View details" Visible="False" />
    <br /><br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Enabled="False" EnableTheming="True" Height="700px" Width="1184px" Visible="False"></asp:TextBox>
   
   <asp:label runat="server" ID="lblError"></asp:label>
       <asp:Timer ID="Timer1" runat="server" OnTick="Page_Load" Interval="70000"></asp:Timer>
</asp:Content>
