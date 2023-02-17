<%@ Page Title="WTC History" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="history.aspx.cs" Inherits="TomTom_Info_Page.WTC.history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 148px;
        }
        .style2
        {
            width: 201px;
        }
        .style3
        {
            width: 152px;
        }
        .style4
        {
            width: 135px;
        }
        .style5
        {
            width: 128px;
        }

        .bgimg {
            background-image: url('../img/wtc.jpg');
            background-size: contain;
        }
    </style>
      <script language="javascript" type="text/javascript">
          function openCalendar1() {

              window.open('calendar.aspx?Ctlid=<%=tb_start_date.ClientID %>', 'Calendar', 'scrollbars=no,resizable=no,width=450,height=250');
              return false;
          }
          function openCalendar2() {

              window.open('calendar.aspx?Ctlid=<%=tb_end_date.ClientID %>', 'Calendar', 'scrollbars=no,resizable=no,width=450,height=250');
              return false;
          }
          
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bgimg"> 
  <asp:Label runat="server" Text="Work Time Controller - WTC 5.0" Font-Bold="True" ForeColor="#996633"></asp:Label>
        <br />
        <asp:Menu Visible="false" ID="Menu_mng" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
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
        <asp:Menu Visible="true" ID="menu_std" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
                <asp:MenuItem NavigateUrl="~/WTC/wtc_main.aspx" Text="WTC Main Page" Value="WTC Main Page"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/history.aspx" Text="History" Value="1"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/back_dated_entry.aspx" Text="Back dated entry" Value="Back dated entry"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WTC/leaves_history.aspx" Text="Leaves History" Value="Leaves History"></asp:MenuItem>
              </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
<hr />
<table>
<tr>
<td>Start date:</td>
<td><asp:TextBox runat="server" id="tb_start_date" 
        ontextchanged="on_tb_date_update"></asp:TextBox>
</td>
<td><asp:Button runat="server" Text="..." OnClientClick="javascript:return openCalendar1();"></asp:Button></td>
<td class="style5"></td>
<td>end date:</td>
<td><asp:TextBox runat="server" id="tb_end_date" 
        ontextchanged="on_tb_date_update"></asp:TextBox>
</td>
<td><asp:Button runat="server" Text="..." OnClientClick="javascript:return openCalendar2();"></asp:Button></td>

</tr></table>
<br />
<asp:Panel runat="server" id="p_user" visible="false">
<table style="width: 496px">
<tr>
<td class="style1">
Team
</td>
<td></td>
<td>
User
</td>
</tr>
<tr>
<td class="style1"><asp:DropDownList runat="server" id="ddl_team" 
        AutoPostBack="True" onselectedindexchanged="ddl_team_SelectedIndexChanged"></asp:DropDownList>

</td>
<td></td>
<td><asp:DropDownList runat="server" id="ddl_user" AutoPostBack="True" 
        onselectedindexchanged="ddl_user_SelectedIndexChanged"></asp:DropDownList>

</td>
</tr>
</table>
</asp:Panel>
<table>
<tr>
<td class="style2">
Project</td>
<td>
</td>
<td class="style3">Task</td>
<td>
</td>
<td class="style4">Sub Task</td>
</tr>
<tr>
<td class="style2"><asp:DropDownList runat="server" id="ddl_project" Width="220px"  
        AutoPostBack="True" onselectedindexchanged="ddl_project_SelectedIndexChanged" ></asp:DropDownList>
</td>
<td>
</td>
<td class="style3"><asp:DropDownList runat="server" id="ddl_task" Width="220px"  
        AutoPostBack="True" onselectedindexchanged="ddl_task_SelectedIndexChanged" ></asp:DropDownList></td>
<td>
</td>
<td class="style4">
    <asp:DropDownList runat="server" id="ddl_sub_task" 
        Width="171px"  AutoPostBack="True" 
        onselectedindexchanged="ddl_sub_task_SelectedIndexChanged" ></asp:DropDownList></td>
</tr>
</table>
<hr />
<br />
<table>
<tr>
<td><asp:Button runat="server" Text="Run Query" onclick="Unnamed3_Click"></asp:Button>
</td>

<td><asp:Button runat="server" Text="Reset Filter" onclick="Unnamed4_Click"></asp:Button>
</td>

<td><asp:Button runat="server" Text="Dump" onclick="Unnamed5_Click"></asp:Button>
</td></tr></table>
<br />
<asp:GridView runat="server" id="gv_data" CellPadding="4" ForeColor="#333333" GridLines="Vertical" 
            AllowPaging="True" AllowSorting="True" 
            onpageindexchanging="gridView_PageIndexChanging" 
            onsorting="gridView_Sorting" 
            PageSize="70">
    <AlternatingRowStyle BackColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <sortedascendingcellstyle backcolor="#F8FAFA" />
    <sortedascendingheaderstyle backcolor="#246B61" />
    <sorteddescendingcellstyle backcolor="#D4DFE1" />
    <sorteddescendingheaderstyle backcolor="#15524A" />
        </asp:GridView>
        <br />
<asp:Label runat="server" id="lbl_results" Font-Bold="True" 
            ></asp:Label>
<br />
<asp:Label runat="server" id="lbl_err" Font-Bold="True" ForeColor="Red" 
            Visible="False" ></asp:Label>
</div>
</asp:Content>
