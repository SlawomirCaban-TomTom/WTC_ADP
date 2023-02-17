<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="mdsrefresher_dashboard_aws4.aspx.cs" Inherits="TomTom_Info_Page.cpp.mdsrefresher_dashboard_aws4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <br /><asp:Label ID="Label4" runat="server" Text="MDS Refresher Dashboard 04" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr />
    <br />
    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" Width="80px" />
&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://infopage-lodz.ttg.global/cpp/mdsrefresher_machines.aspx" Target="_blank" Visible="False">View machines</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnViewgroupid" runat="server" OnClick="btnViewgroupid_Click" Text="View details for multiple group_id (comma separated)" Width="326px" />
    <asp:TextBox ID="txtgroupids" runat="server" Width="1067px" ToolTip="provide comma delimted group_id"></asp:TextBox>
    &nbsp;&nbsp; <br /><br />
    

    <strong> <asp:Label runat="server" Text="mds groupid details" ID="lblDetails" Visible="False"></asp:Label>
    <asp:DropDownList ID="ddlFeaturesBatches" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFeaturesBatches_SelectedIndexChanged" Visible="False">
        <asp:ListItem Value="'Features','Batches'">--All--</asp:ListItem>
        <asp:ListItem Value="'Features'" Selected="True" >featues</asp:ListItem>
        <asp:ListItem Value="'Batches'">batches</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Visible="False">
        <asp:ListItem Value="0" Selected="True">--All statuses--</asp:ListItem>
        <asp:ListItem Value="1">Only running</asp:ListItem>
    </asp:DropDownList>
    </strong>
            <asp:GridView ID="groupiddetails" OnRowDataBound="groupiddetails_RowDataBound" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" Wrap="False" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <br />
     <strong>mds overview&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
    <asp:CheckBox ID="cbProfile" runat="server" Text="speedprofiles" AutoPostBack="True" />
    <asp:CheckBox ID="cbCategory" runat="server" Text="speedcategory" AutoPostBack="True" />
&nbsp;<asp:GridView ID="refreshjobs" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="refreshjobs_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="progress" HeaderText="progress" SortExpression="progress" DataFormatString="{0:p0}"></asp:BoundField>
            <asp:BoundField DataField="zone" HeaderText="zone" SortExpression="zone"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="job_id" DataNavigateUrlFormatString="http://rprod-cpp-mdscontentrefresher201-r2-101.flatns.net:8080/mds-content-refresher-service/status/job/{0}/details" DataTextField="job_id" DataTextFormatString="{0}" HeaderText="job_id" Target="_blank"></asp:HyperLinkField>
            <asp:BoundField DataField="job_name" HeaderText="job_name" SortExpression="job_name"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="group_id" DataNavigateUrlFormatString="?groupid={0}" DataTextField="group_id" DataTextFormatString="{0}" HeaderText="group_id" Target="_blank"></asp:HyperLinkField>
            <asp:BoundField DataField="canceled" HeaderText="canceled" SortExpression="canceled"></asp:BoundField>
            <asp:BoundField DataField="total_task_count" HeaderText="total_task_count" SortExpression="total_task_count"></asp:BoundField>
            <asp:BoundField DataField="processing_task_count" HeaderText="processing_task_count" SortExpression="processing_task_count"></asp:BoundField>
            <asp:BoundField DataField="failed_task_count" HeaderText="failed_task_count" SortExpression="failed_task_count"></asp:BoundField>
            <asp:BoundField DataField="finished_task_count" HeaderText="finished_task_count" SortExpression="finished_task_count"></asp:BoundField>
            <asp:BoundField DataField="created" HeaderText="created" SortExpression="created"></asp:BoundField>
            <asp:BoundField DataField="continent" HeaderText="continent" SortExpression="continent"></asp:BoundField>
            <asp:BoundField DataField="release" HeaderText="release" SortExpression="release"></asp:BoundField>
            <asp:BoundField DataField="zone_type" HeaderText="zone_type" SortExpression="zone_type"></asp:BoundField>
            <asp:BoundField DataField="parameters" HeaderText="parameters" SortExpression="parameters"></asp:BoundField>
            <asp:BoundField DataField="dry_run" HeaderText="dry_run" SortExpression="dry_run"></asp:BoundField>
            <asp:BoundField DataField="project_id" HeaderText="project_id" SortExpression="project_id"></asp:BoundField>
            <asp:BoundField DataField="last_updated" HeaderText="last_updated" SortExpression="last_updated"></asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" Wrap="False" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <br />

    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>

</asp:Content>
