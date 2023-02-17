<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="slf_dashboard_kor.aspx.cs" Inherits="TomTom_Info_Page.cpp.slf_dashboard_kor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <br /><asp:Label ID="Label4" runat="server" Text="SLF Dashboard KOREA" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr /><br />
    <strong>speed-limit-fusion.cryfuxgcs7ds.ap-northeast-2.rds.amazonaws.com</strong><br /><br />
    <asp:DropDownList ID="ddDataset" runat="server" AutoPostBack="True" Height="28px" OnSelectedIndexChanged="ddDataset_SelectedIndexChanged" Width="141px" AppendDataBoundItems="True" Font-Size="Medium">
     <asp:ListItem Text="<All datasets>" Value="0" />
    </asp:DropDownList>

    <br />
   <asp:GridView runat="server" ID="dgDashboard" OnSorting="GridView_Sorting" AllowSorting="True" AutoGenerateColumns="False" EnableModelValidation="True" BackColor="White" BorderColor="#353481" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Large"  >
       <AlternatingRowStyle BackColor="#F7F7F7" />
      <Columns>
            <asp:BoundField DataField="dataset" HeaderText="dataset" ReadOnly="True" SortExpression="dataset"></asp:BoundField>
            <asp:BoundField DataField="beforesquash" HeaderText="beforesquash" ReadOnly="True" SortExpression="beforesquash"></asp:BoundField>
            <asp:BoundField DataField="total" HeaderText="total" ReadOnly="True" SortExpression="total"></asp:BoundField>
            <asp:BoundField DataField="readytorun" HeaderText="readytorun" ReadOnly="True" SortExpression="readytorun"></asp:BoundField>
            <asp:BoundField DataField="sentforcommit" HeaderText="sentforcommit" ReadOnly="True" SortExpression="sentforcommit"></asp:BoundField>
            <asp:BoundField DataField="success" HeaderText="success" ReadOnly="True" SortExpression="success"></asp:BoundField>
            <asp:BoundField DataField="processing" HeaderText="processing" ReadOnly="True" SortExpression="processing"></asp:BoundField>
            <asp:BoundField DataField="failed" HeaderText="failed" ReadOnly="True" SortExpression="failed"></asp:BoundField>
            <asp:BoundField DataField="commitfailed" HeaderText="commitfailed" ReadOnly="True" SortExpression="commitfailed"></asp:BoundField>
            <asp:BoundField DataField="qa" HeaderText="qa" ReadOnly="True" SortExpression="qa"></asp:BoundField>
          <asp:BoundField DataField="speed>max" HeaderText="speed>max" ReadOnly="True" SortExpression="speed>max"></asp:BoundField>
          <asp:BoundField DataField="500" HeaderText="500" ReadOnly="True" SortExpression="500"></asp:BoundField>
            <asp:BoundField DataField="tooshort" HeaderText="tooshort" ReadOnly="True" SortExpression="tooshort"></asp:BoundField>
            <asp:BoundField DataField="outdated" HeaderText="outdated" ReadOnly="True" SortExpression="outdated"></asp:BoundField>
            <asp:BoundField DataField="decode" HeaderText="decode" ReadOnly="True" SortExpression="decode"></asp:BoundField>
            <asp:BoundField DataField="generatedfallout" HeaderText="generatedfallout" ReadOnly="True" SortExpression="generatedfallout"></asp:BoundField>
          <asp:BoundField DataField="resolvedfallout" HeaderText="resolvedfallout" ReadOnly="True" SortExpression="resolvedfallout"></asp:BoundField>
          <asp:BoundField DataField="falloutiniris" HeaderText="falloutiniris" ReadOnly="True" SortExpression="falloutiniris"></asp:BoundField>
        </Columns>
       <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="Larger" />
       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
       <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
       <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    
  
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
</asp:Content>
