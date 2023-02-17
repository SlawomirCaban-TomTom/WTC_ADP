<%@ Page Title="WTC New Project" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="new_project.aspx.cs" Inherits="TomTom_Info_Page.WTC.new_project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 329px;
        }

        .bgimg {
            background-image: url('../img/wtc.jpg');
            background-size: cover;
        }

        .auto-style2 {
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        <h1>Add new Project/Task</h1>
        <h4>
            <asp:Label runat="server" Text="required format:"></asp:Label>
        </h4>
        <table>
            <tr>
                <td>project name</td>
                <td>;</td>
                <td>feature</td>
                <td>;</td>
                <td>PU</td>
                </tr>
        </table>
        <br />

        <asp:TextBox ID="tb_add_project" runat="server" Rows="30" TextMode="MultiLine"
            Width="1113px" OnTextChanged="tb_add_project_TextChanged" BackColor="#FFFFCC"></asp:TextBox>
        <br />
        <asp:Button runat="server" Text="insert" OnClick="Unnamed6_Click"></asp:Button>
        <br />

        <asp:Label ID="lbl_v2_result" runat="server" Text="" Font-Bold="true"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lbl_fail" runat="server" Text="Following rows where not imported:" Font-Bold="True" Visible="False" Font-Underline="True"></asp:Label>
        <br />
        <asp:Panel ID="p_params" runat="server" Visible="false">
            <strong>
                <asp:Label runat="server" Text="invalid number of parameters"></asp:Label>
            </strong>
            <asp:GridView ID="gv_params" runat="server" ShowHeader="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="p_not_valid" runat="server" Visible="false">
            <strong>
                <asp:Label runat="server" Text="Project + task already exist"></asp:Label>
            </strong>
            <asp:GridView ID="gv_not_valid" runat="server" ShowHeader="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="p_pu" runat="server" Visible="false">
            <strong>
                <asp:Label runat="server" Text="Missing PU"></asp:Label>
            </strong>
            <asp:GridView ID="gv_pu" runat="server" ShowHeader="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>

        <br />
        <hr />
        <h4>active values:</h4>
        <table align="left">
            <tr>
                <td valign="top" align="center">PUs</td>
                <td valign="top" align="center">Features</td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="gv_pus" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataSourceID="sds_pus"
                        ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="pu" HeaderText="PU" SortExpression="pu"></asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sds_pus" runat="server"
                        ConnectionString="<%$ ConnectionStrings:WTCConnStr %>"
                        SelectCommand="SELECT [pu] FROM [pus] where is_active=1 ORDER BY [pu]"></asp:SqlDataSource>
                </td>
                <td valign="top">
                    <asp:GridView ID="gv_tools" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataSourceID="sds_tools"
                        ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="task_type_name" HeaderText="Feature" SortExpression="task_type_name"></asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sds_tools" runat="server"
                        ConnectionString="<%$ ConnectionStrings:WTCConnStr %>"
                        SelectCommand="SELECT distinct [task_type_name] FROM [task_type] ORDER BY [task_type_name]"></asp:SqlDataSource>
                </td>
            </tr>



        </table>

        <br />
    
        <br />
        <asp:Label runat="server" ID="lbl_results" Font-Bold="True"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lbl_err" Font-Bold="True" ForeColor="Red"
            Visible="False"></asp:Label>
        </div>
</asp:Content>
