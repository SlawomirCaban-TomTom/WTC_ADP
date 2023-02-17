<%@ Page Title="WTC Back dated entry" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="back_dated_entry.aspx.cs" Inherits="TomTom_Info_Page.WTC.back_dated_entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 148px;
        }

        .style2 {
            width: 201px;
        }

        .bgimg {
            background-image: url('../img/wtc.jpg');
            background-size: contain;
        }
    </style>
    <script language="javascript" type="text/javascript">
</script>
</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceholder1" runat="server">
    <style type="text/css">
        .style1 {
            width: 329px;
        }

        .auto-style3 {
            width: 321px;
        }

        .bgimg {
            background-image: url('../img/wtc.jpg');
            background-size: cover;
        }

        .style6 {
            width: 144px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function openCalendar1() {

            window.open('calendar.aspx?Ctlid=<%=txtdate.ClientID %>', 'Calendar', 'scrollbars=no,resizable=no,width=450,height=250');
            return false;
        }


    </script>

    <div class="bgimg">
        <asp:Label ID="Label1" runat="server" Text="Work Time Controler - WTC 5.0" Font-Bold="True" ForeColor="#996633"></asp:Label><br />
        <asp:Menu Visible="false" ID="Menu_mng" runat="server" BackColor="#F7F6F3"
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em"
            ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px"
            >
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


        <table>
            <tr>
                <td>

                    <strong>

                        <asp:Label runat="server" ID="lbl_name" Text=""></asp:Label>
                        <asp:Label runat="server" ID="lbl_firstname" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lbl_lastname" Text="" Visible="false"></asp:Label>
                    </strong>
                </td>

                <td class="style1"></td>


                <td><strong>
                    <asp:Label runat="server" ID="lbl_date" Text=""></asp:Label>
                </strong>
                </td>

            </tr>
        </table>



        <asp:Panel runat="server" ID="report_time" Visible="False">
            <br />
            <hr />
            <br />
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                    <ContentTemplate>

                        <table>
                            <tr>
                                <td class="auto-style3"></td>
  </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <table>
                   
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="ltdate" runat="server" Text="Date:" Visible="true"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtdate_CalendarExtender" runat="server"
                                                Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtdate">
                                            </asp:CalendarExtender>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Text="Leave Type:" Visible="true"></asp:Label></td>
                                        <td class="style6">
                                            <asp:DropDownList runat="server" ID="ddl_leave_type" Width="370px"
                                                AutoPostBack="True" Height="28px" OnSelectedIndexChanged="ddl_lave_type_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lb_dely_time" runat="server" Text="Delay Time:" Visible="False"
                                                ToolTip="Please enter delay time 2 digits allowed only "></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txt_time" runat="server" Visible="false" MaxLength="2"
                                                OnTextChanged="txt_time_TextChanged"></asp:TextBox>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" Text="Description:"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txt_desc" runat="server" Height="23px" MaxLength="50" Width="365px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_total" runat="server" Text="Total Count:" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </td>
                        <td align="center"></td>
                        <td>
                            <br />

                            <br />
                            <br />
                            <br />
                            <asp:Button runat="server" Text="Add" Height="42px" Width="67px"
                                OnClick="Unnamed7_Click" ID="bt_report"></asp:Button><br />
                            <br />

                        </td>
                    </tr>

                </table>

            </div>

            <br />
            <hr />
        </asp:Panel>

        <asp:Label ID="lbl_err" runat="server" Font-Bold="True" ForeColor="#FF3300"
            Visible="False"></asp:Label>
    </div>
</asp:Content>
