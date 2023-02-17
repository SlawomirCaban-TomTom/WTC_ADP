<%@ Page Title="WTC Manage Project" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="edit_project.aspx.cs" Inherits="TomTom_Info_Page.WTC.edit_project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">
    .style1
    {
        width: 329px;
    }
    .bgimg {
    background-image: url('../img/wtc.jpg');
    background-size: contain;
}
</style>
    <div class="bgimg"> 
    <asp:Label runat="server" Text="Work Time Controller - WTC 5.0" Font-Bold="True" ForeColor="#996633"></asp:Label>
       <br />
        <asp:Menu ID="Menu_mng" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
                <asp:MenuItem NavigateUrl="~/WTC/wtc_main.aspx" Text="WTC Main Page" Value="WTC Main Page"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/history.aspx" Text="History" Value="1"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/edit_project.aspx" Text="Manage Existing Projects" Value="Manage Existing Projects"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/new_project.aspx" Text="Add New Project" Value="Add New Project"></asp:MenuItem>
             <asp:MenuItem NavigateUrl="~/WTC/back_dated_entry.aspx" Text="Back dated entry" Value="Back dated entry"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/WTC/leaves_history.aspx" Text="Leaves History" Value="Leaves History"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/shift_allowence.aspx" Text="Shift Allowence" Value="Shift Allowence"></asp:MenuItem>
         
              </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
<h3>Projects:</h3>

        <br />
        <table>
             <tr>
                 <td>        <asp:DropDownList ID="ddl_pu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_pu_SelectedIndexChanged" Width="136px"></asp:DropDownList></td>
<td>        <asp:DropDownList ID="ddl_state" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged">
    <asp:ListItem Selected="True">Only Active Projects</asp:ListItem>
    <asp:ListItem>All Projects</asp:ListItem>
    </asp:DropDownList></td>
                <td><asp:Button ID="Button1" runat="server" Text="Reset Filter" OnClick="Button1_Click1" /></td>
                
            </tr>
        </table>
        <br />
<asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        DataKeyNames="project_id" ForeColor="Black" GridLines="Horizontal">
    <Columns>
        <asp:BoundField DataField="project_id" HeaderText="project_id" 
            InsertVisible="False" ReadOnly="True" SortExpression="project_id" 
            Visible="False"></asp:BoundField>
        <asp:BoundField DataField="project_name" HeaderText="project_name" 
            SortExpression="project_name"></asp:BoundField>
       <asp:BoundField DataField="PU" HeaderText="PU" SortExpression="PU">
        </asp:BoundField>
        <asp:HyperLinkField ShowHeader="False" Text="Details" DataNavigateUrlFields="project_id" DataNavigateUrlFormatString="project_details.aspx?ID={0}"></asp:HyperLinkField>
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
        <br />
        <asp:Label ID="lbl_status" runat="server" Text=""  Font-Bold="true"></asp:Label>
        <br />

        <asp:Label ID="lbl_err" runat="server" Text="" Visible="false" Font-Bold="true" ForeColor="Red"></asp:Label>
</div>
</asp:Content>
