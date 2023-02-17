<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="mdsrefresher_dashboard_aws.aspx.cs" Inherits="TomTom_Info_Page.cpp.mdsrefresher_dashboard_aws" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://code.jquery.com/jquery-1.11.3.js"></script>
        <script type="text/javascript" language="javascript">
            var gridViewId = '#<%= refreshjobs.ClientID %>';
            function checkAll(selectAllCheckbox) {
                //get all checkboxes within item rows and select/deselect based on select all checked status
                //:checkbox is jquery selector to get all checkboxes
                $('td :checkbox', gridViewId).prop("checked", selectAllCheckbox.checked);
            }
            function unCheckSelectAll(selectCheckbox) {
                //if any item is unchecked, uncheck header checkbox as well
                if (!selectCheckbox.checked)
                    $('th :checkbox', gridViewId).prop("checked", false);
            }
        </script>
    <br /><asp:Label ID="Label4" runat="server" Text="MDS Refresher Dashboard 03" Font-Size="Larger" Font-Bold="True"></asp:Label><br /><hr />
     <strong>Daily stats:</strong><br />
     <asp:GridView ID="dailystats_gv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
         <AlternatingRowStyle BackColor="White" />
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <sortedascendingcellstyle backcolor="#F5F7FB" />
         <sortedascendingheaderstyle backcolor="#6D95E1" />
         <sorteddescendingcellstyle backcolor="#E9EBEF" />
         <sorteddescendingheaderstyle backcolor="#4870BE" />
     </asp:GridView>
     <a href="http://jenkins.maps-contentprocessing-prod.amiefarm.com:8080/job/mds_refresher_dailystats/">http://jenkins.maps-contentprocessing-prod.amiefarm.com:8080/job/mds_refresher_dailystats/</a><br />
    <br /></b> <hr />

     <asp:Button ID="btnViewgroupid" runat="server" OnClick="GetSelectedRecords" Text="Show commited features for selected jobs" Width="336px" />   
  <br />
   
            <asp:GridView ID="groupiddetails" OnRowDataBound="groupiddetails_RowDataBound" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" Wrap="False" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>

    <asp:GridView ID="refreshjobs" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="refreshjobs_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                 <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" onclick="checkAll(this);" />
                    </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server"  />
            </ItemTemplate>
                 <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
            <asp:BoundField DataField="progress" HeaderText="progress" SortExpression="progress" DataFormatString="{0:p0}"></asp:BoundField>
            <asp:BoundField DataField="zone" HeaderText="zone" SortExpression="zone"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="job_id" DataNavigateUrlFormatString="http://mcrcore03-cpp-mdscontentrefreshercore03-r2-101.node.eu-west-1-mapspucoreprodeu.maps-pu-core-prod.amiefarm.com:8080/mds-content-refresher-service/status/details.html?uuid={0}" DataTextField="job_id" DataTextFormatString="{0}" HeaderText="job_id" Target="_blank"></asp:HyperLinkField>
            <asp:BoundField DataField="job_name" HeaderText="job_name" SortExpression="job_name"></asp:BoundField>
             <asp:BoundField DataField="group_id" HeaderText="group_id" SortExpression="group_id"></asp:BoundField>
            <asp:BoundField DataField="canceled" HeaderText="canceled" SortExpression="canceled"></asp:BoundField>
            <asp:BoundField DataField="total_task_count" HeaderText="total_task_count" SortExpression="total_task_count"></asp:BoundField>
            <asp:BoundField DataField="processing_task_count" HeaderText="processing_task_count" SortExpression="processing_task_count"></asp:BoundField>
            <asp:BoundField DataField="failed_task_count" HeaderText="failed_task_count" SortExpression="failed_task_count"></asp:BoundField>
            <asp:BoundField DataField="finished_task_count" HeaderText="finished_task_count" SortExpression="finished_task_count"></asp:BoundField>
            <asp:BoundField DataField="last_updated" HeaderText="last_updated" SortExpression="last_updated"></asp:BoundField>
            <asp:BoundField DataField="created" HeaderText="created" SortExpression="created"></asp:BoundField>
            <asp:BoundField DataField="project_id" HeaderText="project_id" SortExpression="project_id"></asp:BoundField>
            
            <asp:BoundField DataField="continent" HeaderText="continent" SortExpression="continent"></asp:BoundField>
            <asp:BoundField DataField="release" HeaderText="release" SortExpression="release"></asp:BoundField>
            <asp:BoundField DataField="zone_type" HeaderText="zone_type" SortExpression="zone_type"></asp:BoundField>
            <asp:BoundField DataField="parameters" HeaderText="parameters" SortExpression="parameters"></asp:BoundField>
            <asp:BoundField DataField="dry_run" HeaderText="dry_run" SortExpression="dry_run"></asp:BoundField>
            
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" Wrap="False" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <br />
    <asp:GridView runat="server" id="gvSelected" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="groupid" HeaderText="groupid" ItemStyle-Width="150" />
    </Columns>
    </asp:GridView>
    <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>




     <asp:TextBox ID="txtgroupids" runat="server" Width="1067px" ToolTip="provide comma delimted group_id" Visible="False"></asp:TextBox>
 
     

    <strong> <asp:Label runat="server" Text="mds groupid details" ID="lblDetails" Visible="False"></asp:Label>
    <asp:DropDownList ID="ddlFeaturesBatches" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFeaturesBatches_SelectedIndexChanged" Visible="False">
        <asp:ListItem Value="'Features','Batches'">--All--</asp:ListItem>
        <asp:ListItem Value="'Features'" Selected="True" >featues</asp:ListItem>
        <asp:ListItem Value="'Batches'">batches</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Visible="False">
        <asp:ListItem Value="0">--All statuses--</asp:ListItem>
        <asp:ListItem Value="1" Selected="True">Only commited</asp:ListItem>
    </asp:DropDownList>
    </strong>
    
    <asp:CheckBox ID="cbProfile" runat="server" Text="speedprofiles" AutoPostBack="True" Checked="True" Visible="False" />
    <asp:CheckBox ID="cbCategory" runat="server" Text="speedcategory" AutoPostBack="True" Visible="False" />
&nbsp;
</asp:Content>
