<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="slf_dashboard.aspx.cs" Inherits="TomTom_Info_Page.cpp.slf_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><asp:Label ID="Label4" runat="server" Text="SLF Dashboard" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr /><br />
    <strong>rdb.slf.v2.prd.adans.tthad.net</strong><br /><br />
    <asp:DropDownList ID="ddDataset" runat="server" AutoPostBack="True" Height="28px" OnSelectedIndexChanged="ddDataset_SelectedIndexChanged" Width="141px" AppendDataBoundItems="True" Font-Size="Medium" Visible="False">
     <asp:ListItem Text="<All datasets>" Value="0" />
    </asp:DropDownList>

    <br /><br /> <asp:Label runat="server" Text="Label" id="Label"></asp:Label>
   <asp:GridView runat="server" ID="dgDashboard" OnSorting="GridView_Sorting" AllowSorting="True" AutoGenerateColumns="False" EnableModelValidation="True" BackColor="White" BorderColor="#353481" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Large"  >
       <AlternatingRowStyle BackColor="#F7F7F7" />
      <Columns>
            <asp:BoundField DataField="dataset" HeaderText="dataset" ReadOnly="True" SortExpression="dataset"></asp:BoundField>
            <asp:BoundField DataField="to_do" HeaderText="to do" ReadOnly="True" SortExpression="to_do"></asp:BoundField>
            <asp:BoundField DataField="in_progress" HeaderText="in progress" ReadOnly="True" SortExpression="in_progress"></asp:BoundField>
          <asp:BoundField DataField="tech_fallout" HeaderText="tech_fallout" ReadOnly="True" SortExpression="tech_fallout"></asp:BoundField>
          <asp:BoundField DataField="qa_fallout" HeaderText="qa_fallout" ReadOnly="True" SortExpression="qa_fallout"></asp:BoundField>
            <asp:BoundField DataField="success" HeaderText="success" ReadOnly="True" SortExpression="success"></asp:BoundField>
            <asp:BoundField DataField="percent_of_fallout" HeaderText="% of fallout" ReadOnly="True" SortExpression="percent_of_fallout"></asp:BoundField>
            
        </Columns>
       <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="Larger" />
       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
       <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
       <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    
  
    
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
</asp:Content>
