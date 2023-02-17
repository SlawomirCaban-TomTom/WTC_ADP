<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master_Page.Master"  CodeBehind="teams_content2.aspx.cs" 
Inherits="TomTom_Info_Page.TEAMS.teams_content2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WTCConnStr %>" 
            SelectCommand="SELECT [ID], [Name], [Domain Name] AS Domain_Name FROM [v_user_team] WHERE ([team_id] = @team_id) ORDER BY [Name]">
            <SelectParameters>
                <asp:QueryStringParameter Name="team_id" QueryStringField="team_id" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label2" runat="server" Text="Coordinator name:"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
            ForeColor="#003399"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
            DataSourceID="SqlDataSource1" GridLines="None" Height="274px" 
            Width="701px" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="ID">
            <RowStyle BackColor="#EFF3FB" BorderStyle="Groove" BorderWidth="1px" 
                HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                <asp:BoundField DataField="Domain_Name" HeaderText="Domain_Name" SortExpression="Domain_Name" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
    <asp:Label runat="server" Text="" id="lbl_done"></asp:Label>
    <br />

     <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Back" />
    </p>
    <asp:Label ID="lbl_err" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>

</asp:Content>