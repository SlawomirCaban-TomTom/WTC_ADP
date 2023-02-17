<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="cor_dashboard.aspx.cs" Inherits="TomTom_Info_Page.cpp.cor_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><asp:Label ID="Label4" runat="server" Text="COR Dashboard" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr /><br />

    Latest report in csv: <asp:HyperLink ID="HyperLink1" runat="server" >       </asp:HyperLink>
    <br />
    <br />
    Jenkins job:  <asp:HyperLink runat="server" NavigateUrl="http://jenkins-adp-lodz.tomtomgroup.com:8080/view/Dashboards/job/CORDashboard/ws/" Target="_blank">http://jenkins-adp-lodz.tomtomgroup.com:8080/view/Dashboards/job/CORDashboard/ws/</asp:HyperLink>
    <br />
         <br />Shows only active projects &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="32px" AutoPostBack="True" Visible="False">1500</asp:TextBox>
    &nbsp;&nbsp;&nbsp; Last refresh date_time:
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>

    <asp:GridView ID="GridView1" runat="server"  HeaderStyle-BackColor="YellowGreen" 
AutoGenerateColumns="false" AlternatingRowStyle-BackColor="WhiteSmoke" 
OnRowDataBound="gvDistricts_RowDataBound" Font-Size="Smaller">  
        <Columns>
            
            <asp:TemplateField HeaderText="project_id" 
            HeaderStyle-Width="350px" ItemStyle-Width="350px">
                <ItemTemplate>
                    <asp:Label ID="project_id" runat="server" 
                    Text='<%#Eval("project_id")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="name" 
            HeaderStyle-Width="150px" ItemStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="name" runat="server" 
                    Text='<%#Eval("name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ready to calculate" 
            HeaderStyle-Width="150px" ItemStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="ready_to_calculate" runat="server" 
                    Text='<%#Eval("ready_to_calculate")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="tx to commit" 
            HeaderStyle-Width="150px" ItemStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="tx_to_commit" runat="server" 
                    Text='<%#Eval("tx_to_commit")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="calculation quality violation" 
            HeaderStyle-Width="50px" ItemStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="calculation_quality_violation" runat="server" 
                    Text='<%#Eval("calculation_quality_violation")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
      
        </Columns>
    </asp:GridView>

    
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
</asp:Content>
