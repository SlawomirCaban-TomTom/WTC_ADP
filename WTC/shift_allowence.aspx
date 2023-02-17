<%@Page Title="shift_allowence" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="shift_allowence.aspx.cs" Inherits="TomTom_Info_Page.WTC.shift_allowence" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
//          function openCalendar1() {

//              window.open('calendar.aspx?Ctlid=<%=tb_start_date1.ClientID %>', 'Calendar', 'scrollbars=no,resizable=no,width=450,height=250');
//              return false;
//          }
//          function openCalendar2() {

//              window.open('calendar.aspx?Ctlid=<%=tb_end_date1.ClientID %>', 'Calendar', 'scrollbars=no,resizable=no,width=450,height=250');
//              return false;
//          }
          
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bgimg"> 
  
  <asp:Label ID="Label11" runat="server" Text="Work Time Controler - WTC 5.0" Font-Bold="True" ForeColor="#996633"></asp:Label>
        <br />
        <asp:Menu Visible="false" ID="Menu_mng1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
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
<td><asp:TextBox runat="server" id="tb_start_date1" 
        ontextchanged="on_tb_date_update1"></asp:TextBox>
         <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                    TargetControlID="tb_start_date1" Format="yyyy-MM-dd">
                                                </asp:CalendarExtender>
</td>
<td><%--<asp:Button ID="Button111" runat="server" Text="..." 
        OnClientClick="javascript:return openCalendar1();" onclick="Button111_Click"></asp:Button>--%></td>
<td class="style5"></td>
<td>end date:</td>
<td><asp:TextBox runat="server" id="tb_end_date1" 
        ontextchanged="on_tb_date_update1"></asp:TextBox>

        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                    TargetControlID="tb_end_date1" Format="yyyy-MM-dd">
                                                </asp:CalendarExtender>
</td>
<td><%--<asp:Button ID="Button22" runat="server" Text="..." 
        OnClientClick="javascript:return openCalendar2();" onclick="Button22_Click"></asp:Button>--%></td>

</tr></table>
<br />
<asp:Panel runat="server" id="p_user1" visible="false">
<table style="width: 496px">
<tr>
<%--<td class="style1">
Team
</td>--%>
<td></td>
<%--<td>
User
</td>--%>
</tr>
<tr>
<td class="style1"><%--<asp:DropDownList runat="server" id="ddl_team1" 
        AutoPostBack="True" onselectedindexchanged="ddl_team1_SelectedIndexChanged"></asp:DropDownList>--%>

</td>
<td></td>
<td><%--<asp:DropDownList runat="server" id="ddl_user1" AutoPostBack="True" 
        onselectedindexchanged="ddl_user1_SelectedIndexChanged"></asp:DropDownList>--%>

</td>
</tr>
</table>
</asp:Panel>
<table>
<tr>
<%--<td class="style2">tool
</td>--%>
<td>
</td>
<%--<td class="style3">Project</td>--%>
<td>
</td>
<%--<td class="style4">Task</td>--%>
<td>
</td>
<%--<td class="style4">Sub Task</td>--%>
<td>
</td>
<%--<td class="style4">Category</td>--%>
</tr>
<tr>
<td class="style2"><%--<asp:DropDownList runat="server" id="ddl_tool1" Width="220px"  
        AutoPostBack="True" onselectedindexchanged="ddl_tool1_SelectedIndexChanged" ></asp:DropDownList>--%>
</td>
<td>
</td>
<td class="style3"><%--<asp:DropDownList runat="server" id="ddl_project1" Width="220px"  
        AutoPostBack="True" onselectedindexchanged="ddl_project1_SelectedIndexChanged" ></asp:DropDownList>--%></td>
<td>
</td>
<td class="style4">
    <%--<asp:DropDownList runat="server" id="ddl_task1" 
        Width="171px"  AutoPostBack="True" 
        onselectedindexchanged="ddl_task1_SelectedIndexChanged" ></asp:DropDownList>--%></td>
        <td>
</td>
       <%-- <td class="style4">
    <asp:DropDownList runat="server" id="ddl_sub_task1" 
        Width="171px"  AutoPostBack="True" 
        onselectedindexchanged="ddl_sub_task1_SelectedIndexChanged" ></asp:DropDownList></td>--%>
        <td>
</td>
        <td class="style4">
    <%--<asp:DropDownList runat="server" id="ddl_category" 
        Width="171px"  AutoPostBack="True" 
        onselectedindexchanged="ddl_category_SelectedIndexChanged" ></asp:DropDownList>--%></td>
</tr>
</table>
<hr />
<br />
<table>
<tr>
<td><asp:Button ID="Button33" runat="server" Text="Run Query" onclick="Unnamed33_Click"></asp:Button>
</td>

<td><asp:Button ID="Button44" runat="server" Text="Reset Filter" onclick="Unnamed44_Click"></asp:Button>
</td>

<%--<td><asp:Button ID="Button55" runat="server" Text="Dump" visible="false" onclick="Unnamed55_Click"></asp:Button>
</td>--%>

<td><asp:Button runat="server" Text="Dump" OnClick="Unnamed1_Click"></asp:Button></td></tr></table>
<br />
<asp:GridView runat="server" id="gv_data111"  HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"  RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            EnableModelValidation="True"  GridLines="Horizontal" 
            AllowPaging="True" AllowSorting="True" 
            onpageindexchanging="OnPageIndexChanging" 
            onsorting="gridView1_Sorting" EnableViewState="true" 
            PageSize="100" Visible="False">
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <%--<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />--%>
    <PagerSettings Mode="NumericFirstLast" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <br />
        <br />
<asp:GridView runat="server" id="GridView1" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            EnableModelValidation="True" ForeColor="Black" GridLines="Horizontal" 
            AllowPaging="True" AllowSorting="True" 
            onpageindexchanging="gridView1_PageIndexChanging" 
            onsorting="gridView1_Sorting" EnableViewState="true" 
            PageSize="70">
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerSettings Mode="NumericFirstLast" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <br />

<asp:Label runat="server" id="lbl_results1" Font-Bold="True" 
            ></asp:Label>
<br />
<asp:Label runat="server" id="lbl_err1" Font-Bold="True" ForeColor="Red" 
            Visible="False" ></asp:Label>
</div>
</asp:Content>
