<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" Async="true" CodeBehind="cc_skor.aspx.cs" Inherits="TomTom_Info_Page.cpp.cc_skor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br /><asp:Label ID="Label4" runat="server" Text="Committer Controller priorities sKOR Env" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr /><br />
  

<asp:Button runat="server" ID="bt_add" Text="Add new project to CC" OnClick="bt_add_Click"></asp:Button>
<asp:Panel runat="server" ID="p_add" Visible="false">
    <hr />
<table>
    <tr>
        <td><asp:Label runat="server" Text="Project/Tool name"></asp:Label></td><td><asp:TextBox runat="server" ID="tb_new_project"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Priority"></asp:Label></td><td><asp:DropDownList ID="dd_priority" runat="server" OnSelectedIndexChanged="dd_priority_SelectedIndexChanged">
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td></td><td><asp:Button runat="server" Text="Add" OnClick="Unnamed4_Click"></asp:Button></td>
    </tr>
</table>
    <br />
    <hr />
      <asp:Label runat="server" ID="lbl_err_np" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
 
    </asp:Panel>

<asp:Label runat="server" ID="lbl_status_new" Text=""></asp:Label>
  <asp:DataGrid ID="gv_results" runat="server" AutoGenerateColumns="False" OnItemDataBound="gd_results_ItemDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
      <AlternatingItemStyle BackColor="White" />
      <FooterStyle BackColor="#CCCC99" />
      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
      <ItemStyle BackColor="#F7F7DE" />
      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
      <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
       <Columns>       
            <asp:BoundColumn DataField="Tool Name" HeaderText="Tool Name"  HeaderStyle-Font-Size="Small"
                        SortExpression="Tool Name"  >
<HeaderStyle Font-Size="Small"></HeaderStyle>
                    </asp:BoundColumn>
                 <asp:BoundColumn DataField="priority" HeaderText="Priority"  HeaderStyle-Font-Size="Small"
                        SortExpression="priority" Visible="False"  >
<HeaderStyle Font-Size="Small"></HeaderStyle>
                    </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Priority"   HeaderStyle-Font-Size="Small">
                        <ItemTemplate>
                             <asp:DropDownList ID="ddl_new_prio" runat="server" AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true" OnSelectedIndexChanged="change_prio">                                       
                             </asp:DropDownList>
                        </ItemTemplate>

<HeaderStyle Font-Size="Small"></HeaderStyle>
                   </asp:TemplateColumn >     
                <asp:TemplateColumn >
                        <ItemTemplate>            <asp:ImageButton runat="server" ImageUrl="~/img/cross.bmp" OnClick="Unnamed4_Click1"></asp:ImageButton>
                        </ItemTemplate>

<HeaderStyle Font-Size="Small"></HeaderStyle>
                   </asp:TemplateColumn >     
           </Columns>
    </asp:DataGrid>
    <br />
     <asp:Label runat="server" ID="lbl_err" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                    

</asp:Content>
