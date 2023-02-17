<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="caj_dashboard_new.aspx.cs" Inherits="TomTom_Info_Page.cpp.caj_dashboard_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .FixedHeader {
            #position: absolute;
            vertical-align:text-bottom;
            margin-top:-20px;
        }      
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <asp:Label ID="Label4" runat="server" Text="CAJ  Dashboard Prod 4" Font-Size="Larger" Font-Bold="True"></asp:Label>
    <br />
    <hr />
    <br /><strong>caj-production-4.cilsxbffebe8.eu-west-1.rds.amazonaws.com</strong><br />
    <br />
    <asp:DropDownList ID="ddProject" runat="server" AutoPostBack="True" Height="28px" Width="299px" AppendDataBoundItems="True" Font-Size="Small">
        <asp:ListItem Text="<All projects>" Value="0" />
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" BackColor="#FFFFCC" NavigateUrl="http://infopage-lodz.ttg.global/cpp/caj_status_legend.aspx" Target="_blank">CAJ status description</asp:HyperLink>

    <br />
    
  <!--  <div style="height: 700px; overflow: auto;" align="left">-->
    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Enabled="False" Text="only active projects" />
    <asp:GridView runat="server" ID="dgDashboard" OnSorting="GridView_Sorting" AllowSorting="True" AutoGenerateColumns="False" EnableModelValidation="True" BackColor="White" BorderColor="#353481" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Small" 
        HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="#9999FF" 
OnRowDataBound="gvDistricts_RowDataBound"  >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            
            <asp:TemplateField HeaderText="name" HeaderStyle-Width="400px" ItemStyle-Width="400px" SortExpression="name">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" 

                    Text='<%#Eval("name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="project_id" HeaderStyle-Width="240px" ItemStyle-Width="240px" SortExpression="project_id">
                <ItemTemplate>
                    <asp:Label ID="lblproject_id" runat="server" 

                    Text='<%#Eval("project_id")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            
            <asp:TemplateField HeaderText="Auto_calc_QC" HeaderStyle-Width="" ItemStyle-Width="" SortExpression="Automatic_calculation_done_and_in_QC">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" 

                    Text='<%#Eval("Automatic_calculation_done_and_in_QC")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="commit_requested" HeaderStyle-Width="" ItemStyle-Width="" SortExpression="commit_requested">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" 

                    Text='<%#Eval("commit_requested")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="commit_exception" HeaderStyle-Width="" ItemStyle-Width="" SortExpression="commit_exception">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" 

                    Text='<%#Eval("commit_exception")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="commit_done" HeaderStyle-Width="" ItemStyle-Width="" SortExpression="commit_done">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" 

                    Text='<%#Eval("commit_done")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="Larger" />
        

        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
     <!--   </div>-->
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>


</asp:Content>
