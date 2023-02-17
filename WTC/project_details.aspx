<%@ Page Title="WTC Project Details"  MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="project_details.aspx.cs" Inherits="TomTom_Info_Page.WTC.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 61px;
        }
        .auto-style1 {
            width: 122px;
        }
        .auto-style3 {
            width: 205px;
        }
        .auto-style4 {
            width: 142px;
        }
        .auto-style5 {
            width: 169px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">
    .style1
    {
        width: 329px;
    }

    .bgimg {
    background-image: url('../img/wtc.jpg');
    background-size:cover;
}
         .auto-style7 {
             width: 169px;
             height: 23px;
         }
         .auto-style8 {
             width: 142px;
             height: 23px;
         }
         .auto-style9 {
             width: 205px;
             height: 23px;
         }
         .auto-style11 {
             width: 122px;
             height: 23px;
         }
         .auto-style12 {
             width: 162px;
             height: 23px;
         }
         .auto-style13 {
             width: 162px;
         }
         .auto-style14 {
             margin-right: 180px;
         }
         .auto-style15 {
             width: 356px;
         }
         .auto-style16 {
             width: 224px;
         }
     </style>
    <div class="bgimg"> 
    <asp:Label runat="server" Text="Work Time Controller - WTC 5.0" Font-Bold="True" ForeColor="#996633"></asp:Label>        <br />
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
<h3>Update Project:</h3>
<br />
<table>
<tr>
<td class="auto-style16">Attribute</td>
<td>Current Value</td>
<td class="style1"></td>
<td class="auto-style15">New Value</td>
<td></td>
</tr>
<tr>

<td class="auto-style16">
<asp:Label runat="server" Text="Project Name:" ></asp:Label>
</td>
<td>
<asp:Label runat="server" Text="" id ="lbl_p_name" ></asp:Label>

</td>
<td class="style1"></td>
<td class="auto-style15"><asp:TextBox runat="server" id="tb_p_name" Width="345px"></asp:TextBox>
</td>
<td><asp:Button runat="server" Text="Update" onclick="Unnamed4_Click"></asp:Button> </td>
</tr>

<tr>

<td class="auto-style16">
<asp:Label runat="server" Text="PU:" ></asp:Label>
<td>
<asp:Label runat="server" Text="" id ="lbl_pu" ></asp:Label>

</td>
<td class="style1"></td>
<td class="auto-style15"><asp:DropDownList runat="server" id='ddl_pu' AutoPostBack="True" Width="345px"></asp:DropDownList>
</td>
<td><asp:Button runat="server" Text="Update" onclick="Unnamed12_Click"></asp:Button> </td>
</tr>

</table>
<br />
<h5> Available tasks:</h5>
        <asp:checkbox runat="server" ID="cb_nonactive" AutoPostBack="True" Checked="True" OnCheckedChanged="Unnamed14_CheckedChanged" Text="Hide non Active Tasks"></asp:checkbox>
<br />

        <br />

<asp:DataGrid id="gv_tasks" runat="server" AutoGenerateColumns="False" OnItemDataBound="gv_tasks_ItemDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" Width="1497px" ForeColor="Black" OnSelectedIndexChanged="gv_tasks_SelectedIndexChanged" CssClass="auto-style14" 
        >
    <AlternatingItemStyle BackColor="White" />
    <Columns>
        <asp:BoundColumn DataField="task_type_id" HeaderText="task_type_id" Visible="false">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="task_type_name" HeaderText="Task Name">
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Active Task">
         <ItemTemplate>
                         <asp:radiobuttonlist ID="rb_active" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="rb_active_change">
                                 <asp:ListItem Value="1">Active</asp:ListItem>
    <asp:ListItem Value="0">Not Active</asp:ListItem>
    </asp:radiobuttonlist>
                        </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle HorizontalAlign="Center" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <ItemStyle BackColor="#F7F7DE" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
    <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
       
<br />
<hr />
<h4><b>Add new feature to project</b></h4>
    <table>
        <tr>
            <td class="auto-style7"><strong>Task Name</strong></td>     
        </tr>
         <tr>
            <td class="auto-style5">
                <asp:TextBox ID="tb_new_task_name" runat="server" MaxLength="450" Width="152px"></asp:TextBox></td>           
         </tr>
    </table>
    <br />
<asp:Button ID="Button1" runat="server" Text="Add new feature" OnClick="Button1_Click" />
    <br />

    <asp:Label runat="server" id="lbl_err" Font-Bold="True" ForeColor="Red" 
            Visible="False" ></asp:Label>
        </div>

</asp:Content>

