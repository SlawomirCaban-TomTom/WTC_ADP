<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ts_dashboard.aspx.cs" Inherits="TomTom_Info_Page.cpp.ts_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type = "text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function SetTargetSelf() {
            document.forms[0].target = "_self";
        }
    </script>

    <br /><asp:Label ID="Label4" runat="server" Text="TS Dashboard" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr />
    Choose database<br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://infopage-lodz.ttg.global/cpp/ts_dashboard.aspx">traffic-signs.cilsxbffebe8.eu-west-1.rds.amazonaws.com</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://infopage-lodz.ttg.global/cpp/ts_dashboard_oce.aspx">moma_ts_oce 172.23.110.177</asp:HyperLink>
    <br />
    <hr />
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/cpp/ts_propagate.aspx" Target="_blank">TS propagate</asp:HyperLink>
<br /><hr />
    <br />
    <asp:DropDownList ID="ddDataset" runat="server" AutoPostBack="True" Height="28px" OnSelectedIndexChanged="ddDataset_SelectedIndexChanged" Width="141px" AppendDataBoundItems="True" Font-Size="Medium" Visible="False">
     <asp:ListItem Text="<All datasets>" Value="0" />
    </asp:DropDownList> from: traffic-signs.cilsxbffebe8.eu-west-1.rds.amazonaws.com  

    <br />
   <asp:GridView runat="server" ID="dgDashboard" OnSorting="GridView_Sorting" AllowSorting="True" AutoGenerateColumns="True" EnableModelValidation="True" BackColor="White" BorderColor="#353481" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Small"  >
       <AlternatingRowStyle BackColor="#F7F7F7" />

       <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="Larger" />
       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
       <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
       <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    
  
    
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
</asp:Content>
