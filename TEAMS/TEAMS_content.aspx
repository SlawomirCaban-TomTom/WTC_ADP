<%@ Page Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true"
    CodeBehind="TEAMS_content.aspx.cs" Inherits="TomTom_Info_Page.TEAMS.TEAMS_content"
    Title="Competence Center Info Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Teams details" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="team_id"
        DataSourceID="SqlDataSource1" Height="131px" Width="642px" CaptionAlign="Top"
        CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Left">
        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="Leader Name" HeaderText="Leader Name" SortExpression="Leader Name" />
            <asp:BoundField DataField="Team Name" HeaderText="Team Name" ReadOnly="True" SortExpression="Team Name" />
            <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" />
             <asp:HyperLinkField DataNavigateUrlFormatString="~/TEAMS/TEAMS_content2.aspx?team_id={0}"
                DataNavigateUrlFields="team_id" Text="Details"  />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WTCConnStr %>"
        SelectCommand="select team_id, team_name &quot;Leader Name&quot;, 'Team ' + cast( team_id as nvarchar) &quot;Team Name&quot; ,unit_name Unit from teams t join units u on t.unit_id=u.unit_id 
where team_id not in (200,999)">    </asp:SqlDataSource>    
</asp:Content>
