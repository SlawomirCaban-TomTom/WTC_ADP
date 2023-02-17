<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="caj_dashboard.aspx.cs" Inherits="TomTom_Info_Page.cpp.caj_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <asp:Label ID="Label4" runat="server" Text="CAJ  Dashboard  Prod 3" Font-Size="Larger" Font-Bold="True"></asp:Label>
    <br />
    <hr />
    <br /><strong>caj-production-3-helium.cilsxbffebe8.eu-west-1.rds.amazonaws.com</strong><br />
    <br />
    <asp:DropDownList ID="ddProject" runat="server" AutoPostBack="True" Height="28px" Width="299px" AppendDataBoundItems="True" Font-Size="Medium" OnSelectedIndexChanged="ddProject_SelectedIndexChanged">
        <asp:ListItem Text="<All projects>" Value="0" />
    </asp:DropDownList>
    <br />
    <asp:GridView runat="server" ID="dgDashboard" OnSorting="GridView_Sorting" AllowSorting="True" AutoGenerateColumns="False" EnableModelValidation="True" BackColor="White" BorderColor="#353481" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Large"  >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" SortExpression="name"></asp:BoundField>
            <asp:BoundField DataField="project_id" HeaderText="project_id" ReadOnly="True" SortExpression="project_id"></asp:BoundField>
            <asp:BoundField DataField="commit_requested" HeaderText="commit_requested" ReadOnly="True" SortExpression="commit_requested"></asp:BoundField>
            <asp:BoundField DataField="commit_exception" HeaderText="commit_exception" ReadOnly="True" SortExpression="commit_exception"></asp:BoundField>
            <asp:BoundField DataField="commit_done" HeaderText="commit_done" ReadOnly="True" SortExpression="commit_done"></asp:BoundField>
            </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="Larger" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>


</asp:Content>
